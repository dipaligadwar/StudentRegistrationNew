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
using Sancharak;
using Classes;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Text.RegularExpressions;
using StudentRegistration.Eligibility.ElgClasses;
using System.Net;
using DUConfigurations;


namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_ResolveProvisional__2 : System.Web.UI.Page
    {
        /// <summary>
        /// Summary description for reg_ResolveProvisionalEligibility__1.
        /// </summary>
        protected System.Web.UI.WebControls.Label lblFaculty;
        protected System.Web.UI.HtmlControls.HtmlGenericControl divDuplicateProfile;
        DataSet matchingrecords = new DataSet();
        DataSet submitteddocs = new DataSet();
        DataSet dsQualn = new DataSet();
        DataSet AdmissionDetails = new DataSet();
        clsUser userob = new clsUser();
        string userid = "";
        clsCommon Common = new clsCommon();
        DataSet ds = new DataSet();
        string[] RefIDarr = new string[4];
        clsCache clsCache = new clsCache();
        int GoToDataBase;
        InstituteRepository InstRep = new InstituteRepository();
        CDN oCDNKeys = clsDUConfigurations.Instance.CDNKeys;
        clsCDN objCDN = null;
        string sPathExists = string.Empty;
        #region Page_Load

        protected void Page_Load(object sender, System.EventArgs e)
        {
            clsCache.NoCache();
            if (!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[23];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidElgFormNo;
                hid[3] = hidFacID;
                hid[4] = hidpkYear;
                hid[5] = hidpkStudentID;
                hid[6] = hidCrID;
                hid[7] = hidCrMoLrnID;
                hid[8] = hidPtrnID;
                hid[9] = hidBrnID;
                hid[10] = hidCrPrDetailsID;
                hid[11] = hidAcademicYr;

                hid[12] = hid_fk_AcademicYr_ID;
                hid[13] = hidAcademicYrText;
                hid[14] = hidPRN;
                hid[15] = hidIsBlank;
                hid[16] = hidFacName;
                hid[17] = hidCrName;
                hid[18] = hidMOLName;
                hid[19] = hidPattern;
                hid[20] = hidBrName;
                hid[21] = hidAcYrName;
                hid[22] = hidSearchType;

                Common.setHiddenVariablesMPC(ref hid);
            }

            if (hidInstID.Value != "" && hidInstID.Value != null)
            {
                lblPageHead.Text = "Resolve Provisional Eligibility";
                lblSubHeader.Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);

            }
            rbEligible.Attributes.Add("onclick", "fnDisplayDiv();");
            rbDefaulter.Attributes.Add("onclick", "fnDisplayDiv();");
            rbProvisional.Attributes.Add("onclick", "fnDisplayDiv();");
            btnSubmit.Attributes.Add("onclick", "return fnConfirm();");

            userob = (clsUser)Session["User"];
            userid = userob.User_ID.ToString();

            if (hidSearchType.Value == "Simple")
                btnGoTo.Text = "Go To Search";
            else            // Search == "Adv"
                btnGoTo.Text = "Go To Student List";

            if (!IsPostBack)
            {

                /*ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                //reg_ResolveProvisionalEligibility ob = (reg_ResolveProvisionalEligibility)System.Web.HttpContext.Current.Handler;
                WebCtrl.StudentAdvanceSeachForConfigure tempHidden = (WebCtrl.StudentAdvanceSeachForConfigure)Cntph.FindControl("StudentAdvanceSeachForConfigure1");

                if (Request.QueryString["Search"] == "Adv")
                {
                    hidElgFormNo.Value = ((HtmlInputHidden)tempHidden.FindControl("hidElgFormNo")).Value;
                    hidpkYear.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkYear")).Value;
                    hidpkStudentID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkStudentID")).Value;
                    hidpkFacID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidFacID")).Value;
                    hidpkCrID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidCrID")).Value;
                    hidpkMoLrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidCrMoLrnID")).Value;
                    hidpkPtrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidPtrnID")).Value;
                    hidpkBrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidBrnID")).Value;
                    hidpkCrPrDetailsID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidCrPrDetailsID")).Value;
                    hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)tempHidden.FindControl("hid_fk_AcademicYr_ID")).Value;
                    hidAcademicYrText.Value = ((HtmlInputHidden)tempHidden.FindControl("hidAcademicYrText")).Value;
                    hidInstID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidInstID")).Value;
                    hidPRN.Value = ((HtmlInputHidden)tempHidden.FindControl("hidPRN")).Value;
                    hidFacName.Value = ((HtmlInputHidden)tempHidden.FindControl("hidFacName")).Value;
                    hidCrName.Value = ((HtmlInputHidden)tempHidden.FindControl("hidCrName")).Value;
                    hidMOLName.Value = ((HtmlInputHidden)tempHidden.FindControl("hidMOLName")).Value;
                    hidPattern.Value = ((HtmlInputHidden)tempHidden.FindControl("hidPattern")).Value;
                    hidBrName.Value = ((HtmlInputHidden)tempHidden.FindControl("hidBrName")).Value;
                    hidInstID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidInstID")).Value;
                    hidAcYrName.Value = ((HtmlInputHidden)tempHidden.FindControl("hidAcYrName")).Value;
                    hidSearchType.Value = ((HtmlInputHidden)tempHidden.FindControl("hidSearchType")).Value;
                    hidBranchName.Value = ((HtmlInputHidden)tempHidden.FindControl("hidBranchName")).Value;

                }
                if (Request.QueryString["Search"] == "Simple")
                {
                    hidElgFormNo.Value = ((HtmlInputHidden)tempHidden.FindControl("hidElgFormNo")).Value;
                    hidpkYear.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkYear")).Value;
                    hidpkStudentID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidpkStudentID")).Value;
                    hidpkFacID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidFacID")).Value;
                    hidpkCrID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidCrID")).Value;
                    hidpkMoLrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidCrMoLrnID")).Value;
                    hidpkPtrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidPtrnID")).Value;
                    hidpkBrnID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidBrnID")).Value;
                    hidpkCrPrDetailsID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidCrPrDetailsID")).Value;
                    hidInstID.Value = ((HtmlInputHidden)tempHidden.FindControl("hidInstID")).Value;
                    hidIsBlank.Value = ((HtmlInputHidden)tempHidden.FindControl("hidIsBlank")).Value;
                    hidPRN.Value = ((HtmlInputHidden)tempHidden.FindControl("hidPRN")).Value;
                    hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)tempHidden.FindControl("hid_fk_AcademicYr_ID")).Value;
                }*/


                

                hidElgFlag.Value = "NotAssigned";
                FetchStudentDetails();
                divPRN.Style.Add("Display", "none");
                GoToDataBase = 1;
                Session["GoToDataBase"] = GoToDataBase;
            }
            else if (IsPostBack)
            {
                GoToDataBase = Convert.ToInt32(Session["GoToDataBase"].ToString());
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

        #region FetchStudentDetails

        public void FetchStudentDetails()
        {

            lblEligibilityFormNo.Text = hidElgFormNo.Value.ToString();

            string ElgFormNo = hidElgFormNo.Value.ToString();

            RefIDarr = ElgFormNo.Split('-');   // UniID = RefIDarr[0], InstID = RefIDarr[1],Year = RefIDarr[2], StudID = RefIDarr[3]
            try
            {

                //ds=clsEligibilityDBAccess.Fetch_REG_Pending_Student_Details(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"].ToString()),Convert.ToInt32(Session["pk_Year"].ToString()),Convert.ToInt32(Session["pk_Student_ID"].ToString()),Convert.ToInt32(RefIDarr[1].ToString()),Convert.ToInt32(RefIDarr[0].ToString()),Convert.ToInt32(RefIDarr[2].ToString()),Convert.ToInt32(RefIDarr[3].ToString()),Convert.ToInt32(Session["pk_CrMoLrnPtrn_ID"].ToString()));
                ds = clsEligibilityDBAccess.Fetch_REG_ProvisionallyEligible_Student_Details(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(hidpkYear.Value), Convert.ToInt32(hidpkStudentID.Value), Convert.ToInt32(RefIDarr[0].ToString()), Convert.ToInt32(RefIDarr[1].ToString()), Convert.ToInt32(RefIDarr[2].ToString()), Convert.ToInt32(RefIDarr[3].ToString()), Convert.ToInt32(hidFacID.Value), Convert.ToInt32(hidCrID.Value), Convert.ToInt32(hidCrMoLrnID.Value), Convert.ToInt32(hidPtrnID.Value), Convert.ToInt32(hidCrPrDetailsID.Value), Convert.ToInt32(hidBrnID.Value));
                //ds=clsEligibilityDBAccess.Fetch_REG_Pending_Student_Details(179,1996,100,179,1996,1,1,1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblInstName.Text = ds.Tables[0].Rows[0]["RefInstName"].ToString();
                    lblProvisionalReason.Text = FormatReason(ds.Tables[0].Rows[0]["PendingReason"].ToString());
                    lblAdmissionDate.Text = ds.Tables[0].Rows[0]["Admission_Date"].ToString();
                    lblAppFormNo.Text = ds.Tables[0].Rows[0]["Admission_Form_No"].ToString();
                    //lblCourse.Text=ds.Tables[0].Rows[0]["Course"].ToString()+" ("+ds.Tables[0].Rows[0]["CoursePart"].ToString()+")";
                    //lblFaculty.Text = ds.Tables[0].Rows[0]["Faculty"].ToString();
                    lblCourse.Text = ds.Tables[0].Rows[0]["Course"].ToString(); //+ "-" + ds.Tables[0].Rows[0]["CrPrAbbr"].ToString();
                    hidElgFlag.Value = ds.Tables[0].Rows[0]["Eligibility"].ToString();
                    hidSMSCrAbbr.Value = ds.Tables[0].Rows[0]["CrAbbr"].ToString();
                    hidAcademicYr.Value = ds.Tables[0].Rows[0]["Year"].ToString();
                    if (hidSMSCrAbbr.Value.Length > 9)
                    {
                        hidSMSCrAbbr.Value = hidSMSCrAbbr.Value.Substring(0, 8);
                    }

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
                    lblPermRegNo.Text = ds.Tables[2].Rows[0]["PRN"].ToString();
                    if (lblPermRegNo.Text == "" || lblPermRegNo.Text == null)
                        lblPermRegNo.Text = "Not Generated";
                    lblAlumni.Text = ds.Tables[2].Rows[0]["Alumini_Flag"].ToString();
                    lblNameAsMarksheet.Text = ds.Tables[2].Rows[0]["Name_QualExamMarkSheet"].ToString();
                    lblNameOfStudent.Text = ds.Tables[2].Rows[0]["Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Middle_Name"].ToString();
                    lblMothersMaidenName.Text = ds.Tables[2].Rows[0]["Mother_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Mother_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Mother_Middle_Name"].ToString();
                    lblFathersName.Text = ds.Tables[2].Rows[0]["Father_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Father_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Father_Middle_Name"].ToString();
                    hidSMSFirstName.Value = ds.Tables[2].Rows[0]["First_Name"].ToString();
                    if (hidSMSFirstName.Value.Length > 15)
                    {
                        hidSMSFirstName.Value = hidSMSFirstName.Value.Substring(0, 14);
                    }
                    if (ds.Tables[2].Rows[0]["Changed_Name_Flag"].ToString() == "1")
                    {
                        lblPreviousName.Text = ds.Tables[2].Rows[0]["Prev_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Prev_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Prev_Middle_Name"].ToString();
                    }
                    lblGender.Text = ds.Tables[2].Rows[0]["Gender_Desc"].ToString();
                    lblDOB.Text = ds.Tables[2].Rows[0]["DOB"].ToString();                   //Gender,Date_of_Birth,Changed_Name_Reason
                    lblNationality.Text = ds.Tables[2].Rows[0]["Nationality"].ToString();
                    hidSMSMobileNumber.Value = ds.Tables[2].Rows[0]["Mobile_Number"].ToString();
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
                    if (ds.Tables[3].Rows[0]["Physically_Challenged_Flag"].ToString() == "1")
                        lblPhyChlngd.Text = ds.Tables[3].Rows[0]["PhysicallyChallenged"].ToString();
                    else
                        lblPhyChlngd.Text = "     -";
                    lblAdmittedCategory.Text = ds.Tables[3].Rows[0]["AdmittedCategory"].ToString();
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

                //IF there are any Matching Records
                //Commented By deepti on 10/09/2007 to supress the functionality of
                //displaying match records for different Courses and Institutes for given student
                /*
                        HTML code to show matching records,removed from aspx page as it was giving error when commented
     					<div id="divMatchingRecords" style="DISPLAY: block" runat="server"><br>
						<asp:label id="lblGridName" runat="server" Width="100%" CssClass="GridHeadingM" Height="18px"> Eligiblility Pending Student's Other Course(s) Details</asp:label><asp:datagrid id="DGMatchgCourseDetails" runat="server" Width="100%" BorderColor="#336699" BorderWidth="1px"
							AutoGenerateColumns="False" PageSize="5" BorderStyle="Solid">
							<ItemStyle CssClass="GridData2"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="1px" ForeColor="White" BorderStyle="Solid"
								BorderColor="White" CssClass="GridHeading"></HeaderStyle>
							<Columns>
								<asp:BoundColumn ReadOnly="True" HeaderText="Sr. No."></asp:BoundColumn>
								<asp:BoundColumn DataField="Course" HeaderText="Course"></asp:BoundColumn>
								<asp:BoundColumn DataField="InstituteName" HeaderText="Institute Name"></asp:BoundColumn>
								<asp:BoundColumn DataField="EligibilityStatus" HeaderText="Eligibility Status"></asp:BoundColumn>
								<asp:BoundColumn DataField="CourseStatus" HeaderText="Course Status"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</div>
                 */
                /*if(ds.Tables[7].Rows.Count>0)
                {  
					
                    divMatchingRecords.Style.Add("display","block");
                    DGMatchgCourseDetails.DataSource=ds.Tables[7];
                    DGMatchgCourseDetails.DataBind();
                }
                else
                {
					
                    divMatchingRecords.Style.Add("display","none");
                }*/           

                hidDocCnt.Value = ds.Tables[6].Rows.Count.ToString();
                //Image1.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[2].Rows[0]["PhotoPath"].ToString();//"ELGV2_ResolveProvisional__3.aspx?img=PR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
                Image1.Visible = true;
                //Image2.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[2].Rows[0]["SignPath"].ToString();//"ELGV2_ResolveProvisional__3.aspx?img=SR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
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

                //For Proper Display Message of Eligibility Decision
                if (hidElgFlag.Value == "1")
                {
                    lblProfileHeading.Text = "Candidate " + ds.Tables[2].Rows[0]["First_Name"].ToString() + " is Marked Eligible for the " + lblCr.Text + " : " + ds.Tables[0].Rows[0]["CrPrAbbr"].ToString();
                    divPendingReason.Visible = false;
                    divReason.Attributes.Add("style", "display:none");
                }
                else if (hidElgFlag.Value == "2")
                {
                    lblProfileHeading.Text = "Candidate " + ds.Tables[2].Rows[0]["First_Name"].ToString() + " is Marked Not-Eligible for the " + lblCr.Text + " : " + ds.Tables[0].Rows[0]["CrPrAbbr"].ToString();
                    lblEligibilityReason.Text = "Not-Eligible due to following reason(s)";
                    divPendingReason.Visible = true;
                    rbDefaulter.Checked = true;
                    divReason.Attributes.Add("style", "display:inline");
                    divOldReason.Attributes.Add("style", "display:inline");
                    //tbReason.Text = ds.Tables[0].Rows[0]["PendingReason"].ToString();
                    tbOldReason.Text = FormatReason(ds.Tables[0].Rows[0]["PendingReason"].ToString()).Replace("<br/>", Environment.NewLine);

                }
                else if (hidElgFlag.Value == "3")
                {
                    lblProfileHeading.Text = "Candidate " + ds.Tables[2].Rows[0]["First_Name"].ToString() + " is Marked Pending for the " + lblCr.Text + " : " + ds.Tables[0].Rows[0]["CrPrAbbr"].ToString();
                    lblEligibilityReason.Text = "Eligibility Kept Pending due to following reason(s)";
                    divPendingReason.Visible = true;
                    rbPending.Checked = true;
                    divReason.Attributes.Add("style", "display:inline");
                    divOldReason.Attributes.Add("style", "display:inline");
                    tbOldReason.Text = FormatReason(ds.Tables[0].Rows[0]["PendingReason"].ToString()).Replace("<br/>", Environment.NewLine);

                }
                else if (hidElgFlag.Value == "5")
                {
                    lblProfileHeading.Text = "Candidate " + ds.Tables[2].Rows[0]["First_Name"].ToString() + " is Marked Provisionally Eligible for the " + lblCr.Text + " : " + ds.Tables[0].Rows[0]["CrPrAbbr"].ToString();
                    lblEligibilityReason.Text = "Eligibility Kept Provisional due to following reason(s)";
                    divPendingReason.Visible = true;
                    rbProvisional.Checked = true;
                    divReason.Attributes.Add("style", "display:inline");
                    divOldReason.Attributes.Add("style", "display:inline");
                    tbOldReason.Text = FormatReason(ds.Tables[0].Rows[0]["PendingReason"].ToString()).Replace("<br/>", Environment.NewLine);

                }
                //lblGridName.Text ="Candidate "+ds.Tables[2].Rows[0]["First_Name"].ToString() +"'s Matching Other Course  Details ";
                if (ds.Tables[0].Rows.Count > 0)
                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                lblPageHead.Text = "Resolve Provisional Eligibility";
                lblSubHeader.Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);
                lblStudName.Text = "<br><b> for student <i>" + lblNameOfStudent.Text + "</i> for " + lblCr.Text + " " + ds.Tables[0].Rows[0]["CrPrAbbr"].ToString() + "</b>";
            }
           // catch (Exception ex)
            //{
                //Response.Write(ex.Message);
                // throw new Exception(ex.Message);
          //  }
            finally
            {
                ds.Dispose();
            }


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
        #region DGSubmittedDocs_ItemDataBound

        /*      private void DGSubmittedDocs_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + 1);
                e.Item.Cells[2].Text = "Recvd (Valid)";
                if (ds.Tables[6].Rows[e.Item.ItemIndex]["RecvdBy_Uni"].ToString() == "1")
                {
                    ((CheckBox)e.Item.Cells[3].Controls[1]).Checked = true;
                    ((RadioButton)e.Item.Cells[4].Controls[1]).Enabled = true;
                    ((RadioButton)e.Item.Cells[4].Controls[3]).Enabled = true;
                    if (ds.Tables[6].Rows[e.Item.ItemIndex]["ValidityBy_Uni"].ToString() == "1")
                        ((RadioButton)e.Item.Cells[4].Controls[1]).Checked = true;
                    if (ds.Tables[6].Rows[e.Item.ItemIndex]["ValidityBy_Uni"].ToString() == "0")
                        ((RadioButton)e.Item.Cells[4].Controls[3]).Checked = true;

                }

            }
        }
        */
        #endregion
        # endregion Commented by Jatin

        /*#region DGSubmittedDocs1_RowDataBound
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
                if (ds.Tables[6].Rows[e.Row.RowIndex]["RecvdBy_Uni"].ToString() == "1")
                {
                    ((CheckBox)e.Row.Cells[3].Controls[1]).Checked = true;
                    ((RadioButton)e.Row.Cells[4].Controls[1]).Enabled = true;
                    ((RadioButton)e.Row.Cells[4].Controls[3]).Enabled = true;
                    if (ds.Tables[6].Rows[e.Row.RowIndex]["ValidityBy_Uni"].ToString() == "1")
                        ((RadioButton)e.Row.Cells[4].Controls[1]).Checked = true;
                    if (ds.Tables[6].Rows[e.Row.RowIndex]["ValidityBy_Uni"].ToString() == "0")
                        ((RadioButton)e.Row.Cells[4].Controls[3]).Checked = true;

                }

            }
        }
        #endregion*/

        #region DGCourseDetails_ItemDataBound

        private void DGCourseDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + 1);
            }
        }

        #endregion

        #endregion

        #region btnGoTo_Click

        protected void btnGoTo_Click(object sender, System.EventArgs e)
        {
            if (hidSearchType.Value == "Simple")
                Server.Transfer("ELGV2_ResolveProvisional__1.aspx?Navigate=back&Search=Simple");
            if (hidSearchType.Value == "Adv")
                Server.Transfer("ELGV2_ResolveProvisional__1.aspx?Navigate=back&Search=Adv" + "&AcYear=" + hid_fk_AcademicYr_ID.Value + "&AcYearText=" + hidAcademicYrText.Value + "&Faculty=" + hidFacID.Value + "&FacName=" + hidFacName.Value + "&Course=" + hidCrID.Value + "&CrName=" + hidCrName.Value + "&MoLearning=" + hidCrMoLrnID.Value + "&MoLrnName=" + hidMoLrnText.Value + "&Pattern=" + hidPtrnID.Value + "&PatternName=" + hidPtrnText.Value + "&Branch=" + hidBrnID.Value + "&BranchName=" + hidBrName.Value +  "&CoursePrtDetails=" + hidCrPrDetailsID.Value + "&SearchType=" + hidSearchType.Value);
        }

        #endregion

        #region btnSubmit_Click

        protected void btnSubmit_Click(object sender, System.EventArgs e)
        {
            divEligibilityDecision.Style.Add("display", "none");

            //if (rbProvisional.Checked == true)
            //{
            //    divPRN.Style.Add("display", "block");
            //    lblPRN.Text = "<Font color='#c00000' size='3'>Selected record has already been processed for 'Provisionally Eligible' decision.</font><br>" + lblPermRegNo.Text.Trim() + "<br>The SMS regarding the same is already been sent to the student.";
            //}
            if (GoToDataBase == 1)
            {
                string sReason = "";
                string PRN, ElgLabel = "";
                string flag = "0";
                DataSet dsDocs = new DataSet();
                DataRow dr;
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
                        dr["fk_Doc_ID"] = DGSubmittedDocs1.Rows[j].Cells[5].Text.Trim();
                        dr["RecvdBy_Uni"] = '1';
                        dr["ValidityBy_Uni"] = hidDocXML.Value[i + 1];
                        dsDocs.Tables["StudentDocs"].Rows.Add(dr);
                    }
                    else if (hidDocXML.Value[i] == '0')     //if checkbox checked =  false
                    {
                        dr = dsDocs.Tables["StudentDocs"].NewRow();
                        dr["fk_Doc_ID"] = DGSubmittedDocs1.Rows[j].Cells[5].Text.Trim();
                        dr["RecvdBy_Uni"] = '0';
                        dr["ValidityBy_Uni"] = "";
                        dsDocs.Tables["StudentDocs"].Rows.Add(dr);
                    }
                    j++;
                }

                System.Text.StringBuilder sb = new System.Text.StringBuilder(1000);    //contains XML fmt of Docs
                System.IO.StringWriter sw = new System.IO.StringWriter(sb);
                dsDocs.WriteXml(sw, XmlWriteMode.IgnoreSchema);
                //string sbuilder = "";
                //if(sb.Length==14)     //if empty contains "</newdataset>"
                // sb = (System.Text.StringBuilder)null;
                //sb = (System.Text.StringBuilder)Convert.DBNull;   
                if (rbEligible.Checked) //Eligible
                {
                    divReason.Attributes.Add("style", "display:none");
                    flag = "1";
                    ElgLabel = "Eligible";
                    lblProvisionalReason.Text = "";
                   
                        sReason = tbOldReason.Text.Replace("\r \n", "") + "[Resolved]";
                }
                else if (rbDefaulter.Checked) //Not Eligible
                {
                    flag = "2";
                    ElgLabel = "Not Eligible";
                    sReason = tbOldReason.Text.Replace("\r\n", "") + "===" + DateTime.Now.ToString("MM/dd/yy HH:mm") + "===" + tbReason.Text.Trim();
                }
                /* else if(rbPending.Checked) //Pending-- Commented by Shivani 0n 3rd Jan
                {
                    flag = "3";
                    ElgLabel= "Pending";
                    sReason = tbReason.Text.Trim(); 
                } */
                else if (rbProvisional.Checked) //Provisionally Eligible
                {
                    flag = "5";
                    ElgLabel = "Provisionally Eligible";
                    sReason = tbOldReason.Text.Replace("\r\n", "") + "===" + DateTime.Now.ToString("MM/dd/yy HH:mm") + "===" + tbReason.Text.Trim();

                    divPRN.Style.Add("display", "block");
                    lblPRN.Text = "<Font color='#c00000' size='3'>Selected record has been processed for 'Provisionally Eligible' decision with probably changes in the Student Document details.</font><br>";// +lblPermRegNo.Text.Trim() + "<br>The SMS regarding the same is already been sent to the student.";
                }

                tbOldReason.Text = FormatReason(sReason).Replace("<br/>", Environment.NewLine);

                hidElgFlag.Value = flag;
                if (lblPermRegNo.Text == "" || lblPermRegNo.Text == null || lblPermRegNo.Text == "-" || lblPermRegNo.Text == "Not Generated")
                    lblPermRegNo.Text = "00";
                RefIDarr = hidElgFormNo.Value.Split('-');
                //  PRN = clsEligibilityDBAccess.REG_ProvisionallyEligibleStudentEligibilityDecision(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"].ToString()), Convert.ToInt32(Session["pk_Year"].ToString()), Convert.ToInt32(Session["pk_Student_ID"].ToString()), Convert.ToInt32(Session["pk_CrMoLrnPtrn_ID"].ToString()), flag, sb, tbReason.Text.Trim(), lblPermRegNo.Text.Trim(), userid);
                int Error;
                Error = clsEligibilityDBAccess.REG_ProvisionallyEligibleStudentEligibilityDecision(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(RefIDarr[2].ToString()), Convert.ToInt32(RefIDarr[1].ToString()), Convert.ToInt32(RefIDarr[3].ToString()), Convert.ToInt32(hidFacID.Value), Convert.ToInt32(hidCrID.Value), Convert.ToInt32(hidCrMoLrnID.Value), Convert.ToInt32(hidPtrnID.Value), Convert.ToInt32(hidBrnID.Value), Convert.ToInt32(hidCrPrDetailsID.Value), Convert.ToInt32(hid_fk_AcademicYr_ID.Value), flag, sb, lblPermRegNo.Text.Trim(), sReason, userid);
                //lblPermRegNo.Text = hidPRN.Value;
                //FetchStudentDetails();
                clsUser u = (clsUser)Session["User"]; //Added By Saroj on 1st Nov 2007

                if (Error == 0 && flag != "5")
                {
                    string SMSreturn = "";
                    string SMSMessage = "";

                    try
                    {
                        SendSMS objSendSMS = new SendSMS();
                        divPRN.Style.Add("Display", "block");
                        //lblPRN.Text ="The Student is Marked as <br><Font color='red' size='2'>"+ElgLabel+"</font><br> for the Course "+lblCourse.Text +" .";
                        lblPRN.Text = "The Student is Marked as <br><Font color='red' size='2'>" + ElgLabel + "</font><br>";
                        if (flag == "1")
                        {
                            if (lblPermRegNo.Text != "" && lblPermRegNo.Text != "00" && lblPermRegNo.Text != null)
                            {

                                lblPRN.Text += " " + lblPermanentRegistrationNumber.Text + " for the Student ";
                                lblPRN.Text += "<i>" + lblNameOfStudent.Text + "</i> is <br><Font color='red' size='3'>" + lblPermRegNo.Text + "</Font><br>Please write " + lblPermanentRegNumber.Text + " on the Admission/Eligibility form.";
                                Cache["PRN"] = lblPRN.Text;
                                Cache["GeneratedPRN"] = lblPermRegNo.Text;
                            }
                            else
                            {
                                lblPRN.Text += " \nThe " + lblPermanentRegistrationNumber.Text + " for the Student ";
                                lblPRN.Text += "<i>" + lblNameOfStudent.Text + "</i> is same<br><Font color='red' size='3'>" + lblPermRegNo.Text + "</Font><br>Please write " + lblPermanentRegNumber.Text + " on the Admission/Eligibility form.";
                                Cache["PRN"] = lblPRN.Text;
                                Cache["GeneratedPRN"] = lblPermRegNo.Text;
                            }

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
                            //SMSMessage = "Congrats " + hidSMSFirstName.Value + ",You are eligible for " + hidSMSCrAbbr.Value + " for Academic Year " + hidAcademicYr.Value + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your " + lblPermanentRegNumber.Text + ":" + lblPermRegNo.Text + ".";
                            SMSMessage = clsEligibilityRights.GetSMSBody("24", hidSMSFirstName.Value, hidSMSCrAbbr.Value, hidAcademicYr.Value, hidUniAbbrv.Value, lblPermRegNo.Text, clsGetSettings.SitePath, userName, password, string.Empty);

                            objSendSMS.epMessage = SMSMessage;
                            objSendSMS.epUser = u.User_ID;
                            lblProvisionalReason.Text = FormatReason(tbOldReason.Text);//Added By Saroj on 1st Nov 2007
                        }

                        else if ((flag == "2") /* ||(flag == "3")*/) // Pending--Commented by Shivani on 3rd Jan 2008
                        {
                            /*if (lblPermRegNo.Text != "" && lblPermRegNo.Text != "00" && lblPermRegNo.Text != null)
                            {
                                lblPRN.Text += "\nThe Permanent Registration Number (PRN) for the Student ";
                                lblPRN.Text += "<i>" + lblNameOfStudent.Text + "</i> is same<br><Font color='red' size='3'>" + lblPermRegNo.Text + "</Font><br>Please write PRN on the Admission/Eligibility form.";
                                Cache["PRN"] = lblPRN.Text;
                                Cache["GeneratedPRN"] = PRN;
                            }
                            else
                            {*/
                            lblPRN.Text = "The Student <i>" + lblNameOfStudent.Text + "</i> is marked <br><Font color='#c00000' size='2'>" + ElgLabel + "</Font><br> for the " + lblCr.Text + " " + lblCourse.Text;
                            Cache["PRN"] = lblPRN.Text;
                            //}
                            lblProvisionalReason.Text = FormatReason(tbOldReason.Text);
                            // Eligibility.clsEligibilityDBAccess.CheckDetailsToChangeFromProvisionallyEligibleToNotEligible(hidUniID.Value, hidpkYear.Value, hidpkStudentID.Value, hidInstID.Value);

                            if (flag == "2")
                            {
                                //SMSMessage = "Dear " + hidSMSFirstName.Value + ", You are found ineligible for " + hidSMSCrAbbr.Value + " for Academic Year " + hidAcademicYr.Value + ". For more details contact your " + lblCollege.Text.ToLower() + ".";
                                SMSMessage = clsEligibilityRights.GetSMSBody("5", hidSMSFirstName.Value, hidSMSCrAbbr.Value, hidAcademicYr.Value, hidUniAbbrv.Value, lblPermRegNo.Text, clsGetSettings.SitePath, "", "", string.Empty);
                            }
                            //else if (flag == "3")
                            //{
                            //    SMSMessage = "Dear " + hidSMSFirstName.Value + ", your eligibility for " + hidSMSCrAbbr.Value + " is pending. Discrepancy is available in college's login on Digital University Portal of eSuvidha.";
                            //}
                            objSendSMS.epMessage = SMSMessage;
                            objSendSMS.epUser = u.User_ID;  //Added By Saroj on 1st Nov 2007
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

                divEligibilityDecision.Attributes.Add("display", "none");

                int k = 0;
                for (int l = 0; l < hidDocXML.Value.Length; l += 2)
                {
                    if (hidDocXML.Value[l] == '1')     //if checkbox checked =  true
                    {

                        if (hidDocXML.Value[l + 1] == '1')
                        {
                            ((RadioButton)DGSubmittedDocs1.Rows[k].Cells[4].Controls[1]).Checked = true;
                        }
                        else
                        {
                            ((RadioButton)DGSubmittedDocs1.Rows[k].Cells[4].Controls[3]).Checked = true;
                        }
                    }
                    k++;
                }
                if (lblPermRegNo.Text == "" || lblPermRegNo.Text == null || lblPermRegNo.Text == "00")
                    lblPermRegNo.Text = "-";
                GoToDataBase = 0;
                Session["GoToDataBase"] = GoToDataBase;


            }
            else
            {
                divPRN.Style.Add("display", "block");
                lblPermRegNo.Text = Cache["GeneratedPRN"].ToString();
                if (Cache["GeneratedPRN"] != null && Cache["GeneratedPRN"].ToString() != "")
                {
                    divReason.Attributes.Add("style", "display:none");
                }
                lblPRN.Text = "<Font color='#c00000' size='3'>Selected Record has Already been Processed</font><br>" + Cache["PRN"].ToString();
            }

            for (int i = 0; i < DGSubmittedDocs1.Rows.Count; i++)
            {
                ((CheckBox)DGSubmittedDocs1.Rows[i].Cells[3].Controls[1]).Enabled = false;
                ((RadioButton)DGSubmittedDocs1.Rows[i].Cells[4].Controls[1]).Enabled = false;
                ((RadioButton)DGSubmittedDocs1.Rows[i].Cells[4].Controls[3]).Enabled = false;  

            }
        }

        #endregion

        /* protected void DGSubmittedDocs_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + 1);
                e.Item.Cells[2].Text = "Recvd (Valid)";

                if (ds.Tables[6].Rows[e.Item.ItemIndex]["RecvdBy_Uni"].ToString() == "1")
                {
                    ((CheckBox)e.Item.Cells[3].Controls[1]).Checked = true;
                    ((RadioButton)e.Item.Cells[4].Controls[1]).Enabled = true;
                    ((RadioButton)e.Item.Cells[4].Controls[3]).Enabled = true;
                    if (ds.Tables[6].Rows[e.Item.ItemIndex]["ValidityBy_Uni"].ToString() == "1")
                        ((RadioButton)e.Item.Cells[4].Controls[1]).Checked = true;
                    if (ds.Tables[6].Rows[e.Item.ItemIndex]["ValidityBy_Uni"].ToString() == "0")
                        ((RadioButton)e.Item.Cells[4].Controls[3]).Checked = true;

                }
                //else
                //{
                //    ((CheckBox)e.Item.Cells[3].Controls[1]).Checked = false;
                //    ((RadioButton)e.Item.Cells[4].Controls[1]).Enabled = false;
                //    ((RadioButton)e.Item.Cells[4].Controls[3]).Enabled = false;
                //}


            }
        }*/

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
                if (ds.Tables[6].Rows[e.Row.RowIndex]["RecvdBy_Uni"].ToString() == "1")
                {
                    ((CheckBox)e.Row.Cells[3].Controls[1]).Checked = true;
                    ((RadioButton)e.Row.Cells[4].Controls[1]).Enabled = true;
                    ((RadioButton)e.Row.Cells[4].Controls[3]).Enabled = true;
                    if (ds.Tables[6].Rows[e.Row.RowIndex]["ValidityBy_Uni"].ToString() == "1")
                        ((RadioButton)e.Row.Cells[4].Controls[1]).Checked = true;
                    if (ds.Tables[6].Rows[e.Row.RowIndex]["ValidityBy_Uni"].ToString() == "0")
                        ((RadioButton)e.Row.Cells[4].Controls[3]).Checked = true;

                }

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

                            string Path = GetCDN_DownloadPath(Convert.ToInt32(DGSubmittedDocs1.DataKeys[e.Row.RowIndex]["Admission_Form_No"])) + DGSubmittedDocs1.DataKeys[e.Row.RowIndex]["FileName"].ToString();
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
                if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
                    e.Row.Cells[6].Style.Add("display", "none");
            }

        }

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



