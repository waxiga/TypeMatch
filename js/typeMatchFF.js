var usedTime=0;
var submitTime=180;//最少提交时间（秒）
var timer;
var timer1;
var timer2;
var textLength=0;
var i=0;
var text1="";
var text2="";
var wrong=0;
var right=0;
var averagespeed=0;
var cur="";
var totalTime=0;
var textBody;
var isIE=true;
window.onload=function(){
	text1=document.getElementById("articleCenter").innerHTML;
	if(!window.ActiveXObject){
	isIE=false;
	}
	document.form1.textfield.style.height=document.getElementById("articleCenter").offsetHeight;
	if(isIE){
	    clipboardData.setData("Text","typeMatch");
	    var aab= clipboardData.getData("Text");
	    if(aab!=""){
	    setInterval('clipboardData.setData(\'Text\',\'\')',100);//清空剪切板
	    alertFirstWindow();
	    }
	    else{
	    alert("对不起，为了使本系统能正常运行，如果你使用的是ＩＥ6浏览器，在弹出＂是否允许访问剪贴板＂时，请选择＂充许＂，否则系统无法计算你的打字速度．现在请你刷新本页，以重新选择．谢谢合作．");
	    }
	}
	else{
		document.getElementById("singleLine").style.display="none";
	    alert("你使用的不是IE浏览器,为了达到更好的打字效果,请使用IE浏览器.");
	    alertFirstWindow();
	}
}
function countDown(secs){
secs--;
document.getElementById("jump").innerHTML=secs;
if(secs>0) timer1=setTimeout("countDown("+secs+")",1000);
else
{closeFirstWindow();}
}
function alertFirstWindow(){
	textBody="<font style='font-size:14px;font-weight:bold;'>请准备好后点击确定，即开始计时。<a href='#' onclick='closeFirstWindow();return false;'>确定</a><br /></font>（友情提醒：如果不点击确定，10秒后自动开始。<span id='jump' style='color:#fff;font-size:30px;'>10</span>）<br /><br />";
	if(alertMinWindow(textBody)){
		countDown(10);
	}
	document.getElementById("closeBtn").onclick=function(){
		closeFirstWindow();
		return false;
	}
}
function alertMinWindow(textBody){
	var winBody=document.getElementById("alertWindowContent");
	var winContent="<div id='winBg'></div><div id='winBox' class='windowBgDiv1'><table class='window_table'><tr><td id='windHead'><a href='#' id='closeBtn' onclick='closeWindowThis();return false;'>关闭</a></td></tr><tr><td class='window_content' valign='middle'><br />"+textBody+"</td></tr></table></div>";
	winBody.innerHTML=winContent;
	return true;
}
function closeWindowThis(){
	document.getElementById("alertWindowContent").innerHTML="";
	if(isIE)document.getElementById("containner").style.marginTop="-4px";
}
function closeFirstWindow(){
	window.clearTimeout(timer1);
	closeWindowThis();
	totalTime=document.form1.totalTime.value*60;
	document.form1.textfield.focus();
	showTimeLeft(totalTime);
	checkWords();
}
function selectArt(){
	textBody=document.getElementById("artLilst").innerHTML;
	alertMinWindow(textBody);
}
function sumbitTypeData(){
	textBody="<p class='forSingline'>时间到。正在提交成绩...</p>";
	alertMinWindow(textBody);
}
function dataSaveOk(){
	document.form1.sumbitResult.disabled=true;
	textBody="<b style='font-size:16px;'><img src='images/true.gif' class='showwaitting_gif' />恭喜，成绩已经保存成功。</b><br />你本次的打字成绩如下：<br/><ul><li>打字速度:<b id='myspeed'></b>字/分</li><li>正确字数:<b id='myright'></b>个</li><li>错误字数:<b id='mywrong'></b>个</li><li>用时:<b id='myusetime'></b>秒</li></ul>";
	if(alertMinWindow(textBody)){
		document.getElementById("myspeed").innerHTML=averagespeed;
		document.getElementById("myright").innerHTML=right;
		document.getElementById("mywrong").innerHTML=wrong;
		document.getElementById("myusetime").innerHTML=usedTime;
	}
}
function returnError(){
	textBody="<p class='forSingline'><img src='images/timeout.gif' />数据保存失败，请<a href='#' onclick='submitSelectItem();return false;'>点击重试</a>.</p>";
	alertMinWindow(textBody);
}
function sumbitTimeOut(){
	textBody="<p class='forSingline'><img src='images/timeout.gif' />连接超时，请检查网络连接或<a href='#' onclick='submitSelectItem();return false;'>点击重试</a>.</p>";
	alertMinWindow(textBody);
}


function showTimeLeft(secs){
secs--;
curmin=Math.floor(secs/60);
cursec=Math.floor(secs-curmin*60);
document.getElementById("leftTime").innerHTML=curmin+"分"+cursec+"秒";
if(secs>0){
timer=setTimeout("showTimeLeft("+secs+")",1000);
usedTime=totalTime-secs;
averagespeed=Math.round(parseInt(document.form1.rightWords.value)/usedTime*60);
document.getElementById("typeSpeed").innerHTML=averagespeed;
if (usedTime<submitTime)
			{
				document.form1.sumbitResult.value='提交 '+(submitTime-usedTime);
				document.form1.sumbitResult.disabled=true;
			}
			else
			{
				document.form1.sumbitResult.value='提交';
				document.form1.sumbitResult.disabled=false;	
			}
}
else
{
window.clearTimeout(timer2);
document.form1.sumbitResult.value='提交';
document.form1.sumbitResult.disabled=false;
document.form1.textfield.blur();
submitSelectItem();
}
}
function checkWords(){
	text2=document.form1.textfield.value;
	if((text2.length-textLength)>5){
		window.clearTimeout(timer);
		window.clearTimeout(timer2);
		zuobi();
	}
	else{
	textLength=text2.length;
	wrong=0;
	right=0;
	cur="";
	for (i=0;i<text2.length;i++)
	{
		if (text2.substr(i,1)!=text1.substr(i,1)) 
		{
			wrong=wrong+1;
			cur=cur+"<label>"+text1.substr(i,1)+"</label>";
			} else {
			right=right+1;
			cur=cur+"<span>"+text1.substr(i,1)+"</span>";
		}
	}
	document.getElementById("articleCenter").innerHTML=cur+"<b>"+text1.substr(i,1)+"</b>"+text1.substr(i+1,text1.length);
	document.getElementById("rightCount").innerHTML=right;
	document.getElementById("wrongCount").innerHTML=wrong;
	document.form1.rightWords.value=right;
	document.form1.wrongWords.value=wrong;
	if (text2.length>=text1.length)
	{
		submitSelectItem();
		document.form1.textfield.blur();
		window.clearTimeout(timer);
	}else{
	timer2=window.setTimeout("checkWords()",100);
	}
	}
}
function keyPress()//屏蔽回车
{
     if (event.keyCode == 13)
     {
     event.keyCode=0;
     return false;
     }
}