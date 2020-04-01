using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using Classes;
using System.Threading;
using System.Globalization;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperExemptionClaim : System.Web.UI.Page
    {
        string PRNumber = null;
        private string Elg_FormNo;
        clsUser user;
        InstituteRepository InstRep = new InstituteRepository();


        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent), this.Page);
            user = (clsUser)Session["User"];
            //handling college login
            if (user.UserTypeCode == "2")
            {
                hidUserType.Value = "2";
                hidInstID.Value = user.UserReferenceID;
                DataTable dt = new DataTable();
                dt = InstRep.InstituteDetails(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value);
                lblAcaYear.Text = "for " + dt.Rows[0]["Inst_Name"] + " [" + dt.Rows[0]["Inst_Code"] + "]";
            }
            else
                hidUserType.Value = "1";

            hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();

            try
            {
                hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
            }
            catch
            {
                hidIsPRNValidationRequired.Value = "N";
            }


        }

        #endregion

        #region btnSimpleSearch_Click

        protected void btnSimpleSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            //lblCrPrTermHead.Text = "List of available Course Part Terms";
            divCourses.Style.Add("display", "block");           

            /* call SP for listing all courses of a student here */

            if (txtElgFormNo.Text != "")
            {
                Elg_FormNo = txtElgFormNo.Text.Trim();
            }

            else
            {
                Elg_FormNo = "0-0-0-0";
            }

            int cnt = 0;
            string str = Elg_FormNo;
            int pos = str.IndexOf('-');
            string[] arr = new string[] { "0", "0", "0", "0" };
            Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");

            if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                PRNumber = txtPRN.Text.Trim();

            while (pos != -1)
            {
                str = str.Substring(pos + 1);
                pos = str.IndexOf('-');
                cnt++;

            }
            if (cnt == 3)
            {
                arr = new string[4];
                arr = Elg_FormNo.Split('-');   //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
                for (int i = 0; i < 4; i++)
                {
                    if (arr[i] == "")
                        arr[i] = "0";
                }
            }

            dt = ElgClasses.clsCollegeAdmissionReports.ListStudentwiseCrPrTerms_ExemptionClaim(PRNumber, arr[0], arr[1], arr[2], arr[3]);

            if (dt != null && dt.Rows.Count > 0)
            {
                GVCourseTerms.Visible = true;
                divNoteEnabledLink.Style.Add("display", "block");
                lblCrPrTermHead.Visible = true;
                lblNoRecordsFound.Visible = false;

                GVCourseTerms.DataSource = dt;
                GVCourseTerms.DataBind();
                //storing UniID, YearID, StudentID in hidden fields
                arr = dt.Rows[0].ItemArray[0].ToString().Split('-');
                hidUniID.Value = arr[0].ToString();
                DataRow Dr = dt.Rows[0];
                hidYearID.Value = Dr["pkYear"].ToString();
                hidStudentID.Value = Dr["pkStudentID"].ToString();
                hidPRN.Value = txtPRN.Text;
                hidElgFormNo.Value = txtElgFormNo.Text;

                // changing Page Heading according to selected student
                lblAcaYear.Text = " for " + Dr["StudentName"].ToString() + " for " + Dr["CourseName"].ToString();
                hidHeading.Value = Dr["StudentName"].ToString() + " for " + Dr["CourseName"].ToString();
            }
            else
            {
                GVCourseTerms.Visible = false;
                lblNoRecordsFound.Visible = true;

                if (txtElgFormNo.Text == "")
                    lblNoRecordsFound.Text = "Student does not exist for entered " + lblPRNNomenclature.Text;
                else
                    lblNoRecordsFound.Text = "Student does not exist for entered Eligibility form number";

                divNoteEnabledLink.Style.Add("display", "none");
                lblCrPrTermHead.Visible = false;
                lblAcaYear.Text = "";
                
            }

        }

        #endregion

        #region GridView events
        protected void GVCourseTerms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string UniID, YearID, StudentID,pkFacID, pkCrID, pkMoLrnID, pkPtrnID, pkBrnID, pkCrPrDetails, pkCrPrChID;
            DataSet DsPapers = new DataSet();

            if (e.CommandName == "SelectCrPrTerm")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GVCourseTerms.Rows[index];
                hidpkFacID.Value = GVCourseTerms.DataKeys[index]["pkFacID"].ToString();
                hidpkCrID.Value = GVCourseTerms.DataKeys[index]["pkCrID"].ToString();
                hidpkMoLrnID.Value = GVCourseTerms.DataKeys[index]["pkMoLrnID"].ToString();
                hidpkPtrnID.Value = GVCourseTerms.DataKeys[index]["pkPtrnID"].ToString();
                hidpkBrnID.Value = GVCourseTerms.DataKeys[index]["pkBrnID"].ToString();
                hidpkCrPrDetails.Value = GVCourseTerms.DataKeys[index]["pkCrPrDetails"].ToString();
                hidpkCrPrChID.Value = GVCourseTerms.DataKeys[index]["pkCrPrChID"].ToString();

                /* Call SP for listing papers of selected CrPrTerm here */
                // This returns 2 DataTables
                DsPapers = ElgClasses.clsCollegeAdmissionReports.ListCrPrTermwisePapers_ExemptionClaim(hidUniID.Value, hidYearID.Value, hidStudentID.Value, hidpkFacID.Value, hidpkCrID.Value, hidpkMoLrnID.Value, hidpkPtrnID.Value, hidpkBrnID.Value, hidpkCrPrDetails.Value, hidpkCrPrChID.Value);

                //***********************************************************************************
                //filling old claims GV
                DataTable dt = DsPapers.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblGVPapersOldHeading.Visible = true;
                    GVPapersOld.DataSource = dt;
                    GVPapersOld.DataBind();
                    divPapersOld.Style.Add("display", "block");
                }
                else
                {
                    lblGVPapersOldHeading.Visible = false;
                    divPapersOld.Style.Add("display", "none");
                }
                //***********************************************************************************
                
                //filling fresh claim GV
                dt = DsPapers.Tables[1];
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblGVPapersNewHeading.Visible = true;
                    btnProceed.Visible = true;

                    GVPapersNew.Visible = true;
                    GVPapersNew.DataSource = dt;
                    GVPapersNew.DataBind();
                    divPapersNew.Style.Add("display", "block");
                }
                else
                {
                    GVPapersNew.Visible = false;
                    lblGVPapersNewHeading.Visible = false;
                    btnProceed.Visible = false;
                    divPapersNew.Style.Add("display", "none");
                }
                //***********************************************************************************
                divCourses.Style.Add("display", "none");
                divSimpleSearch.Style.Add("display", "none");
                divPapers.Style.Add("display", "block");
                btnBack.Style.Add("display", "block");

                lblAcaYear.Text = " for " + row.Cells[1].Text + " for " + row.Cells[3].Text;
                hidHeading.Value = row.Cells[1].Text + " for " + row.Cells[3].Text;


                // Prototype coding
                //=======================================
                ////filling old claims GV
                //DataTable dt = new DataTable();
                //dt.Columns.Add("PpPpCode");
                //dt.Columns.Add("Status");
                //dt.Columns.Add("pk_Pp_PpHead_CrPrCh_ID");

                //DataRow dr = dt.NewRow();
                //dr["PpPpCode"] = "English (Compulsory) (15101)";
                //dr["Status"] = "Granted";
                //dr["pk_Pp_PpHead_CrPrCh_ID"] = "1";
                //dt.Rows.Add(dr);

                //dr = dt.NewRow();
                //dr["PpPpCode"] = "Optional Sociology Paper-III (15146) Lectures-Practical-UA";
                //dr["Status"] = "Granted";
                //dr["pk_Pp_PpHead_CrPrCh_ID"] = "2";
                //dt.Rows.Add(dr);

                //dr = dt.NewRow();
                //dr["PpPpCode"] = "Optional Sociology Paper-III (15146) Lectures-Theory-UA";
                //dr["Status"] = "Denied";
                //dr["pk_Pp_PpHead_CrPrCh_ID"] = "2";
                //dt.Rows.Add(dr);

                //dr = dt.NewRow();
                //dr["PpPpCode"] = "Optional Marathi Paper-III (15128) ";
                //dr["pk_Pp_PpHead_CrPrCh_ID"] = "3";
                //dr["Status"] = "Pending";
                //dt.Rows.Add(dr);

                //GVPapersOld.DataSource = dt;
                //GVPapersOld.DataBind();

                ////filling fresh claim GV
                //dt = new DataTable();
                //dt.Columns.Add("PpPpCode");
                //dt.Columns.Add("pk_Pp_PpHead_CrPrCh_ID");

                //dr = dt.NewRow();
                //dr["PpPpCode"] = "Optional Sociology Paper-II (15145)";
                //dr["pk_Pp_PpHead_CrPrCh_ID"] = "4";
                //dt.Rows.Add(dr);

                //dr = dt.NewRow();
                //dr["PpPpCode"] = "Optional Geography Paper-III (15140)";
                //dr["pk_Pp_PpHead_CrPrCh_ID"] = "5";
                //dt.Rows.Add(dr);

                //dr = dt.NewRow();
                //dr["PpPpCode"] = "Optional Sociology Paper-II (15145)";
                //dr["pk_Pp_PpHead_CrPrCh_ID"] = "6";
                //dt.Rows.Add(dr);

                //GVPapersNew.DataSource = dt;
                //GVPapersNew.DataBind();
                //=======================================
            }

        }

        //show or hide the Select Papers link button
        protected void GVCourseTerms_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (GVCourseTerms.DataKeys[e.Row.RowIndex]["PpExistsCnt"].ToString().Equals("0"))
                {
                   e.Row.Cells[4].Enabled = false;
                   
               }
            }
        }

        #endregion
       
        #region btnProceed_Click

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            /* Call SP for claiming exemption here*/

            // forming CSV string of all selected papers' PpPpHeadCrPrChIDs 
            string PpPpHeadCrPrChIDList = string.Empty;
            
            string userid = user.User_ID.ToString();
            int i;
            for (i = 0; i < GVPapersNew.Rows.Count; i++)
            {
                if (((CheckBox)GVPapersNew.Rows[i].Cells[2].FindControl("chkSelectApps")).Checked)
                {
                    PpPpHeadCrPrChIDList = PpPpHeadCrPrChIDList + GVPapersNew.DataKeys[i]["pk_Pp_PpHead_CrPrCh_ID"].ToString().Trim() + ", ";
                }
            }

            // calling SP 
            i = ElgClasses.clsCollegeAdmissionReports.ClaimExemptionForSelectedPapers(hidUniID.Value, hidYearID.Value, hidStudentID.Value, hidpkFacID.Value, hidpkCrID.Value, hidpkMoLrnID.Value, hidpkPtrnID.Value, hidpkBrnID.Value, hidpkCrPrDetails.Value, hidpkCrPrChID.Value, PpPpHeadCrPrChIDList,userid);

            if (i != 0)
            {
                lblMsg.Style.Add("display", "block");
                //lblMsg.Text = "The Exemption has been successfully claimed for the selected paper(s)";
                RefillGridViews();
            }
        }

        #endregion

        #region btnBack_Click

        protected void btnBack_Click(object sender, EventArgs e)
        {
            divCourses.Style.Add("display", "block");
            divSimpleSearch.Style.Add("display", "block");
            divPapers.Style.Add("display", "none");
            btnBack.Style.Add("display", "none");
            lblMsg.Style.Add("display", "none");
            txtPRN.Text = hidPRN.Value;
            txtElgFormNo.Text = hidElgFormNo.Value;
            btnSimpleSearch_Click(sender, e);
        }

        #endregion

        #region RefillGridViews

        // Method to refresh both the GridViews after some papers are claimed for exemption
        protected void RefillGridViews()
        {
            DataSet DsPapers = new DataSet();
            // This returns 2 DataTables
            DsPapers = ElgClasses.clsCollegeAdmissionReports.ListCrPrTermwisePapers_ExemptionClaim(hidUniID.Value, hidYearID.Value, hidStudentID.Value, hidpkFacID.Value, hidpkCrID.Value, hidpkMoLrnID.Value, hidpkPtrnID.Value, hidpkBrnID.Value, hidpkCrPrDetails.Value, hidpkCrPrChID.Value);

            //***********************************************************************************
            //filling old claims GV
            DataTable dt = DsPapers.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                lblGVPapersOldHeading.Visible = true;
                GVPapersOld.DataSource = dt;
                GVPapersOld.DataBind();
                divPapersOld.Style.Add("display", "block");
            }
            else
            {
                lblGVPapersOldHeading.Visible = false;
                divPapersOld.Style.Add("display", "none");
            }
            //***********************************************************************************

            //filling fresh claim GV
            dt = DsPapers.Tables[1];
            if (dt != null && dt.Rows.Count > 0)
            {
                lblGVPapersNewHeading.Visible = true;
                btnProceed.Visible = true;

                GVPapersNew.DataSource = dt;
                GVPapersNew.DataBind();
                GVPapersNew.Visible = true;
                divPapersNew.Style.Add("display", "block");
            }
            else
            {
                GVPapersNew.Visible = false;
                lblGVPapersNewHeading.Visible = false;
                btnProceed.Visible = false;
                divPapersNew.Style.Add("display", "none");
            }
            //***********************************************************************************
        }

        #endregion

        #region Select All code

        protected void ChkHead_Checked(object sender, EventArgs e)
        {
            CheckBox Chk1 = (CheckBox)GVPapersNew.HeaderRow.Cells[2].FindControl("ChkHead");
            
            foreach (GridViewRow gv in GVPapersNew.Rows)
            {
                if (Chk1.Checked == true)
                {
                    ((CheckBox)gv.Cells[2].FindControl("chkSelectApps")).Checked = true;
                }
                else
                {
                    ((CheckBox)gv.Cells[2].FindControl("chkSelectApps")).Checked = false;
                }
            }
        }

        #endregion

    }
}
