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
using System.Threading;
using System.Globalization;
using Ajax;
using AjaxControlToolkit;
using Microsoft.Reporting.WebForms;

namespace StudentRegistration.Eligibility
{
    public partial class rptStudProgrameValidity : System.Web.UI.Page
    {
        #region Variables

        clsCommon Common = new clsCommon();
        CourseRepository crRepository = new CourseRepository();
        DataTable dt1 = new DataTable();
        DataTable oDT;
        string date;
        clsUser user;
        private string[] IDs_List = new string[3];
        InstituteRepository oInstituteRepository = new InstituteRepository();
        DataTable dtCollege;
        clsEligibilityDBAccess oclsEligibilityDBAccess;

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["user"];
            DataTable dtInst = new DataTable();
           
            if (!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[2];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                
                Common.setHiddenVariables(ref hid);
                lblPageHead.Text = "Student Program Validity Report";
                if (hidUniID.Value == "")
                {
                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                    FillExamEvent(); 
                }


               // FillExamEvent();
                
            }


           

        }

        #endregion

        #region InitializeCulture

        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion


        #region btnDisplay_Click

        protected void btnGenerate_Click(object sender, EventArgs e)
        {

            
            CreateReport();
            //Warning[] warnings;
            //string[] streams;
            //byte[] renderedBytes;
            //string mimeType, encoding, extension;
            //string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
            //  + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
            //  + "  <MarginLeft>0.6in</MarginLeft>" + "  <MarginRight>0.4in</MarginRight>"
            //  + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
            //renderedBytes = ReportViewer1.LocalReport.Render("PDF", DeviceInfo, out mimeType, out encoding, out extension, out streams, out warnings);
            //Response.Buffer = true;
            //Response.Clear();
            //Response.ContentType = mimeType;
            //Response.AddHeader("content-disposition", "attachment; filename=ProgrameValidityReport.pdf");
            //Response.BinaryWrite(renderedBytes);
            //Response.Flush();
            //HttpContext.Current.ApplicationInstance.CompleteRequest();


          


        }

        #endregion

        #region CreateReport Region

        public void CreateReport()
        {
            try
            {
                ReportViewer rvReport = new ReportViewer();
                #region Assign DataSet and Report Data Sourse Details
                 DataSet DS;
                 clsReports oReport =  new clsReports();
                 DS = oReport.Get_ProgrameValidity_Report(hidUniID.Value, ddlExamEvent.SelectedValue);
                if (DS.Tables.Count != 0)
                {
                    DataTable dtExport = new DataTable();
                    dtExport = DS.Tables[0];
                    //  dtExport = ((System.Data.DataTable)Session["ViewElg_dtData"]).Copy();
                    ReportDataSource ReportDetailsDS1 = new ReportDataSource("DataSet1", dtExport);
                    ReportParameter[] p = new ReportParameter[4];

                    p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 0);
                    p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 1);
                    p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 2);
                    p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + @"Images/" + Classes.clsGetSettings.UniversityLogo), 3);
                    // ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());


                #endregion

                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath + "Eligibility\\Rdlc\\rptStudentProgrameValidity.rdlc";

                    #region Adding DataSet and Report Data Sourse to ReportViewer DataSources

                    ReportViewer1.LocalReport.DataSources.Add(ReportDetailsDS1);
                    // ReportViewer1.LocalReport.DataSources.Add(MultNomDS);
                    ReportViewer1.LocalReport.SetParameters(p);

                    #endregion
                   
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    ReportViewer1.LocalReport.Refresh();
                }

                string sDateTime = DateTime.Now.ToString("ddMMyyyyhhmmsstt");
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, filenameExtension;
                byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=ProgrameValidityReport_" + sDateTime + ".pdf");
                Response.BinaryWrite(bytes);

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

            DataRow dr = dtMultNomen.NewRow();
            dr["Course"] = lblPrvCourseNomenclature.Text;
            dr["PRN"] = lblPRNNomenclature.Text;

            dtMultNomen.Rows.Add(dr);
            return dtMultNomen;
        }

        #endregion

        #region FillExamEvent
        /// <summary>
        /// Fill the Exam Event drop down
        /// </summary>
        public void FillExamEvent()
        {

          
            clsReports oReport = new clsReports();
            ddlExamEvent.DataSource = oReport.ListEventResultReports();
            ddlExamEvent.DataTextField = "Text";
            ddlExamEvent.DataValueField = "Value";
            ddlExamEvent.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            ddlExamEvent.Items.Insert(0, li);
            //ddlExamEvent.DataSource = oReport.ListEventResultReports();
            //ddlExamEvent.DataTextField = "ExamEvent";
            //ddlExamEvent.DataValueField = "ExamEventID";
            //ddlExamEvent.DataBind();
            //ddlExamEvent.Items.Insert(0, li);

        }
        #endregion
    }
}

