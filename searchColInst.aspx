<%@ Page language="c#" Codebehind="searchColInst.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.searchColInst" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Classes.clsGetSettings.Name%>
			| Course Search</title>
		<meta content="Microsoft Visual&#9;Studio .NET&#9;7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<script language="javascript">
			var sChk = 'false';
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
			
			//Programe Level Fill
			function FillPrgLevel(val)
			{               
                
				var PrgTyID= val;
				var UniID=document.getElementById("hidUniID").value;
	        
	            
				if(PrgTyID=="")
					PrgTyID=0;      
				if(UniID=="")
					UniID=0;    

				var strxml = "<pk_PrgTy_ID>"+PrgTyID+"</pk_PrgTy_ID>";   
				strxml += " <pk_Uni_ID>"+UniID+"</pk_Uni_ID>";

	            
				var cmbName=document.getElementById("ddl_PrLvl");
	                

				XMLSP(cmbName,"ID_ListProgramLevelPrgTypeWise",strxml,"Y"); 
	            
				var objOption = document.createElement("option");
				objOption.text = "Any";
				objOption.value = "0";
				cmbName.options[0]=objOption;       
				cmbName.selectedIndex=0;
			} 
			
			function fnShow()
			{
				tbl=document.getElementById("chkSelect");
				
				//Location
				if(tbl.rows[0].cells[0].childNodes[0].checked)
				{
					document.getElementById("tblLocation").style.display="inline";					
				}
				else
				{
					document.getElementById("tblLocation").style.display="none";
				}
				//Faculty
				if(tbl.rows[1].cells[0].childNodes[0].checked)
				{ sChk = 'true';
					document.getElementById("tblFac").style.display="inline";					
				}
				else
				{
					document.getElementById("tblFac").style.display="none";
				}
				//Course
				if(tbl.rows[2].cells[0].childNodes[0].checked)
				{  sChk = 'true';
					document.getElementById("tblCourse").style.display="inline";
				}
				else
				{
					document.getElementById("tblCourse").style.display="none";
				}
				//Monority
				if(tbl.rows[3].cells[0].childNodes[0].checked)
				{   sChk = 'true';
					document.getElementById("tblMinority").style.display="inline";
				}
				else
				{
					document.getElementById("tblMinority").style.display="none";
				}
				//For
				if(tbl.rows[4].cells[0].childNodes[0].checked)
				{   sChk = 'true';
					document.getElementById("tblFor").style.display="inline";
				}
				else
				{
					document.getElementById("tblFor").style.display="none";
				}
				//Area
				if(tbl.rows[5].cells[0].childNodes[0].checked)
				{
					document.getElementById("tblArea").style.display="inline"; 
				}
				else
				{
					document.getElementById("tblArea").style.display="none";
				}
			}
			/*=======================================================================
			CASES FOR MINORITY STATUS
			IF Minority Status == Minority
				Visible Minority Type 
				Visisble Religion/Language 
					CASES
						1.[IF Minority Type==Religious THEN Religion/Language = Religion]
						2.[IF Minority Type==Linguistic THEN Religion/Language = Language]
			IF Minority Status == Non-Minority	
				Not Visible Minority Type	
				Not Visible Religion/Language	
			=========================================================================*/	
			function setMinorityTypeAndReligion()
			{
				//document.forms[0].Inst_MinorityStatusFlag[0].checked=true;
				if(document.forms[0].Inst_Minority_NonMinorityType[1].checked)
				{
					document.getElementById("TRMinorityType").style.display="none";
				}
				if(document.forms[0].Inst_Minority_NonMinorityType[1].checked)
				{
					document.getElementById("TRMinorityType").style.display="inline";
				}
				else if(document.forms[0].Inst_Minority_NonMinorityType[2].checked)
				{
					document.getElementById("TRMinorityType").style.display="none";
				}
			}				
			
			function fnSetHiddenValue()
			{
				tbl=document.getElementById("chkSelect");
				
				//Location
				if(tbl.rows[0].cells[0].childNodes[0].checked)
				{
					document.getElementById("hidStateID").value=document.getElementById("State_ID").value;
					document.getElementById("hidDistrictID").value=document.getElementById("District_ID").value;				
					document.getElementById("hidTehsilID").value=document.getElementById("Tehsil_ID").value;
				}
				else
				{
					document.getElementById("hidStateID").value="0";
					document.getElementById("hidDistrictID").value="0";				
					document.getElementById("hidTehsilID").value="0";
				}
				//Faculty
				if(tbl.rows[1].cells[0].childNodes[0].checked)
				{   sChk = 'true';
					document.getElementById("hidFacID").value=document.getElementById("ddl_Fac_Desc").value;
				}
				else
				{
					document.getElementById("hidFacID").value="0";
				}
				//Course
				if(tbl.rows[2].cells[0].childNodes[0].checked)
				{ sChk = 'true';
					document.getElementById("hidPrgTyID").value=document.getElementById("ddl_PrTy").value;
					document.getElementById("hidPrgLID").value=document.getElementById("ddl_PrLvl").value;
					document.getElementById("hidCrLID").value=document.getElementById("ddl_CrLvl").value;
				}
				else
				{
					document.getElementById("hidPrgTyID").value="0";
					document.getElementById("hidPrgLID").value="0";
					document.getElementById("hidCrLID").value="0";
				}
				/*//Monority
				if(tbl.rows[3].cells[0].childNodes[0].checked)
				{
					document.getElementById("tblMinority").style.display="inline";
				}
				//For
				if(tbl.rows[4].cells[0].childNodes[0].checked)
				{
					document.getElementById("tblFor").style.display="inline";
				}
				//Area
				if(tbl.rows[5].cells[0].childNodes[0].checked)
				{
					document.getElementById("tblArea").style.display="inline"; 
				}
				*/
				
				
				
			}
			
			function fnDetails(Uni,Inst)
			{
				window.open("uniDetails.aspx?uni="+Uni+"&Inst="+Inst,null,"width=800, height=400,left=100, top=200, resizable = yes, scrollbars = yes");
			}
			
		function newWindow()
		{	
			var sSID=document.getElementById("hidStateID").value;
			var sDID=document.getElementById("hidDistrictID").value;
			var sTID=document.getElementById("hidTehsilID").value;
			var sFID=document.getElementById("hidFacID").value;
			var sPTID=document.getElementById("hidPrgTyID").value;
			var sPLID=document.getElementById("hidPrgLID").value;
			var sCLID=document.getElementById("hidCrLID").value;
			tbl=document.getElementById("chkSelect");
				if(!tbl.rows[0].cells[0].childNodes[0].checked)
				{
					sSID="0";
					sDID="0";				
					sTID="0";
				}
		
			if(sSID!="" && sSID!=null && sDID!="" && sDID!=null && sTID!="" && sTID!=null)
			{	
				var url="searchColInst_print.aspx?SID="+sSID+"&DID="+sDID+"&TID="+sTID+"&FID="+sFID+"&PTID="+sPTID+"&PLID="+sPLID+"&CLID="+sCLID+"&Chk="+sChk;
				window.open(url,'','toolbar=no,resizable=yes,location=no,scrollbars=yes,status=yes,width=950,height=650');
			}
			else
				alert("Select Valid State, District And Taluka");
			  document.getElementById("hlPrint").style.display="none";	
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
										<p align="left"><asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label>
										<P></P>
									</td>
									<td vAlign="top" align="left" width="1%"><uc1:sublinkusercontrol id="UCSubLink" runat="server"></uc1:sublinkusercontrol></td>
								</tr>
							</table>
							<!-- Main Starts -->
							<p style="MARGIN-TOP: 10px; MARGIN-BOTTOM: 20px; MARGIN-LEFT: 5px" align="left"><asp:checkboxlist id="chkSelect" runat="server" Width="100%">
									<asp:ListItem Value="1" Selected="True">Include search by location</asp:ListItem>
									<asp:ListItem Value="2">Include search by Faculty available</asp:ListItem>
									<asp:ListItem Value="3">Include search by Course available</asp:ListItem>
									<asp:ListItem Value="4">Show Minority College/Institutes having Minority Status</asp:ListItem>
									<asp:ListItem Value="5">Show College/Institutes for</asp:ListItem>
									<asp:ListItem Value="6">Show only College/Institutes in area</asp:ListItem>
								</asp:checkboxlist></p>
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
							</table>
							<!-- Location Search Ends -->
							<!-- Faculty Search Starts -->
							<table id="tblFac" style="DISPLAY: none" cellSpacing="0" cellPadding="0" width="100%" border="0"
								runat="server">
								<tr>
									<td align="right" width="100%" colSpan="3">
										<hr width="100%" color="#dfdfdf" noShade SIZE="1">
									</td>
								</tr>
								<tr>
									<td align="right" width="30%"><B>Select Faculty</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="ddl_Fac_Desc" runat="server" CssClass="selectBoxHome" Width="206px"></asp:dropdownlist></td>
								</tr>
							</table>
							<!-- Faculty Search Ends -->
							<!-- Course Search Starts -->
							<table id="tblCourse" style="DISPLAY: none" cellSpacing="0" cellPadding="0" width="100%"
								border="0" runat="server">
								<tr>
									<td align="right" width="100%" colSpan="3">
										<hr width="100%" color="#dfdfdf" noShade SIZE="1">
									</td>
								</tr>
								<tr>
									<td align="right" width="30%"><B>Select Program Type</B>
									</td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="ddl_PrTy" onblur="setValue('hidPrgTyID',this.value)" runat="server" CssClass="selectBoxHome"
											Width="304px" OnChange="FillPrgLevel(this.value);"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td style="HEIGHT: 17px" align="right" width="30%"><B>Select Program Level</B>
									</td>
									<td style="HEIGHT: 17px" align="center" width="1%"><B>:</B></td>
									<td style="HEIGHT: 17px" width="69%"><asp:dropdownlist id="ddl_PrLvl" onblur="setValue('hidPrgLID',this.value)" runat="server" CssClass="selectBoxHome"
											Width="304px"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td align="right" width="30%"><B>Select Course Level</B>
									</td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="ddl_CrLvl" onblur="setValue('hidCrLID',this.value)" runat="server" CssClass="selectBoxHome"
											Width="304px"></asp:dropdownlist></td>
								</tr>
							</table>
							<!-- Course Search Ends -->
							<!-- Minority Search Starts -->
							<table id="tblMinority" style="DISPLAY: none" cellSpacing="0" cellPadding="0" width="100%"
								border="0" runat="server">
								<tr>
									<td align="right" width="100%" colSpan="3">
										<hr width="100%" color="#dfdfdf" noShade SIZE="1">
									</td>
								</tr>
								<tr>
									<td align="right" width="30%"><B>Select Type of Minority</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:radiobuttonlist id="Inst_Minority_NonMinorityType" runat="server" Width="400px" RepeatLayout="Flow"
											RepeatDirection="Horizontal">
											<asp:ListItem Value="2" Selected="True">Any</asp:ListItem>
											<asp:ListItem Value="0">Minority</asp:ListItem>
											<asp:ListItem Value="1">Non-Minority</asp:ListItem>
										</asp:radiobuttonlist></td>
								</tr>
								<tr id="TRMinorityType" style="DISPLAY: none" runat="server">
									<td align="right"><b>Select Language/Religion</b></td>
									<td align="center"><b>:</b></td>
									<td><asp:radiobuttonlist id="Inst_MinorityStatusFlag" runat="server" Width="400px" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="R" Selected="True">Religious</asp:ListItem>
											<asp:ListItem Value="L">Linguistic</asp:ListItem>
										</asp:radiobuttonlist></td>
								</tr>
							</table>
							<!-- Minority Search Ends -->
							<!-- For Search Starts -->
							<table id="tblFor" style="DISPLAY: none" cellSpacing="0" cellPadding="0" width="100%" border="0"
								runat="server">
								<tr>
									<td align="right" width="100%" colSpan="3">
										<hr width="100%" color="#dfdfdf" noShade SIZE="1">
									</td>
								</tr>
								<tr>
									<td align="right" width="30%"><B>For</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:radiobuttonlist id="Inst_ForWhomFlag" runat="server" Width="400px" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="0">Boys</asp:ListItem>
											<asp:ListItem Value="1">Girls</asp:ListItem>
											<asp:ListItem Value="2" Selected="True">Co-Education</asp:ListItem>
										</asp:radiobuttonlist></td>
								</tr>
							</table>
							<!-- For Search Ends -->
							<!-- Area Search Starts -->
							<table id="tblArea" style="DISPLAY: none" cellSpacing="0" cellPadding="0" width="100%"
								border="0" runat="server">
								<tr>
									<td align="right" width="100%" colSpan="3">
										<hr width="100%" color="#dfdfdf" noShade SIZE="1">
									</td>
								</tr>
								<tr>
									<td align="right" width="30%"><B>Area</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:radiobuttonlist id="Inst_AreaCodeFlag" runat="server" Width="352px" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="U" Selected="True">Urban</asp:ListItem>
											<asp:ListItem Value="S">Semi-Urban</asp:ListItem>
											<asp:ListItem Value="R">Rural</asp:ListItem>
											<asp:ListItem Value="T">Tribal</asp:ListItem>
										</asp:radiobuttonlist></td>
								</tr>
							</table>
							<!-- Area Search Ends -->
							<p style="MARGIN-TOP: 5px; MARGIN-BOTTOM: 15px" align="center"><asp:button id="btnSearch" runat="server" CssClass="ButSp" Text="Search"></asp:button></p>
							<br>
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
							<p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 10px" align="center"><asp:datagrid id="dgData" runat="server" Width="99%" AutoGenerateColumns="False" AllowPaging="True">
									<AlternatingItemStyle CssClass="gridAltItemHome"></AlternatingItemStyle>
									<ItemStyle CssClass="gridItemHome"></ItemStyle>
									<HeaderStyle CssClass="gridHeaderHome"></HeaderStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="pk_Inst_ID" HeaderText="pk_Inst_ID"></asp:BoundColumn>
										<asp:BoundColumn HeaderText="Sr.No.">
											<HeaderStyle Width="2%" CssClass="gridHeaderHome"></HeaderStyle>
											<ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Inst_Name" HeaderText="Name">
											<HeaderStyle Width="25%" CssClass="gridHeaderHome"></HeaderStyle>
											<ItemStyle VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="SocTrt_Name" HeaderText="Parent Body">
											<HeaderStyle Width="25%" CssClass="gridHeaderHome"></HeaderStyle>
											<ItemStyle VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Address" HeaderText="Address">
											<HeaderStyle Width="25%" CssClass="gridHeaderHome"></HeaderStyle>
											<ItemStyle VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="District_Name" HeaderText="District">
											<HeaderStyle Width="10%" CssClass="gridHeaderHome"></HeaderStyle>
											<ItemStyle VerticalAlign="Middle"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn></asp:BoundColumn>
									</Columns>
									<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
								</asp:datagrid></p>
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
			<INPUT id="hidUniID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="hidUniID"
				runat="server"> <INPUT id="hidStateID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" value="0"
				name="hidStateID" runat="server"> <INPUT id="hidDistrictID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" value="0"
				name="hidDistrictID" runat="server"> <INPUT id="hidTehsilID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" value="0"
				name="hidTehsilID" runat="server"> <INPUT id="hidFacID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" value="0"
				name="hidFacID" runat="server"> <INPUT id="hidPrgTyID" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
				name="hidPrgTyID" runat="server"> <INPUT id="hidPrgLID" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
				name="hidPrgLID" runat="server"> <INPUT id="hidCrLID" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
				name="hidCrLID" runat="server">
		</form>
	</body>
</HTML>
