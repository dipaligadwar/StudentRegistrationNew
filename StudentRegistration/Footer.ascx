<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Footer.ascx.cs" Inherits="UniversityPortal.Footer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function OpenVersion()
	{
		window.open('<%=UniversityPortal.clsGetSettings.SitePath%>'+'AssemblyVersion.aspx',null,"width=400, height=400,left=300, top=200");
	}
</script>
<div style="MARGIN-TOP:30px;WIDTH:100%">
	<div align="center" style="WIDTH:100%;HEIGHT:16px">
		<!-- <asp:label id="toplinks" runat="server"></asp:label> -->
		<a class='toplinks' href="<%=UniversityPortal.clsGetSettings.SitePath%>PhotoGallary.aspx">
			Photo Gallery</a> | <a class='toplinks' href="<%=UniversityPortal.clsGetSettings.SitePath%>VisualTour.aspx">
			Visual Tour</a> | <a class='toplinks' href="<%=UniversityPortal.clsGetSettings.SitePath%>Suggestions.aspx" >
			Suggestion </a>| <a class='toplinks' href="<%=UniversityPortal.clsGetSettings.SitePath%>RequestInfo.aspx">
			Request Info</a> | <a href="<%=UniversityPortal.clsGetSettings.SitePath%>RegisterComplaint.aspx" class='toplinks'>
			Complaints</a> | <a href="<%=UniversityPortal.clsGetSettings.SitePath%>DisplayFAQ.aspx" class='toplinks'>
			FAQ</a> | <a class='toplinks' href="<%=UniversityPortal.clsGetSettings.SitePath%>Disclaimer.aspx">
			Disclaimer</a>
	</div>
	<div class="logoAddress" style="WIDTH: 100%; HEIGHT: 16px" align="center">Portal 
		Definition <a class="footerLink" href="javaScript:OpenVersion();">Version</a>
		<asp:label id="lblVersion" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Developed 
		&amp; Powered by Maharashtra Knowledge Corporation Ltd. (<a class="footerLink" href="http://www.mkcl.org" target="_blank">MKCL</a>).</div>
</div>
<div class="logoAddress" style="WIDTH: 100%; HEIGHT: 16px" align="center">The 
	website can be best viewed in 1024 * 768 resolution and required version of 
	internet explorer is IE 6.0 and above</div>
<div></div>
