<%@ Register TagPrefix="uc1" TagName="footer" Src="../Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainLink" Src="../SideLinks.ascx" %>
<%@ Register TagPrefix="uc1"  TagName="topLink" Src="../InnerHeader.ascx" %>
<%@ Page language="c#" Codebehind="IA_StudentEligibility__1.aspx.cs" AutoEventWireup="True" Inherits="StudentRegistration.Eligibility.IA_StudentEligibility__1" %>
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
	<!--<script language="javascript" src="ajax/common.ashx"></script>
		<script language="javascript" src="ajax/StudentRegistration.Eligibility.IA_StudentEligibility__1,StudentRegistration.ashx"></script>-->
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
	 
   //dragObj.elNode.style.left = 0;
  // dragObj.elNode.style.top = 0;
  // window.scrollTo(0,document.getElementById(val).scrollTop);

	 
	 
	 
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

var zxcTO;
function Scroll()

{
if(document.getElementById('divMStudentDetails').style.display == "block")
{
//clearTimeout(zxcTO);


if (navigator.appName=="Microsoft Internet Explorer")
{ 
eval("divMStudentDetails.style.pixelTop=" +event.clientY*2);
//eval("divMStudentDetails.style.pixelLeft=" + event.clientX); 
}
//zxcTO=setTimeout(1000);


}
}
  window.onscroll=Scroll;

 

		
		</script>
		<script language="javascript">
		var MUni_ID;
		var MYear;
		var MStudent_ID
		function fnCheckSelection(cb)
		{
			
			var cbID = document.getElementById(cb.id);
			var cnt = document.getElementById('hidMatchingRecCount').value;
			if(cbID.checked == true)
			{ 
				for(i=1; i<=cnt; i++)
				{
					var str = document.getElementById('DGMatchingRecords').cells[((i+1)*8)-1].innerHTML;
					if(str.match(cbID.id) == null)
						document.getElementById('DGMatchingRecords').cells[((i+1)*8)-1].innerHTML = str.replace(/CHECKED/,"");
					
				}
				var ch = confirm('Are you sure you want to associate the profile under consideration for Eligibility with the selected record ?');
				if(!ch)
				{
					cbID.checked = false;
				}
			}
				
		}
		function fnFetchMatchingProfile(Uni_ID,Year,Student_ID)
		{
			MUni_ID = Uni_ID;
			MYear = Year;
			MStudent_ID = Student_ID;
			IA_StudentEligibility__1.FetchMatchingProfile(Uni_ID,Year,Student_ID,FetchMatchingProfile_CallBack);
		}	
		
		function FetchMatchingProfile_CallBack(response)
		{
			var ds = response.value;
			document.getElementById('trMChangedName').style.display = "none";
			document.getElementById('DGMCourseDetails').style.display = "none";
			document.getElementById('DGMQualification').style.display = "none";
			var MatchingID = MUni_ID +'-'+MYear+'-'+MStudent_ID;
			document.getElementById('ImageM1').src = "PhotoAndSignTemp.aspx?PMatchingID=" + MatchingID;
			document.getElementById('ImageM2').src = "PhotoAndSignTemp.aspx?SMatchingID=" + MatchingID;
			//document.getElementById('DGMSubmittedDocs').style.display = "none";
			if(ds.Tables[0].Rows.length>0)
			{
				var tbl=document.getElementById("DGMCourseDetails").getElementsByTagName("tbody")[0];
				if(tbl.rows.length!=0)
				{
					var cnt = tbl.rows.length;
					for(var k=1;k<cnt && k!=cnt;k++)
					{
						if(tbl.rows.length!=0)
						{
							tbl.deleteRow(1);
						}
					}
				}
				for(var i=0; i<ds.Tables[0].Rows.length; i++)
				{
					var row=document.createElement("TR");
					row.setAttribute('align','center');
					var cell=document.createElement("TD");
					cell.innerHTML=i+1;
					row.appendChild(cell);
					var cell1=document.createElement("TD");
					cell1.innerHTML=ds.Tables[0].Rows[i].Course;
					row.appendChild(cell1);
					var cell2=document.createElement("TD");
					cell2.innerHTML=ds.Tables[0].Rows[i].CoursePart;
					row.appendChild(cell2);
					var cell3=document.createElement("TD");
					cell3.innerHTML=ds.Tables[0].Rows[i].InstName;
					row.appendChild(cell3);
					var cell4=document.createElement("TD");
					cell4.innerHTML=ds.Tables[0].Rows[i].CrPrEligibility;
					row.appendChild(cell4);
					var cell5=document.createElement("TD");
					cell5.innerHTML=ds.Tables[0].Rows[i].CrPrStatus;
					row.appendChild(cell5);
					tbl.appendChild(row);
				}
				document.getElementById('DGMCourseDetails').style.display = "block";
			}
		
			if(ds.Tables[1].Rows.length>0)
			{
				//alert("In Table 1");
				document.getElementById('lblMPRN').innerText=ds.Tables[1].Rows[0].PRN;
				document.getElementById('lblMAlumni').innerText=ds.Tables[1].Rows[0].Alumini;
				document.getElementById('lblMNameOfStudent').innerText = ds.Tables[1].Rows[0].Last_Name+" "+ds.Tables[1].Rows[0].First_Name+" "+ds.Tables[1].Rows[0].Middle_Name;
				document.getElementById('lblMMothersMaidenName').innerText = ds.Tables[1].Rows[0].Mother_Last_Name+" "+ds.Tables[1].Rows[0].Mother_First_Name+" "+ds.Tables[1].Rows[0].Mother_Middle_Name;
				document.getElementById('lblMFathersName').innerText = ds.Tables[1].Rows[0].Father_Last_Name+" "+ds.Tables[1].Rows[0].Father_First_Name+" "+ds.Tables[1].Rows[0].Father_Middle_Name;
				if(ds.Tables[1].Rows[0].Changed_Name_Flag == "1")
				{
					document.getElementById('lblMPreviousName').innerText = ds.Tables[1].Rows[0].Prev_Last_Name+" "+ds.Tables[1].Rows[0].Prev_First_Name+" "+ds.Tables[1].Rows[0].Prev_Middle_Name;
					document.getElementById('trMChangedName').style.display = "block";
				}
				document.getElementById('lblMGender').innerText = ds.Tables[1].Rows[0].Gender_Desc;
				document.getElementById('lblMDOB').innerText = ds.Tables[1].Rows[0].DOB;                   //Gender,Date_of_Birth,Changed_Name_Reason
				document.getElementById('lblMNationality').innerText = ds.Tables[1].Rows[0].Nationality;
			}
			if(ds.Tables[2].Rows.length>0)
			{
				document.getElementById('lblMDomicileState').innerText = ds.Tables[2].Rows[0].Domicile_of_State;
				document.getElementById('lblMResvCategory').innerText = ds.Tables[2].Rows[0].Category;
				if(ds.Tables[2].Rows[0].Category_Flag == "1")
				{
					if(ds.Tables[2].Rows[0].ResvCategory != "")
					{
						document.getElementById('lblMResvCategory').innerText = document.getElementById('lblMResvCategory').innerText+" ("+ds.Tables[2].Rows[0].ResvCategory;
						if(ds.Tables[2].Rows[0].SubCaste != "")
							document.getElementById('lblMResvCategory').innerText = document.getElementById('lblMResvCategory').innerText+" - "+ds.Tables[2].Rows[0].SubCaste;
						document.getElementById('lblMResvCategory').innerText = document.getElementById('lblMResvCategory').innerText+")";
					}
				}
				if(ds.Tables[2].Rows[0].Physically_Challenged_Flag == "1")
					document.getElementById('lblMPhyChlngd').innerText = ds.Tables[2].Rows[0].PhysicallyChallenged;
				else
					document.getElementById('lblMPhyChlngd').innerText = "     -";
				document.getElementById('lblMGuardianincome').innerText = ds.Tables[2].Rows[0].Guardian_Annual_Income;
				document.getElementById('lblMGuardianOccupation').innerText = ds.Tables[2].Rows[0].GuardOccupation;
			}	
			if(ds.Tables[3].Rows.length>0)
			{
				for(var i=0; i<ds.Tables[3].Rows.length; i++)
				{
					document.getElementById('lblMSocResv').innerText = document.getElementById('lblMSocResv').innerText + ds.Tables[3].Rows[i].SocialReservation_Description;
					if(i < (ds.Tables[3].Rows.length - 1))
						document.getElementById('lblMSocResv').innerText =  document.getElementById('lblMSocResv').innerText + ", ";
				}
			}  
			if(ds.Tables[4].Rows.length>0)
			{
				var tbl=document.getElementById("DGMQualification").getElementsByTagName("tbody")[0];
				if(tbl.rows.length!=0)
				{
					var cnt = tbl.rows.length;
					for(var k=1;k<cnt && k!=cnt;k++)
					{
						if(tbl.rows.length!=0)
						{
							tbl.deleteRow(1);
						}
					}
				}
				for(var i=0; i<ds.Tables[4].Rows.length; i++)
				{
					var row=document.createElement("TR");
					row.setAttribute('align','center');
					var cell=document.createElement("TD");
					cell.innerHTML=ds.Tables[4].Rows[i].Qualification;
					row.appendChild(cell);
					var cell1=document.createElement("TD");
					cell1.innerHTML=ds.Tables[4].Rows[i].CollegeInstituteName;
					row.appendChild(cell1);
					var cell2=document.createElement("TD");
					cell2.innerHTML=ds.Tables[4].Rows[i].Body;
					row.appendChild(cell2);
					var cell3=document.createElement("TD");
					cell3.innerHTML=ds.Tables[4].Rows[i].Marks_Obtained;
					row.appendChild(cell3);
					var cell4=document.createElement("TD");
					cell4.innerHTML=ds.Tables[4].Rows[i].Marks_OutOf;
					row.appendChild(cell4);
					var cell5=document.createElement("TD");
					cell5.innerHTML=ds.Tables[4].Rows[i].DateOfPassing;
					row.appendChild(cell5);
					tbl.appendChild(row);
				}
				document.getElementById('DGMQualification').style.display = "block";
			}
			
			if(ds.Tables[5].Rows.length>0)
			{	
				var tbl=document.getElementById("DGMSubmittedDocs").getElementsByTagName("tbody")[0];
				if(tbl.rows.length!=0)
				{
					var cnt = tbl.rows.length;
					for(var k=1;k<cnt && k!=cnt;k++)
					{
						if(tbl.rows.length!=0)
						{
							tbl.deleteRow(1);
						}
					}
				}
				for(var i=0; i<ds.Tables[5].Rows.length; i++)
				{
					var row=document.createElement("TR");
					//row.setAttribute('align','center');
					var cell=document.createElement("TD");
					cell.innerHTML=(i+1);
					cell.setAttribute('align','center');
					row.appendChild(cell);
					var cell1=document.createElement("TD");
					cell1.innerHTML=ds.Tables[5].Rows[i].DocCert_Desc;
					row.appendChild(cell1);
					var cell2=document.createElement("TD");
					cell2.innerHTML="Received";
					cell2.setAttribute('align','center');
					row.appendChild(cell2);
					var cell3=document.createElement("TD");
					cell3.innerHTML=ds.Tables[5].Rows[i].ReceivedByUniversity;
					cell3.setAttribute('align','center');
					row.appendChild(cell3);
					tbl.appendChild(row);
				}
				document.getElementById('DGMSubmittedDocs').style.display = "block";	
			}	
				
				if(document.getElementById('divMStudentDetails').style.display == "none")
				{
					document.getElementById('divMStudentDetails').style.display = "block";
				}
				document.getElementById('divMStudentDetails').style.top=100;
				document.getElementById('divMStudentDetails').style.left=220;
			
			//divMStudentDetails
			

		}
			
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
					if(document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-1].childNodes[0].childNodes[0].checked == true)
						DocXML.value = DocXML.value + "1";   //Validity_By_Uni = 1
					if(document.getElementById('DGSubmittedDocs').cells[((i+1)*5)-1].childNodes[2].childNodes[0].checked == true)
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
			      alert('Please Enter a Valid Reason for marking this Student Not Eligible');
			      return false;
			   }
			   ch = confirm('Are you sure you want to mark this student as \"Not Eligible\" ?');
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
			return ch;
		}
		
		function fnHelp()
		{
			document.getElementById('divInstructions').style.display = "block";
			document.getElementById('divInstructions').style.top=255;
			document.getElementById('divInstructions').style.left=220;
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
						<td vAlign="middle" align="center" width="20%" rowSpan="2"><IMG height="45" src="../images/CoomingSoon.gif" width="45"></td>
						<td vAlign="bottom"><asp:label id="lblTitle" runat="server" CssClass="PageHeading" Font-Bold="True" Height="8px" ForeColor="Tomato"></asp:label>
						<asp:Label ID="lblInstitute" runat="server" Font-Bold="True"></asp:Label><asp:Label ID="lblStudName" Text="" runat="server"></asp:Label></td>
					</tr>
					<TR height="30">
						<TD align="left" width="80%" colSpan="2"><asp:label id="lblvalidateevent" CssClass="lbltext" Runat="server" Visible="False">
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
								<div id="divMatchingRecords" style="DISPLAY: none" runat="server"><br>
									<asp:label id="lblGridName" runat="server" CssClass="GridHeadingM" Height="18px" Width="100%">Details of the Matching Records</asp:label><br>
									<b>Note:</b><br>
									<div>
										<ol>
											<li>
											System has found that, the details of this student are matching with details of 
											already registered student(s), as displayed in following table.
											<li>
											Please click on the student's name in the table to view and compare the 
											profiles.
											<li>
												If you need to associate the student with any of the matching profiles, please 
												click on the check box against that profile, in the following table.
											</li>
										</ol>
									</div>
									<asp:datagrid id="DGMatchingRecords" runat="server" Width="100%" BorderStyle="Solid" PageSize="1"
										AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699">
										<ItemStyle CssClass="gridItem"></ItemStyle>
										<Columns>
											<asp:BoundColumn ReadOnly="True" HeaderText="Sr. No."></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Student Name">
												<ItemTemplate>
													<asp:Label id="lblStudentName" runat="server" ForeColor="#666666" style="cursor:hand;">
														<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "StudName"))%>
													</asp:Label>
												</ItemTemplate>
												<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="ExistingPRN" HeaderText="PRN">
											    <HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Alumini" ReadOnly="True" HeaderText="Alumini of Univeristy">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CertificateNo" HeaderText="10th First Certificate No.">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PassingDate" HeaderText="10th Passing Year">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SSCBoard" HeaderText="10th Examination  Board">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Select">
												<ItemTemplate>
													<asp:CheckBox id="cbSelection" onclick="fnCheckSelection(this);" runat="server"></asp:CheckBox>&nbsp;
												</ItemTemplate>
												<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center/>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="pkYear" ReadOnly="True" HeaderText="pkYear"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="pkStudentID" ReadOnly="True" HeaderText="pkStudentID"></asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid><br>
								</div>
								<div id="divMStudentDetails" style="BORDER-RIGHT: #800000 solid; BORDER-TOP: #800000 solid; DISPLAY: none; BORDER-LEFT: #800000 solid; WIDTH: 760px; BORDER-BOTTOM: #800000 solid; POSITION: absolute; TOP: 100px; HEIGHT: 200px; BACKGROUND-COLOR: white"
									runat="server">
									<table onmousedown="dragStart(event, 'divMStudentDetails')" style="CURSOR: move; BACKGROUND-COLOR: #800000"
										cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="GridHeadingM1" width="100%"><asp:label id="lblMProfileHeading" runat="server" Height="18px">Selected Student's Profile</asp:label></td>
											<td align="right"><IMG id="imgClose" style="CURSOR: hand" onclick="WinClose('imgClose')" src="../images/closeBtn.GIF"
													align="right"></td>
										</tr>
									</table>
									<div id="divScroll" style="OVERFLOW: auto; TOP: 100px; HEIGHT: 200px" runat="server"><br>
										<br>
										<table class="tblBackColor" cellSpacing="1" cellPadding="3" width="100%" border="0">
											<tr class="GridSubHeadingM">
												<td colSpan="4"><b>Registration Details of the Student</b></td>
											</tr>
											<tr class="rFont">
												<td vAlign="top" width="30%"><b>Permanent Registration Number </b>
												<td vAlign="top" width="20%"><asp:label id="lblMPRN" runat="server"></asp:label></td>
												<td vAlign="top" width="30%"><b>Alumni of University</b></td>
												<td vAlign="top" width="20%"><asp:label id="lblMAlumni" runat="server">No</asp:label></td>
											</tr>
										</table>
										<br>
										<table class="tblBackColor" id="Tbl2" cellSpacing="1" cellPadding="3" width="100%" border="0">
											<TBODY>
												<tr class="GridSubHeadingM">
													<TD style="HEIGHT: 18px" colSpan="4"><b>Admission Details of the Student</b>
													</TD>
												</tr>
											</TBODY>
										</table>
										<table class="GridDataM" id="DGMCourseDetails" style="DISPLAY: none; WIDTH: 100%; BORDER-COLLAPSE: collapse"
											borderColor="#600000" cellSpacing="0" rules="all" border="1">
											<tr class="GridHeadingM2" align="center">
												<td>Sr. No.</td>
												<td>Course</td>
												<td>Course Part</td>
												<td>Institute Name</td>
												<td>Eligibility Status</td>
												<td>Course Status</td>
											</tr>
										</table>
										<br>
										<table id="Table1" cellSpacing="0" cellPadding="3" width="100%" border="0">
											<tr>
												<td vAlign="top" width="80%">
													<table class="tblBackColor" id="Table2" cellSpacing="1" cellPadding="3" width="100%" border="0">
														<tr class="GridSubHeadingM">
															<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Personal Details of&nbsp;the 
																	Student</b>
															</td>
														</tr>
														<tr class="rFont">
															<td vAlign="top" width="30%"><b>Full Name</b></td>
															<td vAlign="top" colSpan="3"><asp:label id="lblMNameOfStudent" runat="server"></asp:label></td>
														</tr>
														<tr class="rFont">
															<td vAlign="top" width="30%"><b>Father's Full Name</b></td>
															<td vAlign="top" colSpan="3"><asp:label id="lblMFathersName" runat="server"></asp:label></td>
														</tr>
														<tr class="rFont">
															<td vAlign="top" width="30%"><b>Mother's Maiden Name</b></td>
															<td vAlign="top" colSpan="3"><asp:label id="lblMMothersMaidenName" runat="server"></asp:label></td>
														</tr>
														<tr class="rFont" id="trMChangedName" style="DISPLAY: none" runat="server">
															<td vAlign="top" width="30%"><b>Previous&nbsp;Name</b></td>
															<td vAlign="top" colSpan="3"><asp:label id="lblMPreviousName" runat="server"></asp:label></td>
														</tr>
														<tr class="rFont">
															<td vAlign="top" width="30%"><b>Date of Birth</b></td>
															<td vAlign="top" width="30%"><asp:label id="lblMDOB" runat="server"></asp:label></td>
															<td vAlign="top" width="20%"><b>Gender</b></td>
															<td vAlign="top" width="20%"><asp:label id="lblMGender" runat="server"></asp:label></td>
														</tr>
														<tr class="rFont">
															<td vAlign="top" width="20%"><b>Nationality</b></td>
															<td vAlign="top" colSpan="3"><asp:label id="lblMNationality" runat="server"></asp:label></td>
														</tr>
													</table>
												</td>
												<td vAlign="top" width="20%">
													<table class="tblBackColor" id="Table3" cellSpacing="1" cellPadding="3" width="100%" border="0">
														<tr class="GridSubHeadingM">
															<td style="HEIGHT: 16px" vAlign="top" align="center"><b>Photograph</b></td>
														</tr>
														<tr class="rFont">
															<td vAlign="top" align="center"><img id="ImageM1"></td>
														</tr>
														<tr class="GridSubHeadingM">
															<td style="HEIGHT: 16px" vAlign="top" align="center"><b>Signature</b></td>
														</tr>
														<tr class="rFont">
															<td vAlign="top" align="center"><img id="ImageM2"></td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
										<table class="tblBackColor" id="Table5" cellSpacing="1" cellPadding="3" width="100%" border="0">
											<tr class="GridSubHeadingM">
												<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Reservation Details of the Student</b>
												</td>
											</tr>
											<tr class="rFont">
												<td vAlign="top" width="20%"><b>State of Domicile</b></td>
												<td vAlign="top" width="30%"><asp:label id="lblMDomicileState" runat="server"></asp:label></td>
												<td vAlign="top" width="20%"><b>Reservation Category</b></td>
												<td vAlign="top" width="30%"><asp:label id="lblMResvCategory" runat="server"></asp:label></td>
											</tr>
											<tr class="rFont">
												<td vAlign="top" width="20%"><b>Physically Challenged</b></td>
												<td vAlign="top" colSpan="3"><asp:label id="lblMPhyChlngd" runat="server"></asp:label></td>
											</tr>
											<tr class="rFont">
												<td vAlign="top"><b>Social Reservation</b>
												</td>
												<td vAlign="top" colSpan="3"><asp:label id="lblMSocResv" runat="server"></asp:label></td>
											</tr>
										</table>
										<br>
										<table class="tblBackColor" cellSpacing="1" cellPadding="3" width="100%" border="0">
											<tr class="GridSubHeadingM">
												<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Guardian Details of the Student</b>
												</td>
											</tr>
											<tr class="rFont">
												<td vAlign="top" width="30%"><b>Annual Income of the Guardian</b></td>
												<td vAlign="top" width="20%"><asp:label id="lblMGuardianincome" runat="server"></asp:label></td>
												<td vAlign="top" width="30%"><b>Occupation of the Guardian</b></td>
												<td vAlign="top" width="20%"><asp:label id="lblMGuardianOccupation" runat="server"></asp:label></td>
											</tr>
										</table>
										<br>
										<table class="tblBackColor" id="Table4" cellSpacing="1" cellPadding="3" width="100%" border="0">
											<tr class="GridSubHeadingM">
												<td style="HEIGHT: 16px" vAlign="top"><b>Educational Details&nbsp;of the Student</b>
												</td>
											</tr>
										</table>
										<table id="DGMQualification" style="DISPLAY: none" borderColor="gainsboro" cellSpacing="0"
											cellPadding="0" width="100%" border="1">
											<tr align="center">
												<td><b>Qualification</b></td>
												<td><b>College/Institute</b></td>
												<td><b>Board/University</b></td>
												<td><b>Marks</b></td>
												<td><b>Out of</b></td>
												<td><b>Passing Date</b></td>
											</tr>
										</table>
										<br>
										<table class="tblBackColor" id="Tbl4" cellSpacing="1" cellPadding="3" width="100%" border="0">
											<tr class="GridSubHeadingM">
												<td style="HEIGHT: 16px" vAlign="top"><b>Documents Submitted by the Student</b></td>
											</tr>
										</table>
										<table class="GridDataM" id="DGMSubmittedDocs" style="DISPLAY: none; WIDTH: 100%; BORDER-COLLAPSE: collapse"
											borderColor="#600000" cellSpacing="0" rules="all" border="1">
											<tr class="GridHeadingM2" align="center">
												<td>Sr. No.</td>
												<td>Document Name</td>
												<td>Received By College</td>
												<td>Received By University</td>
											</tr>
										</table>
										<br>
										<br>
									</div>
								</div>
								<div id="divStudentDetails" style="DISPLAY: block" runat="server"><br>
									<asp:label id="lblStudentProfile" runat="server" CssClass="GridHeadingM" Height="18px" Width="100%">Student Profile Whose Eligibility is Under Consideration</asp:label><br>
									<asp:label id="lblInstructions" style="CURSOR: hand" onclick="fnHelp();" Font-Bold="True" Runat="server"
										ForeColor="green">Click here to view Instructions for Eligibility Decision</asp:label><br>
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
														'valid' / 'invalid'.</font><br>
													<br>
												<li>
													<font color="black">Take the eligibility decision by marking 'Eligible' / 'Not 
														Eligible' / 'Pending Eligible'.</font><br>
													<br>
												<li>
													<font color="black">Specify the reason if the student is marked as 'Not Eligible' / 
														'Pending Eligible'. </font>
													<br>
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
											<td style="HEIGHT: 16px" vAlign="top" colSpan="4"><b>Eligibility Form Number of the 
													Student&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</b>
												<asp:label id="lblEligibilityFormNo" runat="server" Font-Bold="True"></asp:label></td>
										</tr>
									</table>
									<br>
									<br>
									<table class="tblBackColor" id="Tbl2" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<TBODY>
											<tr class="GridSubHeading">
												<TD style="HEIGHT: 18px" colSpan="4"><b>Admission&nbsp;Details of the Student</b>
												</TD>
											</tr>
											<tr class="rFont">
												<TD width="30%" style="HEIGHT: 18px"><b>Institute Name :</b></TD>
												<td colSpan="3" style="HEIGHT: 18px"><asp:label id="lblInstName" runat="server"></asp:label></td>
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
														<td style="HEIGHT: 30px" vAlign="top" width="30%"><b>Previous&nbsp;Name</b></td>
														<td style="HEIGHT: 30px" vAlign="top" colSpan="3"><asp:label id="lblPreviousName" runat="server"></asp:label></td>
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
											<td><asp:datagrid id="DGQualification" runat="server" Width="100%" AutoGenerateColumns="False" BorderWidth="1px"
													BorderColor="Gainsboro">
													<Columns>
														<asp:BoundColumn DataField="Qualification" HeaderText="Qualification">
															<HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CollegeInstituteName" HeaderText="College/Institute">
															<HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Body" HeaderText="Board/University">
															<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Marks_Obtained" HeaderText="Marks">
															<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Marks_OutOf" HeaderText="Out of">
															<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DateOfPassing" HeaderText="Passing Date">
															<HeaderStyle CssClass="gridHeader" HorizontalAlign=Center />
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<br>
									<table class="tblBackColor" id="Tbl4" cellSpacing="1" cellPadding="3" width="100%" border="0">
										<tr class="GridSubHeading">
											<td style="HEIGHT: 16px" vAlign="top"><b>Documents submitted by the student.</b>
											</td>
										</tr>
										<tr class="rFont">
											<td vAlign="top" align="center" width="100%"><asp:datagrid id="DGSubmittedDocs" runat="server" Width="90%" BorderStyle="Solid" PageSize="5"
													AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699" DESIGNTIMEDRAGDROP="895">
													<ItemStyle CssClass="GridData2"></ItemStyle>
													<Columns>
														<asp:BoundColumn ReadOnly="True" HeaderText="Sr. No.">
														    <HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
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
																<asp:RadioButton id="rbValidDoc" runat="server" GroupName="grpValidity" Text="Valid" Enabled="False"></asp:RadioButton>
																<asp:RadioButton id="rbInvalidDoc" runat="server" GroupName="grpValidity" Text="Invalid" Enabled="False"></asp:RadioButton>
															</ItemTemplate>
															<HeaderStyle CssClass="gridHeader"  HorizontalAlign=Center/>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="pk_DocCert_ID" ReadOnly="True" HeaderText="Doc_ID"></asp:BoundColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</tr>
									</table>
									<div><asp:label id="lblDoctext" CssClass="ErrorNote" Runat="server" Visible="False"></asp:label></div>
									<br>
									<div id="divEligibilityDecision" style="DISPLAY: block" runat="server">
										<table class="tblBackColor" id="Tbl44" cellSpacing="1" cellPadding="3" width="100%" border="0">
											<tr class="rFont">
												<td vAlign="top" width="39%"><b>Decision of Student's Eligibility</b></td>
												<td vAlign="top"><asp:radiobutton id="rbEligible" runat="server" Text="Eligible" GroupName="grpEligibility"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:radiobutton id="rbDefaulter" runat="server" Text="Not Eligible" GroupName="grpEligibility"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:radiobutton id="rbPending" runat="server" Text="Eligibility Pending" GroupName="grpEligibility"></asp:radiobutton></td>
											</tr>
										</table>
										<div id="divReason" style="DISPLAY: none" runat="server">
											<table class="tblBackColor" id="Table6" cellSpacing="1" cellPadding="3" width="100%">
												<tr class="rFont">
													<td vAlign="top" width="39%"><b>Reason(s) for Denying Eligibility / Pending Eligibility </b>
													</td>
													<td><asp:textbox id="tbReason" runat="server" CssClass="textarea" Height="30px" Width="466px" TextMode="MultiLine"></asp:textbox></td>
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
												<td align="center"><asp:label id="lblPRN" runat="server" CssClass="StylePRN"></asp:label>
												<asp:label id="lblRefresh" Text="" runat="server" CssClass="StylePRN"></asp:label>
												</td>
											</tr>
										</table>
									</div>
									<br>
									<table id="Table9" cellSpacing="0" cellPadding="5" align="center" border="0">
										<tr>
											<td><asp:button id="btnGoTo" runat="server" CssClass="butSubmit" Text="Go To Student List" onclick="btnGoTo_Click"></asp:button></td>
										</tr>
									</table>
								</div>
							</td>
						</tr>
						 <TR>
						<TD colSpan="3" class="FooterTop"><font style="FONT-SIZE: 1pt">&nbsp;</font></TD>
					</TR>
					</TBODY>
				</table>
				<!--Main Ends-->
				<!-- Footer Starts--><uc1:footer id="Footer1" runat="server"></uc1:footer><!-- Footer Ends-->
				<INPUT id="hidUniID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidUniID" runat="server">
				<INPUT id="hidPRN" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidPRN" runat="server">
				<INPUT id="hidMatchingRecCount" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidMatchingRecCount" runat="server"> 
				<INPUT id="hidDocCnt" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDocCnt" runat="server"> 
				<INPUT id="hidElgFormNo" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidElgFormNo" runat="server"> 
				<INPUT id="hidStudentName" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidStudentName" runat="server">
				<INPUT id="hidReturnFlag" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidReturnFlag" runat="server"> 
				<input id="hidCrMoLrnPtrnID" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidCrMoLrnPtrnID" runat="server">
				<input id="hidDocXML" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" name="hidDocXML" runat="server">
                <input id="hidInstID" runat="server" name="hidInstID" style="width: 24px; height: 22px" type="hidden" />
                <input id="hidpkStudentID" runat="server" name="hidpkStudentID" type="hidden" value="0" />
                <input id="hidpkYear" runat="server" name="hidpkYear" type="hidden" value="0" />     
                </div>
		</form>
	</body>
</HTML>
