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
using System.Text.RegularExpressions;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;
using System.Collections.Generic;
using System.Xml;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperExemptionChange : System.Web.UI.Page
    {
        #region variables

        DataTable dt;
        DataRow dr;
        string PRNumber = null;
        private string Elg_FormNo;
        clsUser user;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["User"];

            if (user.UserTypeCode == "2") 
            {
                hidInstID.Value = user.User_ID;
            }

            try
            {
                hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
            }
            catch
            {
                hidIsPRNValidationRequired.Value = "N";
            }
        }

        #endregion

        protected void btnSimpleSearch_Click(object sender, EventArgs e)
        {
            /* call SP for listing all courses of a student here */
            lblCrPrTermHead.Text = "List of available " + lblCourse.Text + " Part Terms";
            divCourses.Style.Add("display", "block");

            if (txtElgFormNo.Text != "")
            {
                Elg_FormNo = txtElgFormNo.Text.Trim();
            }

            else
            {
                Elg_FormNo = "0-0-0-0";
            }

            int cnt = 0;
            string str = Elg_FormNo;
            int pos = str.IndexOf('-');
            string[] arr = new string[] { "0", "0", "0", "0" };
            Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");

            if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                PRNumber = txtPRN.Text.Trim();

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

            dt = ElgClasses.clsCollegeAdmissionReports.ListStudentwiseCrPrTerms_ChangeExemptionDecision(PRNumber, arr[0], arr[1], arr[2], arr[3]);

            if (dt != null && dt.Rows.Count > 0)
            {
                GVCourseTerms.Visible = true;
                divNoteEnabledLink.Style.Add("display", "block");
                lblCrPrTermHead.Visible = true;
                lblNoRecordsFound.Visible = false;

                GVCourseTerms.DataSource = dt;
                GVCourseTerms.DataBind();
                //storing UniID, YearID in hidden fields
                arr = dt.Rows[0].ItemArray[0].ToString().Split('-');
                hidUniID.Value = arr[0].ToString();
                /* Commented by Shivani on 15/12/2014 to resolve a budobserver thru issue no 57355
                hidYearID.Value = arr[2].ToString();
                 */
                hidYearID.Value = dt.Rows[0]["pkYear"].ToString();
                hidPRN.Value = txtPRN.Text;
                hidElgFormNo.Value = txtElgFormNo.Text;
                DataRow Dr = dt.Rows[0];
                lblAcaYear.Text = " for " + Dr["StudentName"].ToString() + " for " + Dr["CourseName"].ToString();
            }
            else
            {
                GVCourseTerms.Visible = false;
                lblNoRecordsFound.Visible = true;
                divNoteEnabledLink.Style.Add("display", "none");
                lblCrPrTermHead.Visible = false;
            }
        }

        //listing papers for the selected course part term
        protected void GVCourseTerms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectCrPrTerm")
            {
                /* Call SP for listing papers of selected CrPrTerm here */
                divCourses.Style.Add("display", "none");
                divSimpleSearch.Style.Add("display", "none");
                btnBack.Style.Add("display", "block");
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GVCourseTerms.Rows[index];
                lblAcaYear.Text = "for " + row.Cells[1].Text + " for " + row.Cells[3].Text;
                hidHeading.Value = row.Cells[1].Text + " for " + row.Cells[3].Text;
                hidpkFacID.Value = GVCourseTerms.DataKeys[index]["pkFacID"].ToString();
                hidpkCrID.Value = GVCourseTerms.DataKeys[index]["pkCrID"].ToString();
                hidpkMoLrnID.Value = GVCourseTerms.DataKeys[index]["pkMoLrnID"].ToString();
                hidpkPtrnID.Value = GVCourseTerms.DataKeys[index]["pkPtrnID"].ToString();
                hidpkBrnID.Value = GVCourseTerms.DataKeys[index]["pkBrnID"].ToString();
                hidpkCrPrDetails.Value = GVCourseTerms.DataKeys[index]["pkCrPrDetails"].ToString();
                hidpkCrPrChID.Value = GVCourseTerms.DataKeys[index]["pkCrPrChID"].ToString();
                hidStudentID.Value = GVCourseTerms.DataKeys[index]["pkStudentID"].ToString();
                hidInstID.Value = GVCourseTerms.DataKeys[index]["pkInstID"].ToString();
                hidAcademicYear.Value = GVCourseTerms.DataKeys[index]["fkAcademicYr"].ToString();
                if (GVCourseTerms.DataKeys[index]["fk_ExEv_ID"].ToString().Equals("0") || GVCourseTerms.DataKeys[index]["fk_ExEv_ID"].ToString().Equals("-"))
                {
                    hidExamFormModifyReq.Value = "No";
                }
                else 
                {
                    hidExamFormModifyReq.Value = "Yes";
                }

                dt = ElgClasses.clsCollegeAdmissionReports.ListCrPrTermwisePapers_ChangeExemptionDecision(hidUniID.Value, hidYearID.Value, hidStudentID.Value, hidpkFacID.Value, hidpkCrID.Value, hidpkMoLrnID.Value, hidpkPtrnID.Value, hidpkBrnID.Value, hidpkCrPrDetails.Value, hidpkCrPrChID.Value);

                if (dt != null && dt.Rows.Count > 0)
                {
                    GVPapersNew.DataSource = dt;
                    GVPapersNew.DataBind();
                    divPapers.Style.Add("display", "block");
                }
            }

        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            lblNote.Text = string.Empty;

            /* Call SP for changing decision here*/
            string SPXML = string.Empty;
            List<PaperStudXML> oPaperStudXMLList = new List<PaperStudXML>();
            PaperStudXML oPaperStudXML;
            for (int j = 0; j < GVPapersNew.Rows.Count; j++)
            {
                if (((((RadioButton)GVPapersNew.Rows[j].Cells[2].FindControl("RDBtn_Approve")).Enabled && ((RadioButton)GVPapersNew.Rows[j].Cells[2].FindControl("RDBtn_Approve")).Checked)) || (((RadioButton)GVPapersNew.Rows[j].Cells[3].FindControl("RDBtn_Deny")).Enabled && ((RadioButton)GVPapersNew.Rows[j].Cells[3].FindControl("RDBtn_Deny")).Checked))
                {
                    oPaperStudXML = new PaperStudXML();
                    oPaperStudXML.UniID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Uni_ID"].ToString());
                    oPaperStudXML.Year = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Year"].ToString());
                    oPaperStudXML.StudentID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Student_ID"].ToString());
                    oPaperStudXML.TLM = int.Parse(GVPapersNew.DataKeys[j].Values["TLM-AM-AT-ID"].ToString().Split('-')[0]);
                    oPaperStudXML.AM = int.Parse(GVPapersNew.DataKeys[j].Values["TLM-AM-AT-ID"].ToString().Split('-')[1]);
                    oPaperStudXML.AT = int.Parse(GVPapersNew.DataKeys[j].Values["TLM-AM-AT-ID"].ToString().Split('-')[2]);
                    oPaperStudXML.Pk_Pp_PpHead_CrPrCh_ID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Pp_PpHead_CrPrCh_ID"].ToString());
                    oPaperStudXML.FacID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Fac_ID"].ToString());
                    oPaperStudXML.CRID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Cr_ID"].ToString());
                    oPaperStudXML.MOLID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_MoLrn_ID"].ToString());
                    oPaperStudXML.PtrnID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Ptrn_ID"].ToString());
                    oPaperStudXML.BrnID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_Brn_ID"].ToString());
                    oPaperStudXML.CrPrDetID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_CrPr_Details_ID"].ToString());
                    oPaperStudXML.CrPrChtID = int.Parse(GVPapersNew.DataKeys[j].Values["pk_CrPrCh_ID"].ToString());
                    oPaperStudXMLList.Add(oPaperStudXML);
                }
            }

            //set hidden variables
            hidpkFacID.Value = GVPapersNew.DataKeys[0]["pk_Fac_ID"].ToString();
            hidpkCrID.Value = GVPapersNew.DataKeys[0]["pk_Cr_ID"].ToString();
            hidpkMoLrnID.Value = GVPapersNew.DataKeys[0]["pk_MoLrn_ID"].ToString();
            hidpkPtrnID.Value = GVPapersNew.DataKeys[0]["pk_Ptrn_ID"].ToString();
            hidpkBrnID.Value = GVPapersNew.DataKeys[0]["pk_Brn_ID"].ToString();
            hidpkCrPrDetails.Value = GVPapersNew.DataKeys[0]["pk_CrPr_Details_ID"].ToString();
            hidpkCrPrChID.Value = GVPapersNew.DataKeys[0]["pk_CrPrCh_ID"].ToString();
            hidStudentID.Value = GVPapersNew.DataKeys[0]["pk_Student_ID"].ToString();
            hidAcademicYear.Value = GVPapersNew.DataKeys[0]["fk_AcademicYear_ID"].ToString();
            hidInstID.Value = GVPapersNew.DataKeys[0]["Ref_InstReg_Institute_ID"].ToString();
            hidYearID.Value = GVPapersNew.DataKeys[0]["pk_Year"].ToString();
            hidUniID.Value = GVPapersNew.DataKeys[0]["pk_Uni_ID"].ToString();

            int result = 0;

            result = clsCollegeAdmissionReports.ChangeExemptionDecisionForSelectedPapers(user.User_ID, PaperStudXML.SerializeObject(oPaperStudXMLList));

            if (result != 0)
            {
                //divMsg.Style.Add("display", "block");
                lblMsg.Text = "The Exemption Approval Decision has been successfully changed for the Selected " + lblPaper.Text + "(s).";
               
                //send exam for modify request
                Hashtable HT = new Hashtable();
                HT.Add("UniID", hidUniID.Value);
                HT.Add("StudentID", hidStudentID.Value);
                HT.Add("Year", hidYearID.Value);
                HT.Add("InstID", hidInstID.Value);
                HT.Add("FacID", hidpkFacID.Value);
                HT.Add("CrID", hidpkCrID.Value);
                HT.Add("MoLrnID", hidpkMoLrnID.Value);
                HT.Add("PtrnID", hidpkPtrnID.Value);
                HT.Add("BrnID", hidpkBrnID.Value);
                HT.Add("CrPrDetailsID", hidpkCrPrDetails.Value);
                HT.Add("CrPrChID", hidpkCrPrChID.Value);
                HT.Add("AcYrID", hidAcademicYear.Value);
                HT.Add("CreatedBy", user.User_ID.ToString());
                HT.Add("RequestDetails", createExamFormModifyXML());

                if (clsPaperChange.SendExamFormModifyRequest_PaperExemptionApproval(HT).Equals("S")) //successful
                {
                    if (user.UserTypeCode != "2")
                    {
                        lblMsg.Text += "<br>An Exam Form Modify Request has been sent.";
                    }
                    else if (user.UserTypeCode == "2")
                    {
                        lblMsg.Text += "<br>An Exam Form Modify Request has been sent.";
                    }
                }

                else
                {
                    lblMsg.Text += "<br>An Exam Form Modify Request could not be sent.";
                }

                #region commented old code
                //***********************************************
                //if (hidExamFormModifyReq.Value.Equals("Yes"))
                //{
                //    Hashtable HT = new Hashtable();
                //    HT.Add("UniID", hidUniID.Value);
                //    HT.Add("InstID", hidInstID.Value);
                //    HT.Add("FacID", hidpkFacID.Value);
                //    HT.Add("CrID", hidpkCrID.Value);
                //    HT.Add("MoLrnID", hidpkMoLrnID.Value);
                //    HT.Add("PtrnID", hidpkPtrnID.Value);
                //    HT.Add("BrnID", hidpkBrnID.Value);
                //    HT.Add("CrPrDetailsID", hidpkCrPrDetails.Value);
                //    HT.Add("CrPrChID", hidpkCrPrChID.Value);
                //    HT.Add("AcYrID", hidAcademicYear.Value);
                //    HT.Add("CreatedBy", user.User_ID.ToString());
                //    HT.Add("RequestDetails", "'" + createExamFormModifyXML() + "'");

                //    string status = clsPaperChange.SendExamFormModifyRequest(HT);

                //    if (status.Equals("S")) //successful
                //    {
                //        if (user.UserTypeCode != "2")
                //        {
                //            lblMsg.Text += "<br>An Exam Form Modify Request has been sent.";
                //        }
                //        else if (user.UserTypeCode == "2")
                //        {
                //            lblMsg.Text += "<br>An Exam Form Modify Request has been sent.";
                //        }
                //    }

                //    else 
                //    {
                //        lblMsg.Text += "<br>An Exam Form Modify Request could not be sent.";
                //    }
                    
                //}
                //********************************************
                #endregion

                //refill grid view
                dt = ElgClasses.clsCollegeAdmissionReports.ListCrPrTermwisePapers_ChangeExemptionDecision(hidUniID.Value, hidYearID.Value, hidStudentID.Value, hidpkFacID.Value, hidpkCrID.Value, hidpkMoLrnID.Value, hidpkPtrnID.Value, hidpkBrnID.Value, hidpkCrPrDetails.Value, hidpkCrPrChID.Value);

                if (dt.Rows.Count > 0)
                {
                    GVPapersNew.DataSource = dt;
                    GVPapersNew.DataBind();
                }
                else
                {
                    tblExportedDataMsg.Style.Add("display", "block");
                    lblExportedData.Text = "No Record(s) found.";
                }
            }

            else
            {
                //divMsg.Style.Add("display", "block");
                lblMsg.Text = "An error has occurred. Please try again later.";
            }

            if (oPaperStudXMLList != null)
                oPaperStudXMLList = null;
            lblMsg.Style.Add("display", "block");
        }

        //going back to CrPrTerms listing
        protected void btnBack_Click(object sender, EventArgs e)
        {
            divCourses.Style.Add("display", "block");
            divSimpleSearch.Style.Add("display", "block");
            btnBack.Style.Add("display", "none");
            divPapers.Style.Add("display", "none");
            lblMsg.Style.Add("display", "none");
            txtPRN.Text = hidPRN.Value;
            txtElgFormNo.Text = hidElgFormNo.Value;
            //reinvoke event in case the paper status has changed
            btnSimpleSearch_Click(sender, e);
        }

        //show or hide the Select Papers link button
        protected void GVCourseTerms_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (GVCourseTerms.DataKeys[e.Row.RowIndex]["PpExistsCnt"].ToString().Equals("0"))
                {
                    e.Row.Cells[4].Enabled = false;
                }
            }
        }

        //enable and diable radiobuttons according to current decision
        protected void GVPapersNew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (GVPapersNew.DataKeys[e.Row.RowIndex]["ExmpApprovalStatus"].ToString().Equals("Granted"))
                {
                    ((RadioButton)e.Row.Cells[2].FindControl("RDBtn_Approve")).Enabled = false;
                    ((RadioButton)e.Row.Cells[2].FindControl("RDBtn_Approve")).Checked = true;

                }
                else if (GVPapersNew.DataKeys[e.Row.RowIndex]["ExmpApprovalStatus"].ToString().Equals("Denied"))
                {
                    ((RadioButton)e.Row.Cells[3].FindControl("RDBtn_Deny")).Enabled = false;
                    ((RadioButton)e.Row.Cells[3].FindControl("RDBtn_Deny")).Checked = true;
                }
            }
        }

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
            student.Attributes.Append(xml.CreateAttribute("Year")).Value = hidYearID.Value;
            student.Attributes.Append(xml.CreateAttribute("StudentID")).Value = hidStudentID.Value;
            child.AppendChild(student);
            root.AppendChild(child);
            xml.AppendChild(root);
            return xml.OuterXml;
        }

        #endregion
    }
}
