gx.evt.autoSkip=!1;gx.define("gx00d0",!1,function(){var n,t;this.ServerClass="gx00d0";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00d0.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="IndicadroresPalmas";this.SetStandaloneVars=function(){this.AV13pPAGOFRUTAFecha=gx.fn.getDateValue("vPPAGOFRUTAFECHA");this.AV14pPAGOFRUTAMes=gx.fn.getIntegerValue("vPPAGOFRUTAMES",".");this.AV15pPAGOFRUTAAno=gx.fn.getIntegerValue("vPPAGOFRUTAANO",".");this.AV16pCod_Area=gx.fn.getControlValue("vPCOD_AREA");this.AV17pIndicadoresCodigo=gx.fn.getControlValue("vPINDICADORESCODIGO");this.AV18pMotivosUspCodigo=gx.fn.getControlValue("vPMOTIVOSUSPCODIGO")};this.Validv_Cpagofrutafecha=function(){return this.validCliEvt("Validv_Cpagofrutafecha",0,function(){try{var n=gx.util.balloon.getNew("vCPAGOFRUTAFECHA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV6cPAGOFRUTAFecha)===0||new gx.date.gxdate(this.AV6cPAGOFRUTAFecha).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo PAGOFRUTAFecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e180f1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e110f1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PAGOFRUTAFECHAFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("PAGOFRUTAFECHAFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("PAGOFRUTAFECHAFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PAGOFRUTAFECHAFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAFECHAFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120f1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PAGOFRUTAMESFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PAGOFRUTAMESFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPAGOFRUTAMES","Visible",!0)):(gx.fn.setCtrlProperty("PAGOFRUTAMESFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPAGOFRUTAMES","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PAGOFRUTAMESFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAMESFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPAGOFRUTAMES","Visible")',ctrl:"vCPAGOFRUTAMES",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130f1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PAGOFRUTAANOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PAGOFRUTAANOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPAGOFRUTAANO","Visible",!0)):(gx.fn.setCtrlProperty("PAGOFRUTAANOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPAGOFRUTAANO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PAGOFRUTAANOFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAANOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPAGOFRUTAANO","Visible")',ctrl:"vCPAGOFRUTAANO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e140f1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("COD_AREAFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("COD_AREAFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCCOD_AREA","Visible",!0)):(gx.fn.setCtrlProperty("COD_AREAFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCCOD_AREA","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("COD_AREAFILTERCONTAINER","Class")',ctrl:"COD_AREAFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOD_AREA","Visible")',ctrl:"vCCOD_AREA",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150f1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCINDICADORESCODIGO","Visible",!0)):(gx.fn.setCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCINDICADORESCODIGO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class")',ctrl:"INDICADORESCODIGOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCINDICADORESCODIGO","Visible")',ctrl:"vCINDICADORESCODIGO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e160f1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("MOTIVOSUSPCODIGOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("MOTIVOSUSPCODIGOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCMOTIVOSUSPCODIGO","Visible",!0)):(gx.fn.setCtrlProperty("MOTIVOSUSPCODIGOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCMOTIVOSUSPCODIGO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("MOTIVOSUSPCODIGOFILTERCONTAINER","Class")',ctrl:"MOTIVOSUSPCODIGOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCMOTIVOSUSPCODIGO","Visible")',ctrl:"vCMOTIVOSUSPCODIGO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e170f1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PAGOFRUTAVALORFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PAGOFRUTAVALORFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPAGOFRUTAVALOR","Visible",!0)):(gx.fn.setCtrlProperty("PAGOFRUTAVALORFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPAGOFRUTAVALOR","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PAGOFRUTAVALORFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAVALORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPAGOFRUTAVALOR","Visible")',ctrl:"vCPAGOFRUTAVALOR",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e210f2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e220f1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,85,86,87,88,89,90,91,92,93,94];this.GXLastCtrlId=94;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",84,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00d0",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",85,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(68,86,"PAGOFRUTAFECHA","PAGOFRUTAFecha","","PAGOFRUTAFecha","date",0,"px",8,8,"right",null,[],68,"PAGOFRUTAFecha",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(69,87,"PAGOFRUTAMES","PAGOFRUTAMes","","PAGOFRUTAMes","int",0,"px",4,4,"right",null,[],69,"PAGOFRUTAMes",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(70,88,"PAGOFRUTAANO","PAGOFRUTAAno","","PAGOFRUTAAno","int",0,"px",4,4,"right",null,[],70,"PAGOFRUTAAno",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(5,89,"COD_AREA","Cod_Area","","Cod_Area","svchar",0,"px",40,40,"left",null,[],5,"Cod_Area",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(4,90,"INDICADORESCODIGO","Indicadores Codigo","","IndicadoresCodigo","svchar",0,"px",40,40,"left",null,[],4,"IndicadoresCodigo",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(30,91,"MOTIVOSUSPCODIGO","Motivos Usp Codigo","","MotivosUspCodigo","svchar",0,"px",40,40,"left",null,[],30,"MotivosUspCodigo",!1,0,!1,!1,"Attribute",0,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"PAGOFRUTAFECHAFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLPAGOFRUTAFECHAFILTER",format:1,grid:0,evt:"e110f1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Cpagofrutafecha,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPAGOFRUTAFECHA",fmt:0,gxz:"ZV6cPAGOFRUTAFecha",gxold:"OV6cPAGOFRUTAFecha",gxvar:"AV6cPAGOFRUTAFecha",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[16],ip:[16],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cPAGOFRUTAFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cPAGOFRUTAFecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCPAGOFRUTAFECHA",gx.O.AV6cPAGOFRUTAFecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cPAGOFRUTAFecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCPAGOFRUTAFECHA")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"PAGOFRUTAMESFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLPAGOFRUTAMESFILTER",format:1,grid:0,evt:"e120f1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPAGOFRUTAMES",fmt:0,gxz:"ZV7cPAGOFRUTAMes",gxold:"OV7cPAGOFRUTAMes",gxvar:"AV7cPAGOFRUTAMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cPAGOFRUTAMes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7cPAGOFRUTAMes=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPAGOFRUTAMES",gx.O.AV7cPAGOFRUTAMes,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cPAGOFRUTAMes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPAGOFRUTAMES",".")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"PAGOFRUTAANOFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLPAGOFRUTAANOFILTER",format:1,grid:0,evt:"e130f1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPAGOFRUTAANO",fmt:0,gxz:"ZV8cPAGOFRUTAAno",gxold:"OV8cPAGOFRUTAAno",gxvar:"AV8cPAGOFRUTAAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cPAGOFRUTAAno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cPAGOFRUTAAno=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPAGOFRUTAANO",gx.O.AV8cPAGOFRUTAAno,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cPAGOFRUTAAno=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPAGOFRUTAANO",".")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"COD_AREAFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLCOD_AREAFILTER",format:1,grid:0,evt:"e140f1_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCOD_AREA",fmt:0,gxz:"ZV9cCod_Area",gxold:"OV9cCod_Area",gxvar:"AV9cCod_Area",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cCod_Area=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9cCod_Area=n)},v2c:function(){gx.fn.setControlValue("vCCOD_AREA",gx.O.AV9cCod_Area,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cCod_Area=this.val())},val:function(){return gx.fn.getControlValue("vCCOD_AREA")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"INDICADORESCODIGOFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLINDICADORESCODIGOFILTER",format:1,grid:0,evt:"e150f1_client",ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCINDICADORESCODIGO",fmt:0,gxz:"ZV10cIndicadoresCodigo",gxold:"OV10cIndicadoresCodigo",gxvar:"AV10cIndicadoresCodigo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cIndicadoresCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10cIndicadoresCodigo=n)},v2c:function(){gx.fn.setControlValue("vCINDICADORESCODIGO",gx.O.AV10cIndicadoresCodigo,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cIndicadoresCodigo=this.val())},val:function(){return gx.fn.getControlValue("vCINDICADORESCODIGO")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"MOTIVOSUSPCODIGOFILTERCONTAINER",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"LBLMOTIVOSUSPCODIGOFILTER",format:1,grid:0,evt:"e160f1_client",ctrltype:"textblock"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCMOTIVOSUSPCODIGO",fmt:0,gxz:"ZV11cMotivosUspCodigo",gxold:"OV11cMotivosUspCodigo",gxvar:"AV11cMotivosUspCodigo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11cMotivosUspCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11cMotivosUspCodigo=n)},v2c:function(){gx.fn.setControlValue("vCMOTIVOSUSPCODIGO",gx.O.AV11cMotivosUspCodigo,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11cMotivosUspCodigo=this.val())},val:function(){return gx.fn.getControlValue("vCMOTIVOSUSPCODIGO")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"PAGOFRUTAVALORFILTERCONTAINER",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"LBLPAGOFRUTAVALORFILTER",format:1,grid:0,evt:"e170f1_client",ctrltype:"textblock"};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"decimal",len:14,dec:2,sign:!1,pic:"ZZZZZZZZZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPAGOFRUTAVALOR",fmt:0,gxz:"ZV12cPAGOFRUTAValor",gxold:"OV12cPAGOFRUTAValor",gxvar:"AV12cPAGOFRUTAValor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12cPAGOFRUTAValor=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV12cPAGOFRUTAValor=gx.fn.toDecimalValue(n,".",","))},v2c:function(){gx.fn.setDecimalValue("vCPAGOFRUTAVALOR",gx.O.AV12cPAGOFRUTAValor,2,",")},c2v:function(){this.val()!==undefined&&(gx.O.AV12cPAGOFRUTAValor=this.val())},val:function(){return gx.fn.getDecimalValue("vCPAGOFRUTAVALOR",".",",")},nac:gx.falseFn};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"GRIDTABLE",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"BTNTOGGLE",grid:0,evt:"e180f1_client"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[85]={id:85,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84),gx.O.AV5LinkSelection,gx.O.AV22Linkselection_GXI)},c2v:function(n){gx.O.AV22Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(84))},gxvar_GXI:"AV22Linkselection_GXI",nac:gx.falseFn};n[86]={id:86,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGOFRUTAFECHA",fmt:0,gxz:"Z68PAGOFRUTAFecha",gxold:"O68PAGOFRUTAFecha",gxvar:"A68PAGOFRUTAFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A68PAGOFRUTAFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z68PAGOFRUTAFecha=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("PAGOFRUTAFECHA",n||gx.fn.currentGridRowImpl(84),gx.O.A68PAGOFRUTAFecha,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A68PAGOFRUTAFecha=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("PAGOFRUTAFECHA",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[87]={id:87,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGOFRUTAMES",fmt:0,gxz:"Z69PAGOFRUTAMes",gxold:"O69PAGOFRUTAMes",gxvar:"A69PAGOFRUTAMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A69PAGOFRUTAMes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z69PAGOFRUTAMes=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PAGOFRUTAMES",n||gx.fn.currentGridRowImpl(84),gx.O.A69PAGOFRUTAMes,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A69PAGOFRUTAMes=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PAGOFRUTAMES",n||gx.fn.currentGridRowImpl(84),".")},nac:gx.falseFn};n[88]={id:88,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAGOFRUTAANO",fmt:0,gxz:"Z70PAGOFRUTAAno",gxold:"O70PAGOFRUTAAno",gxvar:"A70PAGOFRUTAAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A70PAGOFRUTAAno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z70PAGOFRUTAAno=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PAGOFRUTAANO",n||gx.fn.currentGridRowImpl(84),gx.O.A70PAGOFRUTAAno,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A70PAGOFRUTAAno=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PAGOFRUTAANO",n||gx.fn.currentGridRowImpl(84),".")},nac:gx.falseFn};n[89]={id:89,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COD_AREA",fmt:0,gxz:"Z5Cod_Area",gxold:"O5Cod_Area",gxvar:"A5Cod_Area",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A5Cod_Area=n)},v2z:function(n){n!==undefined&&(gx.O.Z5Cod_Area=n)},v2c:function(n){gx.fn.setGridControlValue("COD_AREA",n||gx.fn.currentGridRowImpl(84),gx.O.A5Cod_Area,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5Cod_Area=this.val(n))},val:function(n){return gx.fn.getGridControlValue("COD_AREA",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[90]={id:90,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INDICADORESCODIGO",fmt:0,gxz:"Z4IndicadoresCodigo",gxold:"O4IndicadoresCodigo",gxvar:"A4IndicadoresCodigo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A4IndicadoresCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.Z4IndicadoresCodigo=n)},v2c:function(n){gx.fn.setGridControlValue("INDICADORESCODIGO",n||gx.fn.currentGridRowImpl(84),gx.O.A4IndicadoresCodigo,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4IndicadoresCodigo=this.val(n))},val:function(n){return gx.fn.getGridControlValue("INDICADORESCODIGO",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[91]={id:91,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MOTIVOSUSPCODIGO",fmt:0,gxz:"Z30MotivosUspCodigo",gxold:"O30MotivosUspCodigo",gxvar:"A30MotivosUspCodigo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A30MotivosUspCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.Z30MotivosUspCodigo=n)},v2c:function(n){gx.fn.setGridControlValue("MOTIVOSUSPCODIGO",n||gx.fn.currentGridRowImpl(84),gx.O.A30MotivosUspCodigo,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30MotivosUspCodigo=this.val(n))},val:function(n){return gx.fn.getGridControlValue("MOTIVOSUSPCODIGO",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"BTN_CANCEL",grid:0,evt:"e220f1_client"};this.AV6cPAGOFRUTAFecha=gx.date.nullDate();this.ZV6cPAGOFRUTAFecha=gx.date.nullDate();this.OV6cPAGOFRUTAFecha=gx.date.nullDate();this.AV7cPAGOFRUTAMes=0;this.ZV7cPAGOFRUTAMes=0;this.OV7cPAGOFRUTAMes=0;this.AV8cPAGOFRUTAAno=0;this.ZV8cPAGOFRUTAAno=0;this.OV8cPAGOFRUTAAno=0;this.AV9cCod_Area="";this.ZV9cCod_Area="";this.OV9cCod_Area="";this.AV10cIndicadoresCodigo="";this.ZV10cIndicadoresCodigo="";this.OV10cIndicadoresCodigo="";this.AV11cMotivosUspCodigo="";this.ZV11cMotivosUspCodigo="";this.OV11cMotivosUspCodigo="";this.AV12cPAGOFRUTAValor=0;this.ZV12cPAGOFRUTAValor=0;this.OV12cPAGOFRUTAValor=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z68PAGOFRUTAFecha=gx.date.nullDate();this.O68PAGOFRUTAFecha=gx.date.nullDate();this.Z69PAGOFRUTAMes=0;this.O69PAGOFRUTAMes=0;this.Z70PAGOFRUTAAno=0;this.O70PAGOFRUTAAno=0;this.Z5Cod_Area="";this.O5Cod_Area="";this.Z4IndicadoresCodigo="";this.O4IndicadoresCodigo="";this.Z30MotivosUspCodigo="";this.O30MotivosUspCodigo="";this.AV6cPAGOFRUTAFecha=gx.date.nullDate();this.AV7cPAGOFRUTAMes=0;this.AV8cPAGOFRUTAAno=0;this.AV9cCod_Area="";this.AV10cIndicadoresCodigo="";this.AV11cMotivosUspCodigo="";this.AV12cPAGOFRUTAValor=0;this.AV13pPAGOFRUTAFecha=gx.date.nullDate();this.AV14pPAGOFRUTAMes=0;this.AV15pPAGOFRUTAAno=0;this.AV16pCod_Area="";this.AV17pIndicadoresCodigo="";this.AV18pMotivosUspCodigo="";this.A136PAGOFRUTAValor=0;this.AV5LinkSelection="";this.A68PAGOFRUTAFecha=gx.date.nullDate();this.A69PAGOFRUTAMes=0;this.A70PAGOFRUTAAno=0;this.A5Cod_Area="";this.A4IndicadoresCodigo="";this.A30MotivosUspCodigo="";this.Events={e210f2_client:["ENTER",!0],e220f1_client:["CANCEL",!0],e180f1_client:["'TOGGLE'",!1],e110f1_client:["LBLPAGOFRUTAFECHAFILTER.CLICK",!1],e120f1_client:["LBLPAGOFRUTAMESFILTER.CLICK",!1],e130f1_client:["LBLPAGOFRUTAANOFILTER.CLICK",!1],e140f1_client:["LBLCOD_AREAFILTER.CLICK",!1],e150f1_client:["LBLINDICADORESCODIGOFILTER.CLICK",!1],e160f1_client:["LBLMOTIVOSUSPCODIGOFILTER.CLICK",!1],e170f1_client:["LBLPAGOFRUTAVALORFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cPAGOFRUTAFecha",fld:"vCPAGOFRUTAFECHA",pic:""},{av:"AV7cPAGOFRUTAMes",fld:"vCPAGOFRUTAMES",pic:"ZZZ9"},{av:"AV8cPAGOFRUTAAno",fld:"vCPAGOFRUTAANO",pic:"ZZZ9"},{av:"AV9cCod_Area",fld:"vCCOD_AREA",pic:""},{av:"AV10cIndicadoresCodigo",fld:"vCINDICADORESCODIGO",pic:""},{av:"AV11cMotivosUspCodigo",fld:"vCMOTIVOSUSPCODIGO",pic:""},{av:"AV12cPAGOFRUTAValor",fld:"vCPAGOFRUTAVALOR",pic:"ZZZZZZZZZZ9.99"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLPAGOFRUTAFECHAFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PAGOFRUTAFECHAFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAFECHAFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PAGOFRUTAFECHAFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAFECHAFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLPAGOFRUTAMESFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PAGOFRUTAMESFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAMESFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PAGOFRUTAMESFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAMESFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPAGOFRUTAMES","Visible")',ctrl:"vCPAGOFRUTAMES",prop:"Visible"}]];this.EvtParms["LBLPAGOFRUTAANOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PAGOFRUTAANOFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAANOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PAGOFRUTAANOFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAANOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPAGOFRUTAANO","Visible")',ctrl:"vCPAGOFRUTAANO",prop:"Visible"}]];this.EvtParms["LBLCOD_AREAFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("COD_AREAFILTERCONTAINER","Class")',ctrl:"COD_AREAFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("COD_AREAFILTERCONTAINER","Class")',ctrl:"COD_AREAFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOD_AREA","Visible")',ctrl:"vCCOD_AREA",prop:"Visible"}]];this.EvtParms["LBLINDICADORESCODIGOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class")',ctrl:"INDICADORESCODIGOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class")',ctrl:"INDICADORESCODIGOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCINDICADORESCODIGO","Visible")',ctrl:"vCINDICADORESCODIGO",prop:"Visible"}]];this.EvtParms["LBLMOTIVOSUSPCODIGOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("MOTIVOSUSPCODIGOFILTERCONTAINER","Class")',ctrl:"MOTIVOSUSPCODIGOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("MOTIVOSUSPCODIGOFILTERCONTAINER","Class")',ctrl:"MOTIVOSUSPCODIGOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCMOTIVOSUSPCODIGO","Visible")',ctrl:"vCMOTIVOSUSPCODIGO",prop:"Visible"}]];this.EvtParms["LBLPAGOFRUTAVALORFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PAGOFRUTAVALORFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAVALORFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PAGOFRUTAVALORFILTERCONTAINER","Class")',ctrl:"PAGOFRUTAVALORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPAGOFRUTAVALOR","Visible")',ctrl:"vCPAGOFRUTAVALOR",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A68PAGOFRUTAFecha",fld:"PAGOFRUTAFECHA",pic:"",hsh:!0},{av:"A69PAGOFRUTAMes",fld:"PAGOFRUTAMES",pic:"ZZZ9",hsh:!0},{av:"A70PAGOFRUTAAno",fld:"PAGOFRUTAANO",pic:"ZZZ9",hsh:!0},{av:"A5Cod_Area",fld:"COD_AREA",pic:"",hsh:!0},{av:"A4IndicadoresCodigo",fld:"INDICADORESCODIGO",pic:"",hsh:!0},{av:"A30MotivosUspCodigo",fld:"MOTIVOSUSPCODIGO",pic:"",hsh:!0}],[{av:"AV13pPAGOFRUTAFecha",fld:"vPPAGOFRUTAFECHA",pic:""},{av:"AV14pPAGOFRUTAMes",fld:"vPPAGOFRUTAMES",pic:"ZZZ9"},{av:"AV15pPAGOFRUTAAno",fld:"vPPAGOFRUTAANO",pic:"ZZZ9"},{av:"AV16pCod_Area",fld:"vPCOD_AREA",pic:""},{av:"AV17pIndicadoresCodigo",fld:"vPINDICADORESCODIGO",pic:""},{av:"AV18pMotivosUspCodigo",fld:"vPMOTIVOSUSPCODIGO",pic:""}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cPAGOFRUTAFecha",fld:"vCPAGOFRUTAFECHA",pic:""},{av:"AV7cPAGOFRUTAMes",fld:"vCPAGOFRUTAMES",pic:"ZZZ9"},{av:"AV8cPAGOFRUTAAno",fld:"vCPAGOFRUTAANO",pic:"ZZZ9"},{av:"AV9cCod_Area",fld:"vCCOD_AREA",pic:""},{av:"AV10cIndicadoresCodigo",fld:"vCINDICADORESCODIGO",pic:""},{av:"AV11cMotivosUspCodigo",fld:"vCMOTIVOSUSPCODIGO",pic:""},{av:"AV12cPAGOFRUTAValor",fld:"vCPAGOFRUTAVALOR",pic:"ZZZZZZZZZZ9.99"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cPAGOFRUTAFecha",fld:"vCPAGOFRUTAFECHA",pic:""},{av:"AV7cPAGOFRUTAMes",fld:"vCPAGOFRUTAMES",pic:"ZZZ9"},{av:"AV8cPAGOFRUTAAno",fld:"vCPAGOFRUTAANO",pic:"ZZZ9"},{av:"AV9cCod_Area",fld:"vCCOD_AREA",pic:""},{av:"AV10cIndicadoresCodigo",fld:"vCINDICADORESCODIGO",pic:""},{av:"AV11cMotivosUspCodigo",fld:"vCMOTIVOSUSPCODIGO",pic:""},{av:"AV12cPAGOFRUTAValor",fld:"vCPAGOFRUTAVALOR",pic:"ZZZZZZZZZZ9.99"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cPAGOFRUTAFecha",fld:"vCPAGOFRUTAFECHA",pic:""},{av:"AV7cPAGOFRUTAMes",fld:"vCPAGOFRUTAMES",pic:"ZZZ9"},{av:"AV8cPAGOFRUTAAno",fld:"vCPAGOFRUTAANO",pic:"ZZZ9"},{av:"AV9cCod_Area",fld:"vCCOD_AREA",pic:""},{av:"AV10cIndicadoresCodigo",fld:"vCINDICADORESCODIGO",pic:""},{av:"AV11cMotivosUspCodigo",fld:"vCMOTIVOSUSPCODIGO",pic:""},{av:"AV12cPAGOFRUTAValor",fld:"vCPAGOFRUTAVALOR",pic:"ZZZZZZZZZZ9.99"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cPAGOFRUTAFecha",fld:"vCPAGOFRUTAFECHA",pic:""},{av:"AV7cPAGOFRUTAMes",fld:"vCPAGOFRUTAMES",pic:"ZZZ9"},{av:"AV8cPAGOFRUTAAno",fld:"vCPAGOFRUTAANO",pic:"ZZZ9"},{av:"AV9cCod_Area",fld:"vCCOD_AREA",pic:""},{av:"AV10cIndicadoresCodigo",fld:"vCINDICADORESCODIGO",pic:""},{av:"AV11cMotivosUspCodigo",fld:"vCMOTIVOSUSPCODIGO",pic:""},{av:"AV12cPAGOFRUTAValor",fld:"vCPAGOFRUTAVALOR",pic:"ZZZZZZZZZZ9.99"}],[]];this.EvtParms.VALIDV_CPAGOFRUTAFECHA=[[],[]];this.setVCMap("AV13pPAGOFRUTAFecha","vPPAGOFRUTAFECHA",0,"date",8,0);this.setVCMap("AV14pPAGOFRUTAMes","vPPAGOFRUTAMES",0,"int",4,0);this.setVCMap("AV15pPAGOFRUTAAno","vPPAGOFRUTAANO",0,"int",4,0);this.setVCMap("AV16pCod_Area","vPCOD_AREA",0,"svchar",40,0);this.setVCMap("AV17pIndicadoresCodigo","vPINDICADORESCODIGO",0,"svchar",40,0);this.setVCMap("AV18pMotivosUspCodigo","vPMOTIVOSUSPCODIGO",0,"svchar",40,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingVar(this.GXValidFnc[66]);t.addRefreshingVar(this.GXValidFnc[76]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[66]);t.addRefreshingParm(this.GXValidFnc[76]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00d0)})