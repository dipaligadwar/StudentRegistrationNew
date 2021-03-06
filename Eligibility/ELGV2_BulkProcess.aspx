<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_BulkProcess.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_BulkProcess" %>
    
<%@ Register Src="WebCtrl/searchInstNew.ascx" TagName="searchInstNew" TagPrefix="uc2" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="0">
            <tr>
                <%--<td class="FormName" align="left" valign="middle">
                    <asp:Label ID="lblTitle" runat="server" Width="99%" Font-Bold="True" CssClass="lblPageHead">Bulk Process Eligibility</asp:Label>--%>
                    <td align="left" style="border-bottom: 1px solid #FFD275;">
                     <asp:Label ID="lblPageHead" runat="server" Text="Bulk Process Eligibility"></asp:Label>
                </td>
            </tr>
            <tr style="height:5px;"><td></td></tr>
            <tr>
                <td valign="top" align="center">
                    <p>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0" id="tblUserControl">
                            <tr>
                                <td valign="top" align="center" style="width: 80%">
                                    <uc2:searchInstNew ID="SchInst1" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <p style="azimuth:center">
                            <asp:Label ID="lblGridName" runat="server" CssClass="clSubHeading" Width="95%"
                                Height="18px"></asp:Label></p>
                        <p style="azimuth:center">
                            <asp:DataGrid ID="dgData" runat="server" CssClass="grid" Width="95%" AutoGenerateColumns="False"
                                AllowPaging="True" PageSize="25">
                                <%--<alternatingitemstyle cssclass="gridAltItem"></alternatingitemstyle>--%>
                                <ItemStyle CssClass="gridItem"></ItemStyle>
                                <Columns>
                                    <asp:ButtonColumn Text="&lt;img border='0' src='../images/pencil.gif' width='16' height='16'&gt;"
                                        HeaderText="Select" CommandName="lnkButSelect">
                                        <HeaderStyle Width="5%" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#FF3333" VerticalAlign="Middle">
                                        </ItemStyle>
                                    </asp:ButtonColumn>
                                    <asp:BoundColumn Visible="False" DataField="pk_Inst_ID" HeaderText="pk_Inst_ID">
                                        <HeaderStyle Width="0%" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="InstName" HeaderText="Name">
                                        <HeaderStyle Width="80%" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="InstTy_Name" HeaderText="Type">
                                        <HeaderStyle Width="15%" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundColumn>
                                </Columns>
                                <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" Mode="NumericPages">
                                </PagerStyle>
                            </asp:DataGrid></p>
                        <div align="center">
                            <asp:Label ID="lblData" runat="server" ForeColor="Tomato" Font-Bold="True" Width="99%"
                                Visible="False">No Record Found</asp:Label>&nbsp;</div>
                        <input id="hidInstID" style="width: 24px; height: 22px" type="hidden" name="hidInstID"
                            runat="server" />
                        <input id="hidUniID" style="width: 24px; height: 22px" type="hidden" name="hidUniID"
                            runat="server" />
                    </p>
                     <input id="Hidden1" type="hidden" name="hidInstID" runat="server" />
                        <input id="Hidden2" type="hidden" name="hidUniID"  runat="server" />
                        <input id="hidCountryId" type="hidden" value="0" name="hidcountryId" runat="server" />
                        <input id="hidCntry" type="hidden" value="0" name="Cntry" runat="server" />
                        <input id="hidStateID" type="hidden" value="0" name="hidStateID" runat="server" />
                        <input id="hidDistrictID" type="hidden" value="0" name="hidDistrictID" runat="server" />
                        <input id="hidTehsilID" type="hidden" value="0"  name="hidTehsilID" runat="server" />
                        <input id="hidCollCode" type="hidden" name="hidCollCode" runat="server" />
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
