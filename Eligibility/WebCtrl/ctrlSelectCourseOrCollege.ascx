<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ctrlSelectCourseOrCollege.ascx.cs"
    Inherits="StudentRegistration.Eligibility.WebCtrl.WebUserControl1" %>

<script language="javascript" type="text/javascript">

         var hidFacClientID = '<%=hidFacID.ClientID%>';
		 var hidCrClientID = '<%=hidCrID.ClientID%>';
		 var hidMoLrnClientID = '<%=hidMoLrnID.ClientID%>';
		 var hidPtrnClientID = '<%=hidPtrnID.ClientID%>';
		 var hidBrnClientID = '<%=hidBrnID.ClientID%>';	
		 var hidCrPrDetailsIDClientID = '<%=hidCrPrDetailsID.ClientID%>';	
		 var hidCrPrChIDClientID = '<%=hidCrPrChID.ClientID%>';	
		  	  
		 var hidUniClientID = '<%=hidUniID.ClientID%>';
		 
		 var ddlFacDescClient = '<%=ddlFacDesc.ClientID%>';
		 var ddlCrDescClient = '<%=ddlCrDesc.ClientID%>';
		 var ddlModeLrnDescClient = '<%=ddlModeLrnDesc.ClientID%>';
		 var ddlCrPtrnDescClient = '<%=ddlCrPtrnDesc.ClientID%>';
		 var ddlCrBrnDescClient = '<%=ddlCrBrnDesc.ClientID%>';
		 var ddlCrPrDetailsDescClient = '<%=ddlCrPrDetailsDesc.ClientID%>';
		 var ddlCrPrChDescClient = '<%=ddlCrPrChDesc.ClientID%>';
		 var hidLevelFlagClient = '<%=hidLevelFlag.ClientID%>';
		 var hidCourseDetailsClientID = '<%=hidCourseDetails.ClientID%>';		 
       
    function fnClearSearchCriteria()
			{					
				document.getElementById('<%= ddlFacDesc.ClientID%>').value = "-1";
				document.getElementById('<%= ddlCrDesc.ClientID%>').value = "-1";
				document.getElementById('<%= ddlModeLrnDesc.ClientID%>').value = "-1";
				document.getElementById('<%= ddlCrPtrnDesc.ClientID%>').value = "-1";
				document.getElementById('<%= ddlCrBrnDesc.ClientID%>').value = "-1";
				document.getElementById('<%=ddlCrPrChDesc.ClientID%>').value = '-1';	
				document.getElementById('<%=ddlCrPrDetailsDesc.ClientID%>').value = '-1';	
								
			}
			
			    function setValue(Text,Value)
		        {
        		
			        var text = eval(document.getElementById(Text));
			        text.value = Value;	
        			
		        } 
		
		    function setCrPart(val)
            { 
	           
	            document.getElementById(hidCrPrDetailsIDClientID).value = val;
	            //alert(document.getElementById(hidCrPrDetailsIDClientID).value);
	            //document.getElementById('ctl00_ContentPlaceHolder1_hidCrPrID').value = val;
	            
            }
		
		
        function FetchFacultyWiseCourseList(location, UniID, FacID, HtmlSelCrID, LevelFlag)
        {	
      
       	        sTableCellID = location;
       	        clsAjaxMethods.FetchFacultyWiseLaunchedCourseList(UniID, FacID, HtmlSelCrID, LevelFlag, BindDataToCombo_CallBack);
        }
        // To Get Coursewise Mode Of Learning List(Launched).....Developed by Amit
        function FetchCourseWiseLaunchedModeOfLearningList(location, UniID, FacID, CrID, HtmlSelMoLrnID, LevelFlag)
        { 		
		        sTableCellID=location;
		        clsAjaxMethods.FetchCourseWiseLaunchedModeOfLearningList(UniID, FacID, CrID, HtmlSelMoLrnID, LevelFlag, BindDataToCombo_CallBack);
		     
        }
        // To Get Course Mode Of Learning Wise Course Pattern List(Launched).....Developed By Madhu
        function FetchCourseMoLrnwiseLaunchedCoursePatternsList(location, UniID, FacID, CrID, MoLrnID, HtmlSelCrPtrnID, LevelFlag)
        {
                
		        sTableCellID=location;
		        clsAjaxMethods.FetchCourseMoLrnwiseLaunchedCoursePatternsList(UniID, FacID, CrID, MoLrnID, HtmlSelCrPtrnID, LevelFlag, BindDataToCombo_CallBack);	
        }

        // To Get Course Mode Of Learning Pattern Wise Branch List(Launched).....Developed By Madhu
        function FetchCourseMoLrnPtrnWiseLaunchedBranchList(location, UniID, FacID, CrID, MoLrnID, PtrnID, HtmlSelCrBrnID, LevelFlag)
        {
        
        
        //alert(location + UniID + FacID + CrID + MoLrnID + PtrnID + HtmlSelCrBrnID + LevelFlag);
                sTableCellID=location;
		        clsAjaxMethods.FetchCourseMoLrnPtrnWiseLaunchedBranchList(UniID, FacID, CrID, MoLrnID, PtrnID, HtmlSelCrBrnID, LevelFlag, BindDataToCombo_CallBack);	
        }
        function FetchCourseWiseCoursePartList(location, UniID, FacID, CrID, MoLrnID, PtrnID, BrnID, HtmlSelCrBrnID, LevelFlag)
         {
       
        //alert(location + UniID + FacID + CrID + MoLrnID + PtrnID + HtmlSelCrBrnID + LevelFlag);
                sTableCellID=location;
		        clsAjaxMethods.FetchCourseWiseCoursePartList(UniID, FacID, CrID, MoLrnID, PtrnID,BrnID, HtmlSelCrBrnID, LevelFlag, BindDataToCombo_CallBack);	
        }
        
        function FetchCourseMoLrnPtrnBrnWiseLaunchedCoursePartList(location, UniID, FacID, CrID, MoLrnID, PtrnID, BrnID, HtmlSelCrPrID, LevelFlag)
         {
        
        //alert(location + UniID + FacID + CrID + MoLrnID + PtrnID + HtmlSelCrBrnID + LevelFlag);
                sTableCellID=location;
		        clsAjaxMethods.FetchCourseMoLrnPtrnBrnWiseLaunchedCoursePartList(UniID, FacID, CrID, MoLrnID, PtrnID, BrnID, HtmlSelCrPrID, LevelFlag, BindDataToCombo_CallBack);	
        }

        function FetchCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrChList(location, UniID, CrPrDetailsID, HtmlSelCrPrChID, LevelFlag)
        {       
                
                sTableCellID = location;
                clsAjaxMethods.FetchCourseMoLrnPtrnBrnCrPrWiseLaunchedCrPrChList(UniID, CrPrDetailsID, HtmlSelCrPrChID, LevelFlag, BindDataToCombo_CallBack);
        }
        
       
   function ClearDropDowns(FromLevel, LevelFlag)
        {          
           switch (FromLevel)
	        { 
		        case 1:
		        
		                if(LevelFlag >= 2)
				        {
					       ClearDropDownList(document.getElementById('<%=ddlCrDesc.ClientID%>'));
					      
					       
				        }
		        case 2:
				        if(LevelFlag >= 3)
				        {
				             ClearDropDownList(document.getElementById('<%=ddlModeLrnDesc.ClientID%>'));
					        
				        }
		        case 3:
				        if(LevelFlag >= 4)
				        {
					        ClearDropDownList(document.getElementById('<%=ddlCrPtrnDesc.ClientID%>'));
					      
				        }
		        case 4:
				        if(LevelFlag >= 5)
				        {
					        ClearDropDownList(document.getElementById('<%=ddlCrBrnDesc.ClientID%>'));
					       
					        
				        }
				        
			   case 5:
				        if(LevelFlag >= 6)
				        {
					        ClearDropDownList(document.getElementById('<%=ddlCrPrDetailsDesc.ClientID%>'));
					       
					        
				        }
			    case 6:
				        if(LevelFlag >= 7)
				        {
					        ClearDropDownList(document.getElementById('<%=ddlCrPrChDesc.ClientID%>'));
					       
					        
				        }
			     
	                   				
	   	        }
            
        }
	    	
        function ClearDropDownList(ddlObject)
        { 
            
	        while(ddlObject.length > 1)
	        {        	  
		        ddlObject.remove(1);
		        
	        }
	        
        }
        
                
        //var sTableCellID;  
        //To get the dropdown which is not mandatory
        function  BindDataToCombo_CallBack(response)
		{
		
			if(response.error == null)
			{		
				document.getElementById(sTableCellID).innerHTML = response.value +"&nbsp;<FONT class='Mandatory'>*</FONT>";
			}			
		}
</script>

<div id="divAcademicYr" runat="server" style="azimuth: center; margin-left: 30PX;
    width: 90%;">
    &nbsp;&nbsp
    <div id="tblAcademicYr" runat="server" style="height: 50px;" align="center">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td style="height: 20px;" colspan="3">
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 20px; width: 125px;">
                    <asp:Label ID="lblAcyr" runat="server" Font-Bold="True" Width="221px" meta:resourcekey="lblAcyrResource1"
                        Text="Select Academic Year"></asp:Label></td>
                <td align="center" style="height: 20px; width: 1%;">
                    <b>&nbsp;:&nbsp;</b></td>
                <td align="left" id="tdAcdYr" runat="server" style="height: 20px">
                    <asp:DropDownList ID="ddlAcademicYr" runat="server" CssClass="selectbox" Width="245px"
                        meta:resourcekey="ddlAcademicYrResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                    </asp:DropDownList><font class="Mandatory">*</font></td>
            </tr>
        </table>
    </div>
</div>
<div id="fldAllInst" runat="server" style="azimuth: center; margin-left: 30PX; width: 90%;"
    align="center">
    <table cellspacing="0" cellpadding="0" align="center" border="0" width="100%">
        <tr>
            <td align="right" style="height: 20px; width: 105px;">
                <asp:Label ID="lblViewRptFor" runat="server" Font-Bold="True" Width="221px" Text="View Uploaded Statistics Report for"></asp:Label>
            </td>
            <td align="center" style="height: 20px; width: 1%;">
                <b>&nbsp;:&nbsp;</b></td>
            <td align="left">
                <asp:RadioButton ID="rdAllColleges" Text=" All Colleges" Checked="True" GroupName="grpColleges"
                    runat="server" align="left" onclick="showAllOrSelectCollegeDiv()" />
                <asp:RadioButton ID="rdSelectedColleges" Text="Selected College" GroupName="grpColleges"
                    runat="server" onclick="showAllOrSelectCollegeDiv()" />
            </td>
        </tr>
    </table>
</div>
<table id="divCourse" runat="server" style="azimuth: center; margin-left: 30PX; width: 90%;">
    <tr>
        <td colspan="3">
        </td>
    </tr>
    <tr>
        <td>
            <div id="tblCourse" runat="server" style="azimuth: center;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td align="right" style="height: 20px; width: 125px;">
                            <b>
                                <asp:Label ID="lblFacultyNm" runat="server" Text="Select Faculty Name" Width="221px"
                                    meta:resourcekey="lblFacultyNmResource1"></asp:Label></b></td>
                        <td align="center" style="height: 20px; width: 1%;">
                            <b>&nbsp;:&nbsp;</b></td>
                        <td style="height: 20px" colspan="3" align="left">
                            <asp:DropDownList ID="ddlFacDesc" runat="server" onchange="setValue(document.getElementById(hidFacClientID).id,this.value);FetchFacultyWiseCourseList('tdCrDesc',document.getElementById(hidUniClientID).value,document.getElementById(hidFacClientID).value,document.getElementById(ddlCrDescClient).id, document.getElementById(hidLevelFlagClient).value);ClearDropDowns(1,document.getElementById(hidLevelFlagClient).value);"
                                CssClass="selectbox" meta:resourcekey="ddlFacDescResource1" Width="245px">
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
                            <asp:DropDownList ID="ddlCrDesc" runat="server" CssClass="selectbox" meta:resourcekey="ddlCrDescResource1">
                                <asp:ListItem Value="-1" meta:resourcekey="ListItemResource3" Text="--- Select ---"></asp:ListItem>
                            </asp:DropDownList><font class="Mandatory">*</font>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <b>Select Mode of Learning</b></td>
                        <td align="center">
                            <b>:</b></td>
                        <td id="tdModeLrnDesc" colspan="3" align="left">
                            <asp:DropDownList ID="ddlModeLrnDesc" runat="server" CssClass="selectbox" meta:resourcekey="ddlModeLrnDescResource1">
                                <asp:ListItem Value="-1" meta:resourcekey="ListItemResource4" Text="--- Select ---"></asp:ListItem>
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
                                <asp:Label ID="lblSelectCrPtrn" runat="server" Text="Select Course Pattern" meta:resourcekey="lblSelectCrPtrnResource1"></asp:Label></b></td>
                        <td align="center">
                            <b>:</b></td>
                        <td id="tdCrPtrnDesc" colspan="3" align="left">
                            <asp:DropDownList ID="ddlCrPtrnDesc" runat="server" CssClass="selectbox" meta:resourcekey="ddlCrPtrnDescResource1">
                                <asp:ListItem Value="-1" meta:resourcekey="ListItemResource5" Text="--- Select ---"></asp:ListItem>
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
                            <asp:DropDownList ID="ddlCrBrnDesc" runat="server" CssClass="selectbox" meta:resourcekey="ddlCrBrnDescResource1">
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
                                <asp:Label ID="Label1" runat="server" Text="Select Course Part" meta:resourcekey="Label1Resource1"></asp:Label></b></td>
                        <td align="center">
                            <b>:</b></td>
                        <td id="tdCrPrDesc" colspan="3" align="left">
                            <asp:DropDownList ID="ddlCrPrDetailsDesc" runat="server" CssClass="selectbox" meta:resourcekey="ddlCrPrDetailsDescResource1">
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
                                <asp:Label ID="Label2" runat="server" Text="Select Course Part Term" meta:resourcekey="Label2Resource1"></asp:Label></b></td>
                        <td align="center" style="width: 1%">
                            <b>:</b></td>
                        <td id="tdCrPrChDesc" colspan="3" align="left">
                            <asp:DropDownList ID="ddlCrPrChDesc" runat="server" CssClass="selectbox" meta:resourcekey="ddlCrPrChDescResource1">
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
        <br />
        <table cellpadding="0" cellspacing="0" border="0" style="azimuth: center;" width="100%">
            <tr>
                <td align="right" style="height: 38px; width: 26%;">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Select College"></asp:Label></td>
                <td align="center" style="height: 38px; width: 1%;">
                    <b>&nbsp;:&nbsp; </b>
                </td>
                <td align="left" style="height: 38px">
                    <asp:TextBox ID="Collcode" runat="server" onclick="this.value='';" CssClass="inputbox"
                        Width="40px" MaxLength="300" meta:resourcekey="CollcodeResource1" onkeydown="return allowTab(this, event)"></asp:TextBox>
                </td>
                <td width="79%" align="left" style="height: 38px">
                    <asp:DropDownList ID="ddlCollegeName" runat="server" Width="200px" CssClass="inputbox"
                        onchange="fillCollegeCode(this.value);">
                    </asp:DropDownList>
                </td>
                <td style="height: 38px">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <br />
                </td>
            </tr>
        </table>
    </div>
</center>
<input id="hidUniID" type="hidden" name="hidUniID" runat="server" />
<input id="hidLevelFlag" type="hidden" name="hidLevelFlag" runat="server" />
<input id="hidFacID" runat="server" name="hidFacID" style="width: 32px; height: 22px"
    type="hidden" />
<input id="hidFacText" runat="server" name="hidFacText" style="width: 32px; height: 22px"
    type="hidden" />
<input id="hidCrID" runat="server" name="hidCrID" style="width: 32px; height: 22px"
    type="hidden" />
<input id="hidMoLrnID" runat="server" name="hidMoLrnID" style="width: 32px; height: 22px"
    type="hidden" />
<input id="hidPtrnID" runat="server" name="hidPtrnID" style="width: 32px; height: 22px"
    type="hidden" />
<input id="hidBrnID" runat="server" name="hidBrnID" style="width: 32px; height: 22px"
    type="hidden" />
<input id="hidCrPrDetailsID" runat="server" name="hidCrPrDetailsID" style="width: 32px;
    height: 22px" type="hidden" />
<input id="hidCrPrChID" runat="server" name="hidCrPrChID" style="width: 32px; height: 22px"
    type="hidden" />
<input id="hidCourseDetails" runat="server" name="hidCourseDetails" style="width: 32px;
    height: 22px" type="hidden" />
