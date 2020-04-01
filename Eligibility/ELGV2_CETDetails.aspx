<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="ELGV2_CETDetails.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_CETDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            //your functions
            //- - - - - - - - - - - -
            if ($("#<%=ddlCETType.ClientID %>").val() == "11") {
                $("#<%=txtCETMarks.ClientID %>").attr("disabled", "disabled");
                $("#<%=txtCETMarks.ClientID %>").val("");
            }
            else
                $("#<%=txtCETMarks.ClientID %>").attr("disabled", "");


            $("#<%=ddlCETType.ClientID %>").change(function () {

                if ($(this).val() == "11") {
                    $("#<%=txtCETMarks.ClientID %>").attr("disabled", "disabled");
                    $("#<%=txtCETMarks.ClientID %>").val("");
                }
                else
                    $("#<%=txtCETMarks.ClientID %>").attr("disabled", "");
            });



        });
        function fnSubmitValidate() {
            var myArray = new Array();
            if ($("#<%=ddlCETType.ClientID %>").val() != "11")
                myArray[myArray.length] = new Array(document.getElementById("<%=txtCETMarks.ClientID%>"), "Empty", "CET Marks should not be empty.", "text");
            myArray[myArray.length] = new Array(document.getElementById("<%=ddlCETType.ClientID%>"), "0", "Please Select CET Type.", "select");
            myArray[myArray.length] = new Array(document.getElementById("<%=ddlQuotaType.ClientID%>"), "0", "Please Select Quota Type.", "select");
            myArray[myArray.length] = new Array(document.getElementById("<%=txtPhysicsParks.ClientID%>"), "NumericOnly/Empty", "Physics Marks should not be empty.", "text");
            myArray[myArray.length] = new Array(document.getElementById("<%=txtChemistryMarks.ClientID%>"), "NumericOnly/Empty", "Chemistry Marks should not be empty.", "text");
            myArray[myArray.length] = new Array(document.getElementById("<%=txtBioMarks.ClientID%>"), "NumericOnly/Empty", "Bio Marks should not be empty.", "text");
            myArray[myArray.length] = new Array(document.getElementById("<%=txtHscBoard.ClientID%>"), "Empty", "Hsc Board should not be empty.", "text");

            var ret = validateMe(myArray, 10);
            return ret;
            // showValidationSummary('', "<li>Enter Valid Allowance Value .");
            // showAlert('Put message here');
        }
    </script>
    <div id="">
        <div align="left" class="masterheading" style="position: relative;">
            <asp:Label ID="lblPageHead" runat="server" Text="CET Details"></asp:Label>
            <%--<asp:Label ID="lblSubHeader" runat="server" Text="Page Sub-Header"></asp:Label>--%>
        </div>
        <br />
        <br />
        <div id="cetDetails" runat="server">
            <fieldset>
                <legend>CET Details</legend>
                <table cellspacing="2" cellpadding="2" width="100%">
                    <tbody>
                        <tr>
                            <td align="right" style="width: 20%">
                                Type of CET
                            </td>
                            <td align="center">
                                <b>&nbsp;:&nbsp;</b>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" CssClass="selectbox" ID="ddlCETType">
                                    <asp:ListItem Text="--- Select ---" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Asso-CET " Value="1"></asp:ListItem>
                                    <asp:ListItem Text="MH- CET" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="AIEE-CET" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="AIPMT" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="MGIMSPMT" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Minority CET" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="GOI" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="AIIPMR-CET" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="AMMMEI" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="AFMC-E" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="Non-CET" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="Ay. CET" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                                <font class="Mandatory">*</font>
                            </td>
                            <td align="right">
                                CET Marks
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtCETMarks" runat="server" />
                                <font class="Mandatory">*</font>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Type of Quota
                                <%--<asp:Label runat="server"  Text="Type of Quota" ID="lblQuotaType" Font-Bold="true"></asp:Label>--%>
                            </td>
                            <td style="width: 1%; height: 20px" align="center">
                                <b>&nbsp;:&nbsp;</b>
                            </td>
                            <td style="height: 20px" align="left">
                                <asp:DropDownList runat="server" CssClass="selectbox" ID="ddlQuotaType">
                                    <asp:ListItem Text="--- Select ---" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Govt. Of  India (GOI)" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="AIEE" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Government Quota" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Open" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="60% Open Quota" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="60% Against Open" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="25 %  Reservation Quota" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="25 % Against Reservation Quota" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="15% NRI Quota" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="15 % Against NRI Quota" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="Minority Quota " Value="11"></asp:ListItem>
                                    <asp:ListItem Text="Against Minority Quota" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="Non-Minority Quota" Value="13"></asp:ListItem>
                                    
                                </asp:DropDownList>
                                <font class="Mandatory">*</font>
                            </td>
                            <td align="right">
                                Selection Letter
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="rblSelectionLettter" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                    runat="server">
                                    <asp:ListItem Text="Yes" Value="1" />
                                    <asp:ListItem Text="No" Value="0" Selected="True" />
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <b>Details of Subject Marks in HSC (12th)</b>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Marks in Physics
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtPhysicsParks" />
                                <font class="Mandatory">*</font>
                            </td>
                            <td align="right">
                                Marks in English
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtEnglishMarks" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Marks in Chemistry
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtChemistryMarks" />
                                <font class="Mandatory">*</font>
                            </td>
                            <td align="right">
                                Marks in Urdu/Maths
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtUrduMarks" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Marks in Biology
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtBioMarks" />
                                <font class="Mandatory">*</font>
                            </td>
                            <td align="right">
                                Marks in Computer
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtCompMarks" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Place of HSC(12th) Board
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtHscBoard" />
                                <font class="Mandatory">*</font>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <b>Other Details</b>
                            </td>
                        </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="right" style="width: 50%">
                            Are you from Maharashtra State
                        </td>
                        <td>
                            :
                        </td>
                        <td align="left">
                            <asp:RadioButtonList runat="server" ID="rblFromMaharashtra" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Text="Yes" Value="1" Selected="True" />
                                <asp:ListItem Text="No" Value="0" />
                            </asp:RadioButtonList>
                            <font class="Mandatory">*</font>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Registration and Diploma Certificate/GNM Marksheet
                        </td>
                        <td>
                            :
                        </td>
                        <td align="left">
                            <asp:RadioButtonList runat="server" ID="rblDipGNMsheet" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Text="Yes" Value="1" />
                                <asp:ListItem Text="No" Value="0" Selected="True" />
                            </asp:RadioButtonList>
                            <font class="Mandatory">*</font>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Are you a Foreigner
                        </td>
                        <td>
                            :
                        </td>
                        <td align="left">
                            <asp:RadioButtonList runat="server" ID="rblIsForeigner" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Yes" Value="1" />
                                <asp:ListItem Text="No" Value="0" Selected="True" />
                            </asp:RadioButtonList>
                            <font class="Mandatory">*</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 16px; padding-top: 10px;" colspan="6">
                            <asp:Button Text="Save & Proceed" ID="btnSubmit" OnClientClick="return fnSubmitValidate();"
                                runat="server" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                    </tbody>
                </table>
                <div>
                    
                    <asp:Label Text="Information Saved Successfully." ID="lblSaveMsg" Visible="false"
                        CssClass="saveNote" runat="server" />
                </div>
            </fieldset>
        </div>
        <div>
        <asp:Label ID="lblErrorMsg" Visible="False" CssClass="errorNote" runat="server" />
        </div>
    </div>
    <input id="hidFacID" runat="server" name="hidFacID" type="hidden" />
    <input id="hidCrID" runat="server" name="hidCrID" type="hidden" />
    <input id="hidMoLrnID" runat="server" name="hidMoLrnID" type="hidden" />
    <input id="hidPtrnID" runat="server" name="hidPtrnID" type="hidden" />
    <input id="hidBrnID" runat="server" name="hidBrnID" type="hidden" />
    <input id="hidCrPrDetailsID" runat="server" name="hidCrPrDetailsID" type="hidden" />
    <input id="hidCrPrChID" runat="server" name="hidCrPrChID" type="hidden" />
    <input id="hidStudentName" runat="server" type="hidden" />
    <input id="hidCrName" runat="server" type="hidden" />
    <input id="hidPRN" runat="server" type="hidden" />
    <input id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server" />
    <input id="hidInstID" runat="server" name="hidInstID" type="hidden" />
    <input id="hidYear" type="hidden" name="hidYear" runat="server" />
    <input id="hidStudentID" runat="server" name="hidStudentID" type="hidden" />
</asp:Content>
