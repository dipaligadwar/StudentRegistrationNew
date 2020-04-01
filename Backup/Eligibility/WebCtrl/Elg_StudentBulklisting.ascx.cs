namespace StudentRegistration.Eligibility.WebCtrl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Configuration;
	using Classes;

	/// <summary>
	///		Summary description for Elg_StudentBulklisting.
	/// </summary>
	public partial class Elg_StudentBulklisting : System.Web.UI.UserControl
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl CollegeGrid;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divStudentList;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCrMoLrnID;
		private string qstrNavigate;
		private string strUrl;
		private string gridType;
		DataSet dsDistricts = new DataSet();
		public DataSet ds=new DataSet();

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
		}
		public string GridType
		{
			set
			{
				gridType = value;
			}
		}
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
            Classes.clsCache.NoCache();

			Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods),this.Page);
			dgElgRegular.Visible=false;
			lblGridName.Style.Remove("display");
			lblGridName.Style.Add("display","none");
			divDGNote.Style.Remove("display");
			divDGNote.Style.Add("display","none");
			//Search college
			if(!IsPostBack)
			{
				
				if(qstrNavigate == "back")
				{
					Inst_Name.Text = Session["SInst_Name"].ToString();
					txtDOB.Text = Session["DOB"].ToString();
					for(int i=0; i<ddlGender.Items.Count; i++)
					{
						if(ddlGender.Items[i].Value == Session["Gender"].ToString())
							ddlGender.SelectedIndex = i;
					}
					txtLastName.Text = Session["LastName"].ToString();
					txtFirstName.Text = Session["FirstName"].ToString();
					fnFillInstType(Session["SInst_Type"].ToString());
					fnFillStateDistrictTaluka(Session["SState_ID"].ToString(),Session["SDistrict_ID"].ToString(),Session["STehsil_ID"].ToString());
					//FillFaculty();
					FillFacultyWiseCourseCoursePart(Session["FacultyID"].ToString(),Session["CourseID"].ToString(),Session["Cr_MLPtrnID"].ToString());
					
					hidStateID.Value = Session["SState_ID"].ToString();
					hidDistrictID.Value = Session["SDistrict_ID"].ToString();
					hidTehsilID.Value = Session["STehsil_ID"].ToString();
					hidFacID.Value = Session["FacultyID"].ToString();
					hidCrID.Value = Session["CourseID"].ToString();
					hidCr_MLrnPtrnID.Value = Session["Cr_MLPtrnID"].ToString();
					
					if(gridType == "IA")
					{
						Session["ElgFormNo"] = null;
						//						Session["pk_CrMoLrnPtrn_ID"] = null;
						fnDisplayIAGrid();
					}
					
				}
				else
				{
					//Session["Navigate"] = "";
					fnFillInstType("");
					fnFillStateDistrictTaluka("","","");
					//fnFillStateDistrictTaluka(hidStateID.Value,hidDistrictID.Value,hidTehsilID.Value);
					hidUniID.Value = ConfigurationSettings.AppSettings["UniversityID"].ToString();                   
					//FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidCr_MLrnPtrnID.Value);
					FillFaculty();
					//FillFacultyWiseCourseCoursePart("", "", "");
				}
			}
			else
			{
				//Session["Navigate"] = "";
				//fnFillInstType("");
				//fnFillStateDistrictTaluka("","","");

				fnFillStateDistrictTaluka(hidStateID.Value,hidDistrictID.Value,hidTehsilID.Value);
				hidUniID.Value=ConfigurationSettings.AppSettings["UniversityID"].ToString();
				FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidCr_MLrnPtrnID.Value);
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
			this.dgElgRegular.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgElgRegular_ItemCommand);
			this.dgElgRegular.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgElgRegular_PageIndexChanged);
			this.dgElgRegular.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgElgRegular_ItemDataBound);

		}
		#endregion

		private void fnDisplayIAGrid()
		{
			DataSet ds=new DataSet();
			try
			{
				ds=Eligibility.clsEligibilityDBAccess.Fetch_IA_Student_List(ConfigurationSettings.AppSettings["UniversityID"].ToString(),Session["SInst_Type"].ToString(),Session["SInst_Name"].ToString(),Session["SState_ID"].ToString(),Session["SDistrict_ID"].ToString(),Session["STehsil_ID"].ToString(),Session["FacultyID"].ToString(),Session["CourseID"].ToString(),Session["CrMoLrnPtrnID"].ToString(),Session["CoursePartID"].ToString(),Session["DOB"].ToString(),Session["LastName"].ToString(),Session["FirstName"].ToString(),Session["Gender"].ToString());
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
			if(ds.Tables[0].Rows.Count>0)
			{
				dgElgRegular.DataSource = ds;
				try
				{
					dgElgRegular.DataBind();
				}
				catch
				{
					dgElgRegular.CurrentPageIndex = 0;
					dgElgRegular.DataBind();
				}
				dgElgRegular.Visible=true;
				tblDGElgRegular.Style.Remove("display");
				tblDGElgRegular.Style.Add("display","block");
				//lblGridName.Text="..:: Available "+rdbtnInstType.SelectedItem.Text+"(s) ::..";
				lblGridName.Text = "..:: List of Uploaded Students whose Eligiblity is yet to be Processed ::..";
				lblGridName.Style.Remove("display");
				lblGridName.Style.Add("display","block");
				divDGNote.Style.Remove("display");
				divDGNote.Style.Add("display","block");
			}
			else
			{
				dgElgRegular.Visible=false;
				tblDGElgRegular.Style.Remove("display");
				tblDGElgRegular.Style.Add("display","none");
				lblGridName.Text = "The College(s) of Student(s) searched for, have not Uploaded the Admitted Students Data yet...";
				lblGridName.Style.Remove("display");
				lblGridName.Style.Add("display","block");
				divDGNote.Style.Remove("display");
				divDGNote.Style.Add("display","none");
			}

			ds.Clear();
			ds.Dispose();
			ds=null;

			
		}

		
		private void fnFillInstType(string sValue)
		{
			DataTable dt;
			int flag;
			try
			{
				dt = clsInstituteType.AllInstituteTypes();
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			flag = fillRadioList(rdbtnInstType,dt,sValue,"InstTy_Name","pk_InstTy_ID");
			if(dt!=null)dt=null;
			
			rdbtnInstType.Items.Insert(0,new ListItem("Any Type","0"));
			//if(Request.QueryString["status"] == "" || Request.QueryString["status"] == null)
			if(flag == 0)
			{
				rdbtnInstType.ClearSelection();
				rdbtnInstType.Items[0].Selected=true;
			}
		}

		public int fillRadioList(RadioButtonList rdList,DataTable dt ,string selectedID,string textColumnName,string valueColumnName)
		{
			int flag = 0;
			rdList.SelectedIndex=-1;
			if(dt.Rows.Count>0)
			{
				rdList.DataSource=dt;
				if(valueColumnName!=null && valueColumnName!="")
					rdList.DataValueField=valueColumnName;
				else
					rdList.DataValueField=textColumnName;

				rdList.DataTextField=textColumnName;
				rdList.DataBind();
				ListItem li= rdList.Items.FindByValue(selectedID);
				if(li!=null)
				{
					flag = 1;
					li.Selected=true;
				}
				else
				{
					rdList.Items[0].Selected=true;
					flag = 0;
				}
				
			}
			return flag;
			/*else
			{
				rdList.Items.Insert(0,new ListItem("--No Value--","0"));
			}*/
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

		public void FillFaculty()
		{
			DataSet ds;
			try
			{
				ds=Eligibility.elgDBAccess.GetAllFaculties(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"].ToString()));
                DataRow dr = ds.Tables[0].NewRow();
				dr[0]=Convert.ToString("---Select---");
				dr[1]=Convert.ToInt64(0);
				ds.Tables[0].Rows.InsertAt(dr,0);
				ddlFaculty.DataSource=ds.Tables[0];
				ddlFaculty.DataTextField="Fac_Desc";
				ddlFaculty.DataValueField="pk_Fac_ID";
				ddlFaculty.DataBind();
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			ds.Dispose();

		}

		public void FillFacultyWiseCourseCoursePart(string FacID,string CrID ,string CrMLPtrnID)
		{
			clsCommon common = new clsCommon();
			DataSet ds;
			DataTable dt ;
			ddlFaculty.Items.Clear();
			try
			{
				ds = Eligibility.elgDBAccess.GetAllFaculties(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"].ToString()));
				dt=ds.Tables[0];
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			common.fillDropDown(ddlFaculty,dt,FacID,"Fac_Desc","pk_Fac_ID","---- Select ----");

			ddlCourse.Items.Clear();
			 
			try
			{
				ds = Eligibility.elgDBAccess.selFacultyWiseAllCourses(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"].ToString()),Convert.ToInt32(FacID));
				dt=ds.Tables[0];
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			common.fillDropDown(ddlCourse,dt,CrID,"Course","CourseID","---- Select ----");

			ddlCoursePart.Items.Clear();
			try
			{
				ds = Eligibility.elgDBAccess.selAllCoursePart(Convert.ToInt32(ConfigurationSettings.AppSettings["UniversityID"].ToString()),Convert.ToInt32(FacID),Convert.ToInt32(CrID));
				dt=ds.Tables[0];
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			common.fillDropDown(ddlCoursePart,dt,CrMLPtrnID,"CrPr_Desc","Cr_MLPtrnID","---- Select ----");
			if(common!=null)common=null;
			ds.Dispose();
			dt.Dispose();
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			Session["SInst_Type"] = rdbtnInstType.SelectedValue;
			Session["SInst_Name"] = Inst_Name.Text.Trim();
			Session["SState_ID"] = hidStateID.Value;
			Session["SDistrict_ID"] = hidDistrictID.Value;
			Session["STehsil_ID"] = hidTehsilID.Value;
			Session["FacultyID"]=hidFacID.Value;
			Session["CourseID"]=hidCrID.Value;
			Session["CoursePartID"]=hidCrPrID.Value;
			Session["CrMoLrnPtrnID"]=hidCrMoLrnPtrnID.Value;
			Session["Cr_MLPtrnID"]=hidCr_MLrnPtrnID.Value;
			string dob=txtDOB.Text.Trim();
			if(dob != "")
			{
				string[] arr=new string[3];
				arr=dob.Split('/');
				dob=arr[1]+'/'+arr[0]+'/'+arr[2];
			}
			Session["DOB"]=dob;
			Session["Gender"]=ddlGender.SelectedItem.Value;
			Session["LastName"]=txtLastName.Text.Trim();
			Session["FirstName"]=txtFirstName.Text.Trim();
			if(gridType == "IA")
			{
				dgElgRegular.CurrentPageIndex = 0;
				fnDisplayIAGrid();
			}
		}

		private void dgElgRegular_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName=="StudentDetails")
			{
				Session["ElgFormNo"] = e.Item.Cells[1].Text.Trim();
				//Session["pk_CrMoLrnPtrn_ID"]=e.Item.Cells[6].Text.Trim();
				hidElgFormNo.Value=e.Item.Cells[1].Text.Trim();
				hidCrMoLrnPtrnID.Value=e.Item.Cells[6].Text.Trim();
				Server.Transfer(strUrl);
			}
		}

		private void dgElgRegular_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				((CheckBox)(e.Item.Cells[7].FindControl("SelectAll"))).Attributes.Add("onclick","CheckAll('"+ dgElgRegular.PageSize+"','dgElgRegular',"+"'SelectAll','Select')");
			}
			if(e.Item.ItemType!=ListItemType.Header && e.Item.ItemType!=ListItemType.Footer)
			{
				e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgElgRegular.CurrentPageIndex*10) + 1);
				((CheckBox)(e.Item.Cells[7].FindControl("Select"))).Attributes.Add("onclick","Checkone('"+ dgElgRegular.PageSize+"','dgElgRegular',"+"'SelectAll','Select')");
			}
		}

		private void dgElgRegular_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgElgRegular.CurrentPageIndex=e.NewPageIndex;
			fnDisplayIAGrid();
		}

		private void dgRegPendingStudents_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName=="PendingStudentDetails")
			{
				//Commented by Liwia
				// 				Session["ElgFormNo"] = e.Item.Cells[1].Text.Trim();
				Session["pk_Year"] = e.Item.Cells[6].Text.Trim();
				Session["pk_Student_ID"]=e.Item.Cells[7].Text.Trim();
				//				Session["pk_CrMoLrnPtrn_ID"]=e.Item.Cells[8].Text.Trim();
				//added by liwia
				//				hidUniID.Value=ConfigurationSettings.AppSettings["UniversityID"].ToString();
				hidElgFormNo.Value=e.Item.Cells[1].Text.Trim();
				hidpkYear.Value = e.Item.Cells[6].Text.Trim();
				hidpkStudentID.Value = e.Item.Cells[7].Text.Trim();
				hidCrMoLrnPtrnID.Value = e.Item.Cells[8].Text.Trim();
				//Common.setHiddenVariables(ref hid);
				//end
				Server.Transfer(strUrl);
			}
		}

		

		

		protected void dgElgRegular_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void btndecision_Click(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
