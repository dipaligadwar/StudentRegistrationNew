<%@ Register TagPrefix="uc2" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mnuMedia" Src="mnuMedia.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mnuActivitiesServices" Src="mnuActivitiesServices.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mnuIPRPublication" Src="mnuIPRPublication.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerHeader" Src="InnerHeader.ascx" %>
<%@ Page language="c#" Codebehind="MySettings.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.MySettings" %>
<%@ Register TagPrefix="uc1" TagName="topMenuBar" Src="WebCtrl/topMenuBar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UniversityMenu" Src="UniversityMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mnuAcademics" Src="mnuAcademics.ascx" %>
<%@ Register TagPrefix="uc2" TagName="AdminHeader" Src="Admin/AdminHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SideLinks" Src="SideLinks.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
			| Administrator</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="../jscript/jscript_validations.js"></script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function setEmailID()
			{
				var txt = document.forms[0].Email_ID;
				if(document.forms[0].Auto_forward[0].checked)
				{
					txt.disabled=false;
					txt.focus();
				}	
				else
				{
					txt.value='';
					txt.disabled=true;
				}
			}
			function validMe()
			{
				if(document.forms[0].Auto_forward[0].checked)
				{
					var i=-1;
					var myArr= new Array();
					myArr[++i]= new Array(document.getElementById("<%= Email_ID.ClientID %>"),"Empty","Enter E-mail ID.","text");
					myArr[++i]= new Array(document.getElementById("<%= Email_ID.ClientID %>"),"Email","E-mail ID is not valid.","text");
					var ret=validateMe(myArr,50);
					return ret;
				}
			}		
			function changePassword(val)
			{
				var oldpass = document.getElementById("<%= oldPassword.ClientID %>").value;
				var newpass = document.getElementById("<%= newPassword.ClientID %>").value;
				var conpass = document.getElementById("<%= conPassword.ClientID %>").value;
					if(oldpass.toUpperCase()==val)
					{
						var j=-1;
						var myArr= new Array();
						myArr[++j]= new Array(document.getElementById("<%= newPassword.ClientID %>"),"Empty","Enter new password.","text");
						var ret=validateMe(myArr,50);
						if(ret)
						{
							
							if(newpass==conpass)
							{
								return ret;
							}
							else
							{
									alert('Please confirm new password.');
									document.getElementById("<%= conPassword.ClientID %>").value='';
									document.getElementById("<%= conPassword.ClientID %>").focus();
									return false;
							}
						}
						else
						{
							document.getElementById("<%= newPassword.ClientID %>").focus();
							return false;
						}
						
					}	
					else
					{
						alert('Old Password is not valid.')
						document.getElementById("<%= oldPassword.ClientID %>").value='';
						document.getElementById("<%= oldPassword.ClientID %>").focus();
						return false;
					}
			
			}	
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
					<TR>
						<TD colSpan="4"></TD>
					</TR>
					<TR>
						<TD colSpan="4" height="10">
							<uc1:InnerHeader id="InnerHeader1" runat="server"></uc1:InnerHeader></TD>
					</TR>
					<tr height="15">
						<td class="FormName" vAlign="middle" align="center" width="20%"><IMG height="45" src="images/CoomingSoon.gif" width="45"></td>
						<TD class="FormName" vAlign="middle" align="left"><asp:label id="lblTitle" runat="server" Width="99%" Font-Bold="True"><font class="PageHeading">
									<b>My Settings</b></font></asp:label></TD>
					</tr>
					<TR height="380">
						<TD style="HEIGHT: 395px" vAlign="top" width="18%" class="SideLeft">
							<uc1:SideLinks id="SideLinks1" runat="server"></uc1:SideLinks>
						</TD>
						<TD style="HEIGHT: 395px" vAlign="top">
							<!-- Form  Contents -->
							<!-- Toolbar Starts-->
							<table cellSpacing="1" cellPadding="0" width="100%" border="0" id="Table2">
								<tr>
									<td>
										<p style="MARGIN: 2px 0px" align="left">
										<!--table class="ToolBar" id="table15" cellSpacing="1" cellPadding="0" width="100%" border="0">
												<tr>
													<td align="center" width="10%"><IMG height="16" src="images/button_new.gif" width="16" border="0">
														<asp:button id="btnNew" runat="server" CssClass="But" Text="New"></asp:button></td>
													<td align="center" width="10%"><IMG height="16" src="images/button_save.gif" width="16" border="0">
														<asp:button id="Button1" runat="server" CssClass="But" Text="Save"></asp:button></td>
													<td align="center" width="10%"><IMG height="16" src="images/button_delete.gif" width="16" border="0">
														<asp:button id="btnDelete" disabled runat="server" CssClass="But" Text="Delete"></asp:button></td>
													<!--<td align="center" width="10%"><IMG height="16" src="images/button_close.gif" width="16" border="0">
																<asp:button id="btnClose" runat="server" CssClass="But" Text="Close"></asp:button></td></p></p>
									<td align="center" width="7%">&nbsp;</td>
									<td align="center" width="10%"><IMG height="16" src="images/button_reset.gif" width="16" border="0"><input class="But" title="Reset" accessKey="R" tabIndex="4" type="reset" value="Reset"
											name="Reset"></td>
									<td align="right">&nbsp;</td>
								</tr>
							</table>-->
										<P>&nbsp;</P>
									</td>
								</tr>
							</table>
							<!--p style="MARGIN: 0px 5px" align="right"><asp:label id="lblNote" runat="server" CssClass="saveNote" Height="15px"></asp:label></p>-->
							<!-- Toolbar Ends-->
							<!-- Entry Area Starts-->
							<table style="BORDER-COLLAPSE: collapse" cellSpacing="2" cellPadding="0" width="100%" border="0"
								id="Table3">
								<tr>
									<td vAlign="top" align="center">
										<fieldset style="WIDTH: 500px"><legend class="fontbold">Auto Forward</legend>
											<TABLE cellSpacing="1" cellPadding="0" width="100%" border="0" id="Table5">
												<TR>
													<TD class="fontbold" align="right" colSpan="3">
														<P align="center"><asp:label id="lblMsg" runat="server" CssClass="message"></asp:label></P>
													</TD>
												</TR>
												<TR>
													<TD class="fontbold" style="WIDTH: 175px" align="right">Auto Forward</TD>
													<TD class="fontbold" align="center" width="2%">:</TD>
													<TD align="left"><asp:radiobuttonlist id="Auto_forward" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0"
															Width="100px">
															<asp:ListItem Value="Y">Yes</asp:ListItem>
															<asp:ListItem Value="N" Selected="True">No</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD class="fontbold" align="right">E-mail ID</TD>
													<TD class="fontbold" align="center" width="2%">:</TD>
													<TD align="left">&nbsp;<asp:textbox id="Email_ID" runat="server" CssClass="InputBox" Width="200px" Enabled="False"></asp:textbox></TD>
												</TR>
												<tr>
													<td vAlign="middle" align="center" colSpan="3" height="30"><asp:button id="btnSave" runat="server" CssClass="butSubmitt" Width="55px" Text="Save"></asp:button>&nbsp;&nbsp;
														<INPUT class="butSubmitt" type="reset" value="Reset">
													</td>
												</tr>
											</TABLE>
										</fieldset>
									</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
										<fieldset style="WIDTH: 500px"><legend class="fontbold">Change Password</legend>
											<TABLE cellSpacing="1" cellPadding="0" width="100%" border="0" id="Table6">
												<TR>
													<TD class="fontbold" style="HEIGHT: 12px" align="right" colSpan="3">
														<P align="center"><asp:label id="lblMessage" runat="server" CssClass="message"></asp:label></P>
													</TD>
												</TR>
												<TR>
													<TD class="fontbold" style="WIDTH: 175px" align="right">Old&nbsp;Password</TD>
													<TD class="fontbold" align="center" width="2%">:</TD>
													<TD align="left"><asp:textbox id="oldPassword" runat="server" CssClass="InputBox" Width="153px" TextMode="Password"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="fontbold" style="WIDTH: 175px" align="right">New Password</TD>
													<TD class="fontbold" align="center" width="2%">:</TD>
													<TD align="left"><asp:textbox id="newPassword" runat="server" CssClass="InputBox" Width="153px" TextMode="Password"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="fontbold" style="WIDTH: 175px; HEIGHT: 12px" align="right">Re-enter&nbsp;Password</TD>
													<TD class="fontbold" style="HEIGHT: 12px" align="center" width="2%">:</TD>
													<TD style="HEIGHT: 12px" align="left"><asp:textbox id="conPassword" runat="server" CssClass="InputBox" Width="153px" TextMode="Password"></asp:textbox></TD>
												</TR>
												<tr>
													<td vAlign="middle" align="center" colSpan="3" height="30"><asp:button id="btnSavePassword" runat="server" CssClass="butSubmitt" Width="55px" Text="Save"></asp:button>&nbsp;&nbsp;
														<INPUT class="butSubmitt" type="reset" value="Reset">
													</td>
												</tr>
											</TABLE>
										</fieldset>
									</td>
								</tr>
							</table>
						</TD>
					</TR>
				</TABLE>
				</TD></TR>
				<TR>
					<TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					<uc2:Footer id="Footer1" runat="server"></uc2:Footer>
				</TR>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
				</TABLE>
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
