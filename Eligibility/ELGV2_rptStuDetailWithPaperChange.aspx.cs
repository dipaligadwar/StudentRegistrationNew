using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Classes;
using AjaxControlToolkit;
using StudentRegistration.Eligibility.ElgClasses;
using Microsoft.Reporting.WebForms;
using System.Text.RegularExpressions;
using System.Web;
using System.Globalization;
using System.Threading;
using System.Configuration;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptStuDetailWithPaperChange : System.Web.UI.Page
    {
        #region Variable declaration
        clsCommon Common = new clsCommon();
        CourseRepository crRepository = new CourseRepository();
        DataTable oDT;
        clsUser user;
        private string[] IDs_List = new string[3];
        InstituteRepository oInstituteRepository = new InstituteRepository();
        clsCollegeAdmissionReports oCollegeAdmissionReports;
        private string Elg_FormNo;
        string PRNumber = null;
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)    
        {
             //Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent), this.Page);
             Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent), this.Page);
            user = (clsUser)Session["user"];
            DataTable dtInst = new DataTable();
            if (!IsPostBack)
            {

                lblPageHead.Text = "Student Details With "+ lblPaper.Text+" Change";
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();

                if (user.UserTypeCode == "2")
                {
                    hidInstID.Value = user.UserReferenceID;
                    hidCollName.Value = user.Name;
                    hidUserType.Value = "2";

                }
                else
                    hidUserType.Value = "1";

                #region For Academic year
                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                ViewState["AcademicYear"] = dt;
                Common.fillDropDown(ddlAcademicYr, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                ddlAcademicYr.SelectedIndex = 0;
                hid_AcademicYear.Value = ddlAcademicYr.SelectedItem.Text;
                try
                {
                    hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
                }
                catch
                {
                    hidIsPRNValidationRequired.Value = "N";
                }

                #endregion
                fnFirstFill();
                //DisplyFromSession();
            }

        }
        #endregion

        #region fnFirstFill

        private void fnFirstFill()
        {
            if (user.UserTypeCode != "2")
            {
                FetchUniversityWiseFacultyList(ddlFacDesc);
            }
            if (user.UserTypeCode == "2")
            {
                FetchCollegeWiseConfirmedFacultyList(hidUniID.Value, hidInstID.Value);
            }
        }

        #endregion

        #region Fetch University Wise Faculty List

        public void FetchUniversityWiseFacultyList(DropDownList ddlFacDesc)
        {

            DataTable listFaculty = crRepository.LaunchedUniversityWiseFacultyList(Convert.ToInt64(hidUniID.Value.ToString()));
            try
            {
                if (listFaculty != null)
                {
                    ddlFacDesc.DataSource = listFaculty;
                    ddlFacDesc.DataTextField = "text";
                    ddlFacDesc.DataValueField = "value";
                    ddlFacDesc.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--- Select ---", "-1");
                    ddlFacDesc.Items.Insert(0, li);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Fetch College wise Assigned Confirmed Faculties

        public void FetchCollegeWiseConfirmedFacultyList(string UniID, string InstID)
        {

            DataTable listFaculty = oInstituteRepository.AssignedConfirmedFaculties(hidUniID.Value.ToString(), hidInstID.Value);
            try
            {
                if (listFaculty != null)
                {
                    ddlFacDesc.DataSource = listFaculty;
                    ddlFacDesc.DataTextField = "Fac_Desc";
                    ddlFacDesc.DataValueField = "pk_Fac_ID";
                    ddlFacDesc.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--- Select ---", "-1");
                    ddlFacDesc.Items.Insert(0, li);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Dropdown Events
        protected void ddlFacDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCrBrnDesc.Items.Clear();
            ddlCrPrDetailsDesc.Items.Clear();
            ddlCrPrChDesc.Items.Clear();
            if (user.UserTypeCode != "2")
            {
                hidInstID.Value = string.Empty;
            }

            ddlCrBrnDesc.Items.Insert(0, new ListItem("--- Select ---", "-1"));
            ddlCrPrDetailsDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));

            FillFacultyCourseMoLrnPatternName(hidUniID.Value, hidInstID.Value, ddlFacDesc.SelectedValue);

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlFacDesc);
        }
        protected void ddlCrDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCrPrDetailsDesc.Items.Clear();
            ddlCrPrChDesc.Items.Clear();
            if (user.UserTypeCode != "2")
            {
                hidInstID.Value = string.Empty;
            }

            ddlCrPrDetailsDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));

            ////Call for Seting FacultyID , CourseID ,MoLrnID and PatternID
            getFacCrMoLrnPtrnID();

            ////This will Fill Correspondance Branch Drop Down
            FillBranch(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value);

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrDesc);
        }
        protected void ddlCrBrnDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCrPrChDesc.Items.Clear();

            ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
            getFacCrMoLrnPtrnID();

            FillCoursePart(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(ddlCrBrnDesc.SelectedValue));
            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrBrnDesc);
        }
        protected void ddlCrPrDetailsDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            getFacCrMoLrnPtrnID();

            ////This will Fill Correspondance Course Part Term Details Drop Down
            FillPartTerm(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(ddlCrBrnDesc.SelectedItem.Value), Convert.ToString(ddlCrPrDetailsDesc.SelectedItem.Value));

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrPrChDesc);
        }
        protected void ddlCrPrChDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDisplay.Visible = true;

        }
        #endregion

        #region  FillFacultyCourseMoLrnPatternName Function
        private void FillFacultyCourseMoLrnPatternName(string Uni_ID, string Inst_ID, string Faculty_ID)
        {
            ddlCrDesc.Items.Clear();
            oDT = new System.Data.DataTable();
            Common = new clsCommon();
            try
            {

                if (hidInstID.Value != "")
                {
                    oDT = oInstituteRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, Inst_ID, Faculty_ID);
                    Common.fillDropDown(ddlCrDesc, oDT, string.Empty, "Text", "value", "--- Select ---");
                }
                else
                {
                    oDT = crRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, Faculty_ID);
                    Common.fillDropDown(ddlCrDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
                }

                if (Common != null)
                {
                    Common = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region getFacCrMoLrnPtrnID function
        private void getFacCrMoLrnPtrnID()
        {
            if (Convert.ToString(ddlCrDesc.SelectedValue) != "0")
            {
                IDs_List = Convert.ToString(ddlCrDesc.SelectedValue).Split('-');
                hidFacID.Value = Convert.ToString(IDs_List[0]).Trim();
                hidCrID.Value = Convert.ToString(IDs_List[1]).Trim();
                hidMoLrnID.Value = Convert.ToString(IDs_List[2]).Trim();
                hidPtrnID.Value = Convert.ToString(IDs_List[3]).Trim();
            }
            else
            {
                if (Convert.ToString(ddlCrDesc.SelectedValue) == "0")
                {
                    hidCrID.Value = "0";
                    hidMoLrnID.Value = "0";
                    hidPtrnID.Value = "0";
                }
                hidFacID.Value = ddlFacDesc.SelectedValue;
            }
        }

        #endregion

        #region Fill Branch Function
        private void FillBranch(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID)
        {
            ddlCrBrnDesc.Items.Clear();
            oDT = new System.Data.DataTable();
            try
            {
                if (hidInstID.Value != "")
                {
                    oDT = oInstituteRepository.AssignedConfirmedBranches(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID);
                }
                else
                {
                    oDT = crRepository.ListCourseModeOfLearningPatternWiseLaunchedBranches(long.Parse(Uni_ID), long.Parse(Fac_ID), long.Parse(Cr_ID), long.Parse(Molrn_ID), long.Parse(Ptrn_ID));
                }

                if (oDT.Rows.Count > 0)
                {
                    Common = new clsCommon();
                    if (oDT.Rows.Count == 1)
                    {
                        if (Convert.ToString(oDT.Rows[0]["Text"]) == "No Branch")
                        {
                            ListItem li = new ListItem();
                            li.Text = "No Branch Available";
                            li.Value = "0";
                            ddlCrBrnDesc.Items.Add(li);
                            FillCoursePart(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, "0");
                        }
                        else
                        {
                            Common.fillDropDown(ddlCrBrnDesc, oDT, "-1", "Text", "Value", "---- Select ----");
                        }
                    }
                    else
                    {
                        Common.fillDropDown(ddlCrBrnDesc, oDT, "-1", "Text", "Value", "---- Select ----");
                    }
                    if (Common != null)
                    {
                        Common = null;
                    }
                }
                else
                {
                    if (ddlCrDesc.SelectedIndex == 0)
                    {
                        ListItem li = new ListItem();
                        li.Text = "---- Select ----";
                        li.Value = "-1";
                        ddlCrBrnDesc.Items.Add(li);
                    }
                    else
                    {
                        ListItem li = new ListItem();
                        li.Text = "No Branch Available";
                        li.Value = "0";
                        ddlCrBrnDesc.Items.Add(li);
                    }
                }
            }
            catch (Exception e) { }
        }
        #endregion

        #region Fill Course Part Function
        private void FillCoursePart(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID, string Brn_ID)
        {
            ddlCrPrDetailsDesc.Items.Clear();
            oDT = new System.Data.DataTable();
            Common = new clsCommon();
            try
            {
                if (hidInstID.Value != "")
                {
                    oDT = oInstituteRepository.AssignedConfirmedCourseParts(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, Brn_ID);
                    Common.fillDropDown(ddlCrPrDetailsDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
                }
                else
                {
                    oDT = crRepository.ListCourseModeOfLearningPatternBrnWiseLaunchedCourseParts(long.Parse(Uni_ID), long.Parse(Fac_ID), long.Parse(Cr_ID), long.Parse(Molrn_ID), long.Parse(Ptrn_ID), long.Parse(Brn_ID));
                    Common.fillDropDown(ddlCrPrDetailsDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
                }

                if (Common != null)
                {
                    Common = null;
                }
            }
            catch (Exception e) { }
        }

        #endregion

        #region FillPartTerm

        private void FillPartTerm(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID, string Brn_ID, string CrPrDetails_ID)
        {
            ddlCrPrChDesc.Items.Clear();
            oDT = new System.Data.DataTable();
            Common = new clsCommon();
            try
            {
                if (hidInstID.Value != "")
                {
                    oDT = oInstituteRepository.AssignCoursePartTerm(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(ddlCrBrnDesc.SelectedValue), Convert.ToString(ddlCrPrDetailsDesc.SelectedValue));
                    Common.fillDropDown(ddlCrPrChDesc, oDT, string.Empty, "Text", "value", "--- Select ---");
                }
                else
                {
                    oDT = crRepository.ListCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrCh(long.Parse(hidUniID.Value), long.Parse(CrPrDetails_ID));
                    Common.fillDropDown(ddlCrPrChDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
                }


                if (Common != null)
                {
                    Common = null;
                }

                if (oDT != null)
                {
                    oDT = null;
                }

            }
            catch (Exception Ex5)
            {
                throw new Exception(Ex5.Message);
            }
        }

        #endregion

        #region Function to Add User's newly selected data in session

        private void MemorizeInSession()
        {
            try
            {
                Session["ElgfacultyID"] = Convert.ToString(ddlFacDesc.SelectedItem.Value);
                Session["ElgBranchID"] = Convert.ToString(ddlCrBrnDesc.SelectedItem.Value);
                Session["ElgFacCrMoLrnPtrn_ID"] = Convert.ToString(ddlCrDesc.SelectedItem.Value);
                Session["Elgpk_CrPr_Details_ID"] = Convert.ToString(ddlCrPrDetailsDesc.SelectedItem.Value);
                Session["Elgpk_CrPrCh_ID"] = Convert.ToString(ddlCrPrChDesc.SelectedItem.Value);
                Session["Elgpk_AcademicYear_ID"] = Convert.ToString(ddlAcademicYr.SelectedItem.Value);

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        #endregion

        #region btnDisplay_Click
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            MemorizeInSession();
            divDGEligibility.Style.Add("display", "block");
            DisplayEligibilityDetails();

            if (string.IsNullOrEmpty(hidInstID.Value))
            {

                lblAcaYear.Text = " for " + ddlFacDesc.SelectedItem.Text + " - " + ddlCrDesc.SelectedItem.Text + " - " + ddlCrBrnDesc.SelectedItem.Text + " - " + ddlCrPrDetailsDesc.SelectedItem.Text + " - " + ddlCrPrChDesc.SelectedItem.Text + " [Academic Year " + ddlAcademicYr.SelectedItem.Text + "]";
            }
            else
            {
                lblAcaYear.Text = " for " + hidCollName.Value + " - " + ddlFacDesc.SelectedItem.Text + " - " + ddlCrDesc.SelectedItem.Text + " - " + ddlCrBrnDesc.SelectedItem.Text + " - " + ddlCrPrDetailsDesc.SelectedItem.Text + " - " + ddlCrPrChDesc.SelectedItem.Text + " [Academic Year " + ddlAcademicYr.SelectedItem.Text + "]";
            }


        }

        #endregion

        #region Create Data Table for gridview Source
        private DataTable CreateDataTable()
        {
            DataTable myDataTable = new DataTable();

            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "pk_Uni_ID";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "pk_Student_ID";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "pk_Year";
            myDataTable.Columns.Add(myDataColumn);


            //myDataColumn = new DataColumn();
            //myDataColumn.DataType = Type.GetType("System.Int32");
            //myDataColumn.ColumnName = "Seq_No";


            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Inst_Name";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "StudentName";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "PRN_Number";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "OldPprs";
            myDataTable.Columns.Add(myDataColumn);


            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Newpprs";
            myDataTable.Columns.Add(myDataColumn);

            //myDataColumn = new DataColumn();
            //myDataColumn.DataType = Type.GetType("System.String");
            //myDataColumn.ColumnName = "RegionalCenterInfo";
            //myDataTable.Columns.Add(myDataColumn);



            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "UserName";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Date";
            myDataTable.Columns.Add(myDataColumn);

            return myDataTable;
        }

        #endregion

        #region DisplayEligibilityDetails Function
        protected void DisplayEligibilityDetails()
        {
            Hashtable oHt = new Hashtable();
            oHt["UniID"] = hidUniID.Value;
            oHt["FacID"] = hidFacID.Value;
            oHt["CrID"] = hidCrID.Value;
            oHt["MoLrnID"] = hidMoLrnID.Value;
            oHt["PtrnID"] = hidPtrnID.Value;
            oHt["BrnID"] = Convert.ToString(Session["ElgBranchID"]);
            oHt["CrPrDetailsID"] = Convert.ToString(Session["Elgpk_CrPr_Details_ID"]);
            oHt["CrPrChID"] = Convert.ToString(Session["Elgpk_CrPrCh_ID"]);
            oHt["AcademicYearID"] = Convert.ToString(Session["Elgpk_AcademicYear_ID"]);
            DataTable oDtGridView = CreateDataTable();
            try
            {
                DataTable Dt;
                oCollegeAdmissionReports = new clsCollegeAdmissionReports();
                Dt = oCollegeAdmissionReports.ListStudentDetailsWithPaperChangeAdvSearch(oHt);
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    CreateTableForGridViewAndReport(oDtGridView, Dt);

                    Session["StudentDetailsWithPprChange"] = oDtGridView;
                    if (oDtGridView.Rows.Count > 0 && oDtGridView != null)
                    {
                        DGEligibility1.DataSource = oDtGridView;
                        tblDGEligibility.Style.Add("display", "block");
                        DGEligibility1.DataBind();
                        lblnorecordfound.Visible = false;
                        
                    }
                    else
                    {
                        tblDGEligibility.Style.Add("display", "none");
                        Session.Remove("StudentDetailsWithPprChange");
                        lblnorecordfound.Visible = true;
                    }
                }
                else
                {
                    tblDGEligibility.Style.Add("display", "none");
                    lblnorecordfound.Visible = true;
                    Session.Remove("StudentDetailsWithPprChange");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static void CreateTableForGridViewAndReport(DataTable oDtGridView, DataTable Dt)
        {
            DataView dv = new DataView(Dt);
            //dv.Table = Dt;

            foreach (DataRow row in Dt.Rows)
            {
                DateTime d = row.Field<DateTime>("Date");
                row["Date"] = new DateTime(d.Year, d.Month, d.Day);
                // or use "tricks" like this
                // row["Time"] = d.AddTicks(-(d.Ticks % TimeSpan.TicksPerMinute));
            }


            DataTable distinctValues = dv.ToTable(true, "pk_Uni_ID", "pk_Year", "pk_Student_ID", "Inst_Name", "PRN_Number", "StudentName", "UserName", "Date");

           
            //DataView view = new DataView(table);
            //DataTable distinctValues = view.ToTable(true, "id");

            if (distinctValues != null && distinctValues.Rows.Count > 0)
            {
                
                DataRow row;
                foreach (DataRow dr in distinctValues.Rows)
                {
                    row = oDtGridView.NewRow();
                    row["pk_Uni_ID"] = dr["pk_Uni_ID"].ToString();
                    row["pk_Student_ID"] = dr["pk_Student_ID"].ToString();
                    row["pk_Year"] = dr["pk_Year"].ToString();
                    row["Inst_Name"] = dr["Inst_Name"].ToString();
                    row["PRN_Number"] = dr["PRN_Number"].ToString();
                    row["StudentName"] = dr["StudentName"].ToString();
                    dv.Table = Dt;
                    string OldPpr = "<ul style='padding-left:15px;margin:0px;'>";
                    string NewPpr = "<ul style='padding-left:15px;margin:0px;'>";
                    dv.RowFilter = "pk_Uni_ID= " + dr["pk_Uni_ID"].ToString() + " and pk_Student_ID=" + dr["pk_Student_ID"].ToString() + " and pk_Year=" + dr["pk_Year"].ToString() + " and UserName='" + dr["UserName"].ToString()+ "'";
                    if (dv != null)
                    {
                        foreach (DataRowView drv in dv)
                        {
                            if (drv.Row["PaperChange_Type"].ToString().Equals("i"))
                                NewPpr += "<li>" + drv.Row["Pp_Name"].ToString() + "</li>";
                            else if (drv.Row["PaperChange_Type"].ToString().Equals("d"))
                                OldPpr += "<li>" + drv.Row["Pp_Name"].ToString() + "</li>";
                        }

                    }
                    if (!string.IsNullOrEmpty(OldPpr))
                        row["OldPprs"] = OldPpr + "</ul>";
                    if (!string.IsNullOrEmpty(NewPpr))
                        row["Newpprs"] = NewPpr + "</ul>";
                    //dv = null;

                    row["UserName"] = dr["UserName"].ToString();
                    row["Date"] = dr["Date"].ToString();
                    oDtGridView.Rows.Add(row);
                }
            }
        }
        #endregion

        #region DGEligibility1_RowDataBound
        protected void DGEligibility1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView gv = (GridView)sender;
           // int cellIndex = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (user.UserTypeCode == "2")
                {
                    e.Row.Cells[1].Style.Add("display", "none");
                   // cellIndex = 3;
                }
               // else
                  //  cellIndex = 4;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (user.UserTypeCode == "2")
                {
                    e.Row.Cells[1].Style.Add("display", "none");
                    
                }


                //if (!string.IsNullOrEmpty(e.Row.Cells[cellIndex].Text) && !e.Row.Cells[cellIndex].Text.ToString().Equals("&nbsp;"))
                //{
                //    string[] arr = e.Row.Cells[cellIndex].Text.Split(',');// "<li>Pawan</li>";
                //    e.Row.Cells[cellIndex].Text = "<ul style='padding-left:15px;margin:0px;'>";
                //    for (int i = 0; i < arr.Length; i++)
                //    {
                //        e.Row.Cells[cellIndex].Text += "<li>" + arr[i] + "</li>";
                //    }
                //    e.Row.Cells[cellIndex].Text += "</ul>";
                //}
                //if (!string.IsNullOrEmpty(e.Row.Cells[cellIndex + 1].Text) && !e.Row.Cells[cellIndex + 1].Text.ToString().Equals("&nbsp;"))
                //{
                //    string[] arr1 = e.Row.Cells[cellIndex + 1].Text.Split(',');// "<li>Pawan</li>";
                //    e.Row.Cells[cellIndex + 1].Text = "<ul style='padding-left:15px;margin:0px;'>";
                //    for (int i = 0; i < arr1.Length; i++)
                //    {
                //        e.Row.Cells[cellIndex + 1].Text += "<li>" + arr1[i] + "</li>";
                //    }
                //    e.Row.Cells[cellIndex + 1].Text += "</ul>";
                //}

            }

        }
        #endregion

        #region PDF Export

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            #region Report Viewer Approach

            CreateReport();
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, extension;
            string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
              + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
              + "  <MarginLeft>0.6in</MarginLeft>" + "  <MarginRight>0.4in</MarginRight>"
              + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
            renderedBytes = ReportViewer1.LocalReport.Render("PDF", DeviceInfo, out mimeType, out encoding, out extension, out streams, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=StudentDetailsWithPprChangeReport.pdf");
            Response.BinaryWrite(renderedBytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();


            #endregion
        }

        #endregion

        #region CreateReport Region

        public void CreateReport()
        {
            try
            {
                #region Assign DataSet and Report Data Sourse Details

                DataTable dtExport = new DataTable();
                dtExport = ((System.Data.DataTable)Session["StudentDetailsWithPprChange"]).Copy();
                ReportDataSource ReportDetailsDS1;
                if(user.UserTypeCode=="2")
                    ReportDetailsDS1 = new ReportDataSource("dsViewElgStatus_dtStudentDetailsWithPPrChangeForCollege", dtExport);
                else
                ReportDetailsDS1 = new ReportDataSource("dsViewElgStatus_dtStudentDetailsWithPPrChange", dtExport);
                ReportParameter[] p = new ReportParameter[7];

                p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 0);
                p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 1);
                p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 2);
                p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + @"/Images/" + Classes.clsGetSettings.UniversityLogo), 3);
                p.SetValue(new ReportParameter("SubHead", lblAcaYear.Text), 4);
                bool b = string.IsNullOrEmpty(hidInstID.Value.Trim()) ? false : true;
                p.SetValue(new ReportParameter("ColumnCollegeVisibility", b.ToString()), 5);
                p.SetValue(new ReportParameter("Culture", CultureInfo.CurrentCulture.Name), 6);
               
                ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());


                #endregion

                ReportViewer1.LocalReport.DataSources.Clear();
                if(user.UserTypeCode=="2")
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Eligibility\Rdlc\rptStudentDetailwithPaperChangeForCollege.rdlc");
                else
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Eligibility\Rdlc\rptStudentDetailwithPaperChange.rdlc");

                #region Adding DataSet and Report Data Sourse to ReportViewer DataSources

                ReportViewer1.LocalReport.DataSources.Add(ReportDetailsDS1);
                ReportViewer1.LocalReport.DataSources.Add(MultNomDS);
                ReportViewer1.LocalReport.SetParameters(p);

                #endregion

                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.LocalReport.Refresh();


            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);

            }

        }

        #endregion

        #region MultinomenClature Table

        public DataTable MultinomenClature()
        {
            DataTable dtMultNomen = new DataTable();
            dtMultNomen.Columns.Add("Course");
            dtMultNomen.Columns.Add("PRN");
            dtMultNomen.Columns.Add("College");
            dtMultNomen.Columns.Add("Paper");


            DataRow dr = dtMultNomen.NewRow();
            dr["Course"] = lblPrvCourseNomenclature.Text;
            dr["PRN"] = lblPRNNomenclature.Text;
            dr["College"] = lblCollege.Text;
            dr["Paper"] = lblPaper.Text;
            dtMultNomen.Rows.Add(dr);
            return dtMultNomen;
        }

        #endregion

        #region Excel Export

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            #region Report Viewer Approach

            CreateReport();
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, extension;
            string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>EXCEL</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
              + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
              + "  <MarginLeft>0.6in</MarginLeft>" + "  <MarginRight>0.4in</MarginRight>"
              + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
            renderedBytes = ReportViewer1.LocalReport.Render("Excel", DeviceInfo, out mimeType, out encoding, out extension, out streams, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=StudentDetailsWithPaperChangeReport.xls");
            Response.BinaryWrite(renderedBytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();


            #endregion

        }

        #endregion

        #region btnSimpleSearch_Click

        protected void btnSimpleSearch_Click(object sender, EventArgs e)
        {
            divYCMOU.Attributes.Add("style", "display:none");
            divSimpleSearch.Attributes.Add("style", "display:block");
            divDGEligibility.Style.Add("display", "block");
            btnDisplay.Visible = false;
            lblAdvSearch.Visible = false;
            if (user.UserTypeCode == "2")
            {
                if (string.IsNullOrEmpty(txtPRN.Text.Trim()))
                    lblAcaYear.Text = " for " + hidCollName.Value;
                else if (string.IsNullOrEmpty(txtElgFormNo.Text.Trim()))
                    lblAcaYear.Text = " for " + hidCollName.Value;
            }
            else
                lblAcaYear.Text = "";
            DataTable dt = new DataTable();
            if (txtElgFormNo.Text != "")
            {
                Elg_FormNo = txtElgFormNo.Text.Trim();
            }

            else
            {
                Elg_FormNo = "0-0-0-0";
            }

            int cnt = 0;
            string str = Elg_FormNo;
            int pos = str.IndexOf('-');
            string[] arr = new string[] { "0", "0", "0", "0" };
            Regex objNotNaturalPattern = new Regex("^([0-9])$");

            if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                PRNumber = txtPRN.Text.Trim();

            while (pos != -1)
            {
                str = str.Substring(pos + 1);
                pos = str.IndexOf('-');
                cnt++;

            }
            if (cnt == 3)
            {
                arr = new string[4];
                arr = Elg_FormNo.Split('-');   //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
                for (int i = 0; i < 4; i++)
                {
                    if (arr[i] == "")
                        arr[i] = "0";
                }
            }


            Hashtable oHt = new Hashtable();
            oHt["RefUniID"] = arr[0];
            oHt["RefInstID"] = arr[1];
            oHt["RefStudentYear"] = arr[2];
            oHt["RefStudentID"] = arr[3];
            if (PRNumber == null)
            {
                PRNumber = txtPRN.Text.Trim();
            }
            oHt["PRN_number"] = PRNumber;
            DataTable oDtGridView = CreateDataTable();
            try
            {
                DataTable Dt;
                oCollegeAdmissionReports = new clsCollegeAdmissionReports();
                Dt = oCollegeAdmissionReports.ListStudentDetailsWithPaperChangeSimpleSearch(oHt);
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    lblAcaYear.Text += " for " + Dt.Rows[0]["Course_Name"].ToString();
                    CreateTableForGridViewAndReport(oDtGridView, Dt);

                  
                    if (oDtGridView.Rows.Count > 0 && oDtGridView != null)
                    {
                        DGEligibility1.DataSource = oDtGridView;
                        tblDGEligibility.Style.Add("display", "block");
                        DGEligibility1.DataBind();
                        DGEligibility1.Visible = true;
                        lblnorecordfound.Visible = false;
                        
                    }
                    else
                    {
                        tblDGEligibility.Style.Add("display", "none");
                        Session.Remove("StudentDetailsWithPprChange");
                        lblnorecordfound.Visible = true;
                    }
                    if (user.UserTypeCode == "2")
                    {
                        oDtGridView.Columns.Remove("Inst_Name");
                        
                    }
                    Session["StudentDetailsWithPprChange"] = oDtGridView;
                }
                else
                {
                    tblDGEligibility.Style.Add("display", "none");
                    lblnorecordfound.Visible = true;
                    Session.Remove("StudentDetailsWithPprChange");
                    if (txtElgFormNo.Text == "")
                        lblnorecordfound.Text = "Student does not exist for entered " + lblPRNNomenclature.Text;
                    else
                        lblnorecordfound.Text = "Student does not exist for entered Eligibility form number";
                    lblAcaYear.Text = "";
                }
            }
            catch (Exception ex)
            {
               
                throw ex;
            }

            //if (string.IsNullOrEmpty(hidInstID.Value))
            //{

            //    lblAcaYear.Text = " for " + ddlFacDesc.SelectedItem.Text + " - " + ddlCrDesc.SelectedItem.Text + " - " + ddlCrBrnDesc.SelectedItem.Text + " - " + ddlCrPrDetailsDesc.SelectedItem.Text + " - " + ddlCrPrChDesc.SelectedItem.Text + " [Academic Year " + ddlAcademicYr.SelectedItem.Text + "]";
            //}
            //else
            //{
            //    lblAcaYear.Text = " for " + hidCollName.Value + " - " + ddlFacDesc.SelectedItem.Text + " - " + ddlCrDesc.SelectedItem.Text + " - " + ddlCrBrnDesc.SelectedItem.Text + " - " + ddlCrPrDetailsDesc.SelectedItem.Text + " - " + ddlCrPrChDesc.SelectedItem.Text + " [Academic Year " + ddlAcademicYr.SelectedItem.Text + "]";
            //}

        }


        #endregion


        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion

    }


}