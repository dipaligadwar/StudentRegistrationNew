
/*  **************************************************
This function is to use Ajax JavaScript Methods To Populate DropDown based on the Value
Selected From Parent DropDown.
************************************************** */


// To get FacultyWiseBranch..
var sTableCellID;
function getBranch(location,Uni_ID,Fac_ID)
{
		sTableCellID=location;
		clsAjaxMethodCD.FacultyWiseBranchList(Uni_ID,Fac_ID,BindDataToBranchCombo_CallBack);
}

function BindDataToBranchCombo_CallBack(response)
{		
		if(response.error == null)
		{
		  document.getElementById(sTableCellID).innerHTML = response.value +"&nbsp;(if any)";
		}			
}

// To Get all all ProgramTypeWiseProgram Level..
function getProgramLevel(location,PrgTy_ID)
{
		sTableCellID=location;
		clsAjaxMethodCD.ProgramTypeProgramLevel(PrgTy_ID,BindDataToCombo_CallBack);
}

// To get FacultyWise Courses..
function jsFillCr(location,Uni_ID,Fac_ID,HtmlSelCr_ID)
{		 
		sTableCellID=location;
		clsAjaxMethodCD.FacultyWiseCourse(Uni_ID,Fac_ID,HtmlSelCr_ID,BindDataToCombo_CallBack);
				
}
// Added on 25/8/06 for Faculty wise courses Without onchange Event..
function jsFillCr_withoutOnchange(location,Uni_ID,Fac_ID,HtmlSelCr_ID)
{
		sTableCellID=location;
		clsAjaxMethodCD.FacultyWiseCourse_withoutOnchange(Uni_ID,Fac_ID,HtmlSelCr_ID,BindDataToCombo_CallBack);
}

//FillCr with two functions in onchange attribute
function jsFillCr_fnSetTxt(location,Uni_ID,Fac_ID,HtmlSelCr_ID)
{
	sTableCellID=location;
	clsAjaxMethodCD.FacultyWiseCourse_fnSetTxt(Uni_ID,Fac_ID,HtmlSelCr_ID,BindDataToCombo_CallBack);
}

// Added on 25/8/06 for Faculty wise courses with fnSetTxt in onchange Event..
function jsFillCr_WithSetVal(location,Uni_ID,Fac_ID,HtmlSelCr_ID)
{		
		sTableCellID=location;
		clsAjaxMethodCD.FacultyWiseCourse_WithSetVal(Uni_ID,Fac_ID,HtmlSelCr_ID,BindDataToCombo_CallBack);
}

// To Get Coursewise mode of learning....
function jsFillMoLrn(location,Uni_ID,Fac_ID,Cr_ID,HtmlSelMoLrn_ID)
{ 		
		if(Uni_ID=="")
		  Uni_ID=0;
		if(Fac_ID=="")
		  Fac_ID=0;				
		if(Cr_ID=="")
		  Cr_ID=0;
		sTableCellID=location;
		clsAjaxMethodCD.allCourseModeOfLearning(Uni_ID,Fac_ID,Cr_ID,HtmlSelMoLrn_ID,BindDataToCombo_CallBack);
}

// Added on 25/8/06 for Courses Wise ModeOfLearning with fnSetTxt in onchange Event.. 
function jsFillMoLrn_WithSetVal(location,Uni_ID,Fac_ID,Cr_ID,HtmlSelMoLrn_ID)
{ 			
		if(Uni_ID=="")
		  Uni_ID=0;
		if(Fac_ID=="")
		  Fac_ID=0;				
		if(Cr_ID=="")
		  Cr_ID=0;
		sTableCellID=location;
		clsAjaxMethodCD.allCourseModeOfLearning_WithSetVal(Uni_ID,Fac_ID,Cr_ID,HtmlSelMoLrn_ID,BindDataToCombo_CallBack);
}

// Added on 25/8/06 for Course Wise ModeOfLearn Without onchange Event..
function jsFillMoLrn_withoutOnchange(location,Uni_ID,Fac_ID,Cr_ID,HtmlSelMoLrn_ID)
{ 
		if(Uni_ID=="")
		  Uni_ID=0;
		if(Fac_ID=="")
		  Fac_ID=0;				
		if(Cr_ID=="")
		  Cr_ID=0;
		sTableCellID=location;
		clsAjaxMethodCD.allCourseModeOfLearning_withoutOnchange(Uni_ID,Fac_ID,Cr_ID,HtmlSelMoLrn_ID,BindDataToCombo_CallBack);
}

// To get mode of learning wise course pattern....
function jsFillCrMoLrnWisePattern(location,CrMoLrn_ID,HtmlSelPattern_ID)
{
		sTableCellID=location;
		if(CrMoLrn_ID=="")
				CrMoLrn_ID=0;
		clsAjaxMethodCD.allCoursePatterns(CrMoLrn_ID,HtmlSelPattern_ID,BindDataToCombo_CallBack);
}

//To get Mode of learning wise course pattern...without ONCHange 
function jsFillCrMoLrnWisePattern_withoutOnChange(location,CrMoLrn_ID,HtmlSelPattern_ID)
{
	sTableCellID=location;
	if(CrMoLrn_ID=="")
		CrMoLrn_ID=0;
	clsAjaxMethodCD.allCoursePatterns_withoutOnChange(CrMoLrn_ID,HtmlSelPattern_ID,BindDataToCombo_CallBack);

}

// Added on 25/8/06 for ModeOfLearning Wise Course Pattern WithfnSetTxt...
function jsFillCrMoLrnWisePattern_WithSetVal(location,CrMoLrn_ID,HtmlSelPattern_ID)
{
		sTableCellID=location;
		if(CrMoLrn_ID=="")
				CrMoLrn_ID=0;
		clsAjaxMethodCD.allCoursePatterns_WithSetVal(CrMoLrn_ID,HtmlSelPattern_ID,BindDataToCombo_CallBack);
}


// To get Course Pattern wise course part....
function jsFillCrPart(location,CrMoLrnPtrn_ID,HtmlSelCrPart_ID)
{
		if(CrMoLrnPtrn_ID=="")
					CrMoLrnPtrn_ID=0;
		sTableCellID=location;
		clsAjaxMethodCD.AllCourseParts(CrMoLrnPtrn_ID,HtmlSelCrPart_ID,BindDataToCombo_CallBack);
}

// To get Coure part wise course part term....
function jsFillCrPtrnPartTerm(location,CrMoLrnPtrn_ID,CrPr_ID,HtmlSelPartTerm_ID)
{			
		if(CrMoLrnPtrn_ID=="")
					CrMoLrnPtrn_ID=0;		
				if(CrPr_ID=="")
					CrPr_ID=0;	
		sTableCellID=location;
		clsAjaxMethodCD.CoursePartTerms(CrMoLrnPtrn_ID,CrPr_ID,HtmlSelPartTerm_ID,BindDataToCombo_CallBack);
		
}

function jsFillCrPtrnPartTerm_Paperselect(location,CrMoLrnPtrn_ID,CrPr_ID,HtmlSelPartTerm_ID)
{			
		if(CrMoLrnPtrn_ID=="")
					CrMoLrnPtrn_ID=0;		
				if(CrPr_ID=="")
					CrPr_ID=0;	
		sTableCellID=location;
		clsAjaxMethodCD.CoursePartTerms_WithoutOnChange(CrMoLrnPtrn_ID,CrPr_ID,HtmlSelPartTerm_ID,BindDataToCombo_CallBack);
		
}


function jsFillCrPtrnPartTerm_WithoutOnChange(location,CrMoLrnPtrn_ID,CrPr_ID,HtmlSelPartTerm_ID)
{			
		if(CrMoLrnPtrn_ID=="")
					CrMoLrnPtrn_ID=0;		
				if(CrPr_ID=="")
					CrPr_ID=0;	
		sTableCellID=location;
		clsAjaxMethodCD.CoursePartTerms_WithoutOnChange(CrMoLrnPtrn_ID,CrPr_ID,HtmlSelPartTerm_ID,BindDataToCombo_CallBack);
		
			
}

function jsFillCrPtrnPartTerm_PaperFill(location,CrMoLrnPtrn_ID,CrPr_ID,HtmlSelPartTerm_ID)
{			
		if(CrMoLrnPtrn_ID=="")
					CrMoLrnPtrn_ID=0;		
				if(CrPr_ID=="")
					CrPr_ID=0;	
		sTableCellID=location;
		clsAjaxMethodCD.CoursePartTerms_PaperFill(CrMoLrnPtrn_ID,CrPr_ID,HtmlSelPartTerm_ID,BindDataToCombo_CallBack);
		
			
}

//To get Faculty wise subject....
function FillSubject(location,FacID)
{		
		var UniID=document.getElementById("hidUniID").value;
		document.getElementById("fk_Fac_ID").value=FacID;
		document.getElementById("pk_Fac_ID").value=FacID;
		sTableCellID=location;
		clsAjaxMethodCD.FacultyWiseSubjectList(UniID,FacID,BindDataToCombo_CallBack);
}

// To get Course Part Term wise Course Paper....
function jsFillCrPtrnPartTermPaper(location,pk_CrMoLrnPtrn_ID,pk_CrPr_ID,val,fk_Uni_ID)
{					
		var CrMoLrnPtrn_ID = pk_CrMoLrnPtrn_ID;	
		var CrPr_ID = pk_CrPr_ID;		
		var CrPrCh_ID=val;		
		var UniID = fk_Uni_ID;
		sTableCellID=location;
		clsAjaxMethodCD.CoursePartTermsPapers(CrMoLrnPtrn_ID,CrPr_ID,CrPrCh_ID,UniID,BindDataToCombo_CallBack);
}

// To get Course Part Term wise Paper Group....
function jsFillCrPaperGroup(location,CrMoLrnPtrn_ID,CrPr_ID,CrPrCh_ID)
{		
		sTableCellID=location;
		clsAjaxMethodCD.paperGroups(CrMoLrnPtrn_ID,CrPrCh_ID,CrPr_ID,BindDataToCombo_CallBack);		
}

function BindDataToCombo_CallBack(response)
{		
		if(response.error == null)
		{
		  document.getElementById(sTableCellID).innerHTML = response.value +"&nbsp;<FONT class='Mandatory'>*</FONT>";
		}			
}
	
//To get Course MoLrn Ptrn Branch Wise Course Part List - By Amit
function FetchCourseMoLrnPtrnBrnWiseCoursePartList(location, UniID, FacID, CrID, MoLrnID, PtrnID, BrnID,ddlCrPrDesc, lvlFlag)
{
    //FetchCourseMoLrnPtrnBrnWiseCoursePartList('tdCrPrDesc',hidUniID.value,hidFacID.value,hidCrID.value, hidMoLrnID.value, hidPtrnID.value, hidBrnID.value, 'ddlCrPrDesc'," + LevelFlag + ");ClearDropDowns(4," + LevelFlag + ");
    sTableCellID=location;
    clsAjaxMethodCD.FetchCourseMoLrnPtrnBrnWiseCoursePartList(UniID, FacID, CrID, MoLrnID, PtrnID, ddlCrPrDesc, lvlFlag);
}