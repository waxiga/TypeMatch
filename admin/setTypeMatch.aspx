<%@ Page Language="C#" AutoEventWireup="true" CodeFile="setTypeMatch.aspx.cs" Inherits="admin_setTypeMatch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>开启/关闭打字比赛</title>
<script language="javascript" type="text/javascript" src="../js/addTableEvent.js"></script>
<link rel="stylesheet" type="text/css" href="../style/forAdminMainFrame.css" />
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
	<div id="header">开启/关闭打字比赛</div>
	<div id="content">
		 <table>
		 <tr class="tableHeader">
		 	<td>类别</td>
			<td>当前状态</td>
			<td>比赛文章</td>
			<td>可执行的操作</td>
		 </tr>
		 <tr>
		 	<td><b>中文</b>打字比赛</td>
			<td>
                <asp:Label ID="Chtypematch" runat="server" Text="已关闭"></asp:Label></td>
			<td>
                <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/#typematch.mdb"
                    SelectCommand="SELECT [newsID], [title] FROM [news] WHERE ([newsType] = ?)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="3" Name="newsType" Type="Int32" />
                    </SelectParameters>
                </asp:AccessDataSource>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="AccessDataSource1"
                    DataTextField="title" DataValueField="newsID">
                </asp:DropDownList></td>
			<td>
			<input name="startChType" type="button" value="立即开启" id="openChBtn" runat="server" visible="true" onserverclick="openChBtn_ServerClick" /><input name="endChType" type="button" value="立即关闭" id="closeChBtn" runat="server" onserverclick="closeChBtn_ServerClick" /></td>
		 </tr>
		 <tr>
		 	<td><b>英文</b>打字比赛</td>
			<td>
                <asp:Label ID="Entypematch" runat="server" Text="已关闭"></asp:Label></td>
			<td>
                <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/#typematch.mdb"
                    SelectCommand="SELECT [newsID], [title] FROM [news] WHERE ([newsType] = ?)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="4" Name="newsType" Type="Int32" />
                    </SelectParameters>
                </asp:AccessDataSource>
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="AccessDataSource2"
                    DataTextField="title" DataValueField="newsID">
                </asp:DropDownList></td>
			<td>
			<input name="startEnType" type="button" value="立即开启" id="openEnBtn" runat="server" visible="true" onserverclick="openEnBtn_ServerClick"  /><input name="endChType" type="button" value="立即关闭" id="closeEnBtn" runat="server" onserverclick="closeEnBtn_ServerClick" /></td>
		</tr>
		 </table>
	</div>
</div>
<table class="copyrightTable"><tr><td class="copyrightTable">版权所有：清新视觉网络工作室 copyright:2007--2008<br/>power by www.bfc2008.cn</td></tr>
</table>
    </form>
</body>
</html>
