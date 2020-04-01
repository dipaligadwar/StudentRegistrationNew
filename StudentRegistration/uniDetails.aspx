<%@ Page language="c#" Codebehind="uniDetails.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.uniDetails" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
			| College Details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<script language="javascript">
		
			//Set value to given field
			function setValue(Text,Value)
			{
				var text = eval(document.getElementById(Text));
				text.value = Value;
				//alert(Value);
			}
			
			//Fill District
			function FillDistricts(StateID,LangFlag,TargetDropDownName)
			{				
					var strxml = "<State_ID>"+StateID+"</State_ID>";   
					strxml += "	<Lang_Flag>"+LangFlag+"</Lang_Flag>";					 
					var dropDownName=document.getElementById(TargetDropDownName);
					XMLSP(dropDownName,"GEN_stateWiseDistricts",strxml,"Y");
			}
			
			function fnImageDetails(ImagePath)
			{
				//window.open("Image.aspx?ImagePath="+ImagePath,'_blank',"width=400, height=400,left=10, top=50, resizable = yes, scrollbars = yes");
				window.open(ImagePath,'_blank',"width=400, height=400,left=10, top=50, resizable = yes, scrollbars = yes");
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
						<td align="left" colSpan="4" height="10">
							<table border="0" width="100%" id="table1">
								<tr>
									<td rowspan="2" width="2%"><IMG src="Images/logo.jpg" width="60" border="0" height="60"></td>
									<td class="logoName" valign="bottom"><%=UniversityPortal.clsGetSettings.Name%></td>
								</tr>
								<tr>
									<td class="lblAddress" valign="top"><%=UniversityPortal.clsGetSettings.Address%></td>
								</tr>
							</table>
						</td>
						</TD>
					</tr>
					<tr>
						<td colSpan="4" height="5"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px; HEIGHT: 58px" vAlign="top"></td>
						<td vAlign="top" width="830" height="450">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<p align="left"><asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label></p>
									</td>
									<td vAlign="top" align="left" width="1%"></td>
								</tr>
							</table>
							<!-- Main Starts -->
							<p style="MARGIN-TOP: 5px; MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px" align="left">&nbsp;</p>
							<!-- Location Search Starts -->
							<table id="tblDetails" style="DISPLAY: inline" cellSpacing="0" cellPadding="0" width="100%"
								border="0" runat="server">
								<TBODY>
									<tr>
										<td vAlign="top" align="right" width="20%" height="25"><B>College Name</B></td>
										<td vAlign="top" align="center" width="1%" height="25"><B>:</B></td>
										<td width="69%" height="25"><asp:label id="lblCollegeName" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Parent Body</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblParentBodyName" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Minority Status</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblMinorityStatus" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Establishment Date</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblEstablishmentDate" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Area of Location</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>College Code</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblCollegeCode" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Affiliation Code</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblAffiliationCode" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td colSpan="4">&nbsp;</td>
									</tr>
									<tr>
										<td vAlign="top" align="right"><b>Address</b></td>
										<td vAlign="top" align="center"><b>:</b></td>
										<td><asp:label id="lblAddress" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td style="HEIGHT: 10px" colSpan="4">
											<hr width="100%" color="#000000" SIZE="1">
										</td>
									</tr>
									<tr>
										<td style="HEIGHT: 25px" align="left" colSpan="4"><b>Contact Details:</b></td>
									</tr>
									<tr>
										<td style="HEIGHT: 10px" colSpan="4">
											<hr width="100%" color="#000000" SIZE="1">
										</td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Phone 1</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblPhone1" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Phone 2</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblPhone2" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Fax</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblFax" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Email Id 1</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblEmail1" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Email Id 2</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblEmail2" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Email Id 3</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblEmail3" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Website Address</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblWebAddr" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Nearest Bus Station</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblBusStat" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Nearest Railway Station</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblRailStat" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td vAlign="top" align="right" height="25"><b>Nearest Airport</b></td>
										<td vAlign="top" align="center" height="25"><b>:</b></td>
										<td height="25"><asp:label id="lblAirport" runat="server" Height="20px" Width="524px"></asp:label></td>
									</tr>
									<tr>
										<td align="left" colSpan="4" height="25"><b>Accreditation Status:</b></td>
									</tr>
									<tr>
										<td colSpan="4"><asp:datagrid id="dgData" runat="server" Width="100%" BorderColor="#003300" AllowPaging="True"
												AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="10pt" AllowSorting="True">
												<HeaderStyle Font-Size="10pt" Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
												<Columns>
													<asp:BoundColumn HeaderText="Sr. No">
														<HeaderStyle Font-Size="8pt" Font-Bold="True" HorizontalAlign="Center" Width="7%"></HeaderStyle>
														<ItemStyle Font-Size="8pt" HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Accr_Name" HeaderText="Accreditation Received">
														<HeaderStyle Font-Size="8pt" Font-Bold="True" HorizontalAlign="Left" Width="20%"></HeaderStyle>
														<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="AccreditationBody" HeaderText="Accreditation Body">
														<HeaderStyle Font-Size="8pt" Font-Bold="True" HorizontalAlign="Center" Width="25%"></HeaderStyle>
														<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="InstAccr_Date" HeaderText="Date">
														<HeaderStyle Font-Size="8pt" Font-Bold="True" HorizontalAlign="Center" Width="20%"></HeaderStyle>
														<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="InstAccr_Image" HeaderText="Certificate Image">
														<HeaderStyle Font-Size="8pt" Font-Bold="True" HorizontalAlign="Center" Width="35%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></td>
									</tr>
									<tr>
										<td align="left" colSpan="4" height="25"><b>Courses:</b></td>
									</tr>
									<tr>
										<td colSpan="4"><asp:datagrid id="dgCourse" runat="server" Width="100%" BorderColor="#003300" AllowPaging="True"
												AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="10pt" AllowSorting="True">
												<HeaderStyle Font-Size="10pt" Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
												<Columns>
													<asp:BoundColumn HeaderText="Sr. No">
														<HeaderStyle Font-Size="8pt" Font-Bold="True" HorizontalAlign="Center" Width="7%"></HeaderStyle>
														<ItemStyle Font-Size="8pt" HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Courses" HeaderText="Courses">
														<HeaderStyle Font-Size="8pt" Font-Bold="True" HorizontalAlign="Left" Width="50%"></HeaderStyle>
														<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CrMoLrn_Code" HeaderText="Course Code">
														<HeaderStyle Font-Size="8pt" Font-Bold="True" HorizontalAlign="Center" Width="45%"></HeaderStyle>
														<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></td>
									</tr>
					</tr>
				</table>
				<!-- Location Search Ends -->
				<!-- Parent Search Starts -->
				<!-- Parent Search Ends -->
				<!-- Main Ends --> </TD></TR>
				<tr>
					<td colSpan="3"><INPUT id="hidUniID" style="WIDTH: 41px; HEIGHT: 22px" type="hidden" size="1" name="hidUniID"
							runat="server"></td>
				</tr>
				<tr>
					<td colSpan="3"></td>
				</tr>
				</TBODY></TABLE><asp:repeater id="mnuReapeater" runat="server">
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
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</form>
	</body>
</HTML>
