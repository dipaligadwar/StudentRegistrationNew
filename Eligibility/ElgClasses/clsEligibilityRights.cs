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
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data.Common;
using System.Text;
using System.IO;

namespace StudentRegistration.Eligibility.ElgClasses
{
    public class clsEligibilityRights
    {
        public string Add_EligibilityRights(string UniID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string ElgRightsFlag, string Created_By, string For_All_Coll)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            int retFlag = 1;
            Hashtable oHS = new Hashtable();
            string sReturnData = "";
            SqlCommand cmd;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                oHS.Add("UniID", UniID);
                oHS.Add("FacID", FacID);
                oHS.Add("CrID", CrID);
                oHS.Add("MoLrnID", MoLrnID);
                oHS.Add("PtrnID", PtrnID);
                oHS.Add("BrnID", BrnID);
                oHS.Add("Elg_Rights_Flag", ElgRightsFlag);
                oHS.Add("Created_By", Created_By);
                oHS.Add("For_All_Coll", For_All_Coll);
                oHS.Add("@ReturnFlag", retFlag);


                cmd = oDB.GenerateCommand("ELGV2_Add_Eligibility_Rights", oHS);
                cmd.ExecuteScalar();
                retFlag = Convert.ToInt32(cmd.Parameters["@ReturnFlag"].Value);
                if (retFlag == 1)
                    sReturnData = "Y";
                else if (retFlag == 0)
                    sReturnData = "E";
                else
                    sReturnData = "N";

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

        public string Modify_EligibilityRights(string UniID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string ElgRightsFlag, string Created_By, string For_All_Coll)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;

            Hashtable oHs = new Hashtable();
            string sReturnData = "";
            SqlCommand cmd;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                oHs.Add("UniID", UniID);
                oHs.Add("FacID", FacID);
                oHs.Add("CrID", CrID);
                oHs.Add("MoLrnID", MoLrnID);
                oHs.Add("PtrnID", PtrnID);
                oHs.Add("BrnID", BrnID);
                oHs.Add("Elg_Rights_Flag", ElgRightsFlag);
                oHs.Add("Modified_By", Created_By);
                oHs.Add("For_All_Coll", For_All_Coll);

                cmd = oDB.GenerateCommand("ELGV2_Update_Eligibility_Rights", oHs);

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

        #region Elg_Diplay_Course_Rights  - Added By Amit
        public DataTable Elg_Diplay_Course_Rights(string UniID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID)
        {

            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable DT = new DataTable();
            try
            {
                Hashtable oHs = new Hashtable();
                oHs.Add("UniID", UniID);
                oHs.Add("FacID", FacID);
                oHs.Add("CrID", CrID);
                oHs.Add("MoLrnID", MoLrnID);
                oHs.Add("PtrnID", PtrnID);
                oHs.Add("BrnID", BrnID);
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                DT = oDB.getparamdataset("ELGV2_Display_Course_Rights", oHs).Tables[0];
            }
            catch (Exception ex)
            {
                DT = null;
                throw new Exception(ex.Message);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return (DT);
        }
        #endregion

        public static string Elg_Get_Courses_Rights(string UniID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID,
string pk_CrPrCh_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string sRightsFlag = "";

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                DataTable DT = oDB.getparamdataset("ELGV2_Get_Course_Rights", ohs).Tables[0];
                if (DT.Rows.Count > 0)
                {
                    sRightsFlag = DT.Rows[0]["Elg_Rights_Flag"].ToString();
                }
                return sRightsFlag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }


        public static string Elg_Get_Courses_Rights1(string UniID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string sRightsFlag = "";

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrDetailsID);
                //ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                DataTable DT = oDB.getparamdataset("ELGV2_Get_Course_Rights", ohs).Tables[0];
                if (DT.Rows.Count > 0)
                {
                    sRightsFlag = DT.Rows[0]["Elg_Rights_Flag"].ToString();
                }
                return sRightsFlag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }



        #region Elg_Get_Eligibility_Statistics and Elg_Get_StudentsList_Coll_Uni with invoice and bypass invoice for Unregistered Students

        public static DataSet Elg_Get_Eligibility_Statistics(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string College_Eligibility_Flag, string fk_AcademicYear_ID, string pk_CrPrCh_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);

                DS = oDB.getparamdataset("ElgV2_Statistics_Coll_Uni", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                DS = null;
                throw new Exception(ex.Message);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_Eligibility_Statistics_ExamBody(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string fk_AcademicYear_ID, string College_Eligibility_Flag, string StateID, string BodyID, string pk_CrPrCh_Id)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("Body_State", StateID);
                ohs.Add("Body_ID", BodyID);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_Id);

                DS = oDB.getparamdataset("ELGV2_Statistics_Coll_Uni_ExamBody", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_Eligibility_Statistics_ExamBody_Foreign(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string fk_AcademicYear_ID, string College_Eligibility_Flag, string BodyCountryID, string ForeignBoardUnivName, string pk_CrPrCh_Id)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("Body_Country", BodyCountryID);
                ohs.Add("Other_Body_Name", ForeignBoardUnivName);
                ohs.Add("pk_CrPrCh_Id", pk_CrPrCh_Id);
                DS = oDB.getparamdataset("ELGV2_Statistics_Coll_Uni_ExamBody_Foreign", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_Eligibility_Statistics_bypassInv(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string AcademicYr, string College_Eligibility_Flag, string pk_CrPrCh_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);

                DS = oDB.getparamdataset("ELGV2_Statistics_Coll_Uni_bypassInv", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_Eligibility_Statistics_bypassInv_ExamBody(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string AcademicYr, string College_Eligibility_Flag, string StateID, string BodyID, string pk_CrPrCh_Id)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("Body_State", StateID);
                ohs.Add("Body_ID", BodyID);
                ohs.Add("pk_CrPrCh_Id", pk_CrPrCh_Id);

                DS = oDB.getparamdataset("ELGV2_Statistics_Coll_Uni_bypassInv_ExamBody", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_Eligibility_Statistics_bypassInv_ExamBody_Foerign(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string pk_CrPrCh_ID, string AcademicYr, string College_Eligibility_Flag, string BodyCountryID, string ForeignBoardUnivName)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("Body_Country", BodyCountryID);
                ohs.Add("Other_Body_Name", ForeignBoardUnivName);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);

                DS = oDB.getparamdataset("ELGV2_Statistics_Coll_Uni_bypassInv_ExamBody_Foerign", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }



        public static DataSet Elg_Get_StudentsList_Coll_Uni(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string AcademicYr, string College_Eligibility_Flag, string FilterFlag, string lName, string fName, string pk_CrPrCh_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("FilterFlag", FilterFlag);
                ohs.Add("LastName", lName);
                ohs.Add("FirstName", fName);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);

                DS = oDB.getparamdataset("ELGV2_StudentsList_Coll_Uni", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_StudentsList_Coll_Uni_ExamBody(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string AcademicYr, string College_Eligibility_Flag, string FilterFlag, string lName, string fName, string StateID, string BodyID, string pk_CrPrCh_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("FilterFlag", FilterFlag);
                ohs.Add("LastName", lName);
                ohs.Add("FirstName", fName);
                ohs.Add("Body_State", StateID);
                ohs.Add("Body_ID", BodyID);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                DS = oDB.getparamdataset("ELGV2_StudentsList_Coll_Uni_ExamBody", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_StudentsList_Coll_Uni_ExamBody_Foerign(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string AcademicYr, string College_Eligibility_Flag, string FilterFlag, string lName, string fName, string BodyCountryID, string ForeignBoardUnivName, string pk_CrPrCh_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("FilterFlag", FilterFlag);
                ohs.Add("LastName", lName);
                ohs.Add("FirstName", fName);
                ohs.Add("Body_Country", BodyCountryID);
                ohs.Add("Other_Body_Name", ForeignBoardUnivName);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);

                DS = oDB.getparamdataset("ELGV2_StudentsList_Coll_Uni_ExamBody_Foerign", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_StudentsList_Coll_Uni_bypassInv(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string AcademicYr, string College_Eligibility_Flag, string FilterFlag, string lName, string fName, string pk_CrPrCh_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("FilterFlag", FilterFlag);
                ohs.Add("LastName", lName);
                ohs.Add("FirstName", fName);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                DS = oDB.getparamdataset("ELGV2_StudentsList_Coll_Uni_bypassInv", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_StudentsList_Coll_Uni_bypassInv_ExamBody(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string pk_CrPrCh_ID, string AcademicYr, string College_Eligibility_Flag, string FilterFlag, string lName, string fName, string StateID, string BodyID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("FilterFlag", FilterFlag);
                ohs.Add("LastName", lName);
                ohs.Add("FirstName", fName);
                ohs.Add("Body_State", StateID);
                ohs.Add("Body_ID", BodyID);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                DS = oDB.getparamdataset("ELGV2_StudentsList_Coll_Uni_bypassInv_ExamBody", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_StudentsList_Coll_Uni_bypassInv_ExamBody_Foerign(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string pk_CrPrCh_ID, string AcademicYr, string College_Eligibility_Flag, string FilterFlag, string lName, string fName, string BodyCountryID, string ForeignBoardUnivName)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("FilterFlag", FilterFlag);
                ohs.Add("LastName", lName);
                ohs.Add("FirstName", fName);
                ohs.Add("Body_Country", BodyCountryID);
                ohs.Add("Other_Body_Name", ForeignBoardUnivName);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                DS = oDB.getparamdataset("ELGV2_StudentsList_Coll_Uni_bypassInv_ExamBody_Foerign", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region Elg_Get_Eligibility_Statistics with invoice and bypass invoice for Registered Students

        public static DataSet Elg_Get_Eligibility_Statistics_RegStu(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string CrPrChID, string College_Eligibility_Flag, string AcademicYr)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("pk_CrPrCh_Id", CrPrChID);

                DS = oDB.getparamdataset("ElgV2_Statistics_Coll_Uni_RegStu", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_Eligibility_Statistics_bypassInv_RegStu(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string CrPrChID, string College_Eligibility_Flag, string AcademicYr)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("pk_CrPrCh_ID", CrPrChID);
                DS = oDB.getparamdataset("ELGV2_Statistics_Coll_Uni_RegStu_bypassInv", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_StudentsList_Coll_Uni_RegStu(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string CrPrChID, string College_Eligibility_Flag, string FilterFlag, string lName, string fName, string prn, string AcademicYr)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("FilterFlag", FilterFlag);
                ohs.Add("LastName", lName);
                ohs.Add("FirstName", fName);
                ohs.Add("PRN", prn);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("pk_CrPrCh_ID", CrPrChID);
                DS = oDB.getparamdataset("ELGV2_StudentsList_Coll_Uni_RegStu", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Elg_Get_StudentsList_Coll_Uni_bypassInv_RegStu(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string CrPrChID, string College_Eligibility_Flag, string FilterFlag, string lName, string fName, string prn, string AcademicYr)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet DS = new DataSet();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();
                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_RefInstitute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ohs.Add("FilterFlag", FilterFlag);
                ohs.Add("LastName", lName);
                ohs.Add("FirstName", fName);
                ohs.Add("PRN", prn);
                ohs.Add("fk_AcademicYear_ID", AcademicYr);
                ohs.Add("pk_CrPrCh_ID", CrPrChID);
                DS = oDB.getparamdataset("ELGV2_StudentsList_Coll_Uni_RegStu_bypassInv", ohs);
                return DS;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DS = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region Bulk_Process_Eligibility_Data for Unregistered Students

        public static string Bulk_Process_Eligibility_Data(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string fkAcademicYearID, string StudentYrID, string College_Eligibility_Flag, string ElgDecision, string Reason, string UserID, string pk_CrPrCh_ID, string DC_ServerName, string DC_DBName)
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
                ht.Add("pk_Uni_ID", UniID);
                //ht.Add("pk_Year", Year);
                ht.Add("pk_Institute_ID", InstID);
                ht.Add("pk_Fac_ID", FacID);
                ht.Add("pk_Cr_ID", CrID);
                ht.Add("pk_MoLrn_ID", MoLrnID);
                ht.Add("pk_Ptrn_ID", PtrnID);
                ht.Add("pk_Brn_ID", BrnID);
                // ht.Add("pk_CrPrDetails_ID", CrPrID);
                ht.Add("fkAcademicYearID", fkAcademicYearID);
                ht.Add("StudentYrID", StudentYrID);
                ht.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ht.Add("ElgDecision", ElgDecision);
                ht.Add("Reason", Reason);
                ht.Add("UserID", UserID);
                ht.Add("pkCrPrChID", pk_CrPrCh_ID);
                ht.Add("DC_ServerName", DC_ServerName);
                ht.Add("DC_DBName", DC_DBName);
                //ht.Add("PRN", "");
                //ht.Add("Error", 0);
                cmd = oDB.GenerateCommand("ELGV2_Register_Fresh_Student_Bulk", ht);
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
        #endregion

        #region Bulk_Process_Eligibility_Data for Registered Students

        public static string Bulk_Process_Eligibility_Data_RegStu(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrChID, string studYearID, string fkAcademicyear, string College_Eligibility_Flag, string ElgDecision, string Reason, string UserID)
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
                ht.Add("pk_Uni_ID", UniID);
                //ht.Add("pk_Year", Year);
                ht.Add("pk_Institute_ID", InstID);
                ht.Add("StudentYrID", studYearID);
                ht.Add("fkAcademicYearID", fkAcademicyear);
                ht.Add("pk_Fac_ID", FacID);
                ht.Add("pk_Cr_ID", CrID);
                ht.Add("pk_MoLrn_ID", MoLrnID);
                ht.Add("pk_Ptrn_ID", PtrnID);
                ht.Add("pk_Brn_ID", BrnID);
                // ht.Add("pk_CrPrDetails_ID", CrPrID);
                ht.Add("College_Eligibility_Flag", College_Eligibility_Flag);
                ht.Add("ElgDecision", ElgDecision);
                ht.Add("Reason", Reason);
                ht.Add("UserID", UserID);
                ht.Add("pkCrPrChID", CrPrChID);
                cmd = oDB.GenerateCommand("ELGV2_Register_Fresh_Student_RegStu_Bulk", ht);
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

        #endregion

        public static DataTable Elg_Display_PRN(string UniID, string Year, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string pk_CrPrCh_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable DT = new DataTable();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable ohs = new Hashtable();

                ohs.Add("pk_Uni_ID", UniID);
                ohs.Add("pk_Year", Year);
                ohs.Add("pk_Institute_ID", InstID);
                ohs.Add("pk_Fac_ID", FacID);
                ohs.Add("pk_Cr_ID", CrID);
                ohs.Add("pk_MoLrn_ID", MoLrnID);
                ohs.Add("pk_Ptrn_ID", PtrnID);
                ohs.Add("pk_Brn_ID", BrnID);
                ohs.Add("pk_CrPr_Details_ID", CrPrID);
                ohs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                DT = oDB.getparamdataset("ELGV2_Display_PRN", ohs).Tables[0];
                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DT = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #region Fetch Registered Student Details For SMS - Modified By Shivani on 2nd Sept 2008 For SMS Integration

        public static DataSet FetchRegisteredStudentDetailsForSMS(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrChID, string studYearID)
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", UniID);
                //ht.Add("pk_Year", Year);
                ht.Add("pk_Institute_ID", InstID);
                ht.Add("pk_Fac_ID", FacID);
                ht.Add("pk_Cr_ID", CrID);
                ht.Add("pk_MoLrn_ID", MoLrnID);
                ht.Add("pk_Ptrn_ID", PtrnID);
                ht.Add("pk_Brn_ID", BrnID);
                // ht.Add("pk_CrPr_Details_ID", CrPrID);
                ht.Add("pk_CrPrCh_ID", CrPrChID);
                ht.Add("studYearID", studYearID);
                ds = oDB.getparamdataset("ELGV2_Fetch_Reg_Student_Details_ForSMS", ht);
                return ds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                ds = null;
                throw (e);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }


        }

        #endregion

        #region List State
        //public static DataTable ELGV2_displayAllStates(string langFlag, string universityID, string instituteID, string facID, string crID, string moLrnID, string ptrnID, string brnID)
        public static DataTable ELGV2_displayAllStates(string langFlag, string universityID, string instituteID, string facID, string crID, string moLrnID, string ptrnID, string brnID, string DOB, string LastName, string FirstName, string Gender, string ElgStatusColl)
        {

            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable DT = new DataTable();

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable oHs = new Hashtable();
                oHs.Add("Lang_Flag", langFlag);
                oHs.Add("Uni_ID", universityID);
                oHs.Add("RefInst_ID", instituteID);
                oHs.Add("Fac_ID", facID);
                oHs.Add("Cr_ID", crID);
                oHs.Add("MoLrn_ID", moLrnID);
                oHs.Add("Ptrn_ID", ptrnID);
                oHs.Add("Brn_ID", brnID);
                oHs.Add("DOB_Stu", DOB);
                oHs.Add("Last_Name", LastName);
                oHs.Add("First_Name", FirstName);
                oHs.Add("Gender_Stu", Gender);
                oHs.Add("Elg_StatusColl", ElgStatusColl);
                DT = oDB.getparamdataset("ELGV2_displayAllStates", oHs).Tables[0];
                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                DT = null;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region List State for BulkProcess
        public static DataTable ELGV2_displayAllStates_BulkProcess(string langFlag, string universityID, string instituteID, string facID, string crID, string moLrnID, string ptrnID, string brnID)
        {
            Hashtable oHs = new Hashtable();
            oHs["Lang_Flag"] = langFlag;
            oHs["pk_Uni_ID"] = universityID;
            oHs["pk_Inst_ID"] = instituteID;
            oHs["FacID"] = facID;
            oHs["CrID"] = crID;
            oHs["MoLrnID"] = moLrnID;
            oHs["PtrnID"] = ptrnID;
            oHs["BrnID"] = brnID;
            //oHs["CrPrDetailsID"] = CrPrDetailsID;            
            DataSet set = new DataSet();
            DBObjectPool instance = null;
            DBObject db = null;
            try
            {
                instance = DBObjectPool.Instance;
                db = instance.AcquireDBObject();
                set = db.getparamdataset("ELGV2_displayAllStates_BulkProcess", oHs);
            }
            finally
            {
                instance.ReleaseDBObject(db);
            }
            if (set.Tables.Count == 1)
            {
                return set.Tables[0];
            }
            return null;
        }

        #endregion



        #region List statewise Board for Bulk Process
        public static DataTable ELGV2_List_StateWiseBoard_BulkProcess(string universityID, string instituteID, string fk_StateID, string facID, string crID, string moLrnID, string ptrnID, string brnID)
        {
            Hashtable oHs = new Hashtable();

            oHs.Add("pk_Uni_ID", universityID);
            oHs.Add("pk_Inst_ID", instituteID);
            oHs.Add("fk_StateID", fk_StateID);
            oHs.Add("Fac_ID", facID);
            oHs.Add("Cr_ID", crID);
            oHs.Add("MoLrn_ID", moLrnID);
            oHs.Add("Ptrn_ID", ptrnID);
            oHs.Add("Brn_ID", brnID);

            DBObject db = null;
            DBObjectPool instance = null;
            DataTable table = new DataTable();
            try
            {
                instance = DBObjectPool.Instance;
                db = instance.AcquireDBObject();
                table = db.getparamdataset("ELGV2_List_StateWiseBoard_BulkProcess", oHs).Tables[0];
            }
            finally
            {
                instance.ReleaseDBObject(db);
            }
            return table;
        }
        #endregion


        #region List statewise Board
        public static DataTable ELGV2_ListStateWiseBoard(string universityID, string instituteID, string fk_StateID, string facID, string crID, string moLrnID, string ptrnID, string brnID, string DOB, string LastName, string FirstName, string Gender, string ElgStatusColl)
        {
            Hashtable oHs = new Hashtable();

            oHs.Add("pk_Uni_ID", universityID);
            oHs.Add("pk_Inst_ID", instituteID);
            oHs.Add("fk_StateID", fk_StateID);
            oHs.Add("Fac_ID", facID);
            oHs.Add("Cr_ID", crID);
            oHs.Add("MoLrn_ID", moLrnID);
            oHs.Add("Ptrn_ID", ptrnID);
            oHs.Add("Brn_ID", brnID);
            oHs.Add("DOB_Stu", DOB);
            oHs.Add("Last_Name", LastName);
            oHs.Add("First_Name", FirstName);
            oHs.Add("Gender_Stu", Gender);
            oHs.Add("Elg_StatusColl", ElgStatusColl);


            DBObject db = null;
            DBObjectPool instance = null;
            DataTable table = new DataTable();
            try
            {
                instance = DBObjectPool.Instance;
                db = instance.AcquireDBObject();
                table = db.getparamdataset("ELGV2_List_StateWiseBoard", oHs).Tables[0];
            }
            finally
            {
                instance.ReleaseDBObject(db);
            }
            return table;
        }
        #endregion

        #region List Statewise university
        public static DataTable ELGV2_ListStateWiseUniversities(string State_ID, string universityID, string instituteID, string facID, string crID, string moLrnID, string ptrnID, string brnID)
        {
            Hashtable oHs = new Hashtable();
            oHs.Add("State_ID", State_ID);

            oHs.Add("pk_Uni_ID", universityID);
            oHs.Add("pk_Inst_ID", instituteID);
            oHs.Add("FacID", facID);
            oHs.Add("CrID", crID);
            oHs.Add("MoLrnID", moLrnID);
            oHs.Add("PtrnID", ptrnID);
            oHs.Add("BrnID", brnID);
            // oHs.Add("CrPrDetailsID", CrPrDetailsID);

            DBObject db = null;
            DBObjectPool instance = null;
            DataTable table = new DataTable();
            try
            {
                instance = DBObjectPool.Instance;
                db = instance.AcquireDBObject();
                table = db.getparamdataset("ELGV2_ListStateWiseUniversities", oHs).Tables[0];
            }
            finally
            {
                instance.ReleaseDBObject(db);
            }
            return table;
        }



        #endregion

        #region Get SMS Text from DP_SMS_Notifications
        public static DataSet GetSMSText(string Notification_ID)
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Notification_ID", Notification_ID);

                ds = oDB.getparamdataset("ELGV2_Get_SMSBody", ht);
                return ds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                ds = null;
                throw (e);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Get Student Credentials for SMS
        public static DataSet GetStudentCredentialsForSMS(string UniID, string Year, string StudentID)
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("UniID", UniID);
                ht.Add("Year", Year);
                ht.Add("StudentID", StudentID);
                ds = oDB.getparamdataset("ELGV2_Get_StudentCredentialsForSMS", ht);
                return ds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                ds = null;
                throw (e);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Function to Get SMS Text from DB
        public static string GetSMSBody(string Registration_ID, string firstName, string courseName, string academicYear, string uniCode, string PRN, string URL, string userName, string password,string reason)
        {
            string sNotificationMessage = string.Empty;
            sNotificationMessage = clsEligibilityRights.GetSMSText(Registration_ID).Tables[0].Rows[0]["NotificationMessage"].ToString();
            sNotificationMessage = Regex.Replace(sNotificationMessage, "\\<\\<First_Name\\>\\>", firstName);
            sNotificationMessage = Regex.Replace(sNotificationMessage, "\\<\\<Course_Short_Name\\>\\>", courseName);
            sNotificationMessage = Regex.Replace(sNotificationMessage, "\\<\\<Academic_Year\\>\\>", academicYear);
            sNotificationMessage = Regex.Replace(sNotificationMessage, "\\<\\<University_Code\\>\\>", uniCode);
            sNotificationMessage = Regex.Replace(sNotificationMessage, "\\<\\<PRN\\>\\>", PRN);
            sNotificationMessage = Regex.Replace(sNotificationMessage, "\\<\\<URL\\>\\>", URL);
            sNotificationMessage = Regex.Replace(sNotificationMessage, "\\<\\<username\\>\\>", userName);
            sNotificationMessage = Regex.Replace(sNotificationMessage, "\\<\\<password\\>\\>", password);
            sNotificationMessage = Regex.Replace(sNotificationMessage, "\\<\\<Reason\\>\\>", reason);


            return sNotificationMessage;
        }
        #endregion

        #region Import Provisional & Non Provisional Eligibility from Excel :JatinD

        #region CheckTableExists Records

        public string CheckTableExists(string tablename)
        {
            string result = "Successful";
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable objHT = new Hashtable();
            DataSet ds = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                objHT.Add("TableName", tablename);                
                ds = oDB.getparamdataset("ELGV2_ImportFromExcel_CheckTableExists", objHT);

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

        #region CreateTable

		public string CreateTable(string FileName, string TableName)
		{
			//System.Data.DataTable dt = null;
			DataSet TableData = new DataSet();

			DBObjectPool Pool = null;
			DBObject oDB = null;

			Pool = DBObjectPool.Instance;
			oDB = Pool.AcquireDBObject();
			////oDB.ThisConnectionFor = DBConnection.ADECWrite;
			string conn = oDB.GetConnectionString();

			SqlConnection DestCnn = new SqlConnection(conn);
			OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=Excel 12.0;");
			//OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR= Yes;\"");
			try
			{
				OleDbDataAdapter oledba = new OleDbDataAdapter("SELECT DISTINCT * FROM [sheet1$]", connection);
				oledba.Fill(TableData);
				System.Data.DataTable tblSchema = TableData.Tables[0].CreateDataReader().GetSchemaTable();
				if (tblSchema.Rows.Count != 0)
				{
					StringBuilder QCreate = new StringBuilder();

					//QCreate.Append(" CREATE TABLE dbo.[" + TableName + "](");
					QCreate.Append(" IF  EXISTS (SELECT * FROM sys.objects");
					QCreate.Append(" WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]')");
					QCreate.Append(" AND type in (N'U'))");
					QCreate.Append(" DROP TABLE [dbo].[" + TableName + "] ");
					QCreate.Append(" CREATE TABLE dbo.[" + TableName + "](");

					foreach (DataRow dr in tblSchema.Rows)
					{
						switch (Convert.ToString(dr["DataType"]))
						{
							//case "System.String":
							//    QCreate.Append("[" + dr["ColumnName"] + "] varchar(" + dr["ColumnSize"] + "), ");
							//    break;
							//case "System.Int32":
							//    QCreate.Append("[" + dr["ColumnName"] + "] bigint, ");
							//    break;
							//case "System.Double":
							//    QCreate.Append("[" + dr["ColumnName"] + "] decimal, ");
							//    break;
							//case "System.DateTime":
							//    QCreate.Append("[" + dr["ColumnName"] + "] datetime, ");
							//    break;
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
					sqlcpy.DestinationTableName = "[" + TableName + "]";
					sqlcpy.WriteToServer(TableData.Tables[0]);
					string Result = TableName;

					sqlcpy.Close();
					comd.Dispose();

				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
			finally
			{
				if (connection != null)
				{
					connection.Close();
					connection.Dispose();
				}
				if (DestCnn != null)
				{
					DestCnn.Close();
					DestCnn.Dispose();
				}

				if (TableData != null)
					TableData.Dispose();

				////FileInfo fi = new FileInfo(FileName);
				////if (fi.Exists)
				////{
				////    fi.Delete();
				////}
			}

			return "0";
		}

        #endregion

        #region Import Provisional & Non Provisional Eligibility from Excel

        public string ConfirmProvisionalANDNonProvisionalEligibilityfromExcel(string TableName, string FacID, string CrID, string MolrnID, string PtrnID, string BrnID, string CrDetailID, string CrPrTrmID, string UserID, string AcademicID, string Eligibility)
        {

            string result = "Successful";
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable objHT = new Hashtable();
            DataSet ds = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                objHT.Add("UniID", clsGetSettings.UniversityID.Trim());
                objHT.Add("TableName", TableName);
                objHT.Add("FacID", FacID);
                objHT.Add("CrID", CrID);
                objHT.Add("MoLrnID", MolrnID);
                objHT.Add("PtrnID", PtrnID);
                objHT.Add("BrnID", BrnID);
                objHT.Add("CrPrDetailsID", CrDetailID);
                objHT.Add("CrPrChID", CrPrTrmID);
                objHT.Add("UserID", UserID);
				objHT.Add("AcadYrID", AcademicID);
				objHT.Add("Eligibility", Eligibility);
				ds = oDB.getparamdataset("ELGV2_ProvisionalNonProvisionalImport_Bulk", objHT);

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

        #endregion


    }


}
