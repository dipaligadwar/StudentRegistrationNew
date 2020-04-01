using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using Classes;

namespace StudentRegistration.Eligibility
{
    public partial class ImportSelectCntPRNList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Hashtable ht = new Hashtable();

                string id = Request.QueryString["IDs"];
               
                ht.Add("SourceTableName", Request.QueryString["hidSourceTableName"]);
                ht.Add("ID", Request.QueryString["IDs"]);
                ht.Add("AcademicYearID", Request.QueryString["hidAcademicYearID"]);

                DataTable dt = new DataTable();
                clsOthers oImportFromExcel = new clsOthers();

                dt = oImportFromExcel.GetImportPRNFromExcelDiscrepancyStudentList(ht);

                GVStudent.DataSource = dt;
                GVStudent.DataBind();
            }
            catch (Exception ex)
            {
                //Response.Redirect(clsGetSettings.SitePath + "Logout.aspx");
            }
        }
    }
}