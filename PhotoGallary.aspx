<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrgStrControl" Src="OrgStrControl.ascx" %>
<%@ Page language="c#" Codebehind="PhotoGallary.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.PhotoGallary" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
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
		<LINK href="css/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<script language="javascript" src="JS/header.js"></script>
		<script language="javascript" src="JS/footer.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="JS/change.js"></script>
		<script language="javascript">
		function ManageDTIndex()
		{ 
			//alert((parseInt(document.getElementById("<%=hid_PriCount.ClientID%>").value))-8);
			document.getElementById("<%=hid_PriCount.ClientID%>").value=(parseInt(document.getElementById("<%=hid_PriCount.ClientID%>").value))-8;
			document.getElementById("<%=hidBtn.ClientID%>").value="Pri";
		}
		function nextClick()
		{
			document.getElementById("<%=hidBtn.ClientID%>").value="Next";
		}
		</script>
	</HEAD>
	<BODY leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<CENTER>&nbsp;
				<table id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
					<tr>
						<td colSpan="4"></td>
					</tr>
					<tr>
						<td colSpan="4" height="10"><uc1:header id="UCHeader" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td style="HEIGHT: 12px" colSpan="4" height="12"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px" vAlign="top">
							<uc1:InnerMenuControl id="UCInnerMenuControl" runat="server"></uc1:InnerMenuControl><INPUT type="hidden" runat="server" id="hid_Page" name="hid_Page"><INPUT type="hidden" runat="server" id="hid_MenuID" name="hid_MenuID">
						</td>
						<td height="360" vAlign="top" width="830">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="70%">
										<P align="left">
											<uc1:OrgStrControl id="OrgStrControl1" runat="server"></uc1:OrgStrControl></P>
										<P class="llblContentTitle">Photo Gallery</P>
									</td>
									<td align="right"><p align="right"><a href='#Video' class="footerlink">Video Clips</a></p>
									</td>
								</tr>
								<tr>
									<td colspan="2"><asp:label id="lblTable" runat="server">Label</asp:label></td>
								</tr>
								<tr>
									<td colspan="2" align="center"><asp:button id="btnPri" runat="server" Height="26px" CssClass="butSubmit" Text="« « Previous"></asp:button><asp:button id="btnNext" runat="server" Height="26px" CssClass="butSubmit" Text="Next » »" Width="104px"></asp:button></td>
								</tr>
								<TR>
									<TD colspan="2" vAlign="top" align="left" width="99%">&nbsp;</TD>
								</TR>
								<TR>
									<TD colspan="2" vAlign="top" align="left" width="99%">
										<TABLE id="Table2" width="100%">
											<TR>
												<TD vAlign="top" align="left" width="99%" style="HEIGHT: 13px">
													<P class="llblContentTitle" align="left">
														<asp:label id="lblVideoTitle" runat="server" CssClass="llblContentTitle"><a id="Video">Video</a>&nbsp;Clips</asp:label>
													</P>
											<TR>
												<TD vAlign="top" align="left" width="99%">
													<asp:label id="lblVideoDisplay" runat="server"></asp:label></TD>
											</TR>
										</TABLE>
										&nbsp;
									</TD>
								</TR>
							</table>
							<INPUT id="hid_PriCount" style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4" runat="server">
							<INPUT id="hidBtn" style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4" name="hidBtn"
								runat="server"></td>
					</tr>
					<tr>
						<td colSpan="3"></td>
					</tr>
					<tr>
						<td colSpan="3">
							<uc1:footer id="Footer1" runat="server"></uc1:footer></td>
					</tr>
				</table>
				<asp:repeater id="mnuReapeater" runat="server">
			<HeaderTemplate>
						<script language="javascript"> 
					</HeaderTemplate>					
						<ItemTemplate>
					//	alert(document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetLeft);
					var sWidth=0;
			//		alert(parseInt(document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetTop+document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetTop));
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
		</asp:repeater>
			</CENTER>
		</form>
	</BODY>
</HTML>
