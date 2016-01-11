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
		//������ҵ�ѡ��Ϊ���й���½������ʡ��������ֵ��Ϊ��
		if (list.options[list.selectedIndex].value != "CN"){//����ʡ��������ֵΪ��
			if (list.options[list.selectedIndex].value == "Other"){
				//���ѡ���������Һ͵����������г����й���
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
		//������ҵ�ѡ��Ϊ���й���½������ʡ��������ֵ��Ϊ��
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

        //ȡʡ�ݡ�����
			    cur1 = new Province('����','����');
	  		    catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1002,'����','����'));
	  			  				cur1.addBoard(new Board(1002,'����','����'));
	  			  				cur1.addBoard(new Board(1002,'����','����'));
	  			  				cur1.addBoard(new Board(1002,'����','����'));
	  			  				cur1.addBoard(new Board(1002,'����','����'));
	  			  				cur1.addBoard(new Board(1002,'����','����'));
	  			  				cur1.addBoard(new Board(1002,'�Ϸ�','�Ϸ�'));
	  			  				cur1.addBoard(new Board(1002,'����','����'));
	  			  				cur1.addBoard(new Board(1002,'����','����'));
	  			  				cur1.addBoard(new Board(1002,'��ɽ','��ɽ'));
	  			  				cur1.addBoard(new Board(1002,'����','����'));
	  			  				cur1.addBoard(new Board(1002,'��ɽ','��ɽ'));
	  			  				cur1.addBoard(new Board(1002,'����','����'));
	  			  				cur1.addBoard(new Board(1002,'ͭ��','ͭ��'));
	  			  				cur1.addBoard(new Board(1002,'�ߺ�','�ߺ�'));
	  			  				cur1.addBoard(new Board(1002,'����','����'));
	  			  				cur1.addBoard(new Board(1002,'����','����'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1098,'����','����'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  				cur1.addBoard(new Board(1103,'����','����'));
	  			  				cur1.addBoard(new Board(1103,'����','����'));
	  			  				cur1.addBoard(new Board(1103,'��ƽ','��ƽ'));
	  			  				cur1.addBoard(new Board(1103,'������Ϣ��','������Ϣ��'));
	  			  				cur1.addBoard(new Board(1103,'����','����'));
	  			  				cur1.addBoard(new Board(1103,'Ȫ��','Ȫ��'));
	  			  				cur1.addBoard(new Board(1103,'����','����'));
	  			  				cur1.addBoard(new Board(1103,'����','����'));
	  			  				cur1.addBoard(new Board(1103,'����','����'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1181,'����','����'));
	  			  				cur1.addBoard(new Board(1181,'����','����'));
	  			  				cur1.addBoard(new Board(1181,'���ϲ���������','���ϲ���������'));
	  			  				cur1.addBoard(new Board(1181,'������','������'));
	  			  				cur1.addBoard(new Board(1181,'���','���'));
	  			  				cur1.addBoard(new Board(1181,'��Ȫ','��Ȫ'));
	  			  				cur1.addBoard(new Board(1181,'����','����'));
	  			  				cur1.addBoard(new Board(1181,'���Ļ���������','���Ļ���������'));
	  			  				cur1.addBoard(new Board(1181,'¤��','¤��'));
	  			  				cur1.addBoard(new Board(1181,'ƽ��','ƽ��'));
	  			  				cur1.addBoard(new Board(1181,'����','����'));
	  			  				cur1.addBoard(new Board(1181,'��ˮ','��ˮ'));
	  			  				cur1.addBoard(new Board(1181,'����','����'));
	  			  				cur1.addBoard(new Board(1181,'��Ҵ','��Ҵ'));
	  		
         			cur1 = new Province('�㶫','�㶫');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2614,'����','����'));
	  			  				cur1.addBoard(new Board(2614,'��ݸ','��ݸ'));
	  			  				cur1.addBoard(new Board(2614,'��ɽ','��ɽ'));
	  			  				cur1.addBoard(new Board(2614,'����','����'));
	  			  				cur1.addBoard(new Board(2614,'��Դ','��Դ'));
	  			  				cur1.addBoard(new Board(2614,'����','����'));
	  			  				cur1.addBoard(new Board(2614,'����','����'));
	  			  				cur1.addBoard(new Board(2614,'����','����'));
	  			  				cur1.addBoard(new Board(2614,'ï��','ï��'));
	  			  				cur1.addBoard(new Board(2614,'÷��','÷��'));
	  			  				cur1.addBoard(new Board(2614,'��Զ','��Զ'));
	  			  				cur1.addBoard(new Board(2614,'��ͷ','��ͷ'));
	  			  				cur1.addBoard(new Board(2614,'��β','��β'));
	  			  				cur1.addBoard(new Board(2614,'�ع�','�ع�'));
	  			  				cur1.addBoard(new Board(2614,'����','����'));
	  			  				cur1.addBoard(new Board(2614,'����','����'));
	  			  				cur1.addBoard(new Board(2614,'�Ƹ�','�Ƹ�'));
	  			  				cur1.addBoard(new Board(2614,'տ��','տ��'));
	  			  				cur1.addBoard(new Board(2614,'����','����'));
	  			  				cur1.addBoard(new Board(2614,'��ɽ','��ɽ'));
	  			  				cur1.addBoard(new Board(2614,'�麣','�麣'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1277,'��ɫ','��ɫ'));
	  			  				cur1.addBoard(new Board(1277,'����','����'));
	  			  				cur1.addBoard(new Board(1277,'����','����'));
	  			  				cur1.addBoard(new Board(1277,'���Ǹ�','���Ǹ�'));
	  			  				cur1.addBoard(new Board(1277,'����','����'));
	  			  				cur1.addBoard(new Board(1277,'���','���'));
	  			  				cur1.addBoard(new Board(1277,'�ӳ�','�ӳ�'));
	  			  				cur1.addBoard(new Board(1277,'����','����'));
	  			  				cur1.addBoard(new Board(1277,'����','����'));
	  			  				cur1.addBoard(new Board(1277,'����','����'));
	  			  				cur1.addBoard(new Board(1277,'����','����'));
	  			  				cur1.addBoard(new Board(1277,'����','����'));
	  			  				cur1.addBoard(new Board(1277,'����','����'));
	  			  				cur1.addBoard(new Board(1277,'����','����'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1382,'��˳','��˳'));
	  			  				cur1.addBoard(new Board(1382,'�Ͻ�','�Ͻ�'));
	  			  				cur1.addBoard(new Board(1382,'����','����'));
	  			  				cur1.addBoard(new Board(1382,'����ˮ','����ˮ'));
	  			  				cur1.addBoard(new Board(1382,'ǭ�������嶱��������','ǭ�������嶱��������'));
	  			  				cur1.addBoard(new Board(1382,'ǭ�ϲ���������������','ǭ�ϲ���������������'));
	  			  				cur1.addBoard(new Board(1382,'ǭ���ϲ���������������','ǭ���ϲ���������������'));
	  			  				cur1.addBoard(new Board(1382,'ͭ��','ͭ��'));
	  			  				cur1.addBoard(new Board(1382,'����','����'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1474,'��ɳ����������','��ɳ����������'));
	  			  				cur1.addBoard(new Board(1474,'��ͤ��������������','��ͤ��������������'));
	  			  				cur1.addBoard(new Board(1474,'��������������','��������������'));
	  			  				cur1.addBoard(new Board(1474,'������','������'));
	  			  				cur1.addBoard(new Board(1474,'������','������'));
	  			  				cur1.addBoard(new Board(1474,'����','����'));
	  			  				cur1.addBoard(new Board(1474,'����','����'));
	  			  				cur1.addBoard(new Board(1474,'�ֶ�����������','�ֶ�����������'));
	  			  				cur1.addBoard(new Board(1474,'�ٸ���','�ٸ���'));
	  			  				cur1.addBoard(new Board(1474,'��ˮ����������','��ˮ����������'));
	  			  				cur1.addBoard(new Board(1474,'��','��'));
	  			  				cur1.addBoard(new Board(1474,'������������������','������������������'));
	  			  				cur1.addBoard(new Board(1474,'����','����'));
	  			  				cur1.addBoard(new Board(1474,'�Ͳ���','�Ͳ���'));
	  			  				cur1.addBoard(new Board(1474,'����','����'));
	  			  				cur1.addBoard(new Board(1474,'�Ĳ�','�Ĳ�'));
	  			  				cur1.addBoard(new Board(1474,'��ָɽ','��ָɽ'));
	  			  				cur1.addBoard(new Board(1474,'����','����'));
	  		
         			cur1 = new Province('�ӱ�','�ӱ�');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1511,'����','����'));
	  			  				cur1.addBoard(new Board(1511,'����','����'));
	  			  				cur1.addBoard(new Board(1511,'�е�','�е�'));
	  			  				cur1.addBoard(new Board(1511,'����','����'));
	  			  				cur1.addBoard(new Board(1511,'��ˮ','��ˮ'));
	  			  				cur1.addBoard(new Board(1511,'�ȷ�','�ȷ�'));
	  			  				cur1.addBoard(new Board(1511,'�ػʵ�','�ػʵ�'));
	  			  				cur1.addBoard(new Board(1511,'ʯ��ׯ','ʯ��ׯ'));
	  			  				cur1.addBoard(new Board(1511,'��ɽ','��ɽ'));
	  			  				cur1.addBoard(new Board(1511,'��̨','��̨'));
	  			  				cur1.addBoard(new Board(1511,'�żҿ�','�żҿ�'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1670,'����','����'));
	  			  				cur1.addBoard(new Board(1670,'�ױ�','�ױ�'));
	  			  				cur1.addBoard(new Board(1670,'��Դ','��Դ'));
	  			  				cur1.addBoard(new Board(1670,'����','����'));
	  			  				cur1.addBoard(new Board(1670,'����','����'));
	  			  				cur1.addBoard(new Board(1670,'����','����'));
	  			  				cur1.addBoard(new Board(1670,'����','����'));
	  			  				cur1.addBoard(new Board(1670,'ƽ��ɽ','ƽ��ɽ'));
	  			  				cur1.addBoard(new Board(1670,'����Ͽ','����Ͽ'));
	  			  				cur1.addBoard(new Board(1670,'����','����'));
	  			  				cur1.addBoard(new Board(1670,'����','����'));
	  			  				cur1.addBoard(new Board(1670,'����','����'));
	  			  				cur1.addBoard(new Board(1670,'���','���'));
	  			  				cur1.addBoard(new Board(1670,'֣��','֣��'));
	  			  				cur1.addBoard(new Board(1670,'�ܿ�','�ܿ�'));
	  			  				cur1.addBoard(new Board(1670,'פ���','פ���'));
	  			  				cur1.addBoard(new Board(1670,'���','���'));
	  			  				cur1.addBoard(new Board(1670,'���','���'));
	  		
         			cur1 = new Province('������','������');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1816,'����','����'));
	  			  				cur1.addBoard(new Board(1816,'���˰���','���˰���'));
	  			  				cur1.addBoard(new Board(1816,'������','������'));
	  			  				cur1.addBoard(new Board(1816,'�׸�','�׸�'));
	  			  				cur1.addBoard(new Board(1816,'�ں�','�ں�'));
	  			  				cur1.addBoard(new Board(1816,'����','����'));
	  			  				cur1.addBoard(new Board(1816,'��ľ˹','��ľ˹'));
	  			  				cur1.addBoard(new Board(1816,'ĵ����','ĵ����'));
	  			  				cur1.addBoard(new Board(1816,'��̨��','��̨��'));
	  			  				cur1.addBoard(new Board(1816,'�������','�������'));
	  			  				cur1.addBoard(new Board(1816,'˫Ѽɽ','˫Ѽɽ'));
	  			  				cur1.addBoard(new Board(1816,'�绯','�绯'));
	  			  				cur1.addBoard(new Board(1816,'����','����'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(1908,'����','����'));
	  			  				cur1.addBoard(new Board(1908,'��ʩ����������������','��ʩ����������������'));
	  			  				cur1.addBoard(new Board(1908,'�Ƹ�','�Ƹ�'));
	  			  				cur1.addBoard(new Board(1908,'��ʯ','��ʯ'));
	  			  				cur1.addBoard(new Board(1908,'����','����'));
	  			  				cur1.addBoard(new Board(1908,'����','����'));
	  			  				cur1.addBoard(new Board(1908,'Ǳ��','Ǳ��'));
	  			  				cur1.addBoard(new Board(1908,'��ũ������','��ũ������'));
	  			  				cur1.addBoard(new Board(1908,'ʮ��','ʮ��'));
	  			  				cur1.addBoard(new Board(1908,'����','����'));
	  			  				cur1.addBoard(new Board(1908,'����','����'));
	  			  				cur1.addBoard(new Board(1908,'�人','�人'));
	  			  				cur1.addBoard(new Board(1908,'����','����'));
	  			  				cur1.addBoard(new Board(1908,'����','����'));
	  			  				cur1.addBoard(new Board(1908,'�差','�差'));
	  			  				cur1.addBoard(new Board(1908,'Т��','Т��'));
	  			  				cur1.addBoard(new Board(1908,'�˲�','�˲�'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2002,'����','����'));
	  			  				cur1.addBoard(new Board(2002,'��ɳ','��ɳ'));
	  			  				cur1.addBoard(new Board(2002,'����','����'));
	  			  				cur1.addBoard(new Board(2002,'����','����'));
	  			  				cur1.addBoard(new Board(2002,'����','����'));
	  			  				cur1.addBoard(new Board(2002,'¦��','¦��'));
	  			  				cur1.addBoard(new Board(2002,'����','����'));
	  			  				cur1.addBoard(new Board(2002,'��̶','��̶'));
	  			  				cur1.addBoard(new Board(2002,'��������������������','��������������������'));
	  			  				cur1.addBoard(new Board(2002,'����','����'));
	  			  				cur1.addBoard(new Board(2002,'����','����'));
	  			  				cur1.addBoard(new Board(2002,'����','����'));
	  			  				cur1.addBoard(new Board(2002,'�żҽ�','�żҽ�'));
	  			  				cur1.addBoard(new Board(2002,'����','����'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2118,'�׳�','�׳�'));
	  			  				cur1.addBoard(new Board(2118,'��ɽ','��ɽ'));
	  			  				cur1.addBoard(new Board(2118,'����','����'));
	  			  				cur1.addBoard(new Board(2118,'����','����'));
	  			  				cur1.addBoard(new Board(2118,'��Դ','��Դ'));
	  			  				cur1.addBoard(new Board(2118,'��ƽ','��ƽ'));
	  			  				cur1.addBoard(new Board(2118,'��ԭ','��ԭ'));
	  			  				cur1.addBoard(new Board(2118,'ͨ��','ͨ��'));
	  			  				cur1.addBoard(new Board(2118,'�ӱ߳�����������','�ӱ߳�����������'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2177,'����','����'));
	  			  				cur1.addBoard(new Board(2177,'����','����'));
	  			  				cur1.addBoard(new Board(2177,'���Ƹ�','���Ƹ�'));
	  			  				cur1.addBoard(new Board(2177,'�Ͼ�','�Ͼ�'));
	  			  				cur1.addBoard(new Board(2177,'��ͨ','��ͨ'));
	  			  				cur1.addBoard(new Board(2177,'����','����'));
	  			  				cur1.addBoard(new Board(2177,'��Ǩ','��Ǩ'));
	  			  				cur1.addBoard(new Board(2177,'̩��','̩��'));
	  			  				cur1.addBoard(new Board(2177,'����','����'));
	  			  				cur1.addBoard(new Board(2177,'����','����'));
	  			  				cur1.addBoard(new Board(2177,'�γ�','�γ�'));
	  			  				cur1.addBoard(new Board(2177,'����','����'));
	  			  				cur1.addBoard(new Board(2177,'��','��'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2258,'����','����'));
	  			  				cur1.addBoard(new Board(2258,'����','����'));
	  			  				cur1.addBoard(new Board(2258,'����','����'));
	  			  				cur1.addBoard(new Board(2258,'������','������'));
	  			  				cur1.addBoard(new Board(2258,'�Ž�','�Ž�'));
	  			  				cur1.addBoard(new Board(2258,'�ϲ�','�ϲ�'));
	  			  				cur1.addBoard(new Board(2258,'Ƽ��','Ƽ��'));
	  			  				cur1.addBoard(new Board(2258,'����','����'));
	  			  				cur1.addBoard(new Board(2258,'����','����'));
	  			  				cur1.addBoard(new Board(2258,'�˴�','�˴�'));
	  			  				cur1.addBoard(new Board(2258,'ӥ̶','ӥ̶'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2361,'��ɽ','��ɽ'));
	  			  				cur1.addBoard(new Board(2361,'��Ϫ','��Ϫ'));
	  			  				cur1.addBoard(new Board(2361,'����','����'));
	  			  				cur1.addBoard(new Board(2361,'����','����'));
	  			  				cur1.addBoard(new Board(2361,'����','����'));
	  			  				cur1.addBoard(new Board(2361,'��˳','��˳'));
	  			  				cur1.addBoard(new Board(2361,'����','����'));
	  			  				cur1.addBoard(new Board(2361,'��«��','��«��'));
	  			  				cur1.addBoard(new Board(2361,'����','����'));
	  			  				cur1.addBoard(new Board(2361,'����','����'));
	  			  				cur1.addBoard(new Board(2361,'�̽�','�̽�'));
	  			  				cur1.addBoard(new Board(2361,'����','����'));
	  			  				cur1.addBoard(new Board(2361,'����','����'));
	  			  				cur1.addBoard(new Board(2361,'Ӫ��','Ӫ��'));
	  		
         			cur1 = new Province('���ɹ�','���ɹ�');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2434,'��������','��������'));
	  			  				cur1.addBoard(new Board(2434,'�����׶���','�����׶���'));
	  			  				cur1.addBoard(new Board(2434,'��ͷ','��ͷ'));
	  			  				cur1.addBoard(new Board(2434,'���','���'));
	  			  				cur1.addBoard(new Board(2434,'������˹','������˹'));
	  			  				cur1.addBoard(new Board(2434,'���ͺ���','���ͺ���'));
	  			  				cur1.addBoard(new Board(2434,'���ױ���','���ױ���'));
	  			  				cur1.addBoard(new Board(2434,'ͨ��','ͨ��'));
	  			  				cur1.addBoard(new Board(2434,'�ں�','�ں�'));
	  			  				cur1.addBoard(new Board(2434,'�����첼��','�����첼��'));
	  			  				cur1.addBoard(new Board(2434,'���ֹ�����','���ֹ�����'));
	  			  				cur1.addBoard(new Board(2434,'�˰���','�˰���'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2536,'��ԭ','��ԭ'));
	  			  				cur1.addBoard(new Board(2536,'ʯ��ɽ','ʯ��ɽ'));
	  			  				cur1.addBoard(new Board(2536,'����','����'));
	  			  				cur1.addBoard(new Board(2536,'����','����'));
	  		
         			cur1 = new Province('�ຣ','�ຣ');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2561,'�������������','�������������'));
	  			  				cur1.addBoard(new Board(2561,'��������������','��������������'));
	  			  				cur1.addBoard(new Board(2561,'����','����'));
	  			  				cur1.addBoard(new Board(2561,'���ϲ���������','���ϲ���������'));
	  			  				cur1.addBoard(new Board(2561,'�����ɹ������������','�����ɹ������������'));
	  			  				cur1.addBoard(new Board(2561,'���ϲ���������','���ϲ���������'));
	  			  				cur1.addBoard(new Board(2561,'����','����'));
	  			  				cur1.addBoard(new Board(2561,'��������������','��������������'));
	  		
         			cur1 = new Province('ɽ��','ɽ��');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2847,'����','����'));
	  			  				cur1.addBoard(new Board(2847,'����','����'));
	  			  				cur1.addBoard(new Board(2847,'��Ӫ','��Ӫ'));
	  			  				cur1.addBoard(new Board(2847,'����','����'));
	  			  				cur1.addBoard(new Board(2847,'����','����'));
	  			  				cur1.addBoard(new Board(2847,'����','����'));
	  			  				cur1.addBoard(new Board(2847,'����','����'));
	  			  				cur1.addBoard(new Board(2847,'�ĳ�','�ĳ�'));
	  			  				cur1.addBoard(new Board(2847,'����','����'));
	  			  				cur1.addBoard(new Board(2847,'�ൺ','�ൺ'));
	  			  				cur1.addBoard(new Board(2847,'����','����'));
	  			  				cur1.addBoard(new Board(2847,'̩��','̩��'));
	  			  				cur1.addBoard(new Board(2847,'����','����'));
	  			  				cur1.addBoard(new Board(2847,'Ϋ��','Ϋ��'));
	  			  				cur1.addBoard(new Board(2847,'��̨','��̨'));
	  			  				cur1.addBoard(new Board(2847,'��ׯ','��ׯ'));
	  			  				cur1.addBoard(new Board(2847,'�Ͳ�','�Ͳ�'));
	  		
         			cur1 = new Province('ɽ��','ɽ��');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2728,'����','����'));
	  			  				cur1.addBoard(new Board(2728,'��ͬ','��ͬ'));
	  			  				cur1.addBoard(new Board(2728,'����','����'));
	  			  				cur1.addBoard(new Board(2728,'����','����'));
	  			  				cur1.addBoard(new Board(2728,'�ٷ�','�ٷ�'));
	  			  				cur1.addBoard(new Board(2728,'����','����'));
	  			  				cur1.addBoard(new Board(2728,'˷��','˷��'));
	  			  				cur1.addBoard(new Board(2728,'̫ԭ','̫ԭ'));
	  			  				cur1.addBoard(new Board(2728,'����','����'));
	  			  				cur1.addBoard(new Board(2728,'��Ȫ','��Ȫ'));
	  			  				cur1.addBoard(new Board(2728,'�˳�','�˳�'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2973,'����','����'));
	  			  				cur1.addBoard(new Board(2973,'����','����'));
	  			  				cur1.addBoard(new Board(2973,'����','����'));
	  			  				cur1.addBoard(new Board(2973,'����','����'));
	  			  				cur1.addBoard(new Board(2973,'ͭ��','ͭ��'));
	  			  				cur1.addBoard(new Board(2973,'μ��','μ��'));
	  			  				cur1.addBoard(new Board(2973,'����','����'));
	  			  				cur1.addBoard(new Board(2973,'����','����'));
	  			  				cur1.addBoard(new Board(2973,'�Ӱ�','�Ӱ�'));
	  			  				cur1.addBoard(new Board(2973,'����','����'));
	  		
         			cur1 = new Province('�Ϻ�','�Ϻ�');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(2610,'�Ϻ�','�Ϻ�'));
	  		
         			cur1 = new Province('�Ĵ�','�Ĵ�');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3078,'���Ӳ���Ǽ��������','���Ӳ���Ǽ��������'));
	  			  				cur1.addBoard(new Board(3078,'����','����'));
	  			  				cur1.addBoard(new Board(3078,'�ɶ�','�ɶ�'));
	  			  				cur1.addBoard(new Board(3078,'����','����'));
	  			  				cur1.addBoard(new Board(3078,'����','����'));
	  			  				cur1.addBoard(new Board(3078,'���β���������','���β���������'));
	  			  				cur1.addBoard(new Board(3078,'�㰲','�㰲'));
	  			  				cur1.addBoard(new Board(3078,'��Ԫ','��Ԫ'));
	  			  				cur1.addBoard(new Board(3078,'��ɽ','��ɽ'));
	  			  				cur1.addBoard(new Board(3078,'��ɽ����������','��ɽ����������'));
	  			  				cur1.addBoard(new Board(3078,'üɽ','üɽ'));
	  			  				cur1.addBoard(new Board(3078,'����','����'));
	  			  				cur1.addBoard(new Board(3078,'�ϳ�','�ϳ�'));
	  			  				cur1.addBoard(new Board(3078,'�ڽ�','�ڽ�'));
	  			  				cur1.addBoard(new Board(3078,'��֦��','��֦��'));
	  			  				cur1.addBoard(new Board(3078,'����','����'));
	  			  				cur1.addBoard(new Board(3078,'�Ű�','�Ű�'));
	  			  				cur1.addBoard(new Board(3078,'�˱�','�˱�'));
	  			  				cur1.addBoard(new Board(3078,'����','����'));
	  			  				cur1.addBoard(new Board(3078,'�Թ�','�Թ�'));
	  			  				cur1.addBoard(new Board(3078,'����','����'));
	  		
         			cur1 = new Province('���','���');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3256,'���','���'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3290,'����','����'));
	  			  				cur1.addBoard(new Board(3290,'����','����'));
	  			  				cur1.addBoard(new Board(3290,'����','����'));
	  			  				cur1.addBoard(new Board(3290,'��֥','��֥'));
	  			  				cur1.addBoard(new Board(3290,'����','����'));
	  			  				cur1.addBoard(new Board(3290,'�տ���','�տ���'));
	  			  				cur1.addBoard(new Board(3290,'ɽ��','ɽ��'));
	  		
         			cur1 = new Province('�½�','�½�');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3371,'������','������'));
	  			  				cur1.addBoard(new Board(3371,'������','������'));
	  			  				cur1.addBoard(new Board(3371,'���������ɹ�������','���������ɹ�������'));
	  			  				cur1.addBoard(new Board(3371,'���������ɹ�������','���������ɹ�������'));
	  			  				cur1.addBoard(new Board(3371,'��������������','��������������'));
	  			  				cur1.addBoard(new Board(3371,'����','����'));
	  			  				cur1.addBoard(new Board(3371,'����','����'));
	  			  				cur1.addBoard(new Board(3371,'��ʲ','��ʲ'));
	  			  				cur1.addBoard(new Board(3371,'��������','��������'));
	  			  				cur1.addBoard(new Board(3371,'�������տ¶�����������','�������տ¶�����������'));
	  			  				cur1.addBoard(new Board(3371,'ʯ����','ʯ����'));
	  			  				cur1.addBoard(new Board(3371,'ͼľ���','ͼľ���'));
	  			  				cur1.addBoard(new Board(3371,'��³��','��³��'));
	  			  				cur1.addBoard(new Board(3371,'��³ľ��','��³ľ��'));
	  			  				cur1.addBoard(new Board(3371,'�����','�����'));
	  			  				cur1.addBoard(new Board(3371,'���������������','���������������'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3559,'��ɽ','��ɽ'));
	  			  				cur1.addBoard(new Board(3559,'��������������','��������������'));
	  			  				cur1.addBoard(new Board(3559,'�������������','�������������'));
	  			  				cur1.addBoard(new Board(3559,'�º���徰����������','�º���徰����������'));
	  			  				cur1.addBoard(new Board(3559,'�������������','�������������'));
	  			  				cur1.addBoard(new Board(3559,'��ӹ���������������','��ӹ���������������'));
	  			  				cur1.addBoard(new Board(3559,'����','����'));
	  			  				cur1.addBoard(new Board(3559,'����','����'));
	  			  				cur1.addBoard(new Board(3559,'�ٲ�','�ٲ�'));
	  			  				cur1.addBoard(new Board(3559,'ŭ��������������','ŭ��������������'));
	  			  				cur1.addBoard(new Board(3559,'����','����'));
	  			  				cur1.addBoard(new Board(3559,'˼é','˼é'));
	  			  				cur1.addBoard(new Board(3559,'��ɽ׳������������','��ɽ׳������������'));
	  			  				cur1.addBoard(new Board(3559,'��˫���ɴ���������','��˫���ɴ���������'));
	  			  				cur1.addBoard(new Board(3559,'��Ϫ','��Ϫ'));
	  			  				cur1.addBoard(new Board(3559,'��ͨ','��ͨ'));
	  		
         			cur1 = new Province('�㽭','�㽭');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3478,'����','����'));
	  			  				cur1.addBoard(new Board(3478,'����','����'));
	  			  				cur1.addBoard(new Board(3478,'����','����'));
	  			  				cur1.addBoard(new Board(3478,'��','��'));
	  			  				cur1.addBoard(new Board(3478,'��ˮ','��ˮ'));
	  			  				cur1.addBoard(new Board(3478,'����','����'));
	  			  				cur1.addBoard(new Board(3478,'����','����'));
	  			  				cur1.addBoard(new Board(3478,'̨��','̨��'));
	  			  				cur1.addBoard(new Board(3478,'����','����'));
	  			  				cur1.addBoard(new Board(3478,'��ɽ','��ɽ'));
	  			  				cur1.addBoard(new Board(3478,'����','����'));
	  		
         			cur1 = new Province('����','����');
	  		        catArr1 = catArr1.concat(cur1);
	  			  			  	cur1.addBoard(new Board(3262,'����','����'));
	  		
         	
	//init catform1
	var catForm1 = document.all.province;
	var boardForm1 = document.all.city;

