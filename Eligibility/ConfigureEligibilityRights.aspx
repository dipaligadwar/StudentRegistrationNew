<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ConfigureEligibilityRights.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ConfigureEligibilityRights" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/jsAjaxMethod.js"></script>

    <script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>

    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>

    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>

    <script language="javascript" type="text/javascript">

    
		 var hidFacClientID = '<%=hidFacID.ClientID%>';
		 var hidCrClientID = '<%=hidCrID.ClientID%>';
		 var hidMoLrnClientID = '<%=hidMoLrnID.ClientID%>';
		 var hidPtrnClientID = '<%=hidPtrnID.ClientID%>';
		 var hidBrnClientID = '<%=hidBrnID.ClientID%>';		 
		 var hidUniClientID = '<%=hidUniID.ClientID%>';			 
		 var hidLevelClientFlag = '<%=hidLevelFlag.ClientID%>';
		 var ddlFacDescClient = '<%=ddlFacDesc.ClientID%>';
		 var ddlCrDescClient = '<%=ddlCrDesc.ClientID%>';
		 var ddlModeLrnDescClient = '<%=ddlModeLrnDesc.ClientID%>';
		 var ddlCrPtrnDescClient = '<%=ddlCrPtrnDesc.ClientID%>';
		 var ddlCrBrnDescClient = '<%=ddlCrBrnDesc.ClientID%>';
		 
		function fnSaveValidate()
		{
		   					
		    var i=-1;
			var myArr= new Array();	
			var ret = true;	
			if(document.getElementById('ctl00_ContentPlaceHolder1_chkCourse_0').checked == true ||document.getElementById('ctl00_ContentPlaceHolder1_chkCourse_1').checked == true && (document.getElementById('ctl00_ContentPlaceHolder1_hidEditAdd').value == "0"))			
			{
				
				    if(document.getElementById('ctl00_ContentPlaceHolder1_chkCourse_1').checked == true)
			        {			
			           
			            myArr[++i]= new Array(document.getElementById('<%=ddlFacDesc.ClientID%>'),-1,"Please Select "+document.getElementById('ctl00_ContentPlaceHolder1_lblFac').innerText,"select");			            
			            myArr[++i]= new Array(document.getElementById('<%=ddlCrDesc.ClientID%>'),-1,"Please Select "+document.getElementById('ctl00_ContentPlaceHolder1_lblCr').innerText,"select");			          
			            myArr[++i]= new Array(document.getElementById('<%=ddlModeLrnDesc.ClientID%>'),-1,"Please Select Mode Of Learning","select");
           	            myArr[++i]= new Array(document.getElementById('<%=ddlCrPtrnDesc.ClientID%>'),-1,"Please Select "+document.getElementById('ctl00_ContentPlaceHolder1_lblCr').innerText+" Pattern","select");
           	            //myArr[++i]  = new Array("rbYes|rbNo","","Please mention whether you want to proceed Branch Wise or Not","CheckSelected");
           	           
		                /*if(document.getElementById("rbYes").checked == true)
		                {
		                    myArr[++i]= new Array(document.getElementById("ddlCrBrnDesc"),-1,"Please Select Branch","select");
		                }*/
		                
		                if(document.getElementById('<%=ddlCrBrnDesc.ClientID%>')[document.getElementById('<%=ddlCrBrnDesc.ClientID%>').selectedIndex].text != "--- No Branch ---")
                            myArr[++i]= new Array(document.getElementById('<%=ddlCrBrnDesc.ClientID%>'),-1,"Please Select Branch","select");
                        else
                            document.getElementById('ctl00_ContentPlaceHolder1_hidBrnID').value = "0";
			       	     var ret = validateMe(myArr,50);
			       	   
			       	     if(!ret)
			       	     {
			       	     return false;   
			       	     }
			        } 
			        
	                 if(document.getElementById('ctl00_ContentPlaceHolder1_rdConfigureRights_0').checked == true || document.getElementById('ctl00_ContentPlaceHolder1_rdConfigureRights_1').checked == true && (document.getElementById('ctl00_ContentPlaceHolder1_hidEditAdd').value == "0"))
                     {
                        ret = true;
                     }
                     else if(document.getElementById('ctl00_ContentPlaceHolder1_hidEditAdd').value == "0")
                     {
                         alert("Please Select "+document.getElementById('<%=lblCollege.ClientID%>').innerText+" or "+document.getElementById('<%=lblUniversity.ClientID%>').innerText+"");
                         ret = false;
                     }
			          
						
			}										
			else if(document.getElementById('ctl00_ContentPlaceHolder1_hidEditAdd').value == "0")
			{
			   if(document.getElementById('ctl00_ContentPlaceHolder1_rdConfigureRights_0').checked == true || document.getElementById('ctl00_ContentPlaceHolder1_rdConfigureRights_1').checked == true)
				{
				alert("Please Select "+document.getElementById('ctl00_ContentPlaceHolder1_lblCr').innerText+"");
				ret = false;
				}
				else 
				{
			    alert("Correct the following errors \n 1.Select Eligibility rights For "+document.getElementById('ctl00_ContentPlaceHolder1_lblCr').innerText+"(s) \n 2.Select rights to "+document.getElementById('<%=lblCollege.ClientID%>').innerText+" or "+document.getElementById('<%=lblUniversity.ClientID%>').innerText+" ");			 		   
			    ret = false;
			    }
			}
		
			return ret;	
		
		}	   
	    function fnDisplayCourse()
	    {
	             
	             if(document.getElementById('ctl00_ContentPlaceHolder1_hidEditAdd').value == "1")
	                document.getElementById('ctl00_ContentPlaceHolder1_tblSelectCr').style.display = "none";
	             else
	             {
	                document.getElementById('ctl00_ContentPlaceHolder1_tblSelectCr').style.display = "inline";
	                document.getElementById('ctl00_ContentPlaceHolder1_lblNote').innerText = "";
	                document.getElementById('ctl00_ContentPlaceHolder1_tblSelectCr2').style.display = "none";   
	                document.getElementById('<%=ddlFacDesc.ClientID%>').selectedIndex = 0;
	                document.getElementById('<%=ddlCrDesc.ClientID%>').selectedIndex = 0;
	                document.getElementById('<%=ddlModeLrnDesc.ClientID%>').selectedIndex = 0;	              
	                document.getElementById('<%=ddlCrPtrnDesc.ClientID%>').selectedIndex = 0;	               
	                document.getElementById('<%=ddlCrBrnDesc.ClientID%>').selectedIndex = 0;		     		         		        	    		          
	             }
	    }
	     function fnHideCourse()
	    {
	                    
	                    document.getElementById('ctl00_ContentPlaceHolder1_lblNote').innerText = "";
	    		        document.getElementById('ctl00_ContentPlaceHolder1_tblSelectCr').style.display = "none";	
	    		        document.getElementById('ctl00_ContentPlaceHolder1_tblSelectCr2').style.display = "none";
	    		        document.getElementById('ctl00_ContentPlaceHolder1_hidEditAdd').value = "0";	    		      
	    		             		         		        	    		          
	    }
	    
		
	   function setValue(Text,Value)
		{
			var text = eval(document.getElementById(Text));
			text.value = Value;
			
			
		} 
		
			
        function FetchFacultyWiseCourseList(location, UniID, FacID, HtmlSelCrID, LevelFlag)
        {	
      
       	        sTableCellID=location;
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
                sTableCellID=location;
		        clsAjaxMethods.FetchCourseMoLrnPtrnWiseLaunchedBranchList(UniID, FacID, CrID, MoLrnID, PtrnID, HtmlSelCrBrnID, LevelFlag, BindDataToCombo_CallBack);	
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
				        
	   	  }
            
        }
	    	// To Clear Drop Down List (Filter List).....Developed By Madhu & Farhat
        function ClearDropDownList(ddlObject)
        { 
            
            while(ddlObject.length > 1)
	        {
        	      ddlObject.remove(1);
        	      
	        }
	     
        }
        
                
         var sTableCellID; 
        //To get the dropdown which is not mandatory
        function  BindDataToCombo_CallBack(response)
		{     
		    
			if(response.error == null)
			{		
				document.getElementById(sTableCellID).innerHTML = response.value + "&nbsp;<FONT class='Mandatory'>*</FONT>";
				
			}			
		}


    </script>

    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="0">
            <tr>
                <td class="FormName" align="left" valign="middle">
                    <asp:Label ID="lblPageHead" runat="server" Width="99%" Font-Bold="True" CssClass="lblPageHead"
                        Text="Configure Eligibility Rights" meta:resourcekey="lblPageHeadResource1"></asp:Label></td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="4" align="right" height="10px">
                                <asp:Label ID="lblNote" runat="server" Font-Bold="True" CssClass="saveNote" meta:resourcekey="lblNoteResource1"></asp:Label></td>
                        </tr>
                        <tr id="trAssElgRightsFor" runat="server">
                            <td width="30%" align="right">
                                Assign Eligibility Rights for</td>
                            <td width="1%" align="center">
                                <b>:</b></td>
                            <td>
                                <asp:RadioButtonList ID="chkCourse" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                    meta:resourcekey="chkCourseResource1">
                                    <asp:ListItem Value="0" Text="All Courses" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Select Course" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                </asp:RadioButtonList><font class="Mandatory">*</font></td>
                        </tr>
                        <tr height="10px">
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr style="display: none" id="tblSelectCr" runat="server">
                            <td colspan="4">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td align="right" width="30%">
                                            <asp:Label ID="lblFacultyNm" runat="server" Text="Faculty Name" meta:resourcekey="lblFacultyNmResource1"></asp:Label></td>
                                        <td width="1%" align="center">
                                            <b>:</b></td>
                                        <td width="69%" colspan="2">
                                            <asp:DropDownList ID="ddlFacDesc" runat="server" onchange="setValue(document.getElementById(hidFacClientID).id,this.value);FetchFacultyWiseCourseList('tdCrDesc',document.getElementById(hidUniClientID).value,document.getElementById(hidFacClientID).value, ddlCrDescClient, document.getElementById(hidLevelClientFlag).value);ClearDropDowns(1,document.getElementById(hidLevelClientFlag).value);"
                                                meta:resourcekey="ddlFacDescResource1">
                                                <asp:ListItem Value="-1" meta:resourcekey="ListItemResource3">--- Select ---</asp:ListItem>
                                            </asp:DropDownList><font class="Mandatory">*</font>
                                        </td>
                                    </tr>
                                    <tr height="10px">
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%">
                                            <asp:Label ID="lblSelectCrNm" runat="server" Text="Select Course Name" meta:resourcekey="lblSelectCrNmResource1"></asp:Label></td>
                                        <td width="1%" align="center">
                                            <b>:</b></td>
                                        <td width="69%" id="tdCrDesc" colspan="2">
                                            <asp:DropDownList ID="ddlCrDesc" runat="server" meta:resourcekey="ddlCrDescResource1">
                                                <asp:ListItem Value="-1" meta:resourcekey="ListItemResource4">--- Select ---</asp:ListItem>
                                            </asp:DropDownList><font class="Mandatory">*</font>
                                        </td>
                                    </tr>
                                    <tr height="10px">
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%">
                                            Select Mode of Learning</td>
                                        <td width="1%" align="center">
                                            <b>:</b></td>
                                        <td width="69%" id="tdModeLrnDesc" colspan="2">
                                            <asp:DropDownList ID="ddlModeLrnDesc" runat="server" meta:resourcekey="ddlModeLrnDescResource1">
                                                <asp:ListItem Value="-1" meta:resourcekey="ListItemResource5">--- Select ---</asp:ListItem>
                                            </asp:DropDownList><font color="#ff0000">*</font>
                                        </td>
                                    </tr>
                                    <tr height="10px">
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%">
                                            <asp:Label ID="lblSlCrPattern" runat="server" Text="Select Course Pattern" meta:resourcekey="lblSlCrPatternResource1"></asp:Label></td>
                                        <td width="1%" align="center">
                                            <b>:</b></td>
                                        <td width="29%" id="tdCrPtrnDesc" colspan="2">
                                            <asp:DropDownList ID="ddlCrPtrnDesc" runat="server" meta:resourcekey="ddlCrPtrnDescResource1">
                                                <asp:ListItem Value="-1" meta:resourcekey="ListItemResource6">--- Select ---</asp:ListItem>
                                            </asp:DropDownList><font class="Mandatory">*</font>
                                        </td>
                                        <td width="30%">
                                        </td>
                                    </tr>
                                    <tr height="10px">
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 24px; text-align: right; width: 30%">
                                            <asp:Label ID="lblSlCrBranch" runat="server" Text="Select Course Branch" meta:resourcekey="lblSlCrBranchResource1"></asp:Label></td>
                                        <td width="1%" align="center">
                                            <b>:</b></td>
                                        <td id="tdCrBrnDesc" style="height: 24px" width="29%" colspan="2">
                                            <asp:DropDownList ID="ddlCrBrnDesc" runat="server" meta:resourcekey="ddlCrBrnDescResource1">
                                                <asp:ListItem Value="-1" meta:resourcekey="ListItemResource7">--- Select ---</asp:ListItem>
                                            </asp:DropDownList><font class="Mandatory">*</font>
                                        </td>
                                        <td style="height: 24px; width: 30%">
                                            <!--/FONT-->
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="display: none" id="tblSelectCr2" runat="server">
                            <td colspan="4">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr height="5%">
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%">
                                            <asp:Label ID="lblFacultyName" runat="server" Text="Faculty Name" meta:resourcekey="lblFacultyNameResource1"></asp:Label></td>
                                        <td align="center" style="width: 1%">
                                            <b>:</b></td>
                                        <td width="69%" colspan="2">
                                            <asp:Label ID="lblFacName" runat="server" meta:resourcekey="lblFacNameResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr height="10%">
                                        <td colspan="4">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%">
                                            <asp:Label ID="lblCourseName" Text="Course Name" runat="server" meta:resourcekey="lblCourseNameResource1"></asp:Label></td>
                                        <td align="center" style="width: 1%">
                                            <b>:</b></td>
                                        <td width="69%" id="td1" colspan="2">
                                            <asp:Label ID="lblCrName" runat="server" meta:resourcekey="lblCrNameResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr height="10%">
                                        <td colspan="4">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%">
                                            Mode of Learning</td>
                                        <td align="center" style="width: 1%">
                                            <b>:</b></td>
                                        <td width="69%" id="td2" colspan="2">
                                            <asp:Label ID="lblMoLrnName" runat="server" meta:resourcekey="lblMoLrnNameResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr height="10%">
                                        <td colspan="4">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%">
                                            <asp:Label ID="lblCoursePattern" runat="server" Text="Course Pattern" meta:resourcekey="lblCoursePatternResource1"></asp:Label></td>
                                        <td align="center" style="width: 1%">
                                            <b>:</b></td>
                                        <td width="29%" id="td3" colspan="2">
                                            <asp:Label ID="lblPtrnName" runat="server" meta:resourcekey="lblPtrnNameResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                        </td>
                                    </tr>
                                    <tr height="10%">
                                        <td colspan="4" style="height: 10%">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr id="trCrBranch" style="display: none" runat="server">
                                        <td style="height: 24px; text-align: right; width: 30%">
                                            <asp:Label ID="lblCourseBranch" runat="server" Text="Course Branch" meta:resourcekey="lblCourseBranchResource1"></asp:Label></td>
                                        <td style="height: 24px; width: 1%">
                                            &nbsp; <b>:</b></td>
                                        <td id="td5" style="height: 24px" width="29%" colspan="2">
                                            <asp:Label ID="lblBranchName" runat="server" meta:resourcekey="lblBranchNameResource1"></asp:Label>
                                        </td>
                                        <td style="height: 24px; width: 30%">
                                            <!--/FONT-->
                                        </td>
                                    </tr>
                                    <tr height="10px">
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                </table>
                                <!--Normal Table-->
                                <table>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right">
                                Assign Eligibility Rights to</td>
                            <td width="1%" align="center">
                                <b>:</b></td>
                            <td>
                                <asp:RadioButtonList ID="rdConfigureRights" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow" meta:resourcekey="rdConfigureRightsResource1">
                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource8">University</asp:ListItem>
                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource9">College</asp:ListItem>
                                </asp:RadioButtonList><font class="Mandatory">*</font>
                            </td>
                        </tr>
                        <tr>
                            <td height="10px" colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" valign="middle">
                                <asp:Button ID="btnProcess" Text="Assign Rights" runat="server" CssClass="butSubmit"
                                    OnClick="btnProcess_Click" meta:resourcekey="btnProcessResource1" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="30%">
                                <p align="left">
                                    <strong><i>Note:</i></strong> <font class="Mandatory">*</font> marked are mandatory...
                                </p>
                            </td>
                            <td width="1%">
                            </td>
                            <td width="69%" colspan="2">
                            </td>
                        </tr>
                        <tr id="trlblCourse" style="display: inline" runat="server">
                            <td align="left" colspan="4" width="99%">
                                <p style="margin-top: 10px; margin-bottom: 1px; margin-left: 0px" align="left">
                                    <asp:Label ID="lblCrNote" runat="server" class="clSubHeading" meta:resourcekey="lblCrNoteResource1"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <div id="divDGCourseRights" runat="server" style="display: block">
                                    <asp:GridView CssClass="clGrid grid-view" ID="DGCourseRights1" runat="server" Width="99%" BorderStyle="Solid"
                                        AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699" AllowPaging="True"
                                        AllowSorting="True" OnPageIndexChanging="DGCourseRights1_PageIndexChanging" OnRowDataBound="DGCourseRights1_RowDataBound"
                                        OnSorting="DGCourseRights1_Sorting" meta:resourcekey="DGCourseRights1Resource1"
                                        OnRowEditing="DGCourseRights1_RowEditing">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                                <ItemTemplate>
                                                    <%# (Container.DataItemIndex)+1 %>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="pk_Fac_ID" HeaderText="pk_Fac_ID" meta:resourcekey="BoundFieldResource1">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Fac_Desc" ReadOnly="True" HeaderText="Faculty" meta:resourcekey="BoundFieldResource2">
                                                <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="pk_Cr_ID" HeaderText="pk_Cr_ID" meta:resourcekey="BoundFieldResource3">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Cr_Desc" HeaderText="Course" SortExpression="Cr_Desc"
                                                meta:resourcekey="BoundFieldResource4">
                                                <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="pk_MoLrn_ID" HeaderText="Mode Of Learning" meta:resourcekey="BoundFieldResource5">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MoLrn_Type" HeaderText="Mode Of Type" meta:resourcekey="BoundFieldResource6">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="pk_Ptrn_ID" HeaderText="pk_Ptrn_ID" meta:resourcekey="BoundFieldResource7">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="pk_Brn_ID" HeaderText="pk_Ptrn_ID" meta:resourcekey="BoundFieldResource8">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CrPtrn_Name" HeaderText="CrPtrn_Name" meta:resourcekey="BoundFieldResource9">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Elg_Rights_Flag" HeaderText="Elg_Rights_Flag" meta:resourcekey="BoundFieldResource10">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="Rights To" HeaderText="Rights To" meta:resourcekey="BoundFieldResource11">
                                                <ItemStyle Width="10%" />
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            
                                            <asp:TemplateField HeaderText="Rights To">
                                               <ItemTemplate>
                                                  <asp:Label ID="lblRightsTo" runat="server" Text='<%# Bind("Elg_Rights_Flag") %>'></asp:Label>
                                               </ItemTemplate>
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            
                                            


                                            <asp:BoundField DataField="CollCount" HeaderText="College Count" meta:resourcekey="BoundFieldResource12">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UniCount" HeaderText="University Count" meta:resourcekey="BoundFieldResource13">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Brn_Desc" HeaderText="Branch Name" meta:resourcekey="BoundFieldResource14">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Edit" meta:resourcekey="TemplateFieldResource2">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" Text="Edit" runat="server" meta:resourcekey="btnEditResource1" />
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Cr_Abbr" HeaderText="Course" SortExpression="Cr_Desc"
                                                meta:resourcekey="BoundFieldResource15">
                                                <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                        <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                        </PagerStyle>
                                        <HeaderStyle CssClass="gridHeader" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 2px">
                                <asp:Label ID="lblGridNote" runat="server" Visible="False" meta:resourcekey="lblGridNoteResource1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <input id="hidUniID" runat="server" name="hidUniID" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidInstID" runat="server" name="hidInstID" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidFacID" runat="server" name="hidFacID" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidCrLID" runat="server" name="hidCrLID" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidPrgLID" runat="server" name="hidPrgLID" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidPrgTyID" runat="server" name="hidPrgTyID" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidCrID" runat="server" name="hidCrID" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidCrMoLrnID" runat="server" name="hidCrMoLrnID" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidPtrnID" runat="server" name="hidCrPtrnID" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidCrMoLrnPtrnID" runat="server" name="hidCrMoLrnPtrnID" style="width: 32px;
                        height: 22px" type="hidden" /><input id="hidCrPrID" runat="server" name="hidCrPrID"
                            style="width: 32px; height: 22px" type="hidden" />
                    <input id="hidCrPrChID" runat="server" name="hidCrPrChID" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidCorseFlag" runat="server" name="hidCourseFlag" style="width: 32px;
                        height: 22px" type="hidden" />
                    <input id="hidCollUniFlag" runat="server" name="hidCollUniFlag" style="width: 32px;
                        height: 22px" type="hidden" />
                    <input id="hidEditAdd" runat="server" name="hidEditAdd" style="width: 32px; height: 22px"
                        type="hidden" value="0" />
                    <input id="hidMoLrnID" runat="server" name="hidMoLrnID" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidBrnID" runat="server" name="hidBrnID" size="1" type="hidden" />
                    <input id="hidTotal" runat="server" name="hidTotal" style="width: 32px; height: 22px"
                        type="hidden" />
                    <input id="hidLevelFlag" runat="server" name="hidLevelFlag" size="1" type="hidden" />
                    <input id="hidCrPtrnID" runat="server" name="hidCrPtrnID" size="1" type="hidden" />
                    <asp:Label ID="lblFac" runat="server" Text="Faculty" Style="display: none" meta:resourcekey="lblFacResource1"></asp:Label>
                    <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
                    <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
                        meta:resourcekey="lblUniversityResource1"></asp:Label>
                    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
