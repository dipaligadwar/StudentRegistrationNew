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
	/// Summary description for reg_PendingStudentEligibility.
	/// </summary>
	public partial class reg_PendingStudentEligibility : System.Web.UI.Page
    {
        #region Declaration of Variables
        protected System.Web.UI.HtmlControls.HtmlInputHidden tehsilName;
        Eligibility.WebCtrl.StudentAdvanceSeachForConfigure RegStudentAdvancedSearchCtrl;
        clsCommon Common = new clsCommon();
        #endregion

        #region Page Load
        protected void Page_Load(object sender, System.EventArgs e)
		{
            Classes.clsCache.NoCache();
			// Put user code to initialize the page here
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

            if(hidInstID.Value != "" && hidInstID.Value != null)
            {
                //hidInstID.Value = Request.QueryString["InstituteID"].ToString().Trim();
                lblTitle.Text = "Resolve Pending Eligibility";
                lblInstName.Text = "  for " + Classes.InstituteRepository.InstituteName(hidUniID.Value, hidInstID.Value);                
            }
			btnSimpleSearch.Attributes.Add("onclick","return ChkValidation();");
            RegStudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentAdvanceSeachForConfigure)Page.FindControl("StudentAdvanceSeachForConfigure1");
			RegStudentAdvancedSearchCtrl.QstrNavigate=null;
			RegStudentAdvancedSearchCtrl.StrUrl="reg_PendingStudentEligibility__1.aspx?Search=Adv";
			RegStudentAdvancedSearchCtrl.GridType = "Reg";
			if(Request.QueryString["Search"] == "Adv")
			{
				if(Request.QueryString["Navigate"] == "back")
				{
					RegStudentAdvancedSearchCtrl.QstrNavigate="back";
					RegStudentAdvancedSearchCtrl.StrUrl="reg_PendingStudentEligibility__1.aspx?Search=Adv";
					RegStudentAdvancedSearchCtrl.GridType = "Reg";
					divAdvSearch.Style.Add("display","block");
					divSimpleSearch.Style.Add("display","none");
				}
				else
				{
					RegStudentAdvancedSearchCtrl.QstrNavigate=null;
					RegStudentAdvancedSearchCtrl.StrUrl="reg_PendingStudentEligibility__1.aspx?Search=Adv";
					RegStudentAdvancedSearchCtrl.GridType = "Reg";
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

        #endregion

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
				arr = ElgFormNo.Split('-');   //new  UniID = arr[0], InstID = arr[1],Year = arr[2], StudID = arr[3]
				for(int i=0;i<4;i++)
				{
					if(arr[i] == "")
						arr[i] = "0";
				}
				DataSet ds;
				ds = clsEligibilityDBAccess.Check_Reg_Pending_Student_Exists(arr[0],arr[2],arr[1],arr[3]);
				if(ds.Tables[0].Rows.Count>0)
				{
					if(ds.Tables[0].Rows[0]["Eligibility"].ToString() == "3")    // Pending Eligibility
					{
                        //Session["ElgFormNo"] = tbElgFormNo.Text.Trim();           Commented on 29/09/2007 by Jyotsna
						//Session["pk_Year"] = ds.Tables[0].Rows[0]["pk_Year"];
						//Session["pk_Student_ID"] = ds.Tables[0].Rows[0]["pk_Student_ID"];
						//Session["pk_CrMoLrnPtrn_ID"]=ds.Tables[0].Rows[0]["pk_CrMoLrnPtrn_ID"];						
                        //Session["pk_Year"] = ds.Tables[0].Rows[0]["pk_Year"].ToString();        
						//Session["pk_Student_ID"] = ds.Tables[0].Rows[0]["pk_Student_ID"].ToString();                        
                        hidElgFormNo.Value = tbElgFormNo.Text.Trim();                       
                        hidpkYear.Value = ds.Tables[0].Rows[0]["pk_Year"].ToString();
						hidpkStudentID.Value = ds.Tables[0].Rows[0]["pk_Student_ID"].ToString();
						hidCrMoLrnPtrnID.Value = ds.Tables[0].Rows[0]["pk_CrMoLrnPtrn_ID"].ToString();
						Server.Transfer("reg_PendingStudentEligibility__1.aspx?Search=Simple");
					}
					else if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "1") // Eligible
					{
						lblErrorMsg.Text = "The Student with Eligibility Form Number "+tbElgFormNo.Text.Trim()+" is already been processed and marked as Eligible with PRN : "+ds.Tables[0].Rows[0]["PRN"].ToString();
						lblErrorMsg.Visible = true;
					}
					else  //Not Eligible
					{
						lblErrorMsg.Text = "The Student with Eligibility Form Number "+tbElgFormNo.Text.Trim()+" is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";
						lblErrorMsg.Visible = true;
					}
					
				}
				else
				{
					lblErrorMsg.Text = "The eligibility of the Student with Eligibility Form Number  "+tbElgFormNo.Text.Trim()+"  is not kept pending or may not be processed.Please check the status to verify.";
					lblErrorMsg.Visible = true;
				}
			}
			else
			{
				lblErrorMsg.Text = "There is no matching record.";
				lblErrorMsg.Visible = true;
			}
			
		}

		protected void tbElgFormNo_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
