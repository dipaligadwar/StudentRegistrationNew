<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Page language="c#" Codebehind="frmCourseWiseColleges.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.frmCourseWiseColleges" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=UniversityPortal.clsGetSettings.Name%>
			| Course Wise Colleges</title>
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
				//alert(Value);
			}
			
			
		function FillProgramLevel(val)
        {               
                
            var PrgTyID= val;
            var UniID=document.getElementById("hidUniID").value;
        
            
            if(PrgTyID=="")
                PrgTyID=0;      
            if(UniID=="")
                UniID=0;    

            var strxml = "<pk_PrgTy_ID>"+PrgTyID+"</pk_PrgTy_ID>";   
            strxml += " <pk_Uni_ID>"+UniID+"</pk_Uni_ID>";

            
            var cmbName=document.getElementById("PrL_ID");
                

            XMLSP(cmbName,"ID_ListProgramLevelPrgTypeWise",strxml,"Y"); 
            
            var objOption = document.createElement("option");
            objOption.text = "Any";
            objOption.value = "0";
            cmbName.options[0]=objOption;       
            cmbName.selectedIndex=0;
        } 
        
        function fnSetHiddenValue()
        {	//		
			document.getElementById("hidPrTyID").value=document.getElementById("PrTy_ID").value;
			document.getElementById("hidPrLID").value=document.getElementById("PrL_ID").value;
			document.getElementById("hidCrLID").value=document.getElementById("CrL_ID").value;
			document.getElementById("tblLocation").style.display="inline";
			
        }
        
        
        function fnDetails(Uni,Inst)
		{
			//alert(Uni);
			//alert(Inst);
			var SitePath = '<%=UniversityPortal.clsGetSettings.SitePathCourse%>';
			window.open("uniDetails.aspx?uni="+Uni+"&Inst="+Inst,null,"width=800, height=400,left=100, top=200, resizable = yes, scrollbars = yes");
		}
	
	function newWindow()
		{				
			var sProgLvlID=document.getElementById("hidPrLID").value;
			var sCrLvlID=document.getElementById("hidCrLID").value;
			var sProgTypeID=document.getElementById("hidPrTyID").value;
			
			if(sProgTypeID=="") 
				sProgTypeID=0;
			if( sCrLvlID=="" )
				sCrLvlID=0;
			if(sProgLvlID=="")
				sProgLvlID=0;
			
			var url="frmCourseWiseColleges_print.aspx?ProgTypeID="+sProgTypeID+"&ProgLvlID="+sProgLvlID+"&CrLvlID="+sCrLvlID;
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
							<p style="MARGIN-TOP: 5px; MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px" align="left">&nbsp;</p>
							<!-- Location Search Starts -->
							<table id="tblLocation" style="DISPLAY: inline" cellSpacing="0" cellPadding="0" width="100%"
								border="0" runat="server">
								<tr>
									<td align="right" width="35%"><B>Select Program Type</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="PrTy_ID" onblur="setValue('hidPrTyID',this.value);" runat="server" CssClass="selectBoxHome"
											onChange="setValue('hidPrTyID',this.value);FillProgramLevel(this.value);" Width="206px"></asp:dropdownlist><INPUT id="hidPrTyID" style="WIDTH: 35px; HEIGHT: 22px" type="hidden" size="1" runat="server"></td>
								</tr>
								<tr>
									<td align="right" width="35%"><B>Select Program Level</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="PrL_ID" onblur="setValue('hidPrLID',this.value);" runat="server" CssClass="selectBoxHome"
											onChange="setValue('hidPrLID',this.value);" Width="206px"></asp:dropdownlist><INPUT id="hidPrLID" style="WIDTH: 35px; HEIGHT: 22px" type="hidden" size="1" runat="server"></td>
								</tr>
								<tr>
									<td align="right" width="35%"><B>Select Course Level</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="CrL_ID" onblur="setValue('hidCrLID',this.value);" runat="server" CssClass="selectBoxHome"
											onChange="setValue('hidCrLID',this.value);" Width="206px"></asp:dropdownlist><INPUT id="hidCrLID" style="WIDTH: 35px; HEIGHT: 22px" type="hidden" size="1" runat="server"></td>
								</tr>
							</table>
							<!-- Location Search Ends -->
							<!-- Parent Search Starts -->
							<p style="MARGIN-TOP: 5px; MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px" align="center"><asp:button id="btnSearch" runat="server" CssClass="ButSp" Text="Search"></asp:button></p>
							<table width="100%" align="center">
								<TR>
									<TD width="10%"><a id="hlPrint" onmouseover="this.style.cursor='Hand'" style="FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #666666; FONT-FAMILY: Verdana; TEXT-DECORATION: underline"
											onclick="newWindow();" onmouseout="this.style.cursor='Arrow'" runat="server">Print 
											Report</a>
										<br>
										<asp:label id="lblDisplay" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
								<tr>
									<td align="center" width="100%"><asp:datagrid id="dgData" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
											Font-Names="Verdana" Font-Size="10pt" AllowSorting="True">
											<AlternatingItemStyle CssClass="gridAltItemHome"></AlternatingItemStyle>
											<ItemStyle CssClass="gridItemHome"></ItemStyle>
											<HeaderStyle Font-Size="10pt" HorizontalAlign="Center" CssClass="gridHeaderHome"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="pk_Uni_ID" SortExpression="pk_Uni_ID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="pk_Inst_ID" SortExpression="pk_Inst_ID"></asp:BoundColumn>
												<asp:BoundColumn HeaderText="Sr. No">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="7%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Cr_Desc" SortExpression="Cr_Desc" HeaderText="Course">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="20%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Inst_Name" SortExpression="Inst_Name" HeaderText="College Name">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="20%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ParBdy_Name" SortExpression="ParBdy_Name" HeaderText="Parent Body">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="15%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Address" SortExpression="Address" HeaderText="Address">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="15%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="District_Name" SortExpression="District_Name" HeaderText="District">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="10%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn HeaderText="View Details">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="15%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></td>
								</tr>
								<tr>
									<td><asp:label id="lblData" runat="server" Width="687px" Height="18px"></asp:label></td>
								</tr>
							</table>
							<!-- Parent Search Ends -->
							<!-- Main Ends --></td>
					</tr>
					<tr>
						<td colSpan="3"><INPUT id="hidUniID" style="WIDTH: 41px; HEIGHT: 22px" type="hidden" size="1" name="hidUniID"
								runat="server"></td>
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
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</form>
	</body>
</HTML>
