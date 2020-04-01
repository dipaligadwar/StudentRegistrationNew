using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Classes;
using ServerSideValidations;

namespace StudentRegistration.Eligibility
{


    public partial class StudentRegistrationPage1 : System.Web.UI.Page
    {
        DataTable oDt = null;
        Hashtable oHt = null;
        clsCommon oCommon = null;
        Validation oValidation = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = btnSubmit.UniqueID;
            btnSubmit.Focus();
            if (!IsPostBack)
            {

            }
        }
        protected void rblResultConsideration_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ServerSideValidations();
            if (oValidation.ValidateMe(lblErrorMessage))
            {
                //Write Ur Logic here
            }
            else
                lblErrorMessage.Visible = true;
        }
        #region Server Side Validations
        private void ServerSideValidations()
        {

            ////LessThanOrEqual remaining amount validation not working 
            ////GreaterThanZero validation doesnt work on .2,.5 values
            //oValidation = new Validation();
            //oValidation.inputElement(txtTotalAmount.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty), "Instrument Amount", null, null, null);
            //oValidation.inputElement(txtTotalAmount.Text.Trim(), Convert.ToString(TypeOfValidation.ContainsDecimalValue), "Instrument Amount", null, null, null);
            //oValidation.inputElement(txtDD_Cheque_No.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.ContainsNumberOnly), "DD/Cheque", null, null, null);
            //oValidation.inputElement(txtMICR_No.Text.Trim(), Convert.ToString(TypeOfValidation.LengthBetween), "MICR No", null, 9, 9);
            //oValidation.inputElement(txtDD_Cheque_Date.Text.Trim(), Convert.ToString(TypeOfValidation.NonEmpty) + "|" + Convert.ToString(TypeOfValidation.DateNoGreaterToday) + "|" + Convert.ToString(TypeOfValidation.ValidDate), "Date", "dd/mm/yyyy", null, null);
            //oValidation.inputElement(ddlBank.SelectedValue, Convert.ToString(TypeOfValidation.RequiredDropDown), "Bank", null, null, null);

        }
        #endregion
        protected void oGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("delete"))
            {
                WebControl wc = e.CommandSource as WebControl;
                GridViewRow row = wc.NamingContainer as GridViewRow;
                if (row != null)
                {
                    int index = row.RowIndex;
                    GridViewRow selectedRow = oGridView.Rows[index];

                    //Hashtable ht = new Hashtable();
                    //ht.Add("FileID", selectedRow.Cells[0].Text.Trim());
                    //ht.Add("Modified_By", user.User_ID.ToString());
                    //int result = objManageFiles.deleteFiles(ht);
                    //if (result > 0)
                    //{
                    //    DisplayGrid();
                    //    lblErrorMessage.Visible = true;
                    //    lblErrorMessage.CssClass = "saveNote";
                    //    lblErrorMessage.Text = "File(s) Deleted Successfully.";
                    //}
                    //else
                    //{
                    //    lblErrorMessage.Visible = true;
                    //    lblErrorMessage.CssClass = "saveNote";
                    //    lblErrorMessage.Text = "File cannot be deleted.";
                    //}
                }

            }
        }

        protected void oGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Text = Convert.ToString(e.Row.DataItemIndex + 1);
               // string UniID = oGridView.DataKeys[e.Row.DataItemIndex]["pk_Uni_ID"].ToString();
                string FacID = oGridView.DataKeys[e.Row.DataItemIndex]["FacID"].ToString();
                string CrID = oGridView.DataKeys[e.Row.DataItemIndex]["CrID"].ToString();
                string MolID = oGridView.DataKeys[e.Row.DataItemIndex]["MoLrnID"].ToString();
                string PtrnID = oGridView.DataKeys[e.Row.DataItemIndex]["PtrnID"].ToString();
                string BrnID = oGridView.DataKeys[e.Row.DataItemIndex]["BrnID"].ToString();
                e.Row.Cells[8].Attributes.Add("onmouseover", "this.style.cursor='Hand'");
                e.Row.Cells[8].Attributes.Add("onmouseout", "this.style.cursor='Arrow'");
              //  e.Row.Cells[8].Attributes.Add("onclick", " return PopupNewwindow(" + UniID + "," + FacID + "," + CrID + "," + MolID + "," + PtrnID + "," + BrnID + ");");
            }


        }

        protected void oGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            oGridView.PageIndex = e.NewPageIndex;
           // FillGrid()
        }

        








        








    }
}