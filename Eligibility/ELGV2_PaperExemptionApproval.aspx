<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_PaperExemptionApproval.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_PaperExemptionApproval" %>

<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>
<%@ Register Src="WebCtrl/SelectSingleCourse.ascx" TagName="YCMOU" TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/jsAjaxMethod.js"></script>

    <script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>

    <script language="javascript" type="text/javascript" src="JS/ValidatePRN.js"></script>

    <script language="javascript" type="text/javascript" src="JS/Validations.js"></script>

    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>

    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>

    <script language="javascript" src="ajax/StudentRegistration.Eligibility.AjaxMethods,StudentRegistration.ashx"></script>

    <script type="text/javascript" src="../../ajax/StudentRegistration.Eligibility.clsEligibilityDBAccess,StudentRegistration.ashx"></script>

    <script type="text/javascript">
        var lblAdv='<%=lblAdvSearch.ClientID %>';
        function UnderLineOnMouseOver()
		{				      
		       document.getElementById("<%=lblAdvSearch.ClientID %>").style.textDecoration = "underline"; 
		   
		}
		function UnderLineOnMouseOut()
		{		        
		        document.getElementById("<%=lblAdvSearch.ClientID %>").style.textDecoration = "none"; 		      
		}
		
		function fnDisplayDiv()
	    {  
	           document.getElementById('<%=divYCMOU.ClientID%>').style.display = 'none';
		       document.getElementById('<%=divSimpleSearch.ClientID%>').style.display = 'block';
		       document.getElementById(lblAdv).style.display = 'none';
		       document.getElementById('<%=tblExportedDataMsg.ClientID%>').style.display = 'none';
	    }
	    
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
                        if(arr[j].checked)  
                        { 
                            document.getElementById("<%= hidPapers.ClientID%>").value="Y";
                            flag=true;
                            break;                            
                        }                            
                     }                     
                     if(!flag)
                     {
                        document.getElementById("<%= hidPapers.ClientID%>").value="";
                        myArr[++i]  = new Array(document.getElementById("<%= hidPapers.ClientID%>"),"Empty","Please select one "+document.getElementById('<%=lblPaper.ClientID %>').innerText+" for proceeding.","text");
                     }
                    
                    var ret=validateMe(myArr,50); 
                    return ret;                   
	            }
	            
	          function validateAllowDenyNext(allowOrDeny)
                    {
                        var i=-1;
                        var myArr = new Array();
                        var flag=false;
                        var arr=new Array();
                        arr=document.getElementById('<%=GVPapersNew.ClientID%>').getElementsByTagName("input");
                        for(var j=0;j<arr.length;j++)
                        {
                            if(arr[j].checked)
                            {
                                flag=true;
                                document.getElementById("<%= hidPaperTLMAMAT.ClientID%>").value="Y";
                                break;
                            }
                         }
                         if(!flag)
                         {
                            document.getElementById("<%= hidPaperTLMAMAT.ClientID%>").value="";
                            myArr[++i]  = new Array(document.getElementById("<%= hidPaperTLMAMAT.ClientID%>"),"Empty","Please select at least one paper for making Exemption Approval Decision.","text");
                         }
                        
                        var ret=validateMe(myArr,50);  
                        var ch;
                        if(ret)
                        {   
                                if(allowOrDeny==1)
                                {
                                    ch=confirm("Are you sure you want to grant the Exemption Claimed for the selected "+document.getElementById('<%=lblPaper.ClientID %>').innerText+"(s)?");
                                }
                                else if(allowOrDeny==2)
                                {
                                    ch=confirm("Are you sure you want to deny the Exemption Claimed for the selected "+document.getElementById('<%=lblPaper.ClientID %>').innerText+"(s)?");
                                }
                            return ch;
                        }  
                        else
                        {
                            return ret;
                        }
	                }
		
    </script>

    <asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
            <table style="border-collapse: collapse" id="table3" bordercolor="#c0c0c0" cellpadding="2"
                width="100%" border="0">
                <tbody>
                    <tr>
                        <td style="width: 705px; border-bottom: #ffd275 1px solid" align="left">
                            <asp:Label runat="server" Text="Paper Exemption Approval" ID="lblPageHead" meta:resourceKey="lblPageHeadResource1"></asp:Label>
                            <asp:Label runat="server" Font-Bold="True" Font-Size="Small" ID="lblAcaYear" meta:resourceKey="lblAcaYearResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div runat="server" id="divSimpleSearch" style="display: none">
                                <br />
                                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                                    <tbody>
                                        <tr align="left">
                                            <td align="right" width="50%">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label runat="server" Text="Enter Eligibility Form Number: "
                                                    ID="tbElgFormNo" meta:resourceKey="tbElgFormNoResource2"></asp:Label>
                                                </b>
                                            </td>
                                            <td align="left" height="30">
                                                <asp:TextBox runat="server" Font-Bold="True" Font-Size="Small" ID="txtElgFormNo"
                                                    onclick="this.value='';" meta:resourceKey="txtElgFormNoResource2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trOr" align="center">
                                            <td runat="server" id="Td2" align="center" colspan="2">
                                                <b>OR</b>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trPRN" align="left">
                                            <td runat="server" id="Td3" align="right" width="50%">
                                                <strong>
                                                    <asp:Label runat="server" Text="Enter PRN: " ID="lblEnterPRN" meta:resourceKey="lblEnterPRNResource1"></asp:Label>
                                                </strong>
                                            </td>
                                            <td runat="server" id="Td4" align="left" height="30">
                                                <asp:TextBox runat="server" MaxLength="20" Font-Bold="True" Font-Size="Small" ID="txtPRN"
                                                    onclick="this.value='';"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <br />
                                                <asp:Button runat="server" OnClientClick="return ChkValidation()" Text="Search" CssClass="butSubmit"
                                                    ID="btnSimpleSearch" meta:resourceKey="btnSimpleSearchResource1" OnClick="btnSimpleSearch_Click">
                                                </asp:Button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tbody>
                                    <tr align="right">
                                        <td style="height: 19px" align="right">
                                            <label runat="server" id="lblAdvSearch" style="cursor: hand; color: blue" onmouseover="UnderLineOnMouseOver();"
                                                class="NavLink" onmouseout="UnderLineOnMouseOut();" onclick="fnDisplayDiv();">
                                                Search Student
                                            </label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <br />
                            <div runat="server" id="divYCMOU">
                                <uc3:YCMOU runat="server" ID="YCMOU"></uc3:YCMOU>
                            </div>
                            <div runat="server" id="divCourses" style="display: none">
                                <asp:Label runat="server" CssClass="errorNote" Width="100%" ID="lblCrPrTermHead"
                                    Style="font-size: 9pt; color: #ee6340; text-align: left" meta:resourceKey="lblCrPrTermHeadResource1"></asp:Label>
                                <br />
                                <asp:GridView runat="server" AutoGenerateColumns="False" CellPadding="2" DataKeyNames="pkFacID,pkCrID,pkMoLrnID,pkPtrnID,pkBrnID,pkCrPrDetails,pkCrPrChID,PpExistsCnt"
                                    BorderStyle="None" CssClass="clGrid grid-view" Width="100%" ID="GVCourseTerms"
                                    Style="border-top-style: double; border-right-style: double; border-left-style: double;
                                    border-collapse: collapse; border-bottom-style: double" meta:resourceKey="GVCourseTermsResource1"
                                    OnRowCommand="GVCourseTerms_RowCommand" OnRowDataBound="GVCourseTerms_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No." meta:resourceKey="TemplateFieldResource2">
                                            <ItemTemplate>
                                                <%# (Container.DataItemIndex)+1 %>.
                                            </ItemTemplate>
                                            <ItemStyle Width="3%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="StudentName" HeaderText="Name of Student" meta:resourceKey="BoundFieldResource1">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PRN" HeaderText="PRN" meta:resourceKey="BoundFieldResource2">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CourseName" HeaderText="Course Part Term" meta:resourceKey="BoundFieldResource3">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="42%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:ButtonField CommandName="SelectCrPrTerm" Text="Select Paper(s)" HeaderText="Select Paper(s)"
                                            meta:resourceKey="ButtonFieldResource1">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                        </asp:ButtonField>
                                    </Columns>
                                    <HeaderStyle BackColor="#E0E0E0" CssClass="gridHeader"></HeaderStyle>
                                    <RowStyle CssClass="gridItem"></RowStyle>
                                </asp:GridView>
                                <br />
                                <asp:Label runat="server" CssClass="errorNote" Width="100%" ID="lblNoRecordsFound"
                                    Visible="False" Style="text-align: left" meta:resourceKey="lblNoRecordsFoundResource1"></asp:Label>
                                <div runat="server" id="divNoteEnabledLink" style="display: block; margin-left: 2px;
                                    width: 100%; position: relative; height: 30px; text-align: left">
                                    <asp:Label runat="server" Text="Note: The Select Paper(s) link button is enabled only for the Course Part Terms which have Paper(s) in them for whom Exemption Claim Decision is Pending."
                                        CssClass="errorNote" Width="100%" ID="lblNoteEnabledLink" Style="font-size: 8pt;
                                        color: #ee6340; text-align: left" meta:resourceKey="lblNoteEnabledLinkResource1"></asp:Label>
                                </div>
                            </div>
                            <div runat="server" id="divMsg" style="display: none; margin-left: 2px; width: 100%;
                                position: relative; height: 30px; text-align: right">
                                <asp:Label runat="server" CssClass="saveNote" Width="100%" ID="lblAppOrDenyMsg" Style="text-align: right"
                                    meta:resourceKey="lblAppOrDenyMsgResource1"></asp:Label>
                                <br />
                            </div>
                            <div runat="server" id="divPapers" style="display: none">
                                <center>
                                    <div runat="server" id="divTLMAMATChoice" style="margin-left: 0px; width: 99%; position: relative;
                                        text-align: left">
                                        <fieldset>
                                            <legend>To select specific TLM-AM-AT click below</legend>
                                            <asp:CheckBoxList runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                                DataTextField="TLM-AM-AT" DataValueField="TLM-AM-AT-ID" Width="100%" ID="chkTLMAMAT"
                                                meta:resourceKey="chkTLMAMATResource1" OnSelectedIndexChanged="divTLMAMATChoice_SelectedIndexChanged">
                                            </asp:CheckBoxList>
                                        </fieldset>
                                    </div>
                                </center>
                                <div runat="server" id="divPaperTLMAMAT" style="margin-top: 1px; margin-left: 2px;
                                    width: 99%; position: relative">
                                    <asp:GridView runat="server" AutoGenerateColumns="False" CellPadding="2" DataKeyNames="TLM-AM-AT-ID,pk_Student_ID,pk_Pp_PpHead_CrPrCh_ID,pk_Fac_ID,pk_Cr_ID,pk_MoLrn_ID,pk_Ptrn_ID,pk_Brn_ID,pk_CrPr_Details_ID,pk_CrPrCh_ID,pk_Uni_ID,pk_Year,fk_ExEv_ID,fk_AcademicYear_ID, Ref_InstReg_Institute_ID"
                                        BorderStyle="None" CssClass="clGrid grid-view" Width="100%" ID="GVPapersNew"
                                        Style="border-top-style: double; border-right-style: double; border-left-style: double;
                                        border-collapse: collapse; border-bottom-style: double" meta:resourceKey="GVPapersNewResource1"
                                        OnRowCommand="GVCourseTerms_RowCommand" OnRowDataBound="GVPapersNew_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No." meta:resourceKey="TemplateFieldResource2">
                                                <ItemTemplate>
                                                    <%# (Container.DataItemIndex)+1 %>.
                                                </ItemTemplate>
                                                <ItemStyle Width="4%"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Paper TLM-AM-AT" HeaderText="Paper TLM-AM-AT" meta:resourceKey="BoundFieldResource6">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Select" meta:resourceKey="TemplateFieldResource1">
                                                <EditItemTemplate>
                                                    <asp:CheckBox runat="server" ID="CheckBox1" meta:resourceKey="CheckBox1Resource1"></asp:CheckBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:CheckBox runat="server" ID="chkSelectStudents" meta:resourceKey="chkSelectStudentsResource1">
                                                        </asp:CheckBox>
                                                    </center>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"
                                                    CssClass="gridHeader" Font-Bold="True" Width="10%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30%"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#E0E0E0" CssClass="gridHeader"></HeaderStyle>
                                        <RowStyle CssClass="gridItem"></RowStyle>
                                    </asp:GridView>
                                </div>
                                <br />
                                <div runat="server" id="divEndButtons" style="margin-left: 2px; width: 99%; position: relative">
                                </div>
                            </div>
                            <center>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="height: 20px">
                                                <asp:Button runat="server" OnClientClick="return validateAllowDenyNext(1)" Text="Grant"
                                                    CssClass="butSubmit" ID="btnApprove" Style="display: none" meta:resourceKey="btnApproveResource1"
                                                    OnClick="btnApproveOrDeny_Click"></asp:Button>
                                            </td>
                                            <td style="height: 20px">
                                                <asp:Button runat="server" OnClientClick="return validateAllowDenyNext(2)" Text="Deny"
                                                    CssClass="butSubmit" ID="btnDeny" Style="display: none" meta:resourceKey="btnDenyResource1"
                                                    OnClick="btnApproveOrDeny_Click"></asp:Button>
                                            </td>
                                            <td style="height: 20px">
                                                <asp:Button runat="server" Text="Back to Course Selection" CssClass="butSubmit" ID="btnBack"
                                                    Style="display: none" meta:resourceKey="btnBackResource1" OnClick="btnBack_Click">
                                                </asp:Button>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table runat="server" id="tblExportedDataMsg" style="display: none" width="100%">
                                <tr runat="server" id="Tr1">
                                    <td runat="server" id="Td1" style="height: 30px" align="left">
                                        <asp:Label runat="server" CssClass="errorNote" ID="lblExportedData" meta:resourceKey="lblExportedDataResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <input runat="server" id="hidInstID" type="hidden" style="width: 24px; height: 22px"></input>
            <input runat="server" id="hid_fk_AcademicYr_ID" type="hidden"></input>
            <input runat="server" id="hidFacID" type="hidden"></input>
            <input runat="server" id="hidCrID" type="hidden"></input>
            <input runat="server" id="hidMoLrnID" type="hidden"></input>
            <input runat="server" id="hidPtrnID" type="hidden"></input>
            <input runat="server" id="hidBrnID" type="hidden"></input>
            <input runat="server" id="hidCrPrDetailsID" type="hidden"></input>
            <input runat="server" id="hidCrPrChID" type="hidden"></input>
            <input runat="server" id="hidPapers" type="hidden"></input>
            <input runat="server" id="hidPaperTLMAMAT" type="hidden"></input>
            <input runat="server" id="hidSelPapers" type="hidden"></input>
            <input runat="server" id="hidDD" type="hidden"></input>
            <input runat="server" id="hidBranchName" type="hidden"></input>
            <input runat="server" id="hidAcYrForCollLogin" type="hidden"></input>
            <input runat="server" id="hidUniID" type="hidden"></input>
            <input runat="server" id="hidCollName" type="hidden"></input>
            <input runat="server" id="hidSSVal" type="hidden" value="1"></input>
            <asp:Label runat="server" Text="PRN" ID="lblPRNNomenclature" Style="display: none"
                meta:resourceKey="lblPRNNomenclatureResource1"></asp:Label>
            <input runat="server" id="hidStudentID" type="hidden"></input>
            <input runat="server" id="hidPRN" type="hidden"></input>
            <input runat="server" id="hidElgFormNo" type="hidden"></input>
            <input runat="server" id="hidHeading" type="hidden"></input>
            <input runat="server" id="hidYearID" type="hidden"></input>
            <input runat="server" id="hidSelPaper" type="hidden"></input>
            <input runat="server" id="hidSelTLMAmAt" type="hidden"></input>
            <input runat="server" id="hidHead" type="hidden"></input>
            <input runat="server" id="hidTLMIDs" type="hidden"></input>
            <input runat="server" id="hidAMIDs" type="hidden"></input>
            <input runat="server" id="hidATIDs" type="hidden"></input>
             <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
             <input id="hidExamFormModifyReq" runat="server" type="hidden" />
             <input runat="server" id="hidIsAcdYrDdNotVisible" type="hidden" />
            <asp:Label runat="server" Text="paper" ID="lblPaper" Style="display: none" meta:resourceKey="LblPaperResource1"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="YCMOU" />
        </Triggers>
    </asp:UpdatePanel>
    <table>
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </table>
</asp:Content>
