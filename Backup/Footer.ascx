<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Footer.ascx.cs" Inherits="UniversityPortal.Footer"
    TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<script>
	function OpenVersion()
	{
		window.open('<%=System.Configuration.ConfigurationSettings.AppSettings["Sitepath"]%>'+'AssemblyVersion.aspx',null,"width=400, height=400,left=300, top=200");
	}
</script>

<table width="100%">
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lblFooterLink" runat="server"></asp:Label><!--A href="Default.aspx" class="toplinks">Home</A> | <A href="SearchPRN.aspx" class="toplinks">
				Search</A> | <a href="" class="toplinks">Feedback </a>| <a href="" class="toplinks">
				FAQs</a> | <A class="toplinks" href="Disclaimer.aspx">Disclaimer</A> | <a href="RegisterComplaint.aspx" class="toplinks">
				Complaints</a> | <a class="toplinks" href="">Request Info</a> | <a href="Sitemap.aspx" class="toplinks">
				Sitemap</a> | <a href="ContactUs.aspx" class="toplinks">Contact Us</a-->
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            Portal Definition <a href="javaScript:OpenVersion();">Version</a>
            <asp:Label ID="lblVersion" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font
                face="Verdana" size="1">© Copyright 2005&nbsp;&nbsp;<%=System.Configuration.ConfigurationSettings.AppSettings["Name"]%></font></td>
    </tr>
</table>
<input id="hid_Sitepath" type="hidden" name="hid_Sitepath" runat="server">
