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
		public static int Check_IA_Student_Exists(string pk_Uni_ID, string pk_Year, string pk_Institute_ID, string pk_Student_ID)
		{	
			int Flag = 0;
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
				ht.Add("pk_Institute_ID",pk_Institute_ID);
				ht.Add("pk_Student_ID",pk_Student_ID);
				ht.Add("ExistsFlag",Flag);
				cmd = oDB.GenerateCommand("elg_Check_IA_Student_Exists",ht);
				cmd.Parameters["@ExistsFlag"].Direction  = ParameterDirection.Output;
				cmd.ExecuteNonQuery();
				Flag = Convert.ToInt32(cmd.Parameters["@ExistsFlag"].Value.ToString());
				
				
			}
			catch(Exception Ex)
			{
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			return Flag;

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

		public static DataSet Check_Reg_Pending_Student_Exists(string Ref_pk_Uni_ID, string Ref_pk_Year, string Ref_pk_Institute_ID, string Ref_pk_Student_ID)
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
				ht.Add("Ref_pk_Year",Ref_pk_Year);
				ht.Add("Ref_pk_Institute_ID",Ref_pk_Institute_ID);
				ht.Add("Ref_pk_Student_ID",Ref_pk_Student_ID);
				ds = oDB.getparamdataset("elg_Check_Reg_Pending_Student_Exists",ht);
				return ds;
			}
			
			catch(Exception Ex)
			{
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}


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
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

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
		public static DataSet Fetch_IA_Student_List(string Uni_ID,string InstTy_ID,string Inst_Name,string Inst_State_ID,string Inst_District_ID,string Inst_Tehsil_ID,string FacultyID, string CourseID, string CrMoLrnPtrnID, string CrPrID, string DOB, string LastName, string FirstName, string Gender)
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
				ds = oDB.getparamdataset("elg_Fetch_IA_StudentList",ht);
				return ds;
			}
			
			catch(Exception Ex)
			{
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}


        public static DataSet Fetch_Pending_Reg_Student_List_Resolve(string Uni_ID, string Inst_ID,string FacultyID, string CourseID, string CrMoLrnPtrnID, string CrPrID, string DOB, string LastName, string FirstName, string Gender)
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
                ht.Add("RefInst_ID", Inst_ID);                
                ht.Add("FacultyID", FacultyID);
                ht.Add("CrID", CourseID);
                ht.Add("CrMoLrnPtrnID", CrMoLrnPtrnID);
                ht.Add("CrPrID", CrPrID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ds = oDB.getparamdataset("elg_Fetch_Pending_Reg_StudentList_Resolve", ht);
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

        #region Fetch Provisionally Eligible Reg Student List Resolve
        public static DataSet Fetch_ProvisionallyEligible_Reg_Student_List_Resolve(string Uni_ID, string Inst_ID, string FacultyID, string CourseID, string CrMoLrnPtrnID, string CrPrID, string DOB, string LastName, string FirstName, string Gender)
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
                ht.Add("RefInst_ID", Inst_ID);
                ht.Add("FacultyID", FacultyID);
                ht.Add("CrID", CourseID);
                ht.Add("CrMoLrnPtrnID", CrMoLrnPtrnID);
                ht.Add("CrPrID", CrPrID);
                ht.Add("DOB", DOB);
                ht.Add("LastName", LastName);
                ht.Add("FirstName", FirstName);
                ht.Add("Gender", Gender);
                ds = oDB.getparamdataset("elg_Fetch_ProvisionallyEligible_Reg_StudentList_Resolve", ht);
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
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}
/// <summary>
/// This function is used to fill the Advanced Search Control with the selected conditions used for search.
/// </summary>
/// <param name="Uni_ID"></param>
/// <param name="State_ID"></param>
/// <param name="District_ID"></param>
/// <param name="Tehsil_ID"></param>
/// <param name="DOB"></param>
/// <param name="LastName"></param>
/// <param name="FirstName"></param>
/// <param name="Gender"></param>
/// <returns>DataSet</returns>
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
				ds = oDB.getparamdataset("elg_Fetch_Reg_StudentList",ht);
				return ds;
			}
			
			catch(Exception Ex)
			{
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
			  			
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
		public static string[] Register_Fresh_Student(string Ref_pk_Uni_ID,string Ref_pk_Year, string Ref_pk_Institute_ID, string  Ref_pk_Student_ID, string ElgDecision, string Reason,  string pk_CrMoLrnPtrn_ID, string UserID, System.Text.StringBuilder DocXML)
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
				ht.Add("pk_CrMoLrnPtrn_ID",pk_CrMoLrnPtrn_ID);
				ht.Add("UserID",UserID);
				ht.Add("DocXML",DocXML.ToString());
				ht.Add("PRN","");
				ht.Add("Error",0);
				cmd = oDB.GenerateCommand("elg_Register_Fresh_Student",ht);
				cmd.Parameters["@PRN"].Direction=ParameterDirection.Output;
				cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
				cmd.ExecuteNonQuery();
				arr[0]=cmd.Parameters["@PRN"].Value.ToString();
				arr[1]=cmd.Parameters["@Error"].Value.ToString();
				return arr;
				
			}
			catch(Exception Ex)
			{
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
			  			
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
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
			  			
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}
	
		#endregion

        

        #endregion

        #region Liwia


        #region Fetch Students Details of a Pending Candidate From REG for Eligibility Revising
        /// <summary>
		/// This function Fetch Students Details of a Pending Candidate From REG for Eligibility Revising
		/// </summary>
		/// <param name="Uni_ID" >University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
		public static DataSet Fetch_REG_Pending_Student_Details(int pk_Uni_ID, int pk_Year,int pk_Student_ID,int Ref_Uni_ID,int Ref_Year,int Ref_Institute_ID,int Ref_Student_ID ,int pk_CrMoLrnPtrn_ID)
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
				ht.Add("Ref_Year",Ref_Year);
				ht.Add("Ref_Institute_ID",Ref_Institute_ID);
				ht.Add("Ref_Student_ID",Ref_Student_ID);
				ht.Add("pk_CrMoLrnPtrn_ID",pk_CrMoLrnPtrn_ID);
				ds = oDB.getparamdataset("elg_Fetch_REG_Pending_Student_Details",ht);
				return ds;
			}
			catch(Exception Ex)
			{
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
			  			
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
        public static DataSet Fetch_REG_ProvisionallyEligible_Student_Details(int pk_Uni_ID, int pk_Year, int pk_Student_ID, int Ref_Uni_ID, int Ref_Year, int Ref_Institute_ID, int Ref_Student_ID, int pk_CrMoLrnPtrn_ID)
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
                ht.Add("Ref_Year", Ref_Year);
                ht.Add("Ref_Institute_ID", Ref_Institute_ID);
                ht.Add("Ref_Student_ID", Ref_Student_ID);
                ht.Add("pk_CrMoLrnPtrn_ID", pk_CrMoLrnPtrn_ID);
                ds = oDB.getparamdataset("elg_Fetch_REG_ProvisionallyEligible_Student_Details", ht);
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
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
			  			
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
		public static string[] REG_PendingStudentEligibilityDecision (int pk_Uni_ID, int pk_Year,int pk_Student_ID,int pk_CrMoLrnPtrn_ID,int Ref_Uni_ID,int Ref_Year,int Ref_Institute_ID,int Ref_Student_ID,string ElgDecisionFlag,System.Text.StringBuilder DocXML,string Reason,string ExisitngPRN,string UserID)
		{
			
//			SqlParameter[] pr = new SqlParameter[10];
//			try
//			{
//				pr[0] = new SqlParameter("@pk_Uni_ID",pk_Uni_ID);
//				pr[1] = new SqlParameter("@pk_Year",pk_Year);
//				pr[2] = new SqlParameter("@pk_Student_ID",pk_Student_ID);
//				pr[3] = new SqlParameter("@pk_CrMoLrnPtrn_ID",pk_CrMoLrnPtrn_ID);
//
//				pr[4] = new SqlParameter("@ElgDecisionFlag",ElgDecisionFlag);
//				//pr[5] = new SqlParameter("@DocXML",DocXML);
//				pr[5] = new SqlParameter("@DocXML",SqlDbType.Text);
//				pr[5].Value = Convert.ToString(DocXML);
//				pr[6] = new SqlParameter("@reason",reason);
//				pr[7] = new SqlParameter("@ExisitngPRN",ExistingPRN);
//				pr[8] = new SqlParameter("@UserID",UserID);
//				pr[9] = new SqlParameter("@PRN",SqlDbType.Char,11);
//				pr[9].Direction = ParameterDirection.Output ;
//				
//				SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"],CommandType.StoredProcedure,"Elg_PendingStudent_EligibilityDecision",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return pr[9].Value.ToString();
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
				ht.Add("pk_CrMoLrnPtrn_ID",pk_CrMoLrnPtrn_ID);
				ht.Add("Ref_Uni_ID",Ref_Uni_ID);
				ht.Add("Ref_Year",Ref_Year);
				ht.Add("Ref_Institute_ID",Ref_Institute_ID);
				ht.Add("Ref_Student_ID",Ref_Student_ID);
               // ht.Add("pk_CrMoLrnPtrn_ID",pk_CrMoLrnPtrn_ID);
				ht.Add("ElgDecisionFlag",ElgDecisionFlag);
				ht.Add("DocXML",DocXML.ToString());
				ht.Add("Reason",Reason);
				ht.Add("UserID",UserID);
				ht.Add("ExisitngPRN",ExisitngPRN);
				ht.Add("PRN","");
				ht.Add("Error",0);
				cmd = oDB.GenerateCommand("Elg_PendingStudent_EligibilityDecision",ht);
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
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
			  			
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
        public static string[] REG_ProvisionallyEligibleStudentEligibilityDecision(int pk_Uni_ID, int pk_Year, int pk_Student_ID, int pk_CrMoLrnPtrn_ID, int Ref_Uni_ID, int Ref_Year, int Ref_Institute_ID, int Ref_Student_ID, string ElgDecisionFlag, System.Text.StringBuilder DocXML, string Reason, string ExisitngPRN, string UserID)
        {

            //			SqlParameter[] pr = new SqlParameter[10];
            //			try
            //			{
            //				pr[0] = new SqlParameter("@pk_Uni_ID",pk_Uni_ID);
            //				pr[1] = new SqlParameter("@pk_Year",pk_Year);
            //				pr[2] = new SqlParameter("@pk_Student_ID",pk_Student_ID);
            //				pr[3] = new SqlParameter("@pk_CrMoLrnPtrn_ID",pk_CrMoLrnPtrn_ID);
            //
            //				pr[4] = new SqlParameter("@ElgDecisionFlag",ElgDecisionFlag);
            //				//pr[5] = new SqlParameter("@DocXML",DocXML);
            //				pr[5] = new SqlParameter("@DocXML",SqlDbType.Text);
            //				pr[5].Value = Convert.ToString(DocXML);
            //				pr[6] = new SqlParameter("@reason",reason);
            //				pr[7] = new SqlParameter("@ExisitngPRN",ExistingPRN);
            //				pr[8] = new SqlParameter("@UserID",UserID);
            //				pr[9] = new SqlParameter("@PRN",SqlDbType.Char,11);
            //				pr[9].Direction = ParameterDirection.Output ;
            //				
            //				SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"],CommandType.StoredProcedure,"Elg_PendingStudent_EligibilityDecision",pr);
            //			}
            //			catch(Exception Ex)
            //			{
            //				Exception e = new Exception(Ex.Message,Ex);
            //				throw(e);
            //			  			
            //			}
            //			return pr[9].Value.ToString();
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
                ht.Add("pk_CrMoLrnPtrn_ID", pk_CrMoLrnPtrn_ID);
                ht.Add("Ref_Uni_ID", Ref_Uni_ID);
                ht.Add("Ref_Year", Ref_Year);
                ht.Add("Ref_Institute_ID", Ref_Institute_ID);
                ht.Add("Ref_Student_ID", Ref_Student_ID);
                // ht.Add("pk_CrMoLrnPtrn_ID",pk_CrMoLrnPtrn_ID);
                ht.Add("ElgDecisionFlag", ElgDecisionFlag);
                ht.Add("DocXML", DocXML.ToString());
                ht.Add("Reason", Reason);
                ht.Add("UserID", UserID);
                ht.Add("ExisitngPRN", ExisitngPRN);
                ht.Add("PRN", "");
                ht.Add("Error", 0);
                cmd = oDB.GenerateCommand("Elg_ProvisionallyEligibleStudent_EligibilityDecision", ht);
                cmd.Parameters["@PRN"].Direction = ParameterDirection.Output;
                cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                arr[0] = cmd.Parameters["@PRN"].Value.ToString();
                arr[1] = cmd.Parameters["@Error"].Value.ToString();
                //ds=getparamdataset("elg_Fetch_REG_Pending_Student_Details",ht);
                return arr;
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
        public static DataSet REG_Search_GetStudentIDs(int Ref_Uni_ID, int Ref_Year, int Ref_Institute_ID, int Ref_Student_ID, string PRN)
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
				ds = oDB.getparamdataset("REG_Search_GetStudentIDs",ht);
				return ds;
			}
			catch(Exception Ex)
			{
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
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
		public static DataSet REG_Get_Eligibilitystatusdetails(int pk_Uni_ID, int pk_Year,int pk_Student_ID,int Ref_Uni_ID,int Ref_Year,int Ref_Institute_ID,int Ref_Student_ID ,string PRN)
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
				ht.Add("Ref_Year",Ref_Year);
				ht.Add("Ref_Institute_ID",Ref_Institute_ID);
				ht.Add("Ref_Student_ID",Ref_Student_ID);
				ht.Add("PRN",PRN);
				ds = oDB.getparamdataset("REG_Get_Eligibilitystatusdetails",ht);
				return ds;
			}
			catch(Exception Ex)
			{
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
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
		public static DataSet Elg_AdvSearch_StudentEligibilityDetails(int pk_Uni_ID, int pk_Year,int pk_Student_ID,string PRN)
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
                ht.Add("PRN", PRN);
				ds = oDB.getparamdataset("Elg_AdvSearch_StudentEligibilityDetails",ht);
				return ds;
			}
			catch(Exception Ex)
			{
				Exception e = new Exception(Ex.Message,Ex);
				throw(e);
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}
		#endregion
		#endregion

	}
}

