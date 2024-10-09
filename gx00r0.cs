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
   public class gx00r0 : GXDataArea
   {
      public gx00r0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx00r0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out DateTime aP0_pFRUTAPROPIAFecha ,
                           out short aP1_pFRUTAPROPIAMes ,
                           out short aP2_pFRUTAPROPIAAno ,
                           out string aP3_pIndicadoresCodigo ,
                           out string aP4_pCod_Area ,
                           out long aP5_pVIAJE ,
                           out string aP6_pSETOR ,
                           out string aP7_pFINCA ,
                           out string aP8_pPROVE_COD ,
                           out DateTime aP9_pDIA ,
                           out string aP10_pLOTE ,
                           out string aP11_pTAL )
      {
         this.AV13pFRUTAPROPIAFecha = DateTime.MinValue ;
         this.AV14pFRUTAPROPIAMes = 0 ;
         this.AV15pFRUTAPROPIAAno = 0 ;
         this.AV16pIndicadoresCodigo = "" ;
         this.AV17pCod_Area = "" ;
         this.AV18pVIAJE = 0 ;
         this.AV19pSETOR = "" ;
         this.AV20pFINCA = "" ;
         this.AV21pPROVE_COD = "" ;
         this.AV22pDIA = DateTime.MinValue ;
         this.AV23pLOTE = "" ;
         this.AV24pTAL = "" ;
         executePrivate();
         aP0_pFRUTAPROPIAFecha=this.AV13pFRUTAPROPIAFecha;
         aP1_pFRUTAPROPIAMes=this.AV14pFRUTAPROPIAMes;
         aP2_pFRUTAPROPIAAno=this.AV15pFRUTAPROPIAAno;
         aP3_pIndicadoresCodigo=this.AV16pIndicadoresCodigo;
         aP4_pCod_Area=this.AV17pCod_Area;
         aP5_pVIAJE=this.AV18pVIAJE;
         aP6_pSETOR=this.AV19pSETOR;
         aP7_pFINCA=this.AV20pFINCA;
         aP8_pPROVE_COD=this.AV21pPROVE_COD;
         aP9_pDIA=this.AV22pDIA;
         aP10_pLOTE=this.AV23pLOTE;
         aP11_pTAL=this.AV24pTAL;
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
            gxfirstwebparm = GetFirstPar( "pFRUTAPROPIAFecha");
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
               gxfirstwebparm = GetFirstPar( "pFRUTAPROPIAFecha");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pFRUTAPROPIAFecha");
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
               AV13pFRUTAPROPIAFecha = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV13pFRUTAPROPIAFecha", context.localUtil.Format(AV13pFRUTAPROPIAFecha, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pFRUTAPROPIAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "pFRUTAPROPIAMes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pFRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(AV14pFRUTAPROPIAMes), 4, 0));
                  AV15pFRUTAPROPIAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "pFRUTAPROPIAAno"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15pFRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(AV15pFRUTAPROPIAAno), 4, 0));
                  AV16pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
                  AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
                  AV17pCod_Area = GetPar( "pCod_Area");
                  AssignAttri("", false, "AV17pCod_Area", AV17pCod_Area);
                  AV18pVIAJE = (long)(Math.Round(NumberUtil.Val( GetPar( "pVIAJE"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV18pVIAJE", StringUtil.LTrimStr( (decimal)(AV18pVIAJE), 12, 0));
                  AV19pSETOR = GetPar( "pSETOR");
                  AssignAttri("", false, "AV19pSETOR", AV19pSETOR);
                  AV20pFINCA = GetPar( "pFINCA");
                  AssignAttri("", false, "AV20pFINCA", AV20pFINCA);
                  AV21pPROVE_COD = GetPar( "pPROVE_COD");
                  AssignAttri("", false, "AV21pPROVE_COD", AV21pPROVE_COD);
                  AV22pDIA = context.localUtil.ParseDTimeParm( GetPar( "pDIA"));
                  AssignAttri("", false, "AV22pDIA", context.localUtil.TToC( AV22pDIA, 8, 5, 0, 3, "/", ":", " "));
                  AV23pLOTE = GetPar( "pLOTE");
                  AssignAttri("", false, "AV23pLOTE", AV23pLOTE);
                  AV24pTAL = GetPar( "pTAL");
                  AssignAttri("", false, "AV24pTAL", AV24pTAL);
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
         AV6cFRUTAPROPIAFecha = context.localUtil.ParseDateParm( GetPar( "cFRUTAPROPIAFecha"));
         AV7cFRUTAPROPIAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "cFRUTAPROPIAMes"), "."), 18, MidpointRounding.ToEven));
         AV8cFRUTAPROPIAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "cFRUTAPROPIAAno"), "."), 18, MidpointRounding.ToEven));
         AV9cIndicadoresCodigo = GetPar( "cIndicadoresCodigo");
         AV10cCod_Area = GetPar( "cCod_Area");
         AV11cVIAJE = (long)(Math.Round(NumberUtil.Val( GetPar( "cVIAJE"), "."), 18, MidpointRounding.ToEven));
         AV12cSETOR = GetPar( "cSETOR");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cFRUTAPROPIAFecha, AV7cFRUTAPROPIAMes, AV8cFRUTAPROPIAAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cVIAJE, AV12cSETOR) ;
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
         PA0T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0T2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00r0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pFRUTAPROPIAFecha)),UrlEncode(StringUtil.LTrimStr(AV14pFRUTAPROPIAMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pFRUTAPROPIAAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV17pCod_Area)),UrlEncode(StringUtil.LTrimStr(AV18pVIAJE,12,0)),UrlEncode(StringUtil.RTrim(AV19pSETOR)),UrlEncode(StringUtil.RTrim(AV20pFINCA)),UrlEncode(StringUtil.RTrim(AV21pPROVE_COD)),UrlEncode(DateTimeUtil.FormatDateTimeParm(AV22pDIA)),UrlEncode(StringUtil.RTrim(AV23pLOTE)),UrlEncode(StringUtil.RTrim(AV24pTAL))}, new string[] {"pFRUTAPROPIAFecha","pFRUTAPROPIAMes","pFRUTAPROPIAAno","pIndicadoresCodigo","pCod_Area","pVIAJE","pSETOR","pFINCA","pPROVE_COD","pDIA","pLOTE","pTAL"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCFRUTAPROPIAFECHA", context.localUtil.Format(AV6cFRUTAPROPIAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCFRUTAPROPIAMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cFRUTAPROPIAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCFRUTAPROPIAANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cFRUTAPROPIAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINDICADORESCODIGO", AV9cIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCCOD_AREA", AV10cCod_Area);
         GxWebStd.gx_hidden_field( context, "GXH_vCVIAJE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cVIAJE), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSETOR", AV12cSETOR);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPFRUTAPROPIAFECHA", context.localUtil.DToC( AV13pFRUTAPROPIAFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPFRUTAPROPIAMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pFRUTAPROPIAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPFRUTAPROPIAANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15pFRUTAPROPIAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV16pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "vPCOD_AREA", AV17pCod_Area);
         GxWebStd.gx_hidden_field( context, "vPVIAJE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18pVIAJE), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPSETOR", AV19pSETOR);
         GxWebStd.gx_hidden_field( context, "vPFINCA", AV20pFINCA);
         GxWebStd.gx_hidden_field( context, "vPPROVE_COD", AV21pPROVE_COD);
         GxWebStd.gx_hidden_field( context, "vPDIA", context.localUtil.TToC( AV22pDIA, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vPLOTE", AV23pLOTE);
         GxWebStd.gx_hidden_field( context, "vPTAL", AV24pTAL);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "FRUTAPROPIAFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divFrutapropiafechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FRUTAPROPIAMESFILTERCONTAINER_Class", StringUtil.RTrim( divFrutapropiamesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FRUTAPROPIAANOFILTERCONTAINER_Class", StringUtil.RTrim( divFrutapropiaanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divIndicadorescodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COD_AREAFILTERCONTAINER_Class", StringUtil.RTrim( divCod_areafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VIAJEFILTERCONTAINER_Class", StringUtil.RTrim( divViajefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SETORFILTERCONTAINER_Class", StringUtil.RTrim( divSetorfiltercontainer_Class));
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
            WE0T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0T2( ) ;
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
         return formatLink("gx00r0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pFRUTAPROPIAFecha)),UrlEncode(StringUtil.LTrimStr(AV14pFRUTAPROPIAMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pFRUTAPROPIAAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV17pCod_Area)),UrlEncode(StringUtil.LTrimStr(AV18pVIAJE,12,0)),UrlEncode(StringUtil.RTrim(AV19pSETOR)),UrlEncode(StringUtil.RTrim(AV20pFINCA)),UrlEncode(StringUtil.RTrim(AV21pPROVE_COD)),UrlEncode(DateTimeUtil.FormatDateTimeParm(AV22pDIA)),UrlEncode(StringUtil.RTrim(AV23pLOTE)),UrlEncode(StringUtil.RTrim(AV24pTAL))}, new string[] {"pFRUTAPROPIAFecha","pFRUTAPROPIAMes","pFRUTAPROPIAAno","pIndicadoresCodigo","pCod_Area","pVIAJE","pSETOR","pFINCA","pPROVE_COD","pDIA","pLOTE","pTAL"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00R0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List FRUTAPROPIA" ;
      }

      protected void WB0T0( )
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
            GxWebStd.gx_div_start( context, divFrutapropiafechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divFrutapropiafechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblfrutapropiafechafilter_Internalname, "FRUTAPROPIAFecha", "", "", lblLblfrutapropiafechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110t1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCfrutapropiafecha_Internalname, "FRUTAPROPIAFecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCfrutapropiafecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCfrutapropiafecha_Internalname, context.localUtil.Format(AV6cFRUTAPROPIAFecha, "99/99/99"), context.localUtil.Format( AV6cFRUTAPROPIAFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCfrutapropiafecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCfrutapropiafecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_div_start( context, divFrutapropiamesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divFrutapropiamesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblfrutapropiamesfilter_Internalname, "FRUTAPROPIAMes", "", "", lblLblfrutapropiamesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120t1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCfrutapropiames_Internalname, "FRUTAPROPIAMes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCfrutapropiames_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cFRUTAPROPIAMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCfrutapropiames_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cFRUTAPROPIAMes), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cFRUTAPROPIAMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCfrutapropiames_Jsonclick, 0, "Attribute", "", "", "", "", edtavCfrutapropiames_Visible, edtavCfrutapropiames_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_div_start( context, divFrutapropiaanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divFrutapropiaanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblfrutapropiaanofilter_Internalname, "FRUTAPROPIAAno", "", "", lblLblfrutapropiaanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130t1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCfrutapropiaano_Internalname, "FRUTAPROPIAAno", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCfrutapropiaano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cFRUTAPROPIAAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCfrutapropiaano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cFRUTAPROPIAAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cFRUTAPROPIAAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCfrutapropiaano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCfrutapropiaano_Visible, edtavCfrutapropiaano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblindicadorescodigofilter_Internalname, "Indicadores Codigo", "", "", lblLblindicadorescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140t1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCindicadorescodigo_Internalname, AV9cIndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( AV9cIndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCindicadorescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCindicadorescodigo_Visible, edtavCindicadorescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblcod_areafilter_Internalname, "Cod_Area", "", "", lblLblcod_areafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150t1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcod_area_Internalname, AV10cCod_Area, StringUtil.RTrim( context.localUtil.Format( AV10cCod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcod_area_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcod_area_Visible, edtavCcod_area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_div_start( context, divViajefiltercontainer_Internalname, 1, 0, "px", 0, "px", divViajefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblviajefilter_Internalname, "VIAJE", "", "", lblLblviajefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160t1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCviaje_Internalname, "VIAJE", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCviaje_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cVIAJE), 12, 0, ",", "")), StringUtil.LTrim( ((edtavCviaje_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cVIAJE), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV11cVIAJE), "ZZZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCviaje_Jsonclick, 0, "Attribute", "", "", "", "", edtavCviaje_Visible, edtavCviaje_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_div_start( context, divSetorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSetorfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsetorfilter_Internalname, "SETOR", "", "", lblLblsetorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170t1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsetor_Internalname, "SETOR", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsetor_Internalname, AV12cSETOR, StringUtil.RTrim( context.localUtil.Format( AV12cSETOR, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsetor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsetor_Visible, edtavCsetor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180t1_client"+"'", TempTags, "", 2, "HLP_Gx00R0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00R0.htm");
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

      protected void START0T2( )
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
            Form.Meta.addItem("description", "Selection List FRUTAPROPIA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0T0( ) ;
      }

      protected void WS0T2( )
      {
         START0T2( ) ;
         EVT0T2( ) ;
      }

      protected void EVT0T2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV28Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A94FRUTAPROPIAFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFRUTAPROPIAFecha_Internalname), 0));
                              A95FRUTAPROPIAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFRUTAPROPIAMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A96FRUTAPROPIAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFRUTAPROPIAAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
                              A5Cod_Area = cgiGet( edtCod_Area_Internalname);
                              A97VIAJE = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVIAJE_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A98SETOR = cgiGet( edtSETOR_Internalname);
                              A99FINCA = cgiGet( edtFINCA_Internalname);
                              A100PROVE_COD = cgiGet( edtPROVE_COD_Internalname);
                              A101DIA = context.localUtil.CToT( cgiGet( edtDIA_Internalname), 0);
                              A102LOTE = cgiGet( edtLOTE_Internalname);
                              A103TAL = cgiGet( edtTAL_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cfrutapropiafecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCFRUTAPROPIAFECHA"), 0) != AV6cFRUTAPROPIAFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cfrutapropiames Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFRUTAPROPIAMES"), ",", ".") != Convert.ToDecimal( AV7cFRUTAPROPIAMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cfrutapropiaano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFRUTAPROPIAANO"), ",", ".") != Convert.ToDecimal( AV8cFRUTAPROPIAAno )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cindicadorescodigo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCINDICADORESCODIGO"), AV9cIndicadoresCodigo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccod_area Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCOD_AREA"), AV10cCod_Area) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cviaje Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVIAJE"), ",", ".") != Convert.ToDecimal( AV11cVIAJE )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csetor Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSETOR"), AV12cSETOR) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210T2 ();
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

      protected void WE0T2( )
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

      protected void PA0T2( )
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
                                        DateTime AV6cFRUTAPROPIAFecha ,
                                        short AV7cFRUTAPROPIAMes ,
                                        short AV8cFRUTAPROPIAAno ,
                                        string AV9cIndicadoresCodigo ,
                                        string AV10cCod_Area ,
                                        long AV11cVIAJE ,
                                        string AV12cSETOR )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_FRUTAPROPIAFECHA", GetSecureSignedToken( "", A94FRUTAPROPIAFecha, context));
         GxWebStd.gx_hidden_field( context, "FRUTAPROPIAFECHA", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_FRUTAPROPIAMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A95FRUTAPROPIAMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "FRUTAPROPIAMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A95FRUTAPROPIAMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_FRUTAPROPIAANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A96FRUTAPROPIAAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "FRUTAPROPIAANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A96FRUTAPROPIAAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGO", A4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "COD_AREA", A5Cod_Area);
         GxWebStd.gx_hidden_field( context, "gxhash_VIAJE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A97VIAJE), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "VIAJE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A97VIAJE), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_SETOR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A98SETOR, "")), context));
         GxWebStd.gx_hidden_field( context, "SETOR", A98SETOR);
         GxWebStd.gx_hidden_field( context, "gxhash_FINCA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A99FINCA, "")), context));
         GxWebStd.gx_hidden_field( context, "FINCA", A99FINCA);
         GxWebStd.gx_hidden_field( context, "gxhash_PROVE_COD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A100PROVE_COD, "")), context));
         GxWebStd.gx_hidden_field( context, "PROVE_COD", A100PROVE_COD);
         GxWebStd.gx_hidden_field( context, "gxhash_DIA", GetSecureSignedToken( "", context.localUtil.Format( A101DIA, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, "DIA", context.localUtil.TToC( A101DIA, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "gxhash_LOTE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A102LOTE, "")), context));
         GxWebStd.gx_hidden_field( context, "LOTE", A102LOTE);
         GxWebStd.gx_hidden_field( context, "gxhash_TAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A103TAL, "")), context));
         GxWebStd.gx_hidden_field( context, "TAL", A103TAL);
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
         RF0T2( ) ;
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

      protected void RF0T2( )
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
            lV9cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV9cIndicadoresCodigo), "%", "");
            lV10cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV10cCod_Area), "%", "");
            lV12cSETOR = StringUtil.Concat( StringUtil.RTrim( AV12cSETOR), "%", "");
            /* Using cursor H000T2 */
            pr_default.execute(0, new Object[] {AV6cFRUTAPROPIAFecha, AV7cFRUTAPROPIAMes, AV8cFRUTAPROPIAAno, lV9cIndicadoresCodigo, lV10cCod_Area, AV11cVIAJE, lV12cSETOR, GXPagingFrom2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A103TAL = H000T2_A103TAL[0];
               A102LOTE = H000T2_A102LOTE[0];
               A101DIA = H000T2_A101DIA[0];
               A100PROVE_COD = H000T2_A100PROVE_COD[0];
               A99FINCA = H000T2_A99FINCA[0];
               A98SETOR = H000T2_A98SETOR[0];
               A97VIAJE = H000T2_A97VIAJE[0];
               A5Cod_Area = H000T2_A5Cod_Area[0];
               A4IndicadoresCodigo = H000T2_A4IndicadoresCodigo[0];
               A96FRUTAPROPIAAno = H000T2_A96FRUTAPROPIAAno[0];
               A95FRUTAPROPIAMes = H000T2_A95FRUTAPROPIAMes[0];
               A94FRUTAPROPIAFecha = H000T2_A94FRUTAPROPIAFecha[0];
               /* Execute user event: Load */
               E200T2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0T0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0T2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_FRUTAPROPIAFECHA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A94FRUTAPROPIAFecha, context));
         GxWebStd.gx_hidden_field( context, "gxhash_FRUTAPROPIAMES"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A95FRUTAPROPIAMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_FRUTAPROPIAANO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A96FRUTAPROPIAAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_VIAJE"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A97VIAJE), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SETOR"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A98SETOR, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_FINCA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A99FINCA, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROVE_COD"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A100PROVE_COD, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_DIA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( A101DIA, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_LOTE"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A102LOTE, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TAL"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A103TAL, "")), context));
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
         lV9cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV9cIndicadoresCodigo), "%", "");
         lV10cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV10cCod_Area), "%", "");
         lV12cSETOR = StringUtil.Concat( StringUtil.RTrim( AV12cSETOR), "%", "");
         /* Using cursor H000T3 */
         pr_default.execute(1, new Object[] {AV6cFRUTAPROPIAFecha, AV7cFRUTAPROPIAMes, AV8cFRUTAPROPIAAno, lV9cIndicadoresCodigo, lV10cCod_Area, AV11cVIAJE, lV12cSETOR});
         GRID1_nRecordCount = H000T3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFRUTAPROPIAFecha, AV7cFRUTAPROPIAMes, AV8cFRUTAPROPIAAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cVIAJE, AV12cSETOR) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFRUTAPROPIAFecha, AV7cFRUTAPROPIAMes, AV8cFRUTAPROPIAAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cVIAJE, AV12cSETOR) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFRUTAPROPIAFecha, AV7cFRUTAPROPIAMes, AV8cFRUTAPROPIAAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cVIAJE, AV12cSETOR) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFRUTAPROPIAFecha, AV7cFRUTAPROPIAMes, AV8cFRUTAPROPIAAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cVIAJE, AV12cSETOR) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFRUTAPROPIAFecha, AV7cFRUTAPROPIAMes, AV8cFRUTAPROPIAAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cVIAJE, AV12cSETOR) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190T2 ();
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
            if ( context.localUtil.VCDate( cgiGet( edtavCfrutapropiafecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FRUTAPROPIAFecha"}), 1, "vCFRUTAPROPIAFECHA");
               GX_FocusControl = edtavCfrutapropiafecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cFRUTAPROPIAFecha = DateTime.MinValue;
               AssignAttri("", false, "AV6cFRUTAPROPIAFecha", context.localUtil.Format(AV6cFRUTAPROPIAFecha, "99/99/99"));
            }
            else
            {
               AV6cFRUTAPROPIAFecha = context.localUtil.CToD( cgiGet( edtavCfrutapropiafecha_Internalname), 2);
               AssignAttri("", false, "AV6cFRUTAPROPIAFecha", context.localUtil.Format(AV6cFRUTAPROPIAFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCfrutapropiames_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCfrutapropiames_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCFRUTAPROPIAMES");
               GX_FocusControl = edtavCfrutapropiames_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cFRUTAPROPIAMes = 0;
               AssignAttri("", false, "AV7cFRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(AV7cFRUTAPROPIAMes), 4, 0));
            }
            else
            {
               AV7cFRUTAPROPIAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCfrutapropiames_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cFRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(AV7cFRUTAPROPIAMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCfrutapropiaano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCfrutapropiaano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCFRUTAPROPIAANO");
               GX_FocusControl = edtavCfrutapropiaano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cFRUTAPROPIAAno = 0;
               AssignAttri("", false, "AV8cFRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(AV8cFRUTAPROPIAAno), 4, 0));
            }
            else
            {
               AV8cFRUTAPROPIAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCfrutapropiaano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cFRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(AV8cFRUTAPROPIAAno), 4, 0));
            }
            AV9cIndicadoresCodigo = cgiGet( edtavCindicadorescodigo_Internalname);
            AssignAttri("", false, "AV9cIndicadoresCodigo", AV9cIndicadoresCodigo);
            AV10cCod_Area = cgiGet( edtavCcod_area_Internalname);
            AssignAttri("", false, "AV10cCod_Area", AV10cCod_Area);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCviaje_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCviaje_Internalname), ",", ".") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCVIAJE");
               GX_FocusControl = edtavCviaje_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cVIAJE = 0;
               AssignAttri("", false, "AV11cVIAJE", StringUtil.LTrimStr( (decimal)(AV11cVIAJE), 12, 0));
            }
            else
            {
               AV11cVIAJE = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCviaje_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cVIAJE", StringUtil.LTrimStr( (decimal)(AV11cVIAJE), 12, 0));
            }
            AV12cSETOR = cgiGet( edtavCsetor_Internalname);
            AssignAttri("", false, "AV12cSETOR", AV12cSETOR);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCFRUTAPROPIAFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV6cFRUTAPROPIAFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFRUTAPROPIAMES"), ",", ".") != Convert.ToDecimal( AV7cFRUTAPROPIAMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFRUTAPROPIAANO"), ",", ".") != Convert.ToDecimal( AV8cFRUTAPROPIAAno )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCINDICADORESCODIGO"), AV9cIndicadoresCodigo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCOD_AREA"), AV10cCod_Area) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVIAJE"), ",", ".") != Convert.ToDecimal( AV11cVIAJE )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSETOR"), AV12cSETOR) != 0 )
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
         E190T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190T2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "FRUTAPROPIA", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV25ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200T2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV28Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E210T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210T2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pFRUTAPROPIAFecha = A94FRUTAPROPIAFecha;
         AssignAttri("", false, "AV13pFRUTAPROPIAFecha", context.localUtil.Format(AV13pFRUTAPROPIAFecha, "99/99/99"));
         AV14pFRUTAPROPIAMes = A95FRUTAPROPIAMes;
         AssignAttri("", false, "AV14pFRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(AV14pFRUTAPROPIAMes), 4, 0));
         AV15pFRUTAPROPIAAno = A96FRUTAPROPIAAno;
         AssignAttri("", false, "AV15pFRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(AV15pFRUTAPROPIAAno), 4, 0));
         AV16pIndicadoresCodigo = A4IndicadoresCodigo;
         AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
         AV17pCod_Area = A5Cod_Area;
         AssignAttri("", false, "AV17pCod_Area", AV17pCod_Area);
         AV18pVIAJE = A97VIAJE;
         AssignAttri("", false, "AV18pVIAJE", StringUtil.LTrimStr( (decimal)(AV18pVIAJE), 12, 0));
         AV19pSETOR = A98SETOR;
         AssignAttri("", false, "AV19pSETOR", AV19pSETOR);
         AV20pFINCA = A99FINCA;
         AssignAttri("", false, "AV20pFINCA", AV20pFINCA);
         AV21pPROVE_COD = A100PROVE_COD;
         AssignAttri("", false, "AV21pPROVE_COD", AV21pPROVE_COD);
         AV22pDIA = A101DIA;
         AssignAttri("", false, "AV22pDIA", context.localUtil.TToC( AV22pDIA, 8, 5, 0, 3, "/", ":", " "));
         AV23pLOTE = A102LOTE;
         AssignAttri("", false, "AV23pLOTE", AV23pLOTE);
         AV24pTAL = A103TAL;
         AssignAttri("", false, "AV24pTAL", AV24pTAL);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV13pFRUTAPROPIAFecha, "99/99/99"),(short)AV14pFRUTAPROPIAMes,(short)AV15pFRUTAPROPIAAno,(string)AV16pIndicadoresCodigo,(string)AV17pCod_Area,(long)AV18pVIAJE,(string)AV19pSETOR,(string)AV20pFINCA,(string)AV21pPROVE_COD,context.localUtil.Format( AV22pDIA, "99/99/99 99:99"),(string)AV23pLOTE,(string)AV24pTAL});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pFRUTAPROPIAFecha","AV14pFRUTAPROPIAMes","AV15pFRUTAPROPIAAno","AV16pIndicadoresCodigo","AV17pCod_Area","AV18pVIAJE","AV19pSETOR","AV20pFINCA","AV21pPROVE_COD","AV22pDIA","AV23pLOTE","AV24pTAL"});
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
         AV13pFRUTAPROPIAFecha = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV13pFRUTAPROPIAFecha", context.localUtil.Format(AV13pFRUTAPROPIAFecha, "99/99/99"));
         AV14pFRUTAPROPIAMes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV14pFRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(AV14pFRUTAPROPIAMes), 4, 0));
         AV15pFRUTAPROPIAAno = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV15pFRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(AV15pFRUTAPROPIAAno), 4, 0));
         AV16pIndicadoresCodigo = (string)getParm(obj,3);
         AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
         AV17pCod_Area = (string)getParm(obj,4);
         AssignAttri("", false, "AV17pCod_Area", AV17pCod_Area);
         AV18pVIAJE = Convert.ToInt64(getParm(obj,5));
         AssignAttri("", false, "AV18pVIAJE", StringUtil.LTrimStr( (decimal)(AV18pVIAJE), 12, 0));
         AV19pSETOR = (string)getParm(obj,6);
         AssignAttri("", false, "AV19pSETOR", AV19pSETOR);
         AV20pFINCA = (string)getParm(obj,7);
         AssignAttri("", false, "AV20pFINCA", AV20pFINCA);
         AV21pPROVE_COD = (string)getParm(obj,8);
         AssignAttri("", false, "AV21pPROVE_COD", AV21pPROVE_COD);
         AV22pDIA = (DateTime)getParm(obj,9);
         AssignAttri("", false, "AV22pDIA", context.localUtil.TToC( AV22pDIA, 8, 5, 0, 3, "/", ":", " "));
         AV23pLOTE = (string)getParm(obj,10);
         AssignAttri("", false, "AV23pLOTE", AV23pLOTE);
         AV24pTAL = (string)getParm(obj,11);
         AssignAttri("", false, "AV24pTAL", AV24pTAL);
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
         PA0T2( ) ;
         WS0T2( ) ;
         WE0T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231024468", true, true);
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
         context.AddJavascriptSource("gx00r0.js", "?20247231024469", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtFRUTAPROPIAFecha_Internalname = "FRUTAPROPIAFECHA_"+sGXsfl_84_idx;
         edtFRUTAPROPIAMes_Internalname = "FRUTAPROPIAMES_"+sGXsfl_84_idx;
         edtFRUTAPROPIAAno_Internalname = "FRUTAPROPIAANO_"+sGXsfl_84_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_idx;
         edtVIAJE_Internalname = "VIAJE_"+sGXsfl_84_idx;
         edtSETOR_Internalname = "SETOR_"+sGXsfl_84_idx;
         edtFINCA_Internalname = "FINCA_"+sGXsfl_84_idx;
         edtPROVE_COD_Internalname = "PROVE_COD_"+sGXsfl_84_idx;
         edtDIA_Internalname = "DIA_"+sGXsfl_84_idx;
         edtLOTE_Internalname = "LOTE_"+sGXsfl_84_idx;
         edtTAL_Internalname = "TAL_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtFRUTAPROPIAFecha_Internalname = "FRUTAPROPIAFECHA_"+sGXsfl_84_fel_idx;
         edtFRUTAPROPIAMes_Internalname = "FRUTAPROPIAMES_"+sGXsfl_84_fel_idx;
         edtFRUTAPROPIAAno_Internalname = "FRUTAPROPIAANO_"+sGXsfl_84_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_fel_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_fel_idx;
         edtVIAJE_Internalname = "VIAJE_"+sGXsfl_84_fel_idx;
         edtSETOR_Internalname = "SETOR_"+sGXsfl_84_fel_idx;
         edtFINCA_Internalname = "FINCA_"+sGXsfl_84_fel_idx;
         edtPROVE_COD_Internalname = "PROVE_COD_"+sGXsfl_84_fel_idx;
         edtDIA_Internalname = "DIA_"+sGXsfl_84_fel_idx;
         edtLOTE_Internalname = "LOTE_"+sGXsfl_84_fel_idx;
         edtTAL_Internalname = "TAL_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0T0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A95FRUTAPROPIAMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A96FRUTAPROPIAAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A97VIAJE), 12, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A98SETOR)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A99FINCA)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A100PROVE_COD)+"'"+", "+"'"+GXUtil.EncodeJSConstant( context.localUtil.TToC( A101DIA, 10, 8, 0, 3, "/", ":", " "))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A102LOTE)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A103TAL)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV28Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV28Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFRUTAPROPIAFecha_Internalname,context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"),context.localUtil.Format( A94FRUTAPROPIAFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFRUTAPROPIAFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFRUTAPROPIAMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A95FRUTAPROPIAMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A95FRUTAPROPIAMes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFRUTAPROPIAMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFRUTAPROPIAAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A96FRUTAPROPIAAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A96FRUTAPROPIAAno), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFRUTAPROPIAAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCod_Area_Internalname,(string)A5Cod_Area,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCod_Area_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVIAJE_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A97VIAJE), 12, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A97VIAJE), "ZZZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVIAJE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSETOR_Internalname,(string)A98SETOR,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSETOR_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFINCA_Internalname,(string)A99FINCA,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFINCA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPROVE_COD_Internalname,(string)A100PROVE_COD,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPROVE_COD_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDIA_Internalname,context.localUtil.TToC( A101DIA, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A101DIA, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDIA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLOTE_Internalname,(string)A102LOTE,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLOTE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTAL_Internalname,(string)A103TAL,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTAL_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0T2( ) ;
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
            context.SendWebValue( "FRUTAPROPIAFecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "FRUTAPROPIAMes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "FRUTAPROPIAAno") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Codigo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cod_Area") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "VIAJE") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "SETOR") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "FINCA") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "PROVE_COD") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "DIA") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "LOTE") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "TAL") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A95FRUTAPROPIAMes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A96FRUTAPROPIAAno), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A4IndicadoresCodigo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A5Cod_Area));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A97VIAJE), 12, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A98SETOR));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A99FINCA));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A100PROVE_COD));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A101DIA, 10, 8, 0, 3, "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A102LOTE));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A103TAL));
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
         lblLblfrutapropiafechafilter_Internalname = "LBLFRUTAPROPIAFECHAFILTER";
         edtavCfrutapropiafecha_Internalname = "vCFRUTAPROPIAFECHA";
         divFrutapropiafechafiltercontainer_Internalname = "FRUTAPROPIAFECHAFILTERCONTAINER";
         lblLblfrutapropiamesfilter_Internalname = "LBLFRUTAPROPIAMESFILTER";
         edtavCfrutapropiames_Internalname = "vCFRUTAPROPIAMES";
         divFrutapropiamesfiltercontainer_Internalname = "FRUTAPROPIAMESFILTERCONTAINER";
         lblLblfrutapropiaanofilter_Internalname = "LBLFRUTAPROPIAANOFILTER";
         edtavCfrutapropiaano_Internalname = "vCFRUTAPROPIAANO";
         divFrutapropiaanofiltercontainer_Internalname = "FRUTAPROPIAANOFILTERCONTAINER";
         lblLblindicadorescodigofilter_Internalname = "LBLINDICADORESCODIGOFILTER";
         edtavCindicadorescodigo_Internalname = "vCINDICADORESCODIGO";
         divIndicadorescodigofiltercontainer_Internalname = "INDICADORESCODIGOFILTERCONTAINER";
         lblLblcod_areafilter_Internalname = "LBLCOD_AREAFILTER";
         edtavCcod_area_Internalname = "vCCOD_AREA";
         divCod_areafiltercontainer_Internalname = "COD_AREAFILTERCONTAINER";
         lblLblviajefilter_Internalname = "LBLVIAJEFILTER";
         edtavCviaje_Internalname = "vCVIAJE";
         divViajefiltercontainer_Internalname = "VIAJEFILTERCONTAINER";
         lblLblsetorfilter_Internalname = "LBLSETORFILTER";
         edtavCsetor_Internalname = "vCSETOR";
         divSetorfiltercontainer_Internalname = "SETORFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtFRUTAPROPIAFecha_Internalname = "FRUTAPROPIAFECHA";
         edtFRUTAPROPIAMes_Internalname = "FRUTAPROPIAMES";
         edtFRUTAPROPIAAno_Internalname = "FRUTAPROPIAANO";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtCod_Area_Internalname = "COD_AREA";
         edtVIAJE_Internalname = "VIAJE";
         edtSETOR_Internalname = "SETOR";
         edtFINCA_Internalname = "FINCA";
         edtPROVE_COD_Internalname = "PROVE_COD";
         edtDIA_Internalname = "DIA";
         edtLOTE_Internalname = "LOTE";
         edtTAL_Internalname = "TAL";
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
         edtTAL_Jsonclick = "";
         edtLOTE_Jsonclick = "";
         edtDIA_Jsonclick = "";
         edtPROVE_COD_Jsonclick = "";
         edtFINCA_Jsonclick = "";
         edtSETOR_Jsonclick = "";
         edtVIAJE_Jsonclick = "";
         edtCod_Area_Jsonclick = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtFRUTAPROPIAAno_Jsonclick = "";
         edtFRUTAPROPIAMes_Jsonclick = "";
         edtFRUTAPROPIAFecha_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCsetor_Jsonclick = "";
         edtavCsetor_Enabled = 1;
         edtavCsetor_Visible = 1;
         edtavCviaje_Jsonclick = "";
         edtavCviaje_Enabled = 1;
         edtavCviaje_Visible = 1;
         edtavCcod_area_Jsonclick = "";
         edtavCcod_area_Enabled = 1;
         edtavCcod_area_Visible = 1;
         edtavCindicadorescodigo_Jsonclick = "";
         edtavCindicadorescodigo_Enabled = 1;
         edtavCindicadorescodigo_Visible = 1;
         edtavCfrutapropiaano_Jsonclick = "";
         edtavCfrutapropiaano_Enabled = 1;
         edtavCfrutapropiaano_Visible = 1;
         edtavCfrutapropiames_Jsonclick = "";
         edtavCfrutapropiames_Enabled = 1;
         edtavCfrutapropiames_Visible = 1;
         edtavCfrutapropiafecha_Jsonclick = "";
         edtavCfrutapropiafecha_Enabled = 1;
         divSetorfiltercontainer_Class = "AdvancedContainerItem";
         divViajefiltercontainer_Class = "AdvancedContainerItem";
         divCod_areafiltercontainer_Class = "AdvancedContainerItem";
         divIndicadorescodigofiltercontainer_Class = "AdvancedContainerItem";
         divFrutapropiaanofiltercontainer_Class = "AdvancedContainerItem";
         divFrutapropiamesfiltercontainer_Class = "AdvancedContainerItem";
         divFrutapropiafechafiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List FRUTAPROPIA";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cFRUTAPROPIAFecha',fld:'vCFRUTAPROPIAFECHA',pic:''},{av:'AV7cFRUTAPROPIAMes',fld:'vCFRUTAPROPIAMES',pic:'ZZZ9'},{av:'AV8cFRUTAPROPIAAno',fld:'vCFRUTAPROPIAANO',pic:'ZZZ9'},{av:'AV9cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV10cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV11cVIAJE',fld:'vCVIAJE',pic:'ZZZZZZZZZZZ9'},{av:'AV12cSETOR',fld:'vCSETOR',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180T1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLFRUTAPROPIAFECHAFILTER.CLICK","{handler:'E110T1',iparms:[{av:'divFrutapropiafechafiltercontainer_Class',ctrl:'FRUTAPROPIAFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLFRUTAPROPIAFECHAFILTER.CLICK",",oparms:[{av:'divFrutapropiafechafiltercontainer_Class',ctrl:'FRUTAPROPIAFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLFRUTAPROPIAMESFILTER.CLICK","{handler:'E120T1',iparms:[{av:'divFrutapropiamesfiltercontainer_Class',ctrl:'FRUTAPROPIAMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLFRUTAPROPIAMESFILTER.CLICK",",oparms:[{av:'divFrutapropiamesfiltercontainer_Class',ctrl:'FRUTAPROPIAMESFILTERCONTAINER',prop:'Class'},{av:'edtavCfrutapropiames_Visible',ctrl:'vCFRUTAPROPIAMES',prop:'Visible'}]}");
         setEventMetadata("LBLFRUTAPROPIAANOFILTER.CLICK","{handler:'E130T1',iparms:[{av:'divFrutapropiaanofiltercontainer_Class',ctrl:'FRUTAPROPIAANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLFRUTAPROPIAANOFILTER.CLICK",",oparms:[{av:'divFrutapropiaanofiltercontainer_Class',ctrl:'FRUTAPROPIAANOFILTERCONTAINER',prop:'Class'},{av:'edtavCfrutapropiaano_Visible',ctrl:'vCFRUTAPROPIAANO',prop:'Visible'}]}");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK","{handler:'E140T1',iparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK",",oparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCindicadorescodigo_Visible',ctrl:'vCINDICADORESCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK","{handler:'E150T1',iparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK",",oparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'},{av:'edtavCcod_area_Visible',ctrl:'vCCOD_AREA',prop:'Visible'}]}");
         setEventMetadata("LBLVIAJEFILTER.CLICK","{handler:'E160T1',iparms:[{av:'divViajefiltercontainer_Class',ctrl:'VIAJEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLVIAJEFILTER.CLICK",",oparms:[{av:'divViajefiltercontainer_Class',ctrl:'VIAJEFILTERCONTAINER',prop:'Class'},{av:'edtavCviaje_Visible',ctrl:'vCVIAJE',prop:'Visible'}]}");
         setEventMetadata("LBLSETORFILTER.CLICK","{handler:'E170T1',iparms:[{av:'divSetorfiltercontainer_Class',ctrl:'SETORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSETORFILTER.CLICK",",oparms:[{av:'divSetorfiltercontainer_Class',ctrl:'SETORFILTERCONTAINER',prop:'Class'},{av:'edtavCsetor_Visible',ctrl:'vCSETOR',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E210T2',iparms:[{av:'A94FRUTAPROPIAFecha',fld:'FRUTAPROPIAFECHA',pic:'',hsh:true},{av:'A95FRUTAPROPIAMes',fld:'FRUTAPROPIAMES',pic:'ZZZ9',hsh:true},{av:'A96FRUTAPROPIAAno',fld:'FRUTAPROPIAANO',pic:'ZZZ9',hsh:true},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:'',hsh:true},{av:'A5Cod_Area',fld:'COD_AREA',pic:'',hsh:true},{av:'A97VIAJE',fld:'VIAJE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'A98SETOR',fld:'SETOR',pic:'',hsh:true},{av:'A99FINCA',fld:'FINCA',pic:'',hsh:true},{av:'A100PROVE_COD',fld:'PROVE_COD',pic:'',hsh:true},{av:'A101DIA',fld:'DIA',pic:'99/99/99 99:99',hsh:true},{av:'A102LOTE',fld:'LOTE',pic:'',hsh:true},{av:'A103TAL',fld:'TAL',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pFRUTAPROPIAFecha',fld:'vPFRUTAPROPIAFECHA',pic:''},{av:'AV14pFRUTAPROPIAMes',fld:'vPFRUTAPROPIAMES',pic:'ZZZ9'},{av:'AV15pFRUTAPROPIAAno',fld:'vPFRUTAPROPIAANO',pic:'ZZZ9'},{av:'AV16pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV17pCod_Area',fld:'vPCOD_AREA',pic:''},{av:'AV18pVIAJE',fld:'vPVIAJE',pic:'ZZZZZZZZZZZ9'},{av:'AV19pSETOR',fld:'vPSETOR',pic:''},{av:'AV20pFINCA',fld:'vPFINCA',pic:''},{av:'AV21pPROVE_COD',fld:'vPPROVE_COD',pic:''},{av:'AV22pDIA',fld:'vPDIA',pic:'99/99/99 99:99'},{av:'AV23pLOTE',fld:'vPLOTE',pic:''},{av:'AV24pTAL',fld:'vPTAL',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cFRUTAPROPIAFecha',fld:'vCFRUTAPROPIAFECHA',pic:''},{av:'AV7cFRUTAPROPIAMes',fld:'vCFRUTAPROPIAMES',pic:'ZZZ9'},{av:'AV8cFRUTAPROPIAAno',fld:'vCFRUTAPROPIAANO',pic:'ZZZ9'},{av:'AV9cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV10cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV11cVIAJE',fld:'vCVIAJE',pic:'ZZZZZZZZZZZ9'},{av:'AV12cSETOR',fld:'vCSETOR',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cFRUTAPROPIAFecha',fld:'vCFRUTAPROPIAFECHA',pic:''},{av:'AV7cFRUTAPROPIAMes',fld:'vCFRUTAPROPIAMES',pic:'ZZZ9'},{av:'AV8cFRUTAPROPIAAno',fld:'vCFRUTAPROPIAANO',pic:'ZZZ9'},{av:'AV9cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV10cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV11cVIAJE',fld:'vCVIAJE',pic:'ZZZZZZZZZZZ9'},{av:'AV12cSETOR',fld:'vCSETOR',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cFRUTAPROPIAFecha',fld:'vCFRUTAPROPIAFECHA',pic:''},{av:'AV7cFRUTAPROPIAMes',fld:'vCFRUTAPROPIAMES',pic:'ZZZ9'},{av:'AV8cFRUTAPROPIAAno',fld:'vCFRUTAPROPIAANO',pic:'ZZZ9'},{av:'AV9cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV10cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV11cVIAJE',fld:'vCVIAJE',pic:'ZZZZZZZZZZZ9'},{av:'AV12cSETOR',fld:'vCSETOR',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cFRUTAPROPIAFecha',fld:'vCFRUTAPROPIAFECHA',pic:''},{av:'AV7cFRUTAPROPIAMes',fld:'vCFRUTAPROPIAMES',pic:'ZZZ9'},{av:'AV8cFRUTAPROPIAAno',fld:'vCFRUTAPROPIAANO',pic:'ZZZ9'},{av:'AV9cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV10cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV11cVIAJE',fld:'vCVIAJE',pic:'ZZZZZZZZZZZ9'},{av:'AV12cSETOR',fld:'vCSETOR',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CFRUTAPROPIAFECHA","{handler:'Validv_Cfrutapropiafecha',iparms:[]");
         setEventMetadata("VALIDV_CFRUTAPROPIAFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tal',iparms:[]");
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
         AV13pFRUTAPROPIAFecha = DateTime.MinValue;
         AV16pIndicadoresCodigo = "";
         AV17pCod_Area = "";
         AV19pSETOR = "";
         AV20pFINCA = "";
         AV21pPROVE_COD = "";
         AV22pDIA = (DateTime)(DateTime.MinValue);
         AV23pLOTE = "";
         AV24pTAL = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cFRUTAPROPIAFecha = DateTime.MinValue;
         AV9cIndicadoresCodigo = "";
         AV10cCod_Area = "";
         AV12cSETOR = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblfrutapropiafechafilter_Jsonclick = "";
         TempTags = "";
         lblLblfrutapropiamesfilter_Jsonclick = "";
         lblLblfrutapropiaanofilter_Jsonclick = "";
         lblLblindicadorescodigofilter_Jsonclick = "";
         lblLblcod_areafilter_Jsonclick = "";
         lblLblviajefilter_Jsonclick = "";
         lblLblsetorfilter_Jsonclick = "";
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
         AV28Linkselection_GXI = "";
         A94FRUTAPROPIAFecha = DateTime.MinValue;
         A4IndicadoresCodigo = "";
         A5Cod_Area = "";
         A98SETOR = "";
         A99FINCA = "";
         A100PROVE_COD = "";
         A101DIA = (DateTime)(DateTime.MinValue);
         A102LOTE = "";
         A103TAL = "";
         scmdbuf = "";
         lV9cIndicadoresCodigo = "";
         lV10cCod_Area = "";
         lV12cSETOR = "";
         H000T2_A103TAL = new string[] {""} ;
         H000T2_A102LOTE = new string[] {""} ;
         H000T2_A101DIA = new DateTime[] {DateTime.MinValue} ;
         H000T2_A100PROVE_COD = new string[] {""} ;
         H000T2_A99FINCA = new string[] {""} ;
         H000T2_A98SETOR = new string[] {""} ;
         H000T2_A97VIAJE = new long[1] ;
         H000T2_A5Cod_Area = new string[] {""} ;
         H000T2_A4IndicadoresCodigo = new string[] {""} ;
         H000T2_A96FRUTAPROPIAAno = new short[1] ;
         H000T2_A95FRUTAPROPIAMes = new short[1] ;
         H000T2_A94FRUTAPROPIAFecha = new DateTime[] {DateTime.MinValue} ;
         H000T3_AGRID1_nRecordCount = new long[1] ;
         AV25ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00r0__default(),
            new Object[][] {
                new Object[] {
               H000T2_A103TAL, H000T2_A102LOTE, H000T2_A101DIA, H000T2_A100PROVE_COD, H000T2_A99FINCA, H000T2_A98SETOR, H000T2_A97VIAJE, H000T2_A5Cod_Area, H000T2_A4IndicadoresCodigo, H000T2_A96FRUTAPROPIAAno,
               H000T2_A95FRUTAPROPIAMes, H000T2_A94FRUTAPROPIAFecha
               }
               , new Object[] {
               H000T3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14pFRUTAPROPIAMes ;
      private short AV15pFRUTAPROPIAAno ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cFRUTAPROPIAMes ;
      private short AV8cFRUTAPROPIAAno ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A95FRUTAPROPIAMes ;
      private short A96FRUTAPROPIAAno ;
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
      private int edtavCfrutapropiafecha_Enabled ;
      private int edtavCfrutapropiames_Enabled ;
      private int edtavCfrutapropiames_Visible ;
      private int edtavCfrutapropiaano_Enabled ;
      private int edtavCfrutapropiaano_Visible ;
      private int edtavCindicadorescodigo_Visible ;
      private int edtavCindicadorescodigo_Enabled ;
      private int edtavCcod_area_Visible ;
      private int edtavCcod_area_Enabled ;
      private int edtavCviaje_Enabled ;
      private int edtavCviaje_Visible ;
      private int edtavCsetor_Visible ;
      private int edtavCsetor_Enabled ;
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
      private long AV18pVIAJE ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV11cVIAJE ;
      private long A97VIAJE ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divFrutapropiafechafiltercontainer_Class ;
      private string divFrutapropiamesfiltercontainer_Class ;
      private string divFrutapropiaanofiltercontainer_Class ;
      private string divIndicadorescodigofiltercontainer_Class ;
      private string divCod_areafiltercontainer_Class ;
      private string divViajefiltercontainer_Class ;
      private string divSetorfiltercontainer_Class ;
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
      private string divFrutapropiafechafiltercontainer_Internalname ;
      private string lblLblfrutapropiafechafilter_Internalname ;
      private string lblLblfrutapropiafechafilter_Jsonclick ;
      private string edtavCfrutapropiafecha_Internalname ;
      private string TempTags ;
      private string edtavCfrutapropiafecha_Jsonclick ;
      private string divFrutapropiamesfiltercontainer_Internalname ;
      private string lblLblfrutapropiamesfilter_Internalname ;
      private string lblLblfrutapropiamesfilter_Jsonclick ;
      private string edtavCfrutapropiames_Internalname ;
      private string edtavCfrutapropiames_Jsonclick ;
      private string divFrutapropiaanofiltercontainer_Internalname ;
      private string lblLblfrutapropiaanofilter_Internalname ;
      private string lblLblfrutapropiaanofilter_Jsonclick ;
      private string edtavCfrutapropiaano_Internalname ;
      private string edtavCfrutapropiaano_Jsonclick ;
      private string divIndicadorescodigofiltercontainer_Internalname ;
      private string lblLblindicadorescodigofilter_Internalname ;
      private string lblLblindicadorescodigofilter_Jsonclick ;
      private string edtavCindicadorescodigo_Internalname ;
      private string edtavCindicadorescodigo_Jsonclick ;
      private string divCod_areafiltercontainer_Internalname ;
      private string lblLblcod_areafilter_Internalname ;
      private string lblLblcod_areafilter_Jsonclick ;
      private string edtavCcod_area_Internalname ;
      private string edtavCcod_area_Jsonclick ;
      private string divViajefiltercontainer_Internalname ;
      private string lblLblviajefilter_Internalname ;
      private string lblLblviajefilter_Jsonclick ;
      private string edtavCviaje_Internalname ;
      private string edtavCviaje_Jsonclick ;
      private string divSetorfiltercontainer_Internalname ;
      private string lblLblsetorfilter_Internalname ;
      private string lblLblsetorfilter_Jsonclick ;
      private string edtavCsetor_Internalname ;
      private string edtavCsetor_Jsonclick ;
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
      private string edtFRUTAPROPIAFecha_Internalname ;
      private string edtFRUTAPROPIAMes_Internalname ;
      private string edtFRUTAPROPIAAno_Internalname ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtCod_Area_Internalname ;
      private string edtVIAJE_Internalname ;
      private string edtSETOR_Internalname ;
      private string edtFINCA_Internalname ;
      private string edtPROVE_COD_Internalname ;
      private string edtDIA_Internalname ;
      private string edtLOTE_Internalname ;
      private string edtTAL_Internalname ;
      private string scmdbuf ;
      private string AV25ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtFRUTAPROPIAFecha_Jsonclick ;
      private string edtFRUTAPROPIAMes_Jsonclick ;
      private string edtFRUTAPROPIAAno_Jsonclick ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string edtCod_Area_Jsonclick ;
      private string edtVIAJE_Jsonclick ;
      private string edtSETOR_Jsonclick ;
      private string edtFINCA_Jsonclick ;
      private string edtPROVE_COD_Jsonclick ;
      private string edtDIA_Jsonclick ;
      private string edtLOTE_Jsonclick ;
      private string edtTAL_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV22pDIA ;
      private DateTime A101DIA ;
      private DateTime AV13pFRUTAPROPIAFecha ;
      private DateTime AV6cFRUTAPROPIAFecha ;
      private DateTime A94FRUTAPROPIAFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV16pIndicadoresCodigo ;
      private string AV17pCod_Area ;
      private string AV19pSETOR ;
      private string AV20pFINCA ;
      private string AV21pPROVE_COD ;
      private string AV23pLOTE ;
      private string AV24pTAL ;
      private string AV9cIndicadoresCodigo ;
      private string AV10cCod_Area ;
      private string AV12cSETOR ;
      private string AV28Linkselection_GXI ;
      private string A4IndicadoresCodigo ;
      private string A5Cod_Area ;
      private string A98SETOR ;
      private string A99FINCA ;
      private string A100PROVE_COD ;
      private string A102LOTE ;
      private string A103TAL ;
      private string lV9cIndicadoresCodigo ;
      private string lV10cCod_Area ;
      private string lV12cSETOR ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000T2_A103TAL ;
      private string[] H000T2_A102LOTE ;
      private DateTime[] H000T2_A101DIA ;
      private string[] H000T2_A100PROVE_COD ;
      private string[] H000T2_A99FINCA ;
      private string[] H000T2_A98SETOR ;
      private long[] H000T2_A97VIAJE ;
      private string[] H000T2_A5Cod_Area ;
      private string[] H000T2_A4IndicadoresCodigo ;
      private short[] H000T2_A96FRUTAPROPIAAno ;
      private short[] H000T2_A95FRUTAPROPIAMes ;
      private DateTime[] H000T2_A94FRUTAPROPIAFecha ;
      private long[] H000T3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP0_pFRUTAPROPIAFecha ;
      private short aP1_pFRUTAPROPIAMes ;
      private short aP2_pFRUTAPROPIAAno ;
      private string aP3_pIndicadoresCodigo ;
      private string aP4_pCod_Area ;
      private long aP5_pVIAJE ;
      private string aP6_pSETOR ;
      private string aP7_pFINCA ;
      private string aP8_pPROVE_COD ;
      private DateTime aP9_pDIA ;
      private string aP10_pLOTE ;
      private string aP11_pTAL ;
      private GXWebForm Form ;
   }

   public class gx00r0__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000T2;
          prmH000T2 = new Object[] {
          new ParDef("@AV6cFRUTAPROPIAFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cFRUTAPROPIAMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cFRUTAPROPIAAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cVIAJE",GXType.Decimal,12,0) ,
          new ParDef("@lV12cSETOR",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000T3;
          prmH000T3 = new Object[] {
          new ParDef("@AV6cFRUTAPROPIAFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cFRUTAPROPIAMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cFRUTAPROPIAAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cVIAJE",GXType.Decimal,12,0) ,
          new ParDef("@lV12cSETOR",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000T2", "SELECT [TAL], [LOTE], [DIA], [PROVE_COD], [FINCA], [SETOR], [VIAJE], [Cod_Area], [IndicadoresCodigo], [FRUTAPROPIAAno], [FRUTAPROPIAMes], [FRUTAPROPIAFecha] FROM [FRUTAPROPIA] WHERE ([FRUTAPROPIAFecha] >= @AV6cFRUTAPROPIAFecha and [FRUTAPROPIAMes] >= @AV7cFRUTAPROPIAMes and [FRUTAPROPIAAno] >= @AV8cFRUTAPROPIAAno) AND ([IndicadoresCodigo] like @lV9cIndicadoresCodigo) AND ([Cod_Area] like @lV10cCod_Area) AND ([VIAJE] >= @AV11cVIAJE) AND ([SETOR] like @lV12cSETOR) ORDER BY [FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [IndicadoresCodigo], [Cod_Area], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000T2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000T3", "SELECT COUNT(*) FROM [FRUTAPROPIA] WHERE ([FRUTAPROPIAFecha] >= @AV6cFRUTAPROPIAFecha and [FRUTAPROPIAMes] >= @AV7cFRUTAPROPIAMes and [FRUTAPROPIAAno] >= @AV8cFRUTAPROPIAAno) AND ([IndicadoresCodigo] like @lV9cIndicadoresCodigo) AND ([Cod_Area] like @lV10cCod_Area) AND ([VIAJE] >= @AV11cVIAJE) AND ([SETOR] like @lV12cSETOR) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000T3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
