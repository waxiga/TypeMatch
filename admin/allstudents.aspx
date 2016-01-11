<%@ Page Language="C#" AutoEventWireup="true" CodeFile="allstudents.aspx.cs" Inherits="admin_allstudents" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>所有学生的报名信息</title>
<script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
<link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css">
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
	<div id="header">所有学生的报名情况(共<b id="personcount">0</b>人)</div>
	<div id="content">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" DataKeyNames="studentUsername" DataSourceID="AccessDataSource1" EmptyDataText="暂无学生注册">
            <Columns>
                <asp:BoundField DataField="studentUsername" HeaderText="用户名" ReadOnly="True" SortExpression="studentUsername" />
                <asp:BoundField DataField="studentName" HeaderText="学生姓名" SortExpression="studentName" />
                <asp:BoundField DataField="studentID" HeaderText="学号" SortExpression="studentID" />
                <asp:CheckBoxField DataField="studentSex" HeaderText="性别(男)" SortExpression="studentSex" />
                <asp:BoundField DataField="studentDepartment" HeaderText="系别" SortExpression="studentDepartment" />
                <asp:BoundField DataField="studentGrade" HeaderText="年级" SortExpression="studentGrade" />
                <asp:BoundField DataField="studentClass" HeaderText="班别" SortExpression="studentClass" />
                <asp:BoundField DataField="studentTel" HeaderText="电话" SortExpression="studentTel" />
                <asp:BoundField DataField="studentQQ" HeaderText="ＱＱ" SortExpression="studentQQ" />
                <asp:BoundField DataField="studentAbout" HeaderText="备注" SortExpression="studentAbout" />
                <asp:BoundField DataField="loginCount" HeaderText="登陆次数" SortExpression="loginCount" />
                <asp:BoundField DataField="mathchEnCount" HeaderText="英文打字比赛次数" SortExpression="mathchEnCount" />
                <asp:BoundField DataField="mathchChCount" HeaderText="中文打字比赛次数" SortExpression="mathchChCount" />
                <asp:BoundField DataField="trainEnCount" HeaderText="英文打字练习次数" SortExpression="trainEnCount" />
                <asp:BoundField DataField="trainChCount" HeaderText="中文打字练习次数" SortExpression="trainChCount" />
                <asp:BoundField DataField="registerTime" HeaderText="注册时间" SortExpression="registerTime" />
                <asp:BoundField DataField="lastLoinTime" HeaderText="最后登陆时间" SortExpression="lastLoinTime" />
                <asp:BoundField DataField="lastTypeTime" HeaderText="最后一次打字时间" SortExpression="lastTypeTime" />
                <asp:BoundField DataField="registerIP" HeaderText="注册ＩＰ" SortExpression="registerIP" />
                <asp:BoundField DataField="lastLoinIP" HeaderText="上次登陆ＩＰ" SortExpression="lastLoinIP" />
                <asp:BoundField DataField="lastTypeIP" HeaderText="上次打字ＩＰ" SortExpression="lastTypeIP" />
                <asp:TemplateField HeaderText="<a href='delete.aspx?tablename=student&count=all' onclick='return areYouSure()'><b style='color:#fff;'>删除</b></a>">
                    <ItemTemplate>
                      <a href='delete.aspx?tablename=student&key=studentUsername&value=<%# Eval("studentUsername") %>' onclick="return areYouSure()"><img src='../images/delete.gif' alt='删除' /></a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" ConflictDetection="CompareAllValues"
            DataFile="~/App_Data/#typematch.mdb" DeleteCommand="DELETE FROM [student] WHERE [studentUsername] = ? AND [studentPassword] = ? AND [roleType] = ? AND [studentName] = ? AND [studentID] = ? AND [studentSex] = ? AND [studentDepartment] = ? AND [studentGrade] = ? AND [studentClass] = ? AND [studentTel] = ? AND [studentQQ] = ? AND [studentAbout] = ? AND [loginCount] = ? AND [mathchEnCount] = ? AND [mathchChCount] = ? AND [trainEnCount] = ? AND [trainChCount] = ? AND [registerTime] = ? AND [lastLoinTime] = ? AND [lastTypeTime] = ? AND [registerIP] = ? AND [lastLoinIP] = ? AND [lastTypeIP] = ?"
            InsertCommand="INSERT INTO [student] ([studentUsername], [studentPassword], [roleType], [studentName], [studentID], [studentSex], [studentDepartment], [studentGrade], [studentClass], [studentTel], [studentQQ], [studentAbout], [loginCount], [mathchEnCount], [mathchChCount], [trainEnCount], [trainChCount], [registerTime], [lastLoinTime], [lastTypeTime], [registerIP], [lastLoinIP], [lastTypeIP]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [student] WHERE ([roleType] = ?) ORDER BY [registerTime] DESC, [lastTypeTime] DESC, [studentID]"
            UpdateCommand="UPDATE [student] SET [studentPassword] = ?, [roleType] = ?, [studentName] = ?, [studentID] = ?, [studentSex] = ?, [studentDepartment] = ?, [studentGrade] = ?, [studentClass] = ?, [studentTel] = ?, [studentQQ] = ?, [studentAbout] = ?, [loginCount] = ?, [mathchEnCount] = ?, [mathchChCount] = ?, [trainEnCount] = ?, [trainChCount] = ?, [registerTime] = ?, [lastLoinTime] = ?, [lastTypeTime] = ?, [registerIP] = ?, [lastLoinIP] = ?, [lastTypeIP] = ? WHERE [studentUsername] = ? AND [studentPassword] = ? AND [roleType] = ? AND [studentName] = ? AND [studentID] = ? AND [studentSex] = ? AND [studentDepartment] = ? AND [studentGrade] = ? AND [studentClass] = ? AND [studentTel] = ? AND [studentQQ] = ? AND [studentAbout] = ? AND [loginCount] = ? AND [mathchEnCount] = ? AND [mathchChCount] = ? AND [trainEnCount] = ? AND [trainChCount] = ? AND [registerTime] = ? AND [lastLoinTime] = ? AND [lastTypeTime] = ? AND [registerIP] = ? AND [lastLoinIP] = ? AND [lastTypeIP] = ?">
            <DeleteParameters>
                <asp:Parameter Name="original_studentUsername" Type="String" />
                <asp:Parameter Name="original_studentPassword" Type="String" />
                <asp:Parameter Name="original_roleType" Type="Int32" />
                <asp:Parameter Name="original_studentName" Type="String" />
                <asp:Parameter Name="original_studentID" Type="String" />
                <asp:Parameter Name="original_studentSex" Type="Boolean" />
                <asp:Parameter Name="original_studentDepartment" Type="String" />
                <asp:Parameter Name="original_studentGrade" Type="String" />
                <asp:Parameter Name="original_studentClass" Type="String" />
                <asp:Parameter Name="original_studentTel" Type="String" />
                <asp:Parameter Name="original_studentQQ" Type="String" />
                <asp:Parameter Name="original_studentAbout" Type="String" />
                <asp:Parameter Name="original_loginCount" Type="Int32" />
                <asp:Parameter Name="original_mathchEnCount" Type="Int32" />
                <asp:Parameter Name="original_mathchChCount" Type="Int32" />
                <asp:Parameter Name="original_trainEnCount" Type="Int32" />
                <asp:Parameter Name="original_trainChCount" Type="Int32" />
                <asp:Parameter Name="original_registerTime" Type="DateTime" />
                <asp:Parameter Name="original_lastLoinTime" Type="DateTime" />
                <asp:Parameter Name="original_lastTypeTime" Type="DateTime" />
                <asp:Parameter Name="original_registerIP" Type="String" />
                <asp:Parameter Name="original_lastLoinIP" Type="String" />
                <asp:Parameter Name="original_lastTypeIP" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="studentPassword" Type="String" />
                <asp:Parameter Name="roleType" Type="Int32" />
                <asp:Parameter Name="studentName" Type="String" />
                <asp:Parameter Name="studentID" Type="String" />
                <asp:Parameter Name="studentSex" Type="Boolean" />
                <asp:Parameter Name="studentDepartment" Type="String" />
                <asp:Parameter Name="studentGrade" Type="String" />
                <asp:Parameter Name="studentClass" Type="String" />
                <asp:Parameter Name="studentTel" Type="String" />
                <asp:Parameter Name="studentQQ" Type="String" />
                <asp:Parameter Name="studentAbout" Type="String" />
                <asp:Parameter Name="loginCount" Type="Int32" />
                <asp:Parameter Name="mathchEnCount" Type="Int32" />
                <asp:Parameter Name="mathchChCount" Type="Int32" />
                <asp:Parameter Name="trainEnCount" Type="Int32" />
                <asp:Parameter Name="trainChCount" Type="Int32" />
                <asp:Parameter Name="registerTime" Type="DateTime" />
                <asp:Parameter Name="lastLoinTime" Type="DateTime" />
                <asp:Parameter Name="lastTypeTime" Type="DateTime" />
                <asp:Parameter Name="registerIP" Type="String" />
                <asp:Parameter Name="lastLoinIP" Type="String" />
                <asp:Parameter Name="lastTypeIP" Type="String" />
                <asp:Parameter Name="original_studentUsername" Type="String" />
                <asp:Parameter Name="original_studentPassword" Type="String" />
                <asp:Parameter Name="original_roleType" Type="Int32" />
                <asp:Parameter Name="original_studentName" Type="String" />
                <asp:Parameter Name="original_studentID" Type="String" />
                <asp:Parameter Name="original_studentSex" Type="Boolean" />
                <asp:Parameter Name="original_studentDepartment" Type="String" />
                <asp:Parameter Name="original_studentGrade" Type="String" />
                <asp:Parameter Name="original_studentClass" Type="String" />
                <asp:Parameter Name="original_studentTel" Type="String" />
                <asp:Parameter Name="original_studentQQ" Type="String" />
                <asp:Parameter Name="original_studentAbout" Type="String" />
                <asp:Parameter Name="original_loginCount" Type="Int32" />
                <asp:Parameter Name="original_mathchEnCount" Type="Int32" />
                <asp:Parameter Name="original_mathchChCount" Type="Int32" />
                <asp:Parameter Name="original_trainEnCount" Type="Int32" />
                <asp:Parameter Name="original_trainChCount" Type="Int32" />
                <asp:Parameter Name="original_registerTime" Type="DateTime" />
                <asp:Parameter Name="original_lastLoinTime" Type="DateTime" />
                <asp:Parameter Name="original_lastTypeTime" Type="DateTime" />
                <asp:Parameter Name="original_registerIP" Type="String" />
                <asp:Parameter Name="original_lastLoinIP" Type="String" />
                <asp:Parameter Name="original_lastTypeIP" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="roleType" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="studentUsername" Type="String" />
                <asp:Parameter Name="studentPassword" Type="String" />
                <asp:Parameter Name="roleType" Type="Int32" />
                <asp:Parameter Name="studentName" Type="String" />
                <asp:Parameter Name="studentID" Type="String" />
                <asp:Parameter Name="studentSex" Type="Boolean" />
                <asp:Parameter Name="studentDepartment" Type="String" />
                <asp:Parameter Name="studentGrade" Type="String" />
                <asp:Parameter Name="studentClass" Type="String" />
                <asp:Parameter Name="studentTel" Type="String" />
                <asp:Parameter Name="studentQQ" Type="String" />
                <asp:Parameter Name="studentAbout" Type="String" />
                <asp:Parameter Name="loginCount" Type="Int32" />
                <asp:Parameter Name="mathchEnCount" Type="Int32" />
                <asp:Parameter Name="mathchChCount" Type="Int32" />
                <asp:Parameter Name="trainEnCount" Type="Int32" />
                <asp:Parameter Name="trainChCount" Type="Int32" />
                <asp:Parameter Name="registerTime" Type="DateTime" />
                <asp:Parameter Name="lastLoinTime" Type="DateTime" />
                <asp:Parameter Name="lastTypeTime" Type="DateTime" />
                <asp:Parameter Name="registerIP" Type="String" />
                <asp:Parameter Name="lastLoinIP" Type="String" />
                <asp:Parameter Name="lastTypeIP" Type="String" />
            </InsertParameters>
        </asp:AccessDataSource>
	
</div>
</div>
<table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
</table>
    </form>
</body>
</html>
