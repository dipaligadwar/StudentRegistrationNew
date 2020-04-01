<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Header.ascx.cs" Inherits="UniversityPortal.Header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<script>
	function getLinks(link)
	{
		window.location.href=link;
	}
</script>

<table border="0" cellpadding="2" style="border-collapse: collapse" width="900" bordercolor="#c0c0c0" id="table1">
    <tr>
        <td rowspan="2" width="2%">
            <asp:Image runat="server" border="0" ImageUrl="Images/Logo.jpg" ID="Image1" Height="60" Width="60" /></td>
        <td align="left" width="45%" valign="bottom">
            <asp:Label ID="lblName" CssClass="logoName" runat="server"></asp:Label>&nbsp;</td>
        <td align="right" valign="top">
            <asp:HyperLink runat="server" CssClass="toplinks" NavigateUrl="Default.aspx" ID="Hyperlink8">Home</asp:HyperLink>&nbsp;|
            <asp:Label ID="pnlLogin" runat="server" align="right" CssClass="toplinks">
                <asp:HyperLink runat="server" NavigateUrl="Home.aspx" ID="hlkHome" CssClass="toplinks">My Login</asp:HyperLink>
                &nbsp;|
                <asp:HyperLink runat="server" NavigateUrl="MySettings.aspx" ID="hlkMySettings" CssClass="toplinks">My Settings</asp:HyperLink>
                &nbsp;|
                <asp:HyperLink runat="server" NavigateUrl="Logout.aspx" ID="hlkLogout" CssClass="toplinks">Logout</asp:HyperLink>&nbsp;| </asp:Label>
            <asp:HyperLink runat="server" CssClass="toplinks" NavigateUrl="CalendarDisplay.aspx" ID="HyperLink3">Calendar</asp:HyperLink>&nbsp;|
            <asp:HyperLink runat="server" CssClass="toplinks" NavigateUrl="SiteMap.aspx" ID="HyperLink4">Sitemap</asp:HyperLink>&nbsp;|
            <asp:HyperLink ID="HyperLink5" runat="server" CssClass="toplinks" NavigateUrl="ContactUs.aspx">Contact Us</asp:HyperLink>&nbsp;
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <asp:Label ID="lblAddress" CssClass="logoAddress" runat="server"></asp:Label>&nbsp;</td>
        <td valign="middle" align="right">
            <select id="QuickLinks" class="select" onchange="getLinks(this.value);">
                <option selected>--Quick Link--</option>
                <option value='<%=Classes.clsGetSettings.SitePath%>Content.aspx?ID=4'>Admissions</option>
                <option value='<%=Classes.clsGetSettings.SitePath%>Coming_Soon.aspx'>Search PRN</option>
                <option value='<%=Classes.clsGetSettings.SitePath%>Content.aspx?ID=1'>Courses</option>
                <option value='<%=Classes.clsGetSettings.SitePath%>GR.aspx'>GR</option>
                <option value='<%=Classes.clsGetSettings.SitePath%>Coming_Soon.aspx'>Job Opening</option>
            </select>
        </td>
    </tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" width="900" bordercolor="#c0c0c0" id="table14">
    <tr>
        <td colspan="3" align="left" height="35" background='<%=Classes.clsGetSettings.SitePath%>Images/linkbg.gif' valign='bottom'>
            <asp:Label ID="lblTopLinks" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr height="5">
        <td background='<%=Classes.clsGetSettings.SitePath%>Images/middlespacer.gif'>
            <img src='<%=Classes.clsGetSettings.SitePath%>Images/left-corner.gif'></td>
        <td background='<%=Classes.clsGetSettings.SitePath%>Images/middlespacer.gif' width="99%">
        </td>
        <td background='<%=Classes.clsGetSettings.SitePath%>Images/middlespacer.gif' align="right" valign="bottom">
            <img src='<%=Classes.clsGetSettings.SitePath%>Images/right-corner.gif'></td>
    </tr>
</table>
