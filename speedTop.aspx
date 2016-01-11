<%@ Page Language="C#" AutoEventWireup="true" CodeFile="speedTop.aspx.cs" Inherits="speedTop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>打字速度排行榜</title>
    <style type="text/css">
body{
	margin:0px;
	font-size:12px;
	text-align:center;
	background-image:url(images/typeface_bg.gif);
	color:#FFCC33;
}
#containner{
	margin:auto;
	margin-top:10px;
	width:620px;
	height:auto;
	text-align:left;
	border:1px solid #FFCC66;
	display:block;
}
#header{
	width:100%;
	height:34px;
	line-height:34px;
	font-size:14px;
	font-weight:bold;
	background-color:#6F0003;
	border-bottom:1px solid #FFCC66;
	color:#FFF;
	text-indent:24px;
	display:block;
}
#content{
	background-image:url(images/apoints_bg.jpg);
	width:100%;
	height:auto;
}
table{
width:100%;
height:auto;
text-align:left;
margin:auto;
border:1px solid #FFCC66;
border-collapse:collapse;
}
tr{
height:15px;
}
td{
height:15px;
border:1px solid #FFCC66;
border-collapse:collapse;
}
.tableHeader{
background-color:#FFF;
color:#000;
font-weight:bold;
}
a{
color:#5f5;
border:none;
}
img{
border:none;
}
.delBtn{
display:block;
width:100%;
height:100%;
background-color:#fff;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
<div id="containner">
	<div id="header">
        当前排名榜(按打字速度从高到低)<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            <asp:ListItem Selected="True" Value="3">中文打字比赛</asp:ListItem>
            <asp:ListItem Value="4">英文打字比赛</asp:ListItem>
            <asp:ListItem Value="2">中文打字练习</asp:ListItem>
            <asp:ListItem Value="1">英文打字练习</asp:ListItem>
        </asp:DropDownList></div>
	<div id="content">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="typeID" DataSourceID="AccessDataSource1" PageSize="50" EmptyDataText="<b style='color:#fff;margin-left:220px;'>暂无打字结果</b>">
        <Columns>
            <asp:BoundField DataField="typeUser" HeaderText="参赛者" SortExpression="typeUser" />
            <asp:BoundField DataField="typeEndTime" HeaderText="打字时间" SortExpression="typeEndTime" />
            <asp:BoundField DataField="typeIP" HeaderText="打字ＩＰ" SortExpression="typeIP" />
            <asp:BoundField DataField="typeArtTitle" HeaderText="打字文章" SortExpression="typeArtTitle" />
            <asp:BoundField DataField="useTime" HeaderText="用时" SortExpression="useTime" />
            <asp:BoundField DataField="typeSpeed" HeaderText="打字速度" SortExpression="typeSpeed" />
            <asp:BoundField DataField="rightWordCount" HeaderText="正确字数" SortExpression="rightWordCount" />
            <asp:BoundField DataField="wrongWordCount" HeaderText="错误字数" SortExpression="wrongWordCount" />
        </Columns>
    </asp:GridView>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/#typematch.mdb"
        SelectCommand="SELECT DISTINCT * FROM [typeResult] WHERE ([typeType] = ?) ORDER BY [typeSpeed] DESC, [typeEndTime] DESC, [rightWordCount] DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="3" Name="typeType"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:AccessDataSource>

	</div>
</div>
    </form>
    <div style="display:none;"><script language="javascript" src="http://count20.51yes.com/click.aspx?id=205571862&logo=12"></script></div>
</body>
</html>
