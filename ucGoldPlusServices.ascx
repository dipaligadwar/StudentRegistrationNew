<%@ Control Language="c#" AutoEventWireup="True" Codebehind="ucGoldPlusServices.ascx.cs" Inherits="SOADelivery.ucGoldPlusServices" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<div style="WIDTH: 100%;PADDING-TOP: 5px">
<div class='clLeftMenu' >
<div class="clMenuHeader" align="left">
     <asp:label id="LBLGroupname" runat="server" width="100%">Gold Plus Services</asp:label>
 </div>
	<asp:DataGrid id="DGGoldPlus" runat="server" AutoGenerateColumns="False" GridLines="None" Width="99%">	
		<Columns>
			<asp:BoundColumn Visible="False" DataField="Service_ID" HeaderText="Service_ID"></asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="Service_Detail_ID" HeaderText="Service_Detail_ID"></asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="Service_Flag" HeaderText="Service_Flag"></asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="Target_URL" HeaderText="Target_URL"></asp:BoundColumn>
			<asp:BoundColumn DataField="URL_Title"><HeaderStyle CssClass=clOff />			
			</asp:BoundColumn>
		</Columns>
	</asp:DataGrid>
	</div>
</div>
