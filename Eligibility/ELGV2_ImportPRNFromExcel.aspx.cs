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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using Classes;
//using PreExamClstLib.Services;
using Ajax;
//using Classes;
using Microsoft.Reporting.WebForms;
//using StudentRegistration.Classes;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_ImportPRNFromExcel : System.Web.UI.Page
    {
        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                hidFlag.Value = "0";
                FillAcademicYear("0");
                clsOthers oImportFromExcel = new clsOthers();

                //Folllowing code is added to move the imported files source table/s (in ERPS) into Work db
                oImportFromExcel.MoveSucceededTableIntoWorkDB();
            }

        }
        #endregion

        #region Events

        #region btnUploadProceed_Click
        protected void btnUploadProceed_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = this.Server.MapPath(@"..\ImportFromExcelFile");

                if (fileUploadExcel.HasFile)
                {
                    //checking extension
                    if (!(fileUploadExcel.FileName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase) || fileUploadExcel.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase)))
                    {
                        lblFileError.Text = "Invalid File Extension.";
                        return;
                    }
                    //code to upload file.
                    CreateFileInServer(folderPath);
                    //checking if data and columns of Excel are valid
                    string proceed = CheckExcelForValidData(folderPath + "\\" + fileUploadExcel.FileName);
                    if (proceed.Equals(string.Empty))
                    {
                        clsOthers oImportFromExcel = new clsOthers();

                        string SourceTableName = string.Empty;
                        SourceTableName = "ImportPRN_" + String.Format("{0:d_M_yyyy_HH_mm_ss}", System.DateTime.Now);// System.DateTime.Now.ToShortDateString();

                        //SourceTableName = SourceTableName.Replace(':', '_');
                        //SourceTableName = SourceTableName.Replace(':', '_');

                        string message = oImportFromExcel.CreateTable(folderPath + "\\" + fileUploadExcel.FileName, SourceTableName);

                        Hashtable oHt = new Hashtable();
                        oHt.Add("AcademicYearID", hidAcademicYearID.Value);
                        oHt.Add("SourceFileName", fileUploadExcel.FileName);
                        oHt.Add("SourceTableName", SourceTableName);
                        clsUser oUser = (clsUser)Session["user"];
                        oHt.Add("ImportedBy", oUser.User_ID);

                        bool insertTableEntryFlag = oImportFromExcel.SavePRNImportSourceTableEntry(oHt);

                        if (message.Equals("0") && insertTableEntryFlag)
                        {
                            hidSourceFileName.Value = fileUploadExcel.FileName;
                            hidSourceTableName.Value = SourceTableName;
                            divFileUplToHide.Disabled = true;
                            fileUploadExcel.Enabled = false;
                            btnUploadProceed.Enabled = false;
                            ShowDiscrepancyStats();
                        }
                        else
                        {
                            lblFileError.Text = message;
                            lblFileError.CssClass = "errorNote";
                        }

                        oImportFromExcel = null;
                    }
                    else
                    {
                        FileInfo fi = new FileInfo(folderPath + "\\" + fileUploadExcel.FileName);
                        if (fi.Exists)
                        {
                            fi.Delete();
                        }
                        lblFileError.Text = proceed;
                        return;
                    }
                }
                else
                {
                    lblFileError.Text = "Please select valid file";
                    return;
                }
            }
            catch (Exception ex)
            {
                lblFileError.Text = ex.Message;
            }

        }
        #endregion

        #region btnCancel_Click
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clsOthers oImportFromExcel = new clsOthers();
            string result = string.Empty;
            try
            {
                // setVariables();
                result = oImportFromExcel.Cancelrecords(hidAcademicYearID.Value, hidSourceTableName.Value);
                if (result.Equals("Successful"))
                {
                    lblMessage.Text = "Filed Cancelled Successfully.";
                    lblMessage.CssClass = "saveNote";
                    btnConfirm.Enabled = false;
                    // btnGetDetails.Enabled = false;
                    btnCancel.Enabled = false;
                    tblDiscrepancyStats.Visible = false;

                    divFileUplToHide.Disabled = false;
                    fileUploadExcel.Enabled = true;
                    btnUploadProceed.Enabled = true;
                }
                else
                {
                    lblFileError.Text = result;
                    lblFileError.CssClass = "saveNote";
                }
            }
            catch (Exception ex2)
            {
                lblMessage.Text = ex2.Message;
                lblMessage.CssClass = "errorNote";
            }
            if (oImportFromExcel != null) oImportFromExcel = null;

        }
        #endregion

        #region btnConfirm_Click
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            clsOthers oImportFromExcel = new clsOthers();
            string result = string.Empty;
            try
            {
                clsUser oUser = (clsUser)Session["user"];

                int res = oImportFromExcel.ImportPRNFromExcel(hidSourceTableName.Value, oUser.User_ID);
                //int res = 1;

                if (res != 0)
                {
                    lblMessage.Text = "Data Imported Successfully.";
                    lblMessage.CssClass = "saveNote";
                    btnConfirm.Enabled = false;
                    btnCancel.Enabled = false;
                    // btnGetDetails.Enabled = false;
                    //ShowDiscrepancyStats();
                }
                else
                {
                    //tnGetDetails.Enabled = true;
                }

            }
            catch (Exception ex1)
            {
                lblFileError.Text = ex1.Message;
                lblFileError.CssClass = "errorNote";
            }
            if (oImportFromExcel != null) oImportFromExcel = null;
        }
        #endregion

        #region oGvDetails_RowDataBound
        protected void oGvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            HtmlGenericControl div = (HtmlGenericControl)e.Row.FindControl("PopUpList");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (div != null)
                {
                    if (e.Row.Cells[2].Text == "7" && div.InnerText.Trim() == "0")
                    {
                        e.Row.Cells[0].CssClass = "gridstyle";
                        e.Row.Cells[1].CssClass = "gridstyle";
                        e.Row.Cells[0].Font.Bold = true;
                        e.Row.Cells[1].Font.Bold = true;
                        btnConfirm.Enabled = false;
                        divGrvMsg.Style.Add("display", "block");
                    }
                }
                if (e.Row.Cells[2].Text == "1" || e.Row.Cells[2].Text == "2" || e.Row.Cells[2].Text == "3"
                    || e.Row.Cells[2].Text == "4" || e.Row.Cells[2].Text == "5" || e.Row.Cells[2].Text == "6"
                    || e.Row.Cells[2].Text == "7")
                {
                    //e.Row.Cells[0].CssClass = "gridstyle";
                    // e.Row.Cells[1].CssClass = "gridstyle";
                    e.Row.Cells[0].Font.Bold = true;
                    // e.Row.Cells[1].Font.Bold = true;

                    // btnConfirm.Enabled = false;
                    //divGrvMsg.Style.Add("display", "block");

                    // hidFlag.Value = "1";
                }
            }

            //HtmlGenericControl div = (HtmlGenericControl)e.Row.FindControl("PopUpList");

            if (div != null)
            {
                if (div.InnerText.Trim() != "0")
                {
                    div.Attributes.Add("onclick", "return ShowWindow(" + e.Row.Cells[2].Text + ")");
                    div.Attributes.Add("style", "cursor:pointer");
                }
            }
        }
        #endregion

        #endregion

        #region Other Functions

        #region CreateFileInServer
        private void CreateFileInServer(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                fileUploadExcel.SaveAs(folderPath + @"\" + fileUploadExcel.FileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Check Excel For Valid Data and Columns

        private string CheckExcelForValidData(string FileName)
        {
            string exit = string.Empty;
            DataTable dt = new DataTable();
            SqlConnection DestCnn = null;
            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=Excel 12.0;";

            OleDbConnection connection = new OleDbConnection(conString);
            try
            {
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [sheet1$]", connection);
                OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                DataSet TableData = new DataSet();
                ad.Fill(TableData);

                if (TableData.Tables[0].Rows.Count > 0)
                {
                    if (TableData.Tables[0].Columns.Count != 5)
                    {
                        exit += "The number of columns in uploaded Excel should be equal to five.";
                    }
                    else if (TableData.Tables[0].Columns.Count == 5)
                    {
                        //checking if columns equal 2
                        string col1 = TableData.Tables[0].Columns[0].ColumnName.Trim();
                        string col2 = TableData.Tables[0].Columns[1].ColumnName.Trim();
                        string col3 = TableData.Tables[0].Columns[2].ColumnName.Trim();
                        string col4 = TableData.Tables[0].Columns[3].ColumnName.Trim();
                        string col5 = TableData.Tables[0].Columns[4].ColumnName.Trim();

                        //checking if first row is blank
                        if ((col1.Equals("F1") || col2.Equals("F2") || col3.Equals("F3") || col4.Equals("F4") || col5.Equals("F5")))
                        {
                            exit += "The first row of uploaded Excel is blank.";
                        }

                        if (!col1.Equals("Eligibility_Form_Number", StringComparison.OrdinalIgnoreCase))
                        {
                            exit += "The uploaded Excel file has invalid 1st Column Header.";
                        }
                        if (!col2.Equals("Registration_Number", StringComparison.OrdinalIgnoreCase))
                        {
                            exit += "The uploaded Excel file has invalid 2nd Column Header.";
                        }
                        if (!col3.Equals("Student_Name", StringComparison.OrdinalIgnoreCase))
                        {
                            exit += "The uploaded Excel file has invalid 3rd Column Header.";
                        }
                        if (!col4.Equals("Eligibility_Status", StringComparison.OrdinalIgnoreCase))
                        {
                            exit += "The uploaded Excel file has invalid 4th Column Header.";
                        }

                        if (!col5.Equals("Eligibility_Remark", StringComparison.OrdinalIgnoreCase))
                        {
                            exit += "The uploaded Excel file has invalid 5th Column Header.";
                        }

                        for (int i = 0; i < TableData.Tables[0].Rows.Count; i++)
                        {
                            if (!TableData.Tables[0].Rows[0][3].ToString().Equals("E") && !TableData.Tables[0].Rows[0][3].ToString().Equals("P"))
                            {
                                exit += "The Eligibility_Status field contains some invalid values.";
                                break;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                exit += ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (DestCnn != null)
                    DestCnn.Close();
            }
            return exit;
        }

        #region Fill Academic Year
        private void FillAcademicYear(string sAcademicYearID)
        {
            DataTable oDT = new DataTable();
            clsAcademicYear objAcadYear = new clsAcademicYear();
            oDT = objAcadYear.ListAcademicYear();
            ViewState["AcademicYear"] = oDT;
            clsCommon oCommon = new clsCommon();
            oCommon.fillDropDown(ddlAcadYear, oDT, string.Empty, "Year", "pk_AcademicYear_ID", "---- Select ----");

            if (oCommon != null)
            {
                oCommon = null;
            }
            // if (!IsPostBack)

            // SelectItem(ddlAcadYear, sAcademicYearID);
            //if (!string.IsNullOrEmpty(sAcademicYearID))
            //{
            //    //ddlAcadYear.ClearSelection();
            //    ListItem oLi = ddlAcadYear.Items.FindByValue(sAcademicYearID);
            //        if (oLi != null)
            //            oLi.Selected = true;
            //}
        }
        #endregion


        #endregion

        #region Show Discrepancy Statistics

        void ShowDiscrepancyStats()
        {
            clsOthers oImportFromExcel = new clsOthers();
            DataSet oDGetImport = oImportFromExcel.GetImportPRNFromExcelDiscrepancyStatistics(hidAcademicYearID.Value, hidSourceTableName.Value);
            DataTable odt = new DataTable();
            odt.Columns.Add("Section");
            odt.Columns.Add("NoOfRecords");
            odt.Columns.Add("SrNo");
            int i = 0;
            if (oDGetImport != null)
            {
                foreach (DataTable oDataTable in oDGetImport.Tables)
                {
                    if (oDataTable.Rows.Count > 0)
                    {
                        object[] rowData = oDataTable.Rows[0].ItemArray;
                        odt.Rows.Add(odt.NewRow());
                        odt.Rows[i].ItemArray = rowData;
                        i++;
                    }
                }
            }
            if (odt.Rows.Count > 0)
            {
                oGvDetails.DataSource = odt;
                oGvDetails.DataBind();
                tblDiscrepancyStats.Visible = true;

                lblMessage.Text = "";

                if (Convert.ToInt32(odt.Rows[6]["NoOfRecords"].ToString()) > 0)
                {
                    btnConfirm.Enabled = true;
                }
                else
                {
                    btnConfirm.Enabled = false;
                    lblMessage.Text = "No Valid data found for import";
                    //tblDiscrepancyStats.Visible = false;
                    hidFlag.Value = "1";
                    string result = string.Empty;
                    try
                    {
                        // setVariables();
                        //result = oImportFromExcel.Cancelrecords(hidAcademicYearID.Value, hidSourceTableName.Value);
                        if (result.Equals("Successful"))
                        {
                            oGvDetails.Enabled = false;
                            //lblMessage.Text = "Cancelled Successfully.";
                            //lblMessage.CssClass = "saveNote";
                            //btnConfirm.Enabled = false;
                            //// btnGetDetails.Enabled = false;
                            //btnCancel.Enabled = false;
                        }
                        else
                        {
                            //lblFileError.Text = result;
                            //lblFileError.CssClass = "saveNote";
                        }
                    }
                    catch (Exception ex2)
                    {
                        lblMessage.Text = ex2.Message;
                        lblMessage.CssClass = "errorNote";
                    }

                }
            }

            btnCancel.Enabled = true;
            oImportFromExcel = null;
        }

        #endregion

        #region SetVariables
        private void SetVariables()
        {
            hidAcademicYearID.Value = ddlAcadYear.SelectedValue;

        }
        #endregion


        #endregion

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            SetVariables();
            mvImportFromExcel.ActiveViewIndex = 1;
            lblAY.Text = "Selected Academic Year: " + ddlAcadYear.SelectedItem.Text;

        }




    }
}