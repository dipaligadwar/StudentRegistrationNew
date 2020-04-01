<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="ELGV2_rpt_FormAReport.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_rpt_FormAReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>
<%@ Register Src="WebCtrl/SelectSingleCourse.ascx" TagName="YCMOU" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
        border="0" width="700">
        <tr style="width: 700">
            <td class="FormName" align="left" width="100%">
                <asp:Label ID="lblPageHead" runat="server" Font-Bold="True" Text="Form A Report"></asp:Label>
                <asp:Label ID="lblAcaYear" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
            </td>
        </tr>
        <tr style="width: 700">
            <td colspan="3">
                <div id="divYCMOU" runat="server">
                    <uc3:YCMOU ID="YCMOU" runat="server"></uc3:YCMOU>
                </div>
            </td>
        </tr>
    </table>
    <div>
        <asp:Label Text="No Record Found" ID="lblErrorMsg" runat="server" Visible="false"
            CssClass="errorNote" />
    </div>
    <div style="margin: 10px;">
        <%--<asp:Button ID="ExptToExl" CssClass="clButtonHolder" runat="server" Text="Export To Excel"
            OnClick="ExptToExl_Click" />--%>
        <%-- <asp:Button ID="ExptToPDF" CssClass="clButtonHolder" runat="server" Text="Export To PDF"
            OnClick="ExptToPDF_Click" />--%>
        <div id="DivReportViewerDesign" runat="server" style="display: none;">
            <rsweb:ReportViewer ID="rptViewer" Height="10px" runat="server" Font-Names="Verdana"
                Font-Size="8pt" AsyncRendering="false">
            </rsweb:ReportViewer>
        </div>
    </div>
    <asp:Label ID="lblCourse" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCourseResource1"></asp:Label>
    <asp:Label ID="lblPRN" runat="server" Text="PRN Numbner" Style="display: none" meta:resourcekey="lblPRNResource1"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Paper" Style="display: none" meta:resourcekey="lblPaperResource1"></asp:Label>
    <input id="hidUniID" type="hidden" runat="server" />
    <input id="hidInstID" runat="server" type="hidden" />
    <input id="hidCollName" runat="server" type="hidden" />
    <input id="Hidden1" runat="server" type="hidden" />
    <input id="hid_fk_AcademicYr_ID" runat="server" type="hidden" />
    <input id="hid_AcademicYear" runat="server" type="hidden" />
    <input id="hid_strAcademicYr1" runat="server" value="" type="hidden" />
    <input id="hid_strAcademicYr2" runat="server" value="" type="hidden" />
    <input id="hidCountryId" type="hidden" value="0" runat="server" />
    <input id="hidCntry" type="hidden" value="0" runat="server" />
    <input id="hidStateID" type="hidden" value="0" runat="server" />
    <input id="hidDistrictID" type="hidden" value="0" runat="server" />
    <input id="hidTehsilID" type="hidden" value="0" runat="server" />
    <input id="hidCourseDetails" runat="server" type="hidden" />
    <input type="hidden" runat="server" id="hidregisterationInfo" />
    <input id="hidCollCode" type="hidden" runat="server" />
    <input id="hidFacID" runat="server" type="hidden" />
    <input id="hidFacText" runat="server" type="hidden" />
    <input id="hidCrID" runat="server" type="hidden" />
    <input id="hidCrText" runat="server" type="hidden" />
    <input id="hidMoLrnID" runat="server" type="hidden" />
    <input id="hidMoLrnText" runat="server" type="hidden" />
    <input id="hidPtrnID" runat="server" type="hidden" />
    <input id="hidPtrnText" runat="server" type="hidden" />
    <input id="hidBrnID" runat="server" type="hidden" />
    <input id="hidCrPrDetailsID" runat="server" type="hidden" />
    <input id="hidCrPrChID" runat="server" type="hidden" />
    <input id="hidBrnText" runat="server" type="hidden" />
    <input id="hidLevelFlag" runat="server" value="" type="hidden" />
    <input id="Hidden3" runat="server" type="hidden" />
    <input id="hidAcYrName" runat="server" type="hidden" />
    <input id="hidFacName" runat="server" type="hidden" />
    <input id="hidCrName" runat="server" type="hidden" />
    <input id="hidBrName" runat="server" type="hidden" />
    <input id="hidCrPrName" runat="server" type="hidden" />
    <input id="hidCrPrDetName" runat="server" type="hidden" />
    <input id="hidCrPrChName" runat="server" type="hidden" />
    <input id="hidAllInstChkStatus" type="hidden" runat="server" />
    <input id="hidTermSelection" type="hidden" runat="server" />
    <input id="hidCrPrChIds" type="hidden" runat="server" />
    <input id="hidCrPrChNames" type="hidden" runat="server" />
    <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
    <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
        meta:resourcekey="lblUniversityResource1"></asp:Label>
    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
    <asp:Label ID="lblSelectCr" runat="server" Text="Course" meta:resourcekey="lblSelectCrResource1"
        Style="display: none"></asp:Label>
    <asp:Label ID="lblFacultyNm" Style="display: none" runat="server" Text="Faculty Name"
        meta:resourcekey="lblFacultyNmResource1"></asp:Label>
    <asp:Label ID="lblPaper" runat="server" Text="Paper" meta:resourcekey="lblPaperResource1"
        Style="display: none"></asp:Label>
    <input id="hidRCName" runat="server" type="hidden" />
    <input id="hidRCID" runat="server" type="hidden" />
     <table>
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </table>
</asp:Content>
