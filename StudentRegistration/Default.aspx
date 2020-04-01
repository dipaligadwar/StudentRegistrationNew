<%@ Register TagPrefix="uc1" TagName="HomeContentControl" Src="HomeContentControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#"  AutoEventWireup="false" Inherits="UniversityPortal.Default" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<META http-equiv=CACHE-CONTROL content=NO-CACHE>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<link href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function validate_Me()
			{
					var i=-1;
					var myArr= new Array();
					myArr[++i]= new Array(document.getElementById("<% =txtUserName.ClientID%>"),"Empty","Enter User Name.","text");	
					myArr[++i]= new Array(document.getElementById("<% =txtPassword.ClientID%>"),"Empty","Enter Password.","text");
					var ret=validateMe(myArr,50);
					return ret;
			}
		</script>
	</head>
	<body leftmargin="0" topmargin="0" rightmargin="0">
		<form id="form1" method="post" runat="server">
			<center>
				<table id="table1" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="2"
					width="900">
					<tr>
						<td colspan="5"></td>
					<tr>
						<td colspan="5" height="23" style="HEIGHT: 23px"><uc1:header id="UCHeader" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td valign="top" width="170">
							<table id="table4" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="0"
								width="170" border="0">
								<tr>
									<td valign="top" align="center" bgcolor="#e7e2db"><uc1:menucontrol id="mnuUniversity" runat="server"></uc1:menucontrol></td>
								</tr>
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td valign="top"><uc1:menucontrol id="mnuActivities" runat="server"></uc1:menucontrol></td>
								</tr>
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td valign="top"><uc1:menucontrol id="mnuMedia" runat="server"></uc1:menucontrol></td>
								</tr>
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td>
										<object id="obj1" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0"
											height="74" width="170" border="0" classid="clsid:D27CDB6E-AE6D-11CF-96B8-444553540000"
											viewastext>
											<param name="_cx" value="4498">
											<param name="_cy" value="1958">
											<param name="FlashVars" value="">
											<param name="Movie" value="images/aff.swf">
											<param name="Src" value="images/aff.swf">
											<param name="WMode" value="Window">
											<param name="Play" value="-1">
											<param name="Loop" value="-1">
											<param name="Quality" value="High">
											<param name="SAlign" value="">
											<param name="Menu" value="-1">
											<param name="Base" value="">
											<param name="AllowScriptAccess" value="">
											<param name="Scale" value="ShowAll">
											<param name="DeviceFont" value="0">
											<param name="EmbedMovie" value="0">
											<param name="BGColor" value="">
											<param name="SWRemote" value="">
											<param name="MovieData" value="">
											<param name="SeamlessTabbing" value="1">
											<param name="Profile" value="0">
											<param name="ProfileAddress" value="">
											<param name="ProfilePort" value="0">
											<param name="AllowNetworking" value="all">
											<embed src="images/aff.swf" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
												name="obj1" width="170" height="74">
										</object>
										<!--<IMG height="74" src="Images/affi.jpg" width="170" border="0">--></td>
								</tr>
							</table>
						</td>
						<td></td>
						<td valign="top" align="center" width="558">
							<table id="table6" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="0"
								width="542" border="0">
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><img height="129" src="Images/mainimage.jpg" width="542" border="0"></td>
								</tr>
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td>
										<table id="table7" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="0"
											width="542" border="0">
											<tr>
												<td width="265"><img height="5" src="Images/box03_topstrip.gif" width="265" border="0"></td>
												<td width="12" rowspan="3">&nbsp;</td>
												<td width="265"><img height="5" src="Images/box03_topstrip.gif" width="265" border="0"></td>
											</tr>
											<tr>
												<td class="NewsTD" width="265">&nbsp;:: News &amp; Events</td>
												<td class="NewsTD" width="265">&nbsp;:: Application Forms</td>
											</tr>
											<tr>
												<td class="newsBox" width="265" height="100">
													<marquee onmouseover="this.stop()" style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; BACKGROUND-ATTACHMENT: fixed; PADDING-BOTTOM: 1px; WIDTH: 265px; COLOR: #6d6254; PADDING-TOP: 1px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 100px"
														onmouseout="this.start()" scrollamount="2" scrolldelay="60" direction="up" align='justify"'><uc1:homecontentcontrol id="UCNews" runat="server"></uc1:homecontentcontrol></marquee>
												</td>
												<td class="newsBox" valign="top" width="265">&nbsp;
													<uc1:homecontentcontrol id="UCApplicationFrm" runat="server"></uc1:homecontentcontrol></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td>
										<table id="table8" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="0"
											width="542" border="0">
											<tr>
												<td width="265"><img height="5" src="Images/box04_topstrip.gif" width="265" border="0"></td>
												<td width="12" rowspan="3">&nbsp;</td>
												<td width="265"><img height="5" src="Images/box04_topstrip.gif" width="265" border="0"></td>
											</tr>
											<tr>
												<td class="downloadsHeaderTD" width="265">&nbsp;:: Downloads</td>
												<td class="downloadsHeaderTD" width="265">&nbsp;:: Circulars/GR/Notices</td>
											</tr>
											<tr>
												<td class="downloadBox" valign="top" width="265"><uc1:homecontentcontrol id="UCDownloads" runat="server"></uc1:homecontentcontrol></td>
												<td class="downloadBox" valign="top" width="265" height="75"><uc1:homecontentcontrol id="UCCircular" runat="server"></uc1:homecontentcontrol></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td valign="middle" background="Images/annoucementbg.gif" height="39">
										<marquee onmouseover="this.stop()" style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; BACKGROUND-ATTACHMENT: fixed; PADDING-BOTTOM: 1px; WIDTH: 542px; COLOR: #ff9933; PADDING-TOP: 1px; BACKGROUND-REPEAT: no-repeat"
											onmouseout="this.start()" scrollamount="2" scrolldelay="60" direction="left"><uc1:homecontentcontrol id="UCAnnouncement" runat="server"></uc1:homecontentcontrol></marquee>
									</td>
								</tr>
							</table>
						</td>
						<td></td>
						<td valign="top" width="170">
							<table id="table5" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="0"
								width="170" border="0">
								<tr>
									<td><img height="5" src="Images/box02_topstrip.gif" width="170" border="0"></td>
								</tr>
								<tr>
									<td class="login" valign="top" height="75">
										<table>
											<tr>
												<td align="right"><font class="loginLabels">User</font></td>
												<td align="right"><asp:textbox id="txtUserName" runat="server" cssclass="loginbox" maxlength="50"></asp:textbox></td>
											</tr>
											<tr>
												<td><font class="loginLabels">Password</font></td>
												<td><asp:textbox id="txtPassword" runat="server" cssclass="loginbox" maxlength="15" textmode="Password"></asp:textbox></td>
											</tr>
											<tr>
												<td valign="baseline" align="right" colspan="2"><asp:label id="lblError" runat="server" font-bold="True" forecolor="Red" font-size="6pt" visible="False">Invalid User Name/Password</asp:label><asp:button id="btnLogin" runat="server" cssclass="btnGo" text="Go"></asp:button></td>
											</tr>
											<tr>
												<td colspan="2"><font class="loginLabels">Forgot Password</font>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td><img height="5" src="Images/box02_bottom.gif" width="170" border="0"></td>
								</tr>
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><a href="#" target="_self"><img src="Images/admission.jpg" width="170" border="0"></a></td>
								</tr>
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><a href="#" target="_self"><img height="74" src="Images/result.jpg" width="170" border="0"></a></td>
								</tr>
								<!--tr>
									<td>
										<object classid="clsid:D27CDB6E-AE6D-11CF-96B8-444553540000" id="obj1" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0"
											border="0" width="170" height="74">
											<param name="movie" value="images/aff.swf">
											<param name="quality" value="High">
											<embed src="images/aff.swf" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
												name="obj1" width="170" height="74">
										</object>										
									</td>
								</tr-->
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><a href="#" target="_self"><img src="Images/teacherreg.jpg" width="170" border="0"></a></td>
								</tr>
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><uc1:menucontrol id="mnuIPRPublication" runat="server"></uc1:menucontrol></td>
								</tr>
								<tr>
									<td><img height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><uc1:menucontrol id="mnuAcademics" runat="server"></uc1:menucontrol></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td colspan="5" height="1"><uc1:footer id="Footer1" runat="server"></uc1:footer></td>
					</tr>
					<tr>
						<td colspan="5"></td>
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
		</asp:repeater></center>
		</form>
	</body>
</html>
