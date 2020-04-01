<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ELGV2_BulkProcess_reg_Students__2.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_BulkProcess_reg_Students__2"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=Classes.clsGetSettings.Name%>
        - StudentRegistration </title>
    <link href="/CSS/UniPortal.css" type="text/css" rel="stylesheet" />
    <link href="/CSS/calendar-blue.css" type="text/css" rel="stylesheet" />
    <script language="javascript">

        function closewindow() {
            return window.close();
        }
     
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table height="100%" cellspacing="0" cellpadding="0" width="90%" border="0">
            <tbody>
                <tr>
                    <td valign="top" align="left" width="10%">
                        <!--Menu Start Here-->
                        <!--Menu Ends Here-->
                    </td>
                    <td valign="top" align="left" width="2%">
                        &nbsp;
                    </td>
                    <td valign="top" align="left" width="80%">
                        <div id="divStudentStatusDetails" runat="server">
                            <br>
                            <div runat="server" id="divTblElgFormdetails">
                                <table class="tblBackColor" id="TblElgFormdetails" cellspacing="1" cellpadding="3"
                                    width="100%" border="0">
                                    <tr class="clSubHeading">
                                        <td align="left" valign="top">
                                            <b>Student Details</b>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td style="height: 16px" valign="top" colspan="4">
                                            <b>Eligibility Form Number of the Student&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </b>
                                            <asp:Label ID="lblEligibilityFormNo" runat="server" Font-Bold="True" meta:resourcekey="lblEligibilityFormNoResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td style="height: 16px" valign="top" colspan="4">
                                            <b>
                                                <asp:Label ID="lblPRNStudent" runat="server" Text="PRN of the Student" meta:resourcekey="lblPRNStudentResource1"></asp:Label>
                                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </b>
                                            <asp:Label ID="lblPRN" runat="server" Font-Bold="True" meta:resourcekey="lblPRNResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br>
                            <table class="tblBackColor" id="TblAdmission" style="display: none" cellspacing="1"
                                cellpadding="3" width="100%" border="0" runat="server">
                                <tbody>
                                    <tr class="clSubHeading">
                                        <td style="height: 18px" colspan="4">
                                            <b>Admission&nbsp;Details of the Student</b>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td width="30%">
                                            <b>Admission Form Number :</b>
                                        </td>
                                        <td width="20%">
                                            <asp:Label ID="lblAppFormNo" runat="server" meta:resourcekey="lblAppFormNoResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <b>Admission Date :</b>
                                        </td>
                                        <td width="20%">
                                            <asp:Label ID="lblAdmissionDate" runat="server" meta:resourcekey="lblAdmissionDateResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td width="30%">
                                            <b>Seeking Admission in
                                                <%= lblCr.Text%>
                                                :</b>
                                        </td>
                                        <td width="70%" colspan="3">
                                            <asp:Label ID="lblCourse" runat="server" meta:resourcekey="lblCourseResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td width="30%">
                                            <b>
                                                <%=lblCollege.Text %>
                                                Name :</b>
                                        </td>
                                        <td width="80%" colspan="3">
                                            <asp:Label ID="lblInstName" runat="server" meta:resourcekey="lblInstNameResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <br>
                            <div id="divMatchingRecords" style="display: none" runat="server">
                                <asp:Label ID="lblGridName" runat="server" Height="18px" CssClass="GridHeadingM"
                                    Width="100%" Text="Other Course Eligibility Status" meta:resourcekey="lblGridNameResource1"></asp:Label><br>
                                <asp:GridView ID="DGMatchgCourseDetails1" runat="server" Width="100%" BorderStyle="Solid"
                                    PageSize="5" AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699"
                                    AllowPaging="True" meta:resourcekey="DGMatchgCourseDetails1Resource1">
                                    <RowStyle CssClass="gridItem" />
                                    <HeaderStyle CssClass="gridHeader" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                            <ItemTemplate>
                                                <%# (Container.DataItemIndex)+1 %>
                                            </ItemTemplate>
                                            <ItemStyle Width="3%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Course" HeaderText="Course" meta:resourcekey="BoundFieldResource1">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="InstituteName" HeaderText="College Name" meta:resourcekey="BoundFieldResource2">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EligibilityStatus" HeaderText="Eligibility Status" meta:resourcekey="BoundFieldResource3">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CourseStatus" HeaderText="Course Status" meta:resourcekey="BoundFieldResource4">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Reason" HeaderText="Reason" meta:resourcekey="BoundFieldResource5">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ElgFormNo" HeaderText="Eligibility Form Number" meta:resourcekey="BoundFieldResource6">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                    </PagerStyle>
                                </asp:GridView>
                            </div>
                        </div>
                        <div id="divStudentDetails" runat="server">
                            <br>
                            <asp:Label ID="lblProfileHeading" runat="server" Height="18px" CssClass="GridHeadingM"
                                Width="100%" meta:resourcekey="lblProfileHeadingResource1" Text=" Student's Profile"></asp:Label>
                            <table id="Table1" cellspacing="0" cellpadding="3" width="100%" border="0">
                                <tr>
                                    <td valign="top" width="80%">
                                        <table class="tblBackColor" id="Table2" cellspacing="1" cellpadding="3" width="100%"
                                            border="0">
                                            <tr class="clSubHeading">
                                                <td style="height: 16px" valign="top" colspan="4">
                                                    <b>Personal Details of the Student</b>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Name as appeared on Statement of Marks</b>
                                                </td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblNameAsMarksheet" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Full Name</b>
                                                </td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblNameOfStudent" runat="server" meta:resourcekey="lblNameOfStudentResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Father's Full Name</b>
                                                </td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblFathersName" runat="server" meta:resourcekey="lblFathersNameResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Mother's Maiden Name</b>
                                                </td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblMothersMaidenName" runat="server" meta:resourcekey="lblMothersMaidenNameResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont" id="trChangedName" style="display: none" runat="server">
                                                <td valign="top" width="30%">
                                                    <b>Previous&nbsp;Name</b>
                                                </td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblPreviousName" runat="server" meta:resourcekey="lblPreviousNameResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Date of Birth</b>
                                                </td>
                                                <td valign="top" width="30%">
                                                    <asp:Label ID="lblDOB" runat="server" meta:resourcekey="lblDOBResource1"></asp:Label>
                                                </td>
                                                <td valign="top" width="20%">
                                                    <b>Gender</b>
                                                </td>
                                                <td valign="top" width="20%">
                                                    <asp:Label ID="lblGender" runat="server" meta:resourcekey="lblGenderResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="20%">
                                                    <b>Nationality</b>
                                                </td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblNationality" runat="server" meta:resourcekey="lblNationalityResource1"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" width="20%">
                                        <table class="tblBackColor" id="Table3" cellspacing="1" cellpadding="3" width="100%"
                                            border="0">
                                            <tr class="clSubHeading">
                                                <td style="height: 16px" valign="top" align="center">
                                                    <b>Photograph</b>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" align="center">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="../images/Member.gif" AlternateText="Photograph"
                                                        meta:resourcekey="Image1Resource1"></asp:Image>
                                                </td>
                                            </tr>
                                            <tr class="clSubHeading">
                                                <td style="height: 16px" valign="top" align="center">
                                                    <b>Signature</b>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" align="center">
                                                    <asp:Image ID="Image2" runat="server" AlternateText="Signature" ToolTip="Signature"
                                                        meta:resourcekey="Image2Resource1"></asp:Image>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table class="tblBackColor" id="Table5" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tr class="clSubHeading">
                                    <td style="height: 16px" valign="top" colspan="4">
                                        <b>Reservation Details of the Student</b>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" width="20%">
                                        <b>State of Domicile</b>
                                    </td>
                                    <td valign="top" width="30%">
                                        <asp:Label ID="lblDomicileState" runat="server" meta:resourcekey="lblDomicileStateResource1"></asp:Label>
                                    </td>
                                    <td valign="top" width="20%">
                                        <b>Reservation Category</b>
                                    </td>
                                    <td valign="top" width="30%">
                                        <asp:Label ID="lblResvCategory" runat="server" meta:resourcekey="lblResvCategoryResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" width="20%">
                                        <b>Physically Challenged</b>
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblPhyChlngd" runat="server" meta:resourcekey="lblPhyChlngdResource1"></asp:Label>
                                    </td>
                                    <td valign="top" width="20%">
                                        <b>Admitted Category</b>
                                    </td>
                                    <td valign="top" width="30%">
                                        <asp:Label ID="lblAdmittedCategory" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top">
                                        <b>Social Reservation</b>
                                    </td>
                                    <td valign="top" colspan="3">
                                        <asp:Label ID="lblSocResv" runat="server" meta:resourcekey="lblSocResvResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br>
                            <table class="tblBackColor" cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tr class="clSubHeading">
                                    <td style="height: 16px" valign="top" colspan="4">
                                        <b>Guardian Details of the Student</b>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" width="30%">
                                        <b>Annual Income of the Guardian</b>
                                    </td>
                                    <td valign="top" width="20%">
                                        <asp:Label ID="lblGuardianincome" runat="server" meta:resourcekey="lblGuardianincomeResource1"></asp:Label>
                                    </td>
                                    <td valign="top" width="30%">
                                        <b>Occupation of the Guardian</b>
                                    </td>
                                    <td valign="top" width="20%">
                                        <asp:Label ID="lblGuardianOccupation" runat="server" meta:resourcekey="lblGuardianOccupationResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br>
                            <table class="tblBackColor" id="Table4" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tr class="clSubHeading">
                                    <td style="height: 16px" valign="top">
                                        <b>Educational Details&nbsp;of the Student</b>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td>
                                        <asp:GridView ID="DGQualification1" runat="server" Width="100%" AutoGenerateColumns="False"
                                            BorderWidth="1px" BorderColor="Gainsboro" meta:resourcekey="DGQualificationResource1">
                                            <RowStyle CssClass="gridItem" />
                                            <HeaderStyle CssClass="gridHeader" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                            <Columns>
                                                <asp:BoundField DataField="Qualification" HeaderText="Qualification" meta:resourcekey="BoundFieldResource10">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CollegeInstituteName" HeaderText="College" meta:resourcekey="BoundFieldResource11">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Body" HeaderText="University" meta:resourcekey="BoundFieldResource12">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Marks_Obtained" HeaderText="Marks" meta:resourcekey="BoundFieldResource13">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Marks_OutOf" HeaderText="Out of" meta:resourcekey="BoundFieldResource14">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DateOfPassing" HeaderText="Passing Date" meta:resourcekey="BoundFieldResource15">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <br>
                            <table class="tblBackColor" id="Tbl4" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tr class="clSubHeading">
                                    <td style="height: 16px" valign="top">
                                        <b>Documents Submitted by the Student</b>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" align="center" width="100%">
                                        <asp:GridView ID="DGSubmittedDocs1" runat="server" Width="90%" BorderStyle="Solid"
                                            PageSize="5" AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699"
                                            meta:resourcekey="DGSubmittedDocsResource1" OnRowDataBound="DGSubmittedDocs1_RowDataBound">
                                            <RowStyle CssClass="gridItem" />
                                            <HeaderStyle CssClass="gridHeader" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                                    <ItemTemplate>
                                                        <%# (Container.DataItemIndex)+1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DocCert_Desc" ReadOnly="True" HeaderText="Document Name"
                                                    meta:resourcekey="BoundFieldResource7">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField ReadOnly="True" HeaderText="Received By College" meta:resourcekey="BoundFieldResource8">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Received By University" meta:resourcekey="TemplateFieldResource2">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cbDocRecv" runat="server" onclick="fnDocRecv(this);" Enabled="False"
                                                            meta:resourcekey="cbDocRecvResource1"></asp:CheckBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Determine Validity " meta:resourcekey="TemplateFieldResource3">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rbValidDoc" runat="server" Text="Valid" GroupName="grpValidity"
                                                            Enabled="False" meta:resourcekey="rbValidDocResource1"></asp:RadioButton>
                                                        <asp:RadioButton ID="rbInvalidDoc" runat="server" Text="Invalid" GroupName="grpValidity"
                                                            Enabled="False" meta:resourcekey="rbInvalidDocResource1"></asp:RadioButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="pk_DocCert_ID" ReadOnly="True" HeaderText="Doc_ID" meta:resourcekey="BoundFieldResource9">
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                            </PagerStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <div>
                                <asp:Label ID="lblDoctext" CssClass="ErrorNote" runat="server" Visible="False" meta:resourcekey="lblDoctextResource1"></asp:Label></div>
                            <br>
                        </div>
                        <br>
                        <table id="Table9" cellspacing="0" cellpadding="5" align="center" border="0">
                            <tr>
                                <td>
                                    <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="butSubmit" meta:resourcekey="btnCloseResource1">
                                    </asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="FooterTop">
                        <font style="font-size: 1pt">&nbsp;</font>
                    </td>
                </tr>
            </tbody>
        </table>
        <input id="hidUniID" style="width: 24px; height: 22px" type="hidden" name="hidUniID"
            runat="server" />
        <input id="hidpkYear" style="width: 24px; height: 22px" type="hidden" name="hidpkYear"
            runat="server" />
        <input id="hidpkStudentID" style="width: 24px; height: 22px" type="hidden" name="hidpkStudentID"
            runat="server" />
        <input id="hidPRN" style="width: 24px; height: 22px" type="hidden" name="hidPRN"
            runat="server" />
        <input id="hidElgFormNo" style="width: 24px; height: 22px" type="hidden" name="hidElgFormNo"
            runat="server" />
        <input id="hidFacID" style="width: 24px; height: 22px" type="hidden" name="hidFacID"
            runat="server" />
        <input id="hidCrID" style="width: 24px; height: 22px" type="hidden" name="hidCrID"
            runat="server" />
        <input id="hidMoLrnID" style="width: 24px; height: 22px" type="hidden" name="hidMoLrnID"
            runat="server" />
        <input id="hidPtrnID" style="width: 24px; height: 22px" type="hidden" name="hidPtrnID"
            runat="server" />
        <input id="hidBrnID" style="width: 24px; height: 22px" type="hidden" name="hidBrnID"
            runat="server" />
        <input id="hidCrPrID" style="width: 24px; height: 22px" type="hidden" name="hidCrPrID"
            runat="server" />
        <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
        <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
    </div>
    </form>
</body>
</html>
