<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MessagingInbox.ascx.cs" Inherits="UniversityPortal.MessagingInbox" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellSpacing="0" cellPadding="0" width="265px"  >
	<tr>
		<td width="100%"  id="tdTitle" runat="server" class="clBlueBoxTitle">
			
					<%--<td class="clBlueBoxTitle" id="tdTitle" runat="server">&nbsp;--%><STRONG>
					&nbsp;:: Messaging </STRONG>
					<asp:label id="lblMails" runat="server" Font-Bold="True"></asp:label>
				
		</td>
	</tr>
	<tr height="80">
		<td vAlign="top" align="center" style="padding:5px">
			<table cellpadding="0" cellspacing="0" width="100%" border="0" >
				<tr id="TR1" runat="server">
					<td align="center" valign="top" style="PADDING-TOP: 5px"><img src='<%=Classes.clsGetSettings.SitePath%>Images/bullet1.gif'></td>
					<td  style="COLOR: #dedfd4" align="left" valign="top" width="95%"></td>
				</tr>
				<tr id="TR2" runat="server">
					<td align="center" valign="top" style="PADDING-TOP: 5px"><img src='<%=Classes.clsGetSettings.SitePath%>Images/bullet1.gif'></td>
					<td style="COLOR: #dedfd4" align="left" valign="top"  width="95%"></td>
				</tr>
				<tr id="TR3" runat="server">
					<td align="center" valign="top" style="PADDING-TOP: 5px"><img src='<%=Classes.clsGetSettings.SitePath%>Images/bullet1.gif'></td>
					<td style="COLOR: #dedfd4" align="left" valign="top"></td>
				</tr>
				<tr id="TRMore" runat="server">
					<td style="COLOR: #dedfd4" align="right" valign="top" colspan="2">
						<a href='<%=Classes.clsGetSettings.SitePath+Classes.clsGetSettings.MessagingFolder%>/inboxMail.aspx'>
							more... </a>
					</td>
				</tr>
			</table>
			<asp:label id="lblNoMessage" runat="server" Font-Bold="True"></asp:label>
	</td>
	</tr>
</table>
