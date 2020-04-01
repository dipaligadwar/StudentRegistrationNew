<%@ Control Language="c#" AutoEventWireup="True" Codebehind="ucGoldPlusServices.ascx.cs" Inherits="SOADelivery.ucGoldPlusServices" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<div style="WIDTH: 100%;PADDING-TOP: 5px">
	<asp:DataGrid id="DGGoldPlus" runat="server" AutoGenerateColumns="False" GridLines="None" Width="100%">
		<ItemStyle CssClass="boxBG"></ItemStyle>
		<HeaderStyle CssClass="boxTitle"></HeaderStyle>
		<Columns>
			<asp:BoundColumn Visible="False" DataField="Service_ID" HeaderText="Service_ID"></asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="Service_Detail_ID" HeaderText="Service_Detail_ID"></asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="Service_Flag" HeaderText="Service_Flag"></asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="Target_URL" HeaderText="Target_URL"></asp:BoundColumn>
			<asp:BoundColumn DataField="URL_Title" HeaderText="&amp;nbsp;Gold-Plus Services">
				<HeaderStyle Font-Bold="True" Width="100%"></HeaderStyle>
			</asp:BoundColumn>
		</Columns>
	</asp:DataGrid>
</div>
