<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false"  CodeFile="affiche.aspx.cs" Inherits="admin_affiche" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>滚动公告</title>
<script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
<link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css" />
<script type="text/javascript" language="javascript">
    function addValue(type){
        var addStr="<"+"%"+"="+"typeOperation."+type+"%"+">";
        var mytext=document.getElementById("afficheBody");
        mytext.value=mytext.value+addStr;
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
	<div id="header">滚动公告设置</div>
	<div id="content">
	<table>
  <tr>
    <td>
    你可以把下列选项添加到首页公告中:
    <ul>
       <li><a href="#" onclick='addValue("topType(\"ChType\",10)");return false;'>中文打字前10名</a></li>
       <li><a href="#" onclick='addValue("topType(\"EnType\",10)");return false;'>英文打字前10名</a></li>
       <li><a href="#" onclick='addValue("topType(\"ChMatch\",10)");return false;'>中文打字比赛前10名</a></li>
       <li><a href="#" onclick='addValue("topType(\"EnMatch\",10)");return false;'>英文打字比赛前10名</a></li>
       <li><a href="#" onclick='addValue("topType(\"ChTrain\",10)");return false;'>中文打字练习前10名</a></li>
       <li><a href="#" onclick='addValue("topType(\"EnTrain\",10)");return false;'>英文打字练习前10名</a></li>
    </ul>
    </td>
    <td><label>
      <textarea name="textfield" id="afficheBody" cols="65" rows="20" runat="server"></textarea>
    </label></td>
  </tr>
  <tr>
    <td colspan="2" align="center"><label>
      <input type="submit" name="Submit" value="确定" id="Submit1" onserverclick="Submit1_ServerClick" runat="server" />
    </label></td>
    </tr>
</table>
	</div>
</div>
<table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
</table>
    </form>
</body>
</html>
