<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="ELGV2_PaperChange__3.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_PaperChange__3" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>



<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="content1">

<link href="css/3-StepLaunch.css" type="text/css" rel="stylesheet"/>

 <style type="text/css">
	
	    .clPopupTable
        {
            width:550px;
        }
 </style>
    
<!------------------------------ Script For XML TREE ----------------------------------------------->
<script language="javascript" type="text/javascript"> 
            //
			//Name : Neeraj
			//Date : 25 July 2007			
			//
			var gotErr="N"		
			var msg='';				
			var myElement;
			var message;	
			var IsPMinLimitCheck=false;
			
			//
			// Added By : Rupam 
			// Date     : 2 May 2008
			//
			function changeBackgroundColor(sGroupID,sTdCheck)
		    {   
		        oGroupID = 'TDGroup'+sGroupID;
		        arrChkBox = document.getElementById(oGroupID).getElementsByTagName("INPUT");		        
		        for(i=0;i<arrChkBox.length;i++)
			    {	
			        sCheckID = sTdCheck.split('__')[12];			        	       
					arrCheckIDtemp = arrChkBox[i].id.split(',')[0];
					arrCheckID = arrCheckIDtemp.split('_')[0];		
					if(sCheckID == arrCheckID)
					{			
				        if(arrChkBox[i].type=='checkbox' && arrChkBox[i].checked==true)				    
				        {			            					
					        document.getElementById(sTdCheck).style.backgroundColor = "#FFFFCD";
					    }
					    else
					    {		        		       
					        document.getElementById(sTdCheck).style.backgroundColor = "#FFFFFF";
					    }					    	  
				    }
				    			    
		        } 	    				       
		    }	
		   
		    //
			//Name : Neeraj Choudhary
			//Date Created : 11-SEP-2008
			//Purpose : Check minimum limit of paper and paper group
			//		     
	         function ValidateMinLimit()
	         {		
	            if(paperFactory.paperList.length==0)
			    {
			        var message = 'Papers not affiliated for this Course Part Term<br><br>Please affiliate papers first.';
                    showValidationSummary(myElement,message);				             		                
                    return false;
			    }        
			    
		        var ret=false
		        for(a=0;a<paperFactory.paperList.length ;a++)
		        {
		              if(paperFactory.paperList[a].Group.ContainsGroup=='N')
		              {     		            
                         ret = CheckMinLimit(paperFactory.paperList[a].Group.GID.toString());
		                 if(ret==false)
		                       return false;
		              }		              
		        }
		        return true;
	         }
		    
		    //
			//Name : Neeraj Choudhary
			//Date Created : 11-SEP-2008
			//Purpose : Check minimum limit of paper and paper group
			//
			function CheckMinLimit(oGroupID)
			{	
			    var iNum = 0;
			    for(iNum=0;iNum<paperFactory.paperList.length ;iNum++)
			    {			       
			        if(paperFactory.paperList[iNum].Group.GID.toString()==oGroupID)
			        {  
	                    var iCount = 0
	                    var ChkBox=null;
	                    var message = ''
	                    //
                        //Group having NO PARENT GROUP (means groupid and parent group id is same.)
                        //
	                    if(parseInt(paperFactory.paperList[iNum].Group.GID.toString())== parseInt(paperFactory.paperList[iNum].Group.PID.toString()))	                    
	                    {
	                        if(paperFactory.paperList[iNum].Group.ContainsGroup=='N')
	                        {
	                            iCount = 0
                                for(k=0;k<paperFactory.paperList[a].Group.Children.length;k++)
                                {
                                    ChkBox = document.getElementById(paperFactory.paperList[a].Group.Children[k])
                                    if(ChkBox!=null && ChkBox.type=='checkbox' && ChkBox.checked==true)
                                    {
                                        iCount = iCount + 1
                                    }
                                }
                                if((parseInt(paperFactory.paperList[a].Group.GMin) > parseInt(iCount)))
                                {		                        
                                    message = 'Atleast '+ paperFactory.paperList[a].Group.GMin +' paper(s) should be selected from \''+paperFactory.paperList[a].Group.GName +'\'.<br>';
                                    showValidationSummary(myElement,message);				             		                
                                    return false;				                
                                } 
	                        }
	                        else	
	                        {
                                var iCount = 0;         
                                for(q=0;q<paperFactory.paperList[iNum].Group.Children.length;q++)
                                {
                                    oGroupID = 'TDGroup'+paperFactory.paperList[iNum].Group.Children[q].toString();
			                        arrChkBox = document.getElementById(oGroupID).getElementsByTagName("INPUT");                																	
			                        for(r=0;r<arrChkBox.length;r++)
			                        {					
				                        if(arrChkBox[r].type=='checkbox' && arrChkBox[r].checked==true)
				                        {	
					                        iCount = iCount + 1;								                
					                        break; 
				                        }				
			                        }						                                               
                                }	                                                       	                            
                                if((parseInt(paperFactory.paperList[iNum].Group.GMin) > parseInt(iCount)))
                                {		                                
                                    message = 'Atleast '+ paperFactory.paperList[iNum].Group.GMin +' sub-group(s) should be selected from \''+paperFactory.paperList[iNum].Group.GName +'\'.<br>';
                                    showValidationSummary(myElement,message);				                     
	                                return false;				                
                                }	                            
	                            return true;                                                
	                        }   
	                    }	
	                    //
	                    //Group having PARENT GROUP
	                    //	                		                	                    
	                    else if(parseInt(paperFactory.paperList[iNum].Group.GID.toString())!= parseInt(paperFactory.paperList[iNum].Group.PID.toString()))	                    
	                    {   
	                       
	                        if(CheckMinLimit(paperFactory.paperList[iNum].Group.PID)==false)
	                            return false;	
	                        
	                        var oGroupID = null;
		                    var arrChkBox = null; 		                                 
	                        
                            for(p=0;p<paperFactory.paperList.length ;p++)
	                        {			       
	                            if(paperFactory.paperList[p].Group.GID.toString()==paperFactory.paperList[iNum].Group.PID)
	                            {
	                                var iCount = 0;         
	                                for(q=0;q<paperFactory.paperList[p].Group.Children.length;q++)
	                                {
	                                    oGroupID = 'TDGroup'+paperFactory.paperList[p].Group.Children[q].toString();
					                    arrChkBox = document.getElementById(oGroupID).getElementsByTagName("INPUT");                																	
					                    for(r=0;r<arrChkBox.length;r++)
					                    {					
						                    if(arrChkBox[r].type=='checkbox' && arrChkBox[r].checked==true)
						                    {	
							                    iCount = iCount + 1;								                
							                    break; 
						                    }				
					                    }						                                               
	                                }	
                                    //
                                    //Only thoes group should be checked for which atleast 
                                    //one checkbox is checked.i.e why (iCount > 0) 
                                    //                               
	                                if((iCount>0)&&(parseInt(paperFactory.paperList[p].Group.GMin) > parseInt(iCount)))
	                                {	
	                                    iCount = 0;	                                
	                                    message = 'Atleast '+ paperFactory.paperList[p].Group.GMin +' sub-group(s) should be selected from \''+paperFactory.paperList[p].Group.GName +'\'.<br>';
	                                    showValidationSummary(myElement,message);	
			                            return false;				                
	                                }		                          	                            
	                            }		                       
	                        }
		                    	
		                    //
		                    //Check for minimum paper in the group who has paper associate with
		                    //and atleast checked one paper selected
		                    //		                    
		                    if(paperFactory.paperList[iNum].Group.ContainsGroup=='N')
		                    {		                        
		                        iCount = 0
                                for(k=0;k<paperFactory.paperList[iNum].Group.Children.length;k++)
                                {
                                    ChkBox = document.getElementById(paperFactory.paperList[iNum].Group.Children[k])
                                    if(ChkBox!=null && ChkBox.type=='checkbox' && ChkBox.checked==true)
                                    {
                                        iCount = iCount + 1
                                    }
                                }	                                
                                //
                                //Only thoes group should be checked for which atleast 
                                //one checkbox is checked.i.e why (iCount > 0) 
                                //		                   		 			                        	                
                                if((iCount > 0) && (parseInt(paperFactory.paperList[iNum].Group.GMin) > parseInt(iCount)))
                                {	
                                    iCount = 0;	                        
                                    message = 'Atleast '+ paperFactory.paperList[iNum].Group.GMin +' paper(s) should be selected from \''+paperFactory.paperList[iNum].Group.GName +'\'.<br>';
                                    showValidationSummary(myElement,message);                                    
                                    return false;				                
                                }                                  	                    
		                    }                   
	                    } 	                         	            			            			            
			        }
			    }			   
			    return true;
			}   
		    
		    function ValidatePreRequisite(oCurrentCheckBox)
		    {
		    
		        var myMessage  = "";
                var isOpted= false;                    
                var sPapers="";
                var iRequisiteCount = 0;
                var loopBreak=false;       

                for(i=0;i<preRequisiteFactory.Papers.length;i++)
                {   	                    	                        
                    if(parseInt(preRequisiteFactory.Papers[i].Paper.ID)==parseInt(oCurrentCheckBox.id) && preRequisiteFactory.Papers[i].Paper.PreRequisiteType=='N')
                    {		                            
                        for(j=0;j<preRequisiteFactory.Papers[i].Paper.PreRequisitePapers.length;j++)
                        {
                             if(preRequisiteFactory.Papers[i].Paper.PreRequisitePapers[j].IsOpted=='Y')
                             {
                                 sPapers += "<li style='margin:0px 0px 10px 0px;'>"+preRequisiteFactory.Papers[i].Paper.PreRequisitePapers[j].Name;
                                 sPapers += "<div style='color:green'>[<b>Course: </b>"+preRequisiteFactory.Papers[i].Paper.PreRequisitePapers[j].CourseName + "]</div></li>";
                                 isOpted = true;
                             }      
                        }
                        
                        if(isOpted)
                        {
                            myMessage = "You have already opted following paper(s) previously.<ol style='margin:10px 0px 5px 5px;'>"+ sPapers +"</ol>Hence you cannot opt selected paper \""+ preRequisiteFactory.Papers[i].Paper.Name +"\".<hr style='border-width:0px;border-bottom:dashed 1px #000;height:1px;'/>";	                          	                              
                        }
                        
                        loopBreak = true;
                    }
                    
                    sPapers="";
                    isOpted = false;
                    if(parseInt(preRequisiteFactory.Papers[i].Paper.ID)==parseInt(oCurrentCheckBox.id) && preRequisiteFactory.Papers[i].Paper.PreRequisiteType=='A')
                    {
                        for(j=0;j<preRequisiteFactory.Papers[i].Paper.PreRequisitePapers.length;j++)
                        {
                             if(preRequisiteFactory.Papers[i].Paper.PreRequisitePapers[j].IsOpted=='N')
                             {  
                                sPapers += "<li style='margin:0px 0px 10px 0px;'>"+preRequisiteFactory.Papers[i].Paper.PreRequisitePapers[j].Name;
                                sPapers += "<div style='color:green'>[<b>Course: </b>"+preRequisiteFactory.Papers[i].Paper.PreRequisitePapers[j].CourseName + "]</div></li>";
                                iRequisiteCount = iRequisiteCount + 1;
                                isOpted = true;
                             }      
                        }
                        
                        if(isOpted && parseInt(preRequisiteFactory.Papers[i].Paper.MinPp)<= parseInt(iRequisiteCount))
                        {   
                            myMessage +=  "You have not opted following paper(s) previously.<ol style='margin:10px 0px 5px 5px;'>"+ sPapers +"</ol>Hence you cannot opt selected paper \""+ preRequisiteFactory.Papers[i].Paper.Name +"\".<br/>";
                        }
                        
                        loopBreak = true;
                    }
                    if(loopBreak)break;
                }   
                if(myMessage!="")
                {
                   oCurrentCheckBox.checked=false;                           
                   SetCheckboxHolderBgColor(oCurrentCheckBox,false);
                   showValidationSummary(myElement,myMessage);                            
                   return false;
                }  
                return true;
		    }
		    
		    //
			//Name : Neeraj Choudhary
			//Date Created : 11-SEP-2008
			//Purpose : Check maximum limit of paper and paper group
			//
		    function ValidateMaxLimit(oCurrentCheckBox,oGroupID,objThis,evt)
		    {
		        
		        
		        try
		        {
		            var oElement = evt.srcElement ? evt.srcElement : evt.target;
                    if(oElement.tagName=='TD')
                    {
                        oCurrentCheckBox.checked=!oCurrentCheckBox.checked;		
                    }
                }
                catch(e)
                {
                    
                }
	    
			    SetCheckboxHolderBgColor(oCurrentCheckBox,oCurrentCheckBox.checked);	
		    
		        //
	            //Name: Neeraj Chodhary
	            //Date Modified: 30 Jan 2010	         
                //Purpose: As per paper pre-requisite definition we cannot get paper if we have specific paper(s) in previous year/semister.
                //Example: if we want to get Hindi paper we should not have english paper in previous year/semister.
                //
                ValidatePreRequisite(oCurrentCheckBox);		        
			    
			     //
			     //Check Maximum limit recurssively
			     //   			     
			     var retValue=CheckMaxLimit(oCurrentCheckBox,oGroupID);
			     
			     if(retValue)
			     {
			        //
			        //Select all max=min && max=children
			        //	
			        var arrID = oCurrentCheckBox.parentNode.id.split('__');
			        var arrChkBox = document.getElementById('TDGroup'+oGroupID).getElementsByTagName("INPUT");   
			        
			        if(parseInt(arrID[0])==parseInt(oGroupID) && parseInt(arrID[2])==parseInt(arrID[3]) && arrChkBox.length==parseInt(arrID[2]))
			        {                																	
						for(i=0;i<arrChkBox.length;i++)
						{						    
						    arrChkBox[i].checked = 	oCurrentCheckBox.checked;							   				    							  					    
						    SetCheckboxHolderBgColor(arrChkBox[i],arrChkBox[i].checked)										    
						}
						
						//
						//Check all checked child satisfies pre-requisite conditions.
						//
						if(oCurrentCheckBox.checked)
						{
						    var isBool = true;
						    for(j=0;j<arrChkBox.length;j++)
						    {	
						        isBool = ValidatePreRequisite(arrChkBox[j]); 						        								    
						        if(!isBool)break;
						    }
						    //
						    //If any one from a group all should be unchecked.
						    //
						    if(!isBool)
						    {
						        for(k=0;k<arrChkBox.length;k++)
						        {	          
						           arrChkBox[k].checked = isBool; 
						           SetCheckboxHolderBgColor(arrChkBox[k],arrChkBox[k].checked)	 
						        }
						    }    
						}    
			        }	        
			     }
		    }
		    
		    function SetCheckboxHolderBgColor(oCurrentCheckBox,isChecked)
		    {
	            if(isChecked)
		        {   
		            oCurrentCheckBox.parentNode.style.backgroundColor = "#FFFFCD";	
		        }    
		        else    
		        {  
		            oCurrentCheckBox.parentNode.style.backgroundColor = "#FFFFFF";  
		        }
		    }		    
			//
			//Name : Neeraj Choudhary
			//Date Created : 11-SEP-2008
			//Purpose : Check maximum limit of paper and paper group
			//Check child to parent group
			//
			function CheckMaxLimit(oCurrentCheckBox,oGroupID)
			{				        
			    var iNum = 0;
			    for(iNum=0;iNum<paperFactory.paperList.length ;iNum++)
			    {			       
			        if(paperFactory.paperList[iNum].Group.GID.toString()==oGroupID)
			        {  
	                    var iCount = 0
	                    var ChkBox=null;
	                    var message = ''
		                if(paperFactory.paperList[iNum].Group.ContainsGroup=='N')
		                {
		                    //
	                        //Check Group max limit
	                        //
		                    for(k=0;k<paperFactory.paperList[iNum].Group.Children.length;k++)
		                    {
		                        ChkBox = document.getElementById(paperFactory.paperList[iNum].Group.Children[k])
		                        if(ChkBox!=null && ChkBox.type=='checkbox' && ChkBox.checked==true)
		                        {
		                            iCount = iCount + 1
		                        }
		                    }			                    	                   		 			                        	                
		                    if((parseInt(paperFactory.paperList[iNum].Group.GMax) < parseInt(iCount)) && (oCurrentCheckBox.checked==true))
		                    {
		                        oCurrentCheckBox.checked=false;				              
				                SetCheckboxHolderBgColor(oCurrentCheckBox,false);
		                        message='For group \''+ paperFactory.paperList[iNum].Group.GName +'\' , you have already selected '+paperFactory.paperList[iNum].Group.GMax+' paper(s) which is maximum limit for this group.<br>';
		                        showValidationSummary(myElement,message);				               			                
				                return false;				                
		                    }			                    
		                }
		                //
		                //Come out from Recursion  once group does not have parent group.
		                //
		                //	                    
	                    if(parseInt(paperFactory.paperList[iNum].Group.PID)== parseInt(paperFactory.paperList[iNum].Group.GID))
	                    {	                      
	                        return true;	                		                
	                    }   
	                    else
	                    {                          
	                        var oGroupID = null;
		                    var arrChkBox = null; 		                                 
	                        //
	                        //Check Parent Group max limit
	                        //
	                        for(p=0;p<paperFactory.paperList.length ;p++)
		                    {			       
		                        if(paperFactory.paperList[p].Group.GID.toString()==paperFactory.paperList[iNum].Group.PID)
		                        {
		                            var iCount = 0;         
		                            for(q=0;q<paperFactory.paperList[p].Group.Children.length;q++)
		                            {
		                                oGroupID = 'TDGroup'+paperFactory.paperList[p].Group.Children[q].toString();
						                arrChkBox = document.getElementById(oGroupID).getElementsByTagName("INPUT");                																	
						                for(r=0;r<arrChkBox.length;r++)
						                {					
							                if(arrChkBox[r].type=='checkbox' && arrChkBox[r].checked==true)
							                {	
								                iCount = iCount + 1;								                
								                break; 
							                }				
						                }		                                
		                            }		                           	                            
		                            if((parseInt(paperFactory.paperList[p].Group.GMax) < parseInt(iCount)) && (oCurrentCheckBox.checked==true))
		                            {
		                                oCurrentCheckBox.checked=false;	
				                        SetCheckboxHolderBgColor(oCurrentCheckBox,false);
		                                message='For group \''+ paperFactory.paperList[p].Group.GName +'\' , you have already selected '+paperFactory.paperList[p].Group.GMax+' sub group(s) which is maximum limit for this group.<br>';
		                                showValidationSummary(myElement,message);				                                             
				                        return false;				                
		                            }
		                        }
		                    }
	                       CheckMaxLimit(oCurrentCheckBox,paperFactory.paperList[iNum].Group.PID);		
	                    }      	            			            			            
			        }
			    }
			    return true;
			}
			
			function fnValidate()
			{									
				//var bul = CheckMinimumLimit();
				
				var bul =ValidateMinLimit();
				
				if(bul)
				{
					bul = MaximumPaperFinally();					
				}			
				if(bul)
				{
				    bul = CheckSubjectLimits();					
				}																				
				if(bul)
				{												
					/*var arrChkBox = document.getElementsByTagName("INPUT");					
					var sChkBoxVals='';								
					document.getElementById("<%=hid_SelectedPapers.ClientID%>").value='';					
					for(number=0;number<arrChkBox.length;number++)
					{
						if(arrChkBox[number].type=='checkbox' && arrChkBox[number].checked==true)					
						{
							sChkBoxVals += arrChkBox[number].id + ",";														
						}
					
					}						
					sChkBoxVals = sChkBoxVals.substr(0,sChkBoxVals.lastIndexOf(','));
					document.getElementById("<%=hid_SelectedPapers.ClientID%>").value = sChkBoxVals;
					*/
					return true;				
				}
				return false;
			}
			
			function CheckSubjectLimits()
			{
		        var arrChkBox = document.getElementsByTagName("INPUT");					
				var sChkBoxVals='';								
				document.getElementById("<%=hid_SelectedPapers.ClientID%>").value='';	
							
				for(number=0;number<arrChkBox.length;number++)
				{
					if(arrChkBox[number].type=='checkbox' && arrChkBox[number].checked==true)					
					{
					    
						sChkBoxVals += arrChkBox[number].id + ",";														
					}
				
				}										
				sChkBoxVals = sChkBoxVals.substr(0,sChkBoxVals.lastIndexOf(','));
				document.getElementById("<%=hid_SelectedPapers.ClientID%>").value = sChkBoxVals;
		        var intCount=0;			             
		        var sMessage ='<ol style=\"margin-left:0px\">';
		        var ppIDs = '';
		        var re = null;
  		        
                for (i = 0; i<subjectFactory.list.length;i++)
                {       
                    intCount = 0;    
                    ppIDs = '';                          
                    for(j=0;j<subjectFactory.list[i].Subject.Papers.length;j++)
                    { 
                        re = new RegExp('\\b('+ subjectFactory.list[i].Subject.Papers[j].pID.toString()  +')\\b');                                                  
                        if (sChkBoxVals.match(re)!=null)
                        { 
                          intCount  = intCount  +  1 ; 
                        }                        
                    }   
                    if((intCount > 0) && (parseInt(intCount) < parseInt(subjectFactory.list[i].Subject.Min)))
                    {
                        sMessage = sMessage +'<li>Minimum '+ subjectFactory.list[i].Subject.Min +' paper(s) should be selected for subject \''+  subjectFactory.list[i].Subject.SubjectName + '\'.\n'
                    }
                    if((intCount > 0) && (parseInt(subjectFactory.list[i].Subject.Max) < parseInt(intCount)))
                    {
                        sMessage = sMessage +'<li>Maximum '+ subjectFactory.list[i].Subject.Max +' paper(s) should be selected for subject \''+  subjectFactory.list[i].Subject.SubjectName + '\'.\n'
                    }
                }                               		   
                if(sMessage!= '<ol style=\"margin-left:0px\">')
                {                
                    var ms = sMessage + "</ol>";
                    showValidationSummary(myElement,ms);                 
                    return false;
                }
                return true; 
			}			
			var arr=new Array();			
			function MaximumPaperFinally()
			{				
				var CheckedCount=0;
				var chkBoxList = document.getElementsByTagName("INPUT");
				var PaperHeadChildCnt=0;
												
				for(nmb=0;nmb<chkBoxList.length;nmb++)
				{					
					if(chkBoxList[nmb].type=="checkbox" && chkBoxList[nmb].checked)
					{   
					    
					    CheckedCount = CheckedCount + 1;	
					    /*
					    Date : 04-SEP-2008
					    Description : Now Irrespective of papers under paper head we need to increase only once if paperhead selected. 					    
					    PaperHeadChildCnt = chkBoxList[nmb].id.split('_').length;
					    if(PaperHeadChildCnt == 1)
					    {
						    CheckedCount = CheckedCount + 1;	
						}
						else
						{
						    CheckedCount = CheckedCount + PaperHeadChildCnt - 1;	
						}	
						*/										
						//--paper head child paper addition					
					}
				}
				
                ////				//
                ////				//Name: Neeraj
                ////				//Purpose:It was allow to select more than maximum limit 
                ////                //but was not allowed to less than maximum limit
                ////				//Date: 14 May 2010 
                ////				//
                ////				//
                ////				// Compare with max limit
                ////				//								
                ////				var maxPapLimit = document.getElementById("<%=MaxPaperLimit.ClientID%>").value;
                ////							
                ////		        if(maxPapLimit!=null && maxPapLimit!="" && parseInt(maxPapLimit)>0)					
                ////		        {
                ////		            if(CheckedCount < parseInt(maxPapLimit))
                ////		            {	
                ////			            var ms = "Information can not be processed.<br>";
                ////				            ms += "Total "+ maxPapLimit +" paper(s) should be selected.";	
                ////    					
                ////			            //alert(ms);	
                ////			            //commented on 11 june  to  remove validation				
                ////			            showValidationSummary(myElement,ms);
                ////			            return false;						
                ////		            }
                ////		        }
								
				//
				//Name: Neeraj
				//Purpose: Minimum limit implimentation.
				//Date: 14 May 2010 
				//
				var minPapLimit = document.getElementById("<%=MinPaperLimit.ClientID%>").value;
				if(minPapLimit!=null && minPapLimit!="" && parseInt(minPapLimit)>0)					
		        {
		            if(CheckedCount < parseInt(minPapLimit))
		            {	
			            var ms = "Information cannot be processed.<br>";
				            ms += "Please select Total minimum "+ minPapLimit +" papers.";	
    				   				
			           showValidationSummary(myElement,ms);
			           return false;						
		            }
		        }	
			
				//
				//Name : Neeraj
				//Purpose: Minimum limit implimentation.
				//Date: 14 May 2010 
				//
				var maxPapLimit = document.getElementById("<%=MaxPaperLimit.ClientID%>").value;
				if(maxPapLimit!=null && maxPapLimit!="" && parseInt(maxPapLimit)>0)					
		        {
		            if(parseInt(maxPapLimit)<CheckedCount)
		            {	
			            var ms = "Information cannot be processed.<br>";
				            ms += "You cannot select more than Total "+ maxPapLimit +" papers.";	
    				   				
			           showValidationSummary(myElement,ms);
			           return false;						
		            }
		        }			
				return true;				
			}			
</script> 
 <!--------------------------------------------------------------------------------------------------->
    
    <!------------------------------Script for Expand/Collapse------------------------------------------------>
    <script type="text/javascript">

    
    function Hide_UnHide1(obj)
    {
        var node=obj;
	   
        if(node.src.indexOf("plus.gif")!=-1) 
            node.src="../images/minus.gif";
        else 
            node.src="../images/plus.gif";
	    
        while(node.tagName!='TABLE') 
            node=node.parentNode; 
      
        node=node.getElementsByTagName('TABLE')[0];
      
        if(node.style.display=="none")
        {
            node.style.display="block";
            document.getElementById("<%=trNote.ClientID%>").style.display ='block';
        }
        else 
        {
           node.style.display="none" ;
            document.getElementById("<%=trNote.ClientID%>").style.display ='none';
        }       
    }
	
   
   
   </script> 
  <!--------------------------------------------End--------------------------------------------------------->

  <table height="30" cellspacing="0" cellpadding="0" width="710px" border="0">
        <tr height="15">
            <td style="height: 17px;" valign="top" align="left">
               <asp:Label ID="lblPageHead" runat="server"  meta:resourcekey="lblPageNameResource1" Text="Paper Change"></asp:Label>
               &nbsp;<asp:Label id="lblSubHeader" Runat="server" meta:resourcekey="lblwelcomeResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="FormName" valign="middle" align="center" style="height: 11px">
                <font style="font-size: 2pt">&nbsp;</font></td>
        </tr>
         <tr>
            <td align="center">
            <br />
              <!-- Fields Starts-->
							<!-- Fields Starts-->
							
							<div id = "divCourseList" align="center">						
							
							
							<table cellspacing="1" cellpadding="0" width="95%" border="0" align="center">
                            <tr align="left">
                            <td style="height: 24px; width: 25%;" align="left">
                                <b><%= lblCr.Text%> </b></td>
                            <td style="height: 24px; width: 1%;">
                                :</td>
                            <td style="height: 24px" width="50%">
                                <asp:Label ID="lblCourse" runat="server"  ForeColor="#307D7E" meta:resourcekey="lblCourseResource1"></asp:Label>
                                </td>
                            </tr>
                            
                            <tr align="left">
                            <td style="height: 24px; width: 25%;" align="left">
                                <b><%= lblCr.Text%> Part - <%= lblCr.Text%> Part Term </b></td>
                            <td style="height: 24px; width: 1%;">
                                :</td>
                            <td style="height: 24px" width="50%">
                                <asp:Label ID="lblCoursePart" runat="server"  ForeColor="#307D7E" meta:resourcekey="lblCoursePartResource1"></asp:Label>
                                </td>
                            </tr>      
                            
                            <tr align="left">
                            <td style="height: 24px; width: 25%;" align="left">
                                <b>Student Name </b></td>
                            <td style="height: 24px; width: 1%;">
                                :</td>
                            <td style="height: 24px" width="50%">
                                <asp:Label ID="lblStudent" runat="server"  ForeColor="#810541" meta:resourcekey="lblStudentResource1" ></asp:Label>
                                </td>
                            </tr>    
                            
                                   
                            </table>
                          
                           
                            <br />	
                           
							
                                &nbsp;<asp:Panel ID="Panel1" runat="server" Width="93%" BorderColor ="#3399CC" BorderWidth="1px" BackColor="LemonChiffon" meta:resourcekey="Panel1Resource1">
                                <table align="center" width ="100%">
                                <tr style="border-color:Black; border-width:5px">
                                <td width="3%" style="height: 20px" align="left">
                                <img src="../images/plus.gif" alt="Click here to view Papers opted" id="imgDataGrid" onclick="Hide_UnHide1(this)" onmouseover="javascript:this.style.cursor='hand'" />
                               
                                </td >
                                 <td width="1%" style="height: 20px"></td>
                                <td width="100%" align="left" style="height: 20px; font-size:11; font-family:Verdana; color:#C12267;"><asp:Label ID="lblPaperOpted" runat="server" onclick ="Hide_UnHide1(imgDataGrid)" style="cursor:hand;" meta:resourcekey="lblPaperOptedResource1" Text="Paper(s)/Paper Head(s) Previously opted by the Student" Width="100%"></asp:Label></td>
                                </tr>
							 <tr><td colspan="3" style="height: 15px"></td></tr>
							  <tr width="95%" id ="trdataGrid" runat="server" align="center">
							  <td id="Td1" colspan="3" runat="server">
							   <asp:GridView id="dgPaperGroup1" runat="server" width="95%" autogeneratecolumns="False"
	                                      AllowSorting="True"  CssClass="clGrid" style="display:none" 
	                                      OnRowDataBound="dgPaperGroup1_RowDataBound" meta:resourcekey="dgPaperGroup1Resource1" DataKeyNames="pk_PpGrp_ID,Validation_Flag,pk_Pp_ID,pk_PpHead_ID,Confirmed">
	                              <HeaderStyle  HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridHeader" />
	                                <RowStyle CssClass="gridItem"></RowStyle>
	                                    <columns>
	                                    
                                            <asp:BoundField DataField="PpGrp_Desc" HeaderText="Paper Group" meta:resourcekey="BoundFieldResource1">
                                             <HeaderStyle Font-Bold="True"  Width="30%" CssClass="gridHeader" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Paper" HeaderText="Paper(s)/Paper Head(s)" meta:resourcekey="BoundFieldResource2">
                                             <HeaderStyle Font-Bold="True"  Width="70%" CssClass="gridHeader" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                            
                                            </asp:BoundField>
                                            <asp:BoundField DataField="pk_PpGrp_ID" HeaderText="pk_PpGrp_ID" Visible="False" meta:resourcekey="BoundFieldResource3"></asp:BoundField>
                                            <asp:BoundField DataField="Validation_Flag" HeaderText="ValidationFlag" Visible="False" meta:resourcekey="BoundFieldResource4">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="pk_Pp_ID" HeaderText="pk_Pp_ID" Visible="False" meta:resourcekey="BoundFieldResource5"></asp:BoundField>
                                            <asp:BoundField DataField="pk_PpHead_ID" HeaderText="pk_PpHead_ID" Visible="False" meta:resourcekey="BoundFieldResource6">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Confirmed" Visible="False" />
                                           
	                                    </columns>
	                                    <PagerStyle VerticalAlign="Middle"  Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                         </PagerStyle>
                                    </asp:GridView>
							  </td>
							  </tr>
							   <tr id= "trNote" runat="server" style="display:none" align="center">
                                    <td id="Td2" colspan="3" runat="server">
                                    <i><strong>* Note:</strong> <%=lblPaper.Text %>(s) marked in <font color="#E41B17">red</font> are <%=lblPaper.Text %>(s) with 'Discrepancy' which signifies that the <%=lblPaper.Text %>(s) are affiliated by the college but is 'not affiliated' and/or 'denied' by the <%=lblUniversity.Text %>.</i>
                                    </td>
                                </tr>
							   <tr><td colspan="3" height="22" align="center">                                      
                                       <asp:Label ID="lblDataGridMsg" style="display:none" CssClass="errorNote" runat="server" meta:resourcekey="lblDataGridMsgResource1"  />
                                      </td></tr>
                            
						        </table>
							    </asp:Panel>
							
							</div>
							<br />
							
						<div id="divPaperList" runat="server">
							<table width="95%" align="center" border="0">
								<tr>
									<td style="HEIGHT: 14px"><asp:label id="lblMsg" runat="server" font-size="8pt" font-bold="True" font-names="Verdana" meta:resourcekey="lblMsgResource1"></asp:label></td>
								</tr>
								<tr>
									<td style="HEIGHT: 14px" align="right"><asp:label id="lblNote" runat="server" width="100%" height="8px" cssclass="errorNote" meta:resourcekey="lblNoteResource1"></asp:label></td>
								</tr>
								<tr>
									<td class="paperDisplay" id="tdPapers" runat="server" align="left"><asp:xml id="Xml1" runat="server"></asp:xml></td>
								</tr>
								
								<tr>
                                <td class="BorderTB" align="center" style="height: 22px">
                                 <asp:Button ID="btnSave" runat="server" Font-Bold="False" CssClass="butSubmit"
                                        Text="Save" Width="180px" OnClick="btnSave_Click" OnClientClick="return fnValidate();" meta:resourcekey="btnSaveResource1"/> &nbsp;
                                    <asp:Button ID="btnBackToStudent" runat="server" Font-Bold="False" CssClass="butSubmit"
                                        Text="<< Back To Student List" Width="250px" OnClick="btnBackToStudent_Click" meta:resourcekey="btnBackToStudentResource1"/>
                                   </td>
                                   
                            </tr>
         
                                <tr>
								<td>
								<br />
                                   <strong><i>Note:</i></strong> <i><font color="#E41B17">
                                   The student will be available for further processing only after the duration of 4 Hrs. of the decision taken on discrepant <%=lblPaper.Text.ToLower() %>(s) of the student.
                                   </font> </i>                                 
                                   
								</td>							
								</tr>
							</table>
						</div>
						
								
							<!-- Fields Ends-->








 <input id="hidUniID" style="width: 32px; height: 22px" type="hidden" size="1" name="hidUniID" runat="server"/>
			
			<input id="hidInstID" runat="server" name="hidInstID" size="1" type="hidden" />   
			<input id="hidInstName" runat="server" name="hidInstID" size="1" type="hidden" />  
			<input id="hidFacID" runat="server" name="hidFacID" size="1" type="hidden" />
            <input id="hidCrID" runat="server" name="hidCrID" size="1" type="hidden" />
            <input id="hidMoLrnID" runat="server" name="hidMoLrnID" size="1" type="hidden" />
            <input id="hidPtrnID" runat="server" name="hidPtrnID" size="1" type="hidden" />
            <input id="hidBrnID" runat="server" name="hidBrnID" size="1" type="hidden" /> 
            <input id="hidCrPrDetailsID" runat="server" name="hidCrPrDetailsID" size="1" type="hidden" />
            <input id="hidCrPrChID" runat="server" name="hidCrPrChID" size="1" type="hidden" />
            <input id="hidCrPrSeq" runat="server" name="hidCrPrSeq" size="1" type="hidden" />
            <input id="hidCrPrChSeq" runat="server" name="hidCrPrChSeq" size="1" type="hidden" />
            <input id="hidCrPartName" runat="server" name="hidCrPartName" size="1" type="hidden" />
            <input id="hidCrName" runat="server" name="hidCrName" size="1" type="hidden" /> 
            <input id="hidStudentID" runat="server" name="hidStudentID" size="1" type="hidden" /> 
             <input id="hidStudentName" runat="server" name="hidStudentName" size="1" type="hidden" /> 
             <input id="hidStudentYear" runat="server" name="hidStudentYear" size="1" type="hidden" /> 
            <input id="hidOldPpList" type="hidden" name="hidOldPpList" size="1" runat="server"/>
            <input id="hid_SelectedPapers" type="hidden" name="hid_SelectedPapers" size="1" runat="server"/>
            <input id="MaxPaperLimit" type="hidden" name="MaxPaperLimit" size="1" runat="server"/> 
             <input id="hidAcademicYear" runat="server" name="hidAcademicYear" size="1" type="hidden" /> 
              <input id="hidPpList" type="hidden" name="hidPpList" size="1" runat="server"/>
	        <asp:Label ID="lblCr" runat="server" Text="Course" style="display:none"  meta:resourcekey="lblCrResource1"></asp:Label>
            <asp:Label ID="lblPaper" runat="server" Text="Paper" Style="display: none" meta:resourcekey="lblPaperResource1"  ></asp:Label> 
              <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none" meta:resourcekey="lblUniversityResource1"  ></asp:Label> 
              
              <input type="hidden" runat="server" id="MinPaperLimit" value="0"/> 
            
            </td>
         </tr>
        <tr>
                <td valign="top" align="left" width="100%" style="height: 20px">                  
                </td>
               
         </tr>
         </table>
         
      
</asp:Content>

