using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperChange__4 : System.Web.UI.Page
    {
        #region Variable Declaration
        clsCache oCache = new clsCache();
        clsCommon oCommon = new clsCommon();
        string sPaperCourse = string.Empty;        
        Hashtable oHS = null;
        DataTable oDT = null;
        RadioButton oRDButAdditionalPapers = null;
        Label oLabelAdditionalPapers = null;
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

                HtmlInputHidden[] hid = new HtmlInputHidden[33];
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
                hid[21] = hid_Prev_pk_Fac_ID;
                hid[22] = hid_Prev_pk_Cr_ID;
                hid[23] = hid_Prev_pk_MoLrn_ID;
                hid[24] = hid_Prev_pk_Ptrn_ID;
                hid[25] = hid_Prev_pk_Brn_ID;
                hid[26] = hid_Prev_pk_CrPr_Details_ID;
                hid[27] = hid_Prev_CoursePartChild;
                hid[28] = hid_Prev_CoursePart_Opted;
                hid[29] = hid_SelectedAdditionalPpID;               
                hid[30] = hid_SelectedAdditionalPpName;
                hid[31] = hid_Prev_CoursePart_Admission_Type;
                hid[32] = hid_IsPpHead;
                oCommon.setHiddenVariablesMPC(ref hid);

                #endregion                
            }

            #region Display Additional Paper that could be selected by student
            
            DisplayStudentAdditionalPapers();            

            #endregion            
          
            lblPageHead.Text = "Additional Paper -";
            lblSubHeader.Text = "for " + hidStudentName.Value;          
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

        #region Button Proceed Click
        /// <summary>
        /// Proceed button click event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event argument.</param>
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            Classes.clsUser user = new Classes.clsUser();
            user = (Classes.clsUser)Session["user"];

            if (AdditionalPaperList.Controls.Count > 0)
            {
                /*This will get the Additional Papers that are selected */
                hid_SelectedAdditionalPpID.Value = string.Empty;
                hid_SelectedAdditionalPpName.Value = string.Empty;

                for (int i = 0; i < AdditionalPaperList.Controls.Count; i++)
                {
                    if (AdditionalPaperList.Controls[i].GetType().Name == "RadioButton")
                    {
                        RadioButton oRB = (RadioButton)AdditionalPaperList.Controls[i];
                        if (oRB.Checked == true)
                        {
                            hid_SelectedAdditionalPpID.Value = oRB.ID;
                            hid_SelectedAdditionalPpName.Value = oRB.Text;
                            hid_IsPpHead.Value = Convert.ToString(oRB.ID).Split('|')[1];
                            break;
                        }
                    }
                }         
                if (hid_Prev_CoursePart_Opted.Value == "N")
                {
                    oHS = new Hashtable();
                    oHS = CreateHashTable();
                    oHS.Add("Add_pk_PpPpGrp_ID", (hid_SelectedAdditionalPpID.Value.Split('|')[0]));
                    oHS.Add("Prev_CrPr_Seq", "0");
                    oHS.Add("Prev_CrPrCh_Seq", "0");
                    oHS.Add("fk_AcademicYear_ID", hidAcademicYear.Value);                   
                    oHS.Add("Created_By", user.User_ID);

                    // Saving the selected Additional papers.
                    
                    string sStatus = clsPaperChange.AddStudentAdditionalPapers(oHS);
                    if (sStatus != "Y")
                    {
                        lblNote.Visible = true;
                        lblNote.CssClass = "errorNote";
                        lblNote.Text = "Information Can not be Processed<br> If you get this message again please contact ADMINSTRATOR";
                        btnProceed.Enabled = false;
                    }
                    else
                    {
                        oHS = new Hashtable();
                        oHS.Add("UniID", clsGetSettings.UniversityID);
                        oHS.Add("InstID", hidInstID.Value);
                        oHS.Add("FacID", hid_Prev_pk_Fac_ID.Value);
                        oHS.Add("CrID", hid_Prev_pk_Cr_ID.Value);
                        oHS.Add("MoLrnID", hid_Prev_pk_MoLrn_ID.Value);
                        oHS.Add("PtrnID", hid_Prev_pk_Ptrn_ID.Value);
                        oHS.Add("BrnID", hid_Prev_pk_Brn_ID.Value);
                        oHS.Add("CrPrDetailsID", hid_Prev_pk_CrPr_Details_ID.Value);
                        oHS.Add("CrPrChID", hid_Prev_CoursePartChild.Value);

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
                                        lblNote.Visible = true;
                                        lblNote.CssClass = "saveNote";
                                        lblNote.Text = "Information Saved Successfully !!! <br>An Exam Form Modify Request has been sent. The results will also be re-processed.";
                                        btnProceed.Enabled = false;
                                    }
                                    else if (user.UserTypeCode == "2")
                                    {
                                        lblNote.Visible = true;
                                        lblNote.CssClass = "saveNote";
                                        lblNote.Text = "Information Saved Successfully !!! <br>An Exam Form Modify Request has been sent.";
                                        btnProceed.Enabled = false;
                                    }
                                }
                                else
                                {
                                    lblNote.Visible = true;
                                    lblNote.CssClass = "saveNote";
                                    lblNote.Text = "Information Saved Successfully !!! <br>An Exam Form Modify Request could not be sent. Please contact ADMINISTRATOR.";
                                    btnProceed.Enabled = false;
                                }

                            }
                            else
                            {
                                lblNote.Visible = true;
                                lblNote.CssClass = "saveNote";
                                lblNote.Text = "Information saved sucessfully";
                                btnProceed.Enabled = false;
                            }
                        }
                        else
                        {
                            lblNote.Visible = true;
                            lblNote.CssClass = "saveNote";
                            lblNote.Text = "Information saved sucessfully";                                     
                            btnProceed.Enabled = false;
                        }
                    }
                }
                else
                {
                    Server.Transfer("ELGV2_PaperChange__6.aspx", true);
                }
            }
            else
            {

                //if (hid_Mode.Value == "EditMode")
                //{
                //    Server.Transfer("RegdSearchStudent__2.aspx", true);
                //}
                //else
                //{
                //    Server.Transfer("RegularAdmissions__12.aspx", true);
                //}
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

            return oHS;
        }
        #endregion

        #region Function to display student papers
        /// <summary>
        /// Display student papers.
        /// </summary>
        private void DisplayStudentAdditionalPapers()
        {
            btnProceed.Enabled = true;
            lblNote.Visible = false;
            lblNote.Text = string.Empty;            

            // Show course Name. 
            Hashtable oHs = new Hashtable();
            oHs.Add("pk_Uni_ID", Classes.clsGetSettings.UniversityID);
            oHs.Add("pk_Institute_ID", hidInstID.Value);
            oHs.Add("pk_Fac_ID", hid_Prev_pk_Fac_ID.Value);
            oHs.Add("pk_Cr_ID", hid_Prev_pk_Cr_ID.Value);
            oHs.Add("pk_MoLrn_ID", hid_Prev_pk_MoLrn_ID.Value);
            oHs.Add("pk_Ptrn_ID", hid_Prev_pk_Ptrn_ID.Value);
            oHs.Add("pk_Brn_ID", hid_Prev_pk_Brn_ID.Value);
            oHs.Add("fk_CrPr_Details_ID", hid_Prev_pk_CrPr_Details_ID.Value);
            oHs.Add("pk_CrPrCh_ID", hid_Prev_CoursePartChild.Value);

            sPaperCourse = clsPaperChange.GetCourseName(oHs);            

            oHS = CreateHashTable();         
           
            oDT = new DataTable();
            oDT = clsPaperChange.GetAdditionalPaper(oHS);
            if (oDT.Rows.Count > 0)
            {
                if (sPaperCourse != string.Empty)
                {                 
                    lblCourseName.Text = "<span class='errorNote'>List of not opted papers for : " + sPaperCourse + "</span><br>";
                }
                chk_Papers.Visible = true;
                // Assign oDT to radio button list which will display papers that are opted by student.
               
                for (int i = 0; i < oDT.Rows.Count; i++)
                {                    
                    if (Convert.ToString(oDT.Rows[i]["fk_PpHead_ID"]) == "" || Convert.ToString(oDT.Rows[i]["IsPpHead"]) == "1")
                    {
                        AdditionalPaperList.Controls.Add(new LiteralControl("<div style='padding-top:5px'>"));
                        oRDButAdditionalPapers=new RadioButton();
                        oRDButAdditionalPapers.Text=Convert.ToString(oDT.Rows[i]["PaperName"]);
                        oRDButAdditionalPapers.ID=Convert.ToString(oDT.Rows[i]["PaperID"]);
                        oRDButAdditionalPapers.GroupName="AddPapers";
                        oRDButAdditionalPapers.Style.Add("font-family", "Verdana");
                        oRDButAdditionalPapers.Style.Add("font-size", "8pt");
                        oRDButAdditionalPapers.Style.Add("font-weight", "400");
                        AdditionalPaperList.Controls.Add(oRDButAdditionalPapers);
                        AdditionalPaperList.Controls.Add(new LiteralControl("</div>"));                       
                    }
                    else
                    {
                        AdditionalPaperList.Controls.Add(new LiteralControl("<div style='padding-top:10px'>"));
                        oLabelAdditionalPapers=new Label();
                        oLabelAdditionalPapers.Text=Convert.ToString(oDT.Rows[i]["PaperName"]);
                        oLabelAdditionalPapers.ID=Convert.ToString(oDT.Rows[i]["PaperID"]);
                        oLabelAdditionalPapers.Style.Add("font-family", "Verdana");
                        oLabelAdditionalPapers.Style.Add("font-size", "8pt");
                        oLabelAdditionalPapers.Style.Add("font-weight", "400");
                        oLabelAdditionalPapers.Style.Add("padding-left","30px");
                        AdditionalPaperList.Controls.Add(oLabelAdditionalPapers);
                        AdditionalPaperList.Controls.Add(new LiteralControl("</div>"));                       
                    }            
                }
                oRDButAdditionalPapers.Focus();

                if (AdditionalPaperList.Controls.Count >= 0)
                {
                    for (int i = 0; i < AdditionalPaperList.Controls.Count; i++)
                    {
                        if (AdditionalPaperList.Controls[i].GetType().Name == "RadioButton")
                        {
                            RadioButton oRB = (RadioButton)AdditionalPaperList.Controls[i];
                            if (hid_SelectedAdditionalPpID.Value == Convert.ToString(oRB.ID.Trim()))
                            {
                                oRB.Checked = true;                    
                            }                           
                        }
                    }
                }               
            }
            else
            {        
                chk_Papers.Visible = false;
                btnProceed.Enabled = false;               
                lblCourseName.CssClass = "errorNote";
                lblCourseName.Text = "Papers not available for selection.<br>1. Either papers are not affiliated to college <br>2. All affiliated papers for the selected course part term has already been opted.";
            }
        }
        #endregion       

        #region btnBack_Click
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("ELGV2_PaperChange__5.aspx", true);
        }
        #endregion       
    }
}
