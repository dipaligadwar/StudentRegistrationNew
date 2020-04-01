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
using StudentRegistration.Eligibility.ElgClasses;
//using RKLib.ExportData;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2rptUploadedStudentStatistics_CoursePart : System.Web.UI.Page
    {

        #region variable declaration

        clsCommon Common = new clsCommon();

        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        clsUser user;
        clsUser userInst;
        string sUser;
        DataTable DTdata;
        DataSet DS1 = new DataSet("myDS");
        int cntStud = 0;
        DataTable DT = new DataTable();
        DataTable DTSort = new DataTable();
        string grpRow1 = "-";
        string grpRow2 = "";
        int index = 0;
        int cntCol = 0;
        int flag = 0;

        string fkCountryID = "";
        private string instIDs = "";

        private const string CHECKED_ITEMS = "CheckedItems";
        InstituteRepository InstRep = new InstituteRepository();

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            //btnAcYr.Attributes.Add("onclick", "return callvaliadteAcademic();");
            user = (clsUser)Session["User"];

            if (user != null && user.Exist)
            {
                sUser = user.User_ID;
            }
            else
            {
                Response.Redirect(Classes.clsGetSettings.SitePath.ToString() + "Logout.aspx");
            }

            if (user.UserTypeCode == "2")
            {
                instIDs = user.UserReferenceID;
                hidInstID.Value = instIDs.ToString();
                //divAcademicYr.Style.Add("display", "block");
                divWaitMsg.Style.Add("display", "none");



            }

            if (IsPostBack)
            {
                flag = 1;
            }


            if (!IsPostBack)
            {

                if (PreviousPage != null)
                {
                    ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

                    if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                    {
                        hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                    }
                }

                instIDs = "";
                //DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                //Common.fillDropDown(ddlAcademicYr, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                //ddlAcademicYr.SelectedIndex = 0;
                Session.Remove("dtdata");

                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            }

            ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");


            hid_AcademicYear.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue;

            YCMOU.IsInstituteDisplay = false;
            YCMOU.IsFacultyDisplay = false;
            YCMOU.IsCourseDisply = false;
            YCMOU.IsCoursePartDisply = false;
            YCMOU.IsCourseTermDisply = false;
            YCMOU.IsBranchDisply = false;
            YCMOU.IsReportUserAndDateDisplay = false;
            YCMOU.isMISRpt.Value = "Yes";
            YCMOU.OnProceedClick += btnAcYr_Click;

        }

        #endregion

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        #region fill grid method

        private void fillGrid()
        {

            DataTable dtTmp = new DataTable();
            try
            {
                if (YCMOU.IsRegionalCenterVisible.Equals(true))
                {
                    if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked)
                    {
                        dtTmp = clsCollegeAdmissionReports.REPV2_AllInstitutes_uploaded_data(hid_fk_AcademicYr_ID.Value, ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedValue);
                    }
                    else
                    {
                        dtTmp = clsCollegeAdmissionReports.REPV2_AllInstitutes_uploaded_data(hid_fk_AcademicYr_ID.Value, null);
                    }
                }
                else
                {
                    dtTmp = clsCollegeAdmissionReports.REPV2_AllInstitutes_uploaded_data(hid_fk_AcademicYr_ID.Value, null);
                }
                dtTmp.TableName = "Table1";
                DS1.Tables.Add(dtTmp.Copy());
                dtTmp = null;


                GVStat.DataSource = SummaryTables();
                GVStat.DataBind();
                Session["dtdata"] = SummaryTables();
                DTdata = (DataTable)Session["dtdata"];
            }

            catch (Exception) { }

            GVStat.Visible = true;
            if (GVStat.Rows.Count == 0)
            {
                divDGStat.Style.Add("display", "none");
                //divAcademicYr.Style.Add("display", "block");
                Button3.Style.Add("display", "none");
                //lblAcYrError.Text = "No Record(s) found.";
                // tblNoRecForAcYr.Style.Add("display", "block");     
                tblSelect.Style.Add("display", "none");
                tblheader.Style.Add("display", "none");
            }
            if (GVStat.Rows.Count > 0)
            {
                divYCMOU.Style.Add("display", "none");
            }
        }

        #endregion

        #region SummaryTables

        public DataTable SummaryTables()
        {
            DataTable _dtSummary = new DataTable("Summary");

            #region - Table Creation -

            _dtSummary.Columns.Add("Course Name");
            _dtSummary.Columns.Add("CoursePart");
            _dtSummary.Columns.Add("Total uploaded data");
            #endregion


            for (int i = 0; i < DS1.Tables[0].Rows.Count; i++)
            {
                DataRow row = _dtSummary.NewRow();
                int j = (int)(DS1.Tables["Table1"].Rows[i][2]);
                if (j > 0)
                {
                    row[0] = DS1.Tables["Table1"].Rows[i][0];
                    row[1] = DS1.Tables["Table1"].Rows[i][1];
                    row[2] = DS1.Tables["Table1"].Rows[i][2];

                    _dtSummary.Rows.Add(row);
                }
            }
            return _dtSummary;
        }

        #endregion

        #region data table creation

        protected DataTable CreateTable()
        {

            DataTable newDt = new DataTable("CourseTable");
            for (int j = 0; j < DT.Columns.Count; j++)
            {
                newDt.Columns.Add(DT.Columns[j].ColumnName);
            }

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (DT.Rows[i]["Total uploaded data"].ToString() != "0")
                {
                    DataRow nRow = newDt.NewRow();

                    nRow["Course Name"] = DT.Rows[i]["Course Name"];
                    nRow["CoursePart"] = DT.Rows[i]["CoursePart"];
                    nRow["Total Uploaded Data"] = DT.Rows[i]["Total uploaded data"];
                    newDt.Rows.Add(nRow);

                }

            }

            return newDt;

        }

        #endregion

        #region GridView related functions

        protected void GVStat_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                if (flag == 0)
                {


                }
                cntStud += Convert.ToInt32(e.Row.Cells[3].Text.Trim());

                if (e.Row.Cells[1].Text.Trim() + '-' + e.Row.Cells[2].Text.Trim() +  '-' + e.Row.Cells[3].Text.Trim() == grpRow1)
                {
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[1].Text = "";
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[3].Text = "";


                    e.Row.Cells[0].Attributes.Add("style", "border-top:2px solid white;");
                    e.Row.Cells[1].Attributes.Add("style", "border-top:2px solid white;");
                    e.Row.Cells[2].Attributes.Add("style", "border-top:2px solid white;");
                    e.Row.Cells[3].Attributes.Add("style", "border-top:2px solid white;");

                }
                else
                {

                    grpRow1 = e.Row.Cells[1].Text.Trim() + '-' + e.Row.Cells[2].Text.Trim() + '-' + e.Row.Cells[3].Text.Trim();
                    index += 1;
                    e.Row.Cells[0].Text = index.ToString();
                    cntCol = Convert.ToInt32(e.Row.Cells[0].Text.ToString());

                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "<b>Total Uploaded Student Count</b>";
                e.Row.Cells[3].Text = "<b>" + cntStud.ToString() + "</b>";

            }
        }

        protected void GVStat_Sorted(object sender, EventArgs e)
        {

        }

        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        private void SortGridView(string sortExpression, string direction)
        {

            grpRow1 = "-";
            index = 0;
            cntStud = 0;
            grpRow1 = "-";
            grpRow2 = "";
            index = 0;
            cntCol = 0;



            DataView dv = new DataView(DT);

            dv.Sort = sortExpression + direction;
            GVStat.DataSource = dv;
            GVStat.DataBind();
        }

        protected void GVStat_Sorting(object sender, GridViewSortEventArgs e)
        {


            string sortExpression = e.SortExpression;

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, DESCENDING);
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, ASCENDING);
            }


        }

        #endregion

        #region btnAcYr_Click

        protected void btnAcYr_Click(object sender, EventArgs e)
        {
            try
            {
                tblSelect.Style.Add("display", "block");
                //divAcademicYr.Style.Add("display", "none");
                lblWaitMsg.Visible = true;
                DivCollegeUploadInfo.Style.Add("display", "block");
                divDGStat.Style.Add("display", "block");
                GVStat.Visible = true;
                tblheader.Style.Add("display", "block");
                Button3.Style.Add("display", "inline");

                string RegCentreName = string.Empty;

                if (YCMOU.IsRegionalCenterVisible.Equals(true))
                {
                    if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked)
                    {
                        RegCentreName = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                        lblAcaYear.Text = " for Regional Center " + RegCentreName + " for [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                    }
                    else
                    {
                        lblAcaYear.Text = " for All Regional Centers [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                    }
                }
                else
                {
                    lblAcaYear.Text = " for [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                }
                if (user.UserTypeCode == "2")
                {
                    DivCollegeUploadInfo.Style.Add("display", "none");
                    divDGStat.Style.Add("display", "block");
                    lblAcaYear.Text = " " + "for " + InstRep.InstituteName(hidUniID.Value, instIDs) + " for" + " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                }
                fillGrid();
            }
            catch (TimeoutException ex)
            {
                divWaitMsg.Style.Add("display", "block");
            }

        }

        #endregion

        //#region btnSelAcademicYr_Click

        //protected void btnSelAcademicYr_Click(object sender, EventArgs e)
        //{

        //    divAcademicYr.Style.Add("display", "block");

        //}

        //#endregion

        #region Export to Excel

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {

                StringWriter writer2 = new StringWriter();
                StringBuilder oSB = new StringBuilder();
                DataTable dtExport = new DataTable();
                dtExport = ((DataTable)Session["dtdata"]).Copy();                
                dtExport.Columns["Course Name"].ColumnName = lblCr.Text + " Name";
                dtExport.Columns["CoursePart"].ColumnName ="Duration of Programme/ Course in Months";
                dtExport.Columns["Total uploaded data"].ColumnName = "Admissions confirmed by "+lblCollege.Text;
                oSB.Append("<?xml version=\"1.0\"?>");
                oSB.Append("<ss:Workbook xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
                oSB.Append("<ss:Styles>");
                oSB.Append("<ss:Style ss:ID=\"1\">");
                oSB.Append("<ss:Font ss:Bold=\"1\"/>");
                oSB.Append("</ss:Style>");
                oSB.Append("</ss:Styles>");

                oSB.Append("<ss:Worksheet ss:Name=\"" + dtExport.TableName + "\">");
                oSB.Append("<ss:Table>");
                oSB.Append("<ss:Column ss:Width=\"400\"/>");
                oSB.Append("<ss:Column ss:Width=\"175\"/>");
                oSB.Append("<ss:Column ss:Width=\"94\"/>");
                oSB.Append("<ss:Row>");
                oSB.Append("<ss:Cell ss:MergeAcross=\"1\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Academic Year: " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "</ss:Data></ss:Cell>");
                oSB.Append("</ss:Row>");              
                if (YCMOU.IsRegionalCenterVisible.Equals(true))
                {
                    string RegCentre = string.Empty;
                    if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
                    {
                        RegCentre = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                    }
                    else
                    {
                        RegCentre = "all Regional Centres";
                    }
                    oSB.Append("<ss:Row>");
                    oSB.Append("<ss:Cell ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Regional Centre: " + RegCentre + "</ss:Data></ss:Cell>");
                    oSB.Append("</ss:Row>");

                    oSB.Append("<ss:Row>");
                    oSB.Append("<ss:Cell ss:MergeAcross=\"1\"><ss:Data ss:Type=\"String\"></ss:Data></ss:Cell>");
                    oSB.Append("</ss:Row>");
                }
                

                oSB.Append("<ss:Row ss:StyleID=\"1\">");
                for (int iCol = 0; iCol <= dtExport.Columns.Count - 1; iCol++)
                {
                    oSB.Append("<ss:Cell><ss:Data ss:Type=\"String\">" + dtExport.Columns[iCol].ColumnName + "</ss:Data></ss:Cell>");
                }
                oSB.Append("</ss:Row>");

                for (int iRow = 0; iRow <= dtExport.Rows.Count - 1; iRow++)
                {
                    oSB.Append("<ss:Row>");
                    for (int iCol = 0; iCol <= dtExport.Columns.Count - 1; iCol++)
                    {
                        oSB.Append("<ss:Cell><ss:Data ss:Type=\"String\">" + dtExport.Rows[iRow][iCol].ToString() + "</ss:Data></ss:Cell>");

                    }
                    oSB.Append("</ss:Row>");
                }

                

                oSB.Append("</ss:Table>");
                oSB.Append("</ss:Worksheet>");

                oSB.Append("</ss:Workbook>");
                this.Response.ContentType = "application/vnd.ms-excel";
                this.Response.AddHeader("Content-Disposition", "attachment; filename = " + "ExportedStatisticsReport.xls;");
                this.Response.Write(oSB.ToString());
                writer2.Close();
                this.Response.End();
                if (dtExport != null) { dtExport = null; }


            }
            catch (Exception Ex3)
            {

            }

            #region RKLib

            //try
            //{

            //    if (((DataTable)Session["dtdata"]).Rows.Count == 0 || ((DataTable)Session["dtdata"]) == null)
            //    {
            //        tblExportedDataMsg.Style.Add("display", "block");
            //        lblExportedData.Text = "No records found.";
            //        Session.Remove("dtdata");
            //        ((DataTable)Session["dtdata"]).Dispose();


            //    }

            //    // Export all the details to Excel
            //    int[] ColumnsList = { 0, 1 };
            //    string[] Headers = { lblCr.Text + " Name", "Total Uploaded Data" };

            //    //RKLib.ExportData.Export objExport = new RKLib.ExportData.Export();
            //    //objExport.ExportDetails(((DataTable)Session["dtdata"]), ColumnsList, Headers, Export.ExportFormat.Excel, "ExportedStatisticsReport");

            //    //tblExportedDataMsg.Style.Add("display", "block");
            //    //lblExportedData.Text = "Exported Successfully to Excel.....";

            //}

            //catch (Exception Ex)
            //{
            //    tblExportedDataMsg.Style.Add("display", "block");
            //    lblExportedData.CssClass = "errorNote";
            //}
            //finally
            //{
            //    ((DataTable)Session["dtdata"]).Dispose();

            //}

            #endregion
        }
        #endregion

        #region btnBackAcYear_Click

        protected void btnBackAcYear_Click(object sender, EventArgs e)
        {
            tblSelect.Style.Add("display", "none");
            divYCMOU.Style.Add("display", "block");
            //lblWaitMsg.Visible = false;
            DivCollegeUploadInfo.Style.Add("display", "none");
            divDGStat.Style.Add("display", "none");
            GVStat.Visible = false;
            tblheader.Style.Add("display", "none");
            //tblNoRecForAcYr.Style.Add("display", "none");  
        }

        #endregion

     

    }
}
