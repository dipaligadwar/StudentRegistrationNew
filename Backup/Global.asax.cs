using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Configuration;
using Classes;
using System.Data;
using System.Threading;


namespace StudentRegistration 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		//private System.ComponentModel.IContainer components = null;
		
		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			Application["ConnectionString"] = UniversityPortal.clsGetSettings.ConnectionString;
			//DBObject.ConnectionString = Application["ConnectionString"].ToString();
			
            
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
            DataTable DT = clsAcademicYear.CurrentAcademicYear();
            if (DT.Rows.Count > 0)
            {
                Session["AcademicYearID"] = DT.Rows[0]["pk_AcademicYear_ID"].ToString();
                Session["AcademicYearFrom"] = DT.Rows[0]["Start_Date"].ToString();
                Session["AcademicYearTo"] = DT.Rows[0]["End_Date"].ToString();

                Session["CurrentYearID"] = DT.Rows[0]["AcademicYrID"].ToString();
                Session["CurrentYear"] = DT.Rows[0]["Year"].ToString();

            }

            DT = new DataTable();
            DT = clsFinancialYear.CurrentFinancialYear();
            if (DT.Rows.Count > 0)
            {
                Session["FinYearID"] = DT.Rows[0]["pk_Fin_Year_ID"].ToString();
                Session["FinYearFrom"] = DT.Rows[0]["Fin_Year_From"].ToString();
                Session["FinYearTo"] = DT.Rows[0]["Fin_Year_To"].ToString();
            }

            if (DT != null)
            {
                DT.Dispose();
                DT = null;
            }
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			if(!Response.IsClientConnected)
			{
				Response.End();
			}
			//Response.Write("<Base href="+ System.Configuration.ConfigurationSettings.AppSettings["SitePath"] +">");
			

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
//			Exception err=(Exception)HttpContext.Current.Error;
//
//			string error="";
//			if(err.Message=="")
//			{
//				throw(err);
//			}
//			while(err!=null)
//			{
//				error=error+"\n\n<font color=#660000><b>Message::</b></font>"+err.Message+"\n<font color=#660000><b> Error Location::</b></font>"+err.TargetSite+"\n <font color=#660000><b>Functions that caused the Error::</b></font><BR>"+err.StackTrace+"\n";
//				err=err.InnerException;
//			}
//			error=error.Replace("\n","<BR>");
//			HttpContext.Current.ClearError();
//
//			try
//			{
//				Session["err"]=error;			
//				Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["SitePath"]+"OnErrorShow.aspx");
//			}
//			catch
//			{
//				Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["SitePath"]+"onErrorShow.aspx");
//			}
		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			// 
			// Global
			// 
			this.PreRequestHandlerExecute += new System.EventHandler(this.Global_PreRequestHandlerExecute);
			this.Error += new System.EventHandler(this.Global_Error);

		}
		#endregion

		

		
		public void Page_Load(object sender, System.EventArgs e)
		{
			//			for(int i=0;i<Request.ServerVariables.Count;i++)
			//			{
			//				Response.Write("<BR>"+Request.ServerVariables.Keys[i].ToString()+"="+Request.ServerVariables[i]);
			//			}
            Classes.clsCache.NoCache();

			clsUser user=null;
			string Module=clsMenu.Module_Key(Request.Url);
			string Menu=clsMenu.Menu_Key(Request.Url);
			if(Session["User"]!=null && Session["User"].ToString()!="")
				user=(clsUser)Session["User"];
		
			string obj=Request.QueryString["MenuID"];
			int MenuID=0;
			if(obj!=null && obj.ToString()!="")
			{
				try
				{
					MenuID=Convert.ToInt16(obj);
				}
				catch
				{
							
				}
			}

			if(Menu.ToUpper()!="DEFAULT" && Menu.ToUpper()!="LOGOUT" && Menu.ToUpper()!="ONERRORSHOW" && !clsMenu.isValidMenu(user,Module,Menu,MenuID.ToString()) )
			{
				
				Response.Write(UniversityPortal.clsGetSettings.LogOffMessage);
				Response.End();
			}
		}

		private void Global_PreRequestHandlerExecute(object sender, System.EventArgs e)
		{
//			System.Web.UI.Page page=(System.Web.UI.Page)HttpContext.Current.Handler;
//			if(page!=null)
//			{
//				page.Load+=new EventHandler(Page_Load);
//			}
		}

		private void Global_Error(object sender, System.EventArgs e)
		{
			
			
			
		
		}


	
	}
}

