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
using StudentRegistration.Eligibility.ElgClasses;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using DUConfigurations;


namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_DownloadPhotoSign : System.Web.UI.Page
    {
        #region User Defined Variables

        DataTable oDT = null;
        clsRegionalStudyCenter oRegionalStudyCenter = null;
        FastZip oFastZip = new FastZip();
        FileStream oFileStream = null;

        CDN oCDNKeys = clsDUConfigurations.Instance.CDNKeys;

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
            if (!IsPostBack)
            {
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
            }
            //
            // Hide not required portions of the user control
            //
            YCMOU.IsInstituteDisplay = true;
            YCMOU.IsReportUserAndDateDisplay = false;
			//((HtmlGenericControl)YCMOU.FindControl("divRegionalCenter")).Visible = false;
			//((HtmlGenericControl)YCMOU.FindControl("divStudyCenter")).Visible = false;
            YCMOU.OnProceedClick += new WebCtrl.SingleCourseProceedClick(YCMOU_OnProceedClick);
            //YCMOU.OnProceedClick += new SingleCourseProceedClick(YCMOU_OnProceedClick);
        }
        #endregion

        #region YCMOU_OnProceedClick
        protected void YCMOU_OnProceedClick(object sender, EventArgs e)
        {
            oRegionalStudyCenter = new clsRegionalStudyCenter();
            hidAcademicYearID.Value = YCMOU.AcademicYearID;
            /*added by shrikantb on 07102013*/
            hidExamEventID.Value = YCMOU.ExamEventID;
            hidFacID.Value = YCMOU.FacultyID;
            hidCrID.Value = YCMOU.CourseID;
            hidMoLrnID.Value = YCMOU.ModeLrnID;
            hidPtrnID.Value = YCMOU.PatternID;
            hidBrnID.Value =  YCMOU.BranchID;
            hidCrPrDetailsID.Value = YCMOU.PartID;
            hidCrPrChID.Value =  YCMOU.TermID;

            hidFacName.Value = YCMOU.FacultyName;
            string CourseName = YCMOU.CourseName;
            hidCrName.Value = CourseName.Split('-')[0].ToString().Trim();
            hidMoLrnName.Value = CourseName.Split('-')[1].ToString().Trim();
            hidPtrnName.Value = CourseName.Split('-')[2].ToString().Trim();
            hidBrnName.Value = YCMOU.BranchName;
            hidCrPrName.Value = YCMOU.PartName;
            hidCrPrChName.Value = YCMOU.TermName;

            
            /*oDT = oRegionalStudyCenter.FetchAcademicYrCrPrTermWiseStudentList(YCMOU.AcademicYearID, hidUniID.Value,
                                                                              YCMOU.FacultyID, YCMOU.CourseID, YCMOU.ModeLrnID,
                                                                              YCMOU.PatternID, YCMOU.BranchID, YCMOU.PartID,
                                                                              YCMOU.TermID); by shrikantb on 07102013*/

            oDT = oRegionalStudyCenter.FetchAcademicYrCrPrTermWiseStudentList(YCMOU.AcademicYearID, hidUniID.Value,
                                                                              YCMOU.FacultyID, YCMOU.CourseID, YCMOU.ModeLrnID,
                                                                              YCMOU.PatternID, YCMOU.BranchID, YCMOU.PartID,
                                                                              YCMOU.TermID,YCMOU.ExamEventID, YCMOU.InstID);

            divGridView.Style.Add("display", "block");
            divYCMOU.Style.Add("display", "none");

            string totalDataAvailable = oDT.Rows.Count.ToString();

            if (oDT != null && oDT.Rows.Count > 0)
            {
                oDT = SetLinks(oDT);

                gvStudentCountLinks.DataSource = oDT;
                gvStudentCountLinks.DataBind();
                lblTotalData.Text += " " + totalDataAvailable;
                lblErrorMsg.Visible = false;
                lblTotalData.Visible = true;
            }
            else
            {
                lblErrorMsg.Visible = true;
                lblTotalData.Visible = false;
                lblErrorMsg.Text = "No Students Found.";
                lblErrorMsg.CssClass = "errorNote";
                lblErrorMsg.Style.Add("text-align", "center");
            }
            string strTitle = string.Empty;
            if (YCMOU.AcademicYearID != null)
                strTitle = ((DropDownList)YCMOU.FindControl("ddlAcadYear")).SelectedItem.Text;
            else
                strTitle = ((DropDownList)YCMOU.FindControl("ddlExEvent")).SelectedItem.Text;
            lblwelcome.Text = " for " + strTitle + "-" +
                              hidFacName.Value + "-" + CourseName + hidBrnName.Value + "-" + hidCrPrName.Value + "-" + hidCrPrChName.Value;

        }
        #endregion

        #region SetLinks

        public DataTable SetLinks(DataTable oDT)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            DataRow oDr;

            int lowerLimit = 1;
            int batchSize = 2000;
            int upperLimit = (int)oDT.Rows.Count / batchSize;
            if (upperLimit == 0) upperLimit = lowerLimit;            
            int index = 0, startCnt = 0, endCnt = 0;

            for (int i = lowerLimit; i <= upperLimit; i = i + 1)
            {
                startCnt = (index * batchSize) + 1;
                endCnt = (index * batchSize) + batchSize;

                oDr = dt.NewRow();
                if (i == upperLimit)
                    oDr["Text"] = Convert.ToString(startCnt) + "-" + Convert.ToString(oDT.Rows.Count);
                else
                    oDr["Text"] = Convert.ToString(startCnt) + "-" + Convert.ToString(endCnt);
                dt.Rows.Add(oDr);                
                index = i;
            }
            return dt;
        }

        #endregion

        #region gvStudentCountLinks_RowCommand
       
        protected void gvStudentCountLinks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdGenerateXML"))
            {
                oRegionalStudyCenter = new clsRegionalStudyCenter();
                string PhotoSignXml = string.Empty;

                GridView gv = (GridView)sender;
                int index = Convert.ToInt32(e.CommandArgument);
                string LowerLimit = gv.DataKeys[index]["Text"].ToString().Split('-')[0];
                string UpperLimit = gv.DataKeys[index]["Text"].ToString().Split('-')[1];
               
                int RowIndex = index +1;

                string sFileName = hidUniID.Value + "_" + hidAcademicYearID.Value + "_" +
                                   hidCrName.Value + "_" + hidMoLrnName.Value + "_" + hidPtrnName.Value + "_" + hidBrnName.Value + "_" +
                                   hidCrPrName.Value + "_" + hidCrPrChName.Value + "_" + RowIndex.ToString();


                char[] charNotAllowed = { '/', '\\', '*', '?', '"', '<', '>', '|', ':'};

                for (int icharCount = 0; icharCount < charNotAllowed.Length; icharCount++)
                {
                    sFileName = sFileName.Replace(charNotAllowed[icharCount], '_');
                }
                sFileName = sFileName.Replace(" ", string.Empty);           

                string sDestination = Server.MapPath(".\\TempDirectory\\");

              
                PhotoSignXml = oRegionalStudyCenter.ListStudentPhotoSignXML(hidAcademicYearID.Value, hidUniID.Value,
                                                                              hidFacID.Value, hidCrID.Value, hidMoLrnID.Value,
                                                                              hidPtrnID.Value, hidBrnID.Value, hidCrPrDetailsID.Value,
                                                                              hidCrPrChID.Value,LowerLimit,UpperLimit,hidExamEventID.Value);

                //************************************ CDN related changes ******************************
                clsCDN objCDN = new clsCDN();
                string BusinessUnitId, PIdDC, Relative_Path, Upload_Path;
                string DownloadZipServicePath;
                //DataTable oDtCDNConf = cdnConf.GetCDNKeys();

                if (oCDNKeys != null)
                {
                    DataRow dtRow = objCDN.GetCDNKeys(oCDNKeys.PhotoSignKey);
                    if (dtRow != null)
                    {
                        BusinessUnitId = Convert.ToString(dtRow["BusinessUnitId"]);
                        PIdDC = Convert.ToString(dtRow["PIdDC"]);
                        Relative_Path = Convert.ToString(dtRow["Relative_Path"]);
                        Upload_Path = Convert.ToString(dtRow["Upload_Path"]); //+ "uploadBase64AndGetId";

                        DownloadZipServicePath = Upload_Path + "downloadZipFile";

                        StringBuilder CDNKeys = new StringBuilder("<CDNXML><CDNKeys>");
                        CDNKeys.Append("<BusinessUnitId>");
                        CDNKeys.Append(BusinessUnitId);
                        CDNKeys.Append("</BusinessUnitId>");

                        CDNKeys.Append("<PIdDC>");
                        CDNKeys.Append(PIdDC);
                        CDNKeys.Append("</PIdDC>");

                        CDNKeys.Append("<Relative_Path>");
                        CDNKeys.Append(Relative_Path);
                        CDNKeys.Append("</Relative_Path>");

                        CDNKeys.Append("<DownloadZipServicePath>");
                        CDNKeys.Append(DownloadZipServicePath);
                        CDNKeys.Append("</DownloadZipServicePath>");

                        CDNKeys.Append("</CDNKeys>");

                        // BusinessUnitId, PIdDC, Relative_Path, DownloadZipServicePath

                        PhotoSignXml = CDNKeys.ToString() +  PhotoSignXml + "</CDNXML>";

                    }

                    
                }

                //***************************************************************************************

                if (!Directory.Exists(sDestination))
                {
                    Directory.CreateDirectory(sDestination);
                }
               
                string outputFile = sDestination + sFileName + ".zip";
                string inputFile = sDestination + sFileName + ".xml";
                string sPassword = "MKCL123";

                DeleteZipFiles(sDestination, sFileName);

                try 
                {
                    UTF8Encoding encoding = new UTF8Encoding();
                    Byte[] byteArray = encoding.GetBytes(PhotoSignXml);
                   
                    oFileStream = new FileStream(inputFile, FileMode.Create, FileAccess.Write);
                    oFileStream.Write(byteArray, 0, byteArray.Length);
                    oFileStream.Close();
                    oFastZip.CreateZip(inputFile,outputFile,sPassword);
                }
                catch(Exception ex)
                {
                    lblErrorMsg.Text = ex.Message.ToString();
                }
               
            }
        }
        #endregion

        #region Delete Previous zip files if exists
        public void DeleteZipFiles(string strFolderPath,string sFileName)
        {
            if (Directory.Exists(strFolderPath))
            {
                DirectoryInfo di = new DirectoryInfo(strFolderPath);
                FileInfo[] fi = di.GetFiles("*.zip");
                string newFileName = sFileName + ".zip";
                foreach (FileInfo ff in fi)
                {
                    try
                    {
                        if (ff.Name == newFileName)
                        {
                            ff.Delete();
                        }
                    }
                    catch (Exception ex)
                    {
                        lblErrorMsg.Text = ex.Message.ToString();
                    }
                }
            }
        }
        #endregion       

    }
}
