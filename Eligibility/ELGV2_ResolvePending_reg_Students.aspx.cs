
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
using StudentRegistration.Eligibility.ElgClasses;
using System.Threading;
using System.Globalization;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_ResolvePending_reg_Students : System.Web.UI.Page
    {

        searchInstNew sInst;
        clsCommon Common = new clsCommon();
        clsCache clsCache = new clsCache();

        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

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
                sInst = (searchInstNew)Cntph.FindControl("SchInst1");

                HtmlInputHidden[] hid = new HtmlInputHidden[2];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                Common.setHiddenVariables(ref hid);
                lblPageHead.Text = "Resolve Pending Eligibility";
                
            }

            lblGridName.Visible = false;
            //sInst = (searchInstNew)Page.FindControl("SchInst1");            
            SchInst1.dgData1.RowCommand += new GridViewCommandEventHandler(dgData1_RowCommand);
        }

        #endregion

        /*
        #region btnSearch_Click

        void btnSearch_Click(object sender, EventArgs e)
        {
            lblGridName.Visible = true;
            fnDisplayGrid();
        }

        #endregion

        #region fnDisplayGrid

        private void fnDisplayGrid()
        {
            DataTable dt = new DataTable();
            dt = clsInstitute.InstituteSearch(sInst.UniID, sInst.RDType_ID, sInst.InstName, "107", sInst.StatID, sInst.DistID, sInst.TehID, sInst.InstCode);
            if (dt.Rows.Count > 0)
            {
                dgData.DataSource = dt;

                try
                {
                    dgData.DataBind();
                }
                catch
                {
                    dgData.CurrentPageIndex = 0;
                    dgData.DataBind();
                }
                dgData.Visible = true;

                lblGridName.Visible = true;
                lblGridName.Text = "..:: Available " + sInst.RD_TypeText + "(s) ::..";

                lblData.Text = "";
                lblData.Visible = false;
            }
            else
            {
                dgData.Visible = false;
                lblGridName.Visible = false;

                lblData.Visible = true;
                lblData.Text = "<font size=3 color='#000000'>Sorry...</font><br><br>Record is not available for the " + sInst.RD_TypeText;
            }
            dt.Dispose();
            dt = null;
        }

        #endregion
        */

       #region GridView Event :Jatin

        protected void dgData1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkButSelect")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = SchInst1.dgData1.Rows[index];

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
                    Server.Transfer("ELGV2_ResolvePending_reg_Students__1.aspx?InstituteID=" + InstID, true);
                }
            }
        }

        #endregion

    }
}
