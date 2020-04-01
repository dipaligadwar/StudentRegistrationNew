using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;
using System.Threading;
using System.Globalization;
using System.Configuration;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_PaperChange__1 : System.Web.UI.Page
    {
        #region Variables

        InstituteRepository InstRep = new InstituteRepository();
        clsCommon Common = new clsCommon();
        clsUser user;
        private string instIDs = "";
        private string[] IDs_List = new string[3];
        DataTable dt = new DataTable();

        #endregion

        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["user"];

         

            if (!IsPostBack)
            {
                if (Page.PreviousPage != null && Page.PreviousPage.ToString().Equals("ASP.eligibility_elgv2_paperchange_aspx"))
                {
                    //-------------------------------------
                    // For University Login and Fresh load
                    //-------------------------------------
                    ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                    searchInstNew temp = (searchInstNew)Cntph1.FindControl("SchInst1");
                    hidInstID.Value = ((HtmlInputHidden)Cntph1.FindControl("hidInstID")).Value;

                    hidAcademicYear.Value = Session["AcademicYearID"].ToString();//Session["pk_AcademicYear_ID"].ToString();

                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                    hidInstCode.Value = ((HtmlInputHidden)temp.FindControl("hidCollCode")).Value;
                    hidInstName.Value = ((HtmlInputHidden)temp.FindControl("hidCollName")).Value;
                }
                else
                {
                    if (user.UserTypeCode != "2")
                    {
                        //-----------------------------------------
                        // For University Login and Back Navigation
                        //-----------------------------------------
                        ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                        hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                        hidInstID.Value = ((HtmlInputHidden)Cntph1.FindControl("hidInstID")).Value;

                        hidAcademicYear.Value = Session["AcademicYearID"].ToString();

                        hidInstName.Value = ((HtmlInputHidden)Cntph1.FindControl("hidInstName")).Value;
                        hidInstCode.Value = ((HtmlInputHidden)Cntph1.FindControl("hidInstCode")).Value;
                    }
                }
                YCMOU.IsReportUserAndDateDisplay = false;
                YCMOU.IsInstituteDisplay = false;
                ((HtmlInputHidden)YCMOU.FindControl("hid_Institute_ID")).Value = hidInstID.Value;
             
            }

            YCMOU.isPpChange.Value = "Yes";
            //modified  by shafik on 09-oct-2012  added new hidden  as need to hide the academic year on paperchange  page
            YCMOU.hidIsAcdYrDdNotVisible.Value = "Yes";
            YCMOU.IsInstituteDisplay = YCMOU.IsCourseDisply = YCMOU.IsFacultyDisplay = YCMOU.IsBranchDisply = YCMOU.IsCoursePartDisply = YCMOU.IsCourseTermDisply = YCMOU.IsAcYrDisplay = false;
            YCMOU.IsCollegeLogin = true;

            YCMOU.OnProceedClick += btnNext_Click;


            if (user.UserTypeCode == "2")
            {
                //-----------------------------------------------
                // For Institute Login (Fresh and Back Navigation)
                //-----------------------------------------------
                instIDs = user.UserReferenceID;
                hidInstID.Value = instIDs.ToString();
                // hidInstName.Value = user.Name;
                lblPageHead.Text = lblPaper.Text + " Change";
                //dt = InstRep.InstituteDetails(hidUniID.Value, hidInstID.Value);
                //hidInstName.Value = dt.Rows[0]["Inst_Name"].ToString();
                //hidInstCode.Value = dt.Rows[0]["Inst_Code"].ToString();
                hidInstName.Value = user.Name;
                lblSubHeader.Text = "  for " + hidInstName.Value;
                YCMOU.hid_Institute_ID.Value = hidInstID.Value;
            }

            else
            {
                lblPageHead.Text = lblPaper.Text + " Change";
                lblSubHeader.Text = "  for " + hidInstName.Value + " [" + hidInstCode.Value + "] ";

            }
        }

        #endregion

        #region btnNext_Click

        protected void btnNext_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            // set hiddens and call 'Allow' check

           
             hidPRN.Value = ((TextBox)YCMOU.FindControl("txtPRN")).Text;
               
            if (((TextBox)YCMOU.FindControl("txtElgFormNo")).Text != "")
            {
                hidElgFormNo.Value = ((TextBox)YCMOU.FindControl("txtElgFormNo")).Text.Trim();
               
            }

            hidAppFormNo.Value = ((TextBox)YCMOU.FindControl("txtApplFormNo")).Text;
            FillGrid();
            
        }

        #endregion



      
  void FillGrid()
        {

            DataTable odt = new DataTable();
       
            Hashtable oHs = new Hashtable();
            oHs.Add("UniID", clsGetSettings.UniversityID.Trim());
            oHs.Add("InstID", hidInstID.Value);
           oHs.Add("AcademicYear",hidAcademicYear.Value);
            if (hidPRN.Value != string.Empty)
            {
                oHs.Add("PRN", hidPRN.Value);
            }
            else if (hidElgFormNo.Value != string.Empty)
            {
                oHs.Add("RefUni", hidElgFormNo.Value.Split('-')[0].ToString());
                oHs.Add("RefInstID", hidElgFormNo.Value.Split('-')[1].ToString());
                oHs.Add("RefYear", hidElgFormNo.Value.Split('-')[2].ToString());
                oHs.Add("RefStudent", hidElgFormNo.Value.Split('-')[3].ToString());
            }

            else if (hidAppFormNo.Value != string.Empty)
            {
                oHs.Add("ApplicationFormNo", hidAppFormNo.Value);
                
            }

            odt = clsPaperChange.ListStudentCoursePartTerm(oHs);
            if (odt.Rows.Count > 0 )
            {
                    TrNote.Visible = true;
                    GV_SrchStud.Visible = true;
                    GV_SrchStud.DataSource = odt;
                    GV_SrchStud.DataBind();

            }
            else
            {
                GV_SrchStud.Visible = false;
                TrNote.Visible = false;
                lblMessage.Text = "No Records found.";
                if (hidAppFormNo.Value != string.Empty)
                {
                    lblMessage.Text = "Application Form No is Not present In Selected college Or Current Academic Year.";
                }
            }
        }

 



        protected void GV_SrchStud_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            clsUser oUser = (clsUser)Session["user"];
            
            if (e.Row.RowType == DataControlRowType.Header)
            {
              

                if (clsGetSettings.UniversityID.Equals("169") && oUser.UserTypeCode!="2")
                    e.Row.Cells[13].Visible = true;
                else
                    e.Row.Cells[13].Visible = false;
               e.Row.Cells[0].Text = lblStudName.Text;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //e.Row.Cells[0].Text = lblStudName.Text;
                if (clsGetSettings.UniversityID.Equals("169") && oUser.UserTypeCode != "2")
                    e.Row.Cells[13].Visible = true;
                else
                    e.Row.Cells[13].Visible = false;

                
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkSelect");
                if (e.Row.Cells[10].Text == "0" && e.Row.Cells[11].Text == "0" && e.Row.Cells[12].Text == "1")
                {

                    if (lnk != null)
                    {
                        lnk.Enabled = false;
                    }

                }
                else
                {
                    if (lnk != null)
                    {
                        lnk.Enabled = true;
                    }
                }


            }
        }

        protected void GV_SrchStud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            WebControl wc = e.CommandSource as WebControl;
            GridViewRow row = wc.NamingContainer as GridViewRow;

            if (e.CommandName.Equals("PaperChange"))
            {
                if (row != null)
                {
                    int index = row.RowIndex;
                    GridViewRow selectedRow = GV_SrchStud.Rows[index];

                    hidStudentName.Value = Convert.ToString(selectedRow.Cells[0].Text);
                    hidCrName.Value = Convert.ToString(selectedRow.Cells[1].Text);
                    hidFacID.Value = Convert.ToString(selectedRow.Cells[3].Text);
                    hidCrID.Value = Convert.ToString(selectedRow.Cells[4].Text);
                    hidMoLrnID.Value = Convert.ToString(selectedRow.Cells[5].Text);
                    hidPtrnID.Value = Convert.ToString(selectedRow.Cells[6].Text);
                    hidBrnID.Value = Convert.ToString(selectedRow.Cells[7].Text);
                    hidCrPrDetailsID.Value = Convert.ToString(selectedRow.Cells[8].Text);
                    hidCrPrChID.Value = Convert.ToString(selectedRow.Cells[9].Text);
                    hidAppFormNo.Value = ((TextBox)YCMOU.FindControl("txtApplFormNo")).Text;
                    Server.Transfer("ELGV2_PaperChange__2.aspx");
                }
            }
            else if (e.CommandName.Equals("CetDetails"))
            {
                int index = row.RowIndex;
                GridViewRow selectedRow = GV_SrchStud.Rows[index];

                hidStudentName.Value = Convert.ToString(selectedRow.Cells[0].Text);
                hidCrName.Value = Convert.ToString(selectedRow.Cells[1].Text);
                hidFacID.Value = Convert.ToString(selectedRow.Cells[3].Text);
                hidCrID.Value = Convert.ToString(selectedRow.Cells[4].Text);
                hidMoLrnID.Value = Convert.ToString(selectedRow.Cells[5].Text);
                hidPtrnID.Value = Convert.ToString(selectedRow.Cells[6].Text);
                hidBrnID.Value = Convert.ToString(selectedRow.Cells[7].Text);
                hidCrPrDetailsID.Value = Convert.ToString(selectedRow.Cells[8].Text);
                hidCrPrChID.Value = Convert.ToString(selectedRow.Cells[9].Text);
                Server.Transfer("ELGV2_CETDetails.aspx");
            }

        }




    }
}
