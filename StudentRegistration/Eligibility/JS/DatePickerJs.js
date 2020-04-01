		var activeElement = false;
		function setDate( elementName )	{
			activeElement = document.forms[0].elements[ elementName ];
			var w = window.open("DateSelector.htm", "DateSelector", "width=280,height=280,resizable=no,scrollbars=no,menu=no,location=no,status=no");
			w.focus();
		}
		function GetDateSelectorDate() { return activeElement.value; }
		function SetDateSelectorDate( dateString ) { activeElement.value = dateString; }
