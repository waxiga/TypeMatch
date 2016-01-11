<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg.aspx.cs" Inherits="reg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户注册</title>
    <script type="text/javascript" language="javascript" src="ajax/checkUsernameEnable.js"></script>
<script type="text/javascript" language="javascript">
	<!--
	function checkIfNull(){
		if(document.form1.username.value==""){
			alert("用户名不能为空!");
			document.form1.username.focus();
			return false;
		}
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
		if(document.form1.studentName.value==""){
			alert("姓名不能为空!");
			document.form1.studentName.focus();
			return false;
		}
		if(document.form1.about.value.length>200){
			alert("备注不能超过200字!");
			document.form1.about.focus();
			return false;
		}
		if(document.form1.qq.value==""){
			alert("QQ不能为空!");
			document.form1.qq.focus();
			return false;
		}
		if(document.form1.qq.value.length>12){
			alert("QQ不能超过12位!");
			document.form1.qq.focus();
			return false;
		}
		if(document.form1.password.value!=document.form1.passwordagain.value){
			alert("两次输入的密码不一致，请检查!");
			document.form1.password.focus();
			return false;
		}
		return CheckEmail();
	}
	function CheckEmail(){ 
 var email =form1.mail.value; 
 var pattern = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/; 
 flag = pattern.test(email); 
 if(!flag){ 
  alert("email格式不正确!"); 
  form1.mail.focus(); 
  return false; 
 } 
 return (true); 
}
	// -->
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
	margin-top:20px;
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
	height:auto;
	padding:5px;
}
.baoming{
width:auto;
height:100%;
border-collapse:collapse;
text-align:left;
border:none;
}
.baoming td{
height:25px;
line-height:25px;
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
    <div id="containner">
	<div id="header">用户注册</div>
	<div id="content">
<form method="post" action="register.aspx" name="form1">
<table class="baoming" id="myform">
	<tr>
    <td class="baoming_left">用户名:</td>
    <td>
		<input name="username" type="text" onkeyup="checkEnable()" id="username" size="20" maxlength="20" /><span id="checkuser"></span>
		<label>(必填,只能由字母,数字下划线组成.)</label></td>
  </tr>
  <tr>
    <td class="baoming_left">密码:</td>
    <td>
		<input name="password" type="password" id="password" size="20" maxlength="20" />
		<label>(必填,且六位以上.)</label></td>
  </tr>
  <tr>
    <td class="baoming_left">确认密码:</td>
    <td>
		<input name="passwordagain" type="password" id="passwordagain" size="20" maxlength="20" />
		<label>(两次密码必须一致)</label></td>
  </tr>
  <tr>
    <td class="baoming_left">姓名:</td>
    <td>
		<input name="studentName" type="text" id="student_name" size="20" maxlength="20" />
		<label>(必填,请填写真实姓名.)</label></td>
  </tr>
  <tr>
    <td class="baoming_left">性别:</td>
    <td><p>
      <label>
        <input name="sex" type="radio" value="boy" checked="checked" />
        男</label>
      <label>
        <input type="radio" name="sex" value="gril" />
        女</label>
    </p></td>
  </tr>
  <tr>
    <td class="baoming_left">E_mail:</td>
    <td>
      <input name="mail" type="text" id="student_id" value="" size="20" maxlength="20" />
      <label>(必填)</label></td>
  </tr>
  
  <tr>
    <td class="baoming_left">QQ:</td>
    <td>
      <input  name="qq" type="text" onkeyup= "this.value=this.value.replace(/\D/g, ''); " size="20" maxlength="20" />
<label>(必填)</label></td>
  </tr>
  <tr>
    <td class="baoming_left">备注:</td>
    <td>
      <textarea name="about" cols="40" rows="4"></textarea>
<label>(可不填)</label></td>
  </tr>
  <tr>
      <td colspan="2" class="baoming_footer">
      	<input class="sumbitBtn" type="reset" value="重填"/>
      	<input class="sumbitBtn" type="submit" value="提交" onclick="return checkIfNull()"/></td>
    </tr>
</table>
</form>
	</div>
</div>
<script language="javascript" src="http://count20.51yes.com/click.aspx?id=205571862&logo=12"></script></body>
</html>
