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
    public partial class BulkInsertForUniversity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.clsCache.NoCache();
        }

        protected void btnProcessData_Click(object sender, EventArgs e)
        {
            tblGrid.Visible = true;
            lblSave.Text = "Record Saved Sucessfuly";
            lblSave.CssClass = "saveNote";
            lblGrid.Text = "List of Student Processed Records";
            lblGrid.CssClass = "errorNote";
        }
    }
}
