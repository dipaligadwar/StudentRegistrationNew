using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Globalization;
using System.Text;
using System.Threading;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperChange__2 : System.Web.UI.Page
    {
        clsUser user;
        static string Flag_isPaperChangeAllowed = string.Empty;
        clsCommon oCommon = new clsCommon();
        bool isDuplicatePaperValidated = true;

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["user"];
            if (hidUniID.Value == "")
            {
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            }
            if (!IsPostBack)
            {
                #region Set Hidden Variables

                HtmlInputHidden[] hid = new HtmlInputHidden[17];
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
                hid[16] = hidAppFormNo;
                oCommon.setHiddenVariablesMPC(ref hid);
                lblSubHeader.Text = "for " + hidStudentName.Value;

                #endregion

                #region Validate and Show Paper Change Interface if valid

                Hashtable oHs = new Hashtable();
                oHs.Add("UniID", hidUniID.Value);
                oHs.Add("InstID", hidInstID.Value);
                oHs.Add("FacID", hidFacID.Value);
                oHs.Add("CrID", hidCrID.Value);
                oHs.Add("MoLrnID", hidMoLrnID.Value);
                oHs.Add("PtrnID", hidPtrnID.Value);
                oHs.Add("BrnID", hidBrnID.Value);
                oHs.Add("CrPrDetailsID", hidCrPrDetailsID.Value);
                oHs.Add("CrPrChID", hidCrPrChID.Value);
                if (hidAppFormNo.Value != string.Empty)
                {
                    oHs.Add("ApplicationFormNo", hidAppFormNo.Value);

                }
                if (hidPRN.Value != string.Empty)
                {
                    oHs.Add("PRN", hidPRN.Value);
                }
                else if (hidElgFormNo.Value != string.Empty)
                {
                    oHs.Add("RefUni", hidElgFormNo.Value.Split('-')[0].ToString());
                    oHs.Add("RefInstID", hidElgFormNo.Value.Split('-')[1].ToString());
                    oHs.Add("RefYear", hidElgFormNo.Value.Split('-')[2].ToString());
                    oHs.Add("RefStudent", hidElgFormNo.Value.Split('-')[3].ToString());
                }

                DataTable dt = clsPaperChange.IsPaperChangeAllowed(oHs);
                if (dt.Rows.Count > 0)
                {

                    // set flag for exam form modify request to be sent or not if saved

                    hidExamFormModifyReq.Value = string.Empty;
                    if (dt.Rows[0]["fkExEvId"].ToString().Equals("0") || dt.Rows[0]["fkExEvId"].ToString().Equals("-")) //fresher
                    {
                        hidExamFormModifyReq.Value = "No";
                    }

                    else
                    {
                        hidExamFormModifyReq.Value = "Yes";
                    }

                    // checking if proceed is allowed / show suitable message

                    int result = 1; // Result =1 means allowed for Paper change
                    string exemption = dt.Rows[0]["ExemptionApprovalPending"].ToString();
                    string eligibility = string.Empty;
                    string message = string.Empty;

                    eligibility = dt.Rows[0]["Eligibility"].ToString();
                    switch (eligibility)
                    {
                        //case "3": message = "Pending"; result = 0; break;
                        //case "-": message = "Notprocessed"; result = 0; break;
                        case "2": message = "Noteligibile"; result = 0; break;
                    }

                    if (result == 1)
                    {
                        if (exemption.Equals("1"))
                        {
                            result = 0;
                            message = "Exemption";
                        }

                        //if (result == 1 && user.UserTypeCode == "2")
                        if (result == 1 && !(user.RoleList.Contains("00004") || user.RoleList.Contains("00006"))) //BA and super admin are exception
                        {
                            if (dt.Rows[0]["fkExEvId"].ToString().Equals("0") || dt.Rows[0]["fkExEvId"].ToString().Equals("-")) //fresher (Exam form is not generated even first time)                            
                                result = 1; // paper changed is  allowed
                            
                            else // Exam form is generated 
                            {
                                if (dt.Rows[0]["ExamFormInwarded"].ToString().Equals("0") || dt.Rows[0]["ExamFormInwarded"].ToString().Equals("-")) // If exam form is not inwarded                                 
                                    result = 1; // paper changed is  allowed
                                else if (user.RoleList.Contains("00005") || user.UserTypeCode.Equals("0"))// if exam form is inwarded allow admin and university logins 
                                {
                                    if (dt.Rows[0]["Result_Status"].ToString().Equals("0") || dt.Rows[0]["Result_Status"].ToString().Equals("-")) // if result is not uploaded 
                                        result = 1; // paper changed is  allowed
                                    else //if  inwarded but result is uploaded
                                    {
                                        result = 0;  // paper changed is not  allowed
                                        message = "result";
                                    }
                                }
                                else
                                {
                                    result = 0; // paper changed is not allowed
                                    message = "inwarded";
                                }

                            }
                        }
                       
                    }
                    if (result == 1)    // Paper Change is allowed(all conditions are satisfied)
                    {
                        GVStat.DataSource = dt;
                        GVStat.DataBind();
                        hidCrPrSeq.Value = GVStat.DataKeys[0]["CrPr_Seq"].ToString();
                        hidCrPrChSeq.Value = GVStat.DataKeys[0]["CrPrCh_Seq"].ToString();
                        hidAcademicYear.Value = GVStat.DataKeys[0]["fk_AcademicYear_ID"].ToString();
                        hidStudentYear.Value = GVStat.DataKeys[0]["pkYear"].ToString();
                        hidStudentID.Value = GVStat.DataKeys[0]["pkStudentId"].ToString();
                        trGrid.Visible = true;
                        Flag_isPaperChangeAllowed = "True";

                        DisplayPaperList();
                    }
                    else //if result == 0   Paper Change is not allowed(one of the conditions is not satisfied)
                    {
                        //-----------
                        GVStat.DataSource = dt;
                        GVStat.DataBind();
                        hidCrPrSeq.Value = GVStat.DataKeys[0]["CrPr_Seq"].ToString();
                        hidCrPrChSeq.Value = GVStat.DataKeys[0]["CrPrCh_Seq"].ToString();
                        hidAcademicYear.Value = GVStat.DataKeys[0]["fk_AcademicYear_ID"].ToString();
                        hidStudentYear.Value = GVStat.DataKeys[0]["pkYear"].ToString();
                        hidStudentID.Value = GVStat.DataKeys[0]["pkStudentId"].ToString();
                        trGrid.Visible = true;
                        Flag_isPaperChangeAllowed = "False";
                        //-----------

                        btnSave.Visible = false;
                        string error = "The " + lblPaper.Text + "(s) cannot be changed for the selected student because the";
                        switch (message)
                        {
                            case "inwarded": lblMessage.Text = error + " exam form has been inwarded."; break;
                            case "result": lblMessage.Text = error + " result has been uploaded."; break;
                            //case "Pending": lblMessage.Text = error + " eligibility is pending."; break;
                            //case "Notprocessed": lblMessage.Text = error + " eligibility is not processed."; break;
                            case "Noteligibile": lblMessage.Text = error + " he/she is not eligible."; break;
                            case "Exemption": lblMessage.Text = error + " " + lblPaper.Text + " exemption approval is pending for some of the " + lblPaper.Text + "(s) of the student."; break;
                        }

                    }

                }

                else
                {
                    btnSave.Visible = false;
                    lblMessage.Text = "There was no student found with the selected criteria.";
                }

                #endregion
            }

        }
        #endregion

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        #region PreRenderComplete Event and WritePaperFactory Function

        void Page_PreRenderComplete(object sender, EventArgs e)
        {
            if (isDuplicatePaperValidated)
            {
                if (trGrid.Visible && Flag_isPaperChangeAllowed == "True")
                {
                    #region Subject  wise maximum paper selection

                    Hashtable oHS = new Hashtable();
                    oHS["UniID"] = hidUniID.Value;
                    oHS["InstID"] = hidInstID.Value;
                    oHS["FacID"] = hidFacID.Value;
                    oHS["CrID"] = hidCrID.Value;
                    oHS["MoLrnID"] = hidMoLrnID.Value;
                    oHS["PtrnID"] = hidPtrnID.Value;
                    oHS["BrnID"] = hidBrnID.Value;
                    oHS["CrPrDetailsID"] = hidCrPrDetailsID.Value;
                    //===========================================
                    // Newly Added parameter on 12th Sept 2012 (ref: #9478)
                    oHS["CrPrChID"] = hidCrPrChID.Value;
                    //===========================================

                    DataTable oDT = clsPaperChange.PaperChange_ListCoursePartWisePaperSubjectMapping(oHS);
                    DataColumn[] col = new DataColumn[1];
                    col[0] = oDT.Columns["PpPpGrpID"];
                    oDT.PrimaryKey = col;
                    DataView oDV = oDT.DefaultView;
                    oDV.Sort = "FacID,SubID";
                    DataRowView[] oDRV = null;
                    object[] obj = new object[2];
                    string sTempKey = string.Empty;

                    System.Text.StringBuilder oSB = new System.Text.StringBuilder();
                    oSB.Append("var subjectFactory = {\"list\":[");

                    if (oDT != null && oDT.Rows.Count > 0)
                    {
                        foreach (DataRow oDR in oDT.Rows)
                        {
                            if ((oDR["SubID"].ToString() + '-' + oDR["FacID"].ToString()) != sTempKey)
                            {
                                sTempKey = oDR["SubID"].ToString() + '-' + oDR["FacID"].ToString();
                                obj[0] = oDR["FacID"].ToString();
                                obj[1] = oDR["SubID"].ToString();
                                oDRV = oDV.FindRows(obj);

                                if (oDRV.Length > 0)
                                {
                                    // Add Subject Details.
                                    oSB.Append("{ \"Subject\" :{\"Min\" : " + oDRV[0]["MinPaperSelection"].ToString() + ",\"Max\"  : " + oDRV[0]["MaxPaperSelection"].ToString() + ",\"SubjectName\" : \"" + oDRV[0]["SubjectName"].ToString() + "\",\"SubjectID\" : " + oDRV[0]["SubID"].ToString() + ",");
                                    oSB.Append("\"Papers\":[");
                                    foreach (DataRowView oVR in oDRV)
                                    {
                                        // Add Papers.
                                        oSB.Append("{\"pID\":\"" + oVR["PpPpGrpID"].ToString() + "\"},");
                                    }

                                    oSB.Remove(oSB.ToString().LastIndexOf(","), 1);
                                    oSB.Append("]");
                                    oSB.Append("} },");
                                }
                            }
                        }

                        oSB.Remove(oSB.ToString().LastIndexOf(","), 1);
                    }

                    oSB.Append("]}");
                    /*Page.RegisterStartupScript("SubjectWisePaperScript", "<script language=\"javascript\">\n" + oSB.ToString() + "</Script>");*/
                    ClientScript.RegisterStartupScript(this.GetType(), "SubjectWisePaperScript", "<script language=\"javascript\">\n" + oSB.ToString() + "</Script>");
                    oPaperBuilder.Append("var paperFactory = {\"paperList\":[");

                    if (xml != null && xml.HasChildNodes)
                    {
                        XmlNode oNode = xml.ChildNodes[0];
                        WritePaperFactory(ref oNode);
                    }
                    if (oPaperBuilder != null && oPaperBuilder.ToString().LastIndexOf(",") > -1)
                    {
                        oPaperBuilder.Remove(oPaperBuilder.ToString().LastIndexOf(","), 1);
                    }

                    oPaperBuilder.Append("]}");
                    /*Page.RegisterStartupScript("PaperFactroyScript", "\n<script language=\"javascript\">" + oPaperBuilder.ToString() + "</Script>");*/
                    ClientScript.RegisterStartupScript(this.GetType(), "PaperFactroyScript", "\n<script language=\"javascript\">" + oPaperBuilder.ToString() + "</Script>");

                    #endregion

                    #region Paper Pre-Requisite

                    Hashtable oHashtable = new Hashtable();
                    oHashtable["pk_Uni_ID"] = hidUniID.Value;
                    oHashtable["pk_Institute_ID"] = hidInstID.Value;
                    oHashtable["pk_Year"] = hidStudentYear.Value;
                    oHashtable["pk_Student_ID"] = hidStudentID.Value;
                    oHashtable["pk_Fac_ID"] = hidFacID.Value;
                    oHashtable["pk_Cr_ID"] = hidCrID.Value;
                    oHashtable["pk_MoLrn_ID"] = hidMoLrnID.Value;
                    oHashtable["pk_Ptrn_ID"] = hidPtrnID.Value;
                    oHashtable["pk_Brn_ID"] = hidBrnID.Value;
                    oHashtable["fk_CrPr_Details_ID"] = hidCrPrDetailsID.Value;
                    oHashtable["pk_CrPrCh_ID"] = hidCrPrChID.Value;
                    oHashtable["CrPr_Seq"] = hidCrPrSeq.Value;
                    oHashtable["CrPrCh_Seq"] = hidCrPrChSeq.Value;

                    DataTable oDataTable = clsPaperChange.PaperChange_ListStudentWisePaperPreRequisiteDetails(oHashtable);
                    StringBuilder oStringBuilder = new StringBuilder();
                    XmlDocument oXmlDocument = new XmlDocument();
                    bool bul = false;
                    oStringBuilder.Append("var preRequisiteFactory ={\"Papers\":[");
                    if (oDataTable != null && oDataTable.Rows.Count > 0)
                    {
                        foreach (DataRow Row in oDataTable.Rows)
                        {
                            oStringBuilder.Append("{\"Paper\":");

                            oStringBuilder.Append("{\"ID\":\"" + Row["pk_PpPpGrp_ID"].ToString().Trim() + "\",");
                            oStringBuilder.Append("\"Name\":\"" + Row["Pp_Name"].ToString().Trim() + "\",");
                            oStringBuilder.Append("\"PreRequisiteType\":\"" + Row["PreRequisiteType"].ToString().Trim() + "\",");
                            oStringBuilder.Append("\"MinPp\":\"" + Row["MinPp"].ToString().Trim() + "\",");
                            // this will use to identify level of pre-requisite : PreRequisiteLevel = 1 pre-reqiusite across the terms 
                            //PreRequisiteLevel = 2 pre-reqiusite for same term
                            oStringBuilder.Append("\"PreRequisiteLevel\":\"" + Row["PreRequisiteLevel"].ToString().Trim() + "\",");

                            oStringBuilder.Append("\"PreRequisitePapers\":[");

                            oXmlDocument.LoadXml(Row["PreRequisite"].ToString().Trim());
                            XmlNodeList oXmlNodeList = oXmlDocument.SelectNodes("Papers/Paper");
                            if (oXmlNodeList != null)
                            {
                                bul = false;
                                foreach (XmlNode oXmlNode in oXmlNodeList)
                                {
                                    oStringBuilder.Append("{\"ID\":\"" + oXmlNode.SelectSingleNode("pk_PpPpGrp_ID").InnerText.Trim() + "\",");
                                    oStringBuilder.Append("\"CourseName\":\"" + oXmlNode.SelectSingleNode("CourseName").InnerText.Trim() + "\",");
                                    oStringBuilder.Append("\"Name\":\"" + oXmlNode.SelectSingleNode("Pre_Pp_Name").InnerText.Trim() + "\",");
                                    oStringBuilder.Append("\"IsOpted\":\"" + oXmlNode.SelectSingleNode("IsOpted").InnerText.Trim() + "\"},\n");

                                    bul = true;
                                }
                                if (bul && oStringBuilder.ToString().LastIndexOf(",") > -1)
                                {
                                    oStringBuilder.Remove(oStringBuilder.ToString().LastIndexOf(","), 1);
                                }
                            }
                            oStringBuilder.Append("]");
                            oStringBuilder.Append("}},\n");
                        }
                        if (oStringBuilder.ToString().LastIndexOf(",") > -1)
                        {
                        }
                    }
                    oStringBuilder.Append(" ]};");

                    ClientScript.RegisterStartupScript(this.GetType(), "PreRequisitePaperScript", "<script language=\"javascript\">\n" + oStringBuilder.ToString() + "</Script>");
                    #endregion
                }
            }
        }

        #region Write Paper Factory
        /// <summary>
        /// Write paper factory function.
        /// </summary>
        /// <param name="currentNode">Current node.</param>
        private void WritePaperFactory(ref XmlNode currentNode)
        {
            if (currentNode == null)
            {
                return;
            }

            for (int i = 0; i < currentNode.ChildNodes.Count; i++)
            {
                XmlNode oN = currentNode.ChildNodes[i];

                if (oN.HasChildNodes && oN.Name.ToUpper() == "GROUP")
                {
                    oPaperBuilder.Append("\n{\"Group\" :{\"GID\" : " + oN.Attributes["ID"].Value.ToString() + ",\"GName\"  : \"" + oN.Attributes["Name"].Value.ToString() + "\",\"GMax\" : " + oN.Attributes["Max"].Value.ToString() + ",\"GMin\" : " + oN.Attributes["Min"].Value.ToString() + ",\"PID\" : " + oN.Attributes["ParentID"].Value.ToString() + ",\"PName\"  : \"" + oN.Attributes["ParentName"].Value.ToString() + "\",\"PMax\" : " + oN.Attributes["PMaxLimit"].Value.ToString() + " ,\"PMin\" : " + oN.Attributes["PMinLimit"].Value.ToString());

                    if (oN.ChildNodes.Count > 0 && (oN.ChildNodes[0].Name.ToString() == "Paper" || oN.ChildNodes[0].Name.ToString() == "PaperHead"))
                    {
                        oPaperBuilder.Append(",\"ContainsGroup\" : 'N'");
                    }
                    else
                    {
                        oPaperBuilder.Append(",\"ContainsGroup\" : 'Y'");
                    }

                    oPaperBuilder.Append(",\"Children\":[");
                    /*for (int n = 0; n < oN.ChildNodes.Count; n++)
                    {                       
                        oPaperBuilder.Append(oN.ChildNodes[n].Attributes["ID"].Value.ToString() +",");
                    }*/
                    for (int n = 0; n < oN.ChildNodes.Count; n++)
                    {
                        sPaperHeadID = string.Empty;
                        if (oN.ChildNodes[n].Name.ToString() == "PaperHead")
                        {
                            sPaperHeadID = oN.ChildNodes[n].Attributes["ID"].Value.ToString();
                            foreach (XmlNode oPaper in oN.ChildNodes[n].ChildNodes)
                            {
                                sPaperHeadID = sPaperHeadID + "_" + oPaper.Attributes["ID"].Value.ToString();
                            }

                            oPaperBuilder.Append("'" + sPaperHeadID + "' ,");
                        }
                        else
                        {
                            oPaperBuilder.Append("'" + oN.ChildNodes[n].Attributes["ID"].Value.ToString() + "' ,");
                        }
                    }

                    oPaperBuilder.Remove(oPaperBuilder.ToString().LastIndexOf(","), 1);
                    oPaperBuilder.Append("]}},");
                }

                WritePaperFactory(ref oN);
            }
        }
        #endregion

        #endregion

        #region User Defined Variable

        DataSet paperDS;
        DataTable paperGroupDT;
        DataTable paperDT;
        XmlDocument xml;
        // int NoofPapersSelected = 0;
        DataTable dt;

        StringBuilder oPaperBuilder = new StringBuilder();
        string sPaperHeadID = "";

        #endregion

        #region Events

        #region btnBackToStudent_Click
        protected void btnBackToStudent_Click(object sender, EventArgs e)
        {
            Server.Transfer("ELGV2_PaperChange__1.aspx");
        }
        #endregion

        #region btnSave_Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblNote.Text = string.Empty;
            int iMaxPaperLimit = 0;
            int iMinPaperLimit = 0;
            trlblNote.Visible = true;

            if (HasChange())
            {

                if (hid_SelectedPpId.Value != string.Empty && hid_SelectedPapersWithRevisions.Value != string.Empty)
                {
                    string sDupPaperList = string.Empty;
                    clsPaperChange oPaperChange = new clsPaperChange();
                    sDupPaperList = oPaperChange.GetPaperName(hid_SelectedPpId.Value);

                    if (!string.IsNullOrEmpty(sDupPaperList))
                    {
                        lblNote.CssClass = "errorNote";
                        lblNote.Text = "<div style='margin:10px 0px 10px 0px;'> " + lblPaper.Text + "(s) " + Server.HtmlDecode(sDupPaperList) + " you have selected more than once.</div>";
                        DisplayPaperList();
                        isDuplicatePaperValidated = false;
                        return;
                    }
                    else
                    {
                        if (hid_SelectedPapers.Value != "" && hid_SelectedPapersWithRevisions.Value != string.Empty)
                        {
                            //hid_SelectedPapers.Value = hid_SelectedPapers.Value.Replace('_', ',');
                            string[] IDs_List = hid_SelectedPapersWithRevisions.Value.Split(',');
                            //string[] IDs_List = hid_SelectedPapers.Value.Split(',');
                            string sSelectedPapers = hid_SelectedPapers.Value.Replace('_', ',');
                            string sSelectedPpWithRevisions = hid_SelectedPapersWithRevisions.Value.Replace('_', ',');
                            try
                            {
                                //MaxPaper Limit is the no. of papers defined at course part child level                                
                                iMaxPaperLimit = Convert.ToInt32(MaxPaperLimit.Value);
                                iMinPaperLimit = Convert.ToInt32(MinPaperLimit.Value);
                            }
                            catch
                            {
                            }
                            if (IDs_List.Length <= iMaxPaperLimit && IDs_List.Length >= Convert.ToInt32(MinPaperLimit.Value))
                            {

                                // Added by Zarin on 13 Sep 2012, following code will validate selected paper as per defined validation group.

                                DataSet oDS = new DataSet();
                                oDS = oPaperChange.ListValidationGroup(hidUniID.Value, hidCrPrDetailsID.Value, hidCrPrChID.Value);

                                if (oDS.Tables[0].Rows.Count > 0)// && oDS.Tables[1].Rows.Count > 0)
                                {
                                    for (short i = 0; i < oDS.Tables[0].Rows.Count; i++)
                                    {
                                        DataView odv = new DataView(oDS.Tables[1]);
                                        if (odv != null && odv.Count>0)
                                        {
                                            odv.RowFilter = "pk_ValGrp_ID = " + Convert.ToString(oDS.Tables[0].Rows[i]["pk_ValGrp_ID"]) + " AND pk_PpPpGrp_ID in (" + sSelectedPapers + ")";

                                            if (odv.Count > Convert.ToInt16(oDS.Tables[0].Rows[i]["ValGrp_MaxPaper"]) || odv.Count < Convert.ToInt16(oDS.Tables[0].Rows[i]["ValGrp_MinPaper"]))
                                            {
                                                DataRow[] oDr = oDS.Tables[1].Select("pk_ValGrp_ID = " + Convert.ToString(oDS.Tables[0].Rows[i]["pk_ValGrp_ID"]));
                                                string sPpaper = string.Empty;
                                                foreach (DataRow dr in oDr)
                                                {
                                                    sPpaper += Convert.ToString(dr["Pp_Name"]) + ", ";
                                                }

                                                sPpaper.Remove(sPpaper.LastIndexOf(','));
                                                lblNote.CssClass = "errorNote";
                                                lblNote.Text = "Minimum <span style='color:black'>" + Convert.ToString(oDS.Tables[0].Rows[i]["ValGrp_MinPaper"]) + "</span> and Maximum <span style='color:black'>" + Convert.ToString(oDS.Tables[0].Rows[i]["ValGrp_MaxPaper"]) + "</span> " + lblPaper.Text + "(s) can be selected out of <span style='color:green'> [ " + sPpaper + " ]</span> From <span style='color:black'>" + Convert.ToString(oDS.Tables[0].Rows[i]["ValGrp_Desc"]) + " </span>";
                                                DisplayPaperList();
                                                return;
                                            }
                                        }
                                    }
                                }


                                string StatusFlag = "";
                                string[] listOldPpIDsArr = hidOldPpList.Value.Split(",".ToCharArray());
                                //hid_SelectedPapers.Value = hid_SelectedPapers.Value.Replace('_', ',');
                                string s = hid_SelectedPapersWithRevisions.Value.Replace('_', ',');
                                string[] listNewPpIDsArr = s.Split(",".ToCharArray());
                                string DelPpStr = "";
                                string InsPpStr = "";
                                int DelFlag = 0;
                                int InsFlag = 0;

                                //For Deleted Papers List
                                for (int i = 0; i < listOldPpIDsArr.Length; i++)
                                {
                                    DelFlag = 0;
                                    for (int j = 0; j < listNewPpIDsArr.Length; j++)
                                    {
                                        if (listOldPpIDsArr[i] == listNewPpIDsArr[j])
                                        {
                                            DelFlag = 1;
                                            break;
                                        }

                                    }
                                    if (DelFlag == 0)
                                        DelPpStr += listOldPpIDsArr[i] + ",";
                                }


                                if (DelPpStr != "")
                                    DelPpStr = DelPpStr.Remove(DelPpStr.LastIndexOf(","), 1);
                                //  Arr1 = IDArray(DelPpStr);
                                //  }

                                //For Newly Inserted Papers List
                                for (int i = 0; i < listNewPpIDsArr.Length; i++)
                                {
                                    InsFlag = 0;
                                    for (int j = 0; j < listOldPpIDsArr.Length; j++)
                                    {
                                        if (listNewPpIDsArr[i] == listOldPpIDsArr[j])
                                        {
                                            InsFlag = 1;
                                            break;
                                        }

                                    }
                                    if (InsFlag == 0)
                                        InsPpStr += listNewPpIDsArr[i] + ",";
                                }

                                if (InsPpStr != "")
                                    InsPpStr = InsPpStr.Remove(InsPpStr.LastIndexOf(","), 1);

                                // string[] Arr2 = new string[3];                                    

                                //if (InsPpStr != "")
                                //{
                                //    InsPpStr = InsPpStr.Remove(InsPpStr.LastIndexOf(","), 1);
                                //    Arr2 = IDArray(InsPpStr);
                                //}

                                Classes.clsUser user = new Classes.clsUser();
                                user = (Classes.clsUser)Session["user"];

                                Hashtable objHT = new Hashtable();

                                objHT.Add("UniID", hidUniID.Value);
                                objHT.Add("InstID", hidInstID.Value);
                                objHT.Add("FacID", hidFacID.Value);
                                objHT.Add("CrID", hidCrID.Value);
                                objHT.Add("MoLrnID", hidMoLrnID.Value);
                                objHT.Add("PtrnID", hidPtrnID.Value);
                                objHT.Add("BrnID", hidBrnID.Value);
                                objHT.Add("CrPrDetailsID", hidCrPrDetailsID.Value);
                                objHT.Add("CrPrChID", hidCrPrChID.Value);
                                objHT.Add("StudentYear", hidStudentYear.Value);
                                objHT.Add("StudentID", hidStudentID.Value);
                                objHT.Add("AcademicYearID", hidAcademicYear.Value);
                                objHT.Add("DelPpStr", DelPpStr);
                                objHT.Add("InsPpStr", InsPpStr);
                                //objHT.Add("DelPpStr", Arr1[0]);
                                //objHT.Add("InsPpStr", Arr2[0]);
                                //objHT.Add("DelPpStr1", Arr1[1]);
                                //objHT.Add("InsPpStr1", Arr2[1]);
                                //objHT.Add("DelPpStr2", Arr1[2]);
                                // objHT.Add("InsPpStr2", Arr2[2]);
                                objHT.Add("Created_By", user.User_ID.ToString());
                                objHT.Add("CrPr_Seq", hidCrPrSeq.Value);
                                objHT.Add("CrPrCh_seq", hidCrPrChSeq.Value);


                                StatusFlag = clsPaperChange.SaveChangedPapers(objHT);

                                if (StatusFlag == "S")
                                {
                                    lblPaperChangeNote.Text = "* The changed paper(s) will not be immediately reflected in the Examform but it will take some processing time.";


                                    lblNote.CssClass = "saveNote";

                                    //send exam form modify request if needed
                                    if (hidExamFormModifyReq.Value.Equals("Yes"))
                                    {
                                        //Hashtable HT = new Hashtable();
                                        //HT.Add("UniID", hidUniID.Value);
                                        //HT.Add("InstID", hidInstID.Value);
                                        //HT.Add("FacID", hidFacID.Value);
                                        //HT.Add("CrID", hidCrID.Value);
                                        //HT.Add("MoLrnID", hidMoLrnID.Value);
                                        //HT.Add("PtrnID", hidPtrnID.Value);
                                        //HT.Add("BrnID", hidBrnID.Value);
                                        //HT.Add("CrPrDetailsID", hidCrPrDetailsID.Value);
                                        //HT.Add("CrPrChID", hidCrPrChID.Value);
                                        //HT.Add("AcYrID", hidAcademicYear.Value);
                                        //HT.Add("CreatedBy", user.User_ID.ToString());
                                        //HT.Add("RequestDetails", createExamFormModifyXML());
                                        // string status = clsPaperChange.SendExamFormModifyRequest(HT);

                                        //if (status.Equals("S")) //successful
                                        //{
                                        if (user.UserTypeCode != "2" && (user.RoleList.Contains("00004") || user.RoleList.Contains("00006")))
                                        {
                                            lblNote.Text = "Information Saved Successfully !!! <br>An Exam Form Modify Request has been sent. The results will also be re-processed.";
                                        }
                                       
                                        else
                                        {
                                            lblNote.Text = "Information Saved Successfully !!! <br>An Exam Form Modify Request has been sent.";
                                        }
                                        // }


                                    }

                                    else if (hidExamFormModifyReq.Value.Equals("No"))
                                    {
                                        lblNote.Text += "Information Saved Successfully !!!";
                                    }

                                    DisplayPaperList();
                                }

                                else if (StatusFlag == "U") //error occurred 
                                {
                                    lblNote.Text = "Information cannot be Processed<br> If you get this message again please contact ADMINSTRATOR";

                                    DisplayPaperList();
                                }
                            }
                            else
                            {
                                lblNote.CssClass = "errorNote";
                                lblNote.Text = "Information cannot be processed.<br>Required number of " + lblPaper.Text + "(s) are not selected.";

                                DisplayPaperList();
                            }

                        }///End IF
                        else
                        {
                            lblNote.CssClass = "errorNote";

                            lblNote.Text = "Information cannot be processed.<br>Select " + lblPaper.Text + "(s).<br>";
                            DisplayPaperList();
                        }
                    }
                }
            }
            else
            {


                lblNote.Text = "Information cannot be Updated as there is no change!";
                lblNote.CssClass = "errorNote";
                DisplayPaperList();
            }


            // lblMsg.Visible = false;
        }
        #endregion

        //public string[] IDArray(string s)
        //{
        //    string[] Arr= new string [3];
        //    string[] listIDsArr = s.Split(',');
        //    foreach (string item in listIDsArr)
        //    {
        //        Arr[0] +=item.Split('|')[0]+",";
        //        Arr[1] += item.Split('|')[1] + ",";
        //        Arr[2] += item.Split('|')[2] + ",";
        //    }
        //    if (Arr[0]!="")
        //    Arr[0] = Arr[0].Remove(Arr[0].LastIndexOf(","), 1);
        //    if (Arr[1] != "")
        //    Arr[1] = Arr[1].Remove(Arr[1].LastIndexOf(","), 1);
        //    if (Arr[2] != "")
        //    Arr[2] = Arr[2].Remove(Arr[2].LastIndexOf(","), 1);
        //    return Arr;
        //}

        #region GridView Events

        #region dgPaperGroup1_RowDataBound
        protected void dgPaperGroup1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView gv = (GridView)sender;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 0; i < e.Row.RowIndex; i++)
                {
                    if (e.Row.Cells[0].Text == dgPaperGroup1.Rows[i].Cells[0].Text)
                    {
                        e.Row.Cells[0].Text = "";
                    }

                }

                if (gv.DataKeys[e.Row.RowIndex]["pk_Pp_ID"].ToString() != "0" && gv.DataKeys[e.Row.RowIndex]["pk_PpHead_ID"].ToString() != "0")
                {
                    e.Row.Visible = false;
                }
                if (gv.DataKeys[e.Row.RowIndex]["pk_Pp_ID"].ToString() != "0" && gv.DataKeys[e.Row.RowIndex]["pk_PpHead_ID"].ToString() == "0")
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text + " (" + lblPaper.Text + ")";
                }
                else if (gv.DataKeys[e.Row.RowIndex]["pk_Pp_ID"].ToString() == "0" && gv.DataKeys[e.Row.RowIndex]["pk_PpHead_ID"].ToString() != "0")
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text + " (" + lblPaper.Text + " Head)";
                }

                if ((gv.DataKeys[e.Row.RowIndex]["Validation_Flag"].ToString() == "2" || gv.DataKeys[e.Row.RowIndex]["Validation_Flag"].ToString() == "1") && (gv.DataKeys[e.Row.RowIndex]["Confirmed"].ToString() != "1"))
                {
                    e.Row.Cells[1].Text = "<font color='#C11B17'>" + e.Row.Cells[1].Text + "</font>";
                }

            }

        }
        #endregion

        #endregion

        #endregion

        #region Other Functions

        #region XML geneartion Functions

        # region Function CreateXML
        /// <summary>
        /// Function Create XML (This will Xml for Papers with its Group Details)
        /// </summary>
        public void createXML()
        {
            xml = new XmlDocument();
            XmlNode root = xml.CreateNode(XmlNodeType.Element, "Course", "");
            root.Attributes.Append(xml.CreateAttribute("ID")).Value = "0";
            root.Attributes.Append(xml.CreateAttribute("Name")).Value = "ROOT";
            //root.Attributes.Append(xml.CreateAttribute("Min")).Value = NoofPapersSelected.ToString();
            //root.Attributes.Append(xml.CreateAttribute("Max")).Value = NoofPapersSelected.ToString();

            root.Attributes.Append(xml.CreateAttribute("Min")).Value = MinPaperLimit.Value;
            root.Attributes.Append(xml.CreateAttribute("Max")).Value = MaxPaperLimit.Value;

            root.Attributes.Append(xml.CreateAttribute("SelectedCount")).Value = "0";

            DataView dvParents = new DataView(paperGroupDT);
            //Get All Parent Groups


            dvParents.RowFilter = "Prnt_PpGrp_ID is NULL";

            for (int i = 0; i < dvParents.Count; i++)
            {

                if (i == 0 || Convert.ToString(dvParents[i]["pk_PpGrp_ID"]) != Convert.ToString(dvParents[i - 1]["pk_PpGrp_ID"]))
                {
                    XmlNode child = xml.CreateNode(XmlNodeType.Element, "Group", "");


                    child.Attributes.Append(xml.CreateAttribute("ID")).Value = Convert.ToString(dvParents[i]["pk_PpGrp_ID"]);
                    child.Attributes.Append(xml.CreateAttribute("Name")).Value = Convert.ToString(dvParents[i]["PpGrp_Desc"]);
                    child.Attributes.Append(xml.CreateAttribute("Min")).Value = Convert.ToString(dvParents[i]["PpGrp_MinPaperOrSubGrp"]);
                    child.Attributes.Append(xml.CreateAttribute("Max")).Value = Convert.ToString(dvParents[i]["PpGrp_MaxPaperOrSubGrp"]);
                    child.Attributes.Append(xml.CreateAttribute("SelectedCount")).Value = "0";

                    //
                    //Name : Neeraj
                    //Date : 25 July 2007
                    //Begin				
                    //
                    child.Attributes.Append(xml.CreateAttribute("ParentID")).Value = Convert.ToString(dvParents[i]["pk_PpGrp_ID"]);
                    child.Attributes.Append(xml.CreateAttribute("ParentName")).Value = Convert.ToString(dvParents[i]["PpGrp_Desc"]);
                    child.Attributes.Append(xml.CreateAttribute("PMaxLimit")).Value = Convert.ToString(dvParents[i]["PpGrp_MaxPaperOrSubGrp"]);
                    child.Attributes.Append(xml.CreateAttribute("PMinLimit")).Value = Convert.ToString(dvParents[i]["PpGrp_MinPaperOrSubGrp"]);


                    child.Attributes.Append(xml.CreateAttribute("TopMostParentID")).Value = Convert.ToString(dvParents[i]["pk_PpGrp_ID"]);
                    child.Attributes.Append(xml.CreateAttribute("TMPName")).Value = Convert.ToString(dvParents[i]["PpGrp_Desc"]);
                    child.Attributes.Append(xml.CreateAttribute("TMPMaxLimit")).Value = Convert.ToString(dvParents[i]["PpGrp_MaxPaperOrSubGrp"]);
                    child.Attributes.Append(xml.CreateAttribute("TMPMinLimit")).Value = Convert.ToString(dvParents[i]["PpGrp_MinPaperOrSubGrp"]);

                    //
                    //End
                    //


                    getXmlNode(Convert.ToString(dvParents[i]["pk_PpGrp_ID"]), child, Convert.ToString(dvParents[i]["pk_PpGrp_ID"]), Convert.ToString(dvParents[i]["PpGrp_MaxPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_MaxPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_Desc"]), Convert.ToString(dvParents[i]["PpGrp_Desc"]));
                    //
                    //Please refer function defination to get more clear idea abot parameters
                    //

                    getPaperHeadNode(Convert.ToString(dvParents[i]["pk_PpGrp_ID"]), child, Convert.ToString(dvParents[i]["pk_PpGrp_ID"]), Convert.ToString(dvParents[i]["PpGrp_MaxPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_MaxPaperOrSubGrp"]), Convert.ToString(dvParents[i]["Prnt_PpGrp_ID"]), Convert.ToString(dvParents[i]["PpGrp_MaxPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_Desc"]), Convert.ToString(dvParents[i]["PpGrp_Desc"]), Convert.ToString(dvParents[i]["PpGrp_Desc"]));
                    getPaperNode(Convert.ToString(dvParents[i]["pk_PpGrp_ID"]), child, Convert.ToString(dvParents[i]["pk_PpGrp_ID"]), Convert.ToString(dvParents[i]["PpGrp_MaxPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_MaxPaperOrSubGrp"]), Convert.ToString(dvParents[i]["Prnt_PpGrp_ID"]), Convert.ToString(dvParents[i]["PpGrp_MaxPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvParents[i]["PpGrp_Desc"]), Convert.ToString(dvParents[i]["PpGrp_Desc"]), Convert.ToString(dvParents[i]["PpGrp_Desc"]), "0");
                    root.AppendChild(child);
                }
            }
            xml.AppendChild(root);

        }

        #endregion

        # region Function CreateXML for Exam Form Modify Request
        /// <summary>
        /// Function Create XML (This will Xml for Papers with its Group Details)
        /// </summary>
        //public string createExamFormModifyXML()
        //{
        //    xml = new XmlDocument();
        //    XmlNode root = xml.CreateNode(XmlNodeType.Element, "R", "");
        //    XmlNode child = xml.CreateNode(XmlNodeType.Element, "RT", "");
        //    child.Attributes.Append(xml.CreateAttribute("Type")).Value = "PC";
        //    XmlNode student = xml.CreateNode(XmlNodeType.Element, "STU", "");
        //    student.Attributes.Append(xml.CreateAttribute("Year")).Value = hidStudentYear.Value;
        //    student.Attributes.Append(xml.CreateAttribute("StudentID")).Value = hidStudentID.Value;
        //    child.AppendChild(student);
        //    root.AppendChild(child);
        //    xml.AppendChild(root);
        //    return xml.OuterXml;
        //}

        #endregion

        #region Function GetXmlNode
        /// <summary>
        /// Function Get XML  Node (This will create node for xml i.e add groups or papers to the parent node)
        /// </summary>
        public void getXmlNode(string sGroupID, XmlNode xn, string sTopMostPID, string sTopMostPMaxLimit, string sGroupMaxLimit, string sTopMostPMinLimit, string sGroupMinLimit, string sTopMostParentName, string sGroupName)
        {
            DataView dvChilds = new DataView(paperGroupDT);
            //Get Childs of single Parent

            // Mdified By Rupam
            dvChilds.RowFilter = "Prnt_PpGrp_ID =" + sGroupID;

            for (int i = 0; i < dvChilds.Count; i++)
            {
                if (i == 0 || Convert.ToString(dvChilds[i]["pk_PpGrp_ID"]) != Convert.ToString(dvChilds[i - 1]["pk_PpGrp_ID"]))
                {
                    XmlNode child = xml.CreateNode(XmlNodeType.Element, "Group", "");


                    child.Attributes.Append(xml.CreateAttribute("ID")).Value = Convert.ToString(dvChilds[i]["pk_PpGrp_ID"]);
                    child.Attributes.Append(xml.CreateAttribute("Name")).Value = Convert.ToString(dvChilds[i]["PpGrp_Desc"]);
                    child.Attributes.Append(xml.CreateAttribute("Min")).Value = Convert.ToString(dvChilds[i]["PpGrp_MinPaperOrSubGrp"]);
                    child.Attributes.Append(xml.CreateAttribute("Max")).Value = Convert.ToString(dvChilds[i]["PpGrp_MaxPaperOrSubGrp"]);
                    child.Attributes.Append(xml.CreateAttribute("SelectedCount")).Value = "0";

                    //
                    //Name : Neeraj
                    //Date : 25 July 2007
                    //Begin				
                    //
                    child.Attributes.Append(xml.CreateAttribute("ParentID")).Value = sGroupID;
                    child.Attributes.Append(xml.CreateAttribute("ParentName")).Value = sGroupName;
                    child.Attributes.Append(xml.CreateAttribute("PMaxLimit")).Value = sGroupMaxLimit;
                    child.Attributes.Append(xml.CreateAttribute("PMinLimit")).Value = sGroupMinLimit;


                    child.Attributes.Append(xml.CreateAttribute("TopMostParentID")).Value = sTopMostPID;
                    child.Attributes.Append(xml.CreateAttribute("TMPName")).Value = sTopMostParentName;
                    child.Attributes.Append(xml.CreateAttribute("TMPMaxLimit")).Value = sTopMostPMaxLimit;
                    child.Attributes.Append(xml.CreateAttribute("TMPMinLimit")).Value = sTopMostPMinLimit;

                    //
                    //End
                    //
                    xn.AppendChild(child);
                    getXmlNode(Convert.ToString(dvChilds[i]["pk_PpGrp_ID"]), child, sTopMostPID, sTopMostPMaxLimit, Convert.ToString(dvChilds[i]["PpGrp_MaxPaperOrSubGrp"]), sTopMostPMinLimit, Convert.ToString(dvChilds[i]["PpGrp_MinPaperOrSubGrp"]), sTopMostParentName, Convert.ToString(dvChilds[i]["PpGrp_Desc"]));
                    getPaperHeadNode(Convert.ToString(dvChilds[i]["pk_PpGrp_ID"]), child, sTopMostPID, sTopMostPMaxLimit, Convert.ToString(dvChilds[i]["PpGrp_MaxPaperOrSubGrp"]), Convert.ToString(dvChilds[i]["Prnt_PpGrp_ID"]), sGroupMaxLimit, sTopMostPMinLimit, sGroupMinLimit, Convert.ToString(dvChilds[i]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvChilds[i]["PpGrp_Desc"]), sTopMostParentName, sGroupName);
                    //getPaperNode(Convert.ToString(dvChilds[i]["pk_PpGrp_ID"]), child, sTopMostPID, sTopMostPMaxLimit, Convert.ToString(dvChilds[i]["PpGrp_MaxPaperOrSubGrp"]), sGroupID, sGroupMaxLimit, sTopMostPMinLimit, sGroupMinLimit, Convert.ToString(dvChilds[i]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvChilds[i]["PpGrp_Desc"]), sTopMostParentName, sGroupName, "0");
                    getPaperNode(Convert.ToString(dvChilds[i]["pk_PpGrp_ID"]), child, sTopMostPID, sTopMostPMaxLimit, Convert.ToString(dvChilds[i]["PpGrp_MaxPaperOrSubGrp"]), Convert.ToString(dvChilds[i]["Prnt_PpGrp_ID"]), sGroupMaxLimit, sTopMostPMinLimit, sGroupMinLimit, Convert.ToString(dvChilds[i]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvChilds[i]["PpGrp_Desc"]), sTopMostParentName, sGroupName, "0");
                }

            }
        }
        #endregion

        # region Function GetPaperHeadNode
        /// <summary>
        /// Function Get PaperHead Node (This will create PaperHead node for xml i.e add paperhead to the parent group or group attached to parent group)
        /// Created By : Rupam
        /// Date : 3 May 2008
        /// </summary>
        public void getPaperHeadNode(string sGroupID, XmlNode xn, string sTopMostPID, string sTopMostPMaxLimit, string sGroupMaxLimit, string sGroupParentID, string sGroupParentMaxLimit, string sTopMostPMinLimit, string sGroupParentMinLimit, string sGroupMinLimit, string sGroupName, string sTopMostGroupName, string sParentGroupName)
        {
            DataView dvPapers = new DataView(paperDT);
            if (sGroupParentID == "")
            {
                dvPapers.RowFilter = "Prnt_PpGrp_ID is Null and pk_PpGrp_ID =" + sGroupID + " and pk_PpHead_ID is not null and pk_Pp_ID is null";
            }
            else
                dvPapers.RowFilter = "Prnt_PpGrp_ID =" + sGroupParentID + " and pk_PpGrp_ID =" + sGroupID + " and pk_PpHead_ID is not null and pk_Pp_ID is null";

            for (int j = 0; j < dvPapers.Count; j++)
            {
                XmlNode child = xml.CreateNode(XmlNodeType.Element, "PaperHead", "");

                child.Attributes.Append(xml.CreateAttribute("ID")).Value = Convert.ToString(dvPapers[j]["Inst_PpPpGrp_ID"]);
                // child.Attributes.Append(xml.CreateAttribute("ID")).Value = Convert.ToString(dvPapers[j]["pk_Pp_ID"]);
                child.Attributes.Append(xml.CreateAttribute("value")).Value = Convert.ToString(dvPapers[j]["Inst_PpPpGrp_ID"]) + "|" + Convert.ToString(dvPapers[j]["fk_PpPpHead_CrPrCh_ID"]) + "|" + Convert.ToString(dvPapers[j]["Revision_Number"]);
                child.Attributes.Append(xml.CreateAttribute("Name")).Value = Convert.ToString(dvPapers[j]["PpHead_Code"]) + " - " + Convert.ToString(dvPapers[j]["PpHead_Name"]) + " (" + lblPaper.Text + " Head)";
                child.Attributes.Append(xml.CreateAttribute("Min")).Value = "1";
                child.Attributes.Append(xml.CreateAttribute("Max")).Value = "1";
                child.Attributes.Append(xml.CreateAttribute("SelectedCount")).Value = "0";
                child.Attributes.Append(xml.CreateAttribute("PpHead")).Value = Convert.ToString(dvPapers[j]["pk_PpHead_ID"]);
                if (Convert.ToString(dvPapers[j]["Stud_PpPpGrp_ID"]) != "0")
                {
                    child.Attributes.Append(xml.CreateAttribute("Checked")).Value = "checked";

                    //*********************************************************
                    // To be commented while deployment. Not to be included in DLL 
                    //if (Convert.ToString(dvPapers[j]["Paper_Type"]) == "1")
                    //{
                    //    child.Attributes.Append(xml.CreateAttribute("Disabled")).Value = "disabled";
                    //}
                    //*********************************************************
                }
                else
                {
                    child.Attributes.Append(xml.CreateAttribute("Checked")).Value = "notchecked";
                }

                //
                //Name : Neeraj
                //Date : 25 July 2007
                //Begin				
                //			

                child.Attributes.Append(xml.CreateAttribute("GroupID")).Value = sGroupID;
                child.Attributes.Append(xml.CreateAttribute("GroupName")).Value = sGroupName;
                child.Attributes.Append(xml.CreateAttribute("GMaxLimit")).Value = sGroupMaxLimit;
                child.Attributes.Append(xml.CreateAttribute("GMinLimit")).Value = sGroupMinLimit;

                if (sGroupParentID == "")
                    child.Attributes.Append(xml.CreateAttribute("GParentID")).Value = sGroupID;
                else
                    child.Attributes.Append(xml.CreateAttribute("GParentID")).Value = sGroupParentID;
                child.Attributes.Append(xml.CreateAttribute("GParentName")).Value = sParentGroupName;
                child.Attributes.Append(xml.CreateAttribute("GParentMaxLimit")).Value = sGroupParentMaxLimit;
                child.Attributes.Append(xml.CreateAttribute("GParentMinLimit")).Value = sGroupParentMinLimit;

                child.Attributes.Append(xml.CreateAttribute("TopMostGroupID")).Value = sTopMostPID;
                child.Attributes.Append(xml.CreateAttribute("TMGName")).Value = sTopMostGroupName;
                child.Attributes.Append(xml.CreateAttribute("TMGMaxLimit")).Value = sTopMostPMaxLimit;
                child.Attributes.Append(xml.CreateAttribute("TMGMinLimit")).Value = sTopMostPMinLimit;

                //
                //End
                //

                xn.AppendChild(child);
                getPaperNode(Convert.ToString(dvPapers[j]["pk_PpGrp_ID"]), child, sTopMostPID, sTopMostPMaxLimit, Convert.ToString(dvPapers[j]["PpGrp_MaxPaperOrSubGrp"]), Convert.ToString(dvPapers[j]["Prnt_PpGrp_ID"]), sGroupMaxLimit, sTopMostPMinLimit, sGroupMinLimit, Convert.ToString(dvPapers[j]["PpGrp_MinPaperOrSubGrp"]), Convert.ToString(dvPapers[j]["PpGrp_Desc"]), sTopMostGroupName, sGroupName, Convert.ToString(dvPapers[j]["pk_PpHead_ID"]));
            }

        }

        #endregion

        # region Function GetPaperNode
        /// <summary>
        /// Function Get Paper  Node (This will create Paper node for xml i.e add papers to the parent group or group attached to parent group)
        /// </summary>
        public void getPaperNode(string sGroupID, XmlNode xn, string sTopMostPID, string sTopMostPMaxLimit, string sGroupMaxLimit, string sGroupParentID, string sGroupParentMaxLimit, string sTopMostPMinLimit, string sGroupParentMinLimit, string sGroupMinLimit, string sGroupName, string sTopMostGroupName, string sParentGroupName, string sPpHead)
        {
            DataView dvPapers = new DataView(paperDT);
            if (sGroupParentID == "")
                dvPapers.RowFilter = "Prnt_PpGrp_ID is null and pk_PpGrp_ID =" + sGroupID + " and pk_Pp_ID is not null and pk_PpHead_ID =" + sPpHead;
            else
                dvPapers.RowFilter = "Prnt_PpGrp_ID = " + sGroupParentID + " and pk_PpGrp_ID =" + sGroupID + " and pk_Pp_ID is not null and pk_PpHead_ID =" + sPpHead;

            for (int j = 0; j < dvPapers.Count; j++)
            {
                XmlNode child = xml.CreateNode(XmlNodeType.Element, "Paper", "");

                child.Attributes.Append(xml.CreateAttribute("ID")).Value = Convert.ToString(dvPapers[j]["Inst_PpPpGrp_ID"]);
                child.Attributes.Append(xml.CreateAttribute("PpID")).Value = Convert.ToString(dvPapers[j]["pk_Pp_ID"]);
                child.Attributes.Append(xml.CreateAttribute("Name")).Value = Convert.ToString(dvPapers[j]["Pp_Code"]) + " - " + Convert.ToString(dvPapers[j]["Pp_Name"]) + " (" + lblPaper.Text + ")";
                child.Attributes.Append(xml.CreateAttribute("Min")).Value = "1";
                child.Attributes.Append(xml.CreateAttribute("Max")).Value = "1";
                child.Attributes.Append(xml.CreateAttribute("SelectedCount")).Value = "0";
                child.Attributes.Append(xml.CreateAttribute("PpHead")).Value = Convert.ToString(dvPapers[j]["pk_PpHead_ID"]);

                if (Convert.ToString(dvPapers[j]["pk_PpHead_ID"]) == "0")
                {
                    if (Convert.ToString(dvPapers[j]["Stud_PpPpGrp_ID"]) != "0")
                        // {
                        child.Attributes.Append(xml.CreateAttribute("Checked")).Value = "checked";
                    //*********************************************************
                    // To be commented while deployment. Not to be included in DLL 
                    //if (Convert.ToString(dvPapers[j]["Paper_Type"]) == "1")
                    //{
                    //    child.Attributes.Append(xml.CreateAttribute("Disabled")).Value = "disabled";
                    //}
                    //*********************************************************
                    // }
                    else
                        child.Attributes.Append(xml.CreateAttribute("Checked")).Value = "notchecked";
                    child.Attributes.Append(xml.CreateAttribute("value")).Value = Convert.ToString(dvPapers[j]["Inst_PpPpGrp_ID"]) + "|" + Convert.ToString(dvPapers[j]["fk_PpPpHead_CrPrCh_ID"]) + "|" + Convert.ToString(dvPapers[j]["Revision_Number"]);
                }
                else
                {
                    child.Attributes.Append(xml.CreateAttribute("abbr")).Value = Convert.ToString(dvPapers[j]["Inst_PpPpGrp_ID"]) + "|" + Convert.ToString(dvPapers[j]["fk_PpPpHead_CrPrCh_ID"]) + "|" + Convert.ToString(dvPapers[j]["Revision_Number"]);
                }



                //
                //Name : Neeraj
                //Date : 25 July 2007
                //Begin				
                //			

                child.Attributes.Append(xml.CreateAttribute("GroupID")).Value = sGroupID;
                child.Attributes.Append(xml.CreateAttribute("GroupName")).Value = sGroupName;
                child.Attributes.Append(xml.CreateAttribute("GMaxLimit")).Value = sGroupMaxLimit;
                child.Attributes.Append(xml.CreateAttribute("GMinLimit")).Value = sGroupMinLimit;

                if (sGroupParentID == "")
                    child.Attributes.Append(xml.CreateAttribute("GParentID")).Value = sGroupID;
                else
                    child.Attributes.Append(xml.CreateAttribute("GParentID")).Value = sGroupParentID;


                child.Attributes.Append(xml.CreateAttribute("GParentName")).Value = sParentGroupName;
                child.Attributes.Append(xml.CreateAttribute("GParentMaxLimit")).Value = sGroupParentMaxLimit;
                child.Attributes.Append(xml.CreateAttribute("GParentMinLimit")).Value = sGroupParentMinLimit;

                child.Attributes.Append(xml.CreateAttribute("TopMostGroupID")).Value = sTopMostPID;
                child.Attributes.Append(xml.CreateAttribute("TMGName")).Value = sTopMostGroupName;
                child.Attributes.Append(xml.CreateAttribute("TMGMaxLimit")).Value = sTopMostPMaxLimit;
                child.Attributes.Append(xml.CreateAttribute("TMGMinLimit")).Value = sTopMostPMinLimit;

                //
                //End
                //

                xn.AppendChild(child);
            }

        }

        #endregion

        #region Function ModifyXML
        /// <summary>
        /// Function Modify XML (This will modify the node of xml).
        /// </summary>
        private void ModifyXML(ref XmlNode currentNode)
        {
            if (currentNode == null) return;
            for (int i = currentNode.ChildNodes.Count - 1; i >= 0; i--)
            {
                XmlNode fnode = currentNode.ChildNodes[i];
                ModifyXML(ref fnode);
            }
            if (!currentNode.HasChildNodes)
            {
                if (currentNode.Name.ToUpper() == "GROUP")
                {
                    XmlNode oPN = currentNode.ParentNode;
                    oPN.RemoveChild(currentNode);
                }
            }

        }

        #endregion

        #endregion

        #region Display Paper List

        public void DisplayPaperList()
        {
            DataTable table = null;

            xml = new XmlDocument();

            paperDS = clsPaperChange.PaperChange_ListPapers(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hidCrPrChID.Value, hidCrPrSeq.Value, hidCrPrChSeq.Value, hidStudentID.Value, hidStudentYear.Value);
            paperGroupDT = paperDS.Tables[0];
            paperDT = paperDS.Tables[1];
            table = paperDS.Tables[3];

            // hid_SelectedPapers.Value = "";
            //Table[2] of Dataset will return min CrPr and Selected CrPr ID's
            //depending on which it will decide whether to display 'Add Additional Paper' button or no.
            //when it will be first CrPr/CrPrTr i.e FYBA or FYBA-Sem 1,in that case button should not get displayed
            //and if it is not first CrPr/CrPrTr then it should get displayed.
            //i.e if minCrPrOrderNo and Sel_Cr_CrPr_OrderNo are not equal,in that case button will get displayed
            //This logic is used as when user clicks of Add Additional Paper,it will displays all its previous CrPr/CrPrTr
            //so if button is given to first CrPr/CrPrtr then it will not have any previous CrPr/Tr.

            //*********************************************************
            // To be commented while deployment. Not to be included in DLL 
            //if (paperDS.Tables[2] != null)
            //{
            //    DataTable odtDisplatAdd = new DataTable();
            //    odtDisplatAdd = paperDS.Tables[2];
            //    if (Convert.ToString(odtDisplatAdd.Rows[0]["minCrPrOrderNo"]) != Convert.ToString(odtDisplatAdd.Rows[0]["Sel_Cr_CrPr_OrderNo"]))
            //    {
            //        divAdditionalPaper.Visible = true;
            //    }
            //    else
            //    {
            //        divAdditionalPaper.Visible = false;
            //    }
            //}
            //*********************************************************

            if (paperDT.Rows.Count > 0)
            {
                hidCrPrChID.Value = Convert.ToString(paperDT.Rows[0]["pk_CrPrCh_ID"]);
                //Total numbers of Papers to be selected

                DataTable dt = new DataTable();
                dt = clsPaperChange.PaperChange_TotalPapers(hidUniID.Value, hidCrPrDetailsID.Value, hidCrPrChID.Value);
                lblMsg.Text = "<span class='errorNote'>Select papers for  : " + hidCrName.Value + "</span><br><br>";
                lblMsg.Text += "Minimum " + dt.Rows[0]["MinPaperNo"].ToString() + " Paper(s) & Maximum " + dt.Rows[0]["MaxPaperNo"].ToString() + " Paper(s) should be Selected.";

                MaxPaperLimit.Value = dt.Rows[0]["MaxPaperNo"].ToString();
                MinPaperLimit.Value = dt.Rows[0]["MinPaperNo"].ToString();

                hidOldPpList.Value = "";

                for (int i = 0; i < paperDT.Rows.Count; i++)
                {
                    if (paperDT.Rows[i]["Stud_ppPpGrp_ID"].ToString() != "0")
                    {
                        hidOldPpList.Value += paperDT.Rows[i]["Stud_ppPpGrp_ID"].ToString() + "|" + paperDT.Rows[i]["fk_PpPpHead_CrPrCh_ID"].ToString() + "|" + paperDT.Rows[i]["Revision_Number"].ToString() + ",";
                    }
                }

                if (hidOldPpList.Value.Length > 1)
                {
                    hidOldPpList.Value = hidOldPpList.Value.ToString().Remove(hidOldPpList.Value.Length - 1);
                }

                createXML();

                if (xml != null && xml.HasChildNodes)
                {
                    XmlNode oNode = xml.ChildNodes[0];
                    ModifyXML(ref oNode);
                    xml.LoadXml(oNode.OuterXml);
                    Xml1.DocumentContent = xml.InnerXml.ToString();
                    Xml1.TransformSource = "RegdPaperSelectionXSLT.xslt";
                }
            }
            else
            {
                lblMsg.CssClass = "errorNote";
                lblMsg.Text = "<i>No Affiliated " + lblPaper.Text + "s found for</i> " + hidCrPartName.Value;
            }
            if ((table != null) && (table.Rows.Count > 0))
            {
                divOuterInfoBox.Visible = true;
                oGridView.DataSource = table;
                oGridView.DataBind();
            }
            else
            {
                divOuterInfoBox.Visible = false;
            }

        }

        #endregion

        #region HasChange

        public bool HasChange()
        {
            string PpArr = "";
            PpArr = hid_SelectedPapersWithRevisions.Value;
            //hid_SelectedPapers.Value;
            PpArr = PpArr.Replace("_", ",");

            if (PpArr.Length != hidOldPpList.Value.Length)
            {
                return true;
            }
            else
            {
                int Flag = 0;
                string[] listOldPpIDsArr = hidOldPpList.Value.Split(",".ToCharArray());
                string[] listNewPpIDsArr = PpArr.Split(",".ToCharArray());

                for (int i = 0; i < listNewPpIDsArr.Length; i++)
                {
                    for (int j = 0; j < listNewPpIDsArr.Length; j++)
                    {
                        if (listNewPpIDsArr[i] == listOldPpIDsArr[j])
                        {
                            Flag++;
                            break;
                        }
                        else
                            continue;
                    }

                }

                if (Flag == listNewPpIDsArr.Length)
                {
                    return false;
                }
                else
                    return true;
            }

        }

        #endregion

        #region Add Additional Paper Button Click
        protected void btnAdditionalPaper_Click(object sender, EventArgs e)
        {
            Server.Transfer("ELGV2_PaperChange__5.aspx", true);
        }
        #endregion

        #endregion

    }
}
