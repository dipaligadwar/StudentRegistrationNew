using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Data;
using System.Collections;
using ServerSideValidations;
namespace StudentRegistration.Eligibility
{
    public partial class AdmissionEligConfiguration__1 : System.Web.UI.Page
    {
        clsAdmissionElgConfig oAdmissionElgConfig = null;
        DataTable oDt = null;
        Hashtable oHt = null;
        clsCommon oCommon = null;
        Validation oValidation = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlAcademicYear.Focus();
            this.Form.DefaultButton = btnSubmit.UniqueID;
            
            if (!IsPostBack)
            {
                FillAcademicYear();
                
            }
        }

        private void FillAcademicYear()
        {
            using (oDt = new DataTable())
            {
                clsAcademicYear objAcadYear = new clsAcademicYear();
                oDt = objAcadYear.ListAcademicYear();
                oCommon = new clsCommon();
                oCommon.fillDropDown(ddlAcademicYear, oDt, string.Empty, "Year", "pk_AcademicYear_ID", "---- Select ----");
                if (oCommon != null)
                    oCommon = null;
            }
            
        }


        private void FillGrid()
        {
            oAdmissionElgConfig = new clsAdmissionElgConfig();
            oHt=CreateHashTable();
            oDt = oAdmissionElgConfig.GetAllDefinedAdmissionEligibilityConfigurations(oHt);
            if (oDt != null && oDt.Rows.Count > 0)
            {
                tblGridHolder.Visible = true;
                lblErrorMsg.Visible = false;
                oGridView.DataSource = oDt;
                oGridView.DataBind();
            }
            else
            {
                //lblErrorMessage.Text = "No record found.";
                //lblErrorMessage.Visible = true;
               // oGridView.Visible = false;
                Server.Transfer("AdmissionEligConfiguration.aspx");
            }
        }
        private Hashtable CreateHashTable()
        {
            oHt = new Hashtable();

            oHt["UniID"] = clsGetSettings.UniversityID;
            oHt["AcademicYearID"] = ddlAcademicYear.SelectedValue;
            return oHt;
        }
        

        protected void oGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("update"))
            {
                WebControl wc = e.CommandSource as WebControl;
                GridViewRow row = wc.NamingContainer as GridViewRow;
                if (row != null)
                {
                    int index = row.RowIndex;
                    GridViewRow selectedRow = oGridView.Rows[index];
                    hidAcademicYearID.Value = ddlAcademicYear.SelectedValue;
                    hidUniID.Value = oGridView.DataKeys[index]["UniID"].ToString();
                    hidFacID.Value = oGridView.DataKeys[index]["FacID"].ToString();
                    hidCrID.Value = oGridView.DataKeys[index]["CrID"].ToString();
                    hidMoLrnID.Value = oGridView.DataKeys[index]["MoLrnID"].ToString();
                    hidPtrnID.Value = oGridView.DataKeys[index]["PtrnID"].ToString();
                    hidBrnID.Value = oGridView.DataKeys[index]["BrnID"].ToString();
                    hidCrPrDetailsID.Value = oGridView.DataKeys[index]["CrPrDetailsID"].ToString();
                    hidCrPrChID.Value = oGridView.DataKeys[index]["CrPrChID"].ToString();
                    hidCurrentAndPreviousKeys.Value = oGridView.DataKeys[index]["CurrentAndPreviousKeys"].ToString();
                    hidAdmissionElgTypeID.Value = oGridView.DataKeys[index]["AdmissionElgTypeID"].ToString();
                    hidResultConsideration.Value = oGridView.DataKeys[index]["ResultConsideration"].ToString(); 
                    Server.Transfer("AdmissionEligConfiguration.aspx?frmPrevious=Y", true);
                }

            }
        }

        protected void oGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.TableSection = TableRowSection.TableHeader;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               // e.Row.Cells[3].Text = Convert.ToString(e.Row.DataItemIndex + 1);
                // string UniID = oGridView.DataKeys[e.Row.DataItemIndex]["pk_Uni_ID"].ToString();
                
               // e.Row.Cells[8].Attributes.Add("onmouseover", "this.style.cursor='Hand'");
               // e.Row.Cells[8].Attributes.Add("onmouseout", "this.style.cursor='Arrow'");
                //  e.Row.Cells[8].Attributes.Add("onclick", " return PopupNewwindow(" + UniID + "," + FacID + "," + CrID + "," + MolID + "," + PtrnID + "," + BrnID + ");");
            }


        }

        protected void oGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            oGridView.PageIndex = e.NewPageIndex;
           

            if (!string.IsNullOrEmpty(txtSearchBox.Text.Trim()))
            {
                FillGridSearchRecord();
            }
            else
            {
                FillGrid();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ServerSideValidations();
            if (oValidation.ValidateMe(lblErrorMessage))
            {
                FillGrid();
                tblGridHolder.Visible = true;
                trSearchRecord.Visible = true;
                tblSearch.Visible = true;
                trNote.Visible = true;
            }
            else
                lblErrorMessage.Visible = true;
            
        }

        #region Server Side Validations
        private void ServerSideValidations()
        {
            oValidation = new Validation();
            oValidation.inputElement(ddlAcademicYear.SelectedValue, Convert.ToString(TypeOfValidation.RequiredDropDown), "Bank", null, null, null);
        }
        #endregion


        private void MergeRows(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                for (int i = 0; i < 1; i++)
                {
                    if (row.Cells[i].Text == previousRow.Cells[i].Text)
                    {
                        row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                               previousRow.Cells[i].RowSpan + 1;
                        previousRow.Cells[i].Visible = false;
                    }
                }
            }
        }


        protected void oGridView_PreRender(object sender, EventArgs e)
        {
            MergeRows(oGridView);
        }

        protected void btnAddNewConfiguration_Click(object sender, EventArgs e)
        {
            hidAcademicYearID.Value = ddlAcademicYear.SelectedValue;
            Server.Transfer("AdmissionEligConfiguration.aspx");
        }




        protected void btnSearch_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrEmpty(txtSearchBox.Text.Trim()))
            {
                FillGrid();
            }
            else
            {
                FillGridSearchRecord();
            }
        }


        private void FillGridSearchRecord()
        {
            oAdmissionElgConfig = new clsAdmissionElgConfig();
            Hashtable oHt = new Hashtable();

            oHt["UniID"] = clsGetSettings.UniversityID;
            oHt["AcademicYearID"] = ddlAcademicYear.SelectedValue;

            oHt["CourseName"] = txtSearchBox.Text.Trim();


            oDt = oAdmissionElgConfig.GetAllDefinedAdmissionEligibilityConfigurationsForSearch(oHt);

            if (oDt != null && oDt.Rows.Count > 0)
            {
                tblGridHolder.Visible = true;
                lblErrorMsg.Visible = false;

                oGridView.DataSource = oDt;
                oGridView.DataBind();
            }
            else
            {
                tblGridHolder.Visible = false;
                lblErrorMsg.Visible = true;
                    
            }
        }


    }
}