gx.evt.autoSkip=!1;gx.define("costocpoproducido",!1,function(){this.ServerClass="costocpoproducido";this.PackageName="GeneXus.Programs";this.ServerFullClass="costocpoproducido.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="IndicadroresPalmas";this.SetStandaloneVars=function(){};this.Valid_Costocpoproducidofecha=function(){return this.validCliEvt("Valid_Costocpoproducidofecha",0,function(){try{var n=gx.util.balloon.getNew("COSTOCPOPRODUCIDOFECHA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A109COSTOCPOPRODUCIDOFecha)==0||new gx.date.gxdate(this.A109COSTOCPOPRODUCIDOFecha).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo COSTOCPOPRODUCIDOFecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Costocpoproducidomes=function(){return this.validCliEvt("Valid_Costocpoproducidomes",0,function(){try{var n=gx.util.balloon.getNew("COSTOCPOPRODUCIDOMES");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Costocpoproducidoano=function(){return this.validCliEvt("Valid_Costocpoproducidoano",0,function(){try{var n=gx.util.balloon.getNew("COSTOCPOPRODUCIDOANO");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Cod_area=function(){return this.validSrvEvt("Valid_Cod_area",0).then(function(n){return n}.closure(this))};this.Valid_Indicadorescodigo=function(){return this.validSrvEvt("Valid_Indicadorescodigo",0).then(function(n){return n}.closure(this))};this.Valid_Tiposcpocod=function(){return this.validSrvEvt("Valid_Tiposcpocod",0).then(function(n){return n}.closure(this))};this.Valid_Tipoproductocod=function(){return this.validSrvEvt("Valid_Tipoproductocod",0).then(function(n){return n}.closure(this))};this.Valid_Costocpoproducidoreg=function(){return this.validCliEvt("Valid_Costocpoproducidoreg",0,function(){try{var n=gx.util.balloon.getNew("COSTOCPOPRODUCIDOREG");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A193COSTOCPOPRODUCIDOReg)==0||new gx.date.gxdate(this.A193COSTOCPOPRODUCIDOReg).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo COSTOCPOPRODUCIDOReg fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110y35_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e120y35_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97];this.GXLastCtrlId=97;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e130y35_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e140y35_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e150y35_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e160y35_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e170y35_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Costocpoproducidofecha,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTOCPOPRODUCIDOFECHA",fmt:0,gxz:"Z109COSTOCPOPRODUCIDOFecha",gxold:"O109COSTOCPOPRODUCIDOFecha",gxvar:"A109COSTOCPOPRODUCIDOFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[34],ip:[34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A109COSTOCPOPRODUCIDOFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z109COSTOCPOPRODUCIDOFecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("COSTOCPOPRODUCIDOFECHA",gx.O.A109COSTOCPOPRODUCIDOFecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.A109COSTOCPOPRODUCIDOFecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("COSTOCPOPRODUCIDOFECHA")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Costocpoproducidomes,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTOCPOPRODUCIDOMES",fmt:0,gxz:"Z110COSTOCPOPRODUCIDOMes",gxold:"O110COSTOCPOPRODUCIDOMes",gxvar:"A110COSTOCPOPRODUCIDOMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A110COSTOCPOPRODUCIDOMes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z110COSTOCPOPRODUCIDOMes=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("COSTOCPOPRODUCIDOMES",gx.O.A110COSTOCPOPRODUCIDOMes,0)},c2v:function(){this.val()!==undefined&&(gx.O.A110COSTOCPOPRODUCIDOMes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("COSTOCPOPRODUCIDOMES",".")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Costocpoproducidoano,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTOCPOPRODUCIDOANO",fmt:0,gxz:"Z111COSTOCPOPRODUCIDOAno",gxold:"O111COSTOCPOPRODUCIDOAno",gxvar:"A111COSTOCPOPRODUCIDOAno",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A111COSTOCPOPRODUCIDOAno=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z111COSTOCPOPRODUCIDOAno=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("COSTOCPOPRODUCIDOANO",gx.O.A111COSTOCPOPRODUCIDOAno,0)},c2v:function(){this.val()!==undefined&&(gx.O.A111COSTOCPOPRODUCIDOAno=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("COSTOCPOPRODUCIDOANO",".")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Cod_area,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COD_AREA",fmt:0,gxz:"Z5Cod_Area",gxold:"O5Cod_Area",gxvar:"A5Cod_Area",ucs:[],op:[],ip:[49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5Cod_Area=n)},v2z:function(n){n!==undefined&&(gx.O.Z5Cod_Area=n)},v2c:function(){gx.fn.setControlValue("COD_AREA",gx.O.A5Cod_Area,0)},c2v:function(){this.val()!==undefined&&(gx.O.A5Cod_Area=this.val())},val:function(){return gx.fn.getControlValue("COD_AREA")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Indicadorescodigo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INDICADORESCODIGO",fmt:0,gxz:"Z4IndicadoresCodigo",gxold:"O4IndicadoresCodigo",gxvar:"A4IndicadoresCodigo",ucs:[],op:[],ip:[54],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A4IndicadoresCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.Z4IndicadoresCodigo=n)},v2c:function(){gx.fn.setControlValue("INDICADORESCODIGO",gx.O.A4IndicadoresCodigo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A4IndicadoresCodigo=this.val())},val:function(){return gx.fn.getControlValue("INDICADORESCODIGO")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"svchar",len:120,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tiposcpocod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOSCPOCOD",fmt:0,gxz:"Z64TIPOSCPOCod",gxold:"O64TIPOSCPOCod",gxvar:"A64TIPOSCPOCod",ucs:[],op:[],ip:[59],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A64TIPOSCPOCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z64TIPOSCPOCod=n)},v2c:function(){gx.fn.setControlValue("TIPOSCPOCOD",gx.O.A64TIPOSCPOCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A64TIPOSCPOCod=this.val())},val:function(){return gx.fn.getControlValue("TIPOSCPOCOD")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Tipoproductocod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOPRODUCTOCOD",fmt:0,gxz:"Z45TipoProductoCod",gxold:"O45TipoProductoCod",gxvar:"A45TipoProductoCod",ucs:[],op:[84,79,74,69],ip:[84,79,74,69,64,59,54,49,44,39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A45TipoProductoCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z45TipoProductoCod=n)},v2c:function(){gx.fn.setControlValue("TIPOPRODUCTOCOD",gx.O.A45TipoProductoCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A45TipoProductoCod=this.val())},val:function(){return gx.fn.getControlValue("TIPOPRODUCTOCOD")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTOCPOPRODUCIDOVALOR",fmt:0,gxz:"Z191COSTOCPOPRODUCIDOValor",gxold:"O191COSTOCPOPRODUCIDOValor",gxvar:"A191COSTOCPOPRODUCIDOValor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A191COSTOCPOPRODUCIDOValor=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z191COSTOCPOPRODUCIDOValor=gx.fn.toDecimalValue(n,".",","))},v2c:function(){gx.fn.setDecimalValue("COSTOCPOPRODUCIDOVALOR",gx.O.A191COSTOCPOPRODUCIDOValor,2,",")},c2v:function(){this.val()!==undefined&&(gx.O.A191COSTOCPOPRODUCIDOValor=this.val())},val:function(){return gx.fn.getDecimalValue("COSTOCPOPRODUCIDOVALOR",".",",")},nac:gx.falseFn};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"svchar",len:150,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTOCPOPRODUCIDOUSER",fmt:0,gxz:"Z192COSTOCPOPRODUCIDOUser",gxold:"O192COSTOCPOPRODUCIDOUser",gxvar:"A192COSTOCPOPRODUCIDOUser",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A192COSTOCPOPRODUCIDOUser=n)},v2z:function(n){n!==undefined&&(gx.O.Z192COSTOCPOPRODUCIDOUser=n)},v2c:function(){gx.fn.setControlValue("COSTOCPOPRODUCIDOUSER",gx.O.A192COSTOCPOPRODUCIDOUser,0)},c2v:function(){this.val()!==undefined&&(gx.O.A192COSTOCPOPRODUCIDOUser=this.val())},val:function(){return gx.fn.getControlValue("COSTOCPOPRODUCIDOUSER")},nac:gx.falseFn};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Costocpoproducidoreg,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTOCPOPRODUCIDOREG",fmt:0,gxz:"Z193COSTOCPOPRODUCIDOReg",gxold:"O193COSTOCPOPRODUCIDOReg",gxvar:"A193COSTOCPOPRODUCIDOReg",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[79],ip:[79],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A193COSTOCPOPRODUCIDOReg=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z193COSTOCPOPRODUCIDOReg=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("COSTOCPOPRODUCIDOREG",gx.O.A193COSTOCPOPRODUCIDOReg,0)},c2v:function(){this.val()!==undefined&&(gx.O.A193COSTOCPOPRODUCIDOReg=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("COSTOCPOPRODUCIDOREG")},nac:gx.falseFn};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COSTOCPOPRODUCIDOHOR",fmt:0,gxz:"Z194COSTOCPOPRODUCIDOHor",gxold:"O194COSTOCPOPRODUCIDOHor",gxvar:"A194COSTOCPOPRODUCIDOHor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A194COSTOCPOPRODUCIDOHor=n)},v2z:function(n){n!==undefined&&(gx.O.Z194COSTOCPOPRODUCIDOHor=n)},v2c:function(){gx.fn.setControlValue("COSTOCPOPRODUCIDOHOR",gx.O.A194COSTOCPOPRODUCIDOHor,0)},c2v:function(){this.val()!==undefined&&(gx.O.A194COSTOCPOPRODUCIDOHor=this.val())},val:function(){return gx.fn.getControlValue("COSTOCPOPRODUCIDOHOR")},nac:gx.falseFn};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"",grid:0};n[89]={id:89,fld:"BTN_ENTER",grid:0,evt:"e110y35_client",std:"ENTER"};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"BTN_CANCEL",grid:0,evt:"e120y35_client"};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"BTN_DELETE",grid:0,evt:"e180y35_client",std:"DELETE"};n[94]={id:94,fld:"PROMPT_5",grid:35};n[95]={id:95,fld:"PROMPT_4",grid:35};n[96]={id:96,fld:"PROMPT_64",grid:35};n[97]={id:97,fld:"PROMPT_45",grid:35};this.A109COSTOCPOPRODUCIDOFecha=gx.date.nullDate();this.Z109COSTOCPOPRODUCIDOFecha=gx.date.nullDate();this.O109COSTOCPOPRODUCIDOFecha=gx.date.nullDate();this.A110COSTOCPOPRODUCIDOMes=0;this.Z110COSTOCPOPRODUCIDOMes=0;this.O110COSTOCPOPRODUCIDOMes=0;this.A111COSTOCPOPRODUCIDOAno=0;this.Z111COSTOCPOPRODUCIDOAno=0;this.O111COSTOCPOPRODUCIDOAno=0;this.A5Cod_Area="";this.Z5Cod_Area="";this.O5Cod_Area="";this.A4IndicadoresCodigo="";this.Z4IndicadoresCodigo="";this.O4IndicadoresCodigo="";this.A64TIPOSCPOCod="";this.Z64TIPOSCPOCod="";this.O64TIPOSCPOCod="";this.A45TipoProductoCod="";this.Z45TipoProductoCod="";this.O45TipoProductoCod="";this.A191COSTOCPOPRODUCIDOValor=0;this.Z191COSTOCPOPRODUCIDOValor=0;this.O191COSTOCPOPRODUCIDOValor=0;this.A192COSTOCPOPRODUCIDOUser="";this.Z192COSTOCPOPRODUCIDOUser="";this.O192COSTOCPOPRODUCIDOUser="";this.A193COSTOCPOPRODUCIDOReg=gx.date.nullDate();this.Z193COSTOCPOPRODUCIDOReg=gx.date.nullDate();this.O193COSTOCPOPRODUCIDOReg=gx.date.nullDate();this.A194COSTOCPOPRODUCIDOHor="";this.Z194COSTOCPOPRODUCIDOHor="";this.O194COSTOCPOPRODUCIDOHor="";this.A109COSTOCPOPRODUCIDOFecha=gx.date.nullDate();this.A110COSTOCPOPRODUCIDOMes=0;this.A111COSTOCPOPRODUCIDOAno=0;this.A5Cod_Area="";this.A4IndicadoresCodigo="";this.A64TIPOSCPOCod="";this.A45TipoProductoCod="";this.A191COSTOCPOPRODUCIDOValor=0;this.A192COSTOCPOPRODUCIDOUser="";this.A193COSTOCPOPRODUCIDOReg=gx.date.nullDate();this.A194COSTOCPOPRODUCIDOHor="";this.Events={e110y35_client:["ENTER",!0],e120y35_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_COSTOCPOPRODUCIDOFECHA=[[{av:"A109COSTOCPOPRODUCIDOFecha",fld:"COSTOCPOPRODUCIDOFECHA",pic:""}],[{av:"A109COSTOCPOPRODUCIDOFecha",fld:"COSTOCPOPRODUCIDOFECHA",pic:""}]];this.EvtParms.VALID_COSTOCPOPRODUCIDOMES=[[],[]];this.EvtParms.VALID_COSTOCPOPRODUCIDOANO=[[],[]];this.EvtParms.VALID_COD_AREA=[[{av:"A5Cod_Area",fld:"COD_AREA",pic:""}],[]];this.EvtParms.VALID_INDICADORESCODIGO=[[{av:"A4IndicadoresCodigo",fld:"INDICADORESCODIGO",pic:""}],[]];this.EvtParms.VALID_TIPOSCPOCOD=[[{av:"A64TIPOSCPOCod",fld:"TIPOSCPOCOD",pic:""}],[]];this.EvtParms.VALID_TIPOPRODUCTOCOD=[[{av:"A109COSTOCPOPRODUCIDOFecha",fld:"COSTOCPOPRODUCIDOFECHA",pic:""},{av:"A110COSTOCPOPRODUCIDOMes",fld:"COSTOCPOPRODUCIDOMES",pic:"ZZZ9"},{av:"A111COSTOCPOPRODUCIDOAno",fld:"COSTOCPOPRODUCIDOANO",pic:"ZZZ9"},{av:"A5Cod_Area",fld:"COD_AREA",pic:""},{av:"A4IndicadoresCodigo",fld:"INDICADORESCODIGO",pic:""},{av:"A64TIPOSCPOCod",fld:"TIPOSCPOCOD",pic:""},{av:"A45TipoProductoCod",fld:"TIPOPRODUCTOCOD",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A191COSTOCPOPRODUCIDOValor",fld:"COSTOCPOPRODUCIDOVALOR",pic:"ZZZZZZ9.99"},{av:"A192COSTOCPOPRODUCIDOUser",fld:"COSTOCPOPRODUCIDOUSER",pic:""},{av:"A193COSTOCPOPRODUCIDOReg",fld:"COSTOCPOPRODUCIDOREG",pic:""},{av:"A194COSTOCPOPRODUCIDOHor",fld:"COSTOCPOPRODUCIDOHOR",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z109COSTOCPOPRODUCIDOFecha"},{av:"Z110COSTOCPOPRODUCIDOMes"},{av:"Z111COSTOCPOPRODUCIDOAno"},{av:"Z5Cod_Area"},{av:"Z4IndicadoresCodigo"},{av:"Z64TIPOSCPOCod"},{av:"Z45TipoProductoCod"},{av:"Z191COSTOCPOPRODUCIDOValor"},{av:"Z192COSTOCPOPRODUCIDOUser"},{av:"Z193COSTOCPOPRODUCIDOReg"},{av:"Z194COSTOCPOPRODUCIDOHor"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EvtParms.VALID_COSTOCPOPRODUCIDOREG=[[{av:"A193COSTOCPOPRODUCIDOReg",fld:"COSTOCPOPRODUCIDOREG",pic:""}],[{av:"A193COSTOCPOPRODUCIDOReg",fld:"COSTOCPOPRODUCIDOREG",pic:""}]];this.setPrompt("PROMPT_5",[49]);this.setPrompt("PROMPT_4",[54]);this.setPrompt("PROMPT_64",[59]);this.setPrompt("PROMPT_45",[64]);this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.costocpoproducido)})