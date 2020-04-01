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
using System.Text.RegularExpressions;
using Classes;
using System.Threading;
using System.Globalization;
using System.Resources;
using StudentRegistration.Eligibility.ElgClasses;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_ResolvePending_reg_Students__1 : System.Web.UI.Page
    {

        #region Declaration of Variables

        protected System.Web.UI.HtmlControls.HtmlInputHidden tehsilName;
        string PRNumber = null;
        private string Elg_FormNo;
        string searchType = "";
        Eligibility.WebCtrl.StudentAdvanceSearchForConfigure_reg_Students RegStudentAdvancedSearchCtrl;
        clsCommon Common = new clsCommon();
        clsCommon CommonAcYr = new clsCommon();
        clsCache clsCache = new clsCache();
        string InstituteID = null;
        InstituteRepository InstRep = new InstituteRepository();

        #endregion

        #region Page Load

        protected void Page_Load(object sender, System.EventArgs e)
        {
            clsCache.NoCache();

            //RegStudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentAdvanceSearchForConfigure_reg_Students)Page.FindControl("StudentAdvanceSeachForConfigure1");

            ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            RegStudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentAdvanceSearchForConfigure_reg_Students)Cntph.FindControl("StudentAdvanceSeachForConfigure1");

            hid_fk_AcademicYr_ID.Value = RegStudentAdvancedSearchCtrl.ddlAcademicYear.SelectedValue.ToString();
            hidAcademicYrText.Value = RegStudentAdvancedSearchCtrl.ddlAcademicYear.SelectedItem.ToString();
            try
            {
                hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
            }
            catch
            {
                hidIsPRNValidationRequired.Value = "N";
            }

            // Put user code to initialize the page here
            if (!IsPostBack)
            {

                ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                searchInstNew temp = (searchInstNew)Cntph1.FindControl("SchInst1");
                hidInstID.Value = ((HtmlInputHidden)Cntph1.FindControl("hidInstID")).Value;
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();

                if (Request.QueryString["Search"] == "Simple" && Request.QueryString["Navigate"] == "back")
                {
                    hidPRN.Value = ((HtmlInputHidden)Cntph1.FindControl("hidPRN")).Value;
                    hidElgFormNo.Value = ((HtmlInputHidden)Cntph1.FindControl("hidElgFormNo")).Value;
                    hidIsBlank.Value = ((HtmlInputHidden)Cntph1.FindControl("hidIsBlank")).Value;
                }

                HtmlInputHidden[] hid = new HtmlInputHidden[20];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidElgFormNo;
                hid[3] = hidpkStudentID;
                hid[4] = hidpkYear;
                hid[5] = hidpkFacID;
                hid[6] = hidpkCrID;
                hid[7] = hidpkMoLrnID;
                hid[8] = hidpkPtrnID;
                hid[9] = hidpkBrnID;
                hid[10] = hidpkCrPrDetailsID;
                hid[11] = hidPRN;
                hid[12] = hidIsBlank;

                hid[13] = hid_fk_AcademicYr_ID;
                hid[14] = hidAcademicYrText;
                hid[13] = hidFacName;
                hid[14] = hidCrName;
                hid[15] = hidMOLName;
                hid[16] = hidPattern;
                hid[17] = hidBrName;
                hid[18] = hidAcYrName;
                hid[19] = hidSearchType;

                Common.setHiddenVariables(ref hid);

            }

            if (hidInstID.Value != "" && hidInstID.Value != null)
            {
                lblPageHead.Text = "Resolve Pending Eligibility";
                lblSubHeader.Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);

            }
    
            RegStudentAdvancedSearchCtrl.QstrNavigate = null;
            RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ResolvePending_reg_Students__2.aspx?Search=Adv";
            RegStudentAdvancedSearchCtrl.GridType = "Reg";
            if (Request.QueryString["Search"] == "Adv")
            {
                if (Request.QueryString["Navigate"] == "back")
                {
                    RegStudentAdvancedSearchCtrl.QstrNavigate = "back";
                    RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ResolvePending_reg_Students__2.aspx?Search=Adv";
                    RegStudentAdvancedSearchCtrl.GridType = "Reg";
                    divAdvSearch.Style.Add("display", "block");
                    divSimpleSearch.Style.Add("display", "none");
                    divAdvSearch.Style.Remove("display");

                }
                else
                {
                    RegStudentAdvancedSearchCtrl.QstrNavigate = null;
                    RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ResolvePending_reg_Students__2.aspx?Search=Adv";
                    RegStudentAdvancedSearchCtrl.GridType = "Reg";
                }
            }
            else if (Request.QueryString["Search"] == "Simple")
            {
                if (Request.QueryString["Navigate"] == "back")
                {
                    RegStudentAdvancedSearchCtrl.QstrNavigate = "back";
                }

            }

            if (RegStudentAdvancedSearchCtrl.HidSearchType.Equals("Simple"))// || Request.QueryString["Search"] == "Simple")
            {
                RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ResolvePending_reg_Students__2.aspx?Search=Simple";
            }
            else if (RegStudentAdvancedSearchCtrl.HidSearchType.Equals("Adv"))// || Request.QueryString["Search"] == "Adv")
            {
                RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ResolvePending_reg_Students__2.aspx?Search=Adv";
            }
            RegStudentAdvancedSearchCtrl.GridType = "Reg";
        }

        #endregion

     
        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        #region tbElgFormNo_TextChanged

        //protected void tbElgFormNo_TextChanged(object sender, System.EventArgs e)
        //{

        //}

        #endregion

        #region GridView

        #region dgRegStudents1_RowDataBound
        protected void dgRegStudents1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
            }
        }
        #endregion

        //#region dgRegStudents1_RowCommand
        //protected void dgRegStudents1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "StudentDetails")
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = dgRegStudents1.Rows[index];

        //        hidElgFormNo.Value = row.Cells[1].Text.Trim();
        //        hidPRN.Value = row.Cells[3].Text.Trim();
        //        hidpkYear.Value = row.Cells[7].Text.Trim();
        //        hidpkStudentID.Value = row.Cells[8].Text.Trim();
        //        hidpkFacID.Value = row.Cells[9].Text.Trim();
        //        hidpkCrID.Value = row.Cells[10].Text.Trim();
        //        hidpkMoLrnID.Value = row.Cells[11].Text.Trim();
        //        hidpkPtrnID.Value = row.Cells[12].Text.Trim();
        //        hidpkBrnID.Value = row.Cells[13].Text.Trim();
        //        hidpkCrPrDetailsID.Value = row.Cells[14].Text.Trim();
        //        hid_fk_AcademicYr_ID.Value = row.Cells[15].Text.Trim();
        //        searchType = "Simple";
        //        Server.Transfer("ELGV2_ResolvePending_reg_Students__2.aspx?Search=" + searchType.ToString());
        //    }

        //}
        //#endregion
        #endregion
    }
}
