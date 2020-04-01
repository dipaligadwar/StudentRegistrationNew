<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigureEligibilityRights.aspx.cs" Inherits="StudentRegistration.Eligibility.ConfigureEligibilityRights" %>
<%@ Register TagPrefix="uc1"  TagName="topLink" Src="../InnerHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainLink" Src="../SideLinks.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="../Footer.ascx" %>
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
		<script language="javascript" src="../JS/jsAjaxMethod.js"></script>
		<script language="javascript" src="../JS/jscript_validations.js"></script>
		<script language="javascript" src="../JS/Validations.js"></script>
		<script language="javascript" src="ajax/common.ashx"></script>
		<script language="javascript" src="ajax/Classes.clsAjaxMethods,StudentRegistration.ashx"></script>
		<script language="javascript">
		function fnSaveValidate()
		{
		   					
		    var i=-1;
			var myArr= new Array();	
			var ret = false;	
					
			if(document.getElementById("chkCourse_0").checked == true ||document.getElementById("chkCourse_1").checked == true)			
			{
				
				    if(document.getElementById("chkCourse_1").checked == true)
			        {			       
			             myArr[++i]= new Array(document.getElementById("dd_Fac_Desc"),"0","Select Faculty","select");
			             myArr[++i]= new Array(document.getElementById("dd_Cr_Desc"),"0","Select Course","select");
			             myArr[++i]= new Array(document.getElementById("dd_ModeLrn_Desc"),"0","Select Mode Of Learning","select");
           	             myArr[++i]= new Array(document.getElementById("dd_CrPtrn_Desc"),"0","Select Course Pattern","select");                           	        			       	    	     
			       	     var ret=validateMe(myArr,50); 
			       	     if(!ret)
			       	     {
			       	     return false;   
			       	     }
			        } 
	                 if(document.getElementById("rdConfigureRights_0").checked == true || document.getElementById("rdConfigureRights_1").checked == true)
                     {
                        ret = true;
                     }
                     else
                     {
                         alert("Select College or University");
                         ret = false;
                     }
			           
						
			}										
			else
			{
			   if(document.getElementById("rdConfigureRights_0").checked == true || document.getElementById("rdConfigureRights_1").checked == true)
				{
				alert("Select Course");
				ret = false;
				}
				else
				{
			    alert("Correct the following errors \n 1.Select Eligibility rights For Courses \n 2.Select rights to College or University ");			 		   
			    ret = false;
			    }
			}
			
			return ret;
			
		
		}
	    function fnChkCourse()
	    {
	        document.getElementById("lblNote").innerText="";
	        var num=0;
			var selIndex=0;				
	        while(typeof(document.getElementById("chkCourse_"+num)))
			{	
			    if((document.getElementById("chkCourse_"+num).checked))				
				{
				    if(document.getElementById("chkCourse_"+num).value == "1")
				    {
				   
	    		        tblSelectCr.style.display = "inline";
	    		        //trlblCourse.style.display="none";
	    		        document.getElementById("hidEditAdd").value = "1"; 
	    		         		        	    		          
				        
				    }
				    else
				    {
				       tblSelectCr.style.display = "none"; 
				       //trlblCourse.style.display="none";
				       
				       
				       document.getElementById("dd_Fac_Desc").value = "0";
				       document.getElementById("dd_Cr_Desc").value = "0";
				       document.getElementById("dd_ModeLrn_Desc").value = "0";
				       document.getElementById("dd_CrPtrn_Desc").value = "0";
				       document.getElementById("hidEditAdd").value = "0";
				       
				       document.getElementById("hidFacID").value = "";
				       document.getElementById("hidCrID").value = "";
   				       document.getElementById("hidMoLrnID").value = "";
  				       document.getElementById("hidCrPtrnID").value = "";
  				       document.getElementById("hidCrMoLrnPtrnID").value = "";    

				       

				       
 				    }
				    break;
				}					
				num++;			
				
			}
			
			
	    }
	        
	    
	    function fnDisplay()
	    {
	        if(trlblCourse.style.display=="inline")
	        {
	            document.getElementById("lblNote").innerText="Record Saved Successfully";
	            trlblCourse.style.display="inline"
	            trCrGrid.style.display="inline";
	        }
	        else
	        {
	            document.getElementById("lblNote").innerText="Record Saved Successfully";
	            trlblCourse.style.display="inline"
	          
	        }
	    }
	    function setValue(Text,Value)
		{
			var text = eval(document.getElementById(Text));
			text.value = Value;		
		}
		function FillCourseDD(val)
		{
		    FillCourseName('TcCrNmID',val,'dd_Cr_Desc');
		    document.getElementById("<%=hidFacID.ClientID%>").value = val;  
		
		}		
	    function FillMoLrnDD(val)
	    {	
	        
	       FillModeOfLearning('TcMOLID',val,'dd_ModeLrn_Desc');
           document.getElementById("<%=hidCrID.ClientID%>").value = val;  
         
	    }
        function FillCrMoLrnWisePatternDD(val)
	    {
	       FillCoursePattern('TcCrPtrID',val,'dd_CrPtrn_Desc') 	
	      // document.getElementById("<%=hidMoLrnID.ClientID%>").value = val;	
	       document.getElementById("<%=hidCrMoLrnID.ClientID%>").value = val; 
	      
	    }
	    function SetHiddenCoursePattern(val)
	    {
	    //document.getElementById("<%=hidCrPtrnID.ClientID%>").value = val;
	    document.getElementById("<%=hidCrMoLrnPtrnID.ClientID%>").value = val;	   
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
					<tr height="15">
						<td vAlign="middle" align="center" width="10%" rowSpan="2"><IMG height="45" src="../images/CoomingSoon.gif" width="45"></td>
						<td vAlign="top" width="40%"><asp:label id="lblTitle" runat="server" CssClass="PageHeading" Font-Bold="True" Height="8px"
								Width="99%" ForeColor="Tomato">Configure Eligibility Rights</asp:label></td>
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
				<table height="470" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<tbody>
						<tr>
							<td class="SideLeft" vAlign="top" align="left" width="18%"> <!--Menu Start Here-->
								<P><uc1:mainlink id="MainLink1" runat="server"></uc1:mainlink></P>
								<!--Menu Ends Here--></td>
							<td vAlign="top" align="left" width="2%">&nbsp;</td>
							<td vAlign="top" align="left" width="80%">							    
							        <table width="100%" cellpadding="0">
    							        <tr>
    							            <td colspan="4" align="right" height="10px">
                                                <asp:Label ID="lblNote" runat="server" Font-Bold="True" CssClass="SaveNote"></asp:Label></td>
    							        </tr>
    							         <tr>
						                    <td width="32%" align="right">Assign Eligibility Rights For</td>
						                    <td width="1%" align=center><b>:</b></td>
						                    <td>
                                                <asp:RadioButtonList ID="chkCourse" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                    <asp:ListItem Value="0" Text="All Courses"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Select Course"></asp:ListItem>
                                                </asp:RadioButtonList><FONT class="Mandatory">*</FONT></td>
						                </tr> 
						                <tr style="display:none"  id="tblSelectCr" runat="server">
						                <td colspan="4">
						                <table cellSpacing="0" cellPadding="0" width="100%" border="0">
								            <tr>
									            <td align="right" width="30%">Faculty Name</td>
									            <td width="3%" align="center"><b>:</b></td>
									            <td width="69%" colspan="2">
										            <asp:dropdownlist id="dd_Fac_Desc" runat="server" Width="300px" CssClass="selectbox" onblur="setValue('hidFacID',this.value)" 	onchange="FillCourseDD(this.value);">
										            </asp:dropdownlist>										            
										            <FONT class="Mandatory">*</FONT></td>
										            
								            </tr>
								            <tr height="5%">
								            <td colspan="4"></td>
								            </tr>
								            <tr>
									            <td align="right" width="30%">Select Course Name</td>
									             <td width="3%" align="center"><b>:</b></td>
									            <td width="69%" id="TcCrNmID" colspan="2">
									            <asp:dropdownlist id="dd_Cr_Desc"  runat="server" Width="184px" CssClass="selectbox" onchange="FillMoLrnDD(this.value);">
									            </asp:dropdownlist><FONT class="Mandatory">*</FONT>
									            </td>
								            </tr>
								             <tr height="5%">
								            <td colspan="4"></td>
								            </tr>
								            <TR>
									            <TD align="right" width="30%">Select Mode of Learning</TD>
									            <td width="3%" align="center"><b>:</b></td>
									            <TD width="69%" id="TcMOLID" colspan="2">
									            <asp:dropdownlist id="dd_ModeLrn_Desc" runat="server" Width="125px" CssClass="selectbox" onblur="setValue('hidCrMoLrnID',this.value)" onchange="FillCrMoLrnWisePatternDD(this.value);">
									            </asp:dropdownlist>
									            <FONT color="#ff0000">*</FONT>
									            </TD>
								            </TR>
								             <tr height="5%">
								            <td colspan="4"></td>
								            </tr>
								            <TR>
									            <TD align="right" width="30%">Select Course Pattern</TD>
									            <td width="3%" align="center"><b>:</b></td>
									            <TD width="29%" id="TcCrPtrID">
									            <asp:dropdownlist id="dd_CrPtrn_Desc" runat="server" Width="230px" CssClass="selectbox">
									            </asp:dropdownlist><FONT class="Mandatory">*</FONT>
									            </TD>
									            <td width="30%"></td>
								            </TR>								            
							            </table>
						                </td>
						                </tr>   					               
						                <tr>
                                            <td width="32%" align="right">Assign Eligibility Rights To</td> 
                                            <td width="1%" align="center"><b>:</b></td>
                                            <td>
                                                <asp:RadioButtonList ID="rdConfigureRights" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                    <asp:ListItem Value="0">University</asp:ListItem>
                                                    <asp:ListItem Value="1">College</asp:ListItem>
                                                </asp:RadioButtonList><FONT class="Mandatory">*</FONT>
                                            </td>
							            </tr>	        
						               <tr>
						                    <td height="10px" colspan="4"></td>
						                </tr>
						                
						                 <tr>
							                <td colspan="4" align="center" valign=middle>
                                                <asp:Button ID="btnProcess" Text="Assign Rights" runat="server" CssClass="butSubmit" OnClick="btnProcess_Click" />
                                               </td>                                                
							            </tr>	
							            <TR>
									            <TD align="right" width="30%">
										            <P align="left"><STRONG><I>Note:</I></STRONG> <FONT class="Mandatory">*</FONT> marked 
											            are mandatory...
										            </P>
									            </TD>
									            <TD width="1%"></TD>
									            <TD width="69%" colspan="2"></TD>
								         </TR>					                
						                <tr id="trlblCourse" style="display:inline" runat="server">
						                       <td align="left" colspan="4" width="99%">
						                       <p style="MARGIN-TOP: 10px; MARGIN-BOTTOM: 1px; MARGIN-LEFT: 0px" align="left">
									             <asp:Label ID="lblCrNote" runat="server" Text="" class="GridSubHeading"></asp:Label></p>
								            </td>
						                </tr> 
						                <tr><td align="center" colspan="4">
						                	<asp:datagrid CssClass="grid" id="DGCourseRights" runat="server" Width="99%" BorderStyle="Solid"
										AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699" AllowPaging="True" OnItemDataBound="DGCourseRights_ItemDataBound" OnPageIndexChanged="DGCourseRights_PageIndexChanged" OnItemCommand="DGCourseRights_ItemCommand" OnSortCommand="DGCourseRights_SortCommand" AllowSorting="True">
										<alternatingitemstyle cssclass="gridAltItem"></alternatingitemstyle>
											
										<Columns>
											<asp:BoundColumn ReadOnly="True" HeaderText="Sr.No.">
											    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
											    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pk_Fac_ID" HeaderText="pk_Fac_ID" Visible="False"></asp:BoundColumn>
											<asp:BoundColumn DataField="Fac_Desc" ReadOnly="True" HeaderText="Faculty">
												<ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
												<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pk_Cr_ID" HeaderText="pk_Cr_ID" Visible="False">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Cr_Desc" HeaderText="Course" SortExpression="Cr_Desc">
												<ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
												<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="pk_MoLrn_ID" HeaderText="Mode Of Learning" Visible="False">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MoLrn_Type" HeaderText="Mode Of Type" Visible="False">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>	
											<asp:BoundColumn DataField="pk_CrPtrn_ID" HeaderText="pk_CrPtrn_ID" Visible="False">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>	
											<asp:BoundColumn DataField="CrPtrn_Desc" HeaderText="CrPtrn_Desc" Visible="False">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>	
											<asp:BoundColumn DataField="Elg_Rights_Flag" HeaderText="Elg_Rights_Flag" Visible="False">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>																	
                                            <asp:BoundColumn DataField="Rights To" HeaderText="Rights To">
                                                <ItemStyle Width="10%" />
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="pk_CrMoLrn_ID" HeaderText="pk_CrMoLrn_ID" Visible="False"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="pk_CrMoLrnPtrn_ID" HeaderText="pk_CrMoLrnPtrn_ID" Visible="False"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="CollCount" HeaderText="College Count" Visible="False"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="UniCount" HeaderText="University Count" Visible="False">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Brn_Desc" HeaderText="Branch Name" Visible="False"></asp:BoundColumn>
                                            <asp:ButtonColumn CommandName="Edit" HeaderText="Edit" Text=" Edit ">
                                                <ItemStyle Width="5%" />
                                                <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
                                            </asp:ButtonColumn>
											
										</Columns>
										<PagerStyle Mode="NumericPages" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right"></PagerStyle>
									</asp:datagrid>
						              </td></tr>                      		                  
							            
							        </table>
                                <input id="hidUniID" runat="server" name="hidUniID" style="width: 32px; height: 22px"
                                    type="hidden" /><input id="hidInstID" runat="server" name="hidInstID" style="width: 32px;
                                        height: 22px" type="hidden" /><input id="hidFacID" runat="server" name="hidFacID"
                                            style="width: 32px; height: 22px" type="hidden" /><input id="hidCrLID" runat="server"
                                                name="hidCrLID" style="width: 32px; height: 22px" type="hidden" /><input id="hidPrgLID"
                                                    runat="server" name="hidPrgLID" style="width: 32px; height: 22px" type="hidden" /><input
                                                        id="hidPrgTyID" runat="server" name="hidPrgTyID" style="width: 32px; height: 22px"
                                                        type="hidden" /><input id="hidCrID" runat="server" name="hidCrID" style="width: 32px;
                                                            height: 22px" type="hidden" /><input id="hidCrMoLrnID" runat="server" name="hidCrMoLrnID"
                                                                style="width: 32px; height: 22px" type="hidden" /><input id="hidCrPtrnID" runat="server"
                                                                    name="hidCrPtrnID" style="width: 32px; height: 22px" type="hidden" /><input id="hidCrMoLrnPtrnID"
                                                                        runat="server" name="hidCrMoLrnPtrnID" style="width: 32px; height: 22px" type="hidden" /><input
                                                                            id="hidCrPrID" runat="server" name="hidCrPrID" style="width: 32px; height: 22px"
                                                                            type="hidden" /><input id="hidCrPrChID" runat="server" name="hidCrPrChID" style="width: 32px;
                                                                                height: 22px" type="hidden" />
                                <input id="hidCorseFlag" runat="server" name="hidCourseFlag" style="width: 32px;
                                                                                height: 22px" type="hidden" />
                                <input id="hidCollUniFlag" runat="server" name="hidCollUniFlag" style="width: 32px;
                                                                                height: 22px" type="hidden" />
                                <input id="hidEditAdd" runat="server" name="hidEditAdd" style="width: 32px;
                                                                                height: 22px" type="hidden" />
                                <input id="hidMoLrnID" runat="server" name="hidMoLrnID" style="width: 32px;
                                                                                height: 22px" type="hidden" />
                                <input id="hidTotal" runat="server" name="hidTotal" style="width: 32px;
                                                                                height: 22px" type="hidden" /></td>
						</tr>
						<TR>
						<TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					</TR>
					</tbody>
				</table>
				<!--Main Ends-->
				<!-- Footer Starts--><uc1:footer id="Footer1" runat="server"></uc1:footer><!-- Footer Ends-->
			</div>
		</form>
	</body>
</HTML>
