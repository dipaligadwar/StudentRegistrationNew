using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Classes;
using System.Net;
using DUConfigurations;


namespace StudentRegistration.Eligibility.WebCtrl
{
    public partial class ShowStudentPhoto : System.Web.UI.UserControl
    {
        #region Variable Declaration
        clsStudent oStudent;

        private string uniID = clsGetSettings.UniversityID;     
        private string yearID = string.Empty;
        private string studentID = string.Empty;
        CDN oCDNKeys = clsDUConfigurations.Instance.CDNKeys;
        clsCDN objCDN = null;
        string sPathExists = string.Empty;
        #endregion

        #region Set Properties

        /// <summary>
        /// Gets or sets University ID.
        /// </summary>
        /// <value>University id.</value>
        public string UniID
        {
            get
            {
                return uniID;
            }

            set
            {
                uniID = value;
            }
        }
        

        /// <summary>
        /// Gets or sets the YearID.
        /// </summary>
        /// <value>Current year.</value>
        public string YearID
        {
            get
            {
                return yearID;
            }

            set
            {
                yearID = value;
            }
        }

        /// <summary>
        /// Gets or sets the Student ID.
        /// </summary>
        /// <value>Student id.</value>
        public string StudentID
        {
            get
            {
                return studentID;
            }

            set
            {
                studentID = value;
            }
        }
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
			//if (!IsPostBack)
			//{
                showPhotograph();
			//}
        }

        #region show photo
        /// <summary>
        /// This function is used to display the photograph .
        /// </summary>
        private void showPhotograph()
        {
            oStudent = new clsStudent(UniID,YearID, StudentID,true);
            DataTable dt = new DataTable();

            if (oCDNKeys != null)
            {
                objCDN = new clsCDN(oCDNKeys.PhotoSignKey);
                sPathExists = !string.IsNullOrEmpty(Convert.ToString(oStudent.PhotoPath)) ? "Y" : "N";
                ImgPhoto.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(oStudent.PhotoPath), sPathExists, "P");
                ImgPhoto.Visible = true;
            }

            //if (oStudent.PhotoPath != null)
            //{
            //    ImgPhoto.ImageUrl = dtRow["Download_Path"].ToString() + oStudent.PhotoPath;//"..\\PhotoSignTemp.ashx?QS_Student_ID=" + StudentID + "&img=Photo&Year=" + YearID;
            //    ImgPhoto.Visible = true;
            //    DivNoPhoto.Visible = false;
            //}
            //else
            //{
            //    DivNoPhoto.Visible = true;
            //    ImgPhoto.Visible = false;
            //}            
        }
        #endregion       
    }
}