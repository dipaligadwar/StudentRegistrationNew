<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ELGV2_rpt_GenerateRegistrationReceipt.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_rpt_GenerateRegistrationReceipt" %>
<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%@ register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

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
        var hidLevelFlagClient = '<%=hidLevelFlag.ClientID%>';
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
                var collTB = document.getElementById("<%= Collcode.ClientID%>");
                var collDD = document.getElementById("<%=ddlCollegeName.ClientID%>");
                collTxt = document.getElementById("<%= Collcode.ClientID%>").value.toUpperCase();
                var IndexValue = collDD.selectedIndex;
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
                if (document.getElementById("<%=divCollege.ClientID%>").style.display != 'none') {
                    if (collDD.selectedIndex == 0) {
                        myArr[++i] = new Array(document.getElementById("<%= ddlCollegeName.ClientID%>"), "0", "Please Select an " + document.getElementById('<%=lblCollege.ClientID%>').innerText + " Name.", "select");
                    }

                }

                //validate that one criteria is checked


//                var oChecked = false;
//                if (oChecked) {
//                    document.getElementById("<%=hidTermSelection.ClientID%>").value = "1";
//                }
//                else {
//                    document.getElementById("<%=hidTermSelection.ClientID%>").value = "";
//                }
//                myArr[++i] = new Array(document.getElementById("<%=hidTermSelection.ClientID%>"), "Empty", "Please check atleast one criteria.", "text");

                if (document.getElementById("<%=txtFrom.ClientID%>").value != "" || document.getElementById("<%=txtTo.ClientID%>").value != "") {
                    myArr[++i] = new Array(document.getElementById("<%=txtFrom.ClientID%>"), "Empty", "Please enter From date.", "text");
                    myArr[++i] = new Array(document.getElementById("<%=txtTo.ClientID%>"), "Empty", "Please enter To date.", "text");
                    myArr[++i] = new Array(document.getElementById("<%=txtFrom.ClientID%>").value + "|" + document.getElementById("<%=txtTo.ClientID%>").value, "", "  From  Date should be Greater than To Date.", "CompareDates");
                }

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


        //filling college code corr to selection in coll dropdown
        function fillCollegeCode(code) {
            var arr = new Array();
            arr = code.split('|');

            if (document.getElementById("<%=ddlCollegeName.ClientID%>").selectedIndex == 0)
                document.getElementById("<%=Collcode.ClientID%>").value = "";
            else
                document.getElementById("<%=Collcode.ClientID%>").value = arr[1];
            if (arr[1] == "") {
                document.getElementById("<%=Collcode.ClientID%>").value = "-";
            }

        }

        //select coll drop on tab press in coll code textbox
        function allowTab(sender, e) {
            if (e.keyCode == 9) {
                var typedCode = sender.value.toUpperCase();
                var collDD = document.getElementById("<%=ddlCollegeName.ClientID%>");
                setSelectedIndex(collDD, typedCode);
                return false;
            }
            else {


                return true;
            }
        }

        //select corr value in college dropdown
        function setSelectedIndex(dropdown, valueToSelect) {
            var codeFlag = false;
            var myArr = new Array();
            var count = 0;
            var addToDDText = new Array();
            var addToDDValue = new Array();
            for (var i = 0; i < dropdown.options.length; i++) {
                if (dropdown.options[i].value.split('|')[1] == valueToSelect) {
                    codeFlag = true;
                    addToDDText.push(dropdown.options[i].text);
                    addToDDValue.push(dropdown.options[i].value);
                    count++;
                }
            }
            if (codeFlag) {
                if (count == 1) {
                    for (var i = 0; i < dropdown.options.length; i++) {
                        if (dropdown.options[i].value.split('|')[1] == valueToSelect) {
                            dropdown.options[i].selected = true;
                            dropdown.focus();
                            return;
                        }
                    }
                }

                //if multiple coll corr to a code
                if (count > 1) {
                    //adding select as an option in dd
                    dropdown.options.length = 0;
                    var opt = document.createElement("option");
                    opt.text = "--Select--";
                    opt.value = "0";
                    dropdown.options.add(opt);

                    //adding the multiple colleges as items
                    for (var k = 0; k < count; k++) {
                        var opt = document.createElement("option");
                        opt.text = addToDDText[k];
                        opt.value = addToDDValue[k];
                        opt.title = opt.text;
                        dropdown.options.add(opt);
                    }

                    dropdown.focus();
                }
            }
            else {
                if (alert1) {
                    document.getElementById("<%=Collcode.ClientID%>").value = "";
                    var j = -1;
                    myArr[++j] = new Array(document.getElementById("<%= Collcode.ClientID%>"), "Empty", "Please Enter a Valid " + document.getElementById('<%=lblCollege.ClientID%>').innerText + " Code", "text");
                    document.getElementById("<%=ddlCollegeName.ClientID%>").selectedIndex = 0;
                    var ret = validateMe(myArr, 50);
                }


            }
        }

        function resetDropDown() {
            var collDropDown = document.getElementById("<%=ddlCollegeName.ClientID %>");
            var typedCode = document.getElementById("<%=Collcode.ClientID %>").value.toUpperCase();
            collDropDown.selectedIndex = "0";
            collDropDown.options.length = 0;
            var dt = clsAjaxMethods.FillCollegeList();
            var opt = document.createElement("option");
            opt.text = "--- Select---";
            opt.value = "0";
            collDropDown.options.add(opt);
            for (var l = 0; l < dt.value.Rows.length; l++) {
                var opt = document.createElement("option");
                opt.text = dt.value.Rows[l].Inst_Name + "," + dt.value.Rows[l].Inst_City;
                opt.value = dt.value.Rows[l].pk_Inst_ID + "|" + dt.value.Rows[l].Inst_Code;
                opt.title = opt.text;
                collDropDown.options.add(opt);
            }
            setSelectedIndex(collDropDown, typedCode);
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
                            <div runat="server" id="divAllCriterion">
                                <div runat="server" id="div1" style="margin-left: 30px; width: 90%; azimuth: center">
                                    &nbsp;&nbsp;
                                    <div runat="server" id="Div2" align="center">
                                        <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="height: 20px" colspan="3">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 225px; height: 20px" align="right">
                                                        <asp:Label runat="server" Text="Select Academic Year" Font-Bold="True" Width="221px"
                                                            ID="Label3" meta:resourceKey="lblAcyrResource1"></asp:Label>
                                                    </td>
                                                    <td style="width: 1%; height: 20px" align="center">
                                                        <b>&nbsp;:&nbsp;</b></td>
                                                    <td runat="server" id="td1" style="width: 387px; height: 20px" align="left">
                                                        <asp:DropDownList runat="server" CssClass="selectbox" Width="298px" ID="ddlAcademicYr"
                                                            meta:resourceKey="ddlAcademicYrResource1">
                                                            <asp:ListItem Text="--- Select ---" Value="0" meta:resourceKey="ListItemResource1"></asp:ListItem>
                                                        </asp:DropDownList><font class="Mandatory"> *</font></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div runat="server" id="divCollege" style="margin-left: 30px; width: 90%; azimuth: center">
                                    <table style="azimuth: center" cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td style="width: 230px; height: 38px" align="right">
                                                    <asp:Label runat="server" Text="Select College" Font-Bold="True" ID="Label9" meta:resourcekey="Label9Resource1"></asp:Label>
                                                </td>
                                                <td style="width: 1%; height: 38px" align="center">
                                                    <b>&nbsp;:&nbsp; </b>
                                                </td>
                                                <td style="padding-left: 2px; width: 4%; height: 38px" align="left">
                                                    <asp:TextBox runat="server" MaxLength="300" CssClass="inputbox" Width="40px" ID="Collcode"
                                                        onblur="resetDropDown()" onkeydown="return allowTab(this, event)" meta:resourceKey="CollcodeResource1"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td style="height: 38px" align="left">
                                                    <asp:DropDownList runat="server" CssClass="selectbox" Width="250px" ID="ddlCollegeName"
                                                        onchange="fillCollegeCode(this.value);" meta:resourceKey="ddlCollegeNameResource1">
                                                    </asp:DropDownList><font class="Mandatory">    *</font>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <table runat="server" id="Table2" style="margin-left: 30px; width: 90%; azimuth: center">
                                    <tr runat="server" id="Tr1">
                                        <td runat="server" id="Td2">
                                            <div runat="server" id="Div3" style="azimuth: center">
                                                <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 125px; height: 20px" align="right">
                                                                <b>
                                                                    <asp:Label runat="server" Text="Select Faculty Name" Width="221px" ID="Label4" meta:resourceKey="Label4Resource1"></asp:Label>
                                                                </b>
                                                            </td>
                                                            <td style="width: 1%; height: 20px" align="center">
                                                                <b>&nbsp;:&nbsp;</b></td>
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
                                                                <b>:</b></td>
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
                                                                    <asp:Label runat="server" Text="Select Course Branch" ID="Label6"  meta:resourceKey="Label6Resource2"></asp:Label>
                                                                </strong>
                                                            </td>
                                                            <td align="center">
                                                                <b>:</b></td>
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
                                                                    <asp:Label runat="server" Text="Select Course Part" ID="Label7"  meta:resourceKey="Label7Resource2"></asp:Label>
                                                                </b>
                                                            </td>
                                                            <td style="height: 23px" align="center">
                                                                <b>:</b></td>
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
                                                                    <asp:Label runat="server" Text="Select Course Part Term" ID="Label8"  meta:resourceKey="Label8Resource2"></asp:Label>
                                                                </b>
                                                            </td>
                                                            <td style="width: 1%" align="center">
                                                                <b>:</b></td>
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
                                          
                                            
                                            <table style="azimuth: center" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 230px; height: 38px" align="right">
                                                            <asp:Label runat="server" Text="Eligibility Processed From" Font-Bold="True" ID="Label10" ></asp:Label>
                                                        </td>
                                                        <td style="width: 1%; height: 38px" align="center">
                                                            <b>&nbsp;:&nbsp; </b>
                                                        </td>
                                                        <td style="padding-left: 2px; width: 4%; height: 38px" align="left">
                                                            <asp:TextBox ID="txtFrom" runat="server" Width="75px" MaxLength="10" AutoCompleteType="Disabled"/></font>
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom"
                                                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureName="en-GB"
                                                                CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="£" CultureDateFormat="DMY"
                                                                CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder=","
                                                                CultureTimePlaceholder=":" Enabled="True" />
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFrom"
                                                                Format="dd/MM/yyyy" Enabled="True" />
                                                        </td>
                                                        <td align="right">&nbsp;&nbsp;
                                                            <asp:Label runat="server" Text="Eligibility Processed  To" Font-Bold="True" ID="Label11" ></asp:Label>
                                                            </td>
                                                            <td style="width: 1%; height: 38px" align="center">
                                                            <b>&nbsp;:&nbsp; </b>
                                                        </td>
                                                        <td style="height: 38px" align="left">
                                                            <asp:TextBox ID="txtTo" runat="server" Width="75px" MaxLength="10" AutoCompleteType="Disabled"/></font>
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo"
                                                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureName="en-GB"
                                                                CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="£" CultureDateFormat="DMY"
                                                                CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder=","
                                                                CultureTimePlaceholder=":" Enabled="True" />
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo"
                                                                Format="dd/MM/yyyy" Enabled="True" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                
                                           <%-- <table cellspacing="0" cellpadding="2" width="105%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 220px; padding-top: 15px" align="right">
                                                            <asp:Label runat="server" Text="Sort Students On" Font-Bold="True" ID="Label2"></asp:Label>
                                                        </td>
                                                        <td style="vertical-align: top; width: 1%; padding-top: 15px; height: 20px" align="center">
                                                            <b>&nbsp;:&nbsp;</b></td>
                                                        <td style="vertical-align: top; height: 20px" align="left">
                                                            <asp:RadioButtonList runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                                                                Width="390px" ID="rblSortStudent" meta:resourceKey="rblSortStudentResource1">
                                                                <asp:ListItem Selected="True" Text="Last Name" Value="0" meta:resourceKey="ListItemResource12"></asp:ListItem>
                                                                <asp:ListItem Text="First Name" Value="1" meta:resourceKey="ListItemResource13"></asp:ListItem>
                                                                <asp:ListItem Text="Eligibility Form Number" Value="2" meta:resourceKey="ListItemResource14"></asp:ListItem>
                                                                <asp:ListItem Text="Permanent Registration Number(PRN)" Value="3" meta:resourceKey="ListItemResource15"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>--%>
                                        </td>
                                    </tr>
                                </table>
                                <div runat="server" id="DivGenerate">
                                    <table cellpadding="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td style="height: 18px" valign="middle" align="center" colspan="4">
                                                    <asp:Button runat="server" OnClientClick="return callvalidate();" Text="Generate Report"
                                                        CssClass="butSubmit" ID="btnDisplay" meta:resourceKey="btnDisplayResource1" OnClick="btnGenerate_Click">
                                                    </asp:Button>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <table style="border-collapse: collapse" id="table1" bordercolor="#c0c0c0" cellpadding="2"
                                width="700" border="0">
                                <tbody>
                                    <tr>
                                        <td valign="top" align="center">
                                            <table style="visibility: visible; align: left" id="tblnorecordfound">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 641px; height: 15px; text-align: left">
                                                            <asp:Label runat="server" ID="lblnorecordfound" Style="display: none" ></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <input runat="server" id="hidUniID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidInstID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidInstName" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidInstCode" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidInstAddress" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidInstCity" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidSortOption" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCriteria" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCriteriaNull" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCriteriaEligibilityRequired" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidStateID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidDistrictID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidTalukaID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidLastName" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidFirstName" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidDOB" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidGender" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidFacID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidFacText" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCrID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCrText" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidMoLrnID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidMoLrnText" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidPtrnID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidPtrnText" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidBrnID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCrPrDetailsID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCrPrChID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidBrnText" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidLevelFlag" type="hidden"/>
                            <input runat="server" id="hid_fk_AcademicYr_ID" type="hidden"/>
                            <input runat="server" id="hid_strAcademicYr1" type="hidden"/>
                            <input runat="server" id="hid_strAcademicYr2" type="hidden"/>
                            <input runat="server" id="hid_AcademicYear" type="hidden"/>
                            <input runat="server" id="hid_AcademicYearFrom" type="hidden"/>
                            <input runat="server" id="hid_AcademicYearTo" type="hidden"/>
                            <input runat="server" id="hidCourseDetails" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCollName" type="hidden"/>
                            <asp:Label runat="server" Text="Faculty" ID="lblFac" Style="display: none" meta:resourceKey="lblFacResource1"></asp:Label>
                            <asp:Label runat="server" Text="Course" ID="lblCr" Style="display: none" meta:resourceKey="lblCrResource1"></asp:Label>
                            <asp:Label runat="server" Text="College" ID="lblCollege" Style="display: none" meta:resourceKey="lblCollegeResource1"></asp:Label>
                            <asp:Label runat="server" Text="University" ID="lblUniversity" Style="display: none"
                                meta:resourceKey="lblUniversityResource1"></asp:Label>
                            <asp:Label runat="server" Text="Permanent Registration Number" ID="lblPRNNomenclature" Style="display: none"
                                meta:resourceKey="lblPRNNomenclatureResource1"></asp:Label>
                            <asp:Label runat="server" Text="Course" ID="lblPrvCourseNomenclature" Style="display: none"
                                meta:resourceKey="lblPrvCourseNomenclatureResource1"></asp:Label>
                            <input runat="server" id="hidTermSelection" type="hidden"></input>
                            <input runat="server" id="hidFromDate" type="hidden"></input>
                            <input runat="server" id="hidToDate" type="hidden"></input>
                            </input>
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
            <asp:PostBackTrigger ControlID="btnDisplay" />
        </Triggers>
    </asp:UpdatePanel>
    <table>
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </table>
    <div id="DivReportViewerDesign" runat="server" style="display: none;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="650px" meta:resourcekey="ReportViewer1Resource1">
            <LocalReport ReportEmbeddedResource="StudentRegistration.Eligibility.Rdlc.GenerateRegistrationReceipt.rdlc"
                EnableExternalImages="True">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>