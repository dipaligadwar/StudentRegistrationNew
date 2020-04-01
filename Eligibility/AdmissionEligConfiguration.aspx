<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="AdmissionEligConfiguration.aspx.cs" Inherits="StudentRegistration.Eligibility.AdmissionEligConfiguration" meta:resourcekey="PageResource1" %>

<%@ Register Src="WebCtrl/SelectSingleCourse.ascx" TagName="YCMOU" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript">
		function fnBtnSubmitValidate() {

			var i = -1;
			var myArr = new Array();
			myArr[myArr.length] = new Array(document.getElementById("<%=ddlAcadYear.ClientID%>"), 0, "Please Select Academic Year", "select");
			myArr[myArr.length] = new Array(document.getElementById("<%=ddlFacDesc.ClientID%>"), -1, "Please Select " + document.getElementById('<%=lblFac.ClientID%>').innerText, "select");
			myArr[myArr.length] = new Array(document.getElementById("<%=ddlCrDesc.ClientID%>"), -1, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText, "select");
			if (document.getElementById("<%=ddlCrDesc.ClientID%>")[document.getElementById("<%=ddlCrDesc.ClientID%>").selectedIndex].text == "--- Select ---")
				myArr[myArr.length] = new Array(document.getElementById("<%=ddlCrDesc.ClientID%>"), 0, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText, "select");

			if (document.getElementById("<%=ddlCrBrnDesc.ClientID%>")[document.getElementById("<%=ddlCrBrnDesc.ClientID%>").selectedIndex].text != "No Branch Available")
				myArr[myArr.length] = new Array(document.getElementById("<%=ddlCrBrnDesc.ClientID%>"), -1, "Please Select Branch", "select");
			var ret = validateMe(myArr, 50);
			if (ret == false)
				return false;

			var v = $("#<%=rblResultConsideration.ClientID %>");

			var Msg = "Are you sure you want to proceed?";
			if (($("#<%=hidStatusElgConfig.ClientID %>").val() == "N" && $("#<%=hidStatusElgConfigIndepedent.ClientID %>").val() == "N") || ($("#<%=hidStatusElgConfig.ClientID %>").val() == "Y" && $("#<%=hidStatusElgConfigIndepedent.ClientID %>").val() == "N"))
				var Msg = "Are you sure you want to proceed?";
			else if ($("#<%=hidStatusElgConfig.ClientID %>").val() == "N" && $("#<%=hidStatusElgConfigIndepedent.ClientID %>").val() == "Y")
				Msg = "The admission eligibility configuration for the selected course already exists independent of result status.Are you sure you want to proceed?";
			if (ret == true && v.find("input[type='radio']:checked").val() == "2") {
				if ($("#<%=hidStatusElgConfig.ClientID %>").val() == "N" && $("#<%=hidStatusElgConfigIndepedent.ClientID %>").val() == "Y") {
					showAlert(Msg);
					return false;
				}
				else if ($("#<%=hidStatusElgConfig.ClientID %>").val() == "N" && $("#<%=hidStatusElgConfigIndepedent.ClientID %>").val() == "N")
					Msg = "You are not going to consider the result of previous course parts/terms while admitting the students to next course parts/terms.Are you sure you want to proceed?";

				else if ($("#<%=hidStatusElgConfig.ClientID %>").val() == "Y" && $("#<%=hidStatusElgConfigIndepedent.ClientID %>").val() == "N") {
					Msg = "The admission eligibility configuration for the selected course is already saved considering the result status. If you want configuration independent of result status, delete the saved configurations first for the selected course.";
					showAlert(Msg);
					return false;
				}
				var UniqueID = '<%=btnSubmit.UniqueID%>';
				ShowConfirm(UniqueID, Msg);
				return false;
			}
			//            else if (ret == true && v.find("input[type='radio']:checked").val() == "1") {
			//                if ($("#<%=hidStatusElgConfig.ClientID %>").val() == "Y" && $("#<%=hidStatusElgConfigIndepedent.ClientID %>").val() == "N") {
			//                    showAlert(Msg);
			//                    return false;
			//                }

			//                var UniqueID = '<%=btnSubmit.UniqueID%>';
			//                ShowConfirm(UniqueID, Msg);
			//                return false;
			//            }
			else {
				var UniqueID = '<%=btnSubmit.UniqueID%>';
				ShowConfirm(UniqueID, Msg);
				return false;
				//return ret;
			}
			// return ret;
		}

		function validate() {
			var rowcount = $("#<%=hidRowCount.ClientID%>").val();
			var v = true;
			for (var i = 1; i <= rowcount; i++) {
				if ($(".row" + i.toString()).find("input[type='radio']:checked").length == 0) {


					$(".row" + i.toString()).attr("style", "background-color:Aqua");
					v = false;
				}
				else
					$(".row" + i.toString()).attr("style", "background-color:transparent");
			}
			if (v == false) {
				showValidationSummary('', "<li> Please select one category per FeeHead.");
				return false;
			}
			else {

				CreateXML();
				CreateXMLDC();
				return true;
			}
		}

		function callvalidate() {

			try {
				var myArr = new Array();
				myArr[myArr.length] = new Array(document.getElementById("<%=ddlFacDesc.ClientID%>"), -1, "Please Select " + document.getElementById('<%=lblFac.ClientID%>').innerText, "select");
				myArr[myArr.length] = new Array(document.getElementById("<%=ddlCrDesc.ClientID%>"), -1, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText, "select");
				if (document.getElementById("<%=ddlCrDesc.ClientID%>")[document.getElementById("<%=ddlCrDesc.ClientID%>").selectedIndex].text == "--- Select ---")
					myArr[myArr.length] = new Array(document.getElementById("<%=ddlCrDesc.ClientID%>"), 0, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText, "select");

				if (document.getElementById("<%=ddlCrBrnDesc.ClientID%>")[document.getElementById("<%=ddlCrBrnDesc.ClientID%>").selectedIndex].text != "No Branch Available")
					myArr[myArr.length] = new Array(document.getElementById("<%=ddlCrBrnDesc.ClientID%>"), -1, "Please Select Branch", "select");
				myArr[myArr.length] = new Array(document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>"), -1, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText + " Part", "select");
				myArr[myArr.length] = new Array(document.getElementById("<%=ddlCrPrChDesc.ClientID%>"), -1, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText + " Part Child", "select");
				if (document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>")[document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>").selectedIndex].text == "--- Select ---")
					myArr[myArr.length] = new Array(document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>"), 0, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText + " Part", "select");
				if (document.getElementById("<%=ddlCrPrChDesc.ClientID%>")[document.getElementById("<%=ddlCrPrChDesc.ClientID%>").selectedIndex].text == "--- Select ---")
					myArr[myArr.length] = new Array(document.getElementById("<%=ddlCrPrChDesc.ClientID%>"), 0, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText + " Part Child", "select");
				var ret = validateMe(myArr, 50);
				return ret;
			}
			catch (e) {
				alert(e.message);
				return false;
			}
		}


		function CreateXML() {

			var rowcount = $("#<%=hidRowCount.ClientID%>").val();

			var xml = "";
			var TermCount = $(".row1 td").length - 1;
			for (var i = 1; i <= rowcount; i++) {


				if ($(".row" + i.toString()).find("input[type='radio']:checked")[0].value == "E") {
					xml += "<Eligibility>"
					$(".row" + i.toString()).find("td").each(function (index) {
						if (index != TermCount) {
							xml += "<Term" + (index + 1).toString() + " id='" + $(this).attr("id") + "'>";
							xml += $(this).html();
							xml += "</Term" + (index + 1).toString() + ">";
						}

					})
					xml += "</Eligibility>";
				}


			}
			if (xml == "" || xml == null)
				$("#<%=hidXml.ClientID%>").val("");
			else
				$("#<%=hidXml.ClientID%>").val("<Elibilities TermCount='" + TermCount.toString() + "' TermOrPartNames='" + $("#<%=hidTermOrPartNames.ClientID%>").val() + "' id='" + $("#<%=hidCurrentCrKeys.ClientID%>").val() + "'>" + xml + "</Elibilities>");
			//            alert($("#<%=hidXml.ClientID%>").val());

			CreateXMLDC();
		}

		function CreateXMLDC() {
			var rowcount = $("#<%=hidRowCount.ClientID%>").val();
			var xml = "";
			var GopupID = 0;
			var TermCount = $(".row1 td").length - 1;
			for (var i = 1; i <= rowcount; i++) {


				if ($(".row" + i.toString()).find("input[type='radio']:checked")[0].value == "E") {
					GopupID++;
					xml += "<Eligibility>"
					$(".row" + i.toString()).find("td").each(function (index) {

						if (index != TermCount) {
							xml += "<Term>"
							xml += "<pk_Uni_ID>" + $(this).attr("id").split('-')[0] + "</pk_Uni_ID>"
							xml += "<pk_Fac_ID>" + $(this).attr("id").split('-')[1] + "</pk_Fac_ID>"
							xml += "<pk_Cr_ID>" + $(this).attr("id").split('-')[2] + "</pk_Cr_ID>"
							xml += "<pk_MoLrn_ID>" + $(this).attr("id").split('-')[3] + "</pk_MoLrn_ID>"
							xml += "<pk_Ptrn_ID>" + $(this).attr("id").split('-')[4] + "</pk_Ptrn_ID>"
							xml += "<pk_Brn_ID>" + $(this).attr("id").split('-')[5] + "</pk_Brn_ID>"
							xml += "<pk_CrPr_Details_ID>" + $(this).attr("id").split('-')[6] + "</pk_CrPr_Details_ID>"
							xml += "<pk_CrPrCh_ID>" + $(this).attr("id").split('-')[7] + "</pk_CrPrCh_ID>"
							switch ($(this).html()) {
								case 'Pass':
									xml += "<Result_Status>" + 1 + "</Result_Status>";
									break;
								case 'Absent':
									xml += "<Result_Status>" + 5 + "</Result_Status>";
									break;
								case 'ATKT':
									xml += "<Result_Status>" + 2 + "</Result_Status>";
									break;
								case 'Fail':
									xml += "<Result_Status>" + 3 + "</Result_Status>";
									break;
								default:
									xml += "<Result_Status>" + 0 + "</Result_Status>";
									break;
							}


							xml += "<Group_ID>" + GopupID.toString() + "</Group_ID>"
							xml += "</Term>"
							//                            xml += "<Term" + (index + 1).toString() + " id='" + $(this).attr("id") + "'>";
							//                            xml += $(this).html();
							//                            xml += "</Term" + (index + 1).toString() + ">";
						}

					})
					xml += "</Eligibility>";
				}


			}
			if (xml == "" || xml == null)
				$("#<%=hidXMLDc.ClientID%>").val("");
			else
				$("#<%=hidXMLDc.ClientID%>").val("<Elibilities TermCount='" + TermCount.toString() + "' TermOrPartNames='" + $("#<%=hidTermOrPartNames.ClientID%>").val() + "' id='" + $("#<%=hidCurrentCrKeys.ClientID%>").val() + "'>" + xml + "</Elibilities>");



		}
		function fnConfirmDelete() {

			var UniqueID = '<%=btnDelete.UniqueID%>';
			ShowConfirm(UniqueID, 'Are you sure you want to delete this the configuration?');
			return false;

		}


       


	</script>
	<div id="PageTitleHolder" align="left">
		<asp:Label runat="server" ID="lblPageHead" Text="Configure Admission Eligibility" meta:resourcekey="lblPageHeadResource1"></asp:Label>
	</div>
	<asp:UpdatePanel ID="updContent" runat="server">
		<ContentTemplate>
			<fieldset>
				<legend>Admission Eligibility</legend>
				<div align="left" style="padding: 5px 5px 5px 5px;" />
				<div>
					<table id="buttonHolder" border="0" cellpadding="0" cellspacing="0" class="ToolBar" width="100%">
						<tr>
							<%-- <td align="center" width="10%">
                                <img border="0" height="16" src="../images/button_new.gif" width="16" alt="" />
                                <asp:Button ID="btnNew" runat="server" CssClass="But" Text="New" Enabled="False"
                                    meta:resourcekey="btnNewResource1" />
                            </td>--%>
							<td align="center" width="10%">
								<img border="0" height="16" src="../images/button_save.gif" width="16" alt="" />
								<asp:Button OnClientClick="return CreateXML();" Text="Save" ID="btn_Save" Enabled="False" runat="server" OnClick="btn_Save_Click" meta:resourcekey="btn_SaveResource1" />
							</td>
							<td align="center" width="11%">
								<img border="0" height="16" src="../images/button_delete.gif" width="16" alt="" /><strong> </strong>
								<asp:Button runat="server" CssClass="But" Enabled="False" EnableViewState="False" OnClientClick="return fnConfirmDelete();" OnClick="btnDelete_Click" Text="Delete" ID="btnDelete" meta:resourcekey="btnDeleteResource1" />
							</td>
							<td align="right">
								&nbsp;
							</td>
						</tr>
					</table>
				</div>
				<fieldset>
					<table cellspacing="5" cellpadding="0;" width="100%" border="0">
						<tbody>
							<tr>
								<td align="right">
									<b>
										<asp:Label runat="server" Text="Select Academic Year" Width="221px" ID="lblAcademicYr" meta:resourcekey="lblAcademicYrResource1"></asp:Label>
									</b>
								</td>
								<td style="width: 1%; height: 20px" align="center">
									<b>&nbsp;:&nbsp;</b>
								</td>
								<td style="height: 20px" align="left" colspan="3">
									<asp:DropDownList ID="ddlAcadYear" Width="298px" runat="server" meta:resourcekey="ddlAcadYearResource1">
										<asp:ListItem Value="0" meta:resourcekey="ListItemResource1">---- Select ----</asp:ListItem>
									</asp:DropDownList>
									<font class="Mandatory">*</font>
								</td>
							</tr>
							<tr>
								<td align="right">
									<b>
										<asp:Label runat="server" Text="Select Faculty Name" Width="221px" ID="Label4" meta:resourcekey="Label4Resource1"></asp:Label>
									</b>
								</td>
								<td style="width: 1%; height: 20px" align="center">
									<b>&nbsp;:&nbsp;</b>
								</td>
								<td style="height: 20px" align="left" colspan="3">
									<asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" Width="298px" ID="ddlFacDesc" OnSelectedIndexChanged="ddlFacDesc_SelectedIndexChanged" meta:resourcekey="ddlFacDescResource1">
										<asp:ListItem Text="--- Select ---" Value="-1" meta:resourcekey="ListItemResource2"></asp:ListItem>
									</asp:DropDownList>
									<font class="Mandatory">*</font>
								</td>
							</tr>
							<tr>
								<td align="right">
									<b>
										<asp:Label runat="server" Text="Select Course Name" ID="Label5" meta:resourcekey="Label5Resource1"></asp:Label>
									</b>
								</td>
								<td align="center">
									<b>:</b>
								</td>
								<td id="td3" align="left" colspan="3">
									<asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrDesc" OnSelectedIndexChanged="ddlCrDesc_SelectedIndexChanged" meta:resourcekey="ddlCrDescResource1">
										<asp:ListItem Text="--- Select ---" Value="-1" meta:resourcekey="ListItemResource3"></asp:ListItem>
									</asp:DropDownList>
									<font class="Mandatory">*</font>
								</td>
							</tr>
							<tr>
								<td colspan="3">
								</td>
							</tr>
							<tr id="tr2">
								<td align="right">
									<strong>
										<asp:Label runat="server" Text="Select Course Branch" ID="Label6" meta:resourcekey="Label6Resource1"></asp:Label>
									</strong>
								</td>
								<td align="center">
									<b>:</b>
								</td>
								<td id="td4" align="left" colspan="3">
									<asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrBrnDesc" OnSelectedIndexChanged="ddlCrBrnDesc_SelectedIndexChanged" meta:resourcekey="ddlCrBrnDescResource1">
										<asp:ListItem Text="--- Select ---" Value="-1" meta:resourcekey="ListItemResource4"></asp:ListItem>
									</asp:DropDownList>
									<font class="Mandatory">*</font>
								</td>
							</tr>
							<tr>
								<td colspan="3">
								</td>
							</tr>
							<tr>
								<td style="height: 23px" align="right">
									<b>
										<asp:Label runat="server" Text="Do you want to Consider Results for Admission?" ID="lblResultConsideration" meta:resourcekey="lblResultConsiderationResource1"></asp:Label>
									</b>
								</td>
								<td align="center">
									<b>:</b>
								</td>
								<td id="td2" align="left">
									<asp:RadioButtonList ID="rblResultConsideration" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" RepeatLayout="Flow" OnSelectedIndexChanged="rblResultConsideration_SelectedIndexChanged">
										<asp:ListItem Text="Yes" Value="1" Selected="True" />
										<asp:ListItem Text="No" Value="2" />
									</asp:RadioButtonList>
									<font class="Mandatory">*</font>
								</td>
							</tr>
							<tr>
								<td colspan="5">
									<%--<asp:Label CssClass="Mandatory" Text="To Define Admission Eligibility Configuration Please select Yes and Submit." ID="lblNoteResultConsideration" runat="server" />--%>
									<div class="clOuterDiv" style="margin-left: 25px; margin-top: 1px;">
										<div class="clImageHolder">
										</div>
										<div class="clInfoHolder" style="padding-bottom: 8px; background-color: #EFEFEF; min-height: 100px;">
											<table>
												<tr>
													<td style="padding-left: 5px; vertical-align: top;">
														Select "Yes"- if you are considering the results of previous Course parts/Terms as eligibility criteria for admission to next Course parts/Terms. <b style="color: Red">
															<br />
															<br />
															If the results of previous course parts/Terms are not available then after selecting "Yes" button, you will not be able to admit those students to next course parts/Terms.</b><br />
														<br />
														Select 'No" if you are not considering the results of previous Course parts/Terms as eligibility criteria for admission to next Course parts/Terms. </asp:Label>
													</td>
												</tr>
											</table>
										</div>
									</div>
									<br />
								</td>
							</tr>
							<tr>
								<td style="height: 23px" align="right">
								</td>
								<td style="height: 23px" align="center">
								</td>
								<td style="height: 23px" id="td7" align="left" colspan="3">
									<asp:Button Text="Submit" ID="btnSubmit" OnClientClick="return fnBtnSubmitValidate();" runat="server" OnClick="btnSubmit_Click" />
								</td>
							</tr>
						</tbody>
					</table>
				</fieldset>
				<fieldset style="margin-top: 5px;" id="tblAdmissionEligibility" visible="false" runat="server">
					<table runat="server" cellpadding="2" width="100%" border="0" cellspacing="5">
						<tbody>
							<tr>
								<td style="height: 23px; width: 50%;" align="right">
									<b>
										<asp:Label runat="server" Text="At which level you want to configure its result status?" ID="lblPartorTerm" meta:resourcekey="lblPartorTermResource1"></asp:Label>
									</b>
								</td>
								<td style="height: 23px; width: 1%;" align="center">
									<b>&nbsp;:&nbsp;</b>
								</td>
								<td style="height: 23px;" id="td1" align="left" colspan="3">
									<asp:RadioButtonList ID="rdbPartOrTerm" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="rdbPartOrTerm_SelectedIndexChanged" AutoPostBack="true">
										<asp:ListItem Text="Part" Value="1" Selected="True" />
										<asp:ListItem Text="Term" Value="2" />
									</asp:RadioButtonList>
									<font class="Mandatory">*</font>
								</td>
							</tr>
							<tr>
								<td colspan="5">
									<div class="clOuterDiv" style="margin-left: 25px; margin-top: 1px;">
										<div class="clImageHolder">
										</div>
										<div class="clInfoHolder" style="padding-bottom: 8px; background-color: #EFEFEF; min-height: 100px;">
											<table width="100%">
												<tr>
													<td style="padding-left: 5px; vertical-align: top;">
														Select "Part" if you want to admit the student in next course parts/Terms level considering the result of previous course part.(e.g. SY B.A., TY B.A. etc.) After selecting "Part", you have to make configuration on part level only.<br />
														<br />
														Select "Term" if you want to admit the student in next course parts/Terms level considering the result of previous course terms. (e.g. FY B.A.Sem II, SY B.A. Sem III, Sem Iv etc.)After selecting "Term", you have to make configuration on term level only. <b style="color: Red">
															<br />
															<br />
															While configuring the eligibility definition, do it by ascneding order (e.g.SY B.A., TY B.A., OR FY B.A.Sem II, SY B.A. Sem III, Sem Iv etc.) While deleting the configuration of the eligibility definition, do it by descending order (e.g.TY B.A., SY B.A.OR TY B.A. Sem VI, Sem V, SY B.A. Sem III, Sem Iv, FY B.A.Sem II etc.)</b> </asp:Label>
													</td>
												</tr>
											</table>
										</div>
									</div>
									<br />
								</td>
							</tr>
							<tr>
								<td style="height: 23px" align="right">
									<b>
										<asp:Label runat="server" Text="Select Course Part" ID="Label7" meta:resourcekey="Label7Resource1"></asp:Label>
									</b>
								</td>
								<td style="height: 23px" align="center">
									<b>:</b>
								</td>
								<td style="height: 23px" id="td5" align="left" colspan="3">
									<asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrPrDetailsDesc" OnSelectedIndexChanged="ddlCrPrDetailsDesc_SelectedIndexChanged" meta:resourcekey="ddlCrPrDetailsDescResource1">
										<asp:ListItem Text="--- Select ---" Value="-1" meta:resourcekey="ListItemResource5"></asp:ListItem>
									</asp:DropDownList>
									<font class="Mandatory">*</font>
								</td>
							</tr>
							<tr>
								<td colspan="3">
								</td>
							</tr>
							<tr>
								<td align="right">
									<b>
										<asp:Label runat="server" Text="Select Course Part Term" ID="Label8" meta:resourcekey="Label8Resource1"></asp:Label>
									</b>
								</td>
								<td style="width: 1%" align="center">
									<b>:</b>
								</td>
								<td id="td6" align="left" colspan="3">
									<asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrPrChDesc" OnSelectedIndexChanged="ddlCrPrChDesc_SelectedIndexChanged" meta:resourcekey="ddlCrPrChDescResource1">
										<asp:ListItem Text="--- Select ---" Value="-1" meta:resourcekey="ListItemResource6"></asp:ListItem>
									</asp:DropDownList>
									<font class="Mandatory">*</font>
								</td>
							</tr>
							<tr>
								<td colspan="3">
								</td>
							</tr>
						</tbody>
					</table>
				</fieldset>
				</div>
				<input id="hidUniID" runat="server" name="hidUniID" type="hidden" />
				<input id="hidBrnID" runat="server" name="hidBrnID" type="hidden" />
				<input id="hidCrPrDetailsID" runat="server" name="hidCrPrDetailsID" type="hidden" />
				<input id="hidCrPrChID" runat="server" name="hidCrPrChID" type="hidden" />
				<input id="hidAcademicYearID" type="hidden" name="hidAcademicYearID" runat="server" />
				<input id="hidFacID" runat="server" type="hidden" />
				<input id="hidCrID" runat="server" type="hidden" />
				<input id="hidMoLrnID" runat="server" type="hidden" />
				<input id="hidPtrnID" runat="server" type="hidden" />
				<asp:Label ID="lblFac" runat="server" meta:resourceKey="lblFacResource1" Style="display: none" Text="Faculty"></asp:Label>
				<asp:Label ID="lblCr" runat="server" meta:resourceKey="lblCrResource1" Style="display: none" Text="Course"></asp:Label>
				<div align="right" class="saveNote">
					<asp:Label ID="lblNote" runat="server" meta:resourcekey="lblNoteResource1" Text="Information saved successfully." Visible="False"></asp:Label>
				</div>
				<div id="divtable" runat="server" style="margin: 10px;">
					<div style="text-align: left; margin: 10px; font-weight: bold;">
						<asp:Literal ID="lttitle" runat="server" meta:resourcekey="lttitleResource1"></asp:Literal>
					</div>
					<table border="0" cellpadding="2" cellspacing="0" width="100%">
						<tbody>
							<tr>
								<td>
									<asp:PlaceHolder ID="ph" EnableViewState="false" runat="server"></asp:PlaceHolder>
								</td>
							</tr>
						</tbody>
					</table>
				</div>
			</fieldset>
			<div align="right" class="errorNote" style="margin: 5px;">
				<asp:Label ID="lblErrorMessage" runat="server" meta:resourcekey="lblErrorMessageResource1"></asp:Label>
			</div>
			<input id="hidXml" runat="server" type="hidden" />
			<input id="hidXMLDc" runat="server" type="hidden" />
			<input id="hidRowCount" runat="server" type="hidden" />
			<input id="hidPreviousAndCurrentCrKeys" runat="server" type="hidden" />
			<input id="hidTermOrPartNames" runat="server" type="hidden" />
			<input id="hidPreviousCrKeys" runat="server" type="hidden" />
			<input id="hidCurrentCrKeys" runat="server" type="hidden" />
			<input id="hidStatusElgConfig" runat="server" type="hidden" />
			<input id="hidStatusElgConfigIndepedent" runat="server" type="hidden" />
			<input id="hidCurrentAndPreviousKeys" type="hidden" name="hidCurrentAndPreviousKeys" runat="server" />
			<input id="hidAdmissionElgTypeID" type="hidden" name="hidAdmissionElgTypeID" runat="server" />
			<input id="hidResultConsideration" type="hidden" name="hidResultConsideration" runat="server" />
			</fieldset>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="rblResultConsideration" />
			<asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlFacDesc" />
			<asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrDesc" />
			<asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrBrnDesc" />
			<asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrPrDetailsDesc" />
			<asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrPrChDesc" />
			<asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="rdbPartOrTerm" />
			<asp:PostBackTrigger ControlID="btnSubmit" />
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>
