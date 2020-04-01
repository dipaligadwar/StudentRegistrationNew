using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Classes;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace StudentRegistration.Eligibility.ElgClasses
{
    public class clsReports
    {
        public DataTable GetFormAReportData(Hashtable oHs)
        {
            DataSet dt = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ElgV2_GetFormAReportData", oHs);
            }

            catch (SqlException ex)
            {
                throw (ex);
            }

            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt.Tables[0];
        }
        public DataSet GetFormBReportData(Hashtable oHs)
        {

            DataSet dt = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ElgV2_GetFormBReportData", oHs);
            }

            catch (SqlException ex)
            {
                throw (ex);
            }

            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }
        public DataSet Get_ProgrameValidity_Report(string uniId,string EXEV_ID)
        {
             Hashtable oHt = null;
            oHt = new Hashtable();
            oHt["UniID"] = uniId.Trim();
            oHt["ExEv_Id"] = EXEV_ID.Trim();
            DataSet dt = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("StudPrograme_Validtity_Report", oHt);
            }

            catch (SqlException ex)
            {
                throw (ex);
            }

            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #region ListEventResultReports
        /// <summary>
        /// List event as per display configuration.
        /// </summary>
        /// <returns></returns>
        public DataTable ListEventResultReports()
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;

            string uniID = Classes.clsGetSettings.UniversityID.Trim();

            Hashtable objHT = new Hashtable();
            objHT.Add("UniID", uniID);

            DataSet ds;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ds = oDB.getparamdataset("SFC_ListExamEvents", objHT);

                return ds.Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion
    }
}