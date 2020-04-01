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
	/// Summary description for IA_StudentEligibility.
	/// </summary>
	public partial class IA_StudentEligibility : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputHidden tehsilName;
        Eligibility.WebCtrl.StudentAdvanceSeachForConfigure IAStudentAdvancedSearchCtrl;
        clsCommon Common = new clsCommon();
	    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            Classes.clsCache.NoCache();
			// Put user code to initialize the page here
			btnSimpleSearch.Attributes.Add("onclick","return ChkValidation();");
            lblPaidList.Text = "This search will display only those students whose payment is received by university";
           
            if(!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[5];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidElgFormNo;
                hid[3] = hidpkStudentID;
                hid[4] = hidpkYear;


                Common.setHiddenVariables(ref hid);
                
                
            }
            //if (Request.QueryString["InstituteID"] != null && Request.QueryString["InstituteID"] != "")
            if(hidInstID.Value !="" && hidInstID.Value!=null)
            {
               // hidInstID.Value = Request.QueryString["InstituteID"].ToString().Trim();
                lblTitle.Text = "Manual Process Eligibility";
                lblInstName.Text = "  for " + Classes.InstituteRepository.InstituteName(hidUniID.Value, hidInstID.Value);

            }
           
            IAStudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentAdvanceSeachForConfigure)Page.FindControl("StudentAdvanceSeachForConfigure1");
			IAStudentAdvancedSearchCtrl.QstrNavigate=null;
			IAStudentAdvancedSearchCtrl.StrUrl="IA_StudentEligibility__1.aspx?Search=Adv";
			IAStudentAdvancedSearchCtrl.GridType = "IA";
			if(Request.QueryString["Search"] == "Adv")
			{
				if(Request.QueryString["Navigate"] == "back")
				{
					IAStudentAdvancedSearchCtrl.QstrNavigate="back";
					IAStudentAdvancedSearchCtrl.StrUrl="IA_StudentEligibility__1.aspx?Search=Adv";
					IAStudentAdvancedSearchCtrl.GridType = "IA";
					divAdvSearch.Style.Remove("display");
					divAdvSearch.Style.Add("display","block");
					divSimpleSearch.Style.Remove("display");
					divSimpleSearch.Style.Add("display","none");
                    
				}
				else
				{
					IAStudentAdvancedSearchCtrl.QstrNavigate=null;
					IAStudentAdvancedSearchCtrl.StrUrl="IA_StudentEligibility__1.aspx?Search=Adv";
					IAStudentAdvancedSearchCtrl.GridType = "IA";
				}
			}
			else if(Request.QueryString["Search"] == "Simple")
			{
				divAdvSearch.Style.Remove("display");
				divSimpleSearch.Style.Remove("display");
				divSimpleSearch.Style.Add("display","block");
				divAdvSearch.Style.Add("display","none");
               
			}
			
			if(hidSearchType.Value == "Simple")
			{
				divAdvSearch.Style.Remove("display");
				divSimpleSearch.Style.Remove("display");
				divSimpleSearch.Style.Add("display","block");
				divAdvSearch.Style.Add("display","none");
               
			}
			else if(hidSearchType.Value == "Adv")
			{
				divAdvSearch.Style.Remove("display");
				divSimpleSearch.Style.Remove("display");
				divAdvSearch.Style.Add("display","block");
				divSimpleSearch.Style.Add("display","none");
                
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

//		private void lnkAdvSearch_Click(object sender, System.EventArgs e)
//		{
//			divAdvSearch.Style.Add("Display","block");
//			divSimpleSearch.Style.Add("Display", "none");
//		}
//
//		private void lnkSimpleSearch_Click(object sender, System.EventArgs e)
//		{
//			divSimpleSearch.Style.Add("Display", "block");
//			divAdvSearch.Style.Add("Display","none");
//			
//		}

		protected void btnSimpleSearch_Click(object sender, System.EventArgs e)
		{
			string ElgFormNo = tbElgFormNo.Text.Trim();
            
			int cnt = 0;
			string str = ElgFormNo;
			int pos = str.IndexOf('-');
			while(pos != -1)
			{
				str = str.Substring(pos+1);
				pos = str.IndexOf('-');
				cnt++;
				
			}
			if(cnt == 3)
			{
				string[] arr = new string[4];
				arr = ElgFormNo.Split('-');   //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
				for(int i=0;i<4;i++)
				{
					if(arr[i] == "")
					   arr[i] = "0";
				}
				int ExistsFlag;
				ExistsFlag = clsEligibilityDBAccess.Check_IA_Student_Exists(arr[0],arr[2],arr[1],arr[3]);
				if(ExistsFlag == 0)
				{
					lblErrorMsg.Text = "The Student's data with Eligibility Form Number "+tbElgFormNo.Text.Trim()+"  might have processed or haven't uploaded yet.So please check the status to verify.";
					lblErrorMsg.Style.Remove("display");
					lblErrorMsg.Style.Add("display","inline");
                   
				}
				else
				{
					//Session["ElgFormNo"] = tbElgFormNo.Text.Trim();  Commented By Jyotsna on 29/09/2007
					hidElgFormNo.Value = tbElgFormNo.Text.Trim();
					Server.Transfer("IA_StudentEligibility__1.aspx?Search=Simple");
				}
			}
			else
			{
				lblErrorMsg.Text = "Please Enter the Valid Eligibility Form Number.";
				lblErrorMsg.Style.Remove("display");
				lblErrorMsg.Style.Add("display","block");
			}
		}

        protected void Footer1_Load(object sender, EventArgs e)
        {

        }

		
	}
}
