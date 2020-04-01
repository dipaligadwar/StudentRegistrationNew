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
using System.Globalization;
using System.Resources;
using System.Threading;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_BulkProcess : System.Web.UI.Page
    {
        searchInstNew sInst;
        //Profile.WebCtrl.StudentRequestAdvanceSearch StudentAdvancedSearchCtrl;

        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            HtmlInputHidden[] hid = new HtmlInputHidden[7];
            hid[0] = hidUniID;
            hid[1] = hidInstID;
            hid[2] = hidCountryId;
            hid[3] = hidStateID;
            hid[4] = hidDistrictID;
            hid[5] = hidTehsilID;
            hid[6] = hidCollCode;
            //Common.setHiddenVariables(ref hid);
            
            */

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

            }

            ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            sInst =(searchInstNew)Cntph.FindControl("SchInst1");


            if (hidUniID.Value == "")
            {
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            }
                lblGridName.Visible = false;
                //sInst = (searchInstNew)Page.FindControl("SchInst1");

                SchInst1.dgData1.RowCommand += new GridViewCommandEventHandler(dgData1_RowCommand);
           
             /*   
                sInst.btnSearch.Click += new EventHandler(this.btnSearch_Click);
                hidCountryId.Value = ((HtmlInputHidden)sInst.FindControl("hidCountryID")).Value;
                hidStateID.Value = ((HtmlInputHidden)sInst.FindControl("hidStateID")).Value;
                hidDistrictID.Value = ((HtmlInputHidden)sInst.FindControl("hidDistrictID")).Value;
                hidTehsilID.Value = ((HtmlInputHidden)sInst.FindControl("hidTehsilID")).Value;
                hidCollCode.Value = ((HtmlInputHidden)sInst.FindControl("hidCollCode")).Value;
             */
                //hidUniID.Value = ((HtmlInputHidden)sInst.FindControl("hidUniID")).Value;
                //hidInstID.Value = ((HtmlInputHidden)sInst.FindControl("hidInstID")).Value;
      
        }

        #endregion

        #region btnSearch_Click
        /*
        void btnSearch_Click(object sender, EventArgs e)
        {
            lblGridName.Visible = true;
          
            fnDisplayGrid();
        }

         */
        # endregion

        #region fnDisplayGrid

        private void fnDisplayGrid()
        {
            DataTable dt = new DataTable();
            try
            {
                if (hidCountryId.Value == "107")
                {
                    dt = clsInstitute.InstituteSearch(hidUniID.Value, sInst.RDType_ID, sInst.InstName, hidCountryId.Value, hidStateID.Value, hidDistrictID.Value, hidTehsilID.Value, hidCollCode.Value);
                }
                else
                {
                    dt = clsInstitute.InstituteSearch(hidUniID.Value, sInst.RDType_ID, sInst.InstName, hidCountryId.Value, "0", "0", "0", hidCollCode.Value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

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

                //lblData.Text = "";
                //lblData.Visible = false;
            }
            else
            {
                dgData.Visible = false;
                lblGridName.Visible = false;

                //lblData.Visible = true;
                //lblData.Text = "<font size=3 color='#000000'>Sorry...</font><br><br>Record is not available for the " + sInst.RD_TypeText;
            }
       
            dt.Dispose();
            dt = null;
        }

        #endregion

        #region Datagrid related Functions

        #region dgData_ItemCommand

      /*  protected void dgData_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "lnkButSelect")
            {
                hidInstID.Value = e.Item.Cells[1].Text;
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
                    Server.Transfer("ELGV2_BulkProcess__1.aspx");
                    //Server.Transfer("ELGV2_BulkProcess__1.aspx?InstituteID=" + hidInstID.Value + "&UniverID=" + hidUniID.Value);
                   
                    
                }
            }
        }*/

        #endregion

        #endregion

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
                    Server.Transfer("ELGV2_BulkProcess__1.aspx");
                }
            }
        }

        #endregion


    }
}
