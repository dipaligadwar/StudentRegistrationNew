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
using System.Text;
using DUConfigurations;

namespace StudentRegistration.Eligibility
{
    public partial class MatchingProfile__3 : System.Web.UI.Page
    {
        #region Variable declaration
        clsCommon common = null;
        clsEligibilityDBAccess oclsEligibilityDBAccess = null;
        clsUser user;
        DataSet ds = null;
        clsCommon oCommon = new clsCommon();
        clsCache oCache = new clsCache();
        DataTable crTable = new DataTable();
        CDN oCDNKeys = clsDUConfigurations.Instance.CDNKeys;
        clsCDN objCDN = null;
        string sPathExists = string.Empty;
        #endregion

        #region Property for Refresh functionality
        private bool _refreshState;
        private bool _isRefresh;

        public bool IsRefresh
        {
            get
            {
                return _isRefresh;
            }
        }
        #endregion

        #region Overriding LoadViewState and SaveViewState Function to detect Refresh
        protected override void LoadViewState(object savedState)
        {
            object[] allStates = (object[])savedState;
            base.LoadViewState(allStates[0]);
            _refreshState = (bool)allStates[1];
            if (Session["__CONFIRMMERGEISREFRESH"] != null && Session["__CONFIRMMERGEISREFRESH"].ToString() != string.Empty)
            {
                _isRefresh = _refreshState == (bool)Session["__CONFIRMMERGEISREFRESH"];
            }
            else
            {
                Response.Redirect(clsGetSettings.SitePath + "Logout.aspx");
            }
        }

        protected override object SaveViewState()
        {
            Session["__CONFIRMMERGEISREFRESH"] = _refreshState;
            object[] allStates = new object[2];
            allStates[0] = base.SaveViewState();
            allStates[1] = !_refreshState;
            return allStates;
        }
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["__CONFIRMMERGEISREFRESH"] != null && !(bool)Session["__CONFIRMMERGEISREFRESH"])
            {
                _refreshState = true;
            }

            #region Set Hidden
            HtmlInputHidden[] hidden = new HtmlInputHidden[6];
            hidden[0] = hid_BaseStudentIDs;
            hidden[1] = hid_ProfileToBeMerged;
            hidden[2] = hid_MatchingCriteria;
            hidden[3] = hid_Matching_Profile_ID;
            hidden[4] = hid_FromPage;
            hidden[5] = hid_MatchingStudentIDs;

            common = new clsCommon();
            common.setHiddenVariablesMPC(ref hidden);
            #endregion

            lblPageHead.Text = "Confirm Merge Profile";
            lblMatCriteria.Text = "<font color='#EE6340'>Matching Criteria:</font> " + hid_MatchingCriteria.Value;
            //btnMerge.OnClientClick = ClientScript.GetPostBackEventReference(btnMerge, string.Empty) + ";this.Value='Submitting...';this.disabled=true;";

            if (!IsPostBack)
            {
                GetRecords();
            }
        }
        #endregion

        #region Get Records
        void GetRecords()
        {
            oclsEligibilityDBAccess = new clsEligibilityDBAccess();
            ds = oclsEligibilityDBAccess.GetMatchProfileForStudentIDs(hid_ProfileToBeMerged.Value + "," + hid_BaseStudentIDs.Value, hid_BaseStudentIDs.Value);
            if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            {
                //Rendering profile details
                RenderTable(ds.Tables[1]);
            }

            string[] arrBaseStudentIDs = hid_BaseStudentIDs.Value.Split('-');
            string[] arrMergeStudentIDs = hid_ProfileToBeMerged.Value.Split('-');

            ds = oclsEligibilityDBAccess.GetCourseDetailsForConfirmMerge(arrMergeStudentIDs[0], arrMergeStudentIDs[1], arrMergeStudentIDs[2], arrBaseStudentIDs[0], arrBaseStudentIDs[1], arrBaseStudentIDs[2]);
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                //lblPName.Text = Convert.ToString(ds.Tables[0].Rows[0]["StudentName"]);
                //lblBName.Text = Convert.ToString(ds.Tables[0].Rows[1]["StudentName"]);

                //lblPPRN.Text = Convert.ToString(ds.Tables[0].Rows[0]["PRN"]);
                //lblBPRN.Text = Convert.ToString(ds.Tables[0].Rows[1]["PRN"]);

                //string[] MergeArr = hid_ProfileToBeMerged.Value.Split('-');
                //string[] BaseArr = hid_BaseStudentIDs.Value.Split('-');

                //MPImg.ImageUrl = "PhotoSignHandler.ashx?img=Photo&UniID=" + MergeArr[0] + "&StudentID=" + MergeArr[2] + "&YearID=" + MergeArr[1];
                //MSImg.ImageUrl = "PhotoSignHandler.ashx?img=Sign&UniID=" + MergeArr[0] + "&StudentID=" + MergeArr[2] + "&YearID=" + MergeArr[1];

                //BPImg.ImageUrl = "PhotoSignHandler.ashx?img=Photo&UniID=" + BaseArr[0] + "&StudentID=" + BaseArr[2] + "&YearID=" + BaseArr[1];
                //BSImg.ImageUrl = "PhotoSignHandler.ashx?img=Sign&UniID=" + BaseArr[0] + "&StudentID=" + BaseArr[2] + "&YearID=" + BaseArr[1];
            }

            if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            {
                DataView dv1 = ds.Tables[1].DefaultView;
                dv1.RowFilter = "MergeStatus = 'N'";

                if (dv1.ToTable().Rows.Count > 0)
                {
                    GVTermRemove.DataSource = dv1.ToTable();
                    GVTermRemove.DataBind();
                    divGridRemoveTitle.Visible = true;
                    divGridRemoveTitle.InnerText = "List of Terms already available with Base profile";
                }
                else
                {
                    divGridRemoveTitle.Visible = false;
                }

                DataView dv2 = ds.Tables[1].DefaultView;
                dv2.RowFilter = "MergeStatus = 'Y'";

                if (dv2.ToTable().Rows.Count > 0)
                {
                    GVTermRetain.DataSource = dv2.ToTable();
                    GVTermRetain.DataBind();
                    divGridRetainTitle.Visible = true;
                    divGridRetainTitle.InnerText = "List of Terms to be retained with Base profile";
                }
                else
                {
                    divGridRetainTitle.Visible = false;
                }
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                DataView dvFilter = ds.Tables[2].DefaultView;
                dvFilter.RowFilter = "AddPaperStatus = 'Y'";
                if (dvFilter.ToTable().Rows.Count > 0)
                {
                    hid_MergeFlag.Value = "N";
                }
            }
        }
        #endregion

        #region Render Table
        /// <summary>
        /// Rendering profile details
        /// </summary>
        /// <param name="studDt"></param>
        private void RenderTable(DataTable studDt)
        {
            #region "Reset Table"
            for (int it = 0; it < TBLSummery.Rows.Count; it++)
            {
                int iCellCount = TBLSummery.Rows[it].Cells.Count;

                for (int i = iCellCount - 1; i >= 1; i--)
                {
                    TBLSummery.Rows[it].Cells.RemoveAt(i);
                }
            }
            #endregion

            #region Summary
            //
            //Add columns to table Summary
            //
            TableCell oTD = null;
            oTD = new TableCell();
            oTD.CssClass = "clOn";
            oTD.Text = "<div></div>";

            oTD.Attributes.Add("id", "divNote");
            TBLSummery.Rows[0].Cells.Add(oTD);

            oTD = new TableCell();
            oTD.CssClass = "clOn";
            oTD.Text = "<div></div>";
            oTD.Attributes.Add("id", "divNote");
            TBLSummery.Rows[0].Cells.Add(oTD);
            foreach (DataRow Row in studDt.Rows)
            {
                foreach (DataColumn Field in studDt.Columns)
                {
                    switch (Field.ColumnName)
                    {
                        case "PRN":
                            oTD = new TableCell();
                            oTD.CssClass = "clOn";
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TBLSummery.Rows[1].Cells.Add(oTD);
                            break;
                        //case "Eligibility Form No":
                        //    oTD = new TableCell();
                        //    oTD.CssClass = "clOn";
                        //    oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                        //    oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                        //    TBLSummery.Rows[1].Cells.Add(oTD);
                        //    break;
                        case "Student_Name":
                            oTD = new TableCell();
                            oTD.CssClass = "clOn";
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TBLSummery.Rows[2].Cells.Add(oTD);
                            break;
                        case "Photosign":
                            oTD = new TableCell();
                            oTD.CssClass = "clOn";
                            oTD.VerticalAlign = VerticalAlign.Middle;
                            System.Web.UI.WebControls.Image oPhoto = new System.Web.UI.WebControls.Image();
                            oPhoto.ID = "imgPhoto" + Row["Student_ID"].ToString();
                           // oPhoto.ImageUrl = "PhotoSignHandler.ashx?img=Photo&UniID=" + Convert.ToString(Row["pk_Uni_ID"]) + "&StudentID=" + Convert.ToString(Row["pk_Student_ID"]) + "&YearID=" + Convert.ToString(Row["pk_Year"]);
                            oPhoto.CssClass = "cssImage";
                            System.Web.UI.WebControls.Image oSign = new System.Web.UI.WebControls.Image();
                            oSign.ID = "imgSign" + Row["Student_ID"].ToString();
                            //oSign.ImageUrl = "PhotoSignHandler.ashx?img=Sign&UniID=" + Convert.ToString(Row["pk_Uni_ID"]) + "&StudentID=" + Convert.ToString(Row["pk_Student_ID"]) + "&YearID=" + Convert.ToString(Row["pk_Year"]);
                            if (oCDNKeys != null)
                            {
                                objCDN = new clsCDN(oCDNKeys.PhotoSignKey);
                                sPathExists = !string.IsNullOrEmpty(Convert.ToString(Row["PhotoPath"])) ? "Y" : "N";
                                oPhoto.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(Row["PhotoPath"]), sPathExists, "P");
                                sPathExists = !string.IsNullOrEmpty(Convert.ToString(Row["SignPath"])) ? "Y" : "N";
                                oSign.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(Row["SignPath"]), sPathExists, "S");
                            }    
                            oSign.CssClass = "cssImage";
                            oTD.Controls.Add(oPhoto);
                            oTD.Controls.Add(oSign);
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TBLSummery.Rows[3].Cells.Add(oTD);
                            break;
                        //case "College Name":
                        //    oTD = new TableCell();
                        //    oTD.CssClass = "clOn";
                        //    oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                        //    oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                        //    TBLSummery.Rows[4].Cells.Add(oTD);
                        //    break;
                    }
                }
            }

            #endregion
        }
        #endregion

        #region Merge Button Click event
        protected void btnMerge_Click(object sender, EventArgs e)
        {
            if (hid_MergeFlag.Value == "N")
            {
                lblMsg.Text = "These profiles could not be merged.<BR>Selected profile has opted the Additional Paper of the " + (string)GetLocalResourceObject("Course") + " Part/Term which is already available with the Base Profile. ";
                lblMsg.CssClass = "errorNote";
                btnMerge.Enabled = false;
                GetRecords();
                return;
            }
            else
            {
                string[] arrBaseStudentIDs = hid_BaseStudentIDs.Value.Split('-');
                string[] arrMergeStudentIDs = hid_ProfileToBeMerged.Value.Split('-');

                StringBuilder sb = new StringBuilder("<Student>");
                foreach (GridViewRow row in GVTermRetain.Rows)
                {
                    string[] courseIds = row.Cells[3].Text.Split('|');

                    if (((RadioButtonList)row.FindControl("rblMergeRemove")).SelectedValue == "M")
                    {
                        sb.Append("<Term Base_Uni_ID=\"" + arrBaseStudentIDs[0] + "\" Base_Year=\"" + arrBaseStudentIDs[1] + "\" Base_Student_ID=\"" + arrBaseStudentIDs[2] + "\" ToMerge_Uni_ID=\"" + arrMergeStudentIDs[0] + "\" ToMerge_Year=\"" + arrMergeStudentIDs[1] + "\" ToMerge_Student_ID=\"" + arrMergeStudentIDs[2] + "\" ");
                        sb.Append("pk_Fac_ID=\"" + courseIds[0] + "\" pk_Cr_ID=\"" + courseIds[1] + "\" pk_MoLrn_ID=\"" + courseIds[2] + "\" pk_Ptrn_ID=\"" + courseIds[3] + "\" pk_Brn_ID=\"" + courseIds[4] + "\" pk_CrPr_Details_ID=\"" + courseIds[5] + "\" pk_CrPrCh_ID=\"" + courseIds[6] + "\" />");
                    }
                }
                sb.Append("</Student>");


                oclsEligibilityDBAccess = new clsEligibilityDBAccess();
                user = (clsUser)Session["user"];

                /// <param name="base_Uni_ID"></param>
                /// <param name="base_Year"></param>
                /// <param name="base_Student_ID"></param>
                /// <param name="toMerge_Uni_ID"></param>
                /// <param name="toMerge_Year"></param>
                /// <param name="toMerge_Student_ID"></param>
                /// <param name="termsToBeMerge"></param>
                /// <param name="uSERID"></param>
                /// <param name="new_Identity"></param>
                string sReturn = oclsEligibilityDBAccess.ConfirmMerge(arrBaseStudentIDs[0], arrBaseStudentIDs[1], arrBaseStudentIDs[2], arrMergeStudentIDs[0], arrMergeStudentIDs[1], arrMergeStudentIDs[2], sb.ToString(), Convert.ToString(user.User_ID), hid_BaseStudentIDs.Value);
                oclsEligibilityDBAccess = null;

                if (hid_FromPage.Value == "MatchingProfile__1.aspx")
                {
                    hid_BaseStudentIDs.Value = string.Empty;
                    hid_ProfileToBeMerged.Value = string.Empty;
                    hid_FromPage.Value = "MatchingProfile__3.aspx";
                    Server.Transfer("MatchingProfile__1.aspx");
                }
                else
                {
                    hid_FromPage.Value = "MatchingProfile__3.aspx";
                    Server.Transfer("MatchingProfile__2.aspx");
                }
            }
        }
        #endregion
    }
}
