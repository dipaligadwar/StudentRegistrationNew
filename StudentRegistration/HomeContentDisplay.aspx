<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DefaultHeader" Src="DefaultHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="HomeContentDisplay.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.HomeContentDisplay" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title> <%=UniversityPortal.clsGetSettings.Name%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form>
			<CENTER>
				<table id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
					<tr>
						<td colSpan="4"></td>
					</tr>
					<tr>
						<td colSpan="4" height="10">
							<uc1:Header id="UCHeader" runat="server"></uc1:Header></td>
					</tr>
					<tr>
						<td vAlign="top" style="WIDTH: 170px">
							<uc1:InnerMenuControl id="UCInnerMenuControl" runat="server"></uc1:InnerMenuControl>
						</td>
						<td width="830" valign="top" height="380">
							<table width="100%">
								<tr>
									<td width="99%" valign="top" align="left">
										<p align="left">
											<asp:label id="lblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label>
										</p>
										<P>
											<asp:label id="InnerContent" style="TEXT-ALIGN: justify" runat="server"></asp:label>
										</P>
										<P>
											<asp:label id="lblUpdationDate" runat="server"></asp:label>
										</P>
									</td>
									<td width="1%" valign="top" align="left">
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td colSpan="3"></td>
					</tr>
					<tr>
						<td colSpan="3">
							<uc1:Footer id="Footer1" runat="server"></uc1:Footer></td>
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
		</asp:repeater>
			</CENTER>
		</form>
	</body>
</HTML>
