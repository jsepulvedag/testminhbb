function ExtendMenuWithScroll(){if ((typeof(RadMenu)=="undefined") || (typeof(RadMenu.O1o)!="\x75\x6edefined")){return; }RadMenu.prototype.I2w= function (o2x){if (!this.o12.Ig(o2x)){return null; }if (!this.o12.Ig(o2x.O1k)){o2x.O1o(); }return this.o12.lk(o2x.O1k); };RadMenuGroup.prototype.O1o= function (){if (this.o1h){if (this.ParentMenu.I20== false){RadMenuNamespace.O21(this.ParentMenu); this.ParentMenu.I20= true; }if (this.o1k==null){ this.o1k=document.getElementById(("outerSc\x72oller"+this.ID)); }if (this.O1k==null){ this.O1k=document.getElementById(("\x69nnerScr\x6f\x6cler"+this.ID)); }if (this.i1k==null){ this.i1k=this.ParentMenu.o12.om(this.O1k)+"px"; if (this.i1k=="\060\x70x"){ this.i1k=this.ParentMenu.o12.om(this.O1k.childNodes[0])+"\x70x"; }if (this.ParentMenu.I1c.IsMozilla){}}if (this.I1k==null){ this.I1k=this.ParentMenu.o12.il(this.O1k)+"px"; if (this.I1k=="\x30\x70x"){ this.I1k=this.ParentMenu.o12.il(this.O1k.childNodes[0])+"px"; }}var O2x=null; if (this.o1k.style){O2x=this.o1k.style; }else {O2x=this.o1k; }var l2x=null; this.l1k=this.Container.getElementsByTagName("t\x61\142le")[0]; l2x=this.l1k.getElementsByTagName("\x69mg"); if (this.o1g==VERTICAL_DIRECTION){ this.o1l=l2x[0]; this.O1l=l2x[(l2x.length-1)]; O2x.width=this.i1k; }else if (this.o1g==HORIZONTAL_DIRECTION){ this.l1l=l2x[0]; this.i1l=l2x[(l2x.length-1)]; O2x.height=this.I1k; }}};RadMenu.prototype.ScrollLeft= function (i2x){ this.O19(this.l19); var I2x=null; var I11=this ; var O2x=null; I2x=this.AllGroups.I17(i2x); O2x=this.I2w(I2x); if (parseInt(O2x.left)>(I2x.l1h-parseInt(I2x.i1k))){O2x.left=parseInt(O2x.left)-this.o1y+"px"; } this.ScrollLeftTime=setTimeout( function (){I11.ScrollLeft(i2x); } ,50); };RadMenu.prototype.ScrollRight= function (i2x){ this.O19(this.l19); var I2x=null; var I11=this ; var O2x=null; I2x=this.AllGroups.I17(i2x); O2x=this.I2w(I2x); if (parseInt(O2x.left)<0){O2x.left=parseInt(O2x.left)+this.o1y+"px"; } this.ScrollRightTime=setTimeout( function (){I11.ScrollRight(i2x); } ,50); };RadMenu.prototype.ScrollUp= function (i2x){ this.O19(this.l19); var I2x=null; var I11=this ; var O2x=null; I2x=this.AllGroups.I17(i2x); O2x=this.I2w(I2x); if (parseInt(O2x.top)<0){O2x.top=parseInt(O2x.top)+this.o1y+"px"; } this.ScrollUpTime=setTimeout( function (){I11.ScrollUp(i2x); } ,50); };RadMenu.prototype.ScrollDown= function (i2x){ this.O19(this.l19); var I2x=null; var I11=this ; var O2x=null; I2x=this.AllGroups.I17(i2x); O2x=this.I2w(I2x); if (parseInt(O2x.top)>(I2x.O1h-parseInt(I2x.I1k))){O2x.top=parseInt(O2x.top)-this.o1y+"px"; } this.ScrollDownTime=setTimeout( function (){I11.ScrollDown(i2x); } ,50); };}
