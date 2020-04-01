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

namespace StudentRegistration
{
	public class clsStudent
	{

		#region Declare Variables for Qualification details

		/// <summary>
		/// Summary description variables.
		/// </summary>        
		private bool isSSCRecordExist = false;
		private bool isHSCRecordExist = false;
		private bool isDiplomaRecordExist = false;
		private bool isDegreeRecordExist = false;
		private bool isCertificateRecordExist = false;

		#endregion

		#region Declare Variables

		/// <summary>
		/// Summary description variables.
		/// </summary>        
		SqlCommand cmd = new SqlCommand();
		private string pkUniID = string.Empty;
		private string pkYear = string.Empty;
		private string pkStudentID = string.Empty;

		/// <summary>
		/// Combination of Last name FirstName and Middle Name is studentName 
		/// </summary>
		private string studentName = string.Empty;
		private string prnNumber = string.Empty;

		/// <summary>
		/// Combination of universityID,InstituteID,Year,StudentID is eligibilityFormNo
		/// </summary>
		private string eligibilityFormNo = string.Empty;
		private string sDateOfBirth = string.Empty;

		/// <summary>
		/// Eligible,pending,To be decided by University,provisional,Not Eligible is eligibilityStatus
		/// </summary>

		private System.Drawing.Image photograph = null;
		private System.Drawing.Image image = null;

		//
		//checks wether the data is available for student
		//
		private bool isDataAvailable = false;
        private string photoPath = null;
        private string signPath = null;

		#endregion

		#region Student Properties

		///<summary>
		///Student Properties
		///</summary>
		public string UniID
		{
			get
			{
				return pkUniID;
			}
		}

		public string Year
		{
			get
			{
				return pkYear;
			}
		}

		public string StudentID
		{
			get
			{
				return pkStudentID;
			}
		}

		public string StudentName
		{
			get
			{
				return studentName;
			}
		}

		public string PRNNumber
		{
			get
			{
				return prnNumber;
			}
		}

		public string EligibilityFormNo
		{
			get
			{
				return eligibilityFormNo;
			}
		}

		public string DateOfBirth
		{
			get
			{
				return sDateOfBirth;
			}
		}

        //public System.Drawing.Image Photograph
        //{
        //    get
        //    {
        //        return photograph;
        //    }
        //}

        //public System.Drawing.Image Image
        //{
        //    get
        //    {
        //        return image;
        //    }
        //}
        public string PhotoPath { get { return photoPath; } }
        public string SignPath { get { return signPath; } }
		/// <summary>
		/// checks wether data for the student exists
		/// </summary>
		public bool IsDataAvailable
		{
			get
			{
				return isDataAvailable;
			}
		}

		#endregion

		#region Student Properties for qualification details


		public bool IsSSCRecordExist
		{
			get
			{
				return isSSCRecordExist;
			}
		}

		public bool IsHSCRecordExist
		{
			get
			{
				return isHSCRecordExist;
			}
		}

		public bool IsDiplomaRecordExist
		{
			get
			{
				return isDiplomaRecordExist;
			}
		}

		public bool IsDegreeRecordExist
		{
			get
			{
				return isDegreeRecordExist;
			}
		}

		public bool IsCertificateRecordExist
		{
			get
			{
				return isCertificateRecordExist;
			}
		}

		#endregion

		#region Constructor

		///<summary>
		/// Constructor
		///</summary>
		public clsStudent()
		{
		}

		/// <summary>
		/// parameterised constructor
		/// </summary>
		/// <param name="sUniID"></param>       
		/// <param name="sYear"></param>
		/// <param name="sStudentID"></param>
		/// <retuns></retuns>
		public clsStudent(string sUniID, string sYear, string sStudentID)
		{
			pkUniID = sUniID;
			pkYear = sYear;
			pkStudentID = sStudentID;
		}

		/// <summary>
		/// parameterised constructor
		/// </summary>
		/// <param name="sUniID"></param>       
		/// <param name="sYear"></param>
		/// <param name="sStudentID"></param>
		/// <retuns></retuns>
		public clsStudent(string sUniID, string sYear, string sStudentID, bool sLoadPersonalDetails)
		{
			pkUniID = sUniID;
			pkYear = sYear;
			pkStudentID = sStudentID;

			if (sLoadPersonalDetails)
			{
				load();
			}
		}

		#endregion

		#region Load Function(Load All personal details)

		///<summary>
		///private function of load
		///</summary>
		private void load()
		{
			DataTable dt = new DataTable();
			Hashtable oHS = new Hashtable();
			oHS.Add("pk_Uni_ID", pkUniID);
			oHS.Add("pk_Year", pkYear);
			oHS.Add("pk_Student_ID", pkStudentID);

			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				dt = oDB.getparamdataset("REQV2_Load_PersonalDetails", oHS).Tables[0];
				if (dt.Rows.Count > 0)
				{
					studentName = dt.Rows[0]["StudentName"].ToString().Trim();
					prnNumber = dt.Rows[0]["PRNNumber"].ToString().Trim();
					eligibilityFormNo = dt.Rows[0]["EligibilityFormNo"].ToString().Trim();
					sDateOfBirth = dt.Rows[0]["Date_of_Birth"].ToString().Trim();
                    photoPath = dt.Rows[0]["PhotoPath"].ToString().Trim();
                    signPath = dt.Rows[0]["SignPath"].ToString().Trim();

                    //if (dt.Rows[0]["Photograph"] != DBNull.Value)
                    //{
                    //    byte[] Bytes = (byte[])dt.Rows[0]["Photograph"];
                    //    System.IO.Stream s = new System.IO.MemoryStream(Bytes);
                    //    photograph = System.Drawing.Image.FromStream(s);
                    //}
                    //if (dt.Rows[0]["Signature"] != DBNull.Value)
                    //{
                    //    byte[] Bytes1 = (byte[])dt.Rows[0]["Signature"];
                    //    System.IO.Stream sSign = new System.IO.MemoryStream(Bytes1);
                    //    image = System.Drawing.Image.FromStream(sSign);
                    //}

					foreach (DataRow dr in dt.Rows)
					{
						switch (Convert.ToChar(dr["Qualification_Type"]))
						{
							case '1': isSSCRecordExist = true;
								break;
							case '2': isHSCRecordExist = true;
								break;
							case '3': isDiplomaRecordExist = true;
								break;
							case '4': isDegreeRecordExist = true;
								break;
							case '5': isCertificateRecordExist = true;
								break;
							default: isSSCRecordExist = false;
								isHSCRecordExist = false;
								isDiplomaRecordExist = false;
								isDegreeRecordExist = false;
								isCertificateRecordExist = false;
								break;
						}
					}

					isDataAvailable = true;
				}
				else
				{
					isDataAvailable = false;
				}
			}
			catch (SqlException ex)
			{
				throw (ex);
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
		}

		#endregion
		

		#region View Complete profile Function
		/// <summary>
		/// Get student profile and course profile for Cancel Admission
		/// </summary>
		/// <param name="oHS"></param>
		/// <returns></returns>
		public DataSet GetViewStudentDetails(Hashtable oHS)
		{
			DataSet ds = new DataSet();
			//string flag;
			SqlCommand cmd = new SqlCommand();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
                ds = oDB.getparamdataset("ELGV2_CancelAdmission_GetStudentProfile", oHS);
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}

			return ds;
		}
		#endregion

		#region View Complete profile Function
		/// <summary>
		/// Cancel student admission
		/// </summary>
		/// <param name="ht"></param>
		/// <returns>N for Success, Y for Failure, E for Exists in Exam form</returns>
		public string CancelAdmission(Hashtable ht)
		{
			string sReturnData = string.Empty; ;
			SqlCommand cmd = new SqlCommand();
			DBObjectPool Pool = null;
			DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("ErrorOccurred", ParameterDirection.Output);

                //cmd = oDB.GenerateCommand("Elgv2_CancelStudentAdmission", ht);
                cmd = oDB.GenerateCommand("ELGV2_CancelAdmission_CancelAdmission", ht);
                cmd.ExecuteNonQuery();
                sReturnData = cmd.Parameters["@ErrorOccurred"].Value.ToString();                
            }
            catch { sReturnData = ""; }
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}
			return sReturnData;
		}
		#endregion


        public DataSet CancelAdmissionReport(Hashtable oHS)
        {
            DataSet ds = new DataSet();
            //string flag;
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ds = oDB.getparamdataset("ElgV2_Get_AcademicYearWise_CancelAdmission_Log", oHS);
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

            return ds;
        }
        public DataTable GetCollegeCourseStudentDetails(Hashtable oHs)
        {
            DataSet dt = new DataSet();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                dt = oDB.getparamdataset("ElgV2_GetCollegeCourseStudentDetails", oHs);
            }

            catch (SqlException ex)
            {
                throw (ex);
            }

            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt.Tables[0];
        }
        public DataTable GetCDNPath(int CDNID)
        {
            DataTable dt = new DataTable();
            Hashtable oHT = new Hashtable();
            oHT["CDNID"] = CDNID;
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                if (clsGetSettings.UniversityID.Equals("169") || clsGetSettings.UniversityID.Equals("170"))
                    oDB.ThisConnectionFor = DBConnection.OA;
                dt = oDB.getparamdataset("OA_Get_CDNPath", oHT).Tables[0];

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

            return dt;

        }

        public DataTable GetCETDetails(Hashtable oHT)
        {
            DataTable oDT = null;
            DBObjectPool oPool = null;
            DBObject oDB = null;

            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                oDT = oDB.getparamdataset("Elgv2_GetCETDetails", oHT).Tables[0];
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return (oDT);
        }

        public DataTable Get_Student_Details_For_Replace_PRN(string sPRN)
        {
            DataTable oDT = null;
            DBObjectPool oPool = null;
            DBObject oDB = null;

            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                Hashtable oHsReplace = new Hashtable();
                oHsReplace.Add("PRN_Number",sPRN);

                oDT = oDB.getparamdataset("ELGV2_Get_Student_Details_For_Replace_PRN", oHsReplace).Tables[0];
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return (oDT);
        }

        internal string SaveCETDetails(Hashtable oHs)
        {
            DBObjectPool oPool = null;
            DBObject oDB = null;
            SqlCommand oCmd;
            // string[] sRes = new string[3];
            string sRes = string.Empty;

            int iRows = 0;
            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                oCmd = oDB.GenerateCommand("Elgv2_SaveCETDetails", oHs);

                iRows = oCmd.ExecuteNonQuery();
               // if (iRows > 0)
               // {
                    sRes = oCmd.Parameters["@Status"].Value.ToString();
                //}
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return sRes;
        }

        internal int ReplacePRN(string sExistingPRN,string sReplacePRN,string sUser)
        {
            DBObjectPool oPool = null;
            DBObject oDB = null;
            SqlCommand oCmd;
            // string[] sRes = new string[3];
            

            int iRows = 0;
            try
            {
                oPool = DBObjectPool.Instance;
                oDB = oPool.AcquireDBObject();
                Hashtable oHs = new Hashtable();
                oHs.Add("Existing_PRN", sExistingPRN);
                oHs.Add("Replaced_PRN", sReplacePRN);
                oHs.Add("User", sUser);

                oCmd = oDB.GenerateCommand("ELGV2_ReplacePRN", oHs);

                iRows = oCmd.ExecuteNonQuery();

            }
            catch(Exception ex) {
                throw (ex);
            }
            finally
            {
                oPool.ReleaseDBObject(oDB);
            }

            return iRows;
        }
	}
}