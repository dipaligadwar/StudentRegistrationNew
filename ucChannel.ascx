<%@ Control Language="c#" AutoEventWireup="True" Codebehind="ucChannel.ascx.cs" Inherits="SOADelivery.ucChannel" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<div style="WIDTH: 100%;padding:5px 0px 0px 0px">
<div class='clLeftMenu' >
	<div class="clMenuHeader" align="left">
     <asp:label id="LBLGroupname" runat="server" width="100%" >Channels</asp:label>
 </div>
 <div style="text-align:left">
<asp:Repeater id="rptChannel" runat="server">	
	<ItemTemplate >
				<div style="width:100%;text-align:left"  >
				<img src='Images/light-H.gif' align='absmiddle' >
				 <a id="hlChannelID"  
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
</div>
</div>