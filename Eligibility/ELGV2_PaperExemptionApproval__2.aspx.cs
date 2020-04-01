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
using StudentRegistration.Eligibility.ElgClasses;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using Classes;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperExemptionApproval__2 : System.Web.UI.Page
    {
        #region Variables

        DataTable DT;
        clsUser user;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["User"];

            if (!IsPostBack)
            {
                ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
            }
            if (Page.PreviousPage != null)
            {
                ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)Cntph.FindControl("hid_fk_AcademicYr_ID")).Value;
                hidSelPaper.Value = ((HtmlInputHidden)Cntph.FindControl("hidSelPaper")).Value;
                hidSelTLMAmAt.Value = ((HtmlInputHidden)Cntph.FindControl("hidSelTLMAmAt")).Value;
                hidInstID.Value = ((HtmlInputHidden)Cntph.FindControl("hidInstID")).Value;
                hidFacID.Value = ((HtmlInputHidden)Cntph.FindControl("hidFacID")).Value;
                hidCrID.Value = ((HtmlInputHidden)Cntph.FindControl("hidCrID")).Value;
                hidMoLrnID.Value = ((HtmlInputHidden)Cntph.FindControl("hidMoLrnID")).Value;
                hidBrnID.Value = ((HtmlInputHidden)Cntph.FindControl("hidBrnID")).Value;
                hidPtrnID.Value = ((HtmlInputHidden)Cntph.FindControl("hidPtrnID")).Value;
                hidCrPrDetailsID.Value = ((HtmlInputHidden)Cntph.FindControl("hidCrPrDetailsID")).Value;
                hidCrPrChID.Value = ((HtmlInputHidden)Cntph.FindControl("hidCrPrChID")).Value;
                hidHead.Value = ((HtmlInputHidden)Cntph.FindControl("hidHead")).Value;
                hidTLMIDs.Value = ((HtmlInputHidden)Cntph.FindControl("hidTLMIDs")).Value;
                hidAMIDs.Value = ((HtmlInputHidden)Cntph.FindControl("hidAMIDs")).Value;
                hidATIDs.Value = ((HtmlInputHidden)Cntph.FindControl("hidATIDs")).Value;
                hidCollName.Value = ((HtmlInputHidden)Cntph.FindControl("hidCollName")).Value;
                hidAcYrForCollLogin.Value = ((HtmlInputHidden)Cntph.FindControl("hidAcYrForCollLogin")).Value;
                divEndButtons.Style.Add("display", "block");
                lblGVPapersHeading.Text += " " + hidHead.Value;

                //show only selected tlm am at here

                DataTable DChk = new DataTable();
                DChk.Columns.Add("TLM-AM-AT-ID");
                DChk.Columns.Add("TLM-AM-AT");
                ArrayList tlmamat = new ArrayList();
                for (int i = 0; i < hidSelTLMAmAt.Value.Split(',').Length; i++)
                {
                    tlmamat.Add(hidSelTLMAmAt.Value.Split(',')[i]);
                    DataRow dr = DChk.NewRow();
                    dr["TLM-AM-AT-ID"] = tlmamat[i].ToString().Split('|')[0];
                    dr["TLM-AM-AT"] = tlmamat[i].ToString().Split('|')[1];
                    DChk.Rows.Add(dr);
                }

                chkTLMAMAT.DataSource = DChk;
                chkTLMAMAT.DataBind();
                divTLMAMATChoice.Style.Add("display", "block");

                //DT = clsCollegeAdmissionReports.PaperExemptionFetchStudentDetails(hidSelPaper.Value, hidInstID.Value, hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                //           hidCrPrDetailsID.Value, hidCrPrChID.Value, hidTLMIDs.Value, hidAMIDs.Value, hidATIDs.Value);
                DT = clsCollegeAdmissionReports.PaperExemptionFetchStudentDetails(hidSelPaper.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                            hidCrPrDetailsID.Value, hidCrPrChID.Value, hidTLMIDs.Value, hidAMIDs.Value, hidATIDs.Value);
                if (DT.Rows.Count > 0)
                {
                    divPaperTLMAMAT.Style.Add("display", "block");
                    divResultPageDetails.Style.Add("display", "block");
                    FillGridView(DT);

                    btnApprove.Enabled = true;
                    btnDeny.Enabled = true;

                }
                else
                {
                    divEndButtons.Style.Add("display", "none");
                    divTLMAMATChoice.Style.Add("display", "none");
                    divPaperTLMAMAT.Style.Add("display", "none");
                    tblExportedDataMsg.Style.Add("display", "block");
                    lblExportedData.Text = "No Record(s) found.";
                    divResultPageDetails.Style.Add("display", "none");

                    btnApprove.Enabled = false;
                    btnDeny.Enabled = false;
                }

            }
        }

        #endregion

        #region End button clicks

        protected void btnApproveOrDeny_Click(object sender, EventArgs e)
        {
            lblAppOrDenyMsg.Text = string.Empty;
            string SPXML = string.Empty;
            List<PaperStudXML> oPaperStudXMLList = new List<PaperStudXML>();
            PaperStudXML oPaperStudXML;
            StringBuilder oStringBuilder1 = new StringBuilder();
            StringBuilder oStringBuilder2 = new StringBuilder();

            //-------------
            List<ExamFormModifyXML> oExamFormModifyReq = new List<ExamFormModifyXML>();
            ExamFormModifyXML ExamFormModifyReq;
            hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            //-------------

            for (int j = 0; j < GVPaperTLMAMAT.Rows.Count; j++)
            {
                if (((CheckBox)GVPaperTLMAMAT.Rows[j].Cells[4].FindControl("chkSelectStudents")).Checked)
                {    
                    oPaperStudXML = new PaperStudXML();
                    oPaperStudXML.StudentID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Student_ID"].ToString());
                    oPaperStudXML.Year = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Year"].ToString());
                    oPaperStudXML.TLM = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["TLM-AM-AT-ID"].ToString().Split('-')[0]);
                    oPaperStudXML.AM = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["TLM-AM-AT-ID"].ToString().Split('-')[1]);
                    oPaperStudXML.AT = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["TLM-AM-AT-ID"].ToString().Split('-')[2]);
                    oPaperStudXML.Pk_Pp_PpHead_CrPrCh_ID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Pp_PpHead_CrPrCh_ID"].ToString());
                    oPaperStudXML.FacID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Fac_ID"].ToString());
                    oPaperStudXML.CRID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Cr_ID"].ToString());
                    oPaperStudXML.MOLID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_MoLrn_ID"].ToString());
                    oPaperStudXML.PtrnID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Ptrn_ID"].ToString());
                    oPaperStudXML.BrnID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Brn_ID"].ToString());
                    oPaperStudXML.CrPrDetID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_CrPr_Details_ID"].ToString());
                    oPaperStudXML.CrPrChtID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_CrPrCh_ID"].ToString());
                    oPaperStudXML.UniID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Uni_ID"].ToString());
                 
                    oPaperStudXMLList.Add(oPaperStudXML);

                   // hidStudentID.Value += GVPaperTLMAMAT.DataKeys[j]["pk_Student_ID"].ToString()+",";
                    oStringBuilder1.Append(GVPaperTLMAMAT.DataKeys[j]["pk_Student_ID"].ToString());
                    oStringBuilder1.Append(",");
                  //  hidYearID.Value += GVPaperTLMAMAT.DataKeys[j]["pk_Year"].ToString() + ",";
                    oStringBuilder2.Append(GVPaperTLMAMAT.DataKeys[j]["pk_Year"].ToString());
                    oStringBuilder2.Append(",");


                    //---------------
                    ExamFormModifyReq = new ExamFormModifyXML();
                    ExamFormModifyReq.UniID = int.Parse(hidUniID.Value);
                    ExamFormModifyReq.StudentID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Student_ID"].ToString());
                    ExamFormModifyReq.Year = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Year"].ToString());
                    ExamFormModifyReq.AcYrID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["fk_AcademicYear_ID"].ToString());
                    ExamFormModifyReq.InstID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["Ref_InstReg_Institute_ID"].ToString());
                    ExamFormModifyReq.FacID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Fac_ID"].ToString());
                    ExamFormModifyReq.CrID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Cr_ID"].ToString());
                    ExamFormModifyReq.MoLrnID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_MoLrn_ID"].ToString());
                    ExamFormModifyReq.PtrnID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Ptrn_ID"].ToString());
                    ExamFormModifyReq.BrnID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_Brn_ID"].ToString());
                    ExamFormModifyReq.CrPrDetailsID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_CrPr_Details_ID"].ToString());
                    ExamFormModifyReq.CrPrChID = int.Parse(GVPaperTLMAMAT.DataKeys[j].Values["pk_CrPrCh_ID"].ToString());
                    ExamFormModifyReq.CreatedBy = user.User_ID.ToString();
                    //ExamFormModifyReq.RequestDetails = createExamFormModifyXML(ExamFormModifyReq.StudentID, ExamFormModifyReq.Year);
                    oExamFormModifyReq.Add(ExamFormModifyReq);
                    //---------------
                }
            }

            hidStudentID.Value = oStringBuilder1.ToString();
            hidYearID.Value = oStringBuilder2.ToString();

            //set hidden variables

            hidStudentID.Value = oStringBuilder1.ToString();
            hidYearID.Value = oStringBuilder2.ToString();
            hidFacID.Value = GVPaperTLMAMAT.DataKeys[0]["pk_Fac_ID"].ToString();
            hidCrID.Value = GVPaperTLMAMAT.DataKeys[0]["pk_Cr_ID"].ToString();
            hidMoLrnID.Value = GVPaperTLMAMAT.DataKeys[0]["pk_MoLrn_ID"].ToString();
            hidPtrnID.Value = GVPaperTLMAMAT.DataKeys[0]["pk_Ptrn_ID"].ToString();
            hidBrnID.Value = GVPaperTLMAMAT.DataKeys[0]["pk_Brn_ID"].ToString();
            hidCrPrDetailsID.Value = GVPaperTLMAMAT.DataKeys[0]["pk_CrPr_Details_ID"].ToString();
            hidCrPrChID.Value = GVPaperTLMAMAT.DataKeys[0]["pk_CrPrCh_ID"].ToString();            
            hidUniID.Value = GVPaperTLMAMAT.DataKeys[0]["pk_Uni_ID"].ToString();

            //******************************
            //commented old code
            //if (GVPaperTLMAMAT.DataKeys[0]["fk_ExEv_ID"].ToString().Equals("0") || GVPaperTLMAMAT.DataKeys[0]["fk_ExEv_ID"].ToString().Equals("-"))
            //{
            //    hidExamFormModifyReq.Value = "No";
            //}
            //else
            //{
            //    hidExamFormModifyReq.Value = "Yes";
            //}
            //******************************

            int result = 0;
            string status = string.Empty;
            if (((Button)sender).ID == "btnApprove")
            {
                result = clsCollegeAdmissionReports.PaperExemptionApproveOrDeny(user.User_ID, 1, PaperStudXML.SerializeObject(oPaperStudXMLList));
                status = "Granted";
            }
            else if (((Button)sender).ID == "btnDeny")
            {
                result = clsCollegeAdmissionReports.PaperExemptionApproveOrDeny(user.User_ID, 2, PaperStudXML.SerializeObject(oPaperStudXMLList));
                status = "Denied";
            }
            if (result != 0)
            {
                divMsg.Style.Add("display", "block");

                lblAppOrDenyMsg.Text = "The Exemption claimed is " + status + " successfully for the selected student(s).";

                //--------------------------------
                //send exam for modify request
                string resStatus = clsPaperChange.SendExamFormModifyRequest_PaperExemptionApproval_MultipleStuds(ExamFormModifyXML.SerializeObject(oExamFormModifyReq)).ToString();

                if (resStatus != "U") //successful (resStatus gives the number of requests sent) 
                {
                    //if (user.UserTypeCode != "2")
                    //{

                    //    lblAppOrDenyMsg.Text += "<br>An Exam Form Modify Request has been sent for " + resStatus + " number of student(s).";
                    //}
                    //else if (user.UserTypeCode == "2")
                    //{
                    //    lblAppOrDenyMsg.Text += "<br>An Exam Form Modify Request has been sent for " + resStatus + " number of student(s).";
                    //}

                    lblAppOrDenyMsg.Text += "<br>An Exam Form Modify Request has been sent for " + resStatus + " number of student(s).";
                }

                else if (resStatus == "U") //unsuccessful
                {
                    lblAppOrDenyMsg.Text += "<br>An Exam Form Modify Request could not be sent.";
                }
                //--------------------------------

                #region commented old code
                //***************************************************
                //commented old code
                //if (hidExamFormModifyReq.Value.Equals("Yes"))
                //{
                //    Hashtable HT = new Hashtable();
                //    HT.Add("UniID", hidUniID.Value);
                //    HT.Add("InstID", hidInstID.Value);
                //    HT.Add("FacID", hidFacID.Value);
                //    HT.Add("CrID", hidCrID.Value);
                //    HT.Add("MoLrnID", hidMoLrnID.Value);
                //    HT.Add("PtrnID", hidPtrnID.Value);
                //    HT.Add("BrnID", hidBrnID.Value);
                //    HT.Add("CrPrDetailsID", hidCrPrDetailsID.Value);
                //    HT.Add("CrPrChID", hidCrPrChID.Value);
                //    HT.Add("AcYrID", hid_fk_AcademicYr_ID.Value);
                //    HT.Add("CreatedBy", user.User_ID.ToString());
                //    HT.Add("RequestDetails", "'" + createExamFormModifyXML() + "'");

                //    if (clsPaperChange.SendExamFormModifyRequest(HT).Equals("S")) //successful
                //    {
                //        if (user.UserTypeCode != "2")
                //        {
                //            lblAppOrDenyMsg.Text = "<br>An Exam Form Modify Request has been sent. The results will also be re-processed.";
                //        }
                //        else if (user.UserTypeCode == "2")
                //        {
                //            lblAppOrDenyMsg.Text += "<br>An Exam Form Modify Request has been sent.";
                //        }
                //    }

                //    else 
                //    {
                //        lblAppOrDenyMsg.Text += "<br>An Exam Form Modify Request could not be sent.";
                //    }

                //}
                //***************************************************
                #endregion

                //refill grid view
                //DT = clsCollegeAdmissionReports.PaperExemptionFetchStudentDetails(hidSelPaper.Value, hidInstID.Value, hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                //          hidCrPrDetailsID.Value, hidCrPrChID.Value, hidTLMIDs.Value, hidAMIDs.Value, hidATIDs.Value);
                DT = clsCollegeAdmissionReports.PaperExemptionFetchStudentDetails(hidSelPaper.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                         hidCrPrDetailsID.Value, hidCrPrChID.Value, hidTLMIDs.Value, hidAMIDs.Value, hidATIDs.Value);

                if (DT.Rows.Count > 0)
                {
                    divResultPageDetails.Style.Add("display", "block");
                    FillGridView(DT);
                    chkTLMAMAT.ClearSelection();
                    btnApprove.Style.Add("display", "block");
                    btnDeny.Style.Add("display", "block");
                }
                else
                {
                    btnApprove.Style.Add("display", "none");
                    btnDeny.Style.Add("display", "none");
                    divTLMAMATChoice.Style.Add("display", "none");
                    divPaperTLMAMAT.Style.Add("display", "none");
                    tblExportedDataMsg.Style.Add("display", "block");
                    //lblExportedData.Text = "No Record(s) found.";
                    divResultPageDetails.Style.Add("display", "none");
                }


            }
            else
            {
                divMsg.Style.Add("display", "block");
                lblAppOrDenyMsg.Text = "An error has occurred. Please try again later.";
            }

            if (oPaperStudXMLList != null)
                oPaperStudXMLList = null;

        }

        #endregion

        #region Paging for Paper TLM AM AT Grid

        protected void GVPaperTLMAMAT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int curr_page = e.NewPageIndex;
            ArrayList pagesizes = (ArrayList)Session["pagesizes"];
            DataTable DT = (DataTable)Session["DTStudents"];

            int new_size = curr_page * Convert.ToInt32(pagesizes[e.NewPageIndex]);
            int old_size = 0, diff;
            DataTable Dt_temp;
            Dt_temp = DT.Copy();

            for (int i = 0; i < e.NewPageIndex; i++)
            {
                old_size = old_size + Convert.ToInt32(pagesizes[i]);
            }

            diff = old_size - new_size;

            if (diff > 0)
            {
                while (diff > 0)
                {
                    Dt_temp.Rows.RemoveAt(0);
                    diff--;
                }
            }
            else if (diff < 0)
            {
                while (diff < 0)
                {
                    Dt_temp.Rows.InsertAt(Dt_temp.NewRow(), 0);
                    diff++;
                }
            }

            GVPaperTLMAMAT.PageIndex = e.NewPageIndex;
            GVPaperTLMAMAT.DataSource = Dt_temp;
            GVPaperTLMAMAT.PageSize = Convert.ToInt32(pagesizes[e.NewPageIndex]);
            GVPaperTLMAMAT.DataBind();

            ArrayList studentsPerPage = (ArrayList)Session["studentsPerPage"];
            int startIndex, endIndex, totalStudentCount;
            totalStudentCount = Convert.ToInt32(Session["totalStudentCount"]);
            startIndex = (e.NewPageIndex * 25) + 1;
            endIndex = (e.NewPageIndex * 25) + Convert.ToInt32(studentsPerPage[e.NewPageIndex]);
            // To Display first Sr.No. and last Sr.No. of current page
            lblStudCount.Text = startIndex + " - " + endIndex + " of about " + totalStudentCount + " students found";

            chkTLMAMAT.ClearSelection();

        }

        #endregion

        #region Bulk Select

        protected void divTLMAMATChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //find which TLM-AM-AT is bulk selected or de selected

            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$'); ;
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);

            if (chkTLMAMAT.Items[index].Selected)
            {
                foreach (GridViewRow gv in GVPaperTLMAMAT.Rows)
                {
                    if (GVPaperTLMAMAT.DataKeys[gv.RowIndex][0].ToString().Equals((chkTLMAMAT.Items[index].Value)))
                    {
                        ((CheckBox)gv.Cells[3].FindControl("chkSelectStudents")).Checked = true;
                    }
                }
            }
            else
            {
                foreach (GridViewRow gv in GVPaperTLMAMAT.Rows)
                {
                    if (GVPaperTLMAMAT.DataKeys[gv.RowIndex][0].ToString().Equals((chkTLMAMAT.Items[index].Value)))
                    {
                        ((CheckBox)gv.Cells[3].FindControl("chkSelectStudents")).Checked = false;
                    }
                }
            }

        }

        #endregion

        #region Back button click

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("ELGV2_PaperExemptionApproval__1.aspx", true);
        }

        #endregion

        # region FillGridView

        protected void FillGridView(DataTable DT)
        {
            // Calculating pagesizes
            // 25 distinct students per page
            int cnt = 25, rowcnt = 0, j = 0, pageindex = 0;
            string pk_Stud_ID;

            // To store record count of each page
            ArrayList pagesizes = new ArrayList();

            // To Store Student count per page
            ArrayList studentsPerPage = new ArrayList();

            //To store total no. of students
            int totalStudentCount = 0;

            while (j < DT.Rows.Count)
            {
                rowcnt = 0;
                int i;
                for (i = 0; i < cnt; i++)
                {
                    if (j == DT.Rows.Count)
                        break;

                    pk_Stud_ID = DT.Rows[j].ItemArray[2].ToString();
                    rowcnt++;
                    while (true)
                    {
                        j++;
                        if (j < DT.Rows.Count && DT.Rows[j].ItemArray[2].ToString() == pk_Stud_ID)
                        {
                            rowcnt++;
                            continue;
                        }
                        else
                            break;
                    }

                }
                pagesizes.Add(rowcnt);
                studentsPerPage.Add(i);
                totalStudentCount = totalStudentCount + i;
            }

            GVPaperTLMAMAT.DataSource = DT;
            GVPaperTLMAMAT.PageSize = Convert.ToInt32(pagesizes[0]);
            GVPaperTLMAMAT.PageIndex = 0;
            GVPaperTLMAMAT.DataBind();

            Session["DTStudents"] = DT;
            Session["pagesizes"] = pagesizes;
            Session["studentsPerPage"] = studentsPerPage;
            Session["totalStudentCount"] = totalStudentCount;

            // To Display first Sr.No. and last Sr.No. of current page
            lblStudCount.Text = "1 - " + studentsPerPage[0].ToString() + " of about " + totalStudentCount + " students found";

        }

        #endregion

        #region hiding repeating serial numbers

        protected void GVPaperTLMAMAT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex != 0)
                {
                    //checking if stduent id is same as earlier row
                    if (GVPaperTLMAMAT.DataKeys[e.Row.RowIndex].Values[1].ToString() == GVPaperTLMAMAT.DataKeys[e.Row.RowIndex - 1].Values[1].ToString())
                    {
                        e.Row.Cells[0].Text = "";
                    }
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
            child.Attributes.Append(xml.CreateAttribute("Type")).Value = "MEF";
            XmlNode student = xml.CreateNode(XmlNodeType.Element, "STU", "");
            student.Attributes.Append(xml.CreateAttribute("Year")).Value = hidYearID.Value.TrimEnd(',');
            student.Attributes.Append(xml.CreateAttribute("StudentID")).Value = hidStudentID.Value.TrimEnd(',');
            child.AppendChild(student);
            root.AppendChild(child);
            xml.AppendChild(root);
            return xml.OuterXml;
        }

        #endregion
    }
}



