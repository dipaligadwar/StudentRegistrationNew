<%@ Page Language="c#" CodeBehind="ELGV2_ManualProcess__1.aspx.cs" MasterPageFile="~/Home.Master"
    AutoEventWireup="True" Inherits="StudentRegistration.Eligibility.ELGV2_ManualProcess__1" %>

<%@ Register TagPrefix="uc1" TagName="StudentAdvancedSearchforManualProcess" Src="WebCtrl/StudentAdvancedSearchforManualProcess.ascx" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/jscript_validations.js"></script>
    <script language="javascript">

        function fnSubmit(event) {
            if (event.keyCode == 13 || event.keyCode == 9)             //13 - enter key , 9- tab key
            {
                document.getElementById('ctl00_ContentPlaceHolder1_btnSimpleSearch').focus();
                document.getElementById('ctl00_ContentPlaceHolder1_btnSimpleSearch').click();
            }
        }


        //Validating eligibility form number.
        function ChkValidation() {

            var obElg = document.getElementById("ctl00_ContentPlaceHolder1_txtElgFormNo").value;
            var obAppFormNo = $("#<%=txtApplicationFrmNo.ClientID %>").val();
            var sStr = obElg.split('-');
            var ret = true;
            if ((obElg.length == 0) && (obAppFormNo.length == 0)) {
                alert("Enter a valid Eligibility Form Number OR Admission Form Number.")
                ret = false;
            }

            else if ((obElg.length > 0) && (obAppFormNo.length > 0)) {
                alert("Enter a Either Eligibility Form Number OR Admission Form Number.")
                ret = false;
            }
            else if (obElg.length > 0 && obAppFormNo.length ==0) {
                ret = ChkEligFormNumber(obElg);
                if (ret == true) {
                    if (sStr[1] == document.getElementById('<%=hidInstID.ClientID %>').value) {
                        ret = true;
                    }
                    else {
                        alert(".:The Student is not in selected " + document.getElementById('ctl00_ContentPlaceHolder1_lblCollege').innerText + ":.\n Please Enter Correct Form No.");
                        ret = false;
                    }
                }
            }
            else if (obAppFormNo.length > 0 && obElg.length == 0) {

                var myArray = new Array();
                myArray[myArray.length] = new Array(document.getElementById("<%= txtApplicationFrmNo.ClientID%>"), "NumericOnly/Empty", "Enter Valid Application Form Number", "text");
                var ret = validateMe(myArray, 10);
                if(ret==false)
                return ret;
                innerRet = CheckInstforStudentAppFormNo();


                if (innerRet == false) {
                    alert(".:The Student is not in selected " + document.getElementById('ctl00_ContentPlaceHolder1_lblCollege').innerText + ":.\n Please Enter Correct Application Form No.");
                    ret = false;

                }
            }

            else {
                alert("Please enter either Eligibility Form Number or Application Form Number");
                ret = false;
            }
            return ret;
        }

        function CheckInstforStudentAppFormNo() {
            var ResultStatus = clsStudent.CheckInstforStudentAppFormNo(document.getElementById('<%=hidUniID.ClientID%>').value, document.getElementById('<%=txtApplicationFrmNo.ClientID%>').value, document.getElementById('<%=hidInstID.ClientID%>').value);
            if (ResultStatus.value == "1")   // Student belongs to selected institute
                return true;
            else                            // Student does not belong to selected institute
                return false;

        }
				
    </script>
    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="0">
            <tr style="height: 5px;">
                <td>
                </td>
            </tr>
            <tr>
                <%--<td class="FormName" align="left" valign="middle">
                        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" CssClass="lblPageHead"></asp:Label>
                        <asp:Label ID="lblInstName" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>--%>
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                    <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="True" Font-Size="Small"
                        meta:resourcekey="lblAcademicYearResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPaidList" runat="server" CssClass="lblPageHead" meta:resourcekey="lblPaidListResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td id="TDLink" style="display: none" runat="server">
                </td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr style="height: 5px;">
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 13px">
                                <asp:LinkButton ID="lnkSimpleSearch" CssClass="NavLink" runat="server" OnClick="lnkSimpleSearch_Click"
                                    meta:resourcekey="lnkSimpleSearchResource1">Simple Search</asp:LinkButton>&nbsp;|&nbsp;
                                <asp:LinkButton ID="lnkAdvSearch" CssClass="NavLink" runat="server" OnClick="lnkAdvSearch_Click"
                                    meta:resourcekey="lnkAdvSearchResource1">Advanced Search</asp:LinkButton>
                            </td>
                        </tr>
                        <tr style="height: 10pt;">
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <div id="divSimpleSearch" runat="server">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td align="right" height="30" width="25%">
                                    <strong>Enter Eligibility Form Number</strong>
                                </td>
                                <td align="center" width="1%" height="30">
                                    <b>:</b>
                                </td>
                                <td width="58%" height="30">
                                    <asp:TextBox ID="txtElgFormNo" runat="server" Font-Bold="True" Font-Size="Small"
                                        meta:resourcekey="txtElgFormNoResource1"  CssClass="redbox" ></asp:TextBox>
                                    <font class="Mandatory">*</font>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" height="30" colspan="3">
                                    <strong>OR</strong>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" height="30" width="25%">
                                    <strong>Enter Application Form Number</strong>
                                </td>
                                <td align="center" width="1%" height="30">
                                    <b>:</b>
                                </td>
                                <td width="58%" height="30">
                                    <asp:TextBox ID="txtApplicationFrmNo" runat="server" onclick="this.value='';" Font-Bold="True"
                                        Font-Size="Small" MaxLength = "20"  CssClass="redbox" ></asp:TextBox>
                                    <font class="Mandatory">*</font>
                                </td>
                            </tr>
                           <%-- <tr>
                                <td align="right" height="30" widht="25%">
                                    <strong>Consider Payment Status</strong>
                                </td>
                                <td align="center" width="1%" height="30">
                                    <b>:</b>
                                </td>
                                <td colspan="3">
                                    <asp:RadioButton ID="rbWithInv" Text="Yes" GroupName="grpInvoice" runat="server" />
                                    <asp:RadioButton ID="rbWithoutInv" Text="No" Checked="True" GroupName="grpInvoice"
                                        runat="server" />
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="5">
                                    <br>
                                    <asp:Button ID="btnSimpleSearch" CssClass="butSubmit" Height="18px" Text="Search"
                                        runat="server" OnClick="btnSimpleSearch_Click" meta:resourcekey="btnSimpleSearchResource1">
                                    </asp:Button>
                                </td>
                            </tr>
                            <div>
                                <tr id="divErrorMsg" runat="server" style="display: none;">
                                    <td align="center" colspan="5">
                                        <br>
                                        <br>
                                        <br>
                                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="errorNote" Visible="False" meta:resourcekey="lblErrorMsgResource1"></asp:Label>
                                    </td>
                                </tr>
                            </div>
                            <tr>
                                <td colspan="5">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divAdvSearch" runat="server" style="display: none;">
                        &nbsp;
                        <uc1:StudentAdvancedSearchforManualProcess ID="StudentAdvancedSearchforManualProcess1"
                            runat="server"></uc1:StudentAdvancedSearchforManualProcess>
                    </div>
                    <input id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server">
                    <input id="hidSearchType" type="hidden" name="hidSearchType" runat="server">
                    <input id="hidInstID" runat="server" name="hidInstID" style="width: 24px; height: 22px"
                        type="hidden" />
                    <input id="hidUniID" runat="server" name="hidUniID" style="width: 24px; height: 22px"
                        type="hidden" />
                    <input id="hidpkStudentID" runat="server" name="hidpkStudentID" type="hidden" value="0" />
                    <input id="hidpkYear" runat="server" name="hidpkYear" type="hidden" value="0" />
                    <input id="hidpkFacID" type="hidden" name="hidpkFacID" runat="server">
                    <input id="hidpkCrID" type="hidden" name="hidpkCrID" runat="server">
                    <input id="hidpkMoLrnID" type="hidden" name="hidpkMoLrnID" runat="server">
                    <input id="hidpkPtrnID" type="hidden" name="hidpkPtrnID" runat="server">
                    <input id="hidpkBrnID" type="hidden" name="hidpkBrnID" runat="server">
                    <input id="hidpkCrPrDetailsID" type="hidden" name="hidpkCrPrDetailsID" runat="server">
                    <input id="hidCollElgFlag" type="hidden" name="hidCollElgFlag" runat="server">
                    <input id="hidDOB" type="hidden" name="hidDOB" runat="server">
                    <input id="hidLastName" type="hidden" name="hidDOB" runat="server">
                    <input id="hidFirstName" type="hidden" name="hidDOB" runat="server">
                    <input id="hidGender" type="hidden" name="hidDOB" runat="server">
                    <input id="hidElgStatusColl" type="hidden" name="hidElgStatusColl" runat="server">
                    <input id="hidCollElgFlagReason" type="hidden" name="hidCollElgFlagReason" runat="server">
                    <input id="hidElgStatusUni" type="hidden" name="hidElgStatusUni" runat="server">
                    <input id="hidInv" type="hidden" name="hidInv" runat="server">
                    <input id="hidIsBlank" type="hidden" name="hidIsBlank" runat="server">
                    <input id="hidrbFilterYesNo" type="hidden" name="hidrbFilterYesNo" runat="server">
                    <input id="hid_fk_AcademicYr_ID" type="hidden" name="hid_fk_AcademicYr_ID" runat="server">
                    <input id="hidAcademicYr" type="hidden" name="hidAcademicYr" runat="server">
                    <input id="hidAcademicYrText" type="hidden" name="hidAcademicYrText" runat="server">
                    <input id="hidStateID" type="hidden" name="hidStateID" runat="server">
                    <input id="hidBodyID" type="hidden" name="hidBodyID" runat="server">
                    <input id="hidBodySelText" type="hidden" name="hidBodySelText" runat="server" />
                    <input id="hidBodyTypeFlag" type="hidden" name="hidBodyTypeFlag" runat="server" />
                    <input id="hidrbWithInv" type="hidden" name="hidrbWithInv" runat="server">
                    <input id="hidrbWithoutInv" type="hidden" name="hidrbWithoutInv" runat="server">
                    <input id="hidAcademicYearID" type="hidden" name="hidAcademicYearID" runat="server">
                     <input id="hidAppFormNo" type="hidden" value="0" name="hidAppFormNo" runat="server" />
                    <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
                    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
