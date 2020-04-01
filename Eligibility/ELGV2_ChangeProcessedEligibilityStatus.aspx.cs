using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Classes;
using System.Globalization;
using System.Configuration;
using System.Threading;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_ChangeProcessedEligibilityStatus : System.Web.UI.Page
    {

       searchInstNewChangeElgUnprocess sInst;
        clsCommon Common = new clsCommon();
        clsCache clsCache = new clsCache();

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            clsCache.NoCache();
            if (!IsPostBack)
            {
                if (PreviousPage != null)
                {
                    ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

                    if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                    {
                        hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                    }
                }

                ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
                sInst = (searchInstNewChangeElgUnprocess)Cntph.FindControl("SchInst12");

                HtmlInputHidden[] hid = new HtmlInputHidden[2];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                Common.setHiddenVariables(ref hid);
                lblPageHead.Text = "Unprocess Eligibility";
            }

            lblGridName.Visible = false;
            SchInst12.dgData1.RowCommand += new GridViewCommandEventHandler(dgData1_RowCommand);
        }

        #endregion





        #region GridView Event :Jatin

        protected void dgData1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkButSelect")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = SchInst12.dgData1.Rows[index];

                hidInstID.Value = row.Cells[1].Text;
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
                    Server.Transfer("ELGV2_ChangeProcessedEligibilityStatus__2.aspx?InstituteID=" + InstID, true);
                }
            }
        }

        #endregion

        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion

    }
}