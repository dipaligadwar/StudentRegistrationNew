<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkInsert_Uni_StudentStatus.aspx.cs" Inherits="StudentRegistration.Eligibility.BulkInsert_Uni_StudentStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Student Details</title>
    <LINK href="../css/UniPortal.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table height="100%" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<TBODY>
						<tr>
							<td vAlign="top" align="left" width="10%">
								<!--Menu Start Here-->
								
								<!--Menu Ends Here--></td>
							<td vAlign="top" align="left" width="2%">&nbsp;</td>
							<td vAlign="top" align="left" width="80%">
								<div id="divStudentStatusDetails" runat="server"><br>
									<div runat="server" id="divTblElgFormdetails">
										<table class="tblBackColor" id="TblElgFormdetails" cellSpacing="1" cellPadding="3" width="100%"
											border="0">
											<tr>
											    <td align=left valign=top><b>Student Details</b></td>
											</tr>
											<tr class="GridSubHeading">
												<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Eligibility Form Number of the 
														Student&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													</b>
													<asp:label id="lblEligibilityFormNo" runat="server" Font-Bold="True"></asp:label></td>
											</tr>
										</table>
									</div>
									<br>
									<table class="tblBackColor" id="TblAdmission" style="DISPLAY: none" cellSpacing="1" cellPadding="3"
										width="100%" border="0" runat="server">
										<TBODY>
											<tr class="GridSubHeading">
												<TD style="HEIGHT: 18px" colSpan="4"><b>Admission&nbsp;Details of the Student</b>
												</TD>
											</tr>
											<tr class="rFont">
												<TD width="30%"><b>Admission Form Number :</b></TD>
												<td width="20%"><asp:label id="lblAppFormNo" runat="server"></asp:label></td>
												<td width="30%"><b>Admission Date :</b></td>
												<td width="20%"><asp:label id="lblAdmissionDate" runat="server"></asp:label></td>
											</tr>
											<tr class="rFont">
												<td width="30%"><b>Seeking Admission in Course :</b></td>
												<td width="70%" colSpan="3"><asp:label id="lblCourse" runat="server"></asp:label></td>
											</tr>
											
											<tr class="rFont">
												<TD width="30%"><b>Institute Name :</b></TD>
												<td width="80%" colSpan="3"><asp:label id="lblInstName" runat="server"></asp:label></td>
											</tr>
										</TBODY>
									</table>
									<br>
									<div id="divMatchingRecords" style="DISPLAY : none" runat="server">
										<asp:label id="lblGridName" runat="server" Height="18px" CssClass="GridHeadingM" Width="100%">Other Course Eligibility Status</asp:label><br>
										<asp:datagrid id="DGMatchgCourseDetails" runat="server" Width="100%" BorderStyle="Solid" PageSize="5"
											AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699" AllowPaging="True">
											<ItemStyle CssClass="GridData2"></ItemStyle>
											<Columns>
												<asp:BoundColumn ReadOnly="True" HeaderText="Sr. No.">
												    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Course" HeaderText="Course">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="InstituteName" HeaderText="Institute Name">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="EligibilityStatus" HeaderText="Eligibility Status">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CourseStatus" HeaderText="Course Status">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Reason" HeaderText="Reason">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ElgFormNo" HeaderText="Eligibility Form Number">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid>
									</div>
								</div>								
								<div id="divStudentDetails" runat="server"><br>
									<asp:label id="lblProfileHeading" runat="server" Height="18px" CssClass="GridHeadingM" Width="100%"> Student's Profile</asp:label> <table id="Table1" cellSpacing="0" cellPadding="3" width="100%" border="0">
										<tr>
											<td vAlign="top" width="80%">
												<table class="tblBackColor" id="Table2" cellSpacing="1" cellPadding="3" width="100%" border="0">
													<tr class="GridSubHeading">
														<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Personal Details of the 
																Student</b>
														</td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" width="30%"><b>Full Name</b></td>
														<td vAlign="top" colSpan="3"><asp:label id="lblNameOfStudent" runat="server"></asp:label></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" width="30%"><b>Father's Full Name</b></td>
														<td vAlign="top" colSpan="3"><asp:label id="lblFathersName" runat="server"></asp:label></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" width="30%"><b>Mother's Maiden Name</b></td>
														<td vAlign="top" colSpan="3"><asp:label id="lblMothersMaidenName" runat="server"></asp:label></td>
													</tr>
													<tr class="rFont" id="trChangedName" style="DISPLAY: none" runat="server">
														<td vAlign="top" width="30%"><b>Previous&nbsp;Name</b></td>
														<td vAlign="top" colSpan="3"><asp:label id="lblPreviousName" runat="server"></asp:label></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" width="30%"><b>Date of Birth</b></td>
														<td vAlign="top" width="30%"><asp:label id="lblDOB" runat="server"></asp:label></td>
														<td vAlign="top" width="20%"><b>Gender</b></td>
														<td vAlign="top" width="20%"><asp:label id="lblGender" runat="server"></asp:label></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" width="20%"><b>Nationality</b></td>
														<td vAlign="top" colSpan="3"><asp:label id="lblNationality" runat="server"></asp:label></td>
													</tr>
												</table>
											</td>
											<td vAlign="top" width="20%">
												<table class="tblBackColor" id="Table3" cellSpacing="1" cellPadding="3" width="100%" border="0">
													<tr class="GridSubHeading">
														<td style="HEIGHT: 16px" vAlign="top" align="center"><b>Photograph</b></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" align="center"><asp:image id="Image1" runat="server" Visible="true" ImageUrl="../images/Member.gif" AlternateText="Photograph"></asp:image></td>
													</tr>
													<tr class="GridSubHeading">
														<td style="HEIGHT: 16px" vAlign="top" align="center"><b>Signature</b></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" align="center"><asp:image id="Image2" runat="server" Visible="true" AlternateText="Signature" ToolTip="Signature"></asp:image></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<table class="tblBackColor" id="Table5" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Reservation Details of the Student</b>
											</td>
										</tr>
										<tr class="rFont">
											<td vAlign="top" width="20%"><b>State of Domicile</b></td>
											<td vAlign="top" width="30%"><asp:label id="lblDomicileState" runat="server"></asp:label></td>
											<td vAlign="top" width="20%"><b>Reservation Category</b></td>
											<td vAlign="top" width="30%"><asp:label id="lblResvCategory" runat="server"></asp:label></td>
										</tr>
										<tr class="rFont">
											<td vAlign="top" width="20%"><b>Physically Challenged</b></td>
											<td vAlign="top" colSpan="3"><asp:label id="lblPhyChlngd" runat="server"></asp:label></td>
										</tr>
										<tr class="rFont">
											<td vAlign="top"><b>Social Reservation</b>
											</td>
											<td vAlign="top" colSpan="3"><asp:label id="lblSocResv" runat="server"></asp:label></td>
										</tr>
									</table>
									<br>
									<table class="tblBackColor" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Guardian Details of the Student</b>
											</td>
										</tr>
										<tr class="rFont">
											<td vAlign="top" width="30%"><b>Annual Income of the Guardian</b></td>
											<td vAlign="top" width="20%"><asp:label id="lblGuardianincome" runat="server"></asp:label></td>
											<td vAlign="top" width="30%"><b>Occupation of the Guardian</b></td>
											<td vAlign="top" width="20%"><asp:label id="lblGuardianOccupation" runat="server"></asp:label></td>
										</tr>
									</table>
									<br>
									<table class="tblBackColor" id="Table4" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td style="HEIGHT: 16px" vAlign="top"><b>Educational Details&nbsp;of the Student</b>
											</td>
										</tr>
										<tr class="rFont">
											<td><asp:datagrid id="DGQualification" runat="server" Width="100%" AutoGenerateColumns="False" BorderWidth="1px"
													BorderColor="Gainsboro">
													<Columns>
														<asp:BoundColumn DataField="Qualification" HeaderText="Qualification">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CollegeInstituteName" HeaderText="College/Institute">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Body" HeaderText="Board/University">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Marks_Obtained" HeaderText="Marks">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Marks_OutOf" HeaderText="Out of">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DateOfPassing" HeaderText="Passing Date">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<br>
									<table class="tblBackColor" id="Tbl4" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td style="HEIGHT: 16px" vAlign="top"><b>Documents Submitted by the Student</b></td>
										</tr>
										<tr class="rFont">
											<td vAlign="top" align="center" width="100%"><asp:datagrid id="DGSubmittedDocs" runat="server" Width="90%" BorderStyle="Solid" PageSize="5"
													AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699" OnItemDataBound="DGSubmittedDocs_ItemDataBound">
													<ItemStyle CssClass="GridData2"></ItemStyle>
													<Columns>
														<asp:BoundColumn ReadOnly="True" HeaderText="Sr. No.">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DocCert_Desc" ReadOnly="True" HeaderText="Document Name">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:BoundColumn>
														<asp:BoundColumn ReadOnly="True" HeaderText="Received By College">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Received By University">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="cbDocRecv" runat="server" onclick="fnDocRecv(this);" Enabled="false"></asp:CheckBox>
															</ItemTemplate>
															<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Determine Validity ">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:RadioButton id="rbValidDoc" runat="server" Text="Valid" GroupName="grpValidity" Enabled="False"
																	Checked="False"></asp:RadioButton>
																<asp:RadioButton id="rbInvalidDoc" runat="server" Text="Invalid" GroupName="grpValidity" Enabled="False"
																	Checked="False"></asp:RadioButton>
															</ItemTemplate>
															<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="pk_DocCert_ID" ReadOnly="True" HeaderText="Doc_ID"></asp:BoundColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</tr>
									</table>
									<br>
								</div>
								<br>
								<table id="Table9" cellSpacing="0" cellPadding="5" align="center" border="0">
									<tr>
										<td><asp:button id="btnGoTo" runat="server" Text="Go Back" CssClass="butSubmit"></asp:button></td>
									</tr>
								</table>
							</td>
						</tr>
						<TR>
						<TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					</TR>
					</TBODY>
				</table>
				<input id="hidUniID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidUniID" runat="server"/>
				<input id="hidpkYear" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidpkYear" runat="server"/>
				<input id="hidpkStudentID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidpkStudentID" runat="server"/>
				<input id="hidPRN" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidPRN" runat="server"/>
				<input id="hidElgFormNo" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidElgFormNo" runat="server"/>
				<input id="hidCrMoLrnPtrnID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidCrMoLrnPtrnID" runat="server"/>
				
    </div>
    </form>
</body>
</html>
