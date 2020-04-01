<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Page language="c#" Codebehind="levelWiseCourses.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.levelWiseCourses" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
			| Level Wise Courses</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function setValue(Text,Value)
			{	
				var text = eval(document.getElementById(Text));
				text.value = Value;
			}	
		function newWindow()
		{	
			var sFID=document.getElementById("hidFac_ID").value;
			var sCRLID=document.getElementById("hidCrL_ID").value;
			var sFac_Desc=document.getElementById("ddl_Fac_Desc").options[document.getElementById("ddl_Fac_Desc").selectedIndex].text;
			if(sFID!="" && sCRLID!="")
			{
				  var url="levelWiseCourses_print.aspx?Fac_ID="+sFID+"&Fac_Desc="+sFac_Desc+"&CrL_ID="+sCRLID;
				  window.open(url,'','toolbar=no,resizable=yes,location=no,scrollbars=yes,status=yes,width=950,height=650');
			}
			else
			{
				alert("Select a valid Faculty and Course Level.");
			}
			document.getElementById("hlPrint").style.display="none";
		}		
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table id="table11" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
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
								<tr>
									<td width="99%" valign="top" align="left">
										<p align="left">
											<asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label>
										</p>
										<table border="0" width="100%" id="table1" style="BORDER-COLLAPSE: collapse">
											<tr>
												<td colspan="3"><STRONG>Course Level&nbsp; and Faculty wise Course(s)</STRONG></td>
											</tr>
											<tr>
												<td width="50%">
													<p align="right"><b>Select Course Level </b>
													</p>
												</td>
												<td width="1%"><b>:</b></td>
												<td>
													<p align="left">
														<asp:DropDownList id="ddl_CourseLevel_Desc" runat="server" Width="248px" onblur="setValue('hidCrL_ID',this.value)"></asp:DropDownList></p>
												</td>
											</tr>
											<tr>
												<td width="50%">
													<p align="right"><b>Select Faculty Name </b>
													</p>
												</td>
												<td width="1%"><b>:</b></td>
												<td>
													<p align="left">
														<asp:DropDownList id="ddl_Fac_Desc" runat="server" Width="248px" onblur="setValue('hidFac_ID',this.value)"></asp:DropDownList></p>
												</td>
											</tr>
											<tr>
												<td colspan="3">&nbsp;</td>
											</tr>
											<tr>
												<td colspan="3">
													<p align="center">
														<asp:Button id="btnSubmit" runat="server" Text="Show List"></asp:Button></p>
												</td>
											</tr>
										</table>
										<table>
											<tr>
												<TD align="left" width="10%"><a id="hlPrint" runat="server" onclick="newWindow();" onmouseover="this.style.cursor='Hand'"
														onmouseout="this.style.cursor='Arrow'" style="FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #666666; FONT-FAMILY: Verdana; TEXT-DECORATION: underline">
														Print Report</a><br>
													<asp:Label ID="lblMsg" Runat="server"></asp:Label>
												</TD>
											</tr>
										</table>
										<br>
										<P align="center">
											<asp:Label id="lblNote" runat="server" Font-Bold="True"></asp:Label><br>
											<br>
											<asp:DataGrid id="dgData" runat="server" Width="99%" AutoGenerateColumns="False" AllowPaging="True"
												BorderStyle="Solid" BorderWidth="1px" BorderColor="DarkGray">
												<HeaderStyle BackColor="#E0E0E0"></HeaderStyle>
												<Columns>
													<asp:BoundColumn HeaderText="Sr.No.">
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CourseName" HeaderText="Course Name">
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="PrgTy_Desc" HeaderText="Program Type">
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CrMoLrnPtrn_Duration" HeaderText="Duration (in months)">
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid>
										</P>
										<P>
											<asp:label id="lblUpdationDate" runat="server"></asp:label>
										</P>
									</td>
									<td width="1%" valign="top" align="left">
										<uc1:sublinkusercontrol id="UCSubLink" runat="server"></uc1:sublinkusercontrol>
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
		</asp:repeater></CENTER>
			<input id="hidFac_ID" type="hidden" runat="server" value="0" NAME="hidFac_ID"> <input id="hidCrL_ID" type="hidden" runat="server" value="0" NAME="hidCrL_ID">
		</form>
	</body>
</HTML>
