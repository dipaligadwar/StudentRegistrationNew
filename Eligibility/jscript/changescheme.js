
 function createCookie(name,value,days) {
  if (days) {
    var date = new Date();
    date.setTime(date.getTime()+(days*24*60*60*1000));
    var expires = "; expires="+date.toGMTString();
  }
  else expires = "";
  document.cookie = name+"="+value+expires+"; path=/";
}
function readCookie(name) {
  var nameEQ = name + "=";
  var ca = document.cookie.split(';');
  for(var i=0;i < ca.length;i++) {
    var c = ca[i];
    while (c.charAt(0)==' ') c = c.substring(1,c.length);
    if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
  }
  return null;
}
        
//function getPreferredStyleSheet() {
//    var i, a;
//    for(i=0; (a = document.getElementsByTagName("link")[i]); i++) 
//    {
//    if(a.getAttribute("title")=='Color-Scheme')return a;        
//    }
//    return null;
//}
//function  setStyle() {
//    var cookie = readCookie("style");  
//    var oLink = getPreferredStyleSheet();
//    var cssFile = cookie ? cookie : oLink.href;
//    //LNKChangeTheme
//    var arr = oLink.href.split('/'); 
//      
//    if(cookie!=null)
//        cssFile = oLink.href.replace(arr[arr.length-1],cookie);                
//    else
//        cssFile = oLink.href.replace(arr[arr.length-1],'color1.css');     
//        
//    oLink.setAttribute("href",cssFile);
//}
function setStyle() {
    var cookie = readCookie("style");
    var cssFile = cookie ? cookie : 'color1.css';

    var $link = $("<link rel='stylesheet' href='/css/" + cssFile  + "'  type='text/css'></link>");

    $("html head:first-child").append($link)      
}

function applyAnimation() {

    //
    //swith theme
    //
    setTimeout("setStyle()", 500);

    $('body').append('<div id="overlay" />');
    $('body').css({ height: '100%' });
    $('#overlay').css({
        display: 'none',
        position: 'absolute',
        top: 0,
        left: 0,
        width: '100%',
        height: '100%',
        zindex: 1000,
        opacity: '0.6',
        filter: 'alpha(opacity=60)',
        background: 'gray url(/images/loading.gif) no-repeat center'
    });
    $('#overlay').fadeIn(500, function () {       
        $('#overlay').fadeOut(500, function () {
            $(this).remove();
        });
    });
}
function setCookie(cssStyle)
{
    createCookie("style", cssStyle, 365);
    //
    //SET THEME
    //
    applyAnimation();   
    return false;
}



  
