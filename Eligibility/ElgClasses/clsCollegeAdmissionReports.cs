using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Classes;
using System.Data.SqlClient;
using System.Collections;


namespace StudentRegistration.Eligibility.ElgClasses
{
    public class clsCollegeAdmissionReports
    {
        public clsCollegeAdmissionReports()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// This function is used to get the Statistics of Course wise Uploaded students at University  for Selected Institutes
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable instWiseCourseWiseUpStudentStatistics(string fk_AcademicYear_ID, string InstIds)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            //DataTable DT = new DataTable();
            //DBObjectPool Pool = null;
            //DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("InstID", InstIds);

                dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetails", ht).Tables[0];
                // dt = oDB.getdataset("REPV2_GetInvoiceAndEligibilityDetails",ht).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        /// <summary>
        /// This function is used to get the Statistics of Course wise Uploaded students at University  for All Institutes
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable instWiseCourseWiseUpStudentStatisticsforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            //DataTable DT = new DataTable();
            //DBObjectPool Pool = null;
            //DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);

                dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes", ht).Tables[0];
                //  dt = oDB.getdataset("REPV2_GetInvoiceAndEligibilityDetails",ht).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        public static DataSet InstnameNotUploadedData(string UniID,string fk_AcademicYear_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID, string RegCentreID)
        {
            Hashtable HT = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                HT.Add("UniID", UniID);
                HT.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                HT.Add("FacID", FacID);
                HT.Add("CrID", CrID);
                HT.Add("MoLrnID", MoLrnID);
                HT.Add("PtrnID", PtrnID);
                HT.Add("BrnID", BrnID);
                HT.Add("CrPrDetailsID", CrPrDetailsID);
                HT.Add("CrPrChID", CrPrChID);
                HT.Add("RegCentreID", RegCentreID);
                DS = oDB.getparamdataset("REPV2_Du_UploadStatistics_GetCount_InstName", HT);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return DS;
        }

        public static DataSet InstListNotUploadedData(string UniID, string fk_AcademicYear_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID, string RegCentreID)
        {
            Hashtable HT = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                HT.Add("UniID", UniID);
                HT.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                HT.Add("FacID", FacID);
                HT.Add("CrID", CrID);
                HT.Add("MoLrnID", MoLrnID);
                HT.Add("PtrnID", PtrnID);
                HT.Add("BrnID", BrnID);
                HT.Add("CrPrDetailsID", CrPrDetailsID);
                HT.Add("CrPrChID", CrPrChID);
                HT.Add("RegCentreID", RegCentreID);
                DS = oDB.getparamdataset("REPV2_Du_UploadStatisticsNotUploaded_InstDetails", HT);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return DS;
        }
        
        #region Fill Academic Year
        public static DataTable GetAcademicYear()
        {
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;

                oDB = Pool.AcquireDBObject();

                dt = oDB.getdataset("Gen_ListAllAcademicYear").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }
        #endregion

        #region Total Uploaded Data
        public static DataTable TotalUploadedDataforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                // MySQL related change - SP name should be having less than 64 characters
                //dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_uploaded_data", ht).Tables[0];
                dt = oDB.getparamdataset("REPV2_GetInvAndEligibilityDetForAllInst_Uploaded_Data", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total Intake Capacity

        public static DataTable TotalIntakeCapacityforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                // MySQL related change - SP name should be having less than 64 characters
                //dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_IntakeCapacity", ht).Tables[0];
                dt = oDB.getparamdataset("REPV2_GetInvAndEligibilityDetForAllInst_IntakeCapacity", ht).Tables[0];


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total Invoice Generated
        public static DataTable TotalInvoiceGeneratedforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                // MySQL related change - SP name should be having less than 64 characters
                //dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_InvoiceGenerated", ht).Tables[0];
                dt = oDB.getparamdataset("REPV2_GetInvAndEligibilityDetForAllInst_InvoiceGenerated", ht).Tables[0];


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total Invoice Processed
        public static DataTable TotalInvoiceProcessedforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);

                dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_InvoiceProcessed", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total Invoice not processed
        public static DataTable TotalInvoicenotprocessedforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                // MySQL related change - SP name should be having less than 64 characters
                //dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_InvoiceNotProcessed", ht).Tables[0];
                dt = oDB.getparamdataset("REPV2_GetInvAndEligibilityDetForAllInst_InvoiceNotProcessed", ht).Tables[0];


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total EligibilityProcessed
        public static DataTable TotalEligibilityProcessedforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                // MySQL related change - SP name should be having less than 64 characters
                //dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_Eligiblity_processed", ht).Tables[0];
                dt = oDB.getparamdataset("REPV2_GetInvAndEligibilityDetForAllInst_Eligiblity_Processed", ht).Tables[0];


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total Eligiblity not processed
        public static DataTable TotalEligiblitynotprocessedforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                // MySQL related change - SP name should be having less than 64 characters
                //dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_Eligiblity_not_processed", ht).Tables[0];
                dt = oDB.getparamdataset("REPV2_GetInvAndEligibilityDetForAllInst_Eligiblity_Not_Processed", ht).Tables[0];


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total Eligible
        public static DataTable TotalEligibleforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);

                dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_Eligible", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total Not Eligible
        public static DataTable TotalNotEligibleforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                // MySQL related change - SP name should be having less than 64 characters
                //dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_Not_Eligible", ht).Tables[0];
                dt = oDB.getparamdataset("REPV2_GetInvAndEligibilityDetForAllInst_Not_Eligible", ht).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total Pending
        public static DataTable TotalPendingforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);

                dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_Pending", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total Provisional
        public static DataTable TotalProvisionalforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                // MySQL related change - SP name should be having less than 64 characters
                //dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_Provisional", ht).Tables[0];
                dt = oDB.getparamdataset("REPV2_GetInvAndEligibilityDetForAllInst_Provisional", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total SMS Count
        /*
        public static DataTable TotalSMSCountforAllInstitutes(string fk_AcademicYear_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);

                dt = oDB.getparamdataset("REPV2_GetInvoiceAndEligibilityDetailsforAllInstitutes_SMS_Count", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }
        */
        #endregion

        #region Total Uploaded Data
        public static DataTable REPV2_AllInstitutes_uploaded_data(string fk_AcademicYear_ID, string RegCentreID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("RegCentreID", RegCentreID);
                dt = oDB.getparamdataset("REPV2_AllInstitutes_uploaded_data", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Total Uploaded Data
        public static DataTable REPV2_AllInstitutes_uploaded_dataLessThanOneYear(string fk_AcademicYear_ID, string RegCentreID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("RegCentreID", RegCentreID);
                dt = oDB.getparamdataset("REPV2_AllInstitutes_CrPrwiseuploadeddata_LessThanOneYear", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Selected College Report Outer Grid

        public static DataTable FetchSelectedCollegeOuterReport(string fk_AcademicYear_ID, string InstID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("InstID", InstID);

                dt = oDB.getparamdataset("REPV2_GetUploadedStatisticsForSelectedCollege", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        #endregion

        #region Selected College Report Inner Grid

        public static DataTable FetchSelectedCollegeInnerReport(string fk_AcademicYear_ID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("InstID", InstID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("CrPrChID", CrPrChID);

                dt = oDB.getparamdataset("REPV2_GetUploadedStatisticsForSelectedCollegeDetails", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        #endregion

        #region All Colleges Report Inner Grid

        public static DataTable FetchAllCollegesInnerReport(string fk_AcademicYear_ID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("InstID", InstID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("CrPrChID", CrPrChID);

                dt = oDB.getparamdataset("[REPV2_GetUploadedStatisticsForAllCollegeDetails]", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        #endregion

        #region All Colleges Report Outer Grid

        public static DataTable FetchAllCollegesOuterReport(string fk_AcademicYear_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID, string RegCentreID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("CrPrChID", CrPrChID);
                ht.Add("RegCentreID", RegCentreID);
                dt = oDB.getparamdataset("REPV2_GetUploadedStatisticsForAllColleges", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        #endregion

        #region Combined DataTable for Excel Export -All Colleges

        public static DataTable FetchExcelReportAllColleges(string fk_AcademicYear_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID, string RegCentreID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                // ht.Add("InstID", InstID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("CrPrChID", CrPrChID);
                ht.Add("RegCentreID", RegCentreID);

                dt = oDB.getparamdataset("REPV2_GetUploadedStatisticsForAllColleges_ExportToExcel", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        #endregion

        #region Combined DataTable for Excel Export - Selected College

        public static DataTable FetchExcelReportSelectedCollege(string fk_AcademicYear_ID, string InstID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("InstID", InstID);

                dt = oDB.getparamdataset("REPV2_GetUploadedStatisticsForSelectedCollege_ExportToExcel", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                dt.Dispose();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        #endregion

        #region Fill Discrepancy Report

        public static DataTable FillDiscrepancyReport(string fk_AcademicYear_ID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID, string RegCentreID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("CrPrChID", CrPrChID);
                ht.Add("InstID", InstID);
                ht.Add("RegCentreID", RegCentreID);

                dt = oDB.getparamdataset("REPV2_DiscrepancyCountForAllColleges", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        #endregion

        #region Fill Discrepancy Report Student Details

        public static DataTable FillDiscrepancyReportStudentDetails(string fk_AcademicYear_ID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("CrPrChID", CrPrChID);
                ht.Add("InstID", InstID);

                dt = oDB.getparamdataset("REPV2_DiscrepantStudentDetails", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        #endregion

        #region Fill Discrepancy Report Selected College

        public static DataTable FillDiscrepancyReportSelectedCollege(string fk_AcademicYear_ID, string InstID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("InstID", InstID);

                dt = oDB.getparamdataset("REPV2_GetDiscrepancyCountForSelectedCollege", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        #endregion

        #region Fill MIS Report All Colleges All Courses

        public static DataTable FillMISReportAll(string fk_AcademicYear_ID, string RegCentreID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("RegCentreID", RegCentreID);


                dt = oDB.getparamdataset("REPV2_GetUploadedStatisticsForAllCollegesAllCourses", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        #endregion

        #region Fill MIS Report Selected College All Courses

        public static DataTable FillMISReportSelected(string fk_AcademicYear_ID, string InstID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("InstID", InstID);

                dt = oDB.getparamdataset("REPV2_GetUploadedStatisticsForSelectedCollegeAllCourses", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        #endregion

        #region Methods for Paper Exemption Approval

        //1. Method to get paperwise Student count based on selected course
        public static DataTable ListStudentCountForPaperExemptionApprovalSelectedCourse(string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {

                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("CrPrChID", CrPrChID);

                dt = oDB.getparamdataset("ELGV2_ListStudentCountForPaperExemptionApprovalSelectedCourse", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }
        //--------------------------------------------------------------------------------------------------------------


        //2. Method to get paperwise Student count based on selected college
        public static DataTable ListStudentCountForPaperExemptionApprovalSelectedCollege(string InstID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("InstID", InstID);

                dt = oDB.getparamdataset("ELGV2_ListStudentCountForPaperExemptionApprovalSelectedCollege", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }
        //--------------------------------------------------------------------------------------------------------------


        //3. Method to list distinct TLM-AM-AT
        public static DataTable PaperExemptionFetchdistinctTLMAMAT(string pk_Pp_PpHead_CrPrCh_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Pp_PpHead_CrPrCh_ID", pk_Pp_PpHead_CrPrCh_ID);

                dt = oDB.getparamdataset("ELGV2_PaperExemptionFetchdistinctTLMAMAT", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }
        //--------------------------------------------------------------------------------------------------------------


        //4. Method to list student details
        public static DataTable PaperExemptionFetchStudentDetails(string pk_Pp_PpHead_CrPrCh_ID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID, string TchLrnMthID, string AssMthdID, string AssTypeID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {

                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                ht.Add("pk_Pp_PpHead_CrPrCh_ID", pk_Pp_PpHead_CrPrCh_ID);
                ht.Add("InstID", InstID);
                //ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("CrPrChID", CrPrChID);
                ht.Add("pk_TchLrnMth_ID", TchLrnMthID);
                ht.Add("pk_AssMth_ID", AssMthdID);
                ht.Add("pk_AssType_ID", AssTypeID);
                dt = oDB.getparamdataset("ELGV2_PaperExemptionFetchStudentDetails", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        //5. Method to approve or deny exemption claim
        public static int PaperExemptionApproveOrDeny(string userid, int approveOrDeny, string oPaperStudXMLList)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            int TFlag;
            try
            {

                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                ht.Add("userid", userid);
                ht.Add("approveordeny", approveOrDeny);
                SqlCommand cmd = new SqlCommand();
                cmd = oDB.GenerateCommand("ELGV2_PaperExemptionApproveOrDeny", ht);
                cmd.Parameters.RemoveAt("@PaperXML");
                cmd.Parameters.Add("@PaperXML", SqlDbType.Xml);
                cmd.Parameters["@PaperXML"].Value = oPaperStudXMLList;
                cmd.ExecuteNonQuery();
                TFlag = Convert.ToInt32(cmd.Parameters["@ReturnFlag"].Value.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return TFlag;
        }
        //--------------------------------------------------------------------------------------------------------------

        //6. Method to list papers of selected student - Simple Search
        public static DataTable FetchPaperTLMAMATForSimpleStudentSearch(string UniID, string YearID, string StudentID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            int TFlag;
            try
            {

                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("UniID", UniID);
                ht.Add("YearID", YearID);
                ht.Add("StudentID", StudentID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("CrPrChID", CrPrChID);

                dt = oDB.getparamdataset("ELGV2_FetchPaperTLMAMATForSimpleStudentSearch", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //6. Method which returns a DataTable containing Course Part Terms for a given Student PRN/ Eligibility form no.
        public static DataTable ListStudentwiseCrPrTerms_ExemptionApproval(string PRN, string RefUniID, string RefInstID, string RefYearID, string RefStudentID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("PRN", PRN);
                ht.Add("RefUniID", RefUniID);
                ht.Add("RefInstID", RefInstID);
                ht.Add("RefYearID", RefYearID);
                ht.Add("RefStudentID", RefStudentID);

                dt = oDB.getparamdataset("ELGV2_StudentwiseCrPrTerms_ExemptionApproval", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Methods for Paper Exemption Claim

        //1. Method which returns a DataTable containing Course Part Terms for a given Student PRN/ Eligibility form no.
        public static DataTable ListStudentwiseCrPrTerms_ExemptionClaim(string PRN, string RefUniID, string RefInstID, string RefYearID, string RefStudentID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("PRN", PRN);
                ht.Add("RefUniID", RefUniID);
                ht.Add("RefInstID", RefInstID);
                ht.Add("RefYearID", RefYearID);
                ht.Add("RefStudentID", RefStudentID);
                dt = oDB.getparamdataset("ELGV2_StudentwiseCrPrTerms_ExemptionClaim", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }
        //--------------------------------------------------------------------------------------------------------------


        //2. Method which returns two DataTables 
        //   i) which contains already claimed paper TLM-AM-ATs for a Course Part Term
        //   ii) which contains papers which can be claimed
        public static DataSet ListCrPrTermwisePapers_ExemptionClaim(string UniID, string YearID, string StudentID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID)
        {

            DataSet ds;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("UniID", UniID);
                ht.Add("YearID", YearID);
                ht.Add("StudentID", StudentID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("CrPrChID", CrPrChID);

                ds = oDB.getparamdataset("ELGV2_CrPrTermwisePapers_ExemptionClaim", ht);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return ds;

        }
        //--------------------------------------------------------------------------------------------------------------


        //3. Method to claim exemption for selected papers
        public static int ClaimExemptionForSelectedPapers(string UniID, string YearID, string StudentID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID, string PpPpHeadCrPrChIDList, string userid)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            int i;
            Hashtable oHs = new Hashtable();
            SqlCommand cmd;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                oHs.Add("UniID", UniID);
                oHs.Add("YearID", YearID);
                oHs.Add("StudentID", StudentID);
                oHs.Add("FacID", FacID);
                oHs.Add("CrID", CrID);
                oHs.Add("MoLrnID", MoLrnID);
                oHs.Add("PtrnID", PtrnID);
                oHs.Add("BrnID", BrnID);
                oHs.Add("CrPrDetailsID", CrPrDetailsID);
                oHs.Add("CrPrChID", CrPrChID);
                oHs.Add("PpPpHeadCrPrChIDList", PpPpHeadCrPrChIDList);
                oHs.Add("userid", userid);

                cmd = oDB.GenerateCommand("ELGV2_ClaimExemptionForSelectedPapers", oHs);

                i = cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return i;
        }


        #endregion

        #region Methods for Paper Exemption Decision Change

        //1. Method which returns a DataTable containing Course Part Terms for a given Student PRN/ Eligibility form no.
        public static DataTable ListStudentwiseCrPrTerms_ChangeExemptionDecision(string PRN, string RefUniID, string RefInstID, string RefYearID, string RefStudentID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("PRN", PRN);
                ht.Add("RefUniID", RefUniID);
                ht.Add("RefInstID", RefInstID);
                ht.Add("RefYearID", RefYearID);
                ht.Add("RefStudentID", RefStudentID);

                dt = oDB.getparamdataset("ELGV2_StudentwiseCrPrTerms_ChangeExemptionDecision", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        //2. Method which returns a DataTable containing paper TLM-AM-ATs for a Course Part Term for which exemption approval decision has already been taken
        public static DataTable ListCrPrTermwisePapers_ChangeExemptionDecision(string UniID, string YearID, string StudentID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID)
        {
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable dt;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("UniID", UniID);
                ht.Add("YearID", YearID);
                ht.Add("StudentID", StudentID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("CrPrChID", CrPrChID);

                dt = oDB.getparamdataset("ELGV2_CrPrTermwisePapers_ChangeExemptionDecision", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;

        }

        //3. Method to change exemption approval decision for selected papers
        public static int ChangeExemptionDecisionForSelectedPapers(string userid, string oPaperStudXMLList)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            int TFlag;
            Hashtable ht = new Hashtable();
            SqlCommand cmd;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                ht.Add("userid", userid);
                cmd = oDB.GenerateCommand("ELGV2_ChangeExemptionDecisionForSelectedPapers", ht);
                cmd.Parameters.RemoveAt("@PaperXML");
                cmd.Parameters.Add("@PaperXML", SqlDbType.Xml);
                cmd.Parameters["@PaperXML"].Value = oPaperStudXMLList;
                cmd.ExecuteNonQuery();
                TFlag = Convert.ToInt32(cmd.Parameters["@ReturnFlag"].Value.ToString());

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return TFlag;
        }

        #endregion

        #region Paper Exemption Reports

        //to fill outer college wise report
        public static DataTable FillCollWisePaperExemptionOuterReport(string pk_Uni_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);

                dt = oDB.getparamdataset("REPV2_GetCollegeWiseCounts_PaperExemptionReport", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        //to fill report for course wise count of a college
        public static DataTable FillCollWisePaperExemptionInnerReport(string pk_Uni_ID, string pk_Inst_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                ht.Add("pk_Inst_ID", pk_Inst_ID);

                dt = oDB.getparamdataset("REPV2_GetCoursewisePaperExemptionCoursesStatistics", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        //to fill count for college wise course wise counts of a paper tlm am at
        public static DataTable FillCollWisePaperExemptionSubInnerReport(string pk_Uni_ID, string pk_Fac_ID, string pk_Cr_ID,
             string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPr_Details_ID, string pk_CrPrCh_ID, string pk_Inst_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ht.Add("pk_CrPr_Details_ID", pk_CrPr_Details_ID);
                ht.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                ht.Add("pk_Inst_ID", pk_Inst_ID);

                dt = oDB.getparamdataset("REPV2_GetCoursewisePaperExemptionPapersStatistics", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }



        // Report Fill PaperExemption Counts(Pending, Granted, Denied) All Courses
        public static DataTable FillPaperExemptionReportCoursewise(string pk_Uni_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);


                dt = oDB.getparamdataset("REPV2_GetCoursewisePaperExemptionCoursesStatistics", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        // Report Fill PaperExemption Counts(Pending, Granted, Denied) Selected Course all Paper TLM AM ATs
        public static DataTable FillPaperExemptionReportPaperTLMAMATWise(string pk_Uni_ID, string pk_Fac_ID, string pk_Cr_ID,
            string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPr_Details_ID, string pk_CrPrCh_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ht.Add("pk_CrPr_Details_ID", pk_CrPr_Details_ID);
                ht.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                dt = oDB.getparamdataset("REPV2_GetCoursewisePaperExemptionPapersStatistics", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        // Fetch Student List for selected Paper TLM AM AT in Coll Wise Report
        public static DataTable FillStudentListPaperExemptionReportCollegeWise(string pk_Pp_PpHead_CrPrCh_ID, string pk_TchLrnMth_ID, string pk_AssMth_ID,
           string pk_AssType_ID, string pk_Inst_ID)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Pp_PpHead_CrPrCh_ID", pk_Pp_PpHead_CrPrCh_ID);
                ht.Add("pk_TchLrnMth_ID", pk_TchLrnMth_ID);
                ht.Add("pk_AssMth_ID", pk_AssMth_ID);
                ht.Add("pk_AssType_ID", pk_AssType_ID);
                ht.Add("pk_Inst_ID", pk_Inst_ID);

                dt = oDB.getparamdataset("REPV2_GetCollegeWiseCourseWisePaperWiseStudentList", ht).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }


        //1. Method which returns a DataTable containing Course Part Terms for a given Student PRN/ Eligibility form no.
        public static DataSet FillPaperExemptionStudentStatus(string PRN, string RefUniID, string RefInstID, string RefYearID, string RefStudentID)
        {
            DataSet ds;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("PRN", PRN);
                ht.Add("RefUniID", RefUniID);
                ht.Add("RefInstID", RefInstID);
                ht.Add("RefYearID", RefYearID);
                ht.Add("RefStudentID", RefStudentID);

                ds = oDB.getparamdataset("REPV2_GetPaperExemptionStudentStatus", ht);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return ds;
        }


        #endregion

        #region District Wise Uploaded Student Counts

        public static DataTable FillDistrictWiseUploadedStudentCountsReport(string fk_AcademicYear_ID)
        {
            DataSet ds;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);

                ds = oDB.getparamdataset("REPV2_DistrictWiseUploadedStudentCounts", ht);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return ds.Tables[0];
        }

        #endregion

        #region District Wise Uploaded Student Counts

        public static DataTable FillCrPrTrWiseUploadedElgStudentCountsReport(string fk_AcademicYear_ID)
        {
            DataSet ds;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("AcademicYear_ID", fk_AcademicYear_ID);

                ds = oDB.getparamdataset("REPV2_GetUploadedStatisticsAllCrPrTermwise", ht);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return ds.Tables[0];
        }

        #endregion

        #region StudentDetails With PaperChange
        internal DataTable ListStudentDetailsWithPaperChangeSimpleSearch(Hashtable oHT)
        {
            DataTable oDt = null;
            DBObjectPool pool = null;
            DBObject oDb = null;

            try
            {
                pool = DBObjectPool.Instance;
                oDb = pool.AcquireDBObject();
                oDt = oDb.getparamdataset("Repv2_StudentDetailsWithPaperChangeSimpleSearch", oHT).Tables[0];
            }
            finally
            {
                pool.ReleaseDBObject(oDb);
            }

            return (oDt);
        }
        #endregion


        #region StudentDetails With PaperChange
        internal DataTable ListStudentDetailsWithPaperChangeAdvSearch(Hashtable oHT)
        {
            DataTable oDt = null;
            DBObjectPool pool = null;
            DBObject oDb = null;

            try
            {
                pool = DBObjectPool.Instance;
                oDb = pool.AcquireDBObject();
                oDt = oDb.getparamdataset("Repv2_StudentDetailsWithPaperChangeAdvSearch", oHT).Tables[0];
            }
            finally
            {
                pool.ReleaseDBObject(oDb);
            }

            return (oDt);
        }
        #endregion

        public DataTable ListExamEvents()
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable DT = null;
            Hashtable oHs = new Hashtable();
            oHs["pk_Uni_ID"] = clsGetSettings.UniversityID.ToString();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                DT = oDB.getparamdataset("ElgV2_ListExamEvent", oHs).Tables[0];
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return DT;
        }

        public DataTable ListStudentwiseCrPrTerms_ChangeEligStatus(Hashtable oht)
        {
            DBObject oDB = null;
            DBObjectPool Pool = null;
            DataTable DT = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                DT = oDB.getparamdataset("ELGV2_ListStudentwiseCrPrTerms_ChangeEligibilityStatus", oht).Tables[0];
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return DT;

            }

        public DataTable ListStudentDetails_ChangeEligStatus(Hashtable oht)
        {
            DBObject oDB = null;
            DBObjectPool Pool = null;
            DataTable DT = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                DT = oDB.getparamdataset("ELGV2_ListStudentDetails_ChangeEligibilityStatus",oht).Tables[0];
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return DT;
        }

        }

    }

