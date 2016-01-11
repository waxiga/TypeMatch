<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myInfo.aspx.cs" Inherits="myInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>个人信息维护</title>
<script type="text/javascript" language="javascript" src="js/md5.js"></script>
<script type="text/javascript" language="JavaScript">
	function checkIfNull(){
	if(document.getElementById("password").value!=document.getElementById("passwordagain").value){
			alert("两次输入的密码不一致，请检查!");
			document.form1.password.focus();
			return false;
		}
		document.getElementById("password").value=hex_md5(document.getElementById("password").value)
		return true;
		if(document.form1.password.value==""){
			alert("密码不能为空!");
			document.form1.password.focus();
			return false;
		}
		if(document.form1.password.value.length<6){
			alert("密码长度不能少于6位!");
			document.form1.password.focus();
			return false;
		}
		if(document.getElementById("student_name").value==""){
			alert("姓名不能为空!");
			document.form1.studentName.focus();
			return false;
		}
		if(document.form1.about.value.length>200){
			alert("备注不能超过200字!");
			document.form1.about.focus();
			return false;
		}
		if(document.form1.qq.value.length>12){
			alert("QQ不能超过12位!");
			document.form1.qq.focus();
			return false;
		}
		return true;
	}
</script>
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
	width:520px;
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
	width:auto;
	padding:5px;
	padding-bottom:0px;
}
.baoming{
width:auto;
height:100%;
border-collapse:collapse;
text-align:left;
border:none;
display:block;
}
.baoming td{
height:20px;
line-height:20px;
border:none;
}
.baoming tr{
text-align:left;
}
.baoming_left{
text-align:right;
display:block;
width:90px;
font-weight:bold;
}
.baoming label{
font-size:12px;
}
.baoming .baoming_footer{
text-align:center;
}
.sumbitBtn{
width:60px;
height:25px;
text-align:center;
margin:auto;
margin-right:25px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
	<div id="header">以下是你的注册信息，请核对。</div>
	<div id="content">
<table class="baoming" id="myform">
	<tr>
    <td class="baoming_left">用户名:</td>
    <td><b><asp:Literal ID="userName" runat="server"></asp:Literal></b></td>
  </tr>
  <tr>
    <td class="baoming_left">密码:</td>
    <td>
		<input type="password" id="password" name="password" runat="server" />
		<label>(必填,且六位以上.)</label></td>
  </tr>
  <tr>
    <td class="baoming_left">确认密码:</td>
    <td>
		<input type="password" id="passwordagain" name="passwordagain" />
		<label>(两次密码必须一致)</label></td>
  </tr>
  <tr>
    <td class="baoming_left">姓名:</td>
    <td>
		<input type="text" id="student_name" runat="server" name="studentName" />
		<label>(必填,请填写真实姓名.)</label></td>
  </tr>
  <tr>
    <td class="baoming_left">QQ:</td>
    <td>
      <input type="text" runat="server" id="qq" onkeyup= "this.value=this.value.replace(/\D/g, ''); "  name="qq" />
<label>(可不填)</label></td>
  </tr>
  <tr>
    <td class="baoming_left">备注:</td>
    <td>
      <textarea name="about" runat="server" id="about"  cols="40" rows="4"></textarea>
<label>(可不填)</label></td>
  </tr>
  <tr>
      <td colspan="2" class="baoming_footer">
      	<input class="sumbitBtn" type="reset" value="重填"/>
      	<input class="sumbitBtn" runat="server"  type="submit" name="subBtn" value="修改" onclick="return checkIfNull()" id="Submit1" onserverclick="Submit1_ServerClick"/></td>
    </tr>
</table>
	</div>
	<div style="display:block;width:100%;height:1px;"></div>
    </div>
    </form>
</body>
</html>
