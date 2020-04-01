using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;
using System.Collections;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_StudentAdditionalPapers : System.Web.UI.Page
    {
        #region Global Varriables

        InstituteRepository oInstituteRepository = new InstituteRepository();
        DataTable oDT = null; clsCommon oCommon = null;
        private string pk_Uni_ID = Convert.ToString(clsGetSettings.UniversityID);
        clsElgStudent srv = new clsElgStudent();
        clsPaperChange oPaper = new clsPaperChange();
        clsCache oCache = new clsCache();
        string sPaperCourse = string.Empty;
        Hashtable oHS = null;
        clsUser user;
        CheckBox oRDButAdditionalPapers = null;
        Label oLabelAdditionalPapers = null;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DivNoteMsg.Style.Add("display", "block");
                divStudentSearch.Style.Add("display", "block");
                chk_Papers.Style.Add("display", "none");
                divselectPpmsg.Style.Add("display", "none");
                divDispAddPaper.Style.Add("display", "none");
            }           
        }
        #endregion

        #region btnSimpleSearch_Click
        protected void btnSimpleSearch_Click(object sender, EventArgs e)
        {
            hidPRN.Value = txtPRN.Text.Trim();
            hidElgNo.Value = txtElgFormNo.Text.Trim();
            hidAcademicYear_ID.Value = Session["AcademicYearID"].ToString();
            SearchStudent();
        }
        #endregion

        #region SearchStudent
        public void SearchStudent()
        {
            try
            {
                DataTable dt = srv.SearchStudentForAddPaper(hidPRN.Value, hidElgNo.Value, hidAcademicYear_ID.Value);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DivNoteMsg.Style.Add("display", "block");
                    divStudentSearch.Style.Add("display", "block");
                    divDisplayData.Style.Add("display", "block");
                    divDispAddPaper.Style.Add("display", "none");
                    lblErrorMsg.Text = string.Empty;
                    GV_SrchStud.DataSource = dt;
                    GV_SrchStud.DataBind();
                }
                else
                {
                    divDisplayData.Style.Add("display", "none");
                    if (txtElgFormNo.Text != string.Empty)
                    {
                        lblErrorMsg.Text = "The Eligibility Form Number  " + txtElgFormNo.Text.Trim() + "  does not exists. Please entered proper Eligibility Form Number.";
                    }
                    else if (txtPRN.Text != string.Empty)
                    {
                        lblErrorMsg.Text = "The PRN Number  " + txtPRN.Text.Trim() + "  does not exists. Please entered proper PRN Number.";
                    }

                    GV_SrchStud.DataSource = null;
                    GV_SrchStud.DataBind();
                    dt = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GV_SrchStud_RowCommand

        protected void divDisplayData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                GridView gv = (GridView)sender;
                int index = Convert.ToInt32(e.CommandArgument);

                hidPRN.Value = gv.Rows[index].Cells[2].Text;
                hid_pk_Year.Value = gv.Rows[index].Cells[4].Text;
                hid_pk_Student_ID.Value = gv.Rows[index].Cells[5].Text;
                hidUniID.Value = gv.Rows[index].Cells[7].Text;
                hidFacultyID.Value = gv.Rows[index].Cells[8].Text;
                hidCourseID.Value = gv.Rows[index].Cells[9].Text;
                hidMolrnID.Value = gv.Rows[index].Cells[10].Text;
                hidPtrnID.Value = gv.Rows[index].Cells[11].Text;
                hidBrnID.Value = gv.Rows[index].Cells[12].Text;
                hidCrPrDetailsID.Value = gv.Rows[index].Cells[13].Text;
                hidCrPrChID.Value = gv.Rows[index].Cells[14].Text;
                hidCrPr_Seq.Value = gv.Rows[index].Cells[15].Text;
                hidCrPrCh_Seq.Value = gv.Rows[index].Cells[16].Text;    
                hidAcademicYear_ID.Value = gv.Rows[index].Cells[17].Text;
                hidInstID.Value = gv.Rows[index].Cells[18].Text;

                DivNoteMsg.Style.Add("display", "none");
                divStudentSearch.Style.Add("display", "none");
                chk_Papers.Style.Add("display", "none");
                divselectPpmsg.Style.Add("display", "none");
                divDispAddPaper.Style.Add("display", "none");
                DisplayPreviousCoursePartDetails();
            }
        }

        #endregion

        #region Function to display Previous Course Details
        private void DisplayPreviousCoursePartDetails()
        {
            DataTable oDtPrev = new DataTable();
            oDtPrev = oPaper.Get_Previous_CoursePartDetailsforAddPaperChange(hidUniID.Value,hidInstID.Value, hid_pk_Year.Value, hid_pk_Student_ID.Value, hidFacultyID.Value, hidCourseID.Value,hidMolrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hidCrPrChID.Value, hidPRN.Value);

            if (oDtPrev != null && oDtPrev.Rows.Count > 0)
            {
                rdPrevCoursePartList.DataSource = oDtPrev;
                rdPrevCoursePartList.DataTextField = "CourseName";
                rdPrevCoursePartList.DataValueField = "Value";
                rdPrevCoursePartList.DataBind();

                DivNoteMsg.Style.Add("display", "none");
                divStudentSearch.Style.Add("display", "none");
                chk_Papers.Style.Add("display", "block");
                divselectPpmsg.Style.Add("display", "block");
                divDispAddPaper.Style.Add("display", "none");
            }

            if (oDtPrev != null)
                oDtPrev = null;
        }
        #endregion

        #region Function to display Additional Papers that are opted for previous CrPr/Tr for Add Paper Change
        private void DisAddpaperOpted_ForAddPaperChange()
        {
            DataTable oDtAddPp = new DataTable();
            Hashtable oHS = new Hashtable();

            oHS.Add("pk_Uni_ID", hidUniID.Value);
            oHS.Add("pk_Institute_ID", hidInstID.Value);
            oHS.Add("pk_Year", hid_pk_Year.Value);
            oHS.Add("pk_Student_ID", hid_pk_Student_ID.Value);
            oHS.Add("pk_Fac_ID", hidFacultyID.Value);
            oHS.Add("pk_Cr_ID", hidCourseID.Value);
            oHS.Add("pk_MoLrn_ID", hidMolrnID.Value);
            oHS.Add("pk_Ptrn_ID", hidPtrnID.Value);
            oHS.Add("pk_Brn_ID", hidBrnID.Value);
            oHS.Add("CrPr_Seq", hidCrPr_Seq.Value);
            oHS.Add("pk_CrPr_Details_ID", hidCrPrDetailsID.Value);
            oHS.Add("pk_CrPrCh_ID", hidCrPrChID.Value);
            oHS.Add("CrPrCh_Seq", hidCrPrCh_Seq.Value);

            oDtAddPp = oPaper.DisAddpaperOpted_ForAddPaperChange(oHS);

            if (oDtAddPp != null && oDtAddPp.Rows.Count > 0)
            {
                lblDisplayPreviousCourseName.Visible = true;
                GV_DisplayAdditionalPaper.Visible = true;
                GV_DisplayAdditionalPaper.DataSource = oDtAddPp;
                GV_DisplayAdditionalPaper.DataBind();
            }
            else
            {
                lblDisplayPreviousCourseName.Visible = false;
                GV_DisplayAdditionalPaper.Visible = false;
            }
        }
        #endregion


        #region btnBack_Click
        protected void btnBack_Click(object sender, EventArgs e)
        {
            DivNoteMsg.Style.Add("display", "block");
            divStudentSearch.Style.Add("display", "block");
            divDisplayData.Style.Add("display", "block");
            divDispAddPaper.Style.Add("display", "none");
            divselectPpmsg.Style.Add("display", "none");
            chk_Papers.Style.Add("display", "none");
            lblErrorMsg.Text = string.Empty;
            lblNote.Text = "";
        }
        #endregion

        #region btnProceed_Click
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            string[] SplitIDs = rdPrevCoursePartList.SelectedItem.Value.Split('-');

            hid_Prev_pk_Fac_ID.Value = SplitIDs[0];
            hid_Prev_pk_Cr_ID.Value = SplitIDs[1];
            hid_Prev_pk_MoLrn_ID.Value = SplitIDs[2];
            hid_Prev_pk_Ptrn_ID.Value = SplitIDs[3];
            hid_Prev_pk_Brn_ID.Value = SplitIDs[4];
            hid_Prev_pk_CrPr_Details_ID.Value = SplitIDs[5];
            hid_Prev_CoursePartChild.Value = SplitIDs[6];
            hid_Prev_CoursePart_Opted.Value = SplitIDs[7];
            hid_Prev_CoursePart_Admission_Type.Value = SplitIDs[8];

            #region Display Additional Paper that could be selected by student

            DisplayStudentAdditionalPapersForAddPaperChange();

            #endregion  
        }
        #endregion

        #region Function to display student papers For Additional Paper Change
        /// <summary>
        /// Display student papers For Additional Paper Change.
        /// </summary>
        private void DisplayStudentAdditionalPapersForAddPaperChange()
        {
            btnProceed.Enabled = true;
            lblNote.Visible = false;
            lblNote.Text = string.Empty;

            DivNoteMsg.Style.Add("display", "none");
            divStudentSearch.Style.Add("display", "none");
            divDisplayGrid.Style.Add("display", "none");
            chk_Papers.Style.Add("display", "none");
            divselectPpmsg.Style.Add("display", "none");
            divDispAddPaper.Style.Add("display", "block");

            Hashtable OHt = new Hashtable();
            OHt.Add("pk_Uni_ID", Classes.clsGetSettings.UniversityID);
            OHt.Add("pk_Institute_ID", hidInstID.Value);
            OHt.Add("pk_Year", hid_pk_Year.Value);
            OHt.Add("pk_Student_ID", hid_pk_Student_ID.Value);
            OHt.Add("Prev_pk_Fac_ID", hid_Prev_pk_Fac_ID.Value);
            OHt.Add("Prev_pk_Cr_ID", hid_Prev_pk_Cr_ID.Value);
            OHt.Add("Prev_pk_MoLrn_ID", hid_Prev_pk_MoLrn_ID.Value);
            OHt.Add("Prev_pk_Ptrn_ID", hid_Prev_pk_Ptrn_ID.Value);
            OHt.Add("Prev_pk_Brn_ID", hid_Prev_pk_Brn_ID.Value);
            OHt.Add("Prev_fk_CrPr_Details_ID", hid_Prev_pk_CrPr_Details_ID.Value);
            OHt.Add("Prev_pk_CrPrCh_ID", hid_Prev_CoursePartChild.Value);
            OHt.Add("Prev_CoursePart_Admission_Type", hid_Prev_CoursePart_Admission_Type.Value);
            OHt.Add("PRN_Number", hidPRN.Value);

            DataTable oDT = new DataTable();
            DataTable oDtAddPp = new DataTable();
            oDT = clsPaperChange.GetAdditionalPaperForAddPaperChange(OHt);
            //oDtAddPp = oPaper.DisAddpaperOpted_ForAddPaperChange(oHSa);
            if (oDT.Rows.Count > 0)
            {
                if (sPaperCourse != string.Empty)
                {
                    lblCourseName.Text = "<span class='errorNote'>List of not opted papers for : " + sPaperCourse + "</span><br>";
                }
                chk_Papers.Visible = true;

                chkPaperList.DataSource = oDT;
                chkPaperList.DataValueField = "PaperID";
                chkPaperList.DataTextField = "PaperName";
                chkPaperList.DataBind();   
                        
                for (int i = 0; i < oDT.Rows.Count; i++)
                {
                        if (Convert.ToString(oDT.Rows[i]["PpSelected"]) == "Y") 
                        {
                            chkPaperList.Items[i].Selected = true;
                        }
                }

                if (Convert.ToString(oDT.Rows[0]["IsPpChangeAllowed"]) == "N")
                {
                    btnProceed.Enabled = false;
                    lblCourseName.CssClass = "errorNote";
                    lblCourseName.Text = "Additional Paper change not allowed for selected term <br> because exam result is already existed"; 
                }
            }
            else
            {
                chk_Papers.Visible = false;
                btnProceed.Enabled = false;
                lblCourseName.CssClass = "errorNote";
                lblCourseName.Text = "Additional Papers not available for selection.";
            }
        }
        #endregion       

        #region Create Hashtable
        /// <summary>
        /// Create hash table.
        /// </summary>
        /// <returns>Hash table.</returns>
        private Hashtable CreateHashTable()
        {
            user = (clsUser)Session["user"];

            oHS = new Hashtable();
            oHS.Add("pk_Uni_ID", Classes.clsGetSettings.UniversityID);
            oHS.Add("pk_Institute_ID", hidInstID.Value);
            oHS.Add("pk_Year", hid_pk_Year.Value);
            oHS.Add("pk_Student_ID", hid_pk_Student_ID.Value);
            oHS.Add("pk_Fac_ID", hidFacultyID.Value);
            oHS.Add("pk_Cr_ID", hidCourseID.Value);
            oHS.Add("pk_MoLrn_ID", hidMolrnID.Value);
            oHS.Add("pk_Ptrn_ID", hidPtrnID.Value);
            oHS.Add("pk_Brn_ID", hidBrnID.Value);
            oHS.Add("fk_CrPr_Details_ID", hidCrPrDetailsID.Value);
            oHS.Add("CrPr_Seq", hidCrPr_Seq.Value);
            oHS.Add("CrPrCh_Seq", hidCrPrCh_Seq.Value);
            oHS.Add("pk_CrPrCh_ID", hidCrPrChID.Value);
            oHS.Add("Prev_pk_Fac_ID", hid_Prev_pk_Fac_ID.Value);
            oHS.Add("Prev_pk_Cr_ID", hid_Prev_pk_Cr_ID.Value);
            oHS.Add("Prev_pk_MoLrn_ID", hid_Prev_pk_MoLrn_ID.Value);
            oHS.Add("Prev_pk_Ptrn_ID", hid_Prev_pk_Ptrn_ID.Value);
            oHS.Add("Prev_pk_Brn_ID", hid_Prev_pk_Brn_ID.Value);
            oHS.Add("Prev_fk_CrPr_Details_ID", hid_Prev_pk_CrPr_Details_ID.Value);
            oHS.Add("Prev_pk_CrPrCh_ID", hid_Prev_CoursePartChild.Value);
            oHS.Add("Prev_CoursePart_Opted", hid_Prev_CoursePart_Opted.Value);
            oHS.Add("Prev_CoursePart_Admission_Type", hid_Prev_CoursePart_Admission_Type.Value);
            oHS.Add("PRN_Number", hidPRN.Value);
            oHS.Add("Papers_IDs", hid_Papers.Value);
            oHS.Add("fk_AcademicYear_ID", hidAcademicYear_ID.Value);
            oHS.Add("Prev_CrPr_Seq", "0");
            oHS.Add("Prev_CrPrCh_Seq", "0");
            oHS.Add("Created_By", user.User_ID);
            
            return oHS;
        }
        #endregion

        #region btnBack1_Click
        protected void btnBack1_Click(object sender, EventArgs e)
        {
            DivNoteMsg.Style.Add("display", "none");
            divStudentSearch.Style.Add("display", "none");
            chk_Papers.Style.Add("display", "block");
            divselectPpmsg.Style.Add("display", "block");
            divDispAddPaper.Style.Add("display", "none");
            lblNote.Text = "";
        }
        #endregion
        #region Button Save Click
        /// <summary>
        /// Save button click event.
        /// </summary>
        protected void Save_Click(object sender, EventArgs e)
        {
                int i = 0;
                string flag = string.Empty;
                string sPapers = string.Empty;
                string sSelectedPapers = string.Empty;

                for (i = 0; i < chkPaperList.Items.Count; i++)
                {
                    if (chkPaperList.Items[i].Selected)
                    {
                        sPapers += chkPaperList.Items[i].Value + ",";
                        sSelectedPapers += chkPaperList.Items[i].Text + ", ";
                    }
                }

                if (sPapers.LastIndexOf(',') > -1)
                {
                    sPapers = sPapers.Substring(0, sPapers.LastIndexOf(','));
                }

                if (sSelectedPapers.LastIndexOf(',') > -1)
                {
                    sSelectedPapers = sSelectedPapers.Substring(0, sSelectedPapers.LastIndexOf(','));
                }

                hid_Papers.Value = sPapers;
                hid_SelectedPapers.Value = sSelectedPapers;

                oHS = CreateHashTable();
                clsPaperChange clsPaperChange = new clsPaperChange();
                flag = clsPaperChange.AddSelectedAdditionalPaperForAddPaperChange(oHS);

                if (flag != "Y")
                {
                    lblNote.Visible = true;
                    lblNote.CssClass = "errorNote";
                    lblNote.Text = "Information Can not be Processed<br> If you get this message again please contact ADMINSTRATOR";
                }
                else
                {
                    lblNote.Visible = true;
                    lblNote.CssClass = "saveNote";
                    lblNote.Text = "Information Saved Successfully";
                }
        }
        #endregion
    }
}