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
using Classes;
using Ajax;
using AjaxControlToolkit;
using System.Threading;
using StudentRegistration.Eligibility.ElgClasses;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperExemptionApproval : System.Web.UI.Page
    {
        #region variable declaration

        clsCommon Common = new clsCommon();
        CourseRepository crRepository = new CourseRepository();
        InstituteRepository oInstituteRepository = new InstituteRepository();
        clsUser user;
        DataTable DT = new DataTable();
        string sUser;
        private string instIDs = "";
        DataTable oDT;
        DataTable dtCollege;
        private string[] IDs_List = new string[3];
        string PRNumber = null;
        private string Elg_FormNo;

        #endregion


        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["User"];
            //modified  by shafik on 09-oct-2012  added new hidden  as need to hide the academic year on  paper excemption approlval page
            YCMOU.hidIsAcdYrDdNotVisible.Value = "Yes";

            try
            {
                hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
            }
            catch
            {
                hidIsPRNValidationRequired.Value = "N";
            }

            // code added by Pankaj on 05/01/2011
            HtmlControl Cntp = (HtmlControl)YCMOU.FindControl("divAcadYear");
            Cntp.Style.Add("display", "none");
            DropDownList Ddl = (DropDownList)YCMOU.FindControl("ddlAcadYear");
            // Ddl.SelectedValue = "1";
            //  Ddl.SelectedValue = Session["pk_AcademicYear_ID"].ToString();
            //---------------------------------------------

            if (user != null && user.Exist)
            {
                sUser = user.User_ID;
            }
            else
            {
                Response.Redirect(Classes.clsGetSettings.SitePath.ToString() + "Logout.aspx");
            }

            //handling college login
            if (user.UserTypeCode == "2")
            {
                instIDs = user.UserReferenceID;
                hidInstID.Value = instIDs.ToString();
                hidCollName.Value = user.Name;
                YCMOU.IsCollegeLogin = true;
                YCMOU.IsFacultyDisplay = false;
                YCMOU.IsCourseDisply = false;
                YCMOU.IsCoursePartDisply = false;
                YCMOU.IsCourseTermDisply = false;
                YCMOU.IsBranchDisply = false;
                lblAcaYear.Text = hidCollName.Value;
            }

            if (!IsPostBack)
            {
                Session.Remove("dtdata");
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                YCMOU.IsReportUserAndDateDisplay = false;
                YCMOU.IsInstituteDisplay = false;
            }

            YCMOU.OnProceedClick += btnNext_Click;
            YCMOU.IsInstituteDisplay = false;
            tblExportedDataMsg.Style.Add("display", "none");

        }

        #endregion

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        #region getFacCrMoLrnPtrnID

        private void getFacCrMoLrnPtrnID()
        {
            if (((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedValue != "0")
            {
                IDs_List = Convert.ToString(((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedValue).Split('-');
                hidFacID.Value = Convert.ToString(IDs_List[0]).Trim();
                hidCrID.Value = Convert.ToString(IDs_List[1]).Trim();
                hidMoLrnID.Value = Convert.ToString(IDs_List[2]).Trim();
                hidPtrnID.Value = Convert.ToString(IDs_List[3]).Trim();
            }
            else
            {
                if (((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedValue == "0")
                {
                    hidCrID.Value = "0";
                    hidMoLrnID.Value = "0";
                    hidPtrnID.Value = "0";
                }
                hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
            }
        }

        #endregion

        #region btnNext_Click

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string courseOrColl = string.Empty;
            //for one college all courses
            if (user.UserTypeCode != "2")
            {
                //setting hidden vars from dropdown selections of user control 

                if (((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedIndex != 0 || ((TextBox)YCMOU.FindControl("txtCenterCode")).Text != string.Empty)
                {
                    hidInstID.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedValue.Split('|')[0];
                    hidCollName.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedItem.Text;
                    string rc_name = string.Empty;
                    if (YCMOU.IsRegionalCenterVisible)
                    {
                        if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
                        {
                            rc_name = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text + " - ";
                        }
                        else
                        {
                            rc_name = "All Regional Centers";
                        }
                    }
                    courseOrColl = rc_name + hidCollName.Value;
                    DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCollege(hidInstID.Value);
                    if (DT.Rows.Count > 0)
                    {
                        Server.Transfer("ELGV2_PaperExemptionApproval__1.aspx", true);
                    }
                    else
                    {
                        tblExportedDataMsg.Style.Add("display", "block");
                        lblExportedData.Text = "No Record(s) found.";
                    }
                }
                else
                {
                    hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
                    getFacCrMoLrnPtrnID();
                    hidCrPrDetailsID.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedValue;
                    hidCrPrChID.Value = ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedValue;
                    string rc_name = string.Empty;
                    if (YCMOU.IsRegionalCenterVisible)
                    {
                        if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
                        {
                            rc_name = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                            courseOrColl = rc_name + " - " + ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " +
                                ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " +
                                ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " +
                                ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " +
                                ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
                        }
                        else
                        {
                            rc_name = "All Regional Centers";
                            courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text +
                                " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text +
                                " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text +
                                " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " +
                                ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text + " - " + rc_name;

                        }
                    }
                    else
                    {
                        courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text +
                            " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " +
                            ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " +
                            ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " +
                            ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
                    }

                    //DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCourse(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                    //    hidCrPrDetailsID.Value, hidCrPrChID.Value);
                    DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCourse(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                        hidCrPrDetailsID.Value, hidCrPrChID.Value);
                    if (DT.Rows.Count > 0)
                    {
                        Server.Transfer("ELGV2_PaperExemptionApproval__1.aspx", true);
                    }
                    else
                    {
                        tblExportedDataMsg.Style.Add("display", "block");
                        lblExportedData.Text = "No Record(s) found.";
                    }

                }
            }
            //handling college login
            else if (user.UserTypeCode == "2")
            {
                courseOrColl = hidCollName.Value;
                //hid_fk_AcademicYr_ID.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue;
                DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCollege(hidInstID.Value);
                if (DT.Rows.Count > 0)
                {
                    //hidAcYrForCollLogin.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text;
                    Server.Transfer("ELGV2_PaperExemptionApproval__1.aspx", true);
                }

                else
                {
                    tblExportedDataMsg.Style.Add("display", "block");
                    lblExportedData.Text = "No Record(s) found.";
                }
            }

            if (((System.Data.DataTable)Session["dtdata"]) == null || ((System.Data.DataTable)Session["dtdata"]).Rows.Count == 0)
            {
                lblAcaYear.Text = courseOrColl; // +" [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                Session.Remove("dtdata");

            }

            if (dtCollege != null)
            {
                dtCollege = null;
            }
        }

        #endregion

        #region hide search criteria when report is shown

        private void HideSearchCriteria()
        {
            divYCMOU.Style.Add("display", "none");
        }
        #endregion

        #region Handling Simple Search for Student

        #region btnSimpleSearch_Click

        protected void btnSimpleSearch_Click(object sender, EventArgs e)
        {
            divYCMOU.Attributes.Add("style", "display:none");
            divSimpleSearch.Attributes.Add("style", "display:block");
            lblAdvSearch.Attributes.Add("style", "display:none");
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

            dt = ElgClasses.clsCollegeAdmissionReports.ListStudentwiseCrPrTerms_ExemptionApproval(PRNumber, arr[0], arr[1], arr[2], arr[3]);

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
            hidSelPaper.Value = string.Empty;
            DataSet DsPapers = new DataSet();

            if (e.CommandName == "SelectCrPrTerm")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GVCourseTerms.Rows[index];
                hidFacID.Value = GVCourseTerms.DataKeys[index]["pkFacID"].ToString();
                hidCrID.Value = GVCourseTerms.DataKeys[index]["pkCrID"].ToString();
                hidMoLrnID.Value = GVCourseTerms.DataKeys[index]["pkMoLrnID"].ToString();
                hidPtrnID.Value = GVCourseTerms.DataKeys[index]["pkPtrnID"].ToString();
                hidBrnID.Value = GVCourseTerms.DataKeys[index]["pkBrnID"].ToString();
                hidCrPrDetailsID.Value = GVCourseTerms.DataKeys[index]["pkCrPrDetails"].ToString();
                hidCrPrChID.Value = GVCourseTerms.DataKeys[index]["pkCrPrChID"].ToString();

                DT = clsCollegeAdmissionReports.FetchPaperTLMAMATForSimpleStudentSearch(hidUniID.Value, hidYearID.Value, hidStudentID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value,
                            hidCrPrDetailsID.Value, hidCrPrChID.Value);
                if (DT != null && DT.Rows.Count > 0)
                {
                    GVPapersNew.Visible = true;
                    GVPapersNew.DataSource = DT;
                    GVPapersNew.DataBind();
                    divPapers.Style.Add("display", "block");
                    btnApprove.Attributes.Add("style", "display:block");
                    btnDeny.Attributes.Add("style", "display:block");
                    btnBack.Attributes.Add("style", "display:block");
                    //fill tlm am ats in bulk select checkbox

                    hidSelPaper.Value = hidSelPaper.Value.TrimEnd(',');
                    DT = clsCollegeAdmissionReports.PaperExemptionFetchdistinctTLMAMAT(hidSelPaper.Value);

                    if (DT.Rows.Count > 0)
                    {
                        chkTLMAMAT.DataSource = DT;
                        chkTLMAMAT.DataBind();

                    }
                }
                else
                {
                    GVPapersNew.Visible = false;
                    divPapers.Style.Add("display", "none");
                }
                divCourses.Style.Add("display", "none");
                divSimpleSearch.Style.Add("display", "none");
                divPapers.Style.Add("display", "block");

                lblAcaYear.Text = " for " + row.Cells[1].Text + " for " + row.Cells[3].Text;
                hidHeading.Value = row.Cells[1].Text + " for " + row.Cells[3].Text;
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

        //getting all paper ids to obtain tlm am ats
        protected void GVPapersNew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                hidSelPaper.Value += GVPapersNew.DataKeys[e.Row.RowIndex]["pk_Pp_PpHead_CrPrCh_ID"].ToString() + ",";
            }
        }

        #endregion

        #region End button clicks

        protected void btnApproveOrDeny_Click(object sender, EventArgs e)
        {
            string SPXML = string.Empty;
            List<PaperStudXML> oPaperStudXMLList = new List<PaperStudXML>();
            PaperStudXML oPaperStudXML;
            for (int j = 0; j < GVPapersNew.Rows.Count; j++)
            {
                if (((CheckBox)GVPapersNew.Rows[j].Cells[2].FindControl("chkSelectStudents")).Checked)
                {
                    oPaperStudXML = new PaperStudXML();
                    oPaperStudXML.StudentID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Student_ID"].ToString());
                    oPaperStudXML.Year = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Year"].ToString());
                    oPaperStudXML.TLM = int.Parse(GVPapersNew.DataKeys[j].Values["TLM-AM-AT-ID"].ToString().Split('-')[0]);
                    oPaperStudXML.AM = int.Parse(GVPapersNew.DataKeys[j].Values["TLM-AM-AT-ID"].ToString().Split('-')[1]);
                    oPaperStudXML.AT = int.Parse(GVPapersNew.DataKeys[j].Values["TLM-AM-AT-ID"].ToString().Split('-')[2]);
                    oPaperStudXML.Pk_Pp_PpHead_CrPrCh_ID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Pp_PpHead_CrPrCh_ID"].ToString());
                    oPaperStudXML.FacID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Fac_ID"].ToString());
                    oPaperStudXML.CRID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Cr_ID"].ToString());
                    oPaperStudXML.MOLID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_MoLrn_ID"].ToString());
                    oPaperStudXML.PtrnID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Ptrn_ID"].ToString());
                    oPaperStudXML.BrnID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Brn_ID"].ToString());
                    oPaperStudXML.CrPrDetID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_CrPr_Details_ID"].ToString());
                    oPaperStudXML.CrPrChtID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_CrPrCh_ID"].ToString());
                    oPaperStudXML.UniID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Uni_ID"].ToString());
                    oPaperStudXMLList.Add(oPaperStudXML);                    
                }
            }

            //set hidden variables
            hidFacID.Value = GVPapersNew.DataKeys[0]["pk_Fac_ID"].ToString();
            hidCrID.Value = GVPapersNew.DataKeys[0]["pk_Cr_ID"].ToString();
            hidMoLrnID.Value = GVPapersNew.DataKeys[0]["pk_MoLrn_ID"].ToString();
            hidPtrnID.Value = GVPapersNew.DataKeys[0]["pk_Ptrn_ID"].ToString();
            hidBrnID.Value = GVPapersNew.DataKeys[0]["pk_Brn_ID"].ToString();
            hidCrPrDetailsID.Value = GVPapersNew.DataKeys[0]["pk_CrPr_Details_ID"].ToString();
            hidCrPrChID.Value = GVPapersNew.DataKeys[0]["pk_CrPrCh_ID"].ToString();
            hidStudentID.Value = GVPapersNew.DataKeys[0]["pk_Student_ID"].ToString();
            hid_fk_AcademicYr_ID.Value = GVPapersNew.DataKeys[0]["fk_AcademicYear_ID"].ToString();
            hidInstID.Value = GVPapersNew.DataKeys[0]["Ref_InstReg_Institute_ID"].ToString();
            hidYearID.Value = GVPapersNew.DataKeys[0]["pk_Year"].ToString();
            hidUniID.Value = GVPapersNew.DataKeys[0]["pk_Uni_ID"].ToString();
            

            //******************************
            //if (GVPapersNew.DataKeys[0]["fk_ExEv_ID"].ToString().Equals("0") || GVPapersNew.DataKeys[0]["fk_ExEv_ID"].ToString().Equals("-"))
            //{
            //    hidExamFormModifyReq.Value = "No";
            //}
            //else
            //{
            //    hidExamFormModifyReq.Value = "Yes";
            //}
            //******************************

            int result = 0;
            string status = string.Empty;
            if (((Button)sender).ID == "btnApprove")
            {
                result = clsCollegeAdmissionReports.PaperExemptionApproveOrDeny(user.User_ID, 1, PaperStudXML.SerializeObject(oPaperStudXMLList));
                status = "Granted";
            }
            else if (((Button)sender).ID == "btnDeny")
            {
                result = clsCollegeAdmissionReports.PaperExemptionApproveOrDeny(user.User_ID, 2, PaperStudXML.SerializeObject(oPaperStudXMLList));
                status = "Denied";
            }
            if (result != 0)
            {
                divMsg.Style.Add("display", "block");

                lblAppOrDenyMsg.Text = "The Exemption claimed is " + status + " successfully for the selected " + lblPaper.Text + "(s).";

                //send exam for modify request

                //if (hidExamFormModifyReq.Value.Equals("Yes"))
                //{
                    Hashtable HT = new Hashtable();
                    HT.Add("UniID", hidUniID.Value);
                    HT.Add("StudentID", hidStudentID.Value);
                    HT.Add("Year", hidYearID.Value);
                    HT.Add("InstID", hidInstID.Value);
                    HT.Add("FacID", hidFacID.Value);
                    HT.Add("CrID", hidCrID.Value);
                    HT.Add("MoLrnID", hidMoLrnID.Value);
                    HT.Add("PtrnID", hidPtrnID.Value);
                    HT.Add("BrnID", hidBrnID.Value);
                    HT.Add("CrPrDetailsID", hidCrPrDetailsID.Value);
                    HT.Add("CrPrChID", hidCrPrChID.Value);
                    HT.Add("AcYrID", hid_fk_AcademicYr_ID.Value);
                    HT.Add("CreatedBy", user.User_ID.ToString());
                    HT.Add("RequestDetails", createExamFormModifyXML());

                    if (clsPaperChange.SendExamFormModifyRequest_PaperExemptionApproval(HT).Equals("S")) //successful
                    {
                        //if (user.UserTypeCode != "2")
                        //{
                        //    lblAppOrDenyMsg.Text += "<br>An Exam Form Modify Request has been sent.";
                        //}
                        //else if (user.UserTypeCode == "2")
                        //{
                        //    lblAppOrDenyMsg.Text += "<br>An Exam Form Modify Request has been sent.";
                        //}

                        lblAppOrDenyMsg.Text += "<br>An Exam Form Modify Request has been sent.";
                    }

                    else
                    {
                        lblAppOrDenyMsg.Text += "<br>An Exam Form Modify Request could not be sent.";
                    }
                //}

                //refill grid view
                DT = clsCollegeAdmissionReports.FetchPaperTLMAMATForSimpleStudentSearch(hidUniID.Value, hidYearID.Value, hidStudentID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value,
                                            hidCrPrDetailsID.Value, hidCrPrChID.Value);
                if (DT.Rows.Count > 0)
                {
                    GVPapersNew.DataSource = DT;
                    GVPapersNew.DataBind();

                    chkTLMAMAT.ClearSelection();
                }
                else
                {
                    btnApprove.Style.Add("display", "none");
                    btnDeny.Style.Add("display", "none");
                    divTLMAMATChoice.Style.Add("display", "none");
                    divPapers.Style.Add("display", "none");
                    //tblExportedDataMsg.Style.Add("display", "block");
                    //lblExportedData.Text = "No Record(s) found.";
                }

            }
            else
            {
                divMsg.Style.Add("display", "block");
                lblAppOrDenyMsg.Text = "An error has occurred. Please try again later.";
            }

            if (oPaperStudXMLList != null)
                oPaperStudXMLList = null;

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            divCourses.Attributes.Add("style", "display:block");
            divSimpleSearch.Attributes.Add("style", "display:block");
            divPapers.Attributes.Add("style", "display:none");
            lblNoRecordsFound.Attributes.Add("style", "display:none");
            txtPRN.Text = hidPRN.Value;
            txtElgFormNo.Text = hidElgFormNo.Value;
            btnSimpleSearch_Click(sender, e);
            divMsg.Attributes.Add("style", "display:none");
            btnApprove.Attributes.Add("style", "display:none");
            btnDeny.Attributes.Add("style", "display:none");
            btnBack.Attributes.Add("style", "display:none");
        }

        #endregion

        #region Bulk Select

        protected void divTLMAMATChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //find which TLM-AM-AT is bulk selected or de selected

            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$'); ;
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);

            if (chkTLMAMAT.Items[index].Selected)
            {
                foreach (GridViewRow gv in GVPapersNew.Rows)
                {
                    if (GVPapersNew.DataKeys[gv.RowIndex]["TLM-AM-AT-ID"].ToString().Equals((chkTLMAMAT.Items[index].Value)))
                    {
                        ((CheckBox)gv.Cells[2].FindControl("chkSelectStudents")).Checked = true;
                    }
                }
            }
            else
            {
                foreach (GridViewRow gv in GVPapersNew.Rows)
                {
                    if (GVPapersNew.DataKeys[gv.RowIndex]["TLM-AM-AT-ID"].ToString().Equals((chkTLMAMAT.Items[index].Value)))
                    {
                        ((CheckBox)gv.Cells[2].FindControl("chkSelectStudents")).Checked = false;
                    }
                }
            }

        }

        #endregion

        #endregion

        # region Function CreateXML for Exam Form Modify Request
        /// <summary>
        /// Function Create XML (This will Xml for Papers with its Group Details)
        /// </summary>
        public string createExamFormModifyXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateNode(XmlNodeType.Element, "R", "");
            XmlNode child = xml.CreateNode(XmlNodeType.Element, "RT", "");
            child.Attributes.Append(xml.CreateAttribute("Type")).Value = "MEF";
            XmlNode student = xml.CreateNode(XmlNodeType.Element, "STU", "");
            student.Attributes.Append(xml.CreateAttribute("Year")).Value = hidYearID.Value;
            student.Attributes.Append(xml.CreateAttribute("StudentID")).Value = hidStudentID.Value;
            child.AppendChild(student);
            root.AppendChild(child);
            xml.AppendChild(root);
            return xml.OuterXml;
        }

        #endregion
    }
}


