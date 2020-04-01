using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace Classes
{  
    public class clsAdmissionElgConfig
    {
        public enum ResultStatus { Pass = 1, Absent = 5, ATKT = 2, Fail = 3 };
        internal DataTable GetCoursesForAdmissionElgConfigurations(Hashtable oHs)
        {
            DataTable oDt = null;
            DBObjectPool pool = null;
            DBObject oDb = null;

            try
            {
                pool = DBObjectPool.Instance;
                oDb = pool.AcquireDBObject();
                oDt = oDb.getparamdataset("ELGV2_GetCoursesForAdmissionElgConfigurations", oHs).Tables[0];
            }
            finally
            {
                pool.ReleaseDBObject(oDb);
            }

            return (oDt);
        }

        internal DataTable GetAdmissionElgConfigurationsForCourse(Hashtable oHs)
        {
            DataTable oDt = null;
            DBObjectPool pool = null;
            DBObject oDb = null;

            try
            {
                pool = DBObjectPool.Instance;
                oDb = pool.AcquireDBObject();
                oDt = oDb.getparamdataset("ELGV2_GetAdmissionElgConfigurationsForCourse", oHs).Tables[0];
            }
            finally
            {
                pool.ReleaseDBObject(oDb);
            }

            return (oDt);
        }

        


        internal string[] SaveAdmissionElgConfigurationsForCourse(Hashtable oHs)
        {
            DBObjectPool oPool = null;
            DBObject oDB = null;
            SqlCommand oCmd;
            string[] sRes = new string[3];

            int iRows = 0;
            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();

                oCmd = oDB.GenerateCommand("ELGV2_SaveAdmissionElgConfigurationsForCourse", oHs);
                iRows = oCmd.ExecuteNonQuery();
                sRes[0] = oCmd.Parameters["@Status"].Value.ToString();
                sRes[1] = oCmd.Parameters["@PartorTermStatus"].Value.ToString();
                sRes[2] = oCmd.Parameters["@ConfiguredPartOrTerm"].Value.ToString();
                
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return sRes;
        }


        public DataTable GetCoursePartTermForAdmissionElg(Hashtable oHT)
        {
            DataTable oDT = null;
            DBObjectPool oPool = null;
            DBObject oDB = null;

            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                oDT = oDB.getparamdataset("ELGV2_GetCoursePartTermForAdmissionElg", oHT).Tables[0];
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return (oDT);
        }

        public DataTable GetCoursePartForAdmissionElg(Hashtable oHT)
        {
            DataTable oDT = null;
            DBObjectPool oPool = null;
            DBObject oDB = null;

            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                // MySQL related change - SP name should be having less than 64 characters
                //oDT = oDB.getparamdataset("Elgv2_ListCourseModeOfLearningPatternBrnWiseLaunchedCoursePartList", oHT).Tables[0];
                oDT = oDB.getparamdataset("Elgv2_ListCrMoLrnPatternBrnWiseLaunchedCoursePartList", oHT).Tables[0];

            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return (oDT);
        }

        internal string[] IsPreviousConfigurationExists(Hashtable oHs)
        {
            DBObjectPool oPool = null;
            DBObject oDB = null;
            SqlCommand oCmd;
            string[] sRes = new string[7];

            int iRows = 0;
            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                oCmd = oDB.GenerateCommand("ELGV2_IsPreviousConfigurationExists", oHs);
                iRows = oCmd.ExecuteNonQuery();
                sRes[0] = oCmd.Parameters["@isPreviousCoursePartConfigured"].Value.ToString();
                sRes[1] = oCmd.Parameters["@isNextCoursePartConfigured"].Value.ToString();
                sRes[2] = oCmd.Parameters["@PriviousCourse"].Value.ToString();
                sRes[3] = oCmd.Parameters["@NextCourse"].Value.ToString();
                sRes[4] = oCmd.Parameters["@PriviousCourseForDisplay"].Value.ToString();
                sRes[5] = oCmd.Parameters["@OtherPartOrTermExists"].Value.ToString();
                sRes[6] = oCmd.Parameters["@OtherPartOrTermExistsName"].Value.ToString();
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return sRes;
        }

        internal string DeleteConfigurations(Hashtable oHs)
        {
            DBObjectPool oPool = null;
            DBObject oDB = null;
            SqlCommand oCmd;
            string sRes = string.Empty;

            int iRows = 0;
            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                oCmd = oDB.GenerateCommand("ELGV2_DeleteConfigurations", oHs);
                iRows = oCmd.ExecuteNonQuery();
                sRes = oCmd.Parameters["@Status"].Value.ToString();
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return sRes;
      
        }

        internal string SaveAdmissionElgibilityConfigIndependentofResultStatus(Hashtable oHs)
        {
            DBObjectPool oPool = null;
            DBObject oDB = null;
            SqlCommand oCmd;
            string[] sRes = new string[1];

            int iRows = 0;
            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                oCmd = oDB.GenerateCommand("Elgv2_SaveAdmissionElgibilityConfigIndependentofResultStatus", oHs);
                iRows = oCmd.ExecuteNonQuery();
                sRes[0] = oCmd.Parameters["@Status"].Value.ToString();
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return sRes[0];
        }


        internal string DeleteAdmissionElgibilityConfigIndependentofResultStatus(Hashtable oHs)
        {
            DBObjectPool oPool = null;
            DBObject oDB = null;
            SqlCommand oCmd;
            string[] sRes = new string[1];

            int iRows = 0;
            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                oCmd = oDB.GenerateCommand("Elgv2_DeleteAdmissionElgibilityConfigIndependentofResultStatus", oHs);
                iRows = oCmd.ExecuteNonQuery();
                sRes[0] = oCmd.Parameters["@Status"].Value.ToString();
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return sRes[0];
        }

        internal string[] GetAdmissionElgibilityConfigStatusofCourse(Hashtable oHs)
        {
            DBObjectPool oPool = null;
            DBObject oDB = null;
            SqlCommand oCmd;
            string[] sRes = new string[2];

            int iRows = 0;
            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                oCmd = oDB.GenerateCommand("Elgv2_GetAdmissionElgibilityConfigStatusofCourse", oHs);
                iRows = oCmd.ExecuteNonQuery();
                sRes[0] = oCmd.Parameters["@StatusElgConfig"].Value.ToString();
                sRes[1] = oCmd.Parameters["@StatusElgConfigIndepedent"].Value.ToString();
                
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return sRes;
        }



        public DataTable GetAllDefinedAdmissionEligibilityConfigurations(Hashtable oHT)
        {
            DataTable oDT = null;
            DBObjectPool oPool = null;
            DBObject oDB = null;

            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                oDT = oDB.getparamdataset("Elgv2_GetAllDefinedAdmissionEligibilityConfigurations", oHT).Tables[0];
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return (oDT);
        }


        public DataTable GetAllDefinedAdmissionEligibilityConfigurationsForSearch(Hashtable oHT)
        {
            DataTable oDT = null;
            DBObjectPool oPool = null;
            DBObject oDB = null;

            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                oDT = oDB.getparamdataset("Elgv2_GetAllDefinedAdmissionEligibilityConfigurationsForSearch", oHT).Tables[0];
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return (oDT);
        }


      }

       
}