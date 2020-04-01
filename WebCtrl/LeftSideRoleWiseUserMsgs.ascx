<%@ Control Language="c#" AutoEventWireup="false" Codebehind="LeftSideRoleWiseUserMsgs.ascx.cs" Inherits="UniversityPortal.WebCtrl.LeftSideRoleWiseUserMsgs" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<!--style>
A:link { FONT-WEIGHT: normal; FONT-SIZE: 8pt; COLOR: #000080; TEXT-DECORATION: none }
A:visited { FONT-WEIGHT: normal; FONT-SIZE: 8pt; COLOR: #000080; TEXT-DECORATION: none }
A:hover { FONT-WEIGHT: normal; FONT-SIZE: 8pt; COLOR: #000080; BORDER-BOTTOM: #ff0000 1px solid; TEXT-DECORATION: none }
</style-->
<table width="100%" border="0" cellpadding="0" cellspacing="0" id="TBMyFolder" runat="server">
	<tr>
		<td bgcolor="#adadc9" height="18"><STRONG><FONT color="#ffffff">&nbsp;My Folder(s)</FONT></STRONG>
		</td>
	</tr>
	<tr>
		<td bgcolor="#e6e6ee">
			<asp:DataGrid id="DTGrid" runat="server" AutoGenerateColumns="False" ShowHeader="False" GridLines="None"
				Width="100%">
				<HeaderStyle CssClass="gridHeader"></HeaderStyle>
				<Columns>
					<asp:BoundColumn>
						<HeaderStyle Width="3%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:ButtonColumn Text="Role Name" DataTextField="Role_Name" HeaderText="Role Name" CommandName="lnkBtnEdit">
						<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
					</asp:ButtonColumn>
					<asp:BoundColumn DataField="TotalMessageCount" HeaderText="Total Message(s)">
						<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="UnReadMessageCount" HeaderText="Unread Message(s)">
						<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Role_ID" SortExpression="Role_ID" HeaderText="Role_ID"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
		</td>
	</tr>
</table>
