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
using Sancharak;

namespace StudentRegistration.Eligibility
{
	/// <summary>
	/// Summary description for reg_PendingStudentEligibility__1.
	/// </summary>
	public partial class reg_PendingStudentEligibility__1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblFaculty;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divDuplicateProfile;
		DataSet matchingrecords=new DataSet();
		DataSet submitteddocs=new DataSet();
		DataSet dsQualn = new DataSet();
		DataSet AdmissionDetails=new DataSet();
		clsUser userob = new clsUser();
		string userid ="";
		clsCommon Common = new clsCommon();
		DataSet ds = new DataSet();
		string[] RefIDarr = new string[4];
		int GoToDataBase;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            Classes.clsCache.NoCache();
			// Put user code to initialize the page here
            if (!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[6];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidElgFormNo;
                hid[3] = hidCrMoLrnPtrnID;
                hid[4] = hidpkYear;
                hid[5] = hidpkStudentID;

                Common.setHiddenVariables(ref hid);
            }

            if (hidInstID.Value != "" && hidInstID.Value != null)
            {
                // hidInstID.Value = Request.QueryString["InstituteID"].ToString().Trim();
                lblTitle.Text = "Resolve Pending Eligibility";
                lblInstitute.Text = "  for " + Classes.InstituteRepository.InstituteName(hidUniID.Value, hidInstID.Value);

            }
			rbEligible.Attributes.Add("onclick","fnDisplayDiv();");
            rbProvisional.Attributes.Add("onclick", "fnDisplayDiv();");
			rbDefaulter.Attributes.Add("onclick","fnDisplayDiv();");
			rbPending.Attributes.Add("onclick","fnDisplayDiv();");
			btnSubmit.Attributes.Add("onclick","return fnConfirm();");
			userob=(clsUser)Session["User"];
			userid=userob.User_ID.ToString();
             
			if(Request.QueryString["Search"] == "Simple")
				btnGoTo.Text="Go To Search";
			else            // Search == "Adv"
				btnGoTo.Text="Go To Student List";

			if(!IsPostBack)
			{
			 
				reg_PendingStudentEligibility ob =(reg_PendingStudentEligibility)System.Web.HttpContext.Current.Handler;
                WebCtrl.StudentAdvanceSeachForConfigure tempHidden = (WebCtrl.StudentAdvanceSeachForConfigure)ob.FindControl("StudentAdvanceSeachForConfigure1");
				if(Request.QueryString["Search"] == "Adv")
				{
					hidElgFormNo.Value=((HtmlInputHidden)tempHidden.FindControl("hidElgFormNo")).Value;
					hidpkYear.Value=((HtmlInputHidden)tempHidden.FindControl("hidpkYear")).Value;
					hidpkStudentID.Value=((HtmlInputHidden)tempHidden.FindControl("hidpkStudentID")).Value;
					hidCrMoLrnPtrnID.Value=((HtmlInputHidden)tempHidden.FindControl("hidCrMoLrnPtrnID")).Value;
				}
				if(Request.QueryString["Search"] == "Simple")
				{
					hidElgFormNo.Value=((HtmlInputHidden)ob.FindControl("hidElgFormNo")).Value;
					hidpkYear.Value=((HtmlInputHidden)ob.FindControl("hidpkYear")).Value;
					hidpkStudentID.Value=((HtmlInputHidden)ob.FindControl("hidpkStudentID")).Value;
					hidCrMoLrnPtrnID.Value=((HtmlInputHidden)ob.FindControl("hidCrMoLrnPtrnID")).Value;
				}
				hidElgFlag.Value="NotAssigned";
				FetchStudentDetails();
				divPRN.Style.Add("Display","none");
				GoToDataBase = 1;
				Session["GoToDataBase"] = GoToDataBase;
			}
			else if(IsPostBack)
			{
				GoToDataBase = Convert.ToInt32(Session["GoToDataBase"].ToString());
			}
			
			
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
			//this.DGMatchgCourseDetails.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGCourseDetails_ItemDataBound);
			this.DGSubmittedDocs.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGSubmittedDocs_ItemDataBound);

		}
		#endregion

		public void FetchStudentDetails()
		{
//			Session["ElgFormNo"] = null;
//			Session["pk_Year"] = null;
//			Session["pk_Student_ID"]=null;
//			Session["pk_CrMoLrnPtrn_ID"]=null;
			lblEligibilityFormNo.Text = hidElgFormNo.Value.ToString();
			
			//lblEligibilityFormNo.Text = Session["ElgFormNo"].ToString();
		    //string ElgFormNo = Session["ElgFormNo"].ToString();
			string ElgFormNo = hidElgFormNo.Value.ToString();
			
			RefIDarr = ElgFormNo.Split('-');   // UniID = RefIDarr[0], InstID = RefIDarr[1],Year = RefIDarr[2], StudID = RefIDarr[3]
			try
			{
				
				//ds=clsEligibilityDBAccess.Fetch_REG_Pending_Student_Details(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"].ToString()),Convert.ToInt32(Session["pk_Year"].ToString()),Convert.ToInt32(Session["pk_Student_ID"].ToString()),Convert.ToInt32(RefIDarr[1].ToString()),Convert.ToInt32(RefIDarr[0].ToString()),Convert.ToInt32(RefIDarr[2].ToString()),Convert.ToInt32(RefIDarr[3].ToString()),Convert.ToInt32(Session["pk_CrMoLrnPtrn_ID"].ToString()));
				ds=clsEligibilityDBAccess.Fetch_REG_Pending_Student_Details(Convert.ToInt32(UniversityPortal.clsGetSettings.UniversityID.ToString()),Convert.ToInt32(hidpkYear.Value),Convert.ToInt32(hidpkStudentID.Value),Convert.ToInt32(RefIDarr[0].ToString()),Convert.ToInt32(RefIDarr[2].ToString()),Convert.ToInt32(RefIDarr[1].ToString()),Convert.ToInt32(RefIDarr[3].ToString()),Convert.ToInt32(hidCrMoLrnPtrnID.Value));
				//ds=clsEligibilityDBAccess.Fetch_REG_Pending_Student_Details(179,1996,100,179,1996,1,1,1);
				if(ds.Tables[0].Rows.Count>0)
				{
					lblInstName.Text = ds.Tables[0].Rows[0]["RefInstName"].ToString();
					lblPendingReason.Text=ds.Tables[0].Rows[0]["PendingReason"].ToString();
					lblAdmissionDate.Text = ds.Tables[0].Rows[0]["Admission_Date"].ToString();
					lblAppFormNo.Text = ds.Tables[0].Rows[0]["Admission_Form_No"].ToString();
					//lblCourse.Text=ds.Tables[0].Rows[0]["Course"].ToString()+" ("+ds.Tables[0].Rows[0]["CoursePart"].ToString()+")";
					//lblFaculty.Text = ds.Tables[0].Rows[0]["Faculty"].ToString();
					lblCourse.Text=ds.Tables[0].Rows[0]["Course"].ToString()+"-"+ds.Tables[0].Rows[0]["CoursePart"].ToString()+"("+ds.Tables[0].Rows[0]["Faculty"].ToString()+")";
                    hidElgFlag.Value = ds.Tables[0].Rows[0]["Eligibility"].ToString();
                    hidSMSCrAbbr.Value = ds.Tables[0].Rows[0]["CrAbbr"].ToString();
                    if (hidSMSCrAbbr.Value.Length > 9)
                    {
                        hidSMSCrAbbr.Value = hidSMSCrAbbr.Value.Substring(0, 8);
                    }
					
				}

				if(ds.Tables[1].Rows.Count>0)
				{
					lblPapers.Text="<table cellSpacing='0' cellPadding='3' width='100%' align='center' style='BORDER-TOP: silver 1px solid; BORDER-LEFT: silver 1px solid;'>"; //border='1px'
					int j=0;
					for(int i=0;i<ds.Tables[1].Rows.Count;i++)
					{
						if(j==0)
							lblPapers.Text+="<tr>"; //class='rfont'
						lblPapers.Text+="<td style='BORDER-RIGHT: silver 1px solid; BORDER-BOTTOM: silver 1px solid'>"+ds.Tables[1].Rows[i]["PaperCode"].ToString()+"</td>";
						lblPapers.Text+="<td style='BORDER-RIGHT: silver 1px solid; BORDER-BOTTOM: silver 1px solid'>"+ds.Tables[1].Rows[i]["PaperName"].ToString()+"</td>";
						++j;
						if(j==3)
						{
							lblPapers.Text += "</tr>";
							j=0;
						}
					
					}
					lblPapers.Text+="</table>";
				}

				if(ds.Tables[2].Rows.Count>0)
				{
					lblPermRegNo.Text=ds.Tables[2].Rows[0]["PRN"].ToString();
					if(lblPermRegNo.Text=="" || lblPermRegNo.Text==null)
						lblPermRegNo.Text = "Not Generated";
					lblAlumni.Text=ds.Tables[2].Rows[0]["Alumini_Flag"].ToString();
					lblNameOfStudent.Text = ds.Tables[2].Rows[0]["Last_Name"].ToString()+" "+ds.Tables[2].Rows[0]["First_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Middle_Name"].ToString();
					lblMothersMaidenName.Text = ds.Tables[2].Rows[0]["Mother_Last_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Mother_First_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Mother_Middle_Name"].ToString();
					lblFathersName.Text = ds.Tables[2].Rows[0]["Father_Last_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Father_First_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Father_Middle_Name"].ToString();
                    hidSMSFirstName.Value = ds.Tables[2].Rows[0]["First_Name"].ToString();
                    if (hidSMSFirstName.Value.Length > 15)
                    {
                        hidSMSFirstName.Value = hidSMSFirstName.Value.Substring(0, 14);
                    }
					if(ds.Tables[2].Rows[0]["Changed_Name_Flag"].ToString()=="1")
					{
						lblPreviousName.Text = ds.Tables[2].Rows[0]["Prev_Last_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Prev_First_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Prev_Middle_Name"].ToString();
					}
					lblGender.Text = ds.Tables[2].Rows[0]["Gender_Desc"].ToString();
					lblDOB.Text = ds.Tables[2].Rows[0]["DOB"].ToString();                   //Gender,Date_of_Birth,Changed_Name_Reason
					lblNationality.Text = ds.Tables[2].Rows[0]["Nationality"].ToString();
                    hidSMSMobileNumber.Value = ds.Tables[2].Rows[0]["Mobile_Number"].ToString();
				}
			
				if(ds.Tables[3].Rows.Count > 0)
				{
					lblDomicileState.Text = ds.Tables[3].Rows[0]["Domicile_of_State"].ToString();
					lblResvCategory.Text = ds.Tables[3].Rows[0]["Category"].ToString();
					if(ds.Tables[3].Rows[0]["Category_Flag"].ToString()=="1")
					{
						if(ds.Tables[3].Rows[0]["ResvCategory"].ToString() != "")
						{
							lblResvCategory.Text += " ("+ds.Tables[3].Rows[0]["ResvCategory"].ToString();
							if(ds.Tables[3].Rows[0]["SubCaste"].ToString() != "")
								lblResvCategory.Text += " - "+ds.Tables[3].Rows[0]["SubCaste"].ToString();
							lblResvCategory.Text += ")";
						}
					}
					if(ds.Tables[3].Rows[0]["Physically_Challenged_Flag"].ToString() == "1")
						lblPhyChlngd.Text = ds.Tables[3].Rows[0]["PhysicallyChallenged"].ToString();
					else
						lblPhyChlngd.Text = "     -";
					lblGuardianincome.Text = "Rs. "+ds.Tables[3].Rows[0]["Guardian_Annual_Income"].ToString();
					lblGuardianOccupation.Text = ds.Tables[3].Rows[0]["GuardOccupation"].ToString();	                
				}

				if(ds.Tables[4].Rows.Count > 0)
				{
					for(int i=0; i<ds.Tables[4].Rows.Count;i++)
					{
						lblSocResv.Text += ds.Tables[4].Rows[i]["SocialReservation_Description"].ToString();
						if(i < (ds.Tables[4].Rows.Count - 1))
							lblSocResv.Text += ", ";
					}
				}
				if(ds.Tables[5].Rows.Count>0)
				{
					DGQualification.DataSource = ds.Tables[5];
					DGQualification.DataBind();
				}
				if(ds.Tables[6].Rows.Count > 0)
				{
					DGSubmittedDocs.DataSource = ds.Tables[6];
					DGSubmittedDocs.DataBind();
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
                Image1.ImageUrl = "PhotoAndSignTemp.aspx?img=PR&sElgFormNo=" + hidElgFormNo.Value;         
				Image1.Visible=true;
                Image2.ImageUrl = "PhotoAndSignTemp.aspx?img=SR&sElgFormNo=" + hidElgFormNo.Value;         
				Image2.Visible=true;
				divStudentDetails.Style.Add("Display","block");

				//For Proper Display Message of Eligibility Decision
				if(hidElgFlag.Value=="1")
				{
					lblProfileHeading.Text="Candidate "+ds.Tables[2].Rows[0]["First_Name"].ToString() +" is Marked Eligible for the Course : "+ds.Tables[0].Rows[0]["CoursePart"].ToString();
					divPendingReason.Visible=false;
                    divReason.Attributes.Add("style", "display:none");
				}
				else if (hidElgFlag.Value=="2")
				{
					lblProfileHeading.Text="Candidate "+ds.Tables[2].Rows[0]["First_Name"].ToString() +" is Marked Not-Eligible for the Course : "+ds.Tables[0].Rows[0]["CoursePart"].ToString();
					lblEligibilityReason.Text="Not-Eligible due to following reason(s)";
					divPendingReason.Visible=true;
                    rbDefaulter.Checked = true;
                    divReason.Attributes.Add("style", "display:inline");
                    tbReason.Text = ds.Tables[0].Rows[0]["PendingReason"].ToString();
                   
				}
				else if(hidElgFlag.Value=="3")
				{
					lblProfileHeading.Text="Candidate "+ds.Tables[2].Rows[0]["First_Name"].ToString() +" is Marked Pending for the Course : "+ds.Tables[0].Rows[0]["CoursePart"].ToString();
					lblEligibilityReason.Text="Eligibility Kept Pending due to following reason(s)";
					divPendingReason.Visible=true;
                    rbPending.Checked = true;
                    divReason.Attributes.Add("style","display:inline");
                    tbReason.Text = ds.Tables[0].Rows[0]["PendingReason"].ToString();
                    
				}
				//lblGridName.Text ="Candidate "+ds.Tables[2].Rows[0]["First_Name"].ToString() +"'s Matching Other Course  Details ";
				if(ds.Tables[0].Rows.Count > 0)
                    lblStudName.Text = "<br><b> for student <i>" + lblNameOfStudent.Text + "</i> for Course " + ds.Tables[0].Rows[0]["CoursePart"].ToString() + "</b>";
			}
			catch(Exception ex)
			{  
				Response.Write(ex.Message);
				throw new Exception(ex.Message);
			}

			ds.Dispose();

			 
		}		
		private void DGMatchingRecords_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				e.Item.Cells[0].Text=Convert.ToString(e.Item.ItemIndex+1);
			}
		}
		
		private void DGSubmittedDocs_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex+1);
				e.Item.Cells[2].Text = "Recvd (Valid)";
				if(ds.Tables[6].Rows[e.Item.ItemIndex]["RecvdBy_Uni"].ToString() == "1")
				{
					((CheckBox)e.Item.Cells[3].Controls[1]).Checked = true;
					((RadioButton)e.Item.Cells[4].Controls[1]).Enabled = true;
					((RadioButton)e.Item.Cells[4].Controls[3]).Enabled = true;
					if(ds.Tables[6].Rows[e.Item.ItemIndex]["ValidityBy_Uni"].ToString() == "1")
						((RadioButton)e.Item.Cells[4].Controls[1]).Checked = true;
					if(ds.Tables[6].Rows[e.Item.ItemIndex]["ValidityBy_Uni"].ToString() == "0")
						((RadioButton)e.Item.Cells[4].Controls[3]).Checked = true;

				}

			}
		}

		private void DGCourseDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				e.Item.Cells[0].Text=Convert.ToString(e.Item.ItemIndex+1);
				
			}
		}


		protected void btnGoTo_Click(object sender, System.EventArgs e)
		{
			if(Request.QueryString["Search"] == "Simple")
				Server.Transfer("reg_PendingStudentEligibility.aspx?Navigate=back&Search=Simple");
			if(Request.QueryString["Search"] == "Adv")
				Server.Transfer("reg_PendingStudentEligibility.aspx?Navigate=back&Search=Adv");

			
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
            divEligibilityDecision.Style.Add("display", "none");
                
            if (rbPending.Checked == true)
            {
                divPRN.Style.Add("display", "block");
                lblPRN.Text = "<Font color='#c00000' size='3'>Selected record has already been processed for 'Pending Eligible' decision.</font><br>The SMS regarding the same is already been sent to the student.";
            }
            else if(GoToDataBase == 1)
			{
                string sReason = "";
				string PRN,ElgLabel="";
				string flag = "0" ;
				DataSet dsDocs = new DataSet();
				DataRow dr;
				dsDocs.Tables.Add("StudentDocs");
				dsDocs.Tables["StudentDocs"].Columns.Add("fk_Doc_ID");
				dsDocs.Tables["StudentDocs"].Columns.Add("RecvdBy_Uni");
				dsDocs.Tables["StudentDocs"].Columns.Add("ValidityBy_Uni");
				int j=0;
				for(int i=0; i<hidDocXML.Value.Length;i+=2)
				{
					if(hidDocXML.Value[i] == '1')     //if checkbox checked =  true
					{
						dr = dsDocs.Tables["StudentDocs"].NewRow();
						dr["fk_Doc_ID"] = DGSubmittedDocs.Items[j].Cells[5].Text.Trim();
						dr["RecvdBy_Uni"] = '1';
						dr["ValidityBy_Uni"] = hidDocXML.Value[i+1];
						dsDocs.Tables["StudentDocs"].Rows.Add(dr);
					}
					j++;
				}
			
				System.Text.StringBuilder    sb = new System.Text.StringBuilder(1000);    //contains XML fmt of Docs
				System.IO.StringWriter       sw = new System.IO.StringWriter(sb);
				dsDocs.WriteXml(sw,XmlWriteMode.IgnoreSchema);
				//string sbuilder = "";
				//if(sb.Length==14)     //if empty contains "</newdataset>"
				// sb = (System.Text.StringBuilder)null;
				//sb = (System.Text.StringBuilder)Convert.DBNull;   
				if(rbEligible.Checked) //Eligible
				{
                    divReason.Attributes.Add("style", "display:none");
                    flag = "1";
					ElgLabel ="Eligible";
					lblPendingReason.Text="";
                    if (tbReason.Text.ToString().Trim() != "")
                    {
                        sReason = tbReason.Text.ToString().Trim() + "[Resolved]";
                    }
                    else
                    {
                        sReason = tbReason.Text.ToString().Trim()+" - ";
                    }

				}
                else if(rbDefaulter.Checked) //Not Eligible
				{
					flag = "2";
					ElgLabel = "Not Eligible";
                    sReason = tbReason.Text.ToString().Trim(); 
				}
				else if(rbPending.Checked) //Pending
				{
					flag = "3";
					ElgLabel= "Pending";
                    sReason = tbReason.Text.ToString().Trim(); 
				}
                else if (rbProvisional.Checked) //Provisionally Eligible
                {
                    flag = "5";
                    ElgLabel = "Provisionally Eligible";
                    sReason = tbReason.Text.ToString().Trim();
                }
				
				hidElgFlag.Value=flag;
                if (lblPermRegNo.Text == "" || lblPermRegNo.Text == null || lblPermRegNo.Text == "-" || lblPermRegNo.Text == "Not Generated")
					lblPermRegNo.Text="00";
				RefIDarr = hidElgFormNo.Value.Split('-');
				//PRN = clsEligibilityDBAccess.REG_PendingEStudEligibilityDecision(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"].ToString()),Convert.ToInt32(Session["pk_Year"].ToString()),Convert.ToInt32(Session["pk_Student_ID"].ToString()),Convert.ToInt32(Session["pk_CrMoLrnPtrn_ID"].ToString()),flag,sb,tbReason.Text.Trim(),lblPermRegNo.Text.Trim(),userid);
				string[] strArr = new string[2];
				int Error;
                strArr = clsEligibilityDBAccess.REG_PendingStudentEligibilityDecision(Convert.ToInt32(UniversityPortal.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(hidpkYear.Value), Convert.ToInt32(hidpkStudentID.Value), Convert.ToInt32(hidCrMoLrnPtrnID.Value), Convert.ToInt32(RefIDarr[0].ToString()), Convert.ToInt32(RefIDarr[2].ToString()), Convert.ToInt32(RefIDarr[1].ToString()), Convert.ToInt32(RefIDarr[3].ToString()), flag, sb, sReason, lblPermRegNo.Text.Trim(), userid);
				PRN = strArr[0];
				Error = Convert.ToInt32(strArr[1]);
				lblPermRegNo.Text = PRN;
				//FetchStudentDetails();
                clsUser u = (clsUser)Session["User"]; //Added By Saroj on 1st Nov 2007
				if(Error == 0 && flag != "3")
				{
                    string SMSreturn = "";
                    string SMSMessage = "";
                    
                    try
                    {
                        SendSMS objSendSMS = new SendSMS();
					    divPRN.Style.Add("Display","block");	
					    //lblPRN.Text ="The Student is Marked as <br><Font color='red' size='2'>"+ElgLabel+"</font><br> for the Course "+lblCourse.Text +" .";
                        lblPRN.Text = "The Student is Marked as <br><Font color='red' size='2'>" + ElgLabel + "</font><br>";
					    if(flag =="1")
					    {
						    if(lblPermRegNo.Text != "" && lblPermRegNo.Text !="00" && lblPermRegNo.Text != null)
						    {
    					
							    lblPRN.Text +=" The Permanent Registration Number (PRN) for the Student ";
							    lblPRN.Text +="<i>"+lblNameOfStudent.Text+"</i> is <br><Font color='red' size='3'>"+PRN+"</Font><br>Please write PRN on the Admission/Eligibility form.";
                                Cache["PRN"] = lblPRN.Text;
                                Cache["GeneratedPRN"] = PRN;
						    }
						    else
						    {
							    lblPRN.Text +=" \nThe Permanent Registration Number (PRN) for the Student ";
							    lblPRN.Text +="<i>"+lblNameOfStudent.Text+"</i> is same<br><Font color='red' size='3'>"+lblPermRegNo.Text+"</Font><br>Please write PRN on the Admission/Eligibility form.";
                                Cache["PRN"] = lblPRN.Text;
                                Cache["GeneratedPRN"] = PRN;
						    }
                            SMSMessage = "Congrats " + hidSMSFirstName.Value + ",You are eligible for " + hidSMSCrAbbr.Value + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your PRN:" + PRN + ".";
                            objSendSMS.epMessage = SMSMessage;
                            objSendSMS.epUser = u.User_ID;  //Added By Saroj on 1st Nov 2007
					    }
                        else if (flag == "5")
                        {
                            if (PRN != null && PRN != "")
                            {
                                lblPRN.Text = "The Student is Marked as <Font color='red' size='2'><b>" + ElgLabel + "</b></font><br>";
                                lblPRN.Text += "The Permanent Registration Number (PRN) for the Student ";
                                lblPRN.Text += "<b><i>" + lblNameOfStudent.Text + "</i></b> is <br><Font color='#c00000' size='3'>" + PRN + "</Font><br><Font size=2>Please write PRN on the Admission/Eligibility form.</Font>";
                                Cache["PRN"] = lblPRN.Text;
                                Cache["GeneratedPRN"] = PRN;

                                SMSMessage = "Dear " + hidSMSFirstName.Value + ",You are provisionally eligible for " + hidSMSCrAbbr.Value + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your PRN:" + PRN + ". Discrepancy is available in college's login on Digital University Portal of eSuvidha.";
                                objSendSMS.epMessage = SMSMessage;
                                objSendSMS.epUser = u.User_ID;  //Added By Saroj on 1st Nov 2007
                            }
                            else
                            {
                                lblPRN.Text = "System has encountered an error in the registration process. Hence, Registration is failed !!!<br>Please try again later.";

                            }
                        }
                        else if ((flag == "2") || (flag == "3"))
                        {
                            if (lblPermRegNo.Text != "" && lblPermRegNo.Text != "00" && lblPermRegNo.Text != null)
                            {
                                lblPRN.Text += "\nThe Permanent Registration Number (PRN) for the Student ";
                                lblPRN.Text += "<i>" + lblNameOfStudent.Text + "</i> is same<br><Font color='red' size='3'>" + lblPermRegNo.Text + "</Font><br>Please write PRN on the Admission/Eligibility form.";
                                Cache["PRN"] = lblPRN.Text;
                                Cache["GeneratedPRN"] = PRN;
                            }
                            else
                            {
                                lblPRN.Text = "The Student <i>" + lblNameOfStudent.Text + "</i> is marked <br><Font color='#c00000' size='2'>" + ElgLabel + "</Font><br> for the Course " + lblCourse.Text;
                                Cache["PRN"] = lblPRN.Text;
                            }
                            lblPendingReason.Text = tbReason.Text;
                            if (flag == "2")
                            {
                                SMSMessage = "Dear " + hidSMSFirstName.Value + ", You are found ineligible for " + hidSMSCrAbbr.Value + ". For more details contact your college.";
                            }
                            else if (flag == "3")
                            {
                                SMSMessage = "Dear " + hidSMSFirstName.Value + ", your eligibility for " + hidSMSCrAbbr.Value + " is pending. Discrepancy is available in college's login on Digital University Portal of eSuvidha.";
                            }
                            objSendSMS.epMessage = SMSMessage;
                            objSendSMS.epUser = u.User_ID;  //Added By Saroj on 1st Nov 2007
                        }
                        SMSreturn = objSendSMS.SendPersonalizedSMS(hidSMSMobileNumber.Value.Trim(), "ELG" + hidElgFormNo.Value);
                        if (SMSreturn.Substring(0,7) == "Invalid")
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
				else if(Error != 0)
				{
					lblPRN.Text = "System has encountered an error in the registration process. Hence, Registration is failed !!!<br>Please try again later.";
				}
							
				divEligibilityDecision.Attributes.Add("display","none");
				for(int i=0; i<DGSubmittedDocs.Items.Count; i++)
				{
					((CheckBox)DGSubmittedDocs.Items[i].Cells[3].Controls[1]).Enabled = false;
				
				}
				int k=0;
				for(int l=0; l<hidDocXML.Value.Length;l+=2)
				{
					if(hidDocXML.Value[l] == '1')     //if checkbox checked =  true
					{
						
						if(hidDocXML.Value[l+1] == '1')
							((RadioButton)DGSubmittedDocs.Items[k].Cells[4].Controls[1]).Checked = true;
						else
							((RadioButton)DGSubmittedDocs.Items[k].Cells[4].Controls[3]).Checked = true;		
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
                    divReason.Attributes.Add("style","display:none");
                }
                lblPRN.Text = "<Font color='#c00000' size='3'>Selected Record has Already been Processed</font><br>" + Cache["PRN"].ToString();
            }
		}


		
	}
}
