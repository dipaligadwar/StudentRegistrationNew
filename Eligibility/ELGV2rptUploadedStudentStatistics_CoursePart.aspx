<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="ELGV2rptUploadedStudentStatistics_CoursePart.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2rptUploadedStudentStatistics_CoursePart" meta:resourcekey="PageResource1" %>

<%@ Register Src="WebCtrl/SelectSingleCourse.ascx" TagName="YCMOU" TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/jsAjaxMethod.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>
    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>
    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>
    <script language="javascript" type="text/javascript">


        function showPDF() {
            window.open("rptUploadedStudentStatisticsPDF.aspx");
        }


        function hidunhid() {
            var val;
            val = document.getElementById("<%=hidCountryId.ClientID%>").value
            hideUnhide(val)
        }


        function fnSelectAllInstitutes(cbID) //Function used to select all Institute IDs on one click
        {

            var colno = 0;

            if (document.getElementById(cbID).checked) {

                for (var i = 1; i < len; i++) {
                    tbl.rows[i].cells[colno].childNodes[0].childNodes[0].checked = true;

                }
            }
            else {
                for (var i = 1; i < len; i++) {
                    tbl.rows[i].cells[colno].childNodes[0].childNodes[0].checked = false;

                }
            }
        }

        function fnCheck() {
            var bul = false;
            var retval = false;
            if (document.getElementById('ctl00_ContentPlaceHolder1_dgData') != null) {
                var tbl = document.getElementById('ctl00_ContentPlaceHolder1_dgData').getElementsByTagName("INPUT");
                for (i = 0; i < tbl.length; i++) {
                    if (tbl[i].checked) {
                        bul = true;
                        break;
                    }
                }

                if (bul) {
                    return true;

                }
                else {
                    alert("To View the Uploaded Statistics Report please select checkboxes to select the Colleges/Institutes/Study Centers from the list below and click on Next button");
                    return false;
                }



            }
        }
            
    </script>
    <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
        border="0" width="700">
        <tr style="width: 700">
            <td class="FormName" align="left" width="100%">
                <asp:Label ID="lblPageHead" runat="server" Font-Bold="True" CssClass="lblPageHead"
                    Text="Uploaded Data Status (Course Part Wise)" 
                    meta:resourcekey="lblPageHeadResource1"></asp:Label>
                <asp:Label ID="lblAcaYear" runat="server" Font-Bold="True" Font-Size="Small" 
                    meta:resourcekey="lblAcaYearResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" align="left">
                <table id="tblExportedDataMsg" runat="server" width="100%" style="display: none">
                    <tr>
                        <td style="height: 30px;" align="left">
                            <asp:Label runat="server" ID="lblExportedData" CssClass="errorNote" 
                                meta:resourcekey="lblExportedDataResource1"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div id="divWaitMsg" runat="server" style="display: none;">
                    <table align="center" width="100%">
                        <tr id="trWaitMsg" runat="server">
                            <td id="tdWaitmsg" align="center" runat="server" colspan="10">
                                <asp:Label ID="lblWaitMsg" runat="server" ForeColor="Tomato" Font-Bold="True" Width="99%"
                                    Height="20px" Text="Server is Busy. Please try again..." 
                                    meta:resourcekey="lblWaitMsgResource1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div id="divYCMOU" runat="server">
                    <uc3:YCMOU ID="YCMOU" runat="server"></uc3:YCMOU>
                </div>
                <br />
                <div id="DivCollegeUploadInfo" runat="server" style="display: none; margin-left: 10PX;
                    width: 600px">
                    &nbsp;&nbsp
                    <table align="center" id="tblSelect" runat="server" style="display: none; width: 590px;
                        border: solid 1px">
                        <tr>
                            <td style="text-align: left; height: 15px;">
                                <span style="color: red; vertical-align: left; font-family: Verdana;"><b>
                                    <asp:Label ID="lblTotalNoOfStudent" runat="server" 
                                    Text="This uploaded statistics count includes Eligible, Not Eligible, Pending, Provisionally Eligible and Eligibility Not Processed Student(s) Count. " 
                                    meta:resourcekey="lblTotalNoOfStudentResource1"></asp:Label>
                                </b></span>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <table id="tblheader" runat="server" style="display: none; width: 530px;" align="center">
                    <tr>
                        <td style="height: 6px" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnBackAcYear" runat="server" Text="Back" CssClass="butSubmit" 
                                OnClick="btnBackAcYear_Click" meta:resourcekey="btnBackAcYearResource1" />
                            <asp:Button ID="Button3" runat="server" Text="Export to Excel" CssClass="butSubmit"
                                OnClick="btnExportToExcel_Click" meta:resourcekey="Button3Resource1" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 6px">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <div id="divDGStat" style="display: none;" runat="server" align="center">
                    <asp:GridView ID="GVStat" runat="server" AutoGenerateColumns="False" OnRowDataBound="GVStat_RowDataBound"
                        Width="650px" ShowFooter="True" CellPadding="2" EnableViewState="False" OnSorted="GVStat_Sorted"
                        CssClass="clGrid grid-view" OnSorting="GVStat_Sorting" BorderStyle="Solid" BorderWidth="1px"
                        BorderColor="#336699" EnableModelValidation="True" 
                        meta:resourcekey="GVStatResource1">
                        <RowStyle CssClass="gridItem"></RowStyle>
                        <HeaderStyle CssClass="gridHeader" />
                        <Columns>
                            <asp:BoundField HeaderText="Sr.No." meta:resourcekey="BoundFieldResource1">
                                <HeaderStyle CssClass="gridHeader" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Course Name" HeaderText="Course Name" 
                                SortExpression="Course Name" meta:resourcekey="BoundFieldResource2">
                                <HeaderStyle CssClass="gridHeader" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CoursePart" 
                                HeaderText="Duration of Programme/ Course in Months" 
                                meta:resourcekey="BoundFieldResource3">
                                <HeaderStyle CssClass="gridHeader" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Total uploaded data" HeaderText="Data Uploaded (No. of Student)"
                                SortExpression="Total uploaded data" 
                                meta:resourcekey="BoundFieldResource4">
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                <HeaderStyle CssClass="gridHeader" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle HorizontalAlign="Right" />
                    </asp:GridView>
                </div>
                <br />
                <input id="hidInstID" runat="server" name="hidInstID" style="width: 24px; height: 22px"
                    type="hidden" />
                <input id="hid_fk_AcademicYr_ID" runat="server" name="hid_fk_AcademicYr_ID" style="width: 24px;
                    height: 22px" type="hidden" />
                <input id="hid_AcademicYear" runat="server" name="hid_AcademicYear" style="width: 24px;
                    height: 22px" type="hidden" />
                <input id="hid_strAcademicYr1" runat="server" name="hid_strAcademicYr1" value=""
                    type="hidden" />
                <input id="hid_strAcademicYr2" runat="server" name="hid_strAcademicYr2" value=""
                    type="hidden" />
                <input id="hidCountryId" style="width: 24px; height: 22px" type="hidden" value="0"
                    name="hidcountryId" runat="server" />
                <input id="hidCntry" style="width: 24px; height: 22px" type="hidden" value="0" name="Cntry"
                    runat="server" />
                <input id="hidStateID" style="width: 24px; height: 22px" type="hidden" value="0"
                    name="hidStateID" runat="server" />
                <input id="hidDistrictID" style="width: 24px; height: 22px" type="hidden" value="0"
                    name="hidDistrictID" runat="server" />
                <input id="hidTehsilID" style="width: 24px; height: 22px" type="hidden" value="0"
                    name="hidTehsilID" runat="server" />
                <input id="hidUniID" style="width: 24px; height: 22px" type="hidden" name="hidUniID"
                    runat="server" />
                <input type="hidden" runat="server" id="hidregisterationInfo" />
                <input id="hidCollCode" style="width: 24px; height: 22px" type="hidden" name="hidCollCode"
                    runat="server" />
                <input id="hidAllInstChkStatus" style="width: 24px; height: 22px" type="hidden" name="hidAllInstChkStatus"
                    runat="server" />
                <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" 
                    meta:resourcekey="lblCrResource1"></asp:Label>
                <asp:Label ID="lblUniversity" runat="server" Text="University" 
                    Style="display: none" meta:resourcekey="lblUniversityResource1"></asp:Label>
                <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" 
                    meta:resourcekey="lblCollegeResource1"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
