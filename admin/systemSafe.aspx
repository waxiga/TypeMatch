<%@ Page Language="C#" AutoEventWireup="true" CodeFile="systemSafe.aspx.cs" Inherits="admin_systemSafe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系统运行安全</title>
    <script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
    <link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="containner">
	<div id="header">系统探针</div>
	<div id="content">
        <table class="server_info">
<th class="header">系统管理</th>
  <tr><td style="color:green;font-size:20px;line-height:24px;">
&nbsp;&nbsp;&nbsp;&nbsp;<b style="color:Red;"><%= MemberName %></b>你好！&nbsp;欢迎你登陆“键指飞舞版打字比赛系统”后台管理中心。<br />
您是本系统的<b id="ifSuperAdmin" runat="server">超级</b>管理员，拥有<b id="B1" runat="server">最高的管理权限。</b>
  </td></tr>
</table>
<table class="server_info">
  <th colspan="2" class="header">服务器信息
  <tr class="aoshuhang">
    <td width="152" class="left">操作系统：</td>
    <td width="436" ><%= ServerOS %></td>
  </tr>
  <tr>
    <td class="left">CPU个数：</td>
    <td><%= CpuSum %></td>
  </tr>
  <tr class="aoshuhang">
    <td class="left">CPU类型：</td>
    <td><%= CpuType %></td>
  </tr>
  <tr>
    <td class="left">信息服务软件：</td>
    <td><%= ServerSoft %></td>
  </tr>
  <tr class="aoshuhang">
    <td class="left">服务器名：</td>
    <td><%= MachineName %></td>
  </tr>
  <tr>
    <td class="left">服务器域名：</td>
    <td><%= ServerName %></td>
  </tr>
  <tr class="aoshuhang">
    <td class="left">虚拟服务绝对路径：</td>
    <td><%= ServerPath %></td>
  </tr>
  <tr>
    <td class="left">DotNET&nbsp;版本：</td>
    <td><%= ServerNet %></td>
  </tr>
  <tr class="aoshuhang">
    <td class="left">执行1亿次加法运算耗时：</td>
    <td><%= ServerArea %></td>
  </tr>
  <tr>
    <td class="left">脚本超时时间：</td>
    <td><%= ServerTimeOut %></td>
  </tr>
  <tr class="aoshuhang">
    <td class="left">开机运行时长：</td>
    <td><%= ServerStart %></td>
  </tr>
  <tr>
    <td class="left">进程开始时间：</td>
    <td><%= PrStart %></td>
  </tr>
  <tr class="aoshuhang">
    <td class="left">AspNet&nbsp;内存占用：</td>
    <td><%= AspNetN %></td>
  </tr>
  <tr>
    <td class="left">AspNet&nbsp;CPU时间：</td>
    <td><%= AspNetCpu %></td>
  </tr>
  <tr class="aoshuhang">
    <td class="left">Session总数：</td>
    <td><%= ServerSessions %></td>
  </tr>
  <tr>
    <td class="left">Application总数：</td>
    <td><%= ServerApp %></td>
  </tr>
  <tr class="aoshuhang">
    <td class="left">应用程序缓存总数：</td>
    <td><%= ServerCache %></td>
  </tr>
  <tr>
    <td class="left">应用程序占用内存：</td>
    <td><%= ServerAppN %></td>
  </tr>
  <tr class="aoshuhang">
    <td class="left">FSO文本文件读写</td>
    <td><%= ServerFso %></td>
  </tr>
  <tr>
    <td class="left">本页执行时间：</td>
    <td><%= RunTime %></td>
  </tr>
</table>
    </div>
    </div>
    <table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
</table>
    </form>
</body>
</html>
