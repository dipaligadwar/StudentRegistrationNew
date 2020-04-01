<%@ Page language="c#" Codebehind="StudentStatus__1.aspx.cs" AutoEventWireup="True" Inherits="StudentRegistration.Eligibility.StudentStatus__1" %>
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
		<script language="javascript">
		var Rdiff=0;
var WinCollection = new Array()
var WinCtr=-1;
var ctrMin=0;
var ctrMax=0;

var dragObj = new Object();
dragObj.zIndex = 0;

function dragStart(event, id) 
{
  
  var el;
  var x, y;


  if (id)
    dragObj.elNode = document.getElementById(id);
  else 
      dragObj.elNode = window.event.srcElement;


    x = window.event.clientX + document.documentElement.scrollLeft
      + document.body.scrollLeft;
    y = window.event.clientY + document.documentElement.scrollTop
      + document.body.scrollTop;
  
    //window.scroll = "yes";


  dragObj.cursorStartX = x;
  dragObj.cursorStartY = y;
  dragObj.elStartLeft  = parseInt(dragObj.elNode.style.left, 10);
  dragObj.elStartTop   = parseInt(dragObj.elNode.style.top,  10);

  if (isNaN(dragObj.elStartLeft)) dragObj.elStartLeft = 0;
  if (isNaN(dragObj.elStartTop))  dragObj.elStartTop  = 0;


  dragObj.elNode.style.zIndex = ++dragObj.zIndex;


    document.attachEvent("onmousemove", dragGo);
    document.attachEvent("onmouseup",   dragStop);
    window.event.cancelBubble = true;
    window.event.returnValue = false;
 
}

function dragGo(event) {

  var x, y;


    x = window.event.clientX + document.documentElement.scrollLeft
      + document.body.scrollLeft;
    y = window.event.clientY + document.documentElement.scrollTop
      + document.body.scrollTop;
 

 //var Ldiff=x-( x- parseInt(dragObj.elNode.style.left,10));
 //var Rdiff=x+ ( parseInt(dragObj.elNode.style.width,10)-( x- parseInt(dragObj.elNode.style.left,10) ));



dragObj.elNode.style.left = (dragObj.elStartLeft + x - dragObj.cursorStartX) + "px";

    
    dragObj.elNode.style.top  = (dragObj.elStartTop  + y - dragObj.cursorStartY) + "px";

    window.event.cancelBubble = true;
    window.event.returnValue = false;

  
}

function dragStop(event) 
 {


    document.detachEvent("onmousemove", dragGo);
    document.detachEvent("onmouseup",   dragStop);
   // document.getElementById('divStudentDetails').doscroll('scrollbarPageDown');
  
 }
	
	
	
	function WinClose(val)
	{
	
	var node= document.getElementById(val).parentElement;
	
    while( node.tagName != 'DIV' && node.parentElement != null ) 
      node = node.parentElement;
	
	var nodeID=node.id;    
	 document.getElementById(nodeID).style.display="none";
	}
	
	function WinMin(val)
	{
	var node= document.getElementById(val).parentElement;
	
    while( node.tagName != 'DIV' && node.parentElement != null ) 
      node = node.parentElement;
	
	var nodeID=node.childNodes[1].id;    
	 document.getElementById(nodeID).style.display="none";
	
	WinCollection[WinCtr++]=node.id.toString();
	
	if(ctrMax!=0)
	ctrMax =ctrMax-parseInt(node.style.width,10);
	
	if(ctrMin==0)
	{
	ctrMin+=parseInt(node.style.width,10);
	
	node.style.left=document.getElementById("TaskBar").style.left;
	node.style.top=document.getElementById("TaskBar").style.top;
	}
	else
	{
	node.style.left=parseInt(document.getElementById("TaskBar").style.left,10) + ctrMin;
	node.style.top=document.getElementById("TaskBar").style.top;
	ctrMin+=parseInt(node.style.width,10);
	}
	
	}
	
	function WinMax(val)
	{
	var node= document.getElementById(val).parentElement;
	
    while( node.tagName != 'DIV' && node.parentElement != null ) 
      node = node.parentElement;
	
	var nodeID=node.childNodes[1].id;    
	 document.getElementById(nodeID).style.display="block";
	
	var xx;
	for (xx in WinCollection)
	{
	 if(WinCollection[xx]==node.id.toString())
	 WinCollection[xx]=null;
	}
	
	if(ctrMin!=0) 
	ctrMin =ctrMin-parseInt(node.style.width,10);
	
	if(ctrMax==0)
	{
	node.style.top= document.getElementById("layout").style.top;
	node.style.left= document.getElementById("layout").style.left;
	ctrMax=parseInt(node.style.width,10);
	}
	else
	{
	node.style.top= document.getElementById("layout").style.top;
	node.style.left=parseInt(document.getElementById("layout").style.left,10) + ctrMax;
	ctrMax +=parseInt(node.style.width,10);
	
	}
	
	}
		
		</script>
		<script language="javascript">
		
		function fnDocRecv(cbDocRecv)
		{
			var cbID = document.getElementById(cbDocRecv.id);
			var cnt = document.getElementById('hidDocCnt').value;
			if(cbID.checked == true)
			{ 
				for(i=1; i<=cnt; i++)
				{
					
					var strCB = document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-2].innerHTML;
					if(strCB.match(cbID.id) != null)
					{
						var strRB =document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-1].innerHTML; 
						while(strRB.match("disabled") != null)
						{
							strRB = strRB.replace(/disabled/,"");
						}
						if(strRB.match("value=rbValidDoc") != null)
							strRB = strRB.replace(/value=rbValidDoc/,"value=rbValidDoc checked=\"checked\" ");
						document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-1].innerHTML = strRB;
					}
				}
			}
			if(cbID.checked == false)
			{
				for(i=1; i<=cnt; i++)
				{
					
					var strCB = document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-2].innerHTML;
					if(strCB.match(cbID.id) != null)
					{
						var strRB =document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-1].innerHTML; 
						while(strRB.match("<SPAN>") != null)
						  	  strRB = strRB.replace(/<SPAN>/,"<SPAN disabled>");
						strRB = strRB.replace(/value=rbValidDoc/,"value=rbValidDoc disabled ");
						strRB = strRB.replace(/value=rbInValidDoc/,"value=rbInValidDoc disabled ");
						while(strRB.match("CHECKED") != null)
							strRB = strRB.replace(/CHECKED/,"");
						document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-1].innerHTML = strRB;
					}
				}
			}
		}
		
		function fnOnSubmit()
		{
			var cnt = document.getElementById('hidDocCnt').value;
			var DocXML=document.getElementById('hidDocXML');
			DocXML.value = "";
			for(var i=1;i<=cnt;i++)
			{
				
				if(document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-2].childNodes[0].checked == true)
				{
					DocXML.value = DocXML.value + "1";    //Recieved_By_Uni = 1
					if(document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-1].childNodes[0].checked == true)
						DocXML.value = DocXML.value + "1";   //Validity_By_Uni = 1
					if(document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-1].childNodes[2].checked == true)
						DocXML.value = DocXML.value + "0";  //Validity_By_Uni = 0
				}
				else
				{
					DocXML.value = DocXML.value + "00";
				}
				
			}
			
		}
		function fnDisplayDiv()	
		{
			if(document.getElementById('rbDefaulter').checked == true)
			   document.getElementById('divReason').style.display = 'block' ;
			if(document.getElementById('rbPending').checked == true)
			   document.getElementById('divReason').style.display = 'block' ;
			if(document.getElementById('rbEligible').checked == true)
				document.getElementById('divReason').style.display = 'none' ;
			document.getElementById('btnSubmit').disabled = false;
			document.getElementById('btnCancel').disabled = false;
			
		}
		
		
		function  fnConfirm()
		{
			var ch; 
			if(document.getElementById('rbDefaulter').checked == true)
			{
			   if(document.getElementById('tbReason').value == "")
			   {
			      alert('Please Enter a Valid Reason for marking this Student Non Eligible');
			      return false;
			   }
			   ch = confirm('Are you sure you want to mark this student as \"Non Eligible\" ?');
			}
			if(document.getElementById('rbPending').checked == true)
			{
			   if(document.getElementById('tbReason').value == "")
			   {	
			      alert('Please Enter a Valid Reason for keeping the Eligibility of Student Pending');
			      return false;
			   }
			   ch = confirm('Are you sure you want to keep the Eligibility of this student as \"Pending\" ?');
			}
			if(document.getElementById('rbEligible').checked == true)
			   ch = confirm('Are you sure you want to mark this student as \"Eligible\" ?');
			fnOnSubmit();
			return false;
			//return ch;
		}
		
		function fnHelp()
		{
			document.getElementById('divInstructions').style.display = "block";
		}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div align=center>
				<uc1:toplink id="TopLink1" runat="server"></uc1:toplink><!-- Header Ends-->
				<!-- Heading Starts-->
				<table height="48" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<tr height="3">
						<td vAlign="middle" align="center"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
					<tr height="15">
						<td vAlign="middle" align="center" width="10%"><IMG height="45" src="../images/CoomingSoon.gif" width="45"></td>
						<td vAlign="top" width="40%"><asp:label id="lblTitle" runat="server" CssClass="PageHeading" Font-Bold="True" Height="8px" ForeColor="Tomato"></asp:label>
						<asp:Label ID="Institute" runat="server" Font-Bold="True"></asp:Label><asp:Label ID="lblStudName" Text="" runat="server"></asp:Label></td>
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
				<table height="100%" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<TBODY>
						<tr>
							<td class="SideLeft" vAlign="top" align="left" width="18%">
								<!--Menu Start Here-->
								<P><uc1:mainlink id="MainLink1" runat="server"></uc1:mainlink></P>
								<!--Menu Ends Here--></td>
							<td vAlign="top" align="left" width="2%">&nbsp;</td>
							<td vAlign="top" align="left" width="80%">
								<div id="divStudentStatusDetails" runat="server"><br>
									<table class="tblBackColor" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td colSpan="4"><b>Registration Details of the Student</b></td>
										</tr>
										<tr class="rFont">
												<TD width="30%"><b>Eligibility Status :</b></TD>
												<td width="20%"><asp:label id="lblElgStatus" runat="server" Font-Bold="True" ForeColor="#C04000"></asp:label></td>
												<td width="30%"><b>Reason(if any) :</b></td>
												<td width="20%"><asp:label id="lblElgReason" runat="server" Font-Bold="True" ForeColor="#C04000"></asp:label></td>
										</tr>
										<tr class="rFont">
											<td vAlign="top" width="30%"><b>Permanent Registration Number </b>
											<td vAlign="top" width="20%"><asp:label id="lblPermRegNo" runat="server" Font-Bold="True"></asp:label></td>
											<td vAlign="top" width="30%"><b>Alumni of University</b></td>
											<td vAlign="top" width="20%"><asp:label id="lblAlumni" runat="server">No</asp:label></td>
										</tr>
									</table>
									<br>
									<div runat="server" id="divTblElgFormdetails">
										<table class="tblBackColor" id="TblElgFormdetails" cellSpacing="1" cellPadding="3" width="100%"
											border="0">
											
											<tr class="GridSubHeading">
												<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Eligibility Form Number of the 
														Student&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													</b>
													<asp:label id="lblEligibilityFormNo" runat="server" Font-Bold="True"></asp:label></td>
											</tr>
										</table>
									</div>
									<br>
									<table class="tblBackColor" id="TblAdmission" style="DISPLAY: none" cellSpacing="1" cellPadding="3"
										width="100%" border="0" runat="server">
										<TBODY>
											<tr class="GridSubHeading">
												<TD style="HEIGHT: 18px" colSpan="4"><b>Admission&nbsp;Details of the Student</b>
												</TD>
											</tr>
											<tr class="rFont">
												<TD width="30%"><b>Admission Form Number :</b></TD>
												<td width="20%"><asp:label id="lblAppFormNo" runat="server"></asp:label></td>
												<td width="30%"><b>Admission Date :</b></td>
												<td width="20%"><asp:label id="lblAdmissionDate" runat="server"></asp:label></td>
											</tr>
											<tr class="rFont">
												<td width="30%"><b>Seeking Admission in Course :</b></td>
												<td width="70%" colSpan="3"><asp:label id="lblCourse" runat="server"></asp:label></td>
											</tr>
											
											<tr class="rFont">
												<TD width="30%"><b>Institute Name :</b></TD>
												<td width="80%" colSpan="3"><asp:label id="lblInstName" runat="server"></asp:label></td>
											</tr>
										</TBODY>
									</table>
									<br>
									<div id="divMatchingRecords" style="DISPLAY : none" runat="server">
										<asp:label id="lblGridName" runat="server" Height="18px" CssClass="GridHeadingM" Width="100%">Other Course Eligibility Status</asp:label><br>
										<asp:datagrid id="DGMatchgCourseDetails" runat="server" Width="100%" BorderStyle="Solid" PageSize="5"
											AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699" AllowPaging="True">
											<ItemStyle CssClass="GridData2"></ItemStyle>
											<Columns>
												<asp:BoundColumn ReadOnly="True" HeaderText="Sr. No.">
												    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Course" HeaderText="Course">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="InstituteName" HeaderText="Institute Name">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="EligibilityStatus" HeaderText="Eligibility Status">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CourseStatus" HeaderText="Course Status">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Reason" HeaderText="Reason">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ElgFormNo" HeaderText="Eligibility Form Number">
												    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid>
									</div>
								</div>								
								<div id="divStudentDetails" runat="server"><br>
									<asp:label id="lblProfileHeading" runat="server" Height="18px" CssClass="GridHeadingM" Width="100%"> Student's Profile</asp:label>
									<table id="Table1" cellSpacing="0" cellPadding="3" width="100%" border="0">
										<tr>
											<td vAlign="top" width="80%">
												<table class="tblBackColor" id="Table2" cellSpacing="1" cellPadding="3" width="100%" border="0">
													<tr class="GridSubHeading">
														<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Personal Details of the 
																Student</b>
														</td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" width="30%"><b>Full Name</b></td>
														<td vAlign="top" colSpan="3"><asp:label id="lblNameOfStudent" runat="server"></asp:label></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" width="30%"><b>Father's Full Name</b></td>
														<td vAlign="top" colSpan="3"><asp:label id="lblFathersName" runat="server"></asp:label></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" width="30%"><b>Mother's Maiden Name</b></td>
														<td vAlign="top" colSpan="3"><asp:label id="lblMothersMaidenName" runat="server"></asp:label></td>
													</tr>
													<tr class="rFont" id="trChangedName" style="DISPLAY: none" runat="server">
														<td vAlign="top" width="30%"><b>Previous&nbsp;Name</b></td>
														<td vAlign="top" colSpan="3"><asp:label id="lblPreviousName" runat="server"></asp:label></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" width="30%"><b>Date of Birth</b></td>
														<td vAlign="top" width="30%"><asp:label id="lblDOB" runat="server"></asp:label></td>
														<td vAlign="top" width="20%"><b>Gender</b></td>
														<td vAlign="top" width="20%"><asp:label id="lblGender" runat="server"></asp:label></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" width="20%"><b>Nationality</b></td>
														<td vAlign="top" colSpan="3"><asp:label id="lblNationality" runat="server"></asp:label></td>
													</tr>
												</table>
											</td>
											<td vAlign="top" width="20%">
												<table class="tblBackColor" id="Table3" cellSpacing="1" cellPadding="3" width="100%" border="0">
													<tr class="GridSubHeading">
														<td style="HEIGHT: 16px" vAlign="top" align="center"><b>Photograph</b></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" align="center"><asp:image id="Image1" runat="server" Visible="true" ImageUrl="../images/Member.gif" AlternateText="Photograph"></asp:image></td>
													</tr>
													<tr class="GridSubHeading">
														<td style="HEIGHT: 16px" vAlign="top" align="center"><b>Signature</b></td>
													</tr>
													<tr class="rFont">
														<td vAlign="top" align="center"><asp:image id="Image2" runat="server" Visible="true" AlternateText="Signature" ToolTip="Signature"></asp:image></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<table class="tblBackColor" id="Table5" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Reservation Details of the Student</b>
											</td>
										</tr>
										<tr class="rFont">
											<td vAlign="top" width="20%"><b>State of Domicile</b></td>
											<td vAlign="top" width="30%"><asp:label id="lblDomicileState" runat="server"></asp:label></td>
											<td vAlign="top" width="20%"><b>Reservation Category</b></td>
											<td vAlign="top" width="30%"><asp:label id="lblResvCategory" runat="server"></asp:label></td>
										</tr>
										<tr class="rFont">
											<td vAlign="top" width="20%"><b>Physically Challenged</b></td>
											<td vAlign="top" colSpan="3"><asp:label id="lblPhyChlngd" runat="server"></asp:label></td>
										</tr>
										<tr class="rFont">
											<td vAlign="top"><b>Social Reservation</b>
											</td>
											<td vAlign="top" colSpan="3"><asp:label id="lblSocResv" runat="server"></asp:label></td>
										</tr>
									</table>
									<br>
									<table class="tblBackColor" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Guardian Details of the Student</b>
											</td>
										</tr>
										<tr class="rFont">
											<td vAlign="top" width="30%"><b>Annual Income of the Guardian</b></td>
											<td vAlign="top" width="20%"><asp:label id="lblGuardianincome" runat="server"></asp:label></td>
											<td vAlign="top" width="30%"><b>Occupation of the Guardian</b></td>
											<td vAlign="top" width="20%"><asp:label id="lblGuardianOccupation" runat="server"></asp:label></td>
										</tr>
									</table>
									<br>
									<table class="tblBackColor" id="Table4" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td style="HEIGHT: 16px" vAlign="top"><b>Educational Details&nbsp;of the Student</b>
											</td>
										</tr>
										<tr class="rFont">
											<td><asp:datagrid id="DGQualification" runat="server" Width="100%" AutoGenerateColumns="False" BorderWidth="1px"
													BorderColor="Gainsboro">
													<Columns>
														<asp:BoundColumn DataField="Qualification" HeaderText="Qualification">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CollegeInstituteName" HeaderText="College/Institute">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Body" HeaderText="Board/University">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Marks_Obtained" HeaderText="Marks">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Marks_OutOf" HeaderText="Out of">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DateOfPassing" HeaderText="Passing Date">
															<HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign=Center></HeaderStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<br>
									<table class="tblBackColor" id="Tbl4" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td style="HEIGHT: 16px" vAlign="top"><b>Documents Submitted by the Student</b></td>
										</tr>
										<tr class="rFont">
											<td vAlign="top" align="center" width="100%"><asp:datagrid id="DGSubmittedDocs" runat="server" Width="90%" BorderStyle="Solid" PageSize="5"
													AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699">
													<ItemStyle CssClass="GridData2"></ItemStyle>
													<Columns>
														<asp:BoundColumn ReadOnly="True" HeaderText="Sr. No.">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DocCert_Desc" ReadOnly="True" HeaderText="Document Name">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:BoundColumn>
														<asp:BoundColumn ReadOnly="True" HeaderText="Received By College">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Received By University">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="cbDocRecv" runat="server" onclick="fnDocRecv(this);" Enabled="false"></asp:CheckBox>
															</ItemTemplate>
															<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Determine Validity ">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:RadioButton id="rbValidDoc" runat="server" Text="Valid" GroupName="grpValidity" Enabled="False"
																	Checked="False"></asp:RadioButton>
																<asp:RadioButton id="rbInvalidDoc" runat="server" Text="Invalid" GroupName="grpValidity" Enabled="False"
																	Checked="False"></asp:RadioButton>
															</ItemTemplate>
															<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="pk_DocCert_ID" ReadOnly="True" HeaderText="Doc_ID"></asp:BoundColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</tr>
									</table>
									<br>
								</div>
								<br>
								<table id="Table9" cellSpacing="0" cellPadding="5" align="center" border="0">
									<tr>
										<td><asp:button id="btnGoTo" runat="server" Text="Go Back" CssClass="butSubmit" onclick="btnGoTo_Click"></asp:button></td>
									</tr>
								</table>
							</td>
						</tr>
						<TR>
						<TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					</TR>
					</TBODY>
				</table>
				<!--Main Ends-->
				<!-- Footer Starts--><uc1:footer id="Footer1" runat="server"></uc1:footer><!-- Footer Ends-->
                <input id="hidInstID" runat="server" name="hidInstID" style="width: 24px; height: 22px"
                    type="hidden" />
                <INPUT id="hidUniID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidUniID" runat="server">
				<INPUT id="hidPRN" type="hidden" name="hidPRN" runat="server"> 
				<INPUT id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server">
				<input id="hidpkYear" type="hidden" name="hidpkYear" runat="server">
				<input id="hidpkStudentID" type="hidden" name="hidpkStudentID" runat="server">
				<INPUT id="hidCrMoLrnPtrnID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidCrMoLrnPtrnID" runat="server"> 
				<input id="hidStep" type="hidden" name="hidStep" runat="server">
				<input id="hidElgFlag" type="hidden" name="hidElgFlag" runat="server"><input id="hidDocXML" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDocXML"
					runat="server"> <INPUT id="hidDocCnt" type="hidden" name="hidDocCnt" runat="server">
				
			</div>
		</form>
	</body>
</HTML>
