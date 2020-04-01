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
using StudentRegistration.Eligibility.ElgClasses;
using System.Threading;
using System.Globalization;
using System.Text;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptDiscrepancyReport : System.Web.UI.Page
    {
        #region Variable Declaration

        CourseRepository crRepository = new CourseRepository();
        clsCommon Common = new clsCommon();
        InstituteRepository oInstituteRepository = new InstituteRepository();
        DataTable DT = new DataTable();
        private string[] IDs_List = new string[3];
        DataTable oDT;
        clsUser user;
        DataTable dtCollege;
        private string instIDs = "";
        clsEligibilityDBAccess oclsEligibilityDBAccess;
        DataSet dsReport;
        string crprch_ids = string.Empty;
        string crprch_names = string.Empty;

        #endregion

        #region Page Load

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

            YCMOU.isDiscRpt.Value = "Yes";
            YCMOU.IsReportUserAndDateDisplay = false;
            YCMOU.IsInstituteDisplay = false;
            YCMOU.OnProceedClick += btnNext_Click;
            YCMOU.OnPartChange += ddlCrPrDetailsDesc_SelectedIndexChanged;
            YCMOU.IsCourseTermDisply = false;


            hid_AcademicYear.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue;

            tblExportedDataMsg.Style.Add("display", "none");

            #region Back Navigation
            if (Page.PreviousPage != null)
            {
                if (Request.QueryString["Navigate"] == "back")
                {
                    HideSearchCriteria();

                    ContentPlaceHolder CnDet = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                    hidFacName.Value = ((HtmlInputHidden)CnDet.FindControl("hidFacName")).Value;
                    hidCrName.Value = ((HtmlInputHidden)CnDet.FindControl("hidCrName")).Value;
                    hidBrName.Value = ((HtmlInputHidden)CnDet.FindControl("hidBrName")).Value;
                    hidCrPrDetName.Value = ((HtmlInputHidden)CnDet.FindControl("hidCrPrDetName")).Value;
                    hidCrPrChName.Value = ((HtmlInputHidden)CnDet.FindControl("hidCrPrChName")).Value;
                    hidCrPrName.Value = ((HtmlInputHidden)CnDet.FindControl("hidCrPrName")).Value;
                    hidRCName.Value = ((HtmlInputHidden)CnDet.FindControl("hidRCName")).Value;
                    hidRCID.Value = ((HtmlInputHidden)CnDet.FindControl("hidRCID")).Value;

                    string courseOrColl = string.Empty;
                    if (hidRCID.Value != string.Empty)
                    {
                        DT = clsCollegeAdmissionReports.FillDiscrepancyReport(Request.QueryString["AcYrId"].ToString(), hidInstID.Value, Request.QueryString["FacId"].ToString(), Request.QueryString["CrId"].ToString(), Request.QueryString["MoLrnId"].ToString(), Request.QueryString["PtrnId"].ToString(), Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["crprchids"]), hidRCID.Value);
                    }
                    else
                    {
                        DT = clsCollegeAdmissionReports.FillDiscrepancyReport(Request.QueryString["AcYrId"].ToString(), hidInstID.Value, Request.QueryString["FacId"].ToString(), Request.QueryString["CrId"].ToString(), Request.QueryString["MoLrnId"].ToString(), Request.QueryString["PtrnId"].ToString(), Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["crprchids"]), null);
                    }
                    Session["DdtData"] = DT;
                    if (DT.Rows.Count > 0)
                    {
                        GVReport.DataSource = DT;
                        GVReport.DataBind();
                        GVReport.Style.Add("display", "block");
                        string RegCentreName = string.Empty;
                        if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked)
                        {
                            RegCentreName = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                            courseOrColl = " for " + hidFacName.Value + " - " + hidCrName.Value + " - " + hidBrName.Value + " - " + hidCrPrDetName.Value + " - " + hidCrPrChName.Value + " for Regional Center " + RegCentreName;
                        }
                        else
                        {
                            courseOrColl = " for " + hidFacName.Value + " - " + hidCrName.Value + " - " + hidBrName.Value + " - " + hidCrPrDetName.Value + " - " + hidCrPrChName.Value + " for All Regional Centers ";

                        }
                        lblAcaYear.Text = courseOrColl + " [Academic Year " + Request.QueryString["AcYrName"].ToString() + "]";
                    }
                    if (DT != null)
                    {
                        DT = null;
                    }

                }
            }
            #endregion

        }

        #endregion

        #region Filling DropDowns

        protected void ddlCrPrDetailsDesc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region getFacCrMoLrnPtrnID

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

        #endregion

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        #region btnNext_Click

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
            Session.Remove("Ddtdata");
            try
            {
                hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
                getFacCrMoLrnPtrnID();
                hidCrPrDetailsID.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedValue;
                hidCrPrChID.Value = ((CheckBoxList)YCMOU.FindControl("chkChild")).SelectedValue;
                //****************************************************************
                if (YCMOU.IsRegionalCenterLogin == "True")
                {
                    hidInstID.Value = string.Empty;
                    DT = clsCollegeAdmissionReports.FillDiscrepancyReport(((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), YCMOU.hidCrPrChIds.Value, user.UserReferenceID);
                }
                //****************************************************************
                else if (hidInstID.Value.Equals(string.Empty))
                {
                    if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked)
                    {
                        if (((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedIndex != 0)
                            DT = clsCollegeAdmissionReports.FillDiscrepancyReport(((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), YCMOU.hidCrPrChIds.Value, ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedValue, ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedValue.Split('|')[0]);
                        else
                            DT = clsCollegeAdmissionReports.FillDiscrepancyReport(((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), YCMOU.hidCrPrChIds.Value, ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedValue);
                    }
                    else
                    {
                        DT = clsCollegeAdmissionReports.FillDiscrepancyReport(((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), YCMOU.hidCrPrChIds.Value, null);
                    }
                }

                //college login
                else
                {
                    DT = clsCollegeAdmissionReports.FillDiscrepancyReport(((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), YCMOU.hidCrPrChIds.Value, null);
                }
                Session["DdtData"] = DT;
                if (DT.Rows.Count > 0)
                {
                    if (GVReport.Columns[3].HeaderText == "")
                    {
                        string[] terms = YCMOU.hidCrPrChIds.Value.Split(',');
                        if (int.Parse(terms[0]) > int.Parse(terms[1]))
                        {
                            GVReport.Columns[3].HeaderText = "Total Uploaded Data for " + GVReport.Columns[3].HeaderText + " " + YCMOU.hidCrPrChNames.Value.Split(',')[1];
                            GVReport.Columns[4].HeaderText = "Total Uploaded Data for " + GVReport.Columns[4].HeaderText + " " + YCMOU.hidCrPrChNames.Value.Split(',')[0];
                        }
                        else if (int.Parse(terms[0]) < int.Parse(terms[1]))
                        {
                            GVReport.Columns[3].HeaderText = "Total Uploaded Data for " + GVReport.Columns[3].HeaderText + " " + YCMOU.hidCrPrChNames.Value.Split(',')[0];
                            GVReport.Columns[4].HeaderText = "Total Uploaded Data for " + GVReport.Columns[4].HeaderText + " " + YCMOU.hidCrPrChNames.Value.Split(',')[1];
                        }
                    }
                    hidFacName.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text;
                    hidCrName.Value = ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text;
                    hidBrName.Value = ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text;
                    hidCrPrName.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text;
                    GVReport.DataSource = DT;
                    GVReport.DataBind();
                    Button3.Style.Add("display", "block");
                    btnPDF.Style.Add("display", "block");
                    string RegCentreName = string.Empty;
                    if (YCMOU.IsCollegeLogin.Equals(false))
                    {
                        if (YCMOU.IsRegionalCenterVisible.Equals(true))
                        {
                            if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked)
                            {
                                RegCentreName = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                                courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - for Regional Center " + RegCentreName;
                            }
                            else
                            {
                                courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - for All Regional Centers ";
                            }
                        }
                        else
                        {
                            courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text;
                        }
                    }
                    else
                    {
                        courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text;
                    }
                    HideSearchCriteria();
                }


                lblAcaYear.Text = courseOrColl + " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";


                if (((System.Data.DataTable)Session["Ddtdata"]) == null || ((System.Data.DataTable)Session["Ddtdata"]).Rows.Count == 0)
                {
                    string RegCentreName = string.Empty;
                    courseOrColl = hidCollName.Value;
                    if (courseOrColl == "")
                    {
                        if (YCMOU.IsCollegeLogin.Equals(false))
                        {
                            if (YCMOU.IsRegionalCenterVisible.Equals(true))
                            {
                                if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked)
                                {
                                    RegCentreName = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                                    courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + "- for Regional Center " + RegCentreName;
                                }
                                else
                                {
                                    courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - for All Regional Centers ";
                                }
                            }
                            else
                            {
                                courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text;
                            }

                        }

                        else
                        {
                            courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text;
                        }
                    }
                    lblAcaYear.Text = courseOrColl + " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                    lblExportedData.Text = "No records found.";
                    tblExportedDataMsg.Style.Add("display", "block");
                    Session.Remove("dtdata");
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

        #region hide search criteria when report is shown

        private void HideSearchCriteria()
        {
            //divCourse.Style.Add("display", "none");
            //divAcademicYr.Style.Add("display", "none");
            //BtnSubmit.Style.Add("display", "none");
            divYCMOU.Style.Add("display", "none");
        }

        #endregion

        #region GV Events

        protected void GVReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (YCMOU.IsRegionalCenterVisible.Equals(false))
                    e.Row.Cells[1].Visible = false;
                hidInstID.Value = GVReport.DataKeys[e.Row.RowIndex]["pk_Inst_ID"].ToString();
                ((LinkButton)e.Row.Cells[4].FindControl("lnkDifference")).Text = GVReport.DataKeys[e.Row.RowIndex]["Difference"].ToString();
                ((LinkButton)e.Row.Cells[4].FindControl("lnkDifference")).Attributes.Add("onclick", "return openNewWindow(" + hid_fk_AcademicYr_ID.Value + "," + hid_AcademicYear.Value.Split('-')[0] + "," + hid_AcademicYear.Value.Split('-')[1] + "," + hidInstID.Value + "," + hidFacID.Value + "," + hidCrID.Value + "," + hidMoLrnID.Value + "," + hidPtrnID.Value + "," + Convert.ToString(Session["BranchID"]) + "," + Convert.ToString(Session["pk_CrPr_Details_ID"]) + "," + Convert.ToString(Session["crprchids"]).Split(',')[0] + "," + Convert.ToString(Session["crprchids"]).Split(',')[1] + hidRCID.Value + ")");
                if (GVReport.DataKeys[e.Row.RowIndex]["Difference"].ToString().Equals("0"))
                {
                    ((LinkButton)e.Row.Cells[4].FindControl("lnkDifference")).Attributes.Add("onclick", "return false;");
                    ((LinkButton)e.Row.Cells[4].FindControl("lnkDifference")).Style.Add("cursor", "normal");

                }
                else
                {
                    ((LinkButton)e.Row.Cells[4].FindControl("lnkDifference")).ToolTip = "Click here to view the list of discrepant students";
                    ((LinkButton)e.Row.Cells[4].FindControl("lnkDifference")).ForeColor = System.Drawing.Color.Blue;

                }

                // e.Row.Cells[3].Text = "<a href='#' title='abc' onclick=\"return openNewWindow(" +hid_fk_AcademicYr_ID.Value + "," + hid_AcademicYear.Value.Split('-')[0] + "," + hid_AcademicYear.Value.Split('-')[1] + "," + hidInstID.Value + "," + hidFacID.Value + "," + hidCrID.Value + "," + hidMoLrnID.Value + "," + hidPtrnID.Value + "," + Convert.ToString(Session["DBranchID"]) + "," + Convert.ToString(Session["Dpk_CrPr_Details_ID"]) + "," + Convert.ToString(Session["crprchids"]).Split(',')[0] + "," + Convert.ToString(Session["crprchids"]).Split(',')[1] + ")"+"\""+"</a>";

            }
        }

        protected void GVReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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
            //    dtExport = ((DataTable)Session["DdtData"]).Copy();
            //    dtExport.Columns.Remove("pk_Inst_ID");
            //    dtExport.Columns.Remove("pk_Cr_ID");
            //    dtExport.Columns.Remove("pk_MoLrn_ID");
            //    dtExport.Columns.Remove("pk_Ptrn_ID");
            //    dtExport.Columns.Remove("pk_Brn_ID");
            //    dtExport.Columns.Remove("fk_CrPr_Details_ID");
            //    dtExport.Columns.Remove("pk_Fac_ID");

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
            //    oSB.Append("<ss:Column ss:Width=\"150\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"150\"/>");
            //    oSB.Append("<ss:Column ss:Width=\"55\"/>");

            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"4\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Faculty: " + hidFacName.Value + "</ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"4\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Course: " + hidCrName.Value + "</ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"4\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Branch: " + hidBrName.Value + "</ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"4\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Course Part: " + hidCrPrName.Value + "</ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row>");
            //    oSB.Append("<ss:Cell ss:MergeAcross=\"4\"><ss:Data ss:Type=\"String\"></ss:Data></ss:Cell>");
            //    oSB.Append("</ss:Row>");

            //    oSB.Append("<ss:Row ss:StyleID=\"1\">");
            //    for (int iCol = 0; iCol <= dtExport.Columns.Count - 1; iCol++)
            //    {
            //        if (dtExport.Columns[iCol].ColumnName == "Term2Discrepanycount")
            //        {
            //            dtExport.Columns[iCol].ColumnName = "Total Uploaded Data for " + Session["crprchnames"].ToString().Split(',')[1];
            //        }
            //        if (dtExport.Columns[iCol].ColumnName == "Term1Discrepanycount")
            //        {
            //            dtExport.Columns[iCol].ColumnName = "Total Uploaded Data for " + Session["crprchnames"].ToString().Split(',')[0];
            //        }
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
            //string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>EXCEL</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
            //  + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
            //  + "  <MarginLeft>0.6in</MarginLeft>" + "  <MarginRight>0.4in</MarginRight>"
            //  + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
            renderedBytes = ReportViewer1.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streams, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=DiscrepancyReport_" + sDateTime + ".xls");
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
            //string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
            //  + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
            //  + "  <MarginLeft>0.6in</MarginLeft>" + "  <MarginRight>0.4in</MarginRight>"
            //  + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
            renderedBytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streams, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=DiscrepancyReport_" + sDateTime + ".pdf");
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
                dtExport = ((System.Data.DataTable)Session["DdtData"]).Copy();
                ReportDataSource ReportDetailsDS1 = new ReportDataSource("dsDisc_dtDisc", dtExport);
                ReportParameter[] p = new ReportParameter[8];
                string term1, term2 = string.Empty;
                string[] terms = YCMOU.hidCrPrChIds.Value.Split(',');
                if (int.Parse(terms[0]) > int.Parse(terms[1]))
                {
                    term1 = YCMOU.hidCrPrChNames.Value.Split(',')[1];
                    term2 = YCMOU.hidCrPrChNames.Value.Split(',')[0];
                }
                else
                {
                    term1 = YCMOU.hidCrPrChNames.Value.Split(',')[0];
                    term2 = YCMOU.hidCrPrChNames.Value.Split(',')[1];
                }
                p.SetValue(new ReportParameter("Term1", term1), 0);
                p.SetValue(new ReportParameter("Term2", term2), 1);
                p.SetValue(new ReportParameter("SubHead", ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]"), 2);
                p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 3);
                p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 4);
                p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 5);
                p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + @"/Images/" + Classes.clsGetSettings.UniversityLogo
), 6);
                string RegCentre = string.Empty;
                bool isDisplayRCCodeInReport = false;
                
                if (YCMOU.IsCollegeLogin.Equals(false))
                {
                    
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
                }
                else
                {
                    RegCentre = " for " + user.Name;
                }

                p.SetValue(new ReportParameter("RegCentre", RegCentre), 7);
                ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());

                #endregion

                ReportViewer1.LocalReport.DataSources.Clear();
                if (isDisplayRCCodeInReport)
                ReportViewer1.LocalReport.ReportPath =  clsGetSettings.PhysicalSitePath + "Eligibility\\Rdlc\\CrPrTermWiseDisc.rdlc";
                else
                    ReportViewer1.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath + "Eligibility\\Rdlc\\CrPrTermWiseDiscWithOutRCcode.rdlc";


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
            dtMultNomen.Columns.Add("College");

            DataRow dr = dtMultNomen.NewRow();
            dr["College"] = lblCollege.Text;

            dtMultNomen.Rows.Add(dr);
            return dtMultNomen;
        }

        #endregion
    }

}
