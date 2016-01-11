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
var soursStr="在这里输入你的想法看看.";
function ifClear(obj){
    if(obj.value==soursStr){
        obj.value="";
    }
    else{
        if(obj.value==""){
        obj.value="在这里输入你的想法看看.";
        }
    }
}
function ifSearch(obj){
   if(window.event.keyCode==13){
        var t=obj.value;
        if(t=="yellowpage" || t=="huangye" || check(t,"黄","页")){
            setUrl("yellowPageManage.aspx")
            return true;
        }
        if(t=="guest" || t=="guestbook" || t=="jy" || t=="jianyi" || t=="liuyin" || check(t,"建","议")|| check(t,"提","议")|| check(t,"留","言")|| check(t,"提","问")){
            setUrl("guestBookManage.aspx")
            return true;
        }
        if(t=="sql" || t=="chaxun" || t=="cx" || check(t,"查","询") || check(t,"分","析") || check(t,"数","据")){
            setUrl("sqlTran.aspx")
            return true;
        }
        if(t=="shangjia" || t=="Advertiser" || t=="sj" || check(t,"商","家")){
            setUrl("shangjiaManage.aspx")
            return true;
        }
        if(t=="ad" || t=="AD" || t=="fenlei" || t=="fl" || t=="gg" || t=="guanggao" || t=="fenleiAD" || check(t,"分","类")){
            setUrl("fenleiAD.aspx")
            return true;
        }
        if(t=="addnews" || t=="tianjia" || t=="tj" || check(t,"添","加") || check(t,"添","资") || check(t,"添","讯") || check(t,"添","新") || check(t,"添","章")){
            setUrl("newsAdd.aspx")
            return true;
        }
        if(t=="xinwen" || t=="news" || t=="xw" || check(t,"新","闻")){
            setUrl("newsManage.aspx")
            return true;
        }
        if(t=="fc" || t=="fangchan" || check(t,"房","产")){
            setUrl("fangchanManage.aspx")
            return true;
        }
        if(t=="ly" || t=="lvyou" || check(t,"旅","游")){
            setUrl("lvyouManage.aspx")
            return true;
        }
        if(t=="qy" || t=="qiye" || check(t,"企","业")){
            setUrl("qiyeManage.aspx")
            return true;
        }
        if(t=="huiyuan" || t=="hy" || check(t,"会","员")){
            setUrl("webUserManage.aspx")
            return true;
        }
        if(t=="music" || t=="yinyu" || t=="yy" || t=="gequ" || t=="mp3" || t=="tingge" || t=="tg" || t=="gq" || check(t,"听","歌") || check(t,"音","乐") || check(t,"好","听") || check(t,"歌","曲")){
            playMp3();
            return true;
        }
        if(t=="stop" || t=="pause" || check(t,"停","止")){
            stopplayMp3();
            return true;
        }
        if(t=="loginout" || t=="tc" || check(t,"退","出")){
            setUrl("admin_loginOut.aspx")
            return true;
        }
        if(t=="baidu" || t=="bd" || check(t,"百","度")){
            setUrl("http://www.baidu.com")
            return true;
        }
        if(t=="google" || t=="gg" || check(t,"谷","歌")){
            setUrl("http://www.g.cn")
            return true;
        }
        if(t=="index" || t=="default" || t=="sy" || t=="shouye" || t=="0746888" || check(t,"首","页") || check(t,"永","港")){
            setUrl("http://www.0746888.com")
            return true;
        }
        document.getElementById("Text1").value="\""+t+"\"不是内部或外部命令，也不是可运行的程序或批处理文件。";
        window.setTimeout("resetvalue()",2000);
   }
}
//----------------------------------
function playMp3(){
    var myarr=new Array(5);
    var myarr2=new Array(5);
    myarr[0]="新歌推荐-华语"
    myarr2[0]="http://play.1ting.com/p_321382_322536_322537_322257_322458_322263_322460_321211_320786_321943_320779_322461_321391_317888_320759_321387_308744_316773_316768_317103_316226_321926_321385_321376_320343_320339_319895_319197_318303_317319.html";
    myarr[1]="新歌推荐-欧美";
    myarr2[1]="http://play.1ting.com/p_322680_322614_322559_321945_321978_321996_322086_321696_321595_321670_321507_321308_321316_321341_318896_318104_317802_321326_321286_320705_319856_319114_317641_321286_321228_319815_319678_318302_317605_320606.html";
    myarr[2]="最热歌曲";
    myarr2[2]="http://www.vcdmp3.com/playlist.asp?id=127629_127542_127520_127514_127517_127502_127500_127488_127484_127483_127482_127470_127472_127461_127380_127407_127352_127267_127351_127350_127337_127310_127388_127262_127261_127390_127190_127160_127171_127195";
    myarr[3]="新歌推荐-日韩";
    myarr2[3]="http://play.1ting.com/p_322401_322263_321211_321382_116652_160856_320759_178869_317888_322257_321391_53734_321385_321387_320786.html";
    myarr[4]="经典老歌";
    myarr2[4]="http://play.1ting.com/p_116652_178869_53734_131764_58447_82185_142867_136778_131424_73464_120414_203955_206836_44304_52053.html";
    var ii=rand(myarr.length-1)
    var murl=myarr2[ii];
    var gechi=myarr[ii];
    var a="<iframe src='"+murl+"' width='1' height='1' border='0'></iframe>";
    document.getElementById("mp3box").innerHTML=a;
    document.getElementById("musiceInfo").innerHTML="("+ii+")正在下载并播放["+gechi+"]...";
}
function playmp(){
    var murl="http://play.1ting.com/p_321382_322536_322537_322257_322458_322263_322460_321211_320786_321943_320779_322461_321391_317888_320759_321387_308744_316773_316768_317103_316226_321926_321385_321376_320343_320339_319895_319197_318303_317319.html";
    var a="<iframe src='"+murl+"' width='1' height='1' border='0'></iframe>";
    document.getElementById("mp3box").innerHTML=a;
    document.getElementById("musiceInfo").innerHTML="正在下载并播放...";
}
function stopplayMp3(){
    window.location="adminBottom.html";
}
rnd.today=new Date(); 
rnd.seed=rnd.today.getTime(); 
function rnd() { 
　　　　rnd.seed = (rnd.seed*9301+49297) % 233280;
　　　　return rnd.seed/(233280.0); 
    };
function rand(number) { 
　　　　return Math.ceil(rnd()*number); 
    };
function setUrl(theurl){
    var theall=window.top.document.getElementById("mainFrame");
    theall.src=theurl;
    var tempstr="命令已执行成功!"+getDateTime();
    document.getElementById("Text1").value=tempstr;
    window.setTimeout("resetvalue()",2000);
    document.getElementById("Text1").blur();
}
function resetvalue(){
    document.getElementById("Text1").value=soursStr;
}
function getDateTime(){
	var d, s = ""; // 声明变量。 
	d = new Date(); // 创建 Date 对象。
	s +="     "+d.getYear()+"年";
	s += (d.getMonth() + 1) + "月"; // 获取月份。 
	s += d.getDate() + "日  "; // 获取日。 
	s +=d.getHours()+":";
	s +=d.getMinutes()+":";
	s +=d.getSeconds();     
	return s;
}
function check(fullStr,txt1,txt2){ 
var tempChar;
for(var i=0;i<fullStr.length;i++){
 tempChar= fullStr.substring(i,i + 1); 
   if(tempChar==txt1){
	for(var ii=i;ii<fullStr.length;ii++){
	   tempChar= fullStr.substring(ii,ii + 1); 
	   if(tempChar==txt2){
	      return true;
    	   }
	}
    }
 }
return false;
}