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
namespace StudentRegistration.Eligibility
{
	/// <summary>
	/// Summary description for Elg_bulkProcessing__1.
	/// </summary>
	public partial class Elg_bulkProcessing__1 : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl divDuplicateProfile;
		DataSet matchingrecords=new DataSet();
		DataSet submitteddocs=new DataSet();
		protected System.Web.UI.WebControls.Label lblElgDecision;
		DataSet dsQualn = new DataSet();
		clsUser userob = new clsUser();
		protected System.Web.UI.WebControls.DataGrid DGMCourseDetails;
		protected System.Web.UI.WebControls.Image ImageM1;
		protected System.Web.UI.WebControls.Image ImageM2;
		protected System.Web.UI.WebControls.DataGrid DGMQualification;
		protected System.Web.UI.WebControls.DataGrid DGMSubmittedDocs;
		string userid ="";
		DataSet ds;//fetch matching records
		int GoToDataBase;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            Classes.clsCache.NoCache();
			//Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.IA_StudentEligibility__1));
			Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods),this.Page);
			
			
			if(Request.QueryString["Search"] == "Simple")
				btnGoTo.Text="Go To Search";
			else            // Search == "Adv"
				btnGoTo.Text="Go To Student List";

			rbEligible.Attributes.Add("onclick","fnDisplayDiv();");
			rbDefaulter.Attributes.Add("onclick","fnDisplayDiv();");
			rbPending.Attributes.Add("onclick","fnDisplayDiv();");
			btnSubmit.Attributes.Add("onclick","return fnConfirm();");
			//Getting UserID
			userob=(clsUser)Session["User"];
			userid=userob.User_ID.ToString();
			if(!IsPostBack)
			{
				IA_StudentEligibility  ob =(IA_StudentEligibility)System.Web.HttpContext.Current.Handler;
				WebCtrl.StudentsAdvancedSearch  tempHidden=(WebCtrl.StudentsAdvancedSearch )ob.FindControl("StudentsAdvancedSearch1");
				if(Request.QueryString["Search"] == "Adv")
				{
					hidElgFormNo.Value=((HtmlInputHidden)tempHidden.FindControl("hidElgFormNo")).Value;
					hidCrMoLrnPtrnID.Value=((HtmlInputHidden)tempHidden.FindControl("hidCrMoLrnPtrnID")).Value;
				}
				if(Request.QueryString["Search"] == "Simple")
				{
					hidElgFormNo.Value=((HtmlInputHidden)ob.FindControl("hidElgFormNo")).Value;
				}
				FetchStudentDetails();
				GoToDataBase = 1;
				Session["GoToDataBase"] = GoToDataBase;
			}
			else if(IsPostBack)
			{
				GoToDataBase = Convert.ToInt32(Session["GoToDataBase"].ToString());
				Image1.ImageUrl = "PhotoAndSignTemp.aspx?img=PSession";         
				Image2.ImageUrl = "PhotoAndSignTemp.aspx?img=SSession";         
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
			this.DGMatchingRecords.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGMatchingRecords_ItemDataBound);
			this.DGSubmittedDocs.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGSubmittedDocs_ItemDataBound);

		}
		#endregion

		

		private void DGSubmittedDocs_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex+1);
				e.Item.Cells[2].Text = "Recvd (Valid)";
			}
		}

		

		protected void btnGoTo_Click(object sender, System.EventArgs e)
		{
			if(Request.QueryString["Search"] == "Simple")
				Response.Redirect("IA_StudentEligibility.aspx?Navigate=back&Search=Simple");
			if(Request.QueryString["Search"] == "Adv")
				Response.Redirect("IA_StudentEligibility.aspx?Navigate=back&Search=Adv");

		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if(GoToDataBase == 1)
			{
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
				//			if(sb.Length==14)     //if empty contains "</newdataset>"
				//				sb = null;         
			
				int flag;
				flag = SubmitTypeCheck();
				string PRN;
				//string ElgFormNo = Session["ElgFormNo"].ToString();
				string ElgFormNo = hidElgFormNo.Value;
				string[] arr = new string[4];
				arr = ElgFormNo.Split('-');   //Ref_Year = arr[0], Ref_UniID = arr[1], ref_InstID = arr[2], Ref_StudID = arr[3]
			
				string ElgDecision = "-1";
				string ElgDescription="";
				if(rbEligible.Checked == true)
				{
					ElgDecision = "0";
					ElgDescription="Eligible";
				}
				else if(rbDefaulter.Checked == true)
				{
					ElgDecision = "1";
					ElgDescription="Not Eligible";
				}
				else if(rbPending.Checked == true)
				{
					ElgDecision = "2";
					ElgDescription="Pending Eligible";
				}

				if(flag == -1)      // fresh record submit
				{
					string[] strArr = new string[2];
					int Error;
					strArr = clsEligibilityDBAccess.Register_Fresh_Student(arr[0],arr[2],arr[1],arr[3],ElgDecision,tbReason.Text.ToString(),hidCrMoLrnPtrnID.Value,userid,sb);
					PRN = strArr[0];
					Error = Convert.ToInt32(strArr[1]);
					if(Error == 0)
					{
						if(ElgDecision=="0")   // Eligible
						{
							if(PRN != null && PRN != "")
							{
								lblPRN.Text="The Permanent Registration Number (PRN) for the Student ";
								lblPRN.Text +="<i>"+lblNameOfStudent.Text+"</i> is <br><Font color='#c00000' size='3'>"+PRN+"</Font><br>Please write PRN on the Admission/Eligibility form.";
							}
							else
							{
								lblPRN.Text = "System has encountered an error in the registration process. Hence, Registration is failed !!!<br>Please try again later.";
							}
						}
						else        //Not Eligible or Pending Eligible
						{
							lblPRN.Text="The Student <i>"+lblNameOfStudent.Text+"</i> is marked <br><Font color='#c00000' size='2'>"+ElgDescription+"</Font><br> for the Course "+lblCourse.Text;
						}
					}
					else if(Error != 0)
					{
						lblPRN.Text = "System has encountered an error in the registration process. Hence, Registration is failed !!!<br>Please try again later.";
					}
				}
				else				// association with the matching record
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
					strArr = clsEligibilityDBAccess.Associate_Student_With_Course(UniversityPortal.clsGetSettings.UniversityID.ToString(),DGMatchingRecords.Items[flag].Cells[8].Text.ToString().Trim(),DGMatchingRecords.Items[flag].Cells[9].Text.ToString().Trim(),arr[0],arr[2],arr[1],arr[3],ElgDecision,tbReason.Text.ToString(),hidCrMoLrnPtrnID.Value,userid,sb,ExistingPRN);
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
								if(ElgDecision=="0")           // Eligible
								{
									if(PRN != null && PRN != "")
										lblPRN.Text="The Student with PRN <Font color='#c00000' size='2'>"+PRN+"</Font> is now associated and marked <br><Font color='#c00000' size='2'>"+ElgDescription+"</font><br> for the Course "+lblCourse.Text;
									else
										lblPRN.Text = "System has encountered an error in the registration process. Hence, Registration is failed !!!<br>Please try again later.";
								   
								}
								
									// Not Eligible or Pending Eligible
								else if(ElgDecision=="1" || ElgDecision=="2")
									lblPRN.Text="The Student is now associated and marked <br><Font color='#c00000' size='2'>"+ElgDescription+"</font><br> for the Course "+lblCourse.Text;
							}
						}
					}
					else if(Error != 0)
					{
						lblPRN.Text = "System has encountered an error in the registration process. Hence, Registration is failed !!!<br>Please try again later.";
					}
				}
				
			
				divPRN.Style.Add("display","block");
				divEligibilityDecision.Style.Add("display","none");
				for(int i=0; i<DGSubmittedDocs.Items.Count; i++)
				{
					((CheckBox)DGSubmittedDocs.Items[i].Cells[3].Controls[1]).Enabled = false;
				
				}
				for(int i=0; i<DGMatchingRecords.Items.Count; i++)
				{
					((CheckBox)DGMatchingRecords.Items[i].Cells[7].Controls[1]).Enabled = false;
				
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
				GoToDataBase = 0;
				Session["GoToDataBase"] = GoToDataBase;
			}
		
		}

		public int SubmitTypeCheck()
		{
			int flag = -1;
			if(DGMatchingRecords.Items.Count>0)
			{
				for(int i=0; i<DGMatchingRecords.Items.Count; i++)
				{
					if(((CheckBox)DGMatchingRecords.Items[i].Cells[7].Controls[1]).Checked == true)
					{
						flag = i;
					}
				}
			}
			return flag;    //-1 = fresh record submit, i = association with above matching record
		}

		#region Fetch Student Profile from IA
		public void FetchStudentDetails()
		{
			
			trChangedName.Style.Add("display","none");
			//lblEligibilityFormNo.Text = Session["ElgFormNo"].ToString();
			lblEligibilityFormNo.Text= hidElgFormNo.Value;
			//string ElgFormNo = Session["ElgFormNo"].ToString();
			string ElgFormNo = hidElgFormNo.Value;
			string[] arr = new string[4];
			arr = ElgFormNo.Split('-');   //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
			ds = new DataSet();
			try
			{
				ds=elgDBAccess.IA_Fetch_Student_Details(arr[2],ConfigurationSettings.AppSettings["UniversityID"].ToString(),arr[1],arr[3]);
				if(ds.Tables[0].Rows.Count>0)
				{
					lblAdmissionDate.Text = ds.Tables[0].Rows[0]["Admission_Date"].ToString();
					lblAppFormNo.Text = ds.Tables[0].Rows[0]["Admission_Form_No"].ToString();
					lblCourse.Text=ds.Tables[0].Rows[0]["Course"].ToString()+"-"+ds.Tables[0].Rows[0]["CoursePart"].ToString()+"("+ds.Tables[0].Rows[0]["Faculty"].ToString()+")";
					//lblFaculty.Text = ds.Tables[0].Rows[0]["Faculty"].ToString();
					lblInstName.Text=ds.Tables[0].Rows[0]["InstName"].ToString();
					hidCrMoLrnPtrnID.Value = ds.Tables[0].Rows[0]["pk_CrMoLrnPtrn_ID"].ToString();
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
					lblNameOfStudent.Text = ds.Tables[2].Rows[0]["Last_Name"].ToString()+" "+ds.Tables[2].Rows[0]["First_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Middle_Name"].ToString();
					//Giving Title
					lblTitle.Text=" of "+" <i>"+lblNameOfStudent.Text+"</i>"+" for Course "+ds.Tables[0].Rows[0]["CoursePart"].ToString();
					lblMothersMaidenName.Text = ds.Tables[2].Rows[0]["Mother_Last_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Mother_First_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Mother_Middle_Name"].ToString();
					lblFathersName.Text = ds.Tables[2].Rows[0]["Father_Last_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Father_First_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Father_Middle_Name"].ToString();
					if(ds.Tables[2].Rows[0]["Changed_Name_Flag"].ToString()=="1")
					{
						lblPreviousName.Text = ds.Tables[2].Rows[0]["Prev_Last_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Prev_First_Name"].ToString()+" "+ds.Tables[2].Rows[0]["Prev_Middle_Name"].ToString();
						trChangedName.Style.Add("display","block");
					}
					lblGender.Text = ds.Tables[2].Rows[0]["Gender_Desc"].ToString();
					lblDOB.Text = ds.Tables[2].Rows[0]["DOB"].ToString();                   //Gender,Date_of_Birth,Changed_Name_Reason
					lblNationality.Text = ds.Tables[2].Rows[0]["Nationality"].ToString();
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
				else
				{
					lblDoctext.Text="NO documents submitted.";
					lblDoctext.Visible=true;
				}
				if(ds.Tables[7].Rows.Count > 0)
				{
					DGMatchingRecords.DataSource = ds.Tables[7];
					DGMatchingRecords.DataBind();
					divMatchingRecords.Style.Add("display","block");
				}
				hidMatchingRecCount.Value = ds.Tables[7].Rows.Count.ToString();
				hidDocCnt.Value = ds.Tables[6].Rows.Count.ToString();
				Image1.ImageUrl = "PhotoAndSignTemp.aspx?img=PI";         
				Image1.Visible=true;
				Image2.ImageUrl = "PhotoAndSignTemp.aspx?img=SI";         
				Image2.Visible=true;
					
				divStudentDetails.Style.Add("Display","block");
				
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}

			ds.Dispose();
		}
		#endregion

		private void DGMatchingRecords_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if(e.Item.ItemType!=ListItemType.Header && e.Item.ItemType!=ListItemType.Footer)
			{
				e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + 1);
				string pk_Uni_ID = UniversityPortal.clsGetSettings.UniversityID.ToString();
				string pk_Year =  ds.Tables[7].Rows[e.Item.ItemIndex]["pkYear"].ToString();
				string pk_Student_ID =  ds.Tables[7].Rows[e.Item.ItemIndex]["pkStudentID"].ToString();
				((Label)e.Item.Cells[1].Controls[1]).Attributes.Add("onclick","fnFetchMatchingProfile("+pk_Uni_ID+","+pk_Year+","+pk_Student_ID+");");
				
			}
		}

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
		#region Not In Use
		public void FetchMStudentDetails(int pk_Uni_ID, int pk_Year, int pk_Student_ID)
		{
			
			trMChangedName.Style.Add("display","none");
			DataSet ds = new DataSet();
			try
			{
				
				
				ds=clsEligibilityDBAccess.Fetch_IAMatchingREG_StudentDetails(pk_Uni_ID,pk_Year,pk_Student_ID);
				if(ds.Tables[0].Rows.Count>0)
				{
					
					DGMCourseDetails.DataSource=ds.Tables[0];
					DGMCourseDetails.DataBind();
									
				}

				if(ds.Tables[1].Rows.Count>0)
				{
					lblMPRN.Text=ds.Tables[1].Rows[0]["PRN"].ToString();
					lblMAlumni.Text=ds.Tables[1].Rows[0]["Alumini_Flag"].ToString();
					lblMNameOfStudent.Text = ds.Tables[1].Rows[0]["Last_Name"].ToString()+" "+ds.Tables[1].Rows[0]["First_Name"].ToString()+" "+ds.Tables[1].Rows[0]["Middle_Name"].ToString();
					lblMMothersMaidenName.Text = ds.Tables[1].Rows[0]["Mother_Last_Name"].ToString()+" "+ds.Tables[1].Rows[0]["Mother_First_Name"].ToString()+" "+ds.Tables[1].Rows[0]["Mother_Middle_Name"].ToString();
					lblMFathersName.Text = ds.Tables[1].Rows[0]["Father_Last_Name"].ToString()+" "+ds.Tables[1].Rows[0]["Father_First_Name"].ToString()+" "+ds.Tables[1].Rows[0]["Father_Middle_Name"].ToString();
					if(ds.Tables[1].Rows[0]["Changed_Name_Flag"].ToString()=="1")
					{
						lblMPreviousName.Text = ds.Tables[1].Rows[0]["Prev_Last_Name"].ToString()+" "+ds.Tables[1].Rows[0]["Prev_First_Name"].ToString()+" "+ds.Tables[1].Rows[0]["Prev_Middle_Name"].ToString();
						trMChangedName.Style.Add("display","block");
					}
					lblMGender.Text = ds.Tables[1].Rows[0]["Gender_Desc"].ToString();
					lblMDOB.Text = ds.Tables[1].Rows[0]["DOB"].ToString();                   //Gender,Date_of_Birth,Changed_Name_Reason
					lblMNationality.Text = ds.Tables[1].Rows[0]["Nationality"].ToString();
				}
			
				if(ds.Tables[2].Rows.Count > 0)
				{
					lblMDomicileState.Text = ds.Tables[2].Rows[0]["Domicile_of_State"].ToString();
					lblMResvCategory.Text = ds.Tables[2].Rows[0]["Category"].ToString();
					if(ds.Tables[2].Rows[0]["Category_Flag"].ToString()=="1")
					{
						if(ds.Tables[2].Rows[0]["ResvCategory"].ToString() != "")
						{
							lblMResvCategory.Text += " ("+ds.Tables[2].Rows[0]["ResvCategory"].ToString();
							if(ds.Tables[2].Rows[0]["SubCaste"].ToString() != "")
								lblMResvCategory.Text += " - "+ds.Tables[2].Rows[0]["SubCaste"].ToString();
							lblMResvCategory.Text += ")";
						}
					}
					if(ds.Tables[2].Rows[0]["Physically_Challenged_Flag"].ToString() == "1")
						lblMPhyChlngd.Text = ds.Tables[2].Rows[0]["PhysicallyChallenged"].ToString();
					else
						lblMPhyChlngd.Text = "     -";
					lblMGuardianincome.Text = ds.Tables[2].Rows[0]["Guardian_Annual_Income"].ToString();
					lblMGuardianOccupation.Text = ds.Tables[2].Rows[0]["GuardOccupation"].ToString();	                
				}

				if(ds.Tables[3].Rows.Count > 0)
				{
					for(int i=0; i<ds.Tables[3].Rows.Count;i++)
					{
						lblMSocResv.Text += ds.Tables[3].Rows[i]["SocialReservation_Description"].ToString();
						if(i < (ds.Tables[3].Rows.Count - 1))
							lblMSocResv.Text += ", ";
					}
				}
				if(ds.Tables[4].Rows.Count>0)
				{
					DGMQualification.DataSource = ds.Tables[4];
					DGMQualification.DataBind();
				}
				if(ds.Tables[5].Rows.Count > 0)
				{
					DGMSubmittedDocs.DataSource = ds.Tables[5];
					DGMSubmittedDocs.DataBind();
				}
				
				ImageM1.ImageUrl = "PhotoAndSignTemp.aspx?img=PR";         
				ImageM1.Visible=true;
				ImageM2.ImageUrl = "PhotoAndSignTemp.aspx?img=SR";         
				ImageM2.Visible=true;
					
				divMStudentDetails.Style.Add("Display","block");
				
			}
			catch(Exception ex)
			{  
				Response.Write(ex.Message);
				throw new Exception(ex.Message);
			}

			ds.Dispose();
		}
		#endregion
			

		#region Ajax Methods

		[Ajax.AjaxMethod()]

		public DataSet FetchMatchingProfile(int pk_Uni_ID,int pk_Year,int pk_Student_ID)
		{
			DataSet ds=new DataSet();

			try
			{
				ds=clsEligibilityDBAccess.Fetch_IAMatchingREG_StudentDetails(pk_Uni_ID,pk_Year,pk_Student_ID);
			}
			catch(Exception ex)
			{  
				Response.Write(ex.Message);
				throw new Exception(ex.Message);
			}
			return ds;

		}

		#endregion
		



		

	}
}
