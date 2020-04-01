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
using System.IO;
using System.Text;
using Microsoft.Reporting.WebForms;
using System.Threading;
using System.Globalization;



namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptPaperExemptionCollegeWise : System.Web.UI.Page
    {
        #region variables
        clsCommon Common = new clsCommon();
        DataTable dtCollege;
        DataTable DT = new DataTable();
        clsUser user;
        private string instIDs = "";
        string CollName = "", CourseName = "";
        #endregion

        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["User"];
            if (!IsPostBack)
            {
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                btnNext_Click(this, e);
            }

            if (user.UserTypeCode == "2")
            {
                instIDs = user.UserReferenceID;
                hidInstID.Value = instIDs.ToString();
                hidCollName.Value = user.Name;
                lblAcaYear.Text = hidCollName.Value;
                btnNext_Click(this, e);
            }
        }

        #region btnNext_Click

        protected void btnNext_Click(object sender, EventArgs e)
        {
            tblExportedDataMsg.Style.Add("display", "none");
            try
            {
                DT = clsCollegeAdmissionReports.FillCollWisePaperExemptionOuterReport(hidUniID.Value);

                if (DT.Rows.Count > 0)
                {
                    GVCollege.DataSource = DT;
                    GVCollege.DataBind();
                    Button3.Style.Add("display", "block");
                    btnPDF.Style.Add("display", "block");
                    divDGStat.Style.Add("display", "block");
                    Session["dtCollWisePpExmRpt"] = DT;

                }

                if (((System.Data.DataTable)Session["dtCollWisePpExmRpt"]) == null || ((System.Data.DataTable)Session["dtCollWisePpExmRpt"]).Rows.Count == 0)
                {
                    lblExportedData.Text = "No records found.";
                    tblExportedDataMsg.Style.Add("display", "block");
                    Session.Remove("dtCollWisePpExmRpt");
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

        protected void GVCollege_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable DT = new DataTable();

            try
            {
                Session.Remove("dtInnerData");
                GridView selCollegeOuter = (GridView)sender;
                GridViewRow row = null;
                string index = e.CommandArgument.ToString();
                for (int i = 0; i < GVCollege.Rows.Count; i++)
                {
                    if (GVCollege.DataKeys[i]["pk_Inst_ID"].ToString().Equals(index))
                    {
                        row = GVCollege.Rows[i];
                        CollName = GVCollege.Rows[i].Cells[3].Text + " - ";
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
                        GridView gvCourseInner = (GridView)(row.Cells[1].FindControl("divHideMeCourse").FindControl("divCourseInnerHide").FindControl("GVInner"));


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
                            DT = clsCollegeAdmissionReports.FillCollWisePaperExemptionInnerReport(Request.QueryString["LandingPgStats"].ToString().Split('|')[0].ToString(), hidInstID.Value);
                        }
                        else
                        {
                            DT = clsCollegeAdmissionReports.FillCollWisePaperExemptionInnerReport(hidUniID.Value, hidInstID.Value);
                        }
                        if (DT.Rows.Count > 0)
                        {
                            innerGV.DataSource = DT;
                            innerGV.DataBind();
                            innerGV.Style.Add("display", "inline");
                            ((System.Web.UI.WebControls.Image)row.Cells[1].FindControl("imgdiv")).ImageUrl = "../Images/minus.gif";

                            GVCollege.Style.Add("display", "block");
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

        protected void GVCollege_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //showing subtotals

            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (clsGetSettings.OpenUniversity.Equals("No"))
                    e.Row.Cells[2].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (clsGetSettings.OpenUniversity.Equals("No"))
                    e.Row.Cells[2].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int sumG = 0; int sumP = 0; int sumD = 0;
                int cellIndex = 0;
                cellIndex = 5;
                for (int k = 0; k < e.Row.Cells.Count; k++)
                {
                    e.Row.Cells[k].Font.Bold = true;
                }

                for (int i = 0; i < ((GridView)sender).Rows.Count; i++)
                {
                    sumG += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex].Text);

                    sumD += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex+1].Text);
                    sumP += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex+2].Text);

                }

                e.Row.Cells[1].Text = sumG.ToString();
                e.Row.Cells[2].Text = sumD.ToString();
                e.Row.Cells[3].Text = sumP.ToString();
                e.Row.Cells[0].Text = "Total:";

                if(clsGetSettings.OpenUniversity.Equals("Yes"))
                e.Row.Cells[0].ColumnSpan = 5;
                else
                    e.Row.Cells[0].ColumnSpan = 4;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[cellIndex].Style.Add("display", "none");
                e.Row.Cells[cellIndex+1].Style.Add("display", "none");
                e.Row.Cells[cellIndex+2].Style.Add("display", "none");
                e.Row.Cells[cellIndex+3].Style.Add("display", "none");
            }
        }

        protected void GVInner_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable DT = new DataTable();

            try
            {
                Session.Remove("dtInnerData");
                GridView selCollegeInner = (GridView)sender;
                GridViewRow row = null;
                string index = e.CommandArgument.ToString();
                for (int i = 0; i < selCollegeInner.Rows.Count; i++)
                {
                    string toCheck = selCollegeInner.DataKeys[i]["pkFacID"].ToString() + "|" + selCollegeInner.DataKeys[i]["pkCrID"].ToString() + "|" + selCollegeInner.DataKeys[i]["pkMoLrnID"].ToString()
                        + "|" + selCollegeInner.DataKeys[i]["pkPtrnID"].ToString() + "|" + selCollegeInner.DataKeys[i]["pkBrnID"].ToString()
                        + "|" + selCollegeInner.DataKeys[i]["pkCrPrDetails"].ToString() + "|" +
                        selCollegeInner.DataKeys[i]["pkCrPrChID"].ToString() + "|" +
                        selCollegeInner.DataKeys[i]["pk_Inst_ID"].ToString();
                    CourseName = selCollegeInner.Rows[i].Cells[1].Text + " - ";
                    if (toCheck.Equals(index))
                    {
                        row = selCollegeInner.Rows[i];
                        hidFacID.Value = selCollegeInner.DataKeys[i]["pkFacID"].ToString();
                        hidCrID.Value = selCollegeInner.DataKeys[i]["pkCrID"].ToString();
                        hidPtrnID.Value = selCollegeInner.DataKeys[i]["pkPtrnID"].ToString();
                        hidMOLID.Value = selCollegeInner.DataKeys[i]["pkMoLrnID"].ToString();
                        hidBrnID.Value = selCollegeInner.DataKeys[i]["pkBrnID"].ToString();
                        hidCrPrDetID.Value = selCollegeInner.DataKeys[i]["pkCrPrDetails"].ToString();
                        hidCrPrChID.Value = selCollegeInner.DataKeys[i]["pkCrPrChID"].ToString();
                        hidInstID.Value = selCollegeInner.DataKeys[i]["pk_Inst_ID"].ToString();
                        break;
                    }
                }
                GridView innerSubGV = (GridView)row.FindControl("GVInnerSub");
                if (e.CommandName == "showHideSub")
                {
                    if (!innerSubGV.Style["display"].Equals("none"))
                    {
                        innerSubGV.Style.Add("display", "none");
                        ((System.Web.UI.WebControls.Image)row.Cells[0].FindControl("imgdiv")).ImageUrl = "../Images/plus.gif";
                        foreach (TableCell tc in row.Cells)
                        {
                            tc.BackColor = System.Drawing.Color.White;
                        }
                        ((HtmlGenericControl)row.Cells[1].FindControl("divCourseInnerHideSub")).Style.Add("display", "none");
                        ((HtmlGenericControl)row.Cells[1].FindControl("divHideMeCourseSub")).Style.Add("display", "none");


                    }
                    else if (innerSubGV.Style["display"].Equals("none"))
                    {

                        foreach (TableCell tc in row.Cells)
                        {
                            tc.BackColor = System.Drawing.Color.PeachPuff;
                        }
                        if (Request.QueryString["LandingPgStats"] != null)
                        {
                            DT = clsCollegeAdmissionReports.FillCollWisePaperExemptionSubInnerReport(Request.QueryString["LandingPgStats"].ToString().Split('|')[0].ToString(), hidFacID.Value, hidCrID.Value, hidMOLID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetID.Value, hidCrPrChID.Value, hidInstID.Value);
                        }
                        else
                        {
                            DT = clsCollegeAdmissionReports.FillCollWisePaperExemptionSubInnerReport(hidUniID.Value, hidFacID.Value, hidCrID.Value, hidMOLID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetID.Value, hidCrPrChID.Value, hidInstID.Value);
                        }
                        if (DT.Rows.Count > 0)
                        {
                            innerSubGV.DataSource = DT;
                            innerSubGV.DataBind();
                            innerSubGV.Style.Add("display", "inline");
                            ((System.Web.UI.WebControls.Image)row.Cells[1].FindControl("imgdiv")).ImageUrl = "../Images/minus.gif";

                            innerSubGV.Style.Add("display", "block");
                            ////divDGStat.Style.Add("display", "block");
                            ((HtmlGenericControl)row.Cells[1].FindControl("divCourseInnerHideSub")).Style.Add("display", "block");
                            ((HtmlGenericControl)row.Cells[1].FindControl("divHideMeCourseSub")).Style.Add("display", "block");

                        }
                    }

                }
            }
            catch (Exception Ex2)
            {
                throw new Exception(Ex2.Message);
            }
        }

        protected void GVInner_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                    LinkButton lnk = (LinkButton)e.Row.Cells[1].FindControl("lnkPlusSub");
                    lnk.CommandArgument = ((GridView)sender).DataKeys[e.Row.RowIndex]["pkFacID"].ToString() + "|" + ((GridView)sender).DataKeys[e.Row.RowIndex]["pkCrID"].ToString() + "|" + ((GridView)sender).DataKeys[e.Row.RowIndex]["pkMoLrnID"].ToString() + "|" + ((GridView)sender).DataKeys[e.Row.RowIndex]["pkPtrnID"].ToString() + "|" + ((GridView)sender).DataKeys[e.Row.RowIndex]["pkBrnID"].ToString() + "|" + ((GridView)sender).DataKeys[e.Row.RowIndex]["pkCrPrDetails"].ToString() + "|" + ((GridView)sender).DataKeys[e.Row.RowIndex]["pkCrPrChID"].ToString() + "|" + ((GridView)sender).DataKeys[e.Row.RowIndex]["pk_Inst_ID"].ToString();
            
            }

        }

        protected void GVSubInner_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                hidCollCourseDetails.Value = CollName.ToString() + CourseName.ToString();

                ((LinkButton)e.Row.Cells[4].FindControl("lnkStudList")).Text = "View Student List";
                ((LinkButton)e.Row.Cells[4].FindControl("lnkStudList")).Attributes.Add("onclick", "return openNewWindow(" + ((GridView)sender).DataKeys[e.Row.RowIndex]["pk_Pp_PpHead_CrPrCh_ID"].ToString() + "," + ((GridView)sender).DataKeys[e.Row.RowIndex]["pk_TchLrnMth_ID"].ToString() + "," + ((GridView)sender).DataKeys[e.Row.RowIndex]["pk_AssMth_ID"].ToString() + "," + ((GridView)sender).DataKeys[e.Row.RowIndex]["pk_AssType_ID"].ToString() + "," + ((GridView)sender).DataKeys[e.Row.RowIndex]["pk_Inst_ID"].ToString() + ");");
               
                ((LinkButton)e.Row.Cells[4].FindControl("lnkStudList")).ToolTip = "Click here to view the list of student(s).";
                ((LinkButton)e.Row.Cells[4].FindControl("lnkStudList")).ForeColor = System.Drawing.Color.Blue;
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
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=CollegewisePaperExemptionCounts.xls");
            Response.BinaryWrite(renderedBytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
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
            renderedBytes = ReportViewer1.LocalReport.Render("PDF", DeviceInfo, out mimeType, out encoding, out extension, out streams, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=CollegewisePaperExemptionCounts.pdf");
            Response.BinaryWrite(renderedBytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        #endregion

        #region CreateReport Region

        public void CreateReport()
        {
            try
            {
                #region Assign DataSet and Report Data Sourse Details

                DataTable dtExport = new DataTable();
                dtExport = ((System.Data.DataTable)Session["dtCollWisePpExmRpt"]).Copy();
                ReportDataSource ReportDetailsDS1 = new ReportDataSource("dsCollegewisePaperExemption_dtCollegewisePaperExemption", dtExport);
                ReportParameter[] p = new ReportParameter[4];

                p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 0);
                p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 1);
                p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 2);
                p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + @"/Images/" + Classes.clsGetSettings.UniversityLogo), 3);

                ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());

                #endregion

                ReportViewer1.LocalReport.DataSources.Clear();
                if(clsGetSettings.OpenUniversity.Equals("Yes"))
                ReportViewer1.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath+ "Eligibility\\Rdlc\\CollwisePpExem.rdlc";
                else
                    ReportViewer1.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath+ "Eligibility\\Rdlc\\CollwisePpExemWithOutRCcode.rdlc";

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
            dtMultNomen.Columns.Add("College");
            dtMultNomen.Columns.Add("Paper");

            DataRow dr = dtMultNomen.NewRow();
            dr["College"] = lblInstitute.Text;
            dr["Paper"] = lblPaper.Text;
            dtMultNomen.Rows.Add(dr);

            return dtMultNomen;
        }

        #endregion
    }
}
