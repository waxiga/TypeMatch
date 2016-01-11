<%@ Page Language="C#" AutoEventWireup="true" CodeFile="typeMatch.aspx.cs" Inherits="typeMatch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>比赛页面--键指飞舞版在线打字比赛系统</title>
<link rel="stylesheet" type="text/css" href="style/fortypematch.css" />
<script type="text/javascript" language='javascript' src='js/typeMatch.js'></script>
<script type="text/javascript" language='javascript' src='ajax/sendTypeResult.js'></script>
</head>
<body onselectstart="return false">
<form id="form1" runat="server">
<div id="alertWindowContent"></div>
<div style="display:none;" id="artLilst">
<div class='forlist'>
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
<a href='totypematch.aspx?type=<%#Eval("newsType")%>&artID=<%#Eval("newsID")%>' target='_self'><%#Eval("title")%></a>
</ItemTemplate>
</asp:Repeater>
</div>
</div>
    
    
<div id="containner">
		<div id="header">
			<div id="header2">
			<div id="leftTime1">剩余时间:<b id="leftTime">0分0秒</b></div>
			<div>正确字数:<b id="rightCount">0</b></div>
			<div>错误字数:<b id="wrongCount">0</b></div>
			<div>平均速度:<b id="typeSpeed">0</b>字/分</div>
			<input name='sumbitResult' type='button' class='btn' id='sumbitResult' value='提交' onClick='submitSelectItem();return false;'/>
			<a href="#" onclick="selectArt();return false;" class="btn" id="selectArtBtn" runat="server">文章选择</a>
			<a href="typeMatchFF.aspx" class="btn" title="切换到多行对照方式">多行对照</a>
			<a href="default.aspx" class="btn">返回首页</a>
			</div>
		</div>
			<div id="articleTxt"><div id="articleCenter"><%=Session["artBody"]%></div>
		</div>
		</div>
		<div id="inputwords"><div contenteditable=true id="inputwordsContent" onKeyPress="keyPress()" onpaste="return false"></div>
</div>
<input name='totalTime' type='hidden' value='<%=Session["totalTime"] %>' />
<input name='usedTime' type='hidden' value=0 />
<input name='rightWords' type='hidden' value=0 />
<input name='wrongWords' type='hidden' value=0 />
    </form>
</body>
</html>