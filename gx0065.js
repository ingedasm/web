gx.evt.autoSkip=!1;gx.define("gx0065",!1,function(){var n,t;this.ServerClass="gx0065";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0065.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="IndicadroresPalmas";this.SetStandaloneVars=function(){this.AV8pAusen_Fecha=gx.fn.getDateValue("vPAUSEN_FECHA");this.AV9pAusen_Mes=gx.fn.getIntegerValue("vPAUSEN_MES",".");this.AV10pAusen_Ano=gx.fn.getIntegerValue("vPAUSEN_ANO",".");this.AV11pIndicadoresCodigo=gx.fn.getControlValue("vPINDICADORESCODIGO");this.AV12pCod_Area=gx.fn.getControlValue("vPCOD_AREA");this.AV13pAusenArea_Fecha=gx.fn.getDateValue("vPAUSENAREA_FECHA");this.AV14pTipoAusen_Codigo=gx.fn.getControlValue("vPTIPOAUSEN_CODIGO");this.AV8pAusen_Fecha=gx.fn.getDateValue("vPAUSEN_FECHA");this.AV9pAusen_Mes=gx.fn.getIntegerValue("vPAUSEN_MES",".");this.AV10pAusen_Ano=gx.fn.getIntegerValue("vPAUSEN_ANO",".");this.AV11pIndicadoresCodigo=gx.fn.getControlValue("vPINDICADORESCODIGO");this.AV12pCod_Area=gx.fn.getControlValue("vPCOD_AREA")};this.Validv_Causenarea_fecha=function(){return this.validCliEvt("Validv_Causenarea_fecha",0,function(){try{var n=gx.util.balloon.getNew("vCAUSENAREA_FECHA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV6cAusenArea_Fecha)===0||new gx.date.gxdate(this.AV6cAusenArea_Fecha).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Ausen Area_Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e13071_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e11071_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("AUSENAREA_FECHAFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("AUSENAREA_FECHAFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("AUSENAREA_FECHAFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("AUSENAREA_FECHAFILTERCONTAINER","Class")',ctrl:"AUSENAREA_FECHAFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12071_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("TIPOAUSEN_CODIGOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("TIPOAUSEN_CODIGOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTIPOAUSEN_CODIGO","Visible",!0)):(gx.fn.setCtrlProperty("TIPOAUSEN_CODIGOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTIPOAUSEN_CODIGO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TIPOAUSEN_CODIGOFILTERCONTAINER","Class")',ctrl:"TIPOAUSEN_CODIGOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTIPOAUSEN_CODIGO","Visible")',ctrl:"vCTIPOAUSEN_CODIGO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e16072_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e17071_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,35,36,37,38,39,40,41,42,43,44,45,46,47];this.GXLastCtrlId=47;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",34,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0065",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",35,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(10,36,"AUSENAREA_FECHA","Area_Fecha","","AusenArea_Fecha","date",0,"px",8,8,"right",null,[],10,"AusenArea_Fecha",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(11,37,"TIPOAUSEN_CODIGO","Tipo Ausen_Codigo","","TipoAusen_Codigo","svchar",0,"px",40,40,"left",null,[],11,"TipoAusen_Codigo",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(12,38,"AUSENAREAVALOR","Area Valor","","AusenAreaValor","decimal",0,"px",15,15,"right",null,[],12,"AusenAreaValor",!0,2,!1,!1,"DescriptionAttribute",0,"WWColumn");t.addSingleLineEdit(14,39,"AUSENTISMOSAREAREG","Area Reg","","AusentismosAreaReg","date",0,"px",8,8,"right",null,[],14,"AusentismosAreaReg",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(1,40,"AUSEN_FECHA","Ausen_Fecha","","Ausen_Fecha","date",0,"px",8,8,"right",null,[],1,"Ausen_Fecha",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(2,41,"AUSEN_MES","Ausen_Mes","","Ausen_Mes","int",0,"px",4,4,"right",null,[],2,"Ausen_Mes",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(3,42,"AUSEN_ANO","Ausen_Ano","","Ausen_Ano","int",0,"px",4,4,"right",null,[],3,"Ausen_Ano",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(4,43,"INDICADORESCODIGO","Indicadores Codigo","","IndicadoresCodigo","svchar",0,"px",40,40,"left",null,[],4,"IndicadoresCodigo",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(5,44,"COD_AREA","Cod_Area","","Cod_Area","svchar",0,"px",40,40,"left",null,[],5,"Cod_Area",!1,0,!1,!1,"Attribute",0,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"AUSENAREA_FECHAFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLAUSENAREA_FECHAFILTER",format:1,grid:0,evt:"e11071_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Causenarea_fecha,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCAUSENAREA_FECHA",fmt:0,gxz:"ZV6cAusenArea_Fecha",gxold:"OV6cAusenArea_Fecha",gxvar:"AV6cAusenArea_Fecha",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[16],ip:[16],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cAusenArea_Fecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cAusenArea_Fecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCAUSENAREA_FECHA",gx.O.AV6cAusenArea_Fecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cAusenArea_Fecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCAUSENAREA_FECHA")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"TIPOAUSEN_CODIGOFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLTIPOAUSEN_CODIGOFILTER",format:1,grid:0,evt:"e12071_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTIPOAUSEN_CODIGO",fmt:0,gxz:"ZV7cTipoAusen_Codigo",gxold:"OV7cTipoAusen_Codigo",gxvar:"AV7cTipoAusen_Codigo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cTipoAusen_Codigo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cTipoAusen_Codigo=n)},v2c:function(){gx.fn.setControlValue("vCTIPOAUSEN_CODIGO",gx.O.AV7cTipoAusen_Codigo,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cTipoAusen_Codigo=this.val())},val:function(){return gx.fn.getControlValue("vCTIPOAUSEN_CODIGO")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"GRIDTABLE",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"BTNTOGGLE",grid:0,evt:"e13071_client"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34),gx.O.AV5LinkSelection,gx.O.AV18Linkselection_GXI)},c2v:function(n){gx.O.AV18Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(34))},gxvar_GXI:"AV18Linkselection_GXI",nac:gx.falseFn};n[36]={id:36,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUSENAREA_FECHA",fmt:0,gxz:"Z10AusenArea_Fecha",gxold:"O10AusenArea_Fecha",gxvar:"A10AusenArea_Fecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A10AusenArea_Fecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z10AusenArea_Fecha=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("AUSENAREA_FECHA",n||gx.fn.currentGridRowImpl(34),gx.O.A10AusenArea_Fecha,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A10AusenArea_Fecha=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("AUSENAREA_FECHA",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOAUSEN_CODIGO",fmt:0,gxz:"Z11TipoAusen_Codigo",gxold:"O11TipoAusen_Codigo",gxvar:"A11TipoAusen_Codigo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A11TipoAusen_Codigo=n)},v2z:function(n){n!==undefined&&(gx.O.Z11TipoAusen_Codigo=n)},v2c:function(n){gx.fn.setGridControlValue("TIPOAUSEN_CODIGO",n||gx.fn.currentGridRowImpl(34),gx.O.A11TipoAusen_Codigo,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A11TipoAusen_Codigo=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TIPOAUSEN_CODIGO",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[38]={id:38,lvl:2,type:"decimal",len:15,dec:2,sign:!1,pic:"ZZZZZZZZZZZ9.99",ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUSENAREAVALOR",fmt:0,gxz:"Z12AusenAreaValor",gxold:"O12AusenAreaValor",gxvar:"A12AusenAreaValor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A12AusenAreaValor=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z12AusenAreaValor=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("AUSENAREAVALOR",n||gx.fn.currentGridRowImpl(34),gx.O.A12AusenAreaValor,2,",")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A12AusenAreaValor=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("AUSENAREAVALOR",n||gx.fn.currentGridRowImpl(34),".",",")},nac:gx.falseFn};n[39]={id:39,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUSENTISMOSAREAREG",fmt:0,gxz:"Z14AusentismosAreaReg",gxold:"O14AusentismosAreaReg",gxvar:"A14AusentismosAreaReg",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A14AusentismosAreaReg=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z14AusentismosAreaReg=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("AUSENTISMOSAREAREG",n||gx.fn.currentGridRowImpl(34),gx.O.A14AusentismosAreaReg,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A14AusentismosAreaReg=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("AUSENTISMOSAREAREG",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[40]={id:40,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUSEN_FECHA",fmt:0,gxz:"Z1Ausen_Fecha",gxold:"O1Ausen_Fecha",gxvar:"A1Ausen_Fecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1Ausen_Fecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z1Ausen_Fecha=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("AUSEN_FECHA",n||gx.fn.currentGridRowImpl(34),gx.O.A1Ausen_Fecha,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1Ausen_Fecha=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("AUSEN_FECHA",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[41]={id:41,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUSEN_MES",fmt:0,gxz:"Z2Ausen_Mes",gxold:"O2Ausen_Mes",gxvar:"A2Ausen_Mes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A2Ausen_Mes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2Ausen_Mes=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("AUSEN_MES",n||gx.fn.currentGridRowImpl(34),gx.O.A2Ausen_Mes,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2Ausen_Mes=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("AUSEN_MES",n||gx.fn.currentGridRowImpl(34),".")},nac:gx.falseFn};n[42]={id:42,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUSEN_ANO",fmt:0,gxz:"Z3Ausen_Ano",gxold:"O3Ausen_Ano",gxvar:"A3Ausen_Ano",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A3Ausen_Ano=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z3Ausen_Ano=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("AUSEN_ANO",n||gx.fn.currentGridRowImpl(34),gx.O.A3Ausen_Ano,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A3Ausen_Ano=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("AUSEN_ANO",n||gx.fn.currentGridRowImpl(34),".")},nac:gx.falseFn};n[43]={id:43,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INDICADORESCODIGO",fmt:0,gxz:"Z4IndicadoresCodigo",gxold:"O4IndicadoresCodigo",gxvar:"A4IndicadoresCodigo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A4IndicadoresCodigo=n)},v2z:function(n){n!==undefined&&(gx.O.Z4IndicadoresCodigo=n)},v2c:function(n){gx.fn.setGridControlValue("INDICADORESCODIGO",n||gx.fn.currentGridRowImpl(34),gx.O.A4IndicadoresCodigo,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4IndicadoresCodigo=this.val(n))},val:function(n){return gx.fn.getGridControlValue("INDICADORESCODIGO",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[44]={id:44,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COD_AREA",fmt:0,gxz:"Z5Cod_Area",gxold:"O5Cod_Area",gxvar:"A5Cod_Area",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A5Cod_Area=n)},v2z:function(n){n!==undefined&&(gx.O.Z5Cod_Area=n)},v2c:function(n){gx.fn.setGridControlValue("COD_AREA",n||gx.fn.currentGridRowImpl(34),gx.O.A5Cod_Area,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5Cod_Area=this.val(n))},val:function(n){return gx.fn.getGridControlValue("COD_AREA",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"BTN_CANCEL",grid:0,evt:"e17071_client"};this.AV6cAusenArea_Fecha=gx.date.nullDate();this.ZV6cAusenArea_Fecha=gx.date.nullDate();this.OV6cAusenArea_Fecha=gx.date.nullDate();this.AV7cTipoAusen_Codigo="";this.ZV7cTipoAusen_Codigo="";this.OV7cTipoAusen_Codigo="";this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z10AusenArea_Fecha=gx.date.nullDate();this.O10AusenArea_Fecha=gx.date.nullDate();this.Z11TipoAusen_Codigo="";this.O11TipoAusen_Codigo="";this.Z12AusenAreaValor=0;this.O12AusenAreaValor=0;this.Z14AusentismosAreaReg=gx.date.nullDate();this.O14AusentismosAreaReg=gx.date.nullDate();this.Z1Ausen_Fecha=gx.date.nullDate();this.O1Ausen_Fecha=gx.date.nullDate();this.Z2Ausen_Mes=0;this.O2Ausen_Mes=0;this.Z3Ausen_Ano=0;this.O3Ausen_Ano=0;this.Z4IndicadoresCodigo="";this.O4IndicadoresCodigo="";this.Z5Cod_Area="";this.O5Cod_Area="";this.AV6cAusenArea_Fecha=gx.date.nullDate();this.AV7cTipoAusen_Codigo="";this.AV8pAusen_Fecha=gx.date.nullDate();this.AV9pAusen_Mes=0;this.AV10pAusen_Ano=0;this.AV11pIndicadoresCodigo="";this.AV12pCod_Area="";this.AV13pAusenArea_Fecha=gx.date.nullDate();this.AV14pTipoAusen_Codigo="";this.AV5LinkSelection="";this.A10AusenArea_Fecha=gx.date.nullDate();this.A11TipoAusen_Codigo="";this.A12AusenAreaValor=0;this.A14AusentismosAreaReg=gx.date.nullDate();this.A1Ausen_Fecha=gx.date.nullDate();this.A2Ausen_Mes=0;this.A3Ausen_Ano=0;this.A4IndicadoresCodigo="";this.A5Cod_Area="";this.Events={e16072_client:["ENTER",!0],e17071_client:["CANCEL",!0],e13071_client:["'TOGGLE'",!1],e11071_client:["LBLAUSENAREA_FECHAFILTER.CLICK",!1],e12071_client:["LBLTIPOAUSEN_CODIGOFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cAusenArea_Fecha",fld:"vCAUSENAREA_FECHA",pic:""},{av:"AV7cTipoAusen_Codigo",fld:"vCTIPOAUSEN_CODIGO",pic:""},{av:"AV8pAusen_Fecha",fld:"vPAUSEN_FECHA",pic:""},{av:"AV9pAusen_Mes",fld:"vPAUSEN_MES",pic:"ZZZ9"},{av:"AV10pAusen_Ano",fld:"vPAUSEN_ANO",pic:"ZZZ9"},{av:"AV11pIndicadoresCodigo",fld:"vPINDICADORESCODIGO",pic:""},{av:"AV12pCod_Area",fld:"vPCOD_AREA",pic:""}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLAUSENAREA_FECHAFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("AUSENAREA_FECHAFILTERCONTAINER","Class")',ctrl:"AUSENAREA_FECHAFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("AUSENAREA_FECHAFILTERCONTAINER","Class")',ctrl:"AUSENAREA_FECHAFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLTIPOAUSEN_CODIGOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TIPOAUSEN_CODIGOFILTERCONTAINER","Class")',ctrl:"TIPOAUSEN_CODIGOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TIPOAUSEN_CODIGOFILTERCONTAINER","Class")',ctrl:"TIPOAUSEN_CODIGOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTIPOAUSEN_CODIGO","Visible")',ctrl:"vCTIPOAUSEN_CODIGO",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A10AusenArea_Fecha",fld:"AUSENAREA_FECHA",pic:"",hsh:!0},{av:"A11TipoAusen_Codigo",fld:"TIPOAUSEN_CODIGO",pic:"",hsh:!0}],[{av:"AV13pAusenArea_Fecha",fld:"vPAUSENAREA_FECHA",pic:""},{av:"AV14pTipoAusen_Codigo",fld:"vPTIPOAUSEN_CODIGO",pic:""}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cAusenArea_Fecha",fld:"vCAUSENAREA_FECHA",pic:""},{av:"AV7cTipoAusen_Codigo",fld:"vCTIPOAUSEN_CODIGO",pic:""},{av:"AV8pAusen_Fecha",fld:"vPAUSEN_FECHA",pic:""},{av:"AV9pAusen_Mes",fld:"vPAUSEN_MES",pic:"ZZZ9"},{av:"AV10pAusen_Ano",fld:"vPAUSEN_ANO",pic:"ZZZ9"},{av:"AV11pIndicadoresCodigo",fld:"vPINDICADORESCODIGO",pic:""},{av:"AV12pCod_Area",fld:"vPCOD_AREA",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cAusenArea_Fecha",fld:"vCAUSENAREA_FECHA",pic:""},{av:"AV7cTipoAusen_Codigo",fld:"vCTIPOAUSEN_CODIGO",pic:""},{av:"AV8pAusen_Fecha",fld:"vPAUSEN_FECHA",pic:""},{av:"AV9pAusen_Mes",fld:"vPAUSEN_MES",pic:"ZZZ9"},{av:"AV10pAusen_Ano",fld:"vPAUSEN_ANO",pic:"ZZZ9"},{av:"AV11pIndicadoresCodigo",fld:"vPINDICADORESCODIGO",pic:""},{av:"AV12pCod_Area",fld:"vPCOD_AREA",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cAusenArea_Fecha",fld:"vCAUSENAREA_FECHA",pic:""},{av:"AV7cTipoAusen_Codigo",fld:"vCTIPOAUSEN_CODIGO",pic:""},{av:"AV8pAusen_Fecha",fld:"vPAUSEN_FECHA",pic:""},{av:"AV9pAusen_Mes",fld:"vPAUSEN_MES",pic:"ZZZ9"},{av:"AV10pAusen_Ano",fld:"vPAUSEN_ANO",pic:"ZZZ9"},{av:"AV11pIndicadoresCodigo",fld:"vPINDICADORESCODIGO",pic:""},{av:"AV12pCod_Area",fld:"vPCOD_AREA",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cAusenArea_Fecha",fld:"vCAUSENAREA_FECHA",pic:""},{av:"AV7cTipoAusen_Codigo",fld:"vCTIPOAUSEN_CODIGO",pic:""},{av:"AV8pAusen_Fecha",fld:"vPAUSEN_FECHA",pic:""},{av:"AV9pAusen_Mes",fld:"vPAUSEN_MES",pic:"ZZZ9"},{av:"AV10pAusen_Ano",fld:"vPAUSEN_ANO",pic:"ZZZ9"},{av:"AV11pIndicadoresCodigo",fld:"vPINDICADORESCODIGO",pic:""},{av:"AV12pCod_Area",fld:"vPCOD_AREA",pic:""}],[]];this.EvtParms.VALIDV_CAUSENAREA_FECHA=[[],[]];this.setVCMap("AV8pAusen_Fecha","vPAUSEN_FECHA",0,"date",8,0);this.setVCMap("AV9pAusen_Mes","vPAUSEN_MES",0,"int",4,0);this.setVCMap("AV10pAusen_Ano","vPAUSEN_ANO",0,"int",4,0);this.setVCMap("AV11pIndicadoresCodigo","vPINDICADORESCODIGO",0,"svchar",40,0);this.setVCMap("AV12pCod_Area","vPCOD_AREA",0,"svchar",40,0);this.setVCMap("AV13pAusenArea_Fecha","vPAUSENAREA_FECHA",0,"date",8,0);this.setVCMap("AV14pTipoAusen_Codigo","vPTIPOAUSEN_CODIGO",0,"svchar",40,0);this.setVCMap("AV8pAusen_Fecha","vPAUSEN_FECHA",0,"date",8,0);this.setVCMap("AV9pAusen_Mes","vPAUSEN_MES",0,"int",4,0);this.setVCMap("AV10pAusen_Ano","vPAUSEN_ANO",0,"int",4,0);this.setVCMap("AV11pIndicadoresCodigo","vPINDICADORESCODIGO",0,"svchar",40,0);this.setVCMap("AV12pCod_Area","vPCOD_AREA",0,"svchar",40,0);this.setVCMap("AV8pAusen_Fecha","vPAUSEN_FECHA",0,"date",8,0);this.setVCMap("AV9pAusen_Mes","vPAUSEN_MES",0,"int",4,0);this.setVCMap("AV10pAusen_Ano","vPAUSEN_ANO",0,"int",4,0);this.setVCMap("AV11pIndicadoresCodigo","vPINDICADORESCODIGO",0,"svchar",40,0);this.setVCMap("AV12pCod_Area","vPCOD_AREA",0,"svchar",40,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar({rfrVar:"AV8pAusen_Fecha"});t.addRefreshingVar({rfrVar:"AV9pAusen_Mes"});t.addRefreshingVar({rfrVar:"AV10pAusen_Ano"});t.addRefreshingVar({rfrVar:"AV11pIndicadoresCodigo"});t.addRefreshingVar({rfrVar:"AV12pCod_Area"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm({rfrVar:"AV8pAusen_Fecha"});t.addRefreshingParm({rfrVar:"AV9pAusen_Mes"});t.addRefreshingParm({rfrVar:"AV10pAusen_Ano"});t.addRefreshingParm({rfrVar:"AV11pIndicadoresCodigo"});t.addRefreshingParm({rfrVar:"AV12pCod_Area"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0065)})