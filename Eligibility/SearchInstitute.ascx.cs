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
    public partial class SearchInstitute : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void ImageButton_Click()
        {
            Response.Redirect("BulkInsertForCollege.aspx");
        }
    }
}