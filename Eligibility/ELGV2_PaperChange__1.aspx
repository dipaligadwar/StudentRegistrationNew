<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ELGV2_PaperChange__1.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_PaperChange__1" meta:resourcekey="PageResource1" %>
     
<%@ Register Src="WebCtrl/SelectSingleCourse.ascx" TagName="YCMOU" TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" type="text/javascript" src="JS/ValidatePRN.js"></script>
    <center>
        <table id="table1" style="border-collapse: collapse" cellpadding="2" width="700"
            border="0">
            <tr> 
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1"
                        CssClass="lblPageHead"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                    <asp:Label ID="lblStudName" runat="server"  style="display:none;" Font-Size="Small" meta:resourcekey="lblStudNameResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <fieldset>
                        <legend>Single Student Search</legend>
                        <uc3:YCMOU ID="YCMOU" runat="server" />
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Label ID="lblMessage" runat="server" CssClass="errorNote" meta:resourcekey="lblMessageResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView runat="server" AutoGenerateColumns="False" ID="GV_SrchStud" Width="100%"
                        CssClass="clGrid" OnRowCommand="GV_SrchStud_RowCommand" OnRowDataBound="GV_SrchStud_RowDataBound"
                        Visible="False" EnableModelValidation="True" meta:resourcekey="GV_SrchStudResource1">
                        <Columns>
                            <asp:BoundField DataField="StudName" HeaderText="Student Name" meta:resourcekey="BoundFieldResource1">
                                <HeaderStyle Width="30%" CssClass="gridHeader"></HeaderStyle>
                                <ItemStyle Width="30%" CssClass="gridItem" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseName" HeaderText="Course Name" meta:resourcekey="BoundFieldResource2">
                                <HeaderStyle Width="55%" CssClass="gridHeader"></HeaderStyle>
                                <ItemStyle Width="55%" CssClass="gridItem" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Change Paper(s)" meta:resourcekey="TemplateFieldResource1">
                                <HeaderStyle Width="15%" CssClass="gridHeader" />
                                <ItemStyle Width="15%" ForeColor="Navy" CssClass="gridItem" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSelect" runat="server" CommandName="PaperChange" Text="Change Paper(s)"
                                        meta:resourcekey="lnkSelectResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:BoundField DataField="pk_Fac_ID" meta:resourcekey="BoundFieldResource3">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pk_Cr_ID" meta:resourcekey="BoundFieldResource4">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pk_MoLrn_ID" meta:resourcekey="BoundFieldResource5">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pk_Ptrn_ID" meta:resourcekey="BoundFieldResource6">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pk_Brn_ID" meta:resourcekey="BoundFieldResource7">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pk_CrPr_Details_ID" meta:resourcekey="BoundFieldResource8">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pk_CrPrCh_ID" meta:resourcekey="BoundFieldResource9">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CrPr_Seq" meta:resourcekey="BoundFieldResource10">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CrPrCh_Seq" meta:resourcekey="BoundFieldResource11">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                             <asp:BoundField DataField="AdmissionMode">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                             <asp:TemplateField HeaderText="Edit CET Details" >
                                <HeaderStyle Width="15%" CssClass="gridHeader" />
                                <ItemStyle Width="15%" ForeColor="Navy" CssClass="gridItem" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkCET" runat="server" CommandName="CetDetails" Text="Edit CET Details"
                                         />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>

            <tr id="TrNote" runat="server" visible="false">
                <td style="text-align: left">
                    <div style="margin-top: 10px">
                        <strong>Note: </strong>Paper Change is not allowed for the term inserted by System.</div>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <!--Main Ends-->
        <input id="hidUniID" runat="server" name="hidUniID" type="hidden" />
        <input id="hidInstID" runat="server" name="hidInstID" type="hidden" />
        <input id="hidInstName" runat="server" name="hidInstName" type="hidden" />
        <input id="hidInstCode" runat="server" name="hidInstCode" type="hidden" />
        <input id="hidStudentID" runat="server" name="hidpkStudentID" type="hidden" value="0" />
        <input id="hidStudentYear" runat="server" name="hidpkYear" type="hidden" value="0" />
        <input id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server" />
        <input id="hidCrPrSeq" type="hidden" name="hidElgFormNo" runat="server" />
        <input id="hidCrPrChSeq" type="hidden" name="hidElgFormNo" runat="server" />
        <input id="hidAcademicYear" type="hidden" name="hidElgFormNo" runat="server" />
        <input id="hidSearchType" type="hidden" name="hidSearchType" runat="server" />
        <input id="hidIsBlank" type="hidden" name="hidIsBlank" runat="server" />
        <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
        <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none"
            meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>
        <%--<asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>--%>
        <input id="Hidden1" style="width: 32px; height: 22px" type="hidden" size="1" name="hidUniID"
            runat="server" />
        <input id="hidFacID" runat="server" name="hidFacID" type="hidden" />
        <input id="hidCrID" runat="server" name="hidCrID" type="hidden" />
        <input id="hidMoLrnID" runat="server" name="hidMoLrnID" type="hidden" />
        <input id="hidPtrnID" runat="server" name="hidPtrnID" type="hidden" />
        <input id="hidBrnID" runat="server" name="hidBrnID" type="hidden" />
        <input id="hidCrPrDetailsID" runat="server" name="hidCrPrDetailsID" type="hidden" />
        <input id="hidCrPrChID" runat="server" name="hidCrPrChID" type="hidden" />
        <input id="hidCourseDetails" type="hidden" name="hidCourseDetails" runat="server" />
        <input id="hidCrName" runat="server" size="1" type="hidden" />
        <input id="hidCrPartName" runat="server" size="1" type="hidden" />
        <input id="hidCrPrChName" runat="server" size="1" type="hidden" />
        <input id="hidStudentName" runat="server" type="hidden" />
        <input id="hidPRN" runat="server" size="1" type="hidden" />
         <input id="hidAppFormNo" runat="server" size="1" type="hidden" />

        <input id="hidExamFormModifyReq" runat="server" size="1" type="hidden" />
        <asp:Label ID="lblPaper" runat="server" Text="Paper" Style="display: none" meta:resourcekey="lblPaperResource1"></asp:Label>
        
    </center>
</asp:Content>
