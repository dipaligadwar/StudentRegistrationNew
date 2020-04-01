<%@ Page language="c#" Codebehind="LandingPage.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.LandingPage" %>
<%@ Register TagPrefix="uc1" TagName="InnerHeader" Src="InnerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SideLinks" Src="SideLinks.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
			| Administrator</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/jscript_validations.js"></script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
					<TR>
						<TD colSpan="4"></TD>
					</TR>
					<TR>
						<TD colSpan="4" height="10">
							<uc1:InnerHeader id="InnerHeader1" runat="server"></uc1:InnerHeader></TD>
					</TR>
					<tr height="15">
						<td class="FormName" vAlign="middle" align="center" width="20%"><IMG height="45" src="images/CoomingSoon.gif" width="45"></td>
						<TD class="FormName" align="left" vAlign="middle"><asp:label id="lblTitle" runat="server" Width="99%" Font-Bold="True" CssClass="PageHeading"></asp:label></TD>
					</tr>
					<TR>
						<TD vAlign="top" height="380" class="SideLeft" width="20%">
							<P>
								<asp:Label id="Label1" runat="server">Label</asp:Label></P>
							<INPUT style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4" runat="server" id="hid_Page"
								name="hid_Page"><INPUT style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4" runat="server" id="hid_MenuID"
								name="hid_MenuID">
							<P>&nbsp;</P>
							<P>
								<asp:Table id="Menu" runat="server"></asp:Table></P>
						</TD>
						<td valign="top" align="left">
							<P>&nbsp;</P>
						</td>
					</TR>
					<TR>
						<TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<uc1:Footer id="Footer1" runat="server"></uc1:Footer></TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
