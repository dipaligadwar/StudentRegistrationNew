<%@ Page language="c#" Codebehind="reg_PendingStudentEligibility__1.aspx.cs" AutoEventWireup="True" Inherits="StudentRegistration.Eligibility.reg_PendingStudentEligibility__1" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="../Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainLink" Src="../SideLinks.ascx" %>
<%@ Register TagPrefix="uc1"  TagName="topLink" Src="../InnerHeader.ascx" %>
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
					
					var arrRadio = document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-1].getElementsByTagName("INPUT");
					
					for(var j=0;j<arrRadio.length;j++)
					{
					    
					    if(arrRadio[j].type=='radio' && arrRadio[j].checked)
					    {
					        if(arrRadio[j].value=="rbValidDoc")
					        {
					           DocXML.value = DocXML.value + "1";   //Validity_By_Uni = 1 
					        }
					        else if(arrRadio[j].value=="rbInvalidDoc")
					        {
					           DocXML.value = DocXML.value + "0";  //Validity_By_Uni = 0
					        }
					    }
					   
					}
					
					/*
					if(document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-1].childNodes[0].checked == true)
						DocXML.value = DocXML.value + "1";   //Validity_By_Uni = 1
					if(document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-1].childNodes[3].checked == true)
						DocXML.value = DocXML.value + "0";  //Validity_By_Uni = 0
					*/
			    }
				else
				{
					DocXML.value = DocXML.value + "00";
				}
			}
				
		}
		
		function fnDisplayDiv()	
		{
		    if(document.getElementById('rbProvisional').checked == true);
		        document.getElementById('divReason').style.display = 'block' ;
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
			if(document.getElementById('rbProvisional').checked == true)
			{
			   if(document.getElementById('tbReason').value == "")
			   {
			      alert('Please Enter a Valid Reason for marking this Student Non Eligible');
			      return false;
			   }
			   ch = confirm('Are you sure you want to mark this student as \"Provisionally Eligible\" ?');
			}
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
			//return false;
			return ch;
		}
		
		function fnHelp()
		{
			document.getElementById('divInstructions').style.display = "block";
			document.getElementById('divInstructions').style.top=300;
			document.getElementById('divInstructions').style.left=220;
		}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div align=center>
				<uc1:toplink id="TopLink1" runat="server"></uc1:toplink> <!-- Header Ends-->
				<!-- Heading Starts-->
				<table height="48" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<tr height="3">
						<td vAlign="middle" align="center"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
					<tr height="15">
						<td vAlign="middle" align="center" width="20%" rowSpan="2"><IMG height="45" src="../images/CoomingSoon.gif" width="45"></td>
						<td style="HEIGHT: 17px" vAlign="bottom"><asp:label id="lblTitle" runat="server" CssClass="PageHeading" Font-Bold="True" Height="8px" ForeColor="Tomato"></asp:label>
						<asp:Label ID="lblInstitute" runat="server" Font-Bold="True"></asp:Label><asp:Label ID="lblStudName" Text="" runat="server"></asp:Label></td>
					</tr>
					<TR height="30">
						<TD align="left" width="80%" colSpan="2"><asp:label id="lblvalidateevent" CssClass="lbltext" Visible="False" Runat="server">
								<STRONG></STRONG>
							</asp:label></TD>
					</TR>
					<tr>
						<td class="FormName" vAlign="middle" align="center" colSpan="3"><font style="FONT-SIZE: 2pt">&nbsp;</font></td>
					</tr>
				</table>
				<!-- Heading Ends-->
				<!-- Main Starts-->
				<table height="410" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<TBODY>
						<tr>
							<td class="SideLeft" vAlign="top" align="left" width="18%">
								<!--Menu Start Here-->
								<P><uc1:mainlink id="MainLink1" runat="server"></uc1:mainlink></P>
								<!--Menu Ends Here--></td>
							<td vAlign="top" align="left" width="2%">&nbsp;</td>
							<td vAlign="top" align="left" width="80%">
								<div id="divPendingReason" style="DISPLAY: block" runat="server"><asp:label id="lblEligibilityReason" runat="server" Width="100%" CssClass="GridHeadingM" Font-Bold="True"
										text="Eligibility Kept Pending due to following reason(s)"></asp:label>
									<table class="tblBackColor" id="Tbl1" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<TBODY>
											<tr class="rFont">
												<td><asp:label id="lblPendingReason" runat="server" CssClass="lblreason" Font-Bold="True"></asp:label></td>
											</tr>
										</TBODY>
									</table>
								</div>
								

								<br>
								<div id="divStudentDetails" style="DISPLAY: none" runat="server"><br>
									<asp:label id="lblProfileHeading" runat="server" Width="100%" CssClass="GridHeadingM" Height="18px">Eligiblity Pending Student's Profile</asp:label><br>
									<br>
									<asp:label id="lblInstructions" style="CURSOR: hand" onclick="fnHelp();" Font-Bold="True" ForeColor="green"
										Runat="server">Click here to view Instructions for Eligibility Decision</asp:label><br>
									<br>
									<div id="divInstructions" style="BORDER-RIGHT: green solid; BORDER-TOP: green solid; DISPLAY: none; BORDER-LEFT: green solid; WIDTH: 300px; BORDER-BOTTOM: green solid; POSITION: absolute; HEIGHT: 200px; BACKGROUND-COLOR: white"
										runat="server">
										<table onmousedown="dragStart(event, 'divInstructions')" style="CURSOR: move; BACKGROUND-COLOR: green"
											cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td class="GridHeadingMI" width="100%"><asp:label id="lblInstructionHead" runat="server" Height="18px">Instructions for Eligibility Decision</asp:label></td>
												<td align="right"><IMG id="imgIClose" style="CURSOR: hand" onclick="WinClose('imgIClose')" src="../images/closeBtn.GIF"
														align="right"></td>
											</tr>
										</table>
										<div id="divIScroll" style="OVERFLOW: auto; HEIGHT: 200px" runat="server"><br>
											<b>Instructions to be followed for the eligibility decision of a student: </b>
											<br>
											<ol>
												<li>
													<font color="black">Please view the displayed profile of the student whose 
														Eligibility is under consideration.<br>
														<br>
													</font>
												<li>
													<font color="black">View the list of documents submitted by the student at the 
														college level.</font><br>
													<br>
												<li>
													<font color="black">Tick the check box against the document ,if the hard copy of 
														the document is recieved by the University.</font><br>
													<br>
												<li>
													<font color="black">Determine the validity of the received documents by marking 
														'Valid' / 'Invalid'.</font><br>
													<br>
												<li>
													<font color="black">Take the eligibility decision by marking 'Eligible' / 'Not 
														Eligible' / 'Pending Eligible'.</font><br>
													<br>
												<li>
													<font color="black">Take the eligibility decision by marking 'Eligible' / 'Not 
														Eligible' / 'Pending Eligible'.</font><br>
													<br>
												<li>
													<font color="black">Click on 'Cancel' button to change the Eligibility 
														decision(only before submitting).</font><br>
													<br>
												<li>
													<font color="black">'Submit' the eligibility of the student whose Eligibility is 
														Under Consideration.</font><br>
													<br>
												</li>
											</ol>
											<br>
										</div>
									</div>
									<table class="tblBackColor" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td colSpan="4"><b>Registration Details of the Student</b></td>
										</tr>
										<tr class="rFont">
											<td vAlign="top" width="30%"><b>Permanent Registration Number </b>
											<td vAlign="top" width="20%"><asp:label id="lblPermRegNo" runat="server" Font-Bold="True"></asp:label></td>
											<td vAlign="top" width="30%"><b>Alumni of University</b></td>
											<td vAlign="top" width="20%"><asp:label id="lblAlumni" runat="server">No</asp:label></td>
										</tr>
									</table>
									<br>
									<table class="tblBackColor" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Eligibility Form Number of the 
													Student&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</b>
												<asp:label id="lblEligibilityFormNo" runat="server" Font-Bold="True"></asp:label></td>
										</tr>
									</table>
									<br>
									<table class="tblBackColor" id="Tbl2" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<TBODY>
											<tr class="GridSubHeading">
												<TD style="HEIGHT: 18px" colSpan="4"><b>Admission&nbsp;Details of the Student</b>
												</TD>
											</tr>
											<tr class="rFont">
												<TD width="30%"><b>Institute Name :</b></TD>
												<td colSpan="3"><asp:label id="lblInstName" runat="server"></asp:label></td>
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
												<TD colSpan="4"><b>Papers Selected :</b></TD>
											</tr>
											<tr class="rFont">
												<td colSpan="4"><asp:label id="lblPapers" runat="server"></asp:label></td>
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
														<td vAlign="top" align="center"><asp:image id="Image1" runat="server" Visible="true" AlternateText="Photograph" ImageUrl="../images/Member.gif"></asp:image></td>
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
									<br>
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
											<td><asp:datagrid id="DGQualification" runat="server" Width="100%" BorderColor="Gainsboro" BorderWidth="1px"
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
											<td vAlign="top" align="center" width="100%"><asp:datagrid id="DGSubmittedDocs" runat="server" Width="90%" BorderColor="#336699" BorderWidth="1px"
													AutoGenerateColumns="False" PageSize="5" BorderStyle="Solid">
													<ItemStyle CssClass="GridData2"></ItemStyle>
													<HeaderStyle CssClass="GridHeading"></HeaderStyle>
													<Columns>
														<asp:BoundColumn ReadOnly="True" HeaderText="Sr. No.">
														    <HeaderStyle CssClass="gridHeader" />
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DocCert_Desc" ReadOnly="True" HeaderText="Document Name">
														    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
														</asp:BoundColumn>
														<asp:BoundColumn ReadOnly="True" HeaderText="Received By College">
														    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Received By University">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="cbDocRecv" runat="server" onclick="fnDocRecv(this);"></asp:CheckBox>
															</ItemTemplate>
															<HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Determine Validity ">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:RadioButton id="rbValidDoc" runat="server" Text="Valid" GroupName="grpValidity" Enabled="False"
																	Checked="False"></asp:RadioButton>
																<asp:RadioButton id="rbInvalidDoc" runat="server" Text="Invalid" GroupName="grpValidity" Enabled="False"
																	Checked="False"></asp:RadioButton>
															</ItemTemplate>
															<HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="pk_DocCert_ID" ReadOnly="True" HeaderText="Doc_ID"></asp:BoundColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</tr>
									</table>
									<br>
									<div id="divEligibilityDecision" style="DISPLAY: block" runat="server">
										<table class="tblBackColor" id="Tbl44" cellSpacing="1" cellPadding="3" width="100%" border="0">
											<tr class="rFont">
												<td vAlign="middle"><b>Decision of Student's Eligibility</b></td>
												<td vAlign="top">
												<table width="100%"> 
												<tr>
												<td width="15%" style="height: 35px"><asp:radiobutton id="rbEligible" runat="server" Text="Eligible" GroupName="grpEligibility"></asp:radiobutton></td>
												<td width="32%" style="height: 35px"><asp:radiobutton id="rbProvisional" runat="server" Text="Provisionally Eligible" GroupName="grpEligibility"></asp:radiobutton></td>
												<td width="20%" style="height: 35px"><asp:radiobutton id="rbDefaulter" runat="server" Text="Not Eligible" GroupName="grpEligibility"></asp:radiobutton></td>
												<td width="35%" style="height: 35px"><asp:radiobutton id="rbPending" runat="server" Text="Eligibility Pending" GroupName="grpEligibility"></asp:radiobutton></td>
												
												</tr>
												</table>
											</tr>
										</table>
										<div id="divReason" style="DISPLAY: none" runat="server">
											<table class="tblBackColor" id="Table6" cellSpacing="1" cellPadding="3" width="100%">
												<tr class="rFont">
													<td vAlign="top" width="39%"><b>Reason(s) for Denying Eligibility / Pending Eligibility </b>
													</td>
													<td><asp:textbox id="tbReason" runat="server" Width="466px" CssClass="textarea" Height="30px" TextMode="MultiLine"></asp:textbox></td>
												</tr>
											</table>
										</div>
										<br>
										<table id="Table7" cellSpacing="0" cellPadding="5" align="center" border="0">
											<tr>
												<td><asp:button id="btnSubmit" runat="server" CssClass="butSubmit" Text="Submit" Enabled="False" onclick="btnSubmit_Click"></asp:button></td>
												<td><asp:button id="btnCancel" runat="server" CssClass="butSubmit" Text="Cancel" Enabled="False"></asp:button></td>
											</tr>
										</table>
									</div>
									<br>
									<br>
									<div id="divPRN" style="DISPLAY: none" runat="server">
										<table id="Table8" cellSpacing="0" cellPadding="3" width="100%" align="center" border="0">
											<tr>
												<td align="center"><asp:label id="lblPRN" runat="server" CssClass="StylePRN"></asp:label></td>
											</tr>
											<tr>
											    <td align="center">
												<asp:label id="lblSMSError" Text="" runat="server" CssClass="StylePRN"></asp:label></td>
											</tr>
										</table>
									</div>
								</div>
								<br>
								<table id="Table9" cellSpacing="0" cellPadding="5" align="center" border="0">
									<tr>
										<td><asp:button id="btnGoTo" runat="server" CssClass="butSubmit" Text="Go To Student List" onclick="btnGoTo_Click"></asp:button></td>
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
				<INPUT id="hidPRN" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidPRN" runat="server">
				<INPUT id="hidElgFormNo" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidElgFormNo" runat="server"> 
				<input id="hidpkYear" type="hidden" name="hidpkYear" runat="server">
				<input id="hidpkStudentID" type="hidden" name="hidpkStudentID" runat="server"> 
				<INPUT id="hidCrMoLrnPtrnID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidCrMoLrnPtrnID" runat="server"> 
				<input id="hidStep" type="hidden" name="hidStep" runat="server">
				<input id="hidElgFlag" type="hidden" name="hidElgFlag" runat="server">
				<input id="hidDocXML" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDocXML" runat="server">
				<INPUT id="hidDocCnt" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDocCnt" runat="server">
				<!-- Added by Madhu Poclassery for SMS Integration On 27th Oct 2007 -->
                <input id="hidSMSFirstName"  runat="server" name="hidSMSFirstName" type="hidden" value="0" /> 
                <input id="hidSMSCrAbbr"  runat="server" name="hidSMSCrAbbr" type="hidden" value="0" /> 
                <input id="hidSMSMobileNumber"  runat="server" name="hidSMSMobileNumber" type="hidden" value="0" />
                 <!-- Added by Madhu Poclassery for SMS Integration On 27th Oct 2007 Ends -->
			</div>
		</form>
	</body>
</HTML>
