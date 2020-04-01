<%@ Control Language="c#" AutoEventWireup="True" Codebehind="StudentsStatusSearch.ascx.cs" Inherits="StudentRegistration.Eligibility.WebCtrl.StudentsStatusSearch" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<LINK href="../CSS/UniPortal.css" type="text/css" rel="stylesheet">
<LINK href="../CSS/calendar-blue.css" type="text/css" rel="stylesheet">
<!--<script language="javascript" src="../JS/SPXMLHTTP.js"></script>-->
<script language="javascript" src="../JS/DatePickerJs.js"></script>
<script language="javascript" src="../JS/calendar.js"></script>
<script language="javascript" src="../JS/calendar-en.js"></script>
<script language="javascript" src="../JS/InitCalendarFunc.js"></script>
<!--<script language="javascript" src="ajax/common.ashx"></script>
<script language="javascript" src="ajax/Eligibility.AjaxMethods,AjaxMethods.ashx"></script>-->
<script language="javascript">
		var uniid;
		uniid = <%=UniversityPortal.clsGetSettings.UniversityID%>
		
		var hid_state_id= '<%=hidStateID.ClientID%>';
		var hid_district_id= '<%=hidDistrictID.ClientID%>';
		var hid_tehsil_id= '<%=hidTehsilID.ClientID%>';
		var ddl_state_id= '<%= State_ID.ClientID %>';
		var ddl_district_id='<%=District_ID.ClientID%>';
		var ddl_tehsil_id='<%=Tehsil_ID.ClientID%>';
		var txt_DOB = '<%=txtDOB.ClientID%>';
		
		
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
				document.getElementById(txt_DOB).value = '';
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
				document.getElementById('<%= tblDGRegStudentList.ClientID %>').style.display = 'none';
				document.getElementById('<%= lblGridName.ClientID %>').style.display = 'none';
				document.getElementById('<%= divDGNote.ClientID %>').style.display = 'none';
				
			}	
			
</script>
<center>
	<TABLE id="Table4" cellSpacing="0" cellPadding="3" width="100%">
		<!--<TR>
							<TD colspan="3" align="right" height="20"></TD>
								</TR>-->
		<TR>
			<td style="WIDTH: 952px" align="center" colSpan="3">
				<!-- Selection Starts -->
				<fieldset id="tblSelect" style="WIDTH: 700px; HEIGHT: 100px" runat="server"><legend><STRONG>Search 
							Student(s)</STRONG></legend>
					<TABLE class="tblBackColor" cellSpacing="0" cellPadding="3" width="100%">
						<TR class="rFont">
							<td align="right" width="21%"><b>Last Name :&nbsp;</b></td>
							<td width="39%"><asp:textbox id="txtLastName" runat="server" CssClass="inputbox"></asp:textbox></td>
							<td align="right" width="20%"><b>First Name :&nbsp;</b></td>
							<td width="20%"><asp:textbox id="txtFirstName" runat="server" CssClass="inputbox"></asp:textbox></td>
						</TR>
						<tr class="rFont">
							<td align="right" width="21%"><b>Date of Birth :&nbsp;</b></td>
							<td width="39%"><asp:textbox id="txtDOB" runat="server" CssClass="inputbox" MaxLength="10"></asp:textbox>&nbsp;
								<A id="alinkCalender" onclick="return showCalendar(txt_DOB, '%d/%m/%Y');" runat="server">
									<IMG onmouseover="this.style.cursor='Hand'" src="../Images/cal.gif" align="middle"></A>&nbsp; 
								[dd/mm/yyyy]</td>
							<td align="right" width="20%"><b>Gender :&nbsp;</b></td>
							<td width="20%"><asp:dropdownlist id="ddlGender" CssClass="selectbox" Runat="server">
									<asp:ListItem Value="-1" Selected="True">--- Select ---</asp:ListItem>
									<asp:ListItem Value="0">Male</asp:ListItem>
									<asp:ListItem Value="1">Female</asp:ListItem>
								</asp:dropdownlist></td>
						</tr>
					</TABLE>
					<TABLE class="tblBackColor" cellSpacing="0" cellPadding="3" width="100%">
						<TR class="rFont">
							<TD align="right" width="21%"><B>State&nbsp; </B>
							</TD>
							<TD align="center" width="1%"><B>:</B></TD>
							<TD><B><asp:dropdownlist id="State_ID" runat="server" CssClass="selectbox" onchange="setValue(hid_state_id,this.value);FillDistricts(this.value,'E');RemoveAllOptions(ddl_tehsil_id);"
										Width="184px"></asp:dropdownlist></B></TD>
						</TR>
						<TR class="rFont">
							<TD align="right" width="20%"><B>District</B></TD>
							<TD align="center" width="1%"><B>:</B></TD>
							<TD><asp:dropdownlist id="District_ID" runat="server" CssClass="selectbox" onchange="setValue(hid_district_id,this.value);FillTehsils(this.value,'E');"
									Width="184px"></asp:dropdownlist>&nbsp; <B>Tehsil : </B>
								<asp:dropdownlist id="Tehsil_ID" onblur="setValue(hid_tehsil_id,this.value);" runat="server" CssClass="selectbox"
									Width="152px"></asp:dropdownlist></TD>
						</TR>
					</TABLE>
					<table class="tblBackColor" cellSpacing="0" cellPadding="3" width="100%">
						<TR class="rFont">
							<TD align="center"><br>
								<asp:button id="btnSearch" runat="server" CssClass="butSubmit" Width="70px" Height="18px" Text="Search"
									BorderStyle="Solid" BorderWidth="1px" onclick="btnSearch_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;<input class="butSubmit" id="btnClear" onclick="fnClearSearchCriteria();" type="button"
									value="Clear Search Criteria" name="btnClear" runat="server" Width="70px" Height="18px"></TD>
						</TR>
					</table>
				</fieldset>
				<p style="MARGIN-TOP: 10px; MARGIN-BOTTOM: 1px; MARGIN-LEFT: 0px" align="center"><asp:label id="lblGridName" style="DISPLAY: none" runat="server" CssClass="GridSubHeading"
						Width="99%" Height="18px"></asp:label></p>
				<p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; MARGIN-LEFT: 0px" align="center">&nbsp;</p>
				<div id="divDGNote" style="DISPLAY: none" align="left" runat="server"><FONT color="red">* 
						Please click on the student name to view his/her respective request(s).</FONT></div>
			</td>
		</TR>
		<TR>
			<td style="WIDTH: 953px" align="center" colSpan="3" height="30">
				<table id="tblDGRegStudentList" style="DISPLAY: none" width="100%" runat="server">
					<TR>
						<td>
						    <asp:datagrid id="dgRegStudentList" runat="server" Width="100%" BorderStyle="Solid" BorderWidth="1px"
								AutoGenerateColumns="False" BorderColor="#336699" AllowPaging="True" AllowSorting="True" OnSortCommand="dgRegStudentList_SortCommand">
								<ItemStyle CssClass="gridItem"></ItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="Sr No">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<HeaderStyle CssClass="gridHeader" />
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Button" DataTextField="StudentName" HeaderText="Student Name" CommandName="StudentDetails" SortExpression="StudentName">
									    <HeaderStyle CssClass="gridHeader" />
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="PRN_Number" ReadOnly="True" HeaderText="PRN ">
										<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
										<HeaderStyle CssClass="gridHeader" />
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pkYear" ReadOnly="True" HeaderText="pk_Year">
									    <HeaderStyle CssClass="gridHeader" />
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pkStudentID" ReadOnly="True" HeaderText="pk_Student_ID">
									    <HeaderStyle CssClass="gridHeader" />
									</asp:BoundColumn>
                                    <asp:BoundColumn DataField="Ref_Student_ID" HeaderText="Ref_Student_ID" Visible="False">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EligibilityStatus" HeaderText="Eligibility Status">
                                        <HeaderStyle CssClass="gridHeader" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Reason" HeaderText="Reason">
                                        <HeaderStyle CssClass="gridHeader" />
                                    </asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
						</td>
					</TR>
				</table>
			</td>
		</TR>		
	</TABLE>
    <input id="hidInstID" runat="server" name="hidInstID" style="width: 24px; height: 22px"
        type="hidden" />
	<input id="hidUniID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidUniID" runat="server">
	<input id="hidStateID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidStateID" runat="server"> 
	<input id="hidDistrictID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidDistrictID" runat="server"> 
	<input id="hidTehsilID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidTehsilID" runat="server"> 
	<input id="hidpkStudentID" type="hidden" value="0" name="hidpkStudentID" runat="server">
	<input id="hidpkYear" type="hidden" value="0" name="hidpkYear" runat="server">
	<input id="hidSearchType" type="hidden" name="hidSearchType" runat="server">
    <input id="hidElgFormNo" runat="server" name="hidElgFormNo" type="hidden" />
    <input id="hidPRN" runat="server" name="hidPRN" type="hidden" /><br />
    <input id="hidDOB" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDOB" runat="server">
    <input id="hidLastName" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDOB" runat="server">
    <input id="hidFirstName" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDOB" runat="server">
    <input id="hidGender" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDOB" runat="server"></center>
