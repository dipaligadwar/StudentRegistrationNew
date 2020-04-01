<%@ Page language="c#" Codebehind="StatusComplaint.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.StatusComplaint" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
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
		<form id="Form1" name="StatusComplaint" method="post" runat="server">
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
							<TABLE cellSpacing="3" width="100%">
								<TR>
									<TD align="left" colSpan="4" height="14">
										<asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle">Complaint Status</asp:label></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="4" height="14"></TD>
								</TR>
								<TR width="100%">
									<TD align="center" colSpan="4" height="14">
										<asp:label Font-Size="11pt" id="lblInformation" runat="server" Width="99%" Font-Bold="True"></asp:label></TD>
								</TR>
							</TABLE>
							<asp:panel id="PnlComplaintDetails" Visible="true" Runat="server">
								<TABLE id="Table3" cellSpacing="3" width="100%" runat="server">
									<TR>
										<TD align="center" width="80%">
											<FIELDSET style="WIDTH: 95%"><LEGEND class="legendTitlePreLog">Complainer Details</LEGEND>
												<TABLE id="tblComplainerDetail" width="100%" runat="server">
													<TR>
														<TD align="right" width="25%">Name:</TD>
														<TD width="25%"></TD>
														<TD align="right" width="25%">Email ID:</TD>
														<TD width="25%"></TD>
													</TR>
													<TR>
														<TD align="right" width="25%">Telephone:</TD>
														<TD width="25%"></TD>
														<TD align="right" width="25%">Mobile:</TD>
														<TD width="25%"></TD>
													</TR>
												</TABLE>
											</FIELDSET>
										</TD>
									</TR>
									<TR>
										<TD align="center" width="80%">
											<FIELDSET style="WIDTH: 95%"><LEGEND class="legendTitlePreLog">Complaint Details</LEGEND>
												<TABLE id="tblComplaintDetail" width="100%" runat="server">
													<TR>
														<TD style="HEIGHT: 16px" vAlign="top" align="right" width="25%">Number:</TD>
														<TD width="75%"></TD>
													</TR>
													<TR>
														<TD align="right" width="25%">Subject:</TD>
														<TD width="75%"></TD>
													</TR>
													<TR>
														<TD align="right" width="25%">Reference No:</TD>
														<TD width="75%"></TD>
													</TR>
													<TR>
														<TD vAlign="top" align="right" width="25%">Complaint Details:</TD>
														<TD width="75%"></TD>
													</TR>
												</TABLE>
											</FIELDSET>
										</TD>
									</TR>
									<TR>
										<TD align="center" width="80%">
											<FIELDSET style="WIDTH: 95%"><LEGEND class="legendTitlePreLog">Complaint Redressal 
													Details</LEGEND>
												<TABLE id="tblRedressal" width="100%" runat="server">
													<TR>
														<TD align="right" width="25%">Status:</TD>
														<TD width="75%"></TD>
													</TR>
													<TR>
														<TD vAlign="top" align="right" width="25%">Remarks:</TD>
														<TD width="75%"></TD>
													</TR>
												</TABLE>
											</FIELDSET>
										</TD>
									</TR>
								</TABLE>
							</asp:panel></td>
						</TD>
						<td vAlign="top" align="left" width="1%"></td>
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
