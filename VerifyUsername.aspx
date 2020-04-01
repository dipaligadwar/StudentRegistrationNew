<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyUsername.aspx.cs" Inherits="UserCredentials.VerifyUsername" %>
<%--    <title>Forgot Password</title>--%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1"  ID="content1" runat="server">
  <div id="ControlHolder" style="width:700px">
    					<fieldset><legend><strong><font color="#666666" size="2">Forgot Password..</font></strong></legend>
						    <table width="80%">
						        <tr>
						            <td colspan="2" align="right"><br /><asp:Label ID="lblValidate" runat="server" Visible="False" CssClass="errorNote"></asp:Label></td>
						        </tr>
						        <tr>    
						            <td align="left" colspan="2"><br />This process is meant for retrieving your Password. Answer few Questions to complete this process.</td>
						        </tr>
						        <tr>
						            <td colspan="2" ><br /><br /></td>
						        </tr>
						        <tr>
						            <td align="right" width="50%">Enter Your Username: &nbsp;</td>
						            <td align="left"><asp:TextBox ID="txtUsername" runat="server" CssClass="inputbox"></asp:TextBox><font class="Mandatory">*</font></td>
						            
						        </tr>
						        <tr>
						            <td colspan="2"><br /><br /></td>
						        </tr>
						        <tr>
						            <td align="Right">
                                        <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" Width="78px" CssClass="butSubmit" /></td>
						            <td align="Left">
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="78px" CssClass="butSubmit" /></td>
						            
						        </tr>
						        <tr>
		                            <td colspan="2"><br /></td>
		                        </tr>	
						    </table>
						    </fieldset>
						    <div align="left">
						       <p style="MARGIN-TOP: 2px; MARGIN-BOTTOM: 10px; MARGIN-LEFT: 5px" align="left"><strong>Note:</strong><font class="Mandatory">*</font>
	                            Marked fields are mandatory.</p>
						    </div>
				
        <input id="hidNavigation" type="hidden" runat="server" />
        <input id="hidUsername" type="hidden" runat="server" />
        <input id="hidPRN" type="hidden" runat="server" />
        <input id="hidPassword" type="hidden" runat="server" />
    </div>
    
    <script language="javascript">
        
        function ValidUsername()
        {
            var i=-1;
		    var myArr= new Array();	
		    var ret = false;
            var sUsername = document.form1.txtUsername.value;
            
            //myArr[++i]= new Array(document.getElementById("txtUsername"),'Alpha',"Username can only be alphabets.","text");
            myArr[++i]= new Array(document.getElementById("<%=txtUsername.ClientID%>"),'Empty',"Username cannot be blank.","text");
          
            var ret=validateMe(myArr,50); 
    	    
	        if(!ret)
            {             
                return false;   
            }          
        }
    
    </script>
</asp:Content>