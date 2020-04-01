<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Footer.ascx.cs" Inherits="UniversityPortal.Footer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function OpenVersion()
	{
		window.open('<%=Classes.clsGetSettings.SitePath%>'+'AssemblyVersion.aspx',null,"width=400, height=400,left=300, top=200");
	}
</script>
<%--<div style="MARGIN-TOP:30px;WIDTH:100%">
	<div align="center" style="WIDTH:100%;HEIGHT:16px">
		<!-- <asp:label id="toplinks" runat="server"></asp:label> -->
		<a class='toplinks' href="<%=Classes.clsGetSettings.SitePath%>PhotoGallary.aspx">
			Photo Gallery</a> | <a class='toplinks' href="<%=Classes.clsGetSettings.SitePath%>VisualTour.aspx">
			Visual Tour</a> | <a class='toplinks' href="<%=Classes.clsGetSettings.SitePath%>Suggestions.aspx" >
			Suggestion </a>| <a class='toplinks' href="<%=Classes.clsGetSettings.SitePath%>RequestInfo.aspx">
			Request Info</a> | <a href="<%=Classes.clsGetSettings.SitePath%>RegisterComplaint.aspx" class='toplinks'>
			Complaints</a> | <a href="<%=Classes.clsGetSettings.SitePath%>DisplayFAQ.aspx" class='toplinks'>
			FAQ</a> | <a class='toplinks' href="<%=Classes.clsGetSettings.SitePath%>Disclaimer.aspx">
			Disclaimer</a>
	</div>--%>
	
	<div id="footer">
    <div id="footerLink" align="center">
        <ul>
            <li class="first"><a href='<%=Classes.clsGetSettings.SitePath%>PhotoGallary.aspx'>Photo Gallery</a></li>
            <li><a href='<%=Classes.clsGetSettings.SitePath%>VisualTour.aspx'>Visual Tour</a></li>
            <li><a href='<%=Classes.clsGetSettings.SitePath%>Suggestions.aspx'>Suggestion</a></li>
            <li><a href='<%=Classes.clsGetSettings.SitePath%>RequestInfo.aspx'>Request Info</a></li>
            <li><a href='<%=Classes.clsGetSettings.SitePath%>RegisterComplaint.aspx'>Complaints</a></li>
            <li><a href='<%=Classes.clsGetSettings.SitePath%>DisplayFAQ.aspx'>FAQ</a></li>
            <li><a href='<%=Classes.clsGetSettings.SitePath%>Disclaimer.aspx'>Disclaimer</a></li>
        </ul>
    </div>
    
	<div class="logoAddress" style="WIDTH: 100%; HEIGHT: 16px" align="center">Portal 
		Definition <a class="footerLink" href="javaScript:OpenVersion();">Version</a>
		<asp:label id="lblVersion" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Developed 
		&amp; Powered by Maharashtra Knowledge Corporation Ltd. (<a class="footerLink" href="http://www.mkcl.org" target="_blank">MKCL</a>).</div>

    <div class="logoAddress" style="WIDTH: 100%; HEIGHT: 16px" align="center">The 
	website can be best viewed in 1024 * 768 resolution and required version of 
	internet explorer is IE 6.0 and above</div>
</div>
