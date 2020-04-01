<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchInstitute.ascx.cs" Inherits="StudentRegistration.Eligibility.SearchInstitute" %>
<script language="javascript">
    function showGrid()
    {
        document.getElementById("tblGrid").style.display="inline";
    }
    
    
</script>

<script language="C#" runat="server">

    void ImageButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("BulkInsertForCollege.aspx?QS_ID=1");
    }
    
 </script>

<div align="center">
	<fieldset class="fieldSet" id="tblSelect" style="WIDTH: 559px; HEIGHT: 100px" align="absMiddle"
		runat="server"><legend><strong>Search</strong></legend>
		<table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
			<tr>
				<td align="right" width="20%"><strong>Type</strong></td>
				<td align="center" width="1%"><b>:</b></td>
				<td width="79%">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Text="AnyType" Selected=True></asp:ListItem>
                        <asp:ListItem Text="College"></asp:ListItem>
                        <asp:ListItem Text="Institute"></asp:ListItem>
                         <asp:ListItem Text="University Department"></asp:ListItem>
                    </asp:RadioButtonList></td>
			</tr>
			<tr>
				<td align="right" width="20%"><b><span id="lblName0">Name</span></b></td>
				<td align="center" width="1%"><b>:</b></td>
				<td width="79%"><asp:textbox id="Inst_Name" runat="server" cssclass="inputbox" width="395px" maxlength="300"></asp:textbox></td>
			</tr>
			<tr>
				<td style="HEIGHT: 17px" align="right" width="20%"><b>State&nbsp; </b>
				</td>
				<td style="HEIGHT: 17px" align="center" width="1%"><b>:</b></td>
				<td style="HEIGHT: 17px" width="79%"><b>
				    <asp:dropdownlist id="State_ID" runat="server" cssclass="selectbox" width="184px">
				        <asp:ListItem Value="0" Text="---Select---" Selected=True></asp:ListItem>
				        <asp:ListItem Value="0" Text="Maharashtra"></asp:ListItem>
				    </asp:dropdownlist></b>
			    </td>
			</tr>
			<tr>
				<td style="HEIGHT: 20px" align="right" width="20%"><b>District</b></td>
				<td style="HEIGHT: 20px" align="center" width="1%"><b>:</b></td>
				<td id="TbDistID" style="HEIGHT: 20px" width="79%">
				    <asp:dropdownlist id="District_ID" runat="server" cssclass="selectbox" width="184px">
				         <asp:ListItem Value="0" Text="---Select---" Selected=True></asp:ListItem>
				         <asp:ListItem Value="1" Text="Pune"></asp:ListItem>
				         <asp:ListItem Value="2" Text="Sangli"></asp:ListItem>
				         <asp:ListItem Value="3" Text="Kolhapur"></asp:ListItem>
				    </asp:dropdownlist>
				</td>
			</tr>
			<tr>
				<td style="HEIGHT: 26px" align="right" width="20%"><b>Tahsil</b></td>
				<td style="HEIGHT: 26px" align="center" width="1%"><b>:</b></td>
				<td id="TbTalID" style="HEIGHT: 26px" width="79%">
				    <asp:dropdownlist id="Tehsil_ID" runat="server" cssclass="selectbox" width="184px">
				         <asp:ListItem Value="0" Text="---Select---" Selected=True></asp:ListItem>
				         <asp:ListItem Value="0" Text="Miraj"></asp:ListItem>
				         <asp:ListItem Value="1" Text="Tasgaon"></asp:ListItem>
				    </asp:dropdownlist>
				</td>
			</tr>
			<tr>
				<td align="center" colspan="3">
                    <input id="btnSearch" class="butSubmit" type="button" value="Search" onclick="showGrid();"/>
                 </td>
            </tr>
			<tr>
				<td align="center" colspan="3">&nbsp;</td>
			</tr>
		</table>
	</fieldset>
</div>
<p></p>
<p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; MARGIN-LEFT: 0px" align="center"> 
<table width="90%" id="tblGrid" class="grid" border="0" style="border-collapse:collapse;display:none" cellpadding="0">
    <tr>
        <td width="5%" class="gridHeader">Select</td>
        <td width="60%" class="gridHeader">Name</td>
        <td class="gridHeader">Type</td>
    </tr>
    <tr>
        <td width="5%" align="center"><asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="../images/pencil.gif"  OnClick="ImageButton_Click"/></td>
        <td width="60%">Adivasi Research And Educational Institute, [Pune City,Pune]</td>
        <td>College</td>
    </tr>
    <tr>
        <td width="5%" align=center><asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="../images/pencil.gif"  OnClick="ImageButton_Click"/></td>
        <td width="60%">A.M.College Of Education (English Medium), [Malegaon,Nashik]</td>
        <td>College</td>
    </tr>
    <tr>
        <td width="5%" align=center><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="../images/pencil.gif"  OnClick="ImageButton_Click"/></td>
        <td width="60%">Abasaheb Garware College [Pune City,Pune]</td>
        <td>College</td>
    </tr>
    <tr>
        <td width="5%" align=center><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../images/pencil.gif"  OnClick="ImageButton_Click"/></td>
        <td width="60%">Abasaheb Garware College (Arts And Science) [Pune City,Pune]</td>
        <td>College</td>
    </tr>
    <tr>
        <td width="5%" align=center><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../images/pencil.gif"  OnClick="ImageButton_Click"/></td>
        <td width="60%">Academic Staff College, [Pune City,Pune]</td>
        <td>College</td>
    </tr>
    <tr>
        <td width="5%" align=center>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/pencil.gif"  OnClick="ImageButton_Click"/></td>
        <td width="60%">Adhyapak Mahavidyalaya [Pune City,Pune]</td>
        <td>College</td>
    </tr>
</table>
</p>