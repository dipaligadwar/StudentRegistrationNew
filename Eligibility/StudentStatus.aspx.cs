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
using System.Text.RegularExpressions;
using Classes;

namespace StudentRegistration.Eligibility
{
	/// <summary>
	/// Summary description for StudentStatus.
	/// </summary>
	public partial class StudentStatus : System.Web.UI.Page
    {

        #region declaration of variables

        protected System.Web.UI.HtmlControls.HtmlInputHidden tehsilName;
		string PRNumber=null;
        clsCommon Common = new clsCommon();
		Eligibility.WebCtrl.StudentsStatusSearch RegStudentAdvancedSearchCtrl;
		DataSet ds;
		private int pkUniID,pkYear,pkStudentID,Flag;
		private string Elg_FormNo;

        #endregion

        #region
        public int  pk_Uni_ID
		{
			get
			{
			 return pkUniID;
			}
			set
			{
			 pkUniID = value;
			}
		}

		public int pk_Year
		{
			get
			{
				return pkYear;
			}
			set
			{
			   pkYear = value;
			}
		}
		public int pk_Student_ID
		{
			get
			{
			 return pkStudentID;
			}
			set
			{
			 pkStudentID = value;
			}
		}
		public string ElgFormNo
		{
			get
			{
			 return Elg_FormNo;
			}
			set
			{
			 Elg_FormNo =  value;
			}
		}
		public string PRN
		{
			get
			{
			 return PRNumber;
			}
			set
			{
			 PRNumber=value;
			}
		}
		//Flag = 0 if PRN wise search is made ,
		//Flag = 1 if PRN is not given search criteria will be on Eligibility Form Number
		public int DisplayFlag
		{
			get
			{
			 return Flag;
			}
			set
			{
			 Flag = value;
			}
		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            Classes.clsCache.NoCache();

            if (!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[5];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidElgFormNo;
                hid[3] = hidpkStudentID;
                hid[4] = hidpkYear;

                Common.setHiddenVariables(ref hid);
            }
			btnSimpleSearch.Attributes.Add("onclick","return ChkValidation();");
            if (hidInstID.Value != "" && hidInstID.Value != null)
            {
                //hidInstID.Value = Request.QueryString["InstituteID"].ToString().Trim();
                lblTitle.Text = "View Eligibility Status";
                lblInstName.Text = "  for " + Classes.InstituteRepository.InstituteName(hidUniID.Value, hidInstID.Value);
            }
			RegStudentAdvancedSearchCtrl = (Eligibility.WebCtrl.StudentsStatusSearch) Page.FindControl("StudentsStatusSearch1");
			RegStudentAdvancedSearchCtrl.QstrNavigate=null;
			RegStudentAdvancedSearchCtrl.StrUrl="StudentStatus__1.aspx?Search=Adv";
			if(Request.QueryString["Search"] == "Adv")
			{
				if(Request.QueryString["Navigate"] == "back")
				{
					RegStudentAdvancedSearchCtrl.QstrNavigate="back";
					RegStudentAdvancedSearchCtrl.StrUrl="StudentStatus__1.aspx?Search=Adv";
					divAdvSearch.Style.Add("display","block");
					divSimpleSearch.Style.Add("display","none");
				}
				else
				{
					RegStudentAdvancedSearchCtrl.QstrNavigate=null;
					RegStudentAdvancedSearchCtrl.StrUrl="StudentStatus__1.aspx?Search=Adv";
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

		protected void btnSimpleSearch_Click(object sender, System.EventArgs e)
		{
			
			//string ElgFormNo = txtElgFormNo.Text.Trim();
			if(txtElgFormNo.Text!="")
				Elg_FormNo=txtElgFormNo.Text.Trim();
			else
				Elg_FormNo ="0-0-0-0";
			int cnt = 0;
			string str = Elg_FormNo;
			int pos = str.IndexOf('-');
			string[] arr = new string[]{"0","0","0","0"};
			//Regular expression validation
			Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");
			
			//if(txtPRN.Text!="")
			//PRN=txtPRN.Text.Trim();
			if(objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
				PRN=txtPRN.Text.Trim();
			while(pos != -1)
			{
				str = str.Substring(pos+1);
				pos = str.IndexOf('-');
				cnt++;
				
			}
			if(cnt == 3)
			{
				
				arr = ElgFormNo.Split('-');   //UniID = arr[0], InstituteID = arr[1], Year = arr[2], StudID = arr[3]
				for(int i=0;i<4;i++)
				{
					if(arr[i] == "")
						arr[i] = "0";
				}		
			}
			
			ds = clsEligibilityDBAccess.REG_Search_GetStudentIDs(Convert.ToInt32(arr[0]),Convert.ToInt32(arr[2]),Convert.ToInt32(arr[1]),Convert.ToInt32(arr[3]),PRN);
			if(ds.Tables[0].Rows.Count==0)
			{
				if(objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
				{
					lblMsg.Text="The PRN given doesn't exists.";
				}
				else
				{
					lblMsg.Text = "Sorry,No matching record found.Please Check later.";
				}
				lblMsg.Style.Remove("display");
				lblMsg.Style.Add("display","block");
			}
			else
			{
				pk_Uni_ID=Convert.ToInt32(ds.Tables[0].Rows[0]["UniID"].ToString());
				//Session["pk_Year"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Yr"].ToString());        //Comented on 29/09/2007 by Jyotsna
				//Session["pk_Student_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["StudID"].ToString());
                
                hidpkYear.Value = ds.Tables[0].Rows[0]["Yr"].ToString();
                hidpkStudentID.Value = ds.Tables[0].Rows[0]["StudID"].ToString();


                pk_Year=Convert.ToInt32(ds.Tables[0].Rows[0]["Yr"].ToString());
				pk_Student_ID=Convert.ToInt32(ds.Tables[0].Rows[0]["StudID"].ToString());
               
				Server.Transfer("StudentStatus__1.aspx?Search=Simple");
			}
			
		}
		}

	}

