<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Page language="c#" Codebehind="eBooks.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.eBooks" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
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
		function FillSubjects(val)
		{	
			document.getElementById("hid_Fac_ID").value = val;
			var strxml = "<pk_Uni_ID>"+document.getElementById("hidUniID").value+"</pk_Uni_ID>";  
			strxml += "<pk_Fac_ID>"+val+"</pk_Fac_ID>";
			
			//alert(strxml);
			var cmbName=document.getElementById("SubID");
			
			XMLSP(cmbName,"CD_FacultyWiseSubjectList",strxml,"N");
			var objOption = document.createElement("option");
			objOption.text = "---- All ----";
			objOption.value = "";
			objOption.selected = true;
			cmbName.options[0] = objOption;			
			
			var text = eval(document.getElementById("hid_Sub_ID"));
			text.value = "0";
		}
		function fnValidateSearch()
		{
			var i=-1;
			var myArr= new Array();	
			myArr[++i]= new Array(document.getElementById("FacID"),"","Select Faculty","select");	
			//myArr[++i]= new Array(document.getElementById("SubID"),"0","Select Subject","select");			
			var ret=validateMe(myArr,50); 			
			return ret;
			
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
						<td colSpan="4" height="5"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px" vAlign="top">
							<uc1:InnerMenuControl id="UCInnerMenuControl" runat="server"></uc1:InnerMenuControl>
						</td>
						<td vAlign="top" width="830">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<table>
											<tr>
												<td vAlign="top" align="left" width="99%">
													<p class="llblContentTitle" align="left">Search eBooks
													</p>
													<P>
														<TABLE id="Table4" height="360"  cellSpacing="0" cellPadding="0" width="100%" border="0">
															<TR>
																<TD vAlign="top" align="left" width="80%">
																	<table id="tblSelect" cellSpacing="0" cellPadding="3" width="100%" border="0" runat="server">
																		<tr>
																			<td align="right" width="30%" colSpan="1" rowSpan="1"><b>Select&nbsp; Faculty</b></td>
																			<td width="1%" colSpan="1" rowSpan="1">&nbsp;<STRONG>:</STRONG></td>
																			<td align="left" width="69%" colSpan="1" rowSpan="1"><asp:dropdownlist id="FacID" onblur="setValue('Hid_Fac_ID',this.value)" runat="server" CssClass="SelectBoxHome"
																					Width="342px" onchange="FillSubjects(this.value);"></asp:dropdownlist><FONT class="Mandatory">*</FONT><INPUT id="Hid_Fac_ID" style="WIDTH: 37px; HEIGHT: 22px" type="hidden" size="1" name="Hid_Fac_ID"
																					runat="server"></td>
																		</tr>
																		<tr>
																			<td style="WIDTH: 255px" align="right"><b><STRONG><B>Select </B></STRONG>Subject</b></td>
																			<td style="WIDTH: 1px" width="1">&nbsp;<STRONG>:</STRONG></td>
																			<td><asp:dropdownlist id="SubID" onblur="setValue('hid_Sub_ID',this.value);" runat="server" CssClass="SelectBoxHome"
																					Width="342px"></asp:dropdownlist><FONT class="Mandatory">*</FONT><FONT class="Mandatory"></FONT><INPUT id="hid_Sub_ID" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hid_Sub_ID"
																					runat="server"></td>
																		</tr>
																		<TR align="center">
																			<TD style="HEIGHT: 32px" colSpan="3"><asp:button id="btnDetails" runat="server" CssClass="ButSp" Width="100px" Font-Bold="True" Text="Search"></asp:button></TD>
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
				<asp:repeater id="mnuReapeater" runat="server">
			<HeaderTemplate>
						<script language="javascript"> 
					</HeaderTemplate>					
						<ItemTemplate>
					//	alert(document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetLeft);
					var sWidth=0;
			//		alert(parseInt(document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetTop+document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetTop));
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
			<INPUT id="hidUniID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" size="8" name="hidUniID"
				runat="server"></form>
	</body>
</HTML>
