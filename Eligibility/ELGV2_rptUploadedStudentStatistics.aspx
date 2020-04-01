<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_rptUploadedStudentStatistics.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_rptUploadedStudentStatistics"
    %>

<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>
<%@ Register Src="WebCtrl/SelectSingleCourse.ascx" TagName="YCMOU" TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/jsAjaxMethod.js"></script>

    <script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>

    <script type="text/javascript" language="jscript" src="../jscript/calendar.js"> </script>

    <script type="text/javascript" language="jscript" src="../jscript/calendar-en.js"> </script>

    <script type="text/javascript" language="javascript" src="../jscript/InitCalendarFunc.js"> </script>

    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>

    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>

    <script type="text/javascript" src="../../ajax/StudentRegistration.Eligibility.clsEligibilityDBAccess,StudentRegistration.ashx"></script>

    <%-- <script language="javascript" type="text/javascript">
//             var result=false;    
//             var collTxt;
//             var alert1=false;
//        
//   	         var hidAcademicYr = '<%= ddlAcademicYr.ClientID%>';
//       	     
//       	     var hidFacClientID = '<%=hidFacID.ClientID%>';
//		     var hidCrClientID = '<%=hidCrID.ClientID%>';
//		     var hidMoLrnClientID = '<%=hidMoLrnID.ClientID%>';
//		     var hidPtrnClientID = '<%=hidPtrnID.ClientID%>';
//		     var hidBrnClientID = '<%=hidBrnID.ClientID%>';	
//		     var hidCrPrDetailsIDClientID = '<%=hidCrPrDetailsID.ClientID%>';	
//		     var hidCrPrChIDClientID = '<%=hidCrPrChID.ClientID%>';	
//    		  	  
//		     var hidUniClientID = '<%=hidUniID.ClientID%>';
//    		 
//		     var ddlFacDescClient = '<%=ddlFacDesc.ClientID%>';
//		     var ddlCrDescClient = '<%=ddlCrDesc.ClientID%>';		 
//		     var ddlCrBrnDescClient = '<%=ddlCrBrnDesc.ClientID%>';
//		     var ddlCrPrDetailsDescClient = '<%=ddlCrPrDetailsDesc.ClientID%>';
//		     var ddlCrPrChDescClient = '<%=ddlCrPrChDesc.ClientID%>';
//		     var hidLevelFlagClient = '<%=hidLevelFlag.ClientID%>';
//		     var hidCourseDetailsClientID = '<%=hidCourseDetails.ClientID%>';		 
//       
//         function fnClearSearchCriteria()
//	     {			
//				ddlFacDescClient.value = "-1";
//				ddlCrDescClient.value = "-1";
//				ddlCrBrnDescClient.value = "-1";
//				ddlCrPrDetailsDescClient.value = "-1";
//				ddlCrPrChDescClient.value = '-1';	
//								
//		 }		
//			   
//       
//        function showPDF()
//        {
//            window.open("rptUploadedStudentStatisticsPDF.aspx");
//        }       
//    
//        function callvaliadteAcademic()
//		{      
//		       if(document.getElementById(hidAcademicYr)[document.getElementById(hidAcademicYr).selectedIndex].text== "--- Select ---")
//		       {
//		            alert("Please Select Academic Year");
//		                return false;
//		       }
//		                
//		       else
//		       return true;		       
//		 } 	 
//			
//			
//            
//            function fnCheck()
//		    {
//		        var bul=false;
//		        var retval = false;
//		        if(document.getElementById('ctl00_ContentPlaceHolder1_dgData') != null)
//		        {
//		            var tbl=document.getElementById('ctl00_ContentPlaceHolder1_dgData').getElementsByTagName("INPUT");
//		            for(i=0;i<tbl.length;i++)
//		            {
//		                if(tbl[i].checked)
//		                {
//		                   bul=true;
//					       break;
//		                }
//		            }
//		               		        
//		            if(bul)
//		            { 
//		                return true;
//    		           
//				    }
//				}
//			    else
//			    {
//				    alert("To View the Uploaded Statistics Report please select checkboxes to select the Colleges/Institutes/Study Centers from the list below and click on Next button");
//				    return false;
//				}		        
//               
//              }
//               
//               //validate academic year
//               function validateYear()
//	            {
//	                var flag=false;
//	                var i=-1;
//	                var myArr = new Array();  		    
//	                myArr[++i]  = new Array(document.getElementById("<%= ddlAcademicYr.ClientID%>"),"0","Please Select Academic Year.","select");
//	                var ret=validateMe(myArr,50); 
//	                flag=ret;
//	                if(flag)
//	                {
//	                    document.getElementById("<%= fldAllInst.ClientID%>").style.display="block";
//	                }	                
//	                return false;
//	            }
//	            
//               
//  
//		//filling college code corr to selection in coll dropdown
//		function fillCollegeCode(code)
//		{			    
//		     var arr=new Array();
//		     arr=code.split('|');
//		     
//		     if(document.getElementById("<%=ddlCollegeName.ClientID%>").selectedIndex==0)
//		        document.getElementById("<%=Collcode.ClientID%>").value = "";	  
//		     else          
//		        document.getElementById("<%=Collcode.ClientID%>").value = arr[1];
//		     if(arr[1]=="")
//		     {
//		        document.getElementById("<%=Collcode.ClientID%>").value = "-";
//		     }
//		     		
//		}
//		
//		//select coll drop on tab press in coll code textbox
//		function allowTab(sender, e) 
//        {
//	        if (e.keyCode == 9)
//	        {
//	        
//	            var typedCode=sender.value.toUpperCase();
//	            var collDD= document.getElementById("<%=ddlCollegeName.ClientID%>");
//	            setSelectedIndex(collDD,typedCode); 	            
//		            return false;
//	        }	        
//	        else
//	        {
//		        return true;
//	        }
//        }
//               
//             //select corr value in college dropdown
//             function setSelectedIndex(dropdown, valueToSelect) 
//             { 
//                var codeFlag=false;
//                var myArr   = new Array(); 
//                var count=0;
//                var addToDDText=new Array(); 
//                var addToDDValue=new Array();                  

//                for(var i = 0; i < dropdown.options.length; i++) 
//                {
//                    if (dropdown.options[i].value.split('|')[1] == valueToSelect ) 
//                    {
//                        codeFlag=true;
//                        addToDDText.push(dropdown.options[i].text);
//                        addToDDValue.push(dropdown.options[i].value);
//                        count++;                        
//                    }
//                }
//                if(codeFlag)
//                {
//                    if(count==1)
//                    {
//                        for(var i = 0; i < dropdown.options.length; i++) 
//                        {
//                                if ( dropdown.options[i].value.split('|')[1] == valueToSelect ) 
//                                {
//                                    dropdown.options[i].selected = true;
//                                    dropdown.focus();
//                                    return;
//                                }
//                        }
//                    }
//                    
//                    //if multiple coll corr to a code
//                    if(count>1)
//                    {
//                        //adding select as an option in dd
//                        dropdown.options.length=0;
//                        var opt = document.createElement("option");  
//                        opt.text = "--Select--";
//                        opt.value ="0";
//                        dropdown.options.add(opt); 
//                           
//                        //adding the multiple colleges as items
//                        for(var k=0;k<count;k++)
//                        {                            
//                            var opt = document.createElement("option");  
//                            opt.text = addToDDText[k];
//                            opt.value = addToDDValue[k];
//                            opt.title=opt.text;                                                     
//                            dropdown.options.add(opt);  
//                        } 
//                        
//                        dropdown.focus();              
//                    }
//                }
//                else
//                {
//                    if(alert1)
//                    {
//                        document.getElementById("<%=Collcode.ClientID%>").value = "";
//                        var j=-1;
//                        myArr[++j]  = new Array(document.getElementById("<%= Collcode.ClientID%>"),"Empty","Please Enter a Valid "+document.getElementById('<%=lblCollege.ClientID%>').innerText+" Code","text");
//                        document.getElementById("<%=ddlCollegeName.ClientID%>").selectedIndex=0;
//                        var ret=validateMe(myArr,50);
//                    }
//                }
//             }
//             
//             //validate next click for selected college report
//             function validateFinalNext()
//             { 
//                 var collDD= document.getElementById("<%=ddlCollegeName.ClientID%>");
//                 collTxt=document.getElementById("<%= Collcode.ClientID%>").value.toUpperCase();                
//                 var IndexValue = collDD.selectedIndex;
//                 var collTB=document.getElementById("<%= Collcode.ClientID%>");
//                 var flag=false;
//                 var i=-1; 
//		         var myArr   = new Array(); 
//		         myArr[++i]  = new Array(document.getElementById("<%= ddlAcademicYr.ClientID%>"),"0","Please Select Academic Year.","select");
//                 if(document.getElementById("<%= divCollege.ClientID%>").style.display!='none')
//                 {
//                     
//                     if(collDD.selectedIndex==0 && document.getElementById("<%= Collcode.ClientID%>").value=="")
//                     {
//                        myArr[++i]  = new Array(document.getElementById("<%= Collcode.ClientID%>"),"Empty","Please Enter an "+document.getElementById('<%=lblCollege.ClientID%>').innerText+" Code.","text");
//    		         }
//    		            myArr[++i]  = new Array(document.getElementById("<%= ddlCollegeName.ClientID%>"),"0","Please Select an "+document.getElementById('<%=lblCollege.ClientID%>').innerText+" Name.","select");
//    		           	collTB.focus();
//		         }
//                    var ret=validateMe(myArr,50);     	
//	                return ret; 
//	             
//             }
//             
//             //callback function for list colleges
//             function ListColleges_callback(response)
//             {         
//                var dt=response.value;
//                var flag=false;
//                if(dt.Rows.length > 0)
//                {              
//                    for(var j=0;j<dt.Rows.length;j++)
//                    {
//                        if(dt.Rows[j].Inst_Code==collTxt)
//                        {
//                            flag=true;
//                            break;
//                        }
//                    } 
//                    if(flag)
//                    {
//                        result=true;
//                    }                   
//                }                
//            
//             }

//             
//             //validate next click for all colleges report
//             function courseValidate()
//             {	
//                    var i=-1; 
//		            var myArr   = new Array(); 
//		            myArr[++i]  = new Array(document.getElementById("<%=ddlAcademicYr.ClientID%>"),"0","Please Select Academic Year.","select");
//                    myArr[++i]  = new Array(document.getElementById("<%=ddlFacDesc.ClientID%>"),-1,"Please Select "+document.getElementById('<%=lblFacultyNm.ClientID%>').innerText,"select"); 
//	                myArr[++i]  = new Array(document.getElementById("<%=ddlCrDesc.ClientID%>"),-1,"Please Select "+document.getElementById('<%=lblSelectCr.ClientID%>').innerText,"select"); 
//	                if(document.getElementById("<%=ddlCrDesc.ClientID%>")[document.getElementById("<%=ddlCrDesc.ClientID%>").selectedIndex].text=="--- Select ---")
//	                myArr[++i]  = new Array(document.getElementById("<%=ddlCrDesc.ClientID%>"),0,"Please Select "+document.getElementById('<%=lblSelectCr.ClientID%>').innerText,"select"); 

//		            if(document.getElementById("<%=ddlCrBrnDesc.ClientID%>")[document.getElementById("<%=ddlCrBrnDesc.ClientID%>").selectedIndex].text!= "No Branch Available")
//		                myArr[++i]= new Array(document.getElementById("<%=ddlCrBrnDesc.ClientID%>"),-1,"Please Select Branch","select"); 
//		            myArr[++i] = new Array(document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>"),-1,"Please Select " + document.getElementById('<%=lblSelectCr.ClientID%>').innerText + " Part", "select");
//		            myArr[++i] = new Array(document.getElementById("<%=ddlCrPrChDesc.ClientID%>"),-1, "Please Select " + document.getElementById('<%=lblSelectCr.ClientID%>').innerText + " Part Child", "select");
//    		       	if(document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>")[document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>").selectedIndex].text=="--- Select ---")
//    		       	    myArr[++i] = new Array(document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>"),0,"Please Select " + document.getElementById('<%=lblSelectCr.ClientID%>').innerText + " Part", "select");
//		            if(document.getElementById("<%=ddlCrPrChDesc.ClientID%>")[document.getElementById("<%=ddlCrPrChDesc.ClientID%>").selectedIndex].text=="--- Select ---")
//		                myArr[++i] = new Array(document.getElementById("<%=ddlCrPrChDesc.ClientID%>"),0, "Please Select " + document.getElementById('<%=lblSelectCr.ClientID%>').innerText + " Part Child", "select");

//    		        var ret=validateMe(myArr,50); 
//    		        alert1=ret;
//	                return ret;
//	        }
//			
//			
//			//toggle between all and selected colleges
//			function showAllOrSelectCollegeDiv()
//	        {	           
//	                if(document.getElementById("<%=rdAllColleges.ClientID %>").checked)
//	                {
//	                    document.getElementById("<%=rdSelectedColleges.ClientID %>").checked=false;
//	                    document.getElementById("<%=divCourse.ClientID %>").style.display='block';
//	                    document.getElementById("<%=divCollege.ClientID %>").style.display='none';	                    
//	                    var collDD= document.getElementById("<%=ddlCollegeName.ClientID%>");
//                        collDD.selectedIndex='0';
//                        document.getElementById("<%=Collcode.ClientID%>").value='';
//                        document.getElementById("<%=BtnSubmit.ClientID %>").style.display='block';
//                        document.getElementById("<%=btnSubmitSelectedCollege.ClientID %>").style.display='none';  
//                        document.getElementById("<%=tblExportedDataMsg.ClientID %>").style.display='none';  
//                                                                    
//	                    
//	                }
//	                else if(document.getElementById("<%=rdSelectedColleges.ClientID %>").checked)
//	                {
//	                    document.getElementById("<%=rdAllColleges.ClientID %>").checked=false;
//	                    document.getElementById("<%=divCourse.ClientID %>").style.display='none';
//	                    document.getElementById("<%=divCollege.ClientID %>").style.display='block';
//	                    document.getElementById("<%=BtnSubmit.ClientID %>").style.display='none';
//	                    document.getElementById("<%=btnSubmitSelectedCollege.ClientID %>").style.display='block';	
//	                    document.getElementById("<%=tblExportedDataMsg.ClientID %>").style.display='none';  
//	                                         
//	                }
//	                
//	        }
//	        
//	        //to show and hide inner cascading grid - for row databound method
//	        function switchViews(obj,row)
//            {            
//                 var div = document.getElementById(obj);
//                 var img = document.getElementById('img' + obj);
//                    
//                    if (div.style.display=="none")
//                        {
//                            div.style.display = "inline";
//                            if (row=='alt')
//                               {
//                                   img.src="../Images/plus.gif";
//                               }
//                           else
//                               {
//                                   img.src="../Images/minus.gif";
//                               }
//                           img.alt = "Click to hide details";
//                       }
//                   else
//                       {
//                           div.style.display = "none";
//                           if (row=='alt')
//                               {
//                                   img.src="../Images/minus.gif";
//                               }
//                           else
//                               {
//                                   img.src="../Images/plus.gif";
//                               }
//                           img.alt = "Click to show details";
//                       }
//               }             
//                 
//               function  resetDropDown()
//               {                
//                var collDropDown=document.getElementById("<%=ddlCollegeName.ClientID %>");               
//	            
//	            var typedCode=document.getElementById("<%=Collcode.ClientID %>").value.toUpperCase();                
//                collDropDown.selectedIndex="0"; 
//                collDropDown.options.length=0;
//                var dt=clsAjaxMethods.FillCollegeList();
//                       var opt = document.createElement("option");  
//                       opt.text = "--- Select---";
//                       opt.value =  "0";                     
//                       collDropDown.options.add(opt);                   
//                    for(var l=0;l<dt.value.Rows.length;l++)
//                    {                            
//                       var opt = document.createElement("option");  
//                       opt.text = dt.value.Rows[l].Inst_Name+","+dt.value.Rows[l].Inst_City;
//                       opt.value =  dt.value.Rows[l].pk_Inst_ID+"|"+dt.value.Rows[l].Inst_Code; 
//                       opt.title=opt.text;                                                  
//                       collDropDown.options.add(opt);  
//                    } 
//                    setSelectedIndex(collDropDown,typedCode); 	              
//               }
			
    </script>--%>
    <%--<style type="text/css">
        .clOff
        {
            display:none;
        }
        
        .DataGridFixedHeader

        {
        font-weight: bold;
        vertical-align:middle;
        font-family: Verdana; 
        text-align:center;
	    font-size: 8pt;
	    font-weight:bold; 
	    color:#000000;
	    background-color:#EEE8AA; /*#E3E3A4;*/
	    padding-left:5px;
	    border:solid 1px;
	    border-color:#B2B2A9;
        position: absolute;
        top: expression(this.offsetParent.scrollDown);
        }
        
        .DataGridHeaderText

        {
        font-weight: normal;       
        font-family: Verdana; 
        text-align:center;
	    font-size: 8pt;	    
	    color:#000000;	   
        }        

    </style>
    <style type="text/css">
            
        .Freezing 
        { 
           position:relative ; 
           top:expression(this.offsetParent.scrollTop); 
           z-index: 10; 
        }
        </style>--%>
    <style type="text/css">
      .hidden-column {
        display: none;
      }
       </style>
    <asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
            <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
                border="0" width="700">
                <tr style="width: 700">
                    <td class="FormName" align="left" width="100%">
                        <asp:Label ID="lblPageHead" runat="server" Font-Bold="True" Text="Uploaded Statistics Report for"
                            meta:resourcekey="lblPageHeadResource2"></asp:Label>
                        <asp:Label ID="lblAcaYear" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="lblAcaYearResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left">
                        <%-- <div id="divAcademicYr" runat="server" style="azimuth: center; margin-left: 30PX;
                            width: 90%;">
                            &nbsp;&nbsp
                            <div id="tblAcademicYr" runat="server" align="center">
                                <table cellspacing="0" cellpadding="2px" width="100%" border="0">
                                    <tr>
                                        <td style="height: 20px;" colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 20px; width: 225px;">
                                            <asp:Label ID="lblAcyr" runat="server" Font-Bold="True" Width="221px" meta:resourcekey="lblAcyrResource1"
                                                Text="Select Academic Year"></asp:Label></td>
                                        <td align="center" style="height: 20px; width: 1%;">
                                            <b>&nbsp;:&nbsp;</b></td>
                                        <td align="left" id="tdAcdYr" runat="server" style="height: 20px">
                                            <asp:DropDownList ID="ddlAcademicYr" runat="server" CssClass="selectbox" Width="296px"
                                                meta:resourcekey="ddlAcademicYrResource1">
                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                            </asp:DropDownList><font class="Mandatory">*</font></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div id="fldAllInst" runat="server" style="azimuth: center; margin-left: 30PX; width: 90%;
                            display: none" align="center">
                            <table cellspacing="0" cellpadding="2" align="center" border="0" width="100%">
                                <tr>
                                    <td align="right" style="width: 225px;">
                                        <asp:Label ID="lblViewRptFor" runat="server" Font-Bold="True" Width="221px" Text="Uploaded Statistics Report for"
                                            meta:resourcekey="lblViewRptForResource1"></asp:Label>
                                    </td>
                                    <td align="center" style="width: 1%;">
                                        <b>&nbsp;:&nbsp;</b></td>
                                    <td align="left">
                                        <asp:RadioButton ID="rdAllColleges" Text=" All Colleges" Checked="True" GroupName="grpColleges"
                                            runat="server" align="left" onclick="showAllOrSelectCollegeDiv()" meta:resourcekey="rdAllCollegesResource2" />
                                        <asp:RadioButton ID="rdSelectedColleges" Text="Selected College" GroupName="grpColleges"
                                            runat="server" onclick="showAllOrSelectCollegeDiv()" meta:resourcekey="rdSelectedCollegesResource2" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table id="divCourse" runat="server" style="azimuth: center; margin-left: 30PX; width: 90%;
                            display: none">
                            <tr runat="server">
                                <td runat="server">
                                    <div id="tblCourse" runat="server" style="azimuth: center;">
                                        <table cellpadding="2px" cellspacing="0" width="100%" border="0">
                                            <tr>
                                                <td align="right" style="height: 20px; width: 125px;">
                                                    <b>
                                                        <asp:Label ID="Label1" runat="server" Text="Select Faculty Name" meta:resourcekey="Label1Resource1"
                                                            Width="221px"></asp:Label></b></td>
                                                <td align="center" style="height: 20px; width: 1%;">
                                                    <b>&nbsp;:&nbsp;</b></td>
                                                <td style="height: 20px" colspan="3" align="left">
                                                    <asp:DropDownList ID="ddlFacDesc" runat="server" OnSelectedIndexChanged="ddlFacDesc_SelectedIndexChanged"
                                                        CssClass="selectbox" Width="245px" AutoPostBack="True">
                                                        <asp:ListItem Value="-1" meta:resourcekey="ListItemResource2" Text="--- Select ---"></asp:ListItem>
                                                    </asp:DropDownList><font class="Mandatory">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <b>
                                                        <asp:Label ID="lblSelectCrName" runat="server" Text="Select Course Name" meta:resourcekey="lblSelectCrNameResource1"></asp:Label></b></td>
                                                <td align="center">
                                                    <b>:</b></td>
                                                <td id="tdCrDesc" colspan="3" align="left">
                                                    <asp:DropDownList ID="ddlCrDesc" runat="server" OnSelectedIndexChanged="ddlCrDesc_SelectedIndexChanged"
                                                        CssClass="selectbox" meta:resourcekey="ddlCrDescResource1" AutoPostBack="True">
                                                        <asp:ListItem Value="-1" meta:resourcekey="ListItemResource3" Text="--- Select ---"></asp:ListItem>
                                                    </asp:DropDownList><font class="Mandatory">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr id="trCrBrn">
                                                <td align="right">
                                                    <strong>
                                                        <asp:Label ID="lblSelCrBranch" runat="server" Text="Select Course Branch" meta:resourcekey="lblSelCrBranchResource1"></asp:Label></strong></td>
                                                <td align="center">
                                                    <b>:</b></td>
                                                <td id="tdCrBrnDesc" colspan="3" align="left">
                                                    <asp:DropDownList ID="ddlCrBrnDesc" OnSelectedIndexChanged="ddlCrBrnDesc_SelectedIndexChanged"
                                                        runat="server" CssClass="selectbox" meta:resourcekey="ddlCrBrnDescResource1"
                                                        AutoPostBack="True">
                                                        <asp:ListItem Value="-1" meta:resourcekey="ListItemResource6" Text="--- Select ---"></asp:ListItem>
                                                    </asp:DropDownList><font class="Mandatory">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <b>
                                                        <asp:Label ID="Label2" runat="server" Text="Select Course Part" meta:resourcekey="Label2Resource1"></asp:Label></b></td>
                                                <td align="center">
                                                    <b>:</b></td>
                                                <td id="tdCrPrDesc" colspan="3" align="left">
                                                    <asp:DropDownList ID="ddlCrPrDetailsDesc" OnSelectedIndexChanged="ddlCrPrDetailsDesc_SelectedIndexChanged"
                                                        runat="server" CssClass="selectbox" meta:resourcekey="ddlCrPrDetailsDescResource1"
                                                        AutoPostBack="True">
                                                        <asp:ListItem Value="-1" meta:resourcekey="ListItemResource16" Text="--- Select ---"></asp:ListItem>
                                                    </asp:DropDownList><font class="Mandatory">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <b>
                                                        <asp:Label ID="Label3" runat="server" Text="Select Course Part Term" meta:resourcekey="Label3Resource1"></asp:Label></b></td>
                                                <td align="center" style="width: 1%">
                                                    <b>:</b></td>
                                                <td id="tdCrPrChDesc" colspan="3" align="left">
                                                    <asp:DropDownList OnSelectedIndexChanged="ddlCrPrChDesc_SelectedIndexChanged" ID="ddlCrPrChDesc"
                                                        runat="server" CssClass="selectbox" meta:resourcekey="ddlCrPrChDescResource1"
                                                        AutoPostBack="True">
                                                        <asp:ListItem Value="-1" meta:resourcekey="ListItemResource17" Text="--- Select ---"></asp:ListItem>
                                                    </asp:DropDownList><font class="Mandatory">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="height: 24px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <center>
                            <div id="divCollege" runat="server" style="display: none; width: 90%">
                                <table cellpadding="0" cellspacing="0" border="0" style="azimuth: center;" width="100%">
                                    <tr>
                                        <td align="right" style="height: 38px; width: 225px">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Select College" meta:resourcekey="Label4Resource1"></asp:Label></td>
                                        <td align="center" style="height: 38px; width: 1%;">
                                            <b>&nbsp;:&nbsp; </b>
                                        </td>
                                        <td align="left" style="height: 38px; width: 4%">
                                            <asp:TextBox ID="Collcode" runat="server" onblur="resetDropDown()" CssClass="inputbox" Width="40px" MaxLength="300"
                                                meta:resourcekey="CollcodeResource1" onkeydown="return allowTab(this, event)"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td align="left" style="height: 38px;">
                                            <asp:DropDownList ID="ddlCollegeName" runat="server" Width="250px" CssClass="selectbox"
                                                onchange="fillCollegeCode(this.value);" meta:resourcekey="ddlCollegeNameResource1">
                                            </asp:DropDownList><font class="Mandatory">*</font>
                                        </td>
                                        <td style="height: 38px">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </center>
                        <center>
                            <asp:Button ID="BtnSubmit" Text="Next &gt;&gt;" CssClass="butSubmit" OnClientClick="return courseValidate()"
                                runat="server" OnClick="btnNext_Click" meta:resourcekey="BtnSubmitResource1" />
                        </center>
                        <br />
                        <center>
                            <asp:Button runat="server" ID="btnSubmitSelectedCollege" Text="Next &gt;&gt;" CssClass="butSubmit"
                                OnClientClick="return validateFinalNext()" Style="display: none" OnClick="btnNext_Click"
                                meta:resourcekey="btnSubmitSelectedCollegeResource1" /></center>--%>
                        <br />
                        <div id="divYCMOU" runat="server">
                            <uc3:YCMOU ID="YCMOU" runat="server"></uc3:YCMOU>
                        </div>
                        <table id="tblExportedDataMsg" runat="server" width="100%" style="display: none">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" style="height: 30px;" align="left" runat="server">
                                    <asp:Label runat="server" ID="lblExportedData" CssClass="errorNote" meta:resourcekey="lblExportedDataResource1"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <center>
                            
                            <div id="DivCollegeUploadInfo" runat="server" style="display: none; width: 100%">
                                &nbsp;&nbsp
                                <fieldset id="tblSelect" align="left" runat="server">
                                    <legend>Admissions submitted Statistics</legend>
                                    <table style="text-align:left">
                                        <tr>
                                            <td align="left">
                                                Total No of
                                                <%=lblCollege.Text%>
                                                (s) Admissions submitted Data : <asp:Label ID="lblNoOfCollege" runat="server" meta:resourcekey="lblNoOfCollegeResource1" Font-Bold="true"></asp:Label>
                                            </td>
                                           <%-- <td style="text-align: left">
                                                
                                            </td>--%>
                                        </tr>
                                        <tr>
                                           <%-- <td align="right">
                                                Total No of
                                                <%=lblCollege.Text%>
                                                (s) Not Uploaded Data :
                                            </td>--%>
                                            <td style="text-align: left" colspan="2">
                                                <asp:LinkButton ID="LinkcollegeNotUploaded" runat="server" OnClick="LinkcollegeNotUploaded_Click"
                                                    BackColor="White" ForeColor="Red"
                                                    Text="Click Here"></asp:LinkButton>&nbsp;
                                                <asp:Label ID="lblClickCount" runat="server">to see the list of <%=lblCollege.Text%>s who have not submitted the Admission data</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Total No of Admissions submitted Students : <asp:Label ID="lblTotalNoOfStudent"  Font-Bold="true" runat="server" meta:resourcekey="lblTotalNoOfStudentResource1"></asp:Label>
                                            </td>
                                            <%--<td style="text-align: left; height: 15px;">
                                                </td>--%>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                            <table id="tblExportToExcel" runat="server" style="display: none; width: 100%; width: 530px;"
                                align="center">
                                <tr id="Tr2" runat="server">
                                    <td id="Td2" style="height: 6px" runat="server">
                                        &nbsp;</td>
                                </tr>
                                <tr id="Tr3" runat="server">
                                    <td id="Td3" align="center" runat="server">
                                        <asp:Button ID="btnExportToExcel" runat="server" Text="Export to Excel" CssClass="butSubmit"
                                            OnClick="btnExportToExcel_Click" meta:resourcekey="btnExportToExcelResource1" />
                                    </td>
                                </tr>
                                <tr id="Tr4" runat="server">
                                    <td id="Td4" style="height: 6px" runat="server">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </center>
                        <!-- Grids for all colleges one course -->
                        <div id="divDGStat" style="display: none; margin-left: 2px; width: 99%; position: relative;"
                            runat="server">
                            <asp:GridView ID="GVStat" runat="server" AutoGenerateColumns="False" DataKeyNames="pk_Inst_ID"
                                CssClass="clGrid grid-view" OnRowDataBound="GVStat_RowDataBound" CellPadding="2"
                                EnableViewState="True" OnSorted="GVStat_Sorted" OnSorting="GVStat_Sorting" BorderStyle="None"
                                meta:resourcekey="GVStatResource1" OnRowCommand="GVStat_RowCommand" Width="100%"
                                ShowFooter="true" Style="border-style: Double; border-collapse: collapse;">
                                <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                                <RowStyle CssClass="gridItem" />
                                <Columns>
                                    <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                                        <ItemStyle Width="4%" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkPlus" CommandName="showHide" EnableViewState="true"
                                                CommandArgument='<%# Eval("pk_Inst_ID") %>'>
                                                <asp:Image ID="imgdiv" AlternateText="Click to show details" ImageUrl="../Images/plus.gif"
                                                    runat="server" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RegionalCenterInfo" HeaderText="Regional Center"  meta:resourcekey="BoundFieldResourceRegInfo">
                                        <ItemStyle Width="30px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="College Code" HeaderText="College Code" meta:resourcekey="BoundFieldResource27">
                                        <ItemStyle Width="30px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="College Name" HeaderText="College Name" SortExpression="College Name"
                                        meta:resourcekey="BoundFieldResource28">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                                            Width="30%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total Intake Capacity" HeaderText="Total Intake Capacity"
                                        meta:resourcekey="BoundFieldResource30">
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total uploaded data" HeaderText="Data Uploaded (No of Students)"
                                        SortExpression="Total uploaded data" meta:resourcekey="BoundFieldResource31">
                                        <ItemStyle Width="25px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total Eligibility Processed" HeaderText="Eligibility Processed Count"
                                        SortExpression="Total Eligibility Processed" meta:resourcekey="BoundFieldResource32">
                                        <ItemStyle Width="25px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Eligiblity not processed" HeaderText="Eligiblity Not Processed"
                                        SortExpression="Eligiblity not processed" meta:resourcekey="BoundFieldResource33">
                                        <ItemStyle Width="25px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EligiblityNotRequiredToBeProcessed" HeaderText="Eligiblity Not Required to be Processed"
                                        SortExpression="EligiblityNotRequiredToBeProcessed" meta:resourcekey="BoundFieldResource499">
                                        <ItemStyle Width="30px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Duplicate Student Count" HeaderText="Duplicate Student Count"
                                        SortExpression="Duplicate Student Count" meta:resourcekey="BoundFieldResource34">
                                        <ItemStyle Width="25px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Paper Discrepancy Count" HeaderText="Paper Discrepancy Count"
                                        SortExpression="Paper Discrepancy Count" meta:resourcekey="BoundFieldResource35">
                                        <ItemStyle Width="25px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField meta:resourcekey="TemplateFieldResource3" ItemStyle-CssClass="hidden-column"
                                        HeaderStyle-CssClass="hidden-column">
                                        <ItemTemplate>
                                            <tr>
                                                <td colspan="9">
                                                    <div align="center" id="divHideMeCourse" style="display: none; position: relative;
                                                        width: 100%;" runat="server">
                                                        <div id="divCourseInnerHide" runat="server" style="display: none; left: 10px;">
                                                            <br />
                                                            <asp:GridView ID="GVInner" runat="server" AutoGenerateColumns="False" OnRowDataBound="GVInner_RowDataBound"
                                                                Width="94%" EnableViewState="True" OnSorted="GVStat_Sorted" BorderStyle="None"
                                                                CssClass="clGrid grid-view" meta:resourcekey="GVInnerResource1" Style="border-color: #FFD275;
                                                                display: none; border-style: Double; border-collapse: collapse;">
                                                                <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                                                                <RowStyle CssClass="gridItem" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Eligible" HeaderText="Eligible (PRN Generated)" SortExpression="Eligible (PRN Generated)"
                                                                        meta:resourcekey="BoundFieldResource39">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Not Eligible" HeaderText="Not Eligible" SortExpression="Not Eligible"
                                                                        meta:resourcekey="BoundFieldResource40">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Pending" HeaderText="Pending" SortExpression="Pending"
                                                                        meta:resourcekey="BoundFieldResource41">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Provisional" HeaderText="Provisional" SortExpression="Provisional"
                                                                        meta:resourcekey="BoundFieldResource42">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Invoice Generated" HeaderText="Eligibility Fee Invoices Generated"
                                                                        SortExpression="Eligibility Fee Invoices Generated" meta:resourcekey="BoundFieldResource36">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Invoice Processed" HeaderText="Eligibility Fee Invoices Processed"
                                                                        SortExpression="Eligibility Fee Invoices Processed" meta:resourcekey="BoundFieldResource37">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Invoice not processed" HeaderText="Eligibility Fee Invoices Not Processed"
                                                                        SortExpression="Eligibility Fee Invoices Not Processed" meta:resourcekey="BoundFieldResource38">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                        <br />
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="Large" />
                            </asp:GridView>
                        </div>
                        <!-- Grid for one college all courses -->
                        <div id="dgCollege" style="display: none; margin-left: 2px; width: 100%; position: relative;
                            border-collapse: collapse" runat="server">
                            <asp:GridView ID="GVOuterCollege" runat="server" AutoGenerateColumns="False" DataKeyNames="Course Name,pk_Fac_ID,pk_Cr_ID,pk_MoLrn_ID,pk_Ptrn_ID,pk_Brn_ID,fk_CrPr_Details_ID,pk_CrPrCh_ID"
                                OnRowDataBound="GVOuterCollege_RowDataBound" EnableViewState="True" BorderStyle="None"
                                CssClass="clGrid grid-view" Width="100%" ShowFooter="true" meta:resourcekey="GVOuterCollegeResource1"
                                OnRowCommand="GVOuterCollege_RowCommand">
                                <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                                <RowStyle CssClass="gridItem" />
                                <Columns>
                                    <asp:TemplateField meta:resourcekey="TemplateFieldResource4">
                                        <ItemStyle Width="4%" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkPlusCollege" CommandName="showHide" EnableViewState="true"
                                                CommandArgument='<%# Eval("Course Name") %>'>
                                                <asp:Image ID="imgdiv" AlternateText="Click to show details" ImageUrl="../Images/plus.gif"
                                                    runat="server" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Course Name" HeaderText="Course Name" SortExpression="Course Name"
                                        meta:resourcekey="BoundFieldResource43">
                                        <ItemStyle Width="35%" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total Intake Capacity" HeaderText="Total Intake Capacity"
                                        meta:resourcekey="BoundFieldResource44">
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total uploaded data" HeaderText="Data Uploaded (No of Students)"
                                        SortExpression="Total uploaded data" meta:resourcekey="BoundFieldResource45">
                                        <ItemStyle Width="80px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total Eligibility Processed" HeaderText="Eligibility Processed Count"
                                        SortExpression="Total Eligibility Processed" meta:resourcekey="BoundFieldResource46">
                                        <ItemStyle Width="30px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Eligiblity not processed" HeaderText="Eligiblity Not Processed"
                                        SortExpression="Eligiblity not processed" meta:resourcekey="BoundFieldResource47">
                                        <ItemStyle Width="30px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EligiblityNotRequiredToBeProcessed" HeaderText="Eligiblity Not Required to be Processed"
                                        SortExpression="EligiblityNotRequiredToBeProcessed" meta:resourcekey="BoundFieldResource499">
                                        <ItemStyle Width="30px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Duplicate Student Count" HeaderText="Duplicate Student Count"
                                        SortExpression="Duplicate Student Count" meta:resourcekey="BoundFieldResource48">
                                        <ItemStyle Width="30px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Paper Discrepancy Count" HeaderText="Paper Discrepancy Count"
                                        SortExpression="Paper Discrepancy Count" meta:resourcekey="BoundFieldResource49">
                                        <ItemStyle Width="35px" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField meta:resourcekey="TemplateFieldResource5" ItemStyle-CssClass="hidden-column"
                                        HeaderStyle-CssClass="hidden-column">
                                        <ItemTemplate>
                                            <tr>
                                                <td colspan="8">
                                                    <div align="center" id="divHideMe" style="display: none; position: relative; width: 100%;"
                                                        runat="server">
                                                        <div id="divCourseInnerHide" runat="server" style="display: none; left: 10px;">
                                                            <br />
                                                            <asp:GridView ID="GVInnerCollege" runat="server" AutoGenerateColumns="False" OnRowDataBound="GVInner_RowDataBound"
                                                                CssClass="clGrid grid-view" Width="94%" EnableViewState="True" OnSorted="GVStat_Sorted"
                                                                Style="border-color: #FFD275; display: none; border-style: Double; border-collapse: collapse;"
                                                                meta:resourcekey="GVInnerCollegeResource1">
                                                                <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                                                                <RowStyle CssClass="gridItem" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Eligible" HeaderText="Eligible (PRN Generated)" SortExpression="Eligible (PRN Generated)"
                                                                        meta:resourcekey="BoundFieldResource53">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Not Eligible" HeaderText="Not Eligible" SortExpression="Not Eligible"
                                                                        meta:resourcekey="BoundFieldResource54">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Pending" HeaderText="Pending" SortExpression="Pending"
                                                                        meta:resourcekey="BoundFieldResource55">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Provisional" HeaderText="Provisional" SortExpression="Provisional"
                                                                        meta:resourcekey="BoundFieldResource56">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Invoice Generated" HeaderText="Eligibility Fee Invoices Generated"
                                                                        SortExpression="Eligibility Fee Invoices Generated" meta:resourcekey="BoundFieldResource50">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Invoice Processed" HeaderText="Eligibility Fee Invoices Processed"
                                                                        SortExpression="Eligibility Fee Invoices Processed" meta:resourcekey="BoundFieldResource51">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Invoice Not Processed" HeaderText="Eligibility Fee Invoices Not Processed"
                                                                        SortExpression="Eligibility Fee Invoices Not Processed" meta:resourcekey="BoundFieldResource52">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                        <br />
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <ItemStyle BorderWidth="2px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle HorizontalAlign="Left" Font-Bold="true" Font-Size="Large" />
                            </asp:GridView>
                        </div>
                        <br />
                        <br />
                        <input id="hidInstID" runat="server" style="width: 24px; height: 22px" type="hidden" />
                        <input id="hid_fk_AcademicYr_ID" runat="server" style="width: 24px; height: 22px"
                            type="hidden" />
                        <input id="hid_AcademicYear" runat="server" style="width: 24px; height: 22px" type="hidden" />
                        <input id="hid_strAcademicYr1" runat="server" value="" type="hidden" />
                        <input id="hid_strAcademicYr2" runat="server" value="" type="hidden" />
                        <input id="hidCountryId" style="width: 24px; height: 22px" type="hidden" value="0"
                            runat="server" />
                        <input id="hidCntry" style="width: 24px; height: 22px" type="hidden" value="0" runat="server" />
                        <input id="hidStateID" style="width: 24px; height: 22px" type="hidden" value="0"
                            runat="server" />
                        <input id="hidDistrictID" style="width: 24px; height: 22px" type="hidden" value="0"
                            runat="server" />
                        <input id="hidTehsilID" style="width: 24px; height: 22px" type="hidden" value="0"
                            runat="server" />
                        <input id="hidCourseDetails" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidUniID" style="width: 24px; height: 22px" type="hidden" runat="server" />
                        <input type="hidden" runat="server" id="hidregisterationInfo" />
                        <input id="hidCollCode" style="width: 24px; height: 22px" type="hidden" runat="server" />
                        <input id="hidFacID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidFacText" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidCrID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidCrText" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidMoLrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidMoLrnText" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidPtrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidPtrnText" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidBrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidCrPrDetailsID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidCrPrChID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidBrnText" runat="server" style="width: 32px; height: 22px" type="hidden" />
                        <input id="hidLevelFlag" runat="server" value="" type="hidden" />
                        <input id="hidCollName" runat="server" type="hidden" />
                        <input id="hidAcYrName" runat="server" type="hidden" />
                        <input id="hidFacName" runat="server" type="hidden" />
                        <input id="hidCrName" runat="server" type="hidden" />
                        <input id="hidBrName" runat="server" type="hidden" />
                        <input id="hidCrPrName" runat="server" type="hidden" />
                        <input id="hidCrPrDetName" runat="server" type="hidden" />
                        <input id="hidCrPrChName" runat="server" type="hidden" />
                        <input id="hidAllInstChkStatus" type="hidden" runat="server" />
                        <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
                        <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
                            meta:resourcekey="lblUniversityResource1"></asp:Label>
                        <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
                        <asp:Label ID="lblSelectCr" runat="server" Text="Course" meta:resourcekey="lblSelectCrResource1"
                            Style="display: none"></asp:Label>
                        <asp:Label ID="lblFacultyNm" Style="display: none" runat="server" Text="Faculty Name"
                            meta:resourcekey="lblFacultyNmResource1"></asp:Label>
                        <asp:Label ID="lblFaculty" Style="display: none" runat="server" Text="Faculty" meta:resourcekey="lblFacultyResource1"></asp:Label>
                    </td>
                    <asp:Label ID="lblPaper" runat="server" Text="Paper" meta:resourcekey="lblPaperResource1"
                        Style="display: none"></asp:Label>
                    <input id="hidRCName" runat="server" type="hidden" />
                    <input id="hidRCID" runat="server" type="hidden" />
                </tr>
            </table>
            <%-- </center>--%>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="ddlFacDesc" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlCrDesc" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlCrBrnDesc" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlCollegeName" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlCrPrDetailsDesc" EventName="SelectedIndexChanged" />           
            <asp:AsyncPostBackTrigger ControlID="ddlCrPrChDesc" EventName="SelectedIndexChanged" />--%>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
            <asp:PostBackTrigger ControlID="LinkcollegeNotUploaded" />
        </Triggers>
    </asp:UpdatePanel>
    <%--<table cellspacing="0" cellpadding="0" width="700" border="0">
        <tr>
            <td valign="bottom" width="700" colspan="2" align="left">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        &nbsp;<img src="../Images/mozilla_blu.gif" /><span style="color: #0066cc">Getting data...
                        </span>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>--%>
    <table>
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </table>
</asp:Content>
