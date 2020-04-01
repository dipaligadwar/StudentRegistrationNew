using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Classes;

namespace StudentRegistration.Eligibility.ElgClasses
{
	/// <summary>
	/// Summary description for clsInstitute.
	/// </summary>
	public class clsInstitute
	{

		#region Variable Declaration
	
		private string PK_Uni_ID;
		private string PK_Inst_ID;
		private string FK_SocTrt_ID;
		private string FK_InstTy_ID;
		private string Inst_Name;
		private string Inst_IsResearchCenterFlag;
		private string Inst_Minority_NonMinorityType;
		private string Inst_MinorityStatusFlag;
		private string FK_Reln_Lang_ID;
		private string FK_Fac_ID;
		private string FK_Sub_ID;
		private string FK_InstStat_ID;
		private string FK_ParBdy_ID;
		private string Inst_ForWhomFlag;
		private string FK_Country_ID;
		private string FK_State_ID;
		private string FK_District_ID;
		private string FK_Tehsil_ID;
		private string Inst_OtherTehsil;
		private string Inst_City;
		private string Inst_Address;
		private string Inst_PinCode;
		private string Inst_STD1;
		private string Inst_TelNo1;
		private string Inst_STD2;
		private string Inst_TelNo2;
		private string Inst_STD3;
		private string Inst_TelNo3;
		private string Inst_FaxSTD1;
		private string Inst_FaxNo1;
		private string Inst_FaxSTD2;
		private string Inst_FaxNo2;
		private string Inst_MobileNo1;
		private string Inst_MobileNo2;
		private string Inst_EmailID1;
		private string Inst_EmailID2;
		private string Inst_EmailID3;
		private string Inst_Website;
		private string Inst_ConductionModeFlag;
		private string Inst_Establishment_Date;
		private string Inst_Code;
		private string FK_Affi_ID;
		private string Inst_UniLetterToStateGovt_No;
		private string Inst_UniLetterToStateGovt_Date;
		private string Inst_UniLetterToStateGovt_Image;
		private string Inst_StateGovtGR_No;
		private string Inst_StateGovtGR_Date;
		private string Inst_StateGovtGR_Image;
		private string Inst_UniAffiliationLetter_No;
		private string Inst_UniAffiliationLetter_Date;
		private string Inst_UniAffiliationLetter_Image;
		private string Inst_UGCRec_2F_Letter_No;
		private string Inst_UGCRec_2F_Letter_Date;
		private string Inst_UGCRec_2F_Letter_Image;
		private string Inst_UGCRec_12B_Letter_No;
		private string Inst_UGCRec_12B_Letter_Date;
		private string Inst_UGCRec_12B_Letter_Image;
		private string Inst_AreaCodeFlag;
		private string Inst_NearestRlyStationName;
		private string Inst_DistFrmRlyStation;
		private string Inst_NearestBusStandName;
		private string Inst_DistFrmBusStand;
		private string Inst_NearestAirportName;
		private string Inst_DistFrmAirport;
		private string Inst_Longitude;
		private string Inst_Latitude;
		private string Inst_Altitude;
		private string Inst_Image;
		private string Inst_Vision;
		private string Inst_Mission;
		private string Inst_Goals;
		private string Inst_Principal_Director_HODName;
		private string FK_PriDirHOD_Country_ID;
		private string FK_PriDirHOD_State_ID;
		private string FK_PriDirHOD_District_ID;
		private string FK_PriDirHOD_Tehsil_ID;
		private string Inst_PriDirHOD_OtherTehsil;
		private string Inst_PriDirHOD_City;
		private string Inst_PriDirHOD_Address;
		private string Inst_PriDirHOD_PinCode;
		private string Inst_PriDirHOD_STD1;
		private string Inst_PriDirHOD_TelNo1;
		private string Inst_PriDirHOD_STD2;
		private string Inst_PriDirHOD_TelNo2;
		private string Inst_PriDirHOD_MobileNo1;
		private string Inst_PriDirHOD_EmailID1;
		private string Inst_PriDirHOD_EmailID2;
		private string Inst_OfficeInchargeName;
		private string FK_OffInchr_Desgn_ID;
		private string FK_OffInchr_Country_ID;
		private string FK_OffInchr_State_ID;
		private string FK_OffInchr_District_ID;
		private string FK_OffInchr_Tehsil_ID;
		private string Inst_OffInchr_OtherTehsil;
		private string Inst_OffInchr_City;
		private string Inst_OffInchr_Address;
		private string Inst_OffInchr_PinCode;
		private string Inst_OffInchr_STD1;
		private string Inst_OffInchr_TelNo1;
		private string Inst_OffInchr_STD2;
		private string Inst_OffInchr_TelNo2;
		private string Inst_OffInchr_MobileNo1;
		private string Inst_OffInchr_EmailID1;
		private string Inst_OffInchr_EmailID2;
		private string Active;
			
		private DataTable DT;

		#endregion

		#region Properties
		public string pk_Uni_ID	
		{ 
			get
			{ 	
				return PK_Uni_ID;	
			}
		}
		
		public string pk_Inst_ID	
		{
			get
			{ 	
				return PK_Inst_ID;	
			}
		}
		
		public string fk_SocTrt_ID	
		{ 
			get 
			{ 	
				return FK_SocTrt_ID;	
			}
		}
		
		public string fk_InstTy_ID	
		{ 
			get 
			{ 	
				return FK_InstTy_ID;	
			}
		}
		
		public string inst_Name	
		{ 
			get 
			{ 	
				return Inst_Name;	
			}
		}
		
		public string inst_IsResearchCenterFlag	
		{ 
			get 
			{ 	
				return Inst_IsResearchCenterFlag;	
			}
		}
		
		public string inst_Minority_NonMinorityType	
		{ 
			get 
			{ 	
				return Inst_Minority_NonMinorityType;	
			}
		}
		
		public string inst_MinorityStatusFlag	
		{ 
			get 
			{ 	
				return Inst_MinorityStatusFlag;	
			}
		}
		
		public string fk_Reln_Lang_ID	
		{ 
			get 
			{ 	
				return FK_Reln_Lang_ID;	
			}
		}
		public string fk_Fac_ID	
		{ 
			get 
			{ 	
				return FK_Fac_ID;	
			}
		}
		public string fk_Sub_ID
		{ 
			get 
			{ 	
				return FK_Sub_ID;	
			}
		}
		public string fk_InstStat_ID	
		{ 
			get 
			{ 	
				return FK_InstStat_ID;	
			}
		}
		
		public string fk_ParBdy_ID	
		{ 
			get 
			{ 	
				return FK_ParBdy_ID; 
			}
		}
		
		public string inst_ForWhomFlag	
		{ 
			get 
			{ 	
				return Inst_ForWhomFlag;	
			}
		}
		
		public string fk_Country_ID	
		{
			get
			{ 	
				return FK_Country_ID;	
			}
		}
		
		public string fk_State_ID	
		{
			get 
			{ 	
				return FK_State_ID;	
			}
		}
		
		public string fk_District_ID	
		{
			get 
			{ 	
				return FK_District_ID;	
			}
		}
		
		public string fk_Tehsil_ID	
		{ 
			get 
			{ 	
				return FK_Tehsil_ID;	
			}
		}
		
		public string inst_OtherTehsil	
		{ 
			get 
			{ 	
				return Inst_OtherTehsil;	
			}
		}
		
		public string inst_City	
		{ 
			get 
			{ 	
				return Inst_City;	
			}
		}
		
		public string inst_Address	
		{ 
			get 
			{ 	
				return Inst_Address;	
			} 
		}
		
		public string inst_PinCode	
		{ 
			get 
			{ 	
				return Inst_PinCode;	
			} 
		}
		
		public string inst_STD1	
		{ 
			get 
			{ 	
				return Inst_STD1;	
			} 
		}
		
		public string inst_TelNo1	
		{ 
			get 
			{ 	
				return Inst_TelNo1;	
			} 
		}
		
		public string inst_STD2	
		{ 
			get 
			{ 	
				return Inst_STD2;	
			} 
		}
		
		public string inst_TelNo2	
		{ 
			get 
			{ 	
				return Inst_TelNo2;	
			} 
		}
		
		public string inst_STD3	
		{ 
			get 
			{ 	
				return Inst_STD3;	
			} 
		}
		
		public string inst_TelNo3	
		{ 
			get 
			{ 	
				return Inst_TelNo3;	
			} 
		}
		
		public string inst_FaxSTD1	
		{ 
			get 
			{ 	
				return Inst_FaxSTD1;	
			} 
		}
		
		public string inst_FaxNo1	
		{ 
			get 
			{ 	
				return Inst_FaxNo1;	
			} 
		}
		
		public string inst_FaxSTD2	
		{ 
			get 
			{ 	
				return Inst_FaxSTD2;	
			} 
		}
		
		public string inst_FaxNo2	
		{ 
			get 
			{ 	
				return Inst_FaxNo2;	
			} 
		}
		
		public string inst_MobileNo1	
		{ 
			get 
			{ 	
				return Inst_MobileNo1;	
			}
		}
		
		public string inst_MobileNo2	
		{ 
			get 
			{ 	
				return Inst_MobileNo2;	
			} 
		}
		
		public string inst_EmailID1	
		{ 
			get 
			{ 	
				return Inst_EmailID1;	
			} 
		}
		
		public string inst_EmailID2	
		{ 
			get 
			{ 	
				return Inst_EmailID2;	
			} 
		}
		
		public string inst_EmailID3	
		{ 
			get 
			{ 	
				return Inst_EmailID3;	
			} 
		}
		
		public string inst_Website	
		{ 
			get 
			{ 	
				return Inst_Website;	
			} 
		}
		
		public string inst_ConductionModeFlag	
		{ 
			get
			{ 	
				return Inst_ConductionModeFlag;	
			} 
		}
		
		public string inst_Establishment_Date	
		{ 
			get 
			{ 	
				return Inst_Establishment_Date;	
			} 
		}
		
		public string inst_Code	
		{ 
			get 
			{ 	
				return Inst_Code;	
			} 
		}
		
		public string  fk_Affi_ID	
		{ 
			get 
			{ 	
				return FK_Affi_ID;	
			} 
		}
		
		public string inst_UniLetterToStateGovt_No	
		{ 
			get 
			{ 	
				return Inst_UniLetterToStateGovt_No;	
			} 
		}
		public string inst_UniLetterToStateGovt_Date	
		{ 
			get 
			{ 	
				return Inst_UniLetterToStateGovt_Date;	
			} 
		}
		public string inst_UniLetterToStateGovt_Image	
		{ 
			get 
			{ 	
				return Inst_UniLetterToStateGovt_Image;	
			} 
		}
		public string inst_StateGovtGR_No	
		{ 
			get 
			{ 	
				return Inst_StateGovtGR_No;	
			} 
		}
		public string inst_StateGovtGR_Date	
		{ 
			get 
			{ 	
				return Inst_StateGovtGR_Date;	
			} 
		}
		public string inst_StateGovtGR_Image	
		{ 
			get 
			{ 	
				return Inst_StateGovtGR_Image;	
			} 
		}
		public string inst_UniAffiliationLetter_No	
		{ 
			get 
			{
				return Inst_UniAffiliationLetter_No;	
			} 
		}
		public string inst_UniAffiliationLetter_Date	
		{ 
			get 
			{ 	
				return Inst_UniAffiliationLetter_Date;	
			} 
		}
		public string inst_UniAffiliationLetter_Image	
		{ 
			get 
			{ 	
				return Inst_UniAffiliationLetter_Image;	
			}
		}
		public string inst_UGCRec_2F_Letter_No	
		{ 
			get 
			{ 	
				return Inst_UGCRec_2F_Letter_No;	
			} 
		}
		public string inst_UGCRec_2F_Letter_Date	
		{ 
			get 
			{ 	
				return Inst_UGCRec_2F_Letter_Date;	
			} 
		}
		public string inst_UGCRec_2F_Letter_Image	
		{ 
			get 
			{ 	
				return Inst_UGCRec_2F_Letter_Image;	
			} 
		}
		public string inst_UGCRec_12B_Letter_No	
		{ 
			get 
			{ 	
				return Inst_UGCRec_12B_Letter_No;	
			} 
		}
		public string inst_UGCRec_12B_Letter_Date	
		{ 
			get 
			{ 	
				return Inst_UGCRec_12B_Letter_Date;	
			} 
		}
		public string inst_UGCRec_12B_Letter_Image	
		{ 
			get 
			{ 	
				return Inst_UGCRec_12B_Letter_Image;	
			} 
		}
		public string inst_AreaCodeFlag	
		{ 
			get 
			{ 	
				return Inst_AreaCodeFlag;	
			} 
		}
		public string inst_NearestRlyStationName	
		{ 
			get 
			{ 	
				return Inst_NearestRlyStationName;	
			} 
		}
		public string inst_DistFrmRlyStation	
		{ 
			get 
			{ 	
				return Inst_DistFrmRlyStation;	
			} 
		}
		public string inst_NearestBusStandName	
		{ 
			get 
			{ 	
				return Inst_NearestBusStandName;	
			} 
		}
		public string inst_DistFrmBusStand	
		{ 
			get 
			{ 	
				return Inst_DistFrmBusStand;	
			} 
		}
		public string inst_NearestAirportName	
		{ 
			get 
			{ 	
				return Inst_NearestAirportName;	
			} 
		}
		public string inst_DistFrmAirport	
		{ 
			get 
			{ 	
				return Inst_DistFrmAirport;	
			} 
		}
		public string inst_Longitude	
		{ 
			get 
			{ 	
				return Inst_Longitude;	
			} 
		}
		public string inst_Latitude	
		{ 
			get 
			{ 	
				return Inst_Latitude;	
			} 
		}
		public string inst_Altitude	
		{ 
			get 
			{ 	
				return Inst_Altitude;	
			} 
		}
		public string inst_Image	
		{ 
			get 
			{ 	
				return Inst_Image;	
			} 
		}
		public string inst_Vision	
		{ 
			get 
			{ 	
				return Inst_Vision;	
			} 
		}
		public string inst_Mission	
		{ 
			get 
			{ 	
				return Inst_Mission; 
			} 
		}
		
		public string inst_Goals	
		{ 
			get 
			{ 	
				return Inst_Goals;	
			} 
		}
		public string inst_Principal_Director_HODName	
		{ 
			get 
			{ 	
				return Inst_Principal_Director_HODName;	
			} 
		}
		public string fk_PriDirHOD_Country_ID	
		{ 
			get 
			{ 	
				return FK_PriDirHOD_Country_ID;	
			} 
		}
		public string fk_PriDirHOD_State_ID	
		{ 
			get 
			{ 	
				return FK_PriDirHOD_State_ID;	
			} 
		}
		public string fk_PriDirHOD_District_ID	
		{ 
			get 
			{ 	
				return FK_PriDirHOD_District_ID;	
			} 
		}
		public string fk_PriDirHOD_Tehsil_ID	
		{ 
			get 
			{ 	
				return FK_PriDirHOD_Tehsil_ID;	
			} 
		}
		public string inst_PriDirHOD_OtherTehsil	
		{ 
			get 
			{
				return Inst_PriDirHOD_OtherTehsil;	
			} 
		}
		public string inst_PriDirHOD_City	
		{ 
			get 
			{ 	
				return Inst_PriDirHOD_City;	
			} 
		}
		public string inst_PriDirHOD_Address	
		{ 
			get 
			{ 	
				return Inst_PriDirHOD_Address;	
			} 
		}
		public string inst_PriDirHOD_PinCode	
		{ 
			get 
			{ 	
				return Inst_PriDirHOD_PinCode;	
			} 
		}
		public string inst_PriDirHOD_STD1	
		{ 
			get 
			{ 	
				return Inst_PriDirHOD_STD1;	
			} 
		}
		public string inst_PriDirHOD_TelNo1	
		{ 
			get 
			{ 	
				return Inst_PriDirHOD_TelNo1;	
			} 
		}
		public string inst_PriDirHOD_STD2	
		{ 
			get 
			{ 	
				return Inst_PriDirHOD_STD2;	
			} 
		}
		public string inst_PriDirHOD_TelNo2	
		{ 
			get 
			{ 	
				return Inst_PriDirHOD_TelNo2;	
			} 
		}
		public string inst_PriDirHOD_MobileNo1	
		{ 
			get 
			{ 	
				return Inst_PriDirHOD_MobileNo1;	
			} 
		}
		public string inst_PriDirHOD_EmailID1	
		{ 
			get 
			{ 	
				return Inst_PriDirHOD_EmailID1;	

			} 
		}
		public string inst_PriDirHOD_EmailID2	
		{ 
			get 
			{ 	
				return Inst_PriDirHOD_EmailID2;	
			} 
		}
		public string inst_OfficeInchargeName	
		{ 
			get 
			{ 	
				return Inst_OfficeInchargeName;	
			} 
		}
		public string  fk_OffInchr_Desgn_ID	
		{ 
			get 
			{ 	
				return FK_OffInchr_Desgn_ID;	
			} 
		}
		public string  fk_OffInchr_Country_ID	
		{ 
			get 
			{ 	
				return FK_OffInchr_Country_ID;	
			} 
		}
		public string  fk_OffInchr_State_ID	
		{ 
			get 
			{ 	
				return FK_OffInchr_State_ID;	
			} 
		}
		public string  fk_OffInchr_District_ID	
		{ 
			get 
			{ 	
				return FK_OffInchr_District_ID;	
			} 
		}
		
		public string  fk_OffInchr_Tehsil_ID	
		{ 
			get 
			{ 	
				return FK_OffInchr_Tehsil_ID;	
			} 
		}
		public string inst_OffInchr_OtherTehsil	
		{ 
			get 
			{ 	
				return Inst_OffInchr_OtherTehsil;	
			} 
		}
		public string inst_OffInchr_City	
		{ 
			get 
			{ 	
				return Inst_OffInchr_City;	
			} 
		}
		public string inst_OffInchr_Address	
		{ 
			get
			{ 	
				return Inst_OffInchr_Address;	
			} 
		}
		public string inst_OffInchr_PinCode	
		{ 
			get 
			{ 	
				return Inst_OffInchr_PinCode;	
			} 
		}
		public string inst_OffInchr_STD1	
		{ 
			get
			{ 	
				return Inst_OffInchr_STD1;	
			} 
		}
		public string inst_OffInchr_TelNo1	
		{ 
			get 
			{ 	
				return Inst_OffInchr_TelNo1;	
			} 
		}
		public string inst_OffInchr_STD2	
		{ 
			get 
			{ 	
				return Inst_OffInchr_STD2;	
			} 
		}
		public string inst_OffInchr_TelNo2	
		{ 
			get 
			{ 	
				return Inst_OffInchr_TelNo2;	
			} 
		}
		public string inst_OffInchr_MobileNo1	
		{ 
			get 
			{ 	
				return Inst_OffInchr_MobileNo1;	
			} 
		}
		public string inst_OffInchr_EmailID1	
		{ 
			get 
			{ 	
				return Inst_OffInchr_EmailID1;	
			} 
		}
		public string inst_OffInchr_EmailID2	
		{ 
			get 
			{ 	
				return Inst_OffInchr_EmailID2;	
			} 
		}
		public string active	
		{ 
			get 
			{ 	
				return Active;	
			} 
		}
	
		#endregion

		#region Constructor
		public clsInstitute(string UniID, string InstID)
		{
			
			PK_Uni_ID = UniID;
			PK_Inst_ID = InstID;
			Load();
		}
		#endregion

		#region Function Load
		private void Load()
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHsTb = new Hashtable();
				oHsTb.Add("pk_Uni_ID",PK_Uni_ID);
				oHsTb.Add("pk_Inst_ID",PK_Inst_ID);
			
				DT =oDB.getparamdataset("ID_Attribute_Institute",oHsTb).Tables[0]; 
			
				if(DT.Rows.Count > 0)
				{
					PK_Uni_ID=DT.Rows[0]["pk_Uni_ID"].ToString().Trim();
					PK_Inst_ID=DT.Rows[0]["pk_Inst_ID"].ToString().Trim();
					FK_SocTrt_ID=DT.Rows[0]["fk_SocTrt_ID"].ToString().Trim();
					FK_InstTy_ID=DT.Rows[0]["fk_InstTy_ID"].ToString().Trim();
					Inst_Name=DT.Rows[0]["Inst_Name"].ToString().Trim();
					Inst_IsResearchCenterFlag=DT.Rows[0]["Inst_IsResearchCenterFlag"].ToString().Trim();
					//Inst_Minority_NonMinorityType=DT.Rows[0]["Inst_Minority_NonMinorityType"].ToString().Trim();
					Inst_MinorityStatusFlag=DT.Rows[0]["Inst_MinorityStatusFlag"].ToString().Trim();
					FK_Reln_Lang_ID=DT.Rows[0]["fk_Reln_Lang_ID"].ToString().Trim();
				
					FK_Fac_ID=DT.Rows[0]["FK_Fac_ID"].ToString().Trim();
					FK_Sub_ID=DT.Rows[0]["FK_Sub_ID"].ToString().Trim();

					FK_InstStat_ID=DT.Rows[0]["fk_InstStat_ID"].ToString().Trim();
					FK_ParBdy_ID=DT.Rows[0]["fk_ParBdy_ID"].ToString().Trim();
					Inst_ForWhomFlag=DT.Rows[0]["Inst_ForWhomFlag"].ToString().Trim();
					FK_Country_ID=DT.Rows[0]["fk_Country_ID"].ToString().Trim();
					FK_State_ID=DT.Rows[0]["fk_State_ID"].ToString().Trim();
					FK_District_ID=DT.Rows[0]["fk_District_ID"].ToString().Trim();
					FK_Tehsil_ID=DT.Rows[0]["fk_Tehsil_ID"].ToString().Trim();
					Inst_OtherTehsil=DT.Rows[0]["Inst_OtherTehsil"].ToString().Trim();
					Inst_City=DT.Rows[0]["Inst_City"].ToString().Trim();
					Inst_Address=DT.Rows[0]["Inst_Address"].ToString().Trim();
					Inst_PinCode=DT.Rows[0]["Inst_PinCode"].ToString().Trim();
					Inst_STD1=DT.Rows[0]["Inst_STD1"].ToString().Trim();
					Inst_TelNo1=DT.Rows[0]["Inst_TelNo1"].ToString().Trim();
					Inst_STD2=DT.Rows[0]["Inst_STD2"].ToString().Trim();
					Inst_TelNo2=DT.Rows[0]["Inst_TelNo2"].ToString().Trim();
					Inst_STD3=DT.Rows[0]["Inst_STD3"].ToString().Trim();
					Inst_TelNo3=DT.Rows[0]["Inst_TelNo3"].ToString().Trim();
					Inst_FaxSTD1=DT.Rows[0]["Inst_FaxSTD1"].ToString().Trim();
					Inst_FaxNo1=DT.Rows[0]["Inst_FaxNo1"].ToString().Trim();
					Inst_FaxSTD2=DT.Rows[0]["Inst_FaxSTD2"].ToString().Trim();
					Inst_FaxNo2=DT.Rows[0]["Inst_FaxNo2"].ToString().Trim();
					Inst_MobileNo1=DT.Rows[0]["Inst_MobileNo1"].ToString().Trim();
					Inst_MobileNo2=DT.Rows[0]["Inst_MobileNo2"].ToString().Trim();
					Inst_EmailID1=DT.Rows[0]["Inst_EmailID1"].ToString().Trim();
					Inst_EmailID2=DT.Rows[0]["Inst_EmailID2"].ToString().Trim();
					Inst_EmailID3=DT.Rows[0]["Inst_EmailID3"].ToString().Trim();
					Inst_Website=DT.Rows[0]["Inst_Website"].ToString().Trim();
					Inst_ConductionModeFlag=DT.Rows[0]["Inst_ConductionModeFlag"].ToString().Trim();
					Inst_Establishment_Date=DT.Rows[0]["Inst_Establishment_Date"].ToString().Trim();
					Inst_Code=DT.Rows[0]["Inst_Code"].ToString().Trim();
					FK_Affi_ID=DT.Rows[0]["fk_Affi_ID"].ToString().Trim();
					Inst_UniLetterToStateGovt_No=DT.Rows[0]["Inst_UniLetterToStateGovt_No"].ToString().Trim();
					Inst_UniLetterToStateGovt_Date=DT.Rows[0]["Inst_UniLetterToStateGovt_Date"].ToString().Trim();
					Inst_UniLetterToStateGovt_Image=DT.Rows[0]["Inst_UniLetterToStateGovt_Image"].ToString().Trim();
					Inst_StateGovtGR_No=DT.Rows[0]["Inst_StateGovtGR_No"].ToString().Trim();
					Inst_StateGovtGR_Date=DT.Rows[0]["Inst_StateGovtGR_Date"].ToString().Trim();
					Inst_StateGovtGR_Image=DT.Rows[0]["Inst_StateGovtGR_Image"].ToString().Trim();
					Inst_UniAffiliationLetter_No=DT.Rows[0]["Inst_UniAffiliationLetter_No"].ToString().Trim();
					Inst_UniAffiliationLetter_Date=DT.Rows[0]["Inst_UniAffiliationLetter_Date"].ToString().Trim();
					Inst_UniAffiliationLetter_Image=DT.Rows[0]["Inst_UniAffiliationLetter_Image"].ToString().Trim();
					Inst_UGCRec_2F_Letter_No=DT.Rows[0]["Inst_UGCRec_2F_Letter_No"].ToString().Trim();
					Inst_UGCRec_2F_Letter_Date=DT.Rows[0]["Inst_UGCRec_2F_Letter_Date"].ToString().Trim();
					Inst_UGCRec_2F_Letter_Image=DT.Rows[0]["Inst_UGCRec_2F_Letter_Image"].ToString().Trim();
					Inst_UGCRec_12B_Letter_No=DT.Rows[0]["Inst_UGCRec_12B_Letter_No"].ToString().Trim();
					Inst_UGCRec_12B_Letter_Date=DT.Rows[0]["Inst_UGCRec_12B_Letter_Date"].ToString().Trim();
					Inst_UGCRec_12B_Letter_Image=DT.Rows[0]["Inst_UGCRec_12B_Letter_Image"].ToString().Trim();
					Inst_AreaCodeFlag=DT.Rows[0]["Inst_AreaCodeFlag"].ToString().Trim();
					Inst_NearestRlyStationName=DT.Rows[0]["Inst_NearestRlyStationName"].ToString().Trim();
					Inst_DistFrmRlyStation=DT.Rows[0]["Inst_DistFrmRlyStation"].ToString().Trim();
					Inst_NearestBusStandName=DT.Rows[0]["Inst_NearestBusStandName"].ToString().Trim();
					Inst_DistFrmBusStand=DT.Rows[0]["Inst_DistFrmBusStand"].ToString().Trim();
					Inst_NearestAirportName=DT.Rows[0]["Inst_NearestAirportName"].ToString().Trim();
					Inst_DistFrmAirport=DT.Rows[0]["Inst_DistFrmAirport"].ToString().Trim();
					Inst_Longitude=DT.Rows[0]["Inst_Longitude"].ToString().Trim();
					Inst_Latitude=DT.Rows[0]["Inst_Latitude"].ToString().Trim();
					Inst_Altitude=DT.Rows[0]["Inst_Altitude"].ToString().Trim();
					Inst_Image=DT.Rows[0]["Inst_Image"].ToString().Trim();
					Inst_Vision=DT.Rows[0]["Inst_Vision"].ToString().Trim();
					Inst_Mission=DT.Rows[0]["Inst_Mission"].ToString().Trim();
					Inst_Goals=DT.Rows[0]["Inst_Goals"].ToString().Trim();
					Inst_Principal_Director_HODName=DT.Rows[0]["Inst_Principal_Director_HODName"].ToString().Trim();
					FK_PriDirHOD_Country_ID=DT.Rows[0]["fk_PriDirHOD_Country_ID"].ToString().Trim();
					FK_PriDirHOD_State_ID=DT.Rows[0]["fk_PriDirHOD_State_ID"].ToString().Trim();
					FK_PriDirHOD_District_ID=DT.Rows[0]["fk_PriDirHOD_District_ID"].ToString().Trim();
					FK_PriDirHOD_Tehsil_ID=DT.Rows[0]["fk_PriDirHOD_Tehsil_ID"].ToString().Trim();
					Inst_PriDirHOD_OtherTehsil=DT.Rows[0]["Inst_PriDirHOD_OtherTehsil"].ToString().Trim();
					Inst_PriDirHOD_City=DT.Rows[0]["Inst_PriDirHOD_City"].ToString().Trim();
					Inst_PriDirHOD_Address=DT.Rows[0]["Inst_PriDirHOD_Address"].ToString().Trim();
					Inst_PriDirHOD_PinCode=DT.Rows[0]["Inst_PriDirHOD_PinCode"].ToString().Trim();
					Inst_PriDirHOD_STD1=DT.Rows[0]["Inst_PriDirHOD_STD1"].ToString().Trim();
					Inst_PriDirHOD_TelNo1=DT.Rows[0]["Inst_PriDirHOD_TelNo1"].ToString().Trim();
					Inst_PriDirHOD_STD2=DT.Rows[0]["Inst_PriDirHOD_STD2"].ToString().Trim();
					Inst_PriDirHOD_TelNo2=DT.Rows[0]["Inst_PriDirHOD_TelNo2"].ToString().Trim();
					Inst_PriDirHOD_MobileNo1=DT.Rows[0]["Inst_PriDirHOD_MobileNo1"].ToString().Trim();
					Inst_PriDirHOD_EmailID1=DT.Rows[0]["Inst_PriDirHOD_EmailID1"].ToString().Trim();
					Inst_PriDirHOD_EmailID2=DT.Rows[0]["Inst_PriDirHOD_EmailID2"].ToString().Trim();
					Inst_OfficeInchargeName=DT.Rows[0]["Inst_OfficeInchargeName"].ToString().Trim();
					FK_OffInchr_Desgn_ID=DT.Rows[0]["fk_OffInchr_Desgn_ID"].ToString().Trim();
					FK_OffInchr_Country_ID=DT.Rows[0]["fk_OffInchr_Country_ID"].ToString().Trim();
					FK_OffInchr_State_ID=DT.Rows[0]["fk_OffInchr_State_ID"].ToString().Trim();
					FK_OffInchr_District_ID=DT.Rows[0]["fk_OffInchr_District_ID"].ToString().Trim();
					FK_OffInchr_Tehsil_ID=DT.Rows[0]["fk_OffInchr_Tehsil_ID"].ToString().Trim();
					Inst_OffInchr_OtherTehsil=DT.Rows[0]["Inst_OffInchr_OtherTehsil"].ToString().Trim();
					Inst_OffInchr_City=DT.Rows[0]["Inst_OffInchr_City"].ToString().Trim();
					Inst_OffInchr_Address=DT.Rows[0]["Inst_OffInchr_Address"].ToString().Trim();
					Inst_OffInchr_PinCode=DT.Rows[0]["Inst_OffInchr_PinCode"].ToString().Trim();
					Inst_OffInchr_STD1=DT.Rows[0]["Inst_OffInchr_STD1"].ToString().Trim();
					Inst_OffInchr_TelNo1=DT.Rows[0]["Inst_OffInchr_TelNo1"].ToString().Trim();
					Inst_OffInchr_STD2=DT.Rows[0]["Inst_OffInchr_STD2"].ToString().Trim();
					Inst_OffInchr_TelNo2=DT.Rows[0]["Inst_OffInchr_TelNo2"].ToString().Trim();
					Inst_OffInchr_MobileNo1=DT.Rows[0]["Inst_OffInchr_MobileNo1"].ToString().Trim();
					Inst_OffInchr_EmailID1=DT.Rows[0]["Inst_OffInchr_EmailID1"].ToString().Trim();
					Inst_OffInchr_EmailID2=DT.Rows[0]["Inst_OffInchr_EmailID2"].ToString().Trim();
					Active=DT.Rows[0]["Active"].ToString().Trim();
				}
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
			Inst_Name="";
			Inst_IsResearchCenterFlag="";
			Inst_Minority_NonMinorityType="";
			Inst_MinorityStatusFlag="";
			Inst_OtherTehsil="";
			Inst_City="";
			Inst_Address="";
			Inst_PinCode="";
			Inst_STD1="";
			Inst_TelNo1="";
			Inst_STD2="";
			Inst_TelNo2="";
			Inst_STD3="";
			Inst_TelNo3="";
			Inst_FaxSTD1="";
			Inst_FaxNo1="";
			Inst_FaxSTD2="";
			Inst_FaxNo2="";
			Inst_MobileNo1="";
			Inst_MobileNo2="";
			Inst_EmailID1="";
			Inst_EmailID2="";
			Inst_EmailID3="";
			Inst_Website="";
			Inst_ConductionModeFlag="";
			Inst_Establishment_Date="";
			Inst_Code="";
			Inst_UniLetterToStateGovt_No="";
			Inst_UniLetterToStateGovt_Date="";
			Inst_UniLetterToStateGovt_Image="";
			Inst_StateGovtGR_No="";
			Inst_StateGovtGR_Date="";
			Inst_StateGovtGR_Image="";
			Inst_UniAffiliationLetter_No="";
			Inst_UniAffiliationLetter_Date="";
			Inst_UniAffiliationLetter_Image="";
			Inst_UGCRec_2F_Letter_No="";
			Inst_UGCRec_2F_Letter_Date="";
			Inst_UGCRec_2F_Letter_Image="";
			Inst_UGCRec_12B_Letter_No="";
			Inst_UGCRec_12B_Letter_Date="";
			Inst_UGCRec_12B_Letter_Image="";
			Inst_AreaCodeFlag="";
			Inst_NearestRlyStationName="";
			Inst_DistFrmRlyStation="";
			Inst_NearestBusStandName="";
			Inst_DistFrmBusStand="";
			Inst_NearestAirportName="";
			Inst_DistFrmAirport="";
			Inst_Longitude="";
			Inst_Latitude="";
			Inst_Altitude="";
			Inst_Image="";
			Inst_Vision="";
			Inst_Mission="";
			Inst_Goals="";
			Inst_Principal_Director_HODName="";
			Inst_PriDirHOD_OtherTehsil="";
			Inst_PriDirHOD_City="";
			Inst_PriDirHOD_Address="";
			Inst_PriDirHOD_PinCode="";
			Inst_PriDirHOD_STD1="";
			Inst_PriDirHOD_TelNo1="";
			Inst_PriDirHOD_STD2="";
			Inst_PriDirHOD_TelNo2="";
			Inst_PriDirHOD_MobileNo1="";
			Inst_PriDirHOD_EmailID1="";
			Inst_PriDirHOD_EmailID2="";
			Inst_OfficeInchargeName="";
			Inst_OffInchr_OtherTehsil="";
			Inst_OffInchr_City="";
			Inst_OffInchr_Address="";
			Inst_OffInchr_PinCode="";
			Inst_OffInchr_STD1="";
			Inst_OffInchr_TelNo1="";
			Inst_OffInchr_STD2="";
			Inst_OffInchr_TelNo2="";
			Inst_OffInchr_MobileNo1="";
			Inst_OffInchr_EmailID1="";
			Inst_OffInchr_EmailID2="";
			Active="";
		}
		#endregion

		#region Function Add
		public static string[] add(Hashtable HtAllValues)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				string[] returnValue = new string[2];

				SqlCommand cmd =oDB.GenerateCommand("ID_add_Institute",HtAllValues);
				cmd.ExecuteNonQuery();
				returnValue[0] = cmd.Parameters["@pk_Uni_ID"].Value.ToString();
				returnValue[1] = cmd.Parameters["@pk_Inst_ID"].Value.ToString();
	
				return returnValue;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Function Modify Basic Info 
		public static int modifyBasicInfo(Hashtable HtAllValues)
		{			
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				int rowAffected=0;
		
				SqlCommand cmd=new SqlCommand();
				cmd =oDB.GenerateCommand("ID_Modify_BasicInfo",HtAllValues); //Change Procedure name
				rowAffected=cmd.ExecuteNonQuery();
				return rowAffected;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Function  Modify Registration Info
		public int modifyRegistrationInfo(Hashtable HtAllValues)
		{		
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				int rowAffected=0;
		
				SqlCommand cmd =oDB.GenerateCommand("ID_Modify_RegistrationInfo",HtAllValues); //Change Procedure name
				rowAffected = cmd.ExecuteNonQuery();
		
				return rowAffected;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}

		}
		#endregion

		#region Function Modify Geographical Info 
		public static int modifyGeographicalInfo(Hashtable HtAllValues)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				int rowAffected=0;
				SqlCommand cmd =oDB.GenerateCommand("ID_Modify_GeographicalInfo",HtAllValues); //Change Procedure name
				rowAffected = cmd.ExecuteNonQuery();
				return rowAffected;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Function Modify Other Info 
		public int modifyOtherInfo(Hashtable HtAllValues)
		{	
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				int rowAffected=0;
		
				SqlCommand cmd =oDB.GenerateCommand("ID_Modify_OtherInfo",HtAllValues); //Change Procedure name
				rowAffected = cmd.ExecuteNonQuery();
				return rowAffected;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Delete
		public static int delete(string PKUniID , string PKInstID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;

			int recAffected=0;
			SqlCommand cmd;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable objHS = new Hashtable();
				objHS["pk_Uni_ID"]=PKUniID;
				objHS["pk_Inst_ID"]=PKInstID;
			
				cmd = oDB.GenerateCommand("ID_Delete_Institute",objHS); //Change Procedure Name
				recAffected=cmd.ExecuteNonQuery();
				return recAffected;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pk_Uni_ID"></param>
		/// <returns></returns>
    
		public static DataTable DisaffiliationInstituteList(string sUniID,string sCrMoLrnPtrnID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("pk_Uni_ID",sUniID);
				oHs.Add("pk_CrMoLrnPtrn_ID",sCrMoLrnPtrnID);				
				DataTable DT =oDB.getparamdataset("ID_DisaffiliationInstituteList",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pk_Uni_ID"></param>
		/// <returns></returns>
        
		public static string DisaffiliateInstitute(Hashtable oHS)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;

			int returnValue=0;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				SqlCommand cmd =oDB.GenerateCommand("ID_DisaffiliateInstitute",oHS);
				returnValue = cmd.ExecuteNonQuery();			
			}
			catch(Exception ex)
			{
				System.Web.HttpContext.Current.Response.Write(ex.Message);							
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			return returnValue>0 ? "Y" : "N";
		}

		#region All Institutes

		public static DataTable AllInstitutes(string pk_Uni_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("pk_Uni_ID",pk_Uni_ID);

				//DataTable DT = getdataset("ID_AllInstitute").Tables[0]; //Change Procedure Name
				DataTable DT =oDB.getparamdataset("ID_AllInstitute",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}

		#endregion

		#region Institute Details
		public static DataTable AttributeInstituteDetails(string pk_Uni_ID,string pk_Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",pk_Uni_ID);
				oHs.Add("pk_Inst_ID",pk_Inst_ID);
			
				DataTable DT =oDB.getparamdataset("ID_Attribute_Institute",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region All Affiliated Institutes With Affiliation Details
		public static DataTable AffiliatedInstWithInstDetails(string Uni_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("Uni_ID",Uni_ID);
						
				DataTable DT = oDB.getparamdataset("ID_AllAffiliatedInstitutesWithAffiliationDet",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion		

		#region Details of all Affiliation given to Institute
		public static DataTable AffiliationDetailsInstituteWise(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_allAffiliationsDetailsInstituteWise",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}

		}
		#endregion

		#region Assigned Faculties
		public static DataTable AssignedFaculties(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedFaculties",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Confirmed Faculties
		public static DataTable AssignedConfirmedFaculties(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedConfirmedFaculties",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Non Confirmed Faculties
		public static DataTable AssignedNonConfirmedFaculties(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedNonConfirmedFaculties",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Non Affiliated Faculties 
		public static DataTable NonAffiliatedFaculties (string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
						
				DataTable DT = oDB.getparamdataset("ID_NonAffiliatedFaculties",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Courses
		public static DataTable AssignedCourses(string Uni_ID,string Inst_ID,string Fac_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
				oHs.Add("pk_Fac_ID",Fac_ID);
						
				DataTable DT =oDB.getparamdataset("ID_InstWiseAssignCourse",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Faculty Wise Courses
	
		public static DataTable facultywiseCourseList(string Uni_ID,  string Fac_ID, string CrLevel_ID,string PrgTy_ID,string PrgL_ID, string GenProfFlag)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Fac_ID",Fac_ID);
				oHs.Add("CrL_ID",CrLevel_ID);
				oHs.Add("PrgTy_ID",PrgTy_ID);
				oHs.Add("PrgL_ID",PrgL_ID);
				oHs.Add("GenProfFlag",GenProfFlag);
			
				DataTable DT =oDB.getparamdataset("CD_FacwiseCourseList_Launched",oHs).Tables[0];
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion
		
		#region Assigned Confirmed Courses
		public static DataTable AssignedConfirmedCourses(string Uni_ID,string Inst_ID,string Fac_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("Fac_ID",Fac_ID);
						
				DataTable DT = oDB.getparamdataset("ID_AssignedConfirmedCourses",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Non Confirmed Courses
		public static DataTable AssignedNonConfirmedCourses(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedNonConfirmedCourses",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Non Affiliated Courses
		public static DataTable NonAffiliatedCourses (string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_NonAffiliatedCourse",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Mode Of Learning
		public static DataTable AssignedModeOfLearning(string Uni_ID,string Inst_ID,string Fac_ID,string Cr_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("Fac_ID",Fac_ID);
				oHs.Add("Cr_ID",Cr_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedModeOfLearning",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Confirmed Mode Of Learning
		public static DataTable AssignedConfirmedModeOfLearning(string Uni_ID,string Inst_ID,string Fac_ID,string Cr_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("Fac_ID",Fac_ID);
				oHs.Add("Cr_ID",Cr_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedConfirmedModeOfLearning",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Non Confirmed Mode Of Learning
		public static DataTable AssignedNonConfirmedModeOfLearning(string Uni_ID,string Inst_ID,string Fac_ID,string Cr_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("Fac_ID",Fac_ID);
				oHs.Add("Cr_ID",Cr_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedNonConfirmedModeOfLearning",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Course Patterns
		public static DataTable AssignedCoursePatterns(string Uni_ID,string Inst_ID,string CrMoLrnPtrn_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("CrMoLrnPtrn_ID",CrMoLrnPtrn_ID);
						
				DataTable DT = oDB.getparamdataset("ID_AssignedCoursePatterns",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Confirmed Course Patterns
		public static DataTable AssignedConfirmedCoursePatterns(string Uni_ID,string Inst_ID,string CrMoLrnPtrn_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("CrMoLrnPtrn_ID",CrMoLrnPtrn_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedConfirmedCoursePatterns",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Non Confirmed Course Patterns
		public static DataTable AssignedNonConfirmedCoursePatterns(string Uni_ID,string Inst_ID,string CrMoLrnPtrn_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("CrMoLrnPtrn_ID",CrMoLrnPtrn_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedNonConfirmedCoursePatterns",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Course Parts
		public static DataTable AssignedCourseParts(string Uni_ID,string Inst_ID,string CrMoLrnPtrn_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("CrMoLrnPtrn_ID",CrMoLrnPtrn_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedCourseParts",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Confirmed Course Parts
		public static DataTable AssignedConfirmedCourseParts(string Uni_ID,string Inst_ID,string CrMoLrnPtrn_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("CrMoLrnPtrn_ID",CrMoLrnPtrn_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedConfirmedCourseParts",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Non Confirmed Course Parts
		public static DataTable AssignedNonConfirmedCourseParts(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedNonConfirmedCourseParts",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Course Part Patterns
		public static DataTable AssignedCoursePartPatterns(string Uni_ID,string Inst_ID,string CrMoLrnPtrn_ID,string CrPr_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("CrMoLrnPtrn_ID",CrMoLrnPtrn_ID);
				oHs.Add("CrPr_ID",CrPr_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedCoursePartPattern",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Confirmed Course Part Patterns
		public static DataTable AssignedConfirmedCoursePartPatterns(string Uni_ID,string Inst_ID,string CrMoLrnPtrn_ID,string CrPr_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("CrMoLrnPtrn_ID",CrMoLrnPtrn_ID);
				oHs.Add("CrPr_ID",CrPr_ID);
						
				DataTable DT = oDB.getparamdataset("ID_AssignedConfirmedCourseParts",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Non Confirmed Course Part Patterns
		public static DataTable AssignedNonConfirmedCoursePartPatterns(string Uni_ID,string Inst_ID,string CrMoLrnPtrn_ID,string CrPr_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("CrMoLrnPtrn_ID",CrMoLrnPtrn_ID);
				oHs.Add("CrPr_ID",CrPr_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedNonConfirmedCoursePartPattern",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Assigned Non Confirmed Papers
		//Added 
		public static DataTable AssignedConfirmedPapers(string Uni_ID,string Inst_ID, string hidCrID ,string hidModeID ,string hidCrMoLrnPtrnID ,string hidCrPrID , string hidCrPrChID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
				oHs.Add ("hidCrID",hidCrID);
				oHs.Add ("hidModeID",hidModeID);
				oHs.Add("hidCrMoLrnPtrnID",hidCrMoLrnPtrnID);
				oHs.Add("hidCrPrID" ,hidCrPrID );
				oHs.Add ("hidCrPrChID",hidCrPrChID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedConfirmedPaper",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		//
		public static DataTable AssignedNonConfirmedPapers(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AssignedNonConfirmedPaper",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Non Affiliated Course Part 
		public static DataTable NonAffiliatedCoursePart(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_NonAffiliatedCoursePart",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Non Affiliated Paper 
		public static DataTable NonAffiliatedCoursePartTermPaper(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_NonAffiliatedCoursePartTermPaper",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Institute Name
		public static string InstituteName(string pkUniID,string pkInstID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				string InstName="";
			
				oHs.Add("pk_Uni_ID",pkUniID);
				oHs.Add("pk_Inst_ID",pkInstID);
					
				DataTable DT =oDB.getparamdataset("IDV2_InstituteName",oHs).Tables[0]; 
				if(DT.Rows.Count>0)
				{
					InstName=DT.Rows[0]["Inst_Name"].ToString();
				}
				return InstName;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Faculty Name
		public static string GetInstituteFacName(string pkUniID,string pk_Fac_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			Hashtable oHs = new Hashtable();
			string FacName="";
			
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				oHs.Add("pk_Uni_ID",pkUniID);
				oHs.Add("pk_Fac_ID",pk_Fac_ID);
					
				DataTable DT =oDB.getparamdataset("ID_getInstitute_FacutyName",oHs).Tables[0]; 
				if(DT.Rows.Count>0)
				{
					FacName=DT.Rows[0]["Fac_Desc"].ToString();
				}
				return FacName;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion		

		#region Get Institute Course Name(Mode Of Learning)
		public static DataTable GetInstituteCourseName(string Uni_ID,string Inst_ID,string CrMoLrn_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			Hashtable oHs = new Hashtable();
			
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("CrMoLrn_ID",CrMoLrn_ID);
						
				DataTable DT =oDB.getparamdataset("ID_getInstitute_CourseName",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Get Institute_Course_Pattern_Part_PartTermName
		public static string getInstitute_Course_Pattern_Part_PartTermName(string Uni_ID,string Inst_ID,string CrMoLrnPtrn_ID,string CrPr_ID,string CrPrCh_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				string sRet="";
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("CrMoLrnPtrn_ID",CrMoLrnPtrn_ID);
				oHs.Add("CrPr_ID",CrPr_ID);
				oHs.Add("CrPrCh_ID",CrPrCh_ID);
						
				DataTable DT = oDB.getparamdataset("ID_getInstitute_Course_Pattern_Part_PartTermName",oHs).Tables[0]; 
				if(DT.Rows.Count>0)
				{
					sRet=DT.Rows[0]["Inst_Name"].ToString()+"<br>"+DT.Rows[0]["Title"].ToString()+" - "+DT.Rows[0]["MoLrn_Type"].ToString()+" - "+DT.Rows[0]["CrPtrn_Desc"].ToString()+" - "+DT.Rows[0]["CrPr_Abbr"].ToString()+" - "+DT.Rows[0]["CrPrCh_Desc"].ToString();
				}
			
				return sRet;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Get Institute_Course_Pattern
		public static string getInstitute_Course_Pattern(string Uni_ID,string Inst_ID,string Fac_ID,string Cr_ID,string MoLrn_ID,string CrMoLrnPtrn_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				string sRet="";
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				oHs.Add("Fac_ID",Fac_ID);
				oHs.Add("Cr_ID",Cr_ID);
				oHs.Add("MoLrn_ID",MoLrn_ID);
				oHs.Add("CrMoLrnPtrn_ID",CrMoLrnPtrn_ID);
						
				DataTable DT =oDB.getparamdataset("ID_getInstitute_Course_Pattern",oHs).Tables[0]; 
				if(DT.Rows.Count>0)
				{
					sRet=DT.Rows[0]["Inst_Name"].ToString()+"<br>"+DT.Rows[0]["Fac_Desc"].ToString()+"-"+DT.Rows[0]["Title"].ToString()+" - "+DT.Rows[0]["MoLrn_Type"].ToString()+" - "+DT.Rows[0]["CrPtrn_Desc"].ToString();
				}
			
				return sRet;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region Courses Affiliation
		public static DataTable CoursesAffiliation(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
						
				DataTable DT = oDB.getparamdataset("ID_CoursesAffiliation",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region To check Institute Image Available
		public static bool InstituteImageAvailable(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);

				DataTable DT =oDB.getparamdataset("ID_InstituteImageAvailable",oHs).Tables[0];
			
				if (DT.Rows.Count>0)
				{
					if (DT.Rows[0]["Inst_Image"].ToString() == "NULL")
						return true; //Image not present
					else
						return false; //Image Present
				}
				return false;
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
		#endregion

		#region  ADD,MODIFY,DELETE,DETAIL & ACCREDITATION GRADES FOR INSTITUTE ACCREDITATION
		
		public static int isExistInstAccreditation(string Uni_ID,string Inst_ID,string Accr_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("fk_Uni_ID",Uni_ID);
				oHs.Add("fk_Inst_ID",Inst_ID);
				oHs.Add("fk_Accr_ID",Accr_ID);
				DataTable DT = oDB.getparamdataset("ID_IsExistInstAccreditation",oHs).Tables[0]; 
				if(DT.Rows[0]["CountRow"].ToString()=="0")
					return 0;
				else
					return 1;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}

		public static DataTable allInstAccreditation(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
				DataTable DT =oDB.getparamdataset("ID_allInstAccreditation",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}

		public static DataTable InstAccreditationDetails(string pkInstAccrID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("pk_InstAccr_ID",pkInstAccrID);
				DataTable DT = oDB.getparamdataset("ID_InstAccreditationByID",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}

		public static string addInstAccreditation(Hashtable HtAllValues)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;

			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				string returnValue;
				SqlCommand cmd =oDB.GenerateCommand("ID_addInstAccreditation",HtAllValues);
				cmd.ExecuteNonQuery();
				returnValue = cmd.Parameters["@pk_InstAccr_ID"].Value.ToString();
				return returnValue;
			}
			catch
			{
				return "Y";
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}


		public static int modifyInstAccreditation(Hashtable HtAllValues)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			int rowAffected=0;
			
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				SqlCommand cmd = oDB.GenerateCommand("ID_modifyInstAccreditation",HtAllValues); //Change Procedure name
				rowAffected = cmd.ExecuteNonQuery();
				return rowAffected;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}


		public static int deleteInstAccreditation(string pkInstAccrID,string userID)
		{	
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("pk_InstAccr_ID",pkInstAccrID);
				oHs.Add("User_ID",userID);
				int rowAffected=0;
		
				SqlCommand cmd =oDB.GenerateCommand("ID_deleteInstAccreditation",oHs); //Change Procedure name
				rowAffected = cmd.ExecuteNonQuery();
				return rowAffected;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
	

		#endregion

		#region Institute Search
        public static DataTable InstituteSearch(string Uni_ID, string InstTy_ID, string Inst_Name, string Country_ID, string State_ID, string District_ID, string Tehsil_ID, string Inst_code)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                Hashtable oHs = new Hashtable();

                oHs.Add("Uni_ID", Uni_ID);
                oHs.Add("InstTy_ID", InstTy_ID);
                oHs.Add("Inst_Name", Inst_Name);
                oHs.Add("Country_ID", Country_ID);
                oHs.Add("State_ID", State_ID);
                oHs.Add("District_ID", District_ID);
                oHs.Add("Tehsil_ID", Tehsil_ID);
                oHs.Add("Inst_code", Inst_code);

                DataTable DT = oDB.getparamdataset("ELGV2_SearchInstitute", oHs).Tables[0];
                return DT;
            }
            catch (Exception ex)
            {
                throw (ex);
               //Exception e = new Exception(ex.Message, ex);

            }

			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region All faculty university wise
		public static DataTable allFacultyUniversityWise(string pkUniID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("pk_Uni_ID",pkUniID);
				DataTable DT =oDB.getparamdataset("CD_AllUniversityWiseFaculty",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region All subject 
		public static DataTable allSubject()
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				DataTable DT =oDB.getdataset("CD_allSubject").Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion

		#region All subject faculty wise
		public static DataTable allSubjectFacultyWise(string pkUniID,string pkFacID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("@pk_Uni_ID",pkUniID);
				oHs.Add("@pk_Fac_ID",pkFacID);
				DataTable DT =oDB.getparamdataset("CD_allSubjectFacultyWise",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion
		
		//Function from cr definition classes 
		#region To fill course Level
		/// <summary>
		/// This function is used to return All Course Levels 
		/// </summary>
		/// <param name="uni_ID">University Id</param>
		/// <returns>Datatable</returns>
		/// 
		public static DataTable allCourseLevels(long uni_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("pk_Uni_ID",uni_ID);
				DataSet DS =oDB.getparamdataset("CD_allCourseLevel",oHs);
				if(DS.Tables.Count == 1)
					return DS.Tables[0];
				else
					return null;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}

		#endregion


		#region Program Type Details
		public static DataTable ListProgramType(string uniID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("pk_Uni_ID",uniID);
				//This procedure should be  use from crouse definition module
				//but CD_allProgramType-- Not Correct it shd be university wise
				DataSet DS =oDB.getparamdataset("ID_listProgramType",oHs);	
				if(DS.Tables.Count == 1)
					return DS.Tables[0];
				else
					return null;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion


		#region Program Type Details
		public static DataTable ListProgramlevel(string uniID,string prgType)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("pk_Uni_ID",uniID);
				oHs.Add("pk_PrgTy_ID",prgType);
				//This procedure should be  use from crouse definition module
				DataSet DS = oDB.getparamdataset("ID_ListProgramLevelPrgTypeWise",oHs);	
				if(DS.Tables.Count == 1)
					return DS.Tables[0];
				else
					return null;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion


		#region Institute Wise Course Pattern
		public static DataTable InstituteWiseCrPattern(string UniID,string InstID,string FacID,string CrID,string MoLrnID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",UniID);
				oHs.Add("pk_Inst_ID",InstID);
				oHs.Add("pk_Fac_ID",FacID);
				oHs.Add("pk_Cr_ID",CrID);
				oHs.Add("pk_MoLrn_ID",MoLrnID);

				DataTable DT =oDB.getparamdataset("ID_InstWiseAssignCoursePtrn",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion


		#region Faculty Wise Course List
		public static DataTable FacultyWiseCourses(string UniID,string FacID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",UniID);
				oHs.Add("Fac_ID",FacID);
			
				DataTable DT =oDB.getparamdataset("CD_CourseList_Launched",oHs).Tables[0]; 
				return DT;
			}
			finally
			{	
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion


		#region Display Mission Vision Goals
		/// <summary>
		/// Display Mission Vision Goals
		/// </summary>
		/// <param name="uni_ID">University Id</param>
		/// <returns>Datatable</returns>
		/// 
		public static DataTable diplayMissionVisionGoals(string pkUniID , string pkInstID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
				oHs.Add("pk_Uni_ID",pkUniID);
				oHs.Add("pk_Inst_ID",pkInstID);
				DataTable DT  = oDB.getparamdataset("ID_diplayMissionVisionGoals",oHs).Tables[0];
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}

		#endregion


		#region Affiliation Details Display Faculties
		public static DataTable AffiliationDetailsDisplayFaculties(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("Uni_ID",Uni_ID);
				oHs.Add("Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AffiliationDetailsDisplayFaculties",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion


		#region Affiliation Details Display Courses
		public static DataTable AffiliationDetailsDisplayCourses(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AffiliationDetailsDisplayCourses",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion


		#region Affiliation Details Display CourseParts
		public static DataTable AffiliationDetailsDisplayCourseParts(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AffiliationDetailsDisplayCourseParts",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion


		#region Affiliation Details Display Paper
		public static DataTable AffiliationDetailsDisplayPaper(string Uni_ID,string Inst_ID)
		{
			DBObjectPool Pool=null;
			DBObject oDB=null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();

				Hashtable oHs = new Hashtable();
			
				oHs.Add("pk_Uni_ID",Uni_ID);
				oHs.Add("pk_Inst_ID",Inst_ID);
						
				DataTable DT =oDB.getparamdataset("ID_AffilationDetailsDisplayPaper",oHs).Tables[0]; 
				return DT;
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}
		#endregion


        #region Functions to be added in the InstituteRepository // Added by Shivani on 08-08-2008

        public static DataTable Get_AllCourse(string universityID, string instituteID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable["UniID"] = universityID;
            hashtable["InstID"] = instituteID;
            DataTable table = new DataTable();
            DBObjectPool pool = null;
            DBObject oDB = null;
           
            try
            {
                pool = DBObjectPool.Instance;
                oDB = pool.AcquireDBObject();
                table = oDB.getparamdataset("elgV2_getAllInstituteWiseCourses", hashtable).Tables[0];
                
            }
            finally
            {
                pool.ReleaseDBObject(oDB);
            }
            return table;
        }

        public static DataTable Get_CourseModeofLearningPatternWiseBranchList(string universityID, string instituteID, string facID, string crID, string moLrnID, string ptrnID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable["UniID"] = universityID;
            hashtable["InstID"] = instituteID;
            hashtable["FacID"] = facID;
            hashtable["CrID"] = crID;
            hashtable["MoLrnID"] = moLrnID;
            hashtable["PtrnID"] = ptrnID;
            DataTable table = new DataTable();
            DBObject oDB = null;
            DBObjectPool pool = null;
            try
            {
                pool = DBObjectPool.Instance;
                oDB = pool.AcquireDBObject();
                table = oDB.getparamdataset("IDV2_ListFacultyCourseModeofLearningPatternWiseBranches", hashtable).Tables[0];

            }
            finally
            {
                pool.ReleaseDBObject(oDB);
            }
            return table;
        }

        public static DataTable Get_AllCoursePartOnly(string universityID, string instituteID,string facID,string crID, string moLrnID, string ptrnID, string brnID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable["pk_Uni_ID"] = universityID;
            hashtable["pk_Inst_ID"] = instituteID;
            hashtable["FacID"] = facID;
            hashtable["CrID"] = crID;
            hashtable["MoLrnID"] = moLrnID;
            hashtable["PtrnID"] = ptrnID;
            hashtable["BrnID"] = brnID;
            DataTable table = new DataTable();
            DBObjectPool pool = null;
            DBObject oDB = null;
            try
            {
                pool = DBObjectPool.Instance;
                oDB = pool.AcquireDBObject();
                table = oDB.getparamdataset("elgV2_getAllInstWiseCoursePartOnly", hashtable).Tables[0];
            }
            finally
            {
                pool.ReleaseDBObject(oDB);
            }
            return table;
        }

        public static DataTable stateWiseDistricts(string StateID, string langFlag)
        {
            Hashtable hashtable = new Hashtable();
            hashtable["State_ID"] = StateID;
            hashtable["Lang_Flag"] = langFlag;
            DataSet set = new DataSet();
            DBObjectPool pool = null;
            DBObject oDB = null;
            try
            {
                pool = DBObjectPool.Instance;
                oDB = pool.AcquireDBObject();
                set = oDB.getparamdataset("GEN_stateWiseDistricts", hashtable);
            }
            finally
            {
                pool.ReleaseDBObject(oDB);
            }
            if (set.Tables.Count == 1)
            {
                return set.Tables[0];
            }
            return null;
        }

        public static DataTable displayTalukaWithinDistrict(string districtID, string langFlag)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("District_ID", districtID);
            hashtable.Add("Lang_Flag", langFlag);
            DataSet set = new DataSet();
            DBObjectPool pool = null;
            DBObject oDB = null;
            try
            {
                pool = DBObjectPool.Instance;
                oDB = pool.AcquireDBObject();
                set = oDB.getparamdataset("GEN_districtWiseTaluka", hashtable);
            }
            finally
            {
                pool.ReleaseDBObject(oDB);
            }
            if (set.Tables.Count == 1)
            {
                return set.Tables[0];
            }
            return null;
        }

        
        #endregion

        public static DataTable getInstituteDetails(string UniID, string InstID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Uni_ID", UniID);
            hashtable.Add("InstID", InstID);
            DataTable dt = new DataTable();
            DBObjectPool pool = null;
            DBObject oDB = null;
            try
            {
                pool = DBObjectPool.Instance;
                oDB = pool.AcquireDBObject();
                dt = oDB.getparamdataset("ELGV2_FetchInstituteDetails", hashtable).Tables[0];
            }
            finally
            {
                pool.ReleaseDBObject(oDB);
            }

            return dt;
        }

        #region InstituteSearch_ByAffiliatedCourse
        /// <summary>
        /// Seacrh student.
        /// </summary>
        /// <param name="oHs"></param>
        /// <returns></returns>
        public DataTable InstituteSearch_ByAffiliatedCourse(string pk_Fac_ID, string pk_Cr_ID, string pk_MoLrn_ID, string pk_Ptrn_ID, string pk_Brn_ID, string pk_CrPr_Details_ID, string pk_AcademicYear_ID)
        {
            Hashtable oHs = new Hashtable();
            DataTable dt = new DataTable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string uniID = clsGetSettings.UniversityID.Trim();
            try
            {
                oHs.Add("UniID", uniID);
                oHs.Add("pk_Fac_ID", pk_Fac_ID);
                oHs.Add("pk_Cr_ID", pk_Cr_ID);
                oHs.Add("pk_MoLrn_ID", pk_MoLrn_ID);
                oHs.Add("pk_Ptrn_ID", pk_Ptrn_ID);
                oHs.Add("pk_Brn_ID", pk_Brn_ID);
                oHs.Add("pk_CrPr_Details_ID", pk_CrPr_Details_ID);
                oHs.Add("pk_AcademicYear_ID", pk_AcademicYear_ID);

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

    }
}
