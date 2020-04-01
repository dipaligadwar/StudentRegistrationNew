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
using System.Globalization;
using System.Threading;
using System.Configuration;


namespace StudentRegistration.Eligibility
{
	/// <summary>
	/// Summary description for IA_StudentEligibility.
	/// </summary>
    
	public partial class ELGV2_ManualProcess__1 : System.Web.UI.Page
	{

        Eligibility.WebCtrl.StudentAdvancedSearchforManualProcess StudentAdvancedSearchManProcCtrl;

        protected System.Web.UI.HtmlControls.HtmlInputHidden tehsilName;
        private string Elg_FormNo;
        string QstrNavigate;
        string StrUrl;
        string searchType = "";
        string withORWithoutInv = "";
        Eligibility.WebCtrl.StudentAdvancedSearchforManualProcess StudentAdvancedSearchCtrl;
        clsCommon Common = new clsCommon();
        clsCommon CommonAcYr = new clsCommon();
        clsCache clsCache = new clsCache();
        InstituteRepository InstRep = new InstituteRepository();
        

         #region PageLoad

        protected void Page_Load(object sender, System.EventArgs e)
		{
            clsCache.NoCache();			
			btnSimpleSearch.Attributes.Add("onclick","return ChkValidation();");
           // Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods), this.Page);
            Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent), this.Page);
       //   Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent));
            
            ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            StudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentAdvancedSearchforManualProcess)Cntph.FindControl("StudentAdvancedSearchForManualProcess1");
                        
            //StudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentAdvancedSearchforManualProcess)Page.FindControl("StudentAdvancedSearchForManualProcess1");
            hid_fk_AcademicYr_ID.Value = StudentAdvancedSearchCtrl.ddlAcademicYear.SelectedValue.ToString();
            hidAcademicYrText.Value = StudentAdvancedSearchCtrl.ddlAcademicYear.SelectedItem.ToString();

            if(!IsPostBack)
            {
                ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                //ElgConfirm_Inst_Student_Search ob = (ElgConfirm_Inst_Student_Search)Context.Handler;
                searchInstNew temp = (searchInstNew)Cntph1.FindControl("SchInst1");
                hidInstID.Value = ((HtmlInputHidden)Cntph1.FindControl("hidInstID")).Value;
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();

                HtmlInputHidden[] hid = new HtmlInputHidden[29];
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
                hid[11] = hidElgStatusColl;
                hid[12] = hidCollElgFlag;
                hid[13] = hidCollElgFlagReason;
                hid[14] = hidInv;
                hid[15] = hidIsBlank;
                hid[16] = hidrbFilterYesNo;
                hid[17] = hid_fk_AcademicYr_ID;
                hid[18] = hidAcademicYr;
                hid[19] = hidAcademicYrText;
                hid[20] = hidStateID;
                hid[21] = hidBodyID;
                hid[22] = hidBodySelText;
                hid[23] = hidDOB;
                hid[24] = hidLastName;
                hid[25] = hidFirstName;
                hid[26] = hidGender;
                hid[27] = hidrbWithInv;
                hid[28] = hidrbWithoutInv;
                
                Common.setHiddenVariables(ref hid);
        }
       
            if(hidInstID.Value !="" && hidInstID.Value!=null)
            {

                lblPageHead.Text = "Manual Process Eligibility";
                lblSubHeader.Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);
                           
            }
               
            StudentAdvancedSearchCtrl.QstrNavigate = null;

            StudentAdvancedSearchCtrl.StrUrl = "ELGV2_ManualProcess__2.aspx?Search=" + "Adv" ;
            StudentAdvancedSearchCtrl.GridType = "IA";
            

			if(Request.QueryString["Search"] == "Adv")
			{

				if(Request.QueryString["Navigate"] == "back")
				{
                    StudentAdvancedSearchCtrl.QstrNavigate = "back";
                    //StudentAdvancedSearchCtrl.StrUrl = "ELGV2_ManualProcess__2.aspx?Search=" + "Adv" + "&Inv=" + hidInv.Value.ToString() + "&CollElg=" + hidElgStatusColl.Value.ToString() + "&FilterYesNoExBody=" + hidrbFilterYesNo.Value.ToString() + "&AcYear=" + hid_fk_AcademicYr_ID.Value.ToString() + "&AcYearText=" + hidAcademicYrText.Value.ToString() + "&StateID=" + hidStateID.Value.ToString() + "BodyID=" + hidBodyID.Value.ToString() + "BodyText=" + hidBodySelText.Value.ToString() + "InstituteID=" + hidInstID.Value.ToString() + "Faculty=" + hidpkFacID.Value.ToString() + "Course=" + hidpkCrID.Value.ToString() + "MoLearning=" + hidpkMoLrnID.Value.ToString() + "Pattern=" + hidpkPtrnID.Value.ToString() + "Branch=" + hidpkBrnID.Value.ToString() + "CoursePrtDetails=" + hidpkCrPrDetailsID.Value.ToString() + "ElgFormNo=" + hidElgFormNo.Value.ToString();
                   
                    //StudentAdvancedSearchCtrl.GridType = "IA";
					divAdvSearch.Style.Remove("display");
					divAdvSearch.Style.Add("display","block");
					divSimpleSearch.Style.Remove("display");
					divSimpleSearch.Style.Add("display","none");
                    StudentAdvancedSearchCtrl.Div1.Style.Add("display", "block");

                    if (Request.QueryString["AcYear"] != "0")
                    {
                        lblAcademicYear.Text = " [Academic Year " + Request.QueryString["AcYearText"].ToString() + "]";
                        //lblAcademicYear.Text = " for Academic Year " + hidAcademicYrText.Value;
                        lblAcademicYear.Attributes.Add("style", "display:inline");
                    }
                    else if (Request.QueryString["AcYear"] == "0")
                    {
                    lblAcademicYear.Attributes.Add("style", "display:none");                    
				    }                    

				}
				else
				{
                    StudentAdvancedSearchCtrl.QstrNavigate = null;
                    StudentAdvancedSearchCtrl.StrUrl = "ELGV2_ManualProcess__2.aspx?Search=" + "Adv";
                    
				}
			}
			else if(Request.QueryString["Search"] == "Simple")
			{
				divAdvSearch.Style.Remove("display");
				divSimpleSearch.Style.Remove("display");
				divSimpleSearch.Style.Add("display","block");
				divAdvSearch.Style.Add("display","none");
               
			}
			
			if(hidSearchType.Value == "Simple")
			{
				divAdvSearch.Style.Remove("display");
				divSimpleSearch.Style.Remove("display");
				divSimpleSearch.Style.Add("display","block");
				divAdvSearch.Style.Add("display","none");
                StudentAdvancedSearchCtrl.DivFilterExamBody.Style.Add("display", "none");
                StudentAdvancedSearchCtrl.Div1.Style.Add("display", "none");
               
			}
			else if(hidSearchType.Value == "Adv")
			{
				divAdvSearch.Style.Remove("display");
				divSimpleSearch.Style.Remove("display");
				divAdvSearch.Style.Add("display","block");
				divSimpleSearch.Style.Add("display","none");
                StudentAdvancedSearchCtrl.DivFilterExamBody.Style.Add("display", "none");
                StudentAdvancedSearchCtrl.Div1.Style.Add("display", "none");
                



               //if (hid_fk_AcademicYr_ID.Value.ToString() != "0" || hid_fk_AcademicYr_ID.Value != "" || hid_fk_AcademicYr_ID.Value != null)
                if (hidAcademicYrText.Value != "--- Select ---")
               
                {
                    lblAcademicYear.Text = " [Academic Year " + hidAcademicYrText.Value + "]";
                    lblAcademicYear.Attributes.Add("style", "display:inline");
                }
                else if (hidAcademicYrText.Value == "--- Select ---")
                {
                    lblAcademicYear.Attributes.Add("style", "display:none");
                    StudentAdvancedSearchCtrl.DivFilterExamBody.Style.Add("display", "none");
                    StudentAdvancedSearchCtrl.Div1.Style.Add("display", "none");
                }
                
            }
        }

        #endregion

        protected void lnkSimpleSearch_Click(object sender, EventArgs e)
        {
            divSimpleSearch.Attributes.Add("style", "display:inline");
            divAdvSearch.Attributes.Add("style", "display:none");
            txtElgFormNo.Text="";
            txtApplicationFrmNo.Text = "";
            divErrorMsg.Attributes.Add("style", "display:none");
            StudentAdvancedSearchCtrl.divAcademicYr.Attributes.Add("style", "display:none");
            StudentAdvancedSearchCtrl.tblSelect.Attributes.Add("style", "display:none");
            hidSearchType.Value = "Simple";

            hid_fk_AcademicYr_ID.Value = "0";
            lblAcademicYear.Attributes.Add("style", "display:none");

				
        }

        protected void lnkAdvSearch_Click(object sender, EventArgs e)
        {

            divSimpleSearch.Attributes.Add("style", "display:none");
            divAdvSearch.Attributes.Add("style", "display:block");
            txtElgFormNo.Text="";
            txtApplicationFrmNo.Text = "";
            hidSearchType.Value = "Adv";
            divErrorMsg.Attributes.Add("style", "display:none");
            StudentAdvancedSearchCtrl.divAcademicYr.Attributes.Add("style", "display:block");
            StudentAdvancedSearchCtrl.tblSelect.Attributes.Add("style", "display:none");
            StudentAdvancedSearchCtrl.DivFilterExamBody.Attributes.Add("style", "display:none");
            StudentAdvancedSearchCtrl.divDGNote.Attributes.Add("style", "display:none");
            StudentAdvancedSearchCtrl.lblGridName.Attributes.Add("style", "display:none");
            StudentAdvancedSearchCtrl.trbtnSearch.Attributes.Add("style", "display:none");
            StudentAdvancedSearchCtrl.tblDGRegPendingStudents.Attributes.Add("style", "display:none");
            hid_fk_AcademicYr_ID.Value = "0";
            lblAcademicYear.Attributes.Add("style", "display:none");          

            DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
            CommonAcYr.fillDropDown(StudentAdvancedSearchCtrl.ddlAcademicYear, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");        
            
        }


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

        #region btnSimpleSearch_Click

        protected void btnSimpleSearch_Click(object sender, System.EventArgs e)
		    {
                fnFetchStudent();
            }

        #endregion

        #region Fetch Student Details

            private void fnFetchStudent()
            {
                string ElgFormNo = txtElgFormNo.Text.Trim();
                hidAppFormNo.Value = txtApplicationFrmNo.Text.Trim();
                int cnt = 0;
                string str = ElgFormNo;
                string searchType = "";
                string withORWithoutInv = "";
                int pos = str.IndexOf('-');
                while (pos != -1)
                {
                    str = str.Substring(pos + 1);
                    pos = str.IndexOf('-');
                    cnt++;

                }
                if (cnt == 3 || !string.IsNullOrEmpty(hidAppFormNo.Value.Trim()))
                {
                    string[] arr = new string[4];
                    if (cnt == 3)
                    {
                        
                        arr = ElgFormNo.Split('-');   //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
                        for (int i = 0; i < 4; i++)
                        {
                            if (arr[i] == "")
                                arr[i] = "0";
                        }
                    }
                    DataSet ds = new DataSet();
                    try
                    {

                        //if (rbWithInv.Checked == true)
                        //{
                        //    if (string.IsNullOrEmpty(hidAppFormNo.Value.Trim()))
                        //        ds = clsEligibilityDBAccess.Check_IA_Student_Exists(arr[0], arr[1], arr[2], arr[3],hidInstID.Value,hidAppFormNo.Value);
                        //    else
                        //        ds = clsEligibilityDBAccess.Check_IA_Student_Exists(null, null, null, null, hidInstID.Value, hidAppFormNo.Value);
                        //    hidInv.Value = "1";
                        //    hidrbWithInv.Value = "1";
                        //    hidrbWithoutInv.Value = "0";
                        //}

                        //else if (rbWithoutInv.Checked == true)
                        //{
                            if (string.IsNullOrEmpty(hidAppFormNo.Value.Trim()))
                            ds = clsEligibilityDBAccess.Check_IA_Student_Exists_bypassInv(arr[0], arr[1], arr[2], arr[3], hidInstID.Value, hidAppFormNo.Value);
                            else
                                ds = clsEligibilityDBAccess.Check_IA_Student_Exists_bypassInv(null, null, null, null, hidInstID.Value, hidAppFormNo.Value);
                            hidInv.Value = "0";
                            hidrbWithInv.Value = "0";
                            hidrbWithoutInv.Value = "1";
                      //  }

                        if (ds.Tables == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
                        {
                            divErrorMsg.Style.Add("display", "block");
                            lblErrorMsg.Visible = true;
                            if (!string.IsNullOrEmpty(txtElgFormNo.Text.Trim()))
                            lblErrorMsg.Text = "The Student's data with Eligibility Form Number " + txtElgFormNo.Text.Trim() + "  might have processed or haven't uploaded yet.So please check the status to verify.";
                            else if (!string.IsNullOrEmpty(txtApplicationFrmNo.Text.Trim()))
                                lblErrorMsg.Text = "The Student's data with Application Form Number " + txtApplicationFrmNo.Text.Trim() + "  might have processed or haven't uploaded yet.So please check the status to verify.";
                            lblErrorMsg.Style.Remove("display");
                            lblErrorMsg.Style.Add("display", "inline");

                        }
                        else if (ds.Tables[0].Rows.Count > 0)
                        {
                            hidElgFormNo.Value = txtElgFormNo.Text.Trim();
                            hidpkStudentID.Value = ds.Tables[0].Rows[0]["pk_Student_ID"].ToString();
                            hidpkYear.Value = ds.Tables[0].Rows[0]["pk_Year"].ToString();
                            hidpkFacID.Value = ds.Tables[0].Rows[0]["pk_Fac_ID"].ToString();
                            hidpkCrID.Value = ds.Tables[0].Rows[0]["pk_Cr_ID"].ToString();
                            hidpkMoLrnID.Value = ds.Tables[0].Rows[0]["pk_MoLrn_ID"].ToString();
                            hidpkPtrnID.Value = ds.Tables[0].Rows[0]["pk_Ptrn_ID"].ToString();
                            hidpkBrnID.Value = ds.Tables[0].Rows[0]["pk_Brn_ID"].ToString();
                            hidpkCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pk_CrPr_Details_ID"].ToString();
                            hidCollElgFlag.Value = ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString();
                            hidCollElgFlagReason.Value = ds.Tables[0].Rows[0]["Reason"].ToString();
                            hid_fk_AcademicYr_ID.Value = ds.Tables[0].Rows[0]["fkAcademicYearID"].ToString();
                            hidAppFormNo.Value = ds.Tables[0].Rows[0]["AdmissionFormNo"].ToString();
                            if (!string.IsNullOrEmpty(txtApplicationFrmNo.Text.Trim()))
                            hidElgFormNo.Value = ds.Tables[0].Rows[0]["EligibilityFormNumber"].ToString();

                            if (hidCollElgFlag.Value == "4")
                            {
                                hidElgStatusColl.Value = "1";
                            }

                            else
                            {
                                hidElgStatusColl.Value = "0";
                            }

                            if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "1")
                            {
                                hidCollElgFlag.Value = "1";
                                hidCollElgFlagReason.Value = ds.Tables[0].Rows[0]["Reason"].ToString();

                            }

                            if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "2")
                            {
                                hidCollElgFlag.Value = "2";


                            }
                            if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "3")
                            {
                                hidCollElgFlag.Value = "3";


                            }
                            if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "4")
                            {
                                hidCollElgFlag.Value = "4";


                            }
                            if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "5")
                            {
                                hidCollElgFlag.Value = "5";

                            }

                            hidCollElgFlagReason.Value = ds.Tables[0].Rows[0]["Reason"].ToString();
                            searchType = "Simple";

                            //if (rbWithInv.Checked == true)
                            //    withORWithoutInv = "1";
                            //else if (rbWithoutInv.Checked == true)
                                withORWithoutInv = "0";


                            Server.Transfer("ELGV2_ManualProcess__2.aspx?Search=" + searchType.ToString() + "&withORWithoutInv=" + withORWithoutInv.ToString());


                        }

                        else
                        {
                            lblErrorMsg.Text = "Please Enter the Valid Eligibility Form Number.";
                            lblErrorMsg.Style.Remove("display");
                            lblErrorMsg.Style.Add("display", "block");
                        }
                    }

                    catch (Exception ex)
                    {
                       // throw new Exception(ex.Message);
                        throw (ex);
                    }
                    finally
                    {
                        ds.Dispose();
                    }
                }
                else if (!string.IsNullOrEmpty(txtApplicationFrmNo.Text.Trim()))
                {
 
                }
            }

            #endregion 

        #region Footer1_Load

            protected void Footer1_Load(object sender, EventArgs e)
            {

            }

            #endregion

        #region btnAcYr_Click Commented

          /*  void btnAcYr_Click(object sender, EventArgs e)
            {
                if (hid_fk_AcademicYr_ID.Value != "0" || hid_fk_AcademicYr_ID.Value != "")
                {
                    lblAcademicYear.Text = " for Academic Year " + hidAcademicYr.Value;
                    lblAcademicYear.Attributes.Add("style", "display:inline");
                }
                else
                {
                    lblAcademicYear.Attributes.Add("style", "display:none");
                }
            }*/
            #endregion 

            #region Initialize Culture
            protected override void InitializeCulture()
            {
                System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
            }

            #endregion

    }
}
