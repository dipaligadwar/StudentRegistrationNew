<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="schCrInInst.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.schCrInInst" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Classes.clsGetSettings.Name%>
			| College/Institute wise Course Search</title>
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
			}
			
			//Fill District
			function FillDistricts(StateID,LangFlag,TargetDropDownName)
			{				
					var strxml = "<State_ID>"+StateID+"</State_ID>";   
					strxml += "	<Lang_Flag>"+LangFlag+"</Lang_Flag>";					 
					var dropDownName=document.getElementById(TargetDropDownName);
					XMLSP(dropDownName,"GEN_stateWiseDistricts",strxml,"Y");
			}
			
			//Fill Talukas
			function FillTalukas(DistrictID,LangFlag,TargetDropDownName)
			{				
					var strxml = "<District_ID>"+DistrictID+"</District_ID>";   
					strxml += "	<Lang_Flag>"+LangFlag+"</Lang_Flag>";					 
					var dropDownName=document.getElementById(TargetDropDownName);
					XMLSP(dropDownName,"GEN_districtWiseTaluka",strxml,"Y");
			}
			
			//Fill CollegeInst
			function FillCollegeInst(TehsilID,TargetDropDownName)
			{				
					var strxml = "<pk_Uni_ID>"+document.getElementById("hidUniID").value+"</pk_Uni_ID>";   
					strxml += "	<fk_State_ID>"+document.getElementById("hidStateID").value+"</fk_State_ID>";	
					strxml += "	<fk_District_ID>"+document.getElementById("hidDistrictID").value+"</fk_District_ID>";	
					strxml += "	<fk_Tehsil_ID>"+TehsilID+"</fk_Tehsil_ID>";
					
					var dropDownName=document.getElementById(TargetDropDownName);
					XMLSP(dropDownName,"PU_REP_StateDisTalUniColInst",strxml,"Y");
			}
			
			function FillParentBodywiseCollegeInst(SocietyID,TargetDropDownName)
			{				
				var strxml = "<pk_Uni_ID>"+document.getElementById("hidUniID").value+"</pk_Uni_ID>";   
				strxml += "	<fk_SocTrt_ID>"+SocietyID+"</fk_SocTrt_ID>";
				
				var dropDownName=document.getElementById(TargetDropDownName);
				XMLSP(dropDownName,"PU_REP_ParentBodywiseInst",strxml,"Y");
			}
			
			function fnShow()
			{				
				tbl=document.getElementById("rdSelect");
				
				if(tbl.rows[0].cells[0].childNodes[0].checked)
				{
					document.getElementById("tblLocation").style.display="inline";
					document.getElementById("tblParentBody").style.display="none";
					document.getElementById("lblData").innerText="";					
				}
				if(tbl.rows[1].cells[0].childNodes[0].checked)
				{					
					document.getElementById("tblLocation").style.display="none";
					document.getElementById("tblParentBody").style.display="inline";
					document.getElementById("lblData").innerText="";					
				}
			}
			
			function fnSetHiddenValue()
			{
				tbl=document.getElementById("rdSelect");
				
				if(tbl.rows[0].cells[0].childNodes[0].checked)
				{
					document.getElementById("hidInstID").value=document.getElementById("Inst_ID").value;
					document.getElementById("hidStateID").value=document.getElementById("State_ID").value;
					document.getElementById("hidDistrictID").value=document.getElementById("District_ID").value;				
					document.getElementById("hidTehsilID").value=document.getElementById("Tehsil_ID").value;
				}
				if(tbl.rows[1].cells[0].childNodes[0].checked)
				{
					document.getElementById("hidInstID").value=document.getElementById("Inst_ID_Parent").value;					
					document.getElementById("hidSocTrtID").value=document.getElementById("SocTrt_ID").value;
					document.getElementById("hidStateID").value="0";
					document.getElementById("hidDistrictID").value="0";				
					document.getElementById("hidTehsilID").value="0";
				}
			}
			
			function fnDetails(uu,ff,cc,mm,pp)
			{
				var SitePath = '<%=Classes.clsGetSettings.SitePathCourse%>';
				window.open(SitePath+"uniGetCourseDetails.aspx?u="+uu+"&f="+ff+"&c="+cc+"&m="+mm+"&p="+pp,null,"width=800, height=400,left=100, top=200, resizable = yes, scrollbars = yes");
			}
		
		function newWindow()
		{	
			var sInstID=document.getElementById("hidInstID").value;
			if(sInstID!="" && sInstID!="0")
			{
				var url="schCrInInst_print.aspx?InstID="+sInstID;
				window.open(url,'','toolbar=no,resizable=yes,location=no,scrollbars=yes,status=yes,width=950,height=650');
			}
			else
				alert("Select an Institute.");
				document.getElementById("hlPrint").style.display="none";
		}
		function chkInstituteSelect()
		{
			var i=-1;
				var myArr= new Array();		
			tbl=document.getElementById("rdSelect");
			if(tbl.rows[0].cells[0].childNodes[0].checked)
			{
				myArr[++i]= new Array(document.getElementById("State_ID"),"0","Please Select State","select");
				myArr[++i]= new Array(document.getElementById("District_ID"),"0","Please Select District","select");
				myArr[++i]= new Array(document.getElementById("Tehsil_ID"),"0","Please Select Taluka","select");
				myArr[++i]= new Array(document.getElementById("Inst_ID"),"0","Please Select Institute","select");
			}	
			if(tbl.rows[1].cells[0].childNodes[0].checked)
			{					
				myArr[++i]= new Array(document.getElementById("SocTrt_ID"),"0","Please Select Parent Body","select");
				myArr[++i]= new Array(document.getElementById("Inst_ID_Parent"),"0","Please Select Institute","select");
			}
				
				var ret=validateMe(myArr,50);
				return ret;
			
			
			
			
			/*var sInstID=document.getElementById("hidInstID").value;
			if(sInstID!="" || sInstID!="0")
			{
				alert("Select an Institute.");
				return false;
			
			}
			return true;*/
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
						<td colSpan="4" height="10"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td colSpan="4" height="5"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px; HEIGHT: 58px" vAlign="top"><uc1:innermenucontrol id="UCInnerMenuControl" runat="server"></uc1:innermenucontrol></td>
						<td vAlign="top" width="830" height="450">
							<table width="100%">
								<tr>
									<td vAlign="top" align="left" width="99%">
										<p align="left"><asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label></p>
									</td>
									<td vAlign="top" align="left" width="1%"><uc1:sublinkusercontrol id="UCSubLink" runat="server"></uc1:sublinkusercontrol></td>
								</tr>
							</table>
							<!-- Main Starts -->
							<p style="MARGIN-TOP: 10px; MARGIN-BOTTOM: 20px; MARGIN-LEFT: 5px" align="left">&nbsp;
								<asp:radiobuttonlist id="rdSelect" runat="server" CellSpacing="0" CellPadding="0" Width="100%" AutoPostBack="True">
									<asp:ListItem Value="1" Selected="True">Select College/Institute by its location</asp:ListItem>
									<asp:ListItem Value="2">Select College/Institute by its Parent Body</asp:ListItem>
								</asp:radiobuttonlist></p>
							<!-- Location Search Starts -->
							<table id="tblLocation" style="DISPLAY: inline" cellSpacing="0" cellPadding="0" width="100%"
								border="0" runat="server">
								<tr>
									<td align="right" width="30%"><B>Select State</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="State_ID" runat="server" CssClass="selectBoxHome" Width="206px"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td align="right" width="30%"><B>Select District</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="District_ID" runat="server" CssClass="selectBoxHome" Width="180px"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td align="right" width="30%"><B>Select Tehsil</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="Tehsil_ID" runat="server" CssClass="selectBoxHome" Width="163px"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td align="right" width="30%"><B>Select College/Institute</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="Inst_ID" runat="server" CssClass="selectBoxHome" Width="461px"></asp:dropdownlist></td>
								</tr>
							</table>
							<!-- Location Search Ends -->
							<!-- Parent Search Starts -->
							<table id="tblParentBody" style="DISPLAY: none" cellSpacing="0" cellPadding="0" width="100%"
								border="0" runat="server">
								<tr>
									<td align="right" width="30%"><B>Select Parent Body</B>
									</td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="SocTrt_ID" runat="server" CssClass="selectBoxHome" Width="463px"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td align="right" width="30%"><B>Select College/Institute</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="Inst_ID_Parent" runat="server" CssClass="selectBoxHome" Width="461px"></asp:dropdownlist></td>
								</tr>
							</table>
							<!-- Parent Search Ends -->
							<p style="MARGIN-TOP: 5px; MARGIN-BOTTOM: 5px" align="center"><asp:button id="btnSearch" runat="server" CssClass="ButSp" Text="Search"></asp:button></p>
							<table>
								<tr>
									<TD align="left" width="10%"><a id="hlPrint" onmouseover="this.style.cursor='Hand'" style="FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #666666; FONT-FAMILY: Verdana; TEXT-DECORATION: underline"
											onclick="newWindow();" onmouseout="this.style.cursor='Arrow'" name="hlPrint" runat="server">Print 
											Report</a>
									</TD>
								</tr>
							</table>
							<br>
							<asp:label id="lblData" runat="server"></asp:label>
							<!-- Main Ends --></td>
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
		</asp:repeater></p>
			<INPUT id="hidInstID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="hidInstID"
				runat="server"> <INPUT id="hidStateID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" value="0"
				name="hidStateID" runat="server"> <INPUT id="hidDistrictID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" value="0"
				name="hidDistrictID" runat="server"> <INPUT id="hidTehsilID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" value="0"
				name="hidTehsilID" runat="server"> <INPUT id="hidUniID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="hidUniID"
				runat="server"> <INPUT id="hidSocTrtID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="hidSocTrtID"
				runat="server">
		</form>
	</body>
</HTML>
