<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElgResolve_ProvisionalEligibility_Inst_Student_Search.aspx.cs" Inherits="StudentRegistration.Eligibility.ElgResolve_ProvisionalEligibility_Inst_Student_Search" %>

<%@ Register Src="schInst.ascx" TagName="schInst" TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="../Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainLink" Src="../SideLinks.ascx" %>
<%@ Register TagPrefix="uc1"  TagName="topLink" Src="../InnerHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head id="Head1" runat="server">
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
</head>
<body>
    <form id="form1" runat="server">
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
				<table cellSpacing="0" cellPadding="0" width="90%" border="0" height="410">
					<TBODY>
						<tr>
							<td class="SideLeft" vAlign="top" align="left" width="18%" style="height: 509px"> <!--Menu Start Here-->
								<P><uc1:mainlink id="MainLink1" runat="server"></uc1:mainlink></P>
								<!--Menu Ends Here--></td>
							<td vAlign="top" align="left" width="2%" style="height: 509px">&nbsp;</td>							
							<td vAlign="top" align="left" width="80%">
                                <p style="MARGIN: 0px 5px" align="right">
                                 <table width="100%" cellpadding="0" cellspacing="0" border="0" id="tblUserControl">
                                    <tr>
                                        <td align=center style="height: 151px">
                                            <uc2:schInst ID="SchInst1" runat="server"/>
                                        </td>
                                    </tr>
                                 </table>
                                 <p style="MARGIN-TOP: 10px; MARGIN-BOTTOM: 1px; MARGIN-LEFT: 0px" align="center"><asp:label id="lblGridName" runat="server" cssclass="GridSubHeading" width="95%" height="18px"></asp:label></p>
                                 <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; MARGIN-LEFT: 0px" align="center"><asp:datagrid id="dgData" runat="server" cssclass="grid" width="95%" autogeneratecolumns="False"
	                                    allowpaging="True" pagesize="25" OnItemCommand="dgData_ItemCommand" OnPageIndexChanged="dgData_PageIndexChanged">
	                                    <alternatingitemstyle cssclass="gridAltItem"></alternatingitemstyle>
	                                    <itemstyle cssclass="gridItem"></itemstyle>
	                                    <columns>
		                                    <asp:buttoncolumn text="&lt;img border='0' src='../images/pencil.gif' width='16' height='16'&gt;" headertext="Select"
			                                    commandname="lnkButSelect">
			                                    <headerstyle width="5%" cssclass="gridHeader" HorizontalAlign=Center></headerstyle>
			                                    <itemstyle font-bold="True" horizontalalign="Center" forecolor="#FF3333" verticalalign="Middle"></itemstyle>
		                                    </asp:buttoncolumn>
		                                    <asp:boundcolumn visible="False" datafield="pk_Inst_ID" headertext="pk_Inst_ID">
			                                    <headerstyle width="0%" cssclass="gridHeader"></headerstyle>
		                                    </asp:boundcolumn>
		                                    <asp:boundcolumn datafield="InstName" headertext="Name">
			                                    <headerstyle width="80%" cssclass="gridHeader" HorizontalAlign=Center></headerstyle>
		                                    </asp:boundcolumn>
		                                    <asp:boundcolumn datafield="InstTy_Name" headertext="Type">
			                                    <headerstyle width="15%" cssclass="gridHeader" HorizontalAlign=Center></headerstyle>
		                                    </asp:boundcolumn>
	                                    </columns>
	                                    <pagerstyle verticalalign="Middle" font-bold="True" horizontalalign="Right" mode="NumericPages"></pagerstyle>
                                    </asp:datagrid></p>
                                   <div align="center"><asp:label id="lblData" runat="server" forecolor="Tomato" font-bold="True" width="99%" visible="False">No Record Found</asp:label>&nbsp;</div>
                                   <input id="hidInstID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidInstID" runat="server"/>
                                   <input id="hidUniID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidUniID" runat="server"/>
                        </tr>
                        <TR>
						<TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					</TR>
					</TBODY>
				</table>
			<!--Main Ends-->
				<!-- Footer Starts--><uc1:footer id="Footer1" runat="server"></uc1:footer><!-- Footer Ends-->	
				&nbsp;&nbsp;&nbsp;
			</div>
    </form>
</body>
</html>
