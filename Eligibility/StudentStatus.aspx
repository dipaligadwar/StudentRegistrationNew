<%@ Page language="c#" Codebehind="StudentStatus.aspx.cs" AutoEventWireup="True" Inherits="StudentRegistration.Eligibility.StudentStatus" %>
<%@ Register TagPrefix="uc1" TagName="StudentsStatusSearch" Src="WebCtrl/StudentsStatusSearch.ascx" %>
<%@ Register TagPrefix="uc1"  TagName="topLink" Src="../InnerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainLink" Src="../SideLinks.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="../Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Digital University - Student Registration</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../JS/header.js"></script>
		<script language="javascript" src="../JS/footer.js"></script>
		<script language="javascript" src="../JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="../JS/change.js"></script>
		<script language="javascript" src="../JS/ValidatePRN.js"></script>
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
		
		function fnDisplayDiv(divType)
		{
			if(divType == 'Simple')
			{
				document.getElementById('divSimpleSearch').style.display = 'block';
				document.getElementById('divAdvSearch').style.display = 'none';
				document.getElementById('hidSearchType').value = divType;
				document.getElementById('lblMsg').style.display = 'none';
			}
			else if(divType == 'Adv')
			{
				document.getElementById('divSimpleSearch').style.display = 'none';
				document.getElementById('divAdvSearch').style.display = 'block';
				document.getElementById('hidSearchType').value = divType;
			}
		}
		
		//validation check during onclick of search button
		function ChkValidation()
		{ 								 
		  var obPRN = document.getElementById("txtPRN").value;
		  var obElg = document.getElementById("txtElgFormNo").value;
		  var sStr = obElg.split('-');	
		  var ret=true;
		  if((obPRN.length == 0)&&(obElg.length==0))
		  {
		  alert("Enter a valid PRN or Eligibility Form Number.")
		  ret=false;
		  }
		  
		  else
		  {
		 
		     if(obPRN.length>0)
		     {
				ret = checkdigitPRN(obPRN);
			 }
			 else
			 if(obElg.length>0)
			 {  
			    ret = ChkEligFormNumber(obElg);
			    if(ret == true)
		        {
		            if(sStr[1] == document.getElementById("hidInstID").value)
		            {
		            ret = true;
		            }
		            else
		            {
		            alert(".:The Student is not in selected Institute:.\n Please Enter Correct Form No.");
		            ret = false;
		            }
		        }
			 }
			 else
		     {
		          alert("Please enter the Eligibility Form Number.");
		          ret = false;
		     }
		  }
		   return ret;
		}
		</script>

        <link href="../CSS/UniPortal.css" rel="stylesheet" type="text/css" />
        <link href="../CSS/UniPortal.css" rel="stylesheet" type="text/css" />
        <link href="../CSS/calendar-blue.css" rel="stylesheet" type="text/css" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div align=center>
				<!-- Header Starts--><uc1:toplink id="TopLink1" runat="server"></uc1:toplink><!-- Header Ends-->
				<table height="48" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<tr height="3">
						<td vAlign="middle" align="center"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
					<tr height="15">
						<td vAlign="middle" align="center" width="10%" rowSpan="2"><IMG height="45" src="../images/CoomingSoon.gif" width="45"></td>
						<td vAlign="top" width="40%"><asp:label id="lblTitle" runat="server" CssClass="PageHeading" Font-Bold="True" Height="8px" ForeColor="Tomato"></asp:label><asp:Label ID="lblInstName" runat="server" Font-Bold="True"></asp:Label></td>
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
				<table height="100%" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<TBODY>
						<tr>
							<td class="SideLeft" vAlign="top" align="left" width="18%"> <!--Menu Start Here-->
								<P><uc1:mainlink id="MainLink1" runat="server"></uc1:mainlink></P>
								<!--Menu Ends Here--></td>
							<td vAlign="top" align="left" width="2%">&nbsp;</td>
							<td vAlign="top" align="left" width="80%">
								<table cellSpacing="0" cellPadding="0" border="0">
									<tr>
										<td><label class="NavLink" id="lblSimpleSearch" style="CURSOR: hand" onclick="fnDisplayDiv('Simple');">Simple 
												Search</label>&nbsp;|&nbsp; <label class="NavLink" id="lblAdvSearch" style="CURSOR: hand" onclick="fnDisplayDiv('Adv');">
												Advanced Search</label> 
											<!--<asp:LinkButton id="lnkSimpleSearch" CssClass="NavLink" runat="server">Simple Search</asp:LinkButton>&nbsp;|&nbsp;
											<asp:LinkButton id="lnkAdvSearch" CssClass="NavLink" runat="server">Advanced Search</asp:LinkButton>--></td>
									</tr>
								</table>
								<div id="divSimpleSearch" runat="server">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="right" height="30"><STRONG>Enter&nbsp;PRN</STRONG></TD>
											<TD align="center" width="2%" height="30"><B></B></TD>
											<TD width="58%" height="30"><asp:textbox id="txtPRN" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3"><label><b>OR</b></label>
											</TD>
										</TR>
										<TR>
											<TD align="right" height="30"><STRONG>Enter&nbsp;Eligibility Form Number</STRONG></TD>
											<TD align="center" width="2%" height="30"><B></B></TD>
											<TD width="58%" height="30"><asp:textbox id="txtElgFormNo" runat="server"></asp:textbox></TD>
										</TR>
										<tr>
											<td align="center" colSpan="3"><br>
												<asp:button id="btnSimpleSearch" cssclass="butSubmit" Text="Search" Runat="server" onclick="btnSimpleSearch_Click"></asp:button></td>
										</tr>
										<tr>
											<td align="center" colSpan="3">
												<asp:label id="lblMsg" style="DISPLAY: none" runat="server" CssClass="GridSubHeading"></asp:label></td>
										</tr>
									</TABLE>
								</div>
								<div id="divAdvSearch" style="DISPLAY: none" runat="server">&nbsp;
									<uc1:studentsstatussearch id="StudentsStatusSearch1" runat="server"></uc1:studentsstatussearch>
								</div>
							</td>
						</tr>
						<TR>
						<TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					</TR>
					</TBODY>
				</table>
				<!--Main Ends-->
				<!-- Footer Starts--><uc1:footer id="Footer1" runat="server"></uc1:footer><!-- Footer Ends-->
                <input id="hidpkStudentID" runat="server" name="hidpkStudentID" type="hidden" value="0" />
                <input id="hidpkYear" runat="server" name="hidpkYear" type="hidden" value="0" />
				<INPUT id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server">
				<INPUT id="hidSearchType" type="hidden" name="hidSearchType" runat="server"> 
				<INPUT id="hidPRN" type="hidden" name="hidPRN" runat="server">
                <input id="hidInstID" runat="server" name="hidInstID" style="width: 24px; height: 22px"
                    type="hidden" /><input id="hidUniID" runat="server" name="hidUniID" style="width: 24px;
                        height: 22px" type="hidden" /></div>
		</form>
	</body>
</HTML>
