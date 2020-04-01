<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportSelectCntPRNList.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ImportSelectCntPRNList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Import PRN Student List</title>
    <link href="../CSS/UniPortal.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10px 5px 5px 5px; width: 100%">
        <asp:GridView ID="GVStudent" runat="server" Caption="List of Students" CellPadding="0"
            AutoGenerateColumns="False" Width="100%" CssClass="clGrid" CaptionAlign="Left"
            Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" meta:resourcekey="GVStudentResource1">
            <Columns>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                    <HeaderStyle Width="8%" CssClass="gridHeader" />
                    <ItemStyle Width="8%" CssClass="gridItem" />
                    <HeaderTemplate>
                        Sr.No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Eligibility_Form_Number" HeaderText="Eligibility Form Number"
                    ReadOnly="True" meta:resourcekey="BoundFieldResource1">
                    <ItemStyle CssClass="gridItem" Width="25%" />
                    <HeaderStyle CssClass="gridHeader" Width="25%" />
                </asp:BoundField>
                <asp:BoundField DataField="Registration_Number" HeaderText="Registraion Number" ReadOnly="True"
                    meta:resourcekey="BoundFieldResource2">
                    <ItemStyle CssClass="gridItem" Width="20%" />
                    <HeaderStyle CssClass="gridHeader" Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="Student_Name" HeaderText="Student Name" ReadOnly="True"
                    meta:resourcekey="BoundFieldResource3">
                    <ItemStyle CssClass="gridItem" HorizontalAlign="Center" />
                    <HeaderStyle CssClass="gridHeader" />
                </asp:BoundField>
                <asp:BoundField DataField="Eligibility_Status" HeaderText="Eligibilty Status" ReadOnly="True"
                    meta:resourcekey="BoundFieldResource4">
                    <ItemStyle CssClass="gridItem" Width="8%" HorizontalAlign="Center" />
                    <HeaderStyle CssClass="gridHeader" Width="8%" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
