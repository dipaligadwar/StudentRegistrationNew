<%@ Control Language="c#" AutoEventWireup="false" Codebehind="LeftCommonCtrl.ascx.cs" Inherits="UniversityPortal.Messaging.LeftCommonCtrl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="LeftSideRoleWiseUserMsgs" Src="LeftSideRoleWiseUserMsgs.ascx" %>
<Table width="100%">
	<tr>
		<td runat="server" id="LeftContent">
		</td>
	</tr>
	<tr>
		<td>
			<br>
			<uc1:LeftSideRoleWiseUserMsgs id="LeftSideRoleWiseUserMsgs1" runat="server"></uc1:LeftSideRoleWiseUserMsgs>
		</td>
	</tr>
</Table>
