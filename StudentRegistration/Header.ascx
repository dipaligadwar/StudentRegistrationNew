<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Header.ascx.cs" Inherits="UniversityPortal.Header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script>
	function getLinks(link)
	{
		window.location.href=link;
	}
</script>
<div style="WIDTH:900px">
	<div style="FLOAT:left;WIDTH:100%">
		<div style="FLOAT:left"><asp:image runat="server" imageurl="Images/Logo.jpg" id="Image1" height="60" width="60" /></div>
		<div style="FLOAT:left">
			<div style="FLOAT:left;HEIGHT:30px">
				<div style="FLOAT:left;WIDTH:45%;HEIGHT:30px" align="left">
					<asp:label id="lblName" cssclass="logoName" runat="server"></asp:label></div>
				<div style="FLOAT:left;WIDTH:49%;HEIGHT:30px" align="right" nowrap="noWrap">
					<asp:hyperlink runat="server" cssclass="toplinks" navigateurl="Default.aspx" id="Hyperlink8">Home</asp:hyperlink>&nbsp;|
					<asp:label id="pnlLogin" runat="server" align="right" cssclass="toplinks">
					<asp:hyperlink runat="server" navigateurl="Home.aspx" id="hlkHome" cssclass="toplinks">My Login</asp:hyperlink>
						&nbsp;|
					<asp:hyperlink runat="server" navigateurl="MySettings.aspx" id="hlkMySettings" cssclass="toplinks">My Settings</asp:hyperlink>
						&nbsp;|
					<asp:hyperlink runat="server" navigateurl="Logout.aspx" id="hlkLogout" cssclass="toplinks">Logout</asp:hyperlink>&nbsp;|
					</asp:label>
					<asp:hyperlink runat="server" cssclass="toplinks" navigateurl="CalendarDisplay.aspx" id="HyperLink3">Calendar</asp:hyperlink>&nbsp;|
					<asp:hyperlink runat="server" cssclass="toplinks" navigateurl="SiteMap.aspx" id="HyperLink4">Sitemap</asp:hyperlink>&nbsp;|
					<asp:hyperlink id="HyperLink5" runat="server" cssclass="toplinks" navigateurl="ContactUs.aspx">Contact Us</asp:hyperlink>&nbsp;
				</div>
			</div>
			<div style="FLOAT:left;HEIGHT:29px">
				<div style="FLOAT:left;WIDTH:40%;HEIGHT:29px" align="left"><asp:label id="lblAddress" cssclass="logoAddress" runat="server"></asp:label>&nbsp;</div>
				<div style="FLOAT:left;WIDTH:59%;HEIGHT:29px" align="right">
					<select id="QuickLinks" class="select" onchange="getLinks(this.value);">
						<option selected>--Quick Link--</option>
						<option value='<%=UniversityPortal.clsGetSettings.SitePath%>Content.aspx?ID=4'>Admissions</option>
						<option value='<%=UniversityPortal.clsGetSettings.SitePath%>ComingSoonPreLogin.aspx'>Search 
							PRN</option>
						<option value='<%=UniversityPortal.clsGetSettings.SitePath%>Content.aspx?ID=1'>Courses</option>
						<option value='<%=UniversityPortal.clsGetSettings.SitePath%>GR.aspx'>GR</option>
						<option value='<%=UniversityPortal.clsGetSettings.SitePath%>ComingSoonPreLogin.aspx'>Job 
							Opening</option>
					</select>
				</div>
			</div>
		</div>
	</div>
	<!--

	
	-->	
	<div style="BORDER-COLLAPSE: collapse;width:900;">
		<div>
			<div style="padding-top:20px;text-valign:bottom;text-align:left;width:900;height:20px;background-image:url('<%=UniversityPortal.clsGetSettings.SitePath%>Images/linkbg.gif')">				
				<asp:label id="lblTopLinks"  runat="server"></asp:label>
			</div>
		</div>
		<div>
			<div style="height:5px;float:left;background-image:url('<%=UniversityPortal.clsGetSettings.SitePath%>Images/middlespacer.gif');">
				<img src='<%=UniversityPortal.clsGetSettings.SitePath%>Images/left-corner.gif' align=absbottom>
			</div>
			<div style="height:5px;float:left;width:890;background-image:url('<%=UniversityPortal.clsGetSettings.SitePath%>Images/middlespacer.gif');">
			</div>
			<div style="height:5px;float:left;background-image:url('<%=UniversityPortal.clsGetSettings.SitePath%>Images/middlespacer.gif');">
				<img src='<%=UniversityPortal.clsGetSettings.SitePath%>Images/right-corner.gif' align=absbottom>
			</div>
		</div>
	</div>

	
	
</div>

