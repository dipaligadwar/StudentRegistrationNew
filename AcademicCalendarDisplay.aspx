
<%@ Page language="c#"  MasterPageFile="~/Content.Master"  Codebehind="AcademicCalendarDisplay.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.AcademicCalendarDisplay" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<script language="javascript" src="jscript/header.js"></script>
		<script language="javascript" src="jscript/footer.js"></script>
		<script language="javascript" src="jscript/SPXMLHTTP.js"></script>
		<script language="javascript" src="jscript/change.js"></script>

							<table width="99%">
								<tr>
									<td valign="top" align="left" width="99%">
										<p class="llblContentTitle" align="left"><asp:label id="lblTitle" runat="server" cssclass="llblContentTitle" font-bold="True">Academic Calendar</asp:label></p>
										<table cellspacing="1" cellpadding="2" width="100%">
											<tr>
												<td align="right"></td>
												<td align="center"></td>
												<td align="right" colspan="2"><asp:label id="MsgLabel" runat="server" width="200px"></asp:label></td>
											</tr>
											<tr>
												<td align="right" width="30%"><b>Select Academic Year</b></td>
												<td align="center" width="1%"><b>:</b></td>
												<td valign="middle" align="left" width="23%"><asp:dropdownlist id="Academic_Year" runat="server"  width="152px"></asp:dropdownlist>
												&nbsp;
												<td align="left"><asp:button id="btnGo" runat="server" cssclass="butsp" width="96px" text="Display"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td align="center" colspan="4"></td>
								</tr>
								<tr>
									<td align="center" colspan="4"><asp:label id="lblAcademicYear" runat="server" font-bold="True" width="472px"></asp:label></td>
								</tr>
								<tr>
									<td align="center" colspan="4"><asp:placeholder id="plcTable" runat="server"></asp:placeholder></td>
								</tr>
								<tr>
									<td align="center" colspan="4"></td>
								</tr>
							</table>
							
			<input id="hid_Mode" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hid_Mode" runat="server" /><input id="hidUniID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hidUniID" runat="server" /><input id="hidFacID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hidFacID" runat="server" /><input id="hidSubID" style="WIDTH: 80px; HEIGHT: 22px" type="hidden" name="hidSubID" runat="server" />
			
			</asp:Content>