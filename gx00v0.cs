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
   public class gx00v0 : GXDataArea
   {
      public gx00v0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx00v0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out DateTime aP0_pINCIDENCIAPCFec ,
                           out short aP1_pINCIDENCIAPCMes ,
                           out short aP2_pINCIDENCIAPCano ,
                           out string aP3_pCod_Area ,
                           out string aP4_pIndicadoresCodigo ,
                           out string aP5_pTiposEnfermedadesCod ,
                           out string aP6_pMATERIALPALMASCOD ,
                           out string aP7_pINCIDENCIAPCZONA ,
                           out string aP8_pINCIDENCIAPCLOTE )
      {
         this.AV13pINCIDENCIAPCFec = DateTime.MinValue ;
         this.AV14pINCIDENCIAPCMes = 0 ;
         this.AV15pINCIDENCIAPCano = 0 ;
         this.AV16pCod_Area = "" ;
         this.AV17pIndicadoresCodigo = "" ;
         this.AV18pTiposEnfermedadesCod = "" ;
         this.AV19pMATERIALPALMASCOD = "" ;
         this.AV20pINCIDENCIAPCZONA = "" ;
         this.AV21pINCIDENCIAPCLOTE = "" ;
         executePrivate();
         aP0_pINCIDENCIAPCFec=this.AV13pINCIDENCIAPCFec;
         aP1_pINCIDENCIAPCMes=this.AV14pINCIDENCIAPCMes;
         aP2_pINCIDENCIAPCano=this.AV15pINCIDENCIAPCano;
         aP3_pCod_Area=this.AV16pCod_Area;
         aP4_pIndicadoresCodigo=this.AV17pIndicadoresCodigo;
         aP5_pTiposEnfermedadesCod=this.AV18pTiposEnfermedadesCod;
         aP6_pMATERIALPALMASCOD=this.AV19pMATERIALPALMASCOD;
         aP7_pINCIDENCIAPCZONA=this.AV20pINCIDENCIAPCZONA;
         aP8_pINCIDENCIAPCLOTE=this.AV21pINCIDENCIAPCLOTE;
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
            gxfirstwebparm = GetFirstPar( "pINCIDENCIAPCFec");
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
               gxfirstwebparm = GetFirstPar( "pINCIDENCIAPCFec");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pINCIDENCIAPCFec");
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
               AV13pINCIDENCIAPCFec = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV13pINCIDENCIAPCFec", context.localUtil.Format(AV13pINCIDENCIAPCFec, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pINCIDENCIAPCMes = (short)(Math.Round(NumberUtil.Val( GetPar( "pINCIDENCIAPCMes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pINCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(AV14pINCIDENCIAPCMes), 4, 0));
                  AV15pINCIDENCIAPCano = (short)(Math.Round(NumberUtil.Val( GetPar( "pINCIDENCIAPCano"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15pINCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(AV15pINCIDENCIAPCano), 4, 0));
                  AV16pCod_Area = GetPar( "pCod_Area");
                  AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
                  AV17pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
                  AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
                  AV18pTiposEnfermedadesCod = GetPar( "pTiposEnfermedadesCod");
                  AssignAttri("", false, "AV18pTiposEnfermedadesCod", AV18pTiposEnfermedadesCod);
                  AV19pMATERIALPALMASCOD = GetPar( "pMATERIALPALMASCOD");
                  AssignAttri("", false, "AV19pMATERIALPALMASCOD", AV19pMATERIALPALMASCOD);
                  AV20pINCIDENCIAPCZONA = GetPar( "pINCIDENCIAPCZONA");
                  AssignAttri("", false, "AV20pINCIDENCIAPCZONA", AV20pINCIDENCIAPCZONA);
                  AV21pINCIDENCIAPCLOTE = GetPar( "pINCIDENCIAPCLOTE");
                  AssignAttri("", false, "AV21pINCIDENCIAPCLOTE", AV21pINCIDENCIAPCLOTE);
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
         AV6cINCIDENCIAPCFec = context.localUtil.ParseDateParm( GetPar( "cINCIDENCIAPCFec"));
         AV7cINCIDENCIAPCMes = (short)(Math.Round(NumberUtil.Val( GetPar( "cINCIDENCIAPCMes"), "."), 18, MidpointRounding.ToEven));
         AV8cINCIDENCIAPCano = (short)(Math.Round(NumberUtil.Val( GetPar( "cINCIDENCIAPCano"), "."), 18, MidpointRounding.ToEven));
         AV9cCod_Area = GetPar( "cCod_Area");
         AV10cIndicadoresCodigo = GetPar( "cIndicadoresCodigo");
         AV11cTiposEnfermedadesCod = GetPar( "cTiposEnfermedadesCod");
         AV12cINCIDENCIAPCZONA = GetPar( "cINCIDENCIAPCZONA");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cINCIDENCIAPCFec, AV7cINCIDENCIAPCMes, AV8cINCIDENCIAPCano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTiposEnfermedadesCod, AV12cINCIDENCIAPCZONA) ;
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
         PA0X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0X2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00v0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pINCIDENCIAPCFec)),UrlEncode(StringUtil.LTrimStr(AV14pINCIDENCIAPCMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pINCIDENCIAPCano,4,0)),UrlEncode(StringUtil.RTrim(AV16pCod_Area)),UrlEncode(StringUtil.RTrim(AV17pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV18pTiposEnfermedadesCod)),UrlEncode(StringUtil.RTrim(AV19pMATERIALPALMASCOD)),UrlEncode(StringUtil.RTrim(AV20pINCIDENCIAPCZONA)),UrlEncode(StringUtil.RTrim(AV21pINCIDENCIAPCLOTE))}, new string[] {"pINCIDENCIAPCFec","pINCIDENCIAPCMes","pINCIDENCIAPCano","pCod_Area","pIndicadoresCodigo","pTiposEnfermedadesCod","pMATERIALPALMASCOD","pINCIDENCIAPCZONA","pINCIDENCIAPCLOTE"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCINCIDENCIAPCFEC", context.localUtil.Format(AV6cINCIDENCIAPCFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCINCIDENCIAPCMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cINCIDENCIAPCMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINCIDENCIAPCANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cINCIDENCIAPCano), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOD_AREA", AV9cCod_Area);
         GxWebStd.gx_hidden_field( context, "GXH_vCINDICADORESCODIGO", AV10cIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCTIPOSENFERMEDADESCOD", AV11cTiposEnfermedadesCod);
         GxWebStd.gx_hidden_field( context, "GXH_vCINCIDENCIAPCZONA", AV12cINCIDENCIAPCZONA);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPINCIDENCIAPCFEC", context.localUtil.DToC( AV13pINCIDENCIAPCFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPINCIDENCIAPCMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pINCIDENCIAPCMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPINCIDENCIAPCANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15pINCIDENCIAPCano), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOD_AREA", AV16pCod_Area);
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV17pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "vPTIPOSENFERMEDADESCOD", AV18pTiposEnfermedadesCod);
         GxWebStd.gx_hidden_field( context, "vPMATERIALPALMASCOD", AV19pMATERIALPALMASCOD);
         GxWebStd.gx_hidden_field( context, "vPINCIDENCIAPCZONA", AV20pINCIDENCIAPCZONA);
         GxWebStd.gx_hidden_field( context, "vPINCIDENCIAPCLOTE", AV21pINCIDENCIAPCLOTE);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "INCIDENCIAPCFECFILTERCONTAINER_Class", StringUtil.RTrim( divIncidenciapcfecfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INCIDENCIAPCMESFILTERCONTAINER_Class", StringUtil.RTrim( divIncidenciapcmesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INCIDENCIAPCANOFILTERCONTAINER_Class", StringUtil.RTrim( divIncidenciapcanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COD_AREAFILTERCONTAINER_Class", StringUtil.RTrim( divCod_areafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divIndicadorescodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TIPOSENFERMEDADESCODFILTERCONTAINER_Class", StringUtil.RTrim( divTiposenfermedadescodfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INCIDENCIAPCZONAFILTERCONTAINER_Class", StringUtil.RTrim( divIncidenciapczonafiltercontainer_Class));
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
            WE0X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0X2( ) ;
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
         return formatLink("gx00v0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pINCIDENCIAPCFec)),UrlEncode(StringUtil.LTrimStr(AV14pINCIDENCIAPCMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pINCIDENCIAPCano,4,0)),UrlEncode(StringUtil.RTrim(AV16pCod_Area)),UrlEncode(StringUtil.RTrim(AV17pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV18pTiposEnfermedadesCod)),UrlEncode(StringUtil.RTrim(AV19pMATERIALPALMASCOD)),UrlEncode(StringUtil.RTrim(AV20pINCIDENCIAPCZONA)),UrlEncode(StringUtil.RTrim(AV21pINCIDENCIAPCLOTE))}, new string[] {"pINCIDENCIAPCFec","pINCIDENCIAPCMes","pINCIDENCIAPCano","pCod_Area","pIndicadoresCodigo","pTiposEnfermedadesCod","pMATERIALPALMASCOD","pINCIDENCIAPCZONA","pINCIDENCIAPCLOTE"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00V0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List INCIDENCIAPC" ;
      }

      protected void WB0X0( )
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
            GxWebStd.gx_div_start( context, divIncidenciapcfecfiltercontainer_Internalname, 1, 0, "px", 0, "px", divIncidenciapcfecfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblincidenciapcfecfilter_Internalname, "INCIDENCIAPCFec", "", "", lblLblincidenciapcfecfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110x1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCincidenciapcfec_Internalname, "INCIDENCIAPCFec", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCincidenciapcfec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCincidenciapcfec_Internalname, context.localUtil.Format(AV6cINCIDENCIAPCFec, "99/99/99"), context.localUtil.Format( AV6cINCIDENCIAPCFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCincidenciapcfec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCincidenciapcfec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00V0.htm");
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
            GxWebStd.gx_div_start( context, divIncidenciapcmesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divIncidenciapcmesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblincidenciapcmesfilter_Internalname, "INCIDENCIAPCMes", "", "", lblLblincidenciapcmesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120x1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCincidenciapcmes_Internalname, "INCIDENCIAPCMes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCincidenciapcmes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cINCIDENCIAPCMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCincidenciapcmes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cINCIDENCIAPCMes), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cINCIDENCIAPCMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCincidenciapcmes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCincidenciapcmes_Visible, edtavCincidenciapcmes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00V0.htm");
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
            GxWebStd.gx_div_start( context, divIncidenciapcanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divIncidenciapcanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblincidenciapcanofilter_Internalname, "INCIDENCIAPCano", "", "", lblLblincidenciapcanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130x1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCincidenciapcano_Internalname, "INCIDENCIAPCano", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCincidenciapcano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cINCIDENCIAPCano), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCincidenciapcano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cINCIDENCIAPCano), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cINCIDENCIAPCano), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCincidenciapcano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCincidenciapcano_Visible, edtavCincidenciapcano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00V0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblcod_areafilter_Internalname, "Cod_Area", "", "", lblLblcod_areafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140x1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V0.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCcod_area_Internalname, AV9cCod_Area, StringUtil.RTrim( context.localUtil.Format( AV9cCod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcod_area_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcod_area_Visible, edtavCcod_area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00V0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblindicadorescodigofilter_Internalname, "Indicadores Codigo", "", "", lblLblindicadorescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150x1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V0.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCindicadorescodigo_Internalname, AV10cIndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( AV10cIndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCindicadorescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCindicadorescodigo_Visible, edtavCindicadorescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00V0.htm");
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
            GxWebStd.gx_div_start( context, divTiposenfermedadescodfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTiposenfermedadescodfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltiposenfermedadescodfilter_Internalname, "Tipos Enfermedades Cod", "", "", lblLbltiposenfermedadescodfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160x1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtiposenfermedadescod_Internalname, "Tipos Enfermedades Cod", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtiposenfermedadescod_Internalname, AV11cTiposEnfermedadesCod, StringUtil.RTrim( context.localUtil.Format( AV11cTiposEnfermedadesCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtiposenfermedadescod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtiposenfermedadescod_Visible, edtavCtiposenfermedadescod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00V0.htm");
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
            GxWebStd.gx_div_start( context, divIncidenciapczonafiltercontainer_Internalname, 1, 0, "px", 0, "px", divIncidenciapczonafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblincidenciapczonafilter_Internalname, "INCIDENCIAPCZONA", "", "", lblLblincidenciapczonafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170x1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCincidenciapczona_Internalname, "INCIDENCIAPCZONA", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCincidenciapczona_Internalname, AV12cINCIDENCIAPCZONA, StringUtil.RTrim( context.localUtil.Format( AV12cINCIDENCIAPCZONA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCincidenciapczona_Jsonclick, 0, "Attribute", "", "", "", "", edtavCincidenciapczona_Visible, edtavCincidenciapczona_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00V0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180x1_client"+"'", TempTags, "", 2, "HLP_Gx00V0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00V0.htm");
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

      protected void START0X2( )
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
            Form.Meta.addItem("description", "Selection List INCIDENCIAPC", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0X0( ) ;
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV25Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A104INCIDENCIAPCFec = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtINCIDENCIAPCFec_Internalname), 0));
                              A105INCIDENCIAPCMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtINCIDENCIAPCMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A106INCIDENCIAPCano = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtINCIDENCIAPCano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A5Cod_Area = cgiGet( edtCod_Area_Internalname);
                              A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
                              A90TiposEnfermedadesCod = cgiGet( edtTiposEnfermedadesCod_Internalname);
                              A91MATERIALPALMASCOD = cgiGet( edtMATERIALPALMASCOD_Internalname);
                              A107INCIDENCIAPCZONA = cgiGet( edtINCIDENCIAPCZONA_Internalname);
                              A108INCIDENCIAPCLOTE = cgiGet( edtINCIDENCIAPCLOTE_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cincidenciapcfec Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCINCIDENCIAPCFEC"), 0) != AV6cINCIDENCIAPCFec )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cincidenciapcmes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINCIDENCIAPCMES"), ",", ".") != Convert.ToDecimal( AV7cINCIDENCIAPCMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cincidenciapcano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINCIDENCIAPCANO"), ",", ".") != Convert.ToDecimal( AV8cINCIDENCIAPCano )) )
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
                                       /* Set Refresh If Ctiposenfermedadescod Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCTIPOSENFERMEDADESCOD"), AV11cTiposEnfermedadesCod) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cincidenciapczona Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCINCIDENCIAPCZONA"), AV12cINCIDENCIAPCZONA) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210X2 ();
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

      protected void WE0X2( )
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

      protected void PA0X2( )
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
                                        DateTime AV6cINCIDENCIAPCFec ,
                                        short AV7cINCIDENCIAPCMes ,
                                        short AV8cINCIDENCIAPCano ,
                                        string AV9cCod_Area ,
                                        string AV10cIndicadoresCodigo ,
                                        string AV11cTiposEnfermedadesCod ,
                                        string AV12cINCIDENCIAPCZONA )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAPCFEC", GetSecureSignedToken( "", A104INCIDENCIAPCFec, context));
         GxWebStd.gx_hidden_field( context, "INCIDENCIAPCFEC", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAPCMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A105INCIDENCIAPCMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "INCIDENCIAPCMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A105INCIDENCIAPCMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAPCANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A106INCIDENCIAPCano), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "INCIDENCIAPCANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106INCIDENCIAPCano), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "COD_AREA", A5Cod_Area);
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGO", A4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOSENFERMEDADESCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A90TiposEnfermedadesCod, "")), context));
         GxWebStd.gx_hidden_field( context, "TIPOSENFERMEDADESCOD", A90TiposEnfermedadesCod);
         GxWebStd.gx_hidden_field( context, "gxhash_MATERIALPALMASCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A91MATERIALPALMASCOD, "")), context));
         GxWebStd.gx_hidden_field( context, "MATERIALPALMASCOD", A91MATERIALPALMASCOD);
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAPCZONA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A107INCIDENCIAPCZONA, "")), context));
         GxWebStd.gx_hidden_field( context, "INCIDENCIAPCZONA", A107INCIDENCIAPCZONA);
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAPCLOTE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A108INCIDENCIAPCLOTE, "")), context));
         GxWebStd.gx_hidden_field( context, "INCIDENCIAPCLOTE", A108INCIDENCIAPCLOTE);
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
         RF0X2( ) ;
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

      protected void RF0X2( )
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
            lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
            lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
            lV11cTiposEnfermedadesCod = StringUtil.Concat( StringUtil.RTrim( AV11cTiposEnfermedadesCod), "%", "");
            lV12cINCIDENCIAPCZONA = StringUtil.Concat( StringUtil.RTrim( AV12cINCIDENCIAPCZONA), "%", "");
            /* Using cursor H000X2 */
            pr_default.execute(0, new Object[] {AV6cINCIDENCIAPCFec, AV7cINCIDENCIAPCMes, AV8cINCIDENCIAPCano, lV9cCod_Area, lV10cIndicadoresCodigo, lV11cTiposEnfermedadesCod, lV12cINCIDENCIAPCZONA, GXPagingFrom2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A108INCIDENCIAPCLOTE = H000X2_A108INCIDENCIAPCLOTE[0];
               A107INCIDENCIAPCZONA = H000X2_A107INCIDENCIAPCZONA[0];
               A91MATERIALPALMASCOD = H000X2_A91MATERIALPALMASCOD[0];
               A90TiposEnfermedadesCod = H000X2_A90TiposEnfermedadesCod[0];
               A4IndicadoresCodigo = H000X2_A4IndicadoresCodigo[0];
               A5Cod_Area = H000X2_A5Cod_Area[0];
               A106INCIDENCIAPCano = H000X2_A106INCIDENCIAPCano[0];
               A105INCIDENCIAPCMes = H000X2_A105INCIDENCIAPCMes[0];
               A104INCIDENCIAPCFec = H000X2_A104INCIDENCIAPCFec[0];
               /* Execute user event: Load */
               E200X2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0X0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAPCFEC"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A104INCIDENCIAPCFec, context));
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAPCMES"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A105INCIDENCIAPCMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAPCANO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A106INCIDENCIAPCano), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOSENFERMEDADESCOD"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A90TiposEnfermedadesCod, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MATERIALPALMASCOD"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A91MATERIALPALMASCOD, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAPCZONA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A107INCIDENCIAPCZONA, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAPCLOTE"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A108INCIDENCIAPCLOTE, "")), context));
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
         lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
         lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
         lV11cTiposEnfermedadesCod = StringUtil.Concat( StringUtil.RTrim( AV11cTiposEnfermedadesCod), "%", "");
         lV12cINCIDENCIAPCZONA = StringUtil.Concat( StringUtil.RTrim( AV12cINCIDENCIAPCZONA), "%", "");
         /* Using cursor H000X3 */
         pr_default.execute(1, new Object[] {AV6cINCIDENCIAPCFec, AV7cINCIDENCIAPCMes, AV8cINCIDENCIAPCano, lV9cCod_Area, lV10cIndicadoresCodigo, lV11cTiposEnfermedadesCod, lV12cINCIDENCIAPCZONA});
         GRID1_nRecordCount = H000X3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cINCIDENCIAPCFec, AV7cINCIDENCIAPCMes, AV8cINCIDENCIAPCano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTiposEnfermedadesCod, AV12cINCIDENCIAPCZONA) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cINCIDENCIAPCFec, AV7cINCIDENCIAPCMes, AV8cINCIDENCIAPCano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTiposEnfermedadesCod, AV12cINCIDENCIAPCZONA) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cINCIDENCIAPCFec, AV7cINCIDENCIAPCMes, AV8cINCIDENCIAPCano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTiposEnfermedadesCod, AV12cINCIDENCIAPCZONA) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cINCIDENCIAPCFec, AV7cINCIDENCIAPCMes, AV8cINCIDENCIAPCano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTiposEnfermedadesCod, AV12cINCIDENCIAPCZONA) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cINCIDENCIAPCFec, AV7cINCIDENCIAPCMes, AV8cINCIDENCIAPCano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTiposEnfermedadesCod, AV12cINCIDENCIAPCZONA) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190X2 ();
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
            if ( context.localUtil.VCDate( cgiGet( edtavCincidenciapcfec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"INCIDENCIAPCFec"}), 1, "vCINCIDENCIAPCFEC");
               GX_FocusControl = edtavCincidenciapcfec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cINCIDENCIAPCFec = DateTime.MinValue;
               AssignAttri("", false, "AV6cINCIDENCIAPCFec", context.localUtil.Format(AV6cINCIDENCIAPCFec, "99/99/99"));
            }
            else
            {
               AV6cINCIDENCIAPCFec = context.localUtil.CToD( cgiGet( edtavCincidenciapcfec_Internalname), 2);
               AssignAttri("", false, "AV6cINCIDENCIAPCFec", context.localUtil.Format(AV6cINCIDENCIAPCFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCincidenciapcmes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCincidenciapcmes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINCIDENCIAPCMES");
               GX_FocusControl = edtavCincidenciapcmes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cINCIDENCIAPCMes = 0;
               AssignAttri("", false, "AV7cINCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(AV7cINCIDENCIAPCMes), 4, 0));
            }
            else
            {
               AV7cINCIDENCIAPCMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCincidenciapcmes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cINCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(AV7cINCIDENCIAPCMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCincidenciapcano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCincidenciapcano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINCIDENCIAPCANO");
               GX_FocusControl = edtavCincidenciapcano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cINCIDENCIAPCano = 0;
               AssignAttri("", false, "AV8cINCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(AV8cINCIDENCIAPCano), 4, 0));
            }
            else
            {
               AV8cINCIDENCIAPCano = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCincidenciapcano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cINCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(AV8cINCIDENCIAPCano), 4, 0));
            }
            AV9cCod_Area = cgiGet( edtavCcod_area_Internalname);
            AssignAttri("", false, "AV9cCod_Area", AV9cCod_Area);
            AV10cIndicadoresCodigo = cgiGet( edtavCindicadorescodigo_Internalname);
            AssignAttri("", false, "AV10cIndicadoresCodigo", AV10cIndicadoresCodigo);
            AV11cTiposEnfermedadesCod = cgiGet( edtavCtiposenfermedadescod_Internalname);
            AssignAttri("", false, "AV11cTiposEnfermedadesCod", AV11cTiposEnfermedadesCod);
            AV12cINCIDENCIAPCZONA = cgiGet( edtavCincidenciapczona_Internalname);
            AssignAttri("", false, "AV12cINCIDENCIAPCZONA", AV12cINCIDENCIAPCZONA);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCINCIDENCIAPCFEC"), 2) ) != DateTimeUtil.ResetTime ( AV6cINCIDENCIAPCFec ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINCIDENCIAPCMES"), ",", ".") != Convert.ToDecimal( AV7cINCIDENCIAPCMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINCIDENCIAPCANO"), ",", ".") != Convert.ToDecimal( AV8cINCIDENCIAPCano )) )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCTIPOSENFERMEDADESCOD"), AV11cTiposEnfermedadesCod) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCINCIDENCIAPCZONA"), AV12cINCIDENCIAPCZONA) != 0 )
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
         E190X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190X2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "INCIDENCIAPC", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV22ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200X2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV25Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E210X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210X2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pINCIDENCIAPCFec = A104INCIDENCIAPCFec;
         AssignAttri("", false, "AV13pINCIDENCIAPCFec", context.localUtil.Format(AV13pINCIDENCIAPCFec, "99/99/99"));
         AV14pINCIDENCIAPCMes = A105INCIDENCIAPCMes;
         AssignAttri("", false, "AV14pINCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(AV14pINCIDENCIAPCMes), 4, 0));
         AV15pINCIDENCIAPCano = A106INCIDENCIAPCano;
         AssignAttri("", false, "AV15pINCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(AV15pINCIDENCIAPCano), 4, 0));
         AV16pCod_Area = A5Cod_Area;
         AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
         AV17pIndicadoresCodigo = A4IndicadoresCodigo;
         AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
         AV18pTiposEnfermedadesCod = A90TiposEnfermedadesCod;
         AssignAttri("", false, "AV18pTiposEnfermedadesCod", AV18pTiposEnfermedadesCod);
         AV19pMATERIALPALMASCOD = A91MATERIALPALMASCOD;
         AssignAttri("", false, "AV19pMATERIALPALMASCOD", AV19pMATERIALPALMASCOD);
         AV20pINCIDENCIAPCZONA = A107INCIDENCIAPCZONA;
         AssignAttri("", false, "AV20pINCIDENCIAPCZONA", AV20pINCIDENCIAPCZONA);
         AV21pINCIDENCIAPCLOTE = A108INCIDENCIAPCLOTE;
         AssignAttri("", false, "AV21pINCIDENCIAPCLOTE", AV21pINCIDENCIAPCLOTE);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV13pINCIDENCIAPCFec, "99/99/99"),(short)AV14pINCIDENCIAPCMes,(short)AV15pINCIDENCIAPCano,(string)AV16pCod_Area,(string)AV17pIndicadoresCodigo,(string)AV18pTiposEnfermedadesCod,(string)AV19pMATERIALPALMASCOD,(string)AV20pINCIDENCIAPCZONA,(string)AV21pINCIDENCIAPCLOTE});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pINCIDENCIAPCFec","AV14pINCIDENCIAPCMes","AV15pINCIDENCIAPCano","AV16pCod_Area","AV17pIndicadoresCodigo","AV18pTiposEnfermedadesCod","AV19pMATERIALPALMASCOD","AV20pINCIDENCIAPCZONA","AV21pINCIDENCIAPCLOTE"});
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
         AV13pINCIDENCIAPCFec = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV13pINCIDENCIAPCFec", context.localUtil.Format(AV13pINCIDENCIAPCFec, "99/99/99"));
         AV14pINCIDENCIAPCMes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV14pINCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(AV14pINCIDENCIAPCMes), 4, 0));
         AV15pINCIDENCIAPCano = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV15pINCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(AV15pINCIDENCIAPCano), 4, 0));
         AV16pCod_Area = (string)getParm(obj,3);
         AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
         AV17pIndicadoresCodigo = (string)getParm(obj,4);
         AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
         AV18pTiposEnfermedadesCod = (string)getParm(obj,5);
         AssignAttri("", false, "AV18pTiposEnfermedadesCod", AV18pTiposEnfermedadesCod);
         AV19pMATERIALPALMASCOD = (string)getParm(obj,6);
         AssignAttri("", false, "AV19pMATERIALPALMASCOD", AV19pMATERIALPALMASCOD);
         AV20pINCIDENCIAPCZONA = (string)getParm(obj,7);
         AssignAttri("", false, "AV20pINCIDENCIAPCZONA", AV20pINCIDENCIAPCZONA);
         AV21pINCIDENCIAPCLOTE = (string)getParm(obj,8);
         AssignAttri("", false, "AV21pINCIDENCIAPCLOTE", AV21pINCIDENCIAPCLOTE);
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
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231024933", true, true);
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
         context.AddJavascriptSource("gx00v0.js", "?20247231024934", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtINCIDENCIAPCFec_Internalname = "INCIDENCIAPCFEC_"+sGXsfl_84_idx;
         edtINCIDENCIAPCMes_Internalname = "INCIDENCIAPCMES_"+sGXsfl_84_idx;
         edtINCIDENCIAPCano_Internalname = "INCIDENCIAPCANO_"+sGXsfl_84_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_idx;
         edtTiposEnfermedadesCod_Internalname = "TIPOSENFERMEDADESCOD_"+sGXsfl_84_idx;
         edtMATERIALPALMASCOD_Internalname = "MATERIALPALMASCOD_"+sGXsfl_84_idx;
         edtINCIDENCIAPCZONA_Internalname = "INCIDENCIAPCZONA_"+sGXsfl_84_idx;
         edtINCIDENCIAPCLOTE_Internalname = "INCIDENCIAPCLOTE_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtINCIDENCIAPCFec_Internalname = "INCIDENCIAPCFEC_"+sGXsfl_84_fel_idx;
         edtINCIDENCIAPCMes_Internalname = "INCIDENCIAPCMES_"+sGXsfl_84_fel_idx;
         edtINCIDENCIAPCano_Internalname = "INCIDENCIAPCANO_"+sGXsfl_84_fel_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_fel_idx;
         edtTiposEnfermedadesCod_Internalname = "TIPOSENFERMEDADESCOD_"+sGXsfl_84_fel_idx;
         edtMATERIALPALMASCOD_Internalname = "MATERIALPALMASCOD_"+sGXsfl_84_fel_idx;
         edtINCIDENCIAPCZONA_Internalname = "INCIDENCIAPCZONA_"+sGXsfl_84_fel_idx;
         edtINCIDENCIAPCLOTE_Internalname = "INCIDENCIAPCLOTE_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0X0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A105INCIDENCIAPCMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106INCIDENCIAPCano), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A90TiposEnfermedadesCod)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A91MATERIALPALMASCOD)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A107INCIDENCIAPCZONA)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A108INCIDENCIAPCLOTE)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV25Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV25Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtINCIDENCIAPCFec_Internalname,context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"),context.localUtil.Format( A104INCIDENCIAPCFec, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtINCIDENCIAPCFec_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtINCIDENCIAPCMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A105INCIDENCIAPCMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A105INCIDENCIAPCMes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtINCIDENCIAPCMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtINCIDENCIAPCano_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106INCIDENCIAPCano), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106INCIDENCIAPCano), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtINCIDENCIAPCano_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIndicadoresCodigo_Internalname,(string)A4IndicadoresCodigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIndicadoresCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTiposEnfermedadesCod_Internalname,(string)A90TiposEnfermedadesCod,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTiposEnfermedadesCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMATERIALPALMASCOD_Internalname,(string)A91MATERIALPALMASCOD,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMATERIALPALMASCOD_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)140,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtINCIDENCIAPCZONA_Internalname,(string)A107INCIDENCIAPCZONA,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtINCIDENCIAPCZONA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtINCIDENCIAPCLOTE_Internalname,(string)A108INCIDENCIAPCLOTE,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtINCIDENCIAPCLOTE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0X2( ) ;
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
            context.SendWebValue( "INCIDENCIAPCFec") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "INCIDENCIAPCMes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "INCIDENCIAPCano") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cod_Area") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Codigo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tipos Enfermedades Cod") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "MATERIALPALMASCOD") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "INCIDENCIAPCZONA") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "INCIDENCIAPCLOTE") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A105INCIDENCIAPCMes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106INCIDENCIAPCano), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A5Cod_Area));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A4IndicadoresCodigo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A90TiposEnfermedadesCod));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A91MATERIALPALMASCOD));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A107INCIDENCIAPCZONA));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A108INCIDENCIAPCLOTE));
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
         lblLblincidenciapcfecfilter_Internalname = "LBLINCIDENCIAPCFECFILTER";
         edtavCincidenciapcfec_Internalname = "vCINCIDENCIAPCFEC";
         divIncidenciapcfecfiltercontainer_Internalname = "INCIDENCIAPCFECFILTERCONTAINER";
         lblLblincidenciapcmesfilter_Internalname = "LBLINCIDENCIAPCMESFILTER";
         edtavCincidenciapcmes_Internalname = "vCINCIDENCIAPCMES";
         divIncidenciapcmesfiltercontainer_Internalname = "INCIDENCIAPCMESFILTERCONTAINER";
         lblLblincidenciapcanofilter_Internalname = "LBLINCIDENCIAPCANOFILTER";
         edtavCincidenciapcano_Internalname = "vCINCIDENCIAPCANO";
         divIncidenciapcanofiltercontainer_Internalname = "INCIDENCIAPCANOFILTERCONTAINER";
         lblLblcod_areafilter_Internalname = "LBLCOD_AREAFILTER";
         edtavCcod_area_Internalname = "vCCOD_AREA";
         divCod_areafiltercontainer_Internalname = "COD_AREAFILTERCONTAINER";
         lblLblindicadorescodigofilter_Internalname = "LBLINDICADORESCODIGOFILTER";
         edtavCindicadorescodigo_Internalname = "vCINDICADORESCODIGO";
         divIndicadorescodigofiltercontainer_Internalname = "INDICADORESCODIGOFILTERCONTAINER";
         lblLbltiposenfermedadescodfilter_Internalname = "LBLTIPOSENFERMEDADESCODFILTER";
         edtavCtiposenfermedadescod_Internalname = "vCTIPOSENFERMEDADESCOD";
         divTiposenfermedadescodfiltercontainer_Internalname = "TIPOSENFERMEDADESCODFILTERCONTAINER";
         lblLblincidenciapczonafilter_Internalname = "LBLINCIDENCIAPCZONAFILTER";
         edtavCincidenciapczona_Internalname = "vCINCIDENCIAPCZONA";
         divIncidenciapczonafiltercontainer_Internalname = "INCIDENCIAPCZONAFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtINCIDENCIAPCFec_Internalname = "INCIDENCIAPCFEC";
         edtINCIDENCIAPCMes_Internalname = "INCIDENCIAPCMES";
         edtINCIDENCIAPCano_Internalname = "INCIDENCIAPCANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtTiposEnfermedadesCod_Internalname = "TIPOSENFERMEDADESCOD";
         edtMATERIALPALMASCOD_Internalname = "MATERIALPALMASCOD";
         edtINCIDENCIAPCZONA_Internalname = "INCIDENCIAPCZONA";
         edtINCIDENCIAPCLOTE_Internalname = "INCIDENCIAPCLOTE";
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
         edtINCIDENCIAPCLOTE_Jsonclick = "";
         edtINCIDENCIAPCZONA_Jsonclick = "";
         edtMATERIALPALMASCOD_Jsonclick = "";
         edtTiposEnfermedadesCod_Jsonclick = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtCod_Area_Jsonclick = "";
         edtINCIDENCIAPCano_Jsonclick = "";
         edtINCIDENCIAPCMes_Jsonclick = "";
         edtINCIDENCIAPCFec_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCincidenciapczona_Jsonclick = "";
         edtavCincidenciapczona_Enabled = 1;
         edtavCincidenciapczona_Visible = 1;
         edtavCtiposenfermedadescod_Jsonclick = "";
         edtavCtiposenfermedadescod_Enabled = 1;
         edtavCtiposenfermedadescod_Visible = 1;
         edtavCindicadorescodigo_Jsonclick = "";
         edtavCindicadorescodigo_Enabled = 1;
         edtavCindicadorescodigo_Visible = 1;
         edtavCcod_area_Jsonclick = "";
         edtavCcod_area_Enabled = 1;
         edtavCcod_area_Visible = 1;
         edtavCincidenciapcano_Jsonclick = "";
         edtavCincidenciapcano_Enabled = 1;
         edtavCincidenciapcano_Visible = 1;
         edtavCincidenciapcmes_Jsonclick = "";
         edtavCincidenciapcmes_Enabled = 1;
         edtavCincidenciapcmes_Visible = 1;
         edtavCincidenciapcfec_Jsonclick = "";
         edtavCincidenciapcfec_Enabled = 1;
         divIncidenciapczonafiltercontainer_Class = "AdvancedContainerItem";
         divTiposenfermedadescodfiltercontainer_Class = "AdvancedContainerItem";
         divIndicadorescodigofiltercontainer_Class = "AdvancedContainerItem";
         divCod_areafiltercontainer_Class = "AdvancedContainerItem";
         divIncidenciapcanofiltercontainer_Class = "AdvancedContainerItem";
         divIncidenciapcmesfiltercontainer_Class = "AdvancedContainerItem";
         divIncidenciapcfecfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List INCIDENCIAPC";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cINCIDENCIAPCFec',fld:'vCINCIDENCIAPCFEC',pic:''},{av:'AV7cINCIDENCIAPCMes',fld:'vCINCIDENCIAPCMES',pic:'ZZZ9'},{av:'AV8cINCIDENCIAPCano',fld:'vCINCIDENCIAPCANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cTiposEnfermedadesCod',fld:'vCTIPOSENFERMEDADESCOD',pic:''},{av:'AV12cINCIDENCIAPCZONA',fld:'vCINCIDENCIAPCZONA',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180X1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLINCIDENCIAPCFECFILTER.CLICK","{handler:'E110X1',iparms:[{av:'divIncidenciapcfecfiltercontainer_Class',ctrl:'INCIDENCIAPCFECFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINCIDENCIAPCFECFILTER.CLICK",",oparms:[{av:'divIncidenciapcfecfiltercontainer_Class',ctrl:'INCIDENCIAPCFECFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLINCIDENCIAPCMESFILTER.CLICK","{handler:'E120X1',iparms:[{av:'divIncidenciapcmesfiltercontainer_Class',ctrl:'INCIDENCIAPCMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINCIDENCIAPCMESFILTER.CLICK",",oparms:[{av:'divIncidenciapcmesfiltercontainer_Class',ctrl:'INCIDENCIAPCMESFILTERCONTAINER',prop:'Class'},{av:'edtavCincidenciapcmes_Visible',ctrl:'vCINCIDENCIAPCMES',prop:'Visible'}]}");
         setEventMetadata("LBLINCIDENCIAPCANOFILTER.CLICK","{handler:'E130X1',iparms:[{av:'divIncidenciapcanofiltercontainer_Class',ctrl:'INCIDENCIAPCANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINCIDENCIAPCANOFILTER.CLICK",",oparms:[{av:'divIncidenciapcanofiltercontainer_Class',ctrl:'INCIDENCIAPCANOFILTERCONTAINER',prop:'Class'},{av:'edtavCincidenciapcano_Visible',ctrl:'vCINCIDENCIAPCANO',prop:'Visible'}]}");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK","{handler:'E140X1',iparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK",",oparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'},{av:'edtavCcod_area_Visible',ctrl:'vCCOD_AREA',prop:'Visible'}]}");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK","{handler:'E150X1',iparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK",",oparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCindicadorescodigo_Visible',ctrl:'vCINDICADORESCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLTIPOSENFERMEDADESCODFILTER.CLICK","{handler:'E160X1',iparms:[{av:'divTiposenfermedadescodfiltercontainer_Class',ctrl:'TIPOSENFERMEDADESCODFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTIPOSENFERMEDADESCODFILTER.CLICK",",oparms:[{av:'divTiposenfermedadescodfiltercontainer_Class',ctrl:'TIPOSENFERMEDADESCODFILTERCONTAINER',prop:'Class'},{av:'edtavCtiposenfermedadescod_Visible',ctrl:'vCTIPOSENFERMEDADESCOD',prop:'Visible'}]}");
         setEventMetadata("LBLINCIDENCIAPCZONAFILTER.CLICK","{handler:'E170X1',iparms:[{av:'divIncidenciapczonafiltercontainer_Class',ctrl:'INCIDENCIAPCZONAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINCIDENCIAPCZONAFILTER.CLICK",",oparms:[{av:'divIncidenciapczonafiltercontainer_Class',ctrl:'INCIDENCIAPCZONAFILTERCONTAINER',prop:'Class'},{av:'edtavCincidenciapczona_Visible',ctrl:'vCINCIDENCIAPCZONA',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E210X2',iparms:[{av:'A104INCIDENCIAPCFec',fld:'INCIDENCIAPCFEC',pic:'',hsh:true},{av:'A105INCIDENCIAPCMes',fld:'INCIDENCIAPCMES',pic:'ZZZ9',hsh:true},{av:'A106INCIDENCIAPCano',fld:'INCIDENCIAPCANO',pic:'ZZZ9',hsh:true},{av:'A5Cod_Area',fld:'COD_AREA',pic:'',hsh:true},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:'',hsh:true},{av:'A90TiposEnfermedadesCod',fld:'TIPOSENFERMEDADESCOD',pic:'',hsh:true},{av:'A91MATERIALPALMASCOD',fld:'MATERIALPALMASCOD',pic:'',hsh:true},{av:'A107INCIDENCIAPCZONA',fld:'INCIDENCIAPCZONA',pic:'',hsh:true},{av:'A108INCIDENCIAPCLOTE',fld:'INCIDENCIAPCLOTE',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pINCIDENCIAPCFec',fld:'vPINCIDENCIAPCFEC',pic:''},{av:'AV14pINCIDENCIAPCMes',fld:'vPINCIDENCIAPCMES',pic:'ZZZ9'},{av:'AV15pINCIDENCIAPCano',fld:'vPINCIDENCIAPCANO',pic:'ZZZ9'},{av:'AV16pCod_Area',fld:'vPCOD_AREA',pic:''},{av:'AV17pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV18pTiposEnfermedadesCod',fld:'vPTIPOSENFERMEDADESCOD',pic:''},{av:'AV19pMATERIALPALMASCOD',fld:'vPMATERIALPALMASCOD',pic:''},{av:'AV20pINCIDENCIAPCZONA',fld:'vPINCIDENCIAPCZONA',pic:''},{av:'AV21pINCIDENCIAPCLOTE',fld:'vPINCIDENCIAPCLOTE',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cINCIDENCIAPCFec',fld:'vCINCIDENCIAPCFEC',pic:''},{av:'AV7cINCIDENCIAPCMes',fld:'vCINCIDENCIAPCMES',pic:'ZZZ9'},{av:'AV8cINCIDENCIAPCano',fld:'vCINCIDENCIAPCANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cTiposEnfermedadesCod',fld:'vCTIPOSENFERMEDADESCOD',pic:''},{av:'AV12cINCIDENCIAPCZONA',fld:'vCINCIDENCIAPCZONA',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cINCIDENCIAPCFec',fld:'vCINCIDENCIAPCFEC',pic:''},{av:'AV7cINCIDENCIAPCMes',fld:'vCINCIDENCIAPCMES',pic:'ZZZ9'},{av:'AV8cINCIDENCIAPCano',fld:'vCINCIDENCIAPCANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cTiposEnfermedadesCod',fld:'vCTIPOSENFERMEDADESCOD',pic:''},{av:'AV12cINCIDENCIAPCZONA',fld:'vCINCIDENCIAPCZONA',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cINCIDENCIAPCFec',fld:'vCINCIDENCIAPCFEC',pic:''},{av:'AV7cINCIDENCIAPCMes',fld:'vCINCIDENCIAPCMES',pic:'ZZZ9'},{av:'AV8cINCIDENCIAPCano',fld:'vCINCIDENCIAPCANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cTiposEnfermedadesCod',fld:'vCTIPOSENFERMEDADESCOD',pic:''},{av:'AV12cINCIDENCIAPCZONA',fld:'vCINCIDENCIAPCZONA',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cINCIDENCIAPCFec',fld:'vCINCIDENCIAPCFEC',pic:''},{av:'AV7cINCIDENCIAPCMes',fld:'vCINCIDENCIAPCMES',pic:'ZZZ9'},{av:'AV8cINCIDENCIAPCano',fld:'vCINCIDENCIAPCANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cTiposEnfermedadesCod',fld:'vCTIPOSENFERMEDADESCOD',pic:''},{av:'AV12cINCIDENCIAPCZONA',fld:'vCINCIDENCIAPCZONA',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CINCIDENCIAPCFEC","{handler:'Validv_Cincidenciapcfec',iparms:[]");
         setEventMetadata("VALIDV_CINCIDENCIAPCFEC",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Incidenciapclote',iparms:[]");
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
         AV13pINCIDENCIAPCFec = DateTime.MinValue;
         AV16pCod_Area = "";
         AV17pIndicadoresCodigo = "";
         AV18pTiposEnfermedadesCod = "";
         AV19pMATERIALPALMASCOD = "";
         AV20pINCIDENCIAPCZONA = "";
         AV21pINCIDENCIAPCLOTE = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cINCIDENCIAPCFec = DateTime.MinValue;
         AV9cCod_Area = "";
         AV10cIndicadoresCodigo = "";
         AV11cTiposEnfermedadesCod = "";
         AV12cINCIDENCIAPCZONA = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblincidenciapcfecfilter_Jsonclick = "";
         TempTags = "";
         lblLblincidenciapcmesfilter_Jsonclick = "";
         lblLblincidenciapcanofilter_Jsonclick = "";
         lblLblcod_areafilter_Jsonclick = "";
         lblLblindicadorescodigofilter_Jsonclick = "";
         lblLbltiposenfermedadescodfilter_Jsonclick = "";
         lblLblincidenciapczonafilter_Jsonclick = "";
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
         AV25Linkselection_GXI = "";
         A104INCIDENCIAPCFec = DateTime.MinValue;
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A90TiposEnfermedadesCod = "";
         A91MATERIALPALMASCOD = "";
         A107INCIDENCIAPCZONA = "";
         A108INCIDENCIAPCLOTE = "";
         scmdbuf = "";
         lV9cCod_Area = "";
         lV10cIndicadoresCodigo = "";
         lV11cTiposEnfermedadesCod = "";
         lV12cINCIDENCIAPCZONA = "";
         H000X2_A108INCIDENCIAPCLOTE = new string[] {""} ;
         H000X2_A107INCIDENCIAPCZONA = new string[] {""} ;
         H000X2_A91MATERIALPALMASCOD = new string[] {""} ;
         H000X2_A90TiposEnfermedadesCod = new string[] {""} ;
         H000X2_A4IndicadoresCodigo = new string[] {""} ;
         H000X2_A5Cod_Area = new string[] {""} ;
         H000X2_A106INCIDENCIAPCano = new short[1] ;
         H000X2_A105INCIDENCIAPCMes = new short[1] ;
         H000X2_A104INCIDENCIAPCFec = new DateTime[] {DateTime.MinValue} ;
         H000X3_AGRID1_nRecordCount = new long[1] ;
         AV22ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00v0__default(),
            new Object[][] {
                new Object[] {
               H000X2_A108INCIDENCIAPCLOTE, H000X2_A107INCIDENCIAPCZONA, H000X2_A91MATERIALPALMASCOD, H000X2_A90TiposEnfermedadesCod, H000X2_A4IndicadoresCodigo, H000X2_A5Cod_Area, H000X2_A106INCIDENCIAPCano, H000X2_A105INCIDENCIAPCMes, H000X2_A104INCIDENCIAPCFec
               }
               , new Object[] {
               H000X3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14pINCIDENCIAPCMes ;
      private short AV15pINCIDENCIAPCano ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cINCIDENCIAPCMes ;
      private short AV8cINCIDENCIAPCano ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A105INCIDENCIAPCMes ;
      private short A106INCIDENCIAPCano ;
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
      private int edtavCincidenciapcfec_Enabled ;
      private int edtavCincidenciapcmes_Enabled ;
      private int edtavCincidenciapcmes_Visible ;
      private int edtavCincidenciapcano_Enabled ;
      private int edtavCincidenciapcano_Visible ;
      private int edtavCcod_area_Visible ;
      private int edtavCcod_area_Enabled ;
      private int edtavCindicadorescodigo_Visible ;
      private int edtavCindicadorescodigo_Enabled ;
      private int edtavCtiposenfermedadescod_Visible ;
      private int edtavCtiposenfermedadescod_Enabled ;
      private int edtavCincidenciapczona_Visible ;
      private int edtavCincidenciapczona_Enabled ;
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
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divIncidenciapcfecfiltercontainer_Class ;
      private string divIncidenciapcmesfiltercontainer_Class ;
      private string divIncidenciapcanofiltercontainer_Class ;
      private string divCod_areafiltercontainer_Class ;
      private string divIndicadorescodigofiltercontainer_Class ;
      private string divTiposenfermedadescodfiltercontainer_Class ;
      private string divIncidenciapczonafiltercontainer_Class ;
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
      private string divIncidenciapcfecfiltercontainer_Internalname ;
      private string lblLblincidenciapcfecfilter_Internalname ;
      private string lblLblincidenciapcfecfilter_Jsonclick ;
      private string edtavCincidenciapcfec_Internalname ;
      private string TempTags ;
      private string edtavCincidenciapcfec_Jsonclick ;
      private string divIncidenciapcmesfiltercontainer_Internalname ;
      private string lblLblincidenciapcmesfilter_Internalname ;
      private string lblLblincidenciapcmesfilter_Jsonclick ;
      private string edtavCincidenciapcmes_Internalname ;
      private string edtavCincidenciapcmes_Jsonclick ;
      private string divIncidenciapcanofiltercontainer_Internalname ;
      private string lblLblincidenciapcanofilter_Internalname ;
      private string lblLblincidenciapcanofilter_Jsonclick ;
      private string edtavCincidenciapcano_Internalname ;
      private string edtavCincidenciapcano_Jsonclick ;
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
      private string divTiposenfermedadescodfiltercontainer_Internalname ;
      private string lblLbltiposenfermedadescodfilter_Internalname ;
      private string lblLbltiposenfermedadescodfilter_Jsonclick ;
      private string edtavCtiposenfermedadescod_Internalname ;
      private string edtavCtiposenfermedadescod_Jsonclick ;
      private string divIncidenciapczonafiltercontainer_Internalname ;
      private string lblLblincidenciapczonafilter_Internalname ;
      private string lblLblincidenciapczonafilter_Jsonclick ;
      private string edtavCincidenciapczona_Internalname ;
      private string edtavCincidenciapczona_Jsonclick ;
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
      private string edtINCIDENCIAPCFec_Internalname ;
      private string edtINCIDENCIAPCMes_Internalname ;
      private string edtINCIDENCIAPCano_Internalname ;
      private string edtCod_Area_Internalname ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtTiposEnfermedadesCod_Internalname ;
      private string edtMATERIALPALMASCOD_Internalname ;
      private string edtINCIDENCIAPCZONA_Internalname ;
      private string edtINCIDENCIAPCLOTE_Internalname ;
      private string scmdbuf ;
      private string AV22ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtINCIDENCIAPCFec_Jsonclick ;
      private string edtINCIDENCIAPCMes_Jsonclick ;
      private string edtINCIDENCIAPCano_Jsonclick ;
      private string edtCod_Area_Jsonclick ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string edtTiposEnfermedadesCod_Jsonclick ;
      private string edtMATERIALPALMASCOD_Jsonclick ;
      private string edtINCIDENCIAPCZONA_Jsonclick ;
      private string edtINCIDENCIAPCLOTE_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV13pINCIDENCIAPCFec ;
      private DateTime AV6cINCIDENCIAPCFec ;
      private DateTime A104INCIDENCIAPCFec ;
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
      private string AV18pTiposEnfermedadesCod ;
      private string AV19pMATERIALPALMASCOD ;
      private string AV20pINCIDENCIAPCZONA ;
      private string AV21pINCIDENCIAPCLOTE ;
      private string AV9cCod_Area ;
      private string AV10cIndicadoresCodigo ;
      private string AV11cTiposEnfermedadesCod ;
      private string AV12cINCIDENCIAPCZONA ;
      private string AV25Linkselection_GXI ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A90TiposEnfermedadesCod ;
      private string A91MATERIALPALMASCOD ;
      private string A107INCIDENCIAPCZONA ;
      private string A108INCIDENCIAPCLOTE ;
      private string lV9cCod_Area ;
      private string lV10cIndicadoresCodigo ;
      private string lV11cTiposEnfermedadesCod ;
      private string lV12cINCIDENCIAPCZONA ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000X2_A108INCIDENCIAPCLOTE ;
      private string[] H000X2_A107INCIDENCIAPCZONA ;
      private string[] H000X2_A91MATERIALPALMASCOD ;
      private string[] H000X2_A90TiposEnfermedadesCod ;
      private string[] H000X2_A4IndicadoresCodigo ;
      private string[] H000X2_A5Cod_Area ;
      private short[] H000X2_A106INCIDENCIAPCano ;
      private short[] H000X2_A105INCIDENCIAPCMes ;
      private DateTime[] H000X2_A104INCIDENCIAPCFec ;
      private long[] H000X3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP0_pINCIDENCIAPCFec ;
      private short aP1_pINCIDENCIAPCMes ;
      private short aP2_pINCIDENCIAPCano ;
      private string aP3_pCod_Area ;
      private string aP4_pIndicadoresCodigo ;
      private string aP5_pTiposEnfermedadesCod ;
      private string aP6_pMATERIALPALMASCOD ;
      private string aP7_pINCIDENCIAPCZONA ;
      private string aP8_pINCIDENCIAPCLOTE ;
      private GXWebForm Form ;
   }

   public class gx00v0__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH000X2;
          prmH000X2 = new Object[] {
          new ParDef("@AV6cINCIDENCIAPCFec",GXType.Date,8,0) ,
          new ParDef("@AV7cINCIDENCIAPCMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cINCIDENCIAPCano",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@lV11cTiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@lV12cINCIDENCIAPCZONA",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000X3;
          prmH000X3 = new Object[] {
          new ParDef("@AV6cINCIDENCIAPCFec",GXType.Date,8,0) ,
          new ParDef("@AV7cINCIDENCIAPCMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cINCIDENCIAPCano",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@lV11cTiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@lV12cINCIDENCIAPCZONA",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000X2", "SELECT [INCIDENCIAPCLOTE], [INCIDENCIAPCZONA], [MATERIALPALMASCOD], [TiposEnfermedadesCod], [IndicadoresCodigo], [Cod_Area], [INCIDENCIAPCano], [INCIDENCIAPCMes], [INCIDENCIAPCFec] FROM [INCIDENCIAPC] WHERE ([INCIDENCIAPCFec] >= @AV6cINCIDENCIAPCFec and [INCIDENCIAPCMes] >= @AV7cINCIDENCIAPCMes and [INCIDENCIAPCano] >= @AV8cINCIDENCIAPCano) AND ([Cod_Area] like @lV9cCod_Area) AND ([IndicadoresCodigo] like @lV10cIndicadoresCodigo) AND ([TiposEnfermedadesCod] like @lV11cTiposEnfermedadesCod) AND ([INCIDENCIAPCZONA] like @lV12cINCIDENCIAPCZONA) ORDER BY [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000X2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000X3", "SELECT COUNT(*) FROM [INCIDENCIAPC] WHERE ([INCIDENCIAPCFec] >= @AV6cINCIDENCIAPCFec and [INCIDENCIAPCMes] >= @AV7cINCIDENCIAPCMes and [INCIDENCIAPCano] >= @AV8cINCIDENCIAPCano) AND ([Cod_Area] like @lV9cCod_Area) AND ([IndicadoresCodigo] like @lV10cIndicadoresCodigo) AND ([TiposEnfermedadesCod] like @lV11cTiposEnfermedadesCod) AND ([INCIDENCIAPCZONA] like @lV12cINCIDENCIAPCZONA) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000X3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
