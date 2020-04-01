using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using Classes;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;

namespace StudentRegistration.Eligibility.WebCtrl
{
    /// <summary>
    ///		Summary description for StudentsStatusSearch.
    /// </summary>
    public partial class StudentsStatusSearch : System.Web.UI.UserControl
    {
        #region Variables
        DataSet dsDistricts = new DataSet();
        private string qstrNavigate;
        private string strUrl;
        string PRNumber = null;
        clsCommon Common = new clsCommon();
        clsCache clsCache = new clsCache();
        clsState clsState = new clsState();
        clsTaluka clsTaluka = new clsTaluka();
        clsDistrict clsDistrict = new clsDistrict();
        DataSet ds;
        private string Elg_FormNo;
        private int pkUniID, pkYear, pkStudentID, Flag;
        string InstituteID = null;

        #endregion

        #region Properties
        public string QstrNavigate
        {
            set
            {
                qstrNavigate = value;
            }
        }
        public string StrUrl
        {
            set
            {
                strUrl = value;
            }
            get
            {
                return strUrl;
            }
        }

        public int pk_Uni_ID
        {
            get
            {
                return pkUniID;
            }
            set
            {
                pkUniID = value;
            }
        }

        public int pk_Year
        {
            get
            {
                return pkYear;
            }
            set
            {
                pkYear = value;
            }
        }

        public int pk_Student_ID
        {
            get
            {
                return pkStudentID;
            }
            set
            {
                pkStudentID = value;
            }
        }

        public string ElgFormNo
        {
            get
            {
                return Elg_FormNo;
            }
            set
            {
                Elg_FormNo = value;
            }
        }

        public string PRN
        {
            get
            {
                return PRNumber;
            }
            set
            {
                PRNumber = value;
            }
        }


        public int DisplayFlag
        {
            get
            {
                return Flag;
            }
            set
            {
                Flag = value;
            }
        }

        public string HidSearchType
        {
            get
            {
                return hidSearchType.Value;
            }
            set
            {
                hidSearchType.Value = value;
            }
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, System.EventArgs e)
        {
            clsCache.NoCache();

            Ajax.Utility.RegisterTypeForAjax(typeof(Eligibility.AjaxMethods), this.Page);
            Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent), this.Page);

            dgRegStudentList1.Style.Add("display", "none");
            lblGridName.Style.Remove("display");
            lblGridName.Style.Add("display", "none");
            divDGNote.Style.Remove("display");
            divDGNote.Style.Add("display", "none");

            if (!IsPostBack)
            {
                #region Set Hidden
                HtmlInputHidden[] hid = new HtmlInputHidden[20];
                hid[0] = hidInstID;
                hid[1] = hidUniID;
                hid[2] = hidStateID;
                hid[3] = hidDistrictID;
                hid[4] = hidTehsilID;
                hid[5] = hidElgFormNo;
                hid[6] = hidpkStudentID;
                hid[7] = hidpkYear;
                hid[8] = hidPRN;
                hid[9] = hidSearchType;
                hid[10] = hidRef_InstReg_Uni_ID;
                hid[11] = hidRef_InstReg_Institute_ID;
                hid[12] = hidRef_InstReg_Year;
                hid[13] = hidRef_Student_ID;
                hid[14] = hidpkFacID;
                hid[15] = hidpkCrID;
                hid[16] = hidpkMoLrnID;
                hid[17] = hidpkPtrnID;
                hid[18] = hidpkBrnID;
                hid[19] = hidpkCrPrDetailsID;
                divSimpleSearch.Style.Add("display", "block");
                lblAdvSearch.InnerText = "Advanced Search";

                if (Page.PreviousPage != null)
                {
                    ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

                    if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                    {
                        hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;

                    }
                }
                lblGrid.Attributes.Add("style", "display:none");
                btnSimpleSearch.Attributes.Add("onclick", "return ChkValidation();");
                Common.setHiddenVariables(ref hid);
                #endregion

                #region back navigation

                if (qstrNavigate == "back")
                {
                    ContentPlaceHolder Cntp = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");

                    if (((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != null || ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value != "")
                    {
                        hidInstID.Value = ((HtmlInputHidden)Cntp.FindControl("hidInstID")).Value;
                        hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                        hidpkFacID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkFacID")).Value;
                        hidpkCrID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkCrID")).Value;
                        hidpkMoLrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkMoLrnID")).Value;
                        hidpkPtrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkPtrnID")).Value;
                        hidpkBrnID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkBrnID")).Value;
                        hidpkCrPrDetailsID.Value = ((HtmlInputHidden)Cntp.FindControl("hidpkCrPrDetailsID")).Value;
                        hidElgFormNo.Value = ((HtmlInputHidden)Cntp.FindControl("hidElgFormNo")).Value;
                        hidPRN.Value = ((HtmlInputHidden)Cntp.FindControl("hidPRN")).Value;
                        hidIsBlank.Value = ((HtmlInputHidden)Cntp.FindControl("hidIsBlank")).Value;
                        hidDOB.Value = ((HtmlInputHidden)Cntp.FindControl("hidDOB")).Value;
                    }

                    if (Request.QueryString["Search"] == "Adv")
                    {
                        lblAdvSearch.InnerText = "Simple Search";
                       // txtDOB.Text = hidDOB.Value;
                        for (int i = 0; i < ddlGender.Items.Count; i++)
                        {
                            if (ddlGender.Items[i].Value == hidGender.Value)
                                ddlGender.SelectedIndex = i;
                        }
                        txtLastName.Text = hidLastName.Value;
                        txtFirstName.Text = hidFirstName.Value;
                        fnFillStateDistrictTaluka(hidStateID.Value, hidDistrictID.Value, hidTehsilID.Value);

                        hidStateID.Value = hidStateID.Value;
                        hidDistrictID.Value = hidDistrictID.Value;
                        hidTehsilID.Value = hidTehsilID.Value;
                        hidDOB.Value = hidDOB.Value;
                        DivAdvanceSearch.Attributes.Add("style", "display:block");
                        divSimpleSearch.Style.Add("display", "none");
                        fnDisplayDGRegStudentList();
                    }

                    else if (Request.QueryString["Search"] == "Simple")
                    {
                        lblAdvSearch.InnerText = "Advanced Search";
                        if (hidIsBlank.Value != "")
                        {
                            txtElgFormNo.Text = hidElgFormNo.Value;
                        }
                        else
                        {
                            txtPRN.Text = hidPRN.Value;
                        }

                        fnFetchStudent();
                    }

                }
                else
                {
                    fnFillStateDistrictTaluka("", "", "");
                    hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                    if (Request.QueryString["Search"] == "Adv" || HidSearchType.Equals("Adv"))
                    {
                        DivAdvanceSearch.Attributes.Add("style", "display:block");
                        divSimpleSearch.Style.Add("display", "none");
                        lblAdvSearch.InnerText = "Simple Search";
                    }
                    else if (Request.QueryString["Search"] == "Simple" || HidSearchType.Equals("Simple"))
                    {
                        DivAdvanceSearch.Attributes.Add("style", "display:none");
                        divSimpleSearch.Style.Add("display", "block");
                        lblAdvSearch.InnerText = "Advanced Search";
                    }
                }

                #endregion
            }
            else
            {
                fnFillStateDistrictTaluka(hidStateID.Value, hidDistrictID.Value, hidTehsilID.Value);
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            }

            try
            {
                hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
            }
            catch
            {
                hidIsPRNValidationRequired.Value = "N";
            }

            fnFillStateDistrictTaluka(hidStateID.Value, hidDistrictID.Value, hidTehsilID.Value);
        }

        #endregion

        #region fnDisplayDGRegStudentList

        private void fnDisplayDGRegStudentList()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = Eligibility.clsEligibilityDBAccess.Fetch_Reg_Student_List(Classes.clsGetSettings.UniversityID.ToString(), hidInstID.Value, hidStateID.Value, hidDistrictID.Value, hidTehsilID.Value, hidDOB.Value, hidLastName.Value, hidFirstName.Value, hidGender.Value);
                DataView DV = new DataView();
                DV.Table = ds.Tables[0];

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ViewState["SortExpression"] != null)
                    {
                        DV.Sort = ViewState["SortExpression"].ToString() + ViewState["SortOrder"].ToString();

                    }

                    dgRegStudentList1.DataSource = DV;
                    dgRegStudentList1.DataBind();

                    dgRegStudentList1.Style.Add("display", "block");
                    tblDGRegStudentList.Style.Remove("display");
                    tblDGRegStudentList.Style.Add("display", "block");
                    lblGridName.Text = "..:: List of Students whose Eligibility Status for " + lblCr.Text + "(s) is to be Viewed ::..";
                    lblGridName.Style.Remove("display");
                    lblGridName.Style.Add("display", "block");
                    divDGNote.Style.Add("display", "block");
                    lblGrid.Style.Add("display", "none");
                    lblMsg.Style.Add("display", "none");
                }

                else
                {
                    dgRegStudentList1.Style.Add("display", "none");
                    tblDGRegStudentList.Style.Remove("display");
                    tblDGRegStudentList.Style.Add("display", "none");
                    lblGridName.Text = "The Eligibility of Student(s) searched for, is not yet processed...";
                    lblGridName.Style.Remove("display");
                    lblGridName.Style.Add("display", "block");
                    divDGNote.Style.Add("display", "none");
                }

                if ((Request.QueryString["Search"] == "Adv" || HidSearchType.Equals("Adv")))
                {
                    divSimpleSearch.Attributes.Add("style", "display:none");
                    DivAdvanceSearch.Attributes.Add("style", "display:block");
                }

                ds.Clear();
                ds.Dispose();
                ds = null;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        #endregion

        #region fnFillStateDistrictTaluka

        private void fnFillStateDistrictTaluka(string stateID, string districtID, string tehsilID)
        {
            clsCommon common = new clsCommon();
            DataTable dt;

            State_ID.Items.Clear();
            try
            {
                dt = clsState.DisplayAllStates("E");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            common.fillDropDown(State_ID, dt, stateID, "State_Name", "State_ID", "--- Select ---");
            if (dt != null) dt = null;

            District_ID.Items.Clear();
            try
            {
                dt = clsDistrict.StateWiseDistricts(State_ID.SelectedItem.Value, "E");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            common.fillDropDown(District_ID, dt, districtID, "Text", "Value", "--- Select ---");
            if (dt != null) dt = null;

            Tehsil_ID.Items.Clear();
            try
            {
                dt = clsTaluka.DisplayTalukaWithinDistrict(District_ID.SelectedItem.Value, "E");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            common.fillDropDown(Tehsil_ID, dt, tehsilID, "Text", "Value", "--- Select ---");
            if (dt != null) dt = null;

            if (common != null) common = null;

        }

        #endregion

        #region btnSearch_Click

        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            lblAdvSearch.InnerText = "Simple Search";
            //string dob = txtDOB.Text.Trim();
            //if (dob != "")
            //{
            //    string[] arr = new string[3];
            //    arr = dob.Split('/');
            //    dob = arr[1] + '/' + arr[0] + '/' + arr[2];
            //}

            //hidDOB.Value = dob;
            hidDOB.Value = "";
            hidGender.Value = ddlGender.SelectedItem.Value;
            hidLastName.Value = txtLastName.Text.Trim();
            hidFirstName.Value = txtFirstName.Text.Trim();
            dgRegStudentList1.PageIndex = 0;
            fnDisplayDGRegStudentList();


        }

        #endregion

        # region Commented by Jatin
        #region Datagrid related functions

        #region dgRegStudentList_SortCommand

        /*      protected void dgRegStudentList_SortCommand(object source, DataGridSortCommandEventArgs e)
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
            fnDisplayDGRegStudentList();
        }*/

        #endregion

        #region dgRegStudentList_ItemCommand

        /*     protected void dgRegStudentList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {

                hidpkYear.Value = e.Item.Cells[3].Text.Trim();
                hidpkStudentID.Value = e.Item.Cells[4].Text.Trim();
                hidRef_InstReg_Uni_ID.Value = e.Item.Cells[5].Text.Trim();
                hidRef_InstReg_Institute_ID.Value = e.Item.Cells[6].Text.Trim();
                hidRef_InstReg_Year.Value = e.Item.Cells[7].Text.Trim();
                hidRef_Student_ID.Value = e.Item.Cells[8].Text.Trim();
                hidpkFacID.Value = e.Item.Cells[11].Text.Trim();
                hidpkCrID.Value = e.Item.Cells[12].Text.Trim();
                hidpkMoLrnID.Value = e.Item.Cells[13].Text.Trim();
                hidpkPtrnID.Value = e.Item.Cells[14].Text.Trim();
                hidpkBrnID.Value = e.Item.Cells[15].Text.Trim();
                hidpkCrPrDetailsID.Value = e.Item.Cells[16].Text.Trim();

                hidElgFormNo.Value = hidRef_InstReg_Uni_ID.Value + "-" + hidRef_InstReg_Institute_ID.Value + "-" + hidRef_InstReg_Year.Value + "-" + hidRef_Student_ID.Value;

                Server.Transfer(strUrl);
            }
        }*/

        #endregion

        #region dgRegStudentList_PageIndexChanged

        /* protected void dgRegStudentList_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            
                dgRegStudentList.CurrentPageIndex = e.NewPageIndex;
                fnDisplayDGRegStudentList();

            
        }*/

        #endregion

        #region dgRegStudentList_ItemDataBound

        /*     protected void dgRegStudentList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + (dgRegStudentList.CurrentPageIndex * 10) + 1);

            }
        }*/

        #endregion

        #endregion
        # endregion Commented by Jatin

        #region GridView Events

        #region dgRegStudentList1_RowDataBound
        protected void dgRegStudentList1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
                //e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
                //e.Row.Cells[7].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none"); 
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
                e.Row.Cells[13].Style.Add("display", "none");
            }
        }
        #endregion

        #region dgRegStudentList1_RowCommad
        protected void dgRegStudentList1_RowCommad(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "StudentDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgRegStudentList1.Rows[index];
                hidElgFormNo.Value = row.Cells[1].Text.Trim();
                hidpkYear.Value = row.Cells[4].Text.Trim();
                hidpkStudentID.Value = row.Cells[5].Text.Trim();
                //hidRef_InstReg_Uni_ID.Value = row.Cells[5].Text.Trim();
                //hidRef_InstReg_Institute_ID.Value = row.Cells[6].Text.Trim();
                //hidRef_InstReg_Year.Value = row.Cells[7].Text.Trim();
                //hidRef_Student_ID.Value = row.Cells[8].Text.Trim();
                hidPRN.Value = row.Cells[3].Text.Trim();
                hidpkFacID.Value = row.Cells[8].Text.Trim();
                hidpkCrID.Value = row.Cells[9].Text.Trim();
                hidpkMoLrnID.Value = row.Cells[10].Text.Trim();
                hidpkPtrnID.Value = row.Cells[11].Text.Trim();
                hidpkBrnID.Value = row.Cells[12].Text.Trim();
                hidpkCrPrDetailsID.Value = row.Cells[13].Text.Trim();                
                Server.Transfer(strUrl, true);
            }
        }
        #endregion

        #region dgRegStudentList1_PageIndexChanging
        protected void dgRegStudentList1_PageIndexChangin(object sender, GridViewPageEventArgs e)
        {

            dgRegStudentList1.PageIndex = e.NewPageIndex;
            //dgRegStudentList1.DataBind();
            fnDisplayDGRegStudentList();
        }
        #endregion

        #region dgRegStudentList1_Sorting
        protected void dgRegStudentList1_Sorting(object sender, GridViewSortEventArgs e)
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
            fnDisplayDGRegStudentList();
        }
        #endregion

        #endregion

        #region btnSimpleSearch_Click

        protected void btnSimpleSearch_Click(object sender, System.EventArgs e)
        {
            hidSearchType.Value = "Simple";
            fnFetchStudent();
        }

        #endregion

        #region fnFetchStudent

        private void fnFetchStudent()
        {
            //string ElgFormNo = txtElgFormNo.Text.Trim();
            lblAdvSearch.InnerText = "Advanced Search";
            if (txtElgFormNo.Text != "")
            {
                Elg_FormNo = txtElgFormNo.Text.Trim();
                hidIsBlank.Value = Elg_FormNo;
            }
            else
            {
                Elg_FormNo = "0-0-0-0";
                hidIsBlank.Value = "";
            }
            int cnt = 0;
            string str = Elg_FormNo;
            int pos = str.IndexOf('-');
            string[] arr = new string[] { "0", "0", "0", "0" };

            //Regular expression validation
            Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");

            if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                PRN = txtPRN.Text.Trim();
            InstituteID = hidInstID.Value;

            while (pos != -1)
            {
                str = str.Substring(pos + 1);
                pos = str.IndexOf('-');
                cnt++;

            }
            if (cnt == 3)
            {

                arr = ElgFormNo.Split('-');   //UniID = arr[0], InstituteID = arr[1], Year = arr[2], StudID = arr[3]
                for (int i = 0; i < 4; i++)
                {
                    if (arr[i] == "")
                        arr[i] = "0";
                }
            }
            if (arr[1] != "0" && arr[1] != hidInstID.Value)
            {
                lblMsg.Text = "Entered Eligibility Form Number does not belong to this " + lblCollege.Text + ".";
                lblMsg.Style.Remove("display");
                lblMsg.Style.Add("display", "block");
                dgRegStudentList1.Style.Add("display", "none");

            }
            else
            {
                ds = clsEligibilityDBAccess.REG_Search_GetStudentIDs(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[2]), Convert.ToInt32(arr[1]), Convert.ToInt32(arr[3]), txtPRN.Text, hidInstID.Value);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                    {
                        lblMsg.Text = "The " + lblPRNNomenclature.Text + " given doesn't exists.";
                        dgRegStudentList1.Style.Add("display", "none");
                        lblMsg.Style.Remove("display");
                        lblMsg.Style.Add("display", "block");

                    }
                    else
                    {
                        lblMsg.Text = "Sorry,No matching record found.Please Check later.";
                        dgRegStudentList1.Style.Add("display", "none");
                        lblMsg.Style.Remove("display");
                        lblMsg.Style.Add("display", "block");
                    }

                    if (qstrNavigate == "back")
                    {
                        txtElgFormNo.Text = string.Empty;
                        txtPRN.Text = string.Empty;
                    }

                }
                else
                {

                    if (hidInstID.Value != null || hidInstID.Value != "")
                    {

                        hidElgFormNo.Value = txtElgFormNo.Text.Trim();
                        hidpkYear.Value = ds.Tables[0].Rows[0]["pkYear"].ToString();
                        hidpkStudentID.Value = ds.Tables[0].Rows[0]["pkStudentID"].ToString();
                        hidpkFacID.Value = ds.Tables[0].Rows[0]["pk_Fac_ID"].ToString();
                        hidpkCrID.Value = ds.Tables[0].Rows[0]["pk_Cr_ID"].ToString();
                        hidpkMoLrnID.Value = ds.Tables[0].Rows[0]["pk_MoLrn_ID"].ToString();
                        hidpkPtrnID.Value = ds.Tables[0].Rows[0]["pk_Ptrn_ID"].ToString();
                        hidpkBrnID.Value = ds.Tables[0].Rows[0]["pk_Brn_ID"].ToString();
                        hidpkCrPrDetailsID.Value = ds.Tables[0].Rows[0]["pk_CrPr_Details_ID"].ToString();
                        hidPRN.Value = ds.Tables[0].Rows[0]["PRN"].ToString();
                        dgRegStudentList1.DataSource = ds;
                        dgRegStudentList1.DataBind();
                        lblGrid.Text = "<font color= 'red'>" + "Please click on the Student Name to view the Eligibility Status of a particular " + lblCr.Text + " " + "</font>";
                        lblGrid.Attributes.Add("style", "display:block");
                        dgRegStudentList1.Attributes.Add("style", "display:block");
                        lblMsg.Style.Add("display", "none");
                        divDGNote.Attributes.Add("style", "display:none");
                        tblDGRegStudentList.Style.Remove("display");
                        tblDGRegStudentList.Style.Add("display", "block");

                        //Server.Transfer("ELGV2_ViewStatus__2.aspx?Search=Simple");
                    }
                    else
                    {
                        lblMsg.Text = "Entered " + lblPRNNomenclature.Text + " does not belong to this " + lblCollege.Text + ".";
                        lblMsg.Style.Remove("display");
                        lblMsg.Style.Add("display", "block");
                    }

                }
            }

            divSimpleSearch.Attributes.Add("style", "display:block");
            DivAdvanceSearch.Attributes.Add("style", "display:none");
        }

        #endregion
    }
}
