<%@ Page language="c#" Codebehind="levelWiseCourses_print.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.levelWiseCourses_print" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title><%=UniversityPortal.clsGetSettings.Name%>
			| Level Wise Courses</title>
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
					<TR>
						<TD vAlign="top" align="center" width="100%"><IMG src="Images/Logo.jpg"></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:Label id="UName" Width="100%" Runat="server" Font-Size="12pt"></asp:Label></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:Label id="UAddress" Width="100%" Runat="server" Font-Size="12pt"></asp:Label></TD>
					</TR>
					<TR>
						<TD align="center"><BR>
							<asp:Label id="lblNote" runat="server" Font-Bold="True"></asp:Label><BR>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:DataGrid id="dgData" runat="server" AutoGenerateColumns="False" AllowPaging="false" BorderStyle="Solid"
								BorderWidth="1px" BorderColor="DarkGray" Width="99%">
								<HeaderStyle BackColor="#E0E0E0"></HeaderStyle>
								<Columns>
									<asp:BoundColumn HeaderText="Sr.No.">
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CourseName" HeaderText="Course Name">
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PrgTy_Desc" HeaderText="Program Type">
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CrMoLrnPtrn_Duration" HeaderText="Duration (in months)">
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
