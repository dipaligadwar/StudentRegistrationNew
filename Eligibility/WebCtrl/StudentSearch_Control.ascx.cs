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
using ServerSideValidations;
using AjaxControlToolkit;

namespace StudentRegistration.Eligibility.WebCtrl
{
    /// <summary>
    /// Declare a Delegate so that we can use event outside the class.
    /// </summary>
    /// <param name="sender">Event source.</param>
    /// <param name="e">Event argument.</param>
    public delegate void SearchClick(object sender, EventArgs e);
    public partial class StudentSearch_Control : System.Web.UI.UserControl
    {
         #region Variable Declaration       
        Validation oValidate;
        clsCommon oCommon = null;
        clsGeneral oGeneral = null;
        DataTable DT = null;        

        private string[] IDs_List = new string[3];
        private string sElgFormNo = string.Empty;
        private string sPRN = string.Empty;
        private string sOldPRN = string.Empty;
        private string sLastName = string.Empty;
        private string sFirstName = string.Empty;
        private string sGender = string.Empty;
        private string sAppFormNo = string.Empty;

        private long sFacID;
        private long sCourseID;        
        private long sMoLrnID;
        private long sPtrnID;
        private long sBranchID;
        private long sCrPrDetailsID;
        private long sCrPrTermID;
        
        private long UniId = long.Parse(clsGetSettings.UniversityID);
        private string pk_Institute_ID = string.Empty;
        
        private bool isValid;
        private Page oPage;
        
        CourseRepository oCr = new CourseRepository();
        InstituteRepository oInst = new InstituteRepository();
        clsUser user;
        #endregion

        /// <summary>
        /// Declare an event based on the delegate.
        /// </summary>
        public event SearchClick OnSearchClick;

        #region Properties
        /// <summary>
        /// Gets or sets page.
        /// </summary>
        /// <value>Contains page.</value>
        public Page page
        {
            get
            {
                return oPage;
            }

            set
            {
                oPage = value;
            }
        }

        /// <summary>
        /// Gets student eligibility form number.
        /// </summary>
        /// <value>Student eligibility form number.</value>
        public string ElgFormNo
        {
            get
            {
                return sElgFormNo;
            }
        }

        /// <summary>
        /// Gets student PRN.
        /// </summary>
        /// <value>Student prn.</value>
        public string PRN
        {
            get
            {
                return sPRN;
            }
        }

        /// <summary>
        /// Gets student Old PRN.
        /// </summary>
        /// <value>Student Old PRN.</value>
        public string OldPRN
        {
            get
            {
                return sOldPRN;
            }
        }

        /// <summary>
        /// Gets student last name.
        /// </summary>
        /// <value>Student last name.</value>
        public string LastName
        {
            get
            {
                return sLastName;
            }
        }

        /// <summary>
        /// Gets student first name.
        /// </summary>
        /// <value>Student first name.</value>
        public string FirstName
        {
            get
            {
                return sFirstName;
            }
        }
        

        /// <summary>
        /// Gets student gender.
        /// </summary>
        /// <value>Student gender.</value>
        public string Gender
        {
            get
            {
                return sGender;
            }
        }
        
        /// <summary>
        /// Gets a value indicating whether is valid.
        /// </summary>
        /// <value>Whether is valid.</value>
        public bool IsValid
        {
            get
            {
                return isValid;
            }
        }

        /// <summary>
        /// Gets faculty id.
        /// </summary>
        /// <value>Faculty id.</value>
        public long FacID 
        {
            get
            {
                return sFacID;
            }
        }

        /// <summary>
        /// Gets course id.
        /// </summary>
        /// <value>Course id.</value>
        public long CourseID
        {
            get
            {
                return sCourseID;
            }
        }

        /// <summary>
        /// Gets mode of learning id.
        /// </summary>
        /// <value>Mode of learning id.</value>
        public long MoLrnID 
        {
            get
            {
                return sMoLrnID;
            }
        }

        /// <summary>
        /// Gets pattern id.
        /// </summary>
        /// <value>Pattern id.</value>
        public long PtrnID 
        {
            get
            {
                return sPtrnID;
            }
        }

        /// <summary>
        /// Gets branch id.
        /// </summary>
        /// <value>Branch id.</value>
        public long BranchID 
        {
            get
            {
                return sBranchID;
            }
        }
        
        /// <summary>
        /// Gets Course part details id.
        /// </summary>
        /// <value>Course part details id.</value>
        public long CrPrDetailsID 
        {
            get
            {
                return sCrPrDetailsID;
            }
        }

        /// <summary>
        /// Gets Course part term id.
        /// </summary>
        /// <value>Course part term id.</value>
        public long CrPrTermID
        {
            get
            {
                return sCrPrTermID;
            }
        }


        public string AppFormNo
        {
            get
            {
                return sAppFormNo;
            }
        }
       
        #endregion

        #region Function SetFocus
        /// <summary>
        /// Function for set focus.
        /// </summary>
        /// <param name="page">Page name.</param>
        /// <param name="control">Control name.</param>
        public void SetFocus(Page page, Control control)
        {
            string strScript = string.Format("document.getElementById('{0}').focus();", control.ClientID);
            strScript = string.Format("<script language='JavaScript'>{0}</script>", strScript);
            ScriptManager.RegisterStartupScript(this.page, this.GetType(), "setFocus", strScript, false);
        }
        #endregion

        #region Page Load
        /// <summary>
        /// Page load event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
            user = (clsUser)Session["user"];
            if (user.UserTypeCode == "2")
            {
                pk_Institute_ID = user.UserReferenceID;
            }



            if (!IsPostBack)
            {
                // Call for filling Independent Combo box on screen.
                FillIndependentCombo();

                DD_Course.Items.Insert(0, new ListItem("---- Select ----", "0"));
                DD_Branch.Items.Insert(0, new ListItem("---- Select ----", "-1"));
                DD_CoursePart.Items.Insert(0, new ListItem("---- Select ----", "0"));
                DD_Term.Items.Insert(0, new ListItem("---- Select ----", "0"));


                // Call for Displaying Data from Session.
                DisplyFromSession();

                // To show Advance search control Expanded when course selectio is in session.
                if (DDlFaculty.SelectedItem.Value != "0")
                {
                    CollapsiblePanelExtender1.Collapsed = false;
                }

                DateTime date = DateTime.ParseExact(this.Session["AcademicYearFrom"].ToString(), "dd/MM/yyyy", null);
                int FormYear = Convert.ToInt32(date.Year);

                DateTime date1 = DateTime.ParseExact(this.Session["AcademicYearTo"].ToString(), "dd/MM/yyyy", null);
                int ToYear = Convert.ToInt32(date1.Year);

                lblAcademicYear.Text = FormYear + " To " + ToYear;

                SetFocus(oPage, txtPRN);
            }            
        }
        #endregion

        #region Button Search Click
        /// <summary>
        /// Search button click event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
            }
            catch
            {
                hidIsPRNValidationRequired.Value = "N";

            }

            isValid = false;
            if (txtElgFormNo.Text.Trim() == string.Empty && txtPRN.Text.Trim() == string.Empty && txtOldPRN.Text.Trim() == string.Empty && txtLastName.Text.Trim() == string.Empty && txtFirstName.Text.Trim() == string.Empty && DDlFaculty.Text == "0" && DD_Gender.Text == "0" && txtAppFormNo.Text.Trim() == string.Empty)
            {
                lblErrorMessage.Text = "Please Correct The Following Errors</br> 1. Enter atleast one criteria for searching student.";
                isValid  = false;                
            }
            else if(hidIsPRNValidationRequired.Value == "Y")
            {
                ServerSideValidations();
            }

            if (hidIsPRNValidationRequired.Value == "N")
            {
                isValid = true;
            }
            if (isValid)
            {
                sElgFormNo = txtElgFormNo.Text;
                sPRN = txtPRN.Text;
                sOldPRN = txtOldPRN.Text;
                sLastName = txtLastName.Text;
                sFirstName = txtFirstName.Text;
                sAppFormNo = txtAppFormNo.Text;

                if (DD_Course.SelectedItem.Value != "0")
                {
                    getFacCrMoLrnPtrnID();
                    sBranchID = long.Parse(DD_Branch.SelectedItem.Value);
                    sCrPrDetailsID = long.Parse(DD_CoursePart.SelectedItem.Value);
                    sCrPrTermID = long.Parse(DD_Term.SelectedItem.Value);
                }

                sGender = DD_Gender.Text;   
            }
           
            // Call for Memorising value of DropDowns in Session.
            MemorizeInSession();
          
            // Explicitly fire the event.
            if (OnSearchClick != null)
            {
                OnSearchClick(sender, e);
            }
        }
        #endregion
       
        #region Selected Index Change Events
        protected void DDlFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            DD_Branch.Items.Clear();
            DD_Branch.Items.Insert(0, new ListItem("---- Select ----", "-1"));

            DD_CoursePart.Items.Clear();
            DD_CoursePart.Items.Insert(0, new ListItem("---- Select ----", "0"));

            DD_Term.Items.Clear();
            DD_Term.Items.Insert(0, new ListItem("---- Select ----", "0"));

            FillFacultyCourseMoLrnPatternName(UniId.ToString(),pk_Institute_ID, DDlFaculty.SelectedItem.Value);

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(DDlFaculty);
        }

        /// <summary>
        /// Selected index changed event of course's drop down.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void DD_Course_SelectedIndexChanged(object sender, EventArgs e)
        {

            DD_CoursePart.Items.Clear();
            DD_CoursePart.Items.Insert(0, new ListItem("---- Select ----", "0"));

            DD_Term.Items.Clear();
            DD_Term.Items.Insert(0, new ListItem("---- Select ----", "0"));

            // Call for Seting FacultyID , CourseID ,MoLrnID and PatternID.
            getFacCrMoLrnPtrnID();
          
            // This will Fill Correspondance Branch Drop Down.
            FillBranch(UniId,pk_Institute_ID, sFacID, sCourseID, sMoLrnID, sPtrnID);


            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(DD_Course);            
        }

        /// <summary>
        /// Selected index changed event of branch's drop down. 
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void DD_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
           DD_Term.Items.Clear();
           DD_Term.Items.Insert(0, new ListItem("---- Select ----", "0"));

            // Call for Seting FacultyID , CourseID ,MoLrnID and PatternID.
            getFacCrMoLrnPtrnID();

            // This will Fill Correspondance Course Part Details Drop Down.
            FillCoursePart(UniId,pk_Institute_ID, sFacID, sCourseID, sMoLrnID, sPtrnID, long.Parse(DD_Branch.SelectedItem.Value));
            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(DD_Branch);
            
        }

        /// <summary>
        /// Selected index changed event of course part drop down.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void DD_CoursePart_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call for Seting FacultyID , CourseID ,MoLrnID and PatternID.
            getFacCrMoLrnPtrnID();

            // This will fill Correspondance Course Part term drop down
            FillPartTerm(UniId, pk_Institute_ID, Convert.ToString(sFacID), Convert.ToString(sCourseID), Convert.ToString(sMoLrnID), Convert.ToString(sPtrnID), DD_Branch.SelectedItem.Value, long.Parse(DD_CoursePart.SelectedValue));
            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(DD_CoursePart);
            
        }
        #endregion

        #region Function to Fill Independent Combo Box
        /// <summary>
        /// Function for filling independent drop down.
        /// </summary>
        private void FillIndependentCombo()
        {
            DT = new DataTable();
            if (pk_Institute_ID != string.Empty)
            {
                DT = oInst.AssignedConfirmedFaculties(Convert.ToString(UniId), pk_Institute_ID);
            }
            else
            {
                DT = oCr.LaunchedUniversityWiseFacultyList(UniId);
            }

            
            oCommon = new clsCommon();
            oCommon.fillDropDown(DDlFaculty, DT, string.Empty, "Fac_Desc", "pk_Fac_ID", "---- Select ----");
            if (oCommon != null)
            {
                oCommon = null;
            }

            DT = new DataTable();
            oGeneral = new clsGeneral();
            DT = oGeneral.ListGender();
            oGeneral = null;
            oCommon = new clsCommon();
            oCommon.fillDropDown(DD_Gender, DT, "0", "Text", "Value", "---- Select ----");
            DT = null;
            oCommon = null;           
        }
        #endregion

        #region Functions for Filling Dependent Combo box
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Uni_ID"></param>
        /// <param name="Faculty_ID"></param>
        private void FillFacultyCourseMoLrnPatternName(string Uni_ID,string Inst_ID, string Faculty_ID)
        {
            DD_Course.Items.Clear();
            DT = new DataTable();

            if (Inst_ID != string.Empty)
            {
                DT = oInst.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, Inst_ID, Faculty_ID);
            }
            else
            {
                DT = oCr.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, Faculty_ID);
            }
            
            oCommon = new clsCommon();
            oCommon.fillDropDown(DD_Course, DT, string.Empty, "Text", "Value", "---- Select ----");           

            if (oCommon != null)
            {
                oCommon = null;
            }
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="Uni_ID"></param>
       /// <param name="Fac_ID"></param>
       /// <param name="Cr_ID"></param>
       /// <param name="Molrn_ID"></param>
       /// <param name="Ptrn_ID"></param>
        private void FillBranch(long Uni_ID, string Inst_ID, long Fac_ID, long Cr_ID, long Molrn_ID, long Ptrn_ID)
        {
            DD_Branch.Items.Clear();
            DT = new DataTable();

            if (Inst_ID != string.Empty)
            {
                DT = oInst.AssignedConfirmedBranches(Convert.ToString(Uni_ID), Inst_ID, Convert.ToString(Fac_ID), Convert.ToString(Cr_ID),Convert.ToString(Molrn_ID), Convert.ToString(Ptrn_ID));
            }
            else
            {
                DT = oCr.ListCourseModeOfLearningPatternWiseLaunchedBranches(Uni_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID);
            }

            if (DT.Rows.Count > 0)
            {
                oCommon = new clsCommon();

                if (DT.Rows.Count == 1) 
                {
                    if (Convert.ToString(DT.Rows[0]["Text"]).ToUpper() == "NO BRANCH")
                    {
                        ListItem li = new ListItem();
                        li.Text = "No Branch Available";
                        li.Value = "0";
                        DD_Branch.Items.Add(li);
                        FillCoursePart(Uni_ID,pk_Institute_ID,  Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, 0);
                    }
                    else
                    {
                        oCommon.fillDropDown(DD_Branch, DT, "-1", "Text", "Value", "---- Select ----");
                    }
                }
                else
                {
                    oCommon.fillDropDown(DD_Branch, DT, "-1", "Text", "Value", "---- Select ----");
                }
               
                if (oCommon != null)
                {
                    oCommon = null;
                }
            }
            else
            {
                if (DD_Course.SelectedIndex == 0)
                {
                    ListItem li = new ListItem();
                    li.Text = "---- Select ----";
                    li.Value = "-1";
                    DD_Branch.Items.Add(li);
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = "No Branch Available";
                    li.Value = "0";
                    DD_Branch.Items.Add(li);
                }
            }           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Uni_ID"></param>
        /// <param name="Fac_ID"></param>
        /// <param name="Cr_ID"></param>
        /// <param name="Molrn_ID"></param>
        /// <param name="Ptrn_ID"></param>
        /// <param name="Brn_ID"></param>
        private void FillCoursePart(long Uni_ID,string Inst_ID, long Fac_ID, long Cr_ID, long Molrn_ID, long Ptrn_ID, long Brn_ID)
        {
            DD_CoursePart.Items.Clear();
            DT = new DataTable();
            if (Inst_ID != string.Empty)
            {
                DT = oInst.AssignedConfirmedCourseParts(Convert.ToString(Uni_ID), Inst_ID, Convert.ToString(Fac_ID), Convert.ToString(Cr_ID), Convert.ToString(Molrn_ID), Convert.ToString(Ptrn_ID), Convert.ToString(Brn_ID));
            }
            else
            {
                DT = oCr.ListCourseModeOfLearningPatternBrnWiseLaunchedCourseParts(Uni_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, Brn_ID);
            }
            oCommon = new clsCommon();
            oCommon.fillDropDown(DD_CoursePart, DT, string.Empty, "Text", "Value", "---- Select ----");
            if (oCommon != null)
            {
                oCommon = null;
            }           
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="Uni_ID"></param>
       /// <param name="CrPrDetails_ID"></param>
        private void FillPartTerm(long Uni_ID,string Inst_ID,string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID, string Brn_ID, long CrPrDetails_ID)
        {
            DD_Term.Items.Clear();
            DT = new DataTable();
            if (Inst_ID != string.Empty)
            {
                DT = oInst.AssignCoursePartTerm(Convert.ToString(Uni_ID),Inst_ID,Fac_ID,Cr_ID,Molrn_ID,Ptrn_ID,Brn_ID,Convert.ToString(CrPrDetails_ID));
            }
            else
            {
                DT = oCr.ListCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrCh(Uni_ID, CrPrDetails_ID);
            }
            oCommon = new clsCommon();
            oCommon.fillDropDown(DD_Term, DT, string.Empty, "Text", "Value", "---- Select ----");
            if (oCommon != null)
            {
                oCommon = null;
            }           
        }
        #endregion

        #region Function to split FacCrMoLrnPtrnID
        /// <summary>
        /// Spliting the value of Course DropDown into FacultyID , CourseID , MoLrnID and PatternID which are coming combined.
        /// </summary>
        private void getFacCrMoLrnPtrnID()
        {
            if (DD_Course.SelectedValue.ToString() != "0")
            {
                IDs_List = DD_Course.SelectedValue.ToString().Split('-');
                sFacID = long.Parse(IDs_List[0]);
                sCourseID = long.Parse(IDs_List[1]);
                sMoLrnID = long.Parse(IDs_List[2]);
                sPtrnID = long.Parse(IDs_List[3]);
            }            
        }
        #endregion

        #region Server Side Validations
        /// <summary>
        /// Sever side validations.
        /// </summary>
        private void ServerSideValidations()
        {
            oValidate = new Validation();
            oValidate.inputElement(txtElgFormNo.Text, Convert.ToString(TypeOfValidation.ContainsNumberHypen), "Eligibility Form No", null, null, null);
            oValidate.inputElement(txtPRN.Text, Convert.ToString(TypeOfValidation.ContainsNumberOnly), lblPRN.Text, null, null, null);
            oValidate.inputElement(txtLastName.Text, Convert.ToString(TypeOfValidation.ContainsCharacterOnly), "Last Name", null, null, null);
            oValidate.inputElement(txtFirstName.Text, Convert.ToString(TypeOfValidation.ContainsCharacterOnly), "First Name", null, null, null);
            oValidate.inputElement(txtOldPRN.Text, Convert.ToString(TypeOfValidation.ContainsNumberOnly), Label2.Text, null, null, null);
            oValidate.inputElement(txtAppFormNo.Text, Convert.ToString(TypeOfValidation.ContainsNumberHypen), "Application Form No", null, null, null);

            isValid  = oValidate.ValidateMe(lblErrorMessage);
        }
        #endregion
        
        #region Function to Add User's newly selected data in session
        /// <summary>
        /// Function to Add User's newly selected data in session.
        /// </summary>
        private void MemorizeInSession()
        {
            Session["sch_Faculty_ID"] = Convert.ToString(DDlFaculty.SelectedItem.Value);
            Session["sch_FacCrMoLrnPtrn_ID"] = Convert.ToString(DD_Course.SelectedItem.Value);
            Session["sch_Brn_ID"] = Convert.ToString(DD_Branch.SelectedItem.Value);
            Session["sch_CrPr_Details_ID"] = Convert.ToString(DD_CoursePart.SelectedItem.Value);
            Session["sch_CrPr_Term_ID"] = Convert.ToString(DD_Term.SelectedItem.Value);
        }
        #endregion

        #region Function to Display selected data from session
        /// <summary>
        /// Function to Display selected data from session.
        /// </summary>
        private void DisplyFromSession()
        {
            if (Session["sch_Faculty_ID"] != null && Convert.ToString(Session["sch_Faculty_ID"]) != "0")
            {
                DDlFaculty.SelectedValue = Convert.ToString(Session["sch_Faculty_ID"]);
            }
            if (Session["sch_FacCrMoLrnPtrn_ID"] != null && Convert.ToString(Session["sch_FacCrMoLrnPtrn_ID"]) != "0")
            {
                FillFacultyCourseMoLrnPatternName(UniId.ToString(),pk_Institute_ID, Convert.ToString(Session["sch_Faculty_ID"]));
                DD_Course.SelectedValue = Convert.ToString(Session["sch_FacCrMoLrnPtrn_ID"]);
               
                // Call for Seting FacultyID , CourseID ,MoLrnID and PatternID.
                getFacCrMoLrnPtrnID();
            }

            if (Session["sch_Brn_ID"] != null && Convert.ToString(Session["sch_Brn_ID"]) != "-1")
            {
                // This will Fill Correspondance Branch Drop Down.
                FillBranch(UniId,pk_Institute_ID, sFacID, sCourseID, sMoLrnID, sPtrnID);
                DD_Branch.SelectedValue = Convert.ToString(Session["sch_Brn_ID"]);
            }

            if (Session["sch_CrPr_Details_ID"] != null && Convert.ToString(Session["sch_CrPr_Details_ID"]) != "0")
            {
                // This will Fill Correspondance Course Part Details Drop Down
                FillCoursePart(UniId,pk_Institute_ID, sFacID, sCourseID, sMoLrnID, sPtrnID,long.Parse(Convert.ToString(Session["sch_Brn_ID"])));
                DD_CoursePart.SelectedValue = Convert.ToString(Session["sch_CrPr_Details_ID"]);
            }

            if (Session["sch_CrPr_Term_ID"] != null && Convert.ToString(Session["sch_CrPr_Term_ID"]) != "0")
            {
                // This will Fill Correspondance Course Part Details Drop Down.
                FillPartTerm(UniId, pk_Institute_ID,Convert.ToString(sFacID), Convert.ToString(sCourseID), Convert.ToString(sMoLrnID), Convert.ToString(sPtrnID),Convert.ToString(Session["sch_Brn_ID"]) ,long.Parse(Convert.ToString(Session["sch_CrPr_Details_ID"])));
                DD_Term.SelectedValue = Session["sch_CrPr_Term_ID"].ToString();
            }
        }
        #endregion       
    }
    
}