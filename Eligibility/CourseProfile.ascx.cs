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

namespace StudentRegistration.Eligibility
{
    public partial class CourseProfile : System.Web.UI.UserControl
    {
        #region Variable declaration
        DataTable crTable = new DataTable();
        string uniID = string.Empty;
        string year = string.Empty;
        string studentID = string.Empty;
        #endregion

        #region Set Properties
        public string UniID
        {
            set
            {
                uniID = value;
            }
        }
        public string Year
        {
            set
            {
                year = value;
            }
        }
        public string StudentID
        {
            set
            {
                studentID = value;
            }
        }
        #endregion

        #region Page Load
        /// <summary>
        /// Page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            BindRepeater();
        }
        #endregion

        #region Function to Bind Repeater
        /// <summary>
        /// Repeater data binding method.
        /// </summary>
        /// <param name="crTable"></param>
        private void BindRepeater()
        {
            clsEligibilityDBAccess oclsEligibilityDBAccess = new clsEligibilityDBAccess();
            crTable = oclsEligibilityDBAccess.GetStudentsCourseProfile(uniID, year, studentID);
            if (crTable != null && crTable.Rows.Count > 0)
            {
                RptCourse.DataSource = crTable;
                RptCourse.DataBind();
                divCourseProfile.Visible = true;
            }
            else
            {
                divCourseProfile.Visible = false;
            }
        }
        #endregion

        #region Item data bound event of Repeater
        /// <summary>
        /// Repeater item data bound event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void RptCourse_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                if ((e.Item.ItemIndex - 1) > -1)
                {
                    string sName = Convert.ToString(crTable.Rows[e.Item.ItemIndex]["CourseName"]);

                    // This will display course name only once against all its course part.  
                    if (sName == Convert.ToString(crTable.Rows[e.Item.ItemIndex - 1]["CourseName"]))
                    {
                        e.Item.FindControl("trHeader").Visible = false;
                        e.Item.FindControl("tdHeader").Visible = false;
                        e.Item.FindControl("separator").Visible = false;
                    }

                    // This will display separator between each course.
                    if (sName != Convert.ToString(crTable.Rows[e.Item.ItemIndex - 1]["CourseName"]))
                    {
                        e.Item.FindControl("separator").Visible = true;
                    }
                }
            }
        }
        #endregion
    }
}