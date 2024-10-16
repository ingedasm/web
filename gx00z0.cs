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
   public class gx00z0 : GXDataArea
   {
      public gx00z0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx00z0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out DateTime aP0_pCOSTOCPOPRODUCIDOFecha ,
                           out short aP1_pCOSTOCPOPRODUCIDOMes ,
                           out short aP2_pCOSTOCPOPRODUCIDOAno ,
                           out string aP3_pCod_Area ,
                           out string aP4_pIndicadoresCodigo ,
                           out string aP5_pTIPOSCPOCod ,
                           out string aP6_pTipoProductoCod )
      {
         this.AV13pCOSTOCPOPRODUCIDOFecha = DateTime.MinValue ;
         this.AV14pCOSTOCPOPRODUCIDOMes = 0 ;
         this.AV15pCOSTOCPOPRODUCIDOAno = 0 ;
         this.AV16pCod_Area = "" ;
         this.AV17pIndicadoresCodigo = "" ;
         this.AV18pTIPOSCPOCod = "" ;
         this.AV19pTipoProductoCod = "" ;
         executePrivate();
         aP0_pCOSTOCPOPRODUCIDOFecha=this.AV13pCOSTOCPOPRODUCIDOFecha;
         aP1_pCOSTOCPOPRODUCIDOMes=this.AV14pCOSTOCPOPRODUCIDOMes;
         aP2_pCOSTOCPOPRODUCIDOAno=this.AV15pCOSTOCPOPRODUCIDOAno;
         aP3_pCod_Area=this.AV16pCod_Area;
         aP4_pIndicadoresCodigo=this.AV17pIndicadoresCodigo;
         aP5_pTIPOSCPOCod=this.AV18pTIPOSCPOCod;
         aP6_pTipoProductoCod=this.AV19pTipoProductoCod;
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
            gxfirstwebparm = GetFirstPar( "pCOSTOCPOPRODUCIDOFecha");
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
               gxfirstwebparm = GetFirstPar( "pCOSTOCPOPRODUCIDOFecha");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCOSTOCPOPRODUCIDOFecha");
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
               AV13pCOSTOCPOPRODUCIDOFecha = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV13pCOSTOCPOPRODUCIDOFecha", context.localUtil.Format(AV13pCOSTOCPOPRODUCIDOFecha, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pCOSTOCPOPRODUCIDOMes = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTOCPOPRODUCIDOMes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pCOSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTOCPOPRODUCIDOMes), 4, 0));
                  AV15pCOSTOCPOPRODUCIDOAno = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTOCPOPRODUCIDOAno"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15pCOSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTOCPOPRODUCIDOAno), 4, 0));
                  AV16pCod_Area = GetPar( "pCod_Area");
                  AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
                  AV17pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
                  AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
                  AV18pTIPOSCPOCod = GetPar( "pTIPOSCPOCod");
                  AssignAttri("", false, "AV18pTIPOSCPOCod", AV18pTIPOSCPOCod);
                  AV19pTipoProductoCod = GetPar( "pTipoProductoCod");
                  AssignAttri("", false, "AV19pTipoProductoCod", AV19pTipoProductoCod);
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
         AV6cCOSTOCPOPRODUCIDOFecha = context.localUtil.ParseDateParm( GetPar( "cCOSTOCPOPRODUCIDOFecha"));
         AV7cCOSTOCPOPRODUCIDOMes = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTOCPOPRODUCIDOMes"), "."), 18, MidpointRounding.ToEven));
         AV8cCOSTOCPOPRODUCIDOAno = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTOCPOPRODUCIDOAno"), "."), 18, MidpointRounding.ToEven));
         AV9cCod_Area = GetPar( "cCod_Area");
         AV10cIndicadoresCodigo = GetPar( "cIndicadoresCodigo");
         AV11cTipoProductoCod = GetPar( "cTipoProductoCod");
         AV12cCOSTOCPOPRODUCIDOValor = NumberUtil.Val( GetPar( "cCOSTOCPOPRODUCIDOValor"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOCPOPRODUCIDOFecha, AV7cCOSTOCPOPRODUCIDOMes, AV8cCOSTOCPOPRODUCIDOAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTipoProductoCod, AV12cCOSTOCPOPRODUCIDOValor) ;
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
         PA142( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START142( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00z0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pCOSTOCPOPRODUCIDOFecha)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTOCPOPRODUCIDOMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pCOSTOCPOPRODUCIDOAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pCod_Area)),UrlEncode(StringUtil.RTrim(AV17pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV18pTIPOSCPOCod)),UrlEncode(StringUtil.RTrim(AV19pTipoProductoCod))}, new string[] {"pCOSTOCPOPRODUCIDOFecha","pCOSTOCPOPRODUCIDOMes","pCOSTOCPOPRODUCIDOAno","pCod_Area","pIndicadoresCodigo","pTIPOSCPOCod","pTipoProductoCod"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOCPOPRODUCIDOFECHA", context.localUtil.Format(AV6cCOSTOCPOPRODUCIDOFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOCPOPRODUCIDOMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTOCPOPRODUCIDOMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOCPOPRODUCIDOANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTOCPOPRODUCIDOAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOD_AREA", AV9cCod_Area);
         GxWebStd.gx_hidden_field( context, "GXH_vCINDICADORESCODIGO", AV10cIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCTIPOPRODUCTOCOD", AV11cTipoProductoCod);
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOCPOPRODUCIDOVALOR", StringUtil.LTrim( StringUtil.NToC( AV12cCOSTOCPOPRODUCIDOValor, 10, 2, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTOCPOPRODUCIDOFECHA", context.localUtil.DToC( AV13pCOSTOCPOPRODUCIDOFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPCOSTOCPOPRODUCIDOMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pCOSTOCPOPRODUCIDOMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTOCPOPRODUCIDOANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15pCOSTOCPOPRODUCIDOAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOD_AREA", AV16pCod_Area);
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV17pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "vPTIPOSCPOCOD", AV18pTIPOSCPOCod);
         GxWebStd.gx_hidden_field( context, "vPTIPOPRODUCTOCOD", AV19pTipoProductoCod);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "COSTOCPOPRODUCIDOFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divCostocpoproducidofechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTOCPOPRODUCIDOMESFILTERCONTAINER_Class", StringUtil.RTrim( divCostocpoproducidomesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTOCPOPRODUCIDOANOFILTERCONTAINER_Class", StringUtil.RTrim( divCostocpoproducidoanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COD_AREAFILTERCONTAINER_Class", StringUtil.RTrim( divCod_areafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divIndicadorescodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TIPOPRODUCTOCODFILTERCONTAINER_Class", StringUtil.RTrim( divTipoproductocodfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTOCPOPRODUCIDOVALORFILTERCONTAINER_Class", StringUtil.RTrim( divCostocpoproducidovalorfiltercontainer_Class));
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
            WE142( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT142( ) ;
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
         return formatLink("gx00z0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pCOSTOCPOPRODUCIDOFecha)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTOCPOPRODUCIDOMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pCOSTOCPOPRODUCIDOAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pCod_Area)),UrlEncode(StringUtil.RTrim(AV17pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV18pTIPOSCPOCod)),UrlEncode(StringUtil.RTrim(AV19pTipoProductoCod))}, new string[] {"pCOSTOCPOPRODUCIDOFecha","pCOSTOCPOPRODUCIDOMes","pCOSTOCPOPRODUCIDOAno","pCod_Area","pIndicadoresCodigo","pTIPOSCPOCod","pTipoProductoCod"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00Z0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List COSTOCPOPRODUCIDO" ;
      }

      protected void WB140( )
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
            GxWebStd.gx_div_start( context, divCostocpoproducidofechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostocpoproducidofechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostocpoproducidofechafilter_Internalname, "COSTOCPOPRODUCIDOFecha", "", "", lblLblcostocpoproducidofechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11141_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Z0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostocpoproducidofecha_Internalname, "COSTOCPOPRODUCIDOFecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCcostocpoproducidofecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCcostocpoproducidofecha_Internalname, context.localUtil.Format(AV6cCOSTOCPOPRODUCIDOFecha, "99/99/99"), context.localUtil.Format( AV6cCOSTOCPOPRODUCIDOFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostocpoproducidofecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcostocpoproducidofecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00Z0.htm");
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
            GxWebStd.gx_div_start( context, divCostocpoproducidomesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostocpoproducidomesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostocpoproducidomesfilter_Internalname, "COSTOCPOPRODUCIDOMes", "", "", lblLblcostocpoproducidomesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Z0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostocpoproducidomes_Internalname, "COSTOCPOPRODUCIDOMes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostocpoproducidomes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTOCPOPRODUCIDOMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostocpoproducidomes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cCOSTOCPOPRODUCIDOMes), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cCOSTOCPOPRODUCIDOMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostocpoproducidomes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostocpoproducidomes_Visible, edtavCcostocpoproducidomes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00Z0.htm");
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
            GxWebStd.gx_div_start( context, divCostocpoproducidoanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostocpoproducidoanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostocpoproducidoanofilter_Internalname, "COSTOCPOPRODUCIDOAno", "", "", lblLblcostocpoproducidoanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Z0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostocpoproducidoano_Internalname, "COSTOCPOPRODUCIDOAno", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostocpoproducidoano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTOCPOPRODUCIDOAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostocpoproducidoano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cCOSTOCPOPRODUCIDOAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cCOSTOCPOPRODUCIDOAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostocpoproducidoano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostocpoproducidoano_Visible, edtavCcostocpoproducidoano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00Z0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblcod_areafilter_Internalname, "Cod_Area", "", "", lblLblcod_areafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Z0.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCcod_area_Internalname, AV9cCod_Area, StringUtil.RTrim( context.localUtil.Format( AV9cCod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcod_area_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcod_area_Visible, edtavCcod_area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00Z0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblindicadorescodigofilter_Internalname, "Indicadores Codigo", "", "", lblLblindicadorescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Z0.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCindicadorescodigo_Internalname, AV10cIndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( AV10cIndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCindicadorescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCindicadorescodigo_Visible, edtavCindicadorescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00Z0.htm");
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
            GxWebStd.gx_div_start( context, divTipoproductocodfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTipoproductocodfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltipoproductocodfilter_Internalname, "Tipo Producto Cod", "", "", lblLbltipoproductocodfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Z0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtipoproductocod_Internalname, "Tipo Producto Cod", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtipoproductocod_Internalname, AV11cTipoProductoCod, StringUtil.RTrim( context.localUtil.Format( AV11cTipoProductoCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtipoproductocod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtipoproductocod_Visible, edtavCtipoproductocod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00Z0.htm");
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
            GxWebStd.gx_div_start( context, divCostocpoproducidovalorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostocpoproducidovalorfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostocpoproducidovalorfilter_Internalname, "COSTOCPOPRODUCIDOValor", "", "", lblLblcostocpoproducidovalorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17141_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00Z0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostocpoproducidovalor_Internalname, "COSTOCPOPRODUCIDOValor", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostocpoproducidovalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV12cCOSTOCPOPRODUCIDOValor, 10, 2, ",", "")), StringUtil.LTrim( ((edtavCcostocpoproducidovalor_Enabled!=0) ? context.localUtil.Format( AV12cCOSTOCPOPRODUCIDOValor, "ZZZZZZ9.99") : context.localUtil.Format( AV12cCOSTOCPOPRODUCIDOValor, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostocpoproducidovalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostocpoproducidovalor_Visible, edtavCcostocpoproducidovalor_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00Z0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18141_client"+"'", TempTags, "", 2, "HLP_Gx00Z0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00Z0.htm");
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

      protected void START142( )
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
            Form.Meta.addItem("description", "Selection List COSTOCPOPRODUCIDO", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP140( ) ;
      }

      protected void WS142( )
      {
         START142( ) ;
         EVT142( ) ;
      }

      protected void EVT142( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV23Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A109COSTOCPOPRODUCIDOFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCOSTOCPOPRODUCIDOFecha_Internalname), 0));
                              A110COSTOCPOPRODUCIDOMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A111COSTOCPOPRODUCIDOAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A5Cod_Area = cgiGet( edtCod_Area_Internalname);
                              A191COSTOCPOPRODUCIDOValor = context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOValor_Internalname), ",", ".");
                              A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
                              A64TIPOSCPOCod = cgiGet( edtTIPOSCPOCod_Internalname);
                              A45TipoProductoCod = cgiGet( edtTipoProductoCod_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19142 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20142 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccostocpoproducidofecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCCOSTOCPOPRODUCIDOFECHA"), 0) != AV6cCOSTOCPOPRODUCIDOFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostocpoproducidomes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOCPOPRODUCIDOMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTOCPOPRODUCIDOMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostocpoproducidoano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOCPOPRODUCIDOANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTOCPOPRODUCIDOAno )) )
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
                                       /* Set Refresh If Ctipoproductocod Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCTIPOPRODUCTOCOD"), AV11cTipoProductoCod) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostocpoproducidovalor Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOCPOPRODUCIDOVALOR"), ",", ".") != AV12cCOSTOCPOPRODUCIDOValor )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21142 ();
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

      protected void WE142( )
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

      protected void PA142( )
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
                                        DateTime AV6cCOSTOCPOPRODUCIDOFecha ,
                                        short AV7cCOSTOCPOPRODUCIDOMes ,
                                        short AV8cCOSTOCPOPRODUCIDOAno ,
                                        string AV9cCod_Area ,
                                        string AV10cIndicadoresCodigo ,
                                        string AV11cTipoProductoCod ,
                                        decimal AV12cCOSTOCPOPRODUCIDOValor )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF142( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOCPOPRODUCIDOFECHA", GetSecureSignedToken( "", A109COSTOCPOPRODUCIDOFecha, context));
         GxWebStd.gx_hidden_field( context, "COSTOCPOPRODUCIDOFECHA", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOCPOPRODUCIDOMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A110COSTOCPOPRODUCIDOMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTOCPOPRODUCIDOMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOCPOPRODUCIDOANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A111COSTOCPOPRODUCIDOAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTOCPOPRODUCIDOANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "COD_AREA", A5Cod_Area);
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGO", A4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOSCPOCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A64TIPOSCPOCod, "")), context));
         GxWebStd.gx_hidden_field( context, "TIPOSCPOCOD", A64TIPOSCPOCod);
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOPRODUCTOCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A45TipoProductoCod, "")), context));
         GxWebStd.gx_hidden_field( context, "TIPOPRODUCTOCOD", A45TipoProductoCod);
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
         RF142( ) ;
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

      protected void RF142( )
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
                                                 AV12cCOSTOCPOPRODUCIDOValor ,
                                                 A191COSTOCPOPRODUCIDOValor ,
                                                 A5Cod_Area ,
                                                 AV9cCod_Area ,
                                                 A4IndicadoresCodigo ,
                                                 AV10cIndicadoresCodigo ,
                                                 A45TipoProductoCod ,
                                                 AV11cTipoProductoCod ,
                                                 AV6cCOSTOCPOPRODUCIDOFecha ,
                                                 AV7cCOSTOCPOPRODUCIDOMes ,
                                                 AV8cCOSTOCPOPRODUCIDOAno } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
            lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
            lV11cTipoProductoCod = StringUtil.Concat( StringUtil.RTrim( AV11cTipoProductoCod), "%", "");
            /* Using cursor H00142 */
            pr_default.execute(0, new Object[] {AV6cCOSTOCPOPRODUCIDOFecha, AV7cCOSTOCPOPRODUCIDOMes, AV8cCOSTOCPOPRODUCIDOAno, lV9cCod_Area, lV10cIndicadoresCodigo, lV11cTipoProductoCod, AV12cCOSTOCPOPRODUCIDOValor, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A45TipoProductoCod = H00142_A45TipoProductoCod[0];
               A64TIPOSCPOCod = H00142_A64TIPOSCPOCod[0];
               A4IndicadoresCodigo = H00142_A4IndicadoresCodigo[0];
               A191COSTOCPOPRODUCIDOValor = H00142_A191COSTOCPOPRODUCIDOValor[0];
               A5Cod_Area = H00142_A5Cod_Area[0];
               A111COSTOCPOPRODUCIDOAno = H00142_A111COSTOCPOPRODUCIDOAno[0];
               A110COSTOCPOPRODUCIDOMes = H00142_A110COSTOCPOPRODUCIDOMes[0];
               A109COSTOCPOPRODUCIDOFecha = H00142_A109COSTOCPOPRODUCIDOFecha[0];
               /* Execute user event: Load */
               E20142 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB140( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes142( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOCPOPRODUCIDOFECHA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A109COSTOCPOPRODUCIDOFecha, context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOCPOPRODUCIDOMES"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A110COSTOCPOPRODUCIDOMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOCPOPRODUCIDOANO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A111COSTOCPOPRODUCIDOAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOSCPOCOD"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A64TIPOSCPOCod, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOPRODUCTOCOD"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A45TipoProductoCod, "")), context));
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
                                              AV12cCOSTOCPOPRODUCIDOValor ,
                                              A191COSTOCPOPRODUCIDOValor ,
                                              A5Cod_Area ,
                                              AV9cCod_Area ,
                                              A4IndicadoresCodigo ,
                                              AV10cIndicadoresCodigo ,
                                              A45TipoProductoCod ,
                                              AV11cTipoProductoCod ,
                                              AV6cCOSTOCPOPRODUCIDOFecha ,
                                              AV7cCOSTOCPOPRODUCIDOMes ,
                                              AV8cCOSTOCPOPRODUCIDOAno } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
         lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
         lV11cTipoProductoCod = StringUtil.Concat( StringUtil.RTrim( AV11cTipoProductoCod), "%", "");
         /* Using cursor H00143 */
         pr_default.execute(1, new Object[] {AV6cCOSTOCPOPRODUCIDOFecha, AV7cCOSTOCPOPRODUCIDOMes, AV8cCOSTOCPOPRODUCIDOAno, lV9cCod_Area, lV10cIndicadoresCodigo, lV11cTipoProductoCod, AV12cCOSTOCPOPRODUCIDOValor});
         GRID1_nRecordCount = H00143_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOCPOPRODUCIDOFecha, AV7cCOSTOCPOPRODUCIDOMes, AV8cCOSTOCPOPRODUCIDOAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTipoProductoCod, AV12cCOSTOCPOPRODUCIDOValor) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOCPOPRODUCIDOFecha, AV7cCOSTOCPOPRODUCIDOMes, AV8cCOSTOCPOPRODUCIDOAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTipoProductoCod, AV12cCOSTOCPOPRODUCIDOValor) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOCPOPRODUCIDOFecha, AV7cCOSTOCPOPRODUCIDOMes, AV8cCOSTOCPOPRODUCIDOAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTipoProductoCod, AV12cCOSTOCPOPRODUCIDOValor) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOCPOPRODUCIDOFecha, AV7cCOSTOCPOPRODUCIDOMes, AV8cCOSTOCPOPRODUCIDOAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTipoProductoCod, AV12cCOSTOCPOPRODUCIDOValor) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOCPOPRODUCIDOFecha, AV7cCOSTOCPOPRODUCIDOMes, AV8cCOSTOCPOPRODUCIDOAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cTipoProductoCod, AV12cCOSTOCPOPRODUCIDOValor) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP140( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19142 ();
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
            if ( context.localUtil.VCDate( cgiGet( edtavCcostocpoproducidofecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTOCPOPRODUCIDOFecha"}), 1, "vCCOSTOCPOPRODUCIDOFECHA");
               GX_FocusControl = edtavCcostocpoproducidofecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCOSTOCPOPRODUCIDOFecha = DateTime.MinValue;
               AssignAttri("", false, "AV6cCOSTOCPOPRODUCIDOFecha", context.localUtil.Format(AV6cCOSTOCPOPRODUCIDOFecha, "99/99/99"));
            }
            else
            {
               AV6cCOSTOCPOPRODUCIDOFecha = context.localUtil.CToD( cgiGet( edtavCcostocpoproducidofecha_Internalname), 2);
               AssignAttri("", false, "AV6cCOSTOCPOPRODUCIDOFecha", context.localUtil.Format(AV6cCOSTOCPOPRODUCIDOFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostocpoproducidomes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostocpoproducidomes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTOCPOPRODUCIDOMES");
               GX_FocusControl = edtavCcostocpoproducidomes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cCOSTOCPOPRODUCIDOMes = 0;
               AssignAttri("", false, "AV7cCOSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(AV7cCOSTOCPOPRODUCIDOMes), 4, 0));
            }
            else
            {
               AV7cCOSTOCPOPRODUCIDOMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostocpoproducidomes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cCOSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(AV7cCOSTOCPOPRODUCIDOMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostocpoproducidoano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostocpoproducidoano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTOCPOPRODUCIDOANO");
               GX_FocusControl = edtavCcostocpoproducidoano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cCOSTOCPOPRODUCIDOAno = 0;
               AssignAttri("", false, "AV8cCOSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(AV8cCOSTOCPOPRODUCIDOAno), 4, 0));
            }
            else
            {
               AV8cCOSTOCPOPRODUCIDOAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostocpoproducidoano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cCOSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(AV8cCOSTOCPOPRODUCIDOAno), 4, 0));
            }
            AV9cCod_Area = cgiGet( edtavCcod_area_Internalname);
            AssignAttri("", false, "AV9cCod_Area", AV9cCod_Area);
            AV10cIndicadoresCodigo = cgiGet( edtavCindicadorescodigo_Internalname);
            AssignAttri("", false, "AV10cIndicadoresCodigo", AV10cIndicadoresCodigo);
            AV11cTipoProductoCod = cgiGet( edtavCtipoproductocod_Internalname);
            AssignAttri("", false, "AV11cTipoProductoCod", AV11cTipoProductoCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostocpoproducidovalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostocpoproducidovalor_Internalname), ",", ".") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTOCPOPRODUCIDOVALOR");
               GX_FocusControl = edtavCcostocpoproducidovalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cCOSTOCPOPRODUCIDOValor = 0;
               AssignAttri("", false, "AV12cCOSTOCPOPRODUCIDOValor", StringUtil.LTrimStr( AV12cCOSTOCPOPRODUCIDOValor, 10, 2));
            }
            else
            {
               AV12cCOSTOCPOPRODUCIDOValor = context.localUtil.CToN( cgiGet( edtavCcostocpoproducidovalor_Internalname), ",", ".");
               AssignAttri("", false, "AV12cCOSTOCPOPRODUCIDOValor", StringUtil.LTrimStr( AV12cCOSTOCPOPRODUCIDOValor, 10, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCCOSTOCPOPRODUCIDOFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV6cCOSTOCPOPRODUCIDOFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOCPOPRODUCIDOMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTOCPOPRODUCIDOMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOCPOPRODUCIDOANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTOCPOPRODUCIDOAno )) )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCTIPOPRODUCTOCOD"), AV11cTipoProductoCod) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOCPOPRODUCIDOVALOR"), ",", ".") != AV12cCOSTOCPOPRODUCIDOValor )
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
         E19142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19142( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selecci�n %1", "COSTOCPOPRODUCIDO", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV20ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20142( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV23Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E21142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21142( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pCOSTOCPOPRODUCIDOFecha = A109COSTOCPOPRODUCIDOFecha;
         AssignAttri("", false, "AV13pCOSTOCPOPRODUCIDOFecha", context.localUtil.Format(AV13pCOSTOCPOPRODUCIDOFecha, "99/99/99"));
         AV14pCOSTOCPOPRODUCIDOMes = A110COSTOCPOPRODUCIDOMes;
         AssignAttri("", false, "AV14pCOSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTOCPOPRODUCIDOMes), 4, 0));
         AV15pCOSTOCPOPRODUCIDOAno = A111COSTOCPOPRODUCIDOAno;
         AssignAttri("", false, "AV15pCOSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTOCPOPRODUCIDOAno), 4, 0));
         AV16pCod_Area = A5Cod_Area;
         AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
         AV17pIndicadoresCodigo = A4IndicadoresCodigo;
         AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
         AV18pTIPOSCPOCod = A64TIPOSCPOCod;
         AssignAttri("", false, "AV18pTIPOSCPOCod", AV18pTIPOSCPOCod);
         AV19pTipoProductoCod = A45TipoProductoCod;
         AssignAttri("", false, "AV19pTipoProductoCod", AV19pTipoProductoCod);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV13pCOSTOCPOPRODUCIDOFecha, "99/99/99"),(short)AV14pCOSTOCPOPRODUCIDOMes,(short)AV15pCOSTOCPOPRODUCIDOAno,(string)AV16pCod_Area,(string)AV17pIndicadoresCodigo,(string)AV18pTIPOSCPOCod,(string)AV19pTipoProductoCod});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pCOSTOCPOPRODUCIDOFecha","AV14pCOSTOCPOPRODUCIDOMes","AV15pCOSTOCPOPRODUCIDOAno","AV16pCod_Area","AV17pIndicadoresCodigo","AV18pTIPOSCPOCod","AV19pTipoProductoCod"});
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
         AV13pCOSTOCPOPRODUCIDOFecha = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV13pCOSTOCPOPRODUCIDOFecha", context.localUtil.Format(AV13pCOSTOCPOPRODUCIDOFecha, "99/99/99"));
         AV14pCOSTOCPOPRODUCIDOMes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV14pCOSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTOCPOPRODUCIDOMes), 4, 0));
         AV15pCOSTOCPOPRODUCIDOAno = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV15pCOSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTOCPOPRODUCIDOAno), 4, 0));
         AV16pCod_Area = (string)getParm(obj,3);
         AssignAttri("", false, "AV16pCod_Area", AV16pCod_Area);
         AV17pIndicadoresCodigo = (string)getParm(obj,4);
         AssignAttri("", false, "AV17pIndicadoresCodigo", AV17pIndicadoresCodigo);
         AV18pTIPOSCPOCod = (string)getParm(obj,5);
         AssignAttri("", false, "AV18pTIPOSCPOCod", AV18pTIPOSCPOCod);
         AV19pTipoProductoCod = (string)getParm(obj,6);
         AssignAttri("", false, "AV19pTipoProductoCod", AV19pTipoProductoCod);
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
         PA142( ) ;
         WS142( ) ;
         WE142( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231025412", true, true);
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
         context.AddJavascriptSource("gx00z0.js", "?20247231025412", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtCOSTOCPOPRODUCIDOFecha_Internalname = "COSTOCPOPRODUCIDOFECHA_"+sGXsfl_84_idx;
         edtCOSTOCPOPRODUCIDOMes_Internalname = "COSTOCPOPRODUCIDOMES_"+sGXsfl_84_idx;
         edtCOSTOCPOPRODUCIDOAno_Internalname = "COSTOCPOPRODUCIDOANO_"+sGXsfl_84_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_idx;
         edtCOSTOCPOPRODUCIDOValor_Internalname = "COSTOCPOPRODUCIDOVALOR_"+sGXsfl_84_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_idx;
         edtTIPOSCPOCod_Internalname = "TIPOSCPOCOD_"+sGXsfl_84_idx;
         edtTipoProductoCod_Internalname = "TIPOPRODUCTOCOD_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtCOSTOCPOPRODUCIDOFecha_Internalname = "COSTOCPOPRODUCIDOFECHA_"+sGXsfl_84_fel_idx;
         edtCOSTOCPOPRODUCIDOMes_Internalname = "COSTOCPOPRODUCIDOMES_"+sGXsfl_84_fel_idx;
         edtCOSTOCPOPRODUCIDOAno_Internalname = "COSTOCPOPRODUCIDOANO_"+sGXsfl_84_fel_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_fel_idx;
         edtCOSTOCPOPRODUCIDOValor_Internalname = "COSTOCPOPRODUCIDOVALOR_"+sGXsfl_84_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_fel_idx;
         edtTIPOSCPOCod_Internalname = "TIPOSCPOCOD_"+sGXsfl_84_fel_idx;
         edtTipoProductoCod_Internalname = "TIPOPRODUCTOCOD_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB140( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A64TIPOSCPOCod)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A45TipoProductoCod)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV23Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV23Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOCPOPRODUCIDOFecha_Internalname,context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"),context.localUtil.Format( A109COSTOCPOPRODUCIDOFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTOCPOPRODUCIDOFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOCPOPRODUCIDOMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A110COSTOCPOPRODUCIDOMes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTOCPOPRODUCIDOMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOCPOPRODUCIDOAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A111COSTOCPOPRODUCIDOAno), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTOCPOPRODUCIDOAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
            edtCOSTOCPOPRODUCIDOValor_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A64TIPOSCPOCod)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A45TipoProductoCod)+"'"+"]);";
            AssignProp("", false, edtCOSTOCPOPRODUCIDOValor_Internalname, "Link", edtCOSTOCPOPRODUCIDOValor_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOCPOPRODUCIDOValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A191COSTOCPOPRODUCIDOValor, 10, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A191COSTOCPOPRODUCIDOValor, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCOSTOCPOPRODUCIDOValor_Link,(string)"",(string)"",(string)"",(string)edtCOSTOCPOPRODUCIDOValor_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTIPOSCPOCod_Internalname,(string)A64TIPOSCPOCod,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTIPOSCPOCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoProductoCod_Internalname,(string)A45TipoProductoCod,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoProductoCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes142( ) ;
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
            context.SendWebValue( "COSTOCPOPRODUCIDOFecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTOCPOPRODUCIDOMes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTOCPOPRODUCIDOAno") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cod_Area") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTOCPOPRODUCIDOValor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Codigo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "TIPOSCPOCod") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tipo Producto Cod") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A5Cod_Area));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A191COSTOCPOPRODUCIDOValor, 10, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCOSTOCPOPRODUCIDOValor_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A4IndicadoresCodigo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A64TIPOSCPOCod));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A45TipoProductoCod));
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
         lblLblcostocpoproducidofechafilter_Internalname = "LBLCOSTOCPOPRODUCIDOFECHAFILTER";
         edtavCcostocpoproducidofecha_Internalname = "vCCOSTOCPOPRODUCIDOFECHA";
         divCostocpoproducidofechafiltercontainer_Internalname = "COSTOCPOPRODUCIDOFECHAFILTERCONTAINER";
         lblLblcostocpoproducidomesfilter_Internalname = "LBLCOSTOCPOPRODUCIDOMESFILTER";
         edtavCcostocpoproducidomes_Internalname = "vCCOSTOCPOPRODUCIDOMES";
         divCostocpoproducidomesfiltercontainer_Internalname = "COSTOCPOPRODUCIDOMESFILTERCONTAINER";
         lblLblcostocpoproducidoanofilter_Internalname = "LBLCOSTOCPOPRODUCIDOANOFILTER";
         edtavCcostocpoproducidoano_Internalname = "vCCOSTOCPOPRODUCIDOANO";
         divCostocpoproducidoanofiltercontainer_Internalname = "COSTOCPOPRODUCIDOANOFILTERCONTAINER";
         lblLblcod_areafilter_Internalname = "LBLCOD_AREAFILTER";
         edtavCcod_area_Internalname = "vCCOD_AREA";
         divCod_areafiltercontainer_Internalname = "COD_AREAFILTERCONTAINER";
         lblLblindicadorescodigofilter_Internalname = "LBLINDICADORESCODIGOFILTER";
         edtavCindicadorescodigo_Internalname = "vCINDICADORESCODIGO";
         divIndicadorescodigofiltercontainer_Internalname = "INDICADORESCODIGOFILTERCONTAINER";
         lblLbltipoproductocodfilter_Internalname = "LBLTIPOPRODUCTOCODFILTER";
         edtavCtipoproductocod_Internalname = "vCTIPOPRODUCTOCOD";
         divTipoproductocodfiltercontainer_Internalname = "TIPOPRODUCTOCODFILTERCONTAINER";
         lblLblcostocpoproducidovalorfilter_Internalname = "LBLCOSTOCPOPRODUCIDOVALORFILTER";
         edtavCcostocpoproducidovalor_Internalname = "vCCOSTOCPOPRODUCIDOVALOR";
         divCostocpoproducidovalorfiltercontainer_Internalname = "COSTOCPOPRODUCIDOVALORFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCOSTOCPOPRODUCIDOFecha_Internalname = "COSTOCPOPRODUCIDOFECHA";
         edtCOSTOCPOPRODUCIDOMes_Internalname = "COSTOCPOPRODUCIDOMES";
         edtCOSTOCPOPRODUCIDOAno_Internalname = "COSTOCPOPRODUCIDOANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtCOSTOCPOPRODUCIDOValor_Internalname = "COSTOCPOPRODUCIDOVALOR";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtTIPOSCPOCod_Internalname = "TIPOSCPOCOD";
         edtTipoProductoCod_Internalname = "TIPOPRODUCTOCOD";
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
         edtTipoProductoCod_Jsonclick = "";
         edtTIPOSCPOCod_Jsonclick = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOValor_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOValor_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOAno_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOMes_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOFecha_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCcostocpoproducidovalor_Jsonclick = "";
         edtavCcostocpoproducidovalor_Enabled = 1;
         edtavCcostocpoproducidovalor_Visible = 1;
         edtavCtipoproductocod_Jsonclick = "";
         edtavCtipoproductocod_Enabled = 1;
         edtavCtipoproductocod_Visible = 1;
         edtavCindicadorescodigo_Jsonclick = "";
         edtavCindicadorescodigo_Enabled = 1;
         edtavCindicadorescodigo_Visible = 1;
         edtavCcod_area_Jsonclick = "";
         edtavCcod_area_Enabled = 1;
         edtavCcod_area_Visible = 1;
         edtavCcostocpoproducidoano_Jsonclick = "";
         edtavCcostocpoproducidoano_Enabled = 1;
         edtavCcostocpoproducidoano_Visible = 1;
         edtavCcostocpoproducidomes_Jsonclick = "";
         edtavCcostocpoproducidomes_Enabled = 1;
         edtavCcostocpoproducidomes_Visible = 1;
         edtavCcostocpoproducidofecha_Jsonclick = "";
         edtavCcostocpoproducidofecha_Enabled = 1;
         divCostocpoproducidovalorfiltercontainer_Class = "AdvancedContainerItem";
         divTipoproductocodfiltercontainer_Class = "AdvancedContainerItem";
         divIndicadorescodigofiltercontainer_Class = "AdvancedContainerItem";
         divCod_areafiltercontainer_Class = "AdvancedContainerItem";
         divCostocpoproducidoanofiltercontainer_Class = "AdvancedContainerItem";
         divCostocpoproducidomesfiltercontainer_Class = "AdvancedContainerItem";
         divCostocpoproducidofechafiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List COSTOCPOPRODUCIDO";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOCPOPRODUCIDOFecha',fld:'vCCOSTOCPOPRODUCIDOFECHA',pic:''},{av:'AV7cCOSTOCPOPRODUCIDOMes',fld:'vCCOSTOCPOPRODUCIDOMES',pic:'ZZZ9'},{av:'AV8cCOSTOCPOPRODUCIDOAno',fld:'vCCOSTOCPOPRODUCIDOANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cTipoProductoCod',fld:'vCTIPOPRODUCTOCOD',pic:''},{av:'AV12cCOSTOCPOPRODUCIDOValor',fld:'vCCOSTOCPOPRODUCIDOVALOR',pic:'ZZZZZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18141',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCOSTOCPOPRODUCIDOFECHAFILTER.CLICK","{handler:'E11141',iparms:[{av:'divCostocpoproducidofechafiltercontainer_Class',ctrl:'COSTOCPOPRODUCIDOFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOCPOPRODUCIDOFECHAFILTER.CLICK",",oparms:[{av:'divCostocpoproducidofechafiltercontainer_Class',ctrl:'COSTOCPOPRODUCIDOFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLCOSTOCPOPRODUCIDOMESFILTER.CLICK","{handler:'E12141',iparms:[{av:'divCostocpoproducidomesfiltercontainer_Class',ctrl:'COSTOCPOPRODUCIDOMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOCPOPRODUCIDOMESFILTER.CLICK",",oparms:[{av:'divCostocpoproducidomesfiltercontainer_Class',ctrl:'COSTOCPOPRODUCIDOMESFILTERCONTAINER',prop:'Class'},{av:'edtavCcostocpoproducidomes_Visible',ctrl:'vCCOSTOCPOPRODUCIDOMES',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTOCPOPRODUCIDOANOFILTER.CLICK","{handler:'E13141',iparms:[{av:'divCostocpoproducidoanofiltercontainer_Class',ctrl:'COSTOCPOPRODUCIDOANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOCPOPRODUCIDOANOFILTER.CLICK",",oparms:[{av:'divCostocpoproducidoanofiltercontainer_Class',ctrl:'COSTOCPOPRODUCIDOANOFILTERCONTAINER',prop:'Class'},{av:'edtavCcostocpoproducidoano_Visible',ctrl:'vCCOSTOCPOPRODUCIDOANO',prop:'Visible'}]}");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK","{handler:'E14141',iparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK",",oparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'},{av:'edtavCcod_area_Visible',ctrl:'vCCOD_AREA',prop:'Visible'}]}");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK","{handler:'E15141',iparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK",",oparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCindicadorescodigo_Visible',ctrl:'vCINDICADORESCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLTIPOPRODUCTOCODFILTER.CLICK","{handler:'E16141',iparms:[{av:'divTipoproductocodfiltercontainer_Class',ctrl:'TIPOPRODUCTOCODFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTIPOPRODUCTOCODFILTER.CLICK",",oparms:[{av:'divTipoproductocodfiltercontainer_Class',ctrl:'TIPOPRODUCTOCODFILTERCONTAINER',prop:'Class'},{av:'edtavCtipoproductocod_Visible',ctrl:'vCTIPOPRODUCTOCOD',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTOCPOPRODUCIDOVALORFILTER.CLICK","{handler:'E17141',iparms:[{av:'divCostocpoproducidovalorfiltercontainer_Class',ctrl:'COSTOCPOPRODUCIDOVALORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOCPOPRODUCIDOVALORFILTER.CLICK",",oparms:[{av:'divCostocpoproducidovalorfiltercontainer_Class',ctrl:'COSTOCPOPRODUCIDOVALORFILTERCONTAINER',prop:'Class'},{av:'edtavCcostocpoproducidovalor_Visible',ctrl:'vCCOSTOCPOPRODUCIDOVALOR',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21142',iparms:[{av:'A109COSTOCPOPRODUCIDOFecha',fld:'COSTOCPOPRODUCIDOFECHA',pic:'',hsh:true},{av:'A110COSTOCPOPRODUCIDOMes',fld:'COSTOCPOPRODUCIDOMES',pic:'ZZZ9',hsh:true},{av:'A111COSTOCPOPRODUCIDOAno',fld:'COSTOCPOPRODUCIDOANO',pic:'ZZZ9',hsh:true},{av:'A5Cod_Area',fld:'COD_AREA',pic:'',hsh:true},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:'',hsh:true},{av:'A64TIPOSCPOCod',fld:'TIPOSCPOCOD',pic:'',hsh:true},{av:'A45TipoProductoCod',fld:'TIPOPRODUCTOCOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pCOSTOCPOPRODUCIDOFecha',fld:'vPCOSTOCPOPRODUCIDOFECHA',pic:''},{av:'AV14pCOSTOCPOPRODUCIDOMes',fld:'vPCOSTOCPOPRODUCIDOMES',pic:'ZZZ9'},{av:'AV15pCOSTOCPOPRODUCIDOAno',fld:'vPCOSTOCPOPRODUCIDOANO',pic:'ZZZ9'},{av:'AV16pCod_Area',fld:'vPCOD_AREA',pic:''},{av:'AV17pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV18pTIPOSCPOCod',fld:'vPTIPOSCPOCOD',pic:''},{av:'AV19pTipoProductoCod',fld:'vPTIPOPRODUCTOCOD',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOCPOPRODUCIDOFecha',fld:'vCCOSTOCPOPRODUCIDOFECHA',pic:''},{av:'AV7cCOSTOCPOPRODUCIDOMes',fld:'vCCOSTOCPOPRODUCIDOMES',pic:'ZZZ9'},{av:'AV8cCOSTOCPOPRODUCIDOAno',fld:'vCCOSTOCPOPRODUCIDOANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cTipoProductoCod',fld:'vCTIPOPRODUCTOCOD',pic:''},{av:'AV12cCOSTOCPOPRODUCIDOValor',fld:'vCCOSTOCPOPRODUCIDOVALOR',pic:'ZZZZZZ9.99'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOCPOPRODUCIDOFecha',fld:'vCCOSTOCPOPRODUCIDOFECHA',pic:''},{av:'AV7cCOSTOCPOPRODUCIDOMes',fld:'vCCOSTOCPOPRODUCIDOMES',pic:'ZZZ9'},{av:'AV8cCOSTOCPOPRODUCIDOAno',fld:'vCCOSTOCPOPRODUCIDOANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cTipoProductoCod',fld:'vCTIPOPRODUCTOCOD',pic:''},{av:'AV12cCOSTOCPOPRODUCIDOValor',fld:'vCCOSTOCPOPRODUCIDOVALOR',pic:'ZZZZZZ9.99'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOCPOPRODUCIDOFecha',fld:'vCCOSTOCPOPRODUCIDOFECHA',pic:''},{av:'AV7cCOSTOCPOPRODUCIDOMes',fld:'vCCOSTOCPOPRODUCIDOMES',pic:'ZZZ9'},{av:'AV8cCOSTOCPOPRODUCIDOAno',fld:'vCCOSTOCPOPRODUCIDOANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cTipoProductoCod',fld:'vCTIPOPRODUCTOCOD',pic:''},{av:'AV12cCOSTOCPOPRODUCIDOValor',fld:'vCCOSTOCPOPRODUCIDOVALOR',pic:'ZZZZZZ9.99'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOCPOPRODUCIDOFecha',fld:'vCCOSTOCPOPRODUCIDOFECHA',pic:''},{av:'AV7cCOSTOCPOPRODUCIDOMes',fld:'vCCOSTOCPOPRODUCIDOMES',pic:'ZZZ9'},{av:'AV8cCOSTOCPOPRODUCIDOAno',fld:'vCCOSTOCPOPRODUCIDOANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cTipoProductoCod',fld:'vCTIPOPRODUCTOCOD',pic:''},{av:'AV12cCOSTOCPOPRODUCIDOValor',fld:'vCCOSTOCPOPRODUCIDOVALOR',pic:'ZZZZZZ9.99'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCOSTOCPOPRODUCIDOFECHA","{handler:'Validv_Ccostocpoproducidofecha',iparms:[]");
         setEventMetadata("VALIDV_CCOSTOCPOPRODUCIDOFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tipoproductocod',iparms:[]");
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
         AV13pCOSTOCPOPRODUCIDOFecha = DateTime.MinValue;
         AV16pCod_Area = "";
         AV17pIndicadoresCodigo = "";
         AV18pTIPOSCPOCod = "";
         AV19pTipoProductoCod = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cCOSTOCPOPRODUCIDOFecha = DateTime.MinValue;
         AV9cCod_Area = "";
         AV10cIndicadoresCodigo = "";
         AV11cTipoProductoCod = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcostocpoproducidofechafilter_Jsonclick = "";
         TempTags = "";
         lblLblcostocpoproducidomesfilter_Jsonclick = "";
         lblLblcostocpoproducidoanofilter_Jsonclick = "";
         lblLblcod_areafilter_Jsonclick = "";
         lblLblindicadorescodigofilter_Jsonclick = "";
         lblLbltipoproductocodfilter_Jsonclick = "";
         lblLblcostocpoproducidovalorfilter_Jsonclick = "";
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
         AV23Linkselection_GXI = "";
         A109COSTOCPOPRODUCIDOFecha = DateTime.MinValue;
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A64TIPOSCPOCod = "";
         A45TipoProductoCod = "";
         scmdbuf = "";
         lV9cCod_Area = "";
         lV10cIndicadoresCodigo = "";
         lV11cTipoProductoCod = "";
         H00142_A45TipoProductoCod = new string[] {""} ;
         H00142_A64TIPOSCPOCod = new string[] {""} ;
         H00142_A4IndicadoresCodigo = new string[] {""} ;
         H00142_A191COSTOCPOPRODUCIDOValor = new decimal[1] ;
         H00142_A5Cod_Area = new string[] {""} ;
         H00142_A111COSTOCPOPRODUCIDOAno = new short[1] ;
         H00142_A110COSTOCPOPRODUCIDOMes = new short[1] ;
         H00142_A109COSTOCPOPRODUCIDOFecha = new DateTime[] {DateTime.MinValue} ;
         H00143_AGRID1_nRecordCount = new long[1] ;
         AV20ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00z0__default(),
            new Object[][] {
                new Object[] {
               H00142_A45TipoProductoCod, H00142_A64TIPOSCPOCod, H00142_A4IndicadoresCodigo, H00142_A191COSTOCPOPRODUCIDOValor, H00142_A5Cod_Area, H00142_A111COSTOCPOPRODUCIDOAno, H00142_A110COSTOCPOPRODUCIDOMes, H00142_A109COSTOCPOPRODUCIDOFecha
               }
               , new Object[] {
               H00143_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14pCOSTOCPOPRODUCIDOMes ;
      private short AV15pCOSTOCPOPRODUCIDOAno ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cCOSTOCPOPRODUCIDOMes ;
      private short AV8cCOSTOCPOPRODUCIDOAno ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A110COSTOCPOPRODUCIDOMes ;
      private short A111COSTOCPOPRODUCIDOAno ;
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
      private int edtavCcostocpoproducidofecha_Enabled ;
      private int edtavCcostocpoproducidomes_Enabled ;
      private int edtavCcostocpoproducidomes_Visible ;
      private int edtavCcostocpoproducidoano_Enabled ;
      private int edtavCcostocpoproducidoano_Visible ;
      private int edtavCcod_area_Visible ;
      private int edtavCcod_area_Enabled ;
      private int edtavCindicadorescodigo_Visible ;
      private int edtavCindicadorescodigo_Enabled ;
      private int edtavCtipoproductocod_Visible ;
      private int edtavCtipoproductocod_Enabled ;
      private int edtavCcostocpoproducidovalor_Enabled ;
      private int edtavCcostocpoproducidovalor_Visible ;
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
      private decimal AV12cCOSTOCPOPRODUCIDOValor ;
      private decimal A191COSTOCPOPRODUCIDOValor ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCostocpoproducidofechafiltercontainer_Class ;
      private string divCostocpoproducidomesfiltercontainer_Class ;
      private string divCostocpoproducidoanofiltercontainer_Class ;
      private string divCod_areafiltercontainer_Class ;
      private string divIndicadorescodigofiltercontainer_Class ;
      private string divTipoproductocodfiltercontainer_Class ;
      private string divCostocpoproducidovalorfiltercontainer_Class ;
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
      private string divCostocpoproducidofechafiltercontainer_Internalname ;
      private string lblLblcostocpoproducidofechafilter_Internalname ;
      private string lblLblcostocpoproducidofechafilter_Jsonclick ;
      private string edtavCcostocpoproducidofecha_Internalname ;
      private string TempTags ;
      private string edtavCcostocpoproducidofecha_Jsonclick ;
      private string divCostocpoproducidomesfiltercontainer_Internalname ;
      private string lblLblcostocpoproducidomesfilter_Internalname ;
      private string lblLblcostocpoproducidomesfilter_Jsonclick ;
      private string edtavCcostocpoproducidomes_Internalname ;
      private string edtavCcostocpoproducidomes_Jsonclick ;
      private string divCostocpoproducidoanofiltercontainer_Internalname ;
      private string lblLblcostocpoproducidoanofilter_Internalname ;
      private string lblLblcostocpoproducidoanofilter_Jsonclick ;
      private string edtavCcostocpoproducidoano_Internalname ;
      private string edtavCcostocpoproducidoano_Jsonclick ;
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
      private string divTipoproductocodfiltercontainer_Internalname ;
      private string lblLbltipoproductocodfilter_Internalname ;
      private string lblLbltipoproductocodfilter_Jsonclick ;
      private string edtavCtipoproductocod_Internalname ;
      private string edtavCtipoproductocod_Jsonclick ;
      private string divCostocpoproducidovalorfiltercontainer_Internalname ;
      private string lblLblcostocpoproducidovalorfilter_Internalname ;
      private string lblLblcostocpoproducidovalorfilter_Jsonclick ;
      private string edtavCcostocpoproducidovalor_Internalname ;
      private string edtavCcostocpoproducidovalor_Jsonclick ;
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
      private string edtCOSTOCPOPRODUCIDOFecha_Internalname ;
      private string edtCOSTOCPOPRODUCIDOMes_Internalname ;
      private string edtCOSTOCPOPRODUCIDOAno_Internalname ;
      private string edtCod_Area_Internalname ;
      private string edtCOSTOCPOPRODUCIDOValor_Internalname ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtTIPOSCPOCod_Internalname ;
      private string edtTipoProductoCod_Internalname ;
      private string scmdbuf ;
      private string AV20ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCOSTOCPOPRODUCIDOFecha_Jsonclick ;
      private string edtCOSTOCPOPRODUCIDOMes_Jsonclick ;
      private string edtCOSTOCPOPRODUCIDOAno_Jsonclick ;
      private string edtCod_Area_Jsonclick ;
      private string edtCOSTOCPOPRODUCIDOValor_Link ;
      private string edtCOSTOCPOPRODUCIDOValor_Jsonclick ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string edtTIPOSCPOCod_Jsonclick ;
      private string edtTipoProductoCod_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV13pCOSTOCPOPRODUCIDOFecha ;
      private DateTime AV6cCOSTOCPOPRODUCIDOFecha ;
      private DateTime A109COSTOCPOPRODUCIDOFecha ;
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
      private string AV18pTIPOSCPOCod ;
      private string AV19pTipoProductoCod ;
      private string AV9cCod_Area ;
      private string AV10cIndicadoresCodigo ;
      private string AV11cTipoProductoCod ;
      private string AV23Linkselection_GXI ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A64TIPOSCPOCod ;
      private string A45TipoProductoCod ;
      private string lV9cCod_Area ;
      private string lV10cIndicadoresCodigo ;
      private string lV11cTipoProductoCod ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00142_A45TipoProductoCod ;
      private string[] H00142_A64TIPOSCPOCod ;
      private string[] H00142_A4IndicadoresCodigo ;
      private decimal[] H00142_A191COSTOCPOPRODUCIDOValor ;
      private string[] H00142_A5Cod_Area ;
      private short[] H00142_A111COSTOCPOPRODUCIDOAno ;
      private short[] H00142_A110COSTOCPOPRODUCIDOMes ;
      private DateTime[] H00142_A109COSTOCPOPRODUCIDOFecha ;
      private long[] H00143_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP0_pCOSTOCPOPRODUCIDOFecha ;
      private short aP1_pCOSTOCPOPRODUCIDOMes ;
      private short aP2_pCOSTOCPOPRODUCIDOAno ;
      private string aP3_pCod_Area ;
      private string aP4_pIndicadoresCodigo ;
      private string aP5_pTIPOSCPOCod ;
      private string aP6_pTipoProductoCod ;
      private GXWebForm Form ;
   }

   public class gx00z0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00142( IGxContext context ,
                                             decimal AV12cCOSTOCPOPRODUCIDOValor ,
                                             decimal A191COSTOCPOPRODUCIDOValor ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             string A45TipoProductoCod ,
                                             string AV11cTipoProductoCod ,
                                             DateTime AV6cCOSTOCPOPRODUCIDOFecha ,
                                             short AV7cCOSTOCPOPRODUCIDOMes ,
                                             short AV8cCOSTOCPOPRODUCIDOAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [TipoProductoCod], [TIPOSCPOCod], [IndicadoresCodigo], [COSTOCPOPRODUCIDOValor], [Cod_Area], [COSTOCPOPRODUCIDOAno], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOFecha]";
         sFromString = " FROM [COSTOCPOPRODUCIDO]";
         sOrderString = "";
         AddWhere(sWhereString, "([COSTOCPOPRODUCIDOFecha] >= @AV6cCOSTOCPOPRODUCIDOFecha and [COSTOCPOPRODUCIDOMes] >= @AV7cCOSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOAno] >= @AV8cCOSTOCPOPRODUCIDOAno)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         AddWhere(sWhereString, "([TipoProductoCod] like @lV11cTipoProductoCod)");
         if ( ! (Convert.ToDecimal(0)==AV12cCOSTOCPOPRODUCIDOValor) )
         {
            AddWhere(sWhereString, "([COSTOCPOPRODUCIDOValor] >= @AV12cCOSTOCPOPRODUCIDOValor)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00143( IGxContext context ,
                                             decimal AV12cCOSTOCPOPRODUCIDOValor ,
                                             decimal A191COSTOCPOPRODUCIDOValor ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             string A45TipoProductoCod ,
                                             string AV11cTipoProductoCod ,
                                             DateTime AV6cCOSTOCPOPRODUCIDOFecha ,
                                             short AV7cCOSTOCPOPRODUCIDOMes ,
                                             short AV8cCOSTOCPOPRODUCIDOAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [COSTOCPOPRODUCIDO]";
         AddWhere(sWhereString, "([COSTOCPOPRODUCIDOFecha] >= @AV6cCOSTOCPOPRODUCIDOFecha and [COSTOCPOPRODUCIDOMes] >= @AV7cCOSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOAno] >= @AV8cCOSTOCPOPRODUCIDOAno)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         AddWhere(sWhereString, "([TipoProductoCod] like @lV11cTipoProductoCod)");
         if ( ! (Convert.ToDecimal(0)==AV12cCOSTOCPOPRODUCIDOValor) )
         {
            AddWhere(sWhereString, "([COSTOCPOPRODUCIDOValor] >= @AV12cCOSTOCPOPRODUCIDOValor)");
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
                     return conditional_H00142(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H00143(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmH00142;
          prmH00142 = new Object[] {
          new ParDef("@AV6cCOSTOCPOPRODUCIDOFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTOCPOPRODUCIDOMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTOCPOPRODUCIDOAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@lV11cTipoProductoCod",GXType.NVarChar,40,0) ,
          new ParDef("@AV12cCOSTOCPOPRODUCIDOValor",GXType.Decimal,10,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00143;
          prmH00143 = new Object[] {
          new ParDef("@AV6cCOSTOCPOPRODUCIDOFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTOCPOPRODUCIDOMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTOCPOPRODUCIDOAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@lV11cTipoProductoCod",GXType.NVarChar,40,0) ,
          new ParDef("@AV12cCOSTOCPOPRODUCIDOValor",GXType.Decimal,10,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00142", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00142,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00143", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00143,1, GxCacheFrequency.OFF ,false,false )
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
