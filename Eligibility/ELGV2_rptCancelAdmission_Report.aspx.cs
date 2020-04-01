using System;
using Microsoft.Reporting.WebForms;
using System.Data;
using Classes;
using System.Collections;
using StudentRegistration.Eligibility.ElgClasses;
using System.Globalization;
using System.Threading;
using System.Configuration;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptCancelAdmission_Report : System.Web.UI.Page
    {
        clsCommon Common = new clsCommon();
        
        protected void Page_Load(object sender, EventArgs e)
        {

          

            if (!IsPostBack)
            {
                lblPageHead.Text = "Cancel Admission Report";
                
                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                ViewState["AcademicYear"] = dt;
                Common.fillDropDown(ddlAcademicYr, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                ddlAcademicYr.SelectedIndex = 0;
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
           // CreateReport();
            BindReport();
            //if (BindReport())
            //{
            //    GenerateReport("EXCEL", ".xls");
            //}
        }

        #region CreateReport Region

        //public void CreateReport()
        //{
        //    try
        //    {


        //        Hashtable ht = new Hashtable();
        //        ht.Add("fk_AcademicYear_ID", ddlAcademicYr.SelectedValue);
        //        clsStudent objStudent = new clsStudent();
        //        DataTable dtCancelAdmission = objStudent.CancelAdmissionReport(ht).Tables[0];

        //        if (dtCancelAdmission != null && dtCancelAdmission.Rows.Count > 0)
        //        {

        //            ReportDataSource ReportDetailsDS1 = new ReportDataSource("DSCancelAdmission", dtCancelAdmission);

        //            ReportParameter[] p = new ReportParameter[6];

        //            p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 0);
        //            p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 1);
        //            p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 2);
        //            p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + @"/Images/" + Classes.clsGetSettings.UniversityLogo), 3);





        //            rptViewer.LocalReport.DataSources.Clear();

        //            rptViewer.LocalReport.ReportPath = Server.MapPath(@"~\Eligibility\Rdlc\rpt_CancelAdmission.rdlc");
        //            rptViewer.LocalReport.EnableExternalImages = true;


        //            rptViewer.LocalReport.DataSources.Add(ReportDetailsDS1);
        //            rptViewer.LocalReport.SetParameters(p);

        //            rptViewer.LocalReport.Refresh();
        //        }
        //        else
        //        {
        //            lblSave.Text = "No data found.";
        //            lblSave.CssClass = "ErrorNote";
        //        }


        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception e = new Exception(Ex.Message, Ex);

        //    }

        //}

        #endregion

        private bool BindReport()
        {
            DataTable oDt = null;
            Hashtable oHt = new Hashtable();
            clsUser oUser = null;
            oUser = (clsUser)Session["User"];
            oHt.Add("fk_AcademicYear_ID", ddlAcademicYr.SelectedValue);
            clsStudent objStudent = new clsStudent();

            try
            {
                using (oDt = objStudent.CancelAdmissionReport(oHt).Tables[0])
                {
                    if (oDt != null && oDt.Rows.Count > 0)
                    {
                        rptViewer.LocalReport.DataSources.Clear();
                        rptViewer.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath + @"Eligibility\Rdlc\rpt_CancelAdmission.rdlc";
                        ReportDataSource oRds = new ReportDataSource("DSCancelAdmission", oDt);
                        ReportParameter[] param = new ReportParameter[8];
                        param[0] = new ReportParameter("UniName", clsGetSettings.UniversityName.ToString(), true);
                        param[1] = new ReportParameter("UniLogo", clsGetSettings.SitePath + "Images/" + clsGetSettings.Logo, true);
                        param[2] = new ReportParameter("UniSitePath", clsGetSettings.SitePath.ToString(), true);
                        param[3] = new ReportParameter("UniversityCity", clsGetSettings.UniversityCity, true);
                        param[4] = new ReportParameter("UserName", oUser.Name, true);
                        param[5] = new ReportParameter("Address", clsGetSettings.Address, true);
                        string sCriteria = "Branch Change details for " + oUser.Name; ;
                        param[6] = new ReportParameter("ReportCriteria", sCriteria, true);
                        param[7] = new ReportParameter("Culture", CultureInfo.CurrentCulture.Name);
                        //param[7] = new ReportParameter("UniId", clsGetSettings.UniversityID.ToString(), true);
                        ReportDataSource MultNomDS = new ReportDataSource("dsMultiNom", MultinomenClature());
                        rptViewer.LocalReport.EnableExternalImages = true;
                        rptViewer.LocalReport.SetParameters(param);
                        rptViewer.LocalReport.DataSources.Add(oRds);
                        rptViewer.LocalReport.DataSources.Add(MultNomDS);
                        rptViewer.LocalReport.Refresh();

                        DivReportViewerDesign.Visible = true;
                        divAllCriterion.Visible = false;
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Visible = true;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }


        private void GenerateReport(string Format, string extension)
        {
            string sDateTime = DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            Warning[] warnings;
            string[] streamids;
            string mimeType, encoding, filenameExtension;
            byte[] bytes = rptViewer.LocalReport.Render(Format, null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=CancelAdmission_" + sDateTime + extension);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }




        public DataTable MultinomenClature()
        {
            DataTable dtMultNomen = new DataTable();
            dtMultNomen.Columns.Add("Course");
            dtMultNomen.Columns.Add("PRN");
            dtMultNomen.Columns.Add("College");
            dtMultNomen.Columns.Add("Paper");


            DataRow dr = dtMultNomen.NewRow();
            dr["Course"] = lblCourse.Text;
            dr["PRN"] = lblPRN.Text;
            dr["College"] = lblCollege.Text;
            dr["Paper"] = lblPaper.Text;
            dtMultNomen.Rows.Add(dr);
            return dtMultNomen;
        }


        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        protected void rptViewer_PreRender(object sender, EventArgs e)
        {

            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

       

    }
}




       
        