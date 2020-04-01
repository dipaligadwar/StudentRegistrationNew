using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using StudentRegistration.Eligibility.ElgClasses;


namespace Classes
{
    public class Clsdivya
    {
        #region FetchCourseWiseCoursePartList

        [Ajax.AjaxMethod()]
        public HtmlSelect FetchCourseWiseCoursePartList(string UniID, string InstID, string FacID, string CrID, string MoLrnID, string PtrnID, string BrnID, string HtmlSelCrBrnID)
        {

            DataTable dt = clsInstitute.Get_AllCoursePartOnly(UniID, InstID, FacID, CrID, MoLrnID, PtrnID, BrnID);
            HtmlSelect htmlSel = new HtmlSelect();
            htmlSel.ID = HtmlSelCrBrnID;
            htmlSel.Attributes.Add("class", "selectbox");


           // htmlSel.Attributes.Add("onchange", "FetchCourseMoLrnPtrnBrnWiseCoursePartList('tdCrPrDesc', hidUniID.value, hidFacID.value, hidCrID.value, hidMoLrnID.value, hidPtrnID.value, hidBrnID.value, 'ddlCrPrDesc'); ");//ClearDropDowns(5," + levelflag + ");");
            htmlSel.Attributes.Add("onchange", "setValue('hidCrPrID',this.value);");
            htmlSel.DataSource = dt;
            htmlSel.DataTextField = "text";
            htmlSel.DataValueField = "value";
            htmlSel.DataBind();
            ListItem li = new ListItem("--- Select ---", "-1");
            htmlSel.Items.Insert(0, li);
            return htmlSel;
        }

        #endregion
         
        

    }
}
