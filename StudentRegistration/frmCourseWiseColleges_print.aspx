<%@ Page language="c#" Codebehind="frmCourseWiseColleges_print.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.frmCourseWiseColleges_print" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
			| Course Wise Colleges</title>
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
							<TD align="center"><asp:Label id="UName" Font-Size="12pt" Runat="server" Width="100%"></asp:Label></TD>
						</TR>
						<TR>
							<TD align="center"><asp:Label id="UAddress" Font-Size="12pt" Runat="server" Width="100%"></asp:Label></TD>
						</TR>
						<TR>
							<TD align="center"><BR>
								<asp:label id="lblDisplay" runat="server" Font-Bold="True"></asp:label><BR>
							</TD>
						</TR>
						<tr>
							<td align="right"><b>Report Printed On :</b><label id="lblDT" runat="server"></label>
							</td>
						</tr>
						<TR>
							<TD align="center">
								<asp:DataGrid id="dgData" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px"
									BorderColor="DarkGray" Width="99%">
									<HeaderStyle BackColor="#E0E0E0"></HeaderStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="pk_Uni_ID" SortExpression="pk_Uni_ID"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="pk_Inst_ID" SortExpression="pk_Inst_ID"></asp:BoundColumn>
										<asp:BoundColumn HeaderText="Sr. No">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="7%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle Font-Size="8pt" HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Cr_Desc" SortExpression="Cr_Desc" HeaderText="Course">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Left" Width="20%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Inst_Name" SortExpression="Inst_Name" HeaderText="College Name">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Left" Width="20%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ParBdy_Name" SortExpression="ParBdy_Name" HeaderText="Parent Body">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="15%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Address" SortExpression="Address" HeaderText="Address">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="15%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="District_Name" SortExpression="District_Name" HeaderText="District">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</asp:DataGrid></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
