<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="ELGV2_StudyCenterChange.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_StudyCenterChange" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        function fnValidate(ctrlToValidate) {
            document.getElementById("<%=txtPRN.ClientID%>").value = document.getElementById("<%=txtPRN.ClientID%>").value.trim();
            var myArr = new Array();
            myArr[myArr.length] = new Array(document.getElementById("<%=txtPRN.ClientID%>"), "NumericOnly", "Enter valid <%=lblPRN.Text%>.", "text");

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
                InstDDL.options[0].selected = true;
                var myArr = new Array();
                document.getElementById("<%=txtCenterCode.ClientID%>").value = "";
                var j = -1;
                myArr[++j] = new Array(document.getElementById("<%= txtCenterCode.ClientID%>"), "Empty", "Please Enter a Valid " + document.getElementById("<%= lblCollege.ClientID%>").innerText + " Code", "text");
                var ret = validateMe(myArr, 50);
                return false;
            }
        }

        function NumericOnly() {
            var key = window.event.keyCode;

            if (key < 48 || key > 57)
                window.event.returnValue = false;
        }
    </script>
    <div align="left" id="PageTitleHolder">
        <asp:Label ID="lblPageHead" runat="server" Text="Student Transfer" />
        <%--<asp:Label ID="lblSubHeader" runat="server" Text="for Student" />--%>
    </div>
    <div id="divSearchPRN" width="700px" runat="server" style="display: none">
        <div align="right">
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="errorNote" />
        </div>
        <fieldset>
            <legend valign="top" align="left"><strong>Search PRN</strong></legend>
            <table width="700px">
                <tr>
                    <td>
                        <div align="right" class="clLeft" style="height: 25px; padding-top: 12px; width: 180px;">
                            <asp:Label ID="lblPRN" runat="server" Text="DU PRN"></asp:Label><b> : </b>
                        </div>
                        <div align="left" class="clLeft">
                            <asp:TextBox ID="txtPRN" runat="server" Width="230px" CssClass="redbox" MaxLength="16"
                                TabIndex="1"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <div align="center" style="width: 650px; clear: both; padding-top: 8px" class="clButtonHolder">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" TabIndex="13" OnClientClick="return fnValidate(this);"
                                OnClick="btnSearch_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div id="divDisplayPRN" width="700px" runat="server" style="display: none">
        <table width="700px">
            <tr>
                <td align="right">
                    PRN :
                </td>
                <td align="left">
                    <asp:Label ID="lblStudentPRN" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Student Name :
                </td>
                <td align="left">
                    <asp:Label ID="lblStudName" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divDisplayData" width="700px" runat="server" style="display: none">
        <asp:GridView runat="server" AutoGenerateColumns="False" ID="GV_SrchStud" Width="100%"
            OnRowDataBound="GV_SrchStud_RowDataBound" AllowSorting="True" OnRowCommand="GV_SrchStud_RowCommand"
            DataKeyNames="Student_Name" CssClass="clGrid" EnableModelValidation="True">
            <PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" />
            <Columns>
                <asp:TemplateField HeaderText="SNo.">
                    <ItemStyle HorizontalAlign="Center" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                    <HeaderStyle Font-Bold="True" Width="5%" CssClass="gridHeader"></HeaderStyle>
                    <ItemTemplate>
                        <center>
                            <%# Container.DisplayIndex + 1 %>
                        </center>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="course_name" HeaderText="Course Name">
                    <HeaderStyle Width="40%" CssClass="gridHeader"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Crpr_Abbr" HeaderText="Part">
                    <HeaderStyle Width="10%" CssClass="gridHeader"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="CrPrCh_Abbr" HeaderText="Part Term">
                    <HeaderStyle Width="10%" CssClass="gridHeader"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Academic Year" HeaderText="Academic Year">
                    <HeaderStyle Width="10%" CssClass="gridHeader"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Inst_Code" HeaderText="College Code">
                    <HeaderStyle Width="10%" CssClass="gridHeader"></HeaderStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Transfer College">
                    <HeaderStyle Width="6%" CssClass="gridHeader" />
                    <ItemStyle HorizontalAlign="Center" ForeColor="Navy" CssClass="gridItem" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSelect" Text="Transfer" ForeColor="Blue" runat="server" CommandName="Select"
                            CommandArgument='<%# Container.DisplayIndex %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Inst_Name">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="Student_Name">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="PRN_Number">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="pk_Uni_ID">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="pk_Fac_ID">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="pk_Cr_ID">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="pk_MoLrn_ID">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="pk_Ptrn_ID">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="pk_Brn_ID">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="pk_CrPr_Details_ID">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="pk_CrPrCh_ID">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="CrPr_Seq">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="CrPrCh_Seq">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="AY_Sequence">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="pk_AcademicYear_ID">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
                <asp:BoundField DataField="pk_inst_id">
                    <ItemStyle CssClass="off" />
                    <HeaderStyle CssClass="off" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
    </div>
    <table id="tblInstFill" runat="server" style="display:none;" >
        <tr>
            <td colspan="2">
                <div id="dvSelectSC" runat="server" style="width: 700px; clear: both;">
                    <div style="width: 180px; padding: 5px;" class="clLeft" align="right">
                        <asp:Label ID="lblselectStudyCenter" runat="server" Text="Select Institute" /><b> :
                        </b>
                    </div>
                    <div align="left" style="padding: 3px" class="clLeft">
                        <asp:TextBox ID="txtCenterCode" runat="server" Width="80px" onchange="SetInstitute();" />&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlStudyCenter" Width="324px" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlStudyCenter_SelectedIndexChanged">
                            <asp:ListItem Value="0">---- Select ----</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<font class="Mandatory">*</font>
                    </div>
                    <cc1:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtCenterCode"
                        WatermarkText=" Enter Code" WatermarkCssClass="WaterMark" Enabled="True" />
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 15px;" colspan="3">
            </td>
        </tr>
        <tr>
            <td colspan="10" align="center">
                <asp:Button ID="btnProceed" Text="Proceed" CssClass="butSubmit" runat="server" OnClientClick="return SetInstitute();"
                    Width="100px" onclick="btnProceed_Click" />
                <br />
            </td>
        </tr>
    </table>
    <div id="divUpdateData" width="700px" align="center" runat="server" style="display: none">
        <fieldset>
            <legend valign="top" align="left"><strong>Update College</strong></legend>
            <table>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Label ID="lblMSG" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        PRN :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblPRNupdate" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Student Name :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblStudNameupdate" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Course :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblCourseupdate" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Old College Name :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblOldCollege" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        New College Code :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblNewCollCode" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        New College Name :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblNewCollName" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="width: 650px; clear: both; padding-top: 8px"
                        class="clButtonHolder">
                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                        &nbsp;
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClientClick="return confirm('Are you sure you want to Update this New College with old college?');"
                            OnClick="btnUpdate_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div>
        <input id="hidAcademicYear_ID" runat="server" type="hidden" />
        <input id="hidAY_Sequence" runat="server" type="hidden" />
        <input id="hidOldPk_Institute_ID" runat="server" type="hidden" />
        <input id="hidNewRef_Pk_Institute_ID" runat="server" type="hidden" />
        <input id="hidInstName" runat="server" type="hidden" />
        <input id="hidInstCode" runat="server" type="hidden" />
        <input id="hidPRN" runat="server" type="hidden" />
        <input id="hidUniID" type="hidden" runat="server" />
        <input id="hidInstID" type="hidden" runat="server" />
        <input id="hidFacultyID" type="hidden" runat="server" />
        <input id="hidCourseID" type="hidden" runat="server" />
        <input id="hidMolrnID" type="hidden" runat="server" />
        <input id="hidPtrnID" type="hidden" runat="server" />
        <input id="hidBrnID" type="hidden" runat="server" />
        <input id="hidCrPrDetailsID" type="hidden" runat="server" />
        <input id="hidCrPrChID" type="hidden" runat="server" />
        <input id="hidCrPr_Seq" type="hidden" runat="server" />
        <input id="hidCrPrCh_Seq" type="hidden" runat="server" />
        <input id="hid_Newpk_AcademicYear_ID" type="hidden" runat="server" />
        <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none"></asp:Label>
    </div>
</asp:Content>
