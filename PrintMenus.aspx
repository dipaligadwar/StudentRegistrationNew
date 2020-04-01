<%@ Page language="c#" Codebehind="PrintMenus.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.PrintMenus" %>
<%@ Register TagPrefix="uc1" TagName="AdminHeader" Src="Admin/AdminHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SideLinks" Src="SideLinks.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PrintMenus</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href=CSS/UniPortal.css type="text/css" rel="stylesheet">
		<script language="javascript">
			function printmenucontent()
			{
				//window.open("printMenuContent.aspx","Print Menus","width=500,height=400",true);
				window.open("printMenuContent.aspx",null,"height=760,resizable=yes,width=1024,scrollbars=yes,status=yes,toolbar=no,menubar=yes,location=no");
			}
		</script>
	</HEAD>
	<body topMargin="0">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="table1" style="Z-INDEX: 101; BORDER-COLLAPSE: collapse" borderColor="#c0c0c0"
					cellPadding="2" width="900" border="0">
					<TR>
						<TD colSpan="3" height="10"><uc1:adminheader id="AdminHeader2" runat="server"></uc1:adminheader></TD>
					</TR>
					<TR height="15">
						<TD class="FormName" vAlign="middle" align="center" width="20%"><IMG height="45" src="images/CoomingSoon.gif" width="45"></TD>
						<TD class="FormName" vAlign="top" align="left" width="80%"><asp:label id="lblHeader" runat="server" Width="70%" Font-Size="8">
								<font class="lblPageHead"><STRONG>Menu Contents</STRONG></font></asp:label></TD>
					</TR>
					<TR height="380">
						<TD class="SideLeft" vAlign="top" width="18%"><uc1:sidelinks id="SideLinks2" runat="server"></uc1:sidelinks></TD>
						<TD vAlign="top" align="center" colSpan="2">
							<P>&nbsp;</P>
							<P>&nbsp;</P>
							<INPUT class="butSubmit" id="btnPrint" onclick="printmenucontent();" type="button" value="Print Menu Content">
						</TD>
					</TR>
					<TR>
						<TD class="FooterTop" colSpan="3"><FONT style="FONT-SIZE: 1pt">&nbsp;</FONT></TD>
					</TR>
					<TR>
						<TD colSpan="3"><uc1:footer id="Footer2" runat="server"></uc1:footer></TD>
					</TR>
					<TR>
						<TD colSpan="3"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
		<CENTER></CENTER>
	</body>
</HTML>
