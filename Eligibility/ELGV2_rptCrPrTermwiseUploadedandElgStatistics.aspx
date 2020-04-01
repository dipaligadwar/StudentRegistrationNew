<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="ELGV2_rptCrPrTermwiseUploadedandElgStatistics.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_rptCrPrTermwiseUploadedandElgStatistics" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%--<contenttemplate>--%>
    <script type="text/javascript">
        //validate academic year

        function validateYear() {
            var flag = false;
            var i = -1;
            var myArr = new Array();
            myArr[++i] = new Array(document.getElementById("<%= ddlAcademicYr.ClientID%>"), "0", "Please Select Academic Year.", "select");
            var ret = validateMe(myArr, 50);
            return ret;
        }

        function clearLabel() {
            document.getElementById("<%= lblNoRec.ClientID%>").style.display = 'none';
        }	  
	            
	           	            
	            
    </script>
    <div class="FormName" align="left" width="100%">
        <asp:Label runat="server" Text="Course Part/Term wise Uploaded Students & Eligibility Statistics"
            Font-Bold="True" ID="lblPageHead" meta:resourcekey="lblPageHeadResource1"></asp:Label>
        <asp:Label runat="server" Font-Bold="True" Font-Size="Small" ID="lblAcaYear" meta:resourcekey="lblAcaYearResource1"></asp:Label>
    </div>
    <div id="DivReportInput" runat="server">
        <table style="border-collapse: collapse" id="table2" bordercolor="#c0c0c0" cellpadding="2"
            width="100%" border="0">
            <tbody>
                <tr>
                    <td valign="top" align="left">
                        <div runat="server" id="divAcademicYr" style="width: 90%; azimuth: center">
                            <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="right" colspan="3">
                                            <asp:Label ID="lblMessage" runat="server" CssClass="saveNote" Text="Report Generated Successfully"
                                                Style="display: none" meta:resourcekey="lblMessageResource1"></asp:Label>
                                            <asp:Label ID="lblError" runat="server" CssClass="errorNote" Text="There was an error in Report Generation. Please try again later."
                                                Style="display: none" meta:resourcekey="lblErrorResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 225px; height: 20px" align="right">
                                            <asp:Label runat="server" Text="Select Academic Year" Font-Bold="True" Width="221px"
                                                ID="lblAcyr" meta:resourcekey="lblAcyrResource1"></asp:Label>
                                        </td>
                                        <td style="width: 1%; height: 20px" align="center">
                                            <b>&nbsp;:&nbsp;</b>
                                        </td>
                                        <td runat="server" id="tdAcdYr" style="height: 20px" align="left">
                                            <asp:DropDownList runat="server" CssClass="selectbox" Width="245px" ID="ddlAcademicYr"
                                                meta:resourcekey="ddlAcademicYrResource1" onchange="clearLabel()">
                                                <asp:ListItem Text="--- Select ---" Value="0" meta:resourceKey="ListItemResource1">
                                                </asp:ListItem>
                                            </asp:DropDownList>
                                            <font class="Mandatory">*</font>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <br />
                        <asp:Button ID="btnGenerate" runat="server" Text="Generate Report" CssClass="butSubmit"
                            OnClientClick="return validateYear()" OnClick="btnGenerate_Click" meta:resourcekey="btnGenerateResource2" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <br />
                        <asp:Label ID="lblNoRec" runat="server" CssClass="errorNote" Text="No Record(s) Found."
                            Style="display: none" meta:resourcekey="lblNoRecResource1" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <br />
                        <asp:Label ID="lblNote" runat="server" CssClass="errorNote" meta:resourcekey="lblNoteResource1"
                            Text=" Note: Please select the Academic Year and click on 'Generate Report' button.
                        "></asp:Label>
                        <br />
                    </td>
                </tr>
            </tbody>
        </table>
        <center>
            <table>
                <tbody>
                    <tr>
                        <td>
                            <asp:Button runat="server" Text="Export to Excel" CssClass="butSubmit" ID="btnExcel"
                                Style="display: none" OnClick="btnExportToExcel_Click" meta:resourcekey="btnExcelResource1">
                            </asp:Button>
                        </td>
                        <td>
                            &nbsp; &nbsp;
                        </td>
                        <td>
                            <asp:Button runat="server" Text="Export to PDF" CssClass="butSubmit" ID="btnPDF"
                                Style="display: none" OnClick="btnPDF_Click" meta:resourcekey="btnPDFResource1">
                            </asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </center>
        <div runat="server" id="divDGStat">
            <center>
            </center>
            <br />
            <br />
            <asp:GridView ID="GVReportEligibilitystat" runat="server" AutoGenerateColumns="False"
                BorderStyle="Solid" CssClass="clGrid grid-view" OnRowDataBound="GVReportEligibilitystat_RowDataBound"
                ShowFooter="True" AllowSorting="True" EnableModelValidation="True" meta:resourcekey="GVReportEligibilitystatResource1">
                <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No." meta:resourcekey="TemplateFieldResource1">
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%# (Container.DataItemIndex)+1 %>.
                        </ItemTemplate>
                        <HeaderStyle Width="5%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Course_Name" HeaderText="Course Name" SortExpression="Course_Name"
                        meta:resourcekey="BoundFieldResource1">
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Part_Term_Desc" HeaderText="Course Part/Term Name" meta:resourcekey="BoundFieldResource2">
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Uploaded" HeaderText="Data Uploaded(No of Students)" meta:resourcekey="BoundFieldResource3">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EligibilityProcessed" HeaderText="Eligibility Processed Count"
                        meta:resourcekey="BoundFieldResource4">
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Eligible" HeaderText="Eligible" meta:resourcekey="BoundFieldResource5">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NotEligible" HeaderText="Not Eligible" meta:resourcekey="BoundFieldResource6">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PendingEligible" HeaderText="Pending" meta:resourcekey="BoundFieldResource7">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProvisionalEligible" HeaderText="Provisional (PRN Generated)"
                        meta:resourcekey="BoundFieldResource8">
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EligibilityNotProcessed" HeaderText="Eligibility Not Processed"
                        meta:resourcekey="BoundFieldResource9">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="15%" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="Large"></FooterStyle>
            </asp:GridView>
        </div>
    </div>
    <div id="DivReportViewerDesign" runat="server" style="display: none; padding-top: 15px;
        padding-bottom: 10px;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            OnPreRender="ReportViewer1_PreRender" Height="600px" Width="100%" meta:resourcekey="ReportViewer1Resource1"
            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportEmbeddedResource="StudentRegistration.Eligibility.Rdlc.CrPrTermwiseUploadedandElgStatistics.rdlc"
                EnableExternalImages="True">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    <div id="DivNoReportMsg" runat="server" style="display: none">
        <asp:Label ID="LblMsg" runat="server" Text="Report is not available for selected academic year."
            CssClass="errorNote" meta:resourcekey="LblMsgResource1"></asp:Label>
    </div>
    <asp:Label runat="server" Style="display: none" Text="College" ID="lblCollege" meta:resourceKey="lblCollegeResource1"></asp:Label>
    <asp:Label runat="server" Style="display: none" Text="Course" ID="lblCr" meta:resourceKey="lblCrResource1"></asp:Label>
    <input runat="server" id="hid_fk_AcademicYr_ID" type="hidden" />
    <%--</contenttemplate>--%>
    <%-- &nbsp;&nbsp;
    <localreport enableexternalimages="True" reportembeddedresource="StudentRegistration.Eligibility.Rdlc.CrPrTermwiseUploadedandElgStatistics.rdlc">
            </localreport>--%>
</asp:Content>
