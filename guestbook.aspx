<%@ Page Language="C#" AutoEventWireup="true" CodeFile="guestbook.aspx.cs" Inherits="guestbook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>留言本</title>
    <style type="text/css">
body{
	margin:0px;
	font-size:12px;
	text-align:center;
	background-image:url(images/typeface_bg.gif);
	color:#FFCC33;
}
a{
	color:#99CC00;
}
#containner{
	margin:auto;
	margin-top:10px;
	width:624px;
	height:auto;
	text-align:left;
	border:1px solid #FFCC66;
	display:block;
	overflow:hidden;
}
#header{
	width:100%;
	height:34px;
	line-height:34px;
	font-size:14px;
	font-weight:bold;
	background-color:#74010A;
	border-bottom:1px solid #FFCC66;
	color:#FFF;
	text-indent:24px;
	float:left;
}
#content{
	background-image:url(images/apoints_bg.jpg);
	width:594px;
	height:auto;
	padding:15px;
	text-align:center;
	display:block;
	background-color:#990000;
	float:left;
}
table,.pages{
	border:1px solid #FDA271;
	width:100%;
	height:auto;
	border-collapse:collapse;
	margin:auto;
	margin-top:2px;
	text-align:left;
	float:left;
	clear:both;
	display:block;
	overflow:hidden;
	background-image: url(images/typeface_bg22.gif);
}
table tr{
	border:1px solid #FDA271;
	height:auto;
	border-collapse:collapse;
}
table td{
	border:1px solid #FDA271;
	height:auto;
	border-collapse:collapse;
	text-align:left;
	text-indent:12px;
	font-size:14px;
	word-wrap: break-word;
	table-layout:fixed;
	display:block;
	width:100%;
	float:left
}
.tableheader{
	background-color:#F45804;
	color:#006600;
	background-image: url(images/typeface_bg4.gif);
}
.tablecontent{
background-color:#FDA271;
color:#A7430E;
background-image: url(images/typeface_bg22.gif);
font-size:16px;
}
.forip{
width:140px;
display:block;
float:left;
}
.addmessage{
background-image:url(images/userButton1.gif);
background-color:#CC0000;
color:#CC6600;
text-decoration:none;
width:92px;
height:23px;
display:block;
float:left;
line-height:23px;
font-size:14px;
text-align:center;
margin-left:450px;
margin-top:6px;
margin-bottom:auto;
}
.addmessage:hover{
background-image:url(images/userButton2.gif);
color:#33CC00;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="containner">
	<div id="header"><span style="float:left;">留言板</span><a href="sendMessage.aspx?messageType=guestbook" class="addmessage">我要留言</a></div>
	<div id="content">
<asp:Repeater ID="Repeater1" runat="server">
   <ItemTemplate>
<table>
  <tr class="tableheader">
    <td><%#Eval("sendStudentName")%>于<%#Eval("sendTime")%>的留言</td>
    <td><span class="forip">IP:<%#Eval("sendIP")%></span></td>
  </tr>
  <tr class="tablecontent">
    <td colspan="2">
	<%#Eval("messageBody")%>
	<hr />
	站长回复：<%#Eval("reBody")%>
	</td>
    </tr>
</table>
  </ItemTemplate>
</asp:Repeater>
	</div>
</div>
    </form>
</body>
</html>
