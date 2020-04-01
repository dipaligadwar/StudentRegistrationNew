using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Classes;
using ServerSideValidations;
using AjaxControlToolkit;
using System.Globalization;
using System.Threading;
using System.Configuration;

namespace StudentRegistration.Eligibility
{
    public partial class CancelAdmission : System.Web.UI.Page
    {
        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion

        #region Variable Declaration
        Hashtable oHt;
        DataSet oDt;
        Eligibility.ElgClasses.clsElgStudent oStudent;
        clsCommon oCommon = new clsCommon();
        clsCache oCache = new clsCache();
        string sSelectFlag = string.Empty;
        clsUser user;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            // No cache is used for clearing cache when user clicks BACK button.
            oCache.NoCache();

            Page.Title = clsGetSettings.Name + " | Cancel Admission";
            lblPageHead.Text = "Search Student";

            Search_Control1.OnSearchClick += new StudentRegistration.Eligibility.WebCtrl.SearchClick(Search_Control1_OnSearchClick);
            Search_Control1.page = this.Page;

            Form.DefaultButton = Search_Control1.btnSearch.UniqueID;
            if (!IsPostBack)
            {
                #region Set Hidden Variables

                HtmlInputHidden[] hid = new HtmlInputHidden[5];
                hid[0] = hid_PRN_Number;
                hid[1] = hid_Inst_Details;
                hid[2] = hid_pk_Year;
                hid[3] = hid_pk_Student_ID;
                hid[4] = hid_Stud_Name;
                oCommon.setHiddenVariablesMPC(ref hid);
                #endregion
            }
        }

        #region Function Grid Row Data Bound Event
        /// <summary>
        /// Grid view row data bound event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void GV_SrchStud_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer && e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbtn = (LinkButton)e.Row.FindControl("lnkSelect");
                lbtn.Text = "Select";
            }
        }
        #endregion


        #region Function Grid Row Command Event
        /// <summary>
        /// Grid view row command event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void GV_SrchStud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            WebControl wc = e.CommandSource as WebControl;
            GridViewRow row = wc.NamingContainer as GridViewRow;
            if (row != null)
            {
                int index = row.RowIndex;
                GridViewRow selectedRow = GV_SrchStud.Rows[index];

                hid_pk_Year.Value = selectedRow.Cells[7].Text;
                hid_pk_Student_ID.Value = selectedRow.Cells[8].Text;
                hid_Stud_Name.Value = selectedRow.Cells[1].Text;
                hid_OldPRN.Value = selectedRow.Cells[2].Text;
                hid_PRN_Number.Value = selectedRow.Cells[3].Text;

                if (selectedRow.Cells[9].Text != "&nbsp;")
                {
                    hid_Inst_Details.Value = "<strong>Institute Name :</strong> " + selectedRow.Cells[10].Text + " <strong>Institute Code :</strong>  " + selectedRow.Cells[0].Text + " <strong>Region :</strong> " + selectedRow.Cells[9].Text;
                }
                else
                {
                    hid_Inst_Details.Value = "<strong>Institute Name :</strong> " + selectedRow.Cells[10].Text + " <strong>Institute Code :</strong>  " + selectedRow.Cells[0].Text;
                }

                Server.Transfer("CancelAdmission__2.aspx");
            }
        }
        #endregion

        #region Grid Page Index Changing Event
        /// <summary>
        /// Grid view page index changing event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void GV_SrchStud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_SrchStud.PageIndex = e.NewPageIndex;
            sSelectFlag = " ";
            bindGrid(50);
            divLink.Visible = false;
        }
        #endregion

        #region Function CreateHashTable
        /// <summary>
        /// Creates hash table for Search Student.
        /// </summary>
        private void createHashTable()
        {
            oHt = new Hashtable();
            user = (clsUser)Session["user"];
            if (user.UserTypeCode == "2")
            {
                oHt.Add("pk_Institute_ID", user.UserReferenceID);
            }

            oHt.Add("pk_Uni_ID", clsGetSettings.UniversityID);
            oHt.Add("PRN_Number", hid_PRN.Value);
            oHt.Add("OldPRN_Number", hid_OldPRN.Value);
            oHt.Add("Eligibility_Form_No", hid_ElgFormNo.Value);
            oHt.Add("pk_Fac_ID", hid_FacID.Value);
            oHt.Add("pk_Cr_ID", hid_CourseID.Value);
            oHt.Add("pk_MoLrn_ID", hid_MoLrnID.Value);
            oHt.Add("pk_Ptrn_ID", hid_PtrnID.Value);
            oHt.Add("pk_Brn_ID", hid_BranchID.Value);
            oHt.Add("pk_CrPr_Details_ID", hid_CrPrDetailsID.Value);
            oHt.Add("pk_CrPrCh_ID", hid_CrPrTermID.Value);
            oHt.Add("Last_Name", hid_LastName.Value);
            oHt.Add("First_Name", hid_FirstName.Value);
            oHt.Add("Gender", hid_Gender.Value);
            oHt.Add("SelectFlag", sSelectFlag);
            oHt.Add("ApplicationFormNo", hid_AppFormNo.Value);
            oHt.Add("AcademicYear", hidAcademicYear.Value);
        }
        #endregion

        #region Function Bind Grid
        /// <summary>
        /// Binds data to grid view.
        /// </summary>
        private void bindGrid(int PageSize)
        {
            oStudent = new Eligibility.ElgClasses.clsElgStudent();
            createHashTable();
            //oDt = oStudent.SearchStudentLog(oHt);
            // oDt = oStudent.SearchRegStudent(oHt);
            oDt = oStudent.SearchStudent(oHt);

            if (oDt.Tables.Count > 0)
            {
                if (oDt.Tables[0].Rows.Count > 0)
                {
                    if (oDt.Tables[0].Rows.Count == 1)
                    {
                        lblErrorMsg.Text = string.Empty;
                        hid_pk_Year.Value = Convert.ToString(oDt.Tables[0].Rows[0]["pk_Year"]);
                        hid_pk_Student_ID.Value = Convert.ToString(oDt.Tables[0].Rows[0]["pk_Student_ID"]);
                        hid_Stud_Name.Value = Convert.ToString(oDt.Tables[0].Rows[0]["Name"]);
                        hid_OldPRN.Value = Convert.ToString(oDt.Tables[0].Rows[0]["OldPRN_Number"]);
                        hid_PRN_Number.Value = Convert.ToString(oDt.Tables[0].Rows[0]["PRN_Number"]);

                        if (Convert.ToString(oDt.Tables[0].Rows[0]["Region"]) != string.Empty)
                        {
                            hid_Inst_Details.Value = "Institute Name : " + Convert.ToString(oDt.Tables[0].Rows[0]["Study_Center"]) + " Institute Code :  " + Convert.ToString(oDt.Tables[0].Rows[0]["Center_Code"]) + " <strong>Region :</strong> " + Convert.ToString(oDt.Tables[0].Rows[0]["Region"]);
                        }
                        else
                        {
                            hid_Inst_Details.Value = "Institute Name : " + Convert.ToString(oDt.Tables[0].Rows[0]["Study_Center"]) + " Institute Code :  " + Convert.ToString(oDt.Tables[0].Rows[0]["Center_Code"]);
                        }

						Server.Transfer("CancelAdmission__2.aspx");
                    }
                    else
                    {
                        int Record_Count = 0;
                        if (oDt.Tables.Count > 1)
                        {
                            Record_Count = Convert.ToInt32(oDt.Tables[1].Rows[0]["TotalRecords"]);
                        }
                        else
                        {
                            Record_Count = oDt.Tables[0].Rows.Count;
                        }

                        if (Record_Count > PageSize)
                        {
                            int CountStart = (GV_SrchStud.PageIndex * PageSize) + 1;
                            int CountEnd = (GV_SrchStud.PageIndex * PageSize) + PageSize;

                            if (CountEnd > Record_Count)
                            {
                                CountEnd = Record_Count;
                            }

                            lblCount.Text = "<strong>Results</strong> " + CountStart + " - " + CountEnd + " of about " + Record_Count + " records found.";

                            divStudentCount.Visible = true;
                        }
                        else
                        {
                            divStudentCount.Visible = false;
                        }

                        DivDetails.Visible = true;
                        lblErrorMsg.Text = string.Empty;
                        GV_SrchStud.Visible = true;
                        GV_SrchStud.DataSource = oDt.Tables[0];
                        GV_SrchStud.DataBind();
                    }
                }
                else
                {
                    divStudentCount.Visible = false;
                    DivDetails.Visible = false;
                    GV_SrchStud.Visible = false;
                    lblErrorMsg.Text = "No data available for selected criteria";
                    if (hid_AppFormNo.Value != string.Empty)
                    {
                        lblErrorMsg.Text = "Application Form No is Not present In  Current Academic Year.";
                    }
                }
            }
            else
            {
                divStudentCount.Visible = false;
                DivDetails.Visible = false;
                GV_SrchStud.Visible = false;
                lblErrorMsg.Text = "No data available for selected criteria";
                if (hid_AppFormNo.Value != string.Empty)
                {
                    lblErrorMsg.Text = "Application Form No is Not present In  Current Academic Year.";
                }
            }
        }
        #endregion

        #region Button Search Click
        /// <summary>
        /// Search button click event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        private void Search_Control1_OnSearchClick(object sender, EventArgs e)
        {
            #region setting properties value to hidden variable
            hid_PRN.Value = Search_Control1.PRN;
            hid_OldPRN.Value = Search_Control1.OldPRN;
            hid_ElgFormNo.Value = Search_Control1.ElgFormNo;
            hid_AppFormNo.Value = Search_Control1.AppFormNo;
            hidAcademicYear.Value = Session["AcademicYearID"].ToString();

            if (Search_Control1.FacID != 0)
            {
                hid_FacID.Value = Convert.ToString(Search_Control1.FacID);
                hid_CourseID.Value = Convert.ToString(Search_Control1.CourseID);
                hid_MoLrnID.Value = Convert.ToString(Search_Control1.MoLrnID);
                hid_PtrnID.Value = Convert.ToString(Search_Control1.PtrnID);
                hid_BranchID.Value = Convert.ToString(Search_Control1.BranchID);
                hid_CrPrDetailsID.Value = Convert.ToString(Search_Control1.CrPrDetailsID);
                hid_CrPrTermID.Value = Convert.ToString(Search_Control1.CrPrTermID);
            }
            else
            {
                hid_FacID.Value = string.Empty;
                hid_CourseID.Value = string.Empty;
                hid_MoLrnID.Value = string.Empty;
                hid_PtrnID.Value = string.Empty;
                hid_BranchID.Value = string.Empty;
                hid_CrPrDetailsID.Value = string.Empty;
                hid_CrPrTermID.Value = string.Empty;
            }

            hid_LastName.Value = Search_Control1.LastName;
            hid_FirstName.Value = Search_Control1.FirstName;
            hid_Gender.Value = Search_Control1.Gender;
            #endregion

            sSelectFlag = "Top 25";
            GV_SrchStud.PageIndex = 0;
            if (Search_Control1.IsValid)
            {
                bindGrid(25);
                divLink.Visible = true;
            }
        }
        #endregion

        #region Link button click event
        protected void lnkCount_Click(object sender, EventArgs e)
        {
            sSelectFlag = " ";
            GV_SrchStud.PageIndex = 0;
            bindGrid(50);
            divLink.Visible = false;
        }
        #endregion
    }
}
