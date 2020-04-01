using System;
using System.Data.SqlClient;
using System.Data;
using Classes;
using System.Configuration;
using UniversityPortal;
using System.Collections;

namespace StudentRegistration.Eligibility
{
	/// <summary>
	/// Summary description for clsEligibilityDBAccess.
	/// </summary>
    
	public class clsEligibilityDBAccess 
	{
		public clsEligibilityDBAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Farhat
		
		#region Search for Student on Elg Form No

		/// <summary>
		/// This function is to check whether the Eligibility Form Number given , exists in the IA table.
		/// </summary>
		/// <param name="pk_Uni_ID"></param>
		/// <param name="pk_Year"></param>
		/// <param name="pk_Institute_ID"></param>
		/// <param name="pk_Student_ID"></param>
		/// <returns>0 if No Matching Record , 1 if there exists a matching record</returns>

        //public static DataSet Check_IA_Student_Exists(string pk_Uni_ID, string pk_Institute_ID, string pk_Year, string pk_Student_ID, string InstID, string ApplicationFormNo)
        //{	
        //    //int iFlag = 0;
        //    Hashtable ht =  new Hashtable();
        //    //SqlCommand cmd = new SqlCommand();
        //    DBObjectPool Pool = null;
        //    DBObject oDB = null;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        Pool = DBObjectPool.Instance;
        //        oDB = Pool.AcquireDBObject();
        //        ht.Add("RefUniID", pk_Uni_ID);
        //        ht.Add("RefInstID", pk_Institute_ID);
        //        ht.Add("RefYearID", pk_Year);
        //        ht.Add("RefStudentID", pk_Student_ID);
        //        ht.Add("InstID", InstID);
        //        ht.Add("ApplicationFormNo", ApplicationFormNo);
        //        //ht.Add("Flag",iFlag);
        //        //cmd = oDB.GenerateCommand("ELGV2_Check_Reg_Student_Exists", ht);
        //        //cmd.Parameters["@Flag"].Direction  = ParameterDirection.Output;
        //        //cmd.ExecuteNonQuery();
        //        //iFlag = Convert.ToInt32(cmd.Parameters["@Flag"].Value.ToString());
        //        ds = oDB.getparamdataset("ELGV2_Check_Reg_Student_Exists", ht);
        //        return ds;
                			
        //    }
        //    catch(Exception Ex)
        //    {
        //        throw (Ex);
			  			
        //    }
        //    finally
        //    {
        //        Pool.ReleaseDBObject(oDB);
        //    }
			

        //}

        public static DataSet Check_IA_Student_Exists_bypassInv(string pk_Uni_ID, string pk_Institute_ID, string pk_Year, string pk_Student_ID, string InstID, string ApplicationFormNo)
        {
            //int iFlag = 0;
            Hashtable ht = new Hashtable();
            //SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet ds = new DataSet();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("RefUniID", pk_Uni_ID);
                ht.Add("RefInstID", pk_Institute_ID);
                ht.Add("RefYearID", pk_Year);
                ht.Add("RefStudentID", pk_Student_ID);
                ht.Add("InstID", InstID);
                ht.Add("ApplicationFormNo", ApplicationFormNo);
                //ht.Add("Flag",iFlag);
                //cmd = oDB.GenerateCommand("ELGV2_Check_Reg_Student_Exists", ht);
                //cmd.Parameters["@Flag"].Direction  = ParameterDirection.Output;
                //cmd.ExecuteNonQuery();
                //iFlag = Convert.ToInt32(cmd.Parameters["@Flag"].Value.ToString());
                ds = oDB.getparamdataset("ELGV2_Check_Reg_Student_Exists_bypassInv", ht);
                return ds;

            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }


        }

        //public static DataSet Check_IA_Student_Exists_RegStu(string pk_Uni_ID, string pk_Institute_ID, string pk_Year, string pk_Student_ID, string prn, string InstID, string AppFormNo)
        //{
        //    //int iFlag = 0;
        //    Hashtable ht = new Hashtable();
        //    //SqlCommand cmd = new SqlCommand();
        //    DBObjectPool Pool = null;
        //    DBObject oDB = null;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        Pool = DBObjectPool.Instance;
        //        oDB = Pool.AcquireDBObject();
        //        ht.Add("RefUniID", pk_Uni_ID);
        //        ht.Add("RefInstID", pk_Institute_ID);
        //        ht.Add("RefYearID", pk_Year);
        //        ht.Add("RefStudentID", pk_Student_ID);
        //        ht.Add("PRN", prn);
        //        ht.Add("InstituteID", InstID);
        //        ht.Add("ApplicationFormNo", AppFormNo);
        //        //ht.Add("Flag",iFlag);
        //        //cmd = oDB.GenerateCommand("ELGV2_Check_Reg_Student_Exists", ht);
        //        //cmd.Parameters["@Flag"].Direction  = ParameterDirection.Output;
        //        //cmd.ExecuteNonQuery();
        //        //iFlag = Convert.ToInt32(cmd.Parameters["@Flag"].Value.ToString());
        //        ds = oDB.getparamdataset("ELGV2_Check_Reg_Student_Exists_RegStu", ht);
        //        return ds;

        //    }
        //    catch (Exception Ex)
        //    {
        //        throw (Ex);

        //    }
        //    finally
        //    {
        //        Pool.ReleaseDBObject(oDB);
        //    }

        //}

        public static DataSet Check_IA_Student_Exists_bypassInv_RegStu(string pk_Uni_ID, string pk_Institute_ID, string pk_Year, string pk_Student_ID, string prn, string InstID, string AppFormNo)
        {
            //int iFlag = 0;
            Hashtable ht = new Hashtable();
            //SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet ds = new DataSet();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("RefUniID", pk_Uni_ID);
                ht.Add("RefInstID", pk_Institute_ID);
                ht.Add("RefYearID", pk_Year);
                ht.Add("RefStudentID", pk_Student_ID);
                ht.Add("PRN", prn);
                ht.Add("InstituteID", InstID);
                ht.Add("ApplicationFormNo", AppFormNo);
                //ht.Add("Flag",iFlag);
                //cmd = oDB.GenerateCommand("ELGV2_Check_Reg_Student_Exists", ht);
                //cmd.Parameters["@Flag"].Direction  = ParameterDirection.Output;
                //cmd.ExecuteNonQuery();
                //iFlag = Convert.ToInt32(cmd.Parameters["@Flag"].Value.ToString());
                ds = oDB.getparamdataset("ELGV2_Check_Reg_Student_Exists_RegStu_bypassInv", ht);
                return ds;

            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }


        }

		/// <summary>
		/// This function checks whether there is any student whose eligibility is kept pending 
		/// that matches with the Eligibility Form Number in REG tables.
		/// </summary>
		/// <param name="Ref_pk_Uni_ID"></param>
		/// <param name="Ref_pk_Year"></param>
		/// <param name="Ref_pk_Institute_ID"></param>
		/// <param name="Ref_pk_Student_ID"></param>
        /// <returns>Dataset</returns>

        #region Check_Reg_Pending_Student_Exists for Unregistered Students

        public static DataSet Check_Reg_Pending_Student_Exists(string Ref_pk_Uni_ID, string Ref_pk_Institute_ID, string Ref_pk_Year, string Ref_pk_Student_ID, string InstID, string AppFormNo)
		{
			DataSet ds = new DataSet();
			Hashtable ht = new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("Ref_pk_Uni_ID",Ref_pk_Uni_ID);
                ht.Add("Ref_pk_Institute_ID", Ref_pk_Institute_ID);
				ht.Add("Ref_pk_Year",Ref_pk_Year);
				ht.Add("Ref_pk_Student_ID",Ref_pk_Student_ID);
                ht.Add("InstituteID", InstID);
                ht.Add("ApplicationFormNo", AppFormNo);
                ds = oDB.getparamdataset("elgV2_Check_Reg_Pending_Student_Exists", ht);
				return ds;
                
			}
			
			catch(Exception Ex)
			{
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}

        }

        #endregion

        #endregion


        #region Check_Reg_Pending_Student_Exists_RegStu for Registered Students

        public static DataSet Check_Reg_Pending_Student_Exists_RegStu(string Ref_pk_Uni_ID, string Ref_pk_Institute_ID, string Ref_pk_Year, string Ref_pk_Student_ID, string PRN, String InstID, string AppFormNo)
        {
			DataSet ds = new DataSet();
			Hashtable ht = new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("Ref_pk_Uni_ID",Ref_pk_Uni_ID);
                ht.Add("Ref_pk_Institute_ID", Ref_pk_Institute_ID);
				ht.Add("Ref_pk_Year",Ref_pk_Year);
				ht.Add("Ref_pk_Student_ID",Ref_pk_Student_ID);
                ht.Add("PRN", PRN);
                ht.Add("InstituteID", InstID);
                ht.Add("ApplicationFormNo", AppFormNo);
                ds = oDB.getparamdataset("ELGV2_Check_Reg_Pending_Student_Exists_RegStu", ht);
				return ds;
                
			}
			
			catch(Exception Ex)
			{
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}

        /// <summary>
		/// This function checks whether there is any student whose eligibility is kept provisional 
		/// that matches with the Eligibility Form Number in REG tables.
		/// </summary>
		/// <param name="Ref_pk_Uni_ID"></param>
		/// <param name="Ref_pk_Year"></param>
		/// <param name="Ref_pk_Institute_ID"></param>
		/// <param name="Ref_pk_Student_ID"></param>
        /// <returns>Dataset</returns>

        #endregion

        #region List Colleges

        [Ajax.AjaxMethod()]
        public DataTable ListColleges(int UniID)
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            DBObjectPool pool = null;
            DBObject oDB = null;
            try
            {
                pool = DBObjectPool.Instance;
                oDB = pool.AcquireDBObject();
                ht.Add("UniID", UniID);
                ds = oDB.getparamdataset("ELGV2_ListColleges", ht);
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);

            }
            finally
            {
                pool.ReleaseDBObject(oDB);
            }
            return ds.Tables[0];

        }

        #endregion


        #region Check_Reg_Provisional_Student_Exists for Unregistered Students
        public static DataSet CheckRegNtElgStudentExists(string Ref_pk_Uni_ID, string Ref_pk_Institute_ID, string Ref_pk_Year, string Ref_pk_Student_ID, string prn, string InstID, string AppFormNo)
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Ref_pk_Uni_ID", Ref_pk_Uni_ID);
                ht.Add("Ref_pk_Institute_ID", Ref_pk_Institute_ID);
                ht.Add("Ref_pk_Year", Ref_pk_Year);
                ht.Add("Ref_pk_Student_ID", Ref_pk_Student_ID);
                ht.Add("PRN", prn);
                ht.Add("InstituteID", InstID);
                ht.Add("ApplicationFormNo", AppFormNo);
                ds = oDB.getparamdataset("elgV2_Check_Reg_NtElg_Student_Exists", ht);
                return ds;

            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }
        public static DataSet Check_Reg_Provisional_Student_Exists(string Ref_pk_Uni_ID, string Ref_pk_Institute_ID, string Ref_pk_Year, string Ref_pk_Student_ID, string prn, string InstID, string AppFormNo)
		{
			DataSet ds = new DataSet();
			Hashtable ht = new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("Ref_pk_Uni_ID",Ref_pk_Uni_ID);
                ht.Add("Ref_pk_Institute_ID", Ref_pk_Institute_ID);
				ht.Add("Ref_pk_Year",Ref_pk_Year);
				ht.Add("Ref_pk_Student_ID",Ref_pk_Student_ID);
                ht.Add("PRN", prn);
                ht.Add("InstituteID", InstID);
                ht.Add("ApplicationFormNo", AppFormNo);
                ds = oDB.getparamdataset("ELGV2_Check_Reg_ProvisionallyEligible_Student_Exists", ht);
				return ds;
                
			}
			
			catch(Exception Ex)
			{
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}

        }

        #endregion

        #region Check_Reg_Provisional_Student_Exists for Registered Students

        public static DataSet Check_Reg_Provisional_Student_Exists_RegStu(string Ref_pk_Uni_ID, string Ref_pk_Institute_ID, string Ref_pk_Year, string Ref_pk_Student_ID, string prn, string InstID)
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Ref_pk_Uni_ID", Ref_pk_Uni_ID);
                ht.Add("Ref_pk_Institute_ID", Ref_pk_Institute_ID);
                ht.Add("Ref_pk_Year", Ref_pk_Year);
                ht.Add("Ref_pk_Student_ID", Ref_pk_Student_ID);
                ht.Add("PRN", prn);
                ht.Add("InstituteID", InstID);
                ds = oDB.getparamdataset("ELGV2_Check_Reg_ProvisionallyEligible_Student_Exists_RegStu", ht);
                return ds;

            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }

        #endregion

        #endregion

        #region Fetch_IA_Student_List_Configure

        public static DataSet Fetch_IA_Student_List_Configure(string Uni_ID, string Inst_ID,string FacultyID, string CourseID, string CrMoLrnPtrnID, string CrPrID, string DOB, string LastName, string FirstName, string Gender)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("pk_Inst_ID", Inst_ID);
                ht.Add("FacultyID", FacultyID);
                ht.Add("CrID", CourseID);
                ht.Add("CrMoLrnPtrnID", CrMoLrnPtrnID);
                ht.Add("CrPrID", CrPrID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ds = oDB.getparamdataset("elg_Fetch_IA_StudentList_Configure", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region Search for Student List

        /// <summary>
		/// This function is used to fetch the list of students whose data has uploaded for eligibility processing.
		/// The search will be based on the filtering conditions in the Advanced Search control.
		/// The Search will be in IA tables.
		/// </summary>
		/// <param name="Uni_ID"></param>
		/// <param name="InstTy_ID"></param>
		/// <param name="Inst_Name"></param>
		/// <param name="Inst_State_ID"></param>
		/// <param name="Inst_District_ID"></param>
		/// <param name="Inst_Tehsil_ID"></param>
		/// <param name="FacultyID"></param>
		/// <param name="CourseID"></param>
		/// <param name="CrMoLrnPtrnID"></param>
		/// <param name="CrPrID"></param>
		/// <param name="DOB"></param>
		/// <param name="LastName"></param>
		/// <param name="FirstName"></param>
		/// <param name="Gender"></param>
		/// <returns>DataSet</returns>
       
        public static DataSet Fetch_IA_Student_List(string Uni_ID, string InstTy_ID, string Inst_Name, string Inst_State_ID, string Inst_District_ID, string Inst_Tehsil_ID, string FacultyID, string CourseID, string CrMoLrnPtrnID, string CrPrID, string DOB, string LastName, string FirstName, string Gender)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("InstTy_ID", InstTy_ID);
                ht.Add("Inst_Name", Inst_Name);
                ht.Add("Inst_State_ID", Inst_State_ID);
                ht.Add("Inst_District_ID", Inst_District_ID);
                ht.Add("Inst_Tehsil_ID", Inst_Tehsil_ID);
                ht.Add("FacultyID", FacultyID);
                ht.Add("CrID", CourseID);
                ht.Add("CrMoLrnPtrnID", CrMoLrnPtrnID);
                ht.Add("CrPrID", CrPrID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ds = oDB.getparamdataset("elg_Fetch_IA_StudentList", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #region Fetch_Reg_Student_List for Unregistered Students

        public static DataSet Fetch_Reg_Student_List(string Uni_ID, string InstTy_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string ElgCollStatus, string AcademicYrID)
		{
			DataSet ds = new DataSet();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				Hashtable ht=new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", InstTy_ID);
                ht.Add("FacID",FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
              //  ht.Add("CrPrDetailsID", CrPrDetailsID);               
               	ht.Add("DOB",DOB);
				ht.Add("LastName",LastName);
				ht.Add("FirstName",FirstName);
				ht.Add("Gender",Gender);
                ht.Add("ElgStatusColl", ElgCollStatus);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_StudentList_Configure", ht);
				return ds;
			}
			
			catch(Exception Ex)
			{
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}

        public static DataSet PaperExempt_StudentList_CourseWise(string Uni_ID, string InstTy_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string AcademicYrID)
		{
			DataSet ds = new DataSet();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				Hashtable ht=new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", InstTy_ID);
                ht.Add("FacID",FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);                          
               	ht.Add("DOB",DOB);
				ht.Add("LastName",LastName);
				ht.Add("FirstName",FirstName);
				ht.Add("Gender",Gender);                
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ds = oDB.getparamdataset("ELGV2_PaperExempt_StudentList_CourseWise", ht);
				return ds;
			}
			
			catch(Exception Ex)
            {
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}

        public static DataSet Fetch_Reg_Student_List_ExamBody(string Uni_ID, string InstTy_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string ElgCollStatus, string StateID, string BodyID, string AcademicYrID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", InstTy_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                //  ht.Add("CrPrDetailsID", CrPrDetailsID);                
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("ElgStatusColl", ElgCollStatus);
                ht.Add("Body_State", StateID);
                ht.Add("Body_ID", BodyID);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);


                ds = oDB.getparamdataset("ELGV2_Fetch_REG_StudentList_Configure__ExamBody", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Fetch_Reg_Student_List_ExamBody_Foreign(string Uni_ID, string InstTy_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string ElgCollStatus, string StateID, string BodyID, string AcademicYrID, string BodyCountryID, string ForeignBoardUnivName)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", InstTy_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                //  ht.Add("CrPrDetailsID", CrPrDetailsID);                
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("ElgStatusColl", ElgCollStatus);                
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ht.Add("Body_Country", BodyCountryID);
                ht.Add("Other_Body_Name", ForeignBoardUnivName);
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_StudentList_Configure__ExamBody_Foreign", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Fetch_Reg_Student_List_bypassInv_ExamBody(string Uni_ID, string InstTy_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string ElgCollStatus, string StateID, string BodyID, string AcademicYrID)
        {
            DataSet ds = new DataSet();
           
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", InstTy_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
             //   ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("ElgStatusColl", ElgCollStatus);
                ht.Add("Body_State", StateID);
                ht.Add("Body_ID", BodyID);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_StudentList_Configure_bypassInv__ExamBody", ht);
                         
               return ds;              
       }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Fetch_Reg_Student_List_bypassInv_ExamBody_Foreign(string Uni_ID, string InstTy_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string ElgCollStatus, string StateID, string BodyID, string AcademicYrID, string BodyCountryID, string ForeignBoardUnivName)
        {
            DataSet ds = new DataSet();

            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", InstTy_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                //   ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("ElgStatusColl", ElgCollStatus);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ht.Add("Body_Country", BodyCountryID);
                ht.Add("Other_Body_Name", ForeignBoardUnivName);
                
                // MySQL related change - SP name should be having less than 64 characters
                //ds = oDB.getparamdataset("ELGV2_Fetch_REG_StudentList_Configure_bypassInv__ExamBody_Foreign", ht);
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_StudentList_Configure_bypassInv_ExamBodyForeign", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        public static DataSet Fetch_Reg_Student_List_bypassInv(string Uni_ID, string InstTy_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string ElgCollStatus, string AcademicYrID)
        {
            DataSet ds = new DataSet();

            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", InstTy_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                //   ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("ElgStatusColl", ElgCollStatus);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_StudentList_Configure_bypassInv", ht);

                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex); 

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }


        #region Fetch_Reg_Student_List for registered Students

        public static DataSet Fetch_Reg_Student_List_RegStu(string Uni_ID, string InstTy_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string ElgCollStatus, string AcademicYrID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", InstTy_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
               // ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("ElgStatusColl", ElgCollStatus);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_StudentList_Configure_RegStu", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Fetch_Reg_Student_List_RegStu_bypassInv(string Uni_ID, string InstTy_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string ElgCollStatus, string AcademicYrID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", InstTy_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
             //   ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("ElgStatusColl", ElgCollStatus);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_StudentList_Configure_RegStu_bypassInv", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

    #endregion

        #region Fetch_Reg_Student_List for registered Students Having Exam Body

        public static DataSet Fetch_Reg_Student_List_RegStu_ExamBody(string Uni_ID, string InstTy_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string ElgCollStatus, string StateID, string BodyID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", InstTy_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                // ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("ElgStatusColl", ElgCollStatus);
                ht.Add("Body_State", StateID);
                ht.Add("Body_ID", BodyID);
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_StudentList_Configure_RegStu_ExamBody", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public static DataSet Fetch_Reg_Student_List_RegStu_bypassInv_ExamBody(string Uni_ID, string InstTy_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string ElgCollStatus, string StateID, string BodyID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", InstTy_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                //   ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("ElgStatusColl", ElgCollStatus);
                ht.Add("Body_State", StateID);
                ht.Add("Body_ID", BodyID);
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_StudentList_Configure_RegStu_bypassInv_ExamBody", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region Fetch_Pending_Reg_Student_List_Resolve
        public static DataSet Fetch_Pending_Reg_Student_List_Resolve(string Uni_ID, string RInst_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string AcademicYrID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", RInst_ID);                
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ds = oDB.getparamdataset("elgV2_Fetch_Pending_Reg_StudentList_Resolve", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Fetch_Pending_Reg_Student_List_Resolve1

        public static DataSet Fetch_Pending_Reg_Student_List_Resolve1(string Uni_ID, string RInst_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string AcademicYrID, string StateID, string BodyID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {

                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", RInst_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ht.Add("Body_State", StateID);
                ht.Add("Body_ID", BodyID);
                ds = oDB.getparamdataset("elgV2_Fetch_Pending_Reg_StudentList_Resolve_CUBI_ExamBody", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Fetch_Pending_Reg_Student_List_Resolve2

        public static DataSet Fetch_Pending_Reg_Student_List_Resolve2(string Uni_ID, string RInst_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string AcademicYrID, string BodyCountryID, string ForeignBoardUnivName)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", RInst_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ht.Add("Body_Country", BodyCountryID);
                ht.Add("Other_Body_Name", ForeignBoardUnivName);
                ds = oDB.getparamdataset("elgV2_Fetch_Pending_Reg_StudentList_Resolve_CUBIEB_Foreign", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Fetch_Pending_Reg_Student_List_Resolve_RegStu

        public static DataSet Fetch_Pending_Reg_Student_List_Resolve_RegStu(string Uni_ID, string RInst_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string AcademicYrID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", RInst_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
              //  ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ds = oDB.getparamdataset("elgV2_Fetch_Pending_Reg_StudentList_Resolve_RegStu", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Fetch Provisionally Eligible Reg Student List Resolve for Unregistered students

        #region Fetch_NotEligible_Reg_StudentList
        public static DataSet Fetch_NotEligible_Reg_StudentList(string Uni_ID, string RInst_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string AcademicYrID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", RInst_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                // ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ds = oDB.getparamdataset("elgV2_Fetch_NotEligible_Reg_StudentList", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region Fetch_ProvisionallyEligible_Reg_Student_List_Resolve
        public static DataSet Fetch_ProvisionallyEligible_Reg_Student_List_Resolve(string Uni_ID, string RInst_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string AcademicYrID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", RInst_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
               // ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ds = oDB.getparamdataset("elgV2_Fetch_ProvisionallyEligible_Reg_StudentList_Resolve", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Fetch_ProvisionallyEligible_Reg_Student_List_Resolve1

        public static DataSet Fetch_ProvisionallyEligible_Reg_Student_List_Resolve1(string Uni_ID, string RInst_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string AcademicYrID, string StateID, string BodyID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", RInst_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                // ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ht.Add("Body_State", StateID);
                ht.Add("Body_ID", BodyID);
                ds = oDB.getparamdataset("elgV2_Fetch_ProvEli_Reg_StuList_Resolve_CUBI_ExamBody", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Fetch_ProvisionallyEligible_Reg_Student_List_Resolve2

        public static DataSet Fetch_ProvisionallyEligible_Reg_Student_List_Resolve2(string Uni_ID, string RInst_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string AcademicYrID, string BodyCountryID, string ForeignBoardUnivName)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", RInst_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
                // ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ht.Add("Body_Country", BodyCountryID);
                ht.Add("Other_Body_Name", ForeignBoardUnivName);
                ds = oDB.getparamdataset("elgV2_Fetch_ProvEli_Reg_StuList_Resolve_CUBIEB_Foreign", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #endregion

        #region Fetch Provisionally Eligible Reg Student List Resolve for Registered students

        public static DataSet Fetch_ProvisionallyEligible_Reg_Student_List_Resolve_RegStu(string Uni_ID, string RInst_ID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string DOB, string LastName, string FirstName, string Gender, string AcademicYrID)
        {
            DataSet ds = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                Hashtable ht = new Hashtable();
                ht.Add("Uni_ID", Uni_ID);
                ht.Add("RefInst_ID", RInst_ID);
                ht.Add("FacID", FacID);
                ht.Add("CrID", CrID);
                ht.Add("MoLrnID", MoLrnID);
                ht.Add("PtrnID", PtrnID);
                ht.Add("BrnID", BrnID);
              //  ht.Add("CrPrDetailsID", CrPrDetailsID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ht.Add("fk_AcademicYear_ID", AcademicYrID);
                ds = oDB.getparamdataset("elgV2_Fetch_ProvisionallyEligible_Reg_StudentList_Resolve_RegStu", ht);
                return ds;
            }

            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        /// <summary>
/// This function is used to get the list of those students whose eligibility is kept pending. 
/// The search will be based on the filtering conditions in the Advanced Search control.
/// The Search will be in REG tables.
/// </summary>
/// <param name="Uni_ID"></param>
/// <param name="InstTy_ID"></param>
/// <param name="Inst_Name"></param>
/// <param name="Inst_State_ID"></param>
/// <param name="Inst_District_ID"></param>
/// <param name="Inst_Tehsil_ID"></param>
/// <param name="FacultyID"></param>
/// <param name="CourseID"></param>
/// <param name="CrMoLrnPtrnID"></param>
/// <param name="CrPrID"></param>
/// <param name="DOB"></param>
/// <param name="LastName"></param>
/// <param name="FirstName"></param>
/// <param name="Gender"></param>
/// <returns>DataSet</returns>

		public static DataSet Fetch_Pending_Reg_Student_List(string Uni_ID,string InstTy_ID,string Inst_Name,string Inst_State_ID,string Inst_District_ID,string Inst_Tehsil_ID,string FacultyID, string CourseID, string CrMoLrnPtrnID, string CrPrID, string DOB, string LastName, string FirstName, string Gender)
		{
			DataSet ds = new DataSet();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();			
				Hashtable ht=new Hashtable();
				ht.Add("Uni_ID",Uni_ID);
				ht.Add("InstTy_ID",InstTy_ID);
				ht.Add("Inst_Name",Inst_Name);
				ht.Add("Inst_State_ID",Inst_State_ID);
				ht.Add("Inst_District_ID",Inst_District_ID);
				ht.Add("Inst_Tehsil_ID",Inst_Tehsil_ID);
				ht.Add("FacultyID",FacultyID);
				ht.Add("CrID",CourseID);
				ht.Add("CrMoLrnPtrnID",CrMoLrnPtrnID);
				ht.Add("CrPrID",CrPrID);
				ht.Add("DOB",DOB);
				ht.Add("LastName",LastName);
				ht.Add("FirstName",FirstName);
				ht.Add("Gender",Gender);
				ds = oDB.getparamdataset("elg_Fetch_Pending_Reg_StudentList",ht);
				return ds;
			}
			
			catch(Exception Ex)
			{
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}

        public static DataSet Fetch_Reg_Student_List(string Uni_ID,string Inst_ID,string State_ID,string District_ID,string Tehsil_ID, string DOB, string LastName, string FirstName, string Gender)
		{
			DataSet ds = new DataSet();
			Hashtable ht=new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("Ref_Uni_ID",Uni_ID);
                ht.Add("Ref_Institute_ID", Inst_ID);
				ht.Add("State_ID",State_ID);
				ht.Add("District_ID",District_ID);
				ht.Add("Tehsil_ID",Tehsil_ID);
				ht.Add("DOB",DOB);
				ht.Add("LastName",LastName);
				ht.Add("FirstName",FirstName);
				ht.Add("Gender",Gender);
                ds = oDB.getparamdataset("ELGV2_Fetch_ProcessedEligibilityStudentsList", ht);
				return ds;
			}
			
			catch(Exception Ex)
			{
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}

		#endregion 

		#region Register Fresh Student

		/// <summary>
		/// This function is used to register a student in the University .
		/// New Record will be Inserted in to REG Tables from IA Tables
		/// </summary>
		/// <param name="Ref_pk_Uni_ID"></param>
		/// <param name="Ref_pk_Year"></param>
		/// <param name="Ref_pk_Institute_ID"></param>
		/// <param name="Ref_pk_Student_ID"></param>
		/// <param name="ElgDecision"></param>
		/// <param name="Reason"></param>
		/// <param name="pk_CrMoLrnPtrn_ID"></param>
		/// <param name="UserID"></param>
		/// <param name="DocXML"></param>
		/// <returns>Returns PRN ,if already exists or generates a new PRN</returns>

        public static string[] Register_Fresh_Student(string Ref_pk_Uni_ID, string Ref_pk_Institute_ID, string Ref_pk_Year, string Ref_pk_Student_ID, string ElgDecision, string Reason, string pk_Fac_ID, string pk_Cr_ID, string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPrDetails_ID, string fkAcademicYrID, string UserID, System.Text.StringBuilder DocXML, string DC_ServerName, string DC_DBName)
		{
			
			string[] arr = new string[2];
			Hashtable ht =  new Hashtable();
			SqlCommand cmd = new SqlCommand();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("Ref_pk_Uni_ID",Ref_pk_Uni_ID);
				ht.Add("Ref_pk_Year",Ref_pk_Year);
				ht.Add("Ref_pk_Institute_ID",Ref_pk_Institute_ID);
				ht.Add("Ref_pk_Student_ID",Ref_pk_Student_ID);
				ht.Add("ElgDecision",ElgDecision);
				ht.Add("Reason",Reason);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ht.Add("pk_CrPrDetails_ID", pk_CrPrDetails_ID);
                ht.Add("fkAcademicYearID", fkAcademicYrID);
				ht.Add("UserID",UserID);
				ht.Add("DocXML",DocXML.ToString());
				ht.Add("PRN","");
				ht.Add("Error",0);
                ht.Add("DC_ServerName", DC_ServerName);
                ht.Add("DC_DBName", DC_DBName);
                cmd = oDB.GenerateCommand("ELGV2_Register_Fresh_Student", ht);
				cmd.Parameters["@PRN"].Direction=ParameterDirection.Output;
				cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
				cmd.ExecuteNonQuery();
				arr[0]=cmd.Parameters["@PRN"].Value.ToString();
				arr[1]=cmd.Parameters["@Error"].Value.ToString();
				return arr;
				
			}
			catch(Exception Ex)
			{
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}

		#endregion

        #region Register Fresh Student

        /// <summary>
        /// This function is used to register a student in the University .
        /// New Record will be Inserted in to REG Tables from IA Tables
        /// </summary>
        /// <param name="Ref_pk_Uni_ID"></param>
        /// <param name="Ref_pk_Year"></param>
        /// <param name="Ref_pk_Institute_ID"></param>
        /// <param name="Ref_pk_Student_ID"></param>
        /// <param name="ElgDecision"></param>
        /// <param name="Reason"></param>
        /// <param name="pk_CrMoLrnPtrn_ID"></param>
        /// <param name="UserID"></param>
        /// <param name="DocXML"></param>
        /// <returns>Returns PRN ,if already exists or generates a new PRN</returns>
        
        public static string[] Register_Fresh_Student_RegStu(string Ref_pk_Uni_ID, string Ref_pk_Institute_ID, string Ref_pk_Year, string Ref_pk_Student_ID, string ElgDecision, string Reason, string pk_Fac_ID, string pk_Cr_ID, string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPrDetails_ID, string UserID, System.Text.StringBuilder DocXML)
        {

           
           // string[] arr = new string[2];
            string[] arr = new string[1];
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Ref_pk_Uni_ID", Ref_pk_Uni_ID);
                ht.Add("Ref_pk_Year", Ref_pk_Year);
                ht.Add("Ref_pk_Institute_ID", Ref_pk_Institute_ID);
                ht.Add("Ref_pk_Student_ID", Ref_pk_Student_ID);
                ht.Add("ElgDecision", ElgDecision);
                ht.Add("Reason", Reason);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ht.Add("pk_CrPrDetails_ID", pk_CrPrDetails_ID);
                ht.Add("UserID", UserID);
                ht.Add("DocXML", DocXML.ToString());
                //ht.Add("PRN", "");
                ht.Add("Error", 0);
                cmd = oDB.GenerateCommand("ELGV2_Register_Fresh_Student_RegStu", ht);
                //cmd.Parameters["@PRN"].Direction = ParameterDirection.Output;
                cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                //arr[0] = cmd.Parameters["@PRN"].Value.ToString();
                arr[0] = cmd.Parameters["@Error"].Value.ToString();
                return arr;

            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }

        #endregion

		#region Associate Student With Course

		/// <summary>
		/// This function is used to associate the record from IA table with a matching record in the REG table.
		/// </summary>
		/// <param name="pk_Uni_ID"></param>
		/// <param name="pk_Year"></param>
		/// <param name="pk_Student_ID"></param>
		/// <param name="Ref_pk_Uni_ID"></param>
		/// <param name="Ref_pk_Year"></param>
		/// <param name="Ref_pk_Institute_ID"></param>
		/// <param name="Ref_pk_Student_ID"></param>
		/// <param name="ElgDecision"></param>
		/// <param name="Reason"></param>
		/// <param name="pk_CrMoLrnPtrn_ID"></param>
		/// <param name="UserID"></param>
		/// <param name="DocXML"></param>
		/// <param name="ExistingPRN"></param>
		/// <returns>It returns a string array with PRN and Eligibility Flag of the Course to which the current 
		/// record gets associated.</returns>
        
		public static string[] Associate_Student_With_Course(string pk_Uni_ID, string pk_Year, string pk_Student_ID, string Ref_pk_Uni_ID,string Ref_pk_Year, string Ref_pk_Institute_ID, string  Ref_pk_Student_ID, string ElgDecision, string Reason,  string pk_CrMoLrnPtrn_ID, string UserID, System.Text.StringBuilder DocXML, string ExistingPRN)
		{
			string[] arr = new string[3];
			Hashtable ht =  new Hashtable();
			SqlCommand cmd = new SqlCommand();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("pk_Uni_ID",pk_Uni_ID);
				ht.Add("pk_Year",pk_Year);
				ht.Add("pk_Student_ID",pk_Student_ID);
				ht.Add("Ref_pk_Uni_ID",Ref_pk_Uni_ID);
				ht.Add("Ref_pk_Year",Ref_pk_Year);
				ht.Add("Ref_pk_Institute_ID",Ref_pk_Institute_ID);
				ht.Add("Ref_pk_Student_ID",Ref_pk_Student_ID);
				ht.Add("ElgDecision",ElgDecision);
				ht.Add("Reason",Reason);
				ht.Add("pk_CrMoLrnPtrn_ID",pk_CrMoLrnPtrn_ID);
				ht.Add("UserID",UserID);
				ht.Add("DocXML",DocXML.ToString());
				ht.Add("ExistingPRN",ExistingPRN);
				ht.Add("PRN","");
				ht.Add("Flag",0);
				ht.Add("Error",0);
				cmd = oDB.GenerateCommand("elg_Associate_Student_With_Course",ht);
				cmd.Parameters["@PRN"].Direction=ParameterDirection.Output;
				cmd.Parameters["@Flag"].Direction=ParameterDirection.Output;
				cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
				cmd.ExecuteNonQuery();
				arr[0]=cmd.Parameters["@PRN"].Value.ToString();
				arr[1]=cmd.Parameters["@Flag"].Value.ToString();
				arr[2]=cmd.Parameters["@Error"].Value.ToString();
				return arr;
			}
			catch(Exception Ex)
			{
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}
	
		#endregion

        #region Fetch Students Details of a Pending Candidate From REG for Eligibility Revising

        /// <summary>
		/// This function Fetch Students Details of a Pending Candidate From REG for Eligibility Revising
		/// </summary>
		/// <param name="Uni_ID" >University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
        
		public static DataSet Fetch_REG_Pending_Student_Details(int pk_Uni_ID, int pk_Year,int pk_Student_ID,int Ref_Uni_ID,int Ref_Institute_ID,int Ref_Year,int Ref_Student_ID ,int pk_Fac_ID, int pk_Cr_ID, int pk_MoLrn_ID,int pk_Ptrn_ID, int pk_CrPrDetails_ID,int pk_Brn_ID)
		{	
			DataSet ds = new DataSet();
			
			Hashtable ht=new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();	
				ht.Add("pk_Uni_ID",pk_Uni_ID);
				ht.Add("pk_Year",pk_Year);
				ht.Add("pk_Student_ID",pk_Student_ID);

				ht.Add("Ref_Uni_ID",Ref_Uni_ID);
                ht.Add("Ref_Institute_ID",Ref_Institute_ID);
				ht.Add("Ref_Year",Ref_Year);
				ht.Add("Ref_Student_ID",Ref_Student_ID);
                ht.Add("pk_Fac_ID",pk_Fac_ID);
                ht.Add("pk_Cr_ID",pk_Cr_ID);
                ht.Add("pk_MoLrn_ID",pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_CrPrDetails_ID",pk_CrPrDetails_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);				
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_Pending_Student_Details", ht);
				return ds;
			}
			catch(Exception Ex)
			{
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}

		#endregion

        #region fetch student details for pending student for registered student

        public static DataSet Fetch_REG_Pending_Student_Details_RegStu(int pk_Uni_ID, int pk_Year, int pk_Student_ID, int Ref_Uni_ID, int Ref_Institute_ID, int Ref_Year, int Ref_Student_ID, int pk_Fac_ID, int pk_Cr_ID, int pk_MoLrn_ID, int pk_Ptrn_ID, int pk_CrPrDetails_ID, int pk_Brn_ID)
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                ht.Add("pk_Year", pk_Year);
                ht.Add("pk_Student_ID", pk_Student_ID);
                ht.Add("Ref_Uni_ID", Ref_Uni_ID);
                ht.Add("Ref_Institute_ID", Ref_Institute_ID);
                ht.Add("Ref_Year", Ref_Year);
                ht.Add("Ref_Student_ID", Ref_Student_ID);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_CrPrDetails_ID", pk_CrPrDetails_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_Pending_Student_Details_RegStu", ht);
                return ds;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }

        #endregion

        #region Fetch Students Details of a Provisionally Eligible Candidate From REG for Eligibility Revising

        /// <summary>
        /// This function Fetch Students Details of a Provisionally Eligible Candidate From REG for Eligibility Revising
        /// </summary>
        /// <param name="Uni_ID" >University ID</param>
        /// <param name="Institute_ID">Institute ID</param>
        /// <param name="Student_ID">Student ID</param>
        
        public static DataSet Fetch_REG_ProvisionallyEligible_Student_Details(int pk_Uni_ID, int pk_Year, int pk_Student_ID, int Ref_Uni_ID,int Ref_Institute_ID,  int Ref_Year, int Ref_Student_ID, int pk_Fac_ID, int pk_Cr_ID, int pk_MoLrn_ID, int pk_Ptrn_ID, int pk_CrPrDetails_ID, int pk_Brn_ID)
        {
            DataSet ds = new DataSet();

            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                ht.Add("pk_Year", pk_Year);
                ht.Add("pk_Student_ID", pk_Student_ID);

                ht.Add("Ref_Uni_ID", Ref_Uni_ID);
                ht.Add("Ref_Institute_ID", Ref_Institute_ID);
                ht.Add("Ref_Year", Ref_Year);
                ht.Add("Ref_Student_ID", Ref_Student_ID);

                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_CrPrDetails_ID", pk_CrPrDetails_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);	                
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_ProvisionallyEligible_Student_Details", ht);
                return ds;

            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }

        #endregion

        #region fetch student details for Provisionally Eligible_Student for registered student

        public static DataSet Fetch_REG_ProvisionallyEligible_Student_Details_RegStu(int pk_Uni_ID, int pk_Year, int pk_Student_ID, int Ref_Uni_ID, int Ref_Institute_ID, int Ref_Year, int Ref_Student_ID, int pk_Fac_ID, int pk_Cr_ID, int pk_MoLrn_ID, int pk_Ptrn_ID, int pk_CrPrDetails_ID, int pk_Brn_ID)
        {
            DataSet ds = new DataSet();

            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                ht.Add("pk_Year", pk_Year);
                ht.Add("pk_Student_ID", pk_Student_ID);
                ht.Add("Ref_Uni_ID", Ref_Uni_ID);
                ht.Add("Ref_Institute_ID", Ref_Institute_ID);
                ht.Add("Ref_Year", Ref_Year);
                ht.Add("Ref_Student_ID", Ref_Student_ID);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_CrPrDetails_ID", pk_CrPrDetails_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ds = oDB.getparamdataset("ELGV2_Fetch_REG_ProvisionallyEligible_Student_Details_RegStu", ht);
                return ds;

            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }
        
        #endregion

        #region Fetch IA Matching REG Student details

        /// <summary>
		/// This function Fetch Students Details of a Pending Candidate From REG for Eligibility Revising
		/// </summary>
		/// <param name="Uni_ID" >University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
        
		public static DataSet Fetch_IAMatchingREG_StudentDetails(int pk_Uni_ID, int pk_Year,int pk_Student_ID)
		{	
			DataSet ds = new DataSet();
			Hashtable ht=new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				
				ht.Add("pk_Uni_ID",pk_Uni_ID);
				ht.Add("pk_Year",pk_Year);
				ht.Add("pk_Student_ID",pk_Student_ID);
				ds = oDB.getparamdataset("elg_Fetch_IA_Matching_REG_Student_Details",ht);
				return ds;
			}
			catch(Exception Ex)
			{
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}

		#endregion
        
		#region Pending Student -Eligibility Decision

		/// <summary>
		/// This function is to resolve the Eligibilty decision of the Pending Student.
		/// </summary>
		/// <param name="pk_Uni_ID"></param>
		/// <param name="pk_Year"></param>
		/// <param name="pk_Student_ID"></param>
		/// <param name="pk_CrMoLrnPtrn_ID"></param>
		/// <param name="ElgDecisionFlag"></param>
		/// <param name="DocXML"></param>
		/// <param name="reason"></param>
		/// <param name="ExistingPRN"></param>
		/// <param name="UserID"></param>
		/// <returns>Returns PRN , if exits or generated</returns>

        public static string[] REG_PendingStudentEligibilityDecision(int pk_Uni_ID, int pk_Year, int pk_Student_ID, int Ref_Uni_ID, int Ref_Institute_ID, int Ref_Year, int Ref_Student_ID, int pk_Fac_ID, int pk_Cr_ID, int pk_MoLrn_ID, int pk_Ptrn_ID, int pk_Brn_ID, int pk_CrPr_Details_ID, int fkAcademicYearID, string ElgDecisionFlag, System.Text.StringBuilder DocXML, string ExisitngPRN, string Reason, string UserID, string DC_ServerName, string DC_DBName)
		{
			
			string[] arr=new string[2];
			DataSet ds = new DataSet();
			SqlCommand cmd = new SqlCommand();
			Hashtable ht=new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("pk_Uni_ID",pk_Uni_ID);
				ht.Add("pk_Year",pk_Year);
				ht.Add("pk_Student_ID",pk_Student_ID);
				ht.Add("Ref_Uni_ID",Ref_Uni_ID);
                ht.Add("Ref_Institute_ID",Ref_Institute_ID);
				ht.Add("Ref_Year",Ref_Year);
				ht.Add("Ref_Student_ID",Ref_Student_ID);
                ht.Add("pk_Fac_ID",pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID",pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID",pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ht.Add("pk_CrPr_Details_ID", pk_CrPr_Details_ID);
                ht.Add("fkAcademicYearID", fkAcademicYearID);
				ht.Add("ElgDecisionFlag",ElgDecisionFlag);
				ht.Add("DocXML",DocXML.ToString());
				ht.Add("Reason",Reason);
				ht.Add("UserID",UserID);
                ht.Add("DC_ServerName", DC_ServerName);
                ht.Add("DC_DBName", DC_DBName);
				//ht.Add("ExisitngPRN",ExisitngPRN);
				ht.Add("PRN","");
				ht.Add("Error",0);
                cmd = oDB.GenerateCommand("ELGV2_PendingEligibleStudent_EligibilityDecision", ht);
				cmd.Parameters["@PRN"].Direction=ParameterDirection.Output;
				cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
				cmd.ExecuteNonQuery();
				arr[0]=cmd.Parameters["@PRN"].Value.ToString();
				arr[1]=cmd.Parameters["@Error"].Value.ToString();
				//ds=getparamdataset("elg_Fetch_REG_Pending_Student_Details",ht);
				return arr;
			}
			catch(Exception Ex)
			{
                throw (Ex);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}

		#endregion

        #region student eligibility decision for pending student

        public static string REG_PendingStudentEligibilityDecision_RegStu(int pk_Uni_ID, int pk_Year, int pk_Student_ID, int Ref_Uni_ID, int Ref_Institute_ID, int Ref_Year, int Ref_Student_ID, int pk_Fac_ID, int pk_Cr_ID, int pk_MoLrn_ID, int pk_Ptrn_ID, int pk_Brn_ID, int pk_CrPr_Details_ID, int fkAcademicYearID, string ElgDecisionFlag, System.Text.StringBuilder DocXML,  string ExisitngPRN, string Reason, string UserID)
        {

            string arr = "";
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                ht.Add("pk_Year", pk_Year);
                ht.Add("pk_Student_ID", pk_Student_ID);
                
                ht.Add("Ref_Uni_ID", Ref_Uni_ID);
                ht.Add("Ref_Institute_ID", Ref_Institute_ID);
                ht.Add("Ref_Year", Ref_Year);
                ht.Add("Ref_Student_ID", Ref_Student_ID);

                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ht.Add("pk_CrPr_Details_ID", pk_CrPr_Details_ID);
                ht.Add("fkAcademicYearID", fkAcademicYearID);
                ht.Add("ElgDecisionFlag", ElgDecisionFlag);
                ht.Add("DocXML", DocXML.ToString());
                ht.Add("Reason", Reason);
                ht.Add("UserID", UserID);
                ht.Add("ExisitngPRN", ExisitngPRN);
                //ht.Add("PRN", "");
                ht.Add("Error", 0);
                cmd = oDB.GenerateCommand("ELGV2_PendingEligibleStudent_EligibilityDecision_Reg", ht);
                //cmd.Parameters["@PRN"].Direction = ParameterDirection.Output;
                cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                //arr[0] = cmd.Parameters["@PRN"].Value.ToString();
                arr = cmd.Parameters["@Error"].Value.ToString();
                //ds=getparamdataset("elg_Fetch_REG_Pending_Student_Details",ht);
                return arr;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion 

        #region  REG_ProvisionalEligibleStudentEligibilityDecision_RegStu

        public static string[] REG_ProvisionalEligibleStudentEligibilityDecision_RegStu(int pk_Uni_ID, int pk_Year, int pk_Student_ID, int Ref_Uni_ID, int Ref_Institute_ID, int Ref_Year, int Ref_Student_ID, int pk_Fac_ID, int pk_Cr_ID, int pk_MoLrn_ID, int pk_Ptrn_ID, int pk_Brn_ID, int pk_CrPr_Details_ID, string fkAcademicYearID, string ElgDecisionFlag, System.Text.StringBuilder DocXML, string ExisitngPRN, string Reason, string UserID)
        {

            string[] arr = new string[2];
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                ht.Add("pk_Year", pk_Year);
                ht.Add("pk_Student_ID", pk_Student_ID);

                ht.Add("Ref_Uni_ID", Ref_Uni_ID);
                ht.Add("Ref_Institute_ID", Ref_Institute_ID);
                ht.Add("Ref_Year", Ref_Year);
                ht.Add("Ref_Student_ID", Ref_Student_ID);

                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ht.Add("pk_CrPr_Details_ID", pk_CrPr_Details_ID);
                ht.Add("fkAcademicYearID", fkAcademicYearID);
                ht.Add("ElgDecisionFlag", ElgDecisionFlag);
                ht.Add("DocXML", DocXML.ToString());
                ht.Add("Reason", Reason);
                ht.Add("UserID", UserID);
                ht.Add("ExisitngPRN", ExisitngPRN);
                //ht.Add("PRN", "");
                ht.Add("Error", 0);
                // MySQL related change - SP name should be having less than 64 characters
                //cmd = oDB.GenerateCommand("ELGV2_PendingOrProvisionallyEligibleStudent_EligibilityDecision_RegStu", ht);
                cmd = oDB.GenerateCommand("ELGV2_PendingOrProvisionallyElgStudent_ElgDecision_RegStu", ht);

                //cmd.Parameters["@PRN"].Direction = ParameterDirection.Output;
                cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                //arr[0] = cmd.Parameters["@PRN"].Value.ToString();
                arr[1] = cmd.Parameters["@Error"].Value.ToString();
                //ds=getparamdataset("elg_Fetch_REG_Pending_Student_Details",ht);
                return arr;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region Provisionally Eligible Student - Eligibility Decision

        /// <summary>
        /// This function is to resolve the Eligibilty decision of the Provisionally Eligible Student.
        /// </summary>
        /// <param name="pk_Uni_ID"></param>
        /// <param name="pk_Year"></param>
        /// <param name="pk_Student_ID"></param>
        /// <param name="pk_CrMoLrnPtrn_ID"></param>
        /// <param name="ElgDecisionFlag"></param>
        /// <param name="DocXML"></param>
        /// <param name="reason"></param>
        /// <param name="ExistingPRN"></param>
        /// <param name="UserID"></param>
        /// <returns>Returns PRN , if exits or generated</returns>
        
        public static int REG_ProvisionallyEligibleStudentEligibilityDecision(int pk_Uni_ID, int Ref_Year, int Ref_Institute_ID, int Ref_Student_ID, int pk_Fac_ID, int pk_Cr_ID, int pk_MoLrn_ID, int pk_Ptrn_ID, int pk_Brn_ID, int pk_CrPr_Details_ID, int fkAcademicYearID, string ElgDecisionFlag, System.Text.StringBuilder DocXML, string ExisitngPRN, string Reason, string UserID)
        {
            int Err;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                ht.Add("Ref_Year", Ref_Year);
                ht.Add("Ref_Institute_ID", Ref_Institute_ID);
                ht.Add("Ref_Student_ID", Ref_Student_ID);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ht.Add("pk_CrPr_Details_ID",pk_CrPr_Details_ID);
                ht.Add("fkAcademicYearID", fkAcademicYearID);
                ht.Add("ElgDecisionFlag", ElgDecisionFlag);
                ht.Add("DocXML", DocXML.ToString());
                ht.Add("Reason", Reason);
                ht.Add("UserID", UserID);
                ht.Add("ExisitngPRN", ExisitngPRN);
                ht.Add("Error", 0);
                cmd = oDB.GenerateCommand("ELGV2_ProvisionallyEligibleStudent_EligibilityDecision", ht);
                cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Err = Convert.ToInt32(cmd.Parameters["@Error"].Value.ToString());
                return Err;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region Eligibility Status

        /// <summary>
		/// This function is used to get the Primary Keys(ID's) of the Student when the Eligibility form number or PRN is given.
		/// This is used for simple search for viewing Eligibility Status .
		/// </summary>
		/// <param name="Ref_Uni_ID"></param>
		/// <param name="Ref_Year"></param>
		/// <param name="Ref_Institute_ID"></param>
		/// <param name="Ref_Student_ID"></param>
		/// <param name="PRN"></param>
		/// <returns>DataSet</returns>
        
        public static DataSet REG_Search_GetStudentIDs(int Ref_Uni_ID, int Ref_Year, int Ref_Institute_ID, int Ref_Student_ID, string PRN, string InstID)
		{
			
			DataSet ds;
			Hashtable ht=new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("Ref_Uni_ID",Ref_Uni_ID);
				ht.Add("Ref_Year",Ref_Year);
				ht.Add("Ref_Institute_ID",Ref_Institute_ID);
                ht.Add("Ref_Student_ID", Ref_Student_ID);
				ht.Add("PRN",PRN);
                ht.Add("InstituteID", InstID);
                ds = oDB.getparamdataset("ELGV2_Search_GetStudentIDs", ht);
				return ds;
			}
			catch(Exception Ex)
			{
                throw (Ex);
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}

		#endregion
		
		#region GetEligibilityStatus Details

		/// <summary>
		/// This function is used to get the Eligibility Status of a student using Simple Search 
		/// by giving Eligibility Form Number or PRN
		/// </summary>
		/// <param name="pk_Uni_ID"></param>
		/// <param name="pk_Year"></param>
		/// <param name="pk_Student_ID"></param>
		/// <param name="Ref_Uni_ID"></param>
		/// <param name="Ref_Year"></param>
		/// <param name="Ref_Institute_ID"></param>
		/// <param name="Ref_Student_ID"></param>
		/// <param name="PRN"></param>
		/// <returns></returns>
        /// 

        public static DataSet REG_Get_Eligibilitystatusdetails(int pk_Uni_ID, int pk_Year, int pk_Student_ID, int Ref_Uni_ID, int Ref_Institute_ID, int Ref_Year, int Ref_Student_ID, int fk_Fac_ID, int fk_Cr_ID, int fk_MoLrn_ID, int fk_Ptrn_ID, int fk_Brn_ID, int fk_CrPrDetails_ID)
		{
			DataSet ds;
			Hashtable ht=new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("pk_Uni_ID",pk_Uni_ID);
				ht.Add("pk_Year",pk_Year);
				ht.Add("pk_Student_ID",pk_Student_ID);
                ht.Add("Ref_Uni_ID", Ref_Uni_ID);                
                ht.Add("Ref_Institute_ID", Ref_Institute_ID);
                ht.Add("Ref_Year", Ref_Year);
                ht.Add("Ref_Student_ID", Ref_Student_ID);
                ht.Add("fk_Fac_ID", fk_Fac_ID);
                ht.Add("fk_Cr_ID", fk_Cr_ID);
                ht.Add("fk_MoLrn_ID", fk_MoLrn_ID);
                ht.Add("fk_Ptrn_ID", fk_Ptrn_ID);
                ht.Add("fk_Brn_ID", fk_Brn_ID);
                ht.Add("fk_CrPrDetails_ID", fk_CrPrDetails_ID);				
                ds = oDB.getparamdataset("ELGV2_Get_Eligibilitystatusdetails", ht);
				return ds;
			}
			catch(Exception Ex)
			{
                throw (Ex);
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}
        
        #endregion
	
		#region Elg_AdvSearch_StudentEligibilityDetails

		/// <summary>
		/// This function is used to get the Eligibility Details of the Student using Advanced Search Control for
		/// viewing the Eligibility Status of a student.
		/// </summary>
		/// <param name="pk_Uni_ID"></param>
		/// <param name="pk_Year"></param>
		/// <param name="pk_Student_ID"></param>
		/// <returns></returns>
        
		public static DataSet Elg_AdvSearch_StudentEligibilityDetails(int pk_Uni_ID, int pk_Year,int pk_Student_ID,string Ref_Uni_ID,string Ref_Institute_ID,string Ref_Year, string Ref_Student_ID,string PRN)
		{
			DataSet ds;
			Hashtable ht=new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("pk_Uni_ID",pk_Uni_ID);
				ht.Add("pk_Year",pk_Year);
				ht.Add("pk_Student_ID",pk_Student_ID);
                ht.Add("Ref_Uni_ID",Ref_Uni_ID);      
                ht.Add ("Ref_Institute_ID",Ref_Institute_ID);
                ht.Add ("Ref_Year",Ref_Year);   
                ht.Add ("Ref_Student_ID",Ref_Student_ID);                  
                ht.Add("PRN", PRN);
                ds = oDB.getparamdataset("ELGV2_AdvSearch_StudentEligibilityDetails", ht);
				return ds;
			}
			catch(Exception Ex)
			{
                throw (Ex);
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}

		#endregion

        /*
        #region CheckDetails (To check the summary and delete the ExamForm and related details generated if the student is marked as NotEligible from Provisionally Eligible)

        public static void CheckDetailsToChangeFromProvisionallyEligibleToNotEligible(string pk_Uni_ID, string pk_Year, string pk_Student_ID, string pk_Institute_ID)
        {
            SqlCommand cmd = new SqlCommand();
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                ht.Add("pk_Year", pk_Year);
                ht.Add("pk_Student_ID", pk_Student_ID);
                ht.Add("pk_Institute_ID", pk_Institute_ID);
                cmd = oDB.GenerateCommand("ELGV2_CheckDetailsToDelete", ht);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }

        #endregion
         */

        #region Report Student Status - Date:- 22 Sep 2008

        public static DataSet ProcessedEligibilityStudentsList(string UniID, string InstituteID, string pk_Fac_ID, string pk_Cr_ID, string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPr_Details_ID, string pk_CrPrCh_ID, string fk_AcademicYear_ID, string SortOption, string Criteria, string CriteriaNull, string CriteriaEligibilityNotRequired,string FromDate,string ToDate) // string State_ID, string District_ID, string Tehsil_ID, string DOB,  string FirstName, string LastName, string Gender)
        {

            DataSet ds = new DataSet();
            //string s1;
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            if (pk_Brn_ID == "")
                pk_Brn_ID = "0";
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Ref_Uni_ID", UniID);
                ht.Add("Ref_Institute_ID", InstituteID);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ht.Add("pk_CrPrDetails_ID", pk_CrPr_Details_ID);
                ht.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("SortOption", SortOption);
                ht.Add("Criteria", Criteria);
                ht.Add("CriteriaNull", CriteriaNull);
                ht.Add("CriteriaEligibilityRequired", CriteriaEligibilityNotRequired);
                ht.Add("FromDate",FromDate);
                ht.Add("ToDate", ToDate);
                //ht.Add("PrevCrPrChResultStatus", "");
                //cmd = oDB.GenerateCommand("REPV2_ProcessedEligibilityStudentsList", ht);                
                //cmd.Parameters["@ResStatus"].Direction = ParameterDirection.Output;
                //cmd.ExecuteNonQuery();
                //s1 = cmd.Parameters["@ResStatus"].Value.ToString();
                ds = oDB.getparamdataset("REPV2_ProcessedEligibilityStudentsList", ht);
                return ds;
                              
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

       }


        public static DataSet ProcessedEligibilityStudentsList_MUHS(string UniID, string InstituteID, string pk_Fac_ID, string pk_Cr_ID, string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPr_Details_ID, string pk_CrPrCh_ID, string fk_AcademicYear_ID, string SortOption, string Criteria, string CriteriaNull, string CriteriaEligibilityNotRequired, string FromDate, string ToDate) // string State_ID, string District_ID, string Tehsil_ID, string DOB,  string FirstName, string LastName, string Gender)
        {

            DataSet ds = new DataSet();
            //string s1;
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            if (pk_Brn_ID == "")
                pk_Brn_ID = "0";
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Ref_Uni_ID", UniID);
                ht.Add("Ref_Institute_ID", InstituteID);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ht.Add("pk_CrPrDetails_ID", pk_CrPr_Details_ID);
                ht.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("SortOption", SortOption);
                ht.Add("Criteria", Criteria);
                ht.Add("CriteriaNull", CriteriaNull);
                ht.Add("CriteriaEligibilityRequired", CriteriaEligibilityNotRequired);
                ht.Add("FromDate", FromDate);
                ht.Add("ToDate", ToDate);
                //ht.Add("PrevCrPrChResultStatus", "");
                //cmd = oDB.GenerateCommand("REPV2_ProcessedEligibilityStudentsList", ht);                
                //cmd.Parameters["@ResStatus"].Direction = ParameterDirection.Output;
                //cmd.ExecuteNonQuery();
                //s1 = cmd.Parameters["@ResStatus"].Value.ToString();
                ds = oDB.getparamdataset("REPV2_ProcessedEligibilityStudentsList_MUHS", ht);
                return ds;

            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }

        public static DataSet GenerateRegistrationReceiptStudentsList(string UniID, string InstituteID, string pk_Fac_ID, string pk_Cr_ID, string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPr_Details_ID, string pk_CrPrCh_ID, string fk_AcademicYear_ID, string SortOption, string Criteria, string CriteriaNull, string CriteriaEligibilityNotRequired, string FromDate, string ToDate) // string State_ID, string District_ID, string Tehsil_ID, string DOB,  string FirstName, string LastName, string Gender)
        {

            DataSet ds = new DataSet();
            //string s1;
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            if (pk_Brn_ID == "")
                pk_Brn_ID = "0";
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Ref_Uni_ID", UniID);
                ht.Add("Ref_Institute_ID", InstituteID);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                ht.Add("pk_CrPrDetails_ID", pk_CrPr_Details_ID);
                ht.Add("pk_CrPrCh_ID", pk_CrPrCh_ID);
                ht.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                ht.Add("FromDate", FromDate);
                ht.Add("ToDate", ToDate);
                //ht.Add("PrevCrPrChResultStatus", "");
                //cmd = oDB.GenerateCommand("REPV2_ProcessedEligibilityStudentsList", ht);                
                //cmd.Parameters["@ResStatus"].Direction = ParameterDirection.Output;
                //cmd.ExecuteNonQuery();
                //s1 = cmd.Parameters["@ResStatus"].Value.ToString();
                ds = oDB.getparamdataset("REPV2_GenerateRegistrationReceiptStudentsList", ht);
                return ds;

            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }

        #endregion

        #region Resolving Provisional Eligibility ( Unregistered Students) in Bulk
        public static int REG_NotEligibleStudentEligibilityDecisionBulk(int pk_Uni_ID, int pk_Institute_ID, int pk_Fac_ID, int pk_Cr_ID, int pk_MoLrn_ID, int pk_Ptrn_ID, int pk_Brn_ID, int fkAcademicYearID, string Student_ID, string ElgDecision, string Reason, string UserID)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            int RowsAffected;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                //ht.Add("pk_Year", pk_Year);
                ht.Add("pk_Institute_ID", pk_Institute_ID);
                ht.Add("studYearID", Student_ID);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
                //   ht.Add("pk_CrPrDetails_ID", pk_CrPrDetails_ID);
                ht.Add("fkAcademicYearID", fkAcademicYearID);
                ht.Add("ElgDecision", ElgDecision);
                ht.Add("Reason", Reason);
                ht.Add("UserID", UserID);

                cmd = oDB.GenerateCommand("ELGV2_NotEligibleStudent_EligibilityDecision_Bulk", ht);
                RowsAffected = cmd.ExecuteNonQuery();
                return RowsAffected;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        public static int REG_ProvisionallyEligibleStudentEligibilityDecisionBulk(int pk_Uni_ID, int pk_Institute_ID, int pk_Fac_ID, int pk_Cr_ID, int pk_MoLrn_ID, int pk_Ptrn_ID, int pk_Brn_ID, int fkAcademicYearID , string Student_ID, string ElgDecision, string Reason, string UserID)
        {            
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            int RowsAffected;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", pk_Uni_ID);
                //ht.Add("pk_Year", pk_Year);
                ht.Add("pk_Institute_ID", pk_Institute_ID);
                ht.Add("studYearID", Student_ID);
                ht.Add("pk_Fac_ID", pk_Fac_ID);
                ht.Add("pk_Cr_ID", pk_Cr_ID);
                ht.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                ht.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                ht.Add("pk_Brn_ID", pk_Brn_ID);
             //   ht.Add("pk_CrPrDetails_ID", pk_CrPrDetails_ID);
                ht.Add("fkAcademicYearID", fkAcademicYearID);
                ht.Add("ElgDecision", ElgDecision);               
                ht.Add("Reason", Reason);
                ht.Add("UserID", UserID);              
               
                cmd = oDB.GenerateCommand("ELGV2_ProvisionallyEligibleStudent_EligibilityDecision_Bulk", ht);
                RowsAffected = cmd.ExecuteNonQuery();
                return RowsAffected;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region MATCHING PROFILE REGION

        #region Get Match Profile against Match Profile Id (AUTO)
        /// <summary>
        /// Get student details for matching Profile against Matching profile ID
        /// (For auto profile matching)
        /// </summary>
        /// <param name="matching_Profile_ID"></param>
        /// <returns></returns>
        public DataSet GetMatchProfileForMPId(string matching_Profile_ID)
        {
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet ds = new DataSet();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht["Matching_Profile_ID"] = matching_Profile_ID;
                ds = oDB.getparamdataset("ELGV2_Profile_GetMatchProfileForMPId", ht);
                return ds;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Get Match Profile against StudentIDs (MANUAL)
        /// <summary>
        /// Get student details for matching Profile against Student IDs
        /// (For manual profile matching)
        /// </summary>
        /// <param name="studentIDs"></param>
        /// <param name="baseStudentID"></param>
        /// <returns></returns>
        public DataSet GetMatchProfileForStudentIDs(string studentIDs, string baseStudentID)
        {
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet ds = new DataSet();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht["pk_Student_IDs"] = studentIDs;
                ht["Base_Student_ID"] = baseStudentID;
                ds = oDB.getparamdataset("ELGV2_Profile_GetMatchProfileForStudentIDs", ht);
                return ds;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Get Students Course Profile
        /// <summary>
        /// Get students course details for profile matching
        /// </summary>
        /// <param name="uniID"></param>
        /// <param name="year"></param>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataTable GetStudentsCourseProfile(string uniID, string year, string studentID)
        {
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable dt = new DataTable();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht["pk_Uni_ID"] = uniID;
                ht["pk_Year"] = year;
                ht["pk_Student_ID"] = studentID;
                dt = oDB.getparamdataset("ELGV2_Profile_GetStudentsCourseProfile", ht).Tables[0];
                return dt;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        /// <summary>
        /// Show photosign in profile matching
        /// </summary>
        /// <param name="uniID"></param>
        /// <param name="yearID"></param>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataTable ShowPhotoSign(string uniID, string yearID, string studentID)
        {
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable dt = new DataTable();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht["pk_Uni_ID"] = uniID;
                ht["pk_Year"] = yearID;
                ht["pk_Student_ID"] = studentID;
                dt = oDB.getparamdataset("REGV2_fetch_PhotoSign", ht).Tables[0];
                return dt;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #region Delete Profile
        /// <summary>
        /// Deletion of profile
        /// </summary>
        /// <param name="pk_Uni_ID"></param>
        /// <param name="pk_Year"></param>
        /// <param name="Student_ID"></param>
        /// <param name="uSERID"></param>
        /// <param name="Base_Uni_ID"></param>
        /// <param name="Base_Year"></param>
        /// <param name="Base_Student_ID"></param>
        /// <returns></returns>
        public int DeleteDuplicateProfile(string pk_Uni_ID, string pk_Year, string Student_ID, string uSERID, string Base_Uni_ID, string Base_Year, string Base_Student_ID)
        {
            SqlCommand cmd = new SqlCommand();
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            int RowsAffected = 0;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht["ToDelete_Uni_ID"] = pk_Uni_ID;
                ht["ToDelete_Year"] = pk_Year;
                ht["ToDelete_Student_ID"] = Student_ID;
                ht["USERID"] = uSERID;
                ht["Base_Uni_ID"] = Base_Uni_ID;
                ht["Base_Year"] = Base_Year;
                ht["Base_Student_ID"] = Base_Student_ID;

                cmd = oDB.GenerateCommand("ELGV2_Profile_InsertToDelete", ht);
                RowsAffected = cmd.ExecuteNonQuery();
                return RowsAffected;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region List Matching Profiles
        /// <summary>
        /// List Matching Profiles
        /// </summary>
        /// <returns></returns>
        public DataTable ListMatchingProfiles()
        {           
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable dt = new DataTable();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getdataset("ELGV2_Profile_ListMatchingProfiles").Tables[0];
                return dt;
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Search Manual Profile Match
        /// <summary>
        /// Search Manual Profile Match
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet ManualProfileMatch(Hashtable ht)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataSet ds = new DataSet();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ds = oDB.getparamdataset("ELGV2_Profile_Search_ManualProfileMatching", ht);
                return ds;
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Get Course Details For Confirm Merge
        /// <summary>
        /// Get Course Details For retaining or removing terms on merge
        /// </summary>
        /// <param name="mergeUniID"></param>
        /// <param name="mergeYear"></param>
        /// <param name="mergeStudentID"></param>
        /// <param name="BaseUniID"></param>
        /// <param name="BaseYear"></param>
        /// <param name="BaseStudentID"></param>
        /// <returns></returns>
        public DataSet GetCourseDetailsForConfirmMerge(string mergeUniID, string mergeYear, string mergeStudentID, string BaseUniID, string BaseYear, string BaseStudentID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht["Merge_Uni_ID"] = mergeUniID;
            ht["Merge_Year"] = mergeYear;
            ht["Merge_Student_ID"] = mergeStudentID;
            ht["Base_Uni_ID"] = BaseUniID;
            ht["Base_Year"] = BaseYear;
            ht["Base_Student_ID"] = BaseStudentID;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ds = oDB.getparamdataset("ELGV2_Profile_GetCourseDetailsForConfirmMerge", ht);
                return ds;
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Confirm Merge
        /// <summary>
        /// Confirm Merge
        /// </summary>
        /// <param name="base_Uni_ID"></param>
        /// <param name="base_Year"></param>
        /// <param name="base_Student_ID"></param>
        /// <param name="toMerge_Uni_ID"></param>
        /// <param name="toMerge_Year"></param>
        /// <param name="toMerge_Student_ID"></param>
        /// <param name="termsToBeMerge"></param>
        /// <param name="uSERID"></param>
        /// <param name="new_Identity"></param>
        /// <returns>Rows returned</returns>
        public string ConfirmMerge(string base_Uni_ID, string base_Year, string base_Student_ID, string toMerge_Uni_ID, string toMerge_Year, string toMerge_Student_ID, string termsToBeMerge, string uSERID, string new_Identity)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand();
            int rowsAffected = 0;

            ht["Base_Uni_ID"] = base_Uni_ID;
            ht["Base_Year"] = base_Year;
            ht["Base_Student_ID"] = base_Student_ID;
            ht["ToMerge_Uni_ID"] = toMerge_Uni_ID;
            ht["ToMerge_Year"] = toMerge_Year;
            ht["ToMerge_Student_ID"] = toMerge_Student_ID;
            ht["TermsToBeMerge"] = termsToBeMerge;
            ht["USERID"] = uSERID;
            ht["New_Identity"] = new_Identity;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                //cmd = oDB.GenerateCommand("ELGV2_Profile_Merge", ht);
                cmd = oDB.GenerateCommand("ELGV2_Profile_InsertToMerge", ht);
                rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected.ToString();
            }
            catch (SqlException Ex)
            {
                throw (Ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Get Students College Profile
        /// <summary>
        /// Get students College details for profile matching
        /// </summary>
        /// <param name="uniID"></param>
        /// <param name="year"></param>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataTable GetStudentsCollegeProfile(string uniID, string year, string studentID)
        {
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable dt = new DataTable();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht["pk_Uni_ID"] = uniID;
                ht["pk_Year"] = year;
                ht["pk_Student_ID"] = studentID;
                dt = oDB.getparamdataset("ELGV2_Profile_GetStudentsCollegeProfile", ht).Tables[0];
                return dt;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #endregion

        #region Filling Landing Page Panels

        //to fill Pending Exemption Approval Panel
        public static DataTable FillPendingExemptionApproval_Panel(string fk_AcademicYear_ID, string pk_Uni_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable ht = new Hashtable();    
            //DataSet ds;
            DataTable dt;

            ht["fk_AcademicYear_ID"] = fk_AcademicYear_ID;
            ht["pk_Uni_ID"] = pk_Uni_ID;
            
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_PendingExemptionApproval_Panel", ht).Tables[0];                
            }
            catch (Exception Ex)
            {
                dt = null;
               // throw (Ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

            return dt;
        }

        //to get academic year id from academic year
        public static DataTable GetAcademicYearID(string AcademicYear)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable ht = new Hashtable();
            //DataSet ds;
            DataTable dt;

            ht["AcademicYear"] = AcademicYear;            

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_GetAcademicYearID", ht).Tables[0];
            }
            catch (Exception Ex)
            {
                dt = null;
               // throw (Ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

            return dt;
        }

        //to fill Uploaded Disc Stats Panel
        public static DataTable FillUploadedDiscrepancyStatistics_Panel(string fk_AcademicYear_ID, string pk_Uni_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable ht = new Hashtable();
           // DataSet ds;
            DataTable dt;

            ht["fk_AcademicYear_ID"] = fk_AcademicYear_ID;
            ht["pk_Uni_ID"] = pk_Uni_ID;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_UploadedDiscrepancyStatistics_Panel", ht).Tables[0];
            }
            catch (Exception Ex)
            {
               dt = null;
                //throw (Ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

            return dt;
        }

        //to fill Uploaded Not Processed Eligibility Count Panel
        public static DataTable FillUploadedNotProcessedEligibilityCount_Panel(string fk_AcademicYear_ID, string pk_Uni_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable ht = new Hashtable();
            //DataSet ds;
            DataTable dt;

            ht["fkAcademicYearID"] = fk_AcademicYear_ID;
            ht["UniID"] = pk_Uni_ID;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_UploadedNotProcessedEligibilityCount_Panel", ht).Tables[0];
            }
            catch (Exception Ex)
            {
                dt = null;
                //throw (Ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

            return dt;
        }

        //to fill Pending Provisional Eligibility Count Panel
        public  static DataTable FillPendingProvisionalEligibilityCount_Panel(string fk_AcademicYear_ID, string pk_Uni_ID)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable ht = new Hashtable();
            //DataSet ds;
            DataTable dt;

            ht["fkAcademicYearID"] = fk_AcademicYear_ID;
            ht["UniID"] = pk_Uni_ID;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_PendingProvisionalEligibilityCount_Panel", ht).Tables[0];
            }
            catch (Exception Ex)
            {
                dt = null;
                //throw (Ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

            return dt;
        }



        //to get all Panels' data from MIS_Panel_Master 
        public static DataTable FillAllPanels(string Module_Key)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;
            Hashtable ht = new Hashtable();
            //DataSet ds;
            DataTable dt;

            ht["Module_Key"] = Module_Key;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("MIS_GetModuleWisePanelDetails", ht).Tables[0];
            }
            catch (Exception Ex)
            {
                dt = null;
                //throw (Ex);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

            return dt;
        }


        #endregion

        #region Report Merge and Cancel admission request Status

        public  DataTable getMergeAndCancelAdmissionRequestStatus()
        {

            DataTable dt = new DataTable();
           
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
          
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getdataset("ELGV2_MergeProfileCancelAdmission_MIS").Tables[0];
                return dt;

            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }

        #endregion

        #region Students course details for Cancel Admission
        /// <summary>
        /// Get students course details for Cancel Admission
        /// </summary>
        /// <param name="uniID"></param>
        /// <param name="year"></param>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataTable GetStudentsCourseProfileForCancelAdmission(string uniID, string year, string studentID)
        {
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable dt = new DataTable();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht["pk_Uni_ID"] = uniID;
                ht["pk_Year"] = year;
                ht["pk_Student_ID"] = studentID;
                dt = oDB.getparamdataset("ELGV2_CancelAdmission_GetStudentsCourseProfile", ht).Tables[0];
                return dt;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        public DataTable GetDanglingStudent(string pk_Uni_ID, string p_index)
        {
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            DataTable dt = new DataTable();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht["pk_Uni_ID"] = pk_Uni_ID;
                ht["p_index"] = p_index;
                dt = oDB.getparamdataset("ELGV2_CancelAdmission_SearchDanglingStudents", ht).Tables[0];
                return dt;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        public string DeleteDanglingStudent(string uniID, string yearID, string studentID, string userID, string newIdentity)
        {
            string sReturnData = string.Empty;
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht["pk_Uni_ID"] = uniID;
                ht["pk_Year"] = yearID;
                ht["pk_Student_ID"] = studentID;
                ht["USERID"] = userID;
                ht["New_Identity"] = newIdentity;

                cmd = oDB.GenerateCommand("ELGV2_CancelAdmission_DeleteDanglingProfile", ht);
                int iRet = cmd.ExecuteNonQuery();
                sReturnData = "Y";
            }
            catch { sReturnData = ""; }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return sReturnData;
        }



    }
}