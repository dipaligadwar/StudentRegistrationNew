<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CollegeProfile.ascx.cs" Inherits="StudentRegistration.Eligibility.CollegeProfile" %>
<style type="text/css">
.ulCourse li
{
    padding:1px 1px 2px 8px;
    background:url(../Images/bullet02.gif);
    background-repeat:no-repeat;
    background-position:left 20%;
    list-style-type:none;
}
</style>
<div id="divCollegeProfile" runat="server">
<asp:Repeater runat="server" ID="RptCollege" OnItemDataBound="RptCollege_ItemDataBound">
    <HeaderTemplate>                  
        <div style="width: 235px; text-align: left;padding-bottom: 7px;" >
        <table align="center" cellpadding="1px" style="border-collapse: collapse; width: 235px;">
    </HeaderTemplate>
    <ItemTemplate>
         <tr id="separator" runat="server" height="6px" bgcolor="white">
            <td id="Td1" runat="server"></td>
        </tr>
        <tr id="trHeader" runat="server">
            <th id="Th1" style="border:solid 1px Gray;padding:1px;margin:1px;" runat="server">
                <b><%# DataBinder.Eval(Container.DataItem,"CollegeName") %></b>&nbsp;<br />
                Elg Form No: 
                <%# DataBinder.Eval(Container.DataItem, "EligibilityFormNo") %>
            </th>
        </tr>
        <tr >
            <td style="border:solid 1px Gray">
                <ul class="ulCourse"><%# DataBinder.Eval(Container.DataItem,"Course") %></ul>
            </td>
        </tr> 
    </ItemTemplate>    
    <FooterTemplate>           
        </table>        
        </div>
    </FooterTemplate>
</asp:Repeater>
</div>