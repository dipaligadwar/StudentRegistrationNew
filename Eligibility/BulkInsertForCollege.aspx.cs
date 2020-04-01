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
using Sancharak;

namespace StudentRegistration.Eligibility
{
    public partial class BulkInsertForCollege : System.Web.UI.Page
    {
        clsCommon common;
        clsUser user;
        string sUser = "";
        string sRightsFlag = "";       
        
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.clsCache.NoCache();
            user = new clsUser();
            
            //Getting UserID
            user = (clsUser)Session["User"];
            sUser = user.User_ID.ToString();

            if (!IsPostBack)
            {
                HtmlInputHidden[] hidden = new HtmlInputHidden[5];
                hidden[0] = hidInstID;
                hidden[1] = hidUniID;
                hidden[2] = hidCrMoLrnPtrnID;
                hidden[3] = hidCrPrID;
                hidden[4] = hidYear;
                common = new clsCommon();
                common.setHiddenVariables(ref hidden);
                if (common != null) common = null;                
                fillCourse();
                fillCoursePart();
                lblInstName.Text = " for "+Classes.InstituteRepository.InstituteName(hidUniID.Value, hidInstID.Value);
                
            }
            else
            {
                fillCoursePart();
                lblNoRecords.Text = "";
            }
            

            //--------------------------------------------------------
            //University ID Checking
            //--------------------------------------------------------
            if (hidUniID.Value == "")
            {
                hidUniID.Value = UniversityPortal.clsGetSettings.UniversityID.ToString();
            }
         //   btnSave.Attributes.Add("onclick", "return fnConfirm();");
            btnSave.Attributes.Add("onclick", "return fnCheck();");
            btnProcessData.Attributes.Add("onClick", "return fnValidate();");
            btnSave.Enabled = false;
        }
        #endregion


        #region Button Process Click
        protected void btnProcessData_Click(object sender, EventArgs e)
        {
            DG_PRN.Visible = false;
            tblLink.Attributes.Add("style","display:inline");
            lblSave.Text = "";
            lblUniCollPrn.Text = "";
            
            //Get Rights Flag
            sRightsFlag = clsEligibilityRights.Elg_Get_Courses_Rights(hidCrMoLrnPtrnID.Value);
            hidRightsFlag.Value = sRightsFlag;

            displayGrids();
        }
        #endregion


        #region Function Display Grid
        private void displayGrids()
        {
            //lblStatistics.Text = "Statistics of Records";
            lblUnselectCheck.Text = "";
            tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:inline");
            if (hidRightsFlag.Value == "1") //College Side Eligibility
            {
                trStatistics.Attributes.Add("style", "display:inline");
                trGrids.Attributes.Add("style", "display:none");
                lblRights.Text = "Eligibility rights for selected course are at college side" + "<br><br>";
                displayCollegeGrid();
            }
            else //University Side Eligibility
            {
                trStatistics.Attributes.Add("style", "display:inline");
                trGrids.Attributes.Add("style", "display:none");
                lblRights.Text = "Eligibility rights for selected course are at university side" + "<br><br>";
                displayUniversityGrid();
            }
        }
        #endregion


        #region Function to display College Grid
        private void displayCollegeGrid()
        {
            lblDisplayNote.Visible = false;
            lblInfoNote.Visible = false;
            

            //Fill DataTable to get statistics of no. records processed at college level and no. of records to be processed and University Level
            //and Details of students that are processed at College level
            DataSet dsStudDet = new DataSet();
            hidCollege_Eligibility_Flag.Value = "1";
            

            //College_Eligibility_Flag="1" when records are made eligibilie at College level
            dsStudDet = clsEligibilityRights.Elg_Get_Eligibility_Statistics(hidCrMoLrnPtrnID.Value, hidCrPrID.Value, hidUniID.Value, hidInstID.Value, hidCollege_Eligibility_Flag.Value);

            if (dsStudDet.Tables.Count > 0)
            {
                //Display Count of Eligibility for College and University
                lblCollCount.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                lblUniCount.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                lblNonPaidCollCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidCollCount"].ToString();
                lblNonPaidUniCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidUniCount"].ToString();
                //Bind College DataGrid if any record Present of College Side Eligibility

                if (dsStudDet.Tables[1].Rows.Count > 0)
                {
                    int iCount = Convert.ToInt32(dsStudDet.Tables[0].Rows[0]["CollCount"]);
                    
                    if (iCount > 50)
                    {
                        lblInfoNote.Visible = true;
                        lblDisplayNote.Visible = true;
                        // lblInfoNote.Text = "Note : Eligibility Bulk Process will be done for '50' students out of '" + dsStudDet.Tables[0].Rows[0]["CollCount"].ToString() + "' students";
                        lblInfoNote.Text = "Click on save button to generate PRN of eligible students whose payment is recieved.<br>At a time only '50' students will be processed";
                        lblDisplayNote.Text = "List displays students whose eligibility is to be processed ['50' out of '" + iCount + "' students]";
                    }
                    else
                    {
                        lblInfoNote.Visible = true;
                        lblDisplayNote.Visible = true;
                        lblDisplayNote.Text = "List displays students whose eligibility is to be processed ['"+iCount+"' out of '" + iCount + "' students]";
                        lblInfoNote.Text = "Click on save button to generate PRN of eligible students whose payment is recieved.";
                    }


                    trGrids.Attributes.Add("style", "display:inline");
                    btnSave.Enabled = true;
                    lblUnselectCheck.Visible = true;
                    lblUnselectCheck.Text = "Note : Following list does not include Students whose Eligibility is to be decided by University. You are required to process such students eligibility individually using Manual Process menu.";
                    
                    DG_College.DataSource = dsStudDet.Tables[1];
                    DG_College.DataBind();
                    DG_College.Visible = true;
                }
                else
                {
                    lblNoRecords.Text = "No Records Found";
                    DG_University.Visible = false;
                    DG_College.Visible = false;
                    DG_PRN.Visible = false;
                }
                
            }

        }
        #endregion


        #region Function to display University Grid
        private void displayUniversityGrid()
        {
            lblDisplayNote.Visible = false;
            lblInfoNote.Visible = false;

            //Fill DataTable to get statistics of no. records processed at college level and no. of records to be processed and University Level
            //and Details of students that are processed at University level

            DataSet dsStudDet = new DataSet();
            hidCollege_Eligibility_Flag.Value = "4";

            //College_Eligibility_Flag="4" when Eligibility is to be processed at University Level
            dsStudDet = clsEligibilityRights.Elg_Get_Eligibility_Statistics(hidCrMoLrnPtrnID.Value, hidCrPrID.Value, hidUniID.Value, hidInstID.Value, hidCollege_Eligibility_Flag.Value);

            if (dsStudDet.Tables.Count > 0)
            {
                //Display Count of Eligibility for College and University
                lblCollCount.Text = dsStudDet.Tables[0].Rows[0]["CollCount"].ToString();
                lblUniCount.Text = dsStudDet.Tables[0].Rows[0]["UniCount"].ToString();
                lblNonPaidCollCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidCollCount"].ToString();
                lblNonPaidUniCount.Text = dsStudDet.Tables[0].Rows[0]["UnPaidUniCount"].ToString();

                if (dsStudDet.Tables[1].Rows.Count > 0)
                {
                    common = new clsCommon();
                    trGrids.Attributes.Add("style", "display:inline");
                    btnSave.Enabled = true;
                    lblUnselectCheck.Text = "Note : Select Records that you want to process.";
                    trGridHeader.Attributes.Add("style", "display:inline");
                    lblUniCollPrn.Text = "To make the following list of students eligible and generate PRN click on save button.";
                    lblUnselectCheck.Visible = true;
                    lblUniCollPrn.Visible = true;
                    DG_University.DataSource = dsStudDet.Tables[1];
                    DG_University.DataBind();
                    DG_University.Visible = true;
                    //common.SelectUnselectCheckBox(Page, DG_University, "chkSelectAll", "chkSelect");
                }
                else
                {
                    lblNoRecords.Text = "No Records Found";
                    DG_University.Visible = false;
                    DG_College.Visible = false;
                    DG_PRN.Visible = false;
                }
            }
        }
        #endregion

        
        #region Button Save Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sReturn = "";
            string studID = "";
            lblUnselectCheck.Text = "";
            int iCount = 0;

            if(hidRightsFlag.Value == "0")
            {
                DataGridItemCollection items = DG_University.Items;
                for (int i = 0; i < items.Count; i++)
                {                   
                    CheckBox cb = (CheckBox)items[i].FindControl("chkSelect");
                    if ((cb != null) && (cb.Checked == true))
                    {
                        studID += DG_University.DataKeys[i].ToString().Trim() + ",";
                        iCount = iCount + 1;
                    }
                }
            }
            else
            {
                if (DG_College.Items.Count>0)
                iCount = DG_College.Items.Count;                     
               
            }

            sReturn = clsEligibilityRights.Bulk_Process_Eligibility_Data(hidUniID.Value, hidYear.Value, hidInstID.Value, hidCrMoLrnPtrnID.Value, hidCrPrID.Value,studID, hidCollege_Eligibility_Flag.Value,"1", "", sUser);
            if (sReturn == "Y")
            {
                string SMSreturn = "";
                string SMSMessage = "";
                clsUser u = (clsUser)Session["User"]; //Added By Saroj on 1st Nov 2007
                try
                {
                    SendSMS objSendSMS = new SendSMS();
                    DataSet ds = clsEligibilityRights.FetchRegisteredStudentDetailsForSMS(hidUniID.Value, hidYear.Value, hidInstID.Value, hidCrMoLrnPtrnID.Value, hidCrPrID.Value, studID);
                    if (ds != null)
                    {
                        //if (ds.Tables.Count > 0)
                        //{
                        //    for (int i = 0; i < ds.Tables.Count; i++)
                        //    {
                        //        SMSMessage = "Congrats " + ds.Tables[i].Rows[0]["FirstName"].ToString() + ",U R elgble for " + ds.Tables[i].Rows[0]["CrAbbr"].ToString() + ",PRN:" + ds.Tables[i].Rows[0]["PRN"].ToString() + ",Collect eSuvidha LoginId,Password from college and visit " + UniversityPortal.clsGetSettings.SitePath.Replace("http://","");
                        //        objSendSMS.epMessage = SMSMessage;
                        //        SMSreturn = objSendSMS.SendPersonalizedSMS(ds.Tables[i].Rows[0]["MobileNumber"].ToString().Trim(), "ELG" + ds.Tables[i].Rows[0]["EligibilityFormNo"].ToString());
                        //    }
                        //}
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                //SMSMessage = "Congrats " + hidSMSFirstName.Value + ",You are eligible for " + hidSMSCrAbbr.Value + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your PRN:" + PRN + ".";
                                SMSMessage = "Congrats " + ds.Tables[0].Rows[i]["FirstName"].ToString() + ",You are eligible for " + ds.Tables[0].Rows[i]["CrAbbr"].ToString() + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your PRN:" + ds.Tables[0].Rows[i]["PRN"].ToString();
                                objSendSMS.epMessage = SMSMessage;
                                objSendSMS.epUser = u.User_ID;  //Added By Saroj on 1st Nov 2007
                                SMSreturn = objSendSMS.SendPersonalizedSMS(ds.Tables[0].Rows[i]["MobileNumber"].ToString().Trim(), "ELG" + ds.Tables[0].Rows[i]["EligibilityFormNo"].ToString());
                            }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    string sMsg = ex.Message;
                    string strScript = "<script language=JavaScript>alert('" + sMsg + "');</Script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "key1", strScript);
                }
                lblSave.Visible = true;
                lblSave.CssClass = "SaveNote";
                lblSave.Text = "Eligibility processed for "+iCount+" students and PRN generated successfully.<br>To view list of eligible students and PRN generated click on \"View Eligible Students With PRN\" link.";
                lblUniCollPrn.Text = "";
                displayGrids();
            }
            else  
            {
                lblSave.CssClass = "ErrorNote";
                lblSave.Text = "System has encountered an error during Process.<br>Please try again later";
            }

        }
        #endregion


        #region Button New Click
        protected void btnNew_Click(object sender, EventArgs e)
        {
            DD_Course.SelectedIndex = -1;
            DD_CoursePart.SelectedIndex = -1;
            lblStatistics.Text = "";
            lblUnselectCheck.Text = "";
            tblStatistics.Attributes.Add("style", "border-collapse:collapse;display:none");
            DG_University.Visible = false;
            DG_College.Visible = false;
            DG_PRN.Visible = false;
            lblSave.Text = "";
            lblUniCollPrn.Text = "";
            lblNoRecords.Text = "";
            btnSave.Enabled = false;
        }
        #endregion


        #region Fill ComboBox(Course and CoursePart)
        public void fillCourse()
        {
            common = new clsCommon();
            DataTable dt = new DataTable();
            dt = Classes.InstituteRepository.Get_AllCourse(hidUniID.Value, hidInstID.Value);
            common.fillDropDown(DD_Course, dt, "", "Text", "Value", "--- Select ---");
            dt.Dispose();
        }

        public void fillCoursePart()
        {
            common = new clsCommon();
            DataTable dt = new DataTable();
            dt = Classes.InstituteRepository.Get_AllCoursePartOnly(hidUniID.Value, hidInstID.Value, hidCrMoLrnPtrnID.Value);
            common.fillDropDown(DD_CoursePart,dt,hidCrPrID.Value,"Text","Value","--- Select ---");
            dt.Dispose();
        }
        #endregion


        #region Datagrid Related Functions
        protected void DG_College_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.DataSetIndex + 1);
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                hidYear.Value = e.Item.Cells[5].Text.Trim();
            }
        }

        protected void DG_University_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.DataSetIndex + 1);
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                hidYear.Value = e.Item.Cells[6].Text.Trim();
                e.Item.Cells[3].Text = "<a href='#' onclick=\"return openNewWindow("+e.Item.Cells[5].Text+","+e.Item.Cells[6].Text+","+e.Item.Cells[7].Text+","+e.Item.Cells[8].Text+");\">" + e.Item.Cells[3].Text + "</a>";
            }
        }

        protected void DG_PRN_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.DataSetIndex + 1);
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void DG_University_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DG_University.CurrentPageIndex = e.NewPageIndex;
            displayUniversityGrid();
        }

        protected void DG_College_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DG_College.CurrentPageIndex = e.NewPageIndex;
            displayCollegeGrid();
        }
       

        protected void DG_University_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {
                hid_Year.Value = e.Item.Cells[6].Text.Trim();
                hidStudentID.Value = e.Item.Cells[8].Text.Trim();
            }
        }
        #endregion


        #region View Generate PRN link Click
        protected void lnkPRN_Click(object sender, EventArgs e)
        {
             //DG_College.DataSource = null;
            //DG_University.DataSource = null;
            lblDisplayNote.Visible = false;
            lblInfoNote.Visible = false;
            lblSave.Visible = false;
            DG_College.Visible = false;
            DG_University.Visible = false;
            trCourse.Attributes.Add("style","display:none");
            trStatistics.Attributes.Add("style", "display:none");
            tblToolBarMain.Attributes.Add("style", "display:none");
            string Academic_Year_ID = Session["AcademicYearID"].ToString();

            DataTable DtPRN = clsEligibilityRights.Elg_Display_PRN(hidCrMoLrnPtrnID.Value, hidCrPrID.Value, hidUniID.Value, hidInstID.Value, Academic_Year_ID);
            if (DtPRN.Rows.Count > 0)
            {
                trGrids.Attributes.Add("style", "display:inline");
                lblUnselectCheck.Visible = false;
                trGridHeader.Attributes.Add("style", "display:inline");
                lblUniCollPrn.Visible = true;
                lblUniCollPrn.Text = "List of eligible students with PRN for : " + DD_Course.SelectedItem.Text + " - " + DD_CoursePart.SelectedItem.Text;
                //lblUnselectCheck.Text = "List of PRN generated students for : " + DD_Course.SelectedItem.Text + " - " + DD_CoursePart.SelectedItem.Text;
                DG_College.Visible = false;
                DG_University.Visible = false;
                DG_PRN.DataSource = DtPRN;
                DG_PRN.DataBind();
                DG_PRN.Visible = true;
            }
            else
            {
                trGrids.Attributes.Add("style","display:inline");
                lblUniCollPrn.Visible = true;
                lblUnselectCheck.Visible = true;
                lblUniCollPrn.Text = "List of eligible students with PRN for :" + DD_Course.SelectedItem.Text + " - " + DD_CoursePart.SelectedItem.Text;
                lblUnselectCheck.Text = "Students are not yet marked as Eligible for selected Course.";

            }

        }
        #endregion


        #region Link Select Course Click
        protected void lnkSelectCr_Click(object sender, EventArgs e)
        {
            trCourse.Attributes.Add("style","display:inline");
            trStatistics.Attributes.Add("style","display:inline");
            tblToolBarMain.Attributes.Add("style", "display:inline");
            trGrids.Attributes.Add("style", "display:none");

            DG_PRN.Visible = false;
            btnSave.Enabled = true;

            if (hidRightsFlag.Value == "0")
            {
                
                DG_University.Visible = true;
                lblUniCollPrn.Visible = false;
                //lblUnselectCheck.Text = "Note : Select Records that you want to process.";
                //lblUniCollPrn.Text = "To make the following list of students eligible and generate PRN click on save button.";
                displayUniversityGrid();
            }
            else
            {
                DG_College.Visible = true;
                lblUniCollPrn.Visible = false;
                // lblUnselectCheck.Text = "Note : Students whose Eligibility is to be decided by University and eligibility payment is received are required to be proceesed individually using Manual Process menu";
                //lblUniCollPrn.Text = "List of eligible students whose payment is recieved.To generate PRN for following list of students click on save button.";
                displayCollegeGrid();
            }
            //displayGrids();
        }
        #endregion


    }
}
