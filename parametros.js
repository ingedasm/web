gx.evt.autoSkip=!1;gx.define("parametros",!1,function(){this.ServerClass="parametros";this.PackageName="GeneXus.Programs";this.ServerFullClass="parametros.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="IndicadroresPalmas";this.SetStandaloneVars=function(){};this.Valid_Parametroscodigo=function(){return this.validSrvEvt("Valid_Parametroscodigo",0).then(function(n){return n}.closure(this))};this.Valid_Indicadorescodigo=function(){return this.validSrvEvt("Valid_Indicadorescodigo",0).then(function(n){return n}.closure(this))};this.e110g17_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e120g17_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74];this.GXLastCtrlId=74;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e130g17_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e140g17_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e150g17_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e160g17_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e170g17_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Parametroscodigo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSCODIGO",fmt:0,gxz:"Z35ParametrosCodigo",gxold:"O35ParametrosCodigo",gxvar:"A35ParametrosCodigo",ucs:[],op:[49,64,59,54,44,39],ip:[49,64,59,54,44,39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A35ParametrosCodigo=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z35ParametrosCodigo=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PARAMETROSCODIGO",gx.O.A35ParametrosCodigo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A35ParametrosCodigo=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PARAMETROSCODIGO",".")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSNOMBRES",fmt:0,gxz:"Z145ParametrosNombres",gxold:"O145ParametrosNombres",gxvar:"A145ParametrosNombres",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A145ParametrosNombres=n)},v2z:function(n){n!==undefined&&(gx.O.Z145ParametrosNombres=n)},v2c:function(){gx.fn.setControlValue("PARAMETROSNOMBRES",gx.O.A145ParametrosNombres,0)},c2v:function(){this.val()!==undefined&&(gx.O.A145ParametrosNombres=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROSNOMBRES")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSTIPO",fmt:0,gxz:"Z146ParametrosTipo",gxold:"O146ParametrosTipo",gxvar:"A146ParametrosTipo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A146ParametrosTipo=n)},v2z:function(n){n!==undefined&&(gx.O.Z146ParametrosTipo=n)},v2c:function(){gx.fn.setComboBoxValue("PARAMETROSTIPO",gx.O.A146ParametrosTipo)},c2v:function(){this.val()!==undefined&&(gx.O.A146ParametrosTipo=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROSTIPO")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Indicadorescodigo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INDICADORESCODIGO",fmt:0,gxz:"Z4IndicadoresCodigo",gxold:"O4IndicadoresCodigo",gxvar:"A4IndicadoresCodigo",ucs:[],op:[],ip:[49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A4IndicadoresCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.Z4IndicadoresCodigo=n)},v2c:function(){gx.fn.setControlValue("INDICADORESCODIGO",gx.O.A4IndicadoresCodigo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A4IndicadoresCodigo=this.val())},val:function(){return gx.fn.getControlValue("INDICADORESCODIGO")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSMES",fmt:0,gxz:"Z147ParametrosMes",gxold:"O147ParametrosMes",gxvar:"A147ParametrosMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A147ParametrosMes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z147ParametrosMes=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PARAMETROSMES",gx.O.A147ParametrosMes,0)},c2v:function(){this.val()!==undefined&&(gx.O.A147ParametrosMes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PARAMETROSMES",".")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSANO",fmt:0,gxz:"Z148ParametrosAno",gxold:"O148ParametrosAno",gxvar:"A148ParametrosAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A148ParametrosAno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z148ParametrosAno=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PARAMETROSANO",gx.O.A148ParametrosAno,0)},c2v:function(){this.val()!==undefined&&(gx.O.A148ParametrosAno=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PARAMETROSANO",".")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"decimal",len:15,dec:4,sign:!1,pic:"ZZZZZZZZZ9.9999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROSVALOR",fmt:0,gxz:"Z149ParametrosValor",gxold:"O149ParametrosValor",gxvar:"A149ParametrosValor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A149ParametrosValor=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z149ParametrosValor=gx.fn.toDecimalValue(n,".",","))},v2c:function(){gx.fn.setDecimalValue("PARAMETROSVALOR",gx.O.A149ParametrosValor,4,",")},c2v:function(){this.val()!==undefined&&(gx.O.A149ParametrosValor=this.val())},val:function(){return gx.fn.getDecimalValue("PARAMETROSVALOR",".",",")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"BTN_ENTER",grid:0,evt:"e110g17_client",std:"ENTER"};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"BTN_CANCEL",grid:0,evt:"e120g17_client"};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"BTN_DELETE",grid:0,evt:"e180g17_client",std:"DELETE"};n[74]={id:74,fld:"PROMPT_4",grid:17};this.A35ParametrosCodigo=0;this.Z35ParametrosCodigo=0;this.O35ParametrosCodigo=0;this.A145ParametrosNombres="";this.Z145ParametrosNombres="";this.O145ParametrosNombres="";this.A146ParametrosTipo="";this.Z146ParametrosTipo="";this.O146ParametrosTipo="";this.A4IndicadoresCodigo="";this.Z4IndicadoresCodigo="";this.O4IndicadoresCodigo="";this.A147ParametrosMes=0;this.Z147ParametrosMes=0;this.O147ParametrosMes=0;this.A148ParametrosAno=0;this.Z148ParametrosAno=0;this.O148ParametrosAno=0;this.A149ParametrosValor=0;this.Z149ParametrosValor=0;this.O149ParametrosValor=0;this.A35ParametrosCodigo=0;this.A145ParametrosNombres="";this.A146ParametrosTipo="";this.A4IndicadoresCodigo="";this.A147ParametrosMes=0;this.A148ParametrosAno=0;this.A149ParametrosValor=0;this.Events={e110g17_client:["ENTER",!0],e120g17_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_PARAMETROSCODIGO=[[{ctrl:"PARAMETROSTIPO"},{av:"A146ParametrosTipo",fld:"PARAMETROSTIPO",pic:""},{av:"A35ParametrosCodigo",fld:"PARAMETROSCODIGO",pic:"ZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A145ParametrosNombres",fld:"PARAMETROSNOMBRES",pic:""},{ctrl:"PARAMETROSTIPO"},{av:"A146ParametrosTipo",fld:"PARAMETROSTIPO",pic:""},{av:"A4IndicadoresCodigo",fld:"INDICADORESCODIGO",pic:""},{av:"A147ParametrosMes",fld:"PARAMETROSMES",pic:"ZZZ9"},{av:"A148ParametrosAno",fld:"PARAMETROSANO",pic:"ZZZ9"},{av:"A149ParametrosValor",fld:"PARAMETROSVALOR",pic:"ZZZZZZZZZ9.9999"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z35ParametrosCodigo"},{av:"Z145ParametrosNombres"},{av:"Z146ParametrosTipo"},{av:"Z4IndicadoresCodigo"},{av:"Z147ParametrosMes"},{av:"Z148ParametrosAno"},{av:"Z149ParametrosValor"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_INDICADORESCODIGO=[[{av:"A4IndicadoresCodigo",fld:"INDICADORESCODIGO",pic:""}],[]];this.setPrompt("PROMPT_4",[49]);this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.parametros)})