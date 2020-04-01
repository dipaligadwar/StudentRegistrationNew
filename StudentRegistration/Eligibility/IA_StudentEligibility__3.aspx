<%@ Page language="c#" Codebehind="IA_StudentEligibility__3.aspx.cs" AutoEventWireup="false" Inherits="Eligibility.IA_StudentEligibility__3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IA_StudentEligibility__3</title>
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
		
		/*
		function fnSetDecision(decision)
		{
			if(decision=='A')
			{
				opener.document.Form1.hidReturnFlag.value=1;
			}
			else
			{
				opener.document.Form1.hidReturnFlag.value=0;
			}
			opener.document.Form1.hidPRN.value=document.getElementById("lblPRN").innerText;
			opener.document.Form1.hidStudentName.value=document.getElementById("lblNameOfStudent").innerText;
			self.close();
		}*/
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table height="410" cellSpacing="0" cellPadding="0" width="95%" border="0">
				<TBODY>
					<tr>
						<td vAlign="top" align="left" width="80%">
							<div id="divStudentDetails" runat="server" width="100%"><asp:label onmousedown="dragStart(event, 'divStudentDetails')" id="lblProfileHeading" runat="server"
									Width="100%" CssClass="GridHeadingM" Height="18px">Selected Student's Profile</asp:label><br>
								<br>
								<table class="tblBackColor" cellSpacing="1" cellPadding="3" width="100%" border="0">
									<tr class="GridSubHeading">
										<td colSpan="4"><b>Registration Details of the Student</b></td>
									</tr>
									<tr class="rFont">
										<td vAlign="top" width="30%"><b>Permanent Registration Number </b>
										<td vAlign="top" width="20%"><asp:label id="lblPRN" runat="server" Font-Bold="True"></asp:label></td>
										<td vAlign="top" width="30%"><b>Alumni of University</b></td>
										<td vAlign="top" width="20%"><asp:label id="lblAlumni" runat="server">No</asp:label></td>
									</tr>
								</table>
								<br>
								<br>
								<table class="tblBackColor" id="Tbl2" cellSpacing="1" cellPadding="3" width="100%" border="0">
									<TBODY>
										<tr class="GridSubHeading">
											<TD style="HEIGHT: 18px" colSpan="4"><b>Admission Details of the Student</b>
											</TD>
										</tr>
										<tr class="rFont">
											<td><asp:datagrid id="DGMCourseDetails" runat="server" Width="100%" BorderColor="#336699" BorderWidth="1px"
													AutoGenerateColumns="False" PageSize="5" BorderStyle="Solid">
													<ItemStyle CssClass="GridData2"></ItemStyle>
													<Columns>
														<asp:BoundColumn ReadOnly="True" HeaderText="Sr. No.">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Course" HeaderText="Course">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CoursePart" HeaderText="Course Part">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="InstName" HeaderText="Institute Name">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CrPrEligibility" HeaderText="Eligibility Status">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CrPrStatus" HeaderText="Course Status">
														    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</tr>
									</TBODY>
								</table>
								<br>
								<table id="Table1" cellSpacing="0" cellPadding="3" width="100%" border="0">
									<tr>
										<td vAlign="top" width="80%">
											<table class="tblBackColor" id="Table2" cellSpacing="1" cellPadding="3" width="100%" border="0">
												<tr class="GridSubHeading">
													<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Personal Details of&nbsp;the 
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
										<td vAlign="top" colSpan="4"><b>Social Reservation</b></td>
									</tr>
									<tr class="rFont">
										<td vAlign="top" colSpan="4"><asp:label id="lblSocResv" runat="server"></asp:label></td>
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
										<td><asp:datagrid id="DGMQualification" runat="server" Width="100%" BorderColor="Gainsboro" BorderWidth="1px"
												AutoGenerateColumns="False">
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
														<HeaderStyle Font-Bold="True" CssClass="gridHeader"  HorizontalAlign=Center></HeaderStyle>
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
										<td vAlign="top" align="center" width="100%"><asp:datagrid id="DGMSubmittedDocs" runat="server" Width="90%" BorderColor="#336699" BorderWidth="1px"
												AutoGenerateColumns="False" PageSize="5" BorderStyle="Solid">
												<ItemStyle CssClass="GridData2"></ItemStyle>
												<Columns>
													<asp:BoundColumn ReadOnly="True" HeaderText="Sr. No.">
													    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="DocCert_Desc" ReadOnly="True" HeaderText="Document Name">
													     <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
													</asp:BoundColumn>
													<asp:BoundColumn ReadOnly="True" HeaderText="Received By College">
													     <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="pk_DocCert_ID" ReadOnly="True" HeaderText="Doc_ID">
													     <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="ReceivedByUniversity" HeaderText="Received By University">
													     <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</asp:datagrid></td>
									</tr>
								</table>
								<br>
							</div>
						</td>
					</tr>
				</TBODY>
			</table>
			<!--Main Ends--><INPUT id="hidUniID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidUniID" runat="server">
			<INPUT id="hidPRN" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidPRN" runat="server">
			<INPUT id="hidElgFormNo" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidElgFormNo"
				runat="server">
		</form>
	</body>
</HTML>
