window.onload=function(){
var tables=document.getElementsByTagName("table");
	for(var i=0;i<tables.length;i++){
		var trs=tables[i].getElementsByTagName("tr");
		for(var ii=1;ii<trs.length;ii=ii+2){
			trs[ii].style.backgroundColor="#E9F9FE";
			trs[ii].onmouseover=function(){
				changTrBg(this);
			}
			trs[ii].onmouseout=function(){
				rechangTrBg(this,"#E9F9FE");
			}
		}
		for(var ii=2;ii<trs.length;ii=ii+2){
			trs[ii].style.backgroundColor="#C6ECFD";
			trs[ii].onmouseover=function(){
				changTrBg(this);
			}
			trs[ii].onmouseout=function(){
				rechangTrBg(this,"#C6ECFD");
			}
		}
	}
}
function changTrBg(obj)
{
	obj.style.backgroundColor="#3EAFE6";
}
function rechangTrBg(obj,bgColor)
{
	obj.style.backgroundColor=bgColor;
}
function areYouSure(){
return confirm('删除后将不能恢复.你确定要删除吗?');
}