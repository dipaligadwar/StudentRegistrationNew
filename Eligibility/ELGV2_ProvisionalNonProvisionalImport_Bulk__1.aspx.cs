using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Classes;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using StudentRegistration.Eligibility.ElgClasses;
using System.IO;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_ProvisionalNonProvisionalImport_Bulk__1 : System.Web.UI.Page
    {
        #region Declaration of Variables

        clsCommon Common = new clsCommon();
        InstituteRepository InstRep = new InstituteRepository();
        clsUser user;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsUser)Session["user"];
            if (!IsPostBack)
            {
                ContentPlaceHolder Cntph1 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                HtmlInputHidden[] hid = new HtmlInputHidden[9];
                hid[0] = hidUniID;
                hid[1] = hidFacID;
                hid[2] = hidCrID;
                hid[3] = hidMoLrnID;
                hid[4] = hidPtrnID;
                hid[5] = hidBrnID;
                hid[6] = hidCrPrDetailsID;
                hid[7] = hidCrPrChID;
                hid[8] = hid_fk_AcademicYr_ID;

                Common.setHiddenVariablesMPC(ref hid);

                lblPageHead.Text = "Provisional Non Provisional Bulk Importing";
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            string folderPath = this.Server.MapPath(@"..\Eligibility\TempDirectory");
            try
            {
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


                        clsEligibilityRights oImportFromExcel = new clsEligibilityRights();
                        //string IsExists = string.Empty;
                        string result = string.Empty;
                        //IsExists = oImportFromExcel.CheckTableExists("Prov_Src_" + hidUniID.Value + hidFacID.Value + hidCrID.Value + hidMoLrnID.Value + hidPtrnID.Value + hidBrnID.Value + hidCrPrDetailsID.Value + hidCrPrChID.Value);
                        //if (IsExists.Equals("Successful"))
                        //{
                        string tablename = string.Empty;
                        tablename = "Prov_Src_" + hidUniID.Value + "_" + hidFacID.Value + "_" + hidCrID.Value + "_" + hidMoLrnID.Value + "_" + hidPtrnID.Value + "_" + hidBrnID.Value + "_" + hidCrPrDetailsID.Value + "_" + hidCrPrChID.Value + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss");
                        
                        string message = oImportFromExcel.CreateTable(folderPath + "\\" + fileUploadExcel.FileName, tablename.Trim());
                        if (message.Equals("0"))
                        {
                            result = oImportFromExcel.ConfirmProvisionalANDNonProvisionalEligibilityfromExcel(tablename.Trim(), hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value, hidCrPrChID.Value, user.User_ID, hid_fk_AcademicYr_ID.Value, rbtCriteria.SelectedValue);
                            if (result.Equals("Successful"))
                            {
                                lblFileError.Text = "Data updated successfully.";
                                lblFileError.CssClass = "saveNote";
                            }
                        }
                        else
                        {
                            lblFileError.Text = message;
                            lblFileError.CssClass = "errorNote";
                        }
                        //}

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
                    string script = "<script language='javascript'>alert('Please select proper file for Importing data.')</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopUp", script);
                }
            }
            catch (Exception ex)
            {
                lblFileError.Text = "Error in " + ex.Message;
            }
            finally
            {
            }
        }

        #region CreateFileInServer
        private void CreateFileInServer(string folderPath)
        {
            try
            {
                fileUploadExcel.SaveAs(folderPath + @"\" + fileUploadExcel.FileName);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Check Excel For Valid Data and Columns

        private string CheckExcelForValidData(string FileName)
        {
            string exit = string.Empty;
            //ImportFromExcel importFromExcel = new ImportFromExcel();

            DataSet TableData = new DataSet();
            SqlConnection DestCnn = null;//new SqlConnection(clsConnection.getConnectionString());
            string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=Excel 12.0;";
            //string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR= Yes;\"";
            OleDbConnection connection = new OleDbConnection(conString);
            OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT * FROM [sheet1$]", connection);
            OleDbDataAdapter ad = new OleDbDataAdapter(cmd);

            try
            {
                ad.Fill(TableData);

                if (TableData.Tables[0].Rows.Count > 0)
                {
                    //checking if columns equal 2
                    string PRN_col1 = TableData.Tables[0].Columns[0].ColumnName.Trim();
                    string Remark_col2 = TableData.Tables[0].Columns[1].ColumnName.Trim();


                    //checking if first row is blank
                    if ((PRN_col1.Equals("F1") || Remark_col2.Equals("F2")))
                    {
                        exit += "The first row of uploaded Excel is blank.";
                    }

                    //checking columns headers

                    if (!PRN_col1.Equals("PRN", StringComparison.OrdinalIgnoreCase))
                    {
                        exit += "The uploaded Excel file has invalid 1st Column Header.";
                    }

                    if (!Remark_col2.Equals("Remarks", StringComparison.OrdinalIgnoreCase))
                    {
                        exit += "The uploaded Excel file has invalid 2nd Column Header.";

                    }
                    //if (!importFromExcel.IsValidInvalidMarks(TableData.Tables[0]))
                    //{
                    //    exit += "The uploaded Excel file has invalid characters in marks column.";
                    //}
                }

            }
            catch (Exception ex)
            {
                exit += ex.Message;
            }
            finally
            {
                ad.Dispose();
                cmd.Dispose();

                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
                if (DestCnn != null)
                {
                    DestCnn.Close();
                }

                if (TableData != null)
                {
                    TableData.Dispose();
                }
            }
            return exit;
        }

        #endregion
    }
}