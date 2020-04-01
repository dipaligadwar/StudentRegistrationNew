using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Classes;
using System.Data;
using StudentRegistration.Eligibility.ElgClasses;
using System.Threading;
using System.Globalization;
using System.Configuration;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptCrPrTermwiseUploadedandElgStatistics : System.Web.UI.Page
    {
        #region Variables

        DataTable dt;
        clsCommon oCommon;

        #endregion

        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion
        # region Page Load

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

        #endregion

        #region Button Generate Click

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            lblNoRec.Style.Add("display", "none");
            hid_fk_AcademicYr_ID.Value = ddlAcademicYr.SelectedItem.Text;
            dt = clsCollegeAdmissionReports.FillCrPrTrWiseUploadedElgStudentCountsReport(ddlAcademicYr.SelectedValue);
            Session["dtData"] = dt;
            if (dt.Rows.Count > 0)
            {
                //CreateReport();
                bindGrid();
            }

            else
            {
                lblNoRec.Style.Add("display", "block");
            }
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
                ReportDataSource ReportDetailsDS1 = new ReportDataSource("DS_CrPrTermwiseUploadedandElgStatistics", dtExport);
                ReportParameter[] p = new ReportParameter[5];
                //if (Request.QueryString["LandingPgStats"] != null)
                //{
                //    p.SetValue(new ReportParameter("AcYr", Request.QueryString["LandingPgStats"].ToString().Split('|')[1].ToString()), 0);
                //}
                //else
                //{
                //    p.SetValue(new ReportParameter("AcYr", hid_fk_AcademicYr_ID.Value), 0);
                //}
                p.SetValue(new ReportParameter("AcYr", hid_fk_AcademicYr_ID.Value), 0);
                p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 1);
                p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 2);
                p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 3);
                p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + "/Images/" + clsGetSettings.Logo
), 4);
                string RegCentre = string.Empty;

                //if (YCMOU.IsRegionalCenterVisible.Equals(true))
                //{
                //    if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
                //    {
                //        RegCentre = " for " + ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                //    }
                //    else
                //    {
                //        RegCentre = " for all Regional Centres";
                //    }
                //}


             //   p.SetValue(new ReportParameter("RegCentre", RegCentre), 5);

                ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());

                #endregion

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath + "Eligibility\\Rdlc\\CrPrTermwiseUploadedandElgStatistics.rdlc";

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

            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US"); //New CultureInfo("pl-PL");
            return dtMultNomen;
        }

        #endregion

        #region ReportViewer1 PreRender

        protected void ReportViewer1_PreRender(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        #endregion

        #region btnExportToExcel Click

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            #region Report Viewer Approach

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
            renderedBytes = ReportViewer1.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streams, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=UploadedStatisticsReport_" + sDateTime + ".xls");
            Response.BinaryWrite(renderedBytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();

            #endregion
        }

        #endregion

        #region btnPDF Click

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            #region Report Viewer Approach

            CreateReport();
            string sDateTime = DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, extension;
            //string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
            //  + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
            //  + "  <MarginLeft>0.6in</MarginLeft>" + "  <MarginRight>0.4in</MarginRight>"
            //  + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
            renderedBytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streams, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=UploadedStatisticsReport_" + sDateTime + ".pdf");
            Response.BinaryWrite(renderedBytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();

            #endregion
        }

        #endregion

        #region Grid View Events

        #region bindGrid

        private void bindGrid()
        {

            //hid_fk_AcademicYr_ID.Value = ddlAcademicYr.SelectedItem.Text;
            //dt = clsCollegeAdmissionReports.FillCrPrTrWiseUploadedElgStudentCountsReport(ddlAcademicYr.SelectedValue);
            //Session["dtData"] = dt;
            //if (dt.Rows.Count > 0 && dt!=null)
            //{

            GVReportEligibilitystat.DataSource = dt;
            GVReportEligibilitystat.DataBind();
            btnExcel.Style.Add("display", "block");
            btnPDF.Style.Add("display", "block");
            //divAcademicYr.Style.Add("display", "none");
            //BtnSubmit.Style.Add("display", "none");
            divDGStat.Style.Add("display", "block");
            //}

        }

        #endregion

        #region GVReportEligibilitystat RowDataBound

        protected void GVReportEligibilitystat_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //showing subtotals
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int sumDU = 0; int sumEl = 0; int sumEP = 0; int sumENP = 0; int sumNE = 0; int sumPR = 0; int sumPE = 0;

                for (int k = 0; k < e.Row.Cells.Count; k++)
                {
                    e.Row.Cells[k].Font.Bold = true;
                }

                for (int i = 0; i < ((GridView)sender).Rows.Count; i++)
                {
                    sumDU += Convert.ToInt32(((GridView)sender).Rows[i].Cells[3].Text);
                    sumEP += Convert.ToInt32(((GridView)sender).Rows[i].Cells[4].Text);
                    sumEl += Convert.ToInt32(((GridView)sender).Rows[i].Cells[5].Text);
                 
                    sumNE += Convert.ToInt32(((GridView)sender).Rows[i].Cells[6].Text);
                    sumPE += Convert.ToInt32(((GridView)sender).Rows[i].Cells[7].Text);
                    sumPR += Convert.ToInt32(((GridView)sender).Rows[i].Cells[8].Text);
                    sumENP += Convert.ToInt32(((GridView)sender).Rows[i].Cells[9].Text);

                }

                e.Row.Cells[3].Text = sumDU.ToString();
                e.Row.Cells[4].Text = sumEP.ToString();
                e.Row.Cells[5].Text = sumEl.ToString();               
                e.Row.Cells[6].Text = sumNE.ToString();
                e.Row.Cells[7].Text = sumPE.ToString();               
                e.Row.Cells[8].Text = sumPR.ToString();
                e.Row.Cells[9].Text = sumENP.ToString();
                e.Row.Cells[2].Text = "Total:";
                //e.Row.Cells[1].ColumnSpan = 2;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Cells[9].Style.Add("display", "none");
                //e.Row.Cells[10].Style.Add("display", "none");
                //e.Row.Cells[11].Style.Add("display", "none");
                //e.Row.Cells[12].Style.Add("display", "none");
            }
        }

        #endregion

        #endregion

        //    public void CreateReport()
        //    {
        //        try
        //        {
        //            #region Assign DataSet and Report Data Sourse Details

        //            DataTable dtExport = new DataTable();
        //            dtExport = ((System.Data.DataTable)Session["dtData"]).Copy();
        //            if (dtExport != null && dtExport.Rows.Count > 0)
        //            {
        //                ReportDataSource ReportDetailsDS1 = new ReportDataSource("DS_CrPrTermwiseUploadedandElgStatistics", dtExport);
        //                ReportParameter[] p = new ReportParameter[5];

        //                p.SetValue(new ReportParameter("AcYr", hid_fk_AcademicYr_ID.Value), 0);
        //                p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 1);
        //                p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 2);
        //                p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 3);
        //                p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + @"/Images/" + Classes.clsGetSettings.UniversityLogo
        //), 4);

        //                ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());

        //            #endregion

        //                ReportViewer1.LocalReport.DataSources.Clear();
        //                ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\Eligibility\Rdlc\CrPrTermwiseUploadedandElgStatistics.rdlc");

        //                #region Adding DataSet and Report Data Sourse to ReportViewer DataSources

        //                ReportViewer1.LocalReport.DataSources.Add(ReportDetailsDS1);
        //                ReportViewer1.LocalReport.DataSources.Add(MultNomDS);
        //                ReportViewer1.LocalReport.SetParameters(p);

        //                #endregion

        //                ReportViewer1.LocalReport.EnableExternalImages = true;
        //                ReportViewer1.LocalReport.Refresh();

        //                //********************code to hide Word in report viewer***********************************
        //                foreach (RenderingExtension extension in ReportViewer1.LocalReport.ListRenderingExtensions())
        //                {
        //                    if (extension.Name == "WORD")
        //                    {
        //                        System.Reflection.FieldInfo fi = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        //                        fi.SetValue(extension, false);
        //                    }
        //                }
        //                //****************************************************************************************
        //                DivReportViewerDesign.Style.Remove("display");
        //                DivReportViewerDesign.Style.Add("style", "block");
        //                DivReportInput.Style.Remove("display");
        //                DivReportInput.Style.Add("display", "none");
        //                DivNoReportMsg.Style.Remove("display");
        //                DivNoReportMsg.Style.Add("display", "none");
        //            }
        //            else
        //            {
        //                DivReportViewerDesign.Style.Remove("display");
        //                DivReportViewerDesign.Style.Add("style", "none");
        //                DivReportInput.Style.Remove("display");
        //                DivReportInput.Style.Add("display", "block");
        //                DivNoReportMsg.Style.Remove("display");
        //                DivNoReportMsg.Style.Add("display", "block");
        //            }
        //        }
        //        catch (Exception Ex)
        //        {
        //            Exception e = new Exception(Ex.Message, Ex);

        //        }

        //    }

    }
}