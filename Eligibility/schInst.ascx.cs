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

namespace StudentRegistration.Eligibility
{
    public partial class schInst : System.Web.UI.UserControl
    {
        private string uniID = "";
        private string rd_TypeText = "";
        private string rdType_ID = "";
        private string instName = "";
        private string statID = "";
        private string distID = "";
        private string tehID = "";

        public string UniID
        {
            get
            {
                return uniID;
            }
        }
        public string RD_TypeText
        {
            get
            {
                return rd_TypeText;
            }
        }
        public string RDType_ID
        {
            get
            {
                return rdType_ID;
            }
        }
        public string InstName
        {
            get
            {
                return instName;
            }
        }
        public string StatID
        {
            get
            {
                return statID;
            }
        }
        public string DistID
        {
            get
            {
                return distID;
            }
        }
        public string TehID
        {
            get
            {
                return tehID;
            }
        }

        public void Page_Load(object sender, EventArgs e)
        {
            Classes.clsCache.NoCache();
            if (!IsPostBack)
            {
                fnFillInstType("");
                fnFillStateDistrictTaluka("", "", "");
                hidUniID.Value = UniversityPortal.clsGetSettings.UniversityID.ToString();
            }
            else
            {
                fnFillStateDistrictTaluka(hidStateID.Value, hidDistrictID.Value, hidTehsilID.Value);
                uniID = UniversityPortal.clsGetSettings.UniversityID.ToString();
                instName = Inst_Name.Text.ToString();
                statID = hidStateID.Value;
                distID = hidDistrictID.Value;
                tehID = hidTehsilID.Value;
                rdType_ID = rdbtnInstType.SelectedItem.Value;
                rd_TypeText = rdbtnInstType.SelectedItem.Text.ToString();
            }
        }

        #region User Defined Function...

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

            State_ID.Items.Clear();
            DataTable dt = clsState.displayAllStates("E");
            common.fillDropDown(State_ID, dt, stateID, "State_Name", "State_ID", "---- Select ----");
            dt.Dispose();

            District_ID.Items.Clear();
            dt = clsDistrict.stateWiseDistricts(State_ID.SelectedItem.Value, "E");
            common.fillDropDown(District_ID, dt, districtID, "Text", "Value", "---- Select ----");
            dt.Dispose();

            Tehsil_ID.Items.Clear();
            dt = clsTaluka.displayTalukaWithinDistrict(District_ID.SelectedItem.Value, "E");
            common.fillDropDown(Tehsil_ID, dt, tehsilID, "Text", "Value", "---- Select ----");
            dt.Dispose();

        }

        #endregion


        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
    }
}