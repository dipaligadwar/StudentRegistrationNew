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
    public partial class ELGV2_rpt_GenerateRegistrationReceipt : System.Web.UI.Page
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
                lblPageHead.Text = "Generate Registration Receipt";
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
                //string criterion = string.Empty;
                //foreach (ListItem li in cblEligibilityStatus.Items)
                //{
                //    if (li.Selected)
                //    {
                //        criterion += li.Value + ",";
                //    }
                //}
                //criterion = criterion.TrimEnd(',');
                //Session["ElgCriteria"] = criterion;
               // Session["elgSort"] = rblSortStudent.SelectedValue;
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

                //if (Session["ElgCriteria"] != null)
                //{
                //    foreach (string c in Convert.ToString(Session["ElgCriteria"]).Split(','))
                //    {
                //        cblEligibilityStatus.Items.FindByValue(c).Selected = true;
                //    }
                //}

                //if (Session["ElgSort"] != null)
                //{
                //    rblSortStudent.SelectedValue = Convert.ToString(Session["ElgSort"]);
                //}
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

            if (user.UserTypeCode != "2")
            {
                hidInstID.Value = string.Empty;
                hidCollName.Value = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtFrom.Text))
            {
                hidFromDate.Value = txtFrom.Text;
                hidToDate.Value = txtTo.Text;
            }


            if (hidInstID.Value.Equals(string.Empty))
            {
                if (ddlCollegeName.SelectedIndex != 0 || Collcode.Text != string.Empty)
                {
                 
                    hidInstID.Value = ddlCollegeName.SelectedValue.Split('|')[0];
                    hidCollName.Value = ddlCollegeName.SelectedItem.Text;
           
                }
            }

            try
            {
                DataSet DS;
                DS = clsEligibilityDBAccess.GenerateRegistrationReceiptStudentsList(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["ElgBranchID"]), Convert.ToString(Session["Elgpk_CrPr_Details_ID"]), Convert.ToString(Session["Elgpk_CrPrCh_ID"]), hid_fk_AcademicYr_ID.Value, hidSortOption.Value, hidCriteria.Value, hidCriteriaNull.Value, hidCriteriaEligibilityRequired.Value, hidFromDate.Value, hidToDate.Value);//  hidStateID.Value, hidDistrictID.Value, hidTalukaID.Value, hidDOB.Value, hidFirstName.Value, hidLastName.Value, hidGender.Value);
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

                        divAllCriterion.Style.Add("display", "none");
                        lblnorecordfound.Style.Add("display", "none");

                    }

                    else
                    {
                        lblnorecordfound.Style.Add("display", "block");
                        lblnorecordfound.CssClass = "errorNote";
                        lblnorecordfound.Text = "No Record(s) found.";
                        lblnorecordfound.Style.Add("display", "block");
                        Session.Remove("ViewElg_dtData");
                    }
                }
                else
                {
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

            string sDateTime = DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            Warning[] warnings;
            string[] streamids;
            string mimeType, encoding, filenameExtension;
            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=ApplicatntCount_" + sDateTime + ".pdf");
            Response.BinaryWrite(bytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();

            //CreateReport();
            //Warning[] warnings;
            //string[] streams;
            //byte[] renderedBytes;
            //string mimeType, encoding, extension;
            ////string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>"
            ////  + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.6in</MarginTop>"
            ////  + "  <MarginLeft>0.6in</MarginLeft>" + "  <MarginRight>0.4in</MarginRight>"
            ////  + "  <MarginBottom>0.4in</MarginBottom>" + "</DeviceInfo>";
            //renderedBytes = ReportViewer1.LocalReport.Render("PDF", DeviceInfo, out mimeType, out encoding, out extension, out streams, out warnings);
            //Response.Buffer = true;
            //Response.Clear();
            //Response.ContentType = mimeType;
            //Response.AddHeader("content-disposition", "attachment; filename=EligibilityStatusReport.pdf");
            //Response.BinaryWrite(renderedBytes);
           // Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            //Response.End();

            #endregion
        }

        #endregion

        #region Excel Export

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            #region Report Viewer Approach

            CreateReport();

            string sDateTime = DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            Warning[] warnings;
            string[] streamids;
            string mimeType, encoding, filenameExtension;
            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=ApplicatntCount_" + sDateTime + ".pdf");
            Response.BinaryWrite(bytes);
            Response.Flush();

            //Warning[] warnings;
            //string[] streams;
            //byte[] renderedBytes;
            //string mimeType, encoding, extension;
            //string DeviceInfo = "<DeviceInfo>" + "  <OutputFormat>EXCEL</OutputFormat>" + "  <PageWidth>12.5in</PageWidth>"
            //  + "  <PageHeight>11.5in</PageHeight>" + "  <MarginTop>0.5in</MarginTop>"
            //  + "  <MarginLeft>0.5in</MarginLeft>" + "  <MarginRight>0.5in</MarginRight>"
            //  + "  <MarginBottom>0.5in</MarginBottom>" + "</DeviceInfo>";
            //renderedBytes = ReportViewer1.LocalReport.Render("Excel", DeviceInfo, out mimeType, out encoding, out extension, out streams, out warnings);
            //Response.Buffer = true;
            //Response.Clear();
            //Response.ContentType = mimeType;
            //Response.AddHeader("content-disposition", "attachment; filename=EligStatusReport.xls");
            //Response.BinaryWrite(renderedBytes);
            //Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();

            #endregion

        }

        #endregion

        #region CreateReport Region

        public void CreateReport()
        {
            try
            {
                MemorizeInSession();
                #region Assign DataSet and Report Data Sourse Details
                if (user.UserTypeCode != "2")
                {
                    hidInstID.Value = string.Empty;
                    hidCollName.Value = string.Empty;
                }
                if (!string.IsNullOrEmpty(txtFrom.Text))
                {
                    hidFromDate.Value = txtFrom.Text;
                    hidToDate.Value = txtTo.Text;
                }


                if (hidInstID.Value.Equals(string.Empty))
                {
                    if (ddlCollegeName.SelectedIndex != 0 || Collcode.Text != string.Empty)
                    {

                        hidInstID.Value = ddlCollegeName.SelectedValue.Split('|')[0];
                        hidCollName.Value = ddlCollegeName.SelectedItem.Text;

                    }
                }

                DataSet DS;
                DS = clsEligibilityDBAccess.GenerateRegistrationReceiptStudentsList(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["ElgBranchID"]), Convert.ToString(Session["Elgpk_CrPr_Details_ID"]), Convert.ToString(Session["Elgpk_CrPrCh_ID"]), hid_fk_AcademicYr_ID.Value, hidSortOption.Value, hidCriteria.Value, hidCriteriaNull.Value, hidCriteriaEligibilityRequired.Value, hidFromDate.Value, hidToDate.Value);



                if (DS != null && DS.Tables.Count > 0 && DS.Tables[0] != null && DS.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource ReportDetailsDS1 = new ReportDataSource("DataSet1", DS.Tables[0]);
                    ReportParameter[] p = new ReportParameter[1];

                    p.SetValue(new ReportParameter("Logo", Classes.clsGetSettings.SitePath + @"Images/" + Classes.clsGetSettings.UniversityLogo), 0);
                    ReportDataSource MultNomDS = new ReportDataSource("dsDisc_dtMultiNom", MultinomenClature());


                #endregion

                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath + "Eligibility\\Rdlc\\GenerateRegistrationReceipt.rdlc";

                    #region Adding DataSet and Report Data Sourse to ReportViewer DataSources

                    ReportViewer1.LocalReport.DataSources.Add(ReportDetailsDS1);
                    ReportViewer1.LocalReport.DataSources.Add(MultNomDS);
                    ReportViewer1.LocalReport.SetParameters(p);

                    #endregion

                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                {
                    lblnorecordfound.Visible = true;
                    lblnorecordfound.Text = "No Record found";
                }



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

    }
}



//       protected void ExptToExl_Click(object sender, EventArgs e)
//        {
//           if (BindReport())
//            {
//                GenerateReport("EXCEL",".xls");
//            }
//        }
        

//        protected void ExptToPDF_Click(object sender, EventArgs e)
//        {
//               if (BindReport())
//                {
//                    GenerateReport("PDF", ".pdf");
//                }

//        }
//       private void GenerateReport(string Format, string extension)
//        {
//            string sDateTime = DateTime.Now.ToString("ddMMyyyyhhmmsstt");
//            Warning[] warnings;
//            string[] streamids;
//            string mimeType, encoding, filenameExtension;
//            byte[] bytes = rptViewer.LocalReport.Render(Format, null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
//            Response.Buffer = true;
//            Response.Clear();
//            Response.ContentType = mimeType;
//            Response.AddHeader("content-disposition", "attachment; filename=ApplicatntCount_" + sDateTime + extension);
//            Response.BinaryWrite(bytes);
//            Response.Flush();
//            Response.End();
//        }
//        private bool BindReport()
//        {
//            oHt = CreateHashTable();

//            using (oDt = oBranchChange.rptGetBranchChangeDetails(oHt))
//           {
//            if (oDt != null && oDt.Rows.Count > 0)
//                {
//            rptViewer.LocalReport.DataSources.Clear();
//            rptViewer.LocalReport.ReportPath = clsGetSettings.PhysicalSitePath + "Admissions\\rptGetBranchChangeDetails.rdlc";
//            ReportDataSource oRds = new ReportDataSource("DsBranchChangeSetails", oDt);
//            ReportParameter[] param = new ReportParameter[7];
//            param[0] = new ReportParameter("UniName", clsGetSettings.UniversityName.ToString(), true);
//            param[1] = new ReportParameter("UniLogo", clsGetSettings.SitePath + "Images/" + clsGetSettings.Logo, true);
//            param[2] = new ReportParameter("UniSitePath", clsGetSettings.SitePath.ToString(), true);
//            param[3] = new ReportParameter("UniversityCity", clsGetSettings.UniversityCity, true);
//            param[4] = new ReportParameter("userName", oUser.Name, true);
//            param[5] = new ReportParameter("Address", clsGetSettings.Address, true);
//            string sCriteria = "Branch Change details for " + oUser.Name; ;
//            param[6] = new ReportParameter("ReportCriteria", sCriteria, true);
//            ReportDataSource MultNomDS = new ReportDataSource("dsMultiNom", MultinomenClature());
//            rptViewer.LocalReport.EnableExternalImages = true;
//            rptViewer.LocalReport.SetParameters(param);
//            rptViewer.LocalReport.DataSources.Add(oRds);
//            rptViewer.LocalReport.DataSources.Add(MultNomDS);
//            rptViewer.LocalReport.Refresh();
//            return true;
//            }
//           else
//                {
//                    lblErrorMsg.Visible = true;
//                    return false;
//                }
//           }
//        }

//         public DataTable MultinomenClature()
//        {
//            DataTable dtMultNomen = new DataTable();
//            dtMultNomen.Columns.Add("Course");
//            dtMultNomen.Columns.Add("PRN");
//            dtMultNomen.Columns.Add("College");
//            dtMultNomen.Columns.Add("Paper");


//            DataRow dr = dtMultNomen.NewRow();
//            dr["Course"] = lblCourse.Text;
//            dr["PRN"] = lblPRN.Text;
//            dr["College"] = lblCollege.Text;
//            dr["Paper"] = lblPaper.Text;
//            dtMultNomen.Rows.Add(dr);
//            return dtMultNomen;
//        }

       
//         protected override void InitializeCulture()
//         {
//             System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
//             Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
//         }

        

//        <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
//    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
//       <div>
//        <asp:Label Text="No Record Found" ID="lblErrorMsg" runat="server" Visible="false" CssClass="errorNote" />
//    </div>
//       <div style="margin: 10px;">
//        <asp:Button ID="ExptToExl" CssClass="clButtonHolder" runat="server" Text="Export To Excel"
//            OnClick="ExptToExl_Click" />
//        <asp:Button ID="ExptToPDF" CssClass="clButtonHolder" runat="server" Text="Export To PDF"
//            OnClick="ExptToPDF_Click" />
//        <div id="DivReportViewerDesign" runat="server" style="display: none;">
//        <rsweb:ReportViewer ID="rptViewer" Height="10px" runat="server" Font-Names="Verdana" Font-Size="8pt"
//                    AsyncRendering="false" >
//                </rsweb:ReportViewer>
//    </div>
//    </div>
//<asp:Label ID="lblCourse" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCourseResource1"></asp:Label>
//    <asp:Label ID="lblPRN" runat="server" Text="PRN Numbner" Style="display: none" meta:resourcekey="lblPRNResource1"></asp:Label>
//    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
//    <asp:Label ID="lblPaper" runat="server" Text="Paper" Style="display: none" meta:resourcekey="lblPaperResource1"></asp:Label>

