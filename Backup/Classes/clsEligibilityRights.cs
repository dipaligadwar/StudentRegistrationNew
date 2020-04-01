using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;
using Classes;

namespace Classes
{
    public class clsEligibilityRights
    {
        public string Add_EligibilityRights(string pk_Uni_ID,string pk_Fac_ID,string pk_Cr_ID,string pk_MoLrn_ID,string pk_CrPtrn_ID,string Elg_Rights_Flag,string Created_By,string For_All_Coll)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;

            Hashtable oHS = new Hashtable();
            string sReturnData = "";
            SqlCommand cmd;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                oHS.Add("pk_Uni_ID", pk_Uni_ID);
                oHS.Add("pk_Fac_ID", pk_Fac_ID);
                oHS.Add("pk_Cr_ID", pk_Cr_ID);
                oHS.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                oHS.Add("pk_CrPtrn_ID", pk_CrPtrn_ID);
                oHS.Add("Elg_Rights_Flag", Elg_Rights_Flag);
                oHS.Add("Created_By", Created_By);
                oHS.Add("For_All_Coll", For_All_Coll);

                cmd = oDB.GenerateCommand("ELG_Add_Eligibility_Rights", oHS);
                cmd.ExecuteScalar();
                sReturnData = "Y";
            }
            catch (SqlException ex)
            {
                sReturnData = "N";
                throw (ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return sReturnData;
        }

        public string Modify_EligibilityRights(string pk_Uni_ID, string pk_Fac_ID, string pk_Cr_ID, string pk_MoLrn_ID, string pk_CrPtrn_ID, string Elg_Rights_Flag, string Created_By, string For_All_Coll)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;

            Hashtable oHs = new Hashtable();
            string sReturnData="";
            SqlCommand cmd;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                oHs.Add("pk_Uni_ID", pk_Uni_ID);
                oHs.Add("pk_Fac_ID", pk_Fac_ID);
                oHs.Add("pk_Cr_ID", pk_Cr_ID);
                oHs.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                oHs.Add("pk_CrPtrn_ID", pk_CrPtrn_ID);
                oHs.Add("Elg_Rights_Flag", Elg_Rights_Flag);
                oHs.Add("Modified_By", Created_By);
                oHs.Add("For_All_Coll", For_All_Coll);

                cmd = oDB.GenerateCommand("Elg_Update_Eligibility_Rights", oHs);
               
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    sReturnData = "Y";
                }
                else
                {
                    sReturnData = "N";
                }
            }
            catch (SqlException ex)
            {
                sReturnData = "N";
                throw (ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return sReturnData;
        }

        public DataTable Elg_Diplay_Course_Rights(Hashtable oHs)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable DT = new DataTable();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                DT = oDB.getparamdataset("Elg_Diplay_Course_Rights", oHs).Tables[0];
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return (DT);
        }

        public static string Elg_Get_Courses_Rights(string pk_CrMoLrnPtrn_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string sRightsFlag = "";
            
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_CrMoLrnPtrn_ID", pk_CrMoLrnPtrn_ID);

                DataTable DT = oDB.getparamdataset("Elg_Get_Course_Rights", ohs).Tables[0];
                if (DT.Rows.Count > 0)
                {
                    sRightsFlag = DT.Rows[0]["Elg_Rights_Flag"].ToString();
                }
                return sRightsFlag;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_Eligibility_Statistics(string pk_CrMoLrnPtrn_ID, string fk_CrPr_ID, string pk_Uni_ID, string pk_Institute_ID,string College_Eligibility_Flag)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_CrMoLrnPtrn_ID", pk_CrMoLrnPtrn_ID);
                ohs.Add("fk_CrPr_ID", fk_CrPr_ID);
                ohs.Add("pk_Uni_ID", pk_Uni_ID);
                ohs.Add("pk_Institute_ID", pk_Institute_ID);
                ohs.Add("College_Eligibility_Flag",College_Eligibility_Flag);


                DataSet DS = oDB.getparamdataset("Elg_Statistics_Coll_Uni", ohs);
                return DS;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static string Bulk_Process_Eligibility_Data(string Uni_ID,string Year,string Institute_ID,string pk_CrMoLrnPtrn_ID,string pk_CrPr_ID,string Student_ID,string College_Eligibility_Flag,string ElgDecision,string Reason,string UserID)
        {
            string sReturn = "";
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("Year", Year);
                ht.Add("Institute_ID", Institute_ID);
                ht.Add("Student_ID", Student_ID);
                ht.Add("ElgDecision",ElgDecision);
                ht.Add("Reason",Reason);
                ht.Add("pk_CrMoLrnPtrn_ID",pk_CrMoLrnPtrn_ID);
                ht.Add("pk_CrPr_ID",pk_CrPr_ID);
                ht.Add("College_Eligibility_Flag",College_Eligibility_Flag);
                ht.Add("UserID", UserID);
                ht.Add("PRN", "");
                cmd = oDB.GenerateCommand("ELG_Add_BULK_DATA_PRN", ht);
                cmd.ExecuteNonQuery();
                sReturn = "Y";
                return sReturn;

            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                sReturn = "N";
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataTable Elg_Display_PRN(string pk_CrMoLrnPtrn_ID, string pk_CrPr_ID, string pk_Uni_ID, string pk_Institute_ID, string fk_Year_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();

                ohs.Add("pk_CrMoLrnPtrn_ID",pk_CrMoLrnPtrn_ID);
                ohs.Add("pk_CrPr_ID",pk_CrPr_ID);
                ohs.Add("pk_Uni_ID",pk_Uni_ID);
                ohs.Add("pk_Institute_ID",pk_Institute_ID);
                ohs.Add("fk_Year_ID",fk_Year_ID);


                DataTable DT = oDB.getparamdataset("ELG_Dispaly_PRN", ohs).Tables[0];
                return DT;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

    }

        
}
