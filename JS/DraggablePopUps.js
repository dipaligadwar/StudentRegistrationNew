
var Rdiff=0;

var WinCollection = new Array()
var WinCtr=-1;
var ctrMin=0;
var ctrMax=0;

var dragObj = new Object();
dragObj.zIndex = 100;

var iframeObj = new Object();
iframeObj.zIndex = 99;

function dragStart(event, id,fid) 
{
  document.getElementById(fid).style.display = "block";
  var el;
  var x, y;


  if (id)
    dragObj.elNode = document.getElementById(id);
  else 
      dragObj.elNode = window.event.srcElement;

  if (fid)
	  iframeObj.elNode = document.getElementById(fid);
  else 
      iframeObj.elNode = window.event.srcElement;

    x = window.event.clientX + document.documentElement.scrollLeft
      + document.body.scrollLeft;
    y = window.event.clientY + document.documentElement.scrollTop
      + document.body.scrollTop;
  
    


  dragObj.cursorStartX = x;
  iframeObj.cursorStartX = x;
  dragObj.cursorStartY = y;
  iframeObj.cursorStartY = y;
  dragObj.elStartLeft  = parseInt(dragObj.elNode.style.left, 10);
  iframeObj.elStartLeft  = parseInt(iframeObj.elNode.style.left, 10);
  dragObj.elStartTop   = parseInt(dragObj.elNode.style.top,  10);
  iframeObj.elStartTop   = parseInt(iframeObj.elNode.style.top,  10);
  
  if (isNaN(dragObj.elStartLeft)) 
  {
	iframeObj.elStartLeft = 0;
	dragObj.elStartLeft = 0;
  }
  if (isNaN(dragObj.elStartTop)) 
  {
	 dragObj.elStartTop  = 0;
	 iframeObj.elStartTop  = 0;
  }


  dragObj.elNode.style.zIndex = ++dragObj.zIndex;
  iframeObj.elNode.style.zIndex = ++iframeObj.zIndex;

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
 


   dragObj.elNode.style.left = (dragObj.elStartLeft + x - dragObj.cursorStartX) + "px";
   iframeObj.elNode.style.left = (iframeObj.elStartLeft + x - iframeObj.cursorStartX) + "px";
   dragObj.elNode.style.top  = (dragObj.elStartTop  + y - dragObj.cursorStartY) + "px";
   iframeObj.elNode.style.top  = (iframeObj.elStartTop  + y - iframeObj.cursorStartY) + "px";
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
	 
  	 document.getElementById('HelpShim').style.display="none";
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