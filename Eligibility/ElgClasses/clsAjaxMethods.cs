using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Classes;

namespace StudentRegistration.Eligibility.ElgClasses
{
    public class clsAjaxMethods
    {
        CourseRepository crRepository = new CourseRepository();

        /*[Ajax.AjaxMethod]
        public HtmlSelect FillCourseName(string Uni_ID, string FacultyID, string CourseNm)
        {

            DataTable dtCr = new DataTable();
            dtCr = CourseRepository.ListFacultyWiseLaunchedCourses(Convert.ToInt64(Uni_ID), Convert.ToInt64(FacultyID));
            HtmlSelect hCourseNm = new HtmlSelect();
            hCourseNm.ID = CourseNm;
            hCourseNm.Attributes.Add("class", "selectbox");
            hCourseNm.Attributes.Add("onchange", "FillMoLrnDD(this.value);");
            clsCommon common = new clsCommon();
            common.fillDropDown(hCourseNm, dtCr, "", "Text", "value", "---- Select ----");
            dtCr.Dispose();
            return hCourseNm;

        }
        //Function to fill the Mode of learning drop down depending on the selected Course Name
        [Ajax.AjaxMethod]
        public HtmlSelect FillModeOfLearning(long Uni_ID, long FacultyID, long CourseNmID, string ModOfLrn)
        {

            DataTable dtMl = new DataTable();
            dtMl = CourseRepository.ListCourseWiseLaunchedModeOfLearning(Uni_ID, FacultyID, CourseNmID);
            HtmlSelect hModOfLearning = new HtmlSelect();
            hModOfLearning.ID = ModOfLrn;
            hModOfLearning.Attributes.Add("class", "selectbox");
            hModOfLearning.Attributes.Add("onchange", "FillCrMoLrnWisePatternDD(this.value);");
            clsCommon common = new clsCommon();
            common.fillDropDown(hModOfLearning, dtMl, "", "Text", "value", "---- Select ----");
            dtMl.Dispose();
            return hModOfLearning;

        }
        //Function to fill the Course Pattern drop down depending on the selected Mode of Learning
        [Ajax.AjaxMethod]
        public HtmlSelect FillCoursePattern(long Uni_ID, long FacultyID, long CourseNmID,long ModOfLrnID, string CrPattern)
        {

            DataTable dtCptrn = new DataTable();
            dtCptrn = CourseRepository.ListCourseModeOfLearningWiseLaunchedCoursePatterns(Uni_ID, FacultyID, CourseNmID, ModOfLrnID);
            HtmlSelect hCrPattern = new HtmlSelect();
            hCrPattern.ID = CrPattern;
            hCrPattern.Attributes.Add("class", "selectbox");
           // hCrPattern.Attributes.Add("onchange", "FillCrPartDD(this.value);");
            hCrPattern.Attributes.Add("onblur", "SetHiddenCoursePattern(this.value);");
            clsCommon common = new clsCommon();
            common.fillDropDown(hCrPattern, dtCptrn, "", "Text", "value", "---- Select ----");
            dtCptrn.Dispose();
            return hCrPattern;

        }
        */

        [Ajax.AjaxMethod()]
        public HtmlSelect FillDistrict(string StateID, string District, int i)
        {

            DataTable dt = new DataTable();
            //dt = InstituteRepository.stateWiseDistricts(StateID, "E");
            dt = clsInstitute.stateWiseDistricts(StateID, "E");
            HtmlSelect hDistrict = new HtmlSelect();
            hDistrict.ID = District;
            hDistrict.Attributes.Add("class", "selectbox");
            if (i == 0) //for all drop downs except for 'OfficeIncharge' in OtherInformation
                hDistrict.Attributes.Add("onchange", "FillTalukaDD(this.value);");
            else      //for drop down of 'OfficeIncharge' in OtherInformation
                hDistrict.Attributes.Add("onchange", "FillTalukaDDSec(this.value);");
            clsCommon common = new clsCommon();
            common.fillDropDown(hDistrict, dt, "", "Text", "Value", "--- Select ---");
            dt.Dispose();
            return hDistrict;

        }
        //Function to fill the Taluka drop down depending on the selected District
        [Ajax.AjaxMethod]
        public HtmlSelect FillTaluka(string DistrictID, string Taluka, int i)
        {

            DataTable dt = new DataTable();
            //dt = InstituteRepository.displayTalukaWithinDistrict(DistrictID, "E");
            dt = clsInstitute.displayTalukaWithinDistrict(DistrictID, "E");
            HtmlSelect hTaluka = new HtmlSelect();
            hTaluka.ID = Taluka;
            hTaluka.Attributes.Add("class", "selectbox");
            if (i == 0)  //for all drop downs except for 'OfficeIncharge' in OtherInformation
                hTaluka.Attributes.Add("onblur", "setTaluka(this.value);");
            else        //for drop down of 'OfficeIncharge' in OtherInformation
                hTaluka.Attributes.Add("onblur", "setTalukaSec(this.value);");
            clsCommon common = new clsCommon();
            common.fillDropDown(hTaluka, dt, "", "Text", "Value", "--- Select ---");
            dt.Dispose();
            return hTaluka;

        }

        /* Commented by Shivani on 08-08-2008
        //Function to fill the Course Part drop down depending on the selected Course part
        [Ajax.AjaxMethod]
        public HtmlSelect FillCoursePart(string UniID,string InstID,string CrMoLrnPtrnID, string CrPart)
        {

            DataTable dtCp = new DataTable();
            //dtCp = CourseRepository.coursewiseCourseParts(CrMoLrnPtrnID);
               dtCp = InstituteRepository.Get_AllCoursePartOnly(UniID, InstID,CrMoLrnPtrnID);
            HtmlSelect hCrPart = new HtmlSelect();
            hCrPart.ID = CrPart;
            hCrPart.Attributes.Add("class", "selectbox");
            hCrPart.Attributes.Add("onchange", "setCrPart(this.value);");
            clsCommon common = new clsCommon();
            common.fillDropDown(hCrPart, dtCp, "", "Text", "value", "---- Select ----");
            dtCp.Dispose();
            return hCrPart;
        }
         

        //Added By Jyotsna
        [Ajax.AjaxMethod]
        public HtmlSelect FillAssignedCourses(string Uni_ID, string InstId, string FacultyID, string CourseNm)
        {
            DataTable dtCr = new DataTable();
            dtCr = InstituteRepository.InstituteWiseAllAssignedCourse(Uni_ID, InstId, FacultyID);
            HtmlSelect hCourseNm = new HtmlSelect();
            hCourseNm.ID = CourseNm;
            hCourseNm.Attributes.Add("class", "selectbox");
            hCourseNm.Attributes.Add("onchange", "FillCrPrDD(this.value);");
            clsCommon common = new clsCommon();
            common.fillDropDown(hCourseNm, dtCr, "", "Text", "value", "---- Select ----");
            dtCr.Dispose();
            return hCourseNm;

        }
         */
        /*
        #region FetchCourseMoLrnPtrnWiseBranchList

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseMoLrnPtrnWiseBranchList(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string HtmlSelCrBrnID)
        {
            //DataTable dt = CourseRepository.ListCourseModeOfLearningPatternWiseLaunchedBranches(Convert.ToInt32(UniID), Convert.ToInt32(FacID), Convert.ToInt32(CrID), Convert.ToInt32(MoLrnID), Convert.ToInt32(PtrnID));
            DataTable dt = clsInstitute.Get_CourseModeofLearningPatternWiseBranchList(UniID, InstID, FacID, CrID, MoLrnID, PtrnID );
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrBrnID;
            htmlSel.Attributes.Add("class", "selectbox");


            htmlSel.Attributes.Add("onchange", "setValue('hidBrnID',this.value);FetchCourseMoLrnPtrnBrnWiseCoursePartList('tdCrPrDesc', hidUniID.value, hidFacID.value, hidCrID.value, hidMoLrnID.value, hidPtrnID.value, hidBrnID.value, 'ddlCrPrDesc'); ");//ClearDropDowns(5," + levelflag + ");");
            
            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "text";
            htmlSel.DataValueField = "value";
            htmlSel.DataBind();
            if (dt.Rows.Count > 0)
            {
                ListItem li = new ListItem("--- Select ---", "-1");
                htmlSel.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem(" No Branch ", "0");
                htmlSel.Items.Insert(0, li);

            }
            return htmlSel;
        }

        #endregion*/
        #region Fetch Faculty Wise Launched Course List(Launched) - By Amit

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchFacultyWiseLaunchedCourseList(long UniID, long FacID, string HtmlSelCrID, int LevelFlag) //Developed by Madhu
        {
            DataTable dt = crRepository.ListFacultyWiseLaunchedCourses(UniID, FacID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrID;
            htmlSel.Attributes.Add("class", "selectbox");
            if (LevelFlag <= 2)
            {
                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidCrClientID).id,this.value);");
            }
            else
            {
                // htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidCrClientID).id,this.value);FetchCourseWiseLaunchedModeOfLearningList('tdModeLrnDesc',document.getElementById(hidUniClientID).value,document.getElementById(hidFacClientID).value,document.getElementById(hidCrClientID).value,document.getElementByID(hidMoLrnClientID).id," + LevelFlag + ");ClearDropDowns(2," + LevelFlag + ");");
                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidCrClientID).id,this.value);FetchCourseWiseLaunchedModeOfLearningList('tdModeLrnDesc',document.getElementById(hidUniClientID).value,document.getElementById(hidFacClientID).value,document.getElementById(hidCrClientID).value, ddlModeLrnDescClient ," + LevelFlag + ");ClearDropDowns(2," + LevelFlag + ");");
                //document.getElementById(hidCrPrClientID).value = val;
            }
            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "Text";
            htmlSel.DataValueField = "Value";
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);
            return htmlSel;

        }

        #endregion

        #region Fetch Course Wise Mode Of Learning List(Launched) - By Amit

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseWiseLaunchedModeOfLearningList(long UniID, long FacID, long CrID, string HtmlSelMoLrnID, int LevelFlag)
        {


            DataTable dt = crRepository.ListCourseWiseLaunchedModeOfLearning(UniID, FacID, CrID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelMoLrnID;
            htmlSel.Attributes.Add("class", "selectbox");
            if (LevelFlag <= 3)
            {
                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidMoLrnClientID).id,this.value);");
            }
            else
            {
                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidMoLrnClientID).id,this.value);FetchCourseMoLrnwiseLaunchedCoursePatternsList('tdCrPtrnDesc', document.getElementById(hidUniClientID).value,document.getElementById(hidFacClientID).value, document.getElementById(hidCrClientID).value, document.getElementById(hidMoLrnClientID).value, ddlCrPtrnDescClient , " + LevelFlag + ");ClearDropDowns(3," + LevelFlag + ");");
            }
            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "Text";
            htmlSel.DataValueField = "Value";
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);
            return htmlSel;

        }

        #endregion

        #region Fetch Course Mode Of Learning Wise Course Pattern List(Launched) - By Amit

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseMoLrnwiseLaunchedCoursePatternsList(long UniID, long FacID, long CrID, long MoLrnID, string HtmlSelCrPtrnID, int LevelFlag)
        {

            DataTable dt = crRepository.ListCourseModeOfLearningWiseLaunchedCoursePatterns(UniID, FacID, CrID, MoLrnID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrPtrnID;
            htmlSel.Attributes.Add("class", "selectbox");
            if (LevelFlag <= 4)
            {

                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidPtrnClientID).id,this.value);");
            }
            else
            {
                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidPtrnClientID).id,this.value);FetchCourseMoLrnPtrnWiseLaunchedBranchList('tdCrBrnDesc',document.getElementById(hidUniClientID).value,document.getElementById(hidFacClientID).value,document.getElementById(hidCrClientID).value, document.getElementById(hidMoLrnClientID).value, document.getElementById(hidPtrnClientID).value, ddlCrBrnDescClient ," + LevelFlag + ");ClearDropDowns(4," + LevelFlag + ");");
            }

            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "Text";
            htmlSel.DataValueField = "Value";
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);
            return htmlSel;
        }

        #endregion

        #region Fetch Course Mode Of Learning Pattern Wise Branch List(Launched) - By Amit

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseMoLrnPtrnWiseLaunchedBranchList(long UniID, long FacID, long CrID, long MoLrnID, long PtrnID, string HtmlSelCrBrnID, int LevelFlag)
        {
            DataTable dt = crRepository.ListCourseModeOfLearningPatternWiseLaunchedBranches(UniID, FacID, CrID, MoLrnID, PtrnID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrBrnID;
            htmlSel.Attributes.Add("class", "selectbox");
            if (LevelFlag <= 5)
            {
                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidBrnClientID).id,this.value);");
            }
            else
            {
                //htmlSel.Attributes.Add("onchange", "setValue('hidBrnID',this.value);FetchCourseMoLrnPtrnBrnWiseLaunchedCoursePartList('tdCrPrDesc',hidUniID.value,hidFacID.value,hidCrID.value, hidMoLrnID.value, hidPtrnID.value, hidBrnID.value, 'ddlCrPrDesc'," + LevelFlag + ");ClearDropDowns(5," + LevelFlag + ");");
                //htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidBrnClientID).id,this.value);");
                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidBrnClientID).id,this.value);FetchCourseMoLrnPtrnBrnWiseLaunchedCoursePartList('tdCrPrDesc',document.getElementById(hidUniClientID).value,document.getElementById(hidFacClientID).value,document.getElementById(hidCrClientID).value, document.getElementById(hidMoLrnClientID).value, document.getElementById(hidPtrnClientID).value,document.getElementById(hidBrnClientID).value, ddlCrPrDetailsDescClient ," + LevelFlag + ");ClearDropDowns(5," + LevelFlag + ");");
            }


            //htmlSel.Attributes.Add("onchange", "setBranchDetails(this.value);");            
            htmlSel.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                htmlSel.DataTextField = "Text";
                htmlSel.DataValueField = "Value";
                htmlSel.DataBind();
                ListItem li = new ListItem("--- Select ---", "-1");
                htmlSel.Items.Insert(0, li);

            }
            else
            {
                htmlSel.DataBind();
                ListItem li = new ListItem("--- No Branch ---", "-1");
                htmlSel.Items.Insert(0, li);
            }

            return htmlSel;
        }

        #endregion

        #region Fetch Course Mode Of Learning Pattern Branch Wise Course Part List(Launched) - By Amit

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseMoLrnPtrnBrnWiseLaunchedCoursePartList(long UniID, long FacID, long CrID, long MoLrnID, long PtrnID, long BrnID, string HtmlSelCrPrID, int LevelFlag)
        {

            DataTable dt = crRepository.ListCourseModeOfLearningPatternBrnWiseLaunchedCourseParts(UniID, FacID, CrID, MoLrnID, PtrnID, BrnID);


            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrPrID;
            htmlSel.Attributes.Add("class", "selectbox");
            if (LevelFlag <= 6)
            {
                htmlSel.Attributes.Add("onchange", "setCrPart(document.getElementById(hidCrPrDetailsIDClientID).id,this.value);");
                //htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidCrPrDetailsIDClientID).id,this.value);"); 
                // htmlSel.Attributes.Add("onchange", "setValue(document.getElementByID(hidCrPrDetailsIDClientID).id,this.value);");//FetchCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrChList('tdCrPrChDesc',document.getElementById(hidUniClientID).value, document.getElementById(hidCrPrDetailsIDClientID).value, ddlCrPrChDescClient," + LevelFlag + ");ClearDropDowns(6," + LevelFlag + ");");  

            }
            else
            {
                //htmlSel.Attributes.Add("onchange", "setValue('hidCrPrDetailsIDClientID',this.value);FetchCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrChList('tdCrPrChDesc',document.getElementById(hidUniClientID).value, document.getElementById(hidCrPrDetailsIDClientID).value, 'ddlCrPrChDesc'," + LevelFlag + ");ClearDropDowns(6," + LevelFlag + ");");
                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidCrPrDetailsIDClientID).id,this.value);FetchCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrChList('tdCrPrChDesc',document.getElementById(hidUniClientID).value, document.getElementById(hidCrPrDetailsIDClientID).value, ddlCrPrChDescClient," + LevelFlag + ");ClearDropDowns(6," + LevelFlag + ");");
            }
            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "Text";
            htmlSel.DataValueField = "Value";
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);
            return htmlSel;

        }
        #endregion

        #region  Fetch Course Mode Of Learning Pattern Branch Coursepart Wise Course Part Child List(Launched) - By Shivani

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrChList(long UniID, long CrPrDetailsID, string HtmlSelCrPrChID, int LevelFlag)
        {
            DataTable dt = crRepository.ListCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrCh(UniID, CrPrDetailsID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrPrChID;
            htmlSel.Attributes.Add("class", "selectbox");
            if (LevelFlag <= 7)
            {
                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidCrPrChIDClientID).id,this.value);");
            }
            else
            {
            }
            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "Text";
            htmlSel.DataValueField = "Value";
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);
            return htmlSel;

        }

        #endregion

        #region FetchCourseWiseCoursePartList

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseWiseCoursePartList(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string HtmlSelCrBrnID)
        {

            DataTable dt = clsInstitute.Get_AllCoursePartOnly(UniID, InstID, FacID, CrID, MoLrnID, PtrnID, BrnID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrBrnID;
            htmlSel.Attributes.Add("class", "selectbox");


            // htmlSel.Attributes.Add("onchange", "FetchCourseMoLrnPtrnBrnWiseCoursePartList('tdCrPrDesc', hidUniID.value, hidFacID.value, hidCrID.value, hidMoLrnID.value, hidPtrnID.value, hidBrnID.value, 'ddlCrPrDesc'); ");//ClearDropDowns(5," + levelflag + ");");

            //htmlSel.Attributes.Add("onchange", "setValue('hidCrPrID',this.value);");
            htmlSel.Attributes.Add("onchange", "setCrPart(this.value);");
            //hCrPart.Attributes.Add("onchange", "setCrPart(this.value);");
            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "text";
            htmlSel.DataValueField = "value";
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);

            return htmlSel;
        }
        #endregion

        #region Fill College List

        [Ajax.AjaxMethod()]
        public DataTable FillCollegeList()
        {
            DataTable dtCollege;
            clsEligibilityDBAccess oclsEligibilityDBAccess = new clsEligibilityDBAccess();
            int uniID = Convert.ToInt32(clsGetSettings.UniversityID);
            try
            {
                dtCollege = oclsEligibilityDBAccess.ListColleges(uniID);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return dtCollege;
        }
        #endregion

        #region Fetch University Wise Faculty List
        [Ajax.AjaxMethod()]
        public DataTable FetchUniversityWiseFacultyList(string uni_id)
        {

            DataTable listFaculty = crRepository.LaunchedUniversityWiseFacultyList(Convert.ToInt64(uni_id));
            return listFaculty;
        }

        #endregion

        #region Fetch College wise Assigned Confirmed Faculties

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCollegeWiseConfirmedFacultyList(string UniID, string InstID, string ddlFacDescID)
        {
            InstituteRepository oInstituteRepository = new InstituteRepository();
            HtmlSelect htmlSel = new HtmlSelect();
            DataTable listFaculty = oInstituteRepository.AssignedConfirmedFaculties(UniID, InstID.Split('|')[0]);
            try
            {
                if (listFaculty != null)
                {
                    htmlSel.ID = ddlFacDescID;
                    htmlSel.Attributes.Add("class", "selectbox");
                    htmlSel.Attributes.Add("OnSelectedIndexChanged", "ddlFacDesc_SelectedIndexChanged");
                    htmlSel.DataSource = listFaculty;
                    htmlSel.DataTextField = "Fac_Desc";
                    htmlSel.DataValueField = "pk_Fac_ID";
                    htmlSel.DataBind();
                    ListItem li = new ListItem("--- Select ---", "-1");
                    htmlSel.Items.Insert(0, li);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return htmlSel;
        }

        #endregion

        #region New Methods for Paper Exemption

        #region Fetch Faculty Wise Launched Course + Pattern + MOL List(Launched)

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchFacultyWiseLaunchedCoursePtrnMOLList(long UniID, long FacID, string HtmlSelCrID, int LevelFlag)
        {
            DataTable dt = crRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(UniID.ToString(), FacID.ToString());
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrID;
            htmlSel.Attributes.Add("class", "selectbox");

            htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidCrClientID).id,this.value);FillBranchList(this.value);ClearDropDowns(2," + LevelFlag + ");");

            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "Text";
            htmlSel.DataValueField = "Value";
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);
            return htmlSel;
        }

        #endregion

        #region Fetch Combined Course-Mode Of Learning-Pattern Wise Branch List(Launched)

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseMoLrnPtrnWiseLaunchedBranchListCombined(long UniID, long FacID, long CrID, long MoLrnID, long PtrnID, string HtmlSelCrBrnID, int LevelFlag)
        {
            DataTable dt = crRepository.ListCourseModeOfLearningPatternWiseLaunchedBranches(UniID, FacID, CrID, MoLrnID, PtrnID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrBrnID;
            htmlSel.Attributes.Add("class", "selectbox");
            htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidBrnClientID).id,this.value);FillCoursePart(this.value);ClearDropDowns(3," + LevelFlag + ");");
            htmlSel.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                htmlSel.DataTextField = "Text";
                htmlSel.DataValueField = "Value";
                htmlSel.DataBind();
                ListItem li = new ListItem("--- Select ---", "-1");
                htmlSel.Items.Insert(0, li);

            }
            else
            {
                htmlSel.DataBind();
                ListItem li = new ListItem("--- No Branch ---", "-1");
                htmlSel.Items.Insert(0, li);
            }

            return htmlSel;
        }

        #endregion

        #region  Fetch Combined Course-Mode Of Learning-Pattern-Branch-Coursepart Wise Course Part Child List(Launched) - NEW

        #region Fetch Combined Course-Mode Of Learning-Pattern-Branch Wise Cr Parts List(Launched)

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseMoLrnPtrnWiseLaunchedBranchWiseCrPartsCombined(long UniID, long FacID, long CrID, long MoLrnID, long PtrnID, long BrnID, string HtmlSelCrBrnID, int LevelFlag)
        {
            DataTable dt = crRepository.ListCourseModeOfLearningPatternBrnWiseLaunchedCourseParts(UniID, FacID, CrID, MoLrnID, PtrnID, BrnID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrBrnID;
            htmlSel.Attributes.Add("class", "selectbox");
            if (LevelFlag <= 5)
            {
                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hid_CrPrDet_id).id,this.value);FillCrPartChild(this.value);ClearDropDowns(5," + LevelFlag + ");");
            }
            else
            {
                //htmlSel.Attributes.Add("onchange", "setValue('hidBrnID',this.value);FetchCourseMoLrnPtrnBrnWiseLaunchedCoursePartList('tdCrPrDesc',hidUniID.value,hidFacID.value,hidCrID.value, hidMoLrnID.value, hidPtrnID.value, hidBrnID.value, 'ddlCrPrDesc'," + LevelFlag + ");ClearDropDowns(5," + LevelFlag + ");");
                //htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidBrnClientID).id,this.value);");
                htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hid_CrPrDet_id).id,this.value);FillCrPartChild(this.value);ClearDropDowns(5," + LevelFlag + ");");
            }


            //htmlSel.Attributes.Add("onchange", "setBranchDetails(this.value);");            
            htmlSel.DataSource = dt;

            htmlSel.DataTextField = "Text";
            htmlSel.DataValueField = "Value";
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);


            return htmlSel;
        }

        #endregion

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrChListNew(long UniID, long CrPrDetailsID, string HtmlSelCrPrChID, int LevelFlag)
        {
            DataTable dt = crRepository.ListCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrCh(UniID, CrPrDetailsID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrPrChID;
            htmlSel.Attributes.Add("class", "selectbox");
            if (LevelFlag <= 7)
            {
                htmlSel.Attributes.Add("onchange", "setValue(hid_CrPr_DetCh_ID,this.value);return setCrPrChName();");
            }
            else
            {
            }
            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "Text";
            htmlSel.DataValueField = "Value";
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);
            return htmlSel;

        }

        #region Fetch College wise Assigned Confirmed Faculties - PE

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCollegeWiseConfirmedFacultyListNew(string UniID, string InstID, string ddlFacDescID)
        {
            InstituteRepository oInstituteRepository = new InstituteRepository();
            HtmlSelect htmlSel = new HtmlSelect();
            DataTable listFaculty = oInstituteRepository.AssignedConfirmedFaculties(UniID, InstID.Split('|')[0]);
            try
            {
                if (listFaculty != null)
                {
                    htmlSel.ID = ddlFacDescID;
                    htmlSel.Attributes.Add("class", "selectbox");
                    htmlSel.Attributes.Add("onchange", "setValue(hid_Fac_id,this.value);FillCourse(this.value);ClearDropDowns(1,5)");

                    htmlSel.DataSource = listFaculty;
                    htmlSel.DataTextField = "Fac_Desc";
                    htmlSel.DataValueField = "pk_Fac_ID";
                    htmlSel.DataBind();
                    ListItem li = new ListItem("--- Select ---", "-1");
                    htmlSel.Items.Insert(0, li);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return htmlSel;
        }

        #endregion

        #endregion

        #endregion

        #region * Added Cr Pr Term * changes for Bulk Process  - Registered and Unregistered

        #region FetchCourseWiseCoursePartList

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseWiseCoursePartListNew(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string HtmlSelCrBrnID)
        {

            DataTable dt = clsInstitute.Get_AllCoursePartOnly(UniID, InstID, FacID, CrID, MoLrnID, PtrnID, BrnID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrBrnID;
            htmlSel.Attributes.Add("class", "selectbox");
            htmlSel.Attributes.Add("onchange", "setValue(document.getElementById(hidCrPrClientID).id,this.value);FetchCoursePartWiseCoursePartChildList('tbCrPrCh',document.getElementById(hidUniClientID).value, document.getElementById(hidInstClientID).value,document.getElementById(hidFacClientID).value+'-'+document.getElementById(hidCrClientID).value+'-'+document.getElementById(hidMoLrnClientID).value+'-'+document.getElementById(hidPtrnClientID).value+'-'+document.getElementById(hidBrnClientID).value+'-'+document.getElementById(hidCrPrClientID).value,'ctl00_ContentPlaceHolder1_DD_CoursePartTerm'),ClearDropDowns(0,1);");
            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "text";
            htmlSel.DataValueField = "value";
            htmlSel.Style.Add("width", "230px");
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);

            return htmlSel;
        }

        #endregion

        #region FetchCoursePartWiseCoursePartChildList

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCoursePartWiseCoursePartChildList(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetails_ID, string HtmlSelCrBrnID)
        {
            InstituteRepository oInstituteRepository = new InstituteRepository();
            DataTable dt = oInstituteRepository.AssignCoursePartTerm(UniID, InstID, FacID, CrID, MoLrnID, PtrnID, BrnID, CrPrDetails_ID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrBrnID;
            htmlSel.Attributes.Add("class", "selectbox");


            // htmlSel.Attributes.Add("onchange", "FetchCourseMoLrnPtrnBrnWiseCoursePartList('tdCrPrDesc', hidUniID.value, hidFacID.value, hidCrID.value, hidMoLrnID.value, hidPtrnID.value, hidBrnID.value, 'ddlCrPrDesc'); ");//ClearDropDowns(5," + levelflag + ");");

            //htmlSel.Attributes.Add("onchange", "setValue('hidCrPrID',this.value);");
            htmlSel.Attributes.Add("onchange", "setCrPartTerm(this.value);");
            //hCrPart.Attributes.Add("onchange", "setCrPart(this.value);");
            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "text";
            htmlSel.DataValueField = "value";
            htmlSel.Style.Add("width", "230px");
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);

            return htmlSel;
        }
        #endregion

        #endregion
    }
}
