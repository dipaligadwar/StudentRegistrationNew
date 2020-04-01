<%@ Control Language="c#" AutoEventWireup="True" Codebehind="StudentsAdvancedSearch.ascx.cs" Inherits="StudentRegistration.Eligibility.WebCtrl.StudentsAdvancedSearch" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../css/UniPortal.css" type="text/css" rel="stylesheet">
<LINK href="../css/calendar-blue.css" type="text/css" rel="stylesheet">
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
		var ddl_state_id = '<%= State_ID.ClientID %>';
		var ddl_district_id='<%=District_ID.ClientID%>';
		var ddl_tehsil_id='<%=Tehsil_ID.ClientID%>';
		var ddl_Faculty='<%=ddlFaculty.ClientID%>';
		var ddl_Course= '<%=ddlCourse.ClientID%>';
		var ddl_CoursePart= '<%=ddlCoursePart.ClientID%>';
		var hid_Fac_id = '<%=hidFacID.ClientID%>';
		var hid_Cr_id = '<%=hidCrID.ClientID%>';
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
			
			function setIDValues(val)
			{
			  if(val != '0')
			  { 
				var arr= val.split("$");
				document.getElementById('<%=hidCr_MLrnPtrnID.ClientID%>').value=val;
				document.getElementById('<%=hidCrPrID.ClientID%>').value=arr[1];
				document.getElementById('<%=hidCrMoLrnPtrnID.ClientID%>').value=arr[0];
			  }
			  else
			  {
				document.getElementById('<%=hidCr_MLrnPtrnID.ClientID%>').value='0';
				document.getElementById('<%=hidCrPrID.ClientID%>').value='0';
				document.getElementById('<%=hidCrMoLrnPtrnID.ClientID%>').value='0';
			  }
						  
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
			    //alert(ds.Tables[0].Rows.length);
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
							
			function  FillCourse(val)
			{
			    //alert(val);
			    document.getElementById('<%= hidCrID.ClientID%>').value = '0';
				document.getElementById('<%= hidCr_MLrnPtrnID.ClientID%>').value = '0';
				document.getElementById('<%= hidCrPrID.ClientID%>').value = '0';
				document.getElementById('<%= hidCrMoLrnPtrnID.ClientID%>').value = '0';
			    if(val!="0")
			    {
					AjaxMethods.selFacultyWiseAllCourses(parseInt(uniid),parseInt(val),selFacultyWiseAllCourses_Callback);
				}
				else
				{
				 var cr=document.getElementById(ddl_Course);
				 cr.selectedIndex=0;
				 cr.length=1;
				}
				 var cr1=document.getElementById(ddl_CoursePart);
				 cr1.selectedIndex=0;
				 cr1.length=1;
			}
			
			function selFacultyWiseAllCourses_Callback(response)
			{
			    var ds = response.value[0];
			   
			    var d=document.getElementById(ddl_Course);
			    d.length=1;
			    if(ds.Tables[0].Rows.length>0)
			    {
					for(var i=0; i<ds.Tables[0].Rows.length ;i++)
					{
					d.add(new Option(ds.Tables[0].Rows[i].Course,ds.Tables[0].Rows[i].CourseID));
					}	
				}
				else
				{
				 d.selectedIndex=0;
				}
			}
			
			//Fill Coursewise Coursepart
			
			function FillCoursePart(CrID)
			{
			  document.getElementById('<%= hidCr_MLrnPtrnID.ClientID%>').value = '0';
			  document.getElementById('<%= hidCrPrID.ClientID%>').value = '0';
			  document.getElementById('<%= hidCrMoLrnPtrnID.ClientID%>').value = '0';
			  if(CrID!="0")
			  {
					AjaxMethods.selAllCoursePart(parseInt(uniid),parseInt(document.getElementById(hid_Fac_id).value),parseInt(CrID),selAllCoursePart_Callback);
			  }
			  else
			  {
				var cr1=document.getElementById(ddl_CoursePart);
			    cr1.selectedIndex=0;
			    cr1.length=1;
			  }
			}
			
			function selAllCoursePart_Callback(response)
			{
			 
			   
			    var ds = response.value[0];
			    var d=document.getElementById(ddl_CoursePart);
			    d.length=1;
			  
			    for(var i=0; i<ds.Tables[0].Rows.length ;i++)
				{
				d.add(new Option(ds.Tables[0].Rows[i].CrPr_Desc,ds.Tables[0].Rows[i].Cr_MLPtrnID));
				}	
			}
			
			function fnClearSearchCriteria()
			{
				document.getElementById('<%=rdbtnInstType.ClientID%>').children[0].checked = true;
				document.getElementById('<%=Inst_Name.ClientID%>').value = '';
				document.getElementById(txt_DOB).value = '';
				document.getElementById('<%= txtLastName.ClientID %>').value = '';
				document.getElementById('<%= txtFirstName.ClientID %>').value = '';
				document.getElementById(ddl_state_id).selectedIndex = 0;
				
				RemoveAllOptions(ddl_district_id);
				document.getElementById(ddl_district_id).selectedIndex = 0;
				
				RemoveAllOptions(ddl_tehsil_id);
				document.getElementById(ddl_tehsil_id).selectedIndex = 0;
				
				document.getElementById(ddl_Faculty).selectedIndex = 0;
				
				RemoveAllOptions(ddl_Course);
				document.getElementById(ddl_Course).selectedIndex = 0;
				
				RemoveAllOptions(ddl_CoursePart);
				document.getElementById(ddl_CoursePart).selectedIndex = 0;
				
				document.getElementById('<%= ddlGender.ClientID %>').selectedIndex = 0;
				
				document.getElementById('<%= hidStateID.ClientID%>').value = '0';
				document.getElementById('<%= hidDistrictID.ClientID%>').value = '0';
				document.getElementById('<%= hidTehsilID.ClientID%>').value = '0';
				document.getElementById('<%= hidFacID.ClientID%>').value = '0';
				document.getElementById('<%= hidCrID.ClientID%>').value = '0';
				document.getElementById('<%= hidCr_MLrnPtrnID.ClientID%>').value = '0$0';
				document.getElementById('<%= hidCrPrID.ClientID%>').value = '0';
				document.getElementById('<%= hidCrMoLrnPtrnID.ClientID%>').value = '0';
				
				document.getElementById('<%= tblDGElgRegular.ClientID %>').style.display = 'none';
				document.getElementById('<%= tblDGRegPendingStudents.ClientID %>').style.display = 'none';
				document.getElementById('<%= lblGridName.ClientID %>').style.display = 'none';
				document.getElementById('<%= divDGNote.ClientID %>').style.display = 'none';
								
			}
			
</script>
<center>
	<TABLE id="Table4" cellSpacing="0" width="100%" border="0">
		<!--<TR>
									<TD colspan="3" align="right" height="20"></TD>
								</TR>-->
		<TR>
			<td style="WIDTH: 952px" align="center" colSpan="3">
				<!-- Selection Starts -->
				<fieldset id="tblSelect" style="WIDTH: 700px; HEIGHT: 100px" runat="server"><legend><STRONG>Search 
							Student(s)</STRONG></legend>
					<TABLE cellSpacing="0" cellPadding="0" border="0">
						<TR>
							<TD align="right" width="20%"><B>Institute Type</B></TD>
							<TD align="center" width="1%"><B>:</B></TD>
							<TD><asp:radiobuttonlist id="rdbtnInstType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
									ForeColor="Navy" Font-Bold="True"></asp:radiobuttonlist></TD>
						</TR>
						<TR>
							<TD align="right" width="20%"><B>Institute Name</B></TD>
							<TD align="center" width="1%"><B>:</B></TD>
							<TD><asp:textbox id="Inst_Name" runat="server" MaxLength="300" Width="395px" CssClass="inputbox"></asp:textbox></TD>
						</TR>
						<TR>
							<TD align="right" width="20%"><B>Institute State&nbsp; </B>
							</TD>
							<TD align="center" width="1%"><B>:</B></TD>
							<TD><B><asp:dropdownlist id="State_ID" runat="server" Width="184px" CssClass="selectbox" onchange="setValue(hid_state_id,this.value); FillDistricts(this.value,'E'); RemoveAllOptions(ddl_tehsil_id);"></asp:dropdownlist></B></TD>
						</TR>
						<TR>
							<TD align="right" width="20%"><B>Institute District</B></TD>
							<TD align="center" width="1%"><B>:</B></TD>
							<TD><asp:dropdownlist id="District_ID" runat="server" Width="184px" CssClass="selectbox" onchange="setValue(hid_district_id,this.value);FillTehsils(this.value,'E');"></asp:dropdownlist>&nbsp;
								<B>Institute Tehsil : </B>
								<asp:dropdownlist id="Tehsil_ID" onblur="setValue(hid_tehsil_id,this.value);" runat="server" Width="152px"
									CssClass="selectbox"></asp:dropdownlist></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 901px" align="right" colSpan="3"><B>&nbsp;</B></TD>
						</TR>
					</TABLE>
					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td align="right" width="21%"><b>Faculty :&nbsp;</b></td>
							<td colSpan="3"><asp:dropdownlist id="ddlFaculty" runat="server" Width="260px" CssClass="selectbox" onchange="setValue(hid_Fac_id,this.value); FillCourse(this.value);">
									<asp:ListItem Value="0">---Select---</asp:ListItem>
								</asp:dropdownlist></td>
						</tr>
						<tr>
							<td align="right" width="21%"><b>Course :&nbsp;</b></td>
							<td colSpan="3"><asp:dropdownlist id="ddlCourse" runat="server" Width="260px" CssClass="selectbox" onchange="setValue(hid_Cr_id,this.value); FillCoursePart(this.value);">
									<asp:ListItem Value="0">---Select----</asp:ListItem>
								</asp:dropdownlist></td>
						</tr>
						<tr>
							<td align="right" width="21%"><b>Course Part :&nbsp;</b></td>
							<td colSpan="3"><asp:dropdownlist id="ddlCoursePart" runat="server" Width="260px" CssClass="selectbox" onchange="setIDValues(this.value);">
									<asp:ListItem Value="0">---Select----</asp:ListItem>
								</asp:dropdownlist></td>
						</tr>
						<tr>
							<td align="right" width="21%"><b>Date of Birth :&nbsp;</b></td>
							<td width="39%"><asp:textbox id="txtDOB" runat="server" MaxLength="10" CssClass="inputbox" ReadOnly="True"></asp:textbox>&nbsp;
								<A id="alinkCalender" onclick="return showCalendar(txt_DOB, '%d/%m/%Y');" runat="server">
									<IMG onmouseover="this.style.cursor='Hand'" src="../images/cal.gif" align="middle"></A>&nbsp; 
								[dd/mm/yyyy]</td>
							<td align="right" width="20%"><b>Gender :&nbsp;</b></td>
							<td width="20%"><asp:dropdownlist id="ddlGender" CssClass="selectbox" Runat="server">
									<asp:ListItem Value="-1" Selected="True">--- Select ---</asp:ListItem>
									<asp:ListItem Value="0">Male</asp:ListItem>
									<asp:ListItem Value="1">Female</asp:ListItem>
								</asp:dropdownlist></td>
						</tr>
						<TR>
							<td align="right" width="21%"><b>Last Name :&nbsp;</b></td>
							<td width="39%"><asp:textbox id="txtLastName" runat="server" CssClass="inputbox"></asp:textbox></td>
							<td align="right" width="20%"><b>First Name :&nbsp;</b></td>
							<td width="20%"><asp:textbox id="txtFirstName" runat="server" CssClass="inputbox"></asp:textbox></td>
						</TR>
						<TR>
							<TD align="center" colSpan="4"><br>
								<asp:button id="btnSearch" runat="server" Width="70px" CssClass="butSubmit" BorderWidth="1px"
									BorderStyle="Solid" Text="Search" Height="18px" onclick="btnSearch_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;<input class="butSubmit" id="btnClear" onclick="fnClearSearchCriteria();" type="button"
									value="Clear Search Criteria" runat="server" Width="70px" Height="18px"></TD>
						</TR>
					</TABLE>
				</fieldset>
				<p style="MARGIN-TOP: 10px; MARGIN-BOTTOM: 1px; MARGIN-LEFT: 0px" align="center"><asp:label id="lblGridName" style="DISPLAY: none" runat="server" Width="99%" CssClass="GridSubHeading"
						Height="18px"></asp:label></p>
				<p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; MARGIN-LEFT: 0px" align="center">&nbsp;</p>
				<div id="divDGNote" style="DISPLAY: none" align="left" runat="server"><FONT color="red">* 
						Please click on the student name to view his/her respective profile.</FONT></div>
			</td>
		</TR>
		<TR>
			<td style="WIDTH: 953px" align="center" colSpan="3" height="30">
				<table id="tblDGElgRegular" style="DISPLAY: none" width="100%" runat="server">
					<TR>
						<td><asp:datagrid id="dgElgRegular" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
								AllowPaging="True" BorderColor="#336699" AutoGenerateColumns="False">
								<ItemStyle CssClass="gridItem"></ItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="Sr No">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Eligibility_Form_No" ReadOnly="True" HeaderText="Eligibility Form No">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Button" DataTextField="StudentName" HeaderText="Student Name" CommandName="StudentDetails">
									    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="InstituteName" ReadOnly="True" HeaderText="Institute Name">
									    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CourseName" ReadOnly="True" HeaderText="Course Admitted To">
									    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DocCount" HeaderText="No of Documents Submitted">
										<ItemStyle HorizontalAlign="Center" ></ItemStyle>
										<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pk_CrMoLrnPtrn_ID" HeaderText="pkCrMoLrnPtrnID"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</TR>
				</table>
			</td>
		</TR>
		<TR>
			<td style="WIDTH: 953px" align="center" colSpan="3" height="30">
				<table id="tblDGRegPendingStudents" style="DISPLAY: none" width="100%" runat="server">
					<TR>
						<td><asp:datagrid id="dgRegPendingStudents" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
								AllowPaging="True" BorderColor="#336699" AutoGenerateColumns="False">
								<ItemStyle CssClass="GridData2"></ItemStyle>
								<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="White" BorderStyle="Solid" BorderColor="White"
									CssClass="GridHeading"></HeaderStyle>
								<Columns>
									<asp:BoundColumn HeaderText="Sr No">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Eligibility_Form_No" ReadOnly="True" HeaderText="Eligibility Form No">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Button" DataTextField="StudentName" HeaderText="Student Name" CommandName="PendingStudentDetails"></asp:ButtonColumn>
									<asp:BoundColumn DataField="InstituteName" ReadOnly="True" HeaderText="Institute Name"></asp:BoundColumn>
									<asp:BoundColumn DataField="CourseName" ReadOnly="True" HeaderText="Course Admitted To"></asp:BoundColumn>
									<asp:BoundColumn DataField="DocCount" HeaderText="No of Documents Submitted">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pkYear" ReadOnly="True" HeaderText="pkYear"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pkStudentID" ReadOnly="True" HeaderText="pkStudentID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pkCrMoLrnPtrnID" ReadOnly="True" HeaderText="pkCrMoLrnPtrnID"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</TR>
				</table>
			</td>
		</TR>
	</TABLE>
	<DIV></DIV>
	<INPUT id="hidUniID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidUniID" runat="server">
	<INPUT id="hidInstID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidInstID" runat="server">
	<INPUT id="hidStateID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidStateID" runat="server"> 
	<INPUT id="hidDistrictID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidDistrictID" runat="server"> 
	<INPUT id="hidTehsilID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidTehsilID" runat="server">
	<INPUT id="hidFacID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" value="0" name="hidFacID" runat="server"> 
	<INPUT id="hidCrID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" value="0" name="hidCrID" runat="server">
	<INPUT id="hidCr_MLrnPtrnID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" value="0" name="hidCr_MLrnPtrnID" runat="server">
	<INPUT id="hidCrPrID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" value="0" name="hidCrPrID" runat="server">
	<INPUT id="hidElgFormNo" type="hidden" value="0" name="hidElgFormNo" runat="server">
	<INPUT id="hidpkStudentID" type="hidden" value="0" name="hidpkStudentID" runat="server">
	<input id="hidCrMoLrnPtrnID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" value="0" name="hidCrMoLrnPtrnID" runat="server"> 
	<input id="hidStep" type="hidden" name="hidStep" runat="server">
	<input id="hidpkYear" type="hidden" value="0" name="hidpkYear" runat="server">
</center>
