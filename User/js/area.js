function Province(id,title) {
		this.id = id;
		this.title=title;
		this.boardlist=new Array();
		this.addBoard=addBoard;
		this.getOptions = getOptions;
	}

	function addBoard(board) {
		this.boardlist = this.boardlist.concat(board);
	}

	function getOptions() {
		var tmp = new Array();
		for(var i=0; i < this.boardlist.length;i++) {
			var b = this.boardlist[i];
			tmp[i]= b.getOption();
		}
		return tmp;
	}

	//board methods
	function Board(catid,id,title,total) {
		this.catid=catid;
		this.id=id;
		this.title=title;
		this.getOption=getOption;
	}


	function getOption() {
		return new Option(this.title,this.id);
	}

	function changeProvince(list) {
	if (list.selectedIndex<=0) {
		catForm1.options[0].selected=true;
    		var len = boardForm1.options.length;
    		for (var i=len-1;i>0;i--){
    			boardForm1.options[i]=null;
    		}
		}
        else {
    		var boards = catArr1[list.selectedIndex-1].getOptions();
    		var len = boardForm1.options.length;
    		for (var i=len-1;i>0;i--){
    			boardForm1.options[i]=null;
    		}
    		for (var i=0;i<boards.length;i++) {
    			boardForm1.options[i+1]=boards[i];
    		}
		}
	}

	function changeCountry1(list){
		//如果国家的选择为“中国大陆”，则省、地区的值不为空
		if (list.options[list.selectedIndex].value != "CN"){//否则省、地区的值为空
			if (list.options[list.selectedIndex].value == "Other"){
				//如果选择“其他国家和地区”，则列出所有国家
				document.all.country1.style.display = 'none';
				document.all.country2.selectedIndex = 0;
				document.all.country2.style.display = '';
			}
			document.all.province.selectedIndex = 0;
			document.all.city.selectedIndex = 0;
			document.all.province.style.display = 'none';
			document.all.city.style.display = 'none';
		}else{
			document.all.province.style.display = '';
			document.all.city.style.display = '';
	    }

	}

	function changeCountry2(list){
		//如果国家的选择为“中国大陆”，则省、地区的值不为空
		if (list.options[list.selectedIndex].value == "CN"){
		    document.all.country1.selectedIndex = 0;
		    document.all.country1.style.display = '';
			document.all.country2.style.display = 'none';
			document.all.province.style.display = '';
			document.all.city.style.display = '';
		}

	}

	//static methods
	var catArr1 = new Array();
	var cur1;

        //取省份、城市
			    cur1 = new Province('安徽','安徽');
	  		    catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1002,'安庆','安庆'));
	  			  				cur1.addBoard(new Board(1002,'蚌埠','蚌埠'));
	  			  				cur1.addBoard(new Board(1002,'巢湖','巢湖'));
	  			  				cur1.addBoard(new Board(1002,'池州','池州'));
	  			  				cur1.addBoard(new Board(1002,'滁州','滁州'));
	  			  				cur1.addBoard(new Board(1002,'阜阳','阜阳'));
	  			  				cur1.addBoard(new Board(1002,'合肥','合肥'));
	  			  				cur1.addBoard(new Board(1002,'淮北','淮北'));
	  			  				cur1.addBoard(new Board(1002,'淮南','淮南'));
	  			  				cur1.addBoard(new Board(1002,'黄山','黄山'));
	  			  				cur1.addBoard(new Board(1002,'六安','六安'));
	  			  				cur1.addBoard(new Board(1002,'马鞍山','马鞍山'));
	  			  				cur1.addBoard(new Board(1002,'宿州','宿州'));
	  			  				cur1.addBoard(new Board(1002,'铜陵','铜陵'));
	  			  				cur1.addBoard(new Board(1002,'芜湖','芜湖'));
	  			  				cur1.addBoard(new Board(1002,'宣城','宣城'));
	  			  				cur1.addBoard(new Board(1002,'亳州','亳州'));
	  		
         			cur1 = new Province('北京','北京');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1098,'北京','北京'));
	  		
         			cur1 = new Province('福建','福建');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  				cur1.addBoard(new Board(1103,'福州','福州'));
	  			  				cur1.addBoard(new Board(1103,'龙岩','龙岩'));
	  			  				cur1.addBoard(new Board(1103,'南平','南平'));
	  			  				cur1.addBoard(new Board(1103,'永州信息港','永州信息港'));
	  			  				cur1.addBoard(new Board(1103,'莆田','莆田'));
	  			  				cur1.addBoard(new Board(1103,'泉州','泉州'));
	  			  				cur1.addBoard(new Board(1103,'三明','三明'));
	  			  				cur1.addBoard(new Board(1103,'厦门','厦门'));
	  			  				cur1.addBoard(new Board(1103,'漳州','漳州'));
	  		
         			cur1 = new Province('甘肃','甘肃');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1181,'白银','白银'));
	  			  				cur1.addBoard(new Board(1181,'定西','定西'));
	  			  				cur1.addBoard(new Board(1181,'甘南藏族自治州','甘南藏族自治州'));
	  			  				cur1.addBoard(new Board(1181,'嘉峪关','嘉峪关'));
	  			  				cur1.addBoard(new Board(1181,'金昌','金昌'));
	  			  				cur1.addBoard(new Board(1181,'酒泉','酒泉'));
	  			  				cur1.addBoard(new Board(1181,'兰州','兰州'));
	  			  				cur1.addBoard(new Board(1181,'临夏回族自治州','临夏回族自治州'));
	  			  				cur1.addBoard(new Board(1181,'陇南','陇南'));
	  			  				cur1.addBoard(new Board(1181,'平凉','平凉'));
	  			  				cur1.addBoard(new Board(1181,'庆阳','庆阳'));
	  			  				cur1.addBoard(new Board(1181,'天水','天水'));
	  			  				cur1.addBoard(new Board(1181,'武威','武威'));
	  			  				cur1.addBoard(new Board(1181,'张掖','张掖'));
	  		
         			cur1 = new Province('广东','广东');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2614,'潮州','潮州'));
	  			  				cur1.addBoard(new Board(2614,'东莞','东莞'));
	  			  				cur1.addBoard(new Board(2614,'佛山','佛山'));
	  			  				cur1.addBoard(new Board(2614,'广州','广州'));
	  			  				cur1.addBoard(new Board(2614,'河源','河源'));
	  			  				cur1.addBoard(new Board(2614,'惠州','惠州'));
	  			  				cur1.addBoard(new Board(2614,'江门','江门'));
	  			  				cur1.addBoard(new Board(2614,'揭阳','揭阳'));
	  			  				cur1.addBoard(new Board(2614,'茂名','茂名'));
	  			  				cur1.addBoard(new Board(2614,'梅州','梅州'));
	  			  				cur1.addBoard(new Board(2614,'清远','清远'));
	  			  				cur1.addBoard(new Board(2614,'汕头','汕头'));
	  			  				cur1.addBoard(new Board(2614,'汕尾','汕尾'));
	  			  				cur1.addBoard(new Board(2614,'韶关','韶关'));
	  			  				cur1.addBoard(new Board(2614,'深圳','深圳'));
	  			  				cur1.addBoard(new Board(2614,'阳江','阳江'));
	  			  				cur1.addBoard(new Board(2614,'云浮','云浮'));
	  			  				cur1.addBoard(new Board(2614,'湛江','湛江'));
	  			  				cur1.addBoard(new Board(2614,'肇庆','肇庆'));
	  			  				cur1.addBoard(new Board(2614,'中山','中山'));
	  			  				cur1.addBoard(new Board(2614,'珠海','珠海'));
	  		
         			cur1 = new Province('广西','广西');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1277,'百色','百色'));
	  			  				cur1.addBoard(new Board(1277,'北海','北海'));
	  			  				cur1.addBoard(new Board(1277,'崇左','崇左'));
	  			  				cur1.addBoard(new Board(1277,'防城港','防城港'));
	  			  				cur1.addBoard(new Board(1277,'桂林','桂林'));
	  			  				cur1.addBoard(new Board(1277,'贵港','贵港'));
	  			  				cur1.addBoard(new Board(1277,'河池','河池'));
	  			  				cur1.addBoard(new Board(1277,'贺州','贺州'));
	  			  				cur1.addBoard(new Board(1277,'来宾','来宾'));
	  			  				cur1.addBoard(new Board(1277,'柳州','柳州'));
	  			  				cur1.addBoard(new Board(1277,'南宁','南宁'));
	  			  				cur1.addBoard(new Board(1277,'钦州','钦州'));
	  			  				cur1.addBoard(new Board(1277,'梧州','梧州'));
	  			  				cur1.addBoard(new Board(1277,'玉林','玉林'));
	  		
         			cur1 = new Province('贵州','贵州');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1382,'安顺','安顺'));
	  			  				cur1.addBoard(new Board(1382,'毕节','毕节'));
	  			  				cur1.addBoard(new Board(1382,'贵阳','贵阳'));
	  			  				cur1.addBoard(new Board(1382,'六盘水','六盘水'));
	  			  				cur1.addBoard(new Board(1382,'黔东南苗族侗族自治州','黔东南苗族侗族自治州'));
	  			  				cur1.addBoard(new Board(1382,'黔南布依族苗族自治州','黔南布依族苗族自治州'));
	  			  				cur1.addBoard(new Board(1382,'黔西南布依族苗族自治州','黔西南布依族苗族自治州'));
	  			  				cur1.addBoard(new Board(1382,'铜仁','铜仁'));
	  			  				cur1.addBoard(new Board(1382,'遵义','遵义'));
	  		
         			cur1 = new Province('海南','海南');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1474,'白沙黎族自治县','白沙黎族自治县'));
	  			  				cur1.addBoard(new Board(1474,'保亭黎族苗族自治县','保亭黎族苗族自治县'));
	  			  				cur1.addBoard(new Board(1474,'昌江黎族自治县','昌江黎族自治县'));
	  			  				cur1.addBoard(new Board(1474,'澄迈县','澄迈县'));
	  			  				cur1.addBoard(new Board(1474,'定安县','定安县'));
	  			  				cur1.addBoard(new Board(1474,'东方','东方'));
	  			  				cur1.addBoard(new Board(1474,'海口','海口'));
	  			  				cur1.addBoard(new Board(1474,'乐东黎族自治县','乐东黎族自治县'));
	  			  				cur1.addBoard(new Board(1474,'临高县','临高县'));
	  			  				cur1.addBoard(new Board(1474,'陵水黎族自治县','陵水黎族自治县'));
	  			  				cur1.addBoard(new Board(1474,'琼海','琼海'));
	  			  				cur1.addBoard(new Board(1474,'琼中黎族苗族自治县','琼中黎族苗族自治县'));
	  			  				cur1.addBoard(new Board(1474,'三亚','三亚'));
	  			  				cur1.addBoard(new Board(1474,'屯昌县','屯昌县'));
	  			  				cur1.addBoard(new Board(1474,'万宁','万宁'));
	  			  				cur1.addBoard(new Board(1474,'文昌','文昌'));
	  			  				cur1.addBoard(new Board(1474,'五指山','五指山'));
	  			  				cur1.addBoard(new Board(1474,'儋州','儋州'));
	  		
         			cur1 = new Province('河北','河北');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1511,'保定','保定'));
	  			  				cur1.addBoard(new Board(1511,'沧州','沧州'));
	  			  				cur1.addBoard(new Board(1511,'承德','承德'));
	  			  				cur1.addBoard(new Board(1511,'邯郸','邯郸'));
	  			  				cur1.addBoard(new Board(1511,'衡水','衡水'));
	  			  				cur1.addBoard(new Board(1511,'廊坊','廊坊'));
	  			  				cur1.addBoard(new Board(1511,'秦皇岛','秦皇岛'));
	  			  				cur1.addBoard(new Board(1511,'石家庄','石家庄'));
	  			  				cur1.addBoard(new Board(1511,'唐山','唐山'));
	  			  				cur1.addBoard(new Board(1511,'邢台','邢台'));
	  			  				cur1.addBoard(new Board(1511,'张家口','张家口'));
	  		
         			cur1 = new Province('河南','河南');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1670,'安阳','安阳'));
	  			  				cur1.addBoard(new Board(1670,'鹤壁','鹤壁'));
	  			  				cur1.addBoard(new Board(1670,'济源','济源'));
	  			  				cur1.addBoard(new Board(1670,'焦作','焦作'));
	  			  				cur1.addBoard(new Board(1670,'开封','开封'));
	  			  				cur1.addBoard(new Board(1670,'洛阳','洛阳'));
	  			  				cur1.addBoard(new Board(1670,'南阳','南阳'));
	  			  				cur1.addBoard(new Board(1670,'平顶山','平顶山'));
	  			  				cur1.addBoard(new Board(1670,'三门峡','三门峡'));
	  			  				cur1.addBoard(new Board(1670,'商丘','商丘'));
	  			  				cur1.addBoard(new Board(1670,'新乡','新乡'));
	  			  				cur1.addBoard(new Board(1670,'信阳','信阳'));
	  			  				cur1.addBoard(new Board(1670,'许昌','许昌'));
	  			  				cur1.addBoard(new Board(1670,'郑州','郑州'));
	  			  				cur1.addBoard(new Board(1670,'周口','周口'));
	  			  				cur1.addBoard(new Board(1670,'驻马店','驻马店'));
	  			  				cur1.addBoard(new Board(1670,'漯河','漯河'));
	  			  				cur1.addBoard(new Board(1670,'濮阳','濮阳'));
	  		
         			cur1 = new Province('黑龙江','黑龙江');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1816,'大庆','大庆'));
	  			  				cur1.addBoard(new Board(1816,'大兴安岭','大兴安岭'));
	  			  				cur1.addBoard(new Board(1816,'哈尔滨','哈尔滨'));
	  			  				cur1.addBoard(new Board(1816,'鹤岗','鹤岗'));
	  			  				cur1.addBoard(new Board(1816,'黑河','黑河'));
	  			  				cur1.addBoard(new Board(1816,'鸡西','鸡西'));
	  			  				cur1.addBoard(new Board(1816,'佳木斯','佳木斯'));
	  			  				cur1.addBoard(new Board(1816,'牡丹江','牡丹江'));
	  			  				cur1.addBoard(new Board(1816,'七台河','七台河'));
	  			  				cur1.addBoard(new Board(1816,'齐齐哈尔','齐齐哈尔'));
	  			  				cur1.addBoard(new Board(1816,'双鸭山','双鸭山'));
	  			  				cur1.addBoard(new Board(1816,'绥化','绥化'));
	  			  				cur1.addBoard(new Board(1816,'伊春','伊春'));
	  		
         			cur1 = new Province('湖北','湖北');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1908,'鄂州','鄂州'));
	  			  				cur1.addBoard(new Board(1908,'恩施土家族苗族自治州','恩施土家族苗族自治州'));
	  			  				cur1.addBoard(new Board(1908,'黄冈','黄冈'));
	  			  				cur1.addBoard(new Board(1908,'黄石','黄石'));
	  			  				cur1.addBoard(new Board(1908,'荆门','荆门'));
	  			  				cur1.addBoard(new Board(1908,'荆州','荆州'));
	  			  				cur1.addBoard(new Board(1908,'潜江','潜江'));
	  			  				cur1.addBoard(new Board(1908,'神农架林区','神农架林区'));
	  			  				cur1.addBoard(new Board(1908,'十堰','十堰'));
	  			  				cur1.addBoard(new Board(1908,'随州','随州'));
	  			  				cur1.addBoard(new Board(1908,'天门','天门'));
	  			  				cur1.addBoard(new Board(1908,'武汉','武汉'));
	  			  				cur1.addBoard(new Board(1908,'仙桃','仙桃'));
	  			  				cur1.addBoard(new Board(1908,'咸宁','咸宁'));
	  			  				cur1.addBoard(new Board(1908,'襄樊','襄樊'));
	  			  				cur1.addBoard(new Board(1908,'孝感','孝感'));
	  			  				cur1.addBoard(new Board(1908,'宜昌','宜昌'));
	  		
         			cur1 = new Province('湖南','湖南');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2002,'常德','常德'));
	  			  				cur1.addBoard(new Board(2002,'长沙','长沙'));
	  			  				cur1.addBoard(new Board(2002,'郴州','郴州'));
	  			  				cur1.addBoard(new Board(2002,'衡阳','衡阳'));
	  			  				cur1.addBoard(new Board(2002,'怀化','怀化'));
	  			  				cur1.addBoard(new Board(2002,'娄底','娄底'));
	  			  				cur1.addBoard(new Board(2002,'邵阳','邵阳'));
	  			  				cur1.addBoard(new Board(2002,'湘潭','湘潭'));
	  			  				cur1.addBoard(new Board(2002,'湘西土家族苗族自治州','湘西土家族苗族自治州'));
	  			  				cur1.addBoard(new Board(2002,'益阳','益阳'));
	  			  				cur1.addBoard(new Board(2002,'永州','永州'));
	  			  				cur1.addBoard(new Board(2002,'岳阳','岳阳'));
	  			  				cur1.addBoard(new Board(2002,'张家界','张家界'));
	  			  				cur1.addBoard(new Board(2002,'株洲','株洲'));
	  		
         			cur1 = new Province('吉林','吉林');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2118,'白城','白城'));
	  			  				cur1.addBoard(new Board(2118,'白山','白山'));
	  			  				cur1.addBoard(new Board(2118,'长春','长春'));
	  			  				cur1.addBoard(new Board(2118,'吉林','吉林'));
	  			  				cur1.addBoard(new Board(2118,'辽源','辽源'));
	  			  				cur1.addBoard(new Board(2118,'四平','四平'));
	  			  				cur1.addBoard(new Board(2118,'松原','松原'));
	  			  				cur1.addBoard(new Board(2118,'通化','通化'));
	  			  				cur1.addBoard(new Board(2118,'延边朝鲜族自治州','延边朝鲜族自治州'));
	  		
         			cur1 = new Province('江苏','江苏');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2177,'常州','常州'));
	  			  				cur1.addBoard(new Board(2177,'淮安','淮安'));
	  			  				cur1.addBoard(new Board(2177,'连云港','连云港'));
	  			  				cur1.addBoard(new Board(2177,'南京','南京'));
	  			  				cur1.addBoard(new Board(2177,'南通','南通'));
	  			  				cur1.addBoard(new Board(2177,'苏州','苏州'));
	  			  				cur1.addBoard(new Board(2177,'宿迁','宿迁'));
	  			  				cur1.addBoard(new Board(2177,'泰州','泰州'));
	  			  				cur1.addBoard(new Board(2177,'无锡','无锡'));
	  			  				cur1.addBoard(new Board(2177,'徐州','徐州'));
	  			  				cur1.addBoard(new Board(2177,'盐城','盐城'));
	  			  				cur1.addBoard(new Board(2177,'扬州','扬州'));
	  			  				cur1.addBoard(new Board(2177,'镇江','镇江'));
	  		
         			cur1 = new Province('江西','江西');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2258,'抚州','抚州'));
	  			  				cur1.addBoard(new Board(2258,'赣州','赣州'));
	  			  				cur1.addBoard(new Board(2258,'吉安','吉安'));
	  			  				cur1.addBoard(new Board(2258,'景德镇','景德镇'));
	  			  				cur1.addBoard(new Board(2258,'九江','九江'));
	  			  				cur1.addBoard(new Board(2258,'南昌','南昌'));
	  			  				cur1.addBoard(new Board(2258,'萍乡','萍乡'));
	  			  				cur1.addBoard(new Board(2258,'上饶','上饶'));
	  			  				cur1.addBoard(new Board(2258,'新余','新余'));
	  			  				cur1.addBoard(new Board(2258,'宜春','宜春'));
	  			  				cur1.addBoard(new Board(2258,'鹰潭','鹰潭'));
	  		
         			cur1 = new Province('辽宁','辽宁');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2361,'鞍山','鞍山'));
	  			  				cur1.addBoard(new Board(2361,'本溪','本溪'));
	  			  				cur1.addBoard(new Board(2361,'朝阳','朝阳'));
	  			  				cur1.addBoard(new Board(2361,'大连','大连'));
	  			  				cur1.addBoard(new Board(2361,'丹东','丹东'));
	  			  				cur1.addBoard(new Board(2361,'抚顺','抚顺'));
	  			  				cur1.addBoard(new Board(2361,'阜新','阜新'));
	  			  				cur1.addBoard(new Board(2361,'葫芦岛','葫芦岛'));
	  			  				cur1.addBoard(new Board(2361,'锦州','锦州'));
	  			  				cur1.addBoard(new Board(2361,'辽阳','辽阳'));
	  			  				cur1.addBoard(new Board(2361,'盘锦','盘锦'));
	  			  				cur1.addBoard(new Board(2361,'沈阳','沈阳'));
	  			  				cur1.addBoard(new Board(2361,'铁岭','铁岭'));
	  			  				cur1.addBoard(new Board(2361,'营口','营口'));
	  		
         			cur1 = new Province('内蒙古','内蒙古');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2434,'阿拉善盟','阿拉善盟'));
	  			  				cur1.addBoard(new Board(2434,'巴彦淖尔盟','巴彦淖尔盟'));
	  			  				cur1.addBoard(new Board(2434,'包头','包头'));
	  			  				cur1.addBoard(new Board(2434,'赤峰','赤峰'));
	  			  				cur1.addBoard(new Board(2434,'鄂尔多斯','鄂尔多斯'));
	  			  				cur1.addBoard(new Board(2434,'呼和浩特','呼和浩特'));
	  			  				cur1.addBoard(new Board(2434,'呼伦贝尔','呼伦贝尔'));
	  			  				cur1.addBoard(new Board(2434,'通辽','通辽'));
	  			  				cur1.addBoard(new Board(2434,'乌海','乌海'));
	  			  				cur1.addBoard(new Board(2434,'乌兰察布盟','乌兰察布盟'));
	  			  				cur1.addBoard(new Board(2434,'锡林郭勒盟','锡林郭勒盟'));
	  			  				cur1.addBoard(new Board(2434,'兴安盟','兴安盟'));
	  		
         			cur1 = new Province('宁夏','宁夏');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2536,'固原','固原'));
	  			  				cur1.addBoard(new Board(2536,'石嘴山','石嘴山'));
	  			  				cur1.addBoard(new Board(2536,'吴忠','吴忠'));
	  			  				cur1.addBoard(new Board(2536,'银川','银川'));
	  		
         			cur1 = new Province('青海','青海');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2561,'果洛藏族自治州','果洛藏族自治州'));
	  			  				cur1.addBoard(new Board(2561,'海北藏族自治州','海北藏族自治州'));
	  			  				cur1.addBoard(new Board(2561,'海东','海东'));
	  			  				cur1.addBoard(new Board(2561,'海南藏族自治州','海南藏族自治州'));
	  			  				cur1.addBoard(new Board(2561,'海西蒙古族藏族自治州','海西蒙古族藏族自治州'));
	  			  				cur1.addBoard(new Board(2561,'黄南藏族自治州','黄南藏族自治州'));
	  			  				cur1.addBoard(new Board(2561,'西宁','西宁'));
	  			  				cur1.addBoard(new Board(2561,'玉树藏族自治州','玉树藏族自治州'));
	  		
         			cur1 = new Province('山东','山东');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2847,'滨州','滨州'));
	  			  				cur1.addBoard(new Board(2847,'德州','德州'));
	  			  				cur1.addBoard(new Board(2847,'东营','东营'));
	  			  				cur1.addBoard(new Board(2847,'菏泽','菏泽'));
	  			  				cur1.addBoard(new Board(2847,'济南','济南'));
	  			  				cur1.addBoard(new Board(2847,'济宁','济宁'));
	  			  				cur1.addBoard(new Board(2847,'莱芜','莱芜'));
	  			  				cur1.addBoard(new Board(2847,'聊城','聊城'));
	  			  				cur1.addBoard(new Board(2847,'临沂','临沂'));
	  			  				cur1.addBoard(new Board(2847,'青岛','青岛'));
	  			  				cur1.addBoard(new Board(2847,'日照','日照'));
	  			  				cur1.addBoard(new Board(2847,'泰安','泰安'));
	  			  				cur1.addBoard(new Board(2847,'威海','威海'));
	  			  				cur1.addBoard(new Board(2847,'潍坊','潍坊'));
	  			  				cur1.addBoard(new Board(2847,'烟台','烟台'));
	  			  				cur1.addBoard(new Board(2847,'枣庄','枣庄'));
	  			  				cur1.addBoard(new Board(2847,'淄博','淄博'));
	  		
         			cur1 = new Province('山西','山西');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2728,'长治','长治'));
	  			  				cur1.addBoard(new Board(2728,'大同','大同'));
	  			  				cur1.addBoard(new Board(2728,'晋城','晋城'));
	  			  				cur1.addBoard(new Board(2728,'晋中','晋中'));
	  			  				cur1.addBoard(new Board(2728,'临汾','临汾'));
	  			  				cur1.addBoard(new Board(2728,'吕梁','吕梁'));
	  			  				cur1.addBoard(new Board(2728,'朔州','朔州'));
	  			  				cur1.addBoard(new Board(2728,'太原','太原'));
	  			  				cur1.addBoard(new Board(2728,'忻州','忻州'));
	  			  				cur1.addBoard(new Board(2728,'阳泉','阳泉'));
	  			  				cur1.addBoard(new Board(2728,'运城','运城'));
	  		
         			cur1 = new Province('陕西','陕西');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2973,'安康','安康'));
	  			  				cur1.addBoard(new Board(2973,'宝鸡','宝鸡'));
	  			  				cur1.addBoard(new Board(2973,'汉中','汉中'));
	  			  				cur1.addBoard(new Board(2973,'商洛','商洛'));
	  			  				cur1.addBoard(new Board(2973,'铜川','铜川'));
	  			  				cur1.addBoard(new Board(2973,'渭南','渭南'));
	  			  				cur1.addBoard(new Board(2973,'西安','西安'));
	  			  				cur1.addBoard(new Board(2973,'咸阳','咸阳'));
	  			  				cur1.addBoard(new Board(2973,'延安','延安'));
	  			  				cur1.addBoard(new Board(2973,'榆林','榆林'));
	  		
         			cur1 = new Province('上海','上海');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2610,'上海','上海'));
	  		
         			cur1 = new Province('四川','四川');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3078,'阿坝藏族羌族自治州','阿坝藏族羌族自治州'));
	  			  				cur1.addBoard(new Board(3078,'巴中','巴中'));
	  			  				cur1.addBoard(new Board(3078,'成都','成都'));
	  			  				cur1.addBoard(new Board(3078,'永州','永州'));
	  			  				cur1.addBoard(new Board(3078,'德阳','德阳'));
	  			  				cur1.addBoard(new Board(3078,'甘孜藏族自治州','甘孜藏族自治州'));
	  			  				cur1.addBoard(new Board(3078,'广安','广安'));
	  			  				cur1.addBoard(new Board(3078,'广元','广元'));
	  			  				cur1.addBoard(new Board(3078,'乐山','乐山'));
	  			  				cur1.addBoard(new Board(3078,'凉山彝族自治州','凉山彝族自治州'));
	  			  				cur1.addBoard(new Board(3078,'眉山','眉山'));
	  			  				cur1.addBoard(new Board(3078,'绵阳','绵阳'));
	  			  				cur1.addBoard(new Board(3078,'南充','南充'));
	  			  				cur1.addBoard(new Board(3078,'内江','内江'));
	  			  				cur1.addBoard(new Board(3078,'攀枝花','攀枝花'));
	  			  				cur1.addBoard(new Board(3078,'遂宁','遂宁'));
	  			  				cur1.addBoard(new Board(3078,'雅安','雅安'));
	  			  				cur1.addBoard(new Board(3078,'宜宾','宜宾'));
	  			  				cur1.addBoard(new Board(3078,'资阳','资阳'));
	  			  				cur1.addBoard(new Board(3078,'自贡','自贡'));
	  			  				cur1.addBoard(new Board(3078,'泸州','泸州'));
	  		
         			cur1 = new Province('天津','天津');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3256,'天津','天津'));
	  		
         			cur1 = new Province('西藏','西藏');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3290,'阿里','阿里'));
	  			  				cur1.addBoard(new Board(3290,'昌都','昌都'));
	  			  				cur1.addBoard(new Board(3290,'拉萨','拉萨'));
	  			  				cur1.addBoard(new Board(3290,'林芝','林芝'));
	  			  				cur1.addBoard(new Board(3290,'那曲','那曲'));
	  			  				cur1.addBoard(new Board(3290,'日喀则','日喀则'));
	  			  				cur1.addBoard(new Board(3290,'山南','山南'));
	  		
         			cur1 = new Province('新疆','新疆');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3371,'阿克苏','阿克苏'));
	  			  				cur1.addBoard(new Board(3371,'阿拉尔','阿拉尔'));
	  			  				cur1.addBoard(new Board(3371,'巴音郭楞蒙古自治州','巴音郭楞蒙古自治州'));
	  			  				cur1.addBoard(new Board(3371,'博尔塔拉蒙古自治州','博尔塔拉蒙古自治州'));
	  			  				cur1.addBoard(new Board(3371,'昌吉回族自治州','昌吉回族自治州'));
	  			  				cur1.addBoard(new Board(3371,'哈密','哈密'));
	  			  				cur1.addBoard(new Board(3371,'和田','和田'));
	  			  				cur1.addBoard(new Board(3371,'喀什','喀什'));
	  			  				cur1.addBoard(new Board(3371,'克拉玛依','克拉玛依'));
	  			  				cur1.addBoard(new Board(3371,'克孜勒苏柯尔克孜自治州','克孜勒苏柯尔克孜自治州'));
	  			  				cur1.addBoard(new Board(3371,'石河子','石河子'));
	  			  				cur1.addBoard(new Board(3371,'图木舒克','图木舒克'));
	  			  				cur1.addBoard(new Board(3371,'吐鲁番','吐鲁番'));
	  			  				cur1.addBoard(new Board(3371,'乌鲁木齐','乌鲁木齐'));
	  			  				cur1.addBoard(new Board(3371,'五家渠','五家渠'));
	  			  				cur1.addBoard(new Board(3371,'伊犁哈萨克自治州','伊犁哈萨克自治州'));
	  		
         			cur1 = new Province('云南','云南');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3559,'保山','保山'));
	  			  				cur1.addBoard(new Board(3559,'楚雄彝族自治州','楚雄彝族自治州'));
	  			  				cur1.addBoard(new Board(3559,'大理白族自治州','大理白族自治州'));
	  			  				cur1.addBoard(new Board(3559,'德宏傣族景颇族自治州','德宏傣族景颇族自治州'));
	  			  				cur1.addBoard(new Board(3559,'迪庆藏族自治州','迪庆藏族自治州'));
	  			  				cur1.addBoard(new Board(3559,'红河哈尼族彝族自治州','红河哈尼族彝族自治州'));
	  			  				cur1.addBoard(new Board(3559,'昆明','昆明'));
	  			  				cur1.addBoard(new Board(3559,'丽江','丽江'));
	  			  				cur1.addBoard(new Board(3559,'临沧','临沧'));
	  			  				cur1.addBoard(new Board(3559,'怒江傈傈族自治州','怒江傈傈族自治州'));
	  			  				cur1.addBoard(new Board(3559,'曲靖','曲靖'));
	  			  				cur1.addBoard(new Board(3559,'思茅','思茅'));
	  			  				cur1.addBoard(new Board(3559,'文山壮族苗族自治州','文山壮族苗族自治州'));
	  			  				cur1.addBoard(new Board(3559,'西双版纳傣族自治州','西双版纳傣族自治州'));
	  			  				cur1.addBoard(new Board(3559,'玉溪','玉溪'));
	  			  				cur1.addBoard(new Board(3559,'昭通','昭通'));
	  		
         			cur1 = new Province('浙江','浙江');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3478,'永州','永州'));
	  			  				cur1.addBoard(new Board(3478,'湖州','湖州'));
	  			  				cur1.addBoard(new Board(3478,'嘉兴','嘉兴'));
	  			  				cur1.addBoard(new Board(3478,'金华','金华'));
	  			  				cur1.addBoard(new Board(3478,'丽水','丽水'));
	  			  				cur1.addBoard(new Board(3478,'宁波','宁波'));
	  			  				cur1.addBoard(new Board(3478,'绍兴','绍兴'));
	  			  				cur1.addBoard(new Board(3478,'台州','台州'));
	  			  				cur1.addBoard(new Board(3478,'温州','温州'));
	  			  				cur1.addBoard(new Board(3478,'舟山','舟山'));
	  			  				cur1.addBoard(new Board(3478,'衢州','衢州'));
	  		
         			cur1 = new Province('重庆','重庆');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3262,'重庆','重庆'));
	  		
         	
	//init catform1
	var catForm1 = document.all.province;
	var boardForm1 = document.all.city;

