<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrgStrControl" Src="OrgStrControl.ascx" %>
<%@ Page language="c#" Codebehind="VisualTour.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.VisualTour" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Classes.clsGetSettings.Name%>
			| </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="jscript/jscript_validations.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" name="RegisterComplaint" method="post" runat="server">
			<CENTER>
				<table id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
					<tr>
						<td colSpan="4"></td>
					</tr>
					<tr>
						<td colSpan="4" height="28" style="HEIGHT: 28px"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td colSpan="4" height="5"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px" vAlign="top">
							<uc1:InnerMenuControl id="UCInnerMenuControl" runat="server"></uc1:InnerMenuControl><INPUT type="hidden" runat="server" id="hid_Page" name="hid_Page"><INPUT type="hidden" runat="server" id="hid_MenuID" name="hid_MenuID">
						</td>
						<td vAlign="top" width="830">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<TABLE id="Table2" width="100%">
											<tr>
												<td vAlign="top" align="left" width="99%">
													<P align="left">
														<uc1:OrgStrControl id="OrgStrControl1" runat="server"></uc1:OrgStrControl></P>
													<P class="llblContentTitle">Visual Tour</P>
												</td>
											</tr>
											<TR>
												<TD vAlign="top" align="center" width="99%">
													<p>&nbsp;</p>
													<OBJECT id="gallery" style="WIDTH: 631px; HEIGHT: 410px" codeBase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"
														height="516" width="630" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" VIEWASTEXT>
														<PARAM NAME="_cx" VALUE="16695">
														<PARAM NAME="_cy" VALUE="10848">
														<PARAM NAME="FlashVars" VALUE="">
														<PARAM NAME="Movie" VALUE="gallery.swf">
														<PARAM NAME="Src" VALUE="gallery.swf">
														<PARAM NAME="WMode" VALUE="Transparent">
														<PARAM NAME="Play" VALUE="0">
														<PARAM NAME="Loop" VALUE="-1">
														<PARAM NAME="Quality" VALUE="High">
														<PARAM NAME="SAlign" VALUE="">
														<PARAM NAME="Menu" VALUE="0">
														<PARAM NAME="Base" VALUE="">
														<PARAM NAME="AllowScriptAccess" VALUE="always">
														<PARAM NAME="Scale" VALUE="ShowAll">
														<PARAM NAME="DeviceFont" VALUE="0">
														<PARAM NAME="EmbedMovie" VALUE="0">
														<PARAM NAME="BGColor" VALUE="FFFFFF">
														<PARAM NAME="SWRemote" VALUE="">
														<PARAM NAME="MovieData" VALUE="">
														<PARAM NAME="SeamlessTabbing" VALUE="1">
														<PARAM NAME="Profile" VALUE="0">
														<PARAM NAME="ProfileAddress" VALUE="">
														<PARAM NAME="ProfilePort" VALUE="0">
														<PARAM NAME="AllowNetworking" VALUE="all">
														<PARAM NAME="AllowFullScreen" VALUE="false">
														<embed src="gallery.swf" quality="High" bgcolor="#ffffff" width="732" height="350" name="gallery"
															align="" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer"
															menu="false" />
													</OBJECT>
												</TD>
											</TR>
											<!--tr height="30">
												<td align=right ><font color='#666666'><strong>Photographs Courtesy:</strong> Mr. Shaikh Babamiya 
														Karim, University Photographer</font></td>
											</tr-->
										</TABLE>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td colSpan="3"></IMG></td>
					</tr>
					<tr>
						<td colSpan="3"><uc1:footer id="Footer1" runat="server"></uc1:footer></td>
					</tr>
				</table>
				<asp:repeater id="mnuReapeater" runat="server">
			<HeaderTemplate>
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
		</asp:repeater></CENTER>
		</form>
	</body>
</HTML>
