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
using System.Text;
using System.IO;
using StudentRegistration.Eligibility.ElgClasses;
using Microsoft.Reporting.WebForms;
using System.Threading;
using System.Globalization;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptDiscrepancyReport__1 : System.Web.UI.Page
    {
        string strAcademicYrID = "", strAcademicYr1 = "", strAcademicYr2 = "";
        DataTable Dt = new DataTable();
        DataTable DTSort = new DataTable();

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {

            string[] arr = Request.QueryString["AcademicYr"].Split('-');
            strAcademicYrID = arr[0].ToString();
            strAcademicYr1 = arr[1].ToString();
            strAcademicYr2 = arr[2].ToString();
            hid_fk_AcademicYr_ID.Value = strAcademicYrID.ToString();

            hidFacName.Value = Request.QueryString["fname"].ToString();
            hidCrName.Value = Request.QueryString["cname"].ToString();
            hidBrName.Value = Request.QueryString["bname"].ToString();
            hidCrPrDetName.Value = Request.QueryString["cDetN"].ToString();
            

            hid_fk_AcademicYr_ID.Value = strAcademicYrID.ToString();
            hid_strAcademicYr1.Value = strAcademicYr1.ToString();
            hidInstId.Value = Request.QueryString["InstId"].ToString();
            hid_strAcademicYr2.Value = strAcademicYr2.ToString();
            hidFacID.Value = Request.QueryString["FacId"].ToString();
            hidCrID.Value = Request.QueryString["CrId"].ToString();
            hidMoLrnID.Value = Request.QueryString["MoLrnId"].ToString();
            hidPtrnID.Value = Request.QueryString["PtrnId"].ToString();
            hidBrnID.Value = Request.QueryString["BrnId"].ToString();
            hidCrPrDetailsID.Value = Request.QueryString["CrPrDetailsId"].ToString();
            hidCrPrChIDs.Value = Request.QueryString["CrPrChIds"].ToString();
            lblPageHead.Text = "List of Discrepant Students for ";
            lblTitle.Text = hidFacName.Value + " - " + hidCrName.Value + " - " + hidBrName.Value + " - " + hidCrPrDetName.Value + " - " + hidCrPrChName.Value + " [Academic Year " + strAcademicYr1.ToString() + "-" + strAcademicYr2.ToString() + "]";
            if (Request.QueryString["RCentreID"] != null)
            {
                hidRCID.Value = Request.QueryString["RCentreID"].ToString();
            }

            fillGrid();
        }

        #endregion

        #region fillGrid

        private void fillGrid()
        {
            if (ViewState["SortExpression"] == null)
            {
                Dt = clsCollegeAdmissionReports.FillDiscrepancyReportStudentDetails(hid_fk_AcademicYr_ID.Value, hidInstId.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hidCrPrChIDs.Value);
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    GVStudent.DataSource = Dt;
                    GVStudent.DataBind();

                }
                else
                {
                    GVStudent.Visible = false;
                }
            }
            else
            {
                DataView Ddv = new DataView(Dt);
                Ddv.Sort = ViewState["SortExpression"].ToString();
                GVStudent.DataSource = Ddv;
                GVStudent.DataBind();
            }
        }

        #endregion

        #region Excel Export

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            #region XML

            //try
            //{
            //    StringWriter writer2 = new StringWriter();
            //    StringBuilder oSB = new StringBuilder();
            //    DataTable dtExport = new DataTable();
            //    dtExport = (DataTable)GVStudent.DataSource;
            //    dtExport.Columns.Remove("pk_Uni_ID");
            //    dtExport.Columns.Remove("pk_Year");
            //    dtExport.Columns.Remove("pk_Student_ID");
            //    dtExport.Columns.Remove("Ref_InstReg_Institute_ID");

            //    oSB.Append("<?xml version=\"1.0\"?>");
            //    oSB.Append("<ss:Workbook xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            //    oSB.Append("<ss:Styles>");
            //    oSB.Append("<ss:Style ss:ID=\"1\">");
            //    oSB.Append("<ss:Font ss:Bold=\"1\"/>");
            //    oSB.Append("</ss:Style>");
            //    oSB.Append("</ss:Styles>");

            //    oSB.Append("<ss:Worksheet ss:Name=\"" + dtExport.TableName + "\">");
            //    oSB.Append("<ss:Table>");                
            //    oSB.Append("<ss:Column ss:Width=\"200\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"50\"/>");
            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"2\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "List of Discrepant Students" + "</ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"2\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Faculty: " + hidFacName.Value.TrimEnd(',') + "</ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"2\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Course: " + hidCrName.Value.TrimEnd(',') + "</ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"2\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Branch: " + hidBrName.Value.TrimEnd(',') + "</ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"2\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Course Part: " + hidCrPrDetName.Value.TrimEnd(',') + "</ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"2\"><ss:Data ss:Type=\"String\"></ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row ss:StyleID=\"1\">");
            //    for (int iCol = 0; iCol <= dtExport.Columns.Count - 1; iCol++)
            //    {
            //        oSB.Append("<ss:Cell><ss:Data ss:Type=\"String\">" + dtExport.Columns[iCol].ColumnName + "</ss:Data></ss:Cell>");
            //    }
            //    oSB.Append("</ss:Row>");

            //    for (int iRow = 0; iRow <= dtExport.Rows.Count - 1; iRow++)
            //    {
            //        oSB.Append("<ss:Row>");
            //        for (int iCol = 0; iCol <= dtExport.Columns.Count - 1; iCol++)
            //        {
            //            oSB.Append("<ss:Cell><ss:Data ss:Type=\"String\">" + dtExport.Rows[iRow][iCol].ToString() + "</ss:Data></ss:Cell>");
            //        }
            //        oSB.Append("</ss:Row>");
            //    }

            //    oSB.Append("</ss:Table>");
            //    oSB.Append("</ss:Worksheet>");

            //    oSB.Append("</ss:Workbook>");
            //    this.Response.ContentType = "application/vnd.ms-excel";
            //    this.Response.AddHeader("Content-Disposition", "attachment; filename = " + "ExportedStatisticsReport.xls;");
            //    this.Response.Write(oSB.ToString());
            //    writer2.Close();
            //    this.Response.End();
            //    if (dtExport != null) { dtExport = null; }

            //}
            //catch (Exception Ex3)
            //{

            //}

            #endregion

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
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=DiscrepantStudentsList.xls");
            Response.BinaryWrite(renderedBytes);
            Response.End();

            #endregion

        }

        #endregion

        #region PDF Export

        protected void btnPDF_Click(object sender, EventArgs e)
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
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=DiscrepantStudentsList.pdf");
            Response.BinaryWrite(renderedBytes);
            Response.End();

            #endregion
        }

        #endregion

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        #region CreateReport Region

        public void CreateReport()
        {
            try
            {
                #region Assign DataSet and Report Data Sourse Details

                DataTable dtExport = new DataTable();
                dtExport = (DataTable)GVStudent.DataSource;
                ReportDataSource ReportDetailsDS1 = new ReportDataSource("dsDiscStudents_dtDiscStudents", dtExport);
                ReportParameter[] p = new ReportParameter[5];               
                p.SetValue(new ReportParameter("SubHead", lblTitle.Text), 0);
                p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 1);
                p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 2);
                p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 3);
                p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + @"/Images/" + Classes.clsGetSettings.UniversityLogo
), 4);
                ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());

                #endregion

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Eligibility\Rdlc\DiscStudents.rdlc");

                #region Adding DataSet and Report Data Source to ReportViewer DataSources

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
            dtMultNomen.Columns.Add("PRN");
            dtMultNomen.Columns.Add("Course");

            DataRow dr = dtMultNomen.NewRow();
            dr["PRN"] = lblPRN.Text;
            dr["Course"] = lblCourse.Text;

            dtMultNomen.Rows.Add(dr);
            return dtMultNomen;
        }

        #endregion
    }
}
