<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Header.ascx.cs" Inherits="UniversityPortal.Header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script>
	function getLinks(link)
	{
		
		window.location.href=link;
	}
</script>
<table border="0" cellpadding="2" style="BORDER-COLLAPSE: collapse" width="900" bordercolor="#c0c0c0"
	id="table1">
	<tr>
		<td rowspan="2" width="2%">
			<asp:image Runat="server" border="0" ImageUrl="Images/Logo.jpg" id="Image1" Height="60" Width="60" /></td>
		<td align="left" width="45%" valign="bottom">
			<asp:Label id="lblName" CssClass="logoName" runat="server"></asp:Label>&nbsp;</td>
		<td align="right" vAlign="top">
			<font size="1" face="Verdana">
				<asp:HyperLink Runat="server" CssClass="toplinks" NavigateUrl="Default.aspx" id="Hyperlink8">Home</asp:HyperLink>&nbsp;|
				<asp:Label id="pnlLogin" runat="server" align="right"> 
						<asp:HyperLink id="hlkHome" CssClass="toplinks" runat="server" NavigateUrl="Home.aspx">My Login</asp:HyperLink>&nbsp;|
						<asp:HyperLink id="hlkMySettings" CssClass="toplinks" runat="server" NavigateUrl="MySettings.aspx">My Settings</asp:HyperLink>&nbsp;|
						<asp:HyperLink id="hlkLogout" CssClass="toplinks" runat="server" NavigateUrl="Logout.aspx">Logout</asp:HyperLink>&nbsp;|
					</asp:Label>
				<asp:HyperLink Runat="server" CssClass="toplinks" NavigateUrl="CalendarDisplay.aspx" id="HyperLink3">Calendar</asp:HyperLink>&nbsp;|
				<asp:HyperLink Runat="server" CssClass="toplinks" NavigateUrl="SiteMap.aspx" id="HyperLink4">Sitemap</asp:HyperLink>&nbsp;|
				<asp:HyperLink id="HyperLink5" Runat="server" CssClass="toplinks" NavigateUrl="ContactUs.aspx">Contact Us</asp:HyperLink>&nbsp;
			</font>
		</td>
	</tr>
	<tr>
		<td align="left" valign="top">
			<asp:Label id="lblAddress" CssClass="logoAddress" runat="server"></asp:Label>&nbsp;</td>
		<td valign="middle" align="right">
			<select id="QuickLinks" class="select" onchange="getLinks(this.value);">
				<option Selected>--Quick Link--</option>
				<option value='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Content.aspx?ID=4'>Admissions</option>
				<option value='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Coming_Soon.aspx'>Search 
					PRN</option>
				<option value='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Content.aspx?ID=1'>Courses</option>
				<option value='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>GR.aspx'>GR</option>
				<option value='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Coming_Soon.aspx'>Job 
					Opening</option>
			</select>
		</td>
	</tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" width="900"
	bordercolor="#c0c0c0" id="table14">
	<tr>
		<td colspan="3" align="left" height="35" background='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Images/linkbg.gif' valign='bottom'>
			<asp:Label id="lblTopLinks" runat="server"></asp:Label>
		</td>
	</tr>
	<tr height="5">
		<td background='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Images/middlespacer.gif'  ><img src='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Images/left-corner.gif'></td>
		<td background='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Images/middlespacer.gif' width="99%"  ></td>
		<td  background='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Images/middlespacer.gif' align="right" valign="bottom"><img src='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Images/right-corner.gif'></td>
	</tr>
</table>
