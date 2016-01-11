var xmlHttp;
function createXMLHTTP()
{
    if(window.XMLHttpRequest)
    {
        xmlHttp=new XMLHttpRequest();
    }
    else if(window.ActiveXObject)
    {
        try
        {
            xmlHttp=new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch(e)
        {}
        try
        {
            xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
        }
        catch(e)
        {}
        if(!xmlHttp)
        {
            window.alert("创建XMLHTTPREQUEST失败");
            return false;
        }
    }
}

var timeLast;
var ifZuoBi=false;
function submitSelectItem(){
	timeLast=window.setTimeout("sumbitTimeOut()",8000 );
	sumbitTypeData();
	var right=document.form1.rightWords.value;
	var wrong=document.form1.wrongWords.value;
	var speed=averagespeed;
	var typeCookie=getCookie("typeMatchCookie");
	var formStr="right="+right+"&wrong="+wrong+"&speed="+speed+"&last_time="+usedTime+"&co="+typeCookie;
	if(ifZuoBi){
	    formStr="right="+right+"&wrong="+wrong+"&speed="+speed+"&last_time="+usedTime+"&co="+typeCookie+"&zuobi=1";
	}
    createXMLHTTP();//
	var url="ajax/saveTypeResult.aspx?time="+TimeDemo();
	xmlHttp.open("POST",url,true);
	xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded:charset=UTF-8");
    xmlHttp.onreadystatechange=getResponseRusult;
    xmlHttp.send(formStr);
}
function TimeDemo(){
   var d;
   d = new Date();
   return(d.getMilliseconds());
}
function getCookie(name)
{
var arr,reg=new RegExp("(^| )"+name+"=([^;]*)(;|$)");
if(arr=document.cookie.match(reg)) return unescape(arr[2]);
else return null;
}
function getResponseRusult()
{
    if(xmlHttp.readyState==4)
    {
        if(xmlHttp.status==200)
        {
			clearTimeout(window.timeLast);
			var reint=xmlHttp.responseText;
			//alert(reint);
            if(reint=="1"){
				dataSaveOk();
			}
			else{
			    if(reint=="984274924"){
			        zuobi();
			    }
			    else{
				returnError();
				}
			}
        }
    }
}
function zuobi(){
    submitSelectItem();
    ifZuoBi=true;
	textBody="<p style='text-indent:20px;line-height:22px;font-size:14px;font-weight:bold;'><img src='images/timeout.gif' />反作弊系统已启动，你的操作已被记录，如果你有企图作弊行为请立即停止，否则系统将拒绝保存你的打字成绩。谢谢合作！</p><br />";
	alertMinWindow(textBody);
}