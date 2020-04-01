<%@ Page language="c#" Codebehind="FileUploadTest.aspx.cs" AutoEventWireup="false" Inherits="Test.FileUploadTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FileUploadTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style>
			.TBBody { FONT-SIZE: 8pt; FONT-FAMILY: verdana }
			.lbl { FONT-SIZE: 8pt; FONT-FAMILY: verdana }
			.button { BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; FONT-SIZE: 8pt; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; FONT-FAMILY: verdana }
		</style>
	</HEAD>
	<body class="TBBody">
		<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
			<table cellpadding="0" cellspacing="1" width="80%" border="0" height="300" align="center">
				<tr>
					<td align="center" valign="middle">
						<table cellpadding="1" cellspacing="0" border="0" width="35%" align="center" bgcolor="darkgray">
							<tr bgcolor="#dcdcdc">
								<td class="lbl">File</td>
								<td>:</td>
								<td><INPUT id="filMyFile" type="file" name="File1" runat="server" class="button"></td>
							</tr>
							<tr bgcolor="#dcdcdc">
								<td colspan="3" align="center">
									<asp:Button id="cmdSend" runat="server" Text="Upload " CssClass="button"></asp:Button>
								</td>
							</tr>
							<tr bgcolor="#dcdcdc">
								<td colspan="3">
									<asp:Label id="lblInfo" runat="server" CssClass="lbl"></asp:Label>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
