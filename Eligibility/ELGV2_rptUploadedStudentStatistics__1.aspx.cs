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

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptUploadedStudentStatistics__1 : System.Web.UI.Page
    {
        //int index = 0;
        DataSet Ds = new DataSet();
        DataTable DTSort = new DataTable();
        string strAcademicYrID = "", strAcademicYr1 = "", strAcademicYr2 = "";

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable DT = (DataTable)Session["dtData"];
            if (!IsPostBack)
            {
                ContentPlaceHolder Cntph = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                //hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                hidFacName.Value = ((HtmlInputHidden)Cntph.FindControl("hidFacName")).Value;
                hidCrName.Value = ((HtmlInputHidden)Cntph.FindControl("hidCrName")).Value;
                hidBrName.Value = ((HtmlInputHidden)Cntph.FindControl("hidBrName")).Value;
                hidCrPrDetName.Value = ((HtmlInputHidden)Cntph.FindControl("hidCrPrName")).Value;
                hidCrPrChName.Value = ((HtmlInputHidden)Cntph.FindControl("hidCrPrChName")).Value;
                hidCrPrName.Value = ((HtmlInputHidden)Cntph.FindControl("hidCrPrName")).Value;
            }

            string[] arr = Request.QueryString["AcademicYr"].Split('-');
            string InstIDS = Request.QueryString["InstIds"].ToString();
            strAcademicYrID = arr[0].ToString();
            strAcademicYr1 = arr[1].ToString();
            strAcademicYr2 = arr[2].ToString();

            hid_fk_AcademicYr_ID.Value = strAcademicYrID.ToString();
            hid_strAcademicYr1.Value = strAcademicYr1.ToString();
            hid_strAcademicYr2.Value = strAcademicYr2.ToString();
            hidInstId.Value = InstIDS.ToString();
            hidFacID.Value = Request.QueryString["FacId"].ToString();
            hidCrID.Value = Request.QueryString["CrId"].ToString();
            hidMoLrnID.Value = Request.QueryString["MoLrnId"].ToString();
            hidPtrnID.Value = Request.QueryString["PtrnId"].ToString();
            hidBrnID.Value = Request.QueryString["BrnId"].ToString();
            hidCrPrDetailsID.Value = Request.QueryString["CrPrDetailsId"].ToString();
            hidCrPrChID.Value = Request.QueryString["CrPrChId"].ToString();
            if (Request.QueryString["RCenter"] != null)
            {
                hidRCName.Value = Request.QueryString["RCenter"].ToString();
                hidRCID.Value = Request.QueryString["RCentreID"].ToString();
            }

            //hid_AcademicYear.Value = Request.QueryString["AcademicYrText"].ToString(); 
            if (hidRCID.Value != string.Empty)
            {
                Ds = clsCollegeAdmissionReports.InstListNotUploadedData(Classes.clsGetSettings.UniversityID.ToString(), hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hidCrPrChID.Value, hidRCID.Value);
            }
            else
            {
                Ds = clsCollegeAdmissionReports.InstListNotUploadedData(Classes.clsGetSettings.UniversityID.ToString(), hid_fk_AcademicYr_ID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hidCrPrChID.Value, null);
            }
            lblAcaYear.Text = " " + " [Academic Year " + strAcademicYr1.ToString() + "-" + strAcademicYr2.ToString() + "]";
            lblAcaYear.Style.Add("display", "none");
            lblCrDetails.Text = " for " + hidRCName.Value + " - " + hidFacName.Value + " - " + hidCrName.Value + " - " + hidBrName.Value + " - " + hidCrPrDetName.Value + " - " + hidCrPrChName.Value + " " + lblAcaYear.Text;
            fillGrid();

        }

        #endregion

        #region fillGrid

        private void fillGrid()
        {
            if (ViewState["SortExpression"] == null)
            {
                // Ds= clsCollegeAdmissionReports.InstnameNotUploadedData();
                if (Ds.Tables[0] != null && Ds.Tables[0].Rows.Count > 0)
                {
                    DataView odv = Ds.Tables[0].DefaultView;
                    odv.RowFilter = "NotUploaded_InstID = 0";
                    dgGrid1.DataSource = odv;
                    dgGrid1.DataBind();


                }
                else
                {
                    dgGrid1.Visible = false;
                    //lblMessage.Text = "No record found.";
                    lblMessage.Text = "No college(s) found for whom Student data uploading is not done.";
                    Button2.Visible = false;
                }
            }
            else
            {
                DataView odv = Ds.Tables[0].DefaultView;
                odv.RowFilter = "NotUploaded_InstID = 0";
                //DataView Ddv = new DataView(Ds.Tables[1]);
                odv.Sort = ViewState["SortExpression"].ToString();
                dgGrid1.DataSource = odv;
                dgGrid1.DataBind();

            }

        }

        #endregion

        #region Datagrid related functions

        /* protected void dgGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgGrid.CurrentPageIndex = e.NewPageIndex;
            fillGrid();

        }*/

        /*protected void dgGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.DataSetIndex + 1);

            }


        }*/

        /*protected void dgGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            DTSort = new DataTable();
            DTSort.Reset();

            DTSort = Ds.Tables[2];
            DataView DV = new DataView(DTSort);
            dgGrid.DataSource = DV;

            if (ViewState["SortExpression"] == null)
                ViewState["SortExpression"] = e.SortExpression.ToString();

            if (ViewState["SortExpression"].ToString() == e.SortExpression.ToString())
            {
                DV.Sort = e.SortExpression + " Desc";
                ViewState["SortExpression"] = e.SortExpression + " Desc";
            }
            else
            {
                DV.Sort = e.SortExpression;
                ViewState["SortExpression"] = e.SortExpression;
            }
            dgGrid.DataBind();
        }*/

        #endregion

        #region Button1_Click

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Server.Transfer("rptUploadedStudentStatistics.aspx");
            Server.Transfer("ELGV2_rptUploadedStudentStatistics.aspx?Navigate=back" + "&AcYrName=" + strAcademicYr1.ToString() + "-" + strAcademicYr2.ToString() + "&InstIDS=" + hidInstId.Value + "&AcYrId=" + hid_fk_AcademicYr_ID.Value + "&FacId=" + hidFacID.Value + "&CrId=" + hidCrID.Value + "&MoLrnId=" + hidMoLrnID.Value + "&PtrnId=" + hidPtrnID.Value + "&BrnId=" + Convert.ToString(Session["BranchID"]) + "&CrPrDetailsId=" + Convert.ToString(Session["pk_CrPr_Details_ID"]) + "&CrPrChId=" + Convert.ToString(Session["pk_CrPrCh_ID"]));//+"-"+hid_fk_AcademicYr_ID.Value);
            //Server.Transfer("ELGV2rptUploadedStudentStatistics_Test.aspx?Navigate=back" + "&InstIDS=" + hidInstId.Value);//+"-"+hid_fk_AcademicYr_ID.Value);
        }

        #endregion

        #region GridView Events

        protected void dgGrid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgGrid1.PageIndex = e.NewPageIndex;
            fillGrid();
        }

        protected void dgGrid1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DTSort = new DataTable();
            DTSort.Reset();
           
            DTSort = Ds.Tables[0];
            DataView DV = new DataView(DTSort);
            DV.RowFilter = "NotUploaded_InstID = 0";
            dgGrid1.DataSource = DV;

            if (ViewState["SortExpression"] == null)
                ViewState["SortExpression"] = e.SortExpression.ToString();

            if (ViewState["SortExpression"].ToString() == e.SortExpression.ToString())
            {
                DV.Sort = e.SortExpression + " Desc";
                ViewState["SortExpression"] = e.SortExpression + " Desc";
            }
            else
            {
                DV.Sort = e.SortExpression;
                ViewState["SortExpression"] = e.SortExpression;
            }
            dgGrid1.DataBind();
        }


        #endregion

    }
}
