<%@ Page Language="C#" AutoEventWireup="true" CodeFile="getTxt.aspx.cs" Inherits="getTxt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title id="headertitle" runat="server"></title>
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
	margin-top:20px;
	width:624px;
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
	background-color:#74010A;
	border-bottom:1px solid #FFCC66;
	color:#FFF;
	text-indent:24px;
}
#content{
	background-image:url(images/apoints_bg.jpg);
	width:auto;
	height:auto;
	padding:15px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
   <ItemTemplate>
    <div id="containner">
	<div id="header"><%#Eval("title")%></div>
	<div id="content">
		  <%#Eval("value")%>
		  <div  style="width:100%;display:block;clear:both;margin-top:30px;"> <p align="right">清新视觉网络工作室<br/>
		  2008年9月</p></div>
	</div>
</div>
  </ItemTemplate>
</asp:Repeater>
    </form>
</body>
</html>
