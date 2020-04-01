using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using Classes;
using System;
namespace StudentRegistration.Eligibility.ElgClasses
{
    public class clsElgStudent
    {
        #region SearchStudent Function
        /// <summary>
        /// Seacrh student.
        /// </summary>
        /// <param name="oHs"></param>
        /// <returns></returns>
        public DataSet SearchStudent(Hashtable oHs)
        {
            DataSet dt = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_CancelAdmission_SearchStudent", oHs);
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
        #endregion

        #region SearchStudentbyPRN Function
        /// <summary>
        /// Seacrh student.
        /// </summary>
        /// <param name="oHs"></param>
        /// <returns></returns>
        public DataTable SearchStudentbyPRN(string PRN) 
        {
            Hashtable oHs = new Hashtable();
            DataTable dt = new DataTable ();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string uniID = clsGetSettings.UniversityID.Trim();
            try
            {
                oHs.Add("UniID", uniID);
                oHs.Add("PRN_Number", PRN);

                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_TransferPreviousAdmissions_SearchStudent", oHs).Tables[0]; 
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
        #endregion


        #region SearchStudentForAddPaper Function
        /// <summary>
        /// Seacrh student.
        /// </summary>
        /// <param name="oHs"></param>
        /// <returns></returns>
        public DataTable SearchStudentForAddPaper(string PRN, string ElgFormNo, string AcadYear)
        {
            Hashtable oHs = new Hashtable();
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string uniID = clsGetSettings.UniversityID.Trim();
            try
            {
                oHs.Add("UniID", uniID);
                oHs.Add("PRN_Number", PRN);
                oHs.Add("ElgFormNo", ElgFormNo);
                oHs.Add("AcadYearID", AcadYear);

                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_SearchStudentAdditionalPaperChange", oHs).Tables[0];
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
        #endregion



        #region UpdateTransferPreviousAdmissions_ForStudent
        /// <summary>
        /// Seacrh student.
        /// </summary>
        /// <param name="oHs"></param>
        /// <returns></returns>
        public int UpdateTransferPreviousAdmissions_ForStudent(string PRN_Number, string NewRef_Pk_Institute_ID, string OldPk_Institute_ID, string facID, string courseID, string molrnID, string ptrnID, string brnID, string crPrDetailID, string crPrChildID, string fk_AcademicYear_ID, string fk_AcademicYear_Seq, string DeleteOldCancelEntry, string createdBy, string CrPr_Seq, string CrPrCh_Seq)
        {
            int flag = 0;
            Hashtable oHs = new Hashtable();
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string uniID = clsGetSettings.UniversityID.Trim();
            try
            {
                oHs.Add("Pk_Uni_ID", uniID);
                oHs.Add("PRN_Number", PRN_Number);
                oHs.Add("NewRef_Pk_Institute_ID", NewRef_Pk_Institute_ID);
                oHs.Add("OldPk_Institute_ID", OldPk_Institute_ID);
                oHs.Add("PK_Fac_ID", facID);
                oHs.Add("PK_Cr_ID", courseID);
                oHs.Add("Pk_Molrn_ID", molrnID);
                oHs.Add("Pk_Ptrn_ID", ptrnID);
                oHs.Add("Pk_Brn_ID", brnID);
                oHs.Add("Pk_CrPr_Details_ID", crPrDetailID);
                oHs.Add("Pk_CrPrCh_ID", crPrChildID);
                oHs.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                oHs.Add("fk_AcademicYear_Seq", fk_AcademicYear_Seq);
                oHs.Add("DeleteOldCancelEntry", DeleteOldCancelEntry);
                oHs.Add("UserID", createdBy);
                oHs.Add("CrPr_Seq", CrPr_Seq);
                oHs.Add("CrPrCh_Seq", CrPrCh_Seq);
                oHs.Add("ExecutionStatus", flag);

                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                SqlCommand cmd = oDB.GenerateCommand("ELGV2_TransferPreviousAdmissions_ForStudent", oHs);
                cmd.ExecuteNonQuery();
                flag = Convert.ToInt32(cmd.Parameters["@ExecutionStatus"].Value);
            }

            catch (SqlException ex)
            {
                return 0;
                throw (ex);
            }

            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return flag;
        }
        #endregion

        #region UpdateStudyCenter_ForStudent
        /// <summary>
        /// Seacrh student.
        /// </summary>
        /// <param name="oHs"></param>
        /// <returns></returns>
        public int UpdateStudyCenter_ForStudent(string PRN_Number, string NewRef_Pk_Institute_ID, string OldPk_Institute_ID, string facID, string courseID, string molrnID, string ptrnID, string brnID, string crPrDetailID, string crPrChildID, string fk_AcademicYear_ID, string fk_AcademicYear_Seq, string DeleteOldCancelEntry, string createdBy, string CrPr_Seq, string CrPrCh_Seq)
        {
            int flag = 0;
            Hashtable oHs = new Hashtable();
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string uniID = clsGetSettings.UniversityID.Trim();
            try
            {
                oHs.Add("Pk_Uni_ID", uniID);
                oHs.Add("PRN_Number", PRN_Number);
                oHs.Add("NewRef_Pk_Institute_ID", NewRef_Pk_Institute_ID);
                oHs.Add("OldPk_Institute_ID", OldPk_Institute_ID);
                oHs.Add("PK_Fac_ID", facID);
                oHs.Add("PK_Cr_ID", courseID);
                oHs.Add("Pk_Molrn_ID", molrnID);
                oHs.Add("Pk_Ptrn_ID", ptrnID);
                oHs.Add("Pk_Brn_ID", brnID);
                oHs.Add("Pk_CrPr_Details_ID", crPrDetailID);
                oHs.Add("Pk_CrPrCh_ID", crPrChildID);
                oHs.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                oHs.Add("fk_AcademicYear_Seq", fk_AcademicYear_Seq);
                oHs.Add("DeleteOldCancelEntry", DeleteOldCancelEntry);
                oHs.Add("UserID", createdBy);
                oHs.Add("CrPr_Seq", CrPr_Seq);
                oHs.Add("CrPrCh_Seq", CrPrCh_Seq);
                oHs.Add("ExecutionStatus", flag);

                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                SqlCommand cmd = oDB.GenerateCommand("ELGV2_StudyCenterChange_ForStudent", oHs);
                cmd.ExecuteNonQuery();
                flag = Convert.ToInt32(cmd.Parameters["@ExecutionStatus"].Value);
            }

            catch (SqlException ex)
            {
                return 0;
                throw (ex);
            }

            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return flag;
        }
        #endregion

        #region InstituteSearch_ByAffiliatedCourse
        /// <summary>
        /// Seacrh student.
        /// </summary>
        /// <param name="oHs"></param>
        /// <returns></returns>
        public DataTable InstituteSearch_ByAffiliatedCourse(string PRN_Number, string pk_Inst_ID, string pk_Fac_ID, string pk_Cr_ID, string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPr_Details_ID, string pk_AcademicYear_ID)
        {
            Hashtable oHs = new Hashtable();
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string uniID = clsGetSettings.UniversityID.Trim();
            try
            {
                oHs.Add("UniID", uniID);
                oHs.Add("pk_Inst_ID", pk_Inst_ID);
                oHs.Add("PRN_Number", PRN_Number);
                oHs.Add("pk_Fac_ID", pk_Fac_ID);
                oHs.Add("pk_Cr_ID", pk_Cr_ID);
                oHs.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                oHs.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                oHs.Add("pk_Brn_ID", pk_Brn_ID);
                oHs.Add("pk_CrPr_Details_ID", pk_CrPr_Details_ID);
                oHs.Add("pk_AcademicYear_ID", pk_AcademicYear_ID);

                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_StudyCenterChange_SearchInstitute", oHs).Tables[0];
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
        #endregion

        #region InstituteSearch_ByAffiliatedCourse
        /// <summary>
        /// Seacrh student.
        /// </summary>
        /// <param name="oHs"></param>
        /// <returns></returns>
        public DataTable CheckIntakeCapacityForSCChange(string pk_Inst_ID, string pk_Fac_ID, string pk_Cr_ID, string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPr_Details_ID, string pk_CrPrCh_ID, string pk_AcademicYear_ID)
        {
            Hashtable oHs = new Hashtable();
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string uniID = clsGetSettings.UniversityID.Trim();
            try
            {
                oHs.Add("UniID", uniID);
                oHs.Add("NewRef_Pk_Institute_ID", pk_Inst_ID);
                oHs.Add("pk_Fac_ID", pk_Fac_ID);
                oHs.Add("pk_Cr_ID", pk_Cr_ID);
                oHs.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                oHs.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                oHs.Add("pk_Brn_ID", pk_Brn_ID);
                oHs.Add("pk_CrPr_Details_ID", pk_CrPr_Details_ID);
                oHs.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                oHs.Add("pk_AcademicYear_ID", pk_AcademicYear_ID);

                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_StudyCenterChange_CheckIntakeCapacity", oHs).Tables[0];
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
        #endregion
    }
}
