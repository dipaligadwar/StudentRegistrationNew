//***********************************   Developed By Farhat Pirzada   ******************************************//
//***********************************        On July 24th 2007        ******************************************//


function ChkDissociate()
{
	if(confirm("Are you sure...\nYou want to dissociate the Template from the Course...!!!"))
	{
		if(document.getElementById("hidActive").value=="1" ||document.getElementById("hidLaunched").value=="1")
		{
			alert("Record is in Launched/Active mode, hence Template cannot be dissociated from the Course..");
			return false;
		}
		return true;
	}
	else
	{
		return false;
	}
}
			
function setValue(Text,Value)
{
	var text = eval(document.getElementById(Text));
	text.value = Value;
}	
			
function fnSubmitValidate()
{
	var strCr = document.getElementById('ddlFacDesc')[document.getElementById('ddlFacDesc').selectedIndex].text+' - ';
	strCr += document.getElementById('ddlCrDesc')[document.getElementById('ddlCrDesc').selectedIndex].text+' - ';
	strCr += document.getElementById('ddlModeLrnDesc')[document.getElementById('ddlModeLrnDesc').selectedIndex].text+' - ';
	strCr += document.getElementById('ddlCrPtrnDesc')[document.getElementById('ddlCrPtrnDesc').selectedIndex].text;
		
	document.getElementById('hidCourseDetails').value = strCr;
		
	var i=-1;
	var myArr= new Array();
		
	myArr[++i]= new Array(document.getElementById("ddlFacDesc"),-1,"Please Select Faculty","select");
	myArr[++i]= new Array(document.getElementById("ddlCrDesc"),-1,"Please Select Course","select");
	myArr[++i]= new Array(document.getElementById("ddlModeLrnDesc"),-1,"Please Select Mode of Learning","select");
	myArr[++i]= new Array(document.getElementById("ddlCrPtrnDesc"),-1,"Please Select Course Pattern","select");
				
				
	var ret=validateMe(myArr,50); 
				
	return ret;
					
}
			
function fnCheckSelection(cb)
{
	var cbID = document.getElementById(cb.id);
	var cnt = document.getElementById('hidTemplatesCount').value;
	if(cbID.checked == true)
	{ 
		for(i=1; i<=cnt; i++)
		{
			var str = document.getElementById('dgResultTemplates').cells[((i+1)*5)-1].innerHTML;
			if(str.match(cbID.id) == null)
			{
				document.getElementById('dgResultTemplates').cells[((i+1)*5)-1].innerHTML = str.replace(/CHECKED/,"");
			}
											
		}
			
	}
	document.getElementById('btnSave').disabled = "";				
}
				
//Code for Draggable Popup for Result Calculation Templates...

function fnFetchResultCalTemplateDetails(UniID,ResultCalTemplateID)
{
	 document.getElementById('HelpShim').style.display = "block";
	 document.getElementById('divSelectedTemplateDetails').style.display = "block";
	 clsAjaxMethodCD.FetchResultCalTemplateDetails(UniID, ResultCalTemplateID, FetchResultCalTemplateDetails_CallBack);
}
			
function FetchResultCalTemplateDetails_CallBack(response)
{
	var ds = response.value;
	
	if(document.getElementById('hidEvalSysID').value == "1")    //Marks hence Class Templates
	{
		document.getElementById('divClassTemplate').style.display = "block";
		document.getElementById('divGPATemplate').style.display = "none";
		
		if(ds.Tables[0].Rows.length > 0)
		{
			document.getElementById('lblCTEvlSys').innerText = ds.Tables[0].Rows[0].EvlSys;
			document.getElementById('lblCTName').innerText = ds.Tables[0].Rows[0].TName;
			document.getElementById('lblCTDesc').innerText = ds.Tables[0].Rows[0].TDesc;

		}
		
		if(ds.Tables[1].Rows.length>0)
		{
			var tbl=document.getElementById('tblClassTemplateDesign').getElementsByTagName("tbody")[0];
			if(tbl.rows.length!=0)
			{
				var cnt = tbl.rows.length;
				for(var k=1;k<cnt && k!=cnt;k++)
				{
					if(tbl.rows.length!=0)
					{
						tbl.deleteRow(1);
					}
				}
			}
			for(var i=0; i<ds.Tables[1].Rows.length; i++)
			{
				var row=document.createElement("TR");
				row.setAttribute('align','center');
				var cell=document.createElement("TD");
				cell.innerHTML=ds.Tables[1].Rows[i].SrNo;
				row.appendChild(cell);
				var cell1=document.createElement("TD");
				cell1.innerHTML=ds.Tables[1].Rows[i].Description;
				cell1.setAttribute('align','left');
				row.appendChild(cell1);
				var cell2=document.createElement("TD");
				cell2.innerHTML=ds.Tables[1].Rows[i].Range_From;
				row.appendChild(cell2);
				var cell3=document.createElement("TD");
				cell3.innerHTML=ds.Tables[1].Rows[i].Range_To;
				row.appendChild(cell3);
								
				tbl.appendChild(row);
			}
			document.getElementById('tblClassTemplateDesign').style.display = "block";
		}
	}
	if(document.getElementById('hidEvalSysID').value == "2")   //Grading hence GPA Templates
	{
		document.getElementById('divClassTemplate').style.display = "none";
		document.getElementById('divGPATemplate').style.display = "block";
		
		if(ds.Tables[0].Rows.length > 0)
		{
			document.getElementById('lblGPATEvlSys').innerText = ds.Tables[0].Rows[0].EvlSys;
			document.getElementById('lblGPATGradeScale').innerText = ds.Tables[0].Rows[0].GradeScale;
			document.getElementById('lblGPATName').innerText = ds.Tables[0].Rows[0].TName;
			document.getElementById('lblGPATDesc').innerText = ds.Tables[0].Rows[0].TDesc;

		}
		
		if(ds.Tables[1].Rows.length>0)
		{
			var tbl=document.getElementById('tblGPATemplateDesign').getElementsByTagName("tbody")[0];
			if(tbl.rows.length!=0)
			{
				var cnt = tbl.rows.length;
				for(var k=1;k<cnt && k!=cnt;k++)
				{
					if(tbl.rows.length!=0)
					{
						tbl.deleteRow(1);
					}
				}
			}
			for(var i=0; i<ds.Tables[1].Rows.length; i++)
			{
				var row=document.createElement("TR");
				row.setAttribute('align','center');
				var cell=document.createElement("TD");
				cell.innerHTML=ds.Tables[1].Rows[i].SrNo;
				row.appendChild(cell);
				var cell1=document.createElement("TD");
				cell1.innerHTML=ds.Tables[1].Rows[i].Abbr;
				row.appendChild(cell1);
				var cell2=document.createElement("TD");
				cell2.innerHTML=ds.Tables[1].Rows[i].Range_From;
				row.appendChild(cell2);
				var cell3=document.createElement("TD");
				cell3.innerHTML=ds.Tables[1].Rows[i].Range_To;
				row.appendChild(cell3);
				var cell4=document.createElement("TD");
				cell4.innerHTML=ds.Tables[1].Rows[i].GradeLevel;
				row.appendChild(cell4);
				var cell5=document.createElement("TD");
				cell5.innerHTML=ds.Tables[1].Rows[i].Description;
				row.appendChild(cell5);
				tbl.appendChild(row);
			}
			document.getElementById('tblGPATemplateDesign').style.display = "block";
		}
	}	
	
}
