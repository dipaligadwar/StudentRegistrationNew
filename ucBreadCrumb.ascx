<%@ Control Language="c#" AutoEventWireup="True" Codebehind="ucBreadCrumb.ascx.cs" Inherits="SOADelivery.ucBreadCrumb" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<div>
	<div class="clBreadCrumb">
		<asp:LinkButton id="butGold" runat="server" Font-Bold="True" onclick="butGold_Click">Gold</asp:LinkButton>
		<asp:LinkButton id="butSilver" runat="server" Font-Bold="True" onclick="butSilver_Click">Silver</asp:LinkButton>
		<INPUT id="hid_Channel" style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4" name="Hidden1"
			runat="server"><INPUT id="hid_Service_Category" style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4"
			name="Hidden1" runat="server"><INPUT id="hid_Service_ID" style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4" name="Hidden1"
			runat="server"><INPUT id="hid_Service_Detail_ID" style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4"
			name="Hidden1" runat="server">
	</div>
</div>
