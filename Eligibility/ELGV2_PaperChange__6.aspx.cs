using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperChange__6 : System.Web.UI.Page
    {
        #region Variable Declaration
        clsCache oCache = new clsCache();
        clsCommon oCommon = new clsCommon();
        string sPaperCourse = string.Empty;
        Hashtable oHS = null;
        DataTable oDT = null;
        RadioButton oRDButOptedPapers = null;
        Label oLabelOptedPapers = null;
        public string sSelAddPaperName = string.Empty;
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

                sSelAddPaperName = " '<b>" + hid_SelectedAdditionalPpName.Value + "</b>' ";

                #endregion               
            }

            #region Display Additional Paper that could be selected by student
            DisplayStudentOptedPapers();
            #endregion

            lblPageHead.Text = "Student's Opted Papers  -";
            //lblSubHeader.Text =
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

            if (OptedPaperList.Controls.Count > 0)
            {
                /*This will get the opted Papers that are selected to be replaced for additional */
                for (int i = 0; i < OptedPaperList.Controls.Count; i++)
                {
                    if (OptedPaperList.Controls[i].GetType().Name == "RadioButton")
                    {
                        RadioButton oRB = (RadioButton)OptedPaperList.Controls[i];
                        if (oRB.Checked == true)
                        {
                            hid_SelectedOptedPpID.Value = oRB.ID;
                            break;
                        }
                    }
                }

                string[] AddPaperID_List = (hid_SelectedAdditionalPpID.Value.Split('|')[0]).Split('_');
                string[] OptedPaperID_List = (hid_SelectedOptedPpID.Value.Split('|')[0]).Split('_');
                StringBuilder xmlString = new StringBuilder();                

                if (AddPaperID_List.Length>0)
                {
                    xmlString.AppendFormat("<{0}>", "RegV2_Map_Student_CoursePapers_AdditionalPapers");

                    for (int i = 0; i < AddPaperID_List.Length; i++)
                    {
                        xmlString.Append("<Student>");
                        xmlString.AppendFormat("<pk_Uni_ID>" + Classes.clsGetSettings.UniversityID + "</pk_Uni_ID>");
                        xmlString.AppendFormat("<pk_Institute_ID>" +hidInstID.Value + "</pk_Institute_ID>");
                        xmlString.AppendFormat("<pk_Year>" + hidStudentYear.Value + "</pk_Year>");
                        xmlString.AppendFormat("<pk_Student_ID>" + hidStudentID.Value + "</pk_Student_ID>");
                        xmlString.AppendFormat("<pk_Fac_ID>" + hid_Prev_pk_Fac_ID.Value + "</pk_Fac_ID>");
                        xmlString.AppendFormat("<pk_Cr_ID>" + hid_Prev_pk_Cr_ID.Value + "</pk_Cr_ID>");
                        xmlString.AppendFormat("<pk_MoLrn_ID>" + hid_Prev_pk_MoLrn_ID.Value + "</pk_MoLrn_ID>");
                        xmlString.AppendFormat("<pk_Ptrn_ID>" + hid_Prev_pk_Ptrn_ID.Value + "</pk_Ptrn_ID>");
                        xmlString.AppendFormat("<pk_Brn_ID>" + hid_Prev_pk_Brn_ID.Value + "</pk_Brn_ID>");
                        xmlString.AppendFormat("<CrPr_Seq>" + Convert.ToString((hid_SelectedOptedPpID.Value.Split('|')[0]).Split('-')[1].Trim()) + "</CrPr_Seq>");
                        xmlString.AppendFormat("<pk_CrPr_Details_ID>" + hid_Prev_pk_CrPr_Details_ID.Value + "</pk_CrPr_Details_ID>");
                        xmlString.AppendFormat("<pk_CrPrCh_ID>" + hid_Prev_CoursePartChild.Value + "</pk_CrPrCh_ID>");
                        xmlString.AppendFormat("<CrPrCh_Seq>" + Convert.ToString((hid_SelectedOptedPpID.Value.Split('|')[0]).Split('-')[2].Trim()) + "</CrPrCh_Seq>");
                        xmlString.AppendFormat("<pk_PpPpGrp_ID>" + Convert.ToString(OptedPaperID_List[i].Trim().Split('-')[0].Trim()) + "</pk_PpPpGrp_ID>");

                        xmlString.AppendFormat("<fk_Fac_ID>" + hid_Prev_pk_Fac_ID.Value + "</fk_Fac_ID>");
                        xmlString.AppendFormat("<fk_Cr_ID>" + hid_Prev_pk_Cr_ID.Value + "</fk_Cr_ID>");
                        xmlString.AppendFormat("<fk_MoLrn_ID>" + hid_Prev_pk_MoLrn_ID.Value + "</fk_MoLrn_ID>");
                        xmlString.AppendFormat("<fk_Ptrn_ID>" + hid_Prev_pk_Ptrn_ID.Value + "</fk_Ptrn_ID>");
                        xmlString.AppendFormat("<fk_Brn_ID>" + hid_Prev_pk_Brn_ID.Value + "</fk_Brn_ID>");
                        xmlString.AppendFormat("<fk_CrPr_Seq>" + Convert.ToString((hid_SelectedOptedPpID.Value.Split('|')[0]).Split('-')[1].Trim()) + "</fk_CrPr_Seq>");
                        xmlString.AppendFormat("<fk_CrPr_Details_ID>" + hid_Prev_pk_CrPr_Details_ID.Value + "</fk_CrPr_Details_ID>");
                        xmlString.AppendFormat("<fk_CrPrCh_ID>" + hid_Prev_CoursePartChild.Value + "</fk_CrPrCh_ID>");
                        xmlString.AppendFormat("<fk_CrPrCh_Seq>" + Convert.ToString((hid_SelectedOptedPpID.Value.Split('|')[0]).Split('-')[2].Trim()) + "</fk_CrPrCh_Seq>");
                        
                        xmlString.AppendFormat("<fk_PpPpGrp_ID>" + Convert.ToString(AddPaperID_List[i].Trim()) + "</fk_PpPpGrp_ID>");                      
                        xmlString.AppendFormat("<Created_By>" + user.User_ID + "</Created_By>");                      
                        xmlString.Append("</Student>");    
                    }
                    xmlString.AppendFormat("</{0}>", "RegV2_Map_Student_CoursePapers_AdditionalPapers");
                }
                
                oHS = new Hashtable();
                oHS = CreateHashTable();
                oHS.Add("Add_pk_PpPpGrp_ID", (hid_SelectedAdditionalPpID.Value.Split('|')[0]));
                oHS.Add("Rep_pk_PpPpGrp_ID", (hid_SelectedOptedPpID.Value.Split('|')[0]).Split('-')[0].Trim().ToString());
                oHS.Add("Prev_CrPr_Seq", (hid_SelectedOptedPpID.Value.Split('|')[0]).Split('-')[1].Trim().ToString());
                oHS.Add("Prev_CrPrCh_Seq", (hid_SelectedOptedPpID.Value.Split('|')[0]).Split('-')[2].Trim().ToString());
                oHS.Add("fk_AcademicYear_ID", hidAcademicYear.Value);              
                oHS.Add("Created_By", user.User_ID);

                if (Convert.ToString(xmlString)!="")
                {
                    oHS["StudentAddPaperXml"] = Convert.ToString(xmlString);
                }

                // Saving the selected additional papers by replacing the selected opted paper.
                try
                {
                    string sStatus = clsPaperChange.AddStudentAdditionalPapers(oHS);
                    if (sStatus != "Y")
                    {
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
                                        lblNote.CssClass = "saveNote";
                                        lblNote.Text = "Information Saved Successfully !!! <br>An Exam Form Modify Request has been sent. The results will also be re-processed.";
                                        btnProceed.Enabled = false;
                                    }
                                    else if (user.UserTypeCode == "2")
                                    {
                                        lblNote.CssClass = "saveNote";
                                        lblNote.Text = "Information Saved Successfully !!! <br>An Exam Form Modify Request has been sent.";
                                        btnProceed.Enabled = false;
                                    }
                                }
                                else
                                {
                                    lblNote.CssClass = "saveNote";
                                    lblNote.Text = "Information Saved Successfully !!! <br>An Exam Form Modify Request could not be sent. Please contact ADMINISTRATOR.";
                                    btnProceed.Enabled = false;
                                }

                            }
                            else
                            {
                                lblNote.CssClass = "saveNote";
                                lblNote.Text = "Information saved sucessfully";
                                //DisplayStudentOptedPapers();            
                                btnProceed.Enabled = false;
                            }
                        }
                        else
                        {
                            lblNote.CssClass = "saveNote";
                            lblNote.Text = "Information saved sucessfully";
                            //DisplayStudentOptedPapers();            
                            btnProceed.Enabled = false;
                        }
                    }
                }
                catch(Exception ex)
                {
                    lblNote.CssClass = "errorNote";
                    lblNote.Text = "Information Can not be Processed.<br /> If you get this message again please contact ADMINSTRATOR";
                    btnProceed.Enabled = false;
                }                
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
        private void DisplayStudentOptedPapers()
        {
            btnProceed.Enabled = true;

            // Show course Name. 
            oHS = new Hashtable();
            oHS.Add("pk_Uni_ID", Classes.clsGetSettings.UniversityID);
            oHS.Add("pk_Institute_ID", hidInstID.Value);
            oHS.Add("pk_Fac_ID", hid_Prev_pk_Fac_ID.Value);
            oHS.Add("pk_Cr_ID", hid_Prev_pk_Cr_ID.Value);
            oHS.Add("pk_MoLrn_ID", hid_Prev_pk_MoLrn_ID.Value);
            oHS.Add("pk_Ptrn_ID", hid_Prev_pk_Ptrn_ID.Value);
            oHS.Add("pk_Brn_ID", hid_Prev_pk_Brn_ID.Value);
            oHS.Add("fk_CrPr_Details_ID", hid_Prev_pk_CrPr_Details_ID.Value);
            oHS.Add("pk_CrPrCh_ID", hid_Prev_CoursePartChild.Value);

            sPaperCourse = clsPaperChange.GetCourseName(oHS);

            oHS = CreateHashTable();

            
            oDT = new DataTable();
            oDT = clsPaperChange.GetOptedPaper(oHS);
            if (oDT.Rows.Count > 0)
            {
                if (sPaperCourse != string.Empty)
                {
                    lblCourseName.Text = "<span class='errorNote'>List of already opted papers for : " + sPaperCourse + "</span><br>";
                }

                chk_Papers.Visible = true;
                // Assign oDT to radio button list which will display papers that are opted by student.
                // Assign oDT to radio button list which will display papers that are opted by student.

                for (int i = 0; i < oDT.Rows.Count; i++)
                {
                    if (Convert.ToString(oDT.Rows[i]["fk_PpHead_ID"]) == "" || Convert.ToString(oDT.Rows[i]["IsPpHead"]) == "1")
                    {
                        OptedPaperList.Controls.Add(new LiteralControl("<div style='padding-top:5px'>"));
                        oRDButOptedPapers = new RadioButton();
                        oRDButOptedPapers.Text = Convert.ToString(oDT.Rows[i]["PaperName"]);
                        oRDButOptedPapers.ID = Convert.ToString(oDT.Rows[i]["PaperID"]);
                        oRDButOptedPapers.GroupName = "OptPapers";
                        oRDButOptedPapers.Style.Add("font-family", "Verdana");
                        oRDButOptedPapers.Style.Add("font-size", "8pt");
                        oRDButOptedPapers.Style.Add("font-weight", "400");
                        oRDButOptedPapers.Attributes.Add("onclick", "return CheckPpHead('" + Convert.ToString(oDT.Rows[i]["PaperID"]).Split('|')[1] + "','" + Convert.ToString(oDT.Rows[i]["PaperName"]) + "');");
                        OptedPaperList.Controls.Add(oRDButOptedPapers);
                        OptedPaperList.Controls.Add(new LiteralControl("</div>"));  
                        
                    }
                    else
                    {
                        OptedPaperList.Controls.Add(new LiteralControl("<div style='padding-top:10px'>"));
                        oLabelOptedPapers = new Label();
                        oLabelOptedPapers.Text = Convert.ToString(oDT.Rows[i]["PaperName"]);
                        oLabelOptedPapers.ID = Convert.ToString(oDT.Rows[i]["PaperID"]);
                        oLabelOptedPapers.Style.Add("font-family", "Verdana");
                        oLabelOptedPapers.Style.Add("font-size", "8pt");
                        oLabelOptedPapers.Style.Add("font-weight", "400");
                        oLabelOptedPapers.Style.Add("padding-left", "30px");
                        OptedPaperList.Controls.Add(oLabelOptedPapers);
                        OptedPaperList.Controls.Add(new LiteralControl("</div>"));                   
                    }
                }

                oRDButOptedPapers.Focus();
            }
            else
            {
                btnProceed.Enabled = false;
                chk_Papers.Visible = false;
                lblCourseName.CssClass = "errorNote";
                lblCourseName.Text = "Admission process is not completed for : '" +sPaperCourse+"' <br><br>To continue with this Additional paper process,please complete the mentioned admission.";
            }
        }
        #endregion  

        #region btnBack_Click
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("ELGV2_PaperChange__4.aspx", true);
        }
        #endregion     
    }
}
