<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="StudentRegistrationPage1.aspx.cs" Inherits="StudentRegistration.Eligibility.StudentRegistrationPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function fnSubmitValidate() {
            var myArray = new Array();
            myArray[myArray.length] = new Array(document.getElementById("<%=txt.ClientID%>"), "Empty", "Textbox should not be empty.", "text");
            myArray[myArray.length] = new Array(document.getElementById("<%=ddl.ClientID%>"), "0", "Please Select " + document.getElementById('<%=lblFaculty.ClientID%>').innerText+".", "select");
            var ret = validateMe(myArray, 10);
            return ret;
            // showValidationSummary('', "<li>Enter Valid Allowance Value .");
            // showAlert('Put message here');
//            function fnConfirm(sUniqueID, flag) {
//                ShowConfirm(sUniqueID, 'Are you sure you want ' + flag + '?');
//                return false;
//            }
        }
    </script>
    <div id="mastercontentbox">
        <div align="left" class="masterheading" style="position: relative;">
            <asp:Label ID="lblPageHead" runat="server" Text="Page Header"></asp:Label>
            <asp:Label ID="lblSubHeader" runat="server" Text="Page Sub-Header"></asp:Label>
        </div>
        <br />
        <br />
        <fieldset>
            <legend>Legend Text</legend>
            <table cellspacing="5" cellpadding="2"  width="100%" border="0">
                <tbody>
                    <tr>
                        <td align="right">
                            <asp:Label runat="server" Width="221px" Text="Select Institute" ID="lblDdl" Font-Bold="true"></asp:Label>
                        </td>
                        <td style="width: 1%; height: 20px" align="center">
                            <b>&nbsp;:&nbsp;</b>
                        </td>
                        <td style="height: 20px" align="left">
                            <asp:DropDownList runat="server" CssClass="selectbox" Width="298px" ID="ddl">
                                <asp:ListItem Text="--- Select ---" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <font class="Mandatory">*</font>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label runat="server" Text="Part Or Term" ID="lblRbl" Font-Bold="true"></asp:Label>
                        </td>
                        <td style="width: 1%; height: 20px" align="center">
                            <b>&nbsp;:&nbsp;</b>
                        </td>
                        <td align="left">
                           <asp:RadioButtonList ID="rbl" runat="server" 
                                    RepeatDirection="Horizontal" 
                                    RepeatLayout="Flow" 
                                    OnSelectedIndexChanged="rblResultConsideration_SelectedIndexChanged">
                                    <asp:ListItem Text="Yes" Value="1" Selected="True" />
                                    <asp:ListItem Text="No" Value="2" />
                                </asp:RadioButtonList>
                                <font class="Mandatory">*</font>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label runat="server" Text="TextBox" ID="lblTxt" Font-Bold="true"></asp:Label>
                        </td>
                        <td style="width: 1%; height: 20px" align="center">
                            <b>&nbsp;:&nbsp;</b>
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt" MaxLength="10" />  
                                <font class="Mandatory">*</font>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="height: 16px; padding-top: 10px;" colspan="3">
                            <asp:Button Text="Submit" ID="btnSubmit" OnClientClick="return fnSubmitValidate();" runat="server" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <div>
                <asp:Label ID="lblErrorMessage" Visible="False" CssClass="errorNote" runat="server" meta:resourcekey="lblErrorMsgResource1" />
            </div>
        </fieldset>
    </div>

    <table width="100%" id="TBLGridHolder">
        <tr>
            <td colspan="3">
                <asp:GridView ID="oGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="FacID,CrID,MoLrnID,PtrnID,BrnID,CrPrDetailsID,CrPrChID,Registration_ID,Application_ID"
                    Width="100%" CssClass="clGrid" OnRowCommand="oGridView_OnRowCommand" AllowPaging="True"
                    PageSize="25" OnPageIndexChanging="oGridView_PageIndexChanging" OnRowDataBound="oGridView_RowDataBound" EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.No." >
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Registration ID" DataField="Registration_ID">
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="gridItem" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Application ID" DataField="Application_ID">
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="gridItem" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Student Name" DataField="Student_Name">
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="gridItem" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Old Branch" DataField="Old_Branch">
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="gridItem" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Current Branch" DataField="New_Branch">
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="gridItem" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Edit" >
                            <ItemStyle HorizontalAlign="Left" Width="7%" VerticalAlign="Top" CssClass="gridItem" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CommandArgument="<%# Container.DataItemIndex %>"
                                    Text='Edit'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" >
                            <ItemStyle HorizontalAlign="Left" Width="7%" VerticalAlign="Top" CssClass="gridItem" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCourseName" runat="server" CommandName="DeleteCourse" CommandArgument="<%# Container.DataItemIndex %>"
                                    Text='Delete'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" />
                    <HeaderStyle CssClass="gridHeader" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblFaculty" runat="server"  Style="display: none" Text="Faculty"></asp:Label>
                <asp:Label ID="lblCourse" runat="server" Style="display: none" Text="Course"></asp:Label>
                
</asp:Content>
