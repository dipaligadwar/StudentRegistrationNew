<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="MatchingProfile__3.aspx.cs" Inherits="StudentRegistration.Eligibility.MatchingProfile__3" %>
<%@ Register Src="CourseProfile.ascx" TagName="CourseProfile" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script language="javascript" src="<%=Classes.clsGetSettings.SitePath%>jscript/jquery-latest.js"
        type="text/javascript"></script>
<style type="text/css">
.OFFGrid
{
    background-color:#FFFFFF;
    font-family: Verdana;
    font-size: 8pt;
    font-weight: normal;
    width:100%;
}
.OFFGrid TR
{
    background-color:#FFF;
}
.OFFGrid TR TH,OFFGrid TR TD
{
    padding:3px;
}
.OFFGrid TR TH
{
    font-weight:normal;
    background-color:#EBEBEB;
    width:195px;    
    vertical-align:top;
    border:solid 1px #dfdfdf;
    text-align:left;
}
.OFFGrid TR TD
{
    font-family: Verdana;
    font-size: 8pt;
    font-weight: normal;
    min-width:240px;
    width:240px;
    vertical-align:top;
    padding:3px;
    border:solid 1px #dfdfdf;
    background-color:#fff;
}
.subHeading
{
    padding:3px 3px 3px 5px;
    line-height:20px;
    font-size:11pt;
    font-family:Verdana;
    margin:0px 0px 0px 0px;
    letter-spacing:1px; 
    background-color: #EBEBEB;
    border: solid 1px #dfdfdf;  
    border-bottom-width:0px;
    width:98.5%;  
}
.tblContents
{
    width:100%;    
}
.cssImage
{
    padding:5px;
}
.tblSum
{
    background-color:#EFEFEF;
    font-family: Verdana;
    font-size: 8pt;
    font-weight: normal;
    text-align:left;
}
.tblSum TR TH
{
    font-family: Verdana;
    font-size: 9pt;
    font-weight: normal;
    vertical-align:top;
    width:150px; 
    padding:5px; 
    background-color:#E1E1E1;
}
.tblSum TR TD
{
    font-family: Verdana;
    font-size: 8pt;
    font-weight: normal;
    vertical-align:top;
    padding:5px;
}
.mergeProfiles
{
    width: 95%; padding: 15px; margin: 10px 0px 0px 0px;
    border-width: 1px; border-bottom: dashed 1px #c0c0c0; 
    border-top: dashed 1px #c0c0c0;
}
.mergeProfileBut
{
    border:solid 1px #808080;
    background-color:#EBEBEB;
    font-size:14pt;
    height:30px;
    color:#808080;
    font-family: Verdana;
}
.gridTitle
{
    color:#303030;
    font-family: Verdana;
    font-size:10pt;
    padding: 3px 3px 5px 1px;
    font-weight:bold;
}
#divNote
{
    height:35px;
    font-family: Verdana;
    font-size:12pt;
    padding: 5px 5px 5px 5px;
    font-weight:bold;
    background-color:#FFFACD;
    border: solid 1px #c0c0c0;
}

</style>
<center>
<table width="100%" border="0" cellpadding="1" cellspacing="1">
    <tr>
        <td align="left" style="border-bottom: 1px solid #FFD275;" colspan="2">
            <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1"></asp:Label>
            <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 100%;" colspan="2">
            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" meta:resourcekey="lblMsgResource1"></asp:Label>
        </td>
    </tr>
    <tr>
    <td align="left" style="width: 100%; padding: 5px 0px 5px 0px;font-family:Verdana;font-size:9pt;" colspan="2">
        <asp:Label runat="server" ID="lblMatCriteria" meta:resourcekey="lblMatCriteriaResource1"></asp:Label>
    </td>
</tr>
</table>
<br />
<%--<div id="divNote" align="left" style="width: 690px;"></div>--%>
<br />
<div id="divSummary" align="left" style="width: 700px;">
    <div align="left" class="tblContents">
        <asp:Table ID="TBLSummery" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0px" CssClass="OFFGrid" meta:resourcekey="TBLSummeryResource1">
            <asp:TableRow   runat="server">
                <asp:TableHeaderCell   runat="server" >
                    <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableCell>
                </asp:TableCell>
                <asp:TableCell>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow  runat="server">
                <asp:TableHeaderCell runat="server" >
                    <asp:Label ID="lblPRN" runat="server" Text="PRN" ></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableRow>
            <asp:TableRow  runat="server">
                <asp:TableHeaderCell  runat="server" Text="Student Name"></asp:TableHeaderCell>
            </asp:TableRow>
            <asp:TableRow  runat="server">
                <asp:TableHeaderCell  runat="server" Text="Photograph & Signature"></asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <br />
</div>
<br />
<div style="width:700px;text-align:center;">
    <div id="divGridRemoveTitle" align="left" runat="server" class="gridTitle" style="width:100%;">Terms to be removed</div>
    <asp:GridView ID="GVTermRemove" runat="server" AutoGenerateColumns="False" CssClass="clGrid" Width="100%" meta:resourcekey="GVTermRemoveResource1">
    <HeaderStyle CssClass="gridHeader"  />
    <Columns>
        <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
			<ItemStyle Width="8%" HorizontalAlign="Center" CssClass="gridItem" />
            <HeaderTemplate>Sr.No</HeaderTemplate>
            <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField 
            HeaderText="Course Part Term" DataField="CourseTerm" meta:resourcekey="BoundFieldResource1" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle CssClass="gridItem" HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
            <HeaderTemplate>To be Removed</HeaderTemplate>
            <ItemStyle Width="20%"  CssClass="gridItem" HorizontalAlign="Center"/>
            <ItemTemplate><img src="../images/tick_mark.jpg" runat="server" /></ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="CourseTermIDs" meta:resourcekey="BoundFieldResource2" >
            <HeaderStyle CssClass="off" />
            <ItemStyle CssClass="off" />
        </asp:BoundField>
    </Columns>
    </asp:GridView>
</div>
<br />
<div style="width:700px;text-align:center;">
    <div id="divGridRetainTitle" align="left" runat="server" class="gridTitle" style="width:100%;">Terms to be retained</div>
    <asp:GridView ID="GVTermRetain" runat="server" AutoGenerateColumns="False" CssClass="clGrid" Width="100%" meta:resourcekey="GVTermRetainResource1">
    <HeaderStyle CssClass="gridHeader"/>
    <Columns>
        <asp:TemplateField meta:resourcekey="TemplateFieldResource3">
			<ItemStyle Width="7%" CssClass="gridItem" HorizontalAlign="Center"/>
            <HeaderTemplate>Sr.No</HeaderTemplate>
            <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Course Part Term"
            DataField="CourseTerm" meta:resourcekey="BoundFieldResource3" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle CssClass="gridItem" HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:TemplateField meta:resourcekey="TemplateFieldResource4">
			<ItemStyle Width="20%" HorizontalAlign="Center" CssClass="gridItem" />
			<HeaderStyle Width="20%" />
            <HeaderTemplate>Select Action</HeaderTemplate>
            <ItemTemplate>
                <asp:RadioButtonList runat="server" RepeatColumns="2" ID="rblMergeRemove" meta:resourcekey="rblMergeRemoveResource1">
                    <asp:ListItem Selected="True" Text="Merge" Value="M" meta:resourcekey="ListItemResource1"></asp:ListItem>
                    <asp:ListItem Text="Remove" Value="R" meta:resourcekey="ListItemResource2"></asp:ListItem>
                </asp:RadioButtonList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="CourseTermIDs" meta:resourcekey="BoundFieldResource4" >
            <HeaderStyle CssClass="off" />
            <ItemStyle CssClass="off" />
        </asp:BoundField>
    </Columns>
    </asp:GridView>
</div>
<br />
<div class="mergeProfiles">
    <asp:Button ID="btnMerge" runat="server" Text="Confirm Merge Profile" CssClass="mergeProfileBut" 
    OnClientClick="return ValidateMerge();" OnClick="btnMerge_Click" meta:resourcekey="btnMergeResource1" />
</div>
<br />
</center>
<input type="hidden" runat="server" id="hid_BaseStudentIDs" />
<input type="hidden" runat="server" id="hid_MatchingCriteria" />
<input type="hidden" runat="server" id="hid_ProfileToBeMerged" />
<input type="hidden" runat="server" id="hid_Matching_Profile_ID" />
<input type="hidden" runat="server" id="hid_MergeFlag" />
<input type="hidden" runat="server" id="hid_MatchingStudentIDs" />
<input type="hidden" runat="server" id="hid_FromPage" />
<script type="text/javascript" language="javascript">
function ValidateMerge()
{
    var UniqueID = '<%=btnMerge.UniqueID%>';
    //ShowConfirm(UniqueID, "The Selected Student Profile will get merged with the Base Profile and will get deleted permanantly.<br\><br\>Are you sure you wish to finalize the merge of the profiles?");
    ShowConfirm(UniqueID, "Once a profile is deleted or merged, then deleted profile details will not be available anymore.<br\><br\>Are you sure you want to delete/merge the profile?");
    return false;
}

var baseNote='<font color="#006E12">This Profile will be retained ';
baseNote = baseNote + $("#<%=TBLSummery.ClientID%>").find("TR:first").find("TD:first").find("DIV").html() + '</font>';
var MergeNote='<font color="#FF0000">This Profile will be merged and removed ';
//if( $("#<%=TBLSummery.ClientID%>").find("TR:first").find("TD:first").next("TD").find("DIV").html() =="Not Available")
//{
//    MergeNote = MergeNote+"PRN " + $("#<%=TBLSummery.ClientID%>").find("TR:first").find("TD:first").next("TD").find("DIV").html() + '</font>';
//}
//else
//{
//    MergeNote = MergeNote + $("#<%=TBLSummery.ClientID%>").find("TR:first").find("TD:first").next("TD").find("DIV").html() + '</font>';
//}
$("#<%=TBLSummery.ClientID%>").find("TR:first").find("TD:first").find("DIV").html(baseNote);
$("#<%=TBLSummery.ClientID%>").find("TR:first").find("TD:first").next("TD").find("DIV").html(MergeNote);
//$("#TBLSummery.ClientID").html(baseNote + '<br/>' + MergeNote);
</script>
</asp:Content>
