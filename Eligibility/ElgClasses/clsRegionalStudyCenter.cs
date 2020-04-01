using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Classes;
using System.Collections;
using System.Data.SqlClient;

namespace Classes
{
	public class clsRegionalStudyCenter
	{
		DataTable dt;
		Hashtable ht;

		/// <summary>
		/// List Regional centers
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable listRegionalCenter()
		{
			dt = new DataTable();
			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				dt = oDB.getdataset("AD_ListRegionalCenter").Tables[0];
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}

			return dt;
		}

		/// <summary>
		/// List Study centers for selected regional center
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable listStudyCenter(string sRegionalCenterID)
		{
			dt = new DataTable();
			ht = new Hashtable();
			ht.Add("RegionalCenterID", sRegionalCenterID);

			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				dt = oDB.getparamdataset("AD_ListStudyCenter", ht).Tables[0];
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}

			return dt;
		}

		/// <summary>
		/// List StudentPhotoSignList
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable FetchAcademicYrCrPrTermWiseStudentList(string AcademicYearID, string UniID, string FacID, string CrID,
												   string MoLrnID, string PtrnID, string BrnID, string CrPrID, string CrPrChID)
		{
			dt = new DataTable();
			ht = new Hashtable();
			ht.Add("AcademicYearID", AcademicYearID);
			ht.Add("UniID", UniID);
			ht.Add("FacID", FacID);
			ht.Add("CrID", CrID);
			ht.Add("MoLrnID", MoLrnID);
			ht.Add("PtrnID", PtrnID);
			ht.Add("BrnID", BrnID);
			ht.Add("CrPrID", CrPrID);
			ht.Add("CrPrChID", CrPrChID);

			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				dt = oDB.getparamdataset("ElgV2_FetchAcademicYrCrPrTermWiseStudentList", ht).Tables[0];
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}

			return dt;
		}

		/*Added by shrikantb on 07102013*/
		public DataTable FetchAcademicYrCrPrTermWiseStudentList(string AcademicYearID, string UniID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string CrPrID, string CrPrChID, string ExamEventID, string InstID)
		{
			dt = new DataTable();
			ht = new Hashtable();
			ht.Add("AcademicYearID", AcademicYearID);
			ht.Add("ExamEventID", ExamEventID);
			ht.Add("UniID", UniID);
			ht.Add("FacID", FacID);
			ht.Add("CrID", CrID);
			ht.Add("MoLrnID", MoLrnID);
			ht.Add("PtrnID", PtrnID);
			ht.Add("BrnID", BrnID);
			ht.Add("CrPrID", CrPrID);
			ht.Add("CrPrChID", CrPrChID);
			ht.Add("InstID", InstID);

			DBObjectPool Pool = null;
			DBObject oDB = null;
			try
			{
				Pool = DBObjectPool.Instance;
				oDB = Pool.AcquireDBObject();
				dt = oDB.getparamdataset("ElgV2_FetchAcademicYrCrPrTermWiseStudentList", ht).Tables[0];
			}
			finally
			{
				Pool.ReleaseDBObject(oDB);
			}

			return dt;
		}
		/********************************/

		#region ListStudentPhotoSignXML

		public string ListStudentPhotoSignXML(string AcademicYearID, string UniID, string FacID, string CrID,
												   string MoLrnID, string PtrnID, string BrnID, string CrPrID, string CrPrChID, string LowerLimit, string UpperLimit)
		{
			DBObjectPool Pool = null;
			Pool = DBObjectPool.Instance;
			DBObject oDB = Pool.AcquireDBObject();
			ht = new Hashtable();
			ht.Add("AcademicYearID", AcademicYearID);
			ht.Add("UniID", UniID);
			ht.Add("FacID", FacID);
			ht.Add("CrID", CrID);
			ht.Add("MoLrnID", MoLrnID);
			ht.Add("PtrnID", PtrnID);
			ht.Add("BrnID", BrnID);
			ht.Add("CrPrID", CrPrID);
			ht.Add("CrPrChID", CrPrChID);
			ht.Add("LowerLimit", LowerLimit);
			ht.Add("UpperLimit", UpperLimit);
			System.Xml.XmlReader oR = null;
			System.Text.StringBuilder oS = new System.Text.StringBuilder();

			try
			{
				SqlCommand cmd = oDB.GenerateCommand("ElgV2_ListStudentPhotoSignXML", ht);
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

		public string ListStudentPhotoSignXML(string AcademicYearID, string UniID, string FacID, string CrID,
												   string MoLrnID, string PtrnID, string BrnID, string CrPrID, string CrPrChID, string LowerLimit, string UpperLimit, string ExamEventID)
		{
			DBObjectPool Pool = null;
			Pool = DBObjectPool.Instance;
			DBObject oDB = Pool.AcquireDBObject();
			ht = new Hashtable();
			ht.Add("AcademicYearID", AcademicYearID);
			//shrikantb on 08102013
			ht.Add("ExamEventID", ExamEventID);
			ht.Add("UniID", UniID);
			ht.Add("FacID", FacID);
			ht.Add("CrID", CrID);
			ht.Add("MoLrnID", MoLrnID);
			ht.Add("PtrnID", PtrnID);
			ht.Add("BrnID", BrnID);
			ht.Add("CrPrID", CrPrID);
			ht.Add("CrPrChID", CrPrChID);
			ht.Add("LowerLimit", LowerLimit);
			ht.Add("UpperLimit", UpperLimit);
			System.Xml.XmlReader oR = null;
			System.Text.StringBuilder oS = new System.Text.StringBuilder();

			try
			{
				SqlCommand cmd = oDB.GenerateCommand("ElgV2_ListStudentPhotoSignXML", ht);
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
	}
}
