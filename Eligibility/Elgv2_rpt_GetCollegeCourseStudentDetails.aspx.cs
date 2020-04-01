using System;
using Microsoft.Reporting.WebForms;
using System.Data;
using Classes;
using System.Globalization;
using System.Threading;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using StudentRegistration.Eligibility.ElgClasses;

namespace StudentRegistration.Eligibility
{
    public partial class Elgv2_rpt_GetCollegeCourseStudentDetails : System.Web.UI.Page
    {
        Hashtable oHt = null;
        DataTable oDt = null;
        clsStudent oStudent = null;
        clsUser oUser = null;
        string sUser;
        private string instIDs = "";
        private string[] IDs_List = new string[3];
        System.Data.DataTable DT = new System.Data.DataTable();

        // Validation oValidate = null;
        //clsCommon oCommon = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            {
                oUser = (clsUser)Session["User"];
                //YCMOU.isUSRpt.Value = "Yes";

                if (oUser != null && oUser.Exist)
                {
                    sUser = oUser.User_ID;
                }
                else
                {
                    Response.Redirect(Classes.clsGetSettings.SitePath.ToString() + "Logout.aspx");
                }


                hid_AcademicYear.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text;
                hid_fk_AcademicYr_ID.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue;

                if (!IsPostBack)
                {
                    Session.Remove("dtdata");
                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                    System.Data.DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                    ViewState["AcademicYear"] = dt;
                    YCMOU.IsReportUserAndDateDisplay = false;
                    YCMOU.IsInstituteDisplay = false;
                }

                ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
                hid_AcademicYear.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text;
                hid_fk_AcademicYr_ID.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue;
                YCMOU.OnProceedClick += btnNext_Click;
                YCMOU.IsInstituteDisplay = false;

                if (oUser.UserTypeCode == "2")
                {
                    instIDs = oUser.UserReferenceID;
                    hidInstID.Value = instIDs.ToString();
                    hidCollName.Value = oUser.Name;
                    YCMOU.IsInstituteDisplay = false;
                    //  YCMOU.IsCollegeLogin = true;
                    //YCMOU.IsFacultyDisplay = false;
                    //YCMOU.IsCourseDisply = false;
                    //YCMOU.IsCoursePartDisply = false;
                    //YCMOU.IsCourseTermDisply = false;
                    //YCMOU.IsBranchDisply = false;
                    lblAcaYear.Text = hidCollName.Value;
                }


            }

        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            string courseOrColl = string.Empty;
            string collName = string.Empty;
            hidFacName.Value = string.Empty;
            hidCrName.Value = string.Empty;
            hidBrName.Value = string.Empty;
            hidCrPrDetName.Value = string.Empty;
            hidCrPrChName.Value = string.Empty;
            if (oUser.UserTypeCode != "2")
            {
                hidInstID.Value = string.Empty;
                hidCollName.Value = string.Empty;

                if (((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedIndex != 0 || ((TextBox)YCMOU.FindControl("txtCenterCode")).Text != string.Empty)
                {
                    // Selected Study Center for Regional Center login
                    hidInstID.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedValue.Split('|')[0];
                    hidCollName.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedItem.Text;
                    if (((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue.Equals("0"))
                        hidCrName.Value = "All Courses";
                    else
                    {
                        hidCrName.Value = ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text;
                        hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
                        getFacCrMoLrnPtrnID();
                        hidBrnID.Value = ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedValue;
                        hidCrPrDetailsID.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedValue;
                        hidCrPrChID.Value = ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedValue;
                    }
                }
                else
                {


                    hidCollName.Value = "All Colleges";
                    hidCrName.Value = ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text;
                    hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
                    getFacCrMoLrnPtrnID();
                    hidBrnID.Value = ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedValue;
                    hidCrPrDetailsID.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedValue;
                    hidCrPrChID.Value = ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedValue;
                }
               
           
            }
            else
            {
                hidCollName.Value = oUser.Name;
                if (((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue.Equals("0"))
                {
                    hidCrName.Value = "All Courses";
                }
                else
                {
                    hidCrName.Value = ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text;
                    hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
                    getFacCrMoLrnPtrnID();
                    hidBrnID.Value = ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedValue;
                    hidCrPrDetailsID.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedValue;
                    hidCrPrChID.Value = ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedValue;
                }
            }
           lblAcaYear.Text = courseOrColl + " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";

            if (BindReport())
            {
                GenerateReport("EXCEL", ".xls");
            }

            //string courseOrColl = string.Empty;
            //string collName = string.Empty;
            //if (oUser.UserTypeCode != "2")
            //{
            //    hidInstID.Value = string.Empty;
            //    hidCollName.Value = string.Empty;
            //}
            //hidFacName.Value = string.Empty;
            //hidCrName.Value = string.Empty;
            //hidBrName.Value = string.Empty;
            //hidCrPrDetName.Value = string.Empty;
            //hidCrPrChName.Value = string.Empty;
            // try
            //{
            //    if (oUser.UserTypeCode != "2" || YCMOU.IsRegionalCenterLogin == "True")
            //    //***********************************************
            //    {
            //        //setting hidden vars from dropdown selections of oUser control 

            //        if (((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedIndex != 0 || ((TextBox)YCMOU.FindControl("txtCenterCode")).Text != string.Empty)
            //        {
            //            hidInstID.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedValue.Split('|')[0];
            //            hidCollName.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedItem.Text;
            //            if (!hidInstID.Value.Equals(string.Empty) && !hidInstID.Value.Equals("0"))
            //            {
            //                DT = clsCollegeAdmissionReports.FetchSelectedCollegeOuterReport(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
            //                Session["dtDataStu"] = DT;
            //                if (DT.Rows.Count > 0)
            //                {
            //                    GVOuterCollege.DataSource = DT;
            //                    GVOuterCollege.DataBind();
            //                    GVOuterCollege.Style.Add("display", "block");
            //                    divDGStat.Style.Add("display", "none");
            //                    dgCollege.Style.Add("display", "block");
            //                    tblExportToExcel.Style.Add("display", "block");
            //                }
            //            }
            //            string rc_name = string.Empty;
            //            if (YCMOU.IsRegionalCenterVisible)
            //            {
            //                if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
            //                {
            //                    rc_name = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text + " - ";
            //                }
            //                //***********************************************
            //                else if (YCMOU.IsRegionalCenterLogin == "True")
            //                {
            //                    rc_name = oUser.Name + " - ";
            //                }
            //                //***********************************************
            //                else
            //                {
            //                    rc_name = "All Regional Centers";
            //                }
            //            }
            //            courseOrColl = rc_name + hidCollName.Value;

            //        }

            //    //for all colleges one course
            //        else
            //        {
            //            hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
            //            getFacCrMoLrnPtrnID();
            //            hidCrPrDetailsID.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedValue;
            //            hidCrPrChID.Value = ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedValue;

            //            if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked)
            //            {
            //                DT = clsCollegeAdmissionReports.FetchAllCollegesOuterReport(hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedValue);
            //            }
            //            //***********************************************************************************************************
            //            else if (YCMOU.IsRegionalCenterLogin == "True")
            //            {
            //                DT = clsCollegeAdmissionReports.FetchAllCollegesOuterReport(hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), oUser.UserReferenceID);
            //            }
            //            //***********************************************************************************************************
            //            else
            //            {
            //                DT = clsCollegeAdmissionReports.FetchAllCollegesOuterReport(hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), null);
            //            }
            //            Session["dtData"] = DT;
            //            if (DT.Rows.Count > 0)
            //            {
            //                GVStat.DataSource = DT;
            //                GVStat.DataBind();
            //                GVStat.Style.Add("display", "block");
            //                divDGStat.Style.Add("display", "block");
            //                dgCollege.Style.Add("display", "none");
            //                tblExportToExcel.Style.Add("display", "block");
            //                getcount();
            //                DivCollegeUploadInfo.Style.Add("display", "block");
            //                hidFacName.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text;
            //                hidCrName.Value = ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text;
            //                hidBrName.Value = ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text;
            //                hidCrPrName.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text;
            //                hidCrPrChName.Value = ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
            //            }
            //            string rc_name = string.Empty;
            //            if (YCMOU.IsRegionalCenterVisible)
            //            {
            //                if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
            //                {
            //                    rc_name = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
            //                    courseOrColl = rc_name + " - " + ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
            //                }
            //                //*******************************************************************
            //                else if (YCMOU.IsRegionalCenterLogin == "True")
            //                {
            //                    rc_name = oUser.Name;
            //                    courseOrColl = rc_name + " - " + ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
            //                }
            //                //******************************************************************
            //                else
            //                {
            //                    rc_name = "All Regional Centers";
            //                    courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text + " - " + rc_name;

            //                }
            //            }
            //            else
            //            {
            //                courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
            //            }
            //        }
            //    }

            //    //handling college login
            //    else if (oUser.UserTypeCode == "2")
            //    {
            //        DT = clsCollegeAdmissionReports.FetchSelectedCollegeOuterReport(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
            //        Session["dtData"] = DT;
            //        if (DT.Rows.Count > 0)
            //        {
            //            GVOuterCollege.DataSource = DT;
            //            GVOuterCollege.DataBind();
            //            GVOuterCollege.Style.Add("display", "block");
            //            divDGStat.Style.Add("display", "none");
            //            dgCollege.Style.Add("display", "block");

            //            courseOrColl = hidCollName.Value;

            //            tblExportToExcel.Style.Add("display", "block");
            //        }
            //    }

            //    if (GVStat.Rows.Count > 0 || GVOuterCollege.Rows.Count > 0)
            //    {
            //        HideSearchCriteria();
            //        lblAcaYear.Text = courseOrColl + " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
            //    }


            //    if (((System.Data.DataTable)Session["dtdata"]) == null || ((System.Data.DataTable)Session["dtdata"]).Rows.Count == 0)
            //    {
            //        tblExportedDataMsg.Style.Add("display", "block");
            //        //courseOrColl = hidCollName.Value;
            //        //if (courseOrColl == "")
            //        //{
            //        //    courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
            //        //}
            //        lblAcaYear.Text = courseOrColl + " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
            //        lblExportedData.Text = "No records found.";
            //        Session.Remove("dtdata");

            //    }

            //    if (dtCollege != null)
            //    {
            //        dtCollege = null;
            //    }
            //}
            // catch (Exception Ex4)
            // {
            //     throw new Exception(Ex4.Message);
            // }

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
        protected void ExptToExl_Click(object sender, EventArgs e)
        {
            if (BindReport())
            {
                GenerateReport("EXCEL", ".xls");
            }
        }
        protected void ExptToPDF_Click(object sender, EventArgs e)
        {
            if (BindReport())
            {
                GenerateReport("PDF", ".pdf");
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
            Response.AddHeader("content-disposition", "attachment; filename=CutOffDateReport_" + sDateTime + extension);
            Response.BinaryWrite(bytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
        private bool BindReport()
        {
            oHt = new Hashtable();
            oHt = CreateHashTable();
            oStudent = new clsStudent();
            using (oDt = oStudent.GetCollegeCourseStudentDetails(oHt))
            {
                if (oDt != null && oDt.Rows.Count > 0)
                {
                    rptViewer.LocalReport.DataSources.Clear();
                    rptViewer.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath + "Eligibility\\Rdlc\\rptCollegeCourseStudentDetailsMUHS.rdlc";
                    ReportDataSource oRds = new ReportDataSource("DSOAReports", oDt);
                    ReportParameter[] param = new ReportParameter[7];
                    param[0] = new ReportParameter("UniName", clsGetSettings.UniversityName.ToString(), true);
                    param[1] = new ReportParameter("UniLogo", clsGetSettings.SitePath + "Images/" + clsGetSettings.Logo, true);
                    param[2] = new ReportParameter("CollegeName", hidCollName.Value.Trim(), true);
                    param[3] = new ReportParameter("CourseName", hidCrName.Value.Trim(), true);
                    param[4] = new ReportParameter("userName", oUser.Name, true);
                    param[5] = new ReportParameter("Address", clsGetSettings.Address, true);
                    string sLoginType = "C";
                    if (oUser.UserTypeCode != "2")
                        sLoginType = "A";

                    param[6] = new ReportParameter("LoginType", sLoginType, true);

                    //string sCriteria = "Branch Change details for " + oUser.Name; ;
                    // param[6] = new ReportParameter("ReportCriteria", sCriteria, true);
                    ReportDataSource MultNomDS = new ReportDataSource("dsMultiNom", MultinomenClature());
                    rptViewer.LocalReport.EnableExternalImages = true;
                    rptViewer.LocalReport.SetParameters(param);
                    rptViewer.LocalReport.DataSources.Add(oRds);
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

        private Hashtable CreateHashTable()
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
            oHt["CrPrChID"] = hidCrPrChID.Value.Trim();
            oHt["AcademicYearID"] = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue;
            oHt["User"] = oUser.User_ID;
            return oHt;
        }

    }
}










