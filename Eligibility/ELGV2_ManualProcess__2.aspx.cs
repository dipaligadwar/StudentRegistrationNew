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
using System.Configuration;
using Classes;
using Ajax;
using System.Text.RegularExpressions;
using Sancharak;
using System.Threading;
using System.Resources;
using System.Globalization;
using StudentRegistration.Eligibility.ElgClasses;
using System.Net;
using DUConfigurations;

namespace StudentRegistration.Eligibility
{
    /// <summary>
    /// Summary description for reg_StudentEligibility.
    /// </summary>

    public partial class ELGV2_ManualProcess__2 : System.Web.UI.Page
    {

        #region Web Form Generated Variables

        protected System.Web.UI.HtmlControls.HtmlGenericControl divDuplicateProfile;
        protected System.Web.UI.WebControls.Label lblElgDecision;
        protected System.Web.UI.WebControls.DataGrid DGMCourseDetails;
        protected System.Web.UI.WebControls.Image ImageM1;
        protected System.Web.UI.WebControls.Image ImageM2;
        protected System.Web.UI.WebControls.DataGrid DGMQualification;
        protected System.Web.UI.WebControls.DataGrid DGMSubmittedDocs;

        #endregion

        #region User Defined Variables

        DataSet matchingrecords = new DataSet();
        DataSet submitteddocs = new DataSet();
        DataSet dsQualn = new DataSet();
        clsUser userob = new clsUser();
        string userid = "";
        DataSet ds;//fetch matching records
        int GoToDataBase;
        clsCommon Common = new clsCommon();
        clsCache clsCache = new clsCache();
        CDN oCDNKeys = clsDUConfigurations.Instance.CDNKeys;
        clsCDN objCDN = null;
        string sPathExists = string.Empty;

        Eligibility.ELGV2_ManualProcess__1 IA_StudentEligibility1;
        InstituteRepository InstRep = new InstituteRepository();
        string Admission_Form_No = string.Empty;
        #endregion

        #region Page Load

        protected void Page_Load(object sender, System.EventArgs e)
        {
            clsCache.NoCache();
            //Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.IA_StudentEligibility__1));
            Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods), this.Page);

            if (!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[32];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidElgFormNo;
                hid[3] = hidFacID;
                hid[4] = hidCrID;
                hid[5] = hidMoLrnID;
                hid[6] = hidPtrnID;
                hid[7] = hidBrnID;
                hid[8] = hidCrPrDetailsID;
                hid[9] = hidpkYear;
                hid[10] = hidpkStudentID;
                hid[11] = hidElgStatusColl;
                hid[12] = hidCollElgFlag;
                hid[13] = hidCollElgFlagReason;
                hid[14] = hidInv;
                hid[15] = hidIsBlank;
                hid[16] = hidAcademicYr;
                hid[17] = hidCountryIDForeign;
                hid[18] = hidBodyID;
                hid[19] = hid_fk_AcademicYr_ID;
                hid[20] = hidBodyState;
                hid[21] = hidrbFilterYesNo;
                hid[22] = hidAcademicYrText;
                hid[23] = hidBodySelText;
                hid[24] = hidBodyTypeFlag;
                hid[25] = hidDOB;
                hid[26] = hidLastName;
                hid[27] = hidFirstName;
                hid[28] = hidGender;
                hid[29] = hidrbWithInv;
                hid[30] = hidrbWithoutInv;
                hid[31] = hidAppFormNo;



                Common.setHiddenVariables(ref hid);
            }

            if (hidInstID.Value != "" && hidInstID.Value != null)
            {
                // hidInstID.Value = Request.QueryString["InstituteID"].ToString().Trim();
                lblPageHead.Text = "Manual Process Eligibility";
                lblSubHeader.Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);

            }

            if (Request.QueryString["Search"] == "Simple")
                btnGoTo.Text = "Go To Search";
            else  // Search == "Adv"
                btnGoTo.Text = "Go To Student List";

            rbEligible.Attributes.Add("onclick", "fnDisplayDiv();");
            rbDefaulter.Attributes.Add("onclick", "fnDisplayDiv();");
            rbPending.Attributes.Add("onclick", "fnDisplayDiv();");
            rbProvisional.Attributes.Add("onclick", "fnDisplayDiv();");
            btnSubmit.Attributes.Add("onclick", "return fnConfirm();");
            //Getting UserID
            userob = (clsUser)Session["User"];
            userid = userob.User_ID.ToString();
            if (!IsPostBack)
            {
                Eligibility.ELGV2_ManualProcess__1 ob = (ELGV2_ManualProcess__1)System.Web.HttpContext.Current.Handler;
                //WebCtrl.StudentAdvancedSearchforManualProcess tempHidden = (WebCtrl.StudentAdvancedSearchforManualProcess)ob.FindControl("StudentAdvancedSearchforManualProcess1");
                //hidCollElgFlag.Value = ((HtmlInputHidden)ob.FindControl("hidCollElgFlag")).Value;



                ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                // IA_StudentEligibility ob = (IA_StudentEligibility)Context.Handler;  
                WebCtrl.StudentAdvancedSearchforManualProcess tempHidden = (WebCtrl.StudentAdvancedSearchforManualProcess)Cntph.FindControl("StudentAdvancedSearchforManualProcess1");
                hidCollElgFlag.Value = ((HtmlInputHidden)Cntph.FindControl("hidCollElgFlag")).Value;

                //ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                //IA_StudentEligibility1 = (IA_StudentEligibility)Cntph1.FindControl("IA_StudentEligibility1");
                //hidCollElgFlag.Value = ((HtmlInputHidden)IA_StudentEligibility1.FindControl("hidCollElgFlag")).Value;


                if (Request.QueryString["Search"] == "Adv")
                {
                    hidElgFormNo.Value = ((HtmlInputHidden)tempHidden.FindControl("hidElgFormNo")).Value;
                    hidFacID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidFacID")).Value;
                    hidCrID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidCrID")).Value;
                    hidMoLrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidMoLrnID")).Value;
                    hidPtrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidPtrnID")).Value;
                    hidBrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidBrnID")).Value;
                    hidCrPrDetailsID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidCrPrDetailsID")).Value;
                    //hidCollElgFlag.Value = ((HtmlInputHidden)ob.FindControl("hidCollElgFlag")).Value;
                    hidElgStatusColl.Value = ((HtmlInputHidden)tempHidden.FindControl("hidElgStatusColl")).Value;
                    hidpkStudentID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkStudentID")).Value;
                    hidpkYear.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkYear")).Value;
                    lblElgStatusUniversity.Text = "";
                    hidInv.Value = ((HtmlInputHidden)tempHidden.FindControl("hidInv")).Value;
                    hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)tempHidden.FindControl("hid_fk_AcademicYr_ID")).Value;
                    hidAcademicYrText.Value = ((HtmlInputHidden)tempHidden.FindControl("hidAcademicYrText")).Value;
                    hidBodyID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidBodyID")).Value;
                    hidStateID.Value = ((HtmlInputHidden)tempHidden.FindControl("hid_StateID")).Value;
                    hidBodyState.Value = ((HtmlInputHidden)tempHidden.FindControl("hidBodyState")).Value;
                    hidCountryIDForeign.Value = ((HtmlInputHidden)tempHidden.FindControl("hidCountryIDForeign")).Value;
                    hidrbFilterYesNo.Value = ((HtmlInputHidden)tempHidden.FindControl("hidrbFilterYesNo")).Value;
                    hidBodySelText.Value = ((HtmlInputHidden)tempHidden.FindControl("hidBodySelText")).Value;
                    hidInstID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidInstID")).Value;
                    hidBodyTypeFlag.Value = ((HtmlInputHidden)tempHidden.FindControl("hidBodyTypeFlag")).Value;
                    hidrbWithInv.Value = ((HtmlInputHidden)tempHidden.FindControl("hidrbWithInv")).Value;
                    hidrbWithoutInv.Value = ((HtmlInputHidden)tempHidden.FindControl("hidrbWithoutInv")).Value;
                    hidBranchName.Value = ((HtmlInputHidden)tempHidden.FindControl("hidBranchName")).Value;

                }
                if (Request.QueryString["Search"] == "Simple")
                {
                    hidElgFormNo.Value = ((HtmlInputHidden)Cntph.FindControl("hidElgFormNo")).Value;
                    hidpkStudentID.Value = ((HtmlInputHidden)Cntph.FindControl("hidpkStudentID")).Value;
                    hidpkYear.Value = ((HtmlInputHidden)Cntph.FindControl("hidpkYear")).Value;
                    hidFacID.Value = ((HtmlInputHidden)Cntph.FindControl("hidpkFacID")).Value;
                    hidCrID.Value = ((HtmlInputHidden)Cntph.FindControl("hidpkCrID")).Value;
                    hidMoLrnID.Value = ((HtmlInputHidden)Cntph.FindControl("hidpkMoLrnID")).Value;
                    hidPtrnID.Value = ((HtmlInputHidden)Cntph.FindControl("hidpkPtrnID")).Value;
                    hidBrnID.Value = ((HtmlInputHidden)Cntph.FindControl("hidpkBrnID")).Value;
                    hidCrPrDetailsID.Value = ((HtmlInputHidden)Cntph.FindControl("hidpkCrPrDetailsID")).Value;
                    hidElgStatusColl.Value = ((HtmlInputHidden)Cntph.FindControl("hidElgStatusColl")).Value;
                    //hidCollElgFlag.Value = ((HtmlInputHidden)Cntph.FindControl("hidCollElgFlag")).Value;
                    hidCollElgFlagReason.Value = ((HtmlInputHidden)Cntph.FindControl("hidCollElgFlagReason")).Value;
                    hidInv.Value = ((HtmlInputHidden)Cntph.FindControl("hidInv")).Value;
                    hidIsBlank.Value = ((HtmlInputHidden)Cntph.FindControl("hidIsBlank")).Value;
                    hidInstID.Value = ((HtmlInputHidden)Cntph.FindControl("hidInstID")).Value;
                    hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)Cntph.FindControl("hid_fk_AcademicYr_ID")).Value;


                }
                FetchStudentDetails();
                GoToDataBase = 1;
                Session["GoToDataBase"] = GoToDataBase;
            }
            else if (IsPostBack)
            {
                GoToDataBase = Convert.ToInt32(Session["GoToDataBase"].ToString());
                //Image1.ImageUrl = "ELGV2_ManualProcess__3.aspx?img=PSession&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
                //Image2.ImageUrl = "ELGV2_ManualProcess__3.aspx?img=SSession&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
                //Image1.ImageUrl = "ELGV2_ManualProcess__3.aspx?img=PSession&sElgFormNo=" + hidElgFormNo.Value;
                //Image2.ImageUrl = "ELGV2_ManualProcess__3.aspx?img=SSession&sElgFormNo=" + hidElgFormNo.Value; ;         
            }
            if (clsGetSettings.UniversityID.Equals("169"))//MUHS 
                rbProvisional.Text = "By Court Order";

        }

        #endregion

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);

        }
        #endregion

        #region DGSubmittedDocs1_RowDataBound
        /* Commented by Shivani
        protected void DGSubmittedDocs1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Style.Add("display", "none");
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[5].Style.Add("display", "none");
            }
            if ((e.Row.RowType != DataControlRowType.Header) && (e.Row.RowType != DataControlRowType.Footer) && (e.Row.RowType != DataControlRowType.Pager))
            {
                e.Row.Cells[2].Text = "Recvd (Valid)";
            }
        }*/
        #endregion

        #region btnGoTo_Click

        protected void btnGoTo_Click(object sender, System.EventArgs e)
        {
            if (Request.QueryString["Search"] == "Simple")
                Server.Transfer("ELGV2_ManualProcess__1.aspx?Navigate=back&Search=Simple");
            if (Request.QueryString["Search"] == "Adv")
                Server.Transfer("ELGV2_ManualProcess__1.aspx?Navigate=back&Search=Adv" + "&Inv=" + hidInv.Value + "&rbWithInv=" + hidrbWithInv.Value + "&rbWithoutInv=" + hidrbWithoutInv.Value + "&CollElg=" + hidElgStatusColl.Value + "&FilterYesNoExBody=" + hidrbFilterYesNo.Value + "&AcYear=" + hid_fk_AcademicYr_ID.Value + "&AcYearText=" + hidAcademicYrText.Value + "&StateID=" + hidStateID.Value + "&BodyID=" + hidBodyID.Value + "&BodyText=" + hidBodySelText.Value + "&InstituteID=" + hidInstID.Value + "&Faculty=" + hidFacID.Value + "&Course=" + hidCrID.Value + "&MoLearning=" + hidMoLrnID.Value + "&Pattern=" + hidPtrnID.Value + "&Branch=" + hidBrnID.Value + "&CoursePrtDetails=" + hidCrPrDetailsID.Value + "&ElgFormNo=" + hidElgFormNo.Value + "&BodyState=" + hidBodyState.Value + "&CountryIDForeign=" + hidCountryIDForeign.Value + "&BodyTypeFlag=" + hidBodyTypeFlag.Value);


        }

        #endregion

        #region btnSubmit_Click

        protected void btnSubmit_Click(object sender, System.EventArgs e)
        {
            if (GoToDataBase == 1)
            {
                DataSet dsDocs = new DataSet();
                DataRow dr;
                string sReason = "";
                dsDocs.Tables.Add("StudentDocs");
                dsDocs.Tables["StudentDocs"].Columns.Add("fk_Doc_ID");
                dsDocs.Tables["StudentDocs"].Columns.Add("RecvdBy_Uni");
                dsDocs.Tables["StudentDocs"].Columns.Add("ValidityBy_Uni");
                int j = 0;
                for (int i = 0; i < hidDocXML.Value.Length; i += 2)
                {
                    if (hidDocXML.Value[i] == '1')     //if checkbox checked =  true
                    {
                        dr = dsDocs.Tables["StudentDocs"].NewRow();
                        // dr["fk_Doc_ID"] = DGSubmittedDocs.Rows[j].Cells[5].Text.Trim();
                        dr["fk_Doc_ID"] = DGSubmittedDocs1.Rows[j].Cells[5].Text.Trim();
                        dr["RecvdBy_Uni"] = '1';
                        dr["ValidityBy_Uni"] = hidDocXML.Value[i + 1];
                        dsDocs.Tables["StudentDocs"].Rows.Add(dr);
                    }
                    j++;
                }

                System.Text.StringBuilder sb = new System.Text.StringBuilder(1000);    //contains XML fmt of Docs
                System.IO.StringWriter sw = new System.IO.StringWriter(sb);
                dsDocs.WriteXml(sw, XmlWriteMode.IgnoreSchema);
                //			if(sb.Length==14)     //if empty contains "</newdataset>"
                //				sb = null;         

                //int flag;
                //	flag = SubmitTypeCheck();
                string PRN;
                //string ElgFormNo = Session["ElgFormNo"].ToString();
                string ElgFormNo = hidElgFormNo.Value;
                string[] arr = new string[4];
                arr = ElgFormNo.Split('-');   //Ref_Year = arr[0], Ref_UniID = arr[1], ref_InstID = arr[2], Ref_StudID = arr[3]

                string ElgDecision = "-1";
                string ElgDescription = "";
                if (rbEligible.Checked == true)
                {
                    ElgDecision = "1";
                    ElgDescription = "Eligible";
                    if (tbReason.Text.Trim() != "")
                    {
                        sReason = tbReason.Text.Trim() + "[Resolved]";
                    }
                    else
                    {
                        sReason = tbReason.Text.Trim() + " - ";
                    }

                }
                else if (rbDefaulter.Checked == true)
                {
                    ElgDecision = "2";
                    ElgDescription = "Not Eligible";
                    sReason = tbReason.Text.Trim();
                }
                else if (rbPending.Checked == true)
                {
                    ElgDecision = "3";
                    ElgDescription = "Pending Eligible";
                    sReason = tbReason.Text.Trim();
                }
                else if (rbProvisional.Checked == true) //Uncommented by Madhu & Shivani on 17/01/2008 as per Sachin Sir's Requirement
                {
                    ElgDecision = "5";
                    ElgDescription = "Provisionally Eligible";
                    sReason = tbReason.Text.Trim();
                }

                //if(flag == -1)      // fresh record submit
                //{
                string[] strArr = new string[2];
                int Error;

                //string DCServer = clsGetSettings.DCServer; //--TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["DCServer"].ToString();
                //string DCDataBase = clsGetSettings.DCDatabase //--TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["DCDataBase"].ToString();


                string DCServer = clsGetSettings.DCServer;
                string DCDataBase = clsGetSettings.DCDatabase;
                
                strArr = clsEligibilityDBAccess.Register_Fresh_Student(arr[0], arr[1], arr[2], arr[3], ElgDecision, sReason, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hid_fk_AcademicYr_ID.Value, userid, sb, DCServer, DCDataBase);
                PRN = strArr[0];
                Error = Convert.ToInt32(strArr[1]);
                if (Error == 0)             // Modified by Madhu Poclassery on 06th Oct 2007 for SMS Integration
                {
                    string SMSreturn = "";
                    string SMSMessage = "";
                    clsUser u = (clsUser)Session["User"];
                    try
                    {
                        SendSMS objSendSMS = new SendSMS();
                        if (ElgDecision == "1")   // Eligible
                        {
                            if (PRN != null && PRN != "")
                            {
                                lblPRN.Text = "The Student is Marked as <Font color='red' size='2'><b>" + ElgDescription + "</b></font><br>";
                                lblPRN.Text += "The " + lblPermanentRegistrationNumber.Text + " for the Student ";
                                lblPRN.Text += "<b><i>" + lblNameOfStudent.Text + "</i></b> is <br><Font color='#c00000' size='3'>" + PRN + "</Font><br><Font size=2>Please write " + lblPRNNomenclature.Text + " on the Admission/Eligibility form.</Font>";
                                Cache["PRN"] = lblPRN.Text;

                                //==========================================================================================
                                // To fetch Student login credentials for displaying in SMS
                                string userName = string.Empty, password = string.Empty;
                                DataSet Ds = clsEligibilityRights.GetStudentCredentialsForSMS(hidUniID.Value, hidpkYear.Value, hidpkStudentID.Value);
                                if (Ds != null && Ds.Tables[0] != null && Ds.Tables[0].Rows.Count > 0)
                                {
                                    userName = Ds.Tables[0].Rows[0]["UserName"].ToString();
                                    password = Ds.Tables[0].Rows[0]["Password"].ToString();
                                }
                                //==========================================================================================

                                //SMSMessage = "Congrats " + hidSMSFirstName.Value + ",You are eligible for " + hidSMSCrAbbr.Value + " for Academic Year " + hidAcademicYr.Value + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your " + lblPRNNomenclature.Text + ":" + PRN + ".";
                                SMSMessage = clsEligibilityRights.GetSMSBody("24", hidSMSFirstName.Value, hidSMSCrAbbr.Value, hidAcademicYr.Value, hidUniAbbrv.Value, PRN, clsGetSettings.SitePath,  userName, password,sReason);
                                objSendSMS.epMessage = SMSMessage;
                                objSendSMS.epUser = u.User_ID;
                            }
                            else
                            {
                                lblPRN.Text = "System has encountered an error in the registration process. Hence, Registration failed !!!<br>Please try again later.";

                            }
                        }
                        else if (ElgDecision == "2")   //Not Eligible      
                        {
                            lblPRN.Text = "The Student <b><i>" + lblNameOfStudent.Text + "</i></b> is marked as <Font color='#c00000' size='2'>" + ElgDescription + "</Font><br>for the " + lblCr.Text + " " + lblCourse.Text;
                            Cache["PRN"] = lblPRN.Text;
                            //SMSMessage = "Dear " + hidSMSFirstName.Value + ", You are found ineligible for " + hidSMSCrAbbr.Value + " for Academic Year " + hidAcademicYr.Value + ". For more details contact your " + lblCollege.Text.ToLower() + ".";
                            SMSMessage = clsEligibilityRights.GetSMSBody("5", hidSMSFirstName.Value, hidSMSCrAbbr.Value, hidAcademicYr.Value, hidUniAbbrv.Value, PRN, clsGetSettings.SitePath, "", "", sReason);
                            objSendSMS.epMessage = SMSMessage;
                            objSendSMS.epUser = u.User_ID;
                        }
                        else if (ElgDecision == "3")    //Eligibility Pending
                        {
                            lblPRN.Text = "The Student <b><i>" + lblNameOfStudent.Text + "</i></b> is marked <br><Font color='#c00000' size='2'>" + ElgDescription + "</Font><br> for the " + lblCr.Text + " " + lblCourse.Text;
                            Cache["PRN"] = lblPRN.Text;
                            //SMSMessage = "Dear " + hidSMSFirstName.Value + ", your eligibility for " + hidSMSCrAbbr.Value + " for Academic Year " + hidAcademicYr.Value + " is pending. Discrepancy is available in " + lblCollege.Text.ToLower() + "'s login on Digital " + lblUniversity.Text + " Portal of eSuvidha.";
                            SMSMessage = clsEligibilityRights.GetSMSBody("4", hidSMSFirstName.Value, hidSMSCrAbbr.Value, hidAcademicYr.Value, hidUniAbbrv.Value, PRN, clsGetSettings.SitePath, "", "", sReason);
                            objSendSMS.epMessage = SMSMessage;
                            objSendSMS.epUser = u.User_ID;
                        }
                        else if (ElgDecision == "5")    // Provisional PRN --UnCommented by Madhu & Shivani on 17th Jan 2008 as per Sachin Sir's requirement
                        {
                            if (PRN != null && PRN != "")
                            {
                                lblPRN.Text = "The Student is Marked as <Font color='red' size='2'><b>" + ElgDescription + "</b></font><br>";
                                lblPRN.Text += "The " + lblPermanentRegistrationNumber.Text + " for the Student ";
                                lblPRN.Text += "<b><i>" + lblNameOfStudent.Text + "</i></b> is <br><Font color='#c00000' size='3'>" + PRN + "</Font><br><Font size=2>Please write " + lblPRNNomenclature.Text + " on the Admission/Eligibility form.</Font>";
                                Cache["PRN"] = lblPRN.Text;

                                //==========================================================================================
                                // To fetch Student login credentials for displaying in SMS
                                string userName = string.Empty, password = string.Empty;
                                DataSet Ds = clsEligibilityRights.GetStudentCredentialsForSMS(hidUniID.Value, hidpkYear.Value, hidpkStudentID.Value);
                                if (Ds != null && Ds.Tables[0] != null && Ds.Tables[0].Rows.Count > 0)
                                {
                                    userName = Ds.Tables[0].Rows[0]["UserName"].ToString();
                                    password = Ds.Tables[0].Rows[0]["Password"].ToString();
                                }
                                //==========================================================================================
                                //SMSMessage = "Dear " + hidSMSFirstName.Value + ",You are provisionally eligible for " + hidSMSCrAbbr.Value + " for Academic Year " + hidAcademicYr.Value + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your " + lblPRNNomenclature.Text + ":" + PRN + ". Discrepancy is available in " + lblCollege.Text.ToLower() + "'s login on Digital " + lblUniversity.Text + " Portal of eSuvidha.";
                                SMSMessage = clsEligibilityRights.GetSMSBody("3", hidSMSFirstName.Value, hidSMSCrAbbr.Value, hidAcademicYr.Value, hidUniAbbrv.Value, PRN, clsGetSettings.SitePath, userName, password, sReason);
                                objSendSMS.epMessage = SMSMessage;
                                objSendSMS.epUser = u.User_ID;
                                //objSendSMS.epSender= ;

                            }
                            else
                            {
                                lblPRN.Text = "System has encountered an error in the registration process. Hence, Registration failed !!!<br>Please try again later.";

                            }
                        }
                        SMSreturn = objSendSMS.SendPersonalizedSMS(hidSMSMobileNumber.Value.Trim(), "ELG" + hidElgFormNo.Value);
                        if (SMSreturn.Substring(0, 7) == "Invalid")
                        {
                            lblSMSError.Text = "SMS could not be sent because of following reason:<br><font size=2>" + SMSreturn + "</font>";
                        }
                        else
                        {
                            lblSMSError.Text = "<font size=2>Following SMS has been sent to Student on:" + hidSMSMobileNumber.Value.Trim() + "<br><font size=2> (" + SMSMessage + ")</font>";
                        }

                    }
                    catch (Exception ex)
                    {
                        lblSMSError.Text = ex.Message;
                    }
                }
                else if (Error != 0)
                {
                    lblPRN.Text = "System has encountered an error in the registration process. Hence, Registration failed !!!<br>Please try again later.";
                }
                //}
                /*	else				// association with the matching record        // Supressed this functionality to avoid duplicate record 
                    {
                        string ExistingPRN=DGMatchingRecords.Items[flag].Cells[2].Text.ToString().Trim();
                        //if(ExistingPRN == "&nbsp;")
                        //Regular Expression validation 
                        Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");
                        if(!objNotNaturalPattern.IsMatch(ExistingPRN))
                            ExistingPRN="";
                        string[] strArr = new string[3];
                        int crAssoFlag;
                        int Error;
                        //strArr = clsEligibilityDBAccess.Associate_Student_With_Course(ConfigurationSettings.AppSettings["UniversityID"].ToString(),DGMatchingRecords.Items[flag].Cells[8].Text.ToString().Trim(),DGMatchingRecords.Items[flag].Cells[9].Text.ToString().Trim(),arr[1],arr[0],arr[2],arr[3],ElgDecision,tbReason.Text.ToString(),Session["pk_CrMoLrnPtrn_ID"].ToString(),userid,sb,ExistingPRN);
                        strArr = clsEligibilityDBAccess.Associate_Student_With_Course(Classes.clsGetSettings.UniversityID.ToString(),DGMatchingRecords.Items[flag].Cells[8].Text.ToString().Trim(),DGMatchingRecords.Items[flag].Cells[9].Text.ToString().Trim(),arr[0],arr[2],arr[1],arr[3],ElgDecision,tbReason.Text.ToString(),hidCrMoLrnPtrnID.Value,userid,sb,ExistingPRN);
                        PRN = strArr[0];
                        crAssoFlag = Convert.ToInt32(strArr[1]);
                        Error = Convert.ToInt32(strArr[2]);
                        if(Error == 0)
                        {
                            if(crAssoFlag == 1)
                            {
                                lblPRN.Text = "The Student cannot be marked "+ElgDescription+" for the same course, "+lblCourse.Text.ToString().Trim()+" again. Hence, he is marked as <br><Font color='#c00000' size='2'>Not Eligible</font><br> for the same course for the second time by the System";    //not final, fetch the details in the ds and display the same in the msg.
                            }
                            else
                            {
                                if(ExistingPRN != null && ExistingPRN != "")
                                {
                                    lblPRN.Text="The Student with PRN <Font color='#c00000' size='2'>"+ExistingPRN+"</Font> is now associated and marked <br><Font color='#c00000' size='2'>"+ElgDescription+"</font><br> for the Course "+lblCourse.Text;
                                }
                                else					//PRN Exists
                                {
                                    if(ElgDecision=="1")           // Eligible
                                    {
                                        if(PRN != null && PRN != "")
                                            lblPRN.Text="The Student with PRN <Font color='#c00000' size='2'>"+PRN+"</Font> is now associated and marked <br><Font color='#c00000' size='2'>"+ElgDescription+"</font><br> for the Course "+lblCourse.Text;
                                        else
                                            lblPRN.Text = "System has encountered an error in the registration process. Hence, Registration failed !!!<br>Please try again later.";
								   
                                    }
								
                                        // Not Eligible or Pending Eligible
                                        else if(ElgDecision=="2" || ElgDecision=="3")
                                        lblPRN.Text="The Student is now associated and marked <br><Font color='#c00000' size='2'>"+ElgDescription+"</font><br> for the Course "+lblCourse.Text;
                                }
                            }
                        }
                        else if(Error != 0)
                        {
                            lblPRN.Text = "System has encountered an error in the registration process. Hence, Registration is failed !!!<br>Please try again later.";
                        }
                    }
                    */

                divPRN.Style.Add("display", "block");
                divEligibilityDecision.Style.Add("display", "none");
                //for (int i = 0; i < DGSubmittedDocs.Items.Count; i++)
                //{
                //    ((CheckBox)DGSubmittedDocs.Items[i].Cells[3].Controls[1]).Enabled = false;

                //}
                //for (int i = 0; i < DGMatchingRecords.Items.Count; i++)
                //{
                //    ((CheckBox)DGMatchingRecords.Items[i].Cells[7].Controls[1]).Enabled = false;

                //}
                for (int i = 0; i < DGSubmittedDocs1.Rows.Count; i++)
                {
                    ((CheckBox)DGSubmittedDocs1.Rows[i].Cells[3].Controls[1]).Enabled = false;

                }
                int k = 0;
                for (int l = 0; l < hidDocXML.Value.Length; l += 2)
                {
                    if (hidDocXML.Value[l] == '1')     //if checkbox checked =  true
                    {

                        if (hidDocXML.Value[l + 1] == '1')
                            // ((RadioButton)DGSubmittedDocs.Rows[k].Cells[4].Controls[1]).Checked = true;
                            ((RadioButton)DGSubmittedDocs1.Rows[k].Cells[4].Controls[1]).Checked = true;
                        else
                            //  ((RadioButton)DGSubmittedDocs1.Rows[k].Cells[4].Controls[3]).Checked = true;
                            ((RadioButton)DGSubmittedDocs1.Rows[k].Cells[4].Controls[3]).Checked = true;
                    }
                    k++;
                }
                GoToDataBase = 0;
                Session["GoToDataBase"] = GoToDataBase;
            }
            else
            {
                divPRN.Style.Add("display", "block");

                lblRefresh.Text = "<Font color='#c00000' size='3'>Selected Record has Already been Processed</font><br>" + Cache["PRN"].ToString();

            }


        }

        #endregion

        #region Submit Type Check

        //public int SubmitTypeCheck()
        //{
        //    int flag = -1;
        //    if(DGMatchingRecords.Items.Count>0)
        //    {
        //        for(int i=0; i<DGMatchingRecords.Items.Count; i++)
        //        {
        //            if(((CheckBox)DGMatchingRecords.Items[i].Cells[7].Controls[1]).Checked == true)
        //            {
        //                flag = i;
        //            }
        //        }
        //    }
        //    return flag;    //-1 = fresh record submit, i = association with above matching record
        //}

        #endregion

        #region Fetch Student Profile from Reg

        public void FetchStudentDetails()
        {

            trChangedName.Style.Add("display", "none");
            string[] arr = new string[4];
            if (!string.IsNullOrEmpty(hidElgFormNo.Value))
            {
                string ElgFormNo = hidElgFormNo.Value;
                arr = ElgFormNo.Split('-');   //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
            }
            ds = new DataSet();
            try
            {
                if (Request.QueryString["withOrWithOutInv"] == "1" || Request.QueryString["withOrWithOutInv1"] == "1")
                {
                    ds = elgDBAccess.IA_Fetch_Student_Details(Classes.clsGetSettings.UniversityID.ToString(), hidpkStudentID.Value, hidpkYear.Value, arr[0], arr[1], arr[2], arr[3], hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hidAppFormNo.Value.Trim());
                }

                else if (Request.QueryString["withOrWithOutInv"] == "0" || Request.QueryString["withOrWithOutInv1"] == "0")
                {
                    ds = elgDBAccess.IA_Fetch_Student_Details_bypassInv(Classes.clsGetSettings.UniversityID.ToString(), hidpkStudentID.Value, hidpkYear.Value, arr[0], arr[1], arr[2], arr[3], hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hidAppFormNo.Value.Trim());
                }


                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblAdmissionDate.Text = ds.Tables[0].Rows[0]["Admission_Date"].ToString();
                    lblAppFormNo.Text = ds.Tables[0].Rows[0]["Admission_Form_No"].ToString();
                    lblCourse.Text = ds.Tables[0].Rows[0]["Course"].ToString(); //+ "-" + ds.Tables[0].Rows[0]["CrPrAbbr"].ToString(); //+ "(" + ds.Tables[0].Rows[0]["Faculty"].ToString() + ")";

                    lblInstName.Text = ds.Tables[0].Rows[0]["RefInstName"].ToString();

                    hidSMSCrAbbr.Value = ds.Tables[0].Rows[0]["CrAbbr"].ToString(); // Added by Madhu Poclassery on 06th Oct 2007 For SMS Integration
                    hidAcademicYr.Value = ds.Tables[0].Rows[0]["Year"].ToString();

                    if (hidSMSCrAbbr.Value.Length > 9)
                    {
                        hidSMSCrAbbr.Value = hidSMSCrAbbr.Value.Substring(0, 8);
                    }
                    lblEligibilityFormNo.Text = ds.Tables[0].Rows[0]["EligibilityFormNumber"].ToString();
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    lblPapers.Text = "<table cellSpacing='0' cellPadding='3' width='100%' align='center' style='BORDER-TOP: silver 1px solid; BORDER-LEFT: silver 1px solid;'>"; //border='1px'
                    int j = 0;
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        if (j == 0)
                            lblPapers.Text += "<tr>"; //class='rfont'
                        lblPapers.Text += "<td style='BORDER-RIGHT: silver 1px solid; BORDER-BOTTOM: silver 1px solid'>" + ds.Tables[1].Rows[i]["PaperCode"].ToString() + "</td>";
                        lblPapers.Text += "<td style='BORDER-RIGHT: silver 1px solid; BORDER-BOTTOM: silver 1px solid'>" + ds.Tables[1].Rows[i]["PaperName"].ToString() + "</td>";
                        ++j;
                        if (j == 3)
                        {
                            lblPapers.Text += "</tr>";
                            j = 0;
                        }

                    }
                    lblPapers.Text += "</table>";
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    lblNameOfStudent.Text = ds.Tables[2].Rows[0]["Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Middle_Name"].ToString();
                    //Giving Title
                    hidSMSFirstName.Value = ds.Tables[2].Rows[0]["First_Name"].ToString();  // Added by Madhu Poclassery on 06th Oct 2007 For SMS Integration
                    if (hidSMSFirstName.Value.Length > 15)
                    {
                        hidSMSFirstName.Value = hidSMSFirstName.Value.Substring(0, 14);
                    }

                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                    lblPageHead.Text = "Manual Process Eligibility";
                    lblSubHeader.Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);
                    lblNameAsMarksheet.Text = ds.Tables[2].Rows[0]["Name_QualExamMarkSheet"].ToString();
                    lblStudName.Text = "<br><b> for student  " + " <i>" + lblNameOfStudent.Text + "</i>" + " for " + lblCr.Text + " ";

                    if (ds.Tables[0].Rows.Count > 0)
                        lblStudName.Text += ds.Tables[0].Rows[0]["CrPrAbbr"].ToString();
                    lblStudName.Text += "</b>";

                    lblMothersMaidenName.Text = ds.Tables[2].Rows[0]["Mother_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Mother_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Mother_Middle_Name"].ToString();
                    lblFathersName.Text = ds.Tables[2].Rows[0]["Father_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Father_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Father_Middle_Name"].ToString();
                    if (ds.Tables[2].Rows[0]["Changed_Name_Flag"].ToString() == "1")
                    {
                        lblPreviousName.Text = ds.Tables[2].Rows[0]["Prev_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Prev_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Prev_Middle_Name"].ToString();
                        trChangedName.Style.Add("display", "block");
                    }
                    lblGender.Text = ds.Tables[2].Rows[0]["Gender_Desc"].ToString();
                    lblDOB.Text = ds.Tables[2].Rows[0]["DOB"].ToString();                   //Gender,Date_of_Birth,Changed_Name_Reason
                    lblNationality.Text = ds.Tables[2].Rows[0]["Nationality"].ToString();
                    hidSMSMobileNumber.Value = ds.Tables[2].Rows[0]["MobileNumber"].ToString(); // Added by Madhu Poclassery on 06th Oct 2007 For SMS Integration
                    hidUniAbbrv.Value = ds.Tables[2].Rows[0]["UniAbbr"].ToString().ToUpper();
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    lblDomicileState.Text = ds.Tables[3].Rows[0]["Domicile_of_State"].ToString();
                    lblResvCategory.Text = ds.Tables[3].Rows[0]["Category"].ToString();
                    if (ds.Tables[3].Rows[0]["Category_Flag"].ToString() == "1")
                    {
                        if (ds.Tables[3].Rows[0]["ResvCategory"].ToString() != "")
                        {
                            lblResvCategory.Text += " (" + ds.Tables[3].Rows[0]["ResvCategory"].ToString();
                            if (ds.Tables[3].Rows[0]["SubCaste"].ToString() != "")
                                lblResvCategory.Text += " - " + ds.Tables[3].Rows[0]["SubCaste"].ToString();
                            lblResvCategory.Text += ")";
                        }
                    }
                    lblAdmittedCategory.Text = ds.Tables[3].Rows[0]["AdmittedCategory"].ToString();
                    if (ds.Tables[3].Rows[0]["Physically_Challenged_Flag"].ToString() == "1")
                        lblPhyChlngd.Text = ds.Tables[3].Rows[0]["PhysicallyChallenged"].ToString();
                    else
                        lblPhyChlngd.Text = "     -";
                    lblGuardianincome.Text = "Rs. " + ds.Tables[3].Rows[0]["Guardian_Annual_Income"].ToString();
                    lblGuardianOccupation.Text = ds.Tables[3].Rows[0]["GuardOccupation"].ToString();
                }

                if (ds.Tables[4].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                    {
                        lblSocResv.Text += ds.Tables[4].Rows[i]["SocialReservation_Description"].ToString();
                        if (i < (ds.Tables[4].Rows.Count - 1))
                            lblSocResv.Text += ", ";
                    }
                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    DGQualification1.DataSource = ds.Tables[5];
                    DGQualification1.DataBind();
                }
                if (ds.Tables[6].Rows.Count > 0)
                {
                    DGSubmittedDocs1.DataSource = ds.Tables[6];
                    DGSubmittedDocs1.DataBind();
                }
                else
                {
                    lblDoctext.Text = "NO documents submitted.";
                    lblDoctext.Visible = true;
                }
                if (ds.Tables[7].Rows.Count > 0) 
                {
                    hidCollElgFlagReason.Value = ds.Tables[7].Rows[0]["Reason"].ToString();
                    hidCollElgFlag.Value = ds.Tables[7].Rows[0]["College_Eligibility_Flag"].ToString();
                    if (hidElgStatusColl.Value == "1")
                    {
                        divElgStstusCollege.Style.Add("display", "none");
                        lblElgStstusCollege.Text = "";
                    }
                    else
                    {
                        divElgStstusCollege.Style.Add("display", "block");
                        lblElgStstusCollege.Text = "";
                    }

                    if (hidCollElgFlag.Value == "1")
                    {
                        //divElgStstusCollege.Attributes.Add("display", "block");
                        lblElgStstusCollege.Text = "The " + lblCollege.Text + " has Marked the Student as Eligible";
                    }
                    else if (hidCollElgFlag.Value == "2")
                    {
                        //divElgStstusCollege.Attributes.Add("display", "block");
                        lblElgStstusCollege.Text = "The " + lblCollege.Text + " has Marked the Student as Not Eligible <br /><b>Reason:</b>" + hidCollElgFlagReason.Value;
                    }
                    else if (hidCollElgFlag.Value == "3")
                    {
                        //divElgStstusCollege.Attributes.Add("display", "block");
                        lblElgStstusCollege.Text = "The " + lblCollege.Text + " has Marked the Student as Pending Eligible <br /><b>Reason:</b>" + hidCollElgFlagReason.Value;
                    }
                    else if (hidCollElgFlag.Value == "4")
                    {
                        //divElgStstusCollege.Attributes.Add("display", "block");
                        lblElgStatusUniversity.CssClass = "errorNote";
                        lblElgStatusUniversity.Text = "The " + lblCollege.Text + " has kept the Students Eligibility to be Decided by " + lblUniversity.Text + " <br />";

                    }
                    else if (hidCollElgFlag.Value == "5")
                    {
                        //divElgStstusCollege.Attributes.Add("display", "block");
                        lblElgStstusCollege.Text = "The " + lblCollege.Text + " has marked the Students Eligibility as Provisionally Eligible <br /><b>Reason:</b>" + hidCollElgFlagReason.Value;
                    }
                }
              
                hidDocCnt.Value = ds.Tables[6].Rows.Count.ToString();
                //Image1.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[2].Rows[0]["PhotoPath"].ToString();//"ELGV2_ManualProcess__3.aspx?img=PR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
                Image1.Visible = true;
                //Image2.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[2].Rows[0]["SignPath"].ToString();//"ELGV2_ManualProcess__3.aspx?img=SR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
                Image2.Visible = true;
                if (oCDNKeys != null)
                {
                    objCDN = new clsCDN(oCDNKeys.PhotoSignKey);
                    sPathExists = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[2].Rows[0]["PhotoPath"])) ? "Y" : "N";
                    Image1.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(ds.Tables[2].Rows[0]["PhotoPath"]), sPathExists, "P");
                    sPathExists = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[2].Rows[0]["SignPath"])) ? "Y" : "N";
                    Image2.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(ds.Tables[2].Rows[0]["SignPath"]), sPathExists, "S");
                }                     
                divStudentDetails.Style.Add("Display", "block");

                //Display Fee category and fee heads
                if (clsGetSettings.UniversityID.Equals("170"))
                {
                    if (ds.Tables[9] != null && ds.Tables[9].Rows.Count > 0)
                    {
                        lblFeeCategorySelected.Text = ds.Tables[9].Rows[0]["Category_Caption_En"].ToString();
                    }
                    if (ds.Tables[11] != null && ds.Tables[11].Rows.Count > 0)
                    {
                        hid_TotalFeeAmt.Value = ds.Tables[11].Rows[0][0].ToString();
                    }
                    if (ds.Tables[10] != null && ds.Tables[10].Rows.Count > 0)
                    {
                        OGridView.DataSource = ds.Tables[10];
                        OGridView.DataBind();
                        tblFeeDetails.Style.Add("Display", "block");
                        DivFeeCategoryType.Style.Add("Display", "block");
                        divFeeHead.Style.Add("Display", "block");
                    }
                    
                    
                }

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                throw (ex);
            }

            finally
            {
                ds.Dispose();
            }
        }

        #endregion

        #region DGMatchingRecords_ItemDataBound

        //private void DGMatchingRecords_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{

        //    if(e.Item.ItemType!=ListItemType.Header && e.Item.ItemType!=ListItemType.Footer)
        //    {
        //        e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + 1);
        //        string pk_Uni_ID = Classes.clsGetSettings.UniversityID.ToString();
        //        string pk_Year = hidpkYear.Value;   //ds.Tables[0].Rows[e.Item.ItemIndex]["pkYear"].ToString();
        //        string pk_Student_ID = hidpkStudentID.Value;   //ds.Tables[7].Rows[e.Item.ItemIndex]["pkStudentID"].ToString();
        //        ((Label)e.Item.Cells[1].Controls[1]).Attributes.Add("onclick","fnFetchMatchingProfile("+pk_Uni_ID+","+pk_Year+","+pk_Student_ID+");");

        //    }
        //}


        #endregion

        #region DGMatchingRecords_ItemCommand (Commented)

        //		private void DGMatchingRecords_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //		{
        //			if(e.CommandName == "ShowProfile")
        //			{
        //				int pk_Uni_ID = Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"].ToString());
        //				int pk_Year = Convert.ToInt32(e.Item.Cells[8].Text.ToString().Trim());
        //				int pk_Student_ID = Convert.ToInt32(e.Item.Cells[9].Text.ToString().Trim());
        //				FetchMStudentDetails(pk_Uni_ID,pk_Year,pk_Student_ID);
        //				
        //			}
        //		}

        #endregion

        //#region Not In Use
        //public void FetchMStudentDetails(int pk_Uni_ID, int pk_Year, int pk_Student_ID)
        //{

        //    trMChangedName.Style.Add("display", "none");
        //    DataSet ds = new DataSet();
        //    try
        //    {

        //        ds = clsEligibilityDBAccess.Fetch_IAMatchingREG_StudentDetails(pk_Uni_ID, pk_Year, pk_Student_ID);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {

        //            DGMCourseDetails.DataSource = ds.Tables[0];
        //            DGMCourseDetails.DataBind();

        //        }

        //        if (ds.Tables[1].Rows.Count > 0)
        //        {
        //            lblMPRN.Text = ds.Tables[1].Rows[0]["PRN"].ToString();
        //            lblRefresh.Text = lblMPRN.Text;
        //            lblMAlumni.Text = ds.Tables[1].Rows[0]["Alumini_Flag"].ToString();
        //            lblMNameOfStudent.Text = ds.Tables[1].Rows[0]["Last_Name"].ToString() + " " + ds.Tables[1].Rows[0]["First_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Middle_Name"].ToString();
        //            lblMMothersMaidenName.Text = ds.Tables[1].Rows[0]["Mother_Last_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Mother_First_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Mother_Middle_Name"].ToString();
        //            lblMFathersName.Text = ds.Tables[1].Rows[0]["Father_Last_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Father_First_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Father_Middle_Name"].ToString();
        //            if (ds.Tables[1].Rows[0]["Changed_Name_Flag"].ToString() == "1")
        //            {
        //                lblMPreviousName.Text = ds.Tables[1].Rows[0]["Prev_Last_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Prev_First_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Prev_Middle_Name"].ToString();
        //                trMChangedName.Style.Add("display", "block");
        //            }
        //            lblMGender.Text = ds.Tables[1].Rows[0]["Gender_Desc"].ToString();
        //            lblMDOB.Text = ds.Tables[1].Rows[0]["DOB"].ToString();                   //Gender,Date_of_Birth,Changed_Name_Reason
        //            lblMNationality.Text = ds.Tables[1].Rows[0]["Nationality"].ToString();
        //        }

        //        if (ds.Tables[2].Rows.Count > 0)
        //        {
        //            lblMDomicileState.Text = ds.Tables[2].Rows[0]["Domicile_of_State"].ToString();
        //            lblMResvCategory.Text = ds.Tables[2].Rows[0]["Category"].ToString();
        //            if (ds.Tables[2].Rows[0]["Category_Flag"].ToString() == "1")
        //            {
        //                if (ds.Tables[2].Rows[0]["ResvCategory"].ToString() != "")
        //                {
        //                    lblMResvCategory.Text += " (" + ds.Tables[2].Rows[0]["ResvCategory"].ToString();
        //                    if (ds.Tables[2].Rows[0]["SubCaste"].ToString() != "")
        //                        lblMResvCategory.Text += " - " + ds.Tables[2].Rows[0]["SubCaste"].ToString();
        //                    lblMResvCategory.Text += ")";
        //                }
        //            }

        //            lblAdmittedCategory.Text = ds.Tables[2].Rows[0]["AdmittedCategory"].ToString();
        //            if (ds.Tables[2].Rows[0]["Physically_Challenged_Flag"].ToString() == "1")
        //                lblMPhyChlngd.Text = ds.Tables[2].Rows[0]["PhysicallyChallenged"].ToString();
        //            else
        //                lblMPhyChlngd.Text = "     -";
        //            lblMGuardianincome.Text = ds.Tables[2].Rows[0]["Guardian_Annual_Income"].ToString();
        //            lblMGuardianOccupation.Text = ds.Tables[2].Rows[0]["GuardOccupation"].ToString();
        //        }

        //        if (ds.Tables[3].Rows.Count > 0)
        //        {
        //            for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
        //            {
        //                lblMSocResv.Text += ds.Tables[3].Rows[i]["SocialReservation_Description"].ToString();
        //                if (i < (ds.Tables[3].Rows.Count - 1))
        //                    lblMSocResv.Text += ", ";
        //            }
        //        }
        //        if (ds.Tables[4].Rows.Count > 0)
        //        {
        //            DGMQualification.DataSource = ds.Tables[4];
        //            DGMQualification.DataBind();
        //        }
        //        if (ds.Tables[5].Rows.Count > 0)
        //        {
        //            DGMSubmittedDocs.DataSource = ds.Tables[5];
        //            DGMSubmittedDocs.DataBind();
        //        }

        //        ImageM1.ImageUrl = "ELGV2_ManualProcess__3.aspx?img=PR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
        //        ImageM1.Visible = true;
        //        ImageM2.ImageUrl = "ELGV2_ManualProcess__3.aspx?img=SR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
        //        ImageM2.Visible = true;

        //        divMStudentDetails.Style.Add("Display", "block");

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //        throw (ex);
        //    }

        //    ds.Dispose();
        //}
        //#endregion

        #region Ajax Methods

        [Ajax.AjaxMethod()]

        public DataSet FetchMatchingProfile(int pk_Uni_ID, int pk_Year, int pk_Student_ID)
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsEligibilityDBAccess.Fetch_IAMatchingREG_StudentDetails(pk_Uni_ID, pk_Year, pk_Student_ID);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                throw (ex);
            }
            return ds;

        }

        #endregion

        #region DGSubmittedDocs_ItemDataBound
        /* protected void DGSubmittedDocs_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (DGSubmittedDocs.CurrentPageIndex * 10) + 1);

                //e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex+1);
                e.Item.Cells[2].Text = "Recvd (Valid)";
            }

        }*/
        #endregion

        #region GSubmittedDocs1_RowDataBound

        protected void DGSubmittedDocs1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Style.Add("display", "none");
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[5].Style.Add("display", "none");
            }

            if ((e.Row.RowType != DataControlRowType.Header) && (e.Row.RowType != DataControlRowType.Footer) && (e.Row.RowType != DataControlRowType.Pager))
            {
                e.Row.Cells[2].Text = "Recvd (Valid)";
            }

            if (clsGetSettings.UniversityID.Equals("170") || clsGetSettings.UniversityID.Equals("169"))
            {
                DataTable odt1 = (DataTable)DGSubmittedDocs1.DataSource;

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    if (odt1.Rows[0]["AdmissionMode"].ToString().Equals("3") || odt1.Rows[0]["AdmissionMode"].ToString().Equals("6"))
                        ;
                    else
                        e.Row.Cells[6].Style.Add("display", "none");
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DGSubmittedDocs1.DataKeys[e.Row.RowIndex]["AdmissionMode"].ToString().Equals("3") || DGSubmittedDocs1.DataKeys[e.Row.RowIndex]["AdmissionMode"].ToString().Equals("6"))
                    {

                        System.Web.UI.HtmlControls.HtmlAnchor lnkViewDoc = (System.Web.UI.HtmlControls.HtmlAnchor)e.Row.FindControl("lnkViewDoc");
                        if (DGSubmittedDocs1.DataKeys[e.Row.RowIndex]["Is_Uploaded"].ToString().Equals("True"))
                        {
                          //  clsStudent oStu = new clsStudent();

                            string Path = GetCDN_DownloadPath(Convert.ToInt32(DGSubmittedDocs1.DataKeys[e.Row.RowIndex]["Admission_Form_No"]))+ DGSubmittedDocs1.DataKeys[e.Row.RowIndex]["FileName"].ToString();
                            lnkViewDoc.InnerText = "View Document";
                            lnkViewDoc.Attributes.Add("onclick", "window.open('" + Path + "', '_blank', 'location=no,height=635,width=955,status=yes,addressbar=no,toolbar=no,menubar=no,scrollbars=yes,left=250,top=0,screenX=0,screenY=0')");
                            lnkViewDoc.Attributes.Add("style", "color: Blue;cursor:pointer;");
                        }
                        else
                        {
                            lnkViewDoc.InnerText = "Document Not Uploaded";

                        }



                    }
                    else
                    {
                        e.Row.Cells[6].Style.Add("display", "none");
                    }
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.Header||e.Row.RowType == DataControlRowType.DataRow)
                    e.Row.Cells[6].Style.Add("display", "none");
                
            }


        }

        #endregion

        #region GridView Data bound
        protected void OGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.BackColor = Color.LightGray;
                e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Cells[0].Text = "Total Fee Amount";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[1].ColumnSpan = 1;
                e.Row.Cells[1].Text = hid_TotalFeeAmt.Value;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[1].Font.Bold = true;
                e.Row.Cells.RemoveAt(2);

            }
        }
        #endregion

        #region CDN Download Path
        private string GetCDN_DownloadPath(int Application_ID)
        {
            int sCDNID = 0;

            if (Application_ID >= 100000 && Application_ID <= 190000)
                sCDNID = 1;
            else if (Application_ID >= 190001 && Application_ID <= 280000)
                sCDNID = 2;
            else if (Application_ID >= 280001 && Application_ID <= 370000)
                sCDNID = 3;
            else if (Application_ID >= 370001 && Application_ID <= 460000)
                sCDNID = 4;
            else if (Application_ID >= 460001 && Application_ID <= 550000)
                sCDNID = 5;
            else if (Application_ID >= 550001 && Application_ID <= 640000)
                sCDNID = 6;
            else if (Application_ID >= 640001 && Application_ID <= 730000)
                sCDNID = 7;
            else if (Application_ID >= 730001 && Application_ID <= 820000)
                sCDNID = 8;
            else if (Application_ID >= 820001 && Application_ID <= 910000)
                sCDNID = 9;
            else if (Application_ID >= 910001 && Application_ID <= 1000000)
                sCDNID = 10;
            else if (Application_ID >= 1000001 && Application_ID <= 1090000)
                sCDNID = 11;
            else if (Application_ID >= 1090001)
                sCDNID = 12;

          //  clsRegdStudentOaYcmouCollege oStudentDocument = new clsRegdStudentOaYcmouCollege();
            clsStudent oStudent = new clsStudent();
            DataTable oDtCDNPath;
            oDtCDNPath = oStudent.GetCDNPath(sCDNID);

            //  clsCDN oCDN = new clsCDN();
            //  DataTable oDt = oCDN.GetCDNKeys();
            DataView Dv = new DataView(oDtCDNPath);
            Dv.RowFilter = "CDNID =" + sCDNID + " ";

            string sDownloadPath = null;
            sDownloadPath = Dv.ToTable().Rows[0]["Download_Path"].ToString();
            return sDownloadPath;
        }
        #endregion
    }
}
