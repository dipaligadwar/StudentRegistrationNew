<%@ Control Language="c#" AutoEventWireup="True" Codebehind="StudentsAdvancedSearch.ascx.cs"
    Inherits="StudentRegistration.Eligibility.WebCtrl.StudentsAdvancedSearch" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
    
<link href="../CSS/calendar-blue.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" language="jscript" src="../jscript/calendar.js"> </script>
<script type="text/javascript" language="jscript" src="../jscript/calendar-en.js"> </script>
<script type="text/javascript" language="javascript" src="../jscript/InitCalendarFunc.js"> </script>
<script language="javascript" type="text/javascript" src="../jscript/DatePickerJs.js"></script>

<!--<script language="javascript" src="ajax/common.ashx"></script>
<script language="javascript" src="ajax/Eligibility.AjaxMethods,AjaxMethods.ashx"></script>-->

<script language="javascript">
		var uniid;
		uniid = <%=Classes.clsGetSettings.UniversityID%>
		
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
    <table id="Table4" cellspacing="0" width="100%" border="0">
        <!--<TR>
									<TD colspan="3" align="right" height="20"></TD>
								</TR>-->
        <tr>
            <td style="width: 952px" align="center" colspan="3">
                <!-- Selection Starts -->
                <fieldset id="tblSelect" style="width: 700px; height: 100px" runat="server">
                    <legend><strong>Search Student(s)</strong></legend>
                    <table cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td align="right" width="20%">
                                <b>
                                    <asp:Label ID="lblCollegeType" runat="server" Text="College Type" meta:resourcekey="lblCollegeTypeResource1"></asp:Label></b></td>
                            <td align="center" width="1%">
                                <b>:</b></td>
                            <td>
                                <asp:RadioButtonList ID="rdbtnInstType" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow" ForeColor="Navy" Font-Bold="True" meta:resourcekey="rdbtnInstTypeResource1">
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                <b>
                                    <asp:Label ID="lblCollegeName" runat="server" Text="College Name" meta:resourcekey="lblCollegeNameResource1"></asp:Label>
                                </b>
                            </td>
                            <td align="center" width="1%">
                                <b>:</b></td>
                            <td>
                                <asp:TextBox ID="Inst_Name" runat="server" MaxLength="300" Width="395px" CssClass="inputbox"
                                    meta:resourcekey="Inst_NameResource1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                <b>
                                    <asp:Label ID="lblCollegeState" runat="server" Text="College State" meta:resourcekey="lblCollegeStateResource1"></asp:Label>
                                </b>
                            </td>
                            <td align="center" width="1%">
                                <b>:</b></td>
                            <td>
                                <b>
                                    <asp:DropDownList ID="State_ID" runat="server" Width="184px" CssClass="selectbox"
                                        onchange="setValue(hid_state_id,this.value); FillDistricts(this.value,'E'); RemoveAllOptions(ddl_tehsil_id);"
                                        meta:resourcekey="State_IDResource1">
                                    </asp:DropDownList></b></td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                <b>
                                    <asp:Label ID="lblCollegeDistrict" runat="server" Text="College District" meta:resourcekey="lblCollegeDistrictResource1"></asp:Label></b></td>
                            <td align="center" width="1%">
                                <b>:</b></td>
                            <td>
                                <asp:DropDownList ID="District_ID" runat="server" Width="184px" CssClass="selectbox"
                                    onchange="setValue(hid_district_id,this.value);FillTehsils(this.value,'E');"
                                    meta:resourcekey="District_IDResource1">
                                </asp:DropDownList>&nbsp; <b>
                                    <asp:Label ID="lblCollegeTehsil" runat="server" Text="College Tehsil" meta:resourcekey="lblCollegeTehsilResource1"></asp:Label>
                                    : </b>
                                <asp:DropDownList ID="Tehsil_ID" onblur="setValue(hid_tehsil_id,this.value);" runat="server"
                                    Width="152px" CssClass="selectbox" meta:resourcekey="Tehsil_IDResource1">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 901px" align="right" colspan="3">
                                <b>&nbsp;</b></td>
                        </tr>
                    </table>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="right" width="21%">
                                <b>
                                    <asp:Label ID="lblFaculty" runat="server" Text="Faculty" meta:resourcekey="lblFacultyResource1"></asp:Label>
                                    :&nbsp;</b></td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlFaculty" runat="server" Width="260px" CssClass="selectbox"
                                    onchange="setValue(hid_Fac_id,this.value); FillCourse(this.value);" meta:resourcekey="ddlFacultyResource1">
                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">--- Select ---</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" width="21%">
                                <b>
                                    <asp:Label ID="lblCourse" runat="server" Text="Course" meta:resourcekey="lblCourseResource1"></asp:Label>
                                    :&nbsp;</b></td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlCourse" runat="server" Width="260px" CssClass="selectbox"
                                    onchange="setValue(hid_Cr_id,this.value); FillCoursePart(this.value);" meta:resourcekey="ddlCourseResource1">
                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource2">--- Select ---</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" width="21%">
                                <b>
                                    <asp:Label ID="lblCrPart" runat="server" Text="Course Part" meta:resourcekey="lblCrPartResource1"></asp:Label>
                                    :&nbsp;</b></td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlCoursePart" runat="server" Width="260px" CssClass="selectbox"
                                    onchange="setIDValues(this.value);" meta:resourcekey="ddlCoursePartResource1">
                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource3">--- Select ---</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" width="21%">
                                <b>Date of Birth :&nbsp;</b></td>
                            <td width="39%">
                                <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" CssClass="inputbox" ReadOnly="True"
                                    meta:resourcekey="txtDOBResource1"></asp:TextBox>&nbsp; <a id="alinkCalender" onclick="return showCalendar(txt_DOB, '%d/%m/%Y');"
                                        runat="server">
                                        <img onmouseover="this.style.cursor='Hand'" src="../images/cal.gif" align="middle"></a>&nbsp;
                                [dd/mm/yyyy]</td>
                            <td align="right" width="20%">
                                <b>Gender :&nbsp;</b></td>
                            <td width="20%">
                                <asp:DropDownList ID="ddlGender" CssClass="selectbox" runat="server" meta:resourcekey="ddlGenderResource1">
                                    <asp:ListItem Value="0" Selected="True" meta:resourcekey="ListItemResource4">--- Select ---</asp:ListItem>
                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource5">Male</asp:ListItem>
                                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource6">Female</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" width="21%">
                                <b>Last Name :&nbsp;</b></td>
                            <td width="39%">
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="inputbox" meta:resourcekey="txtLastNameResource1"></asp:TextBox></td>
                            <td align="right" width="20%">
                                <b>First Name :&nbsp;</b></td>
                            <td width="20%">
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputbox" meta:resourcekey="txtFirstNameResource1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <br>
                                <asp:Button ID="btnSearch" runat="server" Width="70px" CssClass="butSubmit" BorderWidth="1px"
                                    BorderStyle="Solid" Text="Search" Height="18px" OnClick="btnSearch_Click" meta:resourcekey="btnSearchResource1">
                                </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;<input class="butSubmit" id="btnClear" onclick="fnClearSearchCriteria();"
                                    type="button" value="Clear Search Criteria" runat="server" width="70px" height="18px"></td>
                        </tr>
                    </table>
                </fieldset>
                <p style="margin-top: 10px; margin-bottom: 1px; margin-left: 0px" align="center">
                    <asp:Label ID="lblGridName" Style="display: none" runat="server" Width="99%" CssClass="GridSubHeading"
                        Height="18px" meta:resourcekey="lblGridNameResource1"></asp:Label></p>
                <p style="margin-top: 0px; margin-bottom: 0px; margin-left: 0px" align="center">
                    &nbsp;</p>
                <div id="divDGNote" style="display: none" align="left" runat="server">
                    <font color="red">* Please click on the student name to view his/her respective profile.</font></div>
            </td>
        </tr>
        <tr>
            <td style="width: 953px" align="center" colspan="3" height="30">
                <table id="tblDGElgRegular" style="display: none" width="100%" runat="server">
                    <tr>
                        <td style="height: 205px">
                            <asp:GridView ID="dgElgRegular1" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                AllowPaging="True" BorderColor="#336699" AutoGenerateColumns="False" OnPageIndexChanging="dgElgRegular1_PageIndexChanging"
                                OnRowCommand="dgElgRegular1_RowCommand" OnRowDataBound="dgElgRegular1_RowDataBound"
                                meta:resourcekey="dgElgRegular1Resource1">
                                <RowStyle CssClass="gridItem"></RowStyle>
                                <HeaderStyle CssClass="gridHeader" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <%# (Container.DataItemIndex)+1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Eligibility_Form_No" ReadOnly="True" HeaderText="Eligibility Form No"
                                        meta:resourcekey="BoundFieldResource1">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:ButtonField Text="Button" DataTextField="StudentName" HeaderText="Student Name"
                                        CommandName="StudentDetails" meta:resourcekey="ButtonFieldResource1">
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:ButtonField>
                                    <asp:BoundField DataField="InstituteName" ReadOnly="True" HeaderText="College Name"
                                        meta:resourcekey="BoundFieldResource2">
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
                                    <asp:BoundField DataField="pk_CrMoLrnPtrn_ID" HeaderText="pkCrMoLrnPtrnID" meta:resourcekey="BoundFieldResource5">
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
            <td style="width: 953px" align="center" colspan="3" height="30">
                <table id="tblDGRegPendingStudents" style="display: none" width="100%" runat="server">
                    <tr>
                        <td>
                            <asp:GridView ID="dgRegPendingStudents1" runat="server" Width="100%" BorderWidth="1px" CssClass="clGrid grid-view"
                                BorderStyle="Solid" AllowPaging="True" BorderColor="#336699" AutoGenerateColumns="False"
                                OnPageIndexChanging="dgRegPendingStudents1_PageIndexChanging" OnRowCommand="dgRegPendingStudents1_RowCommand"
                                OnRowDataBound="dgRegPendingStudents1_RowDataBound" meta:resourcekey="dgRegPendingStudents1Resource1">
                                <RowStyle CssClass="gridItem"></RowStyle >
			                     <HeaderStyle CssClass="gridHeader">
                                 </HeaderStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <%# (Container.DataItemIndex)+1 %>
                                            .
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Eligibility_Form_No" ReadOnly="True" HeaderText="Eligibility Form No"
                                        meta:resourcekey="BoundFieldResource6">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:ButtonField Text="Button" DataTextField="StudentName" HeaderText="Student Name"
                                        CommandName="PendingStudentDetails" meta:resourcekey="ButtonFieldResource2"></asp:ButtonField>
                                    <asp:BoundField DataField="InstituteName" ReadOnly="True" HeaderText="College Name"
                                        meta:resourcekey="BoundFieldResource7"></asp:BoundField>
                                    <asp:BoundField DataField="CourseName" ReadOnly="True" HeaderText="Course Admitted To"
                                        meta:resourcekey="BoundFieldResource8"></asp:BoundField>
                                    <asp:BoundField DataField="DocCount" HeaderText="No of Documents Submitted" meta:resourcekey="BoundFieldResource9">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkYear" ReadOnly="True" HeaderText="pkYear" meta:resourcekey="BoundFieldResource10">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkStudentID" ReadOnly="True" HeaderText="pkStudentID"
                                        meta:resourcekey="BoundFieldResource11"></asp:BoundField>
                                    <asp:BoundField DataField="pkCrMoLrnPtrnID" ReadOnly="True" HeaderText="pkCrMoLrnPtrnID"
                                        meta:resourcekey="BoundFieldResource12"></asp:BoundField>
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
        runat="server">
    <input id="hidInstID" style="width: 24px; height: 22px" type="hidden" name="hidInstID"
        runat="server">
    <input id="hidStateID" style="width: 24px; height: 22px" type="hidden" name="hidStateID"
        runat="server">
    <input id="hidDistrictID" style="width: 24px; height: 22px" type="hidden" name="hidDistrictID"
        runat="server">
    <input id="hidTehsilID" style="width: 24px; height: 22px" type="hidden" name="hidTehsilID"
        runat="server">
    <input id="hidFacID" style="width: 40px; height: 22px" type="hidden" value="0" name="hidFacID"
        runat="server">
    <input id="hidCrID" style="width: 40px; height: 22px" type="hidden" value="0" name="hidCrID"
        runat="server">
    <input id="hidCr_MLrnPtrnID" style="width: 40px; height: 22px" type="hidden" value="0"
        name="hidCr_MLrnPtrnID" runat="server">
    <input id="hidCrPrID" style="width: 40px; height: 22px" type="hidden" value="0" name="hidCrPrID"
        runat="server">
    <input id="hidElgFormNo" type="hidden" value="0" name="hidElgFormNo" runat="server">
    <input id="hidpkStudentID" type="hidden" value="0" name="hidpkStudentID" runat="server">
    <input id="hidCrMoLrnPtrnID" style="width: 40px; height: 22px" type="hidden" value="0"
        name="hidCrMoLrnPtrnID" runat="server">
    <input id="hidStep" type="hidden" name="hidStep" runat="server">
    <input id="hidpkYear" type="hidden" value="0" name="hidpkYear" runat="server">
    <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none" meta:resourcekey="lblUniversityResource1"></asp:Label>
    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>

</center>
