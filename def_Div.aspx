<%@ Register TagPrefix="uc1" TagName="HomeContentControl" Src="HomeContentControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="def_Div.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.def_Div" enableViewState="False" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<html>
	<head>
		<title>
			<%=Classes.clsGetSettings.Name%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
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
	<body leftmargin="0" topmargin="0">
		<form id="form1" method="post" runat="server">
			<!--start Main Div-->
			<div style="WIDTH: 100%; HEIGHT: 100%" align="center">
				<div id='Main"' style="WIDTH: 98%; HEIGHT: 100%">
					<!--	<div style="WIDTH: 100%"></div> 
					<div style="WIDTH: 100%;"></div> 
					 -->
					<div style="MARGIN-BOTTOM: 3px; WIDTH: 100%"><uc1:header id="UCHeader" runat="server" enableviewstate="False"></uc1:header></div>
					<!-- Div Main4 starts-->
					<div id="main4" style="MARGIN-TOP: 5px; WIDTH: 920px" align="center">
						<div id="div4_1" style="Z-INDEX: 12; FLOAT: left; MARGIN-LEFT: 15px; WIDTH: 160px; TOP: 5px; HEIGHT: 408px"
							align="left">
							<div style="MARGIN-BOTTOM: 5px"><uc1:menucontrol id="mnuUniversity" runat="server" enableviewstate="False"></uc1:menucontrol></div>
							<div style="MARGIN-BOTTOM: 5px"><uc1:menucontrol id="Menucontrol1" runat="server" enableviewstate="False"></uc1:menucontrol></div>
							<div style="MARGIN-BOTTOM: 5px"><uc1:menucontrol id="mnuActivities" runat="server" enableviewstate="False"></uc1:menucontrol></div>
							<div style="MARGIN-BOTTOM: 5px"><uc1:menucontrol id="mnuMedia" runat="server" enableviewstate="False"></uc1:menucontrol></div>
							<div>
								<object id="obj1" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0"
									height="74" width="170" border="0" classid="clsid:D27CDB6E-AE6D-11CF-96B8-444553540000">
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
							</div>
						</div>
						<div id="div4_2" style="FLOAT: left; MARGIN-LEFT: 5px; WIDTH: 542px; PADDING-TOP: 8px">
							<div id="dv1_1" style="HEIGHT: 135px"><img style="WIDTH: 532px; HEIGHT: 129px" height="129" src="Images/mainimage.jpg" width="532"
									border="0">
							</div>
							<!--News & Application --->
							<div id="dv1_2" style="FLOAT: left; MARGIN-BOTTOM: 5px; WIDTH: 542px; HEIGHT: 120px">
								<div id="div_News" style="FLOAT: left; MARGIN: 0px 5px 5px; WIDTH: 256px">
									<div><img height="5" src="Images/box03_topstrip.gif" width="260" border="0"></div>
									<div class="NewsTD" style="FLOAT: left; WIDTH: 260px; HEIGHT: 18px" align="left">:: 
										News &amp; Events
									</div>
									<div class="newsBox" style="FLOAT: left; WIDTH: 260px">
										<marquee onmouseover="this.stop()" style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; BACKGROUND-ATTACHMENT: fixed; PADDING-BOTTOM: 1px; WIDTH: 240px; COLOR: #6d6254; PADDING-TOP: 1px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 100px"
											onmouseout="this.start()" scrollamount="2" scrolldelay="60" direction="up"><uc1:homecontentcontrol id="UCNews" runat="server" enableviewstate="False"></uc1:homecontentcontrol></marquee>
									</div>
									<div></div>
								</div>
								<div id="div_AppForms" style="MARGIN-TOP: 0px; FLOAT: left; MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px; WIDTH: 260px; HEIGHT: 120px">
									<div><img height="5" src="Images/box03_topstrip.gif" width="260" border="0"></div>
									<div class="NewsTD" style="WIDTH: 260px; HEIGHT: 18px" align="left">:: Application 
										Forms
									</div>
									<div class="newsBox" style="WIDTH: 260px; HEIGHT: 100px"><uc1:homecontentcontrol id="UCApplicationFrm" runat="server" enableviewstate="False"></uc1:homecontentcontrol></div>
								</div>
							</div>
							<!--Downloads & Circulars --->
							<div id="dv1_3" style="FLOAT: left; WIDTH: 542px; HEIGHT: 120px">
								<div id="dvDownload" style="FLOAT: left; MARGIN-BOTTOM: 2px; MARGIN-LEFT: 5px; WIDTH: 260px; MARGIN-RIGHT: 5px; HEIGHT: 120px">
									<div><img height="5" src="Images/box04_topstrip.gif" width="260" border="0"></div>
									<div class="downloadsHeaderTD" style="WIDTH: 260px; HEIGHT: 18px" align="left">:: 
										Downloads</div>
									<div class="downloadBox"><uc1:homecontentcontrol id="UCDownloads" runat="server" enableviewstate="False"></uc1:homecontentcontrol></div>
								</div>
								<div class="downloadBox" id="dvCircular" style="FLOAT: left; MARGIN: 0px 5px 5px; WIDTH: 260px; HEIGHT: 120px">
									<div><img height="5" src="Images/box04_topstrip.gif" width="260" border="0"></div>
									<div class="downloadsHeaderTD" style="WIDTH: 100%" align="left">:: 
										Circulars/GR/Notices</div>
									<div class="downloadBox" style="HEIGHT: 103px"><uc1:homecontentcontrol id="UCCircular" runat="server"></uc1:homecontentcontrol></div>
								</div>
							</div>
							<div id="dv1_4" style="MARGIN-TOP: 5px; BACKGROUND-IMAGE: url(http://localhost/images/annoucementbg.gif); WIDTH: 542px; PADDING-TOP: 10px; HEIGHT: 39px">
								<marquee onmouseover="this.stop()" style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; BACKGROUND-ATTACHMENT: fixed; PADDING-BOTTOM: 1px; WIDTH: 542px; COLOR: #ff9933; PADDING-TOP: 1px; BACKGROUND-REPEAT: no-repeat"
									onmouseout="this.start()" scrollamount="2" scrolldelay="60" direction="left"><uc1:homecontentcontrol id="UCAnnouncement" runat="server"></uc1:homecontentcontrol></marquee>
							</div>
						</div>
						<div id="DIV4_3" style="FLOAT: left; MARGIN-LEFT: 5px; WIDTH: 160px">
							<!--Div 4_3 start..//Login Control -->
							<div class="login" id="div4_3_1" style="HEIGHT: 60px">
								<div style="HEIGHT: 5px"><img hspace="0" src="Images/box02_topstrip.gif" width="170" vspace="0"></div>
								<div class="login" style="MARGIN-TOP: 0px; WIDTH: 170px">
									<div>
										<div style="FLOAT: left; WIDTH: 50px"><font class="loginLabels">User</font></div>
										<div style="FLOAT: left"><asp:textbox id="txtUserName" runat="server" cssclass="loginbox" maxlength="50"></asp:textbox></div>
									</div>
									<div style="FLOAT: left; WIDTH: 100%; HEIGHT: 15px">
										<div style="FLOAT: left; WIDTH: 50px"><font class="loginLabels">Password</font></div>
										<div style="FLOAT: left"><asp:textbox id="txtPassword" runat="server" cssclass="loginbox" maxlength="15" textmode="Password"></asp:textbox></div>
									</div>
									<div style="FLOAT: left; WIDTH: 100%; HEIGHT: 15px">
										<div style="FLOAT: left; WIDTH: 80%" align="left"><asp:label id="lblError" runat="server" width="93px" font-bold="True" forecolor="Red" font-size="6pt"
												visible="False">Invalid User Name/Password</asp:label></div>
										<div style="FLOAT: left; WIDTH: 18%"><asp:button id="btnLogin" runat="server" cssclass="btnGo" text="Go"></asp:button></div>
									</div>
									<div style="HEIGHT: 2px"></div>
									<div style="FLOAT: left; WIDTH: 100%">
										<div><font class="loginLabels">Forgot Password</font></div>
									</div>
								</div>
								<div style="HEIGHT: 5px"><img height="5" src="Images/box02_bottom.gif" width="170" border="0"></div>
							</div>
							<!-- Ends Login Control-->
							<div style="MARGIN-TOP: 5px; FLOAT: left; WIDTH: 150px; HEIGHT: 80px" align="left"><a href="#" target="_self"><img style="WIDTH: 165px; HEIGHT: 74px" height="74" src="Images/admission.jpg" width="165"
										border="0"></a>
							</div>
							<div style="FLOAT: left"><a href="#" target="_self"><img height="74" src="Images/result.jpg" width="170" border="0"></a>
							</div>
							<div id="dvimg3" style="FLOAT: left"><a href="#" target="_self"><img src="Images/teacherreg.jpg" width="170" border="0"></a>
							</div>
							<div style="MARGIN-TOP: 5px; Z-INDEX: 10; FLOAT: left"><uc1:menucontrol id="mnuIPRPublication" runat="server" enableviewstate="False"></uc1:menucontrol></div>
							<div style="MARGIN-TOP: 5px; Z-INDEX: 10; FLOAT: left"><uc1:menucontrol id="mnuAcademics" runat="server" enableviewstate="False"></uc1:menucontrol></div>
						</div>
						<!-- Ends Div Main4 -->
						<div id="last" style="FLOAT: left; WIDTH: 100%"><uc1:footer id="Footer1" runat="server"></uc1:footer></div>
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
				</div>
			</div>
		</form>
	</body>
</html>
