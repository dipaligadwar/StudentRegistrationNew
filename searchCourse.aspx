<%@ Page language="c#" Codebehind="searchCourse.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.searchCourse" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
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
		<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript">        
        //Set value to given field
        function setValue(Text,Value)
        {
            var text = eval(document.getElementById(Text));
            text.value = Value;
        }
        
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
            
            //Faculty
            if(tbl.rows[0].cells[0].childNodes[0].checked)
            {
                document.getElementById("tblFac").style.display="inline";
            }
            else
            {
                document.getElementById("tblFac").style.display="none";
            }
            
            //Other
            if(tbl.rows[1].cells[0].childNodes[0].checked)
            {
                document.getElementById("tblFac").style.display="inline";
                document.getElementById("tblOther").style.display="inline";
            }
            else
            {
                document.getElementById("tblOther").style.display="none";
            }
            
            //Include Mode of learning
            if(tbl.rows[2].cells[0].childNodes[0].checked)
            {
                document.getElementById("tblFac").style.display="inline";
                document.getElementById("tblMode").style.display="inline";
            }
            else
            {
                document.getElementById("tblMode").style.display="none";
            }
        }
        
        function fnSetHiddenValue()
        {
			tbl=document.getElementById("chkSelect");
			var icnt=0;
			for(i=0;i<tbl.rows.length;i++)
			{
				if(tbl.rows[i].cells[0].childNodes[0].checked)
				icnt++;
			}
			
			if(icnt>0)
			{
				document.getElementById("hidFacID").value=document.getElementById("ddl_Fac_Desc").value;
				document.getElementById("hidPrgTyID").value=document.getElementById("ddl_PrTy").value;
				document.getElementById("hidPrgLID").value=document.getElementById("ddl_PrLvl").value;
				document.getElementById("hidCrLID").value=document.getElementById("ddl_CrLvl").value;
				document.getElementById("hidMode").value=document.getElementById("ddl_Mode").value;
				return true;
			}
			else
			{
				alert("Please select any criteria");
				document.getElementById("lblData").innerText="";
				return false;
			}
			
			return false;
        }
        
        function fnDetails(uu,ff,cc,mm,pp)
        {
			var SitePath = '<%=Classes.clsGetSettings.SitePathCourse%>';
			window.open(SitePath+"uniGetCourseDetails.aspx?u="+uu+"&f="+ff+"&c="+cc+"&m="+mm+"&p="+pp,null,"width=800, height=400,left=100, top=200, resizable = yes, scrollbars = yes");
			
        }
        
        function newWindow()
		{	
			var sFID=document.getElementById("hidFacID").value;
			var sPTID=document.getElementById("hidPrgTyID").value;
			var sPLID=document.getElementById("hidPrgLID").value;
			var sCRLID=document.getElementById("hidCrLID").value;
			var sMODE=document.getElementById("hidMode").value;
			var sPLDesc=document.getElementById("ddl_PrLvl").options[document.getElementById("ddl_PrLvl").selectedIndex].text;
			var sPTDesc=document.getElementById("ddl_PrTy").options[document.getElementById("ddl_PrTy").selectedIndex].text;
			var sMLDesc=document.getElementById("ddl_Mode").options[document.getElementById("ddl_Mode").selectedIndex].text;
			var sCrLDesc=document.getElementById("ddl_CrLvl").options[document.getElementById("ddl_CrLvl").selectedIndex].text;
			var sFacDesc=document.getElementById("ddl_Fac_Desc").options[document.getElementById("ddl_Fac_Desc").selectedIndex].text;
			if(sFID=="")
			sFID=0;
			if(sPTID=="")
			sPTID=0;
			if(sCRLID=="")
			sCRLID=0;
			if(sPLID=="")
			sPLID=0;
			if(sMODE=="")
			sMODE=0;
			var url="searchCourse_print.aspx?FID="+sFID+"&PTID="+sPTID+"&CRLID="+sCRLID+"&PLID="+sPLID+"&MODE="+sMODE+"&PLDesc="+sPLDesc+"&PTDesc="+sPTDesc+"&MLDesc="+sMLDesc+"&CrLDesc="+sCrLDesc+"&FacDesc="+sFacDesc;
			window.open(url,'','toolbar=no,resizable=yes,location=no,scrollbars=yes,status=yes,width=950,height=650');
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
										<p align="left"><asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label></p>
									</td>
									<td vAlign="top" align="left" width="1%"><uc1:sublinkusercontrol id="UCSubLink" runat="server"></uc1:sublinkusercontrol></td>
								</tr>
							</table>
							<!-- Main Starts -->
							<p style="MARGIN-TOP: 10px; MARGIN-BOTTOM: 20px; MARGIN-LEFT: 5px" align="left"><asp:checkboxlist id="chkSelect" runat="server" Width="100%">
									<asp:ListItem Value="1" Selected="True">Show courses under a specific faculty (e.g. Faculty of Science, Faculty of Law, …)</asp:ListItem>
									<asp:ListItem Value="2">Show courses meeting following criteria</asp:ListItem>
									<asp:ListItem Value="3">Include ‘Mode of Learning’ in my search (e.g. Regular, External, …)</asp:ListItem>
								</asp:checkboxlist></p>
							<!-- Faculty Search Starts -->
							<table id="tblFac" style="DISPLAY: inline" cellSpacing="0" cellPadding="0" width="99%"
								border="0" runat="server">
								<tr>
									<td align="right" width="30%"><B>Select Faculty </B>
									</td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="ddl_Fac_Desc" onblur="setValue('hidFacID',this.value)" runat="server" CssClass="selectBoxHome"
											Width="304px"></asp:dropdownlist></td>
								</tr>
							</table>
							<!-- Faculty Search Ends -->
							<!-- Other Search Starts -->
							<table id="tblOther" style="DISPLAY: none" cellSpacing="0" cellPadding="0" width="99%"
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
									<td align="right" width="30%"><B>Select Program Level</B>
									</td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="ddl_PrLvl" onblur="setValue('hidPrgLID',this.value)" runat="server" CssClass="selectBoxHome"
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
							<!-- Other Search Ends -->
							<!-- Mode of Learning Search Starts -->
							<table id="tblMode" style="DISPLAY: none" cellSpacing="0" cellPadding="0" width="99%" border="0"
								runat="server">
								<tr>
									<td align="right" width="100%" colSpan="3">
										<hr width="100%" color="#dfdfdf" noShade SIZE="1">
									</td>
								</tr>
								<tr>
									<td align="right" width="30%"><B>Select Mode of Learning </B>
									</td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="ddl_Mode" onblur="setValue('hidMode',this.value)" runat="server" CssClass="selectBoxHome"
											Width="304px"></asp:dropdownlist></td>
								</tr>
							</table>
							<!-- Other Search Ends -->
							<p style="MARGIN-TOP: 5px; MARGIN-BOTTOM: 15px" align="center"><asp:button id="btnSearch" runat="server" CssClass="ButSp" Text="Search"></asp:button></p>
							<table>
								<tr>
									<TD align="left" width="10%"><a id="hlPrint" runat="server" onclick="newWindow();" onmouseover="this.style.cursor='Hand'"
											onmouseout="this.style.cursor='Arrow'" style="FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #666666; FONT-FAMILY: Verdana; TEXT-DECORATION: underline">
											Print Report</a>
									</TD>
								</tr>
							</table>
							<br>
							<asp:Label id="lblData" runat="server"></asp:Label>
							<!-- Main Ends -->
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
        </asp:repeater></p>
			<INPUT id="hidUniID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="hidUniID"
				runat="server"> <INPUT id="hidFacID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="hidFacID"
				runat="server"> <INPUT id="hidPrgTyID" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hidPrgTyID"
				runat="server"> <INPUT id="hidPrgLID" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hidPrgLID"
				runat="server"> <INPUT id="hidCrLID" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hidCrLID"
				runat="server"> <INPUT id="hidMode" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hidMode"
				runat="server">
		</form>
	</body>
</HTML>
