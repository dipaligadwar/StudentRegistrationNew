<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrgStrControl" Src="OrgStrControl.ascx" %>
<%@ Page language="c#" Codebehind="CalendarDisplay.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.CalendarDisplay" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="css/UniPortal.css" type="text/css" rel="stylesheet"/>
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<script language="javascript" src="JS/header.js"></script>
		<script language="javascript" src="JS/footer.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="JS/change.js"></script>
		<script language="javascript" src="ajax/common.ashx"></script>
		<script language="javascript" src="ajax/UniversityPortal.CalendarDisplay,UniversityPortal.ashx"></script>
		<script>
		var sTableCellID;
			function showTR(Text)
			{
				var tRow = 'tr'+Text;
				var img = 'img'+Text;
				tRow = eval(document.getElementById(tRow));	
				img = eval(document.getElementById(img));	
							
				if(tRow.style.display == "none")
				{
					tRow.style.display = "inline";
					img.src = "Images/minus.gif";
				}
				else
				{
					tRow.style.display = "none";
					img.src = "Images/plus.gif";
				}
				
				
				
			}
			function fillMonths(location,Combo)
			{
			
				document.getElementById("hid_Year").value = Combo.value;						
				sTableCellID=location;
				CalendarDisplay.fillMonths(Combo.value, BindDataToCombo_CallBack); 
			}
			
			function BindDataToCombo_CallBack(response)
			{		
				if(response.error == null)
				{
					document.getElementById(sTableCellID).innerHTML = response.value ;
					document.getElementById("hid_Month").value = document.getElementById("cmbMonth").value;
				}			
			}	
			function setHidden(Combo)
			{
				document.getElementById("hid_Month").value = Combo.value;	
			}
			
		</script>
	</head>
	<body leftmargin="0" topmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<table id="table1" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="2"
					width="900" border="0">
					<tr>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td colspan="4" height="10"><uc1:header id="UCHeader" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td colspan="4" height="5"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px; HEIGHT: 358px" valign="top">
							<uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol><input type="hidden" runat="server" id="hid_Page" name="hid_Page"><input type="hidden" runat="server" id="hid_MenuID" name="hid_MenuID">
						</td>
						<td valign="top" width="830">
							<table width="100%">
								<tr>
									<td valign="top" align="left" width="99%">
										<p align="left">
											<uc1:orgstrcontrol id="OrgStrControl1" runat="server"></uc1:orgstrcontrol>
										</p>
										<p class="llblContentTitle" align="left"><asp:label id="lblTitle" runat="server" cssclass="llblContentTitle" font-bold="True">Calendar</asp:label></p>
										<table cellspacing="1" cellpadding="2" width="100%">
											<tr>
												<td colspan="4">
													<table width="90%" align="center">
														<tr>
															<td align="right" width="40%"><strong>Select Year:</strong></td>
															<td width="60%"><asp:dropdownlist id="cmbYear" runat="server" cssclass="SelectboxHome" width="184px" onchange="fillMonths('TDMonth',this);"></asp:dropdownlist></td>
														</tr>
														<tr>
															<td align="right" width="40%"><b>Select Month:</b></td>
															<td id="TDMonth" width="60%"><asp:dropdownlist id="cmbMonth" runat="server" cssclass="SelectboxHome" width="184px" onchange="setHidden(this);"></asp:dropdownlist></td>
														</tr>
														<tr>
															<td valign="middle" align="center" width="100%" colspan="2">
																<asp:button id="btnShow" runat="server" cssclass="ButSp" text="View Calendar"></asp:button></td>
														</tr>
														<tr>
															<td height="5" colspan="2">&nbsp;</td>
														</tr>
														<tr>
															<td id="tdCalendar" width="100%" colspan="2" runat="server">
																<asp:placeholder id="CalendarTable" runat="server"></asp:placeholder>
																<asp:label id="lblInformation" runat="server" font-bold="True"></asp:label>
															</td>
														</tr>
														<tr>
															<td width="100%" colspan="2"></td>
														</tr>
													</table>
													<table id="TbRepresents" runat="server" style="BORDER-TOP-WIDTH:0px; DISPLAY:none; BORDER-LEFT-WIDTH:0px; BORDER-BOTTOM-WIDTH:0px; BORDER-COLLAPSE:collapse; BORDER-RIGHT-WIDTH:0px"
														bordercolor="#000000" width="90%" border="1" align="center">
														<tr>
															<td bgcolor="#800000" style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; BORDER-LEFT-COLOR: #000000; BORDER-BOTTOM: 1px solid">&nbsp;</td>
															<td style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-BOTTOM: medium none">
																<b>&nbsp;Represents a Holiday.</b></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td colspan="4"><hr>
													<p class="llblContentTitle" align="left">
														<asp:label id="Label2" runat="server" font-bold="True" cssclass="llblContentTitle">Holidays</asp:label></p>
													<table id="Table2" cellspacing="1" cellpadding="2" width="100%" align="center">
														<tr>
															<td align="center" colspan="4">
																<table id="Table3" width="100%" align="center">
																	<tr>
																		<td align="center" width="60%">
																			<asp:label id="lblHolidayYear" runat="server" font-bold="True"></asp:label></td>
																	</tr>
																	<tr>
																		<td align="center" width="60%">
																			<asp:datagrid id="DG_DisplayHolidays" runat="server" width="80%" allowsorting="True" font-size="10pt"
																				font-names="Verdana" autogeneratecolumns="False">
																				<alternatingitemstyle cssclass="gridAltItemHome"></alternatingitemstyle>
																				<itemstyle cssclass="gridItemHome"></itemstyle>
																				<headerstyle font-size="10pt" horizontalalign="Center" cssclass="gridHeaderHome"></headerstyle>
																				<columns>
																					<asp:boundcolumn headertext="Sr. No">
																						<headerstyle font-size="8pt" horizontalalign="Center" width="7%" cssclass="gridHeaderHome"></headerstyle>
																						<itemstyle font-size="8pt" horizontalalign="Center"></itemstyle>
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="Event_Date" headertext="Date">
																						<headerstyle font-size="8pt" horizontalalign="Left" width="20%" cssclass="gridHeaderHome"></headerstyle>
																						<itemstyle font-size="8pt" horizontalalign="Left"></itemstyle>
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="Event_Title" headertext="Event">
																						<headerstyle font-size="8pt" horizontalalign="Center" width="30%" cssclass="gridHeaderHome"></headerstyle>
																						<itemstyle font-size="8pt" horizontalalign="Left"></itemstyle>
																					</asp:boundcolumn>
																				</columns>
																			</asp:datagrid></td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
													<p>&nbsp;</p>
												</td>
											</tr>
										</table>
										<p><asp:label id="lblUpdationDate" runat="server"></asp:label></p>
									</td>
									<td valign="top" align="left" width="1%"></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td colspan="3"></td>
					</tr>
					<tr>
						<td colspan="3"><uc1:footer id="Footer1" runat="server"></uc1:footer></td>
					</tr>
				</table>
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
		</asp:repeater></div>
			<input id="hid_Mode" style="WIDTH: 80px; HEIGHT: 22px" type="hidden"  name="hid_Mode"
				runat="server"/><input id="hidUniID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hidUniID"
				runat="server"/><input id="hidFacID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hidFacID"
				runat="server"/><input id="hidSubID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hidSubID"
				runat="server"/><input id="hid_Year" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hid_Year"
				runat="server"/><input id="hid_Month" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hid_Month"
				runat="server"/></form>
	</body>
</html>
