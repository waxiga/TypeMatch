var openHelp=true;
function ifShowHelp(obj){
	if(openHelp){
		openHelp=false;
		obj.value="打开提示";
	}
	else{
		openHelp=true;
		obj.value="关闭提示";
	}
}