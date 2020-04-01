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
	
namespace Digital_College
{
	

	/// <summary>
	///		Summary description for Search_Control.
	/// </summary>
	public partial class Search_Control : System.Web.UI.UserControl
	{
		#region Declare Variables
		public DataTable DT_Search = new DataTable();
		DataTable DT_SessionVars = new DataTable();
		
		Hashtable ht = new Hashtable();
		clsStudent objStudent = new clsStudent();
		clsStudentCourse objStudCourse = new clsStudentCourse();
		clsCommon objCommon = new clsCommon();
		
		string strCrMoLrnPtrn_ID = "";
		string strCrPr_ID = "";
		string strpk_Institute_ID = "";
		
		string strpk_Uni_ID = "";

		#endregion

		public System.Web.UI.WebControls.DataGrid DG_Search;

		#region Setting Properties 

		public System.Web.UI.WebControls.Button btnSearch;
		private string Student_ID = "";		
		private string Admission_Form_No = "";	
		private string CrMoLrnPtrn_ID = "";	
		private string CrPr_ID = "";
		private string Course_Name = "";
		private string Record_Count;

		public string StudentID
		{
			get
			{
				return Student_ID;						
			}
		}

		
		public string Admission_FormNo
		{
			get
			{
				return Admission_Form_No;						
			}
		}

		public string CrMoLrnPtrnID
		{
			get
			{
				return CrMoLrnPtrn_ID;						
			}
		}

		
		public string CourseName
		{
			get
			{
				return Course_Name;						
			}
		}

		public string CrPartID
		{
			get
			{
				return CrPr_ID;						
			}
		}

		public string RecordCount
		{
			get
			{
				return Record_Count;						
			}
		}

		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
            Classes.clsCache.NoCache();

			if(!IsPostBack)
			{
				DataTable DT_Courses = new DataTable();
				//DT_Courses = objStudCourse.Get_AllCourseParts();
				//DT_Courses = Classes.InstituteRepository.Get_AllCourseParts(System.Configuration.ConfigurationSettings.AppSettings["UniversityID"].ToString(),System.Configuration.ConfigurationSettings.AppSettings["InstituteID"].ToString());
				objCommon.fillDropDown(DD_Course, DT_Courses, "", "Text", "Value", "--- Select ---");
			}
			if(IsPostBack ==true && hid_Status.Value == "Y")
			{
				tr_AdvanceSearch1.Attributes["style"]="display:inline";
				tr_AdvanceSearch2.Attributes["style"]="display:inline";
				tr_AdvanceSearch3.Attributes["style"]="display:inline";
			}
			
		}

	
		public void btnSearch_Click(object sender, System.EventArgs e)
		{
			msgLabel.Text = "";
			string str=Page.ToString();
			string PageName = str.Substring(4,(str.Length-9));
			string ans = CreateHastable();
			if(ans == "Y")
			{
				//DT_Search = objStudent.Search_Student_With_PRN(ht);
				if(DT_Search.Rows.Count > 0)
				{
					Student_ID = DT_Search.Rows[0]["pk_Student_ID"].ToString().Trim();
					Admission_Form_No = DT_Search.Rows[0]["Admission_Form_No"].ToString().Trim();
					CrMoLrnPtrn_ID = DT_Search.Rows[0]["fk_CrMoLrnPtrn_ID"].ToString().Trim();
					CrPr_ID = DT_Search.Rows[0]["fk_CrPr_ID"].ToString().Trim();
					Record_Count = DT_Search.Rows.Count.ToString();
				}
				else
				{
					msgLabel.Text = "";
					msgLabel.Text = "No Data Found";
					msgLabel.Visible = true;
					msgLabel.CssClass = "ErrorNote";
					DG_Search.Visible = false;
				}
			}
			else
			{
				msgLabel.Text = "";
				msgLabel.Text = "No option selected for searching";
				msgLabel.Visible = true;
				msgLabel.CssClass = "ErrorNote";
				DG_Search.Visible = false;
				
			}
		}

	
		public void DG_Search_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.Cells[1].Text.ToString() != "&nbsp;")
				strCrMoLrnPtrn_ID = e.Item.Cells[1].Text.ToString();
			if(e.Item.Cells[2].Text.ToString() != "&nbsp;")
				strCrPr_ID = e.Item.Cells[2].Text.ToString();
			strpk_Uni_ID = e.Item.Cells[3].Text.ToString();
			strpk_Institute_ID = e.Item.Cells[4].Text.ToString();
		}


		private void DG_Search_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//			hid_Student_ID.Value = e.Item.Cells[0].Text.ToString().Trim();
			//			hid_FormNo.Value = e.Item.Cells[5].Text.ToString().Trim();
			//			Student_ID = hid_Student_ID.Value;
			//			Admission_Form_No = hid_FormNo.Value ;
			//			CrMoLrnPtrn_ID = e.Item.Cells[1].Text.ToString().Trim();
			//			CrPr_ID = e.Item.Cells[2].Text.ToString().Trim();
			//			Course_Name = e.Item.Cells[9].Text.ToString().Trim();
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DG_Search.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_Search_ItemCommand);
			this.DG_Search.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DG_Search_ItemDataBound);

		}
		#endregion


		#region Create Hash Table 
		private string CreateHastable()
		{
			if(LastName.Text.ToString() == "" && FirstName.Text.ToString().Trim() == "" && Gender.SelectedValue == "N" && DOB.Text.ToString().Trim() == "" && PRN_No.Text.ToString().Trim() == "" && DD_Course.SelectedValue == "0")
			{
				return "N";
			}
			else
			{
				ht.Add("Last_Name", LastName.Text.ToString().Trim());
				ht.Add("First_Name",FirstName.Text.ToString().Trim());
				if(Gender.SelectedValue != "N")
				{
					ht.Add("Gender",Gender.SelectedValue.ToString().Trim());
				}
				ht.Add("Date_of_Birth",DOB.Text.ToString().Trim());
				ht.Add("PRN_Number",PRN_No.Text.ToString().Trim());				
				if(DD_Course.SelectedIndex > 0)
				{
					string []sArr;
					sArr = DD_Course.SelectedValue.ToString().Trim().Split("-".ToCharArray(),2);
					ht.Add("fk_CrMoLrnPtrn_ID", sArr[0].ToString());
					ht.Add("fk_CrPr_ID", sArr[1].ToString());
				}
				ht.Add("pk_Uni_ID",Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["UniversityID"].ToString()));
				ht.Add("pk_Institute_ID",Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["InstituteID"].ToString()));


				return "Y";
			}

		}
		#endregion

		

		protected void Page_PreRender(object sender, EventArgs e)
		{
			
		}

		
	}
}
