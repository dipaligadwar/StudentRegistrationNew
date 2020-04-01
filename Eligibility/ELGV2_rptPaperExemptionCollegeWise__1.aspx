<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ELGV2_rptPaperExemptionCollegeWise__1.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_PaperExemptionCollegeWise__1" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>List of Students</title>
    <link href="/CSS/UniPortal.css" type="text/css" rel="stylesheet" />
    <link href="/CSS/calendar-blue.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../CSS/DCPortal.css" />
   

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
                            Font-Bold="True" Text="List of Students for " meta:resourcekey="lblHeadResource1"></asp:Label>
                        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="10pt" meta:resourcekey="lblTitleResource1"></asp:Label>
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
                                            OnClick="btnPDF_Click" meta:resourcekey="btnPDFResource1"></asp:Button>
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
                                    <asp:BoundField DataField="ApprovalStatus" HeaderText="Approval Status"
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
        <input id="hidPpCrPrChID" runat="server" type="hidden" />
        <input id="hidTLMID" runat="server" type="hidden" />
        <input id="hidAMID" runat="server" type="hidden" />
        <input id="hidATID" runat="server" type="hidden" />
        <input id="hidInstID" runat="server" type="hidden" />        
      
        <input id="hidRCName" runat="server" type="hidden" />
        <input id="hidRCID" runat="server" type="hidden" />
        <input id = "hidCollCourseDetails" runat = "server" type="hidden" /> 
        <asp:Label ID="lblPRN" runat="server" Style="display: none" Text="PRN" meta:resourcekey="lblPRNResource1"></asp:Label>
        <asp:Label ID="lblCourse" runat="server" Style="display: none" Text="Course" meta:resourcekey="lblCourseResource1"></asp:Label>
    
    <div id="DivReportViewerDesign" runat="server" style="display: none;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" 
            Height="600px" Width="650px" meta:resourcekey="ReportViewer1Resource1">
            <LocalReport ReportEmbeddedResource="StudentRegistration.Eligibility.Rdlc.rdlcCollegewisePaperExemption__1.rdlc"
                EnableExternalImages="True">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    
    </form>
</body>
</html>