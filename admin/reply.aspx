<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reply.aspx.cs" Inherits="admin_reply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
<link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css"　/>
<style type="text/css">
.username{
background-color:transparent;
border-color:transparent;
border:0px;
cursor:text;
width:92%;
height:107%;
}
</style>
<script language="javascript" type="text/javascript">
function checkNull(){
    if(document.getElementById("TextBox1").value==""){
    alert("回复内容不能为空！");
    return false;
    }
    else{
        return true;
    }
}
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="containner">
            <div id="header">回复站内信息/留言</div>
            <div id="content">
                <asp:TextBox ID="TextBox1" style="display:block;clear:both;width:90%;" runat="server" Height="188px" TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="Button1" style="float:right;display:block;clear:both;" runat="server" Text="发送" OnClientClick="checkNull()" OnClick="Button1_Click" />
            </div>
        </div>
		<table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
</table>
    </form>
</body>
</html>
