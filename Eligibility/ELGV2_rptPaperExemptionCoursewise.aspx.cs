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
using System.Globalization;
using System.Threading;


namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptPaperExemptionCoursewise : System.Web.UI.Page
    {
        #region Variable Declaration

        DataTable DT = new DataTable();
        clsUser user;


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

                DT = clsCollegeAdmissionReports.FillPaperExemptionReportCoursewise(hidUniID.Value);
                if (DT.Rows.Count > 0)
                {
                    GVCourseStat.DataSource = DT;
                    GVCourseStat.DataBind();
                    btnExcel.Style.Add("display", "block");
                    btnPDF.Style.Add("display", "block");
                    GVCourseStat.Style.Add("display", "block");
                    Session["CoursewisedtData"] = DT;
                    msg.Text = "";
                    
                }
                else
                {
                    btnExcel.Style.Add("display", "none");
                    btnPDF.Style.Add("display", "none");
                    GVCourseStat.Style.Add("display", "none");
                    msg.Text = "No Record Found;";
                    msg.CssClass = "errorNote";
                }
            }
        }

        #endregion

        #region Grid View Events

        protected void GVCourseStat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string pk_Uni_ID = string.Empty,
                   pk_Fac_ID = string.Empty,
                   pk_Cr_ID = string.Empty,
                   pk_Brn_ID = string.Empty,
                   pk_Ptrn_ID = string.Empty,
                   pk_MoLrn_ID = string.Empty,
                   pk_CrPr_Details_ID = string.Empty,
                   pk_CrPrCh_ID = string.Empty;
                   pk_Uni_ID = hidUniID.Value;

            try
            {
                //Session.Remove("dtInnerData");
                GridView OuterGV = (GridView)sender;
                GridViewRow row = null;
                string index = e.CommandArgument.ToString();
                for (int i = 0; i < GVCourseStat.Rows.Count; i++)
                {
                    if (GVCourseStat.DataKeys[i]["Course Name"].ToString().Equals(index))
                    {
                        row = GVCourseStat.Rows[i];

                        pk_Fac_ID = GVCourseStat.DataKeys[i]["pkFacID"].ToString();
                        pk_Cr_ID = GVCourseStat.DataKeys[i]["pkCrID"].ToString();
                        pk_Brn_ID = GVCourseStat.DataKeys[i]["pkBrnID"].ToString();
                        pk_Ptrn_ID = GVCourseStat.DataKeys[i]["pkPtrnID"].ToString();
                        pk_MoLrn_ID = GVCourseStat.DataKeys[i]["pkMoLrnID"].ToString();
                        pk_CrPr_Details_ID = GVCourseStat.DataKeys[i]["pkCrPrDetails"].ToString();
                        pk_CrPrCh_ID = GVCourseStat.DataKeys[i]["pkCrPrChID"].ToString(); 

                        break;
                    }
                }
                GridView InnerGV = (GridView)row.FindControl("GVInner");
                if (e.CommandName == "showHide")
                {
                    if (!InnerGV.Style["display"].Equals("none"))
                    {
                        InnerGV.Style.Add("display", "none");
                        ((System.Web.UI.WebControls.Image)row.Cells[0].FindControl("imgdiv")).ImageUrl = "../Images/plus.gif";
                        foreach (TableCell tc in row.Cells)
                        {
                            tc.BackColor = System.Drawing.Color.White;
                        }
                        ((HtmlGenericControl)row.Cells[1].FindControl("divCourseInnerHide")).Style.Add("display", "none");
                        ((HtmlGenericControl)row.Cells[1].FindControl("divHideMeCourse")).Style.Add("display", "none");


                    }
                    else if (InnerGV.Style["display"].Equals("none"))
                    {

                        foreach (TableCell tc in row.Cells)
                        {
                            tc.BackColor = System.Drawing.Color.PeachPuff;
                        }
                        //hidInstID.Value = index;
                        //if (Request.QueryString["LandingPgStats"] != null)
                        //{
                        //    DT = clsCollegeAdmissionReports.FillMISReportSelected(Request.QueryString["LandingPgStats"].ToString().Split('|')[0].ToString(), hidInstID.Value);
                        //}
                        //else
                        //{
                        //    DT = clsCollegeAdmissionReports.FillMISReportSelected(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
                        //}


                        DT = clsCollegeAdmissionReports.FillPaperExemptionReportPaperTLMAMATWise(pk_Uni_ID, pk_Fac_ID, pk_Cr_ID, pk_MoLrn_ID, pk_Ptrn_ID, pk_Brn_ID, pk_CrPr_Details_ID, pk_CrPrCh_ID);

                        if (DT.Rows.Count > 0)
                        {
                            InnerGV.DataSource = DT;
                            InnerGV.DataBind();
                            InnerGV.Style.Remove("display"); 
                            InnerGV.Style.Add("display", "inline");
                            ((System.Web.UI.WebControls.Image)row.Cells[1].FindControl("imgdiv")).ImageUrl = "../Images/minus.gif";

                            GVCourseStat.Style.Add("display", "block");
                            divDGCourseStat.Style.Add("display", "block");
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

        protected void GVCourseStat_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //// Cells[3] -> Granted Count, Cells[4] -> Denied Count, Cells[5] -> Pending Count
          
            //showing subtotals
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int sumApproved = 0; int sumDenied = 0; int sumPending = 0; 

                for (int k = 0; k < e.Row.Cells.Count; k++)
                {
                    e.Row.Cells[k].Font.Bold = true;
                }

                for (int i = 0; i < ((GridView)sender).Rows.Count; i++)
                {
                    sumApproved += Convert.ToInt32(((GridView)sender).Rows[i].Cells[3].Text);
                    sumDenied += Convert.ToInt32(((GridView)sender).Rows[i].Cells[4].Text);
                    sumPending += Convert.ToInt32(((GridView)sender).Rows[i].Cells[5].Text);
                }

                e.Row.Cells[1].Text = sumApproved.ToString();
                e.Row.Cells[2].Text = sumDenied.ToString();
                e.Row.Cells[3].Text = sumPending.ToString();
                e.Row.Cells[0].Text = "Total:";
                e.Row.Cells[0].ColumnSpan = 3;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
            }
        }

        #endregion

        #region Excel Export

        protected void btnExcel_Click(object sender, EventArgs e)
        {

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
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=CoursewisePaperExemptionCounts.xls");
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
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, extension;
            string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
              + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
              + "  <MarginLeft>0.6in</MarginLeft>" + "  <MarginRight>0.4in</MarginRight>"
              + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
            renderedBytes = ReportViewer1.LocalReport.Render("PDF", DeviceInfo, out mimeType, out encoding, out extension, out streams, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=CoursewisePaperExemptionCounts.pdf");
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
                dtExport = ((System.Data.DataTable)Session["CoursewisedtData"]).Copy();
                ReportDataSource ReportDetailsDS1 = new ReportDataSource("dsCoursewisePaperExemption_dtCoursewisePaperExemption", dtExport);
                ReportParameter[] p = new ReportParameter[4];
                //if (Request.QueryString["LandingPgStats"] != null)
                //{
                //    p.SetValue(new ReportParameter("AcYr", Request.QueryString["LandingPgStats"].ToString().Split('|')[1].ToString()), 0);
                //}
                //else
                //{
                //    p.SetValue(new ReportParameter("AcYr", hid_AcademicYear.Value), 0);
                //}

                p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 0);
                p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 1);
                p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 2);
                p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + @"/Images/" + Classes.clsGetSettings.UniversityLogo
), 3);
                //string RegCentre = string.Empty;

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


                //p.SetValue(new ReportParameter("RegCentre", RegCentre), 5);

                ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());

                #endregion

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.ReportPath =clsGetSettings.PhysicalSitePath+ "Eligibility\\Rdlc\\CoursewisePaperExemption.rdlc";

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
