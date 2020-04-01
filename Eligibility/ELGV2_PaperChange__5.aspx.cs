using System;
using System.Collections;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;


namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperChange__5 : System.Web.UI.Page
    {
        #region Variable Declaration
        clsCache oCache = new clsCache();
        clsCommon oCommon = new clsCommon();       
        Hashtable oHS = null;
        string sPrev_CoursePart_Opted = string.Empty;
        DataTable oDtAddPp = new DataTable();
        string sPaperCourse = string.Empty;
        #endregion

        #region Property for Refresh functionality
        private bool _refreshState;
        private bool _isRefresh;

        /// <summary>
        /// Gets a value indicating whether page is refresh.
        /// </summary>
        /// <value>Whether page is refresh.</value>
        public bool IsRefresh
        {
            get
            {
                return _isRefresh;
            }
        }
        #endregion

        #region Overriding LoadViewState and SaveViewState Function to detect Refresh
        /// <summary>
        /// Function to override LoadViewState.
        /// </summary>
        /// <param name="savedState">Saved state as an Object.</param>
        protected override void LoadViewState(object savedState)
        {
            object[] allStates = (object[])savedState;
            base.LoadViewState(allStates[0]);
            _refreshState = (bool)allStates[1];
            if (Session["__ISREGDPAPEREXEMPTED"] != null && Session["__ISREGDPAPEREXEMPTED"].ToString() != string.Empty)
            {
                _isRefresh = _refreshState == (bool)Session["__ISREGDPAPEREXEMPTED"];
            }
            else
            {
                Response.Redirect(clsGetSettings.SitePath + "Logout.aspx");
            }
        }

        /// <summary>
        /// Function to override SaveViewState.
        /// </summary>
        /// <returns>Returns all states as an Object.</returns>
        protected override object SaveViewState()
        {
            Session["__ISREGDPAPEREXEMPTED"] = _refreshState;
            object[] allStates = new object[2];
            allStates[0] = base.SaveViewState();
            allStates[1] = !_refreshState;
            return allStates;
        }
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["__ISREGDPAPEREXEMPTED"] != null && !(bool)Session["__ISREGDPAPEREXEMPTED"])
            {
                _refreshState = true;
            }

            // No cache is used for clearing cache when user clicks BACK button.
            oCache.NoCache();

            if (!IsPostBack)
            {
                #region Set Hidden Variables

                HtmlInputHidden[] hid = new HtmlInputHidden[22];
                hid[0] = hidInstID;
                hid[1] = hidInstName;
                hid[2] = hidInstCode;
                hid[3] = hidFacID;
                hid[4] = hidCrID;
                hid[5] = hidMoLrnID;
                hid[6] = hidPtrnID;
                hid[7] = hidBrnID;
                hid[8] = hidCrName;
                hid[9] = hidCrPartName;
                hid[10] = hidCrPrChName;
                hid[11] = hidCrPrDetailsID;
                hid[12] = hidCrPrChID;
                hid[13] = hidPRN;
                hid[14] = hidElgFormNo;
                hid[15] = hidStudentName;
                hid[16] = hidCrPrSeq;
                hid[17] = hidCrPrChSeq;
                hid[18] = hidAcademicYear;
                hid[19] = hidStudentYear;
                hid[20] = hidStudentID;
                hid[21] = hid_IsPpHead;
                oCommon.setHiddenVariablesMPC(ref hid);

                #endregion                

                DisplayPreviousCoursePartDetails();
            }

            //Page.Title = clsGetSettings.Name + " |RegdStudentAdmissions - Paper Exemption";
            lblPageHead.Text = "Additional Paper - Select Course - ";
            lblSubHeader.Text = "for " + hidStudentName.Value;
        }
        #endregion

        #region Button Proceed Click
        /// <summary>
        /// Proceed button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event argument.</param>
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

            Server.Transfer("ELGV2_PaperChange__4.aspx", true);
        }
        #endregion

        #region Create Hashtable
        /// <summary>
        /// Create hash table.
        /// </summary>
        /// <returns>Hash table.</returns>
        private Hashtable CreateHashTable()
        {
            
            oHS = new Hashtable();
            oHS.Add("pk_Uni_ID", Classes.clsGetSettings.UniversityID);
            oHS.Add("pk_Institute_ID", hidInstID.Value);
            oHS.Add("pk_Year", hidStudentYear.Value);
            oHS.Add("pk_Student_ID", hidStudentID.Value);
            oHS.Add("pk_Fac_ID", hidFacID.Value);
            oHS.Add("pk_Cr_ID", hidCrID.Value);
            oHS.Add("pk_MoLrn_ID", hidMoLrnID.Value);
            oHS.Add("pk_Ptrn_ID", hidPtrnID.Value);
            oHS.Add("pk_Brn_ID", hidBrnID.Value);
            oHS.Add("fk_CrPr_Details_ID", hidCrPrDetailsID.Value);
            oHS.Add("CrPr_Seq", hidCrPrSeq.Value);
            oHS.Add("CrPrCh_Seq", hidCrPrChSeq.Value);
            oHS.Add("pk_CrPrCh_ID", hidCrPrChID.Value);

            return oHS;
        }
        #endregion

        #region Function to display Previous Course Details
        private void DisplayPreviousCoursePartDetails()
        {
           
            DataTable oDtPrev = new DataTable();
            oDtPrev = clsPaperChange.Get_Previous_CoursePartDetails(Classes.clsGetSettings.UniversityID, hidInstID.Value, hidStudentYear.Value, hidStudentID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value,hidCrPrChID.Value,hidPRN.Value);

            if (oDtPrev != null && oDtPrev.Rows.Count > 0)
            {
                rdPrevCoursePartList.DataSource = oDtPrev;
                rdPrevCoursePartList.DataTextField = "CourseName";
                rdPrevCoursePartList.DataValueField = "Value";
                rdPrevCoursePartList.DataBind();

                // added by garima on 27 july to avoid displaying additonal paper unless course part child sequence keys are set properly.
                if (hidCrPrSeq.Value != string.Empty && hidCrPrChSeq.Value != string.Empty)
                {
                    DisplayAdditionalPapersOptedforPeviousCrPr();
                }
            }

            if (oDtPrev != null)
                oDtPrev = null;
        }
        #endregion

        #region Function to display Additional Papers that are opted for previous CrPr/Tr
        private void DisplayAdditionalPapersOptedforPeviousCrPr()
        {
            hid_Previous_PpGrpID.Value = "";

            oHS=new Hashtable();
            
            oHS.Add("pk_Uni_ID",Classes.clsGetSettings.UniversityID);
	        oHS.Add("pk_Institute_ID",hidInstID.Value);
	        oHS.Add("pk_Year",hidStudentYear.Value);
	        oHS.Add("pk_Student_ID",hidStudentID.Value);
	        oHS.Add("pk_Fac_ID",hidFacID.Value);
	        oHS.Add("pk_Cr_ID",hidCrID.Value);
	        oHS.Add("pk_MoLrn_ID",hidMoLrnID.Value);
	        oHS.Add("pk_Ptrn_ID",hidPtrnID.Value);
	        oHS.Add("pk_Brn_ID",hidBrnID.Value);
	        oHS.Add("CrPr_Seq",hidCrPrSeq.Value);
	        oHS.Add("pk_CrPr_Details_ID",hidCrPrDetailsID.Value);
            oHS.Add("pk_CrPrCh_ID", hidCrPrChID.Value);
            oHS.Add("CrPrCh_Seq", hidCrPrChSeq.Value);           

            oDtAddPp = clsPaperChange.List_AdditionalPapers_Opted_by_Student(oHS);

            if (oDtAddPp != null && oDtAddPp.Rows.Count > 0)
            {
                lblDisplayPreviousCourseName.Visible = true;
                lblDisplayPreviousCourseName.Text = "List of Additional Papers opted for : " + hidCrName.Value;
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

        #region GridView RowDataBound Event
        protected void GV_DisplayAdditionalPaper_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer && e.Row.RowType == DataControlRowType.DataRow)
            {

                 /*Following conditions are written for display of Remove button in grid depending on the conditions
                 whether it is Paper Head or Paper
                 * 1. Whenever it is Paper Head 'Remove' button should get displayed for Paper Head only and not for Papers under
                 * that Paper Head
                 * 2.Whenever it is directly a Paper, then remove button should get displayed for Paper directly
                 * 
                 * First condition represents that it is a Paper and hence 'remove' button will appear for same
                 * Second condition represents that it is Paper Head and hence 'remove' button should get displayed
                 * Third condition respresent that these are Papers under the Paper head, hence remove button should not get displayed
                 * 
                 * e.Row.Cells[14] represents IsPpHead
                 * e.Row.Cells[15] represents PaperHeadGrpID
                 * e.Row.Cells[16] represents fk_PpHead_ID
                 * 
                 * Whenever it is a Paper Head, in this condition fk_PpHead_ID will not be NULL
                 * Whenever Papers are under Paper head fk_PpHead_ID will not be NULL but IsPpHead will be '0' as it will not be Paper Head
                 * Whenever it is Paper fk_PpHead_ID will be NULL, as it will not come under any of the Paper head
                 */
                if (e.Row.Cells[14].Text == "0" && (e.Row.Cells[15].Text == "&nbsp;" || e.Row.Cells[15].Text == "") && (e.Row.Cells[16].Text == "&nbsp;" || e.Row.Cells[16].Text == ""))
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);

                    LinkButton lbtn = (LinkButton)e.Row.FindControl("lnkRemove");
                    lbtn.Attributes.Add("onClick", "return DeleteMsg('" + lbtn.UniqueID + "');");
                    lbtn.Text = "Remove";
                }
                else if (e.Row.Cells[14].Text == "1" && (e.Row.Cells[15].Text != "") && (e.Row.Cells[16].Text != ""))
                {
                    if (hid_Previous_PpGrpID.Value != e.Row.Cells[16].Text)
                    {
                        e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);

                        LinkButton lbtn = (LinkButton)e.Row.FindControl("lnkRemove");
                        lbtn.Attributes.Add("onClick", "return DeleteMsg('" + lbtn.UniqueID + "');");
                        lbtn.Text = "Remove";
                    }
                    else
                    {
                        e.Row.Cells[1].Text = "";
                    }

                    hid_Previous_PpGrpID.Value = e.Row.Cells[16].Text;
                }
                else if (e.Row.Cells[14].Text == "0" && (e.Row.Cells[15].Text != "") && (e.Row.Cells[16].Text != ""))
                {
                    if (hid_Previous_PpGrpID.Value == e.Row.Cells[16].Text)
                    {
                        e.Row.Cells[1].Text = "";
                    }

                    hid_Previous_PpGrpID.Value = e.Row.Cells[16].Text;
                }
            }
        }
        #endregion

        # region Function CreateXML for Exam Form Modify Request
        /// <summary>
        /// Function Create XML (This will Xml for Papers with its Group Details)
        /// </summary>
        public string createExamFormModifyXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateNode(XmlNodeType.Element, "R", "");
            XmlNode child = xml.CreateNode(XmlNodeType.Element, "RT", "");
            child.Attributes.Append(xml.CreateAttribute("Type")).Value = "PC";
            XmlNode student = xml.CreateNode(XmlNodeType.Element, "STU", "");
            student.Attributes.Append(xml.CreateAttribute("Year")).Value = hidStudentYear.Value;
            student.Attributes.Append(xml.CreateAttribute("StudentID")).Value = hidStudentID.Value;
            child.AppendChild(student);
            root.AppendChild(child);
            xml.AppendChild(root);
            return xml.OuterXml;
        }

        #endregion

        #region Gridview RowCommand Event
        protected void GV_DisplayAdditionalPaper_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Hashtable oHSAdd=new Hashtable();
            WebControl wc = e.CommandSource as WebControl;
            GridViewRow row = wc.NamingContainer as GridViewRow;
            if (row != null)
            {
                int index = row.RowIndex;
                GridViewRow selectedRow = GV_DisplayAdditionalPaper.Rows[index];

            	oHSAdd.Add("pk_Uni_ID",Classes.clsGetSettings.UniversityID);
                oHSAdd.Add("pk_Institute_ID",hidInstID.Value);
                oHSAdd.Add("pk_Year",hidStudentYear.Value);
                oHSAdd.Add("pk_Student_ID",hidStudentID.Value);
                /*Course Keys for Addiotional Papers*/
                oHSAdd.Add("AddPp_Fac_ID",Convert.ToString(selectedRow.Cells[4].Text));
                oHSAdd.Add("AddPp_Cr_ID",Convert.ToString(selectedRow.Cells[5].Text));
                oHSAdd.Add("AddPp_MoLrn_ID",Convert.ToString(selectedRow.Cells[6].Text));
                oHSAdd.Add("AddPp_Ptrn_ID",Convert.ToString(selectedRow.Cells[7].Text));
                oHSAdd.Add("AddPp_Brn_ID",Convert.ToString(selectedRow.Cells[8].Text));
                oHSAdd.Add("AddPp_CrPr_Seq",Convert.ToString(selectedRow.Cells[9].Text));
                oHSAdd.Add("AddPp_CrPr_Details_ID",Convert.ToString(selectedRow.Cells[10].Text));
                oHSAdd.Add("AddPp_CrPrCh_ID",Convert.ToString(selectedRow.Cells[11].Text));
                oHSAdd.Add("AddPp_CrPrCh_Seq",Convert.ToString(selectedRow.Cells[12].Text));
                oHSAdd.Add("AddPp_PpPpGrp_ID",Convert.ToString(selectedRow.Cells[17].Text));
                /*Course Keys for which additional Paper is added*/
                oHSAdd.Add("pk_Fac_ID",hidFacID.Value);
                oHSAdd.Add("pk_Cr_ID",hidCrID.Value);
                oHSAdd.Add("pk_MoLrn_ID",hidMoLrnID.Value);
                oHSAdd.Add("pk_Ptrn_ID",hidPtrnID.Value);
                oHSAdd.Add("pk_Brn_ID",hidBrnID.Value);
                oHSAdd.Add("CrPr_Seq",hidCrPrSeq.Value);
                oHSAdd.Add("pk_CrPr_Details_ID",hidCrPrDetailsID.Value);
                oHSAdd.Add("pk_CrPrCh_ID", hidCrPrChID.Value);
                oHSAdd.Add("CrPrCh_Seq", hidCrPrChSeq.Value);                
                oHSAdd.Add("PRN_Number", hidPRN.Value);
                
                string sReturn = clsPaperChange.Remove_AdditionalPapers(oHSAdd);
                //string sReturn = "Y";
                if (sReturn == "Y")
                {
                    Classes.clsUser user = new Classes.clsUser();
                    user = (Classes.clsUser)Session["user"];
                    oHS = new Hashtable();
                    oHS.Add("UniID", clsGetSettings.UniversityID);
                    oHS.Add("InstID", hidInstID.Value);
                    oHS.Add("FacID", Convert.ToString(selectedRow.Cells[4].Text));
                    oHS.Add("CrID", Convert.ToString(selectedRow.Cells[5].Text));
                    oHS.Add("MoLrnID", Convert.ToString(selectedRow.Cells[6].Text));
                    oHS.Add("PtrnID", Convert.ToString(selectedRow.Cells[7].Text));
                    oHS.Add("BrnID", Convert.ToString(selectedRow.Cells[8].Text));
                    oHS.Add("CrPrDetailsID", Convert.ToString(selectedRow.Cells[10].Text));
                    oHS.Add("CrPrChID", Convert.ToString(selectedRow.Cells[11].Text));
                      
                    if (hidPRN.Value != string.Empty)
                    {
                        oHS.Add("PRN", hidPRN.Value);
                    }
                    else if (hidElgFormNo.Value != string.Empty)
                    {
                        oHS.Add("RefUni", hidElgFormNo.Value.Split('-')[0].ToString());
                        oHS.Add("RefInstID", hidElgFormNo.Value.Split('-')[1].ToString());
                        oHS.Add("RefYear", hidElgFormNo.Value.Split('-')[2].ToString());
                        oHS.Add("RefStudent", hidElgFormNo.Value.Split('-')[3].ToString());
                    }

                    DataTable dt = clsPaperChange.IsPaperChangeAllowed(oHS);
                    if (dt.Rows.Count > 0)
                    {
                        hidExamFormModifyReq.Value = string.Empty;
                        if (dt.Rows[0]["fkExEvId"].ToString() != "0" && dt.Rows[0]["fkExEvId"].ToString() != "-") 
                        {
                            oHS.Add("AcYrID", hidAcademicYear.Value);
                            oHS.Add("CreatedBy", user.User_ID.ToString());
                            oHS.Add("RequestDetails", createExamFormModifyXML());

                            string status = clsPaperChange.SendExamFormModifyRequest(oHS);

                            if (status.Equals("S")) //successful
                            {
                                if (user.UserTypeCode != "2")
                                {
                                    lblNote.CssClass = "saveNote";
                                    lblNote.Text = "Selected Additional Paper removed successfully !!! <br>An Exam Form Modify Request has been sent. The results will also be re-processed.";
                                    DisplayAdditionalPapersOptedforPeviousCrPr();                                   
                                }
                                else if (user.UserTypeCode == "2")
                                {
                                    lblNote.CssClass = "saveNote";
                                    lblNote.Text = "Selected Additional Paper removed successfully !!! <br>An Exam Form Modify Request has been sent.";
                                    DisplayAdditionalPapersOptedforPeviousCrPr();
                                }
                            }
                            else
                            {
                                lblNote.CssClass = "saveNote";
                                lblNote.Text = "Selected Additional Paper removed successfully !!! <br>An Exam Form Modify Request could not be sent. Please contact ADMINISTRATOR.";
                                DisplayAdditionalPapersOptedforPeviousCrPr();
                            }
                        }
                        else
                        {
                            lblNote.CssClass = "saveNote";
                            lblNote.Text = "Selected Additional Paper removed successfully";
                            DisplayAdditionalPapersOptedforPeviousCrPr();
                        }
                    }
                    else
                    {
                        lblNote.CssClass = "saveNote";
                        lblNote.Text = "Selected Additional Paper removed successfully";
                        DisplayAdditionalPapersOptedforPeviousCrPr();
                    }                    
                }
                else
                {
                    lblNote.CssClass = "errorNote";
                    lblNote.Text = "Error while removing Additional Paper";
                }
            }
        }
        #endregion

    }
}
