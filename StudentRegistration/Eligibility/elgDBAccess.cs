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
	/// Summary description for elgDBAccess.
	/// </summary>
	public class elgDBAccess 
	{
		public elgDBAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		
		#region  by Farhat
		/// <summary>
		/// This function Fetches the  Districts in the University.
		/// </summary>
		/// <param name="Uni_ID" >University ID</param>
//		public static DataSet Fetch_UniversityWise_Districts(int Uni_ID)
//		{
//			
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[1];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@Uni_ID",Uni_ID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"elg_FetchUniversityWiseDistricts",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		/// <summary>
		/// This function Fetches the Tehsils in the University.
		/// </summary>
		/// <param name="District_ID">District ID</param>
		/// <param name="Lang_Flag">Language Flag</param>
//		public static DataSet Fetch_Tehsils(int District_ID,string Lang_Flag)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[2];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@District_ID",District_ID);
//				pr[1] = new SqlParameter("@Lang_Flag",Lang_Flag);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"GEN_districtWiseTaluka",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		
		#region Fetch institutes who have uploaded student data for Eligibility check
		/// <summary>
		/// This function Fetches the  College List in the University.
		/// </summary>
		/// <param name="Uni_ID" >University ID</param>
		/// <param name="InstTy_ID">Institute Type</param>
		/// <param name="Inst_Name">Institute Name</param>
		/// <param name="Country_ID">Country ID</param>
		/// <param name="State_ID">State ID</param>
		/// <param name="District_ID">District ID</param>
		/// <param name="Tehsil_ID">Tehsil ID</param>
//		public static DataSet Fetch_College_List(string Uni_ID,string InstTy_ID,string Inst_Name,string Country_ID,string State_ID,string District_ID,string Tehsil_ID)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[7];	
//			try
//			{
//				
//				pr[0] = new SqlParameter("@Uni_ID",Uni_ID);
//				pr[1] = new SqlParameter("@InstTy_ID",InstTy_ID);
//				pr[2] = new SqlParameter("@Inst_Name",Inst_Name);
//				pr[3] = new SqlParameter("@Country_ID",Country_ID);
//				pr[4] = new SqlParameter("@State_ID",State_ID);
//				pr[5] = new SqlParameter("@District_ID",District_ID);
//				pr[6] = new SqlParameter("@Tehsil_ID",Tehsil_ID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"elg_fetchcollegelist",pr);
//			}
//			
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		#endregion
		
		#region Fetch Students Details(same function is used in clsEligibilityDBAccess class)
		/// <summary>
		/// This function Fetches the  Details of a Particular Regular Student 
		/// </summary>
		/// <param name="Uni_ID" >University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
		public static DataSet IA_Fetch_Student_Details(string Year, string Uni_ID, string Institute_ID, string Student_ID)
		{	
			DataSet ds = new DataSet();
			//SqlParameter[] pr = new SqlParameter[4];
			Hashtable ht=new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
//				pr[0] = new SqlParameter("@pk_Uni_ID",Uni_ID);
//				pr[1] = new SqlParameter("@pk_Institute_ID",Institute_ID);
//				pr[2] = new SqlParameter("@pk_Student_ID",Student_ID);
//				pr[3] = new SqlParameter("@pk_Year", Year);
				ht.Add("pk_Uni_ID",Uni_ID);
				ht.Add("pk_Institute_ID",Institute_ID);
				ht.Add("pk_Student_ID",Student_ID);
				ht.Add("pk_Year", Year);
				ds = oDB.getparamdataset("elg_Fetch_IA_Student_Details",ht);
				return ds;
				//ds = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"],CommandType.StoredProcedure,"elg_Fetch_IA_Student_Details",pr);
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
		/// This function Fetches the  Student Photograph of Regular Students
		/// </summary>
		/// <param name="Uni_ID" >University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
		public static DataSet IA_Fetch_Student_Photograph(string Year, string Uni_ID, string Institute_ID, string Student_ID)
		{
			Hashtable ht = new Hashtable();
			DataSet ds;
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				
				ht.Add("pk_Year",Year);
				ht.Add("pk_Uni_ID",Uni_ID);
				ht.Add("pk_Institute_ID",Institute_ID);
				ht.Add("pk_Student_ID",Student_ID);
				ds = oDB.getparamdataset("elg_Fetch_IA_Student_Photo",ht);
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
		/// This function Fetches the  Student Signature of Regular Students
		/// </summary>
		/// <param name="Uni_ID" >University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
		public static DataSet IA_Fetch_Student_Signature(string Year, string Uni_ID, string Institute_ID, string Student_ID)
		{
			DataSet ds;
			Hashtable ht = new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				
				//				pr[0] = new SqlParameter("@pk_Uni_ID",Uni_ID);
				//				pr[1] = new SqlParameter("@pk_Institute_ID",Institute_ID);
				//				pr[2] = new SqlParameter("@pk_Student_ID",Student_ID);
				ht.Add("pk_Year",Year);
				ht.Add("pk_Uni_ID",Uni_ID);
				ht.Add("pk_Institute_ID",Institute_ID);
				ht.Add("pk_Student_ID",Student_ID);
				ds = oDB.getparamdataset("elg_Fetch_IA_Student_Sign",ht);
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
		/// This function Fetches the Details of an External Student
		/// </summary>
		/// <param name="Uni_ID" >University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
//		public static DataSet EA_Fetch_Student_Details(string Uni_ID, string Institute_ID, string Student_ID)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[3];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@pk_Uni_ID",Uni_ID);
//				pr[1] = new SqlParameter("@pk_Institute_ID",Institute_ID);
//				pr[2] = new SqlParameter("@pk_Student_ID",Student_ID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"elg_Fetch_EA_Student_Details",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		/// <summary>
		/// This function Fetch the Photograph of an External Student
		/// </summary>
		/// <param name="Uni_ID" >University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
//		public static SqlDataReader EA_Fetch_Student_Photograph(string Uni_ID, string Institute_ID, string Student_ID)
//		{
//			SqlDataReader dr;
//			SqlParameter[] pr = new SqlParameter[3];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@pk_Uni_ID",Uni_ID);
//				pr[1] = new SqlParameter("@pk_Institute_ID",Institute_ID);
//				pr[2] = new SqlParameter("@pk_Student_ID",Student_ID);
//				dr = SqlHelper.ExecuteReader(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"elg_Fetch_EA_Student_Photo",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			
//			return dr;
//		}
		/// <summary>
		/// This function Fetch the Signature of an External Student
		/// </summary>
		/// <param name="Uni_ID" >University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
//		public static SqlDataReader EA_Fetch_Student_Signature(string Uni_ID, string Institute_ID, string Student_ID)
//		{
//			SqlDataReader dr;
//			SqlParameter[] pr = new SqlParameter[3];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@pk_Uni_ID",Uni_ID);
//				pr[1] = new SqlParameter("@pk_Institute_ID",Institute_ID);
//				pr[2] = new SqlParameter("@pk_Student_ID",Student_ID);
//				dr = SqlHelper.ExecuteReader(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"elg_Fetch_EA_Student_Sign",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//				return dr;
//		}
		/// <summary>
		/// This function Fetch the Details of a Registered Sudent  Details using PRN
		/// </summary>
		/// <param name="PRN">Permanent Registration Number</param>
//		public static DataSet Reg_Fetch_Student_Details(string PRN)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[1];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@PRN",PRN);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"elg_Fetch_Reg_Student_Details",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		/// <summary>
		/// This function Fetch the Details of a Registered Sudent Photograph using PRN
		/// </summary>
		/// <param name="PRN">Permanent Registration Number</param>
        public static DataSet Reg_Fetch_Student_Photograph(int Ref_pk_Uni_ID, int Ref_pk_Year, int Ref_pk_Institute_ID, int Ref_pk_Student_ID)
		{
			DataSet ds;		
			Hashtable ht=new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
                ht.Add("Ref_pk_Uni_ID",Ref_pk_Uni_ID);
                ht.Add("Ref_pk_Year",Ref_pk_Year);
                ht.Add("Ref_pk_Institute_ID",Ref_pk_Institute_ID);
                ht.Add("Ref_pk_Student_ID", Ref_pk_Student_ID);

				ds = oDB.getparamdataset("elg_Fetch_Reg_Student_Photo",ht);
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
		/// This function Fetch the Details of a Registered Sudent Signature using PRN
		/// </summary>
		/// <param name="PRN">Permanent Registration Number</param>
        public static DataSet Reg_Fetch_Student_Signature(int Ref_pk_Uni_ID, int Ref_pk_Year, int Ref_pk_Institute_ID, int Ref_pk_Student_ID)
		{
			
			DataSet ds;
			Hashtable ht = new Hashtable();
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

				ds = oDB.getparamdataset("elg_Fetch_Reg_Student_Sign",ht);
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
	
		#region Generate PRN and Register Student
		/// <summary>
		/// This function Generates PRN(Permanent Registration Number)  for an Eligibile Regular Student
		/// </summary>
		/// <param name="Uni_ID">University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
		/// <param name="DocXML">A String Builder in XML Format used to store the Document details 
		/// as recieved by the University. DocXML contains NewDataSet/StudentDocs as root node.  </param>
//		public static string[] GeneratePRN_Register_IA_Student(string Uni_ID, string Institute_ID, string Student_ID, System.Text.StringBuilder DocXML)
//		{
//			string[] arr = new string[2];
//			SqlParameter[] pr = new SqlParameter[6];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@pk_Uni_ID",Uni_ID);
//				pr[1] = new SqlParameter("@pk_Institute_ID",Institute_ID);
//				pr[2] = new SqlParameter("@pk_Student_ID",Student_ID);
//				pr[3] = new SqlParameter("@DocXML",SqlDbType.Text);
//				pr[3].Value = Convert.ToString(DocXML);
//				//pr[3] = new SqlParameter("@DocXML",DocXML);
//				pr[4] = new SqlParameter("@PRN",SqlDbType.Char,11);
//				pr[4].Direction = ParameterDirection.Output;
//				pr[5] = new SqlParameter("@ElgFormNo",SqlDbType.VarChar,50);
//				pr[5].Direction = ParameterDirection.Output;
//				SqlHelper.ExecuteScalar(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"elg_generatePRN_Register_IA_Student",pr);
//				arr[0] = pr[4].Value.ToString();
//				arr[1] = pr[5].Value.ToString();
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return arr;
//
//		}
		/// <summary>
		///  This function Generates PRN(Permanent Registration Number)  for an Eligibile External Student
		/// </summary>
		/// <param name="Uni_ID">Univeristy ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
		/// <param name="DocXML">A String Builder in XML Format used to store the Document details 
		/// as recieved by the University. DocXML contains NewDataSet/StudentDocs as root node.</param>
		/// <returns></returns>
//		public static string[] GeneratePRN_Register_EA_Student(string Uni_ID, string Institute_ID, string Student_ID, System.Text.StringBuilder DocXML)
//		{
//			
//			string[] arr = new string[2];
//			SqlParameter[] pr = new SqlParameter[6];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@pk_Uni_ID",Uni_ID);
//				pr[1] = new SqlParameter("@pk_Institute_ID",Institute_ID);
//				pr[2] = new SqlParameter("@pk_Student_ID",Student_ID);
//				pr[3] = new SqlParameter("@DocXML",SqlDbType.Text);
//				pr[3].Value = Convert.ToString(DocXML);
//				pr[4] = new SqlParameter("@PRN",SqlDbType.Char,11);
//				pr[4].Direction = ParameterDirection.Output;
//				pr[5] = new SqlParameter("@ElgFormNo",SqlDbType.VarChar,50);
//				pr[5].Direction = ParameterDirection.Output;
//				SqlHelper.ExecuteScalar(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"elg_generatePRN_Register_EA_Student",pr);
//				arr[0] = pr[4].Value.ToString();
//				arr[1] = pr[5].Value.ToString();
//			
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return arr;
//
//		}
		 

		#endregion
		
		#region Mark Student Non-Eligible or Keep his/her Eligibility Pending
		/// <summary>
		/// This function is used to mark a student as Non-Eligible and to keep his details as Pending 
		/// with  the Reason.An Entry is made in to Elg_NonElgAndPendingElgStudents table 
		/// with status and Reason.
		/// </summary>
		/// <param name="Uni_ID">University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <param name="Student_ID">Student ID</param>
		/// <param name="Status">Status 0- Not Eligible ,Status 1-Pending </param>
		/// <param name="Reason">Reason for why the Student is made Non-Eligible or Pending</param>
//		public static void Enter_NonElg_PendingStudents(string Uni_ID, string Institute_ID, string Student_ID, int Status, string Reason)
//		{
//			
//			SqlParameter[] pr = new SqlParameter[5];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@pk_Uni_ID",Uni_ID);
//				pr[1] = new SqlParameter("@pk_Institute_ID",Institute_ID);
//				pr[2] = new SqlParameter("@pk_Student_ID",Student_ID);
//				pr[3] = new SqlParameter("@Status",Status);
//				pr[4] = new SqlParameter("@Reason", Reason);
//				SqlHelper.ExecuteNonQuery(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_NonElgPendingStudents",pr);
//			}
//			catch(Exception Ex)
//			{
//			  Exception e = new Exception(Ex.Message,Ex);
//			  throw(e);
//			  			
//			}
//		}

		#endregion
		
		
		#region Reports
		/// <summary>
		/// For Reports
		/// To get the College wise Course Statistics of the Eligibility Determination 
		/// of Students by the University.
		/// </summary>
		/// <param name="Uni_ID">University ID</param>
		/// <param name="Institute_ID">Institute ID</param>
		/// <returns></returns>
//		public static DataSet GetCollegewiseCoursesStats(string Uni_ID, string Institute_ID)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[2];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@UniID",Uni_ID);
//				pr[1] = new SqlParameter("@Institute_ID",Institute_ID);
//				//ds = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"],CommandType.StoredProcedure,"ELG_IA_CollegeWiseCoursesStatistics",pr);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_College_CourseWiseStatistics",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}

		


		#endregion

		
		#endregion

		#region by Liwia 
		
	
		#region fetch Collegewise -Eligibility pending Students
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// This function is used to get the Students(DataSet) Whose eligibility is Pending 
		/// under a Particular Institute for a Particular Course in the University.
		/// </summary>
		/// <param name="Uni_ID">Univeristy ID</param>
		/// <param name="Inst_ID">Institute ID </param>
		/// <param name="CrPr_ID">CoursePart ID</param>
		/// <param name="CrMoLrnPtrnID">Course Mode Of Learning Pattern ID</param>
//		public static DataSet GetElgPendingStudents(int UniID,int InstID,int CrPrID,int CrMoLrnPtrnID)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[4];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@InstID",InstID);
//				pr[2] = new SqlParameter("@CrPrID",CrPrID);
//				pr[3] = new SqlParameter("@CrMoLrnPtrnID",CrMoLrnPtrnID);
//			
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"elg_GetElgPendingStudents",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		#endregion

		
		
		#region GetAllFaculties
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// This function returns the Faculty list of the University in a DataSet.
		/// </summary>
		/// <param name="UniID">Univeristy ID</param>
		
		public static DataSet GetAllFaculties(int UniID)
		{
			DataSet ds = new DataSet();
			//SqlParameter[] pr = new SqlParameter[1];
			Hashtable ht=new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				
				ht.Add("UniID",UniID);
				ds = oDB.getparamdataset("ELG_SelectAllFaculty",ht);
				return ds;
				//ds = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"],CommandType.StoredProcedure,"ELG_SelectAllFaculty",pr);
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
		
	
		
		#region Select  ALL Courses
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// This function returns the Courses under a Faculty in the University using DataSet.
		/// </summary>
		/// <param name="UniID">Univeristy ID</param>
		public static DataSet selFacultyWiseAllCourses(int UniID,int FacID)
		{
			DataSet ds;
			//SqlParameter[] pr = new SqlParameter[2];	
			Hashtable ht= new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				 
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@FacID",FacID);
				ht.Add("UniID",UniID);
				ht.Add("FacID",FacID);
				ds = oDB.getparamdataset("ELG_FacultyWiseAllCourses",ht);
				return ds;
				//ds = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"],CommandType.StoredProcedure,"ELG_FacultyWiseAllCourses",pr);
				//			ArrayList Arrds=new ArrayList(1);
				//			Arrds.Add(ds);
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
		
		
		#region Select  ALL CoursesPart Ext & reg
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// This function returns the CoursePart for Regular Students  under a Faculty in the University
		/// using DataSet.
		/// </summary>
		/// <param name="UniID">Univeristy ID</param>
		/// <param name="FacID">Faculty ID</param>
		/// <param name="CrID">CourseID</param>
		public static DataSet  selAllCoursePart(int UniID,int FacID,int CrID)
		{
			DataSet ds;
			//SqlParameter[] pr = new SqlParameter[3];
			Hashtable ht=new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@FacID",FacID);
//				pr[2] = new SqlParameter("@CrID",CrID);
				ht.Add("UniID",UniID);
				ht.Add("FacID",FacID);
				ht.Add("CrID",CrID);
				ds = oDB.getparamdataset("ELG_RegularCoursePart",ht);
				return ds;
				//ds = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"],CommandType.StoredProcedure,"ELG_RegularCoursePart",pr);
				//			ArrayList Arrds=new ArrayList(1);
				//			Arrds.Add(ds);
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
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// This function returns the CoursePart for External Students  under a Faculty in the University
		/// using DataSet.
		/// </summary>
		/// <param name="UniID">Univeristy ID</param>
		/// <param name="FacID">Faculty ID</param>
		/// <param name="CrID">CourseID</param>
//		public static DataSet  selExtAllCoursePart(int UniID,int FacID,int CrID)
//		{
//			DataSet ds;
//			SqlParameter[] pr = new SqlParameter[3];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@FacID",FacID);
//				pr[2] = new SqlParameter("@CrID",CrID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_ExternalCoursePart",pr);
//				//			ArrayList Arrds=new ArrayList(1);
//				//			Arrds.Add(ds);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		
		#endregion

		
		
		#region Get Coursewise -Eligibility Pending Students
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// This function returns the Course Wise list of Regular Students whose
		/// eligibility is Pending using DataSet.
		/// </summary>
		/// <param name="UniID">Univeristy ID</param>
		/// <param name="CrMoLrnPtrnID">Course Mode Of Learning Pattern ID</param>
		/// <param name="CrPrID">Course Part ID</param>
//		public static DataSet GetCourseWiseIAStudents(int UniID , int CrMoLrnPtrnID , int CrPrID)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[3];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@CrMoLrnPtrnID",CrMoLrnPtrnID);
//				pr[2] = new SqlParameter("@CrPrID",CrPrID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_IA_CoursePartWiseStudents",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// This function returns the Course Wise list of External Students whose
		/// eligibility is Pending using DataSet.
		/// </summary>
		/// <param name="UniID">Univeristy ID</param>
		/// <param name="CrMoLrnPtrnID">Course Mode Of Learning Pattern ID</param>
		/// <param name="CrPrID">Course Part ID</param>
//		public static DataSet GetCourseWiseEAStudents(int UniID , int CrMoLrnPtrnID , int CrPrID)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[3];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@CrMoLrnPtrnID",CrMoLrnPtrnID);
//				pr[2] = new SqlParameter("@CrPrID",CrPrID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_EA_CoursePartWiseStudents",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		#endregion
		
		
		
		#region Select  Institute Wise - Faculty
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// This function returns the list of Faculties in a Particular Institute using DataSet.
		/// </summary>
		/// <param name="UniID">Univeristy ID</param>
		/// <param name="InstID">Institute ID</param>
//		public static  DataSet selInstituteWiseFaculty(int UniID,int InstID)
//		{
//			
//			DataSet ds;
//			SqlParameter[] pr = new SqlParameter[2];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@InstID",InstID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_InstituteWiseFaculties",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		#endregion
		
		
			
		#region Select Institute Wise - Courses
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// This function returns the list of Courses in a Particular Institute using DataSet.
		/// </summary>
		/// <param name="UniID">Univeristy ID</param>
		/// <param name="InstID">Institute ID</param>
		/// <param name="FacID">Faculty ID</param>
//		public static DataSet selInstituteWiseCourses(int UniID,int InstID,int FacID)
//		{
//			DataSet ds;
//			SqlParameter[] pr = new SqlParameter[3];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@InstID",InstID);
//				pr[2] = new SqlParameter("@FacID",FacID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_InstFacultyWiseCourses",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		#endregion

		
		#region Select  CoursesPart
		
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// This function returns the list of Courses in a Particular Institute using DataSet.
		/// </summary>
		/// <param name="UniID">Univeristy ID</param>
		/// <param name="InstID">Institute ID</param>
		/// <param name="FacID">Faculty ID</param>
		/// <param name="CrID">Course ID </param>
			
//		public static DataSet selInstituteWiseCoursePart(int UniID,int InstID,int FacID,int CrID)
//		{
//			DataSet ds;
//			SqlParameter[] pr = new SqlParameter[4];
//			
//			try
//			{
//				
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@InstID",InstID);
//				pr[2] = new SqlParameter("@FacID",FacID);
//				pr[3] = new SqlParameter("@CrID",CrID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_InstCourseWiseCoursePart",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//				return ds;
//		}
		#endregion
		
		
		
		#region Select  Regular Courses wise Statistics	
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// For Reports
		/// This function gets the Course Wise Statistics about the Uploaded Students for
		/// Eligibility determination for the Academic Year in the University.
		/// </summary>
		/// <param name="UniID">University ID</param>
		
//		public static DataSet selRepCourseWiseStatistics(int UniID)
//		{
//			DataSet ds;
//			SqlParameter[] pr = new SqlParameter[1];
//			
//			try
//			{
//				pr[0] = new SqlParameter("@UniID",UniID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_IA_RepCourseWiseStatistics",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		#endregion
		
		
		# region The Functions for getting College-CourseWise Student Summary Reports 
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// For Reports
		/// This function gets the  College Wise Course  Student Summary of Regular Students
		/// about the  Eligibility determination for the Academic Year in the University.
		/// Flags are used for the Filteration of Student Summary.
		/// </summary>
		/// <param name="UniID" >University ID</param>
		/// <param name="InstID">Institute ID</param>
		/// <param name="elgFlg">Eligibility Flag (0,if not selected else 1) </param>
		/// <param name="nonElgFlg">Non-Eligibility Flag (0,if not selected else 1)</param>
		/// <param name="pendFlg">Pending Flag(0,if not selected else 1)</param>
		/// <param name="CrMoLrnPtrnID">Course Mode Of Learning Pattern ID</param>
		/// <param name="CrPr_ID">Course Part ID</param>
//		public static DataSet GetIACollegeCourseWiseStudentsSum(int elgFlg,int nonElgFlg,int pendFlg,int UniID,int InstID,int CrPr_ID,int CrMoLrnPtrnID)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[7];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@Elg",elgFlg);
//				pr[1] = new SqlParameter("@NonElg",nonElgFlg);
//				pr[2] = new SqlParameter("@Pend",pendFlg);
//				pr[3] = new SqlParameter("@UniID",UniID);
//				pr[4] = new SqlParameter("@InstID",InstID);
//				pr[5] = new SqlParameter("@CrPrID",CrPr_ID);
//				pr[6] = new SqlParameter("@CrMoLrnPtrnID",CrMoLrnPtrnID);
//			
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"Elg_IA_CollegeCoursewiseStudSummary",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}


		# endregion
		
		# region The Functions for getting CourseWise Student Summary Report : Divneet
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// For Reports
		/// This function gets the  College Wise Course  Student Summary of Regular Students
		/// about the  Eligibility determination for the Academic Year in the University.
		/// Flags are used for the Filteration of Student Summary.
		/// </summary>
		/// <param name="UniID" >University ID</param>
		/// <param name="Inst_ID">Institute ID</param>
		/// <param name="elgFlg">Eligibility Flag (0,if not selected else 1) </param>
		/// <param name="nonElgFlg">Non-Eligibility Flag (0,if not selected else 1)</param>
		/// <param name="pendFlg">Pending Flag(0,if not selected else 1)</param>
		/// <param name="CrMoLrnPtrnID">Course Mode Of Learning Pattern ID</param>
		/// <param name="CrPr_ID">Course Part ID</param>
//		public static DataSet GetCombinationStudentsSum(int elgFlg,int nonElgFlg,int pendFlg,int UniID,int CrPr_ID,int CrMoLrnPtrnID)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[6];
//			try
//			{
//				
//				pr[0] = new SqlParameter("@Elg",elgFlg);
//				pr[1] = new SqlParameter("@NonElg",nonElgFlg);
//				pr[2] = new SqlParameter("@Pend",pendFlg);
//				pr[3] = new SqlParameter("@UniID",UniID);
//				pr[4] = new SqlParameter("@CrPrID",CrPr_ID);
//				pr[5] = new SqlParameter("@CrMoLrnPtrnID",CrMoLrnPtrnID);
//			
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_IA_CourseWiseCombinationsSummary",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}

		


		#endregion
		
		#region Select  Courses wise Statistics	
		//For External Students
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// For Reports
		/// This function gets the  Course Wise Statistics of External Students
		/// about the  Eligibility determination for the Academic Year in the University.
		/// </summary>
		/// <param name="UniID" >University ID</param>
//		public static DataSet selEARepCourseWiseStatistics(int UniID)
//		{
//			DataSet ds;
//			SqlParameter[] pr = new SqlParameter[1];
//
//			try
//			{
//				
//				pr[0] = new SqlParameter("@UniID",UniID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_EA_RepCourseWiseStatistics",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		#endregion
		
	
		# region External Students - The Functions for getting CourseWise Student Summary Report 
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// For Reports
		/// This function gets the  College Wise Course  Student Summary of External Students
		/// about the  Eligibility determination for the Academic Year in the University.
		/// Flags are used for the Filteration of Student Summary.
		/// </summary>
		/// <param name="UniID" >University ID</param>
		/// <param name="elgFlg">Eligibility Flag (0,if not selected else 1) </param>
		/// <param name="nonElgFlg">Non-Eligibility Flag (0,if not selected else 1)</param>
		/// <param name="pendFlg">Pending Flag(0,if not selected else 1)</param>
		/// <param name="CrMoLrnPtrnID">Course Mode Of Learning Pattern ID</param>
		/// <param name="CrPr_ID">Course Part ID</param>
//		public static DataSet EACombinationStudentsSum(int elgFlg,int nonElgFlg,int pendFlg,int UniID,int CrPr_ID,int CrMoLrnPtrnID)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[6];
//			
//			try
//			{
//				
//				pr[0] = new SqlParameter("@Elg",elgFlg);
//				pr[1] = new SqlParameter("@NonElg",nonElgFlg);
//				pr[2] = new SqlParameter("@Pend",pendFlg);
//				pr[3] = new SqlParameter("@UniID",UniID);
//				pr[4] = new SqlParameter("@CrPrID",CrPr_ID);
//				pr[5] = new SqlParameter("@CrMoLrnPtrnID",CrMoLrnPtrnID);
//			
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_EA_CourseWiseCombinationsSummary",pr);
//			
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//				return ds;
//		}


		# endregion

		#endregion
		
	
		#region GetAllAcademicYear
		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// This function gets Academic Year 
		/// </summary>
//		public static DataSet GetAllAcademicYear()
//		{
//			DataSet ds = new DataSet();
//			//SqlParameter[] pr = new SqlParameter[1];
//			try
//			{
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_SelectAllAcademicYears");
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
		#endregion
		
		
		#region Student Ledgers
		/// For Ledgers
		/// This function gets the  Course Wise  Student List of Registered Regular Students
		/// for the Academic Year in the University.
		/// </summary>
		/// <param name="UniID" >University ID</param>
		/// <param name="AcdYrID">Academic Year ID</param>
		/// <param name="CrMoLrnPtrnID">Course Mode of Learning Pattern ID</param>
		/// <param name="CrPrID">Course Part ID</param>
//		public static DataSet GetCourseWiseIAStudentsLedger(int UniID , int CrPrID, int CrMoLrnPtrnID , int AcdYrID)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[4];
//			try
//			{
//				pr[0] = new SqlParameter("@pk_Uni_ID",UniID);
//				pr[1] = new SqlParameter("@pk_CrPr_ID",CrPrID);
//				pr[2] = new SqlParameter("@pk_CrMoLrnPtrn_ID",CrMoLrnPtrnID);
//				pr[3] = new SqlParameter("@pk_AcademicYr_ID",AcdYrID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"Elg_Ledger_IACourseWiseStudents",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
			
		/// For Ledgers
		/// This function gets the  Course Wise  Student List of Registered External Students
		/// for the Academic Year in the University.
		/// </summary>
		/// <param name="UniID" >University ID</param>
		/// <param name="AcdYrID">Academic Year ID</param>
		/// <param name="CrMoLrnPtrnID">Course Mode of Learning Pattern ID</param>
		/// <param name="CrPrID">Course Part ID</param>
//		public static DataSet GetCourseWiseEAStudentsLedger(int UniID , int CrPrID, int CrMoLrnPtrnID , int AcdYrID)
//		{
//			DataSet ds = new DataSet();
//			SqlParameter[] pr = new SqlParameter[4];
//			try
//			{
//				pr[0] = new SqlParameter("@pk_Uni_ID",UniID);
//				pr[1] = new SqlParameter("@pk_CrPr_ID",CrPrID);
//				pr[2] = new SqlParameter("@pk_CrMoLrnPtrn_ID",CrMoLrnPtrnID);
//				pr[3] = new SqlParameter("@pk_AcademicYr_ID",AcdYrID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"Elg_Ledger_EACourseWiseStudents",pr);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return ds;
//		}
	
	}
		#endregion
}
