<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MessagingInbox.ascx.cs" Inherits="UniversityPortal.MessagingInbox" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
<table cellSpacing="0" cellPadding="0" width="265">
	<tr>
		<td vAlign="middle"><IMG src="Images/box03_topstrip.gif" width="265" border="0"></td>
	</tr>
	<tr>
		<td width="100%" bgColor="#dedfd4">
			<table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td class="NewsTD" bgColor="#dedfd4" id="tdTitle" runat="server">&nbsp;<STRONG>:: 
							Messaging</STRONG></td>
					<td align="right" valign="top"><asp:label id="lblMails" runat="server" Font-Bold="True"></asp:label></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr height="80">
		<td vAlign="top" align="center" bgColor="#eeefe9">
			<table cellpadding="0" cellspacing="5" width="100%" border="0">
				<tr id="TR1" runat="server">
					<td align="right" valign="top" style="PADDING-TOP: 5px"><img src='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Images/bullet1.gif'></td>
					<td width="95%" style="COLOR: #dedfd4" align="left" valign="top"></td>
				</tr>
				<tr id="TR2" runat="server">
					<td align="right" valign="top" style="PADDING-TOP: 5px"><img src='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Images/bullet1.gif'></td>
					<td width="95%" style="COLOR: #dedfd4" align="left" valign="top"></td>
				</tr>
				<tr id="TR3" runat="server">
					<td align="right" valign="top" style="PADDING-TOP: 5px"><img src='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]%>Images/bullet1.gif'></td>
					<td width="95%" style="COLOR: #dedfd4" align="left" valign="top"></td>
				</tr>
				<tr id="TRMore" runat="server">
					<td style="COLOR: #dedfd4" align="right" valign="top" colspan="2">
						<a href='<%=System.Configuration.ConfigurationSettings.AppSettings["SitePath"]+System.Configuration.ConfigurationSettings.AppSettings["MessagingFolder"]%>/inboxMail.aspx'>
							more... </a>
					</td>
				</tr>
			</table>
			<asp:label id="lblNoMessage" runat="server" Font-Bold="True"></asp:label>
		</td>
	</tr>
</table>
