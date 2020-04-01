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
using System.Resources;
using System.Threading;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_BulkProcess_reg_Students__1 : System.Web.UI.Page
    {
        clsCommon common;
        clsUser user;
        string sUser = "";
        string sRightsFlag = "";
        clsCommon Common = new clsCommon();
        clsCache clsCache = new clsCache();
        InstituteRepository InstRep = new InstituteRepository();

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAcYr.Attributes.Add("onclick", " return callvaliadteAcademic();");

            clsCache.NoCache();
            user = new clsUser();
            Ajax.Utility.RegisterTypeForAjax(typeof(ElgClasses.clsAjaxMethods));
            //Getting UserID
            user = (clsUser)Session["User"];
            sUser = user.User_ID.ToString();

            if (!IsPostBack)
            {

                ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                //Search_Institute ob = (Search_Institute)Context.Handler;
                searchInstNew temp = (searchInstNew)Cntph.FindControl("SchInst1");
                hidInstID.Value = ((HtmlInputHidden)Cntph.FindControl("hidInstID")).Value;
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();


                HtmlInputHidden[] hidden = new HtmlInputHidden[14];
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
                hidden[13] = hidIsPRNValidationRequired;

                common = new clsCommon();
                common.setHiddenVariables(ref hidden);
                if (common != null) common = null;

                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                Common.fillDropDown(ddlAcademicYear, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                ddlAcademicYear.SelectedIndex = 0;
                hid_AcademicYear.Value = ddlAcademicYear.SelectedItem.Text;
                hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;

                try
                {
                    hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
                }
                catch
                {
                    hidIsPRNValidationRequired.Value = "N";
                }

                fillCourse();
                //  fillCoursePart();
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
                //fillCoursePart();
                lblNoRecords.Text = "";

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

          //  rdEligible.Checked = true;


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
            btnProcessData.Attributes.Add("onClick", "return fnValidate();");
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
            trDecisionPRN.Attributes.Add("style", "display:none");
            try
            {
                //Get Rights Flag
                sRightsFlag = clsEligibilityRights.Elg_Get_Courses_Rights(hidUniID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value);
                hidRightsFlag.Value = sRightsFlag;

                displayGrids();
                FetchCourseWiseCoursePartList(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, "DD_CoursePart");
                FetchCoursePartWiseCoursePartTermList(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value, "DD_CoursePart");

                DD_CoursePart.SelectedValue = hidCrPrID.Value;
                DD_CoursePartTerm.SelectedValue = hidCrPrChID.Value;
                lnkPRN.Enabled = true;
                lnkSelectCr.Enabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

        public void FetchCoursePartWiseCoursePartTermList(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetID, string HtmlSelCrBrnID)
        {
            InstituteRepository oInstituteRepository = new InstituteRepository();
            DataTable dt = oInstituteRepository.AssignCoursePartTerm(UniID, InstID, FacID, CrID, MoLrnID, PtrnID, BrnID, CrPrDetID);

            DD_CoursePartTerm.DataSource = dt;
            DD_CoursePartTerm.DataTextField = "text";
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


            //lblStatistics.Text = "Statistics of Records";
            lblUnselectCheck.Text = "";

            tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:inline");

            //Fill DataTable to get statistics of no. records processed at college level and no. of records to be processed and University Level

            DataSet dsStudDet = new DataSet();

            if (hidRightsFlag.Value == "1") //College Side Eligibility Rights
            {
                trStatistics.Attributes.Add("style", "display:inline");
                trGrids.Attributes.Add("style", "display:none");
                lblRights.Text = "Eligibility rights for selected "+ lblCr.Text +" are at "+ lblCollege.Text +" side" + "<br><br>";
                hidCollege_Eligibility_Flag.Value = "1";
            }
            else //University Side Eligibility Rights
            {
                trStatistics.Attributes.Add("style", "display:inline");
                trGrids.Attributes.Add("style", "display:none");
                lblRights.Text = "Eligibility rights for selected " + lblCr.Text + " are at "+ lblUniversity.Text +" side" + "<br><br>";
                hidCollege_Eligibility_Flag.Value = "4";

            }
            trfilter.Attributes.Add("style", "display:block");
            try
            {
                //if (rbWithInv.Checked == true)
                //{
                //    trStatistics.Attributes.Add("style", "display:block");
                //    trStatisticsWithoutInv.Attributes.Add("style", "display:none");

                //    dsStudDet = clsEligibilityRights.Elg_Get_Eligibility_Statistics_RegStu(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value, hidCollege_Eligibility_Flag.Value, hid_fk_AcademicYr_ID.Value);

                //    if (dsStudDet.Tables[0].Rows.Count > 0)
                //    {
                //        //Display Count of Eligibility for College and University
                //        lblCollCount.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                //        lblUniCount.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                //        lblNonPaidCollCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidCollCount"].ToString();
                //        lblNonPaidUniCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidUniCount"].ToString();
                //        trfilter.Attributes.Add("style", "display:block");
                //        if (lblCollCount.Text == "0" && lblUniCount.Text == "0" && lblNonPaidCollCount.Text == "0" && lblNonPaidUniCount.Text == "0")
                //        {
                //            trfilter.Attributes.Add("style", "display:none");
                //        }

                //    }
             
                //}
                //else if (rbWithoutInv.Checked == true)
                //{
                    tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");

                    trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                    trStatistics.Attributes.Add("style", "display:none");
                    tblStatistics1.Attributes.Add("style", "display:block");

                    dsStudDet = clsEligibilityRights.Elg_Get_Eligibility_Statistics_bypassInv_RegStu(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value, hidCollege_Eligibility_Flag.Value, hid_fk_AcademicYr_ID.Value);


                    if (dsStudDet.Tables[0].Rows.Count > 0)
                    {
                        //Display Count of Eligibility for College and University
                        lblCollCount1.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                        lblUniCount1.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                        trfilter.Attributes.Add("style", "display:block");
                        if (lblCollCount1.Text == "0" && lblUniCount1.Text == "0")
                        {
                            trfilter.Attributes.Add("style", "display:none");
                        }

                    }
                 
                }
          //  }
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
            try
            {
               // if (rbWithInv.Checked == true)
                //{
                //    trStatistics.Attributes.Add("style", "display:block");
                //    trStatisticsWithoutInv.Attributes.Add("style", "display:none");

                //    dsStudDet = clsEligibilityRights.Elg_Get_StudentsList_Coll_Uni_RegStu(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value, hidCollege_Eligibility_Flag.Value, strfilterFlag.ToString(), txtLastName.Text, txtFirstName.Text, txtPRN.Text, hid_fk_AcademicYr_ID.Value);
                //    dv.Table = dsStudDet.Tables[0];
                //    /*
                //    if (dsStudDet.Tables.Count > 0)
                //    {
                //        //Display Count of Eligibility for College and University
                //        lblCollCount.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                //        lblUniCount.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                //        lblNonPaidCollCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidCollCount"].ToString();
                //        lblNonPaidUniCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidUniCount"].ToString();
                //     */
                //    //Bind College DataGrid if any record Present of College Side Eligibility

                //    if (dsStudDet.Tables[0].Rows.Count > 0)
                //    {
                //        //College_Eligibility_Flag="1" when records are made eligibilie at College level
                //        if (hidCollege_Eligibility_Flag.Value == "1")
                //        {
                //            lblUnselectCheck.Text = "Note : Following list does not include Students whose Eligibility is to be decided by "+ lblUniversity.Text +". You are required to process such students eligibility individually using Manual Process menu.<br>Select Records that you want to process.";
                //            lblUniCollPrn.Text = "Click on save button to generate "+ lblPRNNomenclature.Text +" of Eligible students whose payment is received.";
                //        }
                //        //College_Eligibility_Flag="4" when Eligibility is to be processed at University Level
                //        if (hidCollege_Eligibility_Flag.Value == "4")
                //        {
                //            common = new clsCommon();
                //            lblUnselectCheck.Text = "Note : Select Records that you want to process.";
                //            lblUniCollPrn.Text = "Click on save button to mark student as Eligible and generate "+ lblPRNNomenclature.Text +".";
                //        }

                //        if (ViewState["SortExpression"] != null)
                //        {
                //            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();

                //        }
                //        trGrids.Attributes.Add("style", "display:inline");
                //        btnSave.Enabled = true;
                //        //DG_University.DataSource = dsStudDet.Tables[1];
                //        DG_University1.DataSource = dv;
                //        DG_University1.DataBind();
                //        DG_University1.Columns[2].Visible = true;
                //        DG_University1.Visible = true;
                //        lblNoRecords.Visible = false;
                //    }
                //    else
                //    {
                //        lblNoRecords.Text = "<br>No Records Found <br>";
                //        if (hidCollege_Eligibility_Flag.Value == "1" && lblUniCount.Text != "0")
                //        {
                //            lblNoRecords.Text = lblNoRecords.Text + "<br>" + "<font COLOR='BLACK'>" + "The records are not displayed because the Eligibility Rights are with the "+ lblCollege.Text +" and the Students are marked by the "+ lblCollege.Text +" as Eligibility to be decided by "+ lblUniversity.Text +". So one can process the Eligibility of such students by changing the Eligibility Rights from 'Configure Rights' Menu and assign the Rights to "+ lblUniversity.Text +" or can process a single Student at a time using 'Manual Process'." + "</font>";

                //        }
                //        lblNoRecords.Visible = true;
                //        // tblGrid.Attributes.Add("style", "display:block");
                //        // DG_University.Visible = false;
                //        DG_PRN1.Visible = false;
                //        tblGrid.Attributes.Add("style", "display:none");
                //        trfilter.Attributes.Add("style", "display:none");
                //        fldEligibility.Attributes.Add("style", "display:none");
                //    }

                //    //}
                //}
                //else if (rbWithoutInv.Checked == true)
                //{
                    tblStatistics1.Attributes.Add("style", "border-collapse:collapse;display:inline");

                    trStatisticsWithoutInv.Attributes.Add("style", "display:block");
                    trStatistics.Attributes.Add("style", "display:none");
                    tblStatistics1.Attributes.Add("style", "display:block");

                    dsStudDet = clsEligibilityRights.Elg_Get_StudentsList_Coll_Uni_bypassInv_RegStu(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value,hidCrPrChID.Value, hidCollege_Eligibility_Flag.Value, strfilterFlag.ToString(), txtLastName.Text, txtFirstName.Text, txtPRN.Text, hid_fk_AcademicYr_ID.Value);
                    dv.Table = dsStudDet.Tables[0];
                    /*
                     if (dsStudDet.Tables.Count > 0)
                     {
                         //Display Count of Eligibility for College and University
                         lblCollCount1.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                         lblUniCount1.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                      */
                    //Bind College DataGrid if any record Present of College Side Eligibility

                    if (dsStudDet.Tables[0].Rows.Count > 0)
                    {
                        //College_Eligibility_Flag="1" when records are made eligibilie at College level
                        if (hidCollege_Eligibility_Flag.Value == "1")
                        {
                            lblUnselectCheck.Text = "Note : Following list does not include Students whose Eligibility is to be decided by "+ lblUniversity.Text +". You are required to process such students eligibility individually using Manual Process menu.<br>Select Records that you want to process.";
                            lblUniCollPrn.Text = "Click on save button to generate "+ lblPRNNomenclature.Text +" of Eligible students.";
                        }
                        //College_Eligibility_Flag="4" when Eligibility is to be processed at University Level
                        if (hidCollege_Eligibility_Flag.Value == "4")
                        {
                            common = new clsCommon();
                            lblUnselectCheck.Text = "Note : Select Records that you want to process.";
                            lblUniCollPrn.Text = "Click on save button to mark student as eligible and generate "+ lblPRNNomenclature.Text +".";
                        }

                        if (ViewState["SortExpression"] != null)
                        {
                            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();

                        }

                        trGrids.Attributes.Add("style", "display:inline");
                        btnSave.Enabled = true;
                        //DG_University.DataSource = dsStudDet.Tables[1];
                        DG_University1.DataSource = dv;
                        DG_University1.Columns[2].Visible = false;
                        DG_University1.DataBind();
                        DG_University1.Visible = true;
                        lblNoRecords1.Visible = false;
                    }
                    else
                    {
                        lblNoRecords1.Text = "<br> No Records Found <br>";
                        if (hidCollege_Eligibility_Flag.Value == "1" && lblUniCount1.Text != "0")
                        {
                            lblNoRecords1.Text = lblNoRecords1.Text + "<br>" + "<font color='BLACK'>" + "The records are not displayed because the Eligibility Rights are with the "+ lblCollege.Text +" and the Students are marked by the "+ lblCollege.Text +" as Eligibility to be decided by "+ lblUniversity.Text +". So one can process the Eligibility of such students by changing the Eligibility Rights from 'Configure Rights' Menu and assign the Rights to "+ lblUniversity.Text +" or can process a single Student at a time using 'Manual Process'." + "</font>";

                        }
                        lblNoRecords1.Visible = true;
                        DG_University1.Visible = false;
                        DG_PRN1.Visible = false;
                        tblGrid.Attributes.Add("style", "display:none");
                        trfilter.Attributes.Add("style", "display:none");
                        fldEligibility.Attributes.Add("style", "display:none");
                    }

                    //}

                }
           // }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    lblUniCollPrn.Text = "List of eligible students with "+ lblPRNNomenclature.Text +" for : " + DD_Course.SelectedItem.Text + " - " + DD_CoursePart.SelectedItem.Text;
                    //lblUnselectCheck.Text = "List of PRN generated students for : " + DD_Course.SelectedItem.Text + " - " + DD_CoursePart.SelectedItem.Text;
                    DG_University1.Visible = false;
                   
                    if (ViewState["SortExpression"] != null)
                    {
                        dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();

                    }
                    DG_PRN1.DataSource = dv;
                    DG_PRN1.DataBind();
                    tblGrid.Attributes.Add("style", "display:block");
                    DG_PRN1.Attributes.Add("style", "display:block");
                    DG_PRN1.Visible = true;
                }
                else
                {
                    trGrids.Attributes.Add("style", "display:inline");
                    lblUniCollPrn.Text = "List of Eligible and/or Provisionally Eligible Students with "+ lblPRNNomenclature.Text +" for :" + DD_Course.SelectedItem.Text + " - " + DD_CoursePart.SelectedItem.Text;
                    lblUnselectCheck.Text = "This report will show only such Student(s) with "+ lblPRNNomenclature.Text +" for the selected " + lblCr.Text.ToLower() + " whose Eligibility is processed in the current attempt. For entire report please use 'View Eligibility Status' menu.";
                    lblUniCollPrn.Visible = true;
                    lblUnselectCheck.Visible = true;
                    tblGrid.Attributes.Add("style", "display:block");
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
            string studYearID = "";
            lblUnselectCheck.Text = "";
            int iCount = 0;
            DataSet ds = new DataSet();
            try
            {
                //DataGridItemCollection items = DG_University.Items;
                GridViewRowCollection items = DG_University1.Rows;
                //StringBuilder oStringBuilder = new StringBuilder();
                //for (int i = 0; i < items.Count; i++)
                //{
                //    CheckBox cb = (CheckBox)items[i].FindControl("chkSelect");
                //    if ((cb != null) && (cb.Checked == true))
                //    {
                //        //studID += DG_University1.DataKeys[i].ToString().Trim() + ",";
                //        oStringBuilder.Append(DG_University1.DataKeys[i].Value.ToString().Trim());
                //        oStringBuilder.Append(",");
                //       // studID += DG_University1.DataKeys[i].Value.ToString().Trim() + ","; commented for using StringBuilder
                //        iCount = iCount + 1;
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
                        childNode.AppendChild(xml.CreateElement("YrID")).InnerText = DG_University1.Rows[i].Cells[7].Text.ToString().Trim();
                        //childNode.AppendChild(xml.CreateElement("StuID")).InnerText = DG_University1.DataKeys[i].Value.ToString().Trim();
                        childNode.AppendChild(xml.CreateElement("StuID")).InnerText = DG_University1.DataKeys[i].Value.ToString().Trim();
                        childNode.AppendChild(xml.CreateElement("CrPrDetID")).InnerText = hidCrPrID.Value;
                        root.AppendChild(childNode);
                        iCount = Convert.ToInt32(iCount) + 1;
                    }
                }

                xml.AppendChild(root);

                studYearID = xml.OuterXml.ToString();

                string ElgDecision;
                if (rdEligible.Checked)
                    ElgDecision = "1";
                else
                    ElgDecision = "5";

                sReturn = clsEligibilityRights.Bulk_Process_Eligibility_Data_RegStu(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrChID.Value, studYearID, hid_fk_AcademicYr_ID.Value, hidCollege_Eligibility_Flag.Value, ElgDecision, txtReason.Text, sUser);
                if (sReturn == "Y")
                {
                    string SMSreturn = "";
                    string SMSMessage = "";
                    clsUser u = (clsUser)Session["User"]; //Added By Saroj on 1st Nov 2007

                    SendSMS objSendSMS = new SendSMS();
                    ds = clsEligibilityRights.FetchRegisteredStudentDetailsForSMS(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrChID.Value, studYearID);
                    if (ds != null)
                    {
                        //if (ds.Tables.Count > 0)
                        //{
                        //    for (int i = 0; i < ds.Tables.Count; i++)
                        //    {
                        //        SMSMessage = "Congrats " + ds.Tables[i].Rows[0]["FirstName"].ToString() + ",U R elgble for " + ds.Tables[i].Rows[0]["CrAbbr"].ToString() + ",PRN:" + ds.Tables[i].Rows[0]["PRN"].ToString() + ",Collect eSuvidha LoginId,Password from college and visit " + Classes.clsGetSettings.SitePath.Replace("http://","");
                        //        objSendSMS.epMessage = SMSMessage;
                        //        SMSreturn = objSendSMS.SendPersonalizedSMS(ds.Tables[i].Rows[0]["MobileNumber"].ToString().Trim(), "ELG" + ds.Tables[i].Rows[0]["EligibilityFormNo"].ToString());
                        //    }
                        //}
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
                                //==========================================================================================
                                //SMSMessage = "Congrats " + hidSMSFirstName.Value + ",You are eligible for " + hidSMSCrAbbr.Value + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your PRN:" + PRN + ".";
                                if (ElgDecision == "1")
                                {
                                    //SMSMessage = "Congrats " + ds.Tables[0].Rows[i]["FirstName"].ToString() + ",You are Eligible for " + ds.Tables[0].Rows[i]["CrAbbr"].ToString() + " for Academic Year " + ds.Tables[0].Rows[i]["Year"].ToString() + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ".";// Your PRN:" + ds.Tables[0].Rows[i]["PRN"].ToString();
                                    //SMSMessage = clsEligibilityRights.GetSMSBody("25", ds.Tables[0].Rows[i]["FirstName"].ToString(), ds.Tables[0].Rows[i]["CrAbbr"].ToString(), ds.Tables[0].Rows[i]["Year"].ToString(), ds.Tables[0].Rows[i]["UniAbbr"].ToString().ToUpper(), "", TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SitePath"].ToString(), userName, password, string.Empty);

                                    SMSMessage = clsEligibilityRights.GetSMSBody("25", ds.Tables[0].Rows[i]["FirstName"].ToString(), ds.Tables[0].Rows[i]["CrAbbr"].ToString(), ds.Tables[0].Rows[i]["Year"].ToString(), ds.Tables[0].Rows[i]["UniAbbr"].ToString().ToUpper(), "", clsGetSettings.SitePath, userName, password, string.Empty);
                                }

                                if (ElgDecision == "5")
                                {
                                    //SMSMessage = "Congrats " + ds.Tables[0].Rows[i]["FirstName"].ToString() + ",You are Provisionally Eligible for " + ds.Tables[0].Rows[i]["CrAbbr"].ToString() + " for Academic Year " + ds.Tables[0].Rows[i]["Year"].ToString() + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + "."; // Your PRN:" + ds.Tables[0].Rows[i]["PRN"].ToString();
                                    SMSMessage = clsEligibilityRights.GetSMSBody("26", ds.Tables[0].Rows[i]["FirstName"].ToString(), ds.Tables[0].Rows[i]["CrAbbr"].ToString(), ds.Tables[0].Rows[i]["Year"].ToString(), ds.Tables[0].Rows[i]["UniAbbr"].ToString().ToUpper(), "", clsGetSettings.SitePath, userName, password, string.Empty);
                                }
                                objSendSMS.epMessage = SMSMessage;
                                objSendSMS.epUser = u.User_ID;  //Added By Saroj on 1st Nov 2007
                                SMSreturn = objSendSMS.SendPersonalizedSMS(ds.Tables[0].Rows[i]["MobileNumber"].ToString().Trim(), "ELG" + ds.Tables[0].Rows[i]["EligibilityFormNo"].ToString());
                            }
                        }
                    }


                    lblSave.Visible = true;
                    lblSave.CssClass = "saveNote";
                    lblSave.Text = "Eligibility processed for " + iCount + " students successfully.<br>To view list of eligible students and "+ lblPRNNomenclature.Text +" click on \"View Eligible Students With "+ lblPRNNomenclature.Text +"\" link.";
                    lblUniCollPrn.Text = "";
                    displayGrids();
                    DisplayCollegeOrUniversityGrid();
                    txtReason.Text = "";
                }
                else
                {
                    lblSave.CssClass = "ErrorNote";
                    lblSave.Text = "System has encountered an error during Process.<br>Please try again later";
                }
            }

            catch (Exception ex)
            {
                string sMsg = ex.Message;
                string strScript = "<script language=javascript>alert('" + sMsg + "');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "key1", strScript);
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
            lblStatistics.Text = "";
            lblUnselectCheck.Text = "";
            tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:none");
            DG_University1.Visible = false;
            DG_PRN1.Visible = false;
            lblSave.Text = "";
            lblUniCollPrn.Text = "";
            lblNoRecords.Text = "";
            btnSave.Enabled = false;
            lblUniCollPrn.Text = "";
            lblNoRecords.Text = "";
            btnSave.Enabled = false;
            lblRights.Visible = false;
            trStatistics.Attributes.Add("style", "display:none");
            trStatisticsWithoutInv.Attributes.Add("style", "display:none");
            trfilter.Attributes.Add("style", "display:none");
            trGrids.Attributes.Add("style", "display:none");

            lnkSelectCr.Enabled = false;
            lnkPRN.Enabled = false;
        }

        #endregion

        #region Datagrid Related Functions commented by :Jatin 

       /* protected void DG_University_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.DataSetIndex + 1);
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                hidYear.Value = e.Item.Cells[7].Text.Trim();
                // hidElgFormNo.Value = e.Item.Cells[1].Text.Trim();
                string[] ElgFormNo = e.Item.Cells[1].Text.Split('-');
                //  string ElgFormNo = e.Item.Cells[1].Text.Trim();
                e.Item.Cells[4].Text = "<a href='#' onclick=\"return openNewWindow(" + ElgFormNo[0] + ',' + ElgFormNo[1] + ',' + ElgFormNo[2] + ',' + ElgFormNo[3] + ',' + e.Item.Cells[6].Text + "," + e.Item.Cells[8].Text + "," + e.Item.Cells[7].Text + "," + e.Item.Cells[9].Text+","+ e.Item.Cells[10].Text + "," + e.Item.Cells[11].Text + "," +e.Item.Cells[12].Text + "," + e.Item.Cells[13].Text + "," + e.Item.Cells[14].Text + "," + e.Item.Cells[15].Text + ");\">" + e.Item.Cells[4].Text + "</a>";
                // e.Item.Cells[3].Text = "<a href='#' onclick=\"return openNewWindow(" + ElgFormNo + ',' + e.Item.Cells[5].Text + "," + e.Item.Cells[7].Text + "," + e.Item.Cells[6].Text + "," + e.Item.Cells[8].Text + ");\">" + e.Item.Cells[3].Text + "</a>";
            }
        }*/

        /*protected void DG_PRN_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.DataSetIndex + 1);
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }*/

       /* protected void DG_University_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DG_University.CurrentPageIndex = e.NewPageIndex;

            DisplayCollegeOrUniversityGrid();
        }*/

       /* protected void DG_University_SortCommand(object source, DataGridSortCommandEventArgs e)
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
        }*/

      /*  protected void DG_University_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {
                hid_Year.Value = e.Item.Cells[7].Text.Trim();
                hidStudentID.Value = e.Item.Cells[9].Text.Trim();

            }
        }*/

       /* protected void DG_PRN_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DG_PRN.CurrentPageIndex = e.NewPageIndex;
            Display_PRN();
        }*/

        /*protected void DG_PRN_SortCommand(object source, DataGridSortCommandEventArgs e)
        {*/
            /*if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
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
            }*/
           /* if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
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

        #region View Generated PRN link Click

        protected void lnkPRN_Click(object sender, EventArgs e)
        {

            lblSave.Visible = false;
            DG_University1.Visible = false;
            fldEligibility.Visible = false;
            trCourse.Attributes.Add("style", "display:none");
            trStatistics.Attributes.Add("style", "display:none");
            trStatisticsWithoutInv.Attributes.Add("style", "display:none");
            tblToolBarMain.Attributes.Add("style", "display:none");
            trfilter.Attributes.Add("style", "display:none");
            trbtnProcessData.Attributes.Add("style", "display:none");
            lblRights.Visible = false;
            Display_PRN();

        }

        #endregion

        #region Link Select Course Click

        protected void lnkSelectCr_Click(object sender, EventArgs e)
        {
            trCourse.Attributes.Add("style", "display:inline");
            trGrids.Attributes.Add("style", "display:block");
            trbtnProcessData.Attributes.Add("style", "display:block");
            lblRights.Visible = true;
           
            //if (rbWithInv.Checked == true)
            //{
            //    trStatistics.Attributes.Add("style", "display:inline");
            //    trStatisticsWithoutInv.Attributes.Add("style", "display:none");
            //}
            //else
            //{
                trStatisticsWithoutInv.Attributes.Add("style", "display:inline");
                trStatistics.Attributes.Add("style", "display:none");
          //  }

            tblToolBarMain.Attributes.Add("style", "display:inline");
            lblUnselectCheck.Visible = true;
            fldEligibility.Visible = true;
            rdEligible.Checked = true;
            rdProvisionalEligible.Checked = false;
            txtReason.Text = "";
            DG_PRN1.PageIndex = 0;
            DG_PRN1.Visible = false;
            btnSave.Enabled = true;

            if (hidRightsFlag.Value == "0")
            {

                lblUnselectCheck.Text = "Note : Select Records that you want to process.";
                lblUniCollPrn.Text = "To make the following list of students Eligible click on save button.";
            }
            else
            {
                lblUnselectCheck.Text = "Note : Students whose Eligibility is to be decided by "+ lblUniversity.Text +" are required to be proceesed individually using Manual Process menu";
                lblUniCollPrn.Text = "List of students. To mark the list of students Eligible or Provisionally Eligible click on save button.";
            }
            
            displayGrids();
            DisplayCollegeOrUniversityGrid();
        }

        #endregion

        protected void btnFilterSubmit_Click(object sender, EventArgs e)
        {
            fldEligibility.Attributes.Add("style", "display:block");
            tblGrid.Attributes.Add("style", "display:block");
            
            if (rbFilterYes.Checked == true)
            {
                trDecision.Attributes.Add("style", "display:block");
                trDecisionPRN.Attributes.Add("style", "display:block");
            }
            else if (rbFilterNo.Checked == true)
            {
                trDecision.Attributes.Add("style", "display:none");
                trDecisionPRN.Attributes.Add("style", "display:none");
                txtLastName.Text = "";
                txtFirstName.Text = "";
            }
          
            DisplayCollegeOrUniversityGrid();

        }

        #region function to Bind toolTip for all the items of a dropdownlist

        public static void BindTooltip(System.Web.UI.WebControls.DropDownList dl)
        {
            for (int i = 0; i < dl.Items.Count; i++)
            {
                dl.Items[i].Attributes.Add("title", dl.Items[i].Text);
            }
        }

        #endregion

        protected void btnAcYr_Click(object sender, EventArgs e)
        {
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

        #region GridView Related Events        
        
        protected void DG_University1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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


            if ((e.Row.RowType != DataControlRowType.Header) && (e.Row.RowType != DataControlRowType.Footer) && (e.Row.RowType != DataControlRowType.Pager))
            {
                hidYear.Value = e.Row.Cells[7].Text.Trim();
                // hidElgFormNo.Value = e.Item.Cells[1].Text.Trim();
                string[] ElgFormNo = e.Row.Cells[1].Text.Split('-');
                //  string ElgFormNo = e.Item.Cells[1].Text.Trim();
                e.Row.Cells[4].Text = "<a href='#' onclick=\"return openNewWindow(" + ElgFormNo[0] + ',' + ElgFormNo[1] + ',' + ElgFormNo[2] + ',' + ElgFormNo[3] + ',' + e.Row.Cells[6].Text + "," + e.Row.Cells[8].Text + "," + e.Row.Cells[7].Text + "," + e.Row.Cells[9].Text + "," + e.Row.Cells[10].Text + "," + e.Row.Cells[11].Text + "," + e.Row.Cells[12].Text + "," + e.Row.Cells[13].Text + "," + e.Row.Cells[14].Text + "," + e.Row.Cells[15].Text + ");\">" + e.Row.Cells[4].Text + "</a>";
                // e.Item.Cells[3].Text = "<a href='#' onclick=\"return openNewWindow(" + ElgFormNo + ',' + e.Item.Cells[5].Text + "," + e.Item.Cells[7].Text + "," + e.Item.Cells[6].Text + "," + e.Item.Cells[8].Text + ");\">" + e.Item.Cells[3].Text + "</a>";
            }
        }

        protected void DG_University1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = DG_University1.Rows[index];

                hid_Year.Value = row.Cells[7].Text.Trim();
                hidStudentID.Value = row.Cells[9].Text.Trim();

                //hid_Year.Value = e.Item.Cells[7].Text.Trim();
                //hidStudentID.Value = e.Item.Cells[9].Text.Trim();

            }
        }

        protected void DG_University1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DG_University1.PageIndex = e.NewPageIndex;
            DisplayCollegeOrUniversityGrid();
        }

        protected void DG_University1_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void DG_PRN1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Style.Add("display", "none");
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Style.Add("display", "none");
            }

        }

        protected void DG_PRN1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DG_PRN1.PageIndex = e.NewPageIndex;
            Display_PRN();
        }

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

        #endregion

    }
}
