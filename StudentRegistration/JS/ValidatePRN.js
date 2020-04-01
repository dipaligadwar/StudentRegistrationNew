//function to validate PRN using parity check.
//prn is the value passed to be checked.
		function checkdigitPRN(prn)
		{	
			
		   var PRNlen =16;//defined length of PRN
		   var PRNregularexpression = "^([0-9]){16}$";
		   var regex = new RegExp(PRNregularexpression);
		   //if prn value is matched with the regular expression do parity check.
		   if(regex.exec(prn))
		   {
				var str =prn;
				var sum=0,rem=0;
				var len = str.length-2;
				for (var i=str.length; i>=2 ; i--)
					{
				   
						sum = sum + parseInt(str.charAt(len))*(16-len);
						len= len-1;
					         
					}
					// alert("sum is "+ sum);
					rem= 7-(sum % 7);
					// alert("remainder is "+ rem);
					if(rem==str.charAt(str.length-1))
					{
						//alert("Valid PRN");
						return true;
					}
					else
					{
						alert("Corrupted or Invalid PRN.Please Check.");
						return false; 
					}
		     }//end if prn.length
		     
		     else
		     {
				alert("PRN is a "+PRNlen+" digit number.Please enter a valid PRN.")
				return false;
		     }
		
		}//end function