using System;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Collections;

using Classes;

namespace Classes
{

	public class clsInstituteType
	{

 #region Private variables Declaration
		private long PK_InstTy_ID;
		private string InstTy_Name;
		private string InstTy_Desc;
		private string Active;
//		private string Deleted;
//		private string Created_By;
//		private string Date_Created;
//		private string Modified_By;
//		private string Date_Modified;

		private DataTable DT;
 #endregion


 #region Properties
		public long pk_InstTy_ID
		{ 
			get
			{ 
				return PK_InstTy_ID;
			}
		}	

		public string instTy_Name
		{ 
			get
			{ 
				return InstTy_Name;
			}
		}

		public string instTy_Desc
		{ 
			get
			{ 
				return InstTy_Desc;
			}
		}
		public string active
		{ 
			get
			{ 
				return Active;
			}
		}	

//		public string deleted
//		{ 
//			get
//			{ 
//				return Deleted;
//			}
//		}
//		
//		public string created_By
//		{ 
//			get
//			{ 
//				return Created_By;
//			}
//		}
//
//		public string date_Created
//		{ 
//			get
//			{ 
//				return Date_Created;
//			}
//		}
//
//
//		public string modified_By
//		{ 
//			get
//			{ 
//				return Modified_By;
//			}
//		}
//
//		public string date_Modified
//		{ 
//			get
//			{ 
//				return Date_Modified;
//			}
//		}
 #endregion


 #region Constructor
		public clsInstituteType(long InstTy_ID)
		{
			PK_InstTy_ID = InstTy_ID; 
			
			int iReturn = Load();
		}
 #endregion


 #region Fuction Load
		private int Load()
		{
			Hashtable oHsTb = new Hashtable();
			// Creating Hashtable
			oHsTb.Add("pk_InstTy_ID",PK_InstTy_ID);
			
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				DT = oDB.getparamdataset("ID_AttributeInstituteType",oHsTb).Tables[0];
			
				if(DT.Rows.Count > 0)
				{
				
					InstTy_Name = DT.Rows[0]["InstTy_Name"].ToString().Trim();
					InstTy_Desc = DT.Rows[0]["InstTy_Desc"].ToString().Trim();
					Active = DT.Rows[0]["Active"].ToString();

				}
				else
				{
					Reset();
				}
				return DT.Rows.Count;
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


 #region Function Reset
		private void Reset()
		{
			InstTy_Name = "";
			InstTy_Desc = "";
			Active = "";
		}
 #endregion


 #region Function Add
		public static string add(Hashtable HtAllValues)
		{
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				string returnValue;
				SqlCommand cmd = oDB.GenerateCommand("ID_Add_Institutetype",HtAllValues);
				cmd.ExecuteNonQuery();
				returnValue = cmd.Parameters["@pk_InstTy_ID"].Value.ToString();
				cmd.Dispose();
				cmd.Connection.Close();
				cmd=null;
				
				return returnValue;
			}
			catch(SqlException ex)
			{
				Exception e;
				e = new Exception(ex.Message,ex);
				return "Y";
						
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
 #endregion


 #region Function Modify
		public string modify(Hashtable HtAllValues)
		{			
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				SqlCommand cmd = oDB.GenerateCommand("ID_Modify_InstituteType",HtAllValues); //Change Procedure name
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				cmd.Connection.Close();
				cmd=null;
				Load();
				return "Y";
				
			}
			catch(Exception ex)
			{
				Exception e;
				e = new Exception(ex.Message,ex);
				return "";
				
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
 #endregion


 #region Function Delete
		public int delete()
		{
			int recAffected=0;
			SqlCommand cmd;
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				Hashtable objHS = new Hashtable();
				objHS["pk_InstTy_ID"]=PK_InstTy_ID;
				
				cmd = oDB.GenerateCommand("ID_Delete_InstituteType",objHS); //Change Procedure Name
				recAffected=cmd.ExecuteNonQuery();
				Reset();
				cmd.Connection.Close();
				cmd.Dispose();
				cmd=null;
				return recAffected;
			}
			catch(SqlException ex)
			{
				Exception e;
				e = new Exception(ex.Message,ex);
				throw(e);
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			
		}
 #endregion


 #region All Institute Types
		public static DataTable AllInstituteTypes()
		{
			Hashtable oHs = new Hashtable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				DataTable DT = oDB.getdataset("ID_AllInstituteTypes").Tables[0]; 
				return DT;
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


 #region Institute Type Wise Institute Status
		public static DataTable InstituteTypeWiseStatus(string pk_InstTy_ID)
		{
			Hashtable oHs = new Hashtable();
			
			oHs.Add("pk_InstTy_ID",pk_InstTy_ID);
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				DataTable DT = oDB.getparamdataset("ID_InstituteTypeWiseStatus",oHs).Tables[0]; 
				return DT;
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


	}
}
