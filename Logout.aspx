<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="StudentRegistration.Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>
			<%=Classes.clsGetSettings.Name%>
			| ::Logout</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/jscript_validations.js"></script>
		<LINK href="CSS/Uniportal.css" type="text/css" rel="stylesheet">
		<link href="CSS/gray.css" rel="stylesheet" title='Color-Scheme' type="text/css" /> 
   <link href="CSS/calendar-blue.css" type="text/css" rel="stylesheet">
</head>
<body vLink="#0066ff" aLink="#0066ff" link="#0066ff" bgColor="#ffffff" leftMargin="0"		>
		<script language="javascript" src="<%=Classes.clsGetSettings.SitePath%>jscript/changescheme.js" type="text/javascript" ></script>    
		<form id="frm" method="post" runat="server">
			<TABLE WIDTH="890" CELLSPACING="0" CELLPADDING="0" BORDER="0" align="center" bgcolor="white" style="margin-top:5px"  id="main"  >
				<%--<TR>
					<TD >
						<uc1:Header id="UCHeader" runat="server"></uc1:Header>
					</TD>
				</TR>--%>
				<TR>
					<TD align="center" height="355">
						<table width="60%" cellpadding="0" cellspacing="0" height="90" style="BORDER-RIGHT: 1px dotted; BORDER-TOP: 1px dotted; BORDER-LEFT: 1px dotted; BORDER-BOTTOM: 1px dotted; BORDER-COLLAPSE: collapse"
							bordercolor="#68689a">
							<tr>
								<td>
									<table width="100%" cellpadding="0" cellspacing="0" class="bgcolorLight" height="100%">
										<tr>
											<td align="center" class="normalFont">
												You Have Logged Out. Please <a href="Login.aspx" class="LogOut">Login</a> Again
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
				
			</TABLE>
			  <div align="center" style="width:100%">
			<%--<uc1:Footer id="Footer1" runat="server"></uc1:Footer>--%>
			</div>
		</form>
	</body>
</html>
