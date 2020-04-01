<%@ Page language="c#" Codebehind="searchColInst_print.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.searchColInst_print" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title><%=Classes.clsGetSettings.Name%>
			| Course Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
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
						<TD align="center"><asp:label id="UName" Font-Size="12pt" Runat="server" Width="100%"></asp:label></TD>
					</TR>
					<TR>
						<TD align="center"><asp:label id="UAddress" Font-Size="12pt" Runat="server" Width="100%"></asp:label></TD>
					</TR>
					<TR>
						<TD align="center"><BR>
							<asp:label id="lblData" runat="server" Width="100%"></asp:label><BR>
						</TD>
					</TR>
					<TR>
						<TD align="center"><asp:DataGrid id="dgData" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px"
								BorderColor="DarkGray" Width="99%">
								<HeaderStyle BackColor="#E0E0E0"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="pk_Inst_ID" HeaderText="pk_Inst_ID"></asp:BoundColumn>
									<asp:BoundColumn HeaderText="Sr.No.">
										<HeaderStyle Width="2%" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Inst_Name" HeaderText="Name">
										<HeaderStyle Width="25%" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SocTrt_Name" HeaderText="Parent Body">
										<HeaderStyle Width="25%" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Address" HeaderText="Address">
										<HeaderStyle Width="25%" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="District_Name" HeaderText="District">
										<HeaderStyle Width="10%" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
