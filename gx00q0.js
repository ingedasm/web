gx.evt.autoSkip=!1;gx.define("gx00q0",!1,function(){var n,t;this.ServerClass="gx00q0";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00q0.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="IndicadroresPalmas";this.SetStandaloneVars=function(){this.AV13pCOSTONRFFPROCFec=gx.fn.getDateValue("vPCOSTONRFFPROCFEC");this.AV14pCOSTONRFFPROCMes=gx.fn.getIntegerValue("vPCOSTONRFFPROCMES",".");this.AV15pCOSTONRFFPROCAno=gx.fn.getIntegerValue("vPCOSTONRFFPROCANO",".");this.AV16pCod_Area=gx.fn.getControlValue("vPCOD_AREA");this.AV17pIndicadoresCodigo=gx.fn.getControlValue("vPINDICADORESCODIGO");this.AV18pMOTIVOSCOSRFFPROCod=gx.fn.getControlValue("vPMOTIVOSCOSRFFPROCOD")};this.Validv_Ccostonrffprocfec=function(){return this.validCliEvt("Validv_Ccostonrffprocfec",0,function(){try{var n=gx.util.balloon.getNew("vCCOSTONRFFPROCFEC");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV6cCOSTONRFFPROCFec)===0||new gx.date.gxdate(this.AV6cCOSTONRFFPROCFec).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo COSTONRFFPROCFec fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e180s1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e110s1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("COSTONRFFPROCFECFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("COSTONRFFPROCFECFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("COSTONRFFPROCFECFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("COSTONRFFPROCFECFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCFECFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120s1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("COSTONRFFPROCMESFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("COSTONRFFPROCMESFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCCOSTONRFFPROCMES","Visible",!0)):(gx.fn.setCtrlProperty("COSTONRFFPROCMESFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCCOSTONRFFPROCMES","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("COSTONRFFPROCMESFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCMESFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOSTONRFFPROCMES","Visible")',ctrl:"vCCOSTONRFFPROCMES",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130s1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("COSTONRFFPROCANOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("COSTONRFFPROCANOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCCOSTONRFFPROCANO","Visible",!0)):(gx.fn.setCtrlProperty("COSTONRFFPROCANOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCCOSTONRFFPROCANO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("COSTONRFFPROCANOFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCANOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOSTONRFFPROCANO","Visible")',ctrl:"vCCOSTONRFFPROCANO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e140s1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("COD_AREAFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("COD_AREAFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCCOD_AREA","Visible",!0)):(gx.fn.setCtrlProperty("COD_AREAFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCCOD_AREA","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("COD_AREAFILTERCONTAINER","Class")',ctrl:"COD_AREAFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOD_AREA","Visible")',ctrl:"vCCOD_AREA",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150s1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCINDICADORESCODIGO","Visible",!0)):(gx.fn.setCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCINDICADORESCODIGO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class")',ctrl:"INDICADORESCODIGOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCINDICADORESCODIGO","Visible")',ctrl:"vCINDICADORESCODIGO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e160s1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("MOTIVOSCOSRFFPROCODFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("MOTIVOSCOSRFFPROCODFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCMOTIVOSCOSRFFPROCOD","Visible",!0)):(gx.fn.setCtrlProperty("MOTIVOSCOSRFFPROCODFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCMOTIVOSCOSRFFPROCOD","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("MOTIVOSCOSRFFPROCODFILTERCONTAINER","Class")',ctrl:"MOTIVOSCOSRFFPROCODFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCMOTIVOSCOSRFFPROCOD","Visible")',ctrl:"vCMOTIVOSCOSRFFPROCOD",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e170s1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("COSTONRFFPROCVALORFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("COSTONRFFPROCVALORFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCCOSTONRFFPROCVALOR","Visible",!0)):(gx.fn.setCtrlProperty("COSTONRFFPROCVALORFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCCOSTONRFFPROCVALOR","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("COSTONRFFPROCVALORFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCVALORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOSTONRFFPROCVALOR","Visible")',ctrl:"vCCOSTONRFFPROCVALOR",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e210s2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e220s1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,85,86,87,88,89,90,91,92,93,94,95];this.GXLastCtrlId=95;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",84,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00q0",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",85,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(71,86,"COSTONRFFPROCFEC","COSTONRFFPROCFec","","COSTONRFFPROCFec","date",0,"px",8,8,"right",null,[],71,"COSTONRFFPROCFec",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(72,87,"COSTONRFFPROCMES","COSTONRFFPROCMes","","COSTONRFFPROCMes","int",0,"px",4,4,"right",null,[],72,"COSTONRFFPROCMes",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(73,88,"COSTONRFFPROCANO","COSTONRFFPROCAno","","COSTONRFFPROCAno","int",0,"px",4,4,"right",null,[],73,"COSTONRFFPROCAno",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(5,89,"COD_AREA","Cod_Area","","Cod_Area","svchar",0,"px",40,40,"left",null,[],5,"Cod_Area",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(168,90,"COSTONRFFPROCVALOR","COSTONRFFPROCValor","","COSTONRFFPROCValor","decimal",0,"px",15,15,"right",null,[],168,"COSTONRFFPROCValor",!0,4,!1,!1,"DescriptionAttribute",0,"WWColumn");t.addSingleLineEdit(4,91,"INDICADORESCODIGO","Indicadores Codigo","","IndicadoresCodigo","svchar",0,"px",40,40,"left",null,[],4,"IndicadoresCodigo",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(53,92,"MOTIVOSCOSRFFPROCOD","MOTIVOSCOSRFFPROCod","","MOTIVOSCOSRFFPROCod","svchar",0,"px",40,40,"left",null,[],53,"MOTIVOSCOSRFFPROCod",!1,0,!1,!1,"Attribute",0,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"COSTONRFFPROCFECFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLCOSTONRFFPROCFECFILTER",format:1,grid:0,evt:"e110s1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ccostonrffprocfec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCOSTONRFFPROCFEC",fmt:0,gxz:"ZV6cCOSTONRFFPROCFec",gxold:"OV6cCOSTONRFFPROCFec",gxvar:"AV6cCOSTONRFFPROCFec",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[16],ip:[16],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cCOSTONRFFPROCFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cCOSTONRFFPROCFec=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCCOSTONRFFPROCFEC",gx.O.AV6cCOSTONRFFPROCFec,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cCOSTONRFFPROCFec=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCCOSTONRFFPROCFEC")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"COSTONRFFPROCMESFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLCOSTONRFFPROCMESFILTER",format:1,grid:0,evt:"e120s1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCOSTONRFFPROCMES",fmt:0,gxz:"ZV7cCOSTONRFFPROCMes",gxold:"OV7cCOSTONRFFPROCMes",gxvar:"AV7cCOSTONRFFPROCMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cCOSTONRFFPROCMes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7cCOSTONRFFPROCMes=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCCOSTONRFFPROCMES",gx.O.AV7cCOSTONRFFPROCMes,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cCOSTONRFFPROCMes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCCOSTONRFFPROCMES",".")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"COSTONRFFPROCANOFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLCOSTONRFFPROCANOFILTER",format:1,grid:0,evt:"e130s1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCOSTONRFFPROCANO",fmt:0,gxz:"ZV8cCOSTONRFFPROCAno",gxold:"OV8cCOSTONRFFPROCAno",gxvar:"AV8cCOSTONRFFPROCAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cCOSTONRFFPROCAno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cCOSTONRFFPROCAno=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCCOSTONRFFPROCANO",gx.O.AV8cCOSTONRFFPROCAno,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cCOSTONRFFPROCAno=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCCOSTONRFFPROCANO",".")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"COD_AREAFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLCOD_AREAFILTER",format:1,grid:0,evt:"e140s1_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCOD_AREA",fmt:0,gxz:"ZV9cCod_Area",gxold:"OV9cCod_Area",gxvar:"AV9cCod_Area",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cCod_Area=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9cCod_Area=n)},v2c:function(){gx.fn.setControlValue("vCCOD_AREA",gx.O.AV9cCod_Area,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cCod_Area=this.val())},val:function(){return gx.fn.getControlValue("vCCOD_AREA")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"INDICADORESCODIGOFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLINDICADORESCODIGOFILTER",format:1,grid:0,evt:"e150s1_client",ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCINDICADORESCODIGO",fmt:0,gxz:"ZV10cIndicadoresCodigo",gxold:"OV10cIndicadoresCodigo",gxvar:"AV10cIndicadoresCodigo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cIndicadoresCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10cIndicadoresCodigo=n)},v2c:function(){gx.fn.setControlValue("vCINDICADORESCODIGO",gx.O.AV10cIndicadoresCodigo,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cIndicadoresCodigo=this.val())},val:function(){return gx.fn.getControlValue("vCINDICADORESCODIGO")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"MOTIVOSCOSRFFPROCODFILTERCONTAINER",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"LBLMOTIVOSCOSRFFPROCODFILTER",format:1,grid:0,evt:"e160s1_client",ctrltype:"textblock"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCMOTIVOSCOSRFFPROCOD",fmt:0,gxz:"ZV11cMOTIVOSCOSRFFPROCod",gxold:"OV11cMOTIVOSCOSRFFPROCod",gxvar:"AV11cMOTIVOSCOSRFFPROCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11cMOTIVOSCOSRFFPROCod=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11cMOTIVOSCOSRFFPROCod=n)},v2c:function(){gx.fn.setControlValue("vCMOTIVOSCOSRFFPROCOD",gx.O.AV11cMOTIVOSCOSRFFPROCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11cMOTIVOSCOSRFFPROCod=this.val())},val:function(){return gx.fn.getControlValue("vCMOTIVOSCOSRFFPROCOD")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"COSTONRFFPROCVALORFILTERCONTAINER",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"LBLCOSTONRFFPROCVALORFILTER",format:1,grid:0,evt:"e170s1_client",ctrltype:"textblock"};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"decimal",len:15,dec:4,sign:!1,pic:"ZZZZZZZZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCOSTONRFFPROCVALOR",fmt:0,gxz:"ZV12cCOSTONRFFPROCValor",gxold:"OV12cCOSTONRFFPROCValor",gxvar:"AV12cCOSTONRFFPROCValor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12cCOSTONRFFPROCValor=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV12cCOSTONRFFPROCValor=gx.fn.toDecimalValue(n,".",","))},v2c:function(){gx.fn.setDecimalValue("vCCOSTONRFFPROCVALOR",gx.O.AV12cCOSTONRFFPROCValor,4,",")},c2v:function(){this.val()!==undefined&&(gx.O.AV12cCOSTONRFFPROCValor=this.val())},val:function(){return gx.fn.getDecimalValue("vCCOSTONRFFPROCVALOR",".",",")},nac:gx.falseFn};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"GRIDTABLE",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"BTNTOGGLE",grid:0,evt:"e180s1_client"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[85]={id:85,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84),gx.O.AV5LinkSelection,gx.O.AV22Linkselection_GXI)},c2v:function(n){gx.O.AV22Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(84))},gxvar_GXI:"AV22Linkselection_GXI",nac:gx.falseFn};n[86]={id:86,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTONRFFPROCFEC",fmt:0,gxz:"Z71COSTONRFFPROCFec",gxold:"O71COSTONRFFPROCFec",gxvar:"A71COSTONRFFPROCFec",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A71COSTONRFFPROCFec=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z71COSTONRFFPROCFec=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("COSTONRFFPROCFEC",n||gx.fn.currentGridRowImpl(84),gx.O.A71COSTONRFFPROCFec,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A71COSTONRFFPROCFec=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("COSTONRFFPROCFEC",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[87]={id:87,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTONRFFPROCMES",fmt:0,gxz:"Z72COSTONRFFPROCMes",gxold:"O72COSTONRFFPROCMes",gxvar:"A72COSTONRFFPROCMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A72COSTONRFFPROCMes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z72COSTONRFFPROCMes=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("COSTONRFFPROCMES",n||gx.fn.currentGridRowImpl(84),gx.O.A72COSTONRFFPROCMes,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A72COSTONRFFPROCMes=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("COSTONRFFPROCMES",n||gx.fn.currentGridRowImpl(84),".")},nac:gx.falseFn};n[88]={id:88,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTONRFFPROCANO",fmt:0,gxz:"Z73COSTONRFFPROCAno",gxold:"O73COSTONRFFPROCAno",gxvar:"A73COSTONRFFPROCAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A73COSTONRFFPROCAno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z73COSTONRFFPROCAno=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("COSTONRFFPROCANO",n||gx.fn.currentGridRowImpl(84),gx.O.A73COSTONRFFPROCAno,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A73COSTONRFFPROCAno=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("COSTONRFFPROCANO",n||gx.fn.currentGridRowImpl(84),".")},nac:gx.falseFn};n[89]={id:89,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COD_AREA",fmt:0,gxz:"Z5Cod_Area",gxold:"O5Cod_Area",gxvar:"A5Cod_Area",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A5Cod_Area=n)},v2z:function(n){n!==undefined&&(gx.O.Z5Cod_Area=n)},v2c:function(n){gx.fn.setGridControlValue("COD_AREA",n||gx.fn.currentGridRowImpl(84),gx.O.A5Cod_Area,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5Cod_Area=this.val(n))},val:function(n){return gx.fn.getGridControlValue("COD_AREA",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[90]={id:90,lvl:2,type:"decimal",len:15,dec:4,sign:!1,pic:"ZZZZZZZZZ9.9999",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTONRFFPROCVALOR",fmt:0,gxz:"Z168COSTONRFFPROCValor",gxold:"O168COSTONRFFPROCValor",gxvar:"A168COSTONRFFPROCValor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A168COSTONRFFPROCValor=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z168COSTONRFFPROCValor=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("COSTONRFFPROCVALOR",n||gx.fn.currentGridRowImpl(84),gx.O.A168COSTONRFFPROCValor,4,",")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A168COSTONRFFPROCValor=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("COSTONRFFPROCVALOR",n||gx.fn.currentGridRowImpl(84),".",",")},nac:gx.falseFn};n[91]={id:91,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INDICADORESCODIGO",fmt:0,gxz:"Z4IndicadoresCodigo",gxold:"O4IndicadoresCodigo",gxvar:"A4IndicadoresCodigo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A4IndicadoresCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.Z4IndicadoresCodigo=n)},v2c:function(n){gx.fn.setGridControlValue("INDICADORESCODIGO",n||gx.fn.currentGridRowImpl(84),gx.O.A4IndicadoresCodigo,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4IndicadoresCodigo=this.val(n))},val:function(n){return gx.fn.getGridControlValue("INDICADORESCODIGO",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[92]={id:92,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MOTIVOSCOSRFFPROCOD",fmt:0,gxz:"Z53MOTIVOSCOSRFFPROCod",gxold:"O53MOTIVOSCOSRFFPROCod",gxvar:"A53MOTIVOSCOSRFFPROCod",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A53MOTIVOSCOSRFFPROCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z53MOTIVOSCOSRFFPROCod=n)},v2c:function(n){gx.fn.setGridControlValue("MOTIVOSCOSRFFPROCOD",n||gx.fn.currentGridRowImpl(84),gx.O.A53MOTIVOSCOSRFFPROCod,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A53MOTIVOSCOSRFFPROCod=this.val(n))},val:function(n){return gx.fn.getGridControlValue("MOTIVOSCOSRFFPROCOD",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"BTN_CANCEL",grid:0,evt:"e220s1_client"};this.AV6cCOSTONRFFPROCFec=gx.date.nullDate();this.ZV6cCOSTONRFFPROCFec=gx.date.nullDate();this.OV6cCOSTONRFFPROCFec=gx.date.nullDate();this.AV7cCOSTONRFFPROCMes=0;this.ZV7cCOSTONRFFPROCMes=0;this.OV7cCOSTONRFFPROCMes=0;this.AV8cCOSTONRFFPROCAno=0;this.ZV8cCOSTONRFFPROCAno=0;this.OV8cCOSTONRFFPROCAno=0;this.AV9cCod_Area="";this.ZV9cCod_Area="";this.OV9cCod_Area="";this.AV10cIndicadoresCodigo="";this.ZV10cIndicadoresCodigo="";this.OV10cIndicadoresCodigo="";this.AV11cMOTIVOSCOSRFFPROCod="";this.ZV11cMOTIVOSCOSRFFPROCod="";this.OV11cMOTIVOSCOSRFFPROCod="";this.AV12cCOSTONRFFPROCValor=0;this.ZV12cCOSTONRFFPROCValor=0;this.OV12cCOSTONRFFPROCValor=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z71COSTONRFFPROCFec=gx.date.nullDate();this.O71COSTONRFFPROCFec=gx.date.nullDate();this.Z72COSTONRFFPROCMes=0;this.O72COSTONRFFPROCMes=0;this.Z73COSTONRFFPROCAno=0;this.O73COSTONRFFPROCAno=0;this.Z5Cod_Area="";this.O5Cod_Area="";this.Z168COSTONRFFPROCValor=0;this.O168COSTONRFFPROCValor=0;this.Z4IndicadoresCodigo="";this.O4IndicadoresCodigo="";this.Z53MOTIVOSCOSRFFPROCod="";this.O53MOTIVOSCOSRFFPROCod="";this.AV6cCOSTONRFFPROCFec=gx.date.nullDate();this.AV7cCOSTONRFFPROCMes=0;this.AV8cCOSTONRFFPROCAno=0;this.AV9cCod_Area="";this.AV10cIndicadoresCodigo="";this.AV11cMOTIVOSCOSRFFPROCod="";this.AV12cCOSTONRFFPROCValor=0;this.AV13pCOSTONRFFPROCFec=gx.date.nullDate();this.AV14pCOSTONRFFPROCMes=0;this.AV15pCOSTONRFFPROCAno=0;this.AV16pCod_Area="";this.AV17pIndicadoresCodigo="";this.AV18pMOTIVOSCOSRFFPROCod="";this.AV5LinkSelection="";this.A71COSTONRFFPROCFec=gx.date.nullDate();this.A72COSTONRFFPROCMes=0;this.A73COSTONRFFPROCAno=0;this.A5Cod_Area="";this.A168COSTONRFFPROCValor=0;this.A4IndicadoresCodigo="";this.A53MOTIVOSCOSRFFPROCod="";this.Events={e210s2_client:["ENTER",!0],e220s1_client:["CANCEL",!0],e180s1_client:["'TOGGLE'",!1],e110s1_client:["LBLCOSTONRFFPROCFECFILTER.CLICK",!1],e120s1_client:["LBLCOSTONRFFPROCMESFILTER.CLICK",!1],e130s1_client:["LBLCOSTONRFFPROCANOFILTER.CLICK",!1],e140s1_client:["LBLCOD_AREAFILTER.CLICK",!1],e150s1_client:["LBLINDICADORESCODIGOFILTER.CLICK",!1],e160s1_client:["LBLMOTIVOSCOSRFFPROCODFILTER.CLICK",!1],e170s1_client:["LBLCOSTONRFFPROCVALORFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCOSTONRFFPROCFec",fld:"vCCOSTONRFFPROCFEC",pic:""},{av:"AV7cCOSTONRFFPROCMes",fld:"vCCOSTONRFFPROCMES",pic:"ZZZ9"},{av:"AV8cCOSTONRFFPROCAno",fld:"vCCOSTONRFFPROCANO",pic:"ZZZ9"},{av:"AV9cCod_Area",fld:"vCCOD_AREA",pic:""},{av:"AV10cIndicadoresCodigo",fld:"vCINDICADORESCODIGO",pic:""},{av:"AV11cMOTIVOSCOSRFFPROCod",fld:"vCMOTIVOSCOSRFFPROCOD",pic:""},{av:"AV12cCOSTONRFFPROCValor",fld:"vCCOSTONRFFPROCVALOR",pic:"ZZZZZZZZZ9.9999"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLCOSTONRFFPROCFECFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("COSTONRFFPROCFECFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCFECFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("COSTONRFFPROCFECFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCFECFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLCOSTONRFFPROCMESFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("COSTONRFFPROCMESFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCMESFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("COSTONRFFPROCMESFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCMESFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOSTONRFFPROCMES","Visible")',ctrl:"vCCOSTONRFFPROCMES",prop:"Visible"}]];this.EvtParms["LBLCOSTONRFFPROCANOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("COSTONRFFPROCANOFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCANOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("COSTONRFFPROCANOFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCANOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOSTONRFFPROCANO","Visible")',ctrl:"vCCOSTONRFFPROCANO",prop:"Visible"}]];this.EvtParms["LBLCOD_AREAFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("COD_AREAFILTERCONTAINER","Class")',ctrl:"COD_AREAFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("COD_AREAFILTERCONTAINER","Class")',ctrl:"COD_AREAFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOD_AREA","Visible")',ctrl:"vCCOD_AREA",prop:"Visible"}]];this.EvtParms["LBLINDICADORESCODIGOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class")',ctrl:"INDICADORESCODIGOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("INDICADORESCODIGOFILTERCONTAINER","Class")',ctrl:"INDICADORESCODIGOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCINDICADORESCODIGO","Visible")',ctrl:"vCINDICADORESCODIGO",prop:"Visible"}]];this.EvtParms["LBLMOTIVOSCOSRFFPROCODFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("MOTIVOSCOSRFFPROCODFILTERCONTAINER","Class")',ctrl:"MOTIVOSCOSRFFPROCODFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("MOTIVOSCOSRFFPROCODFILTERCONTAINER","Class")',ctrl:"MOTIVOSCOSRFFPROCODFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCMOTIVOSCOSRFFPROCOD","Visible")',ctrl:"vCMOTIVOSCOSRFFPROCOD",prop:"Visible"}]];this.EvtParms["LBLCOSTONRFFPROCVALORFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("COSTONRFFPROCVALORFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCVALORFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("COSTONRFFPROCVALORFILTERCONTAINER","Class")',ctrl:"COSTONRFFPROCVALORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOSTONRFFPROCVALOR","Visible")',ctrl:"vCCOSTONRFFPROCVALOR",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A71COSTONRFFPROCFec",fld:"COSTONRFFPROCFEC",pic:"",hsh:!0},{av:"A72COSTONRFFPROCMes",fld:"COSTONRFFPROCMES",pic:"ZZZ9",hsh:!0},{av:"A73COSTONRFFPROCAno",fld:"COSTONRFFPROCANO",pic:"ZZZ9",hsh:!0},{av:"A5Cod_Area",fld:"COD_AREA",pic:"",hsh:!0},{av:"A4IndicadoresCodigo",fld:"INDICADORESCODIGO",pic:"",hsh:!0},{av:"A53MOTIVOSCOSRFFPROCod",fld:"MOTIVOSCOSRFFPROCOD",pic:"",hsh:!0}],[{av:"AV13pCOSTONRFFPROCFec",fld:"vPCOSTONRFFPROCFEC",pic:""},{av:"AV14pCOSTONRFFPROCMes",fld:"vPCOSTONRFFPROCMES",pic:"ZZZ9"},{av:"AV15pCOSTONRFFPROCAno",fld:"vPCOSTONRFFPROCANO",pic:"ZZZ9"},{av:"AV16pCod_Area",fld:"vPCOD_AREA",pic:""},{av:"AV17pIndicadoresCodigo",fld:"vPINDICADORESCODIGO",pic:""},{av:"AV18pMOTIVOSCOSRFFPROCod",fld:"vPMOTIVOSCOSRFFPROCOD",pic:""}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCOSTONRFFPROCFec",fld:"vCCOSTONRFFPROCFEC",pic:""},{av:"AV7cCOSTONRFFPROCMes",fld:"vCCOSTONRFFPROCMES",pic:"ZZZ9"},{av:"AV8cCOSTONRFFPROCAno",fld:"vCCOSTONRFFPROCANO",pic:"ZZZ9"},{av:"AV9cCod_Area",fld:"vCCOD_AREA",pic:""},{av:"AV10cIndicadoresCodigo",fld:"vCINDICADORESCODIGO",pic:""},{av:"AV11cMOTIVOSCOSRFFPROCod",fld:"vCMOTIVOSCOSRFFPROCOD",pic:""},{av:"AV12cCOSTONRFFPROCValor",fld:"vCCOSTONRFFPROCVALOR",pic:"ZZZZZZZZZ9.9999"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCOSTONRFFPROCFec",fld:"vCCOSTONRFFPROCFEC",pic:""},{av:"AV7cCOSTONRFFPROCMes",fld:"vCCOSTONRFFPROCMES",pic:"ZZZ9"},{av:"AV8cCOSTONRFFPROCAno",fld:"vCCOSTONRFFPROCANO",pic:"ZZZ9"},{av:"AV9cCod_Area",fld:"vCCOD_AREA",pic:""},{av:"AV10cIndicadoresCodigo",fld:"vCINDICADORESCODIGO",pic:""},{av:"AV11cMOTIVOSCOSRFFPROCod",fld:"vCMOTIVOSCOSRFFPROCOD",pic:""},{av:"AV12cCOSTONRFFPROCValor",fld:"vCCOSTONRFFPROCVALOR",pic:"ZZZZZZZZZ9.9999"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCOSTONRFFPROCFec",fld:"vCCOSTONRFFPROCFEC",pic:""},{av:"AV7cCOSTONRFFPROCMes",fld:"vCCOSTONRFFPROCMES",pic:"ZZZ9"},{av:"AV8cCOSTONRFFPROCAno",fld:"vCCOSTONRFFPROCANO",pic:"ZZZ9"},{av:"AV9cCod_Area",fld:"vCCOD_AREA",pic:""},{av:"AV10cIndicadoresCodigo",fld:"vCINDICADORESCODIGO",pic:""},{av:"AV11cMOTIVOSCOSRFFPROCod",fld:"vCMOTIVOSCOSRFFPROCOD",pic:""},{av:"AV12cCOSTONRFFPROCValor",fld:"vCCOSTONRFFPROCVALOR",pic:"ZZZZZZZZZ9.9999"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cCOSTONRFFPROCFec",fld:"vCCOSTONRFFPROCFEC",pic:""},{av:"AV7cCOSTONRFFPROCMes",fld:"vCCOSTONRFFPROCMES",pic:"ZZZ9"},{av:"AV8cCOSTONRFFPROCAno",fld:"vCCOSTONRFFPROCANO",pic:"ZZZ9"},{av:"AV9cCod_Area",fld:"vCCOD_AREA",pic:""},{av:"AV10cIndicadoresCodigo",fld:"vCINDICADORESCODIGO",pic:""},{av:"AV11cMOTIVOSCOSRFFPROCod",fld:"vCMOTIVOSCOSRFFPROCOD",pic:""},{av:"AV12cCOSTONRFFPROCValor",fld:"vCCOSTONRFFPROCVALOR",pic:"ZZZZZZZZZ9.9999"}],[]];this.EvtParms.VALIDV_CCOSTONRFFPROCFEC=[[],[]];this.setVCMap("AV13pCOSTONRFFPROCFec","vPCOSTONRFFPROCFEC",0,"date",8,0);this.setVCMap("AV14pCOSTONRFFPROCMes","vPCOSTONRFFPROCMES",0,"int",4,0);this.setVCMap("AV15pCOSTONRFFPROCAno","vPCOSTONRFFPROCANO",0,"int",4,0);this.setVCMap("AV16pCod_Area","vPCOD_AREA",0,"svchar",40,0);this.setVCMap("AV17pIndicadoresCodigo","vPINDICADORESCODIGO",0,"svchar",40,0);this.setVCMap("AV18pMOTIVOSCOSRFFPROCod","vPMOTIVOSCOSRFFPROCOD",0,"svchar",40,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingVar(this.GXValidFnc[66]);t.addRefreshingVar(this.GXValidFnc[76]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[66]);t.addRefreshingParm(this.GXValidFnc[76]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00q0)})