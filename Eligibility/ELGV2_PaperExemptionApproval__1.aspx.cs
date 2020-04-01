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
using Ajax;
using AjaxControlToolkit;
using System.Threading;
using StudentRegistration.Eligibility.ElgClasses;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperExemptionApproval__1 : System.Web.UI.Page
    {
        #region variable declaration

        clsCommon Common = new clsCommon();
        CourseRepository crRepository = new CourseRepository();
        InstituteRepository oInstituteRepository = new InstituteRepository();
        clsUser user;
        DataTable DT = new DataTable();
        DataTable dtCollege;
        SelectSingleCourse YCMOU;
        private string[] IDs_List = new string[3];
        string isPaperInGrid = string.Empty;

        #endregion


        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            string courseOrColl = string.Empty;
            user = (clsUser)Session["User"];

            if (!IsPostBack)
            {
                ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
            }

            if (user.UserTypeCode != "2")
            {
                //setting hidden vars from dropdown selections of user control 
                if (Page.PreviousPage != null)
                {
                    #region If redirected here from search control page

                    if (Page.PreviousPage.ToString().Equals("ASP.eligibility_elgv2_paperexemptionapproval_aspx"))
                    {
                        ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                        YCMOU = (SelectSingleCourse)Cntph.FindControl("YCMOU");
                        //hid_fk_AcademicYr_ID.Value = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue;
                        if ((((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedIndex != 0 || ((TextBox)YCMOU.FindControl("txtCenterCode")).Text != string.Empty))
                        {
                            hidInstID.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedValue.Split('|')[0];
                            hidCollName.Value = ((DropDownList)YCMOU.FindControl("ddlStudyCenter")).SelectedItem.Text;
                            string rc_name = string.Empty;
                            if (YCMOU.IsRegionalCenterVisible)
                            {
                                if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
                                {
                                    rc_name = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text + " - ";
                                }
                                else
                                {
                                    rc_name = "All Regional Centers";
                                }
                            }
                            courseOrColl = rc_name + hidCollName.Value;
                            //DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCollege(((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue, hidInstID.Value);
                            DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCollege(hidInstID.Value);
                            if (DT.Rows.Count > 0)
                            {
                                GVPapers.DataSource = DT;
                                GVPapers.DataBind();
                                divPapers.Style.Add("display", "block");
                                btnPaperNext.Style.Add("display", "block");
                            }
                            else
                            {
                                tblExportedDataMsg.Style.Add("display", "block");
                                lblExportedData.Text = "No records found.";
                            }
                            lblAcaYear.Text = "for " + courseOrColl; //+ " [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                            hidHead.Value = lblAcaYear.Text;
                        }
                        else
                        {
                            hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
                            getFacCrMoLrnPtrnID();
                            hidCrPrDetailsID.Value = ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedValue;
                            hidCrPrChID.Value = ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedValue;
                            string rc_name = string.Empty;
                            if (YCMOU.IsRegionalCenterVisible)
                            {
                                if (((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedIndex != 0)
                                {
                                    rc_name = ((DropDownList)YCMOU.FindControl("ddlRegionalCenter")).SelectedItem.Text;
                                    courseOrColl = rc_name + " - " + ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text + " - " +
                                        ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " +
                                        ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " +
                                        ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " +
                                        ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
                                }
                                else
                                {
                                    rc_name = "All Regional Centers";
                                    courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text +
                                        " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text +
                                        " - " + ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text +
                                        " - " + ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " +
                                        ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text + " - " + rc_name;

                                }
                            }
                            else
                            {
                                courseOrColl = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedItem.Text +
                                    " - " + ((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedItem.Text + " - " +
                                    ((DropDownList)YCMOU.FindControl("ddlBranch")).SelectedItem.Text + " - " +
                                    ((DropDownList)YCMOU.FindControl("ddlPart")).SelectedItem.Text + " - " +
                                    ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
                            }

                            //DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCourse(((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedValue, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                            //    hidCrPrDetailsID.Value, hidCrPrChID.Value);
                            DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCourse(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                                hidCrPrDetailsID.Value, hidCrPrChID.Value);
                            if (DT.Rows.Count > 0)
                            {
                                GVPapers.DataSource = DT;
                                GVPapers.DataBind();
                                divPapers.Style.Add("display", "block");
                                btnPaperNext.Style.Add("display", "block");
                            }
                            else
                            {
                                tblExportedDataMsg.Style.Add("display", "block");
                                lblExportedData.Text = "No Record(s) found.";
                                divPapers.Style.Add("display", "none");
                                btnPaperNext.Style.Add("display", "none");
                            }
                            lblAcaYear.Text = "for " + courseOrColl; // +" [Academic Year " + ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text + "]";
                            hidHead.Value = lblAcaYear.Text;
                        }
                    }
                    #endregion

                    #region If redirected here from back navigation of student details page

                    else if (Page.PreviousPage.ToString().Equals("ASP.eligibility_elgv2_paperexemptionapproval__2_aspx"))
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
                        if (hidInstID.Value != string.Empty)
                        {
                            //DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCollege(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
                            DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCollege(hidInstID.Value);
                            if (DT.Rows.Count > 0)
                            {
                                GVPapers.DataSource = DT;
                                GVPapers.DataBind();
                                divPapers.Style.Add("display", "block");
                                btnPaperNext.Style.Add("display", "block");
                            }
                            else
                            {
                                Server.Transfer("ELGV2_PaperExemptionApproval.aspx", true);
                            }
                        }
                        else
                        {
                            //DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCourse(hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                            //       hidCrPrDetailsID.Value, hidCrPrChID.Value);
                            DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCourse(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                                   hidCrPrDetailsID.Value, hidCrPrChID.Value);
                            if (DT.Rows.Count > 0)
                            {
                                GVPapers.DataSource = DT;
                                GVPapers.DataBind();
                                divPapers.Style.Add("display", "block");
                                btnPaperNext.Style.Add("display", "block");
                            }
                            else
                            {
                                Server.Transfer("ELGV2_PaperExemptionApproval.aspx", true);
                            }
                        }

                        //restoring tlm-am-at selection for selected paper                        

                        if (isPaperInGrid.Equals("Yes"))
                        {
                            DT = clsCollegeAdmissionReports.PaperExemptionFetchdistinctTLMAMAT(hidSelPaper.Value);
                            if (DT.Rows.Count > 0)
                            {
                                chkTLMAMAT.DataSource = DT;
                                chkTLMAMAT.DataBind();
                            }

                            string[] tlmamats = hidSelTLMAmAt.Value.Split(',');
                            for (int k = 0; k < chkTLMAMAT.Items.Count; k++)
                            {
                                string toCheck = chkTLMAMAT.Items[k].Value + "|" + chkTLMAMAT.Items[k].Text;
                                if (hidSelTLMAmAt.Value.Contains(toCheck))
                                {
                                    chkTLMAMAT.Items[k].Selected = true;
                                }
                            }
                            divTLMAMATChoice.Style.Add("display", "block");

                            //restoring selected paper chkbox
                            for (int k = 0; k < GVPapers.Rows.Count; k++)
                            {
                                if (GVPapers.DataKeys[k].Values[0].ToString().Equals(hidSelPaper.Value))
                                {
                                    ((CheckBox)GVPapers.Rows[k].Cells[3].FindControl("chkSelectApps")).Checked = true;
                                }
                            }
                        }

                        lblAcaYear.Text = hidHead.Value;
                        if (DT != null) DT = null;
                    }

                    #endregion
                }

            }

            #region College login

            else if (user.UserTypeCode == "2")
            {
                if (Page.PreviousPage != null)
                {
                    ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                    hid_fk_AcademicYr_ID.Value = ((HtmlInputHidden)Cntph.FindControl("hid_fk_AcademicYr_ID")).Value;
                    hidInstID.Value = ((HtmlInputHidden)Cntph.FindControl("hidInstID")).Value;
                    hidCollName.Value = ((HtmlInputHidden)Cntph.FindControl("hidCollName")).Value;
                    hidAcYrForCollLogin.Value = ((HtmlInputHidden)Cntph.FindControl("hidAcYrForCollLogin")).Value;
                    courseOrColl = hidCollName.Value;
                    lblAcaYear.Text = "for " + courseOrColl + " [Academic Year " + hidAcYrForCollLogin.Value + "]";
                    hidHead.Value = lblAcaYear.Text;

                    //DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCollege(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
                    DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCollege(hidInstID.Value);
                    if (DT.Rows.Count > 0)
                    {
                        GVPapers.DataSource = DT;
                        GVPapers.DataBind();
                        divPapers.Style.Add("display", "block");
                        btnPaperNext.Style.Add("display", "block");
                    }

                    else
                    {
                        tblExportedDataMsg.Style.Add("display", "block");
                        lblExportedData.Text = "No Record(s) found.";
                        divPapers.Style.Add("display", "none");
                        btnPaperNext.Style.Add("display", "none");
                    }
                    if (Page.PreviousPage.ToString().Equals("ASP.eligibility_elgv2_paperexemptionapproval__2_aspx"))
                    {
                        hidSelPaper.Value = ((HtmlInputHidden)Cntph.FindControl("hidSelPaper")).Value;
                        hidSelTLMAmAt.Value = ((HtmlInputHidden)Cntph.FindControl("hidSelTLMAmAt")).Value;

                        //restoring tlm-am-at selection for selected paper
                        if (isPaperInGrid.Equals("Yes"))
                        {
                            DT = clsCollegeAdmissionReports.PaperExemptionFetchdistinctTLMAMAT(hidSelPaper.Value);
                            if (DT.Rows.Count > 0)
                            {
                                chkTLMAMAT.DataSource = DT;
                                chkTLMAMAT.DataBind();
                            }

                            string[] tlmamats = hidSelTLMAmAt.Value.Split(',');
                            for (int k = 0; k < chkTLMAMAT.Items.Count; k++)
                            {
                                string toCheck = chkTLMAMAT.Items[k].Value + "|" + chkTLMAMAT.Items[k].Text;
                                if (hidSelTLMAmAt.Value.Contains(toCheck))
                                {
                                    chkTLMAMAT.Items[k].Selected = true;
                                }
                            }
                            divTLMAMATChoice.Style.Add("display", "block");

                            //restoring selected paper chkbox
                            for (int k = 0; k < GVPapers.Rows.Count; k++)
                            {
                                if (GVPapers.DataKeys[k].Values[0].ToString().Equals(hidSelPaper.Value))
                                {
                                    ((CheckBox)GVPapers.Rows[k].Cells[3].FindControl("chkSelectApps")).Checked = true;
                                }
                            }
                        }

                        lblAcaYear.Text = hidHead.Value;
                        if (DT != null) DT = null;
                    }
                }
            }

            #endregion

            if (dtCollege != null)
            {
                dtCollege = null;
            }
        }

        #endregion

        #region btnPaperNext_Click

        protected void btnPaperNext_Click(object sender, EventArgs e)
        {
            divMsg.Style.Add("display", "none");
            btnDenyAll.Enabled = true;
            btnSelect.Enabled = true;
            string selpaper = string.Empty;
            hidSelPaper.Value = string.Empty;
            for (int j = 0; j < GVPapers.Rows.Count; j++)
            {
                if (((CheckBox)GVPapers.Rows[j].Cells[3].FindControl("chkSelectApps")).Checked)
                {
                    selpaper = GVPapers.DataKeys[j].Values[0].ToString();
                    break;
                }
            }
            hidSelPaper.Value = selpaper;
            DT = clsCollegeAdmissionReports.PaperExemptionFetchdistinctTLMAMAT(hidSelPaper.Value);

            if (DT.Rows.Count > 0)
            {
                chkTLMAMAT.DataSource = DT;
                chkTLMAMAT.DataBind();

            }
            divTLMAMATChoice.Style.Add("display", "block");
            lblAcaYear.Text = hidHead.Value;
        }

        #endregion

        #region getFacCrMoLrnPtrnID

        private void getFacCrMoLrnPtrnID()
        {
            if (((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedValue != "0")
            {
                IDs_List = Convert.ToString(((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedValue).Split('-');
                hidFacID.Value = Convert.ToString(IDs_List[0]).Trim();
                hidCrID.Value = Convert.ToString(IDs_List[1]).Trim();
                hidMoLrnID.Value = Convert.ToString(IDs_List[2]).Trim();
                hidPtrnID.Value = Convert.ToString(IDs_List[3]).Trim();
            }
            else
            {
                if (((DropDownList)YCMOU.FindControl("ddlCourse")).SelectedValue == "0")
                {
                    hidCrID.Value = "0";
                    hidMoLrnID.Value = "0";
                    hidPtrnID.Value = "0";
                }
                hidFacID.Value = ((DropDownList)YCMOU.FindControl("ddlFaculty")).SelectedValue;
            }
        }

        #endregion

        #region select students for approval or denialSFC_UpdateApplicationTypeConfigurationDetails

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            hidSelTLMAmAt.Value = string.Empty;
            hidTLMIDs.Value = string.Empty;
            hidAMIDs.Value = string.Empty;
            hidATIDs.Value = string.Empty;
            foreach (ListItem li in chkTLMAMAT.Items)
            {
                if (li.Selected)
                {
                    li.Text = li.Text.Replace(',', ' '); 
                    hidSelTLMAmAt.Value += li.Value + "|" + li.Text + ",";
                    hidTLMIDs.Value += li.Value.Split('-')[0].ToString() + ",";
                    hidAMIDs.Value += li.Value.Split('-')[1].ToString() + ",";
                    hidATIDs.Value += li.Value.Split('-')[2].ToString() + ",";
                }
            }
            hidTLMIDs.Value = hidTLMIDs.Value.TrimEnd(',');
            hidAMIDs.Value = hidAMIDs.Value.TrimEnd(',');
            hidATIDs.Value = hidATIDs.Value.TrimEnd(',');
            hidSelTLMAmAt.Value = hidSelTLMAmAt.Value.TrimEnd(',');
            Server.Transfer("ELGV2_PaperExemptionApproval__2.aspx", true);

        }

        #endregion

        #region deny exemption claimed for all students

        protected void btnDenyAll_Click(object sender, EventArgs e)
        {
            string resStatus = "";
            hidTLMIDs.Value = string.Empty;
            hidAMIDs.Value = string.Empty;
            hidATIDs.Value = string.Empty;
            List<PaperStudXML> oPaperStudXMLList = new List<PaperStudXML>();
            PaperStudXML oPaperStudXML;

            //-------------
            List<ExamFormModifyXML> oExamFormModifyReq = new List<ExamFormModifyXML>();
            ExamFormModifyXML ExamFormModifyReq;
            hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            //-------------

            foreach (ListItem li in chkTLMAMAT.Items)
            {
                if (li.Selected)
                {
                    hidSelTLMAmAt.Value += li.Value + "|" + li.Text + ",";
                    hidTLMIDs.Value += li.Value.Split('-')[0].ToString() + ",";
                    hidAMIDs.Value += li.Value.Split('-')[1].ToString() + ",";
                    hidATIDs.Value += li.Value.Split('-')[2].ToString() + ",";
                }
            }
            hidTLMIDs.Value = hidTLMIDs.Value.TrimEnd(',');
            hidAMIDs.Value = hidAMIDs.Value.TrimEnd(',');
            hidATIDs.Value = hidATIDs.Value.TrimEnd(',');

            //DataTable DT = clsCollegeAdmissionReports.PaperExemptionFetchStudentDetails(hidSelPaper.Value, hidInstID.Value, hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
            //             hidCrPrDetailsID.Value, hidCrPrChID.Value, hidTLMIDs.Value, hidAMIDs.Value, hidATIDs.Value);
            DataTable DT = clsCollegeAdmissionReports.PaperExemptionFetchStudentDetails(hidSelPaper.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
              hidCrPrDetailsID.Value, hidCrPrChID.Value, hidTLMIDs.Value, hidAMIDs.Value, hidATIDs.Value);

            if (DT.Rows.Count != 0)
            {
                for (int j = 0; j < DT.Rows.Count; j++)
                {
                    oPaperStudXML = new PaperStudXML();
                    oPaperStudXML.StudentID = int.Parse(DT.Rows[j]["pk_Student_ID"].ToString());
                    oPaperStudXML.TLM = int.Parse(DT.Rows[j]["TLM-AM-AT-ID"].ToString().Split('-')[0]);
                    oPaperStudXML.Year = int.Parse(DT.Rows[j]["pk_Year"].ToString());
                    oPaperStudXML.AM = int.Parse(DT.Rows[j]["TLM-AM-AT-ID"].ToString().Split('-')[1]);
                    oPaperStudXML.AT = int.Parse(DT.Rows[j]["TLM-AM-AT-ID"].ToString().Split('-')[2]);
                    oPaperStudXML.FacID = int.Parse(DT.Rows[j]["pk_Fac_ID"].ToString());
                    oPaperStudXML.Pk_Pp_PpHead_CrPrCh_ID = int.Parse(DT.Rows[j]["pk_Pp_PpHead_CrPrCh_ID"].ToString());
                    oPaperStudXML.CRID = int.Parse(DT.Rows[j]["pk_Cr_ID"].ToString());
                    oPaperStudXML.MOLID = int.Parse(DT.Rows[j]["pk_MoLrn_ID"].ToString());
                    oPaperStudXML.PtrnID = int.Parse(DT.Rows[j]["pk_Ptrn_ID"].ToString());
                    oPaperStudXML.BrnID = int.Parse(DT.Rows[j]["pk_Brn_ID"].ToString());
                    oPaperStudXML.CrPrDetID = int.Parse(DT.Rows[j]["pk_CrPr_Details_ID"].ToString());
                    oPaperStudXML.CrPrChtID = int.Parse(DT.Rows[j]["pk_CrPrCh_ID"].ToString());
                    oPaperStudXML.UniID = int.Parse(DT.Rows[j]["pk_Uni_ID"].ToString());
                    oPaperStudXMLList.Add(oPaperStudXML);


                    //---------------
                    ExamFormModifyReq = new ExamFormModifyXML();
                    ExamFormModifyReq.UniID = int.Parse(hidUniID.Value);
                    ExamFormModifyReq.StudentID = int.Parse(DT.Rows[j]["pk_Student_ID"].ToString());
                    ExamFormModifyReq.Year = int.Parse(DT.Rows[j]["pk_Year"].ToString());
                    ExamFormModifyReq.AcYrID = int.Parse(DT.Rows[j]["fk_AcademicYear_ID"].ToString());
                    ExamFormModifyReq.InstID = int.Parse(DT.Rows[j]["Ref_InstReg_Institute_ID"].ToString());
                    ExamFormModifyReq.FacID = int.Parse(DT.Rows[j]["pk_Fac_ID"].ToString());
                    ExamFormModifyReq.CrID = int.Parse(DT.Rows[j]["pk_Cr_ID"].ToString());
                    ExamFormModifyReq.MoLrnID = int.Parse(DT.Rows[j]["pk_MoLrn_ID"].ToString());
                    ExamFormModifyReq.PtrnID = int.Parse(DT.Rows[j]["pk_Ptrn_ID"].ToString());
                    ExamFormModifyReq.BrnID = int.Parse(DT.Rows[j]["pk_Brn_ID"].ToString());
                    ExamFormModifyReq.CrPrDetailsID = int.Parse(DT.Rows[j]["pk_CrPr_Details_ID"].ToString());
                    ExamFormModifyReq.CrPrChID = int.Parse(DT.Rows[j]["pk_CrPrCh_ID"].ToString());
                    ExamFormModifyReq.CreatedBy = user.User_ID.ToString();
                    //ExamFormModifyReq.RequestDetails = createExamFormModifyXML(ExamFormModifyReq.StudentID, ExamFormModifyReq.Year);
                    oExamFormModifyReq.Add(ExamFormModifyReq);
                    //---------------

                }
                int result = clsCollegeAdmissionReports.PaperExemptionApproveOrDeny(user.User_ID, 2, PaperStudXML.SerializeObject(oPaperStudXMLList));
                // int result = 1;

                if (result != 0)
                {
                    divMsg.Style.Add("display", "block");
                    lblAppOrDenyMsg.Text = "The Exemption claimed is denied successfully for the selected " + lblPaper.Text + "(s).";
                    btnDenyAll.Enabled = false;
                    btnSelect.Enabled = false;
                    resStatus = clsPaperChange.SendExamFormModifyRequest_PaperExemptionApproval_MultipleStuds(ExamFormModifyXML.SerializeObject(oExamFormModifyReq)).ToString();

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


                }
                else
                {
                    divMsg.Style.Add("display", "block");
                    lblAppOrDenyMsg.Text = "An error has occurred. Please try again later.";
                }
            }
            else
            {
                divMsg.Style.Add("display", "block");
                lblAppOrDenyMsg.Text = "<br>Exemption Approval decision has already been taken for selected " + lblPaper.Text + "(s) and selected assessment type.";
            }

            //refill grid view

            if (hidInstID.Value == "")
            {

                //DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCourse(hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                //    hidCrPrDetailsID.Value, hidCrPrChID.Value);
                DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCourse(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(Session["BranchID"]),
                   hidCrPrDetailsID.Value, hidCrPrChID.Value);
            }
            else
            {
                //DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCollege(hid_fk_AcademicYr_ID.Value, hidInstID.Value);
                DT = clsCollegeAdmissionReports.ListStudentCountForPaperExemptionApprovalSelectedCollege(hidInstID.Value);
            }
            if (DT.Rows.Count > 0)
            {
                GVPapers.DataSource = DT;
                GVPapers.DataBind();
                divPapers.Style.Add("display", "block");
                btnPaperNext.Style.Add("display", "block");
            }
            else
            {
                tblExportedDataMsg.Style.Add("display", "block");
                lblExportedData.Text = "No Record(s) found.";
                divPapers.Style.Add("display", "none");
                btnPaperNext.Style.Add("display", "none");
            }

        }

        #endregion

        //setting string to yes if paper still exists in grid after we return from the grant-deny page
        protected void GVPapers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (isPaperInGrid.Equals(string.Empty))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (hidSelPaper.Value == GVPapers.DataKeys[e.Row.RowIndex]["pk_Pp_PpHead_CrPrCh_ID"].ToString())
                    {
                        isPaperInGrid = "Yes";
                    }
                }
            }
        }


        # region Function CreateXML for Exam Form Modify Request
        /// <summary>
        /// Function Create XML (This will Xml for Papers with its Group Details)
        /// </summary>
        public string createExamFormModifyXML(int StudentID, int Year)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateNode(XmlNodeType.Element, "R", "");
            XmlNode child = xml.CreateNode(XmlNodeType.Element, "RT", "");
            child.Attributes.Append(xml.CreateAttribute("Type")).Value = "MEF";
            XmlNode student = xml.CreateNode(XmlNodeType.Element, "STU", "");
            student.Attributes.Append(xml.CreateAttribute("Year")).Value = Year.ToString();
            student.Attributes.Append(xml.CreateAttribute("StudentID")).Value = StudentID.ToString();
            child.AppendChild(student);
            root.AppendChild(child);
            xml.AppendChild(root);
            return xml.OuterXml;
        }

        #endregion
    }
}

