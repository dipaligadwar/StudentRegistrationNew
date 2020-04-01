<%@ Control Language="c#" AutoEventWireup="false" Codebehind="DefaultHeader.ascx.cs" Inherits="UniversityPortal.DefaultHeader" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script>
	function getLinks(link)
	{
		window.location.href=link;
	}
</script>
<table border="0" cellpadding="2" style="BORDER-COLLAPSE: collapse" width="900" bordercolor="#c0c0c0"
	id="table1">
	<tr>
		<td rowspan="2">
			<img border="0" src="Images/logo.gif" height="66"></td>
		<td align="right">
			<font size="1" face="Verdana"><A href="Default.aspx" class="toplinks">Home</A> | <A href="SearchPRN.aspx" class="toplinks">
					Search</A> | <a href="" class="toplinks">Feedback </a>| <a href="" class="toplinks">
					FAQs</a> | <a href="" class="toplinks">Sitemap</a> | <a href="ContactUs.aspx" class="toplinks">
					Contact Us</a><A class="toplinks" href=""> </A>
				<asp:Label id="pnlLogin" runat="server" align="right"> | 
<asp:HyperLink id="hlkHome" CssClass="toplinks" runat="server" NavigateUrl="Home.aspx">Login Home</asp:HyperLink> |
						<asp:HyperLink id="hlkMySettings" CssClass="toplinks" runat="server" NavigateUrl="MySettings.aspx">My Settings</asp:HyperLink> |
						<asp:HyperLink id="hlkLogout" CssClass="toplinks" runat="server" NavigateUrl="Logout.aspx">Logout</asp:HyperLink>
					</asp:Label>
			</font>
		</td>
	</tr>
	<tr>
		<td>
			<p align="right">
				<select id="QuickLinks" class="select" onchange="getLinks(this.value);">
					<option Selected>--Quick Link--</option>
					<option value="Content.aspx?ID=4">Admissions</option>
					<option value="SearchPRN.aspx">Search PRN</option>
					<option value="Content.aspx?ID=1">Courses</option>
					<option value="GR.aspx">GR</option>
					<option value="JobOpening.aspx">Job Opening</option>
				</select>
			</p>
		</td>
	</tr>
	<tr>
		<td colspan="5">
		<table width=100% cellpadding=0 cellspacing=0>
				<tr>
					<td colspan=3 align="left" height="35" background='Images/linkbg.gif'
						valign='bottom'>
						<asp:Label id="lblTopLinks" runat="server"></asp:Label>
					</td>
				</tr>
				<tr height="4">
					<td background='Images/left-corner.gif'></td>
					<td background='Images/middlespacer.gif' width=99%></td>
					<td background='Images/rightcorner.gif'></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
