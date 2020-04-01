<%@ Page language="c#" Codebehind="schCrDept.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.schCrDept" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
			| College/Institute wise Course Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<script language="javascript">
		function setValue(Text,Value)
			{
				var text = eval(document.getElementById(Text));
				text.value = Value;
			}
			
		function fnDetails(uu,ff,cc,mm,pp)
			{
				var SitePath = '<%=UniversityPortal.clsGetSettings.SitePathCourse%>';
				window.open(SitePath+"uniGetCourseDetails.aspx?u="+uu+"&f="+ff+"&c="+cc+"&m="+mm+"&p="+pp,null,"width=800, height=400,left=100, top=200, resizable = yes, scrollbars = yes");
			}
			
		function newWindow()
		{	
			var sInstID=document.getElementById("hidInstID").value;
			if(sInstID!="" && sInstID!="0")
			{
				var url="schCrDept_print.aspx?InstID="+sInstID;
				window.open(url,'','toolbar=no,resizable=yes,location=no,scrollbars=yes,status=yes,width=950,height=650');
			}
			else
				alert("Select a Department.");
				
				document.getElementById("hlPrint").style.display="none";
		}
		
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<p style="MARGIN: 0px" align="center">
				<table style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2" width="900"
					border="0">
					<tr>
						<td colSpan="4"></td>
					</tr>
					<tr>
						<td colSpan="4" height="10"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td colSpan="4" height="5"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px; HEIGHT: 58px" vAlign="top"><uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol></td>
						<td vAlign="top" width="830" height="450">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<p align="left"><asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label></p>
									</td>
									<td vAlign="top" align="left" width="1%"><uc1:sublinkusercontrol id="UCSubLink" runat="server"></uc1:sublinkusercontrol></td>
								</tr>
							</table>
							<!-- Main Starts -->
							<p style="MARGIN-TOP: 10px; MARGIN-BOTTOM: 10px; MARGIN-LEFT: 5px" align="left">&nbsp; 
								<!-- Search Starts -->
								<table cellSpacing="0" cellPadding="0" width="100%" border="0">
									<tr>
										<td align="right" width="30%"><B>Select Department</B>
										</td>
										<td align="center" width="1%"><B>:</B></td>
										<td width="69%"><asp:dropdownlist id="Inst_ID" runat="server" CssClass="selectBoxHome" Width="424px" OnBlur="setValue('hidInstID',this.value)"></asp:dropdownlist></td>
									</tr>
								</table>
								<!-- Search Ends --></p>
							<p style="MARGIN-TOP: 5px; MARGIN-BOTTOM: 5px" align="center"><asp:button id="btnSearch" runat="server" CssClass="ButSp" Text="Search"></asp:button></p>
							<table>
								<tr>
									<TD align="left" width="10%"><a id="hlPrint" runat="server" onclick="newWindow();" onmouseover="this.style.cursor='Hand'"
											onmouseout="this.style.cursor='Arrow'" style="FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #666666; FONT-FAMILY: Verdana; TEXT-DECORATION: underline">
											Print Report</a>
									</TD>
								</tr>
							</table>
							<br>
							<asp:label id="lblData" runat="server"></asp:label>
							<!-- Main Ends --></td>
					</tr>
					<tr>
						<td colSpan="3"></td>
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
		</asp:repeater></p>
			<INPUT id="hidInstID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="hidInstID"
				runat="server"> <INPUT id="hidUniID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="hidUniID"
				runat="server">
		</form>
	</body>
</HTML>
