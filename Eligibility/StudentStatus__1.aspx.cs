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
using System.Text.RegularExpressions ;

namespace StudentRegistration.Eligibility
{
	/// <summary>
	/// Summary description for StudentStatus__1.
	/// </summary>
	public partial class StudentStatus__1 : System.Web.UI.Page
	{
		
		
		protected System.Web.UI.WebControls.Label lblFaculty;
		protected System.Web.UI.WebControls.Label lblPapers;
		DataSet ds = new DataSet();
		DataSet matchingrecords=new DataSet();
		DataSet submitteddocs=new DataSet();
		DataSet dsQualn = new DataSet();
		DataSet AdmissionDetails=new DataSet();
		clsUser userob = new clsUser();
		string userid ="";
		//clsCommon Common = new clsCommon();
		string ElgFormNo ;
        clsCommon Common = new clsCommon();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

            Classes.clsCache.NoCache();
			
			userob=(clsUser)Session["User"];
			userid=userob.User_ID.ToString();


			if(!IsPostBack)
			{
                HtmlInputHidden[] hid = new HtmlInputHidden[5];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidElgFormNo;
                hid[3] = hidpkYear;
                hid[4] = hidpkStudentID;

                Common.setHiddenVariables(ref hid);               
                
                StudentStatus ob = (StudentStatus)System.Web.HttpContext.Current.Handler;
				WebCtrl.StudentsStatusSearch tempHidden = (WebCtrl.StudentsStatusSearch)ob.FindControl("StudentsStatusSearch1");
				
				if(Request.QueryString["Search"] == "Simple")
				{
					//hidElgFormNo.Value=((HtmlInputHidden)ob.FindControl("hidElgFormNo")).Value;
					//hidpkYear.Value=((HtmlInputHidden)ob.FindControl("hidpkYear")).Value;
					//hidpkStudentID.Value=((HtmlInputHidden)ob.FindControl("hidpkStudentID")).Value;
					//hidCrMoLrnPtrnID.Value=((HtmlInputHidden)ob.FindControl("hidCrMoLrnPtrnID")).Value;
					//ElgFormNo=ob.ElgFormNo;
					//lblEligibilityFormNo.Text = ElgFormNo;
					hidElgFormNo.Value=ob.ElgFormNo;
					ElgFormNo= hidElgFormNo.Value;
					hidUniID.Value=ob.pk_Uni_ID.ToString();
					hidpkYear.Value=ob.pk_Year.ToString();
					hidpkStudentID.Value=ob.pk_Student_ID.ToString();
					hidPRN.Value=ob.PRN;
					FetchStudentDetails();

				}
				if(Request.QueryString["Search"] == "Adv")
				{
					hidElgFormNo.Value=((HtmlInputHidden)tempHidden.FindControl("hidElgFormNo")).Value;
					hidpkYear.Value=((HtmlInputHidden)tempHidden.FindControl("hidpkYear")).Value;
					hidpkStudentID.Value=((HtmlInputHidden)tempHidden.FindControl("hidpkStudentID")).Value;
					//hidCrMoLrnPtrnID.Value=((HtmlInputHidden)ob.FindControl("hidCrMoLrnPtrnID")).Value;
					FetchStudentDetails1(Convert.ToInt32(UniversityPortal.clsGetSettings.UniversityID),Convert.ToInt32(hidpkYear.Value),Convert.ToInt32(hidpkStudentID.Value));
					
				}
//				hidElgFlag.Value="NotAssigned";		    

                if (hidInstID.Value != "" && hidInstID.Value != null)
                {
                    //hidInstID.Value = Request.QueryString["InstituteID"].ToString().Trim();
                    lblTitle.Text = "View Eligibility Status";
                    Institute.Text = "  for " + Classes.InstituteRepository.InstituteName(hidUniID.Value, hidInstID.Value);
                }
				if(IsPostBack)
				{
					if(Request.QueryString["Search"]=="Simple")
					{
						ElgFormNo= hidElgFormNo.Value;
					}
				}
				
				
			
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
			this.DGMatchgCourseDetails.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGMatchgCourseDetails_PageIndexChanged);
			this.DGMatchgCourseDetails.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGCourseDetails_ItemDataBound);
			this.DGSubmittedDocs.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGSubmittedDocs_ItemDataBound);

		}
		#endregion
        
		#region FetchStudentDetails()

		public void FetchStudentDetails()
		{
		
			string[] RefIDarr = new string[4];
			RefIDarr = ElgFormNo.Split('-');   //Year = RefIDarr[0], UniID = RefIDarr[1], InstID = RefIDarr[2], StudID = RefIDarr[3]
			try
			{
				
				
				ds=clsEligibilityDBAccess.REG_Get_Eligibilitystatusdetails(Convert.ToInt32(hidUniID.Value),Convert.ToInt32(hidpkYear.Value),Convert.ToInt32(hidpkStudentID.Value),Convert.ToInt32(RefIDarr[0].ToString()),Convert.ToInt32(RefIDarr[2].ToString()),Convert.ToInt32(RefIDarr[1].ToString()),Convert.ToInt32(RefIDarr[3].ToString()),hidPRN.Value);
				//ds=clsEligibilityDBAccess.REG_Get_Eligibilitystatusdetails(179,2006,55,179,2000,4,73,null);
				

//				if(ds.Tables[0].Rows.Count>0)
//				{
//					lblPapers.Text="<table id='Tbl2' cellSpacing='0' cellPadding='3' width='100%' border='1px'>";
//					int j=0;
//					for(int i=0;i<ds.Tables[0].Rows.Count;i++)
//					{
//						if(j==0)
//							lblPapers.Text+="<tr class='rfont'>";
//						lblPapers.Text+="<td>"+ds.Tables[1].Rows[i]["PaperCode"].ToString()+"</td>";
//						lblPapers.Text+="<td>"+ds.Tables[1].Rows[i]["PaperName"].ToString()+"</td>";
//						++j;
//						if(j==3)
//						{
//							lblPapers.Text += "</tr>";
//							j=0;
//						}
//					
//					}
//					
//					lblPapers.Text+="</table>";
//				}

				if(ds.Tables[0].Rows.Count>0)
				{
					lblPermRegNo.Text=ds.Tables[0].Rows[0]["PRN"].ToString();
					lblAlumni.Text=ds.Tables[0].Rows[0]["Alumini_Flag"].ToString();
					lblNameOfStudent.Text = ds.Tables[0].Rows[0]["Last_Name"].ToString()+" "+ds.Tables[0].Rows[0]["First_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Middle_Name"].ToString();
					lblMothersMaidenName.Text = ds.Tables[0].Rows[0]["Mother_Last_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Mother_First_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Mother_Middle_Name"].ToString();
					lblFathersName.Text = ds.Tables[0].Rows[0]["Father_Last_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Father_First_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Father_Middle_Name"].ToString();
					if(ds.Tables[0].Rows[0]["Changed_Name_Flag"].ToString()=="1")
					{
						lblPreviousName.Text = ds.Tables[0].Rows[0]["Prev_Last_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Prev_First_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Prev_Middle_Name"].ToString();
					}
					lblGender.Text = ds.Tables[0].Rows[0]["Gender_Desc"].ToString();
					lblDOB.Text = ds.Tables[0].Rows[0]["DOB"].ToString();                   //Gender,Date_of_Birth,Changed_Name_Reason
					lblNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                    lblStudName.Text = "<br><b> for student <i>" + lblNameOfStudent.Text + "</i> for Course " + ds.Tables[6].Rows[0]["CoursePart"].ToString() + "</b>";
				}
			
				if(ds.Tables[1].Rows.Count > 0)
				{
					lblDomicileState.Text = ds.Tables[1].Rows[0]["Domicile_of_State"].ToString();
					lblResvCategory.Text = ds.Tables[1].Rows[0]["Category"].ToString();
					if(ds.Tables[1].Rows[0]["Category_Flag"].ToString()=="1")
					{
						if(ds.Tables[1].Rows[0]["ResvCategory"].ToString() != "")
						{
							lblResvCategory.Text += " ("+ds.Tables[1].Rows[0]["ResvCategory"].ToString();
							if(ds.Tables[1].Rows[0]["SubCaste"].ToString() != "")
								lblResvCategory.Text += " - "+ds.Tables[1].Rows[0]["SubCaste"].ToString();
							lblResvCategory.Text += ")";
						}
					}
					if(ds.Tables[1].Rows[0]["Physically_Challenged_Flag"].ToString() == "1")
						lblPhyChlngd.Text = ds.Tables[1].Rows[0]["PhysicallyChallenged"].ToString();
					else
						lblPhyChlngd.Text = "     -";
					lblGuardianincome.Text = "Rs. "+ds.Tables[1].Rows[0]["Guardian_Annual_Income"].ToString();
					lblGuardianOccupation.Text = ds.Tables[1].Rows[0]["GuardOccupation"].ToString();	                
				}

				if(ds.Tables[2].Rows.Count > 0)
				{
					for(int i=0; i<ds.Tables[2].Rows.Count;i++)
					{
						lblSocResv.Text += ds.Tables[2].Rows[i]["SocialReservation_Description"].ToString();
						if(i < (ds.Tables[2].Rows.Count - 1))
							lblSocResv.Text += ", ";
					}
				}
				if(ds.Tables[3].Rows.Count>0)
				{
					DGQualification.DataSource = ds.Tables[3];
					DGQualification.DataBind();
				}
				if(ds.Tables[4].Rows.Count > 0)
				{
					DGSubmittedDocs.DataSource = ds.Tables[4];
					DGSubmittedDocs.DataBind();
				}
				//IF there are any Matching Records    This functionality is commented to supress 
                                                        //the logic of duplicate erecord checking
                //if(ds.Tables[5].Rows.Count>0)
                //{  
					
                //    divMatchingRecords.Style.Add("display","block");
                //    //lblEligibilityFormNo.Text=ds.Tables[5].Rows[0]["ElgFormNo"].ToString() ;
                //    DGMatchgCourseDetails.DataSource=ds.Tables[5];
                //    DGMatchgCourseDetails.DataBind();
                //}
                //else
                //{
					
                //    divMatchingRecords.Style.Add("display","none");
                //}
				
                //if((hidPRN.Value==null)||(hidPRN.Value==""))
                //{
					if(ds.Tables[6].Rows.Count>0) 
					{
						lblInstName.Text = ds.Tables[6].Rows[0]["RefInstName"].ToString();
						lblElgReason.Text=ds.Tables[6].Rows[0]["Reason"].ToString();
						lblElgStatus.Text=ds.Tables[6].Rows[0]["EligibilityStatus"].ToString();
						lblEligibilityFormNo.Text=ds.Tables[6].Rows[0]["ElgFormNo"].ToString() ;
						TblAdmission.Style.Remove("display");
						TblAdmission.Style.Add("display","block");
						divTblElgFormdetails.Style.Remove("display");
						divTblElgFormdetails.Style.Add("display","block");
						lblAdmissionDate.Text = ds.Tables[6].Rows[0]["Admission_Date"].ToString();
						lblAppFormNo.Text = ds.Tables[6].Rows[0]["Admission_Form_No"].ToString();
						//lblCourse.Text=ds.Tables[6].Rows[0]["Course"].ToString()+" ("+ds.Tables[6].Rows[0]["CoursePart"].ToString()+")";
						//lblFaculty.Text = ds.Tables[6].Rows[0]["Faculty"].ToString();
						//lblCourse.Text=ds.Tables[6].Rows[0]["Course"].ToString()+"-"+ds.Tables[6].Rows[0]["CoursePart"].ToString()+"("+ds.Tables[6].Rows[0]["Faculty"].ToString()+")";
						lblCourse.Text=ds.Tables[6].Rows[0]["Course"].ToString()+"("+ds.Tables[6].Rows[0]["Faculty"].ToString()+")";
						
					
					
					}
                //}
                //else
                //if((hidPRN.Value!=null) && (hidPRN.Value!=""))
                //{
                //    TblAdmission.Style.Remove("display");
                //    TblAdmission.Style.Add("display","none");
                //    divTblElgFormdetails.Style.Remove("display");
                //    divTblElgFormdetails.Style.Add("display","none");
                //    lblGridName.Text="Course Eligibility Status";
                //}
				hidDocCnt.Value = ds.Tables[4].Rows.Count.ToString();
                Image1.ImageUrl = "PhotoAndSignTemp.aspx?img=PR&sElgFormNo=" + hidElgFormNo.Value;         
				Image1.Visible=true;
                Image2.ImageUrl = "PhotoAndSignTemp.aspx?img=SR&sElgFormNo=" + hidElgFormNo.Value;         
				Image2.Visible=true;
				//divStudentDetails.Style.Add("Display","block");
				//For Proper Display Message of Eligibility Decision
				
				//lblGridName.Text ="Candidate "+ds.Tables[2].Rows[0]["First_Name"].ToString() +"'s Matching Other Course  Details ";
				//if(ds.Tables[0].Rows.Count > 0)
				//	lblTitle.Text += "<font color='black'> of <i>"+lblNameOfStudent.Text+"</i> for Course "+ds.Tables[0].Rows[0]["CoursePart"].ToString()+"</font>";
			}
			catch(Exception ex)
			{  
				Response.Write(ex.Message);
				throw new Exception(ex.Message);
			}

			ds.Dispose();

			 
		}
		

		#endregion
		
		
		#region FetchStudentDetails1(int pk_Uni_ID, int pk_Year,int pk_Student_ID)
		public  void FetchStudentDetails1(int pk_Uni_ID, int pk_Year,int pk_Student_ID)
		{
			try
			{
                ds = clsEligibilityDBAccess.Elg_AdvSearch_StudentEligibilityDetails(pk_Uni_ID, pk_Year, pk_Student_ID, hidPRN.Value);
				
				divTblElgFormdetails.Style.Remove("display");
				divTblElgFormdetails.Style.Add("display","none");

				if(ds.Tables[0].Rows.Count>0)
				
				{	Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");
						if(!objNotNaturalPattern.IsMatch(ds.Tables[0].Rows[0]["PRN"].ToString()))
					 lblPermRegNo.Text="Not Generated";
					 else
					 lblPermRegNo.Text=ds.Tables[0].Rows[0]["PRN"].ToString();
					
					lblAlumni.Text=ds.Tables[0].Rows[0]["Alumini_Flag"].ToString();
					lblNameOfStudent.Text = ds.Tables[0].Rows[0]["Last_Name"].ToString()+" "+ds.Tables[0].Rows[0]["First_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Middle_Name"].ToString();
					lblMothersMaidenName.Text = ds.Tables[0].Rows[0]["Mother_Last_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Mother_First_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Mother_Middle_Name"].ToString();
					lblFathersName.Text = ds.Tables[0].Rows[0]["Father_Last_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Father_First_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Father_Middle_Name"].ToString();
					if(ds.Tables[0].Rows[0]["Changed_Name_Flag"].ToString()=="1")
					{
						lblPreviousName.Text = ds.Tables[0].Rows[0]["Prev_Last_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Prev_First_Name"].ToString()+" "+ds.Tables[0].Rows[0]["Prev_Middle_Name"].ToString();
					}
					lblGender.Text = ds.Tables[0].Rows[0]["Gender_Desc"].ToString();
					lblDOB.Text = ds.Tables[0].Rows[0]["DOB"].ToString();                   //Gender,Date_of_Birth,Changed_Name_Reason
					lblNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();

				}
			
				if(ds.Tables[1].Rows.Count > 0)
				{
					lblDomicileState.Text = ds.Tables[1].Rows[0]["Domicile_of_State"].ToString();
					lblResvCategory.Text = ds.Tables[1].Rows[0]["Category"].ToString();
					if(ds.Tables[1].Rows[0]["Category_Flag"].ToString()=="1")
					{
						if(ds.Tables[1].Rows[0]["ResvCategory"].ToString() != "")
						{
							lblResvCategory.Text += " ("+ds.Tables[1].Rows[0]["ResvCategory"].ToString();
							if(ds.Tables[1].Rows[0]["SubCaste"].ToString() != "")
								lblResvCategory.Text += " - "+ds.Tables[1].Rows[0]["SubCaste"].ToString();
							lblResvCategory.Text += ")";
						}
					}
					if(ds.Tables[1].Rows[0]["Physically_Challenged_Flag"].ToString() == "1")
						lblPhyChlngd.Text = ds.Tables[1].Rows[0]["PhysicallyChallenged"].ToString();
					else
						lblPhyChlngd.Text = "     -";
					lblGuardianincome.Text ="Rs. "+ds.Tables[1].Rows[0]["Guardian_Annual_Income"].ToString();
					lblGuardianOccupation.Text = ds.Tables[1].Rows[0]["GuardOccupation"].ToString();	                
				}

				if(ds.Tables[2].Rows.Count > 0)
				{
					for(int i=0; i<ds.Tables[2].Rows.Count;i++)
					{
						lblSocResv.Text += ds.Tables[2].Rows[i]["SocialReservation_Description"].ToString();
						if(i < (ds.Tables[2].Rows.Count - 1))
							lblSocResv.Text += ", ";
					}
				}
				if(ds.Tables[3].Rows.Count>0)
				{
					DGQualification.DataSource = ds.Tables[3];
					DGQualification.DataBind();
				}
				if(ds.Tables[4].Rows.Count > 0)
				{
					DGSubmittedDocs.DataSource = ds.Tables[4];
					DGSubmittedDocs.DataBind();
				}
				//IF there are any Matching Records
                //if(ds.Tables[5].Rows.Count>0)
                //{  
					
                //    divMatchingRecords.Style.Add("display","block");
                //    //lblEligibilityFormNo.Text=ds.Tables[5].Rows[0]["ElgFormNo"].ToString() ;
                //    DGMatchgCourseDetails.DataSource=ds.Tables[5];
                //    DGMatchgCourseDetails.DataBind();
                //}
                //else
                //{
					
                //    divMatchingRecords.Style.Add("display","none");
                //}
                //if ((hidPRN.Value == null) || (hidPRN.Value == ""))
                //{
                    if (ds.Tables[6].Rows.Count > 0)
                    {
                        lblInstName.Text = ds.Tables[6].Rows[0]["RefInstName"].ToString();
                        lblElgReason.Text = ds.Tables[6].Rows[0]["Reason"].ToString();
                        lblElgStatus.Text = ds.Tables[6].Rows[0]["EligibilityStatus"].ToString();
                        lblEligibilityFormNo.Text = ds.Tables[6].Rows[0]["ElgFormNo"].ToString();
                        TblAdmission.Style.Remove("display");
                        TblAdmission.Style.Add("display", "block");
                        divTblElgFormdetails.Style.Remove("display");
                        divTblElgFormdetails.Style.Add("display", "block");
                        lblAdmissionDate.Text = ds.Tables[6].Rows[0]["Admission_Date"].ToString();
                        lblAppFormNo.Text = ds.Tables[6].Rows[0]["Admission_Form_No"].ToString();
                        //lblCourse.Text=ds.Tables[6].Rows[0]["Course"].ToString()+" ("+ds.Tables[6].Rows[0]["CoursePart"].ToString()+")";
                        //lblFaculty.Text = ds.Tables[6].Rows[0]["Faculty"].ToString();
                        //lblCourse.Text=ds.Tables[6].Rows[0]["Course"].ToString()+"-"+ds.Tables[6].Rows[0]["CoursePart"].ToString()+"("+ds.Tables[6].Rows[0]["Faculty"].ToString()+")";
                        lblCourse.Text = ds.Tables[6].Rows[0]["Course"].ToString() + "(" + ds.Tables[6].Rows[0]["Faculty"].ToString() + ")";



                    }
                //}
                //else
                //    if ((hidPRN.Value != null) && (hidPRN.Value != ""))
                //    {
                //        TblAdmission.Style.Remove("display");
                //        TblAdmission.Style.Add("display", "none");
                //        divTblElgFormdetails.Style.Remove("display");
                //        divTblElgFormdetails.Style.Add("display", "none");
                //        lblGridName.Text = "Course Eligibility Status";
                //    }
               
				hidDocCnt.Value = ds.Tables[4].Rows.Count.ToString();
                Image1.ImageUrl = "PhotoAndSignTemp.aspx?img=PR&sElgFormNo=" + hidElgFormNo.Value;         
				Image1.Visible=true;
                Image2.ImageUrl = "PhotoAndSignTemp.aspx?img=SR&sElgFormNo=" + hidElgFormNo.Value;         
				Image2.Visible=true;

                lblStudName.Text = "<br><b> for student <i>" + lblNameOfStudent.Text + "</i> for Course " + ds.Tables[6].Rows[0]["CoursePart"].ToString() + "</b>";

				//divStudentDetails.Style.Add("Display","block");
				//For Proper Display Message of Eligibility Decision
				
				//lblGridName.Text ="Candidate "+ds.Tables[2].Rows[0]["First_Name"].ToString() +"'s Matching Other Course  Details ";
				//if(ds.Tables[0].Rows.Count > 0)
				//	lblTitle.Text += "<font color='black'> of <i>"+lblNameOfStudent.Text+"</i> for Course "+ds.Tables[0].Rows[0]["CoursePart"].ToString()+"</font>";
			}
			catch(Exception ex)
			{  
				Response.Write(ex.Message);
				throw new Exception(ex.Message);
			}

			ds.Dispose();

		
		 }
		#endregion
		
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
				if(ds.Tables[4].Rows[e.Item.ItemIndex]["RecvdBy_Uni"].ToString() == "1")
				{
					((CheckBox)e.Item.Cells[3].Controls[1]).Checked = true;
					((RadioButton)e.Item.Cells[4].Controls[1]).Enabled = false;
					((RadioButton)e.Item.Cells[4].Controls[3]).Enabled = false;
					if(ds.Tables[4].Rows[e.Item.ItemIndex]["ValidityBy_Uni"].ToString() == "1")
						((RadioButton)e.Item.Cells[4].Controls[1]).Checked = true;
					if(ds.Tables[4].Rows[e.Item.ItemIndex]["ValidityBy_Uni"].ToString() == "0")
						((RadioButton)e.Item.Cells[4].Controls[3]).Checked = true;

				}

			}
		}

		private void DGCourseDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				e.Item.Cells[0].Text=Convert.ToString(e.Item.ItemIndex+1);
				if(ds.Tables[5].Rows[e.Item.ItemIndex]["Reason"].ToString()==""||ds.Tables[5].Rows[e.Item.ItemIndex]["Reason"].ToString()==null)
				{
				 e.Item.Cells[5].Text="-";
				}
				
			}
		}


		protected void btnGoTo_Click(object sender, System.EventArgs e)
		{
			if(Request.QueryString["Search"] == "Simple")
				Server.Transfer("StudentStatus.aspx?Navigate=back&Search=Simple");
			if(Request.QueryString["Search"] == "Adv")
				Server.Transfer("StudentStatus.aspx?Navigate=back&Search=Adv");

			
		}

		private void DGMatchgCourseDetails_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGMatchgCourseDetails.CurrentPageIndex=e.NewPageIndex;
//			if(Request.QueryString["Search"] == "Adv")
//			{
//				FetchStudentDetails1(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"]),Convert.ToInt32(hidpkYear.Value),Convert.ToInt32(hidpkStudentID.Value));
//			}
//			if(Request.QueryString["Search"] == "Simple")
//			{
//				//FetchStudentDetails();
//				FetchStudentDetails1(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"]),Convert.ToInt32(hidpkYear.Value),Convert.ToInt32(hidpkStudentID.Value));
//			}

		}

		
		

		
		
		
	}
}
