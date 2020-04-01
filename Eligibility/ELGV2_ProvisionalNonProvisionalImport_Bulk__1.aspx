<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="ELGV2_ProvisionalNonProvisionalImport_Bulk__1.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_ProvisionalNonProvisionalImport_Bulk__1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function validation() {

            var isChecked = false;
            var rbtnMarksOption = document.getElementById("<%=rbtCriteria.ClientID%>");
            var radioButtons = rbtnMarksOption.getElementsByTagName("input");
            for (var i = 0; i < radioButtons.length; i++) {
                if (radioButtons[i].checked) {
                    isChecked = true;
                    break;
                }
            }

            if (!isChecked) {
                alert("Please select criteria option for Importing.");
            }

            return isChecked;

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
                <td style="width: 705px">
                </td>
            </tr>
            <tr>
                <td style="width: 705px" valign="top" align="left">
                    <div runat="server" id="div1" style="margin-left: 30px; width: 90%; azimuth: center">
                        &nbsp;&nbsp;
                        <div runat="server" id="Div2" align="center">
                            <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 20px" colspan="3">
                                        <asp:Label ID="lblFileError" runat="server" EnableViewState="False" CssClass="errorNote" Style="text-align: right" Width="100%" meta:resourcekey="lblFileErrorResource1"></asp:Label><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 225px; height: 20px" align="right">
                                           <b> Select Criteria </b>&nbsp;</td>
                                        <td style="width: 1%; height: 20px" align="center">
                                            <b>&nbsp;:&nbsp;</b>
                                        </td>
                                        <td runat="server" id="td1" style="padding-top:13px; height: 20px" align="left" >
                                            <asp:RadioButtonList runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                                                Width="350px" ID="rbtCriteria">
                                                <asp:ListItem Text="Non Provisional Eligible" Value="1" meta:resourceKey="ListItemResource12"></asp:ListItem>
                                                <asp:ListItem Text="Provisional Eligible" Value="5" meta:resourceKey="ListItemResource13"></asp:ListItem>
                                            </asp:RadioButtonList><font class="Mandatory">*</font>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px" colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px" colspan="3" align="center">
                                            <asp:FileUpload ID="fileUploadExcel" runat="server" Font-Size="14px" Width="500px"
                                                meta:resourcekey="fileUploadExcelResource1"></asp:FileUpload> <font class="Mandatory">*</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px" colspan="3">&nbsp;
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div runat="server" id="DivGenerate">
                        <table cellpadding="0" width="100%">
                            <tbody>
                                <tr>
                                    <td style="height: 18px" valign="middle" align="center" colspan="4">
                                        <asp:Button runat="server" OnClientClick="return validation();" Width="150px" Text="Import File"
                                            CssClass="butSubmit" ID="btnProceed" OnClick="btnProceed_Click"></asp:Button>
                                        
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
                    <input runat="server" id="hidCrID" type="hidden" style="width: 32px; height: 22px" />
                    <input runat="server" id="hidMoLrnID" type="hidden" style="width: 32px; height: 22px" />
                    <input runat="server" id="hidPtrnID" type="hidden" style="width: 32px; height: 22px" />
                    <input runat="server" id="hidBrnID" type="hidden" style="width: 32px; height: 22px" />
                    <input runat="server" id="hidCrPrDetailsID" type="hidden" style="width: 32px; height: 22px" />
                    <input runat="server" id="hidCrPrChID" type="hidden" style="width: 32px; height: 22px" />
                    <input runat="server" id="hid_fk_AcademicYr_ID" type="hidden" />
                    <input runat="server" id="hidCourseDetails" type="hidden" style="width: 32px; height: 22px" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
