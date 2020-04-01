<%@ Page language="c#" Codebehind="ListOfCourses_print.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.ListOfCourses_print" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title><%=UniversityPortal.clsGetSettings.Name%>
			| List of Courses</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
			<CENTER>
				<table id="tblPrint" width="650" border="0">
					<tr>
						<td align="right"><font face="Verdana" color="#bf0000" size="1"><A href="javascript:btnPrint_onclick();"><IMG id="imgPrint" title="Print" height="20" src="images/button_print.gif" width="16"
										border="0"></A></font></FONT></FONT>
						</td>
					</tr>
				</table>
				<table width="650">
					<tr>
						<td align="center" vAlign="top" width="100%"><img src="Images/Logo.jpg"></td>
					</tr>
					<tr>
						<td align="center"><asp:Label Runat="server" id="UName" Width="100%" Font-Size="12pt"></asp:Label></td>
					</tr>
					<tr>
						<td align="center"><asp:Label Runat="server" id="UAddress" Width="100%" Font-Size="12pt"></asp:Label></td>
					</tr>
					<tr>
						<td align="center"><br>
							<asp:Label id="lblNote" runat="server" Font-Bold="True"></asp:Label><br>
						</td>
					</tr>
					<tr>
						<td align="center">
							<asp:DataGrid id="dgData" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px"
								BorderColor="DarkGray" Width="99%">
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
							</asp:DataGrid></td>
					</tr>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
