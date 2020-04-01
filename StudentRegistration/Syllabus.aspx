<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Page language="c#" Codebehind="Syllabus.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.Syllabus" %>
<%@ Register TagPrefix="uc1" TagName="OrgStrControl" Src="OrgStrControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
			| Syllabus</title>
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
		function setValue(Text,Value)
		{
			var text = eval(document.getElementById(Text));
			text.value = Value;
		}		
		function FillCr(val)
		{				
			document.getElementById("Hid_Fac_ID").value = val;
			var UniID=document.getElementById("fk_Uni_ID").value;				
			var FacID=val;	
			var strxml = "<Uni_ID>"+UniID+"</Uni_ID>";   
			strxml += "	<Fac_ID>"+FacID+"</Fac_ID>";					 
			
			var cmbName=document.getElementById("dd_Cr_Desc");
			XMLSP(cmbName,"CD_CourseList_Launched",strxml,"Y");
		}
		function fnValidateSearch()
		{
			var i=-1;
			var myArr= new Array();	
			myArr[++i]= new Array(document.getElementById("dd_Fac_Desc"),"","Select Faculty","select");	
			myArr[++i]= new Array(document.getElementById("dd_Cr_Desc"),"0","Select Course","select");			
			var ret=validateMe(myArr,50); 
			if(ret == true)
			{
				if(document.getElementById("dd_ModeLrn_Desc").value == "0")
				{
					alert("Please correct following errors...\n1.Select Learning Mode");
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return ret;
			}
		}
		function FillMoLrn(val)
		{				
				var UniID=document.getElementById("fk_Uni_ID").value;
				var FacID=document.getElementById("Hid_Fac_ID").value;				
				var CrID=val;			
				
				document.getElementById("pk_Cr_ID").value=val;
				if(UniID=="")
					UniID=0;
				if(FacID=="")
					FacID=0;				
				if(CrID=="")
					CrID=0;
					
				var strxml = "<Uni_ID>"+UniID+"</Uni_ID>";   
				strxml += "	<Fac_ID>"+FacID+"</Fac_ID>";
				strxml += "	<Cr_ID>"+CrID+"</Cr_ID>";
						
				var cmbName=document.getElementById("dd_ModeLrn_Desc");
				XMLSP(cmbName,"CD_CoursewiseModeOfLearnings_Launched",strxml,"Y");
		}

		</script>
	</HEAD>
	<body bottomMargin="0" topMargin="0">
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
						<td style="WIDTH: 170px" vAlign="top"><uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol><INPUT id="hid_Page" type="hidden" name="hid_Page" runat="server"><INPUT id="hid_MenuID" type="hidden" name="hid_MenuID" runat="server"></td>
						<td vAlign="top" width="830" height="380">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<table>
											<tr>
												<td vAlign="top" align="left" width="99%">
													<p align="left">
														<uc1:orgstrcontrol id="OrgStrControl1" runat="server"></uc1:orgstrcontrol>
													</p>
													<P class="llblContentTitle" align="left">Search Syllabus
													</P>
													<P>
														<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
															<TR>
																<TD vAlign="top" align="left" width="80%">
																	<table id="tblSelect" cellSpacing="0" cellPadding="3" width="100%" border="0" runat="server">
																		<tr>
																			<td style="WIDTH: 255px" align="right"><b>Select&nbsp; Faculty</b></td>
																			<td style="WIDTH: 1px" width="1">&nbsp;<STRONG>:</STRONG></td>
																			<td align="left"><asp:dropdownlist id="dd_Fac_Desc" onblur="setValue('Hid_Fac_ID',this.value)" runat="server" CssClass="selectBoxHome"
																					Width="300px" OnChange="FillCr(this.value);"></asp:dropdownlist><FONT class="Mandatory">*</FONT><INPUT id="Hid_Fac_ID" style="WIDTH: 37px; HEIGHT: 22px" type="hidden" size="1" name="Hid_Fac_ID"
																					runat="server"></td>
																		</tr>
																		<tr>
																			<td style="WIDTH: 255px" align="right"><b><STRONG><B>Select </B></STRONG>Course</b></td>
																			<td style="WIDTH: 1px" width="1">&nbsp;<STRONG>:</STRONG></td>
																			<td><asp:dropdownlist id="dd_Cr_Desc" onblur="setValue('pk_Cr_ID',this.value);" runat="server" CssClass="selectBoxHome"
																					Width="184px" onchange="FillMoLrn(this.value);"></asp:dropdownlist><FONT class="Mandatory">*</FONT><FONT class="Mandatory"></FONT><INPUT id="pk_Cr_ID" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="pk_Cr_ID"
																					runat="server"></td>
																		</tr>
																		<TR>
																			<TD style="WIDTH: 255px" align="right"><STRONG><B><STRONG><B>Select Learning Mode </B></STRONG>
																					</B></STRONG>
																			</TD>
																			<TD style="WIDTH: 1px">&nbsp;<STRONG>:</STRONG></TD>
																			<TD><asp:dropdownlist id="dd_ModeLrn_Desc" onblur="setValue('pk_CrMoLrn_ID',this.value)" runat="server"
																					CssClass="selectBoxHome" Width="125px"></asp:dropdownlist><FONT class="Mandatory">*</FONT><INPUT id="pk_CrMoLrn_ID" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="pk_CrMoLrn_ID"
																					runat="server">
																			</TD>
																		</TR>
																		<TR>
																			<TD style="WIDTH: 255px; HEIGHT: 2px" align="right"><B></B></TD>
																			<TD style="WIDTH: 1px; HEIGHT: 2px" width="1"></TD>
																			<TD style="HEIGHT: 2px"></TD>
																		</TR>
																		<TR align="center">
																			<TD style="HEIGHT: 2px" colSpan="3"><asp:button id="btnDetails" runat="server" CssClass="ButSp" Width="100px" Font-Bold="True" Text="Search"></asp:button></TD>
																		</TR>
																		<TR>
																			<TD style="HEIGHT: 2px" colSpan="3">&nbsp; <STRONG>Note:</STRONG><FONT class="Mandatory">*</FONT>
																				marked fields are mandatory.</TD>
																		</TR>
																	</table>
																</TD>
															</TR>
														</TABLE>
													</P>
												</td>
											</tr>
										</table>
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
				<!--Repeater--></CENTER>
			<INPUT id="hidUniID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden1"
				runat="server"> <INPUT id="hidFacID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden3"
				runat="server"><INPUT id="hidCrID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden6"
				runat="server"><INPUT id="hidMoLrnID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden5"
				runat="server"><INPUT id="hidCrMoLrnID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden9"
				runat="server"><INPUT id="hidCrPtrnID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden4"
				runat="server"><INPUT id="hidCrMoLrnPtrnID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden7"
				runat="server"><INPUT id="hidCrPrID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden8"
				runat="server"><INPUT id="hidCrPrChID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden10"
				runat="server"><INPUT id="hidPpID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden2"
				runat="server"><INPUT id="hidLaunched" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden2"
				runat="server"><INPUT id="hidActive" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden10"
				runat="server"><INPUT id="hidPapGrpID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="Hidden2"
				runat="server"> <INPUT id="fk_Uni_ID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" runat="server">
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
		</asp:repeater></form>
	</body>
</HTML>
