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
using System.Threading;
using System.Globalization;
using StudentRegistration.Eligibility.ElgClasses;
using Ajax;
using AjaxControlToolkit;
using Classes;
using System.IO;
using System.Text;
using Microsoft.Reporting.WebForms;


namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperExemptionCollegeWise__1 : System.Web.UI.Page
    {
        DataTable dt;
        string Ppname;

        protected void Page_Load(object sender, EventArgs e)
        {
            hidInstID.Value = Request.QueryString["InstID"].ToString();
            hidPpCrPrChID.Value = Request.QueryString["PpCrPrChID"].ToString();
            hidTLMID.Value = Request.QueryString["TchLrMthID"].ToString();
            hidAMID.Value = Request.QueryString["AMthID"].ToString();
            hidATID.Value = Request.QueryString["ATypeID"].ToString();
            hidCollCourseDetails.Value = Request.QueryString["CollCourseDetails"].ToString();
           
            //lblTitle.Text = hidFacName.Value + " - " + hidCrName.Value + " - " + hidBrName.Value + " - " + hidCrPrDetName.Value + " - " + hidCrPrChName.Value + " [Academic Year " + strAcademicYr1.ToString() + "-" + strAcademicYr2.ToString() + "]";
            fillGrid();
            Ppname = dt.Rows[0]["Paper TLM-AM-AT"].ToString(); 
            lblPageHead.Text = "List of Students for "+  "<font COLOR='BLACK'>" + hidCollCourseDetails.Value.ToString() + Ppname + "</font>";
        }

        #region fillGrid

        private void fillGrid()
        {
            if (ViewState["SortExpression"] == null)
            {
                dt = clsCollegeAdmissionReports.FillStudentListPaperExemptionReportCollegeWise(hidPpCrPrChID.Value,hidTLMID.Value,hidAMID.Value,hidATID.Value,hidInstID.Value);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    GVStudent.DataSource = dt;
                    GVStudent.DataBind();
                    Session["DTStudent"] = dt;

                }
                else
                {
                    GVStudent.Visible = false;
                }
            }
            else
            {
                DataView Ddv = new DataView(dt);
                Ddv.Sort = ViewState["SortExpression"].ToString();
                GVStudent.DataSource = Ddv;
                GVStudent.DataBind();
            }
        }

        #endregion

        #region Excel Export

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
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
            Response.AddHeader("content-disposition", "attachment; filename=PaperExemptionStudentList.xls");
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }

        #endregion

        #region PDF Export

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            CreateReport();

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, extension;
            string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
             + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
             + "  <MarginLeft>0.6in</MarginLeft>" + "  <MarginRight>0.4in</MarginRight>"
             + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
            ReportViewer1.LocalReport.EnableExternalImages = true;
            renderedBytes = ReportViewer1.LocalReport.Render("PDF", DeviceInfo, out mimeType, out encoding, out extension, out streams, out warnings);
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=PaperExemptionStudentList.pdf");
            Response.BinaryWrite(renderedBytes);
            Response.End();
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
                #region Assign DataSet and Report Data Source Details

                DataTable dtExport = new DataTable();
                dtExport = ((System.Data.DataTable)Session["DTStudent"]).Copy();
                ReportDataSource ReportDetailsDS1 = new ReportDataSource("dsCollegewisePaperExemption__1_dtStudentList", dtExport);
                ReportParameter[] p = new ReportParameter[5];
                
                p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 0);
                p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 1);
                p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 2);
                p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + @"/Images/" + Classes.clsGetSettings.UniversityLogo), 3);
                p.SetValue(new ReportParameter("Heading", hidCollCourseDetails.Value.ToString() + Ppname),4);

                ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());

                #endregion

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Eligibility\Rdlc\CollwisePpExemStud.rdlc");

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

            DataRow dr = dtMultNomen.NewRow();
            dr["PRN"] = lblPRN.Text;
            dtMultNomen.Rows.Add(dr);

            return dtMultNomen;
        }

        #endregion
    }
}
