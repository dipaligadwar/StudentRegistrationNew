<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="ELGV2_ImportPRNFromExcel.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_ImportPRNFromExcel"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript">
        function fnBtnAYValidate() {

            var i = -1;
            var myArr = new Array();
            myArr[myArr.length] = new Array(document.getElementById("<%=ddlAcadYear.ClientID%>"), 0, "Please Select Academic Year", "select");

            var ret = validateMe(myArr, 50);
            if (ret == false)
                return false;
        }

        function ShowWindow(IDs) {
            var hidSourceTableName = '<%=hidSourceTableName.Value%>';
            var hidFlag = '<%=hidFlag.Value %>'
            var hidAcademicYearID = '<%=hidAcademicYearID.Value %>'
            // if (hidFlag != 1) {
            window.open("ImportSelectCntPRNList.aspx?IDs=" + IDs + "&hidSourceTableName=" + hidSourceTableName + "&hidAcademicYearID=" + hidAcademicYearID, "List", "menubar=0,resizable=0,scrollbars=1,status=0,titlebar=0,toolbar=0, Height=500px,Width=750px");
            return false;
            //}
        }
   

    </script>
    <style>
        .gridstyle
        {
            font-weight: bold;
            font-size: 12px;
            color: Red;
        }
    </style>
    <center>
        <table cellpadding="0" cellspacing="0" width="700" height="30px">
            <tr valign="top">
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" Text="Import PRN/Registration Number From Excel File"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="700" border="0">
            <tr valign="top">
                <td valign="top" align="center">
                    <asp:MultiView ID="mvImportFromExcel" runat="server" ActiveViewIndex="0">
                        <asp:View ID="vwSelection" runat="server">
                            <fieldset style="text-align: left">
                                <legend><strong>Academic Year Selection</strong></legend>
                                <div style="text-align: right">
                                    <asp:Label ID="lblCtrlMsg" runat="server"></asp:Label>
                                </div>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td align="right">
                                                <b>
                                                    <asp:Label runat="server" Text="Select Academic Year" Width="221px" ID="lblAcademicYr"
                                                        meta:resourcekey="lblAcademicYrResource1"></asp:Label>
                                                </b>
                                            </td>
                                            <td style="width: 1%; height: 20px" align="center">
                                                <b>&nbsp;:&nbsp;</b>
                                            </td>
                                            <td style="height: 20px" align="left" colspan="3">
                                                <asp:DropDownList ID="ddlAcadYear" Width="298px" runat="server" meta:resourcekey="ddlAcadYearResource1">
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">---- Select ----</asp:ListItem>
                                                </asp:DropDownList>
                                                <font class="Mandatory">*</font>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </fieldset>
                            &nbsp;&nbsp;
                            <table align="center">
                                <tr>
                                    <td style="text-align: center">
                                        <asp:Button ID="btnProceed" runat="server" Text="Proceed" OnClick="btnProceed_Click"
                                            CssClass="ButSp" OnClientClick="return fnBtnAYValidate();" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="vwImport" runat="server">
                            <div id="divUploadFile" align="center" runat="server">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td align="left" style="width: 100%">
                                                <b>
                                                    <asp:Label ID="lblGenerationSequence" runat="server"></asp:Label></b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 100%">
                                                <br />
                                                <fieldset style="height: 95px; width: 700px" class="styleFieldset">
                                                    <asp:Label ID="lblFileError" runat="server" EnableViewState="False" CssClass="errorNote"
                                                        Style="text-align: right" Width="100%"></asp:Label><br />
                                                    <br />
                                                    <asp:Label ID="lblAY" runat="server" CssClass="saveNote" Style="text-align: right"
                                                        Width="100%"></asp:Label><br />
                                                    <div id="divFileUplToHide" runat="server" style="width: 100%">
                                                        <asp:FileUpload ID="fileUploadExcel" runat="server" Font-Size="14px"></asp:FileUpload>
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btnUploadProceed" CssClass="ButSp" runat="server" Text="Proceed"
                                                            OnClick="btnUploadProceed_Click"></asp:Button>
                                                    </div>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <div id="divInfoHolder" style="text-align: left; padding-top: 0px; padding-bottom: 5px;
                                                    padding-left: 5px; width: 95%">
                                                    <table width="100%" border="0">
                                                        <tr>
                                                            <td style="vertical-align: top">
                                                                <b>Note: </b>
                                                                <div id="divContent" runat="server">
                                                                    <ul>
                                                                        <li>It should be of file format <strong>".xls" or ".xlsx"</strong></li>
                                                                        <li>Only <strong>Sheet1</strong> will be considered. </li>
                                                                        <li>The first row should not be blank and must contain the column heading.</li>
                                                                        <li>First column of the Excel sheet should be <strong>&quot;Eligibility_Form_Number&quot;</strong>&nbsp;
                                                                        </li>
                                                                        <li>Second column of the Excel sheet should be <strong>&quot;Registration_Number&quot;</strong>&nbsp;
                                                                        </li>
                                                                        <li>Third column of the Excel sheet should be <strong>&quot;Student_Name&quot;</strong>&nbsp;
                                                                        </li>
                                                                        <li>Fourth column of the Excel sheet should be <strong>&quot;Eligibility_Status with
                                                                            (E,P) values only&quot;</strong>&nbsp; </li>
                                                                        <li>Fifth column of the Excel sheet should be <strong>&quot;Eligibility_Remark </strong>
                                                                            &nbsp; </li>
                                                                    </ul>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" CssClass="errorNote"
                                                    Style="text-align: right" Width="100%"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <table style="width: 100%;" align="center" border="0" runat="server" id="tblDiscrepancyStats"
                                                    visible="false">
                                                    <tbody>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:GridView ID="oGvDetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                    CssClass="clGrid" OnRowDataBound="oGvDetails_RowDataBound">
                                                                    <FooterStyle Font-Bold="True" ForeColor="White"></FooterStyle>
                                                                    <RowStyle></RowStyle>
                                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="SubHeading">
                                                                    </EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Section" HeaderText="Section">
                                                                            <HeaderStyle Width="75%" VerticalAlign="Top"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <%--  <asp:BoundField DataField="NoOfRecords" HeaderText="No Of Records">
                                                                            <HeaderStyle Width="25%" VerticalAlign="Top"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:BoundField>--%>
                                                                        <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                                                            <HeaderStyle Width="25%" VerticalAlign="Top"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <HeaderTemplate>
                                                                                No Of Records</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div id="PopUpList" runat="server">
                                                                                    <%# Eval("NoOfRecords")%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="SrNo">
                                                                            <HeaderStyle CssClass="off"></HeaderStyle>
                                                                            <ItemStyle CssClass="off"></ItemStyle>
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" BackColor="#2461BF"
                                                                        ForeColor="White"></PagerStyle>
                                                                    <HeaderStyle Font-Bold="True" BorderStyle="None" CssClass="gridHeader"></HeaderStyle>
                                                                    <EditRowStyle BackColor="#2461BF"></EditRowStyle>
                                                                </asp:GridView>
                                                                <br />
                                                                <div id="divGrvMsg" runat="server" style="display: none; text-align: right">
                                                                    <asp:Label ID="lblGrvMsg" runat="server" CssClass="errorNote" Text="Please Correct above issues from grid marked in red."></asp:Label>
                                                                </div>
                                                                <br />
                                                                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Enabled="false" CssClass="ButSp"
                                                                    OnClick="btnConfirm_Click" />
                                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="ButSp" OnClick="btnCancel_Click" />
                                                            </td>
                                                        </tr>
                                                        <%--   <tr>
                                                            <td style="height: 16px" colspan="6">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>--%>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </asp:View>
                    </asp:MultiView>
                    <input id="hidAcademicYearID" runat="server" type="hidden" style="width: 43px; height: 11px"
                        size="1" />
                    <input id="hidSourceFileName" runat="server" type="hidden" style="width: 43px; height: 11px" />
                    <input id="hidSourceTableName" runat="server" type="hidden" style="width: 43px; height: 11px" />
                    <%--    
                    <input id="hidPageDescription" runat="server" type="hidden" style="width: 43px; height: 11px"
                        size="1" />
                    <input id="hidImportOption" runat="server" type="hidden" style="width: 43px; height: 11px"
                        size="1" />
                    
                    <input id="hidGenerationAllocationSeq" runat="server" type="hidden" style="width: 43px;
                        height: 11px" size="1" />--%>
                    <input id="hidFlag" runat="server" type="hidden" style="width: 43px; height: 11px"
                        size="1" />
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
