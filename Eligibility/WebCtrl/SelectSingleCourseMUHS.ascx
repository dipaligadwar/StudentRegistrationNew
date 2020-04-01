<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectSingleCourseMUHS.ascx.cs" Inherits="StudentRegistration.Eligibility.WebCtrlMUHS.SelectSingleCourseMUHS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">

    function ShowHide() {

        var displayRC = document.getElementById("<%=divRegionalCenter.ClientID%>").style.display;
        if (displayRC == "none") {
            if (document.getElementById("<%=ChkAllStudyCenter.ClientID%>").checked == true && document.getElementById("<%=ChkSelectedStudyCenter.ClientID%>").checked == false) {
                document.getElementById("<%=dvSelectSC.ClientID%>").style.display = "none";
                document.getElementById("<%=dvSelectSC.ClientID%>").style.cssText = "clear:both;";
            }
            else {
                document.getElementById("<%=dvSelectSC.ClientID%>").style.display = "inline";
                document.getElementById("<%=dvSelectSC.ClientID%>").style.cssText = "clear:both;";
            }
        }
        else {
            if (document.getElementById("<%=ChkAllRegionalCenter.ClientID%>").checked == true && document.getElementById("<%=ChkSelectedRegionalCenter.ClientID%>").checked == false) {

                document.getElementById("<%=dvSelectRC.ClientID%>").style.display = "none";
                document.getElementById("<%=dvSelectRC.ClientID%>").style.cssText = "clear:both;";
                document.getElementById("<%=divStudyCenter.ClientID%>").style.display = "none";
                document.getElementById("<%=dvSelectSC.ClientID%>").style.display = "none";
                document.getElementById("<%=dvSelectSC.ClientID%>").style.cssText = "clear:both;";
                document.getElementById("<%=ChkAllStudyCenter.ClientID%>").checked = true;
                document.getElementById("<%=ChkSelectedStudyCenter.ClientID%>").checked = false;
            }
            else {

                document.getElementById("<%=dvSelectRC.ClientID%>").style.display = "inline";
                document.getElementById("<%=dvSelectRC.ClientID%>").style.cssText = "clear:both;";
                document.getElementById("<%=divStudyCenter.ClientID%>").style.display = "inline";

                if (document.getElementById("<%=ChkAllStudyCenter.ClientID%>").checked == true && document.getElementById("<%=ChkSelectedStudyCenter.ClientID%>").checked == false) {
                    document.getElementById("<%=dvSelectSC.ClientID%>").style.display = "none";
                    document.getElementById("<%=dvSelectSC.ClientID%>").style.cssText = "clear:both;";
                }
                else {
                    document.getElementById("<%=dvSelectSC.ClientID%>").style.display = "inline";
                    document.getElementById("<%=dvSelectSC.ClientID%>").style.cssText = "clear:both;";
                }
            }
        }
    }


    function fnValidate(ctrlToValidate) {

        var myArr = new Array();

        myArr[myArr.length] = new Array(document.getElementById("<%=ddlAcadYear.ClientID%>"), "0", "Select Academic Year.", "select");

        if (document.getElementById("<%=divRegionalCenter.ClientID%>")) {
            if (document.getElementById("<%=ChkAllRegionalCenter.ClientID%>").checked == false && document.getElementById("<%=ChkSelectedRegionalCenter.ClientID%>").checked == true) {
                myArr[myArr.length] = new Array(document.getElementById("<%=ddlRegionalCenter.ClientID%>"), "0", "Select Regional Center.", "select");
            }
        }

        if (document.getElementById("<%=divStudyCenter.ClientID%>")) {
            if (document.getElementById("<%=ChkAllStudyCenter.ClientID%>").checked == false && document.getElementById("<%=ChkSelectedStudyCenter.ClientID%>").checked == true) {
                myArr[myArr.length] = new Array(document.getElementById("<%=ddlStudyCenter.ClientID%>"), "0", "Select " + document.getElementById("<%=lblStudyCenter.ClientID%>").innerText + ".", "select");
            }
        }

        if (document.getElementById("<%=divFaculty.ClientID%>")) {
            myArr[myArr.length] = new Array(document.getElementById("<%=ddlFaculty.ClientID%>"), "-1", "Select " + document.getElementById("<%=lblFac.ClientID%>").innerText + ".", "select");

        }

        if (document.getElementById("<%=divCourse.ClientID%>")) {

            myArr[myArr.length] = new Array(document.getElementById("<%=ddlCourse.ClientID%>"), "-1", "Select " + document.getElementById("<%=lblCourse.ClientID%>").innerText + ".", "select");



        }

        if (document.getElementById("<%=divBranch.ClientID%>")) {
            var ind = document.getElementById("<%=ddlBranch.ClientID%>").selectedIndex;
            if (document.getElementById("<%=ddlBranch.ClientID%>")[ind].innerHTML != "No Branch Available") {

                myArr[myArr.length] = new Array(document.getElementById("<%=ddlBranch.ClientID%>"), "-1", "Select Branch", "select");

            }
        }

        if (document.getElementById("<%=divPart.ClientID%>")) {

            myArr[myArr.length] = new Array(document.getElementById("<%=ddlPart.ClientID%>"), "-1", "Select " + document.getElementById("<%=lblPart.ClientID%>").innerText + ".", "select");


        }

        if (document.getElementById("<%=divTerm.ClientID%>")) {
            myArr[myArr.length] = new Array(document.getElementById("<%=ddlTerm.ClientID%>"), "-1", "Select " + document.getElementById("<%=lblTerm.ClientID%>").innerText + ".", "select");

        }

        if (document.getElementById("<%=divReportDisp.ClientID%>") && document.getElementById("<%=divReportDisp.ClientID%>").value == "True") {
            if (document.getElementById("<%=rdbtnUser.ClientID%>").checked == true && document.getElementById("<%=rdbtnDate.ClientID%>").checked == false) {
                myArr[myArr.length] = new Array(document.getElementById("<%=ddlUser.ClientID%>"), "-1", "Select Data Entry User.", "select");
            }
            else if (document.getElementById("<%=rdbtnUser.ClientID%>").checked == false && document.getElementById("<%=rdbtnDate.ClientID%>").checked == true) {

                myArr[myArr.length] = new Array(document.getElementById("<%=txtFrom.ClientID%>"), "dd/mm/yyyy", "Enter valid From date.", "date/Empty");
                myArr[myArr.length] = new Array(document.getElementById("<%=txtTo.ClientID%>"), "dd/mm/yyyy", "Enter valid To date.", "date/Empty");
                if (document.getElementById("<%=txtFrom.ClientID%>").value != "" && document.getElementById("<%=txtTo.ClientID%>").value != "") {
                    myArr[myArr.length] = new Array(document.getElementById("<%=txtFrom.ClientID%>").value + "|" + document.getElementById("<%=hid_AcademicYearTo.ClientID%>").value, "", "Enter From Date Within Selected Academic Year.", "CompareDates");
                    myArr[myArr.length] = new Array(document.getElementById("<%=hid_AcademicYearFrom.ClientID%>").value + "|" + document.getElementById("<%=txtFrom.ClientID%>").value, "", "Enter From Date Within Selected Academic Year.", "CompareDates")

                    myArr[myArr.length] = new Array(document.getElementById("<%=txtTo.ClientID%>").value + "|" + document.getElementById("<%=hid_AcademicYearTo.ClientID%>").value, "", "Enter To Date Within Selected Academic Year.", "CompareDates");
                    myArr[myArr.length] = new Array(document.getElementById("<%=hid_AcademicYearFrom.ClientID%>").value + "|" + document.getElementById("<%=txtTo.ClientID%>").value, "", "Enter To Date Within Selected Academic Year.", "CompareDates");

                    myArr[myArr.length] = new Array(document.getElementById("<%=txtFrom.ClientID%>").value + "|" + document.getElementById("<%=txtTo.ClientID%>").value, "", "Enter valid Date range.", "CompareDates");
                }
            }
        }
        var ret = validateMe(myArr, 50, ctrlToValidate);
        return ret;
    }

    function SetInstitute() {
        var InstDDL = document.getElementById("<%=ddlStudyCenter.ClientID%>")
        var compareText = document.getElementById("<%=txtCenterCode.ClientID%>").value
        var noInst = true;

        for (var i = 0; i < InstDDL.options.length; i++) {
            if (InstDDL.options[i].value != "0") {
                var ddText = InstDDL.options[i].text;
                var StartIndex = ddText.indexOf('[') + 1;
                var EndIndex = ddText.indexOf(']');
                ddText = ddText.substring(StartIndex, EndIndex)
                if (compareText.toUpperCase() == ddText.toUpperCase()) {
                    InstDDL.options[i].selected = true;
                    InstDDL.focus();
                    noInst = false;
                    __doPostBack("<%=ddlStudyCenter.ClientID%>", 0);
                    break;
                }
            }
        }

        if (noInst) {
            var control = document.getElementById("<%=txtCenterCode.ClientID%>")
            InstDDL.options[0].selected = true;
            showValidationSummary(control, "Institute not found.");
            return false;
        }
    }    
</script>
<style type="text/css">
.WaterMark
{
   background-color:#efefef;
}
</style>

<div id="ControlHolder">
    <div align="right">
        <asp:Label ID="lblNote" runat="server" meta:resourcekey="lblNoteResource1"></asp:Label>
    </div>
    <div align="left">
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorNote" meta:resourcekey="lblErrorMessageResource1"></asp:Label>
    </div>
    <div>
        <asp:UpdatePanel ID="oUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
            <ContentTemplate>                
                <div id="divAcadYear" style="width: 700px;clear:both;" runat="server">
                    <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                        Academic Year<b> : </b></div>
                    <div align="left" style="padding: 3px" class="clLeft">
                        <asp:DropDownList ID="ddlAcadYear" Width="420px" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlAcadYear_SelectedIndexChanged" meta:resourcekey="ddlAcadYearResource1">
                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">---- Select ----</asp:ListItem>
                        </asp:DropDownList>&nbsp;<font class="Mandatory">*</font></div>
                        
                        <input type="hidden" runat="server" id="hid_AcademicYearTo" />
                        </input>
                    <input id="hid_AcademicYearFrom" runat="server" type="hidden"></input>
                    </input>
                </div>                 
                <div id="divRegionalCenter" runat="server">
                    <div style="width: 700px;clear:both;">
                        <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                            Regional Center<b> : </b>
                        </div>
                        <div align="left" style="padding: 3px;width:420px" class="clLeft">
                            <asp:RadioButton ID="ChkAllRegionalCenter" runat="server" Width="205px" AutoPostBack="True" onclick="ShowHide();"
                                OnCheckedChanged="ChkAllRegionalCenter_CheckedChanged" Text="All Regional Center"
                                GroupName="grpRegionalCenter" Checked="True" meta:resourcekey="ChkAllRegionalCenterResource1">
                            </asp:RadioButton>
                            <asp:RadioButton ID="ChkSelectedRegionalCenter" runat="server" Width="205px" onclick="ShowHide();"
                                Text="Selected Regional Center" GroupName="grpRegionalCenter" meta:resourcekey="ChkSelectedRegionalCenterResource1">
                            </asp:RadioButton>
                        </div>
                    </div>
                    <div id="dvSelectRC" runat="server" style="width: 700px;clear:both;">
                        <div style="width: 180px; padding: 5px;clear:both;" class="clLeft" align="right">
                            Select Regional Center<b> : </b>
                        </div>
                        <div align="left" style="padding: 3px" class="clLeft">
                            <asp:DropDownList ID="ddlRegionalCenter" Width="420px" runat="server" AutoPostBack="True"
                                 OnSelectedIndexChanged="ddlRegionalCenter_SelectedIndexChanged" meta:resourcekey="ddlRegionalCenterResource1">
                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource2">---- Select ----</asp:ListItem>
                            </asp:DropDownList>&nbsp;<font class="Mandatory">*</font>
                        </div>
                    </div>
                </div>
                <div id="divRCLabel" runat="server" style="display:none;">
                     <div style="width: 700px;clear:both;">
                        <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                            <asp:Label ID="lblRC" runat="server" Text="Regional Center" 
                                meta:resourcekey="lblRCResource1"  /><b> : </b>
                        </div>
                        <div align="left" style="padding: 3px;width:420px" class="clLeft">
                            <asp:Label ID="lblRegionalCenterName" runat="server" Width="530px" meta:resourcekey="lblRegionalCenterNameResource1"></asp:Label>
                        </div>
                    </div>
                </div>
                <div id="divStudyCenter" runat="server">
                    <div style="width: 700px;clear:both;">
                        <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                            <asp:Label ID="lblStudyCenter" runat="server" Text="Institute" meta:resourcekey="lblStudyCenterResource1" /><b> : </b>
                        </div>
                        <div align="left" style="padding: 3px;width:420px" class="clLeft">
                            <asp:RadioButton ID="ChkAllStudyCenter" runat="server" Width="205px" AutoPostBack="True" onclick="ShowHide();"
                                OnCheckedChanged="ChkAllStudyCenter_CheckedChanged" Text="All Institutes" GroupName="grpStudyCenter"
                                Checked="false" meta:resourcekey="ChkAllStudyCenterResource1"></asp:RadioButton>
                            <asp:RadioButton ID="ChkSelectedStudyCenter" runat="server" Width="205px" AutoPostBack="True" onclick="ShowHide();"
                                OnCheckedChanged="ChkSelectedStudyCenter_CheckedChanged" Text="Selected Institute"  
                                GroupName="grpStudyCenter" meta:resourcekey="ChkSelectedStudyCenterResource1"></asp:RadioButton>
                        </div>
                    </div>
                    <div id="dvSelectSC" runat="server" style="width:700px;clear:both;">
                        <div style="width: 180px; padding: 5px;clear:both;" class="clLeft" align="right">
                            <asp:Label ID="lblselectStudyCenter" runat="server" Text="Select Institute" meta:resourcekey="lblselectStudyCenterResource1" /><b> : </b>
                        </div>
                        <div align="left" style="padding: 3px" class="clLeft">
                            <asp:TextBox ID="txtCenterCode" runat="server" Width="80px" 
                                onchange="SetInstitute();" meta:resourcekey="txtCenterCodeResource1" />&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlStudyCenter" Width="324px" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlStudyCenter_SelectedIndexChanged" meta:resourcekey="ddlStudyCenterResource1">
                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource3">---- Select ----</asp:ListItem>
                            </asp:DropDownList>&nbsp;<font class="Mandatory">*</font>
                        </div>
                        <cc1:TextBoxWatermarkExtender ID="TBWE2" runat="server" 
                            TargetControlID="txtCenterCode" WatermarkText=" Enter Code" 
                            WatermarkCssClass="WaterMark" Enabled="True" />
                    </div>
                </div>
                <div id="divFaculty" runat="server" style="width:700px;clear:both;">
                    <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                        <asp:Label ID="lblFac" runat="server" Text="Faculty" meta:resourcekey="lblFacResource1" /><b> : </b></div>
                    <div align="left" style="padding: 3px" class="clLeft">
                        <asp:DropDownList ID="ddlFaculty" Width="420px" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" meta:resourcekey="ddlFacultyResource1">                            
                        </asp:DropDownList>&nbsp;<font class="Mandatory">*</font></div>
                </div>
                <div id="divCourse" runat="server" style="width: 700px;clear:both;">
                    <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                        <asp:Label ID="lblCourse" runat="server" Text="Course Name" meta:resourcekey="lblCourseResource1" /><b> : </b></div>
                    <div align="left" style="padding: 3px" class="clLeft">
                        <asp:DropDownList ID="ddlCourse" Width="420px" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" meta:resourcekey="ddlCourseResource1">
                            <asp:ListItem Value="-1" meta:resourcekey="ListItemResource5">---- Select ----</asp:ListItem>
                        </asp:DropDownList>&nbsp;<font class="Mandatory">*</font></div>
                </div>
                <div id="divBranch" runat="server" style="width: 700px;clear:both;">
                    <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                        Branch (if applicable)<b> : </b></div>
                    <div align="left" style="padding: 3px" class="clLeft">
                        <asp:DropDownList ID="ddlBranch" Width="420px" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" meta:resourcekey="ddlBranchResource1">
                            <asp:ListItem Value="-1" meta:resourcekey="ListItemResource6">---- Select ----</asp:ListItem>
                        </asp:DropDownList>&nbsp;<font class="Mandatory">*</font></div>
                </div>
                <div id="divPart" style="width: 700px;clear:both;" runat="server">
                    <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                        <asp:Label ID="lblPart" runat="server" Text="Course Part Details" meta:resourcekey="lblPartResource1" /><b> : </b></div>
                    <div align="left" style="padding: 3px" class="clLeft">
                        <asp:DropDownList ID="ddlPart" Width="420px" runat="server" 
                        AutoPostBack="True" OnSelectedIndexChanged="ddlPart_SelectedIndexChanged" meta:resourcekey="ddlPartResource1">
                            <asp:ListItem Value="-1" meta:resourcekey="ListItemResource7">---- Select ----</asp:ListItem>
                        </asp:DropDownList>&nbsp;<font class="Mandatory">*</font></div>
                </div>
                <div id="divTerm" style="width: 700px;clear:both;" runat="server">
                    <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                        <asp:Label ID="lblTerm" runat="server" Text="Course Part Term" meta:resourcekey="lblTermResource1" /><b> : </b></div>
                    <div align="left" style="padding: 3px" class="clLeft">
                        <asp:DropDownList ID="ddlTerm" Width="420px" runat="server" AutoPostBack="True" meta:resourcekey="ddlTermResource1">
                            <asp:ListItem Value="-1" meta:resourcekey="ListItemResource8">---- Select ----</asp:ListItem>
                        </asp:DropDownList>&nbsp;<font class="Mandatory">*</font></div>
                </div>
                <div id="divReportDisp" runat="server">
                    <div style="width: 700px;clear:both;">
                        <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                            Display Report By<b> : </b>
                        </div>
                        <div align="left" style="padding: 3px;width:420px" class="clLeft">
                            <asp:RadioButton ID="rdbtnUser" runat="server" Width="205px" 
                                AutoPostBack="True" OnCheckedChanged="rdbtnUser_CheckedChanged" 
                                Text="Data Entry User" GroupName="grpReportDisp" Checked="True" 
                                meta:resourcekey="rdbtnUserResource1"></asp:RadioButton>
                            <asp:RadioButton ID="rdbtnDate" runat="server" Width="205px" 
                                AutoPostBack="True" OnCheckedChanged="rdbtnDate_CheckedChanged" 
                                Text="Date Range" GroupName="grpReportDisp" 
                                meta:resourcekey="rdbtnDateResource1"></asp:RadioButton>
                        </div>
                    </div>
                    <div id="DivUser" runat="server" style="width: 700px;clear:both;">
                        <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                            Select User<b> : </b>
                        </div>
                        <div align="left" style="padding: 3px" class="clLeft">
                            <asp:DropDownList ID="ddlUser" Width="420px" runat="server" 
                                meta:resourcekey="ddlUserResource1">
                                <asp:ListItem Value="-1" meta:resourcekey="ListItemResource4">---- Select ----</asp:ListItem>
                            </asp:DropDownList>&nbsp;<font class="Mandatory">*</font>
                        </div>
                    </div>
                    <div id="DivDate" runat="server" style="width: 700px;clear:both;">
                        <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                            Date Range<b> : </b>
                        </div>
                        <div align="left" style="padding: 3px;width:420px" class="clLeft">
                            <div class="clLeft" style="height: 25px; width: 35px; vertical-align: middle;text-align:right;padding:5px">
                                <asp:Label ID="lblFrom" runat="server" Text="From" 
                                    meta:resourcekey="lblFromResource1" />
                            </div>
                            <div class="clLeft">
                                <asp:TextBox ID="txtFrom" runat="server" MaxLength="10" AutoCompleteType="Disabled"
                                    Width="80px" meta:resourcekey="txtFromResource1" />
                                <font class="Mandatory">*</font>
                            </div>
                            <div class="clLeft" style="height: 25px; width: 60px; vertical-align: middle;text-align:right;padding:5px">
                                <asp:Label ID="lblTo" runat="server" Text="To" 
                                    meta:resourcekey="lblToResource1" />
                            </div>
                            <div class="clLeft">
                                <asp:TextBox ID="txtTo" runat="server" MaxLength="10" AutoCompleteType="Disabled"
                                    Width="80px" meta:resourcekey="txtToResource1" />
                                <font class="Mandatory">*</font>&nbsp;&nbsp;[dd/mm/yyyy]
                            </div>
                        </div>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureName="en-GB"
                            CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="£" CultureDateFormat="DMY"
                            CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder=","
                            CultureTimePlaceholder=":" Enabled="True" />
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                            Format="dd/MM/yyyy" Enabled="True" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureName="en-GB"
                            CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="£" CultureDateFormat="DMY"
                            CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder=","
                            CultureTimePlaceholder=":" Enabled="True" />
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                            Format="dd/MM/yyyy" Enabled="True" />
                    </div>
                </div>                   
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlRegionalCenter" />               
                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlStudyCenter" />
                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlFaculty" />
                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlCourse" />
                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlBranch" />
                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlPart" />
                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlAcadYear" />                
                <asp:AsyncPostBackTrigger EventName="CheckedChanged" ControlID="ChkAllRegionalCenter" />
                <asp:AsyncPostBackTrigger EventName="CheckedChanged" ControlID="ChkAllStudyCenter" />
                <asp:AsyncPostBackTrigger EventName="CheckedChanged" ControlID="ChkSelectedStudyCenter" /> 
                <asp:AsyncPostBackTrigger EventName="CheckedChanged" ControlID="rdbtnUser" />
                <asp:AsyncPostBackTrigger EventName="CheckedChanged" ControlID="rdbtnDate" /> 
                             
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <br />
    <div align="center" class="clButtonHolder" style="clear: both; padding-top: 5px;">
        <asp:Button ID="btnProceed" runat="server" Text="Proceed" OnClientClick="return fnValidate(this);"
            OnClick="btnProceed_Click" meta:resourcekey="btnProceedResource1" />
    </div>
    <br />
    <div align="left" style="height: 25px; width: 600px">
        <strong>Note:</strong><font class="Mandatory">*</font> marked fields are mandatory.
    </div> 
    <input type="hidden" id="hid_Institute_ID"  runat="server"/>
    <input type="hidden" id="hidCenterType"  runat="server"/>
</div>
