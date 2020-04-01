<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_BulkProcess_reg_Students__1.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_BulkProcess_reg_Students__1"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register TagPrefix="uc1" TagName="StudentsAdvancedSearch" Src="WebCtrl/StudentsAdvancedSearch.ascx" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/jsAjaxMethod.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/CommonFunctions.js"></script>

    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>

    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>

    <script language="javascript" type="text/javascript" src="JS/ValidatePRN.js"></script>


    <script language="javascript" type="text/javascript">
    
     var uniid;		
	 uniid = <%=Classes.clsGetSettings.UniversityID%>;		 
	 var hidInstClientID = '<%=hidInstID.ClientID %>';
	 var hidFacClientID = '<%=hidFacID.ClientID%>';
	 var hidCrClientID = '<%=hidCrID.ClientID%>';
	 var hidMoLrnClientID = '<%=hidMoLrnID.ClientID%>';
	 var hidPtrnClientID = '<%=hidPtrnID.ClientID%>';
	 var hidBrnClientID = '<%=hidBrnID.ClientID%>';
	 var hidCrPrClientID = '<%=hidCrPrID.ClientID%>';	 
	 var hidUniClientID = '<%=hidUniID.ClientID%>';	
	 var DD_CoursePart = '<%=DD_CoursePart.ClientID%>'; 
	 
		
		function setValue(Text,Value)
			{
				var text = eval(document.getElementById(Text));
				text.value = Value;
			}
			
			function callvaliadteAcademic()
		    {      
		            var i=-1;
				    var myArr= new Array();				
				    myArr[++i]= new Array(document.getElementById('<%= ddlAcademicYear.ClientID%>'),"0","Select Academic Year","select"); 					
				    var ret=validateMe(myArr,50);
		            return ret;
		     } 
		
		    
		    var sTableCellID;
 
         
          function BindDataToCombo_CallBack(response)
              {		
              
		            if(response.error == null)
		            {
            		    
			            document.getElementById(sTableCellID).innerHTML = response.value +"&nbsp;<FONT class='Mandatory'>*</FONT>";
		            }		
            		
              }	
              
        function FetchCourseWiseCoursePartList(location,UniID,InstID,val, HtmlSelCrPrID)
            {
                var arr = new Array(5);
                arr = val.split("-"); 
                document.getElementById(hidFacClientID).value = arr[0];
                document.getElementById(hidCrClientID).value = arr[1];
                document.getElementById(hidMoLrnClientID).value = arr[2];
                document.getElementById(hidPtrnClientID).value = arr[3];
                document.getElementById(hidBrnClientID).value = arr[4];
                sTableCellID=location;
                clsAjaxMethods.FetchCourseWiseCoursePartListNew(UniID,InstID,document.getElementById(hidFacClientID).value,document.getElementById(hidCrClientID).value,document.getElementById(hidMoLrnClientID).value,document.getElementById(hidPtrnClientID).value,document.getElementById(hidBrnClientID).value, HtmlSelCrPrID, BindDataToCombo_CallBack);
       	            
            }
            
            function FetchCoursePartWiseCoursePartChildList(location,UniID,InstID,val, HtmlSelCrPrID)
            {    
                var arr = new Array(6);
                arr = val.split("-");
                document.getElementById(hidFacClientID).value = arr[0];
                document.getElementById(hidCrClientID).value = arr[1];
                document.getElementById(hidMoLrnClientID).value = arr[2];
                document.getElementById(hidPtrnClientID).value = arr[3];
                document.getElementById(hidBrnClientID).value = arr[4];
                document.getElementById(hidCrPrClientID).value = arr[5];;
                sTableCellID=location;           
                
                clsAjaxMethods.FetchCoursePartWiseCoursePartChildList(UniID,InstID,document.getElementById(hidFacClientID).value,document.getElementById(hidCrClientID).value,document.getElementById(hidMoLrnClientID).value,document.getElementById(hidPtrnClientID).value,document.getElementById(hidBrnClientID).value,document.getElementById(hidCrPrClientID).value, HtmlSelCrPrID, BindDataToCombo_CallBack);
            }
		    
		function setCrPart(val)
            { 
	            document.getElementById(hidCrPrClientID).value = val;
	            
            }
		    
		     function setCrPartTerm(val)
            { 
	            
	            document.getElementById('<%=hidCrPrChID.ClientID%>').value = val;
	            //document.getElementById('ctl00_ContentPlaceHolder1_hidCrPrID').value = val;
	            
            }
		    
	    function ShowGrid()
	        {
	            document.getElementById('ctl00_ContentPlaceHolder1_tblGrid').style.display = "inline";
	        }
		    
		function fnConfirm()
		    {
		        var ch;
		        if(document.getElementById('ctl00_ContentPlaceHolder1_tblUniversity').style.display=="inline")
		        {
		            ch=confirm('Are you sure you want to mark all student as \"Eligible\" ?');
		            if(ch==false)
		            {
		                return false;
		            }
		        }	       
		        
		    }
		    
		function fnValidate()
		    {
		        var i=-1;
				var myArr= new Array();
				
			    myArr[++i]= new Array(document.getElementById('<%=DD_Course.ClientID%>'),"0","Select "+document.getElementById('ctl00_ContentPlaceHolder1_lblCr').innerText,"select");
			    //myArr[++i]= new Array(document.getElementById('<%=DD_CoursePart.ClientID%>'),"-1","Select "+document.getElementById('ctl00_ContentPlaceHolder1_lblCr').innerText+" Part","select");
			    
				var ret=validateMe(myArr,50);
				return ret;
		    }
		    
	    function openNewWindow(RefUniID, RefInstID, RefYearID, RefStudID, UniId, InstID, Year, StudID,FacID, CrID, MoLrnID, PtrnID, BrnID, CrPrDetailsID)
	        {
    	      
	            var ElgFormNo = RefUniID+'-'+RefInstID+'-'+RefYearID+'-'+RefStudID;
                window.open("ELGV2_BulkProcess_reg_Students__2.aspx?ElgFormNo="+ElgFormNo+"&UniID="+UniId+"&InstID="+InstID+"&Year="+Year+"&StudID="+StudID+"&FacID="+FacID+"&CrID="+CrID+"&MoLrnID="+MoLrnID+"&PtrnID="+PtrnID+"&BrnID="+BrnID+"&CrPrDetailsID="+CrPrDetailsID+"","_blank","height=300,width=700,status=yes,toolbar=no,menubar=no,location=no,scrollbars =yes,left=250,top=300,screenX=0,screenY=400'");
    	        
	            return false;
	        }
	    
		function fnCheck()
		    {		        
		        var bul=false;
		        var retval = false;
		        if(document.getElementById('ctl00_ContentPlaceHolder1_DG_University1') != null)
		        {
		            var tbl=document.getElementById('ctl00_ContentPlaceHolder1_DG_University1').getElementsByTagName("INPUT");
		            for(i=1;i<tbl.length;i++)
		            {
		                if(tbl[i].checked )
		                {
		                   bul=true;
					       break;
		                }
		            }
		            if(document.getElementById('ctl00_ContentPlaceHolder1_rdProvisionalEligible').checked== true)
                     {
                        if(document.getElementById('ctl00_ContentPlaceHolder1_txtReason').value == "")
                        {
                            alert('Please Enter a Valid Reason for keeping the Eligibility of Student Provisional');
                            document.getElementById('ctl00_ContentPlaceHolder1_txtReason').focus();
                            return false;
                        }
                    }
                    if(document.getElementById('ctl00_ContentPlaceHolder1_rdProvisionalEligible').checked== false && document.getElementById('ctl00_ContentPlaceHolder1_rdEligible').checked== false)
                   { 
                            alert('Please select a Eligibility Status for processing the Students in Bulk');
                            return false;
                    }
                    
               		        		        
		        if(bul)
		        { 
		            return true;
		           
				}
			    else
			    {
				    alert("To process Eligibility of the students please select checkboxes from the list below and click on save button");
				    return false;
				}
			
               }
		        
		    }
		    
		function fnSelectAllStudents(cbID) //Function used to select all Student IDs on one click
            {                                     
                var tbl = document.getElementById('ctl00_ContentPlaceHolder1_DG_University1');
                var len = document.getElementById('ctl00_ContentPlaceHolder1_DG_University1').rows.length ;
                var colno;
//                if(document.getElementById('ctl00_ContentPlaceHolder1_rbWithoutInv').checked == true)
//                    colno = 4;
//                else
                    colno = 4;
                
                if(document.getElementById(cbID).checked)
                {               
                    for(var i = 1; i < len; i++)
                    {
                        var cell = tbl.rows[i].cells[colno];
                        var inputElements = cell.getElementsByTagName('input');

                        for (var j=0; j< inputElements.length; j++)
                        {      
                            if (inputElements[j].type =="checkbox")
                            {
                                inputElements[j].checked = true;
                            }
                        }
                    }
                }
                else
                {
                    for(var i = 1; i < len; i++)
                    {
                        var cell = tbl.rows[i].cells[colno];
                        var inputElements = cell.getElementsByTagName('input');

                        for (var j=0; j< inputElements.length; j++)
                        {      
                            if (inputElements[j].type =="checkbox")
                            {
                                inputElements[j].checked = false;
                            }
                        }
                    }
                }
            }
       
        function fnProvElgClick(flag)
        {            
            if(flag == 'PE')
            {
                document.getElementById('trReason').style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_txtReason').focus();
                                 
            }
            if(flag == 'E')
            {
                document.getElementById('trReason').style.display = "none";
            }
                document.getElementById('ctl00_ContentPlaceHolder1_txtReason').value = "";
        }
        
        function fnFilterClick(flag)
        {            
            if(flag == 'Y')
            {
                document.getElementById('ctl00_ContentPlaceHolder1_trDecision').style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_trDecisionPRN').style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_trDecision').focus();
               
                                 
            }
            if(flag == 'N')
            {
                document.getElementById('ctl00_ContentPlaceHolder1_trDecision').style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_trDecisionPRN').style.display = "none";
            }
            document.getElementById('ctl00_ContentPlaceHolder1_txtFirstName').value = "";
            document.getElementById('ctl00_ContentPlaceHolder1_txtLastName').value = "";
            document.getElementById('ctl00_ContentPlaceHolder1_txtPRN').value = "";
        }
        
        	//validate course
               function validateCourse()
	            {	
	                var i=-1;
	                var crPart=document.getElementById("<%=DD_CoursePart.ClientID%>");
	                 var crPartTerm=document.getElementById("<%=DD_CoursePartTerm.ClientID%>");
	                var myArr = new Array();  		    
	                myArr[++i]  = new Array(document.getElementById("<%=DD_Course.ClientID%>"),"0","Please Select "+ document.getElementById('<%=lblCr.ClientID %>').innerText +".","select");
	                myArr[++i]  = new Array(crPart,"-1","Please Select "+ document.getElementById('<%=lblCr.ClientID %>').innerText +" Part.","select");
	                 myArr[++i]  = new Array(crPartTerm,"-1","Please Select "+ document.getElementById('<%=lblCr.ClientID %>').innerText +" Part Term.","select");
	                var ret=validateMe(myArr,50); 	                                
	                return ret;
	            }		
	            
	            	function ClearDropDowns(part, term)
                    {                    
                        if(part==1)
			                ClearDropDownList(document.getElementById('<%=DD_CoursePart.ClientID%>'));   
			            if(term==1)
			                ClearDropDownList(document.getElementById('<%=DD_CoursePartTerm.ClientID%>'));     					 
                    }          
	        
                    function ClearDropDownList(ddlObject)
                    { 
                        
                        while(ddlObject.length > 1)
	                    {
        	                  ddlObject.remove(1);
                    	      
	                    }    	     
                    }
	            
	            
	            function ChkValidationPRN()
	            {
	                    
	                  var obPRN = document.getElementById("<%=txtPRN.ClientID%>").value;
	                  
		              var myArr=new Array();
		              var innerRet=true;
		              var j=-1;
		              
		              document.getElementById("<%= hidSSVal.ClientID%>").value="1";
            		  
		              
	                if(obPRN.length > 0)
	                {
            		    innerRet = checkdigitPRN_Nomenclature(obPRN, document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText,document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value);
                    }
                    return innerRet;
	            }
                
    </script>

    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="0">
            <tr>
                <%--<td class="FormName" align="left" valign="middle">
                    <asp:Label ID="lblTitle" runat="server" CssClass="lblPageHead" Font-Bold="True" meta:resourcekey="lblTitleResource1">Bulk Process Data</asp:Label>
                    <asp:Label ID="lblInstName" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="lblInstNameResource1"></asp:Label>--%>
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" Text="Bulk Process Data" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                    <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="True" Font-Size="Small"
                        meta:resourcekey="lblAcademicYearResource1"></asp:Label></td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <%--<p style="margin: 0px 5px" align="left">--%>
                        <table border="0" width="95%" style="border-collapse: collapse; display: none" id="tblLink"
                            runat="server">
                            <tr>
                                <td class="InnerLinkBorder" valign="middle" align="center">
                                    <font style="font-size: 2pt">&nbsp;</font></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:LinkButton ID="lnkSelectCr" CssClass="NavLink" runat="server" Enabled="False"
                                        OnClick="lnkSelectCr_Click" meta:resourcekey="lnkSelectCrResource1" Text="Select Course">Select Course</asp:LinkButton>&nbsp;|&nbsp;
                                    <asp:LinkButton ID="lnkPRN" CssClass="NavLink" runat="server" Enabled="False" OnClick="lnkPRN_Click"
                                        meta:resourcekey="lnkPRNResource1" Text="View Eligible Students with PRN">View Eligible Students with PRN</asp:LinkButton>
                                </td>
                            </tr>
                            <%--<tr>
                                <td id="TDLink" style="display: none" runat="server">
                                </td>
                            </tr>--%>
                        </table>
                        <table cellspacing="1" cellpadding="0" width="95%" border="0" id="tblToolBarMain"
                            runat="server">
                            <tr>
                                <td>
                                    <table class="ToolBar" id="tblToolBar" cellspacing="1" cellpadding="0" width="100%"
                                        border="0" runat="server">
                                        <tr>
                                            <td align="center" width="15%">
                                                <img height="16" src="../images/button_new.gif" width="16" border="0">
                                                <asp:Button ID="btnNew" runat="server" CssClass="But" Text="New" OnClick="btnNew_Click"
                                                    meta:resourcekey="btnNewResource1"></asp:Button></td>
                                            <td align="center" width="15%">
                                                <img height="16" src="../images/button_save.gif" width="16" border="0">
                                                <asp:Button ID="btnSave" runat="server" CssClass="But" Text="Save" OnClick="btnSave_Click"
                                                    Enabled="False" meta:resourcekey="btnSaveResource1"></asp:Button></td>
                                            <td align="center" width="15%">
                                                <img height="16" src="../images/button_delete.gif" width="16" border="0">
                                                <asp:Button ID="btnDelete" runat="server" CssClass="But" Text="Delete" Enabled="False"
                                                    meta:resourcekey="btnDeleteResource1"></asp:Button></td>
                                            <td align="center" width="7%">
                                                &nbsp;</td>
                                            <td align="center" width="10%">
                                                <img height="16" src="../images/button_reset.gif" width="16" border="0"><input class="But"
                                                    title="Reset" accesskey="R" tabindex="4" type="reset" value="Reset" name="Reset"></td>
                                            <td align="right">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="95%" cellpadding="0" cellspacing="0" border="0" id="Table2" runat="server">
                            <tr>
                                <td>
                                    <div id="divAcademicYr" runat="server">
                                        <fieldset id="tblAcademicYr" style="height: 100px; width: 603px;" align="center"
                                            runat="server">
                                            <legend><b>Select Academic Year </b></legend>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td style="height: 15px;" colspan="3">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="height: 20px; width: 125px;">
                                                        <asp:Label ID="lblAcyr" runat="server" Font-Bold="True" Width="221px" meta:resourcekey="lblAcyrResource1">Select Academic Year</asp:Label></td>
                                                    <td align="center" style="height: 20px; width: 1%;">
                                                        <b>&nbsp;:&nbsp;</b></td>
                                                    <td align="left" id="tdAcdYr" runat="server">
                                                        <asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="selectbox" Width="151px"
                                                            meta:resourcekey="ddlAcademicYrResource1">
                                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">--- Select ---</asp:ListItem>
                                                        </asp:DropDownList><font class="Mandatory">*</font></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px;" colspan="3">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="10" align="center">
                                                        <asp:Button ID="btnAcYr" Text="Submit" CssClass="butSubmit" runat="server" Width="100px"
                                                            OnClick="btnAcYr_Click" meta:resourcekey="btnAcYrResource1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px;" colspan="3">
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table width="95%" cellpadding="0" cellspacing="0" border="0" id="tblUserControl"
                            runat="server">
                        </table>
                        <table width="95%" cellpadding="0" cellspacing="0" border="0" id="tblMainTable" runat="server">
                            <tr>
                                <td align="left" colspan="3" height="5px">
                                    <asp:Label ID="lblSave" runat="server" CssClass="saveNote" meta:resourcekey="lblSaveResource1"></asp:Label></td>
                            </tr>
                            <tr id="trCourse" runat="server">
                                <td>
                                    <div id="DivCorseSelection" runat="server" style="display: none">
                                        <fieldset>
                                            <legend>Select <%= lblCr.Text%></legend>
                                            <table width="100%">
                                                <%--<tr class="clSubHeading" width="100%">
                                                    <td class="PersonalTableHeader" valign="top" align="left" colspan="5">
                                                        <b>Select
                                                            <%= lblCr.Text%>
                                                        </b>
                                                    </td>
                                                </tr>--%>
                                                <tr height="10px">
                                                    <td width="23%" align="right">
                                                        <b><%= lblCr.Text%>
                                                        </b>
                                                    </td>
                                                    <td width="1%">
                                                        <b>:</b></td>
                                                    <td height="10px" align="left">
                                                        <asp:DropDownList ID="DD_Course" Width="460px" runat="server" CssClass="selectbox"
                                                            onchange="setValue(document.getElementById(hidCrClientID).id,this.value);FetchCourseWiseCoursePartList('tbCrPr',document.getElementById(hidUniClientID).value, document.getElementById(hidInstClientID).value,document.getElementById(hidCrClientID).value,'ctl00_ContentPlaceHolder1_DD_CoursePart'),ClearDropDowns(1,1);"
                                                            meta:resourcekey="DD_CourseResource1">
                                                        </asp:DropDownList>
                                                        <font class="Mandatory">*</font></td>
                                                </tr>
                                                <tr>
                                                    <td width="23%" align="right">
                                                        <b><%= lblCr.Text%>
                                                            Part</b></td>
                                                    <td width="1%">
                                                        <b>:</b></td>
                                                    <td height="10px" id="tbCrPr" align="left">
                                                        <asp:DropDownList ID="DD_CoursePart" Width="230px" runat="server" CssClass="selectbox" onchange="setValue(document.getElementById(hidCrPrClientID).id,this.value);FetchCoursePartWiseCoursePartChildList('tbCrPrCh',document.getElementById(hidUniClientID).value, document.getElementById(hidInstClientID).value,document.getElementById(hidFacClientID).value+'-'+document.getElementById(hidCrClientID).value+'-'+document.getElementById(hidMoLrnClientID).value+'-'+document.getElementById(hidPtrnClientID).value+'-'+document.getElementById(hidBrnClientID).value+'-'+document.getElementById(hidCrPrClientID).value,'ctl00_ContentPlaceHolder1_DD_CoursePartTerm'),ClearDropDowns(0,1);"
                                                            meta:resourcekey="DD_CoursePartResource1">
                                                            <asp:ListItem Value="-1" meta:resourcekey="ListItemResource1">--- Select ---</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <font class="Mandatory">*</font></td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" align="right">
                                                        <b><%= lblCr.Text%>
                                                            Part Term</b></td>
                                                    <td width="1%">
                                                        <b>:</b></td>
                                                    <td height="10px" id="tbCrPrCh" align="left">
                                                        <asp:DropDownList ID="DD_CoursePartTerm" Width="230px" runat="server" CssClass="selectbox" onchange="setCrPartTerm(this.value);"
                                                            meta:resourcekey="DD_CoursePartTermResource1">
                                                            <asp:ListItem Value="-1" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <font class="Mandatory">*</font></td>
                                                </tr>
                                                <t<%--r height="10px">
                                                    <td width="23%" align="right">
                                                        <b>Consider Payment Status</b></td>
                                                    <td width="1%">
                                                        <b>:</b></td>
                                                    <td align="left">
                                                        <asp:RadioButton ID="rbWithInv" Text="Yes"
                                                            GroupName="grpInvoice" runat="server" />
                                                        <asp:RadioButton ID="rbWithoutInv" Text="No"
                                                            GroupName="grpInvoice" runat="server" Checked="True" />
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td colspan="3" height="10px">
                                                    </td>
                                                </tr>
                                                <tr id="trbtnProcessData" runat="server" style="display: none;">
                                                    <td colspan="3" align="center" style="height: 15px">
                                                        <asp:Button ID="btnProcessData" runat="server" CssClass="butSubmit" BorderWidth="1px"
                                                            BorderStyle="Solid" Text="Submit" Height="18px" OnClick="btnProcessData_Click" Width="70px"
                                                            meta:resourcekey="btnProcessDataResource1" OnClientClick="return validateCourse()" />
                                                    </td>
                                                </tr>
                                                <%-- <tr id="trbtnProcessData" runat="server" style="display:none;">
                                                <td colspan="3" align=center style="height: 15px">
                                                    <asp:Button ID="btnProcessData" runat="server" CssClass="butSubmit" BorderWidth="1px"
									                BorderStyle="Solid" Text="Submit" Height="18px" OnClick="btnProcessData_Click" meta:resourcekey="btnProcessDataResource1"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" height="10px"></td>
                                            </tr>
                                             <tr>
                                                <td align="center" colspan="3" height="10px">
                                                    <asp:Label ID="lblRights" runat="server" Font-Bold="True" CssClass="errorNote" meta:resourcekey="lblRightsResource1"></asp:Label></td>
                                            </tr>--%>
                                            </table>
                                        </fieldset>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            
                            <tr>
                                <td colspan="3" height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" height="10px">
                                    <asp:Label ID="lblRights" runat="server" Font-Bold="True" CssClass="errorNote" meta:resourcekey="lblRightsResource1"></asp:Label></td>
                            </tr>
                            <tr>
                                <td height="5px">
                                </td>
                            </tr>
                            <tr id="trStatistics" runat="server" style="display: none">
                                <td>
                                    <fieldset>
                                        <legend><strong>Statistics of Records</strong></legend>
                                        <table width="100%">
                                            <%--<tr class="clSubHeading" width="80%">
                                                <td class="PersonalTableHeader" valign="top" align="left" colspan="5">
                                                    <b>Statistics of Records</b></td>
                                            </tr>--%>
                                            <tr>
                                                <td colspan="4" style="height: 15px">
                                                    <p style="margin: 0px 35px" align="left">
                                                        <asp:Label ID="lblStatistics" runat="server" CssClass="errorNote" meta:resourcekey="lblStatisticsResource1"></asp:Label></p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center">
                                                    <table id="tblStatistics" width="90%" border="0" style="border-collapse: collapse;
                                                        display: none" cellpadding="0" runat="server">
                                                        <tr>
                                                            <td width="40%" align="center" height="20px" class="gridHeader">
                                                                <b>Eligibility Process</b></td>
                                                            <td width="30%" align="center" height="20px" class="gridHeader">
                                                                <b>No. of students<br />
                                                                    (Eligibility payment received)</b></td>
                                                            <td width="30%" align="center" height="20px" class="gridHeader">
                                                                <b>No. of students<br />
                                                                    (Eligibility payment not received)</b></td>
                                                        </tr>
                                                        <tr class="gridItem">
                                                            <td height="20px">
                                                                Students whose eligibility is to be decided by
                                                                <%=lblUniversity.Text.ToLower()%>
                                                            </td>
                                                            <td align="center" height="20px">
                                                                <asp:Label ID="lblUniCount" runat="server" meta:resourcekey="lblUniCountResource1"></asp:Label></td>
                                                            <td align="center" height="20px">
                                                                <asp:Label ID="lblNonPaidUniCount" runat="server" meta:resourcekey="lblNonPaidUniCountResource1"></asp:Label></td>
                                                        </tr>
                                                        <tr class="gridAltItem">
                                                            <td class="gridAltItem" height="20px">
                                                                Students eligible at
                                                                <%=lblCollege.Text.ToLower() %>
                                                            </td>
                                                            <td class="gridAltItem" align="center" height="20px">
                                                                <asp:Label ID="lblCollCount" runat="server" meta:resourcekey="lblCollCountResource1"></asp:Label></td>
                                                            <td class="gridAltItem" align="center" height="20px">
                                                                <asp:Label ID="lblNonPaidCollCount" runat="server" meta:resourcekey="lblNonPaidCollCountResource1"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" height="25px" align="center">
                                                                <asp:Label ID="lblNoRecords" runat="server" CssClass="errorNote" meta:resourcekey="lblNoRecordsResource1"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr id="trStatisticsWithoutInv" runat="server" style="display: none">
                                <td>
                                    <fieldset>
                                        <legend><strong>Statistics of Records</strong></legend>
                                        <table width="100%">
                                           <%-- <tr class="clSubHeading" width="80%">
                                                <td class="PersonalTableHeader" valign="top" align="left" colspan="5">
                                                    <b>Statistics of Records</b></td>
                                            </tr>--%>
                                            <tr>
                                                <td colspan="4" style="height: 15px">
                                                    <p style="margin: 0px 35px" align="left">
                                                        <asp:Label ID="Label1" runat="server" CssClass="errorNote" meta:resourcekey="Label1Resource1"></asp:Label></p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center">
                                                    <table id="tblStatistics1" width="90%" border="0" style="border-collapse: collapse;
                                                        display: none" cellpadding="0" runat="server">
                                                        <tr>
                                                            <td width="50%" align="center" height="20px" class="gridHeader">
                                                                <b>Eligibility Process</b></td>
                                                            <td width="40%" align="center" height="20px" class="gridHeader">
                                                                <b>No. of students<br />
                                                                </b>
                                                            </td>
                                                        </tr>
                                                        <tr class="gridItem">
                                                            <td height="20px" align="left">
                                                                Students whose eligibility is to be decided by
                                                                <%= lblUniversity.Text.ToLower() %>
                                                            </td>
                                                            <td align="left" height="20px">
                                                                <asp:Label ID="lblUniCount1" runat="server" meta:resourcekey="lblUniCount1Resource1"></asp:Label></td>
                                                        </tr>
                                                        <tr class="gridItem">
                                                            <td height="20px" align="left">
                                                                Students eligible at
                                                                <%=lblCollege.Text.ToLower() %>
                                                            </td>
                                                            <td align="left" height="20px">
                                                                <asp:Label ID="lblCollCount1" runat="server" meta:resourcekey="lblCollCount1Resource1"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" height="25px" align="center">
                                                                <asp:Label ID="lblNoRecords1" runat="server" CssClass="errorNote" meta:resourcekey="lblNoRecords1Resource1"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr id="trfilter" runat="server" style="display: none">
                                <td>
                                    <fieldset id="fldFilter" runat="server">
                                        <table align="center" width="85%">
                                            <tr>
                                                <td align="right" style="width: 300px">
                                                    <b>Do you want to use Student Search Filters : </b>
                                                </td>
                                                <td align="left">
                                                    <asp:RadioButton ID="rbFilterYes" Text="Yes" GroupName="grpyesno" runat="server"
                                                        onclick="fnFilterClick('Y');" meta:resourcekey="rbFilterYesResource1" />
                                                    <asp:RadioButton ID="rbFilterNo" Text="No" GroupName="grpyesno" runat="server" onclick="fnFilterClick('N');"
                                                        Checked="True" meta:resourcekey="rbFilterNoResource1" />
                                                </td>
                                            </tr>
                                            <tr id="trDecision" style="display: none" runat="server">
                                                <td align="right">
                                                    <b>Last Name :</b></td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="inputbox" meta:resourcekey="txtLastNameResource1"></asp:TextBox></td>
                                                <td align="right">
                                                    <b>First Name :</b></td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputbox" meta:resourcekey="txtFirstNameResource1"></asp:TextBox></td>
                                            </tr>
                                            <tr id="trDecisionPRN" runat="server">
                                                <td align="right">
                                                    <b>
                                                        <asp:Label ID="lblPRNNumber" runat="server" Text="PRN Number" meta:resourcekey="lblPRNNumberResource1"></asp:Label></b>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtPRN" runat="server" CssClass="inputbox" meta:resourcekey="txtPRNResource1"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <asp:Button ID="btnFilterSubmit" CssClass="butSubmit" Text="Submit" runat="server"
                                                        Width="70px" Height="18px" OnClick="btnFilterSubmit_Click" OnClientClick="return ChkValidationPRN();" meta:resourcekey="btnFilterSubmitResource1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr id="trGrids" runat="server" style="display: none">
                                <td>
                                    <fieldset id="fldEligibility" runat="server">
                                        <table align="center" width="85%">
                                            <tr>
                                                <td style="width: 300px" align="right">
                                                    <b>Mark the selected students as:</b></td>
                                                <td align="left">
                                                    <asp:RadioButton ID="rdEligible" Text="Eligible" GroupName="grpEligibility"
                                                        runat="server" onclick="fnProvElgClick('E');" meta:resourcekey="rdEligibleResource1" />
                                                    <asp:RadioButton ID="rdProvisionalEligible" Text="Provisionally Eligible" GroupName="grpEligibility"
                                                        runat="server" onclick="fnProvElgClick('PE');" meta:resourcekey="rdProvisionalEligibleResource1" />
                                                </td>
                                            </tr>
                                            <tr id="trReason" style="display: none;">
                                                <td style="width: 300px" align="right">
                                                    <b>Reason(s) for marking selected students as Provisionally Eligible:</b></td>
                                                <td>
                                                    <asp:TextBox ID="txtReason" runat="server" CssClass="textarea" Height="30px" Width="400px"
                                                        TextMode="MultiLine" meta:resourcekey="txtReasonResource1"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <fieldset>
                                        <table id="tblGrid" width="100%" style="display: none" runat="server">
                                            <tr class="clSubHeading" width="80%">
                                                <td class="PersonalTableHeader" valign="top" align="left" colspan="5">
                                                    <asp:Label ID="lblUniCollPrn" runat="server" Font-Bold="True" meta:resourcekey="lblUniCollPrnResource1"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <br />
                                                    <p style="margin: 0px 10px" align="left">
                                                        <asp:Label ID="lblUnselectCheck" runat="server" Font-Bold="True" meta:resourcekey="lblUnselectCheckResource1"></asp:Label></p>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <asp:GridView ID="DG_University1" runat="server" Width="95%" AutoGenerateColumns="False"
                                                        Visible="False" AllowPaging="True" DataKeyNames="pk_Student_ID" AllowSorting="True"
                                                        meta:resourcekey="DG_UniversityResource1" PageSize="50" OnPageIndexChanging="DG_University1_PageIndexChanging"
                                                        OnRowCommand="DG_University1_RowCommand" OnRowDataBound="DG_University1_RowDataBound"
                                                        OnSorting="DG_University1_Sorting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <%# (Container.DataItemIndex)+1 %>
                                                                        <center>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="EligibilityFormNo" HeaderText="Eligibility Form No." SortExpression="EligibilityFormNo"
                                                                meta:resourcekey="BoundFieldResource1">
                                                                <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign="Center">
                                                                </HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pk_Invoice_ID" HeaderText="Invoice Number" meta:resourcekey="BoundFieldResource2">
                                                                <HeaderStyle Font-Bold="True" Width="10%" CssClass="gridHeader" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="PRN Number" DataField="PRN" SortExpression="PRN" meta:resourcekey="BoundFieldResource3">
                                                                <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign="Center">
                                                                </HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="studName" HeaderText="Name of Student" SortExpression="studName"
                                                                meta:resourcekey="BoundFieldResource4">
                                                                <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign="Center">
                                                                </HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Select" meta:resourcekey="TemplateFieldResource2">
                                                                <ItemStyle Wrap="False" HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox runat="server" ID="chkSelect" Name="chkSelect" meta:resourcekey="chkSelectResource1" />
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" Width="5%" />
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblSelect" runat="server" Font-Bold="True" Text="Select" meta:resourcekey="lblSelectResource1"></asp:Label>
                                                                    <asp:CheckBox ID="cbSelectAll" runat="server" onclick="fnSelectAllStudents(this.id);"
                                                                        meta:resourcekey="cbSelectAllResource1" />
                                                                </HeaderTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="pk_Uni_ID" HeaderText="pk_Uni_ID" meta:resourcekey="BoundFieldResource5">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pk_Year" HeaderText="pk_Year" meta:resourcekey="BoundFieldResource6">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="InstID" HeaderText="pk_Institute_ID" meta:resourcekey="BoundFieldResource7">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pk_Student_ID" HeaderText="pk_Student_ID" meta:resourcekey="BoundFieldResource8">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pk_Fac_ID" HeaderText="pk_Fac_ID" meta:resourcekey="BoundFieldResource9">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pk_Cr_ID" HeaderText="pk_Cr_ID" meta:resourcekey="BoundFieldResource10">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pk_MoLrn_ID" HeaderText="pk_MoLrn_ID" meta:resourcekey="BoundFieldResource11">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pk_Ptrn_ID" HeaderText="pk_Ptrn_ID" meta:resourcekey="BoundFieldResource12">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pk_Brn_ID" HeaderText="pk_Brn_ID" meta:resourcekey="BoundFieldResource13">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="pk_CrPr_Details_ID" HeaderText="pk_CrPr_Details_ID" meta:resourcekey="BoundFieldResource14">
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <RowStyle CssClass="gridItem" />
                                                        <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>
                                                        <HeaderStyle CssClass="gridHeader" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblPRN" runat="server" Font-Bold="True" meta:resourcekey="lblPRNResource1"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <asp:GridView ID="DG_PRN1" runat="server" Width="95%" AutoGenerateColumns="False"
                                                        Visible="False" PageSize="20" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="DG_PRN1_PageIndexChanging"
                                                        OnRowDataBound="DG_PRN1_RowDataBound" OnSorting="DG_PRN1_Sorting" meta:resourcekey="DG_PRN1Resource1">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource3">
                                                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <%# (Container.DataItemIndex)+1 %>
                                                                        <center>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="EligibilityFormNo" HeaderText="Eligibility Form No." SortExpression="EligibilityFormNo"
                                                                meta:resourcekey="BoundFieldResource15">
                                                                <HeaderStyle Font-Bold="True" Width="15%" CssClass="gridHeader" HorizontalAlign="Center">
                                                                </HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="StudName" HeaderText="Name of Student" SortExpression="StudName"
                                                                meta:resourcekey="BoundFieldResource16">
                                                                <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign="Center">
                                                                </HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Eligibility" HeaderText="Eligibility" meta:resourcekey="BoundFieldResource17">
                                                                <HeaderStyle Font-Bold="True" Width="5%" CssClass="gridHeader" HorizontalAlign="Center">
                                                                </HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="EligibilityStatus" HeaderText="Eligibility Status" SortExpression="EligibilityStatus"
                                                                meta:resourcekey="BoundFieldResource18">
                                                                <HeaderStyle Font-Bold="True" Width="15%" CssClass="gridHeader" HorizontalAlign="Center">
                                                                </HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="PRN_Number" HeaderText="PRN Number" SortExpression="PRN_Number"
                                                                meta:resourcekey="BoundFieldResource19">
                                                                <HeaderStyle Font-Bold="True" Width="15%" CssClass="gridHeader" HorizontalAlign="Center">
                                                                </HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Reason" HeaderText="Reason" meta:resourcekey="BoundFieldResource20">
                                                                <HeaderStyle Font-Bold="True" Width="20%" CssClass="gridHeader" HorizontalAlign="Center">
                                                                </HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <RowStyle CssClass="gridItem" />
                                                        <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>
                                                        <HeaderStyle CssClass="gridHeader" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                        <input id="hidInstID" style="width: 24px; height: 22px" type="hidden" name="hidInstID"
                            runat="server" />
                        <input id="hidUniID" style="width: 24px; height: 22px" type="hidden" name="hidUniID"
                            runat="server" />
                        <input id="hid_Year" style="width: 24px; height: 22px" type="hidden" name="hid_Year"
                            runat="server" />
                        <input id="hidStudentID" style="width: 24px; height: 22px" type="hidden" name="hidStudentID"
                            runat="server" />
                        <input id="hidFacID" style="width: 24px; height: 22px" type="hidden" name="hidFacID"
                            runat="server" />
                        <input id="hidCrID" style="width: 24px; height: 22px" type="hidden" name="hidCrID"
                            runat="server" />
                        <input id="hidMoLrnID" style="width: 24px; height: 22px" type="hidden" name="hidMoLrnID"
                            runat="server" />
                        <input id="hidPtrnID" style="width: 24px; height: 22px" type="hidden" name="hidPtrnID"
                            runat="server" />
                        <input id="hidBrnID" style="width: 24px; height: 22px" type="hidden" name="hidBrnID"
                            runat="server" />
                        <input id="hidCrPrID" style="width: 24px; height: 22px" type="hidden" name="hidCrPrID"
                            runat="server" />
                        <input id="hidCrPrChID" type="hidden" name="hidCrPrChID" runat="server" />
                        <input id="hidYear" style="width: 24px; height: 22px" type="hidden" name="hidYear"
                            runat="server" />
                        <input id="hidCollege_Eligibility_Flag" style="width: 24px; height: 22px" type="hidden"
                            name="hidCollege_Eligibility_Flag" runat="server" />
                        <input id="hidRightsFlag" style="width: 24px; height: 22px" type="hidden" name="hidRightsFlag"
                            runat="server" />
                        <input id="hidElgFormNo" style="width: 24px; height: 22px" type="hidden" name="hidElgFormNo"
                            runat="server" />
                        <input id="hid_fk_AcademicYr_ID" runat="server" name="hid_fk_AcademicYr_ID" value=""
                            type="hidden" />
                        <input id="hid_AcademicYear" runat="server" name="hid_AcademicYear" value="" type="hidden" />
                         <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
                        <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
                        <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
                            meta:resourcekey="lblUniversityResource1"></asp:Label>
                        <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
                        <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none"
                            meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>
                                    
                        <input id="hidSSVal" type="hidden" value="1" runat="server" />

                            
                   <%-- </p>--%>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
