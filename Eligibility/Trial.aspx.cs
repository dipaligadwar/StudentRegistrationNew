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

namespace StudentRegistration.Eligibility
{
	/// <summary>
	/// Summary description for Trial.
	/// </summary>
	public partial class Trial : System.Web.UI.Page
	{
		
		DataSet submitteddocs=new DataSet();
		DataSet matchingrecords=new DataSet();
		DataSet AdmissionDetails=new DataSet();
		protected System.Web.UI.HtmlControls.HtmlGenericControl iframedivStudentDetails;
		DataSet dsQualn = new DataSet();
        clsCache clsCache = new clsCache();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            clsCache.NoCache();

			fillmatchingrecords();
			filldocuments();
			fillqualification();
		}

		public void fillmatchingrecords()
		{
			matchingrecords.Tables.Add("MatchingRecord");
			
			matchingrecords.Tables["MatchingRecord"].Columns.Add("StudentName");
			matchingrecords.Tables["MatchingRecord"].Columns.Add("PRN");
			matchingrecords.Tables["MatchingRecord"].Columns.Add("Certificate_Number");
			matchingrecords.Tables["MatchingRecord"].Columns.Add("PassedYear");
			matchingrecords.Tables["MatchingRecord"].Columns.Add("Board");

			DataRow dr=matchingrecords.Tables["MatchingRecord"].NewRow();
			dr["StudentName"]="Ram Gopal";
			dr["PRN"]="20060000011";
			dr["Certificate_Number"]="765432";
			dr["PassedYear"]="1996";
			dr["Board"]="MAHARASHTRA STATE BOARD OF SECONDARY AND HIGHER SECONDARY EDUCATION";
			matchingrecords.Tables["MatchingRecord"].Rows.Add(dr);
			
			dr=matchingrecords.Tables["MatchingRecord"].NewRow();
			dr["StudentName"]="Ram G";
			dr["PRN"]="20060000011";
			dr["Certificate_Number"]="765432";
			dr["PassedYear"]="1996";
			dr["Board"]="MAHARASHTRA STATE BOARD OF SECONDARY AND HIGHER SECONDARY EDUCATION";
			matchingrecords.Tables["MatchingRecord"].Rows.Add(dr);
			DGMatchingRecords.DataSource=matchingrecords;
			DGMatchingRecords.DataBind();
		}

		public void filldocuments()
		{
			submitteddocs.Tables.Add("submitteddocs");
			
			submitteddocs.Tables["submitteddocs"].Columns.Add("DocCert_Desc");
			submitteddocs.Tables["submitteddocs"].Columns.Add("pk_DocCert_ID");
			submitteddocs.Tables["submitteddocs"].Columns.Add("ReceivedByUniversity");
			DataRow dr=submitteddocs.Tables["submitteddocs"].NewRow();
			dr["DocCert_Desc"]="SSC Certificate";
			dr["pk_DocCert_ID"]="11";
			dr["ReceivedByUniversity"]="Recvd (valid)";
			submitteddocs.Tables["submitteddocs"].Rows.Add(dr);

			dr=submitteddocs.Tables["submitteddocs"].NewRow();
			dr["DocCert_Desc"]="HSC Certificate";
			dr["pk_DocCert_ID"]="12";
			dr["ReceivedByUniversity"]="Not Recvd";
			submitteddocs.Tables["submitteddocs"].Rows.Add(dr);

			DGSubmittedDocs.DataSource=submitteddocs;
			DGSubmittedDocs.DataBind();
		}

		public void fillAdmissionDetails()
		{
			AdmissionDetails.Tables.Add("AdmissionDetails");
			
			AdmissionDetails.Tables["AdmissionDetails"].Columns.Add("Course");
			AdmissionDetails.Tables["AdmissionDetails"].Columns.Add("InstituteName");
			AdmissionDetails.Tables["AdmissionDetails"].Columns.Add("EligibilityStatus");
			AdmissionDetails.Tables["AdmissionDetails"].Columns.Add("CourseStatus");
			

			DataRow dr=AdmissionDetails.Tables["AdmissionDetails"].NewRow();
			dr["Course"]="BSc Mathematics";
			dr["InstituteName"]="Wadia College";
			dr["EligibilityStatus"]="Eligible";
			dr["CourseStatus"]="Appeared";
			AdmissionDetails.Tables["AdmissionDetails"].Rows.Add(dr);
			
			//			dr=matchingrecords.Tables["AdmissionDetails"].NewRow();
			//			dr["Course"]="Ram G";
			//			dr["InstituteName"]="20060000011";
			//			dr["EligibilityStatus"]="765432";
			//			dr["CourseStatus"]="1996";
			//			AdmissionDetails.Tables["AdmissionDetails"].Rows.Add(dr);

			DGCourseDetails.DataSource=AdmissionDetails;
			DGCourseDetails.DataBind();
		}

		public void fillqualification()
		{
			dsQualn.Tables.Add("Qualinfn");
			dsQualn.Tables[0].Columns.Add("Qualification");
			dsQualn.Tables[0].Columns.Add("CollegeInstituteName");
			dsQualn.Tables[0].Columns.Add("Body");
			dsQualn.Tables[0].Columns.Add("Marks_Obtained");
			dsQualn.Tables[0].Columns.Add("Marks_OutOf");
			dsQualn.Tables[0].Columns.Add("DateOfPassing");

			DataRow drow = dsQualn.Tables[0].NewRow();
			drow["Qualification"]="Xth STD";
			drow["CollegeInstituteName"]="St.Vincent's School";
			drow["Body"]="Maharashtra State Board";
			drow["Marks_Obtained"]="540";
			drow["Marks_OutOf"]="600";
			drow["DateOfPassing"]="2000";
			dsQualn.Tables[0].Rows.Add(drow);
			DataRow drow1 = dsQualn.Tables[0].NewRow();
			drow1["Qualification"]="XIIth STD";
			drow1["CollegeInstituteName"]="Fergussan College";
			drow1["Body"]="Maharashtra State Board";
			drow1["Marks_Obtained"]="880";
			drow1["Marks_OutOf"]="1000";
			drow1["DateOfPassing"]="2002";
			dsQualn.Tables[0].Rows.Add(drow1);
			DGQualification.DataSource=dsQualn;
			DGQualification.DataBind();
		  

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
			this.DGMatchingRecords.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGMatchingRecords_ItemCommand);
			this.DGMatchingRecords.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGMatchingRecords_ItemDataBound);

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
			}
		}

		#region FillData
		public void FillData()
		{
			
			lblDOB.Text="11/6/1982";
			lblDomicileState.Text="Maharashtra";
			lblFathersName.Text="Kumar";
			lblGender.Text="Male";
			lblGuardianincome.Text="100000Rs";
			lblGuardianOccupation.Text="Buisness";
			lblMothersMaidenName.Text="Korade";
			lblNameOfStudent.Text="Ram Gopal";
			lblNationality.Text="Indian";
			lblResvCategory.Text="Null";
			lblSocResv.Text="Null";
			lblPhyChlngd.Text="Null";
			
			
		 
		}
		#endregion

		private void DGMatchingRecords_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName=="ShowProfile")
			{
				lblPRN.Text=e.Item.Cells[2].Text;
				FillData();
				fillAdmissionDetails();
				divStudentDetails.Style.Add("display","block");
			}
		}

		private void DGCourseDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				e.Item.Cells[0].Text=Convert.ToString(e.Item.ItemIndex+1);
				
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
		
		}

		

		
	}
}
