<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrgStrControl" Src="OrgStrControl.ascx" %>
<%@ Page language="c#" Codebehind="Suggestions.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.Suggestions" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Classes.clsGetSettings.Name%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<script language="javascript" src="JS/header.js"></script>
		<script language="javascript" src="JS/footer.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="JS/change.js"></script>
		<script language="javascript">
			function fnSaveValidate()
			{
				var i=-1;
				var myArr= new Array();	
				
				myArr[++i]= new Array(document.getElementById("txtEmail"),"Empty","Enter Email ID","text");
				myArr[++i]= new Array(document.getElementById("txtEmail"),"Email","Enter Valid email ID","text");
				myArr[++i]= new Array(document.getElementById("txtName"),"Empty","Enter Your Name","text");
				myArr[++i]= new Array(document.getElementById("TxtSuggestion"),"Empty","Enter Request","text");
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
						<td style="WIDTH: 170px" vAlign="top"><uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol><INPUT id="hid_Page" style="WIDTH: 105px; HEIGHT: 22px" type="hidden" size="12" name="hid_Page"
								runat="server"><INPUT id="hid_MenuID" style="WIDTH: 105px; HEIGHT: 22px" type="hidden" size="12" name="hid_MenuID"
								runat="server">
						</td>
						<td vAlign="top" width="830">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<p align="left"><uc1:orgstrcontrol id="OrgStrControl1" runat="server"></uc1:orgstrcontrol></p>
										<P class="llblContentTitle" align="left">Suggestions</P>
										<table cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td width="100%">
													<div id="RquestDetails" runat="server">
														<table cellSpacing="1" cellPadding="2" width="100%">
															<TBODY>
																<TR>
																	<TD align="left" colSpan="3">
																		<P align="right"><STRONG>Name</STRONG></P>
																	</TD>
																	<TD align="right">
																		<P align="left"><asp:textbox id="txtName" runat="server" Width="472px" CssClass="inputBox"></asp:textbox><STRONG><STRONG><FONT class="mandatory">*</FONT></STRONG></STRONG></P>
																	</TD>
																</TR>
																<tr id="showPatternLink" runat="server">
																	<td align="left" colSpan="3">
																		<P align="right"><STRONG>Address</STRONG></P>
																	</td>
																	<td align="right">
																		<P align="left"><asp:textbox id="txtAddress" runat="server" Width="474px" CssClass="inputBox" Height="32px" TextMode="MultiLine"></asp:textbox></P>
																	</td>
																</tr>
																<TR>
																	<TD align="left" colSpan="3">
																		<P align="right"><STRONG>Contact</STRONG> <STRONG>No</STRONG></P>
																	</TD>
																	<TD align="right">
																		<P align="left"><asp:textbox id="txtContact" runat="server" CssClass="inputBox"></asp:textbox></P>
																	</TD>
																</TR>
																<TR>
																	<TD align="left" colSpan="3">
																		<P align="right"><STRONG>Email-Id</STRONG></P>
																	</TD>
																	<TD align="right">
																		<P align="left"><asp:textbox id="txtEmail" runat="server" Width="472px" CssClass="inputBox"></asp:textbox><STRONG><STRONG><FONT class="mandatory">*</FONT></STRONG></STRONG></P>
																	</TD>
																</TR>
																<TR>
																	<TD vAlign="top" align="right" colSpan="3"><STRONG>Suggestion</STRONG>
																	</TD>
																	<TD align="right">
																		<P align="left"><asp:textbox id="TxtSuggestion" runat="server" Width="480px" CssClass="inputBox" Height="160px"
																				TextMode="MultiLine"></asp:textbox><STRONG><STRONG><FONT class="mandatory">*</FONT></STRONG></STRONG></P>
																	</TD>
																</TR>
																<tr class="off" id="trPanel" align="center">
																	<td colSpan="4"><asp:button id="btnSave" runat="server" Width="69px" CssClass="butSp" Text="Save"></asp:button>&nbsp;
																		<INPUT class="butSp" style="WIDTH: 64px; HEIGHT: 18px" type="reset" value="Reset"></td>
																</tr>
																<TR>
																	<TD colSpan="4"><STRONG>Note:</STRONG><FONT class="Mandatory">*</FONT> marked 
																		fields are mandatory.</TD>
																</TR>
																<DIV></DIV>
												</td>
											</tr>
										</table>
								</DIV>
								<tr>
									<td>
										<!-- Request Recived design-->
										<div id="RquestRecived" runat="server">
											<TABLE id="Table3" cellSpacing="3" width="100%" runat="server">
												<TR>
													<TD align="left" width="80%"><asp:label id="lblComplaintReceived1" runat="server" Width="99%" CssClass="lblPageHead" Height="16px"></asp:label></TD>
												</TR>
												<TR>
													<TD align="left" width="80%" height="8"></TD>
												</TR>
												<tr id="trLabels1" style="DISPLAY: inline" runat="server">
													<td>
														<table cellSpacing="3" width="100%">
														</table>
														<asp:label id="lblNote1" runat="server" Width="99%" CssClass="ComplaintMessageHeading" Height="16px"></asp:label></td>
												</tr>
												<TR style="DISPLAY: inline">
													<TD></TD>
												</TR>
												<TR>
													<TD align="center" width="80%">
														<FIELDSET style="WIDTH: 95%"><LEGEND class="legendTitle">Sender Details</LEGEND>
															<TABLE id="tblComplainerDetail" width="100%" runat="server">
																<TR>
																	<TD vAlign="top" align="right" width="25%"><STRONG>Name:</STRONG></TD>
																	<TD vAlign="top" width="25%"></TD>
																	<TD vAlign="top" align="right" width="25%"><STRONG>Email ID:</STRONG></TD>
																	<TD vAlign="top" width="25%"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" align="right" width="25%"><STRONG>Telephone:</STRONG></TD>
																	<TD vAlign="top" width="25%"></TD>
																	<TD vAlign="top" align="right" width="25%"></TD>
																	<TD vAlign="top" width="25%"></TD>
																</TR>
															</TABLE>
														</FIELDSET>
													</TD>
												</TR>
												<TR>
													<TD align="center" width="80%">
														<FIELDSET style="WIDTH: 95%"><LEGEND class="legendTitle">Suggestion Details</LEGEND>
															<TABLE id="tblComplaintDetail" width="100%" runat="server">
																<TR>
																	<TD style="HEIGHT: 14px" vAlign="top" align="right" width="25%"><STRONG>Suggetion:</STRONG></TD>
																	<TD style="HEIGHT: 14px" vAlign="top" width="75%"></TD>
																</TR>
															</TABLE>
														</FIELDSET>
													</TD>
												</TR>
											</TABLE>
										</div> <!-- REQUEST rECIVED dESIGN eND--></td>
								</tr>
							</table>
							<P>&nbsp;</P>
							<DIV></DIV>
						</td>
						<td vAlign="top" align="left" width="1%"><uc1:sublinkusercontrol id="UCSubLink" runat="server"></uc1:sublinkusercontrol></td>
					</tr>
				</table>
				</TD></TR>
				<tr>
					<td colSpan="3"></td>
				</tr>
				<tr>
					<td colSpan="3"><uc1:footer id="Footer1" runat="server"></uc1:footer></td>
				</tr>
				</TBODY></TABLE>
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
	</BODY>
</HTML>
