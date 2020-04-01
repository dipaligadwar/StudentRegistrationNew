<%@ Control Language="c#" AutoEventWireup="True" Codebehind="ucChannel.ascx.cs" Inherits="SOADelivery.ucChannel" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<div style="MARGIN-TOP: 2px; MARGIN-BOTTOM: 5px">
<asp:Repeater id="rptChannel" runat="server">
	<HeaderTemplate>
		<span class="boxTitle" style="MARGIN-TOP: 5px"><b>Channels</b></span>
		
	</HeaderTemplate>
	<ItemTemplate>
				<div style='width:100%;padding-left:5px;' class='boxBG'>
				<img src='Images/bullet03.gif' border="0" align="absmiddle"> <a id="hlChannelID" 
						href='GoldServices.aspx?ChannelID=
						<%# DataBinder.Eval(Container,"DataItem.Service_Channel_ID") %>
						'>
					<%# DataBinder.Eval(Container,"DataItem.Service_Channel_Desc") %>
				</a>
				</div>
	</ItemTemplate>
	<FooterTemplate>
		
	</FooterTemplate>
</asp:Repeater>
</div>