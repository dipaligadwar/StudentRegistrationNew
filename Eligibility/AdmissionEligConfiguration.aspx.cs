using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Classes;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Xml;
using ServerSideValidations;
using AjaxControlToolkit;
using System.Threading;
using System.Globalization;
using System.Configuration;

namespace StudentRegistration.Eligibility
{
	public partial class AdmissionEligConfiguration : System.Web.UI.Page
	{
		#region Variable declaration

		Hashtable oHt = null;
		DataTable oDt = null;
		clsAdmissionElgConfig oclsAdmissionElgConfig = null;
		clsUser oclsUser = null;
		int index = 0;
		StringBuilder oSB = null;
		int HeaderCount = 0;
		Validation oValidate;
		CourseRepository crRepository = new CourseRepository();
		clsCommon oCommon = null;
		DataTable oDT = null;
		private string[] IDs_List = new string[3];
		#region Variable required while coming from Previous Page i.e. AdmissionEligConfiguration__1.aspx
		string sAcademicYearID = string.Empty;
		string sUniID = string.Empty;
		string sFacID = string.Empty;
		string sCrID = string.Empty;
		string sMoLrnID = string.Empty;
		string sPtrnID = string.Empty;
		string sBrnID = string.Empty;
		string sCrPrDetailsID = string.Empty;
		string sCrPrChID = string.Empty;
		string sCurrentAndPreviousKeys = string.Empty;
		string sAdmissionElgTypeID = string.Empty;
		string sResultConsideration = string.Empty;
		#endregion
		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			Ajax.Utility.RegisterTypeForAjax(typeof(Student.clsStudent), this.Page);
			oclsUser = (clsUser)Session["user"];
			DataTable dtInst = new DataTable();
			lblErrorMessage.CssClass = "";
			lblErrorMessage.Text = "";
			divtable.Visible = false;

			lblNote.Visible = false;
			lblNote.Text = "";
			if (!IsPostBack)
			{
				//While coming from Previous Page i.e. AdmissionEligConfiguration__1.aspx thru Edit in Grid View
				if (Request.QueryString["frmPrevious"] != null)
				{
					HtmlInputHidden[] hid = new HtmlInputHidden[12];
					hid[0] = hidUniID;
					hid[1] = hidFacID;
					hid[2] = hidCrID;
					hid[3] = hidMoLrnID;
					hid[4] = hidPtrnID;
					hid[5] = hidBrnID;
					hid[6] = hidCrPrDetailsID;
					hid[7] = hidCrPrChID;
					hid[8] = hidAcademicYearID;
					hid[9] = hidCurrentAndPreviousKeys;
					hid[10] = hidAdmissionElgTypeID;
					hid[11] = hidResultConsideration;
					oCommon = new clsCommon();
					oCommon.setHiddenVariablesMPC(ref hid);

					sAcademicYearID = hidAcademicYearID.Value;
					sUniID = hidUniID.Value;
					sFacID = hidFacID.Value;
					sCrID = hidCrID.Value;
					sMoLrnID = hidMoLrnID.Value;
					sPtrnID = hidPtrnID.Value;
					sBrnID = hidBrnID.Value;
					sCrPrDetailsID = hidCrPrDetailsID.Value;
					sCrPrChID = hidCrPrChID.Value;
					sAdmissionElgTypeID = hidAdmissionElgTypeID.Value;
					sCurrentAndPreviousKeys = hidCurrentAndPreviousKeys.Value;
					sResultConsideration = hidResultConsideration.Value;
					FillAlltheFields(sAcademicYearID, sUniID, sFacID, sCrID, sMoLrnID, sPtrnID, sBrnID, sCrPrDetailsID, sCrPrChID, sCurrentAndPreviousKeys, sAdmissionElgTypeID, sResultConsideration);
				}
				else
				{
					HtmlInputHidden[] hid = new HtmlInputHidden[1];
					hid[0] = hidAcademicYearID;
					oCommon = new clsCommon();
					oCommon.setHiddenVariablesMPC(ref hid);
					FetchUniversityWiseFacultyList(hidFacID.Value);
				}
			}

			FillAcademicYear(hidAcademicYearID.Value);
			ddlAcadYear.Enabled = false;
		}

		private void FillAlltheFields(string sAcademicYearID, string sUniID, string sFacID, string sCrID, string sMoLrnID, string sPtrnID, string sBrnID, string sCrPrDetailsID, string sCrPrChID, string sCurrentAndPreviousKeys, string sAdmissionElgTypeID, string sResultConsideration)
		{
			FillAcademicYear(sAcademicYearID);
			ddlAcadYear.Enabled = false;
			FetchUniversityWiseFacultyList(sFacID);
			ddlFacDesc.Enabled = false;
			FillDropDowns(sFacID, sCrID, sMoLrnID, sPtrnID);
			ddlCrDesc.Enabled = false;
			FillBranch(sUniID, null, sFacID, sCrID, sMoLrnID, sPtrnID);
			btnSubmit.Enabled = false;
			ddlCrBrnDesc.Enabled = false;
			tblAdmissionEligibility.Visible = true;
			rblResultConsideration.Enabled = false;
			if (!IsPostBack)
			{
				SelectItem(rdbPartOrTerm, sAdmissionElgTypeID);
				rdbPartOrTerm.Enabled = false;
			}

			if (sResultConsideration.Equals("1"))
			{
				FillCoursePart(sUniID, null, sFacID, sCrID, sMoLrnID, sPtrnID, sBrnID);
				FillPartTerm(sUniID, null, sFacID, sCrID, sMoLrnID, sPtrnID, sBrnID, sCrPrDetailsID, sCurrentAndPreviousKeys);
				FillTable();
				ddlCrPrDetailsDesc.Enabled = false;
				ddlCrPrChDesc.Enabled = false;
			}
			else
			{
				tblAdmissionEligibility.Visible = false;
				SelectItem(rblResultConsideration, sResultConsideration);
			}
		}

		private void SelectItem(WebControl control, string sValue)
		{
			string typeName = control.GetType().Name;
			ListItem oLi = null;
			switch (typeName)
			{
				case "DropDownList":
					oLi = ((DropDownList)control).Items.FindByValue(sValue);
					if (oLi != null)
					{
						oLi.Selected = true;
					}
					break;
				case "RadioButtonList":
					oLi = ((RadioButtonList)control).Items.FindByValue(sValue);
					if (oLi != null)
					{
						oLi.Selected = true;
					}
					break;

			}
		}

		#region Fill Academic Year
		private void FillAcademicYear(string sAcademicYearID)
		{
			oDT = new DataTable();
			clsAcademicYear objAcadYear = new clsAcademicYear();
			oDT = objAcadYear.ListAcademicYear();
			ViewState["AcademicYear"] = oDT;
			oCommon = new clsCommon();
			oCommon.fillDropDown(ddlAcadYear, oDT, string.Empty, "Year", "pk_AcademicYear_ID", "---- Select ----");

			if (oCommon != null)
			{
				oCommon = null;
			}
			// if (!IsPostBack)

			SelectItem(ddlAcadYear, sAcademicYearID);
			//if (!string.IsNullOrEmpty(sAcademicYearID))
			//{
			//    //ddlAcadYear.ClearSelection();
			//    ListItem oLi = ddlAcadYear.Items.FindByValue(sAcademicYearID);
			//        if (oLi != null)
			//            oLi.Selected = true;
			//}
		}
		#endregion

		#region Fetch University Wise Faculty List

		public void FetchUniversityWiseFacultyList(string sFacID)
		{
			DataTable listFaculty = crRepository.LaunchedUniversityWiseFacultyList(Convert.ToInt64(clsGetSettings.UniversityID));
			try
			{
				if (listFaculty != null)
				{
					ddlFacDesc.DataSource = listFaculty;
					ddlFacDesc.DataTextField = "text";
					ddlFacDesc.DataValueField = "value";
					ddlFacDesc.DataBind();
					System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--- Select ---", "-1");
					ddlFacDesc.Items.Insert(0, li);
				}

				if (!IsPostBack)
				{
					SelectItem(ddlFacDesc, sFacID);
				}

				//if (!string.IsNullOrEmpty(sFacID))
				//{

				//    ListItem oLi = ddlFacDesc.Items.FindByValue(sFacID);
				//    if (oLi != null)
				//        oLi.Selected = true;
				//}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		#endregion



		protected void ddlFacDesc_SelectedIndexChanged(object sender, EventArgs e)
		{

			FillDropDowns(hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value);
		}

		private void FillDropDowns(string sFacID, string sCrID, string sMoLrnID, string sPtrnID)
		{
			ddlCrBrnDesc.Items.Clear();
			ddlCrPrDetailsDesc.Items.Clear();
			ddlCrPrChDesc.Items.Clear();
			ddlCrBrnDesc.Items.Insert(0, new ListItem("--- Select ---", "-1"));
			ddlCrPrDetailsDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
			ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));

			FillFacultyCourseMoLrnPatternName(clsGetSettings.UniversityID, string.Empty, ddlFacDesc.SelectedValue, sFacID, sCrID, sMoLrnID, sPtrnID);

			ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlFacDesc);
		}

		#region  FillFacultyCourseMoLrnPatternName Function
		private void FillFacultyCourseMoLrnPatternName(string Uni_ID, string Inst_ID, string Faculty_ID, string sFacID, string sCrID, string sMoLrnID, string sPtrnID)
		{
			ddlCrDesc.Items.Clear();
			oDT = new System.Data.DataTable();
			oCommon = new clsCommon();
			try
			{
				oDT = crRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(Uni_ID, Faculty_ID);
				oCommon.fillDropDown(ddlCrDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
				oCommon = null;
				if (!string.IsNullOrEmpty(sFacID) && !string.IsNullOrEmpty(sCrID) && !string.IsNullOrEmpty(sMoLrnID) && !string.IsNullOrEmpty(sPtrnID))
				{
					string sFacCrMrnPrtn = sFacID + "-" + sCrID + "-" + sMoLrnID + "-" + sPtrnID;
					//ListItem oLi = ddlCrDesc.Items.FindByValue(sFacCrMrnPrtn);
					//if (oLi != null)
					//    oLi.Selected = true;
					//if (!IsPostBack)
					SelectItem(ddlCrDesc, sFacCrMrnPrtn);
				}

			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		#endregion

		protected void ddlCrDesc_SelectedIndexChanged(object sender, EventArgs e)
		{
			////This will Fill Correspondance Branch Drop Down
			getFacCrMoLrnPtrnID(); // This is needed for normal Flow
			FillBranch(clsGetSettings.UniversityID, string.Empty, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value);
		}


		#region Fill Branch Function
		private void FillBranch(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID)
		{
			ddlCrPrDetailsDesc.Items.Clear();
			ddlCrPrChDesc.Items.Clear();
			ddlCrPrDetailsDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
			ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
			////Call for Seting FacultyID , CourseID ,MoLrnID and PatternID

			ddlCrBrnDesc.Items.Clear();
			oDT = new System.Data.DataTable();
			try
			{
				oDT = crRepository.ListCourseModeOfLearningPatternWiseLaunchedBranches(long.Parse(Uni_ID), long.Parse(Fac_ID), long.Parse(Cr_ID), long.Parse(Molrn_ID), long.Parse(Ptrn_ID));

				if (oDT.Rows.Count > 0)
				{
					oCommon = new clsCommon();
					if (oDT.Rows.Count == 1)
					{
						if (Convert.ToString(oDT.Rows[0]["Text"]) == "No Branch")
						{
							ListItem li = new ListItem();
							li.Text = "No Branch Available";
							li.Value = "0";
							ddlCrBrnDesc.Items.Add(li);
							FillCoursePart(Uni_ID, Inst_ID, Fac_ID, Cr_ID, Molrn_ID, Ptrn_ID, "0");
						}
						else
						{
							oCommon.fillDropDown(ddlCrBrnDesc, oDT, "-1", "Text", "Value", "---- Select ----");
							SelectItem(ddlCrBrnDesc, hidBrnID.Value);
						}
					}
					else
					{
						oCommon.fillDropDown(ddlCrBrnDesc, oDT, "-1", "Text", "Value", "---- Select ----");
						SelectItem(ddlCrBrnDesc, hidBrnID.Value);
					}

					oCommon = null;
				}
				else
				{
					if (ddlCrDesc.SelectedIndex == 0)
					{
						ListItem li = new ListItem();
						li.Text = "---- Select ----";
						li.Value = "-1";
						ddlCrBrnDesc.Items.Add(li);
					}
					else
					{
						ListItem li = new ListItem();
						li.Text = "No Branch Available";
						li.Value = "0";
						ddlCrBrnDesc.Items.Add(li);
					}
				}
			}
			catch (Exception e)
			{
			}

			ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrDesc);
		}
		#endregion

		#region Fill Course Part Function
		private void FillCoursePart(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID, string Brn_ID)
		{
			ddlCrPrChDesc.Items.Clear();

			ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
			getFacCrMoLrnPtrnID();

			ddlCrPrDetailsDesc.Items.Clear();
			oDT = new System.Data.DataTable();
			oCommon = new clsCommon();

			// Admission Eligibility :Fetch Course Part 
			//Course Part having only one child should be displayed except the first one...
			//Course Part having more than one child should be displayed . Eg. MA-I and MA-II both should be displayed as both parts contains two terms
			Hashtable oHt = new Hashtable();
			oHt["UniID"] = Uni_ID.Trim();
			oHt["FacID"] = Fac_ID.Trim();
			oHt["CrID"] = Cr_ID.Trim();
			oHt["MoLrnID"] = Molrn_ID.Trim();
			oHt["PtrnID"] = Ptrn_ID.Trim();
			oHt["BrnID"] = Brn_ID.Trim();
			if (Request.QueryString["frmPrevious"] != null)
			{
				oHt["PartOrTerm"] = hidAdmissionElgTypeID.Value;
			}
			else
			{
				oHt["PartOrTerm"] = rdbPartOrTerm.SelectedValue;
			}
			clsAdmissionElgConfig oAdmissionElgConfig = new clsAdmissionElgConfig();
			oDT = oAdmissionElgConfig.GetCoursePartForAdmissionElg(oHt);
			if (oDT.Rows.Count == 0)
			{
				lblNote.Text = "There are no " + lblCr.Text + "-Parts available for the selected course for whom the Admission Eligibility can be configured.";
				lblNote.Visible = true;
			}
			else
			{
				lblNote.Text = "";
				lblNote.Visible = false;

			}
			oCommon.fillDropDown(ddlCrPrDetailsDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
			//if(!IsPostBack)
			SelectItem(ddlCrPrDetailsDesc, sCrPrDetailsID);

			ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrBrnDesc);

		}

		#endregion

		protected void ddlCrBrnDesc_SelectedIndexChanged(object sender, EventArgs e)
		{
			FillCoursePart(clsGetSettings.UniversityID, string.Empty, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(ddlCrBrnDesc.SelectedValue));
		}

		protected void ddlCrPrDetailsDesc_SelectedIndexChanged(object sender, EventArgs e)
		{
			////This will Fill Correspondance Course Part Term Details Drop Down
			FillPartTerm(clsGetSettings.UniversityID, string.Empty, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(ddlCrBrnDesc.SelectedItem.Value), Convert.ToString(ddlCrPrDetailsDesc.SelectedItem.Value), hidCurrentAndPreviousKeys.Value);
		}

		#region FillPartTerm

		private void FillPartTerm(string Uni_ID, string Inst_ID, string Fac_ID, string Cr_ID, string Molrn_ID, string Ptrn_ID, string Brn_ID, string CrPrDetails_ID, string sCurrentAndPreviousKeys)
		{
			getFacCrMoLrnPtrnID();
			ddlCrPrChDesc.Items.Clear();
			oDT = new System.Data.DataTable();
			oCommon = new clsCommon();

			try
			{

				Hashtable oHt = new Hashtable();
				oHt["UniID"] = Uni_ID.Trim();
				oHt["FacID"] = Fac_ID.Trim();
				oHt["CrID"] = Cr_ID.Trim();
				oHt["MoLrnID"] = Molrn_ID.Trim();
				oHt["PtrnID"] = Ptrn_ID.Trim();
				oHt["BrnID"] = Brn_ID.Trim();
				oHt["CrPrDetailsID"] = CrPrDetails_ID.Trim();
				if (Request.QueryString["frmPrevious"] != null)
				{
					oHt["PartOrTerm"] = hidAdmissionElgTypeID.Value;
				}
				else
				{
					oHt["PartOrTerm"] = rdbPartOrTerm.SelectedValue;
				}


				// Admission Eligibility 
				// Get Terms except first part or Term
				clsAdmissionElgConfig oAdmissionElgConfig = new clsAdmissionElgConfig();
				oDT = oAdmissionElgConfig.GetCoursePartTermForAdmissionElg(oHt);
				oCommon.fillDropDown(ddlCrPrChDesc, oDT, string.Empty, "Text", "Value", "--- Select ---");
				if (!string.IsNullOrEmpty(sCurrentAndPreviousKeys))
				{
					// if (!IsPostBack)
					SelectItem(ddlCrPrChDesc, sCurrentAndPreviousKeys);
				}
			}
			catch (Exception Ex5)
			{
				throw new Exception(Ex5.Message);
			}

			//ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrPrChDesc);
		}

		#endregion

		#region btnNext_Click

		//protected void btnProceed_Click(object sender, EventArgs e)
		//{
		//   FillTable();
		//}

		#endregion
		#region getFacCrMoLrnPtrnID function
		private void getFacCrMoLrnPtrnID()
		{
			if (Convert.ToString(ddlCrDesc.SelectedValue) != "0")
			{
				IDs_List = Convert.ToString(ddlCrDesc.SelectedValue).Split('-');
				hidFacID.Value = Convert.ToString(IDs_List[0]).Trim();
				hidCrID.Value = Convert.ToString(IDs_List[1]).Trim();
				hidMoLrnID.Value = Convert.ToString(IDs_List[2]).Trim();
				hidPtrnID.Value = Convert.ToString(IDs_List[3]).Trim();
			}
			else
			{
				if (Convert.ToString(ddlCrDesc.SelectedValue) == "0")
				{
					hidCrID.Value = "0";
					hidMoLrnID.Value = "0";
					hidPtrnID.Value = "0";
				}
				hidFacID.Value = ddlFacDesc.SelectedValue;
			}
		}

		#endregion
		protected void ddlCrPrChDesc_SelectedIndexChanged(object sender, EventArgs e)
		{
			FillTable();
		}

		private void FillTable()
		{
			hidXml.Value = "";
			btn_Save.Enabled = true;
			btnDelete.Enabled = true;
			if (hidAdmissionElgTypeID.Value == string.Empty)
			{
				hidAdmissionElgTypeID.Value = rdbPartOrTerm.SelectedValue;
			}
			if (!ddlCrPrChDesc.SelectedValue.Equals("0") && !string.IsNullOrEmpty(ddlCrPrChDesc.SelectedValue))
			{
				hidPreviousAndCurrentCrKeys.Value = ddlCrPrChDesc.SelectedValue;
				string[] arrPreviousAndCurrentCrKeys = ddlCrPrChDesc.SelectedValue.Split('_');
				hidCurrentCrKeys.Value = arrPreviousAndCurrentCrKeys[0];
				hidPreviousCrKeys.Value = arrPreviousAndCurrentCrKeys[1];
			}

			// DropDownList ddlCourse = (DropDownList)YCMOU.FindControl("ddlTerm");
			lttitle.Text = "Define Admission Eligibility Criteria for " + ddlCrPrChDesc.SelectedItem.Text;
			if (!ddlCrPrChDesc.SelectedValue.Equals("0") && !string.IsNullOrEmpty(ddlCrPrChDesc.SelectedValue))
			{
				// hidPreviousAndCurrentCrKeys.Value = ddlCrPrChDesc.SelectedValue;
				string[] arrPreviousAndCurrentCrKeys = ddlCrPrChDesc.SelectedValue.Split('_');
				oHt = CreateHashTable(arrPreviousAndCurrentCrKeys);
				oclsAdmissionElgConfig = new clsAdmissionElgConfig();
				string[] sResultArr = new string[7];
				//ELGV2_Coursepartwise_Eligibility_Configuration
				sResultArr = oclsAdmissionElgConfig.IsPreviousConfigurationExists(oHt);
				hidTermOrPartNames.Value = sResultArr[4];
				if (sResultArr[5].Equals("Y"))
				{
					if (sResultArr[0].Equals("Y") && sResultArr[1].Equals("N"))
					{
						btn_Save.Enabled = true;
						btnDelete.Enabled = true;
						oDt = oclsAdmissionElgConfig.GetAdmissionElgConfigurationsForCourse(oHt);
						bool isNull = false;
						if (string.IsNullOrEmpty(oDt.Rows[0]["PreviousAdmissionElgConfiguration"].ToString()))
						{
							isNull = true;
						}
						CreateTable(isNull, oDt.Rows[0]["PreviousAdmissionElgConfiguration"].ToString(), oDt.Rows[0]["CurrentAdmissionElgConfiguration"].ToString());
						divtable.Visible = true;
					}
					else
					{

						if (sResultArr[0].Equals("Y") && sResultArr[1].Equals("Y"))
						{

							lblErrorMessage.Text = "You cannot edit the configuration of the selected Part/Term as the Next Course Part/Term <b><font style='color:Black'>" + sResultArr[3] + " </font></b>is already configured.";
							lblErrorMessage.Visible = true;
							btnDelete.Enabled = false;
							btn_Save.Enabled = false;
							// duplicacy of code
							oDt = oclsAdmissionElgConfig.GetAdmissionElgConfigurationsForCourse(oHt);
							bool isNull = false;
							if (string.IsNullOrEmpty(oDt.Rows[0]["PreviousAdmissionElgConfiguration"].ToString()))
							{
								isNull = true;
							}
							CreateTable(isNull, oDt.Rows[0]["PreviousAdmissionElgConfiguration"].ToString(), oDt.Rows[0]["CurrentAdmissionElgConfiguration"].ToString());
							divtable.Visible = true;
							//end
						}
						else
						{
							lblErrorMessage.Text = "You cannot configure as the previous Course part/term <b><font style='color:Black'> " + sResultArr[2] + " </font></b>is not configured.";
							lblErrorMessage.Visible = true;
							btnDelete.Enabled = false;
							btn_Save.Enabled = false;
						}
					}
				}
				else
				{
					lblErrorMessage.Text = "Admission eligibility is defined  <b><font style='color:Black;font-size:large;' >";
					lblErrorMessage.Text += rdbPartOrTerm.SelectedValue.Equals("1") ? "term wise" : "part wise";
					lblErrorMessage.Text += "</font></b> up to <b><font style='color:Black'> " + sResultArr[6] + "</font></b>. Please delete the existing configurations and redefine.";
					btn_Save.Enabled = false;
					btnDelete.Enabled = false;
				}

			}
			//btn_Save.Enabled = false;
			// btnDelete.Enabled = false;
		}

		private void CreateTableAndHeader(int HeaderCount1)
		{
			oSB.Append("<table  rules='all' cellpadding='2px' style='border: 1px solid black;border-collapse:collapse;margin:5px;' width='99%'>");
			oSB.Append("<tr>");
			string[] sarrTermOrPartNames = new string[HeaderCount1 + 1];
			sarrTermOrPartNames = hidTermOrPartNames.Value.Split('|');
			for (int i = 0; i < HeaderCount1 + 1; i++)
			{
				oSB.Append("<th>");
				// oSB.Append("Term"+(i+1).ToString());
				oSB.Append(sarrTermOrPartNames[i]);
				oSB.Append("</th>");
			}
			//oSB.Append("<th>");
			//oSB.Append("Current Part/Term Status");
			//oSB.Append("</th>");

			oSB.Append("<th>");
			oSB.Append("Admission Eligibility");
			oSB.Append("</th>");
			oSB.Append("</tr>");
		}

		private bool isConfigured(XmlNode xn, string CurrentXml)
		{
			XmlDocument o = new XmlDocument();
			o.LoadXml(CurrentXml);
			XmlNodeList ol = o.SelectNodes("Elibilities/Eligibility");
			foreach (XmlNode node in ol)
			{
				if (node.OuterXml.Equals(xn.OuterXml))
				{
					return true;
				}
			}
			return false;
		}

		private void CreateTable(bool isNULL, string Previousxml, string CurrentXml)
		{
			// string sXML = "<?xml version='1.0' encoding='utf-8' ?><Elibilities TermCount='4'><Eligibility><Term1>1</Term1><Term2>2</Term2><Term3>3</Term3><Term4>1</Term4></Eligibility><Eligibility><Term1>1</Term1><Term2>2</Term2><Term3>2</Term3><Term4>1</Term4></Eligibility><Eligibility><Term1>1</Term1><Term2>1</Term2><Term3>1</Term3><Term4>1</Term4></Eligibility></Elibilities>";
			oSB = new StringBuilder();

			int rowCount = 1;
			if (!isNULL)
			{
				string sXML = Previousxml;
				XmlDocument xml = new XmlDocument();
				xml.LoadXml(sXML);
				XmlNode xn = xml.SelectSingleNode("Elibilities");
				HeaderCount = Convert.ToInt32(xn.Attributes["TermCount"].Value);
				//hidTermOrPartNames.Value = "";
				hidTermOrPartNames.Value = xn.Attributes["TermOrPartNames"].Value + "|" + hidTermOrPartNames.Value;
				//hidTermOrPartNames.Value = ((DropDownList)YCMOU.FindControl("ddlTerm")).SelectedItem.Text;
				XmlNodeList xnl = xml.SelectNodes("Elibilities/Eligibility");
				CreateTableAndHeader(HeaderCount);

				foreach (XmlNode node in xnl)
				{
					foreach (Classes.clsAdmissionElgConfig.ResultStatus item in Enum.GetValues(typeof(Classes.clsAdmissionElgConfig.ResultStatus)))
					{
						oSB.Append("<tr class='row" + rowCount.ToString() + "'>");
						XmlDocument oXDoc = new XmlDocument();
						XmlNode oXN = oXDoc.CreateNode(XmlNodeType.Element, "Eligibility", "");
						XmlNode oXNTerm = null;
						int i = 1;
						foreach (XmlNode childNode in node.ChildNodes)
						{
							oSB.Append("<td id='" + PartOrTermWise_TermOrEligibilitiesTagsID(childNode.Attributes["id"].Value) + "'>" + ((Classes.clsAdmissionElgConfig.ResultStatus)Convert.ToInt32(childNode.InnerText)).ToString() + "</td>");
							oXNTerm = oXN.AppendChild(oXDoc.CreateNode(XmlNodeType.Element, "Term" + i.ToString(), ""));
							AddAttributetoXML(oXDoc, oXNTerm, "id", PartOrTermWise_TermOrEligibilitiesTagsID(childNode.Attributes["id"].Value));
							oXNTerm.InnerText = childNode.InnerText;
							oXN.AppendChild(oXNTerm);
							i++;
						}
						oSB.Append("<td id='" + PartOrTermWise_TermOrEligibilitiesTagsID(hidPreviousCrKeys.Value) + "'>" + item.ToString() + "</td>");
						oXNTerm = oXN.AppendChild(oXDoc.CreateNode(XmlNodeType.Element, "Term" + i.ToString(), ""));
						oXNTerm.InnerText = item.GetHashCode().ToString();
						AddAttributetoXML(oXDoc, oXNTerm, "id", PartOrTermWise_TermOrEligibilitiesTagsID(hidPreviousCrKeys.Value));
						oXN.AppendChild(oXNTerm);
						bool b = false;
						if (!string.IsNullOrEmpty(CurrentXml))
						{
							b = isConfigured(oXN, CurrentXml);
						}
						string schecked = string.Empty;

						if (b)
						{
							schecked = "checked='checked'";
							oSB.Append("<td><input type='radio' name='EligibilityradioButtonList" + rowCount.ToString() + "' value='N'>Not Eligibile<input type='radio' name='EligibilityradioButtonList" + rowCount.ToString() + "' value='E' " + schecked + ">Eligibile </td>");
						}
						else
						{
							oSB.Append("<td><input type='radio' name='EligibilityradioButtonList" + rowCount.ToString() + "' value='N'checked='checked' >Not Eligibile<input type='radio' name='EligibilityradioButtonList" + rowCount.ToString() + "' value='E' >Eligibile </td>");
						}
						oSB.Append("</tr>");
						rowCount++;
					}
				}

			}
			else
			{
				CreateTableAndHeader(HeaderCount);
				XmlDocument oXDoc = null;
				XmlNode oXN = null;
				XmlNode oXNTerm = null;
				int i = 1;
				if (!string.IsNullOrEmpty(CurrentXml))
				{
					oXDoc = new XmlDocument();
					oXN = oXDoc.CreateNode(XmlNodeType.Element, "Eligibility", "");
				}

				foreach (Classes.clsAdmissionElgConfig.ResultStatus item in Enum.GetValues(typeof(Classes.clsAdmissionElgConfig.ResultStatus)))
				{
					//oSB.Append("<tr class='row" + rowCount.ToString() + "'><td>" + item.ToString() + "</td>");
					oSB.Append("<tr class='row" + rowCount.ToString() + "'><td id='" + PartOrTermWise_TermOrEligibilitiesTagsID(hidPreviousCrKeys.Value) + "'>" + item.ToString() + "</td>");
					bool b = false;
					if (!string.IsNullOrEmpty(CurrentXml))
					{
						oXNTerm = oXN.AppendChild(oXDoc.CreateNode(XmlNodeType.Element, "Term" + i.ToString(), ""));
						oXNTerm.InnerText = item.GetHashCode().ToString();
						AddAttributetoXML(oXDoc, oXNTerm, "id", PartOrTermWise_TermOrEligibilitiesTagsID(hidPreviousCrKeys.Value));
						oXN.AppendChild(oXNTerm);
						b = isConfigured(oXN, CurrentXml);
					}
					string schecked = string.Empty;

					if (b)
					{
						schecked = "checked='checked'";
						oSB.Append("<td><input type='radio' name='EligibilityradioButtonList" + rowCount.ToString() + "' value='N'>Not Eligibile<input type='radio' name='EligibilityradioButtonList" + rowCount.ToString() + "' value='E' " + schecked + ">Eligibile </td>");
					}
					else
					{
						oSB.Append("<td><input type='radio' name='EligibilityradioButtonList" + rowCount.ToString() + "' value='N' checked='checked'>Not Eligibile<input type='radio' name='EligibilityradioButtonList" + rowCount.ToString() + "' value='E'>Eligibile </td>");
					}
					oSB.Append("</tr>");
					rowCount++;
					if (!string.IsNullOrEmpty(CurrentXml))
					{
						oXN.RemoveChild(oXNTerm);
					}
				}
			}

			hidRowCount.Value = (rowCount - 1).ToString();
			oSB.Append("</table>");
			ph.Controls.Add(new LiteralControl(oSB.ToString()));
			btn_Save.Visible = true;
		}

		private bool isEligibile(string s, string cXML)
		{
			return true;
		}

		private Hashtable CreateHashTable(string[] arr)
		{
			oHt = new Hashtable();
			string[] arrCurrentCrKeys = arr[0].Split('-');
			string[] arrPreviousCrKeys = arr[1].Split('-');

			Setindex();

			oHt["AcademicYearID"] = ddlAcadYear.SelectedValue;
			oHt["UniID"] = arrCurrentCrKeys[index];
			oHt["FacID"] = arrCurrentCrKeys[++index];
			oHt["CrID"] = arrCurrentCrKeys[++index];
			oHt["MoLrnID"] = arrCurrentCrKeys[++index];
			oHt["PtrnID"] = arrCurrentCrKeys[++index];
			oHt["BrnID"] = arrCurrentCrKeys[++index];
			oHt["CrPrDetailsID"] = arrCurrentCrKeys[++index];
			oHt["CrPrChID"] = arrCurrentCrKeys[++index];

			Setindex();

			oHt["PreviousUniID"] = arrPreviousCrKeys[index];
			oHt["PreviousFacID"] = arrPreviousCrKeys[++index];
			oHt["PreviousCrID"] = arrPreviousCrKeys[++index];
			oHt["PreviousMoLrnID"] = arrPreviousCrKeys[++index];
			oHt["PreviousPtrnID"] = arrPreviousCrKeys[++index];
			oHt["PreviousBrnID"] = arrPreviousCrKeys[++index];
			oHt["PreviousCrPrDetailsID"] = arrPreviousCrKeys[++index];
			// if(rdbPartOrTerm.SelectedValue.Equals("2"))
			oHt["PreviousCrPrChID"] = arrPreviousCrKeys[++index];
			// else
			// oHt["PreviousCrPrChID"] = "0";
			if (Request.QueryString["frmPrevious"] != null)
			{
				oHt["PartOrTerm"] = hidAdmissionElgTypeID.Value;
			}
			else
			{
				oHt["PartOrTerm"] = rdbPartOrTerm.SelectedValue;
			}

			Setindex();

			//oHt["AorT"] = YCMOU.AorT;

			oHt["xml"] = hidXml.Value;
			oHt["xmlDC"] = hidXMLDc.Value;
			if (oclsUser != null)
			{
				oHt["User"] = oclsUser.User_ID;
			}
			else
			{
				HttpContext.Current.Response.Write(clsGetSettings.LogOffMessage);
				HttpContext.Current.Response.End();
			}

			return oHt;
		}

		private void Setindex()
		{
			index = 0;
		}

		private void setXML(string xml)
		{
			XmlDocument oXmlDocument = new XmlDocument();
			oXmlDocument.LoadXml(xml);
			XmlNodeList xnl = oXmlDocument.SelectNodes("Elibilities/Eligibility");

			foreach (XmlNode node in xnl)
			{

				foreach (XmlNode childNode in node.ChildNodes)
				{
					foreach (Classes.clsAdmissionElgConfig.ResultStatus item in Enum.GetValues(typeof(Classes.clsAdmissionElgConfig.ResultStatus)))
					{
						if (childNode.InnerText.Equals(item.ToString()))
						{
							childNode.InnerText = item.GetHashCode().ToString();
							break;
						}
					}
				}

			}

			hidXml.Value = oXmlDocument.OuterXml;
		}

		protected void btn_Save_Click(object sender, EventArgs e)
		{
			ServerSideValidations();
			if (oValidate.ValidateMe(lblErrorMessage))
			{
				string[] arrPreviousAndCurrentCrKeys = ddlCrPrChDesc.SelectedValue.Split('_');
				setXML(hidXml.Value);
				oHt = CreateHashTable(arrPreviousAndCurrentCrKeys);
				oclsAdmissionElgConfig = new clsAdmissionElgConfig();
				string[] status = new string[2];
				status = oclsAdmissionElgConfig.SaveAdmissionElgConfigurationsForCourse(oHt);
				if (status[0].Equals("E"))
				{
					lblErrorMessage.Text = "Information Cant be processed.Please Contact Administrator.";
				}
				else if (status[1].Equals("Y"))
				{
					lblNote.Visible = true;
					lblNote.Text = "Information saved successfully.";
					FillTable();
				}
				else
				{
					lblNote.Visible = true;
					lblNote.Text = "Information cannot be saved.";
					lblNote.CssClass = "errorNote";
					// FillTable();
				}
			}
			//   btn_Save.Enabled = false;
			//else
			//{
			//    lblErrorMessage.CssClass = "errorNote";
			//}
		}

		#region Function for Server Side Validations
		/// <summary>
		/// ServerSideValidations(Validation for server side).
		/// </summary>
		private void ServerSideValidations()
		{
			oValidate = new Validation();
			oValidate.inputElement(hidXml.Value, Convert.ToString(TypeOfValidation.NonEmpty), "Information Cannot be saved as configuration is not defined.", null, null, null);

		}
		#endregion

		protected void btnDelete_Click(object sender, EventArgs e)
		{
			//  DropDownList ddlCourse = (DropDownList)YCMOU.FindControl("ddlTerm");
			string[] arrPreviousAndCurrentCrKeys = ddlCrPrChDesc.SelectedValue.Split('_');

			oHt = CreateHashTable(arrPreviousAndCurrentCrKeys);
			oclsAdmissionElgConfig = new clsAdmissionElgConfig();
			string result = oclsAdmissionElgConfig.DeleteConfigurations(oHt);
			if (result.Equals("Y"))
			{
				lblNote.Visible = true;
				lblNote.Text = "Configuration deleted successfully.";
			}
			else
			{
				lblErrorMessage.Text = "Information Cant be processed.Please Contact Administrator.";
			}

			FillTable();

			btnDelete.Enabled = false;

		}

		#region Initialize Culture
		protected override void InitializeCulture()
		{
			System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
		}

		#endregion

		protected void rdbPartOrTerm_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Request.QueryString["frmPrevious"] == null)
			{
				//FillDropDowns();
				ddlCrPrChDesc.Items.Clear();

				ddlCrPrChDesc.Items.Insert(0, new ListItem("--- Select ---", "0"));
				getFacCrMoLrnPtrnID();

				FillCoursePart(clsGetSettings.UniversityID, string.Empty, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, Convert.ToString(ddlCrBrnDesc.SelectedValue));
				ToolkitScriptManager.GetCurrent(this.Page).SetFocus(ddlCrBrnDesc);
			}

			hidAdmissionElgTypeID.Value = rdbPartOrTerm.SelectedValue;

		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			if (rblResultConsideration.SelectedValue.Equals("1"))
			{
				// tblAdmissionEligibility.Style.Add("display", "block");
				tblAdmissionEligibility.Visible = true;
				ddlCrPrDetailsDesc.ClearSelection();
				ddlCrPrDetailsDesc.SelectedIndex = 0;
				ddlCrPrChDesc.ClearSelection();
				ddlCrPrChDesc.SelectedIndex = 0;
				oclsAdmissionElgConfig = new clsAdmissionElgConfig();
				oHt = CreateHashTable();
				string sStatus = oclsAdmissionElgConfig.DeleteAdmissionElgibilityConfigIndependentofResultStatus(oHt);
			}
			else
			{
				//tblAdmissionEligibility.Style.Add("display", "none");
				tblAdmissionEligibility.Visible = false;

				oclsAdmissionElgConfig = new clsAdmissionElgConfig();
				oHt = CreateHashTable();
				string sStatus = oclsAdmissionElgConfig.SaveAdmissionElgibilityConfigIndependentofResultStatus(oHt);
				if (sStatus.Equals("Y"))
				{
					lblErrorMessage.Text = "Information saved successfully.";
					lblErrorMessage.CssClass = "saveNote";
				}
				else
				{
					lblErrorMessage.Text = "Information cannot be saved.";
					lblErrorMessage.CssClass = "errorNote";
				}

			}

			SetStatus();
		}

		private void SetStatus()
		{
			string[] sArr = new string[2];
			oHt = CreateHashTable();
			oclsAdmissionElgConfig = new clsAdmissionElgConfig();
			sArr = oclsAdmissionElgConfig.GetAdmissionElgibilityConfigStatusofCourse(oHt);
			hidStatusElgConfig.Value = sArr[0];
			hidStatusElgConfigIndepedent.Value = sArr[1];
			btn_Save.Enabled = false;
			btnDelete.Enabled = false;
		}

		private Hashtable CreateHashTable()
		{
			oHt = new Hashtable();
			oHt["AcademicYearID"] = ddlAcadYear.SelectedValue;
			oHt["UniID"] = clsGetSettings.UniversityID;
			oHt["FacID"] = hidFacID.Value.Trim();
			oHt["CrID"] = hidCrID.Value.Trim();
			oHt["MoLrnID"] = hidMoLrnID.Value.Trim();
			oHt["PtrnID"] = hidPtrnID.Value.Trim();
			oHt["BrnID"] = ddlCrBrnDesc.SelectedValue;
			oHt["ConsiderResultStatus"] = rblResultConsideration.SelectedValue;
			oclsUser = (clsUser)Session["User"];
			if (oclsUser != null)
			{
				oHt["User"] = oclsUser.User_ID;
			}
			else
			{
				HttpContext.Current.Response.Write(clsGetSettings.LogOffMessage);
				HttpContext.Current.Response.End();
			}
			return oHt;
		}

		private void AddAttributetoXML(XmlDocument xd, XmlNode AddAttributeToXmlNode, string Name, string Value)
		{
			XmlAttribute att = xd.CreateAttribute(Name);
			att.InnerText = Value;
			AddAttributeToXmlNode.Attributes.Append(att);
		}

		private string PartOrTermWise_TermOrEligibilitiesTagsID(string TermTagIDs)
		{
			string ModifiedTermTagIDs = string.Empty;
			//	if (sAdmissionElgTypeID == "1")
			if (hidAdmissionElgTypeID.Value == "1")
			{
				ModifiedTermTagIDs = TermTagIDs.Substring(0, TermTagIDs.LastIndexOf('-'));
				ModifiedTermTagIDs += "-0";
				return ModifiedTermTagIDs;
			}
			else
			{
				return TermTagIDs;
			}
		}

		protected void rblResultConsideration_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (rblResultConsideration.SelectedValue.Equals("2"))
			{
				//tblAdmissionEligibility.Style.Add("display", "none");
				tblAdmissionEligibility.Visible = false;
				lblErrorMessage.Text = "";
				lblNote.Text = "";
			}

			SetStatus();

			//foreach (ListItem RadioButton in rblResultConsideration.Items)
			//{
			//    RadioButton.Attributes.Add("onclick", "return DropDownVisibility(this)");
			//}
		}
	}
}