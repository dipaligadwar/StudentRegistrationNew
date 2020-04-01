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
    public partial class ELGV2_rptViewStatus : System.Web.UI.Page
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
                lblPageHead.Text = "Student Eligibility Status Report";
                if (hidUniID.Value == "")
                {
                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                }

                if (user.UserTypeCode == "2")
                {
                    hidInstID.Value = user.UserReferenceID;
                    divCollege.Style.Add("display", "none");
                    hidCollName.Value = user.Name;
                    //dtInst = oInstituteRepository.InstituteDetails(hidUniID.Value.ToString(), hidInstID.Value.ToString());
                    //hidCollName.Value = dtInst.Rows[0]["Inst_Name"].ToString();
                    //Collcode.Text = dtInst.Rows[0]["Inst_Code"].ToString();
                   
                }

                
                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                ViewState["AcademicYear"] = dt;
                Common.fillDropDown(ddlAcademicYr, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                ddlAcademicYr.SelectedIndex = 0;
                hid_AcademicYear.Value = ddlAcademicYr.SelectedItem.Text;
                hid_AcademicYearFrom.Value = dt.Rows[ddlAcademicYr.SelectedIndex]["Academic_StartDate"].ToString();
                hid_AcademicYearTo.Value = dt.Rows[ddlAcademicYr.SelectedIndex]["Academic_EndDate"].ToString();
                date = hid_AcademicYearFrom.Value.ToString() + '-' + hid_AcademicYearTo.Value.ToString();
                FillCollegeList();

                fnFirstFill();
                DisplyFromSession();
            }

            hid_AcademicYear.Value = ddlAcademicYr.SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ddlAcademicYr.SelectedValue.ToString();

        }

        #endregion

        #region InitializeCulture

        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        #region Other Functions

        #region fnFirstFill

        private void fnFirstFill()
        {
            hidLevelFlag.Value = "7";

            if (user.UserTypeCode != "2")
            {
                FetchUniversityWiseFacultyList(ddlFacDesc);
            }
            if (user.UserTypeCode == "2")
            {
                FetchCollegeWiseConfirmedFacultyList(hidUniID.Value, hidInstID.Value);
            }
        }

        #endregion

        #region Fetch University Wise Faculty List

        public void FetchUniversityWiseFacultyList(DropDownList ddlFacDesc)
        {

            DataTable listFaculty = crRepository.LaunchedUniversityWiseFacultyList(Convert.ToInt64(hidUniID.Value.ToString()));
            try
            {
                if (listFaculty != null)
                {
                    ddlFacDesc.DataSource = listFaculty;
                    ddlFacDesc.DataTextField = "text";
                    ddlFacDesc.DataValueField = "value";
                    ddlFacDesc.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--- Select ---", "-1");
                    ddlFacDesc.Items.Insert(0, li);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Fetch College wise Assigned Confirmed Faculties

        public void FetchCollegeWiseConfirmedFacultyList(string UniID, string InstID)
        {

            DataTable listFaculty = oInstituteRepository.AssignedConfirmedFaculties(hidUniID.Value.ToString(), hidInstID.Value);
            try
            {
                if (listFaculty != null)
                {
                    ddlFacDesc.DataSource = listFaculty;
                    ddlFacDesc.DataTextField = "Fac_Desc";
                    ddlFacDesc.DataValueField = "pk_Fac_ID";
                    ddlFacDesc.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--- Select ---", "-1");
                    ddlFacDesc.Items.Insert(0, li);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #endregion
        
        #region Function to Add User's newly selected data in session

        private void MemorizeInSession()
        {
            try
            {
                Session["ElgfacultyID"] = Convert.ToString(ddlFacDesc.SelectedItem.Value);
                Session["ElgBranchID"] = Convert.ToString(ddlCrBrnDesc.SelectedItem.Value);
                Session["ElgFacCrMoLrnPtrn_ID"] = Convert.ToString(ddlCrDesc.SelectedItem.Value);
                Session["Elgpk_CrPr_Details_ID"] = Convert.ToString(ddlCrPrDetailsDesc.SelectedItem.Value);
                Session["Elgpk_CrPrCh_ID"] = Convert.ToString(ddlCrPrChDesc.SelectedItem.Value);
                Session["Elgpk_AcademicYear_ID"] = Convert.ToString(ddlAcademicYr.SelectedItem.Value);
                Session["ElgCollName"] = Convert.ToString(ddlCollegeName.SelectedItem.Value);
                Session["ElgCollCode"] = Convert.ToString(Collcode.Text);
                string criterion = string.Empty;
                foreach (ListItem li in cblEligibilityStatus.Items)
                {
                    if (li.Selected)
                    {
                        criterion += li.Value + ",";
                    }
                }
                criterion = criterion.TrimEnd(',');
                Session["ElgCriteria"] = criterion;
                Session["elgSort"] = rblSortStudent.SelectedValue;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        #endregion

        #region Display From Session

        private void DisplyFromSession()
        {
            try
            {
                if (Session["Elgpk_AcademicYear_ID"] != null)
                {
                    ddlAcademicYr.SelectedValue = Convert.ToString(Session["Elgpk_AcademicYear_ID"]);

                    oDT = new System.Data.DataTable();
                    oDT = (System.Data.DataTable)ViewState["AcademicYear"];
                    DataView odv = oDT.DefaultView;
                    odv.RowFilter = "pk_AcademicYear_ID =" + ddlAcademicYr.SelectedValue;
                    if (odv.Count > 0)
                    {
                        hid_strAcademicYr1.Value = odv[0]["Start_Date"].ToString();
                        hid_strAcademicYr2.Value = odv[0]["End_Date"].ToString();
                    }

                }

                if (Session["ElgfacultyID"] != null)
                {
                    ddlFacDesc.SelectedValue = Convert.ToString(Session["ElgfacultyID"]);
                }

                if (Session["ElgFacCrMoLrnPtrn_ID"] != null)
                {
                    FillFacultyCourseMoLrnPatternName(clsGetSettings.UniversityID, hidInstID.Value, ddlFacDesc.SelectedItem.Value);
                    ddlCrDesc.SelectedValue = Convert.ToString(Session["ElgFacCrMoLrnPtrn_ID"]);
                    getFacCrMoLrnPtrnID();
                }

                if (Session["ElgBranchID"] != null)
                {
                    //This will Fill Correspondance Branch Drop Down
                    FillBranch(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value);
                    ddlCrBrnDesc.SelectedValue = Convert.ToString(Session["ElgBranchID"]);
                }

                if (Session["Elgpk_CrPr_Details_ID"] != null)
                {
                    //This will Fill Correspondance Course Part Details Drop Down
                    FillCoursePart(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["ElgBranchID"]));
                    ddlCrPrDetailsDesc.SelectedValue = Convert.ToString(Session["Elgpk_CrPr_Details_ID"]);

                    //This will Fill Correspondance Course Part Childs Drop Down
                    FillPartTerm(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["ElgBranchID"]), Convert.ToString(Session["Elgpk_CrPr_Details_ID"]));
                }

                if (Session["Elgpk_CrPrCh_ID"] != null)
                {
                    ddlCrPrChDesc.SelectedValue = Convert.ToString(Session["Elgpk_CrPrCh_ID"]);
                }

                if (Session["ElgCollName"] != null)
                {
                    ddlCollegeName.SelectedValue = Convert.ToString(Session["ElgCollName"]);
                }

                if (Session["ElgCollCode"] != null)
                {
                    Collcode.Text = Convert.ToString(Session["ElgCollCode"]);
                }

                if (Session["ElgCriteria"] != null)
                {
                    foreach (string c in Convert.ToString(Session["ElgCriteria"]).Split(','))
                    {
                        cblEligibilityStatus.Items.FindByValue(c).Selected = true;
                    }
                }

                if (Session["ElgSort"] != null)
                {
                    rblSortStudent.SelectedValue = Convert.ToString(Session["ElgSort"]);
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        #endregion

        #region Display Eligibility Details

        protected void DisplayEligibilityDetails()
        {

            string selectedCriteria = "";
            if (user.UserTypeCode != "2")
            {
                hidInstID.Value = string.Empty;
                hidCollName.Value = string.Empty;
            }
            string collName = string.Empty;
            for (int i = 0; i < cblEligibilityStatus.Items.Count; i++)
            {
                if (cblEligibilityStatus.Items[i].Selected)
                {
                    selectedCriteria += cblEligibilityStatus.Items[i].Value + ",";
                }
            }
            int l = selectedCriteria.LastIndexOf(',');
            selectedCriteria = selectedCriteria.Remove(l);
            if (cblEligibilityStatus.Items[0].Selected == false && cblEligibilityStatus.Items[1].Selected == false && cblEligibilityStatus.Items[2].Selected == false && cblEligibilityStatus.Items[3].Selected == false)
                hidCriteria.Value = "0";
            else
                hidCriteria.Value = selectedCriteria;
            hidCriteriaNull.Value = "";
            if (cblEligibilityStatus.Items[4].Selected == true)
            {
                hidCriteriaNull.Value = cblEligibilityStatus.Items[4].Value;
            }

            hidCriteriaEligibilityRequired.Value = "";
            
            if (cblEligibilityStatus.Items[5].Selected == false)
                hidCriteriaEligibilityRequired.Value = "Y";         // Records with Eligibility_Required = '1'     
            else if (cblEligibilityStatus.Items[5].Selected == true)

                hidCriteriaEligibilityRequired.Value = "N";      // All records Eligibility_Required = '1'/'2'      
                
                hidSortOption.Value = rblSortStudent.SelectedValue;

            if (!string.IsNullOrEmpty(txtFrom.Text))
            {
                hidFromDate.Value = txtFrom.Text;
                hidToDate.Value = txtTo.Text;
            }

            //setting inst id
            if (hidInstID.Value.Equals(string.Empty))
            {
                if (ddlCollegeName.SelectedIndex != 0 || Collcode.Text != string.Empty)
                {
                    //if (Collcode.Text != string.Empty)
                    //{
                    //    dtCollege = new System.Data.DataTable();
                    //    oclsEligibilityDBAccess = new clsEligibilityDBAccess();
                    //    dtCollege = oclsEligibilityDBAccess.ListColleges(Convert.ToInt32(clsGetSettings.UniversityID));
                    //    DataView odv = dtCollege.DefaultView;
                    //    odv.RowFilter = "Inst_Code= '" + Collcode.Text + "'";
                    //    if (odv.Count != 0)
                    //    {
                    //        collName = odv[0].Row.ItemArray[1].ToString();
                    //        if ((collName + "," + odv[0].Row.ItemArray[3].ToString()).Equals(ddlCollegeName.SelectedItem.Text))
                    //        {
                    //            hidInstID.Value = ddlCollegeName.SelectedValue.Split('|')[0];
                    //            hidCollName.Value = ddlCollegeName.SelectedItem.Text;
                    //        }
                    //        else
                    //        {
                    //            hidInstID.Value = odv[0].Row.ItemArray[0].ToString();
                    //            hidCollName.Value = collName + "," + odv[0].Row.ItemArray[3].ToString();
                    //        }
                    //    }
                    //}

                    //if (hidInstID.Value.Equals("") || hidInstID.Value.Equals("0"))
                    //{
                    hidInstID.Value = ddlCollegeName.SelectedValue.Split('|')[0];
                    hidCollName.Value = ddlCollegeName.SelectedItem.Text;
                    //}
                }
            }

            try
            {
                DataSet DS;
                DS = clsEligibilityDBAccess.ProcessedEligibilityStudentsList(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["ElgBranchID"]), Convert.ToString(Session["Elgpk_CrPr_Details_ID"]), Convert.ToString(Session["Elgpk_CrPrCh_ID"]), hid_fk_AcademicYr_ID.Value, hidSortOption.Value, hidCriteria.Value, hidCriteriaNull.Value, hidCriteriaEligibilityRequired.Value,hidFromDate.Value,hidToDate.Value);//  hidStateID.Value, hidDistrictID.Value, hidTalukaID.Value, hidDOB.Value, hidFirstName.Value, hidLastName.Value, hidGender.Value);
                if (DS.Tables.Count != 0)
                {
                    DataView dv = new DataView();
                    dv.Table = DS.Tables[0];
                    Session["ViewElg_dtData"] = DS.Tables[0];

                    if (DS.Tables[0].Rows.Count > 0 && DS.Tables[0].ToString() != null)
                    {
                        if (ViewState["SortExpression"] != null)
                        {
                            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();

                        }

                        DGEligibility1.DataSource = dv;
                        tblDGEligibility.Style.Add("display", "block");
                        btnGenerate.Style.Add("display", "block");
                        DGEligibility1.DataBind();
                        divAllCriterion.Style.Add("display", "none");
                        lblnorecordfound.Style.Add("display", "none");

                    }

                    else
                    {
                        tblDGEligibility.Style.Add("display", "none");
                        btnBackDisplay.Style.Add("display", "block");
                        btnGenerate.Style.Add("display", "none");
                        lblnorecordfound.Style.Add("display", "block");
                        lblnorecordfound.CssClass = "errorNote";
                        lblnorecordfound.Text = "No Record(s) found.";
                        lblnorecordfound.Style.Add("display", "block");
                        Session.Remove("ViewElg_dtData");
                    }
                }
                else
                {
                    tblDGEligibility.Style.Add("display", "none");
                    btnBackDisplay.Style.Add("display", "block");
                    btnGenerate.Style.Add("display", "none");
                    lblnorecordfound.Style.Add("display", "block");
                    lblnorecordfound.CssClass = "errorNote";
                    lblnorecordfound.Text = "No Record(s) found.";
                    lblnorecordfound.Style.Add("display", "block");
                    Session.Remove("ViewElg_dtData");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                throw new Exception(ex.Message);
            }

        }

        #endregion

        #region btnDisplay_Click

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            MemorizeInSession();

            divDGEligibility.Style.Add("display", "block");
            DisplayEligibilityDetails();

            if (Collcode.Text != "-" || Collcode.Text != "")
            {

                lblAcaYear.Text = "for " + hidCollName.Value + " (" + Collcode.Text.ToUpper() + ")" + " - " + ddlFacDesc.SelectedItem.Text + " - " + ddlCrDesc.SelectedItem.Text + " - " + ddlCrBrnDesc.SelectedItem.Text + " - " + ddlCrPrDetailsDesc.SelectedItem.Text + " - " + ddlCrPrChDesc.SelectedItem.Text + " [Academic Year " + ddlAcademicYr.SelectedItem.Text + "]";
            }
            else
            {
                lblAcaYear.Text = "for " + hidCollName.Value + " - " + ddlFacDesc.SelectedItem.Text + " - " + ddlCrDesc.SelectedItem.Text + " - " + ddlCrBrnDesc.SelectedItem.Text + " - " + ddlCrPrDetailsDesc.SelectedItem.Text + " - " + ddlCrPrChDesc.SelectedItem.Text + " [Academic Year " + ddlAcademicYr.SelectedItem.Text + "]";
            }


        }

        #endregion

        #region GridView Events

        protected void DGEligibility1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGEligibility1.PageIndex = e.NewPageIndex;
            DisplayEligibilityDetails();
        }

        protected void DGEligibility1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                if (ViewState["SortOrder"].ToString() == " asc")
                    ViewState["SortOrder"] = " desc";
                else
                    ViewState["SortOrder"] = " asc";
            }
            else
            {
                ViewState["SortExpression"] = e.SortExpression;
                ViewState["SortOrder"] = " asc";
            }
            DisplayEligibilityDetails();

        }

        #endregion

        #region Filling DropDowns

        #region Selected Index Changed

        protected void ddlFacDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCrBrnDesc.Items.Clear();
            ddlCrPrDetailsDesc.Items.Clear();
            ddlCrPrChDesc.Items.Clear();
            if (user.UserTypeCode != "2")
            {
                hidInstID.Value = string.Empty;
            }

            ddlCrBrnDesc.Items.Insert(0, new ListItem("--- Select ---", "-1"));
            ddlCrPrDetailsDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));

            FillFacultyCourseMoLrnPatternName(hidUniID.Value, hidInstID.Value, ddlFacDesc.SelectedValue);

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlFacDesc);
        }

        protected void ddlCrDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCrPrDetailsDesc.Items.Clear();
            ddlCrPrChDesc.Items.Clear();
            if (user.UserTypeCode != "2")
            {
                hidInstID.Value = string.Empty;
            }

            ddlCrPrDetailsDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));

            ////Call for Seting FacultyID , CourseID ,MoLrnID and PatternID
            getFacCrMoLrnPtrnID();

            ////This will Fill Correspondance Branch Drop Down
            FillBranch(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value);

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrDesc);
        }

        private void FillBranch(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID)
        {
            ddlCrBrnDesc.Items.Clear();
            oDT = new System.Data.DataTable();
            try
            {
                if (hidInstID.Value != "")
                {
                    oDT = oInstituteRepository.AssignedConfirmedBranches(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID);
                }
                else
                {
                    oDT = crRepository.ListCourseModeOfLearningPatternWiseLaunchedBranches(long.Parse(Uni_ID), long.Parse(Fac_ID), long.Parse(Cr_ID), long.Parse(Molrn_ID), long.Parse(Ptrn_ID));
                }

                if (oDT.Rows.Count > 0)
                {
                    Common = new clsCommon();
                    if (oDT.Rows.Count == 1)
                    {
                        if (Convert.ToString(oDT.Rows[0]["Text"]) == "No Branch")
                        {
                            ListItem li = new ListItem();
                            li.Text = "No Branch Available";
                            li.Value = "0";
                            ddlCrBrnDesc.Items.Add(li);
                            FillCoursePart(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, "0");
                        }
                        else
                        {
                            Common.fillDropDown(ddlCrBrnDesc, oDT, "-1", "Text", "Value", "---- Select ----");
                        }
                    }
                    else
                    {
                        Common.fillDropDown(ddlCrBrnDesc, oDT, "-1", "Text", "Value", "---- Select ----");
                    }
                    if (Common != null)
                    {
                        Common = null;
                    }
                }
                else
                {
                    if (ddlCrDesc.SelectedIndex == 0)
                    {
                        ListItem li = new ListItem();
                        li.Text = "---- Select ----";
                        li.Value = "-1";
                        ddlCrBrnDesc.Items.Add(li);
                    }
                    else
                    {
                        ListItem li = new ListItem();
                        li.Text = "No Branch Available";
                        li.Value = "0";
                        ddlCrBrnDesc.Items.Add(li);
                    }
                }
            }
            catch (Exception e) { }
        }

        protected void ddlCrBrnDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCrPrChDesc.Items.Clear();

            ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
            getFacCrMoLrnPtrnID();

            FillCoursePart(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(ddlCrBrnDesc.SelectedValue));
            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrBrnDesc);
        }


        protected void ddlCrPrDetailsDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            getFacCrMoLrnPtrnID();

            ////This will Fill Correspondance Course Part Term Details Drop Down
            FillPartTerm(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(ddlCrBrnDesc.SelectedItem.Value), Convert.ToString(ddlCrPrDetailsDesc.SelectedItem.Value));

            ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrPrChDesc);
        }


        protected void ddlCrPrChDesc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void FillCoursePart(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID, string Brn_ID)
        {
            ddlCrPrDetailsDesc.Items.Clear();
            oDT = new System.Data.DataTable();
            Common = new clsCommon();
            try
            {
                if (hidInstID.Value != "")
                {
                    oDT = oInstituteRepository.AssignedConfirmedCourseParts(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, Brn_ID);
                    Common.fillDropDown(ddlCrPrDetailsDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
                }
                else
                {
                    oDT = crRepository.ListCourseModeOfLearningPatternBrnWiseLaunchedCourseParts(long.Parse(Uni_ID), long.Parse(Fac_ID), long.Parse(Cr_ID), long.Parse(Molrn_ID), long.Parse(Ptrn_ID), long.Parse(Brn_ID));
                    Common.fillDropDown(ddlCrPrDetailsDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
                }

                if (Common != null)
                {
                    Common = null;
                }
            }
            catch (Exception e) { }
        }

        private void getFacCrMoLrnPtrnID()
        {
            if (Convert.ToString(ddlCrDesc.SelectedValue) != "0")
            {
                IDs_List = Convert.ToString(ddlCrDesc.SelectedValue).Split('-');
                hidFacID.Value = Convert.ToString(IDs_List[0]).Trim();
                hidCrID.Value = Convert.ToString(IDs_List[1]).Trim();
                hidMoLrnID.Value = Convert.ToString(IDs_List[2]).Trim();
                hidPtrnID.Value = Convert.ToString(IDs_List[3]).Trim();
            }
            else
            {
                if (Convert.ToString(ddlCrDesc.SelectedValue) == "0")
                {
                    hidCrID.Value = "0";
                    hidMoLrnID.Value = "0";
                    hidPtrnID.Value = "0";
                }
                hidFacID.Value = ddlFacDesc.SelectedValue;
            }
        }

        private void FillFacultyCourseMoLrnPatternName(string Uni_ID, string Inst_ID, string Faculty_ID)
        {
            ddlCrDesc.Items.Clear();
            oDT = new System.Data.DataTable();
            Common = new clsCommon();
            try
            {

                if (hidInstID.Value != "")
                {
                    oDT = oInstituteRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, Inst_ID, Faculty_ID);
                    Common.fillDropDown(ddlCrDesc, oDT, string.Empty, "Text", "value", "--- Select ---");
                }
                else
                {
                    oDT = crRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, Faculty_ID);
                    Common.fillDropDown(ddlCrDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
                }

                if (Common != null)
                {
                    Common = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region FillPartTerm

        private void FillPartTerm(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID, string Brn_ID, string CrPrDetails_ID)
        {
            ddlCrPrChDesc.Items.Clear();
            oDT = new System.Data.DataTable();
            Common = new clsCommon();
            try
            {
                if (hidInstID.Value != "")
                {
                    oDT = oInstituteRepository.AssignCoursePartTerm(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(ddlCrBrnDesc.SelectedValue), Convert.ToString(ddlCrPrDetailsDesc.SelectedValue));
                    Common.fillDropDown(ddlCrPrChDesc, oDT, string.Empty, "Text", "value", "--- Select ---");
                }
                else
                {
                    oDT = crRepository.ListCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrCh(long.Parse(hidUniID.Value), long.Parse(CrPrDetails_ID));
                    Common.fillDropDown(ddlCrPrChDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
                }


                if (Common != null)
                {
                    Common = null;
                }

                if (oDT != null)
                {
                    oDT = null;
                }

            }
            catch (Exception Ex5)
            {
                throw new Exception(Ex5.Message);
            }
        }

        #endregion

        #region Fill College List

        public void FillCollegeList()
        {
            dtCollege = new System.Data.DataTable();
            oclsEligibilityDBAccess = new clsEligibilityDBAccess();
            int uniID = Convert.ToInt32(clsGetSettings.UniversityID);
            try
            {
                dtCollege = oclsEligibilityDBAccess.ListColleges(uniID);

                if (dtCollege.Rows.Count > 0)
                {
                    foreach (DataRow drCollege in dtCollege.Rows)
                    {
                        string itemValue = drCollege["pk_Inst_ID"].ToString() + "|" + drCollege["Inst_Code"].ToString();
                        ddlCollegeName.Items.Add(new ListItem(drCollege["Inst_Name"].ToString() + "," + drCollege["Inst_City"].ToString(), itemValue));

                    }
                    foreach (ListItem li in this.ddlCollegeName.Items)
                    {

                        li.Attributes.Add("title", li.Text);

                    }
                    ddlCollegeName.Items.Insert(0, new ListItem("--- Select ---", "0"));

                }

                ddlCollegeName.Attributes.Add("onmouseover", "this.title=this.options[this.selectedIndex].title");
               
            }
            catch (Exception)
            {
                dtCollege = null;
            }
        }

        #endregion

        #region PDF Export

        protected void btnGenerate_Click(object sender, EventArgs e)
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
            Response.AddHeader("content-disposition", "attachment; filename=EligibilityStatusReport.pdf");
            Response.BinaryWrite(renderedBytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();

            #endregion
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
            Response.AddHeader("content-disposition", "attachment; filename=EligStatusReport.xls");
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
                dtExport = ((System.Data.DataTable)Session["ViewElg_dtData"]).Copy();
                ReportDataSource ReportDetailsDS1 = new ReportDataSource("dsViewElgStatus_dtViewElgStatus", dtExport);
                ReportParameter[] p = new ReportParameter[5];
                p.SetValue(new ReportParameter("SubHead", lblAcaYear.Text), 0);
                p.SetValue(new ReportParameter("UniName", clsGetSettings.Name), 1);
                p.SetValue(new ReportParameter("UniAdd", clsGetSettings.Address), 2);
                p.SetValue(new ReportParameter("UserName", ((clsUser)Session["User"]).Name), 3);
                p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + @"Images/" + Classes.clsGetSettings.UniversityLogo
), 4);
                ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());


                #endregion

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath+ "Eligibility\\Rdlc\\ViewElgStatus.rdlc";

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
            dtMultNomen.Columns.Add("PRN");

            DataRow dr = dtMultNomen.NewRow();
            dr["Course"] = lblPrvCourseNomenclature.Text;
            dr["PRN"] = lblPRNNomenclature.Text;

            dtMultNomen.Rows.Add(dr);
            return dtMultNomen;
        }

        #endregion

        protected void DGEligibility1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //#158787 : as per requirement from CRSU when student is Provisional Eligible the header text display
                //should be "Temp No"
                //if more than one Eligibility criteria is selected along with 'Provisional Eligible' then header text
                // display will be PRN Number/Temp No
                if (clsGetSettings.UniversityID == "637")
                {
                    if (Session["ElgCriteria"].ToString() == "5")
                    {
                        e.Row.Cells[3].Text = "Temp No";
                    }
                    else
                    {
                        e.Row.Cells[3].Text = "PRN Number/Temp No";
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (DGEligibility1.DataKeys[e.Row.RowIndex].Values[0].ToString() == "2")
                {
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "(Eligibility is already processed in some other " + lblCr.Text + " Part Term)";
                }
            }
        }
    }
}

