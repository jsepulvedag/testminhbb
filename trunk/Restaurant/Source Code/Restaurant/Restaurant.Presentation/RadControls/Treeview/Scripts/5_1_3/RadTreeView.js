var RadTreeView_KeyboardHooked= false; var RadTreeView_Active=null; var RadTreeView_DragActive=null; var RadTreeView_MouseMoveHooked= false; var RadTreeView_MouseUpHooked= false; var RadTreeView_MouseY=0; var RadTreeViewGlobalFirstParam=null; var RadTreeViewGlobalSecondParam=null; var RadTreeViewGlobalThirdParam=null; var contextMenuToBeHidden=null; function RadTreeNode(){ this.Parent=null; this.TreeView=null; this.Nodes=new Array(); this.ID=null; this.ClientID=null; this.SignImage=null; this.SignImageExpanded=null; this.Image=0; this.ImageExpanded=0; this.Action=null; this.Index=0; this.Level=0; this.Text=null; this.Value=null; this.Category=null; this.NodeCss=null; this.NodeCssOver=null; this.NodeCssSelect=null; this.ContextMenuName=null; this.Enabled= true; this.Expanded= false; this.Checked= false; this.Selected= false; this.DragEnabled=1; this.DropEnabled=1; this.EditEnabled=1; this.ExpandOnServer=0; this.IsClientNode=0; this.Attributes=new Array(); this.O= false; } ; RadTreeNode.prototype.Next= function (){var o=(this.Parent != null)?this.Parent.Nodes: this.TreeView.Nodes; return (this.Index>=o.length)?null:o[this.Index+1]; } ; RadTreeNode.prototype.Prev= function (){var o=(this.Parent != null)?this.Parent.Nodes: this.TreeView.Nodes; return (this.Index<=0)?null:o[this.Index-1]; } ; RadTreeNode.prototype.NextVisible= function (){if (this.Expanded)return this.Nodes[0]; if (this.Next() != null)return this.Next(); var I=this ; while (I.Parent != null){if (I.Parent.Next() != null)return I.Parent.Next(); I=I.Parent; }return null; } ; RadTreeNode.prototype.PrevVisible= function (){if (this.Prev() != null){return this.Prev(); }if (this.Parent != null){return this.Parent; }return null; } ; RadTreeNode.prototype.Toggle= function (){if (this.Enabled){if (this.TreeView.FireEvent(this.TreeView.BeforeClientToggle,this ) == false){return; } (this.Expanded)?this.Collapse(): this.Expand(); this.TreeView.FireEvent(this.TreeView.AfterClientToggle,this ); }} ; RadTreeNode.prototype.CollapseNonParentNodes= function (){for (var i=0; i<this.TreeView.AllNodes.length; i++){if (this.TreeView.AllNodes[i].Expanded&&!this.IsParent(this.TreeView.AllNodes[i])){ this.TreeView.AllNodes[i].CollapseNoEffect(); }}} ; RadTreeNode.prototype.U= function (s){try {return encodeURIComponent(s); }catch (e){return escape(s); }} ; RadTreeNode.prototype.Z= function (){var url=this.TreeView.LoadOnDemandUrl+"\x26\x72\x74\x6e\x43\x6c\x69\x65\x6e\x74\x49\x44\x3d"+this.ClientID+"\x26\x72\x74\x6e\x4c\x65\x76\x65\x6c\x3d"+this.Level+"\x26\x72\x74\x6e\x49\x44\x3d"+this.ID+"\x26\x72\x74\x6e\x50\x61\x72\x65\x6e\x74\x50\x6f\x73\x69\x74\x69\x6f\x6e\x3d"+this.GetParentPositions()+"\x26\x72\x74\x6e\x54\x65\x78\x74\x3d"+this.U(this.Text)+"\x26\x72\x74\x6e\x56\x61\x6c\x75\x65\x3d"+this.U(this.Value)+"\x26\x72\x74\x6e\x43\x61\x74\x65\x67\x6f\x72\x79\x3d"+this.U(this.Category); var z; if (typeof(XMLHttpRequest) != "\x75\x6e\x64\x65\x66\x69\x6e\x65\x64"){z=new XMLHttpRequest(); }else {z=new ActiveXObject("\x4d\x69\x63\x72\x6f\x73\x6f\x66\x74\x2e\x58\x4d\x4c\x48\x54\x54\x50"); }url=url+"\x26\x74\x69\x6d\x65\x53\x74\x61\x6d\x70\x3d"+encodeURIComponent((new Date()).getTime()); z.open("\x47\x45\x54",url, true); var W=this ; z.onreadystatechange= function (){if (z.readyState != 4)return; var html=z.responseText; var index=html.indexOf("\x2c"); var V=parseInt(html.substring(0,index)); var v=html.substring(index+1,V+index+1); var T=html.substring(V+index+1); W.LoadNodesOnDemand(v); W.ImageOn(); W.SignOn(); W.Expanded= true; W.ExpandOnServer=0; var S=W.TextElement().parentNode; var R=S.parentNode; switch (W.TreeView.LoadingMessagePosition){case 0:case 1:if (S.tagName == "\x41"){S.firstChild.innerHTML=W.Text; }else {R=W.TextElement().parentNode; if (W.TextElement().innerText){W.TextElement().innerText=W.Text; }else {W.TextElement().innerHTML=W.Text; }}break; case 2:S.removeChild(document.getElementById(W.ClientID+"\x4c\x6f\x61\x64\x69\x6e\x67")); R=W.TextElement().parentNode; break; case 3:R=W.TextElement().parentNode; }rtvInsertHTML(R,T); var images=R.getElementsByTagName("\x49\x4d\x47"); for (var i=0; i<images.length; i++){images[i].align="\x6d\x69\x64\x64\x6c\x65"; images[i].style.display="\x69\x6e\x6c\x69\x6e\x65"; }W.O= false; W.TreeView.FireEvent(W.TreeView.AfterClientToggle,W); } ; z.send(null); } ; RadTreeNode.prototype.Expand= function (){if (this.ExpandOnServer){if (!this.TreeView.FireEvent(this.TreeView.BeforeClientToggle,this )){return; }if (this.ExpandOnServer == 1){ this.TreeView.Q("\x4e\x6f\x64\x65\x45\x78\x70\x61\x6e\x64",this.ClientID); return; }if (this.ExpandOnServer == 2){if (!this.O){ this.O= true; switch (this.TreeView.LoadingMessagePosition){case 0: this.TextElement().innerHTML="\x3c\x73\x70\x61\x6e\x20\x63\x6c\x61\x73\x73\x3d"+this.TreeView.LoadingMessageCssClass+"\x3e"+this.TreeView.LoadingMessage+"\x3c\x2f\x73\x70\x61\x6e\x3e\x20"+this.TextElement().innerHTML; break; case 1: this.TextElement().innerHTML=this.TextElement().innerHTML+"\x20"+"\x3c\x73\x70\x61\x6e\x20\x63\x6c\x61\x73\x73\x3d"+this.TreeView.LoadingMessageCssClass+"\x3e"+this.TreeView.LoadingMessage+"\x3c\x2f\x73\x70\x61\x6e\x3e\x20"; break; case 2:rtvInsertHTML(this.TextElement().parentNode,"\x3c\x64\x69\x76\x20\x69\x64\x3d"+this.ClientID+"\x4c\x6f\x61\x64\x69\x6e\x67\x20"+"\x20\x63\x6c\x61\x73\x73\x3d"+this.TreeView.LoadingMessageCssClass+"\x3e"+this.TreeView.LoadingMessage+"\x3c\x2f\x64\x69\x76\x3e"); break; }var W=this ; window.setTimeout( function (){W.Z();} ,024); return; }}}if (!this.Nodes.length){return; }if (this.TreeView.SingleExpandPath){ this.CollapseNonParentNodes(); }var P=document.getElementById("\x47"+this.ClientID); if (this.TreeView.ExpandDelay>0){P.style.overflow="\x68\x69\x64\x64\x65\x6e"; P.style.height="\x31\x70\x78"; P.style.display="\x62\x6c\x6f\x63\x6b"; P.firstChild.style.position="\x72\x65\x6c\x61\x74\x69\x76\x65"; window.setTimeout("\x72\x74\x76\x4e\x6f\x64\x65\x45\x78\x70\x61\x6e\x64\x28\x31\x2c\x27"+P.id+"\x27\x2c"+this.TreeView.ExpandDelay+"\x29\x3b",024); }else {P.style.display="\x62\x6c\x6f\x63\x6b"; } this.ImageOn(); this.SignOn(); this.Expanded= true; if (!this.IsClientNode){ this.TreeView.UpdateExpandedState(); }} ; RadTreeNode.prototype.GetParentPositions= function (){var parentNode=this ; var N=""; while (parentNode != null){if (parentNode.Next() != null){N=N+"\x31"; }else {N=N+"\x30"; }parentNode=parentNode.Parent; }return N; } ; RadTreeNode.prototype.Collapse= function (){if (this.Nodes.length>0){if (this.TreeView.ExpandDelay>0){var P=document.getElementById("\x47"+this.ClientID); if (P.scrollHeight != "\x75\x6e\x64\x65\x66\x69\x6e\x65\x64"){P.style.overflow="\x68\x69\x64\x64\x65\x6e"; P.style.display="\x62\x6c\x6f\x63\x6b"; P.firstChild.style.position="\x72\x65\x6c\x61\x74\x69\x76\x65"; window.setTimeout("\x72\x74\x76\x4e\x6f\x64\x65\x43\x6f\x6c\x6c\x61\x70\x73\x65\x28"+P.scrollHeight+"\x2c\x27"+P.id+"\x27\x2c"+this.TreeView.ExpandDelay+"\x20\x29\x3b",024); }else { this.CollapseNoEffect(); }}else { this.CollapseNoEffect(); } this.ImageOff(); this.SignOff(); this.Expanded= false; this.TreeView.UpdateExpandedState(); }} ; RadTreeNode.prototype.CollapseNoEffect= function (){if (this.Nodes.length>0){var P=document.getElementById("\x47"+this.ClientID); P.style.display="\x6e\x6f\x6e\x65"; this.ImageOff(); this.SignOff(); this.Expanded= false; this.TreeView.UpdateExpandedState(); }} ; RadTreeNode.prototype.Highlight= function (e){if (!this.Enabled){return; }if (e){if (this.TreeView.MultipleSelect&&(e.ctrlKey||e.shiftKey)){if (this.Selected){ this.TextElement().className=this.NodeCss; this.Selected= false; if (this.TreeView.SelectedNode == this ){ this.TreeView.SelectedNode=null; } this.TreeView.UpdateSelectedState(); return; }}else { this.TreeView.UnSelectAllNodes(); }} this.TextElement().className=this.NodeCssSelect; this.TreeView.SelectNode(this ); this.TreeView.FireEvent(this.TreeView.AfterClientHighlight,this ); } ; RadTreeNode.prototype.ExecuteAction= function (e){if (this.IsClientNode){return; }if (this.TextElement().tagName == "\x41"){ this.TextElement().click(); }else if (this.Action){ this.TreeView.Q("\x4e\x6f\x64\x65\x43\x6c\x69\x63\x6b",this.ClientID); }if (e){ (document.all)?e.returnValue= false :e.preventDefault(); }} ; RadTreeNode.prototype.Select= function (e){if (this.TreeView.FireEvent(this.TreeView.BeforeClientClick,this,e) == false)return; if (this.Enabled){ this.Highlight(e); this.TreeView.LastHighlighted=this ; this.ExecuteAction(); }else { (document.all)?e.returnValue= false :e.preventDefault(); }} ; RadTreeNode.prototype.UnSelect= function (){ this.TextElement().className=this.NodeCss; this.Selected= false; } ; RadTreeNode.prototype.Disable= function (){ this.TextElement().className=this.TreeView.NodeCssDisable; this.Enabled= false; this.Selected= false; if (this.CheckElement() != null)this.CheckElement().disabled= true; } ; RadTreeNode.prototype.Enable= function (){ this.TextElement().className=this.NodeCss; this.Enabled= true; if (this.CheckElement() != null){ this.CheckElement().disabled= false; }} ; RadTreeNode.prototype.Hover= function (){if (this.Enabled){if (this.TreeView.FireEvent(this.TreeView.BeforeClientHighlight,this ) == false){return; } this.TreeView.LastHighlighted=this ; if (RadTreeView_DragActive != null&&RadTreeView_DragActive.DragClone != null&&(!this.Expanded)){var W=this ; window.setTimeout( function (){W.M(); } ,01750); }if (!this.Selected){ this.TextElement().className=this.NodeCssOver; if (this.Image){ this.m().style.cursor="\x68\x61\x6e\x64"; }} this.TreeView.FireEvent(this.TreeView.AfterClientHighlight,this ); }} ; RadTreeNode.prototype.M= function (){if (RadTreeView_DragActive != null&&RadTreeView_DragActive.DragClone != null&&(!this.Expanded)){if (RadTreeView_Active.LastHighlighted == this ){ this.Expand(); }}} ; RadTreeNode.prototype.UnHover= function (){if (this.Enabled){ this.TreeView.LastHighlighted=null; if (!this.Selected){ this.TextElement().className=this.NodeCss; if (this.Image){ this.m().style.cursor="\x64\x65\x66\x61\x75\x6c\x74"; }}}} ; RadTreeNode.prototype.CheckBoxClick= function (e){if (this.Enabled){if (this.TreeView.FireEvent(this.TreeView.BeforeClientCheck,this ) == false){ (this.Checked)?this.Check(): this.UnCheck(); return; } (this.Checked)?this.UnCheck(): this.Check(); this.TreeView.FireEvent(this.TreeView.AfterClientCheck,this ); if (this.TreeView.AutoPostBackOnCheck){ this.TreeView.Q("\x4e\x6f\x64\x65\x43\x68\x65\x63\x6b",this.ClientID); return; }}} ; RadTreeNode.prototype.Check= function (){if (this.CheckElement() != null){ this.CheckElement().checked= true; this.Checked= true; this.TreeView.UpdateCheckedState(); }} ; RadTreeNode.prototype.UnCheck= function (){if (this.CheckElement() != null){ this.CheckElement().checked= false; this.Checked= false; this.TreeView.UpdateCheckedState(); }} ; RadTreeNode.prototype.IsSet= function (a){return (a != null&&a != ""); } ; RadTreeNode.prototype.ImageOn= function (){var L=document.getElementById(this.ClientID+"\x69"); if (this.ImageExpanded != 0){L.src=this.ImageExpanded; }} ; RadTreeNode.prototype.ImageOff= function (){var L=document.getElementById(this.ClientID+"\x69"); if (this.Image != 0){L.src=this.Image; }} ; RadTreeNode.prototype.SignOn= function (){var l=document.getElementById(this.ClientID+"\x63"); if (this.IsSet(this.SignImageExpanded)){l.src=this.SignImageExpanded; }} ; RadTreeNode.prototype.SignOff= function (){var l=document.getElementById(this.ClientID+"\x63"); if (this.IsSet(this.SignImage)){l.src=this.SignImage; }} ; RadTreeNode.prototype.TextElement= function (){var K=document.getElementById(this.ClientID); var k=K.getElementsByTagName("\x73\x70\x61\x6e")[0]; if (k == null){k=K.getElementsByTagName("\x61")[0]; }return k; } ; RadTreeNode.prototype.m= function (){return document.getElementById(this.ClientID+"\x69"); } ; RadTreeNode.prototype.CheckElement= function (){return document.getElementById(this.ClientID).getElementsByTagName("\x69\x6e\x70\x75\x74")[0]; } ; RadTreeNode.prototype.IsParent= function (node){var parent=this.Parent; while (parent != null){if (node == parent)return true; parent=parent.Parent; }return false; } ; RadTreeNode.prototype.StartEdit= function (){if (this.EditEnabled){var J=this.TextElement().innerHTML; this.TreeView.EditMode= true; var parentElement=this.TextElement().parentNode; this.TreeView.EditTextElement=this.TextElement().cloneNode( true); this.TextElement().parentNode.removeChild(this.TextElement()); var H=this ; var h=document.createElement("\x69\x6e\x70\x75\x74"); h.setAttribute("\x74\x79\x70\x65","\x74\x65\x78\x74"); h.setAttribute("\x73\x69\x7a\x65",this.Text.length+3); h.setAttribute("\x76\x61\x6c\x75\x65",J); h.className=this.TreeView.NodeCssEdit; var g=this ; h.onblur= function (){g.EndEdit(); } ; h.onchange= function (){g.EndEdit(); } ; h.onkeypress= function (e){g.AnalyzeEditKeypress(e); } ; h.onsubmit= function (){return false; } ; parentElement.appendChild(h); this.TreeView.EditInputElement=h; h.focus(); h.onselectstart= function (e){if (!e)e=window.event; if (e.stopPropagation){e.stopPropagation(); }else {e.cancelBubble= true; }} ; var F=0; var f=this.Text.length; if (h.createTextRange){var D=h.createTextRange(); D.moveStart("\x63\x68\x61\x72\x61\x63\x74\x65\x72",F); D.moveEnd("\x63\x68\x61\x72\x61\x63\x74\x65\x72",f); D.select(); }else {h.setSelectionRange(F,f); }}} ; RadTreeNode.prototype.EndEdit= function (){var parentElement=this.TreeView.EditInputElement.parentNode; if (this.TreeView.EditTextElement.innerHTML != this.TreeView.EditInputElement.value){ this.TreeView.EditInputElement.onblur= function (){} ; this.TreeView.EditInputElement.onchange= function (){} ; var d=this.ClientID+"\x3a"+this.TreeView.C(this.TreeView.EditInputElement.value); this.TreeView.Q("\x4e\x6f\x64\x65\x45\x64\x69\x74",d); return; } this.TreeView.EditTextElement.innerHTML=this.TreeView.EditInputElement.value; this.Text=this.TreeView.EditInputElement.value; this.TreeView.EditInputElement.parentNode.removeChild(this.TreeView.EditInputElement); parentElement.appendChild(this.TreeView.EditTextElement); this.TreeView.EditMode= false; this.TreeView.EditInputElement=null; this.TreeView.EditTextElement=null; } ; RadTreeNode.prototype.AnalyzeEditKeypress= function (e){if (document.all)e=event; if (e.keyCode == 015){ (document.all)?e.returnValue= false :e.preventDefault(); this.EndEdit(); return false; }if (e.keyCode == 033){ this.TreeView.EditInputElement.value=this.TreeView.EditTextElement.innerHTML; this.EndEdit(); }return true; } ; RadTreeNode.prototype.LoadNodesOnDemand= function (s){eval(s); var B=eval(this.ClientID+"\x43\x6c\x69\x65\x6e\x74\x44\x61\x74\x61"); for (var i=0; i<B.length; i++){B[i][021]=0; this.TreeView.LoadNode(B[i],null,this ); }} ; function RadTreeView(o0){if (window.tlrkTreeViews == null){window.tlrkTreeViews=new Array(); }tlrkTreeViews[o0]=this ; this.Nodes=new Array(); this.AllNodes=new Array(); this.ClientID=null; this.SelectedNode=null; this.DragMode= false; this.DragSource=null; this.DragClone=null; this.LastHighlighted=null; this.MouseInside= false; this.HtmlElementID=""; this.EditMode= false; this.EditTextElement=null; this.EditInputElement=null; this.BeforeClientClick=null; this.BeforeClientHighlight=null; this.AfterClientHighlight=null; this.BeforeClientDrop=null; this.BeforeClientToggle=null; this.AfterClientToggle=null; this.BeforeClientContextClick=null; this.BeforeClientContextMenu=null; this.AfterClientContextClick=null; this.BeforeClientCheck=null; this.AfterClientCheck=null; this.AfterClientMove=null; this.AfterClientFocus=null; this.BeforeClientDrag=null; this.AutoPostBackOnCheck= false; this.CausesValidation= true; this.ContextMenuVisible= false; this.ContextMenuName=null; this.O0=null; this.SingleExpandPath= false; this.ExpandDelay=2; this.TabIndex=0; this.AllowNodeEditing= false; this.LoadOnDemandUrl=null; this.LoadingMessage="\x28\x6c\x6f\x61\x64\x69\x6e\x67\x20\x2e\x2e\x2e\x29"; this.LoadingMessagePosition=0; this.LoadingMessageCssClass="\x4c\x6f\x61\x64\x69\x6e\x67\x4d\x65\x73\x73\x61\x67\x65"; this.l0= false; } ; RadTreeView.prototype.OnInit= function (){var ImageList=new Array(); this.PreloadImages(ImageList); i0=ImageList; var images=document.getElementById(this.Container).getElementsByTagName("\x49\x4d\x47"); for (var i=0; i<images.length; i++){var index=images[i].className; if (index != null&&index != ""){images[i].src=ImageList[index].src; }images[i].align="\x6d\x69\x64\x64\x6c\x65"; } this.LoadTree(ImageList); var I0=document.getElementById(this.Container).getElementsByTagName("\x49\x4e\x50\x55\x54"); for (var i=0; i<I0.length; i++){I0[i].style.verticalAlign="\x6d\x69\x64\x64\x6c\x65"; }if (document.addEventListener&&(!RadTreeView_KeyboardHooked)){RadTreeView_KeyboardHooked= true; document.addEventListener("\x6b\x65\x79\x64\x6f\x77\x6e",this.KeyDownMozilla, false); }if ((!RadTreeView_MouseMoveHooked)&&(this.DragAndDrop)){RadTreeView_MouseMoveHooked= true; if (document.attachEvent){document.attachEvent("\x6f\x6e\x6d\x6f\x75\x73\x65\x6d\x6f\x76\x65",rtvMouseMove); }if (document.addEventListener){document.addEventListener("\x6d\x6f\x75\x73\x65\x6d\x6f\x76\x65",rtvMouseMove, false); }}if (!RadTreeView_MouseUpHooked){RadTreeView_MouseUpHooked= true; if (document.attachEvent){document.attachEvent("\x6f\x6e\x6d\x6f\x75\x73\x65\x75\x70",rtvMouseUp); }if (document.addEventListener){document.addEventListener("\x6d\x6f\x75\x73\x65\x75\x70",rtvMouseUp, false); }} this.o1(); this.l0= true; } ; RadTreeView.prototype.o1= function (){var H=this ; var O1=document.getElementById(this.Container); O1.onfocus= function (e){rtvDispatcher(H.ClientID,"\x66\x6f\x63\x75\x73",e); } ; O1.onmouseover= function (e){rtvDispatcher(H.ClientID,"\x6d\x6f\x76\x65\x72",e); } ; O1.onmouseout= function (e){rtvDispatcher(H.ClientID,"\x6d\x6f\x75\x74",e); } ; O1.oncontextmenu= function (e){rtvDispatcher(H.ClientID,"\x63\x6f\x6e\x74\x65\x78\x74",e); } ; O1.onscroll= function (e){rtvDispatcher(H.ClientID,"\x73\x63\x72\x6f\x6c\x6c",e); } ; O1.onclick= function (e){rtvDispatcher(H.ClientID,"\x6d\x63\x6c\x69\x63\x6b",e); } ; O1.ondblclick= function (e){rtvDispatcher(H.ClientID,"\x6d\x64\x63\x6c\x69\x63\x6b",e); } ; O1.onkeydown= function (e){rtvDispatcher(H.ClientID,"\x6b\x65\x79\x64\x6f\x77\x6e",e); } ; O1.onselectstart= function (){return false; } ; if (this.DragAndDrop){O1.onmousedown= function (e){rtvDispatcher(H.ClientID,"\x6d\x64\x6f\x77\x6e",e); } ; }if (window.attachEvent){window.attachEvent("\x6f\x6e\x75\x6e\x6c\x6f\x61\x64", function (){var O1=document.getElementById(H.Container); H.l1(O1); } ); }} ; RadTreeView.prototype.l1= function (O1){for (var i1 in O1){if (typeof(O1[i1]) == "\x66\x75\x6e\x63\x74\x69\x6f\x6e"){O1[i1]=null; }}};RadTreeView.prototype.PreloadImages= function (images){var imageData=eval(this.ClientID+"\x49\x6d\x61\x67\x65\x44\x61\x74\x61"); for (var i=0; i<imageData.length; i++){var I1=new Image(); I1.src=imageData[i]; images[i]=I1; }} ; RadTreeView.prototype.FindNode= function (node){for (var i=0; i<this.AllNodes.length; i++){if (this.AllNodes[i].ClientID == node){return this.AllNodes[i]; }}return null; } ; RadTreeView.prototype.FindNodeByText= function (text){for (var i=0; i<this.AllNodes.length; i++){if (this.AllNodes[i].Text == text){return this.AllNodes[i]; }}return null; } ; RadTreeView.prototype.FindNodeByValue= function (value){for (var i=0; i<this.AllNodes.length; i++){if (this.AllNodes[i].Value == value){return this.AllNodes[i]; }}return null; } ; RadTreeView.prototype.LoadTree= function (o2){var O2=eval(this.ClientID+"\x43\x6c\x69\x65\x6e\x74\x44\x61\x74\x61"); for (var i=0; i<O2.length; i++){ this.LoadNode(O2[i],o2); }} ; RadTreeView.prototype.LoadNode= function (O2,o2,parentNode){var l2=new RadTreeNode(); l2.ClientID=O2[0]; l2.TreeView=this ; var i2=O2[021]; if (i2>0){l2.Parent=this.AllNodes[i2-1]; }if (parentNode != null){l2.Parent=parentNode; }l2.NodeCss=this.NodeCss; l2.NodeCssOver=this.NodeCssOver; l2.NodeCssSelect=this.NodeCssSelect; l2.Text=O2[1]; l2.Value=O2[2]; l2.Category=O2[3]; if (o2 != null){l2.SignImage=o2[O2[4]].src; l2.SignImageExpanded=o2[O2[5]].src; }else {l2.SignImage=i0[O2[4]].src; l2.SignImageExpanded=i0[O2[5]].src; }if (O2[6]>0){l2.Image=o2[O2[6]].src; }if (O2[7]>0){l2.ImageExpanded=o2[O2[7]].src; }l2.Selected=O2[8]; if (l2.Selected){ this.SelectedNode=l2; }l2.Checked=O2[011]; l2.Enabled=O2[012]; l2.Expanded=O2[013]; l2.Action=O2[014]; if (this.IsSet(O2[015]))l2.NodeCss=O2[015]; if (this.IsSet(O2[016]))l2.ContextMenuName=O2[016]; this.AllNodes[this.AllNodes.length]=l2; if (l2.Parent != null){l2.Parent.Nodes[l2.Parent.Nodes.length]=l2; }else { this.Nodes[this.Nodes.length]=l2; }l2.Index=O2[020]; l2.DragEnabled=O2[022]; l2.DropEnabled=O2[023]; l2.ExpandOnServer=O2[024]; if (this.IsSet(O2[025]))l2.NodeCssOver=O2[025]; if (this.IsSet(O2[026]))l2.NodeCssSelect=O2[026]; l2.Level=O2[027]; l2.ID=O2[030]; l2.IsClientNode=O2[031]; l2.EditEnabled=O2[032]; l2.Attributes=O2[033]; } ; RadTreeView.prototype.Toggle= function (node){ this.FindNode(node).Toggle(); } ; RadTreeView.prototype.Select= function (node,e){ this.FindNode(node).Select(e); } ; RadTreeView.prototype.Hover= function (node){var node=this.FindNode(node); if (node)node.Hover(); } ; RadTreeView.prototype.UnHover= function (node){var node=this.FindNode(node); if (node)node.UnHover(); } ; RadTreeView.prototype.CheckBoxClick= function (node,e){ this.FindNode(node).CheckBoxClick(e); } ; RadTreeView.prototype.Highlight= function (node,e){ this.FindNode(node).Highlight(e); } ; RadTreeView.prototype.SelectNode= function (node){ this.SelectedNode=node; node.Selected= true; this.UpdateSelectedState(); } ; RadTreeView.prototype.GetSelectedNodes= function (){var I2=new Array(); for (var i=0; i<this.AllNodes.length; i++){if (this.AllNodes[i].Selected)I2[I2.length]=this.AllNodes[i]; }return I2; } ; RadTreeView.prototype.UnSelectAllNodes= function (node){for (var i=0; i<this.AllNodes.length; i++){if (this.AllNodes[i].Selected&&this.AllNodes[i].Enabled)this.AllNodes[i].UnSelect(); }} ; RadTreeView.prototype.KeyDownMozilla= function (e){var LastActiveRadTreeView=RadTreeView_Active; if (!LastActiveRadTreeView.l0)return; if (LastActiveRadTreeView != null&&LastActiveRadTreeView.SelectedNode != null){if (LastActiveRadTreeView.EditMode)return; if (e.keyCode == 0153||e.keyCode == 0155||e.keyCode == 045||e.keyCode == 047)LastActiveRadTreeView.SelectedNode.Toggle(); if (e.keyCode == 050&&LastActiveRadTreeView.SelectedNode.NextVisible() != null)LastActiveRadTreeView.SelectedNode.NextVisible().Highlight(e); if (e.keyCode == 046&&LastActiveRadTreeView.SelectedNode.PrevVisible() != null)LastActiveRadTreeView.SelectedNode.PrevVisible().Highlight(e); if (e.keyCode == 015)LastActiveRadTreeView.SelectedNode.ExecuteAction(); if (e.keyCode == 040)LastActiveRadTreeView.SelectedNode.CheckBoxClick(); if (e.keyCode == 0161&&LastActiveRadTreeView.AllowNodeEditing)LastActiveRadTreeView.SelectedNode.StartEdit(); }} ; RadTreeView.prototype.KeyDown= function (e){if (this.EditMode)return; var node=this.SelectedNode; if (node != null){if (e.keyCode == 0153||e.keyCode == 0155||e.keyCode == 045||e.keyCode == 047)node.Toggle(); if (e.keyCode == 050&&node.NextVisible() != null)node.NextVisible().Highlight(e); if (e.keyCode == 046&&node.PrevVisible() != null)node.PrevVisible().Highlight(e); if (e.keyCode == 015)node.ExecuteAction(e); if (e.keyCode == 040){node.CheckBoxClick(); (document.all)?e.returnValue= false :e.preventDefault(); }if (e.keyCode == 0161&&this.AllowNodeEditing){node.StartEdit(); }}else {if (e.keyCode == 046||e.keyCode == 050||e.keyCode == 015||e.keyCode == 040){ this.Nodes[0].Highlight(); }}} ; RadTreeView.prototype.UpdateExpandedState= function (){var o3=""; for (var i=0; i<this.AllNodes.length; i++){var O3=(this.AllNodes[i].Expanded)?"\x31": "\x30"; o3+=O3; }document.getElementById(this.ClientID+"\x5f\x65\x78\x70\x61\x6e\x64\x65\x64").value=o3; } ; RadTreeView.prototype.UpdateCheckedState= function (){var l3=""; for (var i=0; i<this.AllNodes.length; i++){var i3=(this.AllNodes[i].Checked)?"\x31": "\x30"; l3+=i3; }document.getElementById(this.ClientID+"\x5f\x63\x68\x65\x63\x6b\x65\x64").value=l3; } ; RadTreeView.prototype.UpdateSelectedState= function (){var I3=""; for (var i=0; i<this.AllNodes.length; i++){var o4=(this.AllNodes[i].Selected)?"\x31": "\x30"; I3+=o4; }document.getElementById(this.ClientID+"\x5f\x73\x65\x6c\x65\x63\x74\x65\x64").value=I3; } ; RadTreeView.prototype.Scroll= function (e){document.getElementById(this.ClientID+"\x5f\x73\x63\x72\x6f\x6c\x6c").value=document.getElementById(this.Container).scrollTop; } ; RadTreeView.prototype.ContextMenuClick= function (e,O4,l4,i4){H=this ; window.setTimeout( function (){H.HideContextMenu();} ,012); if (this.FireEvent(this.BeforeClientContextClick,this.O0,O4,i4) == false){return; }if (l4){var I4=this.O0.ClientID+"\x3a"+this.C(O4)+"\x3a"+this.C(i4); this.Q("\x43\x6f\x6e\x74\x65\x78\x74\x4d\x65\x6e\x75\x43\x6c\x69\x63\x6b",I4); }} ; RadTreeView.prototype.ContextMenu= function (e,o5){var src=(e.srcElement)?e.srcElement:e.target; var node=this.FindNode(o5); if (node != null&&this.BeforeClientContextMenu != null){var O5=this.SelectedNode; this.Highlight(o5,e,O5); if (this.FireEvent(this.BeforeClientContextMenu,node,e,O5) == false){return; }}if (node != null&&node.ContextMenuName != null&&node.Enabled){if (!this.ContextMenuVisible){ this.O0=node; if (!node.Selected){ this.Highlight(o5,e); } this.ShowContextMenu(node.ContextMenuName,e); document.all?e.returnValue= false :e.preventDefault(); }}} ; RadTreeView.prototype.ShowContextMenu= function (name,e){if (!document.readyState||document.readyState == "\x63\x6f\x6d\x70\x6c\x65\x74\x65"){var l5="\x72\x74\x76\x63\x6d"+this.ClientID+name; var menu=document.getElementById(l5); if (menu){var i5=menu.cloneNode( true); i5.id=l5+"\x5f\x63\x6c\x6f\x6e\x65"; document.body.appendChild(i5); i5=document.getElementById(l5+"\x5f\x63\x6c\x6f\x6e\x65"); i5.style.left=this.I5(e)+"\x70\x78"; i5.style.top=this.o6(e)+"\x70\x78"; i5.style.position="\x61\x62\x73\x6f\x6c\x75\x74\x65"; i5.style.display="\x62\x6c\x6f\x63\x6b"; this.ContextMenuVisible= true; this.ContextMenuName=name; document.all?e.returnValue= false :e.preventDefault(); }}} ; RadTreeView.prototype.o6= function (e){if (document.compatMode&&document.compatMode == "\x43\x53\x53\x31\x43\x6f\x6d\x70\x61\x74"){return (e.clientY+document.documentElement.scrollTop); }return (e.clientY+document.body.scrollTop); } ; RadTreeView.prototype.I5= function (e){if (document.compatMode&&document.compatMode == "\x43\x53\x53\x31\x43\x6f\x6d\x70\x61\x74"){return (e.clientX+document.documentElement.scrollLeft); }return (e.clientX+document.body.scrollLeft); } ; RadTreeView.prototype.HideContextMenu= function (){if (!document.readyState||document.readyState == "\x63\x6f\x6d\x70\x6c\x65\x74\x65"){var O6=document.getElementById("\x72\x74\x76\x63\x6d"+this.ClientID+this.ContextMenuName+"\x5f\x63\x6c\x6f\x6e\x65"); if (O6){document.body.removeChild(O6); } this.ContextMenuVisible= false; }} ; RadTreeView.prototype.MouseClickDispatcher= function (e){var src=(e.srcElement)?e.srcElement:e.target; var o5=rtvGetNodeID(e); if (o5 != null){var l6=this.FindNode(o5); if (l6.Selected){if (this.AllowNodeEditing){l6.StartEdit(); return; }else { this.Select(o5,e); }}else { this.Select(o5,e); }}if (src.tagName == "\x49\x4d\x47"){var i6=src.className; if (this.IsSet(i6)&&this.I6(i6)){ this.Toggle(src.parentNode.id); }}if (src.tagName == "\x49\x4e\x50\x55\x54"&&rtvInsideNode(src)){ this.CheckBoxClick(src.parentNode.id,e); }} ; RadTreeView.prototype.I6= function (o7){return (o7 == 1||o7 == 2||o7 == 5||o7 == 6||o7 == 7||o7 == 8||o7 == 012||o7 == 013); } ; RadTreeView.prototype.DoubleClickDispatcher= function (e,o5){ this.Toggle(o5); } ; RadTreeView.prototype.MouseOverDispatcher= function (e,o5){ this.Hover(o5); } ; RadTreeView.prototype.MouseOutDispatcher= function (e,o5){ this.UnHover(o5); } ; RadTreeView.prototype.MouseDown= function (e){if (this.LastHighlighted != null&&this.DragAndDrop){if (this.FireEvent(this.BeforeClientDrag,this.LastHighlighted) == false)return; if (!this.LastHighlighted.DragEnabled)return; if (e.button == 2)return; this.DragSource=this.LastHighlighted; this.DragClone=document.createElement("\x64\x69\x76"); document.body.appendChild(this.DragClone); RadTreeView_DragActive=this ; var O7=""; if (this.MultipleSelect&&(this.SelectedNodesCount()>1)){for (var i=0; i<this.AllNodes.length; i++){if (this.AllNodes[i].Selected){if (this.AllNodes[i].Image){var img=this.AllNodes[i].m(); var l7=img.cloneNode( true); this.DragClone.appendChild(l7); }var i7=this.AllNodes[i].TextElement().cloneNode( true); i7.className=this.AllNodes[i].NodeCss; i7.style.color="\x67\x72\x61\x79"; this.DragClone.appendChild(i7); this.DragClone.appendChild(document.createElement("\x42\x52")); }O7=O7+"\x74\x65\x78\x74"; }}if (O7 == ""){if (this.LastHighlighted.Image){var img=this.LastHighlighted.m(); var l7=img.cloneNode( true); this.DragClone.appendChild(l7); }var i7=this.LastHighlighted.TextElement().cloneNode( true); i7.className=this.LastHighlighted.NodeCss; i7.style.color="\x67\x72\x61\x79"; this.DragClone.appendChild(i7); } this.DragClone.style.position="\x61\x62\x73\x6f\x6c\x75\x74\x65"; this.DragClone.style.display="\x6e\x6f\x6e\x65"; (document.all)?e.returnValue= false :e.preventDefault(); }} ; RadTreeView.prototype.SelectedNodesCount= function (){var count=0; for (var i=0; i<this.AllNodes.length; i++){if (this.AllNodes[i].Selected)count++; }return count; } ; RadTreeView.prototype.FireEvent= function (I7,a,b,o8){if (!I7){return true; }RadTreeViewGlobalFirstParam=a; RadTreeViewGlobalSecondParam=b; RadTreeViewGlobalThirdParam=o8; var s=I7+"\x28\x52\x61\x64\x54\x72\x65\x65\x56\x69\x65\x77\x47\x6c\x6f\x62\x61\x6c\x46\x69\x72\x73\x74\x50\x61\x72\x61\x6d\x2c\x20\x52\x61\x64\x54\x72\x65\x65\x56\x69\x65\x77\x47\x6c\x6f\x62\x61\x6c\x53\x65\x63\x6f\x6e\x64\x50\x61\x72\x61\x6d\x2c\x20\x52\x61\x64\x54\x72\x65\x65\x56\x69\x65\x77\x47\x6c\x6f\x62\x61\x6c\x54\x68\x69\x72\x64\x50\x61\x72\x61\x6d\x29\x3b"; return eval(s); } ; RadTreeView.prototype.Focus= function (e){ this.FireEvent(this.AfterClientFocus,this ); } ; RadTreeView.prototype.IsSet= function (a){return (a != null&&a != ""); } ; RadTreeView.prototype.O8= function (l8){var i8=0; if (l8.offsetParent){while (l8.offsetParent){i8+=l8.offsetLeft; l8=l8.offsetParent; }}else if (l8.x)i8+=l8.x; return i8; } ; RadTreeView.prototype.I8= function (l8){var o9=0; if (l8.offsetParent){while (l8.offsetParent){o9+=l8.offsetTop; l8=l8.offsetParent; }}else if (l8.y)o9+=l8.y; return o9; } ; RadTreeView.prototype.Q= function (O9,d){var l9=O9+"\x23"+d; if (this.PostBackOptionsClientString){var i9=this.PostBackOptionsClientString.replace(/\x40\x40\x61\x72\x67\x75\x6d\x65\x6e\x74\x73\x40\x40/g,l9); if (typeof(WebForm_PostBackOptions) != "\x75\x6e\x64\x65\x66\x69\x6e\x65\x64"||i9.indexOf("\x5f\x64\x6f\x50\x6f\x73\x74\x42\x61\x63\x6b")>-1){eval(i9); }}else {if (this.CausesValidation){if (!(typeof(Page_ClientValidate) != "\x66\x75\x6e\x63\x74\x69\x6f\x6e"||Page_ClientValidate())){return; }}__doPostBack(this.UniqueID,l9); }} ; RadTreeView.prototype.C= function (param){var I9=param.replace(/\x27/g,"\x26\x73\x71\x75\x6f\x74\x65"); I9=I9.replace(/\x23/g,"\x26\x73\x73\x68\x61\x72\x70"); I9=I9.replace(/\x3a/g,"\x26\x73\x63\x6f\x6c\x6f\x6e"); I9=I9.replace(/\x5c/g,"\x5c\x5c"); return I9; } ; function rtvIsAnyContextMenuVisible(){for (var key in tlrkTreeViews)if ((typeof(tlrkTreeViews[key]) != "\x66\x75\x6e\x63\x74\x69\x6f\x6e")&&tlrkTreeViews[key].ContextMenuVisible)return true; return false; } ; function rtvMouseMove(e){if (rtvIsAnyContextMenuVisible()){return; }if (RadTreeView_DragActive != null&&RadTreeView_DragActive.DragClone != null){var oa,Oa; oa=RadTreeView_DragActive.I5(e)+8; Oa=RadTreeView_DragActive.o6(e)+4; RadTreeView_MouseY=Oa; rtvAdjustScroll(); RadTreeView_DragActive.DragClone.style.zIndex=01747; RadTreeView_DragActive.DragClone.style.top=Oa+"\x70\x78"; RadTreeView_DragActive.DragClone.style.left=oa+"\x70\x78"; RadTreeView_DragActive.DragClone.style.display="\x62\x6c\x6f\x63\x6b"; RadTreeView_DragActive.FireEvent(RadTreeView_DragActive.AfterClientMove,e); (document.all)?e.returnValue= false :e.preventDefault(); }} ; function rtvAdjustScroll(){if (RadTreeView_DragActive == null||RadTreeView_DragActive.DragClone == null){return; }var la=RadTreeView_Active; var ia=document.getElementById(RadTreeView_Active.Container); var Ia,ob; Ia=la.I8(ia); ob=Ia+ia.offsetHeight; if ((RadTreeView_MouseY-Ia)<062&&ia.scrollTop>0){ia.scrollTop=ia.scrollTop-012; la.Scroll(); RadTreeView_ScrollTimeout=window.setTimeout( function (){rtvAdjustScroll(); } ,0144); }else if ((ob-RadTreeView_MouseY)<062&&ia.scrollTop<(ia.scrollHeight-ia.offsetHeight+020)){ia.scrollTop=ia.scrollTop+012; la.Scroll(); RadTreeView_ScrollTimeout=window.setTimeout( function (){rtvAdjustScroll(); } ,0144); }} ; function rtvMouseUp(e){if (RadTreeView_Active == null)return; for (var key in tlrkTreeViews){if ((typeof(tlrkTreeViews[key]) != "\x66\x75\x6e\x63\x74\x69\x6f\x6e")&&tlrkTreeViews[key].ContextMenuVisible){contextMenuToBeHidden=tlrkTreeViews[key]; window.setTimeout("\x63\x6f\x6e\x74\x65\x78\x74\x4d\x65\x6e\x75\x54\x6f\x42\x65\x48\x69\x64\x64\x65\x6e\x2e\x48\x69\x64\x65\x43\x6f\x6e\x74\x65\x78\x74\x4d\x65\x6e\x75\x28\x29",012); return; }}if (RadTreeView_DragActive == null||RadTreeView_DragActive.DragClone == null){return; } (document.all)?e.returnValue= false :e.preventDefault(); var Ob=RadTreeView_DragActive.DragSource; var lb=RadTreeView_Active.LastHighlighted; var ib=RadTreeView_Active; document.body.removeChild(RadTreeView_DragActive.DragClone); RadTreeView_DragActive.DragClone=null; if (lb != null&&lb.DropEnabled == false)return; if (Ob == lb)return; if (RadTreeView_DragActive.FireEvent(RadTreeView_DragActive.BeforeClientDrop,Ob,lb,e) == false)return; if (Ob.IsClientNode||((lb != null)&&lb.IsClientNode))return; var Ib=RadTreeView_DragActive.ClientID+"\x23"+Ob.ClientID+"\x23"; var oc=""; if (lb == null){oc="\x6e\x75\x6c\x6c"+"\x23"+RadTreeView_DragActive.HtmlElementID; }else {oc=ib.ClientID+"\x23"+lb.ClientID; }if (lb == null&&RadTreeView_DragActive.HtmlElementID == ""){return; }RadTreeView_DragActive.Q("\x4e\x6f\x64\x65\x44\x72\x6f\x70",Ib+oc); RadTreeView_DragActive=null; } ; function rtvNodeExpand(a,id,Oc){var lc=document.getElementById(id); var ic=lc.scrollHeight; var Ic=(ic-a)/Oc; var height=a+Ic; if (height>ic-1){lc.style.height=""; lc.firstChild.style.position=""; }else {lc.style.height=height+"\x70\x78"; window.setTimeout("\x72\x74\x76\x4e\x6f\x64\x65\x45\x78\x70\x61\x6e\x64\x28"+height+"\x2c"+"\x27"+id+"\x27\x2c"+Oc+"\x29\x3b",5); }} ; function rtvNodeCollapse(a,id,Oc){var lc=document.getElementById(id); var ic=lc.scrollHeight; var Ic=(ic-Math.abs(ic-a))/Oc; var height=a-Ic; if (height<=3){lc.style.height=""; lc.style.display="\x6e\x6f\x6e\x65"; lc.firstChild.style.position=""; }else {lc.style.height=height+"\x70\x78"; window.setTimeout("\x72\x74\x76\x4e\x6f\x64\x65\x43\x6f\x6c\x6c\x61\x70\x73\x65\x28"+height+"\x2c"+"\x27"+id+"\x27\x2c"+Oc+"\x20\x29\x3b",5); }} ; function rtvGetNodeID(e){if (RadTreeView_Active == null)return; var target=(e.srcElement)?e.srcElement:e.target; if (target.tagName == "\x49\x4d\x47"&&target.nextSibling){var index=target.className; if (index){index=parseInt(index); if (index>014){target=target.nextSibling; }}}while (target != null){if ((target.tagName == "\x53\x50\x41\x4e"||target.tagName == "\x41")&&rtvInsideNode(target)){return target.parentNode.id; }target=target.parentNode; }return null; } ; function rtvInsideNode(od){if (od.parentNode&&od.parentNode.tagName == "\x44\x49\x56"&&od.parentNode.id.indexOf(RadTreeView_Active.ID)>-1){return od.parentNode.id; }} ; function rtvDispatcher(t,w,e,O4,l4,i4){if (!e){e=window.event; }if (tlrkTreeViews){var o5=rtvGetNodeID(e); var Od=tlrkTreeViews[t]; if (!Od.l0)return; if (rtvIsAnyContextMenuVisible()&&w != "\x6d\x63\x6c\x69\x63\x6b"&&w != "\x63\x63\x6c\x69\x63\x6b")return; if (Od.EditMode)return; RadTreeView_Active=Od; switch (w){case "\x6d\x6f\x76\x65\x72":if (o5 != null)Od.MouseOverDispatcher(e,o5); break; case "\x6d\x6f\x75\x74":if (o5 != null)Od.MouseOutDispatcher(e,o5); break; case "\x6d\x63\x6c\x69\x63\x6b":Od.MouseClickDispatcher(e); break; case "\x6d\x64\x63\x6c\x69\x63\x6b":if (o5 != null)Od.DoubleClickDispatcher(e,o5); break; case "\x6d\x64\x6f\x77\x6e":Od.MouseDown(e); break; case "\x6d\x75\x70":Od.ld(e); break; case "\x63\x6f\x6e\x74\x65\x78\x74":if (o5 != null){Od.ContextMenu(e,o5); return false; }break; case "\x63\x63\x6c\x69\x63\x6b":Od.ContextMenuClick(e,O4,l4,i4); break; case "\x73\x63\x72\x6f\x6c\x6c":Od.Scroll(e); break; case "\x66\x6f\x63\x75\x73":Od.Focus(e); case "\x6b\x65\x79\x64\x6f\x77\x6e":Od.KeyDown(e); }}} ; function rtvAppendStyleSheet(oe,Oe){var le=(navigator.appName == "\x4d\x69\x63\x72\x6f\x73\x6f\x66\x74\x20\x49\x6e\x74\x65\x72\x6e\x65\x74\x20\x45\x78\x70\x6c\x6f\x72\x65\x72")&&((navigator.userAgent.toLowerCase().indexOf("\x6d\x61\x63") != -1)||(navigator.appVersion.toLowerCase().indexOf("\x6d\x61\x63") != -1)); var ie=(navigator.userAgent.toLowerCase().indexOf("\x73\x61\x66\x61\x72\x69") != -1); if (le||ie){document.write("\x3c"+"\x6c\x69\x6e\x6b"+"\x20\x72\x65\x6c\x3d\x27\x73\x74\x79\x6c\x65\x73\x68\x65\x65\x74\x27\x20\x74\x79\x70\x65\x3d\x27\x74\x65\x78\x74\x2f\x63\x73\x73\x27\x20\x68\x72\x65\x66\x3d\x27"+Oe+"\x27\x3e"); }else {var Ie=document.createElement("\x4c\x49\x4e\x4b"); Ie.rel="\x73\x74\x79\x6c\x65\x73\x68\x65\x65\x74"; Ie.type="\x74\x65\x78\x74\x2f\x63\x73\x73"; Ie.href=Oe; document.getElementById(oe+"\x53\x74\x79\x6c\x65\x53\x68\x65\x65\x74\x48\x6f\x6c\x64\x65\x72").appendChild(Ie); }} ; function rtvInsertHTML(of,html){if (of.tagName == "\x41"){of=of.parentNode; }if (document.all){of.insertAdjacentHTML("\x62\x65\x66\x6f\x72\x65\x45\x6e\x64",html); }else {var r=of.ownerDocument.createRange(); r.setStartBefore(of); var Of=r.createContextualFragment(html); of.appendChild(Of); }} ;
