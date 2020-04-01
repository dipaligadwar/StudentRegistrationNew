/* http://ypslideoutmenus.sourceforge.net/ */
ypSlideOutMenu.Registry=[];ypSlideOutMenu.aniLen=250;ypSlideOutMenu.hideDelay=1000;ypSlideOutMenu.minCPUResolution=10;function ypSlideOutMenu(id,_2,_3,_4,_5,_6){this.ie=document.all?1:0;this.ns4=document.layers?1:0;this.dom=document.getElementById?1:0;this.css="";if(this.ie||this.ns4||this.dom){this.id=id;this.dir=_2;this.orientation=_2=="left"||_2=="right"?"h":"v";this.dirType=_2=="right"||_2=="down"?"-":"+";this.dim=this.orientation=="h"?_5:_6;this.hideTimer=false;this.aniTimer=false;this.open=false;this.over=false;this.startTime=0;this.gRef="ypSlideOutMenu_"+id;eval(this.gRef+"=this");ypSlideOutMenu.Registry[id]=this;var d=document;var _8="";_8+="#"+this.id+"Container{visibility:hidden;display:none;";_8+="left:"+_3+"px;";_8+="top:"+_4+"px;";_8+="overflow:hidden;z-index:10000;}";_8+="#"+this.id+"Container,#"+this.id+"Content{position:absolute;";_8+="width:"+_5+"px;";_8+="height:"+_6+"px;";_8+="clip:rect(0 "+_5+" "+_6+" 0);";_8+="}";this.css=_8;this.load();}}ypSlideOutMenu.writeCSS=function(){document.writeln("<style type=\"text/css\">");for(var id in ypSlideOutMenu.Registry){document.writeln(ypSlideOutMenu.Registry[id].css);}document.writeln("</style>");};ypSlideOutMenu.prototype.load=function(){var d=document;var _10=this.id+"Container";var _11=this.id+"Content";var _12=this.dom?d.getElementById(_10):this.ie?d.all[_10]:d.layers[_10];if(_12){var _13=this.ns4?_12.layers[_11]:this.ie?d.all[_11]:d.getElementById(_11);}var _14;if(!_12||!_13){window.setTimeout(this.gRef+".load()",100);}else{this.container=_12;this.menu=_13;this.style=this.ns4?this.menu:this.menu.style;this.homePos=eval("0"+this.dirType+this.dim);this.outPos=0;this.accelConst=(this.outPos-this.homePos)/ypSlideOutMenu.aniLen/ypSlideOutMenu.aniLen;if(this.ns4){this.menu.captureEvents(Event.MOUSEOVER|Event.MOUSEOUT);}this.menu.onmouseover=new Function("ypSlideOutMenu.showMenu('"+this.id+"')");this.menu.onmouseout=new Function("ypSlideOutMenu.hideMenu('"+this.id+"')");this.endSlide();}};ypSlideOutMenu.showMenu=function(id){var reg=ypSlideOutMenu.Registry;var obj=ypSlideOutMenu.Registry[id];if(obj.container){obj.over=true;for(menu in reg){if(id!=menu){ypSlideOutMenu.hide(menu);}}if(obj.hideTimer){reg[id].hideTimer=window.clearTimeout(reg[id].hideTimer);}if(!obj.open&&!obj.aniTimer){reg[id].startSlide(true);}}};ypSlideOutMenu.hideMenu=function(id){var obj=ypSlideOutMenu.Registry[id];if(obj.container){if(obj.hideTimer){window.clearTimeout(obj.hideTimer);}obj.hideTimer=window.setTimeout("ypSlideOutMenu.hide('"+id+"')",ypSlideOutMenu.hideDelay);}};ypSlideOutMenu.hideAll=function(){var reg=ypSlideOutMenu.Registry;for(menu in reg){ypSlideOutMenu.hide(menu);if(menu.hideTimer){window.clearTimeout(menu.hideTimer);}}};ypSlideOutMenu.hide=function(id){var obj=ypSlideOutMenu.Registry[id];obj.over=false;if(obj.hideTimer){window.clearTimeout(obj.hideTimer);}obj.hideTimer=0;if(obj.open&&!obj.aniTimer){obj.startSlide(false);}};ypSlideOutMenu.prototype.startSlide=function(_21){this[_21?"onactivate":"ondeactivate"]();this.open=_21;if(_21){this.setVisibility(true);}this.startTime=(new Date()).getTime();this.aniTimer=window.setInterval(this.gRef+".slide()",ypSlideOutMenu.minCPUResolution);};ypSlideOutMenu.prototype.slide=function(){var _22=(new Date()).getTime()-this.startTime;if(_22>ypSlideOutMenu.aniLen){this.endSlide();}else{var d=Math.round(Math.pow(ypSlideOutMenu.aniLen-_22,2)*this.accelConst);if(this.open&&this.dirType=="-"){d=-d;}else{if(this.open&&this.dirType=="+"){d=-d;}else{if(!this.open&&this.dirType=="-"){d=-this.dim+d;}else{d=this.dim+d;}}}this.moveTo(d);}};ypSlideOutMenu.prototype.endSlide=function(){this.aniTimer=window.clearTimeout(this.aniTimer);this.moveTo(this.open?this.outPos:this.homePos);if(!this.open){this.setVisibility(false);}if((this.open&&!this.over)||(!this.open&&this.over)){this.startSlide(this.over);}};ypSlideOutMenu.prototype.setVisibility=function(_24){var s=this.ns4?this.container:this.container.style;s.visibility=_24?"visible":"hidden";s.display=_24?"inline":"none";};ypSlideOutMenu.prototype.moveTo=function(p){this.style[this.orientation=="h"?"left":"top"]=this.ns4?p:p+"px";};ypSlideOutMenu.prototype.getPos=function(c){return parseInt(this.style[c]);};ypSlideOutMenu.prototype.onactivate=function(){};ypSlideOutMenu.prototype.ondeactivate=function(){};
