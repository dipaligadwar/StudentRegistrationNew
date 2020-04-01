<%@ Control Language="C#" AutoEventWireup="true" Codebehind="StudentAdvancedSearchforManualProcess_reg_Students.ascx.cs"
    Inherits="StudentRegistration.Eligibility.WebCtrl.StudentAdvancedSearchforManualProcess_reg_Students" %>
<link href="../CSS/calendar-blue.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" language="jscript" src="../jscript/calendar.js"> </script>

<script type="text/javascript" language="jscript" src="../jscript/calendar-en.js"> </script>

<script type="text/javascript" language="javascript" src="../jscript/InitCalendarFunc.js"> </script>

<script language="javascript" type="text/javascript" src="../jscript/DatePickerJs.js"></script>

<script language="javascript" type="text/javascript" src="../JS/ValidatePRN.js"></script>

<script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript" language="javascript">
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
		    var txt_DOB = '<%=txtDOB.ClientID%>';

            var PRNValidation = '<%=hidIsPRNValidationRequired.ClientID%>';
		    
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
		 
		  function callvaliadteAcademic()
		    {      
		        var i=-1;
				var myArr= new Array();				
				myArr[++i]= new Array(document.getElementById('<%=ddlAcademicYear.ClientID%>'),"0","Select Academic Year .","select"); 					
				var ret=validateMe(myArr,50);
		        return ret;
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
			    //alert(val);
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
				                document.getElementById('<%= hidBranchName.ClientID%>').value="";	
    					        
				            }
		            case 2:
				            if(LevelFlag >= 3)
				            {
					            ClearDropDownList(document.getElementById(ddl_MoLrn));					        
				                document.getElementById('<%= hidPtrnID.ClientID%>').value = '0';
				                document.getElementById('<%= hidBrnID.ClientID%>').value = '0';	
				                document.getElementById('<%= hidBranchName.ClientID%>').value="";	
    					        
				            }
		            case 3:
				            if(LevelFlag >= 4)
				            {
    					       
					            ClearDropDownList(document.getElementById(ddl_CrPtrn));					        
				                document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				                document.getElementById('<%= hidBranchName.ClientID%>').value="";						       
    					       
				            }
	                case 4:
				            if(LevelFlag >= 5)
				            {					       
					            ClearDropDownList(document.getElementById(ddl_Branch));
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
				
				document.getElementById(txt_DOB).value = '';
				document.getElementById('<%= txtLastName.ClientID %>').value = '';
				document.getElementById('<%= txtFirstName.ClientID %>').value = '';		
				document.getElementById('<%= ddlFaculty.ClientID%>').value = "0";
				document.getElementById('<%= ddlCourse.ClientID%>').value = "0";
				document.getElementById('<%= ddlMoLrn.ClientID%>').value = "0";
				document.getElementById('<%= ddlCrPtrn.ClientID%>').value = "0";
				document.getElementById('<%= ddlBranch.ClientID%>').value = "0";
			    document.getElementById('<%= ddlBranch.ClientID%>').options[0].text = "---Select---";
				document.getElementById('<%= hidBranchName.ClientID%>').value="";				
				document.getElementById('<%= ddlGender.ClientID%>').value = "-1";			
				document.getElementById('<%= hidStateID.ClientID%>').value = '0';
				document.getElementById('<%= hidDistrictID.ClientID%>').value = '0';
				document.getElementById('<%= hidTehsilID.ClientID%>').value = '0';
				document.getElementById('<%= hidFacID.ClientID%>').value = '0';
				document.getElementById('<%= hidCrID.ClientID%>').value = '0';
				document.getElementById('<%= hidMoLrnID.ClientID%>').value = '0';
				document.getElementById('<%= hidPtrnID.ClientID%>').value = '0';
				document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				//document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';
				
				document.getElementById('<%= ddlGender.ClientID%>').value = "0";
				document.getElementById('<%= ddlAcademicYear.ClientID%>').value = "0";	
				
				document.getElementById('<%= tblDGRegPendingStudents.ClientID %>').style.display = 'none';
				document.getElementById('<%= lblGridName.ClientID %>').style.display = 'none';
				document.getElementById('<%= divDGNote.ClientID %>').style.display = 'none';
				
				document.getElementById("<%= MaskedEditValidator1.ClientID%>").innerText = '';
				clearToolTip();

				return false;
								
			}
		
		
        //*****************************************************************************
		// Code Added by Pankaj on 21/10/2010
		function fnDisplayDiv()
        {  
              
              if(document.getElementById('<%=divSimpleSearch.ClientID%>').style.display == 'none')
		        {	
		            // To display Simple search Div
		            
        		    document.getElementById('<%=divSimpleSearch.ClientID%>').style.display = 'block';
			        document.getElementById('<%=DivAdvanceSearch.ClientID%>').style.display = 'none';			       
				    document.getElementById('<%=lbl_AdvSearch.ClientID%>').innerText="Advanced Search"; 
				    document.getElementById('<%=hidSearchType.ClientID%>').value="Simple";
				    
				    
				    document.getElementById(txt_DOB).value = '';
				    document.getElementById('<%= txtLastName.ClientID %>').value = '';
				    document.getElementById('<%= txtFirstName.ClientID %>').value = '';		
				    document.getElementById('<%= ddlFaculty.ClientID%>').value = "0";
				    document.getElementById('<%= ddlCourse.ClientID%>').value = "0";
				    document.getElementById('<%= ddlMoLrn.ClientID%>').value = "0";
				    document.getElementById('<%= ddlCrPtrn.ClientID%>').value = "0";
				    document.getElementById('<%= ddlBranch.ClientID%>').value = "0";
			        document.getElementById('<%= ddlBranch.ClientID%>').options[0].text = "---Select---";
				    document.getElementById('<%= hidBranchName.ClientID%>').value="";				
				    document.getElementById('<%= ddlGender.ClientID%>').value = "-1";			
				    document.getElementById('<%= hidStateID.ClientID%>').value = '0';
				    document.getElementById('<%= hidDistrictID.ClientID%>').value = '0';
				    document.getElementById('<%= hidTehsilID.ClientID%>').value = '0';
				    document.getElementById('<%= hidFacID.ClientID%>').value = '0';
				    document.getElementById('<%= hidCrID.ClientID%>').value = '0';
				    document.getElementById('<%= hidMoLrnID.ClientID%>').value = '0';
				    document.getElementById('<%= hidPtrnID.ClientID%>').value = '0';
				    document.getElementById('<%= hidBrnID.ClientID%>').value = '0';
				    //document.getElementById('<%= hidCrPrDetailsID.ClientID%>').value = '0';
    				
				    document.getElementById('<%= ddlGender.ClientID%>').value = "0";
				    document.getElementById('<%= ddlAcademicYear.ClientID%>').value = "0";	
    				
				    document.getElementById('<%= tblDGRegPendingStudents.ClientID %>').style.display = 'none';
				    document.getElementById('<%= lblGridName.ClientID %>').style.display = 'none';
				    document.getElementById('<%= divDGNote.ClientID %>').style.display = 'none';
   		            document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText= "for " + document.getElementById('<%= hidInstName.ClientID %>').value;
   				    document.getElementById('<%= hidIsBack.ClientID %>').value = 'False';

		        }
		        else //if(document.getElementById('<%=divSimpleSearch.ClientID%>').style.display == 'block')
		        {   
		            // To display Advanced search Div
		            
		        	document.getElementById('<%=divSimpleSearch.ClientID%>').style.display = 'none';
			        document.getElementById('<%=DivAdvanceSearch.ClientID%>').style.display = 'block';			       
				    document.getElementById('<%=lbl_AdvSearch.ClientID%>').innerText="Simple Search"; 
				    document.getElementById('<%=hidSearchType.ClientID%>').value="Adv";
			        document.getElementById('<%=txtApplicationFrmNo.ClientID%>').innerText="";
   			        document.getElementById('<%= txtElgFormNo.ClientID %>').value = "";
			        document.getElementById('<%= txtPRN.ClientID %>').value = "";
   				    document.getElementById('<%= lblGridName.ClientID %>').style.display = 'none';
   				    document.getElementById('<%= tblDGRegPendingStudents.ClientID %>').style.display = 'none';
   				    document.getElementById('<%= lblGridName.ClientID %>').style.display = 'none';
				    document.getElementById('<%= divDGNote.ClientID %>').style.display = 'none';
		            document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText= "for " + document.getElementById('<%= hidInstName.ClientID %>').value;
   				    document.getElementById('<%= hidIsBack.ClientID %>').value = 'False';
                    
                    document.getElementById("<%= MaskedEditValidator1.ClientID%>").innerText = '';
                    clearToolTip();

		        }
        }
        //*****************************************************************************
        
        function responseHandler()
        {   
            return;
        }
        
        //Validating eligibility form number.
		function ChkValidation()
		{
		var obPRN = document.getElementById('<%=txtPRN.ClientID %>').value;
		  var obElg = document.getElementById('<%=txtElgFormNo.ClientID %>').value;
          var obAppFormNo = $("#<%=txtApplicationFrmNo.ClientID %>").val();
		  var sStr = obElg.split('-');	
		  var ret=true;
		  var myArr=new Array();
		  var j=-1;
		  
		  if((obPRN.length == 0)&&(obElg.length==0) && (obAppFormNo.length==0))
		  {
		      alert("Enter a valid " + document.getElementById('<%=lblPRNNomenclature.ClientID %>').innerText+" or Eligibility Form Number OR Admission Form Number.")
		      ret=false;
		  }
		   else if ((obPRN.length > 0) && (obElg.length > 0)||(obElg.length > 0) && (obAppFormNo.length > 0)||(obAppFormNo.length > 0) && (obPRN.length > 0))
		  {
		      alert("Please Enter either a Valid " + document.getElementById('<%=lblPRNNomenclature.ClientID %>').innerText+" OR Eligibility Form Number OR Admission Form Number.")
		      ret=false;		  
		  }
		  
		  else
		  {
		 
		     if(obPRN.length>0)
		     {
//                alert('here' + document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value);
//                alert(obPRN);
//                alert(document.getElementById('<%=lblPRNNomenclature.ClientID %>').innerText);

				//ret = checkdigitPRN(obPRN);
				ret = checkdigitPRN_Nomenclature(obPRN, document.getElementById('<%=lblPRNNomenclature.ClientID %>').innerText,document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value);
				document.getElementById('<%=hidPRNorElgFormNo.ClientID %>').value = "PRN";
				
				//************************************************
			    // Added to check whether PRN belongs to the selected Institute
			    if(ret == true)
			    {
			       ret = CheckInstforStudentPRN();
    			   
			       if(ret == false)
			       {
			          document.getElementById("<%= hidSSVal.ClientID%>").value="";
			          myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Entered " + document.getElementById('<%=lblPRNNomenclature.ClientID %>').innerText + " does not belong to selected " +document.getElementById("<%= lblCollege.ClientID%>").innerText + ".","text");  
			          ret=validateMe(myArr,50);
			       }
			    }
			    //************************************************
			 }
			 else
			 if(obElg.length>0)
			 {  
			    ret = ChkEligFormNumber(obElg);
			    document.getElementById('<%=hidPRNorElgFormNo.ClientID %>').value = "ElgFormNo";
			    if(ret == true)
		        {
		            if(sStr[1] == document.getElementById("<%=hidInstID.ClientID %>").value)
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
             else if(obAppFormNo.length > 0)
             {             
			       ret = CheckInstforStudentAppFormNo();
              	      
                         
                   if(ret == false)
			       {
                        document.getElementById("<%= hidSSVal.ClientID%>").value="";
                        myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Entered Application Form No." + " does not belong to selected " +document.getElementById('<%= lblCollege.ClientID%>').innerText+ ".","text"); 
                        ret=validateMe(myArr,50);
              
                   }
                      // document.getElementById("<%= hidSSVal.ClientID%>").value="";
                    myArr[++j] = new Array(document.getElementById("<%= txtApplicationFrmNo.ClientID%>"), "NumericOnly/Empty", "Enter Valid Application Form Number", "text");   
                    innerRet = true;
            
                      
              }
			 else
		     {
		          alert("Please enter the Eligibility Form Number.");
		          ret = false;
		     }
		  }
//		   if(ret==false)
//		        return ret;
//		   else
//		   {
//		        ret=validateMe(myArr,50);
//		        return ret;
//		   }
            return ret;
		}
		
        
		function UnderLineOnMouseOver(obj)
		{				      
		       document.getElementById("<%=lbl_AdvSearch.ClientID %>").style.textDecoration = "underline"; 
		   
		}
		function UnderLineOnMouseOut(obj)
		{		        
		        document.getElementById("<%=lbl_AdvSearch.ClientID %>").style.textDecoration = "none"; 		      
		}
		
		
		//added by Pankaj on 21-10-10
		function chkBlankAcademicYear()
		{
		    
		    var ret=true;
		    if(document.getElementById("<%=ddlAcademicYear.ClientID %>").value == "0")
		    {
		        //alert('Please select Academic Year.');
		        
		        var i = -1;
		        var myArr = new Array();  		    
	            myArr[++i]  = new Array(document.getElementById("<%= ddlAcademicYear.ClientID%>"),"0","Please Select Academic Year.","select");
	            ret=validateMe(myArr,50);	        
		    }
		    if(document.getElementById("<%= MaskedEditValidator1.ClientID%>").innerText=='Date is invalid')
		            ret=false;
		        return ret;    
		    
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
				
			function CheckInstforStudentAppFormNo() {
           
            var ResultStatus = clsStudent.CheckInstforStudentAppFormNo(document.getElementById('<%=hidUniID.ClientID%>').value, document.getElementById('<%=txtApplicationFrmNo.ClientID%>').value, document.getElementById('<%=hidInstID.ClientID%>').value);
            if (ResultStatus.value == "1")   // Student belongs to selected institute
                return true;
            else                            // Student does not belong to selected institute
                return false;

        }			
</script>

<center>
    <table id="Table4" cellspacing="0" width="100%" border="0">
        <tr>
            <td style="width: 100%" align="center" colspan="3">
                <%--<div id="divAcademicYr" runat="server">
                    <fieldset id="tblAcademicYr" style="width: 603px;" align="center" runat="server">
                        <legend><b>Select Academic Year </b></legend>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td style="height: 24px;" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px; width: 125px;">
                                    <asp:Label ID="lblAcyr" runat="server" Font-Bold="True" Width="221px" meta:resourcekey="lblAcyrResource1"
                                        Text="Select Academic Year"></asp:Label></td>
                                <td align="center" style="height: 20px; width: 2%;">
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
                </div>--%>
                <!-- Selection Starts -->
                <fieldset id="tblSelect" runat="server">
                    <legend><strong><span style="text-decoration: underline">Search Student(s)</span></strong></legend>
                    <table cellspacing="0" cellpadding="0" align="center" width="100%">
                        <tr align="right">
                            <td align="right" style="height: 19px">
                                <%--<label id="lblSimpleSearch" runat="server" class="NavLink" style="cursor: hand" onclick="fnDisplayDiv('Simple');"
                                            onmouseover="UnderLineOnMouseOver('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_lblSimpleSearch');"
                                            onmouseout="UnderLineOnMouseOut('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_lblSimpleSearch');">
                                            Simple Search
                                        </label>--%>
                                <label id="lbl_AdvSearch" runat="server" class="NavLink" style="cursor: hand; color: blue"
                                    onclick="fnDisplayDiv();" onmouseover="UnderLineOnMouseOver('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_lbl_AdvSearch');"
                                    onmouseout="UnderLineOnMouseOut('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_lbl_AdvSearch');">
                                    Advanced Search
                                </label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div id="divSimpleSearch" runat="server">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" align="left">
                            <tr align="left">
                                <td align="right" width="40%" runat="server">
                                    <b>
                                        <asp:Label ID="tbElgFormNo" runat="server" Text="Enter Eligibility Form Number" meta:resourcekey="tbElgFormNoResource2"></asp:Label>
                                    </b>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td height="30" align="left" width="59%">
                                    <asp:TextBox ID="txtElgFormNo" runat="server" Font-Bold="True" Font-Size="Small"
                                        onclick="this.value='';" meta:resourcekey="txtElgFormNoResource2"  CssClass="redbox"></asp:TextBox></td>
                            </tr>
                            <tr align="center" id="trOr" runat="server">
                                <td colspan="1" align="center">
                                    &nbsp;
                                </td>
                                <td width="1%">
                                    <b>&nbsp;</b>
                                </td>
                                <td id="Td1" align="left" runat="server">
                                    <b>&nbsp;OR</b>
                                </td>
                            </tr>
                            <tr align="left" id="trPRN" runat="server">
                                <td id="Td2" align="right" width="40%" runat="server">
                                    <strong>
                                        <asp:Label ID="lblEnterPRN" runat="server" Text="Enter PRN " meta:resourcekey="lblEnterPRNResource1"></asp:Label></strong>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td id="Td3" height="30" align="left" runat="server" width="59%">
                                    <asp:TextBox ID="txtPRN" runat="server" MaxLength="20" Font-Bold="True" Font-Size="Small"
                                        onclick="this.value='';" meta:resourcekey="txtPRNResource1"  CssClass="redbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="center" id="tr1" runat="server">
                                <td colspan="1" align="center">
                                    &nbsp;
                                </td>
                                <td width="1%">
                                    <b>&nbsp;</b>
                                </td>
                                <td id="Td4" align="left" runat="server">
                                    <b>&nbsp;OR</b>
                                </td>
                            </tr>
                            <tr align="left" id="tr2" runat="server">
                                <td id="Td5" align="right" width="40%" runat="server">
                                    <strong>
                                        <asp:Label ID="lblApplicationFrmNo" runat="server" Text="Enter Application Form Number " ></asp:Label></strong>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td id="Td6" height="30" align="left" runat="server" width="59%">
                                   <asp:TextBox ID="txtApplicationFrmNo" runat="server" MaxLength="20" Font-Bold="True"
                                        Font-Size="Small" Width="210px" onclick="this.value='';"  CssClass="redbox"/>
                                </td>
                            </tr>
                           
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <br>
                                    <asp:Button ID="btnSimpleSearch" CssClass="butSubmit" Text="Search" runat="server"
                                        OnClick="btnSimpleSearch_Click" OnClientClick="return ChkValidation();" meta:resourcekey="btnSimpleSearchResource1">
                                    </asp:Button>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="DivAdvanceSearch" style="display: inline; width: 100%" runat="server">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="lblAcyr" runat="server" Font-Bold="True" meta:resourcekey="lblAcyrResource1"
                                        Text="Select Academic Year"></asp:Label>
                                </td>
                                <td align="center" style="height: 20px; width: 2%;">
                                    <b>&nbsp;:&nbsp;</b></td>
                                <td align="left" id="tdAcdYr" runat="server">
                                    <asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="selectbox" Width="151px"
                                        meta:resourcekey="ddlAcademicYrResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                    </asp:DropDownList><font class="Mandatory">*</font></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 30%;" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <b>
                                        <asp:Label ID="lblFaculty" runat="server" Text="Select Faculty" meta:resourcekey="lblFacultyResource1"></asp:Label>
                                    </b>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:DropDownList ID="ddlFaculty" runat="server" Width="260px" CssClass="selectbox"
                                        onchange="setValue(hid_Fac_id,this.value);FillCourse(this.value);ClearDropDowns(1,5)"
                                        meta:resourcekey="ddlFacultyResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 300px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <b>
                                        <asp:Label ID="lblCourse" runat="server" Text="Select Course" meta:resourcekey="lblCourseResource1"></asp:Label>
                                    </b>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:DropDownList ID="ddlCourse" runat="server" Width="260px" CssClass="selectbox"
                                        onchange="setValue(hid_Cr_id,this.value);FillModeofLearning(this.value);ClearDropDowns(2,5);"
                                        meta:resourcekey="ddlCourseResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource2" Text="--- Select ---"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 30%;" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <b>Select Mode of Learning </b>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:DropDownList ID="ddlMoLrn" runat="server" Width="260px" CssClass="selectbox"
                                        onchange="setValue(hid_MoLrn_id,this.value);FillCoursePattern(this.value);ClearDropDowns(3,5);"
                                        meta:resourcekey="ddlMoLrnResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource3" Text="--- Select ---"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 30%;" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <b>
                                        <asp:Label ID="lblCrPattern" runat="server" Text="Select Course Pattern" meta:resourcekey="lblCrPatternResource1"></asp:Label>
                                    </b>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:DropDownList ID="ddlCrPtrn" runat="server" Width="260px" CssClass="selectbox"
                                        onchange="setValue(hid_Ptrn_id,this.value);FillBranchList(this.value);ClearDropDowns(4,5); "
                                        meta:resourcekey="ddlCrPtrnResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource4" Text="--- Select ---"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 30%;" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <b>Select Branch </b>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td id="tdBranch" colspan="3" align="left">
                                    <asp:DropDownList ID="ddlBranch" runat="server" Width="260px" CssClass="selectbox"
                                        onchange="setValue(hid_Brn_id, this.value);" meta:resourcekey="ddlBranchResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource5" Text="--- Select ---"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 300px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <b>Date of Birth </b>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" CausesValidation="true" CssClass="inputbox"
                                        Width="70px" meta:resourcekey="txtDOBResource1"></asp:TextBox><b>[dd/mm/yyyy]</b>&nbsp;
                                    <%--<a id="alinkCalender" onclick="return showCalendar(document.getElementById(txt_DOB).id, '%d/%m/%Y');"  runat="server">
                                    <img onmouseover="this.style.cursor='Hand'" src="../images/cal.gif" align="middle" /></a>&nbsp;
                                --%>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOB"
                                        Format="dd/MM/yyyy" Enabled="True" PopupPosition="BottomRight">
                                    </cc1:CalendarExtender>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDOB"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureName="en-GB"
                                        CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="&#163;" CultureDateFormat="DMY"
                                        CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder=","
                                        CultureTimePlaceholder=":" Enabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                        SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtDOB" IsValidEmpty="True"
                                        InvalidValueMessage="Date is invalid" TooltipMessage="Input a Date" MaximumValue="31/12/9999" MinimumValue="01/01/1753" MaximumValueMessage="Date is invalid" MinimumValueMessage="Date is invalid"/>
                                </td>
                                <td align="right">
                                    <b>Gender&nbsp;</b>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    &nbsp;<asp:DropDownList ID="ddlGender" CssClass="selectbox" runat="server" meta:resourcekey="ddlGenderResource1">
                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource7" Text="--- Select ---"></asp:ListItem>
                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource8" Text="Male"></asp:ListItem>
                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource9" Text="Female"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <b>Last Name </b>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td width="15%" align="left">
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="inputbox" meta:resourcekey="txtLastNameResource1"></asp:TextBox></td>
                                <td align="right" width="20%">
                                    <b>First Name&nbsp;</b>
                                </td>
                                <td width="1%" align="center">
                                    <b>:</b>
                                </td>
                                <td width="15%" align="left">
                                    &nbsp;<asp:TextBox ID="txtFirstName" runat="server" CssClass="inputbox" meta:resourcekey="txtFirstNameResource1"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="height: 5px; width: 30%;" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <strong>Display List of Students with Eligibility&nbsp;</strong>
                                </td>
                                <td width="1%" align="center" valign="top">
                                    <b>:</b>
                                </td>
                                <td colspan="4" align="left" valign="top">
                                    <asp:RadioButton ID="rbUni" runat="server" GroupName="EligibleStud" Text="To be decided by University"
                                        Checked="True" meta:resourcekey="rbUniResource1" />
                                    &nbsp;
                                    <asp:RadioButton ID="rbColl" runat="server" GroupName="EligibleStud" Text="Already decided by College"
                                        meta:resourcekey="rbCollResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td height="10px" colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                           
                            <tr id="trbtnSearch" runat="server">
                                <td align="center" colspan="6" style="height: 44px">
                                    <br />
                                    &nbsp;<asp:Button ID="btnSearch" runat="server" Width="70px" CssClass="butSubmit"
                                        Text="Search" OnClientClick="return chkBlankAcademicYear();" ValidationGroup="dateValidator1"
                                        OnClick="btnSearch_Click" meta:resourcekey="btnSearchResource1"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button CssClass="butSubmit" ID="btnClear" Text="Clear Search Criteria" runat="server"
                                        Width="150px" meta:resourcekey="btnClearResource1" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
                <br />
            </td>
        </tr>
        <tr>
            <td style="height: 5px; width: 300px;">
            </td>
        </tr>
        <%--<p style="MARGIN-TOP: 10px; MARGIN-BOTTOM: 1px; MARGIN-LEFT: 0px" align="center">--%>
        <tr>
            <td align="left">
                <asp:Label ID="lblGridName" Style="display: none" runat="server" Width="99%" CssClass="errorNote"
                    Height="30px" meta:resourcekey="lblGridNameResource1"></asp:Label>
                <%--</p>--%>
            </td>
        </tr>
        <%--<p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; MARGIN-LEFT: 0px" align="center">&nbsp;</p>--%>
        <tr>
            <td>
                <div id="divDGNote" style="display: inline" align="left" runat="server">
                    <font color="red">* Please click on the student name to view his/her respective profile.</font>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" height="30">
                <table id="tblDGRegPendingStudents" style="display: inline" width="100%" runat="server">
                    <%--  <tr>
                            <td>
                                <asp:Label runat="server" ID="lblGrid" CssClass="divDGNote" meta:resourcekey="lblGridResource1"></asp:Label>
                            </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <asp:GridView ID="dgRegPendingStudents1" runat="server" Width="100%" BorderWidth="1px"
                                CssClass="clGrid grid-view" BorderStyle="Solid" AllowPaging="True" BorderColor="#336699"
                                AutoGenerateColumns="False" AllowSorting="True" meta:resourcekey="dgRegPendingStudents1Resource1"
                                OnPageIndexChanging="dgRegPendingStudents1_PageIndexChanging" OnRowCommand="dgRegPendingStudents1_RowCommand"
                                OnRowDataBound="dgRegPendingStudents1_RowDataBound" OnSorting="dgRegPendingStudents1_Sorting">
                                <RowStyle CssClass="gridItem"></RowStyle>
                                <HeaderStyle CssClass="gridHeader" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <%# (Container.DataItemIndex)+1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                        <HeaderStyle CssClass="gridHeader" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AdmissionFormNo" ReadOnly="True" HeaderText="Admission Form No"
                                        SortExpression="AdmissionFormNo" >
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
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
                                    <asp:BoundField HeaderText="PRN Number" DataField="PRN" SortExpression="PRN" meta:resourcekey="BoundFieldResource2">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InstituteName" ReadOnly="True" HeaderText="College Name"
                                        meta:resourcekey="BoundFieldResource3">
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourseName" ReadOnly="True" HeaderText="Course Admitted To"
                                        meta:resourcekey="BoundFieldResource4">
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
                                </Columns>
                                <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                </PagerStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
       
    </table>
    <div>
    </div>
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
    <input id="hidFacID" style="width: 40px; height: 22px" type="hidden" value="0" name="hidFacID"
        runat="server" />
    <input id="hidCrID" style="width: 40px; height: 22px" type="hidden" value="0" name="hidCrID"
        runat="server" />
    <input id="hidMoLrnID" style="width: 40px; height: 22px" type="hidden" value="0"
        name="hidMoLrnID" runat="server" />
    <input id="hidPtrnID" style="width: 40px; height: 22px" type="hidden" value="0" name="hidPtrnID"
        runat="server" />
    <input id="hidBrnID" style="width: 40px; height: 22px" type="hidden" value="0" name="hidBrnID"
        runat="server" />
    <input id="hidCrPrDetailsID" style="width: 40px; height: 22px" type="hidden" value="0"
        name="hidCrPrDetailsID" runat="server" />
    <input id="hidElgFormNo" type="hidden" value="0" name="hidElgFormNo" runat="server" />
    <input id="hidPRN" type="hidden" value="0" name="hidPRN" runat="server" />
    <input id="hidPRNorElgFormNo" type="hidden" value="0" name="hidPRN" runat="server" />
    <input id="hidpkStudentID" type="hidden" value="0" name="hidpkStudentID" runat="server" />
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
    <input id="hidElgStatusColl" style="width: 40px; height: 22px" type="hidden" name="hidElgStatusColl"
        runat="server" />
    <input id="hidCollElgFlag" style="width: 40px; height: 22px" type="hidden" name="hidCollElgFlag"
        runat="server" />
    <input id="hidInv" style="width: 40px; height: 22px" type="hidden" name="hidInv"
        runat="server" />
    <input id="hid_StateID" type="hidden" name="hid_StateID" runat="server" />
    <input id="hidBodyState" type="hidden" name="hidBodyState" runat="server" />
    <input id="hidBodyID" type="hidden" name="hidBodyID" runat="server" />
    <input id="hid_BodyID" type="hidden" name="hid_BodyID" runat="server" />
    <input id="hidCountryId" style="width: 24px; height: 22px" type="hidden" value="0"
        name="hidcountryId" runat="server" />
    <input id="hid_fk_AcademicYr_ID" runat="server" name="hid_fk_AcademicYr_ID" value=""
        type="hidden" />
    <input id="hid_AcademicYear" runat="server" name="hid_AcademicYear" value="" type="hidden" />
    <input id="hidAcademicYrText" runat="server" name="hidAcademicYrText" value="" type="hidden" />
    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
    <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
        meta:resourcekey="lblUniversityResource1"></asp:Label>
    <input id="hidBranchName" type="hidden" runat="server">
    <!-- ***********************-->
    <input type="hidden" id="hidSearchType" runat="server" value="Simple" />
    <input id="hidIsBlank" type="hidden" name="hidIsBlank" runat="server" />
    <input id="hidpkFacID" type="hidden" name="hidpkFacID" runat="server" />
    <input id="hidpkCrID" type="hidden" name="hidpkCrID" runat="server" />
    <input id="hidpkMoLrnID" type="hidden" name="hidpkMoLrnID" runat="server" />
    <input id="hidpkPtrnID" type="hidden" name="hidpkPtrnID" runat="server" />
    <input id="hidpkBrnID" type="hidden" name="hidpkBrnID" runat="server" />
    <input id="hidpkCrPrDetailsID" type="hidden" name="hidpkCrPrDetailsID" runat="server" />
    <input id="Hidden1" type="hidden" name="hidElgStatusColl" runat="server" />
    <input id="Hidden2" type="hidden" name="hidCollElgFlag" runat="server" />
    <input id="hidCollElgFlagReason" type="hidden" name="hidCollElgFlagReason" runat="server" />
    <input id="hidElgStatusUni" type="hidden" name="hidElgStatusUni" runat="server" />
    <input id="Hidden3" type="hidden" name="hidInv" runat="server" />
    <input id="hidFacName" runat="server" type="hidden" />
    <input id="hidCrName" runat="server" type="hidden" />
    <input id="hidMOLName" runat="server" type="hidden" />
    <input id="hidPattern" runat="server" type="hidden" />
    <input id="hidBrName" runat="server" type="hidden" />
    <input id="hidCrPrName" runat="server" type="hidden" />
    <input id="hidAcYrName" runat="server" type="hidden" />
    <input id="hidInstName" runat="server" type="hidden" />
    <!-- Added by Pankaj on 28/10/2010 -->
    <input id="hidFacIDToRestore" runat="server" type="hidden" />
    <input id="hidCrIDToRestore" runat="server" type="hidden" />
    <input id="hidMoLrnIDToRestore" runat="server" type="hidden" />
    <input id="hidPtrnIDToRestore" runat="server" type="hidden" />
    <input id="hidBrnIDToRestore" runat="server" type="hidden" />
    <input id="hidWithOrWithoutInv" runat="server" type="hidden" />
    <input id="hidIsBack" runat="server" type="hidden" />
    <input id="hidAppFormNo" type="hidden" value="0" name="hidAppFormNo" runat="server" />
    <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
    <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
    
    <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none"
        meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>

    <input type="hidden" id="hidSSVal" runat="server" value="1" />
    
</center>
