gx.evt.autoSkip=!1;gx.define("general.ui.mpindicadores",!1,function(){var n,t;this.ServerClass="general.ui.mpindicadores";this.PackageName="GeneXus.Programs";this.ServerFullClass="general.ui.mpindicadores.aspx";this.setObjectType("web");this.IsMasterPage=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="DSUnanimoWeb";this.SetStandaloneVars=function(){this.AV6target=gx.fn.getControlValue("vTARGET_MPAGE")};this.e141g1_client=function(){return this.clearMessages(),this.AV6target=this.SIDEBARMENU_MPAGEContainer.SelectedItemTarget,this.callUrl(this.AV6target),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e151g1_client=function(){return this.clearMessages(),this.SIDEBARMENU_MPAGEContainer.isCollapsed?gx.fn.setCtrlProperty("CONTENT_MPAGE","Class","expandible-container expanded"):gx.fn.setCtrlProperty("CONTENT_MPAGE","Class","expandible-container"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CONTENT_MPAGE","Class")',ctrl:"CONTENT_MPAGE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e161g2_client=function(){return this.clearMessages(),this.SIDEBARMENU_MPAGEContainer.isCollapsed?gx.fn.setCtrlProperty("CONTENT_MPAGE","Class","expandible-container expanded"):gx.fn.setCtrlProperty("CONTENT_MPAGE","Class","expandible-container"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CONTENT_MPAGE","Class")',ctrl:"CONTENT_MPAGE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e131g2_client=function(){return this.executeServerEvent("EXIT_MPAGE",!0,null,!1,!1)};this.e171g2_client=function(){return this.executeServerEvent("ENTER_MPAGE",!0,null,!1,!1)};this.e181g2_client=function(){return this.executeServerEvent("CANCEL_MPAGE",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,17,18,19,20];this.GXLastCtrlId=20;this.SIDEBARMENU_MPAGEContainer=gx.uc.getNew(this,16,0,"GeneXusUnanimo_Sidebar","SIDEBARMENU_MPAGEContainer","Sidebarmenu","SIDEBARMENU_MPAGE");t=this.SIDEBARMENU_MPAGEContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setDynProp("Title","Title","","str");t.setProp("Class","Class","ch-sidebar","str");t.setProp("FooterText","Footertext","","str");t.setDynProp("DistanceToTop","Distancetotop",0,"num");t.setProp("Collapsible","Collapsible",!0,"bool");t.addV2CFunction("AV5sidebarItems","vSIDEBARITEMS_MPAGE","setSidebarItems");t.addC2VFunction(function(n){n.ParentObject.AV5sidebarItems=n.getSidebarItems();gx.fn.setControlValue("vSIDEBARITEMS_MPAGE",n.ParentObject.AV5sidebarItems)});t.setProp("SidebarItemsCurrentIndex","Sidebaritemscurrentindex",0,"num");t.setProp("ActiveItemId","Activeitemid","","str");t.setProp("SelectedItemTarget","Selecteditemtarget","","str");t.setProp("isCollapsed","Iscollapsed",!1,"bool");t.setProp("IconAutoColor","Iconautocolor",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ItemClick",this.e141g1_client);t.addEventHandler("GetState",this.e151g1_client);this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"HEADER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"IMAGE1",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"TEXTBLOCK1",format:1,grid:0,evt:"e131g2_client",ctrltype:"textblock"};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"TABLESIDEBARCONTAINER",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"CONTENT",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};this.AV5sidebarItems=[];this.AV6target="";this.Events={e131g2_client:["EXIT_MPAGE",!0],e171g2_client:["ENTER_MPAGE",!0],e181g2_client:["CANCEL_MPAGE",!0],e141g1_client:["SIDEBARMENU_MPAGE.ITEMCLICK_MPAGE",!1],e151g1_client:["SIDEBARMENU_MPAGE.GETSTATE_MPAGE",!1],e161g2_client:["MENUOPEN_MPAGE",!1]};this.EvtParms.REFRESH_MPAGE=[[],[]];this.EvtParms["SIDEBARMENU_MPAGE.ITEMCLICK_MPAGE"]=[[{av:"this.SIDEBARMENU_MPAGEContainer.SelectedItemTarget",ctrl:"SIDEBARMENU_MPAGE",prop:"SelectedItemTarget"}],[]];this.EvtParms["SIDEBARMENU_MPAGE.GETSTATE_MPAGE"]=[[{av:"this.SIDEBARMENU_MPAGEContainer.isCollapsed",ctrl:"SIDEBARMENU_MPAGE",prop:"isCollapsed"}],[{av:'gx.fn.getCtrlProperty("CONTENT_MPAGE","Class")',ctrl:"CONTENT_MPAGE",prop:"Class"}]];this.EvtParms.MENUOPEN_MPAGE=[[{av:"this.SIDEBARMENU_MPAGEContainer.isCollapsed",ctrl:"SIDEBARMENU_MPAGE",prop:"isCollapsed"}],[{av:'gx.fn.getCtrlProperty("CONTENT_MPAGE","Class")',ctrl:"CONTENT_MPAGE",prop:"Class"}]];this.EvtParms.EXIT_MPAGE=[[],[]];this.EvtParms.ENTER_MPAGE=[[],[]];this.setVCMap("AV6target","vTARGET_MPAGE",0,"svchar",1e3,0);this.Initialize()});gx.wi(function(){gx.createMasterPage(general.ui.mpindicadores)})