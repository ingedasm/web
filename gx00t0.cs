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
   public class gx00t0 : GXDataArea
   {
      public gx00t0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx00t0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out DateTime aP0_pHATRABAJADORESFecha ,
                           out short aP1_pHATRABAJADORESMes ,
                           out short aP2_pHATRABAJADORESAno ,
                           out string aP3_pCod_Area ,
                           out string aP4_pIndicadoresCodigo )
      {
         this.AV13pHATRABAJADORESFecha = DateTime.MinValue ;
         this.AV14pHATRABAJADORESMes = 0 ;
         this.AV15pHATRABAJADORESAno = 0 ;
         this.AV16pCod_Area = "" ;
         this.AV17pIndicadoresCodigo = "" ;
         executePrivate();
         aP0_pHATRABAJADORESFecha=this.AV13pHATRABAJADORESFecha;
         aP1_pHATRABAJADORESMes=this.AV14pHATRABAJADORESMes;
         aP2_pHATRABAJADORESAno=this.AV15pHATRABAJADORESAno;
         aP3_pCod_Area=this.AV16pCod_Area;
         aP4_pIndicadoresCodigo=this.AV17pIndicadoresCodigo;
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
            gxfirstwebparm = GetFirstPar( "pHATRABAJADORESFecha");
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
               gxfirstwebparm = GetFirstPar( "pHATRABAJADORESFecha");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pHATRABAJADORESFecha");
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
               AV13pHATRABAJADORESFecha = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV13pHATRABAJADORESFecha", context.localUtil.Format(AV13pHATRABAJADORESFecha, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pHATRABAJADORESMes = (short)(Math.Round(NumberUtil.Val( GetPar( "pHATRABAJADORESMes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pHATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(AV14pHATRABAJADORESMes), 4, 0));
                  AV15pHATRABAJADORESAno = (short)(Math.Round(NumberUtil.Val( GetPar( "pHATRABAJADORESAno"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15pHATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(AV15pHATRABAJADORESAno), 4, 0));
                  AV16pCod_Area = GetPar( "pCod_Area");
                  AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
                  AV17pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
                  AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
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
         AV6cHATRABAJADORESFecha = context.localUtil.ParseDateParm( GetPar( "cHATRABAJADORESFecha"));
         AV7cHATRABAJADORESMes = (short)(Math.Round(NumberUtil.Val( GetPar( "cHATRABAJADORESMes"), "."), 18, MidpointRounding.ToEven));
         AV8cHATRABAJADORESAno = (short)(Math.Round(NumberUtil.Val( GetPar( "cHATRABAJADORESAno"), "."), 18, MidpointRounding.ToEven));
         AV9cCod_Area = GetPar( "cCod_Area");
         AV10cIndicadoresCodigo = GetPar( "cIndicadoresCodigo");
         AV11cHATRABAJADORESTotHas = NumberUtil.Val( GetPar( "cHATRABAJADORESTotHas"), ".");
         AV12cHATRABAJADORESTotTrab = (int)(Math.Round(NumberUtil.Val( GetPar( "cHATRABAJADORESTotTrab"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cHATRABAJADORESFecha, AV7cHATRABAJADORESMes, AV8cHATRABAJADORESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cHATRABAJADORESTotHas, AV12cHATRABAJADORESTotTrab) ;
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
         PA0V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0V2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00t0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pHATRABAJADORESFecha)),UrlEncode(StringUtil.LTrimStr(AV14pHATRABAJADORESMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pHATRABAJADORESAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pCod_Area)),UrlEncode(StringUtil.RTrim(AV17pIndicadoresCodigo))}, new string[] {"pHATRABAJADORESFecha","pHATRABAJADORESMes","pHATRABAJADORESAno","pCod_Area","pIndicadoresCodigo"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCHATRABAJADORESFECHA", context.localUtil.Format(AV6cHATRABAJADORESFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCHATRABAJADORESMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cHATRABAJADORESMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHATRABAJADORESANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cHATRABAJADORESAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOD_AREA", AV9cCod_Area);
         GxWebStd.gx_hidden_field( context, "GXH_vCINDICADORESCODIGO", AV10cIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCHATRABAJADORESTOTHAS", StringUtil.LTrim( StringUtil.NToC( AV11cHATRABAJADORESTotHas, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHATRABAJADORESTOTTRAB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cHATRABAJADORESTotTrab), 6, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPHATRABAJADORESFECHA", context.localUtil.DToC( AV13pHATRABAJADORESFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPHATRABAJADORESMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pHATRABAJADORESMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPHATRABAJADORESANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15pHATRABAJADORESAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOD_AREA", AV16pCod_Area);
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV17pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "HATRABAJADORESFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divHatrabajadoresfechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HATRABAJADORESMESFILTERCONTAINER_Class", StringUtil.RTrim( divHatrabajadoresmesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HATRABAJADORESANOFILTERCONTAINER_Class", StringUtil.RTrim( divHatrabajadoresanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COD_AREAFILTERCONTAINER_Class", StringUtil.RTrim( divCod_areafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divIndicadorescodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HATRABAJADORESTOTHASFILTERCONTAINER_Class", StringUtil.RTrim( divHatrabajadorestothasfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HATRABAJADORESTOTTRABFILTERCONTAINER_Class", StringUtil.RTrim( divHatrabajadorestottrabfiltercontainer_Class));
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
            WE0V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0V2( ) ;
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
         return formatLink("gx00t0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pHATRABAJADORESFecha)),UrlEncode(StringUtil.LTrimStr(AV14pHATRABAJADORESMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pHATRABAJADORESAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pCod_Area)),UrlEncode(StringUtil.RTrim(AV17pIndicadoresCodigo))}, new string[] {"pHATRABAJADORESFecha","pHATRABAJADORESMes","pHATRABAJADORESAno","pCod_Area","pIndicadoresCodigo"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00T0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List HATRABAJADORES" ;
      }

      protected void WB0V0( )
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
            GxWebStd.gx_div_start( context, divHatrabajadoresfechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divHatrabajadoresfechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhatrabajadoresfechafilter_Internalname, "HATRABAJADORESFecha", "", "", lblLblhatrabajadoresfechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110v1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00T0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChatrabajadoresfecha_Internalname, "HATRABAJADORESFecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavChatrabajadoresfecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavChatrabajadoresfecha_Internalname, context.localUtil.Format(AV6cHATRABAJADORESFecha, "99/99/99"), context.localUtil.Format( AV6cHATRABAJADORESFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChatrabajadoresfecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavChatrabajadoresfecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00T0.htm");
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
            GxWebStd.gx_div_start( context, divHatrabajadoresmesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divHatrabajadoresmesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhatrabajadoresmesfilter_Internalname, "HATRABAJADORESMes", "", "", lblLblhatrabajadoresmesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00T0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChatrabajadoresmes_Internalname, "HATRABAJADORESMes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChatrabajadoresmes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cHATRABAJADORESMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavChatrabajadoresmes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cHATRABAJADORESMes), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cHATRABAJADORESMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChatrabajadoresmes_Jsonclick, 0, "Attribute", "", "", "", "", edtavChatrabajadoresmes_Visible, edtavChatrabajadoresmes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00T0.htm");
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
            GxWebStd.gx_div_start( context, divHatrabajadoresanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divHatrabajadoresanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhatrabajadoresanofilter_Internalname, "HATRABAJADORESAno", "", "", lblLblhatrabajadoresanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00T0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChatrabajadoresano_Internalname, "HATRABAJADORESAno", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChatrabajadoresano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cHATRABAJADORESAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtavChatrabajadoresano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cHATRABAJADORESAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cHATRABAJADORESAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChatrabajadoresano_Jsonclick, 0, "Attribute", "", "", "", "", edtavChatrabajadoresano_Visible, edtavChatrabajadoresano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00T0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblcod_areafilter_Internalname, "Cod_Area", "", "", lblLblcod_areafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00T0.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCcod_area_Internalname, AV9cCod_Area, StringUtil.RTrim( context.localUtil.Format( AV9cCod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcod_area_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcod_area_Visible, edtavCcod_area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00T0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblindicadorescodigofilter_Internalname, "Indicadores Codigo", "", "", lblLblindicadorescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00T0.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCindicadorescodigo_Internalname, AV10cIndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( AV10cIndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCindicadorescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCindicadorescodigo_Visible, edtavCindicadorescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00T0.htm");
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
            GxWebStd.gx_div_start( context, divHatrabajadorestothasfiltercontainer_Internalname, 1, 0, "px", 0, "px", divHatrabajadorestothasfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhatrabajadorestothasfilter_Internalname, "HATRABAJADORESTot Has", "", "", lblLblhatrabajadorestothasfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00T0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChatrabajadorestothas_Internalname, "HATRABAJADORESTot Has", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChatrabajadorestothas_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11cHATRABAJADORESTotHas, 12, 2, ",", "")), StringUtil.LTrim( ((edtavChatrabajadorestothas_Enabled!=0) ? context.localUtil.Format( AV11cHATRABAJADORESTotHas, "ZZZZZZZZ9.99") : context.localUtil.Format( AV11cHATRABAJADORESTotHas, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChatrabajadorestothas_Jsonclick, 0, "Attribute", "", "", "", "", edtavChatrabajadorestothas_Visible, edtavChatrabajadorestothas_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00T0.htm");
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
            GxWebStd.gx_div_start( context, divHatrabajadorestottrabfiltercontainer_Internalname, 1, 0, "px", 0, "px", divHatrabajadorestottrabfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhatrabajadorestottrabfilter_Internalname, "HATRABAJADORESTot Trab", "", "", lblLblhatrabajadorestottrabfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00T0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChatrabajadorestottrab_Internalname, "HATRABAJADORESTot Trab", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChatrabajadorestottrab_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cHATRABAJADORESTotTrab), 6, 0, ",", "")), StringUtil.LTrim( ((edtavChatrabajadorestottrab_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cHATRABAJADORESTotTrab), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV12cHATRABAJADORESTotTrab), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChatrabajadorestottrab_Jsonclick, 0, "Attribute", "", "", "", "", edtavChatrabajadorestottrab_Visible, edtavChatrabajadorestottrab_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00T0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180v1_client"+"'", TempTags, "", 2, "HLP_Gx00T0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00T0.htm");
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

      protected void START0V2( )
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
            Form.Meta.addItem("description", "Selection List HATRABAJADORES", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0V0( ) ;
      }

      protected void WS0V2( )
      {
         START0V2( ) ;
         EVT0V2( ) ;
      }

      protected void EVT0V2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV21Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A57HATRABAJADORESFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtHATRABAJADORESFecha_Internalname), 0));
                              A58HATRABAJADORESMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHATRABAJADORESMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A59HATRABAJADORESAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHATRABAJADORESAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A5Cod_Area = cgiGet( edtCod_Area_Internalname);
                              A174HATRABAJADORESTotHas = context.localUtil.CToN( cgiGet( edtHATRABAJADORESTotHas_Internalname), ",", ".");
                              A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Chatrabajadoresfecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCHATRABAJADORESFECHA"), 0) != AV6cHATRABAJADORESFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chatrabajadoresmes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHATRABAJADORESMES"), ",", ".") != Convert.ToDecimal( AV7cHATRABAJADORESMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chatrabajadoresano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHATRABAJADORESANO"), ",", ".") != Convert.ToDecimal( AV8cHATRABAJADORESAno )) )
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
                                       /* Set Refresh If Chatrabajadorestothas Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCHATRABAJADORESTOTHAS"), ",", ".") != AV11cHATRABAJADORESTotHas )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chatrabajadorestottrab Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHATRABAJADORESTOTTRAB"), ",", ".") != Convert.ToDecimal( AV12cHATRABAJADORESTotTrab )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210V2 ();
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

      protected void WE0V2( )
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

      protected void PA0V2( )
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
                                        DateTime AV6cHATRABAJADORESFecha ,
                                        short AV7cHATRABAJADORESMes ,
                                        short AV8cHATRABAJADORESAno ,
                                        string AV9cCod_Area ,
                                        string AV10cIndicadoresCodigo ,
                                        decimal AV11cHATRABAJADORESTotHas ,
                                        int AV12cHATRABAJADORESTotTrab )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_HATRABAJADORESFECHA", GetSecureSignedToken( "", A57HATRABAJADORESFecha, context));
         GxWebStd.gx_hidden_field( context, "HATRABAJADORESFECHA", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_HATRABAJADORESMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A58HATRABAJADORESMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "HATRABAJADORESMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A58HATRABAJADORESMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_HATRABAJADORESANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A59HATRABAJADORESAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "HATRABAJADORESANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A59HATRABAJADORESAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "COD_AREA", A5Cod_Area);
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGO", A4IndicadoresCodigo);
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
         RF0V2( ) ;
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

      protected void RF0V2( )
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
                                                 AV11cHATRABAJADORESTotHas ,
                                                 AV12cHATRABAJADORESTotTrab ,
                                                 A174HATRABAJADORESTotHas ,
                                                 A175HATRABAJADORESTotTrab ,
                                                 A5Cod_Area ,
                                                 AV9cCod_Area ,
                                                 A4IndicadoresCodigo ,
                                                 AV10cIndicadoresCodigo ,
                                                 AV6cHATRABAJADORESFecha ,
                                                 AV7cHATRABAJADORESMes ,
                                                 AV8cHATRABAJADORESAno } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
            lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
            /* Using cursor H000V2 */
            pr_default.execute(0, new Object[] {AV6cHATRABAJADORESFecha, AV7cHATRABAJADORESMes, AV8cHATRABAJADORESAno, lV9cCod_Area, lV10cIndicadoresCodigo, AV11cHATRABAJADORESTotHas, AV12cHATRABAJADORESTotTrab, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A175HATRABAJADORESTotTrab = H000V2_A175HATRABAJADORESTotTrab[0];
               A4IndicadoresCodigo = H000V2_A4IndicadoresCodigo[0];
               A174HATRABAJADORESTotHas = H000V2_A174HATRABAJADORESTotHas[0];
               A5Cod_Area = H000V2_A5Cod_Area[0];
               A59HATRABAJADORESAno = H000V2_A59HATRABAJADORESAno[0];
               A58HATRABAJADORESMes = H000V2_A58HATRABAJADORESMes[0];
               A57HATRABAJADORESFecha = H000V2_A57HATRABAJADORESFecha[0];
               /* Execute user event: Load */
               E200V2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0V0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0V2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_HATRABAJADORESFECHA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A57HATRABAJADORESFecha, context));
         GxWebStd.gx_hidden_field( context, "gxhash_HATRABAJADORESMES"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A58HATRABAJADORESMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_HATRABAJADORESANO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A59HATRABAJADORESAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
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
                                              AV11cHATRABAJADORESTotHas ,
                                              AV12cHATRABAJADORESTotTrab ,
                                              A174HATRABAJADORESTotHas ,
                                              A175HATRABAJADORESTotTrab ,
                                              A5Cod_Area ,
                                              AV9cCod_Area ,
                                              A4IndicadoresCodigo ,
                                              AV10cIndicadoresCodigo ,
                                              AV6cHATRABAJADORESFecha ,
                                              AV7cHATRABAJADORESMes ,
                                              AV8cHATRABAJADORESAno } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
         lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
         /* Using cursor H000V3 */
         pr_default.execute(1, new Object[] {AV6cHATRABAJADORESFecha, AV7cHATRABAJADORESMes, AV8cHATRABAJADORESAno, lV9cCod_Area, lV10cIndicadoresCodigo, AV11cHATRABAJADORESTotHas, AV12cHATRABAJADORESTotTrab});
         GRID1_nRecordCount = H000V3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHATRABAJADORESFecha, AV7cHATRABAJADORESMes, AV8cHATRABAJADORESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cHATRABAJADORESTotHas, AV12cHATRABAJADORESTotTrab) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHATRABAJADORESFecha, AV7cHATRABAJADORESMes, AV8cHATRABAJADORESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cHATRABAJADORESTotHas, AV12cHATRABAJADORESTotTrab) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHATRABAJADORESFecha, AV7cHATRABAJADORESMes, AV8cHATRABAJADORESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cHATRABAJADORESTotHas, AV12cHATRABAJADORESTotTrab) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHATRABAJADORESFecha, AV7cHATRABAJADORESMes, AV8cHATRABAJADORESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cHATRABAJADORESTotHas, AV12cHATRABAJADORESTotTrab) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHATRABAJADORESFecha, AV7cHATRABAJADORESMes, AV8cHATRABAJADORESAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cHATRABAJADORESTotHas, AV12cHATRABAJADORESTotTrab) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190V2 ();
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
            if ( context.localUtil.VCDate( cgiGet( edtavChatrabajadoresfecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"HATRABAJADORESFecha"}), 1, "vCHATRABAJADORESFECHA");
               GX_FocusControl = edtavChatrabajadoresfecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cHATRABAJADORESFecha = DateTime.MinValue;
               AssignAttri("", false, "AV6cHATRABAJADORESFecha", context.localUtil.Format(AV6cHATRABAJADORESFecha, "99/99/99"));
            }
            else
            {
               AV6cHATRABAJADORESFecha = context.localUtil.CToD( cgiGet( edtavChatrabajadoresfecha_Internalname), 2);
               AssignAttri("", false, "AV6cHATRABAJADORESFecha", context.localUtil.Format(AV6cHATRABAJADORESFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavChatrabajadoresmes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavChatrabajadoresmes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHATRABAJADORESMES");
               GX_FocusControl = edtavChatrabajadoresmes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cHATRABAJADORESMes = 0;
               AssignAttri("", false, "AV7cHATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(AV7cHATRABAJADORESMes), 4, 0));
            }
            else
            {
               AV7cHATRABAJADORESMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavChatrabajadoresmes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cHATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(AV7cHATRABAJADORESMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavChatrabajadoresano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavChatrabajadoresano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHATRABAJADORESANO");
               GX_FocusControl = edtavChatrabajadoresano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cHATRABAJADORESAno = 0;
               AssignAttri("", false, "AV8cHATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(AV8cHATRABAJADORESAno), 4, 0));
            }
            else
            {
               AV8cHATRABAJADORESAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavChatrabajadoresano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cHATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(AV8cHATRABAJADORESAno), 4, 0));
            }
            AV9cCod_Area = cgiGet( edtavCcod_area_Internalname);
            AssignAttri("", false, "AV9cCod_Area", AV9cCod_Area);
            AV10cIndicadoresCodigo = cgiGet( edtavCindicadorescodigo_Internalname);
            AssignAttri("", false, "AV10cIndicadoresCodigo", AV10cIndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavChatrabajadorestothas_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavChatrabajadorestothas_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHATRABAJADORESTOTHAS");
               GX_FocusControl = edtavChatrabajadorestothas_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cHATRABAJADORESTotHas = 0;
               AssignAttri("", false, "AV11cHATRABAJADORESTotHas", StringUtil.LTrimStr( AV11cHATRABAJADORESTotHas, 12, 2));
            }
            else
            {
               AV11cHATRABAJADORESTotHas = context.localUtil.CToN( cgiGet( edtavChatrabajadorestothas_Internalname), ",", ".");
               AssignAttri("", false, "AV11cHATRABAJADORESTotHas", StringUtil.LTrimStr( AV11cHATRABAJADORESTotHas, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavChatrabajadorestottrab_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavChatrabajadorestottrab_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHATRABAJADORESTOTTRAB");
               GX_FocusControl = edtavChatrabajadorestottrab_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cHATRABAJADORESTotTrab = 0;
               AssignAttri("", false, "AV12cHATRABAJADORESTotTrab", StringUtil.LTrimStr( (decimal)(AV12cHATRABAJADORESTotTrab), 6, 0));
            }
            else
            {
               AV12cHATRABAJADORESTotTrab = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavChatrabajadorestottrab_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cHATRABAJADORESTotTrab", StringUtil.LTrimStr( (decimal)(AV12cHATRABAJADORESTotTrab), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCHATRABAJADORESFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV6cHATRABAJADORESFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHATRABAJADORESMES"), ",", ".") != Convert.ToDecimal( AV7cHATRABAJADORESMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHATRABAJADORESANO"), ",", ".") != Convert.ToDecimal( AV8cHATRABAJADORESAno )) )
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
            if ( context.localUtil.CToN( cgiGet( "GXH_vCHATRABAJADORESTOTHAS"), ",", ".") != AV11cHATRABAJADORESTotHas )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHATRABAJADORESTOTTRAB"), ",", ".") != Convert.ToDecimal( AV12cHATRABAJADORESTotTrab )) )
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
         E190V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190V2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "HATRABAJADORES", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV18ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200V2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV21Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E210V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210V2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pHATRABAJADORESFecha = A57HATRABAJADORESFecha;
         AssignAttri("", false, "AV13pHATRABAJADORESFecha", context.localUtil.Format(AV13pHATRABAJADORESFecha, "99/99/99"));
         AV14pHATRABAJADORESMes = A58HATRABAJADORESMes;
         AssignAttri("", false, "AV14pHATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(AV14pHATRABAJADORESMes), 4, 0));
         AV15pHATRABAJADORESAno = A59HATRABAJADORESAno;
         AssignAttri("", false, "AV15pHATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(AV15pHATRABAJADORESAno), 4, 0));
         AV16pCod_Area = A5Cod_Area;
         AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
         AV17pIndicadoresCodigo = A4IndicadoresCodigo;
         AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV13pHATRABAJADORESFecha, "99/99/99"),(short)AV14pHATRABAJADORESMes,(short)AV15pHATRABAJADORESAno,(string)AV16pCod_Area,(string)AV17pIndicadoresCodigo});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pHATRABAJADORESFecha","AV14pHATRABAJADORESMes","AV15pHATRABAJADORESAno","AV16pCod_Area","AV17pIndicadoresCodigo"});
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
         AV13pHATRABAJADORESFecha = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV13pHATRABAJADORESFecha", context.localUtil.Format(AV13pHATRABAJADORESFecha, "99/99/99"));
         AV14pHATRABAJADORESMes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV14pHATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(AV14pHATRABAJADORESMes), 4, 0));
         AV15pHATRABAJADORESAno = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV15pHATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(AV15pHATRABAJADORESAno), 4, 0));
         AV16pCod_Area = (string)getParm(obj,3);
         AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
         AV17pIndicadoresCodigo = (string)getParm(obj,4);
         AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
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
         PA0V2( ) ;
         WS0V2( ) ;
         WE0V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231024288", true, true);
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
         context.AddJavascriptSource("gx00t0.js", "?20247231024288", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtHATRABAJADORESFecha_Internalname = "HATRABAJADORESFECHA_"+sGXsfl_84_idx;
         edtHATRABAJADORESMes_Internalname = "HATRABAJADORESMES_"+sGXsfl_84_idx;
         edtHATRABAJADORESAno_Internalname = "HATRABAJADORESANO_"+sGXsfl_84_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_idx;
         edtHATRABAJADORESTotHas_Internalname = "HATRABAJADORESTOTHAS_"+sGXsfl_84_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtHATRABAJADORESFecha_Internalname = "HATRABAJADORESFECHA_"+sGXsfl_84_fel_idx;
         edtHATRABAJADORESMes_Internalname = "HATRABAJADORESMES_"+sGXsfl_84_fel_idx;
         edtHATRABAJADORESAno_Internalname = "HATRABAJADORESANO_"+sGXsfl_84_fel_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_fel_idx;
         edtHATRABAJADORESTotHas_Internalname = "HATRABAJADORESTOTHAS_"+sGXsfl_84_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0V0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A58HATRABAJADORESMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A59HATRABAJADORESAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV21Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV21Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHATRABAJADORESFecha_Internalname,context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"),context.localUtil.Format( A57HATRABAJADORESFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHATRABAJADORESFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHATRABAJADORESMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A58HATRABAJADORESMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A58HATRABAJADORESMes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHATRABAJADORESMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHATRABAJADORESAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A59HATRABAJADORESAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A59HATRABAJADORESAno), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHATRABAJADORESAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
            edtHATRABAJADORESTotHas_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A58HATRABAJADORESMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A59HATRABAJADORESAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+"]);";
            AssignProp("", false, edtHATRABAJADORESTotHas_Internalname, "Link", edtHATRABAJADORESTotHas_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHATRABAJADORESTotHas_Internalname,StringUtil.LTrim( StringUtil.NToC( A174HATRABAJADORESTotHas, 12, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A174HATRABAJADORESTotHas, "ZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtHATRABAJADORESTotHas_Link,(string)"",(string)"",(string)"",(string)edtHATRABAJADORESTotHas_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIndicadoresCodigo_Internalname,(string)A4IndicadoresCodigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIndicadoresCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0V2( ) ;
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
            context.SendWebValue( "HATRABAJADORESFecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "HATRABAJADORESMes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "HATRABAJADORESAno") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cod_Area") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Has") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Codigo") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A58HATRABAJADORESMes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A59HATRABAJADORESAno), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A5Cod_Area));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A174HATRABAJADORESTotHas, 12, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtHATRABAJADORESTotHas_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A4IndicadoresCodigo));
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
         lblLblhatrabajadoresfechafilter_Internalname = "LBLHATRABAJADORESFECHAFILTER";
         edtavChatrabajadoresfecha_Internalname = "vCHATRABAJADORESFECHA";
         divHatrabajadoresfechafiltercontainer_Internalname = "HATRABAJADORESFECHAFILTERCONTAINER";
         lblLblhatrabajadoresmesfilter_Internalname = "LBLHATRABAJADORESMESFILTER";
         edtavChatrabajadoresmes_Internalname = "vCHATRABAJADORESMES";
         divHatrabajadoresmesfiltercontainer_Internalname = "HATRABAJADORESMESFILTERCONTAINER";
         lblLblhatrabajadoresanofilter_Internalname = "LBLHATRABAJADORESANOFILTER";
         edtavChatrabajadoresano_Internalname = "vCHATRABAJADORESANO";
         divHatrabajadoresanofiltercontainer_Internalname = "HATRABAJADORESANOFILTERCONTAINER";
         lblLblcod_areafilter_Internalname = "LBLCOD_AREAFILTER";
         edtavCcod_area_Internalname = "vCCOD_AREA";
         divCod_areafiltercontainer_Internalname = "COD_AREAFILTERCONTAINER";
         lblLblindicadorescodigofilter_Internalname = "LBLINDICADORESCODIGOFILTER";
         edtavCindicadorescodigo_Internalname = "vCINDICADORESCODIGO";
         divIndicadorescodigofiltercontainer_Internalname = "INDICADORESCODIGOFILTERCONTAINER";
         lblLblhatrabajadorestothasfilter_Internalname = "LBLHATRABAJADORESTOTHASFILTER";
         edtavChatrabajadorestothas_Internalname = "vCHATRABAJADORESTOTHAS";
         divHatrabajadorestothasfiltercontainer_Internalname = "HATRABAJADORESTOTHASFILTERCONTAINER";
         lblLblhatrabajadorestottrabfilter_Internalname = "LBLHATRABAJADORESTOTTRABFILTER";
         edtavChatrabajadorestottrab_Internalname = "vCHATRABAJADORESTOTTRAB";
         divHatrabajadorestottrabfiltercontainer_Internalname = "HATRABAJADORESTOTTRABFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtHATRABAJADORESFecha_Internalname = "HATRABAJADORESFECHA";
         edtHATRABAJADORESMes_Internalname = "HATRABAJADORESMES";
         edtHATRABAJADORESAno_Internalname = "HATRABAJADORESANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtHATRABAJADORESTotHas_Internalname = "HATRABAJADORESTOTHAS";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
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
         edtIndicadoresCodigo_Jsonclick = "";
         edtHATRABAJADORESTotHas_Jsonclick = "";
         edtHATRABAJADORESTotHas_Link = "";
         edtCod_Area_Jsonclick = "";
         edtHATRABAJADORESAno_Jsonclick = "";
         edtHATRABAJADORESMes_Jsonclick = "";
         edtHATRABAJADORESFecha_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavChatrabajadorestottrab_Jsonclick = "";
         edtavChatrabajadorestottrab_Enabled = 1;
         edtavChatrabajadorestottrab_Visible = 1;
         edtavChatrabajadorestothas_Jsonclick = "";
         edtavChatrabajadorestothas_Enabled = 1;
         edtavChatrabajadorestothas_Visible = 1;
         edtavCindicadorescodigo_Jsonclick = "";
         edtavCindicadorescodigo_Enabled = 1;
         edtavCindicadorescodigo_Visible = 1;
         edtavCcod_area_Jsonclick = "";
         edtavCcod_area_Enabled = 1;
         edtavCcod_area_Visible = 1;
         edtavChatrabajadoresano_Jsonclick = "";
         edtavChatrabajadoresano_Enabled = 1;
         edtavChatrabajadoresano_Visible = 1;
         edtavChatrabajadoresmes_Jsonclick = "";
         edtavChatrabajadoresmes_Enabled = 1;
         edtavChatrabajadoresmes_Visible = 1;
         edtavChatrabajadoresfecha_Jsonclick = "";
         edtavChatrabajadoresfecha_Enabled = 1;
         divHatrabajadorestottrabfiltercontainer_Class = "AdvancedContainerItem";
         divHatrabajadorestothasfiltercontainer_Class = "AdvancedContainerItem";
         divIndicadorescodigofiltercontainer_Class = "AdvancedContainerItem";
         divCod_areafiltercontainer_Class = "AdvancedContainerItem";
         divHatrabajadoresanofiltercontainer_Class = "AdvancedContainerItem";
         divHatrabajadoresmesfiltercontainer_Class = "AdvancedContainerItem";
         divHatrabajadoresfechafiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List HATRABAJADORES";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHATRABAJADORESFecha',fld:'vCHATRABAJADORESFECHA',pic:''},{av:'AV7cHATRABAJADORESMes',fld:'vCHATRABAJADORESMES',pic:'ZZZ9'},{av:'AV8cHATRABAJADORESAno',fld:'vCHATRABAJADORESANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cHATRABAJADORESTotHas',fld:'vCHATRABAJADORESTOTHAS',pic:'ZZZZZZZZ9.99'},{av:'AV12cHATRABAJADORESTotTrab',fld:'vCHATRABAJADORESTOTTRAB',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180V1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLHATRABAJADORESFECHAFILTER.CLICK","{handler:'E110V1',iparms:[{av:'divHatrabajadoresfechafiltercontainer_Class',ctrl:'HATRABAJADORESFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHATRABAJADORESFECHAFILTER.CLICK",",oparms:[{av:'divHatrabajadoresfechafiltercontainer_Class',ctrl:'HATRABAJADORESFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLHATRABAJADORESMESFILTER.CLICK","{handler:'E120V1',iparms:[{av:'divHatrabajadoresmesfiltercontainer_Class',ctrl:'HATRABAJADORESMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHATRABAJADORESMESFILTER.CLICK",",oparms:[{av:'divHatrabajadoresmesfiltercontainer_Class',ctrl:'HATRABAJADORESMESFILTERCONTAINER',prop:'Class'},{av:'edtavChatrabajadoresmes_Visible',ctrl:'vCHATRABAJADORESMES',prop:'Visible'}]}");
         setEventMetadata("LBLHATRABAJADORESANOFILTER.CLICK","{handler:'E130V1',iparms:[{av:'divHatrabajadoresanofiltercontainer_Class',ctrl:'HATRABAJADORESANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHATRABAJADORESANOFILTER.CLICK",",oparms:[{av:'divHatrabajadoresanofiltercontainer_Class',ctrl:'HATRABAJADORESANOFILTERCONTAINER',prop:'Class'},{av:'edtavChatrabajadoresano_Visible',ctrl:'vCHATRABAJADORESANO',prop:'Visible'}]}");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK","{handler:'E140V1',iparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK",",oparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'},{av:'edtavCcod_area_Visible',ctrl:'vCCOD_AREA',prop:'Visible'}]}");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK","{handler:'E150V1',iparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK",",oparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCindicadorescodigo_Visible',ctrl:'vCINDICADORESCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLHATRABAJADORESTOTHASFILTER.CLICK","{handler:'E160V1',iparms:[{av:'divHatrabajadorestothasfiltercontainer_Class',ctrl:'HATRABAJADORESTOTHASFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHATRABAJADORESTOTHASFILTER.CLICK",",oparms:[{av:'divHatrabajadorestothasfiltercontainer_Class',ctrl:'HATRABAJADORESTOTHASFILTERCONTAINER',prop:'Class'},{av:'edtavChatrabajadorestothas_Visible',ctrl:'vCHATRABAJADORESTOTHAS',prop:'Visible'}]}");
         setEventMetadata("LBLHATRABAJADORESTOTTRABFILTER.CLICK","{handler:'E170V1',iparms:[{av:'divHatrabajadorestottrabfiltercontainer_Class',ctrl:'HATRABAJADORESTOTTRABFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHATRABAJADORESTOTTRABFILTER.CLICK",",oparms:[{av:'divHatrabajadorestottrabfiltercontainer_Class',ctrl:'HATRABAJADORESTOTTRABFILTERCONTAINER',prop:'Class'},{av:'edtavChatrabajadorestottrab_Visible',ctrl:'vCHATRABAJADORESTOTTRAB',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E210V2',iparms:[{av:'A57HATRABAJADORESFecha',fld:'HATRABAJADORESFECHA',pic:'',hsh:true},{av:'A58HATRABAJADORESMes',fld:'HATRABAJADORESMES',pic:'ZZZ9',hsh:true},{av:'A59HATRABAJADORESAno',fld:'HATRABAJADORESANO',pic:'ZZZ9',hsh:true},{av:'A5Cod_Area',fld:'COD_AREA',pic:'',hsh:true},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pHATRABAJADORESFecha',fld:'vPHATRABAJADORESFECHA',pic:''},{av:'AV14pHATRABAJADORESMes',fld:'vPHATRABAJADORESMES',pic:'ZZZ9'},{av:'AV15pHATRABAJADORESAno',fld:'vPHATRABAJADORESANO',pic:'ZZZ9'},{av:'AV16pCod_Area',fld:'vPCOD_AREA',pic:''},{av:'AV17pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHATRABAJADORESFecha',fld:'vCHATRABAJADORESFECHA',pic:''},{av:'AV7cHATRABAJADORESMes',fld:'vCHATRABAJADORESMES',pic:'ZZZ9'},{av:'AV8cHATRABAJADORESAno',fld:'vCHATRABAJADORESANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cHATRABAJADORESTotHas',fld:'vCHATRABAJADORESTOTHAS',pic:'ZZZZZZZZ9.99'},{av:'AV12cHATRABAJADORESTotTrab',fld:'vCHATRABAJADORESTOTTRAB',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHATRABAJADORESFecha',fld:'vCHATRABAJADORESFECHA',pic:''},{av:'AV7cHATRABAJADORESMes',fld:'vCHATRABAJADORESMES',pic:'ZZZ9'},{av:'AV8cHATRABAJADORESAno',fld:'vCHATRABAJADORESANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cHATRABAJADORESTotHas',fld:'vCHATRABAJADORESTOTHAS',pic:'ZZZZZZZZ9.99'},{av:'AV12cHATRABAJADORESTotTrab',fld:'vCHATRABAJADORESTOTTRAB',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHATRABAJADORESFecha',fld:'vCHATRABAJADORESFECHA',pic:''},{av:'AV7cHATRABAJADORESMes',fld:'vCHATRABAJADORESMES',pic:'ZZZ9'},{av:'AV8cHATRABAJADORESAno',fld:'vCHATRABAJADORESANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cHATRABAJADORESTotHas',fld:'vCHATRABAJADORESTOTHAS',pic:'ZZZZZZZZ9.99'},{av:'AV12cHATRABAJADORESTotTrab',fld:'vCHATRABAJADORESTOTTRAB',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHATRABAJADORESFecha',fld:'vCHATRABAJADORESFECHA',pic:''},{av:'AV7cHATRABAJADORESMes',fld:'vCHATRABAJADORESMES',pic:'ZZZ9'},{av:'AV8cHATRABAJADORESAno',fld:'vCHATRABAJADORESANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cHATRABAJADORESTotHas',fld:'vCHATRABAJADORESTOTHAS',pic:'ZZZZZZZZ9.99'},{av:'AV12cHATRABAJADORESTotTrab',fld:'vCHATRABAJADORESTOTTRAB',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CHATRABAJADORESFECHA","{handler:'Validv_Chatrabajadoresfecha',iparms:[]");
         setEventMetadata("VALIDV_CHATRABAJADORESFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Indicadorescodigo',iparms:[]");
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
         AV13pHATRABAJADORESFecha = DateTime.MinValue;
         AV16pCod_Area = "";
         AV17pIndicadoresCodigo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cHATRABAJADORESFecha = DateTime.MinValue;
         AV9cCod_Area = "";
         AV10cIndicadoresCodigo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblhatrabajadoresfechafilter_Jsonclick = "";
         TempTags = "";
         lblLblhatrabajadoresmesfilter_Jsonclick = "";
         lblLblhatrabajadoresanofilter_Jsonclick = "";
         lblLblcod_areafilter_Jsonclick = "";
         lblLblindicadorescodigofilter_Jsonclick = "";
         lblLblhatrabajadorestothasfilter_Jsonclick = "";
         lblLblhatrabajadorestottrabfilter_Jsonclick = "";
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
         AV21Linkselection_GXI = "";
         A57HATRABAJADORESFecha = DateTime.MinValue;
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         scmdbuf = "";
         lV9cCod_Area = "";
         lV10cIndicadoresCodigo = "";
         H000V2_A175HATRABAJADORESTotTrab = new int[1] ;
         H000V2_A4IndicadoresCodigo = new string[] {""} ;
         H000V2_A174HATRABAJADORESTotHas = new decimal[1] ;
         H000V2_A5Cod_Area = new string[] {""} ;
         H000V2_A59HATRABAJADORESAno = new short[1] ;
         H000V2_A58HATRABAJADORESMes = new short[1] ;
         H000V2_A57HATRABAJADORESFecha = new DateTime[] {DateTime.MinValue} ;
         H000V3_AGRID1_nRecordCount = new long[1] ;
         AV18ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00t0__default(),
            new Object[][] {
                new Object[] {
               H000V2_A175HATRABAJADORESTotTrab, H000V2_A4IndicadoresCodigo, H000V2_A174HATRABAJADORESTotHas, H000V2_A5Cod_Area, H000V2_A59HATRABAJADORESAno, H000V2_A58HATRABAJADORESMes, H000V2_A57HATRABAJADORESFecha
               }
               , new Object[] {
               H000V3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14pHATRABAJADORESMes ;
      private short AV15pHATRABAJADORESAno ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cHATRABAJADORESMes ;
      private short AV8cHATRABAJADORESAno ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A58HATRABAJADORESMes ;
      private short A59HATRABAJADORESAno ;
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
      private int AV12cHATRABAJADORESTotTrab ;
      private int edtavChatrabajadoresfecha_Enabled ;
      private int edtavChatrabajadoresmes_Enabled ;
      private int edtavChatrabajadoresmes_Visible ;
      private int edtavChatrabajadoresano_Enabled ;
      private int edtavChatrabajadoresano_Visible ;
      private int edtavCcod_area_Visible ;
      private int edtavCcod_area_Enabled ;
      private int edtavCindicadorescodigo_Visible ;
      private int edtavCindicadorescodigo_Enabled ;
      private int edtavChatrabajadorestothas_Enabled ;
      private int edtavChatrabajadorestothas_Visible ;
      private int edtavChatrabajadorestottrab_Enabled ;
      private int edtavChatrabajadorestottrab_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A175HATRABAJADORESTotTrab ;
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
      private decimal AV11cHATRABAJADORESTotHas ;
      private decimal A174HATRABAJADORESTotHas ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divHatrabajadoresfechafiltercontainer_Class ;
      private string divHatrabajadoresmesfiltercontainer_Class ;
      private string divHatrabajadoresanofiltercontainer_Class ;
      private string divCod_areafiltercontainer_Class ;
      private string divIndicadorescodigofiltercontainer_Class ;
      private string divHatrabajadorestothasfiltercontainer_Class ;
      private string divHatrabajadorestottrabfiltercontainer_Class ;
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
      private string divHatrabajadoresfechafiltercontainer_Internalname ;
      private string lblLblhatrabajadoresfechafilter_Internalname ;
      private string lblLblhatrabajadoresfechafilter_Jsonclick ;
      private string edtavChatrabajadoresfecha_Internalname ;
      private string TempTags ;
      private string edtavChatrabajadoresfecha_Jsonclick ;
      private string divHatrabajadoresmesfiltercontainer_Internalname ;
      private string lblLblhatrabajadoresmesfilter_Internalname ;
      private string lblLblhatrabajadoresmesfilter_Jsonclick ;
      private string edtavChatrabajadoresmes_Internalname ;
      private string edtavChatrabajadoresmes_Jsonclick ;
      private string divHatrabajadoresanofiltercontainer_Internalname ;
      private string lblLblhatrabajadoresanofilter_Internalname ;
      private string lblLblhatrabajadoresanofilter_Jsonclick ;
      private string edtavChatrabajadoresano_Internalname ;
      private string edtavChatrabajadoresano_Jsonclick ;
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
      private string divHatrabajadorestothasfiltercontainer_Internalname ;
      private string lblLblhatrabajadorestothasfilter_Internalname ;
      private string lblLblhatrabajadorestothasfilter_Jsonclick ;
      private string edtavChatrabajadorestothas_Internalname ;
      private string edtavChatrabajadorestothas_Jsonclick ;
      private string divHatrabajadorestottrabfiltercontainer_Internalname ;
      private string lblLblhatrabajadorestottrabfilter_Internalname ;
      private string lblLblhatrabajadorestottrabfilter_Jsonclick ;
      private string edtavChatrabajadorestottrab_Internalname ;
      private string edtavChatrabajadorestottrab_Jsonclick ;
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
      private string edtHATRABAJADORESFecha_Internalname ;
      private string edtHATRABAJADORESMes_Internalname ;
      private string edtHATRABAJADORESAno_Internalname ;
      private string edtCod_Area_Internalname ;
      private string edtHATRABAJADORESTotHas_Internalname ;
      private string edtIndicadoresCodigo_Internalname ;
      private string scmdbuf ;
      private string AV18ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtHATRABAJADORESFecha_Jsonclick ;
      private string edtHATRABAJADORESMes_Jsonclick ;
      private string edtHATRABAJADORESAno_Jsonclick ;
      private string edtCod_Area_Jsonclick ;
      private string edtHATRABAJADORESTotHas_Link ;
      private string edtHATRABAJADORESTotHas_Jsonclick ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV13pHATRABAJADORESFecha ;
      private DateTime AV6cHATRABAJADORESFecha ;
      private DateTime A57HATRABAJADORESFecha ;
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
      private string AV9cCod_Area ;
      private string AV10cIndicadoresCodigo ;
      private string AV21Linkselection_GXI ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string lV9cCod_Area ;
      private string lV10cIndicadoresCodigo ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H000V2_A175HATRABAJADORESTotTrab ;
      private string[] H000V2_A4IndicadoresCodigo ;
      private decimal[] H000V2_A174HATRABAJADORESTotHas ;
      private string[] H000V2_A5Cod_Area ;
      private short[] H000V2_A59HATRABAJADORESAno ;
      private short[] H000V2_A58HATRABAJADORESMes ;
      private DateTime[] H000V2_A57HATRABAJADORESFecha ;
      private long[] H000V3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP0_pHATRABAJADORESFecha ;
      private short aP1_pHATRABAJADORESMes ;
      private short aP2_pHATRABAJADORESAno ;
      private string aP3_pCod_Area ;
      private string aP4_pIndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class gx00t0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000V2( IGxContext context ,
                                             decimal AV11cHATRABAJADORESTotHas ,
                                             int AV12cHATRABAJADORESTotTrab ,
                                             decimal A174HATRABAJADORESTotHas ,
                                             int A175HATRABAJADORESTotTrab ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             DateTime AV6cHATRABAJADORESFecha ,
                                             short AV7cHATRABAJADORESMes ,
                                             short AV8cHATRABAJADORESAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [HATRABAJADORESTotTrab], [IndicadoresCodigo], [HATRABAJADORESTotHas], [Cod_Area], [HATRABAJADORESAno], [HATRABAJADORESMes], [HATRABAJADORESFecha]";
         sFromString = " FROM [HATRABAJADORES]";
         sOrderString = "";
         AddWhere(sWhereString, "([HATRABAJADORESFecha] >= @AV6cHATRABAJADORESFecha and [HATRABAJADORESMes] >= @AV7cHATRABAJADORESMes and [HATRABAJADORESAno] >= @AV8cHATRABAJADORESAno)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         if ( ! (Convert.ToDecimal(0)==AV11cHATRABAJADORESTotHas) )
         {
            AddWhere(sWhereString, "([HATRABAJADORESTotHas] >= @AV11cHATRABAJADORESTotHas)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cHATRABAJADORESTotTrab) )
         {
            AddWhere(sWhereString, "([HATRABAJADORESTotTrab] >= @AV12cHATRABAJADORESTotTrab)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [Cod_Area], [IndicadoresCodigo]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000V3( IGxContext context ,
                                             decimal AV11cHATRABAJADORESTotHas ,
                                             int AV12cHATRABAJADORESTotTrab ,
                                             decimal A174HATRABAJADORESTotHas ,
                                             int A175HATRABAJADORESTotTrab ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             DateTime AV6cHATRABAJADORESFecha ,
                                             short AV7cHATRABAJADORESMes ,
                                             short AV8cHATRABAJADORESAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [HATRABAJADORES]";
         AddWhere(sWhereString, "([HATRABAJADORESFecha] >= @AV6cHATRABAJADORESFecha and [HATRABAJADORESMes] >= @AV7cHATRABAJADORESMes and [HATRABAJADORESAno] >= @AV8cHATRABAJADORESAno)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         if ( ! (Convert.ToDecimal(0)==AV11cHATRABAJADORESTotHas) )
         {
            AddWhere(sWhereString, "([HATRABAJADORESTotHas] >= @AV11cHATRABAJADORESTotHas)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cHATRABAJADORESTotTrab) )
         {
            AddWhere(sWhereString, "([HATRABAJADORESTotTrab] >= @AV12cHATRABAJADORESTotTrab)");
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
                     return conditional_H000V2(context, (decimal)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H000V3(context, (decimal)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmH000V2;
          prmH000V2 = new Object[] {
          new ParDef("@AV6cHATRABAJADORESFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cHATRABAJADORESMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cHATRABAJADORESAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cHATRABAJADORESTotHas",GXType.Decimal,12,2) ,
          new ParDef("@AV12cHATRABAJADORESTotTrab",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000V3;
          prmH000V3 = new Object[] {
          new ParDef("@AV6cHATRABAJADORESFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cHATRABAJADORESMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cHATRABAJADORESAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cHATRABAJADORESTotHas",GXType.Decimal,12,2) ,
          new ParDef("@AV12cHATRABAJADORESTotTrab",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V3,1, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
