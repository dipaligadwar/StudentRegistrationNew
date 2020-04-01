<%@ Page Language="c#" Codebehind="ELGV2_ResolvePending__1.aspx.cs" MasterPageFile="~/Home.Master"
    AutoEventWireup="True" Inherits="StudentRegistration.Eligibility.ELGV2_ResolvePending__1" %>

<%@ Register TagPrefix="uc1" TagName="StudentAdvanceSeachForConfigure" Src="WebCtrl/StudentAdvanceSeachForConfigure.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

    <script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>

    <script language="javascript">
		function fnSubmit(event)
		{
			if(event.keyCode == 13 || event.keyCode == 9)             //13 - enter key , 9- tab key
			{
				document.getElementById('ctl00_ContentPlaceHolder1_btnSimpleSearch').focus();	
				document.getElementById('ctl00_ContentPlaceHolder1_btnSimpleSearch').click();	
				
			}
			
		}	
		
		
		//Validating eligibility form number.
		function ChkValidation()
		{
		 var obElg = document.getElementById('ctl00_ContentPlaceHolder1_tbElgFormNo').value;
		
		 var sStr = obElg.split('-');
				 		 
		 var ret = true;
		 if(obElg.length > 0 )
		 {
		  ret = ChkEligFormNumber(obElg);
		  if(ret == true)
		  {
		    if(sStr[1] == document.getElementById('ctl00_ContentPlaceHolder1_hidInstID').value)
		    {
		        ret = true;
		    }
		    else
		    {
		    
		    alert(".:The Student is not in selected "+document.getElementById('lblCollege').innerText+":.\n Please Enter Correct Form No.");
		    ret = false;
		    }
		  }
		 }
		 else
		 {
		  alert("Please enter the Eligibility Form Number.");
		  ret = false;
		 }
		 return ret;
		}
    </script>

    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="0">
            <tr>
                <%--   <td class="FormName" align="left" valign="middle">
                    <asp:Label ID="lblPageHead" runat="server" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblInstName" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>--%>
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                    <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="True" Font-Size="Small"
                        meta:resourcekey="lblAcademicYearResource1"></asp:Label></td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <table cellspacing="0" cellpadding="0" border="0">
                        <tr style="height: 5px;">
                            <td>
                            </td>
                            <%--<tr>
                            <td style="height: 13px">
                                <asp:LinkButton ID="lnkSimpleSearch" CssClass="NavLink" runat="server" OnClick="lnkSimpleSearch_Click" meta:resourcekey="lnkSimpleSearchResource1">Simple Search</asp:LinkButton>&nbsp;|&nbsp;
                                <asp:LinkButton ID="lnkAdvSearch" CssClass="NavLink" runat="server" OnClick="lnkAdvSearch_Click" meta:resourcekey="lnkAdvSearchResource1">Advanced Search</asp:LinkButton>
                            </td>
                        </tr>--%>
                            <tr style="height: 10pt">
                                <td>
                                </td>
                            </tr>
                    </table>
                    <%--<div id="divSimpleSearch" runat="server">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr style="height:5px;"><td></td></tr>
                            <tr>
                                <td align="right" height="30">
                                    <strong>Enter&nbsp;Eligibility Form Number</strong></td>
                                <td align="center" width="2%" height="30">
                                    <b>:</b></td>
                                <td width="58%" height="30">
                                    <asp:TextBox ID="tbElgFormNo" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="tbElgFormNoResource1"></asp:TextBox>
                                    <font class="Mandatory">*</font></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <br>
                                    <asp:Button ID="btnSimpleSearch" CssClass="butSubmit" Text="Search" runat="server"
                                        OnClick="btnSimpleSearch_Click" meta:resourcekey="btnSimpleSearchResource1"></asp:Button>
                                </td>
                            </tr>
                            <div>
                                <tr id="divErrorMsg" runat="server">
                                    <td align="center" colspan="3">
                                        <br>                                        
                                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="errorNote" Visible="False" meta:resourcekey="lblErrorMsgResource1"></asp:Label></td>
                                </tr>
                            </div>
                        </table>
                    </div>--%>
                    <div id="divAdvSearch" runat="server">
                        &nbsp;
                        <uc1:StudentAdvanceSeachForConfigure ID="StudentAdvanceSeachForConfigure1" runat="server">
                        </uc1:StudentAdvanceSeachForConfigure>
                    </div>
                    <input id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server">
                    <input id="hidpkStudentID" type="hidden" name="hidpkStudentID" runat="server">
                    <!--				 
				<input id="hidCrMoLrnPtrnID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidCrMoLrnPtrnID" runat="server"> 
				-->
                    <input id="hidpkYear" type="hidden" name="hidpkYear" runat="server">
                    <!-- New Hidden Field added for CDV2 requirement -->
                    <input id="hidpkFacID" type="hidden" name="hidpkFacID" runat="server">
                    <input id="hidpkCrID" type="hidden" name="hidpkCrID" runat="server">
                    <input id="hidpkMoLrnID" type="hidden" name="hidpkMoLrnID" runat="server">
                    <input id="hidpkPtrnID" type="hidden" name="hidpkPtrnID" runat="server">
                    <input id="hidpkBrnID" type="hidden" name="hidpkBrnID" runat="server">
                    <input id="hidpkCrPrDetailsID" type="hidden" name="hidpkCrPrDetailsID" runat="server">
                    <input id="hidSearchType" type="hidden" name="hidSearchType" runat="server">
                    <input id="hidInstID" runat="server" name="hidInstID" type="hidden" />
                    <input id="hidUniID" runat="server" name="hidUniID" type="hidden" />
                    <input id="hid_fk_AcademicYr_ID" type="hidden" name="hid_fk_AcademicYr_ID" runat="server" />
                    <input id="hidAcademicYrText" type="hidden" name="hidAcademicYrText" runat="server" />
                    <input id="hidAppFormNo" type="hidden" value="0" name="hidAppFormNo" runat="server" />
                    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
                    <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none"
                        meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>
                    <input id="hidIsBlank" type="hidden" name="hidIsBlank" runat="server">
                    <input id="hidFacName" runat="server" type="hidden" />
                    <input id="hidCrName" runat="server" type="hidden" />
                    <input id="hidMOLName" runat="server" type="hidden" />
                    <input id="hidPattern" runat="server" type="hidden" />
                    <input id="hidBrName" runat="server" type="hidden" />
                    <input id="hidCrPrName" runat="server" type="hidden" />
                    <input id="hidAcYrName" runat="server" type="hidden" />
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
