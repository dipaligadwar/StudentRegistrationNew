<%@ Page language="c#" AutoEventWireup="false" Inherits="SOADelivery.clsTemplateParser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>
			<%=Classes.clsGetSettings.Name%>
			| SOADelivery- Template__1 </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="JS/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<link href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
	</head>
	<body leftmargin="0" topmargin="0" rightmargin="0">
		<form id="form1" method="post" runat="server">
			<div align="center">
				<table id="table1" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="2"
					width="900">
					<tr>
						<td colspan="5"></td>
					<tr>
						<td colspan="5" height="10">
							<!-- BEGIN : HEADER -->
							<table border="0" cellpadding="2" style="BORDER-COLLAPSE: collapse" width="900" bordercolor="#c0c0c0"
								id="table1">
								<tr>
									<td rowspan="2" width="2%">
										<img id="UcHeader1_Image1" border="0" src="Images/Logo.jpg" alt="" style="WIDTH:60px;HEIGHT:60px"></td>
									<td align="left" width="45%" valign="bottom">
										<span id="UcHeader1_lblName" class="logoName">University of Pune</span>&nbsp;</td>
									<td align="right" valign="top">
										<a id="UcHeader1_Hyperlink8" class="toplinks" href="Default.aspx">Home</a>&nbsp;|
										<a id="UcHeader1_HyperLink3" class="toplinks" href="CalendarDisplay.aspx">Calendar</a>&nbsp;|
										<a id="UcHeader1_HyperLink4" class="toplinks" href="SiteMap.aspx">Sitemap</a>&nbsp;|
										<a id="UcHeader1_HyperLink5" class="toplinks" href="ContactUs.aspx">Contact Us</a>&nbsp;
									</td>
								</tr>
								<tr>
									<td align="left" valign="top">
										<span id="UcHeader1_lblAddress" class="logoAddress">Ganeshkind, Pune - 411 007</span>&nbsp;</td>
									<td valign="middle" align="right">
										<select id="QuickLinks" class="select" onchange="getLinks(this.value);">
											<option selected>--Quick Link--</option>
											<option value='http://localhost/Content.aspx?ID=4'>Admissions</option>
											<option value='http://localhost/Coming_Soon.aspx'>Search PRN</option>
											<option value='http://localhost/Content.aspx?ID=1'>Courses</option>
											<option value='http://localhost/GR.aspx'>GR</option>
											<option value='http://localhost/Coming_Soon.aspx'>Job Opening</option>
										</select>
									</td>
								</tr>
							</table>
							<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" width="900"
								bordercolor="#c0c0c0" id="table14">
								<tr>
									<td colspan="3" align="left" height="35" background='Template_1/linkbg.gif' valign='bottom'>
										<!--
										<span id="UcHeader1_lblTopLinks"><b><font class="defaultTopLinks">&nbsp;&nbsp;&nbsp;&nbsp;»</font><a class="TopHome" href="http://localhost/Content.aspx?ID=1">Courses</a></b><b><font class="defaultTopLinks">&nbsp;&nbsp;&nbsp;&nbsp;»</font><a class="TopHome" href="http://localhost/Content.aspx?ID=2">Colleges 
													&amp; Institutions</a></b><b><font class="defaultTopLinks">&nbsp;&nbsp;&nbsp;&nbsp;»</font><a class="TopHome" href="http://localhost/Content.aspx?ID=3">Departments</a></b><b><font class="defaultTopLinks">&nbsp;&nbsp;&nbsp;&nbsp;»</font><a class="TopHome" href="http://localhost/Content.aspx?ID=4">Admissions</a></b><b><font class="defaultTopLinks">&nbsp;&nbsp;&nbsp;&nbsp;»</font><a class="TopHome" href="http://localhost/Content.aspx?ID=5">Scholarships</a></b><b><font class="defaultTopLinks">&nbsp;&nbsp;&nbsp;&nbsp;»</font><a class="TopHome" href="http://localhost/Content.aspx?ID=6">Examinations</a></b><b><font class="defaultTopLinks">&nbsp;&nbsp;&nbsp;&nbsp;»</font><a class="TopHome" href="http://localhost/Content.aspx?ID=210">Migration</a></b><b><font class="defaultTopLinks">&nbsp;&nbsp;&nbsp;&nbsp;»</font><a class="TopHome" href="http://localhost/Content.aspx?ID=631">Convocations</a></b></span>
										-->
									</td>
								</tr>
								<tr height="5">
									<td background='Template_1/middlespacer.gif'><img src='Template_1/left-corner.gif'></td>
									<td background='Template_1/middlespacer.gif' width="99%"></td>
									<td background='Template_1/middlespacer.gif' align="right" valign="bottom"><img src='Template_1/right-corner.gif'></td>
								</tr>
							</table>
							<!-- End :Header -->
						</td>
					</tr>
					<tr>
						<td valign="top" width="170">
							<span class="boxTitle"><b>:: Campus Services</b></span> <span class="boxBG">
								<asp:literal id="UniversityServices" runat="server"></asp:literal>
							</span>
							<br>
							<span class="boxTitle"><b>:: Gold-Plus Services</b></span> <span class="boxBG">
								<asp:literal id="GoldPlusServices" runat="server"></asp:literal>
							</span>
						</td>
						<td></td>
						<td valign="top" align="center" width="558" height="380">
							<table width="100%" cellpadding="1" cellspacing="1">
								<tbody>
									<tr>
										<td valign="top" align="left" colspan="2">
											<asp:literal id="C15" runat="server"></asp:literal></td>
									</tr>
									<tr>
										<td colspan="2">
											<asp:literal id="C20" runat="server"></asp:literal>
										</td>
									</tr>
									<tr>
										<td valign="top" align="left">
											<asp:literal id="C12" runat="server"></asp:literal>
											<asp:literal id="C7" runat="server"></asp:literal>
											<asp:literal id="C9" runat="server"></asp:literal>
										</td>
										<td valign="top" align="left">
											<asp:literal id="C13" runat="server"></asp:literal>
											<asp:literal id="C8" runat="server"></asp:literal>
											<asp:literal id="C14" runat="server"></asp:literal>
										</td>
									</tr>
								</tbody>
							</table>
						<td></td>
						<td valign="top" width="170">
							<div style="BORDER-RIGHT: #c0c0c0 1px solid; PADDING-RIGHT: 10px; BORDER-TOP: #c0c0c0 1px solid; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; BORDER-LEFT: #c0c0c0 1px solid; PADDING-TOP: 10px; BORDER-BOTTOM: #c0c0c0 1px solid; TEXT-ALIGN: center">
								<div style="BORDER-RIGHT:gainsboro 1px solid; BORDER-TOP:gainsboro 1px solid; BORDER-LEFT:gainsboro 1px solid; WIDTH:80px; BORDER-BOTTOM:gainsboro 1px solid; HEIGHT:80px">
									<asp:literal id="Photo" runat="server"></asp:literal>
								</div>
							</div>
							<div>
								<asp:literal id="StudentName" runat="server"></asp:literal>
							</div>
							<div>
								<asp:literal id="PRN" runat="server"></asp:literal>
							</div>
							<br>
							<div class="boxTitle"><b>:: Channels</b></div>
							<div class="boxBG">
								<asp:literal id="Channels" runat="server"></asp:literal>
							</div>
						</td>
					</tr>
					<tr>
						<td colspan="5" height="1">
							<!-- Begin : Footer -->
							<script>
								function OpenVersion()
								{
									window.open('http://localhost/'+'AssemblyVersion.aspx',null,"width=400, height=400,left=300, top=200");
								}
							</script>
							<table width="100%">
								<tr>
									<td align="center" colspan="2">
										<span id="UcFooter1_lblFooterLink"><a class='toplinks' href='http://localhost/PhotoGallary.aspx'>
												Photo Gallery</a> | <a class='toplinks' href='http://localhost/VisualTour.aspx'>
												Visual Tour</a> | <a class='toplinks' href='http://localhost/Suggestions.aspx'>Suggestion
											</a>| <a class='toplinks' href='http://localhost/RequestInfo.aspx'>Request Info</a>
											| <a href='http://localhost/RegisterComplaint.aspx' class='toplinks'>Complaints</a>
											| <a href='http://localhost/DisplayFAQ.aspx' class='toplinks'>FAQ</a> | <a class='toplinks' href='http://localhost/Disclaimer.aspx'>
												Disclaimer</a> </span>
									</td>
								</tr>
								<tr>
									<td class="logoAddress" align="center" colspan="2">Portal Definition <a class="footerLink" href="javaScript:OpenVersion();">
											Version</a> <span id="UcFooter1_lblVersion">1.0.2495.23179</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Developed 
										&amp; Powered by Maharashtra Knowledge Corporation Ltd. (<a class="footerLink" href="http://www.mkcl.org" target="_blank">MKCL</a>).</td>
								</tr>
							</table>
							<input name="UcFooter1:hid_Sitepath" id="UcFooter1_hid_Sitepath" type="hidden" size="1">
					<!-- End : Footer -->
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
										if(parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "Service_Channel_ID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>').offsetWidth)))+170 < screen.width)
										{
											sWidth = parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "Service_Channel_ID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>').offsetWidth)));
										}
										else
										{
											pos="left";
											sWidth= parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "Service_Channel_ID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>').offsetWidth)))-335;
										}			
									new ypSlideOutMenu("menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>", pos,sWidth ,parseInt(document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>').offsetTop+document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "Service_Channel_ID")%>').offsetTop),170,document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>Content')?document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>Content').offsetHeight:0);


								</ItemTemplate>
						<FooterTemplate> 
							ypSlideOutMenu.writeCSS();				
						</script>
						</FooterTemplate>			
				</asp:repeater>
				</div>
		</form>
	</body>
</html>
