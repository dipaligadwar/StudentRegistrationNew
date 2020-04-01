<%@ Register TagPrefix="uc1" TagName="topMenuBar" Src="WebCtrl/topMenuBar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UniversityCalender" Src="UniversityCalender.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HomeContentControl" Src="HomeContentControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AlertsandReminders" Src="AlertsandReminders.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MessagingInbox" Src="MessagingInbox.ascx" %>
<%@ Page language="c#" Codebehind="Home.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.Home" enableViewState="False" %>
<%@ Register TagPrefix="uc1" TagName="CircularControl" Src="CircularControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerHeader" Src="InnerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SideLinks" Src="SideLinks.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=System.Configuration.ConfigurationSettings.AppSettings["Name"]%>
			| Login Home</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
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
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<!--onLoad="MM_preloadImages('images')-->
		<form id="Form1" method="post" runat="server">
			<div align=center>
				<TABLE id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
					<TR>
						<TD colSpan="4"></TD>
					</TR>
					<TR>
						<TD colSpan="4" height="10">
							<uc1:InnerHeader id="InnerHeader1" runat="server"></uc1:InnerHeader></TD>
					</TR>
					<TR>
						<TD height="5" vAlign="middle" align="center" rowSpan="1" class="FormName"><IMG height="45" src="images/CoomingSoon.gif" width="45"></TD>
						<td class="FormName">
							<asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label>
							&nbsp;<span class="WelcomeMsg">[<asp:label id="lblUpdationDate" runat="server"></asp:label>]</span>
							&nbsp;</td>
					</TR>
					<TR>
						<TD height="380" vAlign="top" class="SideLeft" width="18%">
							<P align="center">&nbsp;</P>
							<P align="center"><asp:image id="imgContainer" runat="server" Visible="False"></asp:image></P>
							<p align="center"><asp:label id="lblName" style="TEXT-ALIGN: justify" runat="server"></asp:label></p>
							<uc1:SideLinks id="SideLinks1" runat="server"></uc1:SideLinks>
							<P></P>
						</TD>
						<TD vAlign="top" width="830">
							<TABLE id="Table2" width="100%">
								<tr>
									<td height="5" colspan="2"></td>
								</tr>
								<tr>
									<td colspan="2" align="center" valign="middle">
										<table width="542">
											<TR>
												<TD colSpan="3" rowSpan="1" align="center"><asp:label id="InnerContent" style="text-align:center;" runat="server" Width="80%"></asp:label></TD>
											</TR>
											<tr>
												<td width="265">
													<uc1:MessagingInbox id="MessagingInbox1" runat="server"></uc1:MessagingInbox></td>
												<td>&nbsp;</td>
												<td width="265">
													<uc1:AlertsandReminders id="AlertsandReminders1" runat="server"></uc1:AlertsandReminders></td>
											</tr>
											<tr>
												<td colspan="3"><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
											</tr>
											<tr>
												<td width="265">
													<uc1:UniversityCalender id="UniversityCalender1" runat="server"></uc1:UniversityCalender></td>
												<td>&nbsp;</td>
												<td width="265">
													<uc1:CircularControl id="CircularControl1" runat="server"></uc1:CircularControl></td>
											</tr>
										</table>
									</td>
								</tr>
								<TR>
									<TD vAlign="top" align="left" width="99%" style="HEIGHT: 2px">
										<P align="left">
										</P>
										<P align="left">&nbsp;</P>
										<P align="left">&nbsp;</P>
									</TD>
									<TD vAlign="top" align="left" width="1%" style="HEIGHT: 2px"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<uc1:Footer id="Footer1" runat="server"></uc1:Footer></TD>
					</TR>
				</TABLE>
				<asp:repeater id="mnuReapeater" runat="server">
			<HeaderTemplate>
						<script language="javascript"> 
										
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
				</HeaderTemplate>			
		</asp:repeater></div>
		</form>
	</body>
</HTML>
