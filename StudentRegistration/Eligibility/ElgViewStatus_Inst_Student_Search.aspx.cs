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

namespace StudentRegistration.Eligibility
{
    public partial class ElgViewStatus_Inst_Student_Search : System.Web.UI.Page
    {
        schInst sInst;
        clsCommon Common = new clsCommon();
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.clsCache.NoCache();
            if (!IsPostBack)
            {
                clsUser user = (clsUser)Session["user"];
                if (user.UserTypeCode == "2")
                {
                    hidInstID.Value = user.UserRefferenceID;
                    string InstID = hidInstID.Value;
                    hidUniID.Value = UniversityPortal.clsGetSettings.UniversityID.ToString();
                    Server.Transfer("StudentStatus.aspx?InstituteID=" + InstID, true);
                }
                else
                {
                    HtmlInputHidden[] hid = new HtmlInputHidden[2];
                    hid[0] = hidInstID;
                    hid[1] = hidUniID;
                    Common.setHiddenVariables(ref hid);
                    lblTitle.Text = "View Eligibility Status";
                }
            }

            lblGridName.Visible = false;
            sInst = (schInst)Page.FindControl("SchInst1");
            sInst.btnSearch.Click += new EventHandler(btnSearch_Click);

        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            lblGridName.Visible = true;
            fnDisplayGrid();
        }
        private void fnDisplayGrid()
        {
            DataTable dt = new DataTable();
            dt = clsInstitute.InstituteSearch(sInst.UniID, sInst.RDType_ID, sInst.InstName, "91", sInst.StatID, sInst.DistID, sInst.TehID);
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
                lblData.Text = "<font size=3 color='#000000'>Sorry...</font><br><br>Record is not avilable for the " + sInst.RD_TypeText;
            }
            dt.Dispose();
            dt = null;
        }

        protected void dgData_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgData.CurrentPageIndex = e.NewPageIndex;
            fnDisplayGrid();
        }

        protected void dgData_ItemCommand(object source, DataGridCommandEventArgs e)
        {

            if (e.CommandName == "lnkButSelect")
            {
                hidInstID.Value = e.Item.Cells[1].Text;
                string InstID = hidInstID.Value;
                if (hidInstID.Value == "")
                {
                    lblTitle.Visible = false;

                }
                else
                {
                    if (hidUniID.Value == "")
                    {
                        hidUniID.Value = UniversityPortal.clsGetSettings.UniversityID.ToString();
                    }
                    Server.Transfer("StudentStatus.aspx?InstituteID=" + InstID, true);
                }
            }
        }
    }
}
