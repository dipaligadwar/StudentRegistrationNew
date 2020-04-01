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
	/// Summary description for Elg_bulkProcessing.
	/// </summary>
	public partial class Elg_bulkProcessing : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnkSimpleSearch;
		protected System.Web.UI.WebControls.LinkButton lnkAdvSearch;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tehsilName;
		protected System.Web.UI.WebControls.Button btndecision;
		Eligibility.WebCtrl.Elg_StudentBulklisting Elg_StudentBulklistingctrl;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            Classes.clsCache.NoCache();
			// Put user code to initialize the page here
			//btnSimpleSearch.Attributes.Add("onclick","return ChkValidation();");
			Elg_StudentBulklistingctrl = (Eligibility.WebCtrl.Elg_StudentBulklisting)Page.FindControl("Elg_StudentBulklisting1");
			Elg_StudentBulklistingctrl.QstrNavigate=null;
			Elg_StudentBulklistingctrl.StrUrl="Elg_bulkProcessing__1.aspx?Search=Adv";
			Elg_StudentBulklistingctrl.GridType = "IA";
			if(Request.QueryString["Search"] == "Adv")
			{
				if(Request.QueryString["Navigate"] == "back")
				{
					Elg_StudentBulklistingctrl.QstrNavigate="back";
					Elg_StudentBulklistingctrl.StrUrl="IA_StudentEligibility__1.aspx?Search=Adv";
					Elg_StudentBulklistingctrl.GridType = "IA";
					
				}
				else
				{
					Elg_StudentBulklistingctrl.QstrNavigate=null;
					Elg_StudentBulklistingctrl.StrUrl="IA_StudentEligibility__1.aspx?Search=Adv";
					Elg_StudentBulklistingctrl.GridType = "IA";
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

		}
		#endregion

		

		private void btnSimpleSearch_Click(object sender, System.EventArgs e)
		{
			
						
		}

		private void btndecision_Click(object sender, System.EventArgs e)
		{
			
		}

		
	}
}
