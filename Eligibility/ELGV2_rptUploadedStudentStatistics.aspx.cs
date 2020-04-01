using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
//using RKLib.ExportData;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptUploadedStudentStatistics : System.Web.UI.Page
    {

        #region variable declaration

        clsCommon Common = new clsCommon();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        clsUser user;
        string sUser;
        System.Data.DataTable DTdata;
        DataSet DS1 = new DataSet("myDS");
        int cntIntakeCapacity = 0;
        int cntStud = 0;
        int cntInvoiceGenerated = 0;
        int cntInvoiceProcessed = 0;
        int cntInvoicenotProcessed = 0;
        int cntTotalEligibityProcessed = 0;
        int cntEligible = 0;
        int cntnoteligible = 0;
        int cntprovisinal = 0;
        int cntpending = 0;
        int cnteligibitynotprocessed = 0;

        System.Data.DataTable DT = new System.Data.DataTable();
        System.Data.DataTable DTSort = new System.Data.DataTable();
        string grpRow1 = "-";
        string grpRow2 = "";
        int index = 0;
        int cntCol = 0;
        int flag = 0;

        string fkCountryID = "";
        private string instIDs = "";
        System.Data.DataTable oDT;
        System.Data.DataTable dtCollege;

        CourseRepository crRepository = new CourseRepository();
        InstituteRepository oInstituteRepository = new InstituteRepository();
        clsEligibilityDBAccess oclsEligibilityDBAccess;
        private string[] IDs_List = new string[3];

        #endregion



        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["User"];
            YCMOU.isUSRpt.Value = "Yes";

            if (user != null && user.Exist)
            {
                sUser = user.User_ID;
            }
            else
            {
                Response.Redirect(Classes.clsGetSettings.SitePath.ToString() + "Logout.aspx");
            }


            //else
            //{
            //    fldAllInst.Style.Add("display", "block");
            //    divCourse.Style.Add("display", "block");
            //}

            hid_AcademicYear.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue;

            if (!IsPostBack)
            {
                Session.Remove("dtdata");
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                hidCountryId.Value = fkCountryID;
                //fnFirstFill();
                // FillCollegeList();
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                System.Data.DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                ViewState["AcademicYear"] = dt;
                YCMOU.IsReportUserAndDateDisplay = false;
                YCMOU.IsInstituteDisplay = false;

                //Common.fillDropDown(ddlAcademicYr, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                //ddlAcademicYr.SelectedIndex = 0;
                //DisplyFromSession();
            }

            ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

            hid_AcademicYear.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue;

            //if (Collcode.Text != string.Empty || ddlCollegeName.SelectedValue != "0")
            //{
            //    divCollege.Style.Add("display", "block");
            //    divCourse.Style.Add("display", "none");
            //    btnSubmitSelectedCollege.Style.Add("display", "block");
            //    BtnSubmit.Style.Add("display", "none");

            //}
            //else
            //{
            //    if (user.UserTypeCode != "2")
            //    {
            //        divCourse.Style.Add("display", "block");
            //        btnSubmitSelectedCollege.Style.Add("display", "none");
            //        BtnSubmit.Style.Add("display", "block");
            //    }
            //    else
            //    {
            //        divCourse.Style.Add("display", "none");
            //        btnSubmitSelectedCollege.Style.Add("display", "block");
            //        BtnSubmit.Style.Add("display", "none");
            //    }
            //    divCollege.Style.Add("display", "none");

            //}
            tblExportedDataMsg.Style.Add("display", "none");

            //retaining tooltip on postback
            //foreach (ListItem li in this.ddlCollegeName.Items)
            //{
            //    li.Attributes.Add("title", li.Text);
            //}
            //ddlCollegeName.Attributes.Add("onmouseover", "this.title=this.options[this.selectedIndex].title");
            YCMOU.OnProceedClick += btnNext_Click;
            YCMOU.IsInstituteDisplay = false;

            if (user.UserTypeCode == "2")
            {
                instIDs = user.UserReferenceID;
                hidInstID.Value = instIDs.ToString();
                //divAcademicYr.Style.Add("display", "block");
                //rdAllColleges.Checked = false;
                //rdSelectedColleges.Checked = true;
                hidCollName.Value = user.Name;
                //lblAcaYear.Text = hidCollName.Value;
                ////  lblPageHead.Text = lblAcaYear.Text;
                YCMOU.IsCollegeLogin = true;
                YCMOU.IsFacultyDisplay = false;
                YCMOU.IsCourseDisply = false;
                YCMOU.IsCoursePartDisply = false;
                YCMOU.IsCourseTermDisply = false;
                YCMOU.IsBranchDisply = false;
                lblAcaYear.Text = hidCollName.Value;
            }

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
                    hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)CnDet.FindControl("hid_fk_AcademicYr_ID")).Value;
                    hidFacID.Value = ((HtmlInputHidden)CnDet.FindControl("hidFacID")).Value;
                    hidCrID.Value = ((HtmlInputHidden)CnDet.FindControl("hidCrID")).Value;
                    hidMoLrnID.Value = ((HtmlInputHidden)CnDet.FindControl("hidMoLrnID")).Value;
                    hidPtrnID.Value = ((HtmlInputHidden)CnDet.FindControl("hidPtrnID")).Value;
                    hidBrnID.Value = ((HtmlInputHidden)CnDet.FindControl("hidBrnID")).Value;
                    hidCrPrDetailsID.Value = ((HtmlInputHidden)CnDet.FindControl("hidCrPrDetailsID")).Value;
                    hidCrPrChID.Value = ((HtmlInputHidden)CnDet.FindControl("hidCrPrChID")).Value;
                    hidRCName.Value = ((HtmlInputHidden)CnDet.FindControl("hidRCName")).Value;
                    hidRCID.Value = ((HtmlInputHidden)CnDet.FindControl("hidRCID")).Value;

                    if (Request.QueryString["InstIDS"] == "")
                    {
                        //fetch coursewise report
                        string courseOrColl = string.Empty;
                        if (hidRCName.Value.Equals(string.Empty))
                        {
                            DT = clsCollegeAdmissionReports.FetchAllCollegesOuterReport(Request.QueryString["AcYrId"].ToString(), Request.QueryString["FacId"].ToString(), Request.QueryString["CrId"].ToString(), Request.QueryString["MoLrnId"].ToString(), Request.QueryString["PtrnId"].ToString(), Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), null);
                        }
                        else
                        {
                            DT = clsCollegeAdmissionReports.FetchAllCollegesOuterReport(Request.QueryString["AcYrId"].ToString(), Request.QueryString["FacId"].ToString(), Request.QueryString["CrId"].ToString(), Request.QueryString["MoLrnId"].ToString(), Request.QueryString["PtrnId"].ToString(), Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), hidRCID.Value);
                        }
                        Session["dtData"] = DT;
                        if (DT.Rows.Count > 0)
                        {
                            GVStat.DataSource = DT;
                            GVStat.DataBind();
                            GVStat.Style.Add("display", "block");
                            divDGStat.Style.Add("display", "block");
                            dgCollege.Style.Add("display", "none");
                            courseOrColl = " for " + hidRCName.Value + " - " + hidFacName.Value + " - " + hidCrName.Value + " - " + hidBrName.Value + " - " + hidCrPrDetName.Value + " - " + hidCrPrChName.Value;
                            lblAcaYear.Text = courseOrColl + " [Academic Year " + Request.QueryString["AcYrName"].ToString() + "]";
                            tblExportToExcel.Style.Add("display", "block");
                            getcount();
                            DivCollegeUploadInfo.Style.Add("display", "block");
                        }

                        if (DT != null)
                        {
                            DT = null;
                        }

                    }

                }
            }
            #endregion

        }

        #endregion

        //#region Fill Faculty

        //private void fnFirstFill()
        //{
        //    hidLevelFlag.Value = "7";
        //    FetchUniversityWiseFacultyList(ddlFacDesc);
        //    //FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);        

        //}

        //#endregion

        //#region Fetch University Wise Faculty List

        //public void FetchUniversityWiseFacultyList(DropDownList ddlFacDesc)
        //{

        //    System.Data.DataTable listFaculty = crRepository.LaunchedUniversityWiseFacultyList(Convert.ToInt64(hidUniID.Value.ToString()));
        //    try
        //    {
        //        if (listFaculty != null)
        //        {
        //            ddlFacDesc.DataSource = listFaculty;
        //            ddlFacDesc.DataTextField = "text";
        //            ddlFacDesc.DataValueField = "value";
        //            ddlFacDesc.DataBind();
        //            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--- Select ---", "-1");
        //            ddlFacDesc.Items.Insert(0, li);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //#endregion

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        //#region Fill College List

        //public void FillCollegeList()
        //{
        //    dtCollege = new System.Data.DataTable();
        //    oclsEligibilityDBAccess = new clsEligibilityDBAccess();
        //    int uniID = Convert.ToInt32(clsGetSettings.UniversityID);
        //    try
        //    {
        //        dtCollege = oclsEligibilityDBAccess.ListColleges(uniID);

        //        if (dtCollege.Rows.Count > 0)
        //        {
        //            foreach (DataRow drCollege in dtCollege.Rows)
        //            {
        //                string itemValue = drCollege["pk_Inst_ID"].ToString() + "|" + drCollege["Inst_Code"].ToString();
        //                ddlCollegeName.Items.Add(new ListItem(drCollege["Inst_Name"].ToString() + "," + drCollege["Inst_City"].ToString(), itemValue));

        //            }
        //            foreach (ListItem li in this.ddlCollegeName.Items)
        //            {

        //                li.Attributes.Add("title", li.Text);

        //            }
        //            ddlCollegeName.Items.Insert(0, new ListItem("--- Select ---", "0"));

        //        }

        //        ddlCollegeName.Attributes.Add("onmouseover", "this.title=this.options[this.selectedIndex].title");
        //    }
        //    catch (Exception)
        //    {
        //        dtCollege = null;
        //    }
        //}

        //#endregion

        #region DivCollegeUploadInformation Count

        private void getcount()
        {
            DataSet Ds = new DataSet();
            try
            {
                if (YCMOU.IsRegionalCenterVisible)
                {
                    if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked)
                    {
                        Ds = clsCollegeAdmissionReports.InstnameNotUploadedData(hidUniID.Value, hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedValue);
                    }
                    else if (YCMOU.IsRegionalCenterLogin == "True")
                    {
                        Ds = clsCollegeAdmissionReports.InstnameNotUploadedData(hidUniID.Value, hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), user.UserReferenceID);
                    }
                    else
                    {
                        Ds = clsCollegeAdmissionReports.InstnameNotUploadedData(hidUniID.Value, hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), null);
                    }
                }
                else
                {
                    if (Page.PreviousPage != null)
                    {
                        if (Request.QueryString["Navigate"] == "back")
                        {
                            Ds = clsCollegeAdmissionReports.InstnameNotUploadedData(hidUniID.Value, hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), hidRCID.Value);
                        }
                    }
                    else
                        Ds = clsCollegeAdmissionReports.InstnameNotUploadedData(hidUniID.Value, hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), null);

                }
                //**************************************************************************************************
                //lblNoOfCollege.Text = Ds.Tables[1].Rows[0]["No Uploaded"].ToString();
                //LinkcollegeNotUploaded.Text = Ds.Tables[0].Rows[0]["No Not Uploaded"].ToString();
                //if (Ds.Tables[0].Rows[0]["No Not Uploaded"].ToString().Equals("0"))
                //{
                //    lblClickCount.Style.Add("display", "none");
                //    LinkcollegeNotUploaded.Attributes.Add("onclick", "return false;");
                //    LinkcollegeNotUploaded.Style.Add("cursor", "normal");
                //}
                //lblTotalNoOfStudent.Text = Ds.Tables[3].Rows[0]["Total uploaded data"].ToString();
                //**************************************************************************************************
                lblNoOfCollege.Text = Ds.Tables[0].Rows[0]["No Uploaded"].ToString();

                //**************************************************************************************************
                //DataView odv =  Ds.Tables[1].DefaultView;
                //odv.RowFilter = "NotUploaded_InstID = 0";
                //LinkcollegeNotUploaded.Text = odv.Count.ToString();
                //if (LinkcollegeNotUploaded.Text.Equals("0"))
                //{
                //    lblClickCount.Style.Add("display", "none");
                //    LinkcollegeNotUploaded.Attributes.Add("onclick", "return false;");
                //    LinkcollegeNotUploaded.Style.Add("cursor", "normal");
                //}
                //**************************************************************************************************

                lblTotalNoOfStudent.Text = Ds.Tables[1].Rows[0]["Total uploaded data"].ToString();

            }
            catch (Exception e)
            {
                Ds = null;
            }
        }

        #endregion

        #region LinkcollegeNotUploaded_Click

        protected void LinkcollegeNotUploaded_Click(object sender, EventArgs e)
        {
            if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
            {
                Server.Transfer("ELGV2_rptUploadedStudentStatistics__1.aspx?AcademicYr=" + hid_fk_AcademicYr_ID.Value + "-" + hid_AcademicYear.Value + "&InstIds=" + hidInstID.Value + "&FacId=" + hidFacID.Value + "&CrId=" + hidCrID.Value + "&MoLrnId=" + hidMoLrnID.Value + "&PtrnId=" + hidPtrnID.Value + "&BrnId=" + Convert.ToString(Session["BranchID"]) + "&CrPrDetailsId=" + Convert.ToString(Session["pk_CrPr_Details_ID"]) + "&CrPrChId=" + Convert.ToString(Session["pk_CrPrCh_ID"]) +
                    "&RCenter=" + ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text + "&RCentreID=" + ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedValue);
            }
            //***************************************************************************************
            else if (YCMOU.IsRegionalCenterLogin == "True")
            {
                    hidInstID.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedValue.Split('|')[0];
                    //hidCollName.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedItem.Text;
                    Server.Transfer("ELGV2_rptUploadedStudentStatistics__1.aspx?AcademicYr=" + hid_fk_AcademicYr_ID.Value + "-" + hid_AcademicYear.Value + "&InstIds=" + hidInstID.Value + "&FacId=" + hidFacID.Value + "&CrId=" + hidCrID.Value + "&MoLrnId=" + hidMoLrnID.Value + "&PtrnId=" + hidPtrnID.Value + "&BrnId=" + Convert.ToString(Session["BranchID"]) + "&CrPrDetailsId=" + Convert.ToString(Session["pk_CrPr_Details_ID"]) + "&CrPrChId=" + Convert.ToString(Session["pk_CrPrCh_ID"]) +
                        "&RCenter=" + user.Name + "&RCentreID=" + user.UserReferenceID);
            }
            //***************************************************************************************
            else
            {
                Server.Transfer("ELGV2_rptUploadedStudentStatistics__1.aspx?AcademicYr=" + hid_fk_AcademicYr_ID.Value + "-" + hid_AcademicYear.Value + "&InstIds=" + hidInstID.Value + "&FacId=" + hidFacID.Value + "&CrId=" + hidCrID.Value + "&MoLrnId=" + hidMoLrnID.Value + "&PtrnId=" + hidPtrnID.Value + "&BrnId=" + Convert.ToString(Session["BranchID"]) + "&CrPrDetailsId=" + Convert.ToString(Session["pk_CrPr_Details_ID"]) + "&CrPrChId=" + Convert.ToString(Session["pk_CrPrCh_ID"]));

            }
        }

        #endregion

        #region GridView related functions

        protected void GVStat_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int cellIndex = 4;
            int cellindexd = 4;
            //showing subtotals
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (YCMOU.IsRegionalCenterVisible.Equals(false))
                    e.Row.Cells[1].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (YCMOU.IsRegionalCenterVisible.Equals(false))
                    e.Row.Cells[1].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //if (YCMOU.IsRegionalCenterVisible.Equals(true))
                //{
                //    if (((RadioButton)YCMOU.FindControl("ChkAllRegionalCenter")).Checked)
                //    {
                //        //if (((RadioButton)YCMOU.FindControl("ChkAllStudyCenter")).Checked)
                //        //{
                //        cellindexd = 6;
                //      //  }

                //    }
                //}

                
                int sumTI = 0; int sumDO = 0; int sumEP = 0;
                int sumENP = 0; int sumDS = 0; int sumPD = 0;
                int sumLastColumn = 0;

                for (int k = 0; k < e.Row.Cells.Count; k++)
                {
                    e.Row.Cells[k].Font.Bold = true;
                }

                for (int i = 0; i < ((GridView)sender).Rows.Count; i++)
                {
                    sumTI += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex].Text);
                    sumDO += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex+1].Text);
                    sumEP += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex+2].Text);
                    sumENP += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex+3].Text);
                    sumDS += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex+4].Text);
                    sumPD += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex+5].Text);
                    sumLastColumn += Convert.ToInt32(((GridView)sender).Rows[i].Cells[cellIndex + 6].Text);

                }

                e.Row.Cells[cellIndex-3].Text = sumTI.ToString();
                e.Row.Cells[cellIndex-2].Text = sumDO.ToString();
                e.Row.Cells[cellIndex - 1].Text = sumEP.ToString();
                e.Row.Cells[cellIndex].Text = sumENP.ToString();
                e.Row.Cells[cellIndex+1].Text = sumDS.ToString();
                e.Row.Cells[cellIndex+2].Text = sumPD.ToString();
                e.Row.Cells[cellIndex + 3].Text = sumLastColumn.ToString();
                e.Row.Cells[cellindexd - 4].Text = "Total:";
                if (this.YCMOU.IsRegionalCenterVisible.Equals(false))
                {
                    e.Row.Cells[cellIndex - 4].ColumnSpan = 3;
                }
                else
                {
                    e.Row.Cells[cellIndex - 4].ColumnSpan = 4;
                }

                e.Row.Cells[cellindexd - 4].HorizontalAlign = HorizontalAlign.Right;
               // e.Row.Cells[cellIndex+3].Style.Add("display", "none");
                e.Row.Cells[cellindexd + 4].Style.Add("display", "none");
                e.Row.Cells[cellindexd + 5].Style.Add("display", "none");
                e.Row.Cells[cellindexd + 6].Style.Add("display", "none");
                e.Row.Cells[cellindexd + 7].Style.Add("display", "none");
            }
        }


        protected void GVStat_Sorted(object sender, EventArgs e)
        {

        }

        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        private void SortGridView(string sortExpression, string direction)
        {

            grpRow1 = "-";
            index = 0;
            cntIntakeCapacity = 0;
            cntStud = 0;
            cntInvoiceGenerated = 0;
            cntInvoiceProcessed = 0;
            cntInvoicenotProcessed = 0;
            cntEligible = 0;
            cntnoteligible = 0;
            cntprovisinal = 0;
            cntpending = 0;
            cnteligibitynotprocessed = 0;
            cntTotalEligibityProcessed = 0;
            grpRow1 = "-";
            grpRow2 = "";
            index = 0;
            cntCol = 0;

            DataView dv = new DataView(DT);

            dv.Sort = sortExpression + direction;
            GVStat.DataSource = dv;
            GVStat.DataBind();
        }

        protected void GVStat_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, DESCENDING);
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, ASCENDING);
            }


            /* DTSort = new DataTable();
            DTSort.Reset();

            DTSort = DT;
            DataView DV = new DataView(DTSort);
            GVStat.DataSource = DV;


            if (ViewState["SortExpression"] == null)
                ViewState["SortExpression"] = e.SortExpression.ToString();
             
            if (ViewState["SortExpression"].ToString() == e.SortExpression.ToString())
            {
              
                DV.Sort = e.SortExpression.ToString();  //+ " Desc";
                ViewState["SortExpression"] = e.SortExpression.ToString(); //+ " Desc";
            }
            else
            {
               // e.SortDirection = "Descending";
                DV.Sort = e.SortExpression.ToString();
                ViewState["SortExpression"] = e.SortExpression.ToString();
            }              
           GVStat.DataBind();*/
        }

        protected void GVOuterCollege_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //showing subtotals
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int sumTI = 0; int sumDO = 0; int sumEP = 0;
                int sumENP = 0; int sumDS = 0; int sumPD = 0; int sumPDC = 0;
                for (int k = 0; k < e.Row.Cells.Count; k++)
                {
                    e.Row.Cells[k].Font.Bold = true;
                }

                for (int i = 0; i < ((GridView)sender).Rows.Count; i++)
                {

                    sumTI += Convert.ToInt32(((GridView)sender).Rows[i].Cells[2].Text);
                    sumDO += Convert.ToInt32(((GridView)sender).Rows[i].Cells[3].Text);
                    sumEP += Convert.ToInt32(((GridView)sender).Rows[i].Cells[4].Text);
                    sumENP += Convert.ToInt32(((GridView)sender).Rows[i].Cells[5].Text);
                    sumDS += Convert.ToInt32(((GridView)sender).Rows[i].Cells[6].Text);
                    sumPD += Convert.ToInt32(((GridView)sender).Rows[i].Cells[7].Text);
                    sumPDC += Convert.ToInt32(((GridView)sender).Rows[i].Cells[8].Text);
                }

                e.Row.Cells[1].Text = sumTI.ToString();
                e.Row.Cells[2].Text = sumDO.ToString();
                e.Row.Cells[3].Text = sumEP.ToString();
                e.Row.Cells[4].Text = sumENP.ToString();
                e.Row.Cells[5].Text = sumDS.ToString();
                e.Row.Cells[6].Text = sumPD.ToString();
                e.Row.Cells[7].Text = sumPDC.ToString();
                e.Row.Cells[0].Text = "Total:";
                e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        protected void GVInner_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GVStat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            HideSearchCriteria();
            try
            {
                //if (Session["dtInnerData"] != null) { Session.Remove("dtInnerData"); }
                GridView allCollegesOuter = (GridView)sender;
                GridViewRow row = null;
                int index = Convert.ToInt32(e.CommandArgument);
                for (int i = 0; i < GVStat.Rows.Count; i++)
                {
                    if (GVStat.DataKeys[i]["pk_Inst_ID"].ToString().Equals(index.ToString()))
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
                        ((HtmlGenericControl)row.Cells[0].FindControl("divCourseInnerHide")).Style.Add("display", "none");
                        ((HtmlGenericControl)row.Cells[0].FindControl("divHideMeCourse")).Style.Add("display", "none");

                    }
                    else if (innerGV.Style["display"].Equals("none"))
                    {
                        foreach (TableCell tc in row.Cells)
                        {
                            tc.BackColor = System.Drawing.Color.PeachPuff;
                        }
                        DT = clsCollegeAdmissionReports.FetchAllCollegesInnerReport(hid_fk_AcademicYr_ID.Value, allCollegesOuter.DataKeys[row.RowIndex]["pk_Inst_ID"].ToString(), hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]));
                        //Session["dtInnerData"] = DT;
                        if (DT.Rows.Count > 0)
                        {
                            innerGV.DataSource = DT;
                            innerGV.DataBind();
                            innerGV.Style.Add("display", "inline");
                            ((System.Web.UI.WebControls.Image)row.Cells[0].FindControl("imgdiv")).ImageUrl = "../Images/minus.gif";

                            GVStat.Style.Add("display", "block");
                            divDGStat.Style.Add("display", "block");
                            ((HtmlGenericControl)row.Cells[0].FindControl("divCourseInnerHide")).Style.Add("display", "block");
                            ((HtmlGenericControl)row.Cells[0].FindControl("divHideMeCourse")).Style.Add("display", "block");

                        }
                    }

                }
            }

            catch (Exception Ex1)
            {
                throw new Exception(Ex1.Message);
            }
        }

        protected void GVOuterCollege_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            HideSearchCriteria();
            try
            {
                Session.Remove("dtInnerData");
                GridView selCollegeOuter = (GridView)sender;
                GridViewRow row = null;
                string index = e.CommandArgument.ToString();
                for (int i = 0; i < GVOuterCollege.Rows.Count; i++)
                {
                    if (GVOuterCollege.DataKeys[i]["Course Name"].ToString().Equals(index))
                    {
                        row = GVOuterCollege.Rows[i];
                        break;
                    }
                }
                GridView innerGV = (GridView)row.FindControl("GVInnerCollege");
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
                        ((HtmlGenericControl)row.Cells[0].FindControl("divCourseInnerHide")).Style.Add("display", "none");
                        ((HtmlGenericControl)row.Cells[0].FindControl("divHideMe")).Style.Add("display", "none");


                    }
                    else if (innerGV.Style["display"].Equals("none"))
                    {

                        foreach (TableCell tc in row.Cells)
                        {
                            tc.BackColor = System.Drawing.Color.PeachPuff;
                        }
                        DT = clsCollegeAdmissionReports.FetchSelectedCollegeInnerReport(hid_fk_AcademicYr_ID.Value, hidInstID.Value, selCollegeOuter.DataKeys[row.RowIndex]["pk_Fac_ID"].ToString(), selCollegeOuter.DataKeys[row.RowIndex]["pk_Cr_ID"].ToString(), selCollegeOuter.DataKeys[row.RowIndex]["pk_MoLrn_ID"].ToString(), selCollegeOuter.DataKeys[row.RowIndex]["pk_Ptrn_ID"].ToString(), selCollegeOuter.DataKeys[row.RowIndex]["pk_Brn_ID"].ToString(), selCollegeOuter.DataKeys[row.RowIndex]["fk_CrPr_Details_ID"].ToString(), selCollegeOuter.DataKeys[row.RowIndex]["pk_CrPrCh_ID"].ToString());
                        //Session["dtInnerData"] = DT;
                        if (DT.Rows.Count > 0)
                        {
                            innerGV.DataSource = DT;
                            innerGV.DataBind();
                            innerGV.Style.Add("display", "inline");
                            ((System.Web.UI.WebControls.Image)row.Cells[0].FindControl("imgdiv")).ImageUrl = "../Images/minus.gif";

                            //row.Cells[3].Attributes.Add("style", "display:none");
                            GVOuterCollege.Style.Add("display", "block");
                            dgCollege.Style.Add("display", "block");
                            ((HtmlGenericControl)row.Cells[0].FindControl("divCourseInnerHide")).Style.Add("display", "block");
                            ((HtmlGenericControl)row.Cells[0].FindControl("divHideMe")).Style.Add("display", "block");

                        }
                    }

                }
            }
            catch (Exception Ex2)
            {
                throw new Exception(Ex2.Message);
            }
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
            //MemorizeInSession();
            Session.Remove("dtdata");

            try
            {
                //for one college all courses
                //***********************************************
                //if (user.UserTypeCode != "2")
                if (user.UserTypeCode != "2" || YCMOU.IsRegionalCenterLogin == "True")
                //***********************************************
                {
                    //setting hidden vars from dropdown selections of user control 

                    if (((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedIndex != 0 || ((TextBox)YCMOU.FindControl("txtCenterCode")).Text != string.Empty)
                    {
                        hidInstID.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedValue.Split('|')[0];
                        hidCollName.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedItem.Text;
                        if (!hidInstID.Value.Equals(string.Empty) && !hidInstID.Value.Equals("0"))
                        {
                            DT = clsCollegeAdmissionReports.FetchSelectedCollegeOuterReport(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
                            Session["dtData"] = DT;
                            if (DT.Rows.Count > 0)
                            {
                                GVOuterCollege.DataSource = DT;
                                GVOuterCollege.DataBind();
                                GVOuterCollege.Style.Add("display", "block");
                                divDGStat.Style.Add("display", "none");
                                dgCollege.Style.Add("display", "block");
                                tblExportToExcel.Style.Add("display", "block");
                            }
                        }
                        string rc_name = string.Empty;
                        if (YCMOU.IsRegionalCenterVisible)
                        {
                            if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
                            {
                                rc_name = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text + " - ";
                            }
                            //***********************************************
                            else if (YCMOU.IsRegionalCenterLogin == "True")
                            {
                                rc_name = user.Name + " - ";
                            }
                            //***********************************************
                            else
                            {
                                rc_name = "All Regional Centers";
                            }
                        }
                        courseOrColl = rc_name + hidCollName.Value;

                    }

                //for all colleges one course
                    else
                    {
                        hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
                        getFacCrMoLrnPtrnID();
                        hidCrPrDetailsID.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedValue;
                        hidCrPrChID.Value = ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedValue;
                        
                        if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked)
                        {
                            DT = clsCollegeAdmissionReports.FetchAllCollegesOuterReport(hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedValue);
                        }
                        //***********************************************************************************************************
                        else if (YCMOU.IsRegionalCenterLogin == "True")
                        {
                            DT = clsCollegeAdmissionReports.FetchAllCollegesOuterReport(hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), user.UserReferenceID);
                        }
                        //***********************************************************************************************************
                        else
                        {
                            DT = clsCollegeAdmissionReports.FetchAllCollegesOuterReport(hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), null);
                        }
                        Session["dtData"] = DT;
                        if (DT.Rows.Count > 0)
                        {
                            GVStat.DataSource = DT;
                            GVStat.DataBind();
                            GVStat.Style.Add("display", "block");
                            divDGStat.Style.Add("display", "block");
                            dgCollege.Style.Add("display", "none");
                            tblExportToExcel.Style.Add("display", "block");
                            getcount();
                            DivCollegeUploadInfo.Style.Add("display", "block");
                            hidFacName.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text;
                            hidCrName.Value = ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text;
                            hidBrName.Value = ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text;
                            hidCrPrName.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text;
                            hidCrPrChName.Value = ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
                        }
                        string rc_name = string.Empty;
                        if (YCMOU.IsRegionalCenterVisible)
                        {
                            if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
                            {
                                rc_name = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                                courseOrColl = rc_name + " - " + ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
                            }
                            //*******************************************************************
                            else if (YCMOU.IsRegionalCenterLogin == "True")
                            {
                                rc_name = user.Name;
                                courseOrColl = rc_name + " - " + ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
                            }
                            //******************************************************************
                            else
                            {
                                rc_name = "All Regional Centers";
                                courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text + " - " + rc_name;

                            }
                        }
                        else
                        {
                            courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
                        }
                    }
                }

                //handling college login
                else if (user.UserTypeCode == "2")
                {
                    DT = clsCollegeAdmissionReports.FetchSelectedCollegeOuterReport(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
                    Session["dtData"] = DT;
                    if (DT.Rows.Count > 0)
                    {
                        GVOuterCollege.DataSource = DT;
                        GVOuterCollege.DataBind();
                        GVOuterCollege.Style.Add("display", "block");
                        divDGStat.Style.Add("display", "none");
                        dgCollege.Style.Add("display", "block");

                        courseOrColl = hidCollName.Value;

                        tblExportToExcel.Style.Add("display", "block");
                    }
                }

                if (GVStat.Rows.Count > 0 || GVOuterCollege.Rows.Count > 0)
                {
                    HideSearchCriteria();
                    lblAcaYear.Text = courseOrColl + " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                }


                if (((System.Data.DataTable)Session["dtdata"]) == null || ((System.Data.DataTable)Session["dtdata"]).Rows.Count == 0)
                {
                    tblExportedDataMsg.Style.Add("display", "block");
                    //courseOrColl = hidCollName.Value;
                    //if (courseOrColl == "")
                    //{
                    //    courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " + ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
                    //}
                    lblAcaYear.Text = courseOrColl + " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                    lblExportedData.Text = "No records found.";
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
            //divCollege.Style.Add("display", "none");
            //divCourse.Style.Add("display", "none");
            //divAcademicYr.Style.Add("display", "none");
            //fldAllInst.Style.Add("display", "none");
            //BtnSubmit.Style.Add("display", "none");
            //btnSubmitSelectedCollege.Style.Add("display", "none");
            divYCMOU.Style.Add("display", "none");
        }
        #endregion

        #region Excel Export

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                StringWriter writer2 = new StringWriter();
                StringBuilder oSB = new StringBuilder();
                DataTable dtExport = new DataTable();

                //dtExport = ((System.Data.DataTable)Session["dtdata"]).Copy();
                //*********************************************************************
                if (YCMOU.IsRegionalCenterLogin == "True")
                {

                    //dtExport = clsCollegeAdmissionReports.FetchExcelReportSelectedCollege(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
                    //dtExport.Columns["Course Name"].ColumnName = lblCr.Text + " Name";
                    if (((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedIndex != 0 || ((TextBox)YCMOU.FindControl("txtCenterCode")).Text != string.Empty)
                    {
                        // Selected Study Center for Regional Center login
                        hidInstID.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedValue.Split('|')[0];
                        hidCollName.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedItem.Text;
                        dtExport = clsCollegeAdmissionReports.FetchSelectedCollegeOuterReport(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
                        dtExport.Columns["Course Name"].ColumnName = lblCr.Text + " Name";
                        dtExport.Columns["Total uploaded data"].ColumnName = "Admissions confirmed by " + lblCollege.Text;// as per support #12593
                    }
                    else
                    {
                        // All Study Centers and selected Course
                        hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
                        getFacCrMoLrnPtrnID();
                        hidCrPrDetailsID.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedValue;
                        hidCrPrChID.Value = ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedValue;
                        dtExport = clsCollegeAdmissionReports.FetchExcelReportAllColleges(hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), user.UserReferenceID);
                        dtExport.Columns["College Name"].ColumnName = lblCollege.Text + " Name";
                        dtExport.Columns["College Code"].ColumnName = lblCollege.Text + " Code";
                        dtExport.Columns["Total uploaded data"].ColumnName = "Admissions confirmed by " + lblCollege.Text; //// as per support #12593
                    }
                    
                }
                //*********************************************************************
                else if (hidCollName.Value != "") //college login OR selected RC - selected institute
                {
                    dtExport = clsCollegeAdmissionReports.FetchExcelReportSelectedCollege(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
                    dtExport.Columns["Course Name"].ColumnName = lblCr.Text + " Name";
                    dtExport.Columns["Total uploaded data"].ColumnName = "Admissions confirmed by " + lblCollege.Text; //// as per support #12593

                }

                else
                {
                    if (((RadioButton)YCMOU.FindControl("ChkSelectedRegionalCenter")).Checked) //selected RC-all institutes
                    {
                        if (hidCollName.Value == "")
                        {
                            dtExport = clsCollegeAdmissionReports.FetchExcelReportAllColleges(hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedValue);
                            dtExport.Columns["College Name"].ColumnName = lblCollege.Text + " Name";
                            dtExport.Columns["College Code"].ColumnName = lblCollege.Text + " Code";
                            dtExport.Columns["Total uploaded data"].ColumnName = "Admissions confirmed by " + lblCollege.Text; //// as per support #12593
                        }

                    }
                    else  //all RC-all institutes
                    {
                        dtExport = clsCollegeAdmissionReports.FetchExcelReportAllColleges(hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]), Convert.ToString(Session["pk_CrPrCh_ID"]), null);
                        dtExport.Columns["College Name"].ColumnName = lblCollege.Text + " Name";
                        dtExport.Columns["College Code"].ColumnName = lblCollege.Text + " Code";
                        dtExport.Columns["Total uploaded data"].ColumnName = "Admissions confirmed by " + lblCollege.Text; //// as per support #12593
                    }
                }
                //else if (hidCollName.Value != "")
                //{
                //    dtExport = clsCollegeAdmissionReports.FetchExcelReportSelectedCollege(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
                //    dtExport.Columns["Course Name"].ColumnName = lblCr.Text + " Name";
                //}
                dtExport.Columns["Paper Discrepancy Count"].ColumnName = lblPaper.Text + " Discrepancy Count";
                dtExport.Columns.Remove("pk_Inst_ID");
                dtExport.Columns.Remove("pk_Cr_ID");
                dtExport.Columns.Remove("pk_MoLrn_ID");
                dtExport.Columns.Remove("pk_Ptrn_ID");
                dtExport.Columns.Remove("pk_Brn_ID");
                dtExport.Columns.Remove("fk_CrPr_Details_ID");
                dtExport.Columns.Remove("pk_CrPrCh_ID");
                dtExport.Columns.Remove("pk_Fac_ID");
                if (YCMOU.IsRegionalCenterVisible.Equals(false))
                    dtExport.Columns.Remove("RegionalCenterInfo");

                oSB.Append("<?xml version=\"1.0\"?>");
                oSB.Append("<ss:Workbook xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
                oSB.Append("<ss:Styles>");
                oSB.Append("<ss:Style ss:ID=\"1\">");
                oSB.Append("<ss:Font ss:Bold=\"1\"/>");
                oSB.Append("</ss:Style>");
                oSB.Append("</ss:Styles>");



                oSB.Append("<ss:Worksheet ss:Name=\"" + dtExport.TableName + "\">");
                oSB.Append("<ss:Table>");
                if (YCMOU.IsRegionalCenterVisible.Equals(true))
                    oSB.Append("<ss:Column ss:Width=\"300\"/>");
                if (hidCollName.Value == "")
                {
                    oSB.Append("<ss:Column ss:Width=\"80\"/>");
                    oSB.Append("<ss:Column ss:Width=\"300\"/>");

                }
                else if (hidCollName.Value != "")
                {
                    oSB.Append("<ss:Column ss:Width=\"300\"/>");

                }

                

                oSB.Append("<ss:Column ss:Width=\"115\"/>");
                oSB.Append("<ss:Column ss:Width=\"115\"/>");
                oSB.Append("<ss:Column ss:Width=\"115\"/>");
                oSB.Append("<ss:Column ss:Width=\"115\"/>");
                oSB.Append("<ss:Column ss:Width=\"120\"/>");
                oSB.Append("<ss:Column ss:Width=\"115\"/>");
                oSB.Append("<ss:Column ss:Width=\"115\"/>");
                oSB.Append("<ss:Column ss:Width=\"115\"/>");
                oSB.Append("<ss:Column ss:Width=\"115\"/>");
                oSB.Append("<ss:Column ss:Width=\"115\"/>");
                oSB.Append("<ss:Column ss:Width=\"115\"/>");
                oSB.Append("<ss:Column ss:Width=\"115\"/>");
                oSB.Append("<ss:Column ss:Width=\"120\"/>");
                oSB.Append("<ss:Column ss:Width=\"120\"/>");
                oSB.Append("<ss:Row>");
                oSB.Append("<ss:Cell ss:MergeAcross=\"14\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Academic Year: " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "</ss:Data></ss:Cell>");
                oSB.Append("</ss:Row>");

                if (hidCollName.Value != "")
                {
                    oSB.Append("<ss:Row>");
                    oSB.Append("<ss:Cell ss:MergeAcross=\"14\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + lblCollege.Text + " Name: " + hidCollName.Value + "</ss:Data></ss:Cell>");
                    oSB.Append("</ss:Row>");
                }
                else
                {
                    if (user.UserTypeCode != "2")
                    {
                        oSB.Append("<ss:Row>");
                        oSB.Append("<ss:Cell ss:MergeAcross=\"14\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + lblFaculty.Text + ": " + ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + "</ss:Data></ss:Cell>");
                        oSB.Append("</ss:Row>");

                        oSB.Append("<ss:Row>");
                        oSB.Append("<ss:Cell ss:MergeAcross=\"14\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + lblCr.Text + ": " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + "</ss:Data></ss:Cell>");
                        oSB.Append("</ss:Row>");

                        oSB.Append("<ss:Row>");
                        oSB.Append("<ss:Cell ss:MergeAcross=\"14\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Branch: " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + "</ss:Data></ss:Cell>");
                        oSB.Append("</ss:Row>");

                        oSB.Append("<ss:Row>");
                        oSB.Append("<ss:Cell ss:MergeAcross=\"14\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + lblCr.Text + " Part: " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + "</ss:Data></ss:Cell>");
                        oSB.Append("</ss:Row>");

                        oSB.Append("<ss:Row>");
                        oSB.Append("<ss:Cell ss:MergeAcross=\"14\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + lblCr.Text + " Part Term: " + ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text + "</ss:Data></ss:Cell>");
                        oSB.Append("</ss:Row>");

                        if (YCMOU.IsRegionalCenterVisible.Equals(true))
                        {
                            string RegCentre = string.Empty;
                            if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
                            {
                                RegCentre = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                            }
                            else
                            {
                                RegCentre = "all Regional Centres";
                            }
                            oSB.Append("<ss:Row>");
                            oSB.Append("<ss:Cell ss:MergeAcross=\"14\" ss:StyleID=\"1\"><ss:Data ss:Type=\"String\">" + "Regional Centre: " + RegCentre + "</ss:Data></ss:Cell>");
                            oSB.Append("</ss:Row>");
                        }

                    }
                }

                oSB.Append("<ss:Row>");
                oSB.Append("<ss:Cell ss:MergeAcross=\"10\"><ss:Data ss:Type=\"String\"></ss:Data></ss:Cell>");
                oSB.Append("</ss:Row>");

                oSB.Append("<ss:Row ss:StyleID=\"1\">");
                for (int iCol = 0; iCol <= dtExport.Columns.Count - 1; iCol++)
                {

                    oSB.Append("<ss:Cell><ss:Data ss:Type=\"String\">" + dtExport.Columns[iCol].ColumnName + "</ss:Data></ss:Cell>");

                }
                oSB.Append("</ss:Row>");

                for (int iRow = 0; iRow <= dtExport.Rows.Count - 1; iRow++)
                {
                    oSB.Append("<ss:Row>");
                    for (int iCol = 0; iCol <= dtExport.Columns.Count - 1; iCol++)
                    {
                        oSB.Append("<ss:Cell><ss:Data ss:Type=\"String\">" + dtExport.Rows[iRow][iCol].ToString() + "</ss:Data></ss:Cell>");
                    }
                    oSB.Append("</ss:Row>");
                }

                oSB.Append("</ss:Table>");
                oSB.Append("</ss:Worksheet>");

                oSB.Append("</ss:Workbook>");
                this.Response.ContentType = "application/vnd.ms-excel";
                this.Response.AddHeader("Content-Disposition", "attachment; filename = " + "ExportedStatisticsReport.xls;");
                this.Response.Write(oSB.ToString());
                writer2.Close();
                this.Response.End();
                if (dtExport != null) { dtExport = null; }

                #region RKLib
                //try
                //{
                //    // Get the datatable to export

                //    RKLib.ExportData.Export objExport = new RKLib.ExportData.Export();                

                //    // Export all the details to Excel - for one course all colleges
                //    if (ddlCollegeName.SelectedIndex != 0)
                //    {
                //        int[] ColumnsList = { 0, 1, 2, 3, 4, 5, 6 };
                //        string[] Headers = { "" + lblCr.Text + " Name", "Total Intake Capacity ", "Total Uploaded Data", "Total Eligiblity Processed", "Eligibility not Processed", "Duplicate Student Count", lblPaper.Text + " Discrepancy Count" };
                //        objExport.ExportDetails(((System.Data.DataTable)Session["dtdata"]), ColumnsList, Headers, Export.ExportFormat.Excel, "ExportedStatisticsReport");

                //    }

                //    // Export all the details to Excel - for all courses one college
                //    else if (ddlCollegeName.SelectedIndex == 0)
                //    {

                //        int[] ColumnsList = { 1, 2, 3, 4, 5, 6, 7, 8 };                    
                //        string[] Headers = { "" + lblCollege.Text + " Code", "" + lblCollege.Text+ " Name, City", "Total Intake Capacity ", "Total Uploaded Data", "Total Eligiblity Processed", "Eligibility not Processed", "Duplicate Student Count", lblPaper.Text + " Discrepancy Count" };
                //        objExport.ExportDetails(((System.Data.DataTable)Session["dtdata"]), ColumnsList, Headers, Export.ExportFormat.Excel, "ExportedStatisticsReport");

                //    }

                //    // tblExportedDataMsg.Style.Add("display", "block");
                //    //lblExportedData.Text = "Exported Successfully to Excel.....";

                //}

                //catch (Exception Ex)
                //{
                //    //tblExportedDataMsg.Style.Add("display", "block");
                //    //lblExportedData.CssClass = "errorNote";               

                //}
                //finally
                //{
                //    ((System.Data.DataTable)Session["dtdata"]).Dispose();

                //}
                #endregion
            }
            catch (Exception Ex3)
            {
                throw (Ex3);
            }

        }

        #endregion

        //#region Filling DropDowns

        //#region Selected Index Changed
        //protected void ddlFacDesc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ddlCrBrnDesc.Items.Clear();
        //    ddlCrPrDetailsDesc.Items.Clear();
        //    ddlCrPrChDesc.Items.Clear();
        //    hidInstID.Value = string.Empty;

        //    ddlCrBrnDesc.Items.Insert(0, new ListItem("--- Select ---", "-1"));
        //    ddlCrPrDetailsDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
        //    ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));

        //    FillFacultyCourseMoLrnPatternName(hidUniID.Value, hidInstID.Value, ddlFacDesc.SelectedValue);

        //    ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlFacDesc);
        //    divCourse.Style.Add("display", "block");
        //    divCollege.Style.Add("display", "none");
        //}

        //protected void ddlCrDesc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ddlCrPrDetailsDesc.Items.Clear();
        //    ddlCrPrChDesc.Items.Clear();

        //    ddlCrPrDetailsDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
        //    ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));

        //    ////Call for Seting FacultyID , CourseID ,MoLrnID and PatternID
        //    getFacCrMoLrnPtrnID();

        //    ////This will Fill Correspondance Branch Drop Down
        //    FillBranch(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value);

        //    ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrDesc);
        //}

        //private void FillBranch(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID)
        //{
        //    ddlCrBrnDesc.Items.Clear();
        //    oDT = new System.Data.DataTable();
        //    try
        //    {
        //        if (hidInstID.Value != "")
        //        {
        //            oDT = oInstituteRepository.AssignedConfirmedBranches(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID);
        //        }
        //        else
        //        {
        //            oDT = crRepository.ListCourseModeOfLearningPatternWiseLaunchedBranches(long.Parse(Uni_ID), long.Parse(Fac_ID), long.Parse(Cr_ID), long.Parse(Molrn_ID), long.Parse(Ptrn_ID));
        //        }

        //        if (oDT.Rows.Count > 0)
        //        {
        //            Common = new clsCommon();
        //            if (oDT.Rows.Count == 1)
        //            {
        //                if (Convert.ToString(oDT.Rows[0]["Text"]) == "No Branch")
        //                {
        //                    ListItem li = new ListItem();
        //                    li.Text = "No Branch Available";
        //                    li.Value = "0";
        //                    ddlCrBrnDesc.Items.Add(li);
        //                    FillCoursePart(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, "0");
        //                }
        //                else
        //                {
        //                    Common.fillDropDown(ddlCrBrnDesc, oDT, "-1", "Text", "Value", "---- Select ----");
        //                }
        //            }
        //            else
        //            {
        //                Common.fillDropDown(ddlCrBrnDesc, oDT, "-1", "Text", "Value", "---- Select ----");
        //            }
        //            if (Common != null)
        //            {
        //                Common = null;
        //            }
        //        }
        //        else
        //        {
        //            if (ddlCrDesc.SelectedIndex == 0)
        //            {
        //                ListItem li = new ListItem();
        //                li.Text = "---- Select ----";
        //                li.Value = "-1";
        //                ddlCrBrnDesc.Items.Add(li);
        //            }
        //            else
        //            {
        //                ListItem li = new ListItem();
        //                li.Text = "No Branch Available";
        //                li.Value = "0";
        //                ddlCrBrnDesc.Items.Add(li);
        //            }
        //        }
        //    }
        //    catch (Exception e) { }
        //}

        //protected void ddlCrBrnDesc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ddlCrPrChDesc.Items.Clear();

        //    ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
        //    getFacCrMoLrnPtrnID();

        //    FillCoursePart(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(ddlCrBrnDesc.SelectedValue));
        //    ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrBrnDesc);
        //}


        //protected void ddlCrPrDetailsDesc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    getFacCrMoLrnPtrnID();

        //    ////This will Fill Correspondance Course Part Term Details Drop Down
        //    FillPartTerm(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(ddlCrBrnDesc.SelectedItem.Value), Convert.ToString(ddlCrPrDetailsDesc.SelectedItem.Value));

        //    ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrPrChDesc);
        //}


        //protected void ddlCrPrChDesc_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //#endregion

        //private void FillCoursePart(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID, string Brn_ID)
        //{
        //    ddlCrPrDetailsDesc.Items.Clear();
        //    oDT = new System.Data.DataTable();
        //    Common = new clsCommon();
        //    try
        //    {
        //        if (hidInstID.Value != "")
        //        {
        //            oDT = oInstituteRepository.AssignedConfirmedCourseParts(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, Brn_ID);
        //            Common.fillDropDown(ddlCrPrDetailsDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
        //        }
        //        else
        //        {
        //            oDT = crRepository.ListCourseModeOfLearningPatternBrnWiseLaunchedCourseParts(long.Parse(Uni_ID), long.Parse(Fac_ID), long.Parse(Cr_ID), long.Parse(Molrn_ID), long.Parse(Ptrn_ID), long.Parse(Brn_ID));
        //            Common.fillDropDown(ddlCrPrDetailsDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
        //        }


        //        if (Common != null)
        //        {
        //            Common = null;
        //        }
        //    }
        //    catch (Exception e) { }
        //}

        //private void getFacCrMoLrnPtrnID()
        //{
        //    if (Convert.ToString(ddlCrDesc.SelectedValue) != "0")
        //    {
        //        IDs_List = Convert.ToString(ddlCrDesc.SelectedValue).Split('-');
        //        hidFacID.Value = Convert.ToString(IDs_List[0]).Trim();
        //        hidCrID.Value = Convert.ToString(IDs_List[1]).Trim();
        //        hidMoLrnID.Value = Convert.ToString(IDs_List[2]).Trim();
        //        hidPtrnID.Value = Convert.ToString(IDs_List[3]).Trim();
        //    }
        //    else
        //    {
        //        if (Convert.ToString(ddlCrDesc.SelectedValue) == "0")
        //        {
        //            hidCrID.Value = "0";
        //            hidMoLrnID.Value = "0";
        //            hidPtrnID.Value = "0";
        //        }
        //        hidFacID.Value = ddlFacDesc.SelectedValue;
        //    }
        //}

        //to get ids from combined cr ids

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

        //private void FillFacultyCourseMoLrnPatternName(string Uni_ID, string Inst_ID, string Faculty_ID)
        //{
        //    ddlCrDesc.Items.Clear();
        //    oDT = new System.Data.DataTable();
        //    Common = new clsCommon();
        //    try
        //    {

        //        if (hidInstID.Value != "")
        //        {
        //            oDT = oInstituteRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, Inst_ID, Faculty_ID);
        //            Common.fillDropDown(ddlCrDesc, oDT, string.Empty, "Text", "value", "--- Select ---");
        //        }
        //        else
        //        {
        //            oDT = crRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, Faculty_ID);
        //            Common.fillDropDown(ddlCrDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
        //        }



        //        if (Common != null)
        //        {
        //            Common = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //#endregion

        //#region Function to Add User's newly selected data in session

        //private void MemorizeInSession()
        //{
        //    if (user.UserTypeCode != "2")
        //    {
        //        try
        //        {
        //            Session["facultyID"] = Convert.ToString(ddlFacDesc.SelectedItem.Value);
        //            Session["BranchID"] = Convert.ToString(ddlCrBrnDesc.SelectedItem.Value);
        //            Session["FacCrMoLrnPtrn_ID"] = Convert.ToString(ddlCrDesc.SelectedItem.Value);
        //            Session["pk_CrPr_Details_ID"] = Convert.ToString(ddlCrPrDetailsDesc.SelectedItem.Value);
        //            Session["pk_CrPrCh_ID"] = Convert.ToString(ddlCrPrChDesc.SelectedItem.Value);
        //            Session["pk_AcademicYear_ID"] = Convert.ToString(ddlAcademicYr.SelectedItem.Value);
        //        }
        //        catch (Exception Ex)
        //        {
        //            throw new Exception(Ex.Message);
        //        }
        //    }
        //}
        //#endregion

        //#region FillPartTerm

        //private void FillPartTerm(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID, string Brn_ID, string CrPrDetails_ID)
        //{
        //    ddlCrPrChDesc.Items.Clear();
        //    oDT = new System.Data.DataTable();
        //    Common = new clsCommon();
        //    try
        //    {
        //        if (hidInstID.Value != "")
        //        {
        //            oDT = oInstituteRepository.AssignCoursePartTerm(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Brn_ID, CrPrDetails_ID);
        //            Common.fillDropDown(ddlCrPrChDesc, oDT, string.Empty, "Text", "value", "--- Select ---");
        //        }
        //        else
        //        {
        //            oDT = crRepository.ListCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrCh(long.Parse(hidUniID.Value), long.Parse(CrPrDetails_ID));
        //            Common.fillDropDown(ddlCrPrChDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
        //        }

        //        if (Common != null)
        //        {
        //            Common = null;
        //        }

        //        if (oDT != null)
        //        {
        //            oDT = null;
        //        }

        //    }
        //    catch (Exception Ex5)
        //    {
        //        throw new Exception(Ex5.Message);
        //    }
        //}

        //#endregion

        //#region Display From Session

        //private void DisplyFromSession()
        //{
        //    try
        //    {
        //        if (Session["pk_AcademicYear_ID"] != null)
        //        {
        //            ddlAcademicYr.SelectedValue = Convert.ToString(Session["pk_AcademicYear_ID"]);

        //            oDT = new System.Data.DataTable();
        //            oDT = (System.Data.DataTable)ViewState["AcademicYear"];
        //            DataView odv = oDT.DefaultView;
        //            odv.RowFilter = "pk_AcademicYear_ID =" + ddlAcademicYr.SelectedValue;
        //            if (odv.Count > 0)
        //            {
        //                hid_strAcademicYr1.Value = odv[0]["Start_Date"].ToString();
        //                hid_strAcademicYr2.Value = odv[0]["End_Date"].ToString();
        //            }

        //        }

        //        if (Session["facultyID"] != null)
        //        {
        //            ddlFacDesc.SelectedValue = Convert.ToString(Session["facultyID"]);
        //            if (Session["facultyID"].ToString() != "-1")
        //            {
        //                divCollege.Style.Add("display", "none");
        //                divCourse.Style.Add("display", "block");
        //            }
        //        }

        //        if (Session["FacCrMoLrnPtrn_ID"] != null)
        //        {
        //            FillFacultyCourseMoLrnPatternName(clsGetSettings.UniversityID, hidInstID.Value, ddlFacDesc.SelectedItem.Value);
        //            ddlCrDesc.SelectedValue = Convert.ToString(Session["FacCrMoLrnPtrn_ID"]);
        //            getFacCrMoLrnPtrnID();
        //        }

        //        if (Session["BranchID"] != null)
        //        {
        //            //This will Fill Correspondance Branch Drop Down
        //            FillBranch(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value);
        //            ddlCrBrnDesc.SelectedValue = Convert.ToString(Session["BranchID"]);
        //        }

        //        if (Session["pk_CrPr_Details_ID"] != null)
        //        {
        //            //This will Fill Correspondance Course Part Details Drop Down
        //            FillCoursePart(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]));
        //            ddlCrPrDetailsDesc.SelectedValue = Convert.ToString(Session["pk_CrPr_Details_ID"]);

        //            //This will Fill Correspondance Course Part Childs Drop Down
        //            FillPartTerm(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]), Convert.ToString(Session["pk_CrPr_Details_ID"]));
        //        }

        //        if (Session["pk_CrPrCh_ID"] != null)
        //        {
        //            ddlCrPrChDesc.SelectedValue = Convert.ToString(Session["pk_CrPrCh_ID"]);
        //        }
        //    }

        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}


        //#endregion

        

    }

}
