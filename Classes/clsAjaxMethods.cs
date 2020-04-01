using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Classes
{
    public class clsAjaxMethods
    {

        [Ajax.AjaxMethod]
        public HtmlSelect FillCourseName(string Uni_ID, string FacultyID, string CourseNm)
        {

            DataTable dtCr = new DataTable();
            dtCr = CourseRepository.FacultyWiseCourse(Convert.ToInt64(Uni_ID), Convert.ToInt64(FacultyID));
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
        public HtmlSelect FillModeOfLearning(string Uni_ID, string FacultyID, string CourseNmID, string ModOfLrn)
        {

            DataTable dtMl = new DataTable();
            dtMl = CourseRepository.coursewiseModeOfLearnings(Uni_ID, FacultyID, CourseNmID);
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
        public HtmlSelect FillCoursePattern(string Uni_ID, string ModOfLrnID, string CrPattern)
        {

            DataTable dtCptrn = new DataTable();
            dtCptrn = CourseRepository.coursewisePatternList(Uni_ID, ModOfLrnID);
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

        [Ajax.AjaxMethod]
        public HtmlSelect FillDistrict(string StateID, string District, int i)
        {

            DataTable dt = new DataTable();
            dt = InstituteRepository.stateWiseDistricts(StateID, "E");
            HtmlSelect hDistrict = new HtmlSelect();
            hDistrict.ID = District;
            hDistrict.Attributes.Add("class", "selectbox");
            if (i == 0) //for all drop downs except for 'OfficeIncharge' in OtherInformation
                hDistrict.Attributes.Add("onchange", "FillTalukaDD(this.value);");
            else      //for drop down of 'OfficeIncharge' in OtherInformation
                hDistrict.Attributes.Add("onchange", "FillTalukaDDSec(this.value);");
            clsCommon common = new clsCommon();
            common.fillDropDown(hDistrict, dt, "", "Text", "Value", "---- Select ----");
            dt.Dispose();
            return hDistrict;

        }
        //Function to fill the Taluka drop down depending on the selected District
        [Ajax.AjaxMethod]
        public HtmlSelect FillTaluka(string DistrictID, string Taluka, int i)
        {

            DataTable dt = new DataTable();
            dt = InstituteRepository.displayTalukaWithinDistrict(DistrictID, "E");
            HtmlSelect hTaluka = new HtmlSelect();
            hTaluka.ID = Taluka;
            hTaluka.Attributes.Add("class", "selectbox");
            if (i == 0)  //for all drop downs except for 'OfficeIncharge' in OtherInformation
                hTaluka.Attributes.Add("onblur", "setTaluka(this.value);");
            else        //for drop down of 'OfficeIncharge' in OtherInformation
                hTaluka.Attributes.Add("onblur", "setTalukaSec(this.value);");
            clsCommon common = new clsCommon();
            common.fillDropDown(hTaluka, dt, "", "Text", "Value", "---- Select ----");
            dt.Dispose();
            return hTaluka;

        }

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

    }

}
