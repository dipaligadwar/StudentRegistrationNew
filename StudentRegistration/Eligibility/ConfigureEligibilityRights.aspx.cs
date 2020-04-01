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


namespace StudentRegistration.Eligibility
{
    public partial class ConfigureEligibilityRights : System.Web.UI.Page
    {
        clsCommon Common = new clsCommon();       
        DataTable objDT;
        string Uni_ID = UniversityPortal.clsGetSettings.UniversityID.ToString();
        clsEligibilityRights objclsEligibility = new clsEligibilityRights();
        clsUser userob = new clsUser();
        string userid = "";

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.clsCache.NoCache();
            chkCourse.Attributes.Add("onclick","fnChkCourse();");
            btnProcess.Attributes.Add("onclick","return fnSaveValidate();");
            userob = (clsUser)Session["User"];
            userid = userob.User_ID.ToString();
          
            if (!IsPostBack)
            {                
                //--------------------------------------------------------
                //University ID Checking
                //--------------------------------------------------------

                if (hidUniID.Value == "")
                {
                    hidUniID.Value = UniversityPortal.clsGetSettings.UniversityID.ToString();
                }      
                   
                fnFirstFill();
                DisplayGrid("");
                lblCrNote.Text = "Already configured eligibility rights";
            }
        }
        #endregion

        #region First Fill...
        private void fnFirstFill()
        {
            fnFacFill();
            fnFacWiseCr(hidUniID.Value, "", "", "");
            
        }

        private void fnFacFill()
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
           
        }
        private void fnFacWiseCr(string sUniID,string sFacID,string sCrID,string sCrMoLrnID)
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
                dd_Cr_Desc.Items.Clear();
                Common.fillDropDown(dd_Cr_Desc, objDT, "", "Cr_desc", "pk_Cr_ID", "------ Select ------");
            }
            else
            {
                dd_Cr_Desc.Items.Clear();
                ListItem Li = new ListItem();
                Li.Text = "------ Select ------";
                Li.Value = "0";
                dd_Cr_Desc.Items.Insert(0, Li);
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

        }
        #endregion   
     
        #region DisplayGrid
        private void DisplayGrid(string sortExpression)
        {
            DataTable oDT = new DataTable();
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
                    //if (dd_Fac_Desc.SelectedValue != "0")
                    //{
                    //    objDT = CourseRepository.coursewiseModeOfLearnings(hidUniID.Value,hidFacID.Value,hidCrID.Value);
                    //    if (objDT.Rows.Count > 0 && objDT != null)
                    //    {
                    //        lblCrNote.Text = "Selected Course : " + objDT.Rows[0]["Cr_Desc"].ToString();
                    //    }
                       
                    //}   
                    lblCrNote.Text = "Already configured eligibility rights";

                }
            }
            else
            {
                DGCourseRights.Visible = false;
            }
        }

       
        #endregion 

        private void ClearCrSelection()
        {
            dd_Fac_Desc.ClearSelection();
            dd_Cr_Desc.ClearSelection();
            dd_CrPtrn_Desc.ClearSelection();
            dd_ModeLrn_Desc.ClearSelection();
            rdConfigureRights.ClearSelection();
            chkCourse.ClearSelection();

        }

        #region Procced
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            string sReturn = "";
           
            hidCorseFlag.Value = chkCourse.SelectedValue.Trim();
            hidCollUniFlag.Value = rdConfigureRights.SelectedValue.Trim();
                   
            if(hidEditAdd.Value == "0" || hidEditAdd.Value =="")
            {
                sReturn = objclsEligibility.Add_EligibilityRights(hidUniID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidCrPtrnID.Value, hidCollUniFlag.Value, userid.ToString(), hidCorseFlag.Value);
                
                DisplayGrid("");
            }
            else
            {
                sReturn = objclsEligibility.Modify_EligibilityRights(hidUniID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value, hidCrMoLrnPtrnID.Value, hidCollUniFlag.Value, userid.ToString(), hidCorseFlag.Value);
               // hidEditAdd.Value = "0";
                tblSelectCr.Attributes.Add("style", "Display:inline");
                fnFacWiseCr(hidUniID.Value, hidFacID.Value, hidCrID.Value, hidCrMoLrnID.Value);
                dd_Fac_Desc.SelectedValue = hidFacID.Value;
                dd_Cr_Desc.SelectedValue = hidCrID.Value.Trim();
                dd_ModeLrn_Desc.SelectedValue = hidCrMoLrnID.Value.Trim();
                dd_CrPtrn_Desc.SelectedValue = hidCrMoLrnPtrnID.Value;

                DisplayGrid("");

               
            }
            if (sReturn == "Y")
            {
                lblNote.Text = "Record Saved Sucessfully";
                lblNote.CssClass = "saveNote";           
               
            }
            else
            {
                lblNote.Text = "Information can not be processed";
                lblNote.CssClass = "errorNote";
            }
           
           
        }
        #endregion

        #region Grid Events
        protected void DGCourseRights_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                int srNo = e.Item.DataSetIndex + 1;
                e.Item.Cells[0].Text = srNo.ToString();


                e.Item.Cells[4].Text = e.Item.Cells[4].Text +"-" + e.Item.Cells[15].Text+ "-" + e.Item.Cells[6].Text + "-" + e.Item.Cells[8].Text ;
                
            }
           
        }

        protected void DGCourseRights_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DGCourseRights.CurrentPageIndex = e.NewPageIndex;
            lblNote.Text = "";
            DisplayGrid("");
            ClearCrSelection();
        }

        protected void DGCourseRights_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                
                hidFacID.Value = e.Item.Cells[1].Text;                
                hidCrID.Value = e.Item.Cells[3].Text;
                hidMoLrnID.Value = e.Item.Cells[5].Text;
                hidCrMoLrnID.Value = e.Item.Cells[11].Text;
                hidCrMoLrnPtrnID.Value = e.Item.Cells[12].Text;
                hidCrPtrnID.Value = e.Item.Cells[7].Text;
                hidEditAdd.Value = "1";
                chkCourse.Items[1].Selected = true;
                tblSelectCr.Attributes.Add("style","Display:inline");
                fnFacWiseCr(hidUniID.Value,hidFacID.Value,hidCrID.Value,hidCrMoLrnID.Value);
                dd_Fac_Desc.SelectedValue = hidFacID.Value;
                dd_Cr_Desc.SelectedValue = hidCrID.Value;
                dd_ModeLrn_Desc.SelectedValue = hidCrMoLrnID.Value.Trim();
                dd_CrPtrn_Desc.SelectedValue = hidCrMoLrnPtrnID.Value;
                rdConfigureRights.SelectedValue = e.Item.Cells[9].Text.Trim();  
            }
        }
        #endregion

        protected void DGCourseRights_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            DisplayGrid(e.SortExpression);
        }
    }
}
