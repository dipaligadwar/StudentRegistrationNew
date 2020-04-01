using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Classes;
using System.IO;
using System.Configuration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace StudentRegistration.Eligibility.ElgClasses
{
    /// <summary>
    /// Summary description for clsRegStudent.
    /// </summary>

    [Serializable]
    public class clsRegStudent
    {
        private string spk_Uni_ID;
        private string spk_Year;
        private string spk_Student_ID;
        private string sLast_Name;
        private string sFirst_Name;
        private string sMiddle_Name;
        private string sMother_Last_Name;
        private string sMother_First_Name;
        private string sMother_Middle_Name;
        private string sFather_Last_Name;
        private string sFather_First_Name;
        private string sFather_Middle_Name;
        private string sMarital_Status;
        private string sChanged_Name_Flag;
        private string sPrev_Last_Name;
        private string sPrev_First_Name;
        private string sPrev_Middle_Name;
        private string sChanged_Name_Reason;
        private string sGender;
        private string sBloodGrp;
        private string sDate_of_Birth;
        private string sDOB;
        private string sPlace_of_Birth;
        private string sfk_Reln_ID;
        private string sReligion_Desc;
        private string sNationality_Country_ID;
        private string sDomicile_of_State;
        private string sCategory_Flag;
        private string sfk_Category_ID;
        private string sPhysically_Challenged_Flag;
        private string sfk_PhysicalChallenge_ID;
        private string sCorr_State_ID;
        private string sCorr_District_ID;
        private string sCorr_Tahsil_ID;
        private string sCorr_Other_Tahsil;
        private string sCorr_City;
        private string sCorr_Address;
        private string sCorr_Pin;
        private string sCorr_Per_Same_Flag;
        private string sPer_Country_ID;
        private string sPer_State_ID;
        private string sPer_Foreign_State;
        private string sPer_District_ID;
        private string sPer_Tahsil_ID;
        private string sPer_Other_Tahsil;
        private string sPer_City;
        private string sPer_Address;
        private string sPer_Pin;
        private string sPhone1_STD;
        private string sPhone1_Number;
        private string sPhone2_STD;
        private string sPhone2_Number;
        private string sMobile_Number;
        private string sEmail_ID;
        private string sGuardian_Annual_Income;
        private string sGuardian_Occupation_ID;
        private System.Drawing.Image sPhotograph;
        private System.Drawing.Image sSignature;
        private string sPRN_Number;
        private string sCStateName;
        private string sCDistrictName;
        private string sCTalukaName;
        private string sPStateName;
        private string sPDistrictName;
        private string sPTalukaName;
        private string sPCountryName;
        private string sNationality;
        private string sCategory_Desc;
        private string sCategory_ShortName;
        private string sMaritalStatus_Desc;
        private string sGender_Desc;
        private string sAdmission_Form_No;
        private string sAdmission_Date;
        private string sNameOnMarksheet;
        private string sNameVernacular;
        private string sMotherNameVernacular;

        #region Student Properties

        public string AADHARNo { get; set; }
        public string Name_QualExamMarkSheet
        {
            get
            {
                return sNameOnMarksheet;
            }
            set
            {
                sNameOnMarksheet = value;
            }
        }

        public string Vernacular_Name
        {
            get
            {
                return sNameVernacular;
            }
            set
            {
                sNameVernacular = value;
            }
        }


        public string Mother_Vernacular_Name
        {
            get
            {
                return sMotherNameVernacular;
            }
            set
            {
                sMotherNameVernacular = value;
            }
        }

        public string Last_Name
        {
            get
            {
                return sLast_Name;
            }
            set
            {
                sLast_Name = value;
            }
        }
        public string First_Name
        {
            get
            {
                return sFirst_Name;
            }
            set
            {
                sFirst_Name = value;
            }
        }
        public string Middle_Name
        {
            get
            {
                return sMiddle_Name;
            }
            set
            {
                sMiddle_Name = value;
            }
        }
        public string Mother_Last_Name
        {
            get
            {
                return sMother_Last_Name;
            }
            set
            {
                sMother_Last_Name = value;
            }
        }
        public string Mother_First_Name
        {
            get
            {
                return sMother_First_Name;
            }
            set
            {
                sMother_First_Name = value;
            }
        }
        public string Mother_Middle_Name
        {
            get
            {
                return sMother_Middle_Name;
            }
            set
            {
                sMother_Middle_Name = value;
            }
        }
        public string Father_Last_Name
        {
            get
            {
                return sFather_Last_Name;
            }
            set
            {
                sFather_Last_Name = value;
            }
        }
        public string Father_First_Name
        {
            get
            {
                return sFather_First_Name;
            }
            set
            {
                sFather_First_Name = value;
            }
        }
        public string Father_Middle_Name
        {
            get
            {
                return sFather_Middle_Name;
            }
            set
            {
                sFather_Middle_Name = value;
            }
        }
        public string Marital_Status
        {
            get
            {
                return sMarital_Status;
            }
            set
            {
                sMarital_Status = value;
            }
        }
        public string Changed_Name_Flag
        {
            get
            {
                return sChanged_Name_Flag;
            }
            set
            {
                sChanged_Name_Flag = value;
            }
        }
        public string Prev_Last_Name
        {
            get
            {
                return sPrev_Last_Name;
            }
            set
            {
                sPrev_Last_Name = value;
            }
        }
        public string Prev_First_Name
        {
            get
            {
                return sPrev_First_Name;
            }
            set
            {
                sPrev_First_Name = value;
            }
        }
        public string Prev_Middle_Name
        {
            get
            {
                return sPrev_Middle_Name;
            }
            set
            {
                sPrev_Middle_Name = value;
            }
        }
        public string Changed_Name_Reason
        {
            get
            {
                return sChanged_Name_Reason;
            }
            set
            {
                sChanged_Name_Reason = value;
            }
        }
        public string Gender
        {
            get
            {
                return sGender;
            }
            set
            {
                sGender = value;
            }
        }
        public string BloodGrp
        {
            get
            {
                return sBloodGrp;
            }
            set
            {
                sBloodGrp = value;
            }
        }
        public string Date_of_Birth
        {
            get
            {
                return sDate_of_Birth;
            }
            set
            {
                sDate_of_Birth = value;
            }
        }
        public string DOB
        {
            get
            {
                return sDOB;
            }
            set
            {
                sDOB = value;
            }
        }
        public string Place_of_Birth
        {
            get
            {
                return sPlace_of_Birth;
            }
            set
            {
                sPlace_of_Birth = value;
            }
        }
        public string fk_Reln_ID
        {
            get
            {
                return sfk_Reln_ID;
            }
            set
            {
                sfk_Reln_ID = value;
            }
        }
        public string Religion_Desc
        {
            get
            {
                return sReligion_Desc;
            }
            set
            {
                sReligion_Desc = value;
            }
        }
        public string Nationality_Country_ID
        {
            get
            {
                return sNationality_Country_ID;
            }
            set
            {
                sNationality_Country_ID = value;
            }
        }
        public string Domicile_of_State
        {
            get
            {
                return sDomicile_of_State;
            }
            set
            {
                sDomicile_of_State = value;
            }
        }
        public string MaritalStatus_Desc
        {
            get
            {
                return sMaritalStatus_Desc;
            }
            set
            {
                sMaritalStatus_Desc = value;
            }
        }
        public string Gender_Desc
        {
            get
            {
                return sGender_Desc;
            }
            set
            {
                sGender_Desc = value;
            }
        }
        public string Category_Flag
        {
            get
            {
                return sCategory_Flag;
            }
            set
            {
                sCategory_Flag = value;
            }
        }
        public string fk_Category_ID
        {
            get
            {
                return sfk_Category_ID;
            }
            set
            {
                sfk_Category_ID = value;
            }
        }

        public string Physically_Challenged_Flag
        {
            get
            {
                return sPhysically_Challenged_Flag;
            }
            set
            {
                sPhysically_Challenged_Flag = value;
            }
        }
        public string fk_PhysicalChallenge_ID
        {
            get
            {
                return sfk_PhysicalChallenge_ID;
            }
            set
            {
                sfk_PhysicalChallenge_ID = value;
            }
        }
        public string Corr_State_ID
        {
            get
            {
                return sCorr_State_ID;
            }
            set
            {
                sCorr_State_ID = value;
            }
        }
        public string Corr_District_ID
        {
            get
            {
                return sCorr_District_ID;
            }
            set
            {
                sCorr_District_ID = value;
            }
        }
        public string Corr_Tahsil_ID
        {
            get
            {
                return sCorr_Tahsil_ID;
            }
            set
            {
                sCorr_Tahsil_ID = value;
            }
        }
        public string Corr_Other_Tahsil
        {
            get
            {
                return sCorr_Other_Tahsil;
            }
            set
            {
                sCorr_Other_Tahsil = value;
            }
        }
        public string Corr_City
        {
            get
            {
                return sCorr_City;
            }
            set
            {
                sCorr_City = value;
            }
        }
        public string Corr_Address
        {
            get
            {
                return sCorr_Address;
            }
            set
            {
                sCorr_Address = value;
            }
        }
        public string Corr_Pin
        {
            get
            {
                return sCorr_Pin;
            }
            set
            {
                sCorr_Pin = value;
            }
        }
        public string Corr_Per_Same_Flag
        {
            get
            {
                return sCorr_Per_Same_Flag;
            }
            set
            {
                sCorr_Per_Same_Flag = value;
            }
        }
        public string Per_Country_ID
        {
            get
            {
                return sPer_Country_ID;
            }
            set
            {
                sPer_Country_ID = value;
            }
        }
        public string Per_State_ID
        {
            get
            {
                return sPer_State_ID;
            }
            set
            {
                sPer_State_ID = value;
            }
        }
        public string Per_Foreign_State
        {
            get
            {
                return sPer_Foreign_State;
            }
            set
            {
                sPer_Foreign_State = value;
            }
        }
        public string Per_District_ID
        {
            get
            {
                return sPer_District_ID;
            }
            set
            {
                sPer_District_ID = value;
            }
        }
        public string Per_Tahsil_ID
        {
            get
            {
                return sPer_Tahsil_ID;
            }
            set
            {
                sPer_Tahsil_ID = value;
            }
        }
        public string Per_Other_Tahsil
        {
            get
            {
                return sPer_Other_Tahsil;
            }
            set
            {
                sPer_Other_Tahsil = value;
            }
        }
        public string Per_City
        {
            get
            {
                return sPer_City;
            }
            set
            {
                sPer_City = value;
            }
        }
        public string Per_Address
        {
            get
            {
                return sPer_Address;
            }
            set
            {
                sPer_Address = value;
            }
        }
        public string Per_Pin
        {
            get
            {
                return sPer_Pin;
            }
            set
            {
                sPer_Pin = value;
            }
        }
        public string Phone1_STD
        {
            get
            {
                return sPhone1_STD;
            }
            set
            {
                sPhone1_STD = value;
            }
        }
        public string Phone1_Number
        {
            get
            {
                return sPhone1_Number;
            }
            set
            {
                sPhone1_Number = value;
            }
        }
        public string Phone2_STD
        {
            get
            {
                return sPhone2_STD;
            }
            set
            {
                sPhone2_STD = value;
            }
        }
        public string Phone2_Number
        {
            get
            {
                return sPhone2_Number;
            }
            set
            {
                sPhone2_Number = value;
            }
        }
        public string Mobile_Number
        {
            get
            {
                return sMobile_Number;
            }
            set
            {
                sMobile_Number = value;
            }
        }
        public string Email_ID
        {
            get
            {
                return sEmail_ID;
            }
            set
            {
                sEmail_ID = value;
            }
        }
        public string Guardian_Annual_Income
        {
            get
            {
                return sGuardian_Annual_Income;
            }
            set
            {
                sGuardian_Annual_Income = value;
            }
        }
        public string Guardian_Occupation_ID
        {
            get
            {
                return sGuardian_Occupation_ID;
            }
            set
            {
                sGuardian_Occupation_ID = value;
            }
        }

        public string PRN_Number
        {
            get
            {
                return sPRN_Number;
            }
            set
            {
                sPRN_Number = value;
            }
        }
        public string CStateName
        {
            get
            {
                return sCStateName;
            }
            set
            {
                sCStateName = value;
            }
        }
        public string CDistrictName
        {
            get
            {
                return sCDistrictName;
            }
            set
            {
                sCDistrictName = value;
            }
        }
        public string CTalukaName
        {
            get
            {
                return sCTalukaName;
            }
            set
            {
                sCTalukaName = value;
            }
        }


        public string PStateName
        {
            get
            {
                return sPStateName;
            }
            set
            {
                sPStateName = value;
            }
        }
        public string PDistrictName
        {
            get
            {
                return sPDistrictName;
            }
            set
            {
                sPDistrictName = value;
            }
        }
        public string PTalukaName
        {
            get
            {
                return sPTalukaName;
            }
            set
            {
                sPTalukaName = value;
            }
        }
        public string PCountryName
        {
            get
            {
                return sPCountryName;
            }
            set
            {
                sPCountryName = value;
            }
        }
        public string Nationality
        {
            get
            {
                return sNationality;
            }
            set
            {
                sNationality = value;
            }
        }
        public string Category_Desc
        {
            get
            {
                return sCategory_Desc;
            }
            set
            {
                sCategory_Desc = value;
            }
        }
        public string Category_ShortName
        {
            get
            {
                return sCategory_ShortName;
            }
            set
            {
                sCategory_ShortName = value;
            }
        }

        public System.Drawing.Image Photograph
        {
            get
            {
                return sPhotograph;
            }
            set
            {
                sPhotograph = value;
            }
        }

        public System.Drawing.Image Signature
        {
            get
            {
                return sSignature;
            }
            set
            {
                sSignature = value;
            }
        }
        public string Admission_Form_No
        {
            get
            {
                return sAdmission_Form_No;
            }
            set
            {
                sAdmission_Form_No = value;
            }
        }
        public string Admission_Date
        {
            get
            {
                return sAdmission_Date;
            }
            set
            {
                sAdmission_Date = value;
            }
        }


        #endregion

  

        #region clsRegStudent Constructor
        public clsRegStudent(string pk_Uni_ID, string pk_Year, string pk_Student_ID)
        {

            spk_Uni_ID = pk_Uni_ID;
            spk_Year = pk_Year;
            spk_Student_ID = pk_Student_ID;
            //sPRN_Number=PRN_Number;
            DataTable sDT = new DataTable();
            sDT = LoadStudent();
            if (sDT.Rows.Count > 0)
            {


                sLast_Name = sDT.Rows[0]["Last_Name"].ToString().Trim();
                sFirst_Name = sDT.Rows[0]["First_Name"].ToString().Trim();
                sMiddle_Name = sDT.Rows[0]["Middle_Name"].ToString().Trim();

                sNameOnMarksheet = sDT.Rows[0]["Name_QualExamMarkSheet"].ToString();
                sNameVernacular = sDT.Rows[0]["Vernacular_Name"].ToString().Trim();
                AADHARNo = sDT.Rows[0]["Aadhaar_Number"].ToString().Trim();
                sMother_Last_Name = sDT.Rows[0]["Mother_Last_Name"].ToString().Trim();
                sMother_First_Name = sDT.Rows[0]["Mother_First_Name"].ToString().Trim();
                sMother_Middle_Name = sDT.Rows[0]["Mother_Middle_Name"].ToString().Trim();

                sFather_Last_Name = sDT.Rows[0]["Father_Last_Name"].ToString().Trim();
                sFather_First_Name = sDT.Rows[0]["Father_First_Name"].ToString().Trim();
                sFather_Middle_Name = sDT.Rows[0]["Father_Middle_Name"].ToString().Trim();

                sMarital_Status = sDT.Rows[0]["Marital_Status"].ToString().Trim();
                sChanged_Name_Flag = sDT.Rows[0]["Changed_Name_Flag"].ToString().Trim();
                sPrev_Last_Name = sDT.Rows[0]["Prev_Last_Name"].ToString().Trim();
                sPrev_First_Name = sDT.Rows[0]["Prev_First_Name"].ToString().Trim();
                sPrev_Middle_Name = sDT.Rows[0]["Prev_Middle_Name"].ToString().Trim();
                sChanged_Name_Reason = sDT.Rows[0]["Changed_Name_Reason"].ToString().Trim();
                sGender = sDT.Rows[0]["Gender"].ToString().Trim();
                sBloodGrp = sDT.Rows[0]["Blood_Group"].ToString().Trim();
                sDate_of_Birth = sDT.Rows[0]["Date_of_Birth"].ToString().Trim();
                sDOB = sDT.Rows[0]["DOB"].ToString().Trim();
                sPlace_of_Birth = sDT.Rows[0]["Place_of_Birth"].ToString().Trim();
                sfk_Reln_ID = sDT.Rows[0]["fk_Reln_ID"].ToString().Trim();
                sReligion_Desc = sDT.Rows[0]["Religion"].ToString().Trim();
                sNationality_Country_ID = sDT.Rows[0]["Nationality_Country_ID"].ToString().Trim();
                sDomicile_of_State = sDT.Rows[0]["Domicile_of_State"].ToString().Trim();
                sCategory_Flag = sDT.Rows[0]["Category_Flag"].ToString().Trim();
                sfk_Category_ID = sDT.Rows[0]["fk_Category_ID"].ToString().Trim();
                sPhysically_Challenged_Flag = sDT.Rows[0]["Physically_Challenged_Flag"].ToString().Trim();
                sfk_PhysicalChallenge_ID = sDT.Rows[0]["fk_PhysicalChallenge_ID"].ToString().Trim();
                sCorr_State_ID = sDT.Rows[0]["Corr_State_ID"].ToString().Trim();
                sCorr_District_ID = sDT.Rows[0]["Corr_District_ID"].ToString().Trim();
                sCorr_Tahsil_ID = sDT.Rows[0]["Corr_Tahsil_ID"].ToString().Trim();
                sCorr_Other_Tahsil = sDT.Rows[0]["Corr_Other_Tahsil"].ToString().Trim();
                sCorr_City = sDT.Rows[0]["Corr_City"].ToString().Trim();
                sCorr_Address = sDT.Rows[0]["Corr_Address"].ToString().Trim();
                sCorr_Pin = sDT.Rows[0]["Corr_Pin"].ToString().Trim();
                sCorr_Per_Same_Flag = sDT.Rows[0]["Corr_Per_Same_Flag"].ToString().Trim();
                sPer_Country_ID = sDT.Rows[0]["Per_Country_ID"].ToString().Trim();
                sPer_State_ID = sDT.Rows[0]["Per_State_ID"].ToString().Trim();
                sPer_Foreign_State = sDT.Rows[0]["Per_Foreign_State"].ToString().Trim();
                sPer_District_ID = sDT.Rows[0]["Per_District_ID"].ToString().Trim();
                sPer_Tahsil_ID = sDT.Rows[0]["Per_Tahsil_ID"].ToString().Trim();
                sPer_Other_Tahsil = sDT.Rows[0]["Per_Other_Tahsil"].ToString().Trim();
                sPer_City = sDT.Rows[0]["Per_City"].ToString().Trim();
                sPer_Address = sDT.Rows[0]["Per_Address"].ToString().Trim();
                sPer_Pin = sDT.Rows[0]["Per_Pin"].ToString().Trim();
                sPhone1_STD = sDT.Rows[0]["Phone1_STD"].ToString().Trim();
                sPhone1_Number = sDT.Rows[0]["Phone1_Number"].ToString().Trim();
                sPhone2_STD = sDT.Rows[0]["Phone2_STD"].ToString().Trim();
                sPhone2_Number = sDT.Rows[0]["Phone2_Number"].ToString().Trim();
                sMobile_Number = sDT.Rows[0]["Mobile_Number"].ToString().Trim();
                sEmail_ID = sDT.Rows[0]["Email_ID"].ToString().Trim();
                sGuardian_Annual_Income = sDT.Rows[0]["Guardian_Annual_Income"].ToString().Trim();
                sGuardian_Occupation_ID = sDT.Rows[0]["Guardian_Occupation_ID"].ToString().Trim();
                sMotherNameVernacular = sDT.Rows[0]["Mother_Vernacular_Name"].ToString().Trim();
                //				if(sDT.Rows[0]["Photograph"]!= DBNull.Value)
                //				{
                //					byte[] Bytes=(byte[])sDT.Rows[0]["Photograph"] ;
                //					System.IO.Stream s=new System.IO.MemoryStream(Bytes);
                //					sPhotograph=System.Drawing.Image.FromStream(s);
                //				}				
                //				if(sDT.Rows[0]["Signature"]!= DBNull.Value)
                //				{
                //					byte[] Bytes1 = (byte[])sDT.Rows[0]["Signature"] ;
                //					System.IO.Stream sSign=new System.IO.MemoryStream(Bytes1);
                //					sSignature = System.Drawing.Image.FromStream(sSign);
                //				}
                sPRN_Number = sDT.Rows[0]["PRN_Number"].ToString().Trim();
                sCStateName = sDT.Rows[0]["CStateName"].ToString().Trim();
                sCDistrictName = sDT.Rows[0]["CDistrictName"].ToString().Trim();
                sCTalukaName = sDT.Rows[0]["CTalukaName"].ToString().Trim();
                sPStateName = sDT.Rows[0]["PStateName"].ToString().Trim();
                sPDistrictName = sDT.Rows[0]["PDistrictName"].ToString().Trim();
                sPTalukaName = sDT.Rows[0]["PTalukaName"].ToString().Trim();
                sPCountryName = sDT.Rows[0]["PCountryName"].ToString().Trim();
                sNationality = sDT.Rows[0]["Nationality"].ToString().Trim();
                sCategory_Desc = sDT.Rows[0]["Category_Desc"].ToString().Trim();
                sCategory_ShortName = sDT.Rows[0]["Category_ShortName"].ToString().Trim();
                sMaritalStatus_Desc = sDT.Rows[0]["MaritalStatus_Desc"].ToString().Trim();
                sGender_Desc = sDT.Rows[0]["Gender_Desc"].ToString().Trim();
                //sAdmission_Form_No = sDT.Rows[0]["Admission_Form_No"].ToString().Trim() ;
                //sAdmission_Date = sDT.Rows[0]["Admission_Date"].ToString().Trim() ;
            }
        }

        public clsRegStudent()
        {
            // TODO: Complete member initialization
        }
        #endregion

        #region Load Student

        public DataTable LoadStudent()
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;

            DataTable DT = new DataTable();
            Hashtable oHS = new Hashtable();

            oHS.Add("pk_Uni_ID", spk_Uni_ID);
            oHS.Add("pk_Year", spk_Year);
            oHS.Add("pk_Student_ID", spk_Student_ID);

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                DT = oDB.getparamdataset("REGV2_Get_PersonalDetails", oHS).Tables[0];
                return (DT);
            }
            catch (SqlException ex)
            {
                Exception e;
                e = new Exception(ex.Message, ex);
                throw (e);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }


        }

        //got to work on it !!!
        #endregion

        #region Fetch Student PRN, Course and College
        public static DataSet Fetch_StudentReRegistraionCourseDetails(string Uni_ID, string Year, string Student_ID)
        {
            DataSet ds = new DataSet();
            //SqlParameter[] pr = new SqlParameter[3];
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("UniID", Uni_ID);
                ht.Add("Year", Year);
                ht.Add("StudID", Student_ID);
                ds = oDB.getparamdataset("REGV2_GetStudentReRegistrationCourseDetails", ht);
               
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
            return ds;

        }
        #endregion 
        #region REG_ProfileSearch_GetStudentIDs
        public static DataSet REG_ProfileSearch_GetStudentIDs(string PRN)
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("PRN", PRN);
                ds = oDB.getparamdataset("REGV2_ProfileSearch_GetStudentIDs", ht);
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
            return ds;
        }
        #endregion
        #region Mercy student
        public static DataTable CreateMercy(string PK_Year ,string PK_Student,string targetXML)
        {
            DBObjectPool Pool = null;
            DBObject oDB = null;

            string UniID = clsGetSettings.UniversityID.Trim();
            Hashtable objHT = new Hashtable();
            objHT.Add("pk_Year", PK_Year);
            objHT.Add("Pk_Student_Id", PK_Student);
            objHT.Add("TargetXML", targetXML);

            DataSet ds = new DataSet();
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                SqlCommand cmd = new SqlCommand();
                cmd = oDB.GenerateCommand("Results_Update_ReRegistration_Flag_For_Mercy", objHT);

                if (targetXML != null && targetXML != string.Empty)
                {
                    cmd.Parameters.RemoveAt("@TargetXML");
                    cmd.Parameters.Add("@TargetXML", SqlDbType.Xml);
                    cmd.Parameters["@TargetXML"].Value = targetXML;
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

            if (ds != null && ds.Tables.Count != 0)
                return (ds.Tables[0]);
            else
                return null;
        }
        #endregion
    }



    
} 
