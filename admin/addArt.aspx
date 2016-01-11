<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addArt.aspx.cs" Inherits="admin_addArt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加打字文章</title>
<script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
<link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css" />
<script type="text/javascript" language="javascript">
window.onload=function(){
checkWordCount();
}
function checkWordCount(){
var wordcount=document.getElementById("artBodyTf").value.length;
document.getElementById("words").innerHTML=wordcount;
document.getElementById("timeMinute").innerHTML=Math.round(wordcount/50);
window.setTimeout("checkWordCount()",500);
}
</script>
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
	<div id="header">添加打字文章</div>
	<div id="content">
	<table>
  <tr>
    <td>
      <p>
        <label>
          </label>
          &nbsp;<asp:HiddenField ID="artIdHidden" runat="server" />
      </p>
        <p>
            文章标题：<br /><label><asp:TextBox ID="artTitleTb" runat="server"></asp:TextBox></label>&nbsp;
         </p>
        <p>
            <label>
                文章类型：<asp:RadioButtonList ID="artTypeDbl" runat="server">
                    <asp:ListItem Selected="True" Value="1">英文打字练习</asp:ListItem>
                    <asp:ListItem Value="2">中文打字练习</asp:ListItem>
                    <asp:ListItem Value="3">中文打字比赛</asp:ListItem>
                    <asp:ListItem Value="4">英文打字比赛</asp:ListItem>
                </asp:RadioButtonList></label>
         </p>
      <p>
          打字时间：<asp:TextBox ID="totalTimeTb" runat="server" Width="39px"></asp:TextBox>分钟<br />
          文章共<b id="words">100</b>字，建议打字时间：<b id="timeMinute">100</b>分钟
      </p></td>
    <td><label>
      <textarea name="textfield" cols="75" rows="25" id="artBodyTf" runat="server"></textarea>
    </label></td>
  </tr>
  <tr>
    <td colspan="2" align="center"><label><input id="Reset1" type="reset" value="清空" />
        <asp:Button ID="Button1" style="margin-left:80px;" runat="server" Text="文章管理" OnClick="Button1_Click" />
      <input type="submit" style="margin-left:80px;"  name="Submit" value="确定" id="Submit1" onserverclick="Submit1_ServerClick" runat="server" />
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
