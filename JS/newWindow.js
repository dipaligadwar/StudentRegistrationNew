function sendXML(strxml)
{
	var szRequest = "<RequestXML>";
	szRequest += strxml;
	szRequest += "</RequestXML>";
	var objHTTP = new ActiveXObject("Microsoft.XMLHTTP");
	var szURL = "insertSession.aspx";
	var szHttpMethod = "POST";
	objHTTP.Open(szHttpMethod, szURL, false);
	objHTTP.SetRequestHeader("Content-Type", "text/xml");
      objHTTP.setRequestHeader("User-Agent", "MyCustomUser");
	objHTTP.Send(szRequest);
	var szReply = objHTTP.ResponseText;
	return szReply;
}

function openNewWindow(newPage, strxml)
{
//toolbar=no,
	var flg;
	flg = sendXML(strxml);
	if (flg=="1")
	{
		newPage+=".aspx";
	   window.open(newPage,'','toolbar=no,resizable=yes,location=no,scrollbars=yes,status=yes,width=950,height=650');
	}
	else
	{
		alert("Sorry Try again");
	}
}