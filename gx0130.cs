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
   public class gx0130 : GXDataArea
   {
      public gx0130( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx0130( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out DateTime aP0_pCOSTONRFFPROCESFecha ,
                           out short aP1_pCOSTONRFFPROCESMes ,
                           out short aP2_pCOSTONRFFPROCESAno ,
                           out string aP3_pCod_Area ,
                           out string aP4_pIndicadoresCodigo ,
                           out string aP5_pMOTIVOSCOSRFFCodigo )
      {
         this.AV13pCOSTONRFFPROCESFecha = DateTime.MinValue ;
         this.AV14pCOSTONRFFPROCESMes = 0 ;
         this.AV15pCOSTONRFFPROCESAno = 0 ;
         this.AV16pCod_Area = "" ;
         this.AV17pIndicadoresCodigo = "" ;
         this.AV18pMOTIVOSCOSRFFCodigo = "" ;
         executePrivate();
         aP0_pCOSTONRFFPROCESFecha=this.AV13pCOSTONRFFPROCESFecha;
         aP1_pCOSTONRFFPROCESMes=this.AV14pCOSTONRFFPROCESMes;
         aP2_pCOSTONRFFPROCESAno=this.AV15pCOSTONRFFPROCESAno;
         aP3_pCod_Area=this.AV16pCod_Area;
         aP4_pIndicadoresCodigo=this.AV17pIndicadoresCodigo;
         aP5_pMOTIVOSCOSRFFCodigo=this.AV18pMOTIVOSCOSRFFCodigo;
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
            gxfirstwebparm = GetFirstPar( "pCOSTONRFFPROCESFecha");
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
               gxfirstwebparm = GetFirstPar( "pCOSTONRFFPROCESFecha");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCOSTONRFFPROCESFecha");
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
               AV13pCOSTONRFFPROCESFecha = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV13pCOSTONRFFPROCESFecha", context.localUtil.Format(AV13pCOSTONRFFPROCESFecha, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pCOSTONRFFPROCESMes = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTONRFFPROCESMes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pCOSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTONRFFPROCESMes), 4, 0));
                  AV15pCOSTONRFFPROCESAno = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTONRFFPROCESAno"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15pCOSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTONRFFPROCESAno), 4, 0));
                  AV16pCod_Area = GetPar( "pCod_Area");
                  AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
                  AV17pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
                  AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
                  AV18pMOTIVOSCOSRFFCodigo = GetPar( "pMOTIVOSCOSRFFCodigo");
                  AssignAttri("", false, "AV18pMOTIVOSCOSRFFCodigo", AV18pMOTIVOSCOSRFFCodigo);
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
         AV6cCOSTONRFFPROCESFecha = context.localUtil.ParseDateParm( GetPar( "cCOSTONRFFPROCESFecha"));
         AV7cCOSTONRFFPROCESMes = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTONRFFPROCESMes"), "."), 18, MidpointRounding.ToEven));
         AV8cCOSTONRFFPROCESAno = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTONRFFPROCESAno"), "."), 18, MidpointRounding.ToEven));
         AV9cCod_Area = GetPar( "cCod_Area");
         AV10cIndicadoresCodigo = GetPar( "cIndicadoresCodigo");
         AV11cCOSTONRFFPROCESValor = NumberUtil.Val( GetPar( "cCOSTONRFFPROCESValor"), ".");
         AV12cCOSTONRFFPROCESReg = context.localUtil.ParseDateParm( GetPar( "cCOSTONRFFPROCESReg"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCESFecha, AV7cCOSTONRFFPROCESMes, AV8cCOSTONRFFPROCESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPROCESValor, AV12cCOSTONRFFPROCESReg) ;
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
         PA172( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START172( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0130.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pCOSTONRFFPROCESFecha)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTONRFFPROCESMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pCOSTONRFFPROCESAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pCod_Area)),UrlEncode(StringUtil.RTrim(AV17pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV18pMOTIVOSCOSRFFCodigo))}, new string[] {"pCOSTONRFFPROCESFecha","pCOSTONRFFPROCESMes","pCOSTONRFFPROCESAno","pCod_Area","pIndicadoresCodigo","pMOTIVOSCOSRFFCodigo"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPROCESFECHA", context.localUtil.Format(AV6cCOSTONRFFPROCESFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPROCESMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTONRFFPROCESMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPROCESANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTONRFFPROCESAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOD_AREA", AV9cCod_Area);
         GxWebStd.gx_hidden_field( context, "GXH_vCINDICADORESCODIGO", AV10cIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPROCESVALOR", StringUtil.LTrim( StringUtil.NToC( AV11cCOSTONRFFPROCESValor, 16, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPROCESREG", context.localUtil.Format(AV12cCOSTONRFFPROCESReg, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTONRFFPROCESFECHA", context.localUtil.DToC( AV13pCOSTONRFFPROCESFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPCOSTONRFFPROCESMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pCOSTONRFFPROCESMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTONRFFPROCESANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15pCOSTONRFFPROCESAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOD_AREA", AV16pCod_Area);
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV17pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "vPMOTIVOSCOSRFFCODIGO", AV18pMOTIVOSCOSRFFCodigo);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCESFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprocesfechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCESMESFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprocesmesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCESANOFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprocesanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COD_AREAFILTERCONTAINER_Class", StringUtil.RTrim( divCod_areafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divIndicadorescodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCESVALORFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprocesvalorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCESREGFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprocesregfiltercontainer_Class));
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
            WE172( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT172( ) ;
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
         return formatLink("gx0130.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pCOSTONRFFPROCESFecha)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTONRFFPROCESMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pCOSTONRFFPROCESAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pCod_Area)),UrlEncode(StringUtil.RTrim(AV17pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV18pMOTIVOSCOSRFFCodigo))}, new string[] {"pCOSTONRFFPROCESFecha","pCOSTONRFFPROCESMes","pCOSTONRFFPROCESAno","pCod_Area","pIndicadoresCodigo","pMOTIVOSCOSRFFCodigo"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0130" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List COSTONRFFPROCES" ;
      }

      protected void WB170( )
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
            GxWebStd.gx_div_start( context, divCostonrffprocesfechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprocesfechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprocesfechafilter_Internalname, "COSTONRFFPROCESFecha", "", "", lblLblcostonrffprocesfechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11171_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0130.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprocesfecha_Internalname, "COSTONRFFPROCESFecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCcostonrffprocesfecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprocesfecha_Internalname, context.localUtil.Format(AV6cCOSTONRFFPROCESFecha, "99/99/99"), context.localUtil.Format( AV6cCOSTONRFFPROCESFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprocesfecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcostonrffprocesfecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0130.htm");
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
            GxWebStd.gx_div_start( context, divCostonrffprocesmesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprocesmesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprocesmesfilter_Internalname, "COSTONRFFPROCESMes", "", "", lblLblcostonrffprocesmesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0130.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprocesmes_Internalname, "COSTONRFFPROCESMes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprocesmes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTONRFFPROCESMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostonrffprocesmes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cCOSTONRFFPROCESMes), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cCOSTONRFFPROCESMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprocesmes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostonrffprocesmes_Visible, edtavCcostonrffprocesmes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0130.htm");
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
            GxWebStd.gx_div_start( context, divCostonrffprocesanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprocesanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprocesanofilter_Internalname, "COSTONRFFPROCESAno", "", "", lblLblcostonrffprocesanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0130.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprocesano_Internalname, "COSTONRFFPROCESAno", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprocesano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTONRFFPROCESAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostonrffprocesano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cCOSTONRFFPROCESAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cCOSTONRFFPROCESAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprocesano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostonrffprocesano_Visible, edtavCcostonrffprocesano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0130.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblcod_areafilter_Internalname, "Cod_Area", "", "", lblLblcod_areafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0130.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCcod_area_Internalname, AV9cCod_Area, StringUtil.RTrim( context.localUtil.Format( AV9cCod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcod_area_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcod_area_Visible, edtavCcod_area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0130.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblindicadorescodigofilter_Internalname, "Indicadores Codigo", "", "", lblLblindicadorescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0130.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCindicadorescodigo_Internalname, AV10cIndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( AV10cIndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCindicadorescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCindicadorescodigo_Visible, edtavCindicadorescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0130.htm");
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
            GxWebStd.gx_div_start( context, divCostonrffprocesvalorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprocesvalorfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprocesvalorfilter_Internalname, "COSTONRFFPROCESValor", "", "", lblLblcostonrffprocesvalorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16171_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0130.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprocesvalor_Internalname, "COSTONRFFPROCESValor", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprocesvalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11cCOSTONRFFPROCESValor, 16, 2, ",", "")), StringUtil.LTrim( ((edtavCcostonrffprocesvalor_Enabled!=0) ? context.localUtil.Format( AV11cCOSTONRFFPROCESValor, "ZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV11cCOSTONRFFPROCESValor, "ZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprocesvalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostonrffprocesvalor_Visible, edtavCcostonrffprocesvalor_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0130.htm");
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
            GxWebStd.gx_div_start( context, divCostonrffprocesregfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprocesregfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprocesregfilter_Internalname, "COSTONRFFPROCESReg", "", "", lblLblcostonrffprocesregfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17171_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0130.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprocesreg_Internalname, "COSTONRFFPROCESReg", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCcostonrffprocesreg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprocesreg_Internalname, context.localUtil.Format(AV12cCOSTONRFFPROCESReg, "99/99/99"), context.localUtil.Format( AV12cCOSTONRFFPROCESReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprocesreg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcostonrffprocesreg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0130.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18171_client"+"'", TempTags, "", 2, "HLP_Gx0130.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0130.htm");
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

      protected void START172( )
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
            Form.Meta.addItem("description", "Selection List COSTONRFFPROCES", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP170( ) ;
      }

      protected void WS172( )
      {
         START172( ) ;
         EVT172( ) ;
      }

      protected void EVT172( )
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
                              A80COSTONRFFPROCESFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCOSTONRFFPROCESFecha_Internalname), 0));
                              A81COSTONRFFPROCESMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A82COSTONRFFPROCESAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A5Cod_Area = cgiGet( edtCod_Area_Internalname);
                              A198COSTONRFFPROCESValor = context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESValor_Internalname), ",", ".");
                              A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
                              A66MOTIVOSCOSRFFCodigo = cgiGet( edtMOTIVOSCOSRFFCodigo_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19172 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20172 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccostonrffprocesfecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCCOSTONRFFPROCESFECHA"), 0) != AV6cCOSTONRFFPROCESFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostonrffprocesmes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCESMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTONRFFPROCESMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostonrffprocesano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCESANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTONRFFPROCESAno )) )
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
                                       /* Set Refresh If Ccostonrffprocesvalor Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCESVALOR"), ",", ".") != AV11cCOSTONRFFPROCESValor )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostonrffprocesreg Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCCOSTONRFFPROCESREG"), 0) != AV12cCOSTONRFFPROCESReg )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21172 ();
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

      protected void WE172( )
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

      protected void PA172( )
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
                                        DateTime AV6cCOSTONRFFPROCESFecha ,
                                        short AV7cCOSTONRFFPROCESMes ,
                                        short AV8cCOSTONRFFPROCESAno ,
                                        string AV9cCod_Area ,
                                        string AV10cIndicadoresCodigo ,
                                        decimal AV11cCOSTONRFFPROCESValor ,
                                        DateTime AV12cCOSTONRFFPROCESReg )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF172( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCESFECHA", GetSecureSignedToken( "", A80COSTONRFFPROCESFecha, context));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCESFECHA", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCESMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A81COSTONRFFPROCESMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCESMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A81COSTONRFFPROCESMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCESANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A82COSTONRFFPROCESAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPROCESANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A82COSTONRFFPROCESAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "COD_AREA", A5Cod_Area);
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGO", A4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_MOTIVOSCOSRFFCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A66MOTIVOSCOSRFFCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "MOTIVOSCOSRFFCODIGO", A66MOTIVOSCOSRFFCodigo);
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
         RF172( ) ;
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

      protected void RF172( )
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
                                                 AV11cCOSTONRFFPROCESValor ,
                                                 AV12cCOSTONRFFPROCESReg ,
                                                 A198COSTONRFFPROCESValor ,
                                                 A200COSTONRFFPROCESReg ,
                                                 A5Cod_Area ,
                                                 AV9cCod_Area ,
                                                 A4IndicadoresCodigo ,
                                                 AV10cIndicadoresCodigo ,
                                                 AV6cCOSTONRFFPROCESFecha ,
                                                 AV7cCOSTONRFFPROCESMes ,
                                                 AV8cCOSTONRFFPROCESAno } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
            lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
            /* Using cursor H00172 */
            pr_default.execute(0, new Object[] {AV6cCOSTONRFFPROCESFecha, AV7cCOSTONRFFPROCESMes, AV8cCOSTONRFFPROCESAno, lV9cCod_Area, lV10cIndicadoresCodigo, AV11cCOSTONRFFPROCESValor, AV12cCOSTONRFFPROCESReg, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A200COSTONRFFPROCESReg = H00172_A200COSTONRFFPROCESReg[0];
               A66MOTIVOSCOSRFFCodigo = H00172_A66MOTIVOSCOSRFFCodigo[0];
               A4IndicadoresCodigo = H00172_A4IndicadoresCodigo[0];
               A198COSTONRFFPROCESValor = H00172_A198COSTONRFFPROCESValor[0];
               A5Cod_Area = H00172_A5Cod_Area[0];
               A82COSTONRFFPROCESAno = H00172_A82COSTONRFFPROCESAno[0];
               A81COSTONRFFPROCESMes = H00172_A81COSTONRFFPROCESMes[0];
               A80COSTONRFFPROCESFecha = H00172_A80COSTONRFFPROCESFecha[0];
               /* Execute user event: Load */
               E20172 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB170( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes172( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCESFECHA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A80COSTONRFFPROCESFecha, context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCESMES"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A81COSTONRFFPROCESMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPROCESANO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A82COSTONRFFPROCESAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MOTIVOSCOSRFFCODIGO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A66MOTIVOSCOSRFFCodigo, "")), context));
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
                                              AV11cCOSTONRFFPROCESValor ,
                                              AV12cCOSTONRFFPROCESReg ,
                                              A198COSTONRFFPROCESValor ,
                                              A200COSTONRFFPROCESReg ,
                                              A5Cod_Area ,
                                              AV9cCod_Area ,
                                              A4IndicadoresCodigo ,
                                              AV10cIndicadoresCodigo ,
                                              AV6cCOSTONRFFPROCESFecha ,
                                              AV7cCOSTONRFFPROCESMes ,
                                              AV8cCOSTONRFFPROCESAno } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
         lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
         /* Using cursor H00173 */
         pr_default.execute(1, new Object[] {AV6cCOSTONRFFPROCESFecha, AV7cCOSTONRFFPROCESMes, AV8cCOSTONRFFPROCESAno, lV9cCod_Area, lV10cIndicadoresCodigo, AV11cCOSTONRFFPROCESValor, AV12cCOSTONRFFPROCESReg});
         GRID1_nRecordCount = H00173_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCESFecha, AV7cCOSTONRFFPROCESMes, AV8cCOSTONRFFPROCESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPROCESValor, AV12cCOSTONRFFPROCESReg) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCESFecha, AV7cCOSTONRFFPROCESMes, AV8cCOSTONRFFPROCESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPROCESValor, AV12cCOSTONRFFPROCESReg) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCESFecha, AV7cCOSTONRFFPROCESMes, AV8cCOSTONRFFPROCESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPROCESValor, AV12cCOSTONRFFPROCESReg) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCESFecha, AV7cCOSTONRFFPROCESMes, AV8cCOSTONRFFPROCESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPROCESValor, AV12cCOSTONRFFPROCESReg) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPROCESFecha, AV7cCOSTONRFFPROCESMes, AV8cCOSTONRFFPROCESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPROCESValor, AV12cCOSTONRFFPROCESReg) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP170( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19172 ();
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
            if ( context.localUtil.VCDate( cgiGet( edtavCcostonrffprocesfecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTONRFFPROCESFecha"}), 1, "vCCOSTONRFFPROCESFECHA");
               GX_FocusControl = edtavCcostonrffprocesfecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCOSTONRFFPROCESFecha = DateTime.MinValue;
               AssignAttri("", false, "AV6cCOSTONRFFPROCESFecha", context.localUtil.Format(AV6cCOSTONRFFPROCESFecha, "99/99/99"));
            }
            else
            {
               AV6cCOSTONRFFPROCESFecha = context.localUtil.CToD( cgiGet( edtavCcostonrffprocesfecha_Internalname), 2);
               AssignAttri("", false, "AV6cCOSTONRFFPROCESFecha", context.localUtil.Format(AV6cCOSTONRFFPROCESFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocesmes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocesmes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTONRFFPROCESMES");
               GX_FocusControl = edtavCcostonrffprocesmes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cCOSTONRFFPROCESMes = 0;
               AssignAttri("", false, "AV7cCOSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(AV7cCOSTONRFFPROCESMes), 4, 0));
            }
            else
            {
               AV7cCOSTONRFFPROCESMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostonrffprocesmes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cCOSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(AV7cCOSTONRFFPROCESMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocesano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocesano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTONRFFPROCESANO");
               GX_FocusControl = edtavCcostonrffprocesano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cCOSTONRFFPROCESAno = 0;
               AssignAttri("", false, "AV8cCOSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(AV8cCOSTONRFFPROCESAno), 4, 0));
            }
            else
            {
               AV8cCOSTONRFFPROCESAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostonrffprocesano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cCOSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(AV8cCOSTONRFFPROCESAno), 4, 0));
            }
            AV9cCod_Area = cgiGet( edtavCcod_area_Internalname);
            AssignAttri("", false, "AV9cCod_Area", AV9cCod_Area);
            AV10cIndicadoresCodigo = cgiGet( edtavCindicadorescodigo_Internalname);
            AssignAttri("", false, "AV10cIndicadoresCodigo", AV10cIndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocesvalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprocesvalor_Internalname), ",", ".") > 9999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTONRFFPROCESVALOR");
               GX_FocusControl = edtavCcostonrffprocesvalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cCOSTONRFFPROCESValor = 0;
               AssignAttri("", false, "AV11cCOSTONRFFPROCESValor", StringUtil.LTrimStr( AV11cCOSTONRFFPROCESValor, 16, 2));
            }
            else
            {
               AV11cCOSTONRFFPROCESValor = context.localUtil.CToN( cgiGet( edtavCcostonrffprocesvalor_Internalname), ",", ".");
               AssignAttri("", false, "AV11cCOSTONRFFPROCESValor", StringUtil.LTrimStr( AV11cCOSTONRFFPROCESValor, 16, 2));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCcostonrffprocesreg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTONRFFPROCESReg"}), 1, "vCCOSTONRFFPROCESREG");
               GX_FocusControl = edtavCcostonrffprocesreg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cCOSTONRFFPROCESReg = DateTime.MinValue;
               AssignAttri("", false, "AV12cCOSTONRFFPROCESReg", context.localUtil.Format(AV12cCOSTONRFFPROCESReg, "99/99/99"));
            }
            else
            {
               AV12cCOSTONRFFPROCESReg = context.localUtil.CToD( cgiGet( edtavCcostonrffprocesreg_Internalname), 2);
               AssignAttri("", false, "AV12cCOSTONRFFPROCESReg", context.localUtil.Format(AV12cCOSTONRFFPROCESReg, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCCOSTONRFFPROCESFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV6cCOSTONRFFPROCESFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCESMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTONRFFPROCESMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCESANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTONRFFPROCESAno )) )
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
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPROCESVALOR"), ",", ".") != AV11cCOSTONRFFPROCESValor )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCCOSTONRFFPROCESREG"), 2) ) != DateTimeUtil.ResetTime ( AV12cCOSTONRFFPROCESReg ) )
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
         E19172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19172( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "COSTONRFFPROCES", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV19ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20172( )
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
         E21172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21172( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pCOSTONRFFPROCESFecha = A80COSTONRFFPROCESFecha;
         AssignAttri("", false, "AV13pCOSTONRFFPROCESFecha", context.localUtil.Format(AV13pCOSTONRFFPROCESFecha, "99/99/99"));
         AV14pCOSTONRFFPROCESMes = A81COSTONRFFPROCESMes;
         AssignAttri("", false, "AV14pCOSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTONRFFPROCESMes), 4, 0));
         AV15pCOSTONRFFPROCESAno = A82COSTONRFFPROCESAno;
         AssignAttri("", false, "AV15pCOSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTONRFFPROCESAno), 4, 0));
         AV16pCod_Area = A5Cod_Area;
         AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
         AV17pIndicadoresCodigo = A4IndicadoresCodigo;
         AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
         AV18pMOTIVOSCOSRFFCodigo = A66MOTIVOSCOSRFFCodigo;
         AssignAttri("", false, "AV18pMOTIVOSCOSRFFCodigo", AV18pMOTIVOSCOSRFFCodigo);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV13pCOSTONRFFPROCESFecha, "99/99/99"),(short)AV14pCOSTONRFFPROCESMes,(short)AV15pCOSTONRFFPROCESAno,(string)AV16pCod_Area,(string)AV17pIndicadoresCodigo,(string)AV18pMOTIVOSCOSRFFCodigo});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pCOSTONRFFPROCESFecha","AV14pCOSTONRFFPROCESMes","AV15pCOSTONRFFPROCESAno","AV16pCod_Area","AV17pIndicadoresCodigo","AV18pMOTIVOSCOSRFFCodigo"});
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
         AV13pCOSTONRFFPROCESFecha = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV13pCOSTONRFFPROCESFecha", context.localUtil.Format(AV13pCOSTONRFFPROCESFecha, "99/99/99"));
         AV14pCOSTONRFFPROCESMes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV14pCOSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTONRFFPROCESMes), 4, 0));
         AV15pCOSTONRFFPROCESAno = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV15pCOSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTONRFFPROCESAno), 4, 0));
         AV16pCod_Area = (string)getParm(obj,3);
         AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
         AV17pIndicadoresCodigo = (string)getParm(obj,4);
         AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
         AV18pMOTIVOSCOSRFFCodigo = (string)getParm(obj,5);
         AssignAttri("", false, "AV18pMOTIVOSCOSRFFCodigo", AV18pMOTIVOSCOSRFFCodigo);
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
         PA172( ) ;
         WS172( ) ;
         WE172( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231025554", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1927500), false, true);
         context.AddJavascriptSource("gx0130.js", "?20247231025554", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtCOSTONRFFPROCESFecha_Internalname = "COSTONRFFPROCESFECHA_"+sGXsfl_84_idx;
         edtCOSTONRFFPROCESMes_Internalname = "COSTONRFFPROCESMES_"+sGXsfl_84_idx;
         edtCOSTONRFFPROCESAno_Internalname = "COSTONRFFPROCESANO_"+sGXsfl_84_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_idx;
         edtCOSTONRFFPROCESValor_Internalname = "COSTONRFFPROCESVALOR_"+sGXsfl_84_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_idx;
         edtMOTIVOSCOSRFFCodigo_Internalname = "MOTIVOSCOSRFFCODIGO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtCOSTONRFFPROCESFecha_Internalname = "COSTONRFFPROCESFECHA_"+sGXsfl_84_fel_idx;
         edtCOSTONRFFPROCESMes_Internalname = "COSTONRFFPROCESMES_"+sGXsfl_84_fel_idx;
         edtCOSTONRFFPROCESAno_Internalname = "COSTONRFFPROCESANO_"+sGXsfl_84_fel_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_fel_idx;
         edtCOSTONRFFPROCESValor_Internalname = "COSTONRFFPROCESVALOR_"+sGXsfl_84_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_fel_idx;
         edtMOTIVOSCOSRFFCodigo_Internalname = "MOTIVOSCOSRFFCODIGO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB170( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A81COSTONRFFPROCESMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A82COSTONRFFPROCESAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A66MOTIVOSCOSRFFCodigo)+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPROCESFecha_Internalname,context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"),context.localUtil.Format( A80COSTONRFFPROCESFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTONRFFPROCESFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPROCESMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A81COSTONRFFPROCESMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A81COSTONRFFPROCESMes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTONRFFPROCESMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPROCESAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A82COSTONRFFPROCESAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A82COSTONRFFPROCESAno), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTONRFFPROCESAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
            edtCOSTONRFFPROCESValor_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A81COSTONRFFPROCESMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A82COSTONRFFPROCESAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A66MOTIVOSCOSRFFCodigo)+"'"+"]);";
            AssignProp("", false, edtCOSTONRFFPROCESValor_Internalname, "Link", edtCOSTONRFFPROCESValor_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPROCESValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A198COSTONRFFPROCESValor, 16, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A198COSTONRFFPROCESValor, "ZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCOSTONRFFPROCESValor_Link,(string)"",(string)"",(string)"",(string)edtCOSTONRFFPROCESValor_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMOTIVOSCOSRFFCodigo_Internalname,(string)A66MOTIVOSCOSRFFCodigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMOTIVOSCOSRFFCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)140,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes172( ) ;
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
            context.SendWebValue( "COSTONRFFPROCESFecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTONRFFPROCESMes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTONRFFPROCESAno") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cod_Area") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTONRFFPROCESValor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Codigo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "MOTIVOSCOSRFFCodigo") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A81COSTONRFFPROCESMes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A82COSTONRFFPROCESAno), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A5Cod_Area));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A198COSTONRFFPROCESValor, 16, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCOSTONRFFPROCESValor_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A4IndicadoresCodigo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A66MOTIVOSCOSRFFCodigo));
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
         lblLblcostonrffprocesfechafilter_Internalname = "LBLCOSTONRFFPROCESFECHAFILTER";
         edtavCcostonrffprocesfecha_Internalname = "vCCOSTONRFFPROCESFECHA";
         divCostonrffprocesfechafiltercontainer_Internalname = "COSTONRFFPROCESFECHAFILTERCONTAINER";
         lblLblcostonrffprocesmesfilter_Internalname = "LBLCOSTONRFFPROCESMESFILTER";
         edtavCcostonrffprocesmes_Internalname = "vCCOSTONRFFPROCESMES";
         divCostonrffprocesmesfiltercontainer_Internalname = "COSTONRFFPROCESMESFILTERCONTAINER";
         lblLblcostonrffprocesanofilter_Internalname = "LBLCOSTONRFFPROCESANOFILTER";
         edtavCcostonrffprocesano_Internalname = "vCCOSTONRFFPROCESANO";
         divCostonrffprocesanofiltercontainer_Internalname = "COSTONRFFPROCESANOFILTERCONTAINER";
         lblLblcod_areafilter_Internalname = "LBLCOD_AREAFILTER";
         edtavCcod_area_Internalname = "vCCOD_AREA";
         divCod_areafiltercontainer_Internalname = "COD_AREAFILTERCONTAINER";
         lblLblindicadorescodigofilter_Internalname = "LBLINDICADORESCODIGOFILTER";
         edtavCindicadorescodigo_Internalname = "vCINDICADORESCODIGO";
         divIndicadorescodigofiltercontainer_Internalname = "INDICADORESCODIGOFILTERCONTAINER";
         lblLblcostonrffprocesvalorfilter_Internalname = "LBLCOSTONRFFPROCESVALORFILTER";
         edtavCcostonrffprocesvalor_Internalname = "vCCOSTONRFFPROCESVALOR";
         divCostonrffprocesvalorfiltercontainer_Internalname = "COSTONRFFPROCESVALORFILTERCONTAINER";
         lblLblcostonrffprocesregfilter_Internalname = "LBLCOSTONRFFPROCESREGFILTER";
         edtavCcostonrffprocesreg_Internalname = "vCCOSTONRFFPROCESREG";
         divCostonrffprocesregfiltercontainer_Internalname = "COSTONRFFPROCESREGFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCOSTONRFFPROCESFecha_Internalname = "COSTONRFFPROCESFECHA";
         edtCOSTONRFFPROCESMes_Internalname = "COSTONRFFPROCESMES";
         edtCOSTONRFFPROCESAno_Internalname = "COSTONRFFPROCESANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtCOSTONRFFPROCESValor_Internalname = "COSTONRFFPROCESVALOR";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtMOTIVOSCOSRFFCodigo_Internalname = "MOTIVOSCOSRFFCODIGO";
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
         edtMOTIVOSCOSRFFCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtCOSTONRFFPROCESValor_Jsonclick = "";
         edtCOSTONRFFPROCESValor_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCOSTONRFFPROCESAno_Jsonclick = "";
         edtCOSTONRFFPROCESMes_Jsonclick = "";
         edtCOSTONRFFPROCESFecha_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCcostonrffprocesreg_Jsonclick = "";
         edtavCcostonrffprocesreg_Enabled = 1;
         edtavCcostonrffprocesvalor_Jsonclick = "";
         edtavCcostonrffprocesvalor_Enabled = 1;
         edtavCcostonrffprocesvalor_Visible = 1;
         edtavCindicadorescodigo_Jsonclick = "";
         edtavCindicadorescodigo_Enabled = 1;
         edtavCindicadorescodigo_Visible = 1;
         edtavCcod_area_Jsonclick = "";
         edtavCcod_area_Enabled = 1;
         edtavCcod_area_Visible = 1;
         edtavCcostonrffprocesano_Jsonclick = "";
         edtavCcostonrffprocesano_Enabled = 1;
         edtavCcostonrffprocesano_Visible = 1;
         edtavCcostonrffprocesmes_Jsonclick = "";
         edtavCcostonrffprocesmes_Enabled = 1;
         edtavCcostonrffprocesmes_Visible = 1;
         edtavCcostonrffprocesfecha_Jsonclick = "";
         edtavCcostonrffprocesfecha_Enabled = 1;
         divCostonrffprocesregfiltercontainer_Class = "AdvancedContainerItem";
         divCostonrffprocesvalorfiltercontainer_Class = "AdvancedContainerItem";
         divIndicadorescodigofiltercontainer_Class = "AdvancedContainerItem";
         divCod_areafiltercontainer_Class = "AdvancedContainerItem";
         divCostonrffprocesanofiltercontainer_Class = "AdvancedContainerItem";
         divCostonrffprocesmesfiltercontainer_Class = "AdvancedContainerItem";
         divCostonrffprocesfechafiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List COSTONRFFPROCES";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPROCESFecha',fld:'vCCOSTONRFFPROCESFECHA',pic:''},{av:'AV7cCOSTONRFFPROCESMes',fld:'vCCOSTONRFFPROCESMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPROCESAno',fld:'vCCOSTONRFFPROCESANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTONRFFPROCESValor',fld:'vCCOSTONRFFPROCESVALOR',pic:'ZZZZZZZZZZZZ9.99'},{av:'AV12cCOSTONRFFPROCESReg',fld:'vCCOSTONRFFPROCESREG',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18171',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCOSTONRFFPROCESFECHAFILTER.CLICK","{handler:'E11171',iparms:[{av:'divCostonrffprocesfechafiltercontainer_Class',ctrl:'COSTONRFFPROCESFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPROCESFECHAFILTER.CLICK",",oparms:[{av:'divCostonrffprocesfechafiltercontainer_Class',ctrl:'COSTONRFFPROCESFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLCOSTONRFFPROCESMESFILTER.CLICK","{handler:'E12171',iparms:[{av:'divCostonrffprocesmesfiltercontainer_Class',ctrl:'COSTONRFFPROCESMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPROCESMESFILTER.CLICK",",oparms:[{av:'divCostonrffprocesmesfiltercontainer_Class',ctrl:'COSTONRFFPROCESMESFILTERCONTAINER',prop:'Class'},{av:'edtavCcostonrffprocesmes_Visible',ctrl:'vCCOSTONRFFPROCESMES',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTONRFFPROCESANOFILTER.CLICK","{handler:'E13171',iparms:[{av:'divCostonrffprocesanofiltercontainer_Class',ctrl:'COSTONRFFPROCESANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPROCESANOFILTER.CLICK",",oparms:[{av:'divCostonrffprocesanofiltercontainer_Class',ctrl:'COSTONRFFPROCESANOFILTERCONTAINER',prop:'Class'},{av:'edtavCcostonrffprocesano_Visible',ctrl:'vCCOSTONRFFPROCESANO',prop:'Visible'}]}");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK","{handler:'E14171',iparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK",",oparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'},{av:'edtavCcod_area_Visible',ctrl:'vCCOD_AREA',prop:'Visible'}]}");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK","{handler:'E15171',iparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK",",oparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCindicadorescodigo_Visible',ctrl:'vCINDICADORESCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTONRFFPROCESVALORFILTER.CLICK","{handler:'E16171',iparms:[{av:'divCostonrffprocesvalorfiltercontainer_Class',ctrl:'COSTONRFFPROCESVALORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPROCESVALORFILTER.CLICK",",oparms:[{av:'divCostonrffprocesvalorfiltercontainer_Class',ctrl:'COSTONRFFPROCESVALORFILTERCONTAINER',prop:'Class'},{av:'edtavCcostonrffprocesvalor_Visible',ctrl:'vCCOSTONRFFPROCESVALOR',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTONRFFPROCESREGFILTER.CLICK","{handler:'E17171',iparms:[{av:'divCostonrffprocesregfiltercontainer_Class',ctrl:'COSTONRFFPROCESREGFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPROCESREGFILTER.CLICK",",oparms:[{av:'divCostonrffprocesregfiltercontainer_Class',ctrl:'COSTONRFFPROCESREGFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("ENTER","{handler:'E21172',iparms:[{av:'A80COSTONRFFPROCESFecha',fld:'COSTONRFFPROCESFECHA',pic:'',hsh:true},{av:'A81COSTONRFFPROCESMes',fld:'COSTONRFFPROCESMES',pic:'ZZZ9',hsh:true},{av:'A82COSTONRFFPROCESAno',fld:'COSTONRFFPROCESANO',pic:'ZZZ9',hsh:true},{av:'A5Cod_Area',fld:'COD_AREA',pic:'',hsh:true},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:'',hsh:true},{av:'A66MOTIVOSCOSRFFCodigo',fld:'MOTIVOSCOSRFFCODIGO',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pCOSTONRFFPROCESFecha',fld:'vPCOSTONRFFPROCESFECHA',pic:''},{av:'AV14pCOSTONRFFPROCESMes',fld:'vPCOSTONRFFPROCESMES',pic:'ZZZ9'},{av:'AV15pCOSTONRFFPROCESAno',fld:'vPCOSTONRFFPROCESANO',pic:'ZZZ9'},{av:'AV16pCod_Area',fld:'vPCOD_AREA',pic:''},{av:'AV17pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV18pMOTIVOSCOSRFFCodigo',fld:'vPMOTIVOSCOSRFFCODIGO',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPROCESFecha',fld:'vCCOSTONRFFPROCESFECHA',pic:''},{av:'AV7cCOSTONRFFPROCESMes',fld:'vCCOSTONRFFPROCESMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPROCESAno',fld:'vCCOSTONRFFPROCESANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTONRFFPROCESValor',fld:'vCCOSTONRFFPROCESVALOR',pic:'ZZZZZZZZZZZZ9.99'},{av:'AV12cCOSTONRFFPROCESReg',fld:'vCCOSTONRFFPROCESREG',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPROCESFecha',fld:'vCCOSTONRFFPROCESFECHA',pic:''},{av:'AV7cCOSTONRFFPROCESMes',fld:'vCCOSTONRFFPROCESMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPROCESAno',fld:'vCCOSTONRFFPROCESANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTONRFFPROCESValor',fld:'vCCOSTONRFFPROCESVALOR',pic:'ZZZZZZZZZZZZ9.99'},{av:'AV12cCOSTONRFFPROCESReg',fld:'vCCOSTONRFFPROCESREG',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPROCESFecha',fld:'vCCOSTONRFFPROCESFECHA',pic:''},{av:'AV7cCOSTONRFFPROCESMes',fld:'vCCOSTONRFFPROCESMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPROCESAno',fld:'vCCOSTONRFFPROCESANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTONRFFPROCESValor',fld:'vCCOSTONRFFPROCESVALOR',pic:'ZZZZZZZZZZZZ9.99'},{av:'AV12cCOSTONRFFPROCESReg',fld:'vCCOSTONRFFPROCESREG',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPROCESFecha',fld:'vCCOSTONRFFPROCESFECHA',pic:''},{av:'AV7cCOSTONRFFPROCESMes',fld:'vCCOSTONRFFPROCESMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPROCESAno',fld:'vCCOSTONRFFPROCESANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTONRFFPROCESValor',fld:'vCCOSTONRFFPROCESVALOR',pic:'ZZZZZZZZZZZZ9.99'},{av:'AV12cCOSTONRFFPROCESReg',fld:'vCCOSTONRFFPROCESREG',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCOSTONRFFPROCESFECHA","{handler:'Validv_Ccostonrffprocesfecha',iparms:[]");
         setEventMetadata("VALIDV_CCOSTONRFFPROCESFECHA",",oparms:[]}");
         setEventMetadata("VALIDV_CCOSTONRFFPROCESREG","{handler:'Validv_Ccostonrffprocesreg',iparms:[]");
         setEventMetadata("VALIDV_CCOSTONRFFPROCESREG",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Motivoscosrffcodigo',iparms:[]");
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
         AV13pCOSTONRFFPROCESFecha = DateTime.MinValue;
         AV16pCod_Area = "";
         AV17pIndicadoresCodigo = "";
         AV18pMOTIVOSCOSRFFCodigo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cCOSTONRFFPROCESFecha = DateTime.MinValue;
         AV9cCod_Area = "";
         AV10cIndicadoresCodigo = "";
         AV12cCOSTONRFFPROCESReg = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcostonrffprocesfechafilter_Jsonclick = "";
         TempTags = "";
         lblLblcostonrffprocesmesfilter_Jsonclick = "";
         lblLblcostonrffprocesanofilter_Jsonclick = "";
         lblLblcod_areafilter_Jsonclick = "";
         lblLblindicadorescodigofilter_Jsonclick = "";
         lblLblcostonrffprocesvalorfilter_Jsonclick = "";
         lblLblcostonrffprocesregfilter_Jsonclick = "";
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
         A80COSTONRFFPROCESFecha = DateTime.MinValue;
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A66MOTIVOSCOSRFFCodigo = "";
         scmdbuf = "";
         lV9cCod_Area = "";
         lV10cIndicadoresCodigo = "";
         A200COSTONRFFPROCESReg = DateTime.MinValue;
         H00172_A200COSTONRFFPROCESReg = new DateTime[] {DateTime.MinValue} ;
         H00172_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         H00172_A4IndicadoresCodigo = new string[] {""} ;
         H00172_A198COSTONRFFPROCESValor = new decimal[1] ;
         H00172_A5Cod_Area = new string[] {""} ;
         H00172_A82COSTONRFFPROCESAno = new short[1] ;
         H00172_A81COSTONRFFPROCESMes = new short[1] ;
         H00172_A80COSTONRFFPROCESFecha = new DateTime[] {DateTime.MinValue} ;
         H00173_AGRID1_nRecordCount = new long[1] ;
         AV19ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0130__default(),
            new Object[][] {
                new Object[] {
               H00172_A200COSTONRFFPROCESReg, H00172_A66MOTIVOSCOSRFFCodigo, H00172_A4IndicadoresCodigo, H00172_A198COSTONRFFPROCESValor, H00172_A5Cod_Area, H00172_A82COSTONRFFPROCESAno, H00172_A81COSTONRFFPROCESMes, H00172_A80COSTONRFFPROCESFecha
               }
               , new Object[] {
               H00173_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14pCOSTONRFFPROCESMes ;
      private short AV15pCOSTONRFFPROCESAno ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cCOSTONRFFPROCESMes ;
      private short AV8cCOSTONRFFPROCESAno ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A81COSTONRFFPROCESMes ;
      private short A82COSTONRFFPROCESAno ;
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
      private int edtavCcostonrffprocesfecha_Enabled ;
      private int edtavCcostonrffprocesmes_Enabled ;
      private int edtavCcostonrffprocesmes_Visible ;
      private int edtavCcostonrffprocesano_Enabled ;
      private int edtavCcostonrffprocesano_Visible ;
      private int edtavCcod_area_Visible ;
      private int edtavCcod_area_Enabled ;
      private int edtavCindicadorescodigo_Visible ;
      private int edtavCindicadorescodigo_Enabled ;
      private int edtavCcostonrffprocesvalor_Enabled ;
      private int edtavCcostonrffprocesvalor_Visible ;
      private int edtavCcostonrffprocesreg_Enabled ;
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
      private decimal AV11cCOSTONRFFPROCESValor ;
      private decimal A198COSTONRFFPROCESValor ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCostonrffprocesfechafiltercontainer_Class ;
      private string divCostonrffprocesmesfiltercontainer_Class ;
      private string divCostonrffprocesanofiltercontainer_Class ;
      private string divCod_areafiltercontainer_Class ;
      private string divIndicadorescodigofiltercontainer_Class ;
      private string divCostonrffprocesvalorfiltercontainer_Class ;
      private string divCostonrffprocesregfiltercontainer_Class ;
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
      private string divCostonrffprocesfechafiltercontainer_Internalname ;
      private string lblLblcostonrffprocesfechafilter_Internalname ;
      private string lblLblcostonrffprocesfechafilter_Jsonclick ;
      private string edtavCcostonrffprocesfecha_Internalname ;
      private string TempTags ;
      private string edtavCcostonrffprocesfecha_Jsonclick ;
      private string divCostonrffprocesmesfiltercontainer_Internalname ;
      private string lblLblcostonrffprocesmesfilter_Internalname ;
      private string lblLblcostonrffprocesmesfilter_Jsonclick ;
      private string edtavCcostonrffprocesmes_Internalname ;
      private string edtavCcostonrffprocesmes_Jsonclick ;
      private string divCostonrffprocesanofiltercontainer_Internalname ;
      private string lblLblcostonrffprocesanofilter_Internalname ;
      private string lblLblcostonrffprocesanofilter_Jsonclick ;
      private string edtavCcostonrffprocesano_Internalname ;
      private string edtavCcostonrffprocesano_Jsonclick ;
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
      private string divCostonrffprocesvalorfiltercontainer_Internalname ;
      private string lblLblcostonrffprocesvalorfilter_Internalname ;
      private string lblLblcostonrffprocesvalorfilter_Jsonclick ;
      private string edtavCcostonrffprocesvalor_Internalname ;
      private string edtavCcostonrffprocesvalor_Jsonclick ;
      private string divCostonrffprocesregfiltercontainer_Internalname ;
      private string lblLblcostonrffprocesregfilter_Internalname ;
      private string lblLblcostonrffprocesregfilter_Jsonclick ;
      private string edtavCcostonrffprocesreg_Internalname ;
      private string edtavCcostonrffprocesreg_Jsonclick ;
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
      private string edtCOSTONRFFPROCESFecha_Internalname ;
      private string edtCOSTONRFFPROCESMes_Internalname ;
      private string edtCOSTONRFFPROCESAno_Internalname ;
      private string edtCod_Area_Internalname ;
      private string edtCOSTONRFFPROCESValor_Internalname ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtMOTIVOSCOSRFFCodigo_Internalname ;
      private string scmdbuf ;
      private string AV19ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCOSTONRFFPROCESFecha_Jsonclick ;
      private string edtCOSTONRFFPROCESMes_Jsonclick ;
      private string edtCOSTONRFFPROCESAno_Jsonclick ;
      private string edtCod_Area_Jsonclick ;
      private string edtCOSTONRFFPROCESValor_Link ;
      private string edtCOSTONRFFPROCESValor_Jsonclick ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string edtMOTIVOSCOSRFFCodigo_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV13pCOSTONRFFPROCESFecha ;
      private DateTime AV6cCOSTONRFFPROCESFecha ;
      private DateTime AV12cCOSTONRFFPROCESReg ;
      private DateTime A80COSTONRFFPROCESFecha ;
      private DateTime A200COSTONRFFPROCESReg ;
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
      private string AV18pMOTIVOSCOSRFFCodigo ;
      private string AV9cCod_Area ;
      private string AV10cIndicadoresCodigo ;
      private string AV22Linkselection_GXI ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A66MOTIVOSCOSRFFCodigo ;
      private string lV9cCod_Area ;
      private string lV10cIndicadoresCodigo ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H00172_A200COSTONRFFPROCESReg ;
      private string[] H00172_A66MOTIVOSCOSRFFCodigo ;
      private string[] H00172_A4IndicadoresCodigo ;
      private decimal[] H00172_A198COSTONRFFPROCESValor ;
      private string[] H00172_A5Cod_Area ;
      private short[] H00172_A82COSTONRFFPROCESAno ;
      private short[] H00172_A81COSTONRFFPROCESMes ;
      private DateTime[] H00172_A80COSTONRFFPROCESFecha ;
      private long[] H00173_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP0_pCOSTONRFFPROCESFecha ;
      private short aP1_pCOSTONRFFPROCESMes ;
      private short aP2_pCOSTONRFFPROCESAno ;
      private string aP3_pCod_Area ;
      private string aP4_pIndicadoresCodigo ;
      private string aP5_pMOTIVOSCOSRFFCodigo ;
      private GXWebForm Form ;
   }

   public class gx0130__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00172( IGxContext context ,
                                             decimal AV11cCOSTONRFFPROCESValor ,
                                             DateTime AV12cCOSTONRFFPROCESReg ,
                                             decimal A198COSTONRFFPROCESValor ,
                                             DateTime A200COSTONRFFPROCESReg ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             DateTime AV6cCOSTONRFFPROCESFecha ,
                                             short AV7cCOSTONRFFPROCESMes ,
                                             short AV8cCOSTONRFFPROCESAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [COSTONRFFPROCESReg], [MOTIVOSCOSRFFCodigo], [IndicadoresCodigo], [COSTONRFFPROCESValor], [Cod_Area], [COSTONRFFPROCESAno], [COSTONRFFPROCESMes], [COSTONRFFPROCESFecha]";
         sFromString = " FROM [COSTONRFFPROCES]";
         sOrderString = "";
         AddWhere(sWhereString, "([COSTONRFFPROCESFecha] >= @AV6cCOSTONRFFPROCESFecha and [COSTONRFFPROCESMes] >= @AV7cCOSTONRFFPROCESMes and [COSTONRFFPROCESAno] >= @AV8cCOSTONRFFPROCESAno)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         if ( ! (Convert.ToDecimal(0)==AV11cCOSTONRFFPROCESValor) )
         {
            AddWhere(sWhereString, "([COSTONRFFPROCESValor] >= @AV11cCOSTONRFFPROCESValor)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cCOSTONRFFPROCESReg) )
         {
            AddWhere(sWhereString, "([COSTONRFFPROCESReg] >= @AV12cCOSTONRFFPROCESReg)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00173( IGxContext context ,
                                             decimal AV11cCOSTONRFFPROCESValor ,
                                             DateTime AV12cCOSTONRFFPROCESReg ,
                                             decimal A198COSTONRFFPROCESValor ,
                                             DateTime A200COSTONRFFPROCESReg ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             DateTime AV6cCOSTONRFFPROCESFecha ,
                                             short AV7cCOSTONRFFPROCESMes ,
                                             short AV8cCOSTONRFFPROCESAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [COSTONRFFPROCES]";
         AddWhere(sWhereString, "([COSTONRFFPROCESFecha] >= @AV6cCOSTONRFFPROCESFecha and [COSTONRFFPROCESMes] >= @AV7cCOSTONRFFPROCESMes and [COSTONRFFPROCESAno] >= @AV8cCOSTONRFFPROCESAno)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         if ( ! (Convert.ToDecimal(0)==AV11cCOSTONRFFPROCESValor) )
         {
            AddWhere(sWhereString, "([COSTONRFFPROCESValor] >= @AV11cCOSTONRFFPROCESValor)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cCOSTONRFFPROCESReg) )
         {
            AddWhere(sWhereString, "([COSTONRFFPROCESReg] >= @AV12cCOSTONRFFPROCESReg)");
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
                     return conditional_H00172(context, (decimal)dynConstraints[0] , (DateTime)dynConstraints[1] , (decimal)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H00173(context, (decimal)dynConstraints[0] , (DateTime)dynConstraints[1] , (decimal)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmH00172;
          prmH00172 = new Object[] {
          new ParDef("@AV6cCOSTONRFFPROCESFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTONRFFPROCESMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTONRFFPROCESAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cCOSTONRFFPROCESValor",GXType.Decimal,16,2) ,
          new ParDef("@AV12cCOSTONRFFPROCESReg",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00173;
          prmH00173 = new Object[] {
          new ParDef("@AV6cCOSTONRFFPROCESFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTONRFFPROCESMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTONRFFPROCESAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cCOSTONRFFPROCESValor",GXType.Decimal,16,2) ,
          new ParDef("@AV12cCOSTONRFFPROCESReg",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00172", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00172,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00173", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00173,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
