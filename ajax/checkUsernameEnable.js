var xmlHttp;
function createXMLHTTP()
{
    if(window.XMLHttpRequest)
    {
        xmlHttp=new XMLHttpRequest();//mozilla浏览器
    }
    else if(window.ActiveXObject)
    {
        try
        {
            xmlHttp=new ActiveXObject("Msxml2.XMLHTTP");//IE老版本
        }
        catch(e)
        {}
        try
        {
            xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");//IE新版本
        }
        catch(e)
        {}
        if(!xmlHttp)
        {
            window.alert("不能创建XMLHttpRequest对象实例！");
            return false;
        }
    }
}

function checkEnable(){
	var username=document.form1.username.value;
    createXMLHTTP();//创建XMLHttpRequest对象
	var url="ajax/checkUsernameEnable.aspx?user="+username+"&t="+TimeDemo();
	xmlHttp.open("POST",url,true);
    xmlHttp.onreadystatechange=getResponseRusult;
    xmlHttp.send(null);
}
function TimeDemo(){
   var d;
   d = new Date();
   return(d.getMilliseconds());
}

function getResponseRusult()
{
    if(xmlHttp.readyState==4)
    {
        if(xmlHttp.status==200)
        {
			var reint=xmlHttp.responseText;
            if(reint=="0") {
				showEnable();
			}
			else{
				showDisable();
			}
        }
    }
}
function showEnable(){
document.getElementById("checkuser").innerHTML="<img width='13px' height='13px' src='images/true.gif' title='恭喜，该用户名没被注册，可以使用！' />";
}
function showDisable(){
document.getElementById("checkuser").innerHTML="<img width='14px' height='13px' src='images/false.gif' title='对不起，该用户名已被注册，不可以使用！' />";
}