<%@ Page language="c#" Codebehind="DisplayFAQ.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.DisplayFAQ" %>
<%@ Register TagPrefix="uc1" TagName="OrgStrControl" Src="OrgStrControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title> <%=Classes.clsGetSettings.Name%>
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
			function showTR(Text,Cnt)
			{
				var tRow = 'tr'+Text;
				var OtherRows,otherimg;
				
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
				for(i=1; i<=Cnt;i++)
				{
					OtherRows ='tr'+i;
					OtherRows = eval(document.getElementById(OtherRows));
					otherimg = 'img'+i;
					otherimg = eval(document.getElementById(otherimg));					
					if(tRow!=OtherRows)
					{
						if(OtherRows!=null)
						OtherRows.style.display = "none";
						if(otherimg!=null)
						otherimg.src = "Images/plus.gif";
					}					
				}
				
				
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
						<td style="WIDTH: 153px" vAlign="top"><uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol><INPUT id="hid_Page" style="WIDTH: 120px; HEIGHT: 22px" type="hidden" size="14" name="hid_Page"
								runat="server"><INPUT id="hid_MenuID" style="WIDTH: 120px; HEIGHT: 22px" type="hidden" size="14" name="hid_MenuID"
								runat="server"></td>
						<td vAlign="top" width="830" height="380">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<p align="left"><uc1:orgstrcontrol id="OrgStrControl1" runat="server"></uc1:orgstrcontrol></p>
										<P class="llblContentTitle" align="left">FAQ&nbsp;
										</P>
										<P>
											<table cellSpacing="1" cellPadding="2" width="100%">
												<TR>
													<TD align="right" colSpan="4"><asp:label id="lblInformation" runat="server" Font-Bold="True"></asp:label></TD>
												</TR>
												<TR>
													<TD align="center" colSpan="4"><STRONG>
															<TABLE id="Table2" width="90%" align="center">
																<TR>
																	<TD id="tdFAQ" style="HEIGHT: 15px" width="100%" colSpan="2" runat="server"><asp:placeholder id="FAQTable" runat="server"></asp:placeholder></TD>
																</TR>
																<TR>
																	<TD width="100%" colSpan="2"></TD>
																</TR>
															</TABLE>
														</STRONG>
													</TD>
												</TR>
											</table>
										</P>
										<P><asp:label id="lblUpdationDate" runat="server"></asp:label></P>
									</td>
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
