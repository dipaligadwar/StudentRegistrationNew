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

namespace StudentRegistration.Eligibility
{
    public partial class MatchingProfile : System.Web.UI.Page
    {
        #region Variable declaration
        Hashtable ht;
        clsEligibilityDBAccess oElg;
        DataTable dt;
        DataSet ds;
        #endregion

        #region Bind grid for auto match
        /// <summary>
        /// Bind grid for auto match
        /// </summary>
        /// <param name="e"></param>
        private void bindGrid(RepeaterCommandEventArgs e)
        {
            DataTable odt = (DataTable)ViewState["AutoGeneratedData"];
            DataView odv = odt.DefaultView;
            if (e == null)
            {
                LinkButton item = (LinkButton)rptStudNameIntials.Items[0].FindControl("lnkbtn");
                odv.RowFilter = "Student_Name like '" + item.Text + "%'";
                SetEnabled(item);
            }
            else
            {
                odv.RowFilter = "Student_Name like '" + e.CommandArgument + "%'";
            }

            ViewState["FilteredData"] = odv.ToTable();
            if (odv.ToTable().Rows.Count > 0)
            {
                divGridHead.Attributes.Add("style", "display:inline;");
                gVsysDuplicate.DataSource = odv.ToTable();
                gVsysDuplicate.DataBind();
            }
            else
            {
                divGridHead.Attributes.Add("style", "display:none;");
            }          
        }
        #endregion

        #region Bind grid for manual match
        /// <summary>
        /// Bind grid for manual match
        /// </summary>
        private void bindManualSearchGrid()
        {
            CreateHashTable();
            oElg = new clsEligibilityDBAccess();

            ds = new DataSet();
            ds = oElg.ManualProfileMatch(ht);
            if (ds.Tables[0].Rows.Count == 1)
            {
                if (ds.Tables[0].Rows[0]["LockedProfile"].ToString() == "1")
                {
                    ManualSearch.Attributes.Add("style", "display:inline;width:100%");
                    lblSmplSrch.Attributes.Add("style", "display:inline");
                    lblSmplSrch.Text = "(Match Profile Automatically)";
                    divNote.Attributes.Add("style", "display:none");
                    ManualSrchGrid.Attributes.Add("style", "display:none");
                    lblErrorMsg.Attributes.Add("style", "display:inline");

                    string sCriteria = string.Empty;
                    if (txtPRN.Text != string.Empty)
                    {
                        sCriteria = sCriteria + lblPRN.Text + ", ";
                    }
                    if (txtOldPRN.Text != string.Empty)
                    {
                        sCriteria = sCriteria + Label2.Text + ", ";
                    }
                    if (txtElgFrmNo.Text != string.Empty)
                    {
                        sCriteria = sCriteria + "Eligibility form number,";
                    }

                    sCriteria = sCriteria.Remove(sCriteria.LastIndexOf(','));
                    lblErrorMsg.Text = "Merge/Delete Profile request for this profile is already submitted and is in process.";
                    return;
                }
                if (Convert.ToString(ds.Tables[0].Rows[0]["PRN_Number"]).Trim() == string.Empty || Convert.ToString(ds.Tables[0].Rows[0]["PRN_Number"]).Trim() == "Not Available")
                {
                    ManualSearch.Attributes.Add("style", "display:inline;width:100%");
                    lblSmplSrch.Attributes.Add("style", "display:inline");
                    lblSmplSrch.Text = "(Match Profile Automatically)";
                    divNote.Attributes.Add("style", "display:none");
                    ManualSrchGrid.Attributes.Add("style", "display:none");
                    lblErrorMsg.Attributes.Add("style", "display:inline");

                    string sCriteria = string.Empty;
                    if (txtPRN.Text != string.Empty)
                    {
                        sCriteria = sCriteria + lblPRN.Text + ", ";
                    }
                    if (txtOldPRN.Text != string.Empty)
                    {
                        sCriteria = sCriteria + Label2.Text + ", ";
                    }
                    if (txtElgFrmNo.Text != string.Empty)
                    {
                        sCriteria = sCriteria + "Eligibility form number,";
                    }

                    sCriteria = sCriteria.Remove(sCriteria.LastIndexOf(','));
                    lblErrorMsg.Text = (string)GetLocalResourceObject("lblPRNResource1.Text") + " does not exists for the searched student.";
                    return;
                }

                lblSubHeader.Text = "<B>Student: </B>" + Convert.ToString(ds.Tables[0].Rows[0]["StudentName"]) + ", <B>" + lblPRN.Text + ": </B>" + Convert.ToString(ds.Tables[0].Rows[0]["PRN_Number"]) + ", <B>" + Label2.Text + ": </B>" + Convert.ToString(ds.Tables[0].Rows[0]["OldPRN_Number"]);               
              
                if (ds.Tables[1].Rows.Count > 1)
                {
                    ManualSrchGrid.Attributes.Add("style", "display:inline");
                    divMCriteria.Attributes.Add("style", "display:inline");
                    Mcriteria.InnerText = hid_MatchingCriteria.Value;

                    int TotalMatchingCount = Convert.ToInt32(ds.Tables[2].Rows[0][0]);
                    if (TotalMatchingCount > 5)
                    {                       
                        gCaption.InnerHtml = "<b>Showing Top 5 Student Profiles out of " + TotalMatchingCount + " Matching Profiles found.</b>";
                    }

                    lblErrorMsg.Attributes.Add("style", "display:none");                    
                    divNote.Attributes.Add("style", "display:inline");
                    ManualInfo.Attributes.Add("style", "display:inline");
                    AutoGeneratedInfo.Attributes.Add("style", "display:none");
                    hid_BaseStudentIDs.Value = ds.Tables[0].Rows[0][0].ToString();
                    gVSearchDuplicate.DataSource = ds.Tables[1];
                    gVSearchDuplicate.DataBind();
                }
                else
                {
                    lblErrorMsg.Attributes.Add("style", "display:inline");
                    lblErrorMsg.Text = "No Matching Profile Found.";

                    ManualSrchGrid.Attributes.Add("style", "display:none");
                    divMCriteria.Attributes.Add("style", "display:none");
                    divNote.Attributes.Add("style", "display:none");
                    ManualSearch.Attributes.Add("style", "display:inline;width:100%");
                    lblSmplSrch.Attributes.Add("style", "display:inline");
                    lblSmplSrch.Text = "(Match Profile Automatically)";
                }
            }
            else
            {
                ManualSearch.Attributes.Add("style", "display:inline;width:100%");
                lblSmplSrch.Attributes.Add("style", "display:inline");
                lblSmplSrch.Text = "(Match Profile Automatically)";
                divNote.Attributes.Add("style", "display:none");
                ManualSrchGrid.Attributes.Add("style", "display:none");
                lblErrorMsg.Attributes.Add("style", "display:inline");

                string sCriteria = string.Empty;
                if (txtPRN.Text != string.Empty)
                {
                    sCriteria = sCriteria + lblPRN.Text+", ";
                }
                if (txtOldPRN.Text != string.Empty)
                {
                    sCriteria = sCriteria + Label2.Text + ", ";
                }
                if (txtElgFrmNo.Text != string.Empty)
                {
                    sCriteria = sCriteria + "Eligibility form number,";
                }

                sCriteria = sCriteria.Remove(sCriteria.LastIndexOf(','));
                lblErrorMsg.Text = "Given " + sCriteria + " doesn't exists.";
            }
        }
        #endregion

        #region Create Hashtable
        private void CreateHashTable()
        {
            ht = new Hashtable();
            ht.Add("PRN_Number", txtPRN.Text.Trim());
            ht.Add("OldPRN_Number", txtOldPRN.Text.Trim());
            ht.Add("ElgFormNo", txtElgFrmNo.Text.Trim());
            ht.Add("Last_Name", Convert.ToString(chkLastName.Checked).Trim());
            ht.Add("First_Name", Convert.ToString(chkFirstName.Checked).Trim());
            ht.Add("Middle_Name", Convert.ToString(chkMiddleName.Checked).Trim());
            ht.Add("Father_Last_Name", Convert.ToString(chkFatherLastName.Checked).Trim());
            ht.Add("Father_First_Name", Convert.ToString(chkFatherFistName.Checked).Trim());
            ht.Add("Father_Middle_Name", Convert.ToString(chkFatherMiddleName.Checked).Trim());
            ht.Add("Mother_Last_Name", Convert.ToString(chkMotherLastName.Checked).Trim());
            ht.Add("Mother_First_Name", Convert.ToString(chkMotherFirstName.Checked).Trim());
            ht.Add("Mother_Middle_Name", Convert.ToString(chkMotherMiddleName.Checked).Trim());
            ht.Add("Qual10", Convert.ToString(chkTenth.Checked).Trim());
            ht.Add("Qual12", Convert.ToString(chkTweelth.Checked).Trim());
        }
        #endregion

        #region Enabling/Disabling links for Initials sorting
        private void SetEnabled(LinkButton alnk)
        {

            foreach (RepeaterItem it in rptStudNameIntials.Items)
            {
                LinkButton lnk = (LinkButton)it.FindControl("lnkbtn");
                if (lnk.Text == alnk.Text)
                {
                    lnk.Enabled = false;
                }
                else
                {
                    lnk.Enabled = true;
                }
            }
        }
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
            }
            catch
            {
                if (hidIsPRNValidationRequired.Value == "")
                {
                    hidIsPRNValidationRequired.Value = "N";
                }
            }

            if (!IsPostBack)
            {
                oElg = new clsEligibilityDBAccess();
                dt = new DataTable();
                dt = oElg.ListMatchingProfiles();
                if (dt.Rows.Count > 0)
                {
                    DataView odv = dt.DefaultView;
                    ViewState["AutoGeneratedData"] = dt;

                    lblcnt.Text = "Total Profiles matched by the system: " + Convert.ToString(dt.Rows.Count);

                    rptStudNameIntials.DataSource = odv.ToTable(true, "StudentNameIntials");
                    rptStudNameIntials.DataBind();

                    bindGrid(null);
                }
                else
                {
                    lblcnt.Text = "Total Profiles matched by the system: 0";
                    divGridHead.Attributes.Add("style", "display:none;");
                }
            }
        }
        #endregion

        #region Initials(A-Z) sorting event
        protected void rptStudNameIntials_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "FilterName")
            {               
                AutoGenerated.Attributes.Add("style", "display:inline");
                rpt.Attributes.Add("style", "display:inline");
                divNote.Attributes.Add("style", "display:inline");
                AutoGeneratedInfo.Attributes.Add("style", "display:inline");
                divMCriteria.Attributes.Add("style", "display:none");
                ManualInfo.Attributes.Add("style", "display:none");
                ManualSearch.Attributes.Add("style", "display:none");
                ManualSrchGrid.Attributes.Add("style", "display:none");
                lblSmplSrch.Text = "(Match Profile Manually)";

                lblErrorMsg.Attributes.Add("style", "display:none");
                LinkButton lnk = (LinkButton)e.CommandSource;
                SetEnabled(lnk);

                bindGrid(e);
            }
        }
        #endregion

        #region View Details events for auto match
        protected void gVsysDuplicate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                hid_Matching_Profile_ID.Value =Convert.ToString(e.CommandArgument);
                Server.Transfer("MatchingProfile__1.aspx");
            }
        }
        #endregion

        #region Paging for auto match
        protected void gVsysDuplicate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gVsysDuplicate.PageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["FilteredData"];
            if (dt.Rows.Count > 0)
            {
                divGridHead.Attributes.Add("style", "display:inline;");
                gVsysDuplicate.DataSource = dt;
                gVsysDuplicate.DataBind();
            }
            else
            {
                divGridHead.Attributes.Add("style", "display:none;");
            }             
        }
        #endregion

        #region Search for manual match
        protected void btnSrch_Click(object sender, EventArgs e)
        {           
            AutoGenerated.Attributes.Add("style", "display:none");
            rpt.Attributes.Add("style", "display:none");
            ManualSearch.Attributes.Add("style", "display:none ");
            lblSmplSrch.Attributes.Add("style", "display:inline");
            lblSmplSrch.Text = "(Change Filter Criteria)";

            SetMatchingCriteria();
            bindManualSearchGrid();
        }
        #endregion

        #region Compare button click for manual match
        protected void btnCompareProfile_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in gVSearchDuplicate.Rows)
            {
                hid_MatchingStudentIDs.Value += gr.Cells[5].Text+",";
                
            }
            hid_MatchingStudentIDs.Value = hid_MatchingStudentIDs.Value.Remove(hid_MatchingStudentIDs.Value.LastIndexOf(','));
            
            Server.Transfer("MatchingProfile__2.aspx");
        }
        #endregion

        #region Setting matching criteria
        private void SetMatchingCriteria()
        {
            hid_MatchingCriteria.Value = string.Empty;
            if (chkLastName.Checked)
            {
                hid_MatchingCriteria.Value += chkLastName.Text + ", ";
            }
            if (chkFirstName.Checked)
            {
                hid_MatchingCriteria.Value += chkFirstName.Text + ", ";
            }
            if (chkMiddleName.Checked)
            {
                hid_MatchingCriteria.Value += chkMiddleName.Text + ", ";
            }
            if (chkFatherLastName.Checked)
            {
                hid_MatchingCriteria.Value += chkFatherLastName.Text + ", ";
            }
            if (chkFatherFistName.Checked)
            {
                hid_MatchingCriteria.Value += chkFatherFistName.Text + ", ";
            }
            if (chkFatherMiddleName.Checked)
            {
                hid_MatchingCriteria.Value += chkFatherMiddleName.Text + ", ";
            }
            if (chkMotherLastName.Checked)
            {
                hid_MatchingCriteria.Value += chkMotherLastName.Text + ", ";
            }
            if (chkMotherFirstName.Checked)
            {
                hid_MatchingCriteria.Value += chkMotherFirstName.Text + ", ";
            }
            if (chkMotherMiddleName.Checked)
            {
                hid_MatchingCriteria.Value += chkMotherMiddleName.Text + ", ";
            }
            if (chkTenth.Checked)
            {
                hid_MatchingCriteria.Value += chkTenth.Text + ", ";
            }
            if (chkTweelth.Checked)
            {
                hid_MatchingCriteria.Value += chkTweelth.Text + ", ";
            }

            hid_MatchingCriteria.Value = hid_MatchingCriteria.Value.Remove(hid_MatchingCriteria.Value.LastIndexOf(','));
        }
        #endregion

        #region Highlighting Base profile
        protected void gVSearchDuplicate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text.Trim() == hid_BaseStudentIDs.Value.Trim())
                {
                    e.Row.CssClass = "saveNote";
                }
            }
        }
        #endregion
    }
}