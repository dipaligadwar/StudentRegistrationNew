using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Configuration;
using System.Xml;

namespace StudentRegistration.Eligibility
{
    public partial class EligibilityIndex : System.Web.UI.Page
    {
        clsUser userob = new clsUser();
        string username = "";
        clsCache clsCache = new clsCache();
        DataTable dt;
        string AcYrText = string.Empty;
        string Module_Key = string.Empty;

        #region Page_Load

        protected void Page_Load(object sender, System.EventArgs e)
        {
            clsCache.NoCache();
            userob = (clsUser)Session["User"];
            username = userob.Name.ToString();
            lblContentTitle.Text = "Welcome " + username + " !";
            lblUpdationDate.Text = " You have logged as ";
            lblUpdationDate.Text += userob.PrimaryRole != null ? userob.PrimaryRoleName : "";
            lblUpdationDate.Text += " and your last logon was " + userob.LastLogonTime + "";

            //  DisplayImage();
            if (userob.UserTypeCode != "2")
            {
                DisplayPanels_MIS_Panel_Master();
            }

        }

        #endregion

        #region Panel Filling OLD
        // Not in use

        //public void DisplayPanels()
        //{

        //    //setting Uni ID and Ac Yr ID

        //    dt = clsEligibilityDBAccess.GetAcademicYearID(DateTime.Now.Year.ToString());

        //    if (dt.Rows.Count > 0)
        //    {
        //        hid_fk_AcademicYear_ID.Value = dt.Rows[0]["pk_AcademicYear_ID"].ToString();
        //        AcYrText = dt.Rows[0]["AcYrText"].ToString();
        //    }
        //    else
        //    {
        //        hid_fk_AcademicYear_ID.Value = "0";
        //        AcYrText = "";
        //    }
        //    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();

        //    //Added for Testing as no Data available for current Academic Year
        //    //hid_fk_AcademicYear_ID.Value = "3";

        //    //setting redirect URLs

        //    linkMoreUplDiscStats.NavigateUrl = clsGetSettings.SitePath + "Eligibility/ELGV2_rptMIS.aspx?LandingPgStats=" + hid_fk_AcademicYear_ID.Value + "|" + AcYrText;
        //    linkMorePendingForElgProc.NavigateUrl = clsGetSettings.SitePath + "Eligibility/ELGV2_rptMIS.aspx?LandingPgStats=" + hid_fk_AcademicYear_ID.Value + "|" + AcYrText;
        //    linkMoreUnprocElgStats.NavigateUrl = clsGetSettings.SitePath + "Eligibility/ELGV2_rptMIS.aspx?LandingPgStats=" + hid_fk_AcademicYear_ID.Value + "|" + AcYrText;

        //    //fill Pending Elg Proc Panel

        //    dt = clsEligibilityDBAccess.FillPendingProvisionalEligibilityCount_Panel(hid_fk_AcademicYear_ID.Value, hidUniID.Value);
        //    if (dt == null)
        //    {
        //        lblNoRecPendingForElgProc.Text = "Currently the Pending Eligibility cases cannot be retrieved.";
        //        linkMorePendingForElgProc.Enabled = false;
        //    }
        //    else
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            GV_PendingForElgProc.DataSource = dt;
        //            GV_PendingForElgProc.DataBind();
        //            lblNoRecPendingForElgProc.Text = "";
        //        }
        //        else
        //        {
        //            lblNoRecPendingForElgProc.Text = "Currently No Pending Eligibility cases found.";
        //            linkMorePendingForElgProc.Enabled = false;
        //        }
        //    }


        //    //fill Unproc Elg Stats Panel
        //    dt = clsEligibilityDBAccess.FillUploadedNotProcessedEligibilityCount_Panel(hid_fk_AcademicYear_ID.Value, hidUniID.Value);
        //    if (dt == null)
        //    {
        //        lblNoRecUnprocElgStats.Text = "Currently the Unprocessed Eligibility cases cannot be retrieved.";
        //        linkMoreUnprocElgStats.Enabled = false;
        //    }
        //    else
        //    {

        //        if (dt.Rows.Count > 0)
        //        {
        //            GV_UnprocElgStats.DataSource = dt;
        //            GV_UnprocElgStats.DataBind();
        //            lblNoRecUnprocElgStats.Text = "";
        //        }
        //        else
        //        {
        //            lblNoRecUnprocElgStats.Text = "Currently No Unprocessed Eligibility cases found.";
        //            linkMoreUnprocElgStats.Enabled = false;
        //        }
        //    }

        //    //fill Upload Disc Stats Panel
        //    dt = clsEligibilityDBAccess.FillUploadedDiscrepancyStatistics_Panel(hid_fk_AcademicYear_ID.Value, hidUniID.Value);
        //    if (dt == null)
        //    {
        //        lblNoRecUplDiscStats.Text = "Currently the Upload Discrepancy cases cannot be retrieved.";
        //        linkMoreUplDiscStats.Enabled = false;
        //    }
        //    else
        //    {

        //        if (dt.Rows.Count > 0)
        //        {
        //            GV_UploadDiscStats.DataSource = dt;
        //            GV_UploadDiscStats.DataBind();
        //            lblNoRecUplDiscStats.Text = "";
        //        }
        //        else
        //        {
        //            lblNoRecUplDiscStats.Text = "Currently No Upload Discrepancies found.";
        //            linkMoreUplDiscStats.Enabled = false;
        //        }
        //    }

        //    //fill Pending Exemption Approval Panel
        //    dt = clsEligibilityDBAccess.FillPendingExemptionApproval_Panel(hid_fk_AcademicYear_ID.Value, hidUniID.Value);
        //    if (dt == null)
        //    {
        //        lblNoRecExemAppPending.Text = "Currently the Pending Exemption Approval cases cannot be retrieved.";
        //        linkMorePendingExApproval.Enabled = false;
        //    }
        //    else
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            GV_PendingExApproval.DataSource = dt;
        //            GV_PendingExApproval.DataBind();
        //            lblNoRecExemAppPending.Text = "";
        //            linkMorePendingExApproval.NavigateUrl = "ELGV2_rptPaperExemptionCoursewise.aspx";
        //        }
        //        else
        //        {
        //            lblNoRecExemAppPending.Text = "Currently No Pending Exemption Approval cases found.";
        //            linkMorePendingExApproval.Enabled = false;
        //        }
        //    }
        //}

        #endregion

        #region Panels Filling NEW
        //==========================================================================
        public void DisplayPanels_MIS_Panel_Master()
        {
            //setting Ac Yr ID to pass to redirected reports
            dt = clsEligibilityDBAccess.GetAcademicYearID(DateTime.Now.Year.ToString());

            if (dt.Rows.Count > 0)
            {
                hid_fk_AcademicYear_ID.Value = dt.Rows[0]["pk_AcademicYear_ID"].ToString();
                AcYrText = dt.Rows[0]["AcYrText"].ToString();
            }
            else
            {
                hid_fk_AcademicYear_ID.Value = "0";
                AcYrText = "";
            }

            DataTable DT_Panel = new DataTable();
            XmlDataSource xmldata = new XmlDataSource();

            //Fetch Data for all Panels from MIS_Panel_Master
            Module_Key = "StudentRegistration";
            dt = clsEligibilityDBAccess.FillAllPanels(Module_Key);

            //setting redirect URLs

            linkMoreUplDiscStats.NavigateUrl = clsGetSettings.SitePath + "Eligibility/ELGV2_rptMIS.aspx?LandingPgStats=" + hid_fk_AcademicYear_ID.Value + "|" + AcYrText;
            linkMorePendingForElgProc.NavigateUrl = clsGetSettings.SitePath + "Eligibility/ELGV2_rptMIS.aspx?LandingPgStats=" + hid_fk_AcademicYear_ID.Value + "|" + AcYrText;
            linkMoreUnprocElgStats.NavigateUrl = clsGetSettings.SitePath + "Eligibility/ELGV2_rptMIS.aspx?LandingPgStats=" + hid_fk_AcademicYear_ID.Value + "|" + AcYrText;
            linkMoreMergeProfileStat.NavigateUrl = clsGetSettings.SitePath + "Eligibility/MatchingProfile__4.aspx";
            linkMorePendingExApproval.NavigateUrl = clsGetSettings.SitePath + "Eligibility/ELGV2_rptPaperExemptionCoursewise.aspx";

            if (dt == null)
            {

            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow Dr in dt.Rows)
                    {
                        //----------------------------------------------------------------------------------------------------------
                        // Paper Exemption Panel
                        if (Dr["Panel_Key"].ToString() == "pnlPendingExApproval")
                        {
                            if (Dr["Panel_Content"].ToString() != "")
                            {
                                xmldata.Data = Dr["Panel_Content"].ToString();
                                System.IO.StringReader lstr_temp = new System.IO.StringReader(xmldata.Data);
                                DataSet ds = new DataSet();
                                ds.ReadXml(lstr_temp);
                               // GV_PendingExApproval.DataSource = ds.Tables[0];
                             //   GV_PendingExApproval.DataBind();
                                //lblPendingExApprovalUpdatedOn.Text = "[Last Updated On " + Dr[1].ToString() + "]";
                             //   lblNoRecExemAppPending.Visible = false;
                            }
                            else
                            {

                           //     lblNoRecExemAppPending.Visible = true;
                                linkMorePendingExApproval.Enabled = false;
                                //lblPendingExApprovalUpdatedOn.Text = "";
                            }
                         //   lblPendingExApprovalUpdatedOn.Text = "[Last Updated On " + Dr[1].ToString() + "]";
                        }
                        //----------------------------------------------------------------------------------------------------------
                        // Pending Provisional Panel
                        if (Dr["Panel_Key"].ToString() == "pnlPendingProvisional")
                        {
                            if (Dr["Panel_Content"].ToString() != "")
                            {
                                xmldata.Data = Dr["Panel_Content"].ToString();
                                System.IO.StringReader lstr_temp = new System.IO.StringReader(xmldata.Data);
                                DataSet ds = new DataSet();
                                ds.ReadXml(lstr_temp);
                              //  GV_PendingForElgProc.DataSource = ds.Tables[0];
                              //  GV_PendingForElgProc.DataBind();
                                //lblPendingProvisionalUpdatedOn.Text = "[Last Updated On " + Dr[1].ToString() + "]";
                             //   lblNoRecPendingForElgProc.Visible = false;
                            }
                            else
                            {
                              //  lblNoRecPendingForElgProc.Visible = true;
                                linkMorePendingForElgProc.Enabled = false;
                                //lblPendingProvisionalUpdatedOn.Text = "";
                            }
                         //   lblPendingProvisionalUpdatedOn.Text = "[Last Updated On " + Dr[1].ToString() + "]";
                        }
                        //----------------------------------------------------------------------------------------------------------
                        // Uploaded Discrepancy Panel
                        if (Dr["Panel_Key"].ToString() == "pnlUploadDiscrepancy")
                        {
                            if (Dr["Panel_Content"].ToString() != "")
                            {
                                xmldata.Data = Dr["Panel_Content"].ToString();
                                System.IO.StringReader lstr_temp = new System.IO.StringReader(xmldata.Data);
                                DataSet ds = new DataSet();
                                ds.ReadXml(lstr_temp);

                            //    GV_UploadDiscStats.DataSource = ds.Tables[0];
                            //    GV_UploadDiscStats.DataBind();
                                //lblUploadDiscrepancyUpdatedOn.Text = "[Last Updated On " + Dr[1].ToString() + "]";
                            //    lblNoRecUplDiscStats.Visible = false;

                            }
                            else
                            {
                              //  lblNoRecUplDiscStats.Visible = true;
                                linkMoreUplDiscStats.Enabled = false;
                                //lblUploadDiscrepancyUpdatedOn.Text = "";
                            }
                         //   lblUploadDiscrepancyUpdatedOn.Text = "[Last Updated On " + Dr[1].ToString() + "]";
                        }
                        //----------------------------------------------------------------------------------------------------------
                        // Not Processed Eligibility Panel
                        if (Dr["Panel_Key"].ToString() == "pnlNotProcessedEligibility")
                        {
                            if (Dr["Panel_Content"].ToString() != "")
                            {
                                xmldata.Data = Dr["Panel_Content"].ToString();
                                System.IO.StringReader lstr_temp = new System.IO.StringReader(xmldata.Data);
                                DataSet ds = new DataSet();
                                ds.ReadXml(lstr_temp);

                               // GV_UnprocElgStats.DataSource = ds.Tables[0];
                               // GV_UnprocElgStats.DataBind();
                                //lblNotProcessedEligibilityUpdatedOn.Text = "[Last Updated On " + Dr[1].ToString() + "]";
                              //  lblNoRecUnprocElgStats.Visible = false;
                            }
                            else
                            {
                              
                              //  lblNoRecUnprocElgStats.Visible = true;
                                linkMoreUnprocElgStats.Enabled = false;
                                //lblNotProcessedEligibilityUpdatedOn.Text = "";
                            }
                          //  lblNotProcessedEligibilityUpdatedOn.Text = "[Last Updated On " + Dr[1].ToString() + "]";
                        }
                        //----------------------------------------------------------------------------------------------------------
                        // Merge Profile Request Statistics Panel
                        if (Dr["Panel_Key"].ToString() == "pnlMergeProfileStat")
                        {
                            if (Dr["Panel_Content"].ToString() != "")
                            {
                                xmldata.Data = Dr["Panel_Content"].ToString();
                                System.IO.StringReader lstr_temp = new System.IO.StringReader(xmldata.Data);
                                DataSet ds = new DataSet();
                                ds.ReadXml(lstr_temp);
                             //   GV_MergeProfileStat.DataSource = ds.Tables[0];
                             //   GV_MergeProfileStat.DataBind();
                            //    GV_MergeProfileStat.Visible = true;
                                //lblMergeProfileStat.Text = "[Last Updated On " + Dr[1].ToString() + "]";
                             //   lblNoRecMergeProfileStat.Visible = false;
                            }
                            else
                            {
                             //   GV_MergeProfileStat.Visible = false;
                            //    lblNoRecMergeProfileStat.Visible = true;
                             //   linkMoreMergeProfileStat.Enabled = false;
                                //lblMergeProfileStat.Text = "";
                            }
                         //   lblMergeProfileStat.Text = "[Last Updated On " + Dr[1].ToString() + "]";
                        }
                        //----------------------------------------------------------------------------------------------------------
                    }


                }

            }
        }
        //==========================================================================

        #endregion

        #region InitializeCulture

        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion

        #region Display Image
        //public void DisplayImage()
        //{
        //    Hashtable hTable = new Hashtable();
        //    DataTable dtImg = new DataTable();
        //    clsUserMaster objUserMaster = new clsUserMaster();
        //    hTable.Clear();
        //    hTable.Add("User_ID", userob.User_ID.ToString().Trim());
        //    dtImg = objUserMaster.getUserInfo(hTable);
        //    if (dtImg.Rows.Count > 0)
        //    {

        //        if (dtImg.Rows[0]["Image_URL"].ToString() != "" && dtImg.Rows[0]["Image_URL"] != null)
        //        {
        //           // tdImage.Attributes.Add("style", "display:block");
        //            tdImage.Style.Add("display", "block");
        //            imgContainer.Visible = true;
        //            imgContainer.ImageUrl = Classes.clsGetSettings.SitePath + "/Admin/Images/" + dtImg.Rows[0]["Image_URL"].ToString();

        //        }
        //        else
        //        {
        //            imgContainer.Visible = false;
        //            imgContainer.ImageUrl = "";
        //        }

        //    }
        //    else
        //    {
        //        imgContainer.Visible = false;
        //        imgContainer.ImageUrl = "";
        //    }
        //    dtImg.Dispose();

        //}

        #endregion

    }
}
