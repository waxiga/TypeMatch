<%@ Page Language="C#" AutoEventWireup="true" CodeFile="databaseSafe.aspx.cs" Inherits="admin_databaseSafe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据库安全管理--数据库压缩，备份，还原</title>
    <script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
    <link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="containner">
	<div id="header">数据库管理（<strong>注意</strong>：下列这些操作如果你不熟悉请慎重使用！）</div>
	<div id="content">
    <table>
	    <tr><td><b>项目</b></td><td><b>说明</b></td><td><b>上次操作时间及其情况</b></td><td><b>参数设置</b></td><td><b>操作</b></td></tr>
	    
	    
	    <tr>
	        <td>备份数据库</td>
	        <td>
                为了系统的安全，建议定期备份数据库，并且尽量<br />
                不要修改备份数据库名，否则容易造成误操作。</td>
	        <td>
                <asp:Label ID="Label1" runat="server" Text="暂无操作" ForeColor="Red"></asp:Label></td>
	        <td>
                备份数据库名： &nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Width="113px" ValidationGroup="l1">backup.cs</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="此项不能为空" ControlToValidate="TextBox1" ValidationGroup="l1"></asp:RequiredFieldValidator></td>
             <td><asp:Button ID="Button1" runat="server" Text="备份" ValidationGroup="l1" OnClick="Button1_Click" /></td>
        </tr>
                
                
	    <tr><td>还原数据库</td><td>
            当数据库被损坏或不能使用时使用此功能。<br />
            但还原后，系统回到上次备份数据库时的状态，慎用。</td><td>
            <asp:Label ID="Label2" runat="server" Text="暂无操作" ForeColor="Red"></asp:Label></td><td>
            还原的数据库： &nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" Width="113px" ValidationGroup="l2">backup.cs</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="此项不能为空" ControlToValidate="TextBox2" ValidationGroup="l2"></asp:RequiredFieldValidator></td><td>
	    <asp:Button ID="Button2" runat="server" Text="还原" ValidationGroup="l2" OnClick="Button2_Click" />
	    </td></tr>
	    
	    
	    <tr><td>压缩数据库</td><td>
            定期压缩数据库可节省空间，加快运行速度，提高系统性能。<br />
            但在压缩前请先备份，以防出现不可预知的错误。</td><td>
            <asp:Label ID="Label3" runat="server" Text="暂无操作" ForeColor="Red"></asp:Label></td><td>
            被压缩的数据库：<asp:TextBox ID="TextBox3" runat="server" Width="113px" ReadOnly="True" ValidationGroup="l3">#typematch.mdb</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="此项不能为空" ControlToValidate="TextBox3"></asp:RequiredFieldValidator></td><td>
	    <asp:Button ID="Button3" runat="server" CausesValidation="False" OnClick="Button3_Click" Text="压缩" ValidationGroup="l3"/></td></tr>
	    
	    
	    <tr><td>删除备份</td><td>
            当空间不足或迫不得已时才执行此操作，<br />
            你也可以下载数据库到本地保存，不建议删除备份数据库。</td><td>
            <asp:Label ID="Label4" runat="server" Text="暂无操作" ForeColor="Red"></asp:Label></td><td>
            被删除的数据库：<asp:TextBox ID="TextBox4" runat="server" Width="113px" ValidationGroup="l4">backup.cs</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="此项不能为空" ControlToValidate="TextBox4"></asp:RequiredFieldValidator></td><td>
            <asp:Button ID="Button4" runat="server" Text="删除" OnClick="Button4_Click" ValidationGroup="l4" /></td></tr>
	    
	    
	    <tr><td colspan="5"><hr /></td></tr>
	    
	    
	    <tr><td>定时备份</td><td>
            在到达定时时间后，当有人访问时，就会备份，<br />
            并不一定就是在规定时间到达时立即备份。</td><td>
            <asp:Label ID="Label5" runat="server" Text="暂无操作" ForeColor="Red"></asp:Label></td><td>
            每隔<asp:TextBox ID="TextBox5" runat="server" Width="25px" ValidationGroup="l5">2</asp:TextBox>天备份一次<asp:RequiredFieldValidator
                ID="RequiredFieldValidator5" runat="server" ErrorMessage="此项不能为空" ControlToValidate="TextBox5" ValidationGroup="l5"></asp:RequiredFieldValidator></td><td>
            <asp:Button ID="Button11" runat="server" Text="设置" ValidationGroup="l5" OnClick="Button11_Click" />
            <asp:Button ID="Button12" runat="server" Text="取消" CausesValidation="False" Visible="False" OnClick="Button12_Click" /></td></tr>
	    
	    
	    <tr><td>
            还原定时</td><td>
            在到达定时时间后，当有人访问时，就会还原，<br />
            并不一定就是在规定时间到达时立即还原。</td><td>
            <asp:Label ID="Label6" runat="server" Text="暂无操作" ForeColor="Red"></asp:Label></td><td>
            每隔<asp:TextBox ID="TextBox6" runat="server" Width="25px" ValidationGroup="l6">2</asp:TextBox>天还原一次<asp:RequiredFieldValidator
                ID="RequiredFieldValidator6" runat="server" ErrorMessage="此项不能为空" ControlToValidate="TextBox6" ValidationGroup="l6"></asp:RequiredFieldValidator></td><td>
            <asp:Button ID="Button21" runat="server" Text="设置" ValidationGroup="l6" OnClick="Button21_Click" />
            <asp:Button ID="Button22" runat="server" Text="取消" CausesValidation="False" Visible="False" OnClick="Button22_Click" /></td></tr>
	    
	    
	    <tr><td>定时压缩</td><td>
            在到达定时时间后，当有人访问时，就会压缩，<br />
            并不一定就是在规定时间到达时立即压缩。</td><td>
            <asp:Label ID="Label7" runat="server" Text="暂无操作" ForeColor="Red"></asp:Label></td><td>
            每隔<asp:TextBox ID="TextBox7" runat="server" Width="25px" ValidationGroup="l7">2</asp:TextBox>天压缩一次<asp:RequiredFieldValidator
                ID="RequiredFieldValidator7" runat="server" ErrorMessage="此项不能为空" ControlToValidate="TextBox7" ValidationGroup="l7"></asp:RequiredFieldValidator></td><td>
            <asp:Button ID="Button31" runat="server" Text="设置" ValidationGroup="l7" OnClick="Button31_Click" />
            <asp:Button ID="Button32" runat="server" Text="取消" CausesValidation="False" Visible="False" OnClick="Button32_Click" /></td></tr>
	</table>   
    </div>
    </div>
    <table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
    </table>
    </form>
</body>
</html>
