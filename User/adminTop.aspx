<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminTop.aspx.cs" Inherits="admin_adminTop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>后台</title>
<style type="text/css">
body{
font-family:"宋体";
font-size:12px;
margin:0px;
}
#container{
width:100%;
float:left;
height:55px;
border-bottom:1px solid #93B352;
background-image:url(images/topBg.gif);
background-repeat:repeat-x;
display:block;
}
#contentLeft{
width:236px;
height:55px;
display:block;
overflow:hidden;
float:left;
background-image:url(images/topLeftBg.jpg);
background-repeat:no-repeat;
}
.adminName{
font-size:14px;
color:#45880C;
width:60px;
height:14px;
display:block;
position:relative;
left:39px;
top:34px;
font-family:"黑体";
}
#contentCenter{
float:left;
display:block;
width:400px;
height:55px;
}
#contentRight{
float:right;
display:block;
width:220px;
height:55px;
line-height:55px;
text-indent:20px;
background-image:url(images/datePic.jpg);
background-repeat:no-repeat;
background-position:left center;
color:#448509;
}
.btnRom{
width:400px;
height:30px;
display:block;
margin-top:18px;
margin-left:40px;
}
.btnRom a{
height:23px;
display:block;
float:left;
background-repeat:no-repeat;
text-decoration:none;
cursor:pointer;
}
.btn1{
width:50px;
background-image:url(images/btn1.gif);
}
.btn1:hover{
background-image:url(images/btn12.gif);
}
.btn2{
width:47px;
background-image:url(images/btn2.gif);
}
.btn2:hover{
background-image:url(images/btn22.gif);
}
.btn3{
width:50px;
background-image:url(images/btn3.gif);
}
.btn3:hover{
background-image:url(images/btn32.gif);
}
.btn4{
width:55px;
background-image:url(images/btn4.gif);
}
.btn4:hover{
background-image:url(images/btn42.gif);
}
.btn5{
width:104px;
margin-left:10px;
background-image:url(images/btn5.gif);
}
.btn5:hover{
background-image:url(images/btn52.gif);
}
.btn6{
width:58px;
background-image:url(images/btn6.gif);
}
.btn6:hover{
background-image:url(images/btn62.gif);
}
#divBtn{
width:50px;
height:50px;
display:block;
float:left;
margin-left:90px;
margin-top:-10px;
cursor:pointer;
}
</style>
<script language="javascript">
function btnDown(obj,i){
	obj.style.backgroundImage="url(images/btn"+i+"3.gif)";
}
function btnUp(obj,i){
	obj.style.backgroundImage="url(images/btn"+i+".gif)";
}
function btnOver(obj,i){
	obj.style.backgroundImage="url(images/btn"+i+"2.gif)";
}
function btnOut(obj,i){
	obj.style.backgroundImage="url(images/btn"+i+".gif)";
}
//取时间
window.onload=function(){
	setInterval("getDateTime()",1000);
}
function getDateTime(){
	var d, s = "日期: "; // 声明变量。 
	d = new Date(); // 创建 Date 对象。
	s +=d.getYear()+"年";
	s += (d.getMonth() + 1) + "月"; // 获取月份。 
	s += d.getDate() + "日&nbsp;&nbsp;"; // 获取日。 
	s +=d.getHours()+":<font color='#C38009'>";
	s +=d.getMinutes()+"</font>:<font color='#EB380F'>";
	s +=d.getSeconds()+"</font>"; ;     
	document.getElementById("contentRight").innerHTML=s;
}
</script>
<script language="javascript" type="text/javascript">
	var dishi;
	var maxValue=180;
	var minValue=1;
	var onORoff=true;
	var onORoff2=true;
	function Submit_onclick()
	{
	    var theall=window.top.document.getElementById("allFrame");
	    theall.rows="0,*,22";
	   
   }
   function Submit_onclick1()
	{
	    if(onORoff)
		{
	   onORoff=false;
	   setWidth();
	   }
   }
   function Submit_onclick2()
	{
	if(!onORoff)
		{
	    onORoff=true;
	    setWidth();
	    }
   }
function setWidth(){
	var theElement=window.top.document.getElementById("myFrame");
	if(onORoff){//打开
		minValue=minValue*3+10;
		var theStr=minValue+",*";
		theElement.cols=theStr;
		if(minValue<180){
		dishi=window.setTimeout("setWidth()",50);
		}
		else{
		 minValue=1;
		 window.clearTimeout(dishi);
		 theStr="180,*";
		 theElement.cols=theStr;
		}
	}
	else{//收缩
		maxValue=maxValue-30;
		var theStr=maxValue+",*";
		theElement.cols=theStr;
		if(maxValue>0){
		dishi=window.setTimeout("setWidth()",50);
		}
		else{
		 maxValue=180;
		 theStr="0,*";
		 theElement.cols=theStr;
		 window.clearTimeout(dishi);
		}
	}
}
document.onkeypress=function(){ 
    if(window.event.keyCode==96){
    var theall=window.top.document.getElementById("allFrame");
    var theElement=window.top.document.getElementById("myFrame");
    if(theall.rows!="56,*,22"){
	    theall.rows="56,*,22";
	    theElement.cols="180,*";
	}
	else{
	   theall.rows="0,*,0";
	    theElement.cols="0,*";
	  }
    }
} 
</script>
</head>

<body>
<div id="container">
	<div id="contentLeft">
		<font class="adminName"><%=adminName %></font>
		<div id="divBtn" onclick="Submit_onclick()"></div>
	</div>
	<div id="contentCenter">
		<span class="btnRom">
			<a href="main.aspx" target="mainFrame" onmouseover="btnOver(this,'1')" onmouseout="btnOut(this,'1')" onmousedown="btnDown(this,'1')" onmouseup="btnUp(this,'1')" class="btn1"></a>
			<a onmouseover="btnOver(this,'2')" onmouseout="btnOut(this,'2')" onmousedown="btnDown(this,'2')" onmouseup="btnUp(this,'2')" onclick="Submit_onclick1()" class="btn2"></a>
			<a onmouseover="btnOver(this,'3')" onmouseout="btnOut(this,'3')" onmousedown="btnDown(this,'3')" onmouseup="btnUp(this,'3')" onclick="Submit_onclick2()" class="btn3"></a>
			<a href="adminMain.html" target="_parent" onmouseover="btnOver(this,'4')" onmouseout="btnOut(this,'4')" onmousedown="btnDown(this,'4')" onmouseup="btnUp(this,'4')" class="btn4"></a>
			<a onmouseover="btnOver(this,'5')" onmouseout="btnOut(this,'5')" onmousedown="btnDown(this,'5')" onmouseup="btnUp(this,'5')" class="btn5" href="adminUserManage.aspx?user=<%=adminName %>" target="mainFrame"></a>
			<a href="admin_loginOut.aspx" target="_parent" onmouseover="btnOver(this,'6')" onmouseout="btnOut(this,'6')" onmousedown="btnDown(this,'6')" onmouseup="btnUp(this,'6')" class="btn6"></a>
		</span>
	</div>
	<div id="contentRight">
		日期:2009年2月&nbsp;&nbsp;星期四
	</div>
</div>
</body>
</html>