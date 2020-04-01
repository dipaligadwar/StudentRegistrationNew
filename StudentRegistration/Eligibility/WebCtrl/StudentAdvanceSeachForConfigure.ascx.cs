using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Classes;

namespace StudentRegistration.Eligibility.WebCtrl
{
    public partial class StudentAdvanceSeachForConfigure : System.Web.UI.UserControl
    {
        #region Declaration of Variables
        protected System.Web.UI.HtmlControls.HtmlGenericControl CollegeGrid;
        protected System.Web.UI.HtmlControls.HtmlGenericControl divStudentList;
        protected System.Web.UI.HtmlControls.HtmlInputHidden hidCrMoLrnID;
        private string qstrNavigate;
        private string strUrl;
        private string gridType;
        DataSet dsDistricts = new DataSet();
        clsCommon Common = new clsCommon();
        #endregion

        #region Properties
        public string QstrNavigate
        {
            set
            {
                qstrNavigate = value;
            }
        }
        public string StrUrl
        {
            set
            {
                strUrl = value;
            }
        }
        public string GridType
        {
            set
            {
                gridType = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.clsCache.NoCache();

            Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods), this.Page);
            dgElgRegular.Visible = false;
            dgRegPendingStudents.Visible = false;
            lblGridName.Style.Remove("display");
            lblGridName.Style.Add("display", "none");
            divDGNote.Style.Remove("display");
            divDGNote.Style.Add("display", "none");          
            if (!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[4];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidElgFormNo;
                hid[3] = hidCrMoLrnPtrnID;
                
                Common.setHiddenVariables(ref hid);

                if(qstrNavigate == "back")
                {
                   
                    txtDOB.Text = hidDOB.Value;
                    for (int i = 0; i < ddlGender.Items.Count; i++)
                    {
                        if (ddlGender.Items[i].Value == hidGender.Value)
                            ddlGender.SelectedIndex = i;
                    }
                    //txtLastName.Text = Session["LastName"].ToString();                 Commented By Jyotsna on 29/09/2007
                    //txtFirstName.Text = Session["FirstName"].ToString();   
                   
                    txtLastName.Text = hidLastName.Value;
                    txtFirstName.Text = hidFirstName.Value;  
                   
                    FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidCrMoLrnPtrnID.Value);

                    //hidStateID.Value = Session["SState_ID"].ToString();               Commented By Jyotsna on 29/09/2007
                    //hidDistrictID.Value = Session["SDistrict_ID"].ToString();              
                    //hidTehsilID.Value = Session["STehsil_ID"].ToString();
                    //hidFacID.Value = Session["FacultyID"].ToString();
                    //hidCrID.Value = Session["CourseID"].ToString();
                    //hidCr_MLrnPtrnID.Value = Session["Cr_MLPtrnID"].ToString();

                    if (gridType == "IA")
                    {
                        //Session["ElgFormNo"] = null;          Commented By Jyotsna on 29/09/2007                  
                        hidElgFormNo.Value = "";
                        fnDisplayIAGrid();
                    }
                    if (gridType == "Reg")
                    {
                        //Session["pk_Year"] = null;      Commented By Jyotsna on 29/09/2007
                        //Session["pk_Student_ID"] = null;
                        hidpkYear.Value = "";
                        hidpkStudentID.Value = "";
                        fnDisplayRegGrid();
                    }

                }
                else
                {
                  
                    hidUniID.Value = UniversityPortal.clsGetSettings.UniversityID.ToString();
                    FillFaculty();
                }
            }
            else
            {
                hidUniID.Value = UniversityPortal.clsGetSettings.UniversityID.ToString();
                FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidCr_MLrnPtrnID.Value);
            }
        }

        private void fnDisplayIAGrid()
        {
            DataView dv = new DataView();
            DataSet ds = new DataSet();
            try
            {
                ds = Eligibility.clsEligibilityDBAccess.Fetch_IA_Student_List_Configure(UniversityPortal.clsGetSettings.UniversityID.ToString(), hidInstID.Value,hidFacID.Value, hidCrID.Value, hidCrMoLrnPtrnID.Value, hidCrPrID.Value,hidDOB.Value, hidLastName.Value,hidFirstName.Value, hidGender.Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            if(ds.Tables[0].Rows.Count > 0)
            {
                dv.Table = ds.Tables[0];
                if (ViewState["SortExpression"] != null)
                {
                    dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();
                }
                dgElgRegular.DataSource = dv;// ds;
                try
                {
                    dgElgRegular.DataBind();
                }
                catch
                {
                    dgElgRegular.CurrentPageIndex = 0;
                    dgElgRegular.DataBind();
                }
                dgElgRegular.Visible = true;
                tblDGElgRegular.Style.Remove("display");
                tblDGElgRegular.Style.Add("display", "block");
                lblGridName.Text = "List of uploaded students whose Eligiblity is yet to be processed.";
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");
                divDGNote.Style.Remove("display");
                divDGNote.Style.Add("display", "block");
                
            }
            else
            {
                dgElgRegular.Visible = false;
                tblDGElgRegular.Style.Remove("display");
                tblDGElgRegular.Style.Add("display", "none");
                lblGridName.Text = "The College(s) of Student(s) searched for, have not Uploaded the Admitted Students Data yet...";
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");
                divDGNote.Style.Remove("display");
                divDGNote.Style.Add("display", "none");
            }

            ds.Clear();
            ds.Dispose();
            ds = null;


        }

        private void fnDisplayRegGrid()
        {
            DataSet ds = new DataSet();
            try
            {
              // ds = Eligibility.clsEligibilityDBAccess.Fetch_Pending_Reg_Student_List(UniversityPortal.clsGetSettings.UniversityID.ToString(), Session["SInst_Type"].ToString(), Session["SInst_Name"].ToString(), Session["SState_ID"].ToString(), Session["SDistrict_ID"].ToString(), Session["STehsil_ID"].ToString(), Session["FacultyID"].ToString(), Session["CourseID"].ToString(), Session["CrMoLrnPtrnID"].ToString(), Session["CoursePartID"].ToString(), Session["DOB"].ToString(), Session["LastName"].ToString(), Session["FirstName"].ToString(), Session["Gender"].ToString());
                string str = Page.ToString();
                if (str == "ASP.eligibility_reg_pendingstudenteligibility_aspx")
                {
                    ds = Eligibility.clsEligibilityDBAccess.Fetch_Pending_Reg_Student_List_Resolve(UniversityPortal.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnPtrnID.Value, hidCrPrID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value);
                    lblGridName.Text = "List of students whose Eligiblity is kept pending.";
                }
                else if (str == "ASP.eligibility_reg_resolveprovisionaleligibility_aspx")
                {
                    ds = Eligibility.clsEligibilityDBAccess.Fetch_ProvisionallyEligible_Reg_Student_List_Resolve(UniversityPortal.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnPtrnID.Value, hidCrPrID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value);
                    lblGridName.Text = "List of students whose Eligiblity is kept provisional.";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgRegPendingStudents.DataSource = ds;
                try
                {
                    dgRegPendingStudents.DataBind();
                }
                catch
                {
                    dgRegPendingStudents.CurrentPageIndex = 0;
                    dgRegPendingStudents.DataBind();
                }
                dgRegPendingStudents.Visible = true;
                tblDGRegPendingStudents.Style.Remove("display");
                tblDGRegPendingStudents.Style.Add("display", "block");
                //lblGridName.Text="..:: Available "+rdbtnInstType.SelectedItem.Text+"(s) ::..";
                
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");
                divDGNote.Style.Remove("display");
                divDGNote.Style.Add("display", "block");
            }
            else
            {
                dgRegPendingStudents.Visible = false;
                tblDGRegPendingStudents.Style.Remove("display");
                tblDGRegPendingStudents.Style.Add("display", "none");
                lblGridName.Text = "There are no Students satisfying the above search criteria whose Eligibility is kept Pending...";
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");
                divDGNote.Style.Remove("display");
                divDGNote.Style.Add("display", "none");
            }

            ds.Clear();
            ds.Dispose();
            ds = null;


        }      
        
        public void FillFaculty()
        {
            DataTable oDT = new DataTable();
            try
            {
               // ds = Eligibility.elgDBAccess.GetAllFaculties(Convert.ToInt32(UniversityPortal.clsGetSettings.UniversityID.ToString()));
                oDT = Classes.InstituteRepository.AssignedConfirmedFaculties(hidUniID.Value, hidInstID.Value);
                /*DataRow dr = ds.Tables[0].NewRow();
                dr[0] = Convert.ToString("---Select---");
                dr[1] = Convert.ToInt64(0);
                ds.Tables[0].Rows.InsertAt(dr, 0);
                ddlFaculty.DataSource = ds.Tables[0];
                ddlFaculty.DataTextField = "Fac_Desc";
                ddlFaculty.DataValueField = "pk_Fac_ID";
                ddlFaculty.DataBind();*/
                Common.fillDropDown(ddlFaculty, oDT, "", "Fac_Desc", "pk_Fac_ID", "------ Select ------");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }

        public void FillFacultyWiseCourseCoursePart(string FacID, string CrID, string CrMLPtrnID)
        {
            clsCommon common = new clsCommon();
            DataSet ds;
            DataTable dt;
            ddlFaculty.Items.Clear();
            try
            {
                
                ds = Eligibility.elgDBAccess.GetAllFaculties(Convert.ToInt32(UniversityPortal.clsGetSettings.UniversityID.ToString()));
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            common.fillDropDown(ddlFaculty, dt, FacID, "Fac_Desc", "pk_Fac_ID", "---- Select ----");

            ddlCourse.Items.Clear();

            try
            {
                ds = Eligibility.elgDBAccess.selFacultyWiseAllCourses(Convert.ToInt32(UniversityPortal.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(FacID));
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            common.fillDropDown(ddlCourse, dt, CrID, "Course", "CourseID", "---- Select ----");

            ddlCoursePart.Items.Clear();
            try
            {
                ds = Eligibility.elgDBAccess.selAllCoursePart(Convert.ToInt32(UniversityPortal.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(FacID), Convert.ToInt32(CrID));
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            common.fillDropDown(ddlCoursePart, dt, CrMLPtrnID, "CrPr_Desc", "Cr_MLPtrnID", "---- Select ----");
            if (common != null) common = null;
            ds.Dispose();
            dt.Dispose();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Session["SInst_Type"] = rdbtnInstType.SelectedValue;
           // Session["SInst_Name"] = Inst_Name.Text.Trim();
           /* Session["SInst_Type"] = "0";
            Session["SInst_Name"] = "";
            Session["SState_ID"] = hidStateID.Value;
            Session["SDistrict_ID"] = hidDistrictID.Value;
            Session["STehsil_ID"] = hidTehsilID.Value;*/

            //Session["FacultyID"] = hidFacID.Value;         Commented by Jyotsna on 29/09/2007 to avoid the use of session variables
            //Session["CourseID"] = hidCrID.Value;
            //Session["CoursePartID"] = hidCrPrID.Value;
            //Session["CrMoLrnPtrnID"] = hidCrMoLrnPtrnID.Value;
            //Session["Cr_MLPtrnID"] = hidCr_MLrnPtrnID.Value;

            string dob = txtDOB.Text.Trim();
            if (dob != "")
            {
                string[] arr = new string[3];
                arr = dob.Split('/');
                dob = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            //Session["DOB"] = dob;                  Commented by Jyotsna on 29/09/2007 to avoid the use of session variables
            //Session["Gender"] = ddlGender.SelectedItem.Value;
            //Session["LastName"] = txtLastName.Text.Trim();
            //Session["FirstName"] = txtFirstName.Text.Trim();

            hidDOB.Value = dob;
            hidGender.Value = ddlGender.SelectedItem.Value;
            hidLastName.Value = txtLastName.Text.Trim();
            hidFirstName.Value = txtFirstName.Text.Trim();

            if (gridType == "IA")
            {
                dgElgRegular.CurrentPageIndex = 0;
                fnDisplayIAGrid();
            }
            if (gridType == "Reg")
            {
                dgRegPendingStudents.CurrentPageIndex = 0;
                fnDisplayRegGrid();
            }
				
        }

        protected void dgElgRegular_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {
                //Session["ElgFormNo"] = e.Item.Cells[1].Text.Trim();
                //Session["pk_CrMoLrnPtrn_ID"]=e.Item.Cells[6].Text.Trim();
                hidElgFormNo.Value = e.Item.Cells[1].Text.Trim();
                hidCrMoLrnPtrnID.Value = e.Item.Cells[6].Text.Trim();
                Server.Transfer(strUrl);
            }

        }

        protected void dgElgRegular_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgElgRegular.CurrentPageIndex * 10) + 1);
            }
        }

        protected void dgElgRegular_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgElgRegular.CurrentPageIndex = e.NewPageIndex;
            fnDisplayIAGrid();
        }

        protected void dgElgRegular_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                if (ViewState["SortOrder"].ToString() == " asc")
                    ViewState["SortOrder"] = " desc";
                else
                    ViewState["SortOrder"] = " asc";
            }
            else
            {
                ViewState["SortExpression"] = e.SortExpression;
                ViewState["SortOrder"] = " asc";
            }

            fnDisplayIAGrid();
        }

        protected void dgRegPendingStudents_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "PendingStudentDetails")
            {
                //Commented by Liwia
                // 				Session["ElgFormNo"] = e.Item.Cells[1].Text.Trim();
                             
                //     Session["pk_CrMoLrnPtrn_ID"]=e.Item.Cells[8].Text.Trim();
                //added by liwia
                //     hidUniID.Value=ConfigurationSettings.AppSettings["UniversityID"].ToString();


                //Session["pk_Year"] = e.Item.Cells[6].Text.Trim();       Commented By Jyotsna on 29/09/2007
                //Session["pk_Student_ID"] = e.Item.Cells[7].Text.Trim();
               

                hidElgFormNo.Value = e.Item.Cells[1].Text.Trim();
                hidpkYear.Value = e.Item.Cells[6].Text.Trim();
                hidpkStudentID.Value = e.Item.Cells[7].Text.Trim();
                hidCrMoLrnPtrnID.Value = e.Item.Cells[8].Text.Trim();
                //Common.setHiddenVariables(ref hid);
                //end
                Server.Transfer(strUrl);
            }
        }

        protected void dgRegPendingStudents_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            dgRegPendingStudents.CurrentPageIndex = e.NewPageIndex;
            fnDisplayRegGrid();
        }

        protected void dgRegPendingStudents_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgElgRegular.CurrentPageIndex * 10) + 1);

            }
        }


    }
}