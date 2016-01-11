<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selectResult.aspx.cs" Inherits="selectResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>成绩查询</title>
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
color:#2b8;
}
</style>
<script language="javascript" type="text/javascript">
window.onload=function(){
    var spans=document.getElementsByTagName("span");
    for(var i=0;i<=spans.length;i++){
        var type=spans[i].innerHTML;
        switch (type) {
                case "1":
                    spans[i].innerHTML="英文打字练习";break ;
                case "2" :
                    spans[i].innerHTML="中文打字练习";break ;
                case "3" :
                    spans[i].innerHTML="中文打字比赛";break ;
                case "4" :
                    spans[i].innerHTML="英文打字比赛";break ;
                default :
                    spans[i].innerHTML="中文打字比赛";break ;
            } 
    }
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="containner">
	<div id="header"><b style="color:Green;"><%=Session["realName"]%></b>你好，以下是你最近参加的练习或比赛结果</div>
	<div id="content">
	<table>
  <tr class="tableHeader">
    <td>类型</td>
    <td>速度</td>
    <td>文章</td>
    <td>时间</td>
	<td>正确字数</td>
    <td>错误这数</td>
    <td><a href='deleteTypeResult.aspx?id=all' onclick='return confirm("你确定要删除全部打字记录吗?(注：打字比赛成绩不能删除．)");'>全部删除</a></td>
  </tr>
   <asp:Repeater ID="Repeater1" runat="server">
   <ItemTemplate>
  <tr>
    <td><span><%#Eval("typeType")%></span></td>
    <td><%#Eval("typeSpeed")%>字/分</td>
    <td>《<%#Eval("typeArtTitle")%>》</td>
    <td><%#Eval("typeEndTime")%></td>
	<td><%#Eval("rightWordCount")%></td>
	<td><%#Eval("wrongWordCount")%></td>
	<td><a href='deleteTypeResult.aspx?id=<%#Eval("typeID")%>' onclick='return confirm("你确定要删除此打字记录吗?(注：打字比赛成绩不能删除．)");'>删除</a></td>
  </tr>
  </ItemTemplate>
</asp:Repeater>
</table>
	</div>
</div>
    </form>
    <script language="javascript" src="http://count20.51yes.com/click.aspx?id=205571862&logo=12"></script>
</body>
</html>
