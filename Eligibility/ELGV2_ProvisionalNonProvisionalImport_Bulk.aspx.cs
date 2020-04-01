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
	public partial class ELGV2_ProvisionalNonProvisionalImport_Bulk : System.Web.UI.Page
	{
        #region Variables

        clsCommon Common = new clsCommon();
        CourseRepository crRepository = new CourseRepository();
        DataTable dt1 = new DataTable();
        DataTable oDT;
        clsUser user;
        private string[] IDs_List = new string[3];
        InstituteRepository oInstituteRepository = new InstituteRepository();

        #endregion
		protected void Page_Load(object sender, EventArgs e)
		{
			user = (clsUser)Session["user"];
            
            if (!IsPostBack)
            { 
                lblPageHead.Text = "Provisional Non Provisional Bulk Importing";
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                ViewState["AcademicYear"] = dt;
                Common.fillDropDown(ddlAcademicYr, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                ddlAcademicYr.SelectedIndex = 0;
                hid_AcademicYear.Value = ddlAcademicYr.SelectedItem.Text;
                hid_AcademicYearFrom.Value = dt.Rows[ddlAcademicYr.SelectedIndex]["Academic_StartDate"].ToString();
                hid_AcademicYearTo.Value = dt.Rows[ddlAcademicYr.SelectedIndex]["Academic_EndDate"].ToString();
                FetchUniversityWiseFacultyList(ddlFacDesc);
            }

            hid_AcademicYear.Value = ddlAcademicYr.SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ddlAcademicYr.SelectedValue.ToString();
		}
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

        #region MemorizeInSession

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

                hidBrnID.Value = Convert.ToString(ddlCrBrnDesc.SelectedItem.Value);
                hidCrPrDetailsID.Value = Convert.ToString(ddlCrPrDetailsDesc.SelectedItem.Value);
                hidCrPrChID.Value = Convert.ToString(ddlCrPrChDesc.SelectedItem.Value);
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
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        #endregion

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            MemorizeInSession();
            Server.Transfer("ELGV2_ProvisionalNonProvisionalImport_Bulk__1.aspx");
        }
        
	}
}