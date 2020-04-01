<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="ELGV2_StudentAdditionalPapers.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_StudentAdditionalPapers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function CheckItem()//checks each item in the checkboxlist for checked or not 
        {
            if (document.getElementById('<%=rdPrevCoursePartList.ClientID%>')) {
                var options = document.getElementById('<%=rdPrevCoursePartList.ClientID%>').getElementsByTagName('input');
                var ischecked = false;

                for (i = 0; i < options.length; i++) {
                    var opt = options[i];

                    if (opt.type == "radio") {
                        if (opt.checked) {
                            ischecked = true;
                        }
                    }
                }
                if (ischecked) {
                    return true;
                }
                else {
                    showValidationSummary(options, "<li>Select atleast one <%=litCourse3.Text%>.");
                    return false;
                }
            }
        }

        function DeleteMsg(id) {
            var msg = 'Are you sure you want to remove selected Additional <%=litPp4.Text%>'
            ShowConfirm(id, msg);
            return false;
        }
              
    </script>
    <center>
        <table id="table1" border="0" style="width: 100%; border-collapse: collapse" bordercolor="#c0c0c0"
            cellpadding="2">
            <tr>
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" Text="Additional Paper Change"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="black"></asp:Label>
                    <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="True" Font-Size="Small"
                        Style="display: none"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <div style="width: 100%;">
            <div class="clRight">
                <asp:Label ID="lblNote" runat="server"></asp:Label>
            </div>
        </div>
        <div id="divStudentSearch" runat="server" style="width: 100%; display: none">
            <div align="right">
                <asp:Label ID="lblErrorMsg" runat="server" CssClass="errorNote" />
            </div>
            <div id="DivNoteMsg" runat="server" style="display: none;">
                <div style="width: 100%; background-color: #FFFACD; height: 30px; border: solid 1px #c0c0c0;
                    vertical-align: top">
                    <div style="float: left">
                        <asp:Image runat="server" ID="Image2" ImageUrl="~/Images/Info.jpg" />
                    </div>
                    <div style="float: left; padding: 5px">
                        This functionality is only for those student who takes Direct Admission.
                    </div>
                    <br />
                </div>
            </div>
            <table cellspacing="0" cellpadding="3" border="0" align="left" style="width: 100%;">
               
                <tr>
                    <td>
                        &nbsp
                    </td>
                </tr>
                <tr align="left" id="trElgFormNo" runat="server">
                    <td align="right" width="50%">
                        &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="tbElgFormNo" runat="server" Text="Enter Eligibility Form Number"></asp:Label>
                            :</b>&nbsp;
                    </td>
                    <td height="30" align="left">
                        <asp:TextBox ID="txtElgFormNo" runat="server" Font-Bold="True" Font-Size="Small"
                            Width="180px" onclick="this.value='';" CssClass="redbox"></asp:TextBox>
                    </td>
                </tr>
                <tr align="center" id="tr1" runat="server">
                    <td id="Td4" align="Center" colspan="2" runat="server">
                        &nbsp
                    </td>
                </tr>
                <tr align="center" id="trOr" runat="server">
                    <td id="Td1" align="Center" colspan="2" runat="server">
                        <b>OR</b>
                    </td>
                </tr>
                <tr align="center" id="tr2" runat="server">
                    <td id="Td5" align="Center" colspan="2" runat="server">
                        &nbsp
                    </td>
                </tr>
                <tr align="left" id="trPRN" runat="server">
                    <td id="Td2" align="right" width="50%" runat="server">
                        <strong>
                            <asp:Label ID="lblEnterPRN" runat="server" Text="Enter PRN :  "></asp:Label></strong>
                    </td>
                    <td id="Td3" height="30" align="left" runat="server">
                        &nbsp<asp:TextBox ID="txtPRN" runat="server" MaxLength="20" Font-Bold="True" Font-Size="Small"
                            Width="180px" onclick="this.value='';" CssClass="redbox"></asp:TextBox>
                    </td>
                </tr>
                <tr align="center" id="tr3" runat="server">
                    <td id="Td6" align="Center" colspan="2" runat="server">
                        &nbsp
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <br />
                        <asp:Button ID="btnSimpleSearch" Text="Search" runat="server" CssClass="butSubmit"
                            OnClick="btnSimpleSearch_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp
                    </td>
                </tr>
            </table>
            <div id="divDisplayData" runat="server" style="width: 100%; display: none">
                <asp:GridView runat="server" AutoGenerateColumns="False" ID="GV_SrchStud" Width="100%"
                    AllowSorting="True" OnRowCommand="divDisplayData_RowCommand" DataKeyNames="Student_Name"
                    CssClass="clGrid" EnableModelValidation="True">
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
                        <asp:BoundField DataField="Student_Name" HeaderText="Name of Student">
                            <HeaderStyle Width="30%" CssClass="gridHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PRN_Number" HeaderText="PRN">
                            <HeaderStyle Width="10%" CssClass="gridHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Course_Name" HeaderText="Course Part Term">
                            <HeaderStyle Width="20%" CssClass="gridHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="pk_Year">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="pk_Student_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Select Term">
                            <HeaderStyle Width="6%" CssClass="gridHeader" />
                            <ItemStyle HorizontalAlign="Center" ForeColor="Navy" CssClass="gridItem" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect" Text="Select" ForeColor="Blue" runat="server" CommandName="Select"
                                    CommandArgument='<%# Container.DisplayIndex %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                        <asp:BoundField DataField="fk_AcademicYear_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="pk_Inst_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="divselectPpmsg" runat="server" style="width: 100%; background-color: #FFFACD;
            border: solid 1px #c0c0c0; vertical-align: top; display: none; margin-bottom: 20px;">
            <div>
                <table width="100%" cellpadding="0" cellpadding="0">
                    <tr>
                        <td width="5%" colspan="4">
                            <asp:Image runat="server" ID="imginfo" ImageUrl="~/Images/Info.jpg" />
                        </td>
                        <td width="1%" valign="top">
                            1.
                        </td>
                        <td valign="top">
                            If you want to 'Add' or 'Remove' additional
                            <asp:Literal ID="litPp4" runat="server" EnableViewState="False" Text="Paper" />(s),
                            select the
                            <asp:Literal ID="litCourse1" runat="server" EnableViewState="False" Text="course" />
                            part term and click on 'Proceed'
                        </td>
                    </tr>
                    
                </table>
            </div>
        </div>
        <div id="chk_Papers" runat="server">
            <fieldset style="width: 80%;">
                <legend>Select the
                    <asp:Literal ID="litCourse3" runat="server" EnableViewState="False" Text="course" />
                    part term for which you want to add Additional
                    <asp:Literal ID="litPp" runat="server" EnableViewState="False" Text="Paper" />(s)</legend>
                <div style="padding-top: 8px">
                    <asp:RadioButtonList ID="rdPrevCoursePartList" runat="server">
                    </asp:RadioButtonList>
                    <br />
                </div>
            </fieldset>
            <br />
            <div id="divProceed" class="clButtonHolder" style="padding-top: 10px" align="center">
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                <asp:Button ID="btnProceed" runat="server" Text="Proceed" OnClientClick="return CheckItem()"
                    OnClick="btnProceed_Click" />
            </div>
        </div>
        <div id="divDisplayGrid" runat="server" style="width: 100%; margin-top: 20px">
            <div>
                <asp:Label ID="lblDisplayPreviousCourseName" Font-Bold="True" runat="server"></asp:Label>
            </div>
            <div style="margin-top: 5px">
                <asp:GridView runat="server" AutoGenerateColumns="False" ID="GV_DisplayAdditionalPaper"
                    Width="100%" AllowSorting="True" AllowPaging="True" PageSize="25" CssClass="clGrid"
                    EnableModelValidation="True">
                    <PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No.">
                            <HeaderStyle Width="3%" CssClass="gridHeader" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CourseName" HeaderText="Course">
                            <HeaderStyle Width="30%" CssClass="gridHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="AdditionalPaperName" HeaderText="Additional Paper(s)">
                            <HeaderStyle Width="30%" CssClass="gridHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Remove">
                            <HeaderStyle Width="13%" CssClass="gridHeader" />
                            <ItemStyle HorizontalAlign="Center" ForeColor="Navy" CssClass="gridItem" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRemove" runat="server" CommandName="Remove"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Prev_Fac_ID" HeaderText="Prev_Fac_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Prev_Cr_ID" HeaderText="Prev_Cr_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Prev_MoLrn_ID" HeaderText="Prev_MoLrn_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Prev_Ptrn_ID" HeaderText="Prev_Ptrn_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Prev_Brn_ID" HeaderText="Prev_Brn_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Prev_CrPr_Seq" HeaderText="Prev_CrPr_Seq">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Prev_CrPr_Details_ID" HeaderText="Prev_CrPr_Details_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Prev_CrPrCh_ID" HeaderText="Prev_CrPrCh_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Prev_CrPrCh_Seq" HeaderText="Prev_CrPrCh_Seq">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="pk_PpPpGrp_ID" HeaderText="pk_PpPpGrp_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IsPpHead" HeaderText="IsPpHead">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PaperHeadGrpID" HeaderText="PaperHeadGrpID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fk_PpHead_ID" HeaderText="fk_PpHead_ID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PaperID" HeaderText="PaperID">
                            <ItemStyle CssClass="off" />
                            <HeaderStyle CssClass="off" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="divDispAddPaper" runat="server" style="display: none;">
            <div id="dvNoteMsg" runat="server">
                <div style="width: 100%; background-color: #FFFACD; height: 30px; border: solid 1px #c0c0c0;
                    vertical-align: top">
                    <div style="float: left">
                        <asp:Image runat="server" ID="Image1" ImageUrl="~/Images/Info.jpg" />
                    </div>
                    <div style="float: left; padding: 5px">
                        Select additional
                        <asp:Literal ID="Literal1" runat="server" EnableViewState="False" Text="Paper" />
                        from following list.
                    </div>
                    <br />
                </div>
                <br />
                <asp:Label ID="lblCourseName" Font-Bold="True" runat="server"></asp:Label>
            </div>
            <br />
            <fieldset id="Fieldset1" runat="server">
                <div class="clLeft" align="left">
                    <asp:CheckBoxList runat="server" RepeatDirection="Horizontal" Width="100%" RepeatColumns="1"
                        ID="chkPaperList" Style="width: 600px;">
                    </asp:CheckBoxList>
                </div>
            </fieldset>
            <div class="clButtonHolder" style="padding-top: 10px" align="center">
            <asp:Button ID="btnBack1" runat="server" Text="Back" OnClick="btnBack1_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return CheckItem()"
                    OnClick="Save_Click" />
            </div>
            <br />
        </div>
        <div>
            <input id="hidAcademicYear_ID" runat="server" type="hidden" />
            <input id="hidInstName" runat="server" type="hidden" />
            <input id="hidInstCode" runat="server" type="hidden" />
            <input id="hidPRN" runat="server" type="hidden" />
            <input id="hidElgNo" runat="server" type="hidden" />
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
            <input id="hid_pk_Year" type="hidden" runat="server" />
            <input id="hid_pk_Student_ID" type="hidden" runat="server" />
            <input id="hid_Prev_pk_Fac_ID" type="hidden" runat="server" />
            <input id="hid_Prev_pk_Cr_ID" type="hidden" runat="server" />
            <input id="hid_Prev_pk_MoLrn_ID" type="hidden" runat="server" />
            <input id="hid_Prev_pk_Ptrn_ID" type="hidden" runat="server" />
            <input id="hid_Prev_pk_Brn_ID" type="hidden" runat="server" />
            <input id="hid_Prev_pk_CrPr_Details_ID" type="hidden" runat="server" />
            <input id="hid_Prev_CoursePartChild" type="hidden" runat="server" />
            <input id="hid_Prev_CoursePart_Opted" type="hidden" runat="server" />
            <input id="hid_Prev_CoursePart_Admission_Type" type="hidden" runat="server" />
            <input id="hid_Previous_PpGrpID" type="hidden" runat="server" />
            <input id="hid_SelectedAdditionalPpID" type="hidden" runat="server" />
            <input id="hid_SelectedAdditionalPpName" type="hidden" runat="server" />
            <input id="hid_Papers" type="hidden" runat="server" />
            <input id="hid_SelectedPapers" type="hidden" runat="server" />
            <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none"></asp:Label>
        </div>
    </center>
</asp:Content>
