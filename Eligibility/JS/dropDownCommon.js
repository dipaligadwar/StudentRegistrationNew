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

//Get childs for the given parent
function GetXML(MySQLFld, MySQLTbl, MySQLCondn, txtField, valField)
{
	var szRequest = '<RequestXML MySQLFld="';
	szRequest += MySQLFld;
	szRequest += '" MySQLTbl="';
	szRequest += MySQLTbl;
	szRequest += '" MySQLCondn="';
	szRequest += MySQLCondn;
	szRequest += '" txtField="';
	szRequest += txtField;
	szRequest += '" valField="';
	szRequest += valField;
	szRequest += '"></RequestXML>';	
	
//	alert(szRequest);
	
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
		//failure
		szReply = "";
	}
	return szReply;
}

//Display childs child-listbox for the given parent
function DisplayXML(cmbName, MySQLFld, MySQLTbl, MySQLCondn, txtField, valField)
{
	
	if (cmbName == null)
		return;
	cmbName.selectedIndex = -1;

	RemoveAll(cmbName) ;
	var xmlChilds = GetXML(MySQLFld, MySQLTbl, MySQLCondn, txtField, valField);
	
	var objXmlDom = new ActiveXObject("Microsoft.XMLDOM");
	if (!objXmlDom.loadXML(xmlChilds))
	{
	    var sErr = "Response XML String is messed up\n" + xmlChilds;
		alert(sErr);
	}
	else
	{
		var nodes = objXmlDom.selectNodes("/Response/MyChild");
		var objOption = document.createElement("option");
		objOption.text = "---- Select ----";
		objOption.value = "0";
		cmbName.add(objOption);
		for (var i = 0; i < nodes.length; i++)
		{
			objOption = document.createElement("option");
			objOption.text = nodes[i].text;
			objOption.value = nodes[i].getAttribute("id");
			//var myCmb=getElementById(cmbName);
			cmbName.add(objOption);
		}
	}
}

/* Populate DropDown Function Ends Here  */

//Function to Populate DropDownList with additional Parameter
//to Insert Item ----Select---- with value 0.
//Modified By Rajnish
//25/08/2005

function DisplayXML(cmbName, MySQLFld, MySQLTbl, MySQLCondn, txtField, valField,sSelected)
{
	
	if (cmbName == null)
		return;
	cmbName.selectedIndex = -1;

	RemoveAll(cmbName) ;
	
	var xmlChilds = GetXML(MySQLFld, MySQLTbl, MySQLCondn, txtField, valField);
	//alert(MySQLFld);
	//alert(MySQLTbl);
	//alert(MySQLCondn);
	
	var objXmlDom = new ActiveXObject("Microsoft.XMLDOM");
	if (!objXmlDom.loadXML(xmlChilds))
	{
	    var sErr = "Response XML String is messed up\n" + xmlChilds;
		alert(sErr);
	}
	else
	{
		var nodes = objXmlDom.selectNodes("/Response/MyChild");
		var objOption = document.createElement("option");
		
		if(sSelected == "Y")
		{
			objOption.text = "---- Select ----";
			objOption.value = "0";
			cmbName.add(objOption);
		}
		
		for (var i = 0; i < nodes.length; i++)
		{
			objOption = document.createElement("option");
			objOption.text = nodes[i].text;
			objOption.value = nodes[i].getAttribute("id");
			//var myCmb=getElementById(cmbName);
	
			cmbName.add(objOption);
		}
	}
}



