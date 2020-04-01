<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ELGV2_ChangeProcessedEligibilityStatus__2.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_ChangeProcessedEligibilityStatus__2" %>

<%@ Register TagPrefix="uc1" TagName="StudentAdvanceSeachForConfigureChangeElgUnprocess" Src="WebCtrl/StudentAdvanceSeachForConfigureChangeElgUnprocess.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

    <script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/jscript_validations.js"></script>



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
            var obElg = document.getElementById('ctl00_ContentPlaceHolder1_tbElgFormNo').value;
            var sStr = obElg.split('-');
            var ret = true;
            if (obElg.length > 0) {
                ret = ChkEligFormNumber(obElg);
                if (ret == true) {
                    if (sStr[1] == document.getElementById('ctl00_ContentPlaceHolder1_hidInstID').value) {
                        ret = true;
                    }
                    else {
                        alert(".:The Student is not in selected " + document.getElementById('lblCollege').innerText + ":.\n Please Enter Correct Form No.");
                        ret = false;
                    }
                }
            }
            else {
                alert("Please enter the Eligibility Form Number.");
                ret = false;
            }
            return ret;
        }
    </script>

    <center>
        

        <table id="table1" border="0" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="100%">
            <tr>
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                    <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="True" Font-Size="Small"
                        meta:resourcekey="lblAcademicYearResource1" style="display:none"></asp:Label></td>
            </tr>
            <%--<table cellspacing="0" cellpadding="0" border="0">
                    <tr style="height:5px;"><td></td>
                    </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkSimpleSearch" CssClass="NavLink" runat="server" OnClick="lnkSimpleSearch_Click" meta:resourcekey="lnkSimpleSearchResource1">Simple Search</asp:LinkButton>&nbsp;|&nbsp;
                                <asp:LinkButton ID="lnkAdvSearch" CssClass="NavLink" runat="server" OnClick="lnkAdvSearch_Click" meta:resourcekey="lnkAdvSearchResource1">Advanced Search</asp:LinkButton>
                            </td>
                        </tr>
                        <tr style="height: 10pt;">
                            <td>
                            </td>
                        </tr>
                    </table>--%>
            <%--<div id="divSimpleSearch" runat="server">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td align="right" height="30">
                                    <strong>Enter&nbsp;Eligibility Form Number</strong></td>
                                <td align="center" width="2%" height="30">
                                    <b></b>
                                </td>
                                <td width="58%" height="30">
                                    <asp:TextBox ID="tbElgFormNo" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="tbElgFormNoResource1"></asp:TextBox>
                                    <font class="Mandatory">*</font></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <br>
                                    <asp:Button ID="btnSimpleSearch" CssClass="butSubmit" Text="Search" runat="server"
                                        OnClick="btnSimpleSearch_Click" meta:resourcekey="btnSimpleSearchResource1"></asp:Button>
                                </td>
                            </tr>
                            <div id="divErrorMsg" runat="server">
                                <tr>
                                    <td align="center" colspan="3">
                                        <br>
                                        <br>
                                        <br>
                                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="errorNote" Visible="False" meta:resourcekey="lblErrorMsgResource1"></asp:Label></td>
                                </tr>
                            </div>
                        </table>
                    </div>--%>
        </table>
        <uc1:StudentAdvanceSeachForConfigureChangeElgUnprocess ID="StudentAdvanceSeachForConfigureChangeElgUnprocess1" runat="server">
        </uc1:StudentAdvanceSeachForConfigureChangeElgUnprocess>
        
        <input id="hidUniID" runat="server" name="hidUniID" type="hidden" />
        <input id="hidInstID" runat="server" name="hidInstID" type="hidden" />
        <input id="hidpkStudentID" type="hidden" name="hidpkStudentID" runat="server">
        <input id="hidpkYear" type="hidden" name="hidpkYear" runat="server">
        <input id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server">
        <input id="hidpkFacID" type="hidden" name="hidpkFacID" runat="server">
        <input id="hidpkCrID" type="hidden" name="hidpkCrID" runat="server">
        <input id="hidpkMoLrnID" type="hidden" name="hidpkMoLrnID" runat="server">
        <input id="hidpkPtrnID" type="hidden" name="hidpkPtrnID" runat="server">
        <input id="hidpkBrnID" type="hidden" name="hidpkBrnID" runat="server">
        <input id="hidpkCrPrDetailsID" type="hidden" name="hidpkCrPrDetailsID" runat="server">
        <input id="hidSearchType" type="hidden" name="hidSearchType" runat="server">
        <input id="hid_fk_AcademicYr_ID" type="hidden" name="hid_fk_AcademicYr_ID" runat="server" />
        <input id="hidAcademicYrText" type="hidden" name="hidAcademicYrText" runat="server" />
        <input id="hidAppFormNo" type="hidden" value="0" name="hidAppFormNo" runat="server" />
        <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
            meta:resourcekey="lblUniversityResource1"></asp:Label>
        <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
        <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none"
            meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>
        <input id="hidFacName" runat="server" type="hidden" />
        <input id="hidCrName" runat="server" type="hidden" />
        <input id="hidMOLName" runat="server" type="hidden" />
        <input id="hidPattern" runat="server" type="hidden" />
        <input id="hidBrName" runat="server" type="hidden" />
        <input id="hidCrPrName" runat="server" type="hidden" />
        <input id="hidAcYrName" runat="server" type="hidden" />
    </center>
</asp:Content>
