<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_PaperExemptionChangeDecision.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_PaperExemptionChange" %>

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
		
		function validatePaperNext()
                {
                    var i=-1;                   
                    var myArr = new Array();
                    var flag=false;
                    var arr=new Array();
                    arr=document.getElementById('<%=GVPapersNew.ClientID%>').getElementsByTagName("input");
                    document.getElementById("<%= hidPapers.ClientID%>").value="";
                    for(var j=0;j<arr.length;j++)
                    {
                        if(arr[j].checked && !arr[j].disabled)
                        { 
                            document.getElementById("<%= hidPapers.ClientID%>").value="Y";
                            flag=true;
                            break;                            
                        }                            
                     }                     
                     if(!flag)
                     {
                        document.getElementById("<%= hidPapers.ClientID%>").value="";
                        myArr[++i]  = new Array(document.getElementById("<%= hidPapers.ClientID%>"),"Empty","Please select atleast one Exemption Approval decision to Confirm.","text");
                     }
                    
                    var ret=validateMe(myArr,50); 
                    var ch;
                        if(ret)
                        {   ch=confirm("Are you sure you want to change the Exemption Approval Decision for the selected "+document.getElementById('<%=lblPaper.ClientID %>').innerText+"s?");
                            return ch;
                        }  
                        else
                        {
                            return ret;
                        }   
                    return ret;
	            }
	          
    </script>

    <asp:UpdatePanel ID="updContent" runat="server">
        <contenttemplate>
            <table style="border-collapse: collapse" id="table3" bordercolor="#c0c0c0" cellpadding="2"
                width="100%" border="0">
                <tbody>
                    <tr>
                        <td style="width: 705px; border-bottom: #ffd275 1px solid" align="left">
                            <asp:Label ID="lblPageHead" runat="server" Text="Change Exemption Approval Decision"
                                meta:resourceKey="lblPageHeadResource1"></asp:Label>
                            <asp:Label ID="lblAcaYear" runat="server" meta:resourceKey="lblAcaYearResource1"
                                Font-Size="Small" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="display: none" id="tblExportedDataMsg" width="100%" runat="server">
                                    <tr id="Tr1" runat="server">
                                        <td style="height: 30px" id="Td4" align="left" runat="server">
                                            <asp:Label ID="lblExportedData" runat="server" meta:resourcekey="lblExportedDataResource1"
                                                CssClass="errorNote"></asp:Label>
                                        </td>
                                    </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            
            <div id="divSimpleSearch" runat="server">
                <br />
                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                    <tbody>
                        <tr align="left">
                            <td align="right" width="50%">
                                &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="tbElgFormNo" runat="server" Text="Enter Eligibility Form Number: "
                                    meta:resourcekey="tbElgFormNoResource2"></asp:Label></b></td>
                            <td align="left" height="30">
                                <asp:TextBox ID="txtElgFormNo" onclick="this.value='';" runat="server" Font-Size="Small"
                                    Font-Bold="True" meta:resourcekey="txtElgFormNoResource2"></asp:TextBox></td>
                        </tr>
                        <tr id="trOr" align="center" runat="server">
                            <td id="Td1" align="center" colspan="2" runat="server">
                                <b>OR</b>
                            </td>
                        </tr>
                        <tr id="trPRN" align="left" runat="server">
                            <td id="Td2" align="right" width="50%" runat="server">
                                <strong>
                                    <asp:Label ID="lblEnterPRN" runat="server" Text="Enter PRN: " meta:resourcekey="lblEnterPRNResource1"></asp:Label></strong></td>
                            <td id="Td3" align="left" height="30" runat="server">
                                <asp:TextBox ID="txtPRN" onclick="this.value='';" runat="server" Font-Size="Small"
                                    Font-Bold="True" MaxLength="20"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <br />
                                <asp:Button ID="btnSimpleSearch" OnClick="btnSimpleSearch_Click" runat="server" Text="Search"
                                    meta:resourcekey="btnSimpleSearchResource1" CssClass="butSubmit" OnClientClick="return ChkValidation()">
                                </asp:Button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            
            <div style="display: none" id="divCourses" runat="server">
                <br />
                <asp:Label Style="font-size: 9pt; color: #ee6340; text-align: left" ID="lblCrPrTermHead"
                    runat="server" CssClass="errorNote" Width="100%" meta:resourcekey="lblCrPrTermHeadResource1"></asp:Label>
                <br />
                <asp:GridView Style="border-top-style: double; border-right-style: double; border-left-style: double;
                    border-collapse: collapse; border-bottom-style: double" ID="GVCourseTerms" runat="server"
                    CssClass="clGrid grid-view" Width="100%" OnRowCommand="GVCourseTerms_RowCommand"
                    AutoGenerateColumns="False" CellPadding="2" BorderStyle="None"
                    OnRowDataBound="GVCourseTerms_RowDataBound" DataKeyNames="pkFacID,pkCrID,pkMoLrnID,pkPtrnID,pkBrnID,pkCrPrDetails,pkCrPrChID,PpExistsCnt,pkStudentID, fk_ExEv_ID,pkInstID,fkAcademicYr" meta:resourcekey="GVCourseTermsResource1">
                    <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField meta:resourcekey="TemplateFieldResource2" HeaderText="Sr.No.">
                            <ItemStyle Width="3%" />
                            <ItemTemplate>
                                <%# (Container.DataItemIndex)+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="StudentName" HeaderText="Name of Student" meta:resourcekey="BoundFieldResource1">
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRN" HeaderText="PRN" meta:resourcekey="BoundFieldResource2">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CourseName" HeaderText="Course Part Term" meta:resourcekey="BoundFieldResource3">
                            <ItemStyle HorizontalAlign="Center" Width="42%" />
                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:ButtonField Text="Select Paper(s)" HeaderText="Select Paper(s)" CommandName="SelectCrPrTerm" meta:resourcekey="ButtonFieldResource1">
                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Label ID="lblNoRecordsFound" Visible="False" Style="text-align: left;" Width="100%"
                    Text="No record(s) found." runat="server" CssClass="errorNote" meta:resourcekey="lblNoRecordsFoundResource1"></asp:Label>
                
                <div style="display: block; margin-left: 2px; width: 100%; position: relative; height: 30px;
                    text-align: left" id="divNoteEnabledLink" runat="server">
                    <asp:Label Style="font-size: 8pt; color: #ee6340; text-align: left" ID="lblNote"
                        runat="server" Text="Note: The Select Paper(s) link button is enabled only for the Course Part Terms which have paper(s) in them for whom Exemption Approval Decision has been taken."
                        CssClass="errorNote" Width="100%" meta:resourcekey="lblNoteResource1"></asp:Label>
                </div>
            </div>
            <asp:Label Style="text-align: right" ID="lblMsg" runat="server" CssClass="saveNote"
                Width="100%" meta:resourcekey="lblMsgResource1"></asp:Label>
            <br />
            <div id="divPapers" style="display: none" runat="server">
                <asp:Label Style="font-size: 9pt; color: #ee6340; text-align: left" ID="lblGVPapersNewHeading"
                    runat="server" Text="List of Paper(s) with their Exemption Approval Decisions" CssClass="errorNote"
                    Width="100%" meta:resourcekey="lblGVPapersNewHeadingResource1"></asp:Label>
                <br />
                <asp:GridView Style="border-top-style: double; border-right-style: double; border-left-style: double;
                    border-collapse: collapse; border-bottom-style: double" ID="GVPapersNew" runat="server"
                    CssClass="clGrid grid-view" Width="100%" OnRowCommand="GVCourseTerms_RowCommand"
                    AutoGenerateColumns="False" CellPadding="2" BorderStyle="None"
                    DataKeyNames="pk_Uni_ID,pk_Year,pk_Student_ID,pk_Fac_ID,pk_Cr_ID,pk_MoLrn_ID,pk_Ptrn_ID,pk_Brn_ID,pk_CrPr_Details_ID,pk_CrPrCh_ID,pk_Pp_PpHead_CrPrCh_ID,ExmpApprovalStatus,TLM-AM-AT-ID,fk_AcademicYear_ID, Ref_InstReg_Institute_ID" OnRowDataBound="GVPapersNew_RowDataBound" meta:resourcekey="GVPapersNewResource1">
                    <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField meta:resourcekey="TemplateFieldResource2" HeaderText="Sr. No.">
                            <ItemStyle Width="4%" />
                            <ItemTemplate>
                                <%# (Container.DataItemIndex)+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PpDetails" HeaderText="Paper(Paper Code) TLM-AM-AT" meta:resourcekey="BoundFieldResource4">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Grant" meta:resourcekey="TemplateFieldResource1">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <EditItemTemplate>
                                <asp:RadioButton ID="RDBtnApprove" runat="server" meta:resourcekey="RDBtnApproveResource1" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <center>
                                    <asp:RadioButton ID="RDBtn_Approve" runat="server" GroupName="ApproveDeny" meta:resourcekey="RDBtn_ApproveResource1" />
                                </center>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" BackColor="#E0E0E0" VerticalAlign="Middle"
                                CssClass="gridHeader" Font-Bold="True"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Deny" meta:resourcekey="TemplateFieldResource3">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <EditItemTemplate>
                                <asp:RadioButton ID="RDBtnDeny" runat="server" meta:resourcekey="RDBtnDenyResource1" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <center>
                                    <asp:RadioButton ID="RDBtn_Deny" runat="server" GroupName="GrantDeny" meta:resourcekey="RDBtn_DenyResource1" />
                                </center>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" BackColor="#E0E0E0" VerticalAlign="Middle"
                                CssClass="gridHeader" Font-Bold="True"></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
              <center>
                    <table>
                        <tbody>
                            <tr>
                                <td style="height: 20px">
                                    <asp:Button ID="btnProceed" OnClick="btnProceed_Click" runat="server" Text="Confirm"
                                        CssClass="butSubmit" OnClientClick="return validatePaperNext()" meta:resourcekey="btnProceedResource1"></asp:Button>
                                </td>
                                <td style="height: 20px">
                                     <asp:Button Style="display: none" ID="btnBack" OnClick="btnBack_Click" runat="server"
                                        Text="Back to Course Selection" CssClass="butSubmit" meta:resourcekey="btnBackResource1"></asp:Button>
                                </td>
                              </tr>
                        </tbody>
                    </table>
                </center>

                <br />
            </div>
            <input id="hidSSVal" type="hidden" value="1" runat="server" />
            <input id="hidPapers" type="hidden" value="1" runat="server" />
            <input id="hidHeading" type="hidden" runat="server" />
            <input type="hidden" runat="server" id="hidUniID" />
            <input type="hidden" runat="server" id="hidYearID" />
            <input type="hidden" runat="server" id="hidStudentID" />
            <input type="hidden" runat="server" id="hidpkFacID" />
            <input type="hidden" runat="server" id="hidpkCrID" />
            <input type="hidden" runat="server" id="hidpkMoLrnID" />
            <input type="hidden" runat="server" id="hidpkPtrnID" />
            <input type="hidden" runat="server" id="hidpkBrnID" />
            <input type="hidden" runat="server" id="hidpkCrPrDetails" />
            <input type="hidden" runat="server" id="hidpkCrPrChID" />
             <input id="hidExamFormModifyReq" runat="server" type="hidden" />
              <input id="hidInstID" runat="server" name="hidInstID" size="1" type="hidden" />
                <input id="hidAcademicYear" runat="server" name="hidAcademicYear" size="1" type="hidden" />
                 <input id="hidStudentYear" runat="server" name="hidStudentYear" size="1" type="hidden" />
                 <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
            <asp:Label Style="display: none" ID="lblCollege" runat="server" Text="College" meta:resourcekey="lblCollegeResource1"></asp:Label>
            <asp:Label Style="display: none" ID="lblPRNNomenclature" runat="server" Text="PRN"
                meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>
                
               <asp:Label Style="display: none" ID="lblPaper" runat="server" Text="Paper"
                meta:resourcekey="lblPaperResource1"></asp:Label>
                <asp:Label Style="display: none" ID="lblCourse" runat="server" Text="Course"
                meta:resourcekey="lblCourseResource1"></asp:Label>
                <input type="hidden" runat="server" id="hidPRN" />
            <input type="hidden" runat="server" id="hidElgFormNo" />
        </contenttemplate>
        <triggers>
            <asp:PostBackTrigger ControlID="btnProceed" />
        </triggers>
    </asp:UpdatePanel>
</asp:Content>
