<%@ Page language="c#" Codebehind="frmRecognisedFacultyWiseColleges.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.frmRecognisedFacultyWiseColleges" %>
<%@ Register TagPrefix="uc1" TagName="InnerMenuControl" Src="InnerMenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SubLinkUserControl" Src="SubLinkUserControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Classes.clsGetSettings.Name%>
			| Faculty Wise Recognised Colleges</title>
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
			
			//Fill District
			function FillDistricts(StateID,LangFlag,TargetDropDownName)
			{				
					var strxml = "<State_ID>"+StateID+"</State_ID>";   
					strxml += "	<Lang_Flag>"+LangFlag+"</Lang_Flag>";					 
					var dropDownName=document.getElementById(TargetDropDownName);
					XMLSP(dropDownName,"GEN_stateWiseDistricts",strxml,"Y");
			}
		
			function fnDetails(Uni,Inst)
			{
				var SitePath = '<%=Classes.clsGetSettings.SitePathCourse%>';
				window.open("uniDetails.aspx?uni="+Uni+"&Inst="+Inst,null,"width=800, height=400,left=100, top=200, resizable = yes, scrollbars = yes");
			}
		
			function callValidate()
			{
				
				var i=-1;
				var myArr= new Array();
				
				document.getElementById("Faculty_ID").value=Trim(document.getElementById("Faculty_ID").value);
				
				myArr[++i]= new Array(document.getElementById("Faculty_ID"),"0","Select Faculty","select");
				
				var ret=validateMe(myArr,50);
				/*if(ret==false)
					bolReturn=false;*/
				return ret;		
			}
			
			
			function newWindow()
			{	
				
			var sFac_ID=document.getElementById("hidFacID").value;
			
			if(sFac_ID!="" && sFac_ID!=null && sFac_ID!="0")
			{
				  var url="frmRecognisedFacultyWiseColleges_print.aspx?Fac_ID="+sFac_ID;
				  window.open(url,'','toolbar=no,resizable=yes,location=no,scrollbars=yes,status=yes,width=950,height=650');
			}
			else
			{
				alert("Select a valid Faculty");
			}
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
									<td align="right" width="35%"><B>Select Faculty</B></td>
									<td align="center" width="1%"><B>:</B></td>
									<td width="69%"><asp:dropdownlist id="Faculty_ID" runat="server" CssClass="selectBoxHome" Width="298px" onChange="setValue('hidFacID',this.value);"></asp:dropdownlist><INPUT id="hidFacID" style="WIDTH: 35px; HEIGHT: 22px" type="hidden" size="1" runat="server"
											NAME="hidStateID"></td>
								</tr>
							</table>
							<!-- Location Search Ends -->
							<!-- Parent Search Starts -->
							<p style="MARGIN-TOP: 5px; MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px" align="center"><asp:button id="btnSearch" runat="server" CssClass="ButSp" Text="Search"></asp:button></p>
							<table width="100%" align="center">
								<TR>
									<TD align="left" width="10%"><a id="hlPrint" runat="server" onclick="newWindow();" onmouseover="this.style.cursor='Hand'"
											onmouseout="this.style.cursor='Arrow'" style="FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #666666; FONT-FAMILY: Verdana; TEXT-DECORATION: underline">
											Print Report</a>
										<br>
										<asp:label id="lblDisplay" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
								<tr>
									<td align="center" width="100%">
										<asp:datagrid id="dgData" runat="server" AllowSorting="True" Font-Size="10pt" Font-Names="Verdana"
											AutoGenerateColumns="False" Width="100%" AllowPaging="True">
											<AlternatingItemStyle CssClass="gridAltItemHome"></AlternatingItemStyle>
											<ItemStyle CssClass="gridItemHome"></ItemStyle>
											<HeaderStyle Font-Size="10pt" HorizontalAlign="Center" CssClass="gridHeaderHome"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="pk_Uni_ID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="pk_Inst_ID"></asp:BoundColumn>
												<asp:BoundColumn HeaderText="Sr. No">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="7%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Inst_Name" HeaderText="College Name">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="30%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ParBdy_Name" HeaderText="Parent Body">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="15%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Address" HeaderText="Address">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="20%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="District_Name" HeaderText="District">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="10%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn HeaderText="View Details">
													<HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="10%" CssClass="gridHeaderHome"></HeaderStyle>
													<ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
										</asp:datagrid>
									</td>
								</tr>
								<tr>
									<td>
										<asp:Label id="lblData" runat="server" Width="655px" Height="16px"></asp:Label>
									</td>
								</tr>
							</table>
							<!-- Parent Search Ends -->
							<!-- Main Ends --></td>
					</tr>
					<tr>
						<td colSpan="3"><INPUT id="hidUniID" style="WIDTH: 41px; HEIGHT: 22px" type="hidden" size="1" runat="server"
								NAME="hidUniID"></td>
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
