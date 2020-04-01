using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;
using System.Threading;
using System.Globalization;
using Microsoft.Reporting.WebForms;
using System.Collections;
using System.Web;


namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rpt_FormBReport : System.Web.UI.Page
    {
        clsUser user = null;
        private string instIDs = "";
        DataTable oDt;
        Hashtable oHt = null;
        private string[] IDs_List = new string[3];
        DataTable DT = new DataTable();
        clsReports oReport = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["User"];
            if (!IsPostBack)
            {
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                YCMOU.hidTerms.Value = string.Empty;
            }
            if (user.UserTypeCode == "2")
            {
                instIDs = user.UserReferenceID;
                hidInstID.Value = instIDs.ToString();
                YCMOU.IsCollegeLogin = true;
                hidCollName.Value = user.Name;
                lblAcaYear.Text = hidCollName.Value;
            }

           // YCMOU.isDiscRpt.Value = "Yes";
            YCMOU.IsReportUserAndDateDisplay = false;
            YCMOU.IsInstituteDisplay = false;
            YCMOU.OnProceedClick += btnNext_Click;
            YCMOU.OnPartChange += ddlCrPrDetailsDesc_SelectedIndexChanged;
            YCMOU.IsCourseTermDisply = false;
            //BindReport();
        }
        protected void ddlCrPrDetailsDesc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void getFacCrMoLrnPtrnID()
        {
            if (((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedValue != "0")
            {
                IDs_List = Convert.ToString(((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedValue).Split('-');
                hidFacID.Value = Convert.ToString(IDs_List[0]).Trim();
                hidCrID.Value = Convert.ToString(IDs_List[1]).Trim();
                hidMoLrnID.Value = Convert.ToString(IDs_List[2]).Trim();
                hidPtrnID.Value = Convert.ToString(IDs_List[3]).Trim();
            }
            else
            {
                if (((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedValue == "0")
                {
                    hidCrID.Value = "0";
                    hidMoLrnID.Value = "0";
                    hidPtrnID.Value = "0";
                }
                hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            string courseOrColl = string.Empty;
            string collName = string.Empty;
            if (user.UserTypeCode != "2")
            {
                hidInstID.Value = string.Empty;
                hidCollName.Value = string.Empty;
            }
            hidFacName.Value = string.Empty;
            hidCrName.Value = string.Empty;
            hidBrName.Value = string.Empty;
            hidCrPrDetName.Value = string.Empty;
            hidCrPrChName.Value = string.Empty;
            hidCrPrChIds.Value = string.Empty;
            hidCrPrChNames.Value = string.Empty;
            hidCrName.Value = ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " " +((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text;
            //Session.Remove("Ddtdata");
            

            hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
            getFacCrMoLrnPtrnID();
            hidBrnID.Value = ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedValue;
            hidCrPrDetailsID.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedValue;
            hidCrPrChID.Value = ((CheckBoxList)YCMOU.FindControl("chkChild")).SelectedValue;
            lblAcaYear.Text = courseOrColl + " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";

            if (BindReport())
            {
                GenerateReport("EXCEL", ".xls");
            }

            //DT = clsCollegeAdmissionReports.FillDiscrepancyReport(((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), YCMOU.hidCrPrChIds.Value, null);

            //if (DT.Rows.Count > 0)
            //{

            //}




        }


        protected void ExptToExl_Click(object sender, EventArgs e)
        {
            if (BindReport())
            {
                GenerateReport("EXCEL", ".xls");
            }
        }


        //protected void ExptToPDF_Click(object sender, EventArgs e)
        //{
        //    if (BindReport())
        //    {
        //        GenerateReport("PDF", ".pdf");
        //    }

        //}
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
            Response.AddHeader("content-disposition", "attachment; filename=FormBReport_" + sDateTime + extension);
            Response.BinaryWrite(bytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            
        }
        private bool BindReport()
        {
         CreateHashTable();
         oReport = new clsReports();
         DataSet oDs = null;
         using (oDs = oReport.GetFormBReportData(oHt))
            {
                if (oDs != null && oDs.Tables.Count > 0 && oDs.Tables[0] != null && oDs.Tables[0].Rows.Count > 0)
                {
                    oDt = oDs.Tables[0];
                    rptViewer.LocalReport.DataSources.Clear();
                    rptViewer.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath + "Eligibility\\Rdlc\\rptFormB.rdlc";
                    ReportDataSource oRds = new ReportDataSource("dsFormB", oDt);
                    ReportParameter[] param = new ReportParameter[5];
                    param[0] = new ReportParameter("College", oDt.Rows[0]["Inst_Name"].ToString(), true);
                    param[1] = new ReportParameter("Term", hidCrName.Value, true);
                    param[2] = new ReportParameter("IntakeCapcity", oDt.Rows[0]["IntakeCapacity"].ToString(), true);
                    param[3] = new ReportParameter("University", clsGetSettings.UniversityName, true);
					param[4] = new ReportParameter("AcademicYear", ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text, true);
					//param[2] = new ReportParameter("UniSitePath", clsGetSettings.SitePath.ToString(), true);
                    //param[3] = new ReportParameter("UniversityCity", clsGetSettings.UniversityCity, true);
                    //param[4] = new ReportParameter("userName", user.Name, true);
                    //param[5] = new ReportParameter("Address", clsGetSettings.Address, true);
                    //string sCriteria = "Branch Change details for " + user.Name; ;
                    //param[6] = new ReportParameter("ReportCriteria", sCriteria, true);
                    ReportDataSource MultNomDS = new ReportDataSource("dsMultiNom", MultinomenClature());
                    ReportDataSource DSFormBSummaryMed = null;
                    ReportDataSource DSFormBSummaryCat =null;
                    if(oDs.Tables[2]!=null && oDs.Tables[2].Rows.Count>0)
                        DSFormBSummaryMed = new ReportDataSource("DSFormBSummaryMed", oDs.Tables[2]);
                    if(oDs.Tables[1]!=null && oDs.Tables[1].Rows.Count>0)
                        DSFormBSummaryCat = new ReportDataSource("DSFormBSummaryCat", oDs.Tables[1]);
                    rptViewer.LocalReport.EnableExternalImages = true;
                    rptViewer.LocalReport.SetParameters(param);
                    rptViewer.LocalReport.DataSources.Add(oRds);
                    rptViewer.LocalReport.DataSources.Add(DSFormBSummaryMed);
                    rptViewer.LocalReport.DataSources.Add(DSFormBSummaryCat);
                    rptViewer.LocalReport.DataSources.Add(MultNomDS);
                    rptViewer.LocalReport.Refresh();
                    return true;
                }
                else
                {
                    lblErrorMsg.Visible = true;
                    return false;
                }
            }
        }
        private void CreateHashTable()
        {
            oHt = new Hashtable();
            oHt["UniID"] = hidUniID.Value.Trim();
            oHt["InstID"] = hidInstID.Value.Trim();
            oHt["FacID"] = hidFacID.Value.Trim();
            oHt["CrID"] = hidCrID.Value.Trim();
            oHt["MoLrnID"] = hidMoLrnID.Value.Trim();
            oHt["PtrnID"] = hidPtrnID.Value.Trim();
            oHt["BrnID"] = hidBrnID.Value.Trim();
            oHt["CrPrDetailsID"] = hidCrPrDetailsID.Value.Trim();
            oHt["AcademicYearID"] = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue;
            oHt["User"] = user.User_ID;
            
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
    }
}



      

        

       