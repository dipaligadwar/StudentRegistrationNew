<%@ Register TagPrefix="uc1" TagName="ucFooter" Src="ucFooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucHeader" Src="ucHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucUniversityServices" Src="ucUniversityServices.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucStudentPRN" Src="ucStudentPRN.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucStudentPhoto" Src="ucStudentPhoto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucGoldPlusServices" Src="ucGoldPlusServices.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucChannel" Src="ucChannel.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucStudentName" Src="ucStudentName.ascx" %>
<%@ Page language="c#" Codebehind="STSetDefaultTemplate.aspx.cs" AutoEventWireup="True" Inherits="SOADelivery.STSetDefaultTemplate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>
			<%=Classes.clsGetSettings.Name%>
			| SOADelivery- STSetDefault Template </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="JS/ypSlideOutMenusC.js"></script>
		<script language="javascript" src="JS/jscript_validations.js"></script>
		<link href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<link href="CSS/Services.css" type="text/css" rel="stylesheet">
		<script>
			function SelectedTemplates(chkBox)
			{
				
				document.getElementById("hid_DefaultTemplate").value = chkBox;
							
				
			}
			function showPreview(path)
			{			
				var win = window.open(path,null,"resizable=1,top=0,left=0,width="+ screen.availWidth +" height="+ screen.availHeight);
			}			
		</script>
	</head>
	<body leftmargin="0" topmargin="0" rightmargin="0">
		<form id="form1" method="post" runat="server">
			<div align="center">
				<table id="table1" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="2"
					width="900">
					<tr>
						<td colspan="5"></td>
					<tr>
						<td colspan="5" height="10"><uc1:ucheader id="UcHeader1" runat="server"></uc1:ucheader></td>
					</tr>
					<tr>
						<td valign="top" width="170"><uc1:ucstudentphoto id="UcStudentPhoto1" runat="server"></uc1:ucstudentphoto><uc1:ucstudentname id="UcStudentName1" runat="server"></uc1:ucstudentname><uc1:ucstudentprn id="UcStudentPRN1" runat="server"></uc1:ucstudentprn><uc1:ucuniversityservices id="UcUniversityServices1" runat="server"></uc1:ucuniversityservices><uc1:ucgoldplusservices id="UcGoldPlusServices1" runat="server"></uc1:ucgoldplusservices><uc1:ucchannel id="UcChannel1" runat="server"></uc1:ucchannel></td>
						<td></td>
						<td valign="top" align="center" width="725" colspan="3" height="380">
							<table cellspacing="1" cellpadding="1" width="100%">
								<tbody>
									<tr>
										<td>
											<p align="right">
												<asp:label id="MsgLabel" runat="server" font-bold="True" width="99%"></asp:label></p>
										</td>
									</tr>
									<tr>
										<td><asp:label id="lblNote" runat="server" font-names="Verdana" font-bold="True" width="99%" font-size="8pt">Select the template to set it as default.</asp:label></td>
									</tr>
									<tr>
										<td id="TDContainer" runat="server"></td>
									</tr>
									<tr>
										<td>
											<p align="center"><input style="BORDER-RIGHT:#000000 1px solid; BORDER-TOP:#000000 1px solid; FONT-WEIGHT:bolder; FONT-SIZE:8pt; BORDER-LEFT:#000000 1px solid; BORDER-BOTTOM:#000000 1px solid; BACKGROUND-COLOR:#e0e0e0"
													type="reset" value="Reset">
												<asp:button id="butSave" runat="server" font-bold="True" font-size="8pt" font-names="Verdana"
													text="Save" borderstyle="Solid" backcolor="#E0E0E0" borderwidth="1px" onclick="butSave_Click"></asp:button><input id="hid_DefaultTemplate" type="hidden" name="hid_DefaultTemplate" runat="server"
													style="WIDTH: 34px; HEIGHT: 22px"></p>
										</td>
									</tr>
								</tbody>
							</table>
						</td>
					</tr>
					<tr>
						<td colspan="5" height="1"><uc1:ucfooter id="UcFooter1" runat="server"></uc1:ucfooter></td>
					</tr>
					<tr>
						<td colspan="5"></td>
					</tr>
				</table>
				<!--
				<asp:repeater id="mnuReapeater" runat="server">
			<headertemplate>
						<script language="javascript"> 
					</HeaderTemplate>					
						<ItemTemplate>
				
					var sWidth=0;
				
					var pos="right";
								if(parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "Service_Channel_ID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>').offsetWidth)))+170 < screen.width)
								{
									sWidth = parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "Service_Channel_ID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>').offsetWidth)));
								}
								else
								{
									pos="left";
									sWidth= parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "Service_Channel_ID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>').offsetWidth)))-335;
								}			
							new ypSlideOutMenu("menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>", pos,sWidth ,parseInt(document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>').offsetTop+document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "Service_Channel_ID")%>').offsetTop),170,document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>Content')?document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "Service_Category_ID")%>Content').offsetHeight:0);


						</ItemTemplate>
				<FooterTemplate> 
					ypSlideOutMenu.writeCSS();				
						</script>
				</FooterTemplate>			
		</asp:repeater>
	-->
			</div>
		</form>
	</body>
</html>
