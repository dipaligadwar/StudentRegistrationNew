<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="ELGV2_rptCancelAdmission_Report.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_rptCancelAdmission_Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function callvalidate() {
            try {
                var i = -1;
                var myArr = new Array();

                var flag = false;
                myArr[++i] = new Array(document.getElementById(hidAcademicYr), "0", "Select Academic Year", "select");
                if (validateMe(myArr, 50)) {

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
    </script>
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
                <td align="right" style="width: 705px">
                    <asp:Label ID="lblSave" runat="server" CssClass="saveNote" meta:resourcekey="lblSaveResource1"></asp:Label>
                    <div>
                        <asp:Label Text="No Record Found" ID="lblErrorMsg" runat="server" Visible="false"
                            CssClass="errorNote" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 10px; padding: 5px;" align="center" id="DIVInfoBox" runat="server">
            <div id="div3" class="clOuterDiv">
                <div class="clImageHolder">
                </div>
                <div id="div4" class="clInfoHolder" style="background-color: #EFEFEF; text-align: left;
                    border: dashed 1px #c0c0c0; padding-top: 10px; padding-bottom: 5px; padding-left: 20px;">
                    <table>
                        <tr>
                           <%-- <td valign="top">
                                &bull;
                            </td>--%>
                            <td style="padding-left: 2px; vertical-align: top">
                                <asp:Label ID="LblInfo1" runat="server" meta:resourcekey="LblInfo1Resource1">
                                Cancel admission will remove the student data from DU as well as DC. Please do cancel admission carefully. Cancel admission data can not be retrived in any case. If you want to cancel admission form DU only and not from DC, use cancel invoice menu.
                                </asp:Label>
                            </td>
                        </tr>
                        
                        <%--<tr>
                            <td valign="top">
                                &bull;
                            </td>
                            <td style="padding-left: 2px; vertical-align: top">
                                <asp:Label ID="LblInfo5" runat="server" meta:resourcekey="LblInfo5Resource1">
                             
                                </asp:Label>
                            </td>
                        </tr>--%>
                    </table>
                </div>
            </div>
        </div>
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
                                                <b>&nbsp;:&nbsp;</b>
                                            </td>
                                            <td runat="server" id="td1" style="width: 387px; height: 20px" align="left">
                                                <asp:DropDownList runat="server" CssClass="selectbox" Width="298px" ID="ddlAcademicYr"
                                                    meta:resourceKey="ddlAcademicYrResource1">
                                                    <asp:ListItem Text="--- Select ---" Value="0" meta:resourceKey="ListItemResource1"></asp:ListItem>
                                                </asp:DropDownList>
                                                <font class="Mandatory">*</font>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <br />
                        <div runat="server" id="divCollege" style="margin-left: 30px; width: 90%; azimuth: center">
                            <center>
                                <asp:Button ID="btnGenerate" runat="server" Text="Generate Report" OnClick="btnGenerate_Click" /></center>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="margin: 10px;">
        <div id="DivReportViewerDesign" runat="server" visible="false">
            <rsweb:ReportViewer ID="rptViewer" Height="300px" runat="server" Font-Names="Verdana"
                Font-Size="8pt" AsyncRendering="false"  Width="100%"  onprerender="rptViewer_PreRender">
            </rsweb:ReportViewer>
        </div>
    </div>
    <asp:Label ID="lblCourse" runat="server" Text="Course" Style="display: none"></asp:Label>
    <asp:Label ID="lblPRN" runat="server" Text="PRN Numbner" Style="display: none"></asp:Label>
    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none"></asp:Label>
    <asp:Label ID="lblPaper" runat="server" Text="Paper" Style="display: none"></asp:Label>
</asp:Content>
