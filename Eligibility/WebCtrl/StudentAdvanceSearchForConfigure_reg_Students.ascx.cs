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
using System.Globalization;
using System.Threading;
using System.Resources;
using StudentRegistration.Eligibility.ElgClasses;
using System.Text.RegularExpressions;

namespace StudentRegistration.Eligibility.WebCtrl
{
    public partial class StudentAdvanceSearchForConfigure_reg_Students : System.Web.UI.UserControl
    {
        #region Declaration of Variables

        protected System.Web.UI.HtmlControls.HtmlGenericControl CollegeGrid;
        protected System.Web.UI.HtmlControls.HtmlGenericControl divStudentList;
        protected System.Web.UI.HtmlControls.HtmlInputHidden hidCrMoLrnID;
        private string qstrNavigate;
        private string strUrl;
        private string gridType;
        DataSet dsDistricts = new DataSet();
        clsCommon Common = new clsCommon();
        clsCommon CommonAcYr = new clsCommon();
        clsCache clsCache = new clsCache();
        private string AcdyearID;
        private string AcdyearText;
        DataSet ds;
        string InstituteID = null;
        string PRNumber = null;
        DataTable dt;
        InstituteRepository InstRep = new InstituteRepository();

        #endregion

        #region Properties
        public string QstrNavigate
        {
            set
            {
                qstrNavigate = value;
            }
        }
        public string StrUrl
        {
            set
            {
                strUrl = value;
            }
            get
            {
                return strUrl;
            }
        }
        public string GridType
        {
            set
            {
                gridType = value;
            }
            get
            {
                return gridType;
            }
        }

        public string AcdYearID
        {
            get
            {
                return hid_fk_AcademicYr_ID.Value;
            }
            set
            {
                hid_fk_AcademicYr_ID.Value = value;
            }
        }
        public string AcdYearText
        {
            get
            {
                return hidAcademicYrText.Value;
            }
            set
            {
                hidAcademicYrText.Value = value;
            }
        }
        public string HidSearchType
        {
            get
            {
                return hidSearchType.Value;
            }
            set
            {
                hidSearchType.Value = value;
            }
        }
        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            clsCache.NoCache();

            Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods), this.Page);
            Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent), this.Page);

            dgElgRegular1.Style.Add("display", "none");
            dgRegPendingStudents1.Style.Add("display", "none");
            lblGridName.Style.Remove("display");
            lblGridName.Style.Add("display", "none");
            divDGNote.Style.Remove("display");
            divDGNote.Style.Add("display", "none");
            if (!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[26];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidFacID;
                hid[3] = hidCrID;
                hid[4] = hidMoLrnID;
                hid[5] = hidPtrnID;
                hid[6] = hidBrnID;
                hid[7] = hidCrPrDetailsID;
                hid[8] = hidElgFormNo;
                hid[9] = hidpkYear;
                hid[10] = hidpkStudentID;
                hid[11] = hidDOB;
                hid[12] = hidFirstName;
                hid[13] = hidLastName;
                hid[14] = hidGender;
                hid[15] = hidPRN;
                hid[16] = hid_fk_AcademicYr_ID;
                hid[17] = hidAcademicYrText;
                //hid[3] = hidCrMoLrnPtrnID;
                hid[18] = hidIsBlank;
                hid[19] = hidFacName;
                hid[20] = hidCrName;
                hid[21] = hidMOLName;
                hid[22] = hidPattern;
                hid[23] = hidBrName;
                hid[24] = hidSearchType;
                hid[25] = hidAppFormNo;
                Common.setHiddenVariables(ref hid);
                divSimpleSearch.Style.Add("display", "block");
                lblAdvSearch.InnerText = "Advanced Search";

                if (Page.PreviousPage != null)
                {
                    ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

                    if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                    {
                        hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                    }
                }

                divSimpleSearch.Style.Add("display", "block");
                dt = clsCollegeAdmissionReports.GetAcademicYear();
                CommonAcYr.fillDropDown(ddlAcademicYear, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                btnSimpleSearch.Attributes.Add("onclick", "return ChkValidation();");
                lblGrid.Attributes.Add("style", "display:none");
                lblErrorMsg.Attributes.Add("style", "display:none");
                divError.Attributes.Add("style", "display:none");
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                try
                {
                    hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
                }
                catch
                {
                    hidIsPRNValidationRequired.Value = "N";
                }

                #region Back Navigation
                if (Page.PreviousPage != null)
                {
                    if (qstrNavigate == "back")
                    {
                        //CommonAcYr.fillDropDown(ddlAcademicYear, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");

                        ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");

                        if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                        {
                            hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                            hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                            hidFacID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkFacID")).Value;
                            hidCrID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkCrID")).Value;
                            hidMoLrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkMoLrnID")).Value;
                            hidPtrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkPtrnID")).Value;
                            hidBrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkBrnID")).Value;
                            hidCrPrDetailsID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkCrPrDetailsID")).Value;
                            hidElgFormNo.Value = ((HtmlInputHidden)Cntp.FindControl("hidElgFormNo")).Value;
                            hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)Cntp.FindControl("hid_fk_AcademicYr_ID")).Value;
                            hidAcademicYrText.Value = ((HtmlInputHidden)Cntp.FindControl("hidAcademicYrText")).Value;
                            hidPRN.Value = ((HtmlInputHidden)Cntp.FindControl("hidPRN")).Value;
                            hidFacName.Value = ((HtmlInputHidden)Cntp.FindControl("hidFacName")).Value;
                            hidCrName.Value = ((HtmlInputHidden)Cntp.FindControl("hidCrName")).Value;
                            hidMOLName.Value = ((HtmlInputHidden)Cntp.FindControl("hidMOLName")).Value;
                            hidPattern.Value = ((HtmlInputHidden)Cntp.FindControl("hidPattern")).Value;
                            hidBrName.Value = ((HtmlInputHidden)Cntp.FindControl("hidBrName")).Value;
                            hidAcYrName.Value = ((HtmlInputHidden)Cntp.FindControl("hidAcYrName")).Value;
                            hidIsBlank.Value = ((HtmlInputHidden)Cntp.FindControl("hidIsBlank")).Value;
                            hidBranchName.Value = ((HtmlInputHidden)Cntp.FindControl("hidBranchName")).Value;
                            //txtElgFormNo.Text = hidElgFormNo.Value;
                            //txtPRN.Text = hidPRN.Value;
                        }


                        if (Request.QueryString["Search"] == "Adv")
                        {
                            lblAdvSearch.InnerText = "Simple Search";
                            txtDOB.Text = hidDOB.Value;
                            for (int i = 0; i < ddlGender.Items.Count; i++)
                            {
                                if (ddlGender.Items[i].Value == hidGender.Value)
                                    ddlGender.SelectedIndex = i;
                            }
                            txtLastName.Text = hidLastName.Value;
                            txtFirstName.Text = hidFirstName.Value;

                            ddlAcademicYear.Items.Remove(ddlAcademicYear.Items.FindByText(hidAcademicYrText.Value));
                            ddlAcademicYear.SelectedItem.Text = hidAcademicYrText.Value;
                            ddlAcademicYear.SelectedItem.Value = hid_fk_AcademicYr_ID.Value;

                            DivAdvanceSearch.Attributes.Add("style", "display:block");
                            divSimpleSearch.Style.Add("display", "none");

                            if (gridType == "IA")
                            {

                                hidElgFormNo.Value = "";
                                fnDisplayIAGrid();
                            }
                            if (gridType == "Reg")
                            {

                                hidpkYear.Value = "";
                                hidpkStudentID.Value = "";
                                fnDisplayRegGrid();
                            }

                        }

                        else if (Request.QueryString["Search"] == "Simple")
                        {
                            lblAdvSearch.InnerText = "Advanced Search";
                            if (hidIsBlank.Value != "")
                            {
                                txtElgFormNo.Text = hidElgFormNo.Value;
                            }
                            else
                            {
                                txtPRN.Text = hidPRN.Value;
                            }

                            fnFetchStudent();
                        }
                        DataTable dtAY = clsCollegeAdmissionReports.GetAcademicYear();
                        CommonAcYr.fillDropDown(ddlAcademicYear, dtAY, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                        ListItem selAcYr = ddlAcademicYear.Items.FindByText(hidAcYrName.Value);
                        ddlAcademicYear.SelectedIndex = ddlAcademicYear.Items.IndexOf(selAcYr);
                    }
                }
                else
                {

                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                    FillFaculty();
                    if (Request.QueryString["Search"] == "Adv" || HidSearchType.Equals("Adv"))
                    {
                        DivAdvanceSearch.Attributes.Add("style", "display:block");
                        divSimpleSearch.Style.Add("display", "none");
                        lblAdvSearch.InnerText = "Simple Search";
                    }
                    else if (Request.QueryString["Search"] == "Simple" || HidSearchType.Equals("Simple"))
                    {
                        DivAdvanceSearch.Attributes.Add("style", "display:none");
                        divSimpleSearch.Style.Add("display", "block");
                        lblAdvSearch.InnerText = "Advanced Search";
                    }
                }

                #endregion
            }

            FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value);

        }

        #endregion

        #region Display Grids

        private void fnDisplayIAGrid() 
        {
            DataView dv = new DataView();
            DataSet ds = new DataSet();
            try
            {
                //By Shivani  ds = Eligibility.clsEligibilityDBAccess.Fetch_IA_Student_List_Configure(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value,hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value,hidDOB.Value, hidLastName.Value,hidFirstName.Value, hidGender.Value);
            }
            catch (Exception e)
            {
                throw (e);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                dv.Table = ds.Tables[0];
                if (ViewState["SortExpression"] != null)
                {
                    dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();
                }
                dgElgRegular1.DataSource = dv;// ds;
                try
                {
                    dgElgRegular1.DataBind();
                }
                catch
                {
                    dgElgRegular1.PageIndex = 0;
                    dgElgRegular1.DataBind();
                }
                dgElgRegular1.Visible = true;
                tblDGElgRegular.Style.Remove("display");
                tblDGElgRegular.Style.Add("display", "block");
                lblGridName.Text = "List of uploaded students whose Eligiblity is yet to be processed.";
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");
                divDGNote.Style.Remove("display");
                divDGNote.Style.Add("display", "block");

            }
            else
            {
                dgElgRegular1.Visible = false;
                tblDGElgRegular.Style.Remove("display");
                tblDGElgRegular.Style.Add("display", "none");
                lblGridName.Text = "The " + lblCollege.Text + "(s) of Student(s) searched for, have not Uploaded the Admitted Students Data yet...";
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");
                divDGNote.Style.Remove("display");
                divDGNote.Style.Add("display", "none");
            }

            ds.Clear();
            ds.Dispose();
            ds = null;


        }

        private void fnDisplayRegGrid()
        {
            DataSet ds = new DataSet();
            DataView dv = new DataView();
            if (AcdYearID.Equals("0"))
            {
                hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.ToString();
                hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;
            }

            try
            {
                //ds = Eligibility.clsEligibilityDBAccess.Fetch_Pending_Reg_Student_List(Classes.clsGetSettings.UniversityID.ToString(), Session["SInst_Type"].ToString(), Session["SInst_Name"].ToString(), Session["SState_ID"].ToString(), Session["SDistrict_ID"].ToString(), Session["STehsil_ID"].ToString(), Session["FacultyID"].ToString(), Session["CourseID"].ToString(), Session["CrMoLrnPtrnID"].ToString(), Session["CoursePartID"].ToString(), Session["DOB"].ToString(), Session["LastName"].ToString(), Session["FirstName"].ToString(), Session["Gender"].ToString());
                string str = Page.ToString();
                if (str == "ASP.eligibility_elgv2_resolvepending_reg_students__1_aspx")
                {
                    ds = Eligibility.clsEligibilityDBAccess.Fetch_Pending_Reg_Student_List_Resolve_RegStu(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hid_fk_AcademicYr_ID.Value);
                    lblGridName.Text = "List of students whose Eligiblity is kept pending.";
                }
                else if (str == "ASP.eligibility_elgv2_resolveprovisional_reg_students__1_aspx")
                {
                    ds = Eligibility.clsEligibilityDBAccess.Fetch_ProvisionallyEligible_Reg_Student_List_Resolve_RegStu(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hid_fk_AcademicYr_ID.Value);
                    lblGridName.Text = "List of students whose Eligiblity is kept provisional.";
                    lblGrid.Attributes.Add("style", "display:none");
                }

                ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
                if (hidFacName.Value.Equals(string.Empty))
                {
                    hidFacName.Value = ddlFaculty.SelectedItem.Text;
                    hidCrName.Value = ddlCourse.SelectedItem.Text;
                    hidMOLName.Value = ddlMoLrn.SelectedItem.Text;
                    hidPattern.Value = ddlCrPtrn.SelectedItem.Text;
                    hidBrName.Value = ddlBranch.SelectedItem.Text;
                    hidAcYrName.Value = ddlAcademicYear.SelectedItem.Text;
                }

                ((Label)Cntph1.FindControl("lblSubHeader")).Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value) + " - " + hidFacName.Value + " - " + hidCrName.Value + " - " + hidMOLName.Value + " - " + hidPattern.Value + " - " + hidBrName.Value + " [Academic Year " + hidAcYrName.Value + "]";

            }
            catch (Exception e)
            {
                throw (e);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgRegPendingStudents1.DataSource = ds;
                /*try
                {
                    dgRegPendingStudents1.DataBind();
                }
                catch
                {
                    dgRegPendingStudents1.PageIndex = 0;
                    dgRegPendingStudents1.DataBind();
                }*/

                dv.Table = ds.Tables[0];
                if (ViewState["SortExpression"] != null)
                {
                    dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();
                }
                dgRegPendingStudents1.DataSource = dv;// ds;
                try
                {
                    dgRegPendingStudents1.DataBind();
                }
                catch
                {
                    dgRegPendingStudents1.PageIndex = 0;
                    dgRegPendingStudents1.DataBind();
                }

                dgRegPendingStudents1.Attributes.Add("style", "display:block");
                //dgRegPendingStudents1.Visible = true;
                //tblDGRegPendingStudents.Style.Remove("display");
                //tblDGRegPendingStudents.Style.Add("display", "block");
                tblDGRegPendingStudents.Attributes.Add("style", "display:block");
                //tblDGRegPendingStudents.Visible = true;
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");
               // divDGNote.Style.Remove("display");
                //divDGNote.Style.Add("display", "block");
                lblGrid.Text = "* Please click on the Student Name to select the Student whose Pending Eligibility for a particular " + lblCr.Text.ToLower() + " is to be Resolved";
                lblGrid.Attributes.Add("style", "display:block");


            }
            else
            {
                dgRegPendingStudents1.Style.Add("display", "none");
                tblDGRegPendingStudents.Style.Remove("display");
                tblDGRegPendingStudents.Style.Add("display", "none");
                lblGridName.Text = "There are no Students satisfying the above search criteria whose Eligibility is kept Pending...";
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");
                divDGNote.Style.Remove("display");
                divDGNote.Style.Add("display", "none");
                lblGrid.Attributes.Add("style", "display:none");

            }

            if ((Request.QueryString["Search"] == "Adv" || HidSearchType.Equals("Adv")))
            {
                divSimpleSearch.Attributes.Add("style", "display:none");
                DivAdvanceSearch.Attributes.Add("style", "display:block");
            }

            ds.Clear();
            ds.Dispose();
            ds = null;

        }

        #endregion

        #region Fill Dropdowns
        public void FillFaculty()
        {
            DataTable oDT = new DataTable();
            if (ddlCourse.SelectedIndex == 0)
            {
                try
                {
                    // ds = Eligibility.elgDBAccess.GetAllFaculties(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()));
                    oDT = InstRep.AssignedConfirmedFaculties(hidUniID.Value, hidInstID.Value);
                    /*DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = Convert.ToString("---Select---");
                    dr[1] = Convert.ToInt64(0);
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    ddlFaculty.DataSource = ds.Tables[0];
                    ddlFaculty.DataTextField = "Fac_Desc";
                    ddlFaculty.DataValueField = "pk_Fac_ID";
                    ddlFaculty.DataBind();*/
                    Common.fillDropDown(ddlFaculty, oDT, "", "Fac_Desc", "pk_Fac_ID", "---- Select ----");

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }


        }

        public void FillFacultyWiseCourseCoursePart(string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID)
        {
            clsCommon common = new clsCommon();
            //DataSet ds;
            DataTable dt;
            ddlFaculty.Items.Clear();

            try
            {

                //ds = Eligibility.elgDBAccess.GetAllFaculties(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()));
                //dt = ds.Tables[0];
                dt = InstRep.AssignedConfirmedFaculties(hidUniID.Value, hidInstID.Value);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            Common.fillDropDown(ddlFaculty, dt, FacID, "Fac_Desc", "pk_Fac_ID", "--- Select ---");
            ddlCourse.Items.Clear();

            try
            {
                //ds = Eligibility.elgDBAccess.selFacultyWiseAllCourses(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(FacID));
                //dt = ds.Tables[0];
                dt = InstRep.AssignedConfirmedCourses(hidUniID.Value, hidInstID.Value, FacID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            common.fillDropDown(ddlCourse, dt, CrID, "Cr_Desc", "pk_Cr_ID", "--- Select ---");
            ddlMoLrn.Items.Clear();

            try
            {
                //ds = Eligibility.elgDBAccess.selAllCoursePart(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(FacID), Convert.ToInt32(CrID));
                //dt = ds.Tables[0];
                dt = InstRep.AssignedConfirmedModeOfLearning(hidUniID.Value, hidInstID.Value, FacID, CrID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            common.fillDropDown(ddlMoLrn, dt, MoLrnID, "MoLrn_Type", "pk_MoLrn_ID", "--- Select ---");
            ddlCrPtrn.Items.Clear();

            try
            {
                dt = InstRep.AssignedConfirmedCoursePatterns(hidUniID.Value, hidInstID.Value, FacID, CrID, MoLrnID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            common.fillDropDown(ddlCrPtrn, dt, PtrnID, "text", "value", "--- Select ---");
            ddlBranch.Items.Clear();

            try
            {
                dt = InstRep.AssignedConfirmedBranches(hidUniID.Value, hidInstID.Value, FacID, CrID, MoLrnID, PtrnID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (hidBranchName.Value == "No Branch")
            {
                ddlBranch.Items.Insert(0, "No Branch");
            }
            else
            {
                common.fillDropDown(ddlBranch, dt, BrnID, "Text", "Value", "--- Select ---");
            }
           
            // ddlCoursePart.Items.Clear();

            //try
            //{
            //    dt = InstRepV2.AssignedConfirmedCourseParts(hidUniID.Value, hidInstID.Value, FacID, CrID, MoLrnID, PtrnID, BrnID);
            //}

            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            // common.fillDropDown(ddlCoursePart, dt, CrPrDetailsID, "CrPr_Abbr", "pk_CrPr_Details_ID", "---- Select ----");

            if (common != null) common = null;
            // ds.Dispose();
            dt.Dispose();
        }

        #endregion

        #region Advanced Search Button Click

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblAdvSearch.InnerText = "Simple Search";
            divErrorMsg.Attributes.Add("style", "display:none");
            lblErrorMsg.Attributes.Add("style", "display:none");
            hidFacName.Value = string.Empty;
            hidCrName.Value = string.Empty;
            hidMOLName.Value = string.Empty;
            hidBrName.Value = string.Empty;
            hidPattern.Value = string.Empty;
            hidAcYrName.Value = string.Empty;
            string dob = txtDOB.Text.Trim();
            if (dob != "")
            {
                string[] arr = new string[3];
                arr = dob.Split('/');
                dob = arr[1] + '/' + arr[0] + '/' + arr[2];
            }

            hidDOB.Value = dob;
            hidGender.Value = ddlGender.SelectedItem.Value;
            hidLastName.Value = txtLastName.Text.Trim();
            hidFirstName.Value = txtFirstName.Text.Trim();

            hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;

            if (gridType == "IA")
            {
                dgElgRegular1.PageIndex = 0;
                fnDisplayIAGrid();
            }
            if (gridType == "Reg")
            {
                dgRegPendingStudents1.PageIndex = 0;
                fnDisplayRegGrid();
            }

        }

        #endregion

        #region dgElgRegular

        /*      protected void dgElgRegular_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {
                //Session["ElgFormNo"] = e.Item.Cells[1].Text.Trim();
                //Session["pk_CrMoLrnPtrn_ID"]=e.Item.Cells[6].Text.Trim();
                hidElgFormNo.Value = e.Item.Cells[1].Text.Trim();
                //By Shivani hidCrMoLrnPtrnID.Value = e.Item.Cells[6].Text.Trim();
                Server.Transfer(strUrl);
            }

        }
        */
        /*    protected void dgElgRegular_ItemDataBound(object sender, DataGridItemEventArgs e)
            {
                if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
                {
                    e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgElgRegular.CurrentPageIndex * 10) + 1);
                }
            }*/

        /*      protected void dgElgRegular_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
              {
                  dgElgRegular.CurrentPageIndex = e.NewPageIndex;
                  fnDisplayIAGrid();
              }*/

        /*      protected void dgElgRegular_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
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

                  fnDisplayIAGrid();
              }
              */
        #endregion

        #region dgRegPendingStudents

        /*      protected void dgRegPendingStudents_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "PendingStudentDetails")
            {
                //Commented by Liwia
                // 				Session["ElgFormNo"] = e.Item.Cells[1].Text.Trim();

                //     Session["pk_CrMoLrnPtrn_ID"]=e.Item.Cells[8].Text.Trim();
                //added by liwia
                //     hidUniID.Value=ConfigurationSettings.AppSettings["UniversityID"].ToString();


                //Session["pk_Year"] = e.Item.Cells[6].Text.Trim();       Commented By Jyotsna on 29/09/2007
                //Session["pk_Student_ID"] = e.Item.Cells[7].Text.Trim();


                hidElgFormNo.Value = e.Item.Cells[1].Text.Trim();
                hidPRN.Value = e.Item.Cells[3].Text.Trim(); 
                hidpkYear.Value = e.Item.Cells[7].Text.Trim();
                hidpkStudentID.Value = e.Item.Cells[8].Text.Trim();
                hidFacID.Value = e.Item.Cells[9].Text.Trim();
                hidCrID.Value = e.Item.Cells[10].Text.Trim();
                hidMoLrnID.Value = e.Item.Cells[11].Text.Trim();
                hidPtrnID.Value = e.Item.Cells[12].Text.Trim();
                hidBrnID.Value = e.Item.Cells[13].Text.Trim();
                hidCrPrDetailsID.Value = e.Item.Cells[14].Text.Trim();

                //Common.setHiddenVariables(ref hid);
                //end
                Server.Transfer(strUrl);
            }
        }*/

        /*       protected void dgRegPendingStudents_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
               {
                   dgRegPendingStudents.CurrentPageIndex = e.NewPageIndex;
                   fnDisplayRegGrid();
               }*/

        /*      protected void dgRegPendingStudents_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
              {
                  if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
                  {
                      e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgRegPendingStudents.CurrentPageIndex * 10) + 1);

                  }
              }*/
        #endregion

        #region dgElgRegular1 GridView Events

        protected void dgElgRegular1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
            }
        }

        protected void dgElgRegular1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgElgRegular1.Rows[index];
                hidAppFormNo.Value = row.Cells[1].Text.Trim();
                hidElgFormNo.Value = row.Cells[2].Text.Trim();
                Server.Transfer(strUrl);
            }

        }

        protected void dgElgRegular1_Sorting(object sender, GridViewSortEventArgs e)
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

            fnDisplayIAGrid();
        }

        protected void dgElgRegular1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgElgRegular1.PageIndex = e.NewPageIndex;
            //dgElgRegular1.DataBind();
            fnDisplayIAGrid();
        }

        #endregion

        #region dgRegPendingStudents1 Gridview Events

        protected void dgRegPendingStudents1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
            }

        }

        protected void dgRegPendingStudents1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PendingStudentDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgRegPendingStudents1.Rows[index];

                hidElgFormNo.Value = row.Cells[2].Text.Trim();
                hidPRN.Value = row.Cells[4].Text.Trim();
                hidpkYear.Value = row.Cells[8].Text.Trim();
                hidpkStudentID.Value = row.Cells[9].Text.Trim();
                hidFacID.Value = row.Cells[10].Text.Trim();
                hidCrID.Value = row.Cells[11].Text.Trim();
                hidMoLrnID.Value = row.Cells[12].Text.Trim();
                hidPtrnID.Value = row.Cells[13].Text.Trim();
                hidBrnID.Value = row.Cells[14].Text.Trim();
                hidCrPrDetailsID.Value = row.Cells[15].Text.Trim();
                hidFacName.Value = ddlFaculty.SelectedItem.Text;
                hidCrName.Value = ddlCourse.SelectedItem.Text;
                hidMOLName.Value = ddlMoLrn.SelectedItem.Text;
                hidPattern.Value = ddlCrPtrn.SelectedItem.Text;
                hidBrName.Value = ddlBranch.SelectedItem.Text;
                hidAcYrName.Value = ddlAcademicYear.SelectedItem.Text;
                Server.Transfer(strUrl, true);
            }
        }

        protected void dgRegPendingStudents1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgRegPendingStudents1.PageIndex = e.NewPageIndex;
            //dgRegPendingStudents1.DataBind();
            fnDisplayRegGrid();
        }

        protected void dgRegPendingStudents1_Sorting(object sender, GridViewSortEventArgs e)
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

            fnDisplayRegGrid();

        }

        //public void btnAcYr_Click(object sender, EventArgs e)
        //{
        //    hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.ToString();
        //    hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;

        //    if (hid_fk_AcademicYr_ID.Value == "0")
        //    {
        //        string strScript = "<script language='JavaScript'>alert('Please Select Academic Year')</script>";
        //        Page.RegisterStartupScript("PopUp", strScript);
        //        divAcademicYr.Style.Add("display", "block");
        //        tblSelect.Style.Add("display", "none");
        //        //trbtnSearch.Style.Add("display", "none");
        //        btnAcYr.Attributes.Add("onclick", "return fnClearSearchCriteria();");
        //    }
        //    else
        //    {
        //        divAcademicYr.Style.Add("display", "none");
        //        tblSelect.Style.Add("display", "block");
        //        //trbtnSearch.Style.Add("display", "block");
        //        btnAcYr.Attributes.Add("onclick", "return fnClearSearchCriteria();");

        //    }
        //}

        #endregion

        #region Button Simple Search Click

        protected void btnSimpleSearch_Click(object sender, EventArgs e)
        {
            lblAdvSearch.InnerText = "Advanced Search";
            ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            ((Label)Cntph1.FindControl("lblSubHeader")).Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);

            //lblSubmitMessage.Attributes.Add("style", "display:none");
            divErrorMsg.Attributes.Add("style", "display:none");
            lblError.Attributes.Add("style", "display:none");
            divErrorMsg.Attributes.Add("style", "display:none");
            lblErrorMsg.Attributes.Add("style", "display:none");
            hidSearchType.Value = "Simple";

            string ElgFormNo;
            if (txtElgFormNo.Text != "")
            {
                ElgFormNo = txtElgFormNo.Text.Trim();
                hidIsBlank.Value = ElgFormNo;

            }
            else
            {
                ElgFormNo = "0-0-0-0";
                hidIsBlank.Value = "";

            }

            int cnt = 0;
            string str = ElgFormNo;
            int pos = str.IndexOf('-');
            string[] arr = new string[] { "0", "0", "0", "0" };
            Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");

            if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                PRNumber = txtPRN.Text.Trim();
            InstituteID = hidInstID.Value;

            while (pos != -1)
            {
                str = str.Substring(pos + 1);
                pos = str.IndexOf('-');
                cnt++;

            }

            if (cnt == 3)
            {
                arr = new string[4];
                arr = ElgFormNo.Split('-');   //new  UniID = arr[0], InstID = arr[1],Year = arr[2], StudID = arr[3]
                for (int i = 0; i < 4; i++)
                {
                    if (arr[i] == "")
                        arr[i] = "0";
                }
                try
                {
                    #region all search for pending students
                    ds = clsEligibilityDBAccess.Check_Reg_Pending_Student_Exists_RegStu(arr[0], arr[1], arr[2], arr[3], txtPRN.Text, hidInstID.Value, txtApplicationFrmNo.Text.Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "3")    // Pending Eligibility
                        {
                            hidElgFormNo.Value = txtElgFormNo.Text.Trim();
                            hidAppFormNo.Value = ds.Tables[0].Rows[0]["AdmissionFormNo"].ToString();
                            hidpkYear.Value = ds.Tables[0].Rows[0]["pkYear"].ToString();
                            hidpkStudentID.Value = ds.Tables[0].Rows[0]["pkStudentID"].ToString();
                            hidFacID.Value = ds.Tables[0].Rows[0]["pkFacID"].ToString();
                            hidCrID.Value = ds.Tables[0].Rows[0]["pkCrID"].ToString();
                            hidMoLrnID.Value = ds.Tables[0].Rows[0]["pkMoLrnID"].ToString();
                            hidPtrnID.Value = ds.Tables[0].Rows[0]["pkPtrnID"].ToString();
                            hidBrnID.Value = ds.Tables[0].Rows[0]["pkBrnID"].ToString();
                            hidCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pkCrPrDetails"].ToString();
                            hid_fk_AcademicYr_ID.Value = ds.Tables[0].Rows[0]["fkAcademicYearID"].ToString();
                            //Server.Transfer("ELGV2_ResolveProvisional__2.aspx?Search=Simple");
                            hidPRN.Value = ds.Tables[0].Rows[0]["PRN"].ToString();
                            dgRegPendingStudents1.DataSource = ds;
                            dgRegPendingStudents1.DataBind();
                            dgRegPendingStudents1.Attributes.Add("style", "display:block");
                            tblDGRegPendingStudents.Style.Remove("display");
                            tblDGRegPendingStudents.Style.Add("display", "block");
                            lblGrid.Text = "* Please click on the Student Name to select the Student whose Pending Eligibility for a particular " + lblCr.Text.ToLower() + " is to be Resolved";
                            lblGrid.Attributes.Add("style", "display:block");
                            tblDGRegPendingStudents.Attributes.Add("style", "display:block");
                            //ViewState.Add("SimpleSearchDS", ds);
                        }
                        else if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "1") // Eligible
                        {
                            if (txtElgFormNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();
                            }
                            else if (txtPRN.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with PRN Number " + txtPRN.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();

                            }
                            else if (txtApplicationFrmNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with Application form Number " + txtApplicationFrmNo.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();

                            } divErrorMsg.Attributes.Add("style", "display:block");
                            lblErrorMsg.Attributes.Add("style", "display:none");
                            lblGrid.Attributes.Add("style", "display:none");
                        }
                        else  //Not Eligible
                        {
                            if (txtElgFormNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";
                            }
                            else if (txtPRN.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with PRN Number " + txtPRN.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";

                            }
                            else if (txtApplicationFrmNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with Application Form Number " + txtApplicationFrmNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";

                            }
                            divErrorMsg.Attributes.Add("style", "display:block");
                            lblErrorMsg.Attributes.Add("style", "display:block");
                            lblGrid.Attributes.Add("style", "display:none");
                        }

                    }
                    else
                    {
                        if (txtElgFormNo.Text != string.Empty)
                        {
                            lblErrorMsg.Text = "The eligibility of the Student with Eligibility Form Number  " + txtElgFormNo.Text.Trim() + "  is not kept pending or may not be processed.Please check the status to verify.";
                        }
                        else if (txtPRN.Text != string.Empty)
                        {
                            lblErrorMsg.Text = "The eligibility of the Student with PRN Number  " + txtPRN.Text.Trim() + "  is not kept pending or may not be processed.Please check the status to verify.";

                        }
                        else if (txtApplicationFrmNo.Text != string.Empty)
                        {
                            lblErrorMsg.Text = "The eligibility of the Student with Application Form Number  " + txtApplicationFrmNo.Text.Trim() + "  is not kept pending or may not be processed.Please check the status to verify.";

                        }
                        divErrorMsg.Attributes.Add("style", "display:block");
                        lblErrorMsg.Attributes.Add("style", "display:block");
                        lblGrid.Attributes.Add("style", "display:none");
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    // throw new Exception(ex.Message);
                }
                finally
                {
                    ds.Dispose();
                }
            }
            else
            {
                lblErrorMsg.Text = "There is no matching record.";
                lblErrorMsg.Attributes.Add("style", "display:block");
            }
            divSimpleSearch.Attributes.Add("style", "display:block");
            DivAdvanceSearch.Attributes.Add("style", "display:none");
        }

        #endregion

        private void fnFetchStudent()
        {
            //lblSubmitMessage.Attributes.Add("style", "display:none");
            divErrorMsg.Attributes.Add("style", "display:none");
            lblError.Attributes.Add("style", "display:none");
            divErrorMsg.Attributes.Add("style", "display:none");
            lblErrorMsg.Attributes.Add("style", "display:none");

            string ElgFormNo;
            if (txtElgFormNo.Text != "")
            {
                ElgFormNo = txtElgFormNo.Text.Trim();
                hidIsBlank.Value = ElgFormNo;

            }
            else
            {
                ElgFormNo = "0-0-0-0";
                hidIsBlank.Value = "";

            }

            int cnt = 0;
            string str = ElgFormNo;
            int pos = str.IndexOf('-');
            string[] arr = new string[] { "0", "0", "0", "0" };
            Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");

            if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                PRNumber = txtPRN.Text.Trim();
            InstituteID = hidInstID.Value;

            while (pos != -1)
            {
                str = str.Substring(pos + 1);
                pos = str.IndexOf('-');
                cnt++;

            }

            if (cnt == 3)
            {
                arr = new string[4];
                arr = ElgFormNo.Split('-');   //new  UniID = arr[0], InstID = arr[1],Year = arr[2], StudID = arr[3]
                for (int i = 0; i < 4; i++)
                {
                    if (arr[i] == "")
                        arr[i] = "0";
                }
                try
                {
                    #region all search for pending students
                    ds = clsEligibilityDBAccess.Check_Reg_Pending_Student_Exists_RegStu(arr[0], arr[1], arr[2], arr[3], txtPRN.Text, hidInstID.Value, txtApplicationFrmNo.Text.Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "3")    // Pending Eligibility
                        {
                            hidElgFormNo.Value = txtElgFormNo.Text.Trim();
                            hidAppFormNo.Value = ds.Tables[0].Rows[0]["AdmissionFormNo"].ToString();
                            hidpkYear.Value = ds.Tables[0].Rows[0]["pkYear"].ToString();
                            hidpkStudentID.Value = ds.Tables[0].Rows[0]["pkStudentID"].ToString();
                            hidFacID.Value = ds.Tables[0].Rows[0]["pkFacID"].ToString();
                            hidCrID.Value = ds.Tables[0].Rows[0]["pkCrID"].ToString();
                            hidMoLrnID.Value = ds.Tables[0].Rows[0]["pkMoLrnID"].ToString();
                            hidPtrnID.Value = ds.Tables[0].Rows[0]["pkPtrnID"].ToString();
                            hidBrnID.Value = ds.Tables[0].Rows[0]["pkBrnID"].ToString();
                            hidCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pkCrPrDetails"].ToString();
                            hid_fk_AcademicYr_ID.Value = ds.Tables[0].Rows[0]["fkAcademicYearID"].ToString();
                            //Server.Transfer("ELGV2_ResolveProvisional__2.aspx?Search=Simple");
                            hidPRN.Value = ds.Tables[0].Rows[0]["PRN"].ToString();
                            dgRegPendingStudents1.DataSource = ds;
                            dgRegPendingStudents1.DataBind();
                            dgRegPendingStudents1.Style.Add("display", "block");
                            tblDGRegPendingStudents.Style.Remove("display");
                            tblDGRegPendingStudents.Style.Add("display", "block");
                            lblGrid.Text = "* Please click on the Student Name to select the Student whose Pending Eligibility for a particular " + lblCr.Text.ToLower() + " is to be Resolved";
                            lblGrid.Attributes.Add("style", "display:block");
                            tblDGRegPendingStudents.Attributes.Add("style", "display:block");
                            //ViewState.Add("SimpleSearchDS", ds);
                        }
                        else if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "1") // Eligible
                        {
                            if (txtElgFormNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();
                            }
                            else if (txtPRN.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with PRN Number " + txtPRN.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();

                            }
                            else if (txtApplicationFrmNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with Application Form Number " + txtApplicationFrmNo.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();

                            }
                            divErrorMsg.Attributes.Add("style", "display:block");
                            lblErrorMsg.Attributes.Add("style", "display:none");
                        }
                        else  //Not Eligible
                        {
                            if (txtElgFormNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";
                            }
                            else if (txtPRN.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with PRN Number " + txtPRN.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";

                            }
                            else if (txtApplicationFrmNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The Student with Application Form No Number " + txtApplicationFrmNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";

                            }
                            divErrorMsg.Attributes.Add("style", "display:block");
                            lblErrorMsg.Attributes.Add("style", "display:block");
                        }

                    }
                    else
                    {
                        if (txtElgFormNo.Text != string.Empty)
                        {
                            lblErrorMsg.Text = "The eligibility of the Student with Eligibility Form Number  " + txtElgFormNo.Text.Trim() + "  is not kept pending or may not be processed.Please check the status to verify.";
                        }
                        else if (txtPRN.Text != string.Empty)
                        {
                            lblErrorMsg.Text = "The eligibility of the Student with PRN Number  " + txtPRN.Text.Trim() + "  is not kept pending or may not be processed.Please check the status to verify.";

                        }
                        else if (txtApplicationFrmNo.Text != string.Empty)
                        {
                            lblErrorMsg.Text = "The eligibility of the Student with Application Form Number  " + txtApplicationFrmNo.Text.Trim() + "  is not kept pending or may not be processed.Please check the status to verify.";

                        }
                        divErrorMsg.Attributes.Add("style", "display:block");
                        lblErrorMsg.Attributes.Add("style", "display:block");
                        lblGrid.Attributes.Add("style", "display:none");
                        if (qstrNavigate == "back")
                        {
                            divErrorMsg.Attributes.Add("style", "display:none");
                            lblErrorMsg.Attributes.Add("style", "display:none");
                            txtElgFormNo.Text = string.Empty;
                            txtPRN.Text = string.Empty;
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    // throw new Exception(ex.Message);
                }
                finally
                {
                    ds.Dispose();
                }
            }
            else
            {
                lblErrorMsg.Text = "There is no matching record.";
                lblErrorMsg.Attributes.Add("style", "display:block");
            }
            divSimpleSearch.Attributes.Add("style", "display:block");
            DivAdvanceSearch.Attributes.Add("style", "display:none");
        }

    }
}