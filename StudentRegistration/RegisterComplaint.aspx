<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrgStrControl" Src="OrgStrControl.ascx" %>
<%@ Page language="c#" Codebehind="RegisterComplaint.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.RegisterComplaint" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
			| </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="jscript/jscript_validations.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<script>
			
			function fnSaveValidate()
			{
				var i=-1;
				var myArr= new Array();	
				myArr[++i]= new Array(document.getElementById("cmbSubjectCategory"),"","Select Subject Category","select");								
				//myArr[++i]= new Array(document.getElementById("cmbSubject"),"select","Select Subject","select");								
				if(document.getElementById("cmbSubjectCategory").value == "0" && document.getElementById("cmbSubject").value == "0")
				{
					myArr[++i]= new Array(document.getElementById("txtSubject"),"Empty","Enter Other Subject Name","text");								
				}
				if(document.getElementById("hid_User_ID").value == "")
				{
					myArr[++i]= new Array(document.getElementById("txtName"),"Empty","Enter Your Name","text");			
					myArr[++i]= new Array(document.getElementById("txtEmailID"),"Empty","Enter Email ID","text");			
				}
				if(document.getElementById("txtEmailID").value != "")
				{
					myArr[++i]= new Array(document.getElementById("txtEmailID"),"Email","Enter Valid email ID","text");			
				}
				myArr[++i]= new Array(document.getElementById("txtTelNo"),"NumericOnly","Enter Valid Telephone Number","text");			
				myArr[++i]= new Array(document.getElementById("txtMobileNo"),"NumericOnly","Enter Valid Mobile Number","text");			
				myArr[++i]= new Array(document.getElementById("txtComplaintDetails"),"Empty","Enter Complaint Details","text");					
				var ret=validateMe(myArr,50); 
				if(ret)
				{
					if(document.getElementById("hid_Subject_ID").value == "" || document.getElementById("hid_Subject_ID").value == "0")
					{
						alert("Please Correct following errors... \n1. Select Subject");
						return false;
					}
				}
				return ret;
			}
			
			function FillSubjects(val)
			{	
				document.getElementById("hid_Cat_ID").value = val;
				var strxml = "<fk_SubjectCat_ID>"+val+"</fk_SubjectCat_ID>";  
				
				var cmbName=document.getElementById("cmbSubject");
				var SitePath = '<%=UniversityPortal.clsGetSettings.SitePath%>';
				//alert(SitePath);
				XMLSP(cmbName,"CM_getCatWsieSubjects",strxml,"Y",SitePath);
			}
			
			function displayHideSubjects()
			{	
			
				if(document.getElementById("cmbSubjectCategory").value == "0" && document.getElementById("cmbSubject").value == "0")
				{
					document.getElementById("trSubjectText").style.display="inline";
				}
				else
				{
					document.getElementById("trSubjectText").style.display = "none";
				}
				document.getElementById("hid_Subject_ID").value = document.getElementById("cmbSubject").value;
				//alert(document.getElementById("hid_Subject_ID").value); 
				
			}
			
			function displayHideUserDetails()
			{
				if(document.getElementById("hid_User_ID").value == "")
				{
					document.getElementById("trName").style.display="inline";
					document.getElementById("trEmail").style.display="inline";
				}
				else
				{
					document.getElementById("trName").style.display="none";
					document.getElementById("trEmail").style.display="none";
				}
			}
			
			function setValue(Text,Value)
			{
				var text = eval(document.getElementById(Text));
				text.value = Value;
				//document.getElementById("hid_Subject_Text").value = SubjectText;
				var x=document.getElementById("cmbSubject")
				
				document.getElementById("hid_Subject_Text").value = x.options[x.selectedIndex].text;
			}
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="displayHideUserDetails();" rightMargin="0">
		<form id="Form1" name="RegisterComplaint" method="post" runat="server">
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
						<td style="WIDTH: 170px" vAlign="top"><uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol><INPUT id="hid_Page" style="WIDTH: 88px; HEIGHT: 22px" type="hidden" size="9" name="hid_Page"
								runat="server"><INPUT id="hid_MenuID" style="WIDTH: 88px; HEIGHT: 22px" type="hidden" size="9" name="hid_MenuID"
								runat="server">
						</td>
						<td vAlign="top" width="830">
							<table width="100%">
								<tr>
									<td style="WIDTH: 574px" vAlign="top" align="left" width="575">
										<p align="left"><uc1:orgstrcontrol id="OrgStrControl1" runat="server"></uc1:orgstrcontrol></p>
										<P align="left"><asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle">Enter New Complaint Details</asp:label></P>
										<!-- Form design Begins here  -->
										<table id="tblDetail" cellSpacing="3" width="100%" runat="server">
											<tr>
												<td class="MandetoryField" align="right">Subject Type:</td>
												<td><asp:dropdownlist id="cmbSubjectCategory" tabIndex="1" runat="server" CssClass="SelectBoxHome" Width="440px"
														OnChange="FillSubjects(this.value);"></asp:dropdownlist>&nbsp;<FONT class="Mandatory">*</FONT><INPUT id="hid_Cat_ID" type="hidden" size="1" name="hid_Cat_ID" runat="server"></td>
											</tr>
											<tr id="trSubjectCombo">
												<td class="MandetoryField" style="HEIGHT: 17px" align="right">Subject:</td>
												<td style="HEIGHT: 17px"><asp:dropdownlist id="cmbSubject" onblur="setValue('hid_Subject_ID',this.value)" CssClass="SelectBoxHome"
														Width="440px" AutoPostBack="True" Runat="server"></asp:dropdownlist>&nbsp;<FONT class="Mandatory">*</FONT><INPUT id="hid_Subject_ID" type="hidden" size="1" value="0" name="hid_Subject_ID" runat="server"></td>
											</tr>
											<tr id="trSubjectText" style="DISPLAY: none" runat="server">
												<td class="MandetoryField" style="HEIGHT: 17px" align="right">Other&nbsp;Subject:</td>
												<td style="HEIGHT: 17px"><asp:textbox id="txtSubject" tabIndex="3" runat="server" CssClass="inputBox" Width="437px" MaxLength="200"></asp:textbox>&nbsp;<FONT class="Mandatory">*</FONT></td>
											</tr>
											<tr id="trName">
												<td align="right">Your&nbsp;Name:</td>
												<td><asp:textbox id="txtName" tabIndex="4" runat="server" CssClass="inputBox" Width="260px" MaxLength="300"></asp:textbox>&nbsp;<FONT class="Mandatory">*</FONT></td>
											</tr>
											<tr>
												<td style="HEIGHT: 24px" align="right">Reference No<br>
													(if any):</td>
												<td style="HEIGHT: 24px"><asp:textbox id="txtRefrence" tabIndex="11" runat="server" CssClass="inputBox" Width="128px"
														MaxLength="50"></asp:textbox>&nbsp;
													<asp:label id="lblPreComplaint" runat="server">Previous Complaint No:</asp:label><asp:textbox id="txtPrevComplaint" tabIndex="12" runat="server" CssClass="inputBox" Width="168px"
														MaxLength="7"></asp:textbox></td>
											</tr>
											<tr id="trEmail" align="right">
												<td>Your&nbsp;Email-ID:</td>
												<td align="left"><asp:textbox id="txtEmailID" tabIndex="13" runat="server" CssClass="inputBox" Width="260px" MaxLength="255"></asp:textbox>&nbsp;<FONT class="Mandatory">*</FONT></td>
											</tr>
											<tr>
												<td align="right">Your&nbsp;Telephone No:</td>
												<td><asp:textbox id="txtTelNo" tabIndex="14" runat="server" CssClass="inputBox" Width="152px" MaxLength="15"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp; 
													&nbsp;
													<asp:label id="lblMobile" runat="server">Your Mobile No:</asp:label><asp:textbox id="txtMobileNo" tabIndex="15" runat="server" CssClass="inputBox" Width="143px"
														MaxLength="15"></asp:textbox></td>
											</tr>
											<tr>
												<td vAlign="top" align="right">Complaint Details:</td>
												<td vAlign="top"><asp:textbox id="txtComplaintDetails" tabIndex="16" runat="server" CssClass="inputBox" Width="440px"
														Height="208px" TextMode="MultiLine"></asp:textbox>&nbsp;<FONT class="Mandatory">*</FONT></td>
											</tr>
											<tr>
												<td align="center" colSpan="2"><asp:button id="btnSubmit" tabIndex="17" runat="server" CssClass="butSubmit" Text="Submit"></asp:button>&nbsp;
													<input class="butSubmit" id="btnReset" type="reset" value="Reset" name="btnReset"></td>
											</tr>
											<TR>
												<TD style="HEIGHT: 2px" colSpan="2">&nbsp; <STRONG>Note:</STRONG><FONT class="Mandatory">*</FONT>
													marked fields are mandatory.</TD>
											</TR>
										</table>
										<P><asp:label id="lblUpdationDate" runat="server"></asp:label><INPUT id="hid_User_ID" type="hidden" size="1" name="hid_User_ID" runat="server"><INPUT id="hid_Complaint_ID" type="hidden" size="1" name="hid_Complaint_ID" runat="server"><INPUT id="hid_Subject_Text" type="hidden" size="1" name="hid_Subject_Text" runat="server"><INPUT id="hid_ReComplaint_Flag" type="hidden" size="1" value="F" name="hid_ReComplaint_Flag"
												runat="server"><INPUT id="hid_Error_Occured" type="hidden" size="1" name="hid_Error_Occured" runat="server"></P>
									</td>
									<td vAlign="top" align="center" width="19%"><br>
										<TABLE id="tblSearch" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
											<TR>
												<TD style="WIDTH: 147px" vAlign="bottom" colSpan="2"><IMG src="Images/box01_topstrip.gif" align="middle" border="0"></TD>
											</TR>
											<TR bgColor="#cdc5b6">
												<TD class="tblHeaderTR" colSpan="2" height="18"><font color="#62452c">&nbsp;Search 
														Complaint Status</font></TD>
											</TR>
											<TR bgColor="#e7e2db">
												<td style="WIDTH: 147px" vAlign="bottom" align="center" colSpan="2">&nbsp;</td>
											</TR>
											<TR bgColor="#e7e2db">
												<td class="MandetoryField" style="WIDTH: 73px" align="right">Complaint #</td>
												<td style="WIDTH: 74px" align="left"><asp:textbox id="txtComplaint" tabIndex="20" runat="server" CssClass="inputbox" Width="65px"
														MaxLength="12"></asp:textbox></td>
											</TR>
											<TR bgColor="#e7e2db">
												<td style="WIDTH: 147px" vAlign="bottom" align="center" colSpan="2">&nbsp;</td>
											</TR>
											<TR bgColor="#e7e2db">
												<td vAlign="middle" align="center" colSpan="2" rowSpan="1">&nbsp;<asp:button id="btnSearch" tabIndex="21" runat="server" CssClass="butCompSearch" Text="Search"></asp:button></td>
											</TR>
											<TR>
												<TD style="WIDTH: 147px" vAlign="top" colSpan="2"><IMG src="Images/box01_bottom.gif" align="middle" border="0"></TD>
											</TR>
										</TABLE>
										<P>&nbsp;</P>
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
		</form>
	</body>
</HTML>
