	var NoOffFirstLineMenus=9;			// Number of first level items
	var LowBgColor='#ffffff';			// Background color when mouse is not over
	var LowSubBgColor='#ffffff';			// Background color when mouse is not over on subs
	var HighBgColor='#eeeeee';			// Background color when mouse is over
	var HighSubBgColor='#eeeeee';			// Background color when mouse is over on subs
	var FontLowColor='#000000';			// Font color when mouse is not over
	var FontSubLowColor='#000000';			// Font color subs when mouse is not over
	var FontHighColor='#000000';			// Font color when mouse is over
	var FontSubHighColor='#000000';			// Font color subs when mouse is over
	var BorderColor='#027ADF';			// Border color
	var BorderSubColor='#027ADF';			// Border color for subs
	var BorderWidth=1;				// Border width
	var BorderBtwnElmnts=1;			// Border between elements 1 or 0
	var FontFamily="verdana,arial,comic sans ms,technical"	// Font family menu items
	var FontSize=8;				// Font size menu items
	var FontBold=0;				// Bold menu items 1 or 0
	var FontItalic=0;				// Italic menu items 1 or 0
	var MenuTextCentered='left';			// Item text position 'left', 'center' or 'right'
	var MenuCentered='left';			// Menu horizontal position 'left', 'center' or 'right'
	var MenuVerticalCentered='top';		// Menu vertical position 'top', 'middle','bottom' or static
	var ChildOverlap=.1;				// horizontal overlap child/ parent
	var ChildVerticalOverlap=.2;			// vertical overlap child/ parent
	var StartTop=128;				// Menu offset x coordinate
	var StartLeft=3;				// Menu offset y coordinate
	var VerCorrect=0;				// Multiple frames y correction
	var HorCorrect=0;				// Multiple frames x correction
	var LeftPaddng=3;				// Left padding
	var TopPaddng=2;				// Top padding
	var FirstLineHorizontal=0;			// SET TO 1 FOR HORIZONTAL MENU, 0 FOR VERTICAL
	var MenuFramesVertical=1;			// Frames in cols or rows 1 or 0
	var DissapearDelay=1000;			// delay before menu folds in
	var TakeOverBgColor=1;			// Menu frame takes over background color subitem frame
	var FirstLineFrame='navig';			// Frame where first level appears
	var SecLineFrame='space';			// Frame where sub levels appear
	var DocTargetFrame='space';			// Frame where target documents appear
	var TargetLoc='';				// span id for relative positioning
	var HideTop=0;				// Hide first level when loading new document 1 or 0
	var MenuWrap=1;				// enables/ disables menu wrap 1 or 0
	var RightToLeft=0;				// enables/ disables right to left unfold 1 or 0
	var UnfoldsOnClick=0;			// Level 1 unfolds onclick/ onmouseover
	var WebMasterCheck=0;			// menu tree checking on or off 1 or 0
	var ShowArrow=1;				// Uses arrow gifs when 1
	var KeepHilite=1;				// Keep selected path highligthed
	var Arrws=['jscript/right.gif',15,15,'JS/tridown.gif',10,5,'JS/trileft.gif',5,10];	// Arrow source, width and height

function BeforeStart(){return}
function AfterBuild(){return}
function BeforeFirstOpen(){return}
function AfterCloseAll(){return}

// Menu tree
//	MenuX=new Array(Text to show, Link, background image (optional), number of sub elements, height, width);
//	For rollover images set "Text to show" to:  "rollover:Image1.jpg:Image2.jpg"

Menu1 = new Array("University","","",0,18,180);
Menu2 = new Array("About Universities","","",12);
Menu3 = new Array("Organizational Structure","","",3);
Menu4 = new Array("Accreditation & Recognition","","",2);
Menu5 = new Array("Awards & Honors","","",3);
Menu6 = new Array("Tribunal","","0",3);
Menu7 = new Array("Statistics","","0",9);
Menu8 = new Array("Employment Opportunities","","0",0);
Menu9 = new Array("Annual Report","","0",0);
Menu10 = new Array("Universities Act 1994","","0",0);


Menu2_1=new Array("History"," ","",0,18,180);	
Menu2_2=new Array("Vision and Mission","","",0);
Menu2_3=new Array("Jurisdiction","","",0);
Menu2_4=new Array("Location and Map","","",0);
Menu2_5=new Array("Human Resources","","",0);
Menu2_6=new Array("Infrastructure Resources"," ","",0);
Menu2_7=new Array("Officers"," ","",0);
Menu2_8=new Array("Authorities"," ","",0);
Menu2_9=new Array("Committiees"," ","",0);
Menu2_10=new Array("Departments"," ","",0);
Menu2_11=new Array("Financial Aid and Grants Receivable-Sources amount"," ","",0);
Menu2_12=new Array("Alliances"," ","",0);


Menu3_1=new Array("Officers","","",0,18,180);
Menu3_2=new Array("Authorities","","",0);
Menu3_3=new Array("Committees","","",0);  


Menu4_1=new Array("Accreditation","","",0,16,180); 
Menu4_2=new Array("Recognition","","",0);


Menu5_1=new Array("Awards received by the University","","",0,16,180);
Menu5_2=new Array("Top Rankers","","",0);
Menu5_3=new Array("Awards given by the University","","",0);

Menu6_1=new Array("Jurisdiction","","",0,16,180);
Menu6_2=new Array("Officers of the Tribunal","","",0);
Menu6_3=new Array("Procedure of Applications","","",0);

Menu7_1=new Array("Departments","","",0,16,180);
Menu7_2=new Array("Affiliated Colleges","","",0);
Menu7_3=new Array("Recognized Institutions","","",0);
Menu7_4=new Array("Students","","",0,16,180);
Menu7_5=new Array("Teaching staff","","",0);
Menu7_6=new Array("Faculties","","",0);
Menu7_7=new Array("Courses","","",0,16,180);
Menu7_8=new Array("Result","","",0);
Menu7_9=new Array("Library","","",0);

