using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using Classes;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Configuration;
using System.Text;


namespace StudentRegistration.Eligibility
{
    /// <summary>
    /// Summary description for StudentStatus.
    /// </summary>
    public partial class ELGV2_ViewStatus__1 : System.Web.UI.Page
    {

        #region declaration of variables

        protected System.Web.UI.HtmlControls.HtmlInputHidden tehsilName;
        clsCommon Common = new clsCommon();
        Eligibility.WebCtrl.StudentsStatusSearch RegStudentAdvancedSearchCtrl;
        string searchType = "";
        clsCache clsCache = new clsCache();
        InstituteRepository InstRep = new InstituteRepository();

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            clsCache.NoCache();

            ContentPlaceHolder CntphM = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            RegStudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentsStatusSearch)CntphM.FindControl("StudentsStatusSearch1");


            if (!IsPostBack)
            {
                ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                searchInstNew temp = (searchInstNew)Cntph1.FindControl("SchInst1");
                hidInstID.Value = ((HtmlInputHidden)Cntph1.FindControl("hidInstID")).Value;
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();

                HtmlInputHidden[] hid = new HtmlInputHidden[13];
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

                Common.setHiddenVariables(ref hid);

            }

            ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            RegStudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentsStatusSearch)Cntph.FindControl("StudentsStatusSearch1");

            if (hidInstID.Value != "" && hidInstID.Value != null)
            {

                lblPageHead.Text = "View Eligibility Status";
                lblSubHeader.Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);

            }
            RegStudentAdvancedSearchCtrl.QstrNavigate = null;
            RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ViewStatus__2.aspx?Search=Adv";

            if (Request.QueryString["Search"] == "Adv")
            {
                if (Request.QueryString["Navigate"] == "back")
                {
                    RegStudentAdvancedSearchCtrl.QstrNavigate = "back";
                }
                else
                {
                    RegStudentAdvancedSearchCtrl.QstrNavigate = null;
                }

                RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ViewStatus__2.aspx?Search=Adv";

            }

            else if (Request.QueryString["Search"] == "Simple")
            {
                if (Request.QueryString["Navigate"] == "back")
                {
                    RegStudentAdvancedSearchCtrl.QstrNavigate = "back";
                    RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ViewStatus__2.aspx?Search=Simple";

                }
            }

            //added by Deboshree 16/7/10

            if (RegStudentAdvancedSearchCtrl.HidSearchType.Equals("Simple"))// || Request.QueryString["Search"] == "Simple")
            {
                RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ViewStatus__2.aspx?Search=Simple";

            }
            else if (RegStudentAdvancedSearchCtrl.HidSearchType.Equals("Adv"))// || Request.QueryString["Search"] == "Adv")
            {
                RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ViewStatus__2.aspx?Search=Adv";
            }

            try
            {
                hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
            }
            catch
            {
                hidIsPRNValidationRequired.Value = "N";
            }
        }

        #endregion

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        # region Commented by Jatin

        /* protected void dgRegStudents_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
               e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgRegStudents1.CurrentPageIndex * 10) + 1);

            }
        }*/

        /*       protected void dgRegStudents_ItemCommand(object source, DataGridCommandEventArgs e)
               {
                   if (e.CommandName == "StudentDetails1")
                   {
                       hidElgFormNo.Value = e.Item.Cells[1].Text.Trim();
                       hidPRN.Value = e.Item.Cells[3].Text.Trim();
                       hidpkYear.Value = e.Item.Cells[9].Text.Trim();
                       hidpkStudentID.Value = e.Item.Cells[10].Text.Trim();
                       hidpkFacID.Value = e.Item.Cells[11].Text.Trim();
                       hidpkCrID.Value = e.Item.Cells[12].Text.Trim();
                       hidpkMoLrnID.Value = e.Item.Cells[13].Text.Trim();
                       hidpkPtrnID.Value = e.Item.Cells[14].Text.Trim();
                       hidpkBrnID.Value = e.Item.Cells[15].Text.Trim();
                       hidpkCrPrDetailsID.Value = e.Item.Cells[16].Text.Trim();
                       searchType = "Simple";
                       Server.Transfer("ELGV2_ViewStatus__2.aspx?Search=" + searchType.ToString());
                   }
               }
               */
        # endregion Commented by Jatin

        #region Formatting the Reason History for display

        protected string FormatReason(string reason)
        {
            string formatReason = reason;
            ArrayList reasons = new ArrayList();
            Regex r = new Regex(@"===(0[1-9]|1[012])/(0[1-9]|1[0-9]|2[0-9]|3[01])/\d\d (0[0-9]|1[0-9]|2[0-4]):([0-5][0-9])===");
            MatchCollection mc = r.Matches(formatReason);
            for (int i = 0; i < mc.Count; i++)
            {
                reasons.Add("<br/>" + mc[i].ToString() + "<br/>");
                formatReason = formatReason.Replace(mc[i].ToString(), reasons[i].ToString());
            }
            return formatReason;
        }

        #endregion

    }

}

