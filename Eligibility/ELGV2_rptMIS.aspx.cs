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
using Ajax;
using AjaxControlToolkit;
using Classes;
using System.IO;
using System.Text;
using StudentRegistration.Eligibility.ElgClasses;
using Microsoft.Reporting.WebForms;
using System.Xml;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptMIS : System.Web.UI.Page
    {
        #region Variable declaration

        clsCommon Common = new clsCommon();
        DataTable dtCollege;
        DataTable DT = new DataTable();
        clsUser user;
        private string instIDs = "";

        #endregion

        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                ViewState["AcademicYear"] = dt;
                //Common.fillDropDown(ddlAcademicYr, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                //ddlAcademicYr.SelectedIndex = 0;
            }

            //hid_AcademicYear.Value = ddlAcademicYr.SelectedItem.Text;
            //hid_fk_AcademicYr_ID.Value = ddlAcademicYr.SelectedValue.ToString();

            hid_AcademicYear.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue;

            //hiding not required portions of user control
            YCMOU.IsInstituteDisplay = false;
            YCMOU.IsFacultyDisplay = false;
            YCMOU.IsCourseDisply = false;
            YCMOU.IsCoursePartDisply = false;
            YCMOU.IsCourseTermDisply = false;
            YCMOU.IsBranchDisply = false;
            YCMOU.IsReportUserAndDateDisplay = false;
            YCMOU.isMISRpt.Value = "Yes";
            YCMOU.OnProceedClick += btnNext_Click;
            //user = (clsUser)Session["User"];

            #region Handling Redirection from Landing page Panels

            if (Request.QueryString["LandingPgStats"] != null && GVStat.Rows.Count == 0)
            {
                string AcYrID = string.Empty;
                string AcYrText = string.Empty;
                if (Request.QueryString["LandingPgStats"] != null)
                {
                    AcYrID = Request.QueryString["LandingPgStats"].ToString().Split('|')[0].ToString();
                    AcYrText = Request.QueryString["LandingPgStats"].ToString().Split('|')[1].ToString();
                }

                DT = clsCollegeAdmissionReports.FillMISReportAll(AcYrID, null);
                if (DT.Rows.Count > 0)
                {
                    GVStat.DataSource = DT;
                    GVStat.DataBind();
                    Button3.Style.Add("display", "block");
                    btnPDF.Style.Add("display", "block");
                    divDGStat.Style.Add("display", "block");
                    divYCMOU.Style.Add("display", "none");
                    Session["MISdtData"] = DT;
                    lblAcaYear.Text = " [Academic Year " + AcYrText + "]";
                }
            }


            #endregion
        }

        #endregion

        #region btnNext_Click

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string RegCentreName = string.Empty;

            if (YCMOU.IsRegionalCenterVisible.Equals(true))
            {
                if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked)
                {
                    RegCentreName = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                    lblAcaYear.Text = " Regional Center " + RegCentreName + " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                }
                else
                {
                    lblAcaYear.Text = " All Regional Centers [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                }
            }
            else
            {
                lblAcaYear.Text = " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
            }


            tblExportedDataMsg.Style.Add("display", "none");
            try
            {

                if (YCMOU.IsRegionalCenterVisible.Equals(true))
                {
                    if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked)
                    {
                        DT = clsCollegeAdmissionReports.FillMISReportAll(((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue, ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedValue);
                    }
                    else
                    {
                        DT = clsCollegeAdmissionReports.FillMISReportAll(((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue, null);
                    }
                }
                else
                {
                    DT = clsCollegeAdmissionReports.FillMISReportAll(((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue, null);
                }


                Session["MISdtData"] = DT;
                if (DT.Rows.Count > 0)
                {
                    GVStat.DataSource = DT;
                    GVStat.DataBind();
                    Button3.Style.Add("display", "block");
                    btnPDF.Style.Add("display", "block");
                    //divAcademicYr.Style.Add("display", "none");
                    //BtnSubmit.Style.Add("display", "none");
                    divDGStat.Style.Add("display", "block");
                    divYCMOU.Style.Add("display", "none");
                }

                if (((System.Data.DataTable)Session["MISdtData"]) == null || ((System.Data.DataTable)Session["MISdtData"]).Rows.Count == 0)
                {
                    //lblAcaYear.Text = " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                    lblExportedData.Text = "No records found.";
                    tblExportedDataMsg.Style.Add("display", "block");
                    Session.Remove("MISdtData");
                    divDGStat.Style.Add("display", "none");

                }

                if (dtCollege != null)
                {
                    dtCollege = null;
                }

            }
            catch (Exception Ex4)
            {
                throw new Exception(Ex4.Message);
            }

        }

        #endregion

        #region Grid View Events

        protected void GVStat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //divAcademicYr.Style.Add("display", "none");
            //BtnSubmit.Style.Add("display", "none");
            try
            {
                Session.Remove("dtInnerData");
                GridView selCollegeOuter = (GridView)sender;
                GridViewRow row = null;
                string index = e.CommandArgument.ToString();
                for (int i = 0; i < GVStat.Rows.Count; i++)
                {
                    if (GVStat.DataKeys[i]["pk_Inst_ID"].ToString().Equals(index))
                    {
                        row = GVStat.Rows[i];
                        break;
                    }
                }
                GridView innerGV = (GridView)row.FindControl("GVInner");
                if (e.CommandName == "showHide")
                {
                    if (!innerGV.Style["display"].Equals("none"))
                    {
                        innerGV.Style.Add("display", "none");
                        ((System.Web.UI.WebControls.Image)row.Cells[0].FindControl("imgdiv")).ImageUrl = "../Images/plus.gif";
                        foreach (TableCell tc in row.Cells)
                        {
                            tc.BackColor = System.Drawing.Color.White;
                        }
                        ((HtmlGenericControl)row.Cells[1].FindControl("divCourseInnerHide")).Style.Add("display", "none");
                        ((HtmlGenericControl)row.Cells[1].FindControl("divHideMeCourse")).Style.Add("display", "none");


                    }
                    else if (innerGV.Style["display"].Equals("none"))
                    {

                        foreach (TableCell tc in row.Cells)
                        {
                            tc.BackColor = System.Drawing.Color.PeachPuff;
                        }
                        hidInstID.Value = index;
                        if (Request.QueryString["LandingPgStats"] != null)
                        {
                            DT = clsCollegeAdmissionReports.FillMISReportSelected(Request.QueryString["LandingPgStats"].ToString().Split('|')[0].ToString(), hidInstID.Value);
                        }
                        else
                        {
                            DT = clsCollegeAdmissionReports.FillMISReportSelected(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
                        }
                        if (DT.Rows.Count > 0)
                        {
                            innerGV.DataSource = DT;
                            innerGV.DataBind();
                            innerGV.Style.Add("display", "inline");
                            ((System.Web.UI.WebControls.Image)row.Cells[1].FindControl("imgdiv")).ImageUrl = "../Images/minus.gif";

                            GVStat.Style.Add("display", "block");
                            divDGStat.Style.Add("display", "block");
                            ((HtmlGenericControl)row.Cells[1].FindControl("divCourseInnerHide")).Style.Add("display", "block");
                            ((HtmlGenericControl)row.Cells[1].FindControl("divHideMeCourse")).Style.Add("display", "block");

                        }
                    }

                }
            }
            catch (Exception Ex2)
            {
                throw new Exception(Ex2.Message);
            }
        }

        protected void GVStat_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //showing subtotals
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (YCMOU.IsRegionalCenterVisible.Equals(false))
                    e.Row.Cells[5].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (YCMOU.IsRegionalCenterVisible.Equals(false))
                    e.Row.Cells[5].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int cellIndex = 8;

                int sumTU = 0; int sumEP = 0; int sumENP = 0; int sumDS = 0; int sumPD = 0;

                for (int k = 0; k < e.Row.Cells.Count; k++)
                {
                    e.Row.Cells[k].Font.Bold = true;
                }

                for (int i = 0; i < ((GridView)sender).Rows.Count; i++)
                {
                    sumTU += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex].Text);
                    sumEP += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex + 1].Text);
                    sumENP += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex + 2].Text);
                    sumDS += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex + 3].Text);
                    sumPD += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex + 4].Text);

                }

                e.Row.Cells[cellIndex - 4].Text = sumTU.ToString();
                e.Row.Cells[cellIndex - 3].Text = sumEP.ToString();
                e.Row.Cells[cellIndex - 2].Text = sumENP.ToString();
                e.Row.Cells[cellIndex - 1].Text = sumDS.ToString();
                e.Row.Cells[cellIndex].Text = sumPD.ToString();
                e.Row.Cells[cellIndex - 5].Text = "Total:";
                if (YCMOU.IsRegionalCenterVisible.Equals(false))
                    e.Row.Cells[cellIndex - 5].ColumnSpan = 4;
                else
                    e.Row.Cells[cellIndex - 5].ColumnSpan = 5;
                e.Row.Cells[cellIndex - 5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[cellIndex + 1].Style.Add("display", "none");
                e.Row.Cells[cellIndex + 2].Style.Add("display", "none");
                e.Row.Cells[cellIndex + 3].Style.Add("display", "none");
                e.Row.Cells[cellIndex + 4].Style.Add("display", "none");


            }
        }

        #endregion

        #region Excel Export

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            #region XMl Approach
            //try
            //{
            //    StringWriter writer2 = new StringWriter();
            //    StringBuilder oSB = new StringBuilder();
            //    DataTable dtExport = new DataTable();
            //    dtExport = ((System.Data.DataTable)Session["MISdtData"]).Copy();

            //    dtExport.Columns.Remove("pk_Inst_ID");

            //    oSB.Append("<?xml version=\"1.0\"?>");
            //    oSB.Append("<ss:Workbook xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            //    oSB.Append("<ss:Styles>");
            //    oSB.Append("<ss:Style ss:ID=\"1\">");
            //    oSB.Append("<ss:Font ss:Bold=\"1\"/>");
            //    oSB.Append("</ss:Style>");
            //    oSB.Append("</ss:Styles>");

            //    oSB.Append("<ss:Worksheet ss:Name=\"" + dtExport.TableName + "\">");
            //    oSB.Append("<ss:Table>");
            //    oSB.Append("<ss:Column ss:Width=\"74\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"300\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"115\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"115\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"120\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"115\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"115\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"115\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"115\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"115\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"120\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"120\"/>");
            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"10\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Academic Year: " + ddlAcademicYr.SelectedItem.Text + "</ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"10\"><ss:Data ss:Type=\"String\"></ss:Data></ss:Cell>");
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
             string sDateTime = DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, extension;
            string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>EXCEL</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
              + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
              + "  <MarginLeft>0.6in</MarginLeft>" + "  <MarginRight>0.4in</MarginRight>"
              + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
            renderedBytes = ReportViewer1.LocalReport.Render("EXCEL", DeviceInfo, out mimeType, out encoding, out extension, out streams, out warnings);
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

        #region PDF Export

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            #region Report Viewer Approach

            CreateReport();
            string sDateTime = DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, extension;
            string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
              + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
              + "  <MarginLeft>0.25in</MarginLeft>" + "  <MarginRight>0.25in</MarginRight>"
              + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
            renderedBytes = ReportViewer1.LocalReport.Render("PDF", DeviceInfo, out mimeType, out encoding, out extension, out streams, out warnings);
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

        #region CreateReport Region

        public void CreateReport()
        {
            try
            {
                #region Assign DataSet and Report Data Sourse Details

                DataTable dtExport = new DataTable();
                dtExport = ((System.Data.DataTable)Session["MISdtData"]).Copy();
                ReportDataSource ReportDetailsDS1 = new ReportDataSource("dsMIS_dtMIS", dtExport);
                ReportParameter[] p = new ReportParameter[6];
                if (Request.QueryString["LandingPgStats"] != null)
                {
                    p.SetValue(new ReportParameter("AcYr", Request.QueryString["LandingPgStats"].ToString().Split('|')[1].ToString()), 0);
                }
                else
                {
                    p.SetValue(new ReportParameter("AcYr", hid_AcademicYear.Value), 0);
                }

                p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 1);
                p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 2);
                p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 3);
                p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + "Images/" + clsGetSettings.Logo,true
), 4);
                string RegCentre = string.Empty;
                bool isDisplayRCCodeInReport = false;
                if (YCMOU.IsRegionalCenterVisible.Equals(true))
                {
                    isDisplayRCCodeInReport = true;
                    if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
                    {
                        RegCentre = " for " + ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                    }
                    else
                    {
                        RegCentre = " for all Regional Centres";
                    }
                }


                p.SetValue(new ReportParameter("RegCentre", RegCentre), 5);
                

                ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());

                #endregion
                
                ReportViewer1.LocalReport.DataSources.Clear();
                if(isDisplayRCCodeInReport)
                ReportViewer1.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath+ "Eligibility\\Rdlc\\MIS.rdlc"; 
                else
                    ReportViewer1.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath + "Eligibility\\Rdlc\\MISWithOutRCcode.rdlc";
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
            dtMultNomen.Columns.Add("Paper");

            DataRow dr = dtMultNomen.NewRow();
            dr["Course"] = lblCr.Text;
            dr["College"] = lblCollege.Text;
            dr["Paper"] = lblPaper.Text;

            dtMultNomen.Rows.Add(dr);
            return dtMultNomen;
        }

        #endregion


    }
}
