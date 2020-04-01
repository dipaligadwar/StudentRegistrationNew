<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrgStrControl" Src="OrgStrControl.ascx" %>
<%@ Page language="c#" Codebehind="ContactUs.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.ContactUs" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Classes.clsGetSettings.Name%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<link href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" rightmargin="0">
		<form>
			<div align="center">
				<table id="table1" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="2"
					width="900" border="0">
					<tr>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td colspan="4" height="10">
							<uc1:header id="UCHeader" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td height="5" colspan="4"></td>
					</tr>
					<tr>
						<td valign="top" style="WIDTH: 170px">
							<p>
								<uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol></p>
							<input type="hidden" runat="server" id="hid_Page" name="hid_Page"><input type="hidden" runat="server" id="hid_MenuID" name="hid_MenuID">
						</td>
						<td width="830" valign="top">
							<table width="100%">
								<tr>
									<td width="99%" valign="top" align="left" colspan="2">
										<p align="left">
											<uc1:orgstrcontrol id="OrgStrControl1" runat="server"></uc1:orgstrcontrol></p>
										<p>
											<asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" cssclass="llblContentTitle">Contact Us</asp:label></p>
									</td>
								</tr>
								<tr height="15">
									<td valign="top" align="left" width="99%" colspan="2">&nbsp;</td>
								</tr>
								<tr>
									<td valign="top" align="left" width="99%" colspan="2">
										<asp:label id="lblContent" runat="server"></asp:label></td>
								</tr>
							</table>
							<div align="center"><font face="Verdana" size="1"></font>
							</div>
						</td>
					</tr>
					<tr>
						<td colspan="3"></td>
					</tr>
					<tr>
						<td colspan="3">
							<uc1:footer id="Footer1" runat="server"></uc1:footer></td>
					</tr>
				</table>
				<asp:repeater id="mnuReapeater" runat="server">
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
		</form>
	</body>
</HTML>
