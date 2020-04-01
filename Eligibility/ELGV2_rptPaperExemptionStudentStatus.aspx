<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_rptPaperExemptionStudentStatus.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_rptPaperExemptionStudentStatus" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<script language="javascript" type="text/javascript" src="JS/ValidatePRN.js"></script>
<script language="javascript" type="text/javascript" src="JS/Validations.js"></script>

<script type="text/javascript">

        //Validating eligibility form number.
		function ChkValidation()
		{		
		  var obPRN = document.getElementById("<%=txtPRN.ClientID%>").value;
		  var obElg = document.getElementById("<%= txtElgFormNo.ClientID%>").value;
		  var sStr = obElg.split('-');	
		  var ret=true;
		  var myArr=new Array();
		  var j=-1;
		  var innerRet=false;
		  document.getElementById("<%= hidSSVal.ClientID%>").value="1";
		  
		  if((obPRN.length == 0)&&(obElg.length==0))
		  {
		    document.getElementById("<%= hidSSVal.ClientID%>").value="";
		    
	          //myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter a valid Eligibility Form Number.","text");	        
	          myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Eligibility Form Number.","text");
	        		      
		  }
		  else if ((obPRN.length > 0) && (obElg.length > 0))
		  {
		  	  document.getElementById("<%= hidSSVal.ClientID%>").value="";
	          myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter either a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Eligibility Form Number.","text");
		      		  
		  }
		  
		 else if(obPRN.length>0)
	     {
	         innerRet = checkdigitPRN_Nomenclature(obPRN, document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText, document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value);
		 }
		 else if(obElg.length>0)
		 {  
		    innerRet = ChkEligFormNumber(obElg);		   
		 }
		 else
	     {		  	  
	          document.getElementById("<%= hidSSVal.ClientID%>").value="";
              myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter the Eligibility Form Number.","text");
	          
	     }
		  
		   ret=validateMe(myArr,50);
		   if(innerRet!=false)
		        return ret;
		   else
		        return innerRet;
		}
		
</script>

<asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
<DIV runat="server" ID="heading"><TABLE cellSpacing=0 cellPadding=3 width="100%" border=0><TBODY><TR><TD class="FormName" align=left width="100%"><asp:Label runat="server" Text="Paper Exemption Claim &amp; Approval Status" Font-Bold="True" ID="lblPageHead" meta:resourceKey="lblPageHeadResource1"></asp:Label>
 <asp:Label runat="server" Font-Bold="True" Font-Size="Small" ID="lblStudentName" meta:resourcekey="lblStudentNameResource1"></asp:Label>
 </TD></TR></TBODY></TABLE></DIV>
<DIV runat="server" ID="divSimpleSearch"><BR /><TABLE cellSpacing=0 cellPadding=3 width="100%" border=0><TBODY><TR align=left><TD align=right width="50%">&nbsp;&nbsp;&nbsp;&nbsp;<B><asp:Label runat="server" Text="Enter Eligibility Form Number: " ID="tbElgFormNo" meta:resourceKey="tbElgFormNoResource2"></asp:Label>
</B></TD><TD align=left height=30><asp:TextBox runat="server" Font-Bold="True" Font-Size="Small" ID="txtElgFormNo" onclick="this.value='';" meta:resourceKey="txtElgFormNoResource2"></asp:TextBox>
</TD></TR><tr runat="server" ID="trOr" align="center"><TD runat="server" ID="Td1" align="center" colspan="2"><B>OR</B> </TD>
</tr>
<tr runat="server" ID="trPRN" align="left"><TD runat="server" ID="Td2" align="right" width="50%"><STRONG><asp:Label runat="server" Text="Enter PRN: " ID="lblEnterPRN" meta:resourceKey="lblEnterPRNResource1"></asp:Label>
</STRONG></TD>
<TD runat="server" ID="Td3" align="left" height="30"><asp:TextBox runat="server" MaxLength="20" Font-Bold="True" Font-Size="Small" ID="txtPRN" onclick="this.value='';"></asp:TextBox>
</TD>
</tr>
<TR><TD align=center colSpan=2><BR /><asp:Button runat="server" OnClientClick="return ChkValidation()" Text="Search" CssClass="butSubmit" ID="btnSimpleSearch" meta:resourceKey="btnSimpleSearchResource1" OnClick="btnSimpleSearch_Click"></asp:Button>
 </TD></TR></TBODY></TABLE></DIV>
<BR /><DIV runat="server" ID="divStudentStatus" style="DISPLAY: none"></DIV>
<input runat="server" ID="hidSSVal" type="hidden" value="1"></input>
<input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
 <asp:Label runat="server" Text="College" ID="lblCollege" style="DISPLAY: none" meta:resourceKey="lblCollegeResource1"></asp:Label>
 <asp:Label runat="server" Text="PRN" ID="lblPRNNomenclature" style="DISPLAY: none" meta:resourceKey="lblPRNNomenclatureResource1"></asp:Label>
 <asp:Label runat="server" Text="Paper" ID="lblPaper" style="DISPLAY: none" meta:resourceKey="lblPaperResource1"></asp:Label>
 <asp:Label runat="server" Text="Course" ID="lblCourse" style="DISPLAY: none" meta:resourceKey="lblCourseResource1"></asp:Label>
 
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

    
     

