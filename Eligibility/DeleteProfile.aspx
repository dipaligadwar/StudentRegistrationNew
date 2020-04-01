<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DeleteProfile.aspx.cs" Inherits="StudentRegistration.Eligibility.DeleteProfile" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style type="text/css">
.ulCourse li
{
    padding:1px 1px 2px 10px;
    background:url(../Images/bullet02.gif);
    background-repeat:no-repeat;
    background-position:left 40%;
    list-style-type:none;
}
</style>
<center>
    <table border="0" cellpadding="1" cellspacing="1" width="100%">
	    <tr>
		    <td align="left" colspan="2" style="border-bottom: 1px solid #FFD275;">
			    <asp:Label ID="lblPageHead" runat="server" 
                    meta:resourcekey="lblPageHeadResource1"></asp:Label>
			    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" 
                    meta:resourcekey="lblSubHeaderResource1"></asp:Label>
		    </td>
	    </tr>
	    <tr>
		    <td align="right" colspan="2" style="width: 100%;padding: 5px 0px 0px 0px;">
			    <asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsgResource1"></asp:Label>
		    </td>
	    </tr>	    
    </table>
    <br />
    <div align="left" style="padding:0px 0px 3px 2px;">
        <asp:Label ID="lblGridTitle" runat="server" Text="List of Dangling Students" 
            Font-Bold="True" meta:resourcekey="lblGridTitleResource1"></asp:Label>
    </div>
    <div align="left" style="width: 700px;">
        <asp:GridView ID="GV_DeleteProfile" runat="server" CssClass="clGrid" PageSize="25"
            AutoGenerateColumns="False" AllowPaging="True" Width="100%" rules="all" 
            onrowcommand="GV_DeleteProfile_RowCommand" 
            onrowdatabound="GV_DeleteProfile_RowDataBound" 
            onpageindexchanging="GV_DeleteProfile_PageIndexChanging" 
            EnableModelValidation="True" meta:resourcekey="GV_DeleteProfileResource1" >
            <PagerStyle HorizontalAlign="Right" />
            <Columns>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
                    <HeaderStyle Width="6%" CssClass="gridHeader" />
					<ItemStyle Width="6%" HorizontalAlign="Center" CssClass="gridItem" VerticalAlign="Top" />
                    <HeaderTemplate>Sr No.</HeaderTemplate>
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="PRN" DataField="PRN" 
                    meta:resourcekey="BoundFieldResource1" >
                    <ItemStyle Width="14%" CssClass="gridItem" HorizontalAlign="Center" VerticalAlign="Top" />
                    <HeaderStyle CssClass="gridHeader" Width="14%"/>
                </asp:BoundField>
                <asp:BoundField HeaderText="Student Name" DataField="Student_Name" 
                    meta:resourcekey="BoundFieldResource2" >
                    <ItemStyle Width="27%" CssClass="gridItem" VerticalAlign="Top"/>
                    <HeaderStyle CssClass="gridHeader" Width="27%"/>
                </asp:BoundField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource2" >
                    <HeaderStyle Width="24%" CssClass="gridHeader" />
					<ItemStyle Width="24%" HorizontalAlign="Center" CssClass="gridItem" VerticalAlign="Top" />
                    <HeaderTemplate>Cancelled Term/ Cancelled Date</HeaderTemplate>
                    <ItemTemplate>
                        <ul class="ulCourse"><%# DataBinder.Eval(Container.DataItem, "Cancelled_Term")%></ul>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:BoundField HeaderText="Cancelled Date" DataField="Cancelled_Date" >
                    <ItemStyle Width="9%" CssClass="gridItem" HorizontalAlign="Center"/>
                    <HeaderStyle CssClass="gridHeader" Width="9%"/>
                </asp:BoundField>--%>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource3" >
				    <HeaderStyle Width="10%" CssClass="gridHeader" HorizontalAlign="Center" />
					<ItemStyle Width="10%" HorizontalAlign="Center" ForeColor="Navy" CssClass="gridItem" />
                    <HeaderTemplate>Delete Profile</HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSelect" runat="server" 
                            CommandArgument='<%# Eval("Stud_ID") %>' CommandName="DeleteProfile" 
                        Text="Delete Profile" meta:resourcekey="lnkSelectResource1"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>  
            </Columns>
        </asp:GridView>
    </div>
    <div align="right" style="width: 700px;">
    <asp:LinkButton runat="server" ID="lnkViewFullList" Text="View Complete List.." 
            ForeColor="Navy" onclick="lnkViewFullList_Click" 
            meta:resourcekey="lnkViewFullListResource1"></asp:LinkButton></div>
</center>
<input id="hidUniID" type="hidden" name="hidUniID" runat="server"/>
<input id="hid_pindex" type="hidden" runat="server"/>
</asp:Content>
