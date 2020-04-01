<%@ Page Language="C#" MasterPageFile="~/Content.Master"  AutoEventWireup="true" CodeBehind="VerifyPRN.aspx.cs" Inherits="UserCredentials.VerifyPRN" %>

<%@ Register Assembly="Recaptcha" Namespace="Recaptcha" TagPrefix="recaptcha" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1"  ID="content1" runat="server">

<script language="javascript" type="text/javascript">

    function fnSaveValidate(ctrlToValidate)
    {
        var i=-1;
	    var myArr= new Array();	   
         var options = document.getElementById("<%=txtPRN.ClientID %>");
         if(document.getElementById("<%=txtPRN.ClientID %>").value=="")
         {
          showValidationSummary(options,"1. Enter valid <%=PRN.Text %>.");
          return false;
         }
        
        myArr[++i]= new Array(document.getElementById("<%=txtPRN.ClientID%>"),"NumericOnly","Enter valid <%=PRN.Text%>.","text");
        var ret=validateMe(myArr,50,ctrlToValidate);
        if (ret)
        {
            ret = ChkPRNNumber();
                if (ret == true)
                {
                    ret = true;
                }
            else
                {
                    var options = document.getElementById("<%=txtPRN.ClientID %>");
                    showValidationSummary(options,"1. <%=PRN.Text %> should be of 16 digit.");
                    ret = false;										
                }		
        }
        	       		
        return ret;
    } 
function ChkPRNNumber()
{		
	var ret = true;
	if (document.getElementById("<%=txtPRN.ClientID %>").value.length == 16)
	{
		ret = true;
	}
	else
	{
		ret = false;
	}
	
	return ret;	
}
       
 </script>
<div id="ControlHolder" style="width:700px"> 	
	<fieldset style="height: 380px">
	<legend align="left"><strong><font color="#666666" size="2">Student Login Activation</font></strong></legend>
	    <table width="85%">
	        <tr>
	            <td colspan="2" >                    
                    <br />
	                <asp:Label ID="lblValidate" runat="server" CssClass="errorNote" meta:resourcekey="lblValidateResource1"></asp:Label>
	                <br />
	            </td>
	        </tr>
	        <tr>    
	            <td align="left" colspan="2" >
                    <asp:Label ID="lblMessage" runat="server" Text="lblMessage" meta:resourcekey="lblMessageResource1"></asp:Label></td>
	        </tr>
	        <tr>
	            <td colspan="2"><br /></td>
	        </tr>
	        <tr id ="trPrn" runat ="server" style="display:none">
	            <td width="50%"  align="right" >
                  <asp:Label runat="server" Text="Permanent Registration Number (PRN)" ID="lblPRN" meta:resourcekey="lblPRNResource1"></asp:Label>:</td>
                <td align ="left" width="50%"><asp:TextBox ID="txtPRN" runat="server" MaxLength="16" CssClass="inputbox" AutoCompleteType="Disabled" meta:resourcekey="txtPRNResource1"></asp:TextBox><font class="Mandatory">* </font></td>
	        </tr>
	        <tr id ="trlink" runat ="server" style="display:none">
	            <td align="center" colspan="2"> &nbsp;<br /> </td>
	        </tr>	        
	        <tr>                            
                <td width="50%"  align="right">
                 </td>
                 <td align="left"> 
                    <div style="width:90%;vertical-align:middle;padding-left:2px;" align="left" >                                      
                                <asp:Label ID="lblerror"  runat="server" meta:resourcekey="lblerrorResource1"></asp:Label>
                     </div> 
                     <div style="width:57%;padding-top:4px;" align="left" >                               
                          <recaptcha:RecaptchaControl ID="RecaptchaControl1" runat="server" 
                          PublicKey="6LftTwgAAAAAAEBsQWcisVf1Y5_haXMeBYORwbcP"             
                          PrivateKey="6LftTwgAAAAAAG4Wu8Frb-br4gdGm73GM9eHPYKs"/>
                     </div> 
                </td>                                
            </tr>
	        <tr>
	            <td align="Center" colspan ="2" class="clButtonHolder">
                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" Width="78px" OnClientClick="return fnSaveValidate(this);" meta:resourcekey="btnNextResource1"/>&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" ValidationGroup="abc" OnClick="btnCancel_Click" Text="Cancel" meta:resourcekey="btnCancelResource1" /></td>
	        </tr>	
	        <tr>
	            <td colspan="2"><br /></td>
	        </tr>					        
	    </table>
</fieldset>
<div runat="server" id="divNote"><p style="MARGIN-TOP: 2px; MARGIN-BOTTOM: 10px; MARGIN-LEFT: 5px" align="left"><strong>Note:</strong><font class="Mandatory">*</font>
Marked fields are mandatory.</p></div> 
<input type="hidden" runat="server" id="hidPRN" />
<asp:Label runat="server" ID="PRN" Visible="false" meta:resourcekey="PRNResource2"></asp:Label>
</div>	
</asp:Content>
     
