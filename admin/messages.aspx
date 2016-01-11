<%@ Page Language="C#" AutoEventWireup="true" CodeFile="messages.aspx.cs" Inherits="admin_messages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>站内信管理</title>
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
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
	<div id="header">所有的站内信息</div>
	<div id="content">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" DataKeyNames="messageID" DataSourceID="AccessDataSource1" EmptyDataText="<b style='color:#fff;margin-left:220px;'>暂无站内信</b>">
            <Columns>
                <asp:BoundField DataField="toUerID" HeaderText="接收者" SortExpression="toUerID" />
                <asp:BoundField DataField="sendStudentName" HeaderText="发送者姓名" SortExpression="sendStudentName" />
                <asp:BoundField DataField="sendUerName" HeaderText="发送者用户名" SortExpression="sendUerName" />
                <asp:BoundField DataField="messageType" HeaderText="信息类型" SortExpression="messageType" />
                <asp:BoundField DataField="messageBody" HeaderText="信息内容" SortExpression="messageBody" />
                <asp:CheckBoxField DataField="ifNew" HeaderText="是否新信息" SortExpression="ifNew" />
                <asp:BoundField DataField="sendTime" HeaderText="发送时间" SortExpression="sendTime" />
                <asp:BoundField DataField="sendIP" HeaderText="发送者ＩＰ" SortExpression="sendIP" />
                <asp:CheckBoxField DataField="ifHaveRe" HeaderText="是否已回复" SortExpression="ifHaveRe" />
                <asp:BoundField DataField="reBody" HeaderText="回复内容" SortExpression="reBody" />
                <asp:TemplateField HeaderText="<b style='color:#fff'>回复</b>">
                    <ItemTemplate>
                        <a title="回复" href='reply.aspx?id=<%# Eval("messageID") %>'><img src='../images/reply.gif' alt='回复' /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<a href='delete.aspx?tablename=message&count=all' onclick='return areYouSure()'><b style='color:#fff;'>删除</b></a>">
                    <ItemTemplate>
                        <a href='delete.aspx?tablename=message&key=messageID&value=<%# Eval("messageID") %>' onclick="return areYouSure()"><img src='../images/delete.gif' alt='删除' /></a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" ConflictDetection="CompareAllValues"
            DataFile="~/App_Data/#typematch.mdb" DeleteCommand="DELETE FROM [message] WHERE [messageID] = ? AND [toUerID] = ? AND [sendStudentName] = ? AND [sendUerName] = ? AND [messageType] = ? AND [messageBody] = ? AND [ifNew] = ? AND [sendTime] = ? AND [sendIP] = ? AND [ifHaveRe] = ? AND [reBody] = ?"
            InsertCommand="INSERT INTO [message] ([messageID], [toUerID], [sendStudentName], [sendUerName], [messageType], [messageBody], [ifNew], [sendTime], [sendIP], [ifHaveRe], [reBody]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [message] WHERE ([toUerID] <> ?) ORDER BY [ifNew] DESC, [sendTime] DESC"
            UpdateCommand="UPDATE [message] SET [toUerID] = ?, [sendStudentName] = ?, [sendUerName] = ?, [messageType] = ?, [messageBody] = ?, [ifNew] = ?, [sendTime] = ?, [sendIP] = ?, [ifHaveRe] = ?, [reBody] = ? WHERE [messageID] = ? AND [toUerID] = ? AND [sendStudentName] = ? AND [sendUerName] = ? AND [messageType] = ? AND [messageBody] = ? AND [ifNew] = ? AND [sendTime] = ? AND [sendIP] = ? AND [ifHaveRe] = ? AND [reBody] = ?">
            <DeleteParameters>
                <asp:Parameter Name="original_messageID" Type="Int32" />
                <asp:Parameter Name="original_toUerID" Type="String" />
                <asp:Parameter Name="original_sendStudentName" Type="String" />
                <asp:Parameter Name="original_sendUerName" Type="String" />
                <asp:Parameter Name="original_messageType" Type="String" />
                <asp:Parameter Name="original_messageBody" Type="String" />
                <asp:Parameter Name="original_ifNew" Type="Boolean" />
                <asp:Parameter Name="original_sendTime" Type="DateTime" />
                <asp:Parameter Name="original_sendIP" Type="String" />
                <asp:Parameter Name="original_ifHaveRe" Type="Boolean" />
                <asp:Parameter Name="original_reBody" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="toUerID" Type="String" />
                <asp:Parameter Name="sendStudentName" Type="String" />
                <asp:Parameter Name="sendUerName" Type="String" />
                <asp:Parameter Name="messageType" Type="String" />
                <asp:Parameter Name="messageBody" Type="String" />
                <asp:Parameter Name="ifNew" Type="Boolean" />
                <asp:Parameter Name="sendTime" Type="DateTime" />
                <asp:Parameter Name="sendIP" Type="String" />
                <asp:Parameter Name="ifHaveRe" Type="Boolean" />
                <asp:Parameter Name="reBody" Type="String" />
                <asp:Parameter Name="original_messageID" Type="Int32" />
                <asp:Parameter Name="original_toUerID" Type="String" />
                <asp:Parameter Name="original_sendStudentName" Type="String" />
                <asp:Parameter Name="original_sendUerName" Type="String" />
                <asp:Parameter Name="original_messageType" Type="String" />
                <asp:Parameter Name="original_messageBody" Type="String" />
                <asp:Parameter Name="original_ifNew" Type="Boolean" />
                <asp:Parameter Name="original_sendTime" Type="DateTime" />
                <asp:Parameter Name="original_sendIP" Type="String" />
                <asp:Parameter Name="original_ifHaveRe" Type="Boolean" />
                <asp:Parameter Name="original_reBody" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="messageID" Type="Int32" />
                <asp:Parameter Name="toUerID" Type="String" />
                <asp:Parameter Name="sendStudentName" Type="String" />
                <asp:Parameter Name="sendUerName" Type="String" />
                <asp:Parameter Name="messageType" Type="String" />
                <asp:Parameter Name="messageBody" Type="String" />
                <asp:Parameter Name="ifNew" Type="Boolean" />
                <asp:Parameter Name="sendTime" Type="DateTime" />
                <asp:Parameter Name="sendIP" Type="String" />
                <asp:Parameter Name="ifHaveRe" Type="Boolean" />
                <asp:Parameter Name="reBody" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="guestbook" Name="toUerID" Type="String" />
            </SelectParameters>
        </asp:AccessDataSource>
	
</div>
</div>
<table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
</table>
    </form>
</body>
</html>
