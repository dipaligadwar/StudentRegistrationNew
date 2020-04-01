


//added by sham gaikwad
//date 18/8/2006

var sTableCellID;  
//To get the dropdown which is not mandatory
function  BindDataToCombo_CallBack(response)
		{
			if(response.error == null)
			{
				document.getElementById(sTableCellID).innerHTML = response.value;
			}			
		}


//To get the dropdown which is mandatory		
function  BindDataToCombo_CallBackCom(response)
		{
			if(response.error == null)
			{
				document.getElementById(sTableCellID).innerHTML = response.value + "<font class=Mandatory>*</font>";
			}			
		}
				
		
//function to fill the districts drop down depends on the state	
	
	function FillDistrict(location,val,Dist,j)
{
    sTableCellID=location;   
    clsAjaxMethods.FillDistrict(val,Dist,j,BindDataToCombo_CallBack);
}	
//function to fill the Taluka drop down depends on the Districts
 
function FillTaluka(location,val,Tal,j)
{
		sTableCellID=location;		
		clsAjaxMethods.FillTaluka(val,Tal,j,BindDataToCombo_CallBack);
}


//To get the dropdown which is mandatory
//function to fill the districts drop down depends on the state	
	
	function FillDistrictCom(location,val,Dist,j)
{
    sTableCellID=location;   
    clsAjaxMethods.FillDistrict(val,Dist,j,BindDataToCombo_CallBackCom);
}	
//function to fill the Taluka drop down depends on the Districts
 
function FillTalukaCom(location,val,Tal,j)
{
		sTableCellID=location;		
		clsAjaxMethods.FillTaluka(val,Tal,j,BindDataToCombo_CallBackCom);
}


//function to fill the Course Name drop down depends on the Faculty Name

function FillCourseName(location,val,coursename)
{
		var UniID=document.getElementById("hidUniID").value;				
		sTableCellID=location;
		clsAjaxMethods.FillCourseName(UniID,val,coursename,BindDataToCombo_CallBackCom);		
}
//function to fill the Mode of learning drop down depends on the Course Name
function FillModeOfLearning(location,val,ModeOflearn)
{   
		var UniID=document.getElementById("hidUniID").value;
		var FacID=document.getElementById("hidFacID").value;
		document.getElementById("hidCrID").value=val;						
		sTableCellID=location;
		clsAjaxMethods.FillModeOfLearning(UniID,FacID,val,ModeOflearn,BindDataToCombo_CallBackCom);
	  
}
//function to fill the Course Pattern drop down depends on the Mode of learning
  function FillCoursePattern(location,val,coursepattern)
{
		var UniID=document.getElementById("hidUniID").value;
		sTableCellID=location;
		clsAjaxMethods.FillCoursePattern(UniID,val,coursepattern,BindDataToCombo_CallBackCom);
		
}
//function to fill the Course Part drop down depends on the Course part
function FillCoursePart(location,val,coursepart)
{	
        var UniID=document.getElementById("hidUniID").value;
        var InstID=document.getElementById("hidInstID").value;
		sTableCellID=location;
		clsAjaxMethods.FillCoursePart(UniID,InstID,val,coursepart,BindDataToCombo_CallBackCom);
}

//function to fill the Course Part drop down depends on the Course PartTerm
function FillCoursePartTerm(location,val,partTerm)
{
		var CrMoLrnPtrn_ID=document.getElementById("hidCrMoLrnPtrnID").value;			
		sTableCellID=location;
		clsAjaxMethods.FillCoursePartTerm(CrMoLrnPtrn_ID,val,partTerm,BindDataToCombo_CallBackCom);
}


//function to fill the Program Level drop down 
function FillProgramLevel(location,val,programlevel)
{
  	var UniID=document.getElementById("hidUniID").value;
  	sTableCellID=location;  
 	clsAjaxMethods.FillProgramLevel(UniID,val,programlevel,BindDataToCombo_CallBack);
}










//all belows functions are for to affiliate subject paper
//function to fill the Course Name drop down depends on the Faculty Name

function FillAssignedCourses(location,val,Cname,j)
{
		var pk_Uni_ID=document.getElementById("hidUniID").value;
		var pk_Inst_ID=document.getElementById("hidInstID").value;	
		sTableCellID=location;
		clsAjaxMethods.FillAssignedCourses(pk_Uni_ID,pk_Inst_ID,val,Cname,j,BindDataToCombo_CallBackCom);		
}


//function to fill the Mode of learning drop down depends on the Course Name
function FillAssignedCrModeLearning(location,val,Mol,j)
{
		var pk_Uni_ID=document.getElementById("hidUniID").value;	
		var pk_Inst_ID=document.getElementById("hidInstID").value;	
		var pk_Fac_ID=document.getElementById("hidFacID").value;
		sTableCellID=location;
		clsAjaxMethods.FillAssignedCrModeLearning(pk_Uni_ID,pk_Inst_ID,pk_Fac_ID,val,Mol,j,BindDataToCombo_CallBackCom);
}

//function to fill the Course Pattern drop down depends on the Mode of learning


  function  FillAssignedCrPattern(location,val,Cpattern,j)
{
		var pk_Uni_ID=document.getElementById("hidUniID").value;	
		var pk_Inst_ID=document.getElementById("hidInstID").value;	
		var pk_Fac_ID=document.getElementById("hidFacID").value;
		var pk_Cr_ID=document.getElementById("hidCrID").value;
		sTableCellID=location;
		clsAjaxMethods.FillAssignedCrPattern(pk_Uni_ID,pk_Inst_ID,pk_Fac_ID,pk_Cr_ID,val,Cpattern,j,BindDataToCombo_CallBackCom);
}



//function to fill the Course Part drop down depends on the Course part

function FillAssignedCrPart(location,val,Cpart,j)
{
		var pk_Uni_ID=document.getElementById("hidUniID").value;	
		var pk_Inst_ID=document.getElementById("hidInstID").value;	
		sTableCellID=location;
		clsAjaxMethods.FillAssignedCrPart(pk_Uni_ID,pk_Inst_ID,val,Cpart,j,BindDataToCombo_CallBackCom);
}


//function to fill the Course Part drop down depends on the Course PartTerm

function FillAssignedCrPartTerm(location,val,Cpterm)
{
			var pk_Uni_ID=document.getElementById("hidUniID").value;	
			var pk_Inst_ID=document.getElementById("hidInstID").value;	
			var pk_CrMoLrnPtrn_ID=document.getElementById("hidCrMoLrnPtrnID").value;
			sTableCellID=location;
     		clsAjaxMethods.FillAssignedCrPartTerm(pk_Uni_ID,pk_Inst_ID,pk_CrMoLrnPtrn_ID,val,Cpterm,BindDataToCombo_CallBackCom);
}

//function to fill the Course Pattern drop down depends on the Mode of learning
//for Assigned Capacity

  