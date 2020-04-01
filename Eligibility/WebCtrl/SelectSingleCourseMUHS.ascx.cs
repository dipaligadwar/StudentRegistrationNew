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

namespace StudentRegistration.Eligibility.WebCtrlMUHS
{
    public delegate void SingleCourseProceedClick(object sender, EventArgs e);

    public partial class SelectSingleCourseMUHS : System.Web.UI.UserControl
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

        /// <summary>
        /// Proceed button click event
        /// </summary>
        public event SingleCourseProceedClick OnProceedClick;
        #endregion

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

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsGetSettings.OpenUniversity.ToUpper() == "YES")
            {
                isRegionalCenterVisible = true;
            }

            if (!IsPostBack)
            {
                clsUser oUser = (clsUser)Session["user"];
                if (oUser.UserTypeCode == "2")
                {
                    hid_Institute_ID.Value = oUser.UserReferenceID;
                    InstID = hid_Institute_ID.Value;
                    lblRegionalCenterName.Text = oUser.Name;
                    SetRSCVisibility(oUser);

                }
                if (isRegionalCenterVisible)
                {
                    ////This will Fill Regional Center Drop Down
                    FillRegionalCenter();
                }
                else
                {
                    FillInstitute();
                }


                FillFaculty();

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
                   // FillDataEntryUser();
                }
                else
                {
                    divReportDisp.Visible = false;
                }
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

            if (hidCenterType.Value == string.Empty)
            {
                if (isRegionalCenterVisible)
                {
                    if (ChkAllRegionalCenter.Checked)
                    {
                        dvSelectRC.Attributes.Add("style", "display:none;clear:both;");
                        divStudyCenter.Attributes.Add("style", "display:none");
                        dvSelectSC.Attributes.Add("style", "display:none;clear:both;");
                    }
                    else
                    {
                        ////This will Fill Regional Center Drop Down
                        //FillRegionalCenter();

                        dvSelectRC.Attributes.Add("style", "display:inline;clear:both;");
                        divStudyCenter.Attributes.Add("style", "display:inline");
                        if (ChkAllStudyCenter.Checked)
                        {
                            dvSelectSC.Attributes.Add("style", "display:none;clear:both;");
                        }
                        else
                        {
                            dvSelectSC.Attributes.Add("style", "display:inline;clear:both;");
                        }
                    }
                }
                else
                {
                    divRegionalCenter.Attributes.Add("style", "display:none");
                    divStudyCenter.Attributes.Add("style", "display:inline");
                    if (ChkAllStudyCenter.Checked)
                    {
                        dvSelectSC.Attributes.Add("style", "display:none;clear:both;");
                    }
                    else
                    {
                        dvSelectSC.Attributes.Add("style", "display:inline;clear:both;");
                    }
                }
            }
            else if (hidCenterType.Value == "RSC" || hidCenterType.Value == "RC")
            {
                divRCLabel.Attributes.Add("style", "display:inline");
                divStudyCenter.Attributes.Add("style", "display:inline");
                if (ChkAllStudyCenter.Checked)
                {
                    dvSelectSC.Attributes.Add("style", "display:none;clear:both;");
                }
                else
                {
                    dvSelectSC.Attributes.Add("style", "display:inline;clear:both;");
                }
            }
            else if (hidCenterType.Value == "SC" || hidCenterType.Value == "COLLEGE")
            {
                divRegionalCenter.Attributes.Add("style", "display:none");
                divStudyCenter.Attributes.Add("style", "display:none");
            }

            #endregion
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
                    if (ddlRegionalCenter.SelectedValue.ToString() != "0")
                    {
                        fillStudyCenter(Convert.ToString(ddlRegionalCenter.SelectedItem.Value));
                    }
                    else
                    {
                        if (hid_Institute_ID.Value != "")
                        {
                            fillStudyCenter(Convert.ToString(hid_Institute_ID.Value));
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
                }
                else
                {
                    FillInstitute();
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
                DataView odv = new DataView((DataTable)ViewState["VSAcademicYear"]);
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

            if (hidCenterType.Value != "")
            {
                //
                //BAsed on login type set the parameter values to process the request
                //               
                switch (hidCenterType.Value)
                {
                    case "RC":
                        //
                        //Display study center selction screen with regional center as a label
                        //
                        oDT = new DataTable();
                        oDT = oInstituteRepository.InstituteDetails(pk_Uni_ID, hid_Institute_ID.Value);
                        if (oDT.Rows.Count > 0)
                        {
                            regionalCenterID = hid_Institute_ID.Value;
                            regionalCenterName = Convert.ToString(oDT.Rows[0]["Inst_Name"]);
                            regionalCenterCode = Convert.ToString(oDT.Rows[0]["Inst_Code"]);
                            regionalCenterCity = Convert.ToString(oDT.Rows[0]["Inst_City"]);
                            instName = Convert.ToString(oDT.Rows[0]["Inst_Name"]);
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
                        if (oDT != null) oDT = null;
                        break;
                    case "RSC":
                        //
                        //populate the courses for the regional center
                        //

                        //isDivisionRollNoDisplay = false;
                        oDT = new DataTable();
                        oDT = oInstituteRepository.InstituteDetails(pk_Uni_ID, hid_Institute_ID.Value);
                        if (oDT.Rows.Count > 0)
                        {
                            regionalCenterID = hid_Institute_ID.Value;
                            regionalCenterName = Convert.ToString(oDT.Rows[0]["Inst_Name"]);
                            regionalCenterCode = Convert.ToString(oDT.Rows[0]["Inst_Code"]);
                            regionalCenterCity = Convert.ToString(oDT.Rows[0]["Inst_City"]);
                            ////instAddress = Convert.ToString(oDT.Rows[0]["InstAddress"]);
                            instName = Convert.ToString(oDT.Rows[0]["Inst_Name"]);
                            //instLogo = Convert.ToString(oDT.Rows[0]["Inst_Logo"]);

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
                        if (oDT != null) oDT = null;
                        break;
                    case "SC":
                        //
                        //populate the courses for the study center 
                        //

                        //isDivisionRollNoDisplay = false;
                        oDT = new DataTable();
                        oDT = oInstituteRepository.InstituteDetails(pk_Uni_ID, hid_Institute_ID.Value);
                        if (oDT.Rows.Count > 0)
                        {
                            studyCenterID = hid_Institute_ID.Value;
                            studyCenterCode = Convert.ToString(oDT.Rows[0]["Inst_Code"]);
                            studyCenterName = Convert.ToString(oDT.Rows[0]["Inst_Name"]);
                            regionalCenterID = Convert.ToString(oDT.Rows[0]["RegionalCenterID"]);
                            //instAddress = Convert.ToString(oDT.Rows[0]["InstAddress"]);
                            instName = Convert.ToString(oDT.Rows[0]["Inst_Name"]);
                            //instLogo = Convert.ToString(oDT.Rows[0]["Inst_Logo"]);

                            oDT = new DataTable();
                            oDT = oInstituteRepository.InstituteDetails(pk_Uni_ID, regionalCenterID);
                            if (oDT.Rows.Count > 0)
                            {
                                regionalCenterName = Convert.ToString(oDT.Rows[0]["Inst_Name"]);
                                regionalCenterCode = Convert.ToString(oDT.Rows[0]["Inst_Code"]);
                                regionalCenterCity = Convert.ToString(oDT.Rows[0]["Inst_City"]);
                            }
                        }
                        if (oDT != null) oDT = null;
                        break;
                    case "COLLEGE":



                        oDT = new DataTable();
                        oDT = oInstituteRepository.InstituteDetails(pk_Uni_ID, hid_Institute_ID.Value);
                        if (oDT.Rows.Count > 0)
                        {
                            studyCenterID = hid_Institute_ID.Value;
                            studyCenterCode = Convert.ToString(oDT.Rows[0]["Inst_Code"]);
                            studyCenterName = Convert.ToString(oDT.Rows[0]["Inst_Name"]);
                            //instAddress = Convert.ToString(oDT.Rows[0]["InstAddress"]);
                            instName = Convert.ToString(oDT.Rows[0]["Inst_Name"]);
                            //instLogo = Convert.ToString(oDT.Rows[0]["Inst_Logo"]);
                        }
                        if (oDT != null) oDT = null;
                        break;
                }
            }
            else
            {
                if (isRegionalCenterVisible)
                {
                    if (ChkAllRegionalCenter.Checked)
                    {
                        regionalCenterID = string.Empty;
                        regionalCenterName = "All";
                        regionalCenterCode = "All";
                        regionalCenterCity = "All";
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
                        if (oDT != null) oDT = null;
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
                            studyCenterID = ddlStudyCenter.SelectedValue.ToString();
                            pk_Institute_ID = ddlStudyCenter.SelectedValue.ToString();
                            instName = ddlStudyCenter.SelectedItem.Text.ToString();

                        }
                    }
                }
            }
            ConstrctOtherString();
            ConstrctCourseString();


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
                    DataView odv = new DataView((DataTable)ViewState["VSAcademicYear"]);
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

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlAcadYear);
        }

        /// <summary>
        /// Faculty dropdownlist selected index changed event
        /// </summary>
        /// <param name="sender">Event Source</param>
        /// <param name="e">Event Arguments</param>
        protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCourse.Items.Clear();
            ddlBranch.Items.Clear();
            ddlPart.Items.Clear();
            ddlTerm.Items.Clear();


            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0")
            {
                if (ddlFaculty.SelectedItem.Text == "---- All ----")
                {
                    ddlCourse.Items.Insert(0, new ListItem("---- All ----", "0"));
                    ddlBranch.Items.Insert(0, new ListItem("---- All ----", "0"));
                    ddlPart.Items.Insert(0, new ListItem("---- All ----", "0"));
                    ddlTerm.Items.Insert(0, new ListItem("---- All ----", "0"));
                }
                else
                {
                    ddlCourse.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                    ddlBranch.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                    ddlPart.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                    ddlTerm.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                    FillFacultyCourseMoLrnPatternName(pk_Uni_ID, hid_Institute_ID.Value, ddlFaculty.SelectedValue);
                }
            }
            else
            {
                if (ddlFaculty.SelectedItem.Text == "---- All ----")
                {
                    ddlCourse.Items.Insert(0, new ListItem("---- All ----", "0"));
                    ddlBranch.Items.Insert(0, new ListItem("---- All ----", "0"));
                    ddlPart.Items.Insert(0, new ListItem("---- All ----", "0"));
                    ddlTerm.Items.Insert(0, new ListItem("---- All ----", "0"));
                }
                else
                {
                    ddlCourse.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                    ddlBranch.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                    ddlPart.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                    ddlTerm.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                    FillFacultyCourseMoLrnPatternName(pk_Uni_ID, hid_Institute_ID.Value, ddlFaculty.SelectedValue);
                }
            }

            ////This will Fill Faculty,Course,Mode of Learning and Pattern in single Drop Down            


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
            ddlTerm.Items.Clear();

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

            ////This will Fill Correspondance Course Part Term Details Drop Down            
            FillPartTerm(pk_Uni_ID, hid_Institute_ID.Value, facultyID, courseID, modeLrnID, patternID, Convert.ToString(ddlBranch.SelectedItem.Value), Convert.ToString(ddlPart.SelectedItem.Value));


            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlPart);
        }

        #endregion

        #region Function to split FacCrMoLrnPtrnID
        /// <summary>
        /// Spliting the value of Course DropDown into FacultyID , CourseID , MoLrnID and PatternID which are coming combined.
        /// </summary>
        private void getFacCrMoLrnPtrnID()
        {
            if (Convert.ToString(ddlCourse.SelectedValue) != "-1" && isCourseDisplay && Convert.ToString(ddlCourse.SelectedValue) != "0")
            {
                IDs_List = Convert.ToString(ddlCourse.SelectedValue).Split('-');
                facultyID = Convert.ToString(IDs_List[0]).Trim();
                courseID = Convert.ToString(IDs_List[1]).Trim();
                modeLrnID = Convert.ToString(IDs_List[2]).Trim();
                patternID = Convert.ToString(IDs_List[3]).Trim();
            }
            else
            {
                if (Convert.ToString(ddlCourse.SelectedValue) == "0")
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
            Session["RC_ID"] = Convert.ToString(ddlRegionalCenter.SelectedItem.Value);

            Session["SC_All"] = Convert.ToString(ChkAllStudyCenter.Checked);
            Session["SC_Selected"] = Convert.ToString(ChkSelectedStudyCenter.Checked);
            Session["SC_ID"] = Convert.ToString(ddlStudyCenter.SelectedItem.Value);

            Session["facultyID"] = Convert.ToString(ddlFaculty.SelectedItem.Value);
            Session["BranchID"] = Convert.ToString(ddlBranch.SelectedItem.Value);
            Session["FacCrMoLrnPtrn_ID"] = Convert.ToString(ddlCourse.SelectedItem.Value);
            Session["pk_Brn_ID"] = Convert.ToString(ddlBranch.SelectedItem.Value);
            Session["pk_CrPr_Details_ID"] = Convert.ToString(ddlPart.SelectedItem.Value);
            Session["pk_CrPrCh_ID"] = Convert.ToString(ddlTerm.SelectedItem.Value);
            Session["pk_AcademicYear_ID"] = Convert.ToString(ddlAcadYear.SelectedItem.Value);
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

            if (Session["SC_All"] != null)
            {
                if (Session["SC_All"].ToString() == "True")
                {
                    ChkAllStudyCenter.Checked = true;
                }
                else
                {
                    ChkAllStudyCenter.Checked = false;
                }
            }

            if (Session["SC_Selected"] != null)
            {
                if (Session["SC_Selected"].ToString() == "True")
                {
                    ChkSelectedStudyCenter.Checked = true;
                }
                else
                {
                    ChkSelectedStudyCenter.Checked = false;
                }
            }

            if (Session["SC_ID"] != null)
            {
                ddlStudyCenter.SelectedValue = Convert.ToString(Session["SC_ID"]);
                if (Convert.ToInt16(ddlStudyCenter.SelectedItem.Text.IndexOf('[')) == 0 && Convert.ToInt16(ddlStudyCenter.SelectedItem.Text.IndexOf(']')) > 0)
                {
                    string CenterCode = Convert.ToString(ddlStudyCenter.SelectedItem.Text.Split('[')[1].Trim());
                    CenterCode = CenterCode.Split(']')[0].Trim();
                    txtCenterCode.Text = CenterCode;
                }
            }


            if (Session["pk_AcademicYear_ID"] != null)
            {
                ddlAcadYear.SelectedValue = Convert.ToString(Session["pk_AcademicYear_ID"]);
                DataView odv = new DataView((DataTable)ViewState["VSAcademicYear"]);
                odv.RowFilter = "pk_AcademicYear_ID =" + ddlAcadYear.SelectedValue;
                if (odv.Count > 0)
                {
                    hid_AcademicYearFrom.Value = odv[0]["StartDate"].ToString();
                    hid_AcademicYearTo.Value = odv[0]["EndDate"].ToString();
                }
            }

            if (Session["facultyID"] != null && isFacultyDisplay)
            {
                //FillFaculty();
                ddlFaculty.SelectedValue = Convert.ToString(Session["facultyID"]);
            }

            if (Session["FacCrMoLrnPtrn_ID"] != null && isCourseDisplay)
            {
                FillFacultyCourseMoLrnPatternName(clsGetSettings.UniversityID, pk_Institute_ID, ddlFaculty.SelectedItem.Value);
                ddlCourse.SelectedValue = Convert.ToString(Session["FacCrMoLrnPtrn_ID"]);
                getFacCrMoLrnPtrnID();
            }

            if (Session["pk_Brn_ID"] != null && isBranchDisplay)
            {
                ////This will Fill Correspondance Branch Drop Down
                FillBranch(pk_Uni_ID, pk_Institute_ID, facultyID, courseID, modeLrnID, patternID);
                ddlBranch.SelectedValue = Convert.ToString(Session["pk_Brn_ID"]);
            }

            if (Session["pk_CrPr_Details_ID"] != null && isCoursePartDisplay)
            {
                ////This will Fill Correspondance Course Part Details Drop Down
                FillCoursePart(pk_Uni_ID, pk_Institute_ID, facultyID, courseID, modeLrnID, patternID, Convert.ToString(Session["pk_Brn_ID"]));
                ddlPart.SelectedValue = Convert.ToString(Session["pk_CrPr_Details_ID"]);

                ////This will Fill Correspondance Course Part Childs Drop Down
                FillPartTerm(pk_Uni_ID, pk_Institute_ID, facultyID, courseID, modeLrnID, patternID, Convert.ToString(Session["pk_Brn_ID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]));
            }

            if (Session["pk_CrPrCh_ID"] != null && isCourseTermDisplay)
            {
                ddlTerm.SelectedValue = Convert.ToString(Session["pk_CrPrCh_ID"]);
            }
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

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0" && (hidCenterType.Value == "SC" || hidCenterType.Value == "COLLEGE"))
            {
                oDT = oInstituteRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, hid_Institute_ID.Value, Faculty_ID);
                oCommon.fillDropDown(ddlCourse, oDT, string.Empty, "Text", "Value", "---- Select ----");
                ddlCourse.Items[0].Value = "-1";
            }
            else if (hid_Institute_ID.Value != "" && ddlStudyCenter.SelectedValue != "0")
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

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0" && (hidCenterType.Value == "SC" || hidCenterType.Value == "COLLEGE"))
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
            else if (hid_Institute_ID.Value != "" && ddlStudyCenter.SelectedValue != "0")
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

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0" && (hidCenterType.Value == "SC" || hidCenterType.Value == "COLLEGE"))
            {
                oDT = oInstituteRepository.AssignedConfirmedCourseParts(Uni_ID, hid_Institute_ID.Value, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, Brn_ID);
                oCommon.fillDropDown(ddlPart, oDT, string.Empty, "Text", "Value", "---- Select ----");
                ddlPart.Items[0].Value = "-1";
            }
            else if (hid_Institute_ID.Value != "" && ddlStudyCenter.SelectedValue != "0")
            {
                oDT = oInstituteRepository.AssignedConfirmedCourseParts(Uni_ID, hid_Institute_ID.Value, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, Brn_ID);
                oCommon.fillDropDown(ddlPart, oDT, string.Empty, "Text", "Value", "---- Select ----");
                ddlPart.Items[0].Value = "-1";
            }
            else
            {
                oDT = oCourseRepository.ListCourseModeOfLearningPatternBrnWiseLaunchedCourseParts(long.Parse(Uni_ID), long.Parse(Fac_ID), long.Parse(Cr_ID), long.Parse(Molrn_ID), long.Parse(Ptrn_ID), long.Parse(Brn_ID));
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

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0" && (hidCenterType.Value == "SC" || hidCenterType.Value == "COLLEGE"))
            {
                oDT = oInstituteRepository.AssignCoursePartTerm(Uni_ID, hid_Institute_ID.Value, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, Brn_ID, CrPrDetails_ID);
                oCommon.fillDropDown(ddlTerm, oDT, string.Empty, "Text", "Value", "---- Select ----");
                ddlTerm.Items[0].Value = "-1";
            }
            else if (hid_Institute_ID.Value != "" && ddlStudyCenter.SelectedValue != "0")
            {
                oDT = oInstituteRepository.AssignCoursePartTerm(Uni_ID, hid_Institute_ID.Value, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, Brn_ID, CrPrDetails_ID);
                oCommon.fillDropDown(ddlTerm, oDT, string.Empty, "Text", "Value", "---- Select ----");
                ddlTerm.Items[0].Value = "-1";
            }
            else
            {
                oDT = oCourseRepository.ListCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrCh(long.Parse(Uni_ID), long.Parse(CrPrDetails_ID));
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
            if (Session["SC_ID"] != null && hid_Institute_ID.Value == string.Empty)
            {
                hid_Institute_ID.Value = Convert.ToString(Session["SC_ID"]).Split('|')[0].Trim();
            }
            if (ChkSelectedStudyCenter.Checked == true)
            {
                if (isRegionalCenterVisible)
                {
                    if (Session["SC_ID"] != null && hid_Institute_ID.Value == string.Empty)
                    {
                        hid_Institute_ID.Value = Convert.ToString(Session["SC_ID"]).Split('|')[0].Trim();
                    }
                    else if (Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim()) != "0")
                    {
                        hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value.Split('|')[0].Trim());
                    }

                }
                else if (Convert.ToString(ddlStudyCenter.SelectedItem.Value) != "0")
                {
                    hid_Institute_ID.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Value);
                }

            }

            if (hid_Institute_ID.Value != "" && hid_Institute_ID.Value != "0" && (hidCenterType.Value == "SC" || hidCenterType.Value == "COLLEGE"))
            {
                oDT = oInstituteRepository.AssignedConfirmedFaculties(pk_Uni_ID, hid_Institute_ID.Value);
                oCommon.fillDropDown(ddlFaculty, oDT, string.Empty, "Fac_Desc", "pk_Fac_ID", "---- All ----");
                ddlCourse.Items.Insert(0, new ListItem("---- All ----", "0"));
                ddlBranch.Items.Insert(0, new ListItem("---- All ----", "0"));
                ddlPart.Items.Insert(0, new ListItem("---- All ----", "0"));
                ddlTerm.Items.Insert(0, new ListItem("---- All ----", "0"));
            }
            else if (hid_Institute_ID.Value != "" && ddlStudyCenter.SelectedValue != "0")
            {
                // oDT = oInstituteRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, (ddlStudyCenter.SelectedValue.Split('|'))[0], Faculty_ID);
                oDT = oInstituteRepository.AssignedConfirmedFaculties(pk_Uni_ID, (ddlStudyCenter.SelectedValue.Split('|'))[0]);
                oCommon.fillDropDown(ddlFaculty, oDT, string.Empty, "Fac_Desc", "pk_Fac_ID", "---- All ----");
                ddlCourse.Items.Insert(0, new ListItem("---- All ----", "0"));
                ddlBranch.Items.Insert(0, new ListItem("---- All ----", "0"));
                ddlPart.Items.Insert(0, new ListItem("---- All ----", "0"));
                ddlTerm.Items.Insert(0, new ListItem("---- All ----", "0"));
            }
            else
            {
                oDT = oCourseRepository.LaunchedUniversityWiseFacultyList(long.Parse(pk_Uni_ID));
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

            }

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

            oValidate.inputElement(ddlAcadYear.Text, Convert.ToString(TypeOfValidation.RequiredDropDown), "Academic Year", null, "0", null);

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

        #region SetRSCVisibility
        /// <summary>
        /// Set the Visibility of controls based on login type
        /// </summary>
        /// <param name="oUser"></param>
        private void SetRSCVisibility(clsUser oUser)
        {
            if (hid_Institute_ID.Value != "")
            {
                ///Decide wether to show the study center selection screen or populate
                ///the course based upon Institute ID               
                Hashtable ohs = oUser.ReferenceProperty;
                hidCenterType.Value = Convert.ToString(ohs["CenterType"]);

                switch (hidCenterType.Value)
                {
                    case "RC":
                        //
                        //Display study center selction screen with regional center as a label
                        //

                        divRegionalCenter.Attributes.Add("style", "display:none");
                        divStudyCenter.Attributes.Add("style", "display:inline");
                        fillStudyCenter(Convert.ToString(hid_Institute_ID.Value));
                        break;
                    case "RSC":
                        //
                        //populate the courses for the regional center
                        //

                        divRegionalCenter.Attributes.Add("style", "display:none");
                        divStudyCenter.Attributes.Add("style", "display:inline");
                        fillStudyCenter(Convert.ToString(hid_Institute_ID.Value));
                        break;
                    case "SC":
                        //
                        //populate the courses for the study center 
                        //

                        divRegionalCenter.Attributes.Add("style", "display:none");
                        divStudyCenter.Attributes.Add("style", "display:none");

                        break;
                    case "COLLEGE":
                        divRegionalCenter.Attributes.Add("style", "display:none");
                        divStudyCenter.Attributes.Add("style", "display:none");



                        break;
                }
            }
        }
        #endregion
    }
}