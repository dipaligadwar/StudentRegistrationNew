
<%@ Page language="c#" Codebehind="Divtagtest.aspx.cs" AutoEventWireup="True" Inherits="StudentRegistration.Divtagtest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Digital University - Student Registration</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/UniPortal.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="JS/header.js"></script>
		<script language="javascript" src="JS/footer.js"></script>
		<script language="javascript" src="JS/SPXMLHTTP.js"></script>
		<script language="javascript" src="JS/change.js"></script>
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
eval("divMStudentDetails.style.pixelTop=" +event.clientY);
//eval("divMStudentDetails.style.pixelLeft=" + event.clientX); 
}
//zxcTO=setTimeout(1000);


}
}
  window.onscroll=Scroll;

 

		
		</script>
		<script language="javascript">
		function fnShowdiv()
		{
		 alert("Show div");
		 
		}
		
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div align=center>
				<!-- Header Starts-->
				
				<!-- Heading Ends-->
				<!-- Main Starts-->
				<table height="100%" cellSpacing="0" cellPadding="0" width="95%" border="0">
					<TBODY>
						<tr>
						    <td class="SideLeft" vAlign="top" align="left" width="18%">
						        <!--Menu Start Here-->
								
								<!--Menu Ends Here-->
							</td>
							<td vAlign="top" align="left" width="2%">&nbsp;</td>
							<td vAlign="top" align="left" width="80%">
								<table cellSpacing="0" cellPadding="0" border="0">
									<tr>
										<td colspan="2" align="center">
											<asp:Button Runat="server" ID="btnshow" Text="Show" onclick="btnshow_Click"></asp:Button>
										</td>
									</tr>
								</table>
								<div id="divMStudentDetails" style=" BORDER-RIGHT:#800000 solid; BORDER-TOP:#800000 solid; DISPLAY:none; BORDER-LEFT:#800000 solid; WIDTH:760px; BORDER-BOTTOM:#800000 solid; POSITION:absolute; TOP:100px; HEIGHT:200px; BACKGROUND-COLOR:white" runat="server">
									<table onmousedown="dragStart(event, 'divMStudentDetails')" style="CURSOR: move; BACKGROUND-COLOR: #800000" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="GridHeadingM1" width="100%"><asp:label id="lblMProfileHeading" runat="server" Height="18px">Selected Student's Profile</asp:label></td>
											<td align="right"><IMG id="imgClose" style="CURSOR: hand" onclick="WinClose('imgClose')" src="../images/closeBtn.GIF"
											align="right"></td>
										</tr>
									</table>
									<div id="divScroll" style="OVERFLOW: auto; HEIGHT: 200px" runat="server" TOP="150px"><br><br>
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td width="30%">
													<asp:Label ID="lblone" Runat="server">Name</asp:Label>
												</td>
												<td width="70%">
													<asp:TextBox id="txtone" Runat="server"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td width="30%">
													<asp:Label ID="lbltwo" Runat="server">Address</asp:Label>
												</td>
												<td width="70%">
													<asp:TextBox id="txttwo" Runat="server"></asp:TextBox>
												</td>
											</tr>
										</table>
									</div>
								</div>
							</td>
						</tr>
					</TBODY>
				</table>				
				 <INPUT id="hidElgFormNo" type="hidden" name="hidElgFormNo" runat="server">
				 <INPUT id="hidSearchType" type="hidden" name="hidSearchType" runat="server">
			</div>
		</form>
	</body>
</HTML>
