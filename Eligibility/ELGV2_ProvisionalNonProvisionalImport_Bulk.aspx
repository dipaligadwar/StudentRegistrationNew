<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="ELGV2_ProvisionalNonProvisionalImport_Bulk.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_ProvisionalNonProvisionalImport_Bulk" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="ajax/StudentRegistration.Eligibility.clsEligibilityDBAccess,StudentRegistration.ashx"></script>
    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>
    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>
    <script language="javascript">

        var hidFacClientID = '<%=hidFacID.ClientID%>';
        var hidCrClientID = '<%=hidCrID.ClientID%>';
        var hidMoLrnClientID = '<%=hidMoLrnID.ClientID%>';
        var hidPtrnClientID = '<%=hidPtrnID.ClientID%>';
        var hidBrnClientID = '<%=hidBrnID.ClientID%>';
        var hidCrPrDetailsIDClientID = '<%=hidCrPrDetailsID.ClientID%>';
        var hidCrPrChIDClientID = '<%=hidCrPrChID.ClientID%>';

        var hidUniClientID = '<%=hidUniID.ClientID%>';

        var ddlFacDescClient = '<%=ddlFacDesc.ClientID%>';
        var ddlCrDescClient = '<%=ddlCrDesc.ClientID%>';
        var ddlCrBrnDescClient = '<%=ddlCrBrnDesc.ClientID%>';
        var ddlCrPrDetailsDescClient = '<%=ddlCrPrDetailsDesc.ClientID%>';
        var ddlCrPrChDescClient = '<%=ddlCrPrChDesc.ClientID%>';
        var hidAcademicYr = '<%= ddlAcademicYr.ClientID%>';
        var hidCourseDetailsClientID = '<%=hidCourseDetails.ClientID%>';
        var collTxt;
        var result = false;
        var alert1 = false;



        function callvalidate() {
            try {
                var i = -1;
                var myArr = new Array();
                var str = "";
                var cbArr = new Array(1);

                var flag = false;
                myArr[++i] = new Array(document.getElementById(hidAcademicYr), "0", "Select Academic Year", "select");
                myArr[++i] = new Array(document.getElementById("<%=ddlFacDesc.ClientID%>"), -1, "Please Select " + document.getElementById('<%=lblFac.ClientID%>').innerText, "select");
                myArr[++i] = new Array(document.getElementById("<%=ddlCrDesc.ClientID%>"), -1, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText, "select");


                if (document.getElementById("<%=ddlCrDesc.ClientID%>")[document.getElementById("<%=ddlCrDesc.ClientID%>").selectedIndex].text == "--- Select ---")
                    myArr[++i] = new Array(document.getElementById("<%=ddlCrDesc.ClientID%>"), 0, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText, "select");

                if (document.getElementById("<%=ddlCrBrnDesc.ClientID%>")[document.getElementById("<%=ddlCrBrnDesc.ClientID%>").selectedIndex].text != "No Branch Available")
                    myArr[++i] = new Array(document.getElementById("<%=ddlCrBrnDesc.ClientID%>"), -1, "Please Select Branch", "select");
                myArr[++i] = new Array(document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>"), -1, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText + " Part", "select");
                myArr[++i] = new Array(document.getElementById("<%=ddlCrPrChDesc.ClientID%>"), -1, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText + " Part Child", "select");
                if (document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>")[document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>").selectedIndex].text == "--- Select ---")
                    myArr[++i] = new Array(document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>"), 0, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText + " Part", "select");
                if (document.getElementById("<%=ddlCrPrChDesc.ClientID%>")[document.getElementById("<%=ddlCrPrChDesc.ClientID%>").selectedIndex].text == "--- Select ---")
                    myArr[++i] = new Array(document.getElementById("<%=ddlCrPrChDesc.ClientID%>"), 0, "Please Select " + document.getElementById('<%=lblCr.ClientID%>').innerText + " Part Child", "select");


                //validate that one criteria is checked




                if (validateMe(myArr, 50)) {
                    var str = "";
                    str += document.getElementById('<%=ddlFacDesc.ClientID%>')[document.getElementById('<%=ddlFacDesc.ClientID%>').selectedIndex].text + " - ";
                    str += document.getElementById('<%=ddlCrDesc.ClientID%>')[document.getElementById('<%=ddlCrDesc.ClientID%>').selectedIndex].text + " - ";

                    str += document.getElementById('<%=ddlCrPrDetailsDesc.ClientID%>')[document.getElementById('<%=ddlCrPrDetailsDesc.ClientID%>').selectedIndex].text + " - ";
                    str += document.getElementById('<%=ddlCrPrChDesc.ClientID%>')[document.getElementById('<%=ddlCrPrChDesc.ClientID%>').selectedIndex].text;

                    document.getElementById(hidCourseDetailsClientID).value = str;
                    alert1 = true;
                    return true;
                }
                else {
                    alert1 = false;
                    return false;
                }

            }
            catch (e) {
                alert(e.message);
                return false;
            }
        }

        function setValue(Text, Value) {

            var text = eval(document.getElementById(Text));
            text.value = Value;

        }

        function setCrPart(val) {

            document.getElementById(hidCrPrDetailsIDClientID).value = val;
            //alert(document.getElementById(hidCrPrDetailsIDClientID).value);
            //document.getElementById('ctl00_ContentPlaceHolder1_hidCrPrID').value = val;

        }


        function FetchFacultyWiseCourseList(location, UniID, FacID, HtmlSelCrID, LevelFlag) {

            sTableCellID = location;
            clsAjaxMethods.FetchFacultyWiseLaunchedCourseList(UniID, FacID, HtmlSelCrID, LevelFlag, BindDataToCombo_CallBack);
        }
        // To Get Coursewise Mode Of Learning List(Launched).....Developed by Amit
        function FetchCourseWiseLaunchedModeOfLearningList(location, UniID, FacID, CrID, HtmlSelMoLrnID, LevelFlag) {
            sTableCellID = location;
            clsAjaxMethods.FetchCourseWiseLaunchedModeOfLearningList(UniID, FacID, CrID, HtmlSelMoLrnID, LevelFlag, BindDataToCombo_CallBack);

        }
        // To Get Course Mode Of Learning Wise Course Pattern List(Launched).....Developed By Madhu
        function FetchCourseMoLrnwiseLaunchedCoursePatternsList(location, UniID, FacID, CrID, MoLrnID, HtmlSelCrPtrnID, LevelFlag) {

            sTableCellID = location;
            clsAjaxMethods.FetchCourseMoLrnwiseLaunchedCoursePatternsList(UniID, FacID, CrID, MoLrnID, HtmlSelCrPtrnID, LevelFlag, BindDataToCombo_CallBack);
        }

        // To Get Course Mode Of Learning Pattern Wise Branch List(Launched).....Developed By Madhu
        function FetchCourseMoLrnPtrnWiseLaunchedBranchList(location, UniID, FacID, CrID, MoLrnID, PtrnID, HtmlSelCrBrnID, LevelFlag) {


            //alert(location + UniID + FacID + CrID + MoLrnID + PtrnID + HtmlSelCrBrnID + LevelFlag);
            sTableCellID = location;
            clsAjaxMethods.FetchCourseMoLrnPtrnWiseLaunchedBranchList(UniID, FacID, CrID, MoLrnID, PtrnID, HtmlSelCrBrnID, LevelFlag, BindDataToCombo_CallBack);
        }
        function FetchCourseWiseCoursePartList(location, UniID, FacID, CrID, MoLrnID, PtrnID, BrnID, HtmlSelCrBrnID, LevelFlag) {

            //alert(location + UniID + FacID + CrID + MoLrnID + PtrnID + HtmlSelCrBrnID + LevelFlag);
            sTableCellID = location;
            clsAjaxMethods.FetchCourseWiseCoursePartList(UniID, FacID, CrID, MoLrnID, PtrnID, BrnID, HtmlSelCrBrnID, LevelFlag, BindDataToCombo_CallBack);
        }

        function FetchCourseMoLrnPtrnBrnWiseLaunchedCoursePartList(location, UniID, FacID, CrID, MoLrnID, PtrnID, BrnID, HtmlSelCrPrID, LevelFlag) {

            //alert(location + UniID + FacID + CrID + MoLrnID + PtrnID + HtmlSelCrBrnID + LevelFlag);
            sTableCellID = location;
            clsAjaxMethods.FetchCourseMoLrnPtrnBrnWiseLaunchedCoursePartList(UniID, FacID, CrID, MoLrnID, PtrnID, BrnID, HtmlSelCrPrID, LevelFlag, BindDataToCombo_CallBack);
        }

        function FetchCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrChList(location, UniID, CrPrDetailsID, HtmlSelCrPrChID, LevelFlag) {

            sTableCellID = location;
            clsAjaxMethods.FetchCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrChList(UniID, CrPrDetailsID, HtmlSelCrPrChID, LevelFlag, BindDataToCombo_CallBack);
        }


        var sTableCellID;
        //To get the dropdown which is not mandatory
        function BindDataToCombo_CallBack(response) {

            if (response.error == null) {
                document.getElementById(sTableCellID).innerHTML = response.value + "&nbsp;<FONT class='Mandatory'>*</FONT>";
            }
        }

    </script>
    <asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
            <table style="border-collapse: collapse" id="table3" bordercolor="#c0c0c0" cellpadding="2"
                width="100%" border="0">
                <tbody>
                    <tr>
                        <td style="width: 705px; border-bottom: #ffd275 1px solid" align="left">
                            <asp:Label runat="server" ID="lblPageHead" meta:resourceKey="lblPageHeadResource1"></asp:Label>
                            <asp:Label runat="server" Font-Bold="True" Font-Size="Small" ID="lblAcaYear" meta:resourceKey="lblAcaYearResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td style="width: 705px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 705px" valign="top" align="left">
                            
                            <table runat="server" id="Table2" style="margin-left: 30px; width: 90%; azimuth: center">
                                <tr runat="server" id="Tr1">
                                    <td runat="server" id="Td2">
                                        <div runat="server" id="Div3" style="azimuth: center">
                                            <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 125px; height: 20px" align="right">
                                                            <asp:Label runat="server" Text="Select Academic Year" Font-Bold="True" Width="221px"
                                                                ID="Label3" meta:resourceKey="lblAcyrResource1"></asp:Label>
                                                        </td>
                                                        <td style="width: 1%; height: 20px" align="center">
                                                            <b>&nbsp;:&nbsp;</b>
                                                        </td>
                                                        <td runat="server" id="td1" style="width: 387px; height: 20px" align="left">
                                                            <asp:DropDownList runat="server" CssClass="selectbox" Width="150px" ID="ddlAcademicYr"
                                                                meta:resourceKey="ddlAcademicYrResource1">
                                                                <asp:ListItem Text="--- Select ---" Value="0" meta:resourceKey="ListItemResource1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <font class="Mandatory">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 125px; height: 20px" align="right">
                                                            <b>
                                                                <asp:Label runat="server" Text="Select Faculty Name" Width="221px" ID="Label4" meta:resourceKey="Label4Resource1"></asp:Label>
                                                            </b>
                                                        </td>
                                                        <td style="width: 1%; height: 20px" align="center">
                                                            <b>&nbsp;:&nbsp;</b>
                                                        </td>
                                                        <td style="height: 20px" align="left" colspan="3">
                                                            <asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" Width="298px"
                                                                ID="ddlFacDesc" OnSelectedIndexChanged="ddlFacDesc_SelectedIndexChanged">
                                                                <asp:ListItem Text="--- Select ---" Value="-1" meta:resourceKey="ListItemResource2"></asp:ListItem>
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
                                                                <asp:Label runat="server" Text="Select Course Name" ID="Label5" meta:resourceKey="Label5Resource2"></asp:Label>
                                                            </b>
                                                        </td>
                                                        <td align="center">
                                                            <b>:</b>
                                                        </td>
                                                        <td id="td3" align="left" colspan="3">
                                                            <asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrDesc"
                                                                meta:resourceKey="ddlCrDescResource1" OnSelectedIndexChanged="ddlCrDesc_SelectedIndexChanged">
                                                                <asp:ListItem Text="--- Select ---" Value="-1"></asp:ListItem>
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
                                                                <asp:Label runat="server" Text="Select Course Branch" ID="Label6" meta:resourceKey="Label6Resource2"></asp:Label>
                                                            </strong>
                                                        </td>
                                                        <td align="center">
                                                            <b>:</b>
                                                        </td>
                                                        <td id="td4" align="left" colspan="3">
                                                            <asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrBrnDesc"
                                                                meta:resourceKey="ddlCrBrnDescResource1" OnSelectedIndexChanged="ddlCrBrnDesc_SelectedIndexChanged">
                                                                <asp:ListItem Text="--- Select ---" Value="-1" meta:resourceKey="ListItemResource6"></asp:ListItem>
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
                                                                <asp:Label runat="server" Text="Select Course Part" ID="Label7" meta:resourceKey="Label7Resource2"></asp:Label>
                                                            </b>
                                                        </td>
                                                        <td style="height: 23px" align="center">
                                                            <b>:</b>
                                                        </td>
                                                        <td style="height: 23px" id="td5" align="left" colspan="3">
                                                            <asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrPrDetailsDesc"
                                                                meta:resourceKey="ddlCrPrDetailsDescResource1" OnSelectedIndexChanged="ddlCrPrDetailsDesc_SelectedIndexChanged">
                                                                <asp:ListItem Text="--- Select ---" Value="-1"></asp:ListItem>
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
                                                                <asp:Label runat="server" Text="Select Course Part Term" ID="Label8" meta:resourceKey="Label8Resource2"></asp:Label>
                                                            </b>
                                                        </td>
                                                        <td style="width: 1%" align="center">
                                                            <b>:</b>
                                                        </td>
                                                        <td id="td6" align="left" colspan="3">
                                                            <asp:DropDownList runat="server" AutoPostBack="True" CssClass="selectbox" ID="ddlCrPrChDesc"
                                                                meta:resourceKey="ddlCrPrChDescResource1" OnSelectedIndexChanged="ddlCrPrChDesc_SelectedIndexChanged">
                                                                <asp:ListItem Text="--- Select ---" Value="-1"></asp:ListItem>
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
                            </table>
                            <div runat="server" id="DivGenerate">
                                <table cellpadding="0" width="100%">
                                    <tbody>
                                        <tr>
                                            <td style="height: 18px" valign="middle" align="center" colspan="4">
                                                <asp:Button runat="server" OnClientClick="return callvalidate();" Text="Proceed"
                                                    CssClass="butSubmit" ID="btnProceed" OnClick="btnProceed_Click"></asp:Button>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input runat="server" id="hidUniID" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidInstID" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidFacID" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidFacText" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidCrID" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidCrText" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidMoLrnID" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidMoLrnText" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidPtrnID" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidPtrnText" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidBrnID" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidCrPrDetailsID" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidCrPrChID" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hidBrnText" type="hidden" style="width: 32px; height: 22px" />
                            <input runat="server" id="hid_fk_AcademicYr_ID" type="hidden" />
                            <input runat="server" id="hid_strAcademicYr1" type="hidden" />
                            <input runat="server" id="hid_strAcademicYr2" type="hidden" />
                            <input runat="server" id="hid_AcademicYear" type="hidden" />
                            <input runat="server" id="hid_AcademicYearFrom" type="hidden" />
                            <input runat="server" id="hid_AcademicYearTo" type="hidden" />
                            <input runat="server" id="hidCourseDetails" type="hidden" style="width: 32px; height: 22px" />
                            <asp:Label runat="server" Text="Faculty" ID="lblFac" Style="display: none" meta:resourceKey="lblFacResource1"></asp:Label>
                            <asp:Label runat="server" Text="Course" ID="lblCr" Style="display: none" meta:resourceKey="lblCrResource1"></asp:Label>
                            <asp:Label runat="server" Text="College" ID="lblCollege" Style="display: none" meta:resourceKey="lblCollegeResource1"></asp:Label>
                            <asp:Label runat="server" Text="University" ID="lblUniversity" Style="display: none"
                                meta:resourceKey="lblUniversityResource1"></asp:Label>
                            <asp:Label runat="server" Text="Permanent Registration Number" ID="lblPRNNomenclature"
                                Style="display: none" meta:resourceKey="lblPRNNomenclatureResource1"></asp:Label>
                            <asp:Label runat="server" Text="Course" ID="lblPrvCourseNomenclature" Style="display: none"
                                meta:resourceKey="lblPrvCourseNomenclatureResource1"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlFacDesc" />
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrDesc" />
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrBrnDesc" />
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrPrDetailsDesc" />
            <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCrPrChDesc" />
            <asp:PostBackTrigger ControlID="btnProceed"></asp:PostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
