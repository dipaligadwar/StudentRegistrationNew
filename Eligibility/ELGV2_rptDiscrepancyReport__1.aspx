<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ELGV2_rptDiscrepancyReport__1.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_rptDiscrepancyReport__1" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>
   <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
   <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Discrepant Student Details</title>
    <link href="/CSS/UniPortal.css" type="text/css" rel="stylesheet" />
    <link href="/CSS/calendar-blue.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../CSS/DCPortal.css" />
    <%--    <link href="/CSS/gray.css" rel="stylesheet" title='Color-Scheme' type="text/css" />
--%>

  
    <script type="text/javascript">
     
     function closewindow()
     {
        return window.close();     
     }
     
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:toolkitscriptmanager id="ToolkitScriptManager1" runat="server" ScriptMode="Release"  combinescripts="false" />     

        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            border="0">
            <tr>
                <td>
                    <!-- Grid for Student Details -->
                    <div id="divStudent" style="width: 100%; position: relative; border-collapse: collapse"
                        runat="server">
                        <asp:Label ID="lblPageHead" Style="color: #EE6340; font-size: 10pt;" runat="server"
                            Font-Bold="True" Text="List of Discrepant Students for " meta:resourcekey="lblHeadResource1"></asp:Label>
                        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="10pt"></asp:Label>
                        <br />
                        <br />
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="Button3" runat="server" Text="Export to Excel" CssClass="butSubmit"
                                            OnClick="btnExportToExcel_Click" meta:resourcekey="Button3Resource1" /></td>
                                    <td>
                                        <asp:Button runat="server" Text="Export to PDF" CssClass="butSubmit" ID="btnPDF"
                                            OnClick="btnPDF_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <asp:GridView ID="GVStudent" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                CssClass="clGrid grid-view" Width="100%" Style="border: solid 1px #C0C0C0;" meta:resourcekey="GVStudentResource1">
                                <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                                <Columns>
                                    <asp:TemplateField meta:resourcekey="TemplateFieldResource4" HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <%# (Container.DataItemIndex)+1 %>.
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Student Name" HeaderText="Student Name" SortExpression="Student Name"
                                        meta:resourcekey="BoundFieldResource1">
                                        <ItemStyle Width="2%" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                                            Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PRN_Number" HeaderText="PRN" meta:resourcekey="BoundFieldResource2">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                                            Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RPV2PrevCrPrChStatus" HeaderText="Result Status of previous Course Part Term"
                                        meta:resourcekey="BoundFieldResource3">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                                            Width="20%" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="Large" />
                            </asp:GridView>
                        </center>
                    </div>
                    <br />
                </td>
            </tr>
        </table>
        <input id="hid_fk_AcademicYr_ID" runat="server" name="hid_fk_AcademicYr_ID" type="hidden" />
        <input id="hid_AcademicYear" runat="server" name="hid_AcademicYear" type="hidden" />
        <input id="hid_strAcademicYr1" runat="server" name="hid_strAcademicYr1" type="hidden" />
        <input id="hid_strAcademicYr2" runat="server" name="hid_strAcademicYr2" type="hidden" />
        <input id="hidInstId" runat="server" name="hidInstId" type="hidden" />
        <input id="hidFacID" runat="server" style="width: 32px; height: 22px" type="hidden" />
        <input id="hidCrID" runat="server" style="width: 32px; height: 22px" type="hidden" />
        <input id="hidMoLrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
        <input id="hidPtrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
        <input id="hidBrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
        <input id="hidCrPrDetailsID" runat="server" style="width: 32px; height: 22px" type="hidden" />
        <input id="hidCrPrChIDs" runat="server" style="width: 32px; height: 22px" type="hidden" />
        <input id="hidFacName" runat="server" type="hidden" />
        <input id="hidCrName" runat="server" type="hidden" />
        <input id="hidBrName" runat="server" type="hidden" />
        <input id="hidCrPrName" runat="server" type="hidden" />
        <input id="hidCrPrDetName" runat="server" type="hidden" />
        <input id="hidCrPrChName" runat="server" type="hidden" />
        <input id="hidAcYrName" runat="server" type="hidden" />
        <asp:Label ID="lblPRN" runat="server" Style="display: none" Text="PRN" meta:resourcekey="lblPRNResource1">></asp:Label>
        <asp:Label ID="lblCourse" runat="server" Style="display: none" Text="Course" meta:resourcekey="lblCourseResource1">></asp:Label>
        <input id="hidRCName" runat="server" type="hidden" />
        <input id="hidRCID" runat="server" type="hidden" />
 
    <div id="DivReportViewerDesign" runat="server" style="display: none;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="650px" meta:resourcekey="ReportViewer1Resource1">
            <LocalReport ReportEmbeddedResource="StudentRegistration.Eligibility.Rdlc.rdlcMIS.rdlc"
                EnableExternalImages="True">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>  
    </form>
</body>
</html>
