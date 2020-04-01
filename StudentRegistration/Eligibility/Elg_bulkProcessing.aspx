<%@ Register TagPrefix="uc1" TagName="footer" Src="../Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainLink" Src="../SideLinks.ascx" %>
<%@ Register TagPrefix="uc1"  TagName="topLink" Src="../InnerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Elg_StudentBulklisting" Src="WebCtrl/Elg_StudentBulklisting.ascx" %>
<%@ Page language="c#" Codebehind="Elg_bulkProcessing.aspx.cs" AutoEventWireup="True" Inherits="StudentRegistration.Eligibility.Elg_bulkProcessing" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Digital University - Student Registration</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../JS/header.js"></script>
		<script language="javascript" src="../JS/footer.js"></script>
		<script language="javascript" src="../JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="../JS/change.js"></script>
		<script language="javascript" src="../JS/Validations.js"></script>
		<script language="javascript">
		
		function fnSubmit(event)
		{
			if(event.keyCode == 13 || event.keyCode == 9)             //13 - enter key , 9- tab key
			{
				document.getElementById('btnSimpleSearch').focus();	
				document.getElementById('btnSimpleSearch').click();	
				
			}
			
		}
		
		
		//Validating eligibility form number.
		function ChkValidation()
		{
		 var obElg = document.getElementById("tbElgFormNo").value;
		 var ret = true;
		 if(obElg.length > 0)
		 {
		  ret = ChkEligFormNumber(obElg);
		 }
		 else
		 {
		  alert("Please enter the Eligibility Form Number.");
		  ret = false;
		 }
		 return ret;
		}
		
		</script>
</HEAD>
	<body >
		<form id="formElgbulk" method="post" runat="server">
			<div align=center>
				<!-- Header Starts--><uc1:toplink id="TopLink1" runat="server"></uc1:toplink><!-- Header Ends-->
				<table height="48" cellSpacing="0" cellPadding="0" width="95%" border="0">
					<tr height="3">
						<td vAlign="middle" align="center"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
					<tr height="15">
						<td vAlign="middle" align="center" width="10%" rowSpan="2"><IMG height="45" src="../images/CoomingSoon.gif" width="45"></td>
						<td vAlign="top" width="40%"><asp:label id="lblTitle" runat="server" CssClass="PageHeading" Font-Bold="True" Height="8px"
								Width="99%" ForeColor="Tomato">Confirm Eligibility</asp:label></td>
					</tr>
					<TR>
						<TD id="TDLink" style="DISPLAY: none" runat="server"></TD>
					</TR>
					<tr>
						<td class="FormName" vAlign="middle" align="center" colSpan="3"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
				</table>
				<!-- Heading Ends-->
				<!-- Main Starts-->
				<table height="100%" cellSpacing="0" cellPadding="0" width="95%" border="0">
					<TBODY>
						<tr>
							<td class="SideLeft" vAlign="top" align="left" width="18%"> <!--Menu Start Here-->
								<P><uc1:mainlink id="MainLink1" runat="server"></uc1:mainlink></P>
								<!--Menu Ends Here--></td>
							<td vAlign="top" align="left" width="2%">&nbsp;</td>
							<td vAlign="top" align="left" width="80%">
								<table cellSpacing="0" cellPadding="0" border="0">
								</table>
								<div id="divbulkelgdecision" runat="server">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td align="center" colSpan="3">
												<fieldset id="tblselect" align="absMiddle" runat="server">
												 <legend><strong>Select</strong></legend>
													<asp:radiobuttonlist id="rbeligible" runat="server" Height="100px" Width="100px">
														<asp:ListItem Value="0">Eligible</asp:ListItem>
														<asp:ListItem Value="1">Not-Eligible</asp:ListItem>
														<asp:ListItem Value="2">Pending</asp:ListItem>
													</asp:radiobuttonlist>
												</fieldset>
												<asp:label id="lblErrorMsg" style="DISPLAY: none" runat="server" CssClass="GridSubHeading"></asp:label></td>
										</tr>
									</TABLE>
								</div>
								<div id="divAdvSearch" style="DISPLAY: block" runat="server">&nbsp;
									<uc1:Elg_StudentBulklisting id="Elg_StudentBulklisting1" runat="server"></uc1:Elg_StudentBulklisting></div>
							</td>
						</tr>
					</TBODY>
				</table>
				<INPUT id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server">
				<INPUT id="hidSearchType" type="hidden" name="hidSearchType" runat="server">
			</div>
		</form>
	</body>
</HTML>
