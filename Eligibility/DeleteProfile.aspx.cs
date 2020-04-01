using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Classes;
using System.Web.UI.HtmlControls;

namespace StudentRegistration.Eligibility
{
    public partial class DeleteProfile : System.Web.UI.Page
    {
        #region Declaration
        clsEligibilityDBAccess oclsEligibilityDBAccess;
        clsCommon common = null;
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidUniID.Value = clsGetSettings.UniversityID;
                hid_pindex.Value = "0";
                GetRecords(hid_pindex.Value);
            }

            lblPageHead.Text = "Delete Dangling Students";
            //lblSubHeader.Text = hidCollName.Value + " [" + hidCollCode.Value + "]";
        }
        #endregion

        #region Function Get records
        /// <summary>
        /// Get records of Dangling students
        /// </summary>
        /// <param name="p_index">Paging index</param>
        void GetRecords(string p_index)
        {
            oclsEligibilityDBAccess = new clsEligibilityDBAccess();
            DataTable dt = oclsEligibilityDBAccess.GetDanglingStudent(hidUniID.Value, p_index);
            if (dt != null && dt.Rows.Count > 0)
            {
                GV_DeleteProfile.DataSource = dt;
                GV_DeleteProfile.DataBind();
                GV_DeleteProfile.Visible = true;
                lblGridTitle.Visible = true;
            }
            else
            {
                lblMsg.Text = "No record(s) found.";
                lblMsg.CssClass = "errorNote";
                GV_DeleteProfile.Visible = false;
                lnkViewFullList.Visible = false;
                lblGridTitle.Visible = false;
            }
        }
        #endregion

        #region Grid events
        protected void GV_DeleteProfile_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteProfile")
            {
                string[] IDs = e.CommandArgument.ToString().Split('|');
                oclsEligibilityDBAccess = new clsEligibilityDBAccess();
                string sRet = string.Empty;
                Classes.clsUser user = (Classes.clsUser)Session["User"];
                //
                //DeleteDanglingStudent(uniID, year, studentID, userID, New identity);
                //
                sRet = oclsEligibilityDBAccess.DeleteDanglingStudent(IDs[0], IDs[1], IDs[2], user.User_ID, string.Empty);
                if (sRet == "Y")
                {
                    lblMsg.Text = "Profile deleted successfully.";
                    lblMsg.CssClass = "saveNote";
                    GetRecords(hid_pindex.Value);
                }
                else
                {
                    lblMsg.Text = "Profile could be deleted. Please contact the administrator.";
                    lblMsg.CssClass = "errorNote";
                }
            }
        }

        protected void GV_DeleteProfile_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer && e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbtn = (LinkButton)e.Row.FindControl("lnkSelect");
                lbtn.Attributes.Add("onclick", "javascript:ShowConfirm('" + lbtn.UniqueID + "','On deleting profile, the student will be permanently deleted and will no longer available.<br><br> Are you sure you want to delete this profile?');return false;");
            }
        }

        protected void GV_DeleteProfile_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_DeleteProfile.PageIndex = e.NewPageIndex;
            GetRecords(hid_pindex.Value);
        }
        #endregion

        #region View complete list link click event
        protected void lnkViewFullList_Click(object sender, EventArgs e)
        {
            hid_pindex.Value = "1";
            GetRecords(hid_pindex.Value);
            lnkViewFullList.Visible = false;
        }
        #endregion
    }
}