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
using System.Threading;
using System.Globalization;
using System.Net;
using DUConfigurations;

namespace StudentRegistration.Eligibility
{
    public partial class MatchingProfile__1 : System.Web.UI.Page
    {
        #region Varible Declaration
        DataSet ds = null;
        clsCommon common = null;
        Button btDel = null;
        clsEligibilityDBAccess oclsEligibilityDBAccess = null;
        clsUser user;
        CDN oCDNKeys = clsDUConfigurations.Instance.CDNKeys;
        clsCDN objCDN = null;
        string sPathExists = string.Empty;


        #endregion

        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

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
            if (Session["__AUTOMERGEISREFRESH"] != null && Session["__AUTOMERGEISREFRESH"].ToString() != string.Empty)
            {
                _isRefresh = _refreshState == (bool)Session["__AUTOMERGEISREFRESH"];
            }
            else
            {
                Response.Redirect(clsGetSettings.SitePath + "Logout.aspx");
            }
        }

        protected override object SaveViewState()
        {
            Session["__AUTOMERGEISREFRESH"] = _refreshState;
            object[] allStates = new object[2];
            allStates[0] = base.SaveViewState();
            allStates[1] = !_refreshState;
            return allStates;
        }
        #endregion

        #region Page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["__AUTOMERGEISREFRESH"] != null && !(bool)Session["__AUTOMERGEISREFRESH"])
            {
                _refreshState = true;
            }

            lblInfo.Visible = false;
            hid_MatchingCriteria.Value = "Student's name, Mother's name, Father's name, Date of Birth, Gender";
            lblPageHead.Text = "Matching Profile";
            lblListCat.Text = "Compare more details..";
            lblMatCriteria.Text = "<font color='#EE6340'>Matching Criteria:</font> " + hid_MatchingCriteria.Value;

            #region Set Hidden
            HtmlInputHidden[] hidden = new HtmlInputHidden[6];
            hidden[0] = hid_Matching_Profile_ID;
            hidden[1] = hid_BaseStudentIDs;
            hidden[2] = hid_MatchingStudentIDs;
            hidden[3] = hid_MatchingCriteria;
            hidden[4] = hid_FromPage;
            hidden[5] = hidLockedProfile;
            
            common = new clsCommon();
            common.setHiddenVariablesMPC(ref hidden);
            #endregion            
                    
            //Call to getRecords function
            GetRecords();
        }
        #endregion

        #region Get records
        /// <summary>
        /// Get records for the given match profile ID
        /// </summary>
        private void GetRecords()
        {
            //
            //Datatable 1 lists top 5 profiles
            //Datatable 2 gets all the details of profile
            //
            oclsEligibilityDBAccess = new clsEligibilityDBAccess();
            ds = oclsEligibilityDBAccess.GetMatchProfileForMPId(hid_Matching_Profile_ID.Value);            
            if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            {
                //Listing profiles and categories
                FillFilter(ds.Tables[0]);
                //Rendering profile details
                RenderTable(ds.Tables[1]);
                //Check for locked profile
                if (ds.Tables[2] != null && Convert.ToInt32(ds.Tables[2].Rows[0][0]) > 0)
                {
                    hidLockedProfile.Value = "1";
                    //Display request submitted message
                    if (hid_FromPage.Value == "MatchingProfile__3.aspx" || hid_FromPage.Value == "MatchingProfile__1.aspx")
                    {
                        lblInfo.Text = "Your request has been submitted and is currently in process.<br/>You cannot perform any actions on this profile i.e. Delete Profile or Merge Profile.<br/>However you can compare the profiles if available.";
                        lblInfo.Visible = true;
                        //lblMsg.Text = "";
                        //lblMsg.CssClass = "saveNote";
                    }
                    else
                    {
                        lblInfo.Text = "Request related to this profile is already submitted and is in process.<br/>You cannot perform any actions on this profile i.e. Delete Profile or Merge Profile.<br/>However you can compare the profiles if available.";
                        lblInfo.Visible = true;
                    }
                }
            }
            else
            {
                lblMsg.Text = "No records found.";
                lblMsg.CssClass = "errorNote";
            }
            ds = null;
        }
        #endregion

        #region Fill filter
        /// <summary>
        /// Listing profiles and categories
        /// </summary>
        /// <param name="fildt"></param>
        private void FillFilter(DataTable fildt)
        {
            if (fildt != null && fildt.Rows.Count > 0)
            {
                lblListProfile.Text = "Showing " + fildt.Rows.Count.ToString() + " of " + Convert.ToString(fildt.Rows[0]["Profile_Matched_Count"]) + " profiles";
                //Binding Checkbox list
                CBListFilter1.DataSource = fildt;
                CBListFilter1.DataTextField = "Text";
                CBListFilter1.DataValueField = "Value";
                CBListFilter1.DataBind();
                
                //Adding javascript function call
                foreach (ListItem oListItem in CBListFilter1.Items)
                {
                    
                    oListItem.Attributes.Add("ID",oListItem.Value);
                    oListItem.Attributes.Add("onclick", "return DisplayContents();");          
                }

                int selProfileCount = 0;
                if (fildt.Rows.Count > 2)
                { selProfileCount = 2; }
                else
                { selProfileCount = fildt.Rows.Count; }
                //Min-Max checkbox selected
                for (int i = 0; i < selProfileCount; i++)
                {
                    CBListFilter1.Items[i].Selected = true;
                }
                                
                //Binding Category checkboxlist
                CBListFilter2.Items.Clear();
                CBListFilter2.Items.Add(new ListItem("Personal Information", "divPerInfo"));
                CBListFilter2.Items.Add(new ListItem("Qualification Details", "divQual"));
                CBListFilter2.Items.Add(new ListItem("Social Reservation", "divSocRes"));
                CBListFilter2.Items.Add(new ListItem((string)GetLocalResourceObject("lblCourseResource1.Text") + " Profile", "divCourse"));
                CBListFilter2.Items.Add(new ListItem("College Profile", "divCollege"));

                //Adding javascript function call
                foreach (ListItem oListItem in CBListFilter2.Items)
                {
                    oListItem.Selected = true;
                    oListItem.Attributes.Add("rel", oListItem.Value);
                    oListItem.Attributes.Add("onclick", "return DisplayContents();"); 
                }
            }
            else
            {
                lblMsg.Text = "No records found.";
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
            #region "Reset Tables"
            ResetTable(TBLSummery);
            ResetTable(TblPersonalInfo);
            ResetTable(TblQual);
            ResetTable(TblSocRes);
            ResetTable(TblCourse);
            ResetTable(TblCollege);
            ResetTable(TblAction);
            #endregion

            #region Summary
            //
            //Add columns to table Summary
            //
            TableCell oTD = null;
            foreach (DataRow Row in studDt.Rows)
            {
                foreach (DataColumn Field in studDt.Columns)
                {
                    switch (Field.ColumnName)
                    {
                        case "PRN":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            //oTD.Style.Add("border-top-color", "Black");
                           // oTD.Style.Add("border-top-style", "solid");
                            //oTD.Style.Add("border-right-style", "solid");
                            //oTD.Style.Add("border-bottom-style", "solid");
                            oTD.Text = "<div>"+Convert.ToString(Row[Field.ColumnName])+"</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TBLSummery.Rows[0].Cells.Add(oTD);
                            break;
                        //case "Eligibility Form No":
                        //    oTD = new TableCell();
                        //    oTD.CssClass = "clOff";
                        //    oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                        //    oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                        //    TBLSummery.Rows[1].Cells.Add(oTD);
                        //    break;
                        case "Student_Name":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TBLSummery.Rows[1].Cells.Add(oTD);
                            break;
                        case "Photosign":
                           
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                        
                            //oTD.Style.Add("border-bottom-color", "Black");
                            oTD.VerticalAlign = VerticalAlign.Middle;
                            System.Web.UI.WebControls.Image oPhoto = new System.Web.UI.WebControls.Image();
                            oPhoto.ID = "imgPhoto" + Row["Student_ID"].ToString();
                               //oPhoto.ImageUrl = dtRow["Download_Path"].ToString() + Row["PhotoPath"].ToString();//"PhotoSignHandler.ashx?img=Photo&UniID=" + Convert.ToString(Row["pk_Uni_ID"]) + "&StudentID=" + Convert.ToString(Row["pk_Student_ID"]) + "&YearID=" + Convert.ToString(Row["pk_Year"]);
                            oPhoto.CssClass = "cssImage";
                            System.Web.UI.WebControls.Image oSign = new System.Web.UI.WebControls.Image();
                            oSign.ID = "imgSign" + Row["Student_ID"].ToString();
                            //oSign.ImageUrl = dtRow["Download_Path"].ToString() + Row["SignPath"].ToString();//"PhotoSignHandler.ashx?img=Sign&UniID=" + Convert.ToString(Row["pk_Uni_ID"]) + "&StudentID=" + Convert.ToString(Row["pk_Student_ID"]) + "&YearID=" + Convert.ToString(Row["pk_Year"]);
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
                            TBLSummery.Rows[2].Cells.Add(oTD);
                            break;
                        //case "College Name":
                        //    oTD = new TableCell();
                        //    oTD.CssClass = "clOff";
                        //    oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                        //    oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                        //    TBLSummery.Rows[4].Cells.Add(oTD);
                        //    break;
                    }
                }
            }
            
            #endregion

            #region Personal Information
            //
            //Add columns to table Personal Information
            //
            oTD = null;
            foreach (DataRow Row in studDt.Rows)
            {
                foreach (DataColumn Field in studDt.Columns)
                {
                    switch (Field.ColumnName)
                    {
                        case "Student_Name":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";                            
                            //oTD.Style.Add("border-right-color", "Black");
                            //oTD.Style.Add("border-top-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[0].Cells.Add(oTD);
                            break;
                        case "Mother_Name":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[1].Cells.Add(oTD);
                            break;
                        case "Father_Name":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[2].Cells.Add(oTD);
                            break;
                        case "Printed_statement":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[3].Cells.Add(oTD);
                            break;
                        case "Name_in_Vernacular_language":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[4].Cells.Add(oTD);
                            break;
                        case "Marital_Status":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[5].Cells.Add(oTD);
                            break;
                        case "Gender":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[6].Cells.Add(oTD);
                            break;
                        case "Date_of_Birth":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[7].Cells.Add(oTD);
                            break;
                        case "Place_of_Birth":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[8].Cells.Add(oTD);
                            break;
                        case "Blood_Group":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[9].Cells.Add(oTD);
                            break;
                        case "Religion":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[10].Cells.Add(oTD);
                            break;
                        case "Previous_Name":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[11].Cells.Add(oTD);
                            break;
                        case "Reason_for_Changing_Name":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[12].Cells.Add(oTD);
                            break;
                        case "Country_of_Citizenship":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[13].Cells.Add(oTD);
                            break;
                        case "Location_Category":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[14].Cells.Add(oTD);
                            break;
                        case "Correspondence_Address":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[15].Cells.Add(oTD);
                            break;
                        case "Correspondence_Tahsil":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[16].Cells.Add(oTD);
                            break;
                        case "Correspondence_District":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[17].Cells.Add(oTD);
                            break;
                        case "Correspondence_State":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[18].Cells.Add(oTD);
                            break;
                        case "Correspondence_Country":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[19].Cells.Add(oTD);
                            break;
                        case "Permanent_Address":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[20].Cells.Add(oTD);
                            break;
                        case "Permanent_Tahsil":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[21].Cells.Add(oTD);
                            break;
                        case "Permanent_District":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[22].Cells.Add(oTD);
                            break;
                        case "Permanent_State":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[23].Cells.Add(oTD);
                            break;
                        case "Permanent_Country":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[24].Cells.Add(oTD);
                            break;
                        case "Area_STD_Phone1":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[25].Cells.Add(oTD);
                            break;
                        case "Area_STD_Phone2":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[26].Cells.Add(oTD);
                            break;
                        case "Mobile_Number":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[27].Cells.Add(oTD);
                            break;
                        case "Email_ID":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            //oTD.Style.Add("border-bottom-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblPersonalInfo.Rows[28].Cells.Add(oTD);
                            break;
                    }
                }
            }

            //divPerInfo.Controls.Add(TblPersonalInfo);
            #endregion

            #region Qualifications
            //
            //Add columns to table Qualifications
            //
            oTD = null;
            foreach (DataRow Row in studDt.Rows)
            {
                foreach (DataColumn Field in studDt.Columns)
                {
                    switch (Field.ColumnName)
                    {
                        case "10th_Board_Type":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            //oTD.Style.Add("border-top-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblQual.Rows[0].Cells.Add(oTD);
                            break;
                        case "10th_Board_State":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblQual.Rows[1].Cells.Add(oTD);
                            break;
                        case "10th_Board":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblQual.Rows[2].Cells.Add(oTD);
                            break;
                        case "10th_Passing_Certificate":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblQual.Rows[3].Cells.Add(oTD);
                            break;
                        case "10th_Examination_Seat_Number":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblQual.Rows[4].Cells.Add(oTD);
                            break;
                        case "12th_Board_Type":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblQual.Rows[5].Cells.Add(oTD);
                            break;
                        case "12th_Board_State":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblQual.Rows[6].Cells.Add(oTD);
                            break;
                        case "12th_Board":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblQual.Rows[7].Cells.Add(oTD);
                            break;
                        case "12th_Passing_Certificate":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblQual.Rows[8].Cells.Add(oTD);
                            break;
                        case "12th_Examination_Seat_Number":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            //oTD.Style.Add("border-bottom-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblQual.Rows[9].Cells.Add(oTD);
                            break;
                    }
                }
            }

            //divQual.Controls.Add(TblQual);
            #endregion

            #region Social Reservation
            //
            //Add columns to table Social Reservation
            //
            oTD = null;
            foreach (DataRow Row in studDt.Rows)
            {
                foreach (DataColumn Field in studDt.Columns)
                {
                    switch (Field.ColumnName)
                    {
                        case "Social_Reservations":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            //oTD.Style.Add("border-top-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblSocRes.Rows[0].Cells.Add(oTD);
                            break;
                        case "Domicile_of_State":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblSocRes.Rows[1].Cells.Add(oTD);
                            break;
                        case "Category":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblSocRes.Rows[2].Cells.Add(oTD);
                            break;
                        case "Reserved_Category":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblSocRes.Rows[3].Cells.Add(oTD);
                            break;
                        case "Caste":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblSocRes.Rows[4].Cells.Add(oTD);
                            break;
                        case "Admitted_Under_Category":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblSocRes.Rows[5].Cells.Add(oTD);
                            break;
                        case "Physically_Challenged":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblSocRes.Rows[6].Cells.Add(oTD);
                            break;
                        case "Annual_Income_of_Guardian":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblSocRes.Rows[7].Cells.Add(oTD);
                            break;
                        case "Occupation_of_Guardian":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            //oTD.Style.Add("border-right-color", "Black");
                            //oTD.Style.Add("border-bottom-color", "Black");
                            oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblSocRes.Rows[8].Cells.Add(oTD);
                            break;
                    }
                }
            }

            //divSocRes.Controls.Add(TblSocRes);
            #endregion

            #region Course Profile
            //
            //Add columns to table Course
            //
            oTD = null;
            foreach (DataRow Row in studDt.Rows)
            {
                foreach (DataColumn Field in studDt.Columns)
                {
                    switch (Field.ColumnName)
                    {
                        case "Course":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            oTD.Attributes.Add("style", "padding:0px;");
                            string[] ArrStudID = Row["Student_ID"].ToString().Split('-'); 
                            CourseProfile objCourseProfile = (CourseProfile)LoadControl("CourseProfile.ascx");
                            objCourseProfile.UniID = ArrStudID[0];
                            objCourseProfile.Year = ArrStudID[1];
                            objCourseProfile.StudentID = ArrStudID[2];

                            oTD.Controls.Add(objCourseProfile);
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblCourse.Rows[0].Cells.Add(oTD);
                            break;                        
                    }
                }
            }
            
            #endregion

            #region College Profile
            //
            //Add columns to table College
            //
            oTD = null;
            foreach (DataRow Row in studDt.Rows)
            {
                foreach (DataColumn Field in studDt.Columns)
                {
                    switch (Field.ColumnName)
                    {
                        case "College":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";
                            oTD.Attributes.Add("style", "padding:0px;");
                            string[] ArrStudID = Row["Student_ID"].ToString().Split('-');
                            CollegeProfile objCollegeProfile = (CollegeProfile)LoadControl("CollegeProfile.ascx");
                            objCollegeProfile.UniID = ArrStudID[0];
                            objCollegeProfile.Year = ArrStudID[1];
                            objCollegeProfile.StudentID = ArrStudID[2];

                            oTD.Controls.Add(objCollegeProfile);
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            TblCollege.Rows[0].Cells.Add(oTD);
                            break;
                    }
                }
            }

            #endregion

            #region Action
            //
            //Add columns to table Action
            //
            oTD = null;
            foreach (DataRow Row in studDt.Rows)
            {
                foreach (DataColumn Field in studDt.Columns)
                {
                    switch (Field.ColumnName)
                    {
                        case "Delete_Duplicate":
                            oTD = new TableCell();
                            oTD.CssClass = "clOff";

                            btDel = new Button();
                            btDel.CssClass = "profileBut";
                            btDel.Text = "Delete Profile";
                            btDel.ID = "Del-" + Row["Student_ID"].ToString();
                            btDel.Click += new EventHandler(btDel_Click);
                            btDel.Attributes.Add("onclick", "javascript:return ValidateDelete(this);");
                            oTD.Controls.Add(btDel);
                            oTD.Attributes.Add("id", Row["Student_ID"].ToString());
                            oTD.HorizontalAlign = HorizontalAlign.Center;
                            oTD.VerticalAlign = VerticalAlign.Middle;
                            TblAction.Rows[0].Cells.Add(oTD);
                            break;
                    }
                }
            }
            #endregion
        }
        #endregion

        #region Reset table
        /// <summary>
        /// Clear the tables
        /// </summary>
        /// <param name="oDT"></param>
        private void ResetTable(Table oDT)
        {
            for (int it = 0; it < oDT.Rows.Count; it++)
            {
                int iCellCount = oDT.Rows[it].Cells.Count;

                for (int i = iCellCount - 1; i >= 1; i--)
                {
                    oDT.Rows[it].Cells.RemoveAt(i);
                }
            }
        }
        #endregion

        #region Delete profile button click
        /// <summary>
        /// Delete button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btDel_Click(object sender, EventArgs e)
        {
            if (hid_Del_New_Identity.Value != string.Empty)
            {
                oclsEligibilityDBAccess = new clsEligibilityDBAccess();
                user = (clsUser)Session["user"];
                //Get the student IDs by splitting button ID
                string[] delIDs = ((Button)sender).ID.Split('-');
                string[] baseIDs = hid_Del_New_Identity.Value.Split('-');
                int iRet = oclsEligibilityDBAccess.DeleteDuplicateProfile(delIDs[1], delIDs[2], delIDs[3], Convert.ToString(user.User_ID), baseIDs[0], baseIDs[1], baseIDs[2]);
                if (iRet > 0)
                {
                    //lblMsg.Text = "Profile deleted successfully.";
                    //lblMsg.CssClass = "saveNote";
                    hid_FromPage.Value = "MatchingProfile__1.aspx";
                    GetRecords();
                }
                else
                {
                    lblMsg.Text = "Error occured while deleting Profile.";
                    lblMsg.CssClass = "errorNote";
                }
                oclsEligibilityDBAccess = null;
            }
            else
            {
                lblMsg.Text = "Profile cannot be deleted. Please contact administrator.";
                lblMsg.CssClass = "errorNote";
            }
        }
        #endregion

        #region Merge Profile Button click
        protected void btnMerge_Click(object sender, EventArgs e)
        {
            if (rb1.Checked || rb2.Checked)
            {
                //Commented by Mnagesh on 22-09-17 for issue no: #137675 to avoid validation for KU PRN '11-IETS-159'
                //if ((hidBasePRN.Value != string.Empty) && (hidBasePRN.Value.Contains("-") == false) && (hidBasePRN.Value.Contains(" ") == false))

                if ((hidBasePRN.Value != string.Empty) && (hidBasePRN.Value.Contains(" ") == false))
                {
                    hid_FromPage.Value = "MatchingProfile__1.aspx";
                    Server.Transfer("MatchingProfile__3.aspx");
                }
                else
                {
                    lblMsg.Text = "Profile cannot be merged. Base profile should have " + (string)GetLocalResourceObject("lblPRNResource1.Text") + ". Please check.<br/>If problem still persists, please contact administrator.";
                    lblMsg.CssClass = "errorNote";
                }
            }
            else
            {
                lblMsg.Text = "Profile cannot be merged. Please select profile to merge.<br/>If problem still persists, please contact administrator.";
                lblMsg.CssClass = "errorNote";
            }
        }
        #endregion
    }
}
