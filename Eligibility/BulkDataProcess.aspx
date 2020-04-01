<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkDataProcess.aspx.cs" Inherits="StudentRegistration.Eligibility.BulkDataProcess" %>
<%@ Register TagPrefix="uc1"  TagName="topLink" Src="../InnerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainLink" Src="../SideLinks.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="../Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Bulk Data Processing</title>
    	<LINK href="../CSS/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../JS/header.js"></script>
		<script language="javascript" src="../JS/footer.js"></script>
		<script language="javascript">
		function ShowGrid()
		{
		document.getElementById("tblGrid").style.display = "inline";
		}
		</script>
</head>
<body>
    <form id="frmBulkProcess" runat="server">
    <div align="center">
    <!-- Header Starts--><uc1:toplink id="TopLink1" runat="server"></uc1:toplink><!-- Header Ends-->
				<!-- Heading Starts-->
				<table  cellSpacing="0" cellPadding="0" width="90%" border="0">
					<tr height="3">
						<td vAlign="middle" align="center"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
					<tr height="15">
						<td rowspan="2" vAlign="middle" align="center" width="20%"><IMG height="45" src="../images/CoomingSoon.gif" width="45"></td>
						<td vAlign="bottom" width="40%" style="HEIGHT: 17px" align="left">
										<B><FONT class="PageHeading">
												Bulk Data Processing for College</FONT></B><asp:Label id="lblwelcome" Runat="server" Font-Bold="True" ></asp:Label>
											
						</td>
						<TD vAlign="bottom" width="40%" style="HEIGHT: 17px">
							</TD>
					</tr>
					<TR height="30">
						<TD vAlign="bottom" width="100%" colspan="4" align="left">&nbsp;</TD>
					</TR>
					<tr>
						<td class="FormName" vAlign="middle" align="center" colSpan="3"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
				</table>
				<!-- Heading Ends-->
				<!-- Main Starts-->
				<table height="410" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<tr>
						<td class="SideLeft" vAlign="top" align="left" width="18%">
							<!--Menu Start Here-->
							<P><uc1:mainlink id="MainLink1" runat="server"></uc1:mainlink></P>
							<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							</P>
							<!--Menu Ends Here--></td>
						
						<td vAlign="top" align="left" width="80%" height="20" colspan="">
							<!-- Toolbar Starts--> <!-- Toolbar Ends--><br>
							<!-- Fields Starts-->
							<table border="0" cellpadding="0" cellspacing="3" width="100%" height="100%">
							<tr>
								<td align="right" colspan="3" style="height: 14px"><asp:label id="lblSave" runat="server" font-bold="True" CssClass="saveNote"></asp:label></td>
							</tr>
							<tr>
								<td style="WIDTH: 285px" valign="top" align="center" colspan="3">								
                                </td>
							</tr>														
							<tr>
								<td style="WIDTH: 285px" valign="top" align="right"><strong>Select Institute</strong></td>
								<td width="1%"><strong>:</strong></td>
								<td style="HEIGHT: 15px" align="left">
								<asp:dropdownlist id="DD_Inst" runat="server" width="260px" CssClass="SelectBox">
								<asp:ListItem>---Select---</asp:ListItem>
								<asp:ListItem>Law College</asp:ListItem></asp:dropdownlist>
								<font class="Mandatory">*</font></td>
							</tr>
							<tr>
								<td style="WIDTH: 285px" valign="top" align="right"><strong>Select Course</strong></td>
								<td width="1%"><strong>:</strong></td>
								<td style="HEIGHT: 12px" align="left">
								<asp:dropdownlist id="DD_Course" runat="server" width="260px" CssClass="SelectBox">
								<asp:ListItem>---Select---</asp:ListItem>
								<asp:ListItem>B.Com-Regular-Pattern-2005</asp:ListItem></asp:dropdownlist>
								<font class="Mandatory">*</font></td>
							</tr>	
							<tr><td colspan="3"></td></tr>
							<tr>
								<td style="WIDTH: 285px" valign="top" align="right"></td>
								<td width="1%"></td>
								<td style="HEIGHT: 12px" align="left">
                                    <asp:Button ID="btnProcessData" runat="server" CssClass="butSubmit" BorderWidth="1px"
									BorderStyle="Solid" Text="Bulk Process" Height="18px" OnClick="btnProcessData_Click"/></td>
							</tr>
							<tr><td colspan="3"></td></tr>
							<tr><td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="lblGrid" runat="server" CssClass="errorNote"></asp:label></td></tr>
						    <tr><td colspan="3"></td></tr>
						    </table>
						    <table bordercolor="#336699" border="1" style="border-collapse:collapse;" align="center" runat="server" id="tblGrid" cellpadding="0" cellspacing="0" width="90%" height="100%" visible="false">
						     <tr class="GridHeading">
						    <td width="5%" height="25">Sr.No.</td><td width="10%">Eligibility Form No</td>
						    <td width="10%">Student Name</td><td width="10%">Course Attached to</td>	
						    <td width="10%">No. of Documents Attached</td>	
						    			    
						    </tr>
						    <tr class="GridData2" height="20"> <td>1.</td><td>179-183-2007-572</td>
						    <td>More Jyotsna Namdeo</td><td>BCom</td><td>1</td>
						    </tr>
						    <tr class="GridData2" height="20"> <td>2.</td><td>179-183-2007-573</td>
						    <td>Kale Anil Tukaram</td><td>BCom</td><td>1</td>
						    </tr>
						    <tr class="GridData2" height="20"> <td>3.</td><td>179-183-2007-574</td>
						    <td>More Prasad Namdeo</td><td>BCom</td><td>1</td>
						    </tr>
						    <tr class="GridData2" height="20"> <td>2.</td><td>179-183-2007-575</td>
						    <td>More Yogesh Namdeo</td><td>BCom</td><td>1</td>
						    </tr>
						    <tr><td colspan="5" align="right"><font color="blue">< 1 2 3 ></font></td></tr>
						    </table>
							
						</td>
						
						
					</tr>
					<TR>
						<TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					</TR>
				</table>
				<!--Main Ends-->
				<!-- Footer Starts--><!-- Footer Ends-->
				
    </div>
    </form>
</body>
</html>
