<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="MatchingProfile__4.aspx.cs" Inherits="StudentRegistration.Eligibility.MatchingProfile__4" Title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
            <table style="border-collapse: collapse" id="table2" bordercolor="#c0c0c0" cellpadding="2"
                width="100%" border="0">
                <tbody>
                    <tr>
                        <td class="FormName" align="left" width="100%">
                            <asp:Label runat="server" Text="Merge Profile and Delete Profile Request Status" Font-Bold="True" ID="lblPageHead" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                            
                        </td>
                    </tr>
                    <%--<tr>
                        <td valign="top" align="left" style="height:50pt; vertical-align:middle;">
                            <div style="width: 100%; background-color: #FFFACD; border: solid 1px #c0c0c0; vertical-align: top; margin-bottom: 10px;">
                             <table id="AutoGeneratedInfo" runat="server" width="100%" cellpadding="0">
                                <tr>
                                    <td width="5%" >
                                        <asp:Image runat="server" ID="imginfo" ImageUrl="../images/Info.jpg" /></td>
                                    
                                     <td valign="top">
                                        Table show all in-process and pending request/s related to Merge Profile, Delete Profile and  Cancel Term admission.  </td>
                                </tr>
                                                                             
                            </table>
                            </div>
                        </td>
                     </tr> --%>
                    <tr>
                        <td valign="top" align="left">
                             <div style="margin-top: 5px; margin-left: 1px; width: 99%; border: 1px solid #ffffff;">
                                      
                                <asp:GridView ID="GV_MergeProfileStat" runat="server" CssClass="clGrid" PageSize="25"
                                    AutoGenerateColumns="False" AllowPaging="True" Width="100%" rules="all" OnPageIndexChanging="GV_MergeProfileStat_PageIndexChanging" meta:resourcekey="GV_MergeProfileStatResource1">
                                    <Columns>
                                        <asp:BoundField DataField="SRNO" HeaderText="Sr No." SortExpression="SRNO" meta:resourcekey="BoundFieldResource1">
                                            <HeaderStyle Height="20px"></HeaderStyle>
                                            <ItemStyle Width="3%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BasePrn" HeaderText="Retened Profile" SortExpression="BasePrn" meta:resourcekey="BoundFieldResource2">
                                            <HeaderStyle Width="15%"></HeaderStyle>
                                            <ItemStyle Width="5%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MergePrn" HeaderText="Profile To Be Merge/Delete"  SortExpression="MergePrn" meta:resourcekey="BoundFieldResource3">
                                            <HeaderStyle Width="15%"></HeaderStyle>
                                            <ItemStyle Width="5%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RequestType" HeaderText="Request Type" SortExpression="RequestType" meta:resourcekey="BoundFieldResource5">
                                            <HeaderStyle Width="15%"></HeaderStyle>
                                            <ItemStyle Width="5%"></ItemStyle>
                                        </asp:BoundField>
                                         <asp:BoundField DataField="TimeStamp" HeaderText="Request Time" SortExpression="TimeStamp" meta:resourcekey="BoundFieldResource6">
                                            <HeaderStyle Width="15%"></HeaderStyle>
                                            <ItemStyle Width="5%"></ItemStyle>
                                        </asp:BoundField>
                                         <asp:BoundField DataField="Status" HeaderText="Request Status" SortExpression="RequestStatus" meta:resourcekey="BoundFieldResource4">
                                            <HeaderStyle Width="15%"></HeaderStyle>
                                            <ItemStyle Width="5%"></ItemStyle>
                                        </asp:BoundField>
                                        
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Right" VerticalAlign="Bottom"></PagerStyle>
                                    <HeaderStyle CssClass="gridHeader"></HeaderStyle>
                                </asp:GridView>
                                <asp:Label runat="server" CssClass="errorNote" ID="lblNodata" meta:resourcekey="lblNodataResource1" ></asp:Label>
                              </div>
                        </td>
                    </tr>
                                           
                     
                </tbody>
            </table>
</asp:Content>

