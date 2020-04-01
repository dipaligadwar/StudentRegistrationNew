<%@ Control Language="c#" AutoEventWireup="false" Codebehind="UniversityCalender.ascx.cs" Inherits="UniversityPortal.UniversityCalender" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
<table cellpadding="0" cellspacing="0">
	<tr>
		<td width="265" style="HEIGHT: 4px">
			<IMG height="5" src="Images/box04_topstrip.gif" width="265" border="0"></td>
	</tr>
	<tr>
		<td class="downloadsHeaderTD" width="265" bgColor="#e9cfd9">&nbsp;:: University 
			Calender</td>
	</tr>
	<tr height="80">
		<td vAlign="top" width="265" bgColor="#f4e7ec">
			<asp:PlaceHolder id="plcTable" runat="server"></asp:PlaceHolder></td>
	</tr>
</table>
