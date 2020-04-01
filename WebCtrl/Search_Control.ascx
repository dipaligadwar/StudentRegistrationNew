<%@ Control Language="c#" AutoEventWireup="True" Codebehind="Search_Control.ascx.cs" Inherits="Digital_College.Search_Control" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<HEAD>
	<TITLE>
		<%=System.Configuration.ConfigurationSettings.AppSettings["Name"]%>
		| Serach Admission Form</TITLE>
</HEAD>
<LINK href="CSS/ExtAdmission.css" type="text/css" rel="stylesheet">
<LINK href="../CSS/calendar-blue.css" type="text/css" rel="stylesheet">
<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
<meta content="C#" name="CODE_LANGUAGE">
<meta content="JavaScript" name="vs_defaultClientScript">
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<script language="javascript" src="jscript/AjaxJS.js"></script>
<script language="javascript" src="../JS/DatePickerJs.js"></script>
<script language="javascript" src="../JS/jscript_validations.js"></script>
<script language="javascript" src="../JS/calendar.js"></script>
<script language="javascript" src="../JS/calendar-en.js"></script>
<script language="javascript" src="../JS/InitCalendarFunc.js"></script>
<script>
		function ShowAdvanceSearch()
		{
			if(document.getElementById("<%=tr_AdvanceSearch1.ClientID%>").style.display== 'none')
			{
				document.getElementById("<%=tr_AdvanceSearch1.ClientID%>").style.display = "inline";
				document.getElementById("<%=tr_AdvanceSearch2.ClientID%>").style.display = "inline";
				document.getElementById("<%=tr_AdvanceSearch3.ClientID%>").style.display = "inline";
				document.getElementById("<%=hid_Status.ClientID%>").value= "Y";
			}
			else
			{
				document.getElementById("<%=tr_AdvanceSearch1.ClientID%>").style.display = "none";
				document.getElementById("<%=tr_AdvanceSearch2.ClientID%>").style.display = "none";
				document.getElementById("<%=tr_AdvanceSearch3.ClientID%>").style.display = "none";
				document.getElementById("<%=hid_Status.ClientID%>").value= "N";
			}
		}
		
</script>
<style>.on { DISPLAY: inline }
	.off { DISPLAY: none }
</style>
<table id="Table1" width="100%" border="0">
	<tr>
		<td align="center">
			<table id="Table2" width="100%" border="0">
				<TR>
					<TD align="right"><asp:label id="msgLabel" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<tr>
					<td style="HEIGHT: 266px">
						<fieldset>
							<table id="Table3" width="100%" align="center" border="0">
								<TR>
									<TD style="WIDTH: 133px" align="right">PRN&nbsp;No.</TD>
									<TD style="WIDTH: 216px"><asp:textbox id="PRN_No" runat="server" Width="104px" CssClass="inputbox"></asp:textbox></TD>
									<TD style="WIDTH: 102px" align="right"></TD>
									<TD align="right"><A class="defaultLink" onclick="return ShowAdvanceSearch(this);" href="#">Advance 
											Search</A></TD>
								</TR>
								<TR id="tr_AdvanceSearch1" style="DISPLAY: none" runat="server">
									<TD style="WIDTH: 133px" align="right">Course</TD>
									<TD style="WIDTH: 216px"><asp:dropdownlist id="DD_Course" runat="server" Width="216px" CssClass="selectBox"></asp:dropdownlist></TD>
									<TD style="WIDTH: 102px" align="right">Date of Birth</TD>
									<TD><asp:textbox id="DOB" runat="server" Width="104px" CssClass="inputbox" MaxLength="10"></asp:textbox><A 
                  onclick="return showCalendar('<%=DOB.ClientID%>', '%d/%m/%Y');" 
                  >&nbsp;<IMG onmouseover="this.style.cursor='Hand'" src="../images/cal.gif" align="middle"></A>&nbsp; 
										[dd/mm/yyyy]</TD>
								</TR>
								<TR id="tr_AdvanceSearch2" style="DISPLAY: none" runat="server">
									<TD style="WIDTH: 133px" align="right">Last&nbsp;Name</TD>
									<TD style="WIDTH: 216px"><asp:textbox id="LastName" runat="server" Width="104px" CssClass="inputbox" MaxLength="100"></asp:textbox></TD>
									<TD style="WIDTH: 102px" align="right">First&nbsp;Name</TD>
									<TD><asp:textbox id="FirstName" runat="server" Width="104px" CssClass="inputbox" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR id="tr_AdvanceSearch3" style="DISPLAY: none" runat="server">
									<TD style="WIDTH: 133px; HEIGHT: 20px" align="right">Gender</TD>
									<TD style="WIDTH: 216px; HEIGHT: 20px"><asp:dropdownlist id="Gender" runat="server" Width="143px" CssClass="selectBox">
											<asp:ListItem Value="N" Selected="True">--- Select ---</asp:ListItem>
											<asp:ListItem Value="0">Male</asp:ListItem>
											<asp:ListItem Value="1">Female</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD style="WIDTH: 102px; HEIGHT: 20px" align="right"></TD>
									<TD style="HEIGHT: 20px"></TD>
								</TR>
								<tr>
									<td align="center" colSpan="5"><asp:button id="btnSearch" runat="server" CssClass="butSubmit" Text="Search" onclick="btnSearch_Click"></asp:button></td>
								</tr>
							</table>
						</fieldset>
					</td>
				</tr>
				<TR>
					<TD align="center" colSpan="5"></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="5"><asp:datagrid id="DG_Search" runat="server" Visible="False" Width="98%" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="pk_Student_ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="fk_CrMoLrnPtrn_ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="fk_CrPr_ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="pk_Uni_ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="pk_Institute_ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Admission_Form_No" HeaderText="Form No.">
									<HeaderStyle Font-Bold="True" Width="8%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Admission_Date" HeaderText="Admission Date">
									<HeaderStyle Font-Bold="True" Width="15%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Name" HeaderText="Name">
									<HeaderStyle Font-Bold="True" Width="30%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Date_of_Birth" HeaderText="Date of Birth">
									<HeaderStyle Font-Bold="True" Width="13%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Course" HeaderText="Course">
									<HeaderStyle Font-Bold="True" Width="13%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select">
									<HeaderStyle Font-Bold="True" Width="5%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Navy"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="Admission_Form_No">
								    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</table>
			<INPUT id="hid_pk_Student_ID" type="hidden" name="hid_pk_Student_ID" runat="server">
			<INPUT id="hid_FormNo" type="hidden" name="hid_FormNo" runat="server"><INPUT id="hid_Status" type="hidden" name="hid_Status" runat="server"><INPUT id="hid_pk_CrPr_ID" type="hidden" size="3" name="hid_pk_CrPr_ID" runat="server"><INPUT id="hid_pk_CrMoLrnPtrn_ID" type="hidden" size="3" name="hid_pk_CrMoLrnPtrn_ID" runat="server"></td>
	</tr>
</table>
