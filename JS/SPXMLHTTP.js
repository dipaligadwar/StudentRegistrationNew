function RemoveAll(ListBox)
{
	if (ListBox == null)
		return;
	ListBox.selectedIndex = -1;
	var iListBoxLength = ListBox.options.length;
	for (var i = 0; i < iListBoxLength; i++)
		ListBox.options.remove(0);
}


function sendXMLSP(SPName,KeyValueXML)
{
	var szRequest = "<RequestXML SPName='"+SPName+"'>";
	szRequest += KeyValueXML;
	szRequest += "</RequestXML>";
	var objHTTP = new ActiveXObject("Microsoft.XMLHTTP");
	var szURL = "rptDropDown.aspx";
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

function XMLSP(cmbName,SPName,KeyValueXML,valueName, textName)
{
	
	if (cmbName == null)
		return;
	
	cmbName.selectedIndex = -1;
	RemoveAll(cmbName) ;
	var xmlChilds = sendXMLSP(SPName,KeyValueXML);
	
	
	var objXmlDom = new ActiveXObject("Microsoft.XMLDOM");
	
	if (!objXmlDom.loadXML(xmlChilds))
	{
	    var sErr = "Response XML String is messed up\n" + xmlChilds;
		alert(sErr);
	}
	else
	{
		var nodes = objXmlDom.selectNodes("/NewDataSet/Table");
		
		var objOption = document.createElement("option");
		objOption.text = "---- Select ----";
		objOption.value = "0";
		cmbName.add(objOption);
		for (var i = 0; i < nodes.length; i++)
		{
			
			objOption = document.createElement("option");
			objOption.text = nodes[i].selectNodes("textName")[0].text;
			objOption.value = nodes[i].selectNodes("valueName")[0].text;
			
			cmbName.add(objOption);
			
		}
		
	}
}
function XMLSP(cmbName,SPName,KeyValueXML,selectFlag)
{
	
	if (cmbName == null)
		return;
	
	cmbName.selectedIndex = -1;
	RemoveAll(cmbName) ;
	var xmlChilds = sendXMLSP(SPName,KeyValueXML);
	
	
	var objXmlDom = new ActiveXObject("Microsoft.XMLDOM");
	
	if (!objXmlDom.loadXML(xmlChilds))
	{
	    var sErr = "Response XML String is messed up\n" + xmlChilds;
		alert(sErr);
	}
	else
	{
		
		
		var nodes = objXmlDom.selectNodes("/NewDataSet/Table");
		
		var objOption = document.createElement("option");
		if(selectFlag=="Y")
		{
			objOption.text = "---- Select ----";
			objOption.value = "0";
			cmbName.add(objOption);
		}
		
				for (var i = 0; i < nodes.length; i++)
		{
			
			objOption = document.createElement("option");
			objOption.text = nodes[i].selectNodes("Text")[0].text;
			objOption.value = nodes[i].selectNodes("Value")[0].text;
			cmbName.add(objOption);
			
		}
		
	}
	
	
}