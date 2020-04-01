<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="ListOfCourses.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.ListOfCourses" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Classes.clsGetSettings.Name%>
			| List of Courses</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="jscript/newWindow.js"></script>
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
			var sPTID=document.getElementById("hidProgramType_ID").value;
			var sCRLID=document.getElementById("hidCrL_ID").value;
			if(sFID!="" && sPTID!="" && sCRLID!="")
			{
				  var url="ListOfCourses_print.aspx?FID="+sFID+"&PTID="+sPTID+"&CRLID="+sCRLID;
				  window.open(url,'','toolbar=no,resizable=yes,location=no,scrollbars=yes,status=yes,width=950,height=650');
			}
			else
			{
				alert("Select a valid Faculty, Program Type and Course Level.");
			}
			 document.getElementById("hlPrint").style.display="none";
		}		
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
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
						<td style="WIDTH: 145px" vAlign="top"><uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol></td>
						<td vAlign="top" width="830">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<p align="left"><asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label></p>
										<table id="table5" width="100%" border="0">
											<tr>
												<td colSpan="3"><STRONG>Search Course(s)</STRONG></td>
											</tr>
											<tr>
												<td align="right" width="28%"><b>Select Faculty Name </b>
												</td>
												<td width="1%"><b>:</b></td>
												<td><asp:dropdownlist id="ddl_Fac_Desc" onblur="setValue('hidFac_ID',this.value)" runat="server" Width="248px"></asp:dropdownlist></td>
											</tr>
											<tr>
												<td align="right"><b>Select Program Type </b>
												</td>
												<td width="1%"><b>:</b></td>
												<td><asp:dropdownlist id="ddl_ProgramType_Desc" onblur="setValue('hidProgramType_ID',this.value)" runat="server"
														Width="248px"></asp:dropdownlist></td>
											</tr>
											<tr>
												<td align="right"><b>Select Course Level </b>
												</td>
												<td width="1%"><b>:</b></td>
												<td><asp:dropdownlist id="ddl_CourseLevel_Desc" onblur="setValue('hidCrL_ID',this.value)" runat="server"
														Width="248px"></asp:dropdownlist></td>
											</tr>
											<tr>
												<td colSpan="3">&nbsp;</td>
											</tr>
											<tr>
												<td align="center" colSpan="3"><asp:button id="btnSubmit" runat="server" Text="Show List"></asp:button></td>
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
													<asp:BoundColumn DataField="PrgTy_Desc" HeaderText="Program Type">
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CrMoLrnPtrn_Duration" HeaderText="Duration (in months)">
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></P>
										<P><asp:label id="lblUpdationDate" runat="server"></asp:label></P>
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
			<input id="hidFac_ID" type="hidden" runat="server" value="0"> <input id="hidProgramType_ID" type="hidden" runat="server" value="0">
			<input id="hidCrL_ID" type="hidden" runat="server" value="0">
		</form>
	</body>
</HTML>
