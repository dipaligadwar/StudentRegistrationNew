<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseProfile.ascx.cs" Inherits="StudentRegistration.Eligibility.CourseProfile" %>
<script type="text/javascript">
function DisplayNote(id)
{
    if(document.getElementById("<%=divCourseProfile.ClientID%>"))
    {
        id.style.display  = "inline";
    }
}
</script>
<div id="divCourseProfile" runat="server">
<asp:Repeater ID="RptCourse" runat="server" OnItemDataBound="RptCourse_ItemDataBound">
    <HeaderTemplate>                  
    <div style="width: 235px; text-align: left;padding-bottom: 7px;" >
    <table align="center" cellpadding="1px" style="border-collapse: collapse; width: 235px;">
    </HeaderTemplate>
   
    <ItemTemplate>
         <tr id="separator" runat="server" height="6px" bgcolor="white">
            <td id="Td1" colspan="4" runat="server"></td>
        </tr>
        <tr id="trHeader" runat="server">
            <th id="Th1" colspan="4" style="border:solid 1px Gray;" runat="server">
                <b><%# DataBinder.Eval(Container.DataItem,"CourseName") %></b>
            </th>
        </tr>
         <tr id="tdHeader" runat="server">
            <td id="Td2" style="border:solid 1px Gray" runat="server">Part/ Term</td>
            <td id="Td3" style="border:solid 1px Gray" runat="server">Admission Date</td>
            <td id="Td4" style="border:solid 1px Gray" runat="server">Exam Event</td>
            <td id="Td5" style="border:solid 1px Gray" runat="server">Result Status</td>
        </tr>       
        <tr >
            <td style="border:solid 1px Gray">
                <%# DataBinder.Eval(Container.DataItem,"CrName") %>
            </td>
            <td style="border:solid 1px Gray">
                <%# DataBinder.Eval(Container.DataItem,"AdmissionDate") %>
            </td>
            <td style="border:solid 1px Gray">
                <%# DataBinder.Eval(Container.DataItem, "ExamEvent") %>
            </td>
            <td style="border:solid 1px Gray">
                <%# DataBinder.Eval(Container.DataItem, "ResultStatus") %>
            </td>
        </tr> 
       
           
    </ItemTemplate>    
    <FooterTemplate>           
           </table>        
        </div>
    </FooterTemplate>
</asp:Repeater>
</div>