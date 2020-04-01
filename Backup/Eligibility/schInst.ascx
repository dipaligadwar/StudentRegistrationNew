<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="schInst.ascx.cs" Inherits="StudentRegistration.Eligibility.schInst" %>
<script language="javascript" src="../JS/header.js"></script>
<script language="javascript" src="../JS/footer.js"></script>
<script language="javascript" src="../JS/SPXMLHTTP.js"></script>
<script language="javascript" src="../JS/change.js"></script>
<script language="javascript" src="../JS/jsAjaxMethod.js"></script>
<script language="javascript" src="../JS/jscript_validations.js"></script>
<script language="javascript" src="ajax/common.ashx"></script>
<script language="javascript" src="ajax/Classes.clsAjaxMethods,StudentRegistration.ashx"></script>
        
<script language="javascript">
   function FillDistrictDD(val)
	{ 
	     FillDistrict('TbDistID',val,'District_ID',0);
	     document.getElementById("<%=hidStateID.ClientID%>").value = val;
	}
	function FillTalukaDD(val)
	{  
	     FillTaluka('TbTalID',val,'Tehsil_ID',0);
	     document.getElementById("<%=hidDistrictID.ClientID%>").value = val;
	}
    function setTaluka(val)
    { 
          //alert(val);
	      document.getElementById("<%=hidTehsilID.ClientID%>").value = val;
    }
    
</script>
<div align="center">
	<fieldset class="fieldSet" id="tblSelect" style="WIDTH: 559px; HEIGHT: 100px" runat=server><legend><strong>Search</strong></legend>
		<table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
			<tr>
				<td align="right" width="20%"><strong>Type</strong></td>
				<td align="center" width="1%"><b>:</b></td>
				<td width="79%"><asp:radiobuttonlist id="rdbtnInstType" runat="server" repeatlayout="Flow" repeatdirection="Horizontal"
						forecolor="Navy" font-bold="True"></asp:radiobuttonlist></td>
			</tr>
			<tr>
				<td align="right" width="20%"><b>Name</b></td>
				<td align="center" width="1%"><b>:</b></td>
				<td width="79%"><asp:textbox id="Inst_Name" runat="server" cssclass="inputbox" width="395px" maxlength="300"></asp:textbox></td>
			</tr>
			<tr>
				<td style="HEIGHT: 22px" align="right" width="20%"><b>State&nbsp; </b></td>
				<td style="HEIGHT: 22px" align="center" width="1%"><b>:</b></td>
				<td style="HEIGHT: 22px" width="79%"><b><asp:dropdownlist id="State_ID" runat="server" cssclass="selectbox" width="184px" onchange="FillDistrictDD(this.value);"></asp:dropdownlist></b></td>
			</tr>
			<tr>
				<td style="HEIGHT: 22px" align="right" width="20%"><b>District</b></td>
				<td style="HEIGHT: 22px" align="center" width="1%"><b>:</b></td>
				<td id="TbDistID" style="HEIGHT: 22px" width="79%"><asp:dropdownlist id="District_ID" runat="server" cssclass="selectbox" width="184px" onchange="FillTalukaDD(this.value);"></asp:dropdownlist></td>
			</tr>
			<tr>
				<td style="HEIGHT: 22px" align="right" width="20%"><b>Tahsil</b></td>
				<td style="HEIGHT: 22px" align="center" width="1%"><b>:</b></td>
				<td id="TbTalID" style="HEIGHT: 22px" width="79%"><asp:dropdownlist id="Tehsil_ID" runat="server" cssclass="selectbox" width="184px" onchange="setTaluka(this.value);"></asp:dropdownlist></td>
			</tr>
			<tr>
				<td align="center" colspan="3"><asp:button id="btnSearch" runat="server" cssclass="butSubmit" width="70px" height="18px" text="Search"
						borderstyle="Solid" borderwidth="1px"></asp:button></td>
			</tr>
			<tr>
				<td align="center" colspan="3">&nbsp;</td>
			</tr>
		</table>
	</fieldset>
</div>

<!-- Selection ends -->

<input id="hidInstID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidInstID"
runat="server"/> <input id="hidStateID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" value="0"
name="hidStateID" runat="server"/> <input id="hidDistrictID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" value="0"
name="hidDistrictID" runat="server"/> <input id="hidTehsilID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" value="0"
name="hidTehsilID" runat="server"/> <input id="hidUniID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidUniID"
runat="server"/>