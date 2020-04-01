<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Page language="c#" Codebehind="DisplayHolidays.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.DisplayHolidays" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Classes.clsGetSettings.Name%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<script language="javascript" src="JS/header.js"></script>
		<script language="javascript" src="JS/footer.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="JS/change.js"></script>
	</HEAD>
	<BODY leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
					<tr>
						<td colSpan="4"></td>
					</tr>
					<tr>
						<td colSpan="4" height="10"><uc1:header id="UCHeader" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td colSpan="4" height="5"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px; HEIGHT: 358px" vAlign="top"><uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol></td>
						<td height="380" vAlign="top" width="830">
							<table width="100%" border="0">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<p class="llblContentTitle" align="left"><asp:label id="lblTitle" runat="server" Font-Bold="True" CssClass="llblContentTitle">Holidays</asp:label></p>
										<table cellSpacing="1" cellPadding="2" width="100%" align="center">
											<tr>
												<td align="center" colSpan="4">
													<TABLE width="100%" align="center">
														<TR>
															<TD align="center" width="60%"><asp:label id="lblHolidayYear" runat="server" Font-Bold="True"></asp:label></TD>
														</TR>
														<TR>
															<TD align="center" width="60%"><asp:datagrid id="DG_DisplayHolidays" runat="server" AllowSorting="True" Font-Size="10pt" Font-Names="Verdana"
																	AutoGenerateColumns="False" Width="80%">
																	<AlternatingItemStyle CssClass="gridAltItemHome"></AlternatingItemStyle>
																	<ItemStyle CssClass="gridItemHome"></ItemStyle>
																	<HeaderStyle Font-Size="10pt" HorizontalAlign="Center" CssClass="gridHeaderHome"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn HeaderText="Sr. No">
																			<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="7%" CssClass="gridHeaderHome"></HeaderStyle>
																			<ItemStyle Font-Size="8pt" HorizontalAlign="Center"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Event_Date" HeaderText="Date">
																			<HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="20%" CssClass="gridHeaderHome"></HeaderStyle>
																			<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Event_Title" HeaderText="Event">
																			<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="30%" CssClass="gridHeaderHome"></HeaderStyle>
																			<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																	</Columns>
																</asp:datagrid></TD>
														</TR>
													</TABLE>
												</td>
											</tr>
										</table>
										<P><asp:label id="lblUpdationDate" runat="server"></asp:label></P>
									</td>
									<td vAlign="top" align="left" width="1%"></td>
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
			<INPUT id="hid_Mode" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="hid_Mode"
				runat="server"><INPUT id="hidUniID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="hidUniID"
				runat="server"><INPUT id="hidFacID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="hidFacID"
				runat="server"><INPUT id="hidSubID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="hidSubID"
				runat="server"></form>
	</BODY>
</HTML>
