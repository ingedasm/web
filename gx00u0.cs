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
   public class gx00u0 : GXDataArea
   {
      public gx00u0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx00u0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out DateTime aP0_pCOSTONRFFPRODfec ,
                           out short aP1_pCOSTONRFFPRODmes ,
                           out short aP2_pCOSTONRFFPRODano ,
                           out string aP3_pCod_Area ,
                           out string aP4_pIndicadoresCodigo )
      {
         this.AV12pCOSTONRFFPRODfec = DateTime.MinValue ;
         this.AV13pCOSTONRFFPRODmes = 0 ;
         this.AV14pCOSTONRFFPRODano = 0 ;
         this.AV15pCod_Area = "" ;
         this.AV16pIndicadoresCodigo = "" ;
         executePrivate();
         aP0_pCOSTONRFFPRODfec=this.AV12pCOSTONRFFPRODfec;
         aP1_pCOSTONRFFPRODmes=this.AV13pCOSTONRFFPRODmes;
         aP2_pCOSTONRFFPRODano=this.AV14pCOSTONRFFPRODano;
         aP3_pCod_Area=this.AV15pCod_Area;
         aP4_pIndicadoresCodigo=this.AV16pIndicadoresCodigo;
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
            gxfirstwebparm = GetFirstPar( "pCOSTONRFFPRODfec");
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
               gxfirstwebparm = GetFirstPar( "pCOSTONRFFPRODfec");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCOSTONRFFPRODfec");
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
               AV12pCOSTONRFFPRODfec = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV12pCOSTONRFFPRODfec", context.localUtil.Format(AV12pCOSTONRFFPRODfec, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pCOSTONRFFPRODmes = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTONRFFPRODmes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pCOSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(AV13pCOSTONRFFPRODmes), 4, 0));
                  AV14pCOSTONRFFPRODano = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTONRFFPRODano"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pCOSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(AV14pCOSTONRFFPRODano), 4, 0));
                  AV15pCod_Area = GetPar( "pCod_Area");
                  AssignAttri("", false, "AV15pCod_Area", AV15pCod_Area);
                  AV16pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
                  AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
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
         nRC_GXsfl_74 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
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
         AV6cCOSTONRFFPRODfec = context.localUtil.ParseDateParm( GetPar( "cCOSTONRFFPRODfec"));
         AV7cCOSTONRFFPRODmes = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTONRFFPRODmes"), "."), 18, MidpointRounding.ToEven));
         AV8cCOSTONRFFPRODano = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTONRFFPRODano"), "."), 18, MidpointRounding.ToEven));
         AV9cCod_Area = GetPar( "cCod_Area");
         AV10cIndicadoresCodigo = GetPar( "cIndicadoresCodigo");
         AV11cCOSTONRFFPRODValoEjec = NumberUtil.Val( GetPar( "cCOSTONRFFPRODValoEjec"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPRODfec, AV7cCOSTONRFFPRODmes, AV8cCOSTONRFFPRODano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPRODValoEjec) ;
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
         PA0W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0W2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00u0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV12pCOSTONRFFPRODfec)),UrlEncode(StringUtil.LTrimStr(AV13pCOSTONRFFPRODmes,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTONRFFPRODano,4,0)),UrlEncode(StringUtil.RTrim(AV15pCod_Area)),UrlEncode(StringUtil.RTrim(AV16pIndicadoresCodigo))}, new string[] {"pCOSTONRFFPRODfec","pCOSTONRFFPRODmes","pCOSTONRFFPRODano","pCod_Area","pIndicadoresCodigo"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPRODFEC", context.localUtil.Format(AV6cCOSTONRFFPRODfec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPRODMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTONRFFPRODmes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPRODANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTONRFFPRODano), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOD_AREA", AV9cCod_Area);
         GxWebStd.gx_hidden_field( context, "GXH_vCINDICADORESCODIGO", AV10cIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTONRFFPRODVALOEJEC", StringUtil.LTrim( StringUtil.NToC( AV11cCOSTONRFFPRODValoEjec, 14, 2, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTONRFFPRODFEC", context.localUtil.DToC( AV12pCOSTONRFFPRODfec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPCOSTONRFFPRODMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pCOSTONRFFPRODmes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTONRFFPRODANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pCOSTONRFFPRODano), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOD_AREA", AV15pCod_Area);
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV16pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPRODFECFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprodfecfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPRODMESFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprodmesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPRODANOFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprodanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COD_AREAFILTERCONTAINER_Class", StringUtil.RTrim( divCod_areafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divIndicadorescodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPRODVALOEJECFILTERCONTAINER_Class", StringUtil.RTrim( divCostonrffprodvaloejecfiltercontainer_Class));
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
            WE0W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0W2( ) ;
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
         return formatLink("gx00u0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV12pCOSTONRFFPRODfec)),UrlEncode(StringUtil.LTrimStr(AV13pCOSTONRFFPRODmes,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTONRFFPRODano,4,0)),UrlEncode(StringUtil.RTrim(AV15pCod_Area)),UrlEncode(StringUtil.RTrim(AV16pIndicadoresCodigo))}, new string[] {"pCOSTONRFFPRODfec","pCOSTONRFFPRODmes","pCOSTONRFFPRODano","pCod_Area","pIndicadoresCodigo"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00U0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List COSTONRFFPROD" ;
      }

      protected void WB0W0( )
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
            GxWebStd.gx_div_start( context, divCostonrffprodfecfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprodfecfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprodfecfilter_Internalname, "COSTONRFFPRODfec", "", "", lblLblcostonrffprodfecfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110w1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprodfec_Internalname, "COSTONRFFPRODfec", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCcostonrffprodfec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprodfec_Internalname, context.localUtil.Format(AV6cCOSTONRFFPRODfec, "99/99/99"), context.localUtil.Format( AV6cCOSTONRFFPRODfec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprodfec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcostonrffprodfec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_div_start( context, divCostonrffprodmesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprodmesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprodmesfilter_Internalname, "COSTONRFFPRODmes", "", "", lblLblcostonrffprodmesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprodmes_Internalname, "COSTONRFFPRODmes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprodmes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTONRFFPRODmes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostonrffprodmes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cCOSTONRFFPRODmes), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cCOSTONRFFPRODmes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprodmes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostonrffprodmes_Visible, edtavCcostonrffprodmes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_div_start( context, divCostonrffprodanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprodanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprodanofilter_Internalname, "COSTONRFFPRODano", "", "", lblLblcostonrffprodanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprodano_Internalname, "COSTONRFFPRODano", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprodano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTONRFFPRODano), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostonrffprodano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cCOSTONRFFPRODano), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cCOSTONRFFPRODano), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprodano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostonrffprodano_Visible, edtavCcostonrffprodano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblcod_areafilter_Internalname, "Cod_Area", "", "", lblLblcod_areafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcod_area_Internalname, AV9cCod_Area, StringUtil.RTrim( context.localUtil.Format( AV9cCod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcod_area_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcod_area_Visible, edtavCcod_area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblindicadorescodigofilter_Internalname, "Indicadores Codigo", "", "", lblLblindicadorescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCindicadorescodigo_Internalname, AV10cIndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( AV10cIndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCindicadorescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCindicadorescodigo_Visible, edtavCindicadorescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00U0.htm");
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
            GxWebStd.gx_div_start( context, divCostonrffprodvaloejecfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostonrffprodvaloejecfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostonrffprodvaloejecfilter_Internalname, "COSTONRFFPRODValo Ejec", "", "", lblLblcostonrffprodvaloejecfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00U0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostonrffprodvaloejec_Internalname, "COSTONRFFPRODValo Ejec", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostonrffprodvaloejec_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11cCOSTONRFFPRODValoEjec, 14, 2, ",", "")), StringUtil.LTrim( ((edtavCcostonrffprodvaloejec_Enabled!=0) ? context.localUtil.Format( AV11cCOSTONRFFPRODValoEjec, "ZZZZZZZZZZ9.99") : context.localUtil.Format( AV11cCOSTONRFFPRODValoEjec, "ZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostonrffprodvaloejec_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostonrffprodvaloejec_Visible, edtavCcostonrffprodvaloejec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00U0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e170w1_client"+"'", TempTags, "", 2, "HLP_Gx00U0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00U0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 74 )
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

      protected void START0W2( )
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
            Form.Meta.addItem("description", "Selection List COSTONRFFPROD", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0W0( ) ;
      }

      protected void WS0W2( )
      {
         START0W2( ) ;
         EVT0W2( ) ;
      }

      protected void EVT0W2( )
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
                              nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV20Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A60COSTONRFFPRODfec = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCOSTONRFFPRODfec_Internalname), 0));
                              A61COSTONRFFPRODmes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODmes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A62COSTONRFFPRODano = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A5Cod_Area = cgiGet( edtCod_Area_Internalname);
                              A179COSTONRFFPRODValoEjec = context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODValoEjec_Internalname), ",", ".");
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
                                    E180W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E190W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccostonrffprodfec Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCCOSTONRFFPRODFEC"), 0) != AV6cCOSTONRFFPRODfec )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostonrffprodmes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPRODMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTONRFFPRODmes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostonrffprodano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPRODANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTONRFFPRODano )) )
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
                                       /* Set Refresh If Ccostonrffprodvaloejec Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPRODVALOEJEC"), ",", ".") != AV11cCOSTONRFFPRODValoEjec )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E200W2 ();
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

      protected void WE0W2( )
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

      protected void PA0W2( )
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
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        DateTime AV6cCOSTONRFFPRODfec ,
                                        short AV7cCOSTONRFFPRODmes ,
                                        short AV8cCOSTONRFFPRODano ,
                                        string AV9cCod_Area ,
                                        string AV10cIndicadoresCodigo ,
                                        decimal AV11cCOSTONRFFPRODValoEjec )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0W2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPRODFEC", GetSecureSignedToken( "", A60COSTONRFFPRODfec, context));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPRODFEC", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPRODMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A61COSTONRFFPRODmes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPRODMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A61COSTONRFFPRODmes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPRODANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A62COSTONRFFPRODano), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTONRFFPRODANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A62COSTONRFFPRODano), 4, 0, ".", "")));
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
         RF0W2( ) ;
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

      protected void RF0W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
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
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11cCOSTONRFFPRODValoEjec ,
                                                 A179COSTONRFFPRODValoEjec ,
                                                 A5Cod_Area ,
                                                 AV9cCod_Area ,
                                                 A4IndicadoresCodigo ,
                                                 AV10cIndicadoresCodigo ,
                                                 AV6cCOSTONRFFPRODfec ,
                                                 AV7cCOSTONRFFPRODmes ,
                                                 AV8cCOSTONRFFPRODano } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
            lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
            /* Using cursor H000W2 */
            pr_default.execute(0, new Object[] {AV6cCOSTONRFFPRODfec, AV7cCOSTONRFFPRODmes, AV8cCOSTONRFFPRODano, lV9cCod_Area, lV10cIndicadoresCodigo, AV11cCOSTONRFFPRODValoEjec, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A4IndicadoresCodigo = H000W2_A4IndicadoresCodigo[0];
               A179COSTONRFFPRODValoEjec = H000W2_A179COSTONRFFPRODValoEjec[0];
               A5Cod_Area = H000W2_A5Cod_Area[0];
               A62COSTONRFFPRODano = H000W2_A62COSTONRFFPRODano[0];
               A61COSTONRFFPRODmes = H000W2_A61COSTONRFFPRODmes[0];
               A60COSTONRFFPRODfec = H000W2_A60COSTONRFFPRODfec[0];
               /* Execute user event: Load */
               E190W2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB0W0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0W2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPRODFEC"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, A60COSTONRFFPRODfec, context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPRODMES"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A61COSTONRFFPRODmes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTONRFFPRODANO"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A62COSTONRFFPRODano), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
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
                                              AV11cCOSTONRFFPRODValoEjec ,
                                              A179COSTONRFFPRODValoEjec ,
                                              A5Cod_Area ,
                                              AV9cCod_Area ,
                                              A4IndicadoresCodigo ,
                                              AV10cIndicadoresCodigo ,
                                              AV6cCOSTONRFFPRODfec ,
                                              AV7cCOSTONRFFPRODmes ,
                                              AV8cCOSTONRFFPRODano } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
         lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
         /* Using cursor H000W3 */
         pr_default.execute(1, new Object[] {AV6cCOSTONRFFPRODfec, AV7cCOSTONRFFPRODmes, AV8cCOSTONRFFPRODano, lV9cCod_Area, lV10cIndicadoresCodigo, AV11cCOSTONRFFPRODValoEjec});
         GRID1_nRecordCount = H000W3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPRODfec, AV7cCOSTONRFFPRODmes, AV8cCOSTONRFFPRODano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPRODValoEjec) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPRODfec, AV7cCOSTONRFFPRODmes, AV8cCOSTONRFFPRODano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPRODValoEjec) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPRODfec, AV7cCOSTONRFFPRODmes, AV8cCOSTONRFFPRODano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPRODValoEjec) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPRODfec, AV7cCOSTONRFFPRODmes, AV8cCOSTONRFFPRODano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPRODValoEjec) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTONRFFPRODfec, AV7cCOSTONRFFPRODmes, AV8cCOSTONRFFPRODano, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTONRFFPRODValoEjec) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E180W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavCcostonrffprodfec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTONRFFPRODfec"}), 1, "vCCOSTONRFFPRODFEC");
               GX_FocusControl = edtavCcostonrffprodfec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCOSTONRFFPRODfec = DateTime.MinValue;
               AssignAttri("", false, "AV6cCOSTONRFFPRODfec", context.localUtil.Format(AV6cCOSTONRFFPRODfec, "99/99/99"));
            }
            else
            {
               AV6cCOSTONRFFPRODfec = context.localUtil.CToD( cgiGet( edtavCcostonrffprodfec_Internalname), 2);
               AssignAttri("", false, "AV6cCOSTONRFFPRODfec", context.localUtil.Format(AV6cCOSTONRFFPRODfec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprodmes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprodmes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTONRFFPRODMES");
               GX_FocusControl = edtavCcostonrffprodmes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cCOSTONRFFPRODmes = 0;
               AssignAttri("", false, "AV7cCOSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(AV7cCOSTONRFFPRODmes), 4, 0));
            }
            else
            {
               AV7cCOSTONRFFPRODmes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostonrffprodmes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cCOSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(AV7cCOSTONRFFPRODmes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprodano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprodano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTONRFFPRODANO");
               GX_FocusControl = edtavCcostonrffprodano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cCOSTONRFFPRODano = 0;
               AssignAttri("", false, "AV8cCOSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(AV8cCOSTONRFFPRODano), 4, 0));
            }
            else
            {
               AV8cCOSTONRFFPRODano = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostonrffprodano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cCOSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(AV8cCOSTONRFFPRODano), 4, 0));
            }
            AV9cCod_Area = cgiGet( edtavCcod_area_Internalname);
            AssignAttri("", false, "AV9cCod_Area", AV9cCod_Area);
            AV10cIndicadoresCodigo = cgiGet( edtavCindicadorescodigo_Internalname);
            AssignAttri("", false, "AV10cIndicadoresCodigo", AV10cIndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprodvaloejec_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostonrffprodvaloejec_Internalname), ",", ".") > 99999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTONRFFPRODVALOEJEC");
               GX_FocusControl = edtavCcostonrffprodvaloejec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cCOSTONRFFPRODValoEjec = 0;
               AssignAttri("", false, "AV11cCOSTONRFFPRODValoEjec", StringUtil.LTrimStr( AV11cCOSTONRFFPRODValoEjec, 14, 2));
            }
            else
            {
               AV11cCOSTONRFFPRODValoEjec = context.localUtil.CToN( cgiGet( edtavCcostonrffprodvaloejec_Internalname), ",", ".");
               AssignAttri("", false, "AV11cCOSTONRFFPRODValoEjec", StringUtil.LTrimStr( AV11cCOSTONRFFPRODValoEjec, 14, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCCOSTONRFFPRODFEC"), 2) ) != DateTimeUtil.ResetTime ( AV6cCOSTONRFFPRODfec ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPRODMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTONRFFPRODmes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPRODANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTONRFFPRODano )) )
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
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTONRFFPRODVALOEJEC"), ",", ".") != AV11cCOSTONRFFPRODValoEjec )
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
         E180W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E180W2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selecci�n %1", "COSTONRFFPROD", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV17ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E190W2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV20Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E200W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E200W2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pCOSTONRFFPRODfec = A60COSTONRFFPRODfec;
         AssignAttri("", false, "AV12pCOSTONRFFPRODfec", context.localUtil.Format(AV12pCOSTONRFFPRODfec, "99/99/99"));
         AV13pCOSTONRFFPRODmes = A61COSTONRFFPRODmes;
         AssignAttri("", false, "AV13pCOSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(AV13pCOSTONRFFPRODmes), 4, 0));
         AV14pCOSTONRFFPRODano = A62COSTONRFFPRODano;
         AssignAttri("", false, "AV14pCOSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(AV14pCOSTONRFFPRODano), 4, 0));
         AV15pCod_Area = A5Cod_Area;
         AssignAttri("", false, "AV15pCod_Area", AV15pCod_Area);
         AV16pIndicadoresCodigo = A4IndicadoresCodigo;
         AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV12pCOSTONRFFPRODfec, "99/99/99"),(short)AV13pCOSTONRFFPRODmes,(short)AV14pCOSTONRFFPRODano,(string)AV15pCod_Area,(string)AV16pIndicadoresCodigo});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pCOSTONRFFPRODfec","AV13pCOSTONRFFPRODmes","AV14pCOSTONRFFPRODano","AV15pCod_Area","AV16pIndicadoresCodigo"});
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
         AV12pCOSTONRFFPRODfec = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV12pCOSTONRFFPRODfec", context.localUtil.Format(AV12pCOSTONRFFPRODfec, "99/99/99"));
         AV13pCOSTONRFFPRODmes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV13pCOSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(AV13pCOSTONRFFPRODmes), 4, 0));
         AV14pCOSTONRFFPRODano = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV14pCOSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(AV14pCOSTONRFFPRODano), 4, 0));
         AV15pCod_Area = (string)getParm(obj,3);
         AssignAttri("", false, "AV15pCod_Area", AV15pCod_Area);
         AV16pIndicadoresCodigo = (string)getParm(obj,4);
         AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
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
         PA0W2( ) ;
         WS0W2( ) ;
         WE0W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231024432", true, true);
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
         context.AddJavascriptSource("gx00u0.js", "?20247231024432", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtCOSTONRFFPRODfec_Internalname = "COSTONRFFPRODFEC_"+sGXsfl_74_idx;
         edtCOSTONRFFPRODmes_Internalname = "COSTONRFFPRODMES_"+sGXsfl_74_idx;
         edtCOSTONRFFPRODano_Internalname = "COSTONRFFPRODANO_"+sGXsfl_74_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_74_idx;
         edtCOSTONRFFPRODValoEjec_Internalname = "COSTONRFFPRODVALOEJEC_"+sGXsfl_74_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtCOSTONRFFPRODfec_Internalname = "COSTONRFFPRODFEC_"+sGXsfl_74_fel_idx;
         edtCOSTONRFFPRODmes_Internalname = "COSTONRFFPRODMES_"+sGXsfl_74_fel_idx;
         edtCOSTONRFFPRODano_Internalname = "COSTONRFFPRODANO_"+sGXsfl_74_fel_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_74_fel_idx;
         edtCOSTONRFFPRODValoEjec_Internalname = "COSTONRFFPRODVALOEJEC_"+sGXsfl_74_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         SubsflControlProps_742( ) ;
         WB0W0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A61COSTONRFFPRODmes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A62COSTONRFFPRODano), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV20Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV20Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPRODfec_Internalname,context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"),context.localUtil.Format( A60COSTONRFFPRODfec, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTONRFFPRODfec_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPRODmes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A61COSTONRFFPRODmes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A61COSTONRFFPRODmes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTONRFFPRODmes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPRODano_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A62COSTONRFFPRODano), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A62COSTONRFFPRODano), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTONRFFPRODano_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCod_Area_Internalname,(string)A5Cod_Area,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCod_Area_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtCOSTONRFFPRODValoEjec_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A61COSTONRFFPRODmes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A62COSTONRFFPRODano), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+"]);";
            AssignProp("", false, edtCOSTONRFFPRODValoEjec_Internalname, "Link", edtCOSTONRFFPRODValoEjec_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTONRFFPRODValoEjec_Internalname,StringUtil.LTrim( StringUtil.NToC( A179COSTONRFFPRODValoEjec, 14, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A179COSTONRFFPRODValoEjec, "ZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCOSTONRFFPRODValoEjec_Link,(string)"",(string)"",(string)"",(string)edtCOSTONRFFPRODValoEjec_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIndicadoresCodigo_Internalname,(string)A4IndicadoresCodigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIndicadoresCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0W2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
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
            context.SendWebValue( "COSTONRFFPRODfec") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTONRFFPRODmes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTONRFFPRODano") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cod_Area") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Ejec") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A61COSTONRFFPRODmes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A62COSTONRFFPRODano), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A5Cod_Area));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A179COSTONRFFPRODValoEjec, 14, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCOSTONRFFPRODValoEjec_Link));
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
         lblLblcostonrffprodfecfilter_Internalname = "LBLCOSTONRFFPRODFECFILTER";
         edtavCcostonrffprodfec_Internalname = "vCCOSTONRFFPRODFEC";
         divCostonrffprodfecfiltercontainer_Internalname = "COSTONRFFPRODFECFILTERCONTAINER";
         lblLblcostonrffprodmesfilter_Internalname = "LBLCOSTONRFFPRODMESFILTER";
         edtavCcostonrffprodmes_Internalname = "vCCOSTONRFFPRODMES";
         divCostonrffprodmesfiltercontainer_Internalname = "COSTONRFFPRODMESFILTERCONTAINER";
         lblLblcostonrffprodanofilter_Internalname = "LBLCOSTONRFFPRODANOFILTER";
         edtavCcostonrffprodano_Internalname = "vCCOSTONRFFPRODANO";
         divCostonrffprodanofiltercontainer_Internalname = "COSTONRFFPRODANOFILTERCONTAINER";
         lblLblcod_areafilter_Internalname = "LBLCOD_AREAFILTER";
         edtavCcod_area_Internalname = "vCCOD_AREA";
         divCod_areafiltercontainer_Internalname = "COD_AREAFILTERCONTAINER";
         lblLblindicadorescodigofilter_Internalname = "LBLINDICADORESCODIGOFILTER";
         edtavCindicadorescodigo_Internalname = "vCINDICADORESCODIGO";
         divIndicadorescodigofiltercontainer_Internalname = "INDICADORESCODIGOFILTERCONTAINER";
         lblLblcostonrffprodvaloejecfilter_Internalname = "LBLCOSTONRFFPRODVALOEJECFILTER";
         edtavCcostonrffprodvaloejec_Internalname = "vCCOSTONRFFPRODVALOEJEC";
         divCostonrffprodvaloejecfiltercontainer_Internalname = "COSTONRFFPRODVALOEJECFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCOSTONRFFPRODfec_Internalname = "COSTONRFFPRODFEC";
         edtCOSTONRFFPRODmes_Internalname = "COSTONRFFPRODMES";
         edtCOSTONRFFPRODano_Internalname = "COSTONRFFPRODANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtCOSTONRFFPRODValoEjec_Internalname = "COSTONRFFPRODVALOEJEC";
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
         edtCOSTONRFFPRODValoEjec_Jsonclick = "";
         edtCOSTONRFFPRODValoEjec_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCOSTONRFFPRODano_Jsonclick = "";
         edtCOSTONRFFPRODmes_Jsonclick = "";
         edtCOSTONRFFPRODfec_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCcostonrffprodvaloejec_Jsonclick = "";
         edtavCcostonrffprodvaloejec_Enabled = 1;
         edtavCcostonrffprodvaloejec_Visible = 1;
         edtavCindicadorescodigo_Jsonclick = "";
         edtavCindicadorescodigo_Enabled = 1;
         edtavCindicadorescodigo_Visible = 1;
         edtavCcod_area_Jsonclick = "";
         edtavCcod_area_Enabled = 1;
         edtavCcod_area_Visible = 1;
         edtavCcostonrffprodano_Jsonclick = "";
         edtavCcostonrffprodano_Enabled = 1;
         edtavCcostonrffprodano_Visible = 1;
         edtavCcostonrffprodmes_Jsonclick = "";
         edtavCcostonrffprodmes_Enabled = 1;
         edtavCcostonrffprodmes_Visible = 1;
         edtavCcostonrffprodfec_Jsonclick = "";
         edtavCcostonrffprodfec_Enabled = 1;
         divCostonrffprodvaloejecfiltercontainer_Class = "AdvancedContainerItem";
         divIndicadorescodigofiltercontainer_Class = "AdvancedContainerItem";
         divCod_areafiltercontainer_Class = "AdvancedContainerItem";
         divCostonrffprodanofiltercontainer_Class = "AdvancedContainerItem";
         divCostonrffprodmesfiltercontainer_Class = "AdvancedContainerItem";
         divCostonrffprodfecfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List COSTONRFFPROD";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPRODfec',fld:'vCCOSTONRFFPRODFEC',pic:''},{av:'AV7cCOSTONRFFPRODmes',fld:'vCCOSTONRFFPRODMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPRODano',fld:'vCCOSTONRFFPRODANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTONRFFPRODValoEjec',fld:'vCCOSTONRFFPRODVALOEJEC',pic:'ZZZZZZZZZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E170W1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCOSTONRFFPRODFECFILTER.CLICK","{handler:'E110W1',iparms:[{av:'divCostonrffprodfecfiltercontainer_Class',ctrl:'COSTONRFFPRODFECFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPRODFECFILTER.CLICK",",oparms:[{av:'divCostonrffprodfecfiltercontainer_Class',ctrl:'COSTONRFFPRODFECFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLCOSTONRFFPRODMESFILTER.CLICK","{handler:'E120W1',iparms:[{av:'divCostonrffprodmesfiltercontainer_Class',ctrl:'COSTONRFFPRODMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPRODMESFILTER.CLICK",",oparms:[{av:'divCostonrffprodmesfiltercontainer_Class',ctrl:'COSTONRFFPRODMESFILTERCONTAINER',prop:'Class'},{av:'edtavCcostonrffprodmes_Visible',ctrl:'vCCOSTONRFFPRODMES',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTONRFFPRODANOFILTER.CLICK","{handler:'E130W1',iparms:[{av:'divCostonrffprodanofiltercontainer_Class',ctrl:'COSTONRFFPRODANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPRODANOFILTER.CLICK",",oparms:[{av:'divCostonrffprodanofiltercontainer_Class',ctrl:'COSTONRFFPRODANOFILTERCONTAINER',prop:'Class'},{av:'edtavCcostonrffprodano_Visible',ctrl:'vCCOSTONRFFPRODANO',prop:'Visible'}]}");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK","{handler:'E140W1',iparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK",",oparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'},{av:'edtavCcod_area_Visible',ctrl:'vCCOD_AREA',prop:'Visible'}]}");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK","{handler:'E150W1',iparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK",",oparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCindicadorescodigo_Visible',ctrl:'vCINDICADORESCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTONRFFPRODVALOEJECFILTER.CLICK","{handler:'E160W1',iparms:[{av:'divCostonrffprodvaloejecfiltercontainer_Class',ctrl:'COSTONRFFPRODVALOEJECFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTONRFFPRODVALOEJECFILTER.CLICK",",oparms:[{av:'divCostonrffprodvaloejecfiltercontainer_Class',ctrl:'COSTONRFFPRODVALOEJECFILTERCONTAINER',prop:'Class'},{av:'edtavCcostonrffprodvaloejec_Visible',ctrl:'vCCOSTONRFFPRODVALOEJEC',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E200W2',iparms:[{av:'A60COSTONRFFPRODfec',fld:'COSTONRFFPRODFEC',pic:'',hsh:true},{av:'A61COSTONRFFPRODmes',fld:'COSTONRFFPRODMES',pic:'ZZZ9',hsh:true},{av:'A62COSTONRFFPRODano',fld:'COSTONRFFPRODANO',pic:'ZZZ9',hsh:true},{av:'A5Cod_Area',fld:'COD_AREA',pic:'',hsh:true},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pCOSTONRFFPRODfec',fld:'vPCOSTONRFFPRODFEC',pic:''},{av:'AV13pCOSTONRFFPRODmes',fld:'vPCOSTONRFFPRODMES',pic:'ZZZ9'},{av:'AV14pCOSTONRFFPRODano',fld:'vPCOSTONRFFPRODANO',pic:'ZZZ9'},{av:'AV15pCod_Area',fld:'vPCOD_AREA',pic:''},{av:'AV16pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPRODfec',fld:'vCCOSTONRFFPRODFEC',pic:''},{av:'AV7cCOSTONRFFPRODmes',fld:'vCCOSTONRFFPRODMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPRODano',fld:'vCCOSTONRFFPRODANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTONRFFPRODValoEjec',fld:'vCCOSTONRFFPRODVALOEJEC',pic:'ZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPRODfec',fld:'vCCOSTONRFFPRODFEC',pic:''},{av:'AV7cCOSTONRFFPRODmes',fld:'vCCOSTONRFFPRODMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPRODano',fld:'vCCOSTONRFFPRODANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTONRFFPRODValoEjec',fld:'vCCOSTONRFFPRODVALOEJEC',pic:'ZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPRODfec',fld:'vCCOSTONRFFPRODFEC',pic:''},{av:'AV7cCOSTONRFFPRODmes',fld:'vCCOSTONRFFPRODMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPRODano',fld:'vCCOSTONRFFPRODANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTONRFFPRODValoEjec',fld:'vCCOSTONRFFPRODVALOEJEC',pic:'ZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTONRFFPRODfec',fld:'vCCOSTONRFFPRODFEC',pic:''},{av:'AV7cCOSTONRFFPRODmes',fld:'vCCOSTONRFFPRODMES',pic:'ZZZ9'},{av:'AV8cCOSTONRFFPRODano',fld:'vCCOSTONRFFPRODANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTONRFFPRODValoEjec',fld:'vCCOSTONRFFPRODVALOEJEC',pic:'ZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCOSTONRFFPRODFEC","{handler:'Validv_Ccostonrffprodfec',iparms:[]");
         setEventMetadata("VALIDV_CCOSTONRFFPRODFEC",",oparms:[]}");
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
         AV12pCOSTONRFFPRODfec = DateTime.MinValue;
         AV15pCod_Area = "";
         AV16pIndicadoresCodigo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cCOSTONRFFPRODfec = DateTime.MinValue;
         AV9cCod_Area = "";
         AV10cIndicadoresCodigo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcostonrffprodfecfilter_Jsonclick = "";
         TempTags = "";
         lblLblcostonrffprodmesfilter_Jsonclick = "";
         lblLblcostonrffprodanofilter_Jsonclick = "";
         lblLblcod_areafilter_Jsonclick = "";
         lblLblindicadorescodigofilter_Jsonclick = "";
         lblLblcostonrffprodvaloejecfilter_Jsonclick = "";
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
         AV20Linkselection_GXI = "";
         A60COSTONRFFPRODfec = DateTime.MinValue;
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         scmdbuf = "";
         lV9cCod_Area = "";
         lV10cIndicadoresCodigo = "";
         H000W2_A4IndicadoresCodigo = new string[] {""} ;
         H000W2_A179COSTONRFFPRODValoEjec = new decimal[1] ;
         H000W2_A5Cod_Area = new string[] {""} ;
         H000W2_A62COSTONRFFPRODano = new short[1] ;
         H000W2_A61COSTONRFFPRODmes = new short[1] ;
         H000W2_A60COSTONRFFPRODfec = new DateTime[] {DateTime.MinValue} ;
         H000W3_AGRID1_nRecordCount = new long[1] ;
         AV17ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00u0__default(),
            new Object[][] {
                new Object[] {
               H000W2_A4IndicadoresCodigo, H000W2_A179COSTONRFFPRODValoEjec, H000W2_A5Cod_Area, H000W2_A62COSTONRFFPRODano, H000W2_A61COSTONRFFPRODmes, H000W2_A60COSTONRFFPRODfec
               }
               , new Object[] {
               H000W3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13pCOSTONRFFPRODmes ;
      private short AV14pCOSTONRFFPRODano ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cCOSTONRFFPRODmes ;
      private short AV8cCOSTONRFFPRODano ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A61COSTONRFFPRODmes ;
      private short A62COSTONRFFPRODano ;
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
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCcostonrffprodfec_Enabled ;
      private int edtavCcostonrffprodmes_Enabled ;
      private int edtavCcostonrffprodmes_Visible ;
      private int edtavCcostonrffprodano_Enabled ;
      private int edtavCcostonrffprodano_Visible ;
      private int edtavCcod_area_Visible ;
      private int edtavCcod_area_Enabled ;
      private int edtavCindicadorescodigo_Visible ;
      private int edtavCindicadorescodigo_Enabled ;
      private int edtavCcostonrffprodvaloejec_Enabled ;
      private int edtavCcostonrffprodvaloejec_Visible ;
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
      private decimal AV11cCOSTONRFFPRODValoEjec ;
      private decimal A179COSTONRFFPRODValoEjec ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCostonrffprodfecfiltercontainer_Class ;
      private string divCostonrffprodmesfiltercontainer_Class ;
      private string divCostonrffprodanofiltercontainer_Class ;
      private string divCod_areafiltercontainer_Class ;
      private string divIndicadorescodigofiltercontainer_Class ;
      private string divCostonrffprodvaloejecfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divCostonrffprodfecfiltercontainer_Internalname ;
      private string lblLblcostonrffprodfecfilter_Internalname ;
      private string lblLblcostonrffprodfecfilter_Jsonclick ;
      private string edtavCcostonrffprodfec_Internalname ;
      private string TempTags ;
      private string edtavCcostonrffprodfec_Jsonclick ;
      private string divCostonrffprodmesfiltercontainer_Internalname ;
      private string lblLblcostonrffprodmesfilter_Internalname ;
      private string lblLblcostonrffprodmesfilter_Jsonclick ;
      private string edtavCcostonrffprodmes_Internalname ;
      private string edtavCcostonrffprodmes_Jsonclick ;
      private string divCostonrffprodanofiltercontainer_Internalname ;
      private string lblLblcostonrffprodanofilter_Internalname ;
      private string lblLblcostonrffprodanofilter_Jsonclick ;
      private string edtavCcostonrffprodano_Internalname ;
      private string edtavCcostonrffprodano_Jsonclick ;
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
      private string divCostonrffprodvaloejecfiltercontainer_Internalname ;
      private string lblLblcostonrffprodvaloejecfilter_Internalname ;
      private string lblLblcostonrffprodvaloejecfilter_Jsonclick ;
      private string edtavCcostonrffprodvaloejec_Internalname ;
      private string edtavCcostonrffprodvaloejec_Jsonclick ;
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
      private string edtCOSTONRFFPRODfec_Internalname ;
      private string edtCOSTONRFFPRODmes_Internalname ;
      private string edtCOSTONRFFPRODano_Internalname ;
      private string edtCod_Area_Internalname ;
      private string edtCOSTONRFFPRODValoEjec_Internalname ;
      private string edtIndicadoresCodigo_Internalname ;
      private string scmdbuf ;
      private string AV17ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCOSTONRFFPRODfec_Jsonclick ;
      private string edtCOSTONRFFPRODmes_Jsonclick ;
      private string edtCOSTONRFFPRODano_Jsonclick ;
      private string edtCod_Area_Jsonclick ;
      private string edtCOSTONRFFPRODValoEjec_Link ;
      private string edtCOSTONRFFPRODValoEjec_Jsonclick ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV12pCOSTONRFFPRODfec ;
      private DateTime AV6cCOSTONRFFPRODfec ;
      private DateTime A60COSTONRFFPRODfec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV15pCod_Area ;
      private string AV16pIndicadoresCodigo ;
      private string AV9cCod_Area ;
      private string AV10cIndicadoresCodigo ;
      private string AV20Linkselection_GXI ;
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
      private string[] H000W2_A4IndicadoresCodigo ;
      private decimal[] H000W2_A179COSTONRFFPRODValoEjec ;
      private string[] H000W2_A5Cod_Area ;
      private short[] H000W2_A62COSTONRFFPRODano ;
      private short[] H000W2_A61COSTONRFFPRODmes ;
      private DateTime[] H000W2_A60COSTONRFFPRODfec ;
      private long[] H000W3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP0_pCOSTONRFFPRODfec ;
      private short aP1_pCOSTONRFFPRODmes ;
      private short aP2_pCOSTONRFFPRODano ;
      private string aP3_pCod_Area ;
      private string aP4_pIndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class gx00u0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000W2( IGxContext context ,
                                             decimal AV11cCOSTONRFFPRODValoEjec ,
                                             decimal A179COSTONRFFPRODValoEjec ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             DateTime AV6cCOSTONRFFPRODfec ,
                                             short AV7cCOSTONRFFPRODmes ,
                                             short AV8cCOSTONRFFPRODano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [IndicadoresCodigo], [COSTONRFFPRODValoEjec], [Cod_Area], [COSTONRFFPRODano], [COSTONRFFPRODmes], [COSTONRFFPRODfec]";
         sFromString = " FROM [COSTONRFFPROD]";
         sOrderString = "";
         AddWhere(sWhereString, "([COSTONRFFPRODfec] >= @AV6cCOSTONRFFPRODfec and [COSTONRFFPRODmes] >= @AV7cCOSTONRFFPRODmes and [COSTONRFFPRODano] >= @AV8cCOSTONRFFPRODano)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         if ( ! (Convert.ToDecimal(0)==AV11cCOSTONRFFPRODValoEjec) )
         {
            AddWhere(sWhereString, "([COSTONRFFPRODValoEjec] >= @AV11cCOSTONRFFPRODValoEjec)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [Cod_Area], [IndicadoresCodigo]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000W3( IGxContext context ,
                                             decimal AV11cCOSTONRFFPRODValoEjec ,
                                             decimal A179COSTONRFFPRODValoEjec ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             DateTime AV6cCOSTONRFFPRODfec ,
                                             short AV7cCOSTONRFFPRODmes ,
                                             short AV8cCOSTONRFFPRODano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [COSTONRFFPROD]";
         AddWhere(sWhereString, "([COSTONRFFPRODfec] >= @AV6cCOSTONRFFPRODfec and [COSTONRFFPRODmes] >= @AV7cCOSTONRFFPRODmes and [COSTONRFFPRODano] >= @AV8cCOSTONRFFPRODano)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         if ( ! (Convert.ToDecimal(0)==AV11cCOSTONRFFPRODValoEjec) )
         {
            AddWhere(sWhereString, "([COSTONRFFPRODValoEjec] >= @AV11cCOSTONRFFPRODValoEjec)");
         }
         else
         {
            GXv_int3[5] = 1;
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
                     return conditional_H000W2(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
               case 1 :
                     return conditional_H000W3(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmH000W2;
          prmH000W2 = new Object[] {
          new ParDef("@AV6cCOSTONRFFPRODfec",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTONRFFPRODmes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTONRFFPRODano",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cCOSTONRFFPRODValoEjec",GXType.Decimal,14,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000W3;
          prmH000W3 = new Object[] {
          new ParDef("@AV6cCOSTONRFFPRODfec",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTONRFFPRODmes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTONRFFPRODano",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cCOSTONRFFPRODValoEjec",GXType.Decimal,14,2)
          };
          def= new CursorDef[] {
              new CursorDef("H000W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000W2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000W3,1, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
