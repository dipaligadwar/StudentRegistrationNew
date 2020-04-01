<%@ Control Language="c#" AutoEventWireup="false" Codebehind="InnerHeader.ascx.cs" Inherits="UniversityPortal.InnerHeader" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="topMenuBar" Src="WebCtrl/topMenuBar.ascx" %>
<table border="0" cellpadding="2" style="BORDER-COLLAPSE: collapse" width="900" bordercolor="#c0c0c0"
	id="table1">
	<tr>
		<td rowspan="2" width="2%">
			<asp:Image runat="server" ImageUrl="Images/logo.jpg" id="Image1" Height="60" Width="60" /></td>
		<td align="left" width="45%" valign="bottom">
			<asp:Label id="lblName" CssClass="logoName" runat="server"></asp:Label>&nbsp;</td>
		<td align="right" valign="top">
			<asp:HyperLink Runat="server" CssClass="toplinks" NavigateUrl="Default.aspx" id="Hyperlink8">Home</asp:HyperLink>&nbsp;| 
			<asp:Label id="pnlLogin" runat="server" align="right" CssClass="toplinks">
			<asp:HyperLink id="hlkHome" CssClass="toplinks" runat="server" NavigateUrl="Home.aspx">My Login</asp:HyperLink>&nbsp;|
			<asp:HyperLink id="hlkMySettings" CssClass="toplinks" runat="server" NavigateUrl="MySettings.aspx">My Settings</asp:HyperLink>&nbsp;|
			<asp:HyperLink id="hlkLogout" CssClass="toplinks" runat="server" NavigateUrl="Logout.aspx">Logout</asp:HyperLink>&nbsp;| 
			</asp:Label>
			<asp:HyperLink Runat="server" CssClass="toplinks" NavigateUrl="CalendarDisplay.aspx" id="HyperLink3">Calendar</asp:HyperLink>&nbsp;|
			<asp:HyperLink Runat="server" CssClass="toplinks" NavigateUrl="SiteMap.aspx" id="HyperLink4">Sitemap</asp:HyperLink>&nbsp;|
			<asp:HyperLink id="HyperLink5" Runat="server" CssClass="toplinks" NavigateUrl="ContactUs.aspx">Contact Us</asp:HyperLink>&nbsp;
		</td>
	</tr>
	<tr>
		<td align="left" valign="top">
			<asp:Label id="lblAddress" CssClass="logoAddress" runat="server"></asp:Label>&nbsp;</td>
	</tr>
	<tr>
		<td colspan="5" align="left" width="100%" height="35">
			<uc1:topMenuBar id="TopMenuBar1" runat="server"></uc1:topMenuBar>
		</td>
	</tr>
</table>
