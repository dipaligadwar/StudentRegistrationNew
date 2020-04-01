<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_ResolvePending.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_ResolvePending" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<%@ Register Src="WebCtrl/searchInstNew.ascx" TagName="searchInstNew" TagPrefix="uc2" %>


    <script language="javascript" type="text/javascript" src="JS/header.js"></script>

    <script language="javascript" type="text/javascript" src="JS/footer.js"></script>

    <script language="javascript" type="text/javascript" src="JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="JS/change.js"></script>

    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="0">
            <tr>
               <%-- <td class="FormName" align="left" valign="middle">
                    <asp:Label ID="lblTitle" runat="server" Width="99%" Font-Bold="True" CssClass="lblPageHead">Resolve Pending Eligibility</asp:Label>
                </td>--%>
                
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <p style="margin: 0px 5px" align="center">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0" id="tblUserControl">
                            <tr>
                                <td valign="top" align="center" style="width: 80%">
                                    <uc2:searchInstNew ID="SchInst1" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <p style="margin-top: 10px; margin-bottom: 1px; margin-left: 0px" align="center">
                            <asp:Label ID="lblGridName" runat="server" CssClass="GridSubHeading" Width="95%"
                                Height="18px"></asp:Label></p>
                        <p style="margin-top: 0px; margin-bottom: 0px; margin-left: 0px" align="center">
                            <asp:DataGrid ID="dgData" runat="server" CssClass="grid" Width="95%" AutoGenerateColumns="False"
                                AllowPaging="True" PageSize="25" >
                               <%-- <AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>--%>
                                <ItemStyle CssClass="gridItem"></ItemStyle>
                                <Columns>
                                    <asp:ButtonColumn Text="&lt;img border='0' src='../images/pencil.gif' width='16' height='16'&gt;"
                                        HeaderText="Select" CommandName="lnkButSelect">
                                        <HeaderStyle Width="5%" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#FF3333" VerticalAlign="Middle">
                                        </ItemStyle>
                                    </asp:ButtonColumn>
                                    <asp:BoundColumn Visible="False" DataField="pk_Inst_ID" HeaderText="pk_Inst_ID">
                                        <HeaderStyle Width="0%" CssClass="gridHeader"></HeaderStyle>
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
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
