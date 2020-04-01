<%@ Page Language="c#" Codebehind="EligibilityIndex.aspx.cs" AutoEventWireup="true"
    MasterPageFile="~/Home.Master" Inherits="StudentRegistration.Eligibility.EligibilityIndex"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link rel="stylesheet" type="text/css" href="../Eligibility/CSS/Eligibility_CSS.css" />
    <link href="../css/Portal.css" type="text/css" rel="stylesheet" />

    

    <div align="center">
        <div align="left" style="position: relative;">
            <table id="table1" style="border-collapse: collapse;" bordercolor="#c0c0c0" width="100%"
                border="0">
                <tr width="100%">
                    <td class="masterheading" align="left" width="10%" style="display: none; border-bottom: #ffd275 1px solid;
                        height: 17px; vertical-align: middle" id="tdImage" runat="server">
                        <asp:Image ID="imgContainer" runat="server" Visible="False" meta:resourcekey="imgContainerResource1">
                        </asp:Image>
                    </td>
                    <td class="masterheading" align="left" width="100%">
                        <asp:Label ID="lblContentTitle" Height="16px" Style="text-align: left" runat="server"
                            meta:resourcekey="lblContentTitleResource1"></asp:Label>
                        <br />
                        <asp:Label ID="lblUpdationDate" Height="19px" runat="server" Style="text-align: left;"
                            ForeColor="Maroon" Font-Bold="False" meta:resourcekey="lblUpdationDateResource1"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table id="table2" style="border-collapse: collapse;" bordercolor="#c0c0c0" cellpadding="2"
            width="100%" border="0">
            <tr>
                <td valign="top" align="left">
                                        <div  id="div3" style="width: 97%; height: 30px" runat="server">
                                            <asp:HyperLink runat="server" Width="100%" ID="linkMorePendingForElgProc" CssClass ="clMenuHeader clGrid accordionHeader" meta:resourcekey="linkMorePendingForElgProcResource1"> Pending for Eligibility Processing</asp:HyperLink>
                                        </div>
                           
                                        <div style="width: 97%; height: 30px" id="div2" runat="server">
                                                <asp:HyperLink runat="server" Width="100%" ID="linkMoreUnprocElgStats" CssClass ="clMenuHeader clGrid accordionHeader" meta:resourcekey="linkMoreUnprocElgStatsResource1">Unprocessed Eligibility Statistics</asp:HyperLink>
                                        </div>
                                       
                             
                                        <div id="divMore"  style="width: 97%; height: 30px" runat="server">
                                            <asp:HyperLink runat="server" Width="100%" ID="linkMoreUplDiscStats" CssClass ="clMenuHeader clGrid accordionHeader"  meta:resourcekey="linkMoreUplDiscStatsResource1">Uploaded Discrepancy Statistics</asp:HyperLink>
                                        </div>
                                       
                           
                                        <div id="div7"  style="width: 97%; height: 30px" runat="server">
                                            <asp:HyperLink runat="server" Width="100%" ID="linkMorePendingExApproval"  CssClass ="clMenuHeader clGrid accordionHeader"  meta:resourcekey="linkMoreUplDiscStatsResource2">Pending Exemption Approvals</asp:HyperLink>
                                        </div>
                         
                                        <div id="div1"  style="width: 97%; height: 30px" runat="server">
                                            <asp:HyperLink runat="server" Width="100%" ID="linkMoreMergeProfileStat"  CssClass ="clMenuHeader clGrid accordionHeader"  meta:resourcekey="linkMoreMergeProfileStatResource1">Merge Profile and Delete Profile Request Status &nbsp;&nbsp;&nbsp;&nbsp;</asp:HyperLink>
                                        </div>
                                       
                </td>
            </tr>
        </table>
    </div>
    <br />
    <input id="hidUniID" type="hidden" runat="server" />
    <input id="hid_fk_AcademicYear_ID" type="hidden" runat="server" />
</asp:Content>
