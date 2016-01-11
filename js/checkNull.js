// check input if is null
function checkNull(){
	var uidLabel=document.getElementById("uidIsNull");
	var pwdLabel=document.getElementById("pwdIsNull");
	uidLabel.style.display="none";
	pwdLabel.style.display="none";
	if(document.getElementById("userName").value==""){
	uidLabel.style.display="block";
	document.form1.uid.focus();
	return false;
	}
	else{
		if(document.getElementById("passWord").value==""){
		pwdLabel.style.display="block";
		document.form1.pwd.focus();
		return false;
		}
		else{
			return true;
		}
	}
}