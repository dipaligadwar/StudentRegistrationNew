<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_ManualProcess_reg_Students__1.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_ManualProcess_reg_Students__1"
     %>

<%@ Register TagPrefix="uc1" TagName="StudentAdvancedSearchforManualProcess_reg_Students"
    Src="WebCtrl/StudentAdvancedSearchforManualProcess_reg_Students.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>
    <script language="javascript" type="text/javascript" src="JS/ValidatePRN.js"></script>
    <script language="javascript" type="text/javascript" src="JS/Validations.js"></script>

    <script language="javascript" type="text/javascript">
		
		function fnSubmit(event)
		{
			if(event.keyCode == 13 || event.keyCode == 9)             //13 - enter key , 9- tab key
			{
				document.getElementById('btnSimpleSearch').focus();	
				document.getElementById('btnSimpleSearch').click();	
				
			}
			
		}		
		
		//Validating eligibility form number.
		function ChkValidation()
		{

        var IsPRNValidationRequired= "";

		
		  var obElg = document.getElementById("ctl00_ContentPlaceHolder1_txtElgFormNo").value;
          
		  var sStr = obElg.split('-');	
		  var ret=true;
		  if((obPRN.length == 0)&&(obElg.length==0))
		  {
		      alert("Enter a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText+" or Eligibility Form Number.")
		      ret=false;
		  }
		   else if ((obPRN.length > 0) && (obElg.length > 0))
		  {
		      alert("Please Enter either a Valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText+" OR Eligibility Form Number.")
		      ret=false;		  
		  }
		  
		  else
		  {
		 
		     if(obPRN.length>0)
		     {
				ret = checkdigitPRN(obPRN,document.getElementById('<%=hidIsPRNValidationRequired.ClientID%>').value);
			 }
			 else
			 if(obElg.length>0)
			 {  
			    ret = ChkEligFormNumber(obElg);
			    if(ret == true)
		        {
		            if(sStr[1] == document.getElementById("ctl00_ContentPlaceHolder1_hidInstID").value)
		            {
		            ret = true;
		            }
		            else
		            {
		            alert(".:The Student is not in selected "+document.getElementById('<%= lblCollege.ClientID%>').innerText+":.\n Please Enter Correct Form No.");
		            ret = false;
		            }
		        }
			 }
			 else
		     {
		          alert("Please enter the Eligibility Form Number.");
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
                    <asp:Label ID="lblTitle" runat="server" CssClass="lblPageHead" Font-Bold="True" meta:resourcekey="lblTitleResource1"></asp:Label>
                    <asp:Label ID="lblInstName" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="lblInstNameResource1"></asp:Label>--%>
                    
                    <td align="left" style="border-bottom: 1px solid #FFD275;">
                        <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1" ></asp:Label>
                        <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                    <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="lblAcademicYearResource1"></asp:Label></td>
            </tr>
            
    <!--        
    
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblPaidList" runat="server" CssClass="lblPageHead" meta:resourcekey="lblPaidListResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td id="TDLink" style="display: none" runat="server">
                </td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <p>
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tr style="height:10px;"><td></td></tr>
                            <tr>
                                <td colspan="4">
                                    <asp:LinkButton ID="lnkSimpleSearch" CssClass="NavLink" runat="server" OnClick="lnkSimpleSearch_Click" meta:resourcekey="lnkSimpleSearchResource1">Simple Search</asp:LinkButton>&nbsp;|&nbsp;
                                    <asp:LinkButton ID="lnkAdvSearch" CssClass="NavLink" runat="server" OnClick="lnkAdvSearch_Click" meta:resourcekey="lnkAdvSearchResource1">Advanced Search</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 13px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <div id="divSimpleSearch" runat="server">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td align="right" width="30%" style="height: 30px">
                                        <strong><asp:Label ID="lblEnterPRN" runat="server" Text="Enter PRN" meta:resourcekey="lblEnterPRNResource1"></asp:Label></strong></td>
                                    <td align="center" width="2%" style="height: 30px">
                                        <b>:</b></td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtPRN" runat="server" Font-Bold="True" Font-Size="Small" MaxLength="20"
                                            meta:resourcekey="txtPRNResource1"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <b>OR</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" height="30" widht="30%">
                                        <strong>Enter Eligibility Form Number</strong></td>
                                    <td align="center" width="2%" height="30">
                                        <b>:</b></td>
                                    <td height="30">
                                        <asp:TextBox ID="txtElgFormNo" runat="server" Font-Bold="True" Font-Size="Small"
                                            meta:resourcekey="txtElgFormNoResource1"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" height="30" widht="30%">
                                        <strong>Display Student</strong></td>
                                    <td align="center" width="1%" height="30">
                                        <b>:</b></td>
                                    <td colspan="1">
                                        <asp:RadioButton ID="rbWithInv" Text="Considering only those students whose payment is received and confirmed for Eligibility processing"
                                            Checked="True" GroupName="grpInvoice" runat="server" meta:resourcekey="rbWithInvResource1" />
                                        <br />
                                        <asp:RadioButton ID="rbWithoutInv" Text="Do not consider payment status for Eligibility processing"
                                            GroupName="grpInvoice" runat="server" meta:resourcekey="rbWithoutInvResource1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 15px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:Button ID="btnSimpleSearch" CssClass="butSubmit" Width="66px" Height="22px"
                                            Text="Search" runat="server" OnClick="btnSimpleSearch_Click" meta:resourcekey="btnSimpleSearchResource1">
                                        </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 15px">
                                    </td>
                                </tr>
                                <tr id="Tr1" runat="server">
                                    <td style="height: 30; width: 100%" align="center" colspan="3">
                                        <table id="tblDGRegPendingStudents" style="display: none" width="100%" runat="server">
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="lblGrid" CssClass="divDGNote" meta:resourcekey="lblGridResource1"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="dgRegStudents1" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="#336699" AutoGenerateColumns="False" OnRowCommand="dgRegStudents1_RowCommand"
                                                        OnRowDataBound="dgRegStudents1_RowDataBound" meta:resourcekey="dgRegStudents1Resource1">
                                                        <RowStyle CssClass="gridItem"></RowStyle>
                                                        <HeaderStyle CssClass="gridHeader" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                                                <ItemTemplate>
                                                                    <%# (Container.DataItemIndex)+1 %>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Eligibility_Form_No" ReadOnly="True" HeaderText="Eligibility Form No"
                                                                meta:resourcekey="BoundFieldResource1">
                                                                <ItemStyle HorizontalAlign="Center" Width="18%"></ItemStyle>
                                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:ButtonField Text="Button" DataTextField="StudentName" HeaderText="Student Name"
                                                                CommandName="StudentDetails" meta:resourcekey="ButtonFieldResource1">
                                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                                <ItemStyle Width="27%" />
                                                            </asp:ButtonField>
                                                            <asp:BoundField HeaderText="PRN Number" DataField="PRN" meta:resourcekey="BoundFieldResource2">
                                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="InstituteName" ReadOnly="True" HeaderText="College Name"
                                                                meta:resourcekey="BoundFieldResource3">
                                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CourseName" ReadOnly="True" HeaderText="Course Admitted To"
                                                                meta:resourcekey="BoundFieldResource4">
                                                                <ItemStyle HorizontalAlign="Left" Width="35%" />
                                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DocCount" HeaderText="No of Documents Submitted" meta:resourcekey="BoundFieldResource5">
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pkYear" ReadOnly="True" HeaderText="pkYear" meta:resourcekey="BoundFieldResource6">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pkStudentID" ReadOnly="True" HeaderText="pkStudentID"
                                                                meta:resourcekey="BoundFieldResource7"></asp:BoundField>
                                                            <asp:BoundField DataField="pkFacID" ReadOnly="True" HeaderText="pkFacID" meta:resourcekey="BoundFieldResource8">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pkCrID" HeaderText="pkCrID" meta:resourcekey="BoundFieldResource9">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pkMoLrnID" HeaderText="pkMoLrnID" meta:resourcekey="BoundFieldResource10">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pkPtrnID" HeaderText="pkPtrnID" meta:resourcekey="BoundFieldResource11">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pkBrnID" HeaderText="pkBrnID" meta:resourcekey="BoundFieldResource12">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pkCrPrDetails" HeaderText="pkCrPrDetailsID" meta:resourcekey="BoundFieldResource13">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="fkAcademicYearID" HeaderText="fkAcademicYearID"></asp:BoundField>
                                                        </Columns>
                                                        <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                                        </PagerStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <div>
                                </div>
                                <tr id="divErrorMsg" runat="server" style="display: none;">
                                    <td align="center" colspan="3">
                                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="errorNote" Visible="False"
                                            Style="display: none;" meta:resourcekey="lblErrorMsgResource1"></asp:Label></td>
                                </tr>
                            </table>
                        </div>
               -->
               
               
               </table>
                        <div id="divAdvSearch" runat="server" >
                            &nbsp;
                            <uc1:StudentAdvancedSearchforManualProcess_reg_Students ID="StudentAdvancedSearchforManualProcess1"
                                runat="server" OnLoad="StudentAdvancedSearchforManualProcess1_Load">
                            </uc1:StudentAdvancedSearchforManualProcess_reg_Students>
                        </div>
                        <input id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server" />
                        <input id="hidSearchType" type="hidden" name="hidSearchType" runat="server" />
                        <input id="hidInstID" runat="server" name="hidInstID" style="width: 24px; height: 22px"
                            type="hidden" />
                        <input id="hidUniID" runat="server" name="hidUniID" style="width: 24px; height: 22px"
                            type="hidden" />
                        <input id="hidpkStudentID" runat="server" name="hidpkStudentID" type="hidden" value="0" />
                        <input id="hidpkYear" runat="server" name="hidpkYear" type="hidden" value="0" />
                        <input id="hidPRN" type="hidden" name="hidPRN" runat="server" />
                        <input id="hidpkFacID" type="hidden" name="hidpkFacID" runat="server" />
                        <input id="hidpkCrID" type="hidden" name="hidpkCrID" runat="server" />
                        <input id="hidpkMoLrnID" type="hidden" name="hidpkMoLrnID" runat="server" />
                        <input id="hidpkPtrnID" type="hidden" name="hidpkPtrnID" runat="server" />
                        <input id="hidpkBrnID" type="hidden" name="hidpkBrnID" runat="server" />
                        <input id="hidpkCrPrDetailsID" type="hidden" name="hidpkCrPrDetailsID" runat="server" />
                        <input id="hidElgStatusColl" type="hidden" name="hidElgStatusColl" runat="server" />
                        <input id="hidCollElgFlag" type="hidden" name="hidCollElgFlag" runat="server" />
                        <input id="hidCollElgFlagReason" type="hidden" name="hidCollElgFlagReason" runat="server" />
                        <input id="hidElgStatusUni" type="hidden" name="hidElgStatusUni" runat="server"/>
                        <input id="hidInv" type="hidden" name="hidInv" runat="server" />
                        <input id="hidIsBlank" type="hidden" name="hidIsBlank" runat="server" />
                        <input id="hid_fk_AcademicYr_ID" type="hidden" name="hid_fk_AcademicYr_ID" runat="server"/>
                        <input id="hidAcademicYrText" type="hidden" name="hidAcademicYrText" runat="server"/>
                        <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
                        <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
                        
                        <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none" meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label> 
                        
                        <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
                        
                        
                        
       <%--         </td>
            </tr>
        </table>--%>
    </center>
</asp:Content>
