using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Classes;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text;
using System.IO;
using System.Collections;
using System.Configuration;

namespace StudentRegistration
{
    public class clsOthers
    {

        #region Create table to fetch data from excel sheet in database
        public string CreateTable(string FileName, string TableName)
        {
            DataSet TableData = new DataSet();

            DBObjectPool Pool = null;
            DBObject oDB = null;

            Pool = DBObjectPool.Instance;
            oDB = Pool.AcquireDBObject();

            string conn = clsGetSettings.ConnectionString;

            SqlConnection DestCnn = new SqlConnection(conn);
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=Excel 12.0;");

            try
            {
                OleDbDataAdapter oledba = new OleDbDataAdapter("SELECT * FROM [sheet1$]", connection);
                oledba.Fill(TableData);
                System.Data.DataTable tblSchema = TableData.Tables[0].CreateDataReader().GetSchemaTable();
                if (tblSchema.Rows.Count != 0)
                {
                    StringBuilder QCreate = new StringBuilder();

                    QCreate.Append(" IF  EXISTS (SELECT * FROM sys.objects");
                    QCreate.Append(" WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]')");
                    QCreate.Append(" AND type in (N'U'))");
                    QCreate.Append(" DROP TABLE [dbo].[" + TableName + "] ");
                    QCreate.Append(" CREATE TABLE [dbo].[" + TableName + "](");
                    foreach (DataRow dr in tblSchema.Rows)
                    {
                        switch (Convert.ToString(dr["DataType"]))
                        {
                            default:
                                QCreate.Append("[" + dr["ColumnName"].ToString().Trim() + "] varchar(255), ");
                                break;
                        }
                    }

                    string Query = Convert.ToString(QCreate);
                    Query = Query.Remove(Query.LastIndexOf(','));
                    Query = Query + ")";

                    SqlCommand comd = new SqlCommand(Query, DestCnn);
                    if (DestCnn.State == ConnectionState.Closed)
                    {
                        DestCnn.Open();
                    }
                    comd.ExecuteNonQuery();
                    TableData.Clear();
                    oledba.Fill(TableData);
                    SqlBulkCopy sqlcpy = new SqlBulkCopy(DestCnn);
                    sqlcpy.DestinationTableName = "dbo.[" + TableName + "]";
                    sqlcpy.WriteToServer(TableData.Tables[0]);
                    string Result = TableName;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (DestCnn != null)
                    DestCnn.Close();
                FileInfo fi = new FileInfo(FileName);
                if (fi.Exists)
                {
                    fi.Delete();
                }
            }

            return "0";
        }
        #endregion

        #region SavePRNImportSourceTableEntry
        public bool SavePRNImportSourceTableEntry(Hashtable oHs)
        {
            DBObjectPool oPool = null;
            DBObject oDB = null;
            SqlCommand oCmd;
            bool flag = false;

            int iRows = 0;
            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                oCmd = oDB.GenerateCommand("ELGV2_PRN_Import_SourceTable_Entry", oHs);

                iRows = oCmd.ExecuteNonQuery();
                if (iRows > 0)
                    flag = true;
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return flag;
        }
        #endregion

        #region GetImportPRNFromExcelDiscrepancyStatistics
        public DataSet GetImportPRNFromExcelDiscrepancyStatistics(string AcademicYearID, string SourceTableName)
        {
            DBObject oDb = null;
            DBObjectPool pool = null;
            DataSet ds = null;
            Hashtable objHT = new Hashtable();

            objHT.Add("AcademicYearID", AcademicYearID);
            objHT.Add("SourceTableName", SourceTableName);

            try
            {
                pool = DBObjectPool.Instance;
                oDb = pool.AcquireDBObject();
                ds = oDb.getparamdataset("ELGV2_ImportPRNFromExcel_GetDiscrepancyStatistics", objHT);
            }
            catch (Exception ex)
            {
                ds = null;
                throw (ex);
            }
            finally
            {
                if (pool != null)
                {
                    pool.ReleaseDBObject(oDb);
                }
            }
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            else
                return null;
        }
        #endregion

        #region GetImportPRNFromExcelDiscrepancyStudentList
        public DataTable GetImportPRNFromExcelDiscrepancyStudentList(Hashtable objHT)
        {
            DBObject oDb = null;
            DBObjectPool pool = null;
            DataTable dt = null;
            try
            {
                pool = DBObjectPool.Instance;
                oDb = pool.AcquireDBObject();
                dt = oDb.getparamdataset("ELGV2_ImportPRNFromExcel_GetDiscrepancyList", objHT).Tables[0];
            }
            catch (Exception ex)
            {
                dt = null;
                throw (ex);
            }
            finally
            {
                if (pool != null)
                {
                    pool.ReleaseDBObject(oDb);
                }
            }
            if (dt != null && dt.Rows.Count > 0)
                return dt;
            else
                return null;
        }
        #endregion

        #region Cancelling Records

        public string Cancelrecords(string AcademicYearID, string tablename)
        {
            string result;
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable objHT = new Hashtable();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                objHT.Add("AcademicYearID", AcademicYearID);
                objHT.Add("SourceTableName", tablename);
                SqlCommand cmd = oDB.GenerateCommand("ELGV2_ImportPRNFromExcel_DeleteTable", objHT);
                int res = cmd.ExecuteNonQuery();
                result = "Successful";
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return result;
        }

        #endregion

        #region ImportPRNFromExcel

        public int ImportPRNFromExcel(string SourceTableName, string userID)
        {
            string result;
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable objHT = new Hashtable();
            string UniID = clsGetSettings.UniversityID.ToString();
            int Status = 0;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                string DCDatabase = ConfigurationManager.AppSettings["DCDataBase"];//y
                string dbname = (DCDatabase != "") ? DCDatabase.Split('_')[1] : "";//y

                objHT.Add("TableName", SourceTableName);
                objHT.Add("User", userID);
                objHT.Add("ExecutionStatus", Status);  
                objHT.Add("DBName", dbname);//y

                SqlCommand cmd = oDB.GenerateCommand("ELGV2_ImportPRN", objHT);
                cmd.ExecuteNonQuery();
                Status = Convert.ToInt32(cmd.Parameters["@ExecutionStatus"].Value);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return 0;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return Status;
        }

        #endregion


        #region Move Succeeded Table Into WorkDB

        public void MoveSucceededTableIntoWorkDB()
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable objHT = new Hashtable();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                SqlCommand cmd = oDB.GenerateCommand("ELGV2_ImportPRNFromExcel_MoveSucceededTableIntoWorkDB");
                int res = cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                //result = ex.Message;
                throw ex;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
           
        }

        #endregion

        #region Cancel Admission
        //Added to check is cancel admission is allowd at DU Side or not

        public bool Allow_CancelAdmissionAtOASide(Hashtable oHt)
        {
            bool bAllow = false;
            string sReturnData = "N";
            SqlCommand cmd = new SqlCommand();
            oHt.Add("ReturnVal", ParameterDirection.Output);
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject(); 
                //oDB.ThisConnectionFor = DBConnection.DURead;

                cmd = oDB.GenerateCommand("DU_Configuration_Allow_OA_Cancel", oHt);
                cmd.ExecuteNonQuery();
                sReturnData = cmd.Parameters["@ReturnVal"].Value.ToString();
                if (sReturnData == "Y")
                {
                    bAllow = true;
                }
                else
                {
                    bAllow = false;
                }
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

            return bAllow;
        }

        //Added to Log the error while hiting to OA API

        public void WriteOAErrorLog(Hashtable oHt)
        {
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                oDB.ThisConnectionFor = DBConnection.DCWrite;

                cmd = oDB.GenerateCommand("REGD_CancelAdmission_OA_ErrorLog", oHt);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion
    }
}