		var activeElement = false;
		function setDate(x_position,y_position, elementName, sitepath ) 	
		{
			var x_pos, y_pos;
			x_pos = x_position;
			y_pos = y_position;

	
			activeElement = document.forms[0].elements[ elementName ];
			var w = window.open(sitepath+"DateSelector.htm", "DateSelector", "width=280,height=280,resizable=no,scrollbars=no,menu=no,location=no,status=no,top="+ y_position +",left="+ x_position +"");
			w.focus();
		}
		function GetDateSelectorDate() { return activeElement.value; }
		function SetDateSelectorDate( dateString ) {activeElement.value = dateString; }
