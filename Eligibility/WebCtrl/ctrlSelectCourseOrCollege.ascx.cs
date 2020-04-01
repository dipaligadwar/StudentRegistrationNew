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


namespace StudentRegistration.Eligibility.WebCtrl
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        CourseRepository crRepository = new CourseRepository();
        clsCommon Common = new clsCommon();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fnFirstFill();
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                Common.fillDropDown(ddlAcademicYr, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                ddlAcademicYr.SelectedIndex = 0;
            }
        }

        #region Fetch University Wise Faculty List

        public void FetchUniversityWiseFacultyList(DropDownList ddlFacDesc)
        {

            DataTable listFaculty = crRepository.LaunchedUniversityWiseFacultyList(Convert.ToInt64(clsGetSettings.UniversityID.ToString()));
            try
            {
                if (listFaculty != null)
                {
                    ddlFacDesc.DataSource = listFaculty;
                    ddlFacDesc.DataTextField = "text";
                    ddlFacDesc.DataValueField = "value";
                    ddlFacDesc.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--- Select ---", "-1");
                    ddlFacDesc.Items.Insert(0, li);


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region fnFirstFill

        private void fnFirstFill()
        {
            hidLevelFlag.Value = "7";
            FetchUniversityWiseFacultyList(ddlFacDesc);
            //FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);        

        }

        #endregion
    }
}