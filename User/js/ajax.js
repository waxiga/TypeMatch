var openHelp=true;
function ifShowHelp(obj){
	if(openHelp){
		openHelp=false;
		obj.value="����ʾ";
	}
	else{
		openHelp=true;
		obj.value="�ر���ʾ";
	}
}