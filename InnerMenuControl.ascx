<%@ Control Language="c#" AutoEventWireup="false" Codebehind="InnerMenuControl.ascx.cs" Inherits="UniversityPortal.InnerMenuControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<link href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
<script language="javascript" src="jscript/ypSlideOutMenusC.js"></script>
<table id="Table1">
	<tr id="trSubLink" runat="server">
		<td>
			<uc1:menucontrol id="UCSubLink" runat="server"></uc1:menucontrol></td>
	</tr>
	<tr  id="MNUUniversityHolder" runat="server">
		<td><uc1:menucontrol id="mnuUniversity" runat="server"></uc1:menucontrol></td>
	</tr>
	<tr id="MNUActivitiesHolder"  runat="server">
		<td><uc1:menucontrol id="mnuActivities" runat="server"></uc1:menucontrol></td>
	</tr>
		<tr id="MNUMediaHolder" runat="server">
		<td><uc1:menucontrol id="mnuMedia" runat="server"></uc1:menucontrol></td>
	</tr>
		<tr id="MNUIPRPublicationHolder" runat="server">
		<td><uc1:menucontrol id="mnuIPRPublication" runat="server"></uc1:menucontrol></td>
	</tr>
<tr id="MNUAcademicsHolder" runat="server">
		<td><uc1:menucontrol id="mnuAcademics" runat="server"></uc1:menucontrol></td>
	</tr>
</table>
