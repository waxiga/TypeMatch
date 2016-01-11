<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"  CodeFile="setDownLoad.aspx.cs" Inherits="admin_setDownLoad" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>管理下载/比赛规则/比赛说明/比赛帮助设置</title>
<script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
<link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css" />
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
    <asp:HiddenField ID="HiddenField1" runat="server" />
	<div id="header"><asp:Label ID="Label1" runat="server" Text="管理下载"></asp:Label>(请在下面的输入框中输入HTML代码页面内容)</div>
	<div id="content">
	<table>
  <tr>
    <td>
      <label>
      <textarea name="textfield" cols="100" rows="22" id="TEXTAREA1" runat="server"></textarea>
      </label></td>
    </tr>
	<tr>
    <td>
      文件上传&nbsp;
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="上传" OnClick="Button1_Click" />(不能上传EXE文件)<asp:Literal
            ID="Literal1" runat="server"></asp:Literal><br />
        <div id="filepath" runat="server" visible="false">文件地址<asp:TextBox ID="TextBox1" runat="server" Width="389px"></asp:TextBox></div></td>
    </tr>
  <tr>
    <td align="center"><label>
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
