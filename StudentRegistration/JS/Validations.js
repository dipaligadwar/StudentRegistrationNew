
 //validation check for eligibility form number
		 function ChkEligFormNumber(val)
		 {
			var objRegExp  =/(^\d{3,4}\-\d{1,4}\-\d{1,4}-\d{1,7})/;
			if(objRegExp.test(val))
			{
			return true;
			}
			else
			{
			alert("Please check the Eligibility Form Number.eg(179-2000-121-194)");
			return objRegExp.test(val);
			}

		
		 }//end function
		 
		