gx.evt.autoSkip=!1;gx.define("costotonrffprodu",!1,function(){this.ServerClass="costotonrffprodu";this.PackageName="GeneXus.Programs";this.ServerFullClass="costotonrffprodu.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="IndicadroresPalmas";this.SetStandaloneVars=function(){};this.Valid_Costotonrffprodufecha=function(){return this.validCliEvt("Valid_Costotonrffprodufecha",0,function(){try{var n=gx.util.balloon.getNew("COSTOTONRFFPRODUFECHA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A77COSTOTONRFFPRODUFecha)==0||new gx.date.gxdate(this.A77COSTOTONRFFPRODUFecha).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo COSTOTONRFFPRODUFecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Costotonrffprodumes=function(){return this.validCliEvt("Valid_Costotonrffprodumes",0,function(){try{var n=gx.util.balloon.getNew("COSTOTONRFFPRODUMES");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Costotonrffproduano=function(){return this.validCliEvt("Valid_Costotonrffproduano",0,function(){try{var n=gx.util.balloon.getNew("COSTOTONRFFPRODUANO");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Cod_area=function(){return this.validSrvEvt("Valid_Cod_area",0).then(function(n){return n}.closure(this))};this.Valid_Indicadorescodigo=function(){return this.validSrvEvt("Valid_Indicadorescodigo",0).then(function(n){return n}.closure(this))};this.Valid_Motivotonrffcod=function(){return this.validSrvEvt("Valid_Motivotonrffcod",0).then(function(n){return n}.closure(this))};this.e111037_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e121037_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76];this.GXLastCtrlId=76;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e131037_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e141037_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e151037_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e161037_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e171037_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Costotonrffprodufecha,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTOTONRFFPRODUFECHA",fmt:0,gxz:"Z77COSTOTONRFFPRODUFecha",gxold:"O77COSTOTONRFFPRODUFecha",gxvar:"A77COSTOTONRFFPRODUFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[34],ip:[34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A77COSTOTONRFFPRODUFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z77COSTOTONRFFPRODUFecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("COSTOTONRFFPRODUFECHA",gx.O.A77COSTOTONRFFPRODUFecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.A77COSTOTONRFFPRODUFecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("COSTOTONRFFPRODUFECHA")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Costotonrffprodumes,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTOTONRFFPRODUMES",fmt:0,gxz:"Z78COSTOTONRFFPRODUMes",gxold:"O78COSTOTONRFFPRODUMes",gxvar:"A78COSTOTONRFFPRODUMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A78COSTOTONRFFPRODUMes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z78COSTOTONRFFPRODUMes=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("COSTOTONRFFPRODUMES",gx.O.A78COSTOTONRFFPRODUMes,0)},c2v:function(){this.val()!==undefined&&(gx.O.A78COSTOTONRFFPRODUMes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("COSTOTONRFFPRODUMES",".")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Costotonrffproduano,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTOTONRFFPRODUANO",fmt:0,gxz:"Z79COSTOTONRFFPRODUAno",gxold:"O79COSTOTONRFFPRODUAno",gxvar:"A79COSTOTONRFFPRODUAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A79COSTOTONRFFPRODUAno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z79COSTOTONRFFPRODUAno=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("COSTOTONRFFPRODUANO",gx.O.A79COSTOTONRFFPRODUAno,0)},c2v:function(){this.val()!==undefined&&(gx.O.A79COSTOTONRFFPRODUAno=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("COSTOTONRFFPRODUANO",".")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cod_area,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COD_AREA",fmt:0,gxz:"Z5Cod_Area",gxold:"O5Cod_Area",gxvar:"A5Cod_Area",ucs:[],op:[],ip:[49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5Cod_Area=n)},v2z:function(n){n!==undefined&&(gx.O.Z5Cod_Area=n)},v2c:function(){gx.fn.setControlValue("COD_AREA",gx.O.A5Cod_Area,0)},c2v:function(){this.val()!==undefined&&(gx.O.A5Cod_Area=this.val())},val:function(){return gx.fn.getControlValue("COD_AREA")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Indicadorescodigo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INDICADORESCODIGO",fmt:0,gxz:"Z4IndicadoresCodigo",gxold:"O4IndicadoresCodigo",gxvar:"A4IndicadoresCodigo",ucs:[],op:[],ip:[54],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A4IndicadoresCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.Z4IndicadoresCodigo=n)},v2c:function(){gx.fn.setControlValue("INDICADORESCODIGO",gx.O.A4IndicadoresCodigo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A4IndicadoresCodigo=this.val())},val:function(){return gx.fn.getControlValue("INDICADORESCODIGO")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"svchar",len:140,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Motivotonrffcod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MOTIVOTONRFFCOD",fmt:0,gxz:"Z65MOTIVOTONRFFcod",gxold:"O65MOTIVOTONRFFcod",gxvar:"A65MOTIVOTONRFFcod",ucs:[],op:[64],ip:[64,59,54,49,44,39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A65MOTIVOTONRFFcod=n)},v2z:function(n){n!==undefined&&(gx.O.Z65MOTIVOTONRFFcod=n)},v2c:function(){gx.fn.setControlValue("MOTIVOTONRFFCOD",gx.O.A65MOTIVOTONRFFcod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A65MOTIVOTONRFFcod=this.val())},val:function(){return gx.fn.getControlValue("MOTIVOTONRFFCOD")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"decimal",len:16,dec:2,sign:!1,pic:"ZZZZZZZZZZZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTOTONRFFPRODUVALOR",fmt:0,gxz:"Z196COSTOTONRFFPRODUValor",gxold:"O196COSTOTONRFFPRODUValor",gxvar:"A196COSTOTONRFFPRODUValor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A196COSTOTONRFFPRODUValor=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z196COSTOTONRFFPRODUValor=gx.fn.toDecimalValue(n,".",","))},v2c:function(){gx.fn.setDecimalValue("COSTOTONRFFPRODUVALOR",gx.O.A196COSTOTONRFFPRODUValor,2,",")},c2v:function(){this.val()!==undefined&&(gx.O.A196COSTOTONRFFPRODUValor=this.val())},val:function(){return gx.fn.getDecimalValue("COSTOTONRFFPRODUVALOR",".",",")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"BTN_ENTER",grid:0,evt:"e111037_client",std:"ENTER"};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"BTN_CANCEL",grid:0,evt:"e121037_client"};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"BTN_DELETE",grid:0,evt:"e181037_client",std:"DELETE"};n[74]={id:74,fld:"PROMPT_5",grid:37};n[75]={id:75,fld:"PROMPT_4",grid:37};n[76]={id:76,fld:"PROMPT_65",grid:37};this.A77COSTOTONRFFPRODUFecha=gx.date.nullDate();this.Z77COSTOTONRFFPRODUFecha=gx.date.nullDate();this.O77COSTOTONRFFPRODUFecha=gx.date.nullDate();this.A78COSTOTONRFFPRODUMes=0;this.Z78COSTOTONRFFPRODUMes=0;this.O78COSTOTONRFFPRODUMes=0;this.A79COSTOTONRFFPRODUAno=0;this.Z79COSTOTONRFFPRODUAno=0;this.O79COSTOTONRFFPRODUAno=0;this.A5Cod_Area="";this.Z5Cod_Area="";this.O5Cod_Area="";this.A4IndicadoresCodigo="";this.Z4IndicadoresCodigo="";this.O4IndicadoresCodigo="";this.A65MOTIVOTONRFFcod="";this.Z65MOTIVOTONRFFcod="";this.O65MOTIVOTONRFFcod="";this.A196COSTOTONRFFPRODUValor=0;this.Z196COSTOTONRFFPRODUValor=0;this.O196COSTOTONRFFPRODUValor=0;this.A77COSTOTONRFFPRODUFecha=gx.date.nullDate();this.A78COSTOTONRFFPRODUMes=0;this.A79COSTOTONRFFPRODUAno=0;this.A5Cod_Area="";this.A4IndicadoresCodigo="";this.A65MOTIVOTONRFFcod="";this.A196COSTOTONRFFPRODUValor=0;this.Events={e111037_client:["ENTER",!0],e121037_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_COSTOTONRFFPRODUFECHA=[[{av:"A77COSTOTONRFFPRODUFecha",fld:"COSTOTONRFFPRODUFECHA",pic:""}],[{av:"A77COSTOTONRFFPRODUFecha",fld:"COSTOTONRFFPRODUFECHA",pic:""}]];this.EvtParms.VALID_COSTOTONRFFPRODUMES=[[],[]];this.EvtParms.VALID_COSTOTONRFFPRODUANO=[[],[]];this.EvtParms.VALID_COD_AREA=[[{av:"A5Cod_Area",fld:"COD_AREA",pic:""}],[]];this.EvtParms.VALID_INDICADORESCODIGO=[[{av:"A4IndicadoresCodigo",fld:"INDICADORESCODIGO",pic:""}],[]];this.EvtParms.VALID_MOTIVOTONRFFCOD=[[{av:"A77COSTOTONRFFPRODUFecha",fld:"COSTOTONRFFPRODUFECHA",pic:""},{av:"A78COSTOTONRFFPRODUMes",fld:"COSTOTONRFFPRODUMES",pic:"ZZZ9"},{av:"A79COSTOTONRFFPRODUAno",fld:"COSTOTONRFFPRODUANO",pic:"ZZZ9"},{av:"A5Cod_Area",fld:"COD_AREA",pic:""},{av:"A4IndicadoresCodigo",fld:"INDICADORESCODIGO",pic:""},{av:"A65MOTIVOTONRFFcod",fld:"MOTIVOTONRFFCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A196COSTOTONRFFPRODUValor",fld:"COSTOTONRFFPRODUVALOR",pic:"ZZZZZZZZZZZZ9.99"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z77COSTOTONRFFPRODUFecha"},{av:"Z78COSTOTONRFFPRODUMes"},{av:"Z79COSTOTONRFFPRODUAno"},{av:"Z5Cod_Area"},{av:"Z4IndicadoresCodigo"},{av:"Z65MOTIVOTONRFFcod"},{av:"Z196COSTOTONRFFPRODUValor"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.setPrompt("PROMPT_5",[49]);this.setPrompt("PROMPT_4",[54]);this.setPrompt("PROMPT_65",[59]);this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.costotonrffprodu)})