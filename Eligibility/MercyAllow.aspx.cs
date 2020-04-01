using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Classes;
using System.Threading;
using System.Globalization;
using System.Configuration;
using StudentRegistration.Eligibility.ElgClasses;

namespace StudentRegistration.Eligibility
{

    public partial class MercyAllow : System.Web.UI.Page
    {
        //protected System.Web.UI.HtmlControls.HtmlInputHidden tehsilName;
        string PRNumber = null;
         
        
        DataSet ds;
        //string StrUrl;
        private int pkUniID, pkYear, pkStudentID, Flag;
        private string Elg_FormNo;
        clsCommon Common = new clsCommon();
       
        string QstrNavigate;
        string StrUrl;
        string searchType = "";


        #region User Variables
        public int pk_Uni_ID
        {
            get
            {
                return pkUniID;
            }
            set
            {
                pkUniID = value;
            }
        }
        public int pk_Year
        {
            get
            {
                return pkYear;
            }
            set
            {
                pkYear = value;
            }
        }
        public int pk_Student_ID
        {
            get
            {
                return pkStudentID;
            }
            set
            {
                pkStudentID = value;
            }
        }
        public string ElgFormNo
        {
            get
            {
                return Elg_FormNo;
            }
            set
            {
                Elg_FormNo = value;
            }
        }
        public string PRN
        {
            get
            {
                return PRNumber;
            }
            set
            {
                PRNumber = value;
            }
        }
        //Flag = 0 if PRN wise search is made ,
        //Flag = 1 if PRN is not given search criteria will be on Eligibility Form Number
        public int DisplayFlag
        {
            get
            {
                return Flag;
            }
            set
            {
                Flag = value;
            }
        }      

        #endregion

        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)

        {
           
            clsUser user = new clsUser();
            user = (clsUser)Session["user"];

            string UserRefID = user.UserReferenceID.ToString();
            string UserTypeCode = user.UserTypeCode.ToString();
            Session["UserTypeCode"] = UserTypeCode;


            if (!IsPostBack)
            {
                Session["pkYear"] = "";
                Session["pkStudent_ID"] = "";
            }

        }
        #endregion



        protected void btnSimpleSearch_Click(object sender, EventArgs e)
        {
              DataSet ds;
            ds = clsRegStudent.REG_ProfileSearch_GetStudentIDs(txtPRN.Text.Trim());
            if (ds.Tables.Count > 0)
            {
                Session["pkYear"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Yr"].ToString());
                Session["pkStudent_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["StudID"].ToString());
                Server.Transfer("MercyAllow__1.aspx");
            }
            else
            {
                lblMsg.Text = "Sorry,No matching record found.Please Check later.";
                lblMsg.Style.Remove("display");
                lblMsg.Style.Add("display", "block");
               
            }
           
        }
       
       }
}
