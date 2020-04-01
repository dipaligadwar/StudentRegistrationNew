<%@ Page language="c#" MasterPageFile="~/Content.Master" Codebehind="GR.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.GR" %>

<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >		
	

		<script language="javascript">
        function setCat(val)
        {
	        document.getElementById("<%=ddlGRCategory.ClientID%>").vaue=val;
        }
</script>
		<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<!-- Code Starts Here -->
										<center>
											<table cellSpacing="0" cellPadding="0" width="98%" border="0">
												<tr>
													<td vAlign="top" align="left">
														<P>
															<asp:label id="lblHistory" runat="server" BackColor="White" Width="100%" BorderStyle="Solid"
																BorderWidth="1px" BorderColor="DimGray"></asp:label><br>
															&nbsp;</P>
														<asp:panel id="pnlSearch" runat="server" Width="100%" BorderColor="DimGray" Height="17px" HorizontalAlign="Left">
															<asp:label id="lblCategory" runat="server" Width="88px">G.R. Category</asp:label>
															<asp:DropDownList id="ddlGRCategory" tabIndex="1" runat="server" Width="152px" 
																onChange="setCat(this.value);"></asp:DropDownList>
															<INPUT id="hidCatID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="hidCatID"
																runat="server">
															<asp:label id="lblDate" runat="server" Width="56px">G.R. Date</asp:label>
															<asp:textbox id="txtDate" tabIndex="2" runat="server" BorderWidth="1px" BorderStyle="Solid" Width="72px"
																CssClass="inputbox" MaxLength="10" Font-Size="8pt" Font-Names="Arial"></asp:textbox>
															<asp:label id="lblGrNo" runat="server" Width="56px">G.R. No.</asp:label>
															<asp:textbox id="txtGRNo" tabIndex="3" runat="server" BorderWidth="1px" BorderStyle="Solid" Width="96px"
																CssClass="inputbox" MaxLength="50" Font-Size="8pt" Font-Names="Arial"></asp:textbox>
																<div  class="clButtonHolder">
															<asp:button id="btnSearch" accessKey="S" tabIndex="4" runat="server" Width="64px" Height="18px"
																Text="Search" ToolTip="Search GR(s)"></asp:button>
																</div>
														</asp:panel><br>
														<asp:placeholder id="phdParentGR" runat="server"></asp:placeholder><br>
														<asp:label id="lblGridHeader" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#666666"
															 Visible="False">GR(s) List</asp:label><asp:datagrid id="dgGrDetails" runat="server" BackColor="White" Width="100%" BorderStyle="None"
															BorderWidth="1px" BorderColor="DarkKhaki" Height="56px" ForeColor="Black" AutoGenerateColumns="False" CellPadding="2" AllowPaging="True">
															<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
															<AlternatingItemStyle BorderWidth="1px" CssClass="gridAltItemHome" VerticalAlign="Top"></AlternatingItemStyle>
															<ItemStyle BorderWidth="1px" BorderStyle="Solid" BorderColor="DarkGray" CssClass="gridItemHome"
																VerticalAlign="Top"></ItemStyle>
															<HeaderStyle  HorizontalAlign="Center" BorderWidth="1px" ForeColor="Black" BorderStyle="Solid"
																CssClass="GridItemhome" VerticalAlign="Top"></HeaderStyle>
															<Columns>
																<asp:BoundColumn DataField="GR_No" HeaderText="GR No.">
																	<HeaderStyle  HorizontalAlign="Center" Width="20%" VerticalAlign="Middle" CssClass="gridHeader"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="NewGR_Date" HeaderText="Date">
																	<HeaderStyle  HorizontalAlign="Center" Width="20%" VerticalAlign="Middle" CssClass="gridHeader"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Desc_Summary" HeaderText="Summary">
																	<HeaderStyle  HorizontalAlign="Center" Width="52%" VerticalAlign="Middle" CssClass="gridHeader"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Eng_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeader"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Eng_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeader"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Marathi_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeader"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Marathi_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeader"></HeaderStyle>
																</asp:BoundColumn>
															</Columns>
															<PagerStyle VerticalAlign="Middle" HorizontalAlign="Right" ForeColor="DarkSlateBlue" Position="TopAndBottom"
																Mode="NumericPages"></PagerStyle>
														</asp:datagrid><asp:datagrid id="dgGrSearch" runat="server" BackColor="White" Width="100%" BorderStyle="None"
															BorderWidth="1px" BorderColor="DarkKhaki" Height="198px" ForeColor="Black" AutoGenerateColumns="False" CellPadding="2"
															AllowPaging="True">
															<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
															<AlternatingItemStyle BorderWidth="1px" CssClass="gridAltItemHome" VerticalAlign="Top"></AlternatingItemStyle>
															<ItemStyle BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" CssClass="gridItemHome"
																VerticalAlign="Top"></ItemStyle>
															<HeaderStyle  HorizontalAlign="Center" BorderWidth="1px" ForeColor="Black" BorderStyle="Solid"
																BorderColor="Black" VerticalAlign="Top" BackColor="#DDDDDD"></HeaderStyle>
															<Columns>
																<asp:BoundColumn DataField="GR_No" HeaderText="GR No.">
																	<HeaderStyle  HorizontalAlign="Center" Width="20%" CssClass="gridHeader"
																		VerticalAlign="Middle"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="NewGR_Date" HeaderText="Date">
																	<HeaderStyle  HorizontalAlign="Center" Width="20%" CssClass="gridHeader"
																		VerticalAlign="Middle"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Desc_Summary" HeaderText="Summary">
																	<HeaderStyle  HorizontalAlign="Center" Width="52%" CssClass="gridHeader"
																		VerticalAlign="Middle"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Eng_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeader"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Eng_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeader"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Marathi_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeader"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Marathi_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeader"></HeaderStyle>
																</asp:BoundColumn>
															</Columns>
															<PagerStyle VerticalAlign="Middle" HorizontalAlign="Right" ForeColor="DarkSlateBlue" Position="TopAndBottom"
																Mode="NumericPages"></PagerStyle>
														</asp:datagrid><br>
														<asp:label id="lblData" runat="server"></asp:label></td>
												</tr>
											</table>
										</center>
										<!-- HTML Code End -->
										<P><INPUT id="hidgridFlag" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidgridFlag"
												runat="server"></P>
										<!-- Code End Here --></td>
									<td vAlign="top" align="left" width="1%"><uc1:sublinkusercontrol id="UCSubLink" runat="server"></uc1:sublinkusercontrol><asp:label id="lblAdobe" runat="server"></asp:label></td>
								</tr>
							</table>
			
		<INPUT style="WIDTH: 104px; HEIGHT: 22px" type="hidden" size="12" runat="server" id="hid_Page"	name="hid_Page">
		<INPUT style="WIDTH: 104px; HEIGHT: 22px" type="hidden" size="12" runat="server" id="hid_MenuID" name="hid_MenuID">
							
</asp:Content>