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
using System.Text.RegularExpressions;
using Classes;
using StudentRegistration.Eligibility.ElgClasses;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_rptPaperExemptionStudentStatus : System.Web.UI.Page
    {
        #region variables

        DataSet ds_StudentStatus;
        DataRow dr;
        string PRNumber = null;
        private string Elg_FormNo;
        clsUser user;

        #endregion

        #region Initialize Culture
        protected override void InitializeCulture()
        {
            System.Web.Configuration.GlobalizationSection section = (System.Web.Configuration.GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.UICulture);
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hidIsPRNValidationRequired.Value = Classes.clsGetSettings.IsPRNValidationRequired;
            }
            catch
            {
                hidIsPRNValidationRequired.Value = "N";
            }
        }

        protected void btnSimpleSearch_Click(object sender, EventArgs e)
        {
            if (txtElgFormNo.Text != "")
            {
                Elg_FormNo = txtElgFormNo.Text.Trim();
            }

            else
            {
                Elg_FormNo = "0-0-0-0";
            }

            int cnt = 0;
            string str = Elg_FormNo;
            int pos = str.IndexOf('-');
            string[] arr = new string[] { "0", "0", "0", "0" };
            Regex objNotNaturalPattern = new Regex("^([0-9]){16}$");

            if (objNotNaturalPattern.IsMatch(txtPRN.Text.Trim()))
                PRNumber = txtPRN.Text.Trim();

            while (pos != -1)
            {
                str = str.Substring(pos + 1);
                pos = str.IndexOf('-');
                cnt++;

            }
            if (cnt == 3)
            {
                arr = new string[4];
                arr = Elg_FormNo.Split('-');   //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
                for (int i = 0; i < 4; i++)
                {
                    if (arr[i] == "")
                        arr[i] = "0";
                }
            }

            ds_StudentStatus = ElgClasses.clsCollegeAdmissionReports.FillPaperExemptionStudentStatus(PRNumber, arr[0], arr[1], arr[2], arr[3]);

            if (ds_StudentStatus.Tables.Count > 0)
            {
                divStudentStatus.Style.Add("display", "block");
                divSimpleSearch.Style.Add("display", "none");

                lblStudentName.Text = " for " + ds_StudentStatus.Tables[0].Rows[0]["StudentName"].ToString();

                foreach (DataTable Dt in ds_StudentStatus.Tables)
                {
                    HtmlTable dTable = new HtmlTable();
                    dTable.CellPadding = 3;
                    dTable.CellSpacing = 0;
                    dTable.Border = 1;
                    dTable.Attributes.Add("class", "clGrid");
                   // dTable.BorderColor = "#cccccc";
                    dTable.Width = "100%";
                    dTable.Style.Add("border-style","Double");
                    dTable.Style.Add("border-collapse","collapse");

                    int tRows;
                    int tCells;

                    

                    // DataRows
                    for (tRows = 0; tRows < Dt.Rows.Count; tRows++)
                    {
                        if (tRows == 0)
                        {
                            // Course Name Row
                            HtmlTableRow dTRowCourseName = new HtmlTableRow();
                            HtmlTableCell dTCellCourseName = new HtmlTableCell();
                            dTCellCourseName.ColSpan = 3;
                            dTCellCourseName.InnerText = Dt.Rows[0]["CourseName"].ToString();
                            dTCellCourseName.Style.Add("font-weight", "bold");
                            dTCellCourseName.Align = "left";
                            dTRowCourseName.Controls.Add(dTCellCourseName);
                            dTable.Controls.Add(dTRowCourseName);

                            //----------------------------------------------------------------
                            // Table Heading Row
                            HtmlTableRow dTRowHeading = new HtmlTableRow();
                            HtmlTableCell dTCellHeading = new HtmlTableCell();
                            dTRowHeading.Attributes.Add("class", "clMenuHeader");
                            dTCellHeading.InnerText = "Sr. No.";
                            dTCellHeading.Style.Add("font-weight", "bold");
                            //dTCellHeading.BgColor = "#E0E0E0";
                            dTRowHeading.Controls.Add(dTCellHeading);

                            dTCellHeading = new HtmlTableCell();
                            dTRowHeading.Attributes.Add("class", "clMenuHeader");
                            dTCellHeading.InnerText = lblPaper.Text + " [TLM-AM-AT]";
                            dTCellHeading.Style.Add("font-weight", "bold");
                            //dTCellHeading.BgColor = "#E0E0E0";
                            dTRowHeading.Controls.Add(dTCellHeading);

                            dTCellHeading = new HtmlTableCell();
                            dTRowHeading.Attributes.Add("class", "clMenuHeader");
                            dTCellHeading.InnerText = "Approval Status";
                            dTCellHeading.Style.Add("font-weight", "bold");
                            //dTCellHeading.BgColor = "#E0E0E0";
                            dTRowHeading.Controls.Add(dTCellHeading);

                            dTable.Controls.Add(dTRowHeading);
                            //----------------------------------------------------------------
                        }

                        //--------------------------------------------------------------------
                        // Data Row
                        HtmlTableRow dTRow = new HtmlTableRow();
                       
                        HtmlTableCell dTCell = new HtmlTableCell();
                        dTCell.Attributes.Add("class", "accordaingridItem");
                        dTCell.InnerText = Convert.ToString(tRows + 1) +".";
                        dTRow.Controls.Add(dTCell);

                        dTCell = new HtmlTableCell();
                        dTCell.Attributes.Add("class", "accordaingridItem");
                        dTCell.InnerText = Dt.Rows[tRows]["PpDetails"].ToString();
                        dTCell.Align = "left";
                        dTRow.Controls.Add(dTCell);

                        dTCell = new HtmlTableCell();
                        dTCell.Attributes.Add("class", "accordaingridItem");
                        dTCell.InnerText = Dt.Rows[tRows]["ExmpApprovalStatus"].ToString();
                        dTCell.Align = "left"; 
                        dTRow.Controls.Add(dTCell);

                        dTable.Controls.Add(dTRow);
                        //--------------------------------------------------------------------
                    }


                    divStudentStatus.Controls.Add(dTable);

                    // Adding some empty space after each Table
                    Label LblEmpty = new Label();
                    LblEmpty.Text = "<br><br>";
                    divStudentStatus.Controls.Add(LblEmpty);
                    
                }
                
            }
            else
            {
                divStudentStatus.Style.Add("display", "block");
                divSimpleSearch.Style.Add("display", "block");

                Label LblNorecords = new Label();
                LblNorecords.Text = "<br><br><br><br><br> There is no " + lblPaper.Text + " Exemption Claim & Approval record(s) available for the searched student";
                LblNorecords.CssClass = "errorNote";
                divStudentStatus.Controls.Add(LblNorecords);
            }
        }

    }
}
