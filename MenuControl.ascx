<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MenuControl.ascx.cs" Inherits="UniversityPortal.MenuControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<div class='clLeftMenu' ID="LeftMenuHolder">
 <div class="clMenuHeader">
     <asp:label id="LBLGroupname" runat="server" width="100%"></asp:label>
 </div>
 <div>
     <asp:treeview id="TVMenu"  runat="server" collapseimagetooltip="Collapse Node" collapseimageurl="~/Images/parent-v.gif"
         cssclass="nodeStyle" expanddepth="0" expandimagetooltip="Expand Node" expandimageurl="~/Images/parent-h.gif"
         imageset="Custom" nodeindent="10" nodestyle-childnodespadding="0" noexpandimageurl="~/Images/light-H.gif"
         showexpandcollapse="true">
         <parentnodestyle cssclass="nodeStyle" font-bold="False" width="100px" />
         <hovernodestyle cssclass="nodeStyle" font-underline="True" />
         <selectednodestyle cssclass="nodeStyle" font-underline="True" horizontalpadding="0px"
             verticalpadding="0px" />
         <nodestyle childnodespadding="0px" cssclass="nodeStyle" font-names="Verdana" font-size="8pt"
             forecolor="Black" horizontalpadding="0px" nodespacing="0px" verticalpadding="0px" />
     </asp:treeview>
 </div>
</div>
