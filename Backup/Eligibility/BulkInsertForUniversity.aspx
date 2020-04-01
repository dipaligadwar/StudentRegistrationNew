<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkInsertForUniversity.aspx.cs" Inherits="StudentRegistration.Eligibility.BulkInsertForUniversity" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="../Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainLink" Src="../SideLinks.ascx" %>
<%@ Register TagPrefix="uc1"  TagName="topLink" Src="../InnerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="StudentsAdvancedSearch" Src="WebCtrl/StudentsAdvancedSearch.ascx" %>
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
		    function ShowGrid()
		    {
		        document.getElementById("tblGrid").style.display = "inline";
		    }
		</script>
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
						<td vAlign="top" width="40%"><asp:label id="lblTitle" runat="server" CssClass="PageHeading" Font-Bold="True" Height="8px"
								Width="99%" ForeColor="Tomato"> Bulk Process Data For University</asp:label></td>
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
				<table cellSpacing="0" cellPadding="0" width="90%" border="0" height="100%">
					<TBODY>
						<tr>
							<td class="SideLeft" vAlign="top" align="left" width="18%"> <!--Menu Start Here-->
								<P><uc1:mainlink id="MainLink1" runat="server"></uc1:mainlink></P>
								<!--Menu Ends Here--></td>
							<td vAlign="top" align="left" width="2%">&nbsp;</td>
							<td vAlign="top" align="left" width="80%">
                             
                             <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td colspan="3" height="5px"></td>
                                </tr>
                                <tr>
                                    <td align=right colspan="3" height="10px">
                                        <asp:Label ID="lblSave" runat="server" CssClass="SaveNote"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="30%" align=right><b>Select Institute</b></td>
                                    <td width="1%"><b>:</b></td>
                                    <td>
                                        <asp:dropdownlist id="DD_Inst" runat="server" width="260px" CssClass="SelectBox">
								        <asp:ListItem>---Select---</asp:ListItem>
								        <asp:ListItem>Law College</asp:ListItem></asp:dropdownlist>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px"></td>
                                </tr>
                                <tr>
                                    <td width="30%" align=right><b>Select Course</b></td>
                                    <td width="1%"><b>:</b></td>
                                    <td>
                                        <asp:dropdownlist id="DD_Course" runat="server" width="260px" CssClass="SelectBox">
								        <asp:ListItem>---Select---</asp:ListItem>
								        <asp:ListItem>B.Com-Regular-Pattern-2005</asp:ListItem></asp:dropdownlist>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" height="20px"></td>
                                </tr>
                                <tr>
                                    <td colspan="3" align=center style="height: 15px">
                                        <asp:Button ID="btnProcessData" runat="server" CssClass="butSubmit" BorderWidth="1px"
									    BorderStyle="Solid" Text="Bulk Process" Height="18px" OnClick="btnProcessData_Click"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" height="20px"></td>
                                </tr>
                                <tr>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <td colspan="4" style="height: 13px"> <asp:label id="lblGrid" runat="server" CssClass="errorNote"></asp:label></td>
                                </tr>
                                <tr>
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <table bordercolor="#336699" border="1" style="border-collapse:collapse;" align="center" runat="server" id="tblGrid" cellpadding="0" cellspacing="0" width="95%" height="100%" visible=false>
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
                             </table>
						   
						   
							</td>
						</tr>
					</TBODY>
				</table>
				
			</div>
		</form>
	</body>
</HTML>

