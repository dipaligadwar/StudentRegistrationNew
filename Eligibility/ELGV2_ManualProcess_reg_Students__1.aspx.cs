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
using System.Globalization;
using System.Threading;
using System.Resources;
using StudentRegistration.Eligibility.ElgClasses;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_ManualProcess_reg_Students__1 : System.Web.UI.Page
    {
        #region Variables

        protected System.Web.UI.HtmlControls.HtmlInputHidden tehsilName;
        string PRNumber = null;
        private string Elg_FormNo;
        string qstrNavigate;
        string StrUrl;
        string searchType = "";
        string withORWithoutInv = "";
        Eligibility.WebCtrl.StudentAdvancedSearchforManualProcess_reg_Students StudentAdvancedSearchCtrl;
        clsCommon Common = new clsCommon();
        clsCommon CommonAcYr = new clsCommon();
        clsCache clsCache = new clsCache();
        string InstituteID = null;

        InstituteRepository InstRep = new InstituteRepository();
        #endregion

        #region PageLoad

        protected void Page_Load(object sender, System.EventArgs e)
        {
            clsCache.NoCache();            
            btnSimpleSearch.Attributes.Add("onclick", "return ChkValidation();");

            ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            StudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentAdvancedSearchforManualProcess_reg_Students)Cntph.FindControl("StudentAdvancedSearchforManualProcess1");

            //StudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentAdvancedSearchforManualProcess_reg_Students)Page.FindControl("StudentAdvancedSearchforManualProcess1");

            //********
            //hid_fk_AcademicYr_ID.Value = StudentAdvancedSearchCtrl.ddlAcademicYear.SelectedValue.ToString();
            //hidAcademicYrText.Value = StudentAdvancedSearchCtrl.ddlAcademicYear.SelectedItem.ToString();  

            if (!IsPostBack)
            {
                ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");                
                searchInstNew temp = (searchInstNew)Cntph1.FindControl("SchInst1");
                hidInstID.Value = ((HtmlInputHidden)Cntph1.FindControl("hidInstID")).Value;
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();

                try
                {
                    hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
                }
                catch
                {
                    hidIsPRNValidationRequired.Value = "N";
                }


                if (Request.QueryString["Search"] == "Simple" && Request.QueryString["Navigate"] == "back")
                {
                    hidPRN.Value = ((HtmlInputHidden)Cntph1.FindControl("hidPRN")).Value;
                    hidElgFormNo.Value = ((HtmlInputHidden)Cntph1.FindControl("hidElgFormNo")).Value;
                    hidIsBlank.Value = ((HtmlInputHidden)Cntph1.FindControl("hidIsBlank")).Value;
                }
                
                HtmlInputHidden[] hid = new HtmlInputHidden[20];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidElgFormNo;
                hid[3] = hidpkStudentID;
                hid[4] = hidpkYear;
                hid[5] = hidpkFacID;
                hid[6] = hidpkCrID;
                hid[7] = hidpkMoLrnID;
                hid[8] = hidpkPtrnID;
                hid[9] = hidpkBrnID;
                hid[10] = hidpkCrPrDetailsID;
                hid[11] = hidElgStatusColl;
                hid[12] = hidCollElgFlag;
                hid[13] = hidCollElgFlagReason;
                hid[14] = hidPRN;
                hid[15] = hidInv;
                hid[16] = hidIsBlank;
                hid[17] = hid_fk_AcademicYr_ID;                
                hid[18] = hidAcademicYrText;
                hid[19] = hidIsPRNValidationRequired;

                Common.setHiddenVariables(ref hid);
                
            }

            if (hidInstID.Value != "" && hidInstID.Value != null)
            {

                lblPageHead.Text = "Manual Process Eligibility";
                lblSubHeader.Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);

            }

            //StudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentAdvancedSearchforManualProcess_reg_Students)Page.FindControl("StudentAdvancedSearchForManualProcess1");
            StudentAdvancedSearchCtrl.QstrNavigate = null;
            
            StudentAdvancedSearchCtrl.StrUrl = "ELGV2_ManualProcess_reg_Students__2.aspx?Search=" + "Adv";
            StudentAdvancedSearchCtrl.GridType = "IA";
            if (Request.QueryString["Search"] == "Adv")
            {
                if (Request.QueryString["Navigate"] == "back")
                {
                    /*ContentPlaceHolder Cntph2 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");                
 
                    hidPRN.Value = ((HtmlInputHidden)Cntph1.FindControl("hidPRN")).Value;
                    hidElgFormNo.Value = ((HtmlInputHidden)Cntph1.FindControl("hidElgFormNo")).Value;
                    hidIsBlank.Value = ((HtmlInputHidden)Cntph1.FindControl("hidIsBlank")).Value;*/
                    
                    StudentAdvancedSearchCtrl.QstrNavigate = "back";
                   // StudentAdvancedSearchCtrl.StrUrl = "ELGV2_ManualProcess_reg_Students__2.aspx?Search=" + "Adv" + "&Inv=" + hidInv.Value.ToString() + "&CollElg=" + hidElgStatusColl.Value.ToString();
                   //// StudentAdvancedSearchCtrl.GridType = "IA";
                   // divAdvSearch.Style.Remove("display");
                   // divAdvSearch.Style.Add("display", "block");
                   // divSimpleSearch.Style.Remove("display");
                   // divSimpleSearch.Style.Add("display", "none");


                   // if (Request.QueryString["AcYear"] != "0")
                   // {
                   //     lblAcademicYear.Text = " [Academic Year " + Request.QueryString["AcYearText"].ToString() + "]"; //+ hidAcademicYrText.Value;
                   //     lblAcademicYear.Attributes.Add("style", "display:inline");
                   // }
                   // else if (Request.QueryString["AcYear"] == "0")
                   // {
                   //     lblAcademicYear.Attributes.Add("style", "display:none");
                   // }                   

                }
                else
                {
                    StudentAdvancedSearchCtrl.QstrNavigate = null;
                    StudentAdvancedSearchCtrl.StrUrl = "ELGV2_ManualProcess_reg_Students__2.aspx?Search=" + "Adv";                   
                }
            }
            else if (Request.QueryString["Search"] == "Simple")
            {
                if (Request.QueryString["Navigate"] == "back")
                {
                    StudentAdvancedSearchCtrl.QstrNavigate = "back";
                    //divAdvSearch.Style.Remove("display");
                    //divSimpleSearch.Style.Remove("display");
                    //divSimpleSearch.Style.Add("display", "block");
                    //divAdvSearch.Style.Add("display", "none");
                    //if (hidIsBlank.Value != "")
                    //{
                    //    txtElgFormNo.Text = hidElgFormNo.Value;
                    //}
                    //else
                    //{
                    //    txtPRN.Text = hidPRN.Value;
                    //}
                    //if (Request.QueryString["Inv"] == "1")
                    //{
                    //    rbWithInv.Checked = true;
                    //    rbWithoutInv.Checked = false;

                    //}


                    //else if (Request.QueryString["Inv"] == "0")
                    //{
                    //    rbWithoutInv.Checked = true;
                    //    rbWithInv.Checked = false;
                    //}

                    //fnFetchStudent();
                    
                }

             
              
            }

            //if (hidSearchType.Value == "Simple")
            //{
            //    divAdvSearch.Style.Remove("display");
            //    divSimpleSearch.Style.Remove("display");
            //    divSimpleSearch.Style.Add("display", "block");
            //    divAdvSearch.Style.Add("display", "none");

            //}
            //else if (hidSearchType.Value == "Adv")
            //{
            //    divAdvSearch.Style.Remove("display");
            //    divSimpleSearch.Style.Remove("display");
            //    divAdvSearch.Style.Add("display", "block");
            //    divSimpleSearch.Style.Add("display", "none");

            //    //if (hid_fk_AcademicYr_ID.Value != "0" || hid_fk_AcademicYr_ID.Value != "")
            //    if (hidAcademicYrText.Value != "--- Select ---")
            //    {
            //        lblAcademicYear.Text = " for Academic Year " + hidAcademicYrText.Value;
            //        lblAcademicYear.Attributes.Add("style", "display:inline");
            //    }
            //    else if (hidAcademicYrText.Value == "--- Select ---")
            //    {
            //        lblAcademicYear.Attributes.Add("style", "display:none");
                   
            //    }

            //}
        }

        #endregion

        #region Simple & Advanced Links

        protected void lnkSimpleSearch_Click(object sender, EventArgs e)
        {
            divSimpleSearch.Attributes.Add("style", "display:inline");
            divAdvSearch.Attributes.Add("style", "display:none");
            txtElgFormNo.Text = "";
            divErrorMsg.Attributes.Add("style", "display:none");
            //StudentAdvancedSearchCtrl.divAcademicYr.Attributes.Add("style", "display:none");
            StudentAdvancedSearchCtrl.tblSelect.Attributes.Add("style", "display:none");
            hidSearchType.Value = "Simple";

            hid_fk_AcademicYr_ID.Value = "0";
            lblAcademicYear.Attributes.Add("style", "display:none");


        }

        protected void lnkAdvSearch_Click(object sender, EventArgs e)
        {

            divSimpleSearch.Attributes.Add("style", "display:none");
            divAdvSearch.Attributes.Add("style", "display:block");
            txtElgFormNo.Text = "";
            hidSearchType.Value = "Adv";
            divErrorMsg.Attributes.Add("style", "display:none");
            //StudentAdvancedSearchCtrl.divAcademicYr.Attributes.Add("style", "display:block");
            StudentAdvancedSearchCtrl.tblSelect.Attributes.Add("style", "display:none");            
            StudentAdvancedSearchCtrl.divDGNote.Attributes.Add("style", "display:none");
            StudentAdvancedSearchCtrl.lblGridName.Attributes.Add("style", "display:none");
            //***
            //StudentAdvancedSearchCtrl.trbtnSearch.Attributes.Add("style", "display:none");
            StudentAdvancedSearchCtrl.tblDGRegPendingStudents.Attributes.Add("style", "display:none");
            hid_fk_AcademicYr_ID.Value = "0";
            lblAcademicYear.Attributes.Add("style", "display:none");

            DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
            //********
            //CommonAcYr.fillDropDown(StudentAdvancedSearchCtrl.ddlAcademicYear, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");

        }

        #endregion

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        #region btnSimpleSearch_Click

        protected void btnSimpleSearch_Click(object sender, System.EventArgs e)
        {
            fnFetchStudent();
        }
        
        #endregion

        #region Fetch Student Details

        private void fnFetchStudent()
        {
            {
                if (txtElgFormNo.Text != "")
                {
                    Elg_FormNo = txtElgFormNo.Text.Trim();
                    hidIsBlank.Value = Elg_FormNo;
                }

                else
                {
                    Elg_FormNo = "0-0-0-0";
                    hidIsBlank.Value = "";
                }

                int cnt = 0;
                string str = Elg_FormNo;
                int pos = str.IndexOf('-');
                string[] arr = new string[] { "0", "0", "0", "0" };
                Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");

                if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                    PRNumber = txtPRN.Text.Trim();
                    hidPRN.Value = PRNumber;
                    InstituteID = hidInstID.Value;

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
                DataSet ds = new DataSet();
                try
                {

                    //if (rbWithInv.Checked == true)
                    //{
                    //    ds = clsEligibilityDBAccess.Check_IA_Student_Exists_RegStu(arr[0], arr[1], arr[2], arr[3], txtPRN.Text, hidInstID.Value, txtElgFormNo.Text.Trim());
                    //    hidInv.Value = "1";
                    //}

                    //else if (rbWithoutInv.Checked == true)
                    //{
                        ds = clsEligibilityDBAccess.Check_IA_Student_Exists_bypassInv_RegStu(arr[0], arr[1], arr[2], arr[3], txtPRN.Text, hidInstID.Value,txtElgFormNo.Text.Trim());
                        hidInv.Value = "0";
                    //}

                    if (ds.Tables == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0 || ds.Tables[0] == null)
                    {
                        divErrorMsg.Style.Add("display", "block");
                        lblErrorMsg.Visible = true;
                        lblErrorMsg.Text = "The Student's data with Eligibility Form Number " + txtElgFormNo.Text.Trim() + "  might have processed or haven't uploaded yet.So please check the status to verify.";
                        lblErrorMsg.Style.Remove("display");
                        lblErrorMsg.Style.Add("display", "inline");

                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {

                        hidElgFormNo.Value = txtElgFormNo.Text.Trim();
                        hidpkStudentID.Value = ds.Tables[0].Rows[0]["pkStudentID"].ToString();
                        hidpkYear.Value = ds.Tables[0].Rows[0]["pkYear"].ToString();
                        hidpkFacID.Value = ds.Tables[0].Rows[0]["pkFacID"].ToString();
                        hidpkCrID.Value = ds.Tables[0].Rows[0]["pkCrID"].ToString();
                        hidpkMoLrnID.Value = ds.Tables[0].Rows[0]["pkMoLrnID"].ToString();
                        hidpkPtrnID.Value = ds.Tables[0].Rows[0]["pkPtrnID"].ToString();
                        hidpkBrnID.Value = ds.Tables[0].Rows[0]["pkBrnID"].ToString();
                        hidpkCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pkCrPrDetails"].ToString();
                        hidCollElgFlag.Value = ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString();
                        hidCollElgFlagReason.Value = ds.Tables[0].Rows[0]["Reason"].ToString();
                        hidPRN.Value = ds.Tables[0].Rows[0]["PRN"].ToString();
                        hid_fk_AcademicYr_ID.Value = ds.Tables[0].Rows[0]["fkAcademicYearID"].ToString();


                        dgRegStudents1.DataSource = ds;
                        dgRegStudents1.DataBind();
                        lblGrid.Text = "Please click on the Student Name to select the Student whose Eligibility for a particular " + lblCr.Text + " is to be processed";
                        tblDGRegPendingStudents.Attributes.Add("style", "display:block");
                        divErrorMsg.Style.Add("display", "none");
                        lblErrorMsg.Visible = false;

                        if (hidCollElgFlag.Value == "4")
                        {
                            hidElgStatusColl.Value = "1";
                        }

                        else
                        {
                            hidElgStatusColl.Value = "0";
                        }

                        if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "1")
                        {
                            hidCollElgFlag.Value = "1";
                            hidCollElgFlagReason.Value = ds.Tables[0].Rows[0]["Reason"].ToString();

                        }

                        if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "2")
                        {
                            hidCollElgFlag.Value = "2";


                        }
                        if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "3")
                        {
                            hidCollElgFlag.Value = "3";


                        }
                        if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "4")
                        {
                            hidCollElgFlag.Value = "4";


                        }
                        if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "5")
                        {
                            hidCollElgFlag.Value = "5";

                        }

                        hidCollElgFlagReason.Value = ds.Tables[0].Rows[0]["Reason"].ToString();

                        // Commented by Shivani Server.Transfer("ELGV2_ManualProcess_reg_Students__2.aspx?Search=" + searchType.ToString() + "&withORWithoutInv=" + withORWithoutInv.ToString());


                    }

                    else
                    {
                        lblErrorMsg.Text = "Please Enter the Valid Eligibility Form Number.";
                        lblErrorMsg.Style.Remove("display");
                        lblErrorMsg.Style.Add("display", "block");
                    }
                }

                catch (Exception ex)
                {
                    // throw new Exception(ex.Message);
                }
                finally
                {
                    ds.Dispose();
                }
            }

        }
        #endregion

        #region Footer1_Load

        protected void Footer1_Load(object sender, EventArgs e)
        {

        }

        #endregion

        # region Commented by Jatin
        
        /*   protected void dgRegStudents_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgRegStudents.CurrentPageIndex * 10) + 1);

            }
        }*/

 /*       protected void dgRegStudents_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {
                //Commented by Liwia
                // 				Session["ElgFormNo"] = e.Item.Cells[1].Text.Trim();

                //     Session["pk_CrMoLrnPtrn_ID"]=e.Item.Cells[8].Text.Trim();
                //added by liwia
                //     hidUniID.Value=ConfigurationSettings.AppSettings["UniversityID"].ToString();


                //Session["pk_Year"] = e.Item.Cells[6].Text.Trim();       Commented By Jyotsna on 29/09/2007
                //Session["pk_Student_ID"] = e.Item.Cells[7].Text.Trim();


                hidElgFormNo.Value = e.Item.Cells[1].Text.Trim();
                hidPRN.Value = e.Item.Cells[3].Text.Trim();
                hidpkYear.Value = e.Item.Cells[7].Text.Trim();
                hidpkStudentID.Value = e.Item.Cells[8].Text.Trim();
                hidpkFacID.Value = e.Item.Cells[9].Text.Trim();
                hidpkCrID.Value = e.Item.Cells[10].Text.Trim();
                hidpkMoLrnID.Value = e.Item.Cells[11].Text.Trim();
                hidpkPtrnID.Value = e.Item.Cells[12].Text.Trim();
                hidpkBrnID.Value = e.Item.Cells[13].Text.Trim();
                hidpkCrPrDetailsID.Value = e.Item.Cells[14].Text.Trim();
                searchType = "Simple";

                if (rbWithInv.Checked == true)
                    withORWithoutInv = "1";
                else if (rbWithoutInv.Checked == true)
                    withORWithoutInv = "0";
                Server.Transfer("ELGV2_ManualProcess_reg_Students__2.aspx?Search=" + searchType.ToString() + "&withORWithoutInv=" + withORWithoutInv.ToString());
            }
        }*/
        # endregion Commented by Jatin

        #region GridView Events
        #region dgRegStudents1_RowDataBound
        protected void dgRegStudents1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");

            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
            }

        }
        #endregion

        #region dgRegStudents1_RowCommand
        protected void dgRegStudents1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgRegStudents1.Rows[index];

                hidElgFormNo.Value = row.Cells[1].Text.Trim();
                hidPRN.Value = row.Cells[3].Text.Trim();
                hidpkYear.Value = row.Cells[7].Text.Trim();
                hidpkStudentID.Value = row.Cells[8].Text.Trim();
                hidpkFacID.Value = row.Cells[9].Text.Trim();
                hidpkCrID.Value = row.Cells[10].Text.Trim();
                hidpkMoLrnID.Value = row.Cells[11].Text.Trim();
                hidpkPtrnID.Value = row.Cells[12].Text.Trim();
                hidpkBrnID.Value = row.Cells[13].Text.Trim();
                hidpkCrPrDetailsID.Value = row.Cells[14].Text.Trim();
                hid_fk_AcademicYr_ID.Value = row.Cells[15].Text.Trim();

                searchType = "Simple";

                if (rbWithInv.Checked == true)
                    withORWithoutInv = "1";
                else if (rbWithoutInv.Checked == true)
                    withORWithoutInv = "0";
                Server.Transfer("ELGV2_ManualProcess_reg_Students__2.aspx?Search=" + searchType.ToString() + "&withORWithoutInv=" + withORWithoutInv.ToString());
            }

        }
        #endregion

        protected void StudentAdvancedSearchforManualProcess1_Load(object sender, EventArgs e)
        {

        }
        #endregion


        


    }
}
