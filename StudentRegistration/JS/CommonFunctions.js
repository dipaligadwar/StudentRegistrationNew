
function ShowBorder(obj)
	{
		var width = obj.style.width;
		obj.style.cssText="border  : 1 solid #787878";
		obj.style.width = width;
	}
	function RemoveBorder(obj)
	{
		var width = obj.style.width;
		obj.style.cssText= "border  : 0 solid #787878";
		obj.style.width = width;
	}
	
	function ShowBorderNew(obj)
	{
		var width = obj.style.width;
		obj.style.cssText="border  : 1 solid #ffffff";
		obj.style.width = width;
	}
	function RemoveBorderNew(obj)
	{
		var width = obj.style.width;
		obj.style.cssText= "border  : 0 solid #ffffff";
		obj.style.width = width;
	}
						
	function SetCursorHand(obj)
	{
		obj.style.cursor = "hand";
	}
			
	function SetCursorDefault(obj)
	{
		obj.style.cursor = "default";
	}
			
	function SetBgColor(obj)
	{
		obj.style.backgroundColor="#D0E4EA";
		obj.style.cursor = "hand";
	}
			
	function SetDefaultbgColor(obj)
	{
		obj.style.backgroundColor="#FFFFFF";
		obj.style.cursor = "default";
	}
	
	function SetBgColorWthotHand(obj)
	{
		obj.style.backgroundColor="#D0E4EA";
	}
