function fnSelectData(txtName,cmbName)
{
	for(i=0;i<cmbName.options.length;i++)
	{
		if(cmbName.options[i].value==txtName.value)
		{
			cmbName.options[i].selected=true;
			return;
		}					
	}
	
	if(txtName.value!="")
	{
		alert("No data available for the given value");
	}
				
	cmbName.options[0].selected=true;
	txtName.value=cmbName.options[cmbName.selectedIndex].value;
	txtName.select();
}

function fnSetTxt(cmbName,txtName)
{
	
	//document.getElementById(txtName).value=cmbName.options[cmbName.selectedIndex].value;
	txtName.value=cmbName.options[cmbName.selectedIndex].value;
}
