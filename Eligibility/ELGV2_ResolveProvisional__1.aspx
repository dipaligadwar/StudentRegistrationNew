<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="ELGV2_ResolveProvisional__1.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_ResolveProvisional__1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" language="jscript" src="/jscript/calendar.js"> </script>
    <script type="text/javascript" language="jscript" src="/jscript/calendar-en.js"> </script>
    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>
    <script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/jscript_validations.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/jsAjaxMethod.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/CommonFunctions.js"></script>
    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>
    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>
    <script language="javascript" type="text/javascript">

        function fnSubmit(event) {
            if (event.keyCode == 13 || event.keyCode == 9)             //13 - enter key , 9- tab key
            {
                document.getElementById('ctl00_ContentPlaceHolder1_btnSimpleSearch').focus();
                document.getElementById('ctl00_ContentPlaceHolder1_btnSimpleSearch').click();

            }

        }

        //Validating eligibility form number.
        function ChkValidation() {
            var obElg = document.getElementById('ctl00_ContentPlaceHolder1_tbElgFormNo').value;
            var sStr = obElg.split('-');
            var ret = true;
            if (obElg.length > 0) {
                ret = ChkEligFormNumber(obElg);
                if (ret == true) {
                    if (sStr[1] == document.getElementById('ctl00_ContentPlaceHolder1_hidInstID').value) {
                        ret = true;
                    }
                    else {
                        alert(".:The Student is not in selected " + document.getElementById('lblCollege').innerText + ":.\n Please Enter Correct Form No.");
                        ret = false;
                    }
                }
            }
            else {
                alert("Please enter the Eligibility Form Number.");
                ret = false;
            }
            return ret;
        }

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

		 var TdBodyClientID = '<%=TdBodyID.ClientID%>';
		 var hid_StateClientID = '<%=hid_StateID.ClientID%>';
		 var hid_BodyClientID = '<%=hid_BodyID.ClientID%>';
		 var Body_StateClient = '<%=Body_State.ClientID%>';
		 var Body_IDClient = '<%=Body_ID.ClientID%>';
		 var hidInstClientID = '<%=hidInstID.ClientID %>';
		 var hidFacClientID = '<%=hidFacID.ClientID%>';
		 var hidCrClientID = '<%=hidCrID.ClientID%>';
		 var hidMoLrnClientID = '<%=hidCrMoLrnID.ClientID%>';
		 var hidPtrnClientID = '<%=hidPtrnID.ClientID%>';
		 var hidBrnClientID = '<%=hidBrnID.ClientID%>';
		 var hidCrPrClientID = '<%=hidCrPrID.ClientID%>';	 
		 var hidUniClientID = '<%=hidUniID.ClientID%>';	
         var hidCountryIDForeignClientID = '<%=hidCountryIDForeign.ClientID %>';
		
		
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

         function showMarkChoice(choice)
		{
		   
		    elgChoice=choice.value;
		    if(choice.value=="rbMarkNotElg")
		    {
		        document.getElementById("<%=rbMarkElg.ClientID %>").checked=false;
		        document.getElementById("<%=rbMarkNotElg.ClientID %>").checked=true;
		        document.getElementById("<%=NotElgReason.ClientID %>").style.display="block";
		        document.getElementById("<%=hidEligibility.ClientID %>").value="Not Eligible";
		    }	
		    else if(choice.value=="rbMarkElg")
		    {
		        document.getElementById("<%=rbMarkNotElg.ClientID %>").checked=false;
		        document.getElementById("<%=rbMarkElg.ClientID %>").checked=true;
		        document.getElementById("<%=NotElgReason.ClientID %>").style.display="none";
		        document.getElementById("<%=hidEligibility.ClientID %>").value="Eligible";
		        document.getElementById("<%= txtNotElgReason.ClientID%>").value="";
		    }
	
		}

      function showEligibilityChoice(choice)
		{	
		    if(choice.value=="rbElgDecsionYes")
		    {


		        document.getElementById("<%=rbElgDecsionNo.ClientID %>").checked=false;
		        document.getElementById("<%=tblMarkElg.ClientID %>").style.display="block";
		        document.getElementById("<%=btnSubmit.ClientID %>").disabled=false;
		      //  document.getElementById("<%=rbMarkElg.ClientID %>").checked=true;
		        document.getElementById("<%=rbMarkNotElg.ClientID %>").checked=false;
                document.getElementById("<%=DivExaminingBodyFilter.ClientID %>").style.display="none";

		            //show checkboxes on Yes			        	        
                    var GV= document.getElementById("<%=dgRegPendingStudents1.ClientID%>");               
                    for(var j=0;j<GV.length;j++)
                    {    
                        if(GV[j].cells[16]!=null)  
                        {   
                           // GV[j].cells[16].style.display='block';
                           // GV[j].cells[16].visible=true;                            
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
		         document.getElementById("<%=DivExaminingBodyFilter.ClientID%>").style.display="block";

		         //hide checkboxes on No			        	        
                 var GV= document.getElementById("<%=dgRegPendingStudents1.ClientID%>");
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
			
		//Validating eligibility form number.
		
		function ChkValidation()
		{
	        
		  var obPRN = document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_txtPRN').value;
		  var obElg = document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_txtElgFormNo').value;
          var obAppFormNo = document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_txtApplicationFrmNo').value;
		  var sStr = obElg.split('-');	
		  var ret=true;
		  var myArr=new Array();
		  var j=-1;
		  var innerRet=false;
		  document.getElementById("<%= hidSSVal.ClientID%>").value="1";

		  
		  if((obPRN.length == 0)&&(obElg.length==0)&&(obAppFormNo.length==0))
		  {
		    document.getElementById("<%= hidSSVal.ClientID%>").value="";
            if(document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_trPRN').style.display=="none" )//&& document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_txtApplicationFrmNo').style.display=="none" )
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
              {
                if (document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value == "Y")
                {
	                 myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter either a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Eligibility Form Number.","text");
                }
              }
		      if(obPRN.length==0)
	          myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter either a valid Eligibility Form Number OR Application Form No.","text");
              if(obElg.length==0)
              {
                  if (document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value == "Y")
                    {
	                    myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter either a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Application Form No.","text");		  
                    }
              }
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
	            if(sStr[1] == document.getElementById('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_hidInstID').value)
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

         function fnFilterClickYesNo()
        
            { 
			//var rdFilter = new Array();
			var rdFilter0 = document.getElementById('ctl00_ContentPlaceHolder1_rbFilterYesNo_0');
			var rdFilter1 = document.getElementById('ctl00_ContentPlaceHolder1_rbFilterYesNo_1');
			
			         
			if(document.getElementById('ctl00_ContentPlaceHolder1_rbFilterYesNo_0').checked)    // Yes Examining body filter
          
            {    
                document.getElementById('ctl00_ContentPlaceHolder1_DivFilterExamBody').style.display = "block";                  
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
            }        
            
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

			}

            function selfillStateBoard_Callback(response)		   
		    
		    {
		        var ds = response.value[0];
		        var d  = document.getElementById('<%=Body_ID.ClientID %>');
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
		        var d  = document.getElementById('<%=Body_ID.ClientID %>');		       
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
					        document.getElementById('<%= hidCrMoLrnID.ClientID%>').value = '0';
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
					document.getElementById('ctl00_ContentPlaceHolder1_TrCountry').style.display = "none";
					}
					else
					{	document.getElementById('ctl00_ContentPlaceHolder1_TrState').style.display = 'none';
					document.getElementById('ctl00_ContentPlaceHolder1_TrBody').style.display = 'none';
					document.getElementById('ctl00_ContentPlaceHolder1_TrCountry').style.display = 'inline';									
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

		}


        function setValueState(Text,Value)
			{

				var text = eval(document.getElementById(Text));
				text.value = Value;					
				
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
		}	
        


        function CheckFilter()
        {

        if(document.getElementById("<%=rbElgDecsionYes.ClientID %>").checked=false)

		    {
		        document.getElementById("<%=DivExaminingBodyFilter.ClientID %>").style.display="block";
		        document.getElementById("<%=rbFilterYesNo.ClientID %>").value="0";               
		    }
		    else if(document.getElementById("<%=rbElgDecsionNo.ClientID %>").checked=false)
		    {	
	 
		         document.getElementById("<%=DivExaminingBodyFilter.ClientID %>").style.display="none";
		        document.getElementById("<%=rbFilterYesNo.ClientID %>").value="1";	               
		    }			
        }
        	

		function fillStateBoard(val) //New Logic for Board Details
			{           		    
		    document.getElementById(Body_IDClient).value = "0";
    			
			    if (document.getElementById('ctl00_ContentPlaceHolder1_Body_Type_Flag_0').checked)//Board
			        {	
			           	
					    AjaxMethods.fillStateBoard_BulkProcess(parseInt(val),uniid,document.getElementById(hidInstClientID).value,document.getElementById(hidFacClientID).value,document.getElementById(hidCrClientID).value,document.getElementById(hidMoLrnClientID).value,document.getElementById(hidPtrnClientID).value,document.getElementById(hidBrnClientID).value,selfillStateBoard_Callback);
				    }
				    
				 else if (document.getElementById('ctl00_ContentPlaceHolder1_Body_Type_Flag_1').checked)//University
			        {	
			           
					    AjaxMethods.fillStateUniversity1(parseInt(val),uniid,document.getElementById(hidInstClientID).value,document.getElementById(hidFacClientID).value,document.getElementById(hidCrClientID).value,document.getElementById(hidMoLrnClientID).value,document.getElementById(hidPtrnClientID).value,document.getElementById(hidBrnClientID).value,parseInt(val),selfillStateUniversity_Callback);
					    
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
	            document.getElementById('<%=txtPRN.ClientID%>').value="";
	            document.getElementById('<%=txtElgFormNo.ClientID%>').value="";	
                document.getElementById('<%=txtApplicationFrmNo.ClientID%>').value="";
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
		
		
	    function showMarkChoice(choice)
		{
		   
		    elgChoice=choice.value;
		    if(choice.value=="rbMarkNotElg")
		    {
		        document.getElementById("<%=rbMarkElg.ClientID %>").checked=false;
		        document.getElementById("<%=rbMarkNotElg.ClientID %>").checked=true;
		        document.getElementById("<%=NotElgReason.ClientID %>").style.display="block";
		        document.getElementById("<%=hidEligibility.ClientID %>").value="Not Eligible";
		    }	
		    else if(choice.value=="rbMarkElg")
		    {
		        document.getElementById("<%=rbMarkNotElg.ClientID %>").checked=false;
		        document.getElementById("<%=rbMarkElg.ClientID %>").checked=true;
		        document.getElementById("<%=NotElgReason.ClientID %>").style.display="none";
		        document.getElementById("<%=hidEligibility.ClientID %>").value="Eligible";
		        document.getElementById("<%= txtNotElgReason.ClientID%>").value="";
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
            if(elgChoice=="rbMarkNotElg")
                myArr[++i]  = new Array(document.getElementById("<%= txtNotElgReason.ClientID%>"),"Empty","Please Enter Reason for marking selected student(s) as \"Not Eligible\".","text");
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
                if(confirm("Are you sure you want to Resolve the Provisional Eligibility of the Selected Student(s) by marking them as \""+document.getElementById("<%=hidEligibility.ClientID %>").value+"\"?"))
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

    </script>
    <center>
        <table id="table1" border="0" style="border-collapse: collapse" bordercolor="#c0c0c0"
            cellpadding="2" width="100%">
            <tr>

                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="black"></asp:Label>
                    <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="True" Font-Size="Small"
                        meta:resourcekey="lblAcademicYearResource1" Style="display: none"></asp:Label>
                </td>
            </tr>
            <%--<table cellspacing="0" cellpadding="0" border="0">
                    <tr style="height:5px;"><td></td>
                    </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkSimpleSearch" CssClass="NavLink" runat="server" OnClick="lnkSimpleSearch_Click" meta:resourcekey="lnkSimpleSearchResource1">Simple Search</asp:LinkButton>&nbsp;|&nbsp;
                                <asp:LinkButton ID="lnkAdvSearch" CssClass="NavLink" runat="server" OnClick="lnkAdvSearch_Click" meta:resourcekey="lnkAdvSearchResource1">Advanced Search</asp:LinkButton>
                            </td>
                        </tr>
                        <tr style="height: 10pt;">
                            <td>
                            </td>
                        </tr>
                    </table>--%>
            <%--<div id="divSimpleSearch" runat="server">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td align="right" height="30">
                                    <strong>Enter&nbsp;Eligibility Form Number</strong></td>
                                <td align="center" width="2%" height="30">
                                    <b></b>
                                </td>
                                <td width="58%" height="30">
                                    <asp:TextBox ID="tbElgFormNo" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="tbElgFormNoResource1"></asp:TextBox>
                                    <font class="Mandatory">*</font></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <br>
                                    <asp:Button ID="btnSimpleSearch" CssClass="butSubmit" Text="Search" runat="server"
                                        OnClick="btnSimpleSearch_Click" meta:resourcekey="btnSimpleSearchResource1"></asp:Button>
                                </td>
                            </tr>
                            <div id="divErrorMsg" runat="server">
                                <tr>
                                    <td align="center" colspan="3">
                                        <br>
                                        <br>
                                        <br>
                                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="errorNote" Visible="False" meta:resourcekey="lblErrorMsgResource1"></asp:Label></td>
                                </tr>
                            </div>
                        </table>
                    </div>--%>
        </table>
        <%--        <uc1:StudentAdvanceSeachForConfigure ID="StudentAdvanceSeachForConfigure1" runat="server">
        </uc1:StudentAdvanceSeachForConfigure>--%>
        <div align="right">
            <asp:Label ID="lblSubmitMessage" Style="text-align: right; display: none;" runat="server"
                Width="100%" CssClass="saveNote" meta:resourcekey="lblSubmitMessageResource2"></asp:Label>
        </div>
        <center>
            <table id="Table4" cellspacing="0" width="100%" border="0">
                <tr>
                    <td align="center" colspan="3">
                   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>--%>
                        <fieldset>
                            <legend><strong><span style="text-decoration: underline">Search Criteria</span></strong></legend>
                            <table cellspacing="0" cellpadding="0" border="0" align="center" width="100%">
                                <tr align="right">
                                    <td align="right" style="height: 19px">
                                        <%--<label id="lblSimpleSearch" runat="server" class="NavLink" style="cursor: hand" onclick="fnDisplayDiv('Simple');"
                                            onmouseover="UnderLineOnMouseOver('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_lblSimpleSearch');"
                                            onmouseout="UnderLineOnMouseOut('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_lblSimpleSearch');">
                                            Simple Search
                                        </label>--%>
                                        <label id="lblAdvSearch" runat="server" class="NavLink" style="cursor: hand; color: blue"
                                            onclick="fnDisplayDiv();" onmouseover="UnderLineOnMouseOver('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_lblAdvSearch');"
                                            onmouseout="UnderLineOnMouseOut('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_lblAdvSearch');">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <div id="divSimpleSearch" runat="server">
                                <table cellspacing="0" cellpadding="3" width="100%" border="0" align="left">
                                    <tr align="left" id="trElgFormNo" runat="server">
                                        <td align="right" width="50%">
                                            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="tbElgFormNo" runat="server" Text="Enter Eligibility Form Number"
                                                meta:resourcekey="tbElgFormNoResource2"></asp:Label>
                                                :</b>&nbsp;
                                        </td>
                                        <td height="30" align="left">
                                            <asp:TextBox ID="txtElgFormNo" runat="server" Font-Bold="True" Font-Size="Small" Width="210px"
                                                onclick="this.value='';" meta:resourcekey="txtElgFormNoResource2" CssClass="redbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="center" id="trOr" runat="server">
                                        <td id="Td1" align="Center" colspan="2" runat="server">
                                            <b>OR</b>
                                        </td>
                                    </tr>
                                    <tr align="left" id="trPRN" runat="server">
                                        <td id="Td2" align="right" width="50%" runat="server">
                                            <strong>
                                                <asp:Label ID="lblEnterPRN" runat="server" Text="Enter PRN: " meta:resourcekey="lblEnterPRNResource1"></asp:Label></strong>
                                        </td>
                                        <td id="Td3" height="30" align="left" runat="server">
                                            <asp:TextBox ID="txtPRN" runat="server" MaxLength="20" Font-Bold="True" Font-Size="Small" Width="210px"
                                                onclick="this.value='';" CssClass="redbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="center" id="trOr1" runat="server">
                                        <td id="Td4" align="center" colspan="2" runat="server">
                                            <b>OR</b>
                                        </td>
                                    </tr>
                                    <tr id="trApplicationFormNo" align="left" runat="server">
                                        <td id="Td5" align="right" width="50%" runat="server">
                                            <strong>
                                                <asp:Label ID="lblApplicationFrmNo" runat="server" Text="Enter Application Form Number: "></asp:Label></strong>
                                        </td>
                                        <td id="Td6" height="30" align="left" runat="server">
                                            <asp:TextBox ID="txtApplicationFrmNo" runat="server" MaxLength="20" Font-Bold="True"
                                                Font-Size="Small" Width="210px" onclick="this.value='';" CssClass="redbox" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <br />
                                            <asp:Button ID="btnSimpleSearch" Text="Search" runat="server" OnClick="btnSimpleSearch_Click"
                                                meta:resourcekey="btnSimpleSearchResource1" CssClass="butSubmit"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="DivAdvanceSearch" style="display: none;" runat="server">
                                <table id="tblAcademicYr" runat="server" cellspacing="0" cellpadding="0" width="100%"
                                    border="0">
                                    <tr id="Tr2" runat="server">
                                        <td style="width: 850px;" align="center" colspan="3" runat="server" id="divAcademicYr">
                                            <!-- Selection Starts -->
                                            <table cellspacing="0" cellpadding="0" width="100%">
                                                <tr>
                                                    <td align="right" style="height: 19px; width: 36%;">
                                                        <asp:Label ID="lblAcyr" runat="server" Font-Bold="True" meta:resourcekey="lblAcyrResource1"
                                                            Text="Select Academic Year"></asp:Label>&nbsp;<b>:</b>
                                                    </td>
                                                    <td id="tdAcdYr" runat="server" align="left">
                                                        &nbsp;<asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="selectbox"
                                                            Width="260px" meta:resourcekey="ddlAcademicYrResource1">
                                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <font class="Mandatory">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 5px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                
                                        <%--<asp:Panel ID="pnlSelCourse" runat="server" meta:resourcekey="pnlSelCourseResource2">--%>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td align="right" style="height: 19px; width: 45%;">
                                                        <b>
                                                            <asp:Label ID="lblFaculty" runat="server" Text="Select Faculty" meta:resourcekey="lblFacultyResource1"></asp:Label>
                                                            :&nbsp;</b>
                                                    </td>
                                                    <td colspan="3" style="height: 19px" align="left">
                                                        <asp:DropDownList ID="ddlFaculty" runat="server" Width="260px" CssClass="selectbox"
                                                            onchange="setValue(hid_Fac_id,this.value);FillCourse(this.value);ClearDropDowns(1,5)"
                                                            meta:resourcekey="ddlFacultyResource1">
                                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <font class="Mandatory">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="21%" style="height: 5px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 35%">
                                                        <b>
                                                            <asp:Label ID="lblCourse" runat="server" Text="Select Course" meta:resourcekey="lblCourseResource1"></asp:Label>&nbsp;:&nbsp;</b>
                                                    </td>
                                                    <td colspan="3" align="left">
                                                        <asp:DropDownList ID="ddlCourse" runat="server" Width="260px" CssClass="selectbox"
                                                            onchange="setValue(hid_Cr_id,this.value);FillModeofLearning(this.value);ClearDropDowns(2,5);"
                                                            meta:resourcekey="ddlCourseResource1">
                                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource2" Text="--- Select ---"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <font class="Mandatory">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="21%" style="height: 5px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 35%">
                                                        <b>Select Mode of Learning :&nbsp;</b>
                                                    </td>
                                                    <td colspan="3" align="left">
                                                        <asp:DropDownList ID="ddlMoLrn" runat="server" Width="260px" CssClass="selectbox"
                                                            onchange="setValue(hid_MoLrn_id,this.value);FillCoursePattern(this.value);ClearDropDowns(3,5);"
                                                            meta:resourcekey="ddlMoLrnResource1">
                                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource3" Text="--- Select ---"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <font class="Mandatory">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="21%" style="height: 5px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 35%">
                                                        <b>Select Pattern :&nbsp;</b>
                                                    </td>
                                                    <td colspan="3" align="left">
                                                        <asp:DropDownList ID="ddlCrPtrn" runat="server" Width="260px" CssClass="selectbox"
                                                            onchange="setValue(hid_Ptrn_id,this.value);FillBranchList(this.value);ClearDropDowns(4,5); "
                                                            meta:resourcekey="ddlCrPtrnResource1">
                                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource4" Text="--- Select ---"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <font class="Mandatory">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="21%" style="height: 5px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 35%">
                                                        <b>Select Branch :&nbsp;</b>
                                                    </td>
                                                    <td id="tdBranch" colspan="3" align="left">
                                                        <asp:DropDownList ID="ddlBranch" runat="server" Width="260px" CssClass="selectbox"
                                                            onchange="setValue(hid_Brn_id, this.value);" meta:resourcekey="ddlBranchResource1">
                                                            <asp:ListItem Value="0" meta:resourcekey="ListItemResource5" Text="--- Select ---"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <font class="Mandatory">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="21%" style="height: 5px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 20%;">
                                                        <b>Date of Birth :&nbsp;</b>
                                                    </td>
                                                    <td width="45%" align="left">
                                                        <asp:TextBox ID="txtDOB" runat="server" CssClass="inputbox" Width="70px" MaxLength="10"
                                                            meta:resourcekey="txtDOBResource1" ValidationGroup="dateValidator1" CausesValidation="True"></asp:TextBox>&nbsp;
                                                        <b>[dd/mm/yyyy]</b>
                                                        <%--<a id="alinkCalender" onclick="return showCalendar(document.getElementById(txt_DOB).id, '%d/%m/%Y');"
                                                    runat="server">
                                                    <img onmouseover="this.style.cursor='Hand'" src="../images/cal.gif" align="middle"></a>&nbsp;
                                                [dd/mm/yyyy]--%>
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
                                                            InvalidValueMessage="Date is invalid" ValidationGroup="dateValidator1" TooltipMessage="Input a Date"
                                                            MaximumValue="31/12/9999" MinimumValue="01/01/1753" MaximumValueMessage="Date is invalid"
                                                            MinimumValueMessage="Date is invalid" />
                                                    </td>
                                                    <td align="right" width="15%">
                                                        <b>Gender :&nbsp;</b>
                                                    </td>
                                                    <td width="20%" align="left">
                                                        <asp:DropDownList ID="ddlGender" CssClass="selectbox" runat="server" meta:resourcekey="ddlGenderResource1">
                                                            <asp:ListItem Value="0" Selected="True" meta:resourcekey="ListItemResource7" Text="--- Select ---"></asp:ListItem>
                                                            <asp:ListItem Value="1" meta:resourcekey="ListItemResource8" Text="Male"></asp:ListItem>
                                                            <asp:ListItem Value="2" meta:resourcekey="ListItemResource9" Text="Female"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="20%" style="height: 5px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 21%">
                                                        <b>Last Name :&nbsp;</b>
                                                    </td>
                                                    <td width="39%" align="left">
                                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="inputbox" meta:resourcekey="txtLastNameResource1"></asp:TextBox>
                                                    </td>
                                                    <td align="right" width="20%">
                                                        <b>First Name :&nbsp;</b>
                                                    </td>
                                                    <td width="20%" align="left">
                                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputbox" meta:resourcekey="txtFirstNameResource1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <%--<cc1:CollapsiblePanelExtender ID="ClpnlExtCourse" runat="server" TargetControlID="pnlSelCourse"
                                                ExpandControlID="pnlSearchStudent" CollapseControlID="pnlSearchStudent" ExpandedText="Hide Details"
                                                CollapsedText="Show Details" ImageControlID="imgbtnCourse" ExpandedImage="~/Images/up.png"
                                                CollapsedImage="~/Images/down.png" SuppressPostBack="True" AutoExpand="True"
                                                Enabled="True">
                                            </cc1:CollapsiblePanelExtender>--%>
                                   <%-- </ContentTemplate>
                                    <Triggers >
                                        <asp:PostBackTrigger ControlID = "lblSimpleSearch" />
                                        <asp:PostBackTrigger ControlID = "lblAdvSearch" />
                                        </Triggers>
                                </asp:UpdatePanel>--%>
                                <table id="tblSubmit" runat="server" cellspacing="0" cellpadding="3" width="100%">
                                    <tr id="Tr3" class="rFont" runat="server">
                                        <td id="Td7" align="right" style="height: 25px" runat="server">
                                            <asp:Button ID="btnSearch" runat="server" CssClass="butSubmit" Width="158px" Height="18px"
                                                Text="Search" OnClick="btnSearch_Click" OnClientClick="return advSearchValidate();"
                                                ValidationGroup="dateValidator1"></asp:Button>
                                        </td>
                                        <td id="Td8" align="left" style="height: 25px" runat="server">
                                            &nbsp;<asp:Button ID="btnClear" runat="server" CssClass="butSubmit" Text="Clear Search Criteria"
                                                Height="18px" Width="186px" OnClientClick="return fnClearSearchCriteria();">
                                            </asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </fieldset>
                        <!-- Eligibility decision area -->
                        <table width="100%" style="display: none" id="tblResolveQuestion" runat="server">
                            <tr id="Tr4" runat="server">
                                <td id="Td9" style="text-align: right; width: 60%" runat="server">
                                    <b>&nbsp;&nbsp; Do you want to Resolve Provisional Eligibility of Student(s) in Bulk?
                                        : </b>
                                </td>
                                <td id="Td10" style="text-align: left" runat="server">
                                    <asp:RadioButton ID="rbElgDecsionYes" runat="server" Text="Yes" Checked="True" onclick="showEligibilityChoice(this)" />
                                    <asp:RadioButton ID="rbElgDecsionNo" runat="server" Text="No" onclick="showEligibilityChoice(this)" />
                                </td>
                            </tr>
                        </table>

                         <table width="100%" style="display: none" id="tblMarkElg" runat="server">
                            <tr id="Tr5" runat="server">
                                <td id="Td11" style="text-align: right; width: 60%" runat="server">
                                    <b>Resolve Provisional Eligibility of Student(s) in Bulk and mark them as: </b>
                                </td>
                                <td id="Td12" style="text-align: left" runat="server">
                                    <asp:RadioButton ID="rbMarkElg" runat="server" Text="Eligible" onclick="showMarkChoice(this)" />
                                    <asp:RadioButton ID="rbMarkNotElg" runat="server" Text="Not Eligible" onclick="showMarkChoice(this)" />
                                </td>
                            </tr>
                        </table>
                        <div id="NotElgReason" runat="server" style="display: none">
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right; width: 60%">
                                        <b>Reason(s) for marking selected students as Not Eligible: </b>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="txtNotElgReason" runat="server" TextMode="MultiLine" Width="90%"
                                            meta:resourcekey="txtNotElgReasonResource2"></asp:TextBox><font class="Mandatory">*</font>
                                    </td>
                                </tr>
                            </table>
                        </div>



                        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                                <asp:Panel ID="Panel1" runat="server">
                                    <div id="DivExaminingBodyFilter" runat="server" style="display: none">
                                        <fieldset id="Fieldset3" runat="server">
                                            <legend><strong>Examining Body Filter</strong></legend>
                                            <table cellspacing="0" cellpadding="0" width="95%" border="0">
                                                <tr style="height: 5px;">
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr id="Tr1" height="10px" runat="server">
                                                    <td align="right" style="height: 10px; width: 385px;">
                                                        <strong>Do you want to use Filters for selecting Examining Body&nbsp;</strong>
                                                    </td>
                                                    <td style="height: 10px; width: 1%;">
                                                        <strong>:</strong>
                                                    </td>
                                                    <td style="height: 10px" align="left">
                                                        <asp:RadioButtonList ID="rbFilterYesNo" onclick="fnFilterClickYesNo();" runat="server"
                                                            RepeatDirection="Horizontal" meta:resourcekey="rbFilterYesNoResource1">
                                                            <asp:ListItem Value="1" meta:resourcekey="ListItemResource3" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="0" Selected="True" meta:resourcekey="ListItemResource2" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <fieldset id="DivFilterExamBody" runat="server">
                                                <legend><strong>Examining Body Selection Criteria</strong></legend>
                                                <table cellspacing="0" cellpadding="0" width="95%" border="0">
                                                    <tr id="TrExamBody" runat="server">
                                                        <td align="right" style="width: 28%;">
                                                            <strong>Select Examining Body</strong>
                                                        </td>
                                                        <td style="width: 1%;">
                                                            <strong>&nbsp;:&nbsp;</strong>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList ID="Body_Type_Flag" onclick="OnBodyTypeChange();" runat="server"
                                                                RepeatDirection="Horizontal" meta:resourcekey="Body_Type_FlagResource1">
                                                                <asp:ListItem Value="1" Selected="True" meta:resourcekey="ListItemResource4" Text="Board"></asp:ListItem>
                                                                <asp:ListItem Value="2" meta:resourcekey="ListItemResource5" Text="University"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr id="TrBody_Indian_Foreign" runat="server">
                                                        <td id="TdBody_Indian_Foreign" align="right" style="width: 28%">
                                                            <strong>Select Board</strong>
                                                        </td>
                                                        <td align="center" style="width: 1%">
                                                            <strong>&nbsp;:&nbsp;</strong>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList ID="Body_Indian_Foreign_Flag" onclick="OnIndianForeignChange();"
                                                                runat="server" RepeatDirection="Horizontal" meta:resourcekey="Body_Indian_Foreign_FlagResource1">
                                                                <asp:ListItem Value="0" Selected="True" meta:resourcekey="ListItemResource6" Text="Indian"></asp:ListItem>
                                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource7" Text="Foreign"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 5px;">
                                                        </td>
                                                    </tr>
                                                    <tr id="TrCountry" style="display: none" runat="server">
                                                        <td style="width: 28%;" align="right">
                                                            <strong>Select Country</strong>
                                                        </td>
                                                        <td style="width: 1%;" align="center">
                                                            <strong>&nbsp;:&nbsp;</strong>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="Body_Country" runat="server" CssClass="selectbox" Width="198px"
                                                                meta:resourcekey="Body_CountryResource1" onblur="setValueState(hidCountryIDForeignClientID,this.value)">
                                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource8" Text="--- Select ---"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <font class="Mandatory">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr id="TrCountryForeignBoardUniv" style="display: none" runat="server">
                                                        <td style="width: 28%;" align="right">
                                                            <strong>
                                                                <asp:Label ID="lblBrdUniName" runat="server" Text="Board/University Name" meta:resourcekey="lblBrdUniNameResource1"></asp:Label></strong>
                                                        </td>
                                                        <td style="width: 1%;" align="center">
                                                            <strong>&nbsp;:&nbsp;</strong>
                                                        </td>
                                                        <td style="width: 100%;" align="left">
                                                            <b>
                                                                <asp:TextBox ID="txtForeignBoardUnivName" runat="server" CssClass="inputbox" Width="418px"
                                                                    meta:resourcekey="txtForeignBoardUnivNameResource1"></asp:TextBox></b>
                                                        </td>
                                                    </tr>
                                                    <tr id="TrState" runat="server">
                                                        <td style="width: 28%;" align="right">
                                                            <strong>Select State</strong>
                                                        </td>
                                                        <td style="width: 1%;" align="center">
                                                            <strong>&nbsp;:&nbsp;</strong>
                                                        </td>
                                                        <td id="TdState" align="left">
                                                            <asp:DropDownList ID="Body_State" runat="server" onblur="setValueState(hid_StateClientID,this.value)"
                                                                onchange="fillStateBoard(this.value)" 
                                                                CssClass="selectbox" Width="198px" meta:resourcekey="Body_StateResource1">
                                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource9" Text="--- Select ---"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <font class="Mandatory">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr id="TrBody" runat="server">
                                                        <td id="TdBodyCaption" style="width: 28%; font-weight: bold" align="right">
                                                            <strong>Select Board</strong>
                                                        </td>
                                                        <td style="width: 1%;" align="center">
                                                            <strong>&nbsp;:&nbsp;</strong>
                                                        </td>
                                                        <td id="TdBodyID" align="left">
                                                            <asp:DropDownList ID="Body_ID" onblur="setValueState(hid_BodyClientID,this.value);"
                                                                runat="server" CssClass="selectbox" Width="418px" meta:resourcekey="Body_IDResource1">
                                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource10" Text="--- Select ---"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <font class="Mandatory">*</font>
                                                        </td>
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
                                                        <asp:Button ID="btnProcessData1" runat="server"  CssClass="butSubmit" Text="Submit"
                                                            OnClientClick="return validateExaminingBody()" OnClick="btnProcessData_Click"
                                                            Height="18px" Width="70px" meta:resourcekey="btnProcessDataResource1" />
                                                    </td>
                                                </tr>
                                                <tr style="height: 5px;">
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </div>
                                </asp:Panel>
                            
                       
                        <p style="margin-top: 10px; margin-bottom: 1px; margin-left: 0px" align="left">
                            <asp:Label ID="lblGridName" Style="display: none" runat="server" Width="99%" CssClass="errorNote"
                                Height="18px" meta:resourcekey="lblGridNameResource1"></asp:Label></p>
                        <p style="margin-top: 0px; margin-bottom: 0px; margin-left: 0px" align="center">
                            &nbsp;</p>
                        <div id="divDGNote" style="display: none; height: 12px" align="left" runat="server">
                            <font color="red">* Please click on the student name to view his/her respective profile</font></div>
                         <%--   </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
                
                <tr>
                    <td style="height: 30; width: 953px" align="center" colspan="3">
                  <%--  <asp:UpdatePanel runat="server" id="UPD1">
                        <ContentTemplate>--%>
                        <table id="tblDGRegPendingStudents" style="display: none" width="100%" runat="server">
                            <tr id="Tr7" runat="server">
                                <td id="Td14" align="left" runat="server">
                                    <asp:Label runat="server" ID="lblGrid" CssClass="divDGNote" ForeColor="Red" meta:resourcekey="lblGridResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr id="Tr8" runat="server">
                                <td id="Td15" runat="server">
                                    <br />
                                </td>
                            </tr>
                            <tr id="TrColorCodes" runat="server">
                                <td>
                                    <p>
                                        <br />
                                        <b>Following are the color codes which are used in the Students' list to distinguish
                                            the students according to the given 4 types of Examining Bodies:</b>
                                        <br />
                                        <asp:Label ID="LblSame_university" BackColor="Bisque" runat="server" Text="Same Board/University"
                                            meta:resourcekey="LblSame_universityResource1"></asp:Label>&nbsp;
                                        <asp:Label ID="LblHome_board" BackColor="#E1FFFF" runat="server" Text="Same State Board/University"
                                            meta:resourcekey="LblHome_boardResource1"></asp:Label>&nbsp;
                                        <asp:Label ID="LblOther_state_board" BackColor="#CCEEFF" runat="server" Text="Other State Board/University"
                                            meta:resourcekey="LblOther_state_boardResource1"></asp:Label>&nbsp;
                                        <asp:Label ID="LblForeign_board" BackColor="#FFCCFF" runat="server" Text="Foreign Board/University"
                                            meta:resourcekey="LblForeign_boardResource1"></asp:Label>
                                    </p>
                                    <br />
                                </td>
                            </tr>
                            <tr id="Tr9" runat="server">
                                <td id="Td16" runat="server">
                                    <asp:GridView ID="dgRegPendingStudents1" runat="server" Width="100%" BorderWidth="1px"
                                        BorderStyle="Solid" AllowSorting="True" AllowPaging="True" BorderColor="#336699"
                                        CssClass="clGrid grid-view" AutoGenerateColumns="False" OnPageIndexChanging="dgRegPendingStudents1_PageIndexChanging"
                                        OnRowCommand="dgRegPendingStudents1_RowCommand" OnRowDataBound="dgRegPendingStudents1_RowdataBound"
                                        meta:resourcekey="dgRegPendingStudents1Resource1" OnSorting="dgRegPendingStudents1_Sorting"
                                        PageSize="50">
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
                                                SortExpression="AdmissionFormNo">
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
                                                SortExpression="InstituteName" meta:resourcekey="BoundFieldResource7">
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CourseName" ReadOnly="True" HeaderText="Course Admitted To"
                                                SortExpression="CourseName" meta:resourcekey="BoundFieldResource8">
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DocCount" SortExpression="DocCount" HeaderText="No of Documents Submitted"
                                                meta:resourcekey="BoundFieldResource9">
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
                                            <asp:BoundField DataField="pkCrPrCh" HeaderText="pkCrPrCh" meta:resourcekey="BoundFieldResource18">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Reason" HeaderText="Remark" SortExpression="Reason">
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Body_Name" HeaderText="Examining Body" SortExpression="Body_Name">
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="State_Name" HeaderText="State" SortExpression="State_Name">
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" />
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
                                            <asp:BoundField DataField="ExamBodyType" HeaderText="ExamBodyType" SortExpression="ExamBodyType">
                                            </asp:BoundField>
                                        </Columns>
                                        <HeaderStyle CssClass="gridHeader" />
                                        <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                        </PagerStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    <%--    </ContentTemplate>
                    </asp:UpdatePanel>--%>
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
        <input id="hidUniID" runat="server" name="hidUniID" type="hidden" />
        <input id="hidInstID" runat="server" name="hidInstID" type="hidden" />
        <input id="hidpkStudentID" type="hidden" name="hidpkStudentID" runat="server" />
        <input id="hidpkYear" type="hidden" name="hidpkYear" runat="server" />
        <input id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server" />
        <input id="hidpkFacID" type="hidden" name="hidpkFacID" runat="server" />
        <input id="hidpkCrID" type="hidden" name="hidpkCrID" runat="server" />
        <input id="hidpkMoLrnID" type="hidden" name="hidpkMoLrnID" runat="server" />
        <input id="hidpkPtrnID" type="hidden" name="hidpkPtrnID" runat="server" />
        <input id="hidpkBrnID" type="hidden" name="hidpkBrnID" runat="server" />
        <input id="hidpkCrPrDetailsID" type="hidden" name="hidpkCrPrDetailsID" runat="server" />
        <input id="hidSearchType" type="hidden" name="hidSearchType" runat="server" />
        <input id="hid_fk_AcademicYr_ID" type="hidden" name="hid_fk_AcademicYr_ID" runat="server" />
        <input id="hidAcademicYrText" type="hidden" name="hidAcademicYrText" runat="server" />
        <input id="hidAppFormNo" type="hidden" value="0" name="hidAppFormNo" runat="server" />
        <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
            meta:resourcekey="lblUniversityResource1"></asp:Label>
        <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
        <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none"
            meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>
        <input id="hidFacName" runat="server" type="hidden" />
        <input id="hidCrName" runat="server" type="hidden" />
        <input id="hidMOLName" runat="server" type="hidden" />
        <input id="hidPattern" runat="server" type="hidden" />
        <input id="hidBrName" runat="server" type="hidden" />
        <input id="hidCrPrName" runat="server" type="hidden" />
        <input id="hidAcYrName" runat="server" type="hidden" />
        <input id="hid_MoLrnID" runat="server" type="hidden" />
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
        <input id="hidStep" type="hidden" name="hidStep" runat="server" />
        <input id="Hidden6" type="hidden" value="0" name="hidpkYear" runat="server" />
        <input id="hidDOB" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
            runat="server" />
        <input id="hidLastName" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
            runat="server" />
        <input id="hidFirstName" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
            runat="server" />
        <input id="hidGender" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
            runat="server" />
        <input id="Hidden7" runat="server" name="hid_fk_AcademicYr_ID" value="" type="hidden" />
        <input id="hidIsBlank" type="hidden" name="hidIsBlank" runat="server" />
        <input id="Hidden8" runat="server" name="hidAcademicYrText" value="" type="hidden" />
        <input id="hidPRN" type="hidden" name="hidPRN" runat="server" />
        <input type="hidden" id="Hidden9" runat="server" />
        <input id="hidEligibility" type="hidden" runat="server" />
        <input id="hidCheckboxChosen" type="hidden" runat="server" />
        <input id="hidSubmitFlag" type="hidden" runat="server" value="0" />
        <input id="Hidden10" type="hidden" value="0" name="hidAppFormNo" runat="server" />
        <asp:Label ID="Label1" runat="server" Text="University" Style="display: none"></asp:Label>
        <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="College" Style="display: none"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="PRN" Style="display: none"></asp:Label>
        <input id="hidFresh" runat="server" value="" type="hidden" />
        <input type="hidden" id="hidSSVal" runat="server" value="1" />
        <input id="hidBranchName" type="hidden" runat="server" />
        <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired"
            runat="server" />
        <input id="hidCountryIDForeign" type="hidden" name="hidCountryIDForeign" runat="server" />
        <input id="hidtxtCountryForeignBoardUniv" type="hidden" value="0" name="hidtxtCountryForeignBoardUniv"
            runat="server" />
        <input id="hid_StateID" type="hidden" name="hid_StateID" runat="server" />
        <input id="hidBodyTypeFlag" type="hidden" name="hidBodyTypeFlag" runat="server" />
        <input id="hidStateSelText" type="hidden" name="hidStateSelText" runat="server" />
        <input id="hidMoLrnID" style="width: 24px; height: 22px" type="hidden" name="hidMoLrnID"
            runat="server" />
        <input id="hid_BodyID" type="hidden" name="hid_BodyID" runat="server" />
        <input id="hidCrPrID" style="width: 24px; height: 22px" type="hidden" name="hidCrPrID"
            runat="server" />
        <input id="hidBodySelText" type="hidden" name="hidBodySelText" runat="server" />
        <input id="hidBodyState" type="hidden" name="hidBodyState" runat="server" />
        <input id="hidBodyID" type="hidden" name="hidBodyID" runat="server" />
        <input id="hid_MoLrn_id" type="hidden" name="hid_MoLrn_id" runat="server" />
        <input id="hidCountryId" type="hidden" name="hidCountryIDForeign" runat="server" />
        <input id="hidCollege_Eligibility_Flag" style="width: 24px; height: 22px" type="hidden"
            name="hidCollege_Eligibility_Flag" runat="server" />
    </center>
</asp:Content>
