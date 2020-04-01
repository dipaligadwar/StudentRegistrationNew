<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="ELGV2_rptPaperExemptionCoursewise.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_rptPaperExemptionCoursewise" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

     <style type="text/css">
      .hidden-column {
        display: none;
      }
       </style>
  
    <asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
            <table style="border-collapse: collapse" id="table2" bordercolor="#c0c0c0" cellpadding="2"
                width="100%" border="0">
                <tbody>
                    <tr>
                        <td class="FormName" align="left" width="100%">
                            <asp:Label runat="server" Text="Course wise Paper Exemption Statistics" Font-Bold="True" ID="lblPageHead" meta:resourcekey="lblPageHeadResource2"></asp:Label>

                            <asp:Label runat="server" Font-Bold="True" Font-Size="Small" ID="lblAcaYear" meta:resourcekey="lblAcaYearResource2"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                    <td>
                    <asp:Label ID="msg" runat="server" CssClass="errorNote"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left">
                        
                        <center>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:Button runat="server" Text="Export to Excel" CssClass="butSubmit" ID="btnExcel" Style="display: none" meta:resourcekey="btnExcelResource2" OnClick="btnExcel_Click"></asp:Button>

                                            </td>
                                            <td>
                                                <asp:Button runat="server" Text="Export to PDF" CssClass="butSubmit" ID="btnPDF" Style="display: none" meta:resourcekey="btnPDFResource2" OnClick="btnPDF_Click"></asp:Button>

                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                         </center>
                         
                         
                         
                         <div runat="server" ID="divDGCourseStat" style="position: relative">
                            <br />
                            <br />
                            <asp:GridView runat="server" AutoGenerateColumns="False" DataKeyNames="pkFacID,pkCrID,pkMoLrnID,pkPtrnID,pkBrnID,pkCrPrDetails,pkCrPrChID, Course Name" ShowFooter="True" BorderStyle="None" CssClass="clGrid grid-view" ID="GVCourseStat" Style="border-style: Double; border-collapse: collapse;" meta:resourcekey="GVCourseStatResource2" OnRowDataBound="GVCourseStat_RowDataBound" OnRowCommand="GVCourseStat_RowCommand"><Columns>
<asp:TemplateField HeaderText="Sr. No." meta:resourcekey="TemplateFieldResource4"><ItemTemplate>
<%# (Container.DataItemIndex)+1 %>.
                                        
</ItemTemplate>

<HeaderStyle Width="7%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField meta:resourcekey="TemplateFieldResource5"><ItemTemplate>
<asp:LinkButton runat="server" CommandName="showHide" CommandArgument='<%# Eval("Course Name") %>' ID="lnkPlus" m><asp:Image runat="server" AlternateText="Click to show details" ImageUrl="../Images/plus.gif" ID="imgdiv"></asp:Image>
</asp:LinkButton>

                                        
</ItemTemplate>

<ItemStyle Width="4%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Course Name" HeaderText="Course Name" SortExpression="Course Name" meta:resourcekey="BoundFieldResource9">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Granted Count" HeaderText="Granted Count" SortExpression="Granted Count" meta:resourcekey="BoundFieldResource10">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Denied Count" HeaderText="Denied Count" SortExpression="Denied Count" meta:resourcekey="BoundFieldResource11">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Pending Count" HeaderText="Pending Count" SortExpression="Pending Count" meta:resourcekey="BoundFieldResource12">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField meta:resourcekey="TemplateFieldResource6"><ItemTemplate>
                                            <tr>
                                                <td colspan="13">
                                                    <div runat="server" ID="divHideMeCourse" align="center" style="display: none; position: relative;
                                                        width: 100%;">
                                                        <div runat="server" ID="divCourseInnerHide" style="display: none; left: 10px;">
                                                            <br />
                                                            <asp:GridView runat="server" AutoGenerateColumns="False" BorderStyle="None" CssClass="clGrid grid-view" Width="94%" ID="GVInner" Style="border-color: #FFD275; display:none; border-style: Double; border-collapse: collapse;" meta:resourcekey="GVInnerResource2"><Columns>
<asp:BoundField DataField="Paper TLM-AM-AT" HeaderText="Paper TLM-AM-AT" meta:resourcekey="BoundFieldResource13">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0" Width="50%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Granted Count" HeaderText="Granted Count" meta:resourcekey="BoundFieldResource14">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Denied Count" HeaderText="Denied Count" meta:resourcekey="BoundFieldResource15">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Pending Count" HeaderText="Pending Count" SortExpression="Total uploaded data" meta:resourcekey="BoundFieldResource16">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<HeaderStyle BackColor="#E0E0E0" CssClass="gridHeader"></HeaderStyle>

<RowStyle CssClass="gridItem"></RowStyle>
</asp:GridView>

                                                        </div>

                                                        <br />
                                                    </div>

                                                </td>
                                            </tr>
                                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0" CssClass="hidden-column"></HeaderStyle>

<ItemStyle CssClass="hidden-column"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="Large"></FooterStyle>

<HeaderStyle BackColor="#E0E0E0" CssClass="gridHeader"></HeaderStyle>
</asp:GridView>

                        </div>

                        <table runat="server" ID="tblExportedDataMsg" style="display: none"><tr runat="server" ID="Tr2"><td runat="server" ID="Td2" style="height: 30px" align="left">
                                    <asp:Label runat="server" CssClass="errorNote" ID="lblExportedData"></asp:Label>

                                </td>
</tr>
</table>

                    
                    
                    
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <input runat="server" ID="hidUniID" type="hidden"></input>

        <asp:Label runat="server" Text="College" ID="lblCollege" Style="display: none" meta:resourceKey="lblCollegeResource1"></asp:Label>

        <asp:Label runat="server" Text="Course" ID="lblCr" Style="display: none" meta:resourceKey="lblCrResource1"></asp:Label>

        <asp:Label runat="server" Text="Paper" ID="lblPaper" Style="display: none" meta:resourceKey="lblPaperResource1"></asp:Label>

        
</ContentTemplate>
        <Triggers>
<asp:PostBackTrigger ControlID="btnExcel"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="btnPDF"></asp:PostBackTrigger>
</Triggers>
   </asp:UpdatePanel>
    <div id="divUP" runat="server">
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </div>

    <div id="DivReportViewerDesign" runat="server" style="display: none;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="650px" meta:resourcekey="ReportViewer1Resource2">
            <LocalReport ReportEmbeddedResource="StudentRegistration.Eligibility.Rdlc.rdlcCoursewisePaperExemption.rdlc"
                EnableExternalImages="True" ReportPath="~\Eligibility\Rdlc\rdlcCoursewisePaperExemption.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    
</asp:Content>

