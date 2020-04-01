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
using System.Threading;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Net;
using DUConfigurations;

namespace StudentRegistration.Eligibility
{
	public partial class CancelAdmission__1 : System.Web.UI.Page
	{
		#region Declaration Of variables
		DataTable oDt = null;
		DataTable dtPpSummary = null;
		clsStudent oStudent;
		clsStudent oViewStudent;
		DataSet oDataSet;
		Hashtable oHashTable;
		clsCommon oCommon = new clsCommon();
		clsCache oCache = new clsCache();
		Panel oPanelMain = null;
		Panel oMainPanel;         
        CDN oCDNKeys = clsDUConfigurations.Instance.CDNKeys;
        clsCDN objCDN = null;
        string sPathExists = string.Empty;

		#endregion

		#region Initialize Culture
		protected override void InitializeCulture()
		{
			System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
		}

		#endregion

		#region Page Load
		protected void Page_Load(object sender, EventArgs e)
		{
			////string s = string.Empty;
			//Hashtable oHas = new Hashtable();

			////foreach (string var in Request.ServerVariables.AllKeys)
			////{
			////    s = s + var + "=" + Request.ServerVariables[var];
			////    //oHas[var] = 
			////}
			//string s1 = Request.ServerVariables.
			oCache.NoCache();

			


				#region Set default values in Hidden Variable if any
				HtmlInputHidden[] hid = new HtmlInputHidden[7];
				hid_pk_Uni_ID.Value = clsGetSettings.UniversityID;
				hid[0] = hid_pk_Uni_ID;
				hid[1] = hid_pk_Year;
				hid[2] = hid_pk_Student_ID;
				hid[3] = hid_Stud_Name;
				hid[4] = hid_OldPRN;
				hid[5] = hid_PRN_Number;
				hid[6] = hid_eligiblityFN;
				oCommon.setHiddenVariablesMPC(ref hid);
				#endregion
				Page.Title = clsGetSettings.Name + " | Admissions - Student Detail";
				lblPageHead.Text = "Cancel Student Admission -";
				PageTitle1.PrnNumber = hid_PRN_Number.Value;
				PageTitle1.StudentName = hid_Stud_Name.Value;
				PageTitle1.OldPrnNumber = hid_OldPRN.Value;

				#region Set Properties for ShowPhotoControl

				ShowStudentPhoto1.YearID = hid_pk_Year.Value;
				ShowStudentPhoto1.StudentID = hid_pk_Student_ID.Value;

				#endregion

				oViewStudent = new clsStudent();
				oDataSet = new DataSet();
				oHashTable = new Hashtable();
				oHashTable.Add("Uni_ID", clsGetSettings.UniversityID);
				oHashTable.Add("pk_Student_ID", Convert.ToString(hid_pk_Student_ID.Value));
				oHashTable.Add("pk_Year", Convert.ToString(hid_pk_Year.Value));
				if (hid_PRN_Number.Value != "Not Available")
					oHashTable.Add("Prn_Number", hid_PRN_Number.Value);
				if (!IsPostBack)
				{
				oDataSet = oViewStudent.GetViewStudentDetails(oHashTable);
				DisplayStudentDetails();

			}

				
		}

		#endregion

		#region Display Student Details
		/// <summary>
		/// This Will Display the Student Details.
		/// </summary>
		private void DisplayStudentDetails()
		{
			DisplayPersonalReservationDetails();
			DisplayQualificationDetails();
			DisplayLastQualificationDetails();
			DisplayPaperSummary();
			DisplayDocumentsDetails();
			DisplayFeeDetails();
			DisplayExamDetails();
		}


		#endregion

		#region Displaying Personal & Reservation Details
		/// <summary>
		/// Display Personal & Reservation Details.
		/// </summary>
		private void DisplayPersonalReservationDetails()
		{
			#region Display of Personal Details
			oDt = new DataTable();
			oDt = oDataSet.Tables[2];

			if (oDt.Rows.Count > 0)
			{
				lblNameOfStudent.Text = Convert.ToString(oDt.Rows[0]["Last_Name"]) + " " + Convert.ToString(oDt.Rows[0]["First_Name"]) + " " + Convert.ToString(oDt.Rows[0]["Middle_Name"]);

				if (Convert.ToString(oDt.Rows[0]["Changed_Name_Flag"]) == "1")
				{
					trChangedName.Attributes.Add("style", "display:inline");
					lblChangedName.Text = Convert.ToString(oDt.Rows[0]["Prev_Last_Name"]) + " " + Convert.ToString(oDt.Rows[0]["Prev_First_Name"]) + " " + Convert.ToString(oDt.Rows[0]["Prev_Middle_Name"]);
				}
				else
				{
					trChangedName.Attributes.Add("style", "display:none");
					lblChangedName.Text = string.Empty;
				}

				lblVernacularName.Text = Convert.ToString(oDt.Rows[0]["Vernacular_Name"]);
				lblCertificateNm.Text = Convert.ToString(oDt.Rows[0]["Name_QualExamMarkSheet"]);
				lblDOB.Text = Convert.ToString(oDt.Rows[0]["DOB"]);
				lblPlaceOfBirth.Text = Convert.ToString(oDt.Rows[0]["Place_of_Birth"]);

				if (Convert.ToString(oDt.Rows[0]["Blood_Group"]) != null && Convert.ToString(oDt.Rows[0]["Blood_Group"]) != "0" && Convert.ToString(oDt.Rows[0]["Blood_Group"]).Trim() != string.Empty)
				{
					lblBloodGrp.Text = Convert.ToString(oDt.Rows[0]["Blood_Group"]);
				}
				else
				{
					lblBloodGrp.Text = "Not Available";
				}

				lblLocationCategory.Text = Convert.ToString(oDt.Rows[0]["Location_Category"]);
				lblNationality.Text = Convert.ToString(oDt.Rows[0]["Nationality"]);
				lblPermAddress.Text = Convert.ToString(oDt.Rows[0]["Per_Address"]);
				lblPermCity.Text = Convert.ToString(oDt.Rows[0]["Per_City"]);

				if (Convert.ToString(oDt.Rows[0]["PTalukaName"]) != null && Convert.ToString(oDt.Rows[0]["PTalukaName"]) != string.Empty)
				{
					lblPermTehsil.Text = Convert.ToString(oDt.Rows[0]["PTalukaName"]);
				}
				else
				{
					lblPermTehsil.Text = Convert.ToString(oDt.Rows[0]["Per_Other_Tahsil"]);
				}

				lblPermDist.Text = Convert.ToString(oDt.Rows[0]["PDistrictName"]);
				lblPermState.Text = Convert.ToString(oDt.Rows[0]["PStateName"]);
				lblPermPin.Text = Convert.ToString(oDt.Rows[0]["Per_Pin"]);

				if (Convert.ToString(oDt.Rows[0]["Corr_Per_Same_Flag"]) == "1")
				{
					lblPerCountry.Text = Convert.ToString(oDt.Rows[0]["PCountryName"]);
				}
				else
				{
					lblPerCountry.Text = Convert.ToString(oDt.Rows[0]["PCountryName"]);
				}

				lblFathersName.Text = Convert.ToString(oDt.Rows[0]["Father_Last_Name"]) + " " + Convert.ToString(oDt.Rows[0]["Father_First_Name"]) + " " + Convert.ToString(oDt.Rows[0]["Father_Middle_Name"]);
				lblMothersMaidenName.Text = Convert.ToString(oDt.Rows[0]["Mother_Last_Name"]) + " " + Convert.ToString(oDt.Rows[0]["Mother_First_Name"]) + " " + Convert.ToString(oDt.Rows[0]["Mother_Middle_Name"]);

				if (Convert.ToString(oDt.Rows[0]["Phone1_STD"]) != string.Empty && Convert.ToString(oDt.Rows[0]["Phone1_Number"]) != string.Empty)
				{
					lblPermTelephone.Text = Convert.ToString(oDt.Rows[0]["Phone1_STD"]) + "-" + Convert.ToString(oDt.Rows[0]["Phone1_Number"]);
				}
				else
				{
					lblPermTelephone.Text = "Not Available";
				}

				lblCorspAddress.Text = Convert.ToString(oDt.Rows[0]["Corr_Address"]);
				if (Convert.ToString(oDt.Rows[0]["Corr_City"]) != string.Empty && oDt.Rows[0]["Corr_City"] != null)
				{
					lblCorspCity.Text = Convert.ToString(oDt.Rows[0]["Corr_City"]);
				}
				else
				{
					lblCorspCity.Text = "Not Available";
				}

				if (oDt.Rows[0]["CTalukaName"] != null && Convert.ToString(oDt.Rows[0]["CTalukaName"]) != string.Empty)
				{
					lblCorspTehsil.Text = Convert.ToString(oDt.Rows[0]["CTalukaName"]);
				}
				else
				{
					lblCorspTehsil.Text = "Not Available";
					if (Convert.ToString(oDt.Rows[0]["Corr_Other_Tahsil"]) != string.Empty && Convert.ToString(oDt.Rows[0]["Corr_Other_Tahsil"]) != null)
					{
						lblCorspTehsil.Text = Convert.ToString(oDt.Rows[0]["Corr_Other_Tahsil"]);
					}
					else
					{
						lblCorspTehsil.Text = "Not Available";
					}
				}

				if (Convert.ToString(oDt.Rows[0]["CDistrictName"]) != string.Empty && Convert.ToString(oDt.Rows[0]["CDistrictName"]) != null)
				{
					lblCorspDist.Text = Convert.ToString(oDt.Rows[0]["CDistrictName"]);
				}
				else
				{
					lblCorspDist.Text = "Not Available";
				}

				if (Convert.ToString(oDt.Rows[0]["CStateName"]) != string.Empty && Convert.ToString(oDt.Rows[0]["CStateName"]) != null)
				{
					lblCorspState.Text = Convert.ToString(oDt.Rows[0]["CStateName"]);
				}
				else
				{
					lblCorspState.Text = "Not Available";
				}

				lblCorspPin.Text = Convert.ToString(oDt.Rows[0]["Corr_Pin"]);

				if (oDt.Rows[0]["CCountryName"] != null && Convert.ToString(oDt.Rows[0]["CCountryName"]) != string.Empty)
				{
					lblCorsCountry.Text = Convert.ToString(oDt.Rows[0]["CCountryName"]);
				}
				else
				{
					lblCorsCountry.Text = "Not Available";
				}

				if (Convert.ToString(oDt.Rows[0]["Phone2_STD"]) != string.Empty && Convert.ToString(oDt.Rows[0]["Phone2_Number"]) != string.Empty)
				{
					lblCorspTelephone.Text = Convert.ToString(oDt.Rows[0]["Phone2_STD"]) + "-" + Convert.ToString(oDt.Rows[0]["Phone2_Number"]);
				}
				else
				{
					lblCorspTelephone.Text = "Not Available";
				}

				if (Convert.ToString(oDt.Rows[0]["Mobile_Number"]) != string.Empty)
				{
					string sMobile = Convert.ToString(oDt.Rows[0]["Mobile_Number"]);
					string sCountryCode = Convert.ToString(sMobile.Substring(0, 2));
					lblMobile.Text = sCountryCode + "-" + Convert.ToString(sMobile.Substring(2, 10));
				}
				else
				{
					lblMobile.Text = "Not Available";
				}

				if (Convert.ToString(oDt.Rows[0]["Email_ID"]) != string.Empty)
				{
					lblEmailID.Text = Convert.ToString(oDt.Rows[0]["Email_ID"]);
				}
				else
				{
					lblEmailID.Text = "Not Available";
				}

				lblMaritalStatus.Text = Convert.ToString(oDt.Rows[0]["MaritalStatus_Desc"]);
				lblGender.Text = Convert.ToString(oDt.Rows[0]["Gender_Desc"]);
				lblReligion.Text = Convert.ToString(oDt.Rows[0]["Religion"]);

				oDt = null;
			}
			else
			{
				tr_PersonalDetails1.Attributes.Add("Style", "Display:Inline;width:100%;");
				tr_PersonalDetails.Attributes.Add("Style", "Display:none;width:100%;");
				Err_PersonalDetails.Visible = true;
			}

			showImages();
			#endregion

			#region Display of Reservation Details
			oDt = oDataSet.Tables[3];
			if (oDt.Rows.Count > 0)
			{
				tr_ReservationDetails.Attributes.Add("Style", "Display:Inline;width:100%;");
				if (Convert.ToString(oDt.Rows[0]["Guardian_Annual_Income"]) != null && Convert.ToString(oDt.Rows[0]["Guardian_Annual_Income"]) != string.Empty)
				{
					lblGuardIncome.Text = Convert.ToString(oDt.Rows[0]["Guardian_Annual_Income"]);
				}
				else
				{
					lblGuardIncome.Text = "Not Available";
				}

				if (Convert.ToString(oDt.Rows[0]["GuardOccupation"]) != null && Convert.ToString(oDt.Rows[0]["GuardOccupation"]) != string.Empty)
				{
					lblGuardOccupation.Text = Convert.ToString(oDt.Rows[0]["GuardOccupation"]);
				}
				else
				{
					lblGuardOccupation.Text = "Not Available";
				}

				if (Convert.ToString(oDt.Rows[0]["Category_Flag"]) != null && Convert.ToString(oDt.Rows[0]["Category_Flag"]) != string.Empty)
				{
					if (Convert.ToString(oDt.Rows[0]["ResvCategory"]) != null && Convert.ToString(oDt.Rows[0]["ResvCategory"]) != string.Empty)
					{
						if (Convert.ToString(oDt.Rows[0]["SubCaste"]) != null && Convert.ToString(oDt.Rows[0]["SubCaste"]) != string.Empty)
						{
							lblCategory.Text = Convert.ToString(oDt.Rows[0]["Category"]) + " (" + Convert.ToString(oDt.Rows[0]["ResvCategory"]) + " - " + Convert.ToString(oDt.Rows[0]["SubCaste"]) + ")";
						}
						else
						{
							lblCategory.Text = Convert.ToString(oDt.Rows[0]["Category"]) + " (" + Convert.ToString(oDt.Rows[0]["ResvCategory"]) + ")";
						}
					}
					else
					{
						lblCategory.Text = Convert.ToString(oDt.Rows[0]["Category"]);
					}
				}

				lblAdmittedCat.Text = Convert.ToString(oDt.Rows[0]["AdmittedCategory"]);
				lblDomicileState.Text = Convert.ToString(oDt.Rows[0]["State"]);

				if (Convert.ToString(oDt.Rows[0]["Physically_Challenged_Flag"]) != null && Convert.ToString(oDt.Rows[0]["Physically_Challenged_Flag"]) != string.Empty)
				{
					if (Convert.ToString(oDt.Rows[0]["PhysicallyChallenged"]) != null && Convert.ToString(oDt.Rows[0]["PhysicallyChallenged"]) != string.Empty)
					{
						lblPhysicallyChallenged.Text = Convert.ToString(oDt.Rows[0]["PhysicallyChallenged"]);
					}
					else
					{
						lblPhysicallyChallenged.Text = "Not Available";
					}
				}

				oDt = null;

				oDt = new DataTable();
				oDt = oDataSet.Tables[4];
				string sSocResFlag = "N";
				for (int i = 0; i < oDt.Rows.Count; i++)
				{
					if (Convert.ToString(oDt.Rows[i]["pk_Student_ID"]) != null && Convert.ToString(oDt.Rows[i]["pk_Student_ID"]) != string.Empty)
					{
						tr_ReservationDetails.Attributes.Add("Style", "Display:Inline;width:100%;");

						if (Convert.ToString(oDt.Rows[i]["SocialReservation_Description"]) != string.Empty)
						{
							lblSocialResv.Text += "<br>" + Convert.ToString(oDt.Rows[i]["SocialReservation_Description"]).Trim();
							sSocResFlag = "Y";
						}
						else
						{
							lblSocialResv.Text = "Not Available";
						}
					}
				}

				if (sSocResFlag != "Y")
				{
					lblSocialResv.Text = "Not Available";
				}

				oDt = null;
			}
			else
			{
				tr_ReservationDetails.Attributes.Add("Style", "Display:none;width:100%;");
				Err_ReservationDetails.Visible = true;
			}
			#endregion
		}
		#endregion

		#region Display Qualification Details
		/// <summary>
		/// Display Qualification details.
		/// </summary>   
		private void DisplayQualificationDetails()
		{
			//oDt = new DataTable();
			//oDt = oDataSet.Tables[5];  // oDataSet.Tables[5] returns Qualification Details          
			//if (oDt.Rows.Count > 0)
			//{
			//    TDNote.Attributes.Add("style", "display:inline");                
			//    GV_Qualification.DataSource = oDt;
			//    GV_Qualification.DataBind();
			//    GV_Qualification.Visible = true;
			//}
			//else
			//{
			//    Err_Qualification.Visible = true;
			//    TDNote.Attributes.Add("style", "display:none");
			//    GV_Qualification.Visible = false;
			//}

			//oDt = null;
			oDt = new DataTable();
			oDt = oDataSet.Tables[5];  // oDataSet.Tables[5] returns Qualification Details          
			if (oDt.Rows.Count > 0)
			{
				//TDNote.Attributes.Add("style", "display:inline");
				GV_Qualification.DataSource = oDt;
				GV_Qualification.DataBind();
				GV_Qualification.Visible = true;
			}
			else
			{
				Err_Qualification.Visible = true;
				//TDNote.Attributes.Add("style", "display:none");
				GV_Qualification.Visible = false;
			}

			oDt = null;

		}
		private void DisplayLastQualificationDetails()
		{
			oDt = new DataTable();
			oDt = oDataSet.Tables[9];  // oDataSet.Tables[5] returns Qualification Details          
			if (oDt.Rows.Count > 0)
			{
				// TDNote.Attributes.Add("style", "display:inline");
				GV_LastQualification.DataSource = oDt;
				GV_LastQualification.DataBind();
				GV_LastQualification.Visible = true;
			}
			else
			{
				Err_LastQualification.Visible = true;
				//TDNote.Attributes.Add("style", "display:none");
				GV_LastQualification.Visible = false;
			}

			oDt = null;

		}
		#region  Row Data Bound event for Qualification
		protected void GV_Qualification_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			// Making the row font color red when the data is of last qualification
			//if (e.Row.RowType == DataControlRowType.DataRow)
			//{
			//    if (e.Row.Cells[6].Text != string.Empty && e.Row.Cells[6].Text != "&nbsp;")
			//        e.Row.ForeColor = Color.Red;
			//}
		}
		protected void GV_LastQualification_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			//Making the row font color red when the data is of last qualification
			//if (e.Row.RowType == DataControlRowType.DataRow)
			//{
			//if (e.Row.Cells[6].Text != string.Empty && e.Row.Cells[6].Text != "&nbsp;")
			// e.Row.ForeColor = Color.Red;
			// }
		}

		#endregion
		#endregion

		#region Display Paper Summary

		#region Function Display Papers with grid view
		private void DisplayPaperSummary()
		{
			dtPpSummary = oDataSet.Tables[6];
			oDt = oDataSet.Tables[1]; // oDataSet.Tables[1] returns the student Admitted Course.
			// Creating New Pannel
			oPanelMain = new Panel();
			oPanelMain.Width = Unit.Percentage(100);

			DataView CoursePartTerms = new DataView();
			DataTable CoursePaperTable = new DataTable();
			if (oDt != null && oDt.Rows.Count > 0)
			{
				if (dtPpSummary != null && dtPpSummary.Rows.Count > 0)
				{
					DataView DVPpSummary = dtPpSummary.DefaultView;
					//For Loop to show Course Name
					for (int i = 0; i < oDt.Rows.Count; i++)
					{
						if (oDt.Rows[i]["Active_Flag"].ToString().Equals("1"))
							oPanelMain.Controls.Add(new LiteralControl("<h5 align='left' style='margin-top: 8px;margin-bottom: 8px;'>" + oDt.Rows[i]["CourseName"].ToString() + "</h5>"));
						else
							oPanelMain.Controls.Add(new LiteralControl("<h5 align='left' style='margin-top: 8px;margin-bottom: 8px;'>" + Convert.ToString(oDt.Rows[i]["CourseName"]) + "<Font class='Mandatory' style='font-size:10px;'> (This " + GetLocalResourceObject("Course") + " is not active)</Font> </h5>"));

						CoursePartTerms = dtPpSummary.DefaultView;
						CoursePartTerms.RowFilter = " pk_Fac_ID=" + oDt.Rows[i]["pk_Fac_ID"] + " and pk_Cr_ID=" + oDt.Rows[i]["pk_Cr_ID"] + " and pk_MoLrn_ID=" + oDt.Rows[i]["pk_MoLrn_ID"] + "and pk_Ptrn_ID=" + oDt.Rows[i]["pk_Ptrn_ID"] + " and pk_Brn_ID=" + oDt.Rows[i]["pk_Brn_ID"];
						////string[] strColumnName = new string[] { "CoursePartChildName", "PpHeadName", "ADPpHeadName" };

						// Paper related with A particular Course (including all course Part Terms)
						////CoursePaperTable = CoursePartTerms.ToTable(true, strColumnName);
						CoursePaperTable = CoursePartTerms.ToTable();
						// Creating Grid view to display paper details for selected course
						GridView oGridViewPaper = new GridView();
						oGridViewPaper.RowDataBound += new GridViewRowEventHandler(oGridViewPaper_RowDataBoundPaper);
						oGridViewPaper.RowCommand += new GridViewCommandEventHandler(oGridViewPaper_RowCommand);
						oGridViewPaper.Width = Unit.Percentage(100);
						oGridViewPaper.AutoGenerateColumns = false;
						oGridViewPaper.CssClass = "clGrid";
						// Adding Template fileld & Datafields Coloumn in Grid view
						////TemplateField tmpfield = new TemplateField();
						////tmpfield.ItemTemplate = new GridViewTemplate1(DataControlRowType.DataRow);
						////tmpfield.ItemStyle.Width = Unit.Percentage(2);
						////tmpfield.HeaderText = "Sr/No.";
						////tmpfield.HeaderStyle.CssClass = "gridHeader";
						////tmpfield.ItemStyle.VerticalAlign = VerticalAlign.Top;
						////oGridViewPaper.Columns.Add(tmpfield);

						DataControlField colfi;
						BoundField field;
						field = new BoundField();
						field.DataField = "Academic_Year";
						field.HtmlEncode = false;
						field.HeaderText = "Academic Year";
						field.HeaderStyle.CssClass = "gridHeader";
						field.ItemStyle.Width = Unit.Percentage(10);
						field.ItemStyle.VerticalAlign = VerticalAlign.Top;
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "Inst_Code";
						field.HtmlEncode = false;
						field.HeaderText = "Inst Code";
						field.HeaderStyle.CssClass = "gridHeader";
						field.ItemStyle.Width = Unit.Percentage(7);
						field.ItemStyle.VerticalAlign = VerticalAlign.Top;
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "CoursePartChildName";
						field.HtmlEncode = false;
						field.HeaderText = "Course Part Name";
						field.HeaderStyle.CssClass = "gridHeader";
						field.ItemStyle.Width = Unit.Percentage(8);
						field.ItemStyle.VerticalAlign = VerticalAlign.Top;
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "Eligibility_Form_No_Status";
						field.HtmlEncode = false;
						field.HeaderText = "Eligibility Form No/Eligibility Status";
						field.HeaderStyle.CssClass = "gridHeader";
						field.ItemStyle.Width = Unit.Percentage(18);
						field.ItemStyle.VerticalAlign = VerticalAlign.Top;
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "PpHeadName";
						field.HtmlEncode = false;
						field.HeaderText = "Opted Papers";
						field.HeaderStyle.CssClass = "gridHeader";
						field.ItemStyle.Width = Unit.Percentage(30);
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);


						field = new BoundField();
						field.DataField = "ADPpHeadName";
						field.HtmlEncode = false;
						field.HeaderText = "Additional Papers";
						field.HeaderStyle.CssClass = "gridHeader";
						field.ItemStyle.Width = Unit.Percentage(20);
						field.ItemStyle.VerticalAlign = VerticalAlign.Top;
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);


						TemplateField oButtonFieldCancelAdmission = new TemplateField();
						oButtonFieldCancelAdmission.ItemStyle.Width = Unit.Percentage(7);
						oButtonFieldCancelAdmission.HeaderText = "Cancel Admission";
						oButtonFieldCancelAdmission.HeaderStyle.CssClass = "gridHeader";                             
						oGridViewPaper.Columns.Add(oButtonFieldCancelAdmission);
					   

						field = new BoundField();
						field.DataField = "pk_Fac_ID";
						field.HtmlEncode = false;
						field.HeaderStyle.CssClass = "off";
						field.ItemStyle.CssClass = "off";
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "pk_Cr_ID";
						field.HtmlEncode = false;
						field.HeaderStyle.CssClass = "off";
						field.ItemStyle.CssClass = "off";
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "pk_MoLrn_ID";
						field.HtmlEncode = false;
						field.HeaderStyle.CssClass = "off";
						field.ItemStyle.CssClass = "off";
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "pk_Ptrn_ID";
						field.HtmlEncode = false;
						field.HeaderStyle.CssClass = "off";
						field.ItemStyle.CssClass = "off";
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "pk_Brn_ID";
						field.HtmlEncode = false;
						field.HeaderStyle.CssClass = "off";
						field.ItemStyle.CssClass = "off";
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "pk_CrPr_Details_ID";
						field.HtmlEncode = false;
						field.HeaderStyle.CssClass = "off";
						field.ItemStyle.CssClass = "off";
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "pk_CrPrCh_ID";
						field.HtmlEncode = false;
						field.HeaderStyle.CssClass = "off";
						field.ItemStyle.CssClass = "off";
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "CrPr_Seq";
						field.HtmlEncode = false;
						field.HeaderStyle.CssClass = "off";
						field.ItemStyle.CssClass = "off";
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "CrPrCh_Seq";
						field.HtmlEncode = false;
						field.HeaderStyle.CssClass = "off";
						field.ItemStyle.CssClass = "off";
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "MaxCrPrChSeq";
						field.HtmlEncode = false;
						field.HeaderStyle.CssClass = "off";
						field.ItemStyle.CssClass = "off";
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);

						field = new BoundField();
						field.DataField = "Flag";
						field.HtmlEncode = false;
						field.HeaderStyle.CssClass = "off";
						field.ItemStyle.CssClass = "off";
						colfi = field;
						oGridViewPaper.Columns.Add(colfi);



						oGridViewPaper.DataSource = CoursePaperTable;
						oGridViewPaper.DataBind();
						oPanelMain.Controls.Add(oGridViewPaper);

					}// End Course loop
					tblSummary.Controls.Add(oPanelMain); //adding  Pannel

				}
				else
				{
					lblerrorPaper.Visible = true;
					lblerrorPaper.Text = "No Papers Available.";
				}
			}
			else
			{
				lblerrorPaper.Visible = true;
				lblerrorPaper.Text = "Course Not Available";
			}
		}

		void oGridViewPaper_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			

		}
		#endregion

		#region Row Databound event for Paper Gridview
		protected void oGridViewPaper_RowDataBoundPaper(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				////Literal l1 = (Literal)e.Row.FindControl("lblidPaper");
				////l1.Text = Convert.ToString(e.Row.DataItemIndex + 1);

				if (e.Row.Cells[4].Text == "&nbsp;")
				{
					e.Row.Cells[4].Text = "No papers opted.";
					e.Row.Cells[4].CssClass = "errorNote";
					e.Row.Cells[4].Attributes.Add("style", " font-size:10px;");
				}
				else
				{
					e.Row.Cells[4].Text = Server.HtmlDecode(e.Row.Cells[4].Text);
					string[] s = e.Row.Cells[4].Text.Split(new char[] { ',' });
					//foreach (string str in s)
					//{
					//    str.tex
					//}
					string s1 = "<ul style='padding-left: 10px; margin: 10px;'>";
					for (int i = 0; i < s.Length - 1; i++)
					{
						s1 += "<li>" + s[i] + "</li>";
					}
					s1 += "</ul>";
					//e.Row.Cells[2].Text = e.Row.Cells[2].Text.Replace("_Str", "<ul type='disc' style='margin:0px;padding:2px;'><li>");
					//e.Row.Cells[2].Text = e.Row.Cells[2].Text.Replace("_End", "</li></ul>");
					e.Row.Cells[4].Text = s1;
					e.Row.Cells[4].Attributes.Add("Style", "vertical-align:top;");

				}

				if (e.Row.Cells[5].Text == "&nbsp;")
				{
					e.Row.Cells[5].Text = "No additional papers opted.";
					e.Row.Cells[5].CssClass = "errorNote";
					e.Row.Cells[5].Attributes.Add("style", " font-size:10px; ");

				}
				else
				{
					e.Row.Cells[5].Text = Server.HtmlDecode(e.Row.Cells[5].Text);
					string[] s = e.Row.Cells[5].Text.Split(new char[] { ',' });
					string s1 = "<ul style='padding-left: 10px; margin: 10px;'>";
					for (int i = 0; i < s.Length - 1; i++)
					{
						s1 += "<li>" + s[i] + "</li>";
					}
					s1 += "</ul>";
					//e.Row.Cells[3].Text = e.Row.Cells[3].Text.Replace("_Str", "<ul type='disc' style='margin:0px;padding:2px;'><li>");
					//e.Row.Cells[3].Text = e.Row.Cells[3].Text.Replace("_End", "</li></ul>");
					e.Row.Cells[5].Text = s1;
					e.Row.Cells[5].Attributes.Add("Style", "vertical-align:top;");
				}

				Button oButton = new Button();
			  
				oButton.Text = "SELECT";
			   string strArg = e.Row.Cells[7].Text + "|" + e.Row.Cells[8].Text + "|" + e.Row.Cells[9].Text + "|" + e.Row.Cells[10].Text + "|" + e.Row.Cells[11].Text + "|" + e.Row.Cells[12].Text + "|" + e.Row.Cells[13].Text + "|" + e.Row.Cells[14].Text + "|" + e.Row.Cells[15].Text + "|" + e.Row.Cells[17].Text;
			   
			   if (Convert.ToInt32(e.Row.Cells[15].Text) == Convert.ToInt32(e.Row.Cells[16].Text))
			   {
				   oButton.Enabled = true;
				   oButton.Attributes.Add("onclick", "return ConfirmCancel('" + strArg + "','" + e.Row.Cells[15].Text + "');");
			   }
			   else
			   {
				   oButton.Enabled = false;
			   }               
				e.Row.Cells[6].Controls.Add(oButton);
				

			}
		}

	   
		#endregion

		#region Gridview Template Class For Paper Details
		////public class GridViewTemplate1 : ITemplate
		////{
		////    private DataControlRowType templateType;
		////    private string columnName;

		////    public GridViewTemplate1(DataControlRowType type)
		////    {
		////        templateType = type;
		////    }
		////    public void InstantiateIn(System.Web.UI.Control container)
		////    {

		////        if (templateType == DataControlRowType.DataRow)
		////        {

		////            Literal ltrlPaper = new Literal();
		////            ltrlPaper.Text = "";
		////            ltrlPaper.ID = "lblidPaper";
		////            container.Controls.Add(ltrlPaper);
		////        }

		////    }


		////}
		#endregion

		

		#endregion

		#region Display Documents Details
		#region Function for Displaying course wise document
		private void DisplayDocumentsDetails()
		{
			GridView oGridview;
			oDt = new DataTable();
			oDt = oDataSet.Tables[1];
			DataTable oDt1 = new DataTable();
			oDt1 = oDataSet.Tables[7];// oDataSet.Tables[7] returns the document Details
			if (oDt.Rows.Count > 0)
			{

				oPanelMain = new Panel();
				oPanelMain.Width = Unit.Percentage(100);
				Err_Documents.Visible = false;

				//Loop 4 Each Course Name
				for (int z = 0; z < oDt.Rows.Count; z++)
				{
					// OUTER Table which will be the inner of Main Pannel
					Table DocTable = new Table();
					DocTable.Width = Unit.Percentage(100);
					DocTable.Attributes.Add("Style", "margin-left:20px; margin-top:0px; margin-bottom:0px;");
					DocTable.Attributes.Add("cellpadding", "0");
					DocTable.Attributes.Add("cellspacing", "0");
					TableRow TrDoc = new TableRow();
					TrDoc.Width = Unit.Percentage(100);
					TableCell TCDoc = new TableCell();
					TCDoc.Width = Unit.Percentage(100);

					DataTable temptb = new DataTable();
					oGridview = new GridView();
					oGridview.ShowHeader = false;
					oGridview.Width = Unit.Percentage(100);
					oGridview.AutoGenerateColumns = false;
					oGridview.GridLines = GridLines.None;
					oGridview.RowDataBound += new GridViewRowEventHandler(oGridview_RowDataBound);
					if (oDt.Rows[z]["Active_Flag"].ToString().Equals("1"))
						oPanelMain.Controls.Add(new LiteralControl("<h5 align='left' style='margin-top: 8px;margin-bottom: 8px;'>" + Convert.ToString(oDt.Rows[z]["CourseName"]) + "</h5>"));
					else
						oPanelMain.Controls.Add(new LiteralControl("<h5  align='left' style='margin-top: 8px;margin-bottom: 8px;'>" + Convert.ToString(oDt.Rows[z]["CourseName"]) + "<Font class='Mandatory' style='font-size:10px;'> (This " + GetLocalResourceObject("Course") + " is not active)</Font> </h5>"));

					DataView dv = oDt1.DefaultView; // Dv for Course wise document. where oDt1 contains student admitted all courses document
					dv.RowFilter = "pk_Fac_ID=" + oDt.Rows[z]["pk_Fac_ID"].ToString() + " and pk_Cr_ID=" + oDt.Rows[z]["pk_Cr_ID"].ToString() + " and pk_MoLrn_ID=" + oDt.Rows[z]["pk_MoLrn_ID"].ToString() + " and pk_Ptrn_ID=" + oDt.Rows[z]["pk_Ptrn_ID"].ToString() + " and pk_Brn_ID=" + oDt.Rows[z]["pk_Brn_ID"].ToString();
					string[] col = new string[] { "DocCert_Desc" };
					temptb = dv.ToTable(true, col);

					// For Each Course ,Get Documents into GridView

					if (temptb.Rows.Count > 0)
					{
						TemplateField tmpfield = new TemplateField();
						tmpfield.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow);
						oGridview.Columns.Add(tmpfield);
						DataControlField colfi;
						BoundField field;
						field = new BoundField();
						field.DataField = "DocCert_Desc";
						field.ItemStyle.Width = Unit.Percentage(99);
						colfi = field;
						oGridview.Columns.Add(colfi);
						oGridview.DataSource = temptb;
						oGridview.DataBind();
						TCDoc.Controls.Add(oGridview);
						TrDoc.Cells.Add(TCDoc);
						DocTable.Rows.Add(TrDoc);
						oPanelMain.Controls.Add(DocTable);
						tr_DocumentsDetails.Attributes.Add("Style", "Display:Inline;width:100%;");
						if (z != (oDt.Rows.Count - 1))
							oPanelMain.Controls.Add(new LiteralControl("<hr style='width:99%;text-align:center; size:10px;' />"));
					}
					else
						oPanelMain.Controls.Add(new LiteralControl("<div align='center' Class='errorNote' style='width:100%;font-size: 10px;'>Document details not available.</div>"));
					tr_DocumentsDetails.Controls.Add(oPanelMain);
				}

			}
			else
			{
				tr_DocumentsDetails.Attributes.Add("Style", "Display:Inline;width:100%;");
				Err_Documents.Visible = true;
			}
		}
		#endregion

		#region Databound event for Document Gridview
		protected void oGridview_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			//e.Row.Cells[2].Visible = false;
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				Literal l = (Literal)e.Row.FindControl("lblid");
				l.Text = Convert.ToString(e.Row.DataItemIndex + 1) + ".";

			}
		}
		#endregion

		#region Gridview Template Class For Document Details
		public class GridViewTemplate : ITemplate
		{
			private DataControlRowType templateType;
			private string columnName;

			public GridViewTemplate(DataControlRowType type)
			{
				templateType = type;
			}
			public void InstantiateIn(System.Web.UI.Control container)
			{

				if (templateType == DataControlRowType.DataRow)
				{
					Literal ltrl = new Literal();
					ltrl.Text = "";
					ltrl.ID = "lblid";
					container.Controls.Add(ltrl);
				}

			}


		}
		#endregion
		#endregion

		#region Display Fee Details


		private void DisplayFeeDetails()
		{


			Table oTable = null;
			TableRow otr = null;
			TableCell otd = null;
			DataTable oDistntCourseNameTab = new DataTable();
			DataTable oDistntCoursePartChildNameTab = new DataTable();
			DataTable otblFeeDetails = new DataTable();
			DataView DvEligiblityFee;
			DataView DvExamFee;
			Table otblEligiblityFeeExamfee;
			TableRow otbltr;
			TableCell otblcell;
			TableCell otblcell1;
			oMainPanel = new Panel();
			oMainPanel.Width = Unit.Percentage(100);
			oDistntCourseNameTab = oDataSet.Tables[1];
			oDistntCoursePartChildNameTab = oDataSet.Tables[0];//oDataSet.Tables[0] returns the Student admitted Course and Course Part term

			if (oDistntCourseNameTab != null && oDistntCourseNameTab.Rows.Count > 0)
			{
				otblFeeDetails = oDataSet.Tables[8];//oDataSet.Tables[8] returns Feehead wise Student's fee  of all Course Part terms  
				//Loop for Each Course
				for (int i = 0; i < oDistntCourseNameTab.Rows.Count; i++)
				{
					int seperatorcount = 0;
					if (oDistntCourseNameTab.Rows[i]["Active_Flag"].ToString().Equals("1"))
						oMainPanel.Controls.Add(new LiteralControl("<h5 align='left' style='margin-top: 8px;margin-bottom: 8px;'>" + oDistntCourseNameTab.Rows[i]["CourseName"].ToString() + "</h5>"));
					else
						oMainPanel.Controls.Add(new LiteralControl("<h5 align='left' style='margin-top: 8px;margin-bottom: 8px;'>" + Convert.ToString(oDistntCourseNameTab.Rows[i]["CourseName"]) + "<Font class='Mandatory' style='font-size:10px;'> (This " + GetLocalResourceObject("Course") + " is not active)</Font> </h5>"));

					if (oDistntCoursePartChildNameTab != null && oDistntCoursePartChildNameTab.Rows.Count > 0)
					{
						DataView oCorrospondingCPofC = new DataView();
						oCorrospondingCPofC = oDistntCoursePartChildNameTab.DefaultView;
						oCorrospondingCPofC.RowFilter = " pk_Fac_ID=" + oDistntCourseNameTab.Rows[i]["pk_Fac_ID"] + "and pk_Cr_ID=" + oDistntCourseNameTab.Rows[i]["pk_Cr_ID"] + "and pk_MoLrn_ID=" + oDistntCourseNameTab.Rows[i]["pk_MoLrn_ID"] + "and pk_Ptrn_ID=" + oDistntCourseNameTab.Rows[i]["pk_Ptrn_ID"] + "and pk_Brn_ID=" + oDistntCourseNameTab.Rows[i]["pk_Brn_ID"];
						int numberofrecords;
						if (oCorrospondingCPofC.ToTable() != null && oCorrospondingCPofC.ToTable().Rows.Count > 0)
						{                     // Loop 4 Each course Part term of a Particular Course

							for (int j = 0; j < oCorrospondingCPofC.ToTable().Rows.Count; j++)
							{
								seperatorcount++;
								numberofrecords = oCorrospondingCPofC.ToTable().Rows.Count;
								oTable = new Table();
								oTable.Width = Unit.Percentage(100);
								otr = new TableRow();
								otr.Width = Unit.Percentage(100);
								otd = new TableCell();
								otd.CssClass = "clLeftBold";
								otd.Style.Add("padding-left", "20px");
								otd.HorizontalAlign = HorizontalAlign.Left;
								Label lblCoursePartChildName = new Label();
								lblCoursePartChildName.Text = oCorrospondingCPofC.ToTable().Rows[j]["CoursePartChildName"].ToString();
								otd.Controls.Add(lblCoursePartChildName);
								otr.Cells.Add(otd);
								oTable.Rows.Add(otr);
								DvEligiblityFee = new DataView();
								DvEligiblityFee = otblFeeDetails.DefaultView;
								DvEligiblityFee.RowFilter = "fk_FeeType_ID='1' or fk_FeeType_ID='3' and fk_CrPr_Details_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_CrPr_Details_ID"] + "and fk_CrPrCh_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_CrPrCh_ID"] + " and fk_Cr_ID= " + oCorrospondingCPofC.ToTable().Rows[j]["pk_Cr_ID"] + " and fk_Fac_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_Fac_ID"] + "and fk_MoLrn_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_MoLrn_ID"] + "and fk_Ptrn_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_Ptrn_ID"] + "and fk_Brn_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_Brn_ID"] + "and crpr_seq=" + oCorrospondingCPofC.ToTable().Rows[j]["CrPr_seq"] + "and CrPrCh_Seq=" + oCorrospondingCPofC.ToTable().Rows[j]["CrPrCh_Seq"];


								otblEligiblityFeeExamfee = new Table();
								otblEligiblityFeeExamfee.Width = Unit.Percentage(100);
								Label lbl;
								Label lblvalue;
								if ((DvEligiblityFee.ToTable() != null) && (DvEligiblityFee.ToTable().Rows.Count > 0))
								{
									otd = new TableCell();
									otd.Controls.Add(new LiteralControl("<p class='clLeftBold' align='left' style='padding-left:20px; margin-right:5px;'>Eligiblity Fee   </p><p style='float:left'> &nbsp; Receipt Number: " + (DvEligiblityFee.ToTable().Rows[0]["Receipt_no"].ToString().Equals("") ? "-" : DvEligiblityFee.ToTable().Rows[0]["Receipt_no"].ToString()) + " &amp; Date:" + (DvEligiblityFee.ToTable().Rows[0]["ReceiptDate"].ToString().Equals("") ? "-" : DvEligiblityFee.ToTable().Rows[0]["ReceiptDate"].ToString()) + "</p>"));
									otr = new TableRow();
									otr.Cells.Add(otd);
									oTable.Rows.Add(otr);
									double totalElgfee = 0;
									// For Eligiblity Fee Details

									for (int k = 0; k < DvEligiblityFee.ToTable().Rows.Count; k++)
									{
										otbltr = new TableRow();
										otbltr.Width = Unit.Percentage(100);
										otblcell = new TableCell();
										otblcell.Width = Unit.Percentage(30);
										lbl = new Label();
										lbl.Text = DvEligiblityFee.ToTable().Rows[k]["FeeHead"].ToString();
										otblcell.Controls.Add(lbl);
										otblcell.HorizontalAlign = HorizontalAlign.Left;
										otbltr.Cells.Add(otblcell);

										otblcell = new TableCell();
										otblcell.Width = Unit.Percentage(1);
										lblvalue = new Label();
										lblvalue.Text = ":";
										otblcell.Controls.Add(lblvalue);
										otbltr.Cells.Add(otblcell);


										otblcell = new TableCell();
										otblcell.Width = Unit.Percentage(6);
										otblcell.HorizontalAlign = HorizontalAlign.Right;
										lblvalue = new Label();
										lblvalue.Text = DvEligiblityFee.ToTable().Rows[k]["Fee_Amount"].ToString();
										otblcell.Controls.Add(lblvalue);
										otbltr.Cells.Add(otblcell);

										otblcell = new TableCell();
										otbltr.Cells.Add(otblcell);

										otblcell = new TableCell();
										otbltr.Cells.Add(otblcell);

										totalElgfee += Convert.ToDouble(DvEligiblityFee.ToTable().Rows[k]["Fee_Amount"].ToString());

										otblEligiblityFeeExamfee.Rows.Add(otbltr);
									}
									otbltr = new TableRow();
									otbltr.Width = Unit.Percentage(100);
									otblcell = new TableCell();
									otblcell.Width = Unit.Percentage(30);
									lbl = new Label();
									lbl.Text = "Total";
									lbl.Font.Bold = true;
									otblcell.Controls.Add(lbl);
									otblcell.HorizontalAlign = HorizontalAlign.Left;
									otbltr.Cells.Add(otblcell);

									otblcell = new TableCell();
									otblcell.Width = Unit.Percentage(1);
									lblvalue = new Label();
									lblvalue.Text = ":";
									lblvalue.Font.Bold = true;
									otblcell.Controls.Add(lblvalue);
									otbltr.Cells.Add(otblcell);

									otblcell = new TableCell();
									otblcell.Width = Unit.Percentage(6);
									otblcell.HorizontalAlign = HorizontalAlign.Right;
									lblvalue = new Label();
									lblvalue.Text = String.Format("{0:F2}", totalElgfee);
									lblvalue.Font.Bold = true;
									otblcell.Controls.Add(lblvalue);
									otbltr.Cells.Add(otblcell);

									otblcell = new TableCell();
									otbltr.Cells.Add(otblcell);

									otblcell = new TableCell();
									otbltr.Cells.Add(otblcell);

									otblEligiblityFeeExamfee.Rows.Add(otbltr);

									otd = new TableCell();
									otd.ColumnSpan = 2;
									otd.HorizontalAlign = HorizontalAlign.Left;
									otd.Style.Add("padding-left", "50px");
									otd.Controls.Add(otblEligiblityFeeExamfee);
									otr = new TableRow();
									otr.Width = Unit.Percentage(100);
									otr.Cells.Add(otd);
									oTable.Rows.Add(otr);
								}// End if Eligibility fee not available
								else
								{
									otd = new TableCell();
									otd.Controls.Add(new LiteralControl("<p class='clLeftBold' align='left' style='padding-left:20px;'>Eligiblity Fee </p><p style='float:left; font-size:10px;' class='errorNote'>&nbsp;(Fee details not available.)</p>"));
									//otd.Controls.Add(lblerr);
									otr = new TableRow();
									otr.Cells.Add(otd);
									oTable.Rows.Add(otr);
								}

								DvExamFee = new DataView();
								DvExamFee = otblFeeDetails.DefaultView;
								DvExamFee.RowFilter = "fk_FeeType_ID= '2' and fk_CrPr_Details_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_CrPr_Details_ID"] + "and fk_CrPrCh_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_CrPrCh_ID"] + " and fk_Cr_ID= " + oCorrospondingCPofC.ToTable().Rows[j]["pk_Cr_ID"] + " and fk_Fac_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_Fac_ID"] + "and fk_MoLrn_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_MoLrn_ID"] + "and fk_Ptrn_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_Ptrn_ID"] + "and fk_Brn_ID=" + oCorrospondingCPofC.ToTable().Rows[j]["pk_Brn_ID"] + "and crpr_seq=" + oCorrospondingCPofC.ToTable().Rows[j]["CrPr_seq"] + "and CrPrCh_Seq=" + oCorrospondingCPofC.ToTable().Rows[j]["CrPrCh_Seq"];
								otblEligiblityFeeExamfee = new Table();
								otblEligiblityFeeExamfee.Width = Unit.Percentage(100);
								if ((DvExamFee.ToTable() != null) && (DvExamFee.ToTable().Rows.Count > 0))
								{
									string s = DvExamFee.ToTable().Rows[0]["Receipt_no"].ToString();

									otd = new TableCell();
									otd.Controls.Add(new LiteralControl("<p class='clLeftBold' align='left' style='padding-left:20px; margin-right:5px;'>Exam Fee   </p><p style='float:left'> &nbsp; Receipt Number: " + (DvExamFee.ToTable().Rows[0]["Receipt_no"].ToString().Equals("") ? "-" : DvExamFee.ToTable().Rows[0]["Receipt_no"].ToString()) + "&nbsp;&amp; Date:" + (DvExamFee.ToTable().Rows[0]["ReceiptDate"].ToString().Equals("") ? "-" : DvExamFee.ToTable().Rows[0]["ReceiptDate"].ToString()) + "</p>"));
									otr = new TableRow();
									otr.Cells.Add(otd);
									oTable.Rows.Add(otr);
									double totalExmfee = 0;

									// For Exam Fee details
									for (int k = 0; k < DvExamFee.ToTable().Rows.Count; k++)
									{
										otbltr = new TableRow();
										otbltr.Width = Unit.Percentage(100);
										otblcell = new TableCell();
										otblcell.Width = Unit.Percentage(30);
										lbl = new Label();
										lbl.Text = DvExamFee.ToTable().Rows[k]["FeeHead"].ToString();
										otblcell.Controls.Add(lbl);
										otblcell.HorizontalAlign = HorizontalAlign.Left;
										otbltr.Cells.Add(otblcell);

										otblcell = new TableCell();
										otblcell.Width = Unit.Percentage(1);
										lblvalue = new Label();
										lblvalue.Text = ":";
										otblcell.Controls.Add(lblvalue);
										otbltr.Cells.Add(otblcell);


										otblcell = new TableCell();
										otblcell.Width = Unit.Percentage(6);
										otblcell.HorizontalAlign = HorizontalAlign.Right;
										lblvalue = new Label();
										lblvalue.Text = DvExamFee.ToTable().Rows[k]["Fee_Amount"].ToString();
										otblcell.Controls.Add(lblvalue);
										otbltr.Cells.Add(otblcell);

										otblcell = new TableCell();
										otbltr.Cells.Add(otblcell);

										otblcell = new TableCell();
										otbltr.Cells.Add(otblcell);

										totalExmfee += Convert.ToDouble(DvExamFee.Table.Rows[k]["Fee_Amount"].ToString());


										otblEligiblityFeeExamfee.Rows.Add(otbltr);




										//otbltr = new TableRow();
										//otbltr.Width = Unit.Percentage(100);
										//otblcell = new TableCell();
										//otblcell.Width = Unit.Percentage(30);
										//otblcell.HorizontalAlign = HorizontalAlign.Left;
										//lbl = new Label();
										//lbl.Text = DvEligiblityFee.Table.Rows[k]["FeeHead"].ToString();
										//otblcell.Controls.Add(lbl);
										//otbltr.Cells.Add(otblcell);
										//otblcell1 = new TableCell();
										//otblcell1.Width = Unit.Percentage(70);
										//otblcell1.HorizontalAlign = HorizontalAlign.Left;
										//lblvalue = new Label();
										//lblvalue.Text = ":" + DvEligiblityFee.Table.Rows[k]["Fee_Amount"].ToString();
										//totalExmfee += Convert.ToDouble(DvEligiblityFee.Table.Rows[k]["Fee_Amount"].ToString());
										//otblcell1.Controls.Add(lblvalue);
										//otbltr.Cells.Add(otblcell1);
										//otblEligiblityFeeExamfee.Rows.Add(otbltr);
									}

									otbltr = new TableRow();
									otbltr.Width = Unit.Percentage(100);
									otblcell = new TableCell();
									otblcell.Width = Unit.Percentage(30);
									lbl = new Label();
									lbl.Text = "Total";
									lbl.Font.Bold = true;
									otblcell.Controls.Add(lbl);
									otblcell.HorizontalAlign = HorizontalAlign.Left;
									otbltr.Cells.Add(otblcell);

									otblcell = new TableCell();
									otblcell.Width = Unit.Percentage(1);
									lblvalue = new Label();
									lblvalue.Text = ":";
									lblvalue.Font.Bold = true;
									otblcell.Controls.Add(lblvalue);
									otbltr.Cells.Add(otblcell);

									otblcell = new TableCell();
									otblcell.Width = Unit.Percentage(6);
									otblcell.HorizontalAlign = HorizontalAlign.Right;
									lblvalue = new Label();
									lblvalue.Text = String.Format("{0:F2}", totalExmfee);
									lblvalue.Font.Bold = true;
									otblcell.Controls.Add(lblvalue);
									otbltr.Cells.Add(otblcell);

									otblcell = new TableCell();
									otbltr.Cells.Add(otblcell);

									otblcell = new TableCell();
									otbltr.Cells.Add(otblcell);

									otblEligiblityFeeExamfee.Rows.Add(otbltr);

									//otbltr = new TableRow();
									//otbltr.Width = Unit.Percentage(100);
									//otblcell = new TableCell();
									//otblcell.Width = Unit.Percentage(30);
									//otblcell.HorizontalAlign = HorizontalAlign.Left;
									//lbl = new Label();
									//lbl.Text = "Total";
									//lbl.Font.Bold = true;
									//otblcell.Controls.Add(lbl);
									//otbltr.Cells.Add(otblcell);
									//otblcell1 = new TableCell();
									//otblcell1.Width = Unit.Percentage(70);
									//otblcell1.HorizontalAlign = HorizontalAlign.Left;
									//lblvalue = new Label();
									//lblvalue.Text = ":" + totalExmfee.ToString();
									//lblvalue.Font.Bold = true;
									//otblcell1.Controls.Add(lblvalue);
									//otbltr.Cells.Add(otblcell1);
									//otblEligiblityFeeExamfee.Rows.Add(otbltr);

									otd = new TableCell();
									otd.Controls.Add(otblEligiblityFeeExamfee);
									otd.ColumnSpan = 2;
									otd.HorizontalAlign = HorizontalAlign.Left;
									otd.Style.Add("padding-left", "50px");
									otr = new TableRow();
									otr.Width = Unit.Percentage(100);
									otr.Cells.Add(otd);
									oTable.Rows.Add(otr);
								}
								else
								{
									//Label lblerr = new Label();
									//lblerr.Text = "Fee details not available.";
									otd = new TableCell();
									//otd.CssClass = "errorNote";
									//otd.Attributes.Add("style", "font-size: 10px;");
									otd.Controls.Add(new LiteralControl("<p class='clLeftBold' align='left' style='padding-left:20px;'>Exam Fee </p><p style='float:left; font-size:10px;' class='errorNote'>&nbsp;(Fee details not available.)</p>"));
									//otd.ColumnSpan = 2;
									//otd.Controls.Add(lblerr);
									otr = new TableRow();
									otr.Cells.Add(otd);
									oTable.Rows.Add(otr);
								}
								oMainPanel.Controls.Add(oTable);
								if (seperatorcount < numberofrecords)
									oMainPanel.Controls.Add(new LiteralControl("<hr  style='width:50%;align:centers;size:10px;'>"));

							}
						}
						else
						{
							Label lblerr = new Label();
							lblerr.Text = "Fee details not available.";
							lblerr.CssClass = "errorNote";
							lblerr.Attributes.Add("style", "font-size: 10px;");
							oMainPanel.Controls.Add(lblerr);
						}


					}// End of Check of Course Part Term 
					else
					{
						Label inwarddoc = new Label();
						inwarddoc.Text = "Fee details not available.";
						inwarddoc.CssClass = "errorNote";
						inwarddoc.Attributes.Add("style", "font-size: 10px;");
						oMainPanel.Controls.Add(inwarddoc);
					}

					if (i != (oDistntCourseNameTab.Rows.Count - 1))
						oMainPanel.Controls.Add(new LiteralControl("<hr style='width:99%;text-align:center;size:10px;' />"));
				}// End of For Loop of Course

			} // End of Check of Course Table
			else
			{
				Label inwarddoc = new Label();
				inwarddoc.Text = "Fee details not available.";
				inwarddoc.CssClass = "errorNote";
				inwarddoc.Attributes.Add("style", "font-size: 10px;");
				oMainPanel.Controls.Add(inwarddoc);
			}
			tr_InwardDocuments1.Attributes.Add("Style", "Display:Inline;width:100%;");
			tr_InwardDocuments1.Controls.Add(oMainPanel);
		}
		#endregion

		#region Exam details
		private void DisplayExamDetails()
		{
			if (hid_PRN_Number.Value.ToString().Equals("Not Available"))
			{
				lblExamdetailsError.Visible = true;
				lblExamdetailsError.Text = "-- Not Applicable --";

			}
			else
			{
				oDt = oDataSet.Tables[10];
				if (oDt != null && oDt.Rows.Count > 0)
				{
					oGridViewExmdetails.DataSource = oDt;
					oGridViewExmdetails.DataBind();
					oGridViewExmdetails.Visible = true;
					lblExamdetailsError.Visible = false;
				}
				else
				{
					lblExamdetailsError.Visible = true;
					lblExamdetailsError.Text = "Exam status not available.";

				}
			}
		}
		#endregion

		#region showImages

		/// <summary>
		/// Dispalys the photograph and signature of student.
		/// </summary>
		private void showImages()
        {
            try
            {
                oStudent = new clsStudent(clsGetSettings.UniversityID, hid_pk_Year.Value, hid_pk_Student_ID.Value, true);
                //Modified as per Req 102312
                if (oStudent != null)
                {
                    if (oCDNKeys != null)
                    {
                        objCDN = new clsCDN(oCDNKeys.PhotoSignKey);
                        sPathExists = !string.IsNullOrEmpty(oStudent.PhotoPath) ? "Y" : "N";
                        Image1.ImageUrl = objCDN.PhotoSignDisplay(oStudent.PhotoPath, sPathExists, "P");

                        sPathExists = !string.IsNullOrEmpty(oStudent.SignPath) ? "Y" : "N";
                        Image2.ImageUrl = objCDN.PhotoSignDisplay(oStudent.SignPath, sPathExists, "S");
                    }
                    Image1.Visible = true;
                    Image2.Visible = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
          

            if (oStudent.PhotoPath == null && oStudent.SignPath == null)
				tr_PersonalDetails.Attributes.Add("Style", "Display:Inline");

		}
		#endregion

		protected void lnkCancelAdmission_Click(object sender, EventArgs e)
		{
			clsUser user = (clsUser)Session["User"];

			string[] sCourseKey = HidArg.Value.Split('|');

			string sResult = string.Empty;           

			Hashtable oHt = new Hashtable();
			oHt.Add("pk_Uni_ID", clsGetSettings.UniversityID);
			oHt.Add("pk_Year", hid_pk_Year.Value);
			oHt.Add("pk_Student_ID", hid_pk_Student_ID.Value);
			oHt.Add("pk_Fac_ID", sCourseKey[0]);
			oHt.Add("pk_Cr_ID", sCourseKey[1]);
			oHt.Add("pk_MoLrn_ID", sCourseKey[2]);
			oHt.Add("pk_Ptrn_ID", sCourseKey[3]);
			oHt.Add("pk_Brn_ID", sCourseKey[4]);
			oHt.Add("pk_CrPr_Details_ID", sCourseKey[5]);
			oHt.Add("pk_CrPrCh_ID", sCourseKey[6]);
			oHt.Add("CrPr_Seq", sCourseKey[7]);
			oHt.Add("CrPrCh_Seq", sCourseKey[8]);

			oHt.Add("Cancel_Type", sCourseKey[9]);
			oHt.Add("Prn_number ", hid_PRN_Number.Value);
			////oHt.Add("Cancel_Type ", string.Empty);
			oHt.Add("User", user.User_ID);
			oHt.Add("Ref_InstReg_Institute_ID", string.Empty);


			oStudent = new clsStudent();

			sResult = oStudent.CancelAdmission(oHt);
			HidArg.Value = "";

			if (sResult != "Y")
			{
				if (sCourseKey[9] == "ST")
				{
					Response.Redirect("CancelAdmission.aspx", true);
				}
				else
				{
					oViewStudent = new clsStudent();
					oDataSet = new DataSet();
					oHashTable = new Hashtable();
					oHashTable.Add("Uni_ID", clsGetSettings.UniversityID);
					oHashTable.Add("pk_Student_ID", Convert.ToString(hid_pk_Student_ID.Value));
					oHashTable.Add("pk_Year", Convert.ToString(hid_pk_Year.Value));
					if (hid_PRN_Number.Value != "Not Available")
						oHashTable.Add("Prn_Number", hid_PRN_Number.Value);
				
						oDataSet = oViewStudent.GetViewStudentDetails(oHashTable);
						DisplayStudentDetails();
				}

			}
			else
			{
				lblMessage.Text = "Can not cancel the selected admission!";
			}
		}

	}
}

#region Commented Code

// clsCDN objCDN = new clsCDN();
//DataRow dtRow = objCDN.GetCDNKeys("PhotoSign");
//dtRow = objCDN.GetCDNKeys(oCDNKeys.PhotoSignKey);
//HttpWebRequest URLReq;
//HttpWebResponse URLRes;

//if (!string.IsNullOrEmpty(oStudent.PhotoPath ))
//{
//    try
//    {
//        URLReq = (HttpWebRequest)WebRequest.Create(dtRow["Download_Path"].ToString() + oStudent.PhotoPath);
//        URLRes = (HttpWebResponse)URLReq.GetResponse();
//        if (URLRes == null)
//        {
//            Image1.ImageUrl = dtRow["Download_Path"].ToString() + "NoPhoto.JPG";
//        }
//        else
//        {
//            if (URLRes.StatusCode == HttpStatusCode.OK)
//            {
//                Image1.ImageUrl = dtRow["Download_Path"].ToString() + oStudent.PhotoPath;
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


//if (!string.IsNullOrEmpty(oStudent.SignPath))
//{
//    try
//    {
//        URLReq = (HttpWebRequest)WebRequest.Create(dtRow["Download_Path"].ToString() + oStudent.SignPath);
//        URLRes = (HttpWebResponse)URLReq.GetResponse();
//        if (URLRes == null)
//        {
//            Image2.ImageUrl = dtRow["Download_Path"].ToString() + "NoSign.JPG";
//        }
//        else
//        {
//            if (URLRes.StatusCode == HttpStatusCode.OK)
//            {
//                Image2.ImageUrl = dtRow["Download_Path"].ToString() + oStudent.SignPath;
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
//Image1.Visible = true;
//Image2.Visible = true;


//if (oStudent.PhotoPath != null)
//{
//    Image1.ImageUrl = dtRow["Download_Path"].ToString() + oStudent.PhotoPath;//"PhotoSignTemp.ashx?QS_Student_ID=" + hid_pk_Student_ID.Value + "&img=Photo&Year=" + hid_pk_Year.Value;
//    tr_PersonalDetails.Attributes.Add("Style", "Display:Inline");
//    NoPhoto.Visible = false;
//    Image1.Visible = true;
//}
//else
//{
//    NoPhoto.Visible = true;
//    Image1.Visible = false;
//}

//if (oStudent.SignPath != null)
//{
//    Image2.ImageUrl = dtRow["Download_Path"].ToString() + oStudent.SignPath;// "PhotoSignTemp.ashx?QS_Student_ID=" + hid_pk_Student_ID.Value + "&img=Sign&Year=" + hid_pk_Year.Value;
//    tr_PersonalDetails.Attributes.Add("Style", "Display:Inline");
//    Image2.Visible = true;
//    NoSign.Visible = false;
//}
//else
//{
//    Image2.Visible = false;
//    NoSign.Visible = true;
//}
#endregion

