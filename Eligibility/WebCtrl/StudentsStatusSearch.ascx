<%@ Control Language="c#" AutoEventWireup="True" Codebehind="StudentsStatusSearch.ascx.cs"
    Inherits="StudentRegistration.Eligibility.WebCtrl.StudentsStatusSearch" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<link href="../CSS/calendar-blue.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" language="jscript" src="../jscript/calendar.js"> </script>

<script type="text/javascript" language="jscript" src="../jscript/calendar-en.js"> </script>

<script type="text/javascript" language="javascript" src="../jscript/InitCalendarFunc.js"> </script>

<script language="javascript" type="text/javascript" src="../jscript/DatePickerJs.js"></script>

<script language="javascript" src="../JS/ValidatePRN.js"></script>

<script language="javascript" src="../JS/Validations.js"></script>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript">
		var uniid;
		uniid = <%=Classes.clsGetSettings.UniversityID%>
		
		var hid_state_id= '<%=hidStateID.ClientID%>';
		var hid_district_id= '<%=hidDistrictID.ClientID%>';
		var hid_tehsil_id= '<%=hidTehsilID.ClientID%>';
		var ddl_state_id= '<%= State_ID.ClientID %>';
		var ddl_district_id='<%=District_ID.ClientID%>';
		var ddl_tehsil_id='<%=Tehsil_ID.ClientID%>';
    	
        var txt_DOB = ' ';
		
		//------------------------------------------------------------------------------
		//function to clear textbox tooltip on page load
	        window.onload=clearToolTipOnLoad;
	        function clearToolTipOnLoad()
	        {
	           
	        }
		 //------------------------------------------------------------------------------
		 //function to reset textbox tooltip
	        function clearToolTip()
	        {
	           
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
			
			//Fill Districts
			function FillDistricts(StateID, LangFlag)
			{
				document.getElementById('<%=hidDistrictID.ClientID%>').value = '0';
				document.getElementById('<%=hidTehsilID.ClientID%>').value = '0';
				if(StateID != '0')
			    {
					AjaxMethods.FillStateWiseDistricts(parseInt(StateID),LangFlag, FillStateWiseDistricts_Callback);
					
				}
				else
				{
					var d=document.getElementById(ddl_district_id);
					d.selectedIndex=0;
					d.length=1;
				}
				var d1=document.getElementById(ddl_tehsil_id);
				d1.selectedIndex=0;
				d1.length=1;
			}
			
			function FillStateWiseDistricts_Callback(response)
			{
				var ds = response.value;
			    var d=document.getElementById(ddl_district_id);
			    d.length=1;
			    if(ds.Tables[0].Rows.length>0)
			    {
					for(var i=0; i<ds.Tables[0].Rows.length ;i++)
					{
						d.add(new Option(ds.Tables[0].Rows[i].Text,ds.Tables[0].Rows[i].Value));
					}	
				}
				else
				{
				 d.selectedIndex=0;
				}
			}
			
			//Fill Tehsils
			function FillTehsils(DistrictID,LangFlag)
			{
				document.getElementById('<%=hidTehsilID.ClientID%>').value = '0';
				if(DistrictID != '0')
				 {
					AjaxMethods.FillDistrictWiseTehsils(parseInt(DistrictID),LangFlag,FillDistrictWiseTehsils_Callback);
				 }
				else
				{
					var d=document.getElementById(ddl_tehsil_id);
					d.selectedIndex=0;
					d.length=1;
				 }
				
			}
			
			function FillDistrictWiseTehsils_Callback(response)
			{
				var ds = response.value;
			    var d=document.getElementById(ddl_tehsil_id);
			    d.length=1;
			    if(ds.Tables[0].Rows.length>0)
			    {
					for(var i=0; i<ds.Tables[0].Rows.length ;i++)
					{
						d.add(new Option(ds.Tables[0].Rows[i].Text,ds.Tables[0].Rows[i].Value));
					}	
				}
				else
				{
				 d.selectedIndex=0;
				}
			}
						
			
			
		function fnClearSearchCriteria()
			{
				
				document.getElementById('<%= txtLastName.ClientID %>').value = '';
				document.getElementById('<%= txtFirstName.ClientID %>').value = '';
				document.getElementById(ddl_state_id).selectedIndex = 0;
				
				RemoveAllOptions(ddl_district_id);
				document.getElementById(ddl_district_id).selectedIndex = 0;
				
				RemoveAllOptions(ddl_tehsil_id);
				document.getElementById(ddl_tehsil_id).selectedIndex = 0;
				
				document.getElementById('<%= ddlGender.ClientID %>').selectedIndex = 0;
				
				document.getElementById('<%= hidStateID.ClientID%>').value = '0';
				document.getElementById('<%= hidDistrictID.ClientID%>').value = '0';
				document.getElementById('<%= hidTehsilID.ClientID%>').value = '0';
				if(document.getElementById('<%= dgRegStudentList1.ClientID %>')!=null)
				    document.getElementById('<%= dgRegStudentList1.ClientID %>').style.display = 'none';
				document.getElementById('<%= lblGridName.ClientID %>').style.display = 'none';
				document.getElementById('<%= divDGNote.ClientID %>').style.display = 'none';
				
				
				clearToolTip();
				
			}	
			
			function fnDisplayDiv()
	        {	
	             document.getElementById('<%=txtPRN.ClientID%>').innerText="";
	             document.getElementById('<%=txtElgFormNo.ClientID%>').innerText="";
	             if(document.getElementById('<%=dgRegStudentList1.ClientID%>')!=null)
	             {
	                document.getElementById('<%=dgRegStudentList1.ClientID%>').style.display = 'none';
	             }	           
	             document.getElementById('<%=lblGrid.ClientID%>').style.display = 'none';
	             document.getElementById('<%=lblGridName.ClientID%>').style.display = 'none';
	             document.getElementById('<%= divDGNote.ClientID %>').style.display = 'none';	            
	             fnClearSearchCriteria();
	             
        	
		        if(document.getElementById('<%=divSimpleSearch.ClientID%>').style.display == 'none')
		        {
        		      collNameHead=document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText.split('-');
			        document.getElementById('<%=divSimpleSearch.ClientID%>').style.display = 'block';			       
			        document.getElementById('<%=DivAdvanceSearch.ClientID%>').style.display = 'none';
			        document.getElementById('<%=hidSearchType.ClientID%>').value="Simple";				       
			        document.getElementById('<%=lblAdvSearch.ClientID%>').innerText="Advanced Search"; 	
			         if(collNameHead[0]!="undefined")
				        document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText=collNameHead[0];        	
        			
        			document.getElementById('<%=lblMsg.ClientID %>').style.display ='none';
		        }
		        else if(document.getElementById('<%=divSimpleSearch.ClientID%>').style.display == 'block')
		        {
		            collNameHead=document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText.split('-');
			        document.getElementById('<%=divSimpleSearch.ClientID%>').style.display = 'none';
			        document.getElementById('<%=DivAdvanceSearch.ClientID%>').style.display = 'block';
			        
			        document.getElementById('<%=lblMsg.ClientID %>').style.display ='none';
			        
			        document.getElementById('<%=hidSearchType.ClientID%>').value="Adv";	
			        document.getElementById('<%=lblAdvSearch.ClientID%>').innerText="Simple Search"; 
			         if(collNameHead[0]!="undefined")
			            document.getElementById('ctl00_ContentPlaceHolder1_lblSubHeader').innerText=collNameHead[0]; 
			            
			      
			        clearToolTip();
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
		
		//Validating eligibility form number.
		
		function ChkValidation()
		{	
         debugger;	
		  var obPRN = document.getElementById('ctl00_ContentPlaceHolder1_StudentsStatusSearch1_txtPRN').value;
		  var obElg = document.getElementById('ctl00_ContentPlaceHolder1_StudentsStatusSearch1_txtElgFormNo').value;
		  var sStr = obElg.split('-');	
		  var ret=true;
		  var myArr=new Array();
		  var j=-1;
		  var innerRet=false;
		  document.getElementById("<%= hidSSVal.ClientID%>").value="1";
		  
		  if((obPRN.length == 0)&&(obElg.length==0))
		  {
		      document.getElementById("<%= hidSSVal.ClientID%>").value="";
	          myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Eligibility Form Number.","text");
		  }
		   else if ((obPRN.length > 0) && (obElg.length > 0))
		  {
		  	  document.getElementById("<%= hidSSVal.ClientID%>").value="";
	          myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter either  a valid " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " OR Eligibility Form Number.","text");
		  }
		  
		  else
		  {
		     if(obPRN.length>0)
		     {
				//innerRet = checkdigitPRN(obPRN);		
                //debugger;
                innerRet=true;
				//innerRet = checkdigitPRN_Nomenclature(obPRN, document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText,document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value);
				
				//************************************************
			    // Added to check whether PRN belongs to the selected Institute
			    if(innerRet == true)
			    {
			       innerRet = CheckInstforStudentPRN();
    			   
			       if(innerRet == false)
			       {
			          document.getElementById("<%= hidSSVal.ClientID%>").value="";
			          myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Entered " + document.getElementById('ctl00_ContentPlaceHolder1_lblPRNNomenclature').innerText + " does not belong to selected " + document.getElementById('ctl00_ContentPlaceHolder1_lblCollege').innerText + ".","text");  
			       }
			    }
			    //************************************************		
			 }
			 else
			 if(obElg.length>0)
			 {  
			    innerRet = ChkEligFormNumber(obElg);
			    if(innerRet == true)
		        {
		            if(sStr[1] == document.getElementById('ctl00_ContentPlaceHolder1_StudentsStatusSearch1_hidInstID').value)
		            {
		            innerRet = true;
		            }
		            else
		            {
		            document.getElementById("<%= hidSSVal.ClientID%>").value="";
	                myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty",".: The Student is not in selected "+document.getElementById('ctl00_ContentPlaceHolder1_lblCollege').innerText+":. \n \n Please Enter Correct Eligiblity Form No.","text");
		            }		            
		        }
		        
			 }
			 else
		     {
		          document.getElementById("<%= hidSSVal.ClientID%>").value="";
	              myArr[++j]  = new Array(document.getElementById("<%= hidSSVal.ClientID%>"),"Empty","Please Enter the Eligibility Form Number.","text");
		     }
		  }
		   ret=validateMe(myArr,50);
		   if(innerRet!=false)
		    return ret;
		   else
		    return innerRet;
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
    <table id="Table1" cellspacing="0" width="100%" border="0">
        <tr>
            <td style="width: 952px" align="center" colspan="3">
                <fieldset>
                    <legend><strong><span style="text-decoration: underline">Search Criteria</span></strong></legend>
                    <table cellspacing="0" cellpadding="0" border="0" align="center" width="100%">
                        <tr align="right">
                            <td align="right" style="height: 19px">
                                <%-- <label id="lblSimpleSearch" runat="server" class="NavLink" style="cursor: hand" onclick="fnDisplayDiv('Simple');"
                                    onmouseover="UnderLineOnMouseOver('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_lblSimpleSearch');"
                                    onmouseout="UnderLineOnMouseOut('ctl00_ContentPlaceHolder1_StudentAdvanceSeachForConfigure1_lblSimpleSearch');">
                                    Simple Search
                                </label>
                                &nbsp;|&nbsp;--%>
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
                            <tr align="left">
                                <td align="right" width="50%">
                                    &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="tbElgFormNo" runat="server" Text="Enter Eligibility Form Number"
                                        meta:resourcekey="tbElgFormNoResource2"></asp:Label>
                                        :</b>&nbsp;</td>
                                <td height="30" align="left">
                                    <asp:TextBox ID="txtElgFormNo" runat="server" Font-Bold="True" Font-Size="Small"
                                        onclick="this.value='';" meta:resourcekey="txtElgFormNoResource2"></asp:TextBox></td>
                            </tr>
                            <tr align="center" id="trOr" runat="server">
                                <td align="Center" colspan="2">
                                    <b>OR</b>
                                </td>
                            </tr>
                            <tr align="left" id="trPRN" runat="server">
                                <td align="right" width="50%">
                                    <strong>
                                        <asp:Label ID="lblEnterPRN" runat="server" Text="Enter PRN: " meta:resourcekey="lblEnterPRNResource1"></asp:Label></strong></td>
                                <td height="30" align="left">
                                    <asp:TextBox ID="txtPRN" runat="server" MaxLength="20" Font-Bold="True" Font-Size="Small"
                                        onclick="this.value='';" meta:resourcekey="txtPRNResource2"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <br />
                                    <asp:Button ID="btnSimpleSearch" CssClass="butSubmit" Text="Search" runat="server"
                                        OnClick="btnSimpleSearch_Click" meta:resourcekey="btnSimpleSearchResource1"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="DivAdvanceSearch" runat="server" style="display: none">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td style="height: 24px;" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 952px" align="center" colspan="3">
                                    <!-- Selection Starts -->
                                    <table class="tblBackColor" cellspacing="0" cellpadding="3" width="100%">
                                        <tr class="rFont">
                                            <td align="right" width="21%">
                                                <b>Last Name :&nbsp;</b></td>
                                            <td width="39%" align="left">
                                                <asp:TextBox ID="txtLastName" runat="server" CssClass="inputbox" meta:resourcekey="txtLastNameResource1"></asp:TextBox></td>
                                            <td align="right" width="20%">
                                                <b>First Name :&nbsp;</b></td>
                                            <td width="20%" align="left">
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputbox" meta:resourcekey="txtFirstNameResource1"></asp:TextBox></td>
                                        </tr>
                                        <tr class="rFont">
                                            <td align="right" width="21%">
                                                <b>Date of Birth :&nbsp;</b></td>
                                           <%-- <td width="39%" align="left">
                                                <asp:TextBox ID="txtDOB" runat="server" CssClass="inputbox" Width="70px" MaxLength="10"
                                                    meta:resourcekey="txtDOBResource1" ValidationGroup="dateValidator1" CausesValidation="True"></asp:TextBox>&nbsp;
                                                <b>[dd/mm/yyyy]</b>
                                                <a id="alinkCalender" onclick="return showCalendar(document.getElementById(txt_DOB).id, '%d/%m/%Y');"
                                                    runat="server">
                                                    <img onmouseover="this.style.cursor='Hand'" src="../images/cal.gif" align="middle"></a>&nbsp;
                                                [dd/mm/yyyy]
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
                                                    InvalidValueMessage="Date is invalid" ValidationGroup="dateValidator1" TooltipMessage="Input a Date"  MaximumValue="31/12/9999" MinimumValue="01/01/1753" MaximumValueMessage="Date is invalid" MinimumValueMessage="Date is invalid"/>
                                 
                                            </td>--%>
                                            <td align="right" width="20%">
                                                <b>Gender :&nbsp;</b></td>
                                            <td width="20%" align="left">
                                                <asp:DropDownList ID="ddlGender" CssClass="selectbox" runat="server" meta:resourcekey="ddlGenderResource1">
                                                    <asp:ListItem Value="0" Selected="True" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource2" Text="Male"></asp:ListItem>
                                                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource3" Text="Female"></asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                    <table class="tblBackColor" cellspacing="0" cellpadding="3" width="100%">
                                        <tr class="rFont">
                                            <td align="right" width="21%">
                                                <b>State :&nbsp; </b>
                                            </td>
                                            <td align="left">
                                                <b>
                                                    <asp:DropDownList ID="State_ID" runat="server" CssClass="selectbox" onchange="setValue(hid_state_id,this.value);FillDistricts(this.value,'E');RemoveAllOptions(ddl_tehsil_id);"
                                                        Width="184px" meta:resourcekey="State_IDResource1">
                                                    </asp:DropDownList></b></td>
                                        </tr>
                                        <tr class="rFont">
                                            <td align="right" width="20%">
                                                <b>District :&nbsp;</b></td>
                                            <td align="left">
                                                <asp:DropDownList ID="District_ID" runat="server" CssClass="selectbox" onchange="setValue(hid_district_id,this.value);FillTehsils(this.value,'E');"
                                                    Width="184px" meta:resourcekey="District_IDResource1">
                                                </asp:DropDownList>&nbsp; <b>Tehsil : </b>
                                                <asp:DropDownList ID="Tehsil_ID" onblur="setValue(hid_tehsil_id,this.value);" runat="server"
                                                    CssClass="selectbox" Width="152px" meta:resourcekey="Tehsil_IDResource1">
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                    <table class="tblBackColor" cellspacing="0" cellpadding="3" width="100%">
                                        <tr class="rFont">
                                            <td align="center">
                                                <br>
                                                <asp:Button ID="btnSearch" runat="server" CssClass="butSubmit" Width="70px" Height="18px"
                                                    Text="Search" OnClick="btnSearch_Click"
                                                    meta:resourcekey="btnSearchResource1" ValidationGroup="dateValidator1"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;<input
                                                        class="butSubmit" id="btnClear" onclick="fnClearSearchCriteria();" type="button"
                                                        value="Clear Search Criteria" name="btnClear" runat="server" width="70px" height="18px"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
                <p style="margin-top: 10px; margin-bottom: 1px; margin-left: 0px" align="left">
                    <asp:Label ID="lblGridName" Style="display: none" runat="server" CssClass="errorNote"
                        Width="99%" Height="18px" meta:resourcekey="lblGridNameResource1"></asp:Label></p>
                <p style="margin-top: 0px; margin-bottom: 0px; margin-left: 0px" align="center">
                    &nbsp;</p>
                <div id="divDGNote" style="display: none;" align="left" runat="server">
                    <font color="red">* Please click on the student name to view his/her respective request(s).</font></div>
            </td>
        </tr>
        <tr>
            <td style="width: 953px" align="center" colspan="3">
                <table id="tblDGRegStudentList" width="100%" runat="server">
                    <tr>
                        <td style="width: 100%;" align="left">
                            <asp:Label runat="server" ID="lblGrid" CssClass="divDGNote" meta:resourcekey="lblGridResource1"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:GridView ID="dgRegStudentList1" runat="server" Width="100%" BorderStyle="Solid"
                                BorderWidth="1px" AutoGenerateColumns="False" BorderColor="#336699" AllowPaging="True"
                                AllowSorting="True" OnPageIndexChanging="dgRegStudentList1_PageIndexChangin"
                                OnRowCommand="dgRegStudentList1_RowCommad" OnRowDataBound="dgRegStudentList1_RowDataBound"
                                CssClass="clGrid grid-view" OnSorting="dgRegStudentList1_Sorting" meta:resourcekey="dgRegStudentList1Resource1">
                                <RowStyle CssClass="gridItem"></RowStyle>
                                <HeaderStyle CssClass="gridHeader" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <%# (Container.DataItemIndex)+1 %>
                                            .
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        <ItemStyle Width="1%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Eligibility_Form_No" ReadOnly="True" HeaderText="Eligibility Form No "
                                        SortExpression="Eligibility_Form_No">
                                        <ItemStyle HorizontalAlign="Center" Width="17%"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" />
                                    </asp:BoundField>
                                    <asp:ButtonField Text="Button" DataTextField="StudentName" HeaderText="Student Name"
                                        CommandName="StudentDetails" SortExpression="StudentName" meta:resourcekey="ButtonFieldResource1">
                                        <HeaderStyle CssClass="gridHeader" />
                                        <ItemStyle HorizontalAlign="Center" Width="16%"></ItemStyle>
                                    </asp:ButtonField>
                                    <asp:BoundField DataField="PRN" ReadOnly="True" HeaderText="PRN " SortExpression="PRN"
                                        meta:resourcekey="BoundFieldResource1">
                                        <ItemStyle HorizontalAlign="Center" Width="18%"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkYear" ReadOnly="True" HeaderText="pk_Year" meta:resourcekey="BoundFieldResource2">
                                        <HeaderStyle CssClass="gridHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkStudentID" ReadOnly="True" HeaderText="pk_Student_ID"
                                        meta:resourcekey="BoundFieldResource3">
                                        <HeaderStyle CssClass="gridHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EligibilityStatus" HeaderText="Eligibility Status" SortExpression="EligibilityStatus"
                                        meta:resourcekey="BoundFieldResource8">
                                        <HeaderStyle CssClass="gridHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" meta:resourcekey="BoundFieldResource9">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pk_Fac_ID" HeaderText="pk_Fac_ID" meta:resourcekey="BoundFieldResource10">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pk_Cr_ID" HeaderText="pk_Cr_ID" meta:resourcekey="BoundFieldResource11">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pk_MoLrn_ID" HeaderText="pk_MoLrn_ID" meta:resourcekey="BoundFieldResource12">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pk_Ptrn_ID" HeaderText="pk_Ptrn_ID" meta:resourcekey="BoundFieldResource13">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pk_Brn_ID" HeaderText="pk_Brn_ID" meta:resourcekey="BoundFieldResource14">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pk_CrPr_Details_ID" HeaderText="pk_CrPr_Details_ID" meta:resourcekey="BoundFieldResource15">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourseName" HeaderText="Course Admitted To" meta:resourcekey="BoundFieldResource16">
                                        <HeaderStyle CssClass="gridHeader" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                </PagerStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <br />
                            <asp:Label ID="lblMsg" Style="display: none" runat="server" CssClass="errorNote"
                                meta:resourcekey="lblMsgResource1"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <input id="hidInstID" runat="server" name="hidInstID" style="width: 24px; height: 22px"
        type="hidden" />
    <input id="hidUniID" style="width: 40px; height: 22px" type="hidden" name="hidUniID"
        runat="server">
    <input id="hidStateID" style="width: 24px; height: 22px" type="hidden" name="hidStateID"
        runat="server">
    <input id="hidDistrictID" style="width: 24px; height: 22px" type="hidden" name="hidDistrictID"
        runat="server">
    <input id="hidTehsilID" style="width: 24px; height: 22px" type="hidden" name="hidTehsilID"
        runat="server">
    <input id="hidpkStudentID" type="hidden" value="0" name="hidpkStudentID" runat="server">
    <input id="hidpkYear" type="hidden" value="0" name="hidpkYear" runat="server">
    <input id="hidRef_InstReg_Uni_ID" type="hidden" name="hidRef_InstReg_Uni_ID" runat="server">
    <input id="hidRef_InstReg_Institute_ID" type="hidden" name="hidRef_InstReg_Institute_ID"
        runat="server">
    <input id="hidRef_InstReg_Year" type="hidden" name="hidRef_InstReg_Year" runat="server">
    <input id="hidRef_Student_ID" type="hidden" name="hidRef_Student_ID" runat="server">
    <input id="hidpkFacID" type="hidden" name="hidpkFacID" runat="server">
    <input id="hidpkCrID" type="hidden" name="hidpkCrID" runat="server">
    <input type="hidden" id="hidSSVal" runat="server" value="1" />
    <input id="hidpkMoLrnID" type="hidden" name="hidpkMoLrnID" runat="server">
    <input id="hidpkPtrnID" type="hidden" name="hidpkPtrnID" runat="server">
    <input id="hidpkBrnID" type="hidden" name="hidpkBrnID" runat="server">
    <input id="hidpkCrPrDetailsID" type="hidden" name="hidpkCrPrDetailsID" runat="server">
    <input id="hidSearchType" type="hidden" name="hidSearchType" runat="server">
    <input id="hidElgFormNo" runat="server" name="hidElgFormNo" type="hidden" />
    <input id="hidPRN" runat="server" name="hidPRN" type="hidden" /><br />
    <input id="hidDOB" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
        runat="server">
    
    <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none"
        meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>
    
    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
    <input id="hidLastName" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
        runat="server">
    <input id="hidFirstName" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
        runat="server">
    <input id="hidGender" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
        runat="server">
    <input id="hidIsBlank" type="hidden" name="hidIsBlank" runat="server">
    <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
</center>
<asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
