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
using System.Xml;
using Classes;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Text;
using StudentRegistration.Eligibility.ElgClasses;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperChange__3 : System.Web.UI.Page
    {
      
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (hidUniID.Value == "")
            {
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            }
            if (!IsPostBack)
            {
                
                SetPage();
               // FillDataGrid();
                DisplayPaperList();
                
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
            XmlNode oNode = xml.ChildNodes[0];
            WritePaperFactory(ref oNode);

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
            oHashtable["UniID"] = hidUniID.Value;
            oHashtable["InstID"] = hidInstID.Value;
            oHashtable["StudentYear"] = hidStudentYear.Value;
            oHashtable["StudentID"] = hidStudentID.Value;
            oHashtable["FacID"] = hidFacID.Value;
            oHashtable["CrID"] = hidCrID.Value;
            oHashtable["MoLrnID"] = hidMoLrnID.Value;
            oHashtable["PtrnID"] = hidPtrnID.Value;
            oHashtable["BrnID"] = hidBrnID.Value;
            oHashtable["CrPrDetailsID"] = hidCrPrDetailsID.Value;
            oHashtable["CrPrChID"] = hidCrPrChID.Value;
            oHashtable["CrPrSeq"] = hidCrPrSeq.Value;
            oHashtable["CrPrChSeq"] = hidCrPrChSeq.Value;

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
            Server.Transfer("PaperChange__2.aspx");
        }
        #endregion

        #region btnSave_Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int iMaxPaperLimit = 0;
            if (HasChange())
            {
                if (hid_SelectedPapers.Value != "")
                {
                    //hid_SelectedPapers.Value = hid_SelectedPapers.Value.Replace('_', ',');

                    string[] IDs_List = hid_SelectedPapers.Value.Split(',');
                    try
                    {
                        //MaxPaper Limit is the no. of papers defined at course part child level
                        iMaxPaperLimit = Convert.ToInt32(MaxPaperLimit.Value);
                    }
                    catch
                    {
                    }
                    if (IDs_List.Length <= iMaxPaperLimit && IDs_List.Length >= Convert.ToInt32(MinPaperLimit.Value))
                    {

                        string StatusFlag = "";
                        string[] listOldPpIDsArr = hidOldPpList.Value.Split(",".ToCharArray());
                        hid_SelectedPapers.Value = hid_SelectedPapers.Value.Replace('_', ',');
                        string[] listNewPpIDsArr = hid_SelectedPapers.Value.Split(",".ToCharArray());
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
                        objHT.Add("Created_By", user.User_ID.ToString());


                        StatusFlag = clsPaperChange.SaveChangedPapers(objHT);

                        if (StatusFlag == "S")
                        {
                            lblNote.Visible = true;
                            lblNote.Text = "Information Saved Successfully !!!";
                            lblNote.CssClass = "saveNote";
                            DisplayPaperList();
                            FillDataGrid();

                        }

                        else if (StatusFlag == "U")
                        {
                            lblNote.Text = "Information Can not be Processed<br> If you get this message again please contact ADMINSTRATOR";
                            DisplayPaperList();
                        }
                    }
                    else
                    {
                        lblNote.CssClass = "errorNote";
                        lblNote.Text = "Information can not be processed.<br>Required number of " + lblPaper.Text + "(s) are not selected.";
                        DisplayPaperList();
                    }   

                }

                else 
                {
                    lblNote.CssClass = "errorNote";
                    lblNote.Text = "Information can not be processed.<br>Select " + lblPaper.Text + "(s).<br>";
                    DisplayPaperList();
                }
            }

            else
            {
                lblNote.Visible = true;
                lblNote.Text = "Information canonot be Updated as there is no change!";
                lblNote.CssClass = "errorNote";
                DisplayPaperList();
            }
            

           // lblMsg.Visible = false;
        }
        #endregion

        #region GridView Events

        #region dgPaperGroup1_RowDataBound
        protected void dgPaperGroup1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView gv = (GridView)sender;
          
            if(e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 0; i < e.Row.RowIndex; i++)
                {
                    if (e.Row.Cells[0].Text == dgPaperGroup1.Rows[i].Cells[0].Text)
                    {
                        e.Row.Cells[0].Text = "";
                    }

                }
             
                if (gv.DataKeys[e.Row.RowIndex]["pk_Pp_ID"].ToString() != "0" && gv.DataKeys[e.Row.RowIndex]["pk_PpHead_ID"].ToString()!="0")
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

        #region SetPage

        public void SetPage()
        {
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");

            hidInstID.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidInstID")).Value;
            hidInstName.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidInstName")).Value;
            hidFacID.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidFacID")).Value;
            hidCrID.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidCrID")).Value;
            hidMoLrnID.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidMoLrnID")).Value;
            hidPtrnID.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidPtrnID")).Value;
            hidBrnID.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidBrnID")).Value;
            hidCrName.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidCrName")).Value;
            hidCrPartName.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidCrPartName")).Value;
            hidCrPrDetailsID.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidCrPrDetailsID")).Value;
            hidCrPrChID.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidCrPrChID")).Value;
            hidCrPrSeq.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidCrPrSeq")).Value;
            hidCrPrChSeq.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidCrPrChSeq")).Value;
            hidStudentID.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidStudentID")).Value;
            hidStudentName.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidStudentName")).Value;
            hidStudentYear.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidStudentYear")).Value;
            hidAcademicYear.Value = ((HtmlInputHidden)contentPlaceHolder.FindControl("hidAcademicYear")).Value;
        }

        #endregion
        

        #region XML geneartion Functions

        # region Function CreateXML
        /// <summary>
        /// Function Create XML (This will Xml for Papers with its Group Details)
        /// </summary>
        public void createXML()
        {
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
                child.Attributes.Append(xml.CreateAttribute("Name")).Value = Convert.ToString(dvPapers[j]["PpHead_Code"]) + " - " + Convert.ToString(dvPapers[j]["PpHead_Name"]) + " (" +lblPaper.Text+" Head)";
                child.Attributes.Append(xml.CreateAttribute("Min")).Value = "1";
                child.Attributes.Append(xml.CreateAttribute("Max")).Value = "1";
                child.Attributes.Append(xml.CreateAttribute("SelectedCount")).Value = "0";
                child.Attributes.Append(xml.CreateAttribute("PpHead")).Value = Convert.ToString(dvPapers[j]["pk_PpHead_ID"]);
                if (Convert.ToString(dvPapers[j]["Stud_PpPpGrp_ID"]) != "0")
                    child.Attributes.Append(xml.CreateAttribute("Checked")).Value = "checked";
                else
                    child.Attributes.Append(xml.CreateAttribute("Checked")).Value = "notchecked";

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
                // child.Attributes.Append(xml.CreateAttribute("ID")).Value = Convert.ToString(dvPapers[j]["pk_Pp_ID"]);
                child.Attributes.Append(xml.CreateAttribute("Name")).Value = Convert.ToString(dvPapers[j]["Pp_Code"]) + " - " + Convert.ToString(dvPapers[j]["Pp_Name"]) + " (" +lblPaper.Text+ ")";
                child.Attributes.Append(xml.CreateAttribute("Min")).Value = "1";
                child.Attributes.Append(xml.CreateAttribute("Max")).Value = "1";
                child.Attributes.Append(xml.CreateAttribute("SelectedCount")).Value = "0";
                child.Attributes.Append(xml.CreateAttribute("PpHead")).Value = Convert.ToString(dvPapers[j]["pk_PpHead_ID"]);

                if (Convert.ToString(dvPapers[j]["pk_PpHead_ID"]) == "0")
                {
                    if (Convert.ToString(dvPapers[j]["Stud_PpPpGrp_ID"]) != "0")
                        child.Attributes.Append(xml.CreateAttribute("Checked")).Value = "checked";
                    else
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
            xml = new XmlDocument(); 
         
            paperDS = clsPaperChange.PaperChange_ListPapers(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hidCrPrChID.Value,hidCrPrSeq.Value,hidCrPrChSeq.Value, hidStudentID.Value, hidStudentYear.Value);
            paperGroupDT = paperDS.Tables[0];
            paperDT = paperDS.Tables[1];


            if (paperDT.Rows.Count > 0)
            {
                hidCrPrChID.Value = Convert.ToString(paperDT.Rows[0]["pk_CrPrCh_ID"]);
                //Total numbers of Papers to be selected

                DataTable dt = new DataTable();
                dt = clsPaperChange.PaperChange_TotalPapers(hidUniID.Value, hidCrPrDetailsID.Value, hidCrPrChID.Value);
                    lblMsg.Text = "Minimum " + dt.Rows[0]["MinPaperNo"].ToString() + " Paper(s) & Maximum " + dt.Rows[0]["MaxPaperNo"].ToString() + " Paper(s) should be Selected.";
                    
                    MaxPaperLimit.Value = dt.Rows[0]["MaxPaperNo"].ToString();
                    MinPaperLimit.Value = dt.Rows[0]["MinPaperNo"].ToString();

                    for (int i = 0; i < paperDT.Rows.Count; i++)
                {
                    if (paperDT.Rows[i]["Stud_ppPpGrp_ID"].ToString() != "0")
                    {
                        hidOldPpList.Value += paperDT.Rows[i]["Stud_ppPpGrp_ID"].ToString() + ",";
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
        }

        #endregion 

        #region FillDataGrid

        public void FillDataGrid()
        {
            lblSubHeader.Text = " for " + hidInstName.Value;
            lblCourse.Text = hidCrName.Value;
            lblCoursePart.Text = hidCrPartName.Value;
            lblStudent.Text = hidStudentName.Value;
            //lblPaperOpted.ToolTip = "Please click here to view the " + lblPaper.Text.ToLower() + "(s) opted";
           
            dt = new DataTable();
            dt = clsPaperChange.PaperChange_ListofPreviousPapersOfStudent(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hidCrPrChID.Value, hidStudentID.Value, hidStudentYear.Value);

            if (dt != null && dt.Rows.Count > 0)
            {
                /*************  Modified Code **************/
                DataView dv = new DataView();
                dv.Table = dt;
                dv.RowFilter = "pk_Pp_ID = 0  OR pk_PpHead_ID = 0";
               
                trdataGrid.Style.Add("display", "block");
                lblDataGridMsg.Style.Add("display", "none");
                dgPaperGroup1.DataSource = dv;
                dgPaperGroup1.DataBind();
                /*************  Modified Code **************/

                hidOldPpList.Value = "";
                hidPpList.Value = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {                  
                   hidOldPpList.Value += dt.Rows[i]["pk_PpPpGrp_ID"].ToString() + ",";                   
                }
                if(hidOldPpList.Value != "")
                    hidOldPpList.Value = hidOldPpList.Value.ToString().Remove(hidOldPpList.Value.ToString().LastIndexOf(","), 1);
               
            }
            else
            {
                trdataGrid.Style.Add("display", "none");
                lblDataGridMsg.Style.Add("display", "block");
                lblDataGridMsg.Text = "..:: No Group(s) with " + lblPaper.Text + "(s)found ::..";
            }

        }

        #endregion 

        #region HasChange

        public bool HasChange()
        {
            string PpArr = "";
            PpArr = hid_SelectedPapers.Value;
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

        #endregion

    }
}
