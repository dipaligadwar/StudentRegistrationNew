<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentAdvanceSeachForConfigure.ascx.cs" Inherits="StudentRegistration.Eligibility.WebCtrl.StudentAdvanceSeachForConfigure" %>
<LINK href="../css/UniPortal.css" type="text/css" rel="stylesheet">
<LINK href="../css/calendar-blue.css" type="text/css" rel="stylesheet">
<script language="javascript" src="../JS/DatePickerJs.js"></script>
<script language="javascript" src="../JS/calendar.js"></script>
<script language="javascript" src="../JS/calendar-en.js"></script>
<script language="javascript" src="../JS/InitCalendarFunc.js"></script>


<script language="javascript">
		var uniid;
		
		uniid = <%=UniversityPortal.clsGetSettings.UniversityID%>
		
		    var hid_Fac_id = '<%=hidFacID.ClientID%>';
		    var ddl_Course= '<%=ddlCourse.ClientID%>';
		    var ddl_CoursePart= '<%=ddlCoursePart.ClientID%>';		
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
		 /* function FillCourse(val)
		    {
		     FillAssignedConfirmedCourses('ddlCr',val,'ddlCourse');
		     document.getElementById("<%=hidFacID.ClientID%>").value = val; 
		    }
		    function FillCrPrDD(val)
		    {
		     alert(val);
		     FillAssignedConfirmedCoursesPart('ddlCrPr',val,'ddlCoursePart');
		     document.getElementById("<%=hidCr_MLrnPtrnID.ClientID%>").value = val; 
		    }*/
    							
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
				
				document.getElementById(txt_DOB).value = '';
				document.getElementById('<%= txtLastName.ClientID %>').value = '';
				document.getElementById('<%= txtFirstName.ClientID %>').value = '';		
				document.getElementById('<%= ddlFaculty.ClientID%>').value = "0";
				document.getElementById('<%= ddlCourse.ClientID%>').value = "0";
				document.getElementById('<%= ddlCoursePart.ClientID%>').value = "0";
				document.getElementById('<%= ddlGender.ClientID%>').value = "-1";			
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
					<TABLE cellSpacing="0" cellPadding="0" width="90%" border="0">
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
							<td width="39%"><asp:textbox id="txtDOB" runat="server" MaxLength="10" CssClass="inputbox"></asp:textbox>&nbsp;
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
									BorderStyle="Solid" Text="Search" Height="18px" onclick="btnSearch_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;<input class="butSubmit" id="btnClear" type="button"
									value="Clear Search Criteria" onclick="fnClearSearchCriteria();" runat="server" Width="70px" Height="18px"></TD>
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
								AllowPaging="True" BorderColor="#336699" AutoGenerateColumns="False" OnItemDataBound="dgElgRegular_ItemDataBound" OnItemCommand="dgElgRegular_ItemCommand" OnPageIndexChanged="dgElgRegular_PageIndexChanged" AllowSorting="True" OnSortCommand="dgElgRegular_SortCommand">
								<ItemStyle CssClass="gridItem"></ItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="Sr No">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Eligibility_Form_No" ReadOnly="True" HeaderText="Eligibility Form No" SortExpression="Eligibility_Form_No">
										<ItemStyle HorizontalAlign="Center" ></ItemStyle>
										<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Button" DataTextField="StudentName" HeaderText="Student Name" CommandName="StudentDetails" SortExpression="StudentName">
									    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="InstituteName" ReadOnly="True" HeaderText="Institute Name" Visible="False" SortExpression="InstituteName">
									    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CourseName" ReadOnly="True" HeaderText="Course Admitted To">
									    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DocCount" HeaderText="No of Documents Submitted" Visible="False">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pk_CrMoLrnPtrn_ID" HeaderText="pkCrMoLrnPtrnID"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right"></PagerStyle>
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
								AllowPaging="True" BorderColor="#336699" AutoGenerateColumns="False" OnItemCommand="dgRegPendingStudents_ItemCommand" OnItemDataBound="dgRegPendingStudents_ItemDataBound" OnPageIndexChanged="dgRegPendingStudents_PageIndexChanged">
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
									<asp:ButtonColumn Text="Button" DataTextField="StudentName" HeaderText="Student Name" CommandName="PendingStudentDetails">
									    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="InstituteName" ReadOnly="True" HeaderText="Institute Name" Visible="False">
									    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CourseName" ReadOnly="True" HeaderText="Course Admitted To">
									    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DocCount" HeaderText="No of Documents Submitted" Visible="False">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pkYear" ReadOnly="True" HeaderText="pkYear"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pkStudentID" ReadOnly="True" HeaderText="pkStudentID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pkCrMoLrnPtrnID" ReadOnly="True" HeaderText="pkCrMoLrnPtrnID"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right"></PagerStyle>
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
    <input id="hidDOB" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDOB" runat="server">
    <input id="hidLastName" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDOB" runat="server">
    <input id="hidFirstName" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDOB" runat="server">
    <input id="hidGender" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDOB" runat="server">
    </center>
