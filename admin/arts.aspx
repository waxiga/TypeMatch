<%@ Page Language="C#" AutoEventWireup="true" CodeFile="arts.aspx.cs" Inherits="admin_arts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>打字文章管理</title>
<script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
<link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css" />
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
	<div id="header" style="text-align:center;">
	打字文章管理&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="1">英文打字练习</asp:ListItem>
            <asp:ListItem Value="2">中文打字练习</asp:ListItem>
            <asp:ListItem Value="4">英文打字比赛</asp:ListItem>
            <asp:ListItem Value="3">中文打字比赛</asp:ListItem>
        </asp:DropDownList>
        <a href="addArt.aspx" style="margin-left:50px;font-weight:bold;color:#fff;" title="添加文章">添加文章</a>
        </div>
	<div id="content">
<table id="studentInfoTable">
  <tr>
  	<td>ID</td>
    <td>添加者</td>
    <td>标题</td>
    <td>打字时间</td>
    <td>内容   (把鼠标定在表格内即可显示文章全文)</td>
    <td>添加时间</td>
	<td>点击</td>
	<td>修改</td>
	<td><a href='delete.aspx?tablename=news&count=all' title='删除' onclick="return confirm('你确定要删除全部文章吗?删除后将不能恢复.');">删除</a></td>
    </tr>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal></table>
	</div>
</div>
<table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
</table>
    </form>
</body>
</html>
