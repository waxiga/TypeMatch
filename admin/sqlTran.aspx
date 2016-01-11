<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sqlTran.aspx.cs" Inherits="admin_sqlTran" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>执行ＳＱＬ语句</title>
    <script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
    <link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="containner">
	<div id="header">执行ＳＱＬ语句</div>
	<div id="content">
	    <table>
	    <tr><td><asp:TextBox ID="TextBox1" runat="server" Height="179px" TextMode="MultiLine" Width="600px" ReadOnly="True"></asp:TextBox></td></tr>
	    <tr><td><asp:TextBox ID="TextBox2" runat="server" Height="99px" TextMode="MultiLine" Width="600px"></asp:TextBox></td></tr>
	    <tr><td>
	        <asp:CheckBox ID="CheckBox1" runat="server" Text="自定数据库" />
	        <asp:TextBox ID="TextBox3" runat="server" Width="293px"></asp:TextBox>
	        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" />
	        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="执行" />
	    </td></tr>
	    <tr><td><asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                ErrorMessage="查询语句不能为空"></asp:RequiredFieldValidator></td></tr>
	    </table>
	    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="447px">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#E3EAEB" />
            <EditRowStyle BackColor="#7C6F57" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
	</div>
	</div>
	<table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
    </table>
    </form>
</body>
</html>
