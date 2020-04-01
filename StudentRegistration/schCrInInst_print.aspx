<%@ Page language="c#" Codebehind="schCrInInst_print.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.schCrInInst_print" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title><%=UniversityPortal.clsGetSettings.Name%>
			| College/Institute wise Course Search</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
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
			<center>
				<table id="tblPrint" width="650" border="0">
					<tr>
						<td align="right"><font face="Verdana" color="#bf0000" size="1"><A href="javascript:btnPrint_onclick();"><IMG id="imgPrint" title="Print" height="20" src="images/button_print.gif" width="16"
										border="0"></A></font></FONT></FONT>
						</td>
					</tr>
				</table>
				<TABLE id="Table1" width="650">
					<TBODY>
						<TR>
							<TD vAlign="top" align="center" width="100%"><IMG src="Images/Logo.jpg"></TD>
						</TR>
						<TR>
							<TD align="center"><asp:Label id="UName" Width="100%" Runat="server" Font-Size="12pt"></asp:Label></TD>
						</TR>
						<TR>
							<TD align="center"><asp:Label id="UAddress" Width="100%" Runat="server" Font-Size="12pt"></asp:Label></TD>
						</TR>
						<TR>
							<TD align="center"><BR>
								<asp:Label id="lblData" runat="server" Width="100%"></asp:Label><BR>
							</TD>
						</TR>
						<TR>
							<TD align="center"></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
