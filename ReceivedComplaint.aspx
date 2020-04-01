<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="ReceivedComplaint.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.ReceivedComplaint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Classes.clsGetSettings.Name%>
			| </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="jscript/jscript_validations.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" name="RegisterComplaint" method="post" runat="server">
			<CENTER>
				<table id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
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
						<td style="WIDTH: 170px" vAlign="top">
							<uc1:InnerMenuControl id="UCInnerMenuControl" runat="server"></uc1:InnerMenuControl>
						</td>
						<td vAlign="top" width="830">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<!-- Form design Begins here  -->
										<TABLE id="Table3" cellSpacing="3" width="100%" runat="server">
											<TR>
												<TD align="left" width="80%">
													<asp:label id="lblComplaintReceived" runat="server" Height="16px" Width="99%" CssClass="lblPageHead"></asp:label></TD>
											</TR>
											<TR>
												<TD align="left" width="80%" height="8"></TD>
											</TR>
											<tr id="trLabels" runat="server" style="DISPLAY:inline">
												<td>
													<table cellSpacing="3" width="100%">
														<TR>
															<TD align="left" width="80%">
																<asp:label id="lblMessage" runat="server" Height="16px" Width="99%" CssClass="ComplaintMessageHeading"></asp:label></TD>
														</TR>
														<TR>
															<TD align="left" width="80%" height="8"></TD>
														</TR>
														<TR>
															<TD align="left" width="80%">
																<asp:label id="lblNote" runat="server" Height="16px" Width="99%" CssClass="ComplaintMessageNote"></asp:label></TD>
														</TR>
														<TR>
															<TD align="left" width="80%" height="10"></TD>
														</TR>
													</table>
												</td>
											</tr>
											<TR>
												<TD align="center" width="80%">
													<FIELDSET style="WIDTH: 95%"><LEGEND class="legendTitle"><asp:label id="lblComplainerDetail" runat="server" CssClass="legendTitle">Complainer Details</asp:label></LEGEND>
														<TABLE id="tblComplainerDetail" runat="server" width="100%">
															<TR>
																<TD valign="top" align="right" width="25%" style="HEIGHT: 14px">Name:</TD>
																<TD valign="top" width="25%" style="HEIGHT: 14px"></TD>
																<TD valign="top" align="right" width="25%" style="HEIGHT: 14px">Email ID:</TD>
																<TD valign="top" width="25%" style="HEIGHT: 14px"></TD>
															</TR>
															<TR>
																<TD valign="top" align="right" width="25%">Telephone:</TD>
																<TD valign="top" width="25%"></TD>
																<TD valign="top" align="right" width="25%">Mobile:</TD>
																<TD valign="top" width="25%"></TD>
															</TR>
														</TABLE>
													</FIELDSET>
												</TD>
											</TR>
											<TR>
												<TD align="center" width="80%">
													<FIELDSET style="WIDTH: 95%"><LEGEND class="legendTitle"><asp:label id="lblComplaintDetail" runat="server" CssClass="legendTitle">Complaint Details</asp:label></LEGEND>
														<TABLE id="tblComplaintDetail" runat="server" width="100%">
															<TR>
																<TD valign="top" align="right" width="25%">Subject Type:</TD>
																<TD valign="top" width="75%"></TD>
															</TR>
															<TR>
																<TD valign="top" align="right" width="25%" style="HEIGHT: 14px">Subject:</TD>
																<TD valign="top" width="75%" style="HEIGHT: 14px"></TD>
															</TR>
															<TR>
																<TD valign="top" align="right" width="25%">Reference No:</TD>
																<TD valign="top" width="75%"></TD>
															</TR>
															<TR>
																<TD valign="top" align="right" width="25%">Complaint Details:</TD>
																<TD valign="top" width="75%"></TD>
															</TR>
														</TABLE>
													</FIELDSET>
												</TD>
											</TR>
										</TABLE>
										<P><asp:label id="lblUpdationDate" runat="server"></asp:label><INPUT id="hid_User_ID" type="hidden" size="1" name="hid_User_ID" runat="server"></P>
									</td>
									<td vAlign="top" align="left" width="1%"></td>
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
		</form>
	</body>
</HTML>
