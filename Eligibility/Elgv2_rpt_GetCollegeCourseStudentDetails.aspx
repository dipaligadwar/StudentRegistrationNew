<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="Elgv2_rpt_GetCollegeCourseStudentDetails.aspx.cs" Inherits="StudentRegistration.Eligibility.Elgv2_rpt_GetCollegeCourseStudentDetails" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>
<%@ Register Src="WebCtrl/SelectSingleCourseMUHS.ascx" TagName="YCMOU" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
        border="0" width="700">
        <tr style="width: 700">
            <td class="FormName" align="left" width="100%">
                <asp:Label ID="lblPageHead" runat="server" Font-Bold="True" Text="College Wise Student details report for MUHS"></asp:Label>
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
  
        <div id="DivReportViewerDesign" runat="server" style="display: none;">
            <rsweb:ReportViewer ID="rptViewer" Height="10px" runat="server" Font-Names="Verdana"
                Font-Size="8pt" AsyncRendering="false">
            </rsweb:ReportViewer>
        </div>
    </div>
    <asp:Label ID="lblCourse" runat="server" Text="Course" Style="display: none"></asp:Label>
    <asp:Label ID="lblPRN" runat="server" Text="PRN Numbner" Style="display: none"></asp:Label>
    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none"></asp:Label>
    <asp:Label ID="lblPaper" runat="server" Text="Paper" Style="display: none"></asp:Label>
    <table>
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </table>
    <input id="hidInstID" runat="server" style="width: 24px; height: 22px" type="hidden" />
    <input id="hid_fk_AcademicYr_ID" runat="server" style="width: 24px; height: 22px"
        type="hidden" />
    <input id="hid_AcademicYear" runat="server" style="width: 24px; height: 22px" type="hidden" />
    <input id="hid_strAcademicYr1" runat="server" value="" type="hidden" />
    <input id="hid_strAcademicYr2" runat="server" value="" type="hidden" />
    <input id="hidCountryId" style="width: 24px; height: 22px" type="hidden" value="0"
        runat="server" />
    <input id="hidCntry" style="width: 24px; height: 22px" type="hidden" value="0" runat="server" />
    <input id="hidStateID" style="width: 24px; height: 22px" type="hidden" value="0"
        runat="server" />
    <input id="hidDistrictID" style="width: 24px; height: 22px" type="hidden" value="0"
        runat="server" />
    <input id="hidTehsilID" style="width: 24px; height: 22px" type="hidden" value="0"
        runat="server" />
    <input id="hidCourseDetails" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidUniID" style="width: 24px; height: 22px" type="hidden" runat="server" />
    <input type="hidden" runat="server" id="hidregisterationInfo" />
    <input id="hidCollCode" style="width: 24px; height: 22px" type="hidden" runat="server" />
    <input id="hidFacID" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidFacText" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidCrID" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidCrText" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidMoLrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidMoLrnText" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidPtrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidPtrnText" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidBrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidCrPrDetailsID" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidCrPrChID" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidBrnText" runat="server" style="width: 32px; height: 22px" type="hidden" />
    <input id="hidLevelFlag" runat="server" value="" type="hidden" />
    <input id="hidCollName" runat="server" type="hidden" />
    <input id="hidAcYrName" runat="server" type="hidden" />
    <input id="hidFacName" runat="server" type="hidden" />
    <input id="hidCrName" runat="server" type="hidden" />
    <input id="hidBrName" runat="server" type="hidden" />
    <input id="hidCrPrName" runat="server" type="hidden" />
    <input id="hidCrPrDetName" runat="server" type="hidden" />
    <input id="hidCrPrChName" runat="server" type="hidden" />
    <input id="hidAllInstChkStatus" type="hidden" runat="server" />
    <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
    <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
        meta:resourcekey="lblUniversityResource1"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
    <asp:Label ID="lblSelectCr" runat="server" Text="Course" meta:resourcekey="lblSelectCrResource1"
        Style="display: none"></asp:Label>
    <asp:Label ID="lblFacultyNm" Style="display: none" runat="server" Text="Faculty Name"
        meta:resourcekey="lblFacultyNmResource1"></asp:Label>
    <asp:Label ID="lblFaculty" Style="display: none" runat="server" Text="Faculty" meta:resourcekey="lblFacultyResource1"></asp:Label>
</asp:Content>
