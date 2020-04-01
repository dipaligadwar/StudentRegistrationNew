<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MercyAllow__1.aspx.cs"
    MasterPageFile="~/Home.Master" Inherits="StudentRegistration.Eligibility.MercyAllow_1"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%-- <tr class="rFont">
                                                                                <td valign="top" width="20%">
                                                                                    <b>Course</b></td>
                                                                                <td valign="top" colspan="3">
                                                                                    <asp:Label ID="lblCourse" runat="server"></asp:Label></td>
                                                                            </tr>
                                                                            <tr class="rFont">
                                                                                <td valign="top" width="20%" style="height: 19px">
                                                                                    <b>College</b></td>
                                                                                <td valign="top" colspan="3" style="height: 19px">
                                                                                    <asp:Label ID="lblCollege" runat="server"></asp:Label></td>
                                                                            </tr>--%>
    <script language="javascript" type="text/javascript">

        function Confirmation() {
            var msg = 'Are you sure to allow mercy to selected student?'

            var answer = confirm(msg)
            if (answer) {
                return true;
            }
            else {
                return false;
            }
        } 
            
    </script>
    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="0">
            <tr height="15">
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" Text="Mercy Allow" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <table width="100%">
                        <tbody>
                            <tr>
                                <td align="center">
                                    <table id="Table3" width="100%">
                                        <!--Personal and Academic Details start here-->
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblNote" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <fieldset>
                                                    <legend id="Legend1" runat="server"><strong><span style="text-decoration: underline"
                                                        id="SPAN2" runat="server">Registration and Personal Details Of Student </span></strong>
                                                    </legend>
                                                    <table cellspacing="0" cellpadding="3" width="100%" border="0">
                                                        <tr>
                                                            <td height="15px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" style="height: 75px">
                                                                <fieldset>
                                                                    <legend id="Legend2" runat="server"><strong><span id="SPAN1" runat="server">Registration
                                                                        Details </span></strong></legend>
                                                                    <table class="tblBackColor" cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                        <tr class="rFont">
                                                                            <td valign="top" colspan="2" style="width: 42%; height: 21px">
                                                                                <b>
                                                                                    <asp:Label ID="lblPRNumber" runat="server" Text="Permanent Registration Number" meta:resourcekey="lblPRNumberResource1"></asp:Label>
                                                                                </b>
                                                                            </td>
                                                                            <td valign="top" colspan="2" style="height: 21px">
                                                                                <asp:Label ID="lblPRN" runat="server" Width="266px" meta:resourcekey="lblPRNResource1"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        
                                                                    </table>
                                                                </fieldset>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellspacing="0" cellpadding="3" width="100%" border="0">
                                                        <tr>
                                                            <td style="height: 194px">
                                                                <fieldset>
                                                                    <legend id="Legend3" runat="server"><strong><span id="SPAN3" runat="server">Personal
                                                                        Details </span></strong></legend>
                                                                    <table class="tblBackColor" cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                        <tr class="rFont">
                                                                            <td valign="top" width="30%" align="left">
                                                                                <b>Full Name</b>
                                                                            </td>
                                                                            <td valign="top" colspan="3" align="left">
                                                                                <asp:Label ID="lblNameOfStudent" runat="server" meta:resourcekey="lblNameOfStudentResource1"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="rFont">
                                                                            <td valign="top" width="30%" align="left">
                                                                                <b>Name as printed on statement of marks</b>
                                                                            </td>
                                                                            <td valign="top" colspan="3" align="left" style="font-size: 10px;">
                                                                                <asp:Label ID="lblNameOnMarksheet" runat="server" meta:resourcekey="lblNameOnMarksheetResource1"></asp:Label>
                                                                                <br />
                                                                                <asp:Label ID="Label1" runat="server" Text="Note: This name will appear on all documents of the University. Please ensure that it matches exactly with name as printed on Statement of Marks of last qualifying examination."
                                                                                    ForeColor="Red" meta:resourcekey="Label1Resource1"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="rFont">
                                                                            <td valign="top" width="30%" align="left">
                                                                                <b>Father's Full Name</b>
                                                                            </td>
                                                                            <td valign="top" colspan="3" align="left">
                                                                                <asp:Label ID="lblFathersName" runat="server" meta:resourcekey="lblFathersNameResource1"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="rFont">
                                                                            <td valign="top" width="30%" style="height: 15px" align="left">
                                                                                <b>Mother's Maiden Name</b>
                                                                            </td>
                                                                            <td valign="top" colspan="3" style="height: 15px" align="left">
                                                                                <asp:Label ID="lblMothersMaidenName" runat="server" meta:resourcekey="lblMothersMaidenNameResource1"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="rFont">
                                                                            <td valign="top" width="30%" align="left">
                                                                                <b>Date of Birth</b>
                                                                            </td>
                                                                            <td valign="top" width="30%" align="left">
                                                                                <asp:Label ID="lblDOB" runat="server" meta:resourcekey="lblDOBResource1"></asp:Label>
                                                                            </td>
                                                                            <td valign="top" width="20%" align="left">
                                                                                <b>Gender</b>
                                                                            </td>
                                                                            <td valign="top" width="20%" align="left">
                                                                                <asp:Label ID="lblGender" runat="server" meta:resourcekey="lblGenderResource1"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </fieldset>
                                                            </td>
                                                            <td valign="top" width="20%" style="height: 194px">
                                                                <fieldset style="height: 100%">
                                                                    <table class="tblBackColor" cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                        <tr class="GridSubHeading">
                                                                            <td style="height: 16px; width: 130px;" valign="top" align="center">
                                                                                <b>Photograph</b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="rFont">
                                                                            <td valign="top" align="center" style="width: 130px">
                                                                                <asp:Image ID="Image1" runat="server" AlternateText="Photograph" meta:resourcekey="Image1Resource1">
                                                                                </asp:Image>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="GridSubHeading">
                                                                            <td style="height: 16px; width: 130px;" valign="top" align="center">
                                                                                <b>Signature</b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="rFont">
                                                                            <td valign="top" align="center" style="width: 130px; height: 66px">
                                                                                <asp:Image ID="Image2" runat="server" AlternateText="Signature" ToolTip="Signature"
                                                                                    meta:resourcekey="Image2Resource1"></asp:Image>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </fieldset>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <fieldset>
                                                        <legend><strong>
                                                            <asp:Label ID="lblCrInstDetails" runat="server" Text="Course & College Details" meta:resourcekey="lblCrInstDetailsResource1"></asp:Label>
                                                            : </strong></legend>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="DGCourseInstitute1" runat="server" AutoGenerateColumns="False"
                                                                        CssClass="clGrid" Width="100%" EmptyDataText="Target Couse data not available for current selection..!"
                                                                        DataKeyNames="pk_Uni_ID,pk_Fac_ID,pk_Cr_ID,pk_MoLrn_ID,pk_Ptrn_ID,pk_Brn_ID,pk_CrPr_Details_ID,ReRegistration_Flag,CrDesc,Re-Registarion"
                                                                        EnableModelValidation="True">
                                                                        <HeaderStyle CssClass="gridHeader" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="SNo.">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DisplayIndex + 1 %>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="3px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="CrDesc" HeaderText="Course" />
                                                                            <asp:BoundField DataField="Re-Registarion" HeaderText="ReRegistration" />
                                                                            <asp:TemplateField HeaderText="Select">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="3px" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    <%--<asp:GridView ID="DGCourseInstitute1" runat="server" Width="100%" BorderWidth="1px"
                                                                                        BorderColor="#336699" AutoGenerateColumns="False" BorderStyle="Solid" meta:resourcekey="DGCourseInstitute1Resource1">
                                                                                        <RowStyle CssClass="gridItem"></RowStyle>
                                                                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="InstName" HeaderText="College Name" meta:resourcekey="BoundFieldResource1">
                                                                                                <HeaderStyle Font-Bold="True"></HeaderStyle>
                                                                                            </asp:BoundField>
                                                                                            
                                                                                            <asp:BoundField DataField="InstCode" HeaderText="College Code" meta:resourcekey="BoundFieldResource3">
                                                                                                <HeaderStyle Font-Bold="True"></HeaderStyle>
                                                                                            </asp:BoundField>
                                                                                            
                                                                                            <asp:BoundField DataField="CrDesc" HeaderText="Course" meta:resourcekey="BoundFieldResource2">
                                                                                                <HeaderStyle Font-Bold="True"></HeaderStyle>
                                                                                            </asp:BoundField>
                                                                                        </Columns>
                                                                                    </asp:GridView>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <!---Personal Details end here-->
                                        <tr>
                                            <td align="right" width="100%">
                                                <asp:Label ID="lblError" runat="server" CssClass="saveNote" meta:resourcekey="lblErrorResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="100%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnBack" runat="server" CssClass="butSubmit" Text="Back" 
                                                    meta:resourcekey="btnUpdateContactDetailsResource1" Width="43px">
                                                </asp:Button>&nbsp;&nbsp;
                                                <asp:Button ID="btnMercyAllow" runat="server" CssClass="butSubmit" Text="Mercy Allow"
                                                    OnClick="btnMercyAllow_Click" meta:resourcekey="btnUpdateContactDetailsResource1">
                                                </asp:Button>&nbsp;&nbsp;
                                                <%-- <asp:Button ID="btnGoToStudentList" runat="server" CssClass="butSubmit" Text="Go To StudentList"
                                                    OnClick="btnGoToStudentlist_Click" meta:resourcekey="btnGoToStudentListResource1">
                                                </asp:Button>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp; <strong>Note:</strong><font class="Mandatory">*</font> marked fields are
                                                mandatory.
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
        <input id="hid_pk_Student_ID" type="hidden" name="hid_pk_Student_ID" runat="server"
            style="width: 1px" />&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="hid_pk_Year" style="width: 1px; height: 22px" type="hidden" name="hid_pk_Year"
            runat="server" />
        <input id="hid_pk_Uni_ID" style="width: 1px; height: 22px" type="hidden" name="hid_pk_Uni_ID"
            runat="server" />
        <input id="hidPRN" type="hidden" name="hidPRN" runat="server" style="width: 1px">
        <input id="hidUniID" style="width: 1px; height: 22px" type="hidden" name="hidUniID"
            runat="server" />
        <input id="hidFacID" style="width: 1px; height: 22px" type="hidden" value="0" name="hidFacID"
            runat="server" />
        <input id="hidCrID" style="width: 1px; height: 22px" type="hidden" value="0" name="hidCrID"
            runat="server" />
        <input id="hidMoLrnID" style="width: 1px; height: 22px" type="hidden" value="0" name="hidMoLrnID"
            runat="server" />
        <input id="hidPtrnID" style="width: 1px; height: 22px" type="hidden" value="0" name="hidPtrnID"
            runat="server" />
        <input id="hidBrnID" style="width: 1px; height: 22px" type="hidden" value="0" name="hidBrnID"
            runat="server" />
        <input id="hidCrPrID" style="width: 1px; height: 22px" type="hidden" value="0" name="hidCrPrID"
            runat="server" />
        <input id="hidCrPr_DetailsID" style="width: 1px; height: 22px" type="hidden" value="0"
            name="hidCrPr_DetailsID" runat="server" />
        <input id="hidTargetXML" runat="server" type="hidden" />
    </center>
</asp:Content>
