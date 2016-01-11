<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sendMessage.aspx.cs" Inherits="sendMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <Script Language="JavaScript">
	<!--
	var name="";
	function checkIfNull(){
		var pare=document.getElementById("studentName");
		if(pare.getAttribute("value")==""){
			alert("姓名不能为空!");
			return false;
		}
		pare=document.getElementById("messageBody");
		if(pare.getAttribute("value")==""){
			alert("内容不能为空!");
			return false;
		}
		return true;
	}
	function checkIfSelect(obj){
		if(obj.checked=="checked" || obj.checked==true){
			name=form1.studentName.value;
			form1.studentName.value="匿名用户";
		}
		else{
			form1.studentName.value=name;
		}
	}
	// -->
</Script>
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
	width:380px;
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
	padding:5px;
}
#container table{
width:100%;
text-align:left;
border-collapse:collapse;
}
.studentname{
width:40px;
text-align:right;
display:block;
}
.messagebody{
width:310px;
height:80px;
}
</style>
   

</head>
<body>
    <form id="form1" name="form1"  method="post" action="">
    <div id="containner">
	<div id="header" runat="server">站&nbsp;&nbsp;&nbsp;&nbsp;长&nbsp;&nbsp;&nbsp;&nbsp;信&nbsp;&nbsp;&nbsp;&nbsp;箱</div>
	<div id="content">
	<div id="container">
		<table>
			<tr><td class="studentname">姓名:</td><td><label><input type="text" id="studentName" name="studentName" /><label>
			  <label>
			  <input name="checkbox" type="checkbox" onclick="checkIfSelect(this)" value="checkbox" />
			  匿名</label></td>
			</tr>
			<tr>
				<td class="studentname">内容:</td>
				<td><label><textarea class="messagebody" id="messageBody" name="messagebody"></textarea><label></td>
			</tr>
			<tr><td colspan="2" style="text-align:center;line-height:"><input type="reset" value="清 空" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="submit" value="发 送" onclick="return checkIfNull();" /><div style="display:block;width:100%;clear:both;float:left;"></div></td></tr>
		</table>
	</div>
	<input type="hidden" name="messagetype" id="messageType" value="admin" runat="server" />
	</div>
</div>
    </form>
    <div style="display:none;"><script language="javascript" src="http://count20.51yes.com/click.aspx?id=205571862&logo=12"></script></div>
</body>
</html>