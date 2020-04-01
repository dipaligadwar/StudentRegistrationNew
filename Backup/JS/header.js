function fnHeaderMatter()
{	
	sReturn="<table cellSpacing='1' cellPadding='3' width='100%' border='0'>"+
				"<tr>"+
					"<td vAlign='middle' align='center' width='40'><img border='0' src='images/l.gif'></td>"+
					"<td width='600'>"+
						"<IMG height='41' src='images/p.gif' width='400' border='0'>&nbsp;&nbsp;"+
					"</td>"+
					"<td align='right'>"+
						"<a href='mainHome.aspx'><b><font face='Verdana' color='#808080' size='1'>Log Off</font></b></a>"+
						"<b><font face='Verdana' color='#808080' size='1'> | Help</font></b>"+
					"</td>"+
				"</tr>"+
			"</table>";
		
	document.write(sReturn);
}