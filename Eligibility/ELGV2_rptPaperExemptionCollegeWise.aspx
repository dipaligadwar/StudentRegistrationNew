<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_rptPaperExemptionCollegeWise.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_rptPaperExemptionCollegeWise" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <style type="text/css">
      .hidden-column {
        display: none;
      }
       </style>

    <script type="text/javascript">
  
 function openNewWindow(PpCrPrChID, TchLrMthID, AMthID, ATypeID, InstID)
	        {       
	        
	         var hiddenCollCourseDetails = document.getElementById('<%=hidCollCourseDetails.ClientID%>');
        
            window.open("ELGV2_rptPaperExemptionCollegeWise__1.aspx?&PpCrPrChId="+PpCrPrChID+"&TchLrMthID="+TchLrMthID+"&AMthID="+AMthID+"&ATypeID="+ATypeID+"&InstID="+InstID+"&CollCourseDetails="+hiddenCollCourseDetails.value+"","_blank","location=no,height=320,width=520,status=yes,addressbar=no,toolbar=no,menubar=no,scrollbars =yes,left=250,top=300,screenX=0,screenY=400'");
    	    
    
    	        return false;
	        }
    </script>

    <asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
            <table style="border-collapse: collapse" id="table2" bordercolor="#c0c0c0" cellpadding="2"
                width="100%" border="0">
                <tbody>
                    <tr>
                        <td class="FormName" align="left" width="100%">
                            <asp:Label runat="server" Text="College Wise Paper Exemption Statistics" Font-Bold="True"
                                ID="lblPageHead" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                            <asp:Label ID="lblAcaYear" runat="server" Font-Bold="True"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left">
                            <center>
                                <table>
                                    <tbody>
                                    </tbody>
                                    <caption>
                                        <br />
                                        <tr>
                                            <td>
                                                <asp:Button ID="Button3" runat="server" CssClass="butSubmit" 
                                                    meta:resourcekey="Button3Resource1" OnClick="btnExportToExcel_Click" 
                                                    Style="display: none" Text="Export to Excel" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnPDF" runat="server" CssClass="butSubmit" 
                                                    meta:resourcekey="btnPDFResource1" OnClick="btnPDF_Click" Style="display: none" 
                                                    Text="Export to PDF" />
                                            </td>
                                        </tr>
                                    </caption>
                                </table>
                            </center>
                        </td>
                    </tr>
                </tbody>
            </table>
            </center>
            <div ID="divDGStat" runat="server" style="display: none; position: relative">
                <center>
                </center>
                <br />
                <br />
                <asp:GridView ID="GVCollege" runat="server" AutoGenerateColumns="False" 
                    BorderStyle="None" CssClass="clGrid grid-view" DataKeyNames="pk_Inst_ID" 
                    meta:resourcekey="GVCollegeResource1" OnRowCommand="GVCollege_RowCommand" 
                    OnRowDataBound="GVCollege_RowDataBound" ShowFooter="True" 
                    Style="border-style: Double; border-collapse: collapse;">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No." 
                            meta:resourcekey="TemplateFieldResource1">
                            <ItemTemplate>
                                <%# (Container.DataItemIndex)+1 %>.
                            </ItemTemplate>
                            <HeaderStyle Width="7%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkPlus" runat="server" 
                                    CommandArgument='<%# Eval("pk_Inst_ID") %>' CommandName="showHide">
                                <asp:Image ID="imgdiv" runat="server" AlternateText="Click to show details" 
                                    ImageUrl="../Images/plus.gif" />
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="4%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="RegionalCenterInfo" HeaderText="Regional Center" 
                            meta:resourceKey="BoundFieldResourceRegionalCenter">
                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="College Code" HeaderText="College Code" 
                            meta:resourceKey="BoundFieldResource27">
                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="College Name" HeaderText="College Name" 
                            meta:resourceKey="BoundFieldResource28" SortExpression="College Name">
                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GrantedCount" HeaderText="Granted Count" 
                            meta:resourceKey="BoundFieldResource30">
                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DeniedCount" HeaderText="Denied Count" 
                            meta:resourceKey="BoundFieldResource31" SortExpression="DeniedCount">
                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PendingCount" HeaderText="Pending Count" 
                            meta:resourceKey="BoundFieldResource33" SortExpression="PendingCount">
                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField meta:resourceKey="TemplateFieldResource3">
                            <ItemTemplate>
                                <tr>
                                    <td colspan="13">
                                        <div ID="divHideMeCourse" runat="server" align="center" style="display: none; position: relative;
                                                            width: 100%;">
                                            <div ID="divCourseInnerHide" runat="server" style="display: none; left: 10px;">
                                                <br />
                                                <asp:GridView ID="GVInner" runat="server" AutoGenerateColumns="False" 
                                                    BorderStyle="None" CssClass="clGrid grid-view" 
                                                    DataKeyNames="pkFacID,pkCrID,pkMoLrnID,pkPtrnID,pkBrnID,pkCrPrDetails,pkCrPrChID,pk_Inst_ID" 
                                                    meta:resourceKey="GVInnerResource1" OnRowCommand="GVInner_RowCommand" 
                                                    OnRowDataBound="GVInner_RowDataBound" 
                                                    Style="border-color: #FFD275;
                                                                    display: none; border-style: Double; border-collapse: collapse;" 
                                                    Width="94%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkPlusSub" runat="server" CommandName="showHideSub">
                                                                <asp:Image ID="imgdiv" runat="server" AlternateText="Click to show details" 
                                                                    ImageUrl="../Images/plus.gif" />
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="4%" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Course Name" HeaderText="Course Name" 
                                                            meta:resourceKey="BoundFieldResource1">
                                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                                                VerticalAlign="Middle" Width="50%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="50%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Granted Count" HeaderText="Granted Count" 
                                                            meta:resourceKey="BoundFieldResource30">
                                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                                                VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Denied Count" HeaderText="Denied Count" 
                                                            meta:resourceKey="BoundFieldResource31" SortExpression="DeniedCount">
                                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                                                VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Pending Count" HeaderText="Pending Count" 
                                                            meta:resourceKey="BoundFieldResource33" SortExpression="PendingCount">
                                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                                                VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField meta:resourceKey="TemplateFieldResource3">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td colspan="13">
                                                                        <div ID="divHideMeCourseSub" runat="server" align="center" style="display: none;
                                                                                            position: relative; width: 100%;">
                                                                            <div ID="divCourseInnerHideSub" runat="server" 
                                                                                style="display: none; left: 10px;">
                                                                                <br />
                                                                                <asp:GridView ID="GVInnerSub" runat="server" AutoGenerateColumns="False" 
                                                                                    BorderStyle="None" CssClass="clGrid grid-view" 
                                                                                    DataKeyNames="pk_Pp_PpHead_CrPrCh_ID,pk_TchLrnMth_ID,pk_AssMth_ID,pk_AssType_ID,pk_Inst_ID" 
                                                                                    meta:resourcekey="GVInnerSubResource1" OnRowDataBound="GVSubInner_RowDataBound" 
                                                                                    Style="border-color: #FFD275;
                                                                                                    display: none; border-style: Double; border-collapse: collapse;" 
                                                                                    Width="94%">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="Paper TLM-AM-AT" HeaderText="Paper TLM-AM-AT" 
                                                                                            meta:resourceKey="BoundFieldResource1">
                                                                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                                                                                VerticalAlign="Middle" Width="50%" />
                                                                                            <ItemStyle HorizontalAlign="Left" Width="50%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="Granted Count" HeaderText="Granted Count" 
                                                                                            meta:resourceKey="BoundFieldResource30">
                                                                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                                                                                VerticalAlign="Middle" />
                                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="Denied Count" HeaderText="Denied Count" 
                                                                                            meta:resourceKey="BoundFieldResource31" SortExpression="DeniedCount">
                                                                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                                                                                VerticalAlign="Middle" />
                                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="Pending Count" HeaderText="Pending Count" 
                                                                                            meta:resourceKey="BoundFieldResource33" SortExpression="PendingCount">
                                                                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" 
                                                                                                VerticalAlign="Middle" />
                                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="View StudentList">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkStudList" runat="server" BackColor="White" 
                                                                                                    CommandName="showStudList" ForeColor="Black"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle ForeColor="Blue" Width="10%" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle BackColor="#E0E0E0" CssClass="gridHeader" />
                                                                                    <RowStyle CssClass="gridItem" />
                                                                                </asp:GridView>
                                                                            </div>
                                                                            <br />
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <HeaderStyle BackColor="#E0E0E0" CssClass="hidden-column" 
                                                                HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle CssClass="hidden-column" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#E0E0E0" CssClass="gridHeader" />
                                                    <RowStyle CssClass="gridItem" />
                                                </asp:GridView>
                                            </div>
                                            <br />
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#E0E0E0" CssClass="hidden-column" 
                                HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle CssClass="hidden-column" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle Font-Bold="True" Font-Size="Large" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#E0E0E0" CssClass="gridHeader" />
                </asp:GridView>
                <br />
            </div>
            <table ID="tblExportedDataMsg" runat="server" style="display: none">
                <tr ID="Tr2" runat="server">
                    <td ID="Td2" runat="server" align="left" style="height: 30px">
                        <asp:Label ID="lblExportedData" runat="server" CssClass="errorNote" 
                            meta:resourceKey="lblExportedDataResource1"></asp:Label>
                    </td>
                </tr>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <input runat="server" id="hidUniID" type="hidden"></input>
            <input runat="server" id="hidInstID" type="hidden"></input>
            <input runat="server" id="hidCollName" type="hidden"></input>
            <input runat="server" id="hidFacID" type="hidden"></input>
            <input runat="server" id="hidCrID" type="hidden"></input>
            <input runat="server" id="hidMOLID" type="hidden"></input>
            <input runat="server" id="hidPtrnID" type="hidden"></input>
            <input runat="server" id="hidBrnID" type="hidden"></input>
            <input runat="server" id="hidCrPrDetID" type="hidden"></input>
            <input runat="server" id="hidCrPrChID" type="hidden"></input>
            <input runat="server" id="hidPopUpHeader" type="hidden"></input>
            <input runat="server" id="hidCollCourseDetails" type="hidden"></input>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button3"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnPDF"></asp:PostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
    <table>
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </table>
    <div id="DivReportViewerDesign" runat="server" style="display: none;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="650px" meta:resourcekey="ReportViewer1Resource1">
            <LocalReport ReportEmbeddedResource="StudentRegistration.Eligibility.Rdlc.CollwisePpExemWithOutRCcode.rdlc"
                EnableExternalImages="True">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    <asp:Label ID="lblInstitute" runat="server" Style="display: none" Text="College"
        meta:resourcekey="lblInstitute1"></asp:Label>
    <asp:Label runat="server" Text="Paper" ID="lblPaper" Style="display: none" meta:resourceKey="lblPaperResource1"></asp:Label>
</asp:Content>
