using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using Classes;


namespace StudentRegistration.Eligibility.WebCtrl
{
	/// <summary>
	///		Summary description for StudentsStatusSearch.
	/// </summary>
	public partial class StudentsStatusSearch : System.Web.UI.UserControl
    {
        #region Variables
        DataSet dsDistricts = new DataSet();
		private string qstrNavigate;
		private string strUrl;
        clsCommon Common = new clsCommon();
		//protected System.Web.UI.WebControls.CheckBox cbApproved;
		//protected System.Web.UI.WebControls.CheckBox cbRejected;
		//protected System.Web.UI.WebControls.CheckBox cbPending;
		//protected System.Web.UI.HtmlControls.HtmlGenericControl divCombinationRequest;
		
		//protected System.Web.UI.WebControls.LinkButton lnkSimpleSearch;
		//protected System.Web.UI.WebControls.LinkButton lnkAdvSearch;
		//protected System.Web.UI.WebControls.TextBox tbElgFormNo;
		//protected System.Web.UI.WebControls.Button btnSimpleSearch;
		//protected System.Web.UI.WebControls.Label lblErrorMsg;
		//protected System.Web.UI.HtmlControls.HtmlGenericControl divSimpleSearch;
        //protected System.Web.UI.HtmlControls.HtmlGenericControl divAdvSearch;
        #endregion

        #region Properties
        public string QstrNavigate
		{
			set
			{
				qstrNavigate=value;
			}
		}
		public string StrUrl
		{
			set
			{
				strUrl=value;
			}
			get
			{
				return strUrl;
			}
        }

        #endregion 

        protected void Page_Load(object sender, System.EventArgs e)
		{
            Classes.clsCache.NoCache();

			Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods),this.Page);
			dgRegStudentList.Visible = false;
			lblGridName.Style.Remove("display");
			lblGridName.Style.Add("display","none");
			divDGNote.Style.Remove("display");
			divDGNote.Style.Add("display","none");
			
			if(!IsPostBack)
            {
                #region Set Hidden
                HtmlInputHidden[] hid = new HtmlInputHidden[10];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidStateID;
                hid[3] = hidDistrictID;
                hid[4] = hidTehsilID;
                hid[5] = hidElgFormNo;
                hid[6] = hidpkStudentID;
                hid[7] = hidpkYear;
                hid[8] = hidPRN;
                hid[9] = hidSearchType;

                Common.setHiddenVariables(ref hid);
                #endregion

                if (qstrNavigate == "back")
				{
                                                //All Session variables replaced by hidden variables.
                    txtDOB.Text = hidDOB.Value;
					for(int i=0; i<ddlGender.Items.Count; i++)
					{
						if(ddlGender.Items[i].Value == hidGender.Value)
							ddlGender.SelectedIndex = i;
					}
					txtLastName.Text = hidLastName.Value;
					txtFirstName.Text = hidFirstName.Value;
					fnFillStateDistrictTaluka(hidStateID.Value,hidDistrictID.Value,hidTehsilID.Value);

                    hidStateID.Value = hidStateID.Value;
                    hidDistrictID.Value = hidDistrictID.Value;
					hidTehsilID.Value = hidTehsilID.Value;
					fnDisplayDGRegStudentList("");
			    
				}
				else
				{
					fnFillStateDistrictTaluka("","","");
					hidUniID.Value=UniversityPortal.clsGetSettings.UniversityID.ToString();
				}
			}
			else
			{
				fnFillStateDistrictTaluka(hidStateID.Value,hidDistrictID.Value,hidTehsilID.Value);
				hidUniID.Value=UniversityPortal.clsGetSettings.UniversityID.ToString();
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgRegStudentList.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgRegStudentList_ItemCommand);
			this.dgRegStudentList.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgRegStudentList_PageIndexChanged);
			this.dgRegStudentList.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgRegStudentList_ItemDataBound);

		}
		#endregion

        private void fnDisplayDGRegStudentList(string sortExpression)
		{
			DataSet ds=new DataSet();
			try
			{
				ds=Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List(UniversityPortal.clsGetSettings.UniversityID.ToString(),hidInstID.Value,hidStateID.Value,hidDistrictID.Value,hidTehsilID.Value,hidDOB.Value,hidLastName.Value,hidFirstName.Value,hidGender.Value);
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
			if(ds.Tables[0].Rows.Count>0)
			{


                if (sortExpression != null && sortExpression != "")
                {
                    if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == (sortExpression + ", StudentName"))
                    {
                        ViewState["SortExpression"] = sortExpression + " Desc, StudentName";
                    }
                    else
                    {
                        ViewState["SortExpression"] = sortExpression.Trim() + ", StudentName";
                    }

                    DataView DV = ds.Tables[0].DefaultView;
                    DV.Sort = ViewState["SortExpression"].ToString().Trim();
                    dgRegStudentList.DataSource = DV;
                    dgRegStudentList.DataBind();
                }
                else
                {


                    dgRegStudentList.DataSource = ds;
                    try
                    {
                        dgRegStudentList.DataBind();
                    }
                    catch
                    {
                        dgRegStudentList.CurrentPageIndex = 0;
                        dgRegStudentList.DataBind();
                    }
                }


				dgRegStudentList.Visible=true;
				tblDGRegStudentList.Style.Remove("display");
				tblDGRegStudentList.Style.Add("display","block");
				lblGridName.Text = "..:: List of Students whose Eligibility Status for Course(s) is to be Viewed ::..";
				lblGridName.Style.Remove("display");
				lblGridName.Style.Add("display","block");
				divDGNote.Style.Add("display","block");
			}
			else
			{
				dgRegStudentList.Visible=false;
				tblDGRegStudentList.Style.Remove("display");
				tblDGRegStudentList.Style.Add("display","none");
				lblGridName.Text = "The Eligibility of Student(s) searched for, is not yet processed...";
				lblGridName.Style.Remove("display");
				lblGridName.Style.Add("display","block");
				divDGNote.Style.Add("display","none");
			}

			ds.Clear();
			ds.Dispose();
			ds=null;

			
		}

		private void fnFillStateDistrictTaluka(string stateID,string districtID,string tehsilID)
		{
			clsCommon common = new clsCommon();
			DataTable dt;
			
			State_ID.Items.Clear();
			try
			{ 
				dt = clsState.displayAllStates("E");
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}

			common.fillDropDown(State_ID,dt,stateID,"State_Name","State_ID","---- Select ----");
			if(dt!=null) dt =null;

			District_ID.Items.Clear();
			try
			{
				dt=clsDistrict.stateWiseDistricts(State_ID.SelectedItem.Value,"E");
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}

			common.fillDropDown(District_ID,dt,districtID,"Text","Value","---- Select ----");
			if(dt!=null) dt =null;

			Tehsil_ID.Items.Clear();
			try
			{
				dt = clsTaluka.displayTalukaWithinDistrict(District_ID.SelectedItem.Value,"E");
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			common.fillDropDown(Tehsil_ID,dt,tehsilID,"Text","Value","---- Select ----");
			if(dt!=null) dt =null;

			if(common!=null)common=null;
		
		}

		

		protected void btnSearch_Click(object sender, System.EventArgs e)
        {
        //    Session["SState_ID"] = hidStateID.Value;            Commented on 29/09/2007 by Jyotsna 
        //    Session["SDistrict_ID"] = hidDistrictID.Value;
        //    Session["STehsil_ID"] = hidTehsilID.Value;
			string dob=txtDOB.Text.Trim();
			if(dob != "")
			{
				string[] arr=new string[3];
				arr=dob.Split('/');
				dob=arr[1]+'/'+arr[0]+'/'+arr[2];
			}
            //Session["DOB"]=dob;                        Commented on 29/09/2007 by Jyotsna
            //Session["Gender"]=ddlGender.SelectedItem.Value;
            //Session["LastName"]=txtLastName.Text.Trim();
            //Session["FirstName"]=txtFirstName.Text.Trim();
            hidDOB.Value = dob;
            hidGender.Value = ddlGender.SelectedItem.Value;
            hidLastName.Value = txtLastName.Text.Trim();
            hidFirstName.Value = txtFirstName.Text.Trim();

			
			dgRegStudentList.CurrentPageIndex = 0;
			fnDisplayDGRegStudentList("");
			
				
			
		}
        protected void dgRegStudentList_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            fnDisplayDGRegStudentList(e.SortExpression);
        }
		private void dgRegStudentList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName=="StudentDetails")
			{
                //Session["pk_Year"] = e.Item.Cells[3].Text.Trim();               Comented on 29/09/2007 By Jyotsna
                //Session["pk_Student_ID"] = e.Item.Cells[4].Text.Trim();

				hidpkYear.Value=e.Item.Cells[3].Text.Trim();
				hidpkStudentID.Value=e.Item.Cells[4].Text.Trim();
                hidElgFormNo.Value = hidUniID.Value + "-" + hidInstID.Value + "-" + hidpkYear.Value + "-" + e.Item.Cells[5].Text;
				Server.Transfer(strUrl);
			}
		}

		private void dgRegStudentList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgRegStudentList.CurrentPageIndex = e.NewPageIndex;
			fnDisplayDGRegStudentList("");
			
		}

		private void dgRegStudentList_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType!=ListItemType.Header && e.Item.ItemType!=ListItemType.Footer)
			{
				e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgRegStudentList.CurrentPageIndex*10) + 1);
				
			}
		}
	}
}
