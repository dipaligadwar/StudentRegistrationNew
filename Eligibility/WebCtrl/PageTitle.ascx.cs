//-----------------------------------------------------------------------
// <copyright file="RegdPageTitle.ascx.cs" company="Know-it">
// Copyright (c)All rights reserved Powered by Maharashtra Knowledge Corporation Ltd.
// </copyright>
// <summary>Page title control.</summary>
//-----------------------------------------------------------------------

namespace StudentRegistration.Eligibility.WebCtrl
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    /// <summary>
    /// RegdPageTitle class.
    /// </summary>
    public partial class PageTitle : System.Web.UI.UserControl
    {
        #region Variable Decleration
       
        private string sStudentName = string.Empty;
        private string sPrnNumber = string.Empty;
        private string sOldPrnNumber = string.Empty;
        #endregion

        #region Properties        

        /// <summary>
        /// Gets or sets student name.
        /// </summary>
        /// <value>Contains student name.</value>
        public string StudentName
        {
            get
            {
                return sStudentName;
            }

            set
            {
                sStudentName = value;
            }
        }

        /// <summary>
        /// Gets or sets student prn number.
        /// </summary>
        /// <value>Contains prn number.</value>
        public string PrnNumber
        {
            get
            {
                return sPrnNumber;
            }

            set
            {
                sPrnNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets student prn number.
        /// </summary>
        /// <value>Contains prn number.</value>
        public string OldPrnNumber
        {
            get
            {
                return sOldPrnNumber;
            }

            set
            {
                sOldPrnNumber = value;
            }
        }

        #endregion

        #region Page Load
        /// <summary>
        /// Page load event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (sOldPrnNumber != string.Empty && sOldPrnNumber != "Not Available")
            {
                lblpageheader.Text = " <B>Student Name: </B>" + sStudentName + ", <B>" + (string)GetLocalResourceObject("PRN") + ": </B>" + sPrnNumber +", <B> Old " +(string)GetLocalResourceObject("PRN") + ": </B>" + sOldPrnNumber;            
            }
            else if (sPrnNumber != string.Empty)
            {
                lblpageheader.Text = " <B>Student Name: </B>" + sStudentName + ", <B>" + (string)GetLocalResourceObject("PRN") + ": </B>" + sPrnNumber;            
            }
            else
            {
                lblpageheader.Text = "<B>Student Name: </B>" + sStudentName;
            }            
        }
        #endregion
    }
}