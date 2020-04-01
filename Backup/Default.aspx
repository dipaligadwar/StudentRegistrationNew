<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Page language="c#" AutoEventWireup="false" Inherits="UniversityPortal.Default" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HomeContentControl" Src="HomeContentControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=System.Configuration.ConfigurationSettings.AppSettings["Name"]%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
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
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="form1" method="post" runat="server">
			<div align=center>
				<table id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900">
					<tr>
						<td colSpan="5"></td>
					<tr>
						<td colSpan="5" height="10">
							<uc1:Header id="UCHeader" runat="server"></uc1:Header></td>
					</tr>
					<tr>
						<td vAlign="top" width="170">
							<table id="table4" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="0"
								width="170" border="0">
								<tr>
									<td align="center" bgColor="#e7e2db" vAlign="top"><uc1:menucontrol id="mnuUniversity" runat="server"></uc1:menucontrol></td>
								</tr>
								<tr>
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td vAlign="top"><uc1:menucontrol id="mnuActivities" runat="server"></uc1:menucontrol></td>
								</tr>
								<tr>
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td vAlign="top"><uc1:menucontrol id="mnuMedia" runat="server"></uc1:menucontrol></td>
								</tr>
								<tr>
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td>
										<object classid="clsid:D27CDB6E-AE6D-11CF-96B8-444553540000" id="obj1" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0"
											border="0" width="170" height="74">
											<param name="movie" value="images/aff.swf">
											<param name="quality" value="High">
											<embed src="images/aff.swf" pluginspage="http://www.macromedia.com/go/getflashplayer" Type="application/x-shockwave-flash" name="obj1" width="170" height="74" />
										</object>
										<!--<IMG height="74" src="Images/affi.jpg" width="170" border="0">-->
									</td>
								</tr>
							</table>
						</td>
						<td></td>
						<td vAlign="top" align="center" width="558">
							<table id="table6" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="0"
								width="542" border="0">
								<tr>
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><IMG height="129" src="Images/mainimage.jpg" width="542" border="0"></td>
								</tr>
								<tr>
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td>
										<table id="table7" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="0"
											width="542" border="0">
											<tr>
												<td width="265"><IMG height="5" src="Images/box03_topstrip.gif" width="265" border="0"></td>
												<td width="12" rowSpan="3">&nbsp;</td>
												<td width="265"><IMG height="5" src="Images/box03_topstrip.gif" width="265" border="0"></td>
											</tr>
											<tr>
												<td class="NewsTD" width="265">&nbsp;:: News &amp; Events</td>
												<td class="NewsTD" width="265">&nbsp;:: Application Forms</td>
											</tr>
											<tr>
												<td width="265" height="100" class="newsBox">
													<MARQUEE onmouseover="this.stop()" style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; BACKGROUND-ATTACHMENT: fixed; PADDING-BOTTOM: 1px; WIDTH: 265px; COLOR: #6d6254; PADDING-TOP: 1px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 100px"
														onmouseout="this.start()" scrollAmount="2" scrollDelay="60" direction="up" align='justify"'><uc1:homecontentcontrol id="UCNews" runat="server"></uc1:homecontentcontrol></MARQUEE>
												</td>
												<td valign="top" width="265" class="newsBox">&nbsp;
													<uc1:homecontentcontrol id="UCApplicationFrm" runat="server"></uc1:homecontentcontrol></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td>
										<table id="table8" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="0"
											width="542" border="0">
											<tr>
												<td width="265"><IMG height="5" src="Images/box04_topstrip.gif" width="265" border="0"></td>
												<td width="12" rowSpan="3">&nbsp;</td>
												<td width="265"><IMG height="5" src="Images/box04_topstrip.gif" width="265" border="0"></td>
											</tr>
											<tr>
												<td class="downloadsHeaderTD" width="265">&nbsp;:: Downloads</td>
												<td class="downloadsHeaderTD" width="265">&nbsp;:: Circulars/GR/Notices</td>
											</tr>
											<tr>
												<td vAlign="top" width="265" class="downloadBox"><uc1:homecontentcontrol id="UCDownloads" runat="server"></uc1:homecontentcontrol></td>
												<td vAlign="top" width="265" height="75" class="downloadBox"><uc1:homecontentcontrol id="UCCircular" runat="server"></uc1:homecontentcontrol></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td height="39" background="Images/annoucementbg.gif" valign="middle">
										<MARQUEE onmouseover="this.stop()" style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; BACKGROUND-ATTACHMENT: fixed; PADDING-BOTTOM: 1px; WIDTH: 542px; COLOR: #ff9933; PADDING-TOP: 1px; BACKGROUND-REPEAT: no-repeat"
											onmouseout="this.start()" scrollAmount="2" scrollDelay="60" direction="left">
											<uc1:HomeContentControl id="UCAnnouncement" runat="server"></uc1:HomeContentControl></MARQUEE>
									</td>
								</tr>
							</table>
						</td>
						<td></td>
						<td vAlign="top" width="170">
							<table id="table5" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="0"
								width="170" border="0">
								<tr>
									<td><IMG height="5" src="Images/box02_topstrip.gif" width="170" border="0"></td>
								</tr>
								<tr>
									<td vAlign="top" height="75" class="login">
										<table>
											<tr>
												<td align="right"><font face="verdana" color="#666666" size="1">User</font></td>
												<td align="right"><asp:textbox id="txtUserName" runat="server" CssClass="loginbox" MaxLength="50"></asp:textbox></td>
											</tr>
											<tr>
												<td><font face="verdana" color="#666666" size="1">Password</font></td>
												<td><asp:textbox id="txtPassword" runat="server" CssClass="loginbox" MaxLength="15" TextMode="Password"></asp:textbox></td>
											</tr>
											<tr>
												<td vAlign="baseline" align="right" colSpan="2"><asp:label id="lblError" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="6pt" Visible="False">Invalid User Name/Password</asp:label><asp:button id="btnLogin" runat="server" CssClass="btnGo" Text="Go"></asp:button></td>
											</tr>
											<tr>
												<td colSpan="2"><font face="verdana" color="#666666" size="1">Forgot Password</font>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td><IMG height="5" src="Images/box02_bottom.gif" width="170" border="0"></td>
								</tr>
								<tr>
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><IMG src="Images/admission.jpg" width="170" border="0"></td>
								</tr>
								<tr>
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><IMG height="74" src="Images/result.jpg" width="170" border="0"></td>
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
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><IMG src="Images/teacherreg.jpg" border="0" width="170"></td>
								</tr>
								<tr>
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><uc1:menucontrol id="mnuIPRPublication" runat="server"></uc1:menucontrol></td>
								</tr>
								<tr>
									<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
								</tr>
								<tr>
									<td><uc1:menucontrol id="mnuAcademics" runat="server"></uc1:menucontrol></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td colSpan="5" height="1"><uc1:footer id="Footer1" runat="server"></uc1:footer></td>
					</tr>
					<tr>
						<td colSpan="5"></td>
					</tr>
				</table>
		<asp:repeater id="mnuReapeater" runat="server">
			<HeaderTemplate>
						<script language="javascript"> 
							
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
			</HeaderTemplate>				
		</asp:repeater>
	</div>
</form>
</body>
</HTML>
