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

//using RKLib.ExportData;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace StudentRegistration
{
    public partial class ELGV2rptInvoiceGenration_MonthlyReport : System.Web.UI.Page
    {
        DataTable oDT = null;
        clsCommon oCommon = null;
        clsUser user;
        string sUser;
        int flag = 0;
        string grpRow1 = "-";
        string grpRow2 = "";
        int index = 0;
        int cntCol = 0;
        int cntStud = 0;
        DataSet DS1 = new DataSet("myDS");
        DataTable DTdata;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["User"];

            if (user != null && user.Exist)
            {
                sUser = user.User_ID;
            }
            else
            {
                Response.Redirect(Classes.clsGetSettings.SitePath.ToString() + "Logout.aspx");
            }
            if (!IsPostBack)
            {
                FillAcademic_Year();
              

            }

        }


        private void FillAcademic_Year()
        {
            oDT = new DataTable();
            clsAcademicYear objAcadYear = new clsAcademicYear();
            oDT = objAcadYear.ListAcademicYear();
            ViewState["AcademicYear"] = oDT;
            oCommon = new clsCommon();
            oCommon.fillDropDown(ddlAcademicYear, oDT, string.Empty, "Year", "pk_AcademicYear_ID", "---- Select ----");

            if (oCommon != null)
            {
                oCommon = null;
            }
           
        }


        private void FillAcademicYear()
        {
            oDT = new DataTable();
            clsInvoiceGenration objAcadYear = new clsInvoiceGenration();
            oDT = objAcadYear.ListAcademicYear(ddlAcademicYear.SelectedValue);

            if (oDT != null && oDT.Rows.Count > 0)
            {
                ListItem li = new ListItem("--Select--", "-1");
                ddlAcadYear.Items.Clear();
                ddlAcadYear.Items.Add(new ListItem("Select Academic Year", "0"));
                ddlAcadYear.DataSource = oDT;
                ddlAcadYear.DataTextField = "Year";
                ddlAcadYear.DataValueField = "Year";
                ddlAcadYear.DataBind();
                ddlAcadYear.Items.Insert(0, li);
               
            }
           
        }

        protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlAcademicYear.SelectedValue) != "0")
            {
                divMonth.Visible = true;
                divYear1.Visible = true;
                lblErrorMsg.Visible = false;
                FillAcademicYear();

            }
        }


        protected void btnProceed_Click(object sender, EventArgs e)
        {
            lblAcaYear.Text = " For [ Month: " + ddlMonth.SelectedItem.Text + "-" + ddlAcadYear.SelectedItem.Text + "]";           
            divDGStat.Style.Add("display", "block");
            GVStat.Visible = true;
            divYear.Visible = false;
            tblheader.Style.Add("display", "block");
            fillGrid();
        }


        private void fillGrid()
        {

            DataTable dtTmp = new DataTable();
            clsInvoiceGenration obj = new clsInvoiceGenration();

            dtTmp = obj.REPV2_Invoice_Genration_MonthlyReport(ddlAcademicYear.SelectedValue,ddlAcadYear.SelectedValue, ddlMonth.SelectedValue);
            try
            {
                if (dtTmp != null && dtTmp.Rows.Count > 0)
                {
                    dtTmp.TableName = "Table1";
                    DS1.Tables.Add(dtTmp.Copy());
                    dtTmp = null;
                    lblErrorMsg.Visible = false;
                 
                    GVStat.DataSource = SummaryTables();
                    GVStat.DataBind();
                    Session["dtdata"] = SummaryTables();
                    DTdata = (DataTable)Session["dtdata"];
                }
                else
                {
                    lblErrorMsg.Visible = true;                   
                    lblErrorMsg.Text = "Record not Forund For Selected Criteria.";
                    tblheader.Style.Add("display", "none");
                    divYear.Visible = true;
                }
            }
            catch (Exception) { }

        }

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
                int j = Convert.ToInt32(DS1.Tables["Table1"].Rows[i][2]);
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

        protected void GVStat_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                if (flag == 0)
                {


                }
                cntStud += Convert.ToInt32(e.Row.Cells[3].Text.Trim());

                if (e.Row.Cells[1].Text.Trim() + '-' + e.Row.Cells[2].Text.Trim() + '-' + e.Row.Cells[3].Text.Trim() == grpRow1)
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





        protected void btnBackAcYear_Click(object sender, EventArgs e)
        {
            divYear.Visible = true;
            tblheader.Style.Add("display", "none");
            divDGStat.Style.Add("display", "none");
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {

                StringWriter writer2 = new StringWriter();
                StringBuilder oSB = new StringBuilder();
                DataTable dtExport = new DataTable();
               // DataTable dtExport = (DataTable)Session["dtTmp"];
                dtExport = ((DataTable)Session["dtdata"]).Copy();
                dtExport.Columns["Course Name"].ColumnName = lblCr.Text + " Name";
                dtExport.Columns["CoursePart"].ColumnName = "Duration of Programme/ Course in Months";
                dtExport.Columns["Total uploaded data"].ColumnName = "Admissions confirmed by " + lblCollege.Text;
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
                oSB.Append("<ss:Cell ss:MergeAcross=\"1\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Admission Statistic For Month: "+ddlMonth.SelectedItem.Text +" - " +ddlAcadYear.SelectedItem.Text + "</ss:Data></ss:Cell>");
                oSB.Append("</ss:Row>");
                


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


        }
    }
}