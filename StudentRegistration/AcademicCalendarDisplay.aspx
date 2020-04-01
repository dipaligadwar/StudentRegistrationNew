<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrgStrControl" Src="OrgStrControl.ascx" %>
<%@ Page language="c#" Codebehind="AcademicCalendarDisplay.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.AcademicCalendarDisplay" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="css/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<script language="javascript" src="JS/header.js"></script>
		<script language="javascript" src="JS/footer.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="JS/change.js"></script>
	</head>
	<body leftmargin="0" topmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<table id="table1" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="2"
					width="900" border="0">
					<tr>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td colspan="4" height="10"><uc1:header id="UCHeader" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td colspan="4" height="5"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px; HEIGHT: 358px" valign="top"><uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol><input type="hidden" runat="server" id="hid_Page" name="hid_Page"><input type="hidden" runat="server" id="hid_MenuID" name="hid_MenuID">
						</td>
						<td style="HEIGHT: 358px" valign="top" width="830">
							<table width="100%">
								<tr>
									<td valign="top" align="left" width="99%">
										<p align="left">
											<uc1:orgstrcontrol id="OrgStrControl1" runat="server"></uc1:orgstrcontrol>
										</p>
										<p class="llblContentTitle" align="left"><asp:label id="lblTitle" runat="server" cssclass="llblContentTitle" font-bold="True">Academic Calendar</asp:label></p>
										<table cellspacing="1" cellpadding="2" width="100%">
											<tr>
												<td align="right"></td>
												<td align="center"></td>
												<td align="right" colspan="2"><asp:label id="MsgLabel" runat="server" width="200px"></asp:label></td>
											</tr>
											<tr>
												<td align="right" width="30%"><b>Select Academic Year</b></td>
												<td align="center" width="1%"><b>:</b></td>
												<td valign="middle" align="left" width="23%"><asp:dropdownlist id="Academic_Year" runat="server" cssclass="selectBoxHome" width="152px"></asp:dropdownlist>
												&nbsp;
												<td align="left"><asp:button id="btnGo" runat="server" cssclass="butsp" width="96px" text="Display"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td align="center" colspan="4"></td>
								</tr>
								<tr>
									<td align="center" colspan="4"><asp:label id="lblAcademicYear" runat="server" font-bold="True" width="472px"></asp:label></td>
								</tr>
								<tr>
									<td align="center" colspan="4"><asp:placeholder id="plcTable" runat="server"></asp:placeholder></td>
								</tr>
								<tr>
									<td align="center" colspan="4"></td>
								</tr>
							</table>
							<asp:label id="lblUpdationDate" runat="server"></asp:label></td>
						<td valign="top" align="left" width="1%"></td>
					</tr>
				</table>
				</td></tr>
				<tr>
					<td colspan="3"></td>
				</tr>
				<tr>
					<td colspan="3"><uc1:footer id="Footer1" runat="server"></uc1:footer></td>
				</tr>
				</table><asp:repeater id="mnuReapeater" runat="server">
			<headertemplate>
						<script language="javascript"> 
					</HeaderTemplate>					
						<ItemTemplate>
					
					var sWidth=0;
			
					var pos="right";
								if(parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetWidth)))+170 < screen.width)
								{
									sWidth = parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetWidth)));
								}
								else
								{
									pos="left";
									sWidth= parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetWidth)))-335;
								}			
							new ypSlideOutMenu("menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>", pos,sWidth ,parseInt(document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetTop+document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetTop),170,document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>Content')?document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>Content').offsetHeight:0);


						</ItemTemplate>
				<FooterTemplate> 
					ypSlideOutMenu.writeCSS();				
						</script>
				</FooterTemplate>			
		</asp:repeater></div>
			<input id="hid_Mode" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hid_Mode" runat="server" /><input id="hidUniID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hidUniID" runat="server" /><input id="hidFacID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hidFacID" runat="server" /><input id="hidSubID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hidSubID" runat="server" /></form>
	</body>
</html>
