<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="programTypeWiseCourses.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.programTypeWiseCourses" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Classes.clsGetSettings.Name%>
			| Program Type Wise Courses</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table id="table2" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
					<TBODY>
						<tr>
							<td colSpan="4"></td>
						</tr>
						<tr>
							<td colSpan="4" height="10"><uc1:header id="Header1" runat="server"></uc1:header></td>
						</tr>
						<tr>
							<td height="5" colspan="4"></td>
						</tr>
						<tr>
							<td vAlign="top" style="WIDTH: 170px">
								<uc1:InnerMenuControl id="UCInnerMenuControl" runat="server"></uc1:InnerMenuControl>
							</td>
							<td width="830" valign="top">
								<table width="100%">
									<TBODY>
										<tr>
											<td width="99%" valign="top" align="left">
												<p align="left">
													<asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label>
												</p>
												<table id="table1" style="BORDER-COLLAPSE: collapse" width="100%" border="0">
													<tr>
														<td colSpan="3"><STRONG>Program Type Wise Course(s)</STRONG></td>
													</tr>
													<tr>
														<td width="50%">
															<p align="right"><b>Select Program Type </b>
															</p>
														</td>
														<td width="1%"><b>:</b></td>
														<td>
															<p align="left"><asp:dropdownlist id="ddl_ProgramType_Desc" runat="server" Width="248px"></asp:dropdownlist></p>
														</td>
													</tr>
													<tr>
														<td colSpan="3">&nbsp;</td>
													</tr>
													<tr>
														<td colSpan="3">
															<p align="center"><asp:button id="btnSubmit" runat="server" Text="Show List"></asp:button></p>
														</td>
													</tr>
												</table>
												<P align="center"><asp:label id="lblNote" runat="server" Font-Bold="True"></asp:label><br>
													<br>
													<asp:datagrid id="dgData" runat="server" Width="99%" BorderColor="DarkGray" BorderWidth="1px"
														BorderStyle="Solid" AllowPaging="True" AutoGenerateColumns="False">
														<HeaderStyle BackColor="#E0E0E0"></HeaderStyle>
														<Columns>
															<asp:BoundColumn HeaderText="Sr.No.">
																<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CourseName" HeaderText="Course Name">
																<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CrL_Desc" HeaderText="Course Level">
																<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CrMoLrnPtrn_Duration" HeaderText="Duration (in months)">
																<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></P>
												<P>
													<asp:label id="lblUpdationDate" runat="server"></asp:label>
												</P>
											</td>
											<td width="1%" valign="top" align="left">
												<uc1:sublinkusercontrol id="UCSubLink" runat="server"></uc1:sublinkusercontrol>
											</td>
										</tr>
									</TBODY>
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
					</TBODY>
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
		</form>
	</body>
</HTML>
