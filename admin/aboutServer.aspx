<%@ Page Language="C#" AutoEventWireup="true" CodeFile="aboutServer.aspx.cs" Inherits="admin_aboutServer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系统运行安全记录</title>
    <script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
    <link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css"　/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="containner">
	<div id="header">系统运行记录</div>
	<div id="content">
	<table>
            <tr><td>事件ID</td><td>事件详细说明</td><td>事件发生时间</td>
            <td><a href='delete.aspx?tablename=systemRecord&count=all' onclick='return areYouSure()'><b style='color:#fff;'>全部删除</b></a></td>
            </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
            <tr>
            <td><%#Eval("recordId")%></td>
            <td><%#Eval("recordContent")%></td>
            <td><%#Eval("recordTime")%></td>
            <td>
                <a href='delete.aspx?tablename=systemRecord&key=recordId&value=<%# Eval("recordId") %>' onclick="return areYouSure()"><img src='../images/delete.gif' alt='删除' /></a></td>
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