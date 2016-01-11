<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="admin_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎页面</title>
<script type="text/javascript" src="Images/Alert/ymPrompt.js"></script>
<link rel="stylesheet" id='skin' type="text/css" href="Images/Alert/skin/qq/ymPrompt.css" />
    <script language="javascript" src="js/addTableEvent.js"></script>

    <link rel="stylesheet" type="text/css" href="style/mainFramePublicStyle.css">
    <style type="text/css">
    #form1 #aa *{
        font-size: 42px;
    }
    </style>
</head>
<body background="wallback/<%=theBG %>.jpg" style="font-size: 12px">
    <form id="form1" runat="server">
            <div class="huangyingTxt">
                <%=adminName %>
                你好！<br />
                &nbsp;<strong><span style="font-size: 24pt"> <span style="font-size: 16pt"><span
                    style="color: #336600">欢迎登陆</span><br />
                </span></span></strong><span style="font-size: 74pt" id="aa">&nbsp;<span style="font-family: 黑体">爱打字网用户中心</span><span><span style="font-family: 黑体"><span style="color: #006600">.<br />
                                    <br />
                                </span></span></span></span></div>
          
    </form>
</body>
</html>
