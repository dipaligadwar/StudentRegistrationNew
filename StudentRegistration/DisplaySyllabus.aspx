<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="DisplaySyllabus.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.DisplaySyllabus" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title> <%=UniversityPortal.clsGetSettings.Name%>
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
			/*function fnSaveValidate()
			{
				var bolReturn = true;
				var ichCount = 0;	
				ichCount = checkClicked();
			    if(ichCount == 0)
				{
					alert("Please select papers from grid");
					bolReturn = false;
				}			   
				return bolReturn;
				
			}*/	
			function ValidateSearch()
			{
				var i=-1;
				var myArr= new Array();	
				myArr[++i]= new Array(document.getElementById("DD_Course_Pattern"),"0","Select Pattern","select");	
				var ret=validateMe(myArr,50); 
				return ret;
			}
			function ShowHidePatterns()
			{
				if(document.getElementById("trPanel").className=='off')
				{				
					document.getElementById("trPanel").className='on';
				}
				else
				{
					document.getElementById("trPanel").className='off';
				}
			}
		</script>
		<style>.on { DISPLAY: inline }
	.off { DISPLAY: none }
	</style>
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
						<td vAlign="top" width="830" height="380">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<p class="llblContentTitle" align="left">Download Syllabus
										</p>
										<P>
											<table cellSpacing="1" cellPadding="2" width="100%">
              <TR>
                
                <TD align=right colSpan=4><asp:label id="lblError" runat="server" Font-Bold="True"></asp:label></TD></TR>
												<tr height="20">
													<td align="left" colSpan="2"><asp:label id="lbl_Fac_Cr_Mode" runat="server" Font-Bold="True"></asp:label></td>
													<td align="right" colSpan="2"><A 
                  id=lnkOtherPatterns style="COLOR: #000080" 
                  onclick=ShowHidePatterns(); href="#" 
                  name=lnkOtherPatterns>Show Other Patterns</A></td>
												</tr>
												<tr id="showPatternLink" runat="server">
													<td align="left" colSpan="3"></td>
													<td align="right">&nbsp;
													</td>
												</tr>
												<tr class="off" id="trPanel" align="center">
													<td colSpan="4"><asp:panel id="pnlPatterns" Runat="server">
                  <TABLE width="100%">
                    <TR>
                      <TD style="WIDTH: 190px" align=right><STRONG>Select 
                        Pattern</STRONG> </TD>
                      <TD style="WIDTH: 1px"><STRONG>:</STRONG></TD>
                      <TD style="WIDTH: 241px" align=left>
<asp:dropdownlist id=DD_Course_Pattern runat="server" Width="223px" CssClass="selectBoxHome"></asp:dropdownlist></TD>
                      <TD align=left>
<asp:Button id=btnSearch runat="server" CssClass="butSubmit" Text="Search"></asp:Button></TD></TR></TABLE>
														</asp:panel></td>
												</tr>
												<TR>
													<TD align="center" colSpan="4"><STRONG></STRONG><asp:label id="lblCoursePattern" runat="server" Font-Bold="True" Visible="False"></asp:label></TD>
												</TR>
												<tr align="center">
													<td colSpan="4"><asp:datagrid id="DG_Course_Part" runat="server" Width="95%" AutoGenerateColumns="False">
															<AlternatingItemStyle CssClass="gridAltItemHome"></AlternatingItemStyle>
															<ItemStyle CssClass="gridItemHome"></ItemStyle>
															<Columns>
																<asp:BoundColumn Visible="False" DataField="pk_CrPr_ID" HeaderText="pk_CrPr_ID"></asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="pk_CrPrCh_ID" HeaderText="pk_CrPrCh_ID"></asp:BoundColumn>
																<asp:BoundColumn DataField="CrPr_Abbr" HeaderText="Year">
																	<HeaderStyle Font-Size="8pt" Font-Bold="True" Width="40%" CssClass="gridHeaderHome"></HeaderStyle>
																	<ItemStyle Font-Size="8pt"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="CrPrCh_Desc" HeaderText="Term">
																	<HeaderStyle Font-Size="8pt" Font-Bold="True" Width="40%" CssClass="gridHeaderHome"></HeaderStyle>
																	<ItemStyle Font-Size="8pt"></ItemStyle>
																</asp:BoundColumn>
																<asp:ButtonColumn HeaderText="Select Papers" CommandName="Select">
																	<HeaderStyle Font-Size="8pt" Font-Bold="True" Width="20%" CssClass="gridHeaderHome"></HeaderStyle>
																	<ItemStyle Font-Size="8pt" ForeColor="Navy" Width="22%"></ItemStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" Text="Download Syllabus (All Papers)" HeaderText="Download Syllabus" CommandName="SelectAllPapers">
																	<HeaderStyle Font-Size="8pt" Font-Bold="True" CssClass="gridHeaderHome"></HeaderStyle>
																	<ItemStyle Font-Size="8pt" ForeColor="Navy" Width="40%"></ItemStyle>
																</asp:ButtonColumn>
															</Columns>
														</asp:datagrid></td>
												</tr>
												<tr>
													<td colSpan="4">
														<TABLE width="100%">
															<TR>
																<TD align="center"><asp:label id="lblPartChild" runat="server" Font-Bold="True"></asp:label></TD>
															</TR>
															<TR id="pnlParts" style="DISPLAY: none" align="center" runat="server">
																<TD><asp:datagrid id="DG_Parts_Papers" runat="server" Width="96%" AutoGenerateColumns="False" Visible="False">
																		<AlternatingItemStyle CssClass="gridAltItemHome"></AlternatingItemStyle>
																		<ItemStyle CssClass="gridItemHome"></ItemStyle>
																		<Columns>
																			<asp:BoundColumn Visible="False" DataField="pk_CrPr_ID" HeaderText="pk_CrPr_ID"></asp:BoundColumn>
																			<asp:BoundColumn Visible="False" DataField="pk_CrPrCh_ID" HeaderText="pk_CrPrCh_ID"></asp:BoundColumn>
																			<asp:BoundColumn Visible="False" DataField="pk_Pp_ID" HeaderText="pk_Pp_ID"></asp:BoundColumn>
																			<asp:BoundColumn DataField="Pp_Code" HeaderText="Paper Code">
																				<HeaderStyle Font-Size="8pt" Width="15%" CssClass="gridHeaderHome"></HeaderStyle>
																				<ItemStyle Font-Size="8pt"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="Pp_Name" HeaderText="Paper">
																				<HeaderStyle Font-Size="8pt" Font-Bold="True" CssClass="gridHeaderHome"></HeaderStyle>
																				<ItemStyle Font-Size="8pt"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:ButtonColumn Text="Download Syllabus" HeaderText="Download Syllabus" CommandName="Select">
																				<HeaderStyle Font-Size="8pt" Font-Bold="True" CssClass="gridHeaderHome"></HeaderStyle>
																				<ItemStyle Font-Size="8pt" ForeColor="Navy" Width="30%"></ItemStyle>
																			</asp:ButtonColumn>
																			<asp:BoundColumn Visible="False" DataField="Pp_Syllabus" HeaderText="Pp_Syllabus"></asp:BoundColumn>
																		</Columns>
																	</asp:datagrid></TD>
															</TR>
														</TABLE>
													</td>
												</tr>
											</table>
										</P>
										<P><asp:label id="lblUpdationDate" runat="server"></asp:label></P>
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
			<INPUT id="hidUniID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden1"
				runat="server"> <INPUT id="hidFacID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden3"
				runat="server"><INPUT id="hidCrID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden6"
				runat="server"><INPUT id="hidMoLrnID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden5"
				runat="server"><INPUT id="Hid_Md_Lrn_Ptrn_ID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8"
				name="Hidden5" runat="server"></form>
	</BODY>
</HTML>
