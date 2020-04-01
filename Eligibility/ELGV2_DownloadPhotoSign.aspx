<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="ELGV2_DownloadPhotoSign.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_DownloadPhotoSign" meta:resourcekey="PageResource1" %>

<%@ Register Src="WebCtrl/SelectSingleCourseExamEvent.ascx" TagName="YCMOU" TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<center>
		<table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2" width="700" border="0">
			<tr>
				<td class="FormName" align="left" valign="middle">
					<asp:Label runat="server" Text=" Download Photo and Sign Data" Font-Bold="True" ID="lblPageHead" meta:resourcekey="lblPageHeadResource1"></asp:Label>
					<asp:Label ID="lblwelcome" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="lblwelcomeResource1"></asp:Label>
				</td>
			</tr>
			<tr style="height: 10px;">
				<td>
				</td>
			</tr>
			<tr>
				<td valign="top" align="left">
					<div id="divYCMOU" runat="server">
						<uc3:YCMOU ID="YCMOU" runat="server"></uc3:YCMOU>
					</div>
					<div runat="server" id="divGridView" style="display: none; position: relative">
						<center>
							<asp:Label ID="lblErrorMsg" runat="server" Width="100%" Style="text-align: left;" Visible="False" meta:resourcekey="lblErrorMsgResource1"></asp:Label>
						</center>
						<br />
						<asp:Label ID="lblTotalData" runat="server" Text="Total Data available(No. of Student(s)): " Font-Bold="True" meta:resourcekey="lblTotalDataResource1"></asp:Label>
						<asp:GridView runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="Text" ShowFooter="True" BorderStyle="None" CssClass="clGrid grid-view" ID="gvStudentCountLinks" Style="border-style: Double; border-collapse: collapse;" OnRowCommand="gvStudentCountLinks_RowCommand" EnableModelValidation="True" meta:resourcekey="gvStudentCountLinksResource1">
							<HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
							<Columns>
								<asp:TemplateField HeaderText="Download Photo and Sign Data" meta:resourcekey="TemplateFieldResource1">
									<ItemTemplate>
										<asp:LinkButton runat="server" Text='<%# Eval("Text", "{0} Students") %>' ID="lnkGenerateXML" CommandArgument='<%# (Container.DataItemIndex) %>' CommandName="cmdGenerateXML" meta:resourcekey="lnkGenerateXMLResource1"></asp:LinkButton>
									</ItemTemplate>
									<HeaderStyle />
								</asp:TemplateField>
								<asp:BoundField DataField="Text" HeaderText="Text" Visible="false" meta:resourcekey="BoundFieldResource1"></asp:BoundField>
							</Columns>
							<HeaderStyle BackColor="#E0E0E0" CssClass="gridHeader"></HeaderStyle>
							<RowStyle CssClass="gridItem" HorizontalAlign="Center"></RowStyle>
						</asp:GridView>
					</div>
					<br />
				</td>
			</tr>
		</table>
	</center>
	<input runat="server" id="hidUniID" type="hidden" />
	<input id="hidCourseDetails" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidAcademicYearID" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidFacID" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidCrID" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidMoLrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidPtrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidBrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidCrPrDetailsID" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidCrPrChID" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidExamEventID" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidFacName" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidCrName" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidMoLrnName" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidPtrnName" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidBrnName" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidCrPrName" runat="server" style="width: 32px; height: 22px" type="hidden" />
	<input id="hidCrPrChName" runat="server" style="width: 32px; height: 22px" type="hidden" />

</asp:Content>
