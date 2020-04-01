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
using Sancharak;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.IO;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;


namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_BulkProcess__1 : System.Web.UI.Page
    {
        clsCommon common;
        clsUser user;
        string sUser = "";
        string sRightsFlag = "";
        clsCommon Common = new clsCommon();
        string fkCountryID = "";
        clsCache clsCache = new clsCache();
        clsGeneral clsCountry = new clsGeneral();
        InstituteRepository InstRep = new InstituteRepository();
        
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAcYr.Attributes.Add("onclick", " return callvaliadteAcademic();");
            btnProcessData.Attributes.Add("onclick", "return fnValidate();");
            //BtnSubmit.Attributes.Add("onclick", "return callvalidate();");

            clsCache.NoCache();
            user = new clsUser();
            Ajax.Utility.RegisterTypeForAjax(typeof(ElgClasses.clsAjaxMethods));
            Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods), this.Page);
            user = (clsUser)Session["User"];
            sUser = user.User_ID.ToString();

            if (!IsPostBack)
            {

                ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
             //   Search_Institute ob = (Search_Institute)Context.Handler;
                searchInstNew temp = (searchInstNew)Cntph.FindControl("SchInst1");
                hidInstID.Value = ((HtmlInputHidden)Cntph.FindControl("hidInstID")).Value;
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                //hidCrPrID.Value = DD_CoursePart.SelectedItem.Value;


                HtmlInputHidden[] hidden = new HtmlInputHidden[17];
                hidden[0] = hidInstID;
                hidden[1] = hidUniID;
                hidden[2] = hidFacID;
                hidden[3] = hidCrID;
                hidden[4] = hidMoLrnID;
                hidden[5] = hidPtrnID;
                hidden[6] = hidBrnID;
                hidden[7] = hidCrPrID;
                hidden[8] = hidYear;
                hidden[9] = hidCollege_Eligibility_Flag;
                hidden[10] = hidRightsFlag;
                hidden[11] = hidElgFormNo;
                hidden[12] = hid_fk_AcademicYr_ID;
                hidden[13] = hidBodyState;
                hidden[14] = hidBodyID;
                hidden[15] = hidCountryIDForeign;
                hidden[16] = hidtxtCountryForeignBoardUniv;


                common = new clsCommon();
                common.setHiddenVariables(ref hidden);

                fkCountryID = "0";
                hidStateID.Value = "0";
                hidCountryId.Value = fkCountryID;

                if (common != null) common = null;

                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                Common.fillDropDown(ddlAcademicYear, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                ddlAcademicYear.SelectedIndex = 0;
                hid_AcademicYear.Value = ddlAcademicYear.SelectedItem.Text;
                hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;
                hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
                hidtxtCountryForeignBoardUniv.Value = txtForeignBoardUnivName.Text;

                fillCourse();
                fnFillState(hid_StateID.Value);
                lblSubHeader.Text = " for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);
                lnkPRN.Enabled = false;
                lnkSelectCr.Enabled = false;
                if (hid_fk_AcademicYr_ID.Value != "0")
                {
                    lblAcademicYear.Text = " [Academic Year " + hid_AcademicYear.Value + "]";
                    lblAcademicYear.Attributes.Add("style", "display:inline");
                }
                else
                {
                    lblAcademicYear.Attributes.Add("style", "display:none");
                }


            }
            else
            {
                
                lblNoRecords.Text = "";
                /*if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "0")
                {
                    fnFillState(hid_StateID.Value);
                    FillBoradDetails(hid_StateID.Value, hid_BodyID.Value);
                    DivFilterExamBody.Attributes.Add("style", "display:inline");

                }
                else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "1")
                {
                    hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
                    hidtxtCountryForeignBoardUniv.Value = txtForeignBoardUnivName.Text;
                    //DivFilterExamBody.Attributes.Add("style", "display:inline");

                }

                if (rbFilterYesNo.SelectedItem.Value.ToString() == "1")
                {
                    rbFilterYesNo.SelectedItem.Value = "1";
                    rbFilterYesNo.Items[0].Selected = true;
                    DivFilterExamBody.Attributes.Add("style", "display:inline");
                }
                if (rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                {
                    rbFilterYesNo.SelectedItem.Value = "0";
                    rbFilterYesNo.Items[1].Selected = true;
                    DivFilterExamBody.Attributes.Add("style", "display:none");
                }*/

               // rdEligible.Checked = true;
                
                if (hidCountryId.Value == "107")
                {
                    fnFillState(hidStateID.Value);
                }

                if (hid_fk_AcademicYr_ID.Value != "0")
                {
                    lblAcademicYear.Text = " for Academic Year " + hid_AcademicYear.Value;
                    lblAcademicYear.Attributes.Add("style", "display:inline");
                }
                else
                {
                    lblAcademicYear.Attributes.Add("style", "display:none");
                }

                DG_University.CurrentPageIndex = 0;

            }


            //--------------------------------------------------------
            //University ID Checking
            //--------------------------------------------------------
            if (hidUniID.Value == "")
            {
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            }
            //   btnSave.Attributes.Add("onclick", "return fnConfirm();");
            btnSave.Attributes.Add("onclick", "return fnCheck();");
            // btnSave.Attributes.Add("onclick", "fnProvElgCheck();");
           
            btnSave.Enabled = false;

        }
        #endregion

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        #region Button Process Click
        protected void btnProcessData_Click(object sender, EventArgs e)
        {

            if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "0")
            {
                fnFillState(hid_StateID.Value);
                FillBoradDetails(hid_StateID.Value, hid_BodyID.Value);
                DivFilterExamBody.Attributes.Add("style", "display:inline");
            }
            else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "1")
            {
                hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
                hidtxtCountryForeignBoardUniv.Value = txtForeignBoardUnivName.Text;                

            }

            if (rbFilterYesNo.SelectedItem.Value.ToString() == "1")
            {
                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:inline");
            }
            if (rbFilterYesNo.SelectedItem.Value.ToString() == "0")
            {
                rbFilterYesNo.SelectedItem.Value = "0";
                rbFilterYesNo.Items[1].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:none");
            }

            DG_PRN1.Visible = false;
            tblLink.Attributes.Add("style", "display:inline");
            trfilter.Attributes.Add("style", "display:inline");
            lblNoRecords.Visible = false;
            lblNoRecords1.Visible = false;
            lblSave.Text = "";
            lblUniCollPrn.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            rbFilterNo.Checked = true;
            trDecision.Attributes.Add("style", "display:none");
            hidBodyState.Value = Body_State.SelectedItem.Value;
            hidStateSelText.Value = Body_State.SelectedItem.Text;
            hidBodyID.Value = Body_ID.SelectedItem.Value;
            hidCountryIDForeign.Value = Body_Country.SelectedItem.Value;
            hidtxtCountryForeignBoardUniv.Value = txtForeignBoardUnivName.Text;
            //hidCrPrID.Value = DD_CoursePart.SelectedItem.Value;

            ////New Concept Begin
            if (rbFilterYesNo.SelectedItem.Value.ToString() == "0")
            {
                rbFilterYesNo.SelectedItem.Value = "0";
                rbFilterYesNo.Items[1].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:none");

                /*Div1.Attributes.Add("style", "display:block");
                tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");
                trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                trStatistics.Attributes.Add("style", "display:block");
                tblStatistics1.Attributes.Add("style", "display:none");                 
                lblRights.Attributes.Add("style", "display:block");
                trfilter.Attributes.Add("style", "display:block");*/
            }

            /*else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidBodyID.Value == "0")
            {
                string strScript = "<script language='JavaScript'>alert('Please Select State and Board/University')</script>";
                Page.RegisterStartupScript("PopUp", strScript);

                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:inline");

                trStatistics.Attributes.Add("style", "display:none");
                trStatisticsWithoutInv.Attributes.Add("style", "display:none");
                trfilter.Attributes.Add("style", "display:none");
                trGrids.Attributes.Add("style", "display:none");
                lblRights.Attributes.Add("style", "display:none");                

            }*/

            else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidCountryIDForeign.Value == "0")
            {
                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:inline");
                Body_Country.Attributes.Add("style", "display:none");
                txtForeignBoardUnivName.Attributes.Add("style", "display:none");
                TrCountryForeignBoardUniv.Attributes.Add("style", "display:none"); 
                TrCountry.Attributes.Add("style", "display:none"); 
                TrState.Attributes.Add("style", "display:inline"); 
                TrBody.Attributes.Add("style", "display:inline");

            }

            else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidCountryIDForeign.Value != "0")
            {
                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:inline");
                Body_Country.Attributes.Add("style", "display:inline");
                txtForeignBoardUnivName.Attributes.Add("style", "display:inline");
                TrCountryForeignBoardUniv.Attributes.Add("style", "display:inline"); 
                TrCountry.Attributes.Add("style", "display:inline"); 
                TrState.Attributes.Add("style", "display:none"); 
                TrBody.Attributes.Add("style", "display:none");
            }
            //New Concept End



            try
            {
                //Get Rights Flag
                sRightsFlag = clsEligibilityRights.Elg_Get_Courses_Rights(hidUniID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value);
                hidRightsFlag.Value = sRightsFlag;

                //*************
                displayGrids();
                //Div1.Attributes.Add("style", "display:block");




                FetchCourseWiseCoursePartList(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, "DD_CoursePart");
                FetchCoursePartWiseCoursePartTermList(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value,hidCrPrID.Value, "DD_CoursePart");

                DD_CoursePart.SelectedValue = hidCrPrID.Value;
                DD_CoursePartTerm.SelectedValue = hidCrPrChID.Value;
                //fnFillState(hidStateID.Value);

                fnFillState(hidBodyState.Value);
                Body_Country.Items.FindByValue(hidCountryIDForeign.Value).Selected = true;
                /* if (hidBodyState.Value != "0")
                 {
                     Body_State.SelectedItem.Text = hidStateSelText.Value;
                 }*/
                lnkPRN.Enabled = true;
                lnkSelectCr.Enabled = true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && hidBodyID.Value == "0" && hidCountryIDForeign.Value == "0")
            {
                /*string strScript = "<script language='JavaScript'>alert('Please Select State and Board/University')</script>";
                Page.RegisterStartupScript("PopUp", strScript);*/
                if (Body_Type_Flag.SelectedItem.Value == "1")
                {
                    TdBodyCaption.InnerText = "Select Board";
                }
                else if (Body_Type_Flag.SelectedItem.Value == "2")
                {
                    TdBodyCaption.InnerText = "Select " + lblUniversity.Text + "";
                }

                rbFilterYesNo.SelectedItem.Value = "1";
                rbFilterYesNo.Items[0].Selected = true;
                DivFilterExamBody.Attributes.Add("style", "display:inline");

                trStatistics.Attributes.Add("style", "display:none");
                trStatisticsWithoutInv.Attributes.Add("style", "display:none");
                trfilter.Attributes.Add("style", "display:none");
                trGrids.Attributes.Add("style", "display:none");
                lblRights.Attributes.Add("style", "display:none");

            }

        }
        #endregion

        #region Fill Course

        public void fillCourse()
        {
            common = new clsCommon();
            DataTable dt = new DataTable();
            // dt = InstRep.Get_AllCourse(hidUniID.Value, hidInstID.Value);
            dt = clsInstitute.Get_AllCourse(hidUniID.Value, hidInstID.Value);

            common.fillDropDown(DD_Course, dt, "", "text", "value", "--- Select ---");
            BindTooltip(DD_Course);
            dt.Dispose();
        }

        #endregion

        #region Function to Fetch CourseWisecoursepartList to retain the values in the dropdownlist

        public void FetchCourseWiseCoursePartList(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string HtmlSelCrBrnID)
        {
            DataTable dt = clsInstitute.Get_AllCoursePartOnly(UniID, InstID, FacID, CrID, MoLrnID, PtrnID, BrnID);

            DD_CoursePart.DataSource = dt;
            DD_CoursePart.DataTextField = "text";
            DD_CoursePart.DataValueField = "value";
            DD_CoursePart.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            DD_CoursePart.Items.Insert(0, li);
            BindTooltip(DD_CoursePart);
        }

        #endregion

        #region Function to Fetch CourseWisecoursepartList to retain the values in the dropdownlist

        public void FetchCoursePartWiseCoursePartTermList(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetID,string HtmlSelCrBrnID)
        {
            InstituteRepository oInstituteRepository = new InstituteRepository();
            DataTable dt = oInstituteRepository.AssignCoursePartTerm(UniID, InstID, FacID, CrID, MoLrnID, PtrnID, BrnID,CrPrDetID);

            DD_CoursePartTerm.DataSource = dt;
            DD_CoursePartTerm .DataTextField = "text";
            DD_CoursePartTerm.DataValueField = "value";
            DD_CoursePartTerm.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            DD_CoursePartTerm.Items.Insert(0, li);
            BindTooltip(DD_CoursePartTerm);
        }

        #endregion

        #region Function Display Grid
        private void displayGrids()
        {
            hid_AcademicYear.Value = ddlAcademicYear.SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;
            lblUnselectCheck.Text = "";

            tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:inline");

            //Fill DataTable to get statistics of no. records processed at college level and no. of records to be processed and University Level

            DataSet dsStudDet = new DataSet();

            if (hidRightsFlag.Value == "1") //College Side Eligibility Rights
            {
                trStatistics.Attributes.Add("style", "display:inline");
                trGrids.Attributes.Add("style", "display:none");
                lblRights.Text = "Eligibility rights for selected " + lblCr.Text.ToLower() + " are at " + lblCollege.Text + " side" + "<br><br>";
                hidCollege_Eligibility_Flag.Value = "1";
            }
            else //University Side Eligibility Rights
            {
                trStatistics.Attributes.Add("style", "display:inline");
                trGrids.Attributes.Add("style", "display:none");
                lblRights.Text = "Eligibility rights for selected " + lblCr.Text.ToLower() + " are at " + lblUniversity.Text + " side" + "<br><br>";
                hidCollege_Eligibility_Flag.Value = "4";

            }
            trfilter.Attributes.Add("style", "display:block");
            try
            {
                //CASE 1 STARTS
                if (rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                {
                    //if (rbWithInv.Checked == true)
                    //{
                    //    trStatistics.Attributes.Add("style", "display:block");
                    //    trStatisticsWithoutInv.Attributes.Add("style", "display:none");

                    //    dsStudDet = clsEligibilityRights.Elg_Get_Eligibility_Statistics(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value, hidCollege_Eligibility_Flag.Value, hid_fk_AcademicYr_ID.Value,hidCrPrChID.Value);

                    //    if (dsStudDet.Tables[0].Rows.Count > 0)
                    //    {
                    //        //Display Count of Eligibility for College and University
                    //        lblCollCount.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                    //        lblUniCount.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                    //        lblNonPaidCollCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidCollCount"].ToString();
                    //        lblNonPaidUniCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidUniCount"].ToString();

                    //    }

                    //    hidCollCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                    //    hidUniCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                    //    hidUnPaidCollCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["UnPaidCollCount"].ToString();
                    //    hidUnPaidUniCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["UnPaidUniCount"].ToString();

                    //    if ((hidCollCountWithInv.Value) != "0" || (hidUniCountWithInv.Value) != "0" || (hidUnPaidCollCountWithInv.Value) != "0" || (hidUnPaidUniCountWithInv.Value) != "0" && rbFilterYesNo.SelectedItem.Value.ToString() == "1")
                    //    {
                    //        Div1.Attributes.Add("style", "display:block");
                    //        //tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:inline");
                    //        trStatisticsWithoutInv.Attributes.Add("style", "display:none");
                    //        trStatistics.Attributes.Add("style", "display:none");
                    //        tblStatistics1.Attributes.Add("style", "display:none");
                    //        tblStatistics.Attributes.Add("style", "display:none");
                    //        trfilter.Attributes.Add("style", "display:block");
                    //        fldFilter.Attributes.Add("style", "display:block");
                    //    }
                    //    else if ((hidCollCountWithInv.Value) != "0" || (hidUniCountWithInv.Value) != "0" || (hidUnPaidCollCountWithInv.Value) != "0" || (hidUnPaidUniCountWithInv.Value) != "0" && rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                    //    {
                    //        Div1.Attributes.Add("style", "display:block");
                    //        //tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:inline");
                    //        trStatisticsWithoutInv.Attributes.Add("style", "display:none");
                    //        tblStatistics1.Attributes.Add("style", "display:none");
                    //        trStatistics.Attributes.Add("style", "display:block");
                    //        tblStatistics.Attributes.Add("style", "display:block");
                    //        lblRights.Attributes.Add("style", "display:block");
                    //        trfilter.Attributes.Add("style", "display:block");
                    //        fldFilter.Attributes.Add("style", "display:block");

                    //    }
                    //    else if ((hidCollCountWithInv.Value) == "0" || (hidCollCountWithInv.Value) == "0" || (hidUnPaidCollCountWithInv.Value) == "0" || (hidUnPaidUniCountWithInv.Value) == "0")
                    //    {
                    //        Div1.Attributes.Add("style", "display:none");

                    //        trfilter.Attributes.Add("style", "display:none");
                    //        lblNoRecords.Attributes.Add("style", "display:block");
                    //        lblNoRecords.Visible = true;
                    //        lblNoRecords.Text = "No Records Found";
                    //        //trfilter.Visible = false;

                    //    }

                    //}
                  //  else if (rbWithoutInv.Checked == true)
                    //{
                        //tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");

                        trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                        trStatistics.Attributes.Add("style", "display:none");
                        tblStatistics1.Attributes.Add("style", "display:block");

                        dsStudDet = clsEligibilityRights.Elg_Get_Eligibility_Statistics_bypassInv(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value, hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value,hidCrPrChID.Value);


                        if (dsStudDet.Tables[0].Rows.Count > 0)
                        {
                            //Display Count of Eligibility for College and University
                            lblCollCount1.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                            lblUniCount1.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();

                        }

                        hidCollCount1.Value = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                        hidUniCount1.Value = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                       
                        if ((hidCollCount1.Value) != "0" || (hidUniCount1.Value) != "0" && rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                        {
                            Div1.Attributes.Add("style", "display:block");
                            //tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");
                            trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                            //trStatistics.Attributes.Add("style", "display:block");
                            tblStatistics1.Attributes.Add("style", "display:block");
                            lblRights.Attributes.Add("style", "display:block");
                            trfilter.Attributes.Add("style", "display:block");
                            fldFilter.Attributes.Add("style", "display:block");

                        }
                        else if ((hidCollCount1.Value) != "0" || (hidUniCount1.Value) != "0" && rbFilterYesNo.SelectedItem.Value.ToString() == "1")
                        {
                            Div1.Attributes.Add("style", "display:block");
                            //tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");
                            trStatisticsWithoutInv.Attributes.Add("style", "display:none");
                            trStatistics.Attributes.Add("style", "display:none");
                            tblStatistics1.Attributes.Add("style", "display:none");
                            //trStatisticsWithoutInv.Attributes.Add("style", "display:none");
                            //lblRights.Attributes.Add("style", "display:none");
                            trfilter.Attributes.Add("style", "display:block");
                            fldFilter.Attributes.Add("style", "display:block");
                        }
                        else if ((hidCollCount1.Value) == "0" || (hidUniCount1.Value) == "0" && rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                        {
                            Div1.Attributes.Add("style", "display:none");

                            /*tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");
                            trStatisticsWithoutInv.Attributes.Add("style", "display:none");
                            trStatistics.Attributes.Add("style", "display:none");
                            tblStatistics1.Attributes.Add("style", "display:none");

                            //trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                            lblRights.Attributes.Add("style", "display:none");*/
                            trfilter.Attributes.Add("style", "display:none");
                            lblNoRecords1.Attributes.Add("style", "display:block");
                            lblNoRecords1.Visible = true;
                            lblNoRecords1.Text = "No Records Found";

                        }

                    }
            //    }
                //CASE 1 ENDS

                //CASE 2 STARTS

                else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "0")
                {

                    //if (rbWithInv.Checked == true)
                    //{
                    //    trStatistics.Attributes.Add("style", "display:block");
                    //    trStatisticsWithoutInv.Attributes.Add("style", "display:none");

                    //    dsStudDet = clsEligibilityRights.Elg_Get_Eligibility_Statistics_ExamBody(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value, hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value, hidBodyState.Value, hidBodyID.Value, hidCrPrChID.Value);

                    //    if (dsStudDet.Tables[0].Rows.Count > 0)
                    //    {
                    //        //Display Count of Eligibility for College and University
                    //        lblCollCount.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                    //        lblUniCount.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                    //        lblNonPaidCollCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidCollCount"].ToString();
                    //        lblNonPaidUniCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidUniCount"].ToString();

                    //    }
                    //    hidCollCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                    //    hidUniCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                    //    hidUnPaidCollCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["UnPaidCollCount"].ToString();
                    //    hidUnPaidUniCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["UnPaidUniCount"].ToString();

                    //    if ((hidCollCountWithInv.Value) != "0" || (hidUniCountWithInv.Value) != "0" || (hidUnPaidCollCountWithInv.Value) != "0" || (hidUnPaidUniCountWithInv.Value) != "0" && rbFilterYesNo.SelectedItem.Value.ToString() == "1")
                    //    {
                    //        Div1.Attributes.Add("style", "display:block");
                    //        tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:inline");
                    //        trStatistics.Attributes.Add("style", "display:block");
                    //        tblStatistics1.Attributes.Add("style", "display:none");
                    //        lblRights.Attributes.Add("style", "display:block");
                    //        trfilter.Attributes.Add("style", "display:block");
                    //        fldFilter.Attributes.Add("style", "display:block");
                    //        if (hidBodyState.Value != "0")
                    //        {
                    //            Body_State.SelectedItem.Text = hidStateSelText.Value;
                    //        }

                    //    }
                    //    else if ((hidCollCountWithInv.Value) == "0" || (hidUniCountWithInv.Value) == "0" || (hidUnPaidCollCountWithInv.Value) == "0" || (hidUnPaidUniCountWithInv.Value) == "0" && rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                    //    {

                    //        Div1.Attributes.Add("style", "display:block");
                    //        tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:inline");
                    //        trStatisticsWithoutInv.Attributes.Add("style", "display:none");
                    //        tblStatistics1.Attributes.Add("style", "display:none");
                    //        trStatistics.Attributes.Add("style", "display:block");
                    //        tblStatistics.Attributes.Add("style", "display:block");
                    //        lblRights.Attributes.Add("style", "display:block");
                    //        //trfilter.Attributes.Add("style", "display:block");

                    //        lblNoRecords.Attributes.Add("style", "display:block");
                    //        lblNoRecords.Visible = true;
                    //        lblNoRecords.Text = "No Records Found";

                    //    }

                    //    else if ((hidCollCountWithInv.Value) == "0" || (hidCollCountWithInv.Value) == "0" || (hidUnPaidCollCountWithInv.Value) == "0" || (hidUnPaidUniCountWithInv.Value) == "0")
                    //    {
                    //        Div1.Attributes.Add("style", "display:none");

                    //    }

                    //}



                    //else if (rbWithoutInv.Checked == true)
                    //{

                        dsStudDet = clsEligibilityRights.Elg_Get_Eligibility_Statistics_bypassInv_ExamBody(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value, hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value, hidBodyState.Value, hidBodyID.Value,hidCrPrChID.Value);

                        if (dsStudDet.Tables[0].Rows.Count > 0)
                        {
                            //Display Count of Eligibility for College and University
                            lblCollCount1.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                            lblUniCount1.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();

                        }
                        hidCollCount1.Value = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                        hidUniCount1.Value = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();

                        if ((hidCollCount1.Value) != "0" || (hidUniCount1.Value) != "0" && rbFilterYesNo.SelectedItem.Value.ToString() == "1")
                        {
                            /*Div1.Attributes.Add("style", "display:block");
                            tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");
                            tblStatistics1.Attributes.Add("style", "display:block");
                            trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                            trStatistics.Attributes.Add("style", "display:none");*/


                            Div1.Attributes.Add("style", "display:block");
                            tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");
                            trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                            trStatistics.Attributes.Add("style", "display:none");
                            tblStatistics1.Attributes.Add("style", "display:block");
                            lblRights.Attributes.Add("style", "display:block");
                            trfilter.Attributes.Add("style", "display:block");
                            trfilter.Attributes.Add("style", "display:block");
                            fldFilter.Attributes.Add("style", "display:block");
                            if (hidBodyState.Value != "0")
                            {
                                Body_State.SelectedItem.Text = hidStateSelText.Value;
                            }

                        }
                        else if ((hidCollCount1.Value) == "0" || (hidUniCount1.Value) == "0" && rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                        {
                            /*Div1.Attributes.Add("style", "display:none");
                            tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");
                            trStatisticsWithoutInv.Attributes.Add("style", "display:none");
                            trStatistics.Attributes.Add("style", "display:none");
                            tblStatistics1.Attributes.Add("style", "display:none");
                            trfilter.Attributes.Add("style", "display:none");*/

                            Div1.Attributes.Add("style", "display:block");                           
                            trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                            tblStatistics1.Attributes.Add("style", "display:block");
                            trStatistics.Attributes.Add("style", "display:none");
                            tblStatistics.Attributes.Add("style", "display:none");
                            lblRights.Attributes.Add("style", "display:block");
                            trfilter.Attributes.Add("style", "display:none");
                            trfilter.Attributes.Add("style", "display:none");

                            lblNoRecords1.Attributes.Add("style", "display:block");
                            lblNoRecords1.Visible = true;
                            lblNoRecords1.Text = "No Records Found";
                        }

                        /*else 
                        {
                            Div1.Attributes.Add("style", "display:none");
                            tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");
                            trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                            trStatistics.Attributes.Add("style", "display:none");
                            tblStatistics1.Attributes.Add("style", "display:none");
                            trfilter.Attributes.Add("style", "display:block");

                        }*/

                        else if ((hidCollCount1.Value) == "0" || (hidUniCount1.Value) == "0")
                        {
                            //************
                            Div1.Attributes.Add("style", "display:block");

                        }


                 //   }

                }
                //CASE 2 ENDS

                //CASE 2 STARTS

                else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "1")
                {

                  //  if (rbWithInv.Checked == true)
                    //{
                    //    trStatistics.Attributes.Add("style", "display:block");
                    //    trStatisticsWithoutInv.Attributes.Add("style", "display:none");

                    //    dsStudDet = clsEligibilityRights.Elg_Get_Eligibility_Statistics_ExamBody_Foreign(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,  hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value, hidCountryIDForeign.Value, hidtxtCountryForeignBoardUniv.Value,hidCrPrChID.Value);

                    //    if (dsStudDet.Tables[0].Rows.Count > 0)
                    //    {
                    //        //Display Count of Eligibility for College and University
                    //        lblCollCount.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                    //        lblUniCount.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                    //        lblNonPaidCollCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidCollCount"].ToString();
                    //        lblNonPaidUniCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidUniCount"].ToString();

                    //    }

                    //    hidCollCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                    //    hidUniCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                    //    hidUnPaidCollCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["UnPaidCollCount"].ToString();
                    //    hidUnPaidUniCountWithInv.Value = dsStudDet.Tables[0].Rows[0]["UnPaidUniCount"].ToString();

                    //    if ((hidCollCountWithInv.Value) != "0" || (hidUniCountWithInv.Value) != "0" || (hidUnPaidCollCountWithInv.Value) != "0" || (hidUnPaidUniCountWithInv.Value) != "0")
                    //    {
                    //        Div1.Attributes.Add("style", "display:block");
                    //        tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:inline");
                    //        trStatisticsWithoutInv.Attributes.Add("style", "display:none");
                    //        trStatistics.Attributes.Add("style", "display:none");
                    //        tblStatistics1.Attributes.Add("style", "display:none");
                    //        tblStatistics.Attributes.Add("style", "display:none");
                    //        trfilter.Attributes.Add("style", "display:block");
                    //        fldFilter.Attributes.Add("style", "display:block");
                    //        //Body_State.SelectedItem.Text = hidStateSelText.Value;
                    //    }
                    //    else
                    //    {
                    //        //***********
                    //        Div1.Attributes.Add("style", "display:block");

                    //        tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:inline");
                    //        trStatisticsWithoutInv.Attributes.Add("style", "display:none");
                    //        trStatistics.Attributes.Add("style", "display:block");
                    //        tblStatistics.Attributes.Add("style", "display:block");
                    //        tblStatistics1.Attributes.Add("style", "display:none");
                    //        trfilter.Attributes.Add("style", "display:none");
                    //        fldFilter.Attributes.Add("style", "display:none");
                    //        //lblRights.Attributes.Add("style", "display:none");
                    //        lblNoRecords.Attributes.Add("style", "display:block");
                    //        lblNoRecords.Visible = true;
                    //        lblNoRecords.Text = "No Records Found";


                    //    }

                    //}
                    //else if (rbWithoutInv.Checked == true)
                    //{
                        tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");

                        trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                        trStatistics.Attributes.Add("style", "display:none");
                        tblStatistics1.Attributes.Add("style", "display:block");

                        dsStudDet = clsEligibilityRights.Elg_Get_Eligibility_Statistics_bypassInv_ExamBody_Foerign(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value, hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value, hidCountryIDForeign.Value, hidtxtCountryForeignBoardUniv.Value);


                        if (dsStudDet.Tables[0].Rows.Count > 0)
                        {
                            //Display Count of Eligibility for College and University
                            lblCollCount1.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                            lblUniCount1.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();

                        }
                        hidCollCount1.Value = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                        hidUniCount1.Value = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();

                        if ((hidCollCount1.Value) != "0" || (hidUniCount1.Value) != "0")
                        {
                            Div1.Attributes.Add("style", "display:block");
                            tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");
                            trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                            trStatistics.Attributes.Add("style", "display:none");
                            tblStatistics1.Attributes.Add("style", "display:block");
                            trfilter.Attributes.Add("style", "display:block");
                            fldFilter.Attributes.Add("style", "display:block");
                            //Body_State.SelectedItem.Text = hidStateSelText.Value;
                        }
                        else
                        {
                            //***********
                            Div1.Attributes.Add("style", "display:block");

                            tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");
                            trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                            trStatistics.Attributes.Add("style", "display:none");
                            tblStatistics1.Attributes.Add("style", "display:block");
                            trfilter.Attributes.Add("style", "display:none");
                            fldFilter.Attributes.Add("style", "display:none");
                            //lblRights.Attributes.Add("style", "display:none");
                            lblNoRecords1.Attributes.Add("style", "display:block");
                            lblNoRecords1.Visible = true;
                            lblNoRecords1.Text = "No Records Found";


                        }

                    }

                }

                //CASE 3 ENDS
           // }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                dsStudDet.Dispose();
            }


            // DisplayCollegeOrUniversityGrid();
        }
        #endregion

        #region Display College or University Grid

        public void DisplayCollegeOrUniversityGrid()
        {
            //Fill DataTable to get statistics of no. records processed at college level and no. of records to be processed and University Level
            //and Details of students that are processed at College level or are to be processed by the University.
            DataSet dsStudDet = new DataSet();
            DataView dv = new DataView();
            string strfilterFlag = "";
            if (rbFilterYes.Checked == true)
                strfilterFlag = "1";
            else if (rbFilterNo.Checked == true)
                strfilterFlag = "0";
            //rdEligible.Checked = true;
            //rdProvisionalEligible.Checked = false;
            try
            {
               // if (rbWithInv.Checked == true)
                //{
                //    trStatistics.Attributes.Add("style", "display:block");
                //    trStatisticsWithoutInv.Attributes.Add("style", "display:none");

                //    //dsStudDet = clsEligibilityRights.Elg_Get_StudentsList_Coll_Uni(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hid_fk_AcademicYr_ID.Value,hidCollege_Eligibility_Flag.Value, strfilterFlag.ToString(), txtLastName.Text, txtFirstName.Text);

                //    if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "0")
                //    {
                //        dsStudDet = clsEligibilityRights.Elg_Get_StudentsList_Coll_Uni_ExamBody(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value, hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value, strfilterFlag.ToString(), txtLastName.Text, txtFirstName.Text, hidBodyState.Value, hidBodyID.Value);
                //    }
                //    else if (rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                //    {
                //        dsStudDet = clsEligibilityRights.Elg_Get_StudentsList_Coll_Uni(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value, hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value, strfilterFlag.ToString(), txtLastName.Text, txtFirstName.Text);
                //    }

                //    else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "1")
                //    {
                //        dsStudDet = clsEligibilityRights.Elg_Get_StudentsList_Coll_Uni_ExamBody_Foerign(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value, hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value, strfilterFlag.ToString(), txtLastName.Text, txtFirstName.Text, hidCountryIDForeign.Value, hidtxtCountryForeignBoardUniv.Value);
                //    }

                //    dv.Table = dsStudDet.Tables[0];
                //    //Bind College DataGrid if any record Present of College Side Eligibility

                //    if (dsStudDet.Tables[0].Rows.Count > 0)
                //    {
                //        //College_Eligibility_Flag="1" when records are made eligibilie at College level
                //        if (hidCollege_Eligibility_Flag.Value == "1")
                //        {
                //            lblUnselectCheck.Text = "Note : Following list does not include Students whose Eligibility is to be decided by " + lblUniversity.Text + ". You are required to process such students eligibility individually using Manual Process menu.<br>Select Records that you want to process.";
                //            lblUniCollPrn.Text = "Click on Save button on the Toolbar to generate " + lblPRNNomenclature.Text + " of Eligible students whose payment is received.";
                //        }
                //        //College_Eligibility_Flag="4" when Eligibility is to be processed at University Level
                //        if (hidCollege_Eligibility_Flag.Value == "4")
                //        {
                //            common = new clsCommon();
                //            lblUnselectCheck.Text = "Note : Select Records that you want to process.";
                //            lblUniCollPrn.Text = "Click on Save button on the Toolbar to mark student as Eligible and generate " + lblPRNNomenclature.Text + ".";
                //        }

                //        if (ViewState["SortExpression"] != null)
                //        {
                //            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();

                //        }
                //        trGrids.Attributes.Add("style", "display:inline");
                //        btnSave.Enabled = true;
                //        //DG_University.DataSource = dsStudDet.Tables[1];
                //        DG_University.DataSource = dv;
                //        DG_University.DataBind();
                //        DG_University.Columns[2].Visible = true;
                //        DG_University.Visible = true;
                //        lblNoRecords.Visible = false;
                //    }
                //    else
                //    {
                //        lblNoRecords.Text = "<br>No Records Found <br>";
                //        if (hidCollege_Eligibility_Flag.Value == "1" && lblUniCount.Text != "0")
                //        {
                //            lblNoRecords.Text = lblNoRecords.Text + "<br>" + "<font COLOR='BLACK'>" + "The records are not displayed because the Eligibility Rights are with the " + lblCollege.Text + " and the Students are marked by the " + lblCollege.Text + " as Eligibility to be decided by " + lblUniversity.Text + ". So one can process the Eligibility of such students by changing the Eligibility Rights from 'Configure Rights' Menu and assign the Rights to " + lblUniversity.Text + " or can process a single Student at a time using 'Manual Process'." + "</font>";

                //        }
                //        lblNoRecords.Visible = true;
                //        DG_PRN1.Visible = false;
                //        fldGrid.Attributes.Add("style", "display:none");
                //        trfilter.Attributes.Add("style", "display:none");
                //        fldEligibility.Attributes.Add("style", "display:none");
                //    }


                //}
              //  else if (rbWithoutInv.Checked == true)
              //  {
                    tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");

                    trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                    trStatistics.Attributes.Add("style", "display:none");
                    tblStatistics1.Attributes.Add("style", "display:block");

                    if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "0")
                    {
                        dsStudDet = clsEligibilityRights.Elg_Get_StudentsList_Coll_Uni_bypassInv_ExamBody(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value, hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value, strfilterFlag.ToString(), txtLastName.Text, txtFirstName.Text, hidBodyState.Value, hidBodyID.Value);
                    }
                    else if (rbFilterYesNo.SelectedItem.Value.ToString() == "0")
                    {
                        dsStudDet = clsEligibilityRights.Elg_Get_StudentsList_Coll_Uni_bypassInv(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value, hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value, strfilterFlag.ToString(), txtLastName.Text, txtFirstName.Text,  hidCrPrChID.Value);
                    }
                    else if (rbFilterYesNo.SelectedItem.Value.ToString() == "1" && Body_Indian_Foreign_Flag.SelectedItem.Value.ToString() == "1")
                    {
                        dsStudDet = clsEligibilityRights.Elg_Get_StudentsList_Coll_Uni_bypassInv_ExamBody_Foerign(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value, hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value, strfilterFlag.ToString(), txtLastName.Text, txtFirstName.Text, hidCountryIDForeign.Value, hidtxtCountryForeignBoardUniv.Value);
                    }
                    dv.Table = dsStudDet.Tables[0];

                    if (dsStudDet.Tables[0].Rows.Count > 0)
                    {
                        //College_Eligibility_Flag="1" when records are made eligibilie at College level
                        if (hidCollege_Eligibility_Flag.Value == "1")
                        {
                            lblUnselectCheck.Text = "Note : Following list does not include Students whose Eligibility is to be decided by " + lblUniversity.Text + ". You are required to process such students eligibility individually using Manual Process menu.<br>Select Records that you want to process.";
                            lblUniCollPrn.Text = "Click on Save button on the Toolbar to generate " + lblPRNNomenclature.Text + " of Eligible students.";
                        }
                        //College_Eligibility_Flag="4" when Eligibility is to be processed at University Level
                        if (hidCollege_Eligibility_Flag.Value == "4")
                        {
                            common = new clsCommon();
                            lblUnselectCheck.Text = "Note : Select Records that you want to process.";
                            lblUniCollPrn.Text = "Click on Save button on the Toolbar to mark student as eligible and generate " + lblPRNNomenclature.Text + ".";
                        }

                        if (ViewState["SortExpression"] != null)
                        {
                            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();

                        }

                        trGrids.Attributes.Add("style", "display:inline");
                        btnSave.Enabled = true;
                        DG_University.DataSource = dv;
                        DG_University.Columns[2].Visible = false;
                        DG_University.DataBind();
                        DG_University.Visible = true;
                        lblNoRecords1.Visible = false;

                        //**************************
                        TrColorCodes.Attributes.Remove("display");
                        TrColorCodes.Attributes.Add("style", "display:block");
                        //**************************
                    }
                    else
                    {
                        lblNoRecords1.Text = "<br> No Records Found <br>";
                        if (hidCollege_Eligibility_Flag.Value == "1" && lblUniCount1.Text != "0")
                        {
                            lblNoRecords1.Text = lblNoRecords1.Text + "<br>" + "<font color='BLACK'>" + "The records are not displayed because the Eligibility Rights are with the " + lblCollege.Text + " and the Students are marked by the " + lblCollege.Text + " as Eligibility to be decided by " + lblUniversity.Text + ". So one can process the Eligibility of such students by changing the Eligibility Rights from 'Configure Rights' Menu and assign the Rights to " + lblUniversity.Text + " or can process a single Student at a time using 'Manual Process'." + "</font>";

                        }
                        lblNoRecords1.Visible = true;
                        DG_University.Visible = false;
                        DG_PRN1.Visible = false;
                        fldGrid.Attributes.Add("style", "display:none");
                        trfilter.Attributes.Add("style", "display:none");
                        fldEligibility.Attributes.Add("style", "display:none");
                    }

                }
           // }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);

            }
            finally
            {
                dsStudDet.Dispose();
            }
        }

        #endregion

        #region Function Display PRN

        public void Display_PRN()
        {
            try
            {
                DataTable DtPRN = clsEligibilityRights.Elg_Display_PRN(hidUniID.Value, hidYear.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value);
                DataView dv = new DataView();
                dv.Table = DtPRN;
                if (DtPRN.Rows.Count > 0)
                {
                    trGrids.Attributes.Add("style", "display:inline");
                    lblUnselectCheck.Visible = false;
                    lblUniCollPrn.Text = "List of eligible students with " + lblPRNNomenclature.Text + " for : " + DD_Course.SelectedItem.Text + " - " + DD_CoursePart.SelectedItem.Text;
                    //lblUnselectCheck.Text = "List of PRN generated students for : " + DD_Course.SelectedItem.Text + " - " + DD_CoursePart.SelectedItem.Text;
                    DG_University.Visible = false;
                    if (ViewState["SortExpression"] != null)
                    {
                        dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();

                    }
                    DG_PRN1.DataSource = dv;
                    DG_PRN1.DataBind();
                    fldGrid.Attributes.Add("style", "display:block");

                    DG_PRN1.Attributes.Add("style", "display:block");
                    DG_PRN1.Visible = true;
                }
                else
                {
                    trGrids.Attributes.Add("style", "display:inline");
                    lblUniCollPrn.Text = "List of Eligible and/or Provisionally Eligible Students with " + lblPRNNomenclature.Text + " for :" + DD_Course.SelectedItem.Text + " - " + DD_CoursePart.SelectedItem.Text;
                    lblUnselectCheck.Text = "This report will show only such " + lblPRNNomenclature.Text + "s for the selected " + lblCr.Text.ToLower() + " that were generated in current attempt. For entire report please use 'View Eligibility Status' menu.";
                    lblUniCollPrn.Visible = true;
                    lblUnselectCheck.Visible = true;
                    fldGrid.Attributes.Add("style", "display:block");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion

        #region Button Save Click

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sReturn = "";
            //string studID = "";
            string studYearID = string.Empty; 
            lblUnselectCheck.Text = "";
            int iCount = 0;
            DataSet ds = new DataSet();
            try
            {
                DataGridItemCollection items = DG_University.Items;
                StringBuilder oStringBuilder = new StringBuilder();
                //for (int i = 0; i < Convert.ToInt32(items.Count); i++)
                //{
                //    CheckBox cb = (CheckBox)items[i].FindControl("chkSelect");
                //    if ((cb != null) && (cb.Checked == true))
                //    {
                //        oStringBuilder.Append(
                //            DG_University.DataKeys[i].ToString().Trim());
                //        oStringBuilder.Append(",");
                //        // studID += DG_University.DataKeys[i].ToString().Trim() + ",";// Commented to use StrignBuilder
                //        iCount = Convert.ToInt32(iCount) + 1;
                //    }
                //}

                XmlDocument xml = new XmlDocument();
                XmlNode root = xml.CreateNode(XmlNodeType.Element, "R", "");
                XmlNode childNode = null;

                for (int i = 0; i < Convert.ToInt32(items.Count); i++)
                {
                    CheckBox cb = (CheckBox)items[i].FindControl("chkSelect");
                     if ((cb != null) && (cb.Checked == true))
                     {
                         childNode = xml.CreateNode(XmlNodeType.Element, "SD", "");
                         //childNode.AppendChild(xml.CreateElement("YrID")).InnerText = DG_University.Items[i].Cells[6].Text.ToString().Trim();
                         childNode.AppendChild(xml.CreateElement("YrID")).InnerText = DG_University.Items[i].Cells[9].Text.ToString().Trim();
                         childNode.AppendChild(xml.CreateElement("StuID")).InnerText = DG_University.DataKeys[i].ToString().Trim();
                         childNode.AppendChild(xml.CreateElement("CrPrDetID")).InnerText = hidCrPrID.Value;
                         root.AppendChild(childNode);
                         iCount = Convert.ToInt32(iCount) + 1;
                     }
                }
              
                xml.AppendChild(root);

                //studID = oStringBuilder.ToString();

                studYearID = xml.OuterXml.ToString();

                string ElgDecision;
                if (rdEligible.Checked)
                    ElgDecision = "1";
                else
                    ElgDecision = "5";

                //string DCServer = TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["DCServer"].ToString();
                //string DCDataBase = TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["DCDataBase"].ToString();

                string DCServer = clsGetSettings.DCServer;
                string DCDataBase = clsGetSettings.DCDatabase;

                sReturn = clsEligibilityRights.Bulk_Process_Eligibility_Data(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hid_fk_AcademicYr_ID.Value, studYearID, hidCollege_Eligibility_Flag.Value, ElgDecision.ToString(), txtReason.Text, sUser, hidCrPrChID.Value, DCServer, DCDataBase);
                if (sReturn == "Y")
                {
                    string SMSreturn = "";
                    string SMSMessage = "";
                    clsUser u = (clsUser)Session["User"];

                        SendSMS objSendSMS = new SendSMS();
                        ds = clsEligibilityRights.FetchRegisteredStudentDetailsForSMS(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrChID.Value, studYearID);
                        if (ds != null)
                        {
                           if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    //==========================================================================================
                                    // To fetch Student login credentials for displaying in SMS
                                    string userName = string.Empty, password = string.Empty;
                                    DataSet Ds = clsEligibilityRights.GetStudentCredentialsForSMS(ds.Tables[0].Rows[i]["pk_Uni_ID"].ToString(), ds.Tables[0].Rows[i]["pk_Year"].ToString(), ds.Tables[0].Rows[i]["pk_Student_ID"].ToString());
                                    if (Ds != null && Ds.Tables[0] != null && Ds.Tables[0].Rows.Count > 0)
                                    {
                                        userName = Ds.Tables[0].Rows[0]["UserName"].ToString();
                                        password = Ds.Tables[0].Rows[0]["Password"].ToString();
                                    }
                                    // ==========================================================================================

                                    //SMSMessage = "Congrats " + hidSMSFirstName.Value + ",You are eligible for " + hidSMSCrAbbr.Value + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your PRN:" + PRN + ".";
                                    if (ElgDecision == "1")
                                    {
                                        //SMSMessage = "Congrats " + ds.Tables[0].Rows[i]["FirstName"].ToString() + ",You are Eligible for " + ds.Tables[0].Rows[i]["CrAbbr"].ToString() + " for Academic Year " + ds.Tables[0].Rows[i]["Year"].ToString() + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your " + lblPRNNomenclature.Text + ":" + ds.Tables[0].Rows[i]["PRN"].ToString();
                                        //*****************************************************************************
                                        // Changes related to new SMS
                                        SMSMessage = clsEligibilityRights.GetSMSBody("24", ds.Tables[0].Rows[i]["FirstName"].ToString(), ds.Tables[0].Rows[i]["CrAbbr"].ToString(), ds.Tables[0].Rows[i]["Year"].ToString(), ds.Tables[0].Rows[i]["UniAbbr"].ToString().ToUpper(), ds.Tables[0].Rows[i]["PRN"].ToString(), clsGetSettings.SitePath, userName, password, string.Empty);
                                        //*****************************************************************************
                                    }
                                    if (ElgDecision == "5")
                                    {
                                        //SMSMessage = "Congrats " + ds.Tables[0].Rows[i]["FirstName"].ToString() + ",You are Provisionally Eligible for " + ds.Tables[0].Rows[i]["CrAbbr"].ToString() + " for Academic Year " + ds.Tables[0].Rows[i]["Year"].ToString() + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your " + lblPRNNomenclature.Text + ":" + ds.Tables[0].Rows[i]["PRN"].ToString();
                                        //*****************************************************************************
                                        // Changes related to new SMS
                                        SMSMessage = clsEligibilityRights.GetSMSBody("3", ds.Tables[0].Rows[i]["FirstName"].ToString(), ds.Tables[0].Rows[i]["CrAbbr"].ToString(), ds.Tables[0].Rows[i]["Year"].ToString(), ds.Tables[0].Rows[i]["UniAbbr"].ToString().ToUpper(), ds.Tables[0].Rows[i]["PRN"].ToString(), clsGetSettings.SitePath, userName, password,string.Empty);
                                        //*****************************************************************************
                                    }
                                    objSendSMS.epMessage = SMSMessage;
                                    objSendSMS.epUser = u.User_ID;  //Added By Saroj on 1st Nov 2007
                                    SMSreturn = objSendSMS.SendPersonalizedSMS(ds.Tables[0].Rows[i]["MobileNumber"].ToString().Trim(), "ELG" + ds.Tables[0].Rows[i]["EligibilityFormNo"].ToString());
                                }
                            }
                        }
                               
                    lblSave.Visible = true;
                    lblSave.CssClass = "saveNote";
                    lblSave.Text = "Eligibility processed for " + iCount + " students and " + lblPRNNomenclature.Text + " generated successfully.<br>To view list of Eligible students and " + lblPRNNomenclature.Text + " generated click on \"View Eligible Students With " + lblPRNNomenclature.Text + "\" link.";
                    lblUniCollPrn.Text = "";
                    displayGrids();
                    DisplayCollegeOrUniversityGrid();
                    txtReason.Text = "";
                }
                else
                {
                    lblSave.CssClass = "ErrorNote";
                    lblSave.Text = "System has encountered an error during Process.<br>Please try again later";
                    ds.Dispose();
                }
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message;
                string strScript = "<script language=javascript>alert('" + sMsg + "');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "key1", strScript);
                ds.Dispose();
            }
            finally
            {
                ds.Dispose();

            }
        }

        #endregion

        #region Button New Click

        protected void btnNew_Click(object sender, EventArgs e)
        {
            DD_Course.SelectedIndex = -1;
            DD_CoursePart.SelectedIndex = -1;
            DD_CoursePartTerm.SelectedIndex = -1;
            //lblStatistics.Text = "";
            lblUnselectCheck.Text = "";
            tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:none");
            DG_University.Visible = false;
            DG_PRN1.Visible = false;
            lblSave.Text = "";
            lblUniCollPrn.Text = "";
            lblNoRecords.Text = "";
            btnSave.Enabled = false;
            //lblRights.Visible = false;
            trStatistics.Attributes.Add("style", "display:none");
            trStatisticsWithoutInv.Attributes.Add("style", "display:none");
            trfilter.Attributes.Add("style", "display:none");
            trGrids.Attributes.Add("style", "display:none");

            lnkSelectCr.Enabled = false;
            lnkPRN.Enabled = false;

            //********************
            Div1.Attributes.Add("style", "display:none");
            lblRights.Attributes.Add("style", "display:none");
            trStatistics.Attributes.Add("style", "display:none");
            trStatisticsWithoutInv.Attributes.Add("style", "display:none");
            DivFilterExamBody.Attributes.Add("style", "display:none");
            trfilter.Attributes.Add("style", "display:none");
            fldEligibility.Attributes.Add("style", "display:none");
            rbFilterYesNo.Items[1].Selected = true;
            fldGrid.Attributes.Add("style", "display:none");
            //********************

           
        }

        #endregion

        #region Datagrid Related Functions DG_University

        protected void DG_University_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            string[] ElgFormNo;
            //if(e.Item.ItemType == ListItemType.Header)
            //{
            //    e.Item.Cells[4].Text = lblStudName.Text;
            //}

            DG_University.Columns[4].HeaderText = lblStudName.Text;
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.DataSetIndex + 1);
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                //hidYear.Value = e.Item.Cells[6].Text.Trim();
                hidYear.Value = e.Item.Cells[9].Text.Trim();
                // hidElgFormNo.Value = e.Item.Cells[1].Text.Trim();
                ElgFormNo = e.Item.Cells[1].Text.Split('-');
                //  string ElgFormNo = e.Item.Cells[1].Text.Trim();
                e.Item.Cells[4].Text = "<a href='#' onclick=\"return openNewWindow(" + ElgFormNo[0] + ',' + ElgFormNo[1] + ',' + ElgFormNo[2] + ',' + ElgFormNo[3] + ',' + e.Item.Cells[8].Text + "," + e.Item.Cells[10].Text + "," + e.Item.Cells[9].Text + "," + e.Item.Cells[11].Text + "," + e.Item.Cells[12].Text + "," + e.Item.Cells[13].Text + "," + e.Item.Cells[14].Text + "," + e.Item.Cells[15].Text + "," + e.Item.Cells[16].Text + "," + e.Item.Cells[17].Text + ");\">" + e.Item.Cells[4].Text + "</a>";
                //e.Item.Cells[3].Text = "<a href='#' onclick=\"return openNewWindow(" + ElgFormNo[0] + ',' + ElgFormNo[1] + ',' + ElgFormNo[2] + ',' + ElgFormNo[3] + ',' + e.Item.Cells[5].Text + "," + e.Item.Cells[7].Text + "," + e.Item.Cells[6].Text + "," + e.Item.Cells[8].Text + "," + e.Item.Cells[9].Text + "," + e.Item.Cells[10].Text + "," + e.Item.Cells[11].Text + "," + e.Item.Cells[12].Text + "," + e.Item.Cells[13].Text + "," + e.Item.Cells[14].Text + ");\">" + e.Item.Cells[3].Text + "</a>";
                // e.Item.Cells[3].Text = "<a href='#' onclick=\"return openNewWindow(" + ElgFormNo + ',' + e.Item.Cells[5].Text + "," + e.Item.Cells[7].Text + "," + e.Item.Cells[6].Text + "," + e.Item.Cells[8].Text + ");\">" + e.Item.Cells[3].Text + "</a>";



               
               

                //**********************************************
                string BackColorCode = string.Empty;
                if (e.Item.Cells[18].Text == "same_university")
                {
                    BackColorCode = "#FFE4C4";
                }
                else if (e.Item.Cells[18].Text == "home_board")
                {
                    BackColorCode = "#E1FFFF";
                }
                else if (e.Item.Cells[18].Text == "other_state_board")
                {
                    BackColorCode = "#CCEEFF";
                }
                else if (e.Item.Cells[18].Text == "Foreign_board")
                {
                    BackColorCode = "#FFCCFF";
                }
                //**********************************************
                for (int i = 0; i < e.Item.Cells.Count; i++)
                {
                    e.Item.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml(BackColorCode);
                }
            }
        }

        /*protected void DG_PRN_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (DG_PRN.CurrentPageIndex * DG_PRN.PageSize) + 1);

                //e.Item.Cells[0].Text = Convert.ToString(e.Item.DataSetIndex + 1);
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }*/

        protected void DG_University_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            //try
            //{
            DG_University.CurrentPageIndex = e.NewPageIndex;
            DisplayCollegeOrUniversityGrid();
            //}
            /* catch
             {

                 try
                 {
                     this.DG_University.CurrentPageIndex = 0;
                     //this.DG_University.DataBind();
                     //this.DG_University.Visible = true;

                 }
                 catch
                 {
                     //this.lblError.Text = "No data for selection";
                     //this.lblError.Visible = true;
                 }
             }*/
        }

        protected void DG_University_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                if (ViewState["SortOrder"].ToString() == " asc")
                    ViewState["SortOrder"] = " desc";
                else
                    ViewState["SortOrder"] = " asc";
            }
            else
            {
                ViewState["SortExpression"] = e.SortExpression;
                ViewState["SortOrder"] = " asc";

            }
            DisplayCollegeOrUniversityGrid();
        }

        protected void DG_University_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {
                //hid_Year.Value = e.Item.Cells[6].Text.Trim();
                //hidStudentID.Value = e.Item.Cells[8].Text.Trim();
                hid_Year.Value = e.Item.Cells[9].Text.Trim();
                hidStudentID.Value = e.Item.Cells[11].Text.Trim();

            }
        }

        #region Commented By : Jatin 25 Jan 2010

        /* protected void DG_PRN_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DG_PRN.CurrentPageIndex = e.NewPageIndex;
            Display_PRN();
        }*/

        /*  protected void DG_PRN_SortCommand(object source, DataGridSortCommandEventArgs e)
          {

              if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
              {
                  if (ViewState["SortOrder"].ToString() == " asc")
                      ViewState["SortOrder"] = " desc";
                  else
                      ViewState["SortOrder"] = " asc";
              }
              else
              {
                  ViewState["SortExpression"] = e.SortExpression;
                  ViewState["SortOrder"] = " asc";
              }
              Display_PRN();

          }*/

        #endregion


        #endregion

        #region View Generated PRN link Click

        protected void lnkPRN_Click(object sender, EventArgs e)
        {
            lblSave.Visible = false;
            DG_University.Visible = false;
            fldEligibility.Visible = false;
            trCourse.Attributes.Add("style", "display:none");
            trStatistics.Attributes.Add("style", "display:none");
            trStatisticsWithoutInv.Attributes.Add("style", "display:none");
            tblToolBarMain.Attributes.Add("style", "display:none");
            trfilter.Attributes.Add("style", "display:none");
            trbtnProcessData.Attributes.Add("style", "display:none");
            //lblRights.Visible = false;

            //**************************
            TrColorCodes.Attributes.Remove("display");
            TrColorCodes.Attributes.Add("style", "display:none");
            lblRights.Attributes.Add("style", "display:none");
            //**************************
            //string Academic_Year_ID = Session["AcademicYearID"].ToString();
            Display_PRN();

        }

        #endregion

        #region Link Select Course Click

        protected void lnkSelectCr_Click(object sender, EventArgs e)
        {
            trCourse.Attributes.Add("style", "display:inline");
            trGrids.Attributes.Add("style", "display:block");
            trbtnProcessData.Attributes.Add("style", "display:block");
            //lblRights.Visible = true;
            //*****************************
            //rbFilterYesNo.Items[1].Selected = true;
            //rbFilterNo.Checked = true;

            if (rbFilterYesNo.Items[0].Selected)
            {
                DivFilterExamBody.Attributes.Add("style", "display:inline");
            }
           
            if (rbFilterYes.Checked)
            {
                trDecision.Attributes.Add("style", "display:inline");
            }
           
            //*****************************


            //if (rbWithInv.Checked == true)
            //{
            //    trStatistics.Attributes.Add("style", "display:inline");
            //    trStatisticsWithoutInv.Attributes.Add("style", "display:none");
            //}
            //else
            //{
                trStatisticsWithoutInv.Attributes.Add("style", "display:inline");
                trStatistics.Attributes.Add("style", "display:none");
           // }

            tblToolBarMain.Attributes.Add("style", "display:inline");
            lblUnselectCheck.Visible = true;
            fldEligibility.Visible = true;
            //rdEligible.Checked = true;
            //rdProvisionalEligible.Checked = false;
            txtReason.Text = "";
            DG_PRN1.PageIndex = 0;
            DG_PRN1.Visible = false;
            btnSave.Enabled = true;

            if (hidRightsFlag.Value == "0")
            {

                lblUnselectCheck.Text = "Note : Select Records that you want to process. <br> ";
                lblUniCollPrn.Text = "To make the following list of students Eligible and generate " + lblPRNNomenclature.Text + " click on save button.";
            }
            else
            {
                lblUnselectCheck.Text = "Note : Students whose Eligibility is to be decided by " + lblUniversity.Text + " are required to be processed individually using Manual Process Menu";
                lblUniCollPrn.Text = "List of Eligible students. To generate " + lblPRNNomenclature.Text + " for following list of students click on save button.";
            }


            // DG_University.Visible = true;
            
            //*************************************
            //displayGrids();
            //DisplayCollegeOrUniversityGrid();

            Div1.Attributes.Add("style", "display:none");
            lblRights.Attributes.Add("style", "display:none");
            trStatistics.Attributes.Add("style", "display:none");
            trStatisticsWithoutInv.Attributes.Add("style", "display:none");
            DivFilterExamBody.Attributes.Add("style", "display:none");
            trfilter.Attributes.Add("style", "display:none");
            fldEligibility.Attributes.Add("style", "display:none");
            rbFilterYesNo.Items[1].Selected = true;
            fldGrid.Attributes.Add("style", "display:none");
            
            //*************************************
        }

        #endregion

        #region btnFilterSubmit_Click

        protected void btnFilterSubmit_Click(object sender, EventArgs e)
        {
            fldEligibility.Attributes.Add("style", "display:block");
            fldGrid.Attributes.Add("style", "display:block");

            if (rbFilterYes.Checked == true)
            {
                trDecision.Attributes.Add("style", "display:block");
            }
            else if (rbFilterNo.Checked == true)
            {
                trDecision.Attributes.Add("style", "display:none");
                txtLastName.Text = "";
                txtFirstName.Text = "";
            }


            DisplayCollegeOrUniversityGrid();
        }

        #endregion

        #region function to Bind toolTip for all the items of a dropdownlist

        public static void BindTooltip(System.Web.UI.WebControls.DropDownList dl)
        {
            for (int i = 0; i < dl.Items.Count; i++)
            {
                dl.Items[i].Attributes.Add("title", dl.Items[i].Text);
            }
        }

        #endregion

        #region Function to fill State

        private void fnFillState(string stateID)
        {
            DataSet DSState = new DataSet();
            clsCommon common = new clsCommon();

            DataTable dt = clsCountry.ListCountry();
            common.fillDropDown(Body_Country, dt, fkCountryID, "Text", "Value", "--- Select ---");

            Body_State.Items.Clear();
            dt = clsEligibilityRights.ELGV2_displayAllStates_BulkProcess("E", hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);
            //DSState = clsEligibilityRights.ELGV2_displayAllStates("E", hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);
            if (dt.Rows.Count > 0)
            {
                common.fillDropDown(Body_State, dt, stateID, "Text", "Value", "--- Select ---");
                dt.Dispose();
                hidStateSelText.Value = Body_State.SelectedItem.Text;
                hidBodyTypeFlag.Value = dt.Rows[0]["UniOrBoardCheck"].ToString();

                if (hidBodyTypeFlag.Value == "1")
                {
                    Body_Type_Flag.Items[0].Enabled = true;
                    Body_Type_Flag.Items[0].Selected = true;
                    Body_Type_Flag.Items[1].Selected = false;
                    Body_Type_Flag.Items[1].Enabled = false;

                    TdBodyCaption.InnerText = "Select Body";

                }
                else if (hidBodyTypeFlag.Value == "2")
                {
                    Body_Type_Flag.Items[1].Enabled = true;
                    Body_Type_Flag.Items[1].Selected = true;
                    Body_Type_Flag.Items[0].Selected = false;
                    Body_Type_Flag.Items[0].Enabled = false;

                    TdBodyCaption.InnerText = "Select " + lblUniversity.Text + "";

                }

            }
            else
            {
                common.fillDropDown(Body_State, dt, stateID, "Text", "Value", "--- Select ---");
                dt.Dispose();
                hidStateSelText.Value = Body_State.SelectedItem.Text;
            }


        }

        #endregion

        #region Function to fill Board

        public void FillBoradDetails(string State, string Board)
        {
            clsCommon common = new clsCommon();
            DataTable dt;
            Body_State.Items.Clear();
            Body_ID.Items.Clear();
            try
            {
                //dt = clsState.displayAllStates("E");
                dt = clsEligibilityRights.ELGV2_displayAllStates_BulkProcess("E", hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Common.fillDropDown(Body_State, dt, State, "Text", "Value", "--- Select ---");

            if (Body_Type_Flag.SelectedItem.Value.ToString() == "1")
            {

                try
                {

                    dt = clsEligibilityRights.ELGV2_List_StateWiseBoard_BulkProcess(hidUniID.Value, hidInstID.Value, hid_StateID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                common.fillDropDown(Body_ID, dt, Board, "StateBoard_Description", "pk_BoardID", "--- Select ---");
                hidBodySelText.Value = Body_ID.SelectedItem.Text;

            }
            else if (Body_Type_Flag.SelectedItem.Value.ToString() == "2")
            {

                try
                {
                    if (hid_StateID.Value == "")
                    {
                        hid_StateID.Value = "0";
                    }

                    dt = clsEligibilityRights.ELGV2_ListStateWiseUniversities(hid_StateID.Value, hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                common.fillDropDown(Body_ID, dt, Board, "Uni_Name", "pk_Uni_ID", "--- Select ---");
                hidBodySelText.Value = Body_ID.SelectedItem.Text;
                //dt.Dispose;

            }
        }

        #endregion

        #region BtnAcademicYear Click

        protected void btnAcYr_Click(object sender, EventArgs e)
        {

           // btnAcYr.Attributes.Add("onclick", " return callvaliadteAcademic();");
            divAcademicYr.Style.Add("display", "none");
            DivCorseSelection.Style.Add("display", "block");
            trbtnProcessData.Style.Add("display", "block");

            hid_AcademicYear.Value = ddlAcademicYear.SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;

            if (hid_fk_AcademicYr_ID.Value != "0")
            {
                lblAcademicYear.Text = " for Academic Year " + hid_AcademicYear.Value;
                lblAcademicYear.Attributes.Add("style", "display:inline");
            }
            else
            {
                lblAcademicYear.Attributes.Add("style", "display:none");
            }


        }

        #endregion

        #region Datagrid Related Functions DG_PRN1

        protected void DG_PRN1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                if (ViewState["SortOrder"].ToString() == " asc")
                    ViewState["SortOrder"] = " desc";
                else
                    ViewState["SortOrder"] = " asc";
            }
            else
            {
                ViewState["SortExpression"] = e.SortExpression;
                ViewState["SortOrder"] = " asc";
            }
            Display_PRN();
        }

        protected void DG_PRN1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DG_PRN1.PageIndex = e.NewPageIndex;
            Display_PRN();
        }

        #endregion

        #region btnProcessData1_Click for Btn Click After Course - Course Part Selection - Not in Use

        protected void btnProcessData1_Click(object sender, EventArgs e)
        {
            Div1.Attributes.Add("style", "display:inline");            
            rbFilterYesNo.Items[1].Selected = true;
            rbFilterYesNo.Items[0].Selected = false;  
            tblStatistics.Attributes.Add("style", "display:none");
            trfilter.Attributes.Add("style", "display:none");
            trGrids.Attributes.Add("style", "display:none");
            trStatistics.Attributes.Add("style", "display:none");
            lblRights.Attributes.Add("style", "display:none");
            trStatisticsWithoutInv.Attributes.Add("style", "display:none");
            DivFilterExamBody.Attributes.Add("style", "display:none");
            
            FetchCourseWiseCoursePartList(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, "DD_CoursePart");
            DD_CoursePart.SelectedValue = hidCrPrID.Value;
            
            fnFillState(hid_StateID.Value);


        }

        #endregion

        protected void DG_PRN1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    e.Row.Cells[2].Text = lblStudName.Text;
            //}

            DG_PRN1.HeaderRow.Cells[2].Text = lblStudName.Text;
        }

        
    }
}
