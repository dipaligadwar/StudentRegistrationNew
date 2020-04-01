<%@ OutputCache Duration="14400" Location="Server" VaryByParam="*" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrgStrControl" Src="OrgStrControl.ascx" %>
<%@ Page language="c#" Codebehind="Content.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.Content" enableViewState="False"%>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>
			<%=Classes.clsGetSettings.Name%>
			|
			<%=PageTitle%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<link href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
	</head>
	<body leftmargin="0" topmargin="0" rightmargin="0">
		<form>
			<div id="table1" style="MARGIN-TOP: 5px;MARGIN-LEFT: 50px;WIDTH: 900px;BORDER-COLLAPSE: collapse">
				<!-- div style="WIDTH:100%"></div -->
				<div style="WIDTH:100%;HEIGHT:10px">
					<uc1:header id="UCHeader" runat="server"></uc1:header>
				</div>
				<div id="dv_3" style="MARGIN-TOP:5px;WIDTH:100%">
					<div style="FLOAT:left;WIDTH:170px">
						<uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol>
						<input type="hidden" runat="server" id="hid_MenuID" name="hid_MenuID"> <input type="hidden" runat="server" id="hid_Page" name="hid_Page">
					</div>
					<div style="FLOAT:left;WIDTH:700px;HEIGHT:380px">
						<div style="WIDTH:100%; HEIGHT:336px;Padding-Left:5px" id="dv3_2">
							<div style="WIDTH:100%; HEIGHT:264px" align="left">
								<uc1:orgstrcontrol id="OrgStrControl1" runat="server"></uc1:orgstrcontrol><br>
								<br>
								<asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" cssclass="llblContentTitle"></asp:label><br>
								<br>
								<asp:label id="InnerContent" style="TEXT-ALIGN: justify" runat="server"></asp:label>
								<br>
								<asp:label id="lblUpdationDate" runat="server"></asp:label>
							</div>
						</div>
					</div>
				</div>
				<div style="WIDTH:100%">
					<uc1:footer id="Footer1" runat="server"></uc1:footer></TD>
				</div>
			</div>
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
		</asp:repeater>
			<div></div>
		</form>
		<div></div>
	</body>
</html>
