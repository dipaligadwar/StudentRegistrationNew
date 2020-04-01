<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MercyAllow.aspx.cs" MasterPageFile="~/Home.Master"
    Inherits="StudentRegistration.Eligibility.MercyAllow" MaintainScrollPositionOnPostback="true" %>
  <%--  <%@ Register TagPrefix="uc1" TagName="StudentProfileSearch" Src="WebCtrl/StudentProfileSearch.ascx" %>--%>

    <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    

<center>
            <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
                width="700" border="0">

                <tr >
                    <%--<td class="FormName" align="left" valign="middle">
                        <asp:Label ID="lblTitle" runat="server" CssClass="PageHeading" Font-Bold="True"
                            Width="700" ForeColor="Tomato">&nbsp;&nbsp;&nbsp;Search Student - Update Contact Details</asp:Label>
                    </td>--%>
                    
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" Text="Search Student - Mercy Chance"></asp:Label>
                    
                </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        
                        <div align="center">
                            <asp:Label ID="lblData" runat="server" ForeColor="Tomato" Font-Bold="True" Width="99%"
                                Visible="False">No Record's Found</asp:Label></div>
                       
                        <div id="divAdvSearch" runat="server">
                                 
                            <table border="0" cellpadding="3" cellspacing="0" width="100%">
                                <tr>
                                    <td align="right" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="lblEnterPRN" runat="server" 
                                            meta:resourcekey="lblEnterPRNResource1" Text="Enter PRN"></asp:Label>
                                        </b>
                                    </td>
                                    <td align="center" height="30">
                                        :</td>
                                    <td align="left" height="30">
                                        <asp:TextBox ID="txtPRN" runat="server" meta:resourcekey="txtPRNResource1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:Button ID="btnSimpleSearch" runat="server" CssClass="butSubmit" 
                                            meta:resourcekey="btnSimpleSearchResource1" OnClick="btnSimpleSearch_Click" 
                                            Text="Search" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:Label ID="lblMsg" runat="server" CssClass="errorNote" 
                                            meta:resourcekey="lblMsgResource1" Style="display: none"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>

            </table>
            <input id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server">
            <input id="hidSearchType" type="hidden" name="hidSearchType" runat="server">
            <input id="hidPRN" type="hidden" name="hidPRN" runat="server">
            <input id="hidInstID" runat="server" name="hidInstID" type="hidden" />
            
            <input id="hidUniID" style="width: 40px; height: 22px" type="hidden" name="hidUniID"
                runat="server">
            <input id="hidStateID" style="width: 24px; height: 22px" type="hidden" size="1" name="hidStateID"
                runat="server">
            <input id="hidDistrictID" style="width: 24px; height: 22px" type="hidden" size="1"
                name="hidDistrictID" runat="server">
            <input id="hidTehsilID" style="width: 24px; height: 22px" type="hidden" size="1"
                name="hidTehsilID" runat="server">
            <input id="hidFacID" style="width: 40px; height: 22px" type="hidden" value="0" name="hidFacID"
                runat="server">
            <input id="hidCrID" style="width: 40px; height: 22px" type="hidden" value="0" name="hidCrID"
                runat="server">
            <input id="hidMoLrnID" style="width: 40px; height: 22px" type="hidden" value="0"
                name="hidMoLrnID" runat="server">
            <input id="hidPtrnID" style="width: 40px; height: 22px" type="hidden" value="0" name="hidPtrnID"
                runat="server">
            <input id="hidBrnID" style="width: 40px; height: 22px" type="hidden" value="0" name="hidBrnID"
                runat="server">
            <input id="hidLevelFlag" style="width: 40px; height: 22px" type="hidden" value="5"
                name="hidLevelFlag" runat="server" />
            <input id="hidDOB" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
                runat="server">
            <input id="hidLastName" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
                runat="server">
            <input id="hidFirstName" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
                runat="server">
            <input id="hidGender" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
                runat="server">
        </center>
    
    </asp:Content>