<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="ELGV2rptInvoiceGenration_MonthlyReport.aspx.cs" Inherits="StudentRegistration.ELGV2rptInvoiceGenration_MonthlyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/jsAjaxMethod.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>
    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>
    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>
    <script language="javascript" type="text/javascript">




        function fnValidate(ctrlToValidate) {
            debugger;
            var myArr = new Array();
            var i = 0;        
             var ddlAcademicYear = document.getElementById("<%=ddlAcademicYear.ClientID %>");
             var ddlMonth = document.getElementById("<%=ddlMonth.ClientID %>");
             var ddlAcadYear = document.getElementById("<%=ddlAcadYear.ClientID %>");

             if (ddlAcademicYear.value == "0") {
                 alert("Please Select Academic Year.")
                 return false;
             }

             if (ddlMonth.value == "0") {
                 alert("Please Select  Month.")
                 return false;
             }
             if (ddlAcadYear.value == "-1") {
                 alert("Please Select Year.")
                 return false;
             }
             return true;
        }



    </script>
    <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
        border="0" width="700">
        <tr style="width: 700">
            <td class="FormName" align="left" width="100%">
                <asp:Label ID="lblPageHead" runat="server" Font-Bold="True" CssClass="lblPageHead"
                    Text="Monthly Invoice Statistics Report" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                <asp:Label ID="lblAcaYear" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="lblAcaYearResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" align="left">
            <br />
                <div align="right">
                    <asp:Label ID="lblErrorMsg" runat="server" CssClass="errorNote" meta:resourcekey="lblErrorMsgResource1"  Visible="false"/>
                </div>
                <br />
                <div id="divYear" runat="server">
                    <div id="divAcadYear" style="width: 700px; clear: both;" runat="server">
                        <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                            Academic Year<b> : </b>
                        </div>
                        <div align="left" style="padding: 3px" class="clLeft">
                            <asp:DropDownList ID="ddlAcademicYear" Width="420px" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlAcademicYear_SelectedIndexChanged">
                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">---- Select ----</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<font class="Mandatory">*</font></div>
                    </div>
                    <div id="divMonth" style="width: 700px; clear: both;" runat="server" visible="false">
                        <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                            Select Month<b> : </b>
                        </div>
                        <div align="left" style="padding: 3px" class="clLeft">
                            <asp:DropDownList ID="ddlMonth" Width="420px" runat="server">
                                <asp:ListItem Value="0">---- Select ----</asp:ListItem>
                                <asp:ListItem Value="1">January </asp:ListItem>
                                <asp:ListItem Value="2"> February </asp:ListItem>
                                <asp:ListItem Value="3">March</asp:ListItem>
                                <asp:ListItem Value="4">April</asp:ListItem>
                                <asp:ListItem Value="5"> May </asp:ListItem>
                                <asp:ListItem Value="6"> June</asp:ListItem>
                                <asp:ListItem Value="7"> July </asp:ListItem>
                                <asp:ListItem Value="8">August</asp:ListItem>
                                <asp:ListItem Value="9">September</asp:ListItem>
                                <asp:ListItem Value="10">October </asp:ListItem>
                                <asp:ListItem Value="11">November </asp:ListItem>
                                <asp:ListItem Value="12">December </asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<font class="Mandatory">*</font></div>
                    </div>
                    <div id="divYear1" style="width: 700px; clear: both;" runat="server" visible="false">
                        <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                            Academic Year<b> : </b>
                        </div>
                        <div align="left" style="padding: 3px" class="clLeft">
                            <asp:DropDownList ID="ddlAcadYear" Width="420px" runat="server">
                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">---- Select ----</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<font class="Mandatory">*</font></div>
                    </div>
                    <div align="center" class="clButtonHolder" style="clear: both; padding-top: 5px;">
                        <asp:Button ID="btnProceed" runat="server" Text="Proceed" OnClientClick="return fnValidate(this);"
                            OnClick="btnProceed_Click" meta:resourcekey="btnProceedResource1" />
                    </div>
                </div>
                <table id="tblheader" runat="server" style="display: none; width: 530px;" align="center">
                    <tr>
                        <td style="height: 6px" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnBackAcYear" runat="server" Text="Back" CssClass="butSubmit" OnClick="btnBackAcYear_Click"
                                meta:resourcekey="btnBackAcYearResource1" />
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
                    <asp:GridView ID="GVStat" runat="server" AutoGenerateColumns="False" Width="650px"
                        OnRowDataBound="GVStat_RowDataBound" ShowFooter="True" CellPadding="2" EnableViewState="False"
                        CssClass="clGrid grid-view" BorderStyle="Solid" BorderWidth="1px" BorderColor="#336699"
                        EnableModelValidation="True" meta:resourcekey="GVStatResource1">
                        <RowStyle CssClass="gridItem"></RowStyle>
                        <HeaderStyle CssClass="gridHeader" />
                        <Columns>
                            <asp:BoundField HeaderText="Sr.No." meta:resourcekey="BoundFieldResource1">
                                <HeaderStyle CssClass="gridHeader" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Course Name" HeaderText="Course Name" SortExpression="Course Name"
                                meta:resourcekey="BoundFieldResource2">
                                <HeaderStyle CssClass="gridHeader" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CoursePart" HeaderText="Duration of Programme/ Course in Months"
                                meta:resourcekey="BoundFieldResource3">
                                <HeaderStyle CssClass="gridHeader" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Total uploaded data" HeaderText="Data Uploaded (No. of Student)"
                                SortExpression="Total uploaded data" meta:resourcekey="BoundFieldResource4">
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                <HeaderStyle CssClass="gridHeader" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle HorizontalAlign="Right" />
                    </asp:GridView>
                </div>
                <br />
                <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
                <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
                    meta:resourcekey="lblUniversityResource1"></asp:Label>
                <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
