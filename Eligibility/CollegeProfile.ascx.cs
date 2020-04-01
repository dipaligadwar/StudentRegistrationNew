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
    public partial class CollegeProfile : System.Web.UI.UserControl
    {
        #region Variable declaration
        DataTable clTable = new DataTable();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            BindRepeater();
        }

        #region Function to Bind Repeater
        /// <summary>
        /// Repeater data binding method.
        /// </summary>
        private void BindRepeater()
        {
            clsEligibilityDBAccess oclsEligibilityDBAccess = new clsEligibilityDBAccess();
            clTable = oclsEligibilityDBAccess.GetStudentsCollegeProfile(uniID, year, studentID);
            if (clTable != null && clTable.Rows.Count > 0)
            {
                RptCollege.DataSource = clTable;
                RptCollege.DataBind();
                divCollegeProfile.Visible = true;
            }
            else
            {
                divCollegeProfile.Visible = false;
            }
        }
        #endregion

        #region Item data bound event of Repeater
        /// <summary>
        /// Repeater item data bound event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void RptCollege_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                if ((e.Item.ItemIndex - 1) > -1)
                {
                    string sName = Convert.ToString(clTable.Rows[e.Item.ItemIndex]["CollegeName"]);

                    // This will display college name only once against all its course part.  
                    if (sName == Convert.ToString(clTable.Rows[e.Item.ItemIndex - 1]["CollegeName"]))
                    {
                        e.Item.FindControl("trHeader").Visible = false;
                        //e.Item.FindControl("tdHeader").Visible = false;
                        e.Item.FindControl("separator").Visible = false;
                    }

                    // This will display separator between each course.
                    if (sName != Convert.ToString(clTable.Rows[e.Item.ItemIndex - 1]["CollegeName"]))
                    {
                        e.Item.FindControl("separator").Visible = true;
                    }
                }
            }
        }
        #endregion
    }
}