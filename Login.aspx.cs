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
namespace StudentRegistration 
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnLogin.UniqueID;
            btnLogin.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // txtUserName.Text = "superadmin";
           // txtPassword.Text = "DuDc123!@";
            clsUser user = new clsUser(txtUserName.Text, null);


            if (user.Exist)
            {
                Session["User"] = user;
                Response.Redirect("Eligibility/DeleteProfile.aspx");
              //  Response.Redirect("Eligibility/UpdateContactDetails.aspx");
                
               // Response.Redirect("Eligibility/ELGV2_rptUploadedStudentStatistics.aspx");
             //   Response.Redirect("Eligibility/ELGV2_ChangeProcessedEligibilityStatus.aspx");
               // Response.Redirect("Eligibility/EligibilityIndex.aspx"); //
            }
        }
    }
}
