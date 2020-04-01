using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Threading;
using System.Globalization;
using System.Configuration;
using StudentRegistration.Eligibility.ElgClasses;
using System.Data;
using AjaxControlToolkit;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_TransferPreviousAdmissions : System.Web.UI.Page
    {
        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion

        #region Global Varriables

        InstituteRepository oInstituteRepository = new InstituteRepository();
        DataTable oDT = null; clsCommon oCommon = null;
        private string pk_Uni_ID = Convert.ToString(clsGetSettings.UniversityID);
        clsElgStudent srv = new clsElgStudent();
        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divSearchPRN.Style.Add("display", "block");
            }
        }

        #endregion

        #region Event

        #region btnSearch_Click

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            hidPRN.Value = txtPRN.Text.Trim();
            lblStudentPRN.Text = hidPRN.Value;
            SearchStudentbyPRN();
        }


        #endregion

        #region btnBack_Click

        protected void btnBack_Click(object sender, EventArgs e)
        {
            divSearchPRN.Style.Add("display", "block");
            divDisplayPRN.Style.Add("display", "block");
            divDisplayData.Style.Add("display", "block");
            divUpdateData.Style.Add("display", "none");
            SearchStudentbyPRN();
            //txtPRN.Text = string.Empty;
            //lblPRN.Text = string.Empty;
            //lblStudName.Text = string.Empty;
            //lblPRNupdate.Text = string.Empty;
            lblStudNameupdate.Text = string.Empty;
            lblOldCollege.Text = string.Empty;
            lblCourseupdate.Text = string.Empty;
            lblNewCollCode.Text = string.Empty;
            lblNewCollName.Text = string.Empty;
            lblMSG.Text = string.Empty;
        }


        #endregion

        #region btnUpdate_Click

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            clsUser user = (clsUser)Session["user"];
            int flag = 0;
            try
            {
                flag = srv.UpdateTransferPreviousAdmissions_ForStudent(hidPRN.Value, hidNewRef_Pk_Institute_ID.Value, hidOldPk_Institute_ID.Value, hidFacultyID.Value, hidCourseID.Value, hidMolrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hidCrPrChID.Value, hidAcademicYear_ID.Value, hidAY_Sequence.Value, "Y", user.User_ID, hidCrPr_Seq.Value, hidCrPrCh_Seq.Value);
                if (flag > 0)
                {
                    lblMSG.Text = "College transfer successfully from " + lblOldCollege.Text + " To New College " + "(" + lblNewCollCode.Text + ") " + lblNewCollName.Text;
                    lblMSG.CssClass = "saveNote";
                }
                else
                {
                    lblMSG.Text = "Updation fail. Please try after some time.";
                    lblMSG.CssClass = "errorNote";
                }
            }
            catch (Exception ex)
            { throw ex; }

        }

        #endregion

        #region ddlStudyCenter_SelectedIndexChanged

        protected void ddlStudyCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(ddlStudyCenter.SelectedItem.Text.IndexOf('[')) == 0 && Convert.ToInt16(ddlStudyCenter.SelectedItem.Text.IndexOf(']')) > 0)
            {
                string CenterCode = Convert.ToString(ddlStudyCenter.SelectedItem.Text.Split('[')[1].Trim());
                CenterCode = CenterCode.Split(']')[0].Trim();
                txtCenterCode.Text = CenterCode;
                hidInstCode.Value = CenterCode;
                hidInstName.Value = Convert.ToString(ddlStudyCenter.SelectedItem.Text.Split('-')[1].Trim());
                hidNewRef_Pk_Institute_ID.Value = ddlStudyCenter.SelectedItem.Value.Trim();
            }
            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlStudyCenter);
        }


        #endregion

        #region GV_SrchStud_RowCommand

        protected void GV_SrchStud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                lblStudNameupdate.Text = string.Empty;
                lblOldCollege.Text = string.Empty;
                lblCourseupdate.Text = string.Empty;
                lblNewCollCode.Text = string.Empty;
                lblNewCollName.Text = string.Empty;
                lblMSG.Text = string.Empty;
                GridView gv = (GridView)sender;
                int index = Convert.ToInt32(e.CommandArgument);
                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "key1", "return SetInstitute();", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key1", "<script>return SetInstitute();</script>", false);
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Script", "return SetInstitute();", true);
                //ScriptManager.RegisterStartupScript(this.Page, GetType(), "Key1", "<script> return SetInstitute();</script>", false);
                lblPRNupdate.Text = hidPRN.Value;
                lblStudNameupdate.Text = gv.Rows[index].Cells[8].Text;
                lblCourseupdate.Text = gv.Rows[index].Cells[1].Text;
                lblOldCollege.Text = "(" + gv.Rows[index].Cells[5].Text + ") " + gv.Rows[index].Cells[7].Text;
                lblNewCollCode.Text = hidInstCode.Value;
                lblNewCollName.Text = hidInstName.Value;
                hidFacultyID.Value = gv.Rows[index].Cells[11].Text;
                hidCourseID.Value = gv.Rows[index].Cells[12].Text;
                hidMolrnID.Value = gv.Rows[index].Cells[13].Text;
                hidPtrnID.Value = gv.Rows[index].Cells[14].Text;
                hidBrnID.Value = gv.Rows[index].Cells[15].Text;
                hidCrPrDetailsID.Value = gv.Rows[index].Cells[16].Text;
                hidCrPrChID.Value = gv.Rows[index].Cells[17].Text;
                hidCrPr_Seq.Value = gv.Rows[index].Cells[18].Text;
                hidCrPrCh_Seq.Value = gv.Rows[index].Cells[19].Text;
                hidAY_Sequence.Value = gv.Rows[index].Cells[20].Text;
                hidAcademicYear_ID.Value = gv.Rows[index].Cells[21].Text;
                hidOldPk_Institute_ID.Value = gv.Rows[index].Cells[22].Text;
                divSearchPRN.Style.Add("display", "none");
                divDisplayPRN.Style.Add("display", "none");
                divDisplayData.Style.Add("display", "none");
                divUpdateData.Style.Add("display", "block");
            }
        }

        #endregion

        #endregion

        #region Other Functions

        #region Fill institute based upon university

        private void FillInstitute()
        {
            oDT = new DataTable();
            oDT = oInstituteRepository.InstituteSearch(pk_Uni_ID, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

            oCommon = new clsCommon();
            if (oDT.Rows.Count > 0 && oDT != null)
            {
                oCommon.fillDropDown(ddlStudyCenter, oDT, "0", "Text", "Value", "---- Select ----");
                FillOnlyToolTip(ddlStudyCenter);
            }
        }
        #endregion

        #region Function to add tool tip to dropdown
        public void FillOnlyToolTip(DropDownList ddl)
        {
            foreach (ListItem li in ddl.Items)
            {
                li.Attributes.Add("title", li.Text);
            }
        }
        #endregion

        public void SearchStudentbyPRN()
        {
            try
            {
                DataTable dt = srv.SearchStudentbyPRN(hidPRN.Value);
                if (dt != null && dt.Rows.Count > 0)
                {
                    divSearchPRN.Style.Add("display", "block");
                    divDisplayPRN.Style.Add("display", "block");
                    divDisplayData.Style.Add("display", "block");
                    lblErrorMsg.Text = string.Empty;
                    GV_SrchStud.DataSource = dt;
                    GV_SrchStud.DataBind();
                    lblStudName.Text = dt.Rows[0]["Student_Name"].ToString();
                    FillInstitute();
                }
                else
                {
                    divDisplayPRN.Style.Add("display", "none");
                    divDisplayData.Style.Add("display", "none");
                    lblErrorMsg.Text = "PRN number data does not exists. Please entered proper PRN number.";
                    GV_SrchStud.DataSource = null;
                    GV_SrchStud.DataBind();
                    dt = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}