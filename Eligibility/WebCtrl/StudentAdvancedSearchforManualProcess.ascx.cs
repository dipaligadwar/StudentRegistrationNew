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
using StudentRegistration.Eligibility.ElgClasses;
using Sancharak;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace StudentRegistration.Eligibility.WebCtrl
{
    public partial class StudentAdvancedSearchforManualProcess : System.Web.UI.UserControl
    {
        #region Declaration of Variables
        protected System.Web.UI.HtmlControls.HtmlGenericControl CollegeGrid;
        protected System.Web.UI.HtmlControls.HtmlGenericControl divStudentList;
        protected System.Web.UI.HtmlControls.HtmlInputHidden hidCrMoLrnID;
        private string qstrNavigate;
        private string strUrl;
        private string gridType;
        string withOrWithoutInv1 = "";
        DataSet dsDistricts = new DataSet();
        clsCommon Common = new clsCommon();
        clsCommon objCommon = new clsCommon();
        clsCommon CommonAcYr = new clsCommon();
        clsCache clsCache = new clsCache();
        clsGeneral clsCountry = new clsGeneral();

        string fkCountryID = "";
        private string AcdyearID;
        private string AcdyearText;
        DataTable CountryDT;

        InstituteRepository InstRep = new InstituteRepository();

        #endregion

        #region Properties
        public string QstrNavigate
        {
            set
            {
                qstrNavigate = value;
            }
        }
        public string AcdYearID
        {
            get
            {
                return hid_fk_AcademicYr_ID.Value;
            }
            set
            {
                hid_fk_AcademicYr_ID.Value = value;
            }
        }
        public string AcdYearText
        {
            get
            {
                return hidAcademicYrText.Value;
            }
            set
            {
                hidAcademicYrText.Value = value;
            }
        }

        public string StrUrl
        {
            set
            {
                strUrl = value;
            }
        }
        public string GridType
        {
            set
            {
                gridType = value;
            }
        }



        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            clsCache.NoCache();
            string countryId = Body_Country.SelectedValue;
            Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods), this.Page);
            Ajax.Utility.RegisterTypeForAjax(typeof(ElgClasses.clsAjaxMethods));
            //btnClear.Attributes.Add("onclick", " return fnClearSearchCriteria();");


            dgRegPendingStudent.Visible = false;
            lblGridName.Style.Remove("display");
            lblGridName.Style.Add("display", "none");
            divDGNote.Style.Remove("display");
            divDGNote.Style.Add("display", "none");
            divColorCodes.Style.Remove("display");
            divColorCodes.Style.Add("display", "none");

            if (!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[26];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidFacID;
                hid[3] = hidCrID;
                hid[4] = hidMoLrnID;
                hid[5] = hidPtrnID;
                hid[6] = hidBrnID;
                hid[7] = hidCrPrDetailsID;
                hid[8] = hidElgFormNo;
                hid[9] = hidElgStatusColl;
                hid[10] = hidpkStudentID;
                hid[11] = hidDOB;
                hid[12] = hidFirstName;
                hid[13] = hidLastName;
                hid[14] = hidGender;
                hid[15] = hidCollElgFlag;
                hid[16] = hidInv;
                hid[17] = hidBodyState;
                hid[18] = hidBodyID;
                hid[19] = hidCountryIDForeign;
                hid[20] = hidrbFilterYesNo;
                hid[21] = hid_fk_AcademicYr_ID;
                hid[22] = hidAcademicYrText;
                hid[23] = hidBodySelText;
                hid[24] = hidrbWithInv;
                hid[25] = hidrbWithoutInv;

                if (Page.PreviousPage != null)
                {
                    ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

                    if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                    {
                        hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;

                    }
                    /*if (((HtmlInputHidden)Cntp.FindControl("hidBodyState")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidBodyState")).Value != "")
                    {
                        hidBodyState.Value = ((HtmlInputHidden)Cntp.FindControl("hidBodyState")).Value;
                    }*/
                }



                Common.setHiddenVariables(ref hid);
                fkCountryID = "0";
                hidStateID.Value = "0";
                hidCountryId.Value = fkCountryID;

                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                CommonAcYr.fillDropDown(ddlAcademicYear, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");

                CountryDT = new DataTable();
                CountryDT = clsCountry.ListCountry();
                objCommon.fillDropDown(Body_Country, CountryDT, "", "Text", "Value", "--- Select ---");

                //fnFillState(hidBodyState.Value);                

                if (qstrNavigate == "back")
                {

                    if (Page.PreviousPage != null)
                    {
                        ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");

                        if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                        {
                            hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                            hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                            hidFacID.Value = ((HtmlInputHidden)Cntp.FindControl("hidFacID")).Value;
                            hidCrID.Value = ((HtmlInputHidden)Cntp.FindControl("hidCrID")).Value;
                            hidMoLrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidMoLrnID")).Value;
                            hidPtrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidPtrnID")).Value;
                            hidBrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidBrnID")).Value;
                            hidCrPrDetailsID.Value = ((HtmlInputHidden)Cntp.FindControl("hidCrPrDetailsID")).Value;
                            hidElgFormNo.Value = ((HtmlInputHidden)Cntp.FindControl("hidElgFormNo")).Value;
                            hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)Cntp.FindControl("hid_fk_AcademicYr_ID")).Value;
                            hidAcademicYrText.Value = ((HtmlInputHidden)Cntp.FindControl("hidAcademicYrText")).Value;
                            hidrbFilterYesNo.Value = ((HtmlInputHidden)Cntp.FindControl("hidrbFilterYesNo")).Value;
                            hidBodyState.Value = ((HtmlInputHidden)Cntp.FindControl("hidBodyState")).Value;
                            hidBodyID.Value = ((HtmlInputHidden)Cntp.FindControl("hidBodyID")).Value;
                            hidBodySelText.Value = ((HtmlInputHidden)Cntp.FindControl("hidBodySelText")).Value;
                            hidCountryIDForeign.Value = ((HtmlInputHidden)Cntp.FindControl("hidCountryIDForeign")).Value;
                            hidBodyTypeFlag.Value = ((HtmlInputHidden)Cntp.FindControl("hidBodyTypeFlag")).Value;
                            hidrbWithInv.Value = ((HtmlInputHidden)Cntp.FindControl("hidrbWithInv")).Value;
                            hidrbWithoutInv.Value = ((HtmlInputHidden)Cntp.FindControl("hidrbWithoutInv")).Value;
                            hidInv.Value = ((HtmlInputHidden)Cntp.FindControl("hidInv")).Value;
                            hidBranchName.Value = ((HtmlInputHidden)Cntp.FindControl("hidBranchName")).Value;
                        }
                    }

                    if (hidBodyTypeFlag.Value == "1")
                    {
                        Body_Type_Flag.Items[0].Enabled = true;
                        Body_Type_Flag.Items[0].Selected = true;
                        Body_Type_Flag.Items[1].Selected = false;
                        Body_Type_Flag.Items[1].Enabled = false;

                    }
                    else if (hidBodyTypeFlag.Value == "2")
                    {
                        Body_Type_Flag.Items[1].Enabled = true;
                        Body_Type_Flag.Items[1].Selected = true;
                        Body_Type_Flag.Items[0].Selected = false;
                        Body_Type_Flag.Items[0].Enabled = false;

                    }
                    else if (hidBodyTypeFlag.Value == "1" && hidBodyTypeFlag.Value == "2")
                    {
                        Body_Type_Flag.Items[0].Selected = true;
                        Body_Type_Flag.Items[0].Enabled = true;
                        Body_Type_Flag.Items[1].Enabled = true;


                    }

                    //ddlFaculty.SelectedItem.Text = hidFacID.Value;

                    //   txtDOB.Text = hidDOB.Value;
                    for (int i = 0; i < ddlGender.Items.Count; i++)
                    {
                        if (ddlGender.Items[i].Value == hidGender.Value)
                            ddlGender.SelectedIndex = i;
                    }


                    txtLastName.Text = hidLastName.Value;
                    txtFirstName.Text = hidFirstName.Value;
                    ddlAcademicYear.SelectedItem.Text = hidAcademicYrText.Value;
                    ddlAcademicYear.SelectedItem.Value = hid_fk_AcademicYr_ID.Value;
                    Body_Country.SelectedItem.Value = hidCountryIDForeign.Value;
                    //hidStateSelText.Value = Body_State.SelectedItem.Text;  
                    Body_ID.SelectedItem.Text = hidBodySelText.Value;


                    FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value);
                    FillBoradDetails(hidBodyState.Value, hidBodyID.Value);

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

                    if (Request.QueryString["CollElg"] == "1")
                    {
                        rbUni.Checked = true;
                        rbColl.Checked = false;
                    }
                    else if (Request.QueryString["CollElg"] == "0")
                    {
                        rbUni.Checked = false;
                        rbColl.Checked = true;
                    }

                    if (Request.QueryString["FilterYesNoExBody"] == "0")
                    {
                        rbFilterYesNo.SelectedItem.Value = "0";
                        rbFilterYesNo.Items[1].Selected = true;

                    }
                    else if (Request.QueryString["FilterYesNoExBody"] == "1")
                    {
                        rbFilterYesNo.SelectedItem.Value = "1";
                        ddlAcademicYear.SelectedItem.Value = hid_fk_AcademicYr_ID.Value;
                        Body_State.SelectedItem.Value = hidBodyState.Value;
                        Body_ID.SelectedItem.Value = hidBodyID.Value;
                        Body_Country.SelectedItem.Value = hidCountryIDForeign.Value;
                        rbFilterYesNo.Items[0].Selected = true;

                    }

                    if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidCountryIDForeign.Value == "0")
                    {
                        //Body_ID.SelectedItem.Text = hidBodySelText.Value;
                        FillBoradDetails(hidBodyState.Value, hidBodyID.Value);
                        DivFilterExamBody.Attributes.Add("style", "display:inline");
                        rbFilterYesNo.SelectedItem.Value = "1";
                        Body_Indian_Foreign_Flag.SelectedItem.Value = "0";
                        divAcademicYr.Attributes.Add("style", "display:none");
                        dgRegPendingStudent.Visible = true;
                        tblDGRegPendingStudents.Style.Remove("display");
                        tblDGRegPendingStudents.Style.Add("display", "block");
                        lblGridName.Style.Remove("display");
                        lblGridName.Style.Add("display", "block");
                        divDGNote.Style.Remove("display");
                        divDGNote.Style.Add("display", "block");
                        divColorCodes.Style.Remove("display");
                        divColorCodes.Style.Add("display", "block");
                        trbtnSearch.Style.Add("display", "block");
                        tblSelect.Style.Add("display", "block");
                        rbFilterYesNo.Items[0].Selected = true;
                        trbtnSearchWithExamBody.Style.Add("display", "block");
                    }

                    else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidCountryIDForeign.Value != "0")
                    {
                        FillBoradDetails(hidBodyState.Value, hidBodyID.Value);
                        DivFilterExamBody.Attributes.Add("style", "display:inline");
                        trbtnSearchWithExamBody.Style.Add("display", "block"); ;
                        rbFilterYesNo.SelectedItem.Value = "1";
                        Body_Indian_Foreign_Flag.SelectedItem.Value = "1";
                        divAcademicYr.Attributes.Add("style", "display:none");
                        dgRegPendingStudent.Visible = true;
                        tblDGRegPendingStudents.Style.Remove("display");
                        tblDGRegPendingStudents.Style.Add("display", "block");
                        lblGridName.Style.Remove("display");
                        lblGridName.Style.Add("display", "block");
                        divDGNote.Style.Remove("display");
                        divDGNote.Style.Add("display", "block");
                        divColorCodes.Style.Remove("display");
                        divColorCodes.Style.Add("display", "block");
                        trbtnSearch.Style.Add("display", "block");
                        tblSelect.Style.Add("display", "block");
                        rbFilterYesNo.Items[0].Selected = true;
                        Body_ID.SelectedItem.Text = hidBodySelText.Value;

                    }
                    else if (rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                    {
                        DivFilterExamBody.Attributes.Add("style", "display:none");
                        rbFilterYesNo.SelectedItem.Value = "0";
                        Body_Indian_Foreign_Flag.SelectedItem.Value = "0";
                        lblGridName.Style.Add("display", "none");
                        rbFilterYesNo.Items[1].Selected = true;
                        trbtnSearchWithExamBody.Style.Add("display", "block");
                    }
                    lblGridName.Attributes.Add("style", "display:none");
                    fnDisplayRegGrid();
                    trbtnSearch.Style.Add("display", "block");
                    Body_ID.SelectedItem.Text = hidBodySelText.Value;

                }
                else
                {
                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                    FillFaculty();
                    //fnFillState(hidStateID.Value);
                }
            }
            else
            {
                if (rbFilterYesNo.Items[0].Selected == true)
                {

                    hidrbFilterYesNo.Value = "1";
                    rbFilterYesNo.SelectedItem.Value = hidrbFilterYesNo.Value;
                }
                else if (rbFilterYesNo.Items[1].Selected == true)
                {
                    hidrbFilterYesNo.Value = "0";
                    rbFilterYesNo.SelectedItem.Value = hidrbFilterYesNo.Value;
                }


                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value);


                if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "0")
                {
                    FillBoradDetails(hid_StateID.Value, hid_BodyID.Value);
                    DivFilterExamBody.Attributes.Add("style", "display:inline");
                    TrCountry.Attributes.Add("style", "display:none");
                    TrCountryForeignBoardUniv.Attributes.Add("style", "display:none");
                    trbtnSearchWithExamBody.Style.Add("display", "block");
                }
                else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "1")
                {
                    hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
                }

                if (hidCountryId.Value == "107")
                {
                    fnFillState(hidStateID.Value);
                }

            }
            //btnClear.Attributes.Add("onclick", " return fnClearSearchCriteria();");
        }
        #endregion

        #region fnDisplayRegGrid

        private void fnDisplayRegGrid()
        {
            DataSet ds = new DataSet();
            DataView DV = new DataView();
            hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.ToString();
            hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;
            hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
            //if (rbWithInv.Checked == true)
            //{
            //    hidInv.Value = "1";
            //}
            //else
            //{
                hidInv.Value = "0";
            //}

            try
            {
                if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "0")
                {

                    //if (rbWithInv.Checked == true)
                    //{
                    //    hidInv.Value = "1";
                    //    if (rbColl.Checked == true)
                    //    {
                    //        hidElgStatusColl.Value = "0";
                    //        ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_ExamBody(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hidBodyState.Value, hidBodyID.Value, hid_fk_AcademicYr_ID.Value);
                    //        DV.Table = ds.Tables[0];
                    //        lblGridName.Text = "List of students whose Eligiblity is marked by " + lblCollege.Text + ".";
                    //    }
                    //    if (rbUni.Checked == true)
                    //    {
                    //        hidElgStatusColl.Value = "1";
                    //        ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_ExamBody(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hidBodyState.Value, hidBodyID.Value, hid_fk_AcademicYr_ID.Value);
                    //        DV.Table = ds.Tables[0];
                    //        lblGridName.Text = "List of students whose Eligiblity is marked by " + lblUniversity.Text + ".";
                    //    }
                    //}
                    //else if (rbWithoutInv.Checked == true)
                    //{
                        if (rbColl.Checked == true)
                        {
                            hidElgStatusColl.Value = "0";
                            ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_bypassInv_ExamBody(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hidBodyState.Value, hidBodyID.Value, hid_fk_AcademicYr_ID.Value);
                            DV.Table = ds.Tables[0];

                            lblGridName.Text = "List of students whose Eligiblity is marked by " + lblCollege.Text + ".";
                        }
                        if (rbUni.Checked == true)
                        {

                            hidElgStatusColl.Value = "1";
                            ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_bypassInv_ExamBody(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hidBodyState.Value, hidBodyID.Value, hid_fk_AcademicYr_ID.Value);

                            DV.Table = ds.Tables[0];

                            lblGridName.Text = "List of students whose Eligiblity is marked by " + lblUniversity.Text + ".";
                        }
                    }
              //  }

                else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "1")
                {

                    //if (rbWithInv.Checked == true)
                    //{
                    //    hidInv.Value = "1";
                    //    if (rbColl.Checked == true)
                    //    {
                    //        hidElgStatusColl.Value = "0";
                    //        ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_ExamBody_Foreign(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hidBodyState.Value, hidBodyID.Value, hid_fk_AcademicYr_ID.Value, hidCountryIDForeign.Value, hidtxtCountryForeignBoardUniv.Value);
                    //        DV.Table = ds.Tables[0];
                    //        lblGridName.Text = "List of students whose Eligiblity is marked by " + lblCollege.Text + ".";
                    //    }
                    //    if (rbUni.Checked == true)
                    //    {
                    //        hidElgStatusColl.Value = "1";
                    //        ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_ExamBody_Foreign(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hidBodyState.Value, hidBodyID.Value, hid_fk_AcademicYr_ID.Value, hidCountryIDForeign.Value, hidtxtCountryForeignBoardUniv.Value);
                    //        DV.Table = ds.Tables[0];
                    //        lblGridName.Text = "List of students whose Eligiblity is marked by " + lblUniversity.Text + ".";
                    //    }
                    //}
                    //else if (rbWithoutInv.Checked == true)
                    //{
                        if (rbColl.Checked == true)
                        {
                            hidElgStatusColl.Value = "0";
                            ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_bypassInv_ExamBody_Foreign(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hidBodyState.Value, hidBodyID.Value, hid_fk_AcademicYr_ID.Value, hidCountryIDForeign.Value, hidtxtCountryForeignBoardUniv.Value);
                            DV.Table = ds.Tables[0];

                            lblGridName.Text = "List of students whose Eligiblity is marked by " + lblCollege.Text + ".";
                        }
                        if (rbUni.Checked == true)
                        {

                            hidElgStatusColl.Value = "1";
                            ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_bypassInv_ExamBody_Foreign(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hidBodyState.Value, hidBodyID.Value, hid_fk_AcademicYr_ID.Value, hidCountryIDForeign.Value, hidtxtCountryForeignBoardUniv.Value);

                            DV.Table = ds.Tables[0];

                            lblGridName.Text = "List of students whose Eligiblity is marked by " + lblUniversity.Text + ".";
                        }
                    }
              //  }

                else if (rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                {
                    //if (rbWithInv.Checked == true)
                    ////if (hidrbWithInv.Value =="1")
                    //{
                    //    hidInv.Value = "1";
                    //    if (rbColl.Checked == true)
                    //    {
                    //        hidElgStatusColl.Value = "0";
                    //        ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hid_fk_AcademicYr_ID.Value);
                    //        DV.Table = ds.Tables[0];
                    //        lblGridName.Text = "List of students whose Eligiblity is marked by " + lblCollege.Text + ".";
                    //    }
                    //    if (rbUni.Checked == true)
                    //    {
                    //        hidElgStatusColl.Value = "1";
                    //        ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hid_fk_AcademicYr_ID.Value);
                    //        DV.Table = ds.Tables[0];
                    //        lblGridName.Text = "List of students whose Eligiblity is marked by " + lblUniversity.Text + ".";
                    //    }
                    //}
                    //else if (rbWithoutInv.Checked == true)
                    ////else if (hidrbWithoutInv.Value =="1")
                    //{
                        if (rbColl.Checked == true)
                        {
                            hidElgStatusColl.Value = "0";
                            ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_bypassInv(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hid_fk_AcademicYr_ID.Value);
                            DV.Table = ds.Tables[0];

                            lblGridName.Text = "List of students whose Eligiblity is marked by " + lblCollege.Text + ".";
                        }
                        if (rbUni.Checked == true)
                        {

                            hidElgStatusColl.Value = "1";
                            ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_bypassInv(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hid_fk_AcademicYr_ID.Value);

                            DV.Table = ds.Tables[0];

                            lblGridName.Text = "List of students whose Eligiblity is marked by " + lblUniversity.Text + ".";
                        }
                    }
               // }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ViewState["SortExpression"] != null)
                    {
                        DV.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();

                    }

                    try
                    {
                        dgRegPendingStudent.DataSource = DV;
                        dgRegPendingStudent.DataBind();
                    }
                    catch
                    {
                        dgRegPendingStudent.PageIndex = 0;
                        dgRegPendingStudent.DataBind();
                    }


                    dgRegPendingStudent.Visible = true;
                    tblDGRegPendingStudents.Style.Remove("display");
                    tblDGRegPendingStudents.Style.Add("display", "block");
                    lblGridName.Style.Remove("display");
                    lblGridName.Style.Add("display", "block");
                    divDGNote.Style.Remove("display");
                    divDGNote.Style.Add("display", "block");
                    divColorCodes.Style.Remove("display");
                    divColorCodes.Style.Add("display", "block");
                    divAcademicYr.Style.Add("display", "none");
                    tblSelect.Style.Add("display", "block");


                }
                else
                {
                    dgRegPendingStudent.Visible = false;
                    tblDGRegPendingStudents.Style.Remove("display");
                    tblDGRegPendingStudents.Style.Add("display", "none");
                    lblGridName.Text = "There are no Students satisfying the above search criteria whose Eligibility is kept Pending...";
                    lblGridName.Style.Remove("display");
                    lblGridName.Style.Add("display", "block");
                    divDGNote.Style.Remove("display");
                    divDGNote.Style.Add("display", "none");
                    divColorCodes.Style.Remove("display");
                    divColorCodes.Style.Add("display", "none");

                }


                ds.Clear();
                ds.Dispose();
                ds = null;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region Fill Faculty

        public void FillFaculty()
        {
            DataTable oDT = new DataTable();
            try
            {

                oDT = InstRep.AssignedConfirmedFaculties(hidUniID.Value, hidInstID.Value);
                Common.fillDropDown(ddlFaculty, oDT, "", "Fac_Desc", "pk_Fac_ID", "--- Select ---");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region FillFacultyWiseCourseCoursePart

        public void FillFacultyWiseCourseCoursePart(string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID)
        {
            clsCommon common = new clsCommon();
            DataTable dt;
            ddlFaculty.Items.Clear();

            try
            {
                dt = InstRep.AssignedConfirmedFaculties(hidUniID.Value, hidInstID.Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Common.fillDropDown(ddlFaculty, dt, FacID, "Fac_Desc", "pk_Fac_ID", "--- Select ---");
            ddlCourse.Items.Clear();

            try
            {
                dt = InstRep.AssignedConfirmedCourses(hidUniID.Value, hidInstID.Value, FacID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            common.fillDropDown(ddlCourse, dt, CrID, "Cr_Desc", "pk_Cr_ID", "--- Select ---");
            ddlMoLrn.Items.Clear();

            try
            {
                dt = InstRep.AssignedConfirmedModeOfLearning(hidUniID.Value, hidInstID.Value, FacID, CrID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            common.fillDropDown(ddlMoLrn, dt, MoLrnID, "MoLrn_Type", "pk_MoLrn_ID", "--- Select ---");
            ddlCrPtrn.Items.Clear();

            try
            {
                dt = InstRep.AssignedConfirmedCoursePatterns(hidUniID.Value, hidInstID.Value, FacID, CrID, MoLrnID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            common.fillDropDown(ddlCrPtrn, dt, PtrnID, "text", "value", "--- Select ---");
            ddlBranch.Items.Clear();

            try
            {
                dt = InstRep.AssignedConfirmedBranches(hidUniID.Value, hidInstID.Value, FacID, CrID, MoLrnID, PtrnID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (hidBranchName.Value == "No Branch")
            {
                ddlBranch.Items.Insert(0, "No Branch");
            }
            else
            {
                common.fillDropDown(ddlBranch, dt, BrnID, "Text", "Value", "--- Select ---");
            }
            /*ddlCoursePart.Items.Clear();

            try
            {
                dt = InstRepV2.AssignedConfirmedCourseParts(hidUniID.Value, hidInstID.Value, FacID, CrID, MoLrnID, PtrnID, BrnID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            common.fillDropDown(ddlCoursePart, dt, CrPrDetailsID, "CrPr_Abbr", "pk_CrPr_ID", "---- Select ----");
            //ddlCoursePartChild.Items.Clear();
            if (common != null) common = null;
            dt.Dispose();

            try
            {
                dt = InstRepV2.AssignCoursePartTerm(hidUniID.Value, hidInstID.Value, FacID, CrID, MoLrnID, PtrnID, BrnID, CrPrDetailsID);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            common.fillDropDown(ddlCoursePartChild, dt, CrPrChID, "CrPrCh_Abbr", "pk_CrPrCh_ID", "---- Select ----");

            if (common != null) common = null;
            ds.Dispose();*/
            dt.Dispose();
        }
        #endregion

        #region btnSearch_Click
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //*****************************************************************************
            string dob = txtDOB.Text.Trim();
            if (dob != "")
            {
                string[] arr = new string[3];
                arr = dob.Split('/');
                dob = arr[1] + '/' + arr[0] + '/' + arr[2];
            }

            hidDOB.Value = dob;
            hidGender.Value = ddlGender.SelectedItem.Value;
            hidLastName.Value = txtLastName.Text.Trim();
            hidFirstName.Value = txtFirstName.Text.Trim();
            hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;

            hidrbFilterYesNo.Value = rbFilterYesNo.SelectedItem.Value;

            if (hidrbFilterYesNo.Value == "1")
            {
                if (Body_Indian_Foreign_Flag.SelectedItem.Value == "0")     // Indian
                {
                    hidBodyState.Value = Body_State.SelectedItem.Value;
                    hidBodyID.Value = Body_ID.SelectedItem.Value;
                    hidStateSelText.Value = Body_State.SelectedItem.Text;
                    hidBodySelText.Value = Body_ID.SelectedItem.Text;

                    hidCountryIDForeign.Value = "0";
                    hidtxtCountryForeignBoardUniv.Value = "";
                }
                else                                                        // Foreign
                {
                    hidBodyState.Value = "0";
                    hidBodyID.Value = "0";
                    hidStateSelText.Value = "";
                    hidBodySelText.Value = "";

                    hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
                    hidtxtCountryForeignBoardUniv.Value = txtForeignBoardUnivName.Text;
                }

            }
            DivFilterExamBody.Attributes.Add("style", "display:inline");
            Div1.Attributes.Add("style", "display:inline");
            //*****************************************************************************

            if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidBodyID.Value == "0" && hidCountryIDForeign.Value == "0")
            {


                /*string strScript = "<script language='JavaScript'>alert('Please Select State and Board/University')</script>";
                Page.RegisterStartupScript("PopUp", strScript);*/
                if (Body_Type_Flag.SelectedItem.Value == "1")
                {
                    TdBodyCaption.InnerText = "Select Board";
                }
                else if (Body_Type_Flag.SelectedItem.Value == "2")
                {
                    TdBodyCaption.InnerText = "Select " + lblUniversity.Text + "";
                }

                hidrbFilterYesNo.Value = "1";
                DivFilterExamBody.Attributes.Add("style", "display:inline");
                Div1.Attributes.Add("style", "display:inline");
                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;

                dgRegPendingStudent.Visible = false;
                tblDGRegPendingStudents.Style.Remove("display");
                tblDGRegPendingStudents.Style.Add("display", "none");
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "none");
                divDGNote.Style.Remove("display");
                divDGNote.Style.Add("display", "none");
                divColorCodes.Style.Remove("display");
                divColorCodes.Style.Add("display", "none");
                divAcademicYr.Style.Add("display", "none");
                trbtnSearchWithExamBody.Style.Add("display", "block"); ;
                //tblSelect.Style.Add("display", "block");

                //}
                /*else
                {
                    hidrbFilterYesNo.Value = "1";
                    DivFilterExamBody.Attributes.Add("style", "display:inline");
                    rbFilterYesNo.SelectedItem.Value = "1";
                    rbFilterYesNo.Items[1].Selected = true;
                    fnDisplayRegGrid();
                }*/
                fnDisplayRegGrid();
            }

            else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidCountryIDForeign.Value == "0")
            {
                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:inline");
                Div1.Attributes.Add("style", "display:inline");
                Body_Country.Attributes.Add("style", "display:none");
                txtForeignBoardUnivName.Attributes.Add("style", "display:none");
                TrCountryForeignBoardUniv.Attributes.Add("style", "display:none"); ;
                TrCountry.Attributes.Add("style", "display:none"); ;
                TrState.Attributes.Add("style", "display:inline"); ;
                TrBody.Attributes.Add("style", "display:inline");
                trbtnSearchWithExamBody.Style.Add("display", "block");
                fnDisplayRegGrid();

            }

            else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidCountryIDForeign.Value != "0")
            {
                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:inline");
                //Div1.Attributes.Add("style", "display:none");
                Body_Country.Attributes.Add("style", "display:inline");
                txtForeignBoardUnivName.Attributes.Add("style", "display:inline");
                TrCountryForeignBoardUniv.Attributes.Add("style", "display:inline"); ;
                TrCountry.Attributes.Add("style", "display:inline"); ;
                TrState.Attributes.Add("style", "display:none"); ;
                TrBody.Attributes.Add("style", "display:none");
                trbtnSearchWithExamBody.Style.Add("display", "block"); ;
                Body_Country.SelectedItem.Value = hidCountryIDForeign.Value;
                fnDisplayRegGrid();
            }

            else if (rbFilterYesNo.SelectedItem.Value.ToString() == "0")
            {
                hidrbFilterYesNo.Value = "0";
                DivFilterExamBody.Attributes.Add("style", "display:none");
                rbFilterYesNo.SelectedItem.Value = "0";
                rbFilterYesNo.Items[1].Selected = true;
                fnDisplayRegGrid();
            }

            if (rbColl.Checked)
            {
                hidElgStatusColl.Value = "0";
            }
            else
            {
                hidElgStatusColl.Value = "1";
            }
            //if (rbWithInv.Checked == true)
            //{
            //    hidInv.Value = "1";
            //    hidrbWithInv.Value = "1";
            //    hidrbWithoutInv.Value = "0";
            //}
            //else
            //{
                hidInv.Value = "0";
                hidrbWithInv.Value = "0";
               // hidrbWithoutInv.Value = "1";
           // }
            dgRegPendingStudent.PageIndex = 0;
            //fnDisplayRegGrid();
        }
        #endregion

        #region btnSearchCourse
        protected void btnSearchCourse_Click(object sender, EventArgs e)
        {

            string dob = txtDOB.Text.Trim();
            if (dob != "")
            {
                string[] arr = new string[3];
                arr = dob.Split('/');
                dob = arr[1] + '/' + arr[0] + '/' + arr[2];
            }


            hidDOB.Value = dob;
            hidGender.Value = ddlGender.SelectedItem.Value;
            hidLastName.Value = txtLastName.Text.Trim();
            hidFirstName.Value = txtFirstName.Text.Trim();
            hidBodyState.Value = Body_State.SelectedItem.Value;
            //FillBoradDetails(hid_StateID.Value, hid_BodyID.Value);
            hidBodyID.Value = Body_ID.SelectedItem.Value;

            hidStateSelText.Value = Body_State.SelectedItem.Text;
            hidBodySelText.Value = Body_ID.SelectedItem.Text;

            hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;
            hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
            hidrbFilterYesNo.Value = rbFilterYesNo.SelectedItem.Value;
            hidtxtCountryForeignBoardUniv.Value = txtForeignBoardUnivName.Text;

            //-------------------------------------------------------------------------------

            Div1.Attributes.Add("style", "display:block");
            DivFilterExamBody.Attributes.Add("style", "display:none");
            tblSelect.Attributes.Add("style", "display:block");
            trbtnSearchWithExamBody.Attributes.Add("style", "display:block");
            if (hidFacID.Value == "0" || hidCrID.Value == "0" || hidMoLrnID.Value == "0" || hidPtrnID.Value == "0")
            {
                Div1.Attributes.Add("style", "display:block");
                DivFilterExamBody.Attributes.Add("style", "display:none");
                //DivFacNotSelected.Attributes.Add("style", "display:block");
                tblFacNotSelected.Attributes.Add("style", "display:block");
                lblFacNotSelected.Attributes.Add("style", "display:block");
                trFacNotSelected.Attributes.Add("style", "display:block");
                rbFilterYesNo.Items[1].Selected = true;
                rbFilterYesNo.Items[0].Selected = false;
                rbFilterYesNo.Items[1].Enabled = true;
                rbFilterYesNo.Items[0].Enabled = false;

            }
            else
            {
                if (hidGender.Value == "")
                {
                    hidGender.Value = "0";
                }

                if (rbColl.Checked)
                {
                    hidElgStatusColl.Value = "0";
                }
                else
                {
                    hidElgStatusColl.Value = "1";
                }
                //if (rbWithInv.Checked == true)
                //{
                //    hidInv.Value = "1";
                //}
                //else
                //{
                    hidInv.Value = "0";
               // }


                Div1.Attributes.Add("style", "display:block");
                //DivFilterExamBody.Attributes.Add("style", "display:none");
                tblFacNotSelected.Attributes.Add("style", "display:none");
                lblFacNotSelected.Attributes.Add("style", "display:none");
                trFacNotSelected.Attributes.Add("style", "display:none");
                rbFilterYesNo.Items[1].Selected = true;
                rbFilterYesNo.Items[0].Selected = false;
                rbFilterYesNo.Items[1].Enabled = true;
                rbFilterYesNo.Items[0].Enabled = true;
            }

            fnFillState(hidStateID.Value);


        }
        #endregion

        #region GridView Events

        #region dgRegPendingStudent_RowDataBound
        protected void dgRegPendingStudent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
                e.Row.Cells[16].Style.Add("display", "none");
                //e.Row.Cells[14].Style.Add("display", "none");
                //e.Row.Cells[15].Style.Add("display", "none");


                //**********************************************
                string BackColorCode = string.Empty;
                if (e.Row.Cells[16].Text == "same_university")
                {
                    BackColorCode = "#FFE4C4";
                }
                else if (e.Row.Cells[16].Text == "home_board")
                {
                    BackColorCode = "#E1FFFF";
                }
                else if (e.Row.Cells[16].Text == "other_state_board")
                {
                    BackColorCode = "#CCEEFF";
                }
                else if (e.Row.Cells[16].Text == "Foreign_board")
                {
                    BackColorCode = "#FFCCFF";
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml(BackColorCode);
                }
                //**********************************************
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
                e.Row.Cells[16].Style.Add("display", "none");
                //e.Row.Cells[14].Style.Add("display", "none");
                //e.Row.Cells[15].Style.Add("display", "none");
            }

        }
        #endregion

        #region dgRegPendingStudent_RowCommand

        protected void dgRegPendingStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PendingStudentDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgRegPendingStudent.Rows[index];

                hidElgFormNo.Value = row.Cells[1].Text.Trim();
                hidpkYear.Value = row.Cells[8].Text.Trim();
                hidpkStudentID.Value = row.Cells[9].Text.Trim();
                hidFacID.Value = row.Cells[10].Text.Trim();
                hidCrID.Value = row.Cells[11].Text.Trim();
                hidMoLrnID.Value = row.Cells[12].Text.Trim();
                hidPtrnID.Value = row.Cells[13].Text.Trim();
                hidBrnID.Value = row.Cells[14].Text.Trim();
                hidCrPrDetailsID.Value = row.Cells[15].Text.Trim();
                //hidBodyState.Value = row.Cells[14].Text.Trim();
                //hidBodyID.Value = row.Cells[15].Text.Trim();


                //if (rbWithInv.Checked == true)
                //    withOrWithoutInv1 = "1";
                //else if (rbWithoutInv.Checked == true)
                    withOrWithoutInv1 = "0";

                Server.Transfer(strUrl + "&withOrWithoutInv1=" + withOrWithoutInv1.ToString());
            }
        }

        #endregion

        #region dgRegPendingStudent_PageIndexChanging
        protected void dgRegPendingStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgRegPendingStudent.PageIndex = e.NewPageIndex;
            dgRegPendingStudent.DataBind();
            fnDisplayRegGrid();
        }
        #endregion

        #region dgRegPendingStudent_Sorting
        protected void dgRegPendingStudent_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                if (ViewState["SortOrder"].ToString() == " asc")
                    ViewState["SortOrder"] = " desc";
                else
                    ViewState["SortOrder"] = " asc";
            }
            else
            {
                ViewState["SortExpression"] = e.SortExpression;
                ViewState["SortOrder"] = " asc";
            }
            fnDisplayRegGrid();
        }
        #endregion

        #endregion

        #region Fill State
        private void fnFillState(string stateID)
        {
            clsCommon common = new clsCommon();
            DataTable dt = clsCountry.ListCountry();
            common.fillDropDown(Body_Country, dt, fkCountryID, "Text", "Value", "--- Select ---");

            Body_State.Items.Clear();
            hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            //dt = clsState.displayAllStates("E");
            //dt = clsEligibilityRights.ELGV2_displayAllStates("E", hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);
            DataTable dt1;
            dt1 = clsEligibilityRights.ELGV2_displayAllStates("E", hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value.ToString().Trim(), hidLastName.Value.ToString().Trim(), hidFirstName.Value.ToString().Trim(), hidGender.Value.ToString().Trim(), hidElgStatusColl.Value.ToString().Trim());
            if (dt1.Rows.Count > 0 && dt1 != null)
            {
                common.fillDropDown(Body_State, dt1, stateID, "Text", "Value", "--- Select ---");
                dt.Dispose();
                hidStateSelText.Value = Body_State.SelectedItem.Text;
                hidBodyTypeFlag.Value = dt1.Rows[0]["UniOrBoardCheck"].ToString();

                if (hidBodyTypeFlag.Value == "1")
                {
                    Body_Type_Flag.Items[0].Enabled = true;
                    Body_Type_Flag.Items[0].Selected = true;
                    Body_Type_Flag.Items[1].Selected = false;
                    Body_Type_Flag.Items[1].Enabled = false;

                    TdBodyCaption.InnerText = "Select Board";

                }
                else if (hidBodyTypeFlag.Value == "2")
                {
                    Body_Type_Flag.Items[1].Enabled = true;
                    Body_Type_Flag.Items[1].Selected = true;
                    Body_Type_Flag.Items[0].Selected = false;
                    Body_Type_Flag.Items[0].Enabled = false;

                    TdBodyCaption.InnerText = "Select " + lblUniversity.Text + "";

                }
                else if (hidBodyTypeFlag.Value == "1" && hidBodyTypeFlag.Value == "2")
                {
                    Body_Type_Flag.Items[0].Selected = true;
                    Body_Type_Flag.Items[0].Enabled = true;
                    Body_Type_Flag.Items[1].Enabled = true;

                }
            }
            else
            {
                common.fillDropDown(Body_State, dt1, stateID, "Text", "Value", "--- Select ---");
                dt1.Dispose();
                hidStateSelText.Value = Body_State.SelectedItem.Text;
            }


        }
        #endregion

        #region Fill Board
        public void FillBoradDetails(string State, string Board)
        {
            clsCommon common = new clsCommon();
            DataTable dt;
            Body_State.Items.Clear();
            Body_ID.Items.Clear();

            if (hidGender.Value == "")
            {
                hidGender.Value = "0";
            }
            if (rbColl.Checked)
            {
                hidElgStatusColl.Value = "0";
            }
            else
            {
                hidElgStatusColl.Value = "1";
            }
            //if (rbWithInv.Checked == true)
            //{
            //    hidInv.Value = "1";
            //}
            //else
            //{
                hidInv.Value = "0";
           // }

            try
            {
                //dt = clsState.displayAllStates("E");
                dt = clsEligibilityRights.ELGV2_displayAllStates("E", hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Common.fillDropDown(Body_State, dt, State, "Text", "Value", "--- Select ---");


            if (Body_Type_Flag.SelectedItem.Value.ToString() == "1")
            {

                try
                {
                    if (hid_StateID.Value == "")
                    {
                        hid_StateID.Value = "0";
                        dt = clsEligibilityRights.ELGV2_ListStateWiseBoard(hidUniID.Value, hidInstID.Value, hidBodyState.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value);
                    }
                    else
                    {
                        dt = clsEligibilityRights.ELGV2_ListStateWiseBoard(hidUniID.Value, hidInstID.Value, hid_StateID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                common.fillDropDown(Body_ID, dt, Board, "StateBoard_Description", "pk_BoardID", "--- Select ---");
                //hidBodySelText.Value = Body_ID.SelectedItem.Text;

            }
            else if (Body_Type_Flag.SelectedItem.Value.ToString() == "2")
            {

                try
                {
                    if (hid_StateID.Value == "")
                    {
                        hid_StateID.Value = "0";
                    }

                    //dt = clsUniversity.List_StateWiseUniversities(hid_StateID.Value);
                    dt = clsEligibilityRights.ELGV2_ListStateWiseUniversities(hid_StateID.Value, hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                common.fillDropDown(Body_ID, dt, Board, "Uni_Name", "pk_Uni_ID", "--- Select ---");

            }
        }
        #endregion

        #region Academic Year

        public void btnAcYr_Click(object sender, EventArgs e)
        {
            btnAcYr.Attributes.Add("onclick", "return fnClearSearchCriteria();");
            hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.ToString();
            hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;

            if (hid_fk_AcademicYr_ID.Value == "0")
            {
                string strScript = "<script language='JavaScript'>alert('Please Select Academic Year')</script>";
                Page.RegisterStartupScript("PopUp", strScript);

                divAcademicYr.Style.Add("display", "block");
                tblSelect.Style.Add("display", "none");
                trbtnSearch.Style.Add("display", "none");
                btnAcYr.Attributes.Add("onclick", "return fnClearSearchCriteria();");
            }
            else
            {
                divAcademicYr.Style.Add("display", "none");
                tblSelect.Style.Add("display", "block");
                trbtnSearch.Style.Add("display", "block");
                btnAcYr.Attributes.Add("onclick", "return fnClearSearchCriteria();");
            }
            /* if (hidAcademicYrText.Value == "--- Select ---")
             {
                Div1.Style.Add("display","none");
                Fieldset3.Style.Add("display", "none");
            
             }*/

        }
        #endregion

        #region Clear Search Criteria Click
        protected void btnClear_Click(object sender, EventArgs e)
        {

            txtDOB.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            ddlGender.SelectedItem.Value = "0";
            //ddlFaculty.SelectedItem.Value = "0";
            ddlCourse.SelectedItem.Value = "0";
            ddlMoLrn.SelectedItem.Value = "0";
            ddlCrPtrn.SelectedItem.Value = "0";
            ddlBranch.SelectedItem.Value = "0";
            ddlFaculty.SelectedIndex = 0;
            ddlCourse.SelectedIndex = 0;
            ddlMoLrn.SelectedIndex = 0;
            ddlCrPtrn.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
            hidStateID.Value = "0";
            hidDistrictID.Value = "0";
            hidTehsilID.Value = "0";
            hidFacID.Value = "0";
            hidCrID.Value = "0";
            hidMoLrnID.Value = "0";
            hidPtrnID.Value = "0";
            hidBrnID.Value = "0";
            hidCrPrDetailsID.Value = "0";
            Body_ID.SelectedItem.Value = "0";
            Body_State.SelectedItem.Value = "0";
            hid_StateID.Value = "0";
            hid_BodyID.Value = "0";
            rbFilterYesNo.Items[1].Selected = true;
            Div1.Attributes.Add("style", "display:none");
            DivFilterExamBody.Attributes.Add("style", "display:none");

            rbFilterYesNo.Items[1].Selected = true;
            rbFilterYesNo.Items[0].Selected = false;
            rbFilterYesNo.Items[1].Enabled = true;
            rbFilterYesNo.Items[0].Enabled = false;
            tblFacNotSelected.Attributes.Add("style", "display:none");
            trFacNotSelected.Attributes.Add("style", "display:none");




        }
        #endregion

        #region Commented fillStateBoard

        /*[Ajax.AjaxMethod]
        public HtmlSelect fillStateBoard(string State_ID, string selectedValue)
        {

            DataTable tempDT = new DataTable();
            if (State_ID != "0")
            {
                tempDT = clsBoard.List_StateWiseBoard(State_ID);
            }
            HtmlSelect hStateID = new HtmlSelect();
            hStateID.ID = "Body_ID";
            hStateID.Attributes.Add("class", "selectbox");
            hStateID.Attributes.Add("onblur", "setValueState('hid_BodyID',this.value)");
            try
            {
                objCommon.fillDropDown(hStateID, tempDT, selectedValue, "StateBoard_Description", "pk_BoardID", "---- Select ----");
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            return hStateID;
        }

        #endregion

        #region fillStateUniversity

        [Ajax.AjaxMethod]
        public HtmlSelect fillStateUniversity(string State_ID, string selValue)
        {
            DataTable tempDT = new DataTable();
            if (State_ID != "0")
            {
                tempDT = clsUniversity.List_StateWiseUniversities(State_ID);
            }
            HtmlSelect hUniversityID = new HtmlSelect();
            hUniversityID.ID = "Body_ID";
            hUniversityID.Attributes.Add("class", "selectbox");
            hUniversityID.Attributes.Add("onblur", "setValueState('hid_BodyID',this.value)");
            try
            {
                objCommon.fillDropDown(hUniversityID, tempDT, selValue, "Uni_Name", "pk_Uni_ID", "---- Select ----");
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            return hUniversityID;
        }*/
        #endregion

        
  
    }
}