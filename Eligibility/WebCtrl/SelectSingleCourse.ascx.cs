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
using AjaxControlToolkit;
using Classes;
using Microsoft.ApplicationBlocks.Data;
using ServerSideValidations;
using StudentRegistration.Eligibility.ElgClasses;

namespace StudentRegistration.Eligibility
{
    /// <summary>
    /// Delegate for proceed button click event
    /// </summary>
    /// <param name="sender">Event Source</param>
    /// <param name="e">Event Arguments</param>
    public delegate void SingleCourseProceedClick(object sender, EventArgs e);
    public delegate void SingleCoursePartChange(object sender, EventArgs e);

    public partial class SelectSingleCourse : System.Web.UI.UserControl
    {
        #region Variable Declaration

        DataTable oDT = null;
        clsCommon oCommon = null;
        clsRegionalStudyCenter oRegionalStudyCenter;

        InstituteRepository oInstituteRepository = new InstituteRepository();
        CourseRepository oCourseRepository = new CourseRepository();

        private string pk_Uni_ID = Convert.ToString(clsGetSettings.UniversityID);
        private string pk_Institute_ID = string.Empty;
        private string instName = string.Empty;

        private string[] IDs_List = new string[3];

        private string facultyID = string.Empty;
        private string courseID = string.Empty;
        private string modeLrnID = string.Empty;
        private string patternID = string.Empty;

        private string courseName = string.Empty;
        private string facultyName = string.Empty;

        private string branchID = string.Empty;
        private string branchName = string.Empty;

        private string partID = string.Empty;
        private string partName = string.Empty;

        private string termID = string.Empty;
        private string termName = string.Empty;

        private string academicYearID = string.Empty;
        private string academicYear = string.Empty;

        private string pageTitle = string.Empty;

        private string sUserID = string.Empty;
        private string sUserName = string.Empty;
        private string sDateFrom = string.Empty;
        private string sDateTo = string.Empty;

        private bool isFacultyDisplay = true;
        private bool isCourseDisplay = true;
        private bool isBranchDisplay = true;
        private bool isCoursePartDisplay = true;
        private bool isCourseTermDisplay = true;
        private bool isReportUserAndDateDisplay = true;
        private bool isInstituteDisplay = true;
        private bool isAcYrDisplay = true;

        private string selectedCourseString = string.Empty;
        private string selectedOtherString = string.Empty;

        private string regionalCenterID = string.Empty;
        private string regionalCenterName = string.Empty;
        private string regionalCenterCode = string.Empty;
        private string regionalCenterCity = string.Empty;

        private string studyCenterID = string.Empty;
        private string studyCenterName = string.Empty;
        private string studyCenterCode = string.Empty;

        private bool isRegionalCenterVisible = false;

        private bool isCollegeLogin = false;

        // Used For Admission Eligibility Part is Annual or Termwise
        //public string AorT { get; set; }
       // public bool isCoursePartAvailabletoConfigure { get; set; }

        /// <summary>
        /// Proceed button click event
        /// </summary>
        public event SingleCourseProceedClick OnProceedClick;
        public event SingleCoursePartChange OnPartChange;
        #endregion

        //*******************
        clsUser user;
        string StrRegionalCenterLoginID = string.Empty;
        DataTable oDTRegCenters = null;
        string isRegionalCenterLogin = string.Empty;
        public string IsRegionalCenterLogin
        {
            get
            {
                return isRegionalCenterLogin;
            }

            set
            {
                isRegionalCenterLogin = value;
            }
        }
        //*******************

        #region Set Properties
        /// <summary>
        /// Gets  the UserID.
        /// </summary>
        public bool IsRegionalCenterVisible
        {
            get
            {
                return isRegionalCenterVisible;
            }
            set
            {
                isRegionalCenterVisible = value;
            }
        }

        /// <summary>
        /// Gets  the UserID.
        /// </summary>
        public string UserID
        {
            get
            {
                return sUserID;
            }
        }

        /// <summary>
        /// Gets  the User Name.
        /// </summary>
        public string UserName
        {
            get
            {
                return sUserName;
            }
        }

        /// <summary>
        /// Gets  the Date From.
        /// </summary>
        public string DateFrom
        {
            get
            {
                return sDateFrom;
            }
        }

        /// <summary>
        /// Gets  the Date To.
        /// </summary>
        public string DateTo
        {
            get
            {
                return sDateTo;
            }
        }

        /// <summary>
        /// Gets the Institute Name.
        /// </summary>
        public string InstName
        {
            get
            {
                return instName;

            }
        }


        /// <summary>
        /// Gets or sets the Institute ID.
        /// </summary>
        public string InstID
        {
            get
            {
                return pk_Institute_ID;
            }
            set
            {
                pk_Institute_ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Faculty ID.
        /// </summary>
        public string FacultyID
        {
            get
            {
                return facultyID;
            }
        }

        /// <summary>
        /// Gets or sets the Faculty Name.
        /// </summary>
        public string FacultyName
        {
            get
            {
                return facultyName;
            }
        }

        /// <summary>
        /// Gets or sets the Course ID.
        /// </summary>
        public string CourseID
        {
            get
            {
                return courseID;
            }
        }

        /// <summary>
        /// Gets or sets the Course name.
        /// </summary>
        public string CourseName
        {
            get
            {
                return courseName;
            }
        }

        /// <summary>
        /// Gets or sets the Mode of Learning ID.
        /// </summary>
        public string ModeLrnID
        {
            get
            {
                return modeLrnID;
            }
        }

        /// <summary>
        /// Gets or sets the Course pattern ID.
        /// </summary>
        public string PatternID
        {
            get
            {
                return patternID;
            }
        }

        /// <summary>
        /// Gets or sets the Branch ID.
        /// </summary>
        public string BranchID
        {
            get
            {
                return branchID;
            }
        }

        /// <summary>
        /// Gets or sets the Branch name.
        /// </summary>
        public string BranchName
        {
            get
            {
                return branchName;
            }
        }

        /// <summary>
        /// Gets or sets the Course part ID.
        /// </summary>        
        public string PartID
        {
            get
            {
                return partID;
            }

        }

        /// <summary>
        /// Gets or sets the Course part name.
        /// </summary>        
        public string PartName
        {
            get
            {
                return partName;
            }
        }

        /// <summary>
        /// Gets or sets the Course part Term ID.
        /// </summary>
        public string TermID
        {
            get
            {
                return termID;
            }
        }

        /// <summary>
        /// Gets or sets the Course part Term name.
        /// </summary>
        public string TermName
        {
            get
            {
                return termName;
            }
        }

        /// <summary>
        /// Gets or sets the AcademicYearID.
        /// </summary>
        public string AcademicYearID
        {
            get
            {
                return ddlAcadYear.SelectedValue;
            }
        }

        /// <summary>
        /// Gets or sets the AcademicYear.
        /// </summary>
        public string AcademicYear
        {
            get
            {
                return academicYear;
            }
        }

        /// <summary>
        /// Gets the Regional Center ID.
        /// </summary>
        public string RegionalCenterID
        {
            get
            {
                return regionalCenterID;

            }
        }
        /// <summary>
        /// Gets the Regional Center Name.
        /// </summary>
        public string RegionalCenterName
        {
            get
            {
                return regionalCenterName;

            }
        }
        /// <summary>
        /// Gets the Regional Center Code.
        /// </summary>
        public string RegionalCenterCode
        {
            get
            {
                return regionalCenterCode;

            }
        }
        /// <summary>
        /// Gets the Regional Center Name.
        /// </summary>
        public string RegionalCenterCity
        {
            get
            {
                return regionalCenterCity;

            }
        }
        /// <summary>
        /// Gets the Study Center ID.
        /// </summary>
        public string StudyCenterID
        {
            get
            {
                return studyCenterID;

            }
        }
        /// <summary>
        /// Gets the Study Center Name.
        /// </summary>
        public string StudyCenterName
        {
            get
            {
                return studyCenterName;

            }
        }
        /// <summary>
        /// Gets the Study Center Code.
        /// </summary>
        public string StudyCenterCode
        {
            get
            {
                return studyCenterCode;

            }
        }

        /// <summary>
        /// Gets or sets the page title.
        /// </summary>
        public string PageTitle
        {
            get
            {
                return pageTitle;
            }
        }

        /// <summary>
        /// Gets the Selected Course String.
        /// </summary>
        public string CourseSelectedString
        {
            get
            {
                return selectedCourseString;
            }
        }

        /// <summary>
        /// Gets the Selected String related to Gender, State etc.
        /// </summary>
        public string OtherSelectedString
        {
            get
            {
                return selectedOtherString;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display faculty selection control.
        /// </summary>
        public bool IsFacultyDisplay
        {
            get
            {
                return isFacultyDisplay;
            }

            set
            {
                isFacultyDisplay = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display course selection control
        /// </summary>
        public bool IsCourseDisply
        {
            get
            {
                return isCourseDisplay;
            }

            set
            {
                isCourseDisplay = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display branch selection control
        /// </summary>
        public bool IsBranchDisply
        {
            get
            {
                return isBranchDisplay;
            }

            set
            {
                isBranchDisplay = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display course part selection control
        /// </summary>
        public bool IsCoursePartDisply
        {
            get
            {
                return isCoursePartDisplay;
            }

            set
            {
                isCoursePartDisplay = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display course part term selection control
        /// </summary>
        public bool IsCourseTermDisply
        {
            get
            {
                return isCourseTermDisplay;
            }

            set
            {
                isCourseTermDisplay = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display User and Date selection control
        /// </summary>
        public bool IsReportUserAndDateDisplay
        {
            get
            {
                return isReportUserAndDateDisplay;
            }

            set
            {
                isReportUserAndDateDisplay = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display Institute selection control
        /// </summary>
        public bool IsInstituteDisplay
        {
            get
            {
                return isInstituteDisplay;
            }

            set
            {
                isInstituteDisplay = value;
            }
        }

        public bool IsAcYrDisplay
        {
            get
            {
                return isAcYrDisplay;
            }

            set
            {
                isAcYrDisplay = value;
            }
        }


        public bool IsCollegeLogin
        {
            get
            {
                return isCollegeLogin;
            }

            set
            {
                isCollegeLogin = value;
            }
        }
        

        #endregion


        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            btnProceed.Enabled = true;

            //----------------------------------------------
            hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            //----------------------------------------------

            if (clsGetSettings.OpenUniversity == "Yes")
            {
                isRegionalCenterVisible = true;
               if (isPageNameAdmissionEligConfiguration.Value.Equals("Yes"))
                   isRegionalCenterVisible = false;
            }

            //if (isDiscRpt.Value.Equals("Yes"))
            //{
            //    trTerm.Style.Add("display", "none");
            //    trMsg.Style.Add("display", "none");
            //    trCrPrChoice.Style.Add("display", "none");
            //}

            Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent), this.Page);


            if (!IsPostBack)
            {               

                hidIsNoTermMsgShown.Value = string.Empty;
                hidIsTermCBFilled.Value = string.Empty;

                if (isRegionalCenterVisible)
                {
                    ////This will Fill Regional Center Drop Down
                    FillRegionalCenter();
                }
                else
                {
                    FillInstitute();
                }

                if (!IsInstituteDisplay)
                {
                    FillFaculty();
                }

                ////This will Fill Academic Year Drop Down
                FillAcademicYear();

                ////Call for Displaying Data from Session
                DisplyFromSession();
                setSelectionDisplay();

                ddlAcadYear.Focus();

                if (isReportUserAndDateDisplay)
                {
                    divReportDisp.Visible = true;
                    DivUser.Visible = true;
                    DivDate.Visible = false;

                    ////This will Fill Data Entry User Drop Down
                    //FillDataEntryUser();
                }
                else
                {
                    divReportDisp.Visible = false;
                }

                

                RetainDiscTermsOnPostback();
            }


            #region calling function to fill tooltip
            if (isRegionalCenterVisible)
            {
                FillOnlyToolTip(ddlRegionalCenter);
            }

            FillOnlyToolTip(ddlStudyCenter);
            FillOnlyToolTip(ddlAcadYear);

            if (isFacultyDisplay)
            {
                FillOnlyToolTip(ddlFaculty);
            }
            if (isCourseDisplay)
            {
                FillOnlyToolTip(ddlCourse);
            }
            if (isBranchDisplay)
            {
                FillOnlyToolTip(ddlBranch);
            }
            if (isCoursePartDisplay)
            {
                FillOnlyToolTip(ddlPart);
            }
            if (isCourseTermDisplay)
            {
                FillOnlyToolTip(ddlTerm);
            }

            if (isReportUserAndDateDisplay)
            {
                FillOnlyToolTip(ddlUser);
            }
            #endregion

            #region Show Hide Resgional and Study Center Selection

            if (IsInstituteDisplay)
            {
                divStudyCenter.Attributes.Add("style", "display:none");
            }
            else
            {
                divStudyCenter.Attributes.Add("style", "display:inline");
            }
            if (IsAcYrDisplay) 
            {
                divAcadYear.Attributes.Add("style", "display:inline");
            }
            else
            {
                divAcadYear.Attributes.Add("style", "display:none");
            }

            if (isRegionalCenterVisible)
            {
                if (IsCollegeLogin)
                {
                    //********************************
                    user = (clsUser)Session["User"];
                    if (user.UserTypeCode == "2")
                    {
                        StrRegionalCenterLoginID = user.UserReferenceID;

                    }
                    isRegionalCenterLogin = "False";
                    oRegionalStudyCenter = new clsRegionalStudyCenter();
                    oDTRegCenters = oRegionalStudyCenter.listRegionalCenter();
                    for (int i = 0; i < oDTRegCenters.Rows.Count; i++)
                    {
                        if (StrRegionalCenterLoginID == oDTRegCenters.Rows[i].ItemArray[1].ToString())
                        {
                            isRegionalCenterLogin = "True";
                            break;
                        }
                    }

                    divRegionalCenter.Attributes.Add("style", "display:none");
                    if (isRegionalCenterLogin == "True")
                    {
                        ChkAllRegionalCenter.Checked = false;
                        divStudyCenter.Attributes.Add("style", "display:inline");

                        isFacultyDisplay = true;
                        isCourseDisplay = true;
                        isCoursePartDisplay = true;
                        
                        if (isDiscRpt.Value.Equals("Yes"))
                            isCourseTermDisplay = false;
                        else
                            isCourseTermDisplay = true;
                        
                        isBranchDisplay = true;

                        if (!IsPostBack)
                        {
                            fillStudyCenter(StrRegionalCenterLoginID);
                            setSelectionDisplay();
                        }
                    }
                    else
                    {
                        divStudyCenter.Attributes.Add("style", "display:none");
                    }

                    //********************************

                    //divRegionalCenter.Attributes.Add("style", "display:none");
                    //divStudyCenter.Attributes.Add("style", "display:none");
                }

                //*******************************************
                //if (ChkAllRegionalCenter.Checked == true)
                //*******************************************
                if (ChkAllRegionalCenter.Checked == true || isRegionalCenterLogin == "False")
                {
                    dvSelectRC.Attributes.Add("style", "display:none");
                    divStudyCenter.Attributes.Add("style", "display:none");
                    dvSelectSC.Attributes.Add("style", "display:none");
                }
                else
                {
                    dvSelectRC.Attributes.Add("style", "display:inline");
                    divStudyCenter.Attributes.Add("style", "display:inline");
                    if (ChkAllStudyCenter.Checked == true)
                    {
                        dvSelectSC.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        dvSelectSC.Attributes.Add("style", "display:inline");
                    }
                }

                

            }
            else
            {
                divRegionalCenter.Attributes.Add("style", "display:none");
                if (ChkAllStudyCenter.Checked == true)
                {
                    dvSelectSC.Attributes.Add("style", "display:none");
                }
                else
                {
                    dvSelectSC.Attributes.Add("style", "display:inline");
                }
                if (IsCollegeLogin)
                {
                    divRegionalCenter.Attributes.Add("style", "display:none");
                    divStudyCenter.Attributes.Add("style", "display:none");
                }
            }

            //added by Deboshree
            if (isMISRpt.Value.Equals("Yes"))
            {
                divStudyCenter.Attributes.Add("style", "display:none");
            }
            if (isDiscRpt.Value.Equals("Yes"))
            {
                divStudyCenter.Attributes.Add("style", "display:none");
            }
            if (isPpChange.Value.Equals("Yes"))
            {
                divPRN.Attributes.Add("style", "display:inline;width:700px");
                divElgFormNo.Attributes.Add("style", "display:inline;width:700px");
                divAppFormNo.Attributes.Add("style", "display:inline;width:700px");
                divOR.Attributes.Add("style", "display:inline;");
                divOR1.Attributes.Add("style", "display:inline;");
                divNoteApplicationformNo.Attributes.Add("style", "display:inline;width:700px");

                 DateTime date = DateTime.ParseExact(this.Session["AcademicYearFrom"].ToString(), "dd/MM/yyyy", null);
                  int FormYear = Convert.ToInt32(date.Year);

                 DateTime date1 = DateTime.ParseExact(this.Session["AcademicYearTo"].ToString(), "dd/MM/yyyy", null);
                 int ToYear = Convert.ToInt32(date1.Year);

                 lblAcademicYear.Text = FormYear + " To " + ToYear;
            }
            //end add


            // Pawan 

            if (isPageNameAdmissionEligConfiguration.Value.Equals("Yes"))
            {
                divStudyCenter.Attributes.Add("style", "display:none");
            }
            //added by Pankaj on 22/03/2011
            //modified  by shafik on 09-oct-2012  added new hidden  as need to hide the academic year on paperchange and paper excemption approlval page
            if (hidIsAcdYrDdNotVisible.Value.Equals("Yes"))
            {
                
                divAcadYear.Attributes.Add("style", "display:none");
            }
            //======================================
            #endregion
            user = (clsUser)Session["User"];
            if (user.UserTypeCode == "2")
            {
                hid_Institute_ID.Value = user.UserReferenceID;

            }
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

        #region Function to add tool tip to dropdown
        public void FillOnlyToolTip(DropDownList ddl)
        {
            foreach (ListItem li in ddl.Items)
            {
                li.Attributes.Add("title", li.Text);
            }
        }
        #endregion

        #region FillRegionalCenter
        /// <summary>
        /// Filling dropdown for Regional Centers
        /// </summary>        
        private void FillRegionalCenter()
        {
            oDT = new DataTable();
            oRegionalStudyCenter = new clsRegionalStudyCenter();
            oDT = oRegionalStudyCenter.listRegionalCenter();
            oCommon = new clsCommon();
            oCommon.fillDropDown(ddlRegionalCenter, oDT, "", "Text", "Value", "---- Select ----");
            if (oCommon != null) oCommon = null;
        }

        #endregion

        #region Fill Study Center based  upon Regional Center

        private void fillStudyCenter(string sRegionalCenterID)
        {
            oDT = new DataTable();
            oCommon = new clsCommon();
            oRegionalStudyCenter = new clsRegionalStudyCenter();
            oDT = oRegionalStudyCenter.listStudyCenter(sRegionalCenterID);
            if (oDT.Rows.Count > 0 && oDT != null)
            {
                oCommon.fillDropDown(ddlStudyCenter, oDT, "", "Text", "Value", "--- Select ---");
                FillOnlyToolTip(ddlStudyCenter);
            }
        }

        #endregion

        #region Fill institute based upon university
        private void FillInstitute()
        {
            oDT = new DataTable();
            oDT = oInstituteRepository.InstituteSearch(pk_Uni_ID, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

            oCommon = new clsCommon();
            if (oDT.Rows.Count > 0 && oDT != null)
            {
                oCommon.fillDropDown(ddlStudyCenter, oDT, "0", "Text", "Value", "---- Select ----");
                FillOnlyToolTip(ddlStudyCenter);
            }
        }
        #endregion

        #region ddlRegionalCenter_SelectedIndexChanged
        protected void ddlRegionalCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRegionalCenter.SelectedValue.ToString() != "0")
            {
                fillStudyCenter(Convert.ToString(ddlRegionalCenter.SelectedItem.Value));
            }
            else
            {
                ddlStudyCenter.Items.Clear();
                ListItem Li = new ListItem();
                Li.Text = "--- Select ---";
                Li.Value = "0";
                ddlStudyCenter.Items.Add(Li);
            }

            txtCenterCode.Text = string.Empty;
            if (isDiscRpt.Value.Equals("Yes"))
                RetainDiscTermsOnPostback();
            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlRegionalCenter);
        }
        #endregion

        #region ChkAllRegionalCenter_CheckedChanged
        protected void ChkAllRegionalCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAllRegionalCenter.Checked)
            {
                ddlRegionalCenter.SelectedValue = "0";
            }

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ChkAllRegionalCenter);
        }
        #endregion

        #region ChkAllStudyCenter_CheckedChanged
        protected void ChkAllStudyCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAllStudyCenter.Checked)
            {
                //showing all fields for the case when we return from selected isntitute view
                //handling for uploaded statistics report
                if (isUSRpt.Value.Equals("Yes"))
                {
                    isFacultyDisplay = true;
                    isCourseDisplay = true;
                    isCoursePartDisplay = true;
                    isCourseTermDisplay = true;
                    isBranchDisplay = true;
                    IsReportUserAndDateDisplay = false;
                    setSelectionDisplay();
                }

                ddlStudyCenter.Items.Clear();
                ListItem Li = new ListItem();
                Li.Text = "---- Select ----";
                Li.Value = "0";
                ddlStudyCenter.Items.Add(Li);

                txtCenterCode.Text = string.Empty;
                ddlFaculty.Items.Clear();
                ddlCourse.Items.Clear();
                ddlBranch.Items.Clear();
                ddlPart.Items.Clear();
                ddlTerm.Items.Clear();

                ddlFaculty.Items.Insert(0, new ListItem("---- Select ----", "0"));
                ddlCourse.Items.Insert(0, new ListItem("---- Select ----", "0"));
                ddlBranch.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                ddlPart.Items.Insert(0, new ListItem("---- Select ----", "0"));
                ddlTerm.Items.Insert(0, new ListItem("---- Select ----", "0"));

                pk_Institute_ID = string.Empty;
                ////This will Fill Faculty Drop Down
                Session["SC_ID"] = null;
                hid_Institute_ID.Value = "";
                FillFaculty();

            }
            else
            {
                if (isRegionalCenterVisible)
                {
                    if (ddlRegionalCenter.SelectedValue.ToString() != "0")
                    {
                        fillStudyCenter(Convert.ToString(ddlRegionalCenter.SelectedItem.Value));
                    }
                    //****************
                    else if (isRegionalCenterLogin == "True")
                    {
                        fillStudyCenter(StrRegionalCenterLoginID);
                    }
                    //******************
                    else
                    {
                        ddlStudyCenter.Items.Clear();
                        ListItem Li = new ListItem();
                        Li.Text = "---- Select ----";
                        Li.Value = "0";
                        ddlStudyCenter.Items.Add(Li);
                    }
                }
                else
                {
                    FillInstitute();
                }
            }

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ChkAllStudyCenter);
        }
        #endregion

        #region ChkSelectedStudyCenter_CheckedChanged
        protected void ChkSelectedStudyCenter_CheckedChanged(object sender, EventArgs e)
        {
            ddlFaculty.Items.Clear();
            ddlCourse.Items.Clear();
            ddlBranch.Items.Clear();
            ddlPart.Items.Clear();
            ddlTerm.Items.Clear();

            ddlFaculty.Items.Insert(0, new ListItem("---- Select ----", "0"));
            ddlCourse.Items.Insert(0, new ListItem("---- Select ----", "0"));
            ddlBranch.Items.Insert(0, new ListItem("---- Select ----", "-1"));
            ddlPart.Items.Insert(0, new ListItem("---- Select ----", "0"));
            ddlTerm.Items.Insert(0, new ListItem("---- Select ----", "0"));

            if (ChkSelectedStudyCenter.Checked)
            {
                if (isRegionalCenterVisible)
                {
                    //****************************
                    if (isRegionalCenterLogin == "True")
                    {
                        //dvSelectSC.Attributes.Add("style", "display:inline");
                        regionalCenterID = StrRegionalCenterLoginID;
                        fillStudyCenter(regionalCenterID);
                    }
                    //***************************
                    else if (ddlRegionalCenter.SelectedValue.ToString() != "0")
                    {
                        fillStudyCenter(Convert.ToString(ddlRegionalCenter.SelectedItem.Value));
                    }
                    else
                    {
                        ddlStudyCenter.Items.Clear();
                        ListItem Li = new ListItem();
                        Li.Text = "---- Select ----";
                        Li.Value = "0";
                        ddlStudyCenter.Items.Add(Li);
                    }
                }
                else
                {
                    FillInstitute();
                }

                //handling for uploaded statistics report
                if (isUSRpt.Value.Equals("Yes") || isPaperExemption.Value.Equals("Yes"))
                {
                    isFacultyDisplay = false;
                    isCourseDisplay = false;
                    isCoursePartDisplay = false;
                    isCourseTermDisplay = false;
                    isBranchDisplay = false;
                    IsReportUserAndDateDisplay = false;
                    setSelectionDisplay();
                }
            }

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ChkSelectedStudyCenter);
        }
        #endregion

        #region ddlStudyCenter_SelectedIndexChanged
        protected void ddlStudyCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCenterCode.Text = string.Empty;
            ddlFaculty.Items.Clear();
            ddlCourse.Items.Clear();
            ddlBranch.Items.Clear();
            ddlPart.Items.Clear();
            ddlTerm.Items.Clear();

            if (ddlStudyCenter.SelectedValue.ToString() != "0")
            {
                if (isRegionalCenterVisible)
                {
                    pk_Institute_ID = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim());
                    hid_Institute_ID.Value = pk_Institute_ID;

                }
                else
                {
                    pk_Institute_ID = Convert.ToString(ddlStudyCenter.SelectedItem.Value);
                    hid_Institute_ID.Value = pk_Institute_ID;
                }

                ////This will Fill Faculty Drop Down
                FillFaculty();
                if (Convert.ToInt16(ddlStudyCenter.SelectedItem.Text.IndexOf('[')) == 0 && Convert.ToInt16(ddlStudyCenter.SelectedItem.Text.IndexOf(']')) > 0)
                {
                    string CenterCode = Convert.ToString(ddlStudyCenter.SelectedItem.Text.Split('[')[1].Trim());
                    CenterCode = CenterCode.Split(']')[0].Trim();
                    txtCenterCode.Text = CenterCode;
                }
            }

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlStudyCenter);
        }

        #endregion

        #region ProceedButtonClick
        /// <summary>
        /// Proceed button click event
        /// </summary>
        /// <param name="sender">Event Source</param>
        /// <param name="e">Event Arguments</param>
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (isReportUserAndDateDisplay)
            {
                oDT = new DataTable();
                oDT = (DataTable)ViewState["AcademicYear"];
                DataView odv = oDT.DefaultView;
                odv.RowFilter = "pk_AcademicYear_ID =" + ddlAcadYear.SelectedValue;
                if (odv.Count > 0)
                {
                    hid_AcademicYearFrom.Value = odv[0]["StartDate"].ToString();
                    hid_AcademicYearTo.Value = odv[0]["EndDate"].ToString();
                }

                if (Convert.ToString(ddlUser.SelectedItem.Value) != "0")
                {
                    sUserID = Convert.ToString(ddlUser.SelectedItem.Value);
                    sUserName = Convert.ToString(ddlUser.SelectedItem.Text);
                }
                else
                {
                    sUserID = string.Empty;
                    sUserName = "All";
                }
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    sDateFrom = txtFrom.Text;
                    sDateTo = txtTo.Text;
                }
            }

            ////Call for Setting FacultyID , CourseID ,MoLrnID and PatternID  

            //added by Deboshree
            if (isUSRpt.Value.Equals("Yes"))
            {
                if (ddlCourse.SelectedIndex != 0)
                {
                    getFacCrMoLrnPtrnID();
                }
            }
            else
            {
                getFacCrMoLrnPtrnID();


                if (isFacultyDisplay)
                {
                    if (ddlFaculty.SelectedValue != "0")
                    {
                        facultyName = Convert.ToString(ddlFaculty.SelectedItem.Text);
                    }
                    else
                    {
                        facultyName = "All";
                    }
                }

                if (isCourseDisplay)
                {
                    if (ddlCourse.SelectedValue != "0")
                    {
                        courseName = Convert.ToString(ddlCourse.SelectedItem.Text);
                    }
                    else
                    {
                        courseName = "All";
                    }
                }

                branchID = Convert.ToString(ddlBranch.SelectedValue);

                ////This "IF" condition will check whether the branch is available for course and according to that set the branch name.
                if (isBranchDisplay)
                {
                    if (branchID == "-1")
                    {
                        if (ddlBranch.SelectedItem.Text == "---- All ----")
                        {
                            branchName = "All";
                        }
                    }
                    else if (branchID == "0")
                    {
                        branchName = "";
                    }
                    else
                    {
                        branchName = " - " + Convert.ToString(ddlBranch.SelectedItem.Text);
                    }
                }

                partID = Convert.ToString(ddlPart.SelectedValue);
                if (isCoursePartDisplay)
                {
                    if (partID != "0")
                    {
                        partName = Convert.ToString(ddlPart.SelectedItem.Text);
                    }
                    else
                    {
                        partName = "All";
                    }
                }

                termID = Convert.ToString(ddlTerm.SelectedValue);
                if (isCourseTermDisplay)
                {
                    if (termID != "0")
                    {
                        termName = Convert.ToString(ddlTerm.SelectedItem.Text);
                    }
                    else
                    {
                        termName = "All";
                    }
                }

                academicYearID = Convert.ToString(ddlAcadYear.SelectedItem.Value);
                academicYear = Convert.ToString(ddlAcadYear.SelectedItem.Text);

                if (ddlFaculty.SelectedItem.Text != "---- All ----")
                {
                    pageTitle = courseName + branchName + " - " + partName + " - " + termName + " - For Year - " + academicYear;
                }
                else
                {
                    pageTitle = "All Courses " + " - For Year - " + academicYear;
                }

                if (isRegionalCenterVisible)
                {
                    if (ChkAllRegionalCenter.Checked)
                    {
                        //*****************************************
                        if (isRegionalCenterLogin == "True")
                        {
                            regionalCenterID = StrRegionalCenterLoginID;
                            oDT = new DataTable();
                            oDT = oInstituteRepository.InstituteDetails(pk_Uni_ID, regionalCenterID);
                            if (oDT.Rows.Count > 0)
                            {
                                regionalCenterName = Convert.ToString(oDT.Rows[0]["Inst_Name"]);
                                regionalCenterCode = Convert.ToString(oDT.Rows[0]["Inst_Code"]);
                                regionalCenterCity = Convert.ToString(oDT.Rows[0]["Inst_City"]);
                            }
                        }
                        //******************************************
                        else
                        {
                            regionalCenterID = string.Empty;
                            regionalCenterName = "All";
                            regionalCenterCode = "All";
                            regionalCenterCity = "All";
                        }
                    }
                    else
                    {
                        regionalCenterID = Convert.ToString(ddlRegionalCenter.SelectedItem.Value);
                        oDT = new DataTable();
                        oDT = oInstituteRepository.InstituteDetails(pk_Uni_ID, regionalCenterID);
                        if (oDT.Rows.Count > 0)
                        {
                            regionalCenterName = Convert.ToString(oDT.Rows[0]["Inst_Name"]);
                            regionalCenterCode = Convert.ToString(oDT.Rows[0]["Inst_Code"]);
                            regionalCenterCity = Convert.ToString(oDT.Rows[0]["Inst_City"]);
                        }
                    }
                    if (ChkAllStudyCenter.Checked)
                    {
                        studyCenterID = string.Empty;
                        studyCenterName = "All";
                        studyCenterCode = "All";
                    }
                    else
                    {
                        if (ddlStudyCenter.SelectedValue.ToString() != "0")
                        {
                            studyCenterID = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim());
                            studyCenterCode = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[1].Trim());
                            studyCenterName = ddlStudyCenter.SelectedItem.Text.Trim();

                        }
                    }
                }
                else
                {

                    if (ChkAllStudyCenter.Checked)
                    {
                        pk_Institute_ID = string.Empty;
                        instName = "All";

                    }
                    else
                    {
                        if (ddlStudyCenter.SelectedValue.ToString() != "0")
                        {
                            pk_Institute_ID = ddlStudyCenter.SelectedValue.ToString();
                            instName = ddlStudyCenter.SelectedItem.Text.ToString();
                        }
                    }
                    if (isCourseDisplay == true)
                    {
                        ConstrctCourseString();
                    }
                }

            }
            ConstrctOtherString();


            ////Call for Memorising value of DropDowns in Session.
            MemorizeInSession();

            //
            //Call for Server Side Validations
            //
            if (!ServerSideValidations())
            {
                return;
            }

            ////Explicitly fire the event
            if (OnProceedClick != null)
            {
                OnProceedClick(sender, e);
            }

            //ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            //HtmlControl cntrl = (HtmlControl)Cntp.FindControl("divNoteToViewStudents");
            //if (cntrl != null)
            //    cntrl.Style.Add("display", "block");

        }

        #endregion

        #region Selected Index Change Events to fill dependent Drop Down Box
        /// <summary>
        /// Academic year dropdownlist selected index changed event
        /// </summary>
        /// <param name="sender">Event Source</param>
        /// <param name="e">Event Arguments</param>
        protected void ddlAcadYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlAcadYear.SelectedValue) != "0")
            {
                if (isReportUserAndDateDisplay)
                {
                    oDT = new DataTable();
                    oDT = (DataTable)ViewState["AcademicYear"];
                    DataView odv = oDT.DefaultView;
                    odv.RowFilter = "pk_AcademicYear_ID =" + ddlAcadYear.SelectedValue;
                    if (odv.Count > 0)
                    {
                        hid_AcademicYearFrom.Value = odv[0]["StartDate"].ToString();
                        hid_AcademicYearTo.Value = odv[0]["EndDate"].ToString();
                    }
                }
            }
            if (Convert.ToString(ddlTerm.SelectedValue) != "0")
            {
                if (Convert.ToString(ddlTerm.SelectedValue) != "-1")
                {
                    ////Call for Seting FacultyID , CourseID ,MoLrnID and PatternID
                    getFacCrMoLrnPtrnID();
                }
            }
            if (isDiscRpt.Value.Equals("Yes"))
                RetainDiscTermsOnPostback();
            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlAcadYear);
        }

        //retaining term portion on postback - Disc report
        private void RetainDiscTermsOnPostback()
        {
            //added by Deboshree
            if (hidIsTermCBFilled.Value.Equals("Yes"))
            {
                trCrPrChoice.Style.Add("display", "block");
                trTerm.Style.Add("display", "block");
                trMsg.Style.Add("display", "none");
            }
            else if (hidIsNoTermMsgShown.Value.Equals("Yes"))
            {
                trCrPrChoice.Style.Add("display", "none");
                trTerm.Style.Add("display", "none");
                trMsg.Style.Add("display", "block");
            }
        }

        /// <summary>
        /// Faculty dropdownlist selected index changed event
        /// </summary>
        /// <param name="sender">Event Source</param>
        /// <param name="e">Event Arguments</param>
        protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-----------------------------
            hidFacID.Value = ddlFaculty.SelectedValue;
            //-----------------------------

            ddlBranch.Items.Clear();
            ddlPart.Items.Clear();

            if (isDiscRpt.Value.Equals("Yes"))
            {
                trTerm.Style.Add("display", "none");
                trMsg.Style.Add("display", "none");
                trCrPrChoice.Style.Add("display", "none");
                hidIsTermCBFilled.Value = string.Empty;
                hidIsNoTermMsgShown.Value = string.Empty;
            }

            ddlTerm.Items.Clear();

            if (ChkSelectedStudyCenter.Checked == true)
            {
                if (isRegionalCenterVisible)
                {
                     hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim());

                }
                else
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value);
                }
            }

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0")
            {
                if (ddlFaculty.SelectedItem.Text == "---- All ----")
                {
                    ddlBranch.Items.Insert(0, new ListItem("---- All ----", "-1"));
                    ddlPart.Items.Insert(0, new ListItem("---- All ----", "0"));
                    ddlTerm.Items.Insert(0, new ListItem("---- All ----", "0"));
                }
                else
                {
                    ddlBranch.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                    ddlPart.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                    ddlTerm.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                }
            }
            else
            {
                ddlBranch.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                ddlPart.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                ddlTerm.Items.Insert(0, new ListItem("---- Select ----", "-1"));
            }


            ////This will Fill Faculty,Course,Mode of Learning and Pattern in single Drop Down            
            FillFacultyCourseMoLrnPatternName(pk_Uni_ID, hid_Institute_ID.Value, ddlFaculty.SelectedValue);

        }

        /// <summary>
        /// Course dropdownlist selected index changed event
        /// </summary>
        /// <param name="sender">Event Source</param>
        /// <param name="e">Event Arguments</param>
        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPart.Items.Clear();
            ddlTerm.Items.Clear();

            if (isDiscRpt.Value.Equals("Yes"))
            {
                trTerm.Style.Add("display", "none");
                trMsg.Style.Add("display", "none");
                trCrPrChoice.Style.Add("display", "none");
                hidIsTermCBFilled.Value = string.Empty;
                hidIsNoTermMsgShown.Value = string.Empty;
            }

            if (ChkSelectedStudyCenter.Checked == true)
            {
                if (isRegionalCenterVisible)
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim());

                }
                else
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value);
                }
            }

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0")
            {
                if (ddlCourse.SelectedItem.Text != "---- All ----")
                {
                    ddlPart.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                    ddlTerm.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                }
                else
                {
                    ddlPart.Items.Insert(0, new ListItem("---- All ----", "0"));
                    ddlTerm.Items.Insert(0, new ListItem("---- All ----", "0"));
                }
            }
            else
            {
                ddlPart.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                ddlTerm.Items.Insert(0, new ListItem("---- Select ----", "-1"));
            }

            ////Call for Seting FacultyID , CourseID ,MoLrnID and PatternID
            getFacCrMoLrnPtrnID();

            //-----------------------------------
            hidCrID.Value = courseID;
            hidMoLrnID.Value = modeLrnID;
            hidPtrnID.Value = patternID;
            //-----------------------------------

            ////This will Fill Correspondance Branch Drop Down           
            FillBranch(pk_Uni_ID, hid_Institute_ID.Value, facultyID, courseID, modeLrnID, patternID);

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCourse);
        }

        /// <summary>
        /// Branch dropdownlist selected index changed event
        /// </summary>
        /// <param name="sender">Event Source</param>
        /// <param name="e">Event Arguments</param>
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-----------------------------
            hidBrnID.Value = ddlBranch.SelectedValue;
            //-----------------------------

            ddlTerm.Items.Clear();

            if (isDiscRpt.Value.Equals("Yes"))
            {
                trTerm.Style.Add("display", "none");
                trMsg.Style.Add("display", "none");
                trCrPrChoice.Style.Add("display", "none");
                hidIsTermCBFilled.Value = string.Empty;
                hidIsNoTermMsgShown.Value = string.Empty;
            }

            if (ChkSelectedStudyCenter.Checked == true)
            {
                if (isRegionalCenterVisible)
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim());

                }
                else
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value);
                }
            }

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0")
            {
                ddlTerm.Items.Insert(0, new ListItem("---- All ----", "0"));
            }
            else
            {
                ddlTerm.Items.Insert(0, new ListItem("---- Select ----", "-1"));
            }

            ////Call for Seting FacultyID , CourseID ,MoLrnID and PatternID
            getFacCrMoLrnPtrnID();

            ////This will Fill Correspondance Course Part Details Drop Down           
            FillCoursePart(pk_Uni_ID, hid_Institute_ID.Value, facultyID, courseID, modeLrnID, patternID, Convert.ToString(ddlBranch.SelectedValue));

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlBranch);
        }

        /// <summary>
        /// Course part dropdownlist selected index changed event
        /// </summary>
        /// <param name="sender">Event Source</param>
        /// <param name="e">Event Arguments</param>
        protected void ddlPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Call for Seting FacultyID , CourseID ,MoLrnID and PatternID
            getFacCrMoLrnPtrnID();

            if (isDiscRpt.Value.Equals("Yes"))
            {
                trTerm.Style.Add("display", "none");
                trMsg.Style.Add("display", "none");
                trCrPrChoice.Style.Add("display", "none");
                hidIsTermCBFilled.Value = string.Empty;
                hidIsNoTermMsgShown.Value = string.Empty;
            }

            ////This will Fill Correspondance Course Part Term Details Drop Down            
            FillPartTerm(pk_Uni_ID, hid_Institute_ID.Value, facultyID, courseID, modeLrnID, patternID, Convert.ToString(ddlBranch.SelectedItem.Value), Convert.ToString(ddlPart.SelectedItem.Value));
            if (isDiscRpt.Value.Equals("Yes"))
            {
                chkChild.Items.Clear();
                divDiscTerms.Style.Add("display", "inline");
                if (ddlTerm.Items.Count > 2) //one item will be 'select' and there should be min. 2 other items
                {
                    foreach (ListItem li in ddlTerm.Items)
                    {
                        if (li.Value != "-1")
                            chkChild.Items.Add(new ListItem(li.Text, li.Value));
                    }
                    hidIsTermCBFilled.Value = "Yes";
                    trTerm.Style.Add("display", "block");
                    trCrPrChoice.Style.Add("display", "block");
                    trMsg.Style.Add("display", "none");
                    btnProceed.Enabled = true;
                }
                else
                {
                    hidIsNoTermMsgShown.Value = "Yes";
                    trTerm.Style.Add("display", "none");
                    trCrPrChoice.Style.Add("display", "none");
                    trMsg.Style.Add("display", "block");
                    btnProceed.Enabled = false;
                }
            }
           

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlPart);
        }

        #endregion

        #region Function to split FacCrMoLrnPtrnID
        /// <summary>
        /// Spliting the value of Course DropDown into FacultyID , CourseID , MoLrnID and PatternID which are coming combined.
        /// </summary>
        private void getFacCrMoLrnPtrnID()
        {
            if (Convert.ToString(ddlCourse.SelectedValue) != "-1" && isCourseDisplay)
            {
                IDs_List = Convert.ToString(ddlCourse.SelectedValue).Split('-');
                facultyID = Convert.ToString(IDs_List[0]).Trim();
                courseID = Convert.ToString(IDs_List[1]).Trim();
                modeLrnID = Convert.ToString(IDs_List[2]).Trim();
                patternID = Convert.ToString(IDs_List[3]).Trim();
            }
            else
            {
                if (Convert.ToString(ddlCourse.SelectedValue) == "-1")
                {
                    courseID = "0";
                    modeLrnID = "0";
                    patternID = "0";
                }
                facultyID = ddlFaculty.SelectedValue;
            }
        }

        #endregion

        #region Function to Add User's newly selected data in session
        /// <summary>
        /// Function to Add User's newly selected data in session
        /// </summary>
        private void MemorizeInSession()
        {
            Session["RC_All"] = Convert.ToString(ChkAllRegionalCenter.Checked);
            Session["RC_Selected"] = Convert.ToString(ChkSelectedRegionalCenter.Checked);
            //****************************
            if (isRegionalCenterLogin == "True")
            {
                Session["RC_ID"] = StrRegionalCenterLoginID;
            }
            //****************************
            else
            {
                Session["RC_ID"] = Convert.ToString(ddlRegionalCenter.SelectedItem.Value);
            }

            Session["SC_All"] = Convert.ToString(ChkAllStudyCenter.Checked);
            Session["SC_Selected"] = Convert.ToString(ChkSelectedStudyCenter.Checked);

            if (ChkSelectedStudyCenter.Checked == true)
                Session["SC_ID"] = Convert.ToString(ddlStudyCenter.SelectedItem.Value);
            else
            {
                Session["SC_ID"] = null;

                Session["facultyID"] = Convert.ToString(ddlFaculty.SelectedItem.Value);
                Session["BranchID"] = Convert.ToString(ddlBranch.SelectedItem.Value);
                Session["FacCrMoLrnPtrn_ID"] = Convert.ToString(ddlCourse.SelectedItem.Value);
                Session["pk_Brn_ID"] = Convert.ToString(ddlBranch.SelectedItem.Value);
                Session["pk_CrPr_Details_ID"] = Convert.ToString(ddlPart.SelectedItem.Value);
                Session["pk_CrPrCh_ID"] = Convert.ToString(ddlTerm.SelectedItem.Value);
                if (!isPpChange.Value.Equals("Yes"))
                {
                    Session["pk_AcademicYear_ID"] = Convert.ToString(ddlAcadYear.SelectedItem.Value);
                }

                //--------------------------------------------------------
                Session["hidFacID"] = Convert.ToString(hidFacID.Value);
                Session["hidCrID"] = Convert.ToString(hidCrID.Value);
                Session["hidMoLrnID"] = Convert.ToString(hidMoLrnID.Value);
                Session["hidPtrnID"] = Convert.ToString(hidPtrnID.Value);
                Session["hidBrnID"] = Convert.ToString(hidBrnID.Value);
                //--------------------------------------------------------
            }

            //by Deboshree
            hidCrPrChIds.Value = string.Empty;
            hidCrPrChNames.Value = string.Empty;
            foreach (ListItem li in chkChild.Items)
            {
                if (li.Selected)
                {
                    hidCrPrChIds.Value += li.Value + ",";
                    hidCrPrChNames.Value += li.Text + ",";
                }
            }
            hidCrPrChIds.Value = hidCrPrChIds.Value.TrimEnd(',');
            hidCrPrChNames.Value = hidCrPrChNames.Value.TrimEnd(',');
            if (isDiscRpt.Value.Equals("Yes"))
            {
                Session["crprchids"] = Convert.ToString(hidCrPrChIds.Value);
                Session["crprchnames"] = Convert.ToString(hidCrPrChNames.Value);
            }
        }
        #endregion

        #region Function to Display selected data from session
        /// <summary>
        /// Function to Display selected data from session
        /// </summary>
        private void DisplyFromSession()
        {
            if (isRegionalCenterVisible)
            {
                if (Session["RC_All"] != null)
                {
                    if (Session["RC_All"].ToString() == "True")
                    {
                        ChkAllRegionalCenter.Checked = true;
                    }
                    else
                    {
                        ChkAllRegionalCenter.Checked = false;
                    }
                }

                if (Session["RC_Selected"] != null)
                {
                    if (Session["RC_Selected"].ToString() == "True")
                    {
                        ChkSelectedRegionalCenter.Checked = true;
                    }
                    else
                    {
                        ChkSelectedRegionalCenter.Checked = false;
                    }
                }

                if (Session["RC_ID"] != null)
                {
                    ddlRegionalCenter.SelectedValue = Convert.ToString(Session["RC_ID"]);
                    fillStudyCenter(Convert.ToString(ddlRegionalCenter.SelectedItem.Value));
                }
            }


            //if (Session["SC_All"] != null)
            //{
            //    if (Session["SC_All"].ToString() == "True")
            //    {
            //        ChkAllStudyCenter.Checked = true;
            //    }
            //    else
            //    {
            //        ChkAllStudyCenter.Checked = false;
            //    }
            //}

            //if (Session["SC_Selected"] != null)
            //{
            //    if (Session["SC_Selected"].ToString() == "True")
            //    {
            //        ChkSelectedStudyCenter.Checked = true;
            //    }
            //    else
            //    {
            //        ChkSelectedStudyCenter.Checked = false;
            //    }
            //}

            //if (Session["SC_ID"] != null)
            //{
            //    ddlStudyCenter.SelectedValue = Convert.ToString(Session["SC_ID"]);
            //    if (Convert.ToInt16(ddlStudyCenter.SelectedItem.Text.IndexOf('[')) == 0 && Convert.ToInt16(ddlStudyCenter.SelectedItem.Text.IndexOf(']')) > 0)
            //    {
            //        string CenterCode = Convert.ToString(ddlStudyCenter.SelectedItem.Text.Split('[')[1].Trim());
            //        CenterCode = CenterCode.Split(']')[0].Trim();
            //        txtCenterCode.Text = CenterCode;
            //    }
            //}

            // modified condition by shafik on 10-oct-2012 as hidIsAcdYrDdNotVisible  not filled on paper change and paperexemption approval page
            if ((Session["pk_AcademicYear_ID"] != null) && (hidIsAcdYrDdNotVisible.Value!="Yes"))
            {
                ddlAcadYear.SelectedValue = Convert.ToString(Session["pk_AcademicYear_ID"]);

                oDT = new DataTable();
                oDT = (DataTable)ViewState["AcademicYear"];
                DataView odv = oDT.DefaultView;
                odv.RowFilter = "pk_AcademicYear_ID =" + ddlAcadYear.SelectedValue;
                hid_AcademicYearFrom.Value = odv[0]["StartDate"].ToString();
                hid_AcademicYearTo.Value = odv[0]["EndDate"].ToString();
            }

            if (Session["facultyID"] != null && isFacultyDisplay)
            {
                if (Session["facultyID"].ToString() != "-1")
                {
                    //FillFaculty();
                    ddlFaculty.SelectedValue = Convert.ToString(Session["facultyID"]);
                }
            }

            if (Session["FacCrMoLrnPtrn_ID"] != null && isCourseDisplay)
            {
                if (Session["FacCrMoLrnPtrn_ID"].ToString() != "-1")
                {
                    FillFacultyCourseMoLrnPatternName(clsGetSettings.UniversityID, pk_Institute_ID, ddlFaculty.SelectedItem.Value);
                    ddlCourse.SelectedValue = Convert.ToString(Session["FacCrMoLrnPtrn_ID"]);
                    getFacCrMoLrnPtrnID();
                }
            }

            if (Session["pk_Brn_ID"] != null && isBranchDisplay)
            {
                if (Session["pk_Brn_ID"].ToString() != "-1")
                {
                    ////This will Fill Correspondance Branch Drop Down
                    FillBranch(pk_Uni_ID, pk_Institute_ID, facultyID, courseID, modeLrnID, patternID);
                    ddlBranch.SelectedValue = Convert.ToString(Session["pk_Brn_ID"]);
                }
            }

            if (Session["pk_CrPr_Details_ID"] != null && isCoursePartDisplay)
            {
                if (Session["pk_CrPr_Details_ID"].ToString() != "-1")
                {
                    ////This will Fill Correspondance Course Part Details Drop Down
                    FillCoursePart(pk_Uni_ID, pk_Institute_ID, facultyID, courseID, modeLrnID, patternID, Convert.ToString(Session["pk_Brn_ID"]));
                    ddlPart.SelectedValue = Convert.ToString(Session["pk_CrPr_Details_ID"]);

                    ////This will Fill Correspondance Course Part Childs Drop Down
                    FillPartTerm(pk_Uni_ID, pk_Institute_ID, facultyID, courseID, modeLrnID, patternID, Convert.ToString(Session["pk_Brn_ID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]));

                    if (isDiscRpt.Value.Equals("Yes"))
                    {
                        chkChild.Items.Clear();
                        if (ddlTerm.Items.Count > 2)
                        {
                            foreach (ListItem li in ddlTerm.Items)
                            {
                                if (li.Value != "-1")
                                    chkChild.Items.Add(new ListItem(li.Text, li.Value));
                            }

                            divDiscTerms.Style.Add("display", "inline");
                        }
                        trTerm.Style.Add("display", "block");
                        trCrPrChoice.Style.Add("display", "block");
                        trMsg.Style.Add("display", "none");
                    }
                }
            }

            if (Session["pk_CrPrCh_ID"] != null && isCourseTermDisplay)
            {
                if (Session["pk_CrPrCh_ID"].ToString() != "-1")
                {
                    ddlTerm.SelectedValue = Convert.ToString(Session["pk_CrPrCh_ID"]);
                }
            }

            //by Deboshree
            if (isDiscRpt.Value.Equals("Yes"))
            {
                if (Session["crprchids"] != null && Session["crprchnames"] != null)
                {
                    foreach (ListItem li in chkChild.Items)
                    {
                        if (li.Value == Session["crprchids"].ToString().Split(',')[0] || li.Value == Session["crprchids"].ToString().Split(',')[1])
                        {
                            li.Selected = true;
                        }
                    }
                    trTerm.Style.Add("display", "block");
                    trCrPrChoice.Style.Add("display", "block");
                }
            }
            if (isPpChange.Value != "Yes")
            {
                hid_Institute_ID.Value = string.Empty;
            }


            //--------------------------------------------------------
            if(Session["hidFacID"] != null)
                hidFacID.Value = Session["hidFacID"].ToString();
            if (Session["hidCrID"] != null)
                hidCrID.Value = Session["hidCrID"].ToString();
            if (Session["hidMoLrnID"] != null)
                hidMoLrnID.Value = Session["hidMoLrnID"].ToString();
            if (Session["hidPtrnID"] != null)
                hidPtrnID.Value = Session["hidPtrnID"].ToString();
            if (Session["hidBrnID"] != null)
                hidBrnID.Value = Session["hidBrnID"].ToString();
            //--------------------------------------------------------
        }
        #endregion

        #region setSelectionDisplay
        /// <summary>
        /// Function to set controls' visibility 
        /// </summary>
        private void setSelectionDisplay()
        {
            divFaculty.Visible = isFacultyDisplay;
            divCourse.Visible = isCourseDisplay;
            divBranch.Visible = isBranchDisplay;
            divPart.Visible = isCoursePartDisplay;
            divTerm.Visible = isCourseTermDisplay;
            divReportDisp.Visible = isReportUserAndDateDisplay;
        }
        #endregion

        #region ConstrctCourseString
        /// <summary>
        /// Function to create course string from selection
        /// </summary>
        private void ConstrctCourseString()
        {
            if (facultyName != string.Empty)
            {
                selectedCourseString += lblFac.Text + " : " + facultyName + ", ";
            }

            if (courseName != string.Empty)
            {
                selectedCourseString += lblCourse.Text + " : " + courseName + ", ";
            }

            if (branchName != string.Empty && branchName != "No Branch Available")
            {
                selectedCourseString += " Branch : " + branchName + ", ";
            }

            if (partName != string.Empty)
            {
                selectedCourseString += lblPart.Text + " : " + partName + ", ";
            }

            if (termName != "")
            {
                selectedCourseString += lblTerm.Text + " : " + termName + ", ";
            }

            selectedCourseString = selectedCourseString.Substring(0, selectedCourseString.Length - 2);
        }

        #endregion

        #region ConstrctOtherString
        /// <summary>
        /// Function to create display string from selection
        /// </summary>
        private void ConstrctOtherString()
        {
            if (regionalCenterName != string.Empty)
            {
                selectedOtherString += "Regional Center : " + regionalCenterName + ", ";
            }

            if (studyCenterName != string.Empty)
            {
                selectedOtherString += "Study Center : " + studyCenterName + ", ";
            }

            if (instName != string.Empty)
            {
                selectedOtherString += "Institute : " + instName + ", ";
            }

            if (sUserName != string.Empty)
            {
                selectedOtherString += "Data Entry User Name : " + sUserName + ", ";
            }

            if (sDateFrom != string.Empty && sDateTo != string.Empty)
            {
                selectedOtherString += "Date Range : From[" + sDateFrom + "] To [" + sDateTo + "], ";
            }

            selectedOtherString = selectedOtherString.Substring(0, selectedOtherString.Length - 2);
        }
        #endregion

        #region Dependent Dropdown fill methods

        /// <summary>
        /// Filling dropdown for Course Name which is combination of Faculty + Course + ModeOfLearning + Pattern depending on University ID and Institute ID
        /// </summary>
        /// <param name="Uni_ID">University ID</param>
        /// <param name="Inst_ID">Institute ID</param>
        /// <param name="Faculty_ID">Faculty ID</param>
        private void FillFacultyCourseMoLrnPatternName(string Uni_ID, string Inst_ID, string Faculty_ID)
        {
            ddlCourse.Items.Clear();
            oDT = new DataTable();
            oCommon = new clsCommon();
            if (ChkSelectedStudyCenter.Checked == true)
            {
                if (isRegionalCenterVisible)
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim());

                }
                else
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value);
                }

            }

            if (isDiscRpt.Value.Equals("Yes") && isRegionalCenterVisible.Equals(false))
            {
                hid_Institute_ID.Value = string.Empty;
            }

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0")
            {
                oDT = oInstituteRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, hid_Institute_ID.Value, Faculty_ID);
                oCommon.fillDropDown(ddlCourse, oDT, string.Empty, "Text", "Value", "---- Select ----");
                ddlCourse.Items[0].Value = "-1";
            }
            else
            {
                oDT = oCourseRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, Faculty_ID);
                oCommon.fillDropDown(ddlCourse, oDT, string.Empty, "Text", "Value", "---- Select ----");
                ddlCourse.Items[0].Value = "-1";
            }

            FillOnlyToolTip(ddlCourse);

            if (oCommon != null)
            {
                oCommon = null;
            }
        }

        /// <summary>
        /// Filling dropdown for Branch depending on University ID,Institute ID,Faculty ID,Crouse ID,Modeoflearning ID and Pattern ID 
        /// </summary>
        /// <param name="Uni_ID">University ID</param>
        /// <param name="Inst_ID">Institute ID</param>
        /// <param name="Fac_ID">Faculty ID</param>
        /// <param name="Cr_ID">ID of Course</param>
        /// <param name="Molrn_ID">Mode of Learning ID</param>
        /// <param name="Ptrn_ID">Pattern ID</param>   
        private void FillBranch(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID)
        {
            ddlBranch.Items.Clear();
            oDT = new DataTable();
            if (ChkSelectedStudyCenter.Checked == true)
            {
                if (isRegionalCenterVisible)
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim());

                }
                else
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value);
                }

            }

            if (isDiscRpt.Value.Equals("Yes") && isRegionalCenterVisible.Equals(false))
            {
                hid_Institute_ID.Value = string.Empty;
            }

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0")
            {
                oDT = oInstituteRepository.AssignedConfirmedBranches(Uni_ID, hid_Institute_ID.Value, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID);

                if (oDT.Rows.Count > 0)
                {
                    oCommon = new clsCommon();
                    if (oDT.Rows.Count == 1)
                    {
                        if (Convert.ToString(oDT.Rows[0]["Text"]) == "No Branch")
                        {
                            ListItem li = new ListItem();
                            li.Text = "No Branch Available";
                            li.Value = "0";
                            ddlBranch.Items.Add(li);
                            FillCoursePart(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, "0");
                        }
                        else
                        {
                            oCommon.fillDropDown(ddlBranch, oDT, "0", "Text", "Value", "---- Select ----");
                            FillOnlyToolTip(ddlBranch);

                        }
                    }
                    else
                    {
                        oCommon.fillDropDown(ddlBranch, oDT, "0", "Text", "Value", "---- Select ----");
                        FillOnlyToolTip(ddlBranch);
                    }
                    if (oCommon != null)
                    {
                        oCommon = null;
                    }
                }
                else
                {
                    if (ddlCourse.SelectedIndex == 0)
                    {
                        ListItem li = new ListItem();
                        li.Text = "---- Select ----";
                        li.Value = "-1";
                        ddlBranch.Items.Add(li);
                    }
                    else
                    {
                        ListItem li = new ListItem();
                        li.Text = "No Branch Available";
                        li.Value = "0";
                        ddlBranch.Items.Add(li);
                    }
                }
            }
            else
            {
                oDT = oCourseRepository.ListCourseModeOfLearningPatternWiseLaunchedBranches(long.Parse(Uni_ID), long.Parse(Fac_ID), long.Parse(Cr_ID), long.Parse(Molrn_ID), long.Parse(Ptrn_ID));


                if (oDT.Rows.Count > 0)
                {
                    oCommon = new clsCommon();
                    if (oDT.Rows.Count == 1)
                    {
                        if (Convert.ToString(oDT.Rows[0]["Text"]) == "No Branch")
                        {
                            ListItem li = new ListItem();
                            li.Text = "No Branch Available";
                            li.Value = "0";
                            ddlBranch.Items.Add(li);
                            FillCoursePart(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, "0");
                        }
                        else
                        {
                            oCommon.fillDropDown(ddlBranch, oDT, "-1", "Text", "Value", "---- Select ----");
                            FillOnlyToolTip(ddlBranch);

                        }
                    }
                    else
                    {
                        oCommon.fillDropDown(ddlBranch, oDT, "-1", "Text", "Value", "---- Select ----");
                        FillOnlyToolTip(ddlBranch);
                    }
                    if (oCommon != null)
                    {
                        oCommon = null;
                    }
                }
                else
                {
                    if (ddlCourse.SelectedIndex == 0)
                    {
                        ListItem li = new ListItem();
                        li.Text = "---- Select ----";
                        li.Value = "-1";
                        ddlBranch.Items.Add(li);
                    }
                    else
                    {
                        ListItem li = new ListItem();
                        li.Text = "No Branch Available";
                        li.Value = "0";
                        ddlBranch.Items.Add(li);
                    }
                }
            }

            //-----------------------------------------------
            if (ddlBranch.Items.Count == 1)
            {
                hidBrnID.Value = "0";
            }
            //-----------------------------------------------
        }

        /// <summary>
        /// Filling dropdown for Couse Part depending on University ID,Institute ID,Faculty ID,Crouse ID,Modeoflearning ID,Pattern ID and Brnanch ID
        /// </summary>
        /// <param name="Uni_ID">University ID</param>
        /// <param name="Inst_ID">Institute ID</param>
        /// <param name="Fac_ID">Faculty ID</param>
        /// <param name="Cr_ID">ID of Course</param>
        /// <param name="Molrn_ID">Mode of Learning ID</param>
        /// <param name="Ptrn_ID">Pattern ID</param>   
        /// <param name="Brn_ID">ID of Branch</param> 
        private void FillCoursePart(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID, string Brn_ID)
        {
            ddlPart.Items.Clear();
            oDT = new DataTable();
            oCommon = new clsCommon();
            if (ChkSelectedStudyCenter.Checked == true)
            {
                if (isRegionalCenterVisible)
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim());

                }
                else
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value);
                }

            }

            if (isDiscRpt.Value.Equals("Yes") && isRegionalCenterVisible.Equals(false))
            {
                hid_Institute_ID.Value = string.Empty;
            }

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0")
            {
                oDT = oInstituteRepository.AssignedConfirmedCourseParts(Uni_ID, hid_Institute_ID.Value, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, Brn_ID);
                oCommon.fillDropDown(ddlPart, oDT, string.Empty, "Text", "Value", "---- Select ----");
                ddlPart.Items[0].Value = "-1";
            }
            else
            {
                
                oDT = oCourseRepository.ListCourseModeOfLearningPatternBrnWiseLaunchedCourseParts(long.Parse(Uni_ID), long.Parse(Fac_ID), long.Parse(Cr_ID), long.Parse(Molrn_ID), long.Parse(Ptrn_ID), long.Parse(Brn_ID));

                // Admission Eligibility :Fetch Course Part 
                //Course Part having only one child should be displayed except the first one...
                //Course Part having more than one child should be displayed . Eg. MA-I and MA-II both should be displayed as both parts contains two terms
                //if (isPageNameAdmissionEligConfiguration.Value.Equals("Yes"))
                //{
                //    Hashtable oHt = new Hashtable();
                //    oHt["UniID"] = Uni_ID.Trim();
                //    oHt["FacID"] = Fac_ID.Trim();
                //    oHt["CrID"] = Cr_ID.Trim();
                //    oHt["MoLrnID"] = Molrn_ID.Trim();
                //    oHt["PtrnID"] = Ptrn_ID.Trim();
                //    oHt["BrnID"] = Brn_ID.Trim();
                //    clsAdmissionElgConfig oAdmissionElgConfig = new clsAdmissionElgConfig();
                //    oDT = oAdmissionElgConfig.GetCoursePartForAdmissionElg(oHt);
                //    if (oDT.Rows.Count == 0)
                //        lblAdmissionElgNote.Text = "There are no Course-Parts available for the selected course for whom the Admission Eligibility can be configured.";
                //    else
                //        lblAdmissionElgNote.Text = "";
                //}

                    
                    oCommon.fillDropDown(ddlPart, oDT, string.Empty, "Text", "Value", "---- Select ----");
                    ddlPart.Items[0].Value = "-1";
                
            }

            ////oCommon.fillDropDown(ddlPart, oDT, string.Empty, "Text", "Value", "---- Select ----");
            FillOnlyToolTip(ddlPart);
           
            if (oCommon != null)
            {
                oCommon = null;
            }
        }

        /// <summary>
        /// Filling dropdown for Course Part Term depending on University ID,Institute ID,Faculty ID,Crouse ID,Modeoflearning ID,Pattern ID,Brnanch ID and CoursePartDetails ID
        /// </summary>
        /// <param name="Uni_ID">University ID</param>
        /// <param name="Inst_ID">Institute ID</param>
        /// <param name="Fac_ID">Faculty ID</param>
        /// <param name="Cr_ID">ID of Course</param>
        /// <param name="Molrn_ID">Mode of Learning ID</param>
        /// <param name="Ptrn_ID">Pattern ID</param>   
        /// <param name="Brn_ID">ID of Branch</param> 
        /// <param name="CrPrDetails_ID">Course Part Details ID</param>
        private void FillPartTerm(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID, string Brn_ID, string CrPrDetails_ID)
        {
            ddlTerm.Items.Clear();
            oDT = new DataTable();
            oCommon = new clsCommon();
            if (ChkSelectedStudyCenter.Checked == true)
            {
                if (isRegionalCenterVisible)
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim());

                }
                else
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value);
                }

            }

            if (isDiscRpt.Value.Equals("Yes") && isRegionalCenterVisible.Equals(false))
            {
                hid_Institute_ID.Value = string.Empty;
            }

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0")
            {
                oDT = oInstituteRepository.AssignCoursePartTerm(Uni_ID, hid_Institute_ID.Value, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, Brn_ID, CrPrDetails_ID);
                oCommon.fillDropDown(ddlTerm, oDT, string.Empty, "Text", "Value", "---- Select ----");
                ddlTerm.Items[0].Value = "-1";
            }
            else
            {
                oDT = oCourseRepository.ListCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrCh(long.Parse(Uni_ID), long.Parse(CrPrDetails_ID));

                
                //if (isPageNameAdmissionEligConfiguration.Value.Equals("Yes"))
                //{
                //     Hashtable oHt = new Hashtable();
                //     oHt["UniID"] = Uni_ID.Trim();
                //     oHt["FacID"] = Fac_ID.Trim();
                //     oHt["CrID"] = Cr_ID.Trim();
                //     oHt["MoLrnID"] = Molrn_ID.Trim();
                //     oHt["PtrnID"] = Ptrn_ID.Trim();
                //     oHt["BrnID"] = Brn_ID.Trim();
                //     oHt["CrPrDetailsID"] = CrPrDetails_ID.Trim();

                //     clsAdmissionElgConfig oAdmissionElgConfig = new clsAdmissionElgConfig();
                //     oDT=  oAdmissionElgConfig.GetCoursePartTermForAdmissionElg(oHt);
                   

                //}
                oCommon.fillDropDown(ddlTerm, oDT, string.Empty, "Text", "Value", "---- Select ----");
                ddlTerm.Items[0].Value = "-1";
            }

            FillOnlyToolTip(ddlTerm);

            if (oCommon != null)
            {
                oCommon = null;
            }

            if (oDT != null)
            {
                oDT = null;
            }
        }

        #endregion

        #region Independent Dropdown fill methods

        /// <summary>
        /// Filling dropdown for Data Entry User
        /// </summary>
        /// 
        /*commenting getting users section as not needed here */

        //private void FillDataEntryUser()
        //{
        //    oDT = new DataTable();
        //    clsCollegeAdmissionReports objAddReport = new clsCollegeAdmissionReports();
        //    oDT = objAddReport.Get_DataEntry_Users();
        //    oCommon = new clsCommon();
        //    oCommon.fillDropDown(ddlUser, oDT, string.Empty, "Text", "Value", "---- All ----");

        //    if (oCommon != null)
        //    {
        //        oCommon = null;
        //    }
        //}

        /// <summary>
        /// Filling dropdown for Academic Year
        /// </summary>
        private void FillAcademicYear()
        {
            oDT = new DataTable();
            clsAcademicYear objAcadYear = new clsAcademicYear();
            oDT = objAcadYear.ListAcademicYear();
            ViewState["AcademicYear"] = oDT;
            oCommon = new clsCommon();
            oCommon.fillDropDown(ddlAcadYear, oDT, string.Empty, "Year", "pk_AcademicYear_ID", "---- Select ----");

            if (oCommon != null)
            {
                oCommon = null;
            }
            if (academicYearID != null && academicYearID != "")
            {
                ListItem oLi = ddlAcadYear.Items.FindByValue(academicYearID);
                if (oLi != null)
                    oLi.Selected = true;

                DataView odv = oDT.DefaultView;
                odv.RowFilter = "pk_AcademicYear_ID =" + academicYearID;
                hid_AcademicYearFrom.Value = odv[0]["StartDate"].ToString();
                hid_AcademicYearTo.Value = odv[0]["EndDate"].ToString();
            }
        }

        /// <summary>
        /// Filling dropdown for Faculty
        /// </summary>
        private void FillFaculty()
        {
            ddlFaculty.Items.Clear();
            oDT = new DataTable();
            oCommon = new clsCommon();
            //hid_Institute_ID.Value = "";
            if (ChkSelectedStudyCenter.Checked == false)
            {
                Session["SC_ID"] = null;
            }
            
            if (Session["SC_ID"] != null)
            {
                hid_Institute_ID.Value = Convert.ToString(Session["SC_ID"]).Split('|')[0].Trim();
            }

            if (ChkSelectedStudyCenter.Checked == true)
            {
                if (isRegionalCenterVisible)
                {
                    if (Session["SC_ID"] != null)
                    {
                        hid_Institute_ID.Value = Convert.ToString(Session["SC_ID"]).Split('|')[0].Trim();
                    }
                    else
                    {
                        hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim());
                    }

                }
                else
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value);
                }

            }
             user = (clsUser)Session["User"];

             if (user.UserTypeCode == "2")
             {
                 oDT = oInstituteRepository.AssignedConfirmedFaculties(pk_Uni_ID, user.UserReferenceID);
                 hid_Institute_ID.Value = user.UserReferenceID;

             }
             else
             {
                 oDT = oCourseRepository.LaunchedUniversityWiseFacultyList(long.Parse(pk_Uni_ID));
             }
            oCommon.fillDropDown(ddlFaculty, oDT, string.Empty, "Fac_Desc", "pk_Fac_ID", "---- Select ----");
            ddlFaculty.Items[0].Value = "-1";

            ddlCourse.Items.Clear();
            ddlBranch.Items.Clear();
            ddlPart.Items.Clear();
            ddlTerm.Items.Clear();

            ddlCourse.Items.Insert(0, new ListItem("---- Select ----", "-1"));
            ddlBranch.Items.Insert(0, new ListItem("---- Select ----", "-1"));
            ddlPart.Items.Insert(0, new ListItem("---- Select ----", "-1"));
            ddlTerm.Items.Insert(0, new ListItem("---- Select ----", "-1"));

            FillOnlyToolTip(ddlFaculty);

            if (oCommon != null)
            {
                oCommon = null;
            }
        }

        #endregion

        #region rdbtnUser_CheckedChanged
        protected void rdbtnUser_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnUser.Checked)
            {
                DivUser.Visible = true;
                ddlUser.SelectedValue = "0";
                DivDate.Visible = false;
            }

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(rdbtnUser);
        }
        #endregion

        #region rdbtnDate_CheckedChanged
        protected void rdbtnDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnDate.Checked)
            {
                DivUser.Visible = false;
                DivDate.Visible = true;
            }

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(rdbtnDate);
        }
        #endregion

        #region Function For ServerSideValidations
        /// <summary>
        /// ServerSideValidations(Validation for server side)
        /// </summary>
        private bool ServerSideValidations()
        {
            Validation oValidate = new Validation();
            if (!hidIsAcdYrDdNotVisible.Value.Equals("Yes"))
            {
                oValidate.inputElement(ddlAcadYear.Text, Convert.ToString(TypeOfValidation.RequiredDropDown), "Academic Year", null, "0", null);
            }
            if (isReportUserAndDateDisplay)
            {
                if (rdbtnDate.Checked == true)
                {
                    oValidate.inputElement(txtFrom.Text, Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ValidDate), "From Date", "dd/mm/yyyy", null, null);
                    oValidate.inputElement(txtFrom.Text, Convert.ToString(TypeOfValidation.DateBetween), "From Date", "dd/mm/yyyy", hid_AcademicYearFrom.Value, hid_AcademicYearTo.Value);

                    oValidate.inputElement(txtTo.Text, Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ValidDate), "To Date", "dd/mm/yyyy", null, null);
                    oValidate.inputElement(txtTo.Text, Convert.ToString(TypeOfValidation.DateBetween), "To Date", "dd/mm/yyyy", hid_AcademicYearFrom.Value, hid_AcademicYearTo.Value);
                }
            }

            //
            //This "IF" condition will check whether the Server Side Validation has succeeded.
            //
            return oValidate.ValidateMe(lblErrorMessage);
        }

        #endregion
    }
}