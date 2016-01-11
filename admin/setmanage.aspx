<%@ Page Language="C#" AutoEventWireup="true" CodeFile="setmanage.aspx.cs" Inherits="admin_setmanage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户管理</title>
<script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
<script language="javascript" type="text/javascript">
function checkNull(){
if(document.getElementById("password").value==""){
    alert("密码不能为空！");
    return false;
}
return true;
}

function Submit2_onclick() {
    if(document.getElementById("newUsername").value==""){
    alert("密码不能为空！");
    return false;
    }
    if(document.getElementById("newUserpass").value==""){
    alert("密码不能为空！");
    return false;
    }
    if(document.getElementById("newUserpass2").value==""){
    alert("密码不能为空！");
    return false;
    }
    return true;
}

</script>
<link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css" />
<style type="text/css">
<!--
.STYLE3 {font-size: 24px; font-weight: bold; }
-->
</style>
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
	<div id="header">用户管理</div>
	<div id="content">
		<table>
  <tr>
    <td colspan="2" align="center"><span class="STYLE3">密码修改</span></td>
    </tr>
  <tr>
    <td align="right"><label>用户名：</label></td>
    <td><asp:Literal ID="username" runat="server"></asp:Literal></td>
    </tr>
  <tr>
    <td align="right">密码：</td>
    <td><input type="password" id="password" name="textfield2" runat="server" /></td>
    </tr>
  <tr>
    <td align="right">密码确认：</td>
    <td><input type="password" id="password2" name="textfield" runat="server" /></td>
    </tr>
  <tr>
    <td colspan="2" align="center"><label>
      <input type="submit" name="Submit" value="确定修改" id="Submit1" onclick="return checkNull()" runat="server" onserverclick="Submit1_ServerClick" />
    </label></td>
    </tr>
</table>
<div id="alluserTable" runat="server" visible="false">
<table>
  <tr>
    <td colspan="4" align="center"><span class="STYLE3">所有的管理员
    </span></td>
    </tr>
  <tr>
    <td>用户名</td>
    <td>最后登陆时间</td>
	<td>登陆次数</td>
	<td><a href='delete.aspx?tablename=admin&count=all' title='删除' onclick="return confirm('你确定要删除全部管理员吗?删除后将不能恢复.');">删除</a></td>
  </tr>
    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
  <tr>
    <td><%#Eval("studentUsername")%></td>
    <td><%#Eval("lastLoinTime")%></td>
	<td><%#Eval("loginCount")%>次</td>
	<td>
	  <a href='delete.aspx?tablename=student&key=studentUsername&value=<%#Eval("studentUsername")%>' title='删除' onclick="return confirm('你确定要删除吗?删除后将不能恢复.');"><img src='../images/delete.gif' alt='删除' /></a>
    </td>
  </tr>
   </ItemTemplate>
    </asp:Repeater>
  <tr>
    <td>用户名：
      <label>
      <input name="textfield3" id="newUsername" type="text" size="20" runat="server" />
      </label></td>
    <td>密码：
      <label>
      <input name="textfield4" id="newUserpass" type="password" size="20" runat="server" />
      </label></td>
	<td>密码确认
	  <label>
	  <input name="textfield5"  id="newUserpass2" type="password" size="20" runat="server" />
	  </label></td>
	<td><input type="submit" name="Submit22" value="新增" id="Submit2" onclick="return Submit2_onclick()" onserverclick="Submit2_ServerClick" runat="server" /></td>
  </tr>
</table>
</div>
	</div>
</div>
<table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
</table>
    </form>
</body>
</html>
