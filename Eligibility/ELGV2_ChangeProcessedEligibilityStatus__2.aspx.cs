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
using Classes;
using StudentRegistration.Eligibility.ElgClasses;



namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_ChangeProcessedEligibilityStatus__2 : System.Web.UI.Page
    {
        #region Declaration of Variables
        protected System.Web.UI.HtmlControls.HtmlInputHidden tehsilName;
        Eligibility.WebCtrl.StudentAdvanceSeachForConfigureChangeElgUnprocess RegStudentAdvancedSearchCtrl;
        clsCommon Common = new clsCommon();
        clsCommon CommonAcYr = new clsCommon();
        clsCache clsCache = new clsCache();
        InstituteRepository InstRep = new InstituteRepository();
        #endregion

        #region Page Load

        protected void Page_Load(object sender, System.EventArgs e)
        {
            clsCache.NoCache();

            ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            RegStudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentAdvanceSeachForConfigureChangeElgUnprocess)Cntph.FindControl("StudentAdvanceSeachForConfigureChangeElgUnprocess1");

            hid_fk_AcademicYr_ID.Value = RegStudentAdvancedSearchCtrl.ddlAcademicYear.SelectedValue.ToString();
            hidAcademicYrText.Value = RegStudentAdvancedSearchCtrl.ddlAcademicYear.SelectedItem.ToString();


            // Put user code to initialize the page here
            if (!IsPostBack)
            {
                ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                searchInstNew temp = (searchInstNew)Cntph1.FindControl("SchInst1");
                hidInstID.Value = ((HtmlInputHidden)Cntph1.FindControl("hidInstID")).Value;
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();


                HtmlInputHidden[] hid = new HtmlInputHidden[21];
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
                hid[11] = hid_fk_AcademicYr_ID;
                hid[12] = hidAcademicYrText;
                hid[13] = hidFacName;
                hid[14] = hidCrName;
                hid[15] = hidMOLName;
                hid[16] = hidPattern;
                hid[17] = hidBrName;
                hid[18] = hidAcYrName;
                hid[19] = hidSearchType;
                hid[20] = hidAppFormNo;

                Common.setHiddenVariables(ref hid);
            }

            if (hidInstID.Value != "" && hidInstID.Value != null)
            {
                lblPageHead.Text = "Mark Eligibility to Unprocessed";
                lblSubHeader.Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);
            }


            if (Request.QueryString["Search"] == "Adv")
            {
                if (Request.QueryString["Navigate"] == "back")
                {
                    RegStudentAdvancedSearchCtrl.QstrNavigate = "back";
                    RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ResolveProvisional__2.aspx?Search=Adv";
                    RegStudentAdvancedSearchCtrl.GridType = "Reg";

                    //if (Request.QueryString["AcYear"] != "0")
                    //{
                    //    lblAcademicYear.Text = " [Academic Year " + Request.QueryString["AcYearText"].ToString() + "]";  //+ hidAcademicYrText.Value; 
                    //    lblAcademicYear.Attributes.Add("style", "display:inline");
                    //}
                    //else if (Request.QueryString["AcYear"] == "0")
                    //{
                    //    lblAcademicYear.Attributes.Add("style", "display:none");
                    //}

                }
                else
                {
                    RegStudentAdvancedSearchCtrl.QstrNavigate = null;
                    RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ResolveProvisional__2.aspx?Search=Adv";
                    RegStudentAdvancedSearchCtrl.GridType = "Reg";
                }
            }
            else if (Request.QueryString["Search"] == "Simple")
            {
                if (Request.QueryString["Navigate"] == "back")
                {
                    RegStudentAdvancedSearchCtrl.QstrNavigate = "back";
                    RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ResolveProvisional__2.aspx?Search=Simple";
                    RegStudentAdvancedSearchCtrl.GridType = "Reg";

                }
            }

            //added by Deboshree 16/7/10

            if (RegStudentAdvancedSearchCtrl.HidSearchType.Equals("Simple"))// || Request.QueryString["Search"] == "Simple")
            {
                RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ResolveProvisional__2.aspx?Search=Simple";
                hid_fk_AcademicYr_ID.Value = "0";
                lblAcademicYear.Attributes.Add("style", "display:none");

            }
            else if (RegStudentAdvancedSearchCtrl.HidSearchType.Equals("Adv"))// || Request.QueryString["Search"] == "Adv")
            {
                RegStudentAdvancedSearchCtrl.StrUrl = "ELGV2_ResolveProvisional__2.aspx?Search=Adv";
                if (hid_fk_AcademicYr_ID.Value != "0" || hid_fk_AcademicYr_ID.Value != "" || hid_fk_AcademicYr_ID.Value != null)
                    if (hidAcademicYrText.Value != "--- Select ---")
                    {
                        lblAcademicYear.Text = " for Academic Year " + hidAcademicYrText.Value;
                        //lblAcademicYear.Attributes.Add("style", "display:inline");
                    }
            }
            RegStudentAdvancedSearchCtrl.GridType = "Reg";
            //end add by Deboshree         

        }

        #endregion

        #region Web Form Designer generated code

        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {

        }

        #endregion

        #region tbElgFormNo_TextChanged

        protected void tbElgFormNo_TextChanged(object sender, System.EventArgs e)
        {

        }

        #endregion
    }
}