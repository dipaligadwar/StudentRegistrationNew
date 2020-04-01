<%@ Page language="c#" Codebehind="PhotoEnlarge.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.PhotoEnlarge" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PhotoEnlarge</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script>
			function BackMe()
			{
				history.go(-1);
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 72px" runat="server">Label</asp:Label>
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD width="100%" align="right"><a href="javascript:BackMe()">Back</a></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
