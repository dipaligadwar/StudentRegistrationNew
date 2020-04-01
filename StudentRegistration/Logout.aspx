<%@ Register TagPrefix="uc1" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Page language="c#" Codebehind="Logout.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.Logout" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
			| ::Logout</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<LINK href="CSS/Uniportal.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body vLink="#0066ff" aLink="#0066ff" link="#0066ff" bgColor="#ffffff" leftMargin="0"
		topMargin="0" MS_POSITIONING="GridLayout" marginheight="0" marginwidth="0">
		<form id="frm" method="post" runat="server">
			<TABLE WIDTH="900" CELLSPACING="0" CELLPADDING="0" BORDER="0" align="center">
				<TR>
					<TD class="pageTitle">
						<uc1:Header id="UCHeader" runat="server"></uc1:Header>
					</TD>
				</TR>
				<TR>
					<TD align="center" height="355">
						<table width="60%" cellpadding="0" cellspacing="0" height="90" style="BORDER-RIGHT: 1px dotted; BORDER-TOP: 1px dotted; BORDER-LEFT: 1px dotted; BORDER-BOTTOM: 1px dotted; BORDER-COLLAPSE: collapse"
							bordercolor="#68689a">
							<tr>
								<td>
									<table width="100%" cellpadding="0" cellspacing="0" class="bgcolorLight" height="100%">
										<tr>
											<td align="center" class="normalFont">
												You Have Logged Out. Please <a href="Default.aspx" class="LogOut">Login</a> Again
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD>
						<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
