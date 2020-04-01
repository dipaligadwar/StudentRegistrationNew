
 //validation check for eligibility form number
		 function ChkEligFormNumber(val)
		 {
		    var invalidChars = "\{\}\/\'\:\)\(\,\=\+\_\~\`\!\@\#\$\%\^\&\*\;\>\<\.\]\[";
		    var objRegExp  =/(^\d{1,5}\-\d{1,4}\-\d{1,4}-\d{1,7})/;
		    var flag=true;
			for (l=0; l < invalidChars.length; l++)
			{
				if(val.indexOf(invalidChars.charAt(l)) > -1)
				{					
					flag=false;
					break;					
				}
			}	
			if(flag)
			{			    
		        if(objRegExp.test(val))
		        {
		            return true;
		        }
		        else
		        {
		            alert("Please check the Eligibility Form Number.eg(179-121-2000-194)");
		            return objRegExp.test(val);
		        }
			}	
			else
			{
			    alert("Please check the Eligibility Form Number.eg(179-121-2000-194)");
			    return false;			    
			}			
		
		 }//end function

		