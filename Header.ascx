<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Header.ascx.cs" Inherits="UniversityPortal.Header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register Src="ColorPallete.ascx" TagName="ColorPallete" TagPrefix="uc1" %>
<script>
	function getLinks(link)
	{
		window.location.href=link;
	}
</script>

<%--<div >
    <div id="logo" >
		    <asp:image runat="server"  id="Image1" />	
		    </div>
    <div id="header" >
        <div id="headerLink">
            <font face="Verdana" size="1">
                <ul>
                 <li class='first'><a href='Default.aspx'>Home</a></li> 
				<asp:label id="pnlLogin" runat="server" align="right" Visible="false">
                        <li><asp:hyperlink runat="server" navigateurl="Home.aspx" id="hlkHome" >My Login</asp:hyperlink></li>			
                        <li><asp:hyperlink runat="server"  id="hlkMySettings" >My Settings</asp:hyperlink></li>			
                        <li>	<asp:hyperlink runat="server" navigateurl="Logout.aspx" id="hlkLogout">Logout</asp:hyperlink></li>
				</asp:label>
				<li><asp:hyperlink runat="server" navigateurl="CalendarDisplay.aspx" id="HyperLink3">Calendar</asp:hyperlink></li>
				<li><asp:hyperlink runat="server"  navigateurl="SiteMap.aspx" id="HyperLink4">Sitemap</asp:hyperlink></li>
				<li><asp:hyperlink id="HyperLink5" runat="server" navigateurl="ContactUs.aspx">Contact Us</asp:hyperlink></li>
			 </ul>
			 </font>
        </div>
        <div>
            <asp:label id="lblName" runat="server" cssclass="logoName"></asp:label>
        </div>
        <div>
            <asp:label id="lblAddress" runat="server" cssclass="logoAddress"></asp:label>
        </div>
        <!-- Begin : color Pallete -->
        <uc1:colorpallete id="ColorPallete1" runat="server">
        </uc1:colorpallete>
        <!-- End : color Pallete -->
</div>
	 <div id='HeaderMenuHolderUni' >
	 	<asp:label id="lblTopLinks"   runat="server" ForeColor="White"></asp:label>
    </div>
    

</div>--%>
         
	<%--<div style="BORDER-COLLAPSE: collapse;width:900;">
		<div>
			<div style="padding-top:20px;text-valign:bottom;text-align:left;width:900;height:20px;background-image:url('<%=Classes.clsGetSettings.SitePath%>Images/linkbg.gif')">				
				<asp:label id="lblTopLinks"  runat="server"></asp:label>
			</div>
		</div>
		<div>
			<div style="height:5px;float:left;background-image:url('<%=Classes.clsGetSettings.SitePath%>Images/middlespacer.gif');">
				<img src='<%=Classes.clsGetSettings.SitePath%>Images/left-corner.gif' align=absbottom>
			</div>
			<div style="height:5px;float:left;width:890;background-image:url('<%=Classes.clsGetSettings.SitePath%>Images/middlespacer.gif');">
			</div>
			<div style="height:5px;float:left;background-image:url('<%=Classes.clsGetSettings.SitePath%>Images/middlespacer.gif');">
				<img src='<%=Classes.clsGetSettings.SitePath%>Images/right-corner.gif' align=absbottom>
			</div>
		</div>
	</div>	--%>
	
<div>
    <div id="logo">
        <asp:image id="Image1" runat="server" imageurl="Images/logo.jpg" />
    </div>
    <div id="header">
        <div id="headerLink">
            <font face="Verdana" size="1">
                <ul>
                    <li class='first'><a href='Default.aspx'>Home</a></li>
                        <asp:label id="pnlLogin" runat="server" align="right" Visible="false">
                        <li><asp:hyperlink runat="server" navigateurl="Home.aspx" id="hlkHome" >My Login</asp:hyperlink></li>			
                        <li><asp:hyperlink runat="server"  id="hlkMySettings" >My Settings</asp:hyperlink></li>			
                        <li>	<asp:hyperlink runat="server" navigateurl="Logout.aspx" id="hlkLogout">Logout</asp:hyperlink></li>
				</asp:label>
                    <li>
   
                    <a href='CalendarDisplay.aspx'>Calendar</a>
                    </li>
                   <li>
                      
                    <a href='SiteMap.aspx'>Sitemap</a>
                    </li>
                    <li class='last'>
                        <a href='ContactUs.aspx'>Contact Us</a>
                    </li>
                </ul>
            </font>
        </div>
        <div>
            <asp:label id="lblName" runat="server" cssclass="logoName"></asp:label>
        </div>
        <div>
            <asp:label id="lblAddress" runat="server" cssclass="logoAddress"></asp:label>
        </div>
        <!-- Begin : color Pallete -->
        <uc1:colorpallete id="ColorPallete1" runat="server">
        </uc1:colorpallete>
        <!-- End : color Pallete -->
    </div>
    <div id='HeaderMenuHolderUni'>
    	<asp:label id="lblTopLinks" runat="server"></asp:label>
    </div>       
</div>
<script>
document.getElementById("<%=Image1.ClientID%>").setAttribute("src","<%=sSitePath%>Images/logo.jpg");
</script>