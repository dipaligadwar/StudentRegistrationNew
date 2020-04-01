<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ELGV2_PaperExemptionClaim.aspx.cs"
    MasterPageFile="~/Home.Master" Inherits="StudentRegistration.Eligibility.ELGV2_PaperExemptionClaim" %>

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
			
			//************************************************
			// Added to check whether PRN belongs to the selected Institute
			if(innerRet == true && document.getElementById("<%= hidUserType.ClientID%>").value == "2") // hidUserType = 2 for college login
			{
			   innerRet = CheckInstforStudentPRN();
			   
			   if(innerRet == false)
			   {
			      document.getElementById("<%= hidSSVal.ClientID%>").value="";
			      myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Entered " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " does not belong to selected " +document.getElementById('ctl00_ContentPlaceHolder1_lblCollege').innerText + ".","text");  
			   }
			}
			//************************************************
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
                        if(arr[j].checked && arr[j].id != "ctl00_ContentPlaceHolder1_GVPapersNew_ctl01_ChkHead") // 
                        { 
                            document.getElementById("<%= hidPapers.ClientID%>").value="Y";
                            flag=true;
                            break;                            
                        }                            
                     }                     
                     if(!flag)
                     {
                        document.getElementById("<%= hidPapers.ClientID%>").value="";
                        myArr[++i]  = new Array(document.getElementById("<%= hidPapers.ClientID%>"),"Empty","Please select atleast one " + document.getElementById('ctl00_ContentPlaceHolder1_LblPaper').innerText +" for claiming exemption.","text");
                     }
                    
                    var ret=validateMe(myArr,50); 
                    
                    if(ret == true)
                    {
                        if(confirm("Are you sure you want to claim exemption for the selected " + document.getElementById('ctl00_ContentPlaceHolder1_LblPaper').innerText +"(s)?"))
                        {
                            return ret;
                        }
                        else
                            return false;
                       
                    }
                    else
                        return ret;
	            }
	            
	            
	            //----------------------------------------------------------------------
	            // Function to call the SP for checking whether entered PRN belongs to selected Institute 
	            function CheckInstforStudentPRN()
	            { 
                
                    var ResultStatus = clsStudent.CheckInstforStudentPRN(document.getElementById('<%=hidUniID.ClientID%>').value,document.getElementById('<%=txtPRN.ClientID%>').value, document.getElementById('<%=hidInstID.ClientID%>').value);
                    if(ResultStatus.value == "1")   // Student belongs to selected institute
                        return true;
                    else                            // Student does not belong to selected institute
                        return false;
                    
                }
                //----------------------------------------------------------------------
    </script>

    <asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
            <table style="border-collapse: collapse" id="table3" bordercolor="#c0c0c0" cellpadding="2"
                width="100%" border="0">
                <tbody>
                    <tr>
                        <td style="width: 705px; border-bottom: #ffd275 1px solid" align="left">
                            <asp:Label ID="lblPageHead" runat="server" Text="Paper Exemption Claim" meta:resourceKey="lblPageHeadResource1"></asp:Label>
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
                    OnRowDataBound="GVCourseTerms_RowDataBound" DataKeyNames="pkFacID,pkCrID,pkMoLrnID,pkPtrnID,pkBrnID,pkCrPrDetails,pkCrPrChID,PpExistsCnt" meta:resourcekey="GVCourseTermsResource1">
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
                <asp:Label ID="lblNoRecordsFound" Visible="False" style="text-align: left;" width="100%" runat="server" CssClass="errorNote" meta:resourcekey="lblNoRecordsFoundResource1"></asp:Label>
                
                <div style="display: block; margin-left: 2px; width: 100%; position: relative; height: 30px;
                                text-align: left" id="divNoteEnabledLink" runat="server">
                        <asp:Label Style="font-size: 8pt; color: #ee6340; text-align: left" ID="lblNoteEnabledLink" runat="server" Width="100%" CssClass="errorNote" 
                        Text="Note: The Select Paper(s) link button is enabled only for the Course Part Terms which have paper(s) in them for whom Exemption can be claimed or for the terms for whom the event is open." meta:resourcekey="lblNoteEnabledLinkResource1" ></asp:Label>
                </div>
            </div>
            
            
            
            <asp:Label Style="text-align: right; display:none;" ID="lblMsg" Text="The Exemption has been successfully claimed for the selected paper(s)"
                runat="server" CssClass="saveNote" Width="100%" meta:resourcekey="lblMsgResource1"></asp:Label>
            
            <div style="display: none" id="divPapers" runat="server">
                <div style="display:none;" id="divPapersOld" runat="server">
                    <br />
                    <asp:Label Style="font-size: 9pt; color: #ee6340; text-align: left" ID="lblGVPapersOldHeading"
                        runat="server" Text="List of paper(s) for whom exemptions are already claimed" CssClass="errorNote"
                        Width="100%" meta:resourcekey="lblGVPapersOldHeadingResource1"></asp:Label>
                    <br />
                    <asp:GridView Style="border-top-style: double; border-right-style: double; border-left-style: double;
                        border-collapse: collapse; border-bottom-style: double" ID="GVPapersOld" runat="server"
                        CssClass="clGrid grid-view" Width="100%" OnRowCommand="GVCourseTerms_RowCommand"
                        AutoGenerateColumns="False" CellPadding="2" BorderStyle="None"
                        DataKeyNames="pk_Fac_ID,pk_Cr_ID,pk_MoLrn_ID,pk_Ptrn_ID,pk_Brn_ID,pk_CrPr_Details_ID,pk_Pp_PpHead_CrPrCh_ID" meta:resourcekey="GVPapersOldResource1">
                        <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                        <RowStyle CssClass="gridItem" />
                        <Columns>
                            <asp:TemplateField meta:resourcekey="TemplateFieldResource2" HeaderText="Sr.No.">
                                <ItemStyle Width="4%" />
                                <ItemTemplate>
                                    <%# (Container.DataItemIndex)+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PpDetails" HeaderText="Paper(Paper Code) TLM-AM-AT" meta:resourcekey="BoundFieldResource4">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ExmpApprovalStatus" HeaderText="Exemption Approval Status" meta:resourcekey="BoundFieldResource5">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="display:none;" id="divPapersNew" runat="server">

                    <br />
                    <asp:Label Style="font-size: 9pt; color: #ee6340; text-align: left" ID="lblGVPapersNewHeading"
                        runat="server" Text="List of paper(s) for whom exemption can be claimed" CssClass="errorNote"
                        Width="100%" meta:resourcekey="lblGVPapersNewHeadingResource1"></asp:Label>
                    <br />
                    <asp:GridView Style="border-top-style: double; border-right-style: double; border-left-style: double;
                        border-collapse: collapse; border-bottom-style: double" ID="GVPapersNew" runat="server"
                        CssClass="clGrid grid-view" Width="100%" OnRowCommand="GVCourseTerms_RowCommand"
                        AutoGenerateColumns="False" CellPadding="2" BorderStyle="None"
                        DataKeyNames="pk_Pp_PpHead_CrPrCh_ID" meta:resourcekey="GVPapersNewResource1">
                        <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                        <RowStyle CssClass="gridItem" />
                        <Columns>
                            <asp:TemplateField meta:resourcekey="TemplateFieldResource2" HeaderText="Sr. No.">
                                <ItemStyle Width="4%" />
                                <ItemTemplate>
                                    <%# (Container.DataItemIndex)+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PpNamePpCode" HeaderText="Paper(Paper Code)" meta:resourcekey="BoundFieldResource6">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
                                <HeaderTemplate>
                                    <asp:Label ID="LblChk" Text="Select" runat="server" meta:resourcekey="LblChkResource1"></asp:Label>
                                    <br />
                                    <asp:CheckBox ID="ChkHead" runat="server" OnCheckedChanged="ChkHead_Checked" AutoPostBack="True" meta:resourcekey="ChkHeadResource1"/>
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" meta:resourcekey="CheckBox1Resource1" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <center>
                                        <asp:CheckBox ID="chkSelectApps" runat="server" meta:resourcekey="chkSelectAppsResource1" />
                                    </center>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" BackColor="#E0E0E0" VerticalAlign="Middle"
                                    CssClass="gridHeader" Font-Bold="True" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                     <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td style="height: 20px">
                                        <asp:Button ID="btnProceed" OnClick="btnProceed_Click" runat="server" Text="Claim Exemption"
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
                     <br />
                </div>
            </div>
            <input id="hidSSVal" type="hidden" value="1" runat="server" />
            <input id="hidPapers" type="hidden" value="1" runat="server" />
            <input id="hidHeading" type="hidden" runat="server" />
            <asp:Label Style="display: none" ID="lblCollege" runat="server" Text="College" meta:resourcekey="lblCollegeResource1"></asp:Label>
            <asp:Label Style="display: none" ID="lblPRNNomenclature" runat="server" Text="PRN"
                meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>

                
              <asp:Label Style="display: none" ID="LblListofPapers" runat="server" Text="List of Papers"
                meta:resourcekey="LblListofPapersResource1"></asp:Label>
            <asp:Label Style="display: none" ID="LblPaper" runat="server" Text="paper" meta:resourcekey="LblPaperResource1"></asp:Label>
            
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
            <input type="hidden" runat="server" id="hidPRN" />
            <input type="hidden" runat="server" id="hidElgFormNo" />
            <input type="hidden" runat="server" id="hidInstID" />
            <input type="hidden" runat="server" id="hidUserType" />
            <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnProceed" />
        </Triggers>

    </asp:UpdatePanel>
</asp:Content>
