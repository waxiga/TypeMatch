<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>首页--键指飞舞版在线打字比赛系统</title>
<META NAME="Keywords" CONTENT="高校打字比赛，打字比赛系统，清新视觉网络工作室，清新视觉，键指飞舞版打字比赛系统">
<META NAME="Description" CONTENT="清新视觉网络工作室，专注于开发更实用的大学生网络应用程序，为你量身打造各种大学生专用网站系统。">
<script type="text/javascript" language="JavaScript" src="js/x_open.js"></script>
<link rel="stylesheet" type="text/css" href="style/forindex.css" />
<script type="text/javascript" language="javascript">
function closeWindowThis(){
	document.getElementById("alertTable").style.display="none";
	document.getElementById("alertWindow_container").style.display="none";
}
function lookMessage(){
closeWindowThis();
x_open('查看站内信息','mymessage.aspx',711,516);
}
function TimeDemo(){
   var d;
   d = new Date();
   return(d.getMilliseconds());
}
function forFirefox(){
	 if(window.XMLHttpRequest){
	 var links=document.getElementsByTagName("a");
	 for(var i=0;i<links.length;i++){
			if(links[i].getAttribute("class")=="menu"){
				links[i].setAttribute("onclick","return true;");
			}
		}
	 }
}
function loginout(obj){
var t=TimeDemo();
var url="admin/loginout.aspx?t="+t;
document.getElementById("nologin").style.display="block";
document.getElementById(obj).style.display="none";
x_open('安全退出',url,300,120);
}
var outDiv,aaDiv,bbDiv;
window.onload=function(){
	var speed=100;
	outDiv=document.getElementById("affiche");
	aaDiv=document.getElementById("aa");
	bbDiv=document.getElementById("bb");
	bbDiv.innerHTML=aaDiv.innerHTML;
	var MyMar=setInterval(Marquee,speed);
	outDiv.onmouseover=function() {clearInterval(MyMar);}
	outDiv.onmouseout=function() {MyMar=setInterval(Marquee,speed);}
}
function Marquee(){
	var subResult=bbDiv.offsetHeight-outDiv.scrollTop;
	if(subResult<=0)
	outDiv.scrollTop=-subResult;
	else{
	outDiv.scrollTop++;
	}
}
</script>
</head>
<body>
    <form id="form1" runat="server">
<div id="alertWindow_container" runat="server" visible="false"></div>
<div class="windowBgDiv1" id="alertTable" runat="server" visible="false">
<table class="window_table">
  <tr>
    <td><a href="#" onclick="closeWindowThis();return false;">关闭</a></td>
  </tr>
  <tr>
    <td class="window_content" valign="middle"><br /><font style="font-size:14px;font-weight:bold;">你有<b id="messageCount" runat="server">1</b>条新消息，请点击<a href="mymessage.aspx" title="查看所有的站内信息"  class="menu" onclick="lookMessage();return false;">查看</a>或<a href="#" onclick="closeWindowThis();return false;">返回</a><br /></font>（友情提醒：如果你点击返回，随时可以点击右边的[<a href="mymessages" title="查看所有的站内信息"  class="menu" onclick="lookMessage();return false;">站内消息</a>]查看所有消息。）</td>
  </tr>
</table>
</div>
<div id="container">
	<div id="loginbtn">
		<div id="nologin" runat="server" style="display:none;">
			<a href="login.html">登陆</a>
			<a href="reg.aspx" title="用户注册" class="menu" onclick="x_open('用户注册','reg.aspx',600,520);return false;">注册</a>
		</div>
		<div id="isstudent" runat="server" style="display:none;">
			欢迎你回来:<b id="student_name" runat="server"></b><a href="myInfo.aspx" title="个人信息" class="menu" onclick="x_open('个人信息','myInfo.aspx',650,500);return false;">个人信息</a><a href="speedTop.aspx" title="速度排名" class="menu" onclick="x_open('速度排名','speedTop.aspx',650,500);return false;">速度排名:<b id="studentPaiming" runat="server">0</b></a>
			<a href="admin/loginout.aspx" title="安全退出" class="menu" onclick="loginout('isstudent');return false;">退出</a>
		</div>
		<div id="isadmin" runat="server" style="display:none;">
		欢迎你:<b id="real_name" runat="server"></b>,你是<asp:Literal ID="ifSuperAdmin" runat="server"></asp:Literal>管理员，<a href="admin/index.html">进入后台管理网站</a><a href="speedTop.aspx" title="速度排名" class="menu" onclick="x_open('速度排名','speedTop.aspx',650,500);return false;">速度排名:<b id="adminPaiming" runat="server">0</b></a>; 完成工作后，请点击<a href="admin/loginout.aspx" title="安全退出" class="menu" onclick="loginout('isadmin');return false;">退出</a>
		</div>
	</div>
  <div id="content">
			<div id="affiche"><br /><br /><br /><br />
				<div id="aa">
				<div id="afficheContent" class="contentcontent"><h2 style="color:#fff;font-weight:bold;">欢迎你使用本系统！</h2>
<p><font style="color:yellow;font-size:20px;font-weight:bold;">当前打字速度排行榜：</font><br />
<font style="color:yellow;font-size:14px;font-weight:bold;">中文打字前10名</font><%=typeOperation.topType("ChType",10)%><br /><font style="color:yellow;font-size:14px;font-weight:bold;">英文打字前10名</font><%=typeOperation.topType("EnType",10)%>
</p>
本系统由爱打字网倾情开发，功能完善，使用简便，安全稳定，运行速度快，是高校打字比赛的最佳解决方案。本系统具有反作弊功能，可以杜绝大多数的作弊行为，同时，本系统的后台管理十分方便，极大的减轻了管理员的工作量，如果你是第一次启动此系统，请在后台的“公告设置”中设置此处显示的公告信息。

本系统的几大亮点：页面采用DIV+CSS排版，浏览速度快！全面支持各种版本的浏览器。强大而实用的后台管理中心，使用更方便。页面设计精美，而且支持管理员与参赛者之间的互动，适合各大院校使用。专为高校打字比赛而设计，经过数百次打字比赛实际测试，安全稳定。<br />
				</div></div><div id="bb"></div>
			</div>
			<div id="cententPic"><img alt="键指飞舞" class="wu" src="images/wu.jpg" /></div>
			<div id="nav">
				<a href="totypematch.aspx?type=1" title="点击进入英文打字练习">英文练习</a>
				<a href="totypematch.aspx?type=2" title="点击进入五笔打字练习">五笔练习</a>
				<a href="totypematch.aspx?type=3" title="点击进入打字比赛">进入比赛</a>
				<a href="selectResult.aspx" title="查询你的历史成绩"  class="menu" onclick="x_open('打字成绩查询','selectResult.aspx',811,516);return false;">成绩查询</a>
				<a href="mymessage.aspx" title="查看所有的站内信息"  class="menu" onclick="x_open('查看站内信息','mymessage.aspx',711,516);return false;">站内信息</a>
				<a href="sendMessage.aspx" title="给站长信箱发送信息"  class="menu" onclick="x_open('给站长信箱发送信息。','sendMessage.aspx',440,276);return false;">站长信箱</a>
				<a href="guestbook.aspx" title="留言板"  class="menu" onclick="x_open('留言板','guestbook.aspx',674,550);return false;">我要留言</a>
				<a href="getTxt.aspx?key=howtoplay" title="关于本次比赛事项。"  class="menu" onclick="x_open('比赛说明','getTxt.aspx?key=howtoplay',674,340);return false;">比赛说明</a>
				<a href="getTxt.aspx?key=rolu" title="比赛规则"  class="menu" onclick="x_open('比赛规则','getTxt.aspx?key=rolu',674,500);return false;">比赛规则</a>
				<a href="getTxt.aspx?key=help" title="介绍如何使用本系统。"  class="menu" onclick="x_open('使用帮助','getTxt.aspx?key=help',674,340);return false;">使用帮助</a>
				<a href="Teach/index.html" title="打字教程">打字教程</a>
			</div>
	</div>
<div id="footer">意见建议,请点击<a href="sendMessage.aspx" title="给站长信箱发送信息"  class="menu" onclick="x_open('给站长信箱发送信息。','sendMessage.aspx',440,276);return false;">给站长发站内信</a>或者到<a href="guestbook.aspx" title="留言板"  class="menu" onclick="x_open('留言板','guestbook.aspx',674,550);return false;">留言板</a>留言<br />copyright:www.2dazi.com 2007--2008 <br />常用输入法<a href="getTxt.aspx?key=download" title="本系统的使用帮助。"  class="menu" onclick="x_open('使用帮助','getTxt.aspx?key=download',674,340);return false;">下载</a> </div></div></form><script src="http://s88.cnzz.com/stat.php?id=1573952&web_id=1573952" language="JavaScript" charset="gb2312"></script></body></html>