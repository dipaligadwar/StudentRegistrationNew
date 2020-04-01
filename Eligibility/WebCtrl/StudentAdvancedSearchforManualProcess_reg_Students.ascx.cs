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
    public partial class StudentAdvancedSearchforManualProcess_reg_Students : System.Web.UI.UserControl
    {
        #region Declaration of Variables
        protected System.Web.UI.HtmlControls.HtmlGenericControl CollegeGrid;
        protected System.Web.UI.HtmlControls.HtmlGenericControl divStudentList;
        protected System.Web.UI.HtmlControls.HtmlInputHidden hidCrMoLrnID;
        private string qstrNavigate;
        private string strUrl;
        private string gridType;
        string withOrWithoutInv1 = "";
        DataSet dsDistricts = new DataSet();
        clsCommon Common = new clsCommon();
        clsCommon CommonAcYr = new clsCommon();
        clsCache clsCache = new clsCache();
        string fkCountryID = "";

        private string AcdyearID;
        private string AcdyearText;
        InstituteRepository InstRep = new InstituteRepository();

        //**********
        string PRNumber = null;
        private string Elg_FormNo;
        string InstituteID = null;


        #endregion

        #region Properties
        public string QstrNavigate
        {
            set
            {
                qstrNavigate = value;
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

        public string StrUrl
        {
            set
            {
                strUrl = value;
            }
        }
        public string GridType
        {
            set
            {
                gridType = value;
            }
        }
 
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            clsCache.NoCache();

            Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods), this.Page);
            Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent), this.Page);

            //dgElgRegular.Visible = false;
            dgRegPendingStudents1.Visible = false;
            lblGridName.Style.Remove("display");
            lblGridName.Style.Add("display", "none");
            divDGNote.Style.Remove("display");
            divDGNote.Style.Add("display", "none");


            if (!IsPostBack)
            {
                HtmlInputHidden[] hid = new HtmlInputHidden[22];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidFacID;
                hid[3] = hidCrID;
                hid[4] = hidMoLrnID;
                hid[5] = hidPtrnID;
                hid[6] = hidBrnID;
                hid[7] = hidCrPrDetailsID;
                hid[8] = hidElgFormNo;
                hid[9] = hidElgStatusColl;
                hid[10] = hidpkStudentID;
                hid[11] = hidDOB;
                hid[12] = hidFirstName;
                hid[13] = hidLastName;
                hid[14] = hidGender;
                hid[15] = hidCollElgFlag;
                hid[16] = hidPRN;
                hid[17] = hidInv;
                hid[18] = hid_fk_AcademicYr_ID;
                hid[19] = hid_AcademicYear;
                hid[20] = hidAcademicYrText;
                hid[21] = hidIsPRNValidationRequired;


                if (Page.PreviousPage != null)
                {
                    ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

                    if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                    {
                        hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;

                    }                    
                }

                try
                {
                    hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
                }
                catch
                {
                    hidIsPRNValidationRequired.Value = "N";
                }

                Common.setHiddenVariables(ref hid);
                
                hidIsBack.Value = "False";

                DataTable dt = clsCollegeAdmissionReports.GetAcademicYear();
                CommonAcYr.fillDropDown(ddlAcademicYear, dt, "", "Year", "pk_AcademicYear_ID", "--- Select ---");

                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                // When control is transfered back to this page from ELGV2_ManualProcess_reg_Students__2.aspx page
                if (qstrNavigate == "back")
                {
                    //***********
                    hidSearchType.Value = Request.QueryString[1].ToString();
                    hidIsBack.Value = "True";

                     if (Page.PreviousPage != null)
                     {
                         ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");

                         if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                         {
                             hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                             hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                             hidCrPrDetailsID.Value = ((HtmlInputHidden)Cntp.FindControl("hidCrPrDetailsID")).Value;
                             hidElgFormNo.Value = ((HtmlInputHidden)Cntp.FindControl("hidElgFormNo")).Value;
                             hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)Cntp.FindControl("hid_fk_AcademicYr_ID")).Value;
                             hidAcademicYrText.Value = ((HtmlInputHidden)Cntp.FindControl("hidAcademicYrText")).Value;
                             hidBranchName.Value = ((HtmlInputHidden)Cntp.FindControl("hidBranchName")).Value;
                             hidGender.Value = ((HtmlInputHidden)Cntp.FindControl("hidGender")).Value;

                             hidFacID.Value = ((HtmlInputHidden)Cntp.FindControl("hidddlFaculty")).Value;
                             hidCrID.Value = ((HtmlInputHidden)Cntp.FindControl("hidddlCourse")).Value;
                             hidMoLrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidddlMoLrn")).Value;
                             hidPtrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidddlCrPtrn")).Value;
                             hidBrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidddlbranch")).Value;

                             hidLastName.Value = ((HtmlInputHidden)Cntp.FindControl("hidLastName")).Value;
                             hidFirstName.Value = ((HtmlInputHidden)Cntp.FindControl("hidFirstName")).Value;
                             hidDOB.Value = ((HtmlInputHidden)Cntp.FindControl("hidDOB")).Value;
                             string dob = ((HtmlInputHidden)Cntp.FindControl("hidDOB")).Value;

                             if (dob != "")
                             {
                                 string[] arr = new string[3];
                                 arr = dob.Split('/');
                                 dob = arr[1] + '/' + arr[0] + '/' + arr[2];
                             }

                             txtDOB.Text = dob;
                             //************
                             if (hidSearchType.Value == "Simple")
                             {
                                 hidElgFormNo.Value = ((HtmlInputHidden)Cntp.FindControl("hidElgFormNo")).Value;
                                 hidPRN.Value = ((HtmlInputHidden)Cntp.FindControl("hidPRN")).Value;
                                 hidPRNorElgFormNo.Value = ((HtmlInputHidden)Cntp.FindControl("hidPRNorElgFormNo")).Value;
                             }
                         }
                     }


                    
                    lblGridName.Attributes.Add("style", "display:none");


                    if (hidSearchType.Value == "Adv")   // When Advanced search is to be restored
                    {
                        ddlAcademicYear.Items.FindByValue(hid_fk_AcademicYr_ID.Value).Selected = true;
                        txtLastName.Text = hidLastName.Value;
                        txtFirstName.Text = hidFirstName.Value;

                        ddlGender.Items.FindByValue(hidGender.Value).Selected = true;

                        FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value);

                        if (Request.QueryString["CollElg"] == "1")
                        {
                            rbUni.Checked = true;
                            rbColl.Checked = false;
                        }
                        else if (Request.QueryString["CollElg"] == "0")
                        {
                            rbUni.Checked = false;
                            rbColl.Checked = true;
                        }

                        //if (Request.QueryString["Inv"] == "1")
                        //{
                        //    rbWithInv.Checked = true;
                        //    rbWithoutInv.Checked = false;
                        //    hidWithOrWithoutInv.Value = "WithInv";
                        //}
                        //else if (Request.QueryString["Inv"] == "0")
                        //{
                        //    rbWithoutInv.Checked = true;
                        //    rbWithInv.Checked = false;
                        //    hidWithOrWithoutInv.Value = "WithoutInv";
                        //}

                        hidSearchType.Value = "Adv";
                        lbl_AdvSearch.InnerText = "Simple Search";
                        hidInstName.Value = InstRep.InstituteName(hidUniID.Value, hidInstID.Value);

                        // Filling Gridview
                        fnDisplayRegGrid();
                        trbtnSearch.Style.Add("display", "block");

                    }
                    else    // When Simple search is to be restored
                    {
                        hidSearchType.Value = "Simple";
                        lbl_AdvSearch.InnerText = "Advanced Search";

                        //if (hidIsBlank.Value != "")
                        if (hidPRNorElgFormNo.Value == "ElgFormNo")
                        {
                            txtElgFormNo.Text = hidElgFormNo.Value;
                        }
                        else if (hidPRNorElgFormNo.Value == "PRN")
                        {
                            txtPRN.Text = hidPRN.Value;
                        }
                        //if (Request.QueryString["Inv"] == "1")
                        //{
                        //    rbWithInv_Simple.Checked = true;
                        //    rbWithoutInv_Simple.Checked = false;
                        //}


                        //else if (Request.QueryString["Inv"] == "0")
                        //{
                        //    rbWithoutInv_Simple.Checked = true;
                        //    rbWithInv_Simple.Checked = false;
                        //}

                        FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value);

                        hidInstName.Value = InstRep.InstituteName(hidUniID.Value, hidInstID.Value);
                        
                        // Filling Gridview with single record
                        fnFetchStudent();
                    }

                }
                else
                {
                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                    hidInstName.Value = InstRep.InstituteName(hidUniID.Value, hidInstID.Value);

                    FillFaculty();                   
                }
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            }
            else
            {
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                FillFacultyWiseCourseCoursePart(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value);                              
            }

            btnClear.Attributes.Add("onclick", " return fnClearSearchCriteria();");


            if (hidSearchType.Value == "Simple")
            {
                DivAdvanceSearch.Attributes.Add("style", "display:none");
                divSimpleSearch.Style.Add("display", "block");
                lbl_AdvSearch.InnerText = "Advanced Search";

            }
            else if (hidSearchType.Value == "Adv")
            {
                DivAdvanceSearch.Attributes.Add("style", "display:block");
                divSimpleSearch.Style.Add("display", "none");
                lbl_AdvSearch.InnerText = "Simple Search";
            }
            else
            {

            }

            string a = hidIsPRNValidationRequired.Value;

        }       

        private void fnDisplayRegGrid()
        {
            DataSet ds = new DataSet();
            DataView DV = new DataView();

            hid_AcademicYear.Value = ddlAcademicYear.SelectedItem.ToString();
            hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;
            hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.Text;

            try
            {

                    //if (rbWithInv.Checked == true)
                    //{
                    //    hidInv.Value = "1";

                    //    if (rbColl.Checked == true)
                    //    {
                    //        hidElgStatusColl.Value = "0";
                    //        ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_RegStu(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hid_fk_AcademicYr_ID.Value);
                    //        DV.Table = ds.Tables[0];
                    //        lblGridName.Text = "List of students whose Eligiblity is marked by "+ lblCollege.Text +".";
                    //    }
                    //    if (rbUni.Checked == true)
                    //    {
                    //        hidElgStatusColl.Value = "1";
                    //        ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_RegStu(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hid_fk_AcademicYr_ID.Value);
                    //        DV.Table = ds.Tables[0];
                    //        lblGridName.Text = "List of students whose Eligiblity is marked by " + lblUniversity.Text + ".";
                    //    }
                    //}


                    //else if (rbWithoutInv.Checked == true)
                    //{
                        hidInv.Value = "0";

                        if (rbColl.Checked == true)
                        {
                            hidElgStatusColl.Value = "0";
                            ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_RegStu_bypassInv(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hid_fk_AcademicYr_ID.Value);
                            DV.Table = ds.Tables[0];
                            lblGridName.Text = "List of students whose Eligiblity is marked by " + lblCollege.Text + ".";
                        }
                        if (rbUni.Checked == true)
                        {
                            hidElgStatusColl.Value = "1";
                            ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List_RegStu_bypassInv(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value, hidElgStatusColl.Value, hid_fk_AcademicYr_ID.Value);
                            DV.Table = ds.Tables[0];
                            lblGridName.Text = "List of students whose Eligiblity is marked by " + lblUniversity.Text + ".";
                        }
                   // }


                    if (hidFacName.Value.Equals(string.Empty))
                    {
                        hidFacName.Value = ddlFaculty.SelectedItem.Text;
                        hidCrName.Value = ddlCourse.SelectedItem.Text;
                        hidMOLName.Value = ddlMoLrn.SelectedItem.Text;
                        hidPattern.Value = ddlCrPtrn.SelectedItem.Text;
                        hidBrName.Value = ddlBranch.SelectedItem.Text;
                        hidAcYrName.Value = ddlAcademicYear.SelectedItem.Text;
                    }


                    // Code Added By Pankaj on 28/10/2010
                    hidFacIDToRestore.Value = ddlFaculty.SelectedValue;
                    hidCrIDToRestore.Value = ddlCourse.SelectedValue;
                    hidMoLrnIDToRestore.Value = ddlMoLrn.SelectedValue;
                    hidPtrnIDToRestore.Value = ddlCrPtrn.SelectedValue;
                    hidBrnIDToRestore.Value = ddlBranch.SelectedValue;

                    ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
                    ((Label)Cntph1.FindControl("lblSubHeader")).Text = "  for " + hidInstName.Value;
                    
                    if(ddlFaculty.SelectedValue != "0")
                    {
                        ((Label)Cntph1.FindControl("lblSubHeader")).Text = ((Label)Cntph1.FindControl("lblSubHeader")).Text + " - " + ddlFaculty.SelectedItem.Text;
                    }
                    if ( ddlCourse.SelectedValue != "0")
                    {
                        ((Label)Cntph1.FindControl("lblSubHeader")).Text = ((Label)Cntph1.FindControl("lblSubHeader")).Text + " - " + ddlCourse.SelectedItem.Text;
                    }
                    if (ddlMoLrn.SelectedValue != "0")
                    {
                        ((Label)Cntph1.FindControl("lblSubHeader")).Text = ((Label)Cntph1.FindControl("lblSubHeader")).Text + " - " + ddlMoLrn.SelectedItem.Text;
                    }
                    if (ddlCrPtrn.SelectedValue != "0")
                    {
                        ((Label)Cntph1.FindControl("lblSubHeader")).Text = ((Label)Cntph1.FindControl("lblSubHeader")).Text + " - " + ddlCrPtrn.SelectedItem.Text;
                    }
                    //if (ddlBranch.SelectedValue != "0")   commented by Pankaj 
                    if (ddlBranch.SelectedItem.Text != "--- Select ---")
                    {
                        ((Label)Cntph1.FindControl("lblSubHeader")).Text = ((Label)Cntph1.FindControl("lblSubHeader")).Text + " - " + ddlBranch.SelectedItem.Text;
                    }
                    ((Label)Cntph1.FindControl("lblSubHeader")).Text = ((Label)Cntph1.FindControl("lblSubHeader")).Text + " - [Academic Year " + ddlAcademicYear.SelectedItem.Text + "]";



                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ViewState["SortExpression"] != null)
                    {
                        DV.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();

                    }

                    try
                    {
                        dgRegPendingStudents1.DataSource = DV;
                        dgRegPendingStudents1.DataBind();
                    }
                    catch
                    {
                        dgRegPendingStudents1.PageIndex = 0;
                        dgRegPendingStudents1.DataBind();
                    }

                    //
                    dgRegPendingStudents1.Visible = true;
                    tblDGRegPendingStudents.Style.Remove("display");
                    tblDGRegPendingStudents.Style.Add("display", "block");
                    lblGridName.Style.Remove("display");
                    lblGridName.Style.Add("display", "block");
                    divDGNote.Style.Remove("display");
                    divDGNote.Style.Add("display", "block");
                    //divAcademicYr.Style.Add("display", "none");
                    tblSelect.Style.Add("display", "block");
                    //
                }
                else
                {
                    //
                    dgRegPendingStudents1.Visible = false;
                    tblDGRegPendingStudents.Style.Remove("display");
                    tblDGRegPendingStudents.Style.Add("display", "none");
                    lblGridName.Text = "There are no Students satisfying the above search criteria whose Eligibility is kept Pending...";
                    lblGridName.Style.Remove("display");
                    lblGridName.Style.Add("display", "block");
                    divDGNote.Style.Remove("display");
                    divDGNote.Style.Add("display", "none");
                    //
                }

                ds.Clear();
                ds.Dispose();
                ds = null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        public void FillFaculty()
        {
            DataTable oDT = new DataTable();
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

        public void FillFacultyWiseCourseCoursePart(string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID)
        {
            clsCommon common = new clsCommon();            
            DataTable dt;
            ddlFaculty.Items.Clear();

            try
            {

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
                          
            dt.Dispose();
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
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
            hid_AcademicYear.Value = ddlAcademicYear.SelectedItem.Text;
            hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;

            if (rbColl.Checked == true)
            {
                hidElgStatusColl.Value = "0";
            }
            else
            {
                hidElgStatusColl.Value = "1";
            }
            //if (rbWithInv.Checked == true)
            //{
            //    hidInv.Value = "1";
            //    hidWithOrWithoutInv.Value = "WithInv";
            //}
            //else
            //{
                hidInv.Value = "0";
                hidWithOrWithoutInv.Value = "WithoutInv";
           // }

            fnDisplayRegGrid();
        }        

        #region dgRegPendingStudents1 Events       
        
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
                hidPRN.Value = row.Cells[4].Text.Trim();
                hidpkYear.Value = row.Cells[8].Text.Trim();
                hidpkStudentID.Value = row.Cells[9].Text.Trim();
                hidFacID.Value = row.Cells[10].Text.Trim();
                hidCrID.Value = row.Cells[11].Text.Trim();
                hidMoLrnID.Value = row.Cells[12].Text.Trim();
                hidPtrnID.Value = row.Cells[13].Text.Trim();
                hidBrnID.Value = row.Cells[14].Text.Trim();
                hidCrPrDetailsID.Value = row.Cells[15].Text.Trim();

              

                if (hidSearchType.Value == "Simple")
                {
                    Server.Transfer("ELGV2_ManualProcess_reg_Students__2.aspx?Search=" + hidSearchType.Value + "&withORWithoutInv=0");
                }
                else
                {
                    //if (rbWithInv.Checked == true)
                    //    withOrWithoutInv1 = "1";
                    //else if (rbWithoutInv.Checked == true)
                    //    withOrWithoutInv1 = "0";

                    if (hidWithOrWithoutInv.Value == "WithInv")
                        withOrWithoutInv1 = "1";
                    else if (hidWithOrWithoutInv.Value == "WithoutInv")
                        withOrWithoutInv1 = "0";

                    withOrWithoutInv1 = "0";
                    Server.Transfer(strUrl + "&withOrWithoutInv1=" + withOrWithoutInv1);
                }
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

            if (hidSearchType.Value == "Adv")
            {
                fnDisplayRegGrid();
            }
            else
            {
                fnFetchStudent();
            }
        }

        #endregion

        protected void btnAcYr_Click(object sender, EventArgs e)
        {
            //btnAcYr.Attributes.Add("onclick", "return fnClearSearchCriteria();");

            hidAcademicYrText.Value = ddlAcademicYear.SelectedItem.Text;            
            hid_fk_AcademicYr_ID.Value = ddlAcademicYear.SelectedItem.Value;

            if (hid_fk_AcademicYr_ID.Value == "0")
            {                
                string strScript = "<script language='JavaScript'>alert('Please Select Academic Year')</script>";
                Page.RegisterStartupScript("PopUp", strScript);


                //divAcademicYr.Style.Add("display", "block");
                tblSelect.Style.Add("display", "block");
                trbtnSearch.Style.Add("display", "none");
                //btnAcYr.Attributes.Add("onclick", "return fnClearSearchCriteria();");
            }
            else
            {
                //divAcademicYr.Style.Add("display", "none");
                tblSelect.Style.Add("display", "block");
                trbtnSearch.Style.Add("display", "block");
                //btnAcYr.Attributes.Add("onclick", "return fnClearSearchCriteria();");
            }
        }

       
        //******************


        #region btnSimpleSearch_Click

        protected void btnSimpleSearch_Click(object sender, System.EventArgs e)
        {
            fnFetchStudent();
        }

        #endregion

        #region Fetch Student Details

        private void fnFetchStudent()
        {
            {
                if (txtElgFormNo.Text != "")
                {
                    Elg_FormNo = txtElgFormNo.Text.Trim();
                    hidIsBlank.Value = Elg_FormNo;
                }

                else
                {
                    Elg_FormNo = "0-0-0-0";
                    hidIsBlank.Value = "";
                }

                int cnt = 0;
                string str = Elg_FormNo;
                int pos = str.IndexOf('-');
                string[] arr = new string[] { "0", "0", "0", "0" };
                Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");

                if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                    PRNumber = txtPRN.Text.Trim();
                hidPRN.Value = PRNumber;
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
                    arr = Elg_FormNo.Split('-');   //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
                    for (int i = 0; i < 4; i++)
                    {
                        if (arr[i] == "")
                            arr[i] = "0";
                    }
                }
                DataSet ds = new DataSet();
                try
                {

                    //if (rbWithInv_Simple.Checked == true)
                    //{
                    //    ds = clsEligibilityDBAccess.Check_IA_Student_Exists_RegStu(arr[0], arr[1], arr[2], arr[3], txtPRN.Text, hidInstID.Value, txtApplicationFrmNo.Text.Trim());
                    //    hidWithOrWithoutInv.Value = "WithInv";
                    //    hidInv.Value = "1";
                    //}

                    //else if (rbWithoutInv_Simple.Checked == true)
                    //{
                        ds = clsEligibilityDBAccess.Check_IA_Student_Exists_bypassInv_RegStu(arr[0], arr[1], arr[2], arr[3], txtPRN.Text, hidInstID.Value, txtApplicationFrmNo.Text.Trim());
                        hidWithOrWithoutInv.Value = "WithoutInv";

                        hidInv.Value = "0";
                  //  }

                    if ((ds.Tables == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0 || ds.Tables[0] == null))
                    {

                        if (hidIsBack.Value != "True")
                        {
                            //***************
                            dgRegPendingStudents1.Visible = false;
                            tblDGRegPendingStudents.Style.Remove("display");
                            tblDGRegPendingStudents.Style.Add("display", "none");
                            lblGridName.Text = "The Student's data with Eligibility Form Number " + txtElgFormNo.Text.Trim() + "  might have processed or haven't uploaded yet.So please check the status to verify.";
                            lblGridName.Style.Remove("display");
                            lblGridName.Style.Add("display", "block");
                            divDGNote.Style.Remove("display");
                            divDGNote.Style.Add("display", "none");
                        }
                        else if (hidIsBack.Value == "True")
                        {   
                            // if Student's eligibility is just processed and Simple search is restored and no matching record is found
                            txtElgFormNo.Text = "";
                            txtPRN.Text = "";
                            txtApplicationFrmNo.Text = "";
                            hidIsBack.Value = "False";
                        }

                    }
                    else if (ds.Tables[0].Rows.Count > 0)
                    {

                        hidElgFormNo.Value = txtElgFormNo.Text.Trim();
                        hidAppFormNo.Value = ds.Tables[0].Rows[0]["AdmissionFormNo"].ToString();
                        hidpkStudentID.Value = ds.Tables[0].Rows[0]["pkStudentID"].ToString();
                        hidpkYear.Value = ds.Tables[0].Rows[0]["pkYear"].ToString();
                        hidpkFacID.Value = ds.Tables[0].Rows[0]["pkFacID"].ToString();
                        hidpkCrID.Value = ds.Tables[0].Rows[0]["pkCrID"].ToString();
                        hidpkMoLrnID.Value = ds.Tables[0].Rows[0]["pkMoLrnID"].ToString();
                        hidpkPtrnID.Value = ds.Tables[0].Rows[0]["pkPtrnID"].ToString();
                        hidpkBrnID.Value = ds.Tables[0].Rows[0]["pkBrnID"].ToString();
                        hidpkCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pkCrPrDetails"].ToString();
                        hidCollElgFlag.Value = ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString();
                        hidCollElgFlagReason.Value = ds.Tables[0].Rows[0]["Reason"].ToString();
                        hidPRN.Value = ds.Tables[0].Rows[0]["PRN"].ToString();
                        hid_fk_AcademicYr_ID.Value = ds.Tables[0].Rows[0]["fkAcademicYearID"].ToString();

                        //*****************
                        dgRegPendingStudents1.Visible = true;
                        tblDGRegPendingStudents.Style.Remove("display");
                        tblDGRegPendingStudents.Style.Add("display", "block");
                        lblGridName.Style.Remove("display");
                        lblGridName.Style.Add("display", "block");
                        divDGNote.Style.Remove("display");
                        divDGNote.Style.Add("display", "block");
                        //divAcademicYr.Style.Add("display", "none");
                        tblSelect.Style.Add("display", "block");


                        dgRegPendingStudents1.DataSource = ds;
                        dgRegPendingStudents1.DataBind();

                        //lblGrid.Text = "Please click on the Student Name to select the Student whose Eligibility for a particular " + lblCr.Text + " is to be processed";
                        tblDGRegPendingStudents.Attributes.Add("style", "display:block");
                        //******
                        lblGridName.Style.Add("display", "none");

                        if (hidCollElgFlag.Value == "4")
                        {
                            hidElgStatusColl.Value = "1";
                        }

                        else
                        {
                            hidElgStatusColl.Value = "0";
                        }

                        if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "1")
                        {
                            hidCollElgFlag.Value = "1";
                            hidCollElgFlagReason.Value = ds.Tables[0].Rows[0]["Reason"].ToString();

                        }

                        if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "2")
                        {
                            hidCollElgFlag.Value = "2";


                        }
                        if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "3")
                        {
                            hidCollElgFlag.Value = "3";


                        }
                        if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "4")
                        {
                            hidCollElgFlag.Value = "4";


                        }
                        if (ds.Tables[0].Rows[0]["CollegeEligibilityFlag"].ToString() == "5")
                        {
                            hidCollElgFlag.Value = "5";

                        }

                        hidCollElgFlagReason.Value = ds.Tables[0].Rows[0]["Reason"].ToString();

                        // Commented by Shivani Server.Transfer("ELGV2_ManualProcess_reg_Students__2.aspx?Search=" + searchType.ToString() + "&withORWithoutInv=" + withORWithoutInv.ToString());


                    }

                    else
                    {
                        //***************
                        dgRegPendingStudents1.Visible = false;
                        tblDGRegPendingStudents.Style.Remove("display");
                        tblDGRegPendingStudents.Style.Add("display", "none");
                        lblGridName.Text = "Please Enter the Valid Eligibility Form Number.";
                        lblGridName.Style.Remove("display");
                        lblGridName.Style.Add("display", "block");
                        divDGNote.Style.Remove("display");
                        divDGNote.Style.Add("display", "none");

                    }
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

        }
        #endregion


    }
}