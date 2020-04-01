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

namespace StudentRegistration.Eligibility
{
	/// <summary>
	/// Summary description for IA_StudentEligibility__3.
	/// </summary>
	public class IA_StudentEligibility__3 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMProfileHeading;
		protected System.Web.UI.WebControls.Label lblMPRN;
		protected System.Web.UI.WebControls.Label lblMAlumni;
		protected System.Web.UI.WebControls.DataGrid DGMCourseDetails;
		protected System.Web.UI.WebControls.Label lblMNameOfStudent;
		protected System.Web.UI.WebControls.Label lblMFathersName;
		protected System.Web.UI.WebControls.Label lblMMothersMaidenName;
		protected System.Web.UI.WebControls.Label lblMPreviousName;
		protected System.Web.UI.WebControls.Label lblMDOB;
		protected System.Web.UI.WebControls.Label lblMGender;
		protected System.Web.UI.WebControls.Label lblMNationality;
		protected System.Web.UI.WebControls.Image ImageM1;
		protected System.Web.UI.WebControls.Image ImageM2;
		protected System.Web.UI.WebControls.Label lblMDomicileState;
		protected System.Web.UI.WebControls.Label lblMResvCategory;
		protected System.Web.UI.WebControls.Label lblMPhyChlngd;
		protected System.Web.UI.WebControls.Label lblMSocResv;
		protected System.Web.UI.WebControls.Label lblMGuardianincome;
		protected System.Web.UI.WebControls.Label lblMGuardianOccupation;
		protected System.Web.UI.WebControls.DataGrid DGMQualification;
		protected System.Web.UI.WebControls.DataGrid DGMSubmittedDocs;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divMStudentDetails;
		protected System.Web.UI.WebControls.Label lblProfileHeading;
		protected System.Web.UI.WebControls.Label lblPRN;
		protected System.Web.UI.WebControls.Label lblAlumni;
		protected System.Web.UI.WebControls.DataGrid DGCourseDetails;
		protected System.Web.UI.WebControls.Label lblNameOfStudent;
		protected System.Web.UI.WebControls.Label lblFathersName;
		protected System.Web.UI.WebControls.Label lblMothersMaidenName;
		protected System.Web.UI.WebControls.Label lblPreviousName;
		protected System.Web.UI.WebControls.Label lblDOB;
		protected System.Web.UI.WebControls.Label lblGender;
		protected System.Web.UI.WebControls.Label lblNationality;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label lblDomicileState;
		protected System.Web.UI.WebControls.Label lblResvCategory;
		protected System.Web.UI.WebControls.Label lblPhyChlngd;
		protected System.Web.UI.WebControls.Label lblSocResv;
		protected System.Web.UI.WebControls.Label lblGuardianincome;
		protected System.Web.UI.WebControls.Label lblGuardianOccupation;
		protected System.Web.UI.WebControls.DataGrid DGQualification;
		protected System.Web.UI.WebControls.DataGrid DGSubmittedDocs;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divStudentDetails;
		protected System.Web.UI.HtmlControls.HtmlTableRow trChangedName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidUniID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidPRN;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidElgFormNo;
		protected System.Web.UI.HtmlControls.HtmlTableRow trMChangedName;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
            Classes.clsCache.NoCache();
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
			 FetchMStudentDetails();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void FetchMStudentDetails()
		{
			
			trMChangedName.Style.Add("display","none");
			DataSet ds = new DataSet();
			try
			{
				
				
				ds=clsEligibilityDBAccess.Fetch_IAMatchingREG_StudentDetails(179,2006,1);
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

                ImageM1.ImageUrl = "PhotoAndSignTemp.aspx?img=PR&sElgFormNo=" + hidElgFormNo.Value;         
				ImageM1.Visible=true;
                ImageM2.ImageUrl = "PhotoAndSignTemp.aspx?img=SR&sElgFormNo=" + hidElgFormNo.Value;         
				ImageM2.Visible=true;
					
				divStudentDetails.Style.Add("Display","block");
				
			}
			catch(Exception ex)
			{  
				Response.Write(ex.Message);
				throw new Exception(ex.Message);
			}

			ds.Dispose();
		}

		private void DGMSubmittedDocs_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				e.Item.Cells[0].Text=Convert.ToString(e.Item.DataSetIndex+1);
				
			}
		}

		private void DGMCourseDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				e.Item.Cells[0].Text=Convert.ToString(e.Item.DataSetIndex+1);
				//e.Item.Cells[2].Text = "Received";
				
			}
		}
		

		
	}
}
