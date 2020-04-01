using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;
using System.Xml;
using Sancharak;
using System.Web.Security;
using System.Resources;
using System.IO;
using System.Text;



namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_ResolveProvisional__1 : System.Web.UI.Page
    {
        #region Declaration of Variables
        protected System.Web.UI.HtmlControls.HtmlInputHidden tehsilName;
        protected System.Web.UI.HtmlControls.HtmlGenericControl CollegeGrid;
        protected System.Web.UI.HtmlControls.HtmlGenericControl divStudentList;
        protected System.Web.UI.HtmlControls.HtmlInputHidden hidCrMoLrnID;

        
        private string qstrNavigate;
        private string strUrl;
        private string gridType;
        DataSet dsDistricts = new DataSet();
        clsCommon Common = new clsCommon();
        clsCommon CommonAcYr = new clsCommon();
        clsCache clsCache = new clsCache();
        clsGeneral clsCountry = new clsGeneral();
        private string AcdyearID;
        private string AcdyearText;
        DataSet ds;
        string[] RefIDarr = new string[4];
        string InstituteID = null;
        string PRNumber = null;
        InstituteRepository InstRep = new InstituteRepository();
        string fkCountryID = "";
        #endregion

        #region Properties
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
        public string HidSearchType
        {
            get
            {
                return hidSearchType.Value;
            }
            set
            {
                hidSearchType.Value = value;
            }
        }
        public string StrUrl
        {
            set
            {
                strUrl = value;
            }
            get
            {
                return strUrl;
            }
        }
        public string GridType
        {
            set
            {
                gridType = value;
            }

            get
            {
                return gridType;
            }
        }
        #endregion

        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, System.EventArgs e)
        {
            clsCache.NoCache();

            Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods), this.Page);
            Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent), this.Page);

            // Put user code to initialize the page here
            if (!IsPostBack)
            {
                ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                searchInstNew temp = (searchInstNew)Cntph1.FindControl("SchInst1");
                hidInstID.Value = ((HtmlInputHidden)Cntph1.FindControl("hidInstID")).Value;
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();

                HtmlInputHidden[] hid = new HtmlInputHidden[28];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidElgFormNo;
                hid[3] = hidpkStudentID;
                hid[4] = hidpkYear;
                hid[5] = hidFacID;
                hid[6] = hidCrID;
                hid[7] = hidCrMoLrnID;
                hid[8] = hidPtrnID;
                hid[9] = hidBrnID;
                hid[10] = hidCrPrDetailsID;
                hid[11] = hid_fk_AcademicYr_ID;
                hid[12] = hidAcademicYrText;
                hid[13] = hidFacName;
                hid[14] = hidCrName;
                hid[15] = hidMOLName;
                hid[16] = hidPattern;
                hid[17] = hidBrName;
                hid[18] = hidAcYrName;
                hid[19] = hidSearchType;
                hid[20] = hidAppFormNo;
                hid[21] = hidAppFormNo;
                hid[22] = hidBodyState;
                hid[23] = hidBodyID;
                hid[24] = hidCountryIDForeign;
                hid[25] = hidtxtCountryForeignBoardUniv;
                hid[26] = hidCollege_Eligibility_Flag;
                hid[27] = hidElgFormNo;


                Common.setHiddenVariables(ref hid);
                divSimpleSearch.Style.Add("display", "block");
                lblAdvSearch.InnerText = "Advanced Search";
                lblPageHead.Text = "Resolve Provisional Eligibility";

                fkCountryID = "0";
                hidStateID.Value = "0";
                hidCountryId.Value = fkCountryID;

                if (Page.PreviousPage != null)
                {
                    ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

                    if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                    {
                        hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                    }
                }

                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                CommonAcYr.fillDropDown(ddlAcademicYear, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");

                btnSimpleSearch.Attributes.Add("onclick", "return ChkValidation();");
                btnSubmit.Attributes.Add("onclick", "return submitValidate();");
                lblGrid.Attributes.Add("style", "display:none");
                lblErrorMsg.Attributes.Add("style", "display:none");
                tdSubmit.Attributes.Add("style", "display:none");
                tblResolveQuestion.Attributes.Add("style", "display:none");
                divErrorMsg.Attributes.Add("style", "display:none");
                hidSubmitFlag.Value = "0";
            
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();

                hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
                hidtxtCountryForeignBoardUniv.Value = txtForeignBoardUnivName.Text;
                fnFillState(hid_StateID.Value);
                FillBoradDetails(hid_StateID.Value, hid_BodyID.Value);

                lblSubHeader.Text = " for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);

                try
                {
                    hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
                }
                catch
                {
                    hidIsPRNValidationRequired.Value = "N";
                }

                #region Back Navigation
                if (!hidSubmitFlag.Value.Equals("1"))
                {
                    if (Page.PreviousPage != null)
                    {
                        if (qstrNavigate == "back")
                        {

                            ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");

                            if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                            {
                                hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                                hidFacID.Value = ((HtmlInputHidden)Cntp.FindControl("hidFacID")).Value;
                                hidCrID.Value = ((HtmlInputHidden)Cntp.FindControl("hidCrID")).Value;
                                hidCrMoLrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidCrMoLrnID")).Value;
                                hidPtrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidPtrnID")).Value;
                                hidBrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidBrnID")).Value;
                                hidCrPrDetailsID.Value = ((HtmlInputHidden)Cntp.FindControl("hidCrPrDetailsID")).Value;
                                hidPRN.Value = ((HtmlInputHidden)Cntp.FindControl("hidPRN")).Value;
                                hidElgFormNo.Value = ((HtmlInputHidden)Cntp.FindControl("hidElgFormNo")).Value;
                                hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)Cntp.FindControl("hid_fk_AcademicYr_ID")).Value;
                                hidAcademicYrText.Value = ((HtmlInputHidden)Cntp.FindControl("hidAcademicYrText")).Value;
                                hidIsBlank.Value = ((HtmlInputHidden)Cntp.FindControl("hidIsBlank")).Value;
                                hidFacName.Value = ((HtmlInputHidden)Cntp.FindControl("hidFacName")).Value;
                                hidCrName.Value = ((HtmlInputHidden)Cntp.FindControl("hidCrName")).Value;
                                hidMOLName.Value = ((HtmlInputHidden)Cntp.FindControl("hidMOLName")).Value;
                                hidPattern.Value = ((HtmlInputHidden)Cntp.FindControl("hidPattern")).Value;
                                hidBrName.Value = ((HtmlInputHidden)Cntp.FindControl("hidBrName")).Value;
                                hidAcYrName.Value = ((HtmlInputHidden)Cntp.FindControl("hidAcYrName")).Value;
                                hidBranchName.Value = ((HtmlInputHidden)Cntp.FindControl("hidBranchName")).Value;
                                // txtElgFormNo.Text = hidElgFormNo.Value;
                            }
                        }

                        if (Request.QueryString["Search"] == "Adv")
                        {

                            //hidInstID.Value = ((HtmlInputHidden)temp.FindControl("hidInstID")).Value;
                            hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                            hidFacID.Value = Request.QueryString["Faculty"];
                            hidCrID.Value = Request.QueryString["Course"];
                            hidCrMoLrnID.Value = Request.QueryString["MoLearning"];
                            hidPtrnID.Value = Request.QueryString["Pattern"];
                            hidBrnID.Value = Request.QueryString["Branch"];
                            hidCrPrDetailsID.Value = Request.QueryString["CoursePrtDetails"];
                            hid_fk_AcademicYr_ID.Value = Request.QueryString["AcYear"];

                            hidFacName.Value = Request.QueryString["FacName"];
                            hidCrName.Value = Request.QueryString["CrName"];
                            hidMOLName.Value = Request.QueryString["MoLrnName"];
                            hidPattern.Value = Request.QueryString["PatternName"];
                            hidBrName.Value = Request.QueryString["BranchName"];
                            hidAcademicYrText.Value = Request.QueryString["AcYearText"];

                            lblAdvSearch.InnerText = "Simple Search";
                            txtDOB.Text = hidDOB.Value;
                            for (int i = 0; i < ddlGender.Items.Count; i++)
                            {
                                if (ddlGender.Items[i].Value == hidGender.Value)
                                    ddlGender.SelectedIndex = i;
                            }

                            txtLastName.Text = hidLastName.Value;
                            txtFirstName.Text = hidFirstName.Value;

                            ddlAcademicYear.Items.Remove(ddlAcademicYear.Items.FindByText(hidAcademicYrText.Value));
                            ddlAcademicYear.SelectedItem.Text = hidAcademicYrText.Value;
                            ddlAcademicYear.SelectedItem.Value = hid_fk_AcademicYr_ID.Value;

                            DivAdvanceSearch.Attributes.Add("style", "display:block");
                            divSimpleSearch.Style.Add("display", "none");

                                hidpkYear.Value = "";
                                hidpkStudentID.Value = "";
                                fnDisplayRegGrid();
                            
                        }

                        else if (Request.QueryString["Search"] == "Simple")
                        {
                            lblAdvSearch.InnerText = "Advanced Search";
                            if (hidIsBlank.Value != "")
                            {
                                txtElgFormNo.Text = hidElgFormNo.Value;
                            }
                            else
                            {
                                txtPRN.Text = hidPRN.Value;
                            }

                            fnFetchStudent();
                        }
                        FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value);

                        

                        if (hidCountryId.Value == "107")
                        {
                            fnFillState(hidStateID.Value);
                        }
                       
                    }

                    else
                    {

                        hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                        FillFaculty();
                      
                        if (Request.QueryString["Search"] == "Adv" || HidSearchType.Equals("Adv"))
                        {
                            DivAdvanceSearch.Attributes.Add("style", "display:block");
                            divSimpleSearch.Style.Add("display", "none");
                            lblAdvSearch.InnerText = "Simple Search";
                        }
                        else if (Request.QueryString["Search"] == "Simple" || HidSearchType.Equals("Simple"))
                        {
                            DivAdvanceSearch.Attributes.Add("style", "display:none");
                            tblResolveQuestion.Attributes.Add("style", "display:none");
                            DivExaminingBodyFilter.Attributes.Add("style", "display:none");
                            divSimpleSearch.Style.Add("display", "block");
                            lblAdvSearch.InnerText = "Advanced Search";
                        }
                    }
                    //lblPageHead.Text = "Resolve Provisional Eligibility";
                }

                #region Check Provisional/Pending

                string str = Page.ToString();
                if (str == "ASP.eligibility_elgv2_resolvepending__1_aspx")
                {
                    trOr.Attributes.Add("style", "display:none");
                    trPRN.Attributes.Add("style", "display:none");

                }
                #endregion

                #endregion
            }


            hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            FillFaculty();
            FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value);

        }

        #region Function to fill State

        private void fnFillState(string stateID)
        {
            DataSet DSState = new DataSet();
            clsCommon common = new clsCommon();

            DataTable dt = clsCountry.ListCountry();
            common.fillDropDown(Body_Country, dt, fkCountryID, "Text", "Value", "--- Select ---");

            Body_State.Items.Clear();

            if (Request.QueryString["AcYear"] == null)
            {
                ddlFaculty.SelectedItem.Value = hidFacID.Value;
                ddlCourse.SelectedItem.Value = hidCrID.Value;
                ddlMoLrn.SelectedItem.Value = hidCrMoLrnID.Value;
                ddlCrPtrn.SelectedItem.Value = hidPtrnID.Value;
                ddlBranch.SelectedItem.Value = hidBrnID.Value;

                Session["hidFacID"] = hidFacID.Value;
                Session["hidCrID"] = hidCrID.Value;
                Session["hidCrMoLrnID"] = hidCrMoLrnID.Value;
                Session["hidPtrnID"] = hidPtrnID.Value;
                Session["hidBrnID"] = hidBrnID.Value;
            }
            else
            {
                ddlFaculty.SelectedValue= Convert.ToInt32(Session["hidFacID"]).ToString();
                ddlCourse.SelectedValue = Convert.ToString(Session["hidCrID"]);
                ddlMoLrn.SelectedValue = Convert.ToString(Session["hidCrMoLrnID"]);
                ddlCrPtrn.SelectedValue = Convert.ToString(Session["hidPtrnID"]);
                ddlBranch.SelectedValue = Convert.ToString(Session["hidBrnID"]);
            }

            dt = clsEligibilityRights.ELGV2_displayAllStates_BulkProcess("E", hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);
           
            if (dt.Rows.Count > 0)
            {
                common.fillDropDown(Body_State, dt, stateID, "Text", "Value", "--- Select ---");
                dt.Dispose();
                hidStateSelText.Value = Body_State.SelectedItem.Text;
                hidBodyTypeFlag.Value = dt.Rows[0]["UniOrBoardCheck"].ToString();

                if (hidBodyTypeFlag.Value == "1")
                {
                    Body_Type_Flag.Items[0].Enabled = true;
                    Body_Type_Flag.Items[0].Selected = true;
                    Body_Type_Flag.Items[1].Selected = false;
                    Body_Type_Flag.Items[1].Enabled = false;

                    TdBodyCaption.InnerText = "Select Body";

                }
                else if (hidBodyTypeFlag.Value == "2")
                {
                    Body_Type_Flag.Items[1].Enabled = true;
                    Body_Type_Flag.Items[1].Selected = true;
                    Body_Type_Flag.Items[0].Selected = false;
                    Body_Type_Flag.Items[0].Enabled = false;

                    TdBodyCaption.InnerText = "Select " + lblUniversity.Text + "";

                }
            }
            else
            {
                common.fillDropDown(Body_State, dt, stateID, "Text", "Value", "--- Select ---");
                dt.Dispose();
                hidStateSelText.Value = Body_State.SelectedItem.Text;
            }
        }

        #endregion

        #region Filling Dropdowns

        public void FillFaculty()
        {
            DataTable oDT = new DataTable();
            if (ddlCourse.SelectedIndex == 0)
            {
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

        }

        public void FillFacultyWiseCourseCoursePart(string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID)
        {
            clsCommon common = new clsCommon();
            //DataSet ds;
            DataTable dt;
            ddlFaculty.Items.Clear();

            try
            {

                //ds = Eligibility.elgDBAccess.GetAllFaculties(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()));
                //dt = ds.Tables[0];
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
                //ds = Eligibility.elgDBAccess.selFacultyWiseAllCourses(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(FacID));
                //dt = ds.Tables[0];
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
                //ds = Eligibility.elgDBAccess.selAllCoursePart(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(FacID), Convert.ToInt32(CrID));
                //dt = ds.Tables[0];
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
  
            if (common != null) common = null;
            dt.Dispose();
        }

        #endregion

        #endregion

        #region Web Form Designer generated code

        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {

        }

        #endregion

        #region tbElgFormNo_TextChanged

        protected void tbElgFormNo_TextChanged(object sender, System.EventArgs e)
        {

        }
        #endregion


        #region btnSimpleSearch_Click

        protected void btnSimpleSearch_Click(object sender, System.EventArgs e)
        {
            lblAdvSearch.InnerText = "Advanced Search";
            ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            ((Label)Cntph1.FindControl("lblSubHeader")).Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);
            lblSubmitMessage.Attributes.Add("style", "display:none");
            rbElgDecsionNo.Checked = false;
            rbElgDecsionYes.Checked = true;
            txtNotElgReason.Text = string.Empty;
            tblResolveQuestion.Attributes.Add("style", "display:none");
            divErrorMsg.Attributes.Add("style", "display:none");
            divDGNote.Attributes.Add("style", "display:none");
            DivExaminingBodyFilter.Attributes.Add("style", "display:none");
            tdSubmit.Attributes.Add("style", "display:none");
            hidSubmitFlag.Value = "0";
            hidSearchType.Value = "Simple";

            string ElgFormNo;
            if (txtElgFormNo.Text != "")
            {
                ElgFormNo = txtElgFormNo.Text.Trim();
                hidIsBlank.Value = ElgFormNo;
            }
            else
            {
                ElgFormNo = "0-0-0-0";
                hidIsBlank.Value = "";

            }

            int cnt = 0;
            string str = ElgFormNo;
            int pos = str.IndexOf('-');
            string[] arr = new string[] { "0", "0", "0", "0" };
            Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");

            if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                PRNumber = txtPRN.Text.Trim();
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
                arr = ElgFormNo.Split('-');   //new  UniID = arr[0], InstID = arr[1],Year = arr[2], StudID = arr[3]
                for (int i = 0; i < 4; i++)
                {
                    if (arr[i] == "")
                        arr[i] = "0";
                }
                try
                {
                   
                    #region call search for provisional students

                    if (Page.ToString().Equals("ASP.eligibility_elgv2_resolveprovisional__1_aspx"))
                    {
                        ds = clsEligibilityDBAccess.Check_Reg_Provisional_Student_Exists(arr[0], arr[1], arr[2], arr[3], txtPRN.Text, hidInstID.Value, txtApplicationFrmNo.Text.Trim());
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "5")    // Provisional Eligibility
                            {
                                hidElgFormNo.Value = txtElgFormNo.Text.Trim();
                                hidAppFormNo.Value = ds.Tables[0].Rows[0]["AdmissionFormNo"].ToString();
                                hidpkYear.Value = ds.Tables[0].Rows[0]["pkYear"].ToString();
                                hidpkStudentID.Value = ds.Tables[0].Rows[0]["pkStudentID"].ToString();
                                hidFacID.Value = ds.Tables[0].Rows[0]["pkFacID"].ToString();
                                hidCrID.Value = ds.Tables[0].Rows[0]["pkCrID"].ToString();
                                hidCrMoLrnID.Value = ds.Tables[0].Rows[0]["pkMoLrnID"].ToString();
                                hidPtrnID.Value = ds.Tables[0].Rows[0]["pkPtrnID"].ToString();
                                hidBrnID.Value = ds.Tables[0].Rows[0]["pkBrnID"].ToString();
                                hidCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pkCrPrDetails"].ToString();
                                hid_fk_AcademicYr_ID.Value = ds.Tables[0].Rows[0]["fkAcademicYearID"].ToString();
                                //Server.Transfer("ELGV2_ResolveProvisional__2.aspx?Search=Simple");
                                hidPRN.Value = ds.Tables[0].Rows[0]["PRN"].ToString();
                                dgRegPendingStudents1.Columns[16].ItemStyle.CssClass = "clOff";
                                dgRegPendingStudents1.Columns[16].HeaderStyle.CssClass = "clOff";
                                dgRegPendingStudents1.DataSource = ds;
                                dgRegPendingStudents1.DataBind();
                                dgRegPendingStudents1.Attributes.Add("style", "display:block");
                                lblGridName.Attributes.Add("display", "block");
                                lblGrid.Text = "* Please click on the Student Name to select the Student whose Provisional Eligibility for a particular " + lblCr.Text.ToLower() + " is to be Resolved";
                                lblGrid.Attributes.Add("style", "display:block");
                                tblDGRegPendingStudents.Attributes.Add("style", "display:block");
                                //ViewState.Add("SimpleSearchDS", ds);
                            }
                            else if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "1") // Eligible
                            {
                                if (txtElgFormNo.Text != string.Empty)
                                {
                                    lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();
                                }
                                else if (txtPRN.Text != string.Empty)
                                {
                                    lblErrorMsg.Text = "The Student with PRN Number " + txtPRN.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();

                                }
                                else if (txtApplicationFrmNo.Text != string.Empty)
                                {
                                    lblErrorMsg.Text = "The Student with entered Application Form Number " + txtApplicationFrmNo.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();

                                }

                                divErrorMsg.Attributes.Add("style", "display:block");
                                lblErrorMsg.Attributes.Add("style", "display:none");
                                lblGridName.Attributes.Add("display", "none");
                                lblGrid.Attributes.Add("style", "display:none");
                            }
                            else  //Not Eligible
                            {
                                if (txtElgFormNo.Text != string.Empty)
                                {
                                    lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";
                                }
                                else if (txtPRN.Text != string.Empty)
                                {
                                    lblErrorMsg.Text = "The Student with PRN Number " + txtPRN.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";

                                }

                                else if (txtApplicationFrmNo.Text != string.Empty)
                                {
                                    lblErrorMsg.Text = "The Student with entered Application Form Number " + txtApplicationFrmNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";

                                }
                                divErrorMsg.Style.Add("display", "block");
                                lblErrorMsg.Style.Add("display", "block");
                                lblGridName.Attributes.Add("display", "none");
                                lblGrid.Attributes.Add("style", "display:none");
                            }

                        }
                        else
                        {
                            if (txtElgFormNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The eligibility of the Student with Eligibility Form Number  " + txtElgFormNo.Text.Trim() + "  is not kept provisional or may not be processed.Please check the status to verify.";
                            }
                            else if (txtPRN.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The eligibility of the Student with PRN Number  " + txtPRN.Text.Trim() + "  is not kept provisional or may not be processed.Please check the status to verify.";

                            }
                            else if (txtApplicationFrmNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The eligibility of the Student with entered Application Form Number  " + txtApplicationFrmNo.Text.Trim() + "  is not kept provisional or may not be processed.Please check the status to verify.";

                            }
                            divErrorMsg.Style.Add("display", "block");
                            lblErrorMsg.Style.Add("display", "block");
                            lblGridName.Attributes.Add("display", "none");
                            lblGrid.Attributes.Add("style", "display:none");
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                     throw new Exception(ex.Message);
                }
                finally
                {
                    ds.Dispose();
                }
            }
            else
            {
                lblErrorMsg.Text = "There is no matching record.";
                lblErrorMsg.Attributes.Add("style", "display:block");
            }
            divSimpleSearch.Attributes.Add("style", "display:block");
            DivAdvanceSearch.Attributes.Add("style", "display:none");
        }

        #endregion


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblAdvSearch.InnerText = "Simple Search";
            lblSubmitMessage.Attributes.Add("style", "display:none");
            rbElgDecsionNo.Checked = false;
            rbElgDecsionYes.Checked = true;
            if(rbFilterYesNo.SelectedValue == "1")
            {
                rbFilterYesNo.SelectedValue = "0";
            }

            txtNotElgReason.Text = string.Empty;
            tblResolveQuestion.Attributes.Add("style", "display:block");
            divErrorMsg.Attributes.Add("style", "display:none");

            DivExaminingBodyFilter.Attributes.Add("style", "display:none");

            tdSubmit.Attributes.Add("style", "display:none");
            hidSubmitFlag.Value = "0";
            hidFacName.Value = string.Empty;
            hidCrName.Value = string.Empty;
            hidMOLName.Value = string.Empty;
            hidBrName.Value = string.Empty;
            hidPattern.Value = string.Empty;
            hidAcYrName.Value = string.Empty;

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
            DivAdvanceSearch.Attributes.Add("style", "display:block");
            divSimpleSearch.Attributes.Add("style", "display:none");

            fnFillState(hid_StateID.Value);
            

            txtFirstName.Text = "";
            txtLastName.Text = "";
           
            hidBodyState.Value = Body_State.SelectedItem.Value;
            hidStateSelText.Value = Body_State.SelectedItem.Text;
            hidBodyID.Value = Body_ID.SelectedItem.Value;
            hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
            hidtxtCountryForeignBoardUniv.Value = txtForeignBoardUnivName.Text;

       
             fnDisplayRegGrid(); 
                
        }

        protected void dgRegPendingStudents1_RowdataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx"))
                {
                    e.Row.Cells[4].Style.Add("display", "none");
                }
                e.Row.Cells[5].Style.Add("display", "none");
                //e.Row.Cells[5].Style.Add("display", "none");
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
                //e.Row.Cells[16].Style.Add("display", "none");
                if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx") || hidSearchType.Value.Equals("Simple"))
                {
                    /**********************************************/
                    e.Row.Cells[18].Style.Add("display", "none");

                    /************************************************/
                }
                //**********************************************
                string BackColorCode = string.Empty;

                if (e.Row.Cells[21].Text == "same_university")
                {
                    BackColorCode = "#FFE4C4";
                }
                else if (e.Row.Cells[21].Text == "home_board")
                {
                    BackColorCode = "#E1FFFF";
                }
                else if (e.Row.Cells[21].Text == "other_state_board")
                {
                    BackColorCode = "#CCEEFF";
                }
                else if (e.Row.Cells[21].Text == "Foreign_board")
                {
                    BackColorCode = "#FFCCFF";
                }
                //**********************************************

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml(BackColorCode);
                    e.Row.Cells[21].Style.Add("display", "none");
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx"))
                {
                    e.Row.Cells[4].Style.Add("display", "none");
                }
                e.Row.Cells[5].Style.Add("display", "none");
                // e.Row.Cells[5].Style.Add("display", "none");
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
                //e.Row.Cells[16].Style.Add("display", "none");
                e.Row.Cells[21].Style.Add("display", "none");
                if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx") || hidSearchType.Value.Equals("Simple"))
                {
                    /************************************************/
                    e.Row.Cells[18].Style.Add("display", "none");
                    /************************************************/
                }
            }

        }

        protected void dgRegPendingStudents1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgRegPendingStudents1.PageIndex = e.NewPageIndex;
            //dgRegPendingStudents1.DataBind();
            fnDisplayRegGrid();
        }

        protected void dgRegPendingStudents1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PendingStudentDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgRegPendingStudents1.Rows[index];

                hidElgFormNo.Value = row.Cells[2].Text.Trim();
                hidpkYear.Value = row.Cells[8].Text.Trim();
                hidpkStudentID.Value = row.Cells[9].Text.Trim();
                hidFacID.Value = row.Cells[10].Text.Trim();
                hidCrID.Value = row.Cells[11].Text.Trim();
                hidCrMoLrnID.Value = row.Cells[12].Text.Trim();
                hidPtrnID.Value = row.Cells[13].Text.Trim();
                hidBrnID.Value = row.Cells[14].Text.Trim();
                hidCrPrDetailsID.Value = row.Cells[15].Text.Trim();
                hidFacName.Value = ddlFaculty.SelectedItem.Text;
                hidCrName.Value = ddlCourse.SelectedItem.Text;
                hidMOLName.Value = ddlMoLrn.SelectedItem.Text;
                hidPattern.Value = ddlCrPtrn.SelectedItem.Text;
                hidBrName.Value = ddlBranch.SelectedItem.Text;
                hidAcYrName.Value = ddlAcademicYear.SelectedItem.Text;
                if (lblAdvSearch.InnerText == "Simple Search")
                {
                    hidSearchType.Value = "Adv";
                }
                else
                {
                    hidSearchType.Value = "Simple";
                }

                strUrl = "ELGV2_ResolveProvisional__2.aspx?Search=Simple";
                Server.Transfer(strUrl, true);
            }
        }

        protected void dgRegPendingStudents1_Sorting(object sender, GridViewSortEventArgs e)
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

        private void fnDisplayRegGrid()
        {
            DataSet ds = new DataSet();
            DataView dv = new DataView();

            //if (AcdYearID.Equals("0"))
            //{
                if (!ddlAcademicYear.SelectedIndex.Equals(0))
                {
                    hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.ToString();
                    hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;
                }

                //for preventing clearing of ac yr id when coming back from details page
                else
                {
                    if (Request.QueryString["AcYear"] != null)
                    {
                        hid_fk_AcademicYr_ID.Value = Request.QueryString["AcYear"].ToString();
                    }
                }
            //}

            try
            {
                //ds = Eligibility.clsEligibilityDBAccess.Fetch_Pending_Reg_Student_List(Classes.clsGetSettings.UniversityID.ToString(), Session["SInst_Type"].ToString(), Session["SInst_Name"].ToString(), Session["SState_ID"].ToString(), Session["SDistrict_ID"].ToString(), Session["STehsil_ID"].ToString(), Session["FacultyID"].ToString(), Session["CourseID"].ToString(), Session["CrMoLrnPtrnID"].ToString(), Session["CoursePartID"].ToString(), Session["DOB"].ToString(), Session["LastName"].ToString(), Session["FirstName"].ToString(), Session["Gender"].ToString());
                string str = Page.ToString();

                if (rbElgDecsionNo.Checked == true && rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "0")
                {
                    if (str == "ASP.eligibility_elgv2_resolvepending__1_aspx")
                    {
                        ds = Eligibility.clsEligibilityDBAccess.Fetch_Pending_Reg_Student_List_Resolve1(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hid_fk_AcademicYr_ID.Value, hidBodyState.Value, hidBodyID.Value);
                        lblGridName.Text = "List of students whose Eligiblity is kept pending";
                    }
                    else if (str == "ASP.eligibility_elgv2_resolveprovisional__1_aspx")
                    {
                        ds = Eligibility.clsEligibilityDBAccess.Fetch_ProvisionallyEligible_Reg_Student_List_Resolve1(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, AcdYearID, hidBodyState.Value, hidBodyID.Value);
                        lblGridName.Text = "List of students whose Eligiblity is kept Provisional";
                        lblGrid.Attributes.Add("style", "display:none");
                    }
                }
                else if (rbElgDecsionNo.Checked == false || rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                {
                    if (str == "ASP.eligibility_elgv2_resolvepending__1_aspx")
                    {
                        ds = Eligibility.clsEligibilityDBAccess.Fetch_Pending_Reg_Student_List_Resolve(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hid_fk_AcademicYr_ID.Value);
                        lblGridName.Text = "List of students whose Eligiblity is kept pending";
                    }
                    else if (str == "ASP.eligibility_elgv2_resolveprovisional__1_aspx")
                    {
                        ds = Eligibility.clsEligibilityDBAccess.Fetch_ProvisionallyEligible_Reg_Student_List_Resolve(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hid_fk_AcademicYr_ID.Value);
                        lblGridName.Text = "List of students whose Eligiblity is kept Provisional";
                        lblGrid.Attributes.Add("style", "display:none");

                    }
                }
                else if (rbElgDecsionNo.Checked == true && rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "1")
                {
                    if (str == "ASP.eligibility_elgv2_resolvepending__1_aspx")
                    {
                        ds = Eligibility.clsEligibilityDBAccess.Fetch_Pending_Reg_Student_List_Resolve2(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hid_fk_AcademicYr_ID.Value, hidCountryIDForeign.Value, hidtxtCountryForeignBoardUniv.Value);
                        lblGridName.Text = "List of students whose Eligiblity is kept pending";
                    }
                    else if (str == "ASP.eligibility_elgv2_resolveprovisional__1_aspx")
                    {
                        ds = Eligibility.clsEligibilityDBAccess.Fetch_ProvisionallyEligible_Reg_Student_List_Resolve2(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, AcdYearID, hidCountryIDForeign.Value, hidtxtCountryForeignBoardUniv.Value);
                        lblGridName.Text = "List of students whose Eligiblity is kept Provisional";
                        lblGrid.Attributes.Add("style", "display:none");
                    }

                }

                ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
                if (hidFacName.Value.Equals(string.Empty))
                {
                   if (Request.QueryString["AcYear"] == null)                  
                    {
                        hidFacName.Value = ddlFaculty.SelectedItem.Text;
                        hidCrName.Value = ddlCourse.SelectedItem.Text;
                        hidMOLName.Value = ddlMoLrn.SelectedItem.Text;
                        hidPattern.Value = ddlCrPtrn.SelectedItem.Text;
                        hidBrName.Value = ddlBranch.SelectedItem.Text;
                        hidAcYrName.Value = ddlAcademicYear.SelectedItem.Text;

                        Session["hidFacName"] = hidFacName.Value;
                        Session["hidCrName"] = hidCrName.Value;
                        Session["hidMOLName"] = hidMOLName.Value;
                        Session["hidPattern"] = hidPattern.Value;
                        Session["hidBrName"] = hidBrName.Value;
                        Session["hidAcYrName"] = hidAcYrName.Value;
                    }
                    else 
                    {
                        hidFacName.Value = Convert.ToString(Session["hidFacName"]);
                        hidCrName.Value = Convert.ToString(Session["hidCrName"]);
                        hidMOLName.Value = Convert.ToString(Session["hidMOLName"]);
                        hidPattern.Value = Convert.ToString(Session["hidPattern"]);
                        hidBrName.Value = Convert.ToString(Session["hidBrName"]);
                        hidAcYrName.Value = Convert.ToString(Session["hidAcYrName"]);
                    
                    }
                   
                }

                ((Label)Cntph1.FindControl("lblSubHeader")).Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value) + " - " + Session["hidFacName"] + " - " + Session["hidCrName"] + " - " + Session["hidMOLName"] + " - " + Session["hidPattern"] + " - " + Session["hidBrName"] + " [Academic Year " + Session["hidAcYrName"] + "]";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


            if (ds.Tables[0].Rows.Count > 0)
            {
                dv.Table = ds.Tables[0];


                if (ViewState["SortExpression"] != null)
                {
                    dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();
                }
                dgRegPendingStudents1.DataSource = dv;
                try
                {
                    dgRegPendingStudents1.DataBind();
                }
                catch
                {
                    dgRegPendingStudents1.PageIndex = 0;
                    dgRegPendingStudents1.DataBind();
                }

                dgRegPendingStudents1.Columns[16].ItemStyle.CssClass = "clOff";
                dgRegPendingStudents1.Columns[16].HeaderStyle.CssClass = "clOff";
                dgRegPendingStudents1.Style.Add("display", "block");
                tblDGRegPendingStudents.Style.Remove("display");
                tblDGRegPendingStudents.Style.Add("display", "block");
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");

                lblGrid.Text = "* Please click on the Student Name to select the Student whose Provisional Eligibility for a particular " + lblCr.Text.ToLower() + " is to be Resolved";
                lblGrid.Attributes.Add("style", "display:block");

            }
            else
            {
                string msg = string.Empty;
                if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx")) { msg = "Pending"; }
                else { msg = "Provisional"; }
                dgRegPendingStudents1.Style.Add("display", "none");
                tblDGRegPendingStudents.Style.Remove("display");
                tblDGRegPendingStudents.Style.Add("display", "none");

                lblGridName.Text = "There are no Students satisfying the above search criteria whose Eligibility is kept " + msg + "...";
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");
                divDGNote.Style.Remove("display");
                divDGNote.Style.Add("display", "none");
                //divAcademicYr.Style.Add("display", "none");
                tdSubmit.Attributes.Add("style", "display:none");
                tblResolveQuestion.Attributes.Add("style", "display:none");
                lblGrid.Style.Add("display", "none");

            }

            if (lblAdvSearch.InnerText == "Simple Search")
            {
                hidSearchType.Value = "Adv";
            }
            else
            {
                hidSearchType.Value = "Simple";
            }

            if (HidSearchType.Equals("Adv"))
            {
                divSimpleSearch.Attributes.Add("style", "display:none");
                DivAdvanceSearch.Attributes.Add("style", "display:block");
                if (Page.ToString() != "ASP.eligibility_elgv2_resolvepending__1_aspx" && ds.Tables[0].Rows.Count > 0)
                {
                    tdSubmit.Attributes.Add("style", "display:block");
                    tblResolveQuestion.Attributes.Add("style", "display:block");
                }
            }

            ds.Clear();
            ds.Dispose();
            ds = null;
        }

        #region Button Process Click
        protected void btnProcessData_Click(object sender, EventArgs e)
        {

            rbElgDecsionNo.Checked = true;

            if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "0")
            {
                //fnFillState(hid_StateID.Value);
                //FillBoradDetails(hid_StateID.Value, hid_BodyID.Value);
                DivFilterExamBody.Attributes.Add("style", "display:inline");
            }
            else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "1")
            {
                hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
                hidtxtCountryForeignBoardUniv.Value = txtForeignBoardUnivName.Text;
            }

            if (rbFilterYesNo.SelectedItem.Value.ToString() == "1")
            {
                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:inline");
            }
            if (rbFilterYesNo.SelectedItem.Value.ToString() == "0")
            {
                rbFilterYesNo.SelectedItem.Value = "0";
                rbFilterYesNo.Items[1].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:none");
            }
            txtFirstName.Text = "";
            txtLastName.Text = "";

            hidBodyState.Value = Body_State.SelectedItem.Value;
            hidStateSelText.Value = Body_State.SelectedItem.Text;
            hid_BodyID.Value = Body_ID.SelectedItem.Value;
            hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
            hidtxtCountryForeignBoardUniv.Value = txtForeignBoardUnivName.Text;
            //hidCrPrID.Value = DD_CoursePart.SelectedItem.Value;

            ////New Concept Begin
            if (rbFilterYesNo.SelectedItem.Value.ToString() == "0")
            {
                rbFilterYesNo.SelectedItem.Value = "0";
                rbFilterYesNo.Items[1].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:none");
            }

            else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidCountryIDForeign.Value == "0")
            {
                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;
                DivExaminingBodyFilter.Attributes.Add("style", "display:block");
                DivFilterExamBody.Attributes.Add("style", "display:block");
                Body_Country.Attributes.Add("style", "display:none");
                txtForeignBoardUnivName.Attributes.Add("style", "display:none");
                TrCountryForeignBoardUniv.Attributes.Add("style", "display:none");
                TrCountry.Attributes.Add("style", "display:none");
                TrState.Attributes.Add("style", "display:inline");
                TrBody.Attributes.Add("style", "display:inline");

            }

            else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidCountryIDForeign.Value != "0")
            {
                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;
                DivExaminingBodyFilter.Attributes.Add("style", "display:block");
                DivFilterExamBody.Attributes.Add("style", "display:block");
                Body_Country.Attributes.Add("style", "display:inline");
                txtForeignBoardUnivName.Attributes.Add("style", "display:inline");
                TrCountryForeignBoardUniv.Attributes.Add("style", "display:inline");
                TrCountry.Attributes.Add("style", "display:inline");
                TrState.Attributes.Add("style", "display:none");
                TrBody.Attributes.Add("style", "display:none");
            }
            //New Concept End

            try
            {
                //Get Rights Flag
                //sRightsFlag = clsEligibilityRights.Elg_Get_Courses_Rights(hidUniID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value, hidCrPrChID.Value);
                //hidRightsFlag.Value = sRightsFlag;

                //fnFillState(hidBodyState.Value);
                //Body_Country.Items.FindByValue(hidCountryIDForeign.Value).Selected = true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidBodyID.Value == "0" && hidCountryIDForeign.Value == "0")
            {
                if (Body_Type_Flag.SelectedItem.Value == "1")
                {
                    TdBodyCaption.InnerText = "Select Board";
                }
                else if (Body_Type_Flag.SelectedItem.Value == "2")
                {
                    TdBodyCaption.InnerText = "Select " + lblUniversity.Text + "";
                }

                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:inline");
            }

            fnDisplayRegGrid(); 
            
        }
        #endregion

        public void FillBoradDetails(string State, string Board)
        {
            clsCommon common = new clsCommon();
            DataTable dt;

            if (Body_Type_Flag.SelectedItem.Value.ToString() == "1")
            {

                try
                {

                    dt = clsEligibilityRights.ELGV2_List_StateWiseBoard_BulkProcess(hidUniID.Value, hidInstID.Value, hid_StateID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                common.fillDropDown(Body_ID, dt, Board, "StateBoard_Description", "pk_BoardID", "--- Select ---");
                hidBodySelText.Value = Body_ID.SelectedItem.Text;

            }
            else if (Body_Type_Flag.SelectedItem.Value.ToString() == "2")
            {

                try
                {
                    if (hid_StateID.Value == "")
                    {
                        hid_StateID.Value = "0";
                    }

                    dt = clsEligibilityRights.ELGV2_ListStateWiseUniversities(hid_StateID.Value, hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                common.fillDropDown(Body_ID, dt, Board, "Uni_Name", "pk_Uni_ID", "--- Select ---");
                hidBodySelText.Value = Body_ID.SelectedItem.Text;
                //dt.Dispose;

            }
        }

        #region Button Submit Click

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            rbElgDecsionNo.Checked = false;
            rbElgDecsionYes.Checked = true;
            int iCount = 0;
            string reason = "";
     
            try
            {
                XmlDocument xml = new XmlDocument();
                XmlNode root = xml.CreateNode(XmlNodeType.Element, "R", "");
                XmlNode childNode = null;

                for (int i = 0; i < dgRegPendingStudents1.Rows.Count; i++)
                {
                    CheckBox student_id = (CheckBox)dgRegPendingStudents1.Rows[i].FindControl("chkStudent");
                    HiddenField hid_chk = (HiddenField)dgRegPendingStudents1.Rows[i].FindControl("hid_chkStudent");
                    if (student_id.Checked)
                    {
                        childNode = xml.CreateNode(XmlNodeType.Element, "SD", "");
                        childNode.AppendChild(xml.CreateElement("YrID")).InnerText = dgRegPendingStudents1.Rows[i].Cells[8].Text.ToString().Trim();
                        childNode.AppendChild(xml.CreateElement("StuID")).InnerText = dgRegPendingStudents1.Rows[i].Cells[9].Text.ToString().Trim();
                        childNode.AppendChild(xml.CreateElement("CrPrDetID")).InnerText = dgRegPendingStudents1.Rows[i].Cells[15].Text.ToString().Trim();
                        // childNode.AppendChild(xml.CreateElement("CrPrChID")).InnerText = dgRegPendingStudents1.Rows[i].Cells[15].Text.ToString().Trim();
                        root.AppendChild(childNode);
                        iCount = Convert.ToInt32(iCount) + 1;
                    }

                }

                xml.AppendChild(root);


                hidpkStudentID.Value = xml.OuterXml.ToString();
                // hidpkStudentID.Value = hidpkStudentID.Value.Trim(',');
                clsUser user = new clsUser();
                user = (clsUser)Session["User"];
                int RowsAffected = 0, ElgFlag = 0;
                if (hidEligibility.Value.Equals("Eligible"))
                {
                    ElgFlag = 1;
                }
                else if (hidEligibility.Value.Equals("Not Eligible"))
                {
                    ElgFlag = 2;
                }


                //RowsAffected = clsEligibilityDBAccess.REG_ProvisionallyEligibleStudentEligibilityDecisionBulk(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(hidInstID.Value), hidpkStudentID.Value, Convert.ToInt32(hidFacID.Value), Convert.ToInt32(hidCrID.Value), Convert.ToInt32(hidCrMoLrnID.Value), Convert.ToInt32(hidPtrnID.Value), Convert.ToInt32(hidBrnID.Value), Convert.ToInt32(dgRegPendingStudents1.Rows[0].Cells[14].Text), Convert.ToInt32(hid_fk_AcademicYr_ID.Value), ElgFlag.ToString(), txtNotElgReason.Text, user.User_ID);
                RowsAffected = clsEligibilityDBAccess.REG_ProvisionallyEligibleStudentEligibilityDecisionBulk(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(hidInstID.Value), Convert.ToInt32(hidFacID.Value), Convert.ToInt32(hidCrID.Value), Convert.ToInt32(hidCrMoLrnID.Value), Convert.ToInt32(hidPtrnID.Value), Convert.ToInt32(hidBrnID.Value), Convert.ToInt32(hid_fk_AcademicYr_ID.Value), hidpkStudentID.Value, ElgFlag.ToString(), txtNotElgReason.Text, user.User_ID);
                if (RowsAffected > 0)
                {
                    string SMSreturn = "";
                    string SMSMessage = "";
                    clsUser u = (clsUser)Session["User"]; //Added By Saroj on 1st Nov 2007

                    SendSMS objSendSMS = new SendSMS();
                    //ds = clsEligibilityRights.FetchRegisteredStudentDetailsForSMS(hidUniID.Value,  hidInstID.Value.ToString(), hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, dgRegPendingStudents1.Rows[0].Cells[14].Text, dgRegPendingStudents1.Rows[0].Cells[15].Text, hidpkStudentID.Value);
                    ds = clsEligibilityRights.FetchRegisteredStudentDetailsForSMS(hidUniID.Value, hidInstID.Value.ToString(), hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, dgRegPendingStudents1.Rows[0].Cells[16].Text, hidpkStudentID.Value);
                    if (ds != null)
                    {

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                //SMSMessage = "Congrats " + hidSMSFirstName.Value + ",You are eligible for " + hidSMSCrAbbr.Value + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your PRN:" + PRN + ".";
                                //==========================================================================================
                                // To fetch Student login credentials for displaying in SMS
                                string userName = string.Empty, password = string.Empty;
                                DataSet Ds = clsEligibilityRights.GetStudentCredentialsForSMS(ds.Tables[0].Rows[i]["pk_Uni_ID"].ToString(), ds.Tables[0].Rows[i]["pk_Year"].ToString(), ds.Tables[0].Rows[i]["pk_Student_ID"].ToString());
                                if (Ds != null && Ds.Tables[0] != null && Ds.Tables[0].Rows.Count > 0)
                                {
                                    userName = Ds.Tables[0].Rows[0]["UserName"].ToString();
                                    password = Ds.Tables[0].Rows[0]["Password"].ToString();
                                }
                                //==========================================================================================
                                if (ElgFlag.ToString() == "1")
                                {
                                    //SMSMessage = "Congrats " + ds.Tables[0].Rows[i]["FirstName"].ToString() + ",You are Eligible for " + ds.Tables[0].Rows[i]["CrAbbr"].ToString() + " for Academic Year " + ds.Tables[0].Rows[i]["Year"].ToString() + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ".";// Your PRN:" + ds.Tables[0].Rows[i]["PRN"].ToString();
                                    SMSMessage = clsEligibilityRights.GetSMSBody("24", ds.Tables[0].Rows[i]["FirstName"].ToString(), ds.Tables[0].Rows[i]["CrAbbr"].ToString(), ds.Tables[0].Rows[i]["Year"].ToString(), ds.Tables[0].Rows[i]["UniAbbr"].ToString().ToUpper(), ds.Tables[0].Rows[i]["PRN"].ToString(), clsGetSettings.SitePath, userName, password, string.Empty);
                                }
                                if (ElgFlag.ToString() == "2")
                                {
                                    //SMSMessage = "Dear " + ds.Tables[0].Rows[i]["FirstName"].ToString() + ",You are found inEligible for " + ds.Tables[0].Rows[i]["CrAbbr"].ToString() + " for Academic Year " + ds.Tables[0].Rows[i]["Year"].ToString() + ". For more details contact your " + lblCollege.Text.ToLower() + ".";
                                    SMSMessage = clsEligibilityRights.GetSMSBody("5", ds.Tables[0].Rows[i]["FirstName"].ToString(), ds.Tables[0].Rows[i]["CrAbbr"].ToString(), ds.Tables[0].Rows[i]["Year"].ToString(), ds.Tables[0].Rows[i]["UniAbbr"].ToString().ToUpper(), "", clsGetSettings.SitePath, "", "", string.Empty);
                                }
                                objSendSMS.epMessage = SMSMessage;
                                objSendSMS.epUser = u.User_ID;  //Added By Saroj on 1st Nov 2007
                                SMSreturn = objSendSMS.SendPersonalizedSMS(ds.Tables[0].Rows[i]["MobileNumber"].ToString().Trim(), "ELG" + ds.Tables[0].Rows[i]["EligibilityFormNo"].ToString());
                            }
                        }
                    }
                    if (hidEligibility.Value.Equals("Not Eligible"))
                    {
                        reason = " the reason being \"" + txtNotElgReason.Text + "\".";
                    }
                    lblSubmitMessage.Attributes.Add("style", "display:block");
                    divError.Attributes.Add("style", "display:none");
                    lblSubmitMessage.Text = "The Provisional Eligibility for " + iCount + " Student(s) is resolved and are marked as \"" + hidEligibility.Value + "\"" + reason;
                    lblGrid.Attributes.Add("style", "display:none");
                    tblResolveQuestion.Attributes.Add("style", "display:none");
                    tdSubmit.Attributes.Add("style", "display:none");
                    rbMarkElg.Checked = false;
                    rbMarkNotElg.Checked = false;
                    hidEligibility.Value = "";
                }
                else
                {
                    lblSubmitMessage.Attributes.Add("style", "display:none");
                    divError.Attributes.Add("style", "display:block");
                    lblError.Text = "System has encountered an error in the Registration Process. Hence, Registration failed !!!<br>Please try again later.";


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
                hidpkYear.Value = "";
                hidpkStudentID.Value = "";
                fnDisplayRegGrid();
        }

        #endregion

        #region fnFetchStudent

        private void fnFetchStudent()
        {
            lblSubmitMessage.Attributes.Add("style", "display:none");
            rbElgDecsionNo.Checked = true;
            rbElgDecsionYes.Checked = false;
            txtNotElgReason.Text = string.Empty;
            tblResolveQuestion.Attributes.Add("style", "display:none");
            divErrorMsg.Attributes.Add("style", "display:none");
            divDGNote.Attributes.Add("style", "display:none");
            lblErrorMsg.Attributes.Add("style", "display:none");
            tdSubmit.Attributes.Add("style", "display:none");
            hidSubmitFlag.Value = "0";

            string ElgFormNo;
            if (txtElgFormNo.Text != "")
            {
                ElgFormNo = txtElgFormNo.Text.Trim();
                hidIsBlank.Value = ElgFormNo;
            }
            else
            {
                ElgFormNo = "0-0-0-0";
                hidIsBlank.Value = "";

            }

            int cnt = 0;
            string str = ElgFormNo;
            int pos = str.IndexOf('-');
            string[] arr = new string[] { "0", "0", "0", "0" };
            Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");

            if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                PRNumber = txtPRN.Text.Trim();
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
                arr = ElgFormNo.Split('-');   //new  UniID = arr[0], InstID = arr[1],Year = arr[2], StudID = arr[3]
                for (int i = 0; i < 4; i++)
                {
                    if (arr[i] == "")
                        arr[i] = "0";
                }
                try
                {
                    #region call search for provisional students

                    if (Page.ToString().Equals("ASP.eligibility_elgv2_resolveprovisional__1_aspx"))
                    {
                        ds = clsEligibilityDBAccess.Check_Reg_Provisional_Student_Exists(arr[0], arr[1], arr[2], arr[3], txtPRN.Text, hidInstID.Value, txtApplicationFrmNo.Text);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "5")    // Provisional Eligibility
                            {
                                hidElgFormNo.Value = txtElgFormNo.Text.Trim();
                                hidpkYear.Value = ds.Tables[0].Rows[0]["pkYear"].ToString();
                                hidpkStudentID.Value = ds.Tables[0].Rows[0]["pkStudentID"].ToString();
                                hidFacID.Value = ds.Tables[0].Rows[0]["pkFacID"].ToString();
                                hidCrID.Value = ds.Tables[0].Rows[0]["pkCrID"].ToString();
                                hidCrMoLrnID.Value = ds.Tables[0].Rows[0]["pkMoLrnID"].ToString();
                                hidPtrnID.Value = ds.Tables[0].Rows[0]["pkPtrnID"].ToString();
                                hidBrnID.Value = ds.Tables[0].Rows[0]["pkBrnID"].ToString();
                                hidCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pkCrPrDetails"].ToString();
                                hid_fk_AcademicYr_ID.Value = ds.Tables[0].Rows[0]["fkAcademicYearID"].ToString();
                                //Server.Transfer("ELGV2_ResolveProvisional__2.aspx?Search=Simple");
                                hidPRN.Value = ds.Tables[0].Rows[0]["PRN"].ToString();
                                dgRegPendingStudents1.DataSource = ds;
                                dgRegPendingStudents1.DataBind();
                                dgRegPendingStudents1.Columns[16].ItemStyle.CssClass = "clOff";
                                dgRegPendingStudents1.Columns[16].HeaderStyle.CssClass = "clOff";
                                dgRegPendingStudents1.Attributes.Add("style", "display:block");
                                lblGridName.Attributes.Add("display", "block");
                                lblGrid.Text = "* Please click on the Student Name to select the Student whose Provisional Eligibility for a particular " + lblCr.Text.ToLower() + " is to be Resolved";
                                lblGrid.Attributes.Add("style", "display:block");
                                tblDGRegPendingStudents.Attributes.Add("style", "display:block");
                                lblErrorMsg.Attributes.Add("style", "display:none");
                                //ViewState.Add("SimpleSearchDS", ds);
                            }
                            else if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "1") // Eligible
                            {
                                lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();
                                divErrorMsg.Attributes.Add("style", "display:block");
                                lblErrorMsg.Attributes.Add("style", "display:none");
                                lblGridName.Attributes.Add("display", "none");
                                lblGrid.Attributes.Add("style", "display:none");
                            }
                            else  //Not Eligible
                            {
                                lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";
                                divErrorMsg.Style.Add("display", "block");
                                lblErrorMsg.Style.Add("display", "block");
                                lblGridName.Attributes.Add("display", "none");
                                lblGrid.Attributes.Add("style", "display:none");
                            }

                        }
                        else
                        {
                            lblErrorMsg.Text = "The eligibility of the Student with Eligibility Form Number  " + txtElgFormNo.Text.Trim() + "  is not kept pending or may not be processed.Please check the status to verify.";
                            divErrorMsg.Style.Add("display", "block");
                            lblErrorMsg.Style.Add("display", "block");
                            lblGridName.Attributes.Add("display", "none");
                            lblGrid.Attributes.Add("style", "display:none");
                            if (qstrNavigate == "back")
                            {
                                divErrorMsg.Attributes.Add("style", "display:none");
                                lblErrorMsg.Attributes.Add("style", "display:none");
                                txtElgFormNo.Text = string.Empty;
                                txtPRN.Text = string.Empty;
                            }
                        }
                    }
                    #endregion
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
            else
            {
                lblErrorMsg.Text = "There is no matching record.";
                lblErrorMsg.Attributes.Add("style", "display:block");
            }
            divSimpleSearch.Attributes.Add("style", "display:block");
            DivAdvanceSearch.Attributes.Add("style", "display:none");
        }

        #endregion
    }
}
