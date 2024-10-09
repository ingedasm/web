using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gx00q0 : GXDataArea
   {
      public gx00q0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx00q0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out DateTime aP0_pCOSTONRFFPROCFec ,
                           out short aP1_pCOSTONRFFPROCMes ,
                           out short aP2_pCOSTONRFFPROCAno ,
                           out string aP3_pCod_Area ,
                           out string aP4_pIndicadoresCodigo ,
                           out string aP5_pMOTIVOSCOSRFFPROCod )
      {
         this.AV13pCOSTONRFFPROCFec = DateTime.MinValue ;
         this.AV14pCOSTONRFFPROCMes = 0 ;
         this.AV15pCOSTONRFFPROCAno = 0 ;
         this.AV16pCod_Area = "" ;
         this.AV17pIndicadoresCodigo = "" ;
         this.AV18pMOTIVOSCOSRFFPROCod = "" ;
         executePrivate();
         aP0_pCOSTONRFFPROCFec=this.AV13pCOSTONRFFPROCFec;
         aP1_pCOSTONRFFPROCMes=this.AV14pCOSTONRFFPROCMes;
         aP2_pCOSTONRFFPROCAno=this.AV15pCOSTONRFFPROCAno;
         aP3_pCod_Area=this.AV16pCod_Area;
         aP4_pIndicadoresCodigo=this.AV17pIndicadoresCodigo;
         aP5_pMOTIVOSCOSRFFPROCod=this.AV18pMOTIVOSCOSRFFPROCod;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pCOSTONRFFPROCFec");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCOSTONRFFPROCFec");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCOSTONRFFPROCFec");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13pCOSTONRFFPROCFec = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV13pCOSTONRFFPROCFec", context.localUtil.Format(AV13pCOSTONRFFPROCFec, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pCOSTONRFFPROCMes = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTONRFFPROCMes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pCOSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTONRFFPROCMes), 4, 0));
                  AV15pCOSTONRFFPROCAno = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTONRFFPROCAno"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15pCOSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTONRFFPROCAno), 4, 0));
                  AV16pCod_Area = GetPar( "pCod_Area");
                  AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
                  AV17pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
                  AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
                  AV18pMOTIVOSCOSRFFPROCod = GetPar( "pMOTIVOSCOSRFFPROCod");
                  AssignAttri("", false, "AV18pMOTIVOSCOSRFFPROCod", AV18pMOTIVOSCOSRFFPROCod);
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cCOSTONRFFPROCFec = context.localUtil.ParseDateParm( GetPar( "cCOSTONRFFPROCFec"));
         AV7cCOSTONRFFPROCMes = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTONRFFPROCMes"), "."), 18, MidpointRounding.ToEven));
         AV8cCOSTONRFFPROCAno = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTONRFFPROCAno"), "."), 18, MidpointRounding.ToEven));
         AV9cCod_Area = GetPar( "cCod_Area");
         AV10cIndicadoresCodigo = GetPar( "cIndicadoresCodigo");
         AV11cMOTIVOSCOSRFFPROCod = GetPar( "cMOTIVOSCOSRFFPROCod");
         AV12cCOSTONRFFPROCValor = NumberUtil.Val( GetPar( "cCOSTONRFFPROCValor"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCFec, AV7cCOSTONRFFPROCMes, AV8cCOSTONRFFPROCAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cMOTIVOSCOSRFFPROCod, AV12cCOSTONRFFPROCValor) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0S2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1927500), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1927500), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1927500), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1927500), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1927500), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1927500), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00q0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pCOSTONRFFPROCFec)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTONRFFPROCMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pCOSTONRFFPROCAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pCod_Area)),UrlEncode(StringUtil.RTrim(AV17pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV18pMOTIVOSCOSRFFPROCod))}, new string[] {"pCOSTONRFFPROCFec","pCOSTONRFFPROCMes","pCOSTONRFFPROCAno","pCod_Area","pIndicadoresCodigo","pMOTIVOSCOSRFFPROCod"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPROCFEC", context.localUtil.Format(AV6cCOSTONRFFPROCFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPROCMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTONRFFPROCMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPROCANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTONRFFPROCAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOD_AREA", AV9cCod_Area);
         GxWebStd.gx_hidden_field( context, "GXH_vCINDICADORESCODIGO", AV10cIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCMOTIVOSCOSRFFPROCOD", AV11cMOTIVOSCOSRFFPROCod);
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPROCVALOR", StringUtil.LTrim( StringUtil.NToC( AV12cCOSTONRFFPROCValor, 15, 4, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTONRFFPROCFEC", context.localUtil.DToC( AV13pCOSTONRFFPROCFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPCOSTONRFFPROCMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pCOSTONRFFPROCMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTONRFFPROCANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15pCOSTONRFFPROCAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOD_AREA", AV16pCod_Area);
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV17pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "vPMOTIVOSCOSRFFPROCOD", AV18pMOTIVOSCOSRFFPROCod);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCFECFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprocfecfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCMESFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprocmesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCANOFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprocanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COD_AREAFILTERCONTAINER_Class", StringUtil.RTrim( divCod_areafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divIndicadorescodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MOTIVOSCOSRFFPROCODFILTERCONTAINER_Class", StringUtil.RTrim( divMotivoscosrffprocodfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCVALORFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprocvalorfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0S2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx00q0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pCOSTONRFFPROCFec)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTONRFFPROCMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pCOSTONRFFPROCAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pCod_Area)),UrlEncode(StringUtil.RTrim(AV17pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV18pMOTIVOSCOSRFFPROCod))}, new string[] {"pCOSTONRFFPROCFec","pCOSTONRFFPROCMes","pCOSTONRFFPROCAno","pCod_Area","pIndicadoresCodigo","pMOTIVOSCOSRFFPROCod"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00Q0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List COSTONRFFPROCESADA" ;
      }

      protected void WB0S0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCostonrffprocfecfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprocfecfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprocfecfilter_Internalname, "COSTONRFFPROCFec", "", "", lblLblcostonrffprocfecfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110s1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprocfec_Internalname, "COSTONRFFPROCFec", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCcostonrffprocfec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprocfec_Internalname, context.localUtil.Format(AV6cCOSTONRFFPROCFec, "99/99/99"), context.localUtil.Format( AV6cCOSTONRFFPROCFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprocfec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcostonrffprocfec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00Q0.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCostonrffprocmesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprocmesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprocmesfilter_Internalname, "COSTONRFFPROCMes", "", "", lblLblcostonrffprocmesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120s1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprocmes_Internalname, "COSTONRFFPROCMes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprocmes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTONRFFPROCMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostonrffprocmes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cCOSTONRFFPROCMes), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cCOSTONRFFPROCMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprocmes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostonrffprocmes_Visible, edtavCcostonrffprocmes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCostonrffprocanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprocanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprocanofilter_Internalname, "COSTONRFFPROCAno", "", "", lblLblcostonrffprocanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130s1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprocano_Internalname, "COSTONRFFPROCAno", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprocano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTONRFFPROCAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostonrffprocano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cCOSTONRFFPROCAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cCOSTONRFFPROCAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprocano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostonrffprocano_Visible, edtavCcostonrffprocano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCod_areafiltercontainer_Internalname, 1, 0, "px", 0, "px", divCod_areafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcod_areafilter_Internalname, "Cod_Area", "", "", lblLblcod_areafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140s1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcod_area_Internalname, "Cod_Area", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcod_area_Internalname, AV9cCod_Area, StringUtil.RTrim( context.localUtil.Format( AV9cCod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcod_area_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcod_area_Visible, edtavCcod_area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divIndicadorescodigofiltercontainer_Internalname, 1, 0, "px", 0, "px", divIndicadorescodigofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblindicadorescodigofilter_Internalname, "Indicadores Codigo", "", "", lblLblindicadorescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150s1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCindicadorescodigo_Internalname, "Indicadores Codigo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCindicadorescodigo_Internalname, AV10cIndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( AV10cIndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCindicadorescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCindicadorescodigo_Visible, edtavCindicadorescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMotivoscosrffprocodfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMotivoscosrffprocodfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmotivoscosrffprocodfilter_Internalname, "MOTIVOSCOSRFFPROCod", "", "", lblLblmotivoscosrffprocodfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160s1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmotivoscosrffprocod_Internalname, "MOTIVOSCOSRFFPROCod", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmotivoscosrffprocod_Internalname, AV11cMOTIVOSCOSRFFPROCod, StringUtil.RTrim( context.localUtil.Format( AV11cMOTIVOSCOSRFFPROCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmotivoscosrffprocod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmotivoscosrffprocod_Visible, edtavCmotivoscosrffprocod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCostonrffprocvalorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprocvalorfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprocvalorfilter_Internalname, "COSTONRFFPROCValor", "", "", lblLblcostonrffprocvalorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170s1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprocvalor_Internalname, "COSTONRFFPROCValor", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprocvalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV12cCOSTONRFFPROCValor, 15, 4, ",", "")), StringUtil.LTrim( ((edtavCcostonrffprocvalor_Enabled!=0) ? context.localUtil.Format( AV12cCOSTONRFFPROCValor, "ZZZZZZZZZ9.9999") : context.localUtil.Format( AV12cCOSTONRFFPROCValor, "ZZZZZZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprocvalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostonrffprocvalor_Visible, edtavCcostonrffprocvalor_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180s1_client"+"'", TempTags, "", 2, "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00Q0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0S2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_1-167910", 0) ;
            }
            Form.Meta.addItem("description", "Selection List COSTONRFFPROCESADA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0S0( ) ;
      }

      protected void WS0S2( )
      {
         START0S2( ) ;
         EVT0S2( ) ;
      }

      protected void EVT0S2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV22Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A71COSTONRFFPROCFec = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCOSTONRFFPROCFec_Internalname), 0));
                              A72COSTONRFFPROCMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A73COSTONRFFPROCAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A5Cod_Area = cgiGet( edtCod_Area_Internalname);
                              A168COSTONRFFPROCValor = context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCValor_Internalname), ",", ".");
                              A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
                              A53MOTIVOSCOSRFFPROCod = cgiGet( edtMOTIVOSCOSRFFPROCod_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccostonrffprocfec Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCCOSTONRFFPROCFEC"), 0) != AV6cCOSTONRFFPROCFec )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostonrffprocmes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTONRFFPROCMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostonrffprocano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTONRFFPROCAno )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccod_area Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCOD_AREA"), AV9cCod_Area) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cindicadorescodigo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCINDICADORESCODIGO"), AV10cIndicadoresCodigo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmotivoscosrffprocod Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMOTIVOSCOSRFFPROCOD"), AV11cMOTIVOSCOSRFFPROCod) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostonrffprocvalor Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCVALOR"), ",", ".") != AV12cCOSTONRFFPROCValor )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210S2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0S2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        DateTime AV6cCOSTONRFFPROCFec ,
                                        short AV7cCOSTONRFFPROCMes ,
                                        short AV8cCOSTONRFFPROCAno ,
                                        string AV9cCod_Area ,
                                        string AV10cIndicadoresCodigo ,
                                        string AV11cMOTIVOSCOSRFFPROCod ,
                                        decimal AV12cCOSTONRFFPROCValor )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0S2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCFEC", GetSecureSignedToken( "", A71COSTONRFFPROCFec, context));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCFEC", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A72COSTONRFFPROCMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A72COSTONRFFPROCMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A73COSTONRFFPROCAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A73COSTONRFFPROCAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "COD_AREA", A5Cod_Area);
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGO", A4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_MOTIVOSCOSRFFPROCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A53MOTIVOSCOSRFFPROCod, "")), context));
         GxWebStd.gx_hidden_field( context, "MOTIVOSCOSRFFPROCOD", A53MOTIVOSCOSRFFPROCod);
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV12cCOSTONRFFPROCValor ,
                                                 A168COSTONRFFPROCValor ,
                                                 A5Cod_Area ,
                                                 AV9cCod_Area ,
                                                 A4IndicadoresCodigo ,
                                                 AV10cIndicadoresCodigo ,
                                                 A53MOTIVOSCOSRFFPROCod ,
                                                 AV11cMOTIVOSCOSRFFPROCod ,
                                                 AV6cCOSTONRFFPROCFec ,
                                                 AV7cCOSTONRFFPROCMes ,
                                                 AV8cCOSTONRFFPROCAno } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
            lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
            lV11cMOTIVOSCOSRFFPROCod = StringUtil.Concat( StringUtil.RTrim( AV11cMOTIVOSCOSRFFPROCod), "%", "");
            /* Using cursor H000S2 */
            pr_default.execute(0, new Object[] {AV6cCOSTONRFFPROCFec, AV7cCOSTONRFFPROCMes, AV8cCOSTONRFFPROCAno, lV9cCod_Area, lV10cIndicadoresCodigo, lV11cMOTIVOSCOSRFFPROCod, AV12cCOSTONRFFPROCValor, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A53MOTIVOSCOSRFFPROCod = H000S2_A53MOTIVOSCOSRFFPROCod[0];
               A4IndicadoresCodigo = H000S2_A4IndicadoresCodigo[0];
               A168COSTONRFFPROCValor = H000S2_A168COSTONRFFPROCValor[0];
               A5Cod_Area = H000S2_A5Cod_Area[0];
               A73COSTONRFFPROCAno = H000S2_A73COSTONRFFPROCAno[0];
               A72COSTONRFFPROCMes = H000S2_A72COSTONRFFPROCMes[0];
               A71COSTONRFFPROCFec = H000S2_A71COSTONRFFPROCFec[0];
               /* Execute user event: Load */
               E200S2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0S0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0S2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCFEC"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A71COSTONRFFPROCFec, context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCMES"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A72COSTONRFFPROCMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCANO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A73COSTONRFFPROCAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MOTIVOSCOSRFFPROCOD"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A53MOTIVOSCOSRFFPROCod, "")), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV12cCOSTONRFFPROCValor ,
                                              A168COSTONRFFPROCValor ,
                                              A5Cod_Area ,
                                              AV9cCod_Area ,
                                              A4IndicadoresCodigo ,
                                              AV10cIndicadoresCodigo ,
                                              A53MOTIVOSCOSRFFPROCod ,
                                              AV11cMOTIVOSCOSRFFPROCod ,
                                              AV6cCOSTONRFFPROCFec ,
                                              AV7cCOSTONRFFPROCMes ,
                                              AV8cCOSTONRFFPROCAno } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
         lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
         lV11cMOTIVOSCOSRFFPROCod = StringUtil.Concat( StringUtil.RTrim( AV11cMOTIVOSCOSRFFPROCod), "%", "");
         /* Using cursor H000S3 */
         pr_default.execute(1, new Object[] {AV6cCOSTONRFFPROCFec, AV7cCOSTONRFFPROCMes, AV8cCOSTONRFFPROCAno, lV9cCod_Area, lV10cIndicadoresCodigo, lV11cMOTIVOSCOSRFFPROCod, AV12cCOSTONRFFPROCValor});
         GRID1_nRecordCount = H000S3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCFec, AV7cCOSTONRFFPROCMes, AV8cCOSTONRFFPROCAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cMOTIVOSCOSRFFPROCod, AV12cCOSTONRFFPROCValor) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCFec, AV7cCOSTONRFFPROCMes, AV8cCOSTONRFFPROCAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cMOTIVOSCOSRFFPROCod, AV12cCOSTONRFFPROCValor) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCFec, AV7cCOSTONRFFPROCMes, AV8cCOSTONRFFPROCAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cMOTIVOSCOSRFFPROCod, AV12cCOSTONRFFPROCValor) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCFec, AV7cCOSTONRFFPROCMes, AV8cCOSTONRFFPROCAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cMOTIVOSCOSRFFPROCod, AV12cCOSTONRFFPROCValor) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCFec, AV7cCOSTONRFFPROCMes, AV8cCOSTONRFFPROCAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cMOTIVOSCOSRFFPROCod, AV12cCOSTONRFFPROCValor) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavCcostonrffprocfec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTONRFFPROCFec"}), 1, "vCCOSTONRFFPROCFEC");
               GX_FocusControl = edtavCcostonrffprocfec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCOSTONRFFPROCFec = DateTime.MinValue;
               AssignAttri("", false, "AV6cCOSTONRFFPROCFec", context.localUtil.Format(AV6cCOSTONRFFPROCFec, "99/99/99"));
            }
            else
            {
               AV6cCOSTONRFFPROCFec = context.localUtil.CToD( cgiGet( edtavCcostonrffprocfec_Internalname), 2);
               AssignAttri("", false, "AV6cCOSTONRFFPROCFec", context.localUtil.Format(AV6cCOSTONRFFPROCFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocmes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocmes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTONRFFPROCMES");
               GX_FocusControl = edtavCcostonrffprocmes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cCOSTONRFFPROCMes = 0;
               AssignAttri("", false, "AV7cCOSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(AV7cCOSTONRFFPROCMes), 4, 0));
            }
            else
            {
               AV7cCOSTONRFFPROCMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostonrffprocmes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cCOSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(AV7cCOSTONRFFPROCMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTONRFFPROCANO");
               GX_FocusControl = edtavCcostonrffprocano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cCOSTONRFFPROCAno = 0;
               AssignAttri("", false, "AV8cCOSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(AV8cCOSTONRFFPROCAno), 4, 0));
            }
            else
            {
               AV8cCOSTONRFFPROCAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostonrffprocano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cCOSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(AV8cCOSTONRFFPROCAno), 4, 0));
            }
            AV9cCod_Area = cgiGet( edtavCcod_area_Internalname);
            AssignAttri("", false, "AV9cCod_Area", AV9cCod_Area);
            AV10cIndicadoresCodigo = cgiGet( edtavCindicadorescodigo_Internalname);
            AssignAttri("", false, "AV10cIndicadoresCodigo", AV10cIndicadoresCodigo);
            AV11cMOTIVOSCOSRFFPROCod = cgiGet( edtavCmotivoscosrffprocod_Internalname);
            AssignAttri("", false, "AV11cMOTIVOSCOSRFFPROCod", AV11cMOTIVOSCOSRFFPROCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocvalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocvalor_Internalname), ",", ".") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTONRFFPROCVALOR");
               GX_FocusControl = edtavCcostonrffprocvalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cCOSTONRFFPROCValor = 0;
               AssignAttri("", false, "AV12cCOSTONRFFPROCValor", StringUtil.LTrimStr( AV12cCOSTONRFFPROCValor, 15, 4));
            }
            else
            {
               AV12cCOSTONRFFPROCValor = context.localUtil.CToN( cgiGet( edtavCcostonrffprocvalor_Internalname), ",", ".");
               AssignAttri("", false, "AV12cCOSTONRFFPROCValor", StringUtil.LTrimStr( AV12cCOSTONRFFPROCValor, 15, 4));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCCOSTONRFFPROCFEC"), 2) ) != DateTimeUtil.ResetTime ( AV6cCOSTONRFFPROCFec ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTONRFFPROCMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTONRFFPROCAno )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCOD_AREA"), AV9cCod_Area) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCINDICADORESCODIGO"), AV10cIndicadoresCodigo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMOTIVOSCOSRFFPROCOD"), AV11cMOTIVOSCOSRFFPROCod) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCVALOR"), ",", ".") != AV12cCOSTONRFFPROCValor )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E190S2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190S2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "COSTONRFFPROCESADA", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV19ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200S2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV22Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E210S2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210S2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pCOSTONRFFPROCFec = A71COSTONRFFPROCFec;
         AssignAttri("", false, "AV13pCOSTONRFFPROCFec", context.localUtil.Format(AV13pCOSTONRFFPROCFec, "99/99/99"));
         AV14pCOSTONRFFPROCMes = A72COSTONRFFPROCMes;
         AssignAttri("", false, "AV14pCOSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTONRFFPROCMes), 4, 0));
         AV15pCOSTONRFFPROCAno = A73COSTONRFFPROCAno;
         AssignAttri("", false, "AV15pCOSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTONRFFPROCAno), 4, 0));
         AV16pCod_Area = A5Cod_Area;
         AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
         AV17pIndicadoresCodigo = A4IndicadoresCodigo;
         AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
         AV18pMOTIVOSCOSRFFPROCod = A53MOTIVOSCOSRFFPROCod;
         AssignAttri("", false, "AV18pMOTIVOSCOSRFFPROCod", AV18pMOTIVOSCOSRFFPROCod);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV13pCOSTONRFFPROCFec, "99/99/99"),(short)AV14pCOSTONRFFPROCMes,(short)AV15pCOSTONRFFPROCAno,(string)AV16pCod_Area,(string)AV17pIndicadoresCodigo,(string)AV18pMOTIVOSCOSRFFPROCod});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pCOSTONRFFPROCFec","AV14pCOSTONRFFPROCMes","AV15pCOSTONRFFPROCAno","AV16pCod_Area","AV17pIndicadoresCodigo","AV18pMOTIVOSCOSRFFPROCod"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pCOSTONRFFPROCFec = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV13pCOSTONRFFPROCFec", context.localUtil.Format(AV13pCOSTONRFFPROCFec, "99/99/99"));
         AV14pCOSTONRFFPROCMes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV14pCOSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTONRFFPROCMes), 4, 0));
         AV15pCOSTONRFFPROCAno = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV15pCOSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTONRFFPROCAno), 4, 0));
         AV16pCod_Area = (string)getParm(obj,3);
         AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
         AV17pIndicadoresCodigo = (string)getParm(obj,4);
         AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
         AV18pMOTIVOSCOSRFFPROCod = (string)getParm(obj,5);
         AssignAttri("", false, "AV18pMOTIVOSCOSRFFPROCod", AV18pMOTIVOSCOSRFFPROCod);
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0S2( ) ;
         WS0S2( ) ;
         WE0S2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231024027", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gx00q0.js", "?20247231024027", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtCOSTONRFFPROCFec_Internalname = "COSTONRFFPROCFEC_"+sGXsfl_84_idx;
         edtCOSTONRFFPROCMes_Internalname = "COSTONRFFPROCMES_"+sGXsfl_84_idx;
         edtCOSTONRFFPROCAno_Internalname = "COSTONRFFPROCANO_"+sGXsfl_84_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_idx;
         edtCOSTONRFFPROCValor_Internalname = "COSTONRFFPROCVALOR_"+sGXsfl_84_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_idx;
         edtMOTIVOSCOSRFFPROCod_Internalname = "MOTIVOSCOSRFFPROCOD_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtCOSTONRFFPROCFec_Internalname = "COSTONRFFPROCFEC_"+sGXsfl_84_fel_idx;
         edtCOSTONRFFPROCMes_Internalname = "COSTONRFFPROCMES_"+sGXsfl_84_fel_idx;
         edtCOSTONRFFPROCAno_Internalname = "COSTONRFFPROCANO_"+sGXsfl_84_fel_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_fel_idx;
         edtCOSTONRFFPROCValor_Internalname = "COSTONRFFPROCVALOR_"+sGXsfl_84_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_fel_idx;
         edtMOTIVOSCOSRFFPROCod_Internalname = "MOTIVOSCOSRFFPROCOD_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0S0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A72COSTONRFFPROCMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A73COSTONRFFPROCAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A53MOTIVOSCOSRFFPROCod)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV22Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV22Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPROCFec_Internalname,context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"),context.localUtil.Format( A71COSTONRFFPROCFec, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTONRFFPROCFec_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPROCMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A72COSTONRFFPROCMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A72COSTONRFFPROCMes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTONRFFPROCMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPROCAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A73COSTONRFFPROCAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A73COSTONRFFPROCAno), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTONRFFPROCAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCod_Area_Internalname,(string)A5Cod_Area,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCod_Area_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtCOSTONRFFPROCValor_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A72COSTONRFFPROCMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A73COSTONRFFPROCAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A53MOTIVOSCOSRFFPROCod)+"'"+"]);";
            AssignProp("", false, edtCOSTONRFFPROCValor_Internalname, "Link", edtCOSTONRFFPROCValor_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPROCValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A168COSTONRFFPROCValor, 15, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A168COSTONRFFPROCValor, "ZZZZZZZZZ9.9999")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCOSTONRFFPROCValor_Link,(string)"",(string)"",(string)"",(string)edtCOSTONRFFPROCValor_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIndicadoresCodigo_Internalname,(string)A4IndicadoresCodigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIndicadoresCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMOTIVOSCOSRFFPROCod_Internalname,(string)A53MOTIVOSCOSRFFPROCod,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMOTIVOSCOSRFFPROCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0S2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTONRFFPROCFec") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTONRFFPROCMes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTONRFFPROCAno") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cod_Area") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTONRFFPROCValor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Codigo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "MOTIVOSCOSRFFPROCod") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A72COSTONRFFPROCMes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A73COSTONRFFPROCAno), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A5Cod_Area));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A168COSTONRFFPROCValor, 15, 4, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCOSTONRFFPROCValor_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A4IndicadoresCodigo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A53MOTIVOSCOSRFFPROCod));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblcostonrffprocfecfilter_Internalname = "LBLCOSTONRFFPROCFECFILTER";
         edtavCcostonrffprocfec_Internalname = "vCCOSTONRFFPROCFEC";
         divCostonrffprocfecfiltercontainer_Internalname = "COSTONRFFPROCFECFILTERCONTAINER";
         lblLblcostonrffprocmesfilter_Internalname = "LBLCOSTONRFFPROCMESFILTER";
         edtavCcostonrffprocmes_Internalname = "vCCOSTONRFFPROCMES";
         divCostonrffprocmesfiltercontainer_Internalname = "COSTONRFFPROCMESFILTERCONTAINER";
         lblLblcostonrffprocanofilter_Internalname = "LBLCOSTONRFFPROCANOFILTER";
         edtavCcostonrffprocano_Internalname = "vCCOSTONRFFPROCANO";
         divCostonrffprocanofiltercontainer_Internalname = "COSTONRFFPROCANOFILTERCONTAINER";
         lblLblcod_areafilter_Internalname = "LBLCOD_AREAFILTER";
         edtavCcod_area_Internalname = "vCCOD_AREA";
         divCod_areafiltercontainer_Internalname = "COD_AREAFILTERCONTAINER";
         lblLblindicadorescodigofilter_Internalname = "LBLINDICADORESCODIGOFILTER";
         edtavCindicadorescodigo_Internalname = "vCINDICADORESCODIGO";
         divIndicadorescodigofiltercontainer_Internalname = "INDICADORESCODIGOFILTERCONTAINER";
         lblLblmotivoscosrffprocodfilter_Internalname = "LBLMOTIVOSCOSRFFPROCODFILTER";
         edtavCmotivoscosrffprocod_Internalname = "vCMOTIVOSCOSRFFPROCOD";
         divMotivoscosrffprocodfiltercontainer_Internalname = "MOTIVOSCOSRFFPROCODFILTERCONTAINER";
         lblLblcostonrffprocvalorfilter_Internalname = "LBLCOSTONRFFPROCVALORFILTER";
         edtavCcostonrffprocvalor_Internalname = "vCCOSTONRFFPROCVALOR";
         divCostonrffprocvalorfiltercontainer_Internalname = "COSTONRFFPROCVALORFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCOSTONRFFPROCFec_Internalname = "COSTONRFFPROCFEC";
         edtCOSTONRFFPROCMes_Internalname = "COSTONRFFPROCMES";
         edtCOSTONRFFPROCAno_Internalname = "COSTONRFFPROCANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtCOSTONRFFPROCValor_Internalname = "COSTONRFFPROCVALOR";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtMOTIVOSCOSRFFPROCod_Internalname = "MOTIVOSCOSRFFPROCOD";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtMOTIVOSCOSRFFPROCod_Jsonclick = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtCOSTONRFFPROCValor_Jsonclick = "";
         edtCOSTONRFFPROCValor_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCOSTONRFFPROCAno_Jsonclick = "";
         edtCOSTONRFFPROCMes_Jsonclick = "";
         edtCOSTONRFFPROCFec_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCcostonrffprocvalor_Jsonclick = "";
         edtavCcostonrffprocvalor_Enabled = 1;
         edtavCcostonrffprocvalor_Visible = 1;
         edtavCmotivoscosrffprocod_Jsonclick = "";
         edtavCmotivoscosrffprocod_Enabled = 1;
         edtavCmotivoscosrffprocod_Visible = 1;
         edtavCindicadorescodigo_Jsonclick = "";
         edtavCindicadorescodigo_Enabled = 1;
         edtavCindicadorescodigo_Visible = 1;
         edtavCcod_area_Jsonclick = "";
         edtavCcod_area_Enabled = 1;
         edtavCcod_area_Visible = 1;
         edtavCcostonrffprocano_Jsonclick = "";
         edtavCcostonrffprocano_Enabled = 1;
         edtavCcostonrffprocano_Visible = 1;
         edtavCcostonrffprocmes_Jsonclick = "";
         edtavCcostonrffprocmes_Enabled = 1;
         edtavCcostonrffprocmes_Visible = 1;
         edtavCcostonrffprocfec_Jsonclick = "";
         edtavCcostonrffprocfec_Enabled = 1;
         divCostonrffprocvalorfiltercontainer_Class = "AdvancedContainerItem";
         divMotivoscosrffprocodfiltercontainer_Class = "AdvancedContainerItem";
         divIndicadorescodigofiltercontainer_Class = "AdvancedContainerItem";
         divCod_areafiltercontainer_Class = "AdvancedContainerItem";
         divCostonrffprocanofiltercontainer_Class = "AdvancedContainerItem";
         divCostonrffprocmesfiltercontainer_Class = "AdvancedContainerItem";
         divCostonrffprocfecfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List COSTONRFFPROCESADA";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPROCFec',fld:'vCCOSTONRFFPROCFEC',pic:''},{av:'AV7cCOSTONRFFPROCMes',fld:'vCCOSTONRFFPROCMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPROCAno',fld:'vCCOSTONRFFPROCANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cMOTIVOSCOSRFFPROCod',fld:'vCMOTIVOSCOSRFFPROCOD',pic:''},{av:'AV12cCOSTONRFFPROCValor',fld:'vCCOSTONRFFPROCVALOR',pic:'ZZZZZZZZZ9.9999'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180S1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCOSTONRFFPROCFECFILTER.CLICK","{handler:'E110S1',iparms:[{av:'divCostonrffprocfecfiltercontainer_Class',ctrl:'COSTONRFFPROCFECFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPROCFECFILTER.CLICK",",oparms:[{av:'divCostonrffprocfecfiltercontainer_Class',ctrl:'COSTONRFFPROCFECFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLCOSTONRFFPROCMESFILTER.CLICK","{handler:'E120S1',iparms:[{av:'divCostonrffprocmesfiltercontainer_Class',ctrl:'COSTONRFFPROCMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPROCMESFILTER.CLICK",",oparms:[{av:'divCostonrffprocmesfiltercontainer_Class',ctrl:'COSTONRFFPROCMESFILTERCONTAINER',prop:'Class'},{av:'edtavCcostonrffprocmes_Visible',ctrl:'vCCOSTONRFFPROCMES',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTONRFFPROCANOFILTER.CLICK","{handler:'E130S1',iparms:[{av:'divCostonrffprocanofiltercontainer_Class',ctrl:'COSTONRFFPROCANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPROCANOFILTER.CLICK",",oparms:[{av:'divCostonrffprocanofiltercontainer_Class',ctrl:'COSTONRFFPROCANOFILTERCONTAINER',prop:'Class'},{av:'edtavCcostonrffprocano_Visible',ctrl:'vCCOSTONRFFPROCANO',prop:'Visible'}]}");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK","{handler:'E140S1',iparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK",",oparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'},{av:'edtavCcod_area_Visible',ctrl:'vCCOD_AREA',prop:'Visible'}]}");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK","{handler:'E150S1',iparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK",",oparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCindicadorescodigo_Visible',ctrl:'vCINDICADORESCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLMOTIVOSCOSRFFPROCODFILTER.CLICK","{handler:'E160S1',iparms:[{av:'divMotivoscosrffprocodfiltercontainer_Class',ctrl:'MOTIVOSCOSRFFPROCODFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMOTIVOSCOSRFFPROCODFILTER.CLICK",",oparms:[{av:'divMotivoscosrffprocodfiltercontainer_Class',ctrl:'MOTIVOSCOSRFFPROCODFILTERCONTAINER',prop:'Class'},{av:'edtavCmotivoscosrffprocod_Visible',ctrl:'vCMOTIVOSCOSRFFPROCOD',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTONRFFPROCVALORFILTER.CLICK","{handler:'E170S1',iparms:[{av:'divCostonrffprocvalorfiltercontainer_Class',ctrl:'COSTONRFFPROCVALORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPROCVALORFILTER.CLICK",",oparms:[{av:'divCostonrffprocvalorfiltercontainer_Class',ctrl:'COSTONRFFPROCVALORFILTERCONTAINER',prop:'Class'},{av:'edtavCcostonrffprocvalor_Visible',ctrl:'vCCOSTONRFFPROCVALOR',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E210S2',iparms:[{av:'A71COSTONRFFPROCFec',fld:'COSTONRFFPROCFEC',pic:'',hsh:true},{av:'A72COSTONRFFPROCMes',fld:'COSTONRFFPROCMES',pic:'ZZZ9',hsh:true},{av:'A73COSTONRFFPROCAno',fld:'COSTONRFFPROCANO',pic:'ZZZ9',hsh:true},{av:'A5Cod_Area',fld:'COD_AREA',pic:'',hsh:true},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:'',hsh:true},{av:'A53MOTIVOSCOSRFFPROCod',fld:'MOTIVOSCOSRFFPROCOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pCOSTONRFFPROCFec',fld:'vPCOSTONRFFPROCFEC',pic:''},{av:'AV14pCOSTONRFFPROCMes',fld:'vPCOSTONRFFPROCMES',pic:'ZZZ9'},{av:'AV15pCOSTONRFFPROCAno',fld:'vPCOSTONRFFPROCANO',pic:'ZZZ9'},{av:'AV16pCod_Area',fld:'vPCOD_AREA',pic:''},{av:'AV17pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV18pMOTIVOSCOSRFFPROCod',fld:'vPMOTIVOSCOSRFFPROCOD',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPROCFec',fld:'vCCOSTONRFFPROCFEC',pic:''},{av:'AV7cCOSTONRFFPROCMes',fld:'vCCOSTONRFFPROCMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPROCAno',fld:'vCCOSTONRFFPROCANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cMOTIVOSCOSRFFPROCod',fld:'vCMOTIVOSCOSRFFPROCOD',pic:''},{av:'AV12cCOSTONRFFPROCValor',fld:'vCCOSTONRFFPROCVALOR',pic:'ZZZZZZZZZ9.9999'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPROCFec',fld:'vCCOSTONRFFPROCFEC',pic:''},{av:'AV7cCOSTONRFFPROCMes',fld:'vCCOSTONRFFPROCMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPROCAno',fld:'vCCOSTONRFFPROCANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cMOTIVOSCOSRFFPROCod',fld:'vCMOTIVOSCOSRFFPROCOD',pic:''},{av:'AV12cCOSTONRFFPROCValor',fld:'vCCOSTONRFFPROCVALOR',pic:'ZZZZZZZZZ9.9999'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPROCFec',fld:'vCCOSTONRFFPROCFEC',pic:''},{av:'AV7cCOSTONRFFPROCMes',fld:'vCCOSTONRFFPROCMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPROCAno',fld:'vCCOSTONRFFPROCANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cMOTIVOSCOSRFFPROCod',fld:'vCMOTIVOSCOSRFFPROCOD',pic:''},{av:'AV12cCOSTONRFFPROCValor',fld:'vCCOSTONRFFPROCVALOR',pic:'ZZZZZZZZZ9.9999'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPROCFec',fld:'vCCOSTONRFFPROCFEC',pic:''},{av:'AV7cCOSTONRFFPROCMes',fld:'vCCOSTONRFFPROCMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPROCAno',fld:'vCCOSTONRFFPROCANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cMOTIVOSCOSRFFPROCod',fld:'vCMOTIVOSCOSRFFPROCOD',pic:''},{av:'AV12cCOSTONRFFPROCValor',fld:'vCCOSTONRFFPROCVALOR',pic:'ZZZZZZZZZ9.9999'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCOSTONRFFPROCFEC","{handler:'Validv_Ccostonrffprocfec',iparms:[]");
         setEventMetadata("VALIDV_CCOSTONRFFPROCFEC",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Motivoscosrffprocod',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV13pCOSTONRFFPROCFec = DateTime.MinValue;
         AV16pCod_Area = "";
         AV17pIndicadoresCodigo = "";
         AV18pMOTIVOSCOSRFFPROCod = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cCOSTONRFFPROCFec = DateTime.MinValue;
         AV9cCod_Area = "";
         AV10cIndicadoresCodigo = "";
         AV11cMOTIVOSCOSRFFPROCod = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcostonrffprocfecfilter_Jsonclick = "";
         TempTags = "";
         lblLblcostonrffprocmesfilter_Jsonclick = "";
         lblLblcostonrffprocanofilter_Jsonclick = "";
         lblLblcod_areafilter_Jsonclick = "";
         lblLblindicadorescodigofilter_Jsonclick = "";
         lblLblmotivoscosrffprocodfilter_Jsonclick = "";
         lblLblcostonrffprocvalorfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV22Linkselection_GXI = "";
         A71COSTONRFFPROCFec = DateTime.MinValue;
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A53MOTIVOSCOSRFFPROCod = "";
         scmdbuf = "";
         lV9cCod_Area = "";
         lV10cIndicadoresCodigo = "";
         lV11cMOTIVOSCOSRFFPROCod = "";
         H000S2_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         H000S2_A4IndicadoresCodigo = new string[] {""} ;
         H000S2_A168COSTONRFFPROCValor = new decimal[1] ;
         H000S2_A5Cod_Area = new string[] {""} ;
         H000S2_A73COSTONRFFPROCAno = new short[1] ;
         H000S2_A72COSTONRFFPROCMes = new short[1] ;
         H000S2_A71COSTONRFFPROCFec = new DateTime[] {DateTime.MinValue} ;
         H000S3_AGRID1_nRecordCount = new long[1] ;
         AV19ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00q0__default(),
            new Object[][] {
                new Object[] {
               H000S2_A53MOTIVOSCOSRFFPROCod, H000S2_A4IndicadoresCodigo, H000S2_A168COSTONRFFPROCValor, H000S2_A5Cod_Area, H000S2_A73COSTONRFFPROCAno, H000S2_A72COSTONRFFPROCMes, H000S2_A71COSTONRFFPROCFec
               }
               , new Object[] {
               H000S3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14pCOSTONRFFPROCMes ;
      private short AV15pCOSTONRFFPROCAno ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cCOSTONRFFPROCMes ;
      private short AV8cCOSTONRFFPROCAno ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A72COSTONRFFPROCMes ;
      private short A73COSTONRFFPROCAno ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int edtavCcostonrffprocfec_Enabled ;
      private int edtavCcostonrffprocmes_Enabled ;
      private int edtavCcostonrffprocmes_Visible ;
      private int edtavCcostonrffprocano_Enabled ;
      private int edtavCcostonrffprocano_Visible ;
      private int edtavCcod_area_Visible ;
      private int edtavCcod_area_Enabled ;
      private int edtavCindicadorescodigo_Visible ;
      private int edtavCindicadorescodigo_Enabled ;
      private int edtavCmotivoscosrffprocod_Visible ;
      private int edtavCmotivoscosrffprocod_Enabled ;
      private int edtavCcostonrffprocvalor_Enabled ;
      private int edtavCcostonrffprocvalor_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV12cCOSTONRFFPROCValor ;
      private decimal A168COSTONRFFPROCValor ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCostonrffprocfecfiltercontainer_Class ;
      private string divCostonrffprocmesfiltercontainer_Class ;
      private string divCostonrffprocanofiltercontainer_Class ;
      private string divCod_areafiltercontainer_Class ;
      private string divIndicadorescodigofiltercontainer_Class ;
      private string divMotivoscosrffprocodfiltercontainer_Class ;
      private string divCostonrffprocvalorfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divCostonrffprocfecfiltercontainer_Internalname ;
      private string lblLblcostonrffprocfecfilter_Internalname ;
      private string lblLblcostonrffprocfecfilter_Jsonclick ;
      private string edtavCcostonrffprocfec_Internalname ;
      private string TempTags ;
      private string edtavCcostonrffprocfec_Jsonclick ;
      private string divCostonrffprocmesfiltercontainer_Internalname ;
      private string lblLblcostonrffprocmesfilter_Internalname ;
      private string lblLblcostonrffprocmesfilter_Jsonclick ;
      private string edtavCcostonrffprocmes_Internalname ;
      private string edtavCcostonrffprocmes_Jsonclick ;
      private string divCostonrffprocanofiltercontainer_Internalname ;
      private string lblLblcostonrffprocanofilter_Internalname ;
      private string lblLblcostonrffprocanofilter_Jsonclick ;
      private string edtavCcostonrffprocano_Internalname ;
      private string edtavCcostonrffprocano_Jsonclick ;
      private string divCod_areafiltercontainer_Internalname ;
      private string lblLblcod_areafilter_Internalname ;
      private string lblLblcod_areafilter_Jsonclick ;
      private string edtavCcod_area_Internalname ;
      private string edtavCcod_area_Jsonclick ;
      private string divIndicadorescodigofiltercontainer_Internalname ;
      private string lblLblindicadorescodigofilter_Internalname ;
      private string lblLblindicadorescodigofilter_Jsonclick ;
      private string edtavCindicadorescodigo_Internalname ;
      private string edtavCindicadorescodigo_Jsonclick ;
      private string divMotivoscosrffprocodfiltercontainer_Internalname ;
      private string lblLblmotivoscosrffprocodfilter_Internalname ;
      private string lblLblmotivoscosrffprocodfilter_Jsonclick ;
      private string edtavCmotivoscosrffprocod_Internalname ;
      private string edtavCmotivoscosrffprocod_Jsonclick ;
      private string divCostonrffprocvalorfiltercontainer_Internalname ;
      private string lblLblcostonrffprocvalorfilter_Internalname ;
      private string lblLblcostonrffprocvalorfilter_Jsonclick ;
      private string edtavCcostonrffprocvalor_Internalname ;
      private string edtavCcostonrffprocvalor_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtCOSTONRFFPROCFec_Internalname ;
      private string edtCOSTONRFFPROCMes_Internalname ;
      private string edtCOSTONRFFPROCAno_Internalname ;
      private string edtCod_Area_Internalname ;
      private string edtCOSTONRFFPROCValor_Internalname ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtMOTIVOSCOSRFFPROCod_Internalname ;
      private string scmdbuf ;
      private string AV19ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCOSTONRFFPROCFec_Jsonclick ;
      private string edtCOSTONRFFPROCMes_Jsonclick ;
      private string edtCOSTONRFFPROCAno_Jsonclick ;
      private string edtCod_Area_Jsonclick ;
      private string edtCOSTONRFFPROCValor_Link ;
      private string edtCOSTONRFFPROCValor_Jsonclick ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string edtMOTIVOSCOSRFFPROCod_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV13pCOSTONRFFPROCFec ;
      private DateTime AV6cCOSTONRFFPROCFec ;
      private DateTime A71COSTONRFFPROCFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV16pCod_Area ;
      private string AV17pIndicadoresCodigo ;
      private string AV18pMOTIVOSCOSRFFPROCod ;
      private string AV9cCod_Area ;
      private string AV10cIndicadoresCodigo ;
      private string AV11cMOTIVOSCOSRFFPROCod ;
      private string AV22Linkselection_GXI ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A53MOTIVOSCOSRFFPROCod ;
      private string lV9cCod_Area ;
      private string lV10cIndicadoresCodigo ;
      private string lV11cMOTIVOSCOSRFFPROCod ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000S2_A53MOTIVOSCOSRFFPROCod ;
      private string[] H000S2_A4IndicadoresCodigo ;
      private decimal[] H000S2_A168COSTONRFFPROCValor ;
      private string[] H000S2_A5Cod_Area ;
      private short[] H000S2_A73COSTONRFFPROCAno ;
      private short[] H000S2_A72COSTONRFFPROCMes ;
      private DateTime[] H000S2_A71COSTONRFFPROCFec ;
      private long[] H000S3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP0_pCOSTONRFFPROCFec ;
      private short aP1_pCOSTONRFFPROCMes ;
      private short aP2_pCOSTONRFFPROCAno ;
      private string aP3_pCod_Area ;
      private string aP4_pIndicadoresCodigo ;
      private string aP5_pMOTIVOSCOSRFFPROCod ;
      private GXWebForm Form ;
   }

   public class gx00q0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000S2( IGxContext context ,
                                             decimal AV12cCOSTONRFFPROCValor ,
                                             decimal A168COSTONRFFPROCValor ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             string A53MOTIVOSCOSRFFPROCod ,
                                             string AV11cMOTIVOSCOSRFFPROCod ,
                                             DateTime AV6cCOSTONRFFPROCFec ,
                                             short AV7cCOSTONRFFPROCMes ,
                                             short AV8cCOSTONRFFPROCAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [MOTIVOSCOSRFFPROCod], [IndicadoresCodigo], [COSTONRFFPROCValor], [Cod_Area], [COSTONRFFPROCAno], [COSTONRFFPROCMes], [COSTONRFFPROCFec]";
         sFromString = " FROM [COSTONRFFPROCESADA]";
         sOrderString = "";
         AddWhere(sWhereString, "([COSTONRFFPROCFec] >= @AV6cCOSTONRFFPROCFec and [COSTONRFFPROCMes] >= @AV7cCOSTONRFFPROCMes and [COSTONRFFPROCAno] >= @AV8cCOSTONRFFPROCAno)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         AddWhere(sWhereString, "([MOTIVOSCOSRFFPROCod] like @lV11cMOTIVOSCOSRFFPROCod)");
         if ( ! (Convert.ToDecimal(0)==AV12cCOSTONRFFPROCValor) )
         {
            AddWhere(sWhereString, "([COSTONRFFPROCValor] >= @AV12cCOSTONRFFPROCValor)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000S3( IGxContext context ,
                                             decimal AV12cCOSTONRFFPROCValor ,
                                             decimal A168COSTONRFFPROCValor ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             string A53MOTIVOSCOSRFFPROCod ,
                                             string AV11cMOTIVOSCOSRFFPROCod ,
                                             DateTime AV6cCOSTONRFFPROCFec ,
                                             short AV7cCOSTONRFFPROCMes ,
                                             short AV8cCOSTONRFFPROCAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [COSTONRFFPROCESADA]";
         AddWhere(sWhereString, "([COSTONRFFPROCFec] >= @AV6cCOSTONRFFPROCFec and [COSTONRFFPROCMes] >= @AV7cCOSTONRFFPROCMes and [COSTONRFFPROCAno] >= @AV8cCOSTONRFFPROCAno)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         AddWhere(sWhereString, "([MOTIVOSCOSRFFPROCod] like @lV11cMOTIVOSCOSRFFPROCod)");
         if ( ! (Convert.ToDecimal(0)==AV12cCOSTONRFFPROCValor) )
         {
            AddWhere(sWhereString, "([COSTONRFFPROCValor] >= @AV12cCOSTONRFFPROCValor)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000S2(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H000S3(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000S2;
          prmH000S2 = new Object[] {
          new ParDef("@AV6cCOSTONRFFPROCFec",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTONRFFPROCMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTONRFFPROCAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@lV11cMOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0) ,
          new ParDef("@AV12cCOSTONRFFPROCValor",GXType.Decimal,15,4) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000S3;
          prmH000S3 = new Object[] {
          new ParDef("@AV6cCOSTONRFFPROCFec",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTONRFFPROCMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTONRFFPROCAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@lV11cMOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0) ,
          new ParDef("@AV12cCOSTONRFFPROCValor",GXType.Decimal,15,4)
          };
          def= new CursorDef[] {
              new CursorDef("H000S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000S2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000S3,1, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
