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
using StudentRegistration.Eligibility.ElgClasses;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace StudentRegistration.Eligibility
{
    public partial class ConfigureEligibilityRights : System.Web.UI.Page
    {
        clsCommon Common = new clsCommon();
        CourseRepository crRepository = new CourseRepository();
        DataTable objDT = new DataTable();
        string Uni_ID = Classes.clsGetSettings.UniversityID.ToString();
        clsEligibilityRights objclsEligibility = new clsEligibilityRights();
        clsUser user = new clsUser();
        string userid = "";
        clsCache  clsCache = new clsCache();
        

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            
            clsCache.NoCache();
            // chkCourse.Attributes.Add("onclick","fnChkCourse();");
            btnProcess.Attributes.Add("onclick", "return fnSaveValidate();");
            user = (clsUser)Session["User"];
            userid = user.User_ID.ToString();
            chkCourse.Items[1].Attributes.Add("onclick", "fnDisplayCourse();");
            chkCourse.Items[0].Attributes.Add("onclick", "fnHideCourse();");
            if (!IsPostBack)
            {
                if (PreviousPage != null)
                {
                    ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

                    if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                    {
                        hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                    }
                }
                //--------------------------------------------------------
                //University ID Checking
                //--------------------------------------------------------

                if (hidUniID.Value == "")
                {
                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                }

                fnFirstFill();
                FillGrid();                
                lblCrNote.Text = "Already configured eligibility rights";
            }

            ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            //sInst = (searchInstNew)Cntph.FindControl("SchInst1");

        }

        #endregion     

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        #region USER DEFINED Functions      

        #region fnFirstFill

        private void fnFirstFill()
        {
            hidLevelFlag.Value = "5";
            FetchUniversityWiseFacultyList(ddlFacDesc);

        }

        #endregion

        #region Fetch University Wise Faculty List

        public void FetchUniversityWiseFacultyList(DropDownList ddlFacDesc)
        {

            DataTable listFaculty = crRepository.LaunchedUniversityWiseFacultyList(Convert.ToInt64(hidUniID.Value.ToString()));
            try
            {
                if (listFaculty != null)
                {
                    ddlFacDesc.DataSource = listFaculty;
                    ddlFacDesc.DataTextField = "text";
                    ddlFacDesc.DataValueField = "value";
                    ddlFacDesc.DataBind();
                    ListItem li = new ListItem("--- Select ---", "-1");
                    ddlFacDesc.Items.Insert(0, li);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region FillGrid
        protected void FillGrid()
        {

            lblCrNote.Text = "";
            DataTable dt = objclsEligibility.Elg_Diplay_Course_Rights(hidUniID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value);
            DataView dv = new DataView();
            dv.Table = dt;
            try
            {
                if (dt.Rows.Count > 0 && dt != null)
                {
                    if (ViewState["SortExpression"] != null)
                    {
                        dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();

                    }
                    if (chkCourse.SelectedValue == "0")
                    {
                        tblSelectCr.Attributes.Add("style", "display:none");
                        tblSelectCr2.Attributes.Add("style", "display:none");

                        //lblCrNote.Text += "College: " + oDT.Rows[0]["CollCount"].ToString() + "<br>" + "University: " + oDT.Rows[0]["UniCount"].ToString();
                        if (dt.Rows[0]["CollCount"].ToString() != "0")
                        {
                            lblCrNote.Text = "Eligibility rights assigned to " + dt.Rows[0]["CollCount"].ToString() + " "+ lblCr.Text +"s at "+ lblCollege.Text +"";
                        }
                        else
                        {
                            lblCrNote.Text = "Eligibility rights assigned to " + dt.Rows[0]["UniCount"].ToString() + " " + lblCr.Text + "(s) at " + lblUniversity.Text + "";
                        }
                    }
                    if (lblCrNote.Text == "")
                    {

                        lblCrNote.Text = "Already configured eligibility rights";
                    }
                    DGCourseRights1.DataSource = dv;
                    DGCourseRights1.DataBind();
                    //divDGCourseRights.Style.Add("display", "block");
                    DGCourseRights1.Visible = true;
                    lblGridNote.Visible = false;
                }
                else
                {
                    //DGCourseRights.Visible = false;
                    //divDGCourseRights.Style.Add("display", "none");
                    lblGridNote.Visible = true;
                    lblGridNote.CssClass = "errorNote";
                    lblGridNote.Text = "No Record Found.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #endregion

        #region btnProcess_Click

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            string sReturn = "";

            hidCorseFlag.Value = chkCourse.SelectedValue.Trim();
            hidCollUniFlag.Value = rdConfigureRights.SelectedValue.Trim();
            if (hidBrnID.Value == "")
            {
                hidBrnID.Value = "0";
            }
            lblNote.Text = "";
            if (hidEditAdd.Value == "0" || hidEditAdd.Value == "")
            {
                sReturn = objclsEligibility.Add_EligibilityRights(hidUniID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCollUniFlag.Value, userid.ToString(), hidCorseFlag.Value);

                FillGrid();
            }
            else
            {
                sReturn = objclsEligibility.Modify_EligibilityRights(hidUniID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCollUniFlag.Value, userid.ToString(), hidCorseFlag.Value);
                // hidEditAdd.Value = "0";
                tblSelectCr.Attributes.Add("style", "Display:none");
                tblSelectCr2.Attributes.Add("style", "Display:none");
                hidEditAdd.Value = "0";
                //fnFacWiseCr(hidUniID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value);
                chkCourse.SelectedItem.Selected = false;
                rdConfigureRights.SelectedItem.Selected = false;
                //DisplayGrid("");
                FillGrid();


            }
            if (sReturn == "Y")
            {
                lblNote.Text = "Information Saved Successfully";
                lblNote.CssClass = "saveNote";
                ResetCtrl();
            }
            else if (sReturn == "E")
            {
                lblNote.Text = "Record already exists.";
                lblNote.CssClass = "errorNote";
                ResetCtrl();
            }
            else
            {
                lblNote.Text = "Information can not be processed";
                lblNote.CssClass = "errorNote";
            }
        }

        #endregion

        #region ResetCtrl

        protected void ResetCtrl()
        {
            if (chkCourse.Items[1].Selected)
                chkCourse.Items[1].Selected = false;
            if (rdConfigureRights.Items[0].Selected)
                rdConfigureRights.Items[0].Selected = false;
            if (rdConfigureRights.Items[1].Selected)
                rdConfigureRights.Items[1].Selected = false;
        }

        #endregion

        # region Commented by Jatin
        #region Grid Events
        
        
        #region DGCourseRights_ItemDataBound

        /*       protected void DGCourseRights_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (DGCourseRights.CurrentPageIndex * DGCourseRights.PageSize) + 1) + ".";

                if (e.Item.Cells[14].Text != "-")
                    e.Item.Cells[4].Text = e.Item.Cells[4].Text + "-" + e.Item.Cells[6].Text + "-" + e.Item.Cells[9].Text + "-" + e.Item.Cells[14].Text;
                else
                    e.Item.Cells[4].Text = e.Item.Cells[4].Text + "-" + e.Item.Cells[6].Text + "-" + e.Item.Cells[9].Text;

            }

        }
        */
        #endregion

        #region DGCourseRights_PageIndexChanged

 /*       protected void DGCourseRights_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DGCourseRights.CurrentPageIndex = e.NewPageIndex;
            FillGrid();
            lblNote.Text = "";
            tblSelectCr.Attributes.Add("style", "Display:none");
            tblSelectCr2.Attributes.Add("style", "Display:none");
            hidEditAdd.Value = "0";
            if (chkCourse.Items[1].Selected)
            {
                chkCourse.Items[1].Selected = false;
            }
            
            
            //ClearCrSelection();
        }*/

        #endregion

        #region DGCourseRights_ItemCommand

 /*       protected void DGCourseRights_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {

                hidFacID.Value = e.Item.Cells[1].Text;
                hidCrID.Value = e.Item.Cells[3].Text;
                hidMoLrnID.Value = e.Item.Cells[5].Text;
                //hidCrMoLrnID.Value = e.Item.Cells[11].Text;
                //hidCrMoLrnPtrnID.Value = e.Item.Cells[12].Text;
                hidPtrnID.Value = e.Item.Cells[7].Text;
                hidEditAdd.Value = "1";
                chkCourse.Items[1].Selected = true;
                tblSelectCr.Attributes.Add("style", "Display:inline");
                //fnFacWiseCr(hidUniID.Value,hidFacID.Value,hidCrID.Value,hidCrMoLrnID.Value);


                tblSelectCr.Style.Add("display", "none");
                tblSelectCr2.Style.Add("display", "block");
                lblFacName.Text = e.Item.Cells[2].Text;
                lblCrName.Text = e.Item.Cells[16].Text;
                lblMoLrnName.Text = e.Item.Cells[6].Text;
                lblPtrnName.Text = e.Item.Cells[9].Text;

                if (e.Item.Cells[8].Text != "0")
                {
                    trCrBranch.Style.Add("display", "block");
                    hidBrnID.Value = e.Item.Cells[8].Text;
                    lblBranchName.Text = e.Item.Cells[14].Text;
                }
                else
                {
                    hidBrnID.Value = "0";
                    //trCrBranch.Style.Add("display", "none");
                    lblBranchName.Text = "";
                }
                rdConfigureRights.SelectedValue = e.Item.Cells[10].Text.Trim();
            }
        }*/

        #endregion

        #region DGCourseRights_SortCommand

 /*       protected void DGCourseRights_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            //DisplayGrid(e.SortExpression);
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                if (ViewState["SortOrder"].ToString() == " asc")
                    ViewState["SortOrder"] = " desc";
                else
                    ViewState["SortOrder"] = " asc";
            }
            else
            {
                ViewState["SortExpression"] = e.SortExpression;
                ViewState["SortOrder"] = " asc";
            }
            FillGrid();
        }*/

        #endregion
        #endregion
        # endregion Commented by Jatin

        #region old code not in use

        #region fnFacWiseCr

        /* private void fnFacWiseCr(string sUniID,string sFacID,string sCrID,string sCrMoLrnID)
        {
            objDT = CourseRepository.facultyList(Uni_ID);

            if (objDT.Rows.Count > 0 && objDT != null)
            {
                Common.fillDropDown(dd_Fac_Desc, objDT, "", "fac_desc", "pk_fac_ID", "------ Select ------");
            }
            else
            {
                dd_Fac_Desc.Items.Clear();
                ListItem Li = new ListItem();
                Li.Text = "------ Select ------";
                Li.Value = "0";
                dd_Fac_Desc.Items.Insert(0, Li);
            }

            if (sFacID == null || sFacID=="")
                sFacID = "0";
            objDT = CourseRepository.FacultyWiseCourse(Convert.ToInt64(sUniID), Convert.ToInt64(sFacID));
            if (objDT.Rows.Count > 0 && objDT != null)
            {
                ddlCourse.Items.Clear();
                Common.fillDropDown(ddlCourse, objDT, "", "Cr_desc", "pk_Cr_ID", "------ Select ------");
            }
            else
            {
                ddlCourse.Items.Clear();
                ListItem Li = new ListItem();
                Li.Text = "------ Select ------";
                Li.Value = "0";
                ddlCourse.Items.Insert(0, Li);
            }

            objDT = CourseRepository.coursewiseModeOfLearnings(sUniID,sFacID,sCrID);
            if(objDT.Rows.Count >0 && objDT != null)
            {
                dd_ModeLrn_Desc.Items.Clear();
                Common.fillDropDown(dd_ModeLrn_Desc, objDT, "", "Text", "pk_CrMoLrn_ID", "------ Select ------");
            }
            else
            {
                dd_ModeLrn_Desc.Items.Clear();
                ListItem Li = new ListItem();
                Li.Text = "------ Select ------";
                Li.Value = "0";
                dd_ModeLrn_Desc.Items.Insert(0,Li);
            }
            objDT = CourseRepository.coursewisePatternList(sUniID, sCrMoLrnID);
            if(objDT.Rows.Count > 0 && objDT != null)
            {
                dd_CrPtrn_Desc.Items.Clear();
                Common.fillDropDown(dd_CrPtrn_Desc, objDT, "", "Text", "pk_CrMoLrnPtrn_ID", "------ Select ------");
            }
            else
            {
                dd_CrPtrn_Desc.Items.Clear();
                ListItem Li = new ListItem();
                Li.Text = "------ Select ------";
                Li.Value = "0";
                dd_CrPtrn_Desc.Items.Insert(0,Li);
            }

        }*/

        #endregion

        #region ClearCrSelection

        /*
        private void ClearCrSelection()
        {
            ddlFacDesc.ClearSelection();
            ddlCrDesc.ClearSelection();
            ddlCrPtrnDesc.ClearSelection();
            ddlModeLrnDesc.ClearSelection();
            rdConfigureRights.ClearSelection();
            chkCourse.ClearSelection();

        }*/

        #endregion

        #region DisplayGrid

        private void DisplayGrid(string sortExpression)
        {
            /*DataTable oDT = new DataTable();
            Hashtable oHs = new Hashtable();
            oHs.Add("Uni_ID", hidUniID.Value);
            oHs.Add("Fac_ID", hidFacID.Value);
            oHs.Add("Cr_ID", hidCrID.Value);
            oHs.Add("MoLrn_ID", hidMoLrnID.Value);
            oHs.Add("CrPtrn_ID", hidCrPtrnID.Value);
            oHs.Add("CrMoLrn_ID", hidCrMoLrnID.Value);
            oHs.Add("CrMoLrnPtrn_ID", hidCrMoLrnPtrnID.Value);
            lblCrNote.Text = "";                     
            oDT = objclsEligibility.Elg_Diplay_Course_Rights(oHs);
            if (oDT.Rows.Count > 0 && oDT != null)
            {

                if (sortExpression != null && sortExpression != "")
                {
                    if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == (sortExpression + ", Cr_Desc"))
                    {
                        ViewState["SortExpression"] = sortExpression + " Desc, Cr_Desc";
                    }
                    else
                    {
                        ViewState["SortExpression"] = sortExpression.Trim() + ", Cr_Desc";
                    }

                    DataView DV = oDT.DefaultView;
                    DV.Sort = ViewState["SortExpression"].ToString().Trim();
                    DGCourseRights.DataSource = DV;
                    DGCourseRights.DataBind();
                }
                else
                {
                    try
                    {
                    //if(DGCourseRights.CurrentPageIndex >= DGCourseRights.PageCount)
                    //{
                    //    DGCourseRights.CurrentPageIndex = 0;
                    //}
                        
                    DGCourseRights.DataSource = oDT;
                    DGCourseRights.DataBind();
                    DGCourseRights.Visible = true;


                }
                catch
                {
                    DGCourseRights.CurrentPageIndex = 0;
                    DGCourseRights.DataBind();
                }

                }
                if (chkCourse.SelectedValue == "0")
                {
                    tblSelectCr.Attributes.Add("style", "Display:none");
                   
                    //lblCrNote.Text += "College: " + oDT.Rows[0]["CollCount"].ToString() + "<br>" + "University: " + oDT.Rows[0]["UniCount"].ToString();
                    if (oDT.Rows[0]["CollCount"].ToString() != "0")
                    {
                        lblCrNote.Text = "Eligibility rights assigned to " + oDT.Rows[0]["CollCount"].ToString() + " courses at College";
                    }
                    else
                    {
                        lblCrNote.Text = "Eligibility rights assigned to " + oDT.Rows[0]["UniCount"].ToString() + " Courses at University";
                    }
                }
                else
                {
                  //  
                    if (dd_Fac_Desc.SelectedValue != "0")
                    {
                        objDT = CourseRepository.coursewiseModeOfLearnings(hidUniID.Value,hidFacID.Value,hidCrID.Value);
                        if (objDT.Rows.Count > 0 && objDT != null)
                        {
                            lblCrNote.Text = "Selected Course : " + objDT.Rows[0]["Cr_Desc"].ToString();
                        }
                       
                    }   
                    lblCrNote.Text = "Already configured eligibility rights";

                }
            }
            else
            {
                DGCourseRights.Visible = false;
            }*/
        }

        #endregion        

        #endregion

        #region Grid View Events        
        
        #region DGCourseRights1_PageIndexChanging
        protected void DGCourseRights1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillGrid();
            DGCourseRights1.PageIndex = e.NewPageIndex;
            DGCourseRights1.DataBind();
            lblNote.Text = "";
            tblSelectCr.Attributes.Add("style", "Display:none");
            tblSelectCr2.Attributes.Add("style", "Display:none");
            hidEditAdd.Value = "0";
            if (chkCourse.Items[1].Selected)
            {
                chkCourse.Items[1].Selected = false;
            }

        }
        #endregion

        #region DGCourseRights1_RowDataBound
        protected void DGCourseRights1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType != DataControlRowType.Header) && (e.Row.RowType != DataControlRowType.Footer) && (e.Row.RowType != DataControlRowType.Pager))
            {
                if (e.Row.Cells[14].Text != "-")
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "-" + e.Row.Cells[6].Text + "-" + e.Row.Cells[9].Text + "-" + e.Row.Cells[14].Text;
                else
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "-" + e.Row.Cells[6].Text + "-" + e.Row.Cells[9].Text;

               
                if (e.Row.Cells[10].Text == "0")
                {
                    ((Label)e.Row.Cells[11].FindControl("lblRightsTo")).Text = lblUniversity.Text;
                }
                else if (e.Row.Cells[10].Text == "1")
                {
                    ((Label)e.Row.Cells[11].FindControl("lblRightsTo")).Text = lblCollege.Text;
                }
            }
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[3].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[16].Style.Add("display", "none");
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[3].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
                e.Row.Cells[6].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
                e.Row.Cells[14].Style.Add("display", "none");
                e.Row.Cells[16].Style.Add("display", "none");
            }
        }
        #endregion

        #region DGCourseRights1_RowCommand
        /*protected void DGCourseRights1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = DGCourseRights1.Rows[index];

                hidFacID.Value = row.Cells[1].Text;
                hidCrID.Value = row.Cells[3].Text;
                hidMoLrnID.Value = row.Cells[5].Text;
                //hidCrMoLrnID.Value = e.Item.Cells[11].Text;
                //hidCrMoLrnPtrnID.Value = e.Item.Cells[12].Text;
                hidPtrnID.Value = row.Cells[7].Text;
                hidEditAdd.Value = "1";
                chkCourse.Items[1].Selected = true;
                tblSelectCr.Attributes.Add("style", "Display:inline");
                //fnFacWiseCr(hidUniID.Value,hidFacID.Value,hidCrID.Value,hidCrMoLrnID.Value);


                tblSelectCr.Style.Add("display", "none");
                tblSelectCr2.Style.Add("display", "block");
                lblFacName.Text = row.Cells[2].Text;
                lblCrName.Text = row.Cells[16].Text;
                lblMoLrnName.Text = row.Cells[6].Text;
                lblPtrnName.Text = row.Cells[9].Text;

                if (row.Cells[8].Text != "0")
                {
                    trCrBranch.Style.Add("display", "block");
                    hidBrnID.Value = row.Cells[8].Text;
                    lblBranchName.Text = row.Cells[14].Text;
                }
                else
                {
                    hidBrnID.Value = "0";
                    //trCrBranch.Style.Add("display", "none");
                    lblBranchName.Text = "";
                }
                rdConfigureRights.SelectedValue = row.Cells[10].Text.Trim();
            }
        }*/
        #endregion

        #region DGCourseRights1_Sorting
        protected void DGCourseRights1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                if (ViewState["SortOrder"].ToString() == " asc")
                    ViewState["SortOrder"] = " desc";
                else
                    ViewState["SortOrder"] = " asc";
            }
            else
            {
                ViewState["SortExpression"] = e.SortExpression;
                ViewState["SortOrder"] = " asc";
            }
            FillGrid();
        }
        #endregion

        #region DGCourseRights1_RowEditing
        protected void DGCourseRights1_RowEditing(object sender, GridViewEditEventArgs e)
        {
                 
                hidFacID.Value=DGCourseRights1.Rows[e.NewEditIndex].Cells[1].Text.Trim();
                
                hidCrID.Value = DGCourseRights1.Rows[e.NewEditIndex].Cells[3].Text.Trim();
                hidMoLrnID.Value = DGCourseRights1.Rows[e.NewEditIndex].Cells[5].Text.Trim();
                hidPtrnID.Value = DGCourseRights1.Rows[e.NewEditIndex].Cells[7].Text.Trim();
                hidEditAdd.Value = "1";
                chkCourse.Items[1].Selected = true;
                tblSelectCr.Attributes.Add("style", "Display:inline");

                tblSelectCr.Style.Add("display", "none");
                tblSelectCr2.Style.Add("display", "block");
                lblFacName.Text = DGCourseRights1.Rows[e.NewEditIndex].Cells[2].Text.Trim();
                lblCrName.Text = DGCourseRights1.Rows[e.NewEditIndex].Cells[16].Text.Trim();
                lblMoLrnName.Text = DGCourseRights1.Rows[e.NewEditIndex].Cells[6].Text.Trim();
                lblPtrnName.Text = DGCourseRights1.Rows[e.NewEditIndex].Cells[9].Text.Trim();

                if (DGCourseRights1.Rows[e.NewEditIndex].Cells[8].Text.Trim() != "0")
                {
                    trCrBranch.Style.Add("display", "block");
                    hidBrnID.Value = DGCourseRights1.Rows[e.NewEditIndex].Cells[8].Text.Trim();
                    lblBranchName.Text = DGCourseRights1.Rows[e.NewEditIndex].Cells[14].Text.Trim();
                }
                else
                {
                    hidBrnID.Value = "0";
                    lblBranchName.Text = "";
                }
                rdConfigureRights.SelectedValue = DGCourseRights1.Rows[e.NewEditIndex].Cells[10].Text.Trim();
            }
        #endregion

        #endregion
             
        }

  }

