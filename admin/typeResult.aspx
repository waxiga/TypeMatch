<%@ Page Language="C#" AutoEventWireup="true" CodeFile="typeResult.aspx.cs" Inherits="admin_typeResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>打字结果</title>
<script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
<link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css" />
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
	<div id="header" style="text-align:center;">打字成绩
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            <asp:ListItem Selected="True" Value="3">中文打字比赛</asp:ListItem>
            <asp:ListItem Value="4">英文打字比赛</asp:ListItem>
            <asp:ListItem Value="2">中文打字练习</asp:ListItem>
            <asp:ListItem Value="1">英文打字练习</asp:ListItem>
        </asp:DropDownList></div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="typeID" DataSourceID="AccessDataSource1" PageSize="50" EmptyDataText="<b style='color:#fff;margin-left:220px;'>暂无打字结果</b>">
        <Columns>
            <asp:TemplateField HeaderText="typeID" InsertVisible="False" SortExpression="typeID">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("typeID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("typeID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="typeUser" HeaderText="参赛者" SortExpression="typeUser" />
            <asp:BoundField DataField="typeEndTime" HeaderText="完成时间" SortExpression="typeEndTime" />
            <asp:BoundField DataField="typeIP" HeaderText="打字ＩＰ" SortExpression="typeIP" />
            <asp:BoundField DataField="typeArtTitle" HeaderText="文章标题" SortExpression="typeArtTitle" />
            <asp:BoundField DataField="useTime" HeaderText="用时" SortExpression="useTime" />
            <asp:BoundField DataField="typeSpeed" HeaderText="打字速度" SortExpression="typeSpeed" />
            <asp:BoundField DataField="rightWordCount" HeaderText="正确字数" SortExpression="rightWordCount" />
            <asp:BoundField DataField="wrongWordCount" HeaderText="错误字数" SortExpression="wrongWordCount" />
            <asp:TemplateField HeaderText="<a href='delete.aspx?tablename=typeResult&count=all'  onclick='return areYouSure()'><b style='color:#fff;'>删除</b></a>">
                <ItemTemplate>
                    <a href='delete.aspx?tablename=typeResult&key=typeID&value=<%# Eval("typeID") %>' onclick="return areYouSure()"><img src='../images/delete.gif' alt='删除' /></a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/#typematch.mdb"
        SelectCommand="SELECT * FROM [typeResult] WHERE ([typeType] = ?)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="3" Name="typeType"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:AccessDataSource>
</div>
<table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
</table>
    </form>
</body>
</html>
