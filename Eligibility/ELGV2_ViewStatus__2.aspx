<%@ Page Language="c#" MasterPageFile="~/Home.Master" Codebehind="ELGV2_ViewStatus__2.aspx.cs"
    AutoEventWireup="True" Inherits="StudentRegistration.Eligibility.ELGV2_ViewStatus__2"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    
    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

    <script language="javascript" type="text/javascript">
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

    <script language="javascript" type="text/javascript">
		
		function fnDocRecv(cbDocRecv)
		{
			var cbID = document.getElementById(cbDocRecv.id);
			var cnt = document.getElementById('ctl00_ContentPlaceHolder1_hidDocCnt').value;
			if(cbID.checked == true)
			{ 
				for(i=1; i<=cnt; i++)
				{
					
					var strCB = document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs').cells[((i+1)*5)-2].innerHTML;
					if(strCB.match(cbID.id) != null)
					{
						var strRB =document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs').cells[((i+1)*5)-1].innerHTML; 
						while(strRB.match("disabled") != null)
						{
							strRB = strRB.replace(/disabled/,"");
						}
						if(strRB.match("value=rbValidDoc") != null)
							strRB = strRB.replace(/value=rbValidDoc/,"value=rbValidDoc checked=\"checked\" ");
						document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs').cells[((i+1)*5)-1].innerHTML = strRB;
					}
				}
			}
			if(cbID.checked == false)
			{
				for(i=1; i<=cnt; i++)
				{
					
					var strCB = document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs').cells[((i+1)*5)-2].innerHTML;
					if(strCB.match(cbID.id) != null)
					{
						var strRB =document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs').cells[((i+1)*5)-1].innerHTML; 
						while(strRB.match("<SPAN>") != null)
						  	  strRB = strRB.replace(/<SPAN>/,"<SPAN disabled>");
						strRB = strRB.replace(/value=rbValidDoc/,"value=rbValidDoc disabled ");
						strRB = strRB.replace(/value=rbInvalidDoc/,"value=rbInvalidDoc disabled ");
						while(strRB.match("CHECKED") != null)
							strRB = strRB.replace(/CHECKED/,"");
							strRB =	strRB.replace("","<SPAN disabled>");
						document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs').cells[((i+1)*5)-1].innerHTML = strRB;
					}
				}
			}
		}
		
		function fnOnSubmit()
		{
			var cnt = document.getElementById('ctl00_ContentPlaceHolder1_hidDocCnt').value;
			var DocXML=document.getElementById('ctl00_ContentPlaceHolder1_hidDocXML');
			DocXML.value = "";
			for(var i=1;i<=cnt;i++)
			{
				
				if(document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs').cells[((i+1)*5)-2].childNodes[0].checked == true)
				{
					DocXML.value = DocXML.value + "1";    //Recieved_By_Uni = 1
					if(document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs').cells[((i+1)*5)-1].childNodes[0].checked == true)
						DocXML.value = DocXML.value + "1";   //Validity_By_Uni = 1
					if(document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs').cells[((i+1)*5)-1].childNodes[2].checked == true)
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
			if(document.getElementById('ctl00_ContentPlaceHolder1_rbDefaulter').checked == true)
			   document.getElementById('ctl00_ContentPlaceHolder1_divReason').style.display = 'block' ;
			if(document.getElementById('ctl00_ContentPlaceHolder1_rbPending').checked == true)
			   document.getElementById('ctl00_ContentPlaceHolder1_divReason').style.display = 'block' ;
			if(document.getElementById('ctl00_ContentPlaceHolder1_rbEligible').checked == true)
				document.getElementById('ctl00_ContentPlaceHolder1_divReason').style.display = 'none' ;
			document.getElementById('ctl00_ContentPlaceHolder1_btnSubmit').disabled = false;
			document.getElementById('ctl00_ContentPlaceHolder1_btnCancel').disabled = false;
			
		}
		
		
		function  fnConfirm()
		{
			var ch; 
			if(document.getElementById('ctl00_ContentPlaceHolder1_rbDefaulter').checked == true)
			{
			   if(document.getElementById('ctl00_ContentPlaceHolder1_tbReason').value == "")
			   {
			      alert('Please Enter a Valid Reason for marking this Student Non Eligible');
			      return false;
			   }
			   ch = confirm('Are you sure you want to mark this student as \"Non Eligible\" ?');
			}
			if(document.getElementById('ctl00_ContentPlaceHolder1_rbPending').checked == true)
			{
			   if(document.getElementById('ctl00_ContentPlaceHolder1_tbReason').value == "")
			   {	
			      alert('Please Enter a Valid Reason for keeping the Eligibility of Student Pending');
			      return false;
			   }
			   ch = confirm('Are you sure you want to keep the Eligibility of this student as \"Pending\" ?');
			}
			if(document.getElementById('ctl00_ContentPlaceHolder1_rbEligible').checked == true)
			   ch = confirm('Are you sure you want to mark this student as \"Eligible\" ?');
			fnOnSubmit();
			return false;
			//return ch;
		}
		
		function fnHelp()
		{
			document.getElementById('ctl00_ContentPlaceHolder1_divInstructions').style.display = "block";
		}
    </script>

    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="1">
            <tr>
                <%--<td class="FormName" align="left" valign="middle">
                    <asp:Label ID="lblTitle" runat="server" Font-Bold="True" CssClass="lblPageHead" meta:resourcekey="lblTitleResource1"></asp:Label>
                    <asp:Label ID="lblInstitute" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="lblInstituteResource1"></asp:Label>--%>
                    
                    <td align="left" style="border-bottom: 1px solid #FFD275;">
                        <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1" ></asp:Label>
                        <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                    <asp:Label ID="lblStudName" runat="server" Font-Size="Small" meta:resourcekey="lblStudNameResource1"></asp:Label></td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <p>
                        <div id="divStudentStatusDetails" runat="server">
                            <br>
                            <table class="tblBackColor" cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tr class="clSubHeading">
                                    <td colspan="4">
                                        <b>Registration Details of the Student</b></td>
                                </tr>
                                <tr class="rFont">
                                    <td width="30%">
                                        <b>Eligibility Status :</b></td>
                                    <td width="20%">
                                        <asp:Label ID="lblElgStatus" runat="server" Font-Bold="True" ForeColor="#C04000"
                                            meta:resourcekey="lblElgStatusResource1"></asp:Label></td>
                                    <td width="30%">
                                        <b>Reason(if any) :</b></td>
                                    <td width="20%" align="center">
                                        <asp:Label ID="lblElgReason" runat="server" Font-Bold="True" ForeColor="#C04000"
                                            meta:resourcekey="lblElgReasonResource1"></asp:Label></td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" width="30%">
                                        <b><asp:Label id="lblPermanentRegistrationNumber" runat="server" Text="Permanent Registration Number" meta:resourcekey="lblPermanentRegistrationNumberResource1"></asp:Label> </b>
                                        <td valign="top" width="20%">
                                            <asp:Label ID="lblPermRegNo" runat="server" Font-Bold="True" meta:resourcekey="lblPermRegNoResource1"></asp:Label></td>
                                        <td valign="top" width="30%">
                                            <b>Alumni of <%= lblUniversity.Text %></b></td>
                                        <td valign="top" width="20%">
                                            <asp:Label ID="lblAlumni" runat="server" meta:resourcekey="lblAlumniResource1" Text="No"></asp:Label></td>
                                </tr>
                            </table>
                            <br>
                            <div runat="server" id="divTblElgFormdetails">
                                <table class="tblBackColor" id="TblElgFormdetails" cellspacing="1" cellpadding="3"
                                    width="100%" border="0">
                                    <tr class="GridSubHeading">
                                        <td style="height: 16px" valign="top" colspan="4">
                                            <b>Eligibility Form Number of the Student&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </b>
                                            <asp:Label ID="lblEligibilityFormNo" runat="server" Font-Bold="True" meta:resourcekey="lblEligibilityFormNoResource1"></asp:Label></td>
                                    </tr>
                                </table>
                            </div>
                            <br>
                            <table class="tblBackColor" id="TblAdmission" style="display: none" cellspacing="0"
                                cellpadding="3" width="100%" border="0" runat="server">
                                <tbody>
                                    <tr class="clSubHeading">
                                        <td style="height: 18px;" colspan="4">
                                            <b>Admission Details of the Student</b>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td width="30%">
                                            <b>Admission Form Number :</b></td>
                                        <td width="20%">
                                            <asp:Label ID="lblAppFormNo" runat="server" meta:resourcekey="lblAppFormNoResource1"></asp:Label></td>
                                        <td width="30%">
                                            <b>Admission Date :</b></td>
                                        <td width="20%">
                                            <asp:Label ID="lblAdmissionDate" runat="server" meta:resourcekey="lblAdmissionDateResource1"></asp:Label></td>
                                    </tr>
                                    <tr class="rFont">
                                        <td width="30%">
                                            <b>
                                                <asp:Label ID="lblSeekingAdmCr" runat="server" Text="Seeking Admission in Course"
                                                    meta:resourcekey="lblSeekingAdmCrResource1"></asp:Label>
                                                :</b></td>
                                        <td width="70%" colspan="3">
                                            <asp:Label ID="lblCourse" runat="server" meta:resourcekey="lblCourseResource1"></asp:Label></td>
                                    </tr>
                                    <tr class="rFont">
                                        <td width="30%">
                                            <b><%= lblCollege.Text %> Name :</b></td>
                                        <td width="80%" colspan="3">
                                            <asp:Label ID="lblInstName" runat="server" meta:resourcekey="lblInstNameResource1"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                            <br>
                            <div id="divMatchingRecords" style="display: none" runat="server">
                                <asp:Label ID="lblGridName" runat="server" Height="18px" CssClass="GridHeadingM"
                                    Width="100%" Text="Other Course Eligibility Status" meta:resourcekey="lblGridNameResource1"></asp:Label><br>
                                <asp:GridView ID="DGMatchgCourseDetails1" runat="server" Width="100%" BorderStyle="Solid"
                                    PageSize="5" AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699"
                                    AllowPaging="True" OnPageIndexChanging="DGMatchgCourseDetails1_PageIndexChanging"
                                    meta:resourcekey="DGMatchgCourseDetails1Resource1">
                                    <RowStyle CssClass="GridData2"></RowStyle>
                                    <HeaderStyle CssClass="gridHeader" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                            <ItemTemplate>
                                                <%# (Container.DataItemIndex)+1 %>
                                            </ItemTemplate>
                                            <ItemStyle Width="3%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Course" HeaderText="Course" meta:resourcekey="BoundFieldResource1">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="InstituteName" HeaderText="College Name" meta:resourcekey="BoundFieldResource2">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EligibilityStatus" HeaderText="Eligibility Status" meta:resourcekey="BoundFieldResource3">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CourseStatus" HeaderText="Course Status" meta:resourcekey="BoundFieldResource4">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Reason" HeaderText="Reason" meta:resourcekey="BoundFieldResource5">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ElgFormNo" HeaderText="Eligibility Form Number" meta:resourcekey="BoundFieldResource6">
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
                                    </PagerStyle>
                                </asp:GridView>
                            </div>
                        </div>
                        <div id="divStudentDetails" runat="server">
                            
                            <%--<asp:Label ID="lblProfileHeading" runat="server" Height="18px" CssClass="GridHeadingM"
                                Width="100%" meta:resourcekey="lblProfileHeadingResource1"> Student's Profile</asp:Label>--%>
                            <table id="Table2" cellspacing="0" cellpadding="3" width="100%" border="0">
                                <tr>
                                    <td valign="top" width="80%">
                                        <table class="tblBackColor" id="Table3" cellspacing="1" cellpadding="3" width="100%"
                                            border="0">
                                            <tr class="clSubHeading">
                                                <td valign="top" colspan="4">
                                                    <b>Personal Details of the Student</b>
                                                </td>
                                            </tr>
                                            
                                            <tr class="rFont">
                                            <td valign="top" width="30%">
                                            <b>Name as appeared on Statement of Marks</b></td>
                                            <td valign="top" colspan="3">
                                            <asp:Label ID="lblNameAsMarksheet" runat="server"></asp:Label></td>
                                            </tr>

                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Full Name</b></td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblNameOfStudent" runat="server" meta:resourcekey="lblNameOfStudentResource1"></asp:Label></td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Father's Full Name</b></td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblFathersName" runat="server" meta:resourcekey="lblFathersNameResource1"></asp:Label></td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Mother's Maiden Name</b></td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblMothersMaidenName" runat="server" meta:resourcekey="lblMothersMaidenNameResource1"></asp:Label></td>
                                            </tr>
                                            <tr class="rFont" id="trChangedName" style="display: none" runat="server">
                                                <td valign="top" width="30%">
                                                    <b>Previous&nbsp;Name</b></td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblPreviousName" runat="server" meta:resourcekey="lblPreviousNameResource1"></asp:Label></td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Date of Birth</b></td>
                                                <td valign="top" width="30%">
                                                    <asp:Label ID="lblDOB" runat="server" meta:resourcekey="lblDOBResource1"></asp:Label></td>
                                                <td valign="top" width="20%">
                                                    <b>Gender</b></td>
                                                <td valign="top" width="20%">
                                                    <asp:Label ID="lblGender" runat="server" meta:resourcekey="lblGenderResource1"></asp:Label></td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="20%">
                                                    <b>Nationality</b></td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblNationality" runat="server" meta:resourcekey="lblNationalityResource1"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" width="20%">
                                        <table class="tblBackColor" id="Table4" cellspacing="1" cellpadding="3" width="100%"
                                            border="0">
                                            <tr class="clSubHeading">
                                                <td style="height: 16px" valign="top" align="center">
                                                    <b>Photograph</b></td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" align="center" style="height: 74px">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="../images/Member.gif" AlternateText="Photograph"
                                                        meta:resourcekey="Image1Resource1"></asp:Image></td>
                                            </tr>
                                            <tr class="clSubHeading">
                                                <td style="height: 16px" valign="top" align="center">
                                                    <b>Signature</b></td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" align="center">
                                                    <asp:Image ID="Image2" runat="server" AlternateText="Signature" ToolTip="Signature"
                                                        meta:resourcekey="Image2Resource1"></asp:Image></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table class="tblBackColor" id="Table5" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <br />
                                <tr class="clSubHeading">
                                    <td valign="top" colspan="4">
                                        <b>Reservation Details of the Student</b>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" width="20%">
                                        <b>State of Domicile</b></td>
                                    <td valign="top" width="30%">
                                        <asp:Label ID="lblDomicileState" runat="server" meta:resourcekey="lblDomicileStateResource1"></asp:Label></td>
                                    <td valign="top" width="20%">
                                        <b>Reservation Category</b></td>
                                    <td valign="top" width="30%">
                                        <asp:Label ID="lblResvCategory" runat="server" meta:resourcekey="lblResvCategoryResource1"></asp:Label></td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" width="20%">
                                        <b>Physically Challenged</b></td>
                                    <td valign="top" colspan="3">
                                        <asp:Label ID="lblPhyChlngd" runat="server" meta:resourcekey="lblPhyChlngdResource1"></asp:Label></td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top">
                                        <b>Social Reservation</b>
                                    </td>
                                    <td valign="top" colspan="3">
                                        <asp:Label ID="lblSocResv" runat="server" meta:resourcekey="lblSocResvResource1"></asp:Label></td>
                                </tr>
                            </table>
                            <br>
                            <table class="tblBackColor" cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tr class="clSubHeading">
                                    <td valign="top" colspan="4">
                                        <b>Guardian Details of the Student</b>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" width="30%">
                                        <b>Annual Income of the Guardian</b></td>
                                    <td valign="top" width="20%">
                                        <asp:Label ID="lblGuardianincome" runat="server" meta:resourcekey="lblGuardianincomeResource1"></asp:Label></td>
                                    <td valign="top" width="30%">
                                        <b>Occupation of the Guardian</b></td>
                                    <td valign="top" width="20%">
                                        <asp:Label ID="lblGuardianOccupation" runat="server" meta:resourcekey="lblGuardianOccupationResource1"></asp:Label></td>
                                </tr>
                            </table>
                            <br>
                            <table class="tblBackColor" id="Table6" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tr class="clSubHeading">
                                    <td valign="top">
                                        <b>Educational Details of the Student</b>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td>
                                        <asp:GridView ID="DGQualification1" runat="server" Width="100%" AutoGenerateColumns="False"
                                            BorderWidth="1px" BorderColor="Gainsboro" meta:resourcekey="DGQualificationResource1">
                                            <RowStyle CssClass="gridItem" />
                                            <HeaderStyle CssClass="gridHeader" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                            <Columns>
                                                <asp:BoundField DataField="Qualification" HeaderText="Qualification" meta:resourcekey="BoundFieldResource12">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CollegeInstituteName" HeaderText="College" meta:resourcekey="BoundFieldResource13">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Body" HeaderText="University" meta:resourcekey="BoundFieldResource14">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Marks_Obtained" HeaderText="Marks" meta:resourcekey="BoundFieldResource15">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Marks_OutOf" HeaderText="Out of" meta:resourcekey="BoundFieldResource16">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DateOfPassing" HeaderText="Passing Date" meta:resourcekey="BoundFieldResource17">
                                                    <HeaderStyle Font-Bold="True" CssClass="gridHeader" HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView></td>
                                </tr>
                            </table>
                            <br>
                            <table class="tblBackColor" id="Tbl4" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tr class="clSubHeading">
                                    <td valign="top">
                                        <b>Documents Submitted by the Student</b></td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" align="center" width="100%">
                                        <asp:GridView ID="DGSubmittedDocs1" runat="server" Width="90%" BorderStyle="Solid"
                                            PageSize="5" AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699" OnRowDataBound="DGSubmittedDocs1_RowDataBound" meta:resourcekey="DGSubmittedDocs1Resource1">
                                            <RowStyle CssClass="gridItem" />
                                            <HeaderStyle CssClass="gridHeader" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource2">
                                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                <ItemTemplate>
                                                    <center>
                                                        <%# (Container.DataItemIndex)+1 %>
                                                        <center>
                                                </ItemTemplate>
                                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                                <asp:BoundField DataField="DocCert_Desc" ReadOnly="True" HeaderText="Document Name" meta:resourcekey="BoundFieldResource7">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField ReadOnly="True" HeaderText="Received By College" meta:resourcekey="BoundFieldResource8">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Received By University" meta:resourcekey="TemplateFieldResource3">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cbDocRecv" runat="server" onclick="fnDocRecv(this);" Enabled="False" meta:resourcekey="cbDocRecvResource1">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Determine Validity " meta:resourcekey="TemplateFieldResource4">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rbValidDoc" runat="server" Text="Valid" GroupName="grpValidity"
                                                            Enabled="False" meta:resourcekey="rbValidDocResource1"></asp:RadioButton>
                                                        <asp:RadioButton ID="rbInvalidDoc" runat="server" Text="Invalid" GroupName="grpValidity"
                                                            Enabled="False" meta:resourcekey="rbInvalidDocResource1"></asp:RadioButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField  DataField="pk_DocCert_ID" ReadOnly="True" HeaderText="Doc_ID" meta:resourcekey="BoundFieldResource9">
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="RecvdBy_Uni" ReadOnly="True" HeaderText="RecvdBy_Uni" meta:resourcekey="BoundFieldResource10">
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="ValidityBy_Uni" ReadOnly="True" HeaderText="ValidityBy_Uni" meta:resourcekey="BoundFieldResource11">
                                                </asp:BoundField>
                                            </Columns>
                                        <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <br>
                        </div>
                        <br>
                        <table id="Table9" cellspacing="0" cellpadding="5" align="center" border="0">
                            <tr>
                                <td>
                                    <asp:Button ID="btnGoTo" runat="server" Text="Go Back" CssClass="butSubmit" OnClick="btnGoTo_Click"
                                        meta:resourcekey="btnGoToResource1"></asp:Button></td>
                            </tr>
                        </table>
                        <!--Main Ends-->
                        <input id="hidInstID" runat="server" name="hidInstID" style="width: 24px; height: 22px"
                            type="hidden" />
                        <input id="hidUniID" style="width: 40px; height: 22px" type="hidden" name="hidUniID"
                            runat="server">
                        <input id="hidPRN" type="hidden" name="hidPRN" runat="server">
                        <input id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server">
                        <input id="hidpkYear" type="hidden" name="hidpkYear" runat="server">
                        <input id="hidpkStudentID" type="hidden" name="hidpkStudentID" runat="server">
                        <input id="hidRef_InstReg_Uni_ID" type="hidden" name="hidRef_InstReg_Uni_ID" runat="server">
                        <input id="hidRef_InstReg_Institute_ID" type="hidden" name="Ref_InstReg_Institute_ID"
                            runat="server">
                        <input id="hidRef_InstReg_Year" type="hidden" name="Ref_InstReg_Year" runat="server">
                        <input id="hidRef_Student_ID" type="hidden" name="Ref_Student_ID" runat="server">
                        <input id="hidpkFacID" type="hidden" name="hidpkFacID" runat="server">
                        <input id="hidpkCrID" type="hidden" name="hidpkCrID" runat="server">
                        <input id="hidpkMoLrnID" type="hidden" name="hidpkMoLrnID" runat="server">
                        <input id="hidpkPtrnID" type="hidden" name="hidpkPtrnID" runat="server">
                        <input id="hidpkBrnID" type="hidden" name="hidpkBrnID" runat="server">
                        <input id="hidpkCrPrDetailsID" type="hidden" name="hidpkCrPrDetailsID" runat="server">
                        <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
                        <input id="hidStep" type="hidden" name="hidStep" runat="server">
                        <input id="hidElgFlag" type="hidden" name="hidElgFlag" runat="server">
                        <input id="hidDocXML" style="width: 40px; height: 22px" type="hidden" name="hidDocXML"
                            runat="server">
                              <input id="hidDOB" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
        runat="server">

                         <input type="hidden" id="hidSearchType" runat="server" />
                        <input id="hidDocCnt" type="hidden" name="hidDocCnt" runat="server">
                        <input id="hidIsBlank" runat="server" name="hidIsBlank" type="hidden" value="0" />
                       <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none" meta:resourcekey="lblUniversityResource1"></asp:Label>
                    <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
                    <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none" meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>

                </td>
            </tr>
        </table>
    </center>
</asp:Content>
