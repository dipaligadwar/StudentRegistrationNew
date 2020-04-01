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
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.Text;

using System.Resources;
using System.Net;
using DUConfigurations;

namespace StudentRegistration.Eligibility
{
    /// <summary>
    /// Summary description for StudentStatus__1.
    /// </summary>

    public partial class ELGV2_ViewStatus__2 : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Label lblFaculty;
        protected System.Web.UI.WebControls.Label lblPapers;
        DataSet ds = new DataSet();
        DataSet matchingrecords = new DataSet();
        DataSet submitteddocs = new DataSet();
        DataSet dsQualn = new DataSet();
        DataSet AdmissionDetails = new DataSet();
        clsUser userob = new clsUser();
        string userid = "";
        string ElgFormNo;
        clsCommon Common = new clsCommon();
        string[] RefIDarr = new string[4];
        clsCache clsCache = new clsCache();
        InstituteRepository InstRep = new InstituteRepository();
        CDN oCDNKeys = clsDUConfigurations.Instance.CDNKeys;
        clsCDN objCDN = null;
        string sPathExists = string.Empty;

        #region Page_Load

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here

            clsCache.NoCache();

            userob = (clsUser)Session["User"];
            userid = userob.User_ID.ToString();


            if (!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[15];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidElgFormNo;
                hid[3] = hidpkYear;
                hid[4] = hidpkStudentID;
                hid[5] = hidpkFacID;
                hid[6] = hidpkCrID;
                hid[7] = hidpkMoLrnID;
                hid[8] = hidpkPtrnID;
                hid[9] = hidpkBrnID;
                hid[10] = hidpkCrPrDetailsID;
                hid[11] = hidPRN;
                hid[12] = hidIsBlank;
                hid[13] = hidSearchType;
                hid[14] = hidDOB;
                Common.setHiddenVariables(ref hid);


                Eligibility.ELGV2_ViewStatus__1 ob = (Eligibility.ELGV2_ViewStatus__1)System.Web.HttpContext.Current.Handler;
                //WebCtrl.StudentsStatusSearch tempHidden = (WebCtrl.StudentsStatusSearch)ob.FindControl("StudentsStatusSearch1");

                ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                WebCtrl.StudentsStatusSearch tempHidden = (WebCtrl.StudentsStatusSearch)Cntph.FindControl("StudentsStatusSearch1");

                //setting hidden variables
                
                hidElgFormNo.Value = ((HtmlInputHidden)tempHidden.FindControl("hidElgFormNo")).Value;
                hidPRN.Value = ((HtmlInputHidden)tempHidden.FindControl("hidPRN")).Value;
                hidpkStudentID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkStudentID")).Value;
                hidpkYear.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkYear")).Value;
                hidpkFacID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkFacID")).Value;
                hidpkCrID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkCrID")).Value;
                hidpkMoLrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkMoLrnID")).Value;
                hidpkPtrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkPtrnID")).Value;
                hidpkBrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkBrnID")).Value;
                hidpkCrPrDetailsID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkCrPrDetailsID")).Value;
                hidIsBlank.Value = ((HtmlInputHidden)tempHidden.FindControl("hidIsBlank")).Value;
                hidInstID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidInstID")).Value;
                hidSearchType.Value = ((HtmlInputHidden)tempHidden.FindControl("hidSearchType")).Value;
                hidDOB.Value = ((HtmlInputHidden)tempHidden.FindControl("hidDOB")).Value;
                FetchStudentDetails();

                if (hidInstID.Value != "" && hidInstID.Value != null)
                {
                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                    lblPageHead.Text = "View Eligibility Status";
                    lblSubHeader.Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);

                }
                if (IsPostBack)
                {
                    if (Request.QueryString["Search"] == "Simple")
                    {
                        ElgFormNo = hidElgFormNo.Value;
                    }
                }



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

        #region FetchStudentDetails()

        public void FetchStudentDetails()
        {

            string ElgFormNo = hidElgFormNo.Value.ToString();

            //string[] RefIDarr = new string[4];
            RefIDarr = ElgFormNo.Split('-');   //Year = RefIDarr[0], UniID = RefIDarr[1], InstID = RefIDarr[2], StudID = RefIDarr[3]
            try
            {


                //ds=clsEligibilityDBAccess.REG_Get_Eligibilitystatusdetails(Convert.ToInt32(hidUniID.Value),Convert.ToInt32(hidpkYear.Value),Convert.ToInt32(hidpkStudentID.Value),hidPRN.Value);//Convert.ToInt32(RefIDarr[0].ToString()),Convert.ToInt32(RefIDarr[2].ToString()),Convert.ToInt32(RefIDarr[1].ToString()),Convert.ToInt32(RefIDarr[3].ToString()),hidPRN.Value);
                ds = clsEligibilityDBAccess.REG_Get_Eligibilitystatusdetails(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(hidpkYear.Value), Convert.ToInt32(hidpkStudentID.Value), Convert.ToInt32(RefIDarr[0].ToString()), Convert.ToInt32(RefIDarr[1].ToString()), Convert.ToInt32(RefIDarr[2].ToString()), Convert.ToInt32(RefIDarr[3].ToString()), Convert.ToInt32(hidpkFacID.Value), Convert.ToInt32(hidpkCrID.Value), Convert.ToInt32(hidpkMoLrnID.Value), Convert.ToInt32(hidpkPtrnID.Value), Convert.ToInt32(hidpkBrnID.Value), Convert.ToInt32(hidpkCrPrDetailsID.Value));


                /* if (ds.Tables[0].Rows.Count > 0)
                 {
                     lblPapers.Text = "<table id='Tbl2' cellSpacing='0' cellPadding='3' width='100%' border='1px'>";
                     int j = 0;
                     for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                     {
                         if (j == 0)
                             lblPapers.Text += "<tr class='rfont'>";
                         lblPapers.Text += "<td>" + ds.Tables[1].Rows[i]["PaperCode"].ToString() + "</td>";
                         lblPapers.Text += "<td>" + ds.Tables[1].Rows[i]["PaperName"].ToString() + "</td>";
                         ++j;
                         if (j == 3)
                         {
                             lblPapers.Text += "</tr>";
                             j = 0;
                         }

                     }

                     lblPapers.Text += "</table>";
                 }*/

                if (ds.Tables[1].Rows.Count > 0)
                {
                    Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");
                    if (!objNotNaturalPattern.IsMatch(ds.Tables[1].Rows[0]["PRN"].ToString()))
                        lblPermRegNo.Text = "Not Generated";
                    else
                        lblPermRegNo.Text = ds.Tables[1].Rows[0]["PRN"].ToString();
                    //lblPermRegNo.Text=ds.Tables[1].Rows[0]["PRN"].ToString();
                    lblAlumni.Text = ds.Tables[1].Rows[0]["Alumini_Flag"].ToString();
                    lblNameAsMarksheet.Text = ds.Tables[1].Rows[0]["Name_QualExamMarkSheet"].ToString();
                    lblNameOfStudent.Text = ds.Tables[1].Rows[0]["Last_Name"].ToString() + " " + ds.Tables[1].Rows[0]["First_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Middle_Name"].ToString();
                    lblMothersMaidenName.Text = ds.Tables[1].Rows[0]["Mother_Last_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Mother_First_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Mother_Middle_Name"].ToString();
                    lblFathersName.Text = ds.Tables[1].Rows[0]["Father_Last_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Father_First_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Father_Middle_Name"].ToString();
                    if (ds.Tables[1].Rows[0]["Changed_Name_Flag"].ToString() == "1")
                    {
                        lblPreviousName.Text = ds.Tables[1].Rows[0]["Prev_Last_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Prev_First_Name"].ToString() + " " + ds.Tables[1].Rows[0]["Prev_Middle_Name"].ToString();
                    }
                    lblGender.Text = ds.Tables[1].Rows[0]["Gender_Desc"].ToString();
                    lblDOB.Text = ds.Tables[1].Rows[0]["DOB"].ToString();
                    lblNationality.Text = ds.Tables[1].Rows[0]["Nationality"].ToString();
                    lblStudName.Text = "<br><b> for student <i>" + lblNameOfStudent.Text + "</i> for " + lblCr.Text + " " + ds.Tables[0].Rows[0]["Course"].ToString() + "</b>";
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    lblDomicileState.Text = ds.Tables[2].Rows[0]["Domicile_of_State"].ToString();
                    lblResvCategory.Text = ds.Tables[2].Rows[0]["Category"].ToString();
                    if (ds.Tables[2].Rows[0]["Category_Flag"].ToString() == "1")
                    {
                        if (ds.Tables[2].Rows[0]["ResvCategory"].ToString() != "")
                        {
                            lblResvCategory.Text += " (" + ds.Tables[2].Rows[0]["ResvCategory"].ToString();
                            if (ds.Tables[2].Rows[0]["SubCaste"].ToString() != "")
                                lblResvCategory.Text += " - " + ds.Tables[2].Rows[0]["SubCaste"].ToString();
                            lblResvCategory.Text += ")";
                        }
                    }
                    if (ds.Tables[2].Rows[0]["Physically_Challenged_Flag"].ToString() == "1")
                        lblPhyChlngd.Text = ds.Tables[2].Rows[0]["PhysicallyChallenged"].ToString();
                    else
                        lblPhyChlngd.Text = "     -";
                    lblGuardianincome.Text = "Rs. " + ds.Tables[2].Rows[0]["Guardian_Annual_Income"].ToString();
                    lblGuardianOccupation.Text = ds.Tables[2].Rows[0]["GuardOccupation"].ToString();
                }

                if (ds.Tables[5].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
                    {
                        lblSocResv.Text += ds.Tables[5].Rows[i]["SocialReservation_Description"].ToString();
                        if (i < (ds.Tables[5].Rows.Count - 1))
                            lblSocResv.Text += ", ";
                    }
                }
                if (ds.Tables[3].Rows.Count > 0) 
                {
                    DGQualification1.DataSource = ds.Tables[3];
                    DGQualification1.DataBind();
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    DGSubmittedDocs1.DataSource = ds.Tables[4];
                    DGSubmittedDocs1.DataBind();
                }
                /*IF there are any Matching Records    This functionality is commented to supress 
                                                        the logic of duplicate erecord checking
                if(ds.Tables[5].Rows.Count>0)
                {  
					
                    divMatchingRecords.Style.Add("display","block");
                    //lblEligibilityFormNo.Text=ds.Tables[5].Rows[0]["ElgFormNo"].ToString() ;
                    DGMatchgCourseDetails.DataSource=ds.Tables[5];
                    DGMatchgCourseDetails.DataBind();
                }
                else
                {
					
                    divMatchingRecords.Style.Add("display","none");
                }
				
                if((hidPRN.Value==null)||(hidPRN.Value==""))
                {*/

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblInstName.Text = ds.Tables[0].Rows[0]["RefInstName"].ToString();
                    lblElgReason.Text = FormatReason(ds.Tables[0].Rows[0]["Reason"].ToString());
                    lblElgStatus.Text = ds.Tables[0].Rows[0]["EligibilityStatus"].ToString();
                    lblEligibilityFormNo.Text = ds.Tables[0].Rows[0]["ElgFormNo"].ToString();
                    TblAdmission.Style.Remove("display");
                    TblAdmission.Style.Add("display", "block");
                    divTblElgFormdetails.Style.Remove("display");
                    divTblElgFormdetails.Style.Add("display", "block");

                    lblAdmissionDate.Text = ds.Tables[0].Rows[0]["Admission_Date"].ToString();
                    lblAppFormNo.Text = ds.Tables[0].Rows[0]["Admission_Form_No"].ToString();
                    lblCourse.Text = ds.Tables[0].Rows[0]["Course"].ToString();



                }
                /*}
                else
                if((hidPRN.Value!=null) && (hidPRN.Value!=""))
                {
                    TblAdmission.Style.Remove("display");
                    TblAdmission.Style.Add("display","none");
                    divTblElgFormdetails.Style.Remove("display");
                    divTblElgFormdetails.Style.Add("display","none");
                    lblGridName.Text="Course Eligibility Status";
                }*/
                //hidDocCnt.Value = ds.Tables[5].Rows.Count.ToString();
             
                //Image1.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[1].Rows[0]["PhotoPath"].ToString();//"ELGV2_ViewStatus__3.aspx?img=PR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
                Image1.Visible = true;
                //Image2.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[1].Rows[0]["SignPath"].ToString();//"ELGV2_ViewStatus__3.aspx?img=SR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
                Image2.Visible = true;
                if (oCDNKeys != null)
                {
                    objCDN = new clsCDN(oCDNKeys.PhotoSignKey);
                    sPathExists = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[0]["PhotoPath"])) ? "Y" : "N";
                    Image1.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(ds.Tables[1].Rows[0]["PhotoPath"]), sPathExists, "P");
                    sPathExists = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[0]["SignPath"])) ? "Y" : "N";
                    Image2.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(ds.Tables[1].Rows[0]["SignPath"]), sPathExists, "S");
                }  


                /*divStudentDetails.Style.Add("Display","block");
                For Proper Display Message of Eligibility Decision
				
                lblGridName.Text ="Candidate "+ds.Tables[2].Rows[0]["First_Name"].ToString() +"'s Matching Other Course  Details ";
                if(ds.Tables[0].Rows.Count > 0)
                    lblPageHead.Text += "<font color='black'> of <i>"+lblNameOfStudent.Text+"</i> for Course "+ds.Tables[0].Rows[0]["CoursePart"].ToString()+"</font>";*/

            }
            catch (Exception ex)
            {
                //    Response.Write(ex.Message);
                throw ex;
            }

            finally
            {
                ds.Dispose();
            }


        }

        #endregion

        #region FetchStudentDetails1(int pk_Uni_ID, int pk_Year,int pk_Student_ID)

        public void FetchStudentDetails1(int pk_Uni_ID, int pk_Year, int pk_Student_ID)
        {
            try
            {
                ds = clsEligibilityDBAccess.Elg_AdvSearch_StudentEligibilityDetails(pk_Uni_ID, pk_Year, pk_Student_ID, hidRef_InstReg_Uni_ID.Value, hidRef_InstReg_Institute_ID.Value, hidRef_InstReg_Year.Value, hidRef_Student_ID.Value, hidPRN.Value);

                divTblElgFormdetails.Style.Remove("display");
                divTblElgFormdetails.Style.Add("display", "none");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");
                    if (!objNotNaturalPattern.IsMatch(ds.Tables[0].Rows[0]["PRN"].ToString()))
                        lblPermRegNo.Text = "Not Generated";
                    else
                        lblPermRegNo.Text = ds.Tables[0].Rows[0]["PRN"].ToString();

                    lblAlumni.Text = ds.Tables[0].Rows[0]["Alumini_Flag"].ToString();
                    lblNameAsMarksheet.Text = ds.Tables[0].Rows[0]["Name_QualExamMarkSheet"].ToString();
                    lblNameOfStudent.Text = ds.Tables[0].Rows[0]["Last_Name"].ToString() + " " + ds.Tables[0].Rows[0]["First_Name"].ToString() + " " + ds.Tables[0].Rows[0]["Middle_Name"].ToString();
                    lblMothersMaidenName.Text = ds.Tables[0].Rows[0]["Mother_Last_Name"].ToString() + " " + ds.Tables[0].Rows[0]["Mother_First_Name"].ToString() + " " + ds.Tables[0].Rows[0]["Mother_Middle_Name"].ToString();
                    lblFathersName.Text = ds.Tables[0].Rows[0]["Father_Last_Name"].ToString() + " " + ds.Tables[0].Rows[0]["Father_First_Name"].ToString() + " " + ds.Tables[0].Rows[0]["Father_Middle_Name"].ToString();
                    if (ds.Tables[0].Rows[0]["Changed_Name_Flag"].ToString() == "1")
                    {
                        lblPreviousName.Text = ds.Tables[0].Rows[0]["Prev_Last_Name"].ToString() + " " + ds.Tables[0].Rows[0]["Prev_First_Name"].ToString() + " " + ds.Tables[0].Rows[0]["Prev_Middle_Name"].ToString();
                    }
                    lblGender.Text = ds.Tables[0].Rows[0]["Gender_Desc"].ToString();
                    lblDOB.Text = ds.Tables[0].Rows[0]["DOB"].ToString();                   //Gender,Date_of_Birth,Changed_Name_Reason
                    lblNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();

                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    lblDomicileState.Text = ds.Tables[1].Rows[0]["Domicile_of_State"].ToString();
                    lblResvCategory.Text = ds.Tables[1].Rows[0]["Category"].ToString();
                    if (ds.Tables[1].Rows[0]["Category_Flag"].ToString() == "1")
                    {
                        if (ds.Tables[1].Rows[0]["ResvCategory"].ToString() != "")
                        {
                            lblResvCategory.Text += " (" + ds.Tables[1].Rows[0]["ResvCategory"].ToString();
                            if (ds.Tables[1].Rows[0]["SubCaste"].ToString() != "")
                                lblResvCategory.Text += " - " + ds.Tables[1].Rows[0]["SubCaste"].ToString();
                            lblResvCategory.Text += ")";
                        }
                    }
                    if (ds.Tables[1].Rows[0]["Physically_Challenged_Flag"].ToString() == "1")
                        lblPhyChlngd.Text = ds.Tables[1].Rows[0]["PhysicallyChallenged"].ToString();
                    else
                        lblPhyChlngd.Text = "     -";
                    lblGuardianincome.Text = "Rs. " + ds.Tables[1].Rows[0]["Guardian_Annual_Income"].ToString();
                    lblGuardianOccupation.Text = ds.Tables[1].Rows[0]["GuardOccupation"].ToString();
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        lblSocResv.Text += ds.Tables[2].Rows[i]["SocialReservation_Description"].ToString();
                        if (i < (ds.Tables[2].Rows.Count - 1))
                            lblSocResv.Text += ", ";
                    }
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    DGQualification1.DataSource = ds.Tables[3];
                    DGQualification1.DataBind();
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    DGSubmittedDocs1.DataSource = ds.Tables[4];
                    DGSubmittedDocs1.DataBind();
                }

                /*IF there are any Matching Records
                if(ds.Tables[5].Rows.Count>0)
                {  
					
                    divMatchingRecords.Style.Add("display","block");
                    //lblEligibilityFormNo.Text=ds.Tables[5].Rows[0]["ElgFormNo"].ToString() ;
                    DGMatchgCourseDetails.DataSource=ds.Tables[5];
                    DGMatchgCourseDetails.DataBind();
                }
                else
                {
					
                    divMatchingRecords.Style.Add("display","none");
                }
                if ((hidPRN.Value == null) || (hidPRN.Value == ""))
                {*/

                if (ds.Tables[5].Rows.Count > 0)
                {
                    lblInstName.Text = ds.Tables[5].Rows[0]["RefInstName"].ToString();
                    lblElgReason.Text = FormatReason(ds.Tables[5].Rows[0]["Reason"].ToString());
                    lblElgStatus.Text = FormatReason(ds.Tables[5].Rows[0]["EligibilityStatus"].ToString());
                    lblEligibilityFormNo.Text = ds.Tables[5].Rows[0]["ElgFormNo"].ToString();
                    TblAdmission.Style.Remove("display");
                    TblAdmission.Style.Add("display", "block");
                    divTblElgFormdetails.Style.Remove("display");
                    divTblElgFormdetails.Style.Add("display", "block");
                    lblAdmissionDate.Text = ds.Tables[5].Rows[0]["Admission_Date"].ToString();
                    lblAppFormNo.Text = ds.Tables[5].Rows[0]["Admission_Form_No"].ToString();
                    lblCourse.Text = ds.Tables[5].Rows[0]["Course"].ToString();



                }

                /*}
                else
                if ((hidPRN.Value != null) && (hidPRN.Value != ""))
                {
                    TblAdmission.Style.Remove("display");
                    TblAdmission.Style.Add("display", "none");
                    divTblElgFormdetails.Style.Remove("display");
                    divTblElgFormdetails.Style.Add("display", "none");
                    lblGridName.Text = "Course Eligibility Status";
                }*/


                hidDocCnt.Value = ds.Tables[4].Rows.Count.ToString();

                //Image1.ImageUrl = "ELGV2_ViewStatus__3.aspx?img=PR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
                //Image1.Visible = true;
                //Image2.ImageUrl = "ELGV2_ViewStatus__3.aspx?img=SR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
                //Image2.Visible = true;

                ds = elgDBAccess.Reg_Fetch_Student_Photograph(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(hidpkYear.Value), Convert.ToInt32(hidpkStudentID.Value));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Modified as per Req 102312
                    if (oCDNKeys != null)
                    {
                        objCDN = new clsCDN(oCDNKeys.PhotoSignKey);
                        sPathExists = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["PhotoPath"])) ? "Y" : "N";
                        Image1.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(ds.Tables[0].Rows[0]["PhotoPath"]), sPathExists, "P");
                        Image1.Width = objCDN.PhotoWidth;
                        Image1.Height = objCDN.PhotoHeight;

                        sPathExists = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["SignPath"])) ? "Y" : "N";
                        Image2.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(ds.Tables[0].Rows[0]["SignPath"]), sPathExists, "S");
                        Image2.Width = objCDN.ImageWidth;
                        Image2.Height = objCDN.ImageHeight;
                    }         
                }
               
                

                lblStudName.Text = "<br><b> for student <i>" + lblNameOfStudent.Text + "</i> for " + lblCr.Text + " " + ds.Tables[5].Rows[0]["Course"].ToString() + "</b>";

                /*divStudentDetails.Style.Add("Display","block");
                For Proper Display Message of Eligibility Decision
				
                lblGridName.Text ="Candidate "+ds.Tables[2].Rows[0]["First_Name"].ToString() +"'s Matching Other Course  Details ";
                if(ds.Tables[0].Rows.Count > 0)
                    lblPageHead.Text += "<font color='black'> of <i>"+lblNameOfStudent.Text+"</i> for Course "+ds.Tables[0].Rows[0]["CoursePart"].ToString()+"</font>";*/

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                throw new Exception(ex.Message);
            }

            ds.Dispose();


        }

        #endregion

        #region Datagrid related Functions

        #region DGMatchingRecords_ItemDataBound

        private void DGMatchingRecords_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + 1);
            }
        }

        #endregion


        # region Commented by Jatin


        /*      private void DGSubmittedDocs_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				//e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex+1);
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (DGSubmittedDocs.CurrentPageIndex * DGSubmittedDocs.PageSize) + 1);
				e.Item.Cells[2].Text = "Recvd (Valid)";
				if(e.Item.Cells[6].Text == "1")
				{
					((CheckBox)e.Item.Cells[3].Controls[1]).Checked = true;
					((RadioButton)e.Item.Cells[4].Controls[1]).Enabled = false;
					((RadioButton)e.Item.Cells[4].Controls[3]).Enabled = false;
					if(e.Item.Cells[7].Text == "1")
						((RadioButton)e.Item.Cells[4].Controls[1]).Checked = true;
					if(e.Item.Cells[7].Text == "0")
						((RadioButton)e.Item.Cells[4].Controls[3]).Checked = true;

				}

			}
        }*/


        # endregion Commented by Jatin

        #region DGCourseDetails_ItemDataBound

        private void DGCourseDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + 1);
                if (ds.Tables[0].Rows[e.Item.ItemIndex]["Reason"].ToString() == "" || ds.Tables[0].Rows[e.Item.ItemIndex]["Reason"].ToString() == null)
                {
                    e.Item.Cells[5].Text = "-";
                }

            }
        }

        #endregion

        /* #region DGSubmittedDocs1_RowDataBound
        protected void DGSubmittedDocs1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
            }
            if ((e.Row.RowType != DataControlRowType.Header) && (e.Row.RowType != DataControlRowType.Footer) && (e.Row.RowType != DataControlRowType.Pager))
            {
                e.Row.Cells[2].Text = "Recvd (Valid)";
                if (e.Row.Cells[6].Text == "1")
                {
                    ((CheckBox)e.Row.Cells[3].Controls[1]).Checked = true;
                    ((RadioButton)e.Row.Cells[4].Controls[1]).Enabled = false;
                    ((RadioButton)e.Row.Cells[4].Controls[3]).Enabled = false;
                    if (e.Row.Cells[7].Text == "1")
                        ((RadioButton)e.Row.Cells[4].Controls[1]).Checked = true;
                    if (e.Row.Cells[7].Text == "0")
                        ((RadioButton)e.Row.Cells[4].Controls[3]).Checked = true;

                }

            }
        }
        #endregion*/

        # region Commented by Jatin
        #region DGMatchgCourseDetails_PageIndexChanged

        //private void DGMatchgCourseDetails_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        //{
        //    DGMatchgCourseDetails.CurrentPageIndex = e.NewPageIndex;
        //    /*if(Request.QueryString["Search"] == "Adv")
        //    {
        //        FetchStudentDetails1(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"]),Convert.ToInt32(hidpkYear.Value),Convert.ToInt32(hidpkStudentID.Value));
        //    }
        //    if(Request.QueryString["Search"] == "Simple")
        //    {
        //        //FetchStudentDetails();
        //        FetchStudentDetails1(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"]),Convert.ToInt32(hidpkYear.Value),Convert.ToInt32(hidpkStudentID.Value));
        //    }*/

        //}

        #endregion
        # endregion Commented by Jatin

        #region DGMatchgCourseDetails1_PageIndexChanging
        protected void DGMatchgCourseDetails1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FetchStudentDetails();
            DGMatchgCourseDetails1.PageIndex = e.NewPageIndex;
            DGMatchgCourseDetails1.DataBind();
        }
        #endregion


        #endregion

        #region btnGoTo_Click

        protected void btnGoTo_Click(object sender, System.EventArgs e)
        {
            if (Request.QueryString["Search"] == "Simple")
                Server.Transfer("ELGV2_ViewStatus__1.aspx?Navigate=back&Search=Simple" + "&Blank=" + hidIsBlank.Value + "&InstID=" + hidPRN.Value + "&ElgFormNo=" + hidElgFormNo.Value,true);
            if (Request.QueryString["Search"] == "Adv")
                Server.Transfer("ELGV2_ViewStatus__1.aspx?Navigate=back&Search=Adv",true);


        }

        #endregion

        #region DGSubmittedDocs_ItemDataBound
        /*  protected void DGSubmittedDocs_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                //e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex+1);
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (DGSubmittedDocs.CurrentPageIndex * DGSubmittedDocs.PageSize) + 1);
                e.Item.Cells[2].Text = "Recvd (Valid)";
                if (e.Item.Cells[6].Text == "1")
                {
                    ((CheckBox)e.Item.Cells[3].Controls[1]).Checked = true;
                    ((RadioButton)e.Item.Cells[4].Controls[1]).Enabled = false;
                    ((RadioButton)e.Item.Cells[4].Controls[3]).Enabled = false;
                    if (e.Item.Cells[7].Text == "1")
                        ((RadioButton)e.Item.Cells[4].Controls[1]).Checked = true;
                    if (e.Item.Cells[7].Text == "0")
                        ((RadioButton)e.Item.Cells[4].Controls[3]).Checked = true;

                }

            }

        }*/
        #endregion

        #region DGSubmittedDocs1_RowDataBound

        protected void DGSubmittedDocs1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
            }
            if ((e.Row.RowType != DataControlRowType.Header) && (e.Row.RowType != DataControlRowType.Footer) && (e.Row.RowType != DataControlRowType.Pager))
            {
                e.Row.Cells[2].Text = "Recvd (Valid)";
                if (e.Row.Cells[6].Text == "1")
                {
                    ((CheckBox)e.Row.Cells[3].Controls[1]).Checked = true;
                    ((RadioButton)e.Row.Cells[4].Controls[1]).Enabled = false;
                    ((RadioButton)e.Row.Cells[4].Controls[3]).Enabled = false;
                    if (e.Row.Cells[7].Text == "1")
                        ((RadioButton)e.Row.Cells[4].Controls[1]).Checked = true;
                    if (e.Row.Cells[7].Text == "0")
                        ((RadioButton)e.Row.Cells[4].Controls[3]).Checked = true;

                }

            }

        }

        #endregion

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
