<%@ Page Language="C#" AutoEventWireup="true" CodeFile="systemHistor.aspx.cs" Inherits="admin_systemHistor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>历史记录</title>
<script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
<link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css" />
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
	<div id="header">系统的运行记录</div>
	<div id="content">
		 <table>
		 <tr class="tableHeader">
		 	<td>项目</td>
			<td>数目</td>
			<td>可执行的操作</td>
		 </tr>
		 
             <asp:Repeater ID="Repeater1" runat="server">
             <ItemTemplate> 
		 <tr>
		 	<td><%#Eval("aboutThisCount") %></td>
			<td><%#Eval("countNum")%></td>
			<td><a href='systemHistor.aspx?name=<%#Eval("countName") %>' onclick='return confirm("你确定要清零吗?清零后将不能恢复.");' >清零</a></td>
		 </tr>
		  </ItemTemplate>
             </asp:Repeater>
		 </table>
	</div>
</div>
<table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
</table>
    </form>
</body>
</html>
