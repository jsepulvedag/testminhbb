function ExtendMenuWithKeyboard(){if ((typeof(RadMenu)=="u\x6e\x64efined") || (typeof(RadMenu.KeyDown)!="\165\x6e\x64efin\x65\x64")){return; }RadMenu.prototype.o2q= function (){var O2q=0; for (var i=0; i<this.GroupStateManagement.length; i++){if ((this.GroupStateManagement[i]!=null) && (O2q<i)){O2q=i; }}return O2q; };RadMenu.prototype.l2q= function (i2q){if (i2q!=0){return this.GetGroup(this.GroupStateManagement[i2q]); }else {return this.RootGroup; }};RadMenu.prototype.I2q= function (o2r){if (this.o12.Ig(o2r)){if (this.o12.Ig(o2r.O1a)){return o2r.O1a; }else if (this.o12.Ig(o2r.o18) && this.o12.Ig(o2r.o18[0])){return o2r.o18[0]; }}return null; };RadMenu.prototype.O2r= function (o2r){if (this.o12.Ig(o2r)){if (this.o12.Ig(o2r.O1a)){return true; }else if (this.o12.Ig(this.RootGroup.O1a)){return true; }}return false; };RadMenu.prototype.l2r= function (i2r){var I2r=i2r.ChildGroup; if (I2r && I2r.ID){ this.GroupStateManagement[i2r.Level+1]=I2r.ID; I2r.Show(i2r.Container); this.o2s(I2r.o18[0]); return true; }else {return false; }};RadMenu.prototype.O2s= function (){var l2s="i"; for (var i=0; i<this.o1z.length; i++){l2s+=this.o1z[i]; }return l2s; };RadMenu.prototype.i2s= function (){if (this.o12.Ig(this.l1z)){ this.I1z="\x69"; if (this.o12.Ig(this.O15)){ this.I1z+=this.O15; }if (this.o12.Ig(this.o15)){ this.I1z+=this.o15; } this.I1z+=this.l1z; }};RadMenu.prototype.I2s= function (){return this.I1y.I17(this.O2s()); };RadMenu.prototype.KeyUp= function (processedEvent){if (!processedEvent){var processedEvent=window.event; }var o2t=this.o12.oj(processedEvent); var Ic=this.I2s(); if (Ic){Ic.RemoveState(MODE_CLICKED); }if (o2t==o2l){var O2t=this.o2q(); if (O2t>0){O2t-=1; }var l2t=this.l2q(O2t); var i2t=this.I2q(l2t); i2t.RemoveState(MODE_CLICKED); i2t.Render(MODE_HILIGHT); } this.o1z.pop(); } ; RadMenu.prototype.KeyDown= function (processedEvent){if (!processedEvent){var processedEvent=window.event; }var I2t=this.o12.Ih(processedEvent); if (I2t.type=="t\x65xt" || I2t.type=="\x74extarea"){return; }var o2t=this.o12.oj(processedEvent); var o2u= false; var O2t=this.o2q(); var l2t=this.l2q(O2t); var i2t=this.I2q(l2t); if (this.I1z==""){ this.i2s(); }for (var i=0; i<this.o1z.length; i++){if (this.o1z[i]==o2t){o2u= true; switch (o2t){case o2m:case O2m:case I2l:case i2l:case I2m:case o2l:case o2n:break; default:return; }}}if (!o2u){ this.o1z.push(o2t); }if (this.I1z==this.O2s()){if (this.i19== false){ this.i19= true; this.O2u(processedEvent); }else { this.i19= false; this.l2u(processedEvent); }return false; }var Ic=this.I2s(); if (Ic){if (this.i19== false){ this.i19= true; this.i2u(Ic); }if (this.l2r(Ic)){Ic.ApplyClick(processedEvent); Ic.RemoveClick(processedEvent); }return false; }if (!this.O2r(l2t)){return; }switch (o2t){case o2m:case O2m:case I2l:case i2l:case o2n: this.o12.Ok(processedEvent); break; }if (this.i19== true){var O2t=this.o2q(); var l2t=this.l2q(O2t); var i2t=this.I2q(l2t); if (o2t==I2m){ this.CloseAll((O2t-1)); if ((O2t-1)==0){ this.i19= false; }return false; }if (o2t==o2n){i2t.o19(processedEvent); i2t.I18(processedEvent); }if (o2t==o2l){if (i2t.Enabled!= true){return; }if (!this.l2r(i2t)){i2t.ApplyClick(processedEvent); i2t.RemoveClick(processedEvent); }return false; } this.o2s(this.I2u(i2t,l2t,O2t,o2t)); return false; }return true; } ; RadMenu.prototype.O2u= function (processedEvent){if (this.ClickToOpen== false){ this.ClickToOpen= true; this.FirstClick= false; }if (this.RootGroup && this.RootGroup.o18 && this.RootGroup.o18.length>0){ this.o2s(this.RootGroup.o18[0]); }};RadMenu.prototype.i2u= function (item){if (this.ClickToOpen== false){ this.ClickToOpen= true; this.FirstClick= false; }if (this.RootGroup && this.RootGroup.o18 && this.RootGroup.o18.length>0){ this.o2s(item); }};RadMenu.prototype.l2u= function (processedEvent){if (this.ClickToOpen== true){ this.ClickToOpen= false; this.FirstClick= true; } this.CloseAll(0); window.status=""; };RadMenu.prototype.o2s= function (o25){if (o25){var ParentGroup=null; var l1a=0; ParentGroup=o25.ParentGroup; l1a=o25.Level; if ((l1a)>0 && (ParentGroup!=null)){if (this.GroupStateManagement[l1a]!=ParentGroup.ID){ this.GroupStateManagement[l1a]=ParentGroup.ID; }if (ParentGroup.Visible!= true){ParentGroup.Show(ParentGroup.i11.Container); }} this.o2v(o25); }};RadMenu.prototype.o2v= function (o25){ this.O19(this.l19); this.CloseAll(o25.Level); if (o25==(o25.ParentGroup.O1a)){return; }if (o25.ParentGroup){if (o25.ParentGroup.O1a!=null){o25.ParentGroup.O1a.RemoveHilight(); }o25.ParentGroup.O1a=o25; }if (!this.o12.Ig(o25.O16)){o25.ApplyHilight(); }} ; RadMenu.prototype.NextItem= function (O2v){if (O2v.NextItem){if (O2v.NextItem.o17){return this.NextItem(O2v.NextItem); }return O2v.NextItem; }else {return this.l2v(O2v.ParentGroup); }};RadMenu.prototype.PreviousItem= function (O2v){if (O2v.PreviousItem){if (O2v.PreviousItem.o17){return this.PreviousItem(O2v.PreviousItem); }return O2v.PreviousItem; }else {return this.i2v(O2v.ParentGroup); }};RadMenu.prototype.l2v= function (I2v){if (I2v && I2v.o18){if (I2v.o18[0].o17){return this.NextItem(I2v.o18[0]); }return I2v.o18[0]; }return null; };RadMenu.prototype.i2v= function (I2v){if (I2v && I2v.o18){if (I2v.o18[(I2v.o18.length-1)].o17){return this.PreviousItem(I2v.o18[(I2v.o18.length-1)]); }return I2v.o18[(I2v.o18.length-1)]; }return null; };RadMenu.prototype.I2u= function (l2d,O2d,o2w,O2w){if (!this.o12.Ig(l2d) || !this.o12.Ig(O2d) || !this.o12.Ig(o2w)){return null; }var l2w=O2d.o1g; switch (O2w){case o2m:if (l2w==VERTICAL_DIRECTION){return this.PreviousItem(l2d); }else if (l2d.ChildGroup){return this.l2v(l2d.ChildGroup); }break; case O2m:if (l2w==VERTICAL_DIRECTION){return this.NextItem(l2d); }else if (l2d.ChildGroup){return this.l2v(l2d.ChildGroup); }break; case I2l:if (l2w==VERTICAL_DIRECTION){if (l2d.ChildGroup){return this.l2v(l2d.ChildGroup); }else {var i2w= true; if ((o2w-1)<0){return null; }O2d=this.l2q(o2w-1); if (O2d.o1g==VERTICAL_DIRECTION){for (var i=this.GroupStateManagement.length; i>=0; i--){if (this.GroupStateManagement[i]){O2d=this.GetGroup(this.GroupStateManagement[i]); if (O2d.o1g==HORIZONTAL_DIRECTION){i2w= false; break; }}}if (i2w){O2d=this.RootGroup; }}return this.NextItem(O2d.O1a); }}else {return this.NextItem(l2d); }break; case i2l:if (l2w==VERTICAL_DIRECTION){if ((o2w-1)<0){return null; }O2d=this.l2q(o2w-1); if (O2d.o1g==VERTICAL_DIRECTION){return O2d.O1a; }else {return this.PreviousItem(O2d.O1a); }}else {return this.PreviousItem(l2d); }break; default:return; }};}