<%@ Page language="c#" Codebehind="EligibilityIndex.aspx.cs" AutoEventWireup="True" Inherits="StudentRegistration.Eligibility.EligibilityIndex" %>
<%@ Register TagPrefix="uc1"  TagName="topLink" Src="../InnerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainLink" Src="../SideLinks.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="../Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Digital University - Student Registration</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../JS/header.js"></script>
		<script language="javascript" src="../JS/footer.js"></script>
</HEAD>
	<body>
		<form id="mainHome" method="post" runat="server">
			<div align=center>
				<!-- Header Starts--><uc1:toplink id="TopLink1" runat="server"></uc1:toplink><!-- Header Ends-->
				<!-- Heading Starts-->
				<table height="48" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<tr height="3">
						<td vAlign="middle" align="center"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
					<tr height="15">
						<td rowspan="2" vAlign="middle" align="center" width="20%"><IMG height="45" src="../Images/CoomingSoon.gif" width="45"></td>
						<td vAlign="bottom" width="40%" style="HEIGHT: 17px">
										<B><FONT class="PageHeading">
												Welcome...</FONT></B><asp:Label id="lblwelcome" Runat="server" Font-Bold="True" ></asp:Label>
											
						</td>
						<TD vAlign="bottom" width="40%" style="HEIGHT: 17px">
							<asp:label id="Label2" runat="server" Width="100%" CssClass="saveNote"></asp:label></TD>
					</tr>
					<TR height="30">
						<TD vAlign="bottom" width="80%" colspan="2" align="left">&nbsp;</TD>
					</TR>
					<tr>
						<td class="FormName" vAlign="middle" align="center" colSpan="3"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
				</table>
				<!-- Heading Ends-->
				<!-- Main Starts-->
				<table height="410" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<tr>
						<td class="SideLeft" vAlign="top" align="left" width="18%">
							<!--Menu Start Here-->
							<P><uc1:mainlink id="MainLink1" runat="server"></uc1:mainlink></P>
							<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							</P>
							<!--Menu Ends Here--></td>
						<td vAlign="top" align="left" width="2%">&nbsp;</td>
						<td vAlign="top" align="left" width="80%">
							<!-- Toolbar Starts--> <!-- Toolbar Ends--><br>
							<!-- Fields Starts-->
							<asp:Label id="Label1" runat="server" Width="536px" Height="152px">
								<u><b>ELIGIBILITY MODULE INTRODUCTION</b></u><br /><br /><br />								
									<div style="margin-left:40px"><b>Confirm Eligibility - of College admitted students only</b></div><br />
									<div style="margin-left:40px"><b>Resolve Pending Eligibility - of Eligibility Pending students only</b></div>
							</asp:Label> <!-- Fields Ends-->
						</td>
					</tr>
					<TR>
						<TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					</TR>
				</table>
				<!--Main Ends-->
				<!-- Footer Starts--><uc1:footer id="Footer1" runat="server"></uc1:footer><!-- Footer Ends-->
				&nbsp;&nbsp;&nbsp;
			</div>
		</form>
	</body>
</HTML>
