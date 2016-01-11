window.onload=function(){
	//使表格隔行变色和添加鼠标事件
	var tables=document.getElementsByTagName("table");
	for(var i=0;i<tables.length;i++){
		var trs=tables[i].getElementsByTagName("tr");
		trs[0].className="tableHeader";
		for(var ii=1;ii<trs.length;ii=ii+2){
			trs[ii].style.backgroundColor="#fff";
			trs[ii].onmouseover=function(){
				changTrBg(this);
			}
			trs[ii].onmouseout=function(){
				rechangTrBg(this,"#fff");
			}
		}
		for(var ii=2;ii<trs.length;ii=ii+2){
			trs[ii].style.backgroundColor="#ECF9DB";
			trs[ii].onmouseover=function(){
				changTrBg(this);
			}
			trs[ii].onmouseout=function(){
				rechangTrBg(this,"#ECF9DB");
			}
		}
	}
}
function changTrBg(obj)
{
	obj.style.backgroundColor="#D8F1BA";
}
function rechangTrBg(obj,bgColor)
{
	obj.style.backgroundColor=bgColor;
}
function beforeDel(){
	//删除前确认
	return confirm('删除后将不能恢复.你确定要删除吗?');
}
var theurl;
    function beforeDel2(obj){
        theurl=obj.href;
        ymPrompt.confirmInfo({message:"你确定？",dragOut:true,showShadow:true,minBtn:true,maxBtn:true,handler:cbfhandler})
    }
    function cbfhandler(obj){
        if(obj=="ok"){
            window.location=theurl;
        }
    }
    
    
    
function selectChang(parentDivID,obj){
	//全选/反选按钮
	var theTableObjs=document.getElementsByTagName("table");
	var theObjs;
	for(var a=0;a<theTableObjs.length;a++){
	    theObjs=theTableObjs[a].getElementsByTagName("input");
	    for(var i=1;i<theObjs.length;i++){
		    theObjs[i].checked=obj.checked;
	    }
	}
}
function delTopBox(obj){
	var theTableObjs=document.getElementById(obj);
	if(theTableObjs.style.display=="block" || theTableObjs.style.display=="" || theTableObjs.style.display==null){
	    theTableObjs.style.display="none";
	}
	else{
	    theTableObjs.style.display="block";
	}
}
function MM_jumpMenu(targ,selObj,restore){ //v3.0
//下拉菜单跳转函数
  eval(targ+".location='"+selObj.options[selObj.selectedIndex].value+"'");
  if (restore) selObj.selectedIndex=0;
}
function openNewWindow(url)
{
 window.open (url,'newwindow','height=768,width=1024,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
 closewin();
}
function closewin(){
window.opener='anyone';
window.close();
}
function addHeight(objID){
    var obj=document.getElementById(objID);
    var intHeight=parseInt(obj.style.height)+100;
    obj.style.height=intHeight+"px";
}
function subHeight(objID){
    var obj=document.getElementById(objID);
    var intHeight=parseInt(obj.style.height)-100;
    if(intHeight>100){
    obj.style.height=intHeight+"px";
    }
    else{
        alert("已经缩小到最小高度.");
    }
}
function goUrl(url){
        window.setTimeout("window.location='"+url+"'",3000);
    }
    
    
//------------------热键---------------
document.onkeypress=function(){ 
    if(window.event.keyCode==96){
    var theall=window.top.document.getElementById("allFrame");
    var theElement=window.top.document.getElementById("myFrame");
    if(theall.rows!="56,*,22"){
	    theall.rows="56,*,22";
	    theElement.cols="180,*";
	}
	else{
	   theall.rows="0,*,0";
	    theElement.cols="0,*";
	  }
    }
}