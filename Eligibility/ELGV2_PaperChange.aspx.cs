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
using System.Threading;
using System.Globalization;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperChange : System.Web.UI.Page
    {

        clsUser user;

        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["user"];
            if (user.UserTypeCode == "2") 
            {
                Server.Transfer("ELGV2_PaperChange__1.aspx");
            }
            SchInst1.dgData1.RowCommand += new GridViewCommandEventHandler(dgData1_RowCommand);
        }

        #region GridView Events

        protected void dgData1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkButSelect")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = SchInst1.dgData1.Rows[index];

                hidInstID.Value = row.Cells[1].Text;
                hidInstCode.Value = row.Cells[2].Text;
                string InstID = hidInstID.Value;
               
                if (hidInstID.Value == "")
                {
                    lblPageHead.Visible = false;

                }
                else
                {
                    if (hidUniID.Value == "")
                    {
                        hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                    }
                    Server.Transfer("ELGV2_PaperChange__1.aspx?InstituteID= " + InstID, true);
                }
            }
        }

        #endregion
    }
}
