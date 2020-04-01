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
using System.Threading;
using System.Globalization;
using System.Resources;
using StudentRegistration.Eligibility.ElgClasses;
using System.Text.RegularExpressions;
using Sancharak;
using System.Text;
using System.Xml;

namespace StudentRegistration.Eligibility.WebCtrl
{
    public partial class StudentAdvanceSeachForConfigure : System.Web.UI.UserControl
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
        string[] RefIDarr = new string[4];
        string InstituteID = null;
        string PRNumber = null;
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

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            clsCache.NoCache();

            Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods), this.Page);
            Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent), this.Page);
            
            dgElgRegular1.Visible = false;
            dgRegPendingStudents1.Attributes.Add("style", "display:none");
            lblGridName.Style.Remove("display");
            lblGridName.Style.Add("display", "none");
            divDGNote.Style.Remove("display");
            divDGNote.Style.Add("display", "none");
            if (!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[27];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidFacID;
                hid[3] = hidCrID;
                hid[4] = hidCrMoLrnID;
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
                hid[15] = hid_fk_AcademicYr_ID;
                hid[16] = hidAcademicYrText;
                hid[17] = hidPRN;
                hid[18] = hidIsBlank;
                hid[19] = hidFacName;
                hid[20] = hidCrName;
                hid[21] = hidMOLName;
                hid[22] = hidPattern;
                hid[23] = hidBrName;
                hid[24] = hidSearchType;
                hid[25] = hidEligibility;
                hid[26] = hidAppFormNo;
                Common.setHiddenVariables(ref hid);
                divSimpleSearch.Style.Add("display", "block");
                lblAdvSearch.InnerText = "Advanced Search";
                //hidSearchType.Value = "Simple";

                if (Page.PreviousPage != null)
                {
                    ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

                    if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                    {
                        hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                    }
                }

                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                CommonAcYr.fillDropDown(ddlAcademicYear, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");

                btnSimpleSearch.Attributes.Add("onclick", "return ChkValidation();");
                btnSubmit.Attributes.Add("onclick", "return submitValidate();");
                lblGrid.Attributes.Add("style", "display:none");
                lblErrorMsg.Attributes.Add("style", "display:none");
                tdSubmit.Attributes.Add("style", "display:none");
                tblResolveQuestion.Attributes.Add("style", "display:none");
                divError.Attributes.Add("style", "display:none");
                hidSubmitFlag.Value = "0";
                //  btnClear.Attributes.Add("onclick", " return fnClearSearchCriteria();");     

                //  else
                // {
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                try
                {
                    hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
                }
                catch
                {
                    hidIsPRNValidationRequired.Value = "N";
                }
                //   }

                #region Back Navigation
                if (!hidSubmitFlag.Value.Equals("1"))
                {
                    if (Page.PreviousPage != null)
                    {
                        if (qstrNavigate == "back")
                        {

                            ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");

                            if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                            {
                                hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                                hidFacID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkFacID")).Value;
                                hidCrID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkCrID")).Value;
                                hidCrMoLrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkMoLrnID")).Value;
                                hidPtrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkPtrnID")).Value;
                                hidBrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkBrnID")).Value;
                                hidCrPrDetailsID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkCrPrDetailsID")).Value;
                                hidPRN.Value = ((HtmlInputHidden)Cntp.FindControl("hidPRN")).Value;
                                hidElgFormNo.Value = ((HtmlInputHidden)Cntp.FindControl("hidElgFormNo")).Value;
                                hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)Cntp.FindControl("hid_fk_AcademicYr_ID")).Value;
                                hidAcademicYrText.Value = ((HtmlInputHidden)Cntp.FindControl("hidAcademicYrText")).Value;
                                hidIsBlank.Value = ((HtmlInputHidden)Cntp.FindControl("hidIsBlank")).Value;
                                hidFacName.Value = ((HtmlInputHidden)Cntp.FindControl("hidFacName")).Value;
                                hidCrName.Value = ((HtmlInputHidden)Cntp.FindControl("hidCrName")).Value;
                                hidMOLName.Value = ((HtmlInputHidden)Cntp.FindControl("hidMOLName")).Value;
                                hidPattern.Value = ((HtmlInputHidden)Cntp.FindControl("hidPattern")).Value;
                                hidBrName.Value = ((HtmlInputHidden)Cntp.FindControl("hidBrName")).Value;
                                hidAcYrName.Value = ((HtmlInputHidden)Cntp.FindControl("hidAcYrName")).Value;
                                hidBranchName.Value = ((HtmlInputHidden)Cntp.FindControl("hidBranchName")).Value;
                                // txtElgFormNo.Text = hidElgFormNo.Value;
                            }
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
                            if (Page.ToString() != "ASP.eligibility_elgv2_resolvepending__1_aspx")
                            {
                                tblResolveQuestion.Attributes.Add("style", "display:block");
                                tdSubmit.Attributes.Add("style", "display:block");
                                rbElgDecsionNo.Checked = true;
                                rbElgDecsionYes.Checked = false;
                                txtNotElgReason.Text = string.Empty;
                            }

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
                        FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value);


                        //if (gridType == "IA")
                        //{

                        //    hidElgFormNo.Value = "";
                        //    fnDisplayIAGrid();
                        //}
                        //if (gridType == "Reg")
                        //{

                        //    hidpkYear.Value = "";
                        //    hidpkStudentID.Value = "";
                        //    fnDisplayRegGrid();
                        //}
                        //hidFresh.Value = "1";
                        DataTable dtAY = clsCollegeAdmissionReports.GetAcademicYear();
                        CommonAcYr.fillDropDown(ddlAcademicYear, dtAY, "", "Year", "pk_AcademicYear_ID", "--- Select ---");
                        ListItem selAcYr = ddlAcademicYear.Items.FindByText(hidAcYrName.Value);
                        ddlAcademicYear.SelectedIndex = ddlAcademicYear.Items.IndexOf(selAcYr);
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
                }

                #region Check Provisional/Pending

                string str = Page.ToString();
                if (str == "ASP.eligibility_elgv2_resolvepending__1_aspx")
                {
                    trOr.Attributes.Add("style", "display:none");
                    trPRN.Attributes.Add("style", "display:none");

                }
                #endregion

                #endregion

            }

            FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value);

        }

        #endregion

        #region Display Adv Search Grids

        private void fnDisplayIAGrid()
        {
            DataView dv = new DataView();
            DataSet ds = new DataSet();

            hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.ToString();
            hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;

            try
            {
                //By Shivani ds = Eligibility.clsEligibilityDBAccess.Fetch_IA_Student_List_Configure(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value,hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value,hidDOB.Value, hidLastName.Value,hidFirstName.Value, hidGender.Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
                if (HidSearchType.Equals("Adv"))
                {
                    DivAdvanceSearch.Style.Add("display", "block");
                }
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
                if (!ddlAcademicYear.SelectedIndex.Equals(0))
                {
                    hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.ToString();
                    hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;
                }

                //for preventing clearing of ac yr id when coming back from details page
                else
                {
                    if (Request.QueryString["AcYear"] != null)
                    {
                        hid_fk_AcademicYr_ID.Value = Request.QueryString["AcYear"].ToString();
                    }
                }
            }

            try
            {
                //ds = Eligibility.clsEligibilityDBAccess.Fetch_Pending_Reg_Student_List(Classes.clsGetSettings.UniversityID.ToString(), Session["SInst_Type"].ToString(), Session["SInst_Name"].ToString(), Session["SState_ID"].ToString(), Session["SDistrict_ID"].ToString(), Session["STehsil_ID"].ToString(), Session["FacultyID"].ToString(), Session["CourseID"].ToString(), Session["CrMoLrnPtrnID"].ToString(), Session["CoursePartID"].ToString(), Session["DOB"].ToString(), Session["LastName"].ToString(), Session["FirstName"].ToString(), Session["Gender"].ToString());
                string str = Page.ToString();
                if (str == "ASP.eligibility_elgv2_resolvepending__1_aspx")
                {
                    ds = Eligibility.clsEligibilityDBAccess.Fetch_Pending_Reg_Student_List_Resolve(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hid_fk_AcademicYr_ID.Value);
                    lblGridName.Text = "List of students whose Eligiblity is kept pending";
                }
                else if (str == "ASP.eligibility_elgv2_resolveprovisional__1_aspx")
                {
                    ds = Eligibility.clsEligibilityDBAccess.Fetch_ProvisionallyEligible_Reg_Student_List_Resolve(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, AcdYearID);
                    lblGridName.Text = "List of students whose Eligiblity is kept Provisional";
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
                throw new Exception(e.Message);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgRegPendingStudents1.DataSource = ds;

                dv.Table = ds.Tables[0];
                if (ViewState["SortExpression"] != null)
                {
                    dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();
                }
                dgRegPendingStudents1.DataSource = dv;
                try
                {
                    dgRegPendingStudents1.DataBind();
                }
                catch
                {
                    dgRegPendingStudents1.PageIndex = 0;
                    dgRegPendingStudents1.DataBind();
                }

                dgRegPendingStudents1.Columns[16].ItemStyle.CssClass="clOff";
                dgRegPendingStudents1.Columns[16].HeaderStyle.CssClass = "clOff";
                dgRegPendingStudents1.Style.Add("display", "block");
                tblDGRegPendingStudents.Style.Remove("display");
                tblDGRegPendingStudents.Style.Add("display", "block");
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");
                //divDGNote.Style.Remove("display");
                //divDGNote.Style.Add("display", "block");
                //divAcademicYr.Style.Add("display", "none");
                //divSrchStudent.Style.Add("display", "block");
                lblGrid.Text = "* Please click on the Student Name to select the Student whose Pending Eligibility for a particular " + lblCr.Text.ToLower() + " is to be Resolved";
                lblGrid.Attributes.Add("style", "display:block");

            }
            else
            {
                string msg = string.Empty;
                if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx")) { msg = "Pending"; }
                else { msg = "Provisional"; }
                dgRegPendingStudents1.Style.Add("display", "none");
                tblDGRegPendingStudents.Style.Remove("display");
                tblDGRegPendingStudents.Style.Add("display", "none");
                lblGridName.Text = "There are no Students satisfying the above search criteria whose Eligibility is kept " + msg + "...";
                lblGridName.Style.Remove("display");
                lblGridName.Style.Add("display", "block");
                divDGNote.Style.Remove("display");
                divDGNote.Style.Add("display", "none");
                //divAcademicYr.Style.Add("display", "none");
                tdSubmit.Attributes.Add("style", "display:none");
                tblResolveQuestion.Attributes.Add("style", "display:none");
                lblGrid.Style.Add("display", "none");

            }

            if ((Request.QueryString["Search"] == "Adv" || HidSearchType.Equals("Adv")))
            {
                divSimpleSearch.Attributes.Add("style", "display:none");
                DivAdvanceSearch.Attributes.Add("style", "display:block");
                if (Page.ToString() != "ASP.eligibility_elgv2_resolvepending__1_aspx" && ds.Tables[0].Rows.Count > 0)
                {
                    tdSubmit.Attributes.Add("style", "display:block");
                    tblResolveQuestion.Attributes.Add("style", "display:block");
                }
            }

            ds.Clear();
            ds.Dispose();
            ds = null;


        }

        #endregion

        #region Filling Dropdowns

        public void FillFaculty()
        {
            DataTable oDT = new DataTable();
            if (ddlCourse.SelectedIndex == 0)
            {
                try
                {

                    oDT = InstRep.AssignedConfirmedFaculties(hidUniID.Value, hidInstID.Value);
                    Common.fillDropDown(ddlFaculty, oDT, "", "Fac_Desc", "pk_Fac_ID", "--- Select ---");

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
            common.fillDropDown(ddlMoLrn, dt, MoLrnID, "MoLrn_Type", "pk_MoLrn_ID", "--- Select ---");
            ddlCrPtrn.Items.Clear();

            try
            {
                dt = InstRep.AssignedConfirmedCoursePatterns(hidUniID.Value, hidInstID.Value, FacID, CrID, MoLrnID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            common.fillDropDown(ddlCrPtrn, dt, PtrnID, "text", "value", "--- Select ---");
            ddlBranch.Items.Clear();

            try
            {
                dt = InstRep.AssignedConfirmedBranches(hidUniID.Value, hidInstID.Value, FacID, CrID, MoLrnID, PtrnID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (hidBranchName.Value == "No Branch")
            {
                ddlBranch.Items.Insert(0, "No Branch");
            }
            else
            {
                common.fillDropDown(ddlBranch, dt, BrnID, "Text", "Value", "--- Select ---");
            }
           
            //   ddlCoursePart.Items.Clear();

            /*try
            {
                dt = InstRepV2.AssignedConfirmedCourseParts(hidUniID.Value, hidInstID.Value, FacID, CrID, MoLrnID, PtrnID, BrnID);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            common.fillDropDown(ddlCoursePart, dt,CrPrDetailsID, "CrPr_Abbr", "pk_CrPr_Details_ID", "---- Select ----");

            if (common != null) common = null;
          
            dt.Dispose();*/
            //try
            //{
            //    dt = InstRepV2.AssignedConfirmedCourseParts(hidUniID.Value, hidInstID.Value, FacID, CrID, MoLrnID, PtrnID, BrnID);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            // common.fillDropDown(ddlCoursePart, dt, CrPrDetailsID, "CrPr_Abbr", "pk_CrPr_ID", "---- Select ----");
            //ddlCoursePartChild.Items.Clear();
            if (common != null) common = null;
            dt.Dispose();



        }

        #endregion

        #region Advanced Search Button Click

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblAdvSearch.InnerText = "Simple Search";
            lblSubmitMessage.Attributes.Add("style", "display:none");
            rbElgDecsionNo.Checked = true;
            rbElgDecsionYes.Checked = false;
            txtNotElgReason.Text = string.Empty;
            tblResolveQuestion.Attributes.Add("style", "display:none");
            divErrorMsg.Attributes.Add("style", "display:none");
            lblError.Attributes.Add("style", "display:none");
            tdSubmit.Attributes.Add("style", "display:none");
            hidSubmitFlag.Value = "0";
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

        /*protected void dgElgRegular_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {
                //Session["ElgFormNo"] = e.Item.Cells[1].Text.Trim();
                //Session["pk_CrMoLrnPtrn_ID"]=e.Item.Cells[6].Text.Trim();
                hidElgFormNo.Value = e.Item.Cells[1].Text.Trim();
               //By Shivani hidCrMoLrnPtrnID.Value = e.Item.Cells[6].Text.Trim();
                Server.Transfer(strUrl);
            }

        }*/

        /*     protected void dgElgRegular_ItemDataBound(object sender, DataGridItemEventArgs e)
             {
                 if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
                 {
                     e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgElgRegular.CurrentPageIndex * 10) + 1);
                 }
             }
             */
        /*       protected void dgElgRegular_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
               {
                   dgElgRegular.CurrentPageIndex = e.NewPageIndex;
                   fnDisplayIAGrid();
               }
       */
        /*     protected void dgElgRegular_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
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
             }*/
        #endregion

        #region dgRegPendingStudents1


        /*       protected void dgRegPendingStudents_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
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
                hidpkYear.Value = e.Item.Cells[6].Text.Trim();
                hidpkStudentID.Value = e.Item.Cells[7].Text.Trim();
                hidFacID.Value = e.Item.Cells[8].Text.Trim();
                hidCrID.Value = e.Item.Cells[9].Text.Trim();
                hidMoLrnID.Value = e.Item.Cells[10].Text.Trim();
                hidPtrnID.Value = e.Item.Cells[11].Text.Trim();
                hidBrnID.Value = e.Item.Cells[12].Text.Trim();
                hidCrPrDetailsID.Value = e.Item.Cells[13].Text.Trim();   
                
                //Common.setHiddenVariables(ref hid);
                //end
                Server.Transfer(strUrl);
            }
        }*/

        /*    protected void dgRegPendingStudents_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
            {
                dgRegPendingStudents.CurrentPageIndex = e.NewPageIndex;
                fnDisplayRegGrid();
            }*/

        /*       protected void dgRegPendingStudents_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
               {
                   if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
                   {
                       e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgElgRegular.CurrentPageIndex * 10) + 1);

                   }
               }
               */
        #endregion

        #region dgElgRegular1 Events

        protected void dgElgRegular1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Style.Add("Display", "none");
                e.Row.Cells[6].Style.Add("Display", "none");
                e.Row.Cells[7].Style.Add("Display", "none");
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].Style.Add("Display", "none");
                e.Row.Cells[6].Style.Add("Display", "none");
                e.Row.Cells[7].Style.Add("Display", "none");
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
            fnDisplayIAGrid();
            dgElgRegular1.PageIndex = e.NewPageIndex;
            dgElgRegular1.DataBind();
        }

        #endregion

        #region dgRegPendingStudents1 Events

        protected void dgRegPendingStudents1_RowdataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx"))
                {
                    e.Row.Cells[4].Style.Add("display", "none");
                }
                e.Row.Cells[5].Style.Add("display", "none");
                //e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
                e.Row.Cells[16].Style.Add("display", "none");
                //e.Row.Cells[16].Style.Add("display", "none");
                if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx") || hidSearchType.Value.Equals("Simple"))
                {
                    /**********************************************/
                    e.Row.Cells[18].Style.Add("display", "none");

                    /************************************************/
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx"))
                {
                    e.Row.Cells[4].Style.Add("display", "none");
                }
                e.Row.Cells[5].Style.Add("display", "none");
                // e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[15].Style.Add("display", "none");
                e.Row.Cells[16].Style.Add("display", "none");
                //e.Row.Cells[16].Style.Add("display", "none");
                if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx") || hidSearchType.Value.Equals("Simple"))
                {
                    /************************************************/
                    e.Row.Cells[18].Style.Add("display", "none");
                    /************************************************/
                }
            }

        }

        protected void dgRegPendingStudents1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgRegPendingStudents1.PageIndex = e.NewPageIndex;
            //dgRegPendingStudents1.DataBind();
            fnDisplayRegGrid();
        }

        protected void dgRegPendingStudents1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PendingStudentDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgRegPendingStudents1.Rows[index];

                hidElgFormNo.Value = row.Cells[2].Text.Trim();
                hidpkYear.Value = row.Cells[8].Text.Trim();
                hidpkStudentID.Value = row.Cells[9].Text.Trim();
                hidFacID.Value = row.Cells[10].Text.Trim();
                hidCrID.Value = row.Cells[11].Text.Trim();
                hidCrMoLrnID.Value = row.Cells[12].Text.Trim();
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

        #endregion

        #region Academic Yr & Clear Button Clicks

        //public void btnAcYr_Click(object sender, EventArgs e)
        //{
        //    hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.ToString();
        //    hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;

        //    if (hid_fk_AcademicYr_ID.Value == "0")
        //    {
        //        string strScript = "<script language='JavaScript'>alert('Please Select Academic Year')</script>";
        //        Page.RegisterStartupScript("PopUp", strScript);
        //        tblAcademicYr.Style.Add("display", "block");
        //        DivAdvanceSearch.Style.Add("display", "none");
        //        //trbtnSearch.Style.Add("display", "none");
        //        //  btnAcYr.Attributes.Add("onclick", "return fnClearSearchCriteria();");
        //    }
        //    else
        //    {
        //        tblAcademicYr.Style.Add("display", "none");
        //        //tblSelect.Style.Add("display", "block");
        //        DivAdvanceSearch.Style.Add("display", "block");
        //        //trbtnSearch.Style.Add("display", "block");
        //        btnAcYr.Attributes.Add("onclick", "return fnClearSearchCriteria();");

        //    }
        //    divSimpleSearch.Style.Add("display", "none");
        //    // DivAdvanceSearch.Attributes.Add("display", "block");
        //}

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtDOB.Text = "";
            ddlFaculty.SelectedIndex = 0;
            ddlCourse.SelectedIndex = 0;
            ddlMoLrn.SelectedIndex = 0;
            ddlCrPtrn.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            hidFacID.Value = "0";
            hidCrID.Value = "0";
            hidCrMoLrnID.Value = "0";
            hidPtrnID.Value = "0";
            hidBrnID.Value = "0";
            hidCrPrDetailsID.Value = "0";
            hidGender.Value = "0";
            tdSubmit.Attributes.Add("style", "display:none");
            tblResolveQuestion.Attributes.Add("style", "display:none");
            tblMarkElg.Attributes.Add("style", "display:none");


            //document.getElementById('<%= tblDGElgRegular.ClientID %>').style.display = 'none';
            //document.getElementById('<%= tblDGRegPendingStudents.ClientID %>').style.display = 'none';
            //document.getElementById('<%= lblGridName.ClientID %>').style.display = 'none';
            //document.getElementById('<%= divDGNote.ClientID %>').style.display = 'none';

        }

        #endregion

        #region btnSimpleSearch_Click

        protected void btnSimpleSearch_Click(object sender, System.EventArgs e)
        {
            lblAdvSearch.InnerText = "Advanced Search";
            ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            ((Label)Cntph1.FindControl("lblSubHeader")).Text = "  for " + InstRep.InstituteName(hidUniID.Value, hidInstID.Value);
            lblSubmitMessage.Attributes.Add("style", "display:none");
            rbElgDecsionNo.Checked = true;
            rbElgDecsionYes.Checked = false;
            txtNotElgReason.Text = string.Empty;
            tblResolveQuestion.Attributes.Add("style", "display:none");
            divErrorMsg.Attributes.Add("style", "display:none");
            divDGNote.Attributes.Add("style", "display:none");
            lblError.Attributes.Add("style", "display:none");
            tdSubmit.Attributes.Add("style", "display:none");
            hidSubmitFlag.Value = "0";
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
                    if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx"))
                    {
                        ds = clsEligibilityDBAccess.Check_Reg_Pending_Student_Exists(arr[0], arr[1], arr[2], arr[3], hidInstID.Value,txtApplicationFrmNo.Text.Trim());
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
                                hidCrMoLrnID.Value = ds.Tables[0].Rows[0]["pkMoLrnID"].ToString();
                                hidPtrnID.Value = ds.Tables[0].Rows[0]["pkPtrnID"].ToString();
                                hidBrnID.Value = ds.Tables[0].Rows[0]["pkBrnID"].ToString();
                                hidCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pkCrPrDetails"].ToString();
                                hid_fk_AcademicYr_ID.Value = ds.Tables[0].Rows[0]["fkAcademicYearID"].ToString();
                                //Server.Transfer("ELGV2_ResolveProvisional__2.aspx?Search=Simple");
                                hidPRN.Value = ds.Tables[0].Rows[0]["PRN"].ToString();
                                dgRegPendingStudents1.Columns[16].ItemStyle.CssClass = "clOff";
                                dgRegPendingStudents1.Columns[16].HeaderStyle.CssClass = "clOff";
                                dgRegPendingStudents1.DataSource = ds;
                                dgRegPendingStudents1.DataBind();
                                dgRegPendingStudents1.Attributes.Add("style", "display:block");
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
                                divErrorMsg.Attributes.Add("style", "display:block");
                                lblErrorMsg.Attributes.Add("style", "display:none");
                                lblGrid.Attributes.Add("style", "display:none");
                            }
                            else  //Not Eligible
                            {
                                if (txtElgFormNo.Text != string.Empty)
                                {
                                    lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";
                                }
                                else if (txtApplicationFrmNo.Text != string.Empty)
                                {
                                    lblErrorMsg.Text = "The Student with Application Form Number " + txtApplicationFrmNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";

                                } divErrorMsg.Attributes.Add("style", "display:block");
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
                            else if (txtApplicationFrmNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The eligibility of the Student with Application Form Number  " + txtApplicationFrmNo.Text.Trim() + "  is not kept pending or may not be processed.Please check the status to verify.";

                            } divErrorMsg.Attributes.Add("style", "display:block");
                            lblErrorMsg.Attributes.Add("style", "display:block");
                            lblGrid.Attributes.Add("style", "display:none");
                        }


                    }
                    #endregion

                    #region call search for provisional students

                    else if (Page.ToString().Equals("ASP.eligibility_elgv2_resolveprovisional__1_aspx"))
                    {
                        ds = clsEligibilityDBAccess.Check_Reg_Provisional_Student_Exists(arr[0], arr[1], arr[2], arr[3], txtPRN.Text, hidInstID.Value,txtApplicationFrmNo.Text.Trim());
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "5")    // Provisional Eligibility
                            {
                                hidElgFormNo.Value = txtElgFormNo.Text.Trim();
                                hidAppFormNo.Value = ds.Tables[0].Rows[0]["AdmissionFormNo"].ToString();
                                hidpkYear.Value = ds.Tables[0].Rows[0]["pkYear"].ToString();
                                hidpkStudentID.Value = ds.Tables[0].Rows[0]["pkStudentID"].ToString();
                                hidFacID.Value = ds.Tables[0].Rows[0]["pkFacID"].ToString();
                                hidCrID.Value = ds.Tables[0].Rows[0]["pkCrID"].ToString();
                                hidCrMoLrnID.Value = ds.Tables[0].Rows[0]["pkMoLrnID"].ToString();
                                hidPtrnID.Value = ds.Tables[0].Rows[0]["pkPtrnID"].ToString();
                                hidBrnID.Value = ds.Tables[0].Rows[0]["pkBrnID"].ToString();
                                hidCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pkCrPrDetails"].ToString();
                                hid_fk_AcademicYr_ID.Value = ds.Tables[0].Rows[0]["fkAcademicYearID"].ToString();
                                //Server.Transfer("ELGV2_ResolveProvisional__2.aspx?Search=Simple");
                                hidPRN.Value = ds.Tables[0].Rows[0]["PRN"].ToString();
                                dgRegPendingStudents1.Columns[16].ItemStyle.CssClass = "clOff";
                                dgRegPendingStudents1.Columns[16].HeaderStyle.CssClass = "clOff";
                                dgRegPendingStudents1.DataSource = ds;
                                dgRegPendingStudents1.DataBind();
                                dgRegPendingStudents1.Attributes.Add("style", "display:block");
                                lblGridName.Attributes.Add("display", "block");
                                lblGrid.Text = "* Please click on the Student Name to select the Student whose Provisional Eligibility for a particular " + lblCr.Text.ToLower() + " is to be Resolved";
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
                                    lblErrorMsg.Text = "The Student with entered Application Form Number " + txtApplicationFrmNo.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();

                                }
                                
                                divErrorMsg.Attributes.Add("style", "display:block");
                                lblErrorMsg.Attributes.Add("style", "display:none");
                                lblGridName.Attributes.Add("display", "none");
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
                                    lblErrorMsg.Text = "The Student with entered Application Form Number " + txtApplicationFrmNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";

                                }
                                divErrorMsg.Style.Add("display", "block");
                                lblErrorMsg.Style.Add("display", "block");
                                lblGridName.Attributes.Add("display", "none");
                                lblGrid.Attributes.Add("style", "display:none");
                            }

                        }
                        else
                        {
                            if (txtElgFormNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The eligibility of the Student with Eligibility Form Number  " + txtElgFormNo.Text.Trim() + "  is not kept provisional or may not be processed.Please check the status to verify.";
                            }
                            else if (txtPRN.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The eligibility of the Student with PRN Number  " + txtPRN.Text.Trim() + "  is not kept provisional or may not be processed.Please check the status to verify.";

                            }
                            else if (txtApplicationFrmNo.Text != string.Empty)
                            {
                                lblErrorMsg.Text = "The eligibility of the Student with entered Application Form Number  " + txtApplicationFrmNo.Text.Trim() + "  is not kept provisional or may not be processed.Please check the status to verify.";

                            }
                            divErrorMsg.Style.Add("display", "block");
                            lblErrorMsg.Style.Add("display", "block");
                            lblGridName.Attributes.Add("display", "none");
                            lblGrid.Attributes.Add("style", "display:none");
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

        #endregion

        #region Button Submit Click

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            rbElgDecsionNo.Checked = true;
            rbElgDecsionYes.Checked = false;
            //StringBuilder oStringBuilder = new StringBuilder();
            int iCount = 0;
            string reason = "";
            //resolving eligibility
            //for (int i = 0; i < dgRegPendingStudents1.Rows.Count; i++)
            //{
            //    CheckBox student_id = (CheckBox)dgRegPendingStudents1.Rows[i].FindControl("chkStudent");
            //    HiddenField hid_chk = (HiddenField)dgRegPendingStudents1.Rows[i].FindControl("hid_chkStudent");
            //    if (student_id.Checked)
            //    {
            //        oStringBuilder.Append(hidpkStudentID.Value);
            //        oStringBuilder.Append(",");
            //        oStringBuilder.Append(hid_chk.Value);
            //       // hidpkStudentID.Value += "," + hid_chk.Value;
            //        iCount = iCount + 1;
            //    }
            //}

            try
            {
                XmlDocument xml = new XmlDocument();
                XmlNode root = xml.CreateNode(XmlNodeType.Element, "R", "");
                XmlNode childNode = null;

                for (int i = 0; i < dgRegPendingStudents1.Rows.Count; i++)
                {
                    CheckBox student_id = (CheckBox)dgRegPendingStudents1.Rows[i].FindControl("chkStudent");
                    HiddenField hid_chk = (HiddenField)dgRegPendingStudents1.Rows[i].FindControl("hid_chkStudent");
                    if (student_id.Checked)
                    {
                        childNode = xml.CreateNode(XmlNodeType.Element, "SD", "");
                        childNode.AppendChild(xml.CreateElement("YrID")).InnerText = dgRegPendingStudents1.Rows[i].Cells[8].Text.ToString().Trim();
                        childNode.AppendChild(xml.CreateElement("StuID")).InnerText = dgRegPendingStudents1.Rows[i].Cells[9].Text.ToString().Trim();
                        childNode.AppendChild(xml.CreateElement("CrPrDetID")).InnerText = dgRegPendingStudents1.Rows[i].Cells[15].Text.ToString().Trim();
                        // childNode.AppendChild(xml.CreateElement("CrPrChID")).InnerText = dgRegPendingStudents1.Rows[i].Cells[15].Text.ToString().Trim();
                        root.AppendChild(childNode);
                        iCount = Convert.ToInt32(iCount) + 1;
                    }

                }

                xml.AppendChild(root);


                hidpkStudentID.Value = xml.OuterXml.ToString();
                // hidpkStudentID.Value = hidpkStudentID.Value.Trim(',');
                clsUser user = new clsUser();
                user = (clsUser)Session["User"];
                int RowsAffected = 0, ElgFlag = 0;
                if (hidEligibility.Value.Equals("Eligible"))
                {
                    ElgFlag = 1;
                }
                else if (hidEligibility.Value.Equals("Not Eligible"))
                {
                    ElgFlag = 2;
                }

                //if (rbMarkElg.Checked = true)
                //{
                //    hidEligibility.Value.Equals("Eligible");
                //    ElgFlag = 1;
                //}
                //if (rbMarkNotElg.Checked = true)
                //{
                //    hidEligibility.Value.Equals("Not Eligible");
                //    ElgFlag = 2;
                //}

                //RowsAffected = clsEligibilityDBAccess.REG_ProvisionallyEligibleStudentEligibilityDecisionBulk(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(hidInstID.Value), hidpkStudentID.Value, Convert.ToInt32(hidFacID.Value), Convert.ToInt32(hidCrID.Value), Convert.ToInt32(hidCrMoLrnID.Value), Convert.ToInt32(hidPtrnID.Value), Convert.ToInt32(hidBrnID.Value), Convert.ToInt32(dgRegPendingStudents1.Rows[0].Cells[14].Text), Convert.ToInt32(hid_fk_AcademicYr_ID.Value), ElgFlag.ToString(), txtNotElgReason.Text, user.User_ID);
                RowsAffected = clsEligibilityDBAccess.REG_ProvisionallyEligibleStudentEligibilityDecisionBulk(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(hidInstID.Value), Convert.ToInt32(hidFacID.Value), Convert.ToInt32(hidCrID.Value), Convert.ToInt32(hidCrMoLrnID.Value), Convert.ToInt32(hidPtrnID.Value), Convert.ToInt32(hidBrnID.Value), Convert.ToInt32(hid_fk_AcademicYr_ID.Value), hidpkStudentID.Value, ElgFlag.ToString(), txtNotElgReason.Text, user.User_ID);
                if (RowsAffected > 0)
                {
                    string SMSreturn = "";
                    string SMSMessage = "";
                    clsUser u = (clsUser)Session["User"]; //Added By Saroj on 1st Nov 2007

                    SendSMS objSendSMS = new SendSMS();
                    //ds = clsEligibilityRights.FetchRegisteredStudentDetailsForSMS(hidUniID.Value,  hidInstID.Value.ToString(), hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, dgRegPendingStudents1.Rows[0].Cells[14].Text, dgRegPendingStudents1.Rows[0].Cells[15].Text, hidpkStudentID.Value);
                    ds = clsEligibilityRights.FetchRegisteredStudentDetailsForSMS(hidUniID.Value, hidInstID.Value.ToString(), hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, dgRegPendingStudents1.Rows[0].Cells[16].Text, hidpkStudentID.Value);
                    if (ds != null)
                    {

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                //SMSMessage = "Congrats " + hidSMSFirstName.Value + ",You are eligible for " + hidSMSCrAbbr.Value + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ". Your PRN:" + PRN + ".";
                                //==========================================================================================
                                // To fetch Student login credentials for displaying in SMS
                                string userName = string.Empty, password = string.Empty;
                                DataSet Ds = clsEligibilityRights.GetStudentCredentialsForSMS(ds.Tables[0].Rows[i]["pk_Uni_ID"].ToString(), ds.Tables[0].Rows[i]["pk_Year"].ToString(), ds.Tables[0].Rows[i]["pk_Student_ID"].ToString());
                                if (Ds != null && Ds.Tables[0] != null && Ds.Tables[0].Rows.Count > 0)
                                {
                                    userName = Ds.Tables[0].Rows[0]["UserName"].ToString();
                                    password = Ds.Tables[0].Rows[0]["Password"].ToString();
                                }
                                //==========================================================================================
                                if (ElgFlag.ToString() == "1")
                                {
                                    //SMSMessage = "Congrats " + ds.Tables[0].Rows[i]["FirstName"].ToString() + ",You are Eligible for " + ds.Tables[0].Rows[i]["CrAbbr"].ToString() + " for Academic Year " + ds.Tables[0].Rows[i]["Year"].ToString() + " of " + TripleDESEncryption.clsAppSettings.DecryptAppsettings().AppSettings["SMSPcode"].ToString().ToUpper() + ".";// Your PRN:" + ds.Tables[0].Rows[i]["PRN"].ToString();
                                    SMSMessage = clsEligibilityRights.GetSMSBody("24", ds.Tables[0].Rows[i]["FirstName"].ToString(), ds.Tables[0].Rows[i]["CrAbbr"].ToString(), ds.Tables[0].Rows[i]["Year"].ToString(), ds.Tables[0].Rows[i]["UniAbbr"].ToString().ToUpper(), ds.Tables[0].Rows[i]["PRN"].ToString(), clsGetSettings.SitePath, userName, password, string.Empty);
                                }
                                if (ElgFlag.ToString() == "2")
                                {
                                    //SMSMessage = "Dear " + ds.Tables[0].Rows[i]["FirstName"].ToString() + ",You are found inEligible for " + ds.Tables[0].Rows[i]["CrAbbr"].ToString() + " for Academic Year " + ds.Tables[0].Rows[i]["Year"].ToString() + ". For more details contact your " + lblCollege.Text.ToLower() + ".";
                                    SMSMessage = clsEligibilityRights.GetSMSBody("5", ds.Tables[0].Rows[i]["FirstName"].ToString(), ds.Tables[0].Rows[i]["CrAbbr"].ToString(), ds.Tables[0].Rows[i]["Year"].ToString(), ds.Tables[0].Rows[i]["UniAbbr"].ToString().ToUpper(), "", clsGetSettings.SitePath, "", "", string.Empty);
                                }
                                objSendSMS.epMessage = SMSMessage;
                                objSendSMS.epUser = u.User_ID;  //Added By Saroj on 1st Nov 2007
                                SMSreturn = objSendSMS.SendPersonalizedSMS(ds.Tables[0].Rows[i]["MobileNumber"].ToString().Trim(), "ELG" + ds.Tables[0].Rows[i]["EligibilityFormNo"].ToString());
                            }
                        }
                    }
                    if (hidEligibility.Value.Equals("Not Eligible"))
                    {
                        reason = " the reason being \"" + txtNotElgReason.Text + "\".";
                    }
                    lblSubmitMessage.Attributes.Add("style", "display:block");
                    divError.Attributes.Add("style", "display:none");
                    lblSubmitMessage.Text = "The Provisional Eligibility for " + iCount + " Student(s) is resolved and are marked as \"" + hidEligibility.Value + "\"" + reason;
                    lblGrid.Attributes.Add("style", "display:none");
                    tblResolveQuestion.Attributes.Add("style", "display:none");
                    tdSubmit.Attributes.Add("style", "display:none");
                    rbMarkElg.Checked = false;
                    rbMarkNotElg.Checked = false;
                    hidEligibility.Value = "";
                }
                else
                {
                    lblSubmitMessage.Attributes.Add("style", "display:none");
                    divError.Attributes.Add("style", "display:block");
                    lblError.Text = "System has encountered an error in the Registration Process. Hence, Registration failed !!!<br>Please try again later.";


                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

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

        #endregion

        #region fnFetchStudent

        private void fnFetchStudent()
        {
            lblSubmitMessage.Attributes.Add("style", "display:none");
            rbElgDecsionNo.Checked = true;
            rbElgDecsionYes.Checked = false;
            txtNotElgReason.Text = string.Empty;
            tblResolveQuestion.Attributes.Add("style", "display:none");
            divErrorMsg.Attributes.Add("style", "display:none");
            divDGNote.Attributes.Add("style", "display:none");
            lblError.Attributes.Add("style", "display:none");
            lblErrorMsg.Attributes.Add("style", "display:none");
            tdSubmit.Attributes.Add("style", "display:none");
            hidSubmitFlag.Value = "0";

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
                    if (Page.ToString().Equals("ASP.eligibility_elgv2_resolvepending__1_aspx"))
                    {
                        ds = clsEligibilityDBAccess.Check_Reg_Pending_Student_Exists(arr[0], arr[1], arr[2], arr[3],hidInstID.Value,txtApplicationFrmNo.Text.Trim());
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
                                hidCrMoLrnID.Value = ds.Tables[0].Rows[0]["pkMoLrnID"].ToString();
                                hidPtrnID.Value = ds.Tables[0].Rows[0]["pkPtrnID"].ToString();
                                hidBrnID.Value = ds.Tables[0].Rows[0]["pkBrnID"].ToString();
                                hidCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pkCrPrDetails"].ToString();
                                hid_fk_AcademicYr_ID.Value = ds.Tables[0].Rows[0]["fkAcademicYearID"].ToString();
                                //Server.Transfer("ELGV2_ResolveProvisional__2.aspx?Search=Simple");
                                hidPRN.Value = ds.Tables[0].Rows[0]["PRN"].ToString();
                                /***************************************************************/
                                dgRegPendingStudents1.Columns[18].ItemStyle.CssClass = "clOff";
                                dgRegPendingStudents1.Columns[18].HeaderStyle.CssClass = "clOff";
                                /***************************************************************/
                                dgRegPendingStudents1.DataSource = ds;
                                dgRegPendingStudents1.DataBind();
                                dgRegPendingStudents1.Attributes.Add("style", "display:block");
                                lblGrid.Text = "* Please click on the Student Name to select the Student whose Pending Eligibility for a particular " + lblCr.Text.ToLower() + " is to be Resolved";
                                lblGrid.Attributes.Add("style", "display:block");
                                tblDGRegPendingStudents.Attributes.Add("style", "display:block");
                                lblErrorMsg.Attributes.Add("style", "display:none");
                                //ViewState.Add("SimpleSearchDS", ds);
                            }
                            else if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "1") // Eligible
                            {
                                lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();
                                divErrorMsg.Attributes.Add("style", "display:block");
                                lblErrorMsg.Attributes.Add("style", "display:none");
                                lblGrid.Attributes.Add("style", "display:none");
                            }
                            else  //Not Eligible
                            {
                                lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";
                                divErrorMsg.Attributes.Add("style", "display:block");
                                lblErrorMsg.Attributes.Add("style", "display:block");
                                lblGrid.Attributes.Add("style", "display:none");
                            }

                        }
                        else
                        {
                            lblErrorMsg.Text = "The eligibility of the Student with Eligibility Form Number  " + txtElgFormNo.Text.Trim() + "  is not kept pending or may not be processed.Please check the status to verify.";
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


                    }
                    #endregion

                    #region call search for provisional students

                    else if (Page.ToString().Equals("ASP.eligibility_elgv2_resolveprovisional__1_aspx"))
                    {
                        ds = clsEligibilityDBAccess.Check_Reg_Provisional_Student_Exists(arr[0], arr[1], arr[2], arr[3], txtPRN.Text, hidInstID.Value, txtApplicationFrmNo.Text);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "5")    // Provisional Eligibility
                            {
                                hidElgFormNo.Value = txtElgFormNo.Text.Trim();
                                hidpkYear.Value = ds.Tables[0].Rows[0]["pkYear"].ToString();
                                hidpkStudentID.Value = ds.Tables[0].Rows[0]["pkStudentID"].ToString();
                                hidFacID.Value = ds.Tables[0].Rows[0]["pkFacID"].ToString();
                                hidCrID.Value = ds.Tables[0].Rows[0]["pkCrID"].ToString();
                                hidCrMoLrnID.Value = ds.Tables[0].Rows[0]["pkMoLrnID"].ToString();
                                hidPtrnID.Value = ds.Tables[0].Rows[0]["pkPtrnID"].ToString();
                                hidBrnID.Value = ds.Tables[0].Rows[0]["pkBrnID"].ToString();
                                hidCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pkCrPrDetails"].ToString();
                                hid_fk_AcademicYr_ID.Value = ds.Tables[0].Rows[0]["fkAcademicYearID"].ToString();
                                //Server.Transfer("ELGV2_ResolveProvisional__2.aspx?Search=Simple");
                                hidPRN.Value = ds.Tables[0].Rows[0]["PRN"].ToString();
                                dgRegPendingStudents1.DataSource = ds;
                                dgRegPendingStudents1.DataBind();
                                dgRegPendingStudents1.Columns[16].ItemStyle.CssClass = "clOff"; 
                                dgRegPendingStudents1.Columns[16].HeaderStyle.CssClass = "clOff";
                                dgRegPendingStudents1.Attributes.Add("style", "display:block");
                                lblGridName.Attributes.Add("display", "block");
                                lblGrid.Text = "* Please click on the Student Name to select the Student whose Provisional Eligibility for a particular " + lblCr.Text.ToLower() + " is to be Resolved";
                                lblGrid.Attributes.Add("style", "display:block");
                                tblDGRegPendingStudents.Attributes.Add("style", "display:block");
                                lblErrorMsg.Attributes.Add("style", "display:none");
                                //ViewState.Add("SimpleSearchDS", ds);
                            }
                            else if (ds.Tables[0].Rows[0]["Eligibility"].ToString() == "1") // Eligible
                            {
                                lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Eligible with " + lblPRNNomenclature.Text + " : " + ds.Tables[0].Rows[0]["PRN"].ToString();
                                divErrorMsg.Attributes.Add("style", "display:block");
                                lblErrorMsg.Attributes.Add("style", "display:none");
                                lblGridName.Attributes.Add("display", "none");
                                lblGrid.Attributes.Add("style", "display:none");
                            }
                            else  //Not Eligible
                            {
                                lblErrorMsg.Text = "The Student with Eligibility Form Number " + txtElgFormNo.Text.Trim() + " is already been processed and marked as Not Eligible. Hence the student cannot be reconsidered.";
                                divErrorMsg.Style.Add("display", "block");
                                lblErrorMsg.Style.Add("display", "block");
                                lblGridName.Attributes.Add("display", "none");
                                lblGrid.Attributes.Add("style", "display:none");
                            }

                        }
                        else
                        {
                            lblErrorMsg.Text = "The eligibility of the Student with Eligibility Form Number  " + txtElgFormNo.Text.Trim() + "  is not kept pending or may not be processed.Please check the status to verify.";
                            divErrorMsg.Style.Add("display", "block");
                            lblErrorMsg.Style.Add("display", "block");
                            lblGridName.Attributes.Add("display", "none");
                            lblGrid.Attributes.Add("style", "display:none");
                            if (qstrNavigate == "back")
                            {
                                divErrorMsg.Attributes.Add("style", "display:none");
                                lblErrorMsg.Attributes.Add("style", "display:none");
                                txtElgFormNo.Text = string.Empty;
                                txtPRN.Text = string.Empty;
                            }
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

        #endregion
    }
}