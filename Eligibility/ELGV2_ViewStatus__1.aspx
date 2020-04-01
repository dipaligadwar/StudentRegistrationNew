<%@ Page Language="c#" MasterPageFile="~/Home.Master" Codebehind="ELGV2_ViewStatus__1.aspx.cs"
    AutoEventWireup="True" Inherits="StudentRegistration.Eligibility.ELGV2_ViewStatus__1"
     %>

<%@ Register TagPrefix="uc1" TagName="StudentsStatusSearch" Src="WebCtrl/StudentsStatusSearch.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" src="/JS/change.js"></script>

    <script language="javascript" src="JS/ValidatePRN.js"></script>
    <script language="javascript" src="JS/Validations.js"></script>

    <script language="javascript">
		function fnSubmit(event)
		{
			if(event.keyCode == 13 || event.keyCode == 9)             //13 - enter key , 9- tab key
			{
				document.getElementById('ctl00_ContentPlaceHolder1_btnSimpleSearch').focus();	
				document.getElementById('ctl00_ContentPlaceHolder1_btnSimpleSearch').click();	
				
			}
			
		}
		
		function fnDisplayDiv(divType)
		{
			if(divType == 'Simple')
			{
				document.getElementById('ctl00_ContentPlaceHolder1_divSimpleSearch').style.display = 'block';
				document.getElementById('ctl00_ContentPlaceHolder1_divAdvSearch').style.display = 'none';
				document.getElementById('ctl00_ContentPlaceHolder1_hidSearchType').value = divType;
				document.getElementById('ctl00_ContentPlaceHolder1_txtPRN').value = '';
				document.getElementById('ctl00_ContentPlaceHolder1_txtElgFormNo').value = '';
				document.getElementById('ctl00_ContentPlaceHolder1_tblDGRegPendingStudents').style.display = 'none';
				document.getElementById('ctl00_ContentPlaceHolder1_lblMsg').style.display = 'none';
			}
			else if(divType == 'Adv')
			{
				document.getElementById('ctl00_ContentPlaceHolder1_divSimpleSearch').style.display = 'none';
				document.getElementById('ctl00_ContentPlaceHolder1_divAdvSearch').style.display = 'block';
				document.getElementById('ctl00_ContentPlaceHolder1_hidSearchType').value = divType;
				document.getElementById('ctl00_ContentPlaceHolder1_txtPRN').value = '';
				document.getElementById('ctl00_ContentPlaceHolder1_txtElgFormNo').value = '';
				document.getElementById('ctl00_ContentPlaceHolder1_tblDGRegPendingStudents').style.display = 'none';
			}
		}
		
		//validation check during onclick of search button
		function ChkValidation()
		{ 									 
		  var obPRN = document.getElementById('ctl00_ContentPlaceHolder1_txtPRN').value;
		  var obElg = document.getElementById('ctl00_ContentPlaceHolder1_txtElgFormNo').value;
		  var sStr = obElg.split('-');	
		  var ret=true;
		  if((obPRN.length == 0)&&(obElg.length==0))
		  {
		  alert("Enter a valid "+document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText+" OR Eligibility Form Number.")
		  ret=false;
		  }
		  else if ((obPRN.length > 0) && (obElg.length > 0))
		  {
		  alert("Please Enter either a valid "+document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText+" OR Eligibility Form Number.")
		  ret=false;		  
		  }
		  
		  else
		  {
		 
		     if(obPRN.length>0)
		     {
				//ret = checkdigitPRN(obPRN);
		         ret = checkdigitPRN_Nomenclature(obPRN, document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText, document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value);
			 }
			 else
			 if(obElg.length>0)
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
		            alert("The Student is not in selected "+document.getElementById('lblCollege').innerText+":.\n Please Enter Correct Form No.");
		            ret = false;
		            }
		        }
			 }
			 else
		     {
		          alert("Please enter the Eligibility Form Number");
		          ret = false;
		     }
		  }
		   return ret;
		}
    </script>

    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="0">
            <tr>
                <%--<td class="FormName" align="left" valign="middle">
                    <asp:Label ID="lblTitle" runat="server" Font-Bold="True" CssClass="lblPageHead" meta:resourcekey="lblTitleResource1"></asp:Label>
                    <asp:Label ID="lblInstName" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="lblInstNameResource1"></asp:Label>--%>
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1"
                        CssClass="lblPageHead"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                    <asp:Label ID="lblStudName" runat="server" Font-Size="Small" meta:resourcekey="lblStudNameResource1"></asp:Label></td>
            </tr>
        </table>
        <br /><br />
        <uc1:StudentsStatusSearch ID="StudentsStatusSearch1" runat="server"></uc1:StudentsStatusSearch>
        <!--Main Ends-->
        <input id="hidUniID" runat="server" name="hidUniID" type="hidden" />
        <input id="hidInstID" runat="server" name="hidInstID" type="hidden" />
        <input id="hidpkStudentID" runat="server" name="hidpkStudentID" type="hidden" value="0" />
        <input id="hidpkYear" runat="server" name="hidpkYear" type="hidden" value="0" />
        <input id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server">
        <input id="hidSearchType" type="hidden" name="hidSearchType" runat="server">
        <input id="hidpkFacID" type="hidden" name="hidpkFacID" runat="server">
        <input id="hidpkCrID" type="hidden" name="hidpkCrID" runat="server">
        <input id="hidpkMoLrnID" type="hidden" name="hidpkMoLrnID" runat="server">
        <input id="hidpkPtrnID" type="hidden" name="hidpkPtrnID" runat="server">
        <input id="hidpkBrnID" type="hidden" name="hidpkBrnID" runat="server">
        <input id="hidpkCrPrDetailsID" type="hidden" name="hidpkCrPrDetailsID" runat="server">
        <input id="hidPRN" type="hidden" name="hidPRN" runat="server">
        <input id="hidIsBlank" type="hidden" name="hidIsBlank" runat="server">
        <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
        <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
        <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none"
            meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>
        <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
    </center>
</asp:Content>
