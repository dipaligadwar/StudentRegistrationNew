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

namespace StudentRegistration.Eligibility
{
    public partial class searchInstNew : System.Web.UI.UserControl
    {
        string fkCountryID = "";
        private string instName = "";
        private string rdType_ID = "";
        private string rd_TypeText = "";
        private string instiID = "";
        clsState clsState = new clsState();
        clsTaluka clsTaluka = new clsTaluka();
        clsDistrict clsDistrict = new clsDistrict();
        clsGeneral clsCountry = new clsGeneral();

        #region Properties

        public string Insttype
        {
            get
            {
                return hidregisterationInfo.Value;
            }
        }
        public string InstName
        {
            get
            {
                return instName;
            }
        }
        public string RDType_ID
        {
            get
            {
                return rdType_ID;
            }
        }
        public string RD_TypeText
        {
            get
            {
                return rd_TypeText;
            }
        }

        public string InstiID
        {
            get
            {
                return hidInstID.Value;
            }
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, System.EventArgs e)
        {
            string countryId = ddlCountry.SelectedValue;
            //hidCollCode.Value = Collcode.Text;
            //instName = Inst_Name.Text.ToString();
            //rdType_ID = rdbtnInstType.SelectedItem.Value;
            //rd_TypeText = rdbtnInstType.SelectedItem.Text.ToString();

            if (!IsPostBack)
            {
                fnFillInstType("");
                fkCountryID = "0";
                hidStateID.Value = "0";
                hidTehsilID.Value = "0";
                hidDistrictID.Value = "0";
                fnFillStateDistrictTaluka("", "", "");
               
                hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                hidCountryId.Value = fkCountryID;

                trState.Style.Add("display", "none");
                trDistrict.Style.Add("display", "none");
                trTahsil.Style.Add("display", "none");
                
              //  fnDisplayGrid();

            }
            else
            {
                if (hidCountryId.Value == "107")
                {
                    fnFillStateDistrictTaluka(hidStateID.Value, hidDistrictID.Value, hidTehsilID.Value);
                }
                //hidUniID.Value = Classes.clsGetSettings.UniversityID.ToString();
                //hidCollCode.Value = Collcode.Text;
                //instName = Inst_Name.Text.ToString();
                //rdType_ID = rdbtnInstType.SelectedItem.Value;
                //rd_TypeText = rdbtnInstType.SelectedItem.Text.ToString();
            }
        }

        #endregion

        #region DataGrid Related Events

        #region dgData_ItemCommand

       /* private void dgData_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "lnkButSelect")
            {
                hidInstID.Value = e.Item.Cells[1].Text;
               
                #region Commented
                //				switch(sMID)
                //				{
                //					case "1":
                //						Server.Transfer("basicInfo.aspx?grp=1&PID="+sPID,true);					
                //						break;
                //					case "2":
                //						Server.Transfer("registrationRecognition.aspx?grp=1&PID="+sPID,true);					
                //						break;
                //					case "3":
                //						Server.Transfer("geographicalInfo.aspx?grp=1&PID="+sPID,true);					
                //						break;
                //					case "4":
                //						Server.Transfer("AffiliationInfo.aspx?grp=1&PID="+sPID,true);					
                //						break;
                //					case "5":
                //						Server.Transfer("GradeInfo.aspx?grp=1&PID="+sPID,true);					
                //						break;
                //					case "6":
                //						Server.Transfer("otherBasicInfo.aspx?grp=1&PID="+sPID,true);					
                //						break;
                //				
                //					case "20":
                //						Server.Transfer("selectCourse.aspx?grp=2&PID="+sPID,true);					
                //						break;
                //					case "21":
                //						Server.Transfer("selectSubPp.aspx?grp=3&PID="+sPID,true);					
                //						break;
                //					case "22":
                //						Server.Transfer("assignInstMedium.aspx?grp=2",true);					
                //						break;
                //					case "23":
                //						Server.Transfer("assignCapacity.aspx?grp=2&PID="+sPID,true);					
                //						break;
                //
                //					case "31":
                //						Server.Transfer("rptReportSelection.aspx?PID="+sPID,true);					
                //						break;
                //				
                //					case "99":
                //						Server.Transfer("selectAffData.aspx?PID="+sPID,true);					
                //						break;
                //					case "100":
                //						Server.Transfer("confirmation.aspx?grp=conf&PID="+sPID,true);					
                //						break;
                //				}
                #endregion
            }
        }*/

        #endregion

        #region dgData_PageIndexChanged

       /* protected void dgData_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgData.CurrentPageIndex = e.NewPageIndex;
            fnDisplayGrid();
        }*/

        #endregion

        #endregion

        #region Button Function

        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            fnDisplayGrid();
            
        }

        #endregion

        #region User Defined Function


        private void fnDisplayGrid()
        {
            dgData1.Style.Add("display", "block");
            DataTable dt = new DataTable();

       
            if (hidCountryId.Value == "107")
            {
                dt = clsInstitute.InstituteSearch(hidUniID.Value, rdbtnInstType.SelectedItem.Value, Inst_Name.Text.Trim().Trim('\''), hidCountryId.Value, hidStateID.Value, hidDistrictID.Value, hidTehsilID.Value, Collcode.Text.Trim().Trim('\''));
            }
            else
            {
                dt = clsInstitute.InstituteSearch(hidUniID.Value, rdbtnInstType.SelectedItem.Value, Inst_Name.Text.Trim().Trim('\''), hidCountryId.Value, "0", "0", "0", Collcode.Text.Trim().Trim('\''));
            }
            if (dt.Rows.Count > 0)
            {
                dgData1.DataSource = dt;

                try
                {
                    dgData1.DataBind();
                }
                catch
                {
                    dgData1.PageIndex = 0;
                    dgData1.DataBind();
                }
                fldPapers.Style.Add("display", "block");
                dgData1.Visible = true;

                lblGridName.Visible = true;
                lblGridName.Text = "..:: Available " + rdbtnInstType.SelectedItem.Text + "(s) ::..";

                lblData.Text = "";
                lblData.Visible = false;
            }
            else
            {
                fldPapers.Style.Add("display","none");
                dgData1.Visible = false;
                lblGridName.Visible = false;

                lblData.Visible = true;
                lblData.Text = "<font size=3 color='#000000'>Sorry...</font><br><br>Record is not available for the " + rdbtnInstType.SelectedItem.Text;
            }
 
            fkCountryID = hidCountryId.Value;
            if (hidCountryId.Value == "107")
            {
                trState.Style.Add("display", "block");
                trDistrict.Style.Add("display", "block");
                trTahsil.Style.Add("display", "block");
                ddlCountry.SelectedItem.Text = "India";
                
               // fnFillStateDistrictTaluka(hidStateID.Value, hidDistrictID.Value, hidTehsilID.Value);
            }
            else
            {
                trState.Style.Add("display", "none");
                trDistrict.Style.Add("display", "none");
                trTahsil.Style.Add("display", "none");
                fnFillStateDistrictTaluka("", "", "");
            }

            dt.Dispose();
            dt = null;
           
        }

        private void fnFillInstType(string sValue)
        {
            DataTable dt = clsInstituteType.AllInstituteTypes();
            fillRadioList(rdbtnInstType, dt, sValue, "InstTy_Name", "pk_InstTy_ID");


            rdbtnInstType.Items.Insert(0, new ListItem("Any Type", "0"));
            rdbtnInstType.ClearSelection();
            rdbtnInstType.Items[0].Selected = true;
        }

        public void fillRadioList(RadioButtonList rdList, DataTable dt, string selectedID, string textColumnName, string valueColumnName)
        {
            rdList.SelectedIndex = -1;
            if (dt.Rows.Count > 0)
            {
                rdList.DataSource = dt;
                if (valueColumnName != null && valueColumnName != "")
                    rdList.DataValueField = valueColumnName;
                else
                    rdList.DataValueField = textColumnName;

                rdList.DataTextField = textColumnName;
                rdList.DataBind();
                ListItem li = rdList.Items.FindByValue(selectedID);
                if (li != null)
                {
                    li.Selected = true;
                }
                else
                {
                    rdList.Items[0].Selected = true;
                }
            }
            /*else
            {
                rdList.Items.Insert(0,new ListItem("--No Value--","0"));
            }*/
        }


        private void fnFillStateDistrictTaluka(string stateID, string districtID, string tehsilID)
        {
            clsCommon common = new clsCommon();
            DataTable dt = clsCountry.ListCountry();
            common.fillDropDown(ddlCountry, dt, fkCountryID, "Text", "Value", "--- Select ---");

            State_ID.Items.Clear();
            dt = clsState.DisplayAllStates("E");
            common.fillDropDown(State_ID, dt, stateID, "State_Name", "State_ID", "--- Select ---");
            dt.Dispose();

            District_ID.Items.Clear();
            dt = clsDistrict.StateWiseDistricts(State_ID.SelectedItem.Value, "E");
            common.fillDropDown(District_ID, dt, districtID, "Text", "Value", "--- Select ---");
            dt.Dispose();

            Tehsil_ID.Items.Clear();
            dt = clsTaluka.DisplayTalukaWithinDistrict(District_ID.SelectedItem.Value, "E");
            common.fillDropDown(Tehsil_ID, dt, tehsilID, "Text", "Value", "--- Select ---");
            dt.Dispose();

        }

        #endregion

        #region GridView Related Events : Jatin
                
        protected void dgData1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[8].Style.Add("display", "none");
            }
        }

        protected void dgData1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkButSelect")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgData1.Rows[index];

                hidInstID.Value = row.Cells[1].Text;
                hidCollCode.Value = row.Cells[2].Text;
                hidCollName.Value = row.Cells[3].Text;

            }
        }

        protected void dgData1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgData1.PageIndex = e.NewPageIndex;
            fnDisplayGrid();
        }

        #endregion

    }
}