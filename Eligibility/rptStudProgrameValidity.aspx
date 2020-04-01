<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="rptStudProgrameValidity.aspx.cs"
    Inherits="StudentRegistration.Eligibility.rptStudProgrameValidity" %>

<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%@ register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

    <script type="text/javascript" src="ajax/StudentRegistration.Eligibility.clsEligibilityDBAccess,StudentRegistration.ashx"></script>

    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>

    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>

    <script language="javascript">
    
         var hidFacClientID = '<%=hidFacID.ClientID%>';
		 var hidCrClientID = '<%=hidCrID.ClientID%>';
		 var hidMoLrnClientID = '<%=hidMoLrnID.ClientID%>';
		 var hidPtrnClientID = '<%=hidPtrnID.ClientID%>';
		 var hidBrnClientID = '<%=hidBrnID.ClientID%>';	
		 var hidCrPrDetailsIDClientID = '<%=hidCrPrDetailsID.ClientID%>';	
		 var hidCrPrChIDClientID = '<%=hidCrPrChID.ClientID%>';	
		  	  
		 var hidUniClientID = '<%=hidUniID.ClientID%>';
		 
		 
		 var collTxt;
		 var result=false;
		 var alert1=false;
    
    
    function callvalidate()		  
		    { 	  
		       try { 
		        var i=-1; 
		        var myArr   = new Array(); 
		        var str = "";     
		        var cbArr = new Array(1); 
		       
                var flag=false;
		       // myArr[++i]= new Array(document.getElementById(d),"0","Select Academic Year","select"); 					
                   
                  
		                //validate that one criteria is checked
		                
		                
		                
                if(validateMe(myArr,50)) 
                { 
                    var str = ""; 
		           
	                alert1=true;
	                return true; 
                } 
		        else 
		        { 
		            alert1=false;
		            return false; 
		        } 
		        
		       } 
		       catch(e) 
		       { 
		           alert(e.message);  
		           return false; 
		       } 
		    }
    
      function setValue(Text,Value)
		{
		
			var text = eval(document.getElementById(Text));
			text.value = Value;	
			
		} 
	

    </script>

    <asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
            <table style="border-collapse: collapse" id="table3" bordercolor="#c0c0c0" cellpadding="2"
                width="100%" border="0">
                <tbody>
                    <tr>
                        <td style="width: 705px; border-bottom: #ffd275 1px solid" align="left">
                            <asp:Label runat="server" ID="lblPageHead" meta:resourceKey="lblPageHeadResource1"></asp:Label>
                            <asp:Label runat="server" Font-Bold="True" Font-Size="Small" ID="lblAcaYear" meta:resourceKey="lblAcaYearResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td style="width: 705px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 705px" valign="top" align="left">
                            <div runat="server" id="divAllCriterion">
                                <div runat="server" id="div1" style="margin-left: 30px; width: 90%; azimuth: center">
                                    &nbsp;&nbsp;
                                    <div runat="server" id="Div2" align="center">
                                        <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="height: 20px" colspan="3">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 225px; height: 20px" align="right">
                                                        <asp:Label runat="server" Text="Select Exam Event" Font-Bold="True" Width="221px"
                                                            ID="Label3" meta:resourceKey="lblAcyrResource1"></asp:Label>
                                                    </td>
                                                    <td style="width: 1%; height: 20px" align="center">
                                                        <b>&nbsp;:&nbsp;</b></td>
                                                    <td runat="server" id="td1" style="width: 387px; height: 20px" align="left">
                                                        <asp:DropDownList runat="server" CssClass="selectbox" Width="298px" ID="ddlExamEvent"
                                                           >
                                                            <asp:ListItem Text="--- Select ---" Value="0" meta:resourceKey="ListItemResource1"></asp:ListItem>
                                                        </asp:DropDownList><font class="Mandatory"> *</font></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                
                                <div runat="server" id="DivGenerate">
                                    <table cellpadding="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td style="height: 18px" valign="middle" align="center" colspan="4">
                                                    <asp:Button runat="server" OnClientClick="return callvalidate();" Text="Generate Report"
                                                        CssClass="butSubmit" ID="btnGenerate" meta:resourceKey="btnDisplayResource1" OnClick="btnGenerate_Click">
                                                    </asp:Button>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            
                            <input runat="server" id="hidUniID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidInstID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidInstName" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidInstCode" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidInstAddress" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidInstCity" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidSortOption" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCriteria" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCriteriaNull" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCriteriaEligibilityRequired" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidStateID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidDistrictID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidTalukaID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidLastName" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidFirstName" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidDOB" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidGender" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidFacID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidFacText" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCrID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCrText" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidMoLrnID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidMoLrnText" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidPtrnID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidPtrnText" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidBrnID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCrPrDetailsID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCrPrChID" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidBrnText" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidLevelFlag" type="hidden"/>
                            <input runat="server" id="hid_fk_AcademicYr_ID" type="hidden"/>
                            <input runat="server" id="hid_strAcademicYr1" type="hidden"/>
                            <input runat="server" id="hid_strAcademicYr2" type="hidden"/>
                            <input runat="server" id="hid_AcademicYear" type="hidden"/>
                            <input runat="server" id="hid_AcademicYearFrom" type="hidden"/>
                            <input runat="server" id="hid_AcademicYearTo" type="hidden"/>
                            <input runat="server" id="hidCourseDetails" type="hidden" style="width: 32px; height: 22px"/>
                            <input runat="server" id="hidCollName" type="hidden"/>
                            <asp:Label runat="server" Text="Faculty" ID="lblFac" Style="display: none" meta:resourceKey="lblFacResource1"></asp:Label>
                            <asp:Label runat="server" Text="Course" ID="lblCr" Style="display: none" meta:resourceKey="lblCrResource1"></asp:Label>
                            <asp:Label runat="server" Text="College" ID="lblCollege" Style="display: none" meta:resourceKey="lblCollegeResource1"></asp:Label>
                            <asp:Label runat="server" Text="University" ID="lblUniversity" Style="display: none"
                                meta:resourceKey="lblUniversityResource1"></asp:Label>
                            <asp:Label runat="server" Text="Permanent Registration Number" ID="lblPRNNomenclature" Style="display: none"
                                meta:resourceKey="lblPRNNomenclatureResource1"></asp:Label>
                            <asp:Label runat="server" Text="Course" ID="lblPrvCourseNomenclature" Style="display: none"
                                meta:resourceKey="lblPrvCourseNomenclatureResource1"></asp:Label>
                            <input runat="server" id="hidTermSelection" type="hidden"></input>
                            <input runat="server" id="hidFromDate" type="hidden"></input>
                            <input runat="server" id="hidToDate" type="hidden"></input>
                            </input>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
        <Triggers>
            
            <asp:PostBackTrigger ControlID="btnGenerate"></asp:PostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
    <table>
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </table>
    <div id="DivReportViewerDesign" runat="server" style="display: none;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="600px" Width="650px" meta:resourcekey="ReportViewer1Resource1">
            <LocalReport ReportEmbeddedResource="StudentRegistration.Eligibility.Rdlc.rdlcViewElgStatus.rdlc"
                EnableExternalImages="True">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>
