if(openHelp){
	var r
	if(window.event.srcElement.isTextEdit)
		{
			r=window.event.srcElement.createTextRange();
		}else{
			var el=window.event.srcElement.parentTextEdit;
			r=el.createTextRange();
		}

	r.moveToPoint(window.event.x-8, window.event.y);
	r.expand("word");
	var str = r.text;
	var locaX,locaY,widthZ
	if(str.length > 0 ) {
		locaX=event.offsetX
		locaY=event.offsetY;
		widthZ=document.body.clientWidth
		if(widthZ-locaX<120) locaX=widthZ-120;
		with(zoom_show.style) {
			display = "";
			left =locaX-20;
			top = locaY-30;			
		}
		z_py=trans(str);
		if (z_py!=str)
			{zuanhuan='\nƴ��:'+z_py+'\n���:'+trans_wb(str);}
		else
			{z_zimu=str.toUpperCase();
			if (z_zimu!=str)
				{zuanhuan='\n��д:'+z_zimu;}
			else
				{
					z_zimu_x=str.toLowerCase();
					if (z_zimu_x!=str)
						{zuanhuan='\nСд:'+z_zimu_x;}
					else{
						zuanhuan='';
					}					
			}
		}
		zoom_show.innerText =str+zuanhuan;
	} else {
		zoom_show.style.display = "none";
	}
}