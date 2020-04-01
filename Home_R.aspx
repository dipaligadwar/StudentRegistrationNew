<%@ Register TagPrefix="uc1" TagName="topMenuBar" Src="WebCtrl/topMenuBar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UniversityCalender" Src="UniversityCalender.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HomeContentControl" Src="HomeContentControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AlertsandReminders" Src="AlertsandReminders.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MessagingInbox" Src="MessagingInbox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CircularControl" Src="CircularControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerHeader" Src="InnerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SideLinks" Src="SideLinks.ascx" %>
<%@ Page language="c#" Codebehind="Home_R.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.Home_R"  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title> <%=Classes.clsGetSettings.Name%>  | Login Home</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<link type="text/css" rel="stylesheet" href="CSS/UniPortal.css">
		<script language="javascript">
		<!--
		function MM_preloadImages()
		 { //v3.0
			var d=document; 
			if(d.images)
			{ 
				
				if(!d.MM_p) 
				d.MM_p=new Array();
				var i;
				var j=d.MM_p.length;
				var a=MM_preloadImages.arguments;
				for(i=0; i<a.length; i++)
				{
					if (a[i].indexOf("#")!=0)
					{
						d.MM_p[j]=new Image; 
						d.MM_p[j++].src=a[i];
					}
				}
			}
		}
	
	/*function imgOn (imgName) 
	{
		if (document.images) 
		{
			document[imgName].src = eval(imgName + "on.src");
		}
	}

	function imgOff (imgName) 
	{
		if (document.images) 
		{
			document[imgName].src = eval(imgName + "off.src");
		}
	}*/	
		

		function MenuMouseOut(image,hyperLink)
		{
			var img=hyperLink.childNodes[0];
			img.src=image;
		}
		
		function MenuMouseOver(image,hyperLink)
		{
			var img=hyperLink.childNodes[0];
			img.src=image;
		}
		-->
		</script>
</head>
	<body topmargin="0" leftmargin="0">
		<!--onLoad="MM_preloadImages('images')-->
		<form id="Form1" method="post" runat="server">
			<center>
				<div id="table1" style="WIDTH: 900px;BORDER-COLLAPSE: collapse" cellpadding="2">
					<div style="WIDTH:100%"></div>
					<div style="WIDTH:100%;HEIGHT:10px">
						<uc1:innerheader id="InnerHeader1" runat="server"></uc1:innerheader></div>
					<div style="WIDTH:100%;POSITION:static">
						<div style="FLOAT:left;WIDTH:18%;HEIGHT:50px" align="center" class="FormName">
							<img height="45" src="images/CoomingSoon.gif" width="45"></div>
						<div style="FLOAT:left" class="FormName">
							<asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" cssclass="llblContentTitle"></asp:label>
							&nbsp;<span class="WelcomeMsg">[<asp:label id="lblUpdationDate" runat="server"></asp:label>]</span>
							&nbsp;</div>
					</div>
					<div style="WIDTH:100%;POSITION:static">
						<div style="FLOAT:left;VERTICAL-ALIGN:top;WIDTH:18%;HEIGHT:380px" class="SideLeft">
							<p align="center">&nbsp;</p>
							<p align="center"><asp:image id="imgContainer" runat="server" visible="False"></asp:image></p>
							<p align="center"><asp:label id="lblName" style="TEXT-ALIGN: justify" runat="server"></asp:label></p>
							<uc1:sidelinks id="SideLinks1" runat="server"></uc1:sidelinks>
							<p></p>
						</div>
						<!--div4_2 Starts-->
						<div style= "PADDING-LEFT: 50px; FLOAT: left; WIDTH: 700px; HEIGHT: 380px" id="div4_2" class="FooterTop">
							<div style="VERTICAL-ALIGN:top">
								<div id="Table2" style="HEIGHT:168px">
									<div style="HEIGHT:5px"></div>
									<div>
										<div align="center">
											<div style="WIDTH:542px">
												<div style="WIDTH:100%">			
												</div>
												<div style="WIDTH:100%" >
													<div style="FLOAT:left;WIDTH:265px">
														<uc1:messaginginbox id="MessagingInbox1" runat="server"></uc1:messaginginbox></div>
													
													<div style="PADDING-LEFT:10px;FLOAT:left;WIDTH:265px">
														<uc1:alertsandreminders id="AlertsandReminders1" runat="server"></uc1:alertsandreminders></div>
												</div>
												<div>
													<div colspan="3"><img height="5" src="Images/spacer.gif" width="50" border="0"></div>
												</div>
												<div style="WIDTH:100%">
													<div  style="FLOAT:left;WIDTH:265px">
														<uc1:universitycalender id="UniversityCalender1" runat="server"></uc1:universitycalender></div>
													
													<div  style="PADDING-LEFT:10px;FLOAT:left;WIDTH:265px;HEIGHT:26px">
														<uc1:circularcontrol id="CircularControl1" runat="server"></uc1:circularcontrol></div>
												</div>
											</div>
										</div>
									</div>
								</div>
								<!--div4_2 End-->
								<div>
									<div align="left"  style="width:99%;HEIGHT: 2px">
										<p align="left">
										</p>
										<p align="left">&nbsp;</p>
										<p align="left">&nbsp;</p>
									</div>
									<div  align="left"  style="HEIGHT: 2px;width:1%"></div>
								</div>
							</div>
						</div>
					</div>
					<div>
						<div class="FooterTop"><font style="FONT-SIZE: 1pt"></font>&nbsp;</div>
					</div>
					<div>
						<div >
							<uc1:footer id="Footer1" runat="server"></uc1:footer></div>
					</div>
					<div></div>
					<asp:repeater id="mnuReapeater" runat="server">
					<headertemplate>
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
			</center>
		</form></DIV>
	</body>
</html>
