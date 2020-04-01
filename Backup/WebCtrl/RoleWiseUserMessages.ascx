<%@ Control Language="c#" AutoEventWireup="false" Codebehind="RoleWiseUserMessages.ascx.cs" Inherits="UniversityPortal.WebCtrl.RoleWiseUserMessages" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table width="100%" border="0">
	<tr>
		<td>
			<asp:DataGrid id="DTGrid" runat="server" AutoGenerateColumns="False" BorderColor="#ADADC9" BorderStyle="Solid"
				Width="100%">
				<HeaderStyle BackColor="#E6E6EE"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="Role Name" DataTextField="Role_Name" HeaderText="Role Name" CommandName="lnkBtnEdit">
						<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
					</asp:ButtonColumn>
					<asp:BoundColumn DataField="TotalMessageCount" HeaderText="Total Message(s)">
						<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="UnReadMessageCount" HeaderText="Unread Message(s)">
						<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ReadMessageCount" HeaderText="Read Message(s)">
						<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Role_Id" HeaderText="Role_Id"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
		</td>
	</tr>
</table>
