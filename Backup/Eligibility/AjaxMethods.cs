using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using Classes;
using Ajax;
using Microsoft.ApplicationBlocks.Data;


namespace StudentRegistration.Eligibility
{
	/// <summary>
	/// Summary description for AjaxMethods.
	/// </summary>
	public class AjaxMethods 
	{
		public AjaxMethods()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		# region for Regular Students

		#region Select  Institute Wise - Faculty
		[Ajax.AjaxMethod]
		public ArrayList selInstituteWiseFaculty(int UniID,int InstID)
		{
			DataSet ds;
			ArrayList Arrds=new ArrayList(1);
			Hashtable ht = new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				
				
				ht.Add("UniID",UniID);
				ht.Add("InstID",InstID);
				ds = oDB.getparamdataset("ELG_InstituteWiseFaculties",ht);
				Arrds.Add(ds);
				return Arrds;
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

		#region Select Institute Wise - Courses
		//[Ajax.AjaxMethod]
//		public ArrayList selInstituteWiseCourses(int UniID,int InstID,int FacID)
//		{
//			DataSet ds;
//			ArrayList Arrds=new ArrayList(1);
//			try
//			{
//				
//				SqlParameter[] pr = new SqlParameter[3];
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@InstID",InstID);
//				pr[2] = new SqlParameter("@FacID",FacID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_InstFacultyWiseCourses",pr);
//				Arrds.Add(ds);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return Arrds;
//
//		}
		#endregion
		
		#region Select  CoursesPart
		//[Ajax.AjaxMethod]
//		public ArrayList selInstituteWiseCoursePart(int UniID,int InstID,int FacID,int CrID)
//		{
//			DataSet ds;
//			ArrayList Arrds=new ArrayList(1);
//			Hashtable ht = new Hashtable();
//			try
//			{
//				
//				SqlParameter[] pr = new SqlParameter[4];
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@InstID",InstID);
//				pr[2] = new SqlParameter("@FacID",FacID);
//				pr[3] = new SqlParameter("@CrID",CrID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_InstCourseWiseCoursePart",pr);
//				Arrds.Add(ds);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return Arrds;
//		}
		#endregion
	 
		#region Select  ALL Courses
        [Ajax.AjaxMethod]
        public ArrayList selFacultyWiseAllCourses(int UniID, int FacID)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            try
            {

                SqlParameter[] pr = new SqlParameter[2];
                pr[0] = new SqlParameter("@UniID", UniID);
                pr[1] = new SqlParameter("@FacID", FacID);
                ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString, CommandType.StoredProcedure, "ELG_FacultyWiseAllCourses", pr);
                Arrds.Add(ds);
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            return Arrds;
        }
		#endregion

		#region Select  ALL CoursesPart
        [Ajax.AjaxMethod]
        public ArrayList selAllCoursePart(int UniID, int FacID, int CrID)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            try
            {
                SqlParameter[] pr = new SqlParameter[3];
                pr[0] = new SqlParameter("@UniID", UniID);
                pr[1] = new SqlParameter("@FacID", FacID);
                pr[2] = new SqlParameter("@CrID", CrID);
                ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString, CommandType.StoredProcedure, "ELG_RegularCoursePart", pr);
                Arrds.Add(ds);
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            return Arrds;
        }
		#endregion

		#region Fill State Wise Districts 
		[Ajax.AjaxMethod()]
		public static DataSet FillStateWiseDistricts(int State_ID, string Lang_Flag)
		{
			DataSet ds;
			Hashtable ht =  new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("State_ID",State_ID);
				ht.Add("Lang_Flag",Lang_Flag);
				ds = oDB.getparamdataset("GEN_stateWiseDistricts",ht);
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

		#region Fill District Wise Tehsils
		[Ajax.AjaxMethod()]
		public static DataSet FillDistrictWiseTehsils(int District_ID, string Lang_Flag)
		{
			DataSet ds;
			Hashtable ht =  new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				ht.Add("District_ID",District_ID);
				ht.Add("Lang_Flag",Lang_Flag);
				ds = oDB.getparamdataset("GEN_districtWiseTaluka",ht);
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


		[Ajax.AjaxMethod()]

		public int FetchMatchingProfile(int rowID)
		{
			
			int id;
			id=rowID;
			return id;

		}

		
		#region for External Students
		#region Select  ALL CoursesPart
//		[Ajax.AjaxMethod]
//		public ArrayList selExtAllCoursePart(int UniID,int FacID,int CrID)
//		{
//			DataSet ds;
//			ArrayList Arrds=new ArrayList(1);
//			try
//			{
//				SqlParameter[] pr = new SqlParameter[3];
//				pr[0] = new SqlParameter("@UniID",UniID);
//				pr[1] = new SqlParameter("@FacID",FacID);
//				pr[2] = new SqlParameter("@CrID",CrID);
//				ds = SqlHelper.ExecuteDataset(UniversityPortal.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_ExternalCoursePart",pr);
//				Arrds.Add(ds);
//			}
//			catch(Exception Ex)
//			{
//				Exception e = new Exception(Ex.Message,Ex);
//				throw(e);
//			  			
//			}
//			return Arrds;
//		}
		#endregion
		#endregion
	}

}
