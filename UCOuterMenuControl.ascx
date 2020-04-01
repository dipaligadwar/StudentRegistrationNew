<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserCredentials.UCOuterMenuControl" %>
<%@ Register Src="UCInnerMenuControl.ascx" TagName="UCInnerMenuControl" TagPrefix="uc1" %>

<table id="table4" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="0"
	width="170" border="0">
	<tr>
		<td align="center" bgColor="#e7e2db" vAlign="top">	    	
          <uc1:UCInnerMenuControl id="mnuUniversity" runat="server"></uc1:UCInnerMenuControl></td>
	</tr>
	<tr>
		<td style="height: 8px"></td>
	</tr>
	<tr>
		<td vAlign="top">
            <uc1:UCInnerMenuControl id="mnuActivities" runat="server">
            </uc1:UCInnerMenuControl></td>
	</tr>
	<tr>
		<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
	</tr>
	<tr>
		<td vAlign="top">
            <uc1:UCInnerMenuControl id="mnuMedia" runat="server">
            </uc1:UCInnerMenuControl></td>
	</tr>
	<tr>
		<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
	</tr>	
	<tr>
		<td align="center" bgColor="#e7e2db" vAlign="top">
	    	
            <uc1:UCInnerMenuControl id="mnuIPRPublication" runat="server">
            </uc1:UCInnerMenuControl></td>
	</tr>
	<tr>
		<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
	</tr>	
	<tr>
		<td align="center" bgColor="#e7e2db" vAlign="top" style="height: 1px">	    	
            <uc1:UCInnerMenuControl id="mnuAcademics" runat="server">
            </uc1:UCInnerMenuControl></td>
	</tr>
	<tr>
		<td><IMG height="5" src="Images/spacer.gif" width="50" border="0"></td>
	</tr>							
</table>
