var time_yong=0;
var time_tj=10;//设置几秒后才能提交180
function show_secs()
{
	time_zong=parseInt(document.form1.daziTime.value*60);
	if (time_zong==time_yong)
        {		
			document.form1.submit();
			alert('时间到！');
		 }else{
			time_yong++;
			time_yu=time_zong-time_yong;
			curmin=Math.floor(time_yu/60);
    		cursec=Math.floor(time_yu-curmin*60);
    		timeLeft="剩余时间:"+curmin+"分钟"+cursec+"秒";
    		shijian.innerText=timeLeft;			
			document.form1.time_yong.value=time_yong;
			sudu.innerText='速度:'+Math.round((parseInt(document.form1.zishu_dui.value)+parseInt(document.form1.zishu_cuo.value))/time_yong*600)/10+"字/分";
			
			if (time_yong<time_tj)
			{
				time_s=time_tj-time_yong;
				document.form1.sbt_tj.value='提交 '+time_s;
				document.form1.sbt_tj.disabled='disabled';
			}
			if (time_yong==time_tj)
			{
				document.form1.sbt_tj.value='提交';
				document.form1.sbt_tj.disabled='';	
			}
			window.setTimeout('show_secs()',1000);
		}
}

function checkduicuo()
{
	text1=showArticle.innerText;
	text2=inputwords.innerText;
	cuo=0;dui=0;xianshizi="";
	for (i=0;i<text2.length;i++)
	{
		xianshizi=xianshizi+"<span class="
		if (text2.substr(i,1)!=text1.substr(i,1)) 
		{
			cuo=cuo+1;
			xianshizi=xianshizi+"bg_c"
			} else {
			dui=dui+1;
			xianshizi=xianshizi+"bg_d"
		}
		xianshizi=xianshizi+">"+text1.substr(i,1)+"</span>";
	}
	showArticle.innerHTML=xianshizi+"<span class=redLine>"+text1.substr(i,1)+"</span>"+text1.substr(i+1,text1.length);
	//inputwords.innerHTML=xianshizi;
	words.innerText='正确字数:'+dui;
	wrong.innerText='错误字数:'+cuo;
	document.form1.zishu_dui.value=dui;
	document.form1.zishu_cuo.value=cuo;
	
	if (text1.length==text2.length) //是否打完
	{
		alert('已打完！');
		document.form1.submit();
	}
}

function MyKeyPress()//屏蔽回车键
{
     if (event.keyCode == 13)
     {
     event.keyCode=0;
     return false;
     }
}

function checks(){
	if (inputwords.innerText==""){
		alert ('你还没打字呢，不能提交哦！');
		document.getElementById("inputwords").focus();
		return false;	
	}			
	return true;
}