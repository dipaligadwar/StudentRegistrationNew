/*
----------------------------------------------------------
Author  	    	:Khalique Manyar (m_khalique@hotmail.com)
Module          	:SCM
Description     	:Generic javascript validation file 
Date of Written 	:01/07/2003
Date of Last Modified : 26/08/2003
History :
		24/12/2003 : Rajesh Purohit : GUI change for Displaying Messages
----------------------------------------------------------*/
var finMesg="Please correct following errors...\n";
var finCount=0
var finGotErr="N"
function validateMe(Arr, DialogHeight)
{
	/*var count=0;
	var message="Please correct following errors...\n";
	var gotErr="N";*/
	
	var count=finCount;
	var message=finMesg;
	var gotErr=finGotErr;
	
	var passcount=0;
	var PassArray = new Array(2);
	
	for (k = 0; k < Arr.length; k++)
	{
		var myElement=Arr[k][0];
		var whatToDo=Arr[k][1];
		var myMessage=Arr[k][2];
		var elementType=Arr[k][3];
		if(elementType=="CompareDates")
		{
			var myElement1;
			var DateOne;
			var DateTwo;
			myElement1 = myElement.split("|");
			//DateOne = eval(myElement1[0]).value ;
			//DateTwo = eval(myElement1[1]).value ;
			DateOne = myElement1[0];
			DateTwo = myElement1[1];
			if((DateOne.length) !=0 && (DateTwo.length) !=0)
			{
				//---- added on 15-01-2005 by Ajay	
				var sysdateArr=new Array(3);  // making arr
				sysdateArr = DateOne.split("/");
				var sysdateYY=sysdateArr[2];
						
				if (sysdateYY.length == 4 && Math.abs(sysdateYY) <= 1800)
				{
					message = message + (++count) + ". " + "Year of the date should be greater than 1800" + "\n";
					gotErr="Y";
				}
				else
				{
					sysdateArr = DateTwo.split("/");
					var sysdateYY=sysdateArr[2];
							
					if (sysdateYY.length == 4 && Math.abs(sysdateYY) <= 1800)
					{
						message = message + (++count) + ". " + "Year of the date should be greater than 1800" + "\n";
						gotErr="Y";
					}
					else
					{
					//-----
						if(!CompareDates(DateOne, DateTwo))
						{
							message = message + (++count) + ". " + myMessage + "\n";
							gotErr="Y";			
						}
					}
				}
			}			
		}
//--------------------------
//---- added on 09-Dec-2004 by Ajay (approved by khalique Sir)
		else if(elementType=="CompareValues") //Val One should be less than or equal to ValTwo
		{
			var myElement1;
			var ValOne;
			var ValTwo;
			myElement1 = myElement.split("|");
			ValOne = myElement1[0];
			ValTwo = myElement1[1];
			if((!isNaN(ValOne)) && (!isNaN(ValTwo)))
			{
				if(Math.abs(ValOne)>Math.abs(ValTwo))
				{
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";			
				}
			}			
		}
		else if(elementType=="GreaterThanOREqual") //Val One should be Greater than or equal to ValTwo
		{
			var myElement1;
			var ValOne;
			var ValTwo;
			myElement1 = myElement.split("|");
			ValOne = myElement1[0];
			ValTwo = myElement1[1];
			if((!isNaN(ValOne)) && (!isNaN(ValTwo)))
			{
				if(Math.abs(ValOne)<Math.abs(ValTwo))
				{
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";			
				}
			}			
		}
		else if(elementType=="CompareValuesWithNotAllowEqual") //Val One should be less than ValTwo
		{
			var myElement1;
			var ValOne;
			var ValTwo;
			myElement1 = myElement.split("|");
			ValOne = myElement1[0];
			ValTwo = myElement1[1];
			if((!isNaN(ValOne)) && (!isNaN(ValTwo)))
			{
				if(!(Math.abs(ValOne)<Math.abs(ValTwo)))
				{
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";			
				}
			}			
		}
		else if(elementType=="GreaterThan") //Val One should be Greater than ValTwo
		{
			var myElement1;
			var ValOne;
			var ValTwo;
			myElement1 = myElement.split("|");
			ValOne = myElement1[0];
			ValTwo = myElement1[1];
			if((!isNaN(ValOne)) && (!isNaN(ValTwo)))
			{
				if(!(Math.abs(ValOne)>Math.abs(ValTwo)))
				{
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";			
				}
			}			
		}
		else if(elementType=="EqualValues") //ValOne & ValTwo should be equal
		{
			var myElement1;
			var ValOne;
			var ValTwo;
			myElement1 = myElement.split("|");
			ValOne = myElement1[0];
			ValTwo = myElement1[1];
			if((!isNaN(ValOne)) && (!isNaN(ValTwo)))
			{
				if(Math.abs(ValOne)!=Math.abs(ValTwo))
				{
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";			
				}
			}			
		}
		else if(elementType=="file") 
		{
			if(Trim(myElement.value)!="")
			{
				if(!checkFile(myElement.value))
				{
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";			
				}
			}
		}
		
//--------------------------
		else if (elementType=="PrimaryKey")
		{
			var myElement1;
			myElement1 = myElement.split("|");
			
			for (z=0;z<myElement1.length;z++)
			{
				myValue = eval(myElement1[z]).value;
				if (myValue.length != 0)
				{
					var invalidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\{\}\/\'\:\)\(\,\=\+\_\~\`\!\@\#\$\%\^\&\*\;\>\<\.\]\[ ";
					for (l=0; l < invalidChars.length; l++)
					{
						if(myValue.indexOf(invalidChars.charAt(l)) > -1)
						{
							gotErr="Y";
							break;
						}
					}
					if (gotErr == "Y")
					{ 
						break;
					}
				}
				else
				{
					gotErr="Y";		
					break;
				}	

			} //end for
			if (gotErr == "Y")
			{
				Arr[0][0] = eval(myElement1[0]);
				message = message + (++count) + ". " + myMessage + "\n";	
			}
		}
		else if(elementType=="date")
		{
			if(myElement.value.length !=0)
			{
				/*
				var invalidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\{\}\'\:\)\(\,\=\+\_\~\`\!\@\#\$\%\^\&\*\;\>\<\]\[ ";

				for (l=0; l < invalidChars.length; l++)
				{
					if(myElement.value.indexOf(invalidChars.charAt(l)) > -1)
					{
						message = message + (++count) + ". " + myMessage + "\n";
						gotErr="Y";
						break;
					}
				}	
				*/
				if(!checktxtDate(myElement,whatToDo))
				{
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";			
				}
			}
		}
		// How to use:
		// myArr[0]= new Array(document.frm.txtareaname,"maxlength(number)","Validation Text: can not be more than maxlength character","textarea");
		else if(elementType=="textarea") //Checks if maxlength of textarea 
		{
			var myLength=myElement.value.length;
			if(myLength > whatToDo )
			{
				message = message + (++count) + ". " + myMessage + "\n";
				gotErr="Y";				
			}
		}
		// How to use:
		// myArr[0]= new Array(document.frm.txtareaname,"maxlength(number)","Validation Text: can not be more than maxlength character or empty","textarea/Empty");
		else if(elementType=="textarea/Empty") //Checks if maxlength of textarea 
		{
			var myLength=myElement.value.length;
			if(myElement.value == "" || myElement.value.charAt(0)==" ")
			{	
				message = message + (++count) + ". " + myMessage + "\n";
				gotErr="Y";
			}
			else if(myLength > whatToDo )
			{
				message = message + (++count) + ". " + myMessage + "\n";
				gotErr="Y";				
			}
		}
		// end 
		else if(elementType=="date/Empty")
		{
			
			if(myElement.value == "" || myElement.value.charAt(0)==" ")
			{	
				message = message + (++count) + ". " + myMessage + "\n";
				gotErr="Y";
			}
			else if(!checktxtDate(myElement,whatToDo))
			{
				message = message + (++count) + ". " + myMessage + "\n";
				gotErr="Y";			
			}
		}
		else if(elementType=="password")
		{
			PassArray[passcount]=myElement.value;							
			if(passcount==1 && !checkPassword(PassArray))
			{
				message = message + (++count) + ". " + myMessage + "\n";
				gotErr="Y";	
			}
			++passcount;
		}
		else if(elementType=="text") //Validations if form element type is text box
		{
			var myValue=myElement.value;
			var myLength=myValue.length;
			
			if(whatToDo=="Alpha")
			{
				var invalidchars="0123456789";
				for(x=0;x<invalidchars.length;x++)
				{
					if(myValue.indexOf(invalidchars.charAt(x))>-1)
					{
						message = message + (++count) + ". " + myMessage + "\n";
						gotErr="Y";		
					}				
				}
			}
			if(whatToDo=="Time/Empty")
			{
				if(myValue == "" || myValue.charAt(0)==" ")
				{ 
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";
				}
				else 
				{
					if(!IsValidTime(myValue))
					{
						message = message + (++count) + ". " + myMessage + "\n";
						gotErr="Y";			
					}
				}
			}
			if(whatToDo=="NoGreaterDate/Empty")
			{
				
				if(myValue == "" || myValue.charAt(0)==" ")
				{ 
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";
					
				}
				else 
				{
					//---- added on 15-01-2005 by Ajay	
					
					var sysdateArr=new Array();  // making arr
					sysdateArr = myValue.split("/");
					if(sysdateArr.length==3)
					{
						var sysdateYY=sysdateArr[2];
								
						if (sysdateYY.length == 4 && Math.abs(sysdateYY) <= 1800)
						{
							message = message + (++count) + ". " + "Year of the date should be greater than 1800" + "\n";
							gotErr="Y";
						}
						else
						{
						//-----		
									
							if(!notGreterThanToday(myValue))
							{
								message = message + (++count) + ". " + myMessage + "\n";
								gotErr="Y";			
							}
						}
					}
				}
			}
			if(whatToDo=="NoGreaterDate")
			{
				
					//---- added on 15-01-2005 by Ajay	
					var sysdateArr=new Array();  // making arr
					
					sysdateArr = myValue.split("/");
					if(sysdateArr.length==3)
					{
						var sysdateYY=sysdateArr[2];
								
						if (sysdateYY.length == 4 && Math.abs(sysdateYY) <= 1800)
						{
							message = message + (++count) + ". " + "Year of the date should be greater than 1800" + "\n";
							gotErr="Y";
						}
						else
						{
						//-----	
							if(!notGreterThanToday(myValue))
							{
								message = message + (++count) + ". " + myMessage + "\n";
								gotErr="Y";			
							}
						}
					}
				
			}
			if(whatToDo=="NoSmallerDate/Empty")
			{
				
				if(myValue == "" || myValue.charAt(0)==" ")
				{ 
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";
					
				}
				else 
				{
					if(!notSmallerThanToday(myValue))
					{
						message = message + (++count) + ". " + myMessage + "\n";
						gotErr="Y";			
					}
				}
			}

			if(whatToDo=="Alpha")
			{
				var invalidchars="0123456789";
				for(x=0;x<invalidchars.length;x++)
				{
					if(myValue.indexOf(invalidchars.charAt(x))>-1)
					{
						message = message + (++count) + ". " + myMessage + "\n";
						gotErr="Y";		
					}				
				}
			}

			if(whatToDo=="Alpha/Empty")
			{
				if(myValue == "" || myValue.charAt(0)==" ")
				{ 
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";
				}
				else 
				{
					var invalidchars="0123456789";
					for(x=0;x<invalidchars.length;x++)
					{
						if(myValue.indexOf(invalidchars.charAt(x))>-1)
						{
							message = message + (++count) + ". " + myMessage + "\n";
							gotErr="Y";	
							break;	
						}				
					}
				}
			}

			if(whatToDo=="URL")
			{
				if(myLength!=0)
				{
					var substr=myValue.substring(0,4);
					var myPos=myValue.indexOf("..");
					var myLastPos=myValue.lastIndexOf(".");
					if(substr!="www." || myPos>1 || myLastPos >=myLength-1)
					{
						message = message + (++count) + ". " + myMessage + "\n";
						gotErr="Y";		
					}
				}			        
			}

			if(whatToDo == "Empty") // validates to disallow empty input
			{
				if(myValue == "" || myValue.charAt(0)==" " || myValue.length == 0)
				{ 
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";
				}
			}
	
			if(whatToDo == "NumericOnly") // validates to disallow characters
			{
/*				if(isNaN(myValue))
				{ 
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";
				}
*/
				var invalidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\{\}\/\'\:\)\(\,\-\=\+\_\~\`\!\@\#\$\%\^\&\*\;\>\<\]\[ ";

				for (l=0; l < invalidChars.length; l++)
				{
					if(myValue.indexOf(invalidChars.charAt(l)) > -1)
					{
						message = message + (++count) + ". " + myMessage + "\n";	
						gotErr="Y";
						break;
					}
				}	

			}

			if(whatToDo == "NumericOnly/Empty") // validates to disallow characters
			{									// as well as empty
				if (myValue.length != 0)
				{
					var invalidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\{\}\/\'\:\)\(\,\=\+\_\~\`\!\@\#\$\%\^\&\*\;\>\<\.\]\[ ";
					for (l=0; l < invalidChars.length; l++)
					{
						if(myValue.indexOf(invalidChars.charAt(l)) > -1)
						{
							message = message + (++count) + ". " + myMessage + "\n";	
							gotErr="Y";
							break;
						}
					}
				}
				else
				{
					message = message + (++count) + ". " + myMessage + "\n";	
					gotErr="Y";		
				}	
			}
//--------------------------
//---- added on 09-Dec-2004 by Ajay (approved by khalique Sir)
			if(whatToDo == "IntegerOnly") // validates to disallow characters
			{
				if (myValue.length != 0)
				{
					var invalidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\{\}\/\'\:\)\(\,\-\=\+\_\~\`\!\@\#\$\%\^\&\*\;\>\<\]\[\. ";
					for (l=0; l < invalidChars.length; l++)
					{
						if(myValue.indexOf(invalidChars.charAt(l)) > -1)
						{
							message = message + (++count) + ". " + myMessage + "\n";	
							gotErr="Y";
							break;
						}
					}
				}	

			}
			if(whatToDo == "IntegerOnly/Empty") // validates to disallow characters
			{									// as well as empty
				if (myValue.length != 0)
				{
					var invalidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\{\}\/\'\:\)\(\,\-\=\+\_\~\`\!\@\#\$\%\^\&\*\;\>\<\]\[\. ";
					for (l=0; l < invalidChars.length; l++)
					{
						if(myValue.indexOf(invalidChars.charAt(l)) > -1)
						{
							message = message + (++count) + ". " + myMessage + "\n";	
							gotErr="Y";
							break;
						}
					}
				}
				else
				{
					message = message + (++count) + ". " + myMessage + "\n";	
					gotErr="Y";		
				}	
			}
//--------------------------
	
			if(whatToDo == "Email")
			{
				if (myValue.length != 0)
				{
					if(!isvalidEmail(myValue))
					{
						message = message + (++count) + ". " + myMessage + "\n";
						gotErr="Y";
					}
				}
				//else
				//{
				//	message = message + (++count) + ". " + myMessage + "\n";
				//	gotErr="Y";
				//}
			}

			if(whatToDo == "Currency")
			{
				if (myValue.length != 0)
				{
					myValue=Math.round(parseFloat(myValue)*100);
					myValue=myValue/100;
					
					if(!isvalidCurrency(myValue))
					{
						message = message + (++count) + ". " + myMessage + "\n";
						gotErr="Y";
					}
				}
				//else
				//{
				//	message = message + (++count) + ". " + myMessage + "\n";
				//	gotErr="Y";
				//}
			}
//--------------------------
//---- added on 09-Dec-2004 by Ajay (approved by khalique Sir)
			if(whatToDo == "Currency/Empty")// validates to disallow characters
			{								// as well as empty
				if (myValue.length != 0)
				{
					myValue=Math.round(parseFloat(myValue)*100);
					myValue=myValue/100;
					
					if(!isvalidCurrency(myValue))
					{
						message = message + (++count) + ". " + myMessage + "\n";
						gotErr="Y";
					}
				}
				else
				{
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";
				}
			}
//--------------------------
			if(whatToDo == "Time")
			{
				if (myValue.length != 0)
				{
					if(!IsValidTime(myValue))
					{
						message = message + (++count) + ". " + myMessage + "\n";
						gotErr="Y";
					}
				}
				//else
				//{
				//	message = message + (++count) + ". " + myMessage + "\n";
				//	gotErr="Y";
				//}
			}
			if(whatToDo == "NoSpace") // validates to disallow spaces in between
			{						  // input by the user
				if(myValue == "")
				{
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";
				}	
				else
				{
					for(j=0; j < myLength; j++)
					{
						if(myValue.charAt(j) == " ")	
						{
							message = message + (++count) + ". " + myMessage + "\n";
							gotErr="Y";
						}
					}
				}		
			}
	
			if(whatToDo == "AlphaNumeric")
			{
				var invalidChars = "\{\}\/\'\:\)\(\,\-\=\+\_\~\`\!\@\#\$\%\^\&\*\;\>\<\.\]\[";
				for (l=0; l < invalidChars.length; l++)
				{
					if(myValue.indexOf(invalidChars.charAt(l)) > -1)
					{
						message = message + (++count) + ". " + myMessage + "\n";	
						gotErr="Y";
						break;
					}
				}			
			}

			if(whatToDo == "AlphaNumeric/Empty") // validates to disallow extra characters 
			{							   // other than 0-9 and a-z	
				if(myValue == "" || myValue.charAt(0)==" ")
				{
					message = message + (++count) + ". " + myMessage + "\n";
					gotErr="Y";		
				}
				else
				{
					var invalidChars = "\{\}\/\'\:\)\(\,\-\=\+\_\~\`\!\@\#\$\%\^\&\*\;\>\<\.\]\[";
					for (l=0; l < invalidChars.length; l++)
					{
						if(myValue.indexOf(invalidChars.charAt(l)) > -1)
						{
							message = message + (++count) + ". " + myMessage + "\n";	
							gotErr="Y";
							break;
						}
					}
				}	
			}
		}
		else if (elementType="select") //Validations if form element type is List box
		{
			if(!checkSelectBox(myElement,whatToDo))	
			{
				message = message + (++count) + ". " + myMessage + "\n";
				gotErr="Y";
			}			
		}		
	}
	
	if(gotErr == "Y")
	{
		//SystemAlert(alertpath,'dvuCritical',message,0,DialogHeight,'dvuOKOnly',"", true)
		alert(message);
		//Arr[0][0].focus();
		return false;
	}
	return true;
}
//Milindkumar Kolte
// Function for the sDate must be smaller than todayes Date
function notGreterThanToday(sDate)
{
			var today=new Date()  // todayes date
			var toyy= today.getFullYear()  // year YYYY
			var tomm=(today.getMonth())+1 // Month
			var todayday=today.getDate() 
			
			var sysdate= sDate
			var sysdateArr=new Array(3);  // making arr
			sysdateArr = sysdate.split("/");
			var sysdateYY=sysdateArr[2];
			var sysdateMM=sysdateArr[1];
			var sysdateDay=sysdateArr[0];
			
			if (sysdateYY==toyy)
			{
				if(sysdateMM>tomm)
				{
					return false;
				}
				else if(sysdateMM==tomm)
				{
				   if(sysdateDay>todayday)
				   {
						return false;
				   }
				}
			}
			else if(sysdateYY>toyy)
			{
					return false;
			}
		return true;
}		
function notSmallerThanToday(sDate)
{
			var today=new Date()  // todayes date
			var toyy= today.getFullYear()  // year YYYY
			var tomm=(today.getMonth())+1 // Month
			var todayday=today.getDate()
			 
			var sysdate= sDate
			var sysdateArr=new Array(3);  // making arr
			sysdateArr = sysdate.split("/");
			var sysdateYY=sysdateArr[2];
			var sysdateMM=sysdateArr[1];
			var sysdateDay=sysdateArr[0];
			if (sysdateYY==toyy)
			{
				if(sysdateMM<tomm)
				{
					return false;
				}
				else if(sysdateMM==tomm)
				{
				   if(sysdateDay<todayday)
				   {
						return false;
				   }
				}
			}
			else if(sysdateYY<toyy)
			{
					return false;
			}
		return true;
}		

// ***************End of function*************************
// Milindkumar Kolte
//	Fuction work for taking two date input and compairing the sDateTwo 
// DateTwo must be greater or equal to DateOne
function CompareDates(sDateOne, sDateTwo) // Date 1 And Date two Must be in dd/mm/yyyy Formate
{			
			var fixArr=new Array(3);
			fixArr= sDateOne.split("/");
			var toyy= fixArr[2]; //Year
			var tomm=fixArr[1]; // Month
			var today=fixArr[0]; //Date
			
			var sysdate= sDateTwo
			var sysdateArr=new Array(3);  // making arr
			sysdateArr = sysdate.split("/");
			var sysdateYY=sysdateArr[2];
			var sysdateMM=sysdateArr[1];
			var sysdateDay=sysdateArr[0];
			
			if (sysdateYY==toyy)
			{
				if(sysdateMM<tomm)
				{
					return false;    //if sDateTwo Month is greater than FixDate Month then return false..
				}
				else if(sysdateMM==tomm)
				{
					
				   if(sysdateDay<today)  // IF Date(Moynh (day) is greater then return false
				   {
						return false;
				   }
				}
			}
			else if(sysdateYY<toyy) /// IF year is greater then return the false
			{		
					return false;
			}
   return true;
	}	
//**************************** End    Of Function******************************/	
function isvalidEmail(email) // function to validate email address
{			
	invalidchrs	 = ";:/, ";
	for (i=0; i<invalidchrs.length; i++) 
		if (email.indexOf(invalidchrs.charAt(i)) > -1) 
			return false; 	// there is some invalid characters

	atpos= email.indexOf("@",0);
	if (atpos <1 || email.indexOf("..", atpos)!=-1) 
	        return false; 	// "@" symbol is must, 
							// should not be a first chr 
							// email should not contain ".." continously

	if (email.indexOf("@",atpos+1) != -1) 
	        return false;	// should be only one '@' symbol

	dotpos = email.indexOf(".",atpos);
	if (dotpos == -1) 		        
	        return false;	// at least one "." after the "@"

	if(dotpos-atpos==1)
		return false;		// atlease a chr between '@' and '.' 

	do
	{
		if (dotpos+3 > email.length) 
	        return false; 	// at least 2 chrs after "." is must
	}while((dotpos=email.indexOf(".",dotpos+2))!=-1); // seek next '.'

	return true;
}

/*function isvalidCurrency(Currency) // function to validate currency
{			
	invalidchrs	 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\{\}\/\'\:\)\(\,\=\+\-\_\~\`\!\@\#\$\%\^\&\*\;\>\<\]\[ ";
	for (i=0; i<invalidchrs.length; i++) 
		if (Currency.indexOf(invalidchrs.charAt(i)) > -1) 
			return false; 	// there is some invalid characters

	atpos= Currency.indexOf(".",0);
	if (atpos <1 || Currency.indexOf("..", atpos)!=-1) 
	        return false; 	
	if (Currency.indexOf(".",atpos+1) != -1) 
	        return false;	
	dotpos = Currency.indexOf(".",atpos);
	if(dotpos != -1)
	{
		if (dotpos+2 < Currency.length-1) 
	        return false; 	
	}

	return true;
}*/
function isvalidCurrency(Currency) // function to validate currency
{			
	//Added By Ajay on 16-Feb-2005
	//--Start
	Currency=Math.round(parseFloat(Currency)*100);
	Currency=Currency/100;
	if(Currency=="0")
	{
		return false;
	}
		
	Currency=Currency.toString();
	//--End
	
	invalidchrs	 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\{\}\/\'\:\)\(\,\=\+\-\_\~\`\!\@\#\$\%\^\&\*\;\>\<\]\[ ";
	for (i=0; i<invalidchrs.length; i++) 
		if (Currency.indexOf(invalidchrs.charAt(i)) > -1) 
			return false; 	// there is some invalid characters

	atpos= Currency.indexOf(".",0);
	//if (atpos <1 || Currency.indexOf("..", atpos)!=-1) 
	if (atpos ==0 || Currency.indexOf("..", atpos)!=-1) 
	        return false; 
	        
	if (Currency.indexOf(".",atpos+1) != -1) 
	        return false;	
	dotpos = Currency.indexOf(".",atpos);
	if(dotpos != -1)
	{
		if (dotpos+2 < Currency.length-1) 
	        return false; 	
	}
	return true;
}

function checkSelectBox(boxName,valueToCheck) // function to validate list box
{
	var idx=boxName.selectedIndex;
	var val=boxName[idx].value;
	if (val == valueToCheck) return false;
	else return true;
}

function checkPassword(elements) // function to check password with confirm password
{
	if(elements[0]==elements[1]) return true;
	else return false;	
}
/******* Function to check Time ***********/
function IsValidTime(timeStr) {
// Checks if time is in HH:MM:SS AM/PM format.
// The seconds and AM/PM are optional.

//	var timePat = /^(\d{1,2}):(\d{2})(:(\d{2}))?$/;
	var timePat = /^(\d{1,2}):(\d{2})(:(\d{2}))?(\s?(AM|am|PM|pm))?$/;
	var matchArray = timeStr.match(timePat);
	
	if (matchArray == null) 
	{
		return false;
	}
	hour = matchArray[1];
	minute = matchArray[2];
	second = matchArray[4];
	ampm = matchArray[6];
	
	if (second=="") 
	{ 
		second = null; 
	}
	if (ampm=="") 
	{ 
		ampm = null;
	}
	
	if (hour < 0  || hour > 23) 
	{
		return false;
	}
	if (hour <= 12 && ampm == null) 
	{
		return false;
	}
	if  (hour > 12 && ampm != null) 
	{
		return false;
	}
	if (minute<0 || minute > 59) 
	{
		return false;
	}
	if (second != null && (second < 0 || second > 59)) 
	{
		return false;
	}
		return true;
}
//  End -->
/******FUNCTION TO CHECK DATE*********/

function checkDate(datearr) //to validate the date
{
	for (a = 0; a < datearr.length; a++)
	{
		var myday=datearr[a][0];
		var mymonth=datearr[a][1];
		var myyear=datearr[a][2];

		var i=myday.selectedIndex;
		var intday=myday[i].value;
		
		var j=mymonth.selectedIndex;
		var intMonth=mymonth[j].value;
	
		var k=myyear.selectedIndex;
		var intyear=myyear[k].value;
		
//---- added on 15-01-2005 by Ajay			
			if (intyear.length == 4 && Math.abs(intyear) <= 1800)
			{
				return false;
			}
//-----		

		if(intday !=0 || intMonth !=0 || eval(intyear)!=0)
		{
			if(intday > 31 || intMonth > 12 || intday < 1 || intMonth < 1 || intyear < 1)
			{
				alert("invalid date");
				return false;
			}
			else if ((intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7 || intMonth == 8 || intMonth == 10 || intMonth == 12) && (intday > 31)) 
			{
					alert("invalid day according to month");	
					return false;		
			}
			else if ((intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11) && (intday > 30)) 
			{
				alert("invalid day according to month");		
				return false;		
			}
			else if(intMonth == 2)
			{
				if(LeapYear(intyear)==true)
				{
					if(intday>29)
					{
						alert("invalid day");
						return false;
					}
				}
				else
				{
					if(intday>28)
					{
						alert("invalid day");
						return false;
					}		
				}
			}
		}		
	}
	return true;
}

function LeapYear(intyear) // to check if it is leap year or not
{
	if (intyear % 100 == 0) 
	{
		if (intyear % 400 == 0) { return true; }
	}
	else 
	{
		if ((intyear % 4) == 0) { return true; }
	}
	return false;
}

function checktxtDate(myDate,pattern) //to validate the date from text field
{
		var monthArr= new Array(13);
		monthArr[0]=" ";
		monthArr[1]="JAN";
		monthArr[2]="FEB";
		monthArr[3]="MAR";
		monthArr[4]="APR";
		monthArr[5]="MAY";
		monthArr[6]="JUN";
		monthArr[7]="JUL";
		monthArr[8]="AUG";
		monthArr[9]="SEP";
		monthArr[10]="OCT";
		monthArr[11]="NOV";
		monthArr[12]="DEC";
		var validSeparators = new Array("-"," ","/",".");
		var patternArr  = "notMatching";
		//alert();
		for(vs=0;vs<validSeparators.length;vs++)
		{
			if(myDate.value.indexOf(validSeparators[vs])!=-1)
			{
				patternArr=myDate.value.split(validSeparators[vs]);
				break;
			}	
		}
		if(patternArr=="notMatching" || patternArr.length !=3)
		{
			return false;
		}
		else if(pattern=="dd/mm/yy" || pattern=="dd/mm/yyyy" || pattern=="dd-mm-yyyy" || pattern=="dd-mm-yy" || pattern=="dd.mm.yy" || pattern=="dd.mm.yyyy")
		{
			intday=patternArr[0];
			intMonth=patternArr[1];
			intyear=patternArr[2];

//---- added on 26-08-2003 by khalique			
			if (intyear.length == 3 || intyear.length == 1)
			{
				return false;
			}
//-----

//---- added on 15-01-2005 by Ajay			
			if (intyear.length == 4 && Math.abs(intyear) <= 1800)
			{
				return false;
			}
			if (intyear.length != 4 && pattern=="dd/mm/yyyy")
			{
				return false;
			}
//-----			
			if(isNaN(intMonth))
			{
				var isMonthFound = false;
				for(month=1;month<monthArr.length;month++)				
				{
					if(monthArr[month]==intMonth.toUpperCase())
					{
						intMonth=month;
						isMonthFound=true;
						break;
					}	
				}
				if (!isMonthFound)
				{
					return false;
				}
			}
		}
		else if(pattern=="mm/dd/yy" || pattern=="mm/dd/yyyy" || pattern=="mm-dd-yy" || pattern=="mm-dd-yyyy" || pattern=="mm.dd.yy" || pattern=="mm.dd.yyyy")
		{
			intday=patternArr[1];
			intMonth=patternArr[0];
			intyear=patternArr[2];
			if(isNaN(intMonth))
			{
				for(month=1;month<monthArr.length;month++)				
				{
					if(monthArr[month]==intMonth.toUpperCase())
					{
						intMonth=month;
						break;
					}	
				}
			}
		}
		else if(pattern=="yy/mm/dd" || pattern=="yyyy/mm/dd" || pattern=="yy-mm-dd" || pattern=="yyyy-mm-dd" || pattern=="yy.mm.dd" || pattern=="yyyy.mm.dd")
		{
			intday=patternArr[2];
			intMonth=patternArr[1];
			intyear=patternArr[0];
			if(isNaN(intMonth))
			{
				for(month=1;month<monthArr.length;month++)				
				{
					if(monthArr[month]==intMonth.toUpperCase())
					{
						intMonth=month;
						break;
					}	
				}
			}
		}
//--------------------------
//---- added on 06-Mar-2004 by Zubair (approved by khalique Sir)
//checking whether day and year part are valid integer or not
		if(isNaN(intday) || isNaN(intyear))
		{
			return false;
		}
//--------------------------
		
		if(eval(intday) !=0 || eval(intMonth) !=0 || eval(intyear)!=0)
		{
			if(intday > 31 || intMonth > 12 || intday < 1 || intMonth < 1 || intyear < 1)
			{
				return false;
			}
			else if ((intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7 || intMonth == 8 || intMonth == 10 || intMonth == 12) && (intday > 31)) 
			{
				return false;		
			}	
			else if ((intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11) && (intday > 30)) 
			{
				return false;		
			}
			else if(intMonth == 2)
			{
				if(LeapYear(intyear))
				{
					if(intday>29)
					{
						return false;
					}
				}
				else
				{
					if(intday>28)
					{
						return false;
					}		
				}
			}
		}
		else
		{
			return false;
		}		
	return true;
}

function IsValidTime(timeStr) 
{
	// Checks if time is in HH:MM:SS format.
	var timePat = /^(\d{1,2}):(\d{2})(:(\d{2}))?(\s?(AM|am|PM|pm))?$/;

	var matchArray = timeStr.match(timePat);
	if (matchArray == null)
	{
		//	alert("Time is not in a valid format.");
		return false;
	}

	hour = matchArray[1];
	minute = matchArray[2];
	second = matchArray[4];
	ampm = matchArray[6];

	if (second=="") { second = null; }
	if (ampm=="") { ampm = null }

	if (hour < 0  || hour > 12) {
	//	alert("Hour must be between 1 and 12.");
	return false;
	}
	
	if (minute<0 || minute > 59) {
	//	alert ("Minute must be between 0 and 59.");
	return false;
	}
	
	if (second != null && (second < 0 || second > 59)) {
	//	alert ("Second must be between 0 and 59.");
	return false;
	}
	if (hour <= 12 && ampm == null)
	{
		return false;
  	}
return true;

}

/*Function To Calculate Age from Date of Birth */
function getAge(dateString,dateType) {
/*
   function getAge
   parameters: dateString dateType
   returns: boolean

   dateString is a date passed as a string in the following
   formats:

   type 1 : 19970529
   type 2 : 970529
   type 3 : 29/05/1997
   type 4 : 29/05/97

   dateType is a numeric integer from 1 to 4, representing
   the type of dateString passed, as defined above.

   Returns string containing the age in years, months and days
   in the format yyy years mm months dd days.
   Returns empty string if dateType is not one of the expected
   values.
*/

    var now = new Date();
    var today = new Date(now.getYear(),now.getMonth(),now.getDate());

    var yearNow = now.getYear();
    var monthNow = now.getMonth();
    var dateNow = now.getDate();
	//alert(dateType);
    if (dateType == 1)
        var dob = new Date(dateString.substring(0,4),
                            dateString.substring(4,6)-1,
                            dateString.substring(6,8));
    else if (dateType == 2)
        var dob = new Date(dateString.substring(0,2),
                            dateString.substring(2,4)-1,
                            dateString.substring(4,6));
    else if (dateType == 3)
	    var dob = new Date(dateString.substring(6,10),
                            dateString.substring(3,5)-1,
                            dateString.substring(0,2));
    else if (dateType == 4)
        var dob = new Date(dateString.substring(6,8),
                            dateString.substring(3,5)-1,
                            dateString.substring(0,2));
    else
        return '';

    var yearDob = dob.getYear();
	yearDob = yearDob.toString();
	if(yearDob.length == 2)
	{
		yearDob = "19" + yearDob;
	}
	//---- added on 15-01-2005 by Ajay			
	if (yearDob.length == 4 && Math.abs(yearDob) <= 1800)
	{
		return '';
	}
	//-----		

	var monthDob = dob.getMonth();
    var dateDob = dob.getDate();
	
    yearAge = yearNow - yearDob;
    if (monthNow >= monthDob)
        var monthAge = monthNow - monthDob;
    else {
        yearAge--;
        var monthAge = 12 + monthNow -monthDob;
    }

    if (dateNow >= dateDob)
        var dateAge = dateNow - dateDob;
    else {
        monthAge--;
        var dateAge = 31 + dateNow - dateDob;

        if (monthAge < 0) {
            monthAge = 11;
            yearAge--; 
        }
    }

//    return yearAge + ' years ' + monthAge + ' months ' + dateAge + ' days';
    return yearAge + '.' + monthAge;
}
//--------------------------
//---- added on 09-Dec-2004 by Ajay (approved by khalique Sir)
		function Trim(s)//Triming of String 
		{
			if(s!="")
			{
				// Remove leading spaces and carriage returns
				while ((s.substring(0,1) == ' ') || (s.substring(0,1) == '\n') || (s.substring(0,1) == '\r'))
				{
					s = s.substring(1,s.length);
				}
				// Remove trailing spaces and carriage returns
				while ((s.substring(s.length-1,s.length) == ' ') || (s.substring(s.length-1,s.length) == '\n') || (s.substring(s.length-1,s.length) == '\r'))
				{
					s = s.substring(0,s.length-1);
				}
			}
			return s;
		}
			
		function checkFile(fileName)//Check file with specific extentions (eg. '.jpg','.gif','.bmp') 
		{
				var ext = fileName;
				ext = ext.substring(ext.length-3,ext.length);
				ext = ext.toLowerCase();
				if(ext == 'jpg' || ext == 'gif' || ext == 'bmp') 
				{
					return true; 
				}
		}	
//--------------------------
//--Admin Module Functions-----
//--Added on 10-Feb-2005 by Prashant Bhogle--
function checkDateFormat(myDate,pattern) //to validate the date from text field
{
		var monthArr= new Array(13);
		monthArr[0]=" ";
		monthArr[1]="JAN";
		monthArr[2]="FEB";
		monthArr[3]="MAR";
		monthArr[4]="APR";
		monthArr[5]="MAY";
		monthArr[6]="JUN";
		monthArr[7]="JUL";
		monthArr[8]="AUG";
		monthArr[9]="SEP";
		monthArr[10]="OCT";
		monthArr[11]="NOV";
		monthArr[12]="DEC";
		var validSeparators = new Array("-"," ","/",".");
		var patternArr  = "notMatching";
		for(vs=0;vs<validSeparators.length;vs++)
		{
			if(myDate.value.indexOf(validSeparators[vs])!=-1)
			{
				patternArr=myDate.value.split(validSeparators[vs]);
				break;
			}	
		}
		if(patternArr=="notMatching" || patternArr.length !=3)
		{
			return false;
		}
//		else if(pattern=="dd/mm/yy" || pattern=="dd/mm/yyyy" || pattern=="dd-mm-yyyy" || pattern=="dd-mm-yy" || pattern=="dd.mm.yy" || pattern=="dd.mm.yyyy")
		else if( pattern=="dd/mm/yyyy" || pattern=="dd-mm-yyyy" || pattern=="dd.mm.yyyy")
		{
			intday=patternArr[0];
			intMonth=patternArr[1];
			intyear=patternArr[2];

//---- added on 26-08-2003 by khalique			
			if (intyear.length == 3 || intyear.length == 1 || intyear.length == 2)
			{
				return false;
			}
//-----
			if(intyear<1800)
			{
				return false;
			}
			
			if(isNaN(intMonth))
			{
				var isMonthFound = false;
				for(month=1;month<monthArr.length;month++)				
				{
					if(monthArr[month]==intMonth.toUpperCase())
					{
						intMonth=month;
						isMonthFound=true;
						break;
					}	
				}
				if (!isMonthFound)
				{
					return false;
				}
			}
		}
//		else if(pattern=="mm/dd/yy" || pattern=="mm/dd/yyyy" || pattern=="mm-dd-yy" || pattern=="mm-dd-yyyy" || pattern=="mm.dd.yy" || pattern=="mm.dd.yyyy")
		else if(pattern=="mm/dd/yyyy" || pattern=="mm-dd-yyyy"|| pattern=="mm.dd.yyyy")
		{
			intday=patternArr[1];
			intMonth=patternArr[0];
			intyear=patternArr[2];
			if(isNaN(intMonth))
			{
				for(month=1;month<monthArr.length;month++)				
				{
					if(monthArr[month]==intMonth.toUpperCase())
					{
						intMonth=month;
						break;
					}	
				}
			}
		}
//		else if(pattern=="yy/mm/dd" || pattern=="yyyy/mm/dd" || pattern=="yy-mm-dd" || pattern=="yyyy-mm-dd" || pattern=="yy.mm.dd" || pattern=="yyyy.mm.dd")
		else if(pattern=="yyyy/mm/dd" || pattern=="yyyy-mm-dd" ||  pattern=="yyyy.mm.dd")
		{
			intday=patternArr[2];
			intMonth=patternArr[1];
			intyear=patternArr[0];
			if(isNaN(intMonth))
			{
				for(month=1;month<monthArr.length;month++)				
				{
					if(monthArr[month]==intMonth.toUpperCase())
					{
						intMonth=month;
						break;
					}	
				}
			}
		}
//--------------------------
//---- added on 06-Mar-2004 by Zubair (approved by khalique Sir)
//checking whether day and year part are valid integer or not
		if(isNaN(intday) || isNaN(intyear))
		{
			return false;
		}
//--------------------------
		
		if(eval(intday) !=0 || eval(intMonth) !=0 || eval(intyear)!=0)
		{
			if(intday > 31 || intMonth > 12 || intday < 1 || intMonth < 1 || intyear < 1)
			{
				return false;
			}
			else if ((intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7 || intMonth == 8 || intMonth == 10 || intMonth == 12) && (intday > 31)) 
			{
				return false;		
			}	
			else if ((intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11) && (intday > 30)) 
			{
				return false;		
			}
			else if(intMonth == 2)
			{
				if(LeapYear(intyear))
				{
					if(intday>29)
					{
						return false;
					}
				}
				else
				{
					if(intday>28)
					{
						return false;
					}		
				}
			}
		}
		else
		{
			return false;
		}		
	return true;
}




function ValidTime(timeStr) 
{
	// Checks if time is in HH:MM:SS format.
	var timePat = /^(\d{1,2}):(\d{2})(:(\d{2}))?(\s?(AM|am|PM|pm))?$/;

	var matchArray = timeStr.match(timePat);
	if (matchArray == null)
	{
		//	alert("Time is not in a valid format.");
		return false;
	}

	hour = matchArray[1];
	minute = matchArray[2];
	second = matchArray[4];
	ampm = matchArray[6];

	if (second=="") { second = null; }
	if (ampm=="") { ampm = null }

	if (hour < 0  || hour > 12) {
	//	alert("Hour must be between 1 and 12.");
	return false;
	}
	
	if (minute<0 || minute > 59) {
	//	alert ("Minute must be between 0 and 59.");
	return false;
	}
	
	if (second != null && (second < 0 || second > 59)) {
	//	alert ("Second must be between 0 and 59.");
	return false;
	}
	if (hour <= 12 && ampm == null)
	{
		return false;
  	}
return true;

}


function CompareUserDates(sDateOne, sDateTwo) // Date 1 And Date two Must be in dd/mm/yyyy Formate
{			
			var fixArr=new Array(3);
			fixArr= sDateOne.split("/");
			var toyy= fixArr[2]; //Year
			var tomm=fixArr[1]; // Month
			var today=fixArr[0]; //Date
		
			var sysdate= sDateTwo
			var sysdateArr=new Array(3);  // making arr
			sysdateArr = sysdate.split("/");
			var sysdateYY=sysdateArr[2];
			var sysdateMM=sysdateArr[1];
			var sysdateDay=sysdateArr[0];

			if (sysdateYY==toyy)
			{
				if(sysdateMM<tomm)
				{
					return false;    //if sDateTwo Month is greater than FixDate Month then return false..
				}
				else if(sysdateMM==tomm)
				{
					
				   if(sysdateDay<today)  // IF Date(Moynh (day) is greater then return false
				   {
						return false;
				   }
				}
			}
			else if(sysdateYY<toyy) /// IF year is greater then return the false
			{		
					return false;
			}
   return true;
	}		
	
	////////
	//end  validation function for Admin module
	///////////
	
//--------------------------