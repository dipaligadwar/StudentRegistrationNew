
 //validation check for eligibility form number
		 function ChkEligFormNumber(val)
		 {
			var objRegExp  =/(^\d{1,5}\-\d{1,4}\-\d{1,4}-\d{1,7})/;
			if(objRegExp.test(val))
			{
			return true;
			}
			else
			{
			alert("Please check the Eligibility Form Number.eg(179-121-2000-194)");
			return objRegExp.test(val);
			}

		
		 }//end function
		 
		