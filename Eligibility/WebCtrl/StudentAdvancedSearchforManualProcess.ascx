<%@ Control Language="C#" AutoEventWireup="true"  Codebehind="StudentAdvancedSearchforManualProcess.ascx.cs"
    Inherits="StudentRegistration.Eligibility.WebCtrl.StudentAdvancedSearchforManualProcess" %>
     

<link href="../CSS/calendar-blue.css" type="text/css" rel="stylesheet"/> 

<script type="text/javascript" language="jscript" src="../jscript/calendar.js"> </script>
<script type="text/javascript" language="jscript" src="../jscript/calendar-en.js"> </script>
<script type="text/javascript" language="javascript" src="../jscript/InitCalendarFunc.js"> </script>
<script language="javascript" type="text/javascript" src="../jscript/DatePickerJs.js"></script>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript">
		var uniid;
		
		uniid = <%=Classes.clsGetSettings.UniversityID%>;
		
		    var hid_Inst_id = '<%=hidInstID.ClientID %>';
		    var hid_Fac_id = '<%=hidFacID.ClientID%>';
		    var hid_Cr_id = '<%=hidCrID.ClientID%>';
		    var hid_MoLrn_id = '<%=hidMoLrnID.ClientID%>';
		    var hid_Ptrn_id = '<%=hidPtrnID.ClientID%>';
		    var hid_Brn_id = '<%=hidBrnID.ClientID%>';
		    var hid_CrPr_Details_ID = '<%=hidCrPrDetailsID.ClientID%>';
		    var ddl_Faculty = '<%=ddlFaculty.ClientID%>';
		    var ddl_Course= '<%=ddlCourse.ClientID%>';
		    var ddl_MoLrn = '<%=ddlMoLrn.ClientID%>';
		    var ddl_CrPtrn = '<%=ddlCrPtrn.ClientID%>';
		    var ddl_Branch = '<%=ddlBranch.ClientID%>';
		    var txtDOB= '<%= txtDOB.ClientID%>';   
		    var TdBodyID =  '<%=TdBodyID.ClientID%>';
		    var hid_StateID =  '<%=hid_StateID.ClientID%>';
		    var hid_BodyID =  '<%=hid_BodyID.ClientID%>';
		    var Body_State = '<%=Body_State.ClientID%>';
		    var Body_ID = '<%=Body_ID.ClientID%>';
		    var hid_DOB = '<%=hidDOB.ClientID%>';
		    var hid_LastName = '<%=hidLastName.ClientID%>';
		    var hid_FirstName = '<%=hidFirstName.ClientID%>';
		    var hid_Gender = '<%=hidGender.ClientID%>';
		    var hid_ElgStatusColl = '<%=hidElgStatusColl.ClientID%>';    
		    
		    //------------------------------------------------------------------------------
		    //function to clear textbox tooltip on page load
	            window.onload=clearToolTipOnLoad;
	            function clearToolTipOnLoad()
	            {
	                if(document.getElementById("<%= tblSelect.ClientID%>").style.display!='none')
	                {
	                    if(document.getElementById("<%= txtDOB.ClientID%>").value != '')
	                        document.getElementById("<%= txtDOB.ClientID%>").focus();
    	                    
	                    document.getElementById("<%= MaskedEditValidator1.ClientID%>").innerText = '';
	                }
        	    
	            }
		     //------------------------------------------------------------------------------
    	 
		 
			//Remove Options from DDL
			
			function RemoveAllOptions(ListBox)
			{
				var LB=document.getElementById(''+ListBox+'');
				if (LB == null)
					return;				
				var iListBoxLength = LB.options.length;
				for (var i = 0; i <iListBoxLength; i++)
					LB.options.remove(1);				
			}
			
			//Set value to given field
			function setValue(Text,Value)
			{
				var text = eval(document.getElementById(Text));
				text.value = Value;
				
			}
			
			
    							
			function  FillCourse(val)
			{
			    
			    document.getElementById('<%= hidCrID.ClientID%>').value = '0';
				
			    if(val!="0")
			    {
					AjaxMethods.selInstituteWiseCourses(parseInt(uniid),parseInt(document.getElementById(hid_Inst_id).value),parseInt(val),selInstituteWiseCourses_Callback);
					
				}
				else
				{
				 var cr=document.getElementById(ddl_Course);
				 cr.selectedIndex=0;
				 cr.length=1;
				}

			}
			
			function selInstituteWiseCourses_Callback(response)
			{
			    var ds = response.value[0];
			   
			    var d=document.getElementById(ddl_Course);
			    d.length=1;
			    if(ds.Tables[0].Rows.length > 0)
			    {   
			       			        
					for(var i=0; i<ds.Tables[0].Rows.length ;i++)
					{
					d.add(new Option(ds.Tables[0].Rows[i].Cr_Desc,ds.Tables[0].Rows[i].pk_Cr_ID));
					}	
				}
				else
				{
				 d.selectedIndex=0;
				}
			}
			
			// For filling the ModeofLearning dropdown on change of Course dropdown
			
			function FillModeofLearning(val)
			{
			    document.getElementById('<%=hidMoLrnID.ClientID%>').value = '0';
    			
			    if(val!="0")
			        {
					    AjaxMethods.selModeofLearning(parseInt(uniid),parseInt(document.getElementById(hid_Inst_id).value),parseInt(document.getElementById(hid_Fac_id).value),parseInt(val),selCourseWiseMoLrn_Callback);
    					
				    }
				else
				    {
				     var cr=document.getElementById(ddl_MoLrn);
				     cr.selectedIndex=0;
				     cr.length=1;
				    }
		    }
		    
		    function selCourseWiseMoLrn_Callback(response)
		    {
		        var ds = response.value[0];
		        var d  = document.getElementById(ddl_MoLrn);
		        d.length = 1;
		        if(ds.Tables[0].Rows.length >0)
		        {
		            for(var i=0; i<ds.Tables[0].Rows.length ;i++)
					{
					    d.add(new Option(ds.Tables[0].Rows[i].MoLrn_Type,ds.Tables[0].Rows[i].pk_MoLrn_ID));
					}	
				}
				else
				{
				 d.selectedIndex=0;
				}
		  	}
		  	
		  	//To fill the CoursePattern dropdown on change of ModeofLearning dropdown
		  	
		  	function FillCoursePattern(val)
			{
			    document.getElementById('<%=hidPtrnID.ClientID%>').value = '0';			    
    			
			    if(val!="0")
			        {
					    AjaxMethods.selCoursePattern(parseInt(uniid),parseInt(document.getElementById(hid_Inst_id).value),parseInt(document.getElementById(hid_Fac_id).value),parseInt(document.getElementById(hid_Cr_id).value),parseInt(val),selCoursePattern_Callback);
    					
				    }
				else
				    {
				     var cr=document.getElementById(ddl_CrPtrn);
				     cr.selectedIndex=0;
				     cr.length=1;
				    }
		    }
		    
		    function selCoursePattern_Callback(response)
		    {
		        var ds = response.value[0];
		        var d  = document.getElementById(ddl_CrPtrn);
		        d.length = 1;
		        if(ds.Tables[0].Rows.length >0)
		        {
		            for(var i=0; i<ds.Tables[0].Rows.length ;i++)
					{
					    d.add(new Option(ds.Tables[0].Rows[i].text,ds.Tables[0].Rows[i].value));
					}	
				}
				else
				{
				 d.selectedIndex=0;
				}
		  	}
		  	
		  	//To fill the branch dropdown onchange of CoursePattern dropdown
		  	
		  	function FillBranchList(val)
			{   
			   
			    document.getElementById('<%=hidBrnID.ClientID%>').value = '0';
    			
			    if(val!="0")
			        {  
					    
					    AjaxMethods.selBranch(parseInt(uniid),parseInt(document.getElementById(hid_Inst_id).value),parseInt(document.getElementById(hid_Fac_id).value),parseInt(document.getElementById(hid_Cr_id).value),parseInt(document.getElementById(hid_MoLrn_id).value),parseInt(val),selBranch_Callback);
    					
				    }
				else
				{
				     var ddlBrn=document.getElementById(ddl_Branch);
				     ddlBrn.selectedIndex=0;
				     ddlBrn.length=1;
				     
				}
		    } 
		 
		    function selBranch_Callback(response)
		    {		   
		        var ds = response.value[0];
		        var d  = document.getElementById(ddl_Branch);
		        document.getElementById('<%= hidBranchName.ClientID%>').value="";
		        d.length = 0;
		        if(ds.Tables[0].Rows.length >0)
		        {   
		            if(ds.Tables[0].Rows.length ==1)
		            {  
		                if(ds.Tables[0].Rows[0].Text=="No Branch")
		                {
		                 d.add(new Option(ds.Tables[0].Rows[0].Text,ds.Tables[0].Rows[0].Value));		                 
		                }
		                else
		                {
		                 d.add(new Option("--- Select ---","-1"));
		                 d.add(new Option(ds.Tables[0].Rows[0].Text,ds.Tables[0].Rows[0].Value));
		                }
		            }
		            else if(ds.Tables[0].Rows.length >1)
		            {		            
		                for(var i=0; i<ds.Tables[0].Rows.length ;i++)
					    {
					        d.add(new Option(ds.Tables[0].Rows[i].Text,ds.Tables[0].Rows[i].Value));
					    }	
					}
				}
				else
				{
				  d.add(new Option('No Branch','0'));
				  d.selectedIndex=0;
				  document.getElementById(hid_Brn_id).value = 0;              
				  document.getElementById('<%= hidBranchName.ClientID%>').value="No Branch";
				}				
		  	}
		  	
		  	//Function to clear all the following DropDowns on change of a Dropdown
		  	
		  	function ClearDropDowns(FromLevel, LevelFlag)
            {	

	            switch (FromLevel)
	            { 
		            case 1:
				            if(LevelFlag >= 2)
				            {
					            ClearDropDownList(document.getElementById(ddl_Course));
					            document.getElementById('<%= hidMoLrnID.ClientID%>').value = '0';
				                document.getElementById('<%= hidPtrnID.ClientID%>').value = '0';
				                document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				                document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';
				                document.getElementById('<%= hidBranchName.ClientID%>').value="";
				            }
		            case 2:
				            if(LevelFlag >= 3)
				            {
					            ClearDropDownList(document.getElementById(ddl_MoLrn));					        
				                document.getElementById('<%= hidPtrnID.ClientID%>').value = '0';
				                document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				                document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';	
				                document.getElementById('<%= hidBranchName.ClientID%>').value="";				        
				            }
		            case 3:
				            if(LevelFlag >= 4)
				            {					       
					            ClearDropDownList(document.getElementById(ddl_CrPtrn));					        
				                document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				                document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';
				                document.getElementById('<%= hidBranchName.ClientID%>').value="";
				            }
	                case 4:
				            if(LevelFlag >= 5)
				            {					       
					            ClearDropDownList(document.getElementById(ddl_Branch));					        
				                document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';		
				                document.getElementById('<%= hidBranchName.ClientID%>').value="";		       
    					       
				            }
	   	          }
             }

                // To Clear Drop Down List (Filter List).....Developed By Madhu & Farhat
            function ClearDropDownList(ddlObject)
                {                  
	                while(ddlObject.length > 1)
	                {                	  
		                ddlObject.remove(1);
	                }
	                if(ddlObject.length==1 && ddlObject.options[0].text=="No Branch")
	                {
	                    ddlObject.length=0;
	                    ddlObject.add(new Option("---Select---","0"));
	                }
                }		  	
		 						
			function fnClearSearchCriteria()
			{
				
				document.getElementById(txtDOB).value = '';
				document.getElementById('<%= txtLastName.ClientID %>').value = '';
				document.getElementById('<%= txtFirstName.ClientID %>').value = '';		
				document.getElementById('<%= ddlFaculty.ClientID%>').value = "0";
				document.getElementById('<%= ddlCourse.ClientID%>').value = "0";
				document.getElementById('<%= ddlMoLrn.ClientID%>').value = "0";
				document.getElementById('<%= ddlCrPtrn.ClientID%>').value = "0";
				document.getElementById('<%= ddlBranch.ClientID%>').value = "0";
				document.getElementById('<%= hidBranchName.ClientID%>').value="";	
				document.getElementById('<%= ddlBranch.ClientID%>').options[0].text = "---Select---";
				document.getElementById('<%= ddlGender.ClientID%>').value = "-1";			
				document.getElementById('<%= hidStateID.ClientID%>').value = '0';
				document.getElementById('<%= hidDistrictID.ClientID%>').value = '0';
				document.getElementById('<%= hidTehsilID.ClientID%>').value = '0';
				document.getElementById('<%= hidFacID.ClientID%>').value = '0';
				document.getElementById('<%= hidCrID.ClientID%>').value = '0';
				document.getElementById('<%= hidMoLrnID.ClientID%>').value = '0';
				document.getElementById('<%= hidPtrnID.ClientID%>').value = '0';
				document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';					
				
				document.getElementById('<%= tblDGRegPendingStudents.ClientID %>').style.display = 'none';
				document.getElementById('<%= lblGridName.ClientID %>').style.display = 'none';
				document.getElementById('<%= divDGNote.ClientID %>').style.display = 'none';
				document.getElementById('<% = rbFilterYesNo.ClientID%>'+"_0").checked ="true";
				document.getElementById('<% = Body_ID.ClientID%>').value = '0';
				document.getElementById('<% = Body_State.ClientID%>').value = '0';
				document.getElementById('<% = hid_StateID.ClientID%>').value = '0';
				document.getElementById('<% = hid_BodyID.ClientID%>').value = '0';                
                document.getElementById('<%= DivFilterExamBody.ClientID%>').style.display = "none";                 
                document.getElementById('<%= tblDGRegPendingStudents.ClientID %>').style.display = "none"; 
                               			
                document.getElementById('<%= Div1.ClientID%>').style.display = 'none';
                document.getElementById('<%= Fieldset3.ClientID%>').style.display = 'none';
                document.getElementById('<%= DivFilterExamBody.ClientID%>').style.display = 'none';
                document.getElementById('<%= trbtnSearchWithExamBody.ClientID%>').style.display = 'none';
				return true;								
			}
            
            function fnFilterClickYesNo()
        
            {          
             
			var rdFilter0 = document.getElementById('<%=rbFilterYesNo.ClientID%>'+"_0");
			var rdFilter1 = document.getElementById('<%=rbFilterYesNo.ClientID%>'+"_1");		
			         
			if(rdFilter0.checked)               // Yes Examining body filter
          
            { 	
				
                 document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_DivFilterExamBody').style.display = "block";  
                 document.getElementById('<%= Body_ID.ClientID%>').value = '0';
				 document.getElementById('<%= Body_State.ClientID%>').value = '0';
				 //fillStateBoard('<%= TdBodyID.ClientID %>','0','0');
				 //alert('<%= TdBodyID.ClientID %>'); 

                document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrBody_Indian_Foreign').style.display = 'inline';
				document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrState').style.display = 'inline';
				document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrBody').style.display = 'inline';
                document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrCountryForeignBoardUniv').style.display = 'none';
				document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrCountry').style.display = 'none';
                document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_Body_Indian_Foreign_Flag_0').checked = true;
            }
            else if(rdFilter1.checked)         // No Examining body filter   
            {                 
                document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_DivFilterExamBody').style.display = "none";                                 
                document.getElementById('<%= Body_ID.ClientID%>').value = '0';
				document.getElementById('<%= Body_State.ClientID%>').value = '0'; 

            }       
            //***************************************************
            document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_lblGridName').style.display = "none";                 
			document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_divDGNote').style.display = "none"; 
			document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_tblDGRegPendingStudents').style.display ="none" ;
            document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_divColorCodes').style.display = "none";  
            //***************************************************
            }
						  
						  
			
		function OnBodyTypeChange()
		{
		    
//			var rd = new Array();
//			rd[0] = document.getElementById('<%= Body_Type_Flag.ClientID %>'+"_0");
//			rd[1] = document.getElementById('<%= Body_Type_Flag.ClientID %>'+"_1");
//			
//			if(rd[0].checked) //Board
//			{		
//					document.getElementById('<%= TrBody_Indian_Foreign.ClientID %>').style.display = 'inline';
//					document.getElementById('<%= TrState.ClientID %>').style.display = 'inline';
//					document.getElementById('<%= TrBody.ClientID %>').style.display = 'inline';
//					document.getElementById('<%= TrCountry.ClientID %>').style.display = 'inline';					
//					document.getElementById('<%= TdBodyCaption.ClientID %>').innerText = "Select Board";									
//					document.getElementById('<%= Body_State.ClientID %>').value="0";
//					document.getElementById('<%= Body_ID.ClientID%>').value = '0';	
//					OnIndianForeignChange();
//			}
//			else if(rd[1].checked)//University
//			{	 		
//					document.getElementById('<%= TrBody_Indian_Foreign.ClientID %>').style.display = 'inline';
//					document.getElementById('<%= TrState.ClientID %>').style.display = 'inline';
//					document.getElementById('<%= TrBody.ClientID %>').style.display = 'inline';
//					document.getElementById('<%= TrCountry.ClientID %>').style.display = 'inline';
//					document.getElementById('<%= TdBodyCaption.ClientID %>').innerText = "Select "+document.getElementById('<%=lblUniversity.ClientID %>').innerText+"";									
//					document.getElementById('<%= Body_State.ClientID %>').value="0";
//					document.getElementById('<%= Body_ID.ClientID%>').value = '0';	
//                    									
//				    OnIndianForeignChange();
//			}			


        var rd0 = document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_Body_Type_Flag_0');
			var rd1 = document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_Body_Type_Flag_1');		    
			
			if(rd0.checked) //Board
			{								
					document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrBody_Indian_Foreign').style.display = 'inline';
					if(document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_Body_Indian_Foreign_Flag_0').checked)
					{
					document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrState').style.display = 'inline';
					document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrBody').style.display = 'inline';
					//document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrCountry').style.display = 'inline';					
					document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrCountry').style.display = "none";
					}
					else
					{	document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrState').style.display = 'none';
					document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrBody').style.display = 'none';
					document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrCountry').style.display = 'inline';					
					//document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrCountry').style.display = "none";
					
					}
                    var TdBodyCaption = document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TdBodyCaption');
                    if(TdBodyCaption != null)
					TdBodyCaption.innerText = "Select Board";	
                        				
					document.getElementById('<%= Body_State.ClientID %>').value="0";
					document.getElementById('<%= Body_ID.ClientID%>').value = '0';							
					
				
			}
			else if(rd1.checked)//University
			{			
								
					document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrBody_Indian_Foreign').style.display = 'inline';
					document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrState').style.display = 'inline';
					document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrBody').style.display = 'inline';
                    document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrCountryForeignBoardUniv').style.display = 'none';
					document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TrCountry').style.display = 'none';
                    document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_Body_Indian_Foreign_Flag_0').checked = true;

                    var TdBodyCaption = document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_TdBodyCaption');
                    if(TdBodyCaption != null)
					TdBodyCaption.innerText = "Select "+document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_lblUniversity').innerText+"";	
                    				
					document.getElementById('<%= Body_State.ClientID %>').value="0";
					document.getElementById('<%= Body_ID.ClientID%>').value = '0';			    
				    	
			}		
            
       	}
		
		function OnIndianForeignChange()
		{
			var rdIFC = new Array();
			rdIFC[0] = document.getElementById('<%= Body_Indian_Foreign_Flag.ClientID %>'+"_0");
			rdIFC[1] = document.getElementById('<%= Body_Indian_Foreign_Flag.ClientID %>'+"_1");			
					
							
			if(rdIFC[0].checked)//India
			{
				document.getElementById('<%= TrState.ClientID %>').style.display = 'inline';
				document.getElementById('<%= TrBody.ClientID %>').style.display = 'inline';
				document.getElementById('<%= TrCountry.ClientID %>').style.display = 'none';				
				document.getElementById('<%= TrCountryForeignBoardUniv.ClientID %>').style.display = 'none';				
				document.getElementById('<%= txtForeignBoardUnivName.ClientID %>').style.display = 'none';
				document.getElementById('<%= txtForeignBoardUnivName.ClientID %>').value="";											
				document.getElementById('<%= Body_Country.ClientID %>').value="0";
				document.getElementById('<%= Body_Country.ClientID %>').style.display = 'none';			
				fillStateBoard('<%= TdBodyID.ClientID %>',0,0);
				
			}
			else if(rdIFC[1].checked)//Foreign
			{ 		
				document.getElementById('<%= TrState.ClientID %>').style.display = 'none';
				document.getElementById('<%= TrBody.ClientID %>').style.display = 'none';
				document.getElementById('<%= TrCountry.ClientID %>').style.display = 'inline';										
				document.getElementById('<%= Body_State.ClientID %>').value="0";				
				document.getElementById('<%= TrCountryForeignBoardUniv.ClientID %>').style.display = 'inline';
				document.getElementById('<%= txtForeignBoardUnivName.ClientID %>').style.display = 'inline';
				document.getElementById('<%= txtForeignBoardUnivName.ClientID %>').value="";
				document.getElementById('<%= Body_Country.ClientID %>').style.display = 'inline';
				document.getElementById('<%= Body_Country.ClientID %>').value="0";				
				fillStateBoard('<%= TdBodyID.ClientID %>',0,0);
			}
		}		
		
		function setValueState(Text,Value)
			{					
				var text = eval(Text);
				text.value = Value;	
				
			}
		
		function fillStateBoard(val) //New Logic for Board Details
			{
			    
			    document.getElementById('<%=hid_BodyID.ClientID%>').value = '0';    			
			    if (document.getElementById('<%= Body_Type_Flag.ClientID%>'+"_0").checked)//Board
			        {  
					    				   
					    AjaxMethods.fillStateBoard1(parseInt(uniid),parseInt(document.getElementById(hid_Inst_id).value),parseInt(document.getElementById(Body_State).value),parseInt(document.getElementById(hid_Fac_id).value),parseInt(document.getElementById(hid_Cr_id).value),parseInt(document.getElementById(hid_MoLrn_id).value),parseInt(document.getElementById(hid_Ptrn_id).value),parseInt(document.getElementById(hid_Brn_id).value),document.getElementById(hid_DOB).value,document.getElementById(hid_LastName).value,document.getElementById(hid_FirstName).value,document.getElementById(hid_Gender).value,document.getElementById(hid_ElgStatusColl).value,selfillStateBoard_Callback)
					    //AjaxMethods.fillStateBoard1(parseInt(uniid),parseInt(document.getElementById(hid_Inst_id).value),parseInt(document.getElementById(Body_State).value),parseInt(document.getElementById(hid_Fac_id).value),parseInt(document.getElementById(hid_Cr_id).value),parseInt(document.getElementById(hid_MoLrn_id).value),parseInt(document.getElementById(hid_Ptrn_id).value),parseInt(document.getElementById(hid_Brn_id).value),selfillStateBoard_Callback)
					    					    
				    }
				    
				 else if (document.getElementById('<%= Body_Type_Flag.ClientID%>'+"_1").checked)//University
			        {			        
					    
					   					    
					    AjaxMethods.fillStateUniversity1(parseInt(document.getElementById(Body_State).value),parseInt(uniid),parseInt(document.getElementById(hid_Inst_id).value),parseInt(document.getElementById(hid_Fac_id).value),parseInt(document.getElementById(hid_Cr_id).value),parseInt(document.getElementById(hid_MoLrn_id).value),parseInt(document.getElementById(hid_Ptrn_id).value),parseInt(document.getElementById(hid_Brn_id).value),parseInt(val),selfillStateUniversity_Callback);
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
            
            
            function validateExaminingBody()
            {
                var rbFilterYesNo = document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_rbFilterYesNo_0');
                if(rbFilterYesNo.checked == true)       // If Examining Body filter is applied
                {
                    if (document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_Body_Indian_Foreign_Flag_0').checked)    //Indian Board
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


            function funDDCourseChanged()
            {
                //***************************************************
                document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_lblGridName').style.display = "none";                 
		        document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_divDGNote').style.display = "none"; 
		        document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_tblDGRegPendingStudents').style.display ="none" ;
                document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_divColorCodes').style.display = "none";  
                document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvancedSearchforManualProcess1_Div1').style.display = "none"; 
                //***************************************************
            }
            	
</script>

<body leftmargin="0" topmargin="0">
    <center>
        <table id="Table4" cellspacing="0" width="100%" border="0">
            <tr>
                <td style="width: 952px;" align="center" colspan="3">
                    <!-- Selection Starts -->
                    <div id="divAcademicYr" runat="server" align = "center">
                        <fieldset id="tblAcademicYr" style="width: 550px;" runat="server">
                            <legend><b>Select Academic Year </b></legend>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="height: 20px;" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 20px; width: 125px;">
                                        <asp:Label ID="lblAcyr" runat="server" Font-Bold="True" Width="221px" meta:resourcekey="lblAcyrResource1" Text="Select Academic Year"></asp:Label></td>
                                    <td align="center" style="height: 20px; width: 1%">
                                        <b>:</b></td>
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
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px;" colspan="3">
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                    <div id="tblSelect" runat = server style="display:none">
                    <fieldset id="tblSelect1" runat="server">
                        <legend><strong>Search Student(s)</strong></legend>
                        <table cellspacing="0" cellpadding="0" width="95%" border="0">
                            <tr>
                                <td colspan="3" style="height:10px"></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 19px; width: 234px;">
                                    <b>
                                        <asp:Label ID="lblFaculty" runat="server" Text="Select Faculty" meta:resourcekey="lblFacultyResource1"></asp:Label>
                                    </b>
                                </td>
                                <td style="height: 19px; width: 2%">
                                    <b>:</b>
                                </td>
                                <td colspan="3" style="height: 19px" align="left">
                                    <asp:DropDownList ID="ddlFaculty" runat="server" Width="260px" CssClass="selectbox"
                                        onchange="setValue(hid_Fac_id,this.value);FillCourse(this.value);ClearDropDowns(1,5); funDDCourseChanged();"
                                        meta:resourcekey="ddlFacultyResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 234px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 19px; width: 234px;">
                                    <b>
                                        <asp:Label ID="lblCourse" runat="server" Text="Select Course" meta:resourcekey="lblCourseResource1"></asp:Label>
                                    </b>
                                </td>
                                <td style="height: 19px; width: 2%">
                                    <b>:</b>
                                </td>
                                <td colspan="3" style="height: 19px" align="left">
                                    <asp:DropDownList ID="ddlCourse" runat="server" Width="260px" CssClass="selectbox"
                                        onchange="setValue(hid_Cr_id,this.value);FillModeofLearning(this.value);ClearDropDowns(2,5); funDDCourseChanged();"
                                        meta:resourcekey="ddlCourseResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource2" Text="--- Select ---"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 234px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 234px">
                                    <b>Select Mode of Learning </b>
                                </td>
                                <td style="width: 2%">
                                    <b>:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:DropDownList ID="ddlMoLrn" runat="server" Width="260px" CssClass="selectbox"
                                        onchange="setValue(hid_MoLrn_id,this.value);FillCoursePattern(this.value);ClearDropDowns(3,5); funDDCourseChanged();"
                                        meta:resourcekey="ddlMoLrnResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource3" Text="--- Select ---"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 234px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 234px">
                                    <b><asp:Label ID="lblCrPattern" runat="server" text="Select Course Pattern" meta:resourcekey="lblCrPatternResource1"></asp:Label> </b>
                                </td>
                                <td style="width: 2%">
                                    <b>:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:DropDownList ID="ddlCrPtrn" runat="server" Width="260px" CssClass="selectbox"
                                        onchange="setValue(hid_Ptrn_id,this.value);FillBranchList(this.value);ClearDropDowns(4,5);funDDCourseChanged(); "
                                        meta:resourcekey="ddlCrPtrnResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource4" Text="--- Select ---"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 234px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 19px; width: 234px;">
                                    <b>Select Branch </b>
                                </td>
                                <td style="height: 19px; width: 2%">
                                    <b>:</b>
                                </td>
                                <td id="tdBranch" colspan="3" style="height: 19px" align="left">
                                    <asp:DropDownList ID="ddlBranch" runat="server" Width="260px" CssClass="selectbox"
                                        onchange="setValue(hid_Brn_id, this.value);funDDCourseChanged();" meta:resourcekey="ddlBranchResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource5" Text="--- Select ---"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 234px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 234px">
                                    <b>Date of Birth </b>
                                </td>
                                <td style="width: 1%">
                                    <b>:</b>
                                </td>
                                <td style="width: 400px" align="left">
                                    <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" CssClass="inputbox" meta:resourcekey="txtDOBResource1" Width="70px"></asp:TextBox>&nbsp;
            <%--                       <a id="alinkCalender"  onclick="return showCalendar(document.getElementById(txtDOB).id, '%d/%m/%Y');" runat="server">--%>
                                        <%--<img onmouseover="this.style.cursor='Hand'" src="../images/cal.gif" align="middle"/></a>&nbsp;--%>
                                    <b>[dd/mm/yyyy]</b>
                                    
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOB"
                                                    Format="dd/MM/yyyy" Enabled="True" PopupPosition="BottomRight" >
                                                </cc1:CalendarExtender>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDOB"
                                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureName="en-GB"
                                                    CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="&#163;" CultureDateFormat="DMY"
                                                    CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder=","
                                                    CultureTimePlaceholder=":" Enabled="True">
                                                </cc1:MaskedEditExtender>
                                                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtDOB" IsValidEmpty="True"
                                                    InvalidValueMessage="Date is invalid" ValidationGroup="dateValidator1" TooltipMessage="Input a Date" MaximumValue="31/12/9999" MinimumValue="01/01/1753" MaximumValueMessage="Date is invalid" MinimumValueMessage="Date is invalid"/>
                                                    </td>
                                <td align="right" style="width: 15%">
                                    <b>Gender </b>
                                </td>
                                <td style="width: 1%">
                                    <b>:</b>
                                </td>
                                <td width="20%" align="left">
                                    <asp:DropDownList ID="ddlGender" CssClass="selectbox" runat="server" meta:resourcekey="ddlGenderResource1">
                                        <asp:ListItem Value="0" Selected="True" meta:resourcekey="ListItemResource7" Text="--- Select ---"></asp:ListItem>
                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource8" Text="Male"></asp:ListItem>
                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource9" Text="Female"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 234px">
                                    <b>Last Name </b>
                                </td>
                                <td style="width: 1%">
                                    <b>: </b>
                                </td>
                                <td style="width: 295px" align="left">
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="inputbox" meta:resourcekey="txtLastNameResource1"></asp:TextBox></td>
                                <td align="right" style="width: 15%">
                                    <b>First Name </b>
                                </td>
                                <td style="width: 1%">
                                    <b>:</b>
                                </td>
                                <td width="20%">
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputbox" meta:resourcekey="txtFirstNameResource1"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 234px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 234px">
                                    <strong>Display List of Students with Eligibility&nbsp;</strong>
                                </td>
                                <td style="width: 1%">
                                    <b>:</b>
                                </td>
                                <td colspan="4" align="left">
                                    <asp:RadioButton ID="rbUni" runat="server" GroupName="EligibleStud" Text="To be decided by University"
                                        Checked="True" meta:resourcekey="rbUniResource1" />
                                    &nbsp;
                                    <asp:RadioButton ID="rbColl" runat="server" GroupName="EligibleStud" Text="Already decided by College"
                                        meta:resourcekey="rbCollResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 234px;">
                                </td>
                            </tr>
                           <%-- <tr>
                                <td align="right" style="width: 234px">
                                    <b>Consider Payment Status</b>
                                </td>
                                <td style="height: 10px; width: 1%">
                                    <b>:</b>
                                </td>
                                <td colspan="4" align="left">
                                    <asp:RadioButton ID="rbWithInv" Text="Yes"
                                         GroupName="grpInvoice" runat="server" />&nbsp;
                                   
                                    <asp:RadioButton ID="rbWithoutInv" Text="No"
                                        GroupName="grpInvoice" runat="server" Checked="True" />
                                </td>
                            </tr>--%>
                            <%--<tr id="Tr1" height="10px" runat="server">
                                <td align="right" style="height: 10px; width: 234px;">
                                    <strong>Do you want to use Filters for selecting Examining Body</strong></td>
                                <td style="height: 10px; width: 1%">
                                    <strong>&nbsp;:</strong></td>
                                <td style="height: 10px; width: 295px;">
                                    <asp:RadioButtonList ID="rbFilterYesNo" onclick="fnFilterClickYesNo();" runat="server"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>--%>
                            <tr>
                                <td style="height: 5px; width: 234px;">
                                </td>
                            </tr>
                            <tr id="trbtnSearch" runat="server" style="display: none;">
                                <td align="center" colspan="6">
                                    &nbsp;<asp:Button ID="btnSearchCourse" runat="server" Width="70px" CssClass="butSubmit"
                                        Text="Search" Height="25px" OnClick="btnSearchCourse_Click" ValidationGroup="dateValidator1" meta:resourcekey="btnSearchCourseResource1">
                                    </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button CssClass="butSubmit" ID="btnClear" Text="Clear Search Criteria" Height="25px"
                                        runat="server" Width="150px" meta:resourcekey="btnClearResource1" OnClick="btnClear_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    </div>
                    <br />
                    <br />
                    <div id="Div1" runat="server" style="display: none">
                        <fieldset id="Fieldset3" runat="server">
                            <legend><strong>Examining Body Filter</strong></legend>
                            <table cellspacing="0" cellpadding="0" width="95%" border="0">
                                <tr style="height: 5px;">
                                    <td>
                                    </td>
                                </tr>
                                <tr id="Tr1" style="height:10px; width:100%" runat="server">
                                    <td align="right" style="height: 10px;width:380px;">
                                        <strong>Do you want to use Filters for selecting Examining Body</strong></td>
                                    <td style="height: 10px; width: 1%">
                                        <strong>:</strong></td>
                                    <td style="height: 10px;" align="left">
                                        <asp:RadioButtonList ID="rbFilterYesNo" onclick="fnFilterClickYesNo();" runat="server"
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="0" Selected="True" Text="No"></asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr style="height:10px;"><td></td></tr>                                
                            </table>
                            <%--</fieldset>--%>
                            <%-- </div> --%>                                          
                                                
                                                
                    <div id="DivFilterExamBody" runat="server" style="display: none">
                            <fieldset id="DivFilterExamBody1" runat="server">
                                <legend><strong>Examining Body Selection Criteria</strong></legend>
                                <table cellspacing="0" cellpadding="0" width="95%" border="0">
                                    <tr id="TrExamBody" height="10px" runat="server">
                                        <td align="right" style="height: 10px; width: 28%;">
                                            <strong>Select Examining Body</strong></td>
                                        <td align="center" style="height: 10px; width: 1%;">
                                            <strong>:</strong></td>
                                        <td align="left">
                                            <asp:RadioButtonList ID="Body_Type_Flag" onclick="OnBodyTypeChange();" runat="server"
                                                RepeatDirection="Horizontal" meta:resourcekey="Body_Type_FlagResource1">
                                                <asp:ListItem Value="1" Selected="True" meta:resourcekey="ListItemResource11" Text="Board"></asp:ListItem>
                                                <asp:ListItem Value="2" meta:resourcekey="ListItemResource12" Text="University"></asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr id="TrBody_Indian_Foreign" runat="server">
                                        <td id="TdBody_Indian_Foreign" align="right" style="width: 28%">
                                            <strong>Select Board</strong></td>
                                        <td align="center" style="width: 1%">
                                            <strong>:</strong></td>
                                        <td align="left">
                                            <asp:RadioButtonList ID="Body_Indian_Foreign_Flag" onclick="OnIndianForeignChange();"
                                                runat="server" RepeatDirection="Horizontal" meta:resourcekey="Body_Indian_Foreign_FlagResource1">
                                                <asp:ListItem Value="0" Selected="True" meta:resourcekey="ListItemResource13" Text="Indian"></asp:ListItem>
                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource14" Text="Foreign"></asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr id="TrCountry" style="display: none" runat="server">
                                        <td style="height: 28px; width: 28%;" align="right">
                                            <strong>Select Country</strong></td>
                                        <td style="height: 28px; width: 1%;" align="center">
                                            <strong>:</strong></td>
                                        <td style="height: 28px" align="left">
                                            <asp:DropDownList ID="Body_Country" runat="server" CssClass="selectbox" Width="198px" meta:resourcekey="Body_CountryResource1">
                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource15" Text="-- Select --"></asp:ListItem>
                                            </asp:DropDownList><font class="Mandatory">*</font></td>
                                    </tr>
                                   
                                    <tr id="TrCountryForeignBoardUniv" style="display: none" runat="server">
                                        <td style="height: 20px; width: 28%;" align="right">
                                            <strong><asp:Label ID="lblUniversityName" runat="server" Text="University Name" meta:resourcekey="lblUniversityNameResource1"></asp:Label></strong></td>
                                        <td style="height: 20px; width: 1%;" align="center">
                                            <strong>:</strong></td>
                                        <td style="height: 20px; width: 100%;" align="left">
                                            <b>
                                                <asp:TextBox ID="txtForeignBoardUnivName" runat="server" CssClass="inputbox" Width="418px" meta:resourcekey="txtForeignBoardUnivNameResource1"></asp:TextBox></b></td>
                                    </tr>
                                    <tr id="TrState" runat="server">
                                        <td style="height: 28px; width: 28%;" align="right">
                                            <strong>Select State</strong></td>
                                        <td style="height: 28px; width: 1%;" align="center">
                                            <strong>:</strong></td>
                                        <td id="TdState" style="height: 28px" align="left">
                                            <asp:DropDownList ID="Body_State" runat="server" onblur="setValueState(document.getElementById(hid_StateID),this.value)"
                                                onchange="fillStateBoard(this.value);" CssClass="selectbox" Width="198px" meta:resourcekey="Body_StateResource1">
                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource16" Text="-- Select --"></asp:ListItem>
                                            </asp:DropDownList><font class="Mandatory">*</font></td>
                                    </tr>
                                    
                                    <tr id="TrBody" runat="server">
                                        <td id="TdBodyCaption" style="height: 15px; width: 28%;  font-weight:bold;" align="right">
                                            <strong><%--<asp:Label ID="lblSelectBoard" runat="server" Text="Select Board" meta:resourcekey="lblSelectBoardResource1"></asp:Label>--%></strong></td>
                                        <td style="height: 15px; width: 1%;" align="center">
                                            <strong>:</strong></td>
                                        <td id="TdBodyID" style="height: 15px" align="left">
                                            <asp:DropDownList ID="Body_ID" onblur="setValueState(document.getElementById(hid_BodyID),this.value)"
                                                runat="server" CssClass="selectbox" Width="418px" meta:resourcekey="Body_IDResource1">
                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource17" Text="-- Select --"></asp:ListItem>
                                            </asp:DropDownList><font class="Mandatory">*</font></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px;">
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                            </div>
                            
                            <table id="tblFacNotSelected" runat="server" style="display:none;">
                                <tr id="trFacNotSelected" runat="server" style="display:none;">
                                <td align="left" style="font-size:8pt;">
                                    <asp:Label ID="lblFacNotSelected" runat="server" Width="100%" ForeColor="Red" Font-Bold="True"
                                     Text="As you have not selected all the criteria from the Course Selection dropdowns, you can not use the Examining Body Filters. Please click on the 'Search' button to display the list of students. " meta:resourcekey="lblFacNotSelectedResource1"></asp:Label>
                   
                                </td>
                                </tr>
                            </table>
                            
                            <table cellspacing="0" cellpadding="0" width="95%" border="0">
                                <tr style="height: 5px;">
                                    <td>
                                    </td>
                                </tr>
                                <tr id="trbtnSearchWithExamBody" runat="server" style="display: none;">
                                    <td align="center" colspan="6">
                                        &nbsp;<asp:Button ID="Button1" runat="server" Width="146px" CssClass="butSubmit" Text="Display Student(s) List"
                                            Height="25px" OnClick="btnSearch_Click" OnClientClick="return validateExaminingBody();" meta:resourcekey="btnSearchResource1"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                        
                                    </td>
                                </tr>
                                <tr style="height: 5px;">
                                    <td>
                                    </td>
                                </tr>
                            </table>                            
                        </fieldset>
                    </div>
                    <%--<div id="DivFacNotSelected" runat="server">--%>
                    
                   <%-- </div>--%>
                </td>
            </tr>
            <%-- <tr id="trbtnSearch" runat="server" style="display: none;">
                <td align="center" colspan="6">
                    &nbsp;<asp:Button ID="btnSearch" runat="server" Width="70px" CssClass="butSubmit"
                        Text="Search" Height="25px" OnClick="btnSearch_Click" meta:resourcekey="btnSearchResource1">
                    </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button CssClass="butSubmit" ID="btnClear" Text="Clear Search Criteria" Height="25px"
                        runat="server" Width="150px" meta:resourcekey="btnClearResource1" />
                </td>
            </tr>
            <tr>
                <td style="height: 5px;">
                </td>
            </tr>--%>
            <tr style="height:10px;"><td></td></tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lblGridName" Style="display: none" runat="server" Width="99%" CssClass="errorNote"
                        Height="18px" meta:resourcekey="lblGridNameResource1"></asp:Label>
                    <%-- </p>--%>
                </td>
            </tr>
            <tr>
                <td style="height: 5px;">
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divDGNote" style="display: none" align="left" runat="server">
                        <font color="red">* Please click on the student name to view his/her respective profile.</font></div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divColorCodes" style="display: none" align="left" runat="server">
                    <br />
                    <b>Following are the color codes which are used in the Students' list to distinguish the students according to the given 4 types of Examining Bodies:</b>
                    <br />
                    <asp:Label ID="LblSame_university" BackColor="#FFE4C4" runat="server" Text="Same Board/University"></asp:Label>&nbsp;
                    <asp:Label ID="LblHome_board" BackColor="#E1FFFF" runat="server" Text="Same State Board/University"></asp:Label>&nbsp;   
                    <asp:Label ID="LblOther_state_board" BackColor="#CCEEFF" runat="server" Text="Other State Board/University"></asp:Label>&nbsp;
                    <asp:Label ID="LblForeign_board" BackColor="#FFCCFF" runat="server" Text="Foreign Board/University"></asp:Label> 
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 953px" align="center" colspan="3">
                    &nbsp;<table id="tblDGRegPendingStudents" style="display: none" width="100%" runat="server">
                        <tr>
                            <td>
                                <asp:GridView ID="dgRegPendingStudent" runat="server" Width="100%" BorderWidth="1px"
                                    BorderStyle="Solid" AllowPaging="True" BorderColor="#336699" AutoGenerateColumns="False"
                                    AllowSorting="True" OnPageIndexChanging="dgRegPendingStudent_PageIndexChanging" CssClass="clGrid grid-view"
                                    OnRowCommand="dgRegPendingStudent_RowCommand" OnRowDataBound="dgRegPendingStudent_RowDataBound"
                                    OnSorting="dgRegPendingStudent_Sorting" meta:resourcekey="dgRegPendingStudentResource1">
                                    <RowStyle CssClass="gridItem"></RowStyle>
                                    <HeaderStyle CssClass="gridHeader" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                            <ItemTemplate>
                                                <%# (Container.DataItemIndex)+1 %>
                                            </ItemTemplate>
                                            <ItemStyle Width="3%" HorizontalAlign="Center" />
                                            
                                            <HeaderStyle CssClass="gridHeader" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Eligibility_Form_No" ReadOnly="True" HeaderText="Eligibility Form No"
                                            SortExpression="Eligibility_Form_No" meta:resourcekey="BoundFieldResource1">
                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:ButtonField Text="Button" DataTextField="StudentName" HeaderText="Student Name"
                                            CommandName="PendingStudentDetails" SortExpression="StudentName" meta:resourcekey="ButtonFieldResource1">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                            <ItemStyle Width="30%" />
                                        </asp:ButtonField>
                                        <asp:BoundField DataField="InstituteName" ReadOnly="True" HeaderText="College Name"
                                            meta:resourcekey="BoundFieldResource2">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CourseName" ReadOnly="True" HeaderText="Course Admitted To"
                                            meta:resourcekey="BoundFieldResource3">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Body_Name" HeaderText="Examining Body" SortExpression="Body_Name">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="State_Name" HeaderText="State" SortExpression="State_Name">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="DocCount" HeaderText="No of Documents Submitted" meta:resourcekey="BoundFieldResource4">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pkYear" ReadOnly="True" HeaderText="pkYear" meta:resourcekey="BoundFieldResource5">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pkStudentID" ReadOnly="True" HeaderText="pkStudentID"
                                            meta:resourcekey="BoundFieldResource6"></asp:BoundField>
                                        <asp:BoundField DataField="pkFacID" ReadOnly="True" HeaderText="pkFacID" meta:resourcekey="BoundFieldResource7">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pkCrID" HeaderText="pkCrID" meta:resourcekey="BoundFieldResource8">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pkMoLrnID" HeaderText="pkMoLrnID" meta:resourcekey="BoundFieldResource9">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pkPtrnID" HeaderText="pkPtrnID" meta:resourcekey="BoundFieldResource10">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pkBrnID" HeaderText="pkBrnID" meta:resourcekey="BoundFieldResource11">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="pkCrPrDetails" HeaderText="pkCrPrDetailsID" meta:resourcekey="BoundFieldResource12">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ExamBodyType" HeaderText="ExamBodyType"></asp:BoundField>
                                    </Columns>
                                    <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                    </PagerStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="height:10px;"><td></td></tr>
             </table>
            <input id="hidUniID" type="hidden" name="hidUniID" runat="server"/>
            <input id="hidInstID" type="hidden" name="hidInstID" runat="server"/>
            <input id="hidStateID" type="hidden" name="hidStateID" runat="server"/>
            <input id="hidDistrictID" type="hidden" name="hidDistrictID" runat="server"/>
            <input id="hidTehsilID" type="hidden" name="hidTehsilID" runat="server"/>
            <input id="hidFacID" type="hidden" value="0" name="hidFacID" runat="server"/>
            <input id="hidCrID" type="hidden" value="0" name="hidCrID" runat="server"/>
            <input id="hidMoLrnID" type="hidden" value="0" name="hidMoLrnID" runat="server"/>
            <input id="hidPtrnID" type="hidden" value="0" name="hidPtrnID" runat="server"/>
            <input id="hidBrnID" type="hidden" value="0" name="hidBrnID" runat="server"/>
            <input id="hidCrPrDetailsID" type="hidden" value="0" name="hidCrPrDetailsID" runat="server"/>
            <input id="hidCountryId" type="hidden" value="0" name="hidcountryId" runat="server" />
            <input id="hidElgFormNo" type="hidden" value="0" name="hidElgFormNo" runat="server"/>
            <input id="hidpkStudentID" type="hidden" value="0" name="hidpkStudentID" runat="server"/>
            <input id="hidStep" type="hidden" name="hidStep" runat="server"/>
            <input id="hidpkYear" type="hidden" value="0" name="hidpkYear" runat="server"/>
            <input id="hidDOB" type="hidden" name="hidDOB" runat="server"/>
            <input id="hidLastName" type="hidden" name="hidDOB" runat="server"/>
            <input id="hidFirstName" type="hidden" name="hidDOB" runat="server"/>
            <input id="hidGender" type="hidden" name="hidDOB" runat="server"/>
            <input id="hidElgStatusColl" type="hidden" name="hidElgStatusColl" runat="server"/>
            <input id="hidCollElgFlag" type="hidden" name="hidCollElgFlag" runat="server"/>
            <input id="hidInv" type="hidden" name="hidInv" runat="server"/>
            <input id="hid_StateID" type="hidden" name="hid_StateID" runat="server"/>
            <input id="hidBodyState" type="hidden" name="hidBodyState" runat="server"/>
            <input id="hidBodyID" type="hidden" name="hidBodyID" runat="server"/>
            <input id="hid_BodyID" type="hidden" name="hid_BodyID" runat="server"/>            
            <input id="hidAcademicYrText" runat="server" name="hidAcademicYrText" value="" type="hidden" />
            <input id="hid_AcademicYear" runat="server" name="hid_AcademicYear" value="" type="hidden" />
            <input id="hidCountryIDForeign" type="hidden" name="hidCountryIDForeign" runat="server">
            <input id="hidrbFilterYesNo" type="hidden" name="hidrbFilterYesNo" runat="server">
            <input id="hidtxtCountryForeignBoardUniv" type="hidden" value="0" name="hidtxtCountryForeignBoardUniv" runat="server" />
            <input id="hidBodyTypeFlag" type="hidden" name="hidBodyTypeFlag" runat="server"/>
            <input id="hidStateSelText" type="hidden" name="hidStateSelText" runat="server"/>
            <input id="hidBodySelText" type="hidden" name="hidBodySelText" runat="server"/> 
            <input id="hid_fk_AcademicYr_ID" type="hidden" name="hid_fk_AcademicYr_ID" runat="server">
            <input id="hidrbWithInv" type="hidden" name="hidrbWithInv" runat="server">
            <input id="hidrbWithoutInv" type="hidden" name="hidrbWithoutInv" runat="server">
                        <input id="hidBranchName" type="hidden" runat="server">

            <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none" meta:resourcekey="lblUniversityResource1"></asp:Label>
            <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>

       
       
    </center>
    <%--</form>--%>
    <%--</fieldset> </table>--%>
</body>
