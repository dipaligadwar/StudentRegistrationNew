<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Page language="c#" Codebehind="SearchPortal.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.SearchPortal" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title> <%=UniversityPortal.clsGetSettings.Name%>
		</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<script language="javascript" src="JS/header.js"></script>
		<script language="javascript" src="JS/footer.js"></script>
		<script language="javascript" src="JS/change.js"></script>
		<script>
		function fnValidateSearch()
			{
				var i=-1;
				var myArr= new Array();	
				myArr[++i]= new Array(document.getElementById("txtSearch"),"Empty","Invalid search entry","text");				
				
				var ret=validateMe(myArr,50); 
				return ret;
			}
		</script>
</HEAD>
	<BODY leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
					<tr>
						<td colSpan="4"></td>
					</tr>
					<tr>
						<td colSpan="4" height="10"><uc1:header id="UCHeader" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td colSpan="4" height="5"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px" vAlign="top"><uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol></td>
						<td vAlign="top" width="830">
							<table width="100%" border="0">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<p class="llblContentTitle" align="left">Search Portal
										</p>
										<table cellSpacing="1" cellPadding="0" align="center" border="0">
											<tr>
												<td align="right"><asp:textbox id="txtSearch" runat="server" CssClass="inputBox" Width="350px"></asp:textbox></td>
												<td width="1%">&nbsp;</td>
												<td vAlign="middle"><asp:button id="btnSearchPortal" runat="server" CssClass="ButSp" Text="Search Portal"></asp:button></td>
											</tr>
											<tr>
												<td colSpan="3">&nbsp;</td>
											</tr>
											<TR height="15">
												<TD align="right" colSpan="3"><asp:label id="ResultCount" runat="server"></asp:label></TD>
											</TR>
											<tr>
												<td colSpan="3">&nbsp;</td>
											</tr>
											<tr id="SearchResults" runat="server">
												<td colSpan="3"><asp:datagrid id="SearchGrid" runat="server" Font-Size="8pt" Font-Name="Verdana" BorderWidth="0"
														CellPadding="0" CellSpacing="0" AllowPaging="true" PageSize="10" AutoGenerateColumns="false">
														<PagerStyle Mode="NumericPages" Font-Bold="true" />
														<HeaderStyle Font-Bold="true" />
														<ItemStyle VerticalAlign="top" />
														<FooterStyle BackColor="#ffffff" />
														<Columns>
															<asp:TemplateColumn HeaderText="University Portal" HeaderStyle-Font-Bold="True" HeaderStyle-CssClass="selectBoxHome">
																<ItemStyle Width="515" />
																<ItemTemplate>
																	<a href='<%# PathToVpath(DataBinder.Eval(Container, "DataItem.path"))%>' style="color=#ff0000" target=_blank>
																		<%# DataBinder.Eval(Container, "DataItem.DocTitle") %>
																	</a>
																	<br />
																	<%# DataBinder.Eval(Container, "DataItem.Characterization")%>
																	...
																	<br />
																	<a href='<%# PathToVpath(DataBinder.Eval(Container, "DataItem.path"))%>'
																			style="word-wrap: break-word; color=#000080;" target=_blank>
																		<%# PathToVpath(DataBinder.Eval(Container, "DataItem.path"))%>
																	</a>
																	<br />
																	<br />
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></td>
											</tr>
											<tr>
												<td><asp:label id="lblUpdationDate" runat="server"></asp:label></td>
												<td width="1%"></td>
												<td></td>
											</tr>
										</table>
									</td>
									<td vAlign="top" align="left" width="1%"><uc1:sublinkusercontrol id="UCSubLink" runat="server"></uc1:sublinkusercontrol></td>
								</tr>
							</table>
						</td>
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
		</asp:repeater></CENTER>
			<INPUT id="hidUniID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden1"
				runat="server"> <INPUT id="hidFacID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden3"
				runat="server"><INPUT id="hidCrID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden6"
				runat="server"><INPUT id="hidMoLrnID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden5"
				runat="server"><INPUT id="Hid_Md_Lrn_Ptrn_ID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8"
				name="Hidden5" runat="server"></form>
	</BODY>
</HTML>
