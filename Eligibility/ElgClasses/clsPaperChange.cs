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
using System.Data;
using Classes;

namespace StudentRegistration.Eligibility.ElgClasses
{
    public class clsPaperChange
    {
        #region ListCoursePartWisePaperSubjectList

        public static DataTable PaperChange_ListCoursePartWisePaperSubjectMapping(Hashtable oHt)
        {
            DataTable table = new DataTable();
            DBObjectPool pool = null;
            DBObject db = null;

            try
            {
                pool = DBObjectPool.Instance;
                db = pool.AcquireDBObject();
                table = db.getparamdataset("ElgV2_PaperChange_ListCoursePartWisePaperSubjectMapping", oHt).Tables[0];
            }
            finally
            {
                pool.ReleaseDBObject(db);
            }
            return table;
        }


        #endregion

        #region PaperChange_ListPapers

        public static DataSet PaperChange_ListPapers(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID, string crPrSeq, string crPrChSeq, string StudentID, string StudentYear)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable oHs = new Hashtable();
                oHs.Add("UniID", UniID);
                oHs.Add("InstID", InstID);
                oHs.Add("FacID", FacID);
                oHs.Add("CrID", CrID);
                oHs.Add("MoLrnID", MoLrnID);
                oHs.Add("PtrnID", PtrnID);
                oHs.Add("BrnID", BrnID);
                oHs.Add("CrPrDetailsID", CrPrDetailsID);
                oHs.Add("CrPrChID", CrPrChID);
                oHs.Add("CrPrSeq", crPrSeq);
                oHs.Add("CrPrChSeq", crPrChSeq);
                oHs.Add("StudentID", StudentID);
                oHs.Add("StudentYear", StudentYear);

                DataSet ds = oDB.getparamdataset("ELGV2_PaperChange_ListCoursePartTermStudentWiseAllPapers", oHs);
                return ds;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region PaperChange_TotalPapers

        public static DataTable PaperChange_TotalPapers(string UniID, string CrPrDetailsID, string CrPrChID)
        {

            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable oHs = new Hashtable();
                oHs.Add("UniID", UniID);
                oHs.Add("CrPrDetailsID", CrPrDetailsID);
                oHs.Add("CrPrChID", CrPrChID);


                DataTable DT = oDB.getparamdataset("ELGV2_PaperChange_TotalPapers", oHs).Tables[0];

                return DT;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region PaperChange_ListofPreviousPapersOfStudent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UniID"></param>
        /// <param name="InstID"></param>
        /// <param name="FacID"></param>
        /// <param name="CrID"></param>
        /// <param name="MoLrnID"></param>
        /// <param name="PtrnID"></param>
        /// <param name="BrnID"></param>
        /// <param name="CrPrDetailsID"></param>
        /// <param name="CrPrChID"></param>
        /// <param name="StudentID"></param>
        /// <returns></returns>
        public static DataTable PaperChange_ListofPreviousPapersOfStudent(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrDetailsID, string CrPrChID, string StudentID, string StudentYear)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable oHs = new Hashtable();
                oHs.Add("UniID", UniID);
                oHs.Add("InstID", InstID);
                oHs.Add("FacID", FacID);
                oHs.Add("CrID", CrID);
                oHs.Add("MoLrnID", MoLrnID);
                oHs.Add("PtrnID", PtrnID);
                oHs.Add("BrnID", BrnID);
                oHs.Add("CrPrDetailsID", CrPrDetailsID);
                oHs.Add("CrPrChID", CrPrChID);
                oHs.Add("StudentID", StudentID);
                oHs.Add("StudentYear", StudentYear);

                DataTable DT = oDB.getparamdataset("ElgV2_PaperChange_ListofPreviousPapersOfStudent", oHs).Tables[0];
                return DT;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region ListStudentWisePaperPreRequisiteDetails

        public static DataTable PaperChange_ListStudentWisePaperPreRequisiteDetails(Hashtable oHt)
        {
            DataTable table = new DataTable();
            DBObjectPool pool = null;
            DBObject db = null;
            try
            {
                pool = DBObjectPool.Instance;
                db = pool.AcquireDBObject();
                table = db.getparamdataset("ELGV2_PaperChange_ListStudentWisePaperPreRequisiteDetails", oHt).Tables[0];
            }
            finally
            {
                pool.ReleaseDBObject(db);
            }
            return table;
        }


        #endregion

        #region SaveChangedPapers
        public static string SaveChangedPapers(Hashtable ht)
        {
            string StatusFlag = "S";
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                SqlCommand cmd = new SqlCommand();
                cmd = oDB.GenerateCommand("ELGV2_PaperChange_SaveChangedPapers", ht);
                cmd.ExecuteNonQuery();
                StatusFlag = cmd.Parameters["@StatusFlag"].Value.ToString();

                cmd.Dispose();
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                StatusFlag = "U";

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return StatusFlag;
        }
        #endregion

        #region Check if Paper Change is allowed
        public static DataTable IsPaperChangeAllowed(Hashtable ht)
        {
            DataTable dt=new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();                
                //SqlCommand cmd = new SqlCommand();
                dt = oDB.getparamdataset("ELGV2_PaperChange_ListSingleStudent", ht).Tables[0];
                //StatusFlag = int.Parse(cmd.Parameters["@Result"].Value.ToString());               

              //  cmd.Dispose();
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                //StatusFlag = 0;

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }
        #endregion

        #region Send Exam Form Modify Request
        public static string SendExamFormModifyRequest(Hashtable ht)
        {
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string StatusFlag = "S";
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                SqlCommand cmd = new SqlCommand();
                cmd = oDB.GenerateCommand("ELGV2_PaperChange_AddExamFormModifyRequest", ht);
                cmd.ExecuteNonQuery();
                StatusFlag = cmd.Parameters["@StatusFlag"].Value.ToString();
                cmd.Dispose();
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                StatusFlag = "U";

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return StatusFlag;
        }
        #endregion


        #region Send Exam Form Modify Request (To be sent after paper exemption approval)
        public static string SendExamFormModifyRequest_PaperExemptionApproval(Hashtable ht)
        {
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string StatusFlag = "S";
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                SqlCommand cmd = new SqlCommand();
                cmd = oDB.GenerateCommand("ELGV2_PaperExemptionApproval_AddExamFormModifyRequest", ht);
                cmd.ExecuteNonQuery();
                StatusFlag = cmd.Parameters["@StatusFlag"].Value.ToString();
                cmd.Dispose();
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                StatusFlag = "U";

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return StatusFlag;
        }
        #endregion
        //---------------------------------------------------------------------------------------------------

        // Method to Add Exam Form Modify Request for multiple students
        public static string SendExamFormModifyRequest_PaperExemptionApproval_MultipleStuds(string oExamFormModifyRequest)
        { 
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string TFlag;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                SqlCommand cmd = new SqlCommand();
                // MySQL related change - SP name should be having less than 64 characters
                //cmd = oDB.GenerateCommand("ELGV2_PaperExemptionApproval_AddExamFormModifyRequest_MultipleStudents", ht);
                cmd = oDB.GenerateCommand("ELGV2_PpExmpApproval_AddExamFormModifyRequest_MultipleStudents", ht);

                cmd.Parameters.RemoveAt("@FormModifyRequestsXML");
                cmd.Parameters.Add("@FormModifyRequestsXML", SqlDbType.Xml);
                cmd.Parameters["@FormModifyRequestsXML"].Value = oExamFormModifyRequest;
                cmd.ExecuteNonQuery();
                TFlag = cmd.Parameters["@StatusFlag"].Value.ToString();

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

        #region List Student Course Part term (added by garima 5 sep 2011)
        public static DataTable ListStudentCoursePartTerm(Hashtable ht)
        {
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();               
                dt = oDB.getparamdataset("ELGV2_PaperChange_ListStudentCoursePartTerms", ht).Tables[0];             
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex); 
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }
        #endregion

        #region Function to List all the Previous Course Part of selected Course Part
        /// <summary>
        /// This will List All the Previous Course Part of Selected Course Part
        /// i.e If TYBA is selected then it will list FYBA and SYBA
        /// </summary>
        /// <param name="pk_Uni_ID"></param>
        /// <param name="pk_Institute_ID"></param>
        /// <param name="pk_Year"></param>
        /// <param name="pk_Student_ID"></param>
        /// <param name="pk_Fac_ID"></param>
        /// <param name="pk_Cr_ID"></param>
        /// <param name="pk_MoLrn_ID"></param>
        /// <param name="pk_Ptrn_ID"></param>
        /// <param name="pk_Brn_ID"></param>
        /// <param name="pk_CrPr_Details_ID"></param>
        /// <param name="pk_CrPrCh_ID"></param>
        /// <returns></returns>
        public static DataTable Get_Previous_CoursePartDetails(string pk_Uni_ID, string pk_Institute_ID, string pk_Year, string pk_Student_ID, string pk_Fac_ID, string pk_Cr_ID, string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPr_Details_ID, string pk_CrPrCh_ID, string PRN_Number)
        {
            DataTable oDt = new DataTable();
            Hashtable oHt = new Hashtable();

            oHt.Add("pk_Uni_ID", pk_Uni_ID);
            oHt.Add("pk_Institute_ID", pk_Institute_ID);
            oHt.Add("pk_Year", pk_Year);
            oHt.Add("pk_Student_ID", pk_Student_ID);
            oHt.Add("pk_Fac_ID", pk_Fac_ID);
            oHt.Add("pk_Cr_ID", pk_Cr_ID);
            oHt.Add("pk_MoLrn_ID", pk_MoLrn_ID);
            oHt.Add("pk_Ptrn_ID", pk_Ptrn_ID);
            oHt.Add("pk_Brn_ID", pk_Brn_ID);
            oHt.Add("pk_CrPr_Details_ID", pk_CrPr_Details_ID);
            oHt.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
            oHt.Add("PRN_Number", PRN_Number);

            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                oDt = oDB.getparamdataset("ELGV2_Get_Previous_CoursePartDetails", oHt).Tables[0];
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return oDt;
        }
        #endregion

        #region Function List Additional Papers Opted by Student
        /// <summary>
        /// This will List All the Additional Papers Opted by Student for different Course Part
        /// </summary>
        /// <param name="oHS"></param>
        /// <returns></returns>
        public static DataTable List_AdditionalPapers_Opted_by_Student(Hashtable oHS)
        {
            DataTable oDt = new DataTable();

            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                oDt = oDB.getparamdataset("ELGV2_List_AdditionalPapers_Opted_by_Student", oHS).Tables[0];
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return oDt;
        }
        #endregion

        #region Function to Remove Addiotnal Papers opted by student
        /// <summary>
        /// This will Remove the Addiotnal Papers that are Opted by student
        /// </summary>
        /// <param name="oHt"></param>
        /// <returns></returns>
        public static string Remove_AdditionalPapers(Hashtable oHt)
        {
            string flag;
            SqlCommand cmd;
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                oHt.Add("Status_Out", ParameterDirection.Output);
                cmd = oDB.GenerateCommand("ELGV2_Remove_AdditionalPapers", oHt);
                cmd.ExecuteNonQuery();
                flag = cmd.Parameters["@Result_Out"].Value.ToString();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return flag;
        }
        #endregion

        #region GetOptedPaper of Student

        public static DataTable GetOptedPaper(Hashtable ohs)
        {
            DataTable dt = new DataTable();

            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_GetStudentOptedPapers", ohs).Tables[0];
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region GetAdditionalPaper of Student

        public static DataTable GetAdditionalPaper(Hashtable ohs)
        {
            DataTable dt = new DataTable();

            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_GetStudentAdditionalPapers", ohs).Tables[0];
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Add Students Additional Papers
        /// <summary>
        /// Insert Students Course Part wise Selected Papers
        /// </summary>
        /// <param name="oHt">Hashtable</param>
        /// <returns>Datatable</returns>
        public static string AddStudentAdditionalPapers(Hashtable oHt)
        {
            string flag;
            SqlCommand cmd;
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                oHt.Add("Status_Out", ParameterDirection.Output);
                cmd = oDB.GenerateCommand("ELGV2_Add_StudentAdditionalPapers", oHt);
                cmd.ExecuteNonQuery();
                flag = cmd.Parameters["@Result_Out"].Value.ToString();
            }
            catch(Exception ppEx)
            {
                flag = ppEx.Message;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return flag;
        }
        #endregion

        #region Get Course Name

        /// <summary>
        /// Get Course Name
        /// </summary>
        /// <param name="oHt">Hashtable</param>
        /// <returns>DataTable</returns>
        public static string GetCourseName(Hashtable oHt)
        {
            string sCourseName = string.Empty;
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_Get_SelectedCourseDetails", oHt).Tables[0];
                if (dt.Rows.Count > 0)
                    sCourseName = dt.Rows[0]["CourseName"].ToString();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return sCourseName;
        }
        #endregion 

        #region GetPaperName
        /// <summary>
        /// Get Paper Name
        /// </summary>
        /// <param name="oHt">Hashtable</param>
        /// <returns>String</returns>
        public string GetPaperName(string sPpID)
        {
            string sPaperName = string.Empty;
            DataTable dt = new DataTable();
            Hashtable oHt = new Hashtable();
            oHt.Add("PpIDList", sPpID);
            System.Xml.XmlReader oR = null;
            System.Text.StringBuilder oS = new System.Text.StringBuilder();
            DBObjectPool Pool = null;
            Pool = DBObjectPool.Instance;
            DBObject oDB = Pool.AcquireDBObject();
            try
            {
                System.Data.SqlClient.SqlCommand cmd = oDB.GenerateCommand("ELGV2_Get_PpName", oHt);
                oR = cmd.ExecuteXmlReader();
                while (!oR.EOF)
                {
                    if (oR.IsStartElement())
                    {
                        oS.Append(oR.ReadOuterXml());
                        oS.Append(Environment.NewLine);
                    }
                }
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return oS.ToString();
        }


        #endregion

        #region ListValidationGroup

        public DataSet ListValidationGroup(string UniID, string CrPrDetailsID, string CrPrChID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable oHs = new Hashtable();
                oHs.Add("UniID", UniID);               
                oHs.Add("CrPrDetailsID", CrPrDetailsID);
                oHs.Add("CrPrChID", CrPrChID);           

                DataSet ds = oDB.getparamdataset("ELGV2_GetValidationsGroups", oHs);
                return ds;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region Function to List all the Previous Course Part of selected Course Part for Additional Paper Change
        /// <summary>
        /// This will List All the Previous Course Part of Selected Course Part
        /// i.e If TYBA is selected then it will list FYBA and SYBA

        public DataTable Get_Previous_CoursePartDetailsforAddPaperChange(string pk_Uni_ID, string pk_Inst_ID, string pk_Year, string pk_Student_ID, string pk_Fac_ID, string pk_Cr_ID, string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPr_Details_ID, string pk_CrPrCh_ID, string PRN_Number)
        {
            DataTable oDt = new DataTable();
            Hashtable oHt = new Hashtable();

            oHt.Add("pk_Uni_ID", pk_Uni_ID);
            oHt.Add("pk_Institute_ID", pk_Inst_ID);
            oHt.Add("pk_Year", pk_Year);
            oHt.Add("pk_Student_ID", pk_Student_ID);
            oHt.Add("pk_Fac_ID", pk_Fac_ID);
            oHt.Add("pk_Cr_ID", pk_Cr_ID);
            oHt.Add("pk_MoLrn_ID", pk_MoLrn_ID);
            oHt.Add("pk_Ptrn_ID", pk_Ptrn_ID);
            oHt.Add("pk_Brn_ID", pk_Brn_ID);
            oHt.Add("pk_CrPr_Details_ID", pk_CrPr_Details_ID);
            oHt.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
            oHt.Add("PRN_Number", PRN_Number);

            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                //oDB.ThisConnectionFor = DBConnection.DCWrite;
                oDt = oDB.getparamdataset("ELGV2_PreCoursePart_ForAddPaperChange", oHt).Tables[0];
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return oDt;
        }
        #endregion

        #region Function List Additional Papers Opted by Student For Additional Paper Change
        /// <summary>
        /// This will List All the Additional Papers Opted by Student for different Course Part
        /// </summary>
        /// <param name="oHS"></param>
        /// <returns></returns>
        public DataTable DisAddpaperOpted_ForAddPaperChange(Hashtable oHSa)
        {
            DataTable oDt = new DataTable();

            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                oDt = oDB.getparamdataset("ELGV2_List_AdditionalPapers_ForAddPaperChange", oHSa).Tables[0];
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return oDt;
        }
        #endregion

        #region Function to Remove Addiotnal Papers opted by student for Add Paper Change
        /// <summary>
        /// This will Remove the Addiotnal Papers that are Opted by student for Add Paper Change
        /// </summary>
        /// <param name="oHt"></param>
        /// <returns></returns>
        public string Remove_AdditionalPapersForAddPaperChange(Hashtable oHt)
        {
            string flag;
            SqlCommand cmd;
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                oHt.Add("Status_Out", ParameterDirection.Output);
                cmd = oDB.GenerateCommand("ELGV2_Remove_AdditionalPapers_ForAddPaperChange", oHt);
                cmd.ExecuteNonQuery();
                flag = cmd.Parameters["@Result_Out"].Value.ToString();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return flag;
        }
        #endregion

        #region Get Course Name

        /// <summary>
        /// Get Course Name
        /// </summary>
        /// <param name="oHt">Hashtable</param>
        /// <returns>DataTable</returns>
        public static string GetCourseNameForAddPaperChange(Hashtable oHt)
        {
            string sCourseName = string.Empty;
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_Get_SelectedCourseDetailsForAddPaperChange", oHt).Tables[0];
                if (dt.Rows.Count > 0)
                    sCourseName = dt.Rows[0]["CourseName"].ToString();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return sCourseName;
        }
        #endregion 

        #region GetAdditionalPaper of Student For Add Paper Change

        public static DataTable GetAdditionalPaperForAddPaperChange(Hashtable OHt)
        {
            DataTable dt = new DataTable();

            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("REGD_GetStudentAdditionalPapersForAddPaperChange", OHt).Tables[0];
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;
        }

        #endregion

        #region Add Students Additional Papers For Add Paper Change
        /// <summary>
        /// Insert Students Course Part wise Selected Papers
        /// </summary>
        /// <param name="oHt">Hashtable</param>
        /// <returns>Datatable</returns>
        public string AddStudentAdditionalPapersForAddPaperChange(Hashtable oHt)
        {
            string flag;
            SqlCommand cmd;
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject(); 
                oHt.Add("Status_Out", ParameterDirection.Output);
                cmd = oDB.GenerateCommand("ELGV2_Add_StudentAdditionalPapersForAddPaperChange", oHt);
                cmd.ExecuteNonQuery();
                flag = cmd.Parameters["@Result_Out"].Value.ToString();
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return flag;
        }
        #endregion

        #region Add Selected Additional Paper Fo rAdd Paper Change
        /// <summary>
        /// Add Selected Additional Paper Fo rAdd Paper Change
        /// </summary>
        /// <param name="oHT">Hashtable</param>
        /// <returns>string</returns>
        public string AddSelectedAdditionalPaperForAddPaperChange(Hashtable oHt)
        {
            string flag;
            SqlCommand cmd;
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                cmd = oDB.GenerateCommand("ELGV2_Add_StudentAdditionalPapersForAddPaperChange", oHt);
                cmd.ExecuteNonQuery();
                flag = cmd.Parameters["@Result_Out"].Value.ToString();

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return flag;
        }
        #endregion
    }
}
