//声明XMLHttpRequest对象
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


//检测用户名是否存在,然后正式执行.
var timeLast;
function submitSelectItem()
{
    var postStr="uid="+document.getElementById("userName").value+"&pwd="+document.getElementById("passWord").value;
	timeLast=window.setTimeout("show_timeout()",15000 );
    show_waitting();
    createXMLHTTP();//创建XMLHttpRequest对象
    var url="ajax/chcekUser.aspx?time="+TimeDemo();
    xmlHttp.open("POST",url,true);
    xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded:charset=UTF-8");
    xmlHttp.onreadystatechange=getResponseRusult;
    xmlHttp.send(postStr);
}
//取一个随机数
function TimeDemo(){
   var d;
   d = new Date();
   return(d.getMilliseconds());
}

//执行检测用户名回调函数
function getResponseRusult()
{
    if(xmlHttp.readyState==4)//判断对象状态
    {
        if(xmlHttp.status==200)//信息成功返回，开始处理信息
        {
			clearTimeout(window.timeLast);
			var reint=xmlHttp.responseText;
//			alert(reint);
            switch (reint) {
                case "1":
                    show_success();break ;
                case "2" :
                    show_tryCountOut();break ;
                default :
                    show_error();break ;
            } 
        }
    }
}
var waitting,error,success,timeout,tryCountOut;
window.onload=function(){
document.getElementById("userName").focus();
waitting=document.getElementById("waitting");
error=document.getElementById("error");
success=document.getElementById("success");
timeout=document.getElementById("timeout");
tryCountOut=document.getElementById("tryCountOut");
}
function hiddenall(){
waitting.style.display="none";
error.style.display="none";
success.style.display="none";
timeout.style.display="none";
tryCountOut.style.display="none";
}
function show_waitting(){
hiddenall();
waitting.style.display="block";
}
function show_error(){
hiddenall();
error.style.display="block";
}
function show_success(){
hiddenall();
success.style.display="block";
window.setTimeout("toOtherPage()",2000);
}
function show_timeout(){
hiddenall();
timeout.style.display="block";
}
function show_tryCountOut(){
hiddenall();
tryCountOut.style.display="block";
}
function toOtherPage(){
window.location="default.aspx";
}
