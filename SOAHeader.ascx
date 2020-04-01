<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SOAHeader.ascx.cs" Inherits="SOADelivery.SOAHeader" %>
<%@ Register Src="ColorPallete.ascx" TagName="ColorPallete" TagPrefix="uc1" %>

<script>
	function getLinks(link)
	{
		window.location.href=link;
	}
</script>

<%--<div>
    <div id="logo">
        <asp:Image ID="Image1" runat="server" ImageUrl="Images/logo.jpg" />
    </div>
    <div id="header">
        <div id="headerLink">
            <font face="Verdana" size="1">
                <ul>
                       <li  class='first'  >
                        <asp:HyperLink ID="Hyperlink8" NavigateUrl="~/default.aspx" runat="server">Home</asp:HyperLink>
                    </li>                    
                        <li>
                            <asp:LinkButton runat="server" ID="hlkHome" OnClick="hlkButton_Click" Text="My Login "></asp:LinkButton></li>
                        <li><a href='StudentSettings.aspx'>My Settings</a></li>
                        <li><a href='Logout.aspx'>Logout</a></li>
                   
                    <li><a href='CalendarDisplay.aspx'>Calendar</a></li>
                    <li><a href='SiteMap.aspx'>Sitemap</a> </li>
                    <li class='last'><a href='ContactUs.aspx'>Contact Us</a> </li>
                </ul>
            </font>
        </div>
        <div>
            <asp:Label ID="lblName" runat="server" CssClass="logoName"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblAddress" runat="server" CssClass="logoAddress"></asp:Label>
        </div>
        <!-- Begin : color Pallete -->
        <uc1:ColorPallete ID="ColorPallete1" runat="server"></uc1:ColorPallete>
        <!-- End : color Pallete -->
    </div>
    <div id='HeaderMenuHolder' style="width: 900px">
    </div>
    </div>

<script>
document.getElementById("<%=Image1.ClientID%>").setAttribute("src","<%=sSitePath%>Images/logo.jpg");
</script>
--%>
<div>
    <div id="logo">
        <asp:Image ID="Image1" runat="server" ImageUrl="Images/logo.jpg" />
    </div>
    <div id="header">
        <div id="headerLink">
            <font face="Verdana" size="1">
                <ul>
                    <li class='first'><a href='Default.aspx'>Home</a></li>
                    <li>
                        <asp:LinkButton runat="server" ID="hlkHome" OnClick="hlkButton_Click" Text="My Login "></asp:LinkButton></li>
                    <li><a href='StudentSettings.aspx'>My Settings</a></li>
                    <li><a href='Logout.aspx'>Logout</a></li>
                    <li><a href='CalendarDisplay.aspx'>Calendar</a> </li>
                    <li><a href='SiteMap.aspx'>Sitemap</a> </li>
                    <li class='last'><a href='ContactUs.aspx'>Contact Us</a> </li>
                </ul>
            </font>
        </div>
        <div>
            <asp:Label ID="lblName" runat="server" CssClass="logoName"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblAddress" runat="server" CssClass="logoAddress"></asp:Label>
        </div>
        <!-- Begin : color Pallete -->
        <uc1:ColorPallete ID="ColorPallete1" runat="server"></uc1:ColorPallete>
        <!-- End : color Pallete -->
    </div>
    <div id='HeaderMenuHolder'>
        <asp:Label ID="lblTopLinks" runat="server"></asp:Label>
    </div>
</div>

<script>
document.getElementById("<%=Image1.ClientID%>").setAttribute("src","<%=sSitePath%>Images/logo.jpg");
</script>

