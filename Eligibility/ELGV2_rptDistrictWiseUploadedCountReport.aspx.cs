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
using StudentRegistration.Eligibility.ElgClasses;
using Classes;
using Microsoft.Reporting.WebForms;
using System.Globalization;
using System.Threading;


namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptDistrictWiseUploadedCountReport : System.Web.UI.Page
    {
        #region Variables

        DataTable dt;
        clsCommon oCommon;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //fill academic year
                dt = new DataTable();
                clsAcademicYear objAcadYear = new clsAcademicYear();
                dt = objAcadYear.ListAcademicYear();
                ViewState["AcademicYear"] = dt;
                oCommon = new clsCommon();
                oCommon.fillDropDown(ddlAcademicYr, dt, string.Empty, "Year", "pk_AcademicYear_ID", "---- Select ----");
                if (oCommon != null) { oCommon = null; }
            }
        }

        #region Button Generate Click

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            hid_fk_AcademicYr_ID.Value = ddlAcademicYr.SelectedItem.Text;
            dt = clsCollegeAdmissionReports.FillDistrictWiseUploadedStudentCountsReport(ddlAcademicYr.SelectedValue);
            Session["dtData"] = dt;
            if (dt.Rows.Count > 0)
            {
                ThrowExcel();  
            }

            else
            {
                lblNoRec.Style.Add("display", "block");
            }            
        }

        #endregion

        #region Excel Export

        protected void ThrowExcel()
        {
            #region Report Viewer Approach
            try
            {
                CreateReport();
                string sDateTime = DateTime.Now.ToString("ddMMyyyyhhmmsstt");
                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;
                string mimeType, encoding, extension;
                //string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>EXCEL</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
                //  + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
                //  + "  <MarginLeft>0.6in</MarginLeft>" + "  <MarginRight>0.4in</MarginRight>"
                //  + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
                renderedBytes = ReportViewer1.LocalReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streams, out warnings);
                string filename = string.Format("{0}.{1}", "DistrictWiseUploadedStudentCountsReport", "xls");
                //Response.ClearHeaders();
                Response.Clear();
                Response.Buffer = true;
                
                Response.ContentType = mimeType;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.BinaryWrite(renderedBytes);
                lblMessage.Style.Add("display", "block");
                Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest(); 
               
            }
            catch (Exception e) 
            {
                lblError.Style.Add("display", "block");
            }            

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
                dtExport = ((System.Data.DataTable)Session["dtData"]).Copy();
                ReportDataSource ReportDetailsDS1 = new ReportDataSource("dsDistrictWise_dtDistrictWise", dtExport);
                ReportParameter[] p = new ReportParameter[5];

                p.SetValue(new ReportParameter("AcYr", hid_fk_AcademicYr_ID.Value), 0);
                p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 1);
                p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 2);
                p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 3);
                p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + "Images/" + clsGetSettings.Logo,true
), 4);

                ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());

                #endregion

                ReportViewer1.LocalReport.DataSources.Clear();
                if(Classes.clsGetSettings.OpenUniversity.Equals("Yes"))
                    ReportViewer1.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath + "Eligibility\\Rdlc\\DistrictWiseUplStudCount.rdlc";
                else
                    ReportViewer1.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath + "Eligibility\\Rdlc\\DistrictWiseUplStudCountWithOutRCcode.rdlc";

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
            dtMultNomen.Columns.Add("College");

            DataRow dr = dtMultNomen.NewRow();
            dr["Course"] = lblCr.Text;
            dr["College"] = lblCollege.Text;

            dtMultNomen.Rows.Add(dr);
            return dtMultNomen;
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
