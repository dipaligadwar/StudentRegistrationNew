using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace StudentRegistration.Eligibility.WebCtrl
{
	
	/// <summary>
	///		Summary description for StudentAdvancedSearch.
	/// </summary>
	public partial class StudentsAdvancedSearch : System.Web.UI.UserControl
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl CollegeGrid;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divStudentList;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCrMoLrnID;
		private string qstrNavigate;
		private string strUrl;
		private string gridType;
		DataSet dsDistricts = new DataSet();
        clsCache clsCache = new clsCache();
        clsState clsState = new clsState();
        clsTaluka clsTaluka = new clsTaluka();
        clsDistrict clsDistrict = new clsDistrict();


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
            clsCache.NoCache();

			Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods),this.Page);
			dgElgRegular1.Visible=false;
			dgRegPendingStudents1.Visible=false;
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
					if(gridType == "Reg")
					{
//						Session["ElgFormNo"] = null;
						Session["pk_Year"] = null;
						Session["pk_Student_ID"]=null;
//						Session["pk_CrMoLrnPtrn_ID"]=null;
						fnDisplayRegGrid();
					}
				
				}
				else
				{
					//Session["Navigate"] = "";
					fnFillInstType("");
					fnFillStateDistrictTaluka("","","");
					//fnFillStateDistrictTaluka(hidStateID.Value,hidDistrictID.Value,hidTehsilID.Value);
					hidUniID.Value= Classes.clsGetSettings.UniversityID.ToString();
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
				hidUniID.Value= Classes.clsGetSettings.UniversityID.ToString();
				FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidCr_MLrnPtrnID.Value);
			}

		}

		

		private void fnDisplayIAGrid()
		{
			DataSet ds=new DataSet();
			try
			{
				ds=Eligibility.clsEligibilityDBAccess.Fetch_IA_Student_List(Classes.clsGetSettings.UniversityID.ToString(),Session["SInst_Type"].ToString(),Session["SInst_Name"].ToString(),Session["SState_ID"].ToString(),Session["SDistrict_ID"].ToString(),Session["STehsil_ID"].ToString(),Session["FacultyID"].ToString(),Session["CourseID"].ToString(),Session["CrMoLrnPtrnID"].ToString(),Session["CoursePartID"].ToString(),Session["DOB"].ToString(),Session["LastName"].ToString(),Session["FirstName"].ToString(),Session["Gender"].ToString());
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
			if(ds.Tables[0].Rows.Count>0)
			{
				dgElgRegular1.DataSource = ds;
				try
				{
					dgElgRegular1.DataBind();
				}
				catch
				{
					dgElgRegular1.PageIndex = 0;
					dgElgRegular1.DataBind();
				}
				dgElgRegular1.Visible=true;
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
				dgElgRegular1.Visible=false;
				tblDGElgRegular.Style.Remove("display");
				tblDGElgRegular.Style.Add("display","none");
				lblGridName.Text = "The "+ lblCollege.Text +"(s) of Student(s) searched for, have not Uploaded the Admitted Students Data yet...";
				lblGridName.Style.Remove("display");
				lblGridName.Style.Add("display","block");
				divDGNote.Style.Remove("display");
				divDGNote.Style.Add("display","none");
			}

			ds.Clear();
			ds.Dispose();
			ds=null;

			
		}

		private void fnDisplayRegGrid()
		{
			DataSet ds=new DataSet();
			try
			{
				ds=Eligibility.clsEligibilityDBAccess.Fetch_Pending_Reg_Student_List(Classes.clsGetSettings.UniversityID.ToString(),Session["SInst_Type"].ToString(),Session["SInst_Name"].ToString(),Session["SState_ID"].ToString(),Session["SDistrict_ID"].ToString(),Session["STehsil_ID"].ToString(),Session["FacultyID"].ToString(),Session["CourseID"].ToString(),Session["CrMoLrnPtrnID"].ToString(),Session["CoursePartID"].ToString(),Session["DOB"].ToString(),Session["LastName"].ToString(),Session["FirstName"].ToString(),Session["Gender"].ToString());
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
			if(ds.Tables[0].Rows.Count>0)
			{
				dgRegPendingStudents1.DataSource = ds;
				try
				{
					dgRegPendingStudents1.DataBind();
				}
				catch
				{
					dgRegPendingStudents1.PageIndex = 0;
					dgRegPendingStudents1.DataBind();
				}
				dgRegPendingStudents1.Visible=true;
				tblDGRegPendingStudents.Style.Remove("display");
				tblDGRegPendingStudents.Style.Add("display","block");
				//lblGridName.Text="..:: Available "+rdbtnInstType.SelectedItem.Text+"(s) ::..";
				lblGridName.Text = "..:: List of Students whose Eligiblity is kept Pending ::..";
				lblGridName.Style.Remove("display");
				lblGridName.Style.Add("display","block");
				divDGNote.Style.Remove("display");
				divDGNote.Style.Add("display","block");
			}
			else
			{
				dgRegPendingStudents1.Visible=false;
				tblDGRegPendingStudents.Style.Remove("display");
				tblDGRegPendingStudents.Style.Add("display","none");
				lblGridName.Text = "There are no Students satisfying the above search criteria whose Eligibility is kept Pending...";
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
				dt = clsState.DisplayAllStates("E");
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}

			common.fillDropDown(State_ID,dt,stateID,"State_Name","State_ID","--- Select ---");
			if(dt!=null) dt =null;

			District_ID.Items.Clear();
			try
			{
				dt=clsDistrict.StateWiseDistricts(State_ID.SelectedItem.Value,"E");
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}

			common.fillDropDown(District_ID,dt,districtID,"Text","Value","--- Select ---");
			if(dt!=null) dt =null;

			Tehsil_ID.Items.Clear();
			try
			{
				dt = clsTaluka.DisplayTalukaWithinDistrict(District_ID.SelectedItem.Value,"E");
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			common.fillDropDown(Tehsil_ID,dt,tehsilID,"Text","Value","--- Select ---");
			if(dt!=null) dt =null;

			if(common!=null)common=null;
		
		}

		public void FillFaculty()
		{
			DataSet ds;
			try
			{
				ds=Eligibility.elgDBAccess.GetAllFaculties(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()));
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
				ds = Eligibility.elgDBAccess.GetAllFaculties(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()));
				dt=ds.Tables[0];
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			common.fillDropDown(ddlFaculty,dt,FacID,"Fac_Desc","pk_Fac_ID","--- Select ---");

			ddlCourse.Items.Clear();
			 
			try
			{
				ds = Eligibility.elgDBAccess.selFacultyWiseAllCourses(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()),Convert.ToInt32(FacID));
				dt=ds.Tables[0];
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			common.fillDropDown(ddlCourse,dt,CrID,"Course","CourseID","--- Select ---");

			ddlCoursePart.Items.Clear();
			try
			{
				ds = Eligibility.elgDBAccess.selAllCoursePart(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()),Convert.ToInt32(FacID),Convert.ToInt32(CrID));
				dt=ds.Tables[0];
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			common.fillDropDown(ddlCoursePart,dt,CrMLPtrnID,"CrPr_Desc","Cr_MLPtrnID","--- Select ---");
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
				dgElgRegular1.PageIndex = 0;
				fnDisplayIAGrid();
			}
			if(gridType == "Reg")
			{
				dgRegPendingStudents1.PageIndex = 0;
				fnDisplayRegGrid();
			}

        }

        # region Commented by Jatin
        
        #region dgElgRegular

        /*		private void dgElgRegular_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName=="StudentDetails")
			{
				Session["ElgFormNo"] = e.Item.Cells[1].Text.Trim();
				//Session["pk_CrMoLrnPtrn_ID"]=e.Item.Cells[6].Text.Trim();
				hidElgFormNo.Value=e.Item.Cells[1].Text.Trim();
				hidCrMoLrnPtrnID.Value=e.Item.Cells[6].Text.Trim();
				Server.Transfer(strUrl);
			}
		}*/

	/*	private void dgElgRegular_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType!=ListItemType.Header && e.Item.ItemType!=ListItemType.Footer)
			{
				e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgElgRegular.CurrentPageIndex*10) + 1);
			}
		}*/

/*		private void dgElgRegular_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgElgRegular.CurrentPageIndex=e.NewPageIndex;
			fnDisplayIAGrid();
		}
        */
		#endregion
        #region dgRegPendingStudents        
        
        /*      private void dgRegPendingStudents_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
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
		}*/

	/*	private void dgRegPendingStudents_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgRegPendingStudents.CurrentPageIndex = e.NewPageIndex;
			fnDisplayRegGrid();
		}*/

        /*	private void dgRegPendingStudents_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
            {
                if(e.Item.ItemType!=ListItemType.Header && e.Item.ItemType!=ListItemType.Footer)
                {
                    e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgElgRegular.CurrentPageIndex*10) + 1);
				
                }
            }*/
        #endregion
        # endregion Commented by Jatin

        #region GridView Events        
        
        #region dgElgRegular1_RowDataBound
        protected void dgElgRegular1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[6].Style.Add("display", "none");
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[6].Style.Add("display", "none");
            }
        }
        #endregion        

        #region dgElgRegular1_RowCommand
        protected void dgElgRegular1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgElgRegular1.Rows[index];

                Session["ElgFormNo"] = row.Cells[1].Text.Trim();
                hidElgFormNo.Value = row.Cells[1].Text.Trim();
                hidCrMoLrnPtrnID.Value = row.Cells[6].Text.Trim();
                Server.Transfer(strUrl);
            }
        }
        #endregion
        

        #region dgElgRegular1_PageIndexChanging
        protected void dgElgRegular1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            dgElgRegular1.PageIndex = e.NewPageIndex;
            //dgElgRegular1.DataBind();
            fnDisplayIAGrid();
        }
        #endregion

        #region dgRegPendingStudents1_RowDataBound
        protected void dgRegPendingStudents1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
            }
        }
        #endregion        

        #region dgRegPendingStudents1_RowCommand
        protected void dgRegPendingStudents1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PendingStudentDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgRegPendingStudents1.Rows[index];

                Session["pk_Year"] = row.Cells[6].Text.Trim();
                Session["pk_Student_ID"] = row.Cells[7].Text.Trim();
                hidElgFormNo.Value = row.Cells[1].Text.Trim();
                hidpkYear.Value = row.Cells[6].Text.Trim();
                hidpkStudentID.Value = row.Cells[7].Text.Trim();
                hidCrMoLrnPtrnID.Value = row.Cells[8].Text.Trim();
                Server.Transfer(strUrl);
            }

        }
        #endregion        

        #region dgRegPendingStudents1_PageIndexChanging
        protected void dgRegPendingStudents1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            dgRegPendingStudents1.PageIndex = e.NewPageIndex;
            //dgRegPendingStudents1.DataBind();
            fnDisplayRegGrid();
        }
        #endregion
        #endregion
        
	}
}
