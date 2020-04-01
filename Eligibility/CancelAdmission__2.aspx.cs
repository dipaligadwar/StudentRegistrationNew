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
using DPTemplate2;
//using Newtonsoft.Json;
using System.Net;
using DUConfigurations;
using System.IO;

namespace StudentRegistration.Eligibility
{
	public partial class CancelAdmission__2 : System.Web.UI.Page
	{
		#region Declaration Of variables
		clsStudent oViewStudent;
		DataSet oDataSet;
		Hashtable oHashTable;
		clsCommon oCommon = new clsCommon();
		clsCache oCache = new clsCache();
        DataTable crTable = new DataTable();
        string uniID = string.Empty;
        string year = string.Empty;
        string studentID = string.Empty;
        CDN oCDNKeys = clsDUConfigurations.Instance.CDNKeys;
        clsCDN objCDN = null;
        string sPathExists = string.Empty;
		#endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            oCache.NoCache();

            #region Set default values in Hidden Variable if any
            HtmlInputHidden[] hid = new HtmlInputHidden[8];
            hid[0] = hid_pk_Uni_ID;
            hid[1] = hid_pk_Year;
            hid[2] = hid_pk_Student_ID;
            hid[3] = hid_Stud_Name;
            hid[4] = hid_OldPRN;
            hid[5] = hid_PRN_Number;
            hid[6] = hid_eligiblityFN;
            hid[7] = hid_Inst_Details;
            oCommon.setHiddenVariablesMPC(ref hid);
            #endregion

            lblPageHead.Text = "Cancel Admission";

            #region Set Cancel Admission Info
            string crRes = (string)GetLocalResourceObject("lblCrResource1.Text");
            string strInfo = "\"CANCEL ADMISSION\" will cancel the selected ";
            strInfo += crRes + " Part Term of the student whose Seat Number is not generated. Only the latest Term of the ";
            strInfo += crRes + " will have the \"Cancel Admission\" link. Those student whose all the " + crRes;
            strInfo += "s have been cancelled will be listed for Student Profile Deletion in \"Delete Dangling Students\" link. The Student Profile can be deleted from there.";
            lblCAInfo.Text = strInfo;
            #endregion

            if (!IsPostBack)
            {
                DisplayStudentDetails();
            }
        }
        #endregion

        #region Student Details
        private void DisplayStudentDetails()
		{
            oViewStudent = new clsStudent();
            oDataSet = new DataSet();
            oHashTable = new Hashtable();
            oHashTable["UniID"] = clsGetSettings.UniversityID;
            oHashTable["StudentID"] = hid_pk_Student_ID.Value;
            oHashTable["Year"] = hid_pk_Year.Value;

            oDataSet = oViewStudent.GetViewStudentDetails(oHashTable);
			RenderTable(oDataSet);
		}
        #endregion

        #region Render Table
        /// <summary>
		/// Rendering profile details
		/// </summary>
		/// <param name="studDs"></param>
		private void RenderTable(DataSet studDs)
		{
			#region "Reset Tables"
            ResetTable(TBLSummery);
            #endregion

			#region Summary
			//
			//Add columns to table Summary
			//
			TableCell oTD = null;
			foreach (DataRow Row in studDs.Tables[0].Rows)
			{
				foreach (DataColumn Field in studDs.Tables[0].Columns)
				{
					switch (Field.ColumnName)
					{
						case "PRN":
							oTD = new TableCell();
							oTD.CssClass = "clOn";
							oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
							oTD.Attributes.Add("id", Row["Student_ID"].ToString());
							TBLSummery.Rows[0].Cells.Add(oTD);
							break;
						case "Student_Name":
							oTD = new TableCell();
							oTD.CssClass = "clOn";
							oTD.Text = "<div>" + Convert.ToString(Row[Field.ColumnName]) + "</div>";
							oTD.Attributes.Add("id", Row["Student_ID"].ToString());
							TBLSummery.Rows[1].Cells.Add(oTD);
							break;
						case "Photosign":                         
							oTD = new TableCell();
							oTD.CssClass = "clOn";
							oTD.VerticalAlign = VerticalAlign.Middle;                        
							System.Web.UI.WebControls.Image oPhoto = new System.Web.UI.WebControls.Image();
							oPhoto.ID = "imgPhoto" + Row["Student_ID"].ToString();
                            System.Web.UI.WebControls.Image oSign = new System.Web.UI.WebControls.Image();
                            oSign.ID = "imgSign" + Row["Student_ID"].ToString();
                            //Modified as per Req 102312
                            if (oCDNKeys != null)
                            {
                                objCDN = new clsCDN(oCDNKeys.PhotoSignKey);
                                sPathExists = !string.IsNullOrEmpty(Convert.ToString(Row["PhotoPath"])) ? "Y" : "N";
                                oPhoto.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(Row["PhotoPath"]), sPathExists, "P");
                                sPathExists = !string.IsNullOrEmpty(Convert.ToString(Row["SignPath"])) ? "Y" : "N";
                                oSign.ImageUrl = objCDN.PhotoSignDisplay(Convert.ToString(Row["SignPath"]), sPathExists, "S");                             
                            }						
							oPhoto.CssClass = "cssImage";
							//oSign.ImageUrl = dtRow["Download_Path"].ToString() + Row["SignPath"].ToString();//"PhotoSignHandler.ashx?img=Sign&UniID=" + Convert.ToString(Row["pk_Uni_ID"]) + "&StudentID=" + Convert.ToString(Row["pk_Student_ID"]) + "&YearID=" + Convert.ToString(Row["pk_Year"]);
							oSign.CssClass = "cssImage";
							oTD.Controls.Add(oPhoto);
							oTD.Controls.Add(oSign);
							oTD.Attributes.Add("id", Row["Student_ID"].ToString());
							TBLSummery.Rows[2].Cells.Add(oTD);
							break;
                        default: break;
					}
				}
			}
			#endregion

            #region Course
            if (studDs.Tables[1] != null && studDs.Tables[1].Rows.Count > 0)
            {
                RptCourse.DataSource = studDs.Tables[1];
                RptCourse.DataBind();
                divCourseProfile.Visible = true;
                divCourse.Visible = true;
                hid_Term_Count.Value = studDs.Tables[1].Rows.Count.ToString();
            }
            else
            {
                divCourseProfile.Visible = false;
                divCourse.Visible = false;
            }
            #endregion
        }
		#endregion

		#region Reset table
		/// <summary>
		/// Clear the tables
		/// </summary>
		/// <param name="oDT"></param>
		private void ResetTable(Table oDT)
		{
			for (int it = 0; it < oDT.Rows.Count; it++)
			{
				int iCellCount = oDT.Rows[it].Cells.Count;

				for (int i = iCellCount - 1; i >= 1; i--)
				{
					oDT.Rows[it].Cells.RemoveAt(i);
				}
			}
		}
		#endregion

        #region Item data bound event of Repeater
        /// <summary>
        /// Repeater item data bound event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event argument.</param>
        protected void RptCourse_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                if ((e.Item.ItemIndex - 1) > -1)
                {
                    string sName = Convert.ToString(oDataSet.Tables[1].Rows[e.Item.ItemIndex]["CourseName"]);
                    string bShow = "Y";

                    // This will display course name only once against all its course part.  
                    if (sName == Convert.ToString(oDataSet.Tables[1].Rows[e.Item.ItemIndex - 1]["CourseName"]))
                    {
                        e.Item.FindControl("trHeader").Visible = false;
                        e.Item.FindControl("tdHeader").Visible = false;
                        e.Item.FindControl("separator").Visible = false;
                    }
                    else
                    {
                        bShow = "N";
                    }

                    if (e.Item.ItemIndex > 0)
                    {
                        LinkButton lb = (LinkButton)e.Item.FindControl("btnDel");
                        lb.Attributes.Add("onclick", "javascript:return ShowConfirmBox('" + lb.UniqueID + "', '" + Convert.ToString(oDataSet.Tables[1].Rows[e.Item.ItemIndex]["CrTermCount"]) + "');");
                    }

                    if (e.Item.ItemIndex != 0 && bShow == "Y")
                    {
                        ((LinkButton)e.Item.FindControl("btnDel")).Visible = false;
                        ((TextBox)e.Item.FindControl("txtReasonforCancellation")).Visible = false;
                    }

                    // This will display separator between each course.
                    if (sName != Convert.ToString(oDataSet.Tables[1].Rows[e.Item.ItemIndex - 1]["CourseName"]))
                    {
                        e.Item.FindControl("separator").Visible = true;
                    }
                }

                if (e.Item.ItemIndex == 0)
                {
                    try
                    {
                        LinkButton lb = (LinkButton)e.Item.FindControl("btnDel");                       
                        lb.Attributes.Add("onclick", "javascript:return ShowConfirmBox('" + lb.UniqueID + "', '" + Convert.ToString(oDataSet.Tables[1].Rows[e.Item.ItemIndex]["CrTermCount"]) + "');");
                    }
                    catch { }
                }
            }
        }
        #endregion

        #region Grid Events
        protected void RptCourse_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "CancelAdm")
            {
                if (e.CommandArgument.ToString() != string.Empty)
                {
                    string txtCancelReason=((TextBox)((Repeater)(source)).Items[e.Item.ItemIndex].FindControl("txtReasonforCancellation")).Text;
                    CancelStudentAdmission(e.CommandArgument.ToString(), txtCancelReason);
                }
            }
        }
        #endregion

        #region Other Functions
        void CancelStudentAdmission(string UniStudID, string sCancelReason)
        {
            string[] StudentIDs = UniStudID.Split('|');
            string sResult = string.Empty;
            //string sISDirectAdmission = string.Empty;
            Classes.clsUser user = (Classes.clsUser)Session["User"];

            Hashtable oHt = new Hashtable();
            oHt["pk_Uni_ID"] = StudentIDs[0];
            oHt["pk_Year"] = StudentIDs[1];
            oHt["pk_Student_ID"] = StudentIDs[2];
            oHt["pk_Fac_ID"] = StudentIDs[3];
            oHt["pk_Cr_ID"] = StudentIDs[4];
            oHt["pk_MoLrn_ID"] = StudentIDs[5];
            oHt["pk_Ptrn_ID"] = StudentIDs[6];
            oHt["pk_Brn_ID"] = StudentIDs[7];
            oHt["pk_CrPr_Details_ID"] = StudentIDs[9];
            oHt["pk_CrPrCh_ID"] = StudentIDs[10];
            oHt["CrPr_Seq"] = StudentIDs[8];
            oHt["CrPrCh_Seq"] = StudentIDs[11];
            //oHt["Admission_Form_No"] = StudentIDs[12];
            //oHt["AdmissionMode"] = StudentIDs[13];
            //oHt["CrPr_OrderNo"] = StudentIDs[14];
            //oHt["MINumber"] = StudentIDs[15];
            //oHt["IsDirectAdmission"] = sISDirectAdmission;

            //oHt["Prn_number "] = ((Label)((Repeater)(source)).Items[e.Item.ItemIndex].FindControl("lblPRN")).Text;
            oHt["User"] = user.User_ID;
            oHt["CancellationReason"] = sCancelReason;

            //string sAdmissionFormNo = StudentIDs[12];
            //string sAdmissionMode = StudentIDs[13];
            //int sCrPr_OrderNo = Convert.ToInt16(StudentIDs[14]);
            //string sMINumber = StudentIDs[15];

            //bool isDirectAdmission = StudentIDs[16].Equals("1") ? true : false;

            //oHt["CancellationReason"]=txtReasonforCancellation.
            clsStudent oStudent = new clsStudent();
            clsOthers sOthers = new clsOthers();

            sResult = oStudent.CancelAdmission(oHt);
            switch (sResult)
            {
                case "N":

                    //#region Followng code is added to cancel the admission at OA side, call to API

                    //string OaMessage = string.Empty;

                    //Hashtable oHs = new Hashtable();
                    //oHs.Add("pk_Uni_ID", StudentIDs[0]);

                    //if (sOthers.Allow_CancelAdmissionAtOASide(oHs))
                    //{
                    //    if (sAdmissionMode == "11" || sAdmissionMode == "12") //OA unregistered
                    //    {
                    //        if (sCrPr_OrderNo.Equals(1) || isDirectAdmission)
                    //        {
                    //            clsUserLogin userLogin = new clsUserLogin();

                    //            DataSet ds = new DataSet();

                    //            DataTable dt = new DataTable("CancelAdmissionTable");
                    //            dt.Columns.Add(new DataColumn("ApplicationID", typeof(string)));
                    //            dt.Columns.Add(new DataColumn("DUDCFlag", typeof(string)));
                    //            dt.Columns.Add(new DataColumn("Username", typeof(string)));
                    //            dt.Columns.Add(new DataColumn("MINumber", typeof(string)));

                    //            DataRow dr = dt.NewRow();
                    //            dr["ApplicationID"] = sAdmissionFormNo;
                    //            dr["DUDCFlag"] = "DU";
                    //            dr["Username"] = user.User_Name;
                    //            dr["MINumber"] = sMINumber;
                    //            dt.Rows.Add(dr);
                    //            ds.Tables.Add(dt);

                    //            string dtToJson = string.Empty;

                    //            dtToJson = JsonConvert.SerializeObject(ds, Formatting.Indented);

                    //            //old Code commented for API CALL

                    //            /*
                    //            try
                    //            {
                    //                string apiPath = userLogin.getSyncURL() + "PostStudentCancelAdmission";
                    //                using (ExtendedWebClient client = new ExtendedWebClient())
                    //                {
                    //                    client.Headers.Add("content-type", "application/json; charset=utf-8");
                    //                    client.Encoding = System.Text.Encoding.UTF8;
                    //                    OaMessage = client.UploadString(apiPath, "POST", dtToJson);
                    //                }

                    //            }*/

                    //            try
                    //            {
                    //                string apiPath = userLogin.getSyncURL() + "PostStudentCancelAdmission";
                    //                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiPath);
                    //                httpWebRequest.Method = "POST";
                    //                httpWebRequest.ContentType = "application/json";

                    //                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    //                {
                    //                    streamWriter.Write(dtToJson);
                    //                    streamWriter.Flush();
                    //                    streamWriter.Close();

                    //                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    //                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    //                    {
                    //                        OaMessage = streamReader.ReadToEnd();
                    //                    }
                    //                }
                    //            }

                    //            catch (Exception exOA)
                    //            {
                    //                //Log the error in database Table 

                    //                Hashtable oHsErrorLog = new Hashtable();

                    //                string[] sStudentIDs = UniStudID.Split('|');
                    //                oHsErrorLog.Add("pk_Uni_ID", sStudentIDs[0]);
                    //                oHsErrorLog.Add("pk_Year", sStudentIDs[1]);
                    //                oHsErrorLog.Add("pk_Student_ID", sStudentIDs[2]);
                    //                oHsErrorLog.Add("pk_Fac_ID", sStudentIDs[3]);
                    //                oHsErrorLog.Add("pk_Cr_ID", sStudentIDs[4]);
                    //                oHsErrorLog.Add("pk_MoLrn_ID", sStudentIDs[5]);
                    //                oHsErrorLog.Add("pk_Ptrn_ID", sStudentIDs[6]);
                    //                oHsErrorLog.Add("pk_Brn_ID", sStudentIDs[7]);
                    //                oHsErrorLog.Add("pk_CrPr_Details_ID", sStudentIDs[8]);
                    //                oHsErrorLog.Add("CrPr_Seq", sStudentIDs[9]);
                    //                oHsErrorLog.Add("CrPrCh_ID", sStudentIDs[10]);
                    //                oHsErrorLog.Add("CrPrCh_Seq", sStudentIDs[11]);
                    //                oHsErrorLog.Add("Error_Msg", exOA.Message);
                    //                oHsErrorLog.Add("UserName", user.User_Name);

                    //                sOthers.WriteOAErrorLog(oHsErrorLog);

                    //                OaMessage = "There is some issue while updating at OA side, Please contact Administrator.";
                    //            }
                    //        }
                    //    }
                    //}
                    ///*******************************************************************************************/
                    //#endregion

                    lblMsg.Text = "Admission of the selected term cancelled successfully.";
                    lblMsg.CssClass = "saveNote";
                    break;

                case "Y":
                    lblMsg.Text = "Admission of the selected term cannot be cancelled.";
                    lblMsg.CssClass = "errorNote";
                    break;

                case "E":
                    lblMsg.Text = "Admission of the selected term could not be cancelled as the Seat number is generated for this Term.";
                    lblMsg.CssClass = "errorNote";
                    break;

                case "I":
                    lblMsg.Text = "Admission of the selected term could not be cancelled as the Invoice is generated for this Term.";
                    lblMsg.CssClass = "errorNote";
                    break;

                case "":
                    lblMsg.Text = "Admission of the selected term cannot be cancelled.";
                    lblMsg.CssClass = "errorNote";
                    break;

                default:
                    break;
            }
            DisplayStudentDetails();
        }
        #endregion

        #region Function to Bind Repeater
        /// <summary>
        /// Repeater data binding method.
        /// </summary>
        /// <param name="crTable"></param>
        public void BindRepeater()
        {
            clsEligibilityDBAccess oclsEligibilityDBAccess = new clsEligibilityDBAccess();
            crTable = oclsEligibilityDBAccess.GetStudentsCourseProfileForCancelAdmission(uniID, year, studentID);

            if (crTable != null && crTable.Rows.Count > 0)
            {
                RptCourse.DataSource = crTable;
                RptCourse.DataBind();
                divCourseProfile.Visible = true;
                divCourse.Visible = true;
                hid_Term_Count.Value = crTable.Rows.Count.ToString();
            }
            else
            {
                divCourseProfile.Visible = false;
                divCourse.Visible = false;
            }
        }
        #endregion
	}
}

#region Commented Code

//oPhoto.ImageUrl = dtRow["Download_Path"].ToString() + Row["PhotoPath"].ToString();////"PhotoSignHandler.ashx?img=Photo&UniID=" + Convert.ToString(Row["pk_Uni_ID"]) + "&StudentID=" + Convert.ToString(Row["pk_Student_ID"]) + "&YearID=" + Convert.ToString(Row["pk_Year"]);
//if (!string.IsNullOrEmpty(Row["PhotoPath"].ToString()))
//{
//    try
//    {
//        URLReq = (HttpWebRequest)WebRequest.Create(dtRow["Download_Path"].ToString() + Row["PhotoPath"].ToString());
//        URLRes = (HttpWebResponse)URLReq.GetResponse();
//        if (URLRes == null)
//        {
//            oPhoto.ImageUrl = dtRow["Download_Path"].ToString() + "NoPhoto.JPG";
//        }
//        else
//        {
//            if (URLRes.StatusCode == HttpStatusCode.OK)
//            {
//                oPhoto.ImageUrl = dtRow["Download_Path"].ToString() + Row["PhotoPath"].ToString();//"PhotoSignHandler.ashx?img=Photo&UniID=" + Convert.ToString(Row["pk_Uni_ID"]) + "&StudentID=" + Convert.ToString(Row["pk_Student_ID"]) + "&YearID=" + Convert.ToString(Row["pk_Year"]);
//            }
//            else
//            {
//                oPhoto.ImageUrl = dtRow["Download_Path"].ToString() + "NoPhoto.JPG";
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
//    oPhoto.ImageUrl = dtRow["Download_Path"].ToString() + "NoPhoto.JPG";
//}
//oPhoto.CssClass = "cssImage";


//if (!string.IsNullOrEmpty(Row["SignPath"].ToString()))
//{
//    try
//    {
//        URLReq = (HttpWebRequest)WebRequest.Create(dtRow["Download_Path"].ToString() + Row["SignPath"].ToString());
//        URLRes = (HttpWebResponse)URLReq.GetResponse();
//        if (URLRes == null)
//        {
//            oSign.ImageUrl = dtRow["Download_Path"].ToString() + "NoSign.JPG";
//        }
//        else
//        {
//            if (URLRes.StatusCode == HttpStatusCode.OK)
//            {
//                oSign.ImageUrl = dtRow["Download_Path"].ToString() + Row["SignPath"].ToString();//"PhotoSignHandler.ashx?img=Photo&UniID=" + Convert.ToString(Row["pk_Uni_ID"]) + "&StudentID=" + Convert.ToString(Row["pk_Student_ID"]) + "&YearID=" + Convert.ToString(Row["pk_Year"]);
//            }
//            else
//            {
//                oSign.ImageUrl = dtRow["Download_Path"].ToString() + "NoSign.JPG";
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
//    oSign.ImageUrl = dtRow["Download_Path"].ToString() + "NoSign.JPG";
//}
#endregion
        