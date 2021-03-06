<%@ Control Language="C#" AutoEventWireup="true" Codebehind="StudentAdvanceSeachForConfigureChangeElgUnprocess.ascx.cs"
    Inherits="StudentRegistration.Eligibility.WebCtrl.StudentAdvanceSeachForConfigureChangeElgUnprocess" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript" language="jscript" src="../jscript/calendar.js"> </script>

<script type="text/javascript" language="jscript" src="../jscript/calendar-en.js"> </script>

<script type="text/javascript" language="javascript" src="../jscript/InitCalendarFunc.js"> </script>

<script language="javascript" type="text/javascript" src="../jscript/DatePickerJs.js"></script>

<script language="javascript" type="text/javascript" src="../JS/ValidatePRN.js"></script>

<script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>

<link href="../CSS/calendar-blue.css" type="text/css" rel="stylesheet" />

<script language="javascript" type="text/javascript" src="JS/ValidatePRN.js"></script>

<script language="javascript" type="text/javascript" src="JS/Validations.js"></script>
  
<script language="javascript" type="text/javascript">
		var uniid;
		var elgChoice;
		var collNameHead=new Array();
		uniid = <%=Classes.clsGetSettings.UniversityID%>;
		
	    var hid_Inst_id = '<%=hidInstID.ClientID %>';
	    var hid_Fac_id = '<%=hidFacID.ClientID%>';
	    var hid_Cr_id = '<%=hidCrID.ClientID%>';
	    var hid_MoLrn_id = '<%=hidCrMoLrnID.ClientID%>';
	    var hid_Ptrn_id = '<%=hidPtrnID.ClientID%>';
	    var hid_Brn_id = '<%=hidBrnID.ClientID%>';
	    var hid_CrPr_Details_ID = '<%=hidCrPrDetailsID.ClientID%>';
	    var ddl_Faculty = '<%=ddlFaculty.ClientID%>';
	    var ddl_Course= '<%=ddlCourse.ClientID%>';
	    var ddl_MoLrn = '<%=ddlMoLrn.ClientID%>';
	    var ddl_CrPtrn = '<%=ddlCrPtrn.ClientID%>';
	    var ddl_Branch = '<%=ddlBranch.ClientID%>';
		var txt_DOB = '<%=txtDOB.ClientID%>';
		
		//------------------------------------------------------------------------------
		//function to clear textbox tooltip on page load
	        window.onload=clearToolTipOnLoad;
	        function clearToolTipOnLoad()
	        {
	            if(document.getElementById("<%= DivAdvanceSearch.ClientID%>").style.display!='none')
	            {
	                if(document.getElementById("<%= txtDOB.ClientID%>").value != '')
	                    document.getElementById("<%= txtDOB.ClientID%>").focus();
	                    
	                document.getElementById("<%= MaskedEditValidator1.ClientID%>").innerText = '';
	            }
    	    
	        }
		 //------------------------------------------------------------------------------
		
		function fnSubmit(event)
		{
			if(event.keyCode == 13 || event.keyCode == 9)             //13 - enter key , 9- tab key
			{
				document.getElementById('ctl00_ContentPlaceHolder1_btnSimpleSearch').focus();	
				document.getElementById('ctl00_ContentPlaceHolder1_btnSimpleSearch').click();	
				
			}
			
		}		
			
		//Validating eligibility form number.
		
		function ChkValidation()
		{
	        
		  var obPRN = document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigureChangeElgUnprocess1_txtPRN').value;
		  var obElg = document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigureChangeElgUnprocess1_txtElgFormNo').value;
          var obAppFormNo = document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigureChangeElgUnprocess1_txtApplicationFrmNo').value;
		  var sStr = obElg.split('-');	
		  var ret=true;
		  var myArr=new Array();
		  var j=-1;
		  var innerRet=false;
		  document.getElementById("<%= hidSSVal.ClientID%>").value="1";

		  
		  if((obPRN.length == 0)&&(obElg.length==0)&&(obAppFormNo.length==0))
		  {
		    document.getElementById("<%= hidSSVal.ClientID%>").value="";
            if(document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigureChangeElgUnprocess1_trPRN').style.display=="none" )//&& document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigureChangeElgUnprocess1_txtApplicationFrmNo').style.display=="none" )
            {
                myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter a valid Eligibility Form Number OR Application Form No.","text");
            }
            else
		    {
		        myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Eligibility Form Number OR Application Form No.","text");
            }
	      }
          else if ((obPRN.length > 0) && (obElg.length > 0)&&(obAppFormNo.length>0))
		  {
		  	  document.getElementById("<%= hidSSVal.ClientID%>").value="";
	          myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter either a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Eligibility Form Number OR Application Form No.","text");
		      		  
		  }
		  else if ((obPRN.length > 0) && (obElg.length > 0)&&(obAppFormNo.length==0)|| (obPRN.length == 0) && (obElg.length > 0)&&(obAppFormNo.length >0)||(obPRN.length > 0) && (obElg.length == 0)&&(obAppFormNo.length>0))
		  {
		  	  document.getElementById("<%= hidSSVal.ClientID%>").value="";
              if(obAppFormNo.length==0)
	          myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter either a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Eligibility Form Number.","text");
		      if(obPRN.length==0)
	          myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter either a valid Eligibility Form Number OR Application Form No.","text");
              if(obElg.length==0)
	          myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter either a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Application Form No.","text");		  
		  }
		  

		  else if(obPRN.length>0 && obElg.length==0  && obAppFormNo.length==0  )
	     {
			innerRet = checkdigitPRN_Nomenclature(obPRN, document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText,document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value);
			//************************************************
			// Added to check whether PRN belongs to the selected Institute
			if(innerRet == true)
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
		  else if(obElg.length>0 && obPRN.length==0   && obAppFormNo.length==0 )
		 {  
		    innerRet = ChkEligFormNumber(obElg);
		    if(innerRet == true)
	        {
	            if(sStr[1] == document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigureChangeElgUnprocess1_hidInstID').value)
	            {
	            innerRet = true;
	            }
	            else
	            {
	                document.getElementById("<%= hidSSVal.ClientID%>").value="";
                    myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty",".: The Student is not in selected "+document.getElementById('ctl00_ContentPlaceHolder1_lblCollege').innerText+":. \n \n Please Enter correct Eligiblity Form No.","text");
	            }
	        }
          }
         else if(obAppFormNo.length > 0 && obPRN.length==0 && obElg.length==0 )
         {             
			   innerRet = CheckInstforStudentAppFormNo();
              	      
                         
               if(innerRet == false)
			   {
                    document.getElementById("<%= hidSSVal.ClientID%>").value="";
                    myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Entered Application Form No." + " does not belong to selected " +document.getElementById('ctl00_ContentPlaceHolder1_lblCollege').innerText + ".","text"); 
                    innerRet = true;
              
               }
                  // document.getElementById("<%= hidSSVal.ClientID%>").value="";
                myArr[++j] = new Array(document.getElementById("<%= txtApplicationFrmNo.ClientID%>"), "NumericOnly/Empty", "Enter Valid Application Form Number", "text");   
                innerRet = true;
            
                      
          }

		   ret=validateMe(myArr,50);
		   if(innerRet!=false)
		        return ret;
		   else
		        return innerRet;
		}
         function CheckInstforStudentPRN() {
            var ResultStatus = clsStudent.CheckInstforStudentPRN(document.getElementById('<%=hidUniID.ClientID%>').value, document.getElementById('<%=txtPRN.ClientID%>').value, document.getElementById('<%=hidInstID.ClientID%>').value);
            if (ResultStatus.value == "1")   // Student belongs to selected institute
                return true;
            else                            // Student does not belong to selected institute
                return false;

        }

        function CheckInstforStudentAppFormNo() {
           
            var ResultStatus = clsStudent.CheckInstforStudentAppFormNo(document.getElementById('<%=hidUniID.ClientID%>').value, document.getElementById('<%=txtApplicationFrmNo.ClientID%>').value, document.getElementById('<%=hidInstID.ClientID%>').value);
            if (ResultStatus.value == "1")   // Student belongs to selected institute
                return true;
            else                            // Student does not belong to selected institute
                return false;

        }
		
		
			//Remove Options from DDL
			
			function RemoveAllOptions(ListBox)
			{
				var LB=document.getElementById(''+ListBox+'');
				if (LB == null)
					return;
				//ListBox.selectedIndex = -1;
				var iListBoxLength = LB.options.length;
				for (var i = 0; i <iListBoxLength; i++)
					LB.options.remove(1);
				document.getElementById('<%=hidTehsilID.ClientID%>').value = "0";
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
//				 var cr1=document.getElementById(ddl_CoursePart);
//				 cr1.selectedIndex=0;
//				 cr1.length=1;
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
			    document.getElementById('<%=hidCrMoLrnID.ClientID%>').value = '0';
    			
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
                              document.getElementById('<%=hidBrnID.ClientID%>').value = ds.Tables[0].Rows[0].Value;
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
		  	
		  	
		  	//To fill CoursepartDetails dropdown on change of Branch dropdown
		  	
		  	
//		  		function FillCoursePart(val)
//			    {
//			       
//			        document.getElementById('<%=hidCrPrDetailsID.ClientID%>').value = '0';
//    			    
//			        //AjaxMethods.selCoursePart(parseInt(uniid),parseInt(document.getElementById(hid_Inst_id).value),parseInt(document.getElementById(hid_Fac_id).value),parseInt(document.getElementById(hid_Cr_id).value),parseInt(document.getElementById(hid_MoLrn_id).value),parseInt(document.getElementById(hid_Ptrn_id).value),parseInt(val),selCoursePart_Callback);
//			        AjaxMethods.selCoursePart(parseInt(uniid),parseInt(document.getElementById(hid_Inst_id).value),parseInt(document.getElementById(hid_Fac_id).value),parseInt(document.getElementById(hid_Cr_id).value),parseInt(document.getElementById(hid_MoLrn_id).value),parseInt(document.getElementById(hid_Ptrn_id).value),parseInt(val),selCoursePart_Callback);
//        		}
//		    
//		    function selCoursePart_Callback(response)
//		    {
//		        
//		        var ds = response.value[0];
//		        var d  = document.getElementById(ddl_CoursePart);
//		        d.length = 1;
//		        
//		        if(ds.Tables[0].Rows.length >0)
//		        {
//		            for(var i=0; i<ds.Tables[0].Rows.length ;i++)
//					{
//					    d.add(new Option(ds.Tables[0].Rows[i].CrPr_Abbr,ds.Tables[0].Rows[i].pk_CrPr_Details_ID));
//					    
//					}	
//				}
//				else
//				{
//				 d.selectedIndex=0;
//				}
//		  	}
		  	
		 	
		  	//Function to clear all the following DropDowns on change of a Dropdown
		  	
		  	function ClearDropDowns(FromLevel, LevelFlag)
            {	

	        switch (FromLevel)
	        { 
		        case 1:
				        if(LevelFlag >= 2)
				        {
					        ClearDropDownList(document.getElementById(ddl_Course));
					        document.getElementById('<%= hidCrMoLrnID.ClientID%>').value = '0';
				            document.getElementById('<%= hidPtrnID.ClientID%>').value = '0';
				            document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				            document.getElementById('<%= hidBranchName.ClientID%>').value="";	
				           // document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';
								        
				        }
		        case 2:
				        if(LevelFlag >= 3)
				        {
					        ClearDropDownList(document.getElementById(ddl_MoLrn));					        
				            document.getElementById('<%= hidPtrnID.ClientID%>').value = '0';
				            document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				            document.getElementById('<%= hidBranchName.ClientID%>').value="";	
				       //     document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';
				  
				        }
		        case 3:
				        if(LevelFlag >= 4)
				        {
					       
					        ClearDropDownList(document.getElementById(ddl_CrPtrn));					        
				            document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				            document.getElementById('<%= hidBranchName.ClientID%>').value="";	
				            document.getElementById('<%= hidBranchName.ClientID%>').value="";	
				         //   document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';
		
				        }
	            case 4:
				        if(LevelFlag >= 5)
				        {					       
					        ClearDropDownList(document.getElementById(ddl_Branch));		
					        document.getElementById('<%= hidBranchName.ClientID%>').value="";				       
				       //     document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';
	
				        }
        				
//	            case 5:
//				        if(LevelFlag >= 6)
//				        {
//					        ClearDropDownList(document.getElementById(ddl_CoursePart));
//					       
//				        }
					       
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
				document.getElementById(txt_DOB).value = '';
				document.getElementById('<%= txtLastName.ClientID %>').value = '';
				document.getElementById('<%= txtFirstName.ClientID %>').value = '';		
				document.getElementById('<%= ddlFaculty.ClientID%>').value = "0";
				document.getElementById('<%= ddlCourse.ClientID%>').value = "0";
				document.getElementById('<%= ddlMoLrn.ClientID%>').value = "0";
				document.getElementById('<%= ddlCrPtrn.ClientID%>').value = "0";
				document.getElementById('<%= ddlBranch.ClientID%>').value = "0";
				document.getElementById('<%= ddlGender.ClientID%>').value = "0";			
				document.getElementById('<%= hidStateID.ClientID%>').value = '0';
				document.getElementById('<%= ddlBranch.ClientID%>').options[0].text = "---Select---";
				document.getElementById('<%= hidBranchName.ClientID%>').value="";				
				document.getElementById('<%= hidDistrictID.ClientID%>').value = '0';
				document.getElementById('<%= hidTehsilID.ClientID%>').value = '0';
				document.getElementById('<%= hidFacID.ClientID%>').value = '0';
				document.getElementById('<%= hidCrID.ClientID%>').value = '0';
				document.getElementById('<%= hidCrMoLrnID.ClientID%>').value = '0';
				document.getElementById('<%= hidPtrnID.ClientID%>').value = '0';
				document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';
			    document.getElementById('<%= tblDGElgRegular.ClientID %>').style.display = 'none';
				document.getElementById('<%= tblDGRegPendingStudents.ClientID %>').style.display = 'none';
				document.getElementById('<%= lblGridName.ClientID %>').style.display = 'none';
				document.getElementById('<%= divDGNote.ClientID %>').style.display = 'none';
				document.getElementById('<%= lblGrid.ClientID %>').style.display = 'none';
				document.getElementById('<%= tdSubmit.ClientID %>').style.display = 'none';
				document.getElementById('<%= tblResolveQuestion.ClientID %>').style.display = 'none';
				document.getElementById('<%= tblMarkElg.ClientID %>').style.display = 'none';
				document.getElementById('<%= ddlAcademicYear.ClientID%>').value = "0";	
				if(collNameHead.length>0)
				{			
				if(collNameHead[0]!="undefined")
				    document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText=collNameHead[0];
				}
				else
				{
				    document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText=document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText.split('-')[0];
				}

                document.getElementById("<%= MaskedEditValidator1.ClientID%>").innerText = '';
                clearToolTip();
                
				return false;			
								
			}
			
		function fnDisplayDiv()
	        {  
	            document.getElementById('<%=txtPRN.ClientID%>').innerText="";
	            document.getElementById('<%=txtElgFormNo.ClientID%>').innerText="";	
                document.getElementById('<%=txtApplicationFrmNo.ClientID%>').innerText="";
	             //toggle eligibility area and grid
	             document.getElementById('<%=tblResolveQuestion.ClientID%>').style.display = 'none';
	             document.getElementById('<%=tblMarkElg.ClientID%>').style.display = 'none';
	             document.getElementById('<%=NotElgReason.ClientID%>').style.display = 'none';
	             if(document.getElementById('<%=dgRegPendingStudents1.ClientID%>')!=null)
	             {
	                document.getElementById('<%=dgRegPendingStudents1.ClientID%>').style.display = 'none';
	             }
	             document.getElementById('<%=tdSubmit.ClientID%>').style.display = 'none';
	             document.getElementById('<%=lblGrid.ClientID%>').style.display = 'none';
	             document.getElementById('<%=lblGridName.ClientID%>').style.display = 'block';
	             document.getElementById('<%= divDGNote.ClientID %>').style.display = 'none';
	             if(document.getElementById('<%= lblErrorMsg.ClientID %>')!=null)
	                document.getElementById('<%= lblErrorMsg.ClientID %>').style.display = 'none';
	             document.getElementById('<%=lblSubmitMessage.ClientID%>').style.display = 'none';
	             document.getElementById('<%=hidSubmitFlag.ClientID%>').value = "0";
	             fnClearSearchCriteria();
	             
        	
		        if(document.getElementById('<%=divSimpleSearch.ClientID%>').style.display == 'none')
		        {		        
		            collNameHead=document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText.split('-');
        		    document.getElementById('<%=divSimpleSearch.ClientID%>').style.display = 'block';
			        document.getElementById('<%=tblAcademicYr.ClientID%>').style.display = 'none';	
			        document.getElementById('<%=DivAdvanceSearch.ClientID%>').style.display = 'none';			       
			        document.getElementById('<%=hidSearchType.ClientID%>').value="Simple";	
			        document.getElementById('<%=divAcademicYr.ClientID%>').style.display='none';
			        document.getElementById('<%= ddlAcademicYear.ClientID%>').value = "0";	
			        document.getElementById('<%= hid_fk_AcademicYr_ID.ClientID%>').value = '0';	
			        document.getElementById('<%= hidFacID.ClientID%>').value = '0';
				    document.getElementById('<%= hidCrID.ClientID%>').value = '0';
				    document.getElementById('<%= hidCrMoLrnID.ClientID%>').value = '0';
				    document.getElementById('<%= hidPtrnID.ClientID%>').value = '0';
				    document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				    document.getElementById('<%=lblAdvSearch.ClientID%>').innerText="Advanced Search"; 
				    document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';
				    if(collNameHead[0]!="undefined")
				        document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText=collNameHead[0];
			
		        }
		        else if(document.getElementById('<%=divSimpleSearch.ClientID%>').style.display == 'block')
		        {   
		        	collNameHead=document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText.split('-');
			        document.getElementById('<%=divSimpleSearch.ClientID%>').style.display = 'none';
			        document.getElementById('<%=tblAcademicYr.ClientID%>').style.display = 'block';
			        document.getElementById('<%=tblAcademicYr.ClientID%>').style.fontWeight = 'bold';
			        document.getElementById('<%=DivAdvanceSearch.ClientID%>').style.display = 'block';
			        document.getElementById('<%=ddlAcademicYear.ClientID%>').value = "0";
			        document.getElementById('<%=hidSearchType.ClientID%>').value="Adv";
			        document.getElementById('<%=divAcademicYr.ClientID%>').style.display='block';
			        document.getElementById('<%=hid_fk_AcademicYr_ID.ClientID%>').value = '0';
			        document.getElementById('<%=lblAdvSearch.ClientID%>').innerText="Simple Search"; 
			        if(collNameHead[0]!="undefined")
			            document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText=collNameHead[0]; 
			        document.getElementById("<%= MaskedEditValidator1.ClientID%>").innerText = '';
			        clearToolTip();

		        }
	        }
	        
	    
	    //function to reset textbox tooltip
	    function clearToolTip()
	    {
	        if(document.getElementById("<%= DivAdvanceSearch.ClientID%>").style.display!='none')
	        {
	            document.getElementById("<%= txtDOB.ClientID%>").focus();
	            document.getElementById("<%= txtDOB.ClientID%>").blur();
	        }
	    
	    }
	    
	    
		function UnderLineOnMouseOver(obj)
		{				      
		       document.getElementById("<%=lblAdvSearch.ClientID %>").style.textDecoration = "underline"; 
		   
		}
		function UnderLineOnMouseOut(obj)
		{		        
		        document.getElementById("<%=lblAdvSearch.ClientID %>").style.textDecoration = "none"; 		      
		}
		
		function showEligibilityChoice(choice)
		{	
		    if(choice.value=="rbElgDecsionYes")
		    {
		        document.getElementById("<%=rbElgDecsionNo.ClientID %>").checked=false;
		        document.getElementById("<%=tblMarkElg.ClientID %>").style.display="block";
		        document.getElementById("<%=btnSubmit.ClientID %>").disabled=false;
		            //show checkboxes on Yes			        	        
                    var GV= document.getElementById("<%=dgRegPendingStudents1.ClientID%>").rows;               
                    for(var j=0;j<GV.length;j++)
                    {    
                        if(GV[j].cells[16]!=null)  
                        {   
                                       
                            var arr=document.getElementById('<%=dgRegPendingStudents1.ClientID%>').getElementsByTagName("input");
                       
                            for(i=0;i<arr.length;i++)
                            {
                                arr[i].checked=false;
                            }
                                                           
                         }
                     }                   
		        }
		    else if(choice.value=="rbElgDecsionNo")
		    {		    		 
		         document.getElementById("<%=rbElgDecsionYes.ClientID %>").checked=false;
		         document.getElementById("<%=tblMarkElg.ClientID %>").style.display="none";	
		         document.getElementById("<%=NotElgReason.ClientID %>").style.display="none";	
		         document.getElementById('<%=btnSubmit.ClientID%>').disabled=true;	
		         document.getElementById("<%= txtNotElgReason.ClientID%>").value="";
		         //hide checkboxes on No			        	        
                 var GV= document.getElementById("<%=dgRegPendingStudents1.ClientID%>").rows;
                 for(var j=0;j<GV.length;j++)
                 {
                    if(GV[j].cells[16]!=null) 
                    {  
                        var cell=GV[j].cells[16];
                        cell.style.display='none';
                    }
                 }		        
		    }			
		}
			
	    function showMarkChoice(choice)
		{
		   
		    elgChoice=choice.value;
            if(choice.value=="rbMarkPElg")
		    {
		        document.getElementById("<%=rbMarkPElg.ClientID %>").checked=true;
		        document.getElementById("<%=NotElgReason.ClientID %>").style.display="block";
		        document.getElementById("<%=hidEligibility.ClientID %>").value="Pending Eligible";
		    }	
	
		}
		
		function multiselect()
        {       
            var arr=new Array();
            arr=document.getElementById('<%=dgRegPendingStudents1.ClientID%>').getElementsByTagName("input");
            if(arr[0].checked)
            {
                for(i=0;i<arr.length;i++)
                {
                    arr[i].checked=true;
                }
            }
            else
            {
                for(i=0;i<arr.length;i++)
                {
                    arr[i].checked=false;
                }
            }
        } 
        
        function submitValidate()
        {           
            document.getElementById("<%= hidSubmitFlag.ClientID%>").value="1";
            document.getElementById('<%=hidCheckboxChosen.ClientID%>').value="";
            var i=-1;
            var flag=false;
            var myArr   = new Array();  
            if(elgChoice=="rbMarkPElg")
                myArr[++i]  = new Array(document.getElementById("<%= txtNotElgReason.ClientID%>"),"Empty","Please Enter Reason for marking selected student(s) as \"Pending Eligible\".","text");
            arr=document.getElementById('<%=dgRegPendingStudents1.ClientID%>').getElementsByTagName("input");
            for(var j=0;j<arr.length;j++)
            {                
                if(arr[j].checked) 
                {                
                    document.getElementById('<%=hidCheckboxChosen.ClientID%>').value="1";
                    break;
                }            
            }           
            myArr[++i]  = new Array(document.getElementById("<%= hidCheckboxChosen.ClientID%>"),"Empty","Please select at least one student!","text");

            //*********************************
            myArr[++i]  = new Array(document.getElementById("<%= hidEligibility.ClientID%>"),"Empty","Please select Eligibility status to be marked for selected student(s).","text");
            //*********************************

            var ret=validateMe(myArr,50);    
            flag=ret;
                        
            if(ret)
            {
                if(confirm("Are you sure you want to make the Selected Student(s) available for Eligibility Processing by marking them as \""+document.getElementById("<%=hidEligibility.ClientID %>").value+"\"?"))
                {                    
                    return true;
                }
                else
                {
                    document.getElementById("<%= hidSubmitFlag.ClientID%>").value="0";
                    return false; 
                }
            }
            return false;                
        }			
			
	function validateYear()
	{   
	    var flag=false;
	    var i=-1;
	    var myArr = new Array();  		    
	    myArr[++i]  = new Array(document.getElementById("<%= ddlAcademicYear.ClientID%>"),"0","Please Select Academic Year.","select");
	    var ret=validateMe(myArr,50); 
	    flag=ret;
	    if(!flag)
	    {
	          document.getElementById("<%= tblAcademicYr.ClientID%>").style.display="block";
              document.getElementById("<%= DivAdvanceSearch.ClientID%>").style.display="none";        
	    }
	    else if(flag)
	    {
	          document.getElementById("<%= tblAcademicYr.ClientID%>").style.display="none";
              document.getElementById("<%= DivAdvanceSearch.ClientID%>").style.display="block";
	    }
	    document.getElementById("<%= divSimpleSearch.ClientID%>").style.display="none";
	    if(document.getElementById("<%=ddlAcademicYear.ClientID%>").value != "0")
	    {
	        document.getElementById("ctl00_ContentPlaceHolder1_lblAcademicYear").style.display = "block";
	    }
	    return false;
	}
	
	function advSearchValidate()
	{
    
	    var i=-1;
	    var ret=true;
	    var myArr = new Array(); 
	    myArr[++i]  = new Array(document.getElementById("<%= ddlAcademicYear.ClientID%>"),"0","Please Select Academic Year.","select");
 	    myArr[++i]  = new Array(document.getElementById('<%= ddlFaculty.ClientID%>'),"0","Please "+document.getElementById('<%=lblFaculty.ClientID%>').innerText+".","select");
		myArr[++i]  = new Array(document.getElementById('<%= ddlCourse.ClientID%>'),"0","Please "+document.getElementById('<%=lblCourse.ClientID%>').innerText+".","select");
		myArr[++i]  = new Array(document.getElementById('<%= ddlMoLrn.ClientID%>'),"0","Please Select Mode of Learning.","select");
		myArr[++i]  = new Array(document.getElementById('<%= ddlCrPtrn.ClientID%>'),"0","Please Select Pattern.","select");
		var ddlBranch=document.getElementById('<%= ddlBranch.ClientID%>');
		if(ddlBranch.options[ddlBranch.selectedIndex].text!="No Branch")
		    myArr[++i]  = new Array(document.getElementById('<%= ddlBranch.ClientID%>'),"0","Please Select Branch.","select");
	    var ret=validateMe(myArr,50); 
	    if(document.getElementById("<%= MaskedEditValidator1.ClientID%>").innerText=='Date is invalid')
		  ret=false;
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
    function openNewWindow(RefUniID, RefInstID, RefYearID, RefStudID, UniId, InstID, Year, StudID, FacID, CrID, MoLrnID, PtrnID, BrnID, CrPrDetailsID)
		    {
		      
		        var ElgFormNo = RefUniID+'-'+RefInstID+'-'+RefYearID+'-'+RefStudID;
		        
		        window.open("ELGV2_BulkProcess__2.aspx?ElgFormNo="+ElgFormNo+"&UniID="+UniId+"&InstID="+InstID+"&Year="+Year+"&StudID="+StudID+"&FacID="+FacID+"&CrID="+CrID+"&MoLrnID="+MoLrnID+"&PtrnID="+PtrnID+"&BrnID="+BrnID+"&CrPrDetailsID="+CrPrDetailsID+"","_blank","height=300,width=700,status=yes,toolbar=no,menubar=no,location=no,scrollbars =yes,left=250,top=300,screenX=0,screenY=400'");
		        
		        return false;
		    }
</script>

<%--<asp:UpdatePanel ID="updContent" runat="server">
    <ContentTemplate>--%>
<br />
<div align="right">
    <asp:Label ID="lblSubmitMessage" Style="text-align: right; display: none;" runat="server"
        Width="100%" CssClass="saveNote" meta:resourcekey="lblSubmitMessageResource2"></asp:Label>
</div>
<br />
<center>
    <table id="Table4" cellspacing="0" width="100%" border="0">
        <tr>
            <td align="center" colspan="3">
                <fieldset>
                    <legend><strong><span style="text-decoration: underline">Search Criteria</span></strong></legend>
                    <table cellspacing="0" cellpadding="0" border="0" align="center" width="100%">
                        <tr align="right">
                            <td align="right" style="height: 19px">
                            
                                <label id="lblAdvSearch" runat="server" class="NavLink" style="cursor: hand; color: blue"
                                    onclick="fnDisplayDiv();" onmouseover="UnderLineOnMouseOver('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigureChangeElgUnprocess1_lblAdvSearch');"
                                    onmouseout="UnderLineOnMouseOut('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigureChangeElgUnprocess1_lblAdvSearch');">
                                </label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div id="divSimpleSearch" runat="server">
                        <table cellspacing="0" cellpadding="3" width="100%" border="0" align="left">
                            <tr align="left" id = "trElgFormNo" runat="server">
                                <td align="right" width="50%">
                                    &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="tbElgFormNo" runat="server" Text="Enter Eligibility Form Number"
                                        meta:resourcekey="tbElgFormNoResource2"></asp:Label>
                                        :</b>&nbsp;</td>
                                <td height="30" align="left">
                                    <asp:TextBox ID="txtElgFormNo" runat="server" Font-Bold="True" Font-Size="Small"
                                        onclick="this.value='';" meta:resourcekey="txtElgFormNoResource2"></asp:TextBox></td>
                            </tr>
                            <tr align="center" id="trOr" runat="server">
                                <td align="Center" colspan="2" runat="server">
                                    <b>OR</b>
                                </td>
                            </tr>
                            <tr align="left" id="trPRN" runat="server">
                                <td align="right" width="50%" runat="server">
                                    <strong>
                                        <asp:Label ID="lblEnterPRN" runat="server" Text="Enter PRN: " meta:resourcekey="lblEnterPRNResource1"></asp:Label></strong></td>
                                <td height="30" align="left" runat="server">
                                    <asp:TextBox ID="txtPRN" runat="server" MaxLength="20" Font-Bold="True" Font-Size="Small"
                                        onclick="this.value='';"></asp:TextBox></td>
                            </tr>
                             <tr align="center" id="trOr1" runat="server">
                                <td  align="center" colspan="2" runat="server">
                                    <b>OR</b>
                                </td>
                            </tr>
                           <tr id="trApplicationFormNo" align="left" runat="server">
                             <td id="Td1"  align="right" width="50%" runat="server">
                                 <strong>
                                    <asp:Label ID="lblApplicationFrmNo" runat="server" 
                                    Text="Enter Application Form Number: "></asp:Label></strong>
                             </td>
                    
                             <td id="Td2" height="30" align="left" runat="server">
                                 <asp:TextBox ID="txtApplicationFrmNo" runat="server" MaxLength="10" Font-Bold="True" Font-Size="Small" Width="210px" onclick="this.value='';"/>
                             </td>
                         </tr>

                            <tr>
                                <td align="center" colspan="2">
                                    <br />
                                    <asp:Button ID="btnSimpleSearch" Text="Search" runat="server"
                                        OnClick="btnSimpleSearch_Click" meta:resourcekey="btnSimpleSearchResource1" CssClass="butSubmit"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="DivAdvanceSearch" style="display: none;" runat="server">
                        <table id="tblAcademicYr" runat="server" cellspacing="0" cellpadding="0" width="100%"
                            border="0">
                            <tr runat="server">
                                <td style="width: 850px;" align="center" colspan="3" runat="server" id="divAcademicYr">
                                    <!-- Selection Starts -->
                                    <table cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td align="right" style="height: 19px; width: 36%;">
                                                <asp:Label ID="lblAcyr" runat="server" Font-Bold="True" meta:resourcekey="lblAcyrResource1"
                                                    Text="Select Academic Year"></asp:Label>&nbsp;<b>:</b></td>
                                            <td id="tdAcdYr" runat="server" align="left">
                                                &nbsp;<asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="selectbox"
                                                    Width="260px" meta:resourcekey="ddlAcademicYrResource1">
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                                </asp:DropDownList><font class="Mandatory">*</font></td>
                                        </tr>
                                        <tr><td colspan="2" style="height:5px"></td></tr>
                                        
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlSelCourse" runat="server" meta:resourcekey="pnlSelCourseResource2">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td align="right" style="height: 19px; width: 45%;">
                                                <b>
                                                    <asp:Label ID="lblFaculty" runat="server" Text="Select Faculty" meta:resourcekey="lblFacultyResource1"></asp:Label>
                                                    :&nbsp;</b></td>
                                            <td colspan="3" style="height: 19px" align="left">
                                                <asp:DropDownList ID="ddlFaculty" runat="server" Width="260px" CssClass="selectbox"
                                                    onchange="setValue(hid_Fac_id,this.value);FillCourse(this.value);ClearDropDowns(1,5)"
                                                    meta:resourcekey="ddlFacultyResource1">
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                                </asp:DropDownList><font class="Mandatory">*</font></td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="21%" style="height: 5px" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 35%">
                                                <b>
                                                    <asp:Label ID="lblCourse" runat="server" Text="Select Course" meta:resourcekey="lblCourseResource1"></asp:Label>&nbsp;:&nbsp;</b></td>
                                            <td colspan="3" align="left">
                                                <asp:DropDownList ID="ddlCourse" runat="server" Width="260px" CssClass="selectbox"
                                                    onchange="setValue(hid_Cr_id,this.value);FillModeofLearning(this.value);ClearDropDowns(2,5);"
                                                    meta:resourcekey="ddlCourseResource1">
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource2" Text="--- Select ---"></asp:ListItem>
                                                </asp:DropDownList><font class="Mandatory">*</font></td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="21%" style="height: 5px" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 35%">
                                                <b>Select Mode of Learning :&nbsp;</b></td>
                                            <td colspan="3" align="left">
                                                <asp:DropDownList ID="ddlMoLrn" runat="server" Width="260px" CssClass="selectbox"
                                                    onchange="setValue(hid_MoLrn_id,this.value);FillCoursePattern(this.value);ClearDropDowns(3,5);"
                                                    meta:resourcekey="ddlMoLrnResource1">
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource3" Text="--- Select ---"></asp:ListItem>
                                                </asp:DropDownList><font class="Mandatory">*</font></td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="21%" style="height: 5px" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 35%">
                                                <b>Select Pattern :&nbsp;</b></td>
                                            <td colspan="3" align="left">
                                                <asp:DropDownList ID="ddlCrPtrn" runat="server" Width="260px" CssClass="selectbox"
                                                    onchange="setValue(hid_Ptrn_id,this.value);FillBranchList(this.value);ClearDropDowns(4,5); "
                                                    meta:resourcekey="ddlCrPtrnResource1">
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource4" Text="--- Select ---"></asp:ListItem>
                                                </asp:DropDownList><font class="Mandatory">*</font></td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="21%" style="height: 5px" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 35%">
                                                <b>Select Branch :&nbsp;</b></td>
                                            <td id="tdBranch" colspan="3" align="left">
                                                <asp:DropDownList ID="ddlBranch" runat="server" Width="260px" CssClass="selectbox"
                                                    onchange="setValue(hid_Brn_id, this.value);" meta:resourcekey="ddlBranchResource1">
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource5" Text="--- Select ---"></asp:ListItem>
                                                </asp:DropDownList><font class="Mandatory">*</font></td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="21%" style="height: 5px" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 20%;">
                                                <b>Date of Birth :&nbsp;</b></td>
                                            <td width="45%" align="left">
                                                <asp:TextBox ID="txtDOB" runat="server" CssClass="inputbox" Width="70px" MaxLength="10"
                                                    meta:resourcekey="txtDOBResource1" ValidationGroup="dateValidator1" CausesValidation="True"></asp:TextBox>&nbsp;
                                                <b>[dd/mm/yyyy]</b>
                                            
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOB"
                                                    Format="dd/MM/yyyy" Enabled="True" PopupPosition="BottomRight">
                                                </cc1:CalendarExtender>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDOB"
                                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureName="en-GB"
                                                    CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="&#163;" CultureDateFormat="DMY"
                                                    CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder=","
                                                    CultureTimePlaceholder=":" Enabled="True" >
                                                </cc1:MaskedEditExtender>
                                                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtDOB" IsValidEmpty="True"
                                                    InvalidValueMessage="Date is invalid" ValidationGroup="dateValidator1" TooltipMessage="Input a Date"
                                                    MaximumValue="31/12/9999" MinimumValue="01/01/1753" MaximumValueMessage="Date is invalid" 
                                                    MinimumValueMessage="Date is invalid" />
                                            </td>
                                            <td align="right" width="15%">
                                                <b>Gender :&nbsp;</b></td>
                                            <td width="20%" align="left">
                                                <asp:DropDownList ID="ddlGender" CssClass="selectbox" runat="server" meta:resourcekey="ddlGenderResource1">
                                                    <asp:ListItem Value="0" Selected="True" meta:resourcekey="ListItemResource7" Text="--- Select ---"></asp:ListItem>
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource8" Text="Male"></asp:ListItem>
                                                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource9" Text="Female"></asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="20%" style="height: 5px" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 21%">
                                                <b>Last Name :&nbsp;</b></td>
                                            <td width="39%" align="left">
                                                <asp:TextBox ID="txtLastName" runat="server" CssClass="inputbox" meta:resourcekey="txtLastNameResource1"></asp:TextBox></td>
                                            <td align="right" width="20%">
                                                <b>First Name :&nbsp;</b></td>
                                            <td width="20%" align="left">
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputbox" meta:resourcekey="txtFirstNameResource1"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                              
                            </ContentTemplate>
                          
                        </asp:UpdatePanel>
                        <table id="tblSubmit" runat="server" cellspacing="0" cellpadding="3" width="100%">
                            <tr class="rFont" runat="server">
                                <td align="right" style="height: 25px" runat="server">
                                    <asp:Button ID="btnSearch" runat="server" CssClass="butSubmit" Width="158px" Height="18px"
                                        Text="Search" OnClick="btnSearch_Click"
                                        OnClientClick="return advSearchValidate();" ValidationGroup="dateValidator1"></asp:Button></td>
                                <td align="left" style="height: 25px" runat="server">
                                    &nbsp;<asp:Button ID="btnClear" runat="server"  CssClass="butSubmit" Text="Clear Search Criteria"
                                         Height="18px" Width="186px" OnClientClick="return fnClearSearchCriteria();">
                                    </asp:Button>
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
                <!-- Eligibility decision area -->
                <table width="100%" style="display: none" id="tblResolveQuestion" runat="server">
                    <tr runat="server">
                        <td style="text-align: right; width: 60%" runat="server">
                            <b>&nbsp;&nbsp; Do you want to mark the student(s) to be made available for eligibility processing in bulk?
                                : </b>
                        </td>
                        <td style="text-align: left" runat="server">
                            <asp:RadioButton ID="rbElgDecsionYes" runat="server" Text="Yes" onclick="showEligibilityChoice(this)" />
                            <asp:RadioButton ID="rbElgDecsionNo" runat="server" Text="No" Checked="True" onclick="showEligibilityChoice(this)" />
                        </td>
                    </tr>
                </table>
                <table width="100%" style="display: none" id="tblMarkElg" runat="server">
                    <tr runat="server">
                        <td style="text-align: right; width: 60%" runat="server">
                            <b>Resolve Not Eligible Student(s) in Bulk and mark them as: </b>
                        </td>
                        <td style="text-align: left" runat="server">
                            <asp:RadioButton ID="rbMarkPElg" runat="server" Text="Pending Eligible" onclick="showMarkChoice(this)"  />
                        </td>
                    </tr>
                </table>
                <div id="NotElgReason" runat="server" style="display: none">
                    <table width="100%">
                        <tr>
                            <td style="text-align: right; width: 60%">
                                <b>Reason(s) for marking selected students as Pending Eligible: </b>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtNotElgReason" runat="server" TextMode="MultiLine" Width="90%"
                                    meta:resourcekey="txtNotElgReasonResource2"></asp:TextBox><font class="Mandatory">*</font>
                            </td>
                        </tr>
                    </table>
                </div>
                <p style="margin-top: 10px; margin-bottom: 1px; margin-left: 0px" align="left">
                    <asp:Label ID="lblGridName" Style="display: none" runat="server" Width="99%" CssClass="errorNote"
                        Height="18px" meta:resourcekey="lblGridNameResource1"></asp:Label></p>
                <p style="margin-top: 0px; margin-bottom: 0px; margin-left: 0px" align="center">
                    &nbsp;</p>
                <div id="divDGNote" style="display: none; height: 12px" align="left" runat="server">
                    <font color="red">* Please click on the student name to view his/her respective profile</font></div>
            </td>
        </tr>
        <tr style="display: none">
            <td style="width: 953px; height: 317px;" align="center" colspan="3">
                <table id="tblDGElgRegular" style="display: none" width="100%" runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <asp:GridView ID="dgElgRegular1" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                AllowPaging="True" BorderColor="#336699" AutoGenerateColumns="False" AllowSorting="True"
                                OnPageIndexChanging="dgElgRegular1_PageIndexChanging" OnRowCommand="dgElgRegular1_RowCommand"
                                OnRowDataBound="dgElgRegular1_RowDataBound" OnSorting="dgElgRegular1_Sorting"
                                meta:resourcekey="dgElgRegular1Resource1">
                                <RowStyle CssClass="gridItem"></RowStyle>
                                <HeaderStyle CssClass="gridHeader" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <%# (Container.DataItemIndex)+1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AdmissionFormNo" ReadOnly="True" HeaderText="Admission Form No"
                                        SortExpression="AdmissionFormNo" >
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Eligibility_Form_No" ReadOnly="True" HeaderText="Eligibility Form No"
                                        SortExpression="Eligibility_Form_No" meta:resourcekey="BoundFieldResource1">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:ButtonField Text="Button" DataTextField="StudentName" HeaderText="Student Name"
                                        CommandName="StudentDetails" SortExpression="StudentName" meta:resourcekey="ButtonFieldResource1">
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:ButtonField>
                                    <asp:BoundField DataField="InstituteName" ReadOnly="True" HeaderText="College Name"
                                        SortExpression="InstituteName" meta:resourcekey="BoundFieldResource2">
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourseName" ReadOnly="True" HeaderText="Course Admitted To"
                                        meta:resourcekey="BoundFieldResource3">
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DocCount" HeaderText="No of Documents Submitted" meta:resourcekey="BoundFieldResource4">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pk_CrMoLrnPtrn_ID"  HeaderText="pkCrMoLrnPtrnID" meta:resourcekey="BoundFieldResource5">
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                </PagerStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 30; width: 953px" align="center" colspan="3">
                <table id="tblDGRegPendingStudents" style="display: none" width="100%" runat="server">
                    <tr runat="server">
                        <td align="left" runat="server">
                            <asp:Label runat="server" ID="lblGrid" CssClass="divDGNote" ForeColor="Red" meta:resourcekey="lblGridResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server">
                            <br />
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server">
                            <asp:GridView ID="dgRegPendingStudents1" runat="server" Width="100%" BorderWidth="1px"
                                BorderStyle="Solid" AllowSorting="True" AllowPaging="True" BorderColor="#336699"
                                CssClass="clGrid grid-view" AutoGenerateColumns="False" OnPageIndexChanging="dgRegPendingStudents1_PageIndexChanging"
                                OnRowCommand="dgRegPendingStudents1_RowCommand" OnRowDataBound="dgRegPendingStudents1_RowdataBound"
                                meta:resourcekey="dgRegPendingStudents1Resource1" OnSorting="dgRegPendingStudents1_Sorting"
                                PageSize="50" >
                                <HeaderStyle CssClass="gridHeader" />
                                <RowStyle CssClass="gridItem" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <%# (Container.DataItemIndex)+1 %>
                                            .
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="AdmissionFormNo" ReadOnly="True" HeaderText="Admission Form No"
                                        SortExpression="AdmissionFormNo" >
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Eligibility_Form_No" ReadOnly="True" HeaderText="Eligibility Form No"
                                        SortExpression="Eligibility_Form_No" meta:resourcekey="BoundFieldResource6">
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:ButtonField Text="Button" DataTextField="StudentName" HeaderText="Student Name"
                                        CommandName="PendingStudentDetails" SortExpression="StudentName" meta:resourcekey="ButtonFieldResource2">
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:ButtonField>
                                    <asp:BoundField DataField="PRN" ReadOnly="True" HeaderText="PRN" SortExpression="PRN">
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InstituteName" ReadOnly="True" HeaderText="College Name"
                                        meta:resourcekey="BoundFieldResource7">
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourseName" ReadOnly="True" HeaderText="Course Admitted To"
                                        meta:resourcekey="BoundFieldResource8">
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DocCount" HeaderText="No of Documents Submitted" meta:resourcekey="BoundFieldResource9">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkYear" ReadOnly="True" HeaderText="pkYear" meta:resourcekey="BoundFieldResource10">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkStudentID" ReadOnly="True" HeaderText="pkStudentID"
                                        meta:resourcekey="BoundFieldResource11"></asp:BoundField>
                                    <asp:BoundField DataField="pkFacID" ReadOnly="True" HeaderText="pkFacID" meta:resourcekey="BoundFieldResource12">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkCrID" HeaderText="pkCrID" meta:resourcekey="BoundFieldResource13">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkMoLrnID" HeaderText="pkMoLrnID" meta:resourcekey="BoundFieldResource14">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkPtrnID" HeaderText="pkPtrnID" meta:resourcekey="BoundFieldResource15">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkBrnID" HeaderText="pkBrnID" meta:resourcekey="BoundFieldResource16">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkCrPrDetails" HeaderText="pkCrPrDetailsID" meta:resourcekey="BoundFieldResource17">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkCrPrCh"  HeaderText="pkCrPrCh" meta:resourcekey="BoundFieldResource18" >
                                    
                                     
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Select">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="test" runat="server" Text="Select All"></asp:Label><br />
                                            <br />
                                            <asp:CheckBox ID="cbMSelect" runat="server" onclick="multiselect()" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkStudent" runat="server" Value='<%# Eval("pkStudentID") %>' />
                                            <asp:HiddenField ID="hid_chkStudent" runat="server" Value='<%# Eval("pkStudentID") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridHeader"
                                            Font-Bold="True" Width="10%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="gridHeader" />
                                <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                </PagerStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td id="tdSubmit" runat="server" style="display: none">
                <asp:Button ID="btnSubmit" Text="Submit" Enabled="False" runat="server" CssClass="butSubmit"
                    OnClick="btnSubmit_Click" OnClientClick="return submitValidate()" meta:resourcekey="btnSubmitResource2" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
    </table>
</center>
<div id="divErrorMsg" runat="server" style="display: none; text-align: left" align="left">
    <asp:Label ID="lblErrorMsg" runat="server" Width="100%" Style="text-align: left;
        display: none" CssClass="errorNote" meta:resourcekey="lblErrorMsgResource1"></asp:Label>
</div>
<div style="display: none; text-align: left" id="divError" runat="server">
    <asp:Label ID="lblError" Style="text-align: left" runat="server" CssClass="errorNote"></asp:Label>
</div>
<br />
<input id="hidUniID" style="width: 40px; height: 22px" type="hidden" name="hidUniID"
    runat="server" />
<input id="hidInstID" style="width: 24px; height: 22px" type="hidden" name="hidInstID"
    runat="server" />
<input id="hidStateID" style="width: 24px; height: 22px" type="hidden" name="hidStateID"
    runat="server" />
<input id="hidDistrictID" style="width: 24px; height: 22px" type="hidden" name="hidDistrictID"
    runat="server" />
<input id="hidTehsilID" style="width: 24px; height: 22px" type="hidden" name="hidTehsilID"
    runat="server" />
<input id="hidFacID" style="width: 40px; height: 22px" type="hidden" name="hidFacID"
    runat="server" />
<input id="hidCrID" style="width: 40px; height: 22px" type="hidden" name="hidCrID"
    runat="server" />
<input id="hidCrMoLrnID" style="width: 40px; height: 22px" type="hidden" name="hidCrMoLrnID"
    runat="server" />
<input id="hidPtrnID" style="width: 40px; height: 22px" type="hidden" name="hidPtrnID"
    runat="server" />
<input id="hidBrnID" style="width: 40px; height: 22px" type="hidden" name="hidBrnID"
    runat="server" />
<input id="hidCrPrDetailsID" style="width: 40px; height: 22px" type="hidden" name="hidCrPrDetailsID"
    runat="server" />
<input id="hidElgFormNo" type="hidden" value="0" name="hidElgFormNo" runat="server" />
<input id="hidpkStudentID" type="hidden" name="hidpkStudentID" runat="server" />
<input id="hidStep" type="hidden" name="hidStep" runat="server" />
<input id="hidpkYear" type="hidden" value="0" name="hidpkYear" runat="server" />
<input id="hidDOB" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
    runat="server" />
<input id="hidLastName" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
    runat="server" />
<input id="hidFirstName" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
    runat="server" />
<input id="hidGender" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
    runat="server" />
<input id="hid_fk_AcademicYr_ID" runat="server" name="hid_fk_AcademicYr_ID" value=""
    type="hidden" />
<input id="hidIsBlank" type="hidden" name="hidIsBlank" runat="server"/>
<input id="hidAcademicYrText" runat="server" name="hidAcademicYrText" value="" type="hidden" />
<input id="hidPRN" type="hidden" name="hidPRN" runat="server" />
<input type="hidden" id="hidSearchType" runat="server" />
<input id="hidEligibility" type="hidden" runat="server" />
<input id="hidCheckboxChosen" type="hidden" runat="server" />
<input id="hidSubmitFlag" type="hidden" runat="server" value="0" />
<input id="hidAppFormNo" type="hidden" value="0" name="hidAppFormNo" runat="server" />
<asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
    meta:resourcekey="lblUniversityResource1"></asp:Label>
<asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
<asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>

<asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none"
    meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>

<input id="hidFresh" runat="server" value="" type="hidden" />
<input type="hidden" id="hidSSVal" runat="server" value="1" />
<input id="hidFacName" runat="server" type="hidden" />
<input id="hidCrName" runat="server" type="hidden" />
<input id="hidMOLName" runat="server" type="hidden" />
<input id="hidPattern" runat="server" type="hidden" />
<input id="hidBrName" runat="server" type="hidden" />
<input id="hidCrPrName" runat="server" type="hidden" />
<input id="hidAcYrName" runat="server" type="hidden" />
<input id="hidBranchName" type="hidden" runat="server"/>
<input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
<%-- </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="dgRegPendingStudents1" />
    </Triggers>
</asp:UpdatePanel>
--%>
