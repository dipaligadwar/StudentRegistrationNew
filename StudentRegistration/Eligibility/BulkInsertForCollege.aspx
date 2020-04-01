<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkInsertForCollege.aspx.cs" Inherits="StudentRegistration.Eligibility.BulkInsertForCollege" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="../Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainLink" Src="../SideLinks.ascx" %>
<%@ Register TagPrefix="uc1"  TagName="topLink" Src="../InnerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="StudentsAdvancedSearch" Src="WebCtrl/StudentsAdvancedSearch.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Digital University - Student Registration</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../JS/header.js"></script>
		<script language="javascript" src="../JS/footer.js"></script>
		<script language="javascript" src="../JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="../JS/change.js"></script>
		<script language="javascript" src="../JS/jscript_validations.js"></script>
		<script language="javascript" src="../JS/jsAjaxMethod.js"></script>
		<script language="javascript" src="../JS/CommonFunctions.js"></script>
		
		<script language="javascript" src="ajax/common.ashx"></script>
        <script language="javascript" src="ajax/Classes.clsAjaxMethods,StudentRegistration.ashx"></script>
        
		<script language="javascript">
		    function fillCoursePart(val)
		    {
		        FillCoursePart('tbCrPr',val,'DD_CoursePart',0);
	            document.getElementById("<%=hidCrMoLrnPtrnID.ClientID%>").value = val;
		    }
		    
		    function setCrPart(val)
            { 
	            document.getElementById("<%=hidCrPrID.ClientID%>").value = val;
	            
            }
		    
		    
		    function ShowGrid()
		    {
		        document.getElementById("tblGrid").style.display = "inline";
		    }
		    
		    function fnConfirm()
		    {
		        var ch;
		        if(document.getElementById("tblUniversity").style.display=="inline")
		        {
		            ch=confirm('Are you sure you want to mark all student as \"Eligible\" ?');
		            if(ch==false)
		            {
		                return false;
		            }
		        }
		        /*else if(document.getElementById("tblPRN").style.display=="none" && document.getElementById("tblCollege").style.display=="none")
		        {
		            document.getElementById("btnSave").Enabled=true;
		            return false;
		        }*/
		        
		    }
		    
		    function fnValidate()
		    {
		        var i=-1;
				var myArr= new Array();
				
			    myArr[++i]= new Array(document.getElementById("DD_Course"),"0","Select Course","select");
			    myArr[++i]= new Array(document.getElementById("DD_CoursePart"),"0","Select Course Part","select");
			    
				var ret=validateMe(myArr,50);
				return ret;
		    }
		    
		    function openNewWindow(UniId,Year,InstID,StudID)
		    {
		        
		        /*alert("UniId = "+UniId);
		        alert("Year = "+Year);
		        alert("InstID = "+InstID);
		        alert("StudID = "+StudID);
		        
		        alert("ElgFormNo = "+ElgFormNo);*/
		        var ElgFormNo= UniId+'-'+InstID+'-'+Year+'-'+StudID;
		        window.open("BulkInsert_Uni_StudentStatus.aspx?ElgFormNo="+ElgFormNo+"&UniID="+UniId+"&Year="+Year+"&InstID="+InstID+"&StudID="+StudID+"","_blank","height=300,width=700,status=yes,toolbar=no,menubar=no,location=no,scrollbars =yes,left=250,top=300,screenX=0,screenY=400'");
		        return false;
		    }
		    
		    function fnCheck()
		    {
		        var bul=false;
		        if(document.getElementById("DG_University") != null)
		        {
		        var tbl=document.getElementById("DG_University").getElementsByTagName("INPUT");
		        for(i=0;i<tbl.length;i++)
		        {
		            if(tbl[i].checked)
		            {
		               bul=true;
					   break;
		            }
		        }
		        
		        if(bul)
				    return true;
			    else
			    {
				    alert("To process Eligibility of the students please select checkboxes from the list below and click on save button");
				    return false;
			    }
			    }
		        
		    }
		</script>
		
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div align=center>
				<!-- Header Starts--><uc1:toplink id="TopLink1" runat="server"></uc1:toplink><!-- Header Ends-->
				<table height="48" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<tr height="3">
						<td vAlign="middle" align="center"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
					<tr height="10">
						<td vAlign="middle" align="center" width="10%" rowSpan="2"><IMG height="45" src="../images/CoomingSoon.gif" width="45"></td>
						<td vAlign="top" width="40%"><asp:label id="lblTitle" runat="server" CssClass="PageHeading" Font-Bold="True" Height="8px" ForeColor="Tomato">Bulk Process Data</asp:label>
                            <asp:Label ID="lblInstName" runat="server" Font-Bold="True"></asp:Label>
                            <br /><br />
                            <table border="0" width="100%" style="BORDER-COLLAPSE: collapse;display:none" id="tblLink" runat="server">
	                            <tr>
		                            <td class="InnerLinkBorder" valign="middle" align="center"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
	                            </tr>
	                            <tr>
		                            <td>
			                            <asp:linkbutton id="lnkSelectCr" cssclass="NavLink" runat="server" OnClick="lnkSelectCr_Click">Select Course</asp:linkbutton>&nbsp;|&nbsp;
			                            <asp:linkbutton id="lnkPRN" cssclass="NavLink" runat="server" OnClick="lnkPRN_Click">View Eligible Students With PRN</asp:linkbutton>
		                            </td>
	                            </tr>
                            </table>
                        </td>
    				</tr>
					<TR>
						<TD id="TDLink" style="DISPLAY: none" runat="server"></TD>
					</TR>
					<tr>
						<td class="FormName" vAlign="middle" align="center" colSpan="3"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
				</table>
				<!-- Heading Ends-->
				<!-- Main Starts-->
				<table cellSpacing="0" cellPadding="0" width="90%" border="0" height="100%">
					<TBODY>
						<tr>
							<td class="SideLeft" vAlign="top" align="left" width="18%"> <!--Menu Start Here-->
								<P><uc1:mainlink id="MainLink1" runat="server"></uc1:mainlink></P>
								<!--Menu Ends Here--></td>

							<td vAlign="top" align="left" width="2%">&nbsp;</td>
							
							<td vAlign="top" align="left" width="80%">
                            
							<table cellSpacing="1" cellPadding="0" width="100%" border="0" id="tblToolBarMain" runat=server>
							    <tr>
								    <td>
									 
										    <table class="ToolBar" id="tblToolBar" cellSpacing="1" cellPadding="0" width="100%" border="0" runat="server">
											    <tr>
												    <td align="center" width="10%"><IMG height="16" src="../images/button_new.gif" width="16" border="0">
													    <asp:button id="btnNew" runat="server" CssClass="But" Text="New" OnClick="btnNew_Click"></asp:button></td>
												    <td align="center" width="10%"><IMG height="16" src="../images/button_save.gif" width="16" border="0">
													    <asp:button id="btnSave" runat="server" CssClass="But" Text="Save" OnClick="btnSave_Click" Enabled=false></asp:button></td>
												    <td align="center" width="10%"><IMG height="16" src="../images/button_delete.gif" width="16" border="0">
													    <asp:button id="btnDelete" runat="server" CssClass="But" Text="Delete" Enabled=false></asp:button></td>
												    <td align="center" width="7%">&nbsp;</td>
												    <td align="center" width="10%"><IMG height="16" src="../images/button_reset.gif" width="16" border="0"><input class="But" title="Reset" accessKey="R" tabIndex="4" type="reset" value="Reset"
														    name="Reset" disabled></td>
												    <td align="right">&nbsp;</td>
											    </tr>
										    </table>
									   
								    </td>
							    </tr>
						    </table>
						    <p style="MARGIN: 0px 5px" align="right">
                             <table width="95%" cellpadding="0" cellspacing="0" border="0" id="tblUserControl" runat="server">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                             </table>
                             <table width="95%" cellpadding="0" cellspacing="0" border="0" id="tblMainTable" runat="server">
                                <tr>
                                    <td align="right" colspan="3" height="5px">
                                        <asp:Label ID="lblSave" runat="server" CssClass="SaveNote"></asp:Label></td>
                                </tr>
                                <tr id="trCourse" runat="server">
                                    <td colspan="3">
                                        <fieldset>
                                        <table width="100%">
                                            <tr class="GridSubHeading" width="80%">
												<td class="PersonalTableHeader" vAlign="top" align="left" colSpan="5"><b>Select Course</b></td>
											</tr>
                                            <tr height="10px">
                                                <td width="30%" align=right><b>Select Course</b></td>
                                                <td width="1%"><b>:</b></td>
                                                <td height="10px">
                                                    <asp:dropdownlist id="DD_Course" runat="server" CssClass="SelectBox" onchange="fillCoursePart(this.value);"></asp:dropdownlist>
                                                    <font class="Mandatory">*</font></td>
                                            </tr>
                                           
                                            <tr>
                                                <td width="30%" align=right><b>Select Course Part</b></td>
                                                <td width="1%"><b>:</b></td>
                                                <td height="10px"  id="tbCrPr">
                                                    <asp:dropdownlist id="DD_CoursePart" runat="server" CssClass="SelectBox" onchange="setCrPart(this.value);"></asp:dropdownlist>
                                                    <font class="Mandatory">*</font></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" height="10px"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align=center style="height: 15px">
                                                    <asp:Button ID="btnProcessData" runat="server" CssClass="butSubmit" BorderWidth="1px"
									                BorderStyle="Solid" Text="Submit" Height="18px" OnClick="btnProcessData_Click"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" height="10px"></td>
                                            </tr>
                                             <tr>
                                                <td align="center" colspan="3" height="10px">
                                                    <asp:Label ID="lblRights" runat="server" Font-Bold="True" CssClass="errorNote"></asp:Label></td>
                                            </tr>
                                        </table>
                                        </fieldset>
                                    </td>
                                 </tr>
                                 <tr>
                                    <td height="5px"></td>
                                 </tr>
                                <tr id="trStatistics" runat="server" style="display:none">
                                    <td>
                                        <fieldset>
                                            <table width="100%">
                                            <tr class="GridSubHeading" width="80%">
												<td class="PersonalTableHeader" vAlign="top" align="left" colSpan="5"><b>Statistics of Records</b></td>
											</tr>
                                            <tr>
                                                <td colspan="4"><p style="MARGIN: 0px 35px" align="left"> <asp:label id="lblStatistics" runat="server" CssClass="errorNote"></asp:label></p></td>
                                            </tr>
                                           
                                            <tr>
                                                <td colspan="4" align="center">
                                                    <table id="tblStatistics" width="90%" border="0" style="border-collapse:collapse;display:none" cellpadding="0" runat="server">
                                                        <tr>
                                                            <td width="40%" align="center" height="20px" Class="gridHeader"><b>Eligibility Process</b></td>
                                                            <td width="30%" align="center" height="20px" Class="gridHeader"><b>No. of students<br />(Eligibility payment received)</b></td>
                                                            <td width="30%" align="center" height="20px" Class="gridHeader"><b>No. of students<br />(Eligibility payment not received)</b></td>
                                                            
                                                        </tr>
                                                        <tr class="gridItem">
                                                            <td height="20px">Students whose eligibility is to be decided by university</td>
                                                            <td align="center" height="20px"><asp:Label ID="lblUniCount" runat="server"></asp:Label></td>
                                                            <td align="center" height="20px"><asp:Label ID="lblNonPaidUniCount" runat="server"></asp:Label></td>
                                                        </tr>
                                                         <tr Class="gridAltItem">
                                                            <td Class="gridAltItem" height="20px">Students eligible at college</td>
                                                            <td Class="gridAltItem" align="center" height="20px"><asp:Label ID="lblCollCount" runat="server"></asp:Label></td>                                              
                                                            <td Class="gridAltItem" align="center" height="20px"><asp:Label ID="lblNonPaidCollCount" runat="server"></asp:Label></td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="3" height="25px" align="center"><asp:Label ID="lblNoRecords" runat="server" CssClass="errorNote"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 13px" colspan="3">
                                                                <asp:Label ID="lblInfoNote" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            </table>
                                         </fieldset>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td colspan="3" height="5px"></td>
                                 </tr>
                                 <tr id="trGrids" runat="server" style="display:none">
                                    <td>
                                        <fieldset>
                                        <table width="100%">
                                            <tr class="GridSubHeading" width="80%" style="display:none" id="trGridHeader" runat=server>
										        <td class="PersonalTableHeader" vAlign="top" align="left" colSpan="5"><asp:Label ID="lblUniCollPrn" runat="server" Font-Bold="True"></asp:Label></td>
											</tr>
                                            <tr>
                                                <td colspan="3">
                                                    <br/>
                                                    <p style="MARGIN: 0px 10px" align="left"><asp:Label ID="lblUnselectCheck" runat="server" Font-Bold="True"></asp:Label></p>
                                                    <br/>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align=center>
                                                    <asp:datagrid id="DG_University" runat="server" width="95%" autogeneratecolumns="False" visible="False" OnItemDataBound="DG_University_ItemDataBound" AllowPaging="True" DataKeyField="pk_Student_ID" OnPageIndexChanged="DG_University_PageIndexChanged" OnItemCommand="DG_University_ItemCommand" PageSize="50">
											            <AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
											            <ItemStyle CssClass="gridItem"></ItemStyle>
											            <Columns>
												            <asp:boundcolumn headertext="Sr.No.">
										                        <headerstyle font-bold="True" wrap="False" horizontalalign="Center" width="5%" CssClass="gridHeader"></headerstyle>
										                        <itemstyle horizontalalign="Center" verticalalign="Middle"></itemstyle>
									                        </asp:boundcolumn>
												            <asp:BoundColumn DataField="EligibilityFormNo" HeaderText="Eligibility Form No.">
													            <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
												            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="pk_Invoice_ID" HeaderText="Invoice Number">
                                                                <HeaderStyle Font-Bold="True" Width="20%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="studName" HeaderText="Name of Student">
													            <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
												            </asp:BoundColumn>
												            <asp:TemplateColumn HeaderText="Select">
													            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></ItemStyle>
													            <ItemTemplate>
														            <asp:CheckBox runat="server" ID="chkSelect" Name="chkSelect"/>
													            </ItemTemplate>
													            <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center Width="5%" />
												            </asp:TemplateColumn>
												            <asp:BoundColumn DataField="pk_Uni_ID" HeaderText="pk_Uni_ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="pk_Year" HeaderText="pk_Year" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="pk_Institute_ID" HeaderText="pk_Institute_ID" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="pk_Student_ID" HeaderText="pk_Student_ID" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="pk_CrMoLrnPtrn_ID" HeaderText="pk_CrMoLrnPtrn_ID" Visible="False">
                                                            </asp:BoundColumn>
											            </Columns>
											            <PagerStyle Mode="NumericPages" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right"></PagerStyle>
										            </asp:datagrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3"><p style="MARGIN: 0px 20px" align="left"><asp:Label ID="lblCollege" runat="server" Font-Bold="True"></asp:Label></p></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3"><p style="MARGIN: 0px 20px" align="left"><asp:Label ID="lblDisplayNote" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></p></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align=center>
                                                     <asp:datagrid id="DG_College" runat="server" width="95%" autogeneratecolumns="False" visible="False" OnItemDataBound="DG_College_ItemDataBound" AllowPaging="True" OnPageIndexChanged="DG_College_PageIndexChanged" PageSize="50">
								                        <AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
								                        <ItemStyle CssClass="gridItem"></ItemStyle>
								                        <Columns>
									                        <asp:boundcolumn headertext="Sr.No.">
							                                    <headerstyle font-bold="True" wrap="False" horizontalalign="Center" width="5%" CssClass="gridHeader"></headerstyle>
							                                    <itemstyle horizontalalign="Center" verticalalign="Middle"></itemstyle>
						                                    </asp:boundcolumn>
									                        <asp:BoundColumn DataField="EligibilityFormNo" HeaderText="Eligibility Form No.">
										                        <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
									                        </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="pk_Invoice_ID" HeaderText="Invoice Number">
                                                                <HeaderStyle Font-Bold="True" Width="20%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
                                                            </asp:BoundColumn>
									                        <asp:BoundColumn DataField="studName" HeaderText="Name of Student">
										                        <HeaderStyle Font-Bold="True" Width="50%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
									                        </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="pk_Uni_ID" HeaderText="pk_Uni_ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="pk_Year" HeaderText="pk_Year" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="pk_Institute_ID" HeaderText="pk_Institute_ID" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="pk_Student_ID" HeaderText="pk_Student_ID" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="pk_CrMoLrnPtrn_ID" HeaderText="pk_CrMoLrnPtrn_ID" Visible="False">
                                                            </asp:BoundColumn>
								                        </Columns>
								                        <PagerStyle Mode="NumericPages" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right"></PagerStyle>
							                        </asp:datagrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3"><asp:Label ID="lblPRN" runat="server" Font-Bold="True"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align=center>
                                                      <asp:datagrid id="DG_PRN" runat="server" width="95%" autogeneratecolumns="False" visible="False" OnItemDataBound="DG_PRN_ItemDataBound">
											            <AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
											            <ItemStyle CssClass="gridItem"></ItemStyle>
											            <Columns>
												            <asp:boundcolumn headertext="Sr.No.">
										                        <headerstyle font-bold="True" wrap="False" horizontalalign="Center" width="5%" CssClass="gridHeader"></headerstyle>
										                        <itemstyle horizontalalign="Center" verticalalign="Middle"></itemstyle>
									                        </asp:boundcolumn>
												            <asp:BoundColumn DataField="EligibilityFormNo" HeaderText="Eligibility Form No.">
													            <HeaderStyle Font-Bold="True" Width="25%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
												            </asp:BoundColumn>
												            <asp:BoundColumn DataField="StudName" HeaderText="Name of Student">
													            <HeaderStyle Font-Bold="True" Width="40%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
												            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="PRN_Number" HeaderText="PRN Number">
													            <HeaderStyle Font-Bold="True" Width="30%" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
												            </asp:BoundColumn>
											            </Columns>
										            </asp:datagrid>
                                                </td>
                                            </tr>
                                        </table>
                                        </fieldset>
                                    </td>
                                 </tr>
                                 <tr>
                                    <td height="20px"></td>
                                 </tr>
                             </table>
						   
						   
							</td>
						</tr>
						<TR>
						            <TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					            </TR>
					</TBODY>
				</table>
				<!-- Footer Starts--><uc1:footer id="Footer1" runat="server"></uc1:footer><!-- Footer Ends-->
			</div>
			
			<input id="hidInstID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidInstID" runat="server"/>
            <input id="hidUniID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidUniID" runat="server"/>
            <input id="hid_Year" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hid_Year" runat="server"/>
            <input id="hidStudentID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidStudentID" runat="server"/>
            <input id="hidCrMoLrnPtrnID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidCrMoLrnPtrnID" runat="server"/>
            <input id="hidCrID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidCrID" runat="server"/>
            <input id="hidCrPrID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidCrPrID" runat="server"/>
            <input id="hidYear" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidYear" runat="server"/>
            <input id="hidCollege_Eligibility_Flag" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidCollege_Eligibility_Flag" runat="server"/>
            <input id="hidRightsFlag" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidRightsFlag" runat="server"/>
            
		</form>
	</body>
</HTML>
