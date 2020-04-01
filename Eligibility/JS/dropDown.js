/*  **************************************************
This function is to populate DropDown based on the Value
Selected From First DropDown
XML- HTTP XMLDOM Object
************************************************** */

function RemoveAll(ListBox)
{
	if (ListBox == null)
		return;
	ListBox.selectedIndex = -1;
	var iListBoxLength = ListBox.options.length;
	for (var i = 0; i < iListBoxLength; i++)
		ListBox.options.remove(0);
}

//Get states for the given country
function GetXML(MyAction, MyValue)
{
	var szRequest = "<RequestXML MyAction='";
	szRequest += MyAction;
	szRequest += "' MyValue='";
	szRequest += MyValue;
	szRequest += "'></RequestXML>";
	var objHTTP = new ActiveXObject("Microsoft.XMLHTTP");
	var szURL = "DropDown.aspx";
	var szHttpMethod = "POST";
	objHTTP.Open(szHttpMethod, szURL, false);
	objHTTP.SetRequestHeader("Content-Type", "text/xml");
	
      objHTTP.setRequestHeader("User-Agent", "MyCustomUser");
          
	objHTTP.Send(szRequest);

	var szReply = objHTTP.ResponseText;
	
	if (objHTTP.status != 200)
	{
		alert("am in 200");
		//failure
		szReply = "";
	}
	return szReply;
}

//Display states in 'StatesList' listbox for the given country name
function DisplayXML(cmbName, MyValue, MyAction)
{

	if (cmbName == null)
		return;
	cmbName.selectedIndex = -1;

	RemoveAll(cmbName) 
	var xmlStates = GetXML(MyAction, MyValue);
	var objXmlDom = new ActiveXObject("Microsoft.XMLDOM");
	if (!objXmlDom.loadXML(xmlStates))
	{
	    var sErr = "Response XML String is messed up\n" + xmlStates;
	}
	else
	{
		var nodes = objXmlDom.selectNodes("/Response/MyChild");
		for (var i = 0; i < nodes.length; i++)
		{
			var objOption = document.createElement("option");
			objOption.text = nodes[i].text;
			objOption.value = nodes[i].getAttribute("id");
			//var myCmb=getElementById(cmbName);
			cmbName.add(objOption);
		}
	}
}

/* Populate DropDown Function Ends Here  */