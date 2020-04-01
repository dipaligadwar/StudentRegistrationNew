<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CancelAdmission__1.aspx.cs" Inherits="StudentRegistration.Eligibility.CancelAdmission__1" Title="Cancel Admission" %>

<%@ Register Src="WebCtrl/PageTitle.ascx" TagName="PageTitle" TagPrefix="uc1" %>
<%@ Register Src="WebCtrl/ShowStudentPhoto.ascx" TagName="ShowStudentPhoto" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript">
	function ConfirmCancel(strArg, sFlag)
	{  
////	alert(sFlag);
	var msg ="";
        if(sFlag == "TR")
        {
             msg = "This will permanently delete the students data. \nAre you sure you want to CANCEL this Admission?";
        }
        else
        {
             msg = "This will delete the Complete Profile of student. \nAre you sure you want delete this student?";
        }
////        alert(msg);
        document.getElementById('<%= HidArg.ClientID%>').value=strArg;
        
		ShowConfirm('<%=lnkCancelAdmission.UniqueID%>',msg); 
		return false;  	

	}
	</script>
	<div id="ControlHolder" style="width: 100%;">
		<div id="PageTitleHolder" style="vertical-align: top;">
			<uc2:ShowStudentPhoto ID="ShowStudentPhoto1" runat="server" />
			<div id="StudentLinkHolder" style="margin-top: 0px; padding-top: 0px;">
			</div>
			<asp:Label ID="lblPageHead" runat="server" ></asp:Label>
			<uc1:PageTitle ID="PageTitle1" runat="server" />
            <asp:LinkButton ID="lnkCancelAdmission" runat="server" OnClick="lnkCancelAdmission_Click"></asp:LinkButton>
		</div>
		<div style="width: 100%; text-align: left;">
			<asp:Label ID="lblMessage" runat="server" CssClass="errorNote"></asp:Label>
		</div>
		<div style="text-align: left; margin: 3px 0 0 0; width: 100%;">
			<div id="tr_Details" runat="server">
				<asp:Panel ID="PersonalPanel2" runat="server" BorderColor="White" BorderStyle="Solid" BorderWidth="1pt"  Width="100%">
					<div class="clTitleBackground">
						<div class="clLeftBold">
							Personal Information
						</div>
						<div class="clRight">
							<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/down.png"  />
						</div>
					</div>
				</asp:Panel>
			</div>
			<asp:Panel ID="PersonalPanel1" runat="server"  Width="100%">
				<fieldset>
					<div id="tr_PersonalDetails1" runat="server" align="center" style="display: none;">
						<asp:Label ID="Err_PersonalDetails" runat="server" CssClass="errorNote"  Style="font-size: 10px;" Text="Personal details not yet entered." Visible="False"></asp:Label>
					</div>
					<div id="tr_PersonalDetails" runat="server">
						<div>
							<div class="clLeft" style="width: 50%">
								<div class="clLeft" style="padding: 2px; margin-top: 8px; width: 100%;">
									Full Name<b> : </b>
									<asp:Label ID="lblNameOfStudent" runat="server" ></asp:Label>
								</div>
								<div id="trChangedName" runat="server" class="clLeft" style="display: none; width: 100%;">
									Changed Name<b> : </b>
									<asp:Label ID="lblChangedName" runat="server" ></asp:Label>
								</div>
								<div style="padding: 2px; width: 100%; clear: left;">
									Name as on statement of<br />
									marks of qualifying Exam<b> : </b>
									<asp:Label ID="lblCertificateNm" runat="server" ></asp:Label>
								</div>
								<div style="padding: 2px; width: 100%;">
									Name in vernacular language<b> : </b>
									<asp:Label ID="lblVernacularName" runat="server" ></asp:Label>
								</div>
								<div style="padding: 2px; width: 100%;">
									Father's Full Name<b> : </b>
									<asp:Label ID="lblFathersName" runat="server" ></asp:Label>
								</div>
								<div style="padding: 2px; width: 100%;">
									Mother's Full Name<b> : </b>
									<asp:Label ID="lblMothersMaidenName" runat="server" ></asp:Label>
								</div>
								<div style="padding: 2px; width: 100%;">
									Date of Birth<b> : </b>
									<asp:Label ID="lblDOB" runat="server" ></asp:Label>
								</div>
								<div style="padding: 2px; width: 100%;">
									Place of Birth<b> : </b>
									<asp:Label ID="lblPlaceOfBirth" runat="server" ></asp:Label>
								</div>
								<div style="padding: 2px; width: 100%;">
									Gender<b> : </b>
									<asp:Label ID="lblGender" runat="server" ></asp:Label>
								</div>
								<div style="padding: 2px; width: 100%;">
									Nationality<b> : </b>
									<asp:Label ID="lblNationality" runat="server" ></asp:Label>
								</div>
								<div style="padding: 2px; width: 100%;">
									Location category<b> : </b>
									<asp:Label ID="lblLocationCategory" runat="server" ></asp:Label>
								</div>
								<div style="padding: 2px;">
									Religion<b> : </b>
									<asp:Label ID="lblReligion" runat="server" ></asp:Label>
								</div>
							</div>
							<div class="clLeft" style="width: 50%">
								<div style="width: 250px; padding-top: 10px;">
									<fieldset>
										<div style="width: 100%">
											<div style="padding: 10px 10px 10px 10px">
												<div class="clLeft" style="padding-left: 10px; padding-right: 20px">
													<asp:Image ID="Image1" runat="server" AlternateText="Photograph"  ToolTip="Photograph" />
													<%--<div id="NoPhoto" runat="server" style="line-height: 70px; padding: 3px; border: solid 1px #888888; text-align: center; vertical-align: middle; background-color: #efefef; color: #888888">
														No Photo
													</div>--%>
												</div>
												<div class="clLeft" style="padding-left: 20px; padding-right: 10px; padding-top: 20px">
													<asp:Image ID="Image2" runat="server" AlternateText="Signature"  ToolTip="Signature" />
													<%--<div id="NoSign" runat="server" style="line-height: 30px; padding: 3px; width: 100px; background-color: #efefef; color: #888888; border: solid 1px #888888; text-align: center;">
														No Sign
													</div>--%>
												</div>
											</div>
											<div style="clear: left; padding-top: 2px; padding-bottom: 2px; padding-left: 10px">
												<div align="center" class="clLeft">
													Photograph</div>
												<div style="padding-left: 120px">
													Signature</div>
											</div>
										</div>
									</fieldset>
								</div>
								<div style="margin: 10px 0 0 0;">
									<div style="padding: 2px;">
										Blood Group<b> : </b>
										<asp:Label ID="lblBloodGrp" runat="server" ></asp:Label>
									</div>
								</div>
								<div style="padding: 2px;">
									Marital Status<b> : </b>
									<asp:Label ID="lblMaritalStatus" runat="server" ></asp:Label>
								</div>
							</div>
							<div style="width: 100%">
								<div style="font-weight: bold; padding: 6px 4px 4px 2px; clear: both;">
									Address Detail<b> : </b>
								</div>
								<div class="clLeft" style="width: 50%">
									<div style="padding: 2px">
										Permanent Address<b> : </b>
										<div style="padding: 2px; width: 100%">
											<asp:Label ID="lblPermAddress" runat="server" ></asp:Label>
										</div>
									</div>
									<div style="padding: 2px;">
										City<b> : </b>
										<asp:Label ID="lblPermCity" runat="server" ></asp:Label>
									</div>
									<div style="padding: 2px;">
										Tahsil<b> : </b>
										<asp:Label ID="lblPermTehsil" runat="server" ></asp:Label>
									</div>
									<div style="padding: 2px;">
										District<b> : </b>
										<asp:Label ID="lblPermDist" runat="server" ></asp:Label>
									</div>
									<div style="padding: 2px;">
										State<b> : </b>
										<asp:Label ID="lblPermState" runat="server" ></asp:Label>
									</div>
									<div style="padding: 2px;">
										Pin<b> : </b>
										<asp:Label ID="lblPermPin" runat="server" ></asp:Label>
									</div>
									<div style="padding: 2px;">
										Country<b> : </b>
										<asp:Label ID="lblPerCountry" runat="server" ></asp:Label>
									</div>
								</div>
								<div class="clLeft" style="width: 50%">
									<div style="padding: 2px;">
										Correspondence Address<b> : </b>
										<div style="padding: 2px; width: 100%">
											<asp:Label ID="lblCorspAddress" runat="server"  Width="100%"></asp:Label>
										</div>
									</div>
									<div style="padding: 2px;">
										City<b> : </b>
										<asp:Label ID="lblCorspCity" runat="server" ></asp:Label>
									</div>
									<div style="padding: 2px;">
										Tahsil<b> : </b>
										<asp:Label ID="lblCorspTehsil" runat="server" ></asp:Label>
									</div>
									<div style="padding: 2px;">
										District<b> : </b>
										<asp:Label ID="lblCorspDist" runat="server" ></asp:Label>
									</div>
									<div style="padding: 2px;">
										State<b> : </b>
										<asp:Label ID="lblCorspState" runat="server" ></asp:Label>
									</div>
									<div style="padding: 2px;">
										Pin<b> : </b>
										<asp:Label ID="lblCorspPin" runat="server" ></asp:Label>
									</div>
									<div style="padding: 2px;">
										Country<b> : </b>
										<asp:Label ID="lblCorsCountry" runat="server" ></asp:Label>
									</div>
								</div>
							</div>
							<div style="width: 100%">
								<div style="font-weight: bold; padding: 6px 4px 4px 2px; margin-top: 10px;">
									Contact Detail<b> : </b>
								</div>
								<div style="width: 100%">
									<div class="clLeft" style="width: 50%">
										<div style="padding: 2px;">
											Telephone #1<b> : </b>
											<asp:Label ID="lblPermTelephone" runat="server" ></asp:Label></div>
									</div>
									<div class="clLeft" style="width: 50%">
										Telephone #2<b> : </b>
										<asp:Label ID="lblCorspTelephone" runat="server" ></asp:Label></div>
								</div>
								<div style="width: 100%">
									<div class="clLeft" style="width: 50%">
										<div style="padding: 2px;">
											Mobile<b> : </b>
											<asp:Label ID="lblMobile" runat="server" ></asp:Label><a href="mailto:Tony.Briganzha@Gmail.com"></a></div>
									</div>
									<div class="clLeft" style="width: 50%">
										Email ID<b> : </b>
										<asp:Label ID="lblEmailID" runat="server" ></asp:Label></div>
								</div>
							</div>
						</div>
						<div style="width: 100%">
							<div style="font-weight: bold; padding: 6px 4px 4px 2px; margin-top: 10px; clear: both;">
								Guardian Detail<b> : </b>
							</div>
							<div class="clLeft" style="width: 50%">
								<div style="padding: 2px;">
									Annual Income of Guardian<b> : </b>
									<asp:Label ID="lblGuardIncome" runat="server"  Text="Not Available"></asp:Label></div>
							</div>
							<div class="clLeft" style="width: 50%">
								Occupation of Guardian<b> : </b>
								<asp:Label ID="lblGuardOccupation" runat="server"  Text="Not Available"></asp:Label>
							</div>
						</div>
					</div>
				</fieldset>
			</asp:Panel>
			<cc1:collapsiblepanelextender id="CollapsiblePanelExtender1" runat="server" collapsecontrolid="PersonalPanel2" collapsed="true" collapsedimage="~/images/down.png" collapsedtext="(Show Detail....)" enabled="True" expandcontrolid="PersonalPanel2" expandedimage="~/images/up.png" expandedtext="(Hide Detail....)" imagecontrolid="ImageButton1" suppresspostback="True" targetcontrolid="PersonalPanel1">
</cc1:collapsiblepanelextender>
			<asp:Panel ID="ReservationPanel2" runat="server" BorderColor="White" BorderStyle="Solid" BorderWidth="1pt" CssClass="clSpace"  Width="100%">
				<div class="clTitleBackground">
					<div class="clLeftBold">
						Reservation Detail
					</div>
					<div class="clRight">
						<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/down.png"  />
					</div>
				</div>
			</asp:Panel>
			<asp:Panel ID="ReservationPanel1" runat="server" >
				<fieldset>
					<div align="center" style="padding-top: 8px;">
						<asp:Label ID="Err_ReservationDetails" runat="server" CssClass="errorNote"  Style="font-size: 10px;" Text="Reservation details not yet entered." Visible="False"></asp:Label>
					</div>
					<div id="tr_ReservationDetails" runat="server">
						<div style="width: 100%">
							<div class="clLeft" style="margin: 0 0 0 10px;">
								<div style="padding: 2px;">
									State of Domicile<b> : </b>
									<asp:Label ID="lblDomicileState" runat="server" ></asp:Label></div>
								<div style="padding: 2px">
									Category<b> : </b>
									<asp:Label ID="lblCategory" runat="server" ></asp:Label></div>
								<div style="padding: 2px">
									Admitted Category<b> : </b>
									<asp:Label ID="lblAdmittedCat" runat="server"  Text="&#160;"></asp:Label></div>
								<div style="padding: 2px; margin-top: 2px">
									Social Reservation<b> : </b>
									<asp:Label ID="lblSocialResv" runat="server" ></asp:Label></div>
							</div>
							<div style="margin: 15px 0 0 400px;">
								<div style="padding: 2px;">
									Physically Challenged<b> : </b>
									<asp:Label ID="lblPhysicallyChallenged" runat="server" ></asp:Label></div>
							</div>
						</div>
					</div>
				</fieldset>
			</asp:Panel>
			<cc1:collapsiblepanelextender id="CollapsiblePanelExtender2" runat="server" collapsecontrolid="ReservationPanel2" collapsed="True" collapsedimage="~/images/down.png" collapsedtext="(Show Detail....)" enabled="True" expandcontrolid="ReservationPanel2" expandedimage="~/images/up.png" expandedtext="(Hide Detail....)" imagecontrolid="ImageButton2" suppresspostback="True" targetcontrolid="ReservationPanel1">
</cc1:collapsiblepanelextender>
			<asp:Panel ID="EducationPanel2" runat="server" BorderColor="White" BorderStyle="Solid" BorderWidth="1pt" CssClass="clSpace"  Width="100%">
				<div class="clTitleBackground">
					<div class="clLeftBold">
						Educational Detail
					</div>
					<div class="clRight">
						<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/down.png"  />
					</div>
				</div>
			</asp:Panel>
			<asp:Panel ID="EducationPanel1" runat="server" >
				<fieldset>
					<div align="center" style="padding-top: 8px">
						<asp:Label ID="Err_Qualification" runat="server" CssClass="errorNote"  Style="font-size: 10px;" Text="Educational Details not yet entered." Visible="False"></asp:Label>
					</div>
					<div id="tr_EducationalDetails" runat="server" style="clear: left; padding-top: 5px; padding-bottom: 20px">
						<asp:GridView ID="GV_Qualification" runat="server" AutoGenerateColumns="False" CssClass="clGrid"  OnRowDataBound="GV_Qualification_RowDataBound" Width="100%">
							<Columns>
								<asp:BoundField DataField="Qualification" HeaderText="Qualification" >
									<HeaderStyle CssClass="gridHeader" />
								</asp:BoundField>
								<asp:BoundField DataField="CollegeInstituteName" HeaderText="College/Institute" >
									<HeaderStyle CssClass="gridHeader" />
								</asp:BoundField>
								<asp:BoundField DataField="Body" HeaderText="Board/University" >
									<HeaderStyle CssClass="gridHeader" />
								</asp:BoundField>
								<asp:BoundField DataField="Marks_Obtained" HeaderText="Marks" >
									<HeaderStyle CssClass="gridHeader" />
								</asp:BoundField>
								<asp:BoundField DataField="Marks_OutOf" HeaderText="Out of" >
									<HeaderStyle CssClass="gridHeader" />
								</asp:BoundField>
								<asp:BoundField DataField="Show_Date" HeaderText="Passing Date" >
									<HeaderStyle CssClass="gridHeader" />
								</asp:BoundField>								
							</Columns>
						</asp:GridView>
					</div>
					<br />
					<div>
						<strong>List of Last Qualifying Exams:</strong>
					</div>
					<div style="padding-top: 8px">
					</div>
						<asp:Label ID="Err_LastQualification" runat="server" CssClass="errorNote" Style="font-size: 10px;" Text="Last Qualification Details not yet entered." Visible="False"></asp:Label>
						<div id="Div1" runat="server" style="clear: left; padding-top: 5px; padding-bottom: 20px">
							<asp:GridView ID="GV_LastQualification" runat="server" AutoGenerateColumns="False" CssClass="clGrid" OnRowDataBound="GV_LastQualification_RowDataBound" Width="100%">
								<Columns>
									<asp:TemplateField HeaderText="Sr.No." >
										<HeaderStyle CssClass="gridHeader" />
										<ItemTemplate>
											<%# Container.DataItemIndex+1 %>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="C" HeaderText="Course Admitted">
										<HeaderStyle CssClass="gridHeader" />
									</asp:BoundField>
									<asp:BoundField DataField="Qualification" HeaderText="Last Qualification">
										<HeaderStyle CssClass="gridHeader" />
									</asp:BoundField>
								</Columns>
							</asp:GridView>
						</div>
						<%--<div style="clear: left; padding-top: 8px; text-align:left;"  id="TDNote" runat="server">
                            Note<b> : </b><font class="Mandatory">Last qualifying examination of Educational Detail
                                is in Red.</font></div>--%>
				</fieldset>
			</asp:Panel>
			<cc1:collapsiblepanelextender id="CollapsiblePanelExtender3" runat="server" collapsecontrolid="EducationPanel2" collapsed="True" collapsedimage="~/images/down.png" collapsedtext="(Show Detail....)" enabled="True" expandcontrolid="EducationPanel2" expandedimage="~/images/up.png" expandedtext="(Hide Detail....)" imagecontrolid="ImageButton3" suppresspostback="True" targetcontrolid="EducationPanel1">
</cc1:collapsiblepanelextender>
			<asp:Panel ID="PaperPanel2" runat="server" BorderColor="White" BorderStyle="Solid" BorderWidth="1pt" CssClass="clSpace"  Width="100%">
				<div class="clTitleBackground">
					<div class="clLeftBold">
						Papers Selected
					</div>
					<div class="clRight">
						<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="../Images/down.png"  />
					</div>
				</div>
			</asp:Panel>
			<asp:Panel ID="PaperPanel1" runat="server" >
				<fieldset>
					<div id="tblSummary" runat="server" style="width: 100%">
						<div align="center" style="padding-top: 8px">
							<asp:Label ID="lblerrorPaper" runat="server" CssClass="errorNote"  Style="font-size: 10px;" Text="Exam  details not yet entered." Visible="False"></asp:Label></div>
					</div>
					<div align="left" style="padding: 5px">
						<strong>Note:</strong><font class="Mandatory">*</font> marked Papers are claimed for exemption.
					</div>
				</fieldset>
			</asp:Panel>
			<cc1:collapsiblepanelextender id="CollapsiblePanelExtender4" runat="server" collapsecontrolid="PaperPanel2" collapsed="True" collapsedimage="../Images/down.png" collapsedtext="(Show Details....)" enabled="True" expandcontrolid="PaperPanel2" expandedimage="../Images/up.png" expandedtext="(Hide Details....)" imagecontrolid="ImageButton4" suppresspostback="True" targetcontrolid="PaperPanel1">
</cc1:collapsiblepanelextender>
			<asp:Panel ID="DocumentsPanel2" runat="server" BorderColor="White" BorderStyle="Solid" BorderWidth="1pt" CssClass="clSpace"  Width="100%">
				<div class="clTitleBackground">
					<div class="clLeftBold">
						Documents Attached
					</div>
					<div class="clRight">
						<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="../Images/down.png"  />
					</div>
				</div>
			</asp:Panel>
			<asp:Panel ID="DocumentsPanel1" runat="server" >
				<div>
					<fieldset>
						<div id="tr_DocumentsDetails" runat="server" style="clear: left;">
							<%--<div align="center">--%>
							<asp:Label ID="Err_Documents" runat="server" CssClass="errorNote"  Style="font-size: 10px;" Text="Document details not available." Visible="False"></asp:Label></div>
						<%--</div>--%>
					</fieldset>
				</div>
			</asp:Panel>
			<cc1:collapsiblepanelextender id="CollapsiblePanelExtender5" runat="server" collapsecontrolid="DocumentsPanel2" collapsed="True" collapsedimage="../Images/down.png" collapsedtext="(Show Details....)" enabled="True" expandcontrolid="DocumentsPanel2" expandedimage="../Images/up.png" expandedtext="(Hide Details....)" imagecontrolid="ImageButton5" suppresspostback="True" targetcontrolid="DocumentsPanel1">
</cc1:collapsiblepanelextender>
			<asp:Panel ID="InwardDocuments" runat="server" BorderColor="White" BorderStyle="Solid" BorderWidth="1pt" CssClass="clSpace"  Width="100%">
				<div class="clTitleBackground">
					<div class="clLeftBold">
						Fees Details
					</div>
					<div class="clRight">
						<asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="../Images/down.png"  />
					</div>
				</div>
			</asp:Panel>
			<asp:Panel ID="InwardDocuments1" runat="server" >
				<fieldset style="padding-bottom: 10px;">
					<div align="center" style="padding-top: 8px;">
						<div id="tr_InwardDocuments1" runat="server" align="center" style="padding-top: 8px; display: none">
							<%--<asp:Label ID="Err_feeDocuments" runat="server" Visible="False" CssClass="errorNote"
                                Text=" Fee Details not yet entered. " meta:resourcekey="Err_feeDocumentsResource1"></asp:Label>--%>
						</div>
					</div>
					<div id="tr_InwardDocuments" runat="server" style="clear: left; padding-top: 5px; width: 100%">
					</div>
				</fieldset>
			</asp:Panel>
			<cc1:collapsiblepanelextender id="CollapsiblePanelExtender6" runat="server" collapsecontrolid="InwardDocuments" collapsed="True" collapsedimage="../Images/down.png" collapsedtext="(Show Details....)" enabled="True" expandcontrolid="InwardDocuments" expandedimage="../Images/up.png" expandedtext="(Hide Details....)" imagecontrolid="ImageButton6" suppresspostback="True" targetcontrolid="InwardDocuments1">
</cc1:collapsiblepanelextender>
			<asp:Panel ID="PanelExmdetail2" runat="server" BorderColor="White" BorderStyle="Solid" BorderWidth="1pt" CssClass="clSpace"  Width="100%">
				<div class="clTitleBackground">
					<div class="clLeftBold">
						Exam Details
					</div>
					<div class="clRight">
						<asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="../Images/down.png"  />
					</div>
				</div>
			</asp:Panel>
			<asp:Panel ID="PanelExmdetail1" runat="server" >
				<fieldset>
					<div id="divPExmdetail" runat="server" style="clear: left; padding-top: 8px; padding-bottom: 16px;">
						<div align="center" style="padding-top: 8px">
							<asp:Label ID="lblExamdetailsError" runat="server" CssClass="errorNote"  Style="font-size: 10px;" Text="Exam  details not yet entered." Visible="False"></asp:Label></div>
						<asp:GridView ID="oGridViewExmdetails" runat="server" AutoGenerateColumns="False" CssClass="clGrid"  Visible="False" Width="100%">
							<Columns>
								<asp:TemplateField HeaderText="Sr.No." >
									<HeaderStyle CssClass="gridHeader" />
									<ItemTemplate>
										<%# Container.DataItemIndex+1 %>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField DataField="Exam_Event" HeaderText="Exam Event" >
									<HeaderStyle CssClass="gridHeader" />
									<ItemStyle Width="10%" />
								</asp:BoundField>
								<asp:BoundField DataField="CoursePartChildName" HeaderText="Course/Programme Name" >
									<HeaderStyle CssClass="gridHeader" />
									<ItemStyle Width="45%" />
								</asp:BoundField>
								<asp:BoundField DataField="ExamForm_Number" HeaderText="ExamForm Number" >
									<HeaderStyle CssClass="gridHeader" />
									<ItemStyle Width="10%" />
								</asp:BoundField>
								<asp:BoundField DataField="ExamForm_Status" HeaderText="ExamForm Status" >
									<HeaderStyle CssClass="gridHeader" />
									<ItemStyle Width="10%" />
								</asp:BoundField>
								<asp:BoundField DataField="Seat_Number" HeaderText="Seat Number" >
									<HeaderStyle CssClass="gridHeader" />
									<ItemStyle Width="10%" />
								</asp:BoundField>
								<asp:BoundField DataField="Result_Status" HeaderText="Result Status" >
									<HeaderStyle CssClass="gridHeader" />
									<ItemStyle Width="10%" />
								</asp:BoundField>
							</Columns>
						</asp:GridView>
					</div>
				</fieldset>
			</asp:Panel>
			<cc1:collapsiblepanelextender id="CollapsiblePanelExtender7" runat="server" collapsecontrolid="PanelExmdetail2" collapsed="false" collapsedimage="../Images/down.png" collapsedtext="(Show Details....)" enabled="True" expandcontrolid="PanelExmdetail2" expandedimage="../Images/up.png" expandedtext="(Hide Details....)" imagecontrolid="ImageButton7" suppresspostback="True" targetcontrolid="PanelExmdetail1">
</cc1:collapsiblepanelextender>
		</div>
	</div>
	<input id="hid_pk_Year" runat="server" type="hidden" />
	<input id="hid_Stud_Name" runat="server" type="hidden" />
	<input id="hid_PRN" runat="server" type="hidden" />
	<input id="hid_OldPRN" runat="server" type="hidden" />
	<input id="hid_pk_Student_ID" runat="server" type="hidden" />
	<input id="hid_eligiblityFN" runat="server" type="hidden" />
	<input id="hid_pk_Uni_ID" runat="server" type="hidden" />
	<input id="Hidden1" runat="server" type="hidden" />
	<input id="hid_Inst_Details" runat="server" type="hidden" />
	<input id="hid_PRN_Number" runat="server" type="hidden" />
	<input id="hid_Date" runat="server" type="hidden" />
	<input id="hidPhoto" runat="server" type="hidden" />
	<input id="hidSign" runat="server" type="hidden" />
	<input id="HidArg" runat="server" type="hidden" />
</asp:Content>
