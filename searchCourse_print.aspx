<%@ Page language="c#" Codebehind="searchCourse_print.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.searchCourse_print" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title><%=Classes.clsGetSettings.Name%>
			| Course Search</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		function btnPrint_onclick() 
		{						
			document.getElementById("tblPrint").style.display="none"; 
			window.print(); 
			document.getElementById("tblPrint").style.display="inline"; 								
		}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<CENTER>
			<table id="tblPrint" width="650" border="0">
<tr>
<td align="right"><font face="Verdana" color="#bf0000" size="1"><A href="javascript:btnPrint_onclick();"><IMG id="imgPrint" title="Print" height="20" src="images/button_print.gif" width="16"
	border="0"></A></font></FONT></FONT>
</td>
</tr>
</table>
				<TABLE id="Table1" width="650">
					<TR>
						<TD vAlign="top" align="center" width="100%"><IMG src="Images/Logo.jpg"></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:Label id="UName" Font-Size="12pt" Runat="server" Width="100%"></asp:Label></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:Label id="UAddress" Font-Size="12pt" Runat="server" Width="100%"></asp:Label></TD>
					</TR>
					<TR>
						<TD align="center"><BR>
							<asp:Label id="lblData" runat="server" Width="100%"></asp:Label><BR>
						</TD>
					</TR>
					<TR>
						<TD align="center"></TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
