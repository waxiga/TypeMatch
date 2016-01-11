<%@ Page Language="C#" AutoEventWireup="true" CodeFile="topFrame.aspx.cs" Inherits="admin_topFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>键指飞舞版在线打字系统后台管理中心</title>
	<link rel="stylesheet" type="text/css" href="../style/fortopframe.css" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
    <div id="topBanner">
			<span id="logoTxt">键指飞舞版在线打字系统后台管理中心</span>
			
    </div>
	<div id="topNav">
		<div id="topbg">
			当前位置:<a href="../" target="_parent">首页</a>-->后台管理中心,欢迎你:<b style="color:#fff;"><asp:Literal ID="Literal1"
                runat="server"></asp:Literal></b>,为了系统的安全,请在完成工作后<a href="loginout.aspx" target="_parent">安全退出</a>.
		</div>
	</div>
    </div>
    </form>
</body>
</html>
