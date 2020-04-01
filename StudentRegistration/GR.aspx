<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrgStrControl" Src="OrgStrControl.ascx" %>
<%@ Page language="c#" Codebehind="GR.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.GR" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
			| </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript">
function setCat(val)
{
	document.getElementById("ddlGRCategory").vaue=val;
}

		</script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="frm" method="post" runat="server">
			<CENTER>
				<table id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
					<tr>
						<td colSpan="4"></td>
					</tr>
					<tr>
						<td colSpan="4" height="10"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td colSpan="4" height="5"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px" vAlign="top"><uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol><INPUT style="WIDTH: 104px; HEIGHT: 22px" type="hidden" size="12" runat="server" id="hid_Page"
								name="hid_Page"><INPUT style="WIDTH: 104px; HEIGHT: 22px" type="hidden" size="12" runat="server" id="hid_MenuID"
								name="hid_MenuID"></td>
						<td vAlign="top" width="830">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<!-- Code Starts Here -->
										<center>
											<table cellSpacing="0" cellPadding="0" width="98%" border="0">
												<tr>
													<td vAlign="top" align="left">
														<P align="left">
															<uc1:OrgStrControl id="OrgStrControl1" runat="server"></uc1:OrgStrControl></P>
														<P>
															<asp:label id="lblHistory" runat="server" BackColor="White" Width="100%" BorderStyle="Solid"
																BorderWidth="1px" BorderColor="DimGray"></asp:label><br>
															&nbsp;</P>
														<asp:panel id="pnlSearch" runat="server" Width="100%" BorderColor="DimGray" Height="17px" HorizontalAlign="Left">
															<asp:label id="lblCategory" runat="server" Width="88px">G.R. Category</asp:label>
															<asp:DropDownList id="ddlGRCategory" tabIndex="1" runat="server" Width="152px" CssClass="SelectBoxhome"
																onChange="setCat(this.value);"></asp:DropDownList>
															<INPUT id="hidCatID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="hidCatID"
																runat="server">
															<asp:label id="lblDate" runat="server" Width="56px">G.R. Date</asp:label>
															<asp:textbox id="txtDate" tabIndex="2" runat="server" BorderWidth="1px" BorderStyle="Solid" Width="72px"
																CssClass="inputbox" MaxLength="10" Font-Size="8pt" Font-Names="Arial"></asp:textbox>
															<asp:label id="lblGrNo" runat="server" Width="56px">G.R. No.</asp:label>
															<asp:textbox id="txtGRNo" tabIndex="3" runat="server" BorderWidth="1px" BorderStyle="Solid" Width="96px"
																CssClass="inputbox" MaxLength="50" Font-Size="8pt" Font-Names="Arial"></asp:textbox>
															<asp:button id="btnSearch" accessKey="S" tabIndex="4" runat="server" Width="64px" Height="18px"
																CssClass="ButSp" Text="Search" ToolTip="Search GR(s)"></asp:button>
														</asp:panel><br>
														<asp:placeholder id="phdParentGR" runat="server"></asp:placeholder><br>
														<asp:label id="lblGridHeader" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#666666"
															Font-Bold="True" Visible="False">GR(s) List</asp:label><asp:datagrid id="dgGrDetails" runat="server" BackColor="White" Width="100%" BorderStyle="None"
															BorderWidth="1px" BorderColor="DarkKhaki" Height="56px" ForeColor="Black" AutoGenerateColumns="False" CellPadding="2" AllowPaging="True">
															<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
															<AlternatingItemStyle BorderWidth="1px" CssClass="gridAltItemHome" VerticalAlign="Top"></AlternatingItemStyle>
															<ItemStyle BorderWidth="1px" BorderStyle="Solid" BorderColor="DarkGray" CssClass="gridItemHome"
																VerticalAlign="Top"></ItemStyle>
															<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="1px" ForeColor="Black" BorderStyle="Solid"
																CssClass="GridItemhome" VerticalAlign="Top"></HeaderStyle>
															<Columns>
																<asp:BoundColumn DataField="GR_No" HeaderText="GR No.">
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="20%" VerticalAlign="Middle" CssClass="gridHeaderHome"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="NewGR_Date" HeaderText="Date">
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="20%" VerticalAlign="Middle" CssClass="gridHeaderHome"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Desc_Summary" HeaderText="Summary">
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="52%" VerticalAlign="Middle" CssClass="gridHeaderHome"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Eng_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeaderHome"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Eng_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeaderHome"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Marathi_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeaderHome"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Marathi_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeaderHome"></HeaderStyle>
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
															<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="1px" ForeColor="Black" BorderStyle="Solid"
																BorderColor="Black" VerticalAlign="Top" BackColor="#DDDDDD"></HeaderStyle>
															<Columns>
																<asp:BoundColumn DataField="GR_No" HeaderText="GR No.">
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="20%" CssClass="gridHeaderHome"
																		VerticalAlign="Middle"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="NewGR_Date" HeaderText="Date">
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="20%" CssClass="gridHeaderHome"
																		VerticalAlign="Middle"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Desc_Summary" HeaderText="Summary">
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="52%" CssClass="gridHeaderHome"
																		VerticalAlign="Middle"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Eng_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeaderHome"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Eng_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeaderHome"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Marathi_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeaderHome"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GR_Marathi_File_Name">
																	<HeaderStyle Width="2%" CssClass="gridHeaderHome"></HeaderStyle>
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
						</td>
					</tr>
					<tr>
						<td colSpan="3"></td>
					</tr>
					<tr>
						<td colSpan="3"><uc1:footer id="Footer1" runat="server"></uc1:footer></td>
					</tr>
				</table>
				<asp:repeater id="mnuReapeater" runat="server">
			<HeaderTemplate>
						<script language="javascript"> 
					</HeaderTemplate>					
						<ItemTemplate>
				
					var sWidth=0;
			
					var pos="right";
								if(parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetWidth)))+170 < screen.width)
								{
									sWidth = parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetWidth)));
								}
								else
								{
									pos="left";
									sWidth= parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetWidth)))-335;
								}			
							new ypSlideOutMenu("menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>", pos,sWidth ,parseInt(document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetTop+document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetTop),170,document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>Content')?document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>Content').offsetHeight:0);


						</ItemTemplate>
				<FooterTemplate> 
					ypSlideOutMenu.writeCSS();				
						</script>
				</FooterTemplate>			
		</asp:repeater></CENTER>
		</form>
	</body>
</HTML>
