using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data;
using ServerSideValidations;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_CETDetails : System.Web.UI.Page
    {
        Hashtable oHt = null;
        DataTable oDt = null;
        clsStudent oStudent = null;
        clsUser oclsUser = null;
        Validation oValidation = null;
        clsCommon oCommon = new clsCommon();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                #region Set Hidden Variables

                HtmlInputHidden[] hid = new HtmlInputHidden[12];
                hid[0] = hidFacID;
                hid[1] = hidCrID;
                hid[2] = hidMoLrnID;
                hid[3] = hidPtrnID;
                hid[4] = hidBrnID;
                hid[5] = hidCrPrDetailsID;
                hid[6] = hidCrPrChID;
                hid[7] = hidCrName;
                hid[8] = hidStudentName;
                hid[9] = hidPRN;
                hid[10] = hidInstID;
                hid[11] = hidElgFormNo;
                oCommon.setHiddenVariablesMPC(ref hid);

                #endregion
               

                Display();

                

            }
        }

        private void CreateHashTable()
        {

            oHt = new Hashtable();
            oHt.Add("UniID", clsGetSettings.UniversityID);
            oHt.Add("FacID", hidFacID.Value);
            oHt.Add("CrID", hidCrID.Value);
            oHt.Add("MoLrnID", hidMoLrnID.Value);
            oHt.Add("PtrnID", hidPtrnID.Value);
            oHt.Add("BrnID", hidBrnID.Value);
            oHt.Add("CrPrDetailsID", hidCrPrDetailsID.Value);
            oHt.Add("CrPrChID", hidCrPrChID.Value);
            oHt.Add("InstID", hidInstID.Value);
            if (hidPRN.Value != string.Empty)
            {
                oHt.Add("PRN", hidPRN.Value);
            }
            else if (hidElgFormNo.Value != string.Empty)
            {
                oHt.Add("RefUni", hidElgFormNo.Value.Split('-')[0].ToString());
                oHt.Add("RefInstID", hidElgFormNo.Value.Split('-')[1].ToString());
                oHt.Add("RefYear", hidElgFormNo.Value.Split('-')[2].ToString());
                oHt.Add("RefStudent", hidElgFormNo.Value.Split('-')[3].ToString());
            }
        }


        private void Display()
        {
            oStudent = new clsStudent();
            if (oHt != null)
                oHt.Clear();
            CreateHashTable();
            oDt = oStudent.GetCETDetails(oHt);
            if (oDt != null && oDt.Rows.Count > 0)
            {
                ListItem oLi = null;
                oLi = ddlCETType.Items.FindByValue(oDt.Rows[0]["CET_Type"].ToString());
                if (oLi != null)
                {
                    ddlCETType.ClearSelection();
                    oLi.Selected = true;
                    if (oLi.Value.Equals("11"))
                        txtCETMarks.Enabled = false;
                }

                oLi = ddlQuotaType.Items.FindByValue(oDt.Rows[0]["Quota_Type"].ToString());
                if (oLi != null)
                {
                    ddlQuotaType.ClearSelection();
                    oLi.Selected = true;
                }
                txtCETMarks.Text = oDt.Rows[0]["CET_Marks"].ToString();
                oLi = rblSelectionLettter.Items.FindByValue(oDt.Rows[0]["Selection_Letter"].ToString());
                if (oLi != null)
                {
                    rblSelectionLettter.ClearSelection();
                    oLi.Selected = true;
                }
                txtPhysicsParks.Text = oDt.Rows[0]["HSc_Marks_Physics"].ToString();
                txtChemistryMarks.Text = oDt.Rows[0]["HSc_Marks_Chemistry"].ToString();
                txtBioMarks.Text = oDt.Rows[0]["HSc_Marks_Biology"].ToString();
                txtEnglishMarks.Text = oDt.Rows[0]["HSc_Marks_English"].ToString();
                txtUrduMarks.Text = oDt.Rows[0]["HSc_Marks_Urdu"].ToString();
                txtHscBoard.Text = oDt.Rows[0]["Place_Of_HSc"].ToString();
                txtCompMarks.Text = oDt.Rows[0]["HSc_Marks_Computer"].ToString();
                oLi = rblFromMaharashtra.Items.FindByValue(oDt.Rows[0]["Is_Maharashtra"].ToString());
                if (oLi != null)
                {
                    rblFromMaharashtra.ClearSelection();
                    oLi.Selected = true;
                }
                oLi = rblDipGNMsheet.Items.FindByValue(oDt.Rows[0]["Is_Dip_Cert_GNM_Marksheet"].ToString());

                if (oLi != null)
                {
                    rblDipGNMsheet.ClearSelection();
                    oLi.Selected = true;
                }
                oLi = rblIsForeigner.Items.FindByValue(oDt.Rows[0]["Is_Foreigner"].ToString());
                if (oLi != null)
                {
                    rblIsForeigner.ClearSelection();
                    oLi.Selected = true;
                }
            }
            //else
            //{
            //    cetDetails.Visible = false;
            //    lblErrorMsg.Visible = true;
            //    lblErrorMsg.Text = "Record Not found.";
            //}
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ServerSideValidations();
            if (oValidation.ValidateMe(lblErrorMsg))
            {
                Hashtable oHt = CreateHashTableForCETSave();
                oStudent = new clsStudent();
                string sResult = oStudent.SaveCETDetails(oHt);
                if (sResult.Equals("Y"))
                {
                    lblSaveMsg.Visible = true;
                }
                else
                {
                    lblErrorMsg.Text = "Information can not be saved, Please contance Admin.";
                    lblSaveMsg.Visible = false;
                    lblErrorMsg.Visible = true;
                }
                //Write Ur Logic here
            }
            else
                lblErrorMsg.Visible = true;
        }
        private Hashtable CreateHashTableForCETSave()
        {

            oHt = new Hashtable();
            oHt.Add("UniID", clsGetSettings.UniversityID);
            oHt.Add("FacID", hidFacID.Value);
            oHt.Add("CrID", hidCrID.Value);
            oHt.Add("MoLrnID", hidMoLrnID.Value);
            oHt.Add("PtrnID", hidPtrnID.Value);
            oHt.Add("BrnID", hidBrnID.Value);
            oHt.Add("CrPrDetailsID", hidCrPrDetailsID.Value);
            oHt.Add("CrPrChID", hidCrPrChID.Value);
            oHt.Add("InstID", hidInstID.Value);
            clsUser oUser = (clsUser)Session["user"];
            oHt.Add("User", oUser.User_ID);
         //   oHt.Add("Year", hidYear.Value);
          //  oHt.Add("StudentID", hidStudentID.Value);
            if (hidPRN.Value != string.Empty)
            {
                oHt.Add("PRN", hidPRN.Value);
            }
            else if (hidElgFormNo.Value != string.Empty)
            {
                oHt.Add("RefUni", hidElgFormNo.Value.Split('-')[0].ToString());
                oHt.Add("RefInstID", hidElgFormNo.Value.Split('-')[1].ToString());
                oHt.Add("RefYear", hidElgFormNo.Value.Split('-')[2].ToString());
                oHt.Add("RefStudent", hidElgFormNo.Value.Split('-')[3].ToString());
            }


            oHt["CETType"] = ddlCETType.SelectedValue;
            oHt["QuotaType"] = ddlQuotaType.SelectedValue;
            oHt["CETMarks"] = txtCETMarks.Text.Trim();
            oHt["SelectionLetter"] = rblSelectionLettter.SelectedValue;
            oHt["HScMarksPhysics"] = txtPhysicsParks.Text.Trim();
            oHt["HScMarksChemistry"] = txtChemistryMarks.Text.Trim();
            oHt["HScMarksBiology"] = txtBioMarks.Text.Trim();
            oHt["HScMarksEnglish"] = txtEnglishMarks.Text.Trim();
            oHt["HScMarksUrdu"] = txtUrduMarks.Text.Trim();
            oHt["HScCompMarks"] = txtCompMarks.Text.Trim();
            oHt["PlaceOfHSc"] = txtHscBoard.Text.Trim();
            oHt["IsMaharashtra"] = rblFromMaharashtra.SelectedValue;
            oHt["IsDipCertGNMMarksheet"] = rblDipGNMsheet.SelectedValue;
            oHt["IsForeigner"] = rblIsForeigner.SelectedValue;

            oclsUser = (clsUser)Session["User"];
            oHt["User"] = oclsUser.User_ID;
            return oHt;
        }

        #region Server Side Validations
        private void ServerSideValidations()
        {

            ////LessThanOrEqual remaining amount validation not working 
            ////GreaterThanZero validation doesnt work on .2,.5 values
            oValidation = new Validation();
            if (!ddlCETType.SelectedValue.Equals("11"))
                oValidation.inputElement(txtCETMarks.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsDecimalValue), "CET Marks", null, null, null);
            oValidation.inputElement(txtPhysicsParks.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsDecimalValue), "Physics Marks", null, null, null);
            // oValidation.inputElement(txtEnglishMarks.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsDecimalValue), "English Marks", null, null, null);
            oValidation.inputElement(txtChemistryMarks.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsDecimalValue), "Chemistry Marks", null, null, null);
            //oValidation.inputElement(txtUrduMarks.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsDecimalValue), "Urdu Marks", null, null, null);
            oValidation.inputElement(txtBioMarks.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsDecimalValue), "Bio Marks", null, null, null);
            oValidation.inputElement(txtHscBoard.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsCharacterOnly), "Hsc Board", null, null, null);
            oValidation.inputElement(ddlCETType.SelectedValue, Convert.ToString(TypeOfValidation.RequiredDropDown), "CET Type", null, null, null);
            oValidation.inputElement(ddlQuotaType.SelectedValue, Convert.ToString(TypeOfValidation.RequiredDropDown), "Quota Type", null, null, null);
            //oValidation.inputElement(txtPhysicsParks.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsDecimalValue), "Physics Marks", null, null, null);
            //oValidation.inputElement(txtPhysicsParks.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsDecimalValue), "Physics Marks", null, null, null);
            //oValidation.inputElement(txtPhysicsParks.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsDecimalValue), "Physics Marks", null, null, null);


            //oValidation.inputElement(txtTotalAmount.Text.Trim(), Convert.ToString(TypeOfValidation.ContainsDecimalValue), "Instrument Amount", null, null, null);
            //oValidation.inputElement(txtDD_Cheque_No.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsNumberOnly), "DD/Cheque", null, null, null);
            //oValidation.inputElement(txtMICR_No.Text.Trim(), Convert.ToString(TypeOfValidation.LengthBetween), "MICR No", null, 9, 9);
            //oValidation.inputElement(txtDD_Cheque_Date.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.DateNoGreaterToday) + "|" + Convert.ToString(TypeOfValidation.ValidDate), "Date", "dd/mm/yyyy", null, null);
            //oValidation.inputElement(ddlBank.SelectedValue, Convert.ToString(TypeOfValidation.RequiredDropDown), "Bank", null, null, null);
            //oValidate.inputElement(Mobile_No.Text, Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsNumberOnly), "Mobile Number", null, null, null);
        }
        #endregion
    }
}