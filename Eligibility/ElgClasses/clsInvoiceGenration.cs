using System;
using System.Data;
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
using System.Data.SqlClient;
using System.Collections;

namespace StudentRegistration
{
    public class clsInvoiceGenration
    {

        public DataTable ListAcademicYear(string AcademicYear_ID)
        {
            DataSet ds = new DataSet();
            //string flag;
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            string Uni = clsGetSettings.UniversityID.Trim();
            Hashtable objHT = new Hashtable();

            DataTable dt;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                objHT.Add("pk_AcademicYear_ID", AcademicYear_ID);

                dt = oDB.getparamdataset("ELGV2_Invoice_AcademicYear", objHT).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
            return dt;

        }

        public DataTable REPV2_Invoice_Genration_MonthlyReport(string fk_AcademicYear_ID, string Year, string Month_Id)
        {
            DataSet ds = new DataSet();
            //string flag;
            SqlCommand cmd = new SqlCommand();
            DBObjectPool Pool = null;
            DBObject oDB = null;
           
            Hashtable objHT = new Hashtable();

            DataTable dt;

             try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                objHT.Add("fk_AcademicYear_ID", fk_AcademicYear_ID);
                objHT.Add("Year", Year);
                objHT.Add("Month_Id", Month_Id);

                dt = oDB.getparamdataset("ELGV2_Invoice_Generation_Report", objHT).Tables[0];
            }
             catch (Exception Ex)
             {
                 throw Ex;
             }
             finally
             {
                 Pool.ReleaseDBObject(oDB);
             }
            return dt;

        }

    }
}