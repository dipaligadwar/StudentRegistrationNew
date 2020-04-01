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
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Net;
using DUConfigurations;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_BulkProcess__2 : System.Web.UI.Page
    {
        string ElgFormNo = "";
        clsCache clsCache = new clsCache();
        CDN oCDNKeys = clsDUConfigurations.Instance.CDNKeys;
        clsCDN objCDN = null;
        string sPathExists = string.Empty;
       

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            clsCache.NoCache();
            string sElgFormNo = Request.QueryString["ElgFormNo"].ToString();      
            string sUniID = Request.QueryString["UniID"].ToString();
            string sYear = Request.QueryString["Year"].ToString();
            string sInstID = Request.QueryString["InstID"].ToString();
            string sStudID = Request.QueryString["StudID"].ToString();

            hidElgFormNo.Value = sElgFormNo;
            ElgFormNo = sElgFormNo;
            hidUniID.Value = sUniID;
            hidpkYear.Value = sYear;
            hidpkStudentID.Value = sStudID;
            hidFacID.Value = Request.QueryString["FacID"].ToString();
            hidCrID.Value = Request.QueryString["CrID"].ToString();
            hidMoLrnID.Value = Request.QueryString["MoLrnID"].ToString();
            hidPtrnID.Value = Request.QueryString["PtrnID"].ToString();
            hidBrnID.Value = Request.QueryString["BrnID"].ToString();
            hidCrPrID.Value = Request.QueryString["CrPrDetailsID"].ToString();
            FetchStudentDetails();
            btnClose.Attributes.Add("onclick", " return closewindow();");
        }

        #endregion

        #region InitializeCulture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }
        #endregion

        #region Function FetchStudentDetails

        public void FetchStudentDetails()
        {
            DataSet ds = new DataSet();
            string[] RefIDarr = new string[4];
            RefIDarr = ElgFormNo.Split('-');
            try
            {                
                ds = elgDBAccess.IA_Fetch_Student_Details_BulkInsert(hidUniID.Value, hidpkStudentID.Value, hidpkYear.Value, Classes.clsGetSettings.UniversityID.ToString(), RefIDarr[1], RefIDarr[2], RefIDarr[3], hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, hidCrPrID.Value);

                if (ds.Tables[2].Rows.Count > 0)
                {
                    lblNameAsMarksheet.Text = ds.Tables[2].Rows[0]["Name_QualExamMarkSheet"].ToString();
                    lblNameOfStudent.Text = ds.Tables[2].Rows[0]["Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Middle_Name"].ToString();
                    lblMothersMaidenName.Text = ds.Tables[2].Rows[0]["Mother_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Mother_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Mother_Middle_Name"].ToString();
                    lblFathersName.Text = ds.Tables[2].Rows[0]["Father_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Father_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Father_Middle_Name"].ToString();
                    if (ds.Tables[2].Rows[0]["Changed_Name_Flag"].ToString() == "1")
                    {
                        lblPreviousName.Text = ds.Tables[2].Rows[0]["Prev_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Prev_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Prev_Middle_Name"].ToString();
                    }
                    lblGender.Text = ds.Tables[2].Rows[0]["Gender_Desc"].ToString();
                    lblDOB.Text = ds.Tables[2].Rows[0]["DOB"].ToString();                   //Gender,Date_of_Birth,Changed_Name_Reason
                    lblNationality.Text = ds.Tables[2].Rows[0]["Nationality"].ToString();
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    lblDomicileState.Text = ds.Tables[3].Rows[0]["Domicile_of_State"].ToString();
                    lblResvCategory.Text = ds.Tables[3].Rows[0]["Category"].ToString();
                    if (ds.Tables[3].Rows[0]["Category_Flag"].ToString() == "1")
                    {
                        if (ds.Tables[3].Rows[0]["ResvCategory"].ToString() != "")
                        {
                            lblResvCategory.Text += " (" + ds.Tables[3].Rows[0]["ResvCategory"].ToString();
                            if (ds.Tables[3].Rows[0]["SubCaste"].ToString() != "")
                                lblResvCategory.Text += " - " + ds.Tables[3].Rows[0]["SubCaste"].ToString();
                            lblResvCategory.Text += ")";
                        }
                    }
                    if (ds.Tables[3].Rows[0]["Physically_Challenged_Flag"].ToString() == "1")
                        lblPhyChlngd.Text = ds.Tables[3].Rows[0]["PhysicallyChallenged"].ToString();
                    else
                        lblPhyChlngd.Text = "     -";
                    lblAdmittedCategory.Text = ds.Tables[3].Rows[0]["AdmittedCategory"].ToString();
                    lblGuardianincome.Text = "Rs. " + ds.Tables[3].Rows[0]["Guardian_Annual_Income"].ToString();
                    lblGuardianOccupation.Text = ds.Tables[3].Rows[0]["GuardOccupation"].ToString();
                }

                if (ds.Tables[4].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                    {
                        lblSocResv.Text += ds.Tables[4].Rows[i]["SocialReservation_Description"].ToString();
                        if (i < (ds.Tables[4].Rows.Count - 1))
                            lblSocResv.Text += ", ";
                    }
                }

                if (ds.Tables[5].Rows.Count > 0)
                {
                    DGQualification1.DataSource = ds.Tables[5];
                    DGQualification1.DataBind();
                }

                if (ds.Tables[6].Rows.Count > 0)
                {
                    DGSubmittedDocs1.DataSource = ds.Tables[6];
                    DGSubmittedDocs1.DataBind();
                }
                else
                {
                    lblDoctext.Text = "No documents submitted.";
                    lblDoctext.Visible = true;
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblInstName.Text = ds.Tables[0].Rows[0]["RefInstName"].ToString();
                    lblEligibilityFormNo.Text = hidElgFormNo.Value;
                    TblAdmission.Style.Remove("display");
                    TblAdmission.Style.Add("display", "block");
                    divTblElgFormdetails.Style.Remove("display");
                    divTblElgFormdetails.Style.Add("display", "block");

                    lblAdmissionDate.Text = ds.Tables[0].Rows[0]["Admission_Date"].ToString();
                    lblAppFormNo.Text = ds.Tables[0].Rows[0]["Admission_Form_No"].ToString();
                    lblCourse.Text = ds.Tables[0].Rows[0]["Course"].ToString();// +"-" + ds.Tables[0].Rows[0]["CrPrAbbr"].ToString(); 

                }
                //Modified as per Req 102312  By Deepak Omar                     
                //Image1.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[2].Rows[0]["PhotoPath"].ToString();//"ELGV2_BulkProcess__3.aspx?img=PR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
                Image1.Visible = true;
                //Image2.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[2].Rows[0]["SignPath"].ToString();//"ELGV2_BulkProcess__3.aspx?img=SR&sStudentDetails=" + hidpkYear.Value + "-" + hidpkStudentID.Value;
                Image2.Visible = true;
                if (oCDNKeys != null)
                {
                    objCDN = new clsCDN(oCDNKeys.PhotoSignKey);
                    sPathExists = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[2].Rows[0]["PhotoPath"])) ? "Y" : "N";
                    Image1.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(ds.Tables[2].Rows[0]["PhotoPath"]), sPathExists, "P");
                    sPathExists = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[2].Rows[0]["SignPath"])) ? "Y" : "N";
                    Image2.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(ds.Tables[2].Rows[0]["SignPath"]), sPathExists, "S");  
                }                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                throw new Exception(ex.Message);
            }

            ds.Dispose();
        }

        #endregion     

        #region DGSubmittedDocs1_RowDataBound
        protected void DGSubmittedDocs1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Style.Add("display", "none");
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[5].Style.Add("display", "none");
            }
            if ((e.Row.RowType != DataControlRowType.Header) && (e.Row.RowType != DataControlRowType.Footer) && (e.Row.RowType != DataControlRowType.Pager))
            {
                e.Row.Cells[2].Text = "Recvd (Valid)";
            }

        }
        #endregion
        
    }
}
#region Commented Code

//HttpWebRequest URLReq;
//HttpWebResponse URLRes;
//if (!string.IsNullOrEmpty(ds.Tables[2].Rows[0]["PhotoPath"].ToString()))
//{
//    try
//    {
//        URLReq = (HttpWebRequest)WebRequest.Create(dtRow["Download_Path"].ToString() + ds.Tables[2].Rows[0]["PhotoPath"].ToString());
//        URLRes = (HttpWebResponse)URLReq.GetResponse();
//        if (URLRes == null)
//        {
//            Image1.ImageUrl = dtRow["Download_Path"].ToString() + "NoPhoto.JPG";
//        }
//        else
//        {
//            if (URLRes.StatusCode == HttpStatusCode.OK)
//            {
//                Image1.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[2].Rows[0]["PhotoPath"].ToString();
//            }
//            else
//            {
//                Image1.ImageUrl = dtRow["Download_Path"].ToString() + "NoPhoto.JPG";
//            }
//        }
//        URLRes.Close();
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//}
//else
//{
//    Image1.ImageUrl = dtRow["Download_Path"].ToString() + "NoPhoto.JPG";
//}


//if (!string.IsNullOrEmpty(ds.Tables[2].Rows[0]["SignPath"].ToString()))
//{
//    try
//    {
//        URLReq = (HttpWebRequest)WebRequest.Create(dtRow["Download_Path"].ToString() + ds.Tables[2].Rows[0]["SignPath"].ToString());
//        URLRes = (HttpWebResponse)URLReq.GetResponse();
//        if (URLRes == null)
//        {
//            Image2.ImageUrl = dtRow["Download_Path"].ToString() + "NoSign.JPG";
//        }
//        else
//        {
//            if (URLRes.StatusCode == HttpStatusCode.OK)
//            {
//                Image2.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[2].Rows[0]["SignPath"].ToString();//"PhotoSignHandler.ashx?img=Photo&UniID=" + Convert.ToString(Row["pk_Uni_ID"]) + "&StudentID=" + Convert.ToString(Row["pk_Student_ID"]) + "&YearID=" + Convert.ToString(Row["pk_Year"]);
//            }
//            else
//            {
//                Image2.ImageUrl = dtRow["Download_Path"].ToString() + "NoSign.JPG";
//            }
//        }
//        URLRes.Close();
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//}
//else
//{
//    Image2.ImageUrl = dtRow["Download_Path"].ToString() + "NoSign.JPG";
//}
//Image2.Visible = true;
#endregion