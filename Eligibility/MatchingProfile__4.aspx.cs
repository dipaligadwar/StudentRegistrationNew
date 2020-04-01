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
    public partial class MatchingProfile__4 : System.Web.UI.Page
    {
        DataTable oDt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            DisPlayData();
        }

        #region Fill Grid View
        public void DisPlayData()
        { 
            oDt=new DataTable();
            clsEligibilityDBAccess oclsElgDBAcess = new clsEligibilityDBAccess();
            oDt=oclsElgDBAcess.getMergeAndCancelAdmissionRequestStatus();
            if (oDt != null && oDt.Rows.Count > 0)
            {
                lblNodata.Visible = false;
                lblNodata.Text = "";
                GV_MergeProfileStat.Visible=true;
                GV_MergeProfileStat.DataSource = oDt;
                GV_MergeProfileStat.DataBind();
            }
            else
            {
                GV_MergeProfileStat.Visible = false;
                lblNodata.Text = "No any request is in process or pending.";
                lblNodata.Visible = true;
            }
        }

        #endregion

       
        protected void GV_MergeProfileStat_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_MergeProfileStat.PageIndex = e.NewPageIndex;
            DisPlayData();
        }
    }
}
