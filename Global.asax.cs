using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Globalization;
using System.Resources;
using System.Threading;
using Classes;

namespace MyNamespace
{
    public class Global : System.Web.HttpApplication
    {
        clsAcademicYear oAcademicYear = new clsAcademicYear();

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }


        protected void Session_Start(object sender, EventArgs e)
        {

            oAcademicYear = new clsAcademicYear();
            oAcademicYear.SetCurrentAcademicFinancialYear();

            //
            //SET HIT COUNTS
            //
            // fnWebsiteHitCounts();

        }


        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            #region commented code


            //string strCulture = "en-US";

            // System.Globalization.CultureInfo[] cultureArr = CultureInfo.GetCultures(CultureTypes.UserCustomCulture);
            //int flag = 1;

            //foreach (CultureInfo cu in cultureArr)
            //{
            //    if (cu.ToString() == strCulture)
            //    {
            //        flag = 0;
            //        break;
            //    }

            //}

            //if (flag == 1)
            //{
               
                //CultureAndRegionInfoBuilder culture = new CultureAndRegionInfoBuilder(strCulture, CultureAndRegionModifiers.None);
                //CultureInfo info = new CultureInfo("en-US");
                //culture.LoadDataFromCultureInfo(info);
                //culture.LoadDataFromRegionInfo(new RegionInfo("en-US"));
                //culture.Parent = info;
                //culture.Register();
            //}

            

            #endregion
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //HttpContext oHttpContext = HttpContext.Current;
            //Exception errr = (Exception)oHttpContext.Server.GetLastError();
            //Exception oEx = null;
            //oEx = errr;
            //while (errr != null)
            //{
            //    errr = errr.InnerException;
            //    if (errr != null && errr.Message.ToString() != string.Empty)
            //    {
            //        oEx = errr;
            //    }
            //}
            //Exception err = (Exception)HttpContext.Current.Error;
            //string error = "<HTML><Body>";
            //while (err != null)
            //{

            //    error = error + "\n\n<font color=#660000><b>Message:: " + DateTime.Now + "</b></font>" + err.Message + "\n<font color=#660000><b> Error Location::</b></font>" + err.TargetSite + "\n <font color=#660000><b>Functions that caused the Error::</b></font><BR>" + err.StackTrace + "\n";
            //    err = err.InnerException;
            //}
            //error = error.Replace("\n", "<BR>");
            //HttpContext.Current.ClearError();
            //error += "</Body></HTML>";
            //try
            //{
            //    System.IO.StreamWriter sw = new System.IO.StreamWriter(Request.PhysicalApplicationPath.ToString() + "Error.html");
            //    //System.IO.StreamWriter sw = new System.IO.StreamWriter(Classes.clsGetSettings.SitePath + "Error.html");
            //    sw.Write(error);
            //    sw.Flush();
            //    sw.Close();
            //    Response.Redirect(Classes.clsGetSettings.SitePath + "onErrorShow.aspx");
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}