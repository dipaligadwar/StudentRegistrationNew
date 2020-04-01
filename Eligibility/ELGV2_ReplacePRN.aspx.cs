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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using Classes;
using Ajax;
using Microsoft.Reporting.WebForms;


namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_ReplacePRN : System.Web.UI.Page
    {
        clsStudent oStud = null;
        clsUser user = null;

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["user"];
        }
        #endregion

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            string sPRN = txtPRN.Text.Trim();
            oStud = new clsStudent();

            DataTable oDTReplace = new DataTable();

            oDTReplace = oStud.Get_Student_Details_For_Replace_PRN(sPRN);
            if (oDTReplace != null && oDTReplace.Rows.Count > 0)
            {
                divStudentDetails.Style.Add("display","inline");
                lblStudentName.Text = oDTReplace.Rows[0]["Student_Name"].ToString();
                lblStudentPRN.Text = oDTReplace.Rows[0]["PRN_Number"].ToString();
                lblCourse.Text = oDTReplace.Rows[0]["Course_Name"].ToString();
                lblBranch.Text = oDTReplace.Rows[0]["Branch_Name"].ToString();

                lblMessage.Visible = false;
            }
            else
            {
                lblMessage.Text = "No Record Found";
                lblMessage.CssClass = "errorNote";
                lblMessage.Visible = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
            oStud = new clsStudent();
            lblMessage.Visible = false;
            int i = oStud.ReplacePRN(txtPRN.Text.Trim(), txtReplacePRN.Text.Trim(), user.User_ID);
            if (i > 0)
            {
                lblMessage.Text = "PRN Repalced";
                lblMessage.CssClass = "saveNote";
                lblMessage.Visible = true;
            }
            else {
                lblMessage.Text = "Error while replacing PRN";
                lblMessage.CssClass = "errorNote";
                lblMessage.Visible = true;
            }
        }



    }
}