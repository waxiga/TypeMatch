<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mymessage.aspx.cs" Inherits="mymessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>站内信息</title>
<style type="text/css">
body{
	margin:0px;
	font-size:12px;
	text-align:center;
	background-image:url(images/typeface_bg.gif);
	color:#FFCC33;
}
#containner{
	margin:auto;
	margin-top:10px;
	width:620px;
	height:auto;
	text-align:left;
	border:1px solid #FFCC66;
	display:block;
}
#header{
	width:100%;
	height:34px;
	line-height:34px;
	font-size:14px;
	font-weight:bold;
	background-color:#6F0003;
	border-bottom:1px solid #FFCC66;
	color:#FFF;
	text-indent:24px;
	display:block;
}
#content{
	background-image:url(images/apoints_bg.jpg);
	width:100%;
	height:auto;
}
table{
width:100%;
height:auto;
text-align:left;
margin:auto;
border:1px solid #FFCC66;
border-collapse:collapse;
}
tr{
height:15px;
}
td{
height:15px;
border:1px solid #FFCC66;
border-collapse:collapse;
}
.tableHeader{
background-color:#FFF;
color:#000;
font-weight:bold;
}
a{
color:#2b8;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="containner">
	<div id="header"><b style="color:Green;"><%=Session["realName"]%></b>你好,你当前收到的所有信息如下:</div>
	<div id="content">
	<table>
  <tr class="tableHeader">
  	<td>状态</td>
    <td>发送者用户名</td>
    <td>发送者姓名</td>
	<td>信息类型</td>
    <td>信息详细内容</td>
    <td>发送时间</td>
    <td>是否已回复</td>
    <td>回复内容</td>
    <td><a href='deleteMessage.aspx?id=all' onclick='return confirm("你确定要删除全部站内信吗?");'>全部删除</a></td>
  </tr>
<asp:Repeater ID="Repeater1" runat="server">
   <ItemTemplate>
  <tr>
    <td><img src="images/news<%#Eval("ifNew")%>.gif" title="信息是否是新信息." /></td>
    <td><%#Eval("sendUerName")%></td>
    <td><%#Server.HtmlDecode(Eval("sendStudentName").ToString())%></td>
    <td><%#Eval("messageType")%></td>
    <td><%#Server.HtmlDecode(Eval("messageBody").ToString())%></td>
	<td><%#Eval("sendTime")%></td>
	<td><img alt="信息是否是新信息." src='images/news<%#Eval("ifHaveRe")%>.gif' title="信息是否是新信息." /></td>
    <td><%#Eval("reBody")%></td>
	<td><a href='deleteMessage.aspx?id=<%#Eval("messageID")%>' onclick='return confirm("你确定要删除这条信息吗?");'>删除</a></td>
  </tr>
  </ItemTemplate>
</asp:Repeater>
</table>

	</div>
</div>
    </form>
</body>
</html>
