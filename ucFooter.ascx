<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Footer.ascx.cs" Inherits="UniversityPortal.Footer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function OpenVersion()
	{
		window.open('<%=Classes.clsGetSettings.SitePath%>'+'AssemblyVersion.aspx',null,"width=400, height=400,left=300, top=200");
	}
</script>
<table width="100%">
	<tr>
		<td align="center" colSpan="2">
			<asp:Label id="lblFooterLink" runat="server"></asp:Label><!--A href="Default.aspx" class="toplinks">Home</A> | <A href="SearchPRN.aspx" class="toplinks">
				Search</A> | <a href="" class="toplinks">Feedback </a>| <a href="" class="toplinks">
				FAQs</a> | <A class="toplinks" href="Disclaimer.aspx">Disclaimer</A> | <a href="RegisterComplaint.aspx" class="toplinks">
				Complaints</a> | <a class="toplinks" href="">Request Info</a> | <a href="Sitemap.aspx" class="toplinks">
				Sitemap</a> | <a href="ContactUs.aspx" class="toplinks">Contact Us</a-->
		</td>
	</tr>
	<TR>
		<TD class="logoAddress" align="center" colSpan="2">Portal Definition <A class="footerLink" href="javaScript:OpenVersion();">
				Version</A>
			<asp:Label id="lblVersion" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Developed 
			&amp; Powered by Maharashtra Knowledge Corporation Ltd. (<A class="footerLink" href="http://www.mkcl.org" target="_blank">MKCL</A>).</TD>
	</TR>
</table>
<INPUT id="hid_Sitepath" type="hidden"  name="hid_Sitepath" runat="server">
