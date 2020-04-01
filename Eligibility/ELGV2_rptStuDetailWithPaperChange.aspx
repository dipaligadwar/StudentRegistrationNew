<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="ELGV2_rptStuDetailWithPaperChange.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_rptStuDetailWithPaperChange" %>

<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript" src="JS/ValidatePRN.js"></script>
    <script language="javascript" type="text/javascript" src="/jscript/AdmissionValidations.js"></script>
    <script language="javascript" type="text/javascript">
        function callvalidate() {

            try {
                var myArr = new Array();
                myArr[myArr.length] = new Array(document.getElementById("<%=ddlAcademicYr.ClientID%>"), "0", "Select Academic Year", "select");
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
        function UnderLineOnMouseOver() {
            document.getElementById("<%=lblAdvSearch.ClientID %>").style.textDecoration = "underline";

        }
        function UnderLineOnMouseOut() {
            document.getElementById("<%=lblAdvSearch.ClientID %>").style.textDecoration = "none";
        }
        function ChkValidation() {

            var obPRN = document.getElementById("<%=txtPRN.ClientID%>").value;
            var obElg = document.getElementById("<%= txtElgFormNo.ClientID%>").value;
            var sStr = obElg.split('-');
            var ret = true;
            var myArr = new Array();
            var j = -1;
            var innerRet = false;
            document.getElementById("<%= hidSSVal.ClientID%>").value = "1";

            if ((obPRN.length == 0) && (obElg.length == 0)) {
                document.getElementById("<%= hidSSVal.ClientID%>").value = "";
                myArr[++j] = new Array(document.getElementById("<%= hidSSVal.ClientID%>"), "Empty", "Please Enter a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Eligibility Form Number.", "text");

            }
            else if ((obPRN.length > 0) && (obElg.length > 0)) {
                document.getElementById("<%= hidSSVal.ClientID%>").value = "";
                myArr[++j] = new Array(document.getElementById("<%= hidSSVal.ClientID%>"), "Empty", "Please Enter either a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Eligibility Form Number.", "text");
            }

            else if (obPRN.length > 0) {
                innerRet = checkdigitPRN_Nomenclature(obPRN, document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText, document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value);
                if (innerRet == true && document.getElementById("<%= hidUserType.ClientID%>").value == "2") // hidUserType = 2 for college login
                {
                    innerRet = CheckInstforStudentPRN();

                    if (innerRet == false) {
                        document.getElementById("<%= hidSSVal.ClientID%>").value = "";
                        myArr[++j] = new Array(document.getElementById("<%= hidSSVal.ClientID%>"), "Empty", "Entered " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " does not belong to selected " + document.getElementById('ctl00_ContentPlaceHolder1_lblCollege').innerText + ".", "text");
                    }
                }
            }
            else if (obElg.length > 0) {
                innerRet = ChkEligFormNumber(obElg);
            }
            else {
                document.getElementById("<%= hidSSVal.ClientID%>").value = "";
                myArr[++j] = new Array(document.getElementById("<%= hidSSVal.ClientID%>"), "Empty", "Please Enter the Eligibility Form Number.", "text");

            }

            ret = validateMe(myArr, 50);
            if (innerRet != false)
                return ret;
            else
                return innerRet;
        }

        function CheckInstforStudentPRN() {
            var ResultStatus = clsStudent.CheckInstforStudentPRN(document.getElementById('<%=hidUniID.ClientID%>').value, document.getElementById('<%=txtPRN.ClientID%>').value, document.getElementById('<%=hidInstID.ClientID%>').value);
            if (ResultStatus.value == "1")   // Student belongs to selected institute
                return true;
            else                            // Student does not belong to selected institute
                return false;

        }
        function fnDisplayDiv() {
            document.getElementById('<%=divYCMOU.ClientID%>').style.display = 'none';
            document.getElementById('<%=divSimpleSearch.ClientID%>').style.display = 'block';
            document.getElementById('<%=lblAdvSearch.ClientID %>').style.display = 'none';
            if (document.getElementById('<%=lblnorecordfound.ClientID%>') != null)
                document.getElementById('<%=lblnorecordfound.ClientID%>').style.display = 'none';
            document.getElementById('<%=lblAcaYear.ClientID%>').innerHTML = '';
            if (document.getElementById('<%=btnDisplay.ClientID%>') != null)
                document.getElementById('<%=btnDisplay.ClientID%>').style.display = 'none';
            if (document.getElementById('<%=divDGEligibility.ClientID%>') != null)
                document.getElementById('<%=divDGEligibility.ClientID%>').style.display = 'none';
            if (document.getElementById('tblbtnDisplay') != null)
                document.getElementById('tblbtnDisplay').style.display = 'none';


        }
    </script>
    <asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
            <table style="border-collapse: collapse" id="table3" bordercolor="#c0c0c0" cellpadding="2"
                width="100%" border="0">
                <tbody>
                    <tr>
                        <td style="width: 705px; border-bottom: #ffd275 1px solid" align="left">
                            <asp:Label runat="server" ID="lblPageHead" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                            <asp:Label runat="server" Font-Bold="True" Font-Size="Smaller" ID="lblAcaYear" meta:resourcekey="lblAcaYearResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td style="width: 705px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div runat="server" id="divSimpleSearch" style="display: none">
                                <br />
                                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                                    <tbody>
                                        <tr align="left">
                                            <td align="right" width="50%">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label runat="server" Text="Enter Eligibility Form Number: "
                                                    ID="tbElgFormNo" meta:resourcekey="tbElgFormNoResource1"></asp:Label>
                                                </b>
                                            </td>
                                            <td align="left" height="30">
                                                <asp:TextBox runat="server" Font-Bold="True" Font-Size="Small" ID="txtElgFormNo"
                                                    onclick="this.value='';" meta:resourcekey="txtElgFormNoResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trOr" align="center">
                                            <td runat="server" id="Td9" align="center" colspan="2">
                                                <b>OR</b>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trPRN" align="left">
                                            <td runat="server" id="Td10" align="right" width="50%">
                                                <strong>
                                                    <asp:Label runat="server" Text="Enter PRN: " ID="lblEnterPRN"></asp:Label>
                                                </strong>
                                            </td>
                                            <td runat="server" id="Td11" align="left" height="30">
                                                <asp:TextBox runat="server" MaxLength="20" Font-Bold="True" Font-Size="Small" ID="txtPRN"
                                                    onclick="this.value='';"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <br />
                                                <asp:Button runat="server"  Text="Search" CssClass="butSubmit" OnClientClick="return ChkValidation()"
                                                    ID="btnSimpleSearch" OnClick="btnSimpleSearch_Click" meta:resourcekey="btnSimpleSearchResource1">
                                                </asp:Button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tbody>
                                    <tr align="right">
                                        <td style="height: 19px" align="right">
                                            <label runat="server" id="lblAdvSearch" style="cursor: hand; color: blue" onmouseover="UnderLineOnMouseOver();"
                                                class="NavLink" onmouseout="UnderLineOnMouseOut();" onclick="fnDisplayDiv();">
                                                Search Student
                                            </label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <br />
                            <div runat="server" id="divYCMOU">
                                <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td align="right">
                                                <asp:Label runat="server" Text="Select Academic Year" Font-Bold="True" Width="221px"
                                                    ID="Label3" meta:resourcekey="Label3Resource1"></asp:Label>
                                            </td>
                                            <td style="width: 1%; height: 20px" align="center">
                                                <b>&nbsp;:&nbsp;</b>
                                            </td>
                                            <td runat="server" id="td8" style="width: 387px; height: 20px" align="left">
                                                <asp:DropDownList runat="server" CssClass="selectbox" Width="298px" ID="ddlAcademicYr"
                                                    meta:resourcekey="ddlAcademicYrResource1">
                                                    <asp:ListItem Text="--- Select ---" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
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
                                                    <asp:Label runat="server" Text="Select Faculty Name" Width="221px" ID="Label4" meta:resourcekey="Label4Resource1"></asp:Label>
                                                </b>
                                            </td>
                                            <td style="width: 1%; height: 20px" align="center">
                                                <b>&nbsp;:&nbsp;</b>
                                            </td>
                                            <td style="height: 20px" align="left" colspan="3">
                                                <asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" Width="298px"
                                                    ID="ddlFacDesc" OnSelectedIndexChanged="ddlFacDesc_SelectedIndexChanged" meta:resourcekey="ddlFacDescResource1">
                                                    <asp:ListItem Text="--- Select ---" Value="-1" meta:resourcekey="ListItemResource2"></asp:ListItem>
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
                                                    <asp:Label runat="server" Text="Select Course Name" ID="Label5" meta:resourcekey="Label5Resource1"></asp:Label>
                                                </b>
                                            </td>
                                            <td align="center">
                                                <b>:</b>
                                            </td>
                                            <td id="td3" align="left" colspan="3">
                                                <asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrDesc"
                                                    OnSelectedIndexChanged="ddlCrDesc_SelectedIndexChanged" meta:resourcekey="ddlCrDescResource1">
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
                                                <asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrBrnDesc"
                                                    OnSelectedIndexChanged="ddlCrBrnDesc_SelectedIndexChanged" meta:resourcekey="ddlCrBrnDescResource1">
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
                                                    <asp:Label runat="server" Text="Select Course Part" ID="Label7" meta:resourcekey="Label7Resource1"></asp:Label>
                                                </b>
                                            </td>
                                            <td style="height: 23px" align="center">
                                                <b>:</b>
                                            </td>
                                            <td style="height: 23px" id="td5" align="left" colspan="3">
                                                <asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrPrDetailsDesc"
                                                    OnSelectedIndexChanged="ddlCrPrDetailsDesc_SelectedIndexChanged" meta:resourcekey="ddlCrPrDetailsDescResource1">
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
                                                <asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrPrChDesc"
                                                    OnSelectedIndexChanged="ddlCrPrChDesc_SelectedIndexChanged" meta:resourcekey="ddlCrPrChDescResource1">
                                                    <asp:ListItem Text="--- Select ---" Value="-1" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                                </asp:DropDownList>
                                                <font class="Mandatory">*</font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 16px" colspan="3">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table id="tblbtnDisplay" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td style="height: 18px" valign="middle" align="center" colspan="4">
                            <asp:Button runat="server" OnClientClick="return callvalidate();" Text="Generate Report"
                                CssClass="butSubmit" ID="btnDisplay" Visible="False" OnClick="btnDisplay_Click"
                                meta:resourcekey="btnDisplayResource1"></asp:Button>
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
            <table style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2" id="tblNorecord"
                width="700" border="0">
                <tr>
                    <td align="center" valign="top">
                        <table>
                            <tbody>
                                <tr>
                                    <td style="width: 641px; height: 15px; text-align: left">
                                        <asp:Label ID="lblnorecordfound" runat="server" CssClass="errorNote" Text="No Record(s) found."
                                            Visible="False" meta:resourcekey="lblnorecordfoundResource1"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div id="divDGEligibility" runat="server" style="display: none; margin-left: 2px;
                            width: 100%; position: relative; border-collapse: collapse">
                            <table id="tblDGEligibility" runat="server">
                                <tr>
                                    <td>
                                        <table id="tblButtonDisplay" runat="server" width="100%">
                                            <tr runat="server">
                                                <td align="right" colspan="4" valign="middle" runat="server">
                                                    <asp:Button ID="btnExcel" runat="server" CssClass="butSubmit" OnClick="btnExcel_Click"
                                                        Text="Export to Excel" />
                                                </td>
                                                <td align="left" runat="server">
                                                    <asp:Button ID="btnGenerate" runat="server" CssClass="butSubmit" OnClick="btnGenerate_Click"
                                                        Text="Export to PDF" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <asp:GridView ID="DGEligibility1" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" BorderStyle="None" CssClass="clGrid grid-view" EnableModelValidation="True"
                                            OnRowDataBound="DGEligibility1_RowDataBound" Style="border-top-style: double;
                                            border-right-style: double; border-left-style: double; border-collapse: collapse;
                                            border-bottom-style: double" Width="100%" meta:resourcekey="DGEligibility1Resource1">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                                    <ItemTemplate>
                                                        <center>
                                                            <%# (Container.DataItemIndex)+1 %>.
                                                            <center>
                                                            </center>
                                                        </center>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Inst_Name" HeaderText="College Name" meta:resourcekey="BoundFieldResource1">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" Width="18%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="StudentName" HeaderText="Student Name" meta:resourcekey="BoundFieldResource2">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PRN_Number" HeaderText="PRN" meta:resourcekey="BoundFieldResource3">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="OldPprs" HeaderText="Old Paper(s)" HtmlEncode="False"
                                                    meta:resourcekey="BoundFieldResource4">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Newpprs" HeaderText="New Paper(s)" HtmlEncode="False"
                                                    meta:resourcekey="BoundFieldResource5">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UserName" HeaderText="UserName" HtmlEncode="False">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Date" HeaderText="Date" HtmlEncode="False">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle CssClass="gridHeader" />
                                            <RowStyle CssClass="gridItem" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <input runat="server" id="hidUniID" type="hidden" />
            <input id="hidInstID" runat="server" type="hidden" />
            <input id="hidFacID" runat="server" type="hidden" />
            <input id="hidCrID" runat="server" type="hidden" />
            <input id="hidMoLrnID" runat="server" type="hidden" />
            <input id="hidPtrnID" runat="server" type="hidden" />
            <input id="hidCollName" runat="server" type="hidden" />
            <input id="hid_AcademicYear" runat="server" type="hidden" />
            <input id="hidUserType" runat="server" type="hidden" />
            <asp:Label ID="lblFac" runat="server" meta:resourceKey="lblFacResource1" Style="display: none"
                Text="Faculty"></asp:Label>
            <asp:Label ID="lblCollege" runat="server" meta:resourceKey="lblCollegeResource1"
                Style="display: none" Text="College"></asp:Label>
            <asp:Label ID="lblCr" runat="server" meta:resourceKey="lblCrResource1" Style="display: none"
                Text="Course"></asp:Label>
            <asp:Label ID="lblPrvCourseNomenclature" runat="server" meta:resourceKey="lblPrvCourseNomenclatureResource1"
                Style="display: none" Text="Course"></asp:Label>
            <asp:Label ID="lblPRNNomenclature" runat="server" meta:resourceKey="lblPRNNomenclatureResource1"
                Style="display: none" Text="PRN"></asp:Label>
            <input id="hidSSVal" runat="server" type="hidden" value="1" />
             <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
            <asp:Label runat="server" Text="Paper" ID="lblPaper" Style="display: none" meta:resourceKey="lblPaperResource1"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlFacDesc" />
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrDesc" />
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrBrnDesc" />
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrPrDetailsDesc" />
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrPrChDesc" />
            <asp:PostBackTrigger ControlID="btnExcel" />
            <asp:PostBackTrigger ControlID="btnGenerate"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnGenerate"></asp:PostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
    <table>
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </table>
    <div id="DivReportViewerDesign" runat="server" style="display: none;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            AsyncRendering="false" Width="100%">
            <LocalReport ReportEmbeddedResource="StudentRegistration.Eligibility.Rdlc.rptStudentDetailwithPaperChange.rdlc"
                EnableExternalImages="True">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>
