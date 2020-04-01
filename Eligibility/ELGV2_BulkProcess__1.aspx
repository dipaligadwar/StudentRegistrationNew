<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_BulkProcess__1.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_BulkProcess__1" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register TagPrefix="uc1" TagName="StudentsAdvancedSearch" Src="WebCtrl/StudentsAdvancedSearch.ascx" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/jsAjaxMethod.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/CommonFunctions.js"></script>

    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>

    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>

    <script language="javascript" type="text/javascript">
		
		 var uniid;		
		 uniid = <%=Classes.clsGetSettings.UniversityID%>;
		 var TdBodyClientID = '<%=TdBodyID.ClientID%>';
		 var hid_StateClientID = '<%=hid_StateID.ClientID%>';
		 var hid_BodyClientID = '<%=hid_BodyID.ClientID%>';
		 var Body_StateClient = '<%=Body_State.ClientID%>';
		 var Body_IDClient = '<%=Body_ID.ClientID%>';
		 var hidInstClientID = '<%=hidInstID.ClientID %>';
		 var hidFacClientID = '<%=hidFacID.ClientID%>';
		 var hidCrClientID = '<%=hidCrID.ClientID%>';
		 var hidMoLrnClientID = '<%=hidMoLrnID.ClientID%>';
		 var hidPtrnClientID = '<%=hidPtrnID.ClientID%>';
		 var hidBrnClientID = '<%=hidBrnID.ClientID%>';
		 var hidCrPrClientID = '<%=hidCrPrID.ClientID%>';	 
		 var hidUniClientID = '<%=hidUniID.ClientID%>';	
         var hidCountryIDForeignClientID = '<%=hidCountryIDForeign.ClientID %>';
		 //var DD_CoursePart = '<%=DD_CoursePart.ClientID%>';
		
		
		 function callvaliadteAcademic()
		{      
		        var i=-1;
				var myArr= new Array();
							
				myArr[++i]= new Array(document.getElementById('<%= ddlAcademicYear.ClientID%>'),"0","Select Academic Year","select"); 					
				 
				var ret=validateMe(myArr,50);
		        return ret;
		        
		        
		 } 
		
		function setValue(Text,Value)
			{
				var text = eval(document.getElementById(Text));
				text.value = Value;				
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
	            document.getElementById('<%=hidCrPrID.ClientID%>').value = val;
	            //document.getElementById('ctl00_ContentPlaceHolder1_hidCrPrID').value = val;
	            
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
		      		      
		        
				document.getElementById('ctl00_ContentPlaceHolder1_rbFilterYesNo_1').checked = true;
				document.getElementById('ctl00_ContentPlaceHolder1_rbFilterYesNo_0').checked = false;				
				document.getElementById('ctl00_ContentPlaceHolder1_tblStatistics').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_trfilter').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_trGrids').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_trStatistics').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_lblRights').style.display = "none";
			//	document.getElementById('ctl00_ContentPlaceHolder1_trStatisticsWithoutInv').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_DivFilterExamBody').style.display = "none";
				//ELGV2_BulkProcess__1.FetchCourseWiseCoursePartList(hidUniID.Value, hidInstID.Value, hidFacID.Value, hidCrID.Value, hidMoLrnID.Value, hidPtrnID.Value, hidBrnID.Value, "DD_CoursePart");
				//ELGV2_BulkProcess__1.fnFillState(hid_StateID.Value);
				//DD_CoursePart.SelectedValue = hidCrPrID.Value;
				
				
		        var i=-1;
				var myArr= new Array();				
			    myArr[++i]= new Array(document.getElementById('<%=DD_Course.ClientID%>'),"0","Select "+document.getElementById('ctl00_ContentPlaceHolder1_lblCr').innerText,"select");
			    //myArr[++i]= new Array(document.getElementById('<%=DD_CoursePart.ClientID%>'),"-1","Select "+document.getElementById('ctl00_ContentPlaceHolder1_lblCr').innerText+" Part","select");
			    
				var ret=validateMe(myArr,50);
				return ret;		
				document.getElementById('ctl00_ContentPlaceHolder1_Div1').style.display = "block";		
				                    
		    }
		    
		    function openNewWindow(RefUniID, RefInstID, RefYearID, RefStudID, UniId, InstID, Year, StudID, FacID, CrID, MoLrnID, PtrnID, BrnID, CrPrDetailsID)
		    {
		      
		        var ElgFormNo = RefUniID+'-'+RefInstID+'-'+RefYearID+'-'+RefStudID;
		        
		        window.open("ELGV2_BulkProcess__2.aspx?ElgFormNo="+ElgFormNo+"&UniID="+UniId+"&InstID="+InstID+"&Year="+Year+"&StudID="+StudID+"&FacID="+FacID+"&CrID="+CrID+"&MoLrnID="+MoLrnID+"&PtrnID="+PtrnID+"&BrnID="+BrnID+"&CrPrDetailsID="+CrPrDetailsID+"","_blank","height=300,width=700,status=yes,toolbar=no,menubar=no,location=no,scrollbars =yes,left=250,top=300,screenX=0,screenY=400'");
		        
		        return false;
		    }
		    
		    function fnCheck()
		    {  
		        var bul=false;
		        var retval = false;
		        if(document.getElementById('ctl00_ContentPlaceHolder1_DG_University') != null)
		        {
		        var tbl=document.getElementById('ctl00_ContentPlaceHolder1_DG_University').getElementsByTagName("INPUT");
		        for(i=1;i<tbl.length;i++)
		        {
		            if(tbl[i].checked)
		            {
		               bul=true;
					   break;
		            }
		        }
		        if(document.getElementById('ctl00_ContentPlaceHolder1_rdProvisionalEligible').checked== true)
                 {
//                 alert('rdProvisionalEligible');
//                 alert(document.getElementById('ctl00_ContentPlaceHolder1_txtReason').value);
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
                //var tbl = document.getElementById('ctl00_ContentPlaceHolder1_DG_University');
                var tbl = document.getElementById('<%=DG_University.ClientID %>');
                var len = tbl.rows.length - 1 ;
                var colno;
                //alert(document.getElementById('rbWithoutInv').checked);
//                if(document.getElementById('ctl00_ContentPlaceHolder1_rbWithoutInv').checked == true)
//                {
//                    //colno = 3;
//                    colno = 5;
//                }
//                else
//                {
                    //colno = 4;
                   // colno =5; 
                    colno =6; 

               // }
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
                document.getElementById('ctl00_ContentPlaceHolder1_trDecision').focus();
               
                                 
            }
            if(flag == 'N')
            {
                document.getElementById('ctl00_ContentPlaceHolder1_trDecision').style.display = "none";
                
            }
            document.getElementById('ctl00_ContentPlaceHolder1_txtFirstName').value = "";
            document.getElementById('ctl00_ContentPlaceHolder1_txtLastName').value = "";
            
        }
        
        function fnFilterClickYesNo()
        
            { 
            
             
			//var rdFilter = new Array();
			var rdFilter0 = document.getElementById('ctl00_ContentPlaceHolder1_rbFilterYesNo_0');
			var rdFilter1 = document.getElementById('ctl00_ContentPlaceHolder1_rbFilterYesNo_1');
			
			         
			if(document.getElementById('ctl00_ContentPlaceHolder1_rbFilterYesNo_0').checked)    // Yes Examining body filter
          
            {    
                document.getElementById('ctl00_ContentPlaceHolder1_DivFilterExamBody').style.display = "block";                
                document.getElementById('ctl00_ContentPlaceHolder1_trStatistics').style.display = "none";
				//document.getElementById('ctl00_ContentPlaceHolder1_trStatisticsWithoutInv').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_trfilter').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_trGrids').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_fldEligibility').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_fldGrid').style.display = "none"; 
				document.getElementById('ctl00_ContentPlaceHolder1_lblRights').style.display = "none";   
				 document.getElementById(Body_IDClient).value = "0";
				document.getElementById(Body_StateClient).value = "0";    
				document.getElementById('ctl00_ContentPlaceHolder1_Body_Country').value= "0";	  
                document.getElementById('ctl00_ContentPlaceHolder1_Body_Indian_Foreign_Flag_0').checked = true;     

                document.getElementById('ctl00_ContentPlaceHolder1_TrBody_Indian_Foreign').style.display = 'inline';
				document.getElementById('ctl00_ContentPlaceHolder1_TrState').style.display = 'inline';
				document.getElementById('ctl00_ContentPlaceHolder1_TrBody').style.display = 'inline';
                document.getElementById('ctl00_ContentPlaceHolder1_TrCountryForeignBoardUniv').style.display = 'none';
				document.getElementById('ctl00_ContentPlaceHolder1_TrCountry').style.display = 'none';
				                                
            }
            
            else if(document.getElementById('ctl00_ContentPlaceHolder1_rbFilterYesNo_1').checked)     // No Examining body filter       
            {
                document.getElementById('ctl00_ContentPlaceHolder1_DivFilterExamBody').style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_Body_ID').value = "0";
				document.getElementById('ctl00_ContentPlaceHolder1_Body_State').value = "0";
				document.getElementById('ctl00_ContentPlaceHolder1_trStatistics').style.display = "none";
				//document.getElementById('ctl00_ContentPlaceHolder1_trStatisticsWithoutInv').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_trfilter').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_trGrids').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_fldEligibility').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_fldGrid').style.display = "none";	 
				document.getElementById('ctl00_ContentPlaceHolder1_lblRights').style.display = "none";

              
            }        
            
            }
						  
			
		function OnBodyTypeChange()
		{		    
			
			var rd0 = document.getElementById('ctl00_ContentPlaceHolder1_Body_Type_Flag_0');
			var rd1 = document.getElementById('ctl00_ContentPlaceHolder1_Body_Type_Flag_1');		    
			
			if(rd0.checked) //Board
			{								
					document.getElementById('ctl00_ContentPlaceHolder1_TrBody_Indian_Foreign').style.display = 'inline';
					if(document.getElementById('ctl00_ContentPlaceHolder1_Body_Indian_Foreign_Flag_0').checked)
					{
					document.getElementById('ctl00_ContentPlaceHolder1_TrState').style.display = 'inline';
					document.getElementById('ctl00_ContentPlaceHolder1_TrBody').style.display = 'inline';
					//document.getElementById('ctl00_ContentPlaceHolder1_TrCountry').style.display = 'inline';					
					document.getElementById('ctl00_ContentPlaceHolder1_TrCountry').style.display = "none";
					}
					else
					{	document.getElementById('ctl00_ContentPlaceHolder1_TrState').style.display = 'none';
					document.getElementById('ctl00_ContentPlaceHolder1_TrBody').style.display = 'none';
					document.getElementById('ctl00_ContentPlaceHolder1_TrCountry').style.display = 'inline';					
					//document.getElementById('ctl00_ContentPlaceHolder1_TrCountry').style.display = "none";
					
					}
                    var TdBodyCaption = document.getElementById('ctl00_ContentPlaceHolder1_TdBodyCaption');
                    if(TdBodyCaption != null)
					TdBodyCaption.innerText = "Select Board";	
                        				
					document.getElementById(Body_StateClient).value="0";
					document.getElementById(Body_IDClient).value = '0';							
					
				
			}
			else if(rd1.checked)//University
			{			
								
					document.getElementById('ctl00_ContentPlaceHolder1_TrBody_Indian_Foreign').style.display = 'inline';
					document.getElementById('ctl00_ContentPlaceHolder1_TrState').style.display = 'inline';
					document.getElementById('ctl00_ContentPlaceHolder1_TrBody').style.display = 'inline';
                    document.getElementById('ctl00_ContentPlaceHolder1_TrCountryForeignBoardUniv').style.display = 'none';
					document.getElementById('ctl00_ContentPlaceHolder1_TrCountry').style.display = 'none';
                    document.getElementById('ctl00_ContentPlaceHolder1_Body_Indian_Foreign_Flag_0').checked = true;

                    var TdBodyCaption = document.getElementById('ctl00_ContentPlaceHolder1_TdBodyCaption');
                    if(TdBodyCaption != null)
					TdBodyCaption.innerText = "Select "+document.getElementById('ctl00_ContentPlaceHolder1_lblUniversity').innerText+"";	
                    				
					document.getElementById(Body_StateClient).value="0";
					document.getElementById(Body_IDClient).value = '0';			    
				    	
			}		
            
            //*****************************************************************************************************
            document.getElementById('ctl00_ContentPlaceHolder1_trStatistics').style.display = "none";
		//	document.getElementById('ctl00_ContentPlaceHolder1_trStatisticsWithoutInv').style.display = "none";
			document.getElementById('ctl00_ContentPlaceHolder1_trfilter').style.display = "none";
			document.getElementById('ctl00_ContentPlaceHolder1_trGrids').style.display = "none";
			document.getElementById('ctl00_ContentPlaceHolder1_fldEligibility').style.display = "none";
			document.getElementById('ctl00_ContentPlaceHolder1_fldGrid').style.display = "none"; 
			document.getElementById('ctl00_ContentPlaceHolder1_lblRights').style.display = "none";	
            //*****************************************************************************************************
		}
		
		function OnIndianForeignChange()
		{
			//var rdIFC = new Array();
			var rdIFC0 = document.getElementById('ctl00_ContentPlaceHolder1_Body_Indian_Foreign_Flag_0');
			var rdIFC1 = document.getElementById('ctl00_ContentPlaceHolder1_Body_Indian_Foreign_Flag_1');			
					
							
			if(rdIFC0.checked)//India
			{	
							
				document.getElementById('ctl00_ContentPlaceHolder1_TrState').style.display = 'inline';
				document.getElementById('ctl00_ContentPlaceHolder1_TrBody').style.display = 'inline';
				document.getElementById('ctl00_ContentPlaceHolder1_TrCountry').style.display = 'none';
				document.getElementById('ctl00_ContentPlaceHolder1_TrCountryForeignBoardUniv').style.display = 'none';				
				document.getElementById('ctl00_ContentPlaceHolder1_txtForeignBoardUnivName').style.display = 'none';
				document.getElementById('ctl00_ContentPlaceHolder1_txtForeignBoardUnivName').value="";
				document.getElementById('ctl00_ContentPlaceHolder1_Body_Country').style.display = 'none';
				document.getElementById('ctl00_ContentPlaceHolder1_Body_Country').value="0";	
				//document.getElementById('ctl00_ContentPlaceHolder1_Body_StateClient').value="0";
				document.getElementById(Body_StateClient).value="0";
				document.getElementById(Body_IDClient).value = "0";			
				
			}
			else if(rdIFC1.checked)//Foreign
			{				
					
				document.getElementById('ctl00_ContentPlaceHolder1_TrState').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_TrBody').style.display = "none";
				document.getElementById('ctl00_ContentPlaceHolder1_TrCountry').style.display = 'inline';										
				document.getElementById(Body_StateClient).value="0";				
				document.getElementById('ctl00_ContentPlaceHolder1_TrCountryForeignBoardUniv').style.display = 'inline';
				document.getElementById('ctl00_ContentPlaceHolder1_txtForeignBoardUnivName').style.display = 'inline';
				document.getElementById('ctl00_ContentPlaceHolder1_txtForeignBoardUnivName').value="";
				document.getElementById('ctl00_ContentPlaceHolder1_Body_Country').style.display = 'inline';
				document.getElementById('ctl00_ContentPlaceHolder1_Body_Country').value="0";			    	    	     
                 
				
			}

            //*****************************************************************************************************
            document.getElementById('ctl00_ContentPlaceHolder1_trStatistics').style.display = "none";
		//	document.getElementById('ctl00_ContentPlaceHolder1_trStatisticsWithoutInv').style.display = "none";
			document.getElementById('ctl00_ContentPlaceHolder1_trfilter').style.display = "none";
			document.getElementById('ctl00_ContentPlaceHolder1_trGrids').style.display = "none";
			document.getElementById('ctl00_ContentPlaceHolder1_fldEligibility').style.display = "none";
			document.getElementById('ctl00_ContentPlaceHolder1_fldGrid').style.display = "none"; 
			document.getElementById('ctl00_ContentPlaceHolder1_lblRights').style.display = "none";	
            //*****************************************************************************************************
		}		
		
		function setValueState(Text,Value)
			{	
				//var text = eval(Text);
				//text.value = Value;
				var text = eval(document.getElementById(Text));
				text.value = Value;					
				
			}	
		 
		
		function fillStateBoard(val) //New Logic for Board Details
			{			    
			   
			    document.getElementById(Body_IDClient).value = "0";
    			
			    if (document.getElementById('ctl00_ContentPlaceHolder1_Body_Type_Flag_0').checked)//Board
			        {	
			           	
					    AjaxMethods.fillStateBoard_BulkProcess(parseInt(val),uniid,document.getElementById(hidInstClientID).value,document.getElementById(hidFacClientID).value,document.getElementById(hidCrClientID).value,document.getElementById(hidMoLrnClientID).value,document.getElementById(hidPtrnClientID).value,document.getElementById(hidBrnClientID).value,selfillStateBoard_Callback);
					    //AjaxMethods.fillStateBoard1(parseInt(val),parseInt(uniid),parseInt(document.getElementById(hidInstClientID).value),parseInt(document.getElementById(hidFacClientID).value),parseInt(document.getElementById(hidCrClientID).value),parseInt(document.getElementById(hidMoLrnClientID).value),parseInt(document.getElementById(hidPtrnClientID).value),parseInt(document.getElementById(hidBrnClientID).value),selfillStateBoard_Callback)
				    }
				    
				 else if (document.getElementById('ctl00_ContentPlaceHolder1_Body_Type_Flag_1').checked)//University
			        {	
			           
					    AjaxMethods.fillStateUniversity1(parseInt(val),uniid,document.getElementById(hidInstClientID).value,document.getElementById(hidFacClientID).value,document.getElementById(hidCrClientID).value,document.getElementById(hidMoLrnClientID).value,document.getElementById(hidPtrnClientID).value,document.getElementById(hidBrnClientID).value,parseInt(val),selfillStateUniversity_Callback);
					    
				    }				   
		    }	    
		    
		    
		    function selfillStateBoard_Callback(response)		   
		    
		    {
		        var ds = response.value[0];
		        var d  = document.getElementById('<%= Body_ID.ClientID %>');
		        d.length = 1;		
		       	        
		        if(ds.Tables[0].Rows.length >0)
		        {
		            for(var i=0; i<ds.Tables[0].Rows.length ;i++)
					{
					
					   d.add(new Option(ds.Tables[0].Rows[i].StateBoard_Description,ds.Tables[0].Rows[i].pk_BoardID));					    
					    
					}	
				}
				else
				{
				
				 d.selectedIndex=0;
				 
				}
		  	}
		  	
		  	function selfillStateUniversity_Callback(response)		   
		    
		    {		         
		        var ds = response.value[0];		        
		        var d  = document.getElementById('<%= Body_ID.ClientID %>');		       
		        d.length = 1;		
		        
		        	       
		        if(ds.Tables[0].Rows.length >0)
		        
		        {
		            for(var i=0; i<ds.Tables[0].Rows.length ;i++)
					{					  
					   d.add(new Option(ds.Tables[0].Rows[i].Uni_Name,ds.Tables[0].Rows[i].pk_Uni_ID));					    
					    
					}	
				}
				else
				{
				 d.selectedIndex=0;
				}
		  	}
		  	
		  	//Course Validations 
               function validateCourse()
	           {	          
	                var i=-1;
	                var crPart=document.getElementById("<%=DD_CoursePart.ClientID%>");
	                var crPartTerm=document.getElementById("<%=DD_CoursePartTerm.ClientID%>");
	                var myArr = new Array();  		    
	                myArr[++i]  = new Array(document.getElementById("<%=DD_Course.ClientID%>"),"0","Please Select "+ document.getElementById('<%=lblCr.ClientID %>').innerText,"select");
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

            function validateExaminingBody()
            {
                var rbFilterYesNo = document.getElementById('ctl00_ContentPlaceHolder1_rbFilterYesNo_0');
                if(rbFilterYesNo.checked == true)       // If Examining Body filter is applied
                {
                    if (document.getElementById('ctl00_ContentPlaceHolder1_Body_Indian_Foreign_Flag_0').checked)    //Indian Board
			        {
                        var i=-1;
                        var myArr = new Array();  		     
	                    myArr[++i]  = new Array(document.getElementById("<%=Body_State.ClientID%>"),"0","Please Select State of Examining Body","select");
	                    myArr[++i]  = new Array(document.getElementById("<%=Body_ID.ClientID%>"),"0","Please Select Board/ University" ,"select");
	                    var ret=validateMe(myArr,50); 	                                
	                    return ret; 
                    }
                    else                                //Foreign Board
                    {
                        var i=-1;
                        var myArr = new Array();  		     
	                    myArr[++i]  = new Array(document.getElementById("<%=Body_Country.ClientID%>"),"0","Please Select Country of Examining Body","select");
	                    var ret=validateMe(myArr,50); 	                                
	                    return ret; 
                    }
                }
            }


            function funRBInvoiceClick()
            {
                    //*****************************************************************************************************
                    document.getElementById('ctl00_ContentPlaceHolder1_trStatistics').style.display = "none";
			       // document.getElementById('ctl00_ContentPlaceHolder1_trStatisticsWithoutInv').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_trfilter').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_trGrids').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_fldEligibility').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_fldGrid').style.display = "none"; 
			        document.getElementById('ctl00_ContentPlaceHolder1_lblRights').style.display = "none";	
                    //*****************************************************************************************************
            }


            function funDDCourseChanged()
            {
                    //*****************************************************************************************************
                    document.getElementById('ctl00_ContentPlaceHolder1_trStatistics').style.display = "none";
			       // document.getElementById('ctl00_ContentPlaceHolder1_trStatisticsWithoutInv').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_trfilter').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_trGrids').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_fldEligibility').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_fldGrid').style.display = "none"; 
			        document.getElementById('ctl00_ContentPlaceHolder1_lblRights').style.display = "none";	

                    document.getElementById('ctl00_ContentPlaceHolder1_Div1').style.display = "none";
                    
                    //*****************************************************************************************************
            }

            function funDDCountryOrStateOrUniversityChanged()
            {
                    //*****************************************************************************************************
                    document.getElementById('ctl00_ContentPlaceHolder1_trStatistics').style.display = "none";
			       // document.getElementById('ctl00_ContentPlaceHolder1_trStatisticsWithoutInv').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_trfilter').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_trGrids').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_fldEligibility').style.display = "none";
			        document.getElementById('ctl00_ContentPlaceHolder1_fldGrid').style.display = "none"; 
			        document.getElementById('ctl00_ContentPlaceHolder1_lblRights').style.display = "none";	
                    //*****************************************************************************************************
            }
                
    </script>

    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="0">
            <tr>
                <%--td class="FormName" align="left" valign="middle">
                    <asp:Label ID="lblTitle" runat="server" Font-Bold="True" CssClass="lblPageHead" meta:resourcekey="lblTitleResource1">Bulk Process Data</asp:Label>
                    <asp:Label ID="lblInstName" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="lblInstNameResource1"></asp:Label>--%>
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" Text="Bulk Process Data" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                    <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="True" Font-Size="Small"
                        meta:resourcekey="lblAcademicYearResource1"></asp:Label>

                        <asp:Label ID="lblStudName" runat="server" Font-Size="Small"  Style="display: none" meta:resourcekey="lblStudNameResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <%--<p style="margin: 0px 5px" align="right">--%>
                    <table border="0" width="95%" style="border-collapse: collapse; display: none" id="tblLink"
                        runat="server">
                        <tr>
                            <td class="InnerLinkBorder" valign="middle" align="center">
                                <font style="font-size: 2pt">&nbsp;</font></td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="lnkSelectCr" CssClass="NavLink" runat="server" Enabled="False"
                                    OnClick="lnkSelectCr_Click" meta:resourcekey="lnkSelectCrResource1" Text="Select Course"></asp:LinkButton>&nbsp;|&nbsp;
                                <asp:LinkButton ID="lnkPRN" CssClass="NavLink" runat="server" Enabled="False" OnClick="lnkPRN_Click"
                                    meta:resourcekey="lnkPRNResource1" Text="View Eligible Students with PRN"></asp:LinkButton>
                            </td>
                        </tr>
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
                                        <td align="center" width="15%">
                                            <img height="16" src="../images/button_reset.gif" width="16" border="0"><input class="But"
                                                title="Reset" accesskey="R" tabindex="4" type="reset" value="Reset" name="Reset"
                                                disabled /></td>
                                        <td align="right">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="95%" cellpadding="0" cellspacing="0" border="0" id="tblUserControl"
                        runat="server">
                        <tr>
                            <td>
                                <br />
                                <div id="divAcademicYr" runat="server">
                                    <fieldset id="tblAcademicYr" style="height: 100px; width: 603px;" align="center"
                                        runat="server">
                                        <legend><b>Select Academic Year </b></legend>
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td style="height: 24px;" colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="height: 20px; width: 125px;">
                                                    <asp:Label ID="lblAcyr" runat="server" Text="Select Academic Year" Font-Bold="True"
                                                        Width="221px" meta:resourcekey="lblAcyrResource1"></asp:Label></td>
                                                <td align="center" style="height: 20px; width: 1%;">
                                                    <b>&nbsp;:&nbsp;</b></td>
                                                <td align="left" id="tdAcdYr" runat="server">
                                                    <asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="selectbox" Width="151px"
                                                        meta:resourcekey="ddlAcademicYrResource1">
                                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
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
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table width="95%" cellpadding="0" cellspacing="0" border="0" id="tblMainTable" runat="server">
                        <tr>
                            <td align="left" colspan="3" style="height: 5px">
                                <asp:Label ID="lblSave" runat="server" CssClass="saveNote" meta:resourcekey="lblSaveResource1"></asp:Label></td>
                        </tr>
                        <tr id="trCourse" runat="server">
                            <td colspan="3">
                                <div id="DivCorseSelection" runat="server" style="display: none">
                                    <fieldset id="CorseSelectionFieldset" runat="server"><legend>Select <%= lblCr.Text%></legend>
                                        <table width="100%">
                                            <%--<tr class="clSubHeading" width="85%">
                                                <td class="PersonalTableHeader" valign="top" align="left" colspan="5">
                                                    <b>Select
                                                        <%= lblCr.Text%>
                                                    </b>
                                                </td>
                                            </tr>--%>
                                            <tr height="10px">
                                                <td width="25%" align="right">
                                                    <b><%= lblCr.Text%></b>
                                                </td>
                                                <td width="1%">
                                                    <b>:</b></td>
                                                <td height="10px" align="left">
                                                    <asp:DropDownList ID="DD_Course" runat="server" Width="460px" CssClass="selectbox" onchange="setValue(document.getElementById(hidCrClientID).id,this.value);FetchCourseWiseCoursePartList('tbCrPr',document.getElementById(hidUniClientID).value, document.getElementById(hidInstClientID).value,document.getElementById(hidCrClientID).value,'ctl00_ContentPlaceHolder1_DD_CoursePart'),ClearDropDowns(1,1); funDDCourseChanged();"
                                                        meta:resourcekey="DD_CourseResource1">
                                                    </asp:DropDownList>
                                                    <font class="Mandatory">*</font></td>
                                            </tr>
                                            <tr>
                                                <td width="25%" align="right">
                                                    <b><%= lblCr.Text%> Part</b></td>
                                                <td width="1%">
                                                    <b>:</b></td>
                                                <td height="10px" id="tbCrPr" align="left">
                                                    <asp:DropDownList ID="DD_CoursePart" runat="server"  Width="230px" CssClass="selectbox" meta:resourcekey="DD_CoursePartResource1" onchange="setValue(document.getElementById(hidCrPrClientID).id,this.value);FetchCoursePartWiseCoursePartChildList('tbCrPrCh',document.getElementById(hidUniClientID).value, document.getElementById(hidInstClientID).value,document.getElementById(hidFacClientID).value+'-'+document.getElementById(hidCrClientID).value+'-'+document.getElementById(hidMoLrnClientID).value+'-'+document.getElementById(hidPtrnClientID).value+'-'+document.getElementById(hidBrnClientID).value+'-'+document.getElementById(hidCrPrClientID).value,'ctl00_ContentPlaceHolder1_DD_CoursePartTerm'),ClearDropDowns(0,1);funDDCourseChanged();">
                                                        <asp:ListItem Value="-1" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <font class="Mandatory">*</font></td>
                                            </tr>
                                            <tr>
                                                <td width="25%" align="right">
                                                    <b><%= lblCr.Text%> Part Term</b></td>
                                                <td width="1%">
                                                    <b>:</b></td>
                                                <td height="10px" id="tbCrPrCh" align="left">
                                                    <asp:DropDownList ID="DD_CoursePartTerm" runat="server" Width="230px" CssClass="selectbox" onchange="setCrPartTerm(this.value);funDDCourseChanged();"
                                                        meta:resourcekey="DD_CoursePartTermResource1">
                                                        <asp:ListItem Value="-1" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <font class="Mandatory">*</font></td>
                                            </tr>
                                            <%--<tr height="10px">
                                                <td align="right" style="width: 23%">
                                                    <b>Display list of Students</b></td>
                                                <td style="width: 1%">
                                                    <b>&nbsp;:&nbsp;</b></td>
                                                <td align="left">
                                                    <asp:RadioButton ID="rbWithInv" Text="Consider students whose payment is received and confirmed for Eligibility processing"
                                                        Checked="True" GroupName="grpInvoice" runat="server" meta:resourcekey="rbWithInvResource1" />
                                                    <br />
                                                    <asp:RadioButton ID="rbWithoutInv" Text="Do not consider payment status for Eligibility processing"
                                                        GroupName="grpInvoice" runat="server" meta:resourcekey="rbWithoutInvResource1" />
                                                </td>
                                            </tr>--%>

                                           <%-- <tr height="10px">
                                                <td align="right" style="width: 25%">
                                                    <b>Consider Payment Status</b></td>
                                                <td width="1%">
                                                    <b>:</b></td>
                                                <td align="left">
                                                    <asp:RadioButton ID="rbWithInv" Text="Yes" GroupName="grpInvoice" runat="server" onclick="funRBInvoiceClick();" />                                                    
                                                    <asp:RadioButton ID="rbWithoutInv" Text="No" GroupName="grpInvoice" runat="server" Checked="True" onclick="funRBInvoiceClick();"/>
                                                </td>
                                            </tr>--%>
                                            <tr style="height: 10px; width: 100%;">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="trbtnProcessData" runat="server" style="display: none;">
                                                <td colspan="3" align="center" style="height: 15px;">
                                                    <asp:Button ID="btnProcessData" runat="server" CssClass="butSubmit" Text="Submit"
                                                        Height="18px" Width="70px"  OnClick="btnProcessData_Click" OnClientClick="return validateCourse()"
                                                        meta:resourcekey="btnProcessDataResource1" /> <%-- OnClientClick="return validateCourse()"--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </div>
                                <div id="Div1" runat="server" style="display: none">
                                    <fieldset id="Fieldset3" runat="server">
                                        <legend><strong>Examining Body Filter</strong></legend>
                                        <table cellspacing="0" cellpadding="0" width="95%" border="0">
                                            <tr style="height: 5px;">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="Tr1" height="10px" runat="server">
                                                <td align="right" style="height: 10px; width: 385px;">
                                                    <strong>Do you want to use Filters for selecting Examining Body&nbsp;</strong></td>
                                                <td style="height: 10px; width: 1%;">
                                                    <strong>:</strong></td>
                                                <td style="height: 10px" align="left">
                                                    <asp:RadioButtonList ID="rbFilterYesNo" onclick="fnFilterClickYesNo();" runat="server"
                                                        RepeatDirection="Horizontal" meta:resourcekey="rbFilterYesNoResource1">
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource3" Text="Yes"></asp:ListItem>
                                                        <asp:ListItem Value="0" Selected="True" meta:resourcekey="ListItemResource2" Text="No"></asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                        </table>
                                        <fieldset id="DivFilterExamBody" runat="server">
                                            <legend><strong>Examining Body Selection Criteria</strong></legend>
                                            <table cellspacing="0" cellpadding="0" width="95%" border="0">
                                                <tr id="TrExamBody" runat="server">
                                                    <td align="right" style="width: 28%;">
                                                        <strong>Select Examining Body</strong></td>
                                                    <td style="width: 1%;">
                                                        <strong>&nbsp;:&nbsp;</strong></td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="Body_Type_Flag" onclick="OnBodyTypeChange();" runat="server"
                                                            RepeatDirection="Horizontal" meta:resourcekey="Body_Type_FlagResource1">
                                                            <asp:ListItem Value="1" Selected="True" meta:resourcekey="ListItemResource4" Text="Board"></asp:ListItem>
                                                            <asp:ListItem Value="2" meta:resourcekey="ListItemResource5" Text="University"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr id="TrBody_Indian_Foreign" runat="server">
                                                    <td id="TdBody_Indian_Foreign" align="right" style="width: 28%">
                                                        <strong>Select Board</strong></td>
                                                    <td align="center" style="width: 1%">
                                                        <strong>&nbsp;:&nbsp;</strong></td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="Body_Indian_Foreign_Flag" onclick="OnIndianForeignChange();"
                                                            runat="server" RepeatDirection="Horizontal" meta:resourcekey="Body_Indian_Foreign_FlagResource1">
                                                            <asp:ListItem Value="0" Selected="True" meta:resourcekey="ListItemResource6" Text="Indian"></asp:ListItem>
                                                            <asp:ListItem Value="1" meta:resourcekey="ListItemResource7" Text="Foreign"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 5px;">
                                                    </td>
                                                </tr>
                                                <tr id="TrCountry" style="display: none" runat="server">
                                                    <td style="width: 28%;" align="right">
                                                        <strong>Select Country</strong></td>
                                                    <td style="width: 1%;" align="center">
                                                        <strong>&nbsp;:&nbsp;</strong></td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="Body_Country" runat="server" CssClass="selectbox" Width="198px"
                                                            meta:resourcekey="Body_CountryResource1" onblur="setValueState(hidCountryIDForeignClientID,this.value)" onchange="funDDCountryOrStateOrUniversityChanged();">
                                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource8" Text="--- Select ---"></asp:ListItem>
                                                        </asp:DropDownList><font class="Mandatory">*</font></td>
                                                </tr>
                                                
                                                <tr id="TrCountryForeignBoardUniv" style="display: none" runat="server">
                                                    <td style="width: 28%;" align="right">
                                                        <strong>
                                                            <asp:Label ID="lblBrdUniName" runat="server" Text="Board/University Name" meta:resourcekey="lblBrdUniNameResource1"></asp:Label></strong></td>
                                                    <td style="width: 1%;" align="center">
                                                        <strong>&nbsp;:&nbsp;</strong></td>
                                                    <td style="width: 100%;" align="left">
                                                        <b>
                                                            <asp:TextBox ID="txtForeignBoardUnivName" runat="server" CssClass="inputbox" Width="418px"
                                                                meta:resourcekey="txtForeignBoardUnivNameResource1"></asp:TextBox></b></td>
                                                </tr>
                                                <tr id="TrState" runat="server">
                                                    <td style="width: 28%;" align="right">
                                                        <strong>Select State</strong></td>
                                                    <td style="width: 1%;" align="center">
                                                        <strong>&nbsp;:&nbsp;</strong></td>
                                                    <td id="TdState" align="left">
                                                        <asp:DropDownList ID="Body_State" runat="server" onblur="setValueState(hid_StateClientID,this.value)"
                                                            onchange="fillStateBoard(this.value);funDDCountryOrStateOrUniversityChanged();" CssClass="selectbox" Width="198px" meta:resourcekey="Body_StateResource1">
                                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource9" Text="--- Select ---"></asp:ListItem>
                                                        </asp:DropDownList><font class="Mandatory">*</font></td>
                                                </tr>
                                                <tr id="TrBody" runat="server">
                                                    <td id="TdBodyCaption" style="width: 28%; font-weight:bold" align="right">
                                                        <strong>Select Board</strong></td>
                                                    <td style="width: 1%;" align="center">
                                                        <strong>&nbsp;:&nbsp;</strong></td>
                                                    <td id="TdBodyID" align="left">
                                                        <asp:DropDownList ID="Body_ID" onblur="setValueState(hid_BodyClientID,this.value);" onchange="funDDCountryOrStateOrUniversityChanged();" 
                                                            runat="server" CssClass="selectbox" Width="418px" meta:resourcekey="Body_IDResource1">
                                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource10" Text="--- Select ---"></asp:ListItem>
                                                        </asp:DropDownList><font class="Mandatory">*</font></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 5px;">
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                        <table cellspacing="0" cellpadding="0" width="95%" border="0">
                                            <tr style="height: 5px;">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="trbtnProcessData1" runat="server" align="center">
                                                <td colspan="3" align="center" style="height: 15px;">
                                                    <asp:Button ID="btnProcessData1" runat="server" CssClass="butSubmit" Text="Submit" OnClientClick="return validateExaminingBody()" 
                                                        Height="18px" Width="70px" OnClick="btnProcessData_Click" meta:resourcekey="btnProcessDataResource1" />
                                                </td>
                                            </tr>
                                            <tr style="height: 5px;">
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </div>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <asp:Label ID="lblRights" runat="server" Font-Bold="True" CssClass="errorNote" meta:resourcekey="lblRightsResource1"></asp:Label></td>
                        </tr>
                        <tr id="trStatistics" runat="server" style="display: none">
                            <td>
                                <fieldset id="Fieldset1" runat="server">
                                    <legend><strong>Statistics of Records</strong></legend>
                                    <table width="100%">
                                       <%-- <tr class="clSubHeading" width="80%">
                                            <td class="PersonalTableHeader" valign="top" align="left" colspan="5" style="height: 15px">
                                                <b>Statistics of Records</b></td>
                                        </tr>--%>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 131px">
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
                                                    <tr style="height: 20px; font-size: small;" class="gridItem">
                                                        <td style="height: 20px; font-size: small;" class="gridItem">
                                                            <asp:Label ID="lblStudenteligibility" runat="server" Text="Students whose eligibility is to be decided by university"
                                                                meta:resourcekey="lblStudenteligibilityResource1"></asp:Label></td>
                                                        <td align="center" style="height: 20px; font-size: small;" class="gridItem">
                                                            <asp:Label ID="lblUniCount" runat="server" meta:resourcekey="lblUniCountResource1"></asp:Label></td>
                                                        <td align="center" style="height: 20px; font-size: small;" class="gridItem">
                                                            <asp:Label ID="lblNonPaidUniCount" runat="server" meta:resourcekey="lblNonPaidUniCountResource1"></asp:Label></td>
                                                    </tr>
                                                    <tr style="height: 20px; font-size: small;" class="gridItem">
                                                        <td style="height: 20px; font-size: small;" class="gridItem">
                                                            <asp:Label ID="lblStudenteligible" runat="server" Text="Students eligible at college"
                                                                meta:resourcekey="lblStudenteligibleResource1"></asp:Label></td>
                                                        <td align="center" style="height: 20px; font-size: small;" class="gridItem">
                                                            <asp:Label ID="lblCollCount" runat="server" meta:resourcekey="lblCollCountResource1"></asp:Label></td>
                                                        <td align="center" style="height: 20px; font-size: small;" class="gridItem">
                                                            <asp:Label ID="lblNonPaidCollCount" runat="server" meta:resourcekey="lblNonPaidCollCountResource1"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="center" style="height: 20px; font-size: small;" class="gridItem">
                                                            <asp:Label ID="lblNoRecords" runat="server" CssClass="errorNote" meta:resourcekey="lblNoRecordsResource1"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                <asp:GridView ID="DG_PRN1" runat="server" Width="95%" AutoGenerateColumns="False"
                                                    PageSize="20" AllowPaging="True" AllowSorting="True" meta:resourcekey="DG_PRNResource1"
                                                    OnPageIndexChanging="DG_PRN1_PageIndexChanging" 
                                                    OnSorting="DG_PRN1_Sorting" EnableModelValidation="True" 
                                                    onrowdatabound="DG_PRN1_RowDataBound">
                                                    <RowStyle CssClass="gridItem" />
                                                    <HeaderStyle CssClass="gridHeader" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
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
                                                            meta:resourcekey="BoundFieldResource1">
                                                            <HeaderStyle Font-Bold="True" Width="15%" CssClass="gridHeader" HorizontalAlign="Center">
                                                            </HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="StudName" HeaderText="Name of Student" SortExpression="StudName"
                                                            meta:resourcekey="BoundFieldResource2">
                                                            <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign="Center">
                                                            </HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Eligibility" HeaderText="Eligibility" Visible="False"
                                                            meta:resourcekey="BoundFieldResource3">
                                                            <HeaderStyle Font-Bold="True" Width="5%" CssClass="gridHeader" HorizontalAlign="Center">
                                                            </HeaderStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="EligibilityStatus" HeaderText="Eligibility Status" SortExpression="EligibilityStatus"
                                                            meta:resourcekey="BoundFieldResource4">
                                                            <HeaderStyle Font-Bold="True" Width="15%" CssClass="gridHeader" HorizontalAlign="Center">
                                                            </HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Reason" HeaderText="Reason" meta:resourcekey="BoundFieldResource5">
                                                            <HeaderStyle Font-Bold="True" Width="20%" CssClass="gridHeader" HorizontalAlign="Center">
                                                            </HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PRN_Number" HeaderText="PRN Number" SortExpression="PRN_Number"
                                                            meta:resourcekey="BoundFieldResource6">
                                                            <HeaderStyle Font-Bold="True" Width="15%" CssClass="gridHeader" HorizontalAlign="Center">
                                                            </HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        <tr id="trStatisticsWithoutInv" runat="server" style="display: none">
                            <td style="height: 178px">
                                <fieldset id="Fieldset2" runat="server">
                                    <legend><strong>Statistics of Records</strong></legend>
                                    <table width="100%">
                                       <%-- <tr class="clSubHeading" width="80%">
                                            <td class="PersonalTableHeader" valign="top" align="left" colspan="5">
                                                <b>Statistics of Records</b></td>
                                        </tr>--%>
                                        <tr>
                                            <td colspan="4" style="height: 15px">
                                                <p style="margin: 0px 35px" align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="errorNote" meta:resourcekey="Label2Resource1"></asp:Label></p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <table id="tblStatistics1" width="100%" border="0" style="border-collapse: collapse;
                                                    display: none" cellpadding="0" runat="server">
                                                    <tr>
                                                        <td width="50%" align="center" height="20px" class="gridHeader">
                                                            <b>Eligibility Process</b></td>
                                                        <td width="30%" align="center" height="20px" class="gridHeader">
                                                            <b>No. of students<br />
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 20px; font-size: small;" class="gridItem">
                                                        <td style="height: 20px; font-size: small;" class="gridItem">
                                                            <asp:Label ID="lblStudentsuniversity" runat="server" Text="Students whose eligibility is to be decided by university"
                                                                meta:resourcekey="lblStudentsuniversityResource1"></asp:Label></td>
                                                        <td align="center" style="height: 20px; font-size: small;" class="gridItem">
                                                            <asp:Label ID="lblUniCount1" runat="server" meta:resourcekey="lblUniCount1Resource1"></asp:Label></td>
                                                    </tr>
                                                    <tr class="gridItem">
                                                        <td style="height: 20px; font-size: small;" class="gridItem">
                                                            <asp:Label ID="lblStudentscollege" runat="server" Text="Students eligible at college"
                                                                meta:resourcekey="lblStudentscollegeResource1"></asp:Label></td>
                                                        <td align="center" style="height: 20px; font-size: small;" class="gridItem">
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
                                    <table align="center" width="95%">
                                        <tr>
                                            <td align="left" colspan="4">
                                                <b>Do you want to use Student Search Filters : </b> &nbsp;
                                           <%-- </td>
                                            <td align="left">--%>
                                                <asp:RadioButton ID="rbFilterYes" Text="Yes" GroupName="grpyesno" runat="server"
                                                    onclick="fnFilterClick('Y');" meta:resourcekey="rbFilterYesResource1" />
                                                <asp:RadioButton ID="rbFilterNo" Text="No" GroupName="grpyesno" runat="server" onclick="fnFilterClick('N');"
                                                    Checked="True" meta:resourcekey="rbFilterNoResource1" />
                                            </td>
                                        </tr>
                                       
                                        <tr id="trDecision" style="display: none" runat="server">
                                            <td align="right">
                                                <b>Last Name :</b></td>
                                            <td style="height: 22px" align="left">
                                                <b>
                                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="inputbox" meta:resourcekey="txtLastNameResource1"></asp:TextBox></b></td>
                                            <td align="right">
                                                <b>First Name :</b></td>
                                            <td style="height: 22px" align="left">
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputbox" meta:resourcekey="txtFirstNameResource1"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Button ID="btnFilterSubmit" CssClass="butSubmit" Text="Submit" runat="server"
                                                    Width="70px" Height="18px" OnClick="btnFilterSubmit_Click" meta:resourcekey="btnFilterSubmitResource1" />
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        <tr id="trGrids" runat="server" style="display: none;">
                            <td>
                                <fieldset id="fldEligibility" runat="server" style="display: none">
                                    <table align="center" width="85%">
                                        <tr>
                                            <td align="right" style="width: 300px">
                                                <b>Mark the selected students as:</b></td>
                                            <td align="left">
                                                <asp:RadioButton ID="rdEligible" Text="Eligible" GroupName="grpEligibility"
                                                    runat="server" onclick="fnProvElgClick('E');" meta:resourcekey="rdEligibleResource1" />
                                                <asp:RadioButton ID="rdProvisionalEligible" Text="Provisionally Eligible" GroupName="grpEligibility"
                                                    runat="server" onclick="fnProvElgClick('PE');" meta:resourcekey="rdProvisionalEligibleResource1" />
                                            </td>
                                        </tr>
                                        <tr id="trReason" style="display: none;">
                                            <td align="right" style="width: 300px">
                                                <b>Reason(s) for marking selected students as Provisionally Eligible:</b></td>
                                            <td align="left">
                                                <asp:TextBox ID="txtReason" runat="server" CssClass="textarea" Height="30px" Width="400px"
                                                    TextMode="MultiLine" meta:resourcekey="txtReasonResource1"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </fieldset>
                                <fieldset id="fldGrid" runat="server" style="display: none">
                                    <table width="100%" id="tblGrid" runat="server">
                                        <tr class="clSubHeading" width="80%">
                                            <td class="PersonalTableHeader" valign="top" align="left" colspan="5">
                                                <asp:Label ID="lblUniCollPrn" runat="server" Font-Bold="True" meta:resourcekey="lblUniCollPrnResource1"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <p style="margin: 0px 10px" align="left">
                                                    <asp:Label ID="lblUnselectCheck" runat="server" Font-Bold="True" meta:resourcekey="lblUnselectCheckResource1"></asp:Label>
                                                </P>
                                            </td>
                                        </tr>
                                        <tr id="TrColorCodes" runat="server">
                                            <td>
                                                <p>
                                                    <br />
                                                    <b>Following are the color codes which are used in the Students' list to distinguish the students according to the given 4 types of Examining Bodies:</b>
                                                    <br />
                                                    <asp:Label ID="LblSame_university" BackColor="Bisque" runat="server" 
                                                        Text="Same Board/University" meta:resourcekey="LblSame_universityResource1"></asp:Label>&nbsp;
                                                    <asp:Label ID="LblHome_board" BackColor="#E1FFFF" runat="server" 
                                                        Text="Same State Board/University" meta:resourcekey="LblHome_boardResource1"></asp:Label>&nbsp;   
                                                    <asp:Label ID="LblOther_state_board" BackColor="#CCEEFF" runat="server" 
                                                        Text="Other State Board/University" 
                                                        meta:resourcekey="LblOther_state_boardResource1"></asp:Label>&nbsp;
                                                    <asp:Label ID="LblForeign_board" BackColor="#FFCCFF" runat="server" 
                                                        Text="Foreign Board/University" meta:resourcekey="LblForeign_boardResource1"></asp:Label> 
                                                </p>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:DataGrid ID="DG_University" runat="server" Width="95%" Visible="False" AutoGenerateColumns="False"
                                                    OnItemDataBound="DG_University_ItemDataBound" AllowPaging="True" DataKeyField="pk_Student_ID"
                                                    OnPageIndexChanged="DG_University_PageIndexChanged" OnItemCommand="DG_University_ItemCommand"
                                                    PageSize="50" OnSortCommand="DG_University_SortCommand" 
                                                    AllowSorting="True" meta:resourcekey="DG_UniversityResource1" CssClass="clGrid grid-view" >
                                                    <PagerStyle Mode="NumericPages" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right"></PagerStyle>
                                                    <ItemStyle CssClass="gridItem"></ItemStyle>
                                                    
                                                    <Columns>
                                                        <asp:BoundColumn HeaderText="Sr.No.">
                                                            <HeaderStyle Font-Bold="True" Wrap="False" HorizontalAlign="Center" Width="5%" CssClass="gridHeader">
                                                            </HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EligibilityFormNo" HeaderText="Eligibility Form No."
                                                            SortExpression="EligibilityFormNo">
                                                            <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign="Center">
                                                            </HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="pk_Invoice_ID" HeaderText="Invoice Number">
                                                            <HeaderStyle Font-Bold="True" Width="20%" CssClass="gridHeader" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundColumn>                                                    
                                                  
                                                    <asp:BoundColumn DataField="ApplicationFromNo" HeaderText="Application Form No."
                                                            SortExpression="ApplicationFromNo">
                                                            <HeaderStyle Font-Bold="True" Width="20%" CssClass="gridHeader" HorizontalAlign="Center">
                                                            </HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundColumn>

                                                        <asp:BoundColumn DataField="studName" HeaderText="Name of Student"  meta:resourcekey="BoundFieldResource201">
                                                            <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign="Center">
                                                            </HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundColumn>

                                                        <asp:BoundColumn DataField="Body_Name" HeaderText="Examining Body" SortExpression="Body_Name">
                                                            <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign="Center">
                                                            </HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="State_Name" HeaderText="State" SortExpression="State_Name">
                                                            <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign="Center">
                                                            </HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundColumn>

                                                        <asp:TemplateColumn HeaderText="Select">
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
                                                        </asp:TemplateColumn>
                                                        <asp:BoundColumn DataField="pk_Uni_ID" HeaderText="pk_Uni_ID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="pk_Year" HeaderText="pk_Year" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="InstID" HeaderText="pk_Institute_ID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="pk_Student_ID" HeaderText="pk_Student_ID" Visible="False">
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="pk_Fac_ID" HeaderText="pk_Fac_ID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="pk_Cr_ID" HeaderText="pk_Cr_ID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="pk_MoLrn_ID" HeaderText="pk_MoLrn_ID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="pk_Ptrn_ID" HeaderText="pk_Ptrn_ID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="pk_Brn_ID" HeaderText="pk_Brn_ID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="pk_CrPr_Details_ID" HeaderText="pk_CrPr_Details_ID" Visible="False">
                                                        </asp:BoundColumn>

                                                        <asp:BoundColumn DataField="ExamBodyType" HeaderText="ExamBodyType" Visible="False"></asp:BoundColumn>

                                                        

                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="lblPRN" runat="server" Font-Bold="True" meta:resourcekey="lblPRNResource1"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        <%--  <tr>
                                <td height="20px">
                                </td>
                            </tr>--%>
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
                    <input id="hidCrPrChID" type="hidden" name="hidCrPrChID" runat="server" />
                    <input id="hidBrnID" style="width: 24px; height: 22px" type="hidden" name="hidBrnID"
                        runat="server" />
                    <input id="hidCrPrID" style="width: 24px; height: 22px" type="hidden" name="hidCrPrID"
                        runat="server" />
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
                    <input id="hid_StateID" type="hidden" name="hid_StateID" runat="server">
                    <input id="hidBodyState" type="hidden" name="hidBodyState" runat="server">
                    <input id="hidBodyID" type="hidden" name="hidBodyID" runat="server">
                    <input id="hid_BodyID" type="hidden" name="hid_BodyID" runat="server">
                    <input id="hidStateID" type="hidden" name="hidStateID" runat="server">
                    <input id="hidCountryIDForeign" type="hidden" name="hidCountryIDForeign" runat="server">
                    <input id="hidCountryId" type="hidden" value="0" name="hidcountryId" runat="server" />
                    <input id="hidtxtCountryForeignBoardUniv" type="hidden" value="0" name="hidtxtCountryForeignBoardUniv"
                        runat="server" />
                    <input id="hidCollCount1" type="hidden" name="hid_StateID" runat="server" />
                    <input id="hidUniCount1" type="hidden" name="hid_StateID" runat="server" />
                    <input id="hidCollCountWithInv" type="hidden" name="hidCollCountWithInv" runat="server" />
                    <input id="hidUniCountWithInv" type="hidden" name="hidUniCountWithInv" runat="server" />
                    <input id="hidUnPaidCollCountWithInv" type="hidden" name="hidUnPaidCollCountWithInv"
                        runat="server" />
                    <input id="hidUnPaidUniCountWithInv" type="hidden" name="hidUnPaidUniCountWithInv"
                        runat="server" />
                    <input id="hidStateSelText" type="hidden" name="hidStateSelText" runat="server" />
                    <input id="hidBodyTypeFlag" type="hidden" name="hidBodyTypeFlag" runat="server" />
                    <input id="hidBodySelText" type="hidden" name="hidBodySelText" runat="server" />
                    <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
                    <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
                        meta:resourcekey="lblUniversityResource1"></asp:Label>
                    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
                    <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none"
                        meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
